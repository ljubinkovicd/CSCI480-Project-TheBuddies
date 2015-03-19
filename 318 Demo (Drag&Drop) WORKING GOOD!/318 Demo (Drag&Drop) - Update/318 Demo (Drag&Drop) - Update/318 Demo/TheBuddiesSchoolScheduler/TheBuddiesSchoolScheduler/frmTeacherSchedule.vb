Public Class frmTeacherSchedule

   
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Show()
        frmTeacherSpecs.ShowDialog()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class