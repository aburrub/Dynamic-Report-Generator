<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneratedSqlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.database_ComboBox = New System.Windows.Forms.ComboBox()
        Me.database_Label = New System.Windows.Forms.Label()
        Me.connect_Button = New System.Windows.Forms.Button()
        Me.connection_status_Label = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.browse_Button = New System.Windows.Forms.Button()
        Me.db_TreeView = New System.Windows.Forms.TreeView()
        Me.Generate_Button = New System.Windows.Forms.Button()
        Me.selUnSelLabel = New System.Windows.Forms.Label()
        Me.rMenuContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddColumnAliasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.close_PictureBox = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.rMenuContextMenuStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Green
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(681, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToReportsToolStripMenuItem, Me.RemoveReportToolStripMenuItem, Me.EditReportsToolStripMenuItem, Me.RemoveFilterToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddToReportsToolStripMenuItem
        '
        Me.AddToReportsToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.AddToReportsToolStripMenuItem.Name = "AddToReportsToolStripMenuItem"
        Me.AddToReportsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.AddToReportsToolStripMenuItem.Text = "Add Report"
        '
        'RemoveReportToolStripMenuItem
        '
        Me.RemoveReportToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.RemoveReportToolStripMenuItem.Name = "RemoveReportToolStripMenuItem"
        Me.RemoveReportToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.RemoveReportToolStripMenuItem.Text = "Remove Report"
        '
        'EditReportsToolStripMenuItem
        '
        Me.EditReportsToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.EditReportsToolStripMenuItem.Name = "EditReportsToolStripMenuItem"
        Me.EditReportsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.EditReportsToolStripMenuItem.Text = "Edit Reports"
        '
        'RemoveFilterToolStripMenuItem
        '
        Me.RemoveFilterToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.RemoveFilterToolStripMenuItem.Name = "RemoveFilterToolStripMenuItem"
        Me.RemoveFilterToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.RemoveFilterToolStripMenuItem.Text = "Remove Filter"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneratedSqlToolStripMenuItem, Me.ReportToolStripMenuItem})
        Me.ViewToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ViewToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'GeneratedSqlToolStripMenuItem
        '
        Me.GeneratedSqlToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.GeneratedSqlToolStripMenuItem.Name = "GeneratedSqlToolStripMenuItem"
        Me.GeneratedSqlToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.GeneratedSqlToolStripMenuItem.Text = "Generated Sql"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ReportsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'database_ComboBox
        '
        Me.database_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.database_ComboBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.database_ComboBox.ForeColor = System.Drawing.Color.Green
        Me.database_ComboBox.FormattingEnabled = True
        Me.database_ComboBox.Location = New System.Drawing.Point(16, 38)
        Me.database_ComboBox.Name = "database_ComboBox"
        Me.database_ComboBox.Size = New System.Drawing.Size(191, 24)
        Me.database_ComboBox.TabIndex = 3
        '
        'database_Label
        '
        Me.database_Label.AutoSize = True
        Me.database_Label.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.database_Label.ForeColor = System.Drawing.Color.Green
        Me.database_Label.Location = New System.Drawing.Point(13, 12)
        Me.database_Label.Name = "database_Label"
        Me.database_Label.Size = New System.Drawing.Size(114, 16)
        Me.database_Label.TabIndex = 2
        Me.database_Label.Text = "Select Database"
        '
        'connect_Button
        '
        Me.connect_Button.AutoSize = True
        Me.connect_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.connect_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.connect_Button.ForeColor = System.Drawing.Color.Green
        Me.connect_Button.Location = New System.Drawing.Point(136, 68)
        Me.connect_Button.Name = "connect_Button"
        Me.connect_Button.Size = New System.Drawing.Size(71, 26)
        Me.connect_Button.TabIndex = 4
        Me.connect_Button.Text = "Connect"
        Me.connect_Button.UseVisualStyleBackColor = True
        '
        'connection_status_Label
        '
        Me.connection_status_Label.AutoSize = True
        Me.connection_status_Label.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.connection_status_Label.ForeColor = System.Drawing.Color.Red
        Me.connection_status_Label.Location = New System.Drawing.Point(213, 41)
        Me.connection_status_Label.Name = "connection_status_Label"
        Me.connection_status_Label.Size = New System.Drawing.Size(80, 16)
        Me.connection_status_Label.TabIndex = 5
        Me.connection_status_Label.Text = "########"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'browse_Button
        '
        Me.browse_Button.AutoSize = True
        Me.browse_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.browse_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.browse_Button.ForeColor = System.Drawing.Color.Green
        Me.browse_Button.Location = New System.Drawing.Point(16, 68)
        Me.browse_Button.Name = "browse_Button"
        Me.browse_Button.Size = New System.Drawing.Size(66, 26)
        Me.browse_Button.TabIndex = 6
        Me.browse_Button.Text = "Browse"
        Me.browse_Button.UseVisualStyleBackColor = True
        Me.browse_Button.Visible = False
        '
        'db_TreeView
        '
        Me.db_TreeView.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.db_TreeView.ForeColor = System.Drawing.Color.Green
        Me.db_TreeView.Location = New System.Drawing.Point(16, 108)
        Me.db_TreeView.Name = "db_TreeView"
        Me.db_TreeView.Size = New System.Drawing.Size(630, 231)
        Me.db_TreeView.TabIndex = 7
        '
        'Generate_Button
        '
        Me.Generate_Button.AutoSize = True
        Me.Generate_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Generate_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Generate_Button.ForeColor = System.Drawing.Color.Green
        Me.Generate_Button.Location = New System.Drawing.Point(568, 345)
        Me.Generate_Button.Name = "Generate_Button"
        Me.Generate_Button.Size = New System.Drawing.Size(78, 26)
        Me.Generate_Button.TabIndex = 8
        Me.Generate_Button.Text = "Generate"
        Me.Generate_Button.UseVisualStyleBackColor = True
        '
        'selUnSelLabel
        '
        Me.selUnSelLabel.AutoSize = True
        Me.selUnSelLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selUnSelLabel.ForeColor = System.Drawing.Color.Blue
        Me.selUnSelLabel.Location = New System.Drawing.Point(13, 345)
        Me.selUnSelLabel.Name = "selUnSelLabel"
        Me.selUnSelLabel.Size = New System.Drawing.Size(83, 13)
        Me.selUnSelLabel.TabIndex = 9
        Me.selUnSelLabel.Text = "Select All Nodes"
        '
        'rMenuContextMenuStrip
        '
        Me.rMenuContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddColumnAliasToolStripMenuItem, Me.AddFilterToolStripMenuItem})
        Me.rMenuContextMenuStrip.Name = "rMenuContextMenuStrip"
        Me.rMenuContextMenuStrip.Size = New System.Drawing.Size(171, 48)
        '
        'AddColumnAliasToolStripMenuItem
        '
        Me.AddColumnAliasToolStripMenuItem.Name = "AddColumnAliasToolStripMenuItem"
        Me.AddColumnAliasToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.AddColumnAliasToolStripMenuItem.Text = "Add Column Alias"
        '
        'AddFilterToolStripMenuItem
        '
        Me.AddFilterToolStripMenuItem.Name = "AddFilterToolStripMenuItem"
        Me.AddFilterToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.AddFilterToolStripMenuItem.Text = "Add Filter"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.close_PictureBox)
        Me.Panel1.Controls.Add(Me.db_TreeView)
        Me.Panel1.Controls.Add(Me.Generate_Button)
        Me.Panel1.Controls.Add(Me.selUnSelLabel)
        Me.Panel1.Controls.Add(Me.database_ComboBox)
        Me.Panel1.Controls.Add(Me.browse_Button)
        Me.Panel1.Controls.Add(Me.database_Label)
        Me.Panel1.Controls.Add(Me.connection_status_Label)
        Me.Panel1.Controls.Add(Me.connect_Button)
        Me.Panel1.Location = New System.Drawing.Point(12, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 385)
        Me.Panel1.TabIndex = 10
        '
        'close_PictureBox
        '
        Me.close_PictureBox.Image = Global.DynamicReportGenerator.My.Resources.Resources.closeButton
        Me.close_PictureBox.Location = New System.Drawing.Point(614, 12)
        Me.close_PictureBox.Name = "close_PictureBox"
        Me.close_PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.close_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.close_PictureBox.TabIndex = 10
        Me.close_PictureBox.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(681, 422)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Reports Generator"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.rMenuContextMenuStrip.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents database_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents database_Label As System.Windows.Forms.Label
    Friend WithEvents connect_Button As System.Windows.Forms.Button
    Friend WithEvents connection_status_Label As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents browse_Button As System.Windows.Forms.Button
    Friend WithEvents db_TreeView As System.Windows.Forms.TreeView
    Friend WithEvents Generate_Button As System.Windows.Forms.Button
    Friend WithEvents selUnSelLabel As System.Windows.Forms.Label
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneratedSqlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rMenuContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddColumnAliasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents close_PictureBox As System.Windows.Forms.PictureBox

End Class
