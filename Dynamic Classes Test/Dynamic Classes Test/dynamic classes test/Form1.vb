Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class Form1
    Dim ArraySize As Integer = 5
    Dim MyLabel(ArraySize) As Label
    Dim MyTextBox(ArraySize) As TextBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To ArraySize
            MyLabel(i) = New Label()
            With MyLabel(i)
                .Name = "Label " + i.ToString
                .Text = "CSCI 150." + i.ToString + vbNewLine + "Gunnett" + vbNewLine + "3 hours"
                .AutoSize = False
                .BackColor = Color.Orange
                .Cursor = Cursors.Hand
                .Top = 10 + (75 * i)
                .Left = 50
                .Width = 90
                .Height = 70
                .TextAlign = ContentAlignment.MiddleRight
                .BorderStyle = BorderStyle.FixedSingle
                AddHandler .Click, AddressOf MyMessage
            End With
            Me.Controls.Add(MyLabel(i))
        Next
    End Sub

    Sub MyMessage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim name As String = sender.name
        Dim height As String = sender.Height.ToString
        Dim width As String = sender.Width.ToString
        Dim type As String = sender.GetType.ToString

        MsgBox("name: " + name + "height: " + height + "width: " + width + "type: " + type)
    End Sub

    Dim ptOriginal As Point = Point.Empty
    Private Sub Lab_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        'Dim Lab As Label
        'Lab = CType(sender, Label)
        '
        'Lab.DoDragDrop(Lab, DragDropEffects.All)

        DirectCast(sender, Control).DoDragDrop(sender, DragDropEffects.All)

    End Sub

    Private Sub TableLayoutPanel1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragEnter
        'Dim Lab As Label
        'Lab = e.Data.GetData(GetType(Label))
        '
        'TableLayoutPanel1.Controls.Add(Lab)

        If (e.Data.GetDataPresent(GetType(System.Windows.Forms.Label))) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub TableLayoutPanel1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragOver

        DirectCast(e.Data.GetData(GetType(System.Windows.Forms.Label)), Control).Location = Me.PointToClient(New Point(e.X - ptOriginal.X, e.Y - ptOriginal.Y))
        DirectCast(e.Data.GetData(GetType(System.Windows.Forms.Label)), Control).BringToFront()

    End Sub

    Private Sub TableLayoutPanel1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TableLayoutPanel1.DragDrop

        DirectCast(e.Data.GetData(GetType(System.Windows.Forms.Label)), Label).BringToFront()

    End Sub

End Class

