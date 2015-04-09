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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Initialize the objects before use
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign the connection string to connection object
        connection.ConnectionString = "data source=mars;" & "Initial Catalog=480-Buddies;user id=480-Buddies;password=schedule;"
        command.Connection = connection
        command.CommandType = CommandType.Text
        ' Use any select command.
        command.CommandText = "Select * from SCHEDULE"
        dataAdapter.SelectCommand = command

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
                oSheet = oBook.Worksheets(1)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\Schedule" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                'Release the objects
                ReleaseObject(oSheet)
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

        'temporary term and termyear
        Dim term As String = "Fall"
        Dim termYear As String = "2014"

        'weekly report
        tempds = sql.GetStoredProc("WeeklyReport '" + term + "', '" + termYear + "'")
        weeklyTable = tempds.Tables(0).Copy()

        weeklyTable = GetWeeklyReport(weeklyTable)
        weeklyTable.TableName = "WeeklyTable"

        mainds.Tables.Add(weeklyTable)

        'faculty reports
        tempds = sql.GetStoredProc("GetProfessorName")

        For Each dr As DataRow In tempds.Tables(0).Rows
            tempTable = GetFacultyReport(dr.Item("TeacherID").ToString, term, termYear)
            profTable = tempTable.Copy()
            profTable.TableName = dr.Item("Professor").ToString
            mainds.Tables.Add(profTable)
        Next

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

        'Dim q As Integer = mainds.Tables.Count

        Return mainds
    End Function

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainds As DataSet = GetScheduleDS()
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
        Dim count As Integer = weeklyTable.Rows.Count - 1
        Dim monCol As Integer = 1
        Dim tuesCol As Integer = 1
        Dim wedCol As Integer = 1
        Dim thursCol As Integer = 1
        Dim friCol As Integer = 1
        Dim satCol As Integer = 1
        Dim sunCol As Integer = 1
        Dim newCol As String = ""

        For i = 0 To count
            Dim j As Integer = i + 1
            Dim removeRow As Boolean = False
            If i < count Then
                If weeklyTable.Rows(i).Item("Time").ToString = weeklyTable.Rows(j).Item("Time").ToString Then
                    'Then there are at least two rows with the same time
                    'need to be combined into one row

                    Dim day As String = ""
                    Dim col As Integer = 0
                    Dim start As Integer = 0

                    For z = 0 To 6
                        Select Case z
                            Case 0
                                day = "Monday"
                                col = monCol
                                start = monStart
                            Case 1
                                day = "Tuesday"
                                col = tuesCol
                                start = tuesStart
                            Case 2
                                day = "Wednesday"
                                col = wedCol
                                start = wedStart
                            Case 3
                                day = "Thursday"
                                col = thursCol
                                start = thursStart
                            Case 4
                                day = "Friday"
                                col = friCol
                                start = friStart
                            Case 5
                                day = "Saturday"
                                col = satCol
                                start = satStart
                            Case 6
                                day = "Sunday"
                                col = sunCol
                                start = sunStart
                        End Select

                        If weeklyTable.Rows(j).Item(day).ToString <> "" And weeklyTable.Rows(j).Item(day).ToString <> " " Then
                            removeRow = True
                            If weeklyTable.Rows(i).Item(day).ToString <> "" And weeklyTable.Rows(i).Item(day).ToString <> " " Then
                                'check to see if a column has already been created, if so check to see if something is there
                                If col > 1 Then
                                    'loop through to find the next available column spot, if none found create a new column
                                    For a = 2 To col
                                        If weeklyTable.Rows(i).Item(day + a.ToString).ToString <> "" And weeklyTable.Rows(i).Item(day + a.ToString).ToString <> " " Then
                                            If weeklyTable.Columns.Contains(day + (a + 1).ToString) Then
                                                Continue For
                                            Else
                                                col += 1
                                                newCol = day + (col).ToString
                                                weeklyTable.Columns.Add(newCol).SetOrdinal((col - 1) + start)
                                                weeklyTable.Rows(i).Item(newCol) = weeklyTable.Rows(j).Item(day).ToString
                                                a = col + 1
                                                IncColStart(day)
                                            End If
                                        Else
                                            weeklyTable.Rows(i).Item(day + a.ToString) = weeklyTable.Rows(j).Item(day).ToString
                                            a = col + 1
                                        End If
                                    Next
                                Else
                                    col += 1
                                    newCol = day + (col).ToString
                                    weeklyTable.Columns.Add(newCol).SetOrdinal((col - 1) + start)
                                    weeklyTable.Rows(i).Item(newCol) = weeklyTable.Rows(j).Item(day).ToString
                                    IncColStart(day)
                                End If
                            Else
                                weeklyTable.Rows(i).Item(day) = weeklyTable.Rows(j).Item(day).ToString
                            End If
                        End If
                        Select Case z
                            Case 0
                                monCol = col
                            Case 1
                                tuesCol = col
                            Case 2
                                wedCol = col
                            Case 3
                                thursCol = col
                            Case 4
                                friCol = col
                            Case 5
                                satCol = col
                            Case 6
                                sunCol = col
                        End Select
                    Next

                    If removeRow Then
                        weeklyTable.Rows.RemoveAt(j)
                        count -= 1
                    End If

                End If
            End If
        Next

        '** loop back through to turn the military time to normal

        'dgvTest.DataSource = weeklyTable

        Return weeklyTable
    End Function

    Private Function GetFacultyReport(ByVal prof As String, ByVal term As String, ByVal termYear As String)
        Dim ds As New DataSet
        Dim sql As New SQLConnect

        ds = sql.GetStoredProc("ProfessorWeeklyReport '" + term + "', '" + termYear + "', '" + prof + "'")

        Return ds.Tables(0)
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
        dt = ds.Tables(0)

        Return dt
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
End Class