Public Class order_pending
    Dim report_for As String
    Private Sub order_pending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select to_char(sysdate-21,'IYYYIW')wk from dual union select to_char(sysdate-14,'IYYYIW') wk from dual  union select to_char(sysdate-7,'IYYYIW') wk from dual union select to_char(sysdate,'IYYYIW') wk from dual"

        ds = SQL_SELECT("wk", sql)
        cmb_ofd_wk.DataSource = ds.Tables("wk")
        cmb_ofd_wk.ValueMember = "wk"
        cmb_ofd_wk.DisplayMember = "wk"

        sql = "SELECT DISTINCT SEGMENT14 region FROM RA_TERRITORIES WHERE SEGMENT14 NOT IN ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O') order by 1"
        ds = SQL_SELECT("region", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.ValueMember = "region"
        cmb_region.DisplayMember = "region"
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Cursor.Current = Cursors.WaitCursor



        If rad_production_pending.Checked = True Then
            report_for = "(ordered_quantity - (nvl(shipped_quantity, 0) + picked_qty + rsv_qty))"
        ElseIf rad_order_pending.Checked = True Then
            report_for = "(ordered_quantity-nvl(shipped_quantity,0))"
        End If

        sql = "select customer_name "

        'If cmb_region.Text <> " " Then sql &= " ,region"

        sql &= " ,region"
        If chk_orgwise_order_pending.Checked = True Then

            sql &= " ,order_number ""Order No"",ordered_date ""Order Dt"",to_char(order_ff_dt,'IYYYIW')""OFD Wk"",sum(order_value)""Order Value"",i21_item_no ""I21 Item No"",sum(i21_qty)""I21 Qty"",i22_item_no ""I22 Item No"",sum(i22_qty)""I22 Qty"",i23_item_no ""I23 Item No"",sum(i23_qty)""I23 Qty"",i24_item_no ""I24 Item No"",sum(i24_qty)""I24 Qty"",i25_item_no ""I25 Item No"",sum(i25_qty)""I25 Qty"",i26_item_no ""I26 Item No"",sum(i26_qty)""I26 Qty"",others_item_no ""Other Org Item No"",sum(others_qty)""Others Qty"" ,sum(in_ams)in_ams from (select order_ff_dt, customer_name,region,order_number,ordered_date,sum(ordered_quantity*unit_selling_price)order_value,(case when organization_id=524 then ordered_item end )i21_item_no,sum(case when organization_id=524 then " & report_for & " end )i21_qty,(case when organization_id=464 then ordered_item end )i22_item_no,sum(case when organization_id=464 then " & report_for & " end )i22_qty,(case when organization_id=444 then ordered_item end )i23_item_no,sum(case when organization_id=444 then " & report_for & " end )i23_qty,(case when organization_id=504 then ordered_item end )i24_item_no,sum(case when organization_id=504 then " & report_for & " end )i24_qty,(case when organization_id=484 then ordered_item end )i25_item_no,sum(case when organization_id=484 then " & report_for & " end )i25_qty,(case when organization_id=505 then ordered_item end )i26_item_no,sum(case when organization_id=505 then " & report_for & " end )i26_qty,(case when organization_id not in (444,464,484,504,505) then ordered_item end )others_item_no,sum(case when organization_id not in (444,464,484,504,505,524) then " & report_for & " end )others_qty,sum(in_ams)in_ams from (select a.*,nvl((select rsv_by_ams from JAN_ORDER_PEND_STATUS2_TAB where line_id=a.line_id),0)in_ams from  jan_sales_any_tb2_1 a where  /* ordered_item<>'ICSR'  inventory_item_id<>21835264 and */"
        Else
            sql &= " ,order_number ""Order No"",ordered_date ""Order Dt"",to_char(order_ff_dt,'IYYYIW')""OFD Wk"" ,ordered_item ""Item No"", sum(" & report_for & ")Qty, sum(" & report_for & "*unit_selling_price)report_value,sum(in_ams)in_ams from (select a.*,nvl((select rsv_by_ams from JAN_ORDER_PEND_STATUS2_TAB where line_id=a.line_id),0)in_ams from  jan_sales_any_tb2_1 a where  /* ordered_item<>'ICSR'  inventory_item_id<>21835264 and */"
        End If
        If rad_customer.Checked = True Then sql &= "  customer_id not in (select customer_id from ra_customers where customer_class_code='DEALER')"
        If rad_dealer.Checked = True Then sql &= "  customer_id  in (select customer_id from ra_customers where customer_class_code='DEALER')"

        If cmb_region.Text <> "" Then sql &= "  and region='" & cmb_region.Text & "'"
        sql &= " and to_char(order_ff_dt,'IYYYIW')"
        If chk_ofd_upto.Checked = True Then
            sql &= "<="
        Else
            sql &= "="
        End If

        sql &= " '" & cmb_ofd_wk.Text & "'"
        If txt_order_no.Text <> "" Then
            sql &= " and order_number='" & txt_order_no.Text & "'"
        End If
        sql &= " and flow_status_code='AWAITING_SHIPPING' "
        sql &= " and  " & report_for & ">0 "

        'sql &= " And order_ff_dt <'3-dec-2017' "
        If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno('" & txt_item_no.Text & "')  "

        'If rad_active_oa.Checked = True Then
        '    sql &= " AND (CASE WHEN trunc(BOOKED_DATE)<'9-MAY-2020' AND nvl((SELECT COUNT(*) FROM JAN_ORDER_ACTIVE_INACTIVE WHERE header_id||'.'||Line_number= a.header_id||'.'||a.Line_number),0)=0 THEN  0 ELSE 1 END)=1 "
        'End If
        'If rad_inactive_oa.Checked = True Then
        '    sql &= " AND (CASE WHEN trunc(BOOKED_DATE)<'9-MAY-2020' AND nvl((SELECT COUNT(*) FROM JAN_ORDER_ACTIVE_INACTIVE WHERE header_id||'.'||Line_number= a.header_id||'.'||a.Line_number),0)=0 THEN  0 ELSE 1 END)=0 "
        'End If

        'ACTIVE_OA = ret_val("SELECT   (CASE WHEN BOOKED_DATE<'9-MAY-2020'  AND nvl((SELECT COUNT(*) FROM JAN_ORDER_ACTIVE_INACTIVE WHERE header_id||'.'||Line_number= OP.header_id||'.'||OP.Line_number),0)=0 THEN  0 ELSE 1 END)  ACTIVE_OA from JAN_BMS_ORDER_PENDING_NEW_V op where LINE_ID=" & lv_oa_line_id & "")

        sql &= " )group by  customer_name,region,order_number,ordered_date,ordered_item,organization_id,order_ff_dt "

        If chk_orgwise_order_pending.Checked = True Then

            sql &= " )group by  customer_name,"

            'If cmb_region.Text <> "" Then sql &= " region,"
            sql &= " region"

            sql &= " , order_number,ordered_date,i21_item_no,i22_item_no,i23_item_no,i24_item_no,i25_item_no,i26_item_no,others_item_no,order_ff_dt order by 1 "
        End If

        ds = SQL_SELECT("data", sql)

        If ds.Tables("data").Rows.Count > 0 Then

            With dgv1
                .DataSource = ds.Tables("data")
                .Columns(5).Frozen = True
                If chk_orgwise_order_pending.Checked = True Then
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If cmb_region.Text <> "" Then .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Else
                    .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End If

                .Columns("in_ams").Visible = False

                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Cells("in_ams").Value > 0 Then .Rows(i).Cells(2).Style.BackColor = Color.LightGreen
                Next

            End With

        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgv1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        'If .Rows(i).Cells("in_ams").Value > 0 Then .Rows(i).Cells(2).Style.BackColor = Color.LightGreen
        If e.RowIndex >= 0 Then
            If e.RowIndex <= dgv1.Rows.Count - 1 Then
                'If dgv1.Columns(e.ColumnIndex).Index >= 2 Then
                '    If Not IsDBNull(e.Value) = True Then
                '        If CDbl(e.Value) = 0 Then
                '            e.Value = ""
                '        End If
                '    End If

                'End If
                Dim c As Color
                'If dgv1.Rows(e.RowIndex).Cells(0).Value = "TOTAL" Then
                '    c = Color.LightGray
                '    e.CellStyle.BackColor = c
                '    e.CellStyle.Font = New Font("Arial", 8, FontStyle.Regular)

                'Else
                '    dgv1.Columns(0).DefaultCellStyle.BackColor = Color.GhostWhite
                'End If

                If dgv1.Rows(e.RowIndex).Cells("in_ams").Value > 0 Then dgv1.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    Private Sub btn_export_to_excel_Click(sender As Object, e As EventArgs) Handles btn_export_to_excel.Click
        Dim dt As DataTable
        ' Dim dr As DataRow
        Dim myString As String
        Dim bFirstRecord As Boolean = True
        Dim myWriter As New System.IO.StreamWriter("d:\bms\ORDERPEND.csv")
        myString = ""
        Try
            dt = ds.Tables("data")
            For i = 0 To ds.Tables("data").Columns.Count - 1
                If i > 0 Then
                    myString &= (",")
                End If
                myString &= ds.Tables("data").Columns(i).ColumnName
            Next
            myString &= (Environment.NewLine)

            For Each dr As DataRow In dt.Rows
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString &= (",")
                    End If
                    myString &= (field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString &= (Environment.NewLine)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Write the String to the Csv File
        myWriter.WriteLine(myString)
        'Clean up
        myWriter.Close()
        Process.Start("d:\bms\ORDERPEND.csv")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chk_orgwise_order_pending.CheckedChanged

    End Sub
End Class