Imports System.Data : Imports System.Diagnostics
Imports System.Drawing : Imports Microsoft.VisualBasic
Imports Microsoft.Win32 : Imports System.Net : Imports System.Net.WebClient
Imports System.Object : Imports System.Xml : Imports System.Windows.Forms
Imports System.Reflection : Imports System.Runtime.InteropServices
Imports System.Windows : Imports System.Windows.Input : Imports System.Text
Imports System.Threading : Imports System.Threading.Tasks : Imports System.CodeDom
Imports System.CodeDom.Compiler : Imports System.Globalization
Imports System.IO : Imports System.Collections : Imports System : Imports System.Web
Imports System.Collections.Generic : Imports System.Drawing.Bitmap
Imports System.MarshalByRefObject : Imports System.Drawing.Icon
Imports System.Attribute : Imports System.ComponentModel : Imports Microsoft.CSharp
Imports System.Drawing.Drawing2D

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
    End Sub

    Private Sub RunRemux(txt, blnCopy)
        Dim i
        Dim intCount As Integer
        Dim strOutputDirectory
        Dim arrFilePart1()
        Dim strCommand
        Dim strArgs
        Dim oProcess As New Process()
        If blnCopy Then
            strCommand = "Robocopy"
            strArgs = txt & " /njs /ndl /nc /ns"
        Else
            strCommand = Trim(Split(My.Computer.FileSystem.ReadAllText(txt), "--")(0))
            strArgs = Mid(My.Computer.FileSystem.ReadAllText(txt), Len(strCommand) + 1)
            arrFilePart1 = Split(My.Computer.FileSystem.ReadAllText(txt), "--")
            Dim strOutputFile = Mid(Replace(arrFilePart1(1), Chr(34), ""), InStr(Replace(arrFilePart1(1), Chr(34), ""), " ") + 1)
            'UpdateTextBox(strCommand & strArgs)
            'check for movie folder and create if needed
            strOutputDirectory = Strings.Left(strOutputFile, InStrRev(strOutputFile, "\") - 1)
            If Not Directory.Exists(strOutputDirectory) Then
                Directory.CreateDirectory(strOutputDirectory)
            End If
        End If

        Dim oStartInfo As New ProcessStartInfo(strCommand, strArgs)
        oStartInfo.CreateNoWindow = True
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        AddHandler oProcess.OutputDataReceived, AddressOf StreamView
        'oProcess.WaitForExit()
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
            For Each Title In objFiles
                'check for remux file
                strRemuxName = strRootDirectory & "Remux\" & objFolder.name & "\" & Strings.Left(Title.name, Strings.Len(Title.name) - 4) & ".txt"
                If File.Exists(strRemuxName) Then
                    'if remux file exists run remux
                    RunRemux(strRemuxName, False)
                Else
                    'if no remux file copy file to output folder
                    RunRemux(Chr(34) & strRootDirectory & "\" & objFolder.name & Chr(34) & " " & Chr(34) & Form1.tbxOutputDirectory.Text & "\" & objFolder.name & Chr(34) & " " & Chr(34) & Title.name & Chr(34), True)
                End If
            Next
        Next
        UpdateTextBox("Complete")
    End Sub

    Private Sub rtbProgress_TextChanged(sender As Object, e As EventArgs) Handles rtbProgress.TextChanged
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        ScrollToBottom(rtbProgress)
    End Sub
End Class