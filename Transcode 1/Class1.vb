Class ClassMyTreeView
    Inherits TreeView

    'Public Sub New()
    '    Me.DrawMode = TreeViewDrawMode.OwnerDrawText
    'End Sub

    'Protected Overrides Sub OnDrawNode(ByVal e As DrawTreeNodeEventArgs)
    '    Dim state As TreeNodeStates = e.State
    '    Dim font As Font = If(e.Node.NodeFont, e.Node.TreeView.Font)
    '    Dim fore As Color = e.Node.ForeColor
    '    If fore = Color.Empty Then fore = e.Node.TreeView.ForeColor

    '    If e.Node.IsSelected Then
    '        fore = SystemColors.HighlightText
    '        e.Graphics.FillRectangle(New SolidBrush(Color.Red), e.Bounds)
    '        ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, Color.Red)
    '        TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, Color.Red, TextFormatFlags.GlyphOverhangPadding)
    '    Else
    '        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds)
    '        TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding)
    '    End If
    'End Sub
End Class
