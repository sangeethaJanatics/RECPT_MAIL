Imports System.Data.OracleClient

Public Class Stock_transfer_OA
    'Dim con As New Odbc.OdbcConnection("Driver=Microsoft ODBC for oracle;uid=jan_it;pwd=janapps;server=prod")
    Dim ds As New DataSet
    'Dim adap As New Odbc.OdbcDataAdapter
    'Dim cmd As New Odbc.OdbcCommand
    Dim vendor_address, unit_5_6_oa As String
    Private Sub btn_show_lines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show_lines.Click
        Label2.Visible = False

        unit_5_6_oa = ""

        If txt_po_no.Text <> "" Then
            sql = "SELECT JAN_ITEMNAME(ITEM_ID)ITEM_NO,QUANTITY,UNIT_PRICE,(SELECT SHIP_TO_ORGANIZATION_ID FROM PO_LINE_LOCATIONS_ALL   WHERE PO_LINE_ID=POL.PO_LINE_ID )TO_ORGANIZATION_ID,(SELECT NEED_BY_DATE FROM PO_LINE_LOCATIONS_ALL   WHERE PO_LINE_ID=POL.PO_LINE_ID )NEED_BY_DATE,POH.VENDOR_ID,(SELECT ADDRESS_LINE1 FROM PO_VENDOR_SITES_ALL WHERE  VENDOR_ID=POH.VENDOR_ID AND VENDOR_SITE_ID=POH.VENDOR_SITE_ID )VENDOR_ADDRESS,(SELECT ORG_ID FROM PO_VENDOR_SITES_ALL WHERE  VENDOR_ID=POH.VENDOR_ID AND VENDOR_SITE_ID=POH.VENDOR_SITE_ID )OPERATING_UNIT_ID FROM PO_HEADERS_ALL POH,PO_LINES_ALL POL WHERE POH.PO_HEADER_ID =POL.PO_HEADER_ID AND POH.SEGMENT1 ='" & Trim(txt_po_no.Text) & "'"

            sql = "SELECT poh.creation_date po_date,(SELECT VENDOR_NAME FROM PO_VENDORS WHERE VENDOR_ID=POH.VENDOR_ID)VENDOR_NAME,POH.SEGMENT1 PO_NO,POH.VENDOR_ID,POH.VENDOR_SITE_ID,POL.QUANTITY,ROUND(NVL((POL.UNIT_PRICE),0),2)*NVL(POH.RATE,1) PO_RATE ,SHIP_TO_ORGANIZATION_ID,(select address_line1 from PO_VENDOR_SITES_ALL where  vendor_ID=poh.vendor_id and vendor_site_id=POH.VENDOR_SITE_ID)vendor_address,poll.need_by_date FROM PO_HEADERS_ALL POH ,PO_LINES_ALL POL ,PO_LINE_LOCATIONS_ALL POLL WHERE POH.PO_HEADER_ID=POL.PO_HEADER_ID AND POL.PO_LINE_ID=POLL.PO_LINE_ID  AND POH.SEGMENT1='" & Trim(txt_po_no.Text) & "'"

            sql = "select POH.SEGMENT1 PO_NO,POH.CREATION_DATE PO_DATE,JAN_ORGCODE(SHIP_TO_ORGANIZATION_ID)ORG "

            sql &= " ,JAN_ITEMNAME(POL.ITEM_ID)ITEM_NO,POL.QUANTITY,ROUND(NVL((POL.UNIT_PRICE),0),2)*NVL(POH.RATE,1) PO_RATE,poll.need_by_date ,POH.VENDOR_SITE_ID,(select VENDOR_NAME from PO_VENDORS where VENDOR_ID=POH.VENDOR_ID)VENDOR_NAME,POH.VENDOR_ID,(select address_line1 from PO_VENDOR_SITES_ALL where  vendor_ID=poh.vendor_id and vendor_site_id=POH.VENDOR_SITE_ID)vendor_address"

            sql &= "  FROM PO_HEADERS_ALL POH ,PO_LINES_ALL POL ,PO_LINE_LOCATIONS_ALL POLL WHERE POH.PO_HEADER_ID=POL.PO_HEADER_ID AND POL.PO_LINE_ID=POLL.PO_LINE_ID  and POH.SEGMENT1='" & Trim(txt_po_no.Text) & "'"

            adap = New OracleDataAdapter(sql, con)
            ds = New DataSet
            adap.Fill(ds, "data")
            vendor_address = ds.Tables("data").Rows(0).Item("vendor_address")

            sql = "select POH.SEGMENT1 PO_NO,POH.CREATION_DATE PO_DATE,JAN_ORGCODE(SHIP_TO_ORGANIZATION_ID)ORG "

            sql &= " ,JAN_ITEMNAME(POL.ITEM_ID)ITEM_NO,POL.QUANTITY,ROUND(NVL((POL.UNIT_PRICE),0),2)*NVL(POH.RATE,1) PO_RATE,poll.need_by_date ,POH.VENDOR_SITE_ID,(select VENDOR_NAME from PO_VENDORS where VENDOR_ID=POH.VENDOR_ID)VENDOR_NAME,POH.VENDOR_ID,(select address_line1 from PO_VENDOR_SITES_ALL where  vendor_ID=poh.vendor_id and vendor_site_id=POH.VENDOR_SITE_ID)vendor_address"

            sql &= " ,(SELECT MAX(ORGANIZATION_ID) FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=POL.ITEM_ID "

            'If vendor_address.Contains("BODIPALAYAM") Then ''Disabled  on 14-sep-2018 based on shanthi confirmation

            sql &= " AND ORGANIZATION_ID IN (444,464,484,504,505,524) "
            'Else
            '    sql &= " AND ORGANIZATION_ID IN (106,107,108,109,110,111,304) "
            'End If


            sql &= " AND DECODE(INVENTORY_ITEM_STATUS_CODE,'Active','1',0)+DECODE(CUSTOMER_ORDER_FLAG,'Y',1,0)+DECODE(CUSTOMER_ORDER_ENABLED_FLAG,'Y',1,0)+DECODE(SHIPPABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICEABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICE_ENABLED_FLAG,'Y',1,0)+DECODE(RESERVABLE_TYPE,1,1,0)=7) order_ORG "

            sql &= " ,nvl((select decode(DECODE(INVENTORY_ITEM_STATUS_CODE,'Active','1',0)+DECODE(CUSTOMER_ORDER_FLAG,'Y',1,0)+DECODE(CUSTOMER_ORDER_ENABLED_FLAG,'Y',1,0)+DECODE(SHIPPABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICEABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICE_ENABLED_FLAG,'Y',1,0)+DECODE(RESERVABLE_TYPE,1,1,0),7,'Yes','No')  from mtl_system_items where organization_id=105  and INVENTORY_ITEM_ID=POL.ITEM_ID),0)order_enabled_in_item_mast"
            sql &= "  FROM PO_HEADERS_ALL POH ,PO_LINES_ALL POL ,PO_LINE_LOCATIONS_ALL POLL WHERE POH.PO_HEADER_ID=POL.PO_HEADER_ID AND POL.PO_LINE_ID=POLL.PO_LINE_ID  and POH.SEGMENT1='" & Trim(txt_po_no.Text) & "' and POL.QUANTITY>0"

            adap = New OracleDataAdapter(sql, con)
            ds = New DataSet
            adap.Fill(ds, "data")



            dgv1.DataSource = ds.Tables("data")
            For i = 0 To dgv1.RowCount - 1
                With dgv1.Rows(i)
                    If IsDBNull(.Cells("order_ORG").Value) Or .Cells("order_enabled_in_item_mast").Value = "No" Then
                        '.Cells("order_ORG").Style.BackColor = Color.Red
                        '.Cells("order_enabled_in_item_mast").Style.BackColor = Color.Red
                        .DefaultCellStyle.BackColor = Color.Red
                        Label2.Visible = True
                    End If



                End With
            Next
        Else
            MessageBox.Show("Enter PO Number & View Details ...")

        End If

    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        For i = 0 To dgv1.RowCount - 1
            With dgv1.Rows(i)
                If .Cells("order_ORG") Is DBNull.Value Then
                    MessageBox.Show("Enable order Enable Flag for the item " & .Cells("item_no").Value & " then create the order", "Stock Transfer OA", MessageBoxButtons.OK)
                    Exit Sub
                End If

            End With
        Next


        For i = 0 To dgv1.RowCount - 1
            With dgv1.Rows(i)

                If i = 0 Then
                    sql = "insert into jan_so_header_stg "
                    sql &= " (LEGACY_SO_NUM,CUSTOMER_NAME ,CUSTOMER_NO,CUSTOMER_ID,BILL_TO ,SHIP_TO ,TRANSACTION_TYPE ,CUSTOMER_PO_NO,CUSTOMER_PO_DT,ORDER_DATE ,PRICE_LIST ,PAYMENT_TERMS ,PACKING_INSTRUCTION,VERIFY_FLAG,OE_DMS_ORDER_HEADER_ID,CUSTOMER_PO_REF,OE_DSP_ID,CUST_PO_DT,CUST_PO_DT_CHAR,SHIP_TO_CUSTOMER_ID,SHIP_TO_SITE_ID) values(jan_so_seq.nextval"

                    If .Cells("org").Value = "I15" Then
                        unit_5_6_oa = "Y"

                        sql &= ",'JANATICS INDIA PVT. LTD - UNIT V',(select customer_number from ra_customers where customer_name='JANATICS INDIA PVT. LTD - UNIT V'),(select customer_id from ra_customers where customer_name='JANATICS INDIA PVT. LTD - UNIT V'),"
                        sql &= "'AHMEDABAD','AHMEDABAD'"

                    ElseIf .Cells("org").Value = "I16" Then
                        unit_5_6_oa = "Y"

                        sql &= ",'JANATICS INDIA PVT. LTD - UNIT VI',(select customer_number from ra_customers where customer_name='JANATICS INDIA PVT. LTD - UNIT VI'),(select customer_id from ra_customers where customer_name='JANATICS INDIA PVT. LTD - UNIT VI'),"
                        sql &= "'NOIDA','NOIDA'"

                    ElseIf .Cells("org").Value = "I21" Or .Cells("org").Value = "I22" Or .Cells("org").Value = "I23" Or .Cells("org").Value = "I24" Or .Cells("org").Value = "I25" Or .Cells("org").Value = "I26" Or .Cells("org").Value = "I02" Or .Cells("org").Value = "I03" Or .Cells("org").Value = "I04" Or .Cells("org").Value = "I05" Or .Cells("org").Value = "I06" Or .Cells("org").Value = "I07" Or .Cells("org").Value = "I14" Then

                        sql &= ",'JANATICS INDIA PRIVATE LIMITED',(select customer_number from ra_customers where customer_name='JANATICS INDIA PRIVATE LIMITED'),(select customer_id from ra_customers where customer_name='JANATICS INDIA PRIVATE LIMITED'),"

                        sql &= "'BODIPALAYAM','BODIPALAYAM'"

                        'ElseIf .Cells("org").Value = "I02" Or .Cells("org").Value = "I03" Or .Cells("org").Value = "I04" Or .Cells("org").Value = "I05" Or .Cells("org").Value = "I06" Or .Cells("org").Value = "I07" Or .Cells("org").Value = "I14" Then

                        '    sql &= ",'JANATICS INDIA PRIVATE LIMITED',(select customer_number from ra_customers where customer_name='JANATICS INDIA PRIVATE LIMITED'),(select customer_id from ra_customers where customer_name='JANATICS INDIA PRIVATE LIMITED'),"

                        '    sql &= "'UNIT-1','UNIT-1'"

                    ElseIf .Cells("org").Value = "I01" Then
                        sql &= "'UNIT II - NEW','UNIT II - NEW'"

                    End If

                    'If .Cells("vendor_address").Value.ToString.Contains("BODIPALAYAM") Then
                    sql &= ",'Stock Transfer - VII'"

                    'Else
                    '    sql &= ",'Stock Transfer - Unit I'"
                    'End If


                    ',bill_to ,ship_to ,transaction_type
                    sql &= ",'" & .Cells("PO_NO").Value & "','" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "' ,sysdate,'JANA_STOCK_TRANSFER','120 Days',NULL,'N',JAN_TEST_SEQ.NEXTVAL,'" & .Cells("PO_NO").Value & "',0,'" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "',to_char(to_date('" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "'),'DD-MON-YYYY'),NULL,NULL"
                    sql &= " )"

                    comand()
                End If

                sql = " INSERT INTO JAN_SO_LINES_STG(LEGACY_SO_NUM ,LINE_NUM ,ITEM_CODE ,UOM,LINE_TYPE ,QTY ,PRICE_UNIT ,REQUEST_DATE ,SCHEDULED_SHIP_DATE ,VERIFY_FLAG,ORGANIZATION_ID,OE_DMS_ORDER_HEADER_ID,cust_po_ref)  VALUES(JAN_SO_SEQ.CURRVAL," & i + 1 & ",'" & .Cells("ITEM_NO").Value & "',(SELECT PRIMARY_UOM_CODE FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=JAN_ITEMNO('" & .Cells("ITEM_NO").Value & "') AND ORGANIZATION_ID=" & .Cells("order_ORG").Value & "),'Standard Ship Line'," & .Cells("QUANTITY").Value & "," & .Cells("PO_RATE").Value & ",'" & Format(.Cells("need_by_date").Value, "dd-MMM-yyyy") & "','" & Format(.Cells("need_by_date").Value, "dd-MMM-yyyy") & "','N'"

                'If unit_5_6_oa = "Y" Then
                '    sql &= ",444 "

                'Else
                sql &= " ," & .Cells("order_ORG").Value & ""
                'End If


                sql &= " ,jan_test_seq.CURRval,'" & .Cells("PO_NO").Value & "')"
                comand()

            End With
        Next
        MessageBox.Show("Order Lines moved to Staging", "Stock Transfer OA ", MessageBoxButtons.OK)
    End Sub
    Private Sub comand()
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_interface.Click
        Dim order_id As Integer

        sql = "SELECT OE_DMS_ORDER_HEADER_ID FROM JAN_SO_HEADER_STG WHERE CUSTOMER_PO_NO='" & txt_po_no.Text & "' order by OE_DMS_ORDER_HEADER_ID desc"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        order_id = ds.Tables("data").Rows(0).Item("OE_DMS_ORDER_HEADER_ID")

        sql = "declare begin  JAN_SO_API_STOCK_TRANSFER(" & ds.Tables("data").Rows(0).Item("OE_DMS_ORDER_HEADER_ID") & "); end;"
        comand()

        sql = "SELECT decode(verify_flag,'Y','Lines Moved to Interface','Lines not Moved to Interface')status FROM JAN_SO_HEADER_STG WHERE OE_DMS_ORDER_HEADER_ID=" & order_id & ""
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        MessageBox.Show("Order Lines Status :" & ds.Tables("data").Rows(0).Item("status") & "", "Stock Transfer OA ", MessageBoxButtons.OK)

    End Sub
    Private Sub btn_view_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_order.Click

        sql = "select distinct (select ORDER_NUMBER from OE_ORDER_HEADERS_ALL where HEADER_ID=a.HEADER_ID ) ORDER_NUMBER from OE_ORDER_LINES_ALL a where header_id in (select header_id from OE_ORDER_HEADERS_ALL where TRUNC(ORDERED_DATE)=TRUNC(sysdate) ) and attribute6='" & txt_po_no.Text & "'"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        If ds.Tables("data").Rows.Count > 0 Then
            MessageBox.Show("Order Created for this PO :" & ds.Tables("data").Rows(0).Item("ORDER_NUMBER") & "", "Stock Transfer OA ", MessageBoxButtons.OK)

        Else
            MessageBox.Show("Order Not Created for this PO ", "Stock Transfer OA ", MessageBoxButtons.OK)

        End If


    End Sub
End Class