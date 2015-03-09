Class frmWelcome

    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True

        Dim Password As String
        Dim Username As String
        Dim Server As String

        If frmLogin.ShowDialog = DialogResult.OK Then
            Password = frmLogin.txtPassword.Text
            Username = frmLogin.txtUser.Text
            Server = frmLogin.cboServer.Text
        End If

    End Sub

    Private Sub btnStartSchedule_Click(sender As Object, e As EventArgs) Handles btnStartSchedule.Click
        Me.Visible = False
        Dim startSchedule1Screen As New frmStartSchedule1()

        startSchedule1Screen.Show()
    End Sub

    Private Sub btnLoadSchedule_Click(sender As Object, e As EventArgs) Handles btnLoadSchedule.Click
        Me.Visible = False
        frmReports.Visible = True
    End Sub

    Private Sub btnDatabaseMaintenance_Click(sender As Object, e As EventArgs) Handles btnDatabaseMaintenance.Click
        Me.Visible = False
        Dim databaseMaintenanceScreen As New frmDatabaseMaintenance()

        databaseMaintenanceScreen.Show()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Me.Visible = False
        frmReports.Visible = True
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.Close()
    End Sub
End Class
