Public Class frmClassSpecs

    Dim changeTime As Boolean = False
    Dim changeDay As Boolean = False
    Dim changeDT As New DataTable
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
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
        Dim g As New Globals
        Dim str As String = ""
        str = g.GetSemester(str)
        Dim term As String = str.Substring(0, str.IndexOf(" "))
        Dim termYear As String = str.Substring(str.IndexOf(" ") + 1)
        Dim s As String = "InsertToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime.ToString + "', '" + endTime.ToString + "', '" + mon.ToString + "', '" + tues.ToString + "', '" + wed.ToString + "', '" + thurs.ToString + "', '" + fri.ToString + "', '" + sat.ToString + "', '" + sun.ToString + "', '" + teacherID + "', '" + roomID + "', '" + term + "', '" + termYear + "'"

        Dim sql As New SQLConnect
        Dim ds As New DataSet

        ds = sql.GetStoredProc(s)

        'change the text of the label on the schedule builder screen
        Dim label As Label = CType(frmScheduleBuilder.ClassesPanel.Controls("lbl" + lbl), Label)
        Dim label2 As Label = CType(frmScheduleBuilder.TableLayoutPanel1.Controls("lbl" + lbl), Label)

        '"CSCI 027.1" & vbCrLf & "Helen Schneider" & vbCrLf & "3.00 hours"
        'Need to figure out how to get the credit hours
        If label IsNot Nothing Then
            label.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + "3 hours"
        ElseIf label2 IsNot Nothing Then
            label2.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + "3 hours"
        End If

        If changeTime Or changeDay Then
            'updateChangeDT()
            initChangeDT()
            changeDT.Rows(0).Item("ChangeTime") = changeTime
            changeDT.Rows(0).Item("ChangeDay") = changeDay
            changeDT.Rows(0).Item("StartTime") = txtStartTime.Text
            changeDT.Rows(0).Item("EndTime") = txtEndTime.Text

            Dim days As String = ""
            If chkMonday.Checked Then
                days = "Monday"
            End If
            If chkTuesday.Checked Then
                If days.Length > 0 Then
                    days += ",Tuesday"
                Else
                    days = "Tuesday"
                End If
            End If
            If chkWednesday.Checked Then
                If days.Length > 0 Then
                    days += ",Wednesday"
                Else
                    days = "Wednesday"
                End If
            End If
            If chkThursday.Checked Then
                If days.Length > 0 Then
                    days += ",Thursday"
                Else
                    days = "Thursday"
                End If
            End If
            If chkFriday.Checked Then
                If days.Length > 0 Then
                    days += ",Friday"
                Else
                    days = "Friday"
                End If
            End If
            If chkSaturday.Checked Then
                If days.Length > 0 Then
                    days += ",Saturday"
                Else
                    days = "Saturday"
                End If
            End If
            If chkSunday.Checked Then
                If days.Length > 0 Then
                    days += ",Sunday"
                Else
                    days = "Sunday"
                End If
            End If
            changeDT.Rows(0).Item("Days") = days

            Dim dt As New DataTable
            g.SetDT(changeDT)
            changeDT = New DataTable
        End If

        Me.Close()
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
        Dim str As String = ""
        str = g.GetSemester(str)
        Dim term As String = str.Substring(0, str.IndexOf(" "))
        Dim termYear As String = str.Substring(str.IndexOf(" ") + 1)
        Dim sql As New SQLConnect
        Dim ds As New DataSet
        ds = sql.GetStoredProc("GetEditInfo '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + term + "', '" + termYear + "'")

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
        Dim s As String = ds.Tables(0).Rows(0).Item("Mon").ToString
        If ds.Tables(0).Rows(0).Item("Mon").ToString = "True" Then
            chkMonday.Checked = True
        Else
            chkMonday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Tues").ToString = "True" Then
            chkTuesday.Checked = True
        Else
            chkTuesday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Wed").ToString = "True" Then
            chkWednesday.Checked = True
        Else
            chkWednesday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Thurs").ToString = "True" Then
            chkThursday.Checked = True
        Else
            chkThursday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Fri").ToString = "True" Then
            chkFriday.Checked = True
        Else
            chkFriday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Sat").ToString = "True" Then
            chkSaturday.Checked = True
        Else
            chkSaturday.Checked = False
        End If
        If ds.Tables(0).Rows(0).Item("Sun").ToString = "True" Then
            chkSunday.Checked = True
        Else
            chkSunday.Checked = False
        End If


    End Sub

    Private Sub initChangeDT()
        changeDT.Columns.Add("ChangeTime")
        changeDT.Columns.Add("ChangeDay")
        changeDT.Columns.Add("StartTime")
        changeDT.Columns.Add("EndTime")
        changeDT.Columns.Add("Days")
        changeDT.Rows.Add()
    End Sub

    Private Sub updateChangeDT()

    End Sub

    Private Sub txtStartTime_TextChanged(sender As Object, e As EventArgs) Handles txtStartTime.TextChanged
        changeTime = True
    End Sub

    Private Sub txtEndTime_TextChanged(sender As Object, e As EventArgs) Handles txtEndTime.TextChanged
        changeTime = True
    End Sub

    Private Sub chkMonday_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkTuesday_CheckedChanged(sender As Object, e As EventArgs) Handles chkTuesday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkWednesday_CheckedChanged(sender As Object, e As EventArgs) Handles chkWednesday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkThursday_CheckedChanged(sender As Object, e As EventArgs) Handles chkThursday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkFriday_CheckedChanged(sender As Object, e As EventArgs) Handles chkFriday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkSaturday_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaturday.CheckedChanged
        changeDay = True
    End Sub

    Private Sub chkSunday_CheckedChanged(sender As Object, e As EventArgs) Handles chkSunday.CheckedChanged
        changeDay = True
    End Sub
End Class