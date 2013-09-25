Public Class frmGradeManual
    Public IsDirty As Boolean = False
    Public m_Course As Integer = -1
    Public m_Subject As Integer = -1
    Public studentPK As Integer = -1

    Public Sub LoadCombo()
        'TODO: This line of code loads data into the 'DsSchool.Semester' table. You can move, or remove it, as needed.
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        'TODO: This line of code loads data into the 'DsSchool.SchoolYear' table. You can move, or remove it, as needed.
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        'set check box default to true
        Me.chkFromPrevSchool.Checked = True

        CheckBoxMapSubject.Checked = False
    End Sub

    'Save button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'test length of ex subject name and subject description
        If Me.txtExtSubj.TextLength > 1000 Then
            MsgBox("Your Ex Subject Name exceeds the allowed 1000 characters. Please edit.", MsgBoxStyle.Critical, "Error")
            txtExtSubj.Select()
            Exit Sub
        End If
        If Me.txtExtSubjCode.TextLength > 1000 Then
            MsgBox("Your Ex Subject Code exceeds the allowed 1000 characters. Please edit.", MsgBoxStyle.Critical, "Error")
            txtExtSubjCode.Select()
            Exit Sub
        End If

        'Validate and make numeric
        If Not IsNumeric(Me.cmbCreditGroup.Text) Then Me.cmbCreditGroup.Text = -1
        If Not IsNumeric(Me.txtUnits.Text) Then Me.txtUnits.Text = 0
        If Not IsNumeric(Me.txtExUnits.Text) Then Me.txtExUnits.Text = 0

        'ben2.18.2008
        If Not IsNumeric(Me.txtCompletionGrade.Text) Then Me.txtCompletionGrade.Text = 0

        'validate Ex School. a must.
        If String.IsNullOrEmpty(txtExtSchool.Text) Then
            MsgBox("Ex-school is required! Please choose from configured previous schools.", MsgBoxStyle.Critical, "Error")
            btnExCollege.Select()
            Exit Sub
        End If

        'Validate ex Subject name and code
        If String.IsNullOrEmpty(txtExtSubj.Text) Or String.IsNullOrEmpty(txtExtSubjCode.Text) Then
            MsgBox("Both ex-subject and ex-subject code are required!", MsgBoxStyle.Critical, "Error")
            txtExtSubj.Select()
            Exit Sub
        End If
        'validate grade
        If String.IsNullOrEmpty(txtGrade.Text) Then
            MsgBox("Ex Subject's grade is required!", MsgBoxStyle.Critical, "Error")
            txtGrade.Select()
            Exit Sub
        End If

        'Validate map details if checkbox checked
        If CheckBoxMapSubject.Checked Then

            If m_Subject <= 0 Then
                MsgBox("An MMFC subject is required if you check on Map subject.", MsgBoxStyle.Critical, "Error")
                btnSubject.Select()
                Exit Sub
            End If

            If CDbl(txtUnits.Text) <= 0 Then
                MsgBox("Please put a non-zero value in Credited units if you are mapping a subject.", MsgBoxStyle.Critical, "Error")
                txtUnits.Select()
                Exit Sub
            End If

            If CInt(cmbCreditGroup.Text) < 0 Then
                MsgBox("Please put a numeric value in Credit Group if you are mapping a subject.", MsgBoxStyle.Critical, "Error")
                cmbCreditGroup.Select()
                Exit Sub
            End If

            REM 2.18.2012.  Allowed ZERO grade for mapped subject.
            REM TOR , SPR shouls display Previous School Grade wether its numeric or not
            If CInt(txtCompletionGrade.Text) < 0 Then
                MsgBox("Please put a positive value or zero in Completion Grade if you are mapping a subject.", MsgBoxStyle.Critical, "Error")
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubject.Click

        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()

        If frm.Selected Then
            Me.m_Subject = frm.m_SubjectID
            Me.txtSubject.Text = clsTool.GetSubjectDescription(frm.m_SubjectID)

            CheckBoxMapSubject.Checked = True

            'set credit group automatically
            Dim cgroup As Integer = clsTool.GetSubjectCreditGroup(frm.m_SubjectID)
            If cgroup = -1 Then cgroup = 0
            cmbCreditGroup.Text = cgroup.ToString

        End If
    End Sub


    'Choose Ex College from Excolleges registered in Students Masterfile/Registry
    Private Sub btnExCollege_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExCollege.Click

        Dim frm As New frmSelectExSchool
        frm.StudentPK = studentPK
        frm.LoadData()
        frm.ShowDialog()

        If frm.isDirty Then

            txtExtSchool.Text = frm.PreviousSchool
        End If
    End Sub

    
    Private Sub CheckBoxMapSubject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMapSubject.CheckedChanged

        If CheckBoxMapSubject.Checked Then
            Me.txtUnits.Text = Me.txtExUnits.Text
        End If
    End Sub

End Class