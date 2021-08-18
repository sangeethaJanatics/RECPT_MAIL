Public Class AR_and_invoice_value_check
    Dim inv_view_name, ar_view_name As String


    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Cursor.Current = Cursors.WaitCursor

        If chk_skyfast.Checked = True Then
            inv_view_name = "jan_invoice_listing_sf"
            ar_view_name = "jan_region_payment_pending_sf"
        Else
            inv_view_name = "jan_invoice_listing"
            ar_view_name = "jan_region_payment_pending_tab"
        End If
       

        sql = "select a.*,nvl((select sum(extended_amount) from jan_invoice_tax where customer_trx_id=a.customer_trx_id),0)tax_val,0  total_invoice_value,nvl((select sum(amount_due_original) from " & ar_view_name & " where customer_trx_id=a.customer_trx_id),0)invoice_value_in_Ar ,0 diff from (select bill_to_cust_name,customer_trx_id,trx_number,trx_date,sum(quantity_invoiced*unit_selling_price)basic_value  from " & inv_view_name & " where 1=1 "

        If txt_invoice.Text <> "" Then sql &= " and trx_number='" & txt_invoice.Text & "'"

        sql &= " and trx_date=case when to_date('" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "')=trunc(sysdate) then trunc(sysdate)+2  else to_date('" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "') end group by customer_trx_id,trx_number,trx_date,bill_to_cust_name)a"
        ds = SQL_SELECT("data", sql)
        With ds.Tables("data")

            For i = 0 To .Rows.Count - 1
                .Rows(i).Item("total_invoice_value") = .Rows(i).Item("basic_value") + .Rows(i).Item("tax_val")
                .Rows(i).Item("diff") = .Rows(i).Item("total_invoice_value") - .Rows(i).Item("invoice_value_in_Ar")

            Next

        End With

        With dgv1
            .DataSource = ds.Tables("data")
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells("Diff").Value <> 0 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Red
                Else

                End If

            Next
            .Columns("customer_trx_id").Visible = False
            .Columns("bill_to_cust_name").HeaderText = "Customer Name"
            .Columns("trx_number").HeaderText = "Invoice No"
            .Columns("trx_date").HeaderText = "Invoice Dt"
            .Columns("basic_value").HeaderText = "Basic value"
            .Columns("tax_val").HeaderText = "Tax Value"
            .Columns("diff").HeaderText = "Diff (between AR & GL)"
            .Columns("total_invoice_value").HeaderText = "Total Invoice value"
            .Columns("invoice_value_in_Ar").HeaderText = "Invoice value in GL"
           

        End With

        Cursor.Current = Cursors.Default
    End Sub
End Class