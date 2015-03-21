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
    Const tlpCol As Integer = 70
    Const tlpRow As Integer = 20

    Dim CursorX, CursorY As Integer
    Dim Dragging As Boolean = False
    Dim controlPoint As Point
    Dim dragToggle As Boolean = False
    Dim addedColList As New List(Of Integer)
    Dim daysdt As New DataTable

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnTeacher_Click(sender As Object, e As EventArgs) Handles btnTeacher.Click
        frmTeacherSchedule.Show()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)
        frmClassSpecs.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        frmReports.Show()
        Me.Close()
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
                .Width = 70
                .Height = 70
                .TextAlign = ContentAlignment.MiddleCenter
                .BorderStyle = BorderStyle.FixedSingle
                .ContextMenuStrip = cmsRightClick
                'AddHandler .Click, AddressOf LabelMouseUp
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

        initializeDaysDt()

    End Sub

    'Public Sub LabelMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        cmsRightClick.Show()
    '    End If
    'End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString.Remove(0, 3)
        Dim g As New Globals
        g.SetLabel(lbl)
        frmClassSpecs.ShowDialog()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString
        Dim label2 As Label = CType(Me.TableLayoutPanel1.Controls(lbl), Label)

        '***************eventually want to not place labels on top of each other if removing multiple **************

        If label2 IsNot Nothing Then
            TableLayoutPanel1.Controls.Remove(label2)
            ClassesPanel.Controls.Add(label2)
        End If
    End Sub

    Private Sub labelDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If dragToggle Then
                Dragging = True

                Dim lbl As Label = DirectCast(sender, Label)
                Dim mousePoint As Point = Cursor.Position ' mouse position in screen coordinates

                controlPoint = lbl.PointToClient(mousePoint) ' offset from (0, 0) in label coordinates

                ' This is the location of the label's (0, 0) in screen coordinates.
                Dim screenLoc As Point = New Point(mousePoint.X - controlPoint.X, mousePoint.Y - controlPoint.Y)

                lbl.Location = ClassesPanel.PointToClient(screenLoc)

                ' Note positions of cursor when pressed
                CursorX = e.X
                CursorY = e.Y
            Else
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
            End If
        End If
    End Sub

    Private Sub labelUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsRightClick.Show()
        ElseIf Dragging Then
            If dragToggle Then
                Dragging = False
            Else
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

                Dim pos As New TableLayoutPanelCellPosition(0, 0)
                pos = dropLabelPos()

                TableLayoutPanel1.Controls.Add(lbl)
                TableLayoutPanel1.SetCellPosition(lbl, pos)

                TableLayoutPanel1.SetRowSpan(lbl, 2)
                '**orgininal
                'TableLayoutPanel1.Controls.Add(lbl)
                'TableLayoutPanel1.SetCellPosition(lbl, GetCellCoordinates())

                'test
                'TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
                'TableLayoutPanel1.GetControlFromPosition()

                ' Indicate we're no longer dragging
                Dragging = False

            End If
        End If
    End Sub

    Private Sub labelMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub btnToggleDrag_Click(sender As Object, e As EventArgs) Handles btnToggleDrag.Click
        If dragToggle Then
            dragToggle = False
            lbldragToggle.Text = "Off"
        Else
            dragToggle = True
            lbldragToggle.Text = "On"
        End If


    End Sub

    Private Function dropLabelPos()
        Dim pos As New TableLayoutPanelCellPosition(0, 0)
        'determine if there is anything in that cell before placing it
        'if there is, need to add a new column
        ' then push everything one column over

        Dim r As Integer
        Dim c As Integer
        pos = GetCellCoordinates()
        r = pos.Row
        c = pos.Column
        Dim cntrl As Control = TableLayoutPanel1.GetControlFromPosition(c, r)

        'if there is a control in the drop location check to see if a column needs to be added
        ' then add the column and control to the tlp
        '*********** Need to use the daysdt ******************
        If cntrl IsNot Nothing Then
            Dim newcol As Boolean = True
            'check to see if this column in in the added column list
            For i As Integer = 0 To addedColList.Count - 1
                If c = addedColList.Item(i) Then
                    newcol = False
                End If
            Next

            'push everything to the right if it is not a column that already has a duplicate class time and
            If newcol Then
                'add new column, push everything right
                TableLayoutPanel1.ColumnCount += 1
                TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
                TableLayoutPanel1.AutoSize = True

                c = pushLabelsRight(c)
                pos.Column = c

                linkDaysToSchedule(c - 1)

                'increment columns that are to right
                For i As Integer = 0 To addedColList.Count - 1
                    If c < addedColList.Item(i) Then
                        addedColList.Item(i) = addedColList.Item(i) + 1
                    End If
                Next
                addedColList.Add(c - 1)

            End If
        End If
        Return pos
    End Function

    Private Function pushLabelsRight(ByVal col As Integer)
        Dim newcol As Integer = col + 1
        'Dim c As Integer = TableLayoutPanel1.ColumnStyles.Count - 1
        'Dim r As Integer = TableLayoutPanel1.RowStyles.Count - 1
        Dim cntrl As New Control
        Dim pos As New TableLayoutPanelCellPosition(0, 0)

        'push everything right
        For c As Integer = TableLayoutPanel1.ColumnStyles.Count - 2 To col + 1 Step -1
            pos.Column = c + 1
            For r As Integer = 0 To TableLayoutPanel1.RowStyles.Count - 1
                cntrl = TableLayoutPanel1.GetControlFromPosition(c, r)
                If cntrl IsNot Nothing Then
                    pos.Row = r
                    TableLayoutPanel1.SetCellPosition(cntrl, pos)
                End If
            Next
        Next

        Return newcol
    End Function


    Private Sub initializeDaysDt()
        daysdt.Columns.Add()
        daysdt.Columns.Add()
        daysdt.Columns.Add()
        daysdt.Columns(0).ColumnName = "DayOfWeek"
        daysdt.Columns(1).ColumnName = "ColStart"
        daysdt.Columns(2).ColumnName = "NumCol"
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows.Add()
        daysdt.Rows(0).Item("DayOfWeek") = "Monday"
        daysdt.Rows(1).Item("DayOfWeek") = "Tuesday"
        daysdt.Rows(2).Item("DayOfWeek") = "Wednesday"
        daysdt.Rows(3).Item("DayOfWeek") = "Thursday"
        daysdt.Rows(4).Item("DayOfWeek") = "Friday"
        daysdt.Rows(5).Item("DayOfWeek") = "Saturday"
        daysdt.Rows(6).Item("DayOfWeek") = "Sunday"

        Dim i As Integer = 0
        For Each dr As DataRow In daysdt.Rows
            dr.Item("ColStart") = i
            dr.Item("NumCol") = 1
            i += 1
        Next
    End Sub
    Private Sub linkDaysToSchedule(ByVal c As Integer)
        'increase the label size on the column that was added
        Dim lbl As Label
        For Each dr As DataRow In daysdt.Rows
            If dr.Item("ColStart") <= c And c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                lbl.Width = lbl.Width + tlpCol
                dr.Item("NumCol") += 1
            End If
            If c < dr.Item("ColStart") Then
                dr.Item("ColStart") += 1
                lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                lbl.Left = lbl.Left + tlpCol + 1
            End If
        Next

        'updated the daysdt

    End Sub
End Class