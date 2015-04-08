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
        Me.tbWeek = New System.Windows.Forms.TabPage()
        Me.tbTues = New System.Windows.Forms.TabPage()
        Me.tbWed = New System.Windows.Forms.TabPage()
        Me.tbThurs = New System.Windows.Forms.TabPage()
        Me.tbFri = New System.Windows.Forms.TabPage()
        Me.tbSat = New System.Windows.Forms.TabPage()
        Me.tbSun = New System.Windows.Forms.TabPage()
        Me.tbGeise = New System.Windows.Forms.TabPage()
        Me.tbGunnett = New System.Windows.Forms.TabPage()
        Me.tbRingenberg = New System.Windows.Forms.TabPage()
        Me.tbSchneider = New System.Windows.Forms.TabPage()
        Me.tbMon = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tbSamimi = New System.Windows.Forms.TabPage()
        Me.tbLanghals = New System.Windows.Forms.TabPage()
        Me.tbWardzala = New System.Windows.Forms.TabPage()
        Me.tbBaker = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 43)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reports"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(494, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 29)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Print to Excel"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.TabControl1.Location = New System.Drawing.Point(17, 69)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(574, 501)
        Me.TabControl1.TabIndex = 51
        '
        'tbWeek
        '
        Me.tbWeek.Location = New System.Drawing.Point(4, 22)
        Me.tbWeek.Name = "tbWeek"
        Me.tbWeek.Padding = New System.Windows.Forms.Padding(3)
        Me.tbWeek.Size = New System.Drawing.Size(566, 475)
        Me.tbWeek.TabIndex = 0
        Me.tbWeek.Text = "Week"
        Me.tbWeek.UseVisualStyleBackColor = True
        '
        'tbTues
        '
        Me.tbTues.Location = New System.Drawing.Point(4, 22)
        Me.tbTues.Name = "tbTues"
        Me.tbTues.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTues.Size = New System.Drawing.Size(566, 475)
        Me.tbTues.TabIndex = 2
        Me.tbTues.Text = "Tues"
        Me.tbTues.UseVisualStyleBackColor = True
        '
        'tbWed
        '
        Me.tbWed.Location = New System.Drawing.Point(4, 22)
        Me.tbWed.Name = "tbWed"
        Me.tbWed.Padding = New System.Windows.Forms.Padding(3)
        Me.tbWed.Size = New System.Drawing.Size(566, 475)
        Me.tbWed.TabIndex = 3
        Me.tbWed.Text = "Wed"
        Me.tbWed.UseVisualStyleBackColor = True
        '
        'tbThurs
        '
        Me.tbThurs.Location = New System.Drawing.Point(4, 22)
        Me.tbThurs.Name = "tbThurs"
        Me.tbThurs.Size = New System.Drawing.Size(566, 475)
        Me.tbThurs.TabIndex = 4
        Me.tbThurs.Text = "Thurs"
        Me.tbThurs.UseVisualStyleBackColor = True
        '
        'tbFri
        '
        Me.tbFri.Location = New System.Drawing.Point(4, 22)
        Me.tbFri.Name = "tbFri"
        Me.tbFri.Size = New System.Drawing.Size(566, 475)
        Me.tbFri.TabIndex = 5
        Me.tbFri.Text = "Fri"
        Me.tbFri.UseVisualStyleBackColor = True
        '
        'tbSat
        '
        Me.tbSat.Location = New System.Drawing.Point(4, 22)
        Me.tbSat.Name = "tbSat"
        Me.tbSat.Size = New System.Drawing.Size(566, 475)
        Me.tbSat.TabIndex = 6
        Me.tbSat.Text = "Sat"
        Me.tbSat.UseVisualStyleBackColor = True
        '
        'tbSun
        '
        Me.tbSun.Location = New System.Drawing.Point(4, 22)
        Me.tbSun.Name = "tbSun"
        Me.tbSun.Size = New System.Drawing.Size(566, 475)
        Me.tbSun.TabIndex = 7
        Me.tbSun.Text = "Sun"
        Me.tbSun.UseVisualStyleBackColor = True
        '
        'tbGeise
        '
        Me.tbGeise.Location = New System.Drawing.Point(4, 22)
        Me.tbGeise.Name = "tbGeise"
        Me.tbGeise.Size = New System.Drawing.Size(566, 475)
        Me.tbGeise.TabIndex = 8
        Me.tbGeise.Text = "Geise"
        Me.tbGeise.UseVisualStyleBackColor = True
        '
        'tbGunnett
        '
        Me.tbGunnett.Location = New System.Drawing.Point(4, 22)
        Me.tbGunnett.Name = "tbGunnett"
        Me.tbGunnett.Size = New System.Drawing.Size(566, 475)
        Me.tbGunnett.TabIndex = 11
        Me.tbGunnett.Text = "Gunnett"
        Me.tbGunnett.UseVisualStyleBackColor = True
        '
        'tbRingenberg
        '
        Me.tbRingenberg.Location = New System.Drawing.Point(4, 22)
        Me.tbRingenberg.Name = "tbRingenberg"
        Me.tbRingenberg.Size = New System.Drawing.Size(566, 475)
        Me.tbRingenberg.TabIndex = 9
        Me.tbRingenberg.Text = "Ringenberg"
        Me.tbRingenberg.UseVisualStyleBackColor = True
        '
        'tbSchneider
        '
        Me.tbSchneider.Location = New System.Drawing.Point(4, 22)
        Me.tbSchneider.Name = "tbSchneider"
        Me.tbSchneider.Size = New System.Drawing.Size(566, 475)
        Me.tbSchneider.TabIndex = 10
        Me.tbSchneider.Text = "Schneider"
        Me.tbSchneider.UseVisualStyleBackColor = True
        '
        'tbMon
        '
        Me.tbMon.Location = New System.Drawing.Point(4, 22)
        Me.tbMon.Name = "tbMon"
        Me.tbMon.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMon.Size = New System.Drawing.Size(566, 475)
        Me.tbMon.TabIndex = 1
        Me.tbMon.Text = "Mon"
        Me.tbMon.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(512, 576)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(410, 576)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tbSamimi
        '
        Me.tbSamimi.Location = New System.Drawing.Point(4, 22)
        Me.tbSamimi.Name = "tbSamimi"
        Me.tbSamimi.Size = New System.Drawing.Size(566, 475)
        Me.tbSamimi.TabIndex = 12
        Me.tbSamimi.Text = "Samimi"
        Me.tbSamimi.UseVisualStyleBackColor = True
        '
        'tbLanghals
        '
        Me.tbLanghals.Location = New System.Drawing.Point(4, 22)
        Me.tbLanghals.Name = "tbLanghals"
        Me.tbLanghals.Size = New System.Drawing.Size(566, 475)
        Me.tbLanghals.TabIndex = 13
        Me.tbLanghals.Text = "Langhals"
        Me.tbLanghals.UseVisualStyleBackColor = True
        '
        'tbWardzala
        '
        Me.tbWardzala.Location = New System.Drawing.Point(4, 22)
        Me.tbWardzala.Name = "tbWardzala"
        Me.tbWardzala.Size = New System.Drawing.Size(566, 475)
        Me.tbWardzala.TabIndex = 14
        Me.tbWardzala.Text = "Wardzala"
        Me.tbWardzala.UseVisualStyleBackColor = True
        '
        'tbBaker
        '
        Me.tbBaker.Location = New System.Drawing.Point(4, 22)
        Me.tbBaker.Name = "tbBaker"
        Me.tbBaker.Size = New System.Drawing.Size(566, 475)
        Me.tbBaker.TabIndex = 15
        Me.tbBaker.Text = "Baker"
        Me.tbBaker.UseVisualStyleBackColor = True
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 608)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies Easy Scheduler"
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
End Class
