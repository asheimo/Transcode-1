<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserPreferences
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnWhereRuby = New System.Windows.Forms.Button()
        Me.btnRuby = New System.Windows.Forms.Button()
        Me.tbxPathRuby = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnWhereMKVMerge = New System.Windows.Forms.Button()
        Me.btnMKVMerge = New System.Windows.Forms.Button()
        Me.tbxPathMKVMerge = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnWhereMKVPropEdit = New System.Windows.Forms.Button()
        Me.btnPathMKVPropEdit = New System.Windows.Forms.Button()
        Me.tbxPathMKVPropEdit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnWhereOtherTranscode = New System.Windows.Forms.Button()
        Me.btnWhereFFProbe = New System.Windows.Forms.Button()
        Me.btnWhereFFMpeg = New System.Windows.Forms.Button()
        Me.btnWhereSubtitleEdit = New System.Windows.Forms.Button()
        Me.btnWhereMPV = New System.Windows.Forms.Button()
        Me.btnPathOtherTranscode = New System.Windows.Forms.Button()
        Me.tbxPathothertranscode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPathFFProbe = New System.Windows.Forms.Button()
        Me.tbxPathffprobe = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPathFFMpeg = New System.Windows.Forms.Button()
        Me.tbxPathffmpeg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPathSubtitleEdit = New System.Windows.Forms.Button()
        Me.tbxPathSubtitleedit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPathMPV = New System.Windows.Forms.Button()
        Me.tbxPathMPV = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tbxothertranscodeoptions = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbxMKVMergeOptions = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbxRobocopyDefaults = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbxOtherTranscodeDefaults = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbxMKVMergeDefaults = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(632, 415)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(713, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(775, 396)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnWhereRuby)
        Me.TabPage1.Controls.Add(Me.btnRuby)
        Me.TabPage1.Controls.Add(Me.tbxPathRuby)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.btnWhereMKVMerge)
        Me.TabPage1.Controls.Add(Me.btnMKVMerge)
        Me.TabPage1.Controls.Add(Me.tbxPathMKVMerge)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnWhereMKVPropEdit)
        Me.TabPage1.Controls.Add(Me.btnPathMKVPropEdit)
        Me.TabPage1.Controls.Add(Me.tbxPathMKVPropEdit)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.btnWhereOtherTranscode)
        Me.TabPage1.Controls.Add(Me.btnWhereFFProbe)
        Me.TabPage1.Controls.Add(Me.btnWhereFFMpeg)
        Me.TabPage1.Controls.Add(Me.btnWhereSubtitleEdit)
        Me.TabPage1.Controls.Add(Me.btnWhereMPV)
        Me.TabPage1.Controls.Add(Me.btnPathOtherTranscode)
        Me.TabPage1.Controls.Add(Me.tbxPathothertranscode)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.btnPathFFProbe)
        Me.TabPage1.Controls.Add(Me.tbxPathffprobe)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btnPathFFMpeg)
        Me.TabPage1.Controls.Add(Me.tbxPathffmpeg)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnPathSubtitleEdit)
        Me.TabPage1.Controls.Add(Me.tbxPathSubtitleedit)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnPathMPV)
        Me.TabPage1.Controls.Add(Me.tbxPathMPV)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(767, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Paths"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnWhereRuby
        '
        Me.btnWhereRuby.Location = New System.Drawing.Point(632, 198)
        Me.btnWhereRuby.Name = "btnWhereRuby"
        Me.btnWhereRuby.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereRuby.TabIndex = 37
        Me.btnWhereRuby.Text = "Where"
        Me.btnWhereRuby.UseVisualStyleBackColor = True
        '
        'btnRuby
        '
        Me.btnRuby.Location = New System.Drawing.Point(551, 198)
        Me.btnRuby.Name = "btnRuby"
        Me.btnRuby.Size = New System.Drawing.Size(75, 23)
        Me.btnRuby.TabIndex = 36
        Me.btnRuby.Text = "Browse"
        Me.btnRuby.UseVisualStyleBackColor = True
        '
        'tbxPathRuby
        '
        Me.tbxPathRuby.Location = New System.Drawing.Point(150, 200)
        Me.tbxPathRuby.Name = "tbxPathRuby"
        Me.tbxPathRuby.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathRuby.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.CausesValidation = False
        Me.Label13.Location = New System.Drawing.Point(112, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Ruby"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnWhereMKVMerge
        '
        Me.btnWhereMKVMerge.Location = New System.Drawing.Point(632, 172)
        Me.btnWhereMKVMerge.Name = "btnWhereMKVMerge"
        Me.btnWhereMKVMerge.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereMKVMerge.TabIndex = 33
        Me.btnWhereMKVMerge.Text = "Where"
        Me.btnWhereMKVMerge.UseVisualStyleBackColor = True
        '
        'btnMKVMerge
        '
        Me.btnMKVMerge.Location = New System.Drawing.Point(551, 172)
        Me.btnMKVMerge.Name = "btnMKVMerge"
        Me.btnMKVMerge.Size = New System.Drawing.Size(75, 23)
        Me.btnMKVMerge.TabIndex = 32
        Me.btnMKVMerge.Text = "Browse"
        Me.btnMKVMerge.UseVisualStyleBackColor = True
        '
        'tbxPathMKVMerge
        '
        Me.tbxPathMKVMerge.Location = New System.Drawing.Point(150, 174)
        Me.tbxPathMKVMerge.Name = "tbxPathMKVMerge"
        Me.tbxPathMKVMerge.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathMKVMerge.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.CausesValidation = False
        Me.Label9.Location = New System.Drawing.Point(84, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "MKVMerge"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnWhereMKVPropEdit
        '
        Me.btnWhereMKVPropEdit.Location = New System.Drawing.Point(632, 146)
        Me.btnWhereMKVPropEdit.Name = "btnWhereMKVPropEdit"
        Me.btnWhereMKVPropEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereMKVPropEdit.TabIndex = 29
        Me.btnWhereMKVPropEdit.Text = "Where"
        Me.btnWhereMKVPropEdit.UseVisualStyleBackColor = True
        '
        'btnPathMKVPropEdit
        '
        Me.btnPathMKVPropEdit.Location = New System.Drawing.Point(551, 146)
        Me.btnPathMKVPropEdit.Name = "btnPathMKVPropEdit"
        Me.btnPathMKVPropEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnPathMKVPropEdit.TabIndex = 28
        Me.btnPathMKVPropEdit.Text = "Browse"
        Me.btnPathMKVPropEdit.UseVisualStyleBackColor = True
        '
        'tbxPathMKVPropEdit
        '
        Me.tbxPathMKVPropEdit.Location = New System.Drawing.Point(150, 148)
        Me.tbxPathMKVPropEdit.Name = "tbxPathMKVPropEdit"
        Me.tbxPathMKVPropEdit.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathMKVPropEdit.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.CausesValidation = False
        Me.Label8.Location = New System.Drawing.Point(74, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "MKVPropEdit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnWhereOtherTranscode
        '
        Me.btnWhereOtherTranscode.Location = New System.Drawing.Point(632, 120)
        Me.btnWhereOtherTranscode.Name = "btnWhereOtherTranscode"
        Me.btnWhereOtherTranscode.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereOtherTranscode.TabIndex = 25
        Me.btnWhereOtherTranscode.Text = "Where"
        Me.btnWhereOtherTranscode.UseVisualStyleBackColor = True
        '
        'btnWhereFFProbe
        '
        Me.btnWhereFFProbe.Location = New System.Drawing.Point(632, 94)
        Me.btnWhereFFProbe.Name = "btnWhereFFProbe"
        Me.btnWhereFFProbe.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereFFProbe.TabIndex = 24
        Me.btnWhereFFProbe.Text = "Where"
        Me.btnWhereFFProbe.UseVisualStyleBackColor = True
        '
        'btnWhereFFMpeg
        '
        Me.btnWhereFFMpeg.Location = New System.Drawing.Point(632, 68)
        Me.btnWhereFFMpeg.Name = "btnWhereFFMpeg"
        Me.btnWhereFFMpeg.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereFFMpeg.TabIndex = 23
        Me.btnWhereFFMpeg.Text = "Where"
        Me.btnWhereFFMpeg.UseVisualStyleBackColor = True
        '
        'btnWhereSubtitleEdit
        '
        Me.btnWhereSubtitleEdit.Location = New System.Drawing.Point(632, 42)
        Me.btnWhereSubtitleEdit.Name = "btnWhereSubtitleEdit"
        Me.btnWhereSubtitleEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereSubtitleEdit.TabIndex = 22
        Me.btnWhereSubtitleEdit.Text = "Where"
        Me.btnWhereSubtitleEdit.UseVisualStyleBackColor = True
        '
        'btnWhereMPV
        '
        Me.btnWhereMPV.Location = New System.Drawing.Point(632, 16)
        Me.btnWhereMPV.Name = "btnWhereMPV"
        Me.btnWhereMPV.Size = New System.Drawing.Size(75, 23)
        Me.btnWhereMPV.TabIndex = 21
        Me.btnWhereMPV.Text = "Where"
        Me.btnWhereMPV.UseVisualStyleBackColor = True
        '
        'btnPathOtherTranscode
        '
        Me.btnPathOtherTranscode.Location = New System.Drawing.Point(551, 120)
        Me.btnPathOtherTranscode.Name = "btnPathOtherTranscode"
        Me.btnPathOtherTranscode.Size = New System.Drawing.Size(75, 23)
        Me.btnPathOtherTranscode.TabIndex = 14
        Me.btnPathOtherTranscode.Text = "Browse"
        Me.btnPathOtherTranscode.UseVisualStyleBackColor = True
        '
        'tbxPathothertranscode
        '
        Me.tbxPathothertranscode.Location = New System.Drawing.Point(150, 122)
        Me.tbxPathothertranscode.Name = "tbxPathothertranscode"
        Me.tbxPathothertranscode.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathothertranscode.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.CausesValidation = False
        Me.Label5.Location = New System.Drawing.Point(63, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "other-transcode"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPathFFProbe
        '
        Me.btnPathFFProbe.Location = New System.Drawing.Point(551, 94)
        Me.btnPathFFProbe.Name = "btnPathFFProbe"
        Me.btnPathFFProbe.Size = New System.Drawing.Size(75, 23)
        Me.btnPathFFProbe.TabIndex = 11
        Me.btnPathFFProbe.Text = "Browse"
        Me.btnPathFFProbe.UseVisualStyleBackColor = True
        '
        'tbxPathffprobe
        '
        Me.tbxPathffprobe.Location = New System.Drawing.Point(150, 96)
        Me.tbxPathffprobe.Name = "tbxPathffprobe"
        Me.tbxPathffprobe.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathffprobe.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.CausesValidation = False
        Me.Label4.Location = New System.Drawing.Point(104, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ffprobe"
        '
        'btnPathFFMpeg
        '
        Me.btnPathFFMpeg.Location = New System.Drawing.Point(551, 68)
        Me.btnPathFFMpeg.Name = "btnPathFFMpeg"
        Me.btnPathFFMpeg.Size = New System.Drawing.Size(75, 23)
        Me.btnPathFFMpeg.TabIndex = 8
        Me.btnPathFFMpeg.Text = "Browse"
        Me.btnPathFFMpeg.UseVisualStyleBackColor = True
        '
        'tbxPathffmpeg
        '
        Me.tbxPathffmpeg.Location = New System.Drawing.Point(150, 70)
        Me.tbxPathffmpeg.Name = "tbxPathffmpeg"
        Me.tbxPathffmpeg.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathffmpeg.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.CausesValidation = False
        Me.Label3.Location = New System.Drawing.Point(105, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ffmpeg"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPathSubtitleEdit
        '
        Me.btnPathSubtitleEdit.Location = New System.Drawing.Point(551, 42)
        Me.btnPathSubtitleEdit.Name = "btnPathSubtitleEdit"
        Me.btnPathSubtitleEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnPathSubtitleEdit.TabIndex = 5
        Me.btnPathSubtitleEdit.Text = "Browse"
        Me.btnPathSubtitleEdit.UseVisualStyleBackColor = True
        '
        'tbxPathSubtitleedit
        '
        Me.tbxPathSubtitleedit.Location = New System.Drawing.Point(150, 44)
        Me.tbxPathSubtitleedit.Name = "tbxPathSubtitleedit"
        Me.tbxPathSubtitleedit.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathSubtitleedit.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.CausesValidation = False
        Me.Label2.Location = New System.Drawing.Point(84, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SubtitleEdit"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPathMPV
        '
        Me.btnPathMPV.Location = New System.Drawing.Point(551, 16)
        Me.btnPathMPV.Name = "btnPathMPV"
        Me.btnPathMPV.Size = New System.Drawing.Size(75, 23)
        Me.btnPathMPV.TabIndex = 2
        Me.btnPathMPV.Text = "Browse"
        Me.btnPathMPV.UseVisualStyleBackColor = True
        '
        'tbxPathMPV
        '
        Me.tbxPathMPV.Location = New System.Drawing.Point(150, 18)
        Me.tbxPathMPV.Name = "tbxPathMPV"
        Me.tbxPathMPV.Size = New System.Drawing.Size(395, 20)
        Me.tbxPathMPV.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.CausesValidation = False
        Me.Label1.Location = New System.Drawing.Point(114, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MPV"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tbxothertranscodeoptions)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.tbxMKVMergeOptions)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.tbxRobocopyDefaults)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.tbxOtherTranscodeDefaults)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.tbxMKVMergeDefaults)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(767, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Default Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tbxothertranscodeoptions
        '
        Me.tbxothertranscodeoptions.Location = New System.Drawing.Point(150, 96)
        Me.tbxothertranscodeoptions.Name = "tbxothertranscodeoptions"
        Me.tbxothertranscodeoptions.Size = New System.Drawing.Size(395, 20)
        Me.tbxothertranscodeoptions.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "other-transcoder Options"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMKVMergeOptions
        '
        Me.tbxMKVMergeOptions.Location = New System.Drawing.Point(150, 122)
        Me.tbxMKVMergeOptions.Name = "tbxMKVMergeOptions"
        Me.tbxMKVMergeOptions.Size = New System.Drawing.Size(395, 20)
        Me.tbxMKVMergeOptions.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(46, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "MKVMerge Options"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxRobocopyDefaults
        '
        Me.tbxRobocopyDefaults.Location = New System.Drawing.Point(150, 70)
        Me.tbxRobocopyDefaults.Name = "tbxRobocopyDefaults"
        Me.tbxRobocopyDefaults.Size = New System.Drawing.Size(395, 20)
        Me.tbxRobocopyDefaults.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(46, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Robocopy Defaults"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxOtherTranscodeDefaults
        '
        Me.tbxOtherTranscodeDefaults.Location = New System.Drawing.Point(150, 44)
        Me.tbxOtherTranscodeDefaults.Name = "tbxOtherTranscodeDefaults"
        Me.tbxOtherTranscodeDefaults.Size = New System.Drawing.Size(395, 20)
        Me.tbxOtherTranscodeDefaults.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "other-transcode Defaults"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMKVMergeDefaults
        '
        Me.tbxMKVMergeDefaults.Location = New System.Drawing.Point(150, 18)
        Me.tbxMKVMergeDefaults.Name = "tbxMKVMergeDefaults"
        Me.tbxMKVMergeDefaults.Size = New System.Drawing.Size(395, 20)
        Me.tbxMKVMergeDefaults.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "MKVMerge Defaults"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UserPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "UserPreferences"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UserPreferences"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnPathMPV As Button
    Friend WithEvents tbxPathMPV As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnPathOtherTranscode As Button
    Friend WithEvents tbxPathothertranscode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnPathFFProbe As Button
    Friend WithEvents tbxPathffprobe As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnPathFFMpeg As Button
    Friend WithEvents tbxPathffmpeg As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPathSubtitleEdit As Button
    Friend WithEvents tbxPathSubtitleedit As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnWhereOtherTranscode As Button
    Friend WithEvents btnWhereFFProbe As Button
    Friend WithEvents btnWhereFFMpeg As Button
    Friend WithEvents btnWhereSubtitleEdit As Button
    Friend WithEvents btnWhereMPV As Button
    Friend WithEvents tbxOtherTranscodeDefaults As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbxMKVMergeDefaults As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnWhereMKVMerge As Button
    Friend WithEvents btnMKVMerge As Button
    Friend WithEvents tbxPathMKVMerge As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnWhereMKVPropEdit As Button
    Friend WithEvents btnPathMKVPropEdit As Button
    Friend WithEvents tbxPathMKVPropEdit As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbxRobocopyDefaults As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbxothertranscodeoptions As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tbxMKVMergeOptions As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnWhereRuby As Button
    Friend WithEvents btnRuby As Button
    Friend WithEvents tbxPathRuby As TextBox
    Friend WithEvents Label13 As Label
End Class
