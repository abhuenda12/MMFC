Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class uStudentLedger

    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""
    Dim rep As New crStudentLedger

    Public Sub GenRepDetails()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter
        ds.LedgerbyStudent.Clear()
        dt.Fill(ds.LedgerbyStudent, Me.m_StudentPK)

        ds.TemplateStudentLedger.Clear()

        If ds.LedgerbyStudent.Rows.Count = 0 Then MsgBox("No ledger transactions found!") : Exit Sub


        Me.CrystalReportViewer1.ReportSource = clsStudentLedger.loadStudentLedgerALLDetails( _
                                                        Me.m_StudentPK, ds.LedgerbyStudent)
        Me.CrystalReportViewer1.RefreshReport()

        frm.Hide()
    End Sub

    'benJan 3 2007. Format given by Client . 
    Private Sub GenRepLedger()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.LedgerandTrCodesbyStudentTableAdapter

        dt.Fill(ds.LedgerandTrCodesbyStudent, Me.m_StudentPK, Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue)

        If ds.LedgerandTrCodesbyStudent.Rows.Count <= 0 Then MsgBox("No Records for that student.") : frm.Hide() : Exit Sub

        Dim DateReference As DateTime = CDate(DateTimePicker1.Value.ToShortDateString & " 12:00:00 AM")

        'Now switch on what type of report is chosen (updates only or not)
        If CheckBoxPrintOnlyUpdates.Checked Then

            Me.CrystalReportViewer1.ReportSource = clsStudentLedger.loadStudentLedgerORtypeUpdatesOnly(cmbSem.SelectedValue, _
             Me.cmbSY.SelectedValue, Me.m_StudentPK, ds.LedgerandTrCodesbyStudent, DateReference, True)

        ElseIf CheckBoxFullyPaid.Checked Then

            Me.CrystalReportViewer1.ReportSource = clsStudentLedger.loadStudentLedgerFullyPaid(cmbSem.SelectedValue, _
            Me.cmbSY.SelectedValue, Me.m_StudentPK, ds.LedgerandTrCodesbyStudent, DateReference, True)

        Else

            REM DEFAULT STUDENT LEDGER
            Me.CrystalReportViewer1.ReportSource = clsStudentLedger.loadStudentLedgerORtype(cmbSem.SelectedValue, _
              Me.cmbSY.SelectedValue, Me.m_StudentPK, ds.LedgerandTrCodesbyStudent)

        End If
        
        Me.CrystalReportViewer1.RefreshReport()

        frm.Hide()
    End Sub

    'LOAD REPORT
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If Me.chkDetails.Checked Then
            GenRepDetails()
        Else
            GenRepLedger()
        End If

    End Sub

    'CHOOSE STUDENT
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.M_StudentName = frm.m_StudentName
            TextBox1.Text = frm.m_StudentName
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub uStudentLedger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.chkDetails.Checked = False
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.cmbSem.SelectedValue = clsTool.GetCurSemPK
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK

        CheckBoxPrintOnlyUpdates.Checked = True
    End Sub

    Private Sub chkDetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetails.CheckedChanged
        If Me.chkDetails.Checked Then
            Me.lblSem.Visible = False
            Me.lblYear.Visible = False
            Me.cmbSem.Visible = False
            Me.cmbSY.Visible = False
        Else
            Me.lblSem.Visible = True
            Me.lblYear.Visible = True
            Me.cmbSem.Visible = True
            Me.cmbSY.Visible = True
        End If
    End Sub
End Class
