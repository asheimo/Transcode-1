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
    Sub ScrollToBottom(ByVal RTBName As RichTextBox)
        SendMessage(RTBName.Handle,
               WM_SCROLL,
               SB_PAGEBOTTOM,
               IntPtr.Zero)
    End Sub 'then call ScrollToBottom instead of ScrollToCaret
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub RunRemux_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objFSO As Object
        objFSO = CreateObject("Scripting.FileSystemObject")
        For Each objFolder In objFSO.GetFolder(Form1.txtInputDirectory.Text).SubFolders
            If objFolder.name = "Remux" Or objFolder.name = "Transcode Settings" Then
            Else
                clbxDirectory.Items.Add(objFolder.Name)
            End If
        Next
        If Form1.rbCreate.Checked Then
            Me.Text = "Run Transcode"
            cbxHEVC.Visible = True
        End If
    End Sub

    Private Sub RunRemux(txt, blnCopy)
        Dim strOutputDirectory
        Dim arrFilePart1()
        Dim strCommand
        Dim strArgs
        Dim oProcess As New Process()
        Dim strOutputFile

        If blnCopy Then
            arrFilePart1 = Split(txt, "|")
            strOutputDirectory = arrFilePart1(1)
        Else
            arrFilePart1 = Split(My.Computer.FileSystem.ReadAllText(txt), "--")
            strOutputFile = Mid(Replace(arrFilePart1(1), Chr(34), ""), InStr(Replace(arrFilePart1(1), Chr(34), ""), " ") + 1)
            strOutputDirectory = Strings.Left(strOutputFile, InStrRev(strOutputFile, "\") - 1)
        End If
        'check for movie folder and create if needed
        If Not Directory.Exists(strOutputDirectory) Then
            Directory.CreateDirectory(strOutputDirectory)
        End If


        If blnCopy Then
            If Form1.rbRemux.Checked Then
                strCommand = "Robocopy"
                strArgs = Replace(Chr(34) & txt, "|", Chr(34) & " " & Chr(34)) & Chr(34) & " /is /njs /ndl /nc /ns"
            ElseIf Form1.rbCreate.Checked Then
                strCommand = "other-transcode"
                If cbxHEVC.Checked Then
                    strArgs = " --hevc --copy-track-names --add-audio eng --add-subtitle eng " & txt
                Else
                    strArgs = " --copy-track-names --add-audio eng --add-subtitle eng " & txt
                End If
            Else
                MsgBox("Error, Aborting", vbCritical, "Error")
                Exit Sub
            End If
        Else
            strCommand = Trim(Split(My.Computer.FileSystem.ReadAllText(txt), "--")(0))
            strArgs = Mid(My.Computer.FileSystem.ReadAllText(txt), Len(strCommand) + 1)
        End If

        Dim oStartInfo As New ProcessStartInfo(strCommand, strArgs)
        If Form1.rbCreate.Checked Then
            oStartInfo.WorkingDirectory = Form1.tbxOutputDirectory.Text & "" 'need to add movie folder here
        End If
        oStartInfo.CreateNoWindow = True
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        AddHandler oProcess.OutputDataReceived, AddressOf StreamView
        oProcess.Start()
        oProcess.BeginOutputReadLine()
        While Not oProcess.HasExited
            Application.DoEvents()
        End While

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
                rtbProgress.Text &= "Job Complete" & vbCrLf
            ElseIf Tex Is Nothing Then
                rtbProgress.Text &= Tex & vbCrLf
            ElseIf Strings.Left(Tex, 9) = "Progress:" Then
                Dim lines As String() = rtbProgress.Lines
                lines(rtbProgress.Lines.Count - 1) = Tex
                rtbProgress.Lines = lines
                If Tex = "Progress: 100%" Then
                    rtbProgress.Text &= Environment.NewLine
                End If
            ElseIf Tex.EndsWith("%") Then
                Dim lines As String() = rtbProgress.Lines
                lines(rtbProgress.Lines.Count - 1) = Tex
                rtbProgress.Lines = lines
            Else
                rtbProgress.Text &= Tex & vbCrLf
            End If
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim objFSO As Object
        Dim objFolder
        Dim objFiles
        Dim strRemuxName
        Dim strRootDirectory

        rtbProgress.ResetText()

        objFSO = CreateObject("Scripting.FileSystemObject")
        strRootDirectory = Form1.txtInputDirectory.Text & "\"
        If clbxDirectory.CheckedItems.Count = 0 Then
            MsgBox("No items chosen", vbExclamation, "Error")
            Exit Sub
        End If
        For Each item In clbxDirectory.CheckedItems
            objFolder = objFSO.GetFolder(strRootDirectory & item)
            objFiles = objFolder.Files
            If Form1.rbRemux.Checked Then
                For Each Title In objFiles
                    'check for remux file
                    strRemuxName = strRootDirectory & "Remux\" & objFolder.name & "\" & Strings.Left(Title.name, Strings.Len(Title.name) - 4) & ".txt"
                    If File.Exists(strRemuxName) Then
                        'if remux file exists run remux
                        RunRemux(strRemuxName, False)
                    Else
                        'if no remux file copy file to output folder
                        RunRemux(strRootDirectory & objFolder.name & "|" & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & "|" & Title.name, True)
                    End If
                Next
            ElseIf Form1.rbCreate.Checked Then
                For Each Title In objFiles
                    'check for Transcode file
                    strRemuxName = strRootDirectory & "Transcode\" & objFolder.name & "\" & Strings.Left(Title.name, Strings.Len(Title.name) - 4) & ".txt"
                    If File.Exists(strRemuxName) Then
                        'if Transcode file exists run remux
                        RunRemux(strRemuxName, False)
                    Else
                        'if no transcode file run with default settings
                        RunRemux(Chr(34) & strRootDirectory & "\" & objFolder.name & Chr(34) & " " & Chr(34) & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & Chr(34) & " " & Chr(34) & Title.name & Chr(34), True)
                    End If
                Next

            End If
        Next
        UpdateTextBox("Complete")
    End Sub

    Private Sub rtbProgress_TextChanged(sender As Object, e As EventArgs) Handles rtbProgress.TextChanged
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        ScrollToBottom(rtbProgress)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For i As Integer = 0 To clbxDirectory.Items.Count - 1
            clbxDirectory.SetItemChecked(i, True)
        Next
    End Sub
End Class