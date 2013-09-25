Public Class uEnrollmentList
    'ben10.16.2007 Modified to suit client's own format (matrix type)
    'didn't use the crosstab report of Crytal here since I can't find a way to fit it the way the client wants it


    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
        Me.chkExport.Checked = True
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
            Dim totalunits As Decimal = 0
            Dim course As String = ""
            Dim yrlevel As String = ""
            Dim studentpk As Integer = -1
            Dim hasSubjects As Boolean = False
            Dim enrollsubjectcounter As Integer = 0
            Dim studentsex As String = ""
            Dim bday As String = ""

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


            'Inner loop for subjects of student 
            For idx = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
                Dim xr As dsRep.EnrollSubjectsbyStudentSemYrPkRow = ds.EnrollSubjectsbyStudentSemYrPk(idx)
                course = clsTool.getCourseCode(xr.coursepk)
                yrlevel = clsTool.GetYearLevel(xr.yearpk, xr.sempk, xr.studentpk)
                studentpk = xr.studentpk

                If xr.status = 1 Then
                    hasSubjects = True
                    enrollsubjectcounter += 1
                    Dim isFused As Boolean = clsTool.CheckSYOfferIsFusedSubjects(xr.syofferingpk)

                    Select Case enrollsubjectcounter
                        Case 1
                            If isFused Then subj1 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj1 = clsTool.GetSubjectCode(xr.subjectpk)
                            units1 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 2
                            If isFused Then subj2 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj2 = clsTool.GetSubjectCode(xr.subjectpk)
                            units2 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 3
                            If isFused Then subj3 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj3 = clsTool.GetSubjectCode(xr.subjectpk)
                            units3 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 4
                            If isFused Then subj4 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj4 = clsTool.GetSubjectCode(xr.subjectpk)
                            units4 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 5
                            If isFused Then subj5 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj5 = clsTool.GetSubjectCode(xr.subjectpk)
                            units5 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 6
                            If isFused Then subj6 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj6 = clsTool.GetSubjectCode(xr.subjectpk)
                            units6 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 7
                            If isFused Then subj7 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj7 = clsTool.GetSubjectCode(xr.subjectpk)
                            units7 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 8
                            If isFused Then subj8 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj8 = clsTool.GetSubjectCode(xr.subjectpk)
                            units8 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 9
                            If isFused Then subj9 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj9 = clsTool.GetSubjectCode(xr.subjectpk)
                            units9 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 10
                            If isFused Then subj10 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj10 = clsTool.GetSubjectCode(xr.subjectpk)
                            units10 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 11
                            If isFused Then subj11 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj11 = clsTool.GetSubjectCode(xr.subjectpk)
                            units11 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 12
                            If isFused Then subj12 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj12 = clsTool.GetSubjectCode(xr.subjectpk)
                            units12 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 13
                            If isFused Then subj13 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj13 = clsTool.GetSubjectCode(xr.subjectpk)
                            units13 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 14
                            If isFused Then subj14 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj14 = clsTool.GetSubjectCode(xr.subjectpk)
                            units14 = clsTool.GetSubjectUnits(xr.subjectpk)
                        Case 15
                            If isFused Then subj15 = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk) Else subj15 = clsTool.GetSubjectCode(xr.subjectpk)
                            units15 = clsTool.GetSubjectUnits(xr.subjectpk)

                        Case Else

                    End Select

                    totalunits += clsTool.GetSubjectUnits(xr.subjectpk)
                End If
            Next

            'modified 10.16.2007 ben     
            If clsTool.getStudentBday(studentpk) = "" Then bday = "_" Else bday = clsTool.getStudentBday(studentpk)
            If clsTool.getStudentSex(studentpk) = "" Then studentsex = "_" Else studentsex = clsTool.getStudentSex(studentpk).Substring(0, 1)

            'ben3.24.2008
            Dim surname As String = clsTool2.getSurname(r.StudentName)
            Dim firstname As String = clsTool2.getFirstname(r.StudentName)
            Dim middlename As String = clsTool2.getMiddleName(r.StudentName)

            If clsTool2.checkIfStudent2ndcourser(r.StudentPK) Then
                surname = "*" & surname
            End If

            If hasSubjects Then
                ''ds.EnrollmentList.AddEnrollmentListRow(r.StudentName, r.StudentID, course, subj1, units1, subj2, units2, _
                ''  subj3, units3, subj4, units4, subj5, units5, subj6, units6, subj7, units7, subj8, units8, subj9, units9, subj10, units10, _
                ''  studentpk, yrlevel, studentsex, bday, totalunits, surname, firstname, middlename, _
                ''  subj11, units11, subj12, units12, _
                ''  subj13, units13, subj14, units14, subj15, units15)

                ds.PromotionalReport.AddPromotionalReportRow(r.StudentName, surname, firstname, middlename, _
                   r.StudentID, course, subj1, units1, grade1, subj2, units2, grade2, subj3, units3, grade3, _
                   subj4, units4, grade4, subj5, units5, grade5, subj6, units6, grade6, subj7, units7, _
                   grade7, subj8, units8, grade8, subj9, units9, grade9, subj10, units10, grade10, _
                  studentpk, yrlevel, studentsex, bday, totalunits, subj11, units11, grade11, subj12, _
                  units12, grade12, subj13, units13, grade13, _
                   subj14, units14, grade14, subj15, units15, grade15)

            End If
        Next

        ds.EnrollmentList.DefaultView.Sort = "student"

        ''If Me.chkExport.Checked Then
        ''    Dim rep As New crEnrollmentListExport
        ''    rep.SetDataSource(ds)
        ''    Me.CrystalReportViewer1.ReportSource = rep
        ''    Me.CrystalReportViewer1.RefreshReport()

        ''Else
        Dim rep As New crEnrollmentList3
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSEM.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()

        ''End If

        frm.Hide()
    End Sub


    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
End Class
