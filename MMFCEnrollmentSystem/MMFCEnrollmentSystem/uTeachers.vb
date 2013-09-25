Public Class uTeachers
    Sub NewDoc()
        Dim frm As New frmTeachers
        frm.TextBox1.Text = ""
        frm.TextBox2.Text = ""
        frm.TextBox3.Text = ""
        frm.TextBox4.Text = ""
        frm.TextBox5.Text = ""
        frm.TextBox6.Text = ""
        frm.TextBox7.Text = ""
        frm.TextBox8.Text = ""
        frm.ShowDialog()
        If frm.IsDirty Then
            Me.DsSchool.Teachers.AddTeachersRow(frm.TextBox1.Text, frm.TextBox2.Text, frm.TextBox3.Text, frm.TextBox4.Text, frm.TextBox5.Text, frm.TextBox6.Text, frm.TextBox7.Text, frm.TextBox8.Text)
            Me.TeachersTableAdapter.Update(Me.DsSchool.Teachers)
        End If
    End Sub
    Sub OpenDoc()
        If Me.DsSchool.Teachers.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        Dim frm As New frmTeachers
        With Me.DsSchool.Teachers(Me.TeachersBindingSource.Position)
            frm.TextBox1.Text = .TeacherIDNum
            frm.TextBox2.Text = .Name
            frm.TextBox3.Text = .Address1
            frm.TextBox4.Text = .Address2
            frm.TextBox5.Text = .Address3
            frm.TextBox6.Text = .phone
            frm.TextBox7.Text = .cellphone
            frm.TextBox8.Text = .Remarks
        End With
        frm.ShowDialog()
        If frm.IsDirty Then
            With Me.DsSchool.Teachers(Me.TeachersBindingSource.Position)
                .TeacherIDNum = frm.TextBox1.Text
                .Name = frm.TextBox2.Text
                .Address1 = frm.TextBox3.Text
                .Address2 = frm.TextBox4.Text
                .Address3 = frm.TextBox5.Text
                .phone = frm.TextBox6.Text
                .cellphone = frm.TextBox7.Text
                .Remarks = frm.TextBox8.Text
            End With
            Me.TeachersTableAdapter.Update(Me.DsSchool.Teachers)
        End If
    End Sub
    Sub DeleteDoc()
        If Me.DsSchool.Teachers.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsSchool.Teachers(Me.TeachersBindingSource.Position).Delete()
            Me.TeachersTableAdapter.Update(Me.DsSchool.Teachers)
        End If
    End Sub
    Private Sub uTeachers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dLoad()
    End Sub
    Private Sub dLoad()
        Me.TeachersTableAdapter.Fill(Me.DsSchool.Teachers)
    End Sub
    'ben11.23.2007 Client Request
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            goFilter()
        End If
    End Sub
    'benhide rows not meeting the filter requirement
    Private Sub goFilter()
        Dim rows As Integer = Me.DsSchool.Teachers.Rows.Count
        If rows <= 0 Then MsgBox("No records!") : Exit Sub

        dLoad()
        'put binding source at last row
        Me.TeachersBindingSource.Position = rows - 1
        Dim hits As Integer = 0
        Dim i As Integer
        For i = 0 To rows - 1
            With Me.DataGridView1.Rows(i)
                'check if last row and if theres no hit yet
                If i = rows - 1 And hits <= 0 Then MsgBox("No records meeting your filter.") : dLoad() : Exit Sub
                If CStr(.Cells(1).Value).ToUpper.Contains(Me.txtFilter.Text.ToUpper) Then
                    hits += 1
                    If hits = 1 Then Me.TeachersBindingSource.Position = i 'transfer currency to first hit row
                Else
                    .Visible = False
                End If
            End With
        Next
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

