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