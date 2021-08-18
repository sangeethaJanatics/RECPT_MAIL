Public Class DataGridViewBarGraphColumn
    Inherits DataGridViewColumn
    Public MaxValue As Long
    Private needsRecalc As Boolean = True
    Public Sub CalcMaxValue()
    End Sub

End Class
