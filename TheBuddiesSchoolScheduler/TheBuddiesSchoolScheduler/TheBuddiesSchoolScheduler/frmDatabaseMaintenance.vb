﻿
Imports System.Text.RegularExpressions

Public Class frmDatabaseMaintenance

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmWelcome.Visible = True

        Me.Visible = False
    End Sub


    Private Sub tcDBMaint_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles tcDBMaint.SelectedIndexChanged
        Dim ds As DataSet = New DataSet
        Dim ds2 As DataSet = New DataSet
        Dim SQL As New SQLConnect
        Dim classID As Integer = 0
        Dim index As Integer = 0

        If tcDBMaint.SelectedIndex = 0 Then
            ' Add Class Tab

        ElseIf tcDBMaint.SelectedIndex = 1 Then
            ' Edit Class Tab
            ds = SQL.GetStoredProc("GetCourseNumAndClassName")

            tcEditClass.DisplayMember = ds.Tables(0).Columns(0).ToString
            tcEditClass.ValueMember = ds.Tables(0).Columns(1).ToString
            tcEditClass.DataSource = ds.Tables(0)

            'cbDBData.DisplayMember = "au_lname"

            ds2 = SQL.GetStoredProc("GetAllClasses")

            index = tcEditClass.SelectedIndex
            classID = ds.Tables(0).Rows(0).Item("ClassID")

            ' ClassID, Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
            tbEditClassCourseName.Text = ds2.Tables(0).Rows(0).Item("CourseName")
            tbEditClassCourseNum.Text = ds2.Tables(0).Rows(0).Item("CourseNum")
            tbEditClassDept.Text = ds2.Tables(0).Rows(0).Item("Department")
            tbEditClassProfHr.Text = ds2.Tables(0).Rows(0).Item("TeacherCreditHours")
            tbEditClassStuCredHr.Text = ds2.Tables(0).Rows(0).Item("StudentCreditHours")
            chkEditClassGradClass.CheckState = ds2.Tables(0).Rows(0).Item("IsGradClass")

        ElseIf tcDBMaint.SelectedIndex = 2 Then
            ' Remove Class Tab
            ds = SQL.GetStoredProc("GetCourseNumAndClassName")

            cbDBData.DisplayMember = ds.Tables(0).Columns(0).ToString
            cbDBData.ValueMember = ds.Tables(0).Columns(1).ToString

            cbDBData.DataSource = ds.Tables(0)
        ElseIf tcDBMaint.SelectedIndex = 3 Then
            ' Add Professor

        ElseIf tcDBMaint.SelectedIndex = 4 Then
            ' Edit Professor
            ds = SQL.GetStoredProc("GetProfessorName")

            cbEditProfSelectProf.DisplayMember = ds.Tables(0).Columns(1).ToString
            cbEditProfSelectProf.ValueMember = ds.Tables(0).Columns(0).ToString
            cbEditProfSelectProf.DataSource = ds.Tables(0)

            ds2 = SQL.GetStoredProc("GetAllProfessors")

            index = cbEditProfSelectProf.SelectedIndex

            ' TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD
            tbEditProfTeacherID.Text = ds2.Tables(0).Rows(0).Item("TeacherID")
            tbEditProfFirstName.Text = ds2.Tables(0).Rows(0).Item("FirstName")
            tbEditProfLastName.Text = ds2.Tables(0).Rows(0).Item("LastName")
            tbEditProfCredHours.Text = ds2.Tables(0).Rows(0).Item("YearlyCreditHours")
            chkEditProfAssociates.Checked = ds2.Tables(0).Rows(0).Item("Associates")
            chkEditProfBachelors.Checked = ds2.Tables(0).Rows(0).Item("Bachelors")
            chkEditProfMasters.Checked = ds2.Tables(0).Rows(0).Item("Masters")
            chkEditProfPhD.Checked = ds2.Tables(0).Rows(0).Item("PhD")
        ElseIf tcDBMaint.SelectedIndex = 5 Then
            ' Remove Professor
            ds = SQL.GetStoredProc("GetProfessorName")

            cbRmProfessor.DisplayMember = ds.Tables(0).Columns(1).ToString
            cbRmProfessor.ValueMember = ds.Tables(0).Columns(0).ToString

            cbRmProfessor.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub btnRemove_Click_1(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetCourseNumAndClassName")
        Dim ds2 As DataSet = New DataSet
        Dim classID As Integer = 0
        Dim index As Integer = 0
        Dim success As Boolean = True

        Try
            index = cbDBData.SelectedIndex
            classID = ds.Tables(0).Rows(index).Item("ClassID")

            Dim result As Integer = MessageBox.Show("Are you sure that you would like to delete " + ds.Tables(0).Rows(index).Item("Course") + "?", "The Buddies Scheduler", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                ds2 = SQL.GetStoredProc("RemoveClass " + classID.ToString())
                ds.Tables(0).Rows(index).Delete()
                cbDBData.DataSource = ds.Tables(0)
                cbDBData.ValueMember = "Course"
            Else
                success = False
            End If
        Catch ex As Exception
            success = False
        End Try

        If success Then
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
        classID = ds.Tables(0).Rows(index).Item("ClassID")

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
        Dim ds As DataSet = SQL.GetStoredProc("GetProfessorName")
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
                ds.Tables(0).Rows(index).Delete()
                cbRmProfessor.DataSource = ds.Tables(0)
                cbRmProfessor.ValueMember = "Professor"
            Else
                success = False
            End If

        Catch ex As Exception
            success = False
        End Try

        If success Then
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
        Dim Associates As Boolean = chkAddProfAssociates.Checked
        Dim Bachelors As Boolean = chkAddProfBachelors.Checked
        Dim Masters As Boolean = chkAddProfMasters.Checked
        Dim Doctorate As Boolean = chkAddProfPhD.Checked
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
                                            ", " + Associates.ToString + ", " + Bachelors.ToString + ", " + Masters.ToString + ", " + Doctorate.ToString
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
            chkAddProfAssociates.CheckState = CheckState.Unchecked
            chkAddProfBachelors.CheckState = CheckState.Unchecked
            chkAddProfMasters.CheckState = CheckState.Unchecked
            chkAddProfPhD.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub cbEditProfSelectProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEditProfSelectProf.SelectedIndexChanged
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetAllProfessors")
        Dim ds2 As DataSet = New DataSet
        Dim TeacherID As String = ""
        Dim index As Integer = 0

        index = cbEditProfSelectProf.SelectedIndex
        TeacherID = ds.Tables(0).Rows(index).Item("TeacherID")

        ' TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD
        tbEditProfTeacherID.Text = ds.Tables(0).Rows(index).Item("TeacherID")
        tbEditProfFirstName.Text = ds.Tables(0).Rows(index).Item("FirstName")
        tbEditProfLastName.Text = ds.Tables(0).Rows(index).Item("LastName")
        tbEditProfCredHours.Text = ds.Tables(0).Rows(index).Item("YearlyCreditHours")
        chkEditProfAssociates.Checked = ds.Tables(0).Rows(index).Item("Associates")
        chkEditProfBachelors.Checked = ds.Tables(0).Rows(index).Item("Bachelors")
        chkEditProfMasters.Checked = ds.Tables(0).Rows(index).Item("Masters")
        chkEditProfPhD.Checked = ds.Tables(0).Rows(index).Item("PhD")
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

            ds = SQL.GetStoredProc("GetCourseNumAndClassName")

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
        Dim Associates As Boolean = chkEditProfAssociates.Checked
        Dim Bachelors As Boolean = chkEditProfBachelors.Checked
        Dim Masters As Boolean = chkEditProfMasters.Checked
        Dim Doctorate As Boolean = chkEditProfPhD.Checked
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
                                            ", " + Associates.ToString + ", " + Bachelors.ToString + ", " + Masters.ToString + ", " + Doctorate.ToString
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
            ds = SQL.GetStoredProc("GetProfessorName")

            cbEditProfSelectProf.DisplayMember = ds.Tables(0).Columns(1).ToString
            cbEditProfSelectProf.ValueMember = ds.Tables(0).Columns(0).ToString
            cbEditProfSelectProf.DataSource = ds.Tables(0)
        End If

    End Sub
End Class