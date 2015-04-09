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
        'Dim monTable As New System.Data.DataTable
        'Dim tuesTable As New System.Data.DataTable
        'Dim wedTable As New System.Data.DataTable
        'Dim thursTable As New System.Data.DataTable
        'Dim friTable As New System.Data.DataTable
        'Dim satTable As New System.Data.DataTable
        'Dim sunTable As New System.Data.DataTable
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
                    day = "Monday"
                Case 1
                    day = "Tuesday"
                Case 2
                    day = "Wednesday"
                Case 3
                    day = "Thursday"
                Case 4
                    day = "Friday"
                Case 5
                    day = "Saturday"
                Case 6
                    day = "Sunday"
            End Select
            tempTable = GetDailyReports(tempds.Tables(0), day, term, termYear)
            dayTable = tempTable.Copy()
            dayTable.TableName = day
            mainds.Tables.Add(dayTable)
        Next

        Return mainds
    End Function

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainds As DataSet = GetScheduleDS()
        'dgvTest.DataSource = mainds
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
        Dim ds As New DataSet
        Dim sql As New SQLConnect
        Dim query As String = ""



        Return ds
    End Function
End Class