Imports TheBuddiesSchoolScheduler.Globals

Public Class frmStartSchedule2

    Private Sub btnBack_Click_1(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Visible = False
        frmStartSchedule1.Visible = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmWelcome.Visible = True
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Save the values in the grid to be used in the next page
        Dim dt As New DataTable
        dt = TryCast(TeacherGridView.DataSource, DataTable)

        'pass this datatable to the next screen
        Dim g As New Globals
        g.SetDT(dt)

        Me.Visible = False
        frmScheduleBuilder.Visible = True
    End Sub

    Private Sub frmStartSchedule2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim dt As New DataTable
        dt = g.GetDT(dt)

        'determine the number of sections for each class
        '*********Check that sections is numer of sections in physical class room***********
        dt = getSections(dt)

        Dim cbb As New DataGridViewComboBoxColumn() With {.HeaderText = "Choose Professor"}
        'need to use a stored proc here instead of static items
        Dim sql As New SQLConnect
        Dim ds As New DataSet
        Dim dr As DataRow
        ds = sql.GetStoredProc("GetProfessorLastName")

        For Each dr In ds.Tables(0).Rows
            cbb.Items.Add(dr.Item(0).ToString)
        Next

        'The first column will be filled with the values from the last screen
        'TeacherGridView.Columns.Add("", "Class")
        TeacherGridView.DataSource = dt
        TeacherGridView.Columns(0).HeaderText = "Course"
        TeacherGridView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        TeacherGridView.Columns.Insert(1, cbb)
        TeacherGridView.Columns(1).Width = 100

        'set the semester label
        Dim str As String = ""
        lblSemester.Text = g.GetSemester(str)
    End Sub

    Function getSections(dt As DataTable)
        Dim tempdt As New DataTable
        tempdt.Columns.Add()
        Dim dr As DataRow

        For Each dr In dt.Rows
            If dr.Item(2) > 0 Then
                'add class sections
                For i As Integer = 1 To dr.Item(2)
                    If i < 10 Then
                        tempdt.Rows.Add(dr.Item(0) + ".0" + i.ToString)
                    Else
                        tempdt.Rows.Add(dr.Item(0) + "." + i.ToString)
                    End If
                Next
            End If
            If dr.Item(3) > 0 Then
                'add online sections
                For i As Integer = 1 To dr.Item(3)
                    tempdt.Rows.Add(dr.Item(0) + ".N" + i.ToString)
                Next
            End If
        Next

        'tempdt.Columns(0).ColumnName = "Course Number"

        Return tempdt
    End Function
End Class