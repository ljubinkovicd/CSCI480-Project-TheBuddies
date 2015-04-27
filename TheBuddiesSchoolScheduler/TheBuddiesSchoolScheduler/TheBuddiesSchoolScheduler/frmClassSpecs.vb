﻿Public Class frmClassSpecs
Dim changeDT As New DataTable   'datatable for the changes made

Dim changeTime As Boolean = False
Dim changeDay As Boolean = False
Dim changeDT As New DataTable

'Dim cprofessor As String = ""
Dim cstartTime As Integer = 0
Dim cendTime As Integer = 0
Dim croom As String = ""
Dim cdays As String = ""

Dim times As New List(Of String)
Dim indexes As New List(Of Integer)
Dim times As New List(Of String) 'list of the times as strings for the conversion from military to normal

Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    Me.Close()
End Sub

Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    'get all of the input from the form and determine if something has been changed, if so add it to the database
    Try
        Dim startTimeIndex As Integer = cboStartTime.SelectedIndex
        Dim endTimeIndex As Integer = cboEndTime.SelectedIndex
        'If txtStartTime.Text = "" Then
        '    startTime = 0
        'Else
        '    startTime = txtStartTime.Text
        'End If
        'If txtEndTime.Text = "" Then
        '    endTime = 0
        'Else
        '    endTime = txtEndTime.Text
        'End If

        'check to make sure start time is less than end time
        If startTimeIndex <= endTimeIndex Then

            ds = sql.GetStoredProc("GetCreditHours '" + department + "', '" + courseNum + "'")

            'Need to figure out how to get the credit hours
            Try
                If label IsNot Nothing Then
                    label.Text = lbl + vbNewLine + cboProfessor.SelectedItem(1).ToString + vbNewLine + ds.Tables(0).Rows(0).Item(0).ToString + " hours"
                    MsgBox("Unable to get the TeacherCreditHours")
                    End Try

            'prepare the changeDT datatable for the next screen
            initChangeDT()
            Dim newdays As String = getDays()


        Else
            changeDT.Rows(0).Item("EndTime") = endTime
        End If
        'If txtStartTime.Text = "" Then
        '    changeDT.Rows(0).Item("StartTime") = 0
        'Else
        '    changeDT.Rows(0).Item("StartTime") = txtStartTime.Text
        'End If
        'If txtEndTime.Text = "" Then
        '    changeDT.Rows(0).Item("EndTime") = 0
        'Else
        '    changeDT.Rows(0).Item("EndTime") = txtEndTime.Text
        'End If

        changeDT.Rows(0).Item("Days") = newdays

        Dim dt As New DataTable

        cboStartTime.SelectedIndex = startTimeIndex
        cboEndTime.SelectedIndex = endTimeIndex

        'txtStartTime.Text = ds.Tables(0).Rows(0).Item(2).ToString
        'txtEndTime.Text = ds.Tables(0).Rows(0).Item("EndTime").ToString

        Dim s As String = ds.Tables(0).Rows(0).Item("Mon").ToString
        If ds.Tables(0).Rows(0).Item("Mon").ToString = "True" Then
            chkMonday.Checked = True