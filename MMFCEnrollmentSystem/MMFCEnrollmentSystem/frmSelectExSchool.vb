Public Class frmSelectExSchool

    Public StudentPK As Integer = -1
    Public PreviousSchool As String = ""
    Public isDirty As Boolean = False

    Public Sub LoadData()

        PreviousSchoolsByStudentPKTableAdapter.Fill(DsSchool2.PreviousSchoolsByStudentPK, StudentPK)

        If DsSchool2.PreviousSchoolsByStudentPK.Rows.Count <= 0 Then

            MsgBox("There are no configured Previous Schools for this student.", MsgBoxStyle.Exclamation, "Warning")
            Close()
        End If

    End Sub

    Sub ChooseSchool()

        If DsSchool2.PreviousSchoolsByStudentPK.Rows.Count <= 0 Then Me.Hide()

        PreviousSchool = DsSchool2.PreviousSchoolsByStudentPK(PreviousSchoolsByStudentPKBindingSource.Position).PrevShool

        isDirty = True

        Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChooseSchool()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class