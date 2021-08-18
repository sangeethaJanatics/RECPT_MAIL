Public Class New_customer_addition_bill_To_Ship_TO
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Private Sub btn_search_customer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search_customer.Click
        sql = "select customer_nAme,customer_id from ra_customers where upper(customer_name) like upper('" & TXT_CUST_NAME.Text & "%')  order by customer_nAme"
        ds = SQL_SELECT("CUST", sql)

        'lst_cust.DisplayMember = "customer_nAme"
        'lst_cust.ValueMember = "customer_id"
        'lst_cust.DataSource = ds.Tables("CUST")
        lst_cust.Items.Clear()
        For i = 0 To ds.Tables("CUST").Rows.Count - 1
            lst_cust.Items.Add(ds.Tables("CUST").Rows(i).Item("customer_nAme"))
        Next
        lst_cust.Visible = True
    End Sub

    Private Sub lst_cust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_cust.SelectedIndexChanged
        TXT_CUST_NAME.Text = lst_cust.SelectedItem.ToString
        lst_cust.Visible = False
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If TXT_CUST_NAME.Text = "" Then

            MessageBox.Show("Enter Customer Name then update  ....!", "", MessageBoxButtons.OK)
        Else
            sql = "DELETE FROM JAN_SHIP_TO_SITES_ALL_TAB WHERE CUSTOMER_ID=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
            comand()

            sql = "INSERT  INTO JAN_SHIP_TO_SITES_ALL_TAB select * from JAN_SHIP_TO_SITES_ALL where customer_id=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
            comand()

            MessageBox.Show("Bill To Ship To  updated  ....!", "New Order Entry", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub btn_create_sch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create_sch.Click
        If txt_create_schedule.Text <> "" Then
            sql = " DECLARE BEGIN JAN_CREATE_REG_ORDER_SCHEDULES(" & txt_create_schedule.Text & "); END;"
            comand()

            MessageBox.Show("Schedule Create  ..!")
            txt_create_schedule.Text = ""
        End If
    End Sub

    Private Sub btn_cancel_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel_order.Click

        If txt_create_schedule.Text <> "" Then
            'sql = " DECLARE BEGIN JAN_CREATE_REG_ORDER_SCHEDULES(" & txt_create_schedule.Text & "); END;"

            sql = "UPDATE JAN_IT.JAN_DMS_ORDER_HEADERS_ALL A SET DOWNLOAD_FLG=2 WHERE OE_ORDER_ONLINE_ID=" & txt_create_schedule.Text & ""
            comand()

            MessageBox.Show("Order Cancelled  ..!")
            txt_create_schedule.Text = ""
        End If
    End Sub
    Private Sub btn_view_item_status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_item_status.Click

        If txt_item.Text <> "" Then
            sql = "Select JAN_ORGCODE(ORGANIZATION_ID)ORG,Decode(Inventory_Item_Status_Code,'Active','1',0)+Decode(Customer_Order_Flag,'Y',1,0)+Decode(Customer_Order_Enabled_Flag,'Y',1,0)+Decode(Shippable_Item_Flag,'Y',1,0)+Decode(Invoiceable_Item_Flag,'Y',1,0)+Decode(Invoice_Enabled_Flag,'Y',1,0)+Decode(Reservable_Type,1,1,0)""order enabled count"" ,INVENTORY_ITEM_STATUS_CODE ""Inventory Item Status Code"",CUSTOMER_ORDER_FLAG ""Customer Order Flag"",CUSTOMER_ORDER_ENABLED_FLAG ""Customer Order Enabled Flag"",SHIPPABLE_ITEM_FLAG ""Shippable Item Flag"" ,INVOICEABLE_ITEM_FLAG ""Invoiceable Item Flag"",INVOICE_ENABLED_FLAG ""Invoice Enabled Flag"",RESERVABLE_TYPE ""Reservable Type""  "

            sql &= " ,(select hsn_code from JAN_ITEM_HSN_MASTER_V  WHERE INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and ORGANIZATION_ID=a.ORGANIZATION_ID )hsn_code"
            sql &= " from MTL_SYSTEM_ITEMS A where segment1 ='" & txt_item.Text & "' order by org"
            ds = SQL_SELECT("CUST", sql)
            dgv1.DataSource = ds.Tables("CUST")
        Else
            MessageBox.Show("Enter a Item to View it's Order Enabled Status  ", "Customer Order Enabled Status", MessageBoxButtons.OK)


        End If
    End Sub
    Private Sub btn_update_org_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update_org.Click

        If txt_order_id_org_update.Text <> "" Then
            If txt_item_org_update.Text <> "" Then
                If txt_org_id.Text <> "" Then

                    sql = "UPDATE JAN_DSP_DELIVERY_SCHEDULES_REG  SET ORG_ID=JAN_ORGID('" & txt_org_id.Text & "'),VALIDATION_MSG='Validated',VALIDATION_NO=0 where OE_DMS_ORDER_HEADER_ID=" & txt_order_id_org_update.Text & " AND INVENTORY_ITEM_ID=JAN_ITEMNO('" & txt_item_org_update.Text & "')"
                    comand()
                    MessageBox.Show("Organization Id updated ..!", "New Order Entry", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Enter Organization Id then update ..!", "New Order Entry", MessageBoxButtons.OK)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Enter Item No then update ..!", "New Order Entry", MessageBoxButtons.OK)
                Exit Sub
            End If

        Else
            MessageBox.Show("Enter Order Id then update ..!", "New Order Entry", MessageBoxButtons.OK)
            Exit Sub
        End If
    End Sub

    Private Sub btn_update_dsp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update_dsp.Click
        If txt_dsp_order_id.Text <> "" Then
            If txt_dsp_item_no.Text <> "" Then
                If txt_dsp_org.Text <> "" Then

                    sql = "UPDATE JAN_so_lines_stg  SET ORGanization_ID=JAN_ORGID('" & txt_dsp_org.Text & "'),error_message=null where OE_DMS_ORDER_HEADER_ID=" & txt_dsp_order_id.Text & " AND item_code='" & txt_dsp_item_no.Text & "'"
                    comand()
                    MessageBox.Show("Organization Id updated ..!", "DSP Order Staging", MessageBoxButtons.OK)
                    sql = "declare begin jan_so_api(" & txt_dsp_order_id.Text & "); end;"
                    comand()
                Else
                    MessageBox.Show("Enter Organization Id then update ..!", "DSP Order Entry", MessageBoxButtons.OK)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Enter Item No then update ..!", "DSP Order Entry", MessageBoxButtons.OK)
                Exit Sub
            End If

        Else
            MessageBox.Show("Enter Order Id then update ..!", "DSP Order Entry", MessageBoxButtons.OK)
            Exit Sub
        End If
    End Sub
    Private Sub btn_cancel_dsp_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel_dsp_order.Click
        If txt_create_schedule.Text <> "" Then
            'sql = " DECLARE BEGIN JAN_CREATE_REG_ORDER_SCHEDULES(" & txt_create_schedule.Text & "); END;"

            sql = "UPDATE JAN_IT.oe_DMS_ORDER_HEADERS_ALL A SET DOWNLOAD_FLG=2 WHERE OE_ORDER_ONLINE_ID=" & txt_create_schedule.Text & ""
            comand()

            MessageBox.Show("Order Cancelled  ..!")
            txt_create_schedule.Text = ""
        End If
    End Sub
    Private Sub btn_clear_staging_table_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear_staging_table.Click


        sql = "delete from jan_so_header_stg  WHERE oe_dms_order_header_id=" & txt_create_schedule.Text & ""
        comand()

        sql = "delete from jan_so_lines_stg  WHERE oe_dms_order_header_id=" & txt_create_schedule.Text & ""
        comand()

        MessageBox.Show("Staging Table cleared ..!")
        txt_create_schedule.Text = ""
    End Sub

    Private Sub btn_view_error_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_error.Click

        If txt_web_order_ref.Text <> "" Then

            sql = "select (select JAN_ITEMNAME(OEL.INVENTORY_ITEM_ID)ITEM from APPS.OE_PROCESSING_MSGS OE_MSGS ,OE_LINES_IFACE_ALL OEL WHERE 
OE_MSGS.ORIGINAL_SYS_DOCUMENT_LINE_REF=OEL.ORIG_SYS_LINE_REF AND OE_MSGS.TRANSACTION_ID=TL.TRANSACTION_ID)ITEM_NO,creation_date,message_text from apps.oe_processing_msgs_tl TL where transaction_id in (select TRANSACTION_ID from APPS.OE_PROCESSING_MSGS  where REQUEST_ID in (SELECT REQUEST_ID FROM OE_HEADERS_IFACE_ALL A WHERE REQUEST_ID IN (select request_id from OE_headerS_IFACE_ALL where ORIG_SYS_DOCUMENT_REF in (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "')) and error_flag='Y'))) and message_text not like 'The flexfield on this field contains a flexfield bind %'"

            ds = SQL_SELECT("CUST", sql)
            dgv1.DataSource = ds.Tables("CUST")

        Else
            MessageBox.Show("Enter Web order Reference and view Error", "Order Interface", MessageBoxButtons.OK)

        End If
    End Sub
    Private Sub btn_view_error_items_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_error_items.Click


        If txt_web_order_ref.Text <> "" Then

            sql = "select creation_date,message_text from apps.oe_processing_msgs_tl where transaction_id in (select TRANSACTION_ID from APPS.OE_PROCESSING_MSGS  where REQUEST_ID in (SELECT REQUEST_ID FROM OE_HEADERS_IFACE_ALL A WHERE REQUEST_ID IN (select request_id from OE_headerS_IFACE_ALL where ORIG_SYS_DOCUMENT_REF in (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL a where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "')) and error_flag='Y'))) and message_text not like 'The flexfield on this field contains a flexfield bind %'"

            sql = "select * from (SELECT orig_sys_line_ref line_id ,DECODE(INVENTORY_ITEM_STATUS_CODE,'Active','1',0)+DECODE(CUSTOMER_ORDER_FLAG,'Y',1,0)+DECODE(CUSTOMER_ORDER_ENABLED_FLAG,'Y',1,0)+DECODE(SHIPPABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICEABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICE_ENABLED_FLAG,'Y',1,0)+DECODE(RESERVABLE_TYPE,1,1,0)enabled_flag_cnt,org,item_no ,INVENTORY_ITEM_STATUS_CODE,CUSTOMER_ORDER_FLAG,CUSTOMER_ORDER_ENABLED_FLAG,SHIPPABLE_ITEM_FLAG,INVOICEABLE_ITEM_FLAG,INVOICE_ENABLED_FLAG,RESERVABLE_TYPE FROM (SELECT jan_orgcode(ship_from_org_id)org,(SELECT segment1 FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)item_no,(SELECT INVENTORY_ITEM_STATUS_CODE FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)INVENTORY_ITEM_STATUS_CODE,(SELECT CUSTOMER_ORDER_FLAG FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)CUSTOMER_ORDER_FLAG ,(SELECT CUSTOMER_ORDER_ENABLED_FLAG FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)CUSTOMER_ORDER_ENABLED_FLAG,(SELECT SHIPPABLE_ITEM_FLAG FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)SHIPPABLE_ITEM_FLAG,(SELECT INVOICEABLE_ITEM_FLAG FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND ORGANIZATION_ID=105)INVOICEABLE_ITEM_FLAG,(SELECT INVOICE_ENABLED_FLAG FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and ORGANIZATION_ID=105)INVOICE_ENABLED_FLAG ,(SELECT RESERVABLE_TYPE FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and ORGANIZATION_ID=105)RESERVABLE_TYPE ,a.* from  OE_LINES_IFACE_ALL A where ORIG_SYS_DOCUMENT_REF=(select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "'))) S) order by  enabled_flag_cnt desc "

            ds = SQL_SELECT("CUST", sql)
            dgv1.DataSource = ds.Tables("CUST")

            For i = 0 To dgv1.Rows.Count - 1

                With dgv1
                    If .Rows(i).Cells(1).Value <> 7 Then .Rows(i).DefaultCellStyle.BackColor = Color.Red
                End With
            Next


        Else
            MessageBox.Show("Enter Web order Reference and view Error", "Order Interface", MessageBoxButtons.OK)

        End If

    End Sub

    Private Sub btn_run_concurrent_des_corrected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_run_concurrent_des_corrected.Click

        sql = " UPDATE OE_headerS_IFACE_ALL SET REQUEST_ID=NULL,ERROR_FLAG=NULL WHERE ORIG_SYS_DOCUMENT_REF IN (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "'))"
        comand()
        sql = "update OE_LINES_IFACE_ALL set REQUEST_ID=null,ERROR_FLAG=null where ORIG_SYS_DOCUMENT_REF in (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "'))"
        comand()

        MessageBox.Show("Concurrent Running", "Order Interface correction", MessageBoxButtons.OK)


    End Sub

    Private Sub btn_run_concurrent_remove_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        sql = " UPDATE OE_headerS_IFACE_ALL SET REQUEST_ID=NULL,ERROR_FLAG=NULL WHERE ORIG_SYS_DOCUMENT_REF IN (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "'))"
        comand()
        sql = "update OE_LINES_IFACE_ALL set REQUEST_ID=null,ERROR_FLAG=null where ORIG_SYS_DOCUMENT_REF in (select distinct ORIG_SYS_DOCUMENT_REF from OE_LINES_IFACE_ALL  where ATTRIBUTE8  in ('" & txt_web_order_ref.Text & "'))"
        comand()

        MessageBox.Show("Concurrent Running", "Order Interface correction", MessageBoxButtons.OK)
    End Sub

    Private Sub btn_delete_line_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_line.Click
        sql = "DELETE FROM OE_LINES_IFACE_ALL  WHERE ORIG_SYS_LINE_REF IN ( " & Trim(txt_orig_sys_line_ref.Text) & ")"
        comand()

        MessageBox.Show("Line ID Deleted", "Order Interface Correction", MessageBoxButtons.OK)
    End Sub
    Private Sub txt_BOM_check_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_BOM_check.TextChanged, txt_forward_line_id.TextChanged
        sql = " select organization_id ,jan_orgcode(organization_id)org from mtl_system_items where segment1='" & txt_BOM_check.Text & "' order by organization_id"
        ds = SQL_SELECT("org", sql)
        cmb_bom_org.DataSource = ds.Tables("org")
        cmb_bom_org.DisplayMember = "org"
        cmb_bom_org.ValueMember = "organization_id"

    End Sub
    Private Sub btn_view_BOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_BOM.Click
        sql = "SELECT * FROM bom_bill_of_materials_v  WHERE assembly_item_id =jan_itemno('" & txt_BOM_check.Text & "')  AND organization_id =" & cmb_bom_org.SelectedValue & ""
        ds = SQL_SELECT("bom", sql)

        If ds.Tables("bom").Rows.Count > 0 Then
            lbl_BOM_text.Text = "BOM Available for this Item"
        Else
            lbl_BOM_text.Text = "BOM Not Available for this Item"
        End If
    End Sub
    Private Sub New_customer_addition_bill_To_Ship_TO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select * from jan_form2_master  where trunc(creation_date)>add_months(trunc(sysdate),-5) order by customer_name "
        ds = SQL_SELECT("cust", sql)
        cmb_customer_name.DataSource = ds.Tables("cust")
        cmb_customer_name.DisplayMember = "customer_Name"
        cmb_customer_name.ValueMember = "customer_no"


        sql = "select * from jan_sales_any_tb6_all  where trunc(updation_date)=trunc(sysdate) order by region "
        sql = "SELECT DISTINCT SEGMENT14  REGION FROM RA_TERRITORIES WHERE SEGMENT14 NOT IN ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O','DELHI 2','DELHI 3') order by region"
        ds = SQL_SELECT("cust", sql)
        cmb_form2_region.DataSource = ds.Tables("cust")
        cmb_form2_region.DisplayMember = "region"
        cmb_form2_region.ValueMember = "region"

    End Sub
    Private Sub btn_update_form2_region_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update_form2_region.Click
        sql = "UPDATE jan_it.JAN_FORM2_MASTER SET REGION='" & cmb_form2_region.Text & "'"
        If txt_vendor_code.Text <> "" Then sql &= " ,vendor_code='" & txt_vendor_code.Text.Replace("'", "''") & "'"
        sql &= " where  CUSTOMER_NO=" & cmb_customer_name.SelectedValue & ""
        comand()
        MessageBox.Show("Form2 Region changed", "New order Entry changes", MessageBoxButtons.OK)

    End Sub
    Private Sub btn_view_hSN_Click(sender As Object, e As EventArgs) Handles btn_view_hSN.Click
        sql = "select trx_number ""Inv No"",trx_date ""Inv.Dt"",(select hsn_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id And  inventory_item_id=a.inventory_item_id)hsn_code,jan_orgcode(organization_id)org,ordered_item,description from jan_invoice_listing a  where trx_number='" & txt_inv_no.Text & "' order by org,ordered_item"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub
    Private Sub btn_delete_item_Click(sender As Object, e As EventArgs) Handles btn_delete_item.Click

        If txt_dsP_manual_order_id.Text <> "" Then
            If txt_item.Text <> "" Then
                sql = "delete from  jan_dsp_delivery_schedules where oe_dms_order_header_id=" & txt_dsP_manual_order_id.Text & " and inventory_item_id=jan_itemno('" & txt_item.Text & "')"
                comand()

                sql = "delete from  oe_dms_order_lines_all where oe_dms_order_header_id=" & txt_dsP_manual_order_id.Text & " and oe_item_no='" & txt_item.Text & "'"
                comand()

                MessageBox.Show("Item No  deleted", "New order Entry changes", MessageBoxButtons.OK)
            Else

                MessageBox.Show("Enter  Item No and delete the item", "New order Entry changes", MessageBoxButtons.OK)

            End If
        Else
            MessageBox.Show("Enter Order ID and delete the item", "New order Entry changes", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btn_update_proj_key_customer_Click(sender As Object, e As EventArgs) Handles btn_update_proj_key_customer.Click

        If TXT_CUST_NAME.Text = "" Then
            MessageBox.Show("Enter Customer Name then update  ....!", "", MessageBoxButtons.OK)
        Else
            'TXT_VENDOR_CODE_NON_FORM2
            'sql = " select * from jan_project_key_customer where customer_id=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
            sql = " select * from jan_pick_forward_control_2 where customer_id=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
            ds = SQL_SELECT("data", sql)
            If ds.Tables("data").Rows.Count = 0 Then


                'sql = " insert into jan_pick_forward_control_2 (customer_id ,customer_type ,creation_date)   (select (SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')customer_id, "
                'If rad_project_customer.Checked = True Then
                '    sql &= " 1"
                'ElseIf rad_key_customer.Checked = True Then
                '    sql &= " 2"
                'Else
                '    sql &= " 0"
                'End If
                'sql &= ", sysdate"
                'sql &= " from dual)"
                sql = " insert into jan_pick_forward_control_2 (customer_id ,PROJECT_CUSTOMER,KEY_CUSTOMER,creation_date,LAST_UPDATE_DATE,VENDOR_CODE)   values( (SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "') "
                If rad_project_customer.Checked = True Then sql &= " ,1 " Else sql &= " ,0 "
                If rad_key_customer.Checked = True Then sql &= " ,1 " Else sql &= " ,0 "
                sql &= " ,sysdate,sysdate,'" & Trim(TXT_VENDOR_CODE_NON_FORM2.Text.ToString) & "')"
            Else
                sql = "update jan_pick_forward_control_2 set LAST_UPDATE_DATE=sysdate "
                If rad_project_customer.Checked = True Then sql &= " ,PROJECT_CUSTOMER=1  "
                If rad_key_customer.Checked = True Then sql &= " ,KEY_CUSTOMER=1 "
                If txt_vendor_code.Text <> "" Then sql &= " ,VENDOR_CODE='" & TXT_CUST_NAME.Text.Replace("'", "") & "'"
                sql &= " where customer_id=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
            End If
            comand()
            MessageBox.Show("Customer Type updated ", "New order Entry changes", MessageBoxButtons.OK)
            txt_vendor_code.Text = ""
        End If

    End Sub
    Private Sub btn_update_scheme_order_qty_Click(sender As Object, e As EventArgs) Handles btn_update_scheme_order_qty.Click
        Dim cus_id As Integer = 0
        If TXT_CUST_NAME.Text <> "" Then
            sql = "select customer_id from ra_customers where customer_name ='" & TXT_CUST_NAME.Text & "' "
            ds = SQL_SELECT("data", sql)

            If ds.Tables("data").Rows.Count > 0 Then

                cus_id = ds.Tables("data").Rows(0).Item("customer_id")

                sql = " SELECT * FROM (SELECT (SELECT DRAFT_QTY FROM JAN_DSP_LINES WHERE DSP_ID=A.OE_DSP_ID AND BILL_TO_CUST_ID=A.OE_CUSTOMER_ID AND ORG_ID=A.OE_ORG_ID AND ITEM_ID=A.oe_inventory_item_id)DRAFT_QTY ,A.* FROM OE_DMS_ORDER_LINES_ALL A  WHERE OE_DSP_ID=20200603 AND oe_customer_id=" & cus_id & ") B WHERE DRAFT_QTY<>SITE_1_QTY "


                adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
                ds1 = New DataSet
                adap_sql.Fill(ds1, "RES")
                For i = 0 To ds1.Tables("RES").Rows.Count - 1
                    With ds1.Tables("RES").Rows(i)
                        sql = "update  OE_DMS_ORDER_LINES_ALL set site_1_qty=" & .Item("draft_qty") & "  WHERE OE_DSP_ID=20200603 AND oe_customer_id=" & cus_id & " and  oe_dsp_line_id=" & .Item("oe_dsp_line_id") & ""
                    End With

                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    z = cmd_sql.ExecuteNonQuery()
                Next

                sql = "update jan_dsp_lines set site_1_qty=draft_qty where dsp_id=20200603 and bill_to_cust_id=" & cus_id & " and draft_qty<>site_1_qty"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                z = cmd_sql.ExecuteNonQuery()
                If z > 0 Then
                    MessageBox.Show("Scheme  Quantity Updated ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("There is no mismatch in Scheme  Quantity ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)
                End If
            End If
        Else
            MessageBox.Show("Enter  Dealer Name to Edit the Quantity ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = " DECLARE BEGIN exec apps.jan_release_sales_order_api('" & txt_forward_line_id.Text & ",0'); END "
        comand()

        MessageBox.Show("Error cleared,check after 2 Mins ...!", "Forward Error Clearing ", MessageBoxButtons.OK)

    End Sub

    Private Sub btn_sch_Click(sender As Object, e As EventArgs) Handles btn_sch.Click
        If rad_6_sch.Checked = True Then
            sql = " DECLARE BEGIN exec Jan_dms_Web_Order_Scheduls2sh6(" & txt_sch_order_id.Text & "); END ;"
        ElseIf rad_8sch.Checked = True Then
            sql = " DECLARE BEGIN exec JAN_DMS_WEB_ORDER_SCHEDULES2SH(" & txt_sch_order_id.Text & "); END; "
        End If
        comand()
        MessageBox.Show("Schedule Created ", "Sep 2020 schedule change..", MessageBoxButtons.OK)

        '        --exec JAN_DMS_WEB_ORDER_SCHEDULES2SH(225683);
        '/
        '--exec Jan_dms_Web_Order_Scheduls2sh6(225630);
    End Sub

    Private Sub btn_remove_single_lot_Click(sender As Object, e As EventArgs) Handles btn_remove_single_lot.Click
        sql = "update OE_DMS_ORDER_LINES_ALL set oe_lot_type=0,oe_week_no=0 where OE_DMS_ORDER_HEADER_ID=" & txt_sch_order_id.Text & ""
        comand()
        MessageBox.Show("Single Lot change ", "Single Lot changed", MessageBoxButtons.OK)

    End Sub

    Private Sub btn_view_proj_key_Click(sender As Object, e As EventArgs) Handles btn_view_proj_key.Click
        sql = "select (select customer_name from ra_customers where customer_id=a.customer_id)customer_name,decode(project_customer,1,'Yes','No')Project_customer,decode(key_customer,1,'Yes','No')key_customer,vendor_code from jan_pick_forward_control_2 a
 where 1=1 "
        If TXT_CUST_NAME.Text <> "" Then sql &= " and customer_id=(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_naME='" & TXT_CUST_NAME.Text.Replace("'", "") & "')"
        sql &= " order by customer_name"

        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

    Private Sub btn_tcs_tax_cust_Click(sender As Object, e As EventArgs) Handles btn_tcs_tax_cust.Click
        sql = " select customer_name,region,creation_date,end_date from jan_tcs_tax_customer_master a   where 1=1 "
        If TXT_CUST_NAME.Text <> "" Then sql &= " and customer_name='" & TXT_CUST_NAME.Text.Replace("'", "") & "' "
        sql &= " order by customer_name"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

    Private Sub btn_End_tcs_tax_Click(sender As Object, e As EventArgs) Handles btn_End_tcs_tax.Click
        If TXT_CUST_NAME.Text <> "" Then
            sql = "update jan_tcs_tax_customer_master set end_date=sysdate where customer_name='" & Trim(TXT_CUST_NAME.Text.Replace("'", "")) & "'"
            comand()
            MessageBox.Show("TCS Tax Ended", "TCS Tax customer Editing", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Select customer Name and update", "TCS Tax customer Editing", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub btn_add_to_TCS_cust_list_Click(sender As Object, e As EventArgs) Handles btn_add_to_TCS_cust_list.Click
        If TXT_CUST_NAME.Text <> "" Then
            sql = "select * from jan_tcs_tax_customer_master  where customer_name='" & Trim(TXT_CUST_NAME.Text) & "'"
            ds = SQL_SELECT("data", sql)
            If ds.Tables("data").Rows.Count = 0 Then
                sql = "insert into jan_tcs_tax_customer_master(customer_name,region,cust_category,customer_class,customer_id,creation_date,updated_by)
select customer_name,(select distinct ter_name from jan_bms_bill_to_v where customer_id=a.customer_id)region
,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.customer_id)customer_category,customer_class_code,customer_id,sysdate
,sys_context('userenv','IP_ADDRESS')
from ra_customers a where customer_name='" & TXT_CUST_NAME.Text.Replace("'", "''") & "'"

                comand()
                MessageBox.Show("Customer Marked as TCS Tax customer ...!", "TCS Tax customer Addition", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Customer already Marked as TCS customer ...!", "TCS Tax customer Addition", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("Select customer Name and Add ..!", "TCS Tax customer Addition", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub btn_oa_no_Click(sender As Object, e As EventArgs) Handles btn_oa_no.Click
        sql = "select * from jan_tcs_tax_customer_master  where customer_name='" & Trim(TXT_CUST_NAME.Text) & "'"

        sql = "select order_number,ordered_date,jan_orgcode(ship_from_org_id)org,ordered_item,(select hsn_code from JAN_ITEM_HSN_MASTER_V 
where organization_id=a.ship_from_org_id and inventory_item_id=a.inventory_item_id)hsn
 from jan_bms_order_pending_new_v  a where header_id=(select header_id from oe_order_headers_all where order_number='" & Trim(txt_oa_no.Text) & "')
 order by ordered_item"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub

    Private Sub btn_view_pending_order_Click(sender As Object, e As EventArgs) Handles btn_view_pending_order.Click

        If TXT_CUST_NAME.Text <> "" Then

            sql = "select customer_id from ra_customers  where customer_name='" & TXT_CUST_NAME.Text.Replace("'", "''") & "'"
            ds1 = SQL_SELECT("cust", sql)

            sql = " select b.* 
,rowtocol('select distinct TAX_CATEGORY_NAME from JAI_TAX_CATEGORIES
where tax_category_id in ( select nvl(default_TAX_CATEGORY_ID,OVERRIDE_TAX_CATEGORY_ID) from apps.jai_tax_det_factors 
where org_id=103 and ENTITY_CODE = ''OE_ORDER_HEADERS'' and trx_id='''||b.header_id||''')')tax_category
from (
select b_cust_name customer_name,demand_class_code,region,order_number,header_id,FLOW_STATUS_CODE,ord_type
,sum((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price)order_pending_without_tax
,sum((ordered_quantity)*(unit_selling_price+tax_amt))order_value_with_tax
,sum((ordered_quantity-nvl(shipped_quantity,0))*(unit_selling_price+tax_amt))order_pending_with_tax
from  jan_bms_order_pending_new_v where   FLOW_STATUS_CODE NOT IN ('CLOSED','CANCELLED','ENTERED')
and SOLD_TO_ORG_ID=" & ds1.Tables("cust").Rows(0).Item("customer_id") & "
group by b_cust_name,region,order_number,sold_to_org_id,demand_class_code,header_id,FLOW_STATUS_CODE,ord_type)b"
            ds = SQL_SELECT("data", sql)
            dgv1.DataSource = ds.Tables("data")
        Else
            MessageBox.Show("Select Customer Name and view pending order", "New Bill To Ship To Form", MessageBoxButtons.OK)
        End If
    End Sub
End Class