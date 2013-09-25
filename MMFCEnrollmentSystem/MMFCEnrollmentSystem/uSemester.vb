Public Class uSemester
    'Edited ben10.19.2007 . Created frmSchoolyear (to be used for semester also)

    Public Sub NewDoc()
        ''Dim s As String = InputBox("Enter New Semester Type:", "Semester")
        ''If String.IsNullOrEmpty(s) Then MsgBox("Cannot add empty semester!") : Exit Sub
        Dim frm As New frmSchoolYear
        frm.Text = "Semester Name"
        frm.Label1.Text = "Semester Name"
        frm.ShowDialog()
        If frm.isDirty Then
            Me.DsSchool.Semester.AddSemesterRow(frm.TextBox1.Text, frm.txtSortOrder.Text)
            Me.SemesterTableAdapter.Update(Me.DsSchool.Semester)
            Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        End If
    End Sub

    Public Sub OpenDoc()
        If Me.DsSchool.Semester.Rows.Count = 0 Then MsgBox("Nothing to edit!") : Exit Sub
        ''Dim s As String = InputBox("Change semester Text to:", "Semester", Me.DsSchool.Semester(Me.SemesterBindingSource.Position).SemesterName)
        ''If String.IsNullOrEmpty(s) Then MsgBox("Invalid School Year!") : Exit Sub
        Dim frm As New frmSchoolYear
        With Me.DsSchool.Semester(Me.SemesterBindingSource.Position)

            frm.TextBox1.Text = .SemesterName
            If .IssorterNull Then .sorter = 0
            frm.txtSortOrder.Text = .sorter
            frm.Text = "Semester Name"
            frm.Label1.Text = "Semester Name"
            frm.ShowDialog()
            If frm.isDirty Then
                .SemesterName = frm.TextBox1.Text
                .sorter = frm.txtSortOrder.Text
                Me.SemesterTableAdapter.Update(Me.DsSchool.Semester)
                Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
            End If

        End With
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.Semester.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            Me.DsSchool.Semester(Me.SemesterBindingSource.Position).Delete()
            Me.SemesterTableAdapter.Update(Me.DsSchool.Semester)
        End If
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
    End Sub

    Private Sub uSemesters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
    End Sub
End Class
