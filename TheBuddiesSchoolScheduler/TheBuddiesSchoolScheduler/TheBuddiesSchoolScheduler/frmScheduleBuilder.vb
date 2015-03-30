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
    Const tlpRowCount As Integer = 28
    Const lblHeight As Integer = 70
    Const lblWidth As Integer = 70

    Dim CursorX, CursorY As Integer
    Dim Dragging As Boolean = False
    Dim controlPoint As Point
    Dim dragToggle As Boolean = False
    Dim addedColList As New List(Of Integer)
    Dim daysdt As New DataTable
    Dim time(tlpRowCount) As Integer
    Dim labelDropNewColumn As Boolean = False 'determines whether or not to add a new column when using the edit screen

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
                .Text = dr.Item("Course").ToString + vbNewLine + dr.Item("Professor").ToString + vbNewLine + dr.Item("TeacherCredits").ToString + " hours"
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
        initializeTime()
        'dgvTeacherTotals.DataSource = daysdt

    End Sub

    'Public Sub LabelMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        cmsRightClick.Show()
    '    End If
    'End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString
        Dim g As New Globals
        g.SetLabel(lbl.Remove(0, 3))
        Dim frm = frmClassSpecs.ShowDialog()

        editMenuChanges(lbl)

        ''if either the time or day has change, need to reflect in table
        'Dim changeDT As New DataTable
        'changeDT = g.GetDT(changeDT)
        'Try
        '    If changeDT.Rows(0).Item("ChangeTime").ToString = "True" Or changeDT.Rows(0).Item("ChangeDay").ToString = "True" Then
        '        Dim startTime = CType(changeDT.Rows(0).Item("StartTime").ToString, Integer)
        '        Dim endTime = CType(changeDT.Rows(0).Item("EndTime").ToString, Integer)
        '        Dim days = changeDT.Rows(0).Item("Days").ToString

        '        'if there are no days to add, check to see where the label is and only change if it is in the tlp
        '        If days.Length > 0 Then
        '            'set the new label position
        '            'for now grabbing the first day to add it like that
        '            days = days.Substring(0, days.IndexOf(","))

        '        End If

        '        'find the col and row
        '        Dim col As Integer = 0
        '        Dim startRow As Integer = 0
        '        Dim endRow As Integer = 0

        '        'col is day
        '        For Each dr As DataRow In daysdt.Rows
        '            If days = dr.Item("DayOfWeek") Then
        '                col = dr.Item("ColStart")
        '            End If
        '        Next

        '        'rows determined by start and end times
        '        For i = 0 To time.Length - 1
        '            If startTime = time(i) Then
        '                startRow = i
        '            End If
        '            If endTime = time(i) Then
        '                endRow = i - 1
        '            End If
        '        Next

        '        'Check to make sure there is no label in this position
        '        Dim pos As New TableLayoutPanelCellPosition(0, 0)
        '        pos.Column = col
        '        pos.Row = startRow
        '        Dim cntrl As New Control
        '        Dim addCntrl As Boolean = True

        '        For i = 0 To endRow - startRow
        '            cntrl = TableLayoutPanel1.GetControlFromPosition(col, startRow + i)
        '            If cntrl IsNot Nothing Then
        '                'then we need to move the label over a column, possibly increment the column also
        '                addCntrl = False
        '            End If
        '        Next

        '        If addCntrl Then
        '            Dim label As Label = CType(TableLayoutPanel1.Controls(lbl), Label)
        '            If label Is Nothing Then
        '                label = CType(ClassesPanel.Controls(lbl), Label)
        '                ClassesPanel.Controls.Remove(label)
        '                If label Is Nothing Then
        '                    label = CType(Me.Controls(lbl), Label)
        '                    Me.Controls.Remove(label)
        '                End If
        '            End If
        '            TableLayoutPanel1.Controls.Add(label)
        '            TableLayoutPanel1.SetCellPosition(label, pos)
        '            TableLayoutPanel1.SetRowSpan(label, endRow - startRow + 1)
        '        Else
        '            'check to see if there is an available column

        '            'if there is, add it there

        '            'if not, increment the columns and add it there

        '        End If
        '        'if there are days, for now check to find the day we want so we only add one day for right now
        '        '*********update to include more days**************

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString
        Dim label2 As Label = CType(Me.TableLayoutPanel1.Controls(lbl), Label)

        '***************eventually want to not place labels on top of each other if removing multiple **************

        If label2 IsNot Nothing Then
            If label2.Name.Substring(0, 4) <> "temp" Then
                TableLayoutPanel1.Controls.Remove(label2)
                ClassesPanel.Controls.Add(label2)
                label2.Height = lblHeight
                label2.Width = lblWidth

                'remove the start and end times from the database
                Dim startTime As Integer = 0
                Dim endTime As Integer = 0
                Dim dayOfWeek As String = "Remove"
                Dim department As String = lbl.Substring(3, lbl.IndexOf(" ") - 3)
                Dim courseNum As String = lbl.Substring(lbl.IndexOf(" ") + 1)
                Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
                courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
                Dim sql As New SQLConnect
                Dim ds As New DataSet
                ds = sql.GetStoredProc("InsertTimeDayToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + dayOfWeek + "'")
            Else
                TableLayoutPanel1.Controls.Remove(label2)

            End If
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
                'CursorX = e.X
                'CursorY = e.Y
            End If
        End If
        'dgvTeacherTotals.DataSource = daysdt
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

                'TableLayoutPanel1.SetRowSpan(lbl, 2)

                ' Indicate we're no longer dragging
                Dragging = False

                'send the hours to the edit screen
                'figure out the start and end hours
                Dim col As Integer = pos.Column
                Dim row As Integer = pos.Row
                Dim startTime As Integer = calcStartTime(col, row)
                Dim endTime As Integer = calcEndTime(col, row, lbl)
                Dim dayOfWeek As String = ""
                For Each dr As DataRow In daysdt.Rows
                    If dr.Item("ColStart") <= col AndAlso col <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                        dayOfWeek = dr.Item("DayOfWeek")
                    End If
                Next
                Dim department As String = lbl.Text.Substring(0, lbl.Text.IndexOf(" "))
                Dim courseNum As String = lbl.Text.Substring(lbl.Text.IndexOf(" ") + 1)
                courseNum = courseNum.Substring(0, courseNum.IndexOf(".") + 3)
                Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
                courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
                Dim sql As New SQLConnect
                Dim ds As New DataSet
                ds = sql.GetStoredProc("InsertTimeDayToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + dayOfWeek + "'")

                'pull up the edit screen when she places something
                Dim temp As String = lbl.Name.Remove(0, 3)
                Dim g As New Globals
                g.SetLabel(temp)
                frmClassSpecs.ShowDialog()
                editMenuChanges("lbl" + temp)

            End If
        End If
        'dgvTeacherTotals.DataSource = daysdt
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
            'For i As Integer = 0 To addedColList.Count - 1
            '    If c = addedColList.Item(i) Then
            '        newcol = False
            '    End If
            'Next



            'push everything to the right if it is not a column that already has a duplicate class time and
            If newcol Then
                'add new column, push everything right
                TableLayoutPanel1.ColumnCount += 1
                TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
                TableLayoutPanel1.AutoSize = True

                c = pushLabelsRight(c)
                pos.Column = c

                AddColToDaysDT(c - 1)

                labelDropNewColumn = True

                'increment columns that are to right
                'For i As Integer = 0 To addedColList.Count - 1
                '    If c < addedColList.Item(i) Then
                '        addedColList.Item(i) = addedColList.Item(i) + 1
                '    End If
                'Next
                'addedColList.Add(c - 1)

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

    Private Sub pushLabelsLeft(ByVal col As Integer)
        Dim cntrl As New Control
        Dim pos As New TableLayoutPanelCellPosition(0, 0)

        'Push everything left
        For c As Integer = col + 1 To TableLayoutPanel1.ColumnStyles.Count - 1
            pos.Column = c - 1
            For r As Integer = 0 To TableLayoutPanel1.RowStyles.Count - 1
                cntrl = TableLayoutPanel1.GetControlFromPosition(c, r)
                If cntrl IsNot Nothing Then
                    pos.Row = r
                    TableLayoutPanel1.SetCellPosition(cntrl, pos)
                End If
            Next
        Next
    End Sub


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
    Private Sub AddColToDaysDT(ByVal c As Integer)
        'increase the label size on the column that was added
        Dim lbl As Label
        For Each dr As DataRow In daysdt.Rows
            If dr.Item("ColStart") <= c And c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                lbl.Width = lbl.Width + tlpCol
                dr.Item("NumCol") += 1
            End If
            'aligns the labels to the right up with their new row
            If c < dr.Item("ColStart") Then
                dr.Item("ColStart") += 1
                lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                lbl.Left = lbl.Left + tlpCol + 1
            End If
        Next
    End Sub

    Private Sub RemColFromDaysDT(ByVal c As Integer)
        Dim hasMoreThanOneCol As Boolean = False
        'check to see if there is only one column for this day
        For Each dr As DataRow In daysdt.Rows
            If dr.Item("ColStart") < c And c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                hasMoreThanOneCol = True
            End If
        Next

        If hasMoreThanOneCol Then
            'check to see if there are any controls in the column
            Dim cntrl As New Control
            Dim pos As New TableLayoutPanelCellPosition(0, 0)
            Dim canDelete As Boolean = True

            For i As Integer = 0 To TableLayoutPanel1.RowCount - 1
                cntrl = TableLayoutPanel1.GetControlFromPosition(c, i)
                If cntrl IsNot Nothing Then
                    canDelete = False
                    i = TableLayoutPanel1.RowCount
                End If
            Next

            If canDelete Then
                'delete the column and update the daysdt
                TableLayoutPanel1.ColumnCount -= 1
                TableLayoutPanel1.ColumnStyles.RemoveAt(c)
                ' how to set the new size
                'TableLayoutPanel1.Size.Width = TableLayoutPanel1.Size.Width - tlpCol

                'move all the labels to the right of this column left one column
                pushLabelsLeft(c)

                'decrease the label size of the row deleted
                Dim lbl As Label
                For Each dr As DataRow In daysdt.Rows
                    If dr.Item("ColStart") <= c And c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                        lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                        lbl.Width = lbl.Width - tlpCol
                        dr.Item("NumCol") -= 1
                    End If
                    'aligns the labels to the right up with their new row
                    If c < dr.Item("ColStart") Then
                        dr.Item("ColStart") -= 1
                        lbl = CType(Me.Controls("lbl" + dr.Item("DayOfWeek")), Label)
                        lbl.Left = lbl.Left - tlpCol - 1
                    End If
                Next
            Else
                'display message
                MsgBox("Cannot remove column. There is a class in this column.")
            End If
        Else
            MsgBox("Cannot remove column. There is not more than one for this day.")
        End If
        'dgvTeacherTotals.DataSource = daysdt
    End Sub

    Private Sub btnRemCol_Click(sender As Object, e As EventArgs) Handles btnRemCol.Click

        Dim c As Integer = 0


        Dim s = InputBox("Type in the column to remove", "Remove Column", "1")

        Try
            c = CType(s, Integer)
        Catch ex As Exception
            MsgBox("Incorrect value. Try again.")
        End Try

        RemColFromDaysDT(c)

    End Sub

    Private Function calcStartTime(ByVal c As Integer, ByVal r As Integer)
        Return time(r)
    End Function

    Private Function calcEndTime(ByVal c As Integer, ByVal r As Integer, ByVal lbl As Label)
        Dim endTime As Integer = 0
        Dim s As String = ""

        For Each dr As DataRow In daysdt.Rows
            If dr.Item("ColStart") <= c AndAlso c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                s = dr.Item("DayOfWeek").ToString
            End If
        Next

        If s = "Monday" Or s = "Wednesday" Or s = "Friday" Then
            endTime = time(r + 2)
            TableLayoutPanel1.SetRowSpan(lbl, 2)
        ElseIf s = "Tuesday" Or s = "Thursday" Then
            endTime = time(r + 3)
            TableLayoutPanel1.SetRowSpan(lbl, 3)
        Else
            endTime = time(r + 2)
            TableLayoutPanel1.SetRowSpan(lbl, 2)
        End If

        Return endTime
    End Function

    Private Sub editMenuChanges(ByVal lbl As String)
        'if either the time or day has change, need to reflect in table
        Dim g As New Globals
        Dim changeDT As New DataTable
        changeDT = g.GetDT(changeDT)
        Try
            If changeDT.Rows(0).Item("ChangeTime").ToString = "True" Or changeDT.Rows(0).Item("ChangeDay").ToString = "True" Then
                Dim startTime = CType(changeDT.Rows(0).Item("StartTime").ToString, Integer)
                Dim endTime = CType(changeDT.Rows(0).Item("EndTime").ToString, Integer)
                Dim days = changeDT.Rows(0).Item("Days").ToString
                Dim repeatingDays As String = ""

                'if there are no days to add, check to see where the label is and only change if it is in the tlp
                If days.Length > 0 Then
                    'set the new label position
                    'for now grabbing the first day to add it like that
                    Try
                        If days.Contains(",") Then
                            repeatingDays = days.Substring(days.IndexOf(",") + 1)
                            days = days.Substring(0, days.IndexOf(","))
                        End If
                    Catch ex As Exception

                    End Try


                    'find the col and row
                    Dim col As Integer = 0
                    Dim startRow As Integer = 0
                    Dim endRow As Integer = 0

                    'col is day
                    For Each dr As DataRow In daysdt.Rows
                        If days = dr.Item("DayOfWeek") Then
                            col = dr.Item("ColStart")
                        End If
                    Next

                    'rows determined by start and end times
                    For i = 0 To time.Length - 1
                        If startTime = time(i) Then
                            startRow = i
                        End If
                        If endTime = time(i) Then
                            endRow = i - 1
                        End If
                    Next

                    'Check to make sure there is no label in this position
                    Dim pos As New TableLayoutPanelCellPosition(0, 0)
                    pos.Column = col
                    pos.Row = startRow
                    Dim cntrl As New Control
                    Dim addCntrl As Boolean = True
                    Dim label As New Label

                    For i = 0 To endRow - startRow
                        cntrl = TableLayoutPanel1.GetControlFromPosition(col, startRow + i)
                        If cntrl IsNot Nothing Then
                            'then we need to move the label over a column, possibly increment the column also
                            addCntrl = False
                            i = endRow - startRow
                        End If
                    Next

                    label = CType(TableLayoutPanel1.Controls(lbl), Label)
                    If label Is Nothing Then
                        label = CType(ClassesPanel.Controls(lbl), Label)
                        ClassesPanel.Controls.Remove(label)
                        If label Is Nothing Then
                            label = CType(Me.Controls(lbl), Label)
                            Me.Controls.Remove(label)
                        End If
                    End If

                    If addCntrl = False Then
                        'label = CType(TableLayoutPanel1.Controls(lbl), Label)
                        'If label Is Nothing Then
                        '    label = CType(ClassesPanel.Controls(lbl), Label)
                        '    ClassesPanel.Controls.Remove(label)
                        '    If label Is Nothing Then
                        '        label = CType(Me.Controls(lbl), Label)
                        '        Me.Controls.Remove(label)
                        '    End If
                        'End If

                        'check to see if the control is the same as the label
                        If CType(cntrl, Label).Name <> label.Name AndAlso labelDropNewColumn <> True Then
                            '****check to see if there is an available column first
                            TableLayoutPanel1.ColumnCount += 1
                            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
                            TableLayoutPanel1.AutoSize = True

                            col = pushLabelsRight(col)
                            pos.Column = col

                            AddColToDaysDT(col - 1)


                            'if there is, add it there

                            'if not, increment the columns and add it there
                        End If
                    End If
                    TableLayoutPanel1.Controls.Add(label)
                    TableLayoutPanel1.SetCellPosition(label, pos)
                    TableLayoutPanel1.SetRowSpan(label, endRow - startRow + 1)
                    label.Height = (tlpRow + 2) * (endRow - startRow + 1)
                    'if there are days, for now check to find the day we want so we only add one day for right now
                    '*********update to include more days**************

                    If repeatingDays <> "" Then
                        createRepeatingLabels(repeatingDays, label, startRow, endRow)
                    End If

                Else
                    MsgBox("Select a day to move the class")
                End If
            End If
            labelDropNewColumn = False
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub createRepeatingLabels(ByVal repeatingDays As String, ByVal label As Label, ByVal startRow As Integer, ByVal endRow As Integer)
        Dim dayArray() As String = Split(repeatingDays, ",")
        Dim pos As New TableLayoutPanelCellPosition(0, 0)
        pos.Row = startRow

        Dim department As String = label.Text.Substring(0, label.Text.IndexOf(" "))
        Dim courseNum As String = label.Text.Substring(label.Text.IndexOf(" ") + 1)
        courseNum = courseNum.Substring(0, courseNum.IndexOf(".") + 3)
        Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
        courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
        Dim labeltext As String = department + " " + courseNum + "." + sectionNum

        For i = 0 To dayArray.Count - 1
            Dim tempLabel = New Label
            With tempLabel
                .Name = "temp" + i.ToString + labeltext
                .Text = labeltext
                .AutoSize = False
                .BackColor = Color.Orange
                .Width = 70
                .Height = 70
                .TextAlign = ContentAlignment.MiddleCenter
                .BorderStyle = BorderStyle.FixedSingle
                .ContextMenuStrip = cmsRightClick
            End With

            'update the position
            '****need to check if there already is a label****
            For Each dr As DataRow In daysdt.Rows
                If dayArray(i) = dr.Item("DayOfWeek") Then
                    pos.Column = dr.Item("ColStart")
                End If
            Next

            TableLayoutPanel1.Controls.Add(tempLabel)
            TableLayoutPanel1.SetCellPosition(tempLabel, pos)
            TableLayoutPanel1.SetRowSpan(tempLabel, endRow - startRow + 1)
            label.Height = (tlpRow + 2) * (endRow - startRow + 1)

        Next
    End Sub

    Private Sub calcTeachTotals()

    End Sub

    Private Sub initializeTime()
        time(0) = 800
        time(1) = 830
        time(2) = 900
        time(3) = 930
        time(4) = 1000
        time(5) = 1030
        time(6) = 1100
        time(7) = 1130
        time(8) = 1200
        time(9) = 1230
        time(10) = 1300
        time(11) = 1330
        time(12) = 1400
        time(13) = 1430
        time(14) = 1500
        time(15) = 1530
        time(16) = 1600
        time(17) = 1630
        time(18) = 1700
        time(19) = 1730
        time(20) = 1800
        time(21) = 1830
        time(22) = 1900
        time(23) = 1930
        time(24) = 2000
        time(25) = 2030
        time(26) = 2100
        time(27) = 2130
    End Sub
End Class