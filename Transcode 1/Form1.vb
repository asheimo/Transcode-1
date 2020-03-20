Imports System.IO
Imports System.Text
Public Class Form1
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Private Sub btnDirectory_Click(sender As Object, e As EventArgs) Handles btnInputDirectory.Click

        Dim objFSO As Object

        objFSO = CreateObject("Scripting.FileSystemObject")
        lbxDirectory.Items.Clear()

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtInputDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If

        For Each objFolder In objFSO.GetFolder(txtInputDirectory.Text).SubFolders
            If objFolder.name = "Remux" Or objFolder.name = "Transcode Settings" Then
            Else
                lbxDirectory.Items.Add(objFolder.Name)
            End If
        Next

    End Sub

    Private Sub lbxDirectory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxDirectory.SelectedIndexChanged

        Dim objFSO
        Dim objFolder
        Dim objFiles
        Dim strPath
        Dim intNode As Integer
        Dim strName, strName2  'temp variable
        Dim blnRemux As Boolean

        'Clear existing objects
        blnRemux = rbRemux.Checked
        ClassMyTreeView1.Nodes.Clear()
        CleanUp()

        ' Create a FileSystemObject  
        objFSO = CreateObject("Scripting.FileSystemObject")

        ' Define folder we want to list files from
        strPath = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem

        objFolder = objFSO.GetFolder(strPath)
        objFiles = objFolder.Files

        ' Loop through each file  
        For Each item In objFiles
            strName = Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 10)
            strName2 = Strings.Left(item.name, Strings.Len(item.name) - 4)
            If Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 10) = "featurette" Then
                intNode = SearchTreeNodeParents("featurette")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 15))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 7) = "trailer" Then
                intNode = SearchTreeNodeParents("trailer")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 12))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 15) = "behindthescenes" Then
                intNode = SearchTreeNodeParents("behindthescenes")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 20))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 7) = "deleted" Then
                intNode = SearchTreeNodeParents("deleted")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 12))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 9) = "interview" Then
                intNode = SearchTreeNodeParents("interview")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 14))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 5) = "other" Then
                intNode = SearchTreeNodeParents("other")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 10))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 5) = "scene" Then
                intNode = SearchTreeNodeParents("scene")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 10))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf Strings.Right(Strings.Left(item.name, Strings.Len(item.name) - 4), 5) = "short" Then
                intNode = SearchTreeNodeParents("short")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(Strings.Left(item.name, Strings.Len(item.name) - 10))
                    If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            Else
                ClassMyTreeView1.Nodes.Insert(0, Strings.Left(item.name, Strings.Len(item.name) - 4))
                If CheckRemux(Strings.Left(item.name, Strings.Len(item.name) - 4)) Then
                    ClassMyTreeView1.Nodes(0).BackColor = Color.Green
                End If
            End If
        Next
    End Sub

    Function SearchTreeNodeParents(strNodeName As String)
        Dim blnNodeFound As Boolean
        Dim i = 0
        If ClassMyTreeView1.Nodes.Count <> 0 Then
            For i = 1 To ClassMyTreeView1.Nodes.Count
                If ClassMyTreeView1.Nodes(i - 1).Name = UCase(Strings.Left(strNodeName, 1)) & Mid(strNodeName, 2) Then
                    blnNodeFound = True
                    Exit For
                End If
            Next
        End If
        If Not blnNodeFound Then
            ClassMyTreeView1.Nodes.Add(UCase(Strings.Left(strNodeName, 1)) & Mid(strNodeName, 2), UCase(Strings.Left(strNodeName, 1)) & Mid(strNodeName, 2))
            SearchTreeNodeParents = ClassMyTreeView1.Nodes.Count
        Else
            SearchTreeNodeParents = i
        End If

    End Function

    Private Sub ClassMyTreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles ClassMyTreeView1.BeforeSelect

        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()

        If e.Action = TreeViewAction.Unknown Then
            If e.Node Is Nothing Then Exit Sub
            If e.Node.Index = 0 Then
                Exit Sub
            End If
        End If
        If e.Node.FirstNode Is Nothing Then
            Exit Sub
        Else
            e.Cancel = True
            If e.Action = TreeViewAction.Collapse Or e.Action = TreeViewAction.Unknown Then

            Else
                If Not e.Node.IsExpanded Then
                    e.Node.Expand()
                    ClassMyTreeView1.SelectedNode = e.Node.FirstNode
                End If
            End If
        End If
    End Sub

    Private Sub ClassMyTreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ClassMyTreeView1.AfterSelect
        If e.Node.Parent Is Nothing Then
            ProcessAfterSelect(e.Node.Text & ".mkv")
            ShowSelected(e.Node.Text)
        Else
            ProcessAfterSelect(e.Node.Text & "-" & LCase(e.Node.Parent.Name) & ".mkv")
            ShowSelected(e.Node.Text & "-" & LCase(e.Node.Parent.Name))
        End If


    End Sub

    Sub ShowSelected(strRemuxFileName)
        Dim strPathRemux As String
        Dim strPathRemuxMovie As String
        Dim strPathRemuxFile As String
        Dim arrRemuxSettings
        Dim arrTracks

        strPathRemux = txtInputDirectory.Text & "\Remux"
        strPathRemuxMovie = strPathRemux & "\" & lbxDirectory.SelectedItem
        strPathRemuxFile = strPathRemuxMovie & "\" & strRemuxFileName & ".txt"

        If Not File.Exists(strPathRemuxFile) Then Exit Sub
        arrRemuxSettings = Split(My.Computer.FileSystem.ReadAllText(strPathRemuxFile), "--")
        For Each arrSetting In arrRemuxSettings
            If Strings.Left(LCase(arrSetting), 12) = "audio-tracks" Then
                arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                For Each Track In arrTracks
                    For Each info As DataGridViewRow In DataGridView2.Rows
                        If info.Cells(6).Value = Track Then
                            info.Selected = True
                        End If
                    Next
                Next
            ElseIf Strings.Left(LCase(Trim(arrSetting)), 15) = "subtitle-tracks" Then
                arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                For Each Track In arrTracks
                    For Each info As DataGridViewRow In DataGridView3.Rows
                        If info.Cells(6).Value = Track Then
                            info.Selected = True
                        End If
                    Next
                Next
            ElseIf Strings.Left(LCase(arrSetting), 13) = "default-track" Then
                arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                For Each Track In arrTracks
                    For Each info As DataGridViewRow In DataGridView2.Rows
                        If info.Cells(6).Value = Track Then
                            info.Cells(5).Value = True
                        End If
                    Next
                    For Each info As DataGridViewRow In DataGridView3.Rows
                        If info.Cells(6).Value = Track Then
                            info.Cells(4).Value = True
                        End If
                    Next
                Next

            End If
        Next

    End Sub

    Function GetStreamCount(strText)
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("FFProbe", " -show_entries format=nb_streams -v 0 -of compact=p=0:nk=1 " & Chr(34) & strText & Chr(34))
        oStartInfo.CreateNoWindow = True
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            Do While Not oStreamReader.EndOfStream
                GetStreamCount = oStreamReader.ReadToEnd()
            Loop
        End Using
