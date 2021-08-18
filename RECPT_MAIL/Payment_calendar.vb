Public Class Payment_calendar

    Private Sub Payment_calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select customer_name,customer_id from ra_customers where customer_class_code='DEALER' order by 1"

        ds = SQL_SELECT("CUST", sql)
        cmb_dealer.DataSource = ds.Tables("CUST")
        cmb_dealer.ValueMember = "customer_id"
        cmb_dealer.DisplayMember = "customer_name"

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        sql = "select distinct trunc(AS_ON)AS_ON ,to_char(AS_ON,'MON_DD')day_seg from jan_dealer_payment2_bk where cust_id=" & cmb_dealer.SelectedValue & " and trunc(as_on)>='" & Format(DATE_TIME_PIC1.Value, "dd-MMM-yyyy") & "' and trunc(as_on)<='" & Format(DATE_TIME_PIC2.Value, "dd-MMM-yyyy") & "' order by AS_ON"
        ds = SQL_SELECT("date", sql)

        'sql = "select a.*"
        'For i = 0 To ds.Tables("date").Rows.Count - 1

        '    With ds.Tables("date").Rows(i)
        '        sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2_bk where  cust_id=a.cust_id and trunc(payment_exp_date)=a.payment_exp_date and trunc(as_on)='" & Format(.Item("AS_ON"), "dd-MMM-yyyy") & "'),0)" & .Item("day_seg") & ""
        '    End With
        'Next


        'sql &= " from (  select distinct trunc(payment_exp_date)payment_exp_date,cust_id from jan_dealer_payment2_bk where cust_id=" & cmb_dealer.SelectedValue & " and trunc(as_on)>='" & Format(DATE_TIME_PIC1.Value, "dd-MMM-yyyy") & "' and trunc(as_on)<='" & Format(DATE_TIME_PIC2.Value, "dd-MMM-yyyy") & "' order by payment_exp_date)a"



        sql = "   select  trunc(payment_exp_date)payment_exp_date "

        For i = 0 To ds.Tables("date").Rows.Count - 1

            With ds.Tables("date").Rows(i)
                sql &= " ,sum(case when trunc(as_on)='" & Format(.Item("AS_ON"), "dd-MMM-yyyy") & "' then (payment_value-nvl(rsv2,0)) end  )" & .Item("day_seg") & ""
            End With
        Next

        sql &= " from jan_dealer_payment2_bk where cust_id=" & cmb_dealer.SelectedValue & " and trunc(as_on)>='" & Format(DATE_TIME_PIC1.Value, "dd-MMM-yyyy") & "' and trunc(as_on)<='" & Format(DATE_TIME_PIC2.Value, "dd-MMM-yyyy") & "' group by trunc(payment_exp_date) order by payment_exp_date"


        ds = SQL_SELECT("result", sql)
        dgv1.DataSource = ds.Tables("result")
        For i = 1 To dgv1.Columns.Count - 1
            dgv1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Next

        sql = "select (select customer_name from ra_customers where customer_id=a.pay_from_customer)""Dealer Name"",receipt_date""Receipt Date"",amount ""Amount"",status ""Status"",creation_date ""Oracle Entry (Creation Date)""  from ar_cash_receipts_all a where pay_from_customer= " & cmb_dealer.SelectedValue & " and trunc(receipt_date)>='" & Format(DATE_TIME_PIC1.Value, "dd-MMM-yyyy") & "' order by receipt_date"
        ds = SQL_SELECT("pay", sql)
        dgv_payment.DataSource = ds.Tables("pay")
        'dgv_payment.Columns(0).Frozen = True
        dgv_payment.Columns(2).Frozen = True

        sql = "select  customer_name ""Customer Name"",order_number""Order No"",ordered_date""Order Dt"",booked_date ""Booked Dt"",payment_ff_dt ""Payment ff Dt"",sum(ordered_quantity*(unit_selling_price+tax_amount))""Order Value"" from jan_sales_any_tb2_1 where trunc(ordered_date)>='" & Format(DATE_TIME_PIC1.Value, "dd-MMM-yyyy") & "' and customer_id=" & cmb_dealer.SelectedValue & " group by   customer_name,order_number,ordered_date,booked_date,payment_ff_dt order by   customer_name,ordered_date,payment_ff_dt"
        ds = SQL_SELECT("pay", sql)
        dgv_order.DataSource = ds.Tables("pay")

    End Sub
End Class