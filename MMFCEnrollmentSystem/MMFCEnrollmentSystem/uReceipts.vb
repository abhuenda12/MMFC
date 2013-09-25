Imports System.Math
Imports System.Drawing.Printing
Public Class uReceipts

#Region "Variables"
    Public IsDirty As Boolean = False
    Public m_ReceiptPk As Integer = -1
    Public m_StudentID As Integer = -1
    'ben10.3.2007 this is set in frmMain tellername = UserName
    Public tellername As String = ""
    Public dsFin As New dsFinance
    Public dtLbyS As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter

    Dim frm As New frmReceiptsBreakdown

#End Region

#Region "Setup Initialization"
    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSem.SelectedValue = clsTool.GetCurSemPK
        Me.rdoPaydp.Checked = True
    End Sub
    Public Sub NewDoc()
        m_StudentID = -1
        Me.txtAmount.Text = "0"
        Me.txtReceiptNumber.Text = ""
        Me.txtReceivedFrom.Text = ""
        Me.txtReference.Text = clsTool.getNextORSeries()
        Me.txtRemarks.Text = ""
        Me.txtStudent.Text = ""
        IsDirty = False
        Me.m_ReceiptPk = -1
        Me.txtDate.Value = Now.Date
        dsFin.Clear()
        frm = New frmReceiptsBreakdown
        TextBoxRegNo.Text = ""
    End Sub
    Public Sub OpenDoc()

    End Sub
    Public Sub DeleteDoc()
    End Sub

#End Region