#Disable Warning BC42105 ' Function 'GetStreamCount' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.
    End Function
#Enable Warning BC42105 ' Function 'GetStreamCount' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.

    Function FormatInfo(ByRef Arr(), ByRef strType, strTrack)
        Dim i
        Dim strName
        Dim strWidth
        Dim strHeight
        Dim strFPS
        Dim strChannelLayout
        Dim strBitRate
        Dim strLanguage
        Dim strTitle
        Dim strNumberOfFrames
        Dim arrStream(Arr.Length - 1, 1)
        Dim blnDefault As Boolean
        Dim blnForced As Boolean
        Dim strDefault
        Dim strForced

        Select Case strType
            Case "Video"
                arrStream = SplitArray(Arr)
                For i = 0 To UBound(arrStream)
                    Select Case arrStream(i, 0)
                        Case "codec_name"
                            strName = arrStream(i, 1)
                        Case "width"
                            strWidth = arrStream(i, 1)
                        Case "height"
                            strHeight = arrStream(i, 1)
                        Case "r_frame_rate"
                            strFPS = arrStream(i, 1)
                        Case "disposition:default"
                            If arrStream(i, 1) = 0 Then
                                blnDefault = False
                            Else
                                blnDefault = True
                            End If

                    End Select
                Next
                Dim DGR As Integer = DataGridView1.Rows.Add
                With DataGridView1
