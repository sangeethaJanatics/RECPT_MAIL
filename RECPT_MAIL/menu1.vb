Public Class menu1
    Dim I, j, a As Integer
    Dim MNTH As String
    Dim feb_09 As Date
   
    Private Sub menu1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        feb_09 = "01-feb-2009"
        MNTH = ""
        j = 0
        a = 0
        For I = 0 To 50
            MNTH = Format(CDate(feb_09.AddMonths(a + j)), "MMyy")
            ComboBox1.Items.Add(MNTH)
            If I > 0 Then
                j = j + 1
            End If
            a = 1
        Next
    End Sub
End Class