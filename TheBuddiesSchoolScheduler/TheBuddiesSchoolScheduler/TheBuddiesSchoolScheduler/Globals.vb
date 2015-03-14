Public Class Globals
    Public Shared dataTable As DataTable
    Public Shared semester As String

    Public Sub SetDT(dt As DataTable)
        dataTable = dt
    End Sub

    Public Function GetDT(dt As DataTable)
        dt = dataTable
        Return dt
    End Function

    Public Sub SetSemester(s As String)
        semester = s
    End Sub

    Public Function GetSemester(s As String)
        s = semester
        Return s
    End Function
End Class
