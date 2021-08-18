Public Class stock_out_alert_1
    Dim first_date, last_date As Date
    Dim dr As Odbc.OdbcDataReader
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        ds = New DataSet
        sql = "select trunc(sysdate-180) frm_date from dual"
        adap = New Odbc.OdbcDataAdapter(sql, con)
        adap.Fill(ds, "result")
        first_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, ds.Tables("result").Rows(0).Item("frm_date")), Date.MinValue)
        last_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)

        ds = New DataSet
        sql = ""
        adap = New Odbc.OdbcDataAdapter(sql, con)
        adap.Fill(ds, "result")
        For i = 0 To ds.Tables("result").Rows.Count - 1

        Next
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Private Sub stock_out_alert_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_go_Click(sender, e)
    End Sub
End Class