Public Class DoStuffClass
    Dim mCounterInterger As Integer
    Dim mStartInteger As Integer

    'declare our event 
    Public Event OnProgress(ByVal theCountInteger As Integer)

    Public Property StartValue() As Integer
        Get
            Return mStartInteger
        End Get
        Set(ByVal Value As Integer)
            If (Value < 10000) And (Value >= 0) Then
                mStartInteger = Value
            Else
                mStartInteger = 10000
            End If
        End Set
    End Property
    Public Sub New()
        mStartInteger = 1
    End Sub
    Public Sub CountLoop()
        Dim Xinteger As Integer
        Dim IndexInteger As Integer
        For IndexInteger = mStartInteger To 10000
            Xinteger += 1
            CPU_Eater() 'chew up some machine cycles 
            If Xinteger Mod 10 = 0 Then
                'Every 10 interations of our loop trigger the event 
                RaiseEvent OnProgress(CType(Xinteger / 100, Integer))
            End If
        Next
    End Sub
    Private Sub CPU_Eater()

        Dim IndexInteger As Integer
        Dim CountInteger As Integer

        'on a fast computer terminal integer may need another zero 
        Dim TerminalInteger As Integer = 10000

        For IndexInteger = 1 To TerminalInteger
            CountInteger += 1
        Next
    End Sub
End Class

