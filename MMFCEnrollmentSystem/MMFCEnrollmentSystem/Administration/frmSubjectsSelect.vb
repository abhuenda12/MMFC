Public Class frmSubjectsSelect
    Public Selected As Boolean = False
    Public m_SubjectID As Integer = -1
    Public m_SubjectName As String = ""
    Private Sub frmSubjectsSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsSchool.Subjects' table. You can move, or remove it, as needed.
        Me.SubjectsByCNameTableAdapter.Fill(Me.DsSchool.SubjectsByCName, "%")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsSchool.SubjectsByCName.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        Selected = True
        Me.m_SubjectID = Me.DsSchool.SubjectsByCName(Me.SubjectsByCNameBindingSource.Position).SubjectPriKey
        Me.m_SubjectName = Me.DsSchool.SubjectsByCName(Me.SubjectsByCNameBindingSource.Position).SubjectName
        Me.Hide()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.SubjectsByCNameTableAdapter.Fill(Me.DsSchool.SubjectsByCName, TextBox1.Text & "%")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class