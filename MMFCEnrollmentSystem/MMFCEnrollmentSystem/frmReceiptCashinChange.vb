Public Class frmReceiptCashinChange

    Public isDirty As Boolean = False
    Public cashin, amountdue, change As Double

    'tab out on Cashin
    Private Sub TextBoxCashin_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCashin.Validated

        If Not IsNumeric(TextBoxCashin.Text) Then
            MsgBox("Invalid Cash-in Amount!")
            TextBoxCashin.Text = "0.00"
            Exit Sub
        End If

        TextBoxCashin.Text = FormatNumber(TextBoxCashin.Text, 2)

        cashin = CDbl(TextBoxCashin.Text)
        amountdue = CDbl(TextBoxAmountDue.Text)

        change = cashin - amountdue

        TextBoxChange.Text = FormatNumber(change, 2)

        TextBoxChange.Select()
    End Sub

    'OK
    Private Sub ButtonPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPay.Click

        If Not IsNumeric(TextBoxCashin.Text) Then
            MsgBox("Invalid Cash-in Amount!")
            Exit Sub
        End If

        isDirty = True
        Me.Hide()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
End Class