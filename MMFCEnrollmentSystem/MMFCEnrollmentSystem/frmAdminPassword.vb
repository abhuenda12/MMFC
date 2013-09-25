Public Class frmAdminPassword

    Public isDirty As Boolean = False

    'Will set isDirty= True if SYS rights value for user is = 1 in userRights table
    'If we allow FIN to approve, we just add "FIN" in the option
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkPassword()
    End Sub

    Private Sub checkPassword()
        If String.IsNullOrEmpty(Me.txtPassword.Text) Then MsgBox("Please put Password") : Exit Sub
        Dim useridOfPasswordgiven As Integer = clsTool.getUserPKbypassword(Me.txtPassword.Text)
        If useridOfPasswordgiven < 0 Then MsgBox("No existing user with that Password.") : Exit Sub
        If clsTool.getRightsbyIDandKey(useridOfPasswordgiven, "SYS") Then
            isDirty = True
            Me.Hide()
        Else
            MsgBox("No Admin Rights.")
            Me.txtPassword.Clear()
            Me.txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            checkPassword()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class