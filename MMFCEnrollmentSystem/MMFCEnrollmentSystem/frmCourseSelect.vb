Public Class frmCourseSelect

    Public Selected As Boolean = False
    Public m_CoursePK As Integer = -1
    Public m_CourseName As String = ""
    Public m_CourseSP As Boolean = False

    Private Sub frmCourseSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsSchool.Courses' table. You can move, or remove it, as needed.
        Me.CoursesTableAdapter.Fill(Me.DsSchool.Courses)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsSchool.Courses.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        Me.m_CoursePK = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).coursepk
        Me.m_CourseName = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).CourseName
        Me.m_CourseSP = Me.DsSchool.Courses(Me.CoursesBindingSource.Position).special
        Me.Selected = True
        Me.Hide()
    End Sub
End Class