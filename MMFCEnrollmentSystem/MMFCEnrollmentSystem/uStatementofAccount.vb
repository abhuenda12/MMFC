Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class uStatementofAccount

    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""

    '===========================================================
    ' this report will have 2 groupings
    ' a. Tuition 
    ' b. Miscellaneous  (includes RLE,TUTOR,BACKACCOUNTS,etc)   
    ' * will use same dataset as Student Ledger
    '===========================================================

    'benJan 28 2008 
    Private Sub GenRepSAO()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.LedgerandOrbyStudentTableAdapter
        Dim dsRep As New dsRep

        dt.Fill(ds.LedgerandOrbyStudent, Me.m_StudentPK, Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue)

        If ds.LedgerandOrbyStudent.Rows.Count <= 0 Then MsgBox("No Records for that student.") : frm.Hide() : Exit Sub

        '=========================================================================
        'Variables
        Dim i As Integer
        Dim tuitiontotal As Decimal = 0
        Dim misctotal As Decimal = 0
        Dim otherfees As Decimal = 0  'for other SCHG nonTuition fees  ''check this again if still needed
        Dim rlecharges As Decimal = 0
        'Ben 5.30.2008 Modified BackAccount source value
        ''Dim backaccounts As Decimal = 0        
        Dim backaccounts As Decimal = clsTool2.getStudentBackAccount(Me.m_StudentPK, Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue)
        Dim tutorial As Decimal = 0
        Dim requestedfee As Decimal = 0 'for requested subjects both NCM and nonNCM 
        Dim enrolledunits As Integer = clsTool.getStudentEnrolledUnits(Me.m_StudentPK, _
                                               Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue)
        Dim coursecode As String = clsTool.getStudentCourseCode(Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue, Me.m_StudentPK)
        Dim coursepk As Integer = clsTool.getCoursePKgivenCode(coursecode)
        Dim coursename As String = clsTool.getCourseName(coursepk)
        ' Ben 6.4.2008 Workaround for tuition fee 
        ''Dim tuitionfee As Decimal = clsTool.getCourseTuition(coursepk)
        Dim tuitionfee As Decimal = clsTool.getTuitionbySemStudentSypk(Me.m_StudentPK, Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue, coursepk)
        '===========================================================================

        For i = 0 To ds.LedgerandOrbyStudent.Rows.Count - 1
            With ds.LedgerandOrbyStudent(i)

                Select Case .linetype
                    Case "SCHG"
                        'as of coding , we have 8 TRCODES plus the trpk = -1 which is the non-NCM requested subject
                        If .IsTranCodeNull Then .TranCode = ""
                        If .IsEnrollSubjectCostLineAmountNull Then .EnrollSubjectCostLineAmount = 0

                        If .TranCode.ToUpper = "TUITION" Then
                            tuitiontotal += .EnrollSubjectCostLineAmount

                        ElseIf .TranCode.ToUpper = "RLE" Or .TranCode.ToUpper = "INTERNSHIP" Then
                            rlecharges += .EnrollSubjectCostLineAmount

                        ElseIf .TranCode.ToUpper = "RLE REQUEST" Then  'This is for the NCM-Type REQUESTED subjects
                            requestedfee += .EnrollSubjectCostLineAmount

                            'Trtype charge but display as misc
                            'insert the misc record below along with other misc charges from semamort table
                        ElseIf .TranCode.ToUpper = "CHN KIT" Or .TranCode.ToUpper = "PHARAPHERNALIA" _
                          Or .TranCode.ToUpper = "SCRUBSUIT" Or .TranCode.ToUpper = "COMM. EXTENSION" Then
                            misctotal += .EnrollSubjectCostLineAmount

                            'for trpk = -1 , datatable will return OTHERS 
                        ElseIf .TranCode = "OTHERS" Then
                            'check if nonNCM-Type requested subject
                            If .IsRequestTypeNull Then .RequestType = ""
                            If .RequestType = "REQUEST" Then
                                requestedfee += .EnrollSubjectCostLineAmount
                            End If
                        End If

                        'Miscellaneous Fees dbo.SemAmort
                    Case "MISC"
                        misctotal += .LedgerAmount

                        'Back Accounts
                    Case "OCHG"
                        REM Ben 5.20.2008 BACK ACCOUNTS is now computed from balances                    
                        ''backaccounts += .LedgerAmount


                        'Receipts/Payments
                    Case "RCPT"
                        'do nothing
                    Case "TUTOR"
                        otherfees += .LedgerAmount
                End Select
            End With
        Next

        Dim runningBalance As Decimal = 0

        '==============================================================================
        'ADD MISC DETAILS HERE from semamort table
        Dim dsMisc As New dsFinance.SemAmortbyStudentYearSemPKDataTable
        Dim dtMisc As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        dtMisc.Fill(dsMisc, Me.m_StudentPK, Me.cmbSY.SelectedValue, Me.cmbSem.SelectedValue)

        If dsMisc.Rows.Count > 0 Then

            Dim miscName As String = ""
            For i = 0 To dsMisc.Rows.Count - 1
                With dsMisc(i)
                    miscName = clsTool.getChargeSchedName(.ChargeSchedPK)
                    runningBalance += .Charge

                    dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     " & miscName, .Charge, 0)
                End With
            Next
        End If

        'insert NON tuition TR TYPES 
        For i = 0 To ds.LedgerandOrbyStudent.Rows.Count - 1
            With ds.LedgerandOrbyStudent(i)
                If .IsTranCodeNull Then .TranCode = ""
                If .linetype = "SCHG" Then
                    'MISC TYPE TRAMOUNTS                    
                    If .TranCode.ToUpper = "CHN KIT" Or .TranCode.ToUpper = "PHARAPHERNALIA" _
                       Or .TranCode.ToUpper = "SCRUBSUIT" Or .TranCode.ToUpper = "COMM. EXTENSION" Then

                        If .IsEnrollSubjectCostLineAmountNull Then .EnrollSubjectCostLineAmount = 0
                        runningBalance += .EnrollSubjectCostLineAmount

                        dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     " & .TranCode, .EnrollSubjectCostLineAmount, 0)
                    End If
                End If
            End With
        Next

        'TUTORIAL here
        runningBalance += otherfees
        dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     TUTORIAL CHARGES", otherfees, 0)

        'Back accounts here
        runningBalance += backaccounts
        dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     BACK ACCOUNTS", backaccounts, runningBalance)

        'RLE Fees
        If rlecharges > 0 Then dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     RLE", rlecharges, rlecharges)

        'Requested Subjects Fee (Both NCM and non-NCM)
        If requestedfee > 0 Then dsRep.TemplateSAO.AddTemplateSAORow("1", "MISCELLANEOUS", "     REQUESTED SUBJECTS", requestedfee, requestedfee)

        'TUITION   
        Dim tuitionheaderline As String = "     Add: Tuition fee per unit for " & Me.cmbSem.Text & " Semester " & Me.cmbSY.Text & " is " & tuitionfee
        dsRep.TemplateSAO.AddTemplateSAORow("2", "TUITION", tuitionheaderline, 0, 0)
        dsRep.TemplateSAO.AddTemplateSAORow("2", "TUITION", "      " & tuitionfee & "      x       " & enrolledunits, tuitiontotal, tuitiontotal)

        Dim rep2 As New crStatementofAccount
        rep2.SetDataSource(dsRep)
        rep2.SetParameterValue("STUDENT", Me.m_StudentName)
        rep2.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep2.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep2.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep2.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep2.SetParameterValue("SEMSY", Me.cmbSem.Text & " " & Me.cmbSY.Text)
        rep2.SetParameterValue("COURSE", coursename)
        rep2.SetParameterValue("SAO", clsTool.GetSetting("SAO"))

        Me.CrystalReportViewer1.ReportSource = rep2
        Me.CrystalReportViewer1.RefreshReport()

        frm.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.GenRepSAO()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.M_StudentName = frm.m_StudentName
            TextBox1.Text = frm.m_StudentName
            GenRepSAO()
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub uStudentLedger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.cmbSem.SelectedValue = clsTool.GetCurSemPK()
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK()
    End Sub

   
End Class
