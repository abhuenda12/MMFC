Public Class uWhiteForm
    Dim m_Student As Integer = -1

#Region "Old White Form procedure"
    REM ben10.2.2007. Commented Out.
    ''Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    ''    If Me.m_Student = -1 Then MsgBox("Please select student!") : Exit Sub
    ''    Dim frmw As New frmWait
    ''    frmw.Show()
    ''    Application.DoEvents()
    ''    Dim des As New dsRegistrar
    ''    Dim dest As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
    ''    dest.Fill(des.EnrollHeader, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, Me.m_Student)
    ''    If des.EnrollHeader.Rows.Count = 0 Then
    ''        MsgBox("No Enrollment Records!")
    ''        frmw.Hide()
    ''        Exit Sub
    ''    End If
    ''    If des.EnrollHeader(0).IsyrlevelNull Then
    ''        ''MsgBox("Enrollment not finalized!")
    ''        MsgBox("No year level finalized!")
    ''        frmw.Hide()
    ''        Exit Sub
    ''    End If
    ''    Dim rYearLevel As Integer = des.EnrollHeader(0).yrlevel
    ''    Dim eDate As Date = Now.Date
    ''    Dim ctr As Integer
    ''    Dim ds As New dsRegistrar
    ''    Dim dtx As New dsRegistrarTableAdapters.WhiteFormTableAdapter
    ''    dtx.Fill(ds.WhiteForm, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, Me.m_Student)
    ''    Dim df As New dsFinance
    ''    Dim dft As New dsFinanceTableAdapters.CoursePricingTableAdapter
    ''    Dim dst As New dsFinanceTableAdapters.CourseSubjectPricingTableAdapter
    ''    Dim idx As Integer
    ''    For ctr = 0 To ds.WhiteForm.Rows.Count - 1
    ''        Dim nr As dsRegistrar.WhiteFormRow = ds.WhiteForm(ctr)
    ''        If nr.linetype = "CCHG" Then
    ''            dft.Fill(df.CoursePricing, nr.coursepk, rYearLevel)
    ''            For idx = 0 To df.CoursePricing.Rows.Count - 1
    ''                ds.TemplateEnrollment.AddTemplateEnrollmentRow(clsTool.getCourseName(nr.coursepk), clsTool.getCourseName(nr.coursepk), "COURSE CHARGES", "ENROLLED", clsTool.getTrTypeName(df.CoursePricing(idx).TRPK), df.CoursePricing(idx).Amount)
    ''            Next
    ''        End If
    ''    Next
    ''    For ctr = 0 To ds.WhiteForm.Rows.Count - 1
    ''        Dim nr As dsRegistrar.WhiteFormRow = ds.WhiteForm(ctr)
    ''        If nr.linetype = "SCHG" Then
    ''            Dim sp As Boolean = clsTool.ClassSP(nr.coursepk)
    ''            Dim syopk As Integer = -1
    ''            Dim ndx As Integer
    ''            Dim ent As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
    ''            ent.Fill(ds.EnrollSubjects, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, Me.m_Student)
    ''            For ndx = 0 To ds.EnrollSubjects.Rows.Count - 1
    ''                If ds.EnrollSubjects(ndx).subjectpk = nr.subjectpk Then
    ''                    syopk = ds.EnrollSubjects(ndx).syofferingpk
    ''                    Exit For
    ''                End If
    ''            Next
    ''            dst.Fill(df.CourseSubjectPricing, nr.coursepk, nr.subjectpk)
    ''            For idx = 0 To df.CourseSubjectPricing.Rows.Count - 1
    ''                ds.TemplateEnrollment.AddTemplateEnrollmentRow(clsTool.getCourseName(nr.coursepk), clsTool.GetSubjectDescription(nr.subjectpk), IIf(sp, "Special Class", gSked(syopk)), "ENROLLED", clsTool.getTrTypeName(df.CourseSubjectPricing(idx).TRPk), df.CourseSubjectPricing(idx).Amount)
    ''            Next
    ''        End If
    ''    Next

    ''    Dim rep As New crEnroll
    ''    rep.SetDataSource(ds)
    ''    rep.SetParameterValue("EDATE", eDate.Date)
    ''    rep.SetParameterValue("STUDENTNAME", Me.txtStudent.Text)
    ''    rep.SetParameterValue("YEARLEVEL", rYearLevel)
    ''    rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
    ''    rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
    ''    rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
    ''    rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
    ''    Me.CrystalReportViewer1.ReportSource = rep
    ''    Me.CrystalReportViewer1.RefreshReport()
    ''    Me.CrystalReportViewer1.Zoom(75)
    ''    frmw.Hide()
    ''End Sub

