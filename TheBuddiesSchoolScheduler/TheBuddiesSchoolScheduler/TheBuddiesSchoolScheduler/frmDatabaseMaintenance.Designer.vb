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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatabaseMaintenance))
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radioEditRoomWhite = New System.Windows.Forms.RadioButton()
        Me.radioEditRoomBlack = New System.Windows.Forms.RadioButton()
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
        Me.GroupBox2.SuspendLayout()
        Me.tpRmRoom.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 43)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database Maintenance"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(317, 473)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(95, 25)
        Me.btnOK.TabIndex = 8
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
        Me.tcDBMaint.Location = New System.Drawing.Point(28, 68)
        Me.tcDBMaint.Margin = New System.Windows.Forms.Padding(2)
        Me.tcDBMaint.Name = "tcDBMaint"
        Me.tcDBMaint.SelectedIndex = 0
        Me.tcDBMaint.Size = New System.Drawing.Size(662, 400)
        Me.tcDBMaint.TabIndex = 12
        '
        'tpAddClass
        '
        Me.tpAddClass.BackColor = System.Drawing.SystemColors.ControlLight
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
        Me.tpAddClass.Location = New System.Drawing.Point(4, 22)
        Me.tpAddClass.Margin = New System.Windows.Forms.Padding(2)
        Me.tpAddClass.Name = "tpAddClass"
        Me.tpAddClass.Padding = New System.Windows.Forms.Padding(2)
        Me.tpAddClass.Size = New System.Drawing.Size(654, 374)
        Me.tpAddClass.TabIndex = 0
        Me.tpAddClass.Text = "Add Class"
        Me.dbToolTip.SetToolTip(Me.tpAddClass, "Add a Class to the Database")
        '
        'btnAddClassSave
        '
        Me.btnAddClassSave.Location = New System.Drawing.Point(290, 330)
        Me.btnAddClassSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddClassSave.Name = "btnAddClassSave"
        Me.btnAddClassSave.Size = New System.Drawing.Size(75, 23)
        Me.btnAddClassSave.TabIndex = 6
        Me.btnAddClassSave.Text = "Save Class"
        Me.btnAddClassSave.UseVisualStyleBackColor = True
        '
        'chkGradClass
        '
        Me.chkGradClass.AutoSize = True
        Me.chkGradClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGradClass.Location = New System.Drawing.Point(99, 301)
        Me.chkGradClass.Margin = New System.Windows.Forms.Padding(2)
        Me.chkGradClass.Name = "chkGradClass"
        Me.chkGradClass.Size = New System.Drawing.Size(139, 24)
        Me.chkGradClass.TabIndex = 5
        Me.chkGradClass.Text = "Graduate Class"
        Me.chkGradClass.UseVisualStyleBackColor = True
        '
        'lblAddClassProfCredHours
        '
        Me.lblAddClassProfCredHours.AutoSize = True
        Me.lblAddClassProfCredHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddClassProfCredHours.Location = New System.Drawing.Point(95, 245)
        Me.lblAddClassProfCredHours.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddClassProfCredHours.Name = "lblAddClassProfCredHours"
        Me.lblAddClassProfCredHours.Size = New System.Drawing.Size(209, 20)
        Me.lblAddClassProfCredHours.TabIndex = 9
        Me.lblAddClassProfCredHours.Text = "Professor Credit Hour Worth"
        '
        'tbAddClassProfCredHour
        '
        Me.tbAddClassProfCredHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddClassProfCredHour.Location = New System.Drawing.Point(99, 270)
        Me.tbAddClassProfCredHour.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddClassProfCredHour.Name = "tbAddClassProfCredHour"
        Me.tbAddClassProfCredHour.Size = New System.Drawing.Size(460, 26)
        Me.tbAddClassProfCredHour.TabIndex = 4
        '
        'lblAddClassStuCredHours
        '
        Me.lblAddClassStuCredHours.AutoSize = True
        Me.lblAddClassStuCredHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddClassStuCredHours.Location = New System.Drawing.Point(95, 189)
        Me.lblAddClassStuCredHours.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddClassStuCredHours.Name = "lblAddClassStuCredHours"
        Me.lblAddClassStuCredHours.Size = New System.Drawing.Size(198, 20)
        Me.lblAddClassStuCredHours.TabIndex = 7
        Me.lblAddClassStuCredHours.Text = "Student Credit Hour Worth"
        '
        'tbAddClassStuCredHours
        '
        Me.tbAddClassStuCredHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddClassStuCredHours.Location = New System.Drawing.Point(99, 214)
        Me.tbAddClassStuCredHours.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddClassStuCredHours.Name = "tbAddClassStuCredHours"
        Me.tbAddClassStuCredHours.Size = New System.Drawing.Size(460, 26)
        Me.tbAddClassStuCredHours.TabIndex = 3
        '
        'lblAddClassCourseName
        '
        Me.lblAddClassCourseName.AutoSize = True
        Me.lblAddClassCourseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddClassCourseName.Location = New System.Drawing.Point(95, 133)
        Me.lblAddClassCourseName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddClassCourseName.Name = "lblAddClassCourseName"
        Me.lblAddClassCourseName.Size = New System.Drawing.Size(106, 20)
        Me.lblAddClassCourseName.TabIndex = 5
        Me.lblAddClassCourseName.Text = "Course Name"
        '
        'tbAddClassCourseName
        '
        Me.tbAddClassCourseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddClassCourseName.Location = New System.Drawing.Point(99, 158)
        Me.tbAddClassCourseName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddClassCourseName.Name = "tbAddClassCourseName"
        Me.tbAddClassCourseName.Size = New System.Drawing.Size(460, 26)
        Me.tbAddClassCourseName.TabIndex = 2
        '
        'lblAddClassCourseNum
        '
        Me.lblAddClassCourseNum.AutoSize = True
        Me.lblAddClassCourseNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddClassCourseNum.Location = New System.Drawing.Point(95, 77)
        Me.lblAddClassCourseNum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddClassCourseNum.Name = "lblAddClassCourseNum"
        Me.lblAddClassCourseNum.Size = New System.Drawing.Size(120, 20)
        Me.lblAddClassCourseNum.TabIndex = 3
        Me.lblAddClassCourseNum.Text = "Course Number"
        '
        'tbAddClassCourseNum
        '
        Me.tbAddClassCourseNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddClassCourseNum.Location = New System.Drawing.Point(99, 102)
        Me.tbAddClassCourseNum.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddClassCourseNum.Name = "tbAddClassCourseNum"
        Me.tbAddClassCourseNum.Size = New System.Drawing.Size(460, 26)
        Me.tbAddClassCourseNum.TabIndex = 1
        '
        'lblAddClassDept
        '
        Me.lblAddClassDept.AutoSize = True
        Me.lblAddClassDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddClassDept.Location = New System.Drawing.Point(95, 21)
        Me.lblAddClassDept.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddClassDept.Name = "lblAddClassDept"
        Me.lblAddClassDept.Size = New System.Drawing.Size(94, 20)
        Me.lblAddClassDept.TabIndex = 1
        Me.lblAddClassDept.Text = "Department"
        '
        'tbAddClassDepartment
        '
        Me.tbAddClassDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddClassDepartment.Location = New System.Drawing.Point(99, 46)
        Me.tbAddClassDepartment.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddClassDepartment.Name = "tbAddClassDepartment"
        Me.tbAddClassDepartment.Size = New System.Drawing.Size(460, 26)
        Me.tbAddClassDepartment.TabIndex = 0
        '
        'tpEditClass
        '
        Me.tpEditClass.BackColor = System.Drawing.SystemColors.ControlLight
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
        Me.tpEditClass.Location = New System.Drawing.Point(4, 22)
        Me.tpEditClass.Margin = New System.Windows.Forms.Padding(2)
        Me.tpEditClass.Name = "tpEditClass"
        Me.tpEditClass.Padding = New System.Windows.Forms.Padding(2)
        Me.tpEditClass.Size = New System.Drawing.Size(654, 374)
        Me.tpEditClass.TabIndex = 1
        Me.tpEditClass.Text = "Edit Class"
        Me.dbToolTip.SetToolTip(Me.tpEditClass, "Edit a class in the Database")
        '
        'btnEditClassSave
        '
        Me.btnEditClassSave.Location = New System.Drawing.Point(274, 323)
        Me.btnEditClassSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditClassSave.Name = "btnEditClassSave"
        Me.btnEditClassSave.Size = New System.Drawing.Size(95, 25)
        Me.btnEditClassSave.TabIndex = 7
        Me.btnEditClassSave.Text = "Save"
        Me.btnEditClassSave.UseVisualStyleBackColor = True
        '
        'chkEditClassGradClass
        '
        Me.chkEditClassGradClass.AutoSize = True
        Me.chkEditClassGradClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEditClassGradClass.Location = New System.Drawing.Point(99, 297)
        Me.chkEditClassGradClass.Margin = New System.Windows.Forms.Padding(2)
        Me.chkEditClassGradClass.Name = "chkEditClassGradClass"
        Me.chkEditClassGradClass.Size = New System.Drawing.Size(139, 24)
        Me.chkEditClassGradClass.TabIndex = 6
        Me.chkEditClassGradClass.Text = "Graduate Class"
        Me.chkEditClassGradClass.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(95, 247)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Professor Credit Hour Worth"
        '
        'tbEditClassProfHr
        '
        Me.tbEditClassProfHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditClassProfHr.Location = New System.Drawing.Point(99, 269)
        Me.tbEditClassProfHr.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditClassProfHr.Name = "tbEditClassProfHr"
        Me.tbEditClassProfHr.Size = New System.Drawing.Size(460, 26)
        Me.tbEditClassProfHr.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(95, 197)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Student Credit Hour Worth"
        '
        'tbEditClassStuCredHr
        '
        Me.tbEditClassStuCredHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditClassStuCredHr.Location = New System.Drawing.Point(99, 219)
        Me.tbEditClassStuCredHr.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditClassStuCredHr.Name = "tbEditClassStuCredHr"
        Me.tbEditClassStuCredHr.Size = New System.Drawing.Size(460, 26)
        Me.tbEditClassStuCredHr.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(95, 147)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Course Name"
        '
        'tbEditClassCourseName
        '
        Me.tbEditClassCourseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditClassCourseName.Location = New System.Drawing.Point(99, 169)
        Me.tbEditClassCourseName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditClassCourseName.Name = "tbEditClassCourseName"
        Me.tbEditClassCourseName.Size = New System.Drawing.Size(460, 26)
        Me.tbEditClassCourseName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 97)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Course Number"
        '
        'tbEditClassCourseNum
        '
        Me.tbEditClassCourseNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditClassCourseNum.Location = New System.Drawing.Point(99, 119)
        Me.tbEditClassCourseNum.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditClassCourseNum.Name = "tbEditClassCourseNum"
        Me.tbEditClassCourseNum.Size = New System.Drawing.Size(460, 26)
        Me.tbEditClassCourseNum.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(95, 47)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Department"
        '
        'tbEditClassDept
        '
        Me.tbEditClassDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditClassDept.Location = New System.Drawing.Point(99, 69)
        Me.tbEditClassDept.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditClassDept.Name = "tbEditClassDept"
        Me.tbEditClassDept.Size = New System.Drawing.Size(460, 26)
        Me.tbEditClassDept.TabIndex = 1
        '
        'tcEditClass
        '
        Me.tcEditClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tcEditClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcEditClass.FormattingEnabled = True
        Me.tcEditClass.Location = New System.Drawing.Point(99, 17)
        Me.tcEditClass.Margin = New System.Windows.Forms.Padding(2)
        Me.tcEditClass.Name = "tcEditClass"
        Me.tcEditClass.Size = New System.Drawing.Size(460, 28)
        Me.tcEditClass.TabIndex = 0
        '
        'tpRmClass
        '
        Me.tpRmClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tpRmClass.Controls.Add(Me.btnRemove)
        Me.tpRmClass.Controls.Add(Me.cbDBData)
        Me.tpRmClass.Location = New System.Drawing.Point(4, 22)
        Me.tpRmClass.Margin = New System.Windows.Forms.Padding(2)
        Me.tpRmClass.Name = "tpRmClass"
        Me.tpRmClass.Padding = New System.Windows.Forms.Padding(2)
        Me.tpRmClass.Size = New System.Drawing.Size(654, 374)
        Me.tpRmClass.TabIndex = 2
        Me.tpRmClass.Text = "Remove Class"
        Me.dbToolTip.SetToolTip(Me.tpRmClass, "Remove a class from the Database")
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(267, 203)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(95, 25)
        Me.btnRemove.TabIndex = 1
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'cbDBData
        '
        Me.cbDBData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDBData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDBData.FormattingEnabled = True
        Me.cbDBData.Location = New System.Drawing.Point(97, 146)
        Me.cbDBData.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDBData.Name = "cbDBData"
        Me.cbDBData.Size = New System.Drawing.Size(460, 28)
        Me.cbDBData.TabIndex = 0
        '
        'tpAddProf
        '
        Me.tpAddProf.BackColor = System.Drawing.SystemColors.ControlLight
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
        Me.tpAddProf.Location = New System.Drawing.Point(4, 22)
        Me.tpAddProf.Margin = New System.Windows.Forms.Padding(2)
        Me.tpAddProf.Name = "tpAddProf"
        Me.tpAddProf.Size = New System.Drawing.Size(654, 374)
        Me.tpAddProf.TabIndex = 3
        Me.tpAddProf.Text = "Add Professor"
        Me.dbToolTip.SetToolTip(Me.tpAddProf, "Add a professor to the Database")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(231, 267)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 20)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Teacher Rank"
        '
        'comboAddProfRank
        '
        Me.comboAddProfRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAddProfRank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAddProfRank.FormattingEnabled = True
        Me.comboAddProfRank.Location = New System.Drawing.Point(235, 295)
        Me.comboAddProfRank.Margin = New System.Windows.Forms.Padding(2)
        Me.comboAddProfRank.Name = "comboAddProfRank"
        Me.comboAddProfRank.Size = New System.Drawing.Size(189, 28)
        Me.comboAddProfRank.TabIndex = 4
        '
        'btnAddProfSaveProf
        '
        Me.btnAddProfSaveProf.Location = New System.Drawing.Point(278, 331)
        Me.btnAddProfSaveProf.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddProfSaveProf.Name = "btnAddProfSaveProf"
        Me.btnAddProfSaveProf.Size = New System.Drawing.Size(95, 25)
        Me.btnAddProfSaveProf.TabIndex = 5
        Me.btnAddProfSaveProf.Text = "Save Professor"
        Me.btnAddProfSaveProf.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(231, 205)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Yearly Credit Hours"
        '
        'tbAddProfCredHours
        '
        Me.tbAddProfCredHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddProfCredHours.Location = New System.Drawing.Point(235, 233)
        Me.tbAddProfCredHours.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddProfCredHours.Name = "tbAddProfCredHours"
        Me.tbAddProfCredHours.Size = New System.Drawing.Size(189, 26)
        Me.tbAddProfCredHours.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(231, 143)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Last Name"
        '
        'tbAddProfLastName
        '
        Me.tbAddProfLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddProfLastName.Location = New System.Drawing.Point(235, 171)
        Me.tbAddProfLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddProfLastName.Name = "tbAddProfLastName"
        Me.tbAddProfLastName.Size = New System.Drawing.Size(189, 26)
        Me.tbAddProfLastName.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(231, 81)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "First Name"
        '
        'tbAddProfFirstName
        '
        Me.tbAddProfFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddProfFirstName.Location = New System.Drawing.Point(235, 109)
        Me.tbAddProfFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddProfFirstName.Name = "tbAddProfFirstName"
        Me.tbAddProfFirstName.Size = New System.Drawing.Size(189, 26)
        Me.tbAddProfFirstName.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(231, 19)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Teacher ID"
        '
        'tbAddProfTeacherID
        '
        Me.tbAddProfTeacherID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddProfTeacherID.Location = New System.Drawing.Point(235, 47)
        Me.tbAddProfTeacherID.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAddProfTeacherID.Name = "tbAddProfTeacherID"
        Me.tbAddProfTeacherID.Size = New System.Drawing.Size(189, 26)
        Me.tbAddProfTeacherID.TabIndex = 0
        '
        'tpEditProf
        '
        Me.tpEditProf.BackColor = System.Drawing.SystemColors.ControlLight
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
        Me.tpEditProf.Location = New System.Drawing.Point(4, 22)
        Me.tpEditProf.Margin = New System.Windows.Forms.Padding(2)
        Me.tpEditProf.Name = "tpEditProf"
        Me.tpEditProf.Size = New System.Drawing.Size(654, 374)
        Me.tpEditProf.TabIndex = 4
        Me.tpEditProf.Text = "Edit Professor"
        Me.dbToolTip.SetToolTip(Me.tpEditProf, "Edit a professor in the Database")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(213, 271)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 20)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Teacher Rank"
        '
        'comboEditProfRank
        '
        Me.comboEditProfRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEditProfRank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEditProfRank.FormattingEnabled = True
        Me.comboEditProfRank.Location = New System.Drawing.Point(215, 295)
        Me.comboEditProfRank.Margin = New System.Windows.Forms.Padding(2)
        Me.comboEditProfRank.Name = "comboEditProfRank"
        Me.comboEditProfRank.Size = New System.Drawing.Size(227, 28)
        Me.comboEditProfRank.TabIndex = 5
        '
        'cbEditProfSelectProf
        '
        Me.cbEditProfSelectProf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEditProfSelectProf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEditProfSelectProf.FormattingEnabled = True
        Me.cbEditProfSelectProf.Location = New System.Drawing.Point(216, 23)
        Me.cbEditProfSelectProf.Margin = New System.Windows.Forms.Padding(2)
        Me.cbEditProfSelectProf.Name = "cbEditProfSelectProf"
        Me.cbEditProfSelectProf.Size = New System.Drawing.Size(226, 28)
        Me.cbEditProfSelectProf.TabIndex = 0
        '
        'btnEditProfessorSave
        '
        Me.btnEditProfessorSave.Location = New System.Drawing.Point(263, 327)
        Me.btnEditProfessorSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditProfessorSave.Name = "btnEditProfessorSave"
        Me.btnEditProfessorSave.Size = New System.Drawing.Size(95, 25)
        Me.btnEditProfessorSave.TabIndex = 6
        Me.btnEditProfessorSave.Text = "Save Professor"
        Me.btnEditProfessorSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(213, 217)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 20)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Yearly Credit Hours"
        '
        'tbEditProfCredHours
        '
        Me.tbEditProfCredHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditProfCredHours.Location = New System.Drawing.Point(215, 241)
        Me.tbEditProfCredHours.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditProfCredHours.Name = "tbEditProfCredHours"
        Me.tbEditProfCredHours.Size = New System.Drawing.Size(227, 26)
        Me.tbEditProfCredHours.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(213, 163)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 20)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Last Name"
        '
        'tbEditProfLastName
        '
        Me.tbEditProfLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditProfLastName.Location = New System.Drawing.Point(215, 187)
        Me.tbEditProfLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditProfLastName.Name = "tbEditProfLastName"
        Me.tbEditProfLastName.Size = New System.Drawing.Size(227, 26)
        Me.tbEditProfLastName.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(213, 109)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 20)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "First Name"
        '
        'tbEditProfFirstName
        '
        Me.tbEditProfFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditProfFirstName.Location = New System.Drawing.Point(215, 133)
        Me.tbEditProfFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditProfFirstName.Name = "tbEditProfFirstName"
        Me.tbEditProfFirstName.Size = New System.Drawing.Size(227, 26)
        Me.tbEditProfFirstName.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(213, 55)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 20)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Professor ID Number"
        '
        'tbEditProfTeacherID
        '
        Me.tbEditProfTeacherID.Enabled = False
        Me.tbEditProfTeacherID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditProfTeacherID.Location = New System.Drawing.Point(216, 79)
        Me.tbEditProfTeacherID.Margin = New System.Windows.Forms.Padding(2)
        Me.tbEditProfTeacherID.Name = "tbEditProfTeacherID"
        Me.tbEditProfTeacherID.Size = New System.Drawing.Size(226, 26)
        Me.tbEditProfTeacherID.TabIndex = 1
        '
        'tpRmProf
        '
        Me.tpRmProf.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tpRmProf.Controls.Add(Me.btnRemoveProfessor)
        Me.tpRmProf.Controls.Add(Me.cbRmProfessor)
        Me.tpRmProf.Location = New System.Drawing.Point(4, 22)
        Me.tpRmProf.Margin = New System.Windows.Forms.Padding(2)
        Me.tpRmProf.Name = "tpRmProf"
        Me.tpRmProf.Size = New System.Drawing.Size(654, 374)
        Me.tpRmProf.TabIndex = 5
        Me.tpRmProf.Text = "Remove Professor"
        Me.dbToolTip.SetToolTip(Me.tpRmProf, "Remove a professor from the Database")
        '
        'btnRemoveProfessor
        '
        Me.btnRemoveProfessor.Location = New System.Drawing.Point(280, 206)
        Me.btnRemoveProfessor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRemoveProfessor.Name = "btnRemoveProfessor"
        Me.btnRemoveProfessor.Size = New System.Drawing.Size(95, 25)
        Me.btnRemoveProfessor.TabIndex = 1
        Me.btnRemoveProfessor.Text = "Remove"
        Me.btnRemoveProfessor.UseVisualStyleBackColor = True
        '
        'cbRmProfessor
        '
        Me.cbRmProfessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRmProfessor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRmProfessor.FormattingEnabled = True
        Me.cbRmProfessor.Location = New System.Drawing.Point(193, 144)
        Me.cbRmProfessor.Margin = New System.Windows.Forms.Padding(2)
        Me.cbRmProfessor.Name = "cbRmProfessor"
        Me.cbRmProfessor.Size = New System.Drawing.Size(269, 28)
        Me.cbRmProfessor.TabIndex = 0
        '
        'tpAddRoom
        '
        Me.tpAddRoom.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tpAddRoom.Controls.Add(Me.GroupBox1)
        Me.tpAddRoom.Controls.Add(Me.btnAddRoomSave)
        Me.tpAddRoom.Controls.Add(Me.btnAddRoomRoomColor)
        Me.tpAddRoom.Controls.Add(Me.Label19)
        Me.tpAddRoom.Controls.Add(Me.Label18)
        Me.tpAddRoom.Controls.Add(Me.txtAddRoomRmNumber)
        Me.tpAddRoom.Controls.Add(Me.Label17)
        Me.tpAddRoom.Controls.Add(Me.txtAddRoomBuildingName)
        Me.tpAddRoom.Location = New System.Drawing.Point(4, 22)
        Me.tpAddRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.tpAddRoom.Name = "tpAddRoom"
        Me.tpAddRoom.Size = New System.Drawing.Size(654, 374)
        Me.tpAddRoom.TabIndex = 6
        Me.tpAddRoom.Text = "Add Room"
        Me.dbToolTip.SetToolTip(Me.tpAddRoom, "Add a room to the Database")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radioAddRoomWhite)
        Me.GroupBox1.Controls.Add(Me.radioAddRoomBlack)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(213, 251)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(177, 58)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Text Color"
        '
        'radioAddRoomWhite
        '
        Me.radioAddRoomWhite.AutoSize = True
        Me.radioAddRoomWhite.Location = New System.Drawing.Point(0, 36)
        Me.radioAddRoomWhite.Margin = New System.Windows.Forms.Padding(2)
        Me.radioAddRoomWhite.Name = "radioAddRoomWhite"
        Me.radioAddRoomWhite.Size = New System.Drawing.Size(68, 24)
        Me.radioAddRoomWhite.TabIndex = 5
        Me.radioAddRoomWhite.TabStop = True
        Me.radioAddRoomWhite.Text = "White"
        Me.radioAddRoomWhite.UseVisualStyleBackColor = True
        '
        'radioAddRoomBlack
        '
        Me.radioAddRoomBlack.AutoSize = True
        Me.radioAddRoomBlack.Location = New System.Drawing.Point(0, 17)
        Me.radioAddRoomBlack.Margin = New System.Windows.Forms.Padding(2)
        Me.radioAddRoomBlack.Name = "radioAddRoomBlack"
        Me.radioAddRoomBlack.Size = New System.Drawing.Size(66, 24)
        Me.radioAddRoomBlack.TabIndex = 4
        Me.radioAddRoomBlack.TabStop = True
        Me.radioAddRoomBlack.Text = "Black"
        Me.radioAddRoomBlack.UseVisualStyleBackColor = True
        '
        'btnAddRoomSave
        '
        Me.btnAddRoomSave.Location = New System.Drawing.Point(269, 323)
        Me.btnAddRoomSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddRoomSave.Name = "btnAddRoomSave"
        Me.btnAddRoomSave.Size = New System.Drawing.Size(95, 25)
        Me.btnAddRoomSave.TabIndex = 6
        Me.btnAddRoomSave.Text = "Save"
        Me.btnAddRoomSave.UseVisualStyleBackColor = True
        '
        'btnAddRoomRoomColor
        '
        Me.btnAddRoomRoomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRoomRoomColor.Location = New System.Drawing.Point(213, 208)
        Me.btnAddRoomRoomColor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddRoomRoomColor.Name = "btnAddRoomRoomColor"
        Me.btnAddRoomRoomColor.Size = New System.Drawing.Size(103, 29)
        Me.btnAddRoomRoomColor.TabIndex = 2
        Me.btnAddRoomRoomColor.Text = "Sample Text"
        Me.dbToolTip.SetToolTip(Me.btnAddRoomRoomColor, "Click this button to select a color")
        Me.btnAddRoomRoomColor.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(209, 174)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 20)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Room Color"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(209, 100)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Room Number"
        '
        'txtAddRoomRmNumber
        '
        Me.txtAddRoomRmNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddRoomRmNumber.Location = New System.Drawing.Point(213, 134)
        Me.txtAddRoomRmNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddRoomRmNumber.Name = "txtAddRoomRmNumber"
        Me.txtAddRoomRmNumber.Size = New System.Drawing.Size(233, 26)
        Me.txtAddRoomRmNumber.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(209, 26)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 20)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Building Name"
        '
        'txtAddRoomBuildingName
        '
        Me.txtAddRoomBuildingName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddRoomBuildingName.Location = New System.Drawing.Point(213, 60)
        Me.txtAddRoomBuildingName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddRoomBuildingName.Name = "txtAddRoomBuildingName"
        Me.txtAddRoomBuildingName.Size = New System.Drawing.Size(233, 26)
        Me.txtAddRoomBuildingName.TabIndex = 0
        '
        'tpEditRoom
        '
        Me.tpEditRoom.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tpEditRoom.Controls.Add(Me.GroupBox2)
        Me.tpEditRoom.Controls.Add(Me.btnEditRoomSave)
        Me.tpEditRoom.Controls.Add(Me.comboEditRoom)
        Me.tpEditRoom.Controls.Add(Me.btnEditRoomRoomColor)
        Me.tpEditRoom.Controls.Add(Me.Label20)
        Me.tpEditRoom.Controls.Add(Me.Label21)
        Me.tpEditRoom.Controls.Add(Me.txtEditRoomRmNumber)
        Me.tpEditRoom.Controls.Add(Me.Label22)
        Me.tpEditRoom.Controls.Add(Me.txtEditRoomBuildingName)
        Me.tpEditRoom.Location = New System.Drawing.Point(4, 22)
        Me.tpEditRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.tpEditRoom.Name = "tpEditRoom"
        Me.tpEditRoom.Size = New System.Drawing.Size(654, 374)
        Me.tpEditRoom.TabIndex = 7
        Me.tpEditRoom.Text = "Edit Room"
        Me.dbToolTip.SetToolTip(Me.tpEditRoom, "Edit a room in the Database")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radioEditRoomWhite)
        Me.GroupBox2.Controls.Add(Me.radioEditRoomBlack)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(182, 263)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(177, 58)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Text Color"
        '
        'radioEditRoomWhite
        '
        Me.radioEditRoomWhite.AutoSize = True
        Me.radioEditRoomWhite.Location = New System.Drawing.Point(0, 36)
        Me.radioEditRoomWhite.Margin = New System.Windows.Forms.Padding(2)
        Me.radioEditRoomWhite.Name = "radioEditRoomWhite"
        Me.radioEditRoomWhite.Size = New System.Drawing.Size(68, 24)
        Me.radioEditRoomWhite.TabIndex = 6
        Me.radioEditRoomWhite.TabStop = True
        Me.radioEditRoomWhite.Text = "White"
        Me.radioEditRoomWhite.UseVisualStyleBackColor = True
        '
        'radioEditRoomBlack
        '
        Me.radioEditRoomBlack.AutoSize = True
        Me.radioEditRoomBlack.Location = New System.Drawing.Point(0, 17)
        Me.radioEditRoomBlack.Margin = New System.Windows.Forms.Padding(2)
        Me.radioEditRoomBlack.Name = "radioEditRoomBlack"
        Me.radioEditRoomBlack.Size = New System.Drawing.Size(66, 24)
        Me.radioEditRoomBlack.TabIndex = 5
        Me.radioEditRoomBlack.TabStop = True
        Me.radioEditRoomBlack.Text = "Black"
        Me.radioEditRoomBlack.UseVisualStyleBackColor = True
        '
        'btnEditRoomSave
        '
        Me.btnEditRoomSave.Location = New System.Drawing.Point(254, 332)
        Me.btnEditRoomSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditRoomSave.Name = "btnEditRoomSave"
        Me.btnEditRoomSave.Size = New System.Drawing.Size(95, 25)
        Me.btnEditRoomSave.TabIndex = 7
        Me.btnEditRoomSave.Text = "Save"
        Me.btnEditRoomSave.UseVisualStyleBackColor = True
        '
        'comboEditRoom
        '
        Me.comboEditRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEditRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEditRoom.FormattingEnabled = True
        Me.comboEditRoom.Location = New System.Drawing.Point(182, 17)
        Me.comboEditRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.comboEditRoom.Name = "comboEditRoom"
        Me.comboEditRoom.Size = New System.Drawing.Size(295, 28)
        Me.comboEditRoom.TabIndex = 0
        '
        'btnEditRoomRoomColor
        '
        Me.btnEditRoomRoomColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditRoomRoomColor.Location = New System.Drawing.Point(182, 223)
        Me.btnEditRoomRoomColor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditRoomRoomColor.Name = "btnEditRoomRoomColor"
        Me.btnEditRoomRoomColor.Size = New System.Drawing.Size(103, 29)
        Me.btnEditRoomRoomColor.TabIndex = 3
        Me.btnEditRoomRoomColor.Text = "Sample Text"
        Me.dbToolTip.SetToolTip(Me.btnEditRoomRoomColor, "Click this button to select a color")
        Me.btnEditRoomRoomColor.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(178, 192)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 20)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Room Color"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(178, 124)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Room Number"
        '
        'txtEditRoomRmNumber
        '
        Me.txtEditRoomRmNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditRoomRmNumber.Location = New System.Drawing.Point(182, 155)
        Me.txtEditRoomRmNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditRoomRmNumber.Name = "txtEditRoomRmNumber"
        Me.txtEditRoomRmNumber.Size = New System.Drawing.Size(295, 26)
        Me.txtEditRoomRmNumber.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(178, 56)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(111, 20)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Building Name"
        '
        'txtEditRoomBuildingName
        '
        Me.txtEditRoomBuildingName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditRoomBuildingName.Location = New System.Drawing.Point(182, 87)
        Me.txtEditRoomBuildingName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditRoomBuildingName.Name = "txtEditRoomBuildingName"
        Me.txtEditRoomBuildingName.Size = New System.Drawing.Size(295, 26)
        Me.txtEditRoomBuildingName.TabIndex = 1
        '
        'tpRmRoom
        '
        Me.tpRmRoom.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tpRmRoom.Controls.Add(Me.btnRemoveRoom)
        Me.tpRmRoom.Controls.Add(Me.comboRemoveRoom)
        Me.tpRmRoom.Location = New System.Drawing.Point(4, 22)
        Me.tpRmRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.tpRmRoom.Name = "tpRmRoom"
        Me.tpRmRoom.Size = New System.Drawing.Size(654, 374)
        Me.tpRmRoom.TabIndex = 8
        Me.tpRmRoom.Text = "Remove Room"
        Me.dbToolTip.SetToolTip(Me.tpRmRoom, "Remove a room from the Database")
        '
        'btnRemoveRoom
        '
        Me.btnRemoveRoom.Location = New System.Drawing.Point(280, 206)
        Me.btnRemoveRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRemoveRoom.Name = "btnRemoveRoom"
        Me.btnRemoveRoom.Size = New System.Drawing.Size(95, 25)
        Me.btnRemoveRoom.TabIndex = 1
        Me.btnRemoveRoom.Text = "Remove"
        Me.btnRemoveRoom.UseVisualStyleBackColor = True
        '
        'comboRemoveRoom
        '
        Me.comboRemoveRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRemoveRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboRemoveRoom.FormattingEnabled = True
        Me.comboRemoveRoom.Location = New System.Drawing.Point(193, 144)
        Me.comboRemoveRoom.Margin = New System.Windows.Forms.Padding(2)
        Me.comboRemoveRoom.Name = "comboRemoveRoom"
        Me.comboRemoveRoom.Size = New System.Drawing.Size(269, 28)
        Me.comboRemoveRoom.TabIndex = 0
        '
        'frmDatabaseMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(729, 508)
        Me.Controls.Add(Me.tcDBMaint)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmDatabaseMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies School Scheduler"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpRmRoom.ResumeLayout(False)
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
