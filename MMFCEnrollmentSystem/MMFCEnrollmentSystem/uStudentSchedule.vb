Public Class uStudentSchedule
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

        'Get enrolled subjects of student
        Dim det As New dsRepTableAdapters.EnrollSubjectsbyStudentSemYrPkTableAdapter
        det.Fill(ds.EnrollSubjectsbyStudentSemYrPk, Me.m_Student, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue)
        If ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count <= 0 Then MsgBox("No Subjects for that Student") : Exit Sub

        For i = 0 To ds.EnrollSubjectsbyStudentSemYrPk.Rows.Count - 1
            Dim subjectname As String = ""
            Dim monsked As String = ""
            Dim tuesked As String = ""
            Dim wedsked As String = ""
            Dim thusked As String = ""
            Dim frisked As String = ""
            Dim satsked As String = ""
            Dim sunsked As String = ""
            With ds.EnrollSubjectsbyStudentSemYrPk(i)
                If .status = 1 Then
                    subjectname = clsTool.GetSubjectCode(.subjectpk)                    
                    If clsTool.checkSkedforDay(.syofferingpk, "Mon") Then
                        monsked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Tue") Then
                        tuesked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Wed") Then
                        wedsked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Thu") Then
                        thusked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Fri") Then
                        frisked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Sat") Then
                        satsked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If
                    If clsTool.checkSkedforDay(.syofferingpk, "Sun") Then
                        sunsked = clsTool.getSYOfferStart(.syofferingpk) + " to " + clsTool.getSYOfferEnd(.syofferingpk)
                    End If

                    ds.StudentSchedule.AddStudentScheduleRow(Me.m_Student, subjectname, monsked, tuesked, wedsked, thusked, frisked, satsked, sunsked)
                End If
            End With
        Next


        Dim rep As New crStudentSchedule
        rep.SetDataSource(ds)
        rep.SetParameterValue("STUDENT", Me.txtStudent.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSEM", Me.txtSem.Text)

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
