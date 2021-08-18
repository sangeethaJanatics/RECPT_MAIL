Public Class Sales_Return_Login

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        sql = "select * from jan_bi_sales_user where  REPORT_NAME='RMA' AND USERNAME=upper('" & txt_uname.Text & "') AND  PASSWORD=upper('" & txt_pwd.Text & "')"
        SQL_SELECT("LOG", sql)
        If ds.Tables("LOG").Rows.Count > 0 Then
            rma_user = txt_uname.Text.ToUpper
            rma.Show()
            Me.Hide()
        Else
            MessageBox.Show("User Name or Password is not Correct", "RMA Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class