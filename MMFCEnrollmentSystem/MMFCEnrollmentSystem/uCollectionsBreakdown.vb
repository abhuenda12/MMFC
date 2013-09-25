Public Class uCollectionsBreakdown
    'Created ben11.23.2007 
    'Client Request

    Public Sub LoadData()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.txtSY.SelectedValue = clsTool.GetCurYearPK
        Me.txtSEM.SelectedValue = clsTool.GetCurSemPK
        Me.rdoStudentName.Checked = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.chkAllSemesters.Checked Then
            loadReportAllSems()
        Else
            loadReport()
        End If
    End Sub
    
    Private Sub loadReport()        

        Dim ds As New dsFinance.CollectionBreakdownDataTable
        Dim dt As New dsFinanceTableAdapters.CollectionBreakdownTableAdapter
        Dim dsRep As New dsRep

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        dt.Fill(ds, Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, Me.DateTimePicker1.Value.Date, Me.DateTimePicker2.Value.Date)

        If ds.Rows.Count <= 0 Then MsgBox("No records found!") : frm.Hide() : Exit Sub

        Dim namecourseorno As String = ""
        Dim name As String = ""
        Dim lengthname As Integer = 0
        Dim course As String = ""
        Dim remarks As String = ""
        Dim secondcourser As Boolean = False
        Dim sorter As Int64 = 0
        Dim OrRef As Int64 = 0
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            name = clsTool.getStudentName(ds(i).studentpk).ToUpper
            course = clsTool.getStudentCourseCode(Me.txtSEM.SelectedValue, Me.txtSY.SelectedValue, ds(i).studentpk)
            'Ben 3.17.2008 . For Second Coursers , a separate column is needed in report
            secondcourser = clsTool2.checkIfStudent2ndcourser(ds(i).studentpk)
            'code that follows is for the name manipulation             
            lengthname = name.Length
            Do While lengthname < 25
                name += "_"
                lengthname = name.Length
            Loop
            If ds(i).IsORRefNull Or Not IsNumeric(ds(i).ORRef) Then ds(i).ORRef = "0"
            namecourseorno = name & " | " & course & " | " & ds(i).ORRef  ''for checking if still needed

            'Sorter ================================================================================
            If Me.rdoStudentName.Checked Then
                'alphabetically by name. if studentpk same on next record , dont change sorter
                If i = 0 Then 'for first record , no checking
                    sorter = i
                Else
                    If ds(i).studentpk <> ds(i - 1).studentpk Or ds(i).ORRef <> ds(i - 1).ORRef Then
                        'only change sorter value if current record is a new student Or it's a new OR # 
                        sorter = i
                    End If
                End If

            Else 'by OR No Series
                'get floor of ORref so as to avoid decimal nos
                sorter = Math.Floor(CDbl(ds(i).ORRef))
            End If
            '======================================================================================

            OrRef = Math.Floor(CDbl(ds(i).ORRef))

            '=======================================================================================
            'Filter breakdown combo box Ben 12.10.2007 
            '=======================================================================================
            If Me.cmbFilter.Text = "ALL" Or cmbFilter.Text = "" Then
                If ds(i).remarks.ToUpper.Contains("ENROLLMENT") Then ds(i).remarks = ds(i).remarks.Remove(0, 12)
                If secondcourser And ds(i).remarks.ToUpper.Contains("TUITION") Then ds(i).remarks = "TUITION 2ND C."

                ' Ben 3.18.2008 . Convert OTHER FEES to OF-_________ to fit in report
                If ds(i).remarks.ToUpper.Contains("OTHER FEES") Then
                    ds(i).remarks = ds(i).remarks.Replace("OTHER FEES", "OF")
                End If


                dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
            Else 'only add to report those meeting filter in combo box

                'TUITION FEE 2ND COURSER ONLY
                If Me.cmbFilter.Text.ToUpper = "TUITION FEE 2ND COURSER" Then
                    If secondcourser And ds(i).remarks.ToUpper.Contains("TUITION") Then
                        ds(i).remarks = "TUITION 2ND C."
                        dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
                    End If

                ElseIf ds(i).remarks.ToUpper.Contains(Me.cmbFilter.Text.ToUpper) Then

                    If ds(i).remarks.ToUpper.Contains("ENROLLMENT") Then ds(i).remarks = ds(i).remarks.Remove(0, 12)

                    ' Ben 3.18.2008 . Convert OTHER FEES to OF-_________ to fit in report
                    If ds(i).remarks.ToUpper.Contains("OTHER FEES") Then
                        ds(i).remarks = ds(i).remarks.Replace("OTHER FEES", "OF")
                    End If


                    dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
                End If

            End If
            '==================================================================================================

        Next

        ''for debugging only ==================
        'Dim frm1 As New Form
        'Dim dgrid As New DataGrid
        'frm1.Controls.Add(dgrid)
        'dgrid.DataSource = dsRep.TemplateCollectionBreakdown.Select(String.Empty, "ORNo")
        ''dgrid.DataMember = "TemplateCollectionBreakdown"
        'dgrid.Dock = DockStyle.Fill
        'frm1.Show()

        ''=====================================

        If Me.chkPortrait.Checked Then

            If Me.chkIncludeCancelledOR.Checked Then
                Dim rep As New crCollectionBreakdowninPortraitWithCancelledORs
                Dim dtORCan As New dsRepTableAdapters.ReceiptsHeaderByStatusTableAdapter
                dtORCan.Fill(dsRep.ReceiptsHeaderByStatus, 1, Me.DateTimePicker1.Value.ToShortDateString, CDate(Me.DateTimePicker2.Value.ToShortDateString & " 11:59:59 PM"))
                Dim rep2 As New crCollectionCancelledORs
                rep2.SetDataSource(dsRep)

                rep.SetDataSource(dsRep)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("START", Me.DateTimePicker1.Value)
                rep.SetParameterValue("END", Me.DateTimePicker2.Value)

                Me.grpSorter.ReportSource = rep

            Else
                Dim rep As New crCollectionBreakdowninPortrait
                rep.SetDataSource(dsRep)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("START", Me.DateTimePicker1.Value)
                rep.SetParameterValue("END", Me.DateTimePicker2.Value)

                Me.grpSorter.ReportSource = rep

            End If

            Me.grpSorter.RefreshReport()

        Else
            If Me.chkIncludeCancelledOR.Checked Then
                Dim rep As New crCollectionBreakdownWithCancelledORs
                Dim dtORCan As New dsRepTableAdapters.ReceiptsHeaderByStatusTableAdapter
                dtORCan.Fill(dsRep.ReceiptsHeaderByStatus, 1, Me.DateTimePicker1.Value.ToShortDateString, CDate(Me.DateTimePicker2.Value.ToShortDateString & " 11:59:59 PM"))
                Dim rep2 As New crCollectionCancelledORs
                rep2.SetDataSource(dsRep)
                rep.SetDataSource(dsRep)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("START", Me.DateTimePicker1.Value)
                rep.SetParameterValue("END", Me.DateTimePicker2.Value)
                Me.grpSorter.ReportSource = rep

            Else
                Dim rep As New crCollectionBreakdown
                rep.SetDataSource(dsRep)
                rep.SetParameterValue("pSY", Me.txtSY.Text)
                rep.SetParameterValue("pSem", Me.txtSEM.Text)
                rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
                rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
                rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
                rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
                rep.SetParameterValue("START", Me.DateTimePicker1.Value)
                rep.SetParameterValue("END", Me.DateTimePicker2.Value)
                Me.grpSorter.ReportSource = rep

            End If

            Me.grpSorter.RefreshReport()
        End If
        frm.Hide()
    End Sub

    Private Sub loadReportAllSems()
        Dim ds As New dsFinance.CollectionBreakdownAllSemestersDataTable
        Dim dt As New dsFinanceTableAdapters.CollectionBreakdownAllSemestersTableAdapter
        Dim dsRep As New dsRep

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        dt.Fill(ds, Me.DateTimePicker1.Value.Date, Me.DateTimePicker2.Value.Date)

        Dim namecourseorno As String = ""
        Dim name As String = ""
        Dim lengthname As Integer = 0
        Dim course As String = ""
        Dim remarks As String = ""
        Dim secondcourser As Boolean = False
        Dim sorter As Int64 = 0
        Dim OrRef As Int64 = 0
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            name = clsTool.getStudentName(ds(i).studentpk).ToUpper
            course = clsTool.getStudentCourseCode(clsTool.GetCurSemPK, clsTool.GetCurYearPK, ds(i).studentpk)
            'Ben 3.17.2008 . For Second Coursers , a separate column is needed in report
            secondcourser = clsTool2.checkIfStudent2ndcourser(ds(i).studentpk)
            'code that follows is for the format manipulation             
            lengthname = name.Length
            Do While lengthname < 25
                name += "_"
                lengthname = name.Length
            Loop

            If ds(i).IsORRefNull Or Not IsNumeric(ds(i).ORRef) Then ds(i).ORRef = "0"
            namecourseorno = name & " | " & course & " | " & ds(i).ORRef

            'Sorter ================================================================================
            If Me.rdoStudentName.Checked Then
                'alphabetically by name. if studentpk same on next record , dont change sorter
                If i = 0 Then 'for first record , no checking
                    sorter = i
                Else
                    If ds(i).studentpk <> ds(i - 1).studentpk Or ds(i).ORRef <> ds(i - 1).ORRef Then
                        'only change sorter value if current record is a new student or at new OR#
                        sorter = i
                    End If
                End If

            Else 'by OR No Series
                sorter = Math.Floor(CDbl(ds(i).ORRef))
            End If
            '======================================================================================

            OrRef = Math.Floor(CDbl(ds(i).ORRef))

            '=======================================================================================
            'Filter breakdown combo box Ben 12.10.2007 
            '=======================================================================================
            If Me.cmbFilter.Text = "ALL" Or cmbFilter.Text = "" Then
                If ds(i).remarks.ToUpper.Contains("ENROLLMENT") Then ds(i).remarks = ds(i).remarks.Remove(0, 12)
                If secondcourser And ds(i).remarks.ToUpper.Contains("TUITION") Then ds(i).remarks = "TUITION 2ND C."

                ' Ben 3.18.2008 . Convert OTHER FEES to OF-_________ to fit in report
                If ds(i).remarks.ToUpper.Contains("OTHER FEES") Then
                    ds(i).remarks = ds(i).remarks.Replace("OTHER FEES", "OF")
                End If

                dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
            Else

                'TUITION FEE 2ND COURSER ONLY
                If Me.cmbFilter.Text.ToUpper = "TUITION FEE 2ND COURSER" Then

                    If secondcourser And ds(i).remarks.ToUpper.Contains("TUITION") Then
                        ds(i).remarks = "TUITION 2ND C."
                        dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
                    End If

                ElseIf ds(i).remarks.ToUpper.Contains(Me.cmbFilter.Text.ToUpper) Then

                    If ds(i).remarks.ToUpper.Contains("ENROLLMENT") Then ds(i).remarks = ds(i).remarks.Remove(0, 12)

                    ' Ben 3.18.2008 . Convert OTHER FEES to OF-_________ to fit in report
                    If ds(i).remarks.ToUpper.Contains("OTHER FEES") Then
                        ds(i).remarks = ds(i).remarks.Replace("OTHER FEES", "OF")
                    End If

                    dsRep.TemplateCollectionBreakdown.AddTemplateCollectionBreakdownRow(sorter, namecourseorno, ds(i).remarks, ds(i).amount, OrRef, name, course)
                End If

            End If
            '========================================================================================

        Next


        If Me.chkPortrait.Checked Then
            Dim rep As New crCollectionBreakdowninPortrait
            rep.SetDataSource(dsRep)
            rep.SetParameterValue("pSY", "")
            rep.SetParameterValue("pSem", "")
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            rep.SetParameterValue("START", Me.DateTimePicker1.Value)
            rep.SetParameterValue("END", Me.DateTimePicker2.Value)
            Me.grpSorter.ReportSource = rep
            Me.grpSorter.RefreshReport()

        Else
            Dim rep As New crCollectionBreakdown
            rep.SetDataSource(dsRep)
            rep.SetParameterValue("pSY", Me.txtSY.Text)
            rep.SetParameterValue("pSem", Me.txtSEM.Text)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            rep.SetParameterValue("START", Me.DateTimePicker1.Value)
            rep.SetParameterValue("END", Me.DateTimePicker2.Value)
            Me.grpSorter.ReportSource = rep
            Me.grpSorter.RefreshReport()
        End If
        frm.Hide()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles grpSorter.ReportRefresh
        e.Handled = True
    End Sub


    Private Sub chkAllSemesters_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllSemesters.CheckedChanged
        If Me.chkAllSemesters.Checked Then
            Me.Label1.Enabled = False
            Me.Label2.Enabled = False
            Me.txtSEM.Enabled = False
            Me.txtSY.Enabled = False
        Else
            Me.Label1.Enabled = True
            Me.Label2.Enabled = True
            Me.txtSEM.Enabled = True
            Me.txtSY.Enabled = True
        End If
    End Sub
End Class
