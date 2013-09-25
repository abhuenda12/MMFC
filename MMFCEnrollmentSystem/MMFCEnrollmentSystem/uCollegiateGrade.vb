Public Class uCollegiateGrade

    'ben10.17.2007
    'Copied from uClassList

    Public m_Class As Integer = -1
    Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSem.SelectedValue = clsTool.GetCurSemPK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmClassSelect2
        frm.m_SY = Me.txtSY.SelectedValue
        frm.m_SEM = Me.txtSem.SelectedValue
        frm.LoadGrid()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Class = frm.m_SYOfferingPK
            Me.txtClass.Text = clsTool.GetSubjectDescription(frm.m_Subject)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.m_Class = -1 Then MsgBox("Please select class") : Exit Sub
        Dim dsr As New dsRegistrar
        Dim drt As New dsRegistrarTableAdapters.ClassListTableAdapter
        Dim ds As New dsRep
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        drt.Fill(dsr.ClassList, Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, Me.m_Class)
        If dsr.ClassList.Rows.Count = 0 Then MsgBox("No Records Found!") : frm.Hide() : Exit Sub
        Dim ctr As Integer
        Dim yearlevel As String = ""
        Dim course As String = ""

        'ben10.17.2007
        For ctr = 0 To dsr.ClassList.Rows.Count - 1
            yearlevel = clsTool.GetYearLevel(Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, dsr.ClassList(ctr).studentpk)
            If yearlevel.Length > 3 Then yearlevel = yearlevel.Substring(0, 3)
            course = clsTool.getStudentCourseCode(Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, dsr.ClassList(ctr).studentpk)

            ds.CollegiateGradingSheet.AddCollegiateGradingSheetRow(Me.m_Class, clsTool.getStudentName(dsr.ClassList(ctr).studentpk), yearlevel, course)
        Next

        Dim rep As New crCollegiateGradingSheet  'modified
        Dim dr As New dsRegistrar
        Dim dtr As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dtr.Fill(dr.SYOfferingbyPK, Me.m_Class)
        Dim r As dsRegistrar.SYOfferingbyPKRow = dr.SYOfferingbyPK(0)
        Dim daysked As String = ""
        Dim timesked As String = ""

        daysked = clsTool.getSYOfferDays(r.syofferingpk)
        timesked = clsTool.getSYOfferStart(r.syofferingpk) + " to " + clsTool.getSYOfferEnd(r.syofferingpk)

        'ben10.17.2007 Commented out lines below
        '' ''If r.monday Then s = s & "Mon:" & clsTool.getTime(CDate(r.monfrom)) & "-" & clsTool.getTime(CDate(r.monto)) & "/"
        '' ''If r.tuesday Then s = s & "Tue:" & clsTool.getTime(CDate(r.tuesfrom)) & "-" & clsTool.getTime(CDate(r.tuesto)) & "/"
        '' ''If r.wednesday Then s = s & "Wed:" & clsTool.getTime(CDate(r.wedfrom)) & "-" & clsTool.getTime(CDate(r.wedto)) & "/"
        '' ''If r.thursday Then s = s & "Thu:" & clsTool.getTime(CDate(r.thufrom)) & "-" & clsTool.getTime(CDate(r.thuto)) & "/"
        '' ''If r.alternatefriday Then
        '' ''    If r.friday Then s = s & "Alt-Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
        '' ''Else
        '' ''    If r.friday Then s = s & "Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
        '' ''End If
        '' ''If r.saturday Then s = s & "Sat:" & clsTool.getTime(CDate(r.satfrom)) & "-" & clsTool.getTime(CDate(r.satto)) & "/"
        '' ''If r.sunday Then s = s & "Sun:" & clsTool.getTime(CDate(r.sunfrom)) & "-" & clsTool.getTime(CDate(r.sunto))
        '' ''If s.Substring(s.Length - 1, 1) = "/" Then s = s.Substring(0, s.Length - 1)

        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.txtSY.Text)
        rep.SetParameterValue("pSem", Me.txtSem.Text)
        rep.SetParameterValue("pTeacher", clsTool.getTeacherName(dr.SYOfferingbyPK(0).teacherid))
        rep.SetParameterValue("pSubject", clsTool.GetSubjectDescription(dr.SYOfferingbyPK(0).subjectpk))
        rep.SetParameterValue("pResource", clsTool.getResourceName(dr.SYOfferingbyPK(0).resource))
        'benmodified . 10.17.2007
        rep.SetParameterValue("pSchedule", timesked + " at " + daysked)

        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()
        frm.Hide()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
End Class
