Public Class StopWatch

    Dim i As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        i = i + 1
        '    If frmStopwatch.ThreadStatus = 2 Then
        Me.Text = "Loading" + AnimateThreePoints(i)
        '  End If
        Me.Label1.Text = "(" + i.ToString + ") Seconds"
    End Sub

    Private Sub StopWatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        i = 0
        Me.Text = "Loading" + AnimateThreePoints(i)
    End Sub

    Private Function AnimateThreePoints(ByVal i As Integer) As String
        Select Case i Mod 4
            Case 0
                Return "."
            Case 1
                Return "..."
            Case 2
                Return "....."
            Case 3
                Return "......."
        End Select
        Return ""
    End Function
End Class