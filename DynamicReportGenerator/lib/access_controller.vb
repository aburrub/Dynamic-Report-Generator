Public Class access_controller
    Public Shared Sub begin(ByRef conn As OleDb.OleDbConnection, ByRef db_tables As Hashtable)
        ' Set Tables in hash
        setTablesInHash(conn, db_tables)

        ' set fields for each table in db
        For Each table As String In access_controller.getTables(conn)
            setTableFieldsInHash(conn, db_tables, table)
        Next

        ' set foreign keys 
        setForeginKeys(conn, db_tables)
    End Sub
    ' This is the first function to be called in access db
    Public Shared Function begin_access_selected(ByRef conn As OleDb.OleDbConnection, ByRef db_tables As Hashtable, ByVal selectedTables() As String) As Boolean


        ' Set Tables in hash
        setTablesInHash(conn, db_tables, selectedTables)

        ' set fields for each table in db
        For Each table As String In selectedTables
            setTableFieldsInHash(conn, db_tables, table)
        Next

        ' set foreign keys, just in case we have more than one table
        If (db_tables.Keys.Count >= 2) Then
            If setForeginKeys(conn, db_tables) Then
            Else
                Return False
            End If
        End If


        Return True
    End Function
    ' This is the first function to be called in access db
    Public Shared Function begin_access_all_db_tables(ByRef conn As OleDb.OleDbConnection, ByRef all_db_tables As Hashtable) As Boolean

        ' set all tables hash
        setTablesInHash(conn, all_db_tables)
        ' set fields for each table in all_db_tables
        For Each table As String In access_controller.getTables(conn)
            setTableFieldsInHash(conn, all_db_tables, table)

        Next

        ' set foreign keys for all_db_tables, just in case we have more than one table
        If (all_db_tables.Keys.Count >= 2) Then
            If setForeginKeys(conn, all_db_tables) Then
            Else
                Return False
            End If
        End If


        Return True
    End Function

    Public Shared Function checkIfColumnIsPrimaryKey(ByVal colName As String, ByVal tableName As String, ByRef conn As OleDb.OleDbConnection) As Boolean
        Dim rest(4) As String
        rest(4) = tableName
        Dim dt As DataTable = conn.GetSchema("indexes", rest)
        Dim res As String = ""
        For Each row As DataRow In dt.Rows
            If (colName.ToLower = row.ItemArray(17).ToString.ToLower) Then
                If (row.ItemArray(6).ToString.ToLower = "true") Then
                    Return True
                End If
            End If

        Next
        Return False
    End Function
    Public Shared Function getPrimaryKeys(ByRef conn As OleDb.OleDbConnection, ByVal includeTableNameWithPrimaryKey As Boolean) As String()
        Dim result As New List(Of String)
        Dim rest(4) As String
        For Each tableName As String In getTables(conn)
            rest(4) = tableName
            Dim dt As DataTable = conn.GetSchema("indexes", rest)
            For Each row As DataRow In dt.Rows
                If (row.ItemArray(6).ToString.ToLower = "true") Then
                    result.Add(If(includeTableNameWithPrimaryKey, row.ItemArray(17).ToString + "?" + tableName, row.ItemArray(17).ToString))
                End If
            Next
        Next
        Return If(result Is Nothing Or result.Count = 0, Nothing, result.ToArray)
    End Function


    Public Shared Function getTableColumns(ByRef conn As OleDb.OleDbConnection, ByVal tableName As String) As String()
        Return GetFromSchema(conn, "Columns", 3, 2, tableName, 3)
    End Function
    Public Shared Function getTables(ByRef conn As OleDb.OleDbConnection) As String()
        Return GetFromSchema(conn, "tables", 3, 3, "TABLE", 2)
    End Function
    Private Shared Function GetFromSchema(ByRef conn As OleDb.OleDbConnection, ByVal collectionName As String, ByVal collectoinSize As Integer, ByVal restrictionPositioin As Integer, ByVal restrictionValue As String, ByVal itemArrayIndex As Integer) As String()

        Dim res As New List(Of String)
        Dim rest(collectoinSize) As String
        rest(restrictionPositioin) = restrictionValue
        Dim dt As DataTable = conn.GetSchema(collectionName, rest)
        For Each row As DataRow In dt.Rows
            res.Add(row.Item(itemArrayIndex))
        Next
        Return If(res Is Nothing Or res.Count = 0, Nothing, res.ToArray)
    End Function

    Public Shared Sub setTablesInHash(ByRef conn As OleDb.OleDbConnection, ByRef db_tables As Hashtable, Optional ByVal selectedTables() As String = Nothing)
        Dim tables() As String
        If selectedTables Is Nothing Then
            tables = access_controller.getTables(conn)
        Else
            tables = selectedTables
        End If

        For Each tableName As String In tables
            Dim tableObj As New dbtable
            tableObj.TableName = tableName
            tableObj.tableExtension = tableName
            db_tables.Add(tableName, tableObj)
        Next
    End Sub

    Public Shared Sub setTableFieldsInHash(ByRef conn As OleDb.OleDbConnection, ByRef db_tables As Hashtable, ByVal tableName As String)
        Dim pkeys() As String = getPrimaryKeys(conn, False)
        For Each colName As String In getTableColumns(conn, tableName)
            Dim tableObj = CType(db_tables.Item(tableName), dbtable)
            If utilFunc.findInArray(pkeys, colName) Then
                tableObj.PRIMARYKEY_2.Add(colName, colName)
            Else
                tableObj.TableFields.Add(colName, colName)
            End If
        Next

    End Sub

    Public Shared Function setForeginKeys(ByRef conn As OleDb.OleDbConnection, ByRef db_tables As Hashtable) As Boolean
        Dim ret As Boolean = False
        Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Foreign_Keys, Nothing)
        Dim res As String = ""
        For Each row As DataRow In dt.Rows
            Try
                Dim fkObj As New foreginKey
                Dim fk_table As dbtable = sharedfunc.getTableByName(row.ItemArray(consts.FOREINKEY_TABLE_COLUMN_INDEX).ToString, db_tables)
                Dim pk_table As dbtable = sharedfunc.getTableByName(row.ItemArray(consts.FOREINKEY_RELATED_PRIMARYKEY_TABLE_INDEX).ToString, db_tables)
                pk_table.BACK_TO_REFERENCE = fk_table
                If Not fk_table Is Nothing And Not pk_table Is Nothing Then
                    fkObj.SetAttrs(row.ItemArray(consts.FOREINKEY_NAME_COLUMN_INDEX).ToString, row.ItemArray(consts.FOREINKEY_COLUMN_COLUMN_INDEX).ToString, fk_table, row.ItemArray(consts.FOREINKEY_RELATED_PRIMARYKEY_COLUMN_INDEX).ToString, pk_table)
                    CType(db_tables.Item(fk_table.TableName), dbtable).addForeignKey(fkObj)
                    ret = True
                End If

            Catch ex As Exception
            End Try

        Next
        Return ret


    End Function


End Class
