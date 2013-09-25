Public Class frmAdjustments
    Public IsDirty As Boolean = False 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Me.txtRef.Text) Then MsgBox("Reference cannot be blank!") : Me.txtRef.Focus() : Exit Sub
        If String.IsNullOrEmpty(Me.txtAmount.Text) Then MsgBox("Invalid Amount!") : Me.txtAmount.Focus() : Exit Sub
        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid Amount!") : Me.txtAmount.SelectAll() : Me.txtAmount.Focus() : Exit Sub
        'Ben 2.9.2008 . Limit Ref to a number
        If Not IsNumeric(Me.txtRef.Text) Then MsgBox("Use Number as Reference") : Me.txtRef.SelectAll() : Me.txtRef.Focus() : Exit Sub
        IsDirty = True
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class