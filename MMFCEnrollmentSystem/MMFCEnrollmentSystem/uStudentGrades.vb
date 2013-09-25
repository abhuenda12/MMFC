Public Class uStudentGrades

    ''*********************************************************************************
    '' the difference with uGradeTransferee is that here you can edit ENR subjects
    ''
    ''*********************************************************************************
    Dim m_StudentPK As Integer = -1

#Region "ADD / EDIT / DELETE "

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewDoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        OpenDoc()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        DeleteDoc()
    End Sub

    Public Sub NewDoc()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student!") : Exit Sub

        Dim frm As New frmGradeEnrolled
        frm.LoadCombo()
        frm.txtSY.SelectedValue = clsTool.GetCurYearPK
        frm.txtSemester.SelectedValue = clsTool.GetCurSemPK
        frm.studentPK = Me.m_StudentPK
        frm.m_Course = clsTool.getStudentRecentCoursePK(m_StudentPK)
        frm.txtCourse.Text = clsTool.getCourseCompleteDesc(frm.m_Course)

        frm.ShowDialog()
        If frm.IsDirty Then

            Dim ds As New dsRegistrar
            Dim dt As New dsRegistrarTableAdapters.StudentGradesTableAdapter
            Dim isPrevSchool As Boolean = False
            Dim exgrade As String = ""
            Dim grade As Decimal = CDbl(frm.txtCompletionGrade.Text)

            ds.StudentGrades.AddStudentGradesRow(Now(), grade, "ENR", frm.m_Subject, _
              frm.txtSY.SelectedValue, frm.txtSemester.SelectedValue, -1, Me.m_StudentPK, "", _
              "", "", frm.m_Course, frm.txtUnits.Text, frm.cmbCreditGroup.Text, _
              "", 0, False, 0)

            dt.Update(ds.StudentGrades)

            LoadGrades()
        End If
    End Sub
    Public Sub DeleteDoc()
        If Me.DsRegistrar.TemplateStudentGrades.Rows.Count = 0 Then MsgBox("No data found!") : Exit Sub
        If MsgBox("Are you sure to remove?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim ds As New dsRegistrar
            ''Dim dt As New dsRegistrarTableAdapters.StudentGradesTableAdapter
            Dim dt As New dsRegistrarTableAdapters.StudentGradesByPKTableAdapter
            With Me.DsRegistrar.TemplateStudentGrades(Me.TemplateStudentGradesBindingSource.Position)
                ''dt.Fill(ds.StudentGrades, .KeyThrough, .subjectpk, .sypk, .sempk, Me.m_StudentPK)
                dt.Fill(ds.StudentGradesByPK, .pk)
            End With
            If ds.StudentGradesByPK.Rows.Count > 0 Then
                ds.StudentGradesByPK(0).Delete()
                dt.Update(ds.StudentGradesByPK)
            End If
            LoadGrades()
        End If
    End Sub
    Public Sub OpenDoc()

        If Me.m_StudentPK = -1 Then MsgBox("Please select student!") : Exit Sub

        If Me.DsRegistrar.TemplateStudentGrades.Rows.Count = 0 Then MsgBox("No data found!") : Exit Sub

        If Me.DsRegistrar.TemplateStudentGrades(Me.TemplateStudentGradesBindingSource.Position).KeyThrough = "MAN" Then
            MsgBox("Cannot modify a grade of type 'MAN' (transferee grade)" & vbCrLf & "Edit transferee grades in Registrar > Encode Transferee Grades")
            Exit Sub
        End If

        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentGradesByPKTableAdapter

        With Me.DsRegistrar.TemplateStudentGrades(Me.TemplateStudentGradesBindingSource.Position)

            dt.Fill(ds.StudentGradesByPK, .pk)
        End With

        If ds.StudentGradesByPK.Rows.Count = 0 Then MsgBox("Cannot find grade row!") : Exit Sub

        Dim frm As New frmGradeEnrolled
        frm.LoadCombo()

        With ds.StudentGradesByPK(0)
            frm.studentPK = .studentpk
            frm.m_Course = Convert.ToInt32(.coursepk)
            frm.txtCourse.Text = clsTool.getCourseName(frm.m_Course)

            frm.txtSemester.SelectedValue = Convert.ToInt32(.sempk)
            frm.m_Subject = Convert.ToInt32(.subjectpk)
            frm.txtSubject.Text = clsTool.GetSubjectDescription(frm.m_Subject)
            frm.txtSY.SelectedValue = Convert.ToInt32(.sypk)

            frm.txtCompletionGrade.Text = .grade
            frm.txtUnits.Text = .exSubjectUnits
            frm.cmbCreditGroup.Text = .exCreditGroup

        End With
        frm.ShowDialog()
        If frm.IsDirty Then
            With ds.StudentGradesByPK(0)
                .coursepk = frm.m_Course
                .grade = frm.txtCompletionGrade.Text
                .sempk = frm.txtSemester.SelectedValue
                .subjectpk = frm.m_Subject
                .sypk = frm.txtSY.SelectedValue

                .exSubjectUnits = frm.txtUnits.Text

                If frm.cmbCreditGroup.Text <> "0" Then .exCreditGroup = frm.cmbCreditGroup.Text

            End With

            dt.Update(ds.StudentGradesByPK)
            LoadGrades()
        End If
    End Sub

#End Region

#Region "EVENTS"

    Public Sub Initialize()
        ''GroupControl1.Text = "Grades from previous school(s) of transferee : "
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then

            Initialize()

            Me.m_StudentPK = frm.m_StudentPK

            GroupControl1.Text = "Encode Student Grades (MMFC Grades) : 'MAN' type of grades can't be edited , " & frm.m_StudentName
            LoadGrades()
        End If

    End Sub

    Sub LoadGrades()

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        'load the student's current listing of grades
        Dim ds As New dsReg2.GradesbyStudentSubjectDataTable
        Dim dt As New dsReg2TableAdapters.GradesbyStudentSubjectTableAdapter

        dt.Fill(ds, Me.m_StudentPK, "%" + Me.txtFilter.Text + "%")

        Dim ctr, addedrowsctr As Integer
        addedrowsctr = 0

        'this gridview
        Me.DsRegistrar.TemplateStudentGrades.Clear()

        'Loop grades then insert to grid 
        For ctr = 0 To ds.Rows.Count - 1
            With ds(ctr)

                'validation for display of only 1 entry
                '---------------------------------------------------------------------------------------------------------------------
                Dim ctr2 As Integer
                Dim haspreviousentry As Boolean = False

                'loop to check for previous grade entries
                For ctr2 = 0 To Me.DsRegistrar.TemplateStudentGrades.Rows.Count - 1
                    If .keythrough = "MAN" Then Exit For 'dont check for previous grades since this is manually encoded

                    'Don't compare with grades that are not numeric
                    If Not IsNumeric(Me.DsRegistrar.TemplateStudentGrades(ctr2).Grade) Then Continue For

                    If .subjectpk = Me.DsRegistrar.TemplateStudentGrades(ctr2).subjectpk And _
                           CDbl(Me.DsRegistrar.TemplateStudentGrades(ctr2).Grade) < 5 And _
                            .keythrough = "ENR" Then

                        haspreviousentry = True
                        Exit For
                    End If
                Next

                If haspreviousentry Then Continue For

                'set the index for the grid
                addedrowsctr += 1
                '---------------------------------------------------------------------------------------------------------------------


                'extSubjectID is Ex College Name
                Dim coursename As String = clsTool.getCourseName(.coursepk)
                Dim subjectname As String = clsTool.GetSubjectDescription(.subjectpk)

                '10.21.2011. Added Completion Grade Column to differentiate old school grade and converted grade
                If .keythrough = "ENR" Then

                    Me.DsRegistrar.TemplateStudentGrades.AddTemplateStudentGradesRow(clsTool.getSYName(.sypk), _
                    clsTool.getSEMName(.sempk), coursename, subjectname, _
                    .grade, clsTool.getUnits(.subjectpk), _
                    .keythrough, .sempk, .coursepk, .subjectpk, .sypk, .pk, "", "", "N/A")


                Else
                    Dim displaygrade As String = ""
                    Dim mappedGrade As String = ""

                    'Previous School Grades here
                    If .IsisPrevSchoolGradeNull Then .isPrevSchoolGrade = False
                    REM when its from PRev School, grade is saved in ExSubjectGrade
                    If .isPrevSchoolGrade Then displaygrade = .exSubjectGrade Else displaygrade = .grade

                    
                    Me.DsRegistrar.TemplateStudentGrades.AddTemplateStudentGradesRow(clsTool.getSYName(.sypk), _
                    clsTool.getSEMName(.sempk), coursename, subjectname, displaygrade, .exSubjectUnits, _
                    .keythrough, .sempk, .coursepk, .subjectpk, .sypk, .pk, .exSubjectDesc, .extSubjectID, _
                    .exCompletionGrade)

                    'color the font RED so you know it can't be edited
                    DataGridView1.Rows(addedrowsctr - 1).DefaultCellStyle.ForeColor = Color.IndianRed

                End If
            End With
        Next

        frm.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.m_StudentPK = -1 Then MsgBox("Select student first!") : Exit Sub
        LoadGrades()
    End Sub

    'ben10.24.2007
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            LoadGrades()
        End If
    End Sub

#End Region

End Class
