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
