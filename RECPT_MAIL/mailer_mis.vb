Imports System.Data.OracleClient
Public Class mailer_mis

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        ds = New DataSet
        sql = "SELECT rownum ""S No"",a.mail_name""Mail Name"",(SELECT COUNT(*) FROM jan_mailer_table WHERE schedule_id=a.schedule_id AND TRUNC(run_date)='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "')""No of Times Mailed"" FROM (SELECT mail_name,schedule_id FROM jan_mailer_schedule WHERE schedule_id NOT IN ('4','5','6') ORDER BY schedule_id)a"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        dgv1.DataSource = ds.Tables("result")
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    End Sub
    Private Sub mailer_mis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_go_Click(sender, e)
    End Sub
End Class