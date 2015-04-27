<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExportToExcel = New System.Windows.Forms.Button()
        Me.cboTermAndYear = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 43)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reports"
        '
        'ExportToExcel
        '
        Me.ExportToExcel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ExportToExcel.Location = New System.Drawing.Point(97, 154)
        Me.ExportToExcel.Name = "ExportToExcel"
        Me.ExportToExcel.Size = New System.Drawing.Size(180, 50)
        Me.ExportToExcel.TabIndex = 50
        Me.ExportToExcel.Text = "Print to Excel"
        Me.ExportToExcel.UseVisualStyleBackColor = False
        '
        'cboTermAndYear
        '
        Me.cboTermAndYear.FormattingEnabled = True
        Me.cboTermAndYear.Location = New System.Drawing.Point(78, 102)
        Me.cboTermAndYear.Name = "cboTermAndYear"
        Me.cboTermAndYear.Size = New System.Drawing.Size(220, 21)
        Me.cboTermAndYear.TabIndex = 56
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(377, 263)
        Me.Controls.Add(Me.cboTermAndYear)
        Me.Controls.Add(Me.ExportToExcel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Buddies School Scheduler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExportToExcel As System.Windows.Forms.Button
    Friend WithEvents cboTermAndYear As System.Windows.Forms.ComboBox
End Class
