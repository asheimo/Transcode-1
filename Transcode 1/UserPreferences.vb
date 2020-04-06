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
        tbxRobocopyDefaults.Text = My.Settings.RoboCopy_Defaults
        tbxothertranscodeoptions.Text = My.Settings.othertranscode_Options
        tbxMKVMergeOptions.Text = My.Settings.MKVMerge_options
        tbxPathRuby.Text = My.Settings.Ruby_Path

    End Sub

    'try where for the path
    Private Sub BtnWhereMPV_Click(sender As Object, e As EventArgs) Handles btnWhereMPV.Click
        tbxPathMPV.Text = RunCommandCom("Where", "MPV")
    End Sub

    Private Sub BtnWhereSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnWhereSubtitleEdit.Click
        tbxPathSubtitleedit.Text = RunCommandCom("Where", "SubtitleEdit")
    End Sub

    Private Sub BtnWhereFFMpeg_Click(sender As Object, e As EventArgs) Handles btnWhereFFMpeg.Click
        tbxPathffmpeg.Text = RunCommandCom("Where", "ffmpeg")
    End Sub

    Private Sub BtnWhereFFProbe_Click(sender As Object, e As EventArgs) Handles btnWhereFFProbe.Click
        tbxPathffprobe.Text = RunCommandCom("Where", "ffprobe")
    End Sub

    Private Sub BtnWhereOtherTranscode_Click(sender As Object, e As EventArgs) Handles btnWhereOtherTranscode.Click
        tbxPathothertranscode.Text = RunCommandCom("Where", "other-transcode")
    End Sub
    Private Sub BtnWhereMKVPropEdit_Click(sender As Object, e As EventArgs) Handles btnWhereMKVPropEdit.Click
        tbxPathMKVPropEdit.Text = RunCommandCom("Where", "MKVPropEdit")
    End Sub

    Private Sub BtnWhereMKVMerge_Click(sender As Object, e As EventArgs) Handles btnWhereMKVMerge.Click
        tbxPathMKVMerge.Text = RunCommandCom("Where", "MKVMerge")
    End Sub
    Private Sub BtnWhereRuby_Click(sender As Object, e As EventArgs) Handles btnWhereRuby.Click
        tbxPathRuby.Text = RunCommandCom("Where", "ruby")
    End Sub

    'get the file paths
    Private Sub BtnPathMPV_Click(sender As Object, e As EventArgs) Handles btnPathMPV.Click
        tbxPathMPV.Text = GetFilePath()
    End Sub

    Private Sub BtnPathSubtitleEdit_Click(sender As Object, e As EventArgs) Handles btnPathSubtitleEdit.Click
        tbxPathSubtitleedit.Text = GetFilePath()
    End Sub

    Private Sub BtnPathFFMpeg_Click(sender As Object, e As EventArgs) Handles btnPathFFMpeg.Click
        tbxPathffmpeg.Text = GetFilePath()
    End Sub

    Private Sub BtnPathFFProbe_Click(sender As Object, e As EventArgs) Handles btnPathFFProbe.Click
        tbxPathffprobe.Text = GetFilePath()
    End Sub

    Private Sub BtnPathOtherTranscode_Click(sender As Object, e As EventArgs) Handles btnPathOtherTranscode.Click
        tbxPathothertranscode.Text = GetFilePath()
    End Sub
    Private Sub BtnPathMKVPropEdit_Click(sender As Object, e As EventArgs) Handles btnPathMKVPropEdit.Click
        tbxPathMKVPropEdit.Text = GetFilePath()
    End Sub

    Private Sub BtnMKVMerge_Click(sender As Object, e As EventArgs) Handles btnMKVMerge.Click
        tbxPathMKVMerge.Text = GetFilePath()
    End Sub

    Private Sub BtnRuby_Click(sender As Object, e As EventArgs) Handles btnRuby.Click
        tbxPathRuby.Text = GetFilePath()
    End Sub

    'ok and cancel buttons
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.MPV_Path = tbxPathMPV.Text
        My.Settings.SubtitleEdit_Path = tbxPathSubtitleedit.Text
        My.Settings.ffmpeg_Path = tbxPathffmpeg.Text
        My.Settings.ffprobe_Path = tbxPathffprobe.Text
        My.Settings.othertranscode_Path = tbxPathothertranscode.Text
        My.Settings.MKVPropEdit_Path = tbxPathMKVPropEdit.Text
        My.Settings.MKVMerge_Path = tbxPathMKVMerge.Text
        My.Settings.othertranscode_Defaults = tbxOtherTranscodeDefaults.Text
        My.Settings.MKVMerge_Defaults = tbxMKVMergeDefaults.Text
        My.Settings.RoboCopy_Defaults = tbxRobocopyDefaults.Text
        My.Settings.othertranscode_Options = tbxothertranscodeoptions.Text
        My.Settings.MKVMerge_options = tbxMKVMergeOptions.Text
        My.Settings.Ruby_Path = tbxPathRuby.Text
        My.Settings.Save()

        If My.Settings.MPV_Path = "" Or
        My.Settings.SubtitleEdit_Path = "" Or
        My.Settings.ffmpeg_Path = "" Or
        My.Settings.ffprobe_Path = "" Or
        My.Settings.othertranscode_Path = "" Or
        My.Settings.MKVPropEdit_Path = "" Or
        My.Settings.MKVMerge_Path = "" Or
        My.Settings.Ruby_Path = "" Then
            Using New Centered_MessageBox(Me)
                MsgBox("Please Set All Paths", vbCritical, "Application Paths Missing")
            End Using
        Else
            Me.Close()
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'form functions and subs
    Private Function RunCommandCom(command As String, arguments As String, Optional permanent As Boolean = False)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo With {
            .Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments,
            .CreateNoWindow = True,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .FileName = "cmd.exe"
        }
        p.StartInfo = pi
        p.Start()

        RunCommandCom = p.StandardOutput.ReadLine()
    End Function

    Private Function GetFilePath()
        Dim fd As OpenFileDialog = New OpenFileDialog With {
            .Title = "Find Program Path",
            .InitialDirectory = "C:\",
            .Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            .FilterIndex = 2,
            .RestoreDirectory = True
        }

        If fd.ShowDialog() = DialogResult.OK Then
            GetFilePath = fd.FileName
        Else
            GetFilePath = ""
            Exit Function
        End If
    End Function

End Class