﻿Imports TheBuddiesSchoolScheduler.SQLConnect
Imports TheBuddiesSchoolScheduler.Globals
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmStartSchedule1
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim g As New Globals
        g.IsBackFalse()
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

                'pass a temp dt in case of selecting back in the next screen
                g.SetTempDT(dt)
                g.IsBackFalse()

                frmStartSchedule2.Show()
                Me.Close()
            End If
    End Sub

    Private Sub frmStartSchedule1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim g As New Globals
            Dim back As Boolean = g.GetIsBack()
            If back Then
                'load old data table
                Dim dt As New DataTable
                ClassListGridView.DataSource = g.GetTempDT(dt)
            Else
                Dim SQL As New SQLConnect
                Dim ds As DataSet = SQL.GetStoredProc("GetClasses")

                ClassListGridView.DataSource = ds.Tables(0)
            End If

            ClassListGridView.RowHeadersVisible = False
            ClassListGridView.Columns("Course").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ClassListGridView.Columns("Course Name").Width = 285
            ClassListGridView.Columns("Day").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ClassListGridView.Columns("Night").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ClassListGridView.Columns("Online").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            'Do not let the user edit the first two columns
            ClassListGridView.Columns("Course").ReadOnly = True
            ClassListGridView.Columns("Course Name").ReadOnly = True

            'Get current year and put values close to that in combo box
            Dim thisYear As Integer = Today.Year

            For i As Integer = -3 To 3
                cboSemester.Items.Add("Spring " + ((thisYear + i).ToString))
                cboSemester.Items.Add("Fall " + ((thisYear + i).ToString))
                cboSemester.Items.Add("Summer " + ((thisYear + i).ToString))
            Next
            cboSemester.SelectedText = "Spring " + thisYear.ToString

            '** need to not allow her to edit any of the data grid views

            ClassListGridView.AllowUserToAddRows = False
            ClassListGridView.AllowUserToDeleteRows = False
            '.AllowUserToOrderColumns = False
            '.AllowUserToResizeColumns = False
            ClassListGridView.AllowUserToResizeRows = False
            '.AutoGenerateColumns = False
        Catch ex As Exception
            MsgBox("Error loading data")
        End Try
    End Sub

    Private Sub ClassListGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ClassListGridView.CellEndEdit
        Dim t = ClassListGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If Not IsNumeric(t) Then
            ClassListGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
            ClassListGridView.CurrentCell = ClassListGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            MsgBox("Invalid Data")
        End If
    End Sub
End Class