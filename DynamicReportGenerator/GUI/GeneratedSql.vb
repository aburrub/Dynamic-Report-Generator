Public Class GeneratedSql
    Private sqlStatement As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GeneratedSql_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.generatedSql_TextBox.Text = sqlStatement
    End Sub

    Public Property SQL() As String
        Set(ByVal value As String)
            Me.sqlStatement = value
        End Set
        Get
            Return Me.sqlStatement
        End Get
    End Property

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub
End Class