#End Region

    'LOAD button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.m_Student = -1 Then MsgBox("Please select student!") : Exit Sub
        loadWhiteForm()
    End Sub
    'ben10.2.2007 . This white form procedure same as uEnrollment white form loading.
    Private Sub loadWhiteForm()
   
        'start ledger filling
        Dim ds As New dsRegistrar

        'check EnrollHeader record
        Dim dest As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        dest.Fill(ds.EnrollHeader, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, Me.m_Student)
        If ds.EnrollHeader.Rows.Count <= 0 Then
            MsgBox("No Enrollment Header!")
            Exit Sub
        End If
        If ds.EnrollHeader(0).IsyrlevelNull Then
            MsgBox("No year level finalized!")
            Exit Sub
        End If

        'check ledger
        Dim dtx As New dsRegistrarTableAdapters.WhiteFormTableAdapter
        dtx.Fill(ds.WhiteForm, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, Me.m_Student)
        If ds.WhiteForm.Rows.Count <= 0 Then MsgBox("No Ledger Records Found! ") : Exit Sub

        'check enrolled subjects
        Dim dtEnrollSubj As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dtEnrollSubj.Fill(ds.EnrollSubjects, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, Me.m_Student)
        If ds.EnrollSubjects.Rows.Count <= 0 Then MsgBox("No subjects enlisted!") : Exit Sub
        Dim i As Integer
        Dim hasEnrolled As Boolean = False
        For i = 0 To ds.EnrollSubjects.Rows.Count - 1
            If ds.EnrollSubjects(i).status = 1 Then hasEnrolled = True : Exit For
        Next
        If hasEnrolled = False Then MsgBox("No Enrolled Subjects!") : Exit Sub

        Me.CrystalReportViewer1.ReportSource = clsWhiteForm.loadWhiteForm(Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, Me.m_Student)
        Me.CrystalReportViewer1.RefreshReport()
        Me.CrystalReportViewer1.Zoom(75)

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

#Region "Old gSked Function"
    ''Function gSked(ByVal id As Integer) As String
    ''    If id = -1 Then Return "NONE"
    ''    Dim ds As New dsRegistrar
    ''    Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
    ''    dt.Fill(ds.SYOfferingbyPK, id)
    ''    If ds.SYOfferingbyPK.Rows.Count = 0 Then Return "NOT FOUND"
    ''    Dim r As dsRegistrar.SYOfferingbyPKRow = ds.SYOfferingbyPK(0)
    ''    Dim s As String = clsTool.getTeacherName(r.teacherid) & "-" & clsTool.getResourceName(r.resource) & ":"
    ''    If r.monday Then s = s & "Mon:" & clsTool.getTime(CDate(r.monfrom)) & "-" & clsTool.getTime(CDate(r.monto)) & "/"
    ''    If r.tuesday Then s = s & "Tue:" & clsTool.getTime(CDate(r.tuesfrom)) & "-" & clsTool.getTime(CDate(r.tuesto)) & "/"
    ''    If r.wednesday Then s = s & "Wed:" & clsTool.getTime(CDate(r.wedfrom)) & "-" & clsTool.getTime(CDate(r.wedto)) & "/"
    ''    If r.thursday Then s = s & "Thu:" & clsTool.getTime(CDate(r.thufrom)) & "-" & clsTool.getTime(CDate(r.thuto)) & "/"
    ''    If r.alternatefriday Then
    ''        If r.friday Then s = s & "Alt-Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
    ''    Else
    ''        If r.friday Then s = s & "Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
    ''    End If
    ''    If r.saturday Then s = s & "Sat:" & clsTool.getTime(CDate(r.satfrom)) & "-" & clsTool.getTime(CDate(r.satto)) & "/"
    ''    If r.sunday Then s = s & "Sun:" & clsTool.getTime(CDate(r.sunfrom)) & "-" & clsTool.getTime(CDate(r.sunto))
    ''    If s.Substring(s.Length - 1, 1) = "/" Then s = s.Substring(0, s.Length - 1)
    ''    Return s
    ''End Function
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Student = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName
            loadWhiteForm()
        End If
    End Sub
End Class
