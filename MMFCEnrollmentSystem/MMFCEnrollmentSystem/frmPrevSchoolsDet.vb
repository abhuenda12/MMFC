Public Class frmPrevSchoolsDet

    Public isDirty As Boolean = False
    Public studentPK As Integer = -1

    Public Sub loadData()
        Me.PreviousSchoolsByStudentPKTableAdapter.Fill(Me.DsReg2.PreviousSchoolsByStudentPK, studentPK)
    End Sub

    'On Save
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click

        'to end the edit of the current row. EndEdit  method does not completely edit it.
        Me.PreviousSchoolsByStudentPKBindingSource.Position = Me.DataGridView1.NewRowIndex

        If Me.DsReg2.PreviousSchoolsByStudentPK.Rows.Count <= 0 Then MsgBox("Nothing to save!") : Exit Sub

        isDirty = True
        Me.Hide()

    End Sub


    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

        If e.ColumnIndex = 0 And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value).Length > 300 Then
            MsgBox("You've exceeded the allowed school name length of 300 characters. Please modify.")
        End If

    End Sub
End Class