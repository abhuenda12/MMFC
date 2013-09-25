Public Class uSchoolYear

    Public Sub NewDoc()
        Dim frm As New frmSchoolYear
        frm.ShowDialog()
        If frm.isDirty Then
            Me.DsSchool.SchoolYear.AddSchoolYearRow(frm.TextBox1.Text, CInt(frm.txtSortOrder.Text))
            Me.SchoolYearTableAdapter.Update(Me.DsSchool.SchoolYear)
            Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        End If
    End Sub

    Public Sub OpenDoc()
        If Me.DsSchool.SchoolYear.Rows.Count = 0 Then MsgBox("Nothing to edit!") : Exit Sub
        Dim frm As New frmSchoolYear
        With Me.DsSchool.SchoolYear(Me.SchoolYearBindingSource.Position)
            frm.TextBox1.Text = .SchoolYear
            If .IssorterNull Then .sorter = 0
            frm.txtSortOrder.Text = .sorter

            frm.ShowDialog()

            If frm.isDirty Then
                .SchoolYear = frm.TextBox1.Text
                .sorter = frm.txtSortOrder.Text
                Me.SchoolYearTableAdapter.Update(Me.DsSchool.SchoolYear)
                Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
            End If
        End With
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.SchoolYear.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            Me.DsSchool.SchoolYear(Me.SchoolYearBindingSource.Position).Delete()
            Me.SchoolYearTableAdapter.Update(Me.DsSchool.SchoolYear)
        End If
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
    End Sub

    Private Sub uSchoolYear_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewDoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        OpenDoc()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        DeleteDoc()
    End Sub
End Class
