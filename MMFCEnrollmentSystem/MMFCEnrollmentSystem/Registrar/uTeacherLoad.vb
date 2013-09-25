Public Class uTeacherLoad
    Dim teacherpk As Integer = -1

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs)
        Dim r As dsSchool.SYOfferingbyTeacherRow
        r = Me.DsSchool.SYOfferingbyTeacher(Me.SYOfferingbyTeacherBindingSource.Position)
        If e.ColumnIndex = 0 Then
            e.Value = clsTool.GetSubjectDescription(r.subjectpk)
        End If
        If e.ColumnIndex = 1 Then
            e.Value = clsTool.getResourceName(r.resource)
        End If
        If e.ColumnIndex = 2 Then
            If r.monday Then
                e.Value = clsTool.getTime(r.monfrom) & "-" & clsTool.getTime(r.monto)
            Else
                e.Value = ""
            End If
        End If
        If e.ColumnIndex = 3 Then
            If r.tuesday Then
                e.Value = clsTool.getTime(r.tuesfrom) & "-" & clsTool.getTime(r.tuesto)
            End If
        End If
        If e.ColumnIndex = 4 Then
            If r.wednesday Then
                e.Value = clsTool.getTime(r.wedfrom) & "-" & clsTool.getTime(r.wedto)
            End If
        End If
        If e.ColumnIndex = 5 Then
            If r.thursday Then
                e.Value = clsTool.getTime(r.thufrom) & "-" & clsTool.getTime(r.thuto)
            End If
        End If
        If e.ColumnIndex = 6 Then
            If r.friday Then
                e.Value = clsTool.getTime(r.frifrom) & "-" & clsTool.getTime(r.frito)
            End If
        End If
        If e.ColumnIndex = 7 Then
            If r.saturday Then
                e.Value = clsTool.getTime(r.satfrom) & "-" & clsTool.getTime(r.satto)
            End If
        End If
        If e.ColumnIndex = 8 Then
            If r.sunday Then
                e.Value = clsTool.getTime(r.sunfrom) & "-" & clsTool.getTime(r.sunto)
            End If
        End If
    End Sub


    Private Sub uTeacherLoad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TeachersTableAdapter.Fill(Me.DsSchool.Teachers)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        ComboBox2.SelectedValue = clsTool.GetCurSemPK
        REM added 7.1.2012
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK()

    End Sub

    'LOAD REPORT
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.SYOfferingbyTeacherTableAdapter.Fill(Me.DsSchool.SYOfferingbyTeacher, clsTool.GetCurYearPK, ComboBox2.SelectedValue, ComboBox1.SelectedValue)

        'initialize subreport source
        DsSchool.TemplateTeacherLoadExtraHours.Clear()

        Dim dtSYTeacher As New dsSchoolTableAdapters.SYOfferingbyTeacherTableAdapter

        ''Me.SYOfferingbyTeacherTableAdapter.Fill(Me.DsSchool.SYOfferingbyTeacher, clsTool.GetCurYearPK, ComboBox2.SelectedValue, Me.teacherpk)
        REM added SY option to choose from 7.1.2012
        ''dtSYTeacher.Fill(Me.DsSchool.SYOfferingbyTeacher, clsTool.GetCurYearPK, ComboBox2.SelectedValue, Me.teacherpk)
        dtSYTeacher.Fill(Me.DsSchool.SYOfferingbyTeacher, cmbSY.SelectedValue, ComboBox2.SelectedValue, Me.teacherpk)

        If Me.DsSchool.SYOfferingbyTeacher.Rows.Count = 0 Then MsgBox("No loads found for teacher!") : Exit Sub
        Dim ctr As Integer
        Dim frm As New frmWait
        frm.Show()
        'ben10.15.2005 .used another template (non adapter)
        ''Me.DsSchool.TemplateTeacherLoad.Clear()
        Me.DsSchool.TemplateTeacherLoadReport.Clear()

        'start looping offering load
        For ctr = 0 To Me.DsSchool.SYOfferingbyTeacher.Rows.Count - 1
            ''Dim s As String = ""
            Dim units As Decimal = 0
            Dim starttime, endtime, daysked, subjtype As String
            Dim studentcount As Integer = 0

            Dim r As dsSchool.SYOfferingbyTeacherRow = Me.DsSchool.SYOfferingbyTeacher(ctr)

            daysked = clsTool.getSYOfferDays(r.syofferingpk)
            units = clsTool.GetSubjectUnits(r.subjectpk)
            starttime = clsTool.getSYOfferStart(r.syofferingpk)
            endtime = clsTool.getSYOfferEnd(r.syofferingpk)
            If r.IsrequestedNull Then r.requested = False

            ''Commented out 11.19.2011.
            ''If r.requested Then subjtype = "RQ" Else subjtype = "R"

            subjtype = clsTool.getClassType(r.syofferingpk, r.semesterpk, r.sypk)

            ''studentcount = CountStudents(r.syofferingpk, r.semesterpk, r.subjectpk)
            studentcount = clsTool.getStudentCount(r.semesterpk, r.sypk, r.syofferingpk)

            With Me.DsSchool.SYOfferingbyTeacher(ctr)

                'now check for extra/different hours (also broken hours) 
                Dim hasotherskeds As Boolean = clsTool.CheckSYOfferHasDifferentTimeSkeds(r.syofferingpk)

                'subj desc
                Dim subjectdesc As String = clsTool.GetSubjectDescription(.subjectpk)

                'add rows to template for each different sked for same subject
                If hasotherskeds Then
                    Dim daytimesked As String = clsTool.getSYOfferFullSked(r.syofferingpk)

                    Me.DsSchool.TemplateTeacherLoadExtraHours.AddTemplateTeacherLoadExtraHoursRow(clsTool.GetSubjectDescription(.subjectpk), daytimesked)

                    'put asterisk on subjectdesc
                    subjectdesc = "*" & subjectdesc

                End If

                Me.DsSchool.TemplateTeacherLoadReport.AddTemplateTeacherLoadReportRow(cmbSY.Text, ComboBox2.Text, _
                  clsTool.getResourceID(.resource), subjectdesc, daysked, starttime, endtime, _
                  studentcount, units, subjtype)

                


            End With

            
        Next
        Dim rep As New crTeacherLoad

        rep.SetDataSource(Me.DsSchool)

        'subreport
        rep.Subreports(0).SetDataSource(Me.DsSchool)

        'rep.SetParameterValue("pTeacherName", Me.ComboBox1.Text)
        'rep.SetParameterValue("pTeacherName", Me.txtTeacherFilter.Text)
        rep.SetParameterValue("pTeacherName", Me.TextBoxTeacherName.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()
    End Sub

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

    ' ''ben1.25.2008 Filter Teacher Name
    ''Private Sub txtTeacherFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTeacherFilter.KeyPress

    ''    If e.KeyChar = Chr(13) Then

    ''        Me.teacherpk = clsTool2.getTeacherPKbyName(Me.txtTeacherFilter.Text)
    ''        Me.txtTeacherFilter.Text = clsTool.getTeacherName(Me.teacherpk)
    ''    End If
    ''End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmTeachersSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.teacherpk = frm.DsSchool.TeachersbyCName(frm.TeachersbyCNameBindingSource.Position).TeacherPriKey
            Me.TextBoxTeacherName.Text = frm.DsSchool.TeachersbyCName(frm.TeachersbyCNameBindingSource.Position).Name
        End If
    End Sub
End Class
