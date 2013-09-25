Imports System.Math
Public Class uReceiptReprint

#Region "Variables"
    Private ds As New dsFinance.ReceiptsHeaderByORNoDataTable
    Private dt As New dsFinanceTableAdapters.ReceiptsHeaderByORNoTableAdapter
    Public tellername As String = ""

#End Region

#Region "Setup Initialization"
  
    Public Sub NewDoc()
        Me.txtReceiptNumber.Text = ""
        Me.txtReason.Text = ""
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

#End Region

#Region "EVENTS"

    Private Sub btnFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalize.Click
        If Not IsNumeric(Me.txtReceiptNumber.Text) Then MsgBox("Invalid OR No!") : Exit Sub

        If String.IsNullOrEmpty(Me.txtReceiptNumber.Text) Or String.IsNullOrEmpty(Me.txtReason.Text) Then

            MsgBox("OR Number and Reason should not be empty.")
            Exit Sub
        End If

        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()
        If frmPassword.isDirty Then
            findOR()
        Else
            MsgBox("Unauthorized to Reprint!")
        End If




    End Sub

    Sub findOR()

        Dim orno As String = "%" & Me.txtReceiptNumber.Text & "%"
        Dim receiptheaderpk As Integer = -1
        Dim studentpk, sempk, sypk As Integer
        Dim i As Integer

        dt.Fill(ds, orno)
        If ds.Rows.Count <= 0 Then

            MsgBox("No records found for OR No : " & Me.txtReceiptNumber.Text)
            Exit Sub
        ElseIf ds.Rows.Count > 1 Then

            For i = 0 To ds.Rows.Count - 1
                With ds(i)
                    If IsNumeric(.Reference) Then
                        If .Reference = Convert.ToInt64(Me.txtReceiptNumber.Text) Then
                            receiptheaderpk = .PK
                            studentpk = .Studentpk
                            sempk = .semPK
                            sypk = .yearPK
                            Exit For
                        End If
                    End If
                End With
            Next

        Else

            receiptheaderpk = ds(0).PK
            studentpk = ds(0).Studentpk
            sempk = ds(0).semPK
            sypk = ds(0).yearPK

        End If

        If receiptheaderpk <> -1 Then previewReceipt(receiptheaderpk, studentpk, sypk, sempk)

    End Sub

    Sub previewReceipt(ByVal ReceiptPK As Integer, ByVal studentpk As Integer, ByVal sypk As Integer, ByVal sempk As Integer)

        Dim frm As New frmWait

        Try

            Dim dsPseudoFin As New dsFinance
            Dim enrollmentamount As Double = 0
            Dim receiptAmount As Double = 0
            Dim dsOR As New dsFinance.LedgerORsByORHeaderPKDataTable
            Dim dtOR As New dsFinanceTableAdapters.LedgerORsByORHeaderPKTableAdapter
            dtOR.Fill(dsOR, CStr(ReceiptPK))

            If dsOR.Rows.Count <= 0 Then
                MsgBox("OR No exists in Header table but not in Ledger. Please report to Admin.")
                Exit Sub
            End If

            Dim i As Integer
            For i = 0 To dsOR.Rows.Count - 1
                With dsOR(i)
                    receiptAmount += .amount

                    If .remarks.ToUpper.Contains("ENROLLMENT") Then
                        enrollmentamount += .amount
                    Else
                        dsPseudoFin.LedgerReceiptBreakdown.AddLedgerReceiptBreakdownRow(.amount, .remarks, "")
                    End If

                End With
            Next

            If enrollmentamount > 0 Then
                dsPseudoFin.LedgerReceiptBreakdown.AddLedgerReceiptBreakdownRow(enrollmentamount, "Enrollment", "")
            End If

            frm.Show()
            Application.DoEvents()

            Dim rep As New crReceipts
            rep.SetDataSource(dsPseudoFin)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            rep.SetParameterValue("TRREF", tellername)
            rep.SetParameterValue("SFOR", clsTool.getStudentName(studentpk))
            rep.SetParameterValue("RFROM", clsTool.getStudentName(studentpk))
            rep.SetParameterValue("TTOTAL", receiptAmount)
            rep.SetParameterValue("REMARKS", "")
            rep.SetParameterValue("footer", "")
            rep.SetParameterValue("SECONDCOURSER", IIf(clsTool2.checkIfStudent2ndcourser(studentpk), "2nd Courser - BSN", ""))
            rep.SetParameterValue("COURSE", clsTool.getStudentCourseName(sempk, sypk, studentpk))
            rep.SetParameterValue("TELLER", tellername)


            Me.CrystalReportViewer1.ReportSource = rep
            Me.CrystalReportViewer1.RefreshReport()
            Me.CrystalReportViewer1.Zoom(75)

            MsgBox("Please prepare paper in printer!")
            Me.CrystalReportViewer1.PrintReport()


        Catch ex As Exception

            MsgBox("Error occurred. " & ex.Message)
        End Try

        frm.Hide()

        'if no error..save Reprint Transaction
        saveToDatabase(ReceiptPK)

    End Sub
#End Region

#Region "Database"

    Sub saveToDatabase(ByVal receiptheaderpk As Integer)

        Dim dsDB As New dsFinance.ReceiptReprintDataTable
        Dim dtDB As New dsFinanceTableAdapters.ReceiptReprintTableAdapter

        dsDB.AddReceiptReprintRow(Me.txtReceiptNumber.Text, tellername, Me.txtReason.Text, receiptheaderpk, Now())
        dtDB.Update(dsDB)

        NewDoc()
    End Sub

#End Region
    



  
 
    
End Class
