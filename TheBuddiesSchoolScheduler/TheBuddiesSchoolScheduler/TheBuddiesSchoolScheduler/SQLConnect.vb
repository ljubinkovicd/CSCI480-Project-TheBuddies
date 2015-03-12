Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SQLConnect
    Public SQLCon As New SqlConnection
    Public SQLCmd As New SqlCommand
    Public Sub Connect(username As String, password As String)
        Try
            SQLCon.ConnectionString = "Server=ALEXPC\ALEX080714;Database=SchoolScheduler;User=" + username.ToString + ";Pwd=" + password.ToString + ";"
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
End Class