#Region "Saving and Printing"

    Private Sub btnFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalize.Click

        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid amount!") : Me.txtAmount.SelectAll() : Me.txtAmount.Focus() : Exit Sub

        Dim frmPay As New frmReceiptCashinChange
        frmPay.TextBoxAmountDue.Text = txtAmount.Text
        frmPay.TextBoxCashin.Select()
        frmPay.ShowDialog()

        If frmPay.isDirty Then

            FinalizeTransaction()

        End If
        
    End Sub

    Public Sub FinalizeTransaction()

        Dim receiptheaderpk As Integer = 0

        If String.IsNullOrEmpty(Me.txtReceivedFrom.Text) Then MsgBox("Transaction Invalid!") : Exit Sub
        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid amount!") : Me.txtAmount.SelectAll() : Me.txtAmount.Focus() : Exit Sub

        'Oct 13 2008
        If String.IsNullOrEmpty(Me.txtReference.Text) Or Not IsNumeric(Me.txtReference.Text) Then
            MsgBox("Invalid OR/Reference No !")
            Me.txtReference.SelectAll()
            Me.txtReference.Focus()
            Exit Sub
        End If


        'test Reference No if duplicated
        If clsTool.findOR(Me.txtReference.Text) Then
            MsgBox("That OR/Reference No has been used already! ")
            Exit Sub
        End If

        Dim amt As Double = Convert.ToDouble(Me.txtAmount.Text)
        If amt <= 0 Then MsgBox("Invalid amount!") : Me.txtAmount.SelectAll() : Me.txtAmount.Focus() : Exit Sub
        If Me.m_StudentID = -1 And String.IsNullOrEmpty(Me.txtRemarks.Text) Then MsgBox("Remarks required!") : Me.txtRemarks.Focus() : Exit Sub
        'ben10.31
        If frm.DsFinance.LedgerReceiptBreakdown.Rows.Count <= 0 Then MsgBox("No Records of breakdown of payment!") : Exit Sub

        Dim frmWait As New frmWait
        frmWait.Show()
        Application.DoEvents()

        Try
            Dim ds As New dsFinance
            Dim dtl As New dsFinanceTableAdapters.LedgerTableAdapter
            Dim dtr As New dsFinanceTableAdapters.ReceiptsHeaderTableAdapter

            'ben10.2.2007 dont delete
            ''Dim orno As Integer = clsTool.getNextOR()

            'Add into Receipts Header
            Dim payperiod As Integer = 0
            If Me.rdoPaydp.Checked Then payperiod = 0
            If Me.rdopay1.Checked Then payperiod = 1
            If Me.rdoPay2.Checked Then payperiod = 2
            If Me.rdopay3.Checked Then payperiod = 3
            If Me.rdoPay4.Checked Then payperiod = 4
            If Me.rdoPay5.Checked Then payperiod = 5

            Dim r As dsFinance.ReceiptsHeaderRow = _
              ds.ReceiptsHeader.AddReceiptsHeaderRow(Me.txtDate.Value.Date, Me.txtReference.Text, _
              Me.txtReceivedFrom.Text, amt, 0, Me.m_StudentID, Me.txtRemarks.Text, _
              Me.txtSY.SelectedValue, Me.txtSem.SelectedValue, tellername, payperiod)
            Try
                dtr.Update(ds.ReceiptsHeader)

                'get the receiptheaderpk
                Dim strSQL As String = "SELECT MAX(PK) FROM ReceiptsHeader"
                receiptheaderpk = clsTool.getDBValue(strSQL)

            Catch ex As Exception
                MsgBox("Error adding Receipt Record. Try Again." & vbCrLf & ex.Message)
                Exit Sub
            End Try

            '===================================================================================================
            'Add into Ledger
            'ben10.31.2007
            'Get all rows in frmReceiptsBreakdown where Amount > 0
            Dim i As Integer
            Dim trKey As Integer = r.PK
            Dim remarks As String = ""
            If Me.m_StudentID <> -1 Then
                For i = 0 To frm.DsFinance.LedgerReceiptBreakdown.Rows.Count - 1
                    With frm.DsFinance.LedgerReceiptBreakdown(i)
                        If .amount > 0 Then
                            If .Isremarks2Null Then .remarks2 = ""

                            'Back accounts and other fees require addtl remarks 1.26.2008
                            If .remarks.ToUpper.Contains("BACK ACCOUNT") Or .remarks.ToUpper.Contains("OTHER FEE") Then
                                remarks = .remarks & " - " & .remarks2
                            Else
                                remarks = .remarks
                            End If

                            '10.27.2011. added backaccount clearing bit.
                            ds.Ledger.AddLedgerRow(Me.txtDate.Value, trKey.ToString, Me.txtSem.SelectedValue, _
                               -1, -1, "RCPT", .amount, 0, Me.m_StudentID, Me.txtSY.SelectedValue, remarks, False)
                        End If
                    End With
                Next
                Try
                    dtl.Update(ds.Ledger)
                Catch ex As Exception
                    MsgBox("Error Adding to ledger. Try Again." & vbCrLf & ex.Message)
                    Exit Sub
                End Try
            End If
            '=====================================================================================================

            'take as one item all enrollment fees . create a new datatable for report usage
            Dim dsPseudoFin As New dsFinance
            Dim enrollmentamount As Double = 0
            For i = 0 To frm.DsFinance.LedgerReceiptBreakdown.Rows.Count - 1
                With frm.DsFinance.LedgerReceiptBreakdown(i)
                    If .Isremarks2Null Then .remarks2 = ""
                    If .remarks.ToUpper.Contains("ENROLLMENT") Then
                        enrollmentamount += .amount
                    Else
                        '' AS OF 3.5.2008 , ALL REMARKS2 will be printed                    
                        .remarks += "-" & .remarks2
                        dsPseudoFin.LedgerReceiptBreakdown.AddLedgerReceiptBreakdownRow(.amount, .remarks, .remarks2)
                    End If
                End With
            Next
            'at the end of the loop, we add the total enrollment 
            If enrollmentamount > 0 Then
                dsPseudoFin.LedgerReceiptBreakdown.AddLedgerReceiptBreakdownRow(enrollmentamount, "Enrollment", "")
            End If

            '=====================================================================================================
            ' Save the Registration Number . 10.26.2011

            If Not String.IsNullOrEmpty(TextBoxRegNo.Text) Then
                Dim dsRegNo As New dsReg2.RegistrationNumbersDataTable
                Dim dtregno As New dsReg2TableAdapters.RegistrationNumbersTableAdapter

                dsRegNo.AddRegistrationNumbersRow(receiptheaderpk, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue, Me.m_StudentID, TextBoxRegNo.Text, Now)

                'now update
                dtregno.Update(dsRegNo)
            End If
            '
            '
            'End Registration Number

            Dim rep As New crReceipts
            rep.SetDataSource(dsPseudoFin)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            ''rep.SetParameterValue("TRREF", trKey.ToString)
            rep.SetParameterValue("TRREF", tellername)

            REM Ben 2.29.2008 Commented out to print out Student Name without "ForStudent "
            ''If String.IsNullOrEmpty(Me.txtStudent.Text) Then
            rep.SetParameterValue("SFOR", "" & Me.txtStudent.Text)
            ''Else
            ''rep.SetParameterValue("SFOR", "For Student:" & Me.txtStudent.Text)
            ''End If


            rep.SetParameterValue("RFROM", Me.txtReceivedFrom.Text)
            rep.SetParameterValue("TTOTAL", Me.txtAmount.Text)
            rep.SetParameterValue("REMARKS", Me.txtRemarks.Text)
            rep.SetParameterValue("footer", clsTool.GetSetting("BIR"))
            rep.SetParameterValue("SECONDCOURSER", IIf(clsTool2.checkIfStudent2ndcourser(Me.m_StudentID), "2nd Courser - BSN", ""))
            'ben2.29.2008
            rep.SetParameterValue("COURSE", clsTool.getStudentCourseName(Me.txtSem.SelectedValue, _
                                                               Me.txtSY.SelectedValue, Me.m_StudentID))
            'ben3.5.2008
            rep.SetParameterValue("TELLER", tellername)

            ''frm.Hide()

            Dim frep As New frmReceiptPreview
            frep.CrystalReportViewer1.ReportSource = rep
            frep.Show()
            frmWait.Show()
            frep.CrystalReportViewer1.RefreshReport()
            frep.CrystalReportViewer1.Zoom(75)
            frmWait.Hide()


            MsgBox("Please prepare paper in printer!")
            frep.CrystalReportViewer1.PrintReport()
            If MsgBox("Reprint?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                frep.CrystalReportViewer1.PrintReport()
            End If


            frep.Hide()

            frep.ShowDialog()

            NewDoc()

        Catch ex As Exception

            MsgBox("An error occurred. Please note down the message." & vbCrLf & ex.Message)

        Finally

            frmWait.Hide()
        End Try
        
    End Sub

#End Region

#Region "Choose Student , load ledger"
    'Choose Student
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentID = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName
            Me.txtRemarks.Text = "Enrollment"
            If String.IsNullOrEmpty(Me.txtReceivedFrom.Text) Then Me.txtReceivedFrom.Text = frm.m_StudentName
            getLedger()
        End If
    End Sub

    '10.28.2011. Added test if Ledger rows included in new system reset. only 2nd sem 2011-2012 and onwards.
    'ben10.3.2007 . Copied from uStudentLedger
    Public Sub getLedger()
        If Me.m_StudentID = -1 Then Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        dsFin.LedgerbyStudent.Clear()
        dtLbyS.Fill(dsFin.LedgerbyStudent, Me.m_StudentID)

        Dim ctr As Integer
        Dim bal As Double = 0

        dsFin.TemplateStudentLedger.Clear()
        If dsFin.LedgerbyStudent.Rows.Count = 0 Then
            MsgBox("No ledger transactions found!")
        Else
            For ctr = 0 To dsFin.LedgerbyStudent.Rows.Count - 1

                With dsFin.LedgerbyStudent(ctr)

                    'test inclusion
                    Dim sempk As Integer = .sempk
                    Dim sypk As Integer = .sypk

                    If Not clsTool.IsSYSemIncludedInLedgerComputations(sempk, sypk) Then Continue For


                    If .linetype = "SCHG" Then bal = bal + .amount : dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.GetSubjectDescription(.subjectpk), "SCHG", FormatNumber(.amount, 2), FormatNumber(bal, 2), "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                    If .linetype = "MISC" Then bal = bal + .amount : dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.getCourseName(.coursepk), "MISC", FormatNumber(.amount, 2), FormatNumber(bal, 2), "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                    If .linetype = "RCPT" Then
                        'create debit item
                        If Not clsTool2.isAssessmentDeductible(.remarks) Then
                            bal += .amount
                            dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, .remarks, "PAYABLES", FormatNumber(.amount, 2), _
                                        FormatNumber(bal, 2), "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                        End If

                        bal = bal - .amount : dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, "PAY REF:" & .ref, "RCPT", FormatNumber(.amount, 2), FormatNumber(bal, 2), .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                    End If

                    If .linetype = "OCHG" Then bal = bal + .amount : dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, "", "OCHG", FormatNumber(.amount, 2), FormatNumber(bal, 2), .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                    If .linetype = "TUTOR" Then bal = bal + .amount : dsFin.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.GetSubjectDescription(.subjectpk), "TUTORIAL", FormatNumber(.amount, 2), FormatNumber(bal, 2), .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                End With
            Next

            Me.DataGridView1.DataSource = dsFin
            Me.DataGridView1.DataMember = "TemplateStudentLedger"

        End If
        frm.Hide()
        '=========================================================================
        'ben3.5.2008 . Check back accounts. ask password 
        '=========================================================================
        Dim backaccount As Double = clsTool2.getStudentBackAccounts(Me.m_StudentID, Me.txtSem.SelectedValue, Me.txtSY.SelectedValue)
        If backaccount > 0 Then
            MsgBox("Student has balance/back account =" & FormatNumber(backaccount, 2)) '''''' commented out 5.20.2008 & "  . Please supply Admin password")
            REM Ben 5.20.2008 Commented out as per request of client.
            '' ''Dim frmPassword As New frmAdminPassword
            '' ''frmPassword.ShowDialog()
            '' ''If frmPassword.isDirty Then
            '' ''    'do nothing . allow cashier to continue
            '' ''Else
            '' ''    MsgBox("Cannot continue transactions for this student.")
            '' ''    Me.LoadData()
            '' ''    Me.NewDoc()
            '' ''    Exit Sub
            '' ''End If
        End If
        '===================================================================================================

    End Sub

