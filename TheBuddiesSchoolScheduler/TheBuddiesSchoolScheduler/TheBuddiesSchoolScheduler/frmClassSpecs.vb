Public Class frmClassSpecs
    Dim changeDT As New DataTable   'datatable for the changes made

    Dim times As New List(Of String) 'list of the times as strings for the conversion from military to normal

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'get all of the input from the form and determine if something has been changed, if so add it to the database
        Try
            Dim startTimeIndex As Integer = cboStartTime.SelectedIndex
            Dim endTimeIndex As Integer = cboEndTime.SelectedIndex

            'check to make sure start time is less than end time
            If startTimeIndex <= endTimeIndex Then

                Dim lbl As String = lblClass.Text
                Dim department As String = lbl.Substring(0, lbl.IndexOf(" "))
                Dim courseNum As String = lbl.Substring(lbl.IndexOf(" ") + 1)
                Dim sectionNum As String = courseNum.Substring(courseNum.IndexOf(".") + 1)
                courseNum = courseNum.Substring(0, courseNum.IndexOf("."))


                Dim mon As Integer = 0
                Dim tues As Integer = 0
                Dim wed As Integer = 0
                Dim thurs As Integer = 0
                Dim fri As Integer = 0
                Dim sat As Integer = 0
                Dim sun As Integer = 0
                Dim somethingChecked As Boolean = False
                If chkMonday.Checked Then
                    mon = 1
                    somethingChecked = True
                End If
                If chkTuesday.Checked Then
                    tues = 1
                    somethingChecked = True
                End If
                If chkWednesday.Checked Then
                    wed = 1
                    somethingChecked = True
                End If
                If chkThursday.Checked Then
                    thurs = 1
                    somethingChecked = True
                End If
                If chkFriday.Checked Then
                    fri = 1
                    somethingChecked = True
                End If
                If chkSaturday.Checked Then
                    sat = 1
                    somethingChecked = True
                End If
                If chkSunday.Checked Then
                    sun = 1
                    somethingChecked = True
                End If

                If somethingChecked = False Or (startTimeIndex <> 0 And endTimeIndex <> 0) Then

                    Dim teacherID As String = cboProfessor.SelectedValue.ToString
                    Dim roomID As String = cboRoom.SelectedValue.ToString
                    Dim g As New Globals
                    Dim str As String = ""
                    str = g.GetSemester(str)
                    Dim term As String = str.Substring(0, str.IndexOf(" "))
                    Dim termYear As String = str.Substring(str.IndexOf(" ") + 1)

                    Dim startTime As String = GetStartTimeString(startTimeIndex)
                    Dim endTime As String = GetEndTimeString(endTimeIndex)

                    Dim s As String = "InsertToSchedule '" + department + "', '" + courseNum + "', '" + sectionNum + "', '" + startTime + "', '" + endTime + "', '" + mon.ToString + "', '" + tues.ToString + "', '" + wed.ToString + "', '" + thurs.ToString + "', '" + fri.ToString + "', '" + sat.ToString + "', '" + sun.ToString + "', '" + teacherID + "', '" + roomID + "', '" + term + "', '" + termYear + "'"

                    Dim sql As New SQLConnect
                    Dim ds As New DataSet

                    ds = sql.GetStoredProc(s)

                    'change the text of the label on the schedule builder screen
                    Dim label As Label = CType(frmScheduleBuilder.ClassesPanel.Controls("lbl" + lbl), Label)
                    Dim label2 As Label = CType(frmScheduleBuilder.TableLayoutPanel1.Controls("lbl" + lbl), Label)

                    Dim roomds As DataSet = sql.GetStoredProc("GetRooms")
                    Dim newColor As Int32
                    Dim textColor As String = ""
                    For Each dr As DataRow In roomds.Tables(0).Rows
                        If cboRoom.SelectedValue.ToString = dr.Item("RoomID").ToString Then
                            newColor = Convert.ToInt32(Trim(dr.Item("RoomColor").ToString))
                            textColor = dr.Item("TextColor").ToString
                        End If
                    Next

                    ds = sql.GetStoredProc("GetCreditHours '" + department + "', '" + courseNum + "'")

                    Try
                        If label IsNot Nothing Then
                            label.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + ds.Tables(0).Rows(0).Item(0).ToString + " hours"
                            label.BackColor = Color.FromArgb(newColor)
                            If textColor = "W" Then
                                label.ForeColor = Color.White
                            Else
                                label.ForeColor = Color.Black
                            End If
                        ElseIf label2 IsNot Nothing Then
                            label2.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + ds.Tables(0).Rows(0).Item(0).ToString + " hours"
                            label2.BackColor = Color.FromArgb(newColor)
                            If textColor = "W" Then
                                label2.ForeColor = Color.White
                            Else
                                label2.ForeColor = Color.Black
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Unable to get the TeacherCreditHours")
                    End Try

                    'prepare the changeDT datatable for the next screen
                    initChangeDT()
                    Dim newdays As String = getDays()

                    If startTime = " " Then
                        changeDT.Rows(0).Item("StartTime") = 0
                    Else
                        changeDT.Rows(0).Item("StartTime") = startTime
                    End If

                    If endTime = " " Then
                        changeDT.Rows(0).Item("EndTime") = 0
                    Else
                        changeDT.Rows(0).Item("EndTime") = endTime
                    End If

                    changeDT.Rows(0).Item("Days") = newdays

                    Dim dt As New DataTable
                    g.SetDT(changeDT)
                    changeDT = New DataTable

                    Me.Close()
                Else
                    MsgBox("Start/End Time cannot be empty when choosing a day")
                End If
            Else
                MsgBox("Start Time cannot be greater than End Time")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmClassSpecs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As New Globals
        Dim lbl As String = ""
        lbl = g.GetLabel(lbl)
        lblClass.Text = lbl

        'get the info for this label
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

        'get the professor combo box
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

        'get the room combo box
        cbods = sql.GetStoredProc("GetRooms")

        cboRoom.DisplayMember = cbods.Tables(0).Columns(1).ToString
        cboRoom.ValueMember = cbods.Tables(0).Columns(0).ToString
        cboRoom.DataSource = cbods.Tables(0)
        If ds.Tables(0).Rows(0).Item("RoomID").ToString <> "" Then
            Dim index As Integer = 0

            For i As Integer = 0 To cbods.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(0).Item("RoomID").ToString = cbods.Tables(0).Rows(i).Item("RoomID").ToString Then
                    index = i
                    i = cbods.Tables(0).Rows.Count
                End If
            Next
            cboRoom.SelectedIndex = index
        End If

        'set the labels and such
        lblClassName.Text = ds.Tables(0).Rows(0).Item("CourseName").ToString

        initStartEndTime()
        Dim startTime As String = ds.Tables(0).Rows(0).Item(2).ToString
        Dim endTime As String = ds.Tables(0).Rows(0).Item("EndTime").ToString

        Dim startTimeIndex As Integer = GetStartTimeInteger(startTime)
        Dim endTimeIndex As Integer = GetEndTimeInteger(endTime)
        cboStartTime.SelectedIndex = startTimeIndex
        cboEndTime.SelectedIndex = endTimeIndex

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
        changeDT.Columns.Add("StartTime")
        changeDT.Columns.Add("EndTime")
        changeDT.Columns.Add("Days")
        changeDT.Rows.Add()
    End Sub

    Private Function getDays()
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

        Return days
    End Function

    Private Sub initStartEndTime()
        times.Add(" ")
        times.Add("800")
        times.Add("830")
        times.Add("900")
        times.Add("930")
        times.Add("1000")
        times.Add("1030")
        times.Add("1100")
        times.Add("1130")
        times.Add("1200")
        times.Add("1230")
        times.Add("1300")
        times.Add("1330")
        times.Add("1400")
        times.Add("1430")
        times.Add("1500")
        times.Add("1530")
        times.Add("1600")
        times.Add("1630")
        times.Add("1700")
        times.Add("1730")
        times.Add("1800")
        times.Add("1830")
        times.Add("1900")
        times.Add("1930")
        times.Add("2000")
        times.Add("2030")
        times.Add("2100")
        times.Add("2130")

        If cboStartTime.Items.Count <= 0 Then
            cboStartTime.Items.Add(" ")
            cboStartTime.Items.Add("8:00 AM")
            cboStartTime.Items.Add("8:30 AM")
            cboStartTime.Items.Add("9:00 AM")
            cboStartTime.Items.Add("9:30 AM")
            cboStartTime.Items.Add("10:00 AM")
            cboStartTime.Items.Add("10:30 AM")
            cboStartTime.Items.Add("11:00 AM")
            cboStartTime.Items.Add("11:30 AM")
            cboStartTime.Items.Add("12:00 PM")
            cboStartTime.Items.Add("12:30 PM")
            cboStartTime.Items.Add("1:00 PM")
            cboStartTime.Items.Add("1:30 PM")
            cboStartTime.Items.Add("2:00 PM")
            cboStartTime.Items.Add("2:30 PM")
            cboStartTime.Items.Add("3:00 PM")
            cboStartTime.Items.Add("3:30 PM")
            cboStartTime.Items.Add("4:00 PM")
            cboStartTime.Items.Add("4:30 PM")
            cboStartTime.Items.Add("5:00 PM")
            cboStartTime.Items.Add("5:30 PM")
            cboStartTime.Items.Add("6:00 PM")
            cboStartTime.Items.Add("6:30 PM")
            cboStartTime.Items.Add("7:00 PM")
            cboStartTime.Items.Add("7:30 PM")
            cboStartTime.Items.Add("8:00 PM")
            cboStartTime.Items.Add("8:30 PM")
            cboStartTime.Items.Add("9:00 PM")
            cboStartTime.Items.Add("9:30 PM")
        End If

        If cboEndTime.Items.Count <= 0 Then
            cboEndTime.Items.Add(" ")
            cboEndTime.Items.Add("8:00 AM")
            cboEndTime.Items.Add("8:30 AM")
            cboEndTime.Items.Add("9:00 AM")
            cboEndTime.Items.Add("9:30 AM")
            cboEndTime.Items.Add("10:00 AM")
            cboEndTime.Items.Add("10:30 AM")
            cboEndTime.Items.Add("11:00 AM")
            cboEndTime.Items.Add("11:30 AM")
            cboEndTime.Items.Add("12:00 PM")
            cboEndTime.Items.Add("12:30 PM")
            cboEndTime.Items.Add("1:00 PM")
            cboEndTime.Items.Add("1:30 PM")
            cboEndTime.Items.Add("2:00 PM")
            cboEndTime.Items.Add("2:30 PM")
            cboEndTime.Items.Add("3:00 PM")
            cboEndTime.Items.Add("3:30 PM")
            cboEndTime.Items.Add("4:00 PM")
            cboEndTime.Items.Add("4:30 PM")
            cboEndTime.Items.Add("5:00 PM")
            cboEndTime.Items.Add("5:30 PM")
            cboEndTime.Items.Add("6:00 PM")
            cboEndTime.Items.Add("6:30 PM")
            cboEndTime.Items.Add("7:00 PM")
            cboEndTime.Items.Add("7:30 PM")
            cboEndTime.Items.Add("8:00 PM")
            cboEndTime.Items.Add("8:30 PM")
            cboEndTime.Items.Add("9:00 PM")
            cboEndTime.Items.Add("9:30 PM")
        End If
    End Sub

    Private Function GetEndTimeString(ByVal value As Integer)
        Dim time As String = times(value)
        Return time
    End Function

    Private Function GetStartTimeString(ByVal value As Integer)
        Dim time As String = times(value)
        Return time
    End Function

    Private Function GetStartTimeInteger(ByVal value As String)
        Dim time As Integer = 0

        For i = 0 To times.Count - 1
            If times(i) = value Then
                Return i
            End If
        Next

        Return time
    End Function

    Private Function GetEndTimeInteger(ByVal value As String)
        Dim time As Integer = 0

        For i = 0 To times.Count - 1
            If times(i) = value Then
                Return i
            End If
        Next

        Return time
    End Function
End Class