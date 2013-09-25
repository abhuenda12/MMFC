Public Class frmBrokenHours

    Public isDirty As Boolean = False
    Public dayType As String = ""
    Public referenceFrom, referenceTo As Date


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If DateTimePicker2.Value <= DateTimePicker1.Value Then
            MsgBox("Invalid To value. Time for the To value should be greater than the From value.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'validate against reference (or entries for the same day)
        If DateTimePicker1.Value >= referenceFrom And DateTimePicker1.Value <= referenceTo Then
            MsgBox("Your From value should be outside the time frame of the first entry for this day.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If DateTimePicker2.Value >= referenceFrom And DateTimePicker2.Value <= referenceTo Then
            MsgBox("Your To value should be outside the time frame of the first entry for this day.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        isDirty = True

        Me.Hide()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class