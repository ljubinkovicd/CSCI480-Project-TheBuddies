Public Class Globals
    Public Shared dataTable As DataTable

    Public Sub SetDT(dt As DataTable)
        dataTable = dt
    End Sub

    Public Function GetDT(dt As DataTable)
        dt = dataTable
        Return dt
    End Function
End Class
