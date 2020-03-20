<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.btnInputDirectory = New System.Windows.Forms.Button()
        Me.txtInputDirectory = New System.Windows.Forms.TextBox()
        Me.lbxDirectory = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.rbRemux = New System.Windows.Forms.RadioButton()
        Me.rbCreate = New System.Windows.Forms.RadioButton()
        Me.btnMPV = New System.Windows.Forms.Button()
        Me.btnSubtitleEdit = New System.Windows.Forms.Button()
        Me.btnSaveRemux = New System.Windows.Forms.Button()
        Me.cmsTitleEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditTitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunRemuxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbxOutputDirectory = New System.Windows.Forms.TextBox()
        Me.btnOutputDirectory = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ClassMyTreeView1 = New Transcode_1.ClassMyTreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmsTitleEdit.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(489, 11)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(59, 13)
        Me.lblMode.TabIndex = 3
        Me.lblMode.Text = "User Mode"
        '
        'btnInputDirectory
        '
        Me.btnInputDirectory.Location = New System.Drawing.Point(14, 59)
        Me.btnInputDirectory.Name = "btnInputDirectory"
        Me.btnInputDirectory.Size = New System.Drawing.Size(104, 23)
        Me.btnInputDirectory.TabIndex = 5
        Me.btnInputDirectory.Text = "Input Directory"
        Me.btnInputDirectory.UseVisualStyleBackColor = True
        '
        'txtInputDirectory
        '
        Me.txtInputDirectory.Location = New System.Drawing.Point(124, 62)
        Me.txtInputDirectory.Name = "txtInputDirectory"
        Me.txtInputDirectory.ReadOnly = True
        Me.txtInputDirectory.Size = New System.Drawing.Size(257, 20)
        Me.txtInputDirectory.TabIndex = 6
        '
        'lbxDirectory
        '
        Me.lbxDirectory.FormattingEnabled = True
        Me.lbxDirectory.Location = New System.Drawing.Point(14, 88)
        Me.lbxDirectory.Name = "lbxDirectory"
        Me.lbxDirectory.Size = New System.Drawing.Size(383, 147)
        Me.lbxDirectory.TabIndex = 7
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'rbRemux
        '
        Me.rbRemux.AutoSize = True
        Me.rbRemux.Checked = True
        Me.rbRemux.Location = New System.Drawing.Point(80, 31)
        Me.rbRemux.Name = "rbRemux"
        Me.rbRemux.Size = New System.Drawing.Size(58, 17)
        Me.rbRemux.TabIndex = 8
        Me.rbRemux.TabStop = True
        Me.rbRemux.Text = "Remux"
        Me.rbRemux.UseVisualStyleBackColor = True
        '
        'rbCreate
        '
        Me.rbCreate.AutoSize = True
        Me.rbCreate.Enabled = False
        Me.rbCreate.Location = New System.Drawing.Point(145, 31)
        Me.rbCreate.Name = "rbCreate"
        Me.rbCreate.Size = New System.Drawing.Size(76, 17)
        Me.rbCreate.TabIndex = 9
        Me.rbCreate.Text = "Transcode"
        Me.rbCreate.UseVisualStyleBackColor = True
        '
        'btnMPV
        '
        Me.btnMPV.Location = New System.Drawing.Point(14, 518)
        Me.btnMPV.Name = "btnMPV"
        Me.btnMPV.Size = New System.Drawing.Size(84, 23)
        Me.btnMPV.TabIndex = 18
        Me.btnMPV.Text = "Open in MPV"
        Me.btnMPV.UseVisualStyleBackColor = True
        '
        'btnSubtitleEdit
        '
        Me.btnSubtitleEdit.Location = New System.Drawing.Point(105, 518)
        Me.btnSubtitleEdit.Name = "btnSubtitleEdit"
        Me.btnSubtitleEdit.Size = New System.Drawing.Size(109, 23)
        Me.btnSubtitleEdit.TabIndex = 19
        Me.btnSubtitleEdit.Text = "Open in Subtitleedit"
        Me.btnSubtitleEdit.UseVisualStyleBackColor = True
        '
        'btnSaveRemux
        '
        Me.btnSaveRemux.Location = New System.Drawing.Point(363, 518)
        Me.btnSaveRemux.Name = "btnSaveRemux"
        Me.btnSaveRemux.Size = New System.Drawing.Size(125, 23)
        Me.btnSaveRemux.TabIndex = 20
        Me.btnSaveRemux.Text = "Save Remux Settings"
        Me.btnSaveRemux.UseVisualStyleBackColor = True
        '
        'cmsTitleEdit
        '
        Me.cmsTitleEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditTitleToolStripMenuItem})
        Me.cmsTitleEdit.Name = "cmsTitleEdit"
        Me.cmsTitleEdit.Size = New System.Drawing.Size(132, 26)
        '
        'EditTitleToolStripMenuItem
        '
        Me.EditTitleToolStripMenuItem.Name = "EditTitleToolStripMenuItem"
        Me.EditTitleToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.EditTitleToolStripMenuItem.Text = "Set Default"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunRemuxToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RunRemuxToolStripMenuItem
        '
        Me.RunRemuxToolStripMenuItem.Name = "RunRemuxToolStripMenuItem"
        Me.RunRemuxToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RunRemuxToolStripMenuItem.Text = "Run Remux"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AboutToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'tbxOutputDirectory
        '
        Me.tbxOutputDirectory.Location = New System.Drawing.Point(511, 61)
        Me.tbxOutputDirectory.Name = "tbxOutputDirectory"
        Me.tbxOutputDirectory.ReadOnly = True
        Me.tbxOutputDirectory.Size = New System.Drawing.Size(257, 20)
        Me.tbxOutputDirectory.TabIndex = 26
        '
        'btnOutputDirectory
        '
        Me.btnOutputDirectory.Location = New System.Drawing.Point(403, 59)
        Me.btnOutputDirectory.Name = "btnOutputDirectory"
        Me.btnOutputDirectory.Size = New System.Drawing.Size(104, 23)
        Me.btnOutputDirectory.TabIndex = 25
        Me.btnOutputDirectory.Text = "Output Directory"
        Me.btnOutputDirectory.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 239)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(772, 54)
        Me.DataGridView1.TabIndex = 28
        '
        'Column1
        '
        Me.Column1.HeaderText = "Video Format"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Resolution"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.HeaderText = "fps"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Default"
        Me.Column4.Name = "Column4"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowDrop = True
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.DataGridView2.Location = New System.Drawing.Point(14, 299)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(772, 109)
        Me.DataGridView2.TabIndex = 29
        '
        'Column6
        '
        Me.Column6.HeaderText = "Audio Format"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Width"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Bit Rate (Kbps)"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Language"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Title"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Default"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Track ID"
        Me.Column12.Name = "Column12"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowDrop = True
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19})
        Me.DataGridView3.Location = New System.Drawing.Point(13, 414)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(773, 98)
        Me.DataGridView3.TabIndex = 30
        '
        'Column13
        '
        Me.Column13.HeaderText = "Subtitle Format"
        Me.Column13.Name = "Column13"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Language"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "# of Frames"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "Title"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "Default"
        Me.Column17.Name = "Column17"
        '
        'Column18
        '
        Me.Column18.HeaderText = "Forced"
        Me.Column18.Name = "Column18"
        '
        'Column19
        '
        Me.Column19.HeaderText = "Track ID"
        Me.Column19.Name = "Column19"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 31
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(220, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Open Folder in Expolrer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ClassMyTreeView1
        '
        Me.ClassMyTreeView1.Location = New System.Drawing.Point(403, 88)
        Me.ClassMyTreeView1.Name = "ClassMyTreeView1"
        Me.ClassMyTreeView1.Size = New System.Drawing.Size(383, 147)
        Me.ClassMyTreeView1.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "User Mode:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 566)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ClassMyTreeView1)
        Me.Controls.Add(Me.tbxOutputDirectory)
        Me.Controls.Add(Me.btnOutputDirectory)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnSaveRemux)
        Me.Controls.Add(Me.btnSubtitleEdit)
        Me.Controls.Add(Me.btnMPV)
        Me.Controls.Add(Me.rbCreate)
        Me.Controls.Add(Me.rbRemux)
        Me.Controls.Add(Me.lbxDirectory)
        Me.Controls.Add(Me.txtInputDirectory)
        Me.Controls.Add(Me.btnInputDirectory)
        Me.Controls.Add(Me.lblMode)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Transcode Tools"
        Me.cmsTitleEdit.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMode As Label
    Friend WithEvents btnInputDirectory As Button
    Friend WithEvents txtInputDirectory As TextBox
    Friend WithEvents lbxDirectory As ListBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents rbRemux As RadioButton
    Friend WithEvents rbCreate As RadioButton
    Friend WithEvents btnMPV As Button
    Friend WithEvents btnSubtitleEdit As Button
    Friend WithEvents btnSaveRemux As Button
    Friend WithEvents cmsTitleEdit As ContextMenuStrip
    Friend WithEvents EditTitleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents tbxOutputDirectory As TextBox
    Friend WithEvents btnOutputDirectory As Button
    Friend WithEvents ClassMyTreeView1 As ClassMyTreeView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewCheckBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewCheckBoxColumn
    Friend WithEvents Column18 As DataGridViewCheckBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents RunRemuxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
End Class
