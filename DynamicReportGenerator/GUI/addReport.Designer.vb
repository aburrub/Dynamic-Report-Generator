<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addReport
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
        Me.report_name_TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rep_cat_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.close_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'report_name_TextBox
        '
        Me.report_name_TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.report_name_TextBox.ForeColor = System.Drawing.Color.Green
        Me.report_name_TextBox.Location = New System.Drawing.Point(136, 54)
        Me.report_name_TextBox.Name = "report_name_TextBox"
        Me.report_name_TextBox.Size = New System.Drawing.Size(184, 23)
        Me.report_name_TextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(13, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Report Name"
        '
        'rep_cat_ComboBox
        '
        Me.rep_cat_ComboBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rep_cat_ComboBox.ForeColor = System.Drawing.Color.Green
        Me.rep_cat_ComboBox.FormattingEnabled = True
        Me.rep_cat_ComboBox.Location = New System.Drawing.Point(136, 83)
        Me.rep_cat_ComboBox.Name = "rep_cat_ComboBox"
        Me.rep_cat_ComboBox.Size = New System.Drawing.Size(184, 24)
        Me.rep_cat_ComboBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Report Category"
        '
        'ok_Button
        '
        Me.ok_Button.AutoSize = True
        Me.ok_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ok_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ok_Button.ForeColor = System.Drawing.Color.Green
        Me.ok_Button.Location = New System.Drawing.Point(286, 113)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(34, 26)
        Me.ok_Button.TabIndex = 3
        Me.ok_Button.Text = "Ok"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'cancel_Button
        '
        Me.cancel_Button.AutoSize = True
        Me.cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cancel_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cancel_Button.ForeColor = System.Drawing.Color.Green
        Me.cancel_Button.Location = New System.Drawing.Point(220, 113)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(60, 26)
        Me.cancel_Button.TabIndex = 4
        Me.cancel_Button.Text = "Cancel"
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.close_PictureBox)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cancel_Button)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ok_Button)
        Me.Panel1.Controls.Add(Me.report_name_TextBox)
        Me.Panel1.Controls.Add(Me.rep_cat_ComboBox)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 196)
        Me.Panel1.TabIndex = 4
        '
        'close_PictureBox
        '
        Me.close_PictureBox.Image = Global.DynamicReportGenerator.My.Resources.Resources.closeButton
        Me.close_PictureBox.Location = New System.Drawing.Point(295, 3)
        Me.close_PictureBox.Name = "close_PictureBox"
        Me.close_PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.close_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.close_PictureBox.TabIndex = 11
        Me.close_PictureBox.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(13, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Add Report"
        '
        'addReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(354, 219)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "addReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dynamic Reports Generator | Add Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.close_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents report_name_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rep_cat_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ok_Button As System.Windows.Forms.Button
    Friend WithEvents cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents close_PictureBox As System.Windows.Forms.PictureBox
End Class
