Public Class uChargeSchedule
    Public Sub LoadData()
        Me.ChargeScheduleTableAdapter.Fill(Me.DsFinance.ChargeSchedule)
    End Sub
    Public Sub NewDoc()

        Dim frm As New frmChargeSchedule
        'ben9.27.2007 
        'added initialize line , added required fields in AddRow
        frm.initialize()
        frm.ShowDialog()
        If frm.IsDirty Then
            If frm.txtRemarks.Text.Length > 250 Then frm.txtRemarks.Text = frm.txtRemarks.Text.Substring(0, 250)
            Me.DsFinance.ChargeSchedule.AddChargeScheduleRow(frm.txtCharge.Text, frm.txtSortKey.Text, frm.txtCategory.Text _
                , frm.txtAmount.Text, frm.chkOldStudent.Checked, frm.chkNewStudent.Checked, frm.chkTransferee.Checked, frm.txtRemarks.Text, frm.yrlevel, frm.coursepk)
            Me.ChargeScheduleTableAdapter.Update(Me.DsFinance.ChargeSchedule)
        End If
    End Sub
    Public Sub OpenDoc()

        Dim frm As New frmChargeSchedule
        'ben9.27.2007
        'Added new fields and textboxes
        frm.loadData()
        With Me.DsFinance.ChargeSchedule(Me.ChargeScheduleBindingSource.Position)
            If .IsRemarksNull Then .Remarks = ""
            If .IsyrlevelNull Then .yrlevel = -99
            If .IscoursepkNull Then .coursepk = -99
            If .IsAmountNull Then .Amount = 0
            If .IsCategoryNull Then .Category = ""
            If .IsnewStudentNull Then .newStudent = False
            If .IsoldStudentNull Then .oldStudent = False
            If .IstransferStudentNull Then .transferStudent = False

            frm.txtCharge.Text = .Name
            frm.txtSortKey.Text = .sortorder
            frm.txtCategory.Text = .Category
            frm.txtAmount.Text = FormatNumber(.Amount, 2)
            frm.txtRemarks.Text = .Remarks
            frm.chkNewStudent.Checked = .newStudent
            frm.chkOldStudent.Checked = .oldStudent
            frm.chkTransferee.Checked = .transferStudent
            frm.yrlevel = .yrlevel
            frm.cmbYrLevel.SelectedValue = .yrlevel
            frm.coursepk = .coursepk
            ''frm.cmbCourse.SelectedValue = .coursepk
            frm.txtCourseName.Text = clsTool.getCourseName(.coursepk)

            If .coursepk = -99 Then frm.chkAllCourses.Checked = True
            If .yrlevel = -99 Then frm.chkAllYearLevel.Checked = True

        End With
        frm.ShowDialog()
        If frm.IsDirty Then
            With Me.DsFinance.ChargeSchedule(Me.ChargeScheduleBindingSource.Position)
                .Name = frm.txtCharge.Text
                .sortorder = frm.txtSortKey.Text
                .Category = frm.txtCategory.Text
                .Amount = frm.txtAmount.Text
                If frm.txtRemarks.Text.Length > 250 Then frm.txtRemarks.Text = frm.txtRemarks.Text.Substring(0, 250)
                .Remarks = frm.txtRemarks.Text
                .newStudent = frm.chkNewStudent.Checked
                .oldStudent = frm.chkOldStudent.Checked
                .transferStudent = frm.chkTransferee.Checked
                .yrlevel = frm.yrlevel
                .coursepk = frm.coursepk
            End With
            Me.ChargeScheduleTableAdapter.Update(Me.DsFinance.ChargeSchedule)
        End If
    End Sub
    'ben. 9.27.2007
    'added code 
    Public Sub DeleteDoc()
        If Me.DsFinance.ChargeSchedule.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub

        If MsgBox("Are you sure to remove selected Charge? This cannot be undone.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsFinance.ChargeSchedule(Me.ChargeScheduleBindingSource.Position).Delete()
            Me.ChargeScheduleTableAdapter.Update(Me.DsFinance.ChargeSchedule)
        End If
    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsFinance.ChargeSchedule(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        Try
            If e.ColumnIndex = 6 Then
                If Me.DsFinance.ChargeSchedule(e.RowIndex).IscoursepkNull Then Me.DsFinance.ChargeSchedule(e.RowIndex).coursepk = -99
                If Me.DsFinance.ChargeSchedule(e.RowIndex).coursepk = -99 Then
                    e.Value = "All Courses"
                Else
                    ''e.Value = clsTool.getCourseCode(Me.DsFinance.ChargeSchedule(e.RowIndex).coursepk)
                    e.Value = clsTool.getCourseCompleteDesc(Me.DsFinance.ChargeSchedule(e.RowIndex).coursepk)
                End If
            End If
            If e.ColumnIndex = 7 Then
                If Me.DsFinance.ChargeSchedule(e.RowIndex).IsyrlevelNull Then Me.DsFinance.ChargeSchedule(e.RowIndex).yrlevel = -99
                Select Case Me.DsFinance.ChargeSchedule(e.RowIndex).yrlevel
                    Case 1
                        e.Value = "1st Year"
                    Case 2
                        e.Value = "2nd Year"
                    Case 3
                        e.Value = "3rd Year"
                    Case 4
                        e.Value = "4th Year"
                    Case 5
                        e.Value = "5th Year"
                    Case Else
                        e.Value = "ALL Year Levels"
                End Select
            End If

        Catch ex As Exception
        End Try
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
