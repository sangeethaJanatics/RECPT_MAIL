Public Class unity_testing

    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        Dim x As Integer = e.X
        Dim y As Integer = e.Y
        MessageBox.Show("X & Y value " & x & " and " & y, "", MessageBoxButtons.OK)
    End Sub
End Class