Public Class Active_inactice_OA
    Private Sub Active_inactice_OA_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        sql = " declare begin  JAN_ORDER_ACTIVE_INACTIVE_PROC; end ;"
        comand()

        sql = "insert into jan_sms_outbox_all (MSG_NO,MSG_SENT,MSG_SENDER,MSG_MESSAGE,PROGRAM_NAME,MSG_FROM_SIM)VALUES  (jan_sms_sent_seq.nextval,sysdate,(select mobile_no from jan_sms_stock_users_all where SNO=8),(select 'Active OA Status ason :'||active_oa_end_dt actice_oa_status from jan_sales_bi_setup),'DR MIS','8754019177')"
        Command()

        sql = "insert into jan_sms_outbox_all (MSG_NO,MSG_SENT,MSG_SENDER,MSG_MESSAGE,PROGRAM_NAME,MSG_FROM_SIM)VALUES  (jan_sms_sent_seq.nextval,sysdate,(select mobile_no from jan_sms_stock_users_all where SNO=34),(select 'Active OA Status ason :'||active_oa_end_dt actice_oa_status from jan_sales_bi_setup),'DR MIS','8754019177')"
        Command()

        End
        Me.Close()


    End Sub
End Class