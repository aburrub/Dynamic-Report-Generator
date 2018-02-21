Public Class Report
    Private _connectionString As String
    Private _name As String
    Private _category As String
    Private _sql As String
    Private _dbms As String
    Public Sub New()

    End Sub
    Public Sub New(ByVal name As String, ByVal category As String, ByVal sql As String, ByVal connectionString As String, ByVal dbms As String)
        Me._connectionString = connectionString
        Me._name = name
        Me._category = category
        Me._sql = sql
        Me._dbms = sql
    End Sub

    Public Property CONNECTION_STRING() As String
        Set(ByVal value As String)
            Me._connectionString = value
        End Set
        Get
            Return Me._connectionString
        End Get
    End Property

    Public Property NAME() As String
        Set(ByVal value As String)
            Me._name = value
        End Set
        Get
            Return Me._name
        End Get
    End Property

    Public Property CATEGORY() As String
        Set(ByVal value As String)
            Me._category = value
        End Set
        Get
            Return Me._category
        End Get
    End Property

    Public Property SQL() As String
        Set(ByVal value As String)
            Me._sql = value
        End Set
        Get
            Return Me._sql
        End Get
    End Property
    Public Property dbms() As String
        Set(ByVal value As String)
            Me._dbms = value
        End Set
        Get
            Return Me._dbms
        End Get
    End Property


End Class
