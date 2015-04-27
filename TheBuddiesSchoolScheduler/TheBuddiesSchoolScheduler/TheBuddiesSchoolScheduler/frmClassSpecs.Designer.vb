<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClassSpecs
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
        Me.lblClass = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSunday = New System.Windows.Forms.CheckBox()
        Me.chkSaturday = New System.Windows.Forms.CheckBox()
        Me.chkWednesday = New System.Windows.Forms.CheckBox()
        Me.chkMonday = New System.Windows.Forms.CheckBox()
        Me.chkFriday = New System.Windows.Forms.CheckBox()
        Me.chkThursday = New System.Windows.Forms.CheckBox()
        Me.chkTuesday = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblClassName = New System.Windows.Forms.Label()
        Me.cboProfessor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRoom = New System.Windows.Forms.ComboBox()
        Me.cboEndTime = New System.Windows.Forms.ComboBox()
        Me.cboStartTime = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClass.Location = New System.Drawing.Point(13, 21)
        Me.lblClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(0, 20)
        Me.lblClass.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 114)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Professor:"
        '
        'chkSunday
        '
        Me.chkSunday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSunday.Location = New System.Drawing.Point(316, 322)
        Me.chkSunday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkSunday.Name = "chkSunday"
        Me.chkSunday.Size = New System.Drawing.Size(45, 68)
        Me.chkSunday.TabIndex = 31
        Me.chkSunday.Text = "Sun"
        Me.chkSunday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkSunday.UseVisualStyleBackColor = True
        '
        'chkSaturday
        '
        Me.chkSaturday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSaturday.Location = New System.Drawing.Point(272, 322)
        Me.chkSaturday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkSaturday.Name = "chkSaturday"
        Me.chkSaturday.Size = New System.Drawing.Size(45, 68)
        Me.chkSaturday.TabIndex = 30
        Me.chkSaturday.Text = "Sat"
        Me.chkSaturday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkSaturday.UseVisualStyleBackColor = True
        '
        'chkWednesday
        '
        Me.chkWednesday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkWednesday.Location = New System.Drawing.Point(136, 322)
        Me.chkWednesday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkWednesday.Name = "chkWednesday"
        Me.chkWednesday.Size = New System.Drawing.Size(45, 68)
        Me.chkWednesday.TabIndex = 29
        Me.chkWednesday.Text = "W"
        Me.chkWednesday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkWednesday.UseVisualStyleBackColor = True
        '
        'chkMonday
        '
        Me.chkMonday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMonday.Location = New System.Drawing.Point(46, 322)
        Me.chkMonday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkMonday.Name = "chkMonday"
        Me.chkMonday.Size = New System.Drawing.Size(45, 68)
        Me.chkMonday.TabIndex = 28
        Me.chkMonday.Text = "M"
        Me.chkMonday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkMonday.UseVisualStyleBackColor = True
        '
        'chkFriday
        '
        Me.chkFriday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFriday.Location = New System.Drawing.Point(226, 322)
        Me.chkFriday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkFriday.Name = "chkFriday"
        Me.chkFriday.Size = New System.Drawing.Size(45, 68)
        Me.chkFriday.TabIndex = 27
        Me.chkFriday.Text = "F"
        Me.chkFriday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkFriday.UseVisualStyleBackColor = True
        '
        'chkThursday
        '
        Me.chkThursday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkThursday.Location = New System.Drawing.Point(182, 322)
        Me.chkThursday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkThursday.Name = "chkThursday"
        Me.chkThursday.Size = New System.Drawing.Size(45, 68)
        Me.chkThursday.TabIndex = 26
        Me.chkThursday.Text = "H"
        Me.chkThursday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkThursday.UseVisualStyleBackColor = True
        '
        'chkTuesday
        '
        Me.chkTuesday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTuesday.Location = New System.Drawing.Point(92, 322)
        Me.chkTuesday.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTuesday.Name = "chkTuesday"
        Me.chkTuesday.Size = New System.Drawing.Size(45, 68)
        Me.chkTuesday.TabIndex = 25
        Me.chkTuesday.Text = "T"
        Me.chkTuesday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkTuesday.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(36, 163)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Start:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 207)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "End:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 297)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Repeating:"
        '
        'btnSave
        '
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(62, 395)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(226, 395)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblClassName
        '
        Me.lblClassName.AutoSize = True
        Me.lblClassName.Location = New System.Drawing.Point(119, 66)
        Me.lblClassName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClassName.Name = "lblClassName"
        Me.lblClassName.Size = New System.Drawing.Size(0, 20)
        Me.lblClassName.TabIndex = 40
        '
        'cboProfessor
        '
        Me.cboProfessor.FormattingEnabled = True
        Me.cboProfessor.Location = New System.Drawing.Point(124, 106)
        Me.cboProfessor.Name = "cboProfessor"
        Me.cboProfessor.Size = New System.Drawing.Size(147, 28)
        Me.cboProfessor.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 252)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Room:"
        '
        'cboRoom
        '
        Me.cboRoom.FormattingEnabled = True
        Me.cboRoom.Location = New System.Drawing.Point(123, 244)
        Me.cboRoom.Name = "cboRoom"
        Me.cboRoom.Size = New System.Drawing.Size(147, 28)
        Me.cboRoom.TabIndex = 43
        '
        'cboEndTime
        '
        Me.cboEndTime.FormattingEnabled = True
        Me.cboEndTime.Location = New System.Drawing.Point(124, 204)
        Me.cboEndTime.Name = "cboEndTime"
        Me.cboEndTime.Size = New System.Drawing.Size(147, 28)
        Me.cboEndTime.TabIndex = 44
        '
        'cboStartTime
        '
        Me.cboStartTime.FormattingEnabled = True
        Me.cboStartTime.Location = New System.Drawing.Point(123, 160)
        Me.cboStartTime.Name = "cboStartTime"
        Me.cboStartTime.Size = New System.Drawing.Size(147, 28)
        Me.cboStartTime.TabIndex = 45
        '
        'frmClassSpecs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 431)
        Me.Controls.Add(Me.cboStartTime)
        Me.Controls.Add(Me.cboEndTime)
        Me.Controls.Add(Me.cboRoom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboProfessor)
        Me.Controls.Add(Me.lblClassName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkSunday)
        Me.Controls.Add(Me.chkSaturday)
        Me.Controls.Add(Me.chkWednesday)
        Me.Controls.Add(Me.chkMonday)
        Me.Controls.Add(Me.chkFriday)
        Me.Controls.Add(Me.chkThursday)
        Me.Controls.Add(Me.chkTuesday)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClass)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmClassSpecs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies Easy Scheduler"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSunday As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaturday As System.Windows.Forms.CheckBox
    Friend WithEvents chkWednesday As System.Windows.Forms.CheckBox
    Friend WithEvents chkMonday As System.Windows.Forms.CheckBox
    Friend WithEvents chkFriday As System.Windows.Forms.CheckBox
    Friend WithEvents chkThursday As System.Windows.Forms.CheckBox
    Friend WithEvents chkTuesday As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblClassName As System.Windows.Forms.Label
    Friend WithEvents cboProfessor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRoom As System.Windows.Forms.ComboBox
    Friend WithEvents cboEndTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboStartTime As System.Windows.Forms.ComboBox
End Class
