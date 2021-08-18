Public Class DS_Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        sql = "select * from jan_bi_sales_user WHERE REPORT_NAME='DEMAND SET' AND ENABLED='Y' AND UserNAME=UPPER('" & TXT_UNAME.Text & "')  AND PassWorD=UPPER('" & TXT_PWD.Text & "') "
        ds = SQL_SELECT("res", sql)
        If ds.Tables("RES").Rows.Count > 0 Then
            Demand_set_MIS.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid User Name or Password ...!")
        End If


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
