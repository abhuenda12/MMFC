Public Class uCurrentSchoolyear

    Private sypk As Integer = clsTool.GetCurYearPK()
    Private sempk As Integer = clsTool.GetCurSemPK()

    Sub LoadValues()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        cmbSY.SelectedValue = clsTool.GetCurYearPK()
        cmbSemester.SelectedValue = clsTool.GetCurSemPK()

        loadExamDates()

        'Ben 3.5.2008 . Note : preference value is string
        If String.IsNullOrEmpty(clsTool.GetSetting("ENROLLCLOSED")) Then
            Me.chkEnrollmentClosed.Checked = False
        Else
            If clsTool.GetSetting("ENROLLCLOSED") = "TRUE" Then
                Me.chkEnrollmentClosed.Checked = True
            Else
                Me.chkEnrollmentClosed.Checked = False
            End If
        End If

    End Sub
    Public Sub NewDoc()
        LoadValues()
    End Sub
    Public Sub Opendoc()
        LoadValues()
    End Sub
    Public Sub DeleteDoc()
        MsgBox("Not Applicable!")
    End Sub

    Private Sub uCurrentSchoolyear_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadValues()
    End Sub

    'SAVE button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ''ToolStripStatusLabel1.Text = "Saving Information"

        clsTool.SetCurYear(cmbSY.SelectedValue)
        clsTool.SetCurSem(cmbSemester.SelectedValue)

        'BEN 6.19.2008
        saveExamDates()

        'Ben 3.5.2008
        Dim enrollmentisclosed As String = ""
        If Me.chkEnrollmentClosed.Checked Then enrollmentisclosed = "TRUE" Else enrollmentisclosed = "FALSE"
        clsTool.SetSetting("ENROLLCLOSED", enrollmentisclosed)

        '===============================================================================================
        'Ben 4.22.2008  Update Student Type NEW to OLD 
        'when sem / sy is changed to a higher ordinal number/sort order
        Dim oldSySortOrder As Integer = clsTool2.getSYPKsortorder(sypk)
        Dim oldSemSortOrder As Integer = clsTool2.getSemPKsortorder(sempk)
        Dim newSySortOrder As Integer = clsTool2.getSYPKsortorder(Me.cmbSY.SelectedValue)
        Dim newSemSortOrder As Integer = clsTool2.getSemPKsortorder(Me.cmbSemester.SelectedValue)

        If newSySortOrder > oldSySortOrder Then
            'go change 
            changeStudentType("NEW")
            changeStudentType("TRANSFEREE")
        ElseIf newSySortOrder = oldSySortOrder Then
            'check sem
            If newSemSortOrder > oldSemSortOrder Then
                'go change
                changeStudentType("NEW")
                changeStudentType("TRANSFEREE")
            End If
        End If
        '===============================================================================================

        ''ToolStripStatusLabel1.Text = "Information Saved."

    End Sub

    'Disables SemiMidterm and SemiFinals if Summer is chosen as semester
    Private Sub cmbSemester_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cmbSemester.Text.ToUpper.Contains("SUM") Then
            Me.dateSemiMidtermfrom.Enabled = False
            Me.dateSemiMidtermTo.Enabled = False
            Me.dateSemiFinalFrom.Enabled = False
            Me.dateSemiFinalTo.Enabled = False
        Else
            Me.dateSemiMidtermfrom.Enabled = True
            Me.dateSemiMidtermTo.Enabled = True
            Me.dateSemiFinalFrom.Enabled = True
            Me.dateSemiFinalTo.Enabled = True
        End If
    End Sub

    Sub changeStudentType(ByVal type As String)
        Try

            Dim ds As New dsReg2.StudentsbyTypeDataTable
            Dim dt As New dsReg2TableAdapters.StudentsbyTypeTableAdapter
            dt.Fill(ds, type)
            If ds.Rows.Count <= 0 Then Exit Sub
            Dim regdate As Date = Now()
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                With ds(i)
                    'check if student has enrolled subjects in oldsempk oldsypk
                    If clsTool.getStudentEnrolledUnits(.StudentPK, sempk, sypk) > 0 Then
                        .StudentType = "OLD"
                    End If
                End With
            Next
            dt.Update(ds)

        Catch ex As Exception
            MsgBox("Error updating Student Type to OLD " & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub loadExamDates()
        Dim ds As New dsSchool.ExamsBySemSYDataTable
        Dim dt As New dsSchoolTableAdapters.ExamsBySemSYTableAdapter
        'get current record
        dt.Fill(ds, Me.cmbSY.SelectedValue, Me.cmbSemester.SelectedValue)
        If ds.Rows.Count <= 0 Then Exit Sub
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                Me.DateTimePickerExam1From.Value = .examfrom1
                Me.DateTimePickerExam1To.Value = .examto1
                Me.dateSemiMidtermfrom.Value = .examfrom2
                Me.dateSemiMidtermTo.Value = .examto2
                Me.DateTimePickerExam3From.Value = .examfrom3
                Me.DateTimePickerExam3To.Value = .examto3
                Me.dateSemiFinalFrom.Value = .examfrom4
                Me.dateSemiFinalTo.Value = .examto4
                Me.DateTimePickerExam5From.Value = .examfrom5
                Me.DateTimePickerExam5To.Value = .examto5
            End With
        Next
    End Sub
    Sub saveExamDates()
        Dim ds As New dsSchool.ExamsBySemSYDataTable
        Dim dt As New dsSchoolTableAdapters.ExamsBySemSYTableAdapter
        'get current record
        dt.Fill(ds, Me.cmbSY.SelectedValue, Me.cmbSemester.SelectedValue)
        If ds.Rows.Count <= 0 Then
            'insert
            ds.AddExamsBySemSYRow(Me.cmbSY.SelectedValue, Me.cmbSemester.SelectedValue, _
                 Me.DateTimePickerExam1From.Value, Me.DateTimePickerExam1To.Value, _
                 Me.dateSemiMidtermfrom.Value, Me.dateSemiMidtermTo.Value, _
                 Me.DateTimePickerExam3From.Value, Me.DateTimePickerExam3To.Value, _
                 Me.dateSemiFinalFrom.Value, Me.dateSemiFinalTo.Value, _
                 Me.DateTimePickerExam5From.Value, Me.DateTimePickerExam5To.Value)
        Else
            'update
            With ds(0)
                .examfrom1 = Me.DateTimePickerExam1From.Value
                .examto1 = Me.DateTimePickerExam1To.Value
                .examfrom2 = Me.dateSemiMidtermfrom.Value
                .examto2 = Me.dateSemiMidtermTo.Value
                .examfrom3 = Me.DateTimePickerExam3From.Value
                .examto3 = Me.DateTimePickerExam3To.Value
                .examfrom4 = Me.dateSemiFinalFrom.Value
                .examto4 = Me.dateSemiFinalTo.Value
                .examfrom5 = Me.DateTimePickerExam5From.Value
                .examto5 = Me.DateTimePickerExam5To.Value
            End With
        End If

        dt.Update(ds)
    End Sub

    'Update student type to OLD
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MsgBox("This will set the student type to OLD for all students who have records that are not equal to the current school year and semestter.", MsgBoxStyle.YesNo, "Warning!")) = MsgBoxResult.Yes Then
            frmMain.AutoSetStudentTypeToOld()
        End If
    End Sub

   
End Class
