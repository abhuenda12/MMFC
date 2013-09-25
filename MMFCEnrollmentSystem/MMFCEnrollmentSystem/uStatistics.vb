Public Class uStatistics
    'ben10.19.2007 

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If CheckBoxMatrix.Checked Then

            generateMatrix()

        Else
            generateReport()

        End If
        End Sub

    Private Sub generateReport()
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim ds As New dsRep
        Dim semsy As String = Me.txtSEM.Text + "," + Me.txtSY.Text
        Dim subgroup As String = ""
        Dim subgroupitem As String = ""
        Dim enrollcount As Int64 = 0
        Dim percent As Decimal = 0

        'Get count per gender
        Dim dsSex As New dsRep.EnrollHeaderCountbySexDataTable
        Dim dtSex As New dsRepTableAdapters.EnrollHeaderCountbySexTableAdapter
        dtSex.Fill(dsSex, Me.txtSY.SelectedValue, Me.txtSEM.SelectedValue)
        Dim i As Integer
        If dsSex.Rows.Count > 0 Then
            For i = 0 To dsSex.Rows.Count - 1
                subgroup = "SEX"
                If dsSex(i).IsGenderNull Then dsSex(i).Gender = "Unclassified"
                subgroupitem = dsSex(i).Gender
                If dsSex(i).IsGenderCountNull Then dsSex(i).GenderCount = 0
                enrollcount = dsSex(i).GenderCount
                percent = 100 * enrollcount / dsSex.Compute("Sum(GenderCount)", String.Empty)

                ds.TemplateStatisticsReport.AddTemplateStatisticsReportRow(semsy, subgroup, subgroupitem, enrollcount, percent)
            Next
        End If

        'Get count per course
        Dim dsCourse As New dsRep.EnrollSubjectCountbyCourseDataTable
        Dim dtCourse As New dsRepTableAdapters.EnrollSubjectCountbyCourseTableAdapter
        dtCourse.Fill(dsCourse, Me.txtSY.SelectedValue, Me.txtSEM.SelectedValue)

        If dsCourse.Rows.Count > 0 Then
            For i = 0 To dsCourse.Rows.Count - 1
                subgroup = "COURSE"
                subgroupitem = clsTool.getCourseName(dsCourse(i).coursepk)
                If dsCourse(i).IsEnrollCountNull Then dsCourse(i).EnrollCount = 0
                enrollcount = dsCourse(i).EnrollCount
                percent = 100 * enrollcount / dsCourse.Compute("Sum(EnrollCount)", String.Empty)

                ds.TemplateStatisticsReport.AddTemplateStatisticsReportRow(semsy, subgroup, subgroupitem, enrollcount, percent)
            Next
        End If

        'Get count per year level
        Dim dsYr As New dsRep.EnrollHeaderCountbyyearlevelDataTable
        Dim dtYr As New dsRepTableAdapters.EnrollHeaderCountbyyearlevelTableAdapter
        dtYr.Fill(dsYr, Me.txtSY.SelectedValue, Me.txtSEM.SelectedValue)

        If dsYr.Rows.Count > 0 Then
            For i = 0 To dsYr.Rows.Count - 1
                subgroup = "YEAR LEVEL"
                If dsYr(i).IsyrlevelNull Then dsYr(i).yrlevel = -1
                subgroupitem = clsTool.GetYearLevelFull(dsYr(i).yrlevel)
                If dsYr(i).IsEnrollCountNull Then dsYr(i).EnrollCount = 0
                enrollcount = dsYr(i).EnrollCount
                percent = 100 * enrollcount / dsYr.Compute("Sum(EnrollCount)", String.Empty)

                ds.TemplateStatisticsReport.AddTemplateStatisticsReportRow(semsy, subgroup, subgroupitem, enrollcount, percent)
            Next
        End If

        'Get count per subject
        Dim dsSub As New dsRep.EnrollSubjectCountbySubjectDataTable
        Dim dtSub As New dsRepTableAdapters.EnrollSubjectCountbySubjectTableAdapter
        dtSub.Fill(dsSub, Me.txtSY.SelectedValue, Me.txtSEM.SelectedValue)

        If dsSub.Rows.Count > 0 Then
            For i = 0 To dsSub.Rows.Count - 1
                subgroup = "SUBJECT"
                If dsSub(i).IsEnrollCountNull Then dsSub(i).EnrollCount = 0
                subgroupitem = clsTool.GetSubjectCode(dsSub(i).subjectpk)
                enrollcount = dsSub(i).EnrollCount
                percent = 100 * enrollcount / dsSub.Compute("Sum(EnrollCount)", String.Empty)

                ds.TemplateStatisticsReport.AddTemplateStatisticsReportRow(semsy, subgroup, subgroupitem, enrollcount, percent)
            Next
        End If

        Dim rep As New crStatistics
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


    Private Sub generateMatrix()

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim ds As New dsRep
        Dim dt As New dsRepTableAdapters.StudentsCrosstabTableAdapter

        dt.Fill(ds.StudentsCrosstab, txtSY.SelectedValue, txtSEM.SelectedValue)

        Dim rep As New crStudentsCrosstab
        rep.SetDataSource(ds)
        ''rep.SetParameterValue("pSY", Me.txtSY.Text)
        ''rep.SetParameterValue("pSem", Me.txtSEM.Text)
        ''rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        ''rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        ''rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        ''rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()


        frm.Hide()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
End Class
