Public Class uPromotionalReport
    'ben10.17.2007 Copy of uEnrollmentlist with some modifications to include grade

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New dsRep
        Dim dst As New dsRepTableAdapters.StudentsTableAdapter
        Dim det As New dsRepTableAdapters.EnrollSubjectsbyStudentSemYrPkTableAdapter
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        dst.Fill(ds.Students)
        Dim ctr As Integer
        Dim idx As Integer

        'Outer loop to get all students
        For ctr = 0 To ds.Students.Rows.Count - 1

            Dim r As dsRep.StudentsRow = ds.Students(ctr)

            'dont include optometry and dentistry
            Dim longcourse As String = clsTool.getStudentCourseName(txtSEM.SelectedValue, txtSY.SelectedValue, r.StudentPK)

            'now check if option chosen. continue to next student.
            If Not CheckBox1.Checked Then
                If longcourse.ToUpper.Contains("DENTAL") Or longcourse.ToUpper.Contains("OPTOMETRY") Then
                    Continue For
                End If
            Else 'only dent and opto mode
                If Not longcourse.ToUpper.Contains("DENTAL") And Not longcourse.ToUpper.Contains("OPTOMETRY") Then
                    Continue For
                End If
            End If

            det.Fill(ds.EnrollSubjectsbyStudentSemYrPk, r.StudentPK, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)

            Dim subj1 As String = "_"
            Dim units1 As String = "0"
            Dim subj2 As String = "_"
            Dim units2 As String = "0"
            Dim subj3 As String = "_"
            Dim units3 As String = "0"
            Dim subj4 As String = "_"
            Dim units4 As String = "0"
            Dim subj5 As String = "_"
            Dim units5 As String = "0"
            Dim subj6 As String = "_"
            Dim units6 As String = "0"
            Dim subj7 As String = "_"
            Dim units7 As String = "0"
            Dim subj8 As String = "_"
            Dim units8 As String = "0"
            Dim subj9 As String = "_"
            Dim units9 As String = "0"
            Dim subj10 As String = "_"
            Dim units10 As String = "0"
            Dim subj11 As String = "_"
            Dim units11 As String = "0"
            Dim subj12 As String = "_"
            Dim units12 As String = "0"
            Dim subj13 As String = "_"
            Dim units13 As String = "0"
            Dim subj14 As String = "_"
            Dim units14 As String = "0"
            Dim subj15 As String = "_"
            Dim units15 As String = "0"
            Dim grade1 As String = "0"
            Dim grade2 As String = "0"
            Dim grade3 As String = "0"
            Dim grade4 As String = "0"
            Dim grade5 As String = "0"
            Dim grade6 As String = "0"
            Dim grade7 As String = "0"
            Dim grade8 As String = "0"
            Dim grade9 As String = "0"
            Dim grade10 As String = "0"
            Dim grade11 As String = "0"
            Dim grade12 As String = "0"
            Dim grade13 As String = "0"
            Dim grade14 As String = "0"
            Dim grade15 As String = "0"

            Dim totalunits As Decimal = 0
            Dim course As String = ""
            Dim yrlevel As String = ""
            Dim studentpk As Integer = -1
            Dim hasSubjects As Boolean = False
            Dim enrollsubjectcounter As Integer = 0
            Dim bday As String = ""
            Dim studentsex As String = ""
            Dim surname As String = ""
            Dim firstname As String = ""
            Dim middlename As String = ""
            Dim syofferingpk As Integer = 0

            'Inner loop for subjects of student 
            For idx = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
                Dim xr As dsRep.EnrollSubjectsbyStudentSemYrPkRow = ds.EnrollSubjectsbyStudentSemYrPk(idx)
                course = clsTool.getCourseCode(xr.coursepk)
                yrlevel = clsTool.GetYearLevel(xr.yearpk, xr.sempk, xr.studentpk)
                studentpk = xr.studentpk
                syofferingpk = ds.EnrollSubjectsbyStudentSemYrPk(idx).syofferingpk

                If xr.status = 1 Then
                    hasSubjects = True
                    enrollsubjectcounter += 1
                    Dim isFused As Boolean = clsTool.CheckSYOfferIsFusedSubjects(xr.syofferingpk)
                    Select Case enrollsubjectcounter
                        Case 1
                            If isFused Then subj1 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj1 = clsTool.GetSubjectCode(xr.subjectpk)
                            units1 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade1 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade1 <= 0 Then grade1 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 2
                            If isFused Then subj2 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj2 = clsTool.GetSubjectCode(xr.subjectpk)                           
                            units2 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade2 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade2 <= 0 Then grade2 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 3
                            If isFused Then subj3 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj3 = clsTool.GetSubjectCode(xr.subjectpk)                           
                            units3 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade3 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade3 <= 0 Then grade3 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 4
                            If isFused Then subj4 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj4 = clsTool.GetSubjectCode(xr.subjectpk)
                            units4 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade4 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade4 <= 0 Then grade4 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 5
                            If isFused Then subj5 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj5 = clsTool.GetSubjectCode(xr.subjectpk)
                            units5 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade5 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade5 <= 0 Then grade5 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 6
                            If isFused Then subj6 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj6 = clsTool.GetSubjectCode(xr.subjectpk)
                            units6 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade6 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade6 <= 0 Then grade6 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 7
                            If isFused Then subj7 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj7 = clsTool.GetSubjectCode(xr.subjectpk)
                            units7 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade7 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade7 <= 0 Then grade7 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 8
                            If isFused Then subj8 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj8 = clsTool.GetSubjectCode(xr.subjectpk)
                            units8 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade8 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade1 <= 0 Then grade1 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 9
                            If isFused Then subj9 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj9 = clsTool.GetSubjectCode(xr.subjectpk)
                            units9 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade9 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade9 <= 0 Then grade9 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 10
                            If isFused Then subj10 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj10 = clsTool.GetSubjectCode(xr.subjectpk)
                            units10 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade10 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade10 <= 0 Then grade10 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 11
                            If isFused Then subj11 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj11 = clsTool.GetSubjectCode(xr.subjectpk)
                            units11 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade11 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade11 <= 0 Then grade11 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 12
                            If isFused Then subj12 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj12 = clsTool.GetSubjectCode(xr.subjectpk)
                            units12 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade12 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade12 <= 0 Then grade12 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 13
                            If isFused Then subj13 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj13 = clsTool.GetSubjectCode(xr.subjectpk)
                            units13 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade13 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade13 <= 0 Then grade13 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 14
                            If isFused Then subj14 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj14 = clsTool.GetSubjectCode(xr.subjectpk)
                            units14 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade14 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade14 <= 0 Then grade14 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case 15
                            If isFused Then subj15 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj15 = clsTool.GetSubjectCode(xr.subjectpk)
                            units15 = clsTool.GetSubjectUnits(xr.subjectpk)
                            grade15 = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                            If grade15 <= 0 Then grade15 = clsTool.getStudentGradeBySyOfferingPK(xr.studentpk, syofferingpk)
                        Case Else

                    End Select

                    totalunits += clsTool.GetSubjectUnits(xr.subjectpk)
                End If
            Next

            ' ========= modify for empty ================
            'ben 5.15.2008

            If IsNumeric(grade1) Then
                If CInt(grade1) = 5 Or CInt(grade1) = 9 Or CInt(grade1) = 0 Then units1 = "0"
                If CInt(grade1) = 0 Then grade1 = ""
            Else
                units1 = "0"
                grade1 = ""
            End If
            If subj1 = "_" Or subj1 = "" Then grade1 = "" : units1 = ""

            If IsNumeric(grade2) Then
                If CInt(grade2) = 5 Or CInt(grade2) = 9 Or CInt(grade2) = 0 Then units2 = "0"
                If CInt(grade2) = 0 Then grade2 = ""
            Else
                units2 = "0"
                grade2 = ""
            End If
            If subj2 = "_" Or subj2 = "" Then grade2 = "" : units2 = ""

            If IsNumeric(grade3) Then
                If CInt(grade3) = 5 Or CInt(grade3) = 9 Or CInt(grade3) = 0 Then units3 = "0"
                If CInt(grade3) = 0 Then grade3 = ""
            Else
                units3 = "0"
                grade3 = ""
            End If
            If subj3 = "_" Or subj3 = "" Then grade3 = "" : units3 = ""

            If IsNumeric(grade4) Then
                If CInt(grade4) = 5 Or CInt(grade4) = 9 Or CInt(grade4) = 0 Then units4 = "0"
                If CInt(grade4) = 0 Then grade4 = ""
            Else
                units4 = "0"
                grade4 = ""
            End If
            If subj4 = "_" Or subj4 = "" Then grade4 = "" : units4 = ""

            If IsNumeric(grade5) Then
                If CInt(grade5) = 5 Or CInt(grade5) = 9 Or CInt(grade5) = 0 Then units5 = "0"
                If CInt(grade5) = 0 Then grade5 = ""
            Else
                units5 = "0"
                grade5 = ""
            End If
            If subj5 = "_" Or subj5 = "" Then grade5 = "" : units5 = ""

            '6
            If IsNumeric(grade6) Then
                If CInt(grade6) = 5 Or CInt(grade6) = 9 Or CInt(grade6) = 0 Then units6 = "0"
                If CInt(grade6) = 0 Then grade6 = ""
            Else
                units6 = "0"
                grade6 = ""
            End If
            If subj6 = "_" Or subj6 = "" Then grade6 = "" : units6 = ""

            '7
            If IsNumeric(grade7) Then
                If CInt(grade7) = 5 Or CInt(grade7) = 9 Or CInt(grade7) = 0 Then units7 = "0"
                If CInt(grade7) = 0 Then grade7 = ""
            Else
                units7 = "0"
                grade7 = ""
            End If

            If subj7 = "_" Or subj7 = "" Then grade7 = "" : units7 = ""

            '8
            If IsNumeric(grade8) Then
                If CInt(grade8) = 5 Or CInt(grade8) = 9 Or CInt(grade8) = 0 Then units8 = "0"
                If CInt(grade8) = 0 Then grade8 = ""
            Else
                units8 = "0"
                grade8 = ""
            End If

            If subj8 = "_" Or subj8 = "" Then grade8 = "" : units8 = ""

            '9
            If IsNumeric(grade9) Then
                If CInt(grade9) = 5 Or CInt(grade9) = 9 Or CInt(grade9) = 0 Then units9 = "0"
                If CInt(grade9) = 0 Then grade9 = ""
            Else
                units9 = "0"
                grade9 = ""
            End If

            If subj9 = "_" Or subj9 = "" Then grade9 = "" : units9 = ""

            '10
            If IsNumeric(grade10) Then
                If CInt(grade10) = 5 Or CInt(grade10) = 9 Or CInt(grade10) = 0 Then units10 = "0"
                If CInt(grade10) = 0 Then grade10 = ""
            Else
                units10 = "0"
                grade10 = ""
            End If

            If subj10 = "_" Or subj10 = "" Then grade10 = "" : units10 = ""

            If IsNumeric(grade11) Then
                If CInt(grade11) = 5 Or CInt(grade11) = 9 Or CInt(grade11) = 0 Then units11 = "0"
                If CInt(grade11) = 0 Then grade11 = ""
            Else
                units11 = "0"
                grade11 = ""
            End If
            If subj11 = "_" Or subj11 = "" Then grade11 = "" : units11 = ""

            If IsNumeric(grade12) Then
                If CInt(grade12) = 5 Or CInt(grade12) = 9 Or CInt(grade12) = 0 Then units12 = "0"
                If CInt(grade12) = 0 Then grade12 = ""
            Else
                units12 = "0"
                grade12 = ""
            End If
            If subj12 = "_" Or subj12 = "" Then grade12 = "" : units12 = ""

            If IsNumeric(grade13) Then
                If CInt(grade13) = 5 Or CInt(grade13) = 9 Or CInt(grade13) = 0 Then units13 = "0"
                If CInt(grade13) = 0 Then grade13 = ""
            Else
                units13 = "0"
                grade13 = ""
            End If
            If subj13 = "_" Or subj13 = "" Then grade13 = "" : units13 = ""

            If IsNumeric(grade4) Then
                If CInt(grade14) = 5 Or CInt(grade14) = 9 Or CInt(grade14) = 0 Then units14 = "0"
                If CInt(grade14) = 0 Then grade14 = ""
            Else
                units14 = "0"
                grade14 = ""
            End If
            If subj14 = "_" Or subj14 = "" Then grade14 = "" : units14 = ""

            If IsNumeric(grade15) Then
                If CInt(grade15) = 5 Or CInt(grade15) = 9 Or CInt(grade15) = 0 Then units15 = "0"
                If CInt(grade15) = 0 Then grade15 = ""
            Else
                units15 = "0"
                grade15 = ""
            End If
            If subj15 = "_" Or subj15 = "" Then grade15 = "" : units15 = ""


            'modified 10.16.2007 ben           
            If clsTool.getStudentBday(studentpk) = "" Then bday = "_" Else bday = clsTool.getStudentBday(studentpk)
            If clsTool.getStudentSex(studentpk) = "" Then studentsex = "_" Else studentsex = clsTool.getStudentSex(studentpk).Substring(0, 1)

            'ben1.28.2008
            surname = clsTool2.getSurname(r.StudentName)
            firstname = clsTool2.getFirstname(r.StudentName)
            middlename = clsTool2.getMiddleName(r.StudentName)

            If clsTool2.checkIfStudent2ndcourser(r.StudentPK) Then
                surname = "*" & surname
            End If

            If hasSubjects Then
                ds.PromotionalReport.AddPromotionalReportRow(r.StudentName, surname, firstname, middlename, _
                   r.StudentID, course, subj1, units1, grade1, subj2, units2, grade2, subj3, units3, grade3, _
                   subj4, units4, grade4, subj5, units5, grade5, subj6, units6, grade6, subj7, units7, _
                   grade7, subj8, units8, grade8, subj9, units9, grade9, subj10, units10, grade10, _
                  studentpk, yrlevel, studentsex, bday, totalunits, subj11, units11, grade11, subj12, _
                  units12, grade12, subj13, units13, grade13, _
                   subj14, units14, grade14, subj15, units15, grade15)
            End If
        Next

        ds.PromotionalReport.DefaultView.Sort = "student"
        Dim rep As New crPromotionalReport
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSEM.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()
        MsgBox("This format is designed for and readable in MS Excel.")
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
End Class
