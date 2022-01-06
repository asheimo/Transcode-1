Imports System.IO
Imports System.Text
Public Class Form1
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Does the initial setup of the application and validates that all required programs
        'are installed. If not present the user with a message to set the paths and 
        'puts them to the preferences screen.

        rbRemux.Checked = True
        ValidateButtons("Load", True)
        If My.Settings.MPV_Path = "" Or
        My.Settings.SubtitleEdit_Path = "" Or
        My.Settings.ffmpeg_Path = "" Or
        My.Settings.ffprobe_Path = "" Or
        My.Settings.othertranscode_Path = "" Or
        My.Settings.MKVPropEdit_Path = "" Or
        My.Settings.MKVMerge_Path = "" Or
        My.Settings.Ruby_Path = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("Please Set Paths", vbCritical, "Application Paths Missing")
            End Using
            Dim box = New UserPreferences()
            box.ShowDialog()
        End If
    End Sub
    Private Sub BtnDirectory_Click(sender As Object, e As EventArgs) Handles btnInputDirectory.Click
        'When the input directory button is selected present a selection screen to
        'pick the desired folder. Upon selection load the folder contents into the 
        'lbxDirectory box
        Dim objFSO As Object

        objFSO = CreateObject("Scripting.FileSystemObject")
        'We automatically clear the box anytime a new input is being chosen.
        ' ***** Should probably put into the actual dialog section so that if the user cancels nothing is changed ***** 
        lbxDirectory.Items.Clear()
        txtInputDirectory.Clear()
        ClassMyTreeView1.Nodes.Clear()
        CleanUp()
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtInputDirectory.Text = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        For Each objFolder In objFSO.GetFolder(txtInputDirectory.Text).SubFolders
            If objFolder.name = "Remux" Or objFolder.name = "Transcode" Then
                'don't load these folders in the selection view because they are just settings files
            Else
                lbxDirectory.Items.Add(objFolder.Name)
            End If
        Next

    End Sub

    Private Sub LbxDirectory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxDirectory.SelectedIndexChanged
        'When a object is selected in the lbxDirectory box is select populate the contents
        'into the ClassMyTreeView1 box for the user to be able to select the individual items
        Dim objFSO
        Dim objFolder
        Dim objFiles
        Dim strPath
        Dim intNode As Integer
        Dim strType As String 'type label from filename
        Dim strLongName As String 'filename without extension
        Dim strShortName As String 'filename without extension or type label
        Dim blnRemux As Boolean

        'Clear existing objects
        blnRemux = rbRemux.Checked
        ClassMyTreeView1.Nodes.Clear()
        CleanUp() 'Resets DataGrid Rows for new entries

        'Get the path to the folder and return the files in said folder
        objFSO = CreateObject("Scripting.FileSystemObject")
        strPath = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem
        objFolder = objFSO.GetFolder(strPath)
        objFiles = objFolder.Files

        'Loop through each file and read the labeling. The files need to be prenamed by the type
        'of object they are trailer, featurette, deleted, interview etc. This then allows the files
        'to be grouped in the selection window for organizational purposes. Also checks for a settings
        'file either Remux or Transcode depending on the mode and if exists then change the color of the
        'object to reflect that.
        For Each item In objFiles
            strLongName = Strings.Left(item.name, Strings.Len(item.name) - 4)
            If InStr(item.name, "-") <> 0 Then
                strType = Strings.Left((Strings.Split(item.name, "-")(1)), Strings.Len(Strings.Split(item.name, "-")(1)) - 4)
                strShortName = Strings.Left(strLongName, Strings.Len(strLongName) - Strings.Len(strType) - 1)
            Else
                strType = Strings.Left(item.name, Strings.Len(item.name) - 4)
                strShortName = strType
            End If
            If strType = "featurette" Then
                intNode = SearchTreeNodeParents("featurette")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "trailer" Then
                intNode = SearchTreeNodeParents("trailer")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "behindthescenes" Then
                intNode = SearchTreeNodeParents("behindthescenes")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "deleted" Then
                intNode = SearchTreeNodeParents("deleted")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "interview" Then
                intNode = SearchTreeNodeParents("interview")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "other" Then
                intNode = SearchTreeNodeParents("other")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "scene" Then
                intNode = SearchTreeNodeParents("scene")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            ElseIf strType = "short" Then
                intNode = SearchTreeNodeParents("short")
                With ClassMyTreeView1.Nodes(intNode - 1)
                    .Nodes.Add(strShortName)
                    If CheckSettingsFile(strLongName) Then
                        .LastNode.BackColor = Color.Green
                    End If
                End With
            Else
                ClassMyTreeView1.Nodes.Insert(0, strLongName)
                If CheckSettingsFile(strLongName) Then
                    ClassMyTreeView1.Nodes(0).BackColor = Color.Green
                End If
            End If
        Next
    End Sub

    Function SearchTreeNodeParents(strNodeName As String)
        'Checks for the existance of a particular node such as featurette,
        'trailer, etc and if not found creates said node
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
        'captures the event when a object is selected from the tree to populate the grids below
        'clears the grids based on what function the app is in Remux or Transcode
        If rbRemux.Checked Then
            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            DataGridView3.Rows.Clear()
        ElseIf rbCreate.Checked Then
            DataGridView4.Rows.Clear()
            DataGridView5.Rows.Clear()
            DataGridView6.Rows.Clear()
        End If

        'if the action that triggered the event is unknown then exit the sub
        ' **** why isn't this the first thing in the sub? ****
        If e.Action = TreeViewAction.Unknown Then
            If e.Node Is Nothing Then Exit Sub
            If e.Node.Index = 0 Then
                Exit Sub
            End If
        End If
        'FirstNode is the container. If it doesn't exist then exit the sub because there
        'is nothing to do. Otherwise expand or collapse the container as needed.
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
        'once the container has been opened or closed in the BeforeSelect event then process
        'the selected item by populating the grids in the lower half or the window.
        If e.Node.Parent Is Nothing Then
            'evaluate if the selected object is in a container to determine the filename to pass
            'to the subs that do the processing.
            ProcessAfterSelect(e.Node.Text & ".mkv", Mode)
            ShowSelected(e.Node.Text)
        Else
            ProcessAfterSelect(e.Node.Text & "-" & LCase(e.Node.Parent.Name) & ".mkv", Mode)
            ShowSelected(e.Node.Text & "-" & LCase(e.Node.Parent.Name))
        End If
    End Sub

    Function Mode()
        'Function evaluates which mode radio button is selected.
        'If for some reason no radio button is selected default to
        'Remux mode and check the radio box.
        If rbRemux.Checked Then
            Mode = "Remux"
        ElseIf rbCreate.Checked Then
            Mode = "Create"
        Else
            rbRemux.Checked = True
            Mode = "Remux"
        End If
    End Function
    Sub ShowSelected(strFileName)
        'This modifies what has been entered by the processinfo sub with any settings that have
        'already been saved into a processing file
        Dim strPathMode As String
        Dim strPathModeMovie As String
        Dim strPathModeFile As String
        Dim arrSettings
        Dim arrTracks
        Dim arrDetails()

        If rbRemux.Checked Then
            strPathMode = txtInputDirectory.Text & "\Remux"
        Else
            strPathMode = txtInputDirectory.Text & "\Transcode"
        End If
        strPathModeMovie = strPathMode & "\" & lbxDirectory.SelectedItem
        strPathModeFile = strPathModeMovie & "\" & strFileName & ".txt"

        If Not File.Exists(strPathModeFile) Then Exit Sub
        arrSettings = Split(My.Computer.FileSystem.ReadAllText(strPathModeFile), "--")

        If rbRemux.Checked Then
            For Each arrSetting In arrSettings
                'check if audio track is listed in the existing settings file and if
                'it is then highlight the row to reflect the state
                If Strings.Left(LCase(arrSetting), 12) = "audio-tracks" Then
                    arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                    For Each info As DataGridViewRow In DataGridView2.Rows
                        If info.Cells(6).Value = arrTracks Then
                            info.Selected = True
                        End If
                    Next
                    'check if subtitle track is listed in the existing settings file and if
                    'it is then highlight the row to reflect the state
                ElseIf Strings.Left(LCase(Trim(arrSetting)), 15) = "subtitle-tracks" Then
                    arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                    For Each Track In arrTracks
                        For Each info As DataGridViewRow In DataGridView3.Rows
                            If info.Cells(6).Value = arrTracks Then
                                info.Selected = True
                            End If
                        Next
                    Next
                    'check if default track is listed in the existing settings file and if
                    'it is then set the appropriate checkbox
                    'Since a default track can be audio, video, or subtitle itterate
                    'through each datagrid
                    ' **** if the original default track is no longer default we have to figure out
                    ' how to deal with it ****
                ElseIf Strings.Left(LCase(arrSetting), 13) = "default-track" Then
                    arrTracks = Split(LCase(Trim(arrSetting)), " ")(1)
                    For Each info As DataGridViewRow In DataGridView1.Rows
                        If info.Cells(4).Value = arrTracks And info.Cells(3).Value = False Then
                            info.Cells(3).Value = True
                        End If
                    Next
                    For Each info As DataGridViewRow In DataGridView2.Rows
                        If info.Cells(6).Value = arrTracks And info.Cells(5).Value = False Then
                            info.Cells(5).Value = True
                        End If
                    Next
                    For Each info As DataGridViewRow In DataGridView3.Rows
                        If info.Cells(6).Value = arrTracks And info.Cells(4).Value = False Then
                            info.Cells(4).Value = True
                        End If
                    Next
                    'check if track order is different in the existing settings file and if
                    'it is then re-order the rows to reflect the change
                    ' **** I don't think this part works right now ****
                ElseIf Strings.Left(LCase(arrSetting), 11) = "track-order" Then
                    arrTracks = Replace(Split(LCase(Trim(arrSetting)), " ")(1), "0:", "")
                    Dim output(DataGridView2.Rows.Count - 1, DataGridView2.Columns.Count - 1)
                    Dim i As Integer = 0
                    For Each row As DataGridViewRow In DataGridView2.Rows
                        Dim j As Integer = 0
                        'For Each column In DataGridView2.Columns
                        'If row.IsNewRow Then Continue For
                        For Each cell As DataGridViewCell In row.Cells
                            output(i, j) = cell.Value.ToString
                            j += 1
                        Next
                        'Next
                        i += 1
                    Next

                    DataGridView2.Rows.Clear()
                    ReDim arrDetails(UBound(output, 2))
                    For Each Track In arrTracks
                        For i = 0 To UBound(output)
                            If output(i, 6) = Track Then
                                For j = 0 To UBound(output, 2)
                                    arrDetails(j) = output(i, j).ToString
                                Next
                                RepopulateInfo(arrDetails, "Audio", output(i, 6))
                            End If
                        Next i
                    Next
                    For Each info As DataGridViewRow In DataGridView2.Rows
                        info.Selected = True
                    Next
                End If
            Next
            'This section is for dealing with transcode settings
            ' **** Not yet verified ****
        Else
            For Each arrSetting In arrSettings
                If arrSetting = "eac3 " Then
                    DataGridView5.Rows(0).Cells(1).Value = "eac3"
                ElseIf arrSetting = "all-eac3 " Then
                    For Each row In DataGridView5.Rows
                        row.cells(1).value = "eac3"
                    Next
                ElseIf Strings.Left(arrSetting, 10) = "main-audio" Then
                    If Strings.Right(arrSetting, 9) = "surround " Then
                        DataGridView5.Rows(0).Cells(2).Value = "Surround"
                    ElseIf Strings.Right(arrSetting, 7) = "stereo " Then
                        DataGridView5.Rows(0).Cells(2).Value = "Stereo"
                    End If
                ElseIf Strings.Left(arrSetting, 9) = "add-audio" Then
                    If Strings.Right(arrSetting, 9) = "original " Then
                        With DataGridView5.Rows(Mid(arrSetting, InStr(arrSetting, "=") - 1, 1) - 1)
                            .Cells(1).Value = "Keep"
                            .Cells(2).Value = "Keep"
                            .Cells(3).Value = "Keep"
                        End With
                    ElseIf Strings.Right(arrSetting, 7) = "stereo " Then
                        DataGridView5.Rows(Mid(arrSetting, InStr(arrSetting, "=") - 1, 1)).Cells(2).Value = "Stereo"
                    ElseIf Strings.Right(arrSetting, 9) = "surround " Then
                        DataGridView5.Rows(Mid(arrSetting, InStr(arrSetting, "=") - 1, 1)).Cells(2).Value = "Surround"
                    End If
                ElseIf arrSetting = "hevc " Then
                    DataGridView4.Rows(0).Cells(2).Value = "hevc"
                ElseIf Strings.Left(arrSetting, 14) = "burn-subtitle " Then
                    DataGridView6.Rows(Mid(arrSetting, InStr(arrSetting, " ") + 1, 1) - 1).Cells(1).Value = True
                End If
            Next

        End If

    End Sub

    Function GetStreamCount(FileName)
        'Get the number of streams inside the file that has been selected
        ' **** not sure why we need this maybe further in the commenting phase I'll understand why ****
        GetStreamCount = 0
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(My.Settings.ffprobe_Path, " -show_entries format=nb_streams -v 0 -of compact=p=0:nk=1 " & Chr(34) & FileName & Chr(34)) With {
            .CreateNoWindow = True,
            .UseShellExecute = False,
            .RedirectStandardOutput = True
        }
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            'Do While Not oStreamReader.EndOfStream
            GetStreamCount = oStreamReader.ReadToEnd()
            'Loop
        End Using
    End Function

    Sub RepopulateInfo(ByRef Arr(), ByRef strType, strTrack)
        Dim i
        Dim strName = Nothing
        Dim strWidth
        Dim strHeight = Nothing
        Dim strFPS = Nothing
        Dim strChannelLayout = Nothing
        Dim strBitRate
        Dim strLanguage = Nothing
        Dim strTitle = Nothing
        Dim strNumberOfFrames = Nothing
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
                    .Rows(DGR).Cells(0).Value = strName
                    .Rows(DGR).Cells(1).Value = strHeight & "p"
                    .Rows(DGR).Cells(2).Value = strFPS
                    .Rows(DGR).Cells(3).Value = blnDefault
                End With

            Case "Audio"
                strName = Arr(0)
                strChannelLayout = Arr(1)
                strBitRate = Arr(2)
                strLanguage = Arr(3)
                strTitle = Arr(4)
                blnDefault = Arr(5)
                strTrack = Arr(6)
                Dim DGR As Integer = DataGridView2.Rows.Add
                With DataGridView2
                    .Rows(DGR).Cells(0).Value = strName
                    .Rows(DGR).Cells(1).Value = strChannelLayout
                    .Rows(DGR).Cells(2).Value = strBitRate
                    .Rows(DGR).Cells(3).Value = strLanguage
                    .Rows(DGR).Cells(4).Value = strTitle
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
                    .Rows(DGR).Cells(2).Value = strNumberOfFrames
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

    End Sub

    Sub FormatInfo(ByRef Arr(), ByRef strType, strTrack, strMode)
        'formats the stream into the datagrid of the appropriate type
        'input is everything ffprobe can return
        ' **** might be smarter to break this into 3 subs; Video, Audio, and Subtitle for readability ****
        Dim i
        Dim strName = Nothing
        Dim strWidth
        Dim strHeight = Nothing
        Dim strFPS = Nothing
        Dim strChannelLayout = Nothing
        Dim strBitRate = Nothing
        Dim strLanguage = Nothing
        Dim strTitle = Nothing
        Dim strNumberOfFrames = Nothing
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
                        Case "index"
                            strTrack = arrStream(i, 1)
                    End Select
                Next
                If strMode = "Remux" Then
                    Dim DGR As Integer = DataGridView1.Rows.Add
                    With DataGridView1
                        .Rows(DGR).Cells(0).Value = strName
                        .Rows(DGR).Cells(1).Value = strHeight & "p"
                        .Rows(DGR).Cells(2).Value = strFPS
                        .Rows(DGR).Cells(3).Value = blnDefault
                        .Rows(DGR).Cells(4).Value = strTrack
                    End With
                ElseIf strMode = "Create" Then
                    Dim DGR As Integer = DataGridView4.Rows.Add
                    With DataGridView4
                        .Columns(1).ToolTipText = "Changing Resolution Not Currently Supported"
                        .Columns(3).ToolTipText = "Changing Frame Rate Not Currently Supported"
                        .Rows(DGR).Cells(0).Value = strName & " / " & strHeight & "p" & " / " & strFPS
                    End With
                End If
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
                If strMode = "Remux" Then
                    Dim DGR As Integer = DataGridView2.Rows.Add
                    With DataGridView2
                        .Rows(DGR).Cells(0).Value = strName
                        .Rows(DGR).Cells(1).Value = strChannelLayout
                        .Rows(DGR).Cells(2).Value = strBitRate
                        .Rows(DGR).Cells(3).Value = strLanguage
                        .Rows(DGR).Cells(4).Value = strTitle
                        .Rows(DGR).Cells(5).Value = blnDefault
                        .Rows(DGR).Cells(6).Value = strTrack
                    End With
                ElseIf strMode = "Create" Then
                    Dim DGR As Integer = DataGridView5.Rows.Add
                    With DataGridView5
                        .Rows(DGR).Cells(0).Value = strName & " / " & strChannelLayout & " / " & strBitRate & " / " & strTitle & " / " & strLanguage
                        AddContextMenu()
                    End With
                End If
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
                If strMode = "Remux" Then
                    Dim DGR As Integer = DataGridView3.Rows.Add
                    With DataGridView3
                        .Rows(DGR).Cells(0).Value = strName
                        .Rows(DGR).Cells(1).Value = strLanguage
                        .Rows(DGR).Cells(2).Value = strNumberOfFrames
                        .Rows(DGR).Cells(3).Value = strTitle
                        .Rows(DGR).Cells(4).Value = blnDefault
                        .Rows(DGR).Cells(5).Value = blnForced
                        .Rows(DGR).Cells(6).Value = strTrack
                    End With
                ElseIf strMode = "Create" Then
                    Dim DGR As Integer = DataGridView6.Rows.Add
                    With DataGridView6
                        .Rows(DGR).Cells(0).Value = strName & " / " & strNumberOfFrames & " / " & blnForced.ToString & " / " & If(strTitle = "", "-", strTitle)
                    End With
                End If
        End Select

        If Arr.Contains("codec_type=video") Then
            arrStream = SplitArray(Arr)
            Dim z = 0
        End If

    End Sub

    Function SplitArray(ByRef Arr())
        'take the stream and convert each arraypoint and split it into the
        'two parts or the point
        Dim i
        Dim arrTemp
        Dim arrStream(Arr.Length - 1, 1)

        For i = 0 To Arr.Length - 1
            If InStr(Arr(i), "=") Then
                arrTemp = Split(Arr(i), "=")
                'On Error Resume Next
                arrStream(i, 0) = arrTemp(0)
                arrStream(i, 1) = arrTemp(1)
            Else
                arrStream(i, 0) = Arr(i)
            End If
        Next i
        SplitArray = arrStream
    End Function

    Private Sub ClassMyTreeView1_BeforeCollapse(sender As Object, e As TreeViewEventArgs)
        If e.Action = TreeViewAction.Collapse Then
            CleanUp()

        End If
    End Sub

    Private Sub ProcessAfterSelect(FileName, strMode)
        'A file has been selected from the treeview now we have to look at it see what items
        'are in the file and populate the grids
        Dim i
        Dim intCount As Integer
        Dim oProcess As New Process()
        'put together full filepath that is going to be evaluated
        Dim strFileName = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & FileName
        intCount = GetStreamCount(strFileName)
        Dim oStartInfo As New ProcessStartInfo(My.Settings.ffprobe_Path, " -loglevel quiet -show_streams -print_format csv=nokey=0 " & Chr(34) & strFileName & Chr(34)) With {
            .CreateNoWindow = True,
            .UseShellExecute = False,
            .RedirectStandardOutput = True
        }
        oProcess.StartInfo = oStartInfo
        ToolStripStatusLabel1.Text = "Working"
        oProcess.Start()
        ToolStripStatusLabel1.Text = ""
        Dim arrDetails(intCount - 1)

        i = 0
        'read the details of each stream into a 2d array
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            Do While Not oStreamReader.EndOfStream
                arrDetails(i) = Split(oStreamReader.ReadLine, ",")
                If Strings.Left(arrDetails(i)(0), 6) = "stream" Then
                    i += 1
                End If
            Loop
        End Using

        For i = 0 To UBound(arrDetails)
            'determine what type of stream this is and populate the appropriate datagrid
            Dim arrStream() As String
            arrStream = arrDetails(i)
            Dim lReturn As String = Array.Find(arrStream, Function(x) (x.StartsWith("codec_type")))
            Select Case lReturn
                Case "codec_type=video"
                    FormatInfo(arrDetails(i), "Video", i, strMode)
                Case "codec_type=audio"
                    FormatInfo(arrDetails(i), "Audio", i, strMode)
                Case "codec_type=subtitle"
                    FormatInfo(arrDetails(i), "Subtitle", i, strMode)
            End Select
        Next
    End Sub

    Private Sub CleanUp()
        'Resets DataGrid Rows for new entries
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()
        DataGridView4.Rows.Clear()
        DataGridView5.Rows.Clear()
        DataGridView6.Rows.Clear()
    End Sub

    Private Sub BtnMPV_Click(sender As Object, e As EventArgs) Handles btnMPV.Click
        Dim strText As String
        If ClassMyTreeView1.GetNodeCount(False) = 0 Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Title Selected", vbExclamation, "Error")
            End Using
            Exit Sub
        ElseIf ClassMyTreeView1.SelectedNode Is Nothing Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Title Selected", vbExclamation, "Error")
            End Using
            Exit Sub
        Else
            If Not ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & ClassMyTreeView1.SelectedNode.Parent.Name & ".mkv"
            Else
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & ".mkv"
            End If
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo(My.Settings.MPV_Path, " -- " & Chr(34) & strText & Chr(34)) With {
                .UseShellExecute = True
            }
            oProcess.StartInfo = oStartInfo
            oProcess.Start()
        End If
    End Sub

    Private Sub BtnSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnSubtitleEdit.Click
        Dim strText
        If ClassMyTreeView1.GetNodeCount(False) = 0 Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Title Selected", vbExclamation, "Error")
            End Using
            Exit Sub
        Else
            If ClassMyTreeView1.SelectedNode.Parent IsNot Nothing Then
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & ClassMyTreeView1.SelectedNode.Parent.Name & ".mkv"
            Else
                strText = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & ClassMyTreeView1.SelectedNode.Text & ".mkv"
            End If
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo(My.Settings.SubtitleEdit_Path, Chr(34) & strText & Chr(34)) With {
                .UseShellExecute = True
            }
            oProcess.StartInfo = oStartInfo
            oProcess.Start()
        End If
    End Sub

    Private Sub RbRemux_CheckedChanged(sender As Object, e As EventArgs) Handles rbRemux.CheckedChanged
        ValidateButtons(sender.text, sender.checked)
    End Sub
    Private Sub ValidateButtons(strSource As String, State As Boolean)
        'Takes input that can be Load, Remux, or Transcode then adjusts the form
        'so that the appropriate buttons and grids are loaded.
        Dim blnRemux As Boolean

        If strSource = "Load" Then
            blnRemux = rbRemux.Checked
            strSource = "Remux"

            Select Case strSource
                Case "Transcode"
                    ClassMyTreeView1.Nodes.Clear()
                    lbxDirectory.Items.Clear()
                    tbxOutputDirectory.Clear()
                    txtInputDirectory.Clear()
                    RunRemuxToolStripMenuItem.Text = "Run Transcode"
                    CleanUp()
                    With btnMPV
                        .Enabled = False
                        .Visible = False
                    End With
                    With btnSubtitleEdit
                        .Enabled = False
                        .Visible = False
                    End With
                    With Button1
                        .Enabled = False
                        .Visible = False
                    End With
                    With btnSaveRemux
                        .Enabled = False
                        .Visible = False
                    End With
                    With btnTranscode
                        .Enabled = True
                        .Visible = True
                    End With

                    'Hide Remux grids
                    With DataGridView1
                        .Enabled = False
                        .Visible = False
                    End With
                    With DataGridView2
                        .Enabled = False
                        .Visible = False
                    End With
                    With DataGridView3
                        .Enabled = False
                        .Visible = False
                    End With

                    'Show Transcode grids
                    With DataGridView4
                        .Enabled = True
                        .Visible = True
                    End With
                    With DataGridView5
                        .Enabled = True
                        .Visible = True
                    End With
                    With DataGridView6
                        .Enabled = True
                        .Visible = True
                    End With
                Case "Remux"
                    ClassMyTreeView1.Nodes.Clear()
                    lbxDirectory.Items.Clear()
                    tbxOutputDirectory.Clear()
                    txtInputDirectory.Clear()
                    RunRemuxToolStripMenuItem.Text = "Run Remux"
                    CleanUp()
                    With btnMPV
                        .Enabled = True
                        .Visible = True
                    End With
                    With btnSubtitleEdit
                        .Enabled = True
                        .Visible = True
                    End With
                    With Button1
                        .Enabled = True
                        .Visible = True
                    End With
                    With btnSaveRemux
                        .Enabled = True
                        .Visible = True
                    End With
                    With btnTranscode
                        .Enabled = False
                        .Visible = False
                    End With

                    'Show Remux grids
                    With DataGridView1
                        .Enabled = True
                        .Visible = True
                    End With
                    With DataGridView2
                        .Enabled = True
                        .Visible = True
                    End With
                    With DataGridView3
                        .Enabled = True
                        .Visible = True
                    End With

                    'Hide Transcode grids
                    With DataGridView4
                        .Enabled = False
                        .Visible = False
                    End With
                    With DataGridView5
                        .Enabled = False
                        .Visible = False
                    End With
                    With DataGridView6
                        .Enabled = False
                        .Visible = False
                    End With
            End Select
        End If
    End Sub

    Private Sub BtnSaveRemux_Click(sender As Object, e As EventArgs) Handles btnSaveRemux.Click
        'Deals with the button click for saving the remux settings 
        Dim strString
        'validate that a output directory is selected otherwise advise the user
        'that they need to select one
        If tbxOutputDirectory.Text = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Output Directory Chosen. Save Cancelled.", vbOKOnly, "Error")
            End Using
            Exit Sub
        End If
        strString = CreateCommandSettingsString()
        'if the settings file already exists and the user chooses not to overwrite
        'then an abort is returned to prevent and changes
        If strString = "Abort" Then
            Exit Sub
        End If
        SaveRemuxFile(strString)

    End Sub

    Private Function CreateCommandSettingsString()
        Dim strDefaultVideo
        Dim strDefaultAudio = Nothing
        Dim strDefaultSubtitle = Nothing
        Dim strVideo
        Dim strAudio = Nothing
        Dim strSubtitle = Nothing
        Dim strPathCommand As String
        Dim strPathCommandMovie As String
        Dim strFileName
        Dim strTrackOrder As String
        Dim arrTrackOrder
        Dim strForcedTrack

        'set paths
        If rbRemux.Checked Then
            strPathCommand = txtInputDirectory.Text & "\Remux"
        Else
            strPathCommand = txtInputDirectory.Text & "\Transcode"
        End If
        strPathCommandMovie = txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem

        'check for selected audio tracks
        If rbRemux.Checked Then
            'Deal with video tracks
            'Currently there is only one video track per title so there is no need for real processing
            strDefaultVideo = "--default-track 0"
            strVideo = "--Video-tracks 0"

            'Deal with Audio Tracks
            Dim arraylist As ArrayList = New ArrayList()
            For i = 0 To DataGridView2.SelectedRows.Count - 1
                arraylist.Insert(0, DataGridView2.SelectedRows(i))
            Next
            If arraylist.Count = 0 Then
                Using New Centered_MessageBox(Me)
                    MsgBox("No audio track selected. Aborting", vbOKOnly, "Error")
                End Using
                CreateCommandSettingsString = "Abort"
                Exit Function
            End If
            For Each objItem As DataGridViewRow In arraylist 'Audio tracks
                If objItem.Cells(5).Value = "True" Then
                    strDefaultAudio = "--default-track " & objItem.Cells(6).Value
                End If
                strAudio = AudioRemuxString(strAudio, objItem.Cells(6).Value)
            Next

            'check if the audio tracks are in a different order
            strTrackOrder = Replace(Split(strAudio, " ")(1), ",", "")
            If Not IsAlphabaticOrder(strTrackOrder) Then
                arrTrackOrder = Split(Split(strAudio, " ")(1), ",")
                strTrackOrder = "--track-order 0:0,"
                For i = 0 To UBound(arrTrackOrder)
                    strTrackOrder = strTrackOrder & "0:" & arrTrackOrder(i) & ","
                Next
                If Strings.Right(strTrackOrder, 1) = "," Then
                    strTrackOrder = Strings.Left(strTrackOrder, Len(strTrackOrder) - 1)
                End If
            Else
                strTrackOrder = ""
            End If
            'Deal with Subtitle and forced Tracks
            For Each objItem As DataGridViewRow In DataGridView3.SelectedRows 'Subtitle tracks
                If objItem.Cells(4).Value = True Then
                    strDefaultSubtitle = "--default-track " & objItem.Cells(6).Value
                End If
                If objItem.Cells(5).Value = True Then
                    strForcedTrack = "--forced-track " & objItem.Cells(6).Value
                End If
                strSubtitle = SubtitleRemuxString(strSubtitle, objItem.Cells(6).Value)
            Next

            'create the proper file name
            If ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
                strFileName = ClassMyTreeView1.SelectedNode.Text & ".mkv"
            Else
                strFileName = ClassMyTreeView1.SelectedNode.Text & "-" & LCase(ClassMyTreeView1.SelectedNode.Parent.Name) & ".mkv"
            End If

            'create the contents of the file
            ' **** there are issues here because some items may by blank and should not be added ****
            If strTrackOrder <> "" Then
                CreateCommandSettingsString = My.Settings.MKVMerge_Path & " --output " & Chr(34) & tbxOutputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & strFileName & Chr(34) & " --title " & Chr(34) & Chr(34) & " " & strDefaultVideo & " " _
                & strDefaultAudio & " " & strDefaultSubtitle & " " & strAudio & " " & strTrackOrder & " " & strSubtitle & " " & strForcedTrack & " " & My.Settings.MKVMerge_options & " " _
                & Chr(34) & strPathCommandMovie & "\" & strFileName & Chr(34)

            Else
                CreateCommandSettingsString = My.Settings.MKVMerge_Path & " --output " & Chr(34) & tbxOutputDirectory.Text & "\" & lbxDirectory.SelectedItem & "\" & strFileName & Chr(34) & " --title " & Chr(34) & Chr(34) & " " & strDefaultVideo & " " _
                & strDefaultAudio & " " & strDefaultSubtitle & " " & strAudio & " " & strSubtitle & " " & strForcedTrack & " " & My.Settings.MKVMerge_options & " " _
                & Chr(34) & strPathCommandMovie & "\" & strFileName & Chr(34)
            End If

        ElseIf rbCreate.Checked Then
            Dim arraylist As ArrayList = New ArrayList()
            Dim strResolution As String
            Dim strOutputFormat As String = ""
            Dim strFrameRate As String
            Dim strCodec As Object = ""
            Dim strWidth As Object
            Dim strBitRate As Object
            Dim strDTS As Integer
            Dim i
            Dim strOptions As String = My.Settings.othertranscode_Options

            'Deal with video tracks
            For i = 0 To DataGridView4.Rows.Count - 1
                arraylist.Insert(0, DataGridView4.Rows(i))
            Next
            For Each objItem As DataGridViewRow In arraylist 'Video tracks
                strResolution = objItem.Cells(1).Value
                If objItem.Cells(2).Value = "hevc" Then strOutputFormat = "--hevc "
                strFrameRate = objItem.Cells(3).Value
            Next

            'Deal with Audio Tracks
            arraylist = New ArrayList()
            For i = DataGridView5.Rows.Count - 1 To 0 Step -1
                arraylist.Insert(0, DataGridView5.Rows(i))
            Next
            i = 1
            For Each objItem As DataGridViewRow In arraylist 'Audio tracks
                strCodec = objItem.Cells(1).Value
                strWidth = objItem.Cells(2).Value
                strBitRate = objItem.Cells(3).Value
                strDTS = InStr(objItem.Cells(0).Value, "dts (DTS")

                If strCodec = "Keep" And strWidth = "Keep" And strBitRate = "Keep" Then strWidth = "original"
                If i = 1 Then
                    strAudio = "--main-audio 1=" & LCase(strWidth) & " "
                Else
                    strAudio = strAudio & "--add-audio " & i & "=" & LCase(strWidth) & " "
                End If
                If strCodec = "eac3" Then strOptions = My.Settings.othertranscode_Options & "--eac3 "
                i += 1
            Next

            'Deal with Subtitle Tracks
            i = 1
            For Each objItem As DataGridViewRow In DataGridView6.Rows 'Subtitle tracks
                If objItem.Cells(1).Value = True Then
                    'burn subtitle
                    If strSubtitle = "" Then
                        strSubtitle = "--burn-subtitle " & i & " "
                    Else
                        strSubtitle &= "--burn-subtitle " & i & " "
                    End If
                Else
                    'add subtitle
                    If strSubtitle = "" Then
                        strSubtitle = "--add-subtitle " & i & " "
                    Else
                        strSubtitle = strSubtitle & "--add-subtitle " & i & " "
                    End If
                End If
                i += 1
            Next

            'create the proper file name
            If strDTS <> 0 And strCodec = "Keep" Then
                If strOptions = "" Then
                    strOptions = My.Settings.othertranscode_Options
                Else
                    strOptions &= "--pass-dts "
                End If
            End If
            If ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
                strFileName = ClassMyTreeView1.SelectedNode.Text & ".mkv"
            Else
                strFileName = ClassMyTreeView1.SelectedNode.Text & "-" & LCase(ClassMyTreeView1.SelectedNode.Parent.Name) & ".mkv"
            End If

            CreateCommandSettingsString = My.Settings.othertranscode_Path & " " & strOptions & If(strOutputFormat, "") & strAudio & strSubtitle _
                  & Chr(34) & strPathCommandMovie & "\" & strFileName & Chr(34)
        Else
            CreateCommandSettingsString = "Error"
        End If
    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim box = New AboutBox1()
        box.ShowDialog()
    End Sub

    Sub SaveRemuxFile(strCommand)
        Dim lResult
        Dim strPathFolder As String
        Dim strPathFolderMovie As String
        Dim strPathFolderFile As String
        Dim strProcess As String

        If rbRemux.Checked Then
            strPathFolder = txtInputDirectory.Text & "\Remux"
            strProcess = "Remux"
        ElseIf rbCreate.Checked Then
            strPathFolder = txtInputDirectory.Text & "\Transcode"
            strProcess = "Transcode"
        Else
            Using New Centered_MessageBox(Me)
                MsgBox("Error, Aborting Save", vbCritical, "Error")
            End Using
            Exit Sub
        End If

        strPathFolderMovie = strPathFolder & "\" & lbxDirectory.SelectedItem
        If ClassMyTreeView1.SelectedNode.Parent Is Nothing Then
            strPathFolderFile = strPathFolderMovie & "\" & ClassMyTreeView1.SelectedNode.Text & ".txt"
        Else
            strPathFolderFile = strPathFolderMovie & "\" & ClassMyTreeView1.SelectedNode.Text & "-" & LCase(ClassMyTreeView1.SelectedNode.Parent.Text) & ".txt"
        End If

        'check for "Remux" or "Transcode" folder and create if needed
        If Not Directory.Exists(strPathFolder) Then
            Directory.CreateDirectory(strPathFolder)
        End If

        'check for movie folder and create if needed
        If Not Directory.Exists(strPathFolderMovie) Then
            Directory.CreateDirectory(strPathFolderMovie)
        End If

        'check for existing settings and ask to overwrite if needed
        If File.Exists(strPathFolderFile) Then
            Using New Centered_MessageBox(Me)
                lResult = MsgBox(strProcess & " Settings Already Exist. Overwrite", vbYesNo, strProcess & " Settings")
            End Using
            If lResult = vbYes Then
                'create file and save settings
                Dim ObjFS As FileStream = File.Create(strPathFolderFile)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(strCommand) 'here is where the text goes
                ObjFS.Write(info, 0, info.Length)
                ObjFS.Close()
            ElseIf vbNo Then
                'cancel the save
            End If
        Else
            Dim ObjFS As FileStream = File.Create(strPathFolderFile)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(strCommand) 'here is where the text goes
            ObjFS.Write(info, 0, info.Length)
            ObjFS.Close()
            ClassMyTreeView1.SelectedNode.BackColor = Color.Green

        End If
    End Sub

    Function AudioRemuxString(strAudio, Item)
        'create the string for audio tracks that are selected
        If strAudio = "" Then
            strAudio = "--audio-tracks " & Item
        Else
            strAudio = strAudio & "," & Item
        End If
        AudioRemuxString = strAudio
    End Function

    Function SubtitleRemuxString(strSubtitle, Item)
        'create the string for subtitle tracks that are selected
        If strSubtitle = "" Then
            strSubtitle = "--subtitle-tracks " & Item
        Else
            strSubtitle = strSubtitle & "," & Item
        End If
        SubtitleRemuxString = strSubtitle
    End Function

    Function CheckSettingsFile(strFileName)
        'Chacks for the existance of a settings file that has already been
        'created and returns true or false
        Dim strPathMode As String
        Dim strPathModeMovie As String
        Dim strPathModeFile As String

        If rbRemux.Checked Then
            strPathMode = txtInputDirectory.Text & "\Remux"
        Else
            strPathMode = txtInputDirectory.Text & "\Transcode"
        End If
        strPathModeMovie = strPathMode & "\" & lbxDirectory.SelectedItem
        strPathModeFile = strPathModeMovie & "\" & strFileName & ".txt"

        If File.Exists(strPathModeFile) Then
            CheckSettingsFile = True
        Else
            CheckSettingsFile = False
        End If

    End Function

    Private Sub BtnOutputDirectory_Click(sender As Object, e As EventArgs) Handles btnOutputDirectory.Click
        Dim objFSO As Object

        objFSO = CreateObject("Scripting.FileSystemObject")

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            tbxOutputDirectory.Text = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

    End Sub

    '---------------------Drag and Drop for DataGridView------------------------
    Private Sub DataGridView2_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView2.DragDrop
        Dim p As Point = DataGridView2.PointToClient(New Point(e.X, e.Y))
        dragIndex = DataGridView2.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
            If dragIndex < 0 Then Exit Sub
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
    '---------------------End Drag and Drop for DataGridView--------------------
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start(Chr(34) & txtInputDirectory.Text & "\" & lbxDirectory.SelectedItem & Chr(34))
    End Sub

    Private Sub RunRemuxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunRemuxToolStripMenuItem.Click
        If txtInputDirectory.Text = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Input Directory Chosen", vbExclamation, "Error")
            End Using
            Exit Sub
        End If
        If tbxOutputDirectory.Text = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Output Directory Chosen", vbExclamation, "Error")
            End Using
            Exit Sub
        End If

        Dim box = New RunRemux()
        box.ShowDialog()
    End Sub

    Private Shared Function IsAlphabaticOrder(ByVal s As String) As Boolean
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

    Private Sub RbCreate_CheckedChanged(sender As Object, e As EventArgs) Handles rbCreate.CheckedChanged
        ValidateButtons(sender.text, sender.checked)
    End Sub

    Private Sub BtnTranscode_Click(sender As Object, e As EventArgs) Handles btnTranscode.Click
        Dim strString
        If tbxOutputDirectory.Text = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("No Output Directory Chosen. Save Cancelled.", vbOKOnly, "Error")
            End Using
            Exit Sub
        End If
        strString = CreateCommandSettingsString()
        SaveRemuxFile(strString)
    End Sub

    Private toolStripItem1 As ToolStripMenuItem = New ToolStripMenuItem()

    Private Sub AddContextMenu()
        toolStripItem1.Text = "Copy Track"
        AddHandler toolStripItem1.Click, New EventHandler(AddressOf ToolStripItem1_Click)
        Dim strip As ContextMenuStrip = New ContextMenuStrip()

        For Each row As DataGridViewRow In DataGridView5.Rows
            row.ContextMenuStrip = strip
            row.ContextMenuStrip.Items.Add(toolStripItem1)
        Next
    End Sub

    Private mouseLocation As DataGridViewCellEventArgs

    Private Sub ToolStripItem1_Click(ByVal sender As Object, ByVal args As EventArgs)
        With DataGridView5.Rows(mouseLocation.RowIndex)
            .Cells(1).Value = "Keep"
            .Cells(2).Value = "Keep"
            .Cells(3).Value = "Keep"
        End With
    End Sub

    Private Sub DataGridView5_CellMouseEnter(ByVal sender As Object, ByVal location As DataGridViewCellEventArgs) Handles DataGridView5.CellMouseEnter
        mouseLocation = location
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        Dim box = New UserPreferences()
        box.ShowDialog()
    End Sub

End Class