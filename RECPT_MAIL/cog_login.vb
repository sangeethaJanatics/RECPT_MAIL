Public Class cog_login

    Private Sub BTN_LOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LOGIN.Click
        If TXT_UNAME.Text <> "" And TXT_PWD.Text <> "" Then
            If TXT_UNAME.Text = "COG" And TXT_PWD.Text = "COGCYR" Then
                Cog_current_year.Show()
                Me.Hide()
            Else
                MessageBox.Show("User Name or Password is Invalid", "Cog Login", MessageBoxButtons.OK)

            End If

        End If
    End Sub
End Class