<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunRemux
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
        Me.rtbProgress = New System.Windows.Forms.RichTextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.clbxDirectory = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'rtbProgress
        '
        Me.rtbProgress.BackColor = System.Drawing.SystemColors.Desktop
        Me.rtbProgress.ForeColor = System.Drawing.SystemColors.Window
        Me.rtbProgress.Location = New System.Drawing.Point(226, 13)
        Me.rtbProgress.Name = "rtbProgress"
        Me.rtbProgress.Size = New System.Drawing.Size(562, 380)
        Me.rtbProgress.TabIndex = 1
        Me.rtbProgress.Text = ""
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(22, 409)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start Remux"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(104, 409)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'clbxDirectory
        '
        Me.clbxDirectory.FormattingEnabled = True
        Me.clbxDirectory.Location = New System.Drawing.Point(13, 13)
        Me.clbxDirectory.Name = "clbxDirectory"
        Me.clbxDirectory.Size = New System.Drawing.Size(207, 379)
        Me.clbxDirectory.TabIndex = 4
        '
        'RunRemux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.clbxDirectory)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.rtbProgress)
        Me.Name = "RunRemux"
        Me.Text = "RunRemux"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbProgress As RichTextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents clbxDirectory As CheckedListBox
End Class
