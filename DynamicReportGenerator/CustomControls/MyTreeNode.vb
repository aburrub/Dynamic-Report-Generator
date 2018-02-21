Public Class MyTreeNode : Inherits TreeNode
    Private _alias As String

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal text As String, Optional ByVal alias_param As String = "")        
        MyBase.New(text)
        Me._alias = alias_param
    End Sub
    Public Sub New(ByVal text As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer)
        MyBase.New(text, imageIndex, selectedImageIndex)
    End Sub

    Public Sub New(ByVal text As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer, ByVal children() As System.Windows.Forms.MyTreeNode)
        MyBase.New(text, imageIndex, selectedImageIndex, children)
    End Sub
    Public Sub New(ByVal text As String, ByVal children() As System.Windows.Forms.MyTreeNode)
        MyBase.New(text, children)
    End Sub
    Public Sub New(ByVal serializationInfo As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(serializationInfo, context)
    End Sub

    Public ReadOnly Property TO_TREE_NODE() As MyTreeNode
        Get
            Return Nothing
        End Get
    End Property

    Public Property COLUMN_ALIAS() As String
        Set(ByVal value As String)
            Me._alias = value
        End Set
        Get
            Return Me._alias
        End Get
    End Property
End Class
