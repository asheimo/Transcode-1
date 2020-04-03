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
        Me.components = New System.ComponentModel.Container()
        Me.rtbProgress = New System.Windows.Forms.RichTextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.clbxDirectory = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbxHEVC = New System.Windows.Forms.CheckBox()
        Me.pbFolderProgress = New System.Windows.Forms.ProgressBar()
        Me.lblFolderProgress = New System.Windows.Forms.Label()
        Me.pbOverallProgress = New System.Windows.Forms.ProgressBar()
        Me.lblOverallProgress = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbProgress
        '
        Me.rtbProgress.BackColor = System.Drawing.SystemColors.Desktop
        Me.rtbProgress.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbProgress.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.rtbProgress.Location = New System.Drawing.Point(226, 13)
        Me.rtbProgress.Name = "rtbProgress"
        Me.rtbProgress.Size = New System.Drawing.Size(800, 380)
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
        Me.clbxDirectory.CheckOnClick = True
        Me.clbxDirectory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.clbxDirectory.FormattingEnabled = True
        Me.clbxDirectory.Location = New System.Drawing.Point(13, 13)
        Me.clbxDirectory.Name = "clbxDirectory"
        Me.clbxDirectory.Size = New System.Drawing.Size(207, 379)
        Me.clbxDirectory.TabIndex = 4
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 26)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'cbxHEVC
        '
        Me.cbxHEVC.AutoSize = True
        Me.cbxHEVC.Location = New System.Drawing.Point(185, 413)
        Me.cbxHEVC.Name = "cbxHEVC"
        Me.cbxHEVC.Size = New System.Drawing.Size(173, 17)
        Me.cbxHEVC.TabIndex = 5
        Me.cbxHEVC.Text = "Use HEVC For Untagged Items"
        Me.cbxHEVC.UseVisualStyleBackColor = True
        Me.cbxHEVC.Visible = False
        '
        'pbFolderProgress
        '
        Me.pbFolderProgress.Location = New System.Drawing.Point(484, 409)
        Me.pbFolderProgress.Name = "pbFolderProgress"
        Me.pbFolderProgress.Size = New System.Drawing.Size(100, 23)
        Me.pbFolderProgress.TabIndex = 6
        Me.pbFolderProgress.Visible = False
        '
        'lblFolderProgress
        '
        Me.lblFolderProgress.AutoSize = True
        Me.lblFolderProgress.Location = New System.Drawing.Point(398, 414)
        Me.lblFolderProgress.Name = "lblFolderProgress"
        Me.lblFolderProgress.Size = New System.Drawing.Size(80, 13)
        Me.lblFolderProgress.TabIndex = 7
        Me.lblFolderProgress.Text = "Folder Progress"
        Me.lblFolderProgress.Visible = False
        '
        'pbOverallProgress
        '
        Me.pbOverallProgress.Location = New System.Drawing.Point(700, 409)
        Me.pbOverallProgress.Name = "pbOverallProgress"
        Me.pbOverallProgress.Size = New System.Drawing.Size(100, 23)
        Me.pbOverallProgress.TabIndex = 8
        Me.pbOverallProgress.Visible = False
        '
        'lblOverallProgress
        '
        Me.lblOverallProgress.AutoSize = True
        Me.lblOverallProgress.Location = New System.Drawing.Point(619, 414)
        Me.lblOverallProgress.Name = "lblOverallProgress"
        Me.lblOverallProgress.Size = New System.Drawing.Size(75, 13)
        Me.lblOverallProgress.TabIndex = 9
        Me.lblOverallProgress.Text = "Total Progress"
        Me.lblOverallProgress.Visible = False
        '
        'RunRemux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 438)
        Me.Controls.Add(Me.lblOverallProgress)
        Me.Controls.Add(Me.pbOverallProgress)
        Me.Controls.Add(Me.lblFolderProgress)
        Me.Controls.Add(Me.pbFolderProgress)
        Me.Controls.Add(Me.cbxHEVC)
        Me.Controls.Add(Me.clbxDirectory)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.rtbProgress)
        Me.Name = "RunRemux"
        Me.Text = "RunRemux"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbProgress As RichTextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents clbxDirectory As CheckedListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cbxHEVC As CheckBox
    Friend WithEvents pbFolderProgress As ProgressBar
    Friend WithEvents lblFolderProgress As Label
    Friend WithEvents pbOverallProgress As ProgressBar
    Friend WithEvents lblOverallProgress As Label
End Class
