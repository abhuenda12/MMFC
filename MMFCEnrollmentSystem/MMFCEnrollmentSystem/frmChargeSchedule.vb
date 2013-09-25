Public Class frmChargeSchedule
    Public IsDirty As Boolean = False
    Public yrlevel As Integer = -99 ' -99 means all 
    Public coursepk As Integer = -99

    REM ben. 9.27.2007
    'To avoid null values in checkbox
    Public Sub initialize()
        Me.chkNewStudent.Checked = False
        Me.chkOldStudent.Checked = False
        Me.chkTransferee.Checked = False
        Me.chkAllCourses.Checked = True
        Me.chkAllYearLevel.Checked = True
        loadData()
    End Sub
    Public Sub loadData()
        ''Me.CoursesTableAdapter.Fill(Me.DsSchool.Courses)
        fillEnrollYearCombo()
    End Sub
    REM Sonny. 9.27.2007
    'Added error handling 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Me.txtCharge.Text) Then MsgBox("Invalid Charge Name value!") : Exit Sub
        If String.IsNullOrEmpty(Me.txtCategory.Text) Then MsgBox("Invalid Category value!") : Exit Sub
        If Not IsNumeric(Me.txtAmount.Text) Then MsgBox("Invalid Amount!") : Exit Sub
        If Convert.ToDouble(Me.txtAmount.Text) <= 0 Then MsgBox("Amount should be greater than zero! ") : Exit Sub
        If Me.chkNewStudent.Checked = False And Me.chkOldStudent.Checked = False _
                  And Me.chkTransferee.Checked = False Then MsgBox("Should apply charge to at least 1 student type!") : Exit Sub
        If Me.chkAllYearLevel.Checked = False And String.IsNullOrEmpty(Me.cmbYrLevel.SelectedValue) Then
            MsgBox("A year level should be selected if you don't want to apply it to all!")
            Exit Sub
        End If
        If Me.chkAllCourses.Checked = False And Me.coursepk = -99 Then
            MsgBox("A course should be selected if you don't want to apply it to all!")
            Exit Sub
        End If

        If Me.chkAllYearLevel.Checked Then yrlevel = -99 Else yrlevel = Me.cmbYrLevel.SelectedValue
        If Me.chkAllCourses.Checked Then coursepk = -99

        Me.IsDirty = True
        Me.Hide()
    End Sub

    Private Sub fillEnrollYearCombo()
        Dim cls(4) As clsListItem
        cls(0) = New clsListItem
        cls(0).ID = 1
        cls(0).Name = "1st Year"
        cls(1) = New clsListItem
        cls(1).ID = 2
        cls(1).Name = "2nd Year"
        cls(2) = New clsListItem
        cls(2).ID = 3
        cls(2).Name = "3rd Year"
        cls(3) = New clsListItem
        cls(3).ID = 4
        cls(3).Name = "4th Year"
        cls(4) = New clsListItem
        cls(4).ID = 5
        cls(4).Name = "5th Year"
        Me.cmbYrLevel.DisplayMember = "Name"
        Me.cmbYrLevel.ValueMember = "ID"
        Me.cmbYrLevel.DataSource = cls

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.coursepk = frm.m_CoursePK
            Me.txtCourseName.Text = frm.m_CourseName
        End If
    End Sub
End Class