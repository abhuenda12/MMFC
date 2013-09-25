Public Class frmEnrollSubjectCharge

    Public isDirty As Boolean = False
    Public trtypepk As Integer = -1

    'Choose Transaction
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmTrTypesSelect
        frm.ShowDialog()
        If frm.selected Then
            Me.trtypepk = frm.m_TrTypePK
            Me.txtTransaction.Text = clsTool.getTrTypeName(Me.trtypepk)
            Me.txtAmount.Text = FormatNumber(clsTool.getTrTypeAmount(Me.trtypepk), 2)
            Me.txtQuantity.Focus()
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        computeTotal()
    End Sub
    Private Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        computeTotal()
    End Sub
    Private Sub computeTotal()
        Dim qty As Double = 0
        Dim amt As Double = 0
        Dim total As Double = 0
        If IsNumeric(Me.txtQuantity.Text) Then qty = Convert.ToDouble(Me.txtQuantity.Text)
        If IsNumeric(Me.txtAmount.Text) Then amt = Convert.ToDouble(Me.txtAmount.Text)
        total = qty * amt
        Me.txtTotal.Text = FormatNumber(total, 2)
    End Sub

    'Save
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Me.txtQuantity.Text) Then MsgBox("Invalid Quantity") : Exit Sub
        If Not IsNumeric(Me.txtQuantity.Text) Then MsgBox("Invalid Quantity") : Exit Sub
        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid Amount") : Exit Sub        
        If Convert.ToDouble(Me.txtTotal.Text) < 0 Then MsgBox("Amount can't be Negative.") : Exit Sub
        isDirty = True
        Me.Hide()
    End Sub

End Class