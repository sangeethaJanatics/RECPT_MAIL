Imports System.Data.OracleClient
Public Class Attn_Login

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        'ds = New DataSet
        'sql = "SELECT * FROM jan_attendance_user where user_name='" & UserName_txt.Text & "' and pwd='" & pwd_txt.Text & "'"
        'adap = New OracleDataAdapter(sql, con)
        'adap.Fill(ds, "user")
        'If ds.Tables("user").Rows.Count > 0 Then
        'attn_status.deptid_txt.Text = ds.Tables("user").Rows(0).Item("dept_id")
        If UserName_txt.Text = "ATTEND" And pwd_txt.Text = "JAN267" Then
            attn_status.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid User Name or Password", "Attendance Login", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
End Class