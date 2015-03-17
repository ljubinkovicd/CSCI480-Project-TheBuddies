
Imports System.Text.RegularExpressions

Public Class frmDatabaseMaintenance

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEditClass_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRemoveClass_Click(sender As Object, e As EventArgs)


    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

    End Sub

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

            tcEditClass.DataSource = ds.Tables(0)
            tcEditClass.ValueMember = "Course"
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

            cbDBData.DataSource = ds.Tables(0)
            cbDBData.ValueMember = "Course"
            'cbDBData.DisplayMember = "au_lname"
            cbDBData.Visible = True
            btnRemove.Visible = True '
        ElseIf tcDBMaint.SelectedIndex = 3 Then

        ElseIf tcDBMaint.SelectedIndex = 4 Then

        ElseIf tcDBMaint.SelectedIndex = 5 Then


        End If
    End Sub

    Private Sub btnRemove_Click_1(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetCourseNumAndClassName")
        Dim ds2 As DataSet = New DataSet
        Dim classID As Integer = 0
        Dim index As Integer = 0

        Try
            index = cbDBData.SelectedIndex
            classID = ds.Tables(0).Rows(index).Item("ClassID")

            ds2 = SQL.GetStoredProc("RemoveClass " + classID.ToString())

            ds.Tables(0).Rows(index).Delete()

            cbDBData.DataSource = ds.Tables(0)
            cbDBData.ValueMember = "Course"
        Catch ex As Exception

        End Try

        MessageBox.Show("The Course has been Removed succesfully")
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
        Dim proc As String = ""

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
End Class