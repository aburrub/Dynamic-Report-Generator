Public Class drg_filter_remove
    Private _filters As List(Of String) = Nothing
    Private Sub drg_filter_remove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me._filters Is Nothing Then
            Me.ComboBox1.Items.AddRange(Me._filters.ToArray)
        End If
    End Sub

    Public Property FILTERS As List(Of String)
        Set(ByVal value As List(Of String))
            Me._filters = value
        End Set
        Get
            Return Me._filters
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Me.ComboBox1.SelectedItem Is Nothing Then
            Me._filters.Remove(Me.ComboBox1.SelectedItem.ToString)
        End If
        Me.Close()
    End Sub

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub
End Class