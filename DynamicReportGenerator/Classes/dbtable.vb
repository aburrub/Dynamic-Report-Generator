Public Class dbtable
    Private table_extension As String
    Private table_Name As String
    Private primary_key As Hashtable
    Private table_Fields As Hashtable
    Private foregin_Keys As Hashtable

    Private backToForeignKey As dbtable
    Public Sub New()
        Me.table_Fields = New Hashtable
        Me.foregin_Keys = New Hashtable
        Me.primary_key = New Hashtable
    End Sub

    Public Function addColumn(ByVal columnName As String) As Boolean
        If (Me.table_Fields(columnName)) Then
            Return False
        Else
            Me.table_Fields.Add(columnName, columnName)
            Return True
        End If
    End Function
    Public Function removeColumn(ByVal columnName As String) As Boolean
        If (Me.table_Fields(columnName)) Then
            Me.table_Fields.Remove(columnName)
            Return True
        Else
            Return False
        End If
    End Function
    Public Function addForeignKey(ByVal ForeignKeyName As String, ByVal ForeignKeyColName As String, ByVal foreignKeyTable As dbtable, ByVal primaryKeyColName As String) As Boolean
        If (Me.foregin_Keys(ForeignKeyName)) Then
            Return False
        Else
            Dim newForeignKey = New foreginKey(ForeignKeyName, ForeignKeyColName, foreignKeyTable, primaryKeyColName, Me)
            Me.foregin_Keys.Add(ForeignKeyName, newForeignKey)
            Return True
        End If
    End Function
    Public Function addForeignKey(ByVal foreignKeyObj As foreginKey) As Boolean
        If (Me.foregin_Keys(foreignKeyObj.FOREIGNKEY_NAME)) Then
            Return False
        Else
            Me.foregin_Keys.Add(foreignKeyObj.FOREIGNKEY_NAME, foreignKeyObj)
            Return True
        End If
    End Function
    Public Function removeForeignKey(ByVal ForeignKeyName As String) As Boolean
        If (Me.foregin_Keys(ForeignKeyName)) Then
            Me.foregin_Keys.Remove(ForeignKeyName)
            Return True
        Else
            Return False
        End If
    End Function

    Public ReadOnly Property TableFields() As Hashtable
        Get
            Return Me.table_Fields
        End Get
    End Property

    Public ReadOnly Property FOREGINKEYS() As Hashtable
        Get
            Return Me.foregin_Keys
        End Get
    End Property

    Public Property TableName() As String
        Get
            Return Me.table_Name
        End Get
        Set(ByVal value As String)
            Me.table_Name = value
        End Set
    End Property



    Public Property PRIMARYKEY_2() As Hashtable
        Get
            Return Me.primary_key
        End Get
        Set(ByVal primarykey As Hashtable)
            Me.primary_key = primarykey
        End Set
    End Property

    Public Property tableExtension() As String
        Get
            Return Me.table_extension
        End Get
        Set(ByVal value As String)
            Me.table_extension = value
        End Set
    End Property


    Public Sub print()
        Dim res As String = ""

        res = res + "Table:" + Me.table_Name + Environment.NewLine
        'res = res + "PrimaryKey:" + Me.primary_key + Environment.NewLine

        For Each key As String In Me.table_Fields.Keys
            res = res + "FIELD:" + Me.table_Fields(key) + Environment.NewLine
        Next

        For Each key As String In Me.foregin_Keys.Keys
            res = res + "FK:" + key + Environment.NewLine
        Next
        MsgBox(res)
    End Sub



    Public Property BACK_TO_REFERENCE() As dbtable
        Get
            Return Me.backToForeignKey
        End Get
        Set(ByVal value As dbtable)
            Me.backToForeignKey = value
        End Set
    End Property

End Class
