<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseMaintenance
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tcDBMaint = New System.Windows.Forms.TabControl()
        Me.tpAddClass = New System.Windows.Forms.TabPage()
        Me.btnAddClassSave = New System.Windows.Forms.Button()
        Me.chkGradClass = New System.Windows.Forms.CheckBox()
        Me.lblAddClassProfCredHours = New System.Windows.Forms.Label()
        Me.tbAddClassProfCredHour = New System.Windows.Forms.TextBox()
        Me.lblAddClassStuCredHours = New System.Windows.Forms.Label()
        Me.tbAddClassStuCredHours = New System.Windows.Forms.TextBox()
        Me.lblAddClassCourseName = New System.Windows.Forms.Label()
        Me.tbAddClassCourseName = New System.Windows.Forms.TextBox()
        Me.lblAddClassCourseNum = New System.Windows.Forms.Label()
        Me.tbAddClassCourseNum = New System.Windows.Forms.TextBox()
        Me.lblAddClassDept = New System.Windows.Forms.Label()
        Me.tbAddClassDepartment = New System.Windows.Forms.TextBox()
        Me.tpEditClass = New System.Windows.Forms.TabPage()
        Me.tpRmClass = New System.Windows.Forms.TabPage()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cbDBData = New System.Windows.Forms.ComboBox()
        Me.tpAddProf = New System.Windows.Forms.TabPage()
        Me.tpEditProf = New System.Windows.Forms.TabPage()
        Me.tpRmProf = New System.Windows.Forms.TabPage()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tcEditClass = New System.Windows.Forms.ComboBox()
        Me.chkEditClassGradClass = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbEditClassProfHr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbEditClassStuCredHr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbEditClassCourseName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbEditClassCourseNum = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbEditClassDept = New System.Windows.Forms.TextBox()
        Me.btnEditClassSave = New System.Windows.Forms.Button()
        Me.tcDBMaint.SuspendLayout()
        Me.tpAddClass.SuspendLayout()
        Me.tpEditClass.SuspendLayout()
        Me.tpRmClass.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 35)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(578, 66)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database Maintenance"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(537, 728)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 35)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tcDBMaint
        '
        Me.tcDBMaint.Controls.Add(Me.tpAddClass)
        Me.tcDBMaint.Controls.Add(Me.tpEditClass)
        Me.tcDBMaint.Controls.Add(Me.tpRmClass)
        Me.tcDBMaint.Controls.Add(Me.tpAddProf)
        Me.tcDBMaint.Controls.Add(Me.tpEditProf)
        Me.tcDBMaint.Controls.Add(Me.tpRmProf)
        Me.tcDBMaint.Location = New System.Drawing.Point(43, 104)
        Me.tcDBMaint.Name = "tcDBMaint"
        Me.tcDBMaint.SelectedIndex = 0
        Me.tcDBMaint.Size = New System.Drawing.Size(842, 616)
        Me.tcDBMaint.TabIndex = 12
        '
        'tpAddClass
        '
        Me.tpAddClass.Controls.Add(Me.btnAddClassSave)
        Me.tpAddClass.Controls.Add(Me.chkGradClass)
        Me.tpAddClass.Controls.Add(Me.lblAddClassProfCredHours)
        Me.tpAddClass.Controls.Add(Me.tbAddClassProfCredHour)
        Me.tpAddClass.Controls.Add(Me.lblAddClassStuCredHours)
        Me.tpAddClass.Controls.Add(Me.tbAddClassStuCredHours)
        Me.tpAddClass.Controls.Add(Me.lblAddClassCourseName)
        Me.tpAddClass.Controls.Add(Me.tbAddClassCourseName)
        Me.tpAddClass.Controls.Add(Me.lblAddClassCourseNum)
        Me.tpAddClass.Controls.Add(Me.tbAddClassCourseNum)
        Me.tpAddClass.Controls.Add(Me.lblAddClassDept)
        Me.tpAddClass.Controls.Add(Me.tbAddClassDepartment)
        Me.tpAddClass.Location = New System.Drawing.Point(4, 29)
        Me.tpAddClass.Name = "tpAddClass"
        Me.tpAddClass.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddClass.Size = New System.Drawing.Size(834, 583)
        Me.tpAddClass.TabIndex = 0
        Me.tpAddClass.Text = "Add Class"
        Me.tpAddClass.UseVisualStyleBackColor = True
        '
        'btnAddClassSave
        '
        Me.btnAddClassSave.Location = New System.Drawing.Point(34, 471)
        Me.btnAddClassSave.Name = "btnAddClassSave"
        Me.btnAddClassSave.Size = New System.Drawing.Size(103, 34)
        Me.btnAddClassSave.TabIndex = 11
        Me.btnAddClassSave.Text = "Save Class"
        Me.btnAddClassSave.UseVisualStyleBackColor = True
        '
        'chkGradClass
        '
        Me.chkGradClass.AutoSize = True
        Me.chkGradClass.Location = New System.Drawing.Point(34, 412)
        Me.chkGradClass.Name = "chkGradClass"
        Me.chkGradClass.Size = New System.Drawing.Size(146, 24)
        Me.chkGradClass.TabIndex = 10
        Me.chkGradClass.Text = "Graduate Class"
        Me.chkGradClass.UseVisualStyleBackColor = True
        '
        'lblAddClassProfCredHours
        '
        Me.lblAddClassProfCredHours.AutoSize = True
        Me.lblAddClassProfCredHours.Location = New System.Drawing.Point(30, 338)
        Me.lblAddClassProfCredHours.Name = "lblAddClassProfCredHours"
        Me.lblAddClassProfCredHours.Size = New System.Drawing.Size(209, 20)
        Me.lblAddClassProfCredHours.TabIndex = 9
        Me.lblAddClassProfCredHours.Text = "Professor Credit Hour Worth"
        '
        'tbAddClassProfCredHour
        '
        Me.tbAddClassProfCredHour.Location = New System.Drawing.Point(34, 361)
        Me.tbAddClassProfCredHour.Name = "tbAddClassProfCredHour"
        Me.tbAddClassProfCredHour.Size = New System.Drawing.Size(151, 26)
        Me.tbAddClassProfCredHour.TabIndex = 8
        '
        'lblAddClassStuCredHours
        '
        Me.lblAddClassStuCredHours.AutoSize = True
        Me.lblAddClassStuCredHours.Location = New System.Drawing.Point(30, 262)
        Me.lblAddClassStuCredHours.Name = "lblAddClassStuCredHours"
        Me.lblAddClassStuCredHours.Size = New System.Drawing.Size(198, 20)
        Me.lblAddClassStuCredHours.TabIndex = 7
        Me.lblAddClassStuCredHours.Text = "Student Credit Hour Worth"
        '
        'tbAddClassStuCredHours
        '
        Me.tbAddClassStuCredHours.Location = New System.Drawing.Point(34, 285)
        Me.tbAddClassStuCredHours.Name = "tbAddClassStuCredHours"
        Me.tbAddClassStuCredHours.Size = New System.Drawing.Size(151, 26)
        Me.tbAddClassStuCredHours.TabIndex = 6
        '
        'lblAddClassCourseName
        '
        Me.lblAddClassCourseName.AutoSize = True
        Me.lblAddClassCourseName.Location = New System.Drawing.Point(30, 194)
        Me.lblAddClassCourseName.Name = "lblAddClassCourseName"
        Me.lblAddClassCourseName.Size = New System.Drawing.Size(106, 20)
        Me.lblAddClassCourseName.TabIndex = 5
        Me.lblAddClassCourseName.Text = "Course Name"
        '
        'tbAddClassCourseName
        '
        Me.tbAddClassCourseName.Location = New System.Drawing.Point(34, 217)
        Me.tbAddClassCourseName.Name = "tbAddClassCourseName"
        Me.tbAddClassCourseName.Size = New System.Drawing.Size(151, 26)
        Me.tbAddClassCourseName.TabIndex = 4
        '
        'lblAddClassCourseNum
        '
        Me.lblAddClassCourseNum.AutoSize = True
        Me.lblAddClassCourseNum.Location = New System.Drawing.Point(30, 114)
        Me.lblAddClassCourseNum.Name = "lblAddClassCourseNum"
        Me.lblAddClassCourseNum.Size = New System.Drawing.Size(120, 20)
        Me.lblAddClassCourseNum.TabIndex = 3
        Me.lblAddClassCourseNum.Text = "Course Number"
        '
        'tbAddClassCourseNum
        '
        Me.tbAddClassCourseNum.Location = New System.Drawing.Point(34, 137)
        Me.tbAddClassCourseNum.Name = "tbAddClassCourseNum"
        Me.tbAddClassCourseNum.Size = New System.Drawing.Size(151, 26)
        Me.tbAddClassCourseNum.TabIndex = 2
        '
        'lblAddClassDept
        '
        Me.lblAddClassDept.AutoSize = True
        Me.lblAddClassDept.Location = New System.Drawing.Point(30, 42)
        Me.lblAddClassDept.Name = "lblAddClassDept"
        Me.lblAddClassDept.Size = New System.Drawing.Size(94, 20)
        Me.lblAddClassDept.TabIndex = 1
        Me.lblAddClassDept.Text = "Department"
        '
        'tbAddClassDepartment
        '
        Me.tbAddClassDepartment.Location = New System.Drawing.Point(34, 65)
        Me.tbAddClassDepartment.Name = "tbAddClassDepartment"
        Me.tbAddClassDepartment.Size = New System.Drawing.Size(151, 26)
        Me.tbAddClassDepartment.TabIndex = 0
        '
        'tpEditClass
        '
        Me.tpEditClass.Controls.Add(Me.btnEditClassSave)
        Me.tpEditClass.Controls.Add(Me.chkEditClassGradClass)
        Me.tpEditClass.Controls.Add(Me.Label2)
        Me.tpEditClass.Controls.Add(Me.tbEditClassProfHr)
        Me.tpEditClass.Controls.Add(Me.Label3)
        Me.tpEditClass.Controls.Add(Me.tbEditClassStuCredHr)
        Me.tpEditClass.Controls.Add(Me.Label4)
        Me.tpEditClass.Controls.Add(Me.tbEditClassCourseName)
        Me.tpEditClass.Controls.Add(Me.Label5)
        Me.tpEditClass.Controls.Add(Me.tbEditClassCourseNum)
        Me.tpEditClass.Controls.Add(Me.Label6)
        Me.tpEditClass.Controls.Add(Me.tbEditClassDept)
        Me.tpEditClass.Controls.Add(Me.tcEditClass)
        Me.tpEditClass.Location = New System.Drawing.Point(4, 29)
        Me.tpEditClass.Name = "tpEditClass"
        Me.tpEditClass.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEditClass.Size = New System.Drawing.Size(834, 583)
        Me.tpEditClass.TabIndex = 1
        Me.tpEditClass.Text = "Edit Class"
        Me.tpEditClass.UseVisualStyleBackColor = True
        '
        'tpRmClass
        '
        Me.tpRmClass.Controls.Add(Me.btnRemove)
        Me.tpRmClass.Controls.Add(Me.cbDBData)
        Me.tpRmClass.Location = New System.Drawing.Point(4, 29)
        Me.tpRmClass.Name = "tpRmClass"
        Me.tpRmClass.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRmClass.Size = New System.Drawing.Size(834, 583)
        Me.tpRmClass.TabIndex = 2
        Me.tpRmClass.Text = "Remove Class"
        Me.tpRmClass.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(403, 156)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(143, 38)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'cbDBData
        '
        Me.cbDBData.FormattingEnabled = True
        Me.cbDBData.Location = New System.Drawing.Point(89, 83)
        Me.cbDBData.Name = "cbDBData"
        Me.cbDBData.Size = New System.Drawing.Size(401, 28)
        Me.cbDBData.TabIndex = 2
        '
        'tpAddProf
        '
        Me.tpAddProf.Location = New System.Drawing.Point(4, 29)
        Me.tpAddProf.Name = "tpAddProf"
        Me.tpAddProf.Size = New System.Drawing.Size(834, 583)
        Me.tpAddProf.TabIndex = 3
        Me.tpAddProf.Text = "Add Professor"
        Me.tpAddProf.UseVisualStyleBackColor = True
        '
        'tpEditProf
        '
        Me.tpEditProf.Location = New System.Drawing.Point(4, 29)
        Me.tpEditProf.Name = "tpEditProf"
        Me.tpEditProf.Size = New System.Drawing.Size(834, 583)
        Me.tpEditProf.TabIndex = 4
        Me.tpEditProf.Text = "Edit Professor"
        Me.tpEditProf.UseVisualStyleBackColor = True
        '
        'tpRmProf
        '
        Me.tpRmProf.Location = New System.Drawing.Point(4, 29)
        Me.tpRmProf.Name = "tpRmProf"
        Me.tpRmProf.Size = New System.Drawing.Size(834, 583)
        Me.tpRmProf.TabIndex = 5
        Me.tpRmProf.Text = "Remove Professor"
        Me.tpRmProf.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(380, 728)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(211, 728)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tcEditClass
        '
        Me.tcEditClass.FormattingEnabled = True
        Me.tcEditClass.Location = New System.Drawing.Point(45, 38)
        Me.tcEditClass.Name = "tcEditClass"
        Me.tcEditClass.Size = New System.Drawing.Size(401, 28)
        Me.tcEditClass.TabIndex = 0
        '
        'chkEditClassGradClass
        '
        Me.chkEditClassGradClass.AutoSize = True
        Me.chkEditClassGradClass.Location = New System.Drawing.Point(56, 460)
        Me.chkEditClassGradClass.Name = "chkEditClassGradClass"
        Me.chkEditClassGradClass.Size = New System.Drawing.Size(146, 24)
        Me.chkEditClassGradClass.TabIndex = 21
        Me.chkEditClassGradClass.Text = "Graduate Class"
        Me.chkEditClassGradClass.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 386)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Professor Credit Hour Worth"
        '
        'tbEditClassProfHr
        '
        Me.tbEditClassProfHr.Location = New System.Drawing.Point(56, 409)
        Me.tbEditClassProfHr.Name = "tbEditClassProfHr"
        Me.tbEditClassProfHr.Size = New System.Drawing.Size(151, 26)
        Me.tbEditClassProfHr.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 310)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Student Credit Hour Worth"
        '
        'tbEditClassStuCredHr
        '
        Me.tbEditClassStuCredHr.Location = New System.Drawing.Point(56, 333)
        Me.tbEditClassStuCredHr.Name = "tbEditClassStuCredHr"
        Me.tbEditClassStuCredHr.Size = New System.Drawing.Size(151, 26)
        Me.tbEditClassStuCredHr.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Course Name"
        '
        'tbEditClassCourseName
        '
        Me.tbEditClassCourseName.Location = New System.Drawing.Point(56, 265)
        Me.tbEditClassCourseName.Name = "tbEditClassCourseName"
        Me.tbEditClassCourseName.Size = New System.Drawing.Size(151, 26)
        Me.tbEditClassCourseName.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Course Number"
        '
        'tbEditClassCourseNum
        '
        Me.tbEditClassCourseNum.Location = New System.Drawing.Point(56, 185)
        Me.tbEditClassCourseNum.Name = "tbEditClassCourseNum"
        Me.tbEditClassCourseNum.Size = New System.Drawing.Size(151, 26)
        Me.tbEditClassCourseNum.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Department"
        '
        'tbEditClassDept
        '
        Me.tbEditClassDept.Location = New System.Drawing.Point(56, 113)
        Me.tbEditClassDept.Name = "tbEditClassDept"
        Me.tbEditClassDept.Size = New System.Drawing.Size(151, 26)
        Me.tbEditClassDept.TabIndex = 11
        '
        'btnEditClassSave
        '
        Me.btnEditClassSave.Location = New System.Drawing.Point(56, 512)
        Me.btnEditClassSave.Name = "btnEditClassSave"
        Me.btnEditClassSave.Size = New System.Drawing.Size(143, 38)
        Me.btnEditClassSave.TabIndex = 22
        Me.btnEditClassSave.Text = "Save"
        Me.btnEditClassSave.UseVisualStyleBackColor = True
        '
        'frmDatabaseMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 782)
        Me.Controls.Add(Me.tcDBMaint)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmDatabaseMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies Easy Scheduler"
        Me.tcDBMaint.ResumeLayout(False)
        Me.tpAddClass.ResumeLayout(False)
        Me.tpAddClass.PerformLayout()
        Me.tpEditClass.ResumeLayout(False)
        Me.tpEditClass.PerformLayout()
        Me.tpRmClass.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tcDBMaint As System.Windows.Forms.TabControl
    Friend WithEvents tpAddClass As System.Windows.Forms.TabPage
    Friend WithEvents tpEditClass As System.Windows.Forms.TabPage
    Friend WithEvents tpRmClass As System.Windows.Forms.TabPage
    Friend WithEvents tpAddProf As System.Windows.Forms.TabPage
    Friend WithEvents tpEditProf As System.Windows.Forms.TabPage
    Friend WithEvents tpRmProf As System.Windows.Forms.TabPage
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents cbDBData As System.Windows.Forms.ComboBox
    Friend WithEvents tbAddClassDepartment As System.Windows.Forms.TextBox
    Friend WithEvents lblAddClassDept As System.Windows.Forms.Label
    Friend WithEvents lblAddClassCourseNum As System.Windows.Forms.Label
    Friend WithEvents tbAddClassCourseNum As System.Windows.Forms.TextBox
    Friend WithEvents chkGradClass As System.Windows.Forms.CheckBox
    Friend WithEvents lblAddClassProfCredHours As System.Windows.Forms.Label
    Friend WithEvents tbAddClassProfCredHour As System.Windows.Forms.TextBox
    Friend WithEvents lblAddClassStuCredHours As System.Windows.Forms.Label
    Friend WithEvents tbAddClassStuCredHours As System.Windows.Forms.TextBox
    Friend WithEvents lblAddClassCourseName As System.Windows.Forms.Label
    Friend WithEvents tbAddClassCourseName As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAddClassSave As System.Windows.Forms.Button
    Friend WithEvents tcEditClass As System.Windows.Forms.ComboBox
    Friend WithEvents chkEditClassGradClass As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbEditClassProfHr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbEditClassStuCredHr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbEditClassCourseName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbEditClassCourseNum As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbEditClassDept As System.Windows.Forms.TextBox
    Friend WithEvents btnEditClassSave As System.Windows.Forms.Button
End Class
