'Title: The Buddies School Scheduler
'Authors: Djordje Ljubinkovic, Alex Moser, Chris Reaper, Baylee Smith
'Release Date: 4/27/2015
'Description: The Buddies School Scheduler is a VB.net program made for the client Dr.Geise
'in CSCI 480 under Dr. Ringenberg. This program is meant to assist Dr.Geise in her semester class
'scheduling endeavors by allowing her to more easily assess where and when certain classes need to be.
'We have aided her in providing a drag and drop interface, color-coded room visuals, a running total
'of faculty hours, and a complete database management system where Dr. Geise can completely customize
'her experience to her needs. The program also prints out to Microsoft Excel through the "Reports"
'button on the main screen, which prints out several different versions of the report, including 
'Weekly, by day, and by faculty.

Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SQLConnect
    Public SQLCon As New SqlConnection
    Public SQLCmd As New SqlCommand
    Public Shared connectionString As String

    Public Sub Connect(server As String, database As String, username As String, password As String)
        Try
            connectionString = "Server=" + server + ";Database=" + database + ";User=" + username.ToString + ";Pwd=" + password.ToString + ";"
            'connectionString = "Server=Mars;Database=480-buddies;User=480-buddies;Pwd=schedule;"
            SQLCon.ConnectionString = connectionString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function HasConnection() As String
        Try
            SQLCon.Open()
            SQLCon.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function GetStoredProc(proc As String)
        Dim ds As New DataSet

        'Dim connetionString As String
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim sql As String

        sql = "EXEC " + proc

        con = New SqlConnection(connectionString)

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

        Return ds
    End Function

    Public Function GetQuery(query As String)
        Dim ds As New DataSet

        'Dim connetionString As String
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim sql As String

        sql = query

        con = New SqlConnection(connectionString)

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

        Return ds
    End Function
End Class
