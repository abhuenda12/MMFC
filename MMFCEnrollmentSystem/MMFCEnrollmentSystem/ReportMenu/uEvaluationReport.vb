Public Class uEvaluationReport
    Dim m_Student As Integer = -1
    Dim coursePK As Integer = -1

    'LOAD button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Me.m_Student = -1 Then MsgBox("Please select student!") : Exit Sub

        If Me.chkCurriculum.Checked Then
            REM Curriculum Based Evaluation Sheet, like a printout of a curriculum with grades in it
            loadEvaluationReport()
        Else
            REM Simple Listing
            loadGrades()
        End If

    End Sub

    ''' <summary>
    ''' Curriculum Based Report
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadEvaluationReport()

        Dim frmWait As New frmWait
        frmWait.Show()
        Application.DoEvents()

        'ROW COUNTER to set all Year Level height for page 1 (year1 to 3) EQUAL to 9 rows
        Dim rowCounter_1 As Integer = 0
        Dim rowCounter_1Summer As Integer = 0
        Dim rowCounter_2 As Integer = 0
        Dim rowCounter_2Summer As Integer = 0
        Dim rowCounter_3 As Integer = 0
        Dim rowCounter_3Summer As Integer = 0

        'get curriculum for chosen course
        Dim ds As New dsReg2.CurriculumbyCourseDataTable
        Dim dt As New dsReg2TableAdapters.CurriculumbyCourseTableAdapter
        dt.Fill(ds, coursePK)
        If ds.Rows.Count <= 0 Then MsgBox("That course has no curriculum records.") : frmWait.Hide() : Exit Sub

        'FIRST LOOP . For 1st Semester and Summer subjects
        'loop the dataset and get the grade of student per subject 
        'then insert to TemplateEvaluationCurriculumReport
        Dim dsRep As New dsRep
        Dim i, j As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).IsSubjectpkNull Then ds(i).Subjectpk = -1
            Dim subjectcode As String = clsTool.GetSubjectCode(ds(i).Subjectpk)
            Dim subjectname As String = clsTool.GetSubjectName(ds(i).Subjectpk)
            Dim subjectunits As Integer = clsTool.GetSubjectUnits(ds(i).Subjectpk)
            Dim grade As String = clsTool.getStudentGrade(Me.m_Student, ds(i).Subjectpk)
            Dim yearlevel As String = ""
            Dim semester As String = ""

            grade = clsTool2.formatGrade(grade)
            'check for 5 or 9 grades, replace with empty string
            Try
                If (CDbl(grade) = 5 Or CDbl(grade) = 9) Then grade = ""
            Catch ex As Exception
            End Try

            Select Case ds(i).YearLevelid
                Case 1
                    yearlevel = "1st YEAR"
                    If ds(i).Semesterid = 1 Then rowCounter_1 += 1
                    If ds(i).Semesterid = 3 Then rowCounter_1Summer += 1
                Case 2
                    yearlevel = "2nd YEAR"
                    If ds(i).Semesterid = 1 Then rowCounter_2 += 1
                    If ds(i).Semesterid = 3 Then rowCounter_2Summer += 1
                Case 3
                    yearlevel = "3rd YEAR"
                    If ds(i).Semesterid = 1 Then rowCounter_3 += 1
                    If ds(i).Semesterid = 3 Then rowCounter_3Summer += 1
                Case 4
                    yearlevel = "4th YEAR"

                Case 5
                    yearlevel = "5th YEAR"

                Case 6
                    yearlevel = "6th YEAR"

                Case Else
                    yearlevel = "1st YEAR"
            End Select

            'Name the Year Title
            Select Case ds(i).Semesterid
                Case 1
                    semester = "1st Semester"
                Case 2
                    Continue For  '2nd semester subjects will be inserted (updated) in the 2nd loop                    
                Case 3
                    semester = "SUMMER"  'summer will be considered a year level
                    yearlevel += " SUMMER"
                Case Else
                    semester = "1st Semester"
            End Select

            dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                yearlevel, semester, subjectcode, subjectname, subjectunits, grade, "", "", "", 0, 0)

        Next

        'SECOND LOOP . For 2nd Semester Subjects. Will have inner loop for dsRep.TemplateEvaluation.....
        For i = 0 To ds.Rows.Count - 1
            If ds(i).IsSubjectpkNull Then ds(i).Subjectpk = -1
            Dim subjectcode As String = clsTool.GetSubjectCode(ds(i).Subjectpk)
            Dim subjectname As String = clsTool.GetSubjectName(ds(i).Subjectpk)
            Dim subjectunits As Integer = clsTool.GetSubjectUnits(ds(i).Subjectpk)
            Dim grade As String = clsTool.getStudentGrade(Me.m_Student, ds(i).Subjectpk)
            Dim yearlevel As String = ""
            Dim semester As String = ""

            'Just get 2nd semester subjects
            If ds(i).IsSemesteridNull Then ds(i).Semesterid = 1
            If ds(i).Semesterid <> 2 Then Continue For
            semester = "2nd Semester"

            grade = clsTool2.formatGrade(grade)
            'check for 5 or 9 grades, replace with empty string
            Try
                If (CDbl(grade) = 5 Or CDbl(grade) = 9) Then grade = ""
            Catch ex As Exception
            End Try

            Select Case ds(i).YearLevelid
                Case 1
                    yearlevel = "1st YEAR"
                Case 2
                    yearlevel = "2nd YEAR"
                Case 3
                    yearlevel = "3rd YEAR"
                Case 4
                    yearlevel = "4th YEAR"
                Case 5
                    yearlevel = "5th YEAR"
                Case 6
                    yearlevel = "6th YEAR"
                Case Else
                    yearlevel = "1st YEAR"
            End Select

            'Inner loop for dsRep.templateevaluation.... Find first row of the same yearlevel and empty semname2
            Dim linefound As Boolean = False
            For j = 0 To dsRep.TemplateEvaluationCurriculumReport.Rows.Count - 1
                With dsRep.TemplateEvaluationCurriculumReport(j)
                    If .IsyearlevelNull Then .yearlevel = ""
                    If .Issemname2Null Then .semname2 = ""
                    If .yearlevel = yearlevel And .semname2 = "" Then
                        .semname2 = semester
                        ._2subjectcode = subjectcode
                        ._2subjectname = subjectname
                        ._2subjectunits = subjectunits
                        ._2grade = grade
                        linefound = True
                        Exit For
                    End If
                End With
            Next

            If Not linefound Then  'for case where 2nd semester more than 1st sem subjects
                dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                             yearlevel, "", "", "", 0, 0, semester, subjectcode, subjectname, subjectunits, grade)
            End If

        Next


        'ADD rows to reach 9 rows per year level for years 1 to 3
        While (rowCounter_1 < 10)
            dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                             "1st YEAR", "1st Semester", "", "", 0, "", "", "", "", 0, "")
            rowCounter_1 += 1
        End While
        While (rowCounter_2 < 10)
            dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                             "2nd YEAR", "1st Semester", "", "", 0, "", "", "", "", 0, "")
            rowCounter_2 += 1
        End While
        'For Optometry /Midwifery, no need for 2nd year summer and 3rd year
        If (Not Me.txtCourse.Text.ToUpper.Contains("PREPARATORY TO OPTOMETRY") And Not Me.txtCourse.Text.ToUpper.Contains("MIDWIFERY")) Then
            While (rowCounter_3 < 12)
                dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                                 "3rd YEAR", "1st Semester", "", "", 0, "", "", "", "", 0, "")
                rowCounter_3 += 1
            End While
        End If
        'For Pharmacy add 1 more row since 3rd yr level is showing up
        If (Me.txtCourse.Text.ToUpper.Contains("PHARMACY")) Then
            dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                                             "3rd YEAR", "1st Semester", "", "", 0, "", "", "", "", 0, "")
        End If

        'For Summer subjects, create 3 rows
        While (rowCounter_1Summer < 3)
            dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                             "1st YEAR SUMMER", "SUMMER", "", "", 0, "", "", "", "", 0, "")
            rowCounter_1Summer += 1
        End While
        'For Optometry, no need for 2nd year summer and 3rd year
        If (Not Me.txtCourse.Text.ToUpper.Contains("PREPARATORY TO OPTOMETRY") And Not Me.txtCourse.Text.ToUpper.Contains("MIDWIFERY")) Then
            While (rowCounter_2Summer < 3)
                dsRep.TemplateEvaluationCurriculumReport.AddTemplateEvaluationCurriculumReportRow(Me.m_Student, _
                                 "2nd YEAR SUMMER", "SUMMER", "", "", 0, "", "", "", "", 0, "")
                rowCounter_2Summer += 1
            End While
        End If
        
        'no need 3rd yr summer

        'Start Report
        Dim rep As New crEvaluationReportCurriculum
        rep.SetDataSource(dsRep)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep.SetParameterValue("STUDENT", Me.txtStudent.Text)

        Dim studenttype As Integer = 2 'old
        If clsTool.getStudentType(Me.m_Student).ToUpper.Contains("OLD") Then
            studenttype = 2
        ElseIf clsTool.getStudentType(Me.m_Student).ToUpper.Contains("NEW") Then
            studenttype = 1
        ElseIf clsTool.getStudentType(Me.m_Student).ToUpper.Contains("TRANSFER") Then
            studenttype = 3
        End If


        rep.SetParameterValue("COURSE", Me.txtCourse.Text)
        rep.SetParameterValue("COURSEREMARKS", clsTool.getCourseRemarks(Me.coursePK))
        rep.SetParameterValue("STUDENTTYPE", studenttype)
        rep.SetParameterValue("YEARLEVEL", clsTool.getStudentYearLevel(Me.m_Student, clsTool.GetCurSemPK, clsTool.GetCurYearPK))
        rep.SetParameterValue("ASSESSOR", InputBox("ASSESSOR ?", "Assessor Name"))

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        'Me.CrystalReportViewer1.Zoom(75)

        frmWait.Hide()
    End Sub

    REM Non Curriculum based report
    Private Sub loadGrades()

        REM as of 2.7.2012, all semesters should be included
        REM  change the adapter 

        'Get subjects enrolled by student 
        Dim ds As New dsRegistrar
        ''Dim dtEnrSub As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        Dim dtEnrSub As New dsRegistrarTableAdapters.EnrollSubjects1TableAdapter

        dtEnrSub.Fill(ds.EnrollSubjects1, m_Student)

        If ds.EnrollSubjects1.Rows.Count <= 0 Then MsgBox("No enlisted subjects for that Student!") : Exit Sub

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        'If Enrolled subject then add subject and teacher to template for report, then get corresponding grade 
        Dim dsRep As New dsRep

        Dim gradeweight As Decimal = 0
        Dim totalunits As Decimal = 0
        Dim wga As Decimal = 0  'weighted grade average
        ''to hold subjectspk, to avoid duplicate subjects being listed
        Dim subjectsArray(ds.EnrollSubjects1.Rows.Count) As Integer

        Dim i As Integer
        For i = 0 To ds.EnrollSubjects1.Rows.Count - 1
            Dim teacher As String = ""
            Dim grade As Double = 0
            Dim subject As String = ""
            Dim units As Decimal = 0
            Dim remarks As String = ""


            With ds.EnrollSubjects1(i)

                Dim thisSY As String = clsTool.getSYName(.yearpk)
                Dim thisSem As String = clsTool.getSEMName(.sempk) & " " & thisSY

                If .status = 1 Then
                    ''Check if current SubjectPK has already been added (duplicate enrollment to a subject). 2/12/2013
                    If Array.IndexOf(subjectsArray, .subjectpk) >= 0 Then
                        Continue For
                    End If

                    ''Check for Fused SYOffering, get the mapped subject
                    If clsTool.CheckSYOfferIsFusedSubjects(.syofferingpk) Then
                        subject = clsTool.GetFusedSubjectDescriptionByCoursePK(.syofferingpk, .coursepk, .subjectpk)
                    Else
                        subject = clsTool.GetSubjectDescription(.subjectpk)
                    End If


                    teacher = clsTool.getClassTeacher(.syofferingpk)
                    grade = clsTool.getStudentGrade(Me.m_Student, .subjectpk)
                    units = clsTool.GetSubjectUnits(.subjectpk)
                    If grade > 0 Then gradeweight += units * grade : totalunits += units

                    'remarks now FULLY NAMED not just initials. 3/2/2013
                    If grade >= 1 And grade < 5 Then
                        remarks = "PASSED"
                    ElseIf grade = 5 Then
                        remarks = "FAILED"
                        units = 0 '3/2/2012 as per Sally
                    ElseIf grade = 0 Then
                        remarks = ""
                    ElseIf grade = 9 Then
                        remarks = "DROPPED"
                        units = 0 '3/2/2012 as per Sally
                    End If

                    dsRep.TemplateEvaluationReport.AddTemplateEvaluationReportRow(Me.m_Student, subject, remarks, grade, units, thisSY, thisSem)

                    'add the subject to array of validation
                    subjectsArray(i) = .subjectpk

                End If
            End With
        Next

        If totalunits = 0 Then wga = 0 Else wga = gradeweight / totalunits

        Dim course As String = clsTool.getStudentCourseName(Me.txtSem.SelectedValue, txtSY.SelectedValue, m_Student)

        Dim rep As New crEvaluationReport
        rep.SetDataSource(dsRep)
        ''rep.SetParameterValue("COURSE", clsTool.getStudentCourseName(Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, m_Student))
        rep.SetParameterValue("COURSE", course)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSem.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep.SetParameterValue("STUDENT", Me.txtStudent.Text)
        rep.SetParameterValue("WGA", wga)

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        'Me.CrystalReportViewer1.Zoom(75)

        frm.Hide()
    End Sub

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSem.SelectedValue = clsTool.GetCurSemPK
        Me.chkCurriculum.Checked = True
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
    'Student select
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Student = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName            
        End If
    End Sub

    'Course Select
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.txtCourse.Text = frm.m_CourseName
            Me.coursePK = frm.m_CoursePK
        End If
    End Sub

    Private Sub chkCurriculum_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCurriculum.CheckedChanged
        If Me.chkCurriculum.Checked Then
            Me.grpCurriculum.Visible = True
            Me.grpSemChooser.Visible = False
        Else
            Me.grpCurriculum.Visible = False
            Me.grpSemChooser.Visible = True
        End If
    End Sub
End Class
