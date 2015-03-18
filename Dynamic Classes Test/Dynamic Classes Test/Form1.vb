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
    'Private mousePath As System.Drawing.Drawing2D.GraphicsPath
    Dim CursorX, CursorY As Integer
    Dim Dragging As Boolean = False
    Dim controlPoint As Point

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
                AddHandler .MouseDown, AddressOf labelDown
                AddHandler .MouseMove, AddressOf labelMove
                AddHandler .MouseUp, AddressOf labelUp
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

    'Public Sub New()
    '    mousePath = New System.Drawing.Drawing2D.GraphicsPath()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    'End Sub

    Private Sub labelDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        'Dim name As String = sender.name

        'Dim Lab As Label
        'Lab = CType(sender, Label)

        'Lab.DoDragDrop(Lab, DragDropEffects.Copy)

        ' Set the flag
        Dragging = True

        ' Note positions of cursor when pressed
        CursorX = e.X
        CursorY = e.Y
    End Sub

    Private Sub labelUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        ' Reset the flag
        Dragging = False
    End Sub


    Private Sub labelMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If Dragging Then
            Dim lab As Label = CType(sender, Label)
            ' Move the control according to mouse movement
            lab.Left = (lab.Left + e.X) - CursorX
            lab.Top = (lab.Top + e.Y) - CursorY
            ' Ensure moved control stays on top of anything it is dragged on to
            lab.BringToFront()
        End If
    End Sub

    'Dim ptOriginal As Point = Point.Empty

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

    'Private Function GetCellCoordinates() As TableLayoutPanelCellPosition
    '    Dim pos As New TableLayoutPanelCellPosition(0, 0)

    '    ' Get the client coordinates of the panel
    '    Dim tlpPoint As Point = TableLayoutPanel1.PointToClient(Cursor.Position)

    '    ' Determine the row based on row height of 50 pixels
    '    pos.Row = (tlpPoint.Y \ 50) Mod 2

    '    ' Determine the column
    '    pos.Column = (tlpPoint.X \ 50) Mod 2

    '    Return pos
    'End Function
End Class







































