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
