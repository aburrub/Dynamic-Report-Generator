Imports System.Configuration
Public Class dbConnector
    Private _connectionString As String = ""
    Private Sub dbConnector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Items.AddRange(consts.AVAILABLE_DATABASES.ToArray)
        Me.ComboBox1.SelectedIndex = 0
        Dim connections() As String = xmlLib.getAllPgsqlConnections
        If Not connections Is Nothing Then
            Me.Postgresql_ListBox.Items.AddRange(connections)
        End If
        If Me.Postgresql_ListBox.Items.Count >= 1 Then
            Me.Postgresql_ListBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        Dim found As Boolean = False
        If Not Me.Postgresql_ListBox.SelectedItem Is Nothing Then
            '  drgXML.removePostgresqlConnection(Me.Postgresql_ListBox.SelectedItem.ToString)
            '  drgXML.addPgsqlConnectionToXmlFile(Me.Postgresql_ListBox.SelectedItem.ToString, Me.user_TextBox.Text, Me.password_TextBox.Text, Me.host_TextBox.Text, Me.db_name_TextBox.Text)
            xmlLib.modifyPgsqlConnection(Me.Postgresql_ListBox, Me.user_TextBox, Me.password_TextBox, Me.host_TextBox, Me.db_name_TextBox, Me.Port_TextBox, consts.MY_SETTINGS_OUTPUT_FILE)
        Else

            Dim name As String = InputBox("Enter name for postgresql connection", "Type a name")
            For Each itm As String In Me.Postgresql_ListBox.Items
                If itm.ToLower = name.ToLower Then
                    found = True
                    Exit For
                End If
            Next
            If name Is Nothing Or name = "" Then
                MsgBox("Name should not be empty or null")
            ElseIf found Then
                xmlLib.modifyPgsqlConnection(name, Me.user_TextBox, Me.password_TextBox, Me.host_TextBox, Me.db_name_TextBox, Me.Port_TextBox, consts.MY_SETTINGS_OUTPUT_FILE)
            Else
                xmlLib.addPgsqlConnectionToXmlFile(name, Me.user_TextBox.Text, Me.password_TextBox.Text, Me.host_TextBox.Text, Me.db_name_TextBox.Text, Me.Port_TextBox.Text, consts.MY_SETTINGS_OUTPUT_FILE)
            End If

        End If

        Me.Postgresql_ListBox.Items.Clear()
        Dim connections() As String = xmlLib.getAllPgsqlConnections
        If Not connections Is Nothing Then
            Me.Postgresql_ListBox.Items.AddRange(connections)
        End If
    End Sub

    Private Sub Postgresql_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Postgresql_ListBox.SelectedIndexChanged
        xmlLib.fillPostgresqlGUIFromXml(Me.Postgresql_ListBox, Me.user_TextBox, Me.password_TextBox, Me.host_TextBox, Me.db_name_TextBox, Me.Port_TextBox, consts.MY_SETTINGS_OUTPUT_FILE)
    End Sub

    Private Sub remove_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles remove_Button.Click
        If Not Me.Postgresql_ListBox.SelectedItem Is Nothing Then
            xmlLib.removePostgresqlConnection(Me.Postgresql_ListBox.SelectedItem.ToString)
            Me.Postgresql_ListBox.Items.Clear()
            Dim connections() As String = xmlLib.getAllPgsqlConnections
            If Not connections Is Nothing Then
                Me.Postgresql_ListBox.Items.AddRange(connections)
            End If
        End If
    End Sub
    Private Sub enableAll(ByVal en As Boolean)
        Me.pgsql_GroupBox.Enabled = en
        Me.Save_Button.Enabled = en
        Me.Postgresql_ListBox.Enabled = en
        Me.remove_Button.Enabled = en
        Me.Label6.Enabled = en
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.SelectedItem.ToString = "Access" Then
            enableAll(False)
        Else
            enableAll(True)
        End If

    End Sub

    Public ReadOnly Property CONNECTION_STRING As String
        Get
            Return _connectionString
        End Get
    End Property

    Private Sub Connect_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Connect_Button.Click
        Me._connectionString = "User ID=" + Me.user_TextBox.Text + ";Password=" + Me.password_TextBox.Text + ";Host=" + Me.host_TextBox.Text + ";Port=" + Me.Port_TextBox.Text + ";Database=" + Me.db_name_TextBox.Text + "; Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;Unicode=True"
        Me.Close()
    End Sub

    Private Sub Add_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_Button.Click
        Dim found As Boolean = False


        Dim name As String = InputBox("Enter name for postgresql connection", "Type a name")
        For Each itm As String In Me.Postgresql_ListBox.Items
            If itm.ToLower = name.ToLower Then
                found = True
                Exit For
            End If
        Next
        If name Is Nothing Or name = "" Then
            MsgBox("Name should not be empty or null")
        ElseIf found Then
            xmlLib.modifyPgsqlConnection(name, Me.user_TextBox, Me.password_TextBox, Me.host_TextBox, Me.db_name_TextBox, Me.Port_TextBox, consts.MY_SETTINGS_OUTPUT_FILE)
        Else
            xmlLib.addPgsqlConnectionToXmlFile(name, Me.user_TextBox.Text, Me.password_TextBox.Text, Me.host_TextBox.Text, Me.db_name_TextBox.Text, Me.Port_TextBox.Text, consts.MY_SETTINGS_OUTPUT_FILE)
        End If



        Me.Postgresql_ListBox.Items.Clear()
        Dim connections() As String = xmlLib.getAllPgsqlConnections
        If Not connections Is Nothing Then
            Me.Postgresql_ListBox.Items.AddRange(connections)
        End If
    End Sub

    Private Sub close_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_PictureBox.Click
        Me.Close()
    End Sub

    Private Sub Postgresql_ListBox_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Postgresql_ListBox.MouseDoubleClick
        Me.Connect_Button_Click(Nothing, Nothing)
    End Sub
End Class