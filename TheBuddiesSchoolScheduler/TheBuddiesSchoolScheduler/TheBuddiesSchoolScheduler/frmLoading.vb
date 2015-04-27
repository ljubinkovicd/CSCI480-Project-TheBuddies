'Title: The Buddies School Scheduler
'Authors: Djordje Ljubinkovic, Alex Moser, Chris Reaper, Baylee Smith
'Release Date: 4/27/2015
'Description: The Buddies School Scheduler is a VB.net program made for the client Dr.Geise
'in CSCI 480 under Dr. Ringenberg. This program is meant to assist Dr.Geise in her semester class
'scheduling endeavors by allowing her to more easily assess where and when certain classes need to be.
'We have aided her in providing a drag and drop interface, color-coded room visuals, a running total
'of faculty hours, and a complete database management system where Dr. Geise can completely customize
'her experience to her needs. The program also prints out to Microsoft Excel through the "Reports"
'button on the main screen, which prints out several different versions of the report, including 
'Weekly, by day, and by faculty.

Imports System.ComponentModel
' Code from
' http://stackoverflow.com/questions/403202/show-a-loading-screen-in-vb-net
Public Class frmLoading ' Inherits Form from the designer.vb file

    Private _worker As BackgroundWorker

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        _worker = New BackgroundWorker()
        AddHandler _worker.DoWork, AddressOf WorkerDoWork
        AddHandler _worker.RunWorkerCompleted, AddressOf WorkerCompleted

        _worker.RunWorkerAsync()
    End Sub

    ' This is executed on a worker thread and will not make the dialog unresponsive.  If you want
    ' to interact with the dialog (like changing a progress bar or label), you need to use the
    ' worker's ReportProgress() method (see documentation for details)
    Private Sub WorkerDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        ' Initialize encoder here
    End Sub

    ' This is executed on the UI thread after the work is complete.  It's a good place to either
    ' close the dialog or indicate that the initialization is complete.  It's safe to work with
    ' controls from this event.
    Private Sub WorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class