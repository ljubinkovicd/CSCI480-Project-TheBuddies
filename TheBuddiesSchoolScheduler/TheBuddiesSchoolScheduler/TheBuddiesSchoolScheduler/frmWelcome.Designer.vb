﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcome))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStartSchedule = New System.Windows.Forms.Button()
        Me.btnDatabaseMaintenance = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 43)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome!"
        '
        'btnStartSchedule
        '
        Me.btnStartSchedule.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnStartSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartSchedule.Location = New System.Drawing.Point(138, 96)
        Me.btnStartSchedule.Name = "btnStartSchedule"
        Me.btnStartSchedule.Size = New System.Drawing.Size(294, 58)
        Me.btnStartSchedule.TabIndex = 0
        Me.btnStartSchedule.Text = "Start Schedule"
        Me.btnStartSchedule.UseVisualStyleBackColor = False
        '
        'btnDatabaseMaintenance
        '
        Me.btnDatabaseMaintenance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnDatabaseMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDatabaseMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatabaseMaintenance.Location = New System.Drawing.Point(138, 170)
        Me.btnDatabaseMaintenance.Name = "btnDatabaseMaintenance"
        Me.btnDatabaseMaintenance.Size = New System.Drawing.Size(294, 58)
        Me.btnDatabaseMaintenance.TabIndex = 1
        Me.btnDatabaseMaintenance.Text = "Database Maintenance"
        Me.btnDatabaseMaintenance.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Location = New System.Drawing.Point(138, 249)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(294, 58)
        Me.btnReports.TabIndex = 2
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.Location = New System.Drawing.Point(138, 330)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(294, 58)
        Me.btnLogOut.TabIndex = 3
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'frmWelcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(571, 427)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnDatabaseMaintenance)
        Me.Controls.Add(Me.btnStartSchedule)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmWelcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies School Scheduler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStartSchedule As System.Windows.Forms.Button
    Friend WithEvents btnDatabaseMaintenance As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnLogOut As System.Windows.Forms.Button

End Class
