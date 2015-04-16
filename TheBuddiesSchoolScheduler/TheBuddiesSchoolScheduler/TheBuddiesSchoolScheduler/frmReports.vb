'References that we need
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmReports

    Dim monStart As Integer = 1
    Dim tuesStart As Integer = 2
    Dim wedStart As Integer = 3
    Dim thursStart As Integer = 4
    Dim friStart As Integer = 5
    Dim satStart As Integer = 6
    Dim sunStart As Integer = 7

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub
    Private Sub ExportToExcel_Click(sender As Object, e As EventArgs) Handles ExportToExcel.Click
        'Initialize the objects before use
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        dataSet = GetScheduleDS()

        ' User is able to select a folder into which to export excel.
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section helps if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet

                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                Dim dataTableCollection As System.Data.DataTableCollection = dataSet.Tables
                Dim numberOfSheets As Integer = dataTableCollection.Count

                Dim dataTable As System.Data.DataTable
                Dim sheetCounter As Integer = 1

                'Adding empty sheets based on data table count
                For Each dataTable In dataTableCollection
                    oBook.Worksheets.Add()
                Next

                'Exports all data tables to corresponding data sheets.
                For Each dataTable In dataTableCollection
                    oSheet = oBook.Worksheets(sheetCounter)
                    oSheet.Name = dataTable.TableName
                    If (dataTable.TableName = "WeeklyTable") Then
                        getRoomColors(dataTable)
                    End If
                    exportDataSetToExcelWorksheet(dataTable, oSheet)
                    sheetCounter += 1
                Next

                'Set final path
                Dim fileName As String = "\Schedule" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: 
                'so i am calling GC.Collect method.
                GC.Collect()

                MessageBox.Show("Export done successfully!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub getRoomColors(ByVal dt As System.Data.DataTable)

        Dim g As New Globals

        Dim dictionary As Dictionary(Of String, Color) = New Dictionary(Of String, Color)

        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim data As String
        Dim dataStrings As String()
        Dim roomNum As String
        Dim dataInfo As String
        Dim c As Color
        Dim i As Integer

        Dim roomColors = g.GetRoomColors()

        'Export the rows to excel file
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 1
            For i = 1 To dt.Columns.Count - 1
                colIndex = colIndex + 1
                data = dr(i).ToString()
                If Not String.IsNullOrEmpty(data) Then
                    dataStrings = data.Split(" ")
                    roomNum = dataStrings(0)
                    dataInfo = data.Substring(2)
                    If roomColors.ContainsKey(roomNum) Then
                        c = roomColors.Item(roomNum)
                        If Not dictionary.ContainsKey(dataInfo) Then
                            dictionary.Add(dataInfo, c)
                        End If
                    End If
                End If
            Next
        Next

        g.SetRoomColors(dictionary)

    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Function GetScheduleDS()
        Dim mainds As New DataSet
        Dim sql As New SQLConnect
        Dim tempds As New DataSet
        Dim weeklyTable As New System.Data.DataTable
        Dim dayTable As New System.Data.DataTable
        Dim profTable As New System.Data.DataTable
        Dim tempTable As New System.Data.DataTable

        Dim termAndYear As String = lblTerm.Text
        'temporary term and termyear
        Dim termArray As String() = termAndYear.Split(" ")
        Dim term As String = termArray(0)
        Dim termYear As String = termArray(1)

        'weekly report
        tempds = sql.GetStoredProc("WeeklyReport '" + term + "', '" + termYear + "'")
        weeklyTable = tempds.Tables(0).Copy()

        weeklyTable = GetWeeklyReport(weeklyTable)
        weeklyTable.TableName = "WeeklyTable"

        mainds.Tables.Add(weeklyTable)

        'dgvTest.DataSource = weeklyTable

        'faculty reports
        tempds = sql.GetStoredProc("GetProfessorName")

        For Each dr As DataRow In tempds.Tables(0).Rows
            tempTable = GetFacultyReport(dr.Item("TeacherID").ToString, term, termYear)
            profTable = tempTable.Copy()
            profTable.TableName = dr.Item("Professor").ToString
            mainds.Tables.Add(profTable)
        Next

        'dgvTest.DataSource = mainds.Tables("Langhals")
        'dgvTest.DataSource = mainds.Tables("Baker")

        'Daily Reports
        For i = 0 To 6
            Dim day As String = ""
            Select Case i
                Case 0
                    day = "Mon"
                Case 1
                    day = "Tues"
                Case 2
                    day = "Wed"
                Case 3
                    day = "Thurs"
                Case 4
                    day = "Fri"
                Case 5
                    day = "Sat"
                Case 6
                    day = "Sun"
            End Select
            tempTable = tempds.Tables(0).Copy()
            tempTable = GetDailyReports(tempTable, day, term, termYear)
            dayTable = tempTable.Copy()
            dayTable.TableName = day
            mainds.Tables.Add(dayTable)
            'If day = "Wed" Then
            '    dgvTest.DataSource = dayTable
            'End If
        Next

        'loop back through to turn the military time to normal
        changeMilitaryTime(mainds)

        Return mainds
    End Function

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim str As String = ""
        lblTerm.Text = g.GetSemester(str)
    End Sub

    Private Sub IncColStart(ByVal day As String)
        If day = "Monday" Then
            tuesStart += 1
            wedStart += 1
            thursStart += 1
            friStart += 1
            satStart += 1
            sunStart += 1
        ElseIf day = "Tuesday" Then
            wedStart += 1
            thursStart += 1
            friStart += 1
            satStart += 1
            sunStart += 1
        ElseIf day = "Wednesday" Then
            thursStart += 1
            friStart += 1
            satStart += 1
            sunStart += 1
        ElseIf day = "Thursday" Then
            friStart += 1
            satStart += 1
            sunStart += 1
        ElseIf day = "Friday" Then
            satStart += 1
            sunStart += 1
        ElseIf day = "Saturday" Then
            sunStart += 1
        End If
    End Sub

    Private Function GetWeeklyReport(ByVal weeklyTable As System.Data.DataTable)
        'second try
        'weeklyTable is the dt given in bad format
        'weekdt is the dt we are populating
        Dim weekdt As New System.Data.DataTable
        weekdt = InitReportDT(weekdt, "week") 'change
        For Each dr As DataRow In weeklyTable.Rows
            For Each dc As DataColumn In weeklyTable.Columns
                If dc.ColumnName.ToString <> "Time" Then
                    If dr.Item(dc).ToString <> "" And dr.Item(dc).ToString <> " " Then
                        Dim time As String = dr.Item("Time").ToString
                        Dim colName As String = dc.ColumnName.ToString
                        Dim value As String = dr.Item(dc).ToString
                        Dim roomId As String = value.Substring(0, value.IndexOf(" "))
                        Dim cell As New TableLayoutPanelCellPosition(0, 0)
                        Dim placed As Boolean = False

                        cell.Row = GetReportRow(time)
                        cell.Column = weekdt.Columns(colName + roomId).Ordinal 'change

                        'While placed = False
                        'If weekdt.Rows(cell.Row).Item(cell.Column).ToString = "" Or weekdt.Rows(cell.Row).Item(cell.Column).ToString = " " Then
                        weekdt.Rows(cell.Row).Item(cell.Column) = value
                        'placed = True
                        'Else
                        'cell.Column += 1
                        'End If
                        'End While
                    End If
                End If
            Next
        Next

        'delete unused columns
        '** need to fix to not erase all of one day
        Dim j As Integer = 0

        While j < weekdt.Columns.Count
            Dim removeColumn = True
            If weekdt.Columns(j).ToString.Substring(weekdt.Columns(j).ToString.Length - 1) <> "0" Then
                For i = 0 To weekdt.Rows.Count - 1
                    If weekdt.Rows(i).Item(j).ToString <> "" And weekdt.Rows(i).Item(j).ToString <> " " Then
                        removeColumn = False
                        Exit For
                    End If
                Next
                If removeColumn Then
                    weekdt.Columns.RemoveAt(j)
                Else
                    j += 1
                End If
            Else
                j += 1
            End If
        End While

        'loop back through and fix stuff


        Return weekdt
    End Function

    Private Function GetReportRow(ByVal time As String)
        Dim cell As New TableLayoutPanelCellPosition(0, 0)

        Dim times = {"8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30"}

        For i = 0 To times.Length - 1
            If times(i) = time Then
                cell.Row = i
            End If
        Next

        Return cell.Row
    End Function

    Private Function InitReportDT(ByVal tempdt As System.Data.DataTable, ByVal s As String)
        Dim times = {"8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30"}
        Dim days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
        Dim sql As New SQLConnect
        Dim ds As DataSet = sql.GetStoredProc("GetRooms")
        Dim profds As DataSet = sql.GetStoredProc("GetProfessorName")
        'Dim roomCount As Integer = CType(ds.Tables(0).Rows(0).Item(0).ToString, Integer)

        tempdt.Columns.Add("Time")

        For i = 0 To 27
            tempdt.Rows.Add()
            tempdt.Rows(i).Item("Time") = times(i)
        Next

        If s = "week" Then
            For i = 0 To days.Length - 1
                For j = 0 To ds.Tables(0).Rows.Count - 1
                    tempdt.Columns.Add(days(i) + ds.Tables(0).Rows(j).Item("RoomID").ToString)
                Next
            Next
        ElseIf s = "daily" Then
            For i = 0 To profds.Tables(0).Rows.Count - 1
                tempdt.Columns.Add(profds.Tables(0).Rows(i).Item("Professor").ToString)
            Next
        ElseIf s = "prof" Then
            For i = 0 To days.Length - 1
                tempdt.Columns.Add(days(i))
            Next
        End If

        Return tempdt
    End Function

    Private Function GetFacultyReport(ByVal prof As String, ByVal term As String, ByVal termYear As String)
        Dim ds As New DataSet
        Dim sql As New SQLConnect

        ds = sql.GetStoredProc("ProfessorWeeklyReport '" + term + "', '" + termYear + "', '" + prof + "'")

        'loop back through to get the correct table
        Dim profdt As New System.Data.DataTable
        profdt = InitReportDT(profdt, "prof")

        For Each dr As DataRow In ds.Tables(0).Rows
            For Each dc As DataColumn In ds.Tables(0).Columns
                If dc.ColumnName.ToString <> "Time" Then
                    If dr.Item(dc).ToString <> "" And dr.Item(dc).ToString <> " " Then
                        Dim time As String = dr.Item("Time").ToString
                        Dim colName As String = dc.ColumnName.ToString
                        Dim value As String = dr.Item(dc).ToString
                        Dim cell As New TableLayoutPanelCellPosition(0, 0)

                        cell.Row = GetReportRow(time)
                        cell.Column = profdt.Columns(colName).Ordinal

                        profdt.Rows(cell.Row).Item(cell.Column) = value
                    End If
                End If
            Next
        Next

        Return profdt
    End Function

    Private Function GetDailyReports(ByVal profdt As System.Data.DataTable, ByVal day As String, ByVal term As String, ByVal termYear As String)
        Dim dt As New System.Data.DataTable
        Dim sql As New SQLConnect
        Dim query As String = ""
        Dim topSelect As String = ""
        Dim cases As String = ""
        Dim midCase As String = " THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS "
        Dim bottom As String = ""
        Dim militaryTime As String = ""
        Dim colonMilitaryTime As String = ""
        Dim i As Integer = 0

        For time = 0 To 27
            'reset strings and i
            topSelect = "SELECT Time"
            cases = ""
            bottom = ""
            i = 0

            For Each dr As DataRow In profdt.Rows
                topSelect = topSelect + ", " + dr.Item("Professor").ToString
                cases = cases + "(SELECT CASE TeacherID WHEN " + dr.Item("TeacherID").ToString
                cases = cases + midCase
                cases = cases + dr.Item("Professor").ToString

                If i < profdt.Rows.Count - 1 Then
                    cases = cases + ", "
                Else
                    cases = cases + " "
                End If
                i += 1
            Next

            topSelect = topSelect + " FROM ( SELECT "
            militaryTime = CalcMilitaryTime(time)
            If militaryTime.Length <= 3 Then
                colonMilitaryTime = militaryTime.Insert(1, ":")
            Else
                colonMilitaryTime = militaryTime.Insert(2, ":")
            End If
            bottom = "FROM SCHEDULE S WHERE " + militaryTime + " BETWEEN StartTime AND (EndTime - 1) AND Term = '" + term + "' AND TermYear = '" + termYear + "'"
            bottom = bottom + " AND " + day + " = 1" + " ) AS TMP RIGHT JOIN TIMES ON 1 = 1 WHERE TIME = '" + colonMilitaryTime + "' "

            If time < 27 Then
                bottom = bottom + "UNION "
            End If

            query = query + topSelect + cases + bottom
        Next

        topSelect = "SELECT Time"
        For Each dr As DataRow In profdt.Rows
            topSelect = topSelect + ", " + dr.Item("Professor").ToString
        Next
        topSelect = topSelect + " FROM ( "

        bottom = ") AS k ORDER BY CONVERT(int, Replace(Time, ':', ''))"
        query = topSelect + query + bottom

        'once you have the query, need to get a dt from it
        Dim ds As DataSet = sql.GetQuery(query)
        'dt = ds.Tables(0)

        'loop through the table to fix it
        Dim daydt As New System.Data.DataTable
        daydt = InitReportDT(daydt, "daily")

        For Each dr As DataRow In ds.Tables(0).Rows
            For Each dc As DataColumn In ds.Tables(0).Columns
                If dc.ColumnName.ToString <> "Time" Then
                    If dr.Item(dc).ToString <> "" And dr.Item(dc).ToString <> " " Then
                        Dim time As String = dr.Item("Time").ToString
                        Dim colName As String = dc.ColumnName.ToString
                        Dim value As String = dr.Item(dc).ToString
                        Dim cell As New TableLayoutPanelCellPosition(0, 0)

                        cell.Row = GetReportRow(time)
                        cell.Column = daydt.Columns(colName).Ordinal

                        daydt.Rows(cell.Row).Item(cell.Column) = value
                    End If
                End If
            Next
        Next

        Return daydt
    End Function

    Private Function CalcMilitaryTime(ByVal i As Integer)
        Dim militaryTime As String = ""

        Select Case i
            Case 0
                militaryTime = "800"
            Case 1
                militaryTime = "830"
            Case 2
                militaryTime = "900"
            Case 3
                militaryTime = "930"
            Case 4
                militaryTime = "1000"
            Case 5
                militaryTime = "1030"
            Case 6
                militaryTime = "1100"
            Case 7
                militaryTime = "1130"
            Case 8
                militaryTime = "1200"
            Case 9
                militaryTime = "1230"
            Case 10
                militaryTime = "1300"
            Case 11
                militaryTime = "1330"
            Case 12
                militaryTime = "1400"
            Case 13
                militaryTime = "1430"
            Case 14
                militaryTime = "1500"
            Case 15
                militaryTime = "1530"
            Case 16
                militaryTime = "1600"
            Case 17
                militaryTime = "1630"
            Case 18
                militaryTime = "1700"
            Case 19
                militaryTime = "1730"
            Case 20
                militaryTime = "1800"
            Case 21
                militaryTime = "1830"
            Case 22
                militaryTime = "1900"
            Case 23
                militaryTime = "1930"
            Case 24
                militaryTime = "2000"
            Case 25
                militaryTime = "2030"
            Case 26
                militaryTime = "2100"
            Case 27
                militaryTime = "2130"
        End Select

        Return militaryTime
    End Function

    'Function that puts all the data into excel cells
    Private Sub exportDataSetToExcelWorksheet(ByVal dt As System.Data.DataTable, ByVal excelSheet As Excel.Worksheet)

        Dim g As New Globals

        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim roomColors As Dictionary(Of String, Color) = g.GetRoomColors()
        Dim data As String
        Dim c As Color


        'Export the Columns to excel file
        For Each dc In dt.Columns
            colIndex = colIndex + 1
            excelSheet.Cells(1, colIndex) = dc.ColumnName
        Next

        'Export the rows to excel file
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                If Not IsDBNull(dr(dc.ColumnName)) Then
                    excelSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    data = dr(dc.ColumnName).ToString()
                    If roomColors.ContainsKey(data) Then
                        c = roomColors(data)
                        excelSheet.Cells(rowIndex + 1, colIndex).Interior.Color = c
                    End If
                End If
            Next
        Next

        excelSheet.Columns.AutoFit()
        'Release the objects
        ReleaseObject(excelSheet)
    End Sub

    Private Function changeMilitaryTime(ByVal mainds As DataSet)
        For Each dt As System.Data.DataTable In mainds.Tables
            For Each dr As DataRow In dt.Rows
                Dim time As String = dr.Item("Time").ToString
                Select Case time
                    Case "13:00"
                        time = "1:00"
                    Case "13:30"
                        time = "1:30"
                    Case "14:00"
                        time = "2:00"
                    Case "14:30"
                        time = "2:30"
                    Case "15:00"
                        time = "3:00"
                    Case "15:30"
                        time = "3:30"
                    Case "16:00"
                        time = "4:00"
                    Case "16:30"
                        time = "4:30"
                    Case "17:00"
                        time = "5:00"
                    Case "17:30"
                        time = "5:30"
                    Case "18:00"
                        time = "6:00"
                    Case "18:30"
                        time = "6:30"
                    Case "19:00"
                        time = "7:00"
                    Case "19:30"
                        time = "7:30"
                    Case "20:00"
                        time = "8:00"
                    Case "20:30"
                        time = "8:30"
                    Case "21:00"
                        time = "9:00"
                    Case "21:30"
                        time = "9:30"
                End Select
                dr.Item("Time") = time
            Next
        Next
        Return mainds
    End Function
End Class

'old code
'Dim count As Integer = weeklyTable.Rows.Count - 1
'Dim monCol As Integer = 1
'Dim tuesCol As Integer = 1
'Dim wedCol As Integer = 1
'Dim thursCol As Integer = 1
'Dim friCol As Integer = 1
'Dim satCol As Integer = 1
'Dim sunCol As Integer = 1
'Dim newCol As String = ""

'For i = 0 To count
'    Dim j As Integer = i + 1
'    Dim removeRow As Boolean = False
'    If i < count Then
'        If weeklyTable.Rows(i).Item("Time").ToString = weeklyTable.Rows(j).Item("Time").ToString Then
'            'Then there are at least two rows with the same time
'            'need to be combined into one row

'            Dim day As String = ""
'            Dim col As Integer = 0
'            Dim start As Integer = 0

'            For z = 0 To 6
'                Select Case z
'                    Case 0
'                        day = "Monday"
'                        col = monCol
'                        start = monStart
'                    Case 1
'                        day = "Tuesday"
'                        col = tuesCol
'                        start = tuesStart
'                    Case 2
'                        day = "Wednesday"
'                        col = wedCol
'                        start = wedStart
'                    Case 3
'                        day = "Thursday"
'                        col = thursCol
'                        start = thursStart
'                    Case 4
'                        day = "Friday"
'                        col = friCol
'                        start = friStart
'                    Case 5
'                        day = "Saturday"
'                        col = satCol
'                        start = satStart
'                    Case 6
'                        day = "Sunday"
'                        col = sunCol
'                        start = sunStart
'                End Select

'                If weeklyTable.Rows(j).Item(day).ToString <> "" And weeklyTable.Rows(j).Item(day).ToString <> " " Then
'                    removeRow = True
'                    If weeklyTable.Rows(i).Item(day).ToString <> "" And weeklyTable.Rows(i).Item(day).ToString <> " " Then
'                        'check to see if a column has already been created, if so check to see if something is there
'                        If col > 1 Then
'                            'loop through to find the next available column spot, if none found create a new column
'                            For a = 2 To col
'                                If weeklyTable.Rows(i).Item(day + a.ToString).ToString <> "" And weeklyTable.Rows(i).Item(day + a.ToString).ToString <> " " Then
'                                    If weeklyTable.Columns.Contains(day + (a + 1).ToString) Then
'                                        Continue For
'                                    Else
'                                        col += 1
'                                        newCol = day + (col).ToString
'                                        weeklyTable.Columns.Add(newCol).SetOrdinal((col - 1) + start)
'                                        weeklyTable.Rows(i).Item(newCol) = weeklyTable.Rows(j).Item(day).ToString
'                                        a = col + 1
'                                        IncColStart(day)
'                                    End If
'                                Else
'                                    weeklyTable.Rows(i).Item(day + a.ToString) = weeklyTable.Rows(j).Item(day).ToString
'                                    a = col + 1
'                                End If
'                            Next
'                        Else
'                            col += 1
'                            newCol = day + (col).ToString
'                            weeklyTable.Columns.Add(newCol).SetOrdinal((col - 1) + start)
'                            weeklyTable.Rows(i).Item(newCol) = weeklyTable.Rows(j).Item(day).ToString
'                            IncColStart(day)
'                        End If
'                    Else
'                        weeklyTable.Rows(i).Item(day) = weeklyTable.Rows(j).Item(day).ToString
'                    End If
'                End If
'                Select Case z
'                    Case 0
'                        monCol = col
'                    Case 1
'                        tuesCol = col
'                    Case 2
'                        wedCol = col
'                    Case 3
'                        thursCol = col
'                    Case 4
'                        friCol = col
'                    Case 5
'                        satCol = col
'                    Case 6
'                        sunCol = col
'                End Select
'            Next

'            If removeRow Then
'                weeklyTable.Rows.RemoveAt(j)
'                count -= 1
'            End If

'        End If
'    End If
'Next

'  'Try
'    For j = 0 To weekdt.Columns.Count - 2
'        Dim removeColumn = True
'        If weekdt.Columns(j).ToString.Substring(weekdt.Columns(j).ToString.Length - 1) <> "0" Then
'            For i = 0 To weekdt.Rows.Count - 1
'                If weekdt.Rows(i).Item(j).ToString <> "" And weekdt.Rows(i).Item(j).ToString <> " " Then
'                    removeColumn = False
'                    Exit For
'                End If
'            Next
'            If removeColumn Then
'                weekdt.Columns.RemoveAt(j)
'            End If
'        End If
'    Next
'Catch ex As Exception

'End Try

'Dim i As Integer = 0

''For i = 0 To weekdt.Rows.Count - 1
'    For k = 0 To weekdt.Columns.Count - 1
'        Try
'            If weekdt.Rows(i).Item(k).ToString <> "" And weekdt.Rows(i).Item(k).ToString <> " " And weekdt.Rows(i).Item(k).ToString = weekdt.Rows(i - 1).Item(k - 1).ToString And weekdt.Rows(i).Item(k).ToString <> weekdt.Rows(i - 1).Item(k).ToString Then
'                'shift that weird one right
'                weekdt.Rows(i - 1).Item(k) = weekdt.Rows(i - 1).Item(k - 1).ToString
'                weekdt.Rows(i - 1).Item(k - 1) = ""
'                Dim checkMore As Boolean = True
'                Dim newi As Integer = i
'                'Dim newk As Integer = k
'                While checkMore
'                    If weekdt.Rows(newi).Item(k).ToString = weekdt.Rows(newi - 1).Item(k).ToString Then
'                        newi -= 1
'                        weekdt.Rows(newi - 1).Item(k) = weekdt.Rows(newi - 1).Item(k - 1).ToString
'                        weekdt.Rows(newi - 1).Item(k - 1) = ""
'                    Else
'                        checkMore = False
'                    End If
'                End While
'            End If

'            If weekdt.Rows(i).Item(k).ToString <> "" And weekdt.Rows(i).Item(k).ToString <> " " And weekdt.Rows(i).Item(k).ToString = weekdt.Rows(i + 1).Item(k - 1).ToString And weekdt.Rows(i).Item(k).ToString <> weekdt.Rows(i + 1).Item(k).ToString Then
'                'shift that weird one right
'                weekdt.Rows(i + 1).Item(k) = weekdt.Rows(i + 1).Item(k - 1).ToString
'                weekdt.Rows(i + 1).Item(k - 1) = ""
'                Dim checkMore As Boolean = True
'                Dim newi As Integer = i
'                While checkMore
'                    If weekdt.Rows(newi).Item(k).ToString = weekdt.Rows(newi + 1).Item(k).ToString Then
'                        newi += 1
'                        weekdt.Rows(newi + 1).Item(k) = weekdt.Rows(newi + 1).Item(k - 1).ToString
'                        weekdt.Rows(newi + 1).Item(k - 1) = ""
'                    Else
'                        checkMore = False
'                    End If
'                End While
'            End If
'        Catch ex As Exception

'        End Try
'    Next
'Next

'Dim weekdt As New System.Data.DataTable
'weekdt = InitReportDT(weekdt, "week")
'For Each dr As DataRow In weeklyTable.Rows
'    For Each dc As DataColumn In weeklyTable.Columns
'        If dc.ColumnName.ToString <> "Time" Then
'            If dr.Item(dc).ToString <> "" And dr.Item(dc).ToString <> " " Then
'                Dim time As String = dr.Item("Time").ToString
'                Dim colName As String = dc.ColumnName.ToString
'                Dim value As String = dr.Item(dc).ToString
'                Dim cell As New TableLayoutPanelCellPosition(0, 0)
'                Dim isAnotherCol As Boolean = True
'                Dim placed As Boolean = False

'                cell.Row = GetReportRow(time)
'                cell.Column = weekdt.Columns(colName).Ordinal

'                While isAnotherCol
'                    Try
'                        If weekdt.Rows(cell.Row).Item(cell.Column).ToString = "" Or weekdt.Rows(cell.Row).Item(cell.Column).ToString = " " Then
'                            weekdt.Rows(cell.Row).Item(cell.Column) = value
'                            placed = True
'                            isAnotherCol = False
'                        Else
'                            Dim a As String = weekdt.Columns(cell.Column).ColumnName.ToString
'                            Dim b As String = weekdt.Columns(cell.Column + 1).ColumnName.ToString
'                            b = b.Substring(0, a.Length)

'                            If a <> b Then
'                                isAnotherCol = False
'                            End If
'                            cell.Column += 1
'                        End If
'                    Catch ex As Exception
'                        'last column
'                        isAnotherCol = False
'                        cell.Column += 1
'                    End Try
'                End While

'                If placed = False Then
'                    'create new column
'                    'find the place of the column
'                    Try
'                        Dim newcolname As String = weekdt.Columns(cell.Column - 1).ColumnName.ToString
'                        Dim num As Integer = 0
'                        Try
'                            num = CType(newcolname.Substring(newcolname.Length - 1), Integer)
'                            num += 1
'                            newcolname = newcolname.Substring(0, newcolname.Length - 1)
'                        Catch ex As Exception

'                        End Try
'                        'newcolname = newcolname.Substring(0, newcolname.Length - 1)
'                        weekdt.Columns.Add(newcolname + num.ToString).SetOrdinal(cell.Column)
'                        weekdt.Rows(cell.Row).Item(cell.Column + 1) = value
'                    Catch ex As Exception
'                        dgvTest.DataSource = weekdt
'                        Exit For
'                        Exit For
'                    End Try
'                End If
'            End If
'        End If
'    Next
'Next