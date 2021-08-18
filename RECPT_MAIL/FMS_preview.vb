Public Class FMS_preview
    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        wb.ShowPrintPreviewDialog()

    End Sub

    Private Sub FMS_preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            wb.ShowPrintPreviewDialog()
            Timer1.Stop()
            Timer2.Start()
        Catch ex As Exception

        End Try
        'End If


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            SendKeys.Send("{TAB}")
            SendKeys.Send("{ENTER}")
            Timer2.Stop()
            Timer3.Start()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        SendKeys.Send("{H}")
        'SendKeys.Send("{ENTER}")
        'SendKeys.Send("{ESC}")
        Timer3.Stop()
        Me.Hide()
    End Sub


End Class