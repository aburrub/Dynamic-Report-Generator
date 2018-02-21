Imports Devart.Data.PostgreSql

Public Class pgsql_controller
    ' This is the first function to be called in access db
    Public Shared Function begin_pgsql_selected(ByRef conn As PgSqlConnection, ByRef db_tables As Hashtable, ByVal selectedTables() As String) As Boolean


        ' Set Tables in hash
        setTablesInHash(conn, db_tables, selectedTables)

        ' set fields for each table in db
        For Each table As String In selectedTables
            setTableFieldsInHash(conn, db_tables, table)
        Next

        ' set foreign keys, just in case we have more than one table
        If (db_tables.Keys.Count >= 2) Then
            If setForeginKeys(conn, db_tables, selectedTables) Then
            Else
                Return False
            End If
        End If


        Return True
    End Function

    Public Shared Function begin_pgsql_all_db_tables(ByRef conn As PgSqlConnection, ByRef all_db_tables As Hashtable, ByVal allAvailableTables() As String) As Boolean

        ' set all tables hash
        setTablesInHash(conn, all_db_tables)

        ' set fields for each table in all_db_tables
        Dim i As Integer = 0
        For Each table As String In allAvailableTables
            setTableFieldsInHash(conn, all_db_tables, table)
            i = i + 1
       
        Next

        ' set foreign keys for all_db_tables, just in case we have more than one table
        If (all_db_tables.Keys.Count >= 2) Then
            If setForeginKeys(conn, all_db_tables, allAvailableTables) Then
            Else
                Return False
            End If
        End If

        Return True
    End Function
    Private Shared Function getPrimaryKeyField(ByRef conn As PgSqlConnection, ByRef all_db_tables As Hashtable, ByVal pk_name As String) As String
        Dim rest(4) As String
        rest(2) = pk_name
        Dim dt As DataTable = conn.GetSchema("primarykeys", rest)
        If dt.Rows.Count = 1 Then
            Dim tbl As dbtable = sharedfunc.getTableByName(dt.Rows(0).ItemArray(2).ToString, all_db_tables)
            If Not tbl Is Nothing Then
                Dim pkeysStr As String = dt.Rows(0).ItemArray(4).ToString
                Dim pkeys() As Integer = sharedfunc.convStrToArr(pkeysStr)
                If Not pkeys Is Nothing Then
                    Return pgsql_controller.getTableColumns(conn, tbl.TableName)(pkeys(0) - 1)
                Else
                    Return Nothing
                End If

            End If

        End If
        Return Nothing
        '2 tb_name
    End Function
    Private Shared Function fk_attrs(ByVal tableName As String, ByRef conn As PgSqlConnection, _
                       ByRef fk_name As List(Of String), ByRef fk_col As List(Of String), ByRef fk_tbl As List(Of String), _
                        ByRef pk_table As List(Of String), ByRef pk_field As List(Of String), ByRef all_db_tables As Hashtable _
                       ) As Boolean

        Dim pk_name As String
        Dim rest(4) As String
        rest(1) = tableName
        Dim dt_fks As DataTable = conn.GetSchema("ForeignKeys", rest)
        Dim dt_fkc As DataTable = conn.GetSchema("ForeignKeycolumns", rest)

        If dt_fkc.Rows.Count >= 1 And dt_fks.Rows.Count >= 1 Then
            For i As Integer = 0 To dt_fkc.Rows.Count - 1

            Next
            fk_name.Add(dt_fks.Rows(0).ItemArray(0).ToString)
            fk_col.Add(dt_fkc.Rows(0).ItemArray(3).ToString)
            fk_tbl.Add(dt_fks.Rows(0).ItemArray(2).ToString)
            pk_table.Add(dt_fks.Rows(0).ItemArray(5).ToString)
            pk_name = dt_fks.Rows(0).ItemArray(3).ToString
            pk_field.Add(getPrimaryKeyField(conn, all_db_tables, pk_name))
        Else
            fk_name.Clear()
            fk_col.Clear()
            fk_tbl.Clear()
            pk_table.Clear()
            pk_field.Clear()
            Return False
        End If
        Return True
    End Function

    ' we should loop around fkes not around tables
    Public Shared Function setForeginKeys(ByRef conn As PgSqlConnection, ByRef db_tables As Hashtable, ByRef allTables() As String) As Boolean
        Dim ret As Boolean = False
        Dim rest(4) As String
        Dim fk_name As String = ""
        Dim fk_col As String = ""
        Dim fk_tbl As String = ""
        Dim pk_col As String = ""
        Dim pk_name As String = ""
        Dim pk_tbl As String = ""


        Dim dt_fks As DataTable = conn.GetSchema("ForeignKeys")


        For Each row As DataRow In dt_fks.Rows
            Try
                fk_name = row.ItemArray(0).ToString
                rest(2) = fk_name 'tableName
                Dim dt_fkc As DataTable = conn.GetSchema("ForeignKeycolumns", rest)
                For Each subCol As DataRow In dt_fkc.Rows
                    fk_col = subCol.ItemArray(3).ToString 'ddd
                Next

                fk_tbl = row.ItemArray(2).ToString
                pk_tbl = row.ItemArray(5).ToString
                pk_name = row.ItemArray(3).ToString
                pk_col = getPrimaryKeyField(conn, db_tables, pk_name)

                Dim fkObj As New foreginKey
                Dim fk_table As dbtable = sharedfunc.getTableByName(fk_tbl, db_tables)
                Dim pk_table As dbtable = sharedfunc.getTableByName(pk_tbl, db_tables)
                pk_table.BACK_TO_REFERENCE = fk_table
                If Not fk_table Is Nothing And Not pk_table Is Nothing Then
                    fkObj.SetAttrs(fk_name, fk_col, fk_table, pk_col, pk_table)
                    CType(db_tables.Item(fk_table.TableName), dbtable).addForeignKey(fkObj)
                    ret = True
                End If
            Catch ex As Exception

            End Try
            
        Next

        Return ret
    End Function
    Public Shared Function setForeginKeys2(ByRef conn As PgSqlConnection, ByRef db_tables As Hashtable, ByRef allTables() As String) As Boolean
        Dim ret As Boolean = False

        Dim fk_name As New List(Of String)
        Dim fk_col As New List(Of String)
        Dim fk_tbl As New List(Of String)
        Dim pk_col As New List(Of String)
        Dim pk_tbl As New List(Of String)

        For Each table As String In allTables
            Try
                If fk_attrs(table, conn, fk_name, fk_col, fk_tbl, pk_tbl, pk_col, db_tables) Then
                    For i As Integer = 0 To fk_name.Count - 1
                        Dim fkObj As New foreginKey
                        Dim fk_table As dbtable = sharedfunc.getTableByName(fk_tbl(i), db_tables)
                        Dim pk_table As dbtable = sharedfunc.getTableByName(pk_tbl(i), db_tables)
                        pk_table.BACK_TO_REFERENCE = fk_table
                        If Not fk_table Is Nothing And Not pk_table Is Nothing Then
                            fkObj.SetAttrs(fk_name(i), fk_col(i), fk_table, pk_col(i), pk_table)
                            CType(db_tables.Item(fk_table.TableName), dbtable).addForeignKey(fkObj)
                            ret = True
                        End If
                    Next

                End If
            Catch ex As Exception

            End Try

        Next

        Return ret
    End Function

    ' should handle multiple p-keys
    Public Shared Function getPrimaryKeyPosition(ByRef conn As PgSqlConnection, ByVal tableName As String) As Integer()
        Dim restriction(3) As String
        restriction(1) = tableName
        Dim dt As DataTable = conn.GetSchema("PrimaryKeys", restriction)
        ' primary name, value: field position
        If Not dt.Rows.Count = 0 Then
            Return sharedfunc.convStrToArr(dt.Rows(0).ItemArray(4).ToString)
        Else
            Return New Integer() {-1}
        End If
    End Function

    Public Shared Sub setTableFieldsInHash(ByRef conn As PgSqlConnection, ByRef db_tables As Hashtable, ByVal tableName As String)
        Dim positionCounter As Integer = 0
        Dim found As Boolean
        Dim tbl_pk_ps() As Integer = getPrimaryKeyPosition(conn, tableName)
        For Each colName As String In getTableColumns(conn, tableName)
            positionCounter = positionCounter + 1
            Dim tableObj = CType(db_tables.Item(tableName), dbtable)


            For Each pk As Integer In tbl_pk_ps
                found = False
                If pk = positionCounter And Not pk = -1 Then
                    tableObj.PRIMARYKEY_2.Add(colName, colName)
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                tableObj.TableFields.Add(colName, colName)
            End If
        Next

    End Sub



    Public Shared Sub setTablesInHash(ByRef conn As PgSqlConnection, ByRef db_tables As Hashtable, Optional ByVal selectedTables() As String = Nothing)
        Dim tables() As String
        If selectedTables Is Nothing Then
            tables = getTables(conn)
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


    ' get pgsql table columns
    Public Shared Function getTableColumns(ByRef conn As PgSqlConnection, ByVal tableName As String) As String()
        Return GetFromSchema(conn, "Columns", 3, 1, tableName, 2)
    End Function

    ' get all pgsql tables
    Public Shared Function getTables(ByRef conn As PgSqlConnection) As String()
        Return GetFromSchema(conn, "tables", 2)
    End Function



    Private Shared Function GetFromSchema(ByRef conn As PgSqlConnection, ByVal collectionName As String, ByVal itemArrayIndex As Integer) As String()

        Dim res As New List(Of String)
        Dim dt As DataTable = conn.GetSchema(collectionName)
        For Each row As DataRow In dt.Rows
            res.Add(row.Item(itemArrayIndex))
        Next
        Return If(res Is Nothing Or res.Count = 0, Nothing, res.ToArray)
    End Function

    Private Shared Function GetFromSchema(ByRef conn As PgSqlConnection, ByVal collectionName As String, ByVal collectoinSize As Integer, ByVal restrictionPositioin As Integer, ByVal restrictionValue As String, ByVal itemArrayIndex As Integer) As String()

        Dim res As New List(Of String)
        Dim rest(collectoinSize) As String
        rest(restrictionPositioin) = restrictionValue
        Dim dt As DataTable = conn.GetSchema(collectionName, rest)
        For Each row As DataRow In dt.Rows
            res.Add(row.Item(itemArrayIndex).ToString)
        Next
        Return If(res Is Nothing Or res.Count = 0, Nothing, res.ToArray)
    End Function
End Class
