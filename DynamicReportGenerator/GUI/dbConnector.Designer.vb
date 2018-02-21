<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dbConnector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgsql_GroupBox = New System.Windows.Forms.GroupBox()
        Me.db_name_TextBox = New System.Windows.Forms.TextBox()
        Me.Connect_Button = New System.Windows.Forms.Button()
        Me.Save_Button = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Port_TextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.host_TextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.password_TextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.user_TextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Postgresql_ListBox = New System.Windows.Forms.ListBox()
        Me.remove_Button = New System.Windows.Forms.Button()
        Me.Add_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.close_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pgsql_GroupBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.ForeColor = System.Drawing.Color.Green
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(96, 67)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(20, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database"
        '
        'pgsql_GroupBox
        '
        Me.pgsql_GroupBox.Controls.Add(Me.db_name_TextBox)
        Me.pgsql_GroupBox.Controls.Add(Me.Connect_Button)
        Me.pgsql_GroupBox.Controls.Add(Me.Save_Button)
        Me.pgsql_GroupBox.Controls.Add(Me.Label5)
        Me.pgsql_GroupBox.Controls.Add(Me.Port_TextBox)
        Me.pgsql_GroupBox.Controls.Add(Me.Label7)
        Me.pgsql_GroupBox.Controls.Add(Me.host_TextBox)
        Me.pgsql_GroupBox.Controls.Add(Me.Label4)
        Me.pgsql_GroupBox.Controls.Add(Me.password_TextBox)
        Me.pgsql_GroupBox.Controls.Add(Me.Label3)
        Me.pgsql_GroupBox.Controls.Add(Me.user_TextBox)
        Me.pgsql_GroupBox.Controls.Add(Me.Label2)
        Me.pgsql_GroupBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.pgsql_GroupBox.ForeColor = System.Drawing.Color.Green
        Me.pgsql_GroupBox.Location = New System.Drawing.Point(253, 101)
        Me.pgsql_GroupBox.Name = "pgsql_GroupBox"
        Me.pgsql_GroupBox.Size = New System.Drawing.Size(358, 233)
        Me.pgsql_GroupBox.TabIndex = 2
        Me.pgsql_GroupBox.TabStop = False
        Me.pgsql_GroupBox.Text = "PostgreSql Database"
        '
        'db_name_TextBox
        '
        Me.db_name_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.db_name_TextBox.ForeColor = System.Drawing.Color.Green
        Me.db_name_TextBox.Location = New System.Drawing.Point(131, 144)
        Me.db_name_TextBox.Name = "db_name_TextBox"
        Me.db_name_TextBox.Size = New System.Drawing.Size(199, 23)
        Me.db_name_TextBox.TabIndex = 5
        '
        'Connect_Button
        '
        Me.Connect_Button.AutoSize = True
        Me.Connect_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Connect_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Connect_Button.ForeColor = System.Drawing.Color.Green
        Me.Connect_Button.Location = New System.Drawing.Point(257, 178)
        Me.Connect_Button.Name = "Connect_Button"
        Me.Connect_Button.Size = New System.Drawing.Size(71, 26)
        Me.Connect_Button.TabIndex = 6
        Me.Connect_Button.Text = "Connect"
        Me.Connect_Button.UseVisualStyleBackColor = True
        '
        'Save_Button
        '
        Me.Save_Button.AutoSize = True
        Me.Save_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Save_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Save_Button.ForeColor = System.Drawing.Color.Green
        Me.Save_Button.Location = New System.Drawing.Point(201, 178)
        Me.Save_Button.Name = "Save_Button"
        Me.Save_Button.Size = New System.Drawing.Size(50, 26)
        Me.Save_Button.TabIndex = 7
        Me.Save_Button.Text = "Save"
        Me.Save_Button.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(13, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Database Name"
        '
        'Port_TextBox
        '
        Me.Port_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Port_TextBox.ForeColor = System.Drawing.Color.Green
        Me.Port_TextBox.Location = New System.Drawing.Point(131, 117)
        Me.Port_TextBox.Name = "Port_TextBox"
        Me.Port_TextBox.Size = New System.Drawing.Size(199, 23)
        Me.Port_TextBox.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(86, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Port"
        '
        'host_TextBox
        '
        Me.host_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.host_TextBox.ForeColor = System.Drawing.Color.Green
        Me.host_TextBox.Location = New System.Drawing.Point(131, 90)
        Me.host_TextBox.Name = "host_TextBox"
        Me.host_TextBox.Size = New System.Drawing.Size(199, 23)
        Me.host_TextBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(84, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Host"
        '
        'password_TextBox
        '
        Me.password_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.password_TextBox.ForeColor = System.Drawing.Color.Green
        Me.password_TextBox.Location = New System.Drawing.Point(131, 64)
        Me.password_TextBox.Name = "password_TextBox"
        Me.password_TextBox.Size = New System.Drawing.Size(199, 23)
        Me.password_TextBox.TabIndex = 2
        Me.password_TextBox.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(51, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password"
        '
        'user_TextBox
        '
        Me.user_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.user_TextBox.ForeColor = System.Drawing.Color.Green
        Me.user_TextBox.Location = New System.Drawing.Point(131, 36)
        Me.user_TextBox.Name = "user_TextBox"
        Me.user_TextBox.Size = New System.Drawing.Size(197, 23)
        Me.user_TextBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(67, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "User ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(20, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "List of Connections"
        '
        'Postgresql_ListBox
        '
        Me.Postgresql_ListBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Postgresql_ListBox.ForeColor = System.Drawing.Color.Green
        Me.Postgresql_ListBox.FormattingEnabled = True
        Me.Postgresql_ListBox.ItemHeight = 16
        Me.Postgresql_ListBox.Location = New System.Drawing.Point(23, 122)
        Me.Postgresql_ListBox.Name = "Postgresql_ListBox"
        Me.Postgresql_ListBox.ScrollAlwaysVisible = True
        Me.Postgresql_ListBox.Size = New System.Drawing.Size(177, 132)
        Me.Postgresql_ListBox.TabIndex = 10
        '
        'remove_Button
        '
        Me.remove_Button.AutoSize = True
        Me.remove_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.remove_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.remove_Button.ForeColor = System.Drawing.Color.Green
        Me.remove_Button.Location = New System.Drawing.Point(130, 262)
        Me.remove_Button.Name = "remove_Button"
        Me.remove_Button.Size = New System.Drawing.Size(70, 26)
        Me.remove_Button.TabIndex = 11
        Me.remove_Button.Text = "Remove"
        Me.remove_Button.UseVisualStyleBackColor = True
        '
        'Add_Button
        '
        Me.Add_Button.AutoSize = True
        Me.Add_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Add_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Add_Button.ForeColor = System.Drawing.Color.Green
        Me.Add_Button.Location = New System.Drawing.Point(23, 262)
        Me.Add_Button.Name = "Add_Button"
        Me.Add_Button.Size = New System.Drawing.Size(44, 26)
        Me.Add_Button.TabIndex = 13
        Me.Add_Button.Text = "Add"
        Me.Add_Button.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.close_PictureBox)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.pgsql_GroupBox)
        Me.Panel1.Controls.Add(Me.Add_Button)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.remove_Button)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Postgresql_ListBox)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 410)
        Me.Panel1.TabIndex = 14
        '
        'close_PictureBox
        '
        Me.close_PictureBox.Image = Global.DynamicReportGenerator.My.Resources.Resources.closeButton
        Me.close_PictureBox.Location = New System.Drawing.Point(695, 3)
        Me.close_PictureBox.Name = "close_PictureBox"
        Me.close_PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.close_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.close_PictureBox.TabIndex = 15
        Me.close_PictureBox.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(19, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 19)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Connect to a database"
        '
        'dbConnector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(758, 436)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dbConnector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Reports Generator : Database Connector"
        Me.pgsql_GroupBox.ResumeLayout(False)
        Me.pgsql_GroupBox.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pgsql_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents user_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents password_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents host_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents db_name_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Save_Button As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Postgresql_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents remove_Button As System.Windows.Forms.Button
    Friend WithEvents Connect_Button As System.Windows.Forms.Button
    Friend WithEvents Port_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Add_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents close_PictureBox As System.Windows.Forms.PictureBox
End Class
