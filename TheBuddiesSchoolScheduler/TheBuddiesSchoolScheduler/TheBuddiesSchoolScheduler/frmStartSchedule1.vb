Imports TheBuddiesSchoolScheduler.SQLConnect
Imports TheBuddiesSchoolScheduler.Globals
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmStartSchedule1

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmWelcome.Visible = True
        Me.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmWelcome.Visible = True
        Me.Visible = False
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Save the values in the grid to be used in the next page
        Dim dt As New DataTable
        dt = TryCast(ClassListGridView.DataSource, DataTable)

        'pass this datatable to the next screen
        Dim g As New Globals
        g.SetDT(dt)

        Me.Visible = False
        frmStartSchedule2.Visible = True
    End Sub

    Private Sub frmStartSchedule1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As New SQLConnect
        Dim ds As DataSet = SQL.GetStoredProc("GetClasses")

        ClassListGridView.DataSource = ds.Tables(0)
        '.AllowUserToAddRows = False
        '.AllowUserToDeleteRows = False
        '.AllowUserToOrderColumns = False
        '.AllowUserToResizeColumns = False
        '.AllowUserToResizeRows = False
        '.AutoGenerateColumns = False

    End Sub
End Class