Public Class uTRTypes

    Public Sub NewDoc()
        Dim frm As New frmTrTypes
        frm.txtTrCode.Text = ""
        frm.txtTrName.Text = ""
        frm.txtAmount.Text = ""
        'benedited 9.29.2007

        frm.ComboBoxStudentType.Text = "ALL"

        frm.loadData()

        frm.ShowDialog()

        If frm.IsDirty Then
            Dim yrlevel As Integer = 0
            Dim subjectcode As Integer = 0
            Dim course As Integer = 0

            If frm.chkYrlevel.Checked Then yrlevel = -99 Else yrlevel = frm.cmbEnrollYear.SelectedValue

            If frm.chkSubject.Checked Then subjectcode = -99 Else subjectcode = frm.subjectPK

            If frm.chkCourse.Checked Then course = -99 Else course = frm.coursePK

            Me.DsSchool.TRTypes.AddTRTypesRow(frm.txtTRCode.Text, frm.txtTrName.Text, frm.txtAmount.Text _
                           , course, yrlevel, subjectcode, frm.txtRemarks.Text, frm.ComboBoxStudentType.Text)

            Me.TRTypesTableAdapter.Update(Me.DsSchool.TRTypes)
        End If
    End Sub
    'ben9.29.2007 . Edited added lines.
    Public Sub OpenDoc()
        If Me.DsSchool.TRTypes.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        Dim r As dsSchool.TRTypesRow = Me.DsSchool.TRTypes(Me.TRTypesBindingSource.Position)
        Dim frm As New frmTrTypes

        frm.loadData()
        frm.txtTrCode.Text = r.TRCode
        frm.txtTrName.Text = r.TRName
        frm.txtAmount.Text = FormatNumber(r.TRAmount, 2)

        If Not r.IsTRCourseNull Then
            If r.TRCourse = -99 Then frm.chkCourse.Checked = True Else frm.coursePK = r.TRCourse : frm.txtCourseName.Text = clsTool.getCourseCompleteDesc(r.TRCourse)
        End If

        If Not r.IsTRYearLevelNull Then
            If r.TRYearLevel = -99 Then frm.chkYrlevel.Checked = True Else frm.cmbEnrollYear.SelectedValue = r.TRYearLevel
        End If

        If Not r.IsTRSubjectNull Then
            If r.TRSubject = -99 Then frm.chkSubject.Checked = True Else frm.subjectPK = r.TRSubject : frm.txtSubjectName.Text = clsTool.GetSubjectName(r.TRSubject)
        End If

        If Not r.IsTRRemarksNull Then frm.txtRemarks.Text = r.TRRemarks

        frm.ComboBoxStudentType.Text = r.TRStudentType

        frm.ShowDialog()
        If frm.IsDirty Then
            r.TRCode = frm.txtTRCode.Text
            r.TRName = frm.txtTrName.Text
            r.TRAmount = frm.txtAmount.Text
            r.TRCourse = frm.coursePK
            If frm.chkYrlevel.Checked Then r.TRYearLevel = -99 Else r.TRYearLevel = frm.cmbEnrollYear.SelectedValue
            If frm.chkSubject.Checked Then r.TRSubject = -99 Else r.TRSubject = frm.subjectPK
            If frm.chkCourse.Checked Then r.TRCourse = -99 Else r.TRCourse = frm.coursePK

            'Student Type
            r.TRStudentType = frm.ComboBoxStudentType.Text

            Me.TRTypesTableAdapter.Update(Me.DsSchool.TRTypes)
        End If
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.TRTypes.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        If MsgBox("Are you sure to delete this Transaction Type?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsSchool.TRTypes(Me.TRTypesBindingSource.Position).Delete()
            Me.TRTypesTableAdapter.Update(Me.DsSchool.TRTypes)
        End If
    End Sub

    Private Sub uTRTypes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TRTypesTableAdapter.Fill(Me.DsSchool.TRTypes)
    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsSchool.TRTypes(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If e.ColumnIndex = 0 Then

            If Me.DsSchool.TRTypes(e.RowIndex).IsTRCourseNull Then Exit Sub

            If Me.DsSchool.TRTypes(e.RowIndex).TRCourse = -99 Then
                e.Value = "Applies to all Courses"
            Else
                e.Value = clsTool.getCourseCompleteDesc(Me.DsSchool.TRTypes(e.RowIndex).TRCourse)
            End If

        End If
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
