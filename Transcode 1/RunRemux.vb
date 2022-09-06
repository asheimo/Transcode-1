Imports System.Runtime.InteropServices
Imports System.IO
Public Class RunRemux
    Inherits Form
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer,
                                       ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    Const WM_SCROLL = 277
    Const SB_PAGEBOTTOM = 7
    Dim blnCancel As Boolean = False
    Sub ScrollToBottom(ByVal RTBName As RichTextBox)
        SendMessage(RTBName.Handle,
               WM_SCROLL,
               SB_PAGEBOTTOM,
               IntPtr.Zero)
    End Sub 'then call ScrollToBottom instead of ScrollToCaret
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If btnClose.Text = "Cancel" Then
            Dim pList() As Process = Process.GetProcesses()
            For Each prs In pList
                If prs.ProcessName = "ffmpeg" Then
                    prs.Kill()
                    blnCancel = True
                End If
            Next
        Else
            Me.Close()
        End If
    End Sub

    Private Sub RunRemux_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objFSO As Object
        Dim myNodeCollection As TreeNodeCollection = tvBox.Nodes
        Dim intParentCount As Integer
        objFSO = CreateObject("Scripting.FileSystemObject")
        For Each objFolder In objFSO.GetFolder(Form1.txtInputDirectory.Text).SubFolders
            If objFolder.name = "Remux" Or objFolder.name = "Transcode" Then
            Else
                'clbxDirectory.Items.Add(objFolder.Name)
                'code for treeview box to have individual title selection
                intParentCount = myNodeCollection.Count
                tvBox.Nodes.Add(objFolder.name)
                For Each objfile In objFSO.GetFolder(Form1.txtInputDirectory.Text & "/" & objFolder.name).files
                    tvBox.Nodes(intParentCount).Nodes.Add(objfile.name)
                Next
            End If
        Next
        If Form1.rbCreate.Checked Then
            Me.Text = "Run Transcode"
            cbxHEVC.Visible = True
            btnStart.Text = "Transcode"
        End If
    End Sub

    Private Sub RunProcessing(txt, blnCopy)
        Dim strOutputDirectory
        Dim arrFilePart1()
        Dim strCommand
        Dim strArgs
        Dim oProcess As New Process()
        Dim strOutputFile
        Dim strPath

        'disable changing of the checkbox list
        'clbxDirectory.Enabled = False
        If blnCopy Then
            arrFilePart1 = Split(txt, "|")
            strOutputDirectory = Strings.Left(arrFilePart1(1), Len(arrFilePart1(1)) - 1)
            'strOutputDirectory = Strings.Left(txt, InStrRev(txt, "\"))
        Else
            If Form1.rbRemux.Checked Then
                arrFilePart1 = Split(My.Computer.FileSystem.ReadAllText(txt), "--")
                strOutputFile = Mid(Replace(arrFilePart1(1), Chr(34), ""), InStr(Replace(arrFilePart1(1), Chr(34), ""), " ") + 1)
                strOutputDirectory = Strings.Left(txt, InStrRev(txt, "\"))
            ElseIf Form1.rbCreate.Checked Then
                arrFilePart1 = Nothing
                strOutputFile = Split(My.Computer.FileSystem.ReadAllText(txt), Chr(34))(1)
                strOutputDirectory = Form1.tbxOutputDirectory.Text & "\" & Split(strOutputFile, "\")(2)
            Else
                arrFilePart1 = Nothing
                Using New Centered_MessageBox(Me)
                    MsgBox("Error, Aborting", vbCritical, "Error")
                End Using
                'clbxDirectory.Enabled = True
                Exit Sub
            End If
        End If
        'check for movie folder and create if needed
        If Not Directory.Exists(strOutputDirectory) Then
            Directory.CreateDirectory(strOutputDirectory)
        End If


        If blnCopy Then
            If Form1.rbRemux.Checked Then
                strCommand = "Robocopy"
                strArgs = Chr(34) & Strings.Left(arrFilePart1(0), Len(arrFilePart1(0)) - 1) & Chr(34) & " " & Chr(34) & Strings.Left(arrFilePart1(1), Len(arrFilePart1(1)) - 1) & Chr(34) & " " & Chr(34) & arrFilePart1(2) & Chr(34) & My.Settings.RoboCopy_Defaults
                'strArgs = Replace(Chr(34) & txt, "|", Chr(34) & " " & Chr(34)) & Chr(34) & My.Settings.RoboCopy_Defaults
            ElseIf Form1.rbCreate.Checked Then
                strCommand = My.Settings.Ruby_Path & " "
                strPath = Replace(arrFilePart1(0), Chr(34), "") & "\" & Replace(arrFilePart1(2), Chr(34), "")
                If cbxHEVC.Checked Then
                    strArgs = My.Settings.othertranscode_Path & " --hevc " & My.Settings.othertranscode_Defaults & Chr(34) & strPath & Chr(34)
                Else
                    strArgs = My.Settings.othertranscode_Path & My.Settings.othertranscode_Defaults & Chr(34) & strPath & Chr(34)
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MsgBox("Error, Aborting", vbCritical, "Error")
                End Using
                'clbxDirectory.Enabled = True
                Exit Sub
            End If
        Else
            If Form1.rbRemux.Checked Then
                strCommand = Trim(Split(My.Computer.FileSystem.ReadAllText(txt), "--")(0))
                strArgs = Mid(My.Computer.FileSystem.ReadAllText(txt), Len(strCommand) + 1)
            ElseIf Form1.rbCreate.Checked Then
                strCommand = My.Settings.Ruby_Path & " "
                strArgs = My.Computer.FileSystem.ReadAllText(txt)
            Else
                strCommand = ""
                strArgs = ""

            End If
        End If

        Dim oStartInfo As New ProcessStartInfo(strCommand, strArgs)
        If Form1.rbCreate.Checked Then
            oStartInfo.WorkingDirectory = strOutputDirectory & "\"
        End If
        oStartInfo.CreateNoWindow = True
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.RedirectStandardError = True
        oProcess.StartInfo = oStartInfo
        AddHandler oProcess.OutputDataReceived, AddressOf StreamView
        AddHandler oProcess.ErrorDataReceived, AddressOf StreamView
        oProcess.Start()
        oProcess.BeginOutputReadLine()
        oProcess.BeginErrorReadLine()
        While Not oProcess.HasExited
            Application.DoEvents()
        End While
        'clbxDirectory.Enabled = True
    End Sub

    Sub StreamView(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        UpdateTextBox(e.Data)
    End Sub

    Private Delegate Sub UpdateTextBoxDelegate(ByVal Text As String)
    Private Sub UpdateTextBox(ByVal Tex As String)
        If Me.InvokeRequired Then
            Dim del As New UpdateTextBoxDelegate(AddressOf UpdateTextBox)
            Dim args As Object() = {Tex}
            Me.Invoke(del, args)
        Else
            If Tex = "Complete" Then
                'rtbProgress.AddLine("Job Complete", 200)
                rtbProgress.Text &= vbCrLf & "Job Complete" & vbCrLf
            ElseIf Tex Is Nothing Then
                'rtbProgress.AddLine(Tex, 200)
                rtbProgress.Text &= Tex & vbCrLf
            ElseIf Strings.Left(Tex, 6) = "frame=" Then
                'rtbProgress.Text &= Tex
                Dim lines As String() = rtbProgress.Lines
                lines(rtbProgress.Lines.Count - 1) = Tex
                rtbProgress.Lines = lines
            ElseIf Strings.Left(Tex, 9) = "Progress:" Then
                'rtbProgress.Text &= Tex
                Dim lines As String() = rtbProgress.Lines
                lines(rtbProgress.Lines.Count - 1) = Tex
                rtbProgress.Lines = lines
                If Tex = "Progress: 100%" Then
                    rtbProgress.AddLine("", 200)
                    'rtbProgress.Text &= Environment.NewLine
                End If
            ElseIf Tex.EndsWith("%") Then
                'rtbProgress.Text &= Tex
                Dim lines As String() = rtbProgress.Lines
                lines(rtbProgress.Lines.Count - 1) = Tex
                rtbProgress.Lines = lines
            Else
                'rtbProgress.AddLine(Tex, 200)
                rtbProgress.Text &= Tex & vbCrLf
            End If
        End If
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim objFSO As Object
        Dim objFolder
        Dim objFiles
        'Dim strRemuxName
        Dim strRootDirectory
        Dim selectedParentNode = Nothing
        Dim selectedChildNode = Nothing
        Dim countParentIndex As Integer = 0
        Dim countChildIndex As Integer = 0

        btnClose.Text = "Cancel"
        'rtbProgress.ResetText()
        'lblFolderProgress.Visible = True
        'lblOverallProgress.Visible = True
        'With pbFolderProgress
        '    .Visible = True
        '    .Minimum = 1
        '    .Value = 1
        '    .Step = 1
        'End With

        'With pbOverallProgress
        '    .Visible = True
        '    .Minimum = 1
        '    .Value = 1
        '    .Step = 1
        'End With

        objFSO = CreateObject("Scripting.FileSystemObject")
        strRootDirectory = Form1.txtInputDirectory.Text & "\"
        'If clbxDirectory.CheckedItems.Count = 0 Then
        '    Using New Centered_MessageBox(Me)
        '        MsgBox("No items chosen", vbExclamation, "Error")
        '    End Using
        '    Exit Sub
        'Else
        '    pbOverallProgress.Maximum = clbxDirectory.CheckedItems.Count
        'End If
        Dim intParentCount As Integer = tvBox.Nodes.Count
        For Each myParentNode As TreeNode In tvBox.Nodes
            objFolder = objFSO.GetFolder(strRootDirectory & myParentNode.Text)
            objFiles = objFolder.Files
            If myParentNode.Checked Then
                For Each Title In objFiles
                    performAction(strRootDirectory, objFolder.name & "\", Title.name)
                Next
                'myParentNode.BackColor = Color.Yellow
                'selectedParentNode += myParentNode.Text & " "
                'countParentIndex += 1
            Else
                'myParentNode.BackColor = Color.White
                'For i = 0 To intParentCount - 1
                For Each myChildNode As TreeNode In myParentNode.Nodes
                    If myChildNode.Checked Then
                        performAction(strRootDirectory, myParentNode.Text & "\", myChildNode.Text)
                        'myChildNode.BackColor = Color.Yellow
                        'selectedChildNode += myChildNode.Text & " "
                        'countChildIndex += 1
                    Else
                        myChildNode.BackColor = Color.White
                    End If
                Next
                'Next i
                countChildIndex = 0
            End If

        Next
        'For Each item In clbxDirectory.CheckedItems
        '    lblOverallProgress.Text = "Total Progress " & pbOverallProgress.Value & "/" & pbOverallProgress.Maximum
        '    objFolder = objFSO.GetFolder(strRootDirectory & item)
        '    objFiles = objFolder.Files
        '    pbFolderProgress.Maximum = objFiles.count
        '    pbFolderProgress.Value = 1
        '    If Form1.rbRemux.Checked Then
        '        For Each Title In objFiles
        '            lblFolderProgress.Text = "Folder Progress " & pbFolderProgress.Value & "/" & pbFolderProgress.Maximum
        '            'check for remux file
        '            strRemuxName = strRootDirectory & "Remux\" & objFolder.name & "\" & Strings.Left(Title.name, Strings.Len(Title.name) - 4) & ".txt"
        '            If File.Exists(strRemuxName) Then
        '                'if remux file exists run remux
        '                RunProcessing(strRemuxName, False)
        '            Else
        '                'if no remux file copy file to output folder
        '                RunProcessing(strRootDirectory & objFolder.name & "|" & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & "|" & Title.name, True)
        '                pbFolderProgress.PerformStep()

        '            End If
        '            'If blnCancel Then
        '            '    UpdateTextBox("Job Cancelled")
        '            '    lblFolderProgress.Visible = False
        '            '    lblOverallProgress.Visible = False
        '            '    pbFolderProgress.Visible = False
        '            '    pbOverallProgress.Visible = False
        '            '    btnClose.Text = "Close"
        '            '    Exit Sub
        '            'End If
        '        Next
        '    ElseIf Form1.rbCreate.Checked Then
        '        For Each Title In objFiles
        '            lblFolderProgress.Text = "Folder Progress " & pbFolderProgress.Value & "/" & pbFolderProgress.Maximum
        '            'check for Transcode file
        '            strRemuxName = strRootDirectory & "Transcode\" & objFolder.name & "\" & Strings.Left(Title.name, Strings.Len(Title.name) - 4) & ".txt"
        '            If File.Exists(strRemuxName) Then
        '                'if Transcode file exists run remux
        '                RunProcessing(strRemuxName, False)
        '            Else
        '                'if no transcode file run with default settings
        '                RunProcessing(Chr(34) & strRootDirectory & objFolder.name & "|" & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & "|" & Title.name & Chr(34), True)
        '            End If
        '            pbFolderProgress.PerformStep()
        '            'rtbProgress.ResetText()
        '            If blnCancel Then
        '                Dim strDir As String = Form1.tbxOutputDirectory.Text & "\" & objFolder.name
        '                If File.Exists(strDir & "\" & Title.name) Then
        '                    My.Computer.FileSystem.DeleteFile(strDir & "\" & Title.name)
        '                End If
        '                For Each foundFile As String In My.Computer.FileSystem.GetFiles(strDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "_ffmpeg*")
        '                    My.Computer.FileSystem.DeleteFile(foundFile)
        '                    Exit For
        '                Next
        '                UpdateTextBox("Job Cancelled")
        '                lblFolderProgress.Visible = False
        '                lblOverallProgress.Visible = False
        '                pbFolderProgress.Visible = False
        '                pbOverallProgress.Visible = False
        '                btnClose.Text = "Close"
        '                blnCancel = False
        '                Exit Sub
        '            End If
        '        Next
        '
        'End If
        'pbOverallProgress.PerformStep()
        'Next
        UpdateTextBox("Complete")
        'lblFolderProgress.Visible = False
        'lblOverallProgress.Visible = False
        'pbFolderProgress.Visible = False
        'pbOverallProgress.Visible = False
        btnClose.Text = "Close"
        blnCancel = False
    End Sub

    Sub performAction(rootfolder As String, path As String, title As String)
        'Dim objFSO As Object
        Dim objFolder
        Dim objFiles
        '''''''''''''''''' temp vari
        Dim strRootDirectory, item, strremuxname

        'MsgBox("the path is " & path & title, vbOKOnly)
        'Exit Sub

        'objFolder = objFSO.GetFolder(strRootDirectory & item)
        'objFiles = objFolder.Files

        If Form1.rbRemux.Checked Then
            '    For Each title In objFiles
            'lblFolderProgress.Text = "Folder Progress " & pbFolderProgress.Value & "/" & pbFolderProgress.Maximum
            'check for remux file
            strremuxname = rootfolder & "Remux\" & path & Strings.Left(title, Strings.Len(title) - 4) & ".txt"
            If File.Exists(strremuxname) Then
                'if remux file exists run remux
                RunProcessing(strremuxname, False)
            Else
                'if no remux file copy file to output folder
                'RunProcessing(rootfolder & Split(path, "\")(2) & "|" & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & "|" & title, True)
                RunProcessing(rootfolder & path & "|" & Form1.tbxOutputDirectory.Text & "\" & path & "|" & title, True)
                'pbFolderProgress.PerformStep()

            End If
            If blnCancel Then
                UpdateTextBox("Job Cancelled")
                Exit Sub
            End If
            'Next
        ElseIf Form1.rbCreate.Checked Then
            'For Each title In objFiles
            'lblFolderProgress.Text = "Folder Progress " & pbFolderProgress.Value & "/" & pbFolderProgress.Maximum
            'check for Transcode file
            strremuxname = rootfolder & "Remux\" & path & Strings.Left(title, Strings.Len(title) - 4) & ".txt"
            'strremuxname = strRootDirectory & "Transcode\" & objFolder.name & "\" & Strings.Left(title, Strings.Len(title) - 4) & ".txt"
            If File.Exists(strremuxname) Then
                'if Transcode file exists run remux
                RunProcessing(strremuxname, False)
            Else
                'if no transcode file run with default settings
                'RunProcessing(Chr(34) & strRootDirectory & objFolder.name & "|" & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & "|" & title & Chr(34), True)
                RunProcessing(rootfolder & path & "|" & Form1.tbxOutputDirectory.Text & "\" & path & "|" & title, True)
            End If
            'pbFolderProgress.PerformStep()
            'rtbProgress.ResetText()
            If blnCancel Then
                Dim strDir As String = Form1.tbxOutputDirectory.Text & "\" & objFolder.name
                If File.Exists(strDir & "\" & title) Then
                    My.Computer.FileSystem.DeleteFile(strDir & "\" & title)
                End If
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(strDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "_ffmpeg*")
                    My.Computer.FileSystem.DeleteFile(foundFile)
                    Exit For
                Next
                UpdateTextBox("Job Cancelled")
                'lblFolderProgress.Visible = False
                'lblOverallProgress.Visible = False
                'pbFolderProgress.Visible = False
                'pbOverallProgress.Visible = False
                btnClose.Text = "Close"
                blnCancel = False
                Exit Sub
            End If
            'Next

        End If

    End Sub

    Private Sub RtbProgress_TextChanged(sender As Object, e As EventArgs) Handles rtbProgress.TextChanged
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        ScrollToBottom(rtbProgress)
    End Sub

    'Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
    '    For i As Integer = 0 To clbxDirectory.Items.Count - 1
    '        clbxDirectory.SetItemChecked(i, True)
    '    Next
    'End Sub

End Class