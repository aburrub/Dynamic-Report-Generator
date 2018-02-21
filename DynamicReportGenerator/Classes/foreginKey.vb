Public Class foreginKey

    Private foreignName As String

    Private foreignColumn As String
    Private foreignTable As dbtable

    ' primary key col and table for this foregin key
    Private primaryKeyColumn As String
    Private primaryKeyTable As dbtable

    Public Sub New()

    End Sub
    Public Sub New(ByVal foreign_Name As String, ByVal foreignColumn As String, ByVal foreignTable As dbtable, ByVal primaryKeyColumn As String, ByVal primaryKeyTable As dbtable)
        Me.SetAttrs(foreign_Name, foreignColumn, foreignTable, primaryKeyColumn, primaryKeyTable)
    End Sub

    Public Sub SetAttrs(ByVal foreign_Name As String, ByVal foreignColumn As String, ByVal foreignTable As dbtable, ByVal primaryKeyColumn As String, ByVal primaryKeyTable As dbtable)
        Me.foreignName = foreign_Name
        Me.foreignColumn = foreignColumn
        Me.foreignTable = foreignTable
        Me.primaryKeyColumn = primaryKeyColumn
        Me.primaryKeyTable = primaryKeyTable
    End Sub

    Public Property FOREIGNKEY_NAME() As String
        Get
            Return Me.foreignName
        End Get
        Set(ByVal value As String)
            Me.foreignName = value
        End Set
    End Property

    Public ReadOnly Property FK_TALBE() As dbtable
        Get
            Return Me.foreignTable
        End Get
    End Property
    Public ReadOnly Property PK_TABLE() As dbtable
        Get
            Return Me.primaryKeyTable
        End Get
    End Property

    Public ReadOnly Property FK_COLUMN() As String
        Get
            Return Me.foreignColumn
        End Get
    End Property
    Public ReadOnly Property PK_COLUMN() As String
        Get
            Return Me.primaryKeyColumn
        End Get
    End Property



End Class
