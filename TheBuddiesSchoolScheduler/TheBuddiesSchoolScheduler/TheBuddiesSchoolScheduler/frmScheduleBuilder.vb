Public Class frmScheduleBuilder


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmWelcome.Visible = True
    End Sub

    Private Sub btnTeacher_Click(sender As Object, e As EventArgs) Handles btnTeacher.Click
        Me.Visible = False
        frmTeacherSchedule.Visible = True
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Visible = True
        frmClassSpecs.Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Visible = False
        frmReports.Visible = True
    End Sub

   
End Class