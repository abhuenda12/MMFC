Imports System.Math
Public Class uReceiptCancel

#Region "Variables"
    Private ds As New dsFinance.ReceiptsHeaderByORNoDataTable
    Private dt As New dsFinanceTableAdapters.ReceiptsHeaderByORNoTableAdapter
    Public tellername As String = ""

#End Region

#Region "Setup Initialization"

    Public Sub NewDoc()
        Me.txtReceiptNumber.Text = "put the OR# here then press Enter"        
        txtReceiptNumber.Select()
    End Sub


#End Region

#Region "EVENTS"

    Private Sub btnFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalize.Click
        If Not IsNumeric(Me.txtReceiptNumber.Text) Then MsgBox("Invalid OR No!") : Exit Sub


        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()
        If frmPassword.isDirty Then
            cancelOR()
        Else
            MsgBox("Unauthorized !")
        End If




    End Sub

  

    Sub cancelOR()

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

                            .Cancelled = 1
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
            ds(0).Cancelled = 1
        End If


        dt.Update(ds)

        'Look for details of RCPT tran in Ledger Table
        'change RCPT to RCPT-CANCEL

        Dim ds2 As New dsFinance.LedgerbyRefLinetypeDataTable
        Dim dt2 As New dsFinanceTableAdapters.LedgerbyRefLinetypeTableAdapter

        dt2.Fill(ds2, receiptheaderpk, "RCPT")

        If ds2.Rows.Count <= 0 Then MsgBox("No ledger records for this OR!") : Exit Sub

        For i = 0 To ds2.Rows.Count - 1
            With ds2(i)

                .linetype = "RCPT-CANCEL"
            End With
        Next

        Try
            dt2.Update(ds2)
        Catch ex As Exception

            MsgBox("Error cancelling this OR." & vbCrLf & ex.Message)
        End Try


        MsgBox("Succesfully cancelled OR # " & Me.txtReceiptNumber.Text)

    End Sub

   
#End Region

#Region "Database"

    Sub saveToDatabase(ByVal receiptheaderpk As Integer)

        ''Dim dsDB As New dsFinance.ReceiptReprintDataTable
        ''Dim dtDB As New dsFinanceTableAdapters.ReceiptReprintTableAdapter

        ''dsDB.AddReceiptReprintRow(Me.txtReceiptNumber.Text, tellername, Me.txtReason.Text, receiptheaderpk, Now())
        ''dtDB.Update(dsDB)

        ''NewDoc()
    End Sub

#End Region






    
End Class
