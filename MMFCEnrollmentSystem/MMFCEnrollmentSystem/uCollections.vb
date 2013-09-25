Public Class uCollections
    'Created ben11.23.2007 
    'Client Request

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
        Me.chkHistory.Checked = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.chkHistory.Checked Then
            loadReportHistory()
        Else
            loadReport()
        End If
    End Sub
    Private Sub loadReportHistory()
        Dim ds As New dsRep
        Dim dsL As New dsFinance.AssessmentperCourseDataTable
        Dim dtL As New dsFinanceTableAdapters.AssessmentperCourseTableAdapter
        dtL.Fill(dsL, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
        'fill up TemplateCollectionsHistoryReport. get all ledger records for semester and yearpk
        If dsL.Rows.Count <= 0 Then MsgBox("No records!") : Exit Sub

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim course As String = ""
        Dim studentcount As Integer = 0
        Dim totalass As Double = 0
        Dim totaldp As Double = 0
        Dim balance As Double = 0
        Dim moincome As Double = 0
        Dim exam1amt As Double = 0
        Dim exam1bal As Double = 0
        Dim exam2amt As Double = 0
        Dim exam2bal As Double = 0
        Dim exam3amt As Double = 0
        Dim exam3bal As Double = 0
        Dim exam4amt As Double = 0
        Dim exam4bal As Double = 0
        Dim exam5amt As Double = 0
        Dim exam5bal As Double = 0
        Dim paid1st As Integer = 0
        Dim paid2nd As Integer = 0
        Dim paid3rd As Integer = 0
        Dim paid4th As Integer = 0
        Dim paid5th As Integer = 0

        Dim i As Integer
        For i = 0 To dsL.Rows.Count - 1
            course = clsTool.getCourseCode(dsL(i).coursepk)
            studentcount = clsTool.getCourseStudentCount(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
            totalass = dsL(i).amount
            totaldp = clsTool.getDPperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
            balance = totalass - totaldp
            moincome = balance / 5
            exam1amt = clsTool.getPaymentsperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 1)
            exam2amt = clsTool.getPaymentsperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 2)
            exam3amt = clsTool.getPaymentsperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 3)
            exam4amt = clsTool.getPaymentsperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 4)
            exam5amt = clsTool.getPaymentsperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 5)
            exam1bal = moincome - exam1amt
            exam2bal = moincome - exam2amt
            exam3bal = moincome - exam3amt
            exam4bal = moincome - exam4amt
            exam5bal = moincome - exam5amt
            paid1st = clsTool.getPaidStudentsperPeriod(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 1)
            paid2nd = clsTool.getPaidStudentsperPeriod(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 2)
            paid3rd = clsTool.getPaidStudentsperPeriod(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 3)
            paid4th = clsTool.getPaidStudentsperPeriod(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 4)
            paid5th = clsTool.getPaidStudentsperPeriod(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, 5)

            ds.TemplateCollectionsHistoryReport.AddTemplateCollectionsHistoryReportRow(course, studentcount, totalass, totaldp, balance, moincome, _
                     exam1amt, exam1bal, exam2amt, exam2bal, exam3amt, exam3bal, exam4amt, exam4bal, exam5amt, exam5bal, _
                     studentcount - paid1st, studentcount - paid2nd, studentcount - paid3rd, studentcount - paid4th, studentcount - paid5th)
        Next

        'per Exam or Complete
        If Me.chkHistory.Checked Then
            Dim rep As New crTotalIncomeHistory
            rep.SetDataSource(ds)
            rep.SetParameterValue("pSY", Me.txtSY.Text)
            rep.SetParameterValue("pSem", Me.txtSEM.Text)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            Me.CrystalReportViewer1.ReportSource = rep
            Me.CrystalReportViewer1.RefreshReport()
        Else
            Dim examno As Integer = 0
            If Me.rdo1st.Checked Then
                examno = 1
            ElseIf Me.rdo2nd.Checked Then
                examno = 2
            ElseIf Me.rdo3rd.Checked Then
                examno = 3
            ElseIf Me.rdo4th.Checked Then
                examno = 4
            ElseIf Me.rdo5th.Checked Then
                examno = 5
            End If


            If Me.rdoType1.Checked Then
                'Type 1 = Summary of Collected and Uncollected Amt per course 
                Dim rep As New crTotalIncomePerExam
                rep.SetDataSource(ds)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("EXAMNO", examno)
                Me.CrystalReportViewer1.ReportSource = rep
                Me.CrystalReportViewer1.RefreshReport()
            ElseIf Me.rdoType2.Checked Then
                'Type 2 = Expected Collectibles per course
                Dim rep As New crTotalIncomeExpectedCollectibles
                rep.SetDataSource(ds)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("EXAMNO", examno)
                Me.CrystalReportViewer1.ReportSource = rep
                Me.CrystalReportViewer1.RefreshReport()

            ElseIf Me.rdoType3.Checked Then
                'Type 3 = Summary report of collection
                Dim rep As New crTotalIncomeSummaryCollection
                rep.SetDataSource(ds)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("EXAMNO", examno)
                Me.CrystalReportViewer1.ReportSource = rep
                Me.CrystalReportViewer1.RefreshReport()

            End If

        End If

        frm.Hide()

    End Sub
    'THIS IS THE BIRDS EYEVIEW REPORT showing the whole SEMESTER INCOME
    Private Sub loadReport()
        Dim ds As New dsRep
        Dim dsL As New dsFinance.AssessmentperCourseDataTable
        Dim dtL As New dsFinanceTableAdapters.AssessmentperCourseTableAdapter
        dtL.Fill(dsL, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
        'fill up TemplateCollectionsReport. get all ledger records for semester and yearpk
        If dsL.Rows.Count <= 0 Then MsgBox("No records!") : Exit Sub

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim course As String = ""
        Dim studentcount As Integer = 0
        Dim totalass As Double = 0
        Dim totaldp As Double = 0
        Dim balance As Double = 0
        Dim moincome As Double = 0

        Dim i As Integer
        For i = 0 To dsL.Rows.Count - 1
            course = clsTool.getCourseCode(dsL(i).coursepk)
            studentcount = clsTool.getCourseStudentCount(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
            totalass = dsL(i).amount
            totaldp = clsTool.getDPperCourse(dsL(i).coursepk, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue)
            balance = totalass - totaldp
            moincome = balance / 5

            ds.TemplateCollectionsReport.AddTemplateCollectionsReportRow(course, studentcount, totalass, totaldp, balance, moincome)
        Next

        Dim rep As New crTotalIncome
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

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub chkHistory_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHistory.CheckedChanged
        If Me.chkHistory.Checked Then
            Me.GroupBox1.Visible = True
            Me.rdo1st.Checked = True
            Me.grpReportType.Visible = True
            Me.rdoType1.Checked = True
        Else
            Me.GroupBox1.Visible = False
            Me.grpReportType.Visible = False
        End If
    End Sub


    Private Sub rdoAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHistory.CheckedChanged
        If Me.chkHistory.Checked Then
            Me.grpReportType.Visible = False   'rdoAll is for report of ALL PERIODS
        Else
            Me.grpReportType.Visible = True
            Me.rdoType1.Checked = True
        End If
    End Sub
End Class
