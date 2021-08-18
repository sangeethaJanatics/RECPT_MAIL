Public Class Reservation_flush
    Private Sub Reservation_flush_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00017','Reservation Flush',sysdate) "
        comand()

        Try
            sql = "update jan_sales_bi_setup set reservation_flush_st_date=sysdate "
            comand_new()

            sql = " DELETE FROM JAN_OA_BIN_REQUIREMNT_LINES_T"
            comand_new()

            sql = " DELETE FROM JAN_QUOTA_AVAILABLE_ITEMS_T"
            comand_new()


            sql = " DELETE FROM jan_bin_transaction_lines_all"
            comand_new()
        Catch ex As Exception
            sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.Message.Replace("'", " ") & "' ,end_time=sysdate  where trunc(start_time)=trunc(sysdate) and s_code='C00017' and end_time is null "
            comand()
        End Try
        sql = "update jan_sales_bi_setup set reservation_flush_end_date=sysdate "
        comand_new()
        sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00017'  and end_time is null"
        comand()

        End
    End Sub
End Class