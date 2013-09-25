Public Class uAdjustments
    Public m_StudentPK As Integer = -1

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()

        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.txtStudent.Text = frm.m_StudentName
            LoadLedger()
        End If
    End Sub

    '10.28.2011. Added test if Ledger rows included in new system reset. only 2nd sem 2011-2012 and onwards.
    'ben10.2.2007 replaced with MISC
    'added field ledgerpk in TemplateStudentLedger
    Sub LoadLedger()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter
        ds.LedgerbyStudent.Clear()
        dt.Fill(ds.LedgerbyStudent, Me.m_StudentPK)
        Dim ctr As Integer
        Me.DsFinance.TemplateStudentLedger.Clear()
        Dim bal As Double = 0
        For ctr = 0 To ds.LedgerbyStudent.Rows.Count - 1
            With ds.LedgerbyStudent(ctr)

                'test inclusion
                Dim sempk As Integer = .sempk
                Dim sypk As Integer = .sypk

                If Not clsTool.IsSYSemIncludedInLedgerComputations(sempk, sypk) Then Continue For


                If .linetype = "SCHG" Then bal = bal + .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.GetSubjectDescription(.subjectpk), "SCHG", .amount, bal, "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                ''If .linetype = "CCHG" Then bal = bal + .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.getCourseName(.coursepk), "CCHG", .amount, bal, "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk))
                If .linetype = "MISC" Then bal = bal + .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.getCourseName(.coursepk), "MISC", .amount, bal, "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                If .linetype = "RCPT" Then bal = bal - .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, "PAY REF:" & .ref, "RCPT", .amount, bal, .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                If .linetype = "OCHG" Then bal = bal + .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, .ref, "OCHG", .amount, bal, .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                If .linetype = "TUTOR" Then bal = bal + .amount : Me.DsFinance.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, clsTool.GetSubjectDescription(.subjectpk), "TUTORIAL", .amount, bal, "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
            End With
        Next
        frm.Hide()
    End Sub

    'NEW button
    Private Sub NewDoc()
        'Ben 3.17.2008
        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()

        If Not frmPassword.isDirty Then
            MsgBox("NOT ALLOWED TO MAKE ADJUSTMENTS IN LEDGER.")
            Exit Sub
        End If

        If Me.m_StudentPK = -1 Then MsgBox("Please select student ledger to open!") : Exit Sub

        Dim frm As New frmAdjustments
        frm.txtDate.Value = Now.Date
        frm.ShowDialog()
        If frm.IsDirty Then

            Dim ds As New dsFinance
            Dim dt As New dsFinanceTableAdapters.LedgerTableAdapter

            ds.Ledger.AddLedgerRow(frm.txtDate.Value.Date, frm.txtRef.Text, clsTool.GetCurSemPK, _
                   -1, -1, "OCHG", Convert.ToDouble(frm.txtAmount.Text), 0, Me.m_StudentPK, _
                   clsTool.GetCurYearPK, frm.txtRemarks.Text, frm.CheckBoxClearBackaccounts.Checked)

            dt.Update(ds.Ledger)

            Application.DoEvents()

            LoadLedger()
        End If
    End Sub
    'ben10.2.2007
    'DELETE button . Will only delete OCHG type
    Private Sub DeleteDoc()
        'Ben 3.17.2008
        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()

        If Not frmPassword.isDirty Then
            MsgBox("NOT ALLOWED TO MAKE ADJUSTMENTS IN LEDGER.")
            Exit Sub
        End If

        If Me.DsFinance.TemplateStudentLedger.Rows.Count <= 0 Then MsgBox("No Records.") : Exit Sub
        If MsgBox("Are you sure to delete this Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            With Me.DsFinance.TemplateStudentLedger(Me.TemplateStudentLedgerBindingSource.Position)
                If Not ._Class = "OCHG" Then MsgBox("Only OCHG type can be deleted.") : Exit Sub
                Try
                    Dim con As New System.Data.SqlClient.SqlConnection(My.Settings.mmfcdbConnectionString)
                    Dim com As New System.Data.SqlClient.SqlCommand("DELETE FROM Ledger WHERE ledgerpk = " & .LedgerPK & " AND linetype ='" & ._Class & "'", con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    MsgBox("Error in deleting record. Please Try again." & vbCrLf & ex.Message)
                End Try
            End With
        End If

        LoadLedger()
    End Sub

    
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewDoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        'none
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        DeleteDoc()
    End Sub
End Class
