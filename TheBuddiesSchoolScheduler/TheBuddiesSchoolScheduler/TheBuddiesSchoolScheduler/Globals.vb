Public Class Globals
    Public Shared dataTable As DataTable
    Public Shared semester As String
    Public Shared label As String
    Public Shared roomColors As Dictionary(Of String, Color)
    'Public Shared scheduleDataTable As DataTable

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

    Public Sub SetLabel(lbl As String)
        label = lbl
    End Sub

    Public Function GetLabel(lbl As String)
        lbl = label
        Return lbl
    End Function

    Public Sub SetRoomColors(dict As Dictionary(Of String, Color))
        roomColors = dict
    End Sub

    Public Function GetRoomColors()
        Return roomColors
    End Function

End Class
