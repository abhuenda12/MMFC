Public Class frmChargeScheduleSelect
    Public selected As Boolean = False
    Public chargeskedPK As Integer = -1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsFinance.ChargeSchedulebyName.Rows.Count = 0 Then MsgBox("Nothing Selected") : Exit Sub
        chargeskedPK = Me.DsFinance.ChargeSchedulebyName(Me.ChargeSchedulebyNameBindingSource.Position).pk
        selected = True
        Me.Hide()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.ChargeSchedulebyNameTableAdapter.Fill(Me.DsFinance.ChargeSchedulebyName, "%" & Me.TextBox1.Text & "%")
            If Me.DsFinance.ChargeSchedulebyName.Rows.Count = 1 Then
                chargeskedPK = Me.DsFinance.ChargeSchedulebyName(0).pk
                selected = True
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub frmTrTypesSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ChargeSchedulebyNameTableAdapter.Fill(Me.DsFinance.ChargeSchedulebyName, "%")

        Me.TextBox1.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class