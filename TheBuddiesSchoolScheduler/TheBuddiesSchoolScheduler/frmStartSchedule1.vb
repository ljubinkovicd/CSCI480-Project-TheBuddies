Imports TheBuddiesSchoolScheduler.SQLConnect
Imports TheBuddiesSchoolScheduler.Globals
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmStartSchedule1

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim g As New Globals

        'Set the semester
        Dim semester As String = cboSemester.Text
        g.SetSemester(semester)

        'check if this semester already exists
        Dim sql As New SQLConnect
        Dim ds As DataSet = sql.GetStoredProc("LoadScreenTermsAndYears")
        Dim cont As Boolean = True

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr.Item("TermAndYear").ToString = semester Then
                Dim response = MsgBox("Do you want to overwrite this semester and year?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete Semester and Year?")
                If response = MsgBoxResult.Yes Then
                    'delete that semester and year
                    Dim term As String = semester.Substring(0, semester.IndexOf(" "))
                    Dim termYear As String = semester.Substring(semester.IndexOf(" ") + 1)
                    Dim dsDelete As New DataSet
                    dsDelete = sql.GetStoredProc("DeleteSemesterAndYearFromSchedule '" + term + "', '" + termYear + "'")
                Else
                    'do not continue on
                    cont = False
                End If
            End If
        Next

        If cont Then
            'Save the values in the grid to be used in the next page
            Dim dt As New DataTable
            dt = TryCast(ClassListGridView.DataSource, DataTable)

            'pass this datatable to the next screen
            g.SetDT(dt)

            frmStartSchedule2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frmStartSchedule1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetClasses")

        ClassListGridView.DataSource = ds.Tables(0)
        ClassListGridView.Columns("Course").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        ClassListGridView.Columns("Course Name").Width = 285
        ClassListGridView.Columns("Day").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        ClassListGridView.Columns("Night").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        ClassListGridView.Columns("Online").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        'Get current year and put values close to that in combo box
        Dim thisYear As Integer = Today.Year

        For i As Integer = -3 To 3
            cboSemester.Items.Add("Spring " + ((thisYear + i).ToString))
            cboSemester.Items.Add("Fall " + ((thisYear + i).ToString))
            cboSemester.Items.Add("Summer" + ((thisYear + i).ToString))
        Next

        'change to reflect the next semester
        cboSemester.SelectedText = "Spring " + thisYear.ToString

        '.AllowUserToAddRows = False
        '.AllowUserToDeleteRows = False
        '.AllowUserToOrderColumns = False
        '.AllowUserToResizeColumns = False
        '.AllowUserToResizeRows = False
        '.AutoGenerateColumns = False

    End Sub
End Class