Public Class daily_mail
    Dim h As Integer
    Private Sub daily_mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        criteria_combo.Items.Add("Not Delivered-Inspection Completed before 12:00 PM")
        criteria_combo.Items.Add("RTV Pending")
        criteria_combo.Items.Add("Job Store Pending")
        For h = 0 To criteria_combo.Items.Count - 1

        Next
        'DateTimePicker1.Value = "01/04/2009"
        'DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, Date.Today)
    End Sub
End Class