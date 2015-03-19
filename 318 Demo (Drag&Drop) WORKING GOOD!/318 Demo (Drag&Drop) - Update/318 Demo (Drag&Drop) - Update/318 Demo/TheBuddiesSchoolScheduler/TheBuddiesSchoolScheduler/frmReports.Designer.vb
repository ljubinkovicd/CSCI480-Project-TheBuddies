<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 53)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reports"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(659, 28)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 36)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Print to Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabPage12)
        Me.TabControl1.Controls.Add(Me.TabPage10)
        Me.TabControl1.Controls.Add(Me.TabPage11)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(23, 85)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(765, 617)
        Me.TabControl1.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(757, 588)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Week"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Size = New System.Drawing.Size(757, 588)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tues"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Size = New System.Drawing.Size(757, 588)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Wed"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(757, 588)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Thurs"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(757, 588)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Fri"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(757, 588)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Sat"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(757, 588)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Sun"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'TabPage9
        '
        Me.TabPage9.Location = New System.Drawing.Point(4, 25)
        Me.TabPage9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(757, 588)
        Me.TabPage9.TabIndex = 8
        Me.TabPage9.Text = "Geise"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'TabPage12
        '
        Me.TabPage12.Location = New System.Drawing.Point(4, 25)
        Me.TabPage12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(757, 588)
        Me.TabPage12.TabIndex = 11
        Me.TabPage12.Text = "Gunnett"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'TabPage10
        '
        Me.TabPage10.Location = New System.Drawing.Point(4, 25)
        Me.TabPage10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(757, 588)
        Me.TabPage10.TabIndex = 9
        Me.TabPage10.Text = "Ringenberg"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'TabPage11
        '
        Me.TabPage11.Location = New System.Drawing.Point(4, 25)
        Me.TabPage11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(757, 588)
        Me.TabPage11.TabIndex = 10
        Me.TabPage11.Text = "Schneider"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(757, 588)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mon"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(683, 709)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(547, 709)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 28)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(10, 8)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(744, 580)
        Me.ReportViewer1.TabIndex = 0
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 748)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies Easy Scheduler"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
