Public Class frmGradeEnrolled

    Public IsDirty As Boolean = False
    Public m_Course As Integer = -1
    Public m_Subject As Integer = -1
    Public studentPK As Integer = -1

    Public Sub LoadCombo()
        'TODO: This line of code loads data into the 'DsSchool.Semester' table. You can move, or remove it, as needed.
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        'TODO: This line of code loads data into the 'DsSchool.SchoolYear' table. You can move, or remove it, as needed.
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        
    End Sub

    'Save button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        

        'Validate and make numeric
        If Not IsNumeric(Me.cmbCreditGroup.Text) Then Me.cmbCreditGroup.Text = -1
        If Not IsNumeric(Me.txtUnits.Text) Then Me.txtUnits.Text = 0

        If Not IsNumeric(Me.txtCompletionGrade.Text) Then
            MsgBox("Only numeric grades are allowed.", MsgBoxStyle.Critical, "Error")
            txtCompletionGrade.Select()
            Exit Sub
        End If


        If m_Subject <= 0 Then
            MsgBox("Please select a subject.", MsgBoxStyle.Critical, "Error")
            btnSelectSubject.Select()
            Exit Sub
        End If

        If CDbl(txtUnits.Text) < 0 Then
            MsgBox("Please put a non-zero value in Credited Units.", MsgBoxStyle.Critical, "Error")
            txtUnits.Select()
            Exit Sub
        End If

        'alert on zero units, but still allow it
        If CDbl(txtUnits.Text) = 0 Then
            If MsgBox("You put zero in the credited units. Is this correct? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                txtUnits.Select()
                Exit Sub
            End If
        End If

        If CInt(cmbCreditGroup.Text) < 0 Then
            MsgBox("Please put a non-zero value in Credit Group.", MsgBoxStyle.Critical, "Error")
            cmbCreditGroup.Select()
            Exit Sub
        End If

        If CInt(txtCompletionGrade.Text) < 0 Then
            MsgBox("Please put a non-zero value in Completion Grade.", MsgBoxStyle.Critical, "Error")
            txtCompletionGrade.Select()
            Exit Sub
        End If

        If CInt(txtCompletionGrade.Text) = 0 Then
            If MsgBox("You put zero in the completion grade. Is this correct? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                txtCompletionGrade.Select()
                Exit Sub
            End If
        End If

        Me.IsDirty = True


        Me.Hide()

    End Sub

    'choose course button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Course = frm.m_CoursePK
            Me.txtCourse.Text = frm.m_CourseName
            ''Me.m_Subject = -1
            ''Me.txtSubject.Text = ""
        End If
    End Sub
    'Choose subject button
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSubject.Click

        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()

        If frm.Selected Then

            Dim subjectGrade As String = clsTool.getStudentGrade(studentPK, frm.m_SubjectID)
            If Not IsNumeric(subjectGrade) Then Exit Sub ''this is previous school subject

            'add code to check if subject chosen already has a grade
            If (CDbl(subjectGrade) < 5 And CDbl(subjectGrade) > 0) Then

                If MsgBox("A previous grade for this subject exists! Continue? ", MsgBoxStyle.OkCancel, "Cancel") = MsgBoxResult.Ok Then
                    Me.m_Subject = frm.m_SubjectID
                    Me.txtSubject.Text = clsTool.GetSubjectDescription(frm.m_SubjectID)
                End If

            Else
                Me.m_Subject = frm.m_SubjectID
                Me.txtSubject.Text = clsTool.GetSubjectDescription(frm.m_SubjectID)
            End If

            'set credit group automatically
            Dim cgroup As Integer = clsTool.GetSubjectCreditGroup(frm.m_SubjectID)
            If cgroup = -1 Then cgroup = 0
            cmbCreditGroup.Text = cgroup.ToString

        End If
    End Sub



    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class