Public Class frmTeacherSchedule

   
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Visible = True
        frmTeacherSpecs.Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Visible = False
        frmScheduleBuilder.Visible = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmScheduleBuilder.Visible = True
    End Sub
End Class