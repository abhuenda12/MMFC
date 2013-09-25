Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class uStudentPermit

    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""
    Dim lastpermitno As String = ""

    Public Sub loadData()

        lastpermitno = clsTool.GetSetting("EXAMPERMIT")

        'get last Permit # used then add 1
        If Not IsNumeric(lastpermitno) Then lastpermitno = "0"

        Me.txtPermitNo.Text = CInt(lastpermitno) + 1
        Me.txtSAO.Text = clsTool.GetSetting("SAO")
    End Sub
    
    'choose student
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.M_StudentName = frm.m_StudentName
            TextBox1.Text = frm.m_StudentName
        End If
    End Sub
    'Load button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        printPermit()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub printPermit()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim rep As New crStudentPermit

        rep.SetParameterValue("STUDENT", Me.m_StudentName)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME").ToUpper)
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep.SetParameterValue("EXAM", Me.txtExam.Text.ToUpper)
        rep.SetParameterValue("PERMITNO", Me.txtPermitNo.Text)
        rep.SetParameterValue("PAYMONTH", Me.datePaymentMonth.Value)
        rep.SetParameterValue("VALIDITY", Me.dateValidity.Value)

        If Me.chkEmptyIssuedDate.Checked Then
            rep.SetParameterValue("DATEISSUED", "_________________")
        Else
            Dim startofcomma As Integer = Me.dateIssued.Value.ToLongDateString.IndexOf(",")
            rep.SetParameterValue("DATEISSUED", Me.dateIssued.Value.ToLongDateString.Substring(startofcomma + 1))
        End If

        rep.SetParameterValue("SAO", Me.txtSAO.Text)

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()

        frm.Hide()

        updatePermitNo()
        Me.loadData()
    End Sub

    Private Sub updatePermitNo()

        'we only update preftable if the permit # used is lastpermitno+1 
        'else if the user changed the permit # (reprint) we don't update

        If Me.txtPermitNo.Text = CStr(CInt(lastpermitno) + 1) Then

            Dim ds As New dsSchool.PrefTableDataTable
            Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter

            dt.Fill(ds, "EXAMPERMIT")
            If ds.Rows.Count <= 0 Then Exit Sub
            ds(0).PrefValue = Me.txtPermitNo.Text
            Try
                dt.Update(ds)
            Catch ex As Exception
                MsgBox("Error updating Permit No value in Preference Table." & vbCrLf & ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtPermitNo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPermitNo.MouseEnter
        Me.lblMessage.Visible = True
    End Sub

    
    Private Sub txtPermitNo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPermitNo.MouseLeave
        Me.lblMessage.Visible = False
    End Sub
End Class
