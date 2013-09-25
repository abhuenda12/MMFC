Public Class uReceivables
    'ben10.9.2007 added 2 lines below
    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""

    Public Sub LoadData()
        Me.chkAllStudents.Checked = True
        Me.rdoAllBalance.Checked = True
        Me.rdoAlldays.Checked = True
        'benCommented out 5 lines below 10.9.2007
        ''Me.ChargeScheduleTableAdapter.Fill(Me.DsFinance.ChargeSchedule)
        ''Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        ''Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        ''Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        ''Me.txtSem.SelectedValue = clsTool.GetCurSemPK
    End Sub
    

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    
#Region "Old Retrieve Code"
    ''Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ''    Dim ds As New dsRegistrar
    ''    Dim dst As New dsRegistrarTableAdapters.StudentsTableAdapter
    ''    dst.Fill(ds.Students, "%")
    ''    Dim df As New dsFinance
    ''    Dim dft As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter
    ''    Dim ctr As Integer
    ''    Dim frm As New frmWait
    ''    Dim drep As New dsRep
    ''    frm.Show()
    ''    Application.DoEvents()
    ''    For ctr = 0 To ds.Students.Rows.Count - 1
    ''        frm.lblStat.Text = "Processing: " & ctr.ToString & " of " & ds.Students.Rows.Count.ToString
    ''        dft.Fill(df.LedgerbyStudent, ds.Students(ctr).StudentPK)
    ''        Dim idx As Integer
    ''        Dim xBal As Double = 0
    ''        Dim xReceipts As Double = 0
    ''        Dim xCharges As Double = 0
    ''        Dim xCourse As Integer = -1
    ''        For idx = 0 To df.LedgerbyStudent.Rows.Count - 1
    ''            If xCourse = -1 Then
    ''                xCourse = df.LedgerbyStudent(idx).coursepk
    ''            End If
    ''            Dim rl As dsFinance.LedgerbyStudentRow = df.LedgerbyStudent(idx)
    ''            If rl.linetype = "RCPT" Then
    ''                xBal = xBal - rl.amount
    ''                If rl.sypk = Me.txtSY.SelectedValue And rl.sempk = Me.txtSem.SelectedValue Then
    ''                    xReceipts = xReceipts + rl.amount
    ''                End If
    ''            Else
    ''                xBal = xBal + rl.amount
    ''                If rl.sypk = Me.txtSY.SelectedValue And rl.sempk = Me.txtSem.SelectedValue Then
    ''                    xCharges = xCharges + rl.amount
    ''                End If
    ''            End If
    ''        Next

    ''        If xBal <> 0 Then
    ''            Dim dte As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
    ''            Dim de As New dsRegistrar
    ''            dte.Fill(de.EnrollHeader, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, ds.Students(ctr).StudentPK)
    ''            If de.EnrollHeader.Rows.Count > 0 Then
    ''                Dim yrLevel As Integer = -1
    ''                If Not de.EnrollHeader(0).IsyrlevelNull Then yrLevel = de.EnrollHeader(0).yrlevel
    ''                Dim xCourseRequired As Double = 0
    ''                Dim sOrder As String = Me.DsFinance.ChargeSchedule(Me.ChargeScheduleBindingSource.Position).sortorder
    ''                Dim cidx As Integer
    ''                For cidx = 0 To Me.DsFinance.ChargeSchedule.Rows.Count - 1
    ''                    If Me.DsFinance.ChargeSchedule(cidx).sortorder <= sOrder Then
    ''                        Dim dxf As New dsFinance
    ''                        Dim dxft As New dsFinanceTableAdapters.SemAmortTableAdapter
    ''                        dxft.Fill(dxf.SemAmort, xCourse, Me.DsFinance.ChargeSchedule(cidx).pk, yrLevel)
    ''                        If dxf.SemAmort.Rows.Count > 0 Then
    ''                            xCourseRequired = xCourseRequired + dxf.SemAmort(0).Charge
    ''                        End If
    ''                    End If
    ''                Next
    ''                drep.ReceivablesReport.AddReceivablesReportRow(ds.Students(ctr).StudentID, ds.Students(ctr).StudentName, xBal, xReceipts, IIf(xCharges > xCourseRequired, xCourseRequired - xReceipts, 0), xBal - xCharges)
    ''            End If
    ''        End If
    ''    Next
    ''    Dim rep As New crReceivables
    ''    rep.SetDataSource(drep)
    ''    rep.SetParameterValue("pSY", Me.txtSY.Text)
    ''    rep.SetParameterValue("pSem", Me.txtSem.Text)
    ''    rep.SetParameterValue("pPeriod", Me.txtPaymentSked.Text)
    ''    rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
    ''    rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
    ''    rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
    ''    rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
    ''    Me.CrystalReportViewer1.ReportSource = rep
    ''    Me.CrystalReportViewer1.RefreshReport()
    ''    frm.Hide()
    ''End Sub
