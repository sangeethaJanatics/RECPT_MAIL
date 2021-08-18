Public Class order_receipt_for_the_items
    Private Sub order_receipt_for_the_items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "select customer_id,customer_Name from ra_customers where status='A'  order by customer_Name"
        ds = SQL_SELECT("data", sql)
        cmb_customer.DataSource = ds.Tables("data")
        cmb_customer.DisplayMember = "customer_Name"
        cmb_customer.ValueMember = "customer_id"

    End Sub

    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dgv.Columns.Clear()
        sql = "select  distinct to_char(updation_date,'MMYYYY') my,to_char(updation_date,'YYYYMM')my1,to_char(updation_date,'Mon_YYYY')month_name from jan_dsales_tb1 where trunc(updation_date)>='" & Format(DateTimePicker_from.Value, "dd-MMM-yyyy") & "' and  trunc(updation_date)<='" & Format(DateTimePicker_to.Value, "dd-MMM-yyyy") & "' order  by my1 "
        ds2 = SQL_SELECT("mnth", sql)


        sql = "select jan_orgcode(organization_id)org,ordered_item,customer_name "

        For i = 0 To ds2.Tables("MNTH").Rows.Count - 1
            With ds2.Tables("MNTH").Rows(i)

                sql &= " ,sum(case when odtmy='" & .Item("MY") & "' then ordered_quantity else 0 end)" & .Item("month_name") & "_order_qty "
                sql &= " ,sum(case when odtmy='" & .Item("MY") & "' then ordered_quantity*UNIT_SELLING_PRICE else 0 end)" & .Item("month_name") & "_order_VAL "

            End With
        Next


        sql &= " from jan_sales_any_tb2_1 where TRUNC(ordered_date)>='" & Format(DateTimePicker_from.Value, "dd-MMM-yyyy") & "' AND TRUNC(ordered_date)<'" & Format(DateAdd("d", 1, DateTimePicker_to.Value), "dd-MMM-yyyy") & "' "

        If txt_item1.Text <> "" Or txt_item2.Text <> "" Or txt_item3.Text <> "" Or txt_item4.Text <> "" Then

            sql &= " And  inventory_item_id  IN ( "

            If txt_item1.Text <> "" Then sql &= " jan_itemno('" & txt_item1.Text & "') "
            If txt_item2.Text <> "" Then sql &= " ,jan_itemno('" & txt_item2.Text & "') "
            If txt_item3.Text <> "" Then sql &= " ,jan_itemno('" & txt_item3.Text & "') "
            If txt_item4.Text <> "" Then sql &= " ,jan_itemno('" & txt_item4.Text & "') "


            sql &= " ) "

        End If
        If CMB_CUSTOMER.Text <> "" Then sql &= "  AND CUSTOMER_ID =" & CMB_CUSTOMER.SelectedValue & ""



        sql &= " group by organization_id,ordered_item,customer_name  ORDER BY customer_name"

        ds1 = SQL_SELECT("ORD", sql)
        ds1.Tables("ord").Rows.Add("Total")

        'Dim order_qty_cloumn, order_value_column As String

        'For i = 0 To ds2.Tables("MNTH").Rows.Count - 1
        '    With ds1.Tables("ord")
        '        order_qty_cloumn = ds2.Tables("MNTH").Rows(i).Item("month_name") & "_order_qty"

        '        'ds1.Tables("ord").Rows(ds1.Tables("ord").Rows.Count - 1).Item("" & .Item("month_name") & "_order_qty")
        '        '.Rows(.Rows.Count - 1).Item("abc_order_qty") = .Compute("sum(abc_order_qty", "abc_order_qty>=0")
        '        '.Rows(.Rows.Count - 1).Item("" & order_qty_cloumn & "") = .Compute("sum( " & order_qty_cloumn & " )", order_qty_cloumn >= 0)
        '        .Rows(.Rows.Count - 1).Item("" & order_qty_cloumn & "") = .Compute("sum(  " & order_qty_cloumn & "  )", order_qty_cloumn >= 0)

        '    End With
        'Next
        dgv.DataSource = ds1.Tables("ORD")

        For i = 3 To dgv.Columns.Count - 1
            With dgv
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

        Next

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
End Class