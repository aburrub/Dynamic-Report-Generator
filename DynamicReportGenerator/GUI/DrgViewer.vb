Imports Devart.Data.PostgreSql

Public Class DrgViewer
    Private current_sql As String = ""
    Private dbms As String = "Access"
    Private connection As Object = Nothing
    Private ds As New DataSet

  
    Private Sub DrgViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each local As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
            Me.ComboBox1.Items.Add(local.Name)
        Next

        Dim th As New Threading.Thread(AddressOf HomeScreen.runTh) : th.Start()
        Select Case Me.dbms
            Case "Access"
                viewDataForAccess()
            Case "PostgreSql"
                viewDataForPostgresql()
        End Select
        th.Abort()
    End Sub



    Private Sub viewDataForAccess()
        Dim accessConnection = CType(Me.connection, OleDb.OleDbConnection)
        Dim cmd As New OleDb.OleDbCommand(Me.current_sql, accessConnection)
        ds.Clear()
        Dim adp As New OleDb.OleDbDataAdapter(cmd)
        adp.Fill(ds)

        Me.viewer_DataGridView.DataSource = ds.Tables(0)

    End Sub

    Private Sub viewDataForPostgresql()
        Dim pgsqlConnection = CType(Me.connection, Devart.Data.PostgreSql.PgSqlConnection)
        Dim cmd As New Devart.Data.PostgreSql.PgSqlCommand(Me.current_sql, pgsqlConnection)

        ds.Clear()
        Dim adp As New PgSqlDataAdapter(cmd)
        adp.Fill(ds)
        Me.viewer_DataGridView.DataSource = ds.Tables(0)

    End Sub

    Public Property sql() As String
        Set(ByVal value As String)
            Me.current_sql = value
        End Set
        Get
            Return Me.current_sql
        End Get
    End Property
    Public Property DatabaseManagementSystem() As String
        Set(ByVal value As String)
            Me.dbms = value
        End Set
        Get
            Return Me.dbms
        End Get
    End Property
    Public Sub setConnection(ByVal conn As Object)
        Me.connection = conn
    End Sub
    Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Me.Close()
    End Sub


    Private Sub ExcelFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelFileToolStripMenuItem.Click
        Me.SaveFileDialog1.Filter = "(*.xls)|*.xls|All files (*.*)|*.*"
        Me.SaveFileDialog1.FileName = "rep" + getRepDateName()
        Me.SaveFileDialog1.ShowDialog()
        Dim th As New Threading.Thread(AddressOf HomeScreen.runTh) : th.Start()
        '  exp.exportToExcel("Report", Me.SaveFileDialog1.FileName, Me.viewer_DataGridView)
        exp.ExportToExcel_FastMode(Me.ds, Me.SaveFileDialog1.FileName)
        th.Abort()
    End Sub
    
    Private Function getRepDateName() As String
        Dim d As Date = Date.Now
        Try
            Return d.Year.ToString + d.Month.ToString + d.Day.ToString + d.Hour.ToString + d.Minute.ToString + d.Second.ToString + d.Millisecond.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not Me.ComboBox1.SelectedItem Is Nothing Then
            Dim pgsqlConnection = CType(Me.connection, Devart.Data.PostgreSql.PgSqlConnection)
            Dim cmd As New Devart.Data.PostgreSql.PgSqlCommand(Me.current_sql, pgsqlConnection)

            ds.Clear()
            Dim adp As New PgSqlDataAdapter(cmd)
            adp.Fill(ds)

            'ds.Locale = New System.Globalization.CultureInfo("ar")
            'ds.Locale = New System.Globalization.CultureInfo(Me.ComboBox1.SelectedItem.ToString)

            Me.viewer_DataGridView.DataSource = ds.Tables(0)
        End If
    End Sub
End Class