#Disable Warning BC42104 ' Variable 'strName' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(0).Value = strName
#Enable Warning BC42104 ' Variable 'strName' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strHeight' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(1).Value = strHeight & "p"
#Enable Warning BC42104 ' Variable 'strHeight' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strFPS' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(2).Value = strFPS
#Enable Warning BC42104 ' Variable 'strFPS' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(3).Value = blnDefault
                End With

            Case "Audio"
                arrStream = SplitArray(Arr)
                For i = 0 To UBound(arrStream)
                    Select Case arrStream(i, 0)
                        Case "codec_name"
                            strName = arrStream(i, 1)
                        Case "profile"
                            If strName = "dts" Then
                                strName = strName & " (" & arrStream(i, 1) & ")"
                            End If
                        Case "channel_layout"
                            strChannelLayout = arrStream(i, 1)
                        Case "bit_rate"
                            If arrStream(i, 1) <> "N/A" Then
                                strBitRate = arrStream(i, 1) / 1000
                            End If
                        Case "tag:BPS-eng"
                            If arrStream(i, 1) <> "" Then
                                strBitRate = arrStream(i, 1) / 1000
                            End If
                        Case "tag:language"
                            strLanguage = arrStream(i, 1)
                        Case "tag:title"
                            strTitle = arrStream(i, 1)
                        Case "disposition:default"
                            If arrStream(i, 1) = 0 Then
                                blnDefault = False
                            Else
                                blnDefault = True
                            End If
                        Case "index"
                            strTrack = arrStream(i, 1)
                    End Select
                Next
                Dim DGR As Integer = DataGridView2.Rows.Add
                With DataGridView2
                    .Rows(DGR).Cells(0).Value = strName
#Disable Warning BC42104 ' Variable 'strChannelLayout' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(1).Value = strChannelLayout
#Enable Warning BC42104 ' Variable 'strChannelLayout' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strBitRate' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(2).Value = strBitRate
#Enable Warning BC42104 ' Variable 'strBitRate' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strLanguage' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(3).Value = strLanguage
#Enable Warning BC42104 ' Variable 'strLanguage' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strTitle' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(4).Value = strTitle
#Enable Warning BC42104 ' Variable 'strTitle' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(5).Value = blnDefault
                    .Rows(DGR).Cells(6).Value = strTrack
                End With

            Case "Subtitle"
                arrStream = SplitArray(Arr)
                For i = 0 To UBound(arrStream)
                    Select Case arrStream(i, 0)
                        Case "codec_name"
                            strName = arrStream(i, 1)
                        Case "tag:NUMBER_OF_FRAMES-eng"
                            strNumberOfFrames = arrStream(i, 1)
                        Case "tag:language"
                            strLanguage = arrStream(i, 1)
                        Case "tag:NUMBER_OF_FRAMES-eng"
                            strNumberOfFrames = arrStream(i, 1)
                        Case "tag:title"
                            strTitle = arrStream(i, 1)
                        Case "disposition:default"
                            If arrStream(i, 1) = 1 Then
                                strDefault = True
                            End If
                        Case "disposition:forced"
                            If arrStream(i, 1) = 1 Then
                                strForced = True
                            End If
                        Case "index"
                            strTrack = arrStream(i, 1)
                    End Select
                Next
                Dim DGR As Integer = DataGridView3.Rows.Add
                With DataGridView3
                    .Rows(DGR).Cells(0).Value = strName
                    .Rows(DGR).Cells(1).Value = strLanguage
#Disable Warning BC42104 ' Variable 'strNumberOfFrames' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(2).Value = strNumberOfFrames
#Enable Warning BC42104 ' Variable 'strNumberOfFrames' is used before it has been assigned a value. A null reference exception could result at runtime.
                    .Rows(DGR).Cells(3).Value = strTitle
                    .Rows(DGR).Cells(4).Value = blnDefault
                    .Rows(DGR).Cells(5).Value = blnForced
                    .Rows(DGR).Cells(6).Value = strTrack
                End With

        End Select

        If Arr.Contains("codec_type=video") Then
            arrStream = SplitArray(Arr)
            Dim z = 0
        End If

