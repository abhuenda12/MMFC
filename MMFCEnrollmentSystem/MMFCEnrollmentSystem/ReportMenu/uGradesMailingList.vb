Public Class uGradesMailingList

    REM Dec 23 2011, hide ALL checkbox.. reformatted report to have no groups.

    'ben10.17.2007 Copy of uEnrollmentlist
    Public m_studentpk As Integer = -1

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
        Me.CheckBox1.Checked = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.CheckBox1.Checked Then
            retrieveGradesAll()
        ElseIf m_studentpk <> -1 Then
            retrieveGradesStudent(m_studentpk)
        Else
            retrieveGradesAll()
        End If
    End Sub


    'SUMMARY PRINTING ALL STUDENTS???? disable for now...
    Private Sub retrieveGradesAll()
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

            det.Fill(ds.EnrollSubjectsbyStudentSemYrPk, r.StudentPK, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)

            Dim fullname As String()
            fullname = r.StudentName.Split(",")
            Dim familyname As String = ""

            Try
                familyname = fullname(0)
            Catch ex As Exception
            End Try

            'Inner loop for subjects of student 
            For idx = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
                Dim xr As dsRep.EnrollSubjectsbyStudentSemYrPkRow = ds.EnrollSubjectsbyStudentSemYrPk(idx)
                Dim gradestring As String = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
                Dim grade As Double

                If Not IsNumeric(gradestring) Then
                    grade = 0
                Else
                    grade = gradestring
                End If

                Dim remarks As String = ""
                Dim subjectDesc As String = clsTool.GetSubjectName(xr.subjectpk)
                Dim subjectNo As String = clsTool.GetSubjectCode(xr.subjectpk)
                Dim units As Integer = Convert.ToInt32(clsTool.GetSubjectUnits(xr.subjectpk))

                If grade >= 1 And grade < 5 Then
                    remarks = "PASSED"
                ElseIf grade = 5 Then
                    remarks = "FAILED"
                ElseIf grade = 0 Then
                    remarks = "NO GRADE"
                ElseIf grade = 9 Then
                    remarks = "DROPPED"
                End If

                If xr.status = 1 Then

                    ds.GradesMailingList.AddGradesMailingListRow(r.StudentName, r.StudentID, familyname, _
                      subjectNo, grade, remarks, r.Address1 + r.Address2 + r.Address3, subjectDesc, units)
                End If
            Next
        Next

        ds.GradesMailingList.DefaultView.Sort = "StudentName"
        Dim rep As New crGradesMailingList
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

    End Sub


    Private Sub retrieveGradesStudent(ByVal studentpk As Integer)
        Dim ds As New dsRep
        Dim det As New dsRepTableAdapters.EnrollSubjectsbyStudentSemYrPkTableAdapter
        Dim dts As New dsRepTableAdapters.StudentsTableAdapter

        Dim wpa As Double = 0
        Dim runningUnits As Double = 0
        Dim runningTotal As Double = 0


        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        det.Fill(ds.EnrollSubjectsbyStudentSemYrPk, studentpk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)

        Dim fullname As String()
        fullname = clsTool.getStudentName(studentpk).Split(",")
        Dim familyname As String = ""

        Try
            familyname = fullname(0)
        Catch ex As Exception
        End Try

        'loop for subjects of student 
        Dim idx As Integer
        For idx = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
            Dim xr As dsRep.EnrollSubjectsbyStudentSemYrPkRow = ds.EnrollSubjectsbyStudentSemYrPk(idx)
            Dim grade As Double = clsTool.getStudentGrade(xr.studentpk, xr.subjectpk)
            Dim remarks As String = ""
            Dim subjectDesc As String = clsTool.GetSubjectName(xr.subjectpk)
            Dim subjectNo As String = clsTool.GetSubjectCode(xr.subjectpk)
            Dim units As Integer = Convert.ToInt32(clsTool.GetSubjectUnits(xr.subjectpk))

            If grade >= 1 And grade < 5 Then
                'remarks = "PASSED"
                remarks = ""
            ElseIf grade = 5 Then
                remarks = "FAILED"
                units = 0
            ElseIf grade = 0 Then
                'remarks = "PASSED"
                remarks = ""
            ElseIf grade = 9 Then
                'remarks = "DROPPED"
                remarks = ""
                units = 0
            End If

            If xr.status = 1 Then

                Dim strGrade As String = FormatNumber(grade, 1)

                ''Check for Fused SYOffering, get the mapped subject. 2/14/2013.
                If clsTool.CheckSYOfferIsFusedSubjects(xr.syofferingpk) Then
                    subjectDesc = clsTool.GetFusedSubjectDescriptionByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk)
                    subjectNo = clsTool.GetFusedSubjectCodeByCoursePK(xr.syofferingpk, xr.coursepk, xr.subjectpk)
                End If

                ds.GradesMailingList.AddGradesMailingListRow(clsTool.getStudentName(studentpk), clsTool.getStudentID(studentpk), familyname, _
                  subjectNo, strGrade, remarks, clsTool.getStudentAddress(studentpk), subjectDesc, units)

                runningUnits += units
                runningTotal += grade * units
            End If

        Next

        If runningUnits = 0 Then runningUnits = 1

        wpa = runningTotal / runningUnits

        Dim course As String = clsTool.getStudentCourseName(Me.txtSEM.SelectedValue, txtSY.SelectedValue, studentpk)
        Dim yearlevel As String = clsTool.getStudentYearLevel(studentpk, txtSEM.SelectedValue, txtSY.SelectedValue)

        ds.GradesMailingList.DefaultView.Sort = "StudentName"
        Dim rep As New crGradesMailingList
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSEM.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))

        rep.SetParameterValue("COURSE", course)

        rep.SetParameterValue("YEARLEVEL", yearlevel)

        rep.SetParameterValue("UNITS", runningUnits)

        rep.SetParameterValue("WPA", wpa)

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()

    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    'ben10.24.2007
    'Choose student
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_studentpk = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName
            Me.CheckBox1.Checked = False
            retrieveGradesStudent(m_studentpk)
        End If
    End Sub
End Class
