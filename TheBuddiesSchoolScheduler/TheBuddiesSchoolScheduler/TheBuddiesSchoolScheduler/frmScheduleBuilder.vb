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
        'Dim g As New Globals
        'Dim dt As New DataTable
        'dt = g.GetDT(dt)

        Dim sql As New SQLConnect
        Dim ds As New DataSet
        ds = sql.GetStoredProc("GetScheduleForLabels")
        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim position As String = "left"
        Dim lbls(count) As Label
        Dim i As Integer = 0
        Dim j As Integer = 0

        For Each dr As DataRow In ds.Tables(0).Rows
            lbls(i) = New Label()
            With lbls(i)
                .Name = "lbl" + dr.Item("Course")
                .Text = dr.Item("Course").ToString + vbNewLine + dr.Item("Professor").ToString + vbNewLine + dr.Item("StudentCredits").ToString + " hours"
                .AutoSize = False
                .BackColor = Color.Orange
                .Cursor = Cursors.Hand
                .Top = 10 + (72 * j)
                .Width = 90
                .Height = 70
                .TextAlign = ContentAlignment.MiddleCenter
                .BorderStyle = BorderStyle.FixedSingle
                .ContextMenuStrip = cmsRightClick
                'AddHandler .Click, AddressOf LabelMouseUp
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
            ClassesPanel.Controls.Add(lbls(i))
            i = i + 1
        Next

    End Sub

    Public Sub LabelMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsRightClick.Show()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString.Remove(0, 3)
        Dim g As New Globals
        g.SetLabel(lbl)
        frmClassSpecs.ShowDialog()
    End Sub
End Class