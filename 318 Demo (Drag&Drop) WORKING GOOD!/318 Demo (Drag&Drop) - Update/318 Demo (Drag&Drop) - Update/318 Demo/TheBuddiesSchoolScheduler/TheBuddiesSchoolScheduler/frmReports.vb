Public Class frmReports



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class