Public Class frmTutorialClassList

    Public isDirty As Boolean = False
    Public syofferpk As Integer = -1
    Public sypk, sempk

    Public Sub LoadClassList(ByVal syofferpk As Integer)

        Dim dsr As New dsRegistrar
        Dim drt As New dsRegistrarTableAdapters.ClassListTableAdapter
       
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        drt.Fill(dsr.ClassList, sypk, sempk, syofferpk)

        If dsr.ClassList.Rows.Count = 0 Then MsgBox("No Records Found!") : frm.Hide() : Exit Sub

        Dim ctr As Integer

        Dim coursecode As String = ""

        For ctr = 0 To dsr.ClassList.Rows.Count - 1
            coursecode = clsTool.getStudentCourseCode(sempk, sypk, dsr.ClassList(ctr).studentpk)
            Me.DsRep.ClassList.AddClassListRow(clsTool.getStudentName(dsr.ClassList(ctr).studentpk), coursecode)
        Next

        frm.Hide()

    End Sub

    'Confirm Charges
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If syofferpk = -1 Then
            MsgBox("There was no offering selected")
            Exit Sub

        End If

        isDirty = True

        Me.Hide()

    End Sub

End Class