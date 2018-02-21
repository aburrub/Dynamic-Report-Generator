Imports Devart.Data.PostgreSql
Public Class drg_filters
    Private _column As String
    Private _table As String
    Private connection As Object
    Private _dbms As String = ""
    Private _ext As String = ""
    Private firstLoad As Boolean = True
    Private _filter As String
    Private operations As New Dictionary(Of String, String)
    Private filteredValues As New List(Of String)

    Private currentreeNode As TreeNode = Nothing
    Private treeItems As New List(Of TreeNode)

    Private Const EQUAL_MESSAGE As String = "Equal"
    Private Const NOT_EQUAL_MESSAGE As String = "Not Equal"
    Private Const MULTIPLE_MESSAGE As String = "Multiple Values"
    Private Sub drg_filters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = Me.Label1.Text.Replace("REPLACED_VAL", Me._column)
        Me.aggr_CheckBox.Checked = False
        Me.aggr_TreeView.Enabled = False
        Me.aggr_ComboBox.Enabled = False
        Me.operations.Add(EQUAL_MESSAGE, "=")
        Me.operations.Add(NOT_EQUAL_MESSAGE, "<>")
        Me.operations.Add(MULTIPLE_MESSAGE, "in")

        For Each key As String In Me.operations.Keys
            Me.operation_ComboBox.Items.Add(key)
        Next
        Me.operation_ComboBox.SelectedIndex = 0
    End Sub
    Private Sub fillComboBox()
        Me.aggr_ComboBox.Items.Clear()

        Dim sql As String = "SELECT DISTINCT " + Me._column + " FROM " + Me._table

        Select Case DBMS
            Case "PostgreSql"
                Dim conn As PgSqlConnection = CType(Me.connection, PgSqlConnection)
                Try
                    conn.Open()
                    Dim cmd As New PgSqlCommand(sql, conn)
                    Dim r As PgSqlDataReader = cmd.ExecuteReader
                    While r.Read
                        Me.aggr_ComboBox.Items.Add(r.Item(0).ToString)
                    End While

                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
        End Select
    End Sub
    Private Sub fillTreeNode()
        Me.aggr_TreeView.Nodes.Clear()

        Dim sql As String = "SELECT DISTINCT " + Me._column + " FROM " + Me._table

        Select Case DBMS
            Case "PostgreSql"
                Dim conn As PgSqlConnection = CType(Me.connection, PgSqlConnection)
                Try
                    conn.Open()
                    Dim cmd As New PgSqlCommand(sql, conn)
                    Dim r As PgSqlDataReader = cmd.ExecuteReader
                    While r.Read
                        Me.aggr_TreeView.Nodes.Add(r.Item(0).ToString)
                    End While

                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
        End Select
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aggr_CheckBox.CheckedChanged
        If Me.firstLoad Then
            Me.firstLoad = False
            Me.fillComboBox()
            Me.fillTreeNode()
        End If

        Me.aggr_ComboBox.Enabled = Me.aggr_CheckBox.Checked
        Me.aggr_TreeView.Enabled = Me.aggr_CheckBox.Checked
    End Sub

    Public Sub setConnection(ByVal Conn As Object)
        Me.connection = Conn
    End Sub

    Public Property COLUMN() As String
        Get
            Return Me._column
        End Get
        Set(ByVal value As String)
            Me._column = value
        End Set
    End Property

    Public Property TABLE() As String
        Get
            Return Me._table
        End Get
        Set(ByVal value As String)
            Me._table = value
        End Set
    End Property

    Public Property DBMS() As String
        Get
            Return Me._dbms
        End Get
        Set(ByVal value As String)
            Me._dbms = value
        End Set
    End Property

    Private Function setFilterValue() As String
        Dim res As String = ""
        If Me.filteredValues.Count = 0 Then
            Me.TextBox1.Text = ""
            Return ""
        ElseIf Me.filteredValues.Count = 1 Then
            Me.TextBox1.Text = Me.filteredValues(0)
            Return Me._ext + "." + Me._column + " " + Me.operations(Me.operation_ComboBox.SelectedItem.ToString) + "'" + Me.aggr_ComboBox.SelectedItem.ToString + "'"
        Else
            res = Me._ext + "." + Me._column + " " + Me.operations(Me.operation_ComboBox.SelectedItem.ToString)
            Me.TextBox1.Text = " ("
            For Each v As String In Me.filteredValues
                Me.TextBox1.Text = Me.TextBox1.Text + "'" + v + "',"
            Next
            Me.TextBox1.Text = Me.TextBox1.Text.Substring(0, Me.TextBox1.Text.LastIndexOf(","))
            Me.TextBox1.Text = Me.TextBox1.Text + ")"
            Return res + Me.TextBox1.Text
        End If
    End Function
    Private Function setFilterValue_tn() As String
        Dim res As String = ""
        If Me.treeItems.Count = 0 Then
            Me.TextBox1.Text = ""
            Return ""

        ElseIf Me.treeItems.Count = 1 Then
            Me.TextBox1.Text = Me.treeItems(0).Text
            If Me.operations(Me.operation_ComboBox.SelectedItem.ToString).ToLower = "in" Then
                Return Me._ext + "." + Me._column + " " + Me.operations(Me.operation_ComboBox.SelectedItem.ToString) + " ('" + Me.treeItems(0).Text + "')"
            Else
                Return Me._ext + "." + Me._column + " " + Me.operations(Me.operation_ComboBox.SelectedItem.ToString) + "'" + Me.treeItems(0).Text + "'"
            End If

        Else
            res = Me._ext + "." + Me._column + " " + Me.operations(Me.operation_ComboBox.SelectedItem.ToString)
            Me.TextBox1.Text = " ("
            For Each n As TreeNode In Me.treeItems
                Me.TextBox1.Text = Me.TextBox1.Text + "'" + n.Text + "',"
            Next

            Me.TextBox1.Text = Me.TextBox1.Text.Substring(0, Me.TextBox1.Text.LastIndexOf(","))
            Me.TextBox1.Text = Me.TextBox1.Text + ")"
            Return res + Me.TextBox1.Text
        End If
    End Function
    
    Public Property EXTENSION() As String
        Get
            Return Me._ext
        End Get
        Set(ByVal value As String)
            Me._ext = value
        End Set
    End Property

    Public Property FILTER() As String
        Get
            Return Me._filter
        End Get
        Set(ByVal value As String)
            Me._filter = value
        End Set
    End Property


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged        
    End Sub

    Private Sub cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_Button.Click
        Me._filter = ""
        Me.Close()
    End Sub

    Private Sub ok_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok_Button.Click
        Me.Close()
    End Sub

    Private Sub clear_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_Button.Click
        Me.filteredValues.Clear()
        Me.TextBox1.Text = ""
    End Sub

    Private Function addNodeWithoutReplication(ByRef items As List(Of String), ByVal itm As String)
        For Each item As String In items
            If item = itm Then
                Return False
            End If
        Next
        items.Add(itm)
        Return True
    End Function

    Private Function addNodeWithoutReplication(ByRef items As List(Of TreeNode), ByVal itm As TreeNode)
        For Each item As TreeNode In items
            If item.Text = itm.Text Then
                Return False
            End If
        Next
        items.Add(itm)
        Return True
    End Function

    Private Sub aggr_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aggr_ComboBox.SelectedIndexChanged
        If Not Me.operation_ComboBox.SelectedItem Is Nothing Then
            If Not Me.operation_ComboBox.Text Is Nothing Then
                Select Case Me.operation_ComboBox.Text
                    Case EQUAL_MESSAGE, NOT_EQUAL_MESSAGE
                        filteredValues.Clear()
                        addNodeWithoutReplication(Me.filteredValues, Me.aggr_ComboBox.SelectedItem.ToString)

                    Case MULTIPLE_MESSAGE
                        addNodeWithoutReplication(Me.filteredValues, Me.aggr_ComboBox.SelectedItem.ToString)
                End Select
            End If



            Me._filter = setFilterValue()
        End If


    End Sub

    Private Function findNode(ByRef nodes As List(Of TreeNode), ByVal cn As TreeNode) As Boolean
        For Each node As TreeNode In nodes
            If node.Text = cn.Text Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function RemoveNode(ByRef nodes As List(Of TreeNode), ByVal cn As TreeNode) As Boolean
        For Each node As TreeNode In nodes
            If node.Text = cn.Text Then
                nodes.Remove(node)
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub aggr_TreeView_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles aggr_TreeView.AfterCheck
        Dim checked As Boolean = e.Node.Checked

        If findNode(Me.treeItems, e.Node) And Not checked Then
            Me.RemoveNode(Me.treeItems, e.Node)

        ElseIf Not findNode(Me.treeItems, e.Node) Then
            Me.treeItems.Add(e.Node)
        End If
        Me.currentreeNode = e.Node
        Me._filter = setFilterValue_tn()

    End Sub


    Private Sub operation_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operation_ComboBox.SelectedIndexChanged
        If Not Me.operation_ComboBox.SelectedItem Is Nothing Then
            Select Case Me.operation_ComboBox.SelectedItem.ToString
                Case EQUAL_MESSAGE, NOT_EQUAL_MESSAGE
                    Me.aggr_ComboBox.Visible = True
                    Me.aggr_ComboBox.Enabled = aggr_CheckBox.Checked
                    Me.aggr_TreeView.Visible = False
                    Me.aggr_ComboBox.Location = New Point(18, 240)
                Case MULTIPLE_MESSAGE
                    Me.aggr_ComboBox.Visible = False
                    Me.aggr_TreeView.Visible = True
                    Me.aggr_TreeView.Enabled = aggr_CheckBox.Checked
                    Me.aggr_TreeView.Location = New Point(18, 240)
            End Select
        End If
    End Sub

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub
End Class