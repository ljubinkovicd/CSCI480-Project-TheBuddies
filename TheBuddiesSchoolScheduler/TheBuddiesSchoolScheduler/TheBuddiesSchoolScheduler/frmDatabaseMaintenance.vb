
Imports System.Text.RegularExpressions

Public Class frmDatabaseMaintenance

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub


    Private Sub tcDBMaint_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles tcDBMaint.SelectedIndexChanged
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect
        Dim classID As Integer = 0
        Dim index As Integer = 0
        Dim RoomColor As Integer
        Dim ColorString As String = ""

        If tcDBMaint.SelectedIndex = 0 Then
            ' Add Class Tab

        ElseIf tcDBMaint.SelectedIndex = 1 Then
            ' Edit Class Tab

            ' Grab every class from the database
            ds = SQL.GetStoredProc("GetAllClasses")

            ' Set the combo box to have the class data
            tcEditClass.DisplayMember = ds.Tables(0).Columns(0).ToString
            tcEditClass.ValueMember = ds.Tables(0).Columns(1).ToString
            tcEditClass.DataSource = ds.Tables(0)


            ' ClassID, Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
            tbEditClassCourseName.Text = ds.Tables(0).Rows(0).Item("CourseName")
            tbEditClassCourseNum.Text = ds.Tables(0).Rows(0).Item("CourseNum")
            tbEditClassDept.Text = ds.Tables(0).Rows(0).Item("Department")
            tbEditClassProfHr.Text = ds.Tables(0).Rows(0).Item("TeacherCreditHours")
            tbEditClassStuCredHr.Text = ds.Tables(0).Rows(0).Item("StudentCreditHours")
            chkEditClassGradClass.CheckState = ds.Tables(0).Rows(0).Item("IsGradClass")

        ElseIf tcDBMaint.SelectedIndex = 2 Then
            ' Remove Class Tab


            ds = SQL.GetStoredProc("GetAllClasses")


            cbDBData.DisplayMember = ds.Tables(0).Columns(0).ToString
            cbDBData.ValueMember = ds.Tables(0).Columns(1).ToString
            cbDBData.DataSource = ds.Tables(0)
        ElseIf tcDBMaint.SelectedIndex = 3 Then
            ' Add Professor

            ' Grab every professor rank in the database
            ds2 = SQL.GetStoredProc("GetAllRanks")

            ' Set the combo box to have the class data
            comboAddProfRank.DisplayMember = ds2.Tables(0).Columns(0).ToString
            comboAddProfRank.ValueMember = ds2.Tables(0).Columns(1).ToString
            comboAddProfRank.DataSource = ds2.Tables(0)
        ElseIf tcDBMaint.SelectedIndex = 4 Then
            ' Edit Professor

            ' Grab every professor from the database
            ds = SQL.GetStoredProc("GetAllProfessors")
            ' Grab every rank a professor can have from the database
            ds2 = SQL.GetStoredProc("GetAllRanks")

            ' Set the professor box with the first dataset
            cbEditProfSelectProf.DisplayMember = ds.Tables(0).Columns(0).ToString
            cbEditProfSelectProf.ValueMember = ds.Tables(0).Columns(1).ToString
            cbEditProfSelectProf.DataSource = ds.Tables(0)

            ' Set the professor rank box with the second dataset
            comboEditProfRank.DisplayMember = ds2.Tables(0).Columns(0).ToString
            comboEditProfRank.ValueMember = ds2.Tables(0).Columns(1).ToString
            comboEditProfRank.DataSource = ds2.Tables(0)

            ' Grab the index from the professor box
            index = cbEditProfSelectProf.SelectedIndex

            ' TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD
            tbEditProfTeacherID.Text = ds.Tables(0).Rows(0).Item("TeacherID")
            tbEditProfFirstName.Text = ds.Tables(0).Rows(0).Item("FirstName")
            tbEditProfLastName.Text = ds.Tables(0).Rows(0).Item("LastName")
            tbEditProfCredHours.Text = ds.Tables(0).Rows(0).Item("YearlyCreditHours")

            ' Lookup the professor rank and set the box to the database value in the combo box
            Dim Rank As Integer
            Rank = FindProfRank(ds.Tables(0).Rows(0).Item("ProfessorRank"))
            comboEditProfRank.SelectedIndex = Rank - 1
        ElseIf tcDBMaint.SelectedIndex = 5 Then
            ' Remove Professor

            ' Grab every professor
            ds = SQL.GetStoredProc("GetAllProfessors")

            ' Set the combo box to show the professors
            cbRmProfessor.DisplayMember = ds.Tables(0).Columns(0).ToString
            cbRmProfessor.ValueMember = ds.Tables(0).Columns(1).ToString
            cbRmProfessor.DataSource = ds.Tables(0)
        ElseIf tcDBMaint.SelectedIndex = 6 Then
            ' ADD ROOM
            'btnAddRoomRoomColor.ForeColor = 
        ElseIf tcDBMaint.SelectedIndex = 7 Then
            ' EDIT ROOM

            ' Grab every room from the database
            ds = SQL.GetStoredProc("GetAllRooms")

            ' Set the combo box on the edit room tab to the room names
            comboEditRoom.DisplayMember = ds.Tables(0).Columns("Room").ToString
            comboEditRoom.ValueMember = ds.Tables(0).Columns(0).ToString
            comboEditRoom.DataSource = ds.Tables(0)

            ' Fill the text boxes
            txtEditRoomBuildingName.Text = ds.Tables(0).Rows(0).Item("BuildingName").ToString
            txtEditRoomRmNumber.Text = ds.Tables(0).Rows(0).Item("RoomNumber").ToString

            ' Convert the room color and set the button to the color of the room
            RoomColor = Convert.ToInt32(Trim(ds.Tables(0).Rows(0).Item("RoomColor").ToString))
            btnEditRoomRoomColor.BackColor = Color.FromArgb(RoomColor)
        ElseIf tcDBMaint.SelectedIndex = 8 Then
            ' REMOVE ROOM

            ' Grab every room from the database
            ds = SQL.GetStoredProc("GetAllRooms")

            ' Set the combo box equal to what was retrieved from the database
            comboRemoveRoom.DisplayMember = ds.Tables(0).Columns("Room").ToString
            comboRemoveRoom.ValueMember = ds.Tables(0).Columns(0).ToString
            comboRemoveRoom.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub btnRemove_Click_1(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllClasses")
        Dim ds2 As DataSet = New DataSet
        Dim classID As Integer = 0
        Dim index As Integer = 0
        Dim success As Boolean = True

        Try
            index = cbDBData.SelectedIndex
            classID = ds.Tables(0).Rows(index).Item("ClassID")

            ' Prompt the user to make sure they made the right decision
            Dim result As Integer = MessageBox.Show("Are you sure that you would like to delete " + ds.Tables(0).Rows(index).Item("Course") + "?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                ' Reset the combo box with the data from the dataset
                ds2 = SQL.GetStoredProc("RemoveClass " + classID.ToString())

            Else
                success = False
            End If
        Catch ex As Exception
            success = False
        End Try

        If success Then
            ds.Tables(0).Rows(index).Delete()
            cbDBData.DataSource = ds.Tables(0)
            cbDBData.ValueMember = "Course"
            MessageBox.Show("The Course has been Removed successfully")
        Else
            MessageBox.Show("The Course has not been removed")
        End If
    End Sub


    Private Sub btnAddClassSave_Click(sender As Object, e As EventArgs) Handles btnAddClassSave.Click
        Dim Dept As String = tbAddClassDepartment.Text
        Dim CourseNum As String = tbAddClassCourseNum.Text
        Dim CourseName As String = tbAddClassCourseName.Text
        Dim StudentCredWorth As String = tbAddClassStuCredHours.Text
        Dim ProfCredWorth As String = tbAddClassProfCredHour.Text
        Dim GradClass As Boolean = chkGradClass.CheckState
        Dim passed As Boolean = True
        Dim SQL As New SQLConnect
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim proc As String = ""

        If Not (Trim(Dept) <> "" And CheckStringLength(Dept, 3, 4)) Then
            MessageBox.Show("Department is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(CourseNum) <> "" And CheckStringLength(CourseNum, 3, 3)) Then
            MessageBox.Show("Course Number is either Blank or of the wrong size.")
            passed = False
        End If

        proc = "CheckIfClassExists '" + Dept + "', '" + CourseNum + "'"
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("The class " + Dept + CourseName + " already exists")
            passed = False
        End If

        If Not (CheckIntegerNumeric(CourseNum, 3)) Then
            MessageBox.Show("A Course Number Must be a 3 Digit Numeric Value")
            passed = False
        End If

        If Not (Trim(CourseName) <> "" And CheckStringLength(CourseName, 0, 255)) Then
            MessageBox.Show("Course Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(StudentCredWorth) <> "") Then
            MessageBox.Show("Student Credit Hour Worth is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(ProfCredWorth) <> "") Then
            MessageBox.Show("Professor Credit Hour Worth is either Blank or of the wrong size.")
            passed = False
        End If

        If passed Then
            Try
                proc = "AddClass '" + Dept + "', '" + CourseNum + "' , '" + CourseName + "', " + StudentCredWorth.ToString + _
                                            ", " + ProfCredWorth.ToString + ", " + GradClass.ToString
                ds = SQL.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("Class was not inserted successfully into the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("Class was inserted successfully into the database.")
            tbAddClassDepartment.Clear()
            tbAddClassCourseNum.Clear()
            tbAddClassCourseName.Clear()
            tbAddClassStuCredHours.Clear()
            tbAddClassProfCredHour.Clear()
            chkGradClass.CheckState = CheckState.Unchecked
        End If

    End Sub

    Function CheckIntegerNumeric(ByVal str As String, ByVal length As Integer) As Boolean
        Dim numeric As Regex = New Regex("^\d{" + length.ToString + "}$", RegexOptions.None)
        Return numeric.Match(str.Trim(), 0).Success
    End Function

    Function CheckStringLength(ByVal str As String, ByVal minLength As Integer, ByVal maxLength As Integer) As Boolean
        Dim check As Boolean = True

        If Not Trim(str).Length >= minLength Then
            check = False
        End If

        If Not Trim(str).Length <= maxLength Then
            check = False
        End If

        Return check
    End Function

    Private Sub tcEditClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcEditClass.SelectedIndexChanged
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllClasses")
        Dim ds2 As DataSet = New DataSet
        Dim classID As Integer = 0
        Dim index As Integer = 0

        index = tcEditClass.SelectedIndex

        ' ClassID, Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
        tbEditClassCourseName.Text = ds.Tables(0).Rows(index).Item("CourseName")
        tbEditClassCourseNum.Text = ds.Tables(0).Rows(index).Item("CourseNum")
        tbEditClassDept.Text = ds.Tables(0).Rows(index).Item("Department")
        tbEditClassProfHr.Text = ds.Tables(0).Rows(index).Item("TeacherCreditHours")
        tbEditClassStuCredHr.Text = ds.Tables(0).Rows(index).Item("StudentCreditHours")
        chkEditClassGradClass.Checked = ds.Tables(0).Rows(index).Item("IsGradClass")
    End Sub

    Private Sub btnRemoveProfessor_Click(sender As Object, e As EventArgs) Handles btnRemoveProfessor.Click
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllProfessors")
        Dim ds2 As DataSet = New DataSet
        Dim TeacherID As String = ""
        Dim success As Boolean = True
        Dim index As Integer = 0
        Dim proc As String = ""

        Try
            TeacherID = cbRmProfessor.SelectedValue
            index = cbRmProfessor.SelectedIndex

            Dim result As Integer = MessageBox.Show("Are you sure that you would like to delete " + ds.Tables(0).Rows(index).Item("Professor") + "?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                proc = "DeleteProfessor '" + TeacherID + "'"
                ds2 = SQL.GetStoredProc(proc)


            Else
                success = False
            End If

        Catch ex As Exception
            success = False
        End Try

        If success Then
            ds.Tables(0).Rows(index).Delete()
            cbRmProfessor.DataSource = ds.Tables(0)
            cbRmProfessor.ValueMember = "Professor"
            MessageBox.Show("The Professor has been Removed successfully")
        Else
            MessageBox.Show("The Professor has not been removed")
        End If

    End Sub

    Private Sub btnAddProfSaveProf_Click(sender As Object, e As EventArgs) Handles btnAddProfSaveProf.Click
        Dim TeacherID As String = tbAddProfTeacherID.Text
        Dim FirstName As String = tbAddProfFirstName.Text
        Dim LastName As String = tbAddProfLastName.Text
        Dim CreditHours As String = tbAddProfCredHours.Text
        ' Will have to change to find what is selected
        Dim ProfRank As String = comboAddProfRank.Text
        Dim passed As Boolean = True
        Dim proc As String = ""
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect

        If Not (Trim(TeacherID) <> "" And CheckStringLength(TeacherID, 6, 6)) Then
            MessageBox.Show("Teacher ID is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(FirstName) <> "" And CheckStringLength(FirstName, 0, 255)) Then
            MessageBox.Show("First Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(LastName) <> "" And CheckStringLength(LastName, 0, 255)) Then
            MessageBox.Show("Last Name is either Blank or of the wrong size.")
            passed = False
        End If

        proc = "CheckIfProfessorExists '" + TeacherID + "', '" + FirstName + "', '" + LastName + "'"
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("The teacher: " + FirstName + " " + LastName + " or the ID Number: " + TeacherID + _
                                " already exists")
            passed = False
        End If

        If Not (Trim(CreditHours) <> "" And CheckStringLength(CreditHours, 0, 6)) Then
            MessageBox.Show("Yearly Credit Hours is either Blank or of the wrong size.")
            passed = False
        End If

        If passed Then
            Try
                proc = "AddProfessor '" + TeacherID + "', '" + FirstName + "' , '" + LastName + "', " + CreditHours + _
                                            ", '" + ProfRank + "'"
                ds = Sql.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("Class was not inserted successfully into the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("The professor was inserted successfully into the database.")
            tbAddProfTeacherID.Clear()
            tbAddProfFirstName.Clear()
            tbAddProfLastName.Clear()
            tbAddProfCredHours.Clear()
            comboAddProfRank.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbEditProfSelectProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEditProfSelectProf.SelectedIndexChanged
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllProfessors")
        Dim ds2 As DataSet = New DataSet
        Dim TeacherID As String = ""
        Dim index As Integer = 0
        ds2 = SQL.GetStoredProc("GetAllRanks")
        index = cbEditProfSelectProf.SelectedIndex
        TeacherID = ds.Tables(0).Rows(index).Item("TeacherID")

        comboEditProfRank.DisplayMember = ds2.Tables(0).Columns(0).ToString
        comboEditProfRank.ValueMember = ds2.Tables(0).Columns(1).ToString
        comboEditProfRank.DataSource = ds2.Tables(0)

        ' TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD
        tbEditProfTeacherID.Text = ds.Tables(0).Rows(index).Item("TeacherID")
        tbEditProfFirstName.Text = ds.Tables(0).Rows(index).Item("FirstName")
        tbEditProfLastName.Text = ds.Tables(0).Rows(index).Item("LastName")
        tbEditProfCredHours.Text = ds.Tables(0).Rows(index).Item("YearlyCreditHours")
        Dim Rank As Integer
        Rank = FindProfRank(ds.Tables(0).Rows(index).Item("ProfessorRank"))
        comboEditProfRank.SelectedIndex = Rank - 1
    End Sub

    Private Sub btnEditClassSave_Click(sender As Object, e As EventArgs) Handles btnEditClassSave.Click
        Dim Dept As String = tbEditClassDept.Text
        Dim CourseNum As String = tbEditClassCourseNum.Text
        Dim CourseName As String = tbEditClassCourseName.Text
        Dim StudentCredWorth As String = tbEditClassStuCredHr.Text
        Dim ProfCredWorth As String = tbEditClassProfHr.Text
        Dim GradClass As Boolean = chkEditClassGradClass.CheckState
        Dim passed As Boolean = True
        Dim SQL As New SQLConnect
        Dim ds As DataSet = New DataSet
        Dim proc As String = ""
        Dim index = tcEditClass.SelectedIndex
        Dim ClassID As Integer

        ClassID = tcEditClass.SelectedValue

        If Not (Trim(Dept) <> "" And CheckStringLength(Dept, 3, 4)) Then
            MessageBox.Show("Department is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(CourseNum) <> "" And CheckStringLength(CourseNum, 3, 3)) Then
            MessageBox.Show("Course Number is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (CheckIntegerNumeric(CourseNum, 3)) Then
            MessageBox.Show("A Course Number Must be a 3 Digit Numeric Value")
            passed = False
        End If

        If Not (Trim(CourseName) <> "" And CheckStringLength(CourseName, 0, 255)) Then
            MessageBox.Show("Course Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(StudentCredWorth) <> "") Then
            MessageBox.Show("Student Credit Hour Worth is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(ProfCredWorth) <> "") Then
            MessageBox.Show("Professor Credit Hour Worth is either Blank or of the wrong size.")
            passed = False
        End If

        If passed Then
            Try
                proc = "EditClass '" + Dept + "', '" + CourseNum + "' , '" + CourseName + "', " + StudentCredWorth.ToString + _
                                            ", " + ProfCredWorth.ToString + ", " + GradClass.ToString + ", " + ClassID.ToString
                ds = SQL.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("Class was not successfully changed in the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("Class was successfully edited in the database.")

            ds = SQL.GetStoredProc("GetAllClasses")

            tcEditClass.DisplayMember = ds.Tables(0).Columns(0).ToString
            tcEditClass.ValueMember = ds.Tables(0).Columns(1).ToString
            tcEditClass.DataSource = ds.Tables(0)
        End If

    End Sub

    Private Sub btnEditProfessorSave_Click(sender As Object, e As EventArgs) Handles btnEditProfessorSave.Click
        Dim TeacherID As String = tbEditProfTeacherID.Text
        Dim FirstName As String = tbEditProfFirstName.Text
        Dim LastName As String = tbEditProfLastName.Text
        Dim CreditHours As String = tbEditProfCredHours.Text
        Dim ProfRank As String = comboEditProfRank.Text
        Dim passed As Boolean = True
        Dim proc As String = ""
        Dim ds As DataSet = New DataSet
        Dim SQL As New SQLConnect

        TeacherID = cbEditProfSelectProf.SelectedValue
        'OrigCourseNum = Trim(tcEditClass.SelectedValue.ToString.Substring(5, 3))

        If Not (Trim(FirstName) <> "" And CheckStringLength(FirstName, 0, 255)) Then
            MessageBox.Show("First Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(LastName) <> "" And CheckStringLength(LastName, 0, 255)) Then
            MessageBox.Show("Last Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(CreditHours) <> "" And CheckStringLength(CreditHours, 0, 6)) Then
            MessageBox.Show("Yearly Credit Hours is either Blank or of the wrong size.")
            passed = False
        End If

        If passed Then
            Try
                proc = "EditProfessor '" + TeacherID + "', '" + FirstName + "' , '" + LastName + "', " + CreditHours + _
                                            ", " + ProfRank
                ds = SQL.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("The professor was not successfully changed in the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("Class was successfully edited in the database.")
            ds = SQL.GetStoredProc("GetAllProfessors")

            cbEditProfSelectProf.DisplayMember = ds.Tables(0).Columns(0).ToString
            cbEditProfSelectProf.ValueMember = ds.Tables(0).Columns(1).ToString
            cbEditProfSelectProf.DataSource = ds.Tables(0)
        End If

    End Sub

    Function FindProfRank(ByVal ProfessorRank As String) As Integer
        Dim ds As DataSet = New DataSet
        Dim SQL As New SQLConnect

        ds = SQL.GetStoredProc("FindProfRankID '" + ProfessorRank + "'")

        If ds IsNot Nothing Then
            Return ds.Tables(0).Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function


    Private Sub btnEditRoomRoomColor_Click(sender As Object, e As EventArgs) Handles btnEditRoomRoomColor.Click
        Dim c1 As Color

        ' Allow the user to select a room color
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            c1 = ColorDialog1.Color
            btnEditRoomRoomColor.BackColor = c1
        End If
    End Sub

    Private Sub comboEditRoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboEditRoom.SelectedIndexChanged
        ' EDIT ROOM
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect
        Dim classID As Integer = 0
        Dim index As Integer = 0
        Dim RoomColor As Integer
        Dim ColorString As String = ""

        ds = Sql.GetStoredProc("GetAllRooms")

        index = comboEditRoom.SelectedIndex

        txtEditRoomBuildingName.Text = ds.Tables(0).Rows(index).Item("BuildingName").ToString
        txtEditRoomRmNumber.Text = ds.Tables(0).Rows(index).Item("RoomNumber").ToString

        RoomColor = Convert.ToInt32(Trim(ds.Tables(0).Rows(index).Item("RoomColor").ToString))

        btnEditRoomRoomColor.BackColor = Color.FromArgb(RoomColor)
    End Sub

    Private Sub btnEditRoomSave_Click(sender As Object, e As EventArgs) Handles btnEditRoomSave.Click
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect
        Dim passed As Boolean = True
        Dim BuildingName As String = txtEditRoomBuildingName.Text
        Dim RoomNumber As String = txtEditRoomRmNumber.Text
        Dim RoomColor As Integer = btnEditRoomRoomColor.BackColor.ToArgb
        Dim proc As String = ""
        Dim index As Integer

        index = comboEditRoom.SelectedValue

        If Not (Trim(BuildingName) <> "" And CheckStringLength(BuildingName, 0, 255)) Then
            MessageBox.Show("Building Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(RoomNumber) <> "" And CheckStringLength(RoomNumber, 0, 10)) Then
            MessageBox.Show("Room Number is either Blank or of the wrong size.")
            passed = False
        End If


        If btnEditRoomRoomColor.BackColor = Color.Transparent Then
            MessageBox.Show("Please click the button and select a color for your room.")
            passed = False
        End If

        proc = "CheckIfRoomExists '" + BuildingName + "', '" + RoomNumber + "'"
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            If index.ToString <> ds2.Tables(0).Rows(0).Item("RoomID").ToString Then

                MessageBox.Show("The room: " + BuildingName + " " + RoomNumber + " already exists in the database")
                passed = False
            End If
        End If

        proc = "CheckIfRoomColorExists " + RoomColor.ToString
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            If index.ToString <> ds2.Tables(0).Rows(0).Item("RoomID").ToString Then
                Dim result As Integer = MessageBox.Show("The room color that was selected already exists in the database, would you like to proceed using that color?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Yes Then
                    ' DO NOTHING YET
                Else
                    passed = False
                    MessageBox.Show("Please select a new color and hit save again.")
                End If
            End If
        End If

        If passed Then
            Try
                proc = "EditRoom " + index.ToString + ", '" + BuildingName + "', '" + RoomNumber + "' , " + RoomColor.ToString
                ds = SQL.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("The room was not successfully changed in the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("The room was successfully edited in the database.")
            ds = SQL.GetStoredProc("GetAllRooms")

            comboEditRoom.DisplayMember = ds.Tables(0).Columns("Room").ToString
            comboEditRoom.ValueMember = ds.Tables(0).Columns(0).ToString
            comboEditRoom.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub btnRemoveRoom_Click(sender As Object, e As EventArgs) Handles btnRemoveRoom.Click
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllRooms")
        Dim ds2 As DataSet = New DataSet
        Dim RoomID As String = ""
        Dim success As Boolean = True
        Dim index As Integer = 0
        Dim proc As String = ""

        Try
            RoomID = comboRemoveRoom.SelectedValue
            index = comboRemoveRoom.SelectedIndex

            Dim result As Integer = MessageBox.Show("Are you sure that you would like to delete " + ds.Tables(0).Rows(index).Item("Room") + "?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                proc = "RemoveRoom '" + RoomID + "'"
                ds2 = SQL.GetStoredProc(proc)


            Else
                success = False
            End If

        Catch ex As Exception
            success = False
        End Try

        If success Then
            ds.Tables(0).Rows(index).Delete()
            comboRemoveRoom.DisplayMember = ds.Tables(0).Columns("Room").ToString
            comboRemoveRoom.ValueMember = ds.Tables(0).Columns(0).ToString
            comboRemoveRoom.DataSource = ds.Tables(0)

            MessageBox.Show("The room has been Removed successfully")
        Else
            MessageBox.Show("The room has not been removed")
        End If
    End Sub

    Private Sub btnAddRoomSave_Click(sender As Object, e As EventArgs) Handles btnAddRoomSave.Click
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect
        Dim passed As Boolean = True
        Dim BuildingName As String = txtAddRoomBuildingName.Text
        Dim RoomNumber As String = txtAddRoomRmNumber.Text
        Dim RoomColor As Integer = btnAddRoomRoomColor.BackColor.ToArgb
        Dim proc As String = ""

        If Not (Trim(BuildingName) <> "" And CheckStringLength(BuildingName, 0, 255)) Then
            MessageBox.Show("Building Name is either Blank or of the wrong size.")
            passed = False
        End If

        If Not (Trim(RoomNumber) <> "" And CheckStringLength(RoomNumber, 0, 10)) Then
            MessageBox.Show("Room Number is either Blank or of the wrong size.")
            passed = False
        End If

        If btnAddRoomRoomColor.BackColor = Color.Transparent Then
            MessageBox.Show("Please click the button and select a color for your room.")
            passed = False
        End If

        proc = "CheckIfRoomExists '" + BuildingName + "', '" + RoomNumber + "'"
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("The room: " + BuildingName + " " + RoomNumber + " already exists in the database")
            passed = False
        End If

        proc = "CheckIfRoomColorExists " + RoomColor.ToString
        ds2 = SQL.GetStoredProc(proc)

        If Not ds2 Is Nothing And ds2.Tables(0).Rows.Count > 0 Then
            Dim result As Integer = MessageBox.Show("The color that was selected already exists in the database, would you like to proceed using that color?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                ' DO NOTHING YET
            Else
                passed = False
                MessageBox.Show("Please select a new color and hit save again.")
            End If
        End If

        If passed Then
            Try
                proc = "AddRoom " + "'" + BuildingName + "', '" + RoomNumber + "' , " + RoomColor.ToString
                ds = SQL.GetStoredProc(proc)
            Catch ex As Exception
                passed = False
                MessageBox.Show("The room was not successfully added to the database.")
            End Try

        Else
            MessageBox.Show("Please fix the problems and try again")
        End If

        If passed Then
            MessageBox.Show("The room was successfully added to the database.")
        End If
    End Sub

    Private Sub btnAddRoomRoomColor_Click(sender As Object, e As EventArgs) Handles btnAddRoomRoomColor.Click
        Dim c1 As Color

        ' Allow the user to select a room color
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            c1 = ColorDialog1.Color
            btnAddRoomRoomColor.BackColor = c1
        End If
    End Sub
End Class
