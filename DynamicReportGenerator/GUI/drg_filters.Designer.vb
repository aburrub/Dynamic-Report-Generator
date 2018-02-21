<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class drg_filters
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.aggr_CheckBox = New System.Windows.Forms.CheckBox()
        Me.aggr_ComboBox = New System.Windows.Forms.ComboBox()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.operation_ComboBox = New System.Windows.Forms.ComboBox()
        Me.clear_Button = New System.Windows.Forms.Button()
        Me.aggr_TreeView = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.close_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(327, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filter data based on Column [REPLACED_VAL] By:"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.ForeColor = System.Drawing.Color.Green
        Me.TextBox1.Location = New System.Drawing.Point(18, 33)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(441, 133)
        Me.TextBox1.TabIndex = 1
        '
        'aggr_CheckBox
        '
        Me.aggr_CheckBox.AutoSize = True
        Me.aggr_CheckBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.aggr_CheckBox.ForeColor = System.Drawing.Color.Green
        Me.aggr_CheckBox.Location = New System.Drawing.Point(18, 214)
        Me.aggr_CheckBox.Name = "aggr_CheckBox"
        Me.aggr_CheckBox.Size = New System.Drawing.Size(176, 20)
        Me.aggr_CheckBox.TabIndex = 2
        Me.aggr_CheckBox.Text = "Choose Value From List"
        Me.aggr_CheckBox.UseVisualStyleBackColor = True
        '
        'aggr_ComboBox
        '
        Me.aggr_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.aggr_ComboBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.aggr_ComboBox.ForeColor = System.Drawing.Color.Green
        Me.aggr_ComboBox.FormattingEnabled = True
        Me.aggr_ComboBox.Location = New System.Drawing.Point(18, 240)
        Me.aggr_ComboBox.Name = "aggr_ComboBox"
        Me.aggr_ComboBox.Size = New System.Drawing.Size(351, 24)
        Me.aggr_ComboBox.TabIndex = 3
        '
        'cancel_Button
        '
        Me.cancel_Button.AutoSize = True
        Me.cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cancel_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cancel_Button.ForeColor = System.Drawing.Color.Green
        Me.cancel_Button.Location = New System.Drawing.Point(504, 471)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(60, 26)
        Me.cancel_Button.TabIndex = 5
        Me.cancel_Button.Text = "Cancel"
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'ok_Button
        '
        Me.ok_Button.AutoSize = True
        Me.ok_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ok_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ok_Button.ForeColor = System.Drawing.Color.Green
        Me.ok_Button.Location = New System.Drawing.Point(585, 471)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(34, 26)
        Me.ok_Button.TabIndex = 4
        Me.ok_Button.Text = "Ok"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(15, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Choose Filter Operation"
        '
        'operation_ComboBox
        '
        Me.operation_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.operation_ComboBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.operation_ComboBox.ForeColor = System.Drawing.Color.Green
        Me.operation_ComboBox.FormattingEnabled = True
        Me.operation_ComboBox.Location = New System.Drawing.Point(180, 177)
        Me.operation_ComboBox.Name = "operation_ComboBox"
        Me.operation_ComboBox.Size = New System.Drawing.Size(121, 24)
        Me.operation_ComboBox.TabIndex = 7
        '
        'clear_Button
        '
        Me.clear_Button.AutoSize = True
        Me.clear_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.clear_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.clear_Button.ForeColor = System.Drawing.Color.Green
        Me.clear_Button.Location = New System.Drawing.Point(408, 173)
        Me.clear_Button.Name = "clear_Button"
        Me.clear_Button.Size = New System.Drawing.Size(51, 26)
        Me.clear_Button.TabIndex = 8
        Me.clear_Button.Text = "Clear"
        Me.clear_Button.UseVisualStyleBackColor = True
        '
        'aggr_TreeView
        '
        Me.aggr_TreeView.CheckBoxes = True
        Me.aggr_TreeView.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.aggr_TreeView.ForeColor = System.Drawing.Color.Green
        Me.aggr_TreeView.Location = New System.Drawing.Point(18, 280)
        Me.aggr_TreeView.Name = "aggr_TreeView"
        Me.aggr_TreeView.Size = New System.Drawing.Size(441, 182)
        Me.aggr_TreeView.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.close_PictureBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cancel_Button)
        Me.Panel1.Controls.Add(Me.aggr_TreeView)
        Me.Panel1.Controls.Add(Me.ok_Button)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.operation_ComboBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.aggr_ComboBox)
        Me.Panel1.Controls.Add(Me.clear_Button)
        Me.Panel1.Controls.Add(Me.aggr_CheckBox)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(630, 507)
        Me.Panel1.TabIndex = 10
        '
        'close_PictureBox
        '
        Me.close_PictureBox.Image = Global.DynamicReportGenerator.My.Resources.Resources.closeButton
        Me.close_PictureBox.Location = New System.Drawing.Point(595, 3)
        Me.close_PictureBox.Name = "close_PictureBox"
        Me.close_PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.close_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.close_PictureBox.TabIndex = 17
        Me.close_PictureBox.TabStop = False
        '
        'drg_filters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(645, 520)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "drg_filters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Reports Generator : Filters"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents aggr_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents aggr_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ok_Button As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents operation_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents clear_Button As System.Windows.Forms.Button
    Friend WithEvents aggr_TreeView As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents close_PictureBox As System.Windows.Forms.PictureBox
End Class