#Disable Warning BC42105 ' Function 'FormatInfo' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.
    End Function
#Enable Warning BC42105 ' Function 'FormatInfo' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.

    Function SplitArray(ByRef Arr())
        Dim i
        Dim strCodec
        Dim arrTemp
        Dim arrStream(Arr.Length - 1, 1)

        For i = 0 To Arr.Length - 1
            arrTemp = Split(Arr(i), "=")
            On Error Resume Next
            arrStream(i, 0) = arrTemp(0)
            arrStream(i, 1) = arrTemp(1)
        Next i
        SplitArray = arrStream
    End Function

    Private Sub ClassMyTreeView1_BeforeCollapse(sender As Object, e As TreeViewEventArgs)
        If e.Action = TreeViewAction.Collapse Then
            CleanUp()

        End If
    End Sub

    Private Sub ProcessAfterSelect(txt)
        Dim i
        Dim intCount As Integer
        Dim oProcess As New Process()
        Dim strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & txt
        intCount = GetStreamCount(strText)
        Dim oStartInfo As New ProcessStartInfo("FFProbe", " -loglevel quiet -show_streams -print_format csv=nokey=0 " & Chr(34) & strText & Chr(34))
        oStartInfo.CreateNoWindow = True
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        ToolStripStatusLabel1.Text = "Working"
        oProcess.Start()
        ToolStripStatusLabel1.Text = ""
        Dim arrDetails(intCount - 1)

        i = 0
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            Do While Not oStreamReader.EndOfStream
                arrDetails(i) = Split(oStreamReader.ReadLine, ",")
                i = i + 1
            Loop
        End Using

        For i = 0 To UBound(arrDetails)
            Dim arrStream() As String
            arrStream = arrDetails(i)
            Dim lReturn As String = Array.Find(arrStream, Function(x) (x.StartsWith("codec_type")))
            Select Case lReturn
                Case "codec_type=video"
                    FormatInfo(arrDetails(i), "Video", i)
                Case "codec_type=audio"
                    FormatInfo(arrDetails(i), "Audio", i)
                Case "codec_type=subtitle"
                    FormatInfo(arrDetails(i), "Subtitle", i)
            End Select
        Next
    End Sub

    Private Sub CleanUp()
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()
    End Sub

    Private Sub btnMPV_Click(sender As Object, e As EventArgs) Handles btnMPV.Click
        Dim strText As String
        If ClassMyTreeView1.GetNodeCount(False) = 0 Then
            MsgBox("No Title Selected", vbExclamation, "Error")
            Exit Sub
        ElseIf ClassMyTreeView1.SelectedNode Is Nothing Then
            MsgBox("No Title Selected", vbExclamation, "Error")
            Exit Sub
        Else
            If ClassMyTreeView1.SelectedNode.Parent.Name <> "" Then
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & ClassMyTreeView1.SelectedNode.Parent.Name & ".mkv"
            Else
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & ".mkv"
            End If
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo("mpv", " -- " & Chr(34) & strText & Chr(34))
            oStartInfo.UseShellExecute = True
            oProcess.StartInfo = oStartInfo
            oProcess.Start()
        End If
    End Sub

    Private Sub btnSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnSubtitleEdit.Click
        Dim strText
        If ClassMyTreeView1.GetNodeCount(False) = 0 Then
            MsgBox("No Title Selected", vbExclamation, "Error")
            Exit Sub
        Else
            If ClassMyTreeView1.SelectedNode.Parent.Name <> "" Then
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & ClassMyTreeView1.SelectedNode.Parent.Name & ".mkv"
            Else
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & ".mkv"
            End If
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo("C:\bin\Subtitle Edit\SubtitleEdit", Chr(34) & strText & Chr(34))
            oStartInfo.UseShellExecute = True
            oProcess.StartInfo = oStartInfo
            oProcess.Start()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        rbRemux.Checked = True
        ValidateButtons("Load", True)
    End Sub

    Private Sub rbRemux_CheckedChanged(sender As Object, e As EventArgs) Handles rbRemux.CheckedChanged
        ValidateButtons(sender.text, sender.checked)
    End Sub
    Private Sub ValidateButtons(strSource As String, State As Boolean)
        Dim blnRemux As Boolean
        Dim blnCreate As Boolean
        Dim blnReview As Boolean

        If strSource = "Load" Then
            blnRemux = rbRemux.Checked
            blnCreate = rbCreate.Checked
            If blnRemux Then
                strSource = "Remux"
            ElseIf blnCreate Then
                strSource = "Create"
            ElseIf blnReview Then
                strSource = "Review"
            End If
        End If

        If strSource = "Remux" And State = False Then
            With btnMPV
                .Enabled = False
                .Visible = False
            End With
            With btnSubtitleEdit
                .Enabled = False
                .Visible = False
            End With
        Else
            With btnMPV
                .Enabled = True
                .Visible = True
            End With
            With btnSubtitleEdit
                .Enabled = True
                .Visible = True
            End With

        End If

    End Sub

    Sub ValidateColumns()

        If rbRemux.Checked Then
            DataGridView1.Columns(4).Visible = False
        ElseIf rbCreate.Checked Then
            DataGridView1.Columns(4).Visible = True
        End If
    End Sub

    Private Sub btnSaveRemux_Click(sender As Object, e As EventArgs) Handles btnSaveRemux.Click
        Dim strString
        If tbxOutputDirectory.Text = "" Then
            MsgBox("No Output Directory Chosen. Save Cancelled.", vbOKOnly, "Error")
            Exit Sub
        End If
        strString = CreateRemuxSettingsString()
        SaveRemuxFile(strString)

    End Sub

    Private Function CreateRemuxSettingsString()
        Dim strAlwaysOptions
        Dim strDefaultVideo
        Dim strDefaultAudio
        Dim strDefaultSubtitle
        Dim strVideo
        Dim strAudio
        Dim strSubtitle
        Dim strPathRemux As String
        Dim strPathRemuxMovie As String
        Dim strFileName
        Dim strTrackOrder As String
        Dim arrTrackOrder
        strPathRemux = txtInputDirectory.Text & "\Remux"
        strPathRemuxMovie = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem

        strAlwaysOptions = " --no-buttons --no-attachments "

        'Deal with video tracks
        'Currently ther is only one video track per title so there is no need for real processing
        strDefaultVideo = "--default-track 0"
        strVideo = "--Video-tracks 0"

        'Deal with Audio Tracks
        Dim arraylist As ArrayList = New ArrayList()
        For i = 0 To DataGridView2.SelectedRows.Count - 1
            arraylist.Insert(0, DataGridView2.SelectedRows(i))
        Next
        For Each objItem As DataGridViewRow In arraylist 'Audio tracks
            If objItem.Cells(5).Value = "True" Then
                strDefaultAudio = "--default-track " & objItem.Cells(6).Value
            End If
