Public Class frmReports



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmWelcome.Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Visible = False
        frmWelcome.Visible = True
    End Sub
End Class