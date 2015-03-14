Public Class frmScheduleBuilder


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmWelcome.Visible = True
    End Sub

    Private Sub btnTeacher_Click(sender As Object, e As EventArgs) Handles btnTeacher.Click
        Me.Visible = False
        frmTeacherSchedule.Visible = True
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)
        Me.Visible = True
        frmClassSpecs.Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Visible = False
        frmReports.Visible = True
    End Sub

    Private Sub frmScheduleBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim dt As New DataTable
        dt = g.GetDT(dt)
        Dim count As Integer = dt.Rows.Count
        Dim dr As DataRow
        Dim position As String = "left"
        Dim lbls(count) As Label
        Dim i As Integer = 0
        Dim j As Integer = 0

        For Each dr In dt.Rows


            lbls(i) = New Label()
            With lbls(i)
                .Name = "lbl" + i.ToString
                .Text = dr.Item(0) + vbNewLine + "3 hours"
                .AutoSize = False
                .BackColor = Color.Orange
                .Cursor = Cursors.Hand
                .Top = 100 + (72 * j)
                .Width = 90
                .Height = 70
                .TextAlign = ContentAlignment.MiddleCenter
                .BorderStyle = BorderStyle.FixedSingle
                'AddHandler .Click, AddressOf MyMessage
            End With

            If position = "left" Then
                lbls(i).Left = 20
                position = "center"
            ElseIf position = "center" Then
                lbls(i).Left = 112
                position = "right"
            Else
                lbls(i).Left = 204
                j = j + 1
                position = "left"
            End If

            Me.Controls.Add(lbls(i))
            i = i + 1
        Next

    End Sub
End Class