#Disable Warning BC42104 ' Variable 'strAudio' is used before it has been assigned a value. A null reference exception could result at runtime.
            strAudio = AudioRemuxString(strAudio, objItem.Cells(6).Value)
#Enable Warning BC42104 ' Variable 'strAudio' is used before it has been assigned a value. A null reference exception could result at runtime.
        Next

        'check if the audio tracks are in a different order
        strTrackOrder = Replace(Split(strAudio, " ")(1), ",", "")
        If Not isAlphabaticOrder(strTrackOrder) Then
            arrTrackOrder = Split(Split(strAudio, " ")(1), ",")
            strTrackOrder = "--track-order "
            For i = 0 To UBound(arrTrackOrder)
                strTrackOrder = strTrackOrder & "0:" & arrTrackOrder(i) & ","
            Next
            If Strings.Right(strTrackOrder, 1) = "," Then
                strTrackOrder = Strings.Left(strTrackOrder, Len(strTrackOrder) - 1)
            End If
        Else
            strTrackOrder = ""
        End If
        'Deal with Subtitle Tracks
        For Each objItem As DataGridViewRow In DataGridView3.SelectedRows 'Subtitle tracks
            If objItem.Cells(4).Value = True Then
                strDefaultSubtitle = "--default-track " & objItem.Cells(6).Value
            End If
#Disable Warning BC42104 ' Variable 'strSubtitle' is used before it has been assigned a value. A null reference exception could result at runtime.
            strSubtitle = SubtitleRemuxString(strSubtitle, objItem.Cells(6).Value)
