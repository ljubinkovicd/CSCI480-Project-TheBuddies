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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
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
        Me.btnEditClassSave = New System.Windows.Forms.Button()
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
        Me.tcEditClass = New System.Windows.Forms.ComboBox()
        Me.tpRmClass = New System.Windows.Forms.TabPage()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cbDBData = New System.Windows.Forms.ComboBox()
        Me.tpAddProf = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.comboAddProfRank = New System.Windows.Forms.ComboBox()
        Me.btnAddProfSaveProf = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAddProfCredHours = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbAddProfLastName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbAddProfFirstName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbAddProfTeacherID = New System.Windows.Forms.TextBox()
        Me.tpEditProf = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.comboEditProfRank = New System.Windows.Forms.ComboBox()
        Me.cbEditProfSelectProf = New System.Windows.Forms.ComboBox()
        Me.btnEditProfessorSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbEditProfCredHours = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbEditProfLastName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbEditProfFirstName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbEditProfTeacherID = New System.Windows.Forms.TextBox()
        Me.tpRmProf = New System.Windows.Forms.TabPage()
        Me.btnRemoveProfessor = New System.Windows.Forms.Button()
        Me.cbRmProfessor = New System.Windows.Forms.ComboBox()
        Me.tpAddRoom = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioAddRoomWhite = New System.Windows.Forms.RadioButton()
        Me.radioAddRoomBlack = New System.Windows.Forms.RadioButton()
        Me.btnAddRoomSave = New System.Windows.Forms.Button()
        Me.btnAddRoomRoomColor = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAddRoomRmNumber = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAddRoomBuildingName = New System.Windows.Forms.TextBox()
        Me.tpEditRoom = New System.Windows.Forms.TabPage()
        Me.btnEditRoomSave = New System.Windows.Forms.Button()
        Me.comboEditRoom = New System.Windows.Forms.ComboBox()
        Me.btnEditRoomRoomColor = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEditRoomRmNumber = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtEditRoomBuildingName = New System.Windows.Forms.TextBox()
        Me.tpRmRoom = New System.Windows.Forms.TabPage()
        Me.btnRemoveRoom = New System.Windows.Forms.Button()
        Me.comboRemoveRoom = New System.Windows.Forms.ComboBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.dbToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radioEditRoomWhite = New System.Windows.Forms.RadioButton()
        Me.radioEditRoomBlack = New System.Windows.Forms.RadioButton()
        Me.tcDBMaint.SuspendLayout()
        Me.tpAddClass.SuspendLayout()
        Me.tpEditClass.SuspendLayout()
        Me.tpRmClass.SuspendLayout()
        Me.tpAddProf.SuspendLayout()
        Me.tpEditProf.SuspendLayout()
        Me.tpRmProf.SuspendLayout()
        Me.tpAddRoom.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpEditRoom.SuspendLayout()
        Me.tpRmRoom.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(403, 728)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 35)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "Cancel"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'tcDBMaint
        '
        Me.tcDBMaint.Controls.Add(Me.tpAddClass)
        Me.tcDBMaint.Controls.Add(Me.tpEditClass)
        Me.tcDBMaint.Controls.Add(Me.tpRmClass)
        Me.tcDBMaint.Controls.Add(Me.tpAddProf)
        Me.tcDBMaint.Controls.Add(Me.tpEditProf)
        Me.tcDBMaint.Controls.Add(Me.tpRmProf)
        Me.tcDBMaint.Controls.Add(Me.tpAddRoom)
        Me.tcDBMaint.Controls.Add(Me.tpEditRoom)
        Me.tcDBMaint.Controls.Add(Me.tpRmRoom)
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
        Me.dbToolTip.SetToolTip(Me.tpAddClass, "Add a Class to the Database")
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
        Me.dbToolTip.SetToolTip(Me.tpEditClass, "Edit a class in the Database")
        Me.tpEditClass.UseVisualStyleBackColor = True
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
        'tcEditClass
        '
        Me.tcEditClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tcEditClass.FormattingEnabled = True
        Me.tcEditClass.Location = New System.Drawing.Point(45, 38)
        Me.tcEditClass.Name = "tcEditClass"
        Me.tcEditClass.Size = New System.Drawing.Size(401, 28)
        Me.tcEditClass.TabIndex = 0
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
        Me.dbToolTip.SetToolTip(Me.tpRmClass, "Remove a class from the Database")
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
        Me.cbDBData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDBData.FormattingEnabled = True
        Me.cbDBData.Location = New System.Drawing.Point(89, 83)
        Me.cbDBData.Name = "cbDBData"
        Me.cbDBData.Size = New System.Drawing.Size(401, 28)
        Me.cbDBData.TabIndex = 2
        '
        'tpAddProf
        '
        Me.tpAddProf.Controls.Add(Me.Label16)
        Me.tpAddProf.Controls.Add(Me.comboAddProfRank)
        Me.tpAddProf.Controls.Add(Me.btnAddProfSaveProf)
        Me.tpAddProf.Controls.Add(Me.Label8)
        Me.tpAddProf.Controls.Add(Me.tbAddProfCredHours)
        Me.tpAddProf.Controls.Add(Me.Label9)
        Me.tpAddProf.Controls.Add(Me.tbAddProfLastName)
        Me.tpAddProf.Controls.Add(Me.Label10)
        Me.tpAddProf.Controls.Add(Me.tbAddProfFirstName)
        Me.tpAddProf.Controls.Add(Me.Label11)
        Me.tpAddProf.Controls.Add(Me.tbAddProfTeacherID)
        Me.tpAddProf.Location = New System.Drawing.Point(4, 29)
        Me.tpAddProf.Name = "tpAddProf"
        Me.tpAddProf.Size = New System.Drawing.Size(834, 583)
        Me.tpAddProf.TabIndex = 3
        Me.tpAddProf.Text = "Add Professor"
        Me.dbToolTip.SetToolTip(Me.tpAddProf, "Add a professor to the Database")
        Me.tpAddProf.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(84, 339)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 20)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Teacher Rank"
        '
        'comboAddProfRank
        '
        Me.comboAddProfRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAddProfRank.FormattingEnabled = True
        Me.comboAddProfRank.Location = New System.Drawing.Point(88, 362)
        Me.comboAddProfRank.Name = "comboAddProfRank"
        Me.comboAddProfRank.Size = New System.Drawing.Size(154, 28)
        Me.comboAddProfRank.TabIndex = 50
        '
        'btnAddProfSaveProf
        '
        Me.btnAddProfSaveProf.Location = New System.Drawing.Point(88, 481)
        Me.btnAddProfSaveProf.Name = "btnAddProfSaveProf"
        Me.btnAddProfSaveProf.Size = New System.Drawing.Size(131, 34)
        Me.btnAddProfSaveProf.TabIndex = 33
        Me.btnAddProfSaveProf.Text = "Save Professor"
        Me.btnAddProfSaveProf.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(84, 267)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Yearly Credit Hours"
        '
        'tbAddProfCredHours
        '
        Me.tbAddProfCredHours.Location = New System.Drawing.Point(88, 290)
        Me.tbAddProfCredHours.Name = "tbAddProfCredHours"
        Me.tbAddProfCredHours.Size = New System.Drawing.Size(151, 26)
        Me.tbAddProfCredHours.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(84, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Last Name"
        '
        'tbAddProfLastName
        '
        Me.tbAddProfLastName.Location = New System.Drawing.Point(88, 222)
        Me.tbAddProfLastName.Name = "tbAddProfLastName"
        Me.tbAddProfLastName.Size = New System.Drawing.Size(151, 26)
        Me.tbAddProfLastName.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(84, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "First Name"
        '
        'tbAddProfFirstName
        '
        Me.tbAddProfFirstName.Location = New System.Drawing.Point(88, 142)
        Me.tbAddProfFirstName.Name = "tbAddProfFirstName"
        Me.tbAddProfFirstName.Size = New System.Drawing.Size(151, 26)
        Me.tbAddProfFirstName.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(84, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Teacher ID"
        '
        'tbAddProfTeacherID
        '
        Me.tbAddProfTeacherID.Location = New System.Drawing.Point(88, 70)
        Me.tbAddProfTeacherID.Name = "tbAddProfTeacherID"
        Me.tbAddProfTeacherID.Size = New System.Drawing.Size(151, 26)
        Me.tbAddProfTeacherID.TabIndex = 21
        '
        'tpEditProf
        '
        Me.tpEditProf.Controls.Add(Me.Label15)
        Me.tpEditProf.Controls.Add(Me.comboEditProfRank)
        Me.tpEditProf.Controls.Add(Me.cbEditProfSelectProf)
        Me.tpEditProf.Controls.Add(Me.btnEditProfessorSave)
        Me.tpEditProf.Controls.Add(Me.Label7)
        Me.tpEditProf.Controls.Add(Me.tbEditProfCredHours)
        Me.tpEditProf.Controls.Add(Me.Label12)
        Me.tpEditProf.Controls.Add(Me.tbEditProfLastName)
        Me.tpEditProf.Controls.Add(Me.Label13)
        Me.tpEditProf.Controls.Add(Me.tbEditProfFirstName)
        Me.tpEditProf.Controls.Add(Me.Label14)
        Me.tpEditProf.Controls.Add(Me.tbEditProfTeacherID)
        Me.tpEditProf.Location = New System.Drawing.Point(4, 29)
        Me.tpEditProf.Name = "tpEditProf"
        Me.tpEditProf.Size = New System.Drawing.Size(834, 583)
        Me.tpEditProf.TabIndex = 4
        Me.tpEditProf.Text = "Edit Professor"
        Me.dbToolTip.SetToolTip(Me.tpEditProf, "Edit a professor in the Database")
        Me.tpEditProf.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(79, 364)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 20)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Teacher Rank"
        '
        'comboEditProfRank
        '
        Me.comboEditProfRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEditProfRank.FormattingEnabled = True
        Me.comboEditProfRank.Location = New System.Drawing.Point(83, 387)
        Me.comboEditProfRank.Name = "comboEditProfRank"
        Me.comboEditProfRank.Size = New System.Drawing.Size(154, 28)
        Me.comboEditProfRank.TabIndex = 48
        '
        'cbEditProfSelectProf
        '
        Me.cbEditProfSelectProf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEditProfSelectProf.FormattingEnabled = True
        Me.cbEditProfSelectProf.Location = New System.Drawing.Point(16, 22)
        Me.cbEditProfSelectProf.Name = "cbEditProfSelectProf"
        Me.cbEditProfSelectProf.Size = New System.Drawing.Size(401, 28)
        Me.cbEditProfSelectProf.TabIndex = 47
        '
        'btnEditProfessorSave
        '
        Me.btnEditProfessorSave.Location = New System.Drawing.Point(83, 504)
        Me.btnEditProfessorSave.Name = "btnEditProfessorSave"
        Me.btnEditProfessorSave.Size = New System.Drawing.Size(131, 34)
        Me.btnEditProfessorSave.TabIndex = 46
        Me.btnEditProfessorSave.Text = "Save Professor"
        Me.btnEditProfessorSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 290)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 20)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Yearly Credit Hours"
        '
        'tbEditProfCredHours
        '
        Me.tbEditProfCredHours.Location = New System.Drawing.Point(83, 313)
        Me.tbEditProfCredHours.Name = "tbEditProfCredHours"
        Me.tbEditProfCredHours.Size = New System.Drawing.Size(151, 26)
        Me.tbEditProfCredHours.TabIndex = 40
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(79, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 20)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Last Name"
        '
        'tbEditProfLastName
        '
        Me.tbEditProfLastName.Location = New System.Drawing.Point(83, 245)
        Me.tbEditProfLastName.Name = "tbEditProfLastName"
        Me.tbEditProfLastName.Size = New System.Drawing.Size(151, 26)
        Me.tbEditProfLastName.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(79, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 20)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "First Name"
        '
        'tbEditProfFirstName
        '
        Me.tbEditProfFirstName.Location = New System.Drawing.Point(83, 165)
        Me.tbEditProfFirstName.Name = "tbEditProfFirstName"
        Me.tbEditProfFirstName.Size = New System.Drawing.Size(151, 26)
        Me.tbEditProfFirstName.TabIndex = 36
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(79, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 20)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Professor ID Number"
        '
        'tbEditProfTeacherID
        '
        Me.tbEditProfTeacherID.Enabled = False
        Me.tbEditProfTeacherID.Location = New System.Drawing.Point(83, 93)
        Me.tbEditProfTeacherID.Name = "tbEditProfTeacherID"
        Me.tbEditProfTeacherID.Size = New System.Drawing.Size(151, 26)
        Me.tbEditProfTeacherID.TabIndex = 34
        '
        'tpRmProf
        '
        Me.tpRmProf.Controls.Add(Me.btnRemoveProfessor)
        Me.tpRmProf.Controls.Add(Me.cbRmProfessor)
        Me.tpRmProf.Location = New System.Drawing.Point(4, 29)
        Me.tpRmProf.Name = "tpRmProf"
        Me.tpRmProf.Size = New System.Drawing.Size(834, 583)
        Me.tpRmProf.TabIndex = 5
        Me.tpRmProf.Text = "Remove Professor"
        Me.dbToolTip.SetToolTip(Me.tpRmProf, "Remove a professor from the Database")
        Me.tpRmProf.UseVisualStyleBackColor = True
        '
        'btnRemoveProfessor
        '
        Me.btnRemoveProfessor.Location = New System.Drawing.Point(374, 135)
        Me.btnRemoveProfessor.Name = "btnRemoveProfessor"
        Me.btnRemoveProfessor.Size = New System.Drawing.Size(143, 38)
        Me.btnRemoveProfessor.TabIndex = 5
        Me.btnRemoveProfessor.Text = "Remove"
        Me.btnRemoveProfessor.UseVisualStyleBackColor = True
        '
        'cbRmProfessor
        '
        Me.cbRmProfessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRmProfessor.FormattingEnabled = True
        Me.cbRmProfessor.Location = New System.Drawing.Point(60, 62)
        Me.cbRmProfessor.Name = "cbRmProfessor"
        Me.cbRmProfessor.Size = New System.Drawing.Size(401, 28)
        Me.cbRmProfessor.TabIndex = 4
        '
        'tpAddRoom
        '
        Me.tpAddRoom.Controls.Add(Me.GroupBox1)
        Me.tpAddRoom.Controls.Add(Me.btnAddRoomSave)
        Me.tpAddRoom.Controls.Add(Me.btnAddRoomRoomColor)
        Me.tpAddRoom.Controls.Add(Me.Label19)
        Me.tpAddRoom.Controls.Add(Me.Label18)
        Me.tpAddRoom.Controls.Add(Me.txtAddRoomRmNumber)
        Me.tpAddRoom.Controls.Add(Me.Label17)
        Me.tpAddRoom.Controls.Add(Me.txtAddRoomBuildingName)
        Me.tpAddRoom.Location = New System.Drawing.Point(4, 29)
        Me.tpAddRoom.Name = "tpAddRoom"
        Me.tpAddRoom.Size = New System.Drawing.Size(834, 583)
        Me.tpAddRoom.TabIndex = 6
        Me.tpAddRoom.Text = "Add Room"
        Me.dbToolTip.SetToolTip(Me.tpAddRoom, "Add a room to the Database")
        Me.tpAddRoom.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radioAddRoomWhite)
        Me.GroupBox1.Controls.Add(Me.radioAddRoomBlack)
        Me.GroupBox1.Location = New System.Drawing.Point(79, 323)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 90)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Text Color"
        '
        'radioAddRoomWhite
        '
        Me.radioAddRoomWhite.AutoSize = True
        Me.radioAddRoomWhite.Location = New System.Drawing.Point(0, 56)
        Me.radioAddRoomWhite.Name = "radioAddRoomWhite"
        Me.radioAddRoomWhite.Size = New System.Drawing.Size(75, 24)
        Me.radioAddRoomWhite.TabIndex = 1
        Me.radioAddRoomWhite.TabStop = True
        Me.radioAddRoomWhite.Text = "White"
        Me.radioAddRoomWhite.UseVisualStyleBackColor = True
        '
        'radioAddRoomBlack
        '
        Me.radioAddRoomBlack.AutoSize = True
        Me.radioAddRoomBlack.Location = New System.Drawing.Point(0, 26)
        Me.radioAddRoomBlack.Name = "radioAddRoomBlack"
        Me.radioAddRoomBlack.Size = New System.Drawing.Size(73, 24)
        Me.radioAddRoomBlack.TabIndex = 0
        Me.radioAddRoomBlack.TabStop = True
        Me.radioAddRoomBlack.Text = "Black"
        Me.radioAddRoomBlack.UseVisualStyleBackColor = True
        '
        'btnAddRoomSave
        '
        Me.btnAddRoomSave.Location = New System.Drawing.Point(79, 439)
        Me.btnAddRoomSave.Name = "btnAddRoomSave"
        Me.btnAddRoomSave.Size = New System.Drawing.Size(134, 41)
        Me.btnAddRoomSave.TabIndex = 14
        Me.btnAddRoomSave.Text = "Save"
        Me.btnAddRoomSave.UseVisualStyleBackColor = True
        '
        'btnAddRoomRoomColor
        '
        Me.btnAddRoomRoomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRoomRoomColor.Location = New System.Drawing.Point(79, 264)
        Me.btnAddRoomRoomColor.Name = "btnAddRoomRoomColor"
        Me.btnAddRoomRoomColor.Size = New System.Drawing.Size(155, 45)
        Me.btnAddRoomRoomColor.TabIndex = 5
        Me.btnAddRoomRoomColor.Text = "Sample Text"
        Me.dbToolTip.SetToolTip(Me.btnAddRoomRoomColor, "Click this button to select a color")
        Me.btnAddRoomRoomColor.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(75, 239)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 20)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Room Color"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(75, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Room Number"
        '
        'txtAddRoomRmNumber
        '
        Me.txtAddRoomRmNumber.Location = New System.Drawing.Point(79, 178)
        Me.txtAddRoomRmNumber.Name = "txtAddRoomRmNumber"
        Me.txtAddRoomRmNumber.Size = New System.Drawing.Size(266, 26)
        Me.txtAddRoomRmNumber.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(75, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 20)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Building Name"
        '
        'txtAddRoomBuildingName
        '
        Me.txtAddRoomBuildingName.Location = New System.Drawing.Point(79, 92)
        Me.txtAddRoomBuildingName.Name = "txtAddRoomBuildingName"
        Me.txtAddRoomBuildingName.Size = New System.Drawing.Size(266, 26)
        Me.txtAddRoomBuildingName.TabIndex = 0
        '
        'tpEditRoom
        '
        Me.tpEditRoom.Controls.Add(Me.GroupBox2)
        Me.tpEditRoom.Controls.Add(Me.btnEditRoomSave)
        Me.tpEditRoom.Controls.Add(Me.comboEditRoom)
        Me.tpEditRoom.Controls.Add(Me.btnEditRoomRoomColor)
        Me.tpEditRoom.Controls.Add(Me.Label20)
        Me.tpEditRoom.Controls.Add(Me.Label21)
        Me.tpEditRoom.Controls.Add(Me.txtEditRoomRmNumber)
        Me.tpEditRoom.Controls.Add(Me.Label22)
        Me.tpEditRoom.Controls.Add(Me.txtEditRoomBuildingName)
        Me.tpEditRoom.Location = New System.Drawing.Point(4, 29)
        Me.tpEditRoom.Name = "tpEditRoom"
        Me.tpEditRoom.Size = New System.Drawing.Size(834, 583)
        Me.tpEditRoom.TabIndex = 7
        Me.tpEditRoom.Text = "Edit Room"
        Me.dbToolTip.SetToolTip(Me.tpEditRoom, "Edit a room in the Database")
        Me.tpEditRoom.UseVisualStyleBackColor = True
        '
        'btnEditRoomSave
        '
        Me.btnEditRoomSave.Location = New System.Drawing.Point(79, 458)
        Me.btnEditRoomSave.Name = "btnEditRoomSave"
        Me.btnEditRoomSave.Size = New System.Drawing.Size(134, 41)
        Me.btnEditRoomSave.TabIndex = 13
        Me.btnEditRoomSave.Text = "Save"
        Me.btnEditRoomSave.UseVisualStyleBackColor = True
        '
        'comboEditRoom
        '
        Me.comboEditRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEditRoom.FormattingEnabled = True
        Me.comboEditRoom.Location = New System.Drawing.Point(79, 36)
        Me.comboEditRoom.Name = "comboEditRoom"
        Me.comboEditRoom.Size = New System.Drawing.Size(266, 28)
        Me.comboEditRoom.TabIndex = 12
        '
        'btnEditRoomRoomColor
        '
        Me.btnEditRoomRoomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditRoomRoomColor.Location = New System.Drawing.Point(79, 290)
        Me.btnEditRoomRoomColor.Name = "btnEditRoomRoomColor"
        Me.btnEditRoomRoomColor.Size = New System.Drawing.Size(155, 45)
        Me.btnEditRoomRoomColor.TabIndex = 11
        Me.btnEditRoomRoomColor.Text = "Sample Text"
        Me.dbToolTip.SetToolTip(Me.btnEditRoomRoomColor, "Click this button to select a color")
        Me.btnEditRoomRoomColor.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(75, 262)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 20)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Room Color"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(75, 171)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Room Number"
        '
        'txtEditRoomRmNumber
        '
        Me.txtEditRoomRmNumber.Location = New System.Drawing.Point(79, 209)
        Me.txtEditRoomRmNumber.Name = "txtEditRoomRmNumber"
        Me.txtEditRoomRmNumber.Size = New System.Drawing.Size(266, 26)
        Me.txtEditRoomRmNumber.TabIndex = 8
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(75, 83)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(111, 20)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Building Name"
        '
        'txtEditRoomBuildingName
        '
        Me.txtEditRoomBuildingName.Location = New System.Drawing.Point(79, 123)
        Me.txtEditRoomBuildingName.Name = "txtEditRoomBuildingName"
        Me.txtEditRoomBuildingName.Size = New System.Drawing.Size(266, 26)
        Me.txtEditRoomBuildingName.TabIndex = 6
        '
        'tpRmRoom
        '
        Me.tpRmRoom.Controls.Add(Me.btnRemoveRoom)
        Me.tpRmRoom.Controls.Add(Me.comboRemoveRoom)
        Me.tpRmRoom.Location = New System.Drawing.Point(4, 29)
        Me.tpRmRoom.Name = "tpRmRoom"
        Me.tpRmRoom.Size = New System.Drawing.Size(834, 583)
        Me.tpRmRoom.TabIndex = 8
        Me.tpRmRoom.Text = "Remove Room"
        Me.dbToolTip.SetToolTip(Me.tpRmRoom, "Remove a room from the Database")
        Me.tpRmRoom.UseVisualStyleBackColor = True
        '
        'btnRemoveRoom
        '
        Me.btnRemoveRoom.Location = New System.Drawing.Point(381, 124)
        Me.btnRemoveRoom.Name = "btnRemoveRoom"
        Me.btnRemoveRoom.Size = New System.Drawing.Size(143, 38)
        Me.btnRemoveRoom.TabIndex = 7
        Me.btnRemoveRoom.Text = "Remove"
        Me.btnRemoveRoom.UseVisualStyleBackColor = True
        '
        'comboRemoveRoom
        '
        Me.comboRemoveRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRemoveRoom.FormattingEnabled = True
        Me.comboRemoveRoom.Location = New System.Drawing.Point(67, 51)
        Me.comboRemoveRoom.Name = "comboRemoveRoom"
        Me.comboRemoveRoom.Size = New System.Drawing.Size(401, 28)
        Me.comboRemoveRoom.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radioEditRoomWhite)
        Me.GroupBox2.Controls.Add(Me.radioEditRoomBlack)
        Me.GroupBox2.Location = New System.Drawing.Point(79, 351)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 90)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Text Color"
        '
        'radioEditRoomWhite
        '
        Me.radioEditRoomWhite.AutoSize = True
        Me.radioEditRoomWhite.Location = New System.Drawing.Point(0, 56)
        Me.radioEditRoomWhite.Name = "radioEditRoomWhite"
        Me.radioEditRoomWhite.Size = New System.Drawing.Size(75, 24)
        Me.radioEditRoomWhite.TabIndex = 1
        Me.radioEditRoomWhite.TabStop = True
        Me.radioEditRoomWhite.Text = "White"
        Me.radioEditRoomWhite.UseVisualStyleBackColor = True
        '
        'radioEditRoomBlack
        '
        Me.radioEditRoomBlack.AutoSize = True
        Me.radioEditRoomBlack.Location = New System.Drawing.Point(0, 26)
        Me.radioEditRoomBlack.Name = "radioEditRoomBlack"
        Me.radioEditRoomBlack.Size = New System.Drawing.Size(73, 24)
        Me.radioEditRoomBlack.TabIndex = 0
        Me.radioEditRoomBlack.TabStop = True
        Me.radioEditRoomBlack.Text = "Black"
        Me.radioEditRoomBlack.UseVisualStyleBackColor = True
        '
        'frmDatabaseMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 782)
        Me.Controls.Add(Me.tcDBMaint)
        Me.Controls.Add(Me.btnOK)
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
        Me.tpAddProf.ResumeLayout(False)
        Me.tpAddProf.PerformLayout()
        Me.tpEditProf.ResumeLayout(False)
        Me.tpEditProf.PerformLayout()
        Me.tpRmProf.ResumeLayout(False)
        Me.tpAddRoom.ResumeLayout(False)
        Me.tpAddRoom.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpEditRoom.ResumeLayout(False)
        Me.tpEditRoom.PerformLayout()
        Me.tpRmRoom.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
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
    Friend WithEvents btnRemoveProfessor As System.Windows.Forms.Button
    Friend WithEvents cbRmProfessor As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbAddProfCredHours As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbAddProfLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbAddProfFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbAddProfTeacherID As System.Windows.Forms.TextBox
    Friend WithEvents btnAddProfSaveProf As System.Windows.Forms.Button
    Friend WithEvents cbEditProfSelectProf As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditProfessorSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbEditProfCredHours As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbEditProfLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbEditProfFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbEditProfTeacherID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents comboAddProfRank As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents comboEditProfRank As System.Windows.Forms.ComboBox
    Friend WithEvents tpAddRoom As System.Windows.Forms.TabPage
    Friend WithEvents tpEditRoom As System.Windows.Forms.TabPage
    Friend WithEvents tpRmRoom As System.Windows.Forms.TabPage
    Friend WithEvents btnAddRoomRoomColor As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAddRoomRmNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAddRoomBuildingName As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents comboEditRoom As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditRoomRoomColor As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtEditRoomRmNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtEditRoomBuildingName As System.Windows.Forms.TextBox
    Friend WithEvents btnEditRoomSave As System.Windows.Forms.Button
    Friend WithEvents btnRemoveRoom As System.Windows.Forms.Button
    Friend WithEvents comboRemoveRoom As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddRoomSave As System.Windows.Forms.Button
    Friend WithEvents dbToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radioAddRoomWhite As System.Windows.Forms.RadioButton
    Friend WithEvents radioAddRoomBlack As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radioEditRoomWhite As System.Windows.Forms.RadioButton
    Friend WithEvents radioEditRoomBlack As System.Windows.Forms.RadioButton
End Class
