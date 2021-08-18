Public Class Dealer_payment_calendar_freezing
    Private Sub Dealer_payment_calendar_freezing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00103','Dealer Payment calendar',sysdate) "
        'comand()
        'sql = "DECLARE BEGIN  JAN_DEALER_PAYMENT_AR_PROC(0); END;"
        'comand_new()

        'sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00103'  and end_time is null"
        'comand()
        'End
        'Me.Close()

        sql = "select customer_name,customer_id from ra_customers where customer_class_code='DEALER' union select 'ALL' customer_name,0 customer_id  from dual  order by 1"

        ds = SQL_SELECT("CUST", sql)
        cmb_dealer.DataSource = ds.Tables("CUST")
        cmb_dealer.ValueMember = "customer_id"
        cmb_dealer.DisplayMember = "customer_name"

    End Sub

    Private Sub btn_run_payment_proc_Click(sender As Object, e As EventArgs) Handles btn_run_payment_proc.Click
        sql = "DECLARE BEGIN  JAN_DEALER_PAYMENT_AR_PROC(" & cmb_dealer.SelectedValue & "); END;"
        comand_new()
        MessageBox.Show("Dealer Payment calendar Completed ", "Dealer Payment Calendar Run Status ", MessageBoxButtons.OK)
    End Sub
End Class