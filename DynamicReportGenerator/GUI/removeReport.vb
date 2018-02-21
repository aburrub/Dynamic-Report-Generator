Public Class removeReport
    
    Private Sub ok_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok_Button.Click
        For Each obj As Object In Me.rep_name_ListBox.SelectedItems
            xmlLib.removeReport(obj.ToString, consts.MY_SETTINGS_OUTPUT_FILE)

        Next
        Me.Close()
    End Sub

    Private Sub removeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rep_name_ListBox.Items.Clear()
        Me.rep_name_ListBox.Items.AddRange(xmlLib.getReportsNames(consts.MY_SETTINGS_OUTPUT_FILE))
        If Me.rep_name_ListBox.Items.Count >= 1 Then
            Me.rep_name_ListBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub
End Class