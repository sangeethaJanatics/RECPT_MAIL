Public Class GST_OA_Rsv_Login

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        sql = " select * from jan_bms_login where uname='" & txt_user_name.Text & "' and prpwd='" & txt_pwd.Text & "'"
        ds = SQL_SELECT("org", sql)
        If ds.Tables("org").Rows.Count > 0 Then
            GST_OA_Interface.Show()
            Me.Hide()
        Else
            MessageBox.Show("User Name or Password is Invalid ", "GST order Interface", MessageBoxButtons.OK)

        End If
    End Sub
End Class