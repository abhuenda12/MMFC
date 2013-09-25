Public Class uSchoolResources
    Public Sub NewDoc()
        Dim frm As New frmSchoolResources
        frm.TextBox1.Text = ""
        frm.TextBox2.Text = ""
        frm.TextBox3.Text = ""
        frm.TextBox4.Text = ""
        frm.ShowDialog()
        If frm.IsDirty Then
            Me.DsSchool.SchoolResources.AddSchoolResourcesRow(frm.TextBox1.Text, frm.TextBox2.Text, frm.TextBox3.Text, frm.TextBox4.Text)
            Me.SchoolResourcesTableAdapter.Update(Me.DsSchool.SchoolResources)
        End If
    End Sub

    Public Sub OpenDoc()
        If Me.DsSchool.SchoolResources.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        Dim frm As New frmSchoolResources
        frm.TextBox1.Text = Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position).ResourceID
        frm.TextBox2.Text = Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position).ResourceName
        frm.TextBox3.Text = Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position).Location
        frm.TextBox4.Text = Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position).Remarks
        frm.ShowDialog()
        If frm.IsDirty Then
            With Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position)
                .ResourceID = frm.TextBox1.Text
                .ResourceName = frm.TextBox2.Text
                .Location = frm.TextBox3.Text
                .Remarks = frm.TextBox4.Text
            End With
            Me.SchoolResourcesTableAdapter.Update(Me.DsSchool.SchoolResources)
        End If
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.SchoolResources.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsSchool.SchoolResources(Me.SchoolResourcesBindingSource.Position).Delete()
            Me.SchoolResourcesTableAdapter.Update(Me.DsSchool.SchoolResources)
        End If
    End Sub
    
    Private Sub uSchoolResources_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SchoolResourcesTableAdapter.Fill(Me.DsSchool.SchoolResources)
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
