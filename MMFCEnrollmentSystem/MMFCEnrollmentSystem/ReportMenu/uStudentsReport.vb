Public Class uStudentsReport   'ben10.9.2007

    Public Sub LoadData()
        Me.chkAllCourse.Checked = True
        Me.chkAllYear.Checked = True
        Me.chkAllTypes.Checked = True
        Me.chkBothSex.Checked = True
        fillYearLevelCombo()
        Me.CoursesTableAdapter.Fill(Me.DsSchool.Courses)
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK()
        Me.cmbSem.SelectedValue = clsTool.GetCurSemPK()
        Me.DateTimePicker1.Value = "1/1/1900"
    End Sub
    Private Sub fillYearLevelCombo()
        Dim cls(5) As clsListItem
        cls(0) = New clsListItem
        cls(0).ID = 1
        cls(0).Name = "1st Year"
        cls(1) = New clsListItem
        cls(1).ID = 2
        cls(1).Name = "2nd Year"
        cls(2) = New clsListItem
        cls(2).ID = 3
        cls(2).Name = "3rd Year"
        cls(3) = New clsListItem
        cls(3).ID = 4
        cls(3).Name = "4th Year"
        cls(4) = New clsListItem
        cls(4).ID = 5
        cls(4).Name = "5th Year"
        cls(5) = New clsListItem
        cls(5).ID = 6
        cls(5).Name = "6th Year"
        Me.cmbYearLevel.DisplayMember = "Name"
        Me.cmbYearLevel.ValueMember = "ID"
        Me.cmbYearLevel.DataSource = cls
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    'Retrieve Button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        retrieveReport()
    End Sub

    Private Sub retrieveReport()
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Dim yr1, yr2 As Integer
        Dim studentType As String = "%"
        Dim gender As String = "%"
        Dim m_StudentType As String = ""

        If Me.chkAllYear.Checked Then
            yr1 = 1
            yr2 = 6
        Else
            yr1 = Me.cmbYearLevel.SelectedValue
            yr2 = Me.cmbYearLevel.SelectedValue
        End If

        If Me.chkAllTypes.Checked = False Then

            studentType = "%" + Me.cmbStudentType.Text + "%"
            m_StudentType = Me.cmbStudentType.Text

        Else
            ''ALL Student Types
            m_StudentType = "ALL"
        End If


        If Me.chkBothSex.Checked = False Then gender = Me.cmbSex.Text

        'Get dataset
        Dim ds As New dsRep
        Dim dt As New dsRepTableAdapters.StudentsByCourseYrTypeRegDateTableAdapter

        dt.Fill(ds.StudentsByCourseYrTypeRegDate, yr1, yr2, studentType, Me.DateTimePicker1.Value.Date, _
                               Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue, gender)

        'ADDED CODE TO ENSURE ONLY 1 COURSEPK FOR EACH STUDENT 
        Dim i As Integer
        Dim coursepk As Integer = -1
        Dim coursename As String = ""
        For i = 0 To ds.StudentsByCourseYrTypeRegDate.Rows.Count - 1
            With ds.StudentsByCourseYrTypeRegDate(i)
                coursepk = clsTool.getStudentCoursePK(Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue, .StudentPK)
                coursename = clsTool.getCourseName(coursepk)

                'course filter
                If Me.chkAllCourse.Checked Then
                    ds.TemplateStudentsReports.AddTemplateStudentsReportsRow(.regDate, .StudentType, .yrlevel, coursepk, _
                                .Gender, .StudentName, coursename, .StudentID)
                Else
                    If coursepk = Me.cmbCourse.SelectedValue Then
                        ds.TemplateStudentsReports.AddTemplateStudentsReportsRow(.regDate, .StudentType, .yrlevel, coursepk, _
                                    .Gender, .StudentName, coursename, .StudentID)
                    End If
                End If
            End With
        Next

        REM Start Report
        Dim rep As New crStudentListing
        rep.SetDataSource(ds)
        rep.SetParameterValue("pSY", Me.cmbSY.Text)
        rep.SetParameterValue("pSem", Me.cmbSem.Text)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))

        rep.SetParameterValue("STUDENT_TYPE", m_StudentType)

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()
        frm.Hide()

    End Sub

   
End Class
