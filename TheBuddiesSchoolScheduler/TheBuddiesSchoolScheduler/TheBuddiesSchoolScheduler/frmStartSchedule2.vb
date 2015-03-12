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
        Me.Visible = False
        frmScheduleBuilder.Visible = True
    End Sub

    Private Sub frmStartSchedule2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cbb As New DataGridViewComboBoxColumn() With {.HeaderText = "Choose"}
        'need to use a stored proc here instead of static items
        cbb.Items.Add("Gunnett")
        cbb.Items.Add("Geise")
        cbb.Items.Add("Schneider")

        'The first column will be filled with the values from the last screen
        TeacherGridView.Columns.Add("", "Class")
        TeacherGridView.Columns.Insert(1, cbb)
    End Sub
End Class