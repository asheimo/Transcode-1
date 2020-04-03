Public Class UserPreferences
    Private Sub UserPreferences_Load(sender As Object, e As EventArgs) Handles Me.Load
        'read user preferences and populate text boxes
        tbxPathMPV.Text = My.Settings.MPV_Path
        tbxPathSubtitleedit.Text = My.Settings.SubtitleEdit_Path
        tbxPathffmpeg.Text = My.Settings.ffmpeg_Path
        tbxPathffprobe.Text = My.Settings.ffprobe_Path
        tbxPathothertranscode.Text = My.Settings.othertranscode_Path
        tbxPathMKVPropEdit.Text = My.Settings.MKVPropEdit_Path
        tbxPathMKVMerge.Text = My.Settings.MKVMerge_Path
        tbxOtherTranscodeDefaults.Text = My.Settings.othertranscode_Defaults
        tbxMKVMergeDefaults.Text = My.Settings.MKVMerge_Defaults
    End Sub

    'try where for the path
    Private Sub btnWhereMPV_Click(sender As Object, e As EventArgs) Handles btnWhereMPV.Click
        tbxPathMPV.Text = RunCommandCom("Where", "MPV")
    End Sub

    Private Sub btnWhereSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnWhereSubtitleEdit.Click
        tbxPathSubtitleedit.Text = RunCommandCom("Where", "SubtitleEdit")
    End Sub

    Private Sub btnWhereFFMpeg_Click(sender As Object, e As EventArgs) Handles btnWhereFFMpeg.Click
        tbxPathffmpeg.Text = RunCommandCom("Where", "ffmpeg")
    End Sub

    Private Sub btnWhereFFProbe_Click(sender As Object, e As EventArgs) Handles btnWhereFFProbe.Click
        tbxPathffprobe.Text = RunCommandCom("Where", "ffprobe")
    End Sub

    Private Sub btnWhereOtherTranscode_Click(sender As Object, e As EventArgs) Handles btnWhereOtherTranscode.Click
        tbxPathothertranscode.Text = RunCommandCom("Where", "other-transcode")
    End Sub
    Private Sub btnWhereMKVPropEdit_Click(sender As Object, e As EventArgs) Handles btnWhereMKVPropEdit.Click
        tbxPathMKVPropEdit.Text = RunCommandCom("Where", "MKVPropEdit")
    End Sub

    Private Sub btnWhereMKVMerge_Click(sender As Object, e As EventArgs) Handles btnWhereMKVMerge.Click
        tbxPathMKVMerge.Text = RunCommandCom("Where", "MKVMerge")
    End Sub

    'get the file paths
    Private Sub btnPathMPV_Click(sender As Object, e As EventArgs) Handles btnPathMPV.Click
        tbxPathMPV.Text = GetFilePath()
    End Sub

    Private Sub btnPathSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnPathSubtitleEdit.Click
        tbxPathSubtitleedit.Text = GetFilePath()
    End Sub

    Private Sub btnPathFFMpeg_Click(sender As Object, e As EventArgs) Handles btnPathFFMpeg.Click
        tbxPathffmpeg.Text = GetFilePath()
    End Sub

    Private Sub btnPathFFProbe_Click(sender As Object, e As EventArgs) Handles btnPathFFProbe.Click
        tbxPathffprobe.Text = GetFilePath()
    End Sub

    Private Sub btnPathOtherTranscode_Click(sender As Object, e As EventArgs) Handles btnPathOtherTranscode.Click
        tbxPathothertranscode.Text = GetFilePath()
    End Sub
    Private Sub btnPathMKVPropEdit_Click(sender As Object, e As EventArgs) Handles btnPathMKVPropEdit.Click
        tbxPathMKVPropEdit.Text = GetFilePath()
    End Sub

    Private Sub btnMKVMerge_Click(sender As Object, e As EventArgs) Handles btnMKVMerge.Click
        tbxPathMKVMerge.Text = GetFilePath()
    End Sub

    'ok and cancel buttons
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.MPV_Path = tbxPathMPV.Text
        My.Settings.SubtitleEdit_Path = tbxPathSubtitleedit.Text
        My.Settings.ffmpeg_Path = tbxPathffmpeg.Text
        My.Settings.ffprobe_Path = tbxPathffprobe.Text
        My.Settings.othertranscode_Path = tbxPathothertranscode.Text
        My.Settings.MKVPropEdit_Path = tbxPathMKVPropEdit.Text
        My.Settings.MKVMerge_Path = tbxPathMKVMerge.Text
        My.Settings.othertranscode_Defaults = tbxOtherTranscodeDefaults.Text
        My.Settings.MKVMerge_Defaults = tbxMKVMergeDefaults.Text

        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'form functions and subs
    Private Function RunCommandCom(command As String, arguments As String, Optional permanent As Boolean = False)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments
        pi.CreateNoWindow = True
        pi.UseShellExecute = False
        pi.RedirectStandardOutput = True
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start()

        RunCommandCom = p.StandardOutput.ReadToEnd()
    End Function

    Private Function GetFilePath()
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Find Program Path"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            GetFilePath = fd.FileName
        Else
            GetFilePath = ""
            Exit Function
        End If
    End Function


End Class