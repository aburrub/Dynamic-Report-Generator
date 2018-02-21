<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class removeReport
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
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rep_name_ListBox = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.close_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ok_Button
        '
        Me.ok_Button.AutoSize = True
        Me.ok_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ok_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ok_Button.ForeColor = System.Drawing.Color.Green
        Me.ok_Button.Location = New System.Drawing.Point(696, 394)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(34, 26)
        Me.ok_Button.TabIndex = 9
        Me.ok_Button.Text = "Ok"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(4, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Report Name"
        '
        'rep_name_ListBox
        '
        Me.rep_name_ListBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rep_name_ListBox.ForeColor = System.Drawing.Color.Green
        Me.rep_name_ListBox.FormattingEnabled = True
        Me.rep_name_ListBox.ItemHeight = 16
        Me.rep_name_ListBox.Location = New System.Drawing.Point(7, 48)
        Me.rep_name_ListBox.Name = "rep_name_ListBox"
        Me.rep_name_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.rep_name_ListBox.Size = New System.Drawing.Size(723, 340)
        Me.rep_name_ListBox.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.close_PictureBox)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.rep_name_ListBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ok_Button)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 435)
        Me.Panel1.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(3, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 19)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Remove A Report"
        '
        'close_PictureBox
        '
        Me.close_PictureBox.Image = Global.DynamicReportGenerator.My.Resources.Resources.closeButton
        Me.close_PictureBox.Location = New System.Drawing.Point(698, 9)
        Me.close_PictureBox.Name = "close_PictureBox"
        Me.close_PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.close_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.close_PictureBox.TabIndex = 16
        Me.close_PictureBox.TabStop = False
        '
        'removeReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(769, 459)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "removeReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Reports Generator | Remove Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ok_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rep_name_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents close_PictureBox As System.Windows.Forms.PictureBox
End Class
