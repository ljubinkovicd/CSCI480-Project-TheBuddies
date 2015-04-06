Imports TheBuddiesSchoolScheduler.Globals

Public Class frmStartSchedule2
    Dim profdt As New DataTable
    Private Sub btnBack_Click_1(sender As Object, e As EventArgs) Handles btnBack.Click
        frmStartSchedule1.Show()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Save the values in the grid to be used in the next page
        'code retrieved from: http://www.sourcehints.com/articles/how-to-convert-datagridview-data-to-datatable.html
        Dim dt As New DataTable
        Dim row As DataRow
        Dim TotalDatagridviewColumns As Integer = TeacherGridView.ColumnCount - 1
        'Add Datacolumn
        For Each c As DataGridViewColumn In TeacherGridView.Columns
            Dim idColumn As DataColumn = New DataColumn()
            idColumn.ColumnName = c.Name
            dt.Columns.Add(idColumn)
        Next

        'Now Iterate thru Datagrid and create the data row
        For Each dr As DataGridViewRow In TeacherGridView.Rows
            'Iterate thru datagrid
            row = dt.NewRow 'Create new row
            'Iterate thru Column 1 up to the total number of columns
            For cn As Integer = 0 To TotalDatagridviewColumns
                row.Item(cn) = dr.Cells(cn).Value ' This Will handle error datagridviewcell on NULL Values
            Next
            'Now add the row to Datarow Collection
            dt.Rows.Add(row)
        Next

        'remove the last row since it is blank
        dt.Rows.RemoveAt(dt.Rows.Count - 1)

        dt.Columns(1).ColumnName = "Professor"

        'pass this datatable to the next screen
        Dim g As New Globals
        g.SetDT(dt)

        For Each dr As DataRow In dt.Rows
            'update sql schedule table
            Dim name As String = dr.Item("Professor").ToString
            Dim course As String = dr.Item("Course").ToString
            Dim sql As New SQLConnect
            Dim blank As New DataSet
            Dim department As String = course.Substring(0, course.IndexOf(" "))
            Dim courseNum As String = course.Substring(course.IndexOf(" ") + 1)
            Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
            courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
            Dim teacherId As String = ""
            Dim term As String = lblSemester.Text.Substring(0, lblSemester.Text.IndexOf(" "))
            Dim termYear As String = lblSemester.Text.Substring(lblSemester.Text.IndexOf(" ") + 1)

            For Each r As DataRow In profdt.Rows
                If name = r.Item("Professor") Then
                    teacherId = r.Item("TeacherID")
                End If
            Next
            'Dim firstName As String = ""
            'Dim lastName As String = ""

            'If fullname <> "" Then
            '    firstName = fullname.Substring(0, fullname.IndexOf(" "))
            '    lastName = fullname.Substring(fullname.IndexOf(" ") + 1)
            'End If

            blank = sql.GetStoredProc("InsertProfessorToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + teacherId + "', '" + term + "', '" + termYear + "'")

        Next

        'Set the semester
        Dim semester As String = lblSemester.Text
        g.SetSemester(semester)

        frmScheduleBuilder.Show()
        Me.Close()
    End Sub

    Private Sub frmStartSchedule2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim dt As New DataTable
        dt = g.GetDT(dt)

        'determine the number of sections for each class
        '*********Check that sections is numer of sections in physical class room***********
        dt = getSections(dt)

        Dim cbb As New DataGridViewComboBoxColumn() With {.HeaderText = "Choose Professor"}
        Dim sql As New SQLConnect
        Dim ds As New DataSet
        Dim dr As DataRow
        ds = sql.GetStoredProc("GetProfessorName")
        profdt = ds.Tables(0)

        For Each dr In ds.Tables(0).Rows
            cbb.Items.Add(dr.Item("Professor").ToString)
        Next

        'The first column will be filled with the values from the last screen
        'TeacherGridView.Columns.Add("", "Class")
        TeacherGridView.DataSource = dt
        TeacherGridView.Columns("Course").HeaderText = "Course"
        TeacherGridView.Columns("Course").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        TeacherGridView.Columns.Insert(1, cbb)
        TeacherGridView.Columns(1).Width = 100

        'set the semester label
        Dim str As String = ""
        lblSemester.Text = g.GetSemester(str)
    End Sub

    Function getSections(dt As DataTable)
        Dim tempdt As New DataTable
        tempdt.Columns.Add()
        tempdt.Columns(0).ColumnName = "Course"
        Dim dr As DataRow

        For Each dr In dt.Rows
            If dr.Item("Day") > 0 Then
                'add class sections
                For i As Integer = 1 To dr.Item("Day")
                    If i < 10 Then
                        tempdt.Rows.Add(dr.Item("Course") + ".0" + i.ToString)
                    Else
                        tempdt.Rows.Add(dr.Item("Course") + "." + i.ToString)
                    End If
                Next
            End If
            If dr.Item("Night") > 0 Then
                For i As Integer = 1 To dr.Item("Night")
                    tempdt.Rows.Add(dr.Item("Course") + ".5" + i.ToString)
                Next
            End If
            If dr.Item("Online") > 0 Then
                'add online sections
                For i As Integer = 1 To dr.Item("Online")
                    tempdt.Rows.Add(dr.Item("Course") + ".N" + i.ToString)
                Next
            End If
        Next

        'tempdt.Columns(0).ColumnName = "Course Number"

        Return tempdt
    End Function

    Private Function IfNullObj(p1 As Object) As Object
        Throw New NotImplementedException
    End Function

End Class