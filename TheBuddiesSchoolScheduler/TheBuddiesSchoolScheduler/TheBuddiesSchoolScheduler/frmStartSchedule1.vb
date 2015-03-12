Imports TheBuddiesSchoolScheduler.SQLConnect
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

        Me.Visible = False
        frmStartSchedule2.Visible = True
    End Sub

    Private Sub frmStartSchedule1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get all of the classes from the CLASS table
        Dim connetionString As String
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim sql As String

        'Temporary solution
        '*****needs to change based on the person testing this******
        connetionString = "Server=ALEXPC\ALEX080714;Database=SchoolScheduler;User=test_user;Pwd=pass;"
        sql = "EXEC GetClasses"

        con = New SqlConnection(connetionString)

        Try
            con.Open()
            cmd = New SqlCommand(sql, con)
            adapter.SelectCommand = cmd
            adapter.Fill(ds)
            adapter.Dispose()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ClassListGridView.DataSource = ds.Tables(0)
        '.AllowUserToAddRows = False
        '.AllowUserToDeleteRows = False
        '.AllowUserToOrderColumns = False
        '.AllowUserToResizeColumns = False
        '.AllowUserToResizeRows = False
        '.AutoGenerateColumns = False

    End Sub
End Class