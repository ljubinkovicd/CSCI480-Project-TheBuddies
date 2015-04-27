'Title: The Buddies School Scheduler
'Authors: Djordje Ljubinkovic, Alex Moser, Chris Reaper, Baylee Smith
'Release Date: 4/27/2015
'Description: The Buddies School Scheduler is a VB.net program made for the client Dr.Geise
'in CSCI 480 under Dr. Ringenberg. This program is meant to assist Dr.Geise in her semester class
'scheduling endeavors by allowing her to more easily assess where and when certain classes need to be.
'We have aided her in providing a drag and drop interface, color-coded room visuals, a running total
'of faculty hours, and a complete database management system where Dr. Geise can completely customize
'her experience to her needs. The program also prints out to Microsoft Excel through the "Reports"
'button on the main screen, which prints out several different versions of the report, including 
'Weekly, by day, and by faculty.

Class frmWelcome

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
        frmStartSchedule1.Show()
    End Sub

    Private Sub btnDatabaseMaintenance_Click(sender As Object, e As EventArgs) Handles btnDatabaseMaintenance.Click
        frmDatabaseMaintenance.Show()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Dim g As New Globals

        Dim sql As New SQLConnect
        Dim ds As DataSet = sql.GetStoredProc("GetRooms")
        Dim colorCollection As Dictionary(Of String, Color) = New Dictionary(Of String, Color)
        Dim roomColorCollection As Dictionary(Of String, Color) = New Dictionary(Of String, Color)
        Dim roomColor As Color
        Dim roomNumber As String
        Dim roomName As String

        'dgvLegend.DataSource = ds.Tables(0)
        'dgvLegend.Columns("RoomID").Visible = False
        'dgvLegend.RowHeadersVisible = False
        'dgvLegend.Columns("RoomColor").Visible = False
        'dgvLegend.Columns("TextColor").Visible = False
        'dgvLegend.Columns("RoomName").SortMode = DataGridViewColumnSortMode.NotSortable
        'dgvLegend.DefaultCellStyle.Font = New Font(dgvLegend.Font, FontStyle.Bold)

        'dgvLegend.AllowUserToAddRows = False
        'dgvLegend.AllowUserToDeleteRows = False
        'dgvLegend.AllowUserToResizeRows = False

        For Each gr As DataRow In ds.Tables(0).Rows
            Dim c As Int32 = Convert.ToInt32(Trim(gr("RoomColor").ToString))
            roomName = gr("RoomName").ToString
            roomNumber = Trim(gr("RoomID").ToString)
            roomColor = Color.FromArgb(c)
            colorCollection.Add(roomNumber, roomColor)
            roomColorCollection.Add(roomName, roomColor)
        Next

        g.SetRoomColors(colorCollection)
        g.SetRoomNumberColors(roomColorCollection)

        frmReports.Show()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.Close()
    End Sub
End Class