#End Region

#Region "Payment Breakdown child Form"
    'Breakdown of payment
    Private Sub btnBreakdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBreakdown.Click
        If frm Is Nothing Then frm = New frmReceiptsBreakdown
        frm.ShowDialog()
        If frm.isDirty Then
            Me.txtAmount.Text = frm.txtTotal.Text
        End If

    End Sub

#End Region

#Region "Misc. Function Events"

    'To disable radio buttons for Period2 and Period4 for semester = SUMMER
    Private Sub txtSem_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSem.SelectedValueChanged
        If Me.txtSem.Text.ToUpper.Contains("SUM") Then
            If Me.rdoPay2.Checked Then Me.rdopay1.Checked = True 'to transfer check state
            Me.rdoPay2.Enabled = False
            If Me.rdoPay4.Checked Then Me.rdopay1.Checked = True 'to transfer check state
            Me.rdoPay4.Enabled = False
        Else
            Me.rdoPay2.Enabled = True
            Me.rdoPay4.Enabled = True
        End If
    End Sub

    'Create Registration Number for student on first payment for enrollment
    'gets the next number for the current Sem and Year PK from table RegistrationNumbers
    Private Sub ButtonRegNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegNo.Click

        Dim yearpk As Integer = Me.txtSY.SelectedValue
        Dim sempk As Integer = Me.txtSem.SelectedValue

        'check if student has been chosen first
        If m_StudentID = -1 Then

            MsgBox("Please choose a student first!", MsgBoxStyle.Exclamation, "Error")
            TextBoxRegNo.Text = ""
            Exit Sub
        End If

        'now check if this student has a RegNo already for the current sem and year
        Dim ds As New dsReg2.RegistrationNumbersByStudentSemYearPKDataTable
        Dim dt As New dsReg2TableAdapters.RegistrationNumbersByStudentSemYearPKTableAdapter

        dt.Fill(ds, sempk, yearpk, m_StudentID)
        'check if there are results, if true then exit
        If ds.Rows.Count > 0 Then
            MsgBox("This student already has a registration number for current sem!", MsgBoxStyle.Information, "Note")
            TextBoxRegNo.Text = ds(0).RegNumber
            Exit Sub
        End If

        Dim strSQL As String = "SELECT isnull(MAX(RegNumber),0) FROM RegistrationNumbers WHERE YearPK = " & yearpk & " and SemPK = " & sempk

        'Set next number after the max number
        Dim RegNo As String = CInt(clsTool.getDBValue(strSQL)) + 1

        'now display in textbox
        TextBoxRegNo.Text = RegNo

    End Sub

#End Region

    
End Class
