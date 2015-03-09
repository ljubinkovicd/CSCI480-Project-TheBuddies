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
End Class