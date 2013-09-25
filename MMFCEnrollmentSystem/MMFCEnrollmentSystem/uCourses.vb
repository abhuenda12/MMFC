Public Class uCourses
    Public Sub NewDoc()
        If clsTool.GetCurYearPK() = -1 Then MsgBox("Current school year not defined!") : Exit Sub
        Dim frm As New frmCourse
        frm.TextBox1.Text = ""
        frm.TextBox2.Text = ""
        frm.TextBox3.Text = ""
        frm.ShowDialog()
        If frm.IsDirty Then
            Dim r As dsSchool.CoursesRow
            r = Me.DsSchool.Courses.AddCoursesRow(frm.TextBox1.Text, frm.TextBox2.Text, frm.TextBox3.Text, frm.CheckBox1.Checked)
            Me.CoursesTableAdapter.Update(Me.DsSchool.Courses)
            ''Dim fm As New frmBlockSectionDef
            ''fm.m_Special = frm.CheckBox1.Checked
            ''fm.m_CurCourse = r.coursepk
            ''fm.init()
            ''fm.ShowDialog()
        End If
    End Sub
    Public Sub OpenDoc()
        If Me.DsSchool.Courses.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        Dim frm As New frmCourse
        frm.TextBox1.Text = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).CourseID
        frm.TextBox2.Text = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).CourseName
        frm.TextBox3.Text = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).Remarks
        frm.CheckBox1.Checked = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).special
        frm.ShowDialog()
        If frm.IsDirty Then
            Me.DsSchool.Courses(Me.CoursesBindingSource.Position).CourseID = frm.TextBox1.Text
            Me.DsSchool.Courses(Me.CoursesBindingSource.Position).CourseName = frm.TextBox2.Text
            Me.DsSchool.Courses(Me.CoursesBindingSource.Position).Remarks = frm.TextBox3.Text
            Me.DsSchool.Courses(Me.CoursesBindingSource.Position).special = frm.CheckBox1.Checked
            Me.CoursesTableAdapter.Update(Me.DsSchool.Courses)
            ''Dim fm As New frmBlockSectionDef
            ''fm.m_Special = frm.CheckBox1.Checked
            ''fm.m_CurCourse = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).coursepk
            ''fm.init()
            ''fm.ShowDialog()
        End If
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.Courses.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsSchool.Courses(Me.CoursesBindingSource.Position).Delete()
            Me.CoursesTableAdapter.Update(Me.DsSchool.Courses)
        End If
    End Sub

    
    Private Sub uCourses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CoursesTableAdapter.Fill(Me.DsSchool.Courses)
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
