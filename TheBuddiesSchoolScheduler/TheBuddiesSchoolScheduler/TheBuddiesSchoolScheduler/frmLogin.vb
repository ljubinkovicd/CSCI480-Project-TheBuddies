Imports System.IO

Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    ' Probably should find another path, but couldn't access program files.
    Public filepath As String = "C:\Users\Public\Documents\BuddiesScheduler\saveinfo.txt"
    Public folderpath As String = "C:\Users\Public\Documents\BuddiesScheduler"

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim SQL As New SQLConnect

        SQL.Connect(txtServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text)

        If SQL.HasConnection Then
            Me.Close()
        End If

        If chkSaveInfo.Checked Then
            If (Not System.IO.Directory.Exists(folderpath)) Then
                System.IO.Directory.CreateDirectory(folderpath)
            End If

            If File.Exists(filepath) Then
                File.Delete(filepath)
            End If

            Dim objWriter As New System.IO.StreamWriter(filepath, True)
            objWriter.WriteLine(txtServer.Text)
            objWriter.WriteLine(txtDatabase.Text)
            objWriter.WriteLine(txtUser.Text)
            objWriter.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        frmWelcome.Close()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lines As String = ""


        If File.Exists(filepath) Then
            Using tr As TextReader = New StreamReader(filepath)
                txtServer.Text = Trim(tr.ReadLine())
                txtDatabase.Text = Trim(tr.ReadLine())
                txtUser.Text = Trim(tr.ReadLine())
            End Using
        End If

    End Sub
End Class
