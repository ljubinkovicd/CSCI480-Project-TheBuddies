﻿Class frmWelcome

    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        Dim Password As String
        Dim Username As String
        Dim Server As String

        If frmLogin.ShowDialog = DialogResult.OK Then
            Password = frmLogin.txtPassword.Text
            Username = frmLogin.txtUser.Text
            Server = frmLogin.txtServer.Text
        End If

    End Sub

    Private Sub btnStartSchedule_Click(sender As Object, e As EventArgs) Handles btnStartSchedule.Click

        Dim startSchedule1Screen As New frmStartSchedule1()

        startSchedule1Screen.ShowDialog()

    End Sub

    Private Sub btnLoadSchedule_Click(sender As Object, e As EventArgs) Handles btnLoadSchedule.Click
        frmReports.ShowDialog()
    End Sub

    Private Sub btnDatabaseMaintenance_Click(sender As Object, e As EventArgs) Handles btnDatabaseMaintenance.Click
        frmDatabaseMaintenance.ShowDialog()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click

        frmReports.ShowDialog()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.Close()
    End Sub
End Class