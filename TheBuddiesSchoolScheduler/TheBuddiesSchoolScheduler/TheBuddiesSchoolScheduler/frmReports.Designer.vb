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
        Me.ExportToExcel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbWeek = New System.Windows.Forms.TabPage()
        Me.tbMon = New System.Windows.Forms.TabPage()
        Me.tbTues = New System.Windows.Forms.TabPage()
        Me.tbWed = New System.Windows.Forms.TabPage()
        Me.tbThurs = New System.Windows.Forms.TabPage()
        Me.tbFri = New System.Windows.Forms.TabPage()
        Me.tbSat = New System.Windows.Forms.TabPage()
        Me.tbSun = New System.Windows.Forms.TabPage()
        Me.tbBaker = New System.Windows.Forms.TabPage()
        Me.tbGeise = New System.Windows.Forms.TabPage()
        Me.tbGunnett = New System.Windows.Forms.TabPage()
        Me.tbLanghals = New System.Windows.Forms.TabPage()
        Me.tbRingenberg = New System.Windows.Forms.TabPage()
        Me.tbSamimi = New System.Windows.Forms.TabPage()
        Me.tbSchneider = New System.Windows.Forms.TabPage()
        Me.tbWardzala = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblTerm = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
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
        'ExportToExcel
        '
        Me.ExportToExcel.Location = New System.Drawing.Point(659, 28)
        Me.ExportToExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportToExcel.Name = "ExportToExcel"
        Me.ExportToExcel.Size = New System.Drawing.Size(129, 36)
        Me.ExportToExcel.TabIndex = 50
        Me.ExportToExcel.Text = "Print to Excel"
        Me.ExportToExcel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbWeek)
        Me.TabControl1.Controls.Add(Me.tbMon)
        Me.TabControl1.Controls.Add(Me.tbTues)
        Me.TabControl1.Controls.Add(Me.tbWed)
        Me.TabControl1.Controls.Add(Me.tbThurs)
        Me.TabControl1.Controls.Add(Me.tbFri)
        Me.TabControl1.Controls.Add(Me.tbSat)
        Me.TabControl1.Controls.Add(Me.tbSun)
        Me.TabControl1.Controls.Add(Me.tbBaker)
        Me.TabControl1.Controls.Add(Me.tbGeise)
        Me.TabControl1.Controls.Add(Me.tbGunnett)
        Me.TabControl1.Controls.Add(Me.tbLanghals)
        Me.TabControl1.Controls.Add(Me.tbRingenberg)
        Me.TabControl1.Controls.Add(Me.tbSamimi)
        Me.TabControl1.Controls.Add(Me.tbSchneider)
        Me.TabControl1.Controls.Add(Me.tbWardzala)
        Me.TabControl1.Location = New System.Drawing.Point(23, 85)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(765, 617)
        Me.TabControl1.TabIndex = 51
        '
        'tbWeek
        '
        Me.tbWeek.Location = New System.Drawing.Point(4, 25)
        Me.tbWeek.Margin = New System.Windows.Forms.Padding(4)
        Me.tbWeek.Name = "tbWeek"
        Me.tbWeek.Padding = New System.Windows.Forms.Padding(4)
        Me.tbWeek.Size = New System.Drawing.Size(757, 588)
        Me.tbWeek.TabIndex = 0
        Me.tbWeek.Text = "Week"
        Me.tbWeek.UseVisualStyleBackColor = True
        '
        'tbMon
        '
        Me.tbMon.Location = New System.Drawing.Point(4, 25)
        Me.tbMon.Margin = New System.Windows.Forms.Padding(4)
        Me.tbMon.Name = "tbMon"
        Me.tbMon.Padding = New System.Windows.Forms.Padding(4)
        Me.tbMon.Size = New System.Drawing.Size(757, 588)
        Me.tbMon.TabIndex = 1
        Me.tbMon.Text = "Mon"
        Me.tbMon.UseVisualStyleBackColor = True
        '
        'tbTues
        '
        Me.tbTues.Location = New System.Drawing.Point(4, 25)
        Me.tbTues.Margin = New System.Windows.Forms.Padding(4)
        Me.tbTues.Name = "tbTues"
        Me.tbTues.Padding = New System.Windows.Forms.Padding(4)
        Me.tbTues.Size = New System.Drawing.Size(757, 588)
        Me.tbTues.TabIndex = 2
        Me.tbTues.Text = "Tues"
        Me.tbTues.UseVisualStyleBackColor = True
        '
        'tbWed
        '
        Me.tbWed.Location = New System.Drawing.Point(4, 25)
        Me.tbWed.Margin = New System.Windows.Forms.Padding(4)
        Me.tbWed.Name = "tbWed"
        Me.tbWed.Padding = New System.Windows.Forms.Padding(4)
        Me.tbWed.Size = New System.Drawing.Size(757, 588)
        Me.tbWed.TabIndex = 3
        Me.tbWed.Text = "Wed"
        Me.tbWed.UseVisualStyleBackColor = True
        '
        'tbThurs
        '
        Me.tbThurs.Location = New System.Drawing.Point(4, 25)
        Me.tbThurs.Margin = New System.Windows.Forms.Padding(4)
        Me.tbThurs.Name = "tbThurs"
        Me.tbThurs.Size = New System.Drawing.Size(757, 588)
        Me.tbThurs.TabIndex = 4
        Me.tbThurs.Text = "Thurs"
        Me.tbThurs.UseVisualStyleBackColor = True
        '
        'tbFri
        '
        Me.tbFri.Location = New System.Drawing.Point(4, 25)
        Me.tbFri.Margin = New System.Windows.Forms.Padding(4)
        Me.tbFri.Name = "tbFri"
        Me.tbFri.Size = New System.Drawing.Size(757, 588)
        Me.tbFri.TabIndex = 5
        Me.tbFri.Text = "Fri"
        Me.tbFri.UseVisualStyleBackColor = True
        '
        'tbSat
        '
        Me.tbSat.Location = New System.Drawing.Point(4, 25)
        Me.tbSat.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSat.Name = "tbSat"
        Me.tbSat.Size = New System.Drawing.Size(757, 588)
        Me.tbSat.TabIndex = 6
        Me.tbSat.Text = "Sat"
        Me.tbSat.UseVisualStyleBackColor = True
        '
        'tbSun
        '
        Me.tbSun.Location = New System.Drawing.Point(4, 25)
        Me.tbSun.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSun.Name = "tbSun"
        Me.tbSun.Size = New System.Drawing.Size(757, 588)
        Me.tbSun.TabIndex = 7
        Me.tbSun.Text = "Sun"
        Me.tbSun.UseVisualStyleBackColor = True
        '
        'tbBaker
        '
        Me.tbBaker.Location = New System.Drawing.Point(4, 25)
        Me.tbBaker.Margin = New System.Windows.Forms.Padding(4)
        Me.tbBaker.Name = "tbBaker"
        Me.tbBaker.Size = New System.Drawing.Size(757, 588)
        Me.tbBaker.TabIndex = 15
        Me.tbBaker.Text = "Baker"
        Me.tbBaker.UseVisualStyleBackColor = True
        '
        'tbGeise
        '
        Me.tbGeise.Location = New System.Drawing.Point(4, 25)
        Me.tbGeise.Margin = New System.Windows.Forms.Padding(4)
        Me.tbGeise.Name = "tbGeise"
        Me.tbGeise.Size = New System.Drawing.Size(757, 588)
        Me.tbGeise.TabIndex = 8
        Me.tbGeise.Text = "Geise"
        Me.tbGeise.UseVisualStyleBackColor = True
        '
        'tbGunnett
        '
        Me.tbGunnett.Location = New System.Drawing.Point(4, 25)
        Me.tbGunnett.Margin = New System.Windows.Forms.Padding(4)
        Me.tbGunnett.Name = "tbGunnett"
        Me.tbGunnett.Size = New System.Drawing.Size(757, 588)
        Me.tbGunnett.TabIndex = 11
        Me.tbGunnett.Text = "Gunnett"
        Me.tbGunnett.UseVisualStyleBackColor = True
        '
        'tbLanghals
        '
        Me.tbLanghals.Location = New System.Drawing.Point(4, 25)
        Me.tbLanghals.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLanghals.Name = "tbLanghals"
        Me.tbLanghals.Size = New System.Drawing.Size(757, 588)
        Me.tbLanghals.TabIndex = 13
        Me.tbLanghals.Text = "Langhals"
        Me.tbLanghals.UseVisualStyleBackColor = True
        '
        'tbRingenberg
        '
        Me.tbRingenberg.Location = New System.Drawing.Point(4, 25)
        Me.tbRingenberg.Margin = New System.Windows.Forms.Padding(4)
        Me.tbRingenberg.Name = "tbRingenberg"
        Me.tbRingenberg.Size = New System.Drawing.Size(757, 588)
        Me.tbRingenberg.TabIndex = 9
        Me.tbRingenberg.Text = "Ringenberg"
        Me.tbRingenberg.UseVisualStyleBackColor = True
        '
        'tbSamimi
        '
        Me.tbSamimi.Location = New System.Drawing.Point(4, 25)
        Me.tbSamimi.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSamimi.Name = "tbSamimi"
        Me.tbSamimi.Size = New System.Drawing.Size(757, 588)
        Me.tbSamimi.TabIndex = 12
        Me.tbSamimi.Text = "Samimi"
        Me.tbSamimi.UseVisualStyleBackColor = True
        '
        'tbSchneider
        '
        Me.tbSchneider.Location = New System.Drawing.Point(4, 25)
        Me.tbSchneider.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSchneider.Name = "tbSchneider"
        Me.tbSchneider.Size = New System.Drawing.Size(757, 588)
        Me.tbSchneider.TabIndex = 10
        Me.tbSchneider.Text = "Schneider"
        Me.tbSchneider.UseVisualStyleBackColor = True
        '
        'tbWardzala
        '
        Me.tbWardzala.Location = New System.Drawing.Point(4, 25)
        Me.tbWardzala.Margin = New System.Windows.Forms.Padding(4)
        Me.tbWardzala.Name = "tbWardzala"
        Me.tbWardzala.Size = New System.Drawing.Size(757, 588)
        Me.tbWardzala.TabIndex = 14
        Me.tbWardzala.Text = "Wardzala"
        Me.tbWardzala.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(683, 709)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(547, 709)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 28)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblTerm
        '
        Me.lblTerm.AutoSize = True
        Me.lblTerm.Location = New System.Drawing.Point(409, 28)
        Me.lblTerm.Name = "lblTerm"
        Me.lblTerm.Size = New System.Drawing.Size(51, 17)
        Me.lblTerm.TabIndex = 54
        Me.lblTerm.Text = "Label2"
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 748)
        Me.Controls.Add(Me.lblTerm)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.ExportToExcel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies Easy Scheduler"
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExportToExcel As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbWeek As System.Windows.Forms.TabPage
    Friend WithEvents tbMon As System.Windows.Forms.TabPage
    Friend WithEvents tbTues As System.Windows.Forms.TabPage
    Friend WithEvents tbWed As System.Windows.Forms.TabPage
    Friend WithEvents tbThurs As System.Windows.Forms.TabPage
    Friend WithEvents tbFri As System.Windows.Forms.TabPage
    Friend WithEvents tbSat As System.Windows.Forms.TabPage
    Friend WithEvents tbSun As System.Windows.Forms.TabPage
    Friend WithEvents tbGeise As System.Windows.Forms.TabPage
    Friend WithEvents tbGunnett As System.Windows.Forms.TabPage
    Friend WithEvents tbRingenberg As System.Windows.Forms.TabPage
    Friend WithEvents tbSchneider As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tbBaker As System.Windows.Forms.TabPage
    Friend WithEvents tbLanghals As System.Windows.Forms.TabPage
    Friend WithEvents tbSamimi As System.Windows.Forms.TabPage
    Friend WithEvents tbWardzala As System.Windows.Forms.TabPage
    Friend WithEvents lblTerm As System.Windows.Forms.Label
End Class
