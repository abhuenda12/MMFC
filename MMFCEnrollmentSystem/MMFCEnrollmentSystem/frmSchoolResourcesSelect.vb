Public Class frmSchoolResourcesSelect
    Public Selected As Boolean = False
    Private Sub frmSchoolResourcesSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SchoolResourcesbyCNameTableAdapter.Fill(Me.DsSchool.SchoolResourcesbyCName, "%")
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.SchoolResourcesbyCNameTableAdapter.Fill(Me.DsSchool.SchoolResourcesbyCName, Me.TextBox1.Text & "%")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsSchool.SchoolResourcesbyCName.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        Selected = True
        Me.Hide()
    End Sub
End Class