#Enable Warning BC42104 ' Variable 'strSubtitle' is used before it has been assigned a value. A null reference exception could result at runtime.
        Next

        'create the proper file name
        If ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
            strFileName = ClassMyTreeView1.SelectedNode.Text & ".mkv"
        Else
            strFileName = ClassMyTreeView1.SelectedNode.Text & "-" & LCase(ClassMyTreeView1.SelectedNode.Parent.Name) & ".mkv"
        End If

        If strTrackOrder <> "" Then
#Disable Warning BC42104 ' Variable 'strDefaultSubtitle' is used before it has been assigned a value. A null reference exception could result at runtime.
#Disable Warning BC42104 ' Variable 'strDefaultAudio' is used before it has been assigned a value. A null reference exception could result at runtime.
            CreateRemuxSettingsString = "mkvmerge --output " & Chr(34) & tbxOutputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & strFileName & Chr(34) & " --title " & Chr(34) & Chr(34) & " " & strDefaultVideo & " " _
            & strDefaultAudio & " " & strDefaultSubtitle & " " & strAudio & " " & strTrackOrder & " " & strSubtitle & " " & strAlwaysOptions & " " _
            & Chr(34) & strPathRemuxMovie & "\" & strFileName & Chr(34)
#Enable Warning BC42104 ' Variable 'strDefaultAudio' is used before it has been assigned a value. A null reference exception could result at runtime.
#Enable Warning BC42104 ' Variable 'strDefaultSubtitle' is used before it has been assigned a value. A null reference exception could result at runtime.

        Else
            CreateRemuxSettingsString = "mkvmerge --output " & Chr(34) & tbxOutputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & strFileName & Chr(34) & " --title " & Chr(34) & Chr(34) & " " & strDefaultVideo & " " _
            & strDefaultAudio & " " & strDefaultSubtitle & " " & strAudio & " " & strSubtitle & " " & strAlwaysOptions & " " _
            & Chr(34) & strPathRemuxMovie & "\" & strFileName & Chr(34)
        End If

    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim box = New AboutBox1()
        box.ShowDialog()
    End Sub

    Sub SaveRemuxFile(strMKVMerge)
        Dim lResult
        Dim strPathRemux As String
        Dim strPathRemuxMovie As String
        Dim strPathRemuxFile As String
        strPathRemux = txtInputDirectory.Text & "\Remux"
        strPathRemuxMovie = strPathRemux & "\" & lbxDirectory.SelectedItem
        If ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
            strPathRemuxFile = strPathRemuxMovie & "\" & ClassMyTreeView1.SelectedNode.Text & ".txt"
        Else
            strPathRemuxFile = strPathRemuxMovie & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & LCase(ClassMyTreeView1.SelectedNode.Parent.Text) & ".txt"
        End If

        'check for "Remux" folder and create if needed
        If Not Directory.Exists(strPathRemux) Then
            Directory.CreateDirectory(strPathRemux)
        End If

        'check for movie folder and create if needed
        If Not Directory.Exists(strPathRemuxMovie) Then
            Directory.CreateDirectory(strPathRemuxMovie)
        End If

        'check for existing settings and ask to overwrite if needed
        If File.Exists(strPathRemuxFile) Then
            lResult = MsgBox("Remux Settings Already Exist. Overwrite", vbYesNo, "Remux Settings")
            If lResult = vbYes Then
                'create file and save settings
                Dim ObjFS As FileStream = File.Create(strPathRemuxFile)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(strMKVMerge) 'here is where the text goes
                ObjFS.Write(info, 0, info.Length)
                ObjFS.Close()
            ElseIf vbNo Then
                'cancel the save
            End If
        Else
            Dim ObjFS As FileStream = File.Create(strPathRemuxFile)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(strMKVMerge) 'here is where the text goes
            ObjFS.Write(info, 0, info.Length)
            ObjFS.Close()
            ClassMyTreeView1.SelectedNode.BackColor = Color.Green

        End If
    End Sub

    Function AudioRemuxString(strAudio, Item)
        If strAudio = "" Then
            strAudio = "--audio-tracks " & Item
        Else
            strAudio = strAudio & "," & Item
        End If
        AudioRemuxString = strAudio
    End Function

    Function SubtitleRemuxString(strSubtitle, Item)
        If strSubtitle = "" Then
            strSubtitle = "--subtitle-tracks " & Item
        Else
            strSubtitle = strSubtitle & "," & Item
        End If
        SubtitleRemuxString = strSubtitle
    End Function

    Function CheckRemux(strRemuxFileName)
        Dim blnRemux

        blnRemux = rbRemux.Checked
        If blnRemux Then
            Dim strPathRemux As String
            Dim strPathRemuxMovie As String
            Dim strPathRemuxFile As String
            strPathRemux = txtInputDirectory.Text & "\Remux"
            strPathRemuxMovie = strPathRemux & "\" & lbxDirectory.SelectedItem
            strPathRemuxFile = strPathRemuxMovie & "\" & strRemuxFileName & ".txt"

            If File.Exists(strPathRemuxFile) Then
                CheckRemux = True
            Else
                CheckRemux = False
            End If
        Else
            CheckRemux = False
        End If
    End Function

    Private Sub btnOutputDirectory_Click(sender As Object, e As EventArgs) Handles btnOutputDirectory.Click
        Dim objFSO As Object

        objFSO = CreateObject("Scripting.FileSystemObject")

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            tbxOutputDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub DataGridView2_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView2.DragDrop
        Dim p As Point = DataGridView2.PointToClient(New Point(e.X, e.Y))
        dragIndex = DataGridView2.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
            DataGridView2.Rows.RemoveAt(fromIndex)
            DataGridView2.Rows.Insert(dragIndex, dragRow)
        End If
    End Sub

    Private Sub DataGridView2_DragOver(ByVal sender As Object,
                                       ByVal e As DragEventArgs) _
                                       Handles DataGridView2.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DataGridView2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DataGridView2.MouseDown
        fromIndex = DataGridView2.HitTest(e.X, e.Y).RowIndex
        If fromIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2),
                                               e.Y - (dragSize.Height / 2)),
                                     dragSize)
        Else
            dragRect = Rectangle.Empty
        End If
    End Sub

    Private Sub DataGridView2_MouseMove(ByVal sender As Object,
                                        ByVal e As MouseEventArgs) _
                                        Handles DataGridView2.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty _
            AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DataGridView2.DoDragDrop(DataGridView2.Rows(fromIndex),
                                         DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub DataGridView3_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView3.DragDrop
        Dim p As Point = DataGridView3.PointToClient(New Point(e.X, e.Y))
        dragIndex = DataGridView3.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
            DataGridView3.Rows.RemoveAt(fromIndex)
            DataGridView3.Rows.Insert(dragIndex, dragRow)
        End If
    End Sub

    Private Sub DataGridView3_DragOver(ByVal sender As Object,
                                       ByVal e As DragEventArgs) _
                                       Handles DataGridView3.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DataGridView3_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DataGridView3.MouseDown
        fromIndex = DataGridView3.HitTest(e.X, e.Y).RowIndex
        If fromIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2),
                                               e.Y - (dragSize.Height / 2)),
                                     dragSize)
        Else
            dragRect = Rectangle.Empty
        End If
    End Sub

    Private Sub DataGridView3_MouseMove(ByVal sender As Object,
                                        ByVal e As MouseEventArgs) _
                                        Handles DataGridView3.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty _
            AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DataGridView3.DoDragDrop(DataGridView3.Rows(fromIndex),
                                         DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start(Chr(34) & txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & Chr(34))
    End Sub

    Private Sub RunRemuxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunRemuxToolStripMenuItem.Click
        If txtInputDirectory.Text = "" Then
            MsgBox("No Input Directory Chosen", vbExclamation, "Error")
            Exit Sub
        End If
        If tbxOutputDirectory.Text = "" Then
            MsgBox("No Output Directory Chosen", vbExclamation, "Error")
            Exit Sub
        End If

        Dim box = New RunRemux()
        box.ShowDialog()
    End Sub

    Private Shared Function isAlphabaticOrder(ByVal s As String) As Boolean
        Dim n As Integer = s.Length
        Dim c As Char() = New Char(n - 1) {}

        For i As Integer = 0 To n - 1
            c(i) = s(i)
        Next

        Array.Sort(c)

        For i As Integer = 0 To n - 1
            If c(i) <> s(i) Then Return False
        Next

        Return True
    End Function



End Class