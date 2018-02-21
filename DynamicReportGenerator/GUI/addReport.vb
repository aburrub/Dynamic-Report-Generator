Public Class addReport
    Private _sql As String = ""
    Private _dbms As String
    Private _username As String = "postgres"
    Private _password As String = "1040039"
    Private _port As String = "5432"
    Private _host As String = "127.0.0.1"
    Private _dbname As String = "hr"
    Private _connectionString As String
    Private Sub cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub ok_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok_Button.Click
        If Not xmlLib.isThisReportInXmlFile(Me.report_name_TextBox.Text, consts.MY_SETTINGS_OUTPUT_FILE) Then
            xmlLib.addReportToXmlFile(Me.report_name_TextBox.Text, Me.rep_cat_ComboBox.Text, Me._sql, Me._connectionString, Me._dbms, consts.MY_SETTINGS_OUTPUT_FILE)
            Me.Close()
        Else
            MsgBox("Name is already exist, try another name")
        End If
    End Sub

    Public Property SQL As String
        Get
            Return Me._sql
        End Get
        Set(ByVal value As String)
            Me._sql = value
        End Set
    End Property
    Public Property CONNECTION_STRING As String
        Get
            Return Me._connectionString
        End Get
        Set(ByVal value As String)
            Me._connectionString = value
        End Set
    End Property

    Private Sub addReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cats() As String = xmlLib.getCategoriesNames(consts.MY_SETTINGS_OUTPUT_FILE)
        If cats Is Nothing Then
            Me.rep_cat_ComboBox.Items.Add("root")
        Else
            If Not utilFunc.findInArray(cats, "root") Then
                Me.rep_cat_ComboBox.Items.Add("root")
            End If

        End If
        If Not cats Is Nothing Then
            For Each cat As String In cats
                Me.rep_cat_ComboBox.Items.Add(cat)
            Next
        End If

        If Me.rep_cat_ComboBox.Items.Count >= 1 Then
            Me.rep_cat_ComboBox.SelectedIndex = 0
        End If
    End Sub

    Public Property DBMS() As String
        Set(ByVal value As String)
            Me._dbms = value
        End Set
        Get
            Return Me._dbms
        End Get
    End Property
    Public Property PASSWORD() As String
        Set(ByVal value As String)
            Me._password = value
        End Set
        Get
            Return Me._password
        End Get
    End Property

    Public Property USERNAME() As String
        Set(ByVal value As String)
            Me._username = value
        End Set
        Get
            Return Me._username
        End Get
    End Property

    Public Property PORT() As String
        Set(ByVal value As String)
            Me._port = value
        End Set
        Get
            Return Me._port
        End Get
    End Property
    Public Property DBNAME() As String
        Set(ByVal value As String)
            Me._dbname = value
        End Set
        Get
            Return Me._dbname
        End Get
    End Property
    Public Property HOST() As String
        Set(ByVal value As String)
            Me._host = value
        End Set
        Get
            Return Me._host
        End Get
    End Property

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub
End Class