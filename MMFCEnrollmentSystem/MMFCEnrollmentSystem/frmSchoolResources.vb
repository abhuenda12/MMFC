Public Class frmSchoolResources
    Public IsDirty As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox2.Text) Then MsgBox("Name cannot be empty!") : Exit Sub
        IsDirty = True
        Me.Hide()
    End Sub
End Class