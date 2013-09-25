Public Class frmTeachersSelect
    Public Selected As Boolean = False
    Private Sub frmTeachersSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TeachersbyCNameTableAdapter.Fill(Me.DsSchool.TeachersbyCName, "%")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsSchool.TeachersbyCName.Rows.Count = 0 Then MsgBox("Nothing Selected!") : Exit Sub
        Selected = True
        Me.Hide()
    End Sub
    'ben10.16.2007
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TeachersbyCNameTableAdapter.Fill(Me.DsSchool.TeachersbyCName, "%" + Me.TextBox1.Text + "%")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class