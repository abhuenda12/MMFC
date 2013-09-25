Public Class frmCourseSubjectSelect
    Public IsSelected As Boolean = False
    Public m_Course As Integer = -1
    Public m_Subject As Integer = 1
 

    Public Sub LoadSubjects()
        Me.BlockSectionTuitionbyCourseTableAdapter.Fill(Me.DsRegistrar.BlockSectionTuitionbyCourse, Me.m_Course)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsRegistrar.BlockSectionTuitionbyCourse.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        m_Subject = Me.DsRegistrar.BlockSectionTuitionbyCourse(Me.BlockSectionTuitionbyCourseBindingSource.Position).subjectid
        Me.IsSelected = True
        Me.Hide()
    End Sub


    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If e.ColumnIndex = 1 Then
            e.Value = clsTool.GetSubjectDescription(Me.DsRegistrar.BlockSectionTuitionbyCourse(e.RowIndex).subjectid)
        End If
    End Sub
End Class