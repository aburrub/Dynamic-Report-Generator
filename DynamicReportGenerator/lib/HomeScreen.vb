Imports Devart.Data.PostgreSql
Imports System.Xml
Public Class HomeScreen
    Public Shared Sub setDatabaseComboboxDefaultValues(ByRef comboObject As ComboBox)
        comboObject.Items.AddRange(consts.AVAILABLE_DATABASES.ToArray)
        comboObject.SelectedIndex = 0
    End Sub

    Public Shared Sub setAccessDatabaseTreeView(ByRef tvCtrl As TreeView, ByRef conn As OleDb.OleDbConnection)
        tvCtrl.CheckBoxes = True

        Dim tables() As String = access_controller.getTables(conn)
        'Array.Sort(tables)
        For Each table As String In tables
            Dim columns() As String = access_controller.getTableColumns(conn, table)
            '   Array.Sort(columns)
            Dim node As New TreeNode(table)
            For Each col As String In columns
                node.Nodes.Add(col)
            Next
            tvCtrl.Nodes.Add(node)
        Next
    End Sub
    'Optional ByRef db_tables As Hashtable = Nothing
    Public Shared Function doesTablesHasRelation(ByRef table1 As dbtable, ByRef table2 As dbtable, ByRef conds As List(Of String)) As Boolean
        Dim cond As String = ""
        If table1 Is Nothing Or table2 Is Nothing Then
            Return False
        End If
        'For Each fk As dbtable
        For Each fk As foreginKey In table1.FOREGINKEYS.Values
            If Not fk.PK_TABLE Is Nothing Then
                If fk.PK_TABLE.TableName = table2.TableName Then
                    cond = fk.FK_TALBE.tableExtension + "." + fk.FK_COLUMN + "=" + fk.PK_TABLE.tableExtension + "." + fk.PK_COLUMN
                    conds.Add(cond)
                    Return True
                End If
            End If

        Next

        For Each fk As foreginKey In table2.FOREGINKEYS.Values
            If Not fk.PK_TABLE Is Nothing Then
                If fk.PK_TABLE.TableName = table1.TableName Then
                    cond = fk.FK_TALBE.tableExtension + "." + fk.FK_COLUMN + "=" + fk.PK_TABLE.tableExtension + "." + fk.PK_COLUMN
                    conds.Add(cond)
                    Return True
                End If
            End If

        Next

        Return False
    End Function

    ' PGSQL FUNCTIONS --------------------------------------------------------------------
    Public Shared Function setPgSqlDatabaseTreeView(ByRef tvCtrl As TreeView, ByRef conn As PgSqlConnection) As String()
        tvCtrl.CheckBoxes = True

        Dim tables() As String = pgsql_controller.getTables(conn)
        'Array.Sort(tables)
        For Each table As String In tables
            Dim columns() As String = pgsql_controller.getTableColumns(conn, table)
            '   Array.Sort(columns)
            Dim node As New TreeNode(table)
            For Each col As String In columns
                node.Nodes.Add(col)
            Next
            tvCtrl.Nodes.Add(node)
        Next
        Return tables
    End Function

    Public Shared Sub runTh()
        StopWatch.ShowDialog()
    End Sub


    Public Shared Function doesTablesHasRelation(ByRef table1 As dbtable, ByRef table2 As dbtable) As Boolean
        If table1 Is Nothing Or table2 Is Nothing Then
            Return False
        End If
        'For Each fk As dbtable
        For Each fk As foreginKey In table1.FOREGINKEYS.Values
            If Not fk.PK_TABLE Is Nothing Then
                If fk.PK_TABLE.TableName = table2.TableName Then
                    Return True
                End If
            End If

        Next

        For Each fk As foreginKey In table2.FOREGINKEYS.Values
            If Not fk.PK_TABLE Is Nothing Then
                If fk.PK_TABLE.TableName = table1.TableName Then
                    Return True
                End If
            End If

        Next

        Return False
    End Function

End Class
