Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Devart.Data.PostgreSql

Public Class Form1
    Private aliases As New Hashtable

    Private selectAllNodes As Boolean = True
    Private isGenerated As Boolean = False
    Private currentSql As String = ""
    Private db_tables As Hashtable
    Private all_db_tables As Hashtable
    Private access_connection As OleDb.OleDbConnection
    Private pgsql_connection As PgSqlConnection
    Private mdb_path As String
    Private db As String = ""
    Private _connectionString As String
    Private _username As String
    Private _password As String
    Private _port As String
    Private _host As String
    Private _dbname As String
    Private currentNode As TreeNode = Nothing
    Private _filters As New List(Of String)
    Public Sub New()
        If (db_tables Is Nothing) Then
            Me.db_tables = New Hashtable
        End If
        If (all_db_tables Is Nothing) Then
            Me.all_db_tables = New Hashtable
        End If
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setDefaults()
        appendReportsToMenu(ReportsToolStripMenuItem)
        consts.MAIN_PROJECT_IS_CONNECTED = False

    End Sub

    Public Sub begin()
        Dim connStr As String = "Data Source=YASER-PC\SQLSERVER;Initial Catalog=tdb;Integrated Security=True"

        Dim conn As New SqlConnection(connStr)
        Dim conn2 As New SqlClient.SqlConnection
        'onn2.get()


        Try
            conn.Open()


            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Me.Close()
    End Sub
    Public Sub begin_access()
        Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Yaser\Desktop\testDB\db1.accdb;Persist Security Info=False"
        ' Dim connStr As String = "Data Source=YASER-PC\SQLSERVER;Initial Catalog=tdb;Integrated Security=True"
        Dim conn As New OleDb.OleDbConnection(connStr)
        'Dim conn As New SqlConnection(connStr)

        Try
            conn.Open()

            ' Set Tables in hash
            access_controller.setTablesInHash(conn, Me.db_tables)

            ' set fields for each table in db
            For Each table As String In access_controller.getTables(conn)
                access_controller.setTableFieldsInHash(conn, Me.db_tables, table)
            Next

            ' set foreign keys 
            access_controller.setForeginKeys(conn, Me.db_tables)



            'MsgBox(checkIfColumnIsPrimaryKey("id", "student", conn))
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Me.Close()
    End Sub
    Private Sub runTh()
        StopWatch.ShowDialog()
    End Sub

    Private Sub connect_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connect_Button.Click     
        Dim th As New Threading.Thread(AddressOf runTh)
        Me.db_TreeView.Nodes.Clear()
        Me.db = Me.database_ComboBox.SelectedItem.ToString
        consts.MAIN_PROJECT_DBMS = Me.db
        Me.aliases.Clear()
        Try
            Select Case Me.db
                Case "Access"
                    Me.access_connection = New OleDb.OleDbConnection(consts.DEFAULT_ACCESS_CONNECTION_STRING.Replace("?CURRENT_ACCESS_FILE_PATH?", Me.mdb_path))
                    consts.MAIN_PROJECT_IS_CONNECTION_SET = True
                    consts.MAIN_PROJECT_ACCESS_CONNECTION = Me.access_connection
                    Try
                        Me.access_connection.Open()
                        Me._connectionString = Me.access_connection.ConnectionString
                        Me.connection_status_Label.Text = "Connected"
                        HomeScreen.setAccessDatabaseTreeView(Me.db_TreeView, Me.access_connection)
                        Me.all_db_tables.Clear()
                        access_controller.begin_access_all_db_tables(Me.access_connection, Me.all_db_tables)
                    Catch ex As Exception
                        Me.connection_status_Label.Text = "Error in Connection"
                    Finally
                        Me.access_connection.Close()
                    End Try

                Case "PostgreSql"
                    Try
                        Dim all_tables() As String
                        Dim connector As New dbConnector()
                        connector.ShowDialog()
                        ' set these variables in order to save them in xml file
                        Me._password = connector.password_TextBox.Text
                        Me._username = connector.user_TextBox.Text
                        Me._host = connector.host_TextBox.Text
                        Me._dbname = connector.db_name_TextBox.Text
                        Me._connectionString = connector.CONNECTION_STRING
                        th.Start()
                        Dim connStr As String = connector.CONNECTION_STRING
                        Me.pgsql_connection = New PgSqlConnection(connector.CONNECTION_STRING)
                        consts.MAIN_PROJECT_IS_CONNECTION_SET = True
                        consts.MAIN_PROJECT_PGSQL_CONNECTION = Me.pgsql_connection
                        Me.pgsql_connection.Open()
                        Me.connection_status_Label.Text = "Connected"
                        all_tables = HomeScreen.setPgSqlDatabaseTreeView(Me.db_TreeView, Me.pgsql_connection)
                        Me.all_db_tables.Clear()
                        pgsql_controller.begin_pgsql_all_db_tables(Me.pgsql_connection, Me.all_db_tables, all_tables)

                    Catch ex As Exception
                        Me.connection_status_Label.Text = "Error in Connection"
                    Finally
                        th.Abort()
                        Me.pgsql_connection.Close()
                    End Try


            End Select
        Catch ex As Exception
            Me.connection_status_Label.Text = "Error in Connection"

        End Try


    End Sub

    Private Sub database_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles database_ComboBox.SelectedIndexChanged
        Me.connection_status_Label.Text = ""
        Select Case (Me.database_ComboBox.SelectedIndex)
            Case 1 ' "access"
                Me.browse_Button.Visible = True

            Case Else
                Me.browse_Button.Visible = False
        End Select
    End Sub

    Private Sub browse_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browse_Button.Click
        Me.OpenFileDialog1.Filter = "(*.accdb)|*.accdb|(*.mdb)|*.mdb|All files (*.*)|*.*"
        Me.OpenFileDialog1.ShowDialog()
        Me.mdb_path = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub setDefaults()
        HomeScreen.setDatabaseComboboxDefaultValues(Me.database_ComboBox)
        '    
    End Sub

    Public Shared Sub appendReportsToMenu(ByRef ctrl As ToolStripMenuItem)
        RemoveHandler ctrl.DropDownItemClicked, AddressOf GenerateSavedReport
        AddHandler ctrl.DropDownItemClicked, AddressOf GenerateSavedReport
        Dim h As Hashtable = xmlLib.getCategories(consts.MY_SETTINGS_OUTPUT_FILE)
        For Each key As String In h.Keys
            Dim tsm As New ToolStripMenuItem(key)
            tsm.Font = New Font("Tahoma", 9.75, FontStyle.Bold)
            tsm.ForeColor = Color.Green
            If Not key = "root" Then
                For Each itm As Report In h(key)
                    Dim tsm_item As New ToolStripMenuItem(itm.NAME)
                    tsm_item.Font = New Font("Tahoma", 9.75, FontStyle.Bold)
                    tsm_item.ForeColor = Color.Green
                    tsm.DropDownItems.Add(tsm_item)
                Next
                ctrl.DropDownItems.Add(tsm)
                RemoveHandler tsm.DropDownItemClicked, AddressOf GenerateSavedReport
                AddHandler tsm.DropDownItemClicked, AddressOf GenerateSavedReport
            End If

        Next
        If Not h("root") Is Nothing Then
            For Each itm As Report In h("root")
                Dim tsm_item As New ToolStripMenuItem(itm.NAME)
                tsm_item.Font = New Font("Tahoma", 9.75, FontStyle.Bold)
                tsm_item.ForeColor = Color.Green
                ctrl.DropDownItems.Add(tsm_item)
            Next
        End If
    End Sub

    Private Sub db_TreeView_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles db_TreeView.AfterCheck
        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next
    End Sub

    Private Function GenerateSqlFromTreeView(ByRef tvCtrl As TreeView, ByRef db_tables As Hashtable, ByVal selectedItems() As String, ByVal dbms As String) As String
        Dim sql As String = ""
        Dim condStr As String = ""
        Try


            Dim connectedTables As New List(Of String)
            If db_tables.Keys.Count >= 2 Then
                condStr = sharedfunc.GenerateSqlWhereCondition(selectedItems, db_tables, connectedTables)
            Else
                connectedTables.Add(selectedItems(0))
            End If

            Dim ext As String = ""
            Dim tables As New Hashtable
            Dim cols As New List(Of String)

            For Each node As TreeNode In tvCtrl.Nodes
                If utilFunc.findInArray(connectedTables, node.Text) Then
                    ext = CType(db_tables(node.Text), dbtable).tableExtension
                    setsqlColumns(node, ext, cols)
                    tables.Add(ext, node.Text)
                End If
            Next
            sql = "SELECT "
            For Each col As String In cols
                sql = sql + If(dbms <> "Access", col, If(utilFunc.hasNotAlphnumericChars(col), "[" + col + "]", col)) + ", "
            Next
            sql = sql.Substring(0, sql.LastIndexOf(","))
            sql = sql + Environment.NewLine + " FROM "
            For Each key As String In tables.Keys
                If utilFunc.findInArray(connectedTables, tables(key).ToString) Then
                    sql = sql + If(dbms <> "Access", tables(key).ToString, If(utilFunc.hasNotAlphnumericChars(tables(key).ToString), "[" + tables(key).ToString + "]", tables(key).ToString)) + " " + key + ","

                End If
            Next
            sql = sql.Substring(0, sql.LastIndexOf(","))
        Catch ex As Exception
            sql = ""
        End Try
        condStr = addFiltersToSql(condStr)
        sql = sql + condStr

        Return sql
    End Function
    Private Function addFiltersToSql(ByVal conds As String) As String
        Dim filter_sql As String = ""
        If Me._filters.Count = 0 Then
            Return conds
        Else
            For Each Filter As String In Me._filters
                filter_sql = filter_sql + Filter + " AND "
            Next
        End If
        filter_sql = filter_sql.Substring(0, filter_sql.LastIndexOf(" AND "))
        Return If(conds = "", " WHERE " + filter_sql, conds + " AND " + filter_sql)
    End Function
    Private Function checkIfTreeNodeHasCheckedChildItem(ByRef tn As TreeNode) As Boolean
        For Each node As TreeNode In tn.Nodes
            If node.Checked Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub setsqlColumns(ByRef tn As TreeNode, ByVal ext As String, ByRef cols As List(Of String))
        Dim key As String = ""
        Dim valu As String = ""
        For Each node As TreeNode In tn.Nodes
            If node.Checked Then
                key = tn.Text + "=>" + node.Text
                valu = Me.aliases(key)
                If valu Is Nothing Then
                    cols.Add(ext + "." + node.Text)
                Else
                    cols.Add(ext + "." + node.Text + valu)
                End If

            End If
        Next
    End Sub
    Private Sub Generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generate_Button.Click
        Dim th As New Threading.Thread(AddressOf runTh) : th.Start()
        Me.isGenerated = False
        Select Case Me.db
            Case "Access"
                Try
                    Me.access_connection.Open()
                    Me.db_tables.Clear()
                    Dim selectedItems() As String = getSelectedTables(Me.db_TreeView)


                    Dim res As Boolean = access_controller.begin_access_selected(Me.access_connection, Me.db_tables, selectedItems)

                    If res Then
                        Me.currentSql = GenerateSqlFromTreeView(Me.db_TreeView, Me.db_tables, selectedItems, Me.db)
                        Me.isGenerated = True
                        Me.connection_status_Label.Text = "Report is Generated"
                        Me._filters.Clear()
                    Else
                        Me.connection_status_Label.Text = "No Relation"
                    End If

                Catch ex As Exception
                Finally
                    Me.access_connection.Close()
                End Try



            Case "PostgreSql"
                Try
                    Me.pgsql_connection.Open()
                    Me.db_tables.Clear()
                    Dim selectedItems() As String = getSelectedTables(Me.db_TreeView)


                    Dim res As Boolean = pgsql_controller.begin_pgsql_selected(Me.pgsql_connection, Me.db_tables, selectedItems)

                    If res Then
                        Me.currentSql = GenerateSqlFromTreeView(Me.db_TreeView, Me.db_tables, selectedItems, Me.db)
                        Me.isGenerated = True
                        Me.connection_status_Label.Text = "Report is Generated"
                        Me._filters.Clear()
                    Else
                        Me.connection_status_Label.Text = "No Relation"
                    End If

                Catch ex As Exception
                Finally
                    Me.pgsql_connection.Close()
                End Try

        End Select

        th.Abort()

    End Sub

    Private Function getSelectedTables(ByRef tvCtrl As TreeView) As String()
        Dim tmp As New List(Of String)
        Dim tmp_final As New List(Of String)
        Dim result As New List(Of String)
        For Each tn As TreeNode In tvCtrl.Nodes
            If (checkIfTreeNodeHasCheckedChildItem(tn)) Then
                result.Add(tn.Text)
            End If
        Next
        ' this should be called if we don't have direct relation between tables 
        For i As Integer = 0 To result.Count - 1
            For j As Integer = i + 1 To result.Count - 1
                tmp.Clear() : tmp_final.Clear()
                If Not HomeScreen.doesTablesHasRelation(all_db_tables(result.Item(i)), all_db_tables(result.Item(j))) Then
                    sharedfunc.buildTreeFromDB(all_db_tables(result.Item(i)), all_db_tables(result.Item(j)), tmp, tmp_final)
                    For Each additionalTable As String In tmp_final
                        utilFunc.addWithoutDuplication(additionalTable, result)
                    Next
                End If

            Next
        Next

        Return If(result Is Nothing Or result.Count = 0, Nothing, result.ToArray)
    End Function


    Private Sub selUnSelLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selUnSelLabel.Click
        sharedfunc.SelectUnselectAllTreeViewNodes(Me.db_TreeView, Me.selectAllNodes)
        Me.selectAllNodes = Not Me.selectAllNodes
        If selectAllNodes Then
            CType(sender, Label).Text = "Select All Nodes"
        Else
            CType(sender, Label).Text = "Unselect All Nodes"
        End If

    End Sub

    Private Sub GeneratedSqlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneratedSqlToolStripMenuItem.Click
        GeneratedSql.SQL = Me.currentSql
        GeneratedSql.ShowDialog()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        Dim curForm As New DrgViewer
        If Me.isGenerated Then
            Select Case Me.db
                Case "Access"
                    DrgViewer.sql = Me.currentSql
                    DrgViewer.DatabaseManagementSystem = Me.db
                    DrgViewer.setConnection(Me.access_connection)
                    DrgViewer.ShowDialog()
                    Me.isGenerated = True
                Case "PostgreSql"
                    Try
                        Me.pgsql_connection.Open()
                        curForm.sql = Me.currentSql
                        curForm.DatabaseManagementSystem = Me.db
                        curForm.setConnection(Me.pgsql_connection)
                        curForm.ShowDialog()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Me.pgsql_connection.Close()
                    End Try

            End Select
        End If
    End Sub

    Private Sub AddToReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToReportsToolStripMenuItem.Click
        If Me.isGenerated Then
            Dim addRep As New addReport
            addRep.SQL = Me.currentSql
            addRep.DBMS = consts.MAIN_PROJECT_DBMS
            addRep.PASSWORD = Me._password
            addRep.USERNAME = Me._username
            addRep.HOST = Me._host
            addRep.DBNAME = Me._dbname
            addRep.PORT = Me._port
            addRep.CONNECTION_STRING = Me._connectionString
            addRep.ShowDialog()
            ReportsToolStripMenuItem.DropDownItems.Clear()
            appendReportsToMenu(ReportsToolStripMenuItem)
        Else
            MsgBox(" error in report")
        End If
    End Sub

    Private Sub RemoveReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveReportToolStripMenuItem.Click
        removeReport.ShowDialog()
        ReportsToolStripMenuItem.DropDownItems.Clear()
        appendReportsToMenu(ReportsToolStripMenuItem)
    End Sub
    

    Public Shared Sub GenerateSavedReport(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Dim report As Report = xmlLib.getReportDetails(e.ClickedItem.Text, consts.MY_SETTINGS_OUTPUT_FILE)
        Select Case report.dbms
            Case "Access"
                Dim drg As New DrgViewer
                Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection(report.CONNECTION_STRING)
                con.Open()
                drg.DatabaseManagementSystem = "Access"
                drg.sql = report.SQL
                drg.setConnection(con)
                drg.ShowDialog()
                con.Close()

            Case "PostgreSql"
                Dim drg As New DrgViewer
                Dim con As PgSqlConnection = New PgSqlConnection(report.CONNECTION_STRING)
                con.Open()
                drg.DatabaseManagementSystem = "PostgreSql"
                drg.sql = report.SQL
                drg.setConnection(con)
                drg.ShowDialog()
                con.Close()

        End Select


    End Sub

    Public ReadOnly Property CONNECTIONSTRING() As String
        Get
            Return Me._connectionString
        End Get
    End Property

    Public Property DatabaseManagementSystem() As String
        Set(ByVal value As String)
            Me.db = value
        End Set
        Get
            Return Me.db
        End Get
    End Property


    Private Sub EditReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditReportsToolStripMenuItem.Click
        Dim editRep As New editReports()
        editRep.ShowDialog()
        ReportsToolStripMenuItem.DropDownItems.Clear()
        appendReportsToMenu(ReportsToolStripMenuItem)
    End Sub

    Private Sub db_TreeView_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles db_TreeView.MouseUp
        Try
            Me.currentNode = db_TreeView.SelectedNode
            If e.Button = MouseButtons.Right And Not Me.currentNode.Parent Is Nothing Then
                rMenuContextMenuStrip.Show(Me.db_TreeView, e.X, e.Y)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AddColumnAliasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddColumnAliasToolStripMenuItem.Click
        Dim aliasTag As String = InputBox("Enter New Column Name", "Change Column Name", If(Me.currentNode Is Nothing, "", Me.currentNode.Text))
        Dim key As String = Me.currentNode.Parent.Text + "=>" + Me.currentNode.Text
        If Me.aliases(key) Is Nothing Then
            Me.aliases.Add(key, " AS """ + aliasTag + """")
        Else
            MsgBox("Already Added")
        End If

    End Sub
    ' extension should be saved
    Private Sub AddFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFilterToolStripMenuItem.Click
        If Not checkIfTreeNodeHasCheckedChildItem(Me.currentNode.Parent) Then
            MsgBox("At least one column from table[" + Me.currentNode.Parent.Text + "] should be checked")
        Else
            Dim tbl As String = Me.currentNode.Parent.Text
            Dim col As String = Me.currentNode.Text

            Dim filterDialog As New drg_filters
            Select Case Me.db
                Case "PostgreSql"
                    filterDialog.setConnection(Me.pgsql_connection)
                    filterDialog.TABLE = tbl
                    filterDialog.COLUMN = col
                    filterDialog.DBMS = Me.db
                    filterDialog.EXTENSION = tbl
                    filterDialog.ShowDialog()
                    If Not filterDialog.FILTER = "" Then
                        Me._filters.Add(filterDialog.FILTER)
                    End If

            End Select
        End If

       
    End Sub

    Private Sub RemoveFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFilterToolStripMenuItem.Click
        If Me._filters.Count = 0 Then
            MsgBox("No, Fitlers are found")
        Else
            Dim removeFiltersForm As New drg_filter_remove
            removeFiltersForm.FILTERS = Me._filters
            removeFiltersForm.ShowDialog()
            Me._filters = removeFiltersForm.FILTERS
        End If

    End Sub

 
    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub

    
End Class
