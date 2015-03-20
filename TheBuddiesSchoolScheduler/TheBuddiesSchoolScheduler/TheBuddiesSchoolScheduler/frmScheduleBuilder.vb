Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class frmScheduleBuilder

    Dim CursorX, CursorY As Integer
    Dim Dragging As Boolean = False
    Dim controlPoint As Point

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
                AddHandler .Click, AddressOf LabelMouseUp
                AddHandler .MouseDown, AddressOf labelDown
                AddHandler .MouseMove, AddressOf labelMove
                AddHandler .MouseUp, AddressOf labelUp
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

    Private Sub labelDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        Dim lbl As Label = DirectCast(sender, Label)
        Dim mousePoint As Point = Cursor.Position ' mouse position in screen coordinates

        controlPoint = lbl.PointToClient(mousePoint) ' offset from (0, 0) in label coordinates

        ' This is the location of the label's (0, 0) in screen coordinates.
        Dim screenLoc As Point = New Point(mousePoint.X - controlPoint.X, mousePoint.Y - controlPoint.Y)

        ' Remove the label from the panel and make it a child of the form; bring it to 
        'the front to make sure it's not hidden behind the panel.
        TableLayoutPanel1.Controls.Remove(lbl)
        Me.Controls.Add(lbl)
        lbl.BringToFront()

        lbl.Location = Me.PointToClient(screenLoc)
        ' Set the flag
        Dragging = True

        ' Note positions of cursor when pressed
        CursorX = e.X
        CursorY = e.Y
    End Sub

    Private Sub labelUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        If Dragging Then
            Dim mouseLocation As Point = Cursor.Position ' mouse location in screen coordinates
            Dim formLocation As Point = Me.PointToClient(mouseLocation) ' form coordinates

            ' This is what the location of the label should be set to; it's in form coordinates
            Dim finalLocation As Point = New Point(formLocation.X - controlPoint.X, formLocation.Y - controlPoint.Y)

            ' Get the label and set its location
            Dim lbl As Label = DirectCast(sender, Label)
            lbl.Location = finalLocation

            ' Remove the label from the form's controls and make it a child of the table layout
            ' panel.  Also, calculate its new position in the table.
            Me.Controls.Remove(lbl)
            TableLayoutPanel1.Controls.Add(lbl)
            TableLayoutPanel1.SetCellPosition(lbl, GetCellCoordinates())

            ' Indicate we're no longer dragging
            Dragging = False
        End If
    End Sub

    Private Sub labelMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If Dragging Then
            Dim lab As Label = CType(sender, Label)
            ' Move the control according to mouse movement
            lab.Left = (lab.Left + e.X) - CursorX
            lab.Top = (lab.Top + e.Y) - CursorY
            ' Ensure moved control stays on top of anything it is dragged on to
            lab.BringToFront()
        End If
    End Sub

    Dim ptOriginal As Point = Point.Empty

    'Private Sub TableLayoutPanel1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragEnter
    '    'Dim Lab As Label

    '    'Lab = e.Data.GetData(GetType(Label))

    '    'TableLayoutPanel1.Controls.Add(Lab)

    '    If e.Data.GetDataPresent(GetType(Label)) Then
    '        ' There is Label data. Allow copy.
    '        e.Effect = DragDropEffects.Copy

    '        ' Highlight the control.
    '        TableLayoutPanel1.BorderStyle = BorderStyle.FixedSingle
    '    Else
    '        ' There is no Label. Prohibit drop.
    '        e.Effect = DragDropEffects.None
    '    End If

    'End Sub

    'Private Sub TableLayoutPanel1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragOver
    '    DirectCast(e.Data.GetData(GetType(System.Windows.Forms.Label)), Control).Location = Me.PointToClient(New Point(e.X - ptOriginal.X, e.Y - ptOriginal.Y))
    '    DirectCast(e.Data.GetData(GetType(System.Windows.Forms.Label)), Control).BringToFront()
    'End Sub

    'Private Sub TableLayoutPanel1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragDrop
    '    Dim lbl As Label = DirectCast(e.Data.GetData(GetType(Label)), Label)
    '    TableLayoutPanel1.Text = lbl.Text
    '    TableLayoutPanel1.BackColor = lbl.BackColor
    '    TableLayoutPanel1.BorderStyle = BorderStyle.Fixed3D
    'End Sub

    Private Function GetCellCoordinates() As TableLayoutPanelCellPosition
        Dim pos As New TableLayoutPanelCellPosition(0, 0)

        Dim h As Integer = TableLayoutPanel1.Height
        Dim row = 0

        Dim w As Integer = TableLayoutPanel1.Width
        Dim column = 0

        Dim heights As Integer() = TableLayoutPanel1.GetRowHeights()
        Dim widths As Integer() = TableLayoutPanel1.GetColumnWidths()

        ' Get the client coordinates of the panel
        Dim mousePoint As Point = TableLayoutPanel1.PointToClient(Cursor.Position)

        Dim i As Integer = widths.Length - 1
        While (i >= 0 AndAlso mousePoint.X < w)
            w -= widths(i)
            i -= 1
        End While
        column = i + 1
        pos.Column = column

        i = heights.Length - 1
        While (i >= 0 AndAlso mousePoint.Y < h)
            h -= heights(i)
            i -= 1
        End While
        row = i + 1
        pos.Row = row

        Return pos

    End Function
End Class