Public Class GST_OA_convert

    Private Sub GST_OA_convert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select customer_name,customer_id from ra_customers where status='A' order by  customer_name"

        ds = SQL_SELECT("org", sql)
        cmb_customer.DataSource = ds.Tables("org")
        cmb_customer.ValueMember = "customer_id"
        cmb_customer.DisplayMember = "customer_name"


    End Sub

    Private Sub btn_interface_OA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_interface_OA.Click
        If retval("select count(1) from JAN_GST_REG_DETAILS_VIEW_T where PARTY_CLASS_NAME='Customer' and REGISTRATION_TYPE_NAME='GST Registration Number' and party_id=" & cmb_customer.SelectedValue.ToString) = "0" Then
            MsgBox("GST No not Found !..")
            Exit Sub
        End If
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim J As Integer = 0
        sql = "SELECT  ORDER_NUMBER,SUM(PEND_QTY)PEND_QTY FROM JAN_BMS_ORDER_PENDING_NEW_V A WHERE ORDER_NUMBER IN (SELECT ORDER_NUMBER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE 1=1 "
        If cmb_customer.Text <> "" Then
            sql &= "  and B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        ElseIf txt_old_oa.Text <> "" Then
            sql &= " and order_number='" & txt_old_oa.Text & "'"
        Else
            MessageBox.Show("Enter Order Number or Customer Name and Migrate", "GST OA Migration", MessageBoxButtons.OK)
            Exit Sub
        End If

        sql &= " AND ORDER_NUMBER NOT IN (SELECT ATTRIBUTE18 FROM OE_ORDER_HEADERS_ALL WHERE ORDERED_DATE>'1-JUL-2017' AND ATTRIBUTE18 IS NOT NULL  AND FLOW_STATUS_CODE<>'CANCELLED')) AND PEND_QTY>0 and ORDERED_DATE<'1-jul-2017' GROUP BY ORDER_NUMBER"
        ds = SQL_SELECT("PEND_ORDER", sql)
        For J = 0 To ds.Tables("PEND_ORDER").Rows.Count - 1
            With ds.Tables("PEND_ORDER").Rows(J)
                sql = " insert into JAN_I23_ORDER_CREATION_TABLE62  "
                sql &= " SELECT ORDER_NUMBER,	LINE_ID,	ORD_TYPE,	UNIT_LIST_PRICE,	UNIT_SELLING_PRICE,	DISC,	SCHEDULE_SHIP_DATE,	ORD_CAT,	null TAX_CATEGORY,	CUST_NAME,	REGION,jan_orgcode(ship_from_org_id)	ORG,	ORDERED_ITEM,	ON_HAND,PEND_QTY,	RSV_QTY,0	ALLOTABLE,	0 PROD_PEND,0	I03_CANCEL_OA_QTY,0	I03_EDIT_OA_QTY,pend_qty	I23_ADD_OA_QTY,ORD_TYPE 	TRANSACTION_TYPE,"
                '         sql &= "(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V  WHERE CUSTOMER_ID=a.b_CUST_ID and SITE_USE_ID is null)	PAYMANT_TERMS,
                sql &= "  ( select name from RA_TERMS where TERM_ID=(select PAYMENT_TERM_ID from  oe_order_headers_all oh where oh.ORDER_NUMBER=a.order_number))PAYMENT_TERMS,"
                sql &= "B_CUST_ID,( SELECT QP.NAME FROM OE_ORDER_LINES_ALL OEL,QP_LIST_HEADERS_ALL QP WHERE OEL.LINE_ID=A.LINE_ID AND   QP.LIST_HEADER_ID=OEL.PRICE_LIST_ID)PRICE_LIST_NAME ,	SHIP_to_ORG_ID,	INVOICE_TO_ORG_ID,	SOLD_TO_ORG_ID,	0 OE_DSP_ID,(select PRIMARY_UOM_CODE from MTL_SYSTEM_ITEMS where INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID AND ORGANIZATION_ID=A.SHIP_from_ORG_ID)	UOM,	ship_from_org_id ORGANIZATION_ID,(select distinct ATTRIBUTE6 from OE_ORDER_LINES_ALL where HEADER_ID=a.HEADER_ID and ATTRIBUTE6 is not null and rownum=1)	CUSTOMER_PO_NO,(sELECT DISTINCT attribute8 FROM OE_ORDER_LINES_ALL WHERE HEADER_ID=a.HEADER_ID  AND ATTRIBUTE8 IS NOT NULL  AND ROWNUM=1)	CUSTOMER_PO_REF,	HEADER_ID,(select distinct ATTRIBUTE7 from OE_ORDER_LINES_ALL where HEADER_ID=a.HEADER_ID  and ATTRIBUTE7 is not null  and rownum=1)CUSTOMER_PO_DT,	INVENTORY_ITEM_ID,(select ATTRIBUTE10 from OE_ORDER_LINES_ALL where LINE_ID=a.LINE_ID)DRAWING_NO,	b_CUST_ID,"
                'sql &= "(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V  WHERE CUSTOMER_ID=a.b_CUST_ID and SITE_USE_ID is null)PAYMENT_TERMS,"
                sql &= "  ( select name from RA_TERMS where TERM_ID=(select PAYMENT_TERM_ID from  oe_order_headers_all oh where oh.ORDER_NUMBER=a.order_number))PAYMENT_TERMS,"
                sql &= "( SELECT QP.LIST_HEADER_ID FROM OE_ORDER_LINES_ALL OEL,QP_LIST_HEADERS_ALL QP WHERE OEL.LINE_ID=A.LINE_ID AND   QP.LIST_HEADER_ID=OEL.PRICE_LIST_ID)PRICE_LIST_ID ,'N' INTERFACE from JAN_BMS_ORDER_PENDING_NEW_V a where ORDER_NUMBER='" & .Item("ORDER_NUMBER") & "' and PEND_QTY>0 and ORDERED_DATE<'1-jul-2017'"
                comand()

            End With

        Next

        sql = " DECLARE BEGIN jan_GST_order_interface_opt ; END;"
        comand()
        MessageBox.Show("Old Order Moved to Interface ", "Old Order GST Migration", MessageBoxButtons.OK)

        btn_interface_OA.Enabled = False
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btn_view_new_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_new_order.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        sql = "SELECT B.*,"
        sql &= " (select case when B.OLD_OA_P_F_PER is  null and b.FREIGHT_PER is null and STATE_CODE=33  and SALES_PERCENTAGE=18 then         'U1_Sal_Local_Dly_18%' "
        sql &= " when B.OLD_OA_P_F_PER is  null and b.FREIGHT_PER is null and STATE_CODE=33  and SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_Local_Dly_28%'  "
        sql &= " when B.OLD_OA_P_F_PER is  null and b.FREIGHT_PER is null and  STATE_CODE<>33  and SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_Interstate_Dly_18%' "
        sql &= " when B.OLD_OA_P_F_PER is  null and b.FREIGHT_PER is null and STATE_CODE<>33  and SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_Interstate_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1.5 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1.5%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2.5 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2.5%_Local_Dly_18%'"

        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1.5 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1.5%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2.5 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2.5%_Local_Dly_28%'"

        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= "  'U1_Sal_P&F_1%_Interstate_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= "  'U1_Sal_P&F_1.5%_Interstate_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2%_Interstate_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2.5%_Interstate_Dly_18%'"

        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1%_Interstate_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=1.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1.5%_Interstate_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2%_Interstate_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is null and OLD_OA_P_F_PER=2.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2.5%_Interstate_Dly_28%'"

        '--freight 
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1%_Fre_2.5%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1.5 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1.5%_Fre_2.5%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2%_Fre_2.5%_Local_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2.5 and STATE_CODE=33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2.5%_Fre_2.5%_Local_Dly_18%'"

        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1%_Fre_2.5%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1.5 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1.5%_Fre_2.5%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2%_Fre_2.5%_Local_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2.5 and STATE_CODE=33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_2.5%_Fre_2.5%_Local_Dly_28%'"

        sql &= "  when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1%_Fre_2.5%_Interstate_Dly_18%'"
        sql &= "  when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_1.5%_Fre_2.5%_Interstate_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2%_Fre_2.5%_Interstate_Dly_18%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2.5 and STATE_CODE<>33 and  SALES_PERCENTAGE=18 then "
        sql &= " 'U1_Sal_P&F_2.5%_Fre_2.5%_Interstate_Dly_18%'"

        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=1 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= " 'U1_Sal_P&F_1%_Fre_2.5%_Interstate_Dly_28%'"
        sql &= " WHEN B.OLD_OA_P_F_PER IS  NOT NULL AND b.FREIGHT_PER IS NOT NULL AND OLD_OA_P_F_PER=1.5 AND STATE_CODE<>33 AND  SALES_PERCENTAGE=28 THEN "
        sql &= "   'U1_Sal_P&F_1.5%_Fre_2.5%_Interstate_Dly_28%'"
        sql &= " when B.OLD_OA_P_F_PER is  not null and b.FREIGHT_PER is not null and OLD_OA_P_F_PER=2 and STATE_CODE<>33 and  SALES_PERCENTAGE=28 then "
        sql &= "  'U1_Sal_P&F_2%_Fre_2.5%_Interstate_Dly_28%'"
        sql &= " WHEN B.OLD_OA_P_F_PER IS  NOT NULL AND b.FREIGHT_PER IS not NULL AND OLD_OA_P_F_PER=2.5 AND STATE_CODE<>33 AND  SALES_PERCENTAGE=28 THEN "
        sql &= "   'U1_Sal_P&F_2.5%_Fre_2.5%_Interstate_Dly_28%'"
        sql &= " end new_tax_category"

        sql &= " FROM JAI_TAX_CATEGORIES WHERE  UPPER(TAX_CATEGORY_NAME) LIKE 'U1%SAL%' AND ROWNUM=1"
        sql &= "  )new_tax_category   "

        sql &= " FROM ("
        sql &= " select ORDER_NUMBER old_order_number"

        sql &= " ,(select DISTINCT ORDER_NUMBER from OE_ORDER_HEADERS_ALL OEH,OE_ORDER_LINES_ALL OEL where OEH.ORDERED_DATE>'1-JUL-2017'"
        sql &= " And  Oeh.Header_Id=Oel.Header_Id And Oeh.Attribute18=A.Order_Number And "
        sql &= " OEL.INVENTORY_ITEM_ID=JAN_ITEMNO(a.ORDERED_ITEM) AND OEH.FLOW_STATUS_CODE<>'CANCELLED' and rownum=1)NEW_ORDER_NO"
        sql &= " ,LINE_ID ,ORD_TYPE,UNIT_LIST_PRICE ,UNIT_SELLING_PRICE  Old_UNIT_SELLING_PRICE"

        sql &= "  ,nvl( (select DISTINCT UNIT_SELLING_PRICE from jan_bms_order_pending_new_v where line_id in (SELECT LINE_ID FROM OE_ORDER_LINES_ALL  OL2 WHERE OL2.ATTRIBUTE17=TO_CHAR(A.LINE_ID) ) AND FLOW_STATUS_CODE<>'CANCELLED'),0)NEW_UNIT_SELLING_PRICE"

        sql &= " ,DISC,SCHEDULE_SHIP_DATE,ORD_CAT , CUST_NAME,REGION ,ORG ,ORDERED_ITEM , PEND_QTY ,RSV_QTY ""Freezed Rsv Qty"""

        sql &= "  ,(select rsv_qty from jan_bms_order_pending_new_v where line_id=a.line_id)""Old OA Current Rsv Qty"""
        sql &= "  , (select DISTINCT rsv_qty from jan_bms_order_pending_new_v where line_id in (SELECT LINE_ID FROM OE_ORDER_LINES_ALL  OL2 WHERE OL2.ATTRIBUTE17=TO_CHAR(A.LINE_ID) ) AND FLOW_STATUS_CODE<>'CANCELLED')""New OA Rsv Qty"""

        sql &= " , PRICE_LIST_NAME ,UOM  ,CUSTOMER_PO_NO,CUSTOMER_PO_REF ,CUSTOMER_PO_DT  ,DRAWING_NO , PAYMENT_TERMS,INTERFACED "

        sql &= " ,(select HSN_CODE from JAN_ITEM_HSN_MASTER_V where  ORGANIZATION_ID=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=JAN_ITEMNO(a.ORDERED_ITEM))HSN_CODE"
        sql &= " ,(select SALES_PERCENTAGE from JAN_HSN_TOT where  ORGANIZATION_ID=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=JAN_ITEMNO(a.ORDERED_ITEM))SALES_PERCENTAGE"
        sql &= " , "
        sql &= " (SELECT REGISTRATION_NUMBER FROM JAN_GST_REG_DETAILS_VIEW   WHERE PARTY_id=a.b_cust_id AND REGISTRATION_TYPE_NAME='GST Registration Number'  and party_class_name='Customer'"
        sql &= " AND ROWNUM=1)CUST_GST_NO"
        sql &= " , "
        sql &= " (select STATE_CODE from JAN_GST_REG_DETAILS_VIEW   where PARTY_id=a.B_CUST_id and REGISTRATION_TYPE_NAME='GST Registration Number'  "
        sql &= " and rownum=1)STATE_CODE "
        sql &= " , "
        sql &= " (SELECT STATE_CODE FROM JAN_GST_REG_DETAILS_VIEW   WHERE PARTY_ID=A.B_CUST_ID AND REGISTRATION_TYPE_NAME='GST Registration Number'  and party_class_name='Customer'"
        sql &= " and rownum=1)STATE_CODE_new "
        sql &= " ,(select distinct TAX_CATEGORY from JAN_ORDER_PEND_ASON_5JUL2017 where ORDER_NUMBER=a.ORDER_NUMBER   AND ROWNUM=1 )OLD_TAX_CATEGORY"
        sql &= " ,(select distinct trim(case when UPPER(TAX_CATEGORY) like '%P%F%' then SUBSTR(TAX_CATEGORY,INSTR(TAX_CATEGORY,'-')+1, INSTR(TAX_CATEGORY,'%')-INSTR(TAX_CATEGORY,'-')-1) end)"
        sql &= " FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE ORDER_NUMBER=A.ORDER_NUMBER  AND ROWNUM=1)OLD_OA_P_F_PER"
        sql &= " ,(SELECT DISTINCT FREIGHT_PER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE ORDER_NUMBER=A.ORDER_NUMBER    AND ROWNUM=1)FREIGHT_PER"
       
        sql &= "  FROM jan_GST_interfaced_order  a where order_number in ("

        sql &= "SELECT  distinct ORDER_NUMBER FROM JAN_BMS_ORDER_PENDING_NEW_V  WHERE ORDER_NUMBER IN ("
        sql &= " SELECT DISTINCT ORDER_NUMBER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE  1=1 "

        If cmb_customer.Text <> "" Then sql &= " and  B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        If txt_old_oa.Text <> "" Then sql &= " and order_number='" & txt_old_oa.Text & "'"


        sql &= " ) and   PEND_QTY>0 and ORDERED_DATE<'1-jul-2017' "
        sql &= " )"

        sql &= " )b "

        'HUssain
        sql = "select * from JAN_GST_INTERFACED_ORDER_V where 1=1 "
        If cmb_customer.Text <> "" Then sql &= " and  B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        If txt_old_oa.Text <> "" Then sql &= " and order_number='" & txt_old_oa.Text & "'"
        ds = SQL_SELECT("val", sql)
        With DataGridView1
            .DataSource = ds.Tables("val")
            .Columns("old_order_number").DefaultCellStyle.BackColor = Color.LightGreen
            .Columns("NEW_ORDER_NO").DefaultCellStyle.BackColor = Color.LightYellow
           

        End With
        For i = 0 To DataGridView1.RowCount - 1
            With DataGridView1.Rows(i)
                'IF .Cells 
                If .Cells("oLD_UNIT_SELLING_PRICE").Value <> .Cells("NEW_UNIT_SELLING_PRICE").Value Then
                    .Cells("NEW_UNIT_SELLING_PRICE").Style.BackColor = Color.Red
                End If
            End With

        Next



        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = " DECLARE BEGIN jan_migrarte_logistics ; END;"
        comand()
        MessageBox.Show("Logistics Migrated ", "Old Order GST Migration", MessageBoxButtons.OK)
    End Sub

    Private Sub BTN_LINES_IN_INTERFACE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LINES_IN_INTERFACE.Click
        sql = "select count(*)CNT from oe_headers_iface_All where  attribute18 in (SELECT  distinct ORDER_NUMBER FROM JAN_BMS_ORDER_PENDING_NEW_V A WHERE ORDER_NUMBER IN (SELECT ORDER_NUMBER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE "


        If cmb_customer.Text <> "" Then
            sql &= " B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        ElseIf txt_old_oa.Text <> "" Then
            sql &= " and order_number='" & txt_old_oa.Text & "'"
        End If

        sql &= " ) AND PEND_QTY>0 and ORDERED_DATE<'1-jul-2017' )"
        ds = SQL_SELECT("PEND_ORDER", sql)
        MessageBox.Show("Lines in Interface  ::" & ds.Tables("PEND_ORDER").Rows(0).Item("CNT") & "", "Lines in Interface ", MessageBoxButtons.OK)
    End Sub

    Private Sub cmb_customer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_customer.SelectedIndexChanged
        btn_interface_OA.Enabled = True
    End Sub

    Private Sub btn_migrate_rsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_migrate_rsv.Click
        sql = "SELECT  ORDER_NUMBER,SUM(PEND_QTY)PEND_QTY FROM JAN_BMS_ORDER_PENDING_NEW_V A WHERE ORDER_NUMBER IN (SELECT ORDER_NUMBER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE 1=1 "

        If cmb_customer.Text <> "" Then
            sql &= "and  B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        ElseIf txt_old_oa.Text <> "" Then
            sql &= " and order_number='" & txt_old_oa.Text & "'"
       
        End If

        sql &= " ) AND PEND_QTY>0 and ORDERED_DATE<'1-jul-2017' GROUP BY ORDER_NUMBER"
        ds = SQL_SELECT("PEND_ORDER", sql)

        For j = 0 To ds.Tables("PEND_ORDER").Rows.Count - 1
            With ds.Tables("PEND_ORDER").Rows(j)
                sql = " DECLARE BEGIN JAN_ORDER_RSV_MIGRATE('" & .Item("ORDER_NUMBER") & "') ; END;"
                comand()
            End With
        Next
        MessageBox.Show("Lines in  moved for Reservation migration ", "Lines in Interface", MessageBoxButtons.OK)

    End Sub
    Private Sub btn_rsv_interface_lines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rsv_interface_lines.Click
        sql = "select JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_SEGMENT1 ITEM_NO,RESERVATION_QUANTITY,ERROR_CODE,ERROR_EXPLANATION from MTL_RESERVATIONS_INTERFACE where DEMAND_SOURCE_LINE_ID in (select (SELECT LINE_ID FROM OE_ORDER_LINES_ALL  OL2 WHERE OL2.ATTRIBUTE17=TO_CHAR(A.LINE_ID)) LINE_ID from jan_bms_order_pending_new_v A where order_number in (SELECT  ORDER_NUMBER FROM JAN_BMS_ORDER_PENDING_NEW_V  WHERE ORDER_NUMBER IN (SELECT ORDER_NUMBER FROM JAN_ORDER_PEND_ASON_5JUL2017 WHERE 1=1 "
        If cmb_customer.Text <> "" Then
            sql &= " and  B_CUST_NAME='" & cmb_customer.Text.Replace("'", "''") & "' "
        ElseIf txt_old_oa.Text <> "" Then
            sql &= " and order_number='" & txt_old_oa.Text & "'"
        End If
        sql &= " ) AND PEND_QTY>0 and ORDERED_DATE<'1-jul-2017'))"

        ds = SQL_SELECT("org", sql)
        DGV_RSV_INTERFACE.DataSource = ds.Tables("ORG")
        'MessageBox.Show("Lines in Interface  ::" & ds.Tables("org").Rows(0).Item("CNT") & "", "Lines in Interface ", MessageBoxButtons.OK)
    End Sub
End Class