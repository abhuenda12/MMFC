Public Class uReceiptsListing

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub uReceiptsListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DateTimePicker1.Value = Now.Date
        Me.DateTimePicker2.Value = Now.Date
        Me.CashiersTableAdapter.Fill(Me.DsSystem.Cashiers)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'ben10.9.2007 
        Dim cashierfilter As String = "%" + Me.cmbCashier.SelectedValue + "%"
        If Me.chkAllCashiers.Checked Then
            cashierfilter = "%"
        End If

        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.ReceiptsListingTableAdapter
        Dim rep As New crReceiptsListing
        'added cashierfilter ben10.9.2007
        dt.Fill(ds.ReceiptsListing, Me.DateTimePicker1.Value.Date, Me.DateTimePicker2.Value.Date, cashierfilter)
        rep.SetDataSource(ds)
        rep.SetParameterValue("D1", Me.DateTimePicker1.Value.Date)
        rep.SetParameterValue("D2", Me.DateTimePicker2.Value.Date)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()

    End Sub
End Class
