Public Class uSyOfferingRep
    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSem.SelectedValue = clsTool.GetCurSemPK
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If CheckBoxByCurriculum.Checked Then
            LoadReportByCurriculum()
        Else
            LoadReport()
        End If
        
    End Sub

    Sub LoadReport()
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingSelect2TableAdapter

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        dt.Fill(ds.SYOfferingSelect2, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue)
        If ds.SYOfferingSelect2.Rows.Count = 0 Then MsgBox("No Data Found!") : frm.Hide() : Exit Sub

        Dim ctr As Integer
        For ctr = 0 To ds.SYOfferingSelect2.Rows.Count - 1
            Dim r As dsRegistrar.SYOfferingSelect2Row = ds.SYOfferingSelect2(ctr)
            Dim status As String
            If r.IsclosedNull Then
                status = "Open"
            Else
                If r.closed Then
                    status = "Closed"
                Else
                    status = "Open"
                End If
            End If

            Dim teacher, starttime, endtime, daysked As String

            daysked = clsTool.getSYOfferDays(r.syofferingpk)
            starttime = clsTool.getSYOfferStart(r.syofferingpk)
            endtime = clsTool.getSYOfferEnd(r.syofferingpk)
            teacher = clsTool.getTeacherName(r.teacherid)

            starttime = starttime.Replace("A", "")
            starttime = starttime.Replace("M", "")
            starttime = starttime.Replace("P", "")
            endtime = endtime.Replace("A", "")
            endtime = endtime.Replace("P", "")
            endtime = endtime.Replace("M", "")

            Dim eCount As Integer = clsTool.getStudentCount(Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, r.syofferingpk)
            'ben10.9.2007
            Dim populationFlag As String = ""
            If eCount < r.MinStudents Then populationFlag = "UNDERLOAD!"
            If eCount > r.MaxStudents Then populationFlag = "OVERLOAD!"

            ds.TemplateSYOffering.AddTemplateSYOfferingRow(clsTool.getTeacherName(r.teacherid), _
              clsTool.getResourceName(r.resource), starttime, endtime, daysked, r.MinStudents, r.MaxStudents, eCount, status, _
              clsTool.GetSubjectDescription(r.subjectpk), populationFlag, "")

        Next
        Dim rep As New crSYOffering
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSem.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()
    End Sub

    'Load Report by curriculum
    Sub LoadReportByCurriculum()

        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingSelect2TableAdapter

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        dt.Fill(ds.SYOfferingSelect2, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue)
        If ds.SYOfferingSelect2.Rows.Count = 0 Then MsgBox("No Data Found!") : frm.Hide() : Exit Sub

        'OUTER LOOP . EACH COURSE/CURRICULUM
        Dim dsCourses As New dsSchool.CoursesDataTable
        Dim dtCourses As New dsSchoolTableAdapters.CoursesTableAdapter

        dtCourses.Fill(dsCourses)
        If dsCourses.Rows.Count <= 0 Then MsgBox("No Courses/Departments Found!") : frm.Hide() : Exit Sub

        Dim j As Integer  'OUTER LOOP COUNTER

        'START OUTER LOOP (curriculum/courses)
        For j = 0 To dsCourses.Rows.Count - 1

            Dim ctr As Integer
            Dim thisFusedInCourse As Boolean = False
            Dim thisFusedSubject As Integer = 0

            'START INNER LOOP (subjects inside curriculum)
            For ctr = 0 To ds.SYOfferingSelect2.Rows.Count - 1

                Dim r As dsRegistrar.SYOfferingSelect2Row = ds.SYOfferingSelect2(ctr)
                Dim status As String
                If r.IsclosedNull Then
                    status = "Open"
                Else
                    If r.closed Then
                        status = "Closed"
                    Else
                        status = "Open"
                    End If
                End If

                'FIRST TEST  IF COURSE HAS THIS SUBJECT IN ITS CURRICULUM
                Dim thisSubjectInCourse As Boolean = clsTool.IsSubjectInCourseCurriculum(r.subjectpk, dsCourses(j).coursepk)


                'if didnt pass first test then do 2nd test
                If Not thisSubjectInCourse Then

                    'Next test if syoffering has mapped subjects and test it if found in curriculum
                    Dim dsFused As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
                    Dim dtFused As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter
                    dtFused.Fill(dsFused, r.syofferingpk)

                    'test if no subjects mapped/fused then continue loop no adding of this offering subject (inner loop)
                    If dsFused.Rows.Count <= 0 Then Continue For 'INNER LOOP CONTINUE TO NEXT SUBJECT IN SYOFFERLIST



                    Dim k As Integer
                    '3rd inner loop , loop of fused subjects
                    For k = 0 To dsFused.Rows.Count - 1

                        thisFusedInCourse = clsTool.IsSubjectInCourseCurriculum(dsFused(k).subjectPK, dsCourses(j).coursepk)

                        If thisFusedInCourse Then

                            'set the subject to the fused one
                            thisFusedSubject = dsFused(k).subjectPK

                            Exit For 'k inner loop
                        End If

                    Next

                    'if the fused subject was not found in current loop curriculum, no adding, next subject in syoofering
                    If Not thisFusedInCourse Then Continue For

                End If

                '
                'as this point, the subject was found in course/curriculum or a mapped subject

                Dim teacher, starttime, endtime, daysked As String

                daysked = clsTool.getSYOfferDays(r.syofferingpk)
                starttime = clsTool.getSYOfferStart(r.syofferingpk)
                endtime = clsTool.getSYOfferEnd(r.syofferingpk)
                teacher = clsTool.getTeacherName(r.teacherid)

                starttime = starttime.Replace("A", "")
                starttime = starttime.Replace("M", "")
                starttime = starttime.Replace("P", "")
                endtime = endtime.Replace("A", "")
                endtime = endtime.Replace("P", "")
                endtime = endtime.Replace("M", "")

                Dim eCount As Integer = clsTool.getStudentCount(Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, r.syofferingpk)
                'ben10.9.2007
                Dim populationFlag As String = ""
                If eCount < r.MinStudents Then populationFlag = "UNDERLOAD!"
                If eCount > r.MaxStudents Then populationFlag = "OVERLOAD!"

                'Now set the correct subject( check if the fused subject is found not the loop subject)
                Dim subject As String = ""
                If thisFusedInCourse Then

                    subject = clsTool.GetSubjectDescription(thisFusedSubject)
                Else
                    subject = clsTool.GetSubjectDescription(r.subjectpk)
                End If


                ds.TemplateSYOffering.AddTemplateSYOfferingRow(clsTool.getTeacherName(r.teacherid), _
                  clsTool.getResourceName(r.resource), starttime, endtime, daysked, r.MinStudents, r.MaxStudents, eCount, status, _
                  subject, populationFlag, clsTool.getCourseCompleteDesc(dsCourses(j).coursepk))


            Next 'END INNER LOOP (subjects inside courses)


        Next
        'END OUTER LOOP


        
        Dim rep As New crSYOfferingByCurriculum
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSem.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()

    End Sub
End Class
