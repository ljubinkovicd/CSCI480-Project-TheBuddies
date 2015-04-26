Public Class Globals
    Public Shared dataTable As DataTable
    Public Shared semester As String
    Public Shared label As String
    Public Shared roomColors As Dictionary(Of String, Color)
    Public Shared roomNumberColors As Dictionary(Of String, Color)
    Public Shared tempdt As DataTable
    Public Shared isBack As Boolean = False

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

    Public Sub SetRoomNumberColors(dictionary As Dictionary(Of String, Color))
        roomNumberColors = dictionary
    End Sub

    Public Function GetRoomNumberColors()
        Return roomNumberColors
    End Function

    Public Sub SetRoomColors(dict As Dictionary(Of String, Color))
        roomColors = dict
    End Sub

    Public Function GetRoomColors()
        Return roomColors
    End Function

    Public Sub SetTempDT(dt As DataTable)
        tempdt = dt
    End Sub

    Public Function GetTempDT(dt As DataTable)
        dt = tempdt
        Return dt
    End Function

    Public Sub IsBackTrue()
        isBack = True
    End Sub

    Public Sub IsBackFalse()
        isBack = False
    End Sub

    Public Function GetIsBack()
        Return isBack
    End Function
End Class
