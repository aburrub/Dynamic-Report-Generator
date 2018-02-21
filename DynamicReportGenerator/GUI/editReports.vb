Public Class editReports
    Private oldName As New List(Of String)
    Private Sub editReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.reports_DataGridView.Columns.Clear()
        Me.reports_DataGridView.Rows.Clear()
        xmlLib.fillGridByXmlReports(Me.reports_DataGridView, consts.MY_SETTINGS_OUTPUT_FILE)
        For i As Integer = 0 To Me.reports_DataGridView.Rows.Count - 2
            oldName.Add(Me.reports_DataGridView.Rows(i).Cells(0).Value.ToString)
        Next
        For Each row As DataGridViewRow In Me.reports_DataGridView.Rows
            ' oldName.Add(row.Cells(0).Value.ToString)
        Next
    End Sub

    Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Me.Close()
    End Sub

    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        If checkIfWeHaveReportsWithTheSameName() Then
            MsgBox("Some reports have the same name")
        Else
            xmlLib.removeAllReports(consts.MY_SETTINGS_OUTPUT_FILE)
            Dim dec As String = ""
            Dim row As DataGridViewRow
            For i As Integer = 0 To Me.reports_DataGridView.Rows.Count - 2
                row = Me.reports_DataGridView.Rows(i)
                dec = Enc.Decrypt(row.Cells(3).Value.ToString, oldName.Item(i))
                xmlLib.addReportToXmlFile(row.Cells(0).Value.ToString, row.Cells(1).Value.ToString, row.Cells(2).Value.ToString, dec, row.Cells(4).Value.ToString, consts.MY_SETTINGS_OUTPUT_FILE)

            Next
            Me.Close()
        End If
   

    
    End Sub
    Private Function checkIfWeHaveReportsWithTheSameName() As Boolean
        Dim result As New List(Of String)
        Dim row As DataGridViewRow
        For i As Integer = 0 To Me.reports_DataGridView.Rows.Count - 2
            row = Me.reports_DataGridView.Rows(i)
            If utilFunc.findInArray(result.ToArray, row.Cells(0).Value.ToString) Then
                Return True
            End If
            result.Add(row.Cells(0).Value.ToString)
        Next
        Return False
    End Function


End Class