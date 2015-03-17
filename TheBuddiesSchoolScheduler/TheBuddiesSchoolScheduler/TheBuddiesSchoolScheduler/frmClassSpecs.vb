Public Class frmClassSpecs

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
        frmScheduleBuilder.Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lbl As String = lblClass.Text
        Dim department As String = lbl.Substring(0, lbl.IndexOf(" "))
        Dim courseNum As String = lbl.Substring(lbl.IndexOf(" ") + 1)
        Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
        courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
        Dim startTime As Integer = 0
        Dim endTime As Integer = 0
        If txtStartTime.Text = "" Then
            startTime = 0
        Else
            startTime = txtStartTime.Text
        End If
        If txtEndTime.Text = "" Then
            endTime = 0
        Else
            endTime = txtEndTime.Text
        End If

        Dim mon As Integer = 0
        Dim tues As Integer = 0
        Dim wed As Integer = 0
        Dim thurs As Integer = 0
        Dim fri As Integer = 0
        Dim sat As Integer = 0
        Dim sun As Integer = 0
        If chkMonday.Checked Then
            mon = 1
        End If
        If chkTuesday.Checked Then
            tues = 1
        End If
        If chkWednesday.Checked Then
            wed = 1
        End If
        If chkThursday.Checked Then
            thurs = 1
        End If
        If chkFriday.Checked Then
            fri = 1
        End If
        If chkSaturday.Checked Then
            sat = 1
        End If
        If chkSunday.Checked Then
            sun = 1
        End If

        Dim teacherID As String = cboProfessor.SelectedValue.ToString
        Dim roomID As String = txtRoom.Text
        Dim s As String = "InsertToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + mon.ToString + "', '" + tues.ToString + "', '" + wed.ToString + "', '" + thurs.ToString + "', '" + fri.ToString + "', '" + sat.ToString + "', '" + sun.ToString + "', '" + teacherID + "', '" + roomID + "'"

        Dim sql As New SQLConnect
        Dim ds As New DataSet

        ds = sql.GetStoredProc(s)

        'change the text of the label on the schedule builder screen
        Dim label As Label = CType(frmScheduleBuilder.ClassesPanel.Controls("lbl" + lbl), Label)

        '"CSCI 027.1" & vbCrLf & "Helen Schneider" & vbCrLf & "3.00 hours"
        'Need to figure out how to get the credit hours
        label.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + "3 hours"

        Me.Close()
        frmScheduleBuilder.Visible = True
    End Sub

    Private Sub frmClassSpecs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim lbl As String = ""
        lbl = g.GetLabel(lbl)
        lblClass.Text = lbl

        Dim department As String = lbl.Substring(0, lbl.IndexOf(" "))
        Dim courseNum As String = lbl.Substring(lbl.IndexOf(" ") + 1)
        Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
        courseNum = courseNum.Substring(0, courseNum.IndexOf("."))
        Dim sql As New SQLConnect
        Dim ds As New DataSet
        ds = sql.GetStoredProc("GetEditInfo '" + department + "', '" + courseNum + "', '" + sectionNum + "'")

        Dim cbods As New DataSet
        cbods = sql.GetStoredProc("GetProfessorName")

        cboProfessor.DisplayMember = cbods.Tables(0).Columns(1).ToString
        cboProfessor.ValueMember = cbods.Tables(0).Columns(0).ToString
        cboProfessor.DataSource = cbods.Tables(0)
        If ds.Tables(0).Rows(0).Item("Professor").ToString <> "" Then
            Dim index As Integer = 0

            For i As Integer = 0 To cbods.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(0).Item("Professor").ToString = cbods.Tables(0).Rows(i).Item("Professor").ToString Then
                    index = i
                    i = cbods.Tables(0).Rows.Count
                End If
            Next
            cboProfessor.SelectedIndex = index
        End If

        lblClassName.Text = ds.Tables(0).Rows(0).Item("CourseName").ToString

        txtStartTime.Text = ds.Tables(0).Rows(0).Item(2).ToString
        txtEndTime.Text = ds.Tables(0).Rows(0).Item("EndTime").ToString
        'need to change to get room name not id
        txtRoom.Text = ds.Tables(0).Rows(0).Item("RoomID").ToString
        If ds.Tables(0).Rows(0).Item("Mon").ToString = "1" Then
            chkMonday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Tues").ToString = "1" Then
            chkTuesday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Wed").ToString = "1" Then
            chkWednesday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Thurs").ToString = "1" Then
            chkThursday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Fri").ToString = "1" Then
            chkFriday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Sat").ToString = "1" Then
            chkSaturday.Checked = True
        End If
        If ds.Tables(0).Rows(0).Item("Sun").ToString = "1" Then
            chkSunday.Checked = True
        End If


    End Sub
End Class