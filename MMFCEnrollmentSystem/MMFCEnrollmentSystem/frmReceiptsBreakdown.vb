Public Class frmReceiptsBreakdown

    Public isDirty As Boolean = False
    Dim validValues As Boolean = False

    
    Private Sub getTotal()

        Try
            If DataGridView1.IsCurrentCellDirty Or DataGridView1.IsCurrentRowDirty Then
                DataGridView1.EndEdit()
                Me.LedgerReceiptBreakdownBindingSource.Position = Me.DataGridView1.NewRowIndex
            End If

            ''With Me.DataGridView1.CurrentCell
            ''    If .ColumnIndex = 1 Then
            ''        If .IsInEditMode Then Me.DataGridView1.EndEdit() : Me.LedgerReceiptBreakdownBindingSource.Position = Me.DataGridView1.NewRowIndex
            ''    End If
            ''End With
        Catch ex As Exception
        End Try

        If Me.DsFinance.LedgerReceiptBreakdown.Rows.Count <= 0 Then Exit Sub
        ''If Me.DataGridView1.RowCount <= 0 Then Exit Sub

        Dim totalAmount As Double = 0
        Dim i As Integer
        For i = 0 To Me.DsFinance.LedgerReceiptBreakdown.Rows.Count - 1
            With Me.DsFinance.LedgerReceiptBreakdown(i)
                If .amount < 0 Then MsgBox("Not allowed negative value for : " & .remarks) : Exit Sub
                Try
                    totalAmount += .amount
                Catch ex As Exception
                End Try
            End With
        Next

        Me.txtTotal.Text = FormatNumber(totalAmount, 2)
        validValues = True
    End Sub

    'Get Total
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        getTotal()
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If e.ColumnIndex = 1 Then
            MsgBox("Invalid Amount!") : Exit Sub
        End If
        If e.ColumnIndex = 0 Then
            MsgBox("Remarks cannot be empty!") : Exit Sub
        End If
    End Sub
    'DONE button
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveThis()
    End Sub

    Sub SaveThis()
        getTotal()
        If validValues Then
            isDirty = True
            Me.Hide()
        End If
    End Sub
    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        getTotal()
    End Sub

    
    Private Sub frmReceiptsBreakdown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then getTotal()

        If e.KeyCode = Keys.F3 Then SaveThis()
    End Sub
End Class