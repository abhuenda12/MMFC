Public Class frmSchoolYear

    Public isDirty As Boolean = False

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Me.TextBox1.Text) Then MsgBox("Please put School Year!") : Me.TextBox1.Focus() : Exit Sub
        If Not IsNumeric(Me.txtSortOrder.Text) Then MsgBox("Invalid sort order ! Please put positive integer.") : Exit Sub
        If CInt(Me.txtSortOrder.Text) < 1 Then MsgBox("Invalid sort order ! Please put positive integer.") : Exit Sub
        isDirty = True
        Me.Hide()
    End Sub

   
End Class