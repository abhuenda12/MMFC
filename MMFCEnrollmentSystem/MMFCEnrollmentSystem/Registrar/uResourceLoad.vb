Public Class uResourceLoad

    Public m_resourcePK = -1

    Private Sub uResourceLoad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Me.SchoolResourcesTableAdapter.Fill(Me.DsSchool.SchoolResources)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        ComboBox2.SelectedValue = clsTool.GetCurSemPK

        REM added 7.1.2012
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK()
    End Sub


    'Choose Resource
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim frm As New frmSchoolResourcesSelect
        frm.TextBox1.Select()
        frm.ShowDialog()

        If frm.Selected Then
            With frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position)
                m_resourcePK = .ResourcePrikey
                TextBoxResourceName.Text = .ResourceName
            End With

        End If


    End Sub

    'Load Report
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If m_resourcePK = -1 Then
            MsgBox("Please choose a resource first!", MsgBoxStyle.Critical, "Error!")
            Exit Sub
        End If

        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyResourceTableAdapter

        Dim frm As New frmWait
        frm.Show()

        Application.DoEvents()

        dt.Fill(ds.SYOfferingbyResource, m_resourcePK, cmbSY.SelectedValue, ComboBox2.SelectedValue)
        If ds.SYOfferingbyResource.Rows.Count = 0 Then
            MsgBox("No records found for resource in the selected semester!")
            frm.Hide()
            Exit Sub
        Else
            Dim ctr As Integer
            ds.TemplateResourceLoad.Clear()

            For ctr = 0 To ds.SYOfferingbyResource.Rows.Count - 1
                'ben10.16.2007
                Dim teacher, starttime, endtime, daysked As String
                Dim sorter As Integer = 0
                Dim r As dsRegistrar.SYOfferingbyResourceRow = ds.SYOfferingbyResource(ctr)

                daysked = clsTool.getSYOfferDays(r.syofferingpk)
                starttime = clsTool.getSYOfferStart(r.syofferingpk)
                endtime = clsTool.getSYOfferEnd(r.syofferingpk)
                teacher = clsTool.getTeacherName(r.teacherid)

                Dim daypart As String = ""
                If starttime.ToUpper.Contains("AM") Then daypart = "AM" Else daypart = "PM"

                Dim indexofcolon As Integer = starttime.IndexOf(":")
                Dim timepart As Integer = 0
                timepart = CInt(starttime.Remove(indexofcolon))

                If daypart = "AM" Then sorter = timepart Else sorter = timepart + 12

                With ds.SYOfferingbyResource(ctr)
                    ds.TemplateResourceLoadReport.AddTemplateResourceLoadReportRow(cmbSY.Text, _
                          clsTool.getSEMName(ComboBox2.SelectedValue), teacher, clsTool.GetSubjectDescription(.subjectpk), _
                          daysked, starttime, endtime, sorter)
                End With

                'Start the Broken Hours SubReport Here
                '
                '
                Dim subjectpk As Integer = clsTool.getSYOfferSubjectID(r.syofferingpk)

                'now check for extra/different hours (also broken hours) 
                Dim thisSyofferPK = r.syofferingpk
                Dim hasotherskeds As Boolean = clsTool.CheckSYOfferHasDifferentTimeSkeds(thisSyofferPK)
                Dim thisSubjectName As String = clsTool.GetSubjectName(subjectpk)

                'add rows to template for each different sked for same subject
                If hasotherskeds Then
                    Dim daytimesked As String = clsTool.getSYOfferFullSked(thisSyofferPK)

                    ds.BrokenHoursTemplate.AddBrokenHoursTemplateRow(thisSubjectName, daytimesked)

                End If
                '
                '
                'END Broken Hours

            Next 'Loop of SYOfferingByResource
        End If

        '===ben12.3.2007 =============================================================
        '===  get vacant hours per day ==================================================

        Dim monday As New List(Of String)()
        Dim tuesday As New List(Of String)()
        Dim wednesday As New List(Of String)()
        Dim thursday As New List(Of String)()
        Dim friday As New List(Of String)()
        Dim saturday As New List(Of String)()
        Dim sunday As New List(Of String)()

        Dim i As Integer
        Dim starttime2 As Decimal = 0
        Dim endtime2 As Decimal = 0

        For i = 0 To ds.TemplateResourceLoadReport.Rows.Count - 1
            With ds.TemplateResourceLoadReport(i)
                .start = .start.Replace(":", ".")
                ._end = ._end.Replace(":", ".")

                If .start.Length = 7 Then starttime2 = Convert.ToDecimal(.start.Substring(0, 3)) Else starttime2 = Convert.ToDecimal(.start.Substring(0, 4))
                If ._end.Length = 7 Then endtime2 = Convert.ToDecimal(._end.Substring(0, 3)) Else endtime2 = Convert.ToDecimal(._end.Substring(0, 4))
                If .start.ToUpper.Contains("PM") And starttime2 < 12 Then starttime2 += 12
                If ._end.ToUpper.Contains("PM") And endtime2 < 12 Then endtime2 += 12

                If .Days.ToUpper.Contains("M") Then monday.Add(starttime2 & "," & endtime2)
                If .Days.ToUpper.Contains("T") And Not .Days.ToUpper.Contains("H") Then
                    tuesday.Add(starttime2 & "," & endtime2)
                ElseIf .Days.ToUpper.Contains("T") And .Days.ToUpper.Contains("H") Then
                    'check if H does not occur next to T , then that is a tuesday
                    'MTWThF sample
                    Dim indexofH As Integer = .Days.ToUpper.IndexOf("H")
                    If Not .Days.ToUpper.IndexOf("T") + 1 = indexofH Then tuesday.Add(starttime2 & "," & endtime2)
                End If
                If .Days.ToUpper.Contains("W") Then wednesday.Add(starttime2 & "," & endtime2)
                If .Days.ToUpper.Contains("TH") Then thursday.Add(starttime2 & "," & endtime2)
                If .Days.ToUpper.Contains("F") Then friday.Add(starttime2 & "," & endtime2)
                If .Days.ToUpper.Contains("SA") Then saturday.Add(starttime2 & "," & endtime2)
                If .Days.ToUpper.Contains("SU") Then sunday.Add(starttime2 & "," & endtime2)
            End With
        Next

        'for debugging------------------------
        ''Dim myform0 As New Form
        ''Dim mylistbox0 As New ListBox
        ''mylistbox0.DataSource = monday
        ''myform0.Text = "Before Sorting"
        ''myform0.Show()
        ''myform0.Controls.Add(mylistbox0)
        ''mylistbox0.Dock = DockStyle.Fill
        '--------------------------------------


        sortList(monday)
        sortList(tuesday)
        sortList(wednesday)
        sortList(thursday)
        sortList(friday)
        sortList(saturday)
        sortList(sunday)

        'for debugging-----------------------------
        ''Dim myform As New Form
        ''Dim mylistbox As New ListBox
        ''mylistbox.DataSource = monday
        ''myform.Text = "After Sorting"
        ''myform.Show()
        ''myform.Controls.Add(mylistbox)
        ''mylistbox.Dock = DockStyle.Fill
        '-------------------------------------------

        Dim vacantM As String = getVacant(monday)
        Dim vacantT As String = getVacant(tuesday)
        Dim vacantW As String = getVacant(wednesday)
        Dim vacantTh As String = getVacant(thursday)
        Dim vacantF As String = getVacant(friday)
        Dim vacantSa As String = getVacant(saturday)
        Dim vacantSu As String = getVacant(sunday)

        '=================================================================================================
        '=================================================================================================

        

        If Not Me.chkExcludeTeacher.Checked Then Me.chkExcludeTeacher.Checked = False 'For null handling

        If Me.chkExcludeTeacher.Checked Then
            Dim rep As New crResourceLoadNoTeacher
            rep.SetDataSource(ds)

            'Broken Hours
            rep.Subreports(0).SetDataSource(ds)

            rep.SetParameterValue("pResourceName", TextBoxResourceName.Text)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            rep.SetParameterValue("VM", vacantM)
            rep.SetParameterValue("VT", vacantT)
            rep.SetParameterValue("VW", vacantW)
            rep.SetParameterValue("VTH", vacantTh)
            rep.SetParameterValue("VF", vacantF)
            rep.SetParameterValue("VSA", vacantSa)
            rep.SetParameterValue("VSU", vacantSu)
            Me.CrystalReportViewer1.ReportSource = rep
            Me.CrystalReportViewer1.RefreshReport()
        Else
            Dim rep As New crResourceLoad
            rep.SetDataSource(ds)

            'Broken Hours
            rep.Subreports(0).SetDataSource(ds)

            rep.SetParameterValue("pResourceName", Me.TextBoxResourceName.Text)
            rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
            rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
            rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
            rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
            rep.SetParameterValue("VM", vacantM)
            rep.SetParameterValue("VT", vacantT)
            rep.SetParameterValue("VW", vacantW)
            rep.SetParameterValue("VTH", vacantTh)
            rep.SetParameterValue("VF", vacantF)
            rep.SetParameterValue("VSA", vacantSa)
            rep.SetParameterValue("VSU", vacantSu)
            Me.CrystalReportViewer1.ReportSource = rep
            Me.CrystalReportViewer1.RefreshReport()
        End If

        frm.Hide()
    End Sub

    Sub sortList(ByVal list As List(Of String))
        'Sort the list ascending time        
        Dim currentvalue As Double = 0
        Dim basecomparisonvalue As Double = 0
        Dim basecomparisonindex As Integer = 0
        Dim index As Integer
        Dim tempoholder As String = ""

        'Compare the first record with all the records 
        '   and get the least amongst the list put it at current index (do a swap)
        'at suceeding loops do the same iteration putting 
        '    the next least value at current x

        For basecomparisonindex = 0 To list.Count - 2
            basecomparisonvalue = CDbl(list(basecomparisonindex).Substring(0, list(basecomparisonindex).IndexOf(",")))

            For index = 0 To list.Count - 1

                'only compare values >= basecomparisonindex
                If index >= basecomparisonindex Then

                    currentvalue = CDbl(list(index).Substring(0, list(index).IndexOf(",")))
                    'compare values then swap 
                    If currentvalue < basecomparisonvalue Then
                        'put basecomparisonrecord at a tempo holder
                        tempoholder = list(basecomparisonindex)
                        'put currentvaluerecord at basecomparisonindex
                        list(basecomparisonindex) = list(index)
                        'put tempoholder record at currentvalueindex
                        list(index) = tempoholder

                        'change basecomparisonvalue to the new least value
                        basecomparisonvalue = CDbl(list(basecomparisonindex).Substring(0, list(basecomparisonindex).IndexOf(",")))
                    End If

                End If

            Next
        Next

    End Sub

    'ben12.3
    Sub sortListold(ByVal list As List(Of String))
        'Sort the list ascending time
        Dim goSwap As Boolean = False
        Dim currentrecord As String = ""
        Dim indexcurrentrecord As Integer = 0
        Dim x, y As Integer
        For x = 0 To list.Count - 1
            If x < list.Count - 1 Then
                currentrecord = list(x)
                'put in monday(i) The lowest among the monday(j's).. 
                For y = 0 To list.Count - 1
                    If y <= x Then Continue For 'only compare with next elements
                    If CDbl(list(y).Substring(0, list(y).IndexOf(","))) < _
                       CDbl(currentrecord.Substring(0, currentrecord.IndexOf(","))) Then
                        currentrecord = list(y)
                        indexcurrentrecord = y
                        goSwap = True
                    End If
                Next
                'swap monday(i) with holder                 
                If goSwap Then
                    list(indexcurrentrecord) = list(x)
                    list(x) = currentrecord
                End If
            End If
        Next

    End Sub
    'Ben 3.13.2008
    Function getVacant(ByVal list As List(Of String)) As String
        If list.Count <= 0 Then Return "WHOLE DAY"
        Dim vacantsked As String = "12AM to "
        Dim skedstart As Double = 0
        Dim skedend As Double = 0
        Dim vacantstart As Double = 0
        Dim vacantend As Double = 0
        Dim index As Integer

        For index = 0 To list.Count - 1

            'only for first record index=0. get the first column of the first record in the listbox 
            'this should be the endtime of the first vacant sked for that day
            If index = 0 Then
                skedstart = CDbl(list(index).Substring(0, list(index).IndexOf(",")))
                '2 cases, prior to 12.59 and after 12.59
                If skedstart >= 13 Then
                    'equal and after 13 or 1pm so deduct 12                     
                    vacantsked += CStr(skedstart - 12) & "PM , "
                Else 'prior and equal to 12.59
                    '2 cases , 12.0 up to 12.59 and the rest
                    If skedstart >= 12 Then
                        'put PM
                        vacantsked += CStr(skedstart) & "PM , "
                    Else
                        'put AM
                        vacantsked += CStr(skedstart) & "AM , "
                    End If
                End If
                'get the 1st records skedend
                skedend = CDbl(list(index).Substring(list(index).IndexOf(",") + 1))
            End If

            'for 2nd record and up
            If index > 0 Then

                'check the skedstart of the current record
                skedstart = CDbl(list(index).Substring(0, list(index).IndexOf(",")))
                'compare previous skedend with skedstart
                If skedend < skedstart Then
                    'there's a vacant sked = skedend up to the current records skedstart
                    '2 cases skedend , prior to 13 and equal or greater than 13
                    If skedend >= 13 Then
                        vacantsked += CStr(skedend - 12) & "PM to "
                    Else
                        '2 cases , 12.0 up to 12.59 and the rest
                        If skedend >= 12 Then
                            'put PM
                            vacantsked += CStr(skedend) & "PM to "
                        Else
                            'put AM
                            vacantsked += CStr(skedend) & "AM to "
                        End If
                    End If

                    'Append the skedstart which is the end of the vacantsked for this stage
                    '2 cases skedstart, prior to 13 and equal or after 13
                    If skedstart >= 13 Then
                        'equal and after 13 or 1pm so deduct 12                     
                        vacantsked += CStr(skedstart - 12) & "PM , "
                    Else 'prior and equal to 12.59
                        '2 cases , 12.0 up to 12.59 and the rest
                        If skedstart >= 12 Then
                            'put PM
                            vacantsked += CStr(skedstart) & "PM , "
                        Else
                            'put AM
                            vacantsked += CStr(skedstart) & "AM , "
                        End If
                    End If

                    'get the sked end of current record
                    skedend = CDbl(list(index).Substring(list(index).IndexOf(",") + 1))
                Else
                    'skedend is same as skedstart of current record so no vacant for this stage
                    'get the sked end of current record
                    skedend = CDbl(list(index).Substring(list(index).IndexOf(",") + 1))
                End If

            End If 'if index > 0 block

        Next

        'FINISHED LOOPING

        'add last records skedend
        If skedend >= 13 Then
            vacantsked += CStr(skedend - 12) & "PM to 12AM"
        Else
            '2 cases , 12.0 up to 12.59 and the rest
            If skedend >= 12 Then
                'put PM
                vacantsked += CStr(skedend) & "PM to 12AM"
            Else
                'put AM
                vacantsked += CStr(skedend) & "AM to 12AM"
            End If
        End If

        Return vacantsked
    End Function

    'ben12.3
    Function getVacantoldcode(ByVal list As List(Of String)) As String
        Dim s As String = "12AM to "
        Dim start As Double = 0
        Dim endtime As Double = 0
        Dim j As Integer
        For j = 0 To list.Count - 1
            start = CDbl(list(j).Substring(0, list(j).IndexOf(",")))
            If start <= endtime Then 'previous endtime
                endtime = CDbl(list(j).Substring(list(j).IndexOf(",") + 1))
                If j = list.Count - 1 Then 'check if last record, print the endtime if last
                    If endtime >= 12 Then
                        If endtime < 13 Then
                            s += endtime & "PM to "
                        Else
                            endtime = endtime - 12
                            s += endtime & "PM to "
                        End If
                    Else
                        s += endtime & "AM to "
                    End If
                End If
                Continue For
            End If

            If start >= 12 Then
                If start < 12 Then
                    s += start & "PM , "
                Else
                    start = start - 12
                    s += start & "PM , "
                End If
            Else
                s += start & "AM , "
            End If

            endtime = CDbl(list(j).Substring(list(j).IndexOf(",") + 1))

            If j = list.Count - 1 Then
                If endtime >= 12 Then
                    If endtime < 13 Then
                        s += endtime & "PM to "
                    Else
                        endtime = endtime - 12
                        s += endtime & "PM to "
                    End If
                Else
                    s += endtime & "AM to "
                End If
                Continue For
            End If

            If endtime = CDbl(list(j + 1).Substring(0, list(j + 1).IndexOf(","))) Then Continue For

            If endtime >= 12 Then
                If endtime < 13 Then
                    s += endtime & "PM to "
                Else
                    endtime = endtime - 12
                    s += endtime & "PM to "
                End If
            Else
                s += endtime & "AM to "
            End If

        Next
        s += "12AM"
        Return s
    End Function


    Function CountStudents(ByVal sypk As Integer, ByVal sempk As Integer, ByVal subjectpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCountTableAdapter
        Dim rval As Integer = 0
        dt.Fill(ds.EnrollSubjectsCount, clsTool.GetCurYearPK, sempk, subjectpk)
        If ds.EnrollSubjectsCount.Rows.Count > 0 Then
            rval = ds.EnrollSubjectsCount(0).StudentCount.ToString
        End If
        Return rval
    End Function


  

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

End Class