#End Region

    'Choose Student Button ben10.9.2007
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmStudentSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.m_StudentName = frm.m_StudentName
            Me.txtStudentName.Text = frm.m_StudentName
        End If
    End Sub

    'ben10.9.2007
    'Retrieve Button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        retrieveReport()
    End Sub

    Private Sub retrieveReport()
        If Me.m_StudentPK = -1 And Me.chkAllStudents.Checked = False Then MsgBox("Choose a student or check all ! ") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        'get student list
        Dim dsR As New dsRegistrar
        Dim dst As New dsRegistrarTableAdapters.StudentsTableAdapter
        If Me.chkAllStudents.Checked Then
            dst.Fill(dsR.Students, "%")
        Else
            dst.Fill(dsR.Students, Me.m_StudentName)
        End If

        'get Ledger per student 
        Dim i As Integer
        Dim dsF As New dsFinance
        Dim dtL As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter

        For i = 0 To dsR.Students.Rows.Count - 1
            'fill ledger
            dtL.Fill(dsF.LedgerbyStudent, dsR.Students(i).StudentPK)
            'check for records
            If dsF.LedgerbyStudent.Rows.Count <= 0 Then Continue For

            Dim totalCharges As Double = 0
            Dim totalPayments As Double = 0
            Dim balance As Double = 0
            Dim lastTranType As String = ""
            Dim lastPayDate As Date = "1/1/1900"
            Dim lastPayAmount As Double = 0
            Dim lastTranDate As Date = "1/1/1900"
            Dim lastTranAge As Integer = 0
            Dim j As Integer

            'sum charges. loop ledger.
            For j = 0 To dsF.LedgerbyStudent.Rows.Count - 1
                With dsF.LedgerbyStudent(j)
                    If .linetype = "RCPT" Then
                        totalPayments += .amount
                        lastPayDate = .ledgerdate.Date
                        lastPayAmount = .amount
                    Else
                        totalCharges += .amount
                    End If
                    lastTranType = .linetype                    
                End With
            Next

            balance = totalCharges - totalPayments
            lastTranDate = dsF.LedgerbyStudent.Compute("Max(ledgerdate)", String.Empty)
            lastTranAge = DateDiff(DateInterval.Day, lastTranDate, Now().Date)

            'Filter by choice of Balance and Age
            Dim withBalance As Boolean = Me.rdoWithBalance.Checked
            Dim Optionage As Integer = 0
            If Me.rdoAlldays.Checked Then
                Optionage = 0
            ElseIf Me.rdo15days.Checked Then
                Optionage = 15
            ElseIf Me.rdo30days.Checked Then
                Optionage = 30
            Else
                Optionage = 60
            End If

            'compare variables to filter
            If lastTranAge >= Optionage Then
                If withBalance Then
                    'include those with balance only
                    If balance > 0 Then
                        dsF.TemplateReceivables.AddTemplateReceivablesRow(totalCharges, totalPayments, _
                            balance, dsR.Students(i).StudentName, lastPayDate, lastPayAmount, lastTranDate, lastTranType, lastTranAge)
                    End If
                Else  'All balances including 0
                    dsF.TemplateReceivables.AddTemplateReceivablesRow(totalCharges, totalPayments, _
                        balance, dsR.Students(i).StudentName, lastPayDate, lastPayAmount, lastTranDate, lastTranType, lastTranAge)
                End If
            End If

        Next

        REM Start Report
        Dim rep As New crReceivables
        rep.SetDataSource(dsF)
        rep.SetParameterValue("pSY", clsTool.GetCurYear)
        rep.SetParameterValue("pSem", clsTool.GetCurSem)
        ''rep.SetParameterValue("pPeriod", Me.txtPaymentSked.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()

    End Sub
End Class
