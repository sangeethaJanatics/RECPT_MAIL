Public Class Dealer_Payment_calendar

    Private Sub Dealer_Payment_calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select customer_name,customer_id from ra_customers where customer_class_code='DEALER' order by 1"

        ds = SQL_SELECT("CUST", sql)
        cmb_dealer.DataSource = ds.Tables("CUST")
        cmb_dealer.ValueMember = "customer_id"
        cmb_dealer.DisplayMember = "customer_name"
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = " select * from jan_dealer_payment2 where cust_id=" & cmb_dealer.SelectedValue & " ORDER BY CUST_ID,PAYMENT_EXP_DATE ,flag,line_id"
        ds = SQL_SELECT("CUST", sql)
        Dgv_gate1.DataSource = ds.Tables("CUST")

    End Sub
End Class