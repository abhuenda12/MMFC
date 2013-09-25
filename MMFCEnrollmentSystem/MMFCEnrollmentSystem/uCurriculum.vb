Public Class uCurriculum

    Public coursepk As Integer = -1

    'Choose Course toolbar
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then

            coursepk = frm.m_CoursePK
            getData()

            GroupControl1.Text = "Curriculum By Course (Choose Course from Tool Bar to load the Curriculum) : " _
                    & clsTool.getCourseCompleteDesc(coursepk)

        End If
    End Sub

    Private Sub getData()

        Me.CurriculumbyCourseTableAdapter.Fill(Me.DsReg2.CurriculumbyCourse, coursepk)

        If DsReg2.CurriculumbyCourse.Rows.Count <= 0 Then
            MsgBox("There were no records found.")
        End If
    End Sub

    Public Sub NewDoc()
        Dim frm As New frmCurriculum
        frm.loadData()

        ''If Me.DsReg2.CurriculumbyCourse.Rows.Count > 0 Then
        frm.cmbCourse.SelectedValue = coursepk
        frm.cmbCourse.Enabled = False
        ''End If


        frm.ShowDialog()
        If frm.IsDirty Then
            Me.DsReg2.CurriculumbyCourse.AddCurriculumbyCourseRow(frm.cmbCourse.SelectedValue, frm.yrlevel, _
                                frm.semester, frm.subjectPK, frm.txtRemarks.Text)

            Try
                Me.CurriculumbyCourseTableAdapter.Update(Me.DsReg2.CurriculumbyCourse)
            Catch ex As Exception
                MsgBox("Error saving Curriculum detail! Try Again." & vbCrLf & ex.Message)
            End Try
        End If

        getData()
    End Sub
    Public Sub OpenDoc()
        If Me.DsReg2.CurriculumbyCourse.Rows.Count <= 0 Then MsgBox("Nothing to open!") : Exit Sub

        Dim frm As New frmCurriculum
        frm.loadData()

        With Me.DsReg2.CurriculumbyCourse(Me.CurriculumbyCourseBindingSource.Position)

            If .IsCoursepkNull Then .Coursepk = -1
            If .IsRemarksNull Then .Remarks = ""
            If .IsSemesteridNull Then .Semesterid = 1
            If .IsYearLevelidNull Then .YearLevelid = 1
            If .IsSubjectpkNull Then .Subjectpk = -1

            frm.cmbCourse.SelectedValue = .Coursepk

            Select Case .YearLevelid
                Case 1
                    frm.cmbYrLevel.Text = "1st"
                Case 2
                    frm.cmbYrLevel.Text = "2nd"
                Case 3
                    frm.cmbYrLevel.Text = "3rd"
                Case 4
                    frm.cmbYrLevel.Text = "4th"
                Case 5
                    frm.cmbYrLevel.Text = "5th"
                Case 6
                    frm.cmbYrLevel.Text = "6th"
                Case Else
                    frm.cmbYrLevel.Text = "1st"
            End Select

            Select Case .Semesterid
                Case 1
                    frm.cmbSemester.Text = "First"
                Case 2
                    frm.cmbSemester.Text = "Second"
                Case 3
                    frm.cmbSemester.Text = "Summer"
                Case Else
                    frm.cmbSemester.Text = "First"
            End Select

            ''frm.cmbSubject.SelectedValue = .Subjectpk
            frm.subjectPK = .Subjectpk
            frm.txtSubjectName.Text = clsTool.GetSubjectName(.Subjectpk)

            frm.txtRemarks.Text = .Remarks

            frm.ShowDialog()
            If frm.IsDirty Then
                .Coursepk = frm.cmbCourse.SelectedValue
                .YearLevelid = frm.yrlevel
                .Semesterid = frm.semester
                .Subjectpk = frm.subjectPK
                .Remarks = frm.txtRemarks.Text

                Try
                    Me.CurriculumbyCourseTableAdapter.Update(Me.DsReg2.CurriculumbyCourse)
                Catch ex As Exception
                    MsgBox("Error updating table. Try again." & vbCrLf & ex.Message)
                End Try

                getData()
            End If
        End With

    End Sub
    Public Sub DeleteDoc()
        If Me.DsReg2.CurriculumbyCourse.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Me.DsReg2.CurriculumbyCourse(Me.CurriculumbyCourseBindingSource.Position).Delete()
                Me.CurriculumbyCourseTableAdapter.Update(Me.DsReg2.CurriculumbyCourse)
                getData()
            Catch ex As Exception
                MsgBox("Error deleting data." & vbCrLf & ex.Message)
            End Try
        End If
    End Sub


    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsReg2.CurriculumbyCourse(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If Me.DsReg2.CurriculumbyCourse(e.RowIndex).RowState = DataRowState.Detached Then Exit Sub

        With Me.DsReg2.CurriculumbyCourse(e.RowIndex)
            'course full description including remarks
            ''If e.ColumnIndex = 0 Then
            ''    e.Value = clsTool.getCourseCode(.Coursepk) & " - " & clsTool.getCourseName(.Coursepk) & " - " & clsTool.getCourseRemarks(.Coursepk)
            ''End If
            'yrlevel
            If e.ColumnIndex = 0 Then
                Select Case .YearLevelid
                    Case 1
                        e.Value = "1st Yr"
                    Case 2
                        e.Value = "2nd Yr"
                    Case 3
                        e.Value = "3rd Yr"
                    Case 4
                        e.Value = "4th Yr"
                    Case 5
                        e.Value = "5th Yr"
                    Case 6
                        e.Value = "6th"
                    Case Else
                        e.Value = "No year level"
                End Select
            End If
            'semester
            If e.ColumnIndex = 1 Then
                Select Case .Semesterid
                    Case 1
                        e.Value = "First Sem"
                    Case 2
                        e.Value = "Second Sem"
                    Case 3
                        e.Value = "Summer"
                    Case Else
                        e.Value = "No semester"
                End Select
            End If
            'subject
            If e.ColumnIndex = 2 Then

                ''e.Value = clsTool.GetSubjectName(.Subjectpk)
                e.Value = clsTool.GetSubjectDescription(.Subjectpk)
            End If


        End With
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
