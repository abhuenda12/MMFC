Public Class frmCurriculum
    Public IsDirty As Boolean = False
    Public yrlevel As Integer = 1
    Public semester As Integer = 1
    Public subjectPK As Integer = -1

    Public Sub loadData()
        Me.SubjectsorderedbyNameTableAdapter.Fill(Me.DsSchool.SubjectsorderedbyName)
        Me.CoursesTableAdapter.Fill(Me.DsSchool.Courses)
    End Sub

    'SAVE button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Me.cmbCourse.SelectedValue) Then MsgBox("Please select a Course!") : Exit Sub
        If String.IsNullOrEmpty(Me.cmbYrLevel.Text) Then MsgBox("Please select a Year Level!") : Exit Sub
        If String.IsNullOrEmpty(Me.cmbSemester.Text) Then MsgBox("Please select a Semester!") : Exit Sub

        ''If String.IsNullOrEmpty(Me.cmbSubject.SelectedValue) Then MsgBox("Please select a Subject!") : Exit Sub
        If subjectPK = -1 Then MsgBox("Please select a Subject!") : Exit Sub

        If Me.txtRemarks.TextLength >= 100 Then Me.txtRemarks.Text = Me.txtRemarks.Text.Remove(99)

        'Year level interpretation
        Select Case Me.cmbYrLevel.Text.ToUpper
            Case "1ST"
                yrlevel = 1
            Case "2ND"
                yrlevel = 2
            Case "3RD"
                yrlevel = 3
            Case "4TH"
                yrlevel = 4
            Case "5TH"
                yrlevel = 5
            Case "6TH"
                yrlevel = 6
            Case Else
                MsgBox("Please select from year level options only.")
                Exit Sub
        End Select

        'Semester interpretation
        Select Case Me.cmbSemester.Text.ToUpper
            Case "FIRST"
                semester = 1
            Case "SECOND"
                semester = 2
            Case "SUMMER"
                semester = 3
            Case Else
                MsgBox("Please select semester from options only.")
                Exit Sub
        End Select

        Me.IsDirty = True
        Me.Hide()
    End Sub

    'choose subject
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.subjectPK = frm.m_SubjectID
            Me.txtSubjectName.Text = frm.m_SubjectName
        End If

    End Sub
End Class