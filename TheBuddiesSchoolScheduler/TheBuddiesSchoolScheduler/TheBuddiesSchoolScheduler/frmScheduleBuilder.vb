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
    'Dim dragToggle As Boolean = False
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

    'Private Sub Label13_Click(sender As Object, e As EventArgs)
    '    frmClassSpecs.Show()
    'End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        frmReports.Show()
        Me.Close()
    End Sub

    Private Sub frmScheduleBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        'set the semester label
        Dim str As String = ""
        lblSemester.Text = g.GetSemester(str)
        Dim term As String = lblSemester.Text.Substring(0, lblSemester.Text.IndexOf(" "))
        Dim termYear As String = lblSemester.Text.Substring(lblSemester.Text.IndexOf(" ") + 1)

        Dim sql As New SQLConnect
        Dim ds As New DataSet
        ds = sql.GetStoredProc("GetScheduleForLabels " + "'" + term + "', '" + termYear + "'")
        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim position As String = "left"
        Dim lbls(count) As Label
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim frm As frmLoading = New frmLoading
        frm.ShowDialog()
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

        getTeacherTotals()
        'dgvTeacherTotals.DataSource = daysdt
        getLegend()

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString
        Dim g As New Globals

        If lbl.Substring(0, 4) = "temp" Then
            lbl = lbl.Remove(0, 5)
            lbl = "lbl" + lbl
        End If

        g.SetLabel(lbl.Remove(0, 3))
        Dim frm = frmClassSpecs.ShowDialog()
        Dim s As String = frm.ToString
        If s = "OK" Then
            editMenuChanges(lbl)
            getTeacherTotals()
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim lbl = cmsRightClick.SourceControl.Name.ToString
        Dim label2 As Label = CType(Me.TableLayoutPanel1.Controls(lbl), Label)

        '***************eventually want to not place labels on top of each other if removing multiple **************

        If label2 IsNot Nothing Then
            Dim dayOfWeek As String = "Remove"
            Dim courseNum As String = lbl.Substring(lbl.IndexOf(" ") + 1)
            Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
            courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
            Dim term As String = lblSemester.Text.Substring(0, lblSemester.Text.IndexOf(" "))
            Dim termYear As String = lblSemester.Text.Substring(lblSemester.Text.IndexOf(" ") + 1)
            Dim sql As New SQLConnect
            Dim ds As New DataSet

            If label2.Name.Substring(0, 4) <> "temp" Then
                

                'remove the start and end times from the database
                Dim startTime As Integer = 0
                Dim endTime As Integer = 0
                Dim department As String = lbl.Substring(3, lbl.IndexOf(" ") - 3)

                ds = sql.GetStoredProc("InsertTimeDayToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + dayOfWeek + "', '" + term + "', '" + termYear + "'")

                'Remove any repeating labels if it has any
                Dim temp As String = lbl.Substring(3)
                For i = 0 To 6
                    Dim tempLabel As Label = CType(TableLayoutPanel1.Controls("temp" + i.ToString + temp), Label)
                    If tempLabel IsNot Nothing Then
                        'delete the label
                        TableLayoutPanel1.Controls.Remove(tempLabel)
                    End If
                Next

                TableLayoutPanel1.Controls.Remove(label2)
                ClassesPanel.Controls.Add(label2)
                label2.Height = lblHeight
                label2.Width = lblWidth
            Else
                'remove the repeating label from the database
                'determine which day the label was on
                Dim department As String = lbl.Substring(5, lbl.IndexOf(" ") - 5)
                Dim pos As New TableLayoutPanelCellPosition(0, 0)
                pos = TableLayoutPanel1.GetCellPosition(label2)
                Dim c As Integer = pos.Column
                For Each dr As DataRow In daysdt.Rows
                    If dr.Item("ColStart") <= c And c <= dr.Item("ColStart") + (dr.Item("NumCol") - 1) Then
                        dayOfWeek = dr.Item("DayOfWeek").ToString
                    End If
                Next

                ds = sql.GetStoredProc("RemoveRepeatingDaySchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + dayOfWeek + "', '" + term + "', '" + termYear + "'")

                TableLayoutPanel1.Controls.Remove(label2)
            End If
            getTeacherTotals()
        End If
    End Sub

    Private Sub labelDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'If dragToggle Then
            '    Dragging = True

            '    Dim lbl As Label = DirectCast(sender, Label)
            '    Dim mousePoint As Point = Cursor.Position ' mouse position in screen coordinates

            '    controlPoint = lbl.PointToClient(mousePoint) ' offset from (0, 0) in label coordinates

            '    ' This is the location of the label's (0, 0) in screen coordinates.
            '    Dim screenLoc As Point = New Point(mousePoint.X - controlPoint.X, mousePoint.Y - controlPoint.Y)

            '    lbl.Location = ClassesPanel.PointToClient(screenLoc)

            '    ' Note positions of cursor when pressed
            '    CursorX = e.X
            '    CursorY = e.Y
            'Else
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
        'End If
        'dgvTeacherTotals.DataSource = daysdt
    End Sub

    Private Sub labelUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsRightClick.Show()
            Dragging = False
        ElseIf Dragging Then
            'If dragToggle Then
            '    Dragging = False
            'Else
            Dim mouseLocation As Point = Cursor.Position ' mouse location in screen coordinates
            Dim formLocation As Point = Me.PointToClient(mouseLocation) ' form coordinates
            Dim pos As New TableLayoutPanelCellPosition(0, 0)

            pos = dropLabelPos()

            Dragging = False
            ' Used to prevent the label from getting inserted into the table if outside of the table.
            If (pos.Row < 0 Or pos.Column < 0) Then
                Return
            End If

            ' This is what the location of the label should be set to; it's in form coordinates
            Dim finalLocation As Point = New Point(formLocation.X - controlPoint.X, formLocation.Y - controlPoint.Y)

            ' Get the label and set its location
            Dim lbl As Label = DirectCast(sender, Label)
            lbl.Location = finalLocation

            ' Remove the label from the form's controls and make it a child of the table layout
            ' panel.  Also, calculate its new position in the table.
            Me.Controls.Remove(lbl)

            TableLayoutPanel1.Controls.Add(lbl)
            TableLayoutPanel1.SetCellPosition(lbl, pos)

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
            Dim term As String = lblSemester.Text.Substring(0, lblSemester.Text.IndexOf(" "))
            Dim termYear As String = lblSemester.Text.Substring(lblSemester.Text.IndexOf(" ") + 1)
            Dim sql As New SQLConnect
            Dim ds As New DataSet
            ds = sql.GetStoredProc("InsertTimeDayToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + dayOfWeek + "', '" + term + "', '" + termYear + "'")

            'pull up the edit screen when she places something
            Dim temp As String = lbl.Name.Remove(0, 3)
            Dim g As New Globals
            g.SetLabel(temp)
            frmClassSpecs.ShowDialog()
            editMenuChanges("lbl" + temp)
            getTeacherTotals()
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

        If (mousePoint.X < 0 Or mousePoint.X > w) Then
            pos.Row = -1
            pos.Column = -1
            Return pos
        End If

        If (mousePoint.Y < 0 Or mousePoint.Y > h) Then
            pos.Column = -1
            pos.Row = -1
            Return pos
        End If

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
        'If dragToggle Then
        '    dragToggle = False
        '    lbldragToggle.Text = "Off"
        'Else
        '    dragToggle = True
        '    lbldragToggle.Text = "On"
        'End If
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

        If (r < 0 Or c < 0) Then
            Return pos
        End If

        Dim cntrl As Control = TableLayoutPanel1.GetControlFromPosition(c, r)

        'if there is a control in the drop location check to see if a column needs to be added
        ' then add the column and control to the tlp
        If cntrl IsNot Nothing Then
            'Dim newcol As Boolean = True

            'push everything to the right if it is not a column that already has a duplicate class time and
            'If newcol Then
            'add new column, push everything right
            TableLayoutPanel1.ColumnCount += 1
            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
            TableLayoutPanel1.AutoSize = True

            c = pushLabelsRight(c)
            pos.Column = c

            AddColToDaysDT(c - 1)

            labelDropNewColumn = True
        End If
        'End If
        Return pos
    End Function

    Private Function pushLabelsRight(ByVal col As Integer)
        Dim newcol As Integer = col + 1
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
                    ' ** can be improved
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
            If c > TableLayoutPanel1.ColumnCount - 1 Then
                MsgBox("Not a valid number")
            Else
                MsgBox("Cannot remove column. There is not more than one for this day.")
            End If
        End If
        'dgvTeacherTotals.DataSource = daysdt
    End Sub

    Private Sub btnRemCol_Click(sender As Object, e As EventArgs) Handles btnRemCol.Click

        Dim c As Integer = 0

        Dim s = InputBox("Type in the column to remove (0 is first column)", "Remove Column", "1")
        Try
            If s <> "" Then
                c = CType(s, Integer)
                RemColFromDaysDT(c)
            End If
        Catch ex As Exception
            MsgBox("Incorrect value. Try again.")
        End Try
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
            'If changeDT.Rows(0).Item("ChangeTime").ToString = "True" Or changeDT.Rows(0).Item("ChangeDay").ToString = "True" Then
            'If changeDT.Rows(0).Item("ChangeLabel").ToString = "True" Then
            Dim startTime = CType(changeDT.Rows(0).Item("StartTime").ToString, Integer)
            Dim endTime = CType(changeDT.Rows(0).Item("EndTime").ToString, Integer)
            Dim days = changeDT.Rows(0).Item("Days").ToString
            Dim repeatingDays As String = ""

            'if there are temp labels with this class, delete them before going on
            Dim temp As String = lbl.Substring(3)
            'check to see if there are labels to delete
            For i = 0 To 6
                Dim tempLabel As Label = CType(TableLayoutPanel1.Controls("temp" + i.ToString + temp), Label)
                If tempLabel IsNot Nothing Then
                    'delete the label
                    TableLayoutPanel1.Controls.Remove(tempLabel)
                End If
            Next

            'if there are no days to add, check to see where the label is and only change if it is in the tlp
            If days.Length > 0 Then
                'set the new label position
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
                    'check to see if the control is the same as the label
                    If CType(cntrl, Label).Name <> label.Name AndAlso labelDropNewColumn <> True Then
                        TableLayoutPanel1.ColumnCount += 1
                        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
                        TableLayoutPanel1.AutoSize = True

                        col = pushLabelsRight(col)
                        pos.Column = col

                        AddColToDaysDT(col - 1)
                    End If
                End If
                TableLayoutPanel1.Controls.Add(label)
                TableLayoutPanel1.SetCellPosition(label, pos)
                TableLayoutPanel1.SetRowSpan(label, endRow - startRow + 1)
                label.Height = (tlpRow + 2) * (endRow - startRow + 1)

                'if there are repeating days, create them
                If repeatingDays <> "" Then
                    createRepeatingLabels(repeatingDays, label, startRow, endRow)
                End If

            Else
                If startTime <> 0 AndAlso endTime <> 0 Then
                    MsgBox("Select a day to move the class")
                End If
            End If
            'End If
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
            For Each dr As DataRow In daysdt.Rows
                If dayArray(i) = dr.Item("DayOfWeek") Then
                    'if there is a label already at this spot add a column
                    'if not just leave the position as the start column for the day
                    pos.Column = dr.Item("ColStart")

                    Dim cntrl As Control = TableLayoutPanel1.GetControlFromPosition(pos.Column, pos.Row)
                    Dim col As Integer = pos.Column
                    If cntrl IsNot Nothing Then
                        TableLayoutPanel1.ColumnCount += 1
                        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, tlpCol))
                        TableLayoutPanel1.AutoSize = True

                        col = pushLabelsRight(col)
                        pos.Column = col

                        AddColToDaysDT(col - 1)
                    End If
                End If
            Next

            TableLayoutPanel1.Controls.Add(tempLabel)
            TableLayoutPanel1.SetCellPosition(tempLabel, pos)
            TableLayoutPanel1.SetRowSpan(tempLabel, endRow - startRow + 1)
            tempLabel.Height = (tlpRow + 2) * (endRow - startRow + 1)
            tempLabel.BackColor = label.BackColor

        Next
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

    Private Sub getLegend()
        Dim g As New Globals

        Dim sql As New SQLConnect
        Dim ds As DataSet = sql.GetStoredProc("GetRooms")
        Dim colorCollection As Dictionary(Of String, Color) = New Dictionary(Of String, Color)
        Dim roomColor As Color
        Dim roomNumber As String

        dgvLegend.DataSource = ds.Tables(0)
        dgvLegend.Columns("RoomID").Visible = False
        dgvLegend.RowHeadersVisible = False
        dgvLegend.Columns("RoomColor").Visible = False
        dgvLegend.Columns("RoomName").SortMode = DataGridViewColumnSortMode.NotSortable

        For Each gr As DataGridViewRow In dgvLegend.Rows
            Dim c As Int32 = Convert.ToInt32(Trim(gr.DataBoundItem("RoomColor").ToString))
            roomNumber = Trim(gr.DataBoundItem("RoomID").ToString)
            roomColor = Color.FromArgb(c)
            colorCollection.Add(roomNumber, roomColor)
            gr.Cells("RoomName").Style.BackColor = roomColor
        Next

        g.SetRoomColors(colorCollection)

    End Sub

    Private Sub dgvLegend_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLegend.SelectionChanged
        dgvLegend.ClearSelection()
    End Sub

    Private Sub getTeacherTotals()
        Dim sql As New SQLConnect
        Dim termYear As Integer = lblSemester.Text.Substring(lblSemester.Text.IndexOf(" ") + 1)
        'if it is a fall semester, increment the year by one because of stored proc
        If lblSemester.Text.Substring(0, lblSemester.Text.IndexOf(" ")) = "Fall" Then
            termYear += 1
        End If

        Dim ds As DataSet = sql.GetStoredProc("GetTeacherTotals '" + termYear.ToString + "'")

        dgvTeacherTotals.DataSource = ds.Tables(0)
        dgvTeacherTotals.RowHeadersVisible = False
        dgvTeacherTotals.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTeacherTotals.Columns("Yearly").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTeacherTotals.Columns("Current").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
End Class