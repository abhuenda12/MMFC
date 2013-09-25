Public Class uClassCard
    Dim m_Student As Integer = -1

    'LOAD button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.m_Student = -1 Then MsgBox("Please select student!") : Exit Sub
        loadReport()
    End Sub

    Private Sub loadReport()

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim ds As New dsRep
        Dim i As Integer
        Dim subjectcode As String = ""
        Dim subjectname As String = ""
        Dim daysked As String = ""
        Dim classstart As String = ""
        Dim classend As String = ""
        Dim instructor As String = ""
        Dim course As String = ""

        'Get enrolled subjects of student
        Dim det As New dsRepTableAdapters.EnrollSubjectsbyStudentSemYrPkTableAdapter
        det.Fill(ds.EnrollSubjectsbyStudentSemYrPk, Me.m_Student, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue)
        If ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count <= 0 Then MsgBox("No Subjects for that Student") : Exit Sub

        For i = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
            With ds.EnrollSubjectsbyStudentSemYrPk(i)
                If .status = 1 Then

                    REM 11.09.2011. Edited Subject Code, to full Subject Description
                    ' Edit crystal report also to fit in this full desc
                    subjectcode = clsTool.GetSubjectCode(.subjectpk)
                    subjectname = clsTool.GetSubjectName(.subjectpk)

                    daysked = clsTool.getSYOfferDays(.syofferingpk)
                    classstart = clsTool.getSYOfferStart(.syofferingpk)
                    classstart = classstart.Replace("A", "")
                    classstart = classstart.Replace("M", "")
                    classstart = classstart.Replace("P", "")
                    classstart = classstart.Replace(" ", "")
                    classend = clsTool.getSYOfferEnd(.syofferingpk)
                    classend = classend.Replace("A", "")
                    classend = classend.Replace("M", "")
                    classend = classend.Replace("P", "")
                    classend = classend.Replace(" ", "")
                    instructor = clsTool.getClassTeacher(.syofferingpk)
                    course = clsTool.getCourseCode(.coursepk)

                    ds.TemplateClassCard.AddTemplateClassCardRow(.studentpk, subjectname, daysked, classstart & "-" & classend, instructor)


                    'now check for extra/different hours (also broken hours) 
                    Dim hasotherskeds As Boolean = clsTool.CheckSYOfferHasDifferentTimeSkeds(.syofferingpk)

                    
                    'add rows to template for each different sked for same subject
                    If hasotherskeds Then
                        Dim daytimesked As String = clsTool.getSYOfferFullSked(.syofferingpk)

                        ds.BrokenHoursTemplate.AddBrokenHoursTemplateRow(subjectname, daytimesked)

                    End If


                End If
            End With
        Next


        Dim rep As New crClassCard
        rep.SetDataSource(ds)

        'subreport
        rep.Subreports(0).SetDataSource(ds)

        rep.SetParameterValue("STUDENT", Me.txtStudent.Text)        
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSEM", Me.txtSem.Text)
        rep.SetParameterValue("COURSE", course)                

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        Me.CrystalReportViewer1.Zoom(75)

        frm.Hide()
    End Sub


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
        Dim frm As New frmStudentSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Student = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName
            loadReport()
        End If
    End Sub
End Class
