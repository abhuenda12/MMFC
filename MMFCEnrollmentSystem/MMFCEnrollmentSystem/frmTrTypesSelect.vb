Public Class frmTrTypesSelect

    Public selected As Boolean = False
    Public m_TrTypePK As Integer = -1
    Public m_TrTypeName As String = ""
    Public m_Amount As Double = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsSchool.TRTypesbyName.Rows.Count = 0 Then MsgBox("Nothing selected") : Exit Sub
        Me.m_TrTypePK = Me.DsSchool.TRTypesbyName(Me.TRTypesbyNameBindingSource.Position).TRPK
        Me.m_TrTypeName = Me.DsSchool.TRTypesbyName(Me.TRTypesbyNameBindingSource.Position).TRName
        Me.m_Amount = Me.DsSchool.TRTypesbyName(Me.TRTypesbyNameBindingSource.Position).TRAmount
        selected = True
        Me.Hide()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TRTypesbyNameTableAdapter.Fill(Me.DsSchool.TRTypesbyName, TextBox1.Text & "%")
        End If
    End Sub

    Private Sub frmTrTypesSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TRTypesbyNameTableAdapter.Fill(Me.DsSchool.TRTypesbyName, "%")

        TextBox1.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class