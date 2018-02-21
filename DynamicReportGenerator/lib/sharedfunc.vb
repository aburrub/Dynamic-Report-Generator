
Public Class sharedfunc
    Public Shared Function getAllRelations(ByRef db_tables As Hashtable) As List(Of String)
        Dim result As New List(Of String)
        For Each table As dbtable In db_tables.Values
            For Each fk As foreginKey In table.FOREGINKEYS.Values

            Next
        Next

        Return Nothing
    End Function
    Public Shared Function GenerateSqlWhereCondition(ByVal arr() As String, ByRef db_tables As Hashtable, ByRef connectedTables As List(Of String)) As String
        Dim condStr As String = ""
        Dim conds As New List(Of String)
        Dim result As New List(Of String())

        For Each table As dbtable In db_tables.Values
            For Each fk As foreginKey In table.FOREGINKEYS.Values
                If HomeScreen.doesTablesHasRelation(fk.FK_TALBE, fk.PK_TABLE, conds) Then
                    utilFunc.addWithoutDuplication(fk.FK_TALBE.TableName, connectedTables)
                    utilFunc.addWithoutDuplication(fk.PK_TABLE.TableName, connectedTables)
                End If
            Next
        Next

        Try
            condStr = Environment.NewLine + " WHERE "
            For Each cond As String In conds
                condStr = condStr + cond + Environment.NewLine + " AND "
            Next
            condStr = condStr.Substring(0, condStr.LastIndexOf("AND"))
            Return condStr
        Catch ex As Exception
            Return Nothing
        End Try

        'Return result
    End Function




    Public Shared Sub buildTreeFromDB(ByRef start As dbtable, ByRef endN As dbtable, ByRef read As List(Of String), ByRef final_rest As List(Of String))
        If Not utilFunc.findInArray(read, start.TableName) Then
            read.Add(start.TableName)
        End If

        If Not start.TableName = endN.TableName Then
            If Not start.BACK_TO_REFERENCE Is Nothing Then
                If Not utilFunc.findInArray(read, start.BACK_TO_REFERENCE.TableName) Then
                    buildTreeFromDB(start.BACK_TO_REFERENCE, endN, read, final_rest)
                End If
            End If


            For Each fk As foreginKey In start.FOREGINKEYS.Values
                If Not utilFunc.findInArray(read, fk.PK_TABLE.TableName) Then
                    buildTreeFromDB(fk.PK_TABLE, endN, read, final_rest)
                End If
            Next
            read.Remove(start.TableName)
        Else
            ' copy path
            utilFunc.copyArr(read, final_rest)
        End If


    End Sub


    Public Shared Sub SelectUnselectAllTreeViewNodes(ByRef tv As TreeView, ByVal selectFlag As Boolean)
        For Each parentNode As TreeNode In tv.Nodes
            parentNode.Checked = selectFlag
            For Each subNode As TreeNode In parentNode.Nodes
                subNode.Checked = selectFlag
            Next
        Next
    End Sub

    Public Shared Function getTableByName(ByVal tableName As String, ByRef db_tables As Hashtable) As dbtable
        Dim FTable As dbtable = CType(db_tables.Item(tableName), dbtable)
        If Not FTable Is Nothing Then
            Return FTable
        Else
            Return Nothing
        End If
    End Function

    ' Database Hash Related functions
    Public Shared Function getTablesNamesFromHash(ByRef db_tables As Hashtable) As String()
        Dim result As New List(Of String)
        If db_tables Is Nothing Then
            Return Nothing
        Else
            For Each obj As dbtable In db_tables
                result.Add(obj.TableName)
            Next
        End If
        Return If(result Is Nothing Or result.Count = 0, Nothing, result.ToArray)
    End Function
    
    ' convert from string "{a,b,c,d} to array"
    Public Shared Function convStrToArr(ByVal str As String) As Integer()
        Dim result As New List(Of Integer)
        Dim removeParanthsis As String = str.Replace("{", "").Replace("}", "")
        Dim tokens() As String = removeParanthsis.Split(",")
        For Each num As String In tokens
            Try
                result.Add(Integer.Parse(num))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        Return If(result Is Nothing Or result.Count = 0, Nothing, result.ToArray)
    End Function


    

End Class
