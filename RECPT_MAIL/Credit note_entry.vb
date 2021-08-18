Imports System.Data.OracleClient
Public Class Credit_note_entry
    Dim newPoint As New System.Drawing.Point()
    Dim a As Integer
    Dim b As Integer
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ds = New DataSet
        sql = "select rownum ""Sl No"",b.* from (select trn_no ""TRN Number"",Rma_no ""RMA Number"",rma_dt ""RMA Dt"",(SELECT RA.CUSTOMER_naME FROM OE_ORDER_HEADERS_aLL OEH,RA_CUSTOMERS RA WHERE OEH.SOLD_TO_ORG_ID=RA.CUSTOMER_ID AND OEH.ORDER_NUMBER=A.RMA_NO)""Customer Name"",(SELECT oel.attribute6 FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel WHERE OEH.header_id=OEl.header_id AND  OEH.ORDER_NUMBER=a.rma_no and rownum=1) ""Customer Invoice No"","

        sql &= " (SELECT oel.attribute8 FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel WHERE OEH.header_id=OEl.header_id AND  OEH.ORDER_NUMBER=a.rma_no and rownum=1)""Janatics Inv No"","
        sql &= " (SELECT RA.region FROM OE_ORDER_HEADERS_aLL OEH,jan_bms_customer_region_v RA WHERE OEH.SOLD_TO_ORG_ID=RA.CUSTOMER_ID AND OEH.ORDER_NUMBER=A.RMA_NO and rownum=1)""Region"","

        sql &= "nvl((SELECT sum(oel.ordered_Quantity)val FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel WHERE OEH.header_id=OEl.header_id AND  OEH.ORDER_NUMBER=A.RMA_NO),0)qTY,"


        sql &= "nvl((SELECT sum(oel.unit_selling_price*oel.ordered_Quantity)val FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel WHERE OEH.header_id=OEl.header_id AND  OEH.ORDER_NUMBER=A.RMA_NO),0)BASIC_VALUE,"

        sql &= " rowtocol('SELECT distinct ARL.DESCRIPTION RETURN_REASON FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel,apps.ar_lookups arl WHERE OEH.header_id=OEl.header_id AND ARL.LOOKUP_TYPE=''CREDIT_MEMO_REASON'' AND ARL.LOOKUP_CODE=OEL.RETURN_REASON_CODE AND OEH.ORDER_NUMBER='||A.RMA_NO||'')""Return Reason"",(SELECT TRUNC(oeh.booked_date) FROM OE_ORDER_HEADERS_aLL OEH WHERE  OEH.ORDER_NUMBER=a.rma_no ) ""Sales Approval"",qc_approval ""QA Remarks"" ,qc_dt ""QA Date"","

        sql &= "(SELECT RCH.CREATION_daTE FROM RCV_SHIPMENT_HEADERS RCH,RCV_SHIPMENT_LINES RCL,oe_order_headers_all oeh,OE_ORDER_LINES_ALL OEL WHERE RECEIPT_SOURCE_CODE='CUSTOMER' AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID=OEL.LINE_ID AND oeh.header_id=oel.header_id AND OEH.ORDER_NUMBER=A.RMA_NO and rownum=1)""Receipt Date"","

        sql &= "(SELECT  sum(ja_in.tax_amount)  FROM RCV_SHIPMENT_HEADERS RCH,RCV_SHIPMENT_LINES RCL,oe_order_headers_all oeh,OE_ORDER_LINES_ALL OEL ,JA_IN_RECEIPT_TAX_LINES ja_in WHERE  RECEIPT_SOURCE_CODE='CUSTOMER' AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID=OEL.LINE_ID AND oeh.header_id=oel.header_id and ja_in.shipment_line_id=RCL.SHIPMENT_LINE_ID  and ja_in.tax_type='Excise' AND OEH.ORDER_NUMBER=A.RMA_NO)Cenvat_Value,"

        sql &= " central_excise_submit ""Central Excise Submit Date"",fg_received_date ""FG Hand over"","

        'sql &= " TO_DATE(NULL) ""FG Inward Date"","FG Hand over

        sql &= " (SELECT max(TRUNC(rt.transaction_DAte)) FROM RCV_SHIPMENT_HEADERS RCH,  RCV_SHIPMENT_LINES RCL,  oe_order_headers_all oeh,  OE_ORDER_LINES_ALL OEL , rcv_transactions rt WHERE RCH.SHIPMENT_HEADER_ID=Rt.SHIPMENT_HEADER_ID AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID  =OEL.LINE_ID AND oeh.header_id         =oel.header_id AND OEH.ORDER_NUMBER      =A.RMA_NO and rt.transaction_type='DELIVER') ""FG Inward Date"","

        sql &= " accounts_received_date ""Accounts Received Date"" ,credit_note_no ""Credit Note No"",credit_value ""Credit Value"" ,(select transfered_to from jan_rma_listing where rma_number=a.rma_no and rownum=1)""Transferred To"" ,CREDIT_NOTE_DESPATCH ""Credit Note Despatch Details"",RAMARKS ""Remarks"" from jan_rma_return  a where 1=1  and trunc(rma_dt)>='" & Format(from_dt.Value, "dd-MMM-yyyy") & "' and trunc(rma_dt)<='" & Format(to_dt.Value, "dd-MMM-yyyy") & "'  "

        If cmb_pending.SelectedItem = "Credit note creation" Then sql &= " and  credit_note_no is null "

        If cmb_pending.SelectedItem = "FG Handover" Then sql &= " and  fg_received_date is null "

        If txt_inv_no.Text <> "" Then sql &= " and rma_no in (select distinct rma_number from jan_rma_listing where inv_no='" & txt_inv_no.Text & "') "

        If txt_jan_inv_no.Text <> "" Then sql &= " and rma_no in (select distinct rma_number from jan_rma_listing where janatics_inv_no='" & txt_jan_inv_no.Text & "') "

        If txt_trn_no.Text <> "" Then sql &= " and trn_no='" & txt_trn_no.Text & "'"
        If cmb_cust.Text <> "" Then
            sql &= "  AND  (SELECT SOLD_TO_ORG_ID FROM OE_ORDER_HEADERS_ALL WHERE ORDER_NUMBER=A.RMA_NO)= " & cmb_cust.SelectedValue
        End If

        If CMB_REG.Text <> "ALL" Then
            sql &= " AND (SELECT RA.region FROM OE_ORDER_HEADERS_aLL OEH,jan_bms_customer_region_v RA WHERE OEH.SOLD_TO_ORG_ID=RA.CUSTOMER_ID AND OEH.ORDER_NUMBER=A.RMA_NO and rownum=1)='" & CMB_REG.Text & "'"
        End If
        sql &= " order by rma_dt,rma_no)b "
        If cmb_pending.SelectedItem = "Transfer to FG Store" Then sql &= " where ""Transferred To"" is null "

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "res")
        Dim ROW_COUNT As Integer = 0
        If rma_user = "SERVICE" Then



            ROW_COUNT = ds.Tables("RES").Rows.Count

            ds.Tables("RES").Rows.Add()
            ds.Tables("RES").Rows.Add()



            sql = "SELECT ROWNUM ""Sl No"", ''""TRN Number"",ORDER_NUMBER ""RMA Number"",TRUNC(ORDERED_DATE)""RMA Dt"""

            sql &= ",(SELECT RA.CUSTOMER_naME FROM RA_CUSTOMERS RA WHERE RA.CUSTOMER_ID=A.SOLD_TO_ORG_ID )""Customer Name"",(SELECT oel.attribute6 FROM oe_order_lines_all oel WHERE A.header_id=OEl.header_id  and rownum=1) ""Customer Invoice No"","

            sql &= " (SELECT oel.attribute8 FROM oe_order_lines_all oel WHERE A.header_id=OEl.header_id  and rownum=1)""Janatics Inv No"","

            sql &= " (SELECT RA.region FROM jan_bms_customer_region_v RA WHERE A.SOLD_TO_ORG_ID=RA.CUSTOMER_ID  and rownum=1)""Region"","

            sql &= "nvl((SELECT sum(oel.unit_selling_price*oel.ordered_Quantity)val FROM oe_order_lines_all oel WHERE A.header_id=OEl.header_id ),0)BASIC_VALUE,"

            sql &= " rowtocol('SELECT distinct ARL.DESCRIPTION RETURN_REASON FROM oe_order_lines_all oel,apps.ar_lookups arl WHERE OEl.header_id='||A.header_id||' AND ARL.LOOKUP_TYPE=''CREDIT_MEMO_REASON'' AND ARL.LOOKUP_CODE=OEL.RETURN_REASON_CODE ')""Return Reason"",TRUNC(A.booked_date) ""Sales Approval"",'' ""QA Remarks"" ,TO_DATE(NULL) ""QA Date"","

            sql &= "(SELECT RCH.CREATION_daTE FROM RCV_SHIPMENT_HEADERS RCH,RCV_SHIPMENT_LINES RCL,OE_ORDER_LINES_ALL OEL WHERE RECEIPT_SOURCE_CODE='CUSTOMER' AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID=OEL.LINE_ID AND A.header_id=oel.header_id and rownum=1)""Receipt Date"","

            sql &= "(SELECT sum(ja_in.tax_amount) FROM RCV_SHIPMENT_HEADERS RCH,RCV_SHIPMENT_LINES RCL,OE_ORDER_LINES_ALL OEL ,JA_IN_RECEIPT_TAX_LINES ja_in WHERE  RECEIPT_SOURCE_CODE='CUSTOMER' AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID=OEL.LINE_ID AND A.header_id=oel.header_id and ja_in.shipment_line_id=RCL.SHIPMENT_LINE_ID  and ja_in.tax_type='Excise' )Cenvat_Value,"

            sql &= " TO_DATE(NULL) ""Central Excise Submit Date"",TO_DATE(NULL) ""FG Hand over"",TO_DATE(NULL) ""FG Inward Date"",TO_DATE(NULL)  ""Accounts Received Date"" ,NULL ""Credit Note No"",NULL ""Credit Value"" ,null ""Transferred To"" "

            sql &= " FROM OE_ORDER_HEADERS_ALL A WHERE ORDERED_DATE>'1-APR-2013' AND ORDER_NUMBER LIKE '2%' AND SUBSTR(ORDER_NUMBER,5,1)=3 AND ORDER_NUMBER NOT IN (SELECT RMA_NO FROM JAN_RMA_RETURN) AND FLOW_STATUS_CODE<>'CANCELLED' ORDER BY ORDER_NUMBER"

            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds, "res")
        End If

        Dim BASIC_TOTAL, CENVAT_TOTAL
        BASIC_TOTAL = 0
        CENVAT_TOTAL = 0

        With ds.Tables("RES")
            For i = 0 To .Rows.Count - 1
                If Not IsDBNull(.Rows(i).Item("BASIC_VALUE")) Then BASIC_TOTAL += .Rows(i).Item("BASIC_VALUE")
                If Not IsDBNull(.Rows(i).Item("CENVAT_VALUE")) Then CENVAT_TOTAL += .Rows(i).Item("CENVAT_VALUE")
            Next
        End With

        Label7.Text = "Basic Value Total :" & BASIC_TOTAL
        Label8.Text = "Cenvat Value Total :" & CENVAT_TOTAL

        With dgv1

            .DataSource = ds.Tables("res")
            .Columns("Sl No").Width = 30
            .Columns("TRN Number").Width = 60
            .Columns("Region").Width = 70
            .Columns("BASIC_VALUE").HeaderText = "Value (Basic)"
            .Columns("BASIC_VALUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("BASIC_VALUE").DefaultCellStyle.Format = "00.00"
            .Columns("CENVAT_VALUE").HeaderText = "Cenvat Value"
            .Columns("CENVAT_VALUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("CENVAT_VALUE").DefaultCellStyle.Format = "00.00"


            If rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Customer Invoice No").Visible = False

            If rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Central Excise Submit Date").Visible = False

            If rma_user = "EXCISE" Or rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Region").Visible = False
            If rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Then .Columns("BASIC_VALUE").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Return Reason").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Sales Approval").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "SALES" Or rma_user = "I01SERVICE" Then .Columns("QA Remarks").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "SALES" Or rma_user = "I01SERVICE" Then .Columns("QA Date").Visible = False
            If rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("Receipt Date").Visible = False
            If rma_user = "SALES" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Then .Columns("CENVAT_VALUE").Visible = False
            If rma_user = "EXCISE" Or rma_user = "SALES" Or rma_user = "QUALITY" Then .Columns("FG Hand over").Visible = False
            If rma_user = "EXCISE" Or rma_user = "SALES" Or rma_user = "QUALITY" Or rma_user = "I01SERVICE" Then .Columns("FG Inward Date").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "SALES" Or rma_user = "QUALITY" Or rma_user = "I01SERVICE" Then .Columns("Accounts Received Date").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Or rma_user = "I01SERVICE" Then .Columns("Credit Note No").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Or rma_user = "I01SERVICE" Then .Columns("Credit Value").Visible = False
            If rma_user = "EXCISE" Or rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "QUALITY" Or rma_user = "ACCOUNTS" Or rma_user = "I01SERVICE" Then .Columns("Credit Note Despatch Details").Visible = False


            If rma_user = "SERVICE" Then

                dgv1.Rows(ROW_COUNT).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                dgv1.Rows(ROW_COUNT).Cells("Customer Name").Value = "Un Booked Orders"
                dgv1.Rows(ROW_COUNT).DefaultCellStyle.ForeColor = Color.Crimson


                dgv1.Rows(ROW_COUNT + 1).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow

            End If
            For i = 0 To ROW_COUNT - 1
                If IsDBNull(.Rows(i).Cells("CENVAT_VALUE").Value) Then
                    .Rows(i).Cells("CENVAT_VALUE").Style.BackColor = Color.RosyBrown
                End If

                If IsDBNull(.Rows(i).Cells("Central Excise Submit Date").Value) Then
                    .Rows(i).Cells("Central Excise Submit Date").Style.BackColor = Color.RosyBrown
                End If



                If Not IsDBNull(.Rows(i).Cells("FG Inward Date").Value) Then

                    If IsDBNull(.Rows(i).Cells("FG Hand over").Value) And .Rows(i).Cells("Transferred To").Value <> "Service 1" Then

                        .Rows(i).Cells("FG Hand over").Value = .Rows(i).Cells("FG Inward Date").Value
                    End If
                End If


                'FG Inward Date"","FG Hand over
            Next
        End With
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click

        With dgv1
            .ReadOnly = False
            For i = 0 To .Rows.Count - 1
                .Rows(i).Cells("TRN Number").ReadOnly = True
                .Rows(i).Cells("RMA Number").ReadOnly = True
                .Rows(i).Cells("RMA Dt").ReadOnly = True
                .Rows(i).Cells("Customer Invoice No").ReadOnly = True
                .Rows(i).Cells("Janatics Inv No").ReadOnly = True
                .Rows(i).Cells("BASIC_VALUE").ReadOnly = True
                .Rows(i).Cells("Receipt Date").ReadOnly = True
                .Rows(i).Cells("Region").ReadOnly = True
                '
                .Rows(i).Cells("FG Hand over").ReadOnly = True
                '.Rows(i).Cells("FG Inward Date").ReadOnly = True
                .Rows(i).Cells("Accounts Received Date").ReadOnly = True
                .Rows(i).Cells("Central Excise Submit Date").ReadOnly = True
                .Rows(i).Cells("Credit Note No").ReadOnly = True
                .Rows(i).Cells("Credit Value").ReadOnly = True
                .Rows(i).Cells("QA Remarks").ReadOnly = True
                .Rows(i).Cells("QA Date").ReadOnly = True
                '.Rows(i).Cells("Sales Approval").ReadOnly = True
                .Rows(i).Cells("Cenvat_Value").ReadOnly = True
                .Rows(i).Cells("Return Reason").ReadOnly = True
                .Rows(i).Cells("Credit Note Despatch Details").ReadOnly = True

                If rma_user = "FGSTORE" Or rma_user = "APPLICATION" Or rma_user = "I01SERVICE" Then

                    If IsDBNull(.Rows(i).Cells("FG Hand over").Value) = True Then .Rows(i).Cells("FG Hand over").ReadOnly = False
                    'If IsDBNull(.Rows(i).Cells("FG Inward Date").Value) = True Then .Rows(i).Cells("FG Inward Date").ReadOnly = False

                ElseIf rma_user = "SALES" Then

                    If IsDBNull(.Rows(i).Cells("Credit Note Despatch Details").Value) = True Then .Rows(i).Cells("Credit Note Despatch Details").ReadOnly = False

                ElseIf rma_user = "ACCOUNTS" Then

                    If IsDBNull(.Rows(i).Cells("Accounts Received Date").Value) = True Then .Rows(i).Cells("Accounts Received Date").ReadOnly = False
                    If IsDBNull(.Rows(i).Cells("Credit Note No").Value) = True Then .Rows(i).Cells("Credit Note No").ReadOnly = False
                    If IsDBNull(.Rows(i).Cells("Credit Value").Value) = True Then .Rows(i).Cells("Credit Value").ReadOnly = False

                ElseIf rma_user = "EXCISE" Or rma_user = "I01SERVICE" Then

                    If IsDBNull(.Rows(i).Cells("Central Excise Submit Date").Value) = True Then .Rows(i).Cells("Central Excise Submit Date").ReadOnly = False
                ElseIf rma_user = "SERVICE" Then


                ElseIf rma_user = "QUALITY" Then

                    If IsDBNull(.Rows(i).Cells("QA Remarks").Value) = True Then .Rows(i).Cells("QA Remarks").ReadOnly = False
                    If IsDBNull(.Rows(i).Cells("QA Date").Value) = True Then .Rows(i).Cells("QA Date").ReadOnly = False

                End If


            Next
        End With
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        With dgv1
            For i = 0 To .Rows.Count - 1
                If Not IsDBNull(.Rows(i).Cells("Credit Note No").Value) Or Not IsDBNull(.Rows(i).Cells("Credit Note No").Value) Or Not IsDBNull(.Rows(i).Cells("FG Inward Date").Value) Or Not IsDBNull(.Rows(i).Cells("Accounts Received Date").Value) Or Not IsDBNull(.Rows(i).Cells("Central Excise Submit Date").Value) Or Not IsDBNull(.Rows(i).Cells("FG Hand over").Value) Or Not IsDBNull(.Rows(i).Cells("QA Date").Value) Or Not IsDBNull(.Rows(i).Cells("Sales Approval").Value) Or Not IsDBNull(.Rows(i).Cells("QA Remarks").Value) Or Not IsDBNull(.Rows(i).Cells("Remarks").Value) Then

                    sql = "update jan_rma_return  set last_update_date=sysdate "

                    If Not IsDBNull(.Rows(i).Cells("QA Date").Value) Then sql &= " , QC_DT='" & Format(.Rows(i).Cells("QA Date").Value, "dd-MMM-yyyy") & "' "

                    'If Not IsDBNull(.Rows(i).Cells("Sales Approval").Value) Then sql &= " , sales_approval='" & Format(.Rows(i).Cells("Sales Approval").Value, "dd-MMM-yyyy") & "' "

                    If Not IsDBNull(.Rows(i).Cells("QA Remarks").Value) Then sql &= " , QC_approval='" & .Rows(i).Cells("QA Remarks").Value & "' "

                    If Not IsDBNull(.Rows(i).Cells("Credit Note No").Value) Then sql &= " , credit_note_no='" & .Rows(i).Cells("Credit Note No").Value & "' "

                    If Not IsDBNull(.Rows(i).Cells("Credit Value").Value) Then sql &= " , credit_value=" & .Rows(i).Cells("Credit Value").Value & " "

                    If Not IsDBNull(.Rows(i).Cells("FG Hand over").Value) Then sql &= " , fg_received_date ='" & Format(.Rows(i).Cells("FG Hand over").Value, "dd-MMM-yyyy") & "'"

                    'If Not IsDBNull(.Rows(i).Cells("FG Inward Date").Value) Then sql &= " , fg_return_DAte ='" & Format(.Rows(i).Cells("FG Inward Date").Value, "dd-MMM-yyyy") & "'"

                    If Not IsDBNull(.Rows(i).Cells("Accounts Received Date").Value) Then sql &= " ,accounts_received_date ='" & Format(.Rows(i).Cells("Accounts Received Date").Value, "dd-MMM-yyyy") & "' "

                    If Not IsDBNull(.Rows(i).Cells("Central Excise Submit Date").Value) Then sql &= "  , central_excise_submit='" & Format(.Rows(i).Cells("Central Excise Submit Date").Value, "dd-MMM-yyyy") & "'"

                    If Not IsDBNull(.Rows(i).Cells("Credit Note Despatch Details").Value) Then sql &= " , CREDIT_NOTE_DESPATCH='" & .Rows(i).Cells("Credit Note Despatch Details").Value.ToString.Replace("'", "''") & "' "

                    If Not IsDBNull(.Rows(i).Cells("Remarks").Value) Then sql &= " , remarks='" & .Rows(i).Cells("Remarks").Value.ToString.Replace("'", "''") & "' "

                    sql &= " where rma_no='" & .Rows(i).Cells("RMA Number").Value & "'"
                    comand()
                End If

            Next
            .ReadOnly = True
            MessageBox.Show("Sales Return Data Updated", "RMA Credit Note Updation")
        End With

    End Sub
    Private Sub Credit_note_entry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        End
    End Sub
    Private Sub Credit_note_entry_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Credit_note_entry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub Credit_note_entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "select 0 customer_id,''customer_name from dual union select customer_id,customer_name from ra_customers order by CUSTOMER_nAME"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "cust")

        cmb_cust.DataSource = ds.Tables("cust")
        cmb_cust.ValueMember = "customer_id"
        cmb_cust.DisplayMember = "customer_nAme"

        ds = New DataSet
        sql = "select distinct SEGMENT14 from ra_territories where SEGMENT14 not in ('GOA','M.P.','PROJECTS 1','EXPORT','NOT LISTED')"

        CMB_REG.Items.Add("ALL")
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "region")
        For i = 0 To ds.Tables("region").Rows.Count - 1
            CMB_REG.Items.Add(ds.Tables("region").Rows(i).Item("segment14"))
        Next

        CMB_REG.Text = "ALL"
        btn_go_Click(sender, e)
    End Sub
    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick

        If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "RMA Number" Then
            Panel1.Visible = True
            ds = New DataSet
            sql = "SELECT oeh.order_number ""Rma No"",(select organization_code from org_organization_definitions where organization_id=oel.ship_from_org_id)""Org"",(select segment1 from mtl_system_items where organization_id=oel.ship_from_org_id and inventory_item_id=oel.inventory_item_id)""Item No"",(select Description from mtl_system_items where organization_id=oel.ship_from_org_id and inventory_item_id=oel.inventory_item_id)""Description"",oel.ordered_quantity Rma_Quantity,oel.ordered_quantity*unit_selling_price Rma_Value "

            sql &= ",(SELECT sum(ja_in.tax_amount) FROM RCV_SHIPMENT_HEADERS RCH,RCV_SHIPMENT_LINES RCL,JA_IN_RECEIPT_TAX_LINES ja_in WHERE  RECEIPT_SOURCE_CODE='CUSTOMER' AND RCH.SHIPMENT_HEADER_ID=RCL.SHIPMENT_HEADER_ID AND RCL.OE_ORDER_LINE_ID=OEL.LINE_ID AND oeh.header_id=oel.header_id and ja_in.shipment_line_id=RCL.SHIPMENT_LINE_ID  and ja_in.tax_type='Excise' )""Cenvat Value"""

            sql &= " FROM OE_ORDER_HEADERS_aLL OEH,oe_order_lines_all oel WHERE OEH.header_id=OEl.header_id AND OEH.ORDER_NUMBER='" & dgv1.CurrentRow.Cells("RMA Number").Value & "'"
            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds, "item")

            With ds.Tables("item")
                .Rows.Add()
                .Rows(.Rows.Count - 1).Item("Rma_Value") = .Compute("sum(Rma_Value)", "Rma_Value>= 0")
                .Rows(.Rows.Count - 1).Item("Rma_Quantity") = .Compute("sum(Rma_Quantity)", "Rma_Quantity>= 0")

            End With

            With dgv_item
                .DataSource = ds.Tables("item")
                .Columns("Rma_Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("Rma_Quantity").HeaderText = "Rma Quantity"
                .Columns("Rma_Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("Rma_Value").DefaultCellStyle.Format = "00.00"
                .Columns("Rma_Value").HeaderText = "Rma Value"
                .Columns("Org").Width = 40
                .Columns("Description").Width = 200
            End With

            Panel1.Visible = True
        End If
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Panel1.Visible = False
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        a = Control.MousePosition.X - Panel1.Location.X
        b = Control.MousePosition.Y - Panel1.Location.Y
    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Panel1.Location = newPoint
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Panel3.Visible = True
        new_pwd_txt.Text = ""
        old_pwd_txt.Text = ""
        retype_new_pwd.Text = ""

    End Sub
    Private Sub BTN_CHANGE_PWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CHANGE_PWD.Click
        'Dim DR As Odbc.OdbcDataReader
        If new_pwd_txt.Text <> "" And retype_new_pwd.Text <> "" Then
            sql = "select * from jan_bi_sales_user where report_name='RMA' AND USERNAME='" & rma_user & "'"
            cmd = New OracleClient.OracleCommand(sql, con)
            If con.State = ConnectionState.Closed Then con.Open()
            DR = cmd.ExecuteReader()
            If DR.HasRows = True Then
                If DR.Item("PASSWORD") = old_pwd_txt.Text Then
                    If new_pwd_txt.Text = retype_new_pwd.Text Then
                        sql = "update jan_bi_sales_user set password='" & new_pwd_txt.Text & "' where report_name='RMA' AND USERNAME='" & rma_user & "'"
                        cmd = New OracleCommand(sql, con)
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Password Changed ")
                        Panel3.Visible = False
                    Else
                        MessageBox.Show("Confirm New Password")
                    End If
                Else
                    MessageBox.Show("Invalid Password")
                End If
            End If
        Else
            MessageBox.Show("Enter & Confirm New Password")
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Panel3.Visible = False
    End Sub
    Private Sub Panel3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseDown
        a = Control.MousePosition.X - Panel3.Location.X
        b = Control.MousePosition.Y - Panel3.Location.Y
    End Sub
    Private Sub Panel3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Panel3.Location = newPoint
        End If
    End Sub

    Private Sub CMB_REG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_REG.SelectedIndexChanged

    End Sub
End Class