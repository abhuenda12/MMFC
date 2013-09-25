Public Class frmTrTypes
    Public IsDirty As Boolean = False
    Public coursePK As Integer = -1
    Public subjectPK As Integer = -1

    Public Sub loadData()
       
        'Year level combo box
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
        Me.cmbEnrollYear.DisplayMember = "Name"
        Me.cmbEnrollYear.ValueMember = "ID"
        Me.cmbEnrollYear.DataSource = cls
        'default checkbox value=False
        Me.chkSubject.Checked = False
        Me.chkYrlevel.Checked = False
        Me.chkCourse.Checked = False
    End Sub
    'Save button
    'ben9.29.2007
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(txtTrCode.Text) Then MsgBox("Code cannot be empty!") : txtTrCode.SelectAll() : txtTrCode.Focus() : Exit Sub
        If String.IsNullOrEmpty(txtTrName.Text) Then MsgBox("Name cannot be empty!") : txtTrName.SelectAll() : txtTrName.Focus() : Exit Sub
        If Not IsNumeric(txtAmount.Text) Then MsgBox("value should be numeric!") : txtAmount.SelectAll() : txtAmount.Focus() : Exit Sub
        If Convert.ToDouble(txtAmount.Text) <= 0 Then MsgBox("Amount can't be zero or negative") : txtAmount.SelectAll() : txtAmount.Focus() : Exit Sub

        If coursePK = -1 And Me.chkCourse.Checked = False Then
            MsgBox("Please check box if the transaction is not course specific.")
            Me.chkCourse.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.cmbEnrollYear.SelectedValue) And Me.chkYrlevel.Checked = False Then
            MsgBox("Please check box if the transaction is not year level specific.")
            Me.chkYrlevel.Focus()
            Exit Sub
        End If

        If subjectPK = -1 And Me.chkSubject.Checked = False Then
            MsgBox("Please check box if the transaction is not subject specific.")
            Me.chkSubject.Focus()
            Exit Sub
        End If

        'validate student type
        If String.IsNullOrEmpty(ComboBoxStudentType.Text) Then
            ComboBoxStudentType.Text = "ALL"
        End If

        IsDirty = True
        Me.Hide()
    End Sub

    'Course Select
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.coursePK = frm.m_CoursePK
            Me.txtCourseName.Text = clsTool.getCourseCompleteDesc(frm.m_CoursePK)
        End If
    End Sub
    'Subject Select
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.subjectPK = frm.m_SubjectID
            Me.txtSubjectName.Text = frm.m_SubjectName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class