Public Class frmMiscChargesDetails
    Public isDirty As Boolean = False
    Public chargepk As Integer = -1

    Public Sub loadData()
    End Sub
    'Save
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click        
        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid Amount") : Exit Sub
        If Convert.ToDouble(Me.txtAmount.Text) <= 0 Then MsgBox("Amount can't be Negative or Zero") : Exit Sub
        isDirty = True
        Me.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmChargeScheduleSelect
        frm.ShowDialog()
        If frm.selected Then
            chargepk = frm.chargeskedPK
            Me.txtChargeName.Text = clsTool.getChargeSchedName(chargepk)
            Me.txtCategory.Text = clsTool.getChargeCategory(chargepk)
            Me.txtAmount.Text = FormatNumber(clsTool.getChargeAmount(chargepk), 2)
            Me.txtRemarks.Text = clsTool.getChargeRemarks(chargepk)
        End If
    End Sub

End Class