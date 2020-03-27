Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
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

Class Centered_MessageBox
    Implements IDisposable
    Private mTries As Integer = 0
    Private mOwner As Form

    Public Sub New(owner As Form)
        mOwner = owner
        owner.BeginInvoke(New MethodInvoker(AddressOf FindDialog))
    End Sub

    Private Sub FindDialog()
        ' Enumerate windows to find the message box
        If mTries < 0 Then
            Return
        End If
        Dim callback As New EnumThreadWndProc(AddressOf CheckWindow)
        If EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero) Then
            If System.Threading.Interlocked.Increment(mTries) < 10 Then
                mOwner.BeginInvoke(New MethodInvoker(AddressOf FindDialog))
            End If
        End If
    End Sub
    Private Function CheckWindow(hWnd As IntPtr, lp As IntPtr) As Boolean
        ' Checks if <hWnd> is a dialog
        Dim sb As New StringBuilder(260)
        GetClassName(hWnd, sb, sb.Capacity)
        If sb.ToString() <> "#32770" Then
            Return True
        End If
        ' Got it
        Dim frmRect As New Rectangle(mOwner.Location, mOwner.Size)
        Dim dlgRect As RECT
        GetWindowRect(hWnd, dlgRect)
        MoveWindow(hWnd, frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) \ 2, frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) \ 2, dlgRect.Right - dlgRect.Left, dlgRect.Bottom - dlgRect.Top, True)
        Return False
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        mTries = -1
    End Sub

    ' P/Invoke declarations
    Private Delegate Function EnumThreadWndProc(hWnd As IntPtr, lp As IntPtr) As Boolean
    <DllImport("user32.dll")>
    Private Shared Function EnumThreadWindows(tid As Integer, callback As EnumThreadWndProc, lp As IntPtr) As Boolean
    End Function
    <DllImport("kernel32.dll")>
    Private Shared Function GetCurrentThreadId() As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetClassName(hWnd As IntPtr, buffer As StringBuilder, buflen As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetWindowRect(hWnd As IntPtr, ByRef rc As RECT) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function MoveWindow(hWnd As IntPtr, x As Integer, y As Integer, w As Integer, h As Integer, repaint As Boolean) As Boolean
    End Function
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    'usage of function
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Using New Centered_MessageBox(Me)
    '        MessageBox.Show("Test Text", "Test Title", MessageBoxButtons.OK)
    '    End Using
    'End Sub

End Class