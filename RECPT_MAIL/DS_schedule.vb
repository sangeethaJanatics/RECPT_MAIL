Public Class DS_schedule

    Private Sub DS_schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sql = "select * from dual"
        'ds = SQL_SELECT("org", sql)
        'Me.Close()

        Try

            sql = " DECLARE BEGIN jan_demand_set_proc; END;"
            comand()

        Catch ex As Exception

            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Error in DS Procedure Run ')"
            comand()
        End Try

        Me.Close()

    End Sub
End Class