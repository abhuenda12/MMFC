Imports System.Data
Imports System.Data.SqlClient

Public Class uEnrollSubject
    Public m_StudentPk As Integer = -1
    Public m_CoursePK As Integer = -1

#Region "SETUP , Choose Student Event"
    ''Public Sub NewDoc()
    ''    Me.m_StudentPk = -1
    ''    Me.txtStudent.Text = ""
    ''    'ben10.1.2007
    ''    resetData()
    ''End Sub
    ''Public Sub OpenDoc()

    ''End Sub
    'Additional Request from Client. Allow advance Enrollment for Next Semester.
    Public Sub InitForm()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)

        Me.txtSchoolYear.SelectedValue = clsTool.GetCurYearPK
        Me.txtSemester.SelectedValue = clsTool.GetCurSemPK
        Me.txtSchoolYear.Enabled = False
        ''Me.txtSemester.Enabled = False        
        Me.txtSemester.Enabled = True
        Me.txtDate.Value = Now.Date
        fillEnrollasYearCombo()

        Me.txtUnits.Text = "0"
        m_CoursePK = -1
    End Sub
    Private Sub fillEnrollasYearCombo()

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

        Me.txtEnrollYear.DisplayMember = "Name"
        Me.txtEnrollYear.ValueMember = "ID"
        Me.txtEnrollYear.DataSource = cls

    End Sub

    'ben9.30.2007
    Private Sub resetData()
        Me.DsRegistrar.EnrollHeader.Clear()
        Me.DsRegistrar.EnrollSubjects.Clear()
        Me.DsRegistrar.EnrollSubjectsCostbyPK.Clear()

        Me.txtUnits.Text = "0"
        Me.txtEnrollYear.Enabled = True
        Me.txtCourse.Enabled = True
        Me.txtSemester.Enabled = True

        Me.m_CoursePK = -1
        Me.txtCourse.Text = ""
        Me.txtRemarks.Text = ""
    End Sub
    
    Private Sub totalUnits()
        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then Me.txtUnits.Text = "0.0" : Exit Sub
        Dim ctr As Integer
        Dim units As Double = 0
        For ctr = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1
            'ben9.30.2007
            If Me.DsRegistrar.EnrollSubjects(ctr).RowState = DataRowState.Deleted Then Continue For
            If Me.DsRegistrar.EnrollSubjects(ctr).status = 1 Then
                units = units + clsTool.getUnits(Me.DsRegistrar.EnrollSubjects(ctr).subjectpk)
            End If
        Next
        Me.txtUnits.Text = units
    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsRegistrar.EnrollSubjects(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If e.ColumnIndex = 7 Then
            e.Value = clsTool.getCourseName(Me.DsRegistrar.EnrollSubjects(e.RowIndex).coursepk)
        End If
        If e.ColumnIndex = 2 Then
            e.Value = clsTool.GetSubjectDescription(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If
        If e.ColumnIndex = 3 Then
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 0 Then e.Value = "NOT ENROLLED"
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 1 Then e.Value = "ENROLLED"
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 2 Then e.Value = "DROPPED"
        End If
        If e.ColumnIndex = 4 Then
            If clsTool.ClassSP(Me.DsRegistrar.EnrollSubjects(e.RowIndex).coursepk) Then e.Value = "SPECIAL CLASS" : Exit Sub
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status <> 1 Then e.Value = "" : Exit Sub
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).syofferingpk = -1 Then e.Value = "NONE" : Exit Sub
            Dim ds As New dsRegistrar
            Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
            dt.Fill(ds.SYOfferingbyPK, Me.DsRegistrar.EnrollSubjects(e.RowIndex).syofferingpk)
            If ds.SYOfferingbyPK.Rows.Count = 0 Then e.Value = "NOT FOUND" : Exit Sub
            Dim r As dsRegistrar.SYOfferingbyPKRow = ds.SYOfferingbyPK(0)
            Dim s As String = clsTool.getTeacherName(r.teacherid) & "-" & clsTool.getResourceName(r.resource) & ":"
            If r.monday Then s = s & "Mon:" & clsTool.getTime(CDate(r.monfrom)) & "-" & clsTool.getTime(CDate(r.monto)) & "/"
            If r.tuesday Then s = s & "Tue:" & clsTool.getTime(CDate(r.tuesfrom)) & "-" & clsTool.getTime(CDate(r.tuesto)) & "/"
            If r.wednesday Then s = s & "Wed:" & clsTool.getTime(CDate(r.wedfrom)) & "-" & clsTool.getTime(CDate(r.wedto)) & "/"
            If r.thursday Then s = s & "Thu:" & clsTool.getTime(CDate(r.thufrom)) & "-" & clsTool.getTime(CDate(r.thuto)) & "/"
            If r.alternatefriday Then
                If r.friday Then s = s & "Alt-Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
            Else
                If r.friday Then s = s & "Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
            End If
            If r.saturday Then s = s & "Sat:" & clsTool.getTime(CDate(r.satfrom)) & "-" & clsTool.getTime(CDate(r.satto)) & "/"
            If r.sunday Then s = s & "Sun:" & clsTool.getTime(CDate(r.sunfrom)) & "-" & clsTool.getTime(CDate(r.sunto))
            If s.Substring(s.Length - 1, 1) = "/" Then s = s.Substring(0, s.Length - 1)
            e.Value = s
        End If
        If e.ColumnIndex = 5 Then
            e.Value = clsTool.getUnits(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If
        'ben9.30.3007
        If e.ColumnIndex = 6 Then
            e.Value = clsTool.getLabUnits(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If

    End Sub
    'ben9.25.2007 . Additional Request by client.
    'Validation of Semester. Allowed is Current semester and Next Semester.
    'THERE WILL BE AN ERROR if the values of sempk in semester table is not incremental of 1
    Private Sub txtSemester_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim semDiff As Integer = Convert.ToInt16(Me.txtSemester.SelectedValue) - clsTool.GetCurSemPK
        If semDiff < 0 Then
            MsgBox("You cannot choose a previous Semester.")
            Me.txtSemester.SelectedValue = clsTool.GetCurSemPK
            Me.txtSemester.Focus()
            Exit Sub
        End If
        If semDiff > 1 Then
            MsgBox("You cannot choose a Semester aside from the current and the next one.")
            Me.txtSemester.SelectedValue = clsTool.GetCurSemPK
            Me.txtSemester.Focus()
            Exit Sub
        End If
    End Sub

    'Choose Course button
    Private Sub btnChooseCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseCourse.Click

        Dim frm As New frmCourseSelect
        frm.ShowDialog()
        If frm.Selected Then

            Me.m_CoursePK = frm.m_CoursePK
            txtCourse.Text = clsTool.getCourseCompleteDesc(m_CoursePK)

            'Oct 19 2011, Apply this course change in the database
            'set the coursepk of all enrolled subject to this m_CoursePK
            Dim i As Integer
            For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1
                With Me.DsRegistrar.EnrollSubjects(i)
                    .coursepk = Me.m_CoursePK
                End With
            Next

            'Now send changes to database
            Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)

        End If
    End Sub

#End Region

#Region "CHOOSE STUDENT EVENT"
    'Choose Student Button
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()

        frm.ShowDialog()
        If frm.Selected Then

            resetData()

            Me.m_StudentPk = frm.m_StudentPK

            Me.txtStudent.Text = frm.m_StudentName

            If Not clsTool.checkifStudentPaidRegFee(Me.m_StudentPk, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue) Then
                If MsgBox("Student hasn't paid required amount of Php500. Cancel Enrollment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    resetData()
                    Exit Sub
                End If

            End If

            'Ben. 7.11.2013
            If (frm.m_StudentType = "NEW") Then
                'check if previously enrolled
                clsTool.AutoSetStudentTypeToOld(m_StudentPk)
                Me.txtStudentType.Text = clsTool.getStudentType(m_StudentPk)
            Else
                Me.txtStudentType.Text = frm.m_StudentType
            End If


            getEnrollHeader()

            getSubjectsEnrolled()
        End If
    End Sub

    'creates a new row for enrollheader when theres no existing record (id=sempk+yrpk+studentpk)
    'Note, course gets filled in the getEnrollSubjects method
    Private Sub getEnrollHeader()

        Dim dt As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter

        dt.Fill(Me.DsRegistrar.EnrollHeader, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk)

        If Me.DsRegistrar.EnrollHeader.Rows.Count > 0 Then

            Me.txtRemarks.Text = Me.DsRegistrar.EnrollHeader(0).remarks

            If Not Me.DsRegistrar.EnrollHeader(0).IsyrlevelNull Then
                Me.txtEnrollYear.SelectedValue = Me.DsRegistrar.EnrollHeader(0).yrlevel
            End If

        Else

            Me.DsRegistrar.EnrollHeader.AddEnrollHeaderRow(Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, _
                Me.m_StudentPk, Me.txtRemarks.Text, Me.txtEnrollYear.SelectedValue)

        End If
    End Sub
    'old name = fillGrid()
    ' Course gets filled here since in old database, the course is set on a per subject enrollment .
    ' student can enroll to 2 courses and get 2 subjects, 1 per course.
    Sub getSubjectsEnrolled()

        'Resetting of dataset tables to be done when a student is chosen
        Me.EnrollSubjectsTableAdapter.Fill(Me.DsRegistrar.EnrollSubjects, Me.txtSchoolYear.SelectedValue, _
                                          Me.txtSemester.SelectedValue, Me.m_StudentPk)

        If Me.DsRegistrar.EnrollSubjects.Rows.Count > 0 Then

            Me.m_CoursePK = Me.DsRegistrar.EnrollSubjects(0).coursepk
            Me.txtCourse.Text = clsTool.getCourseCompleteDesc(Me.m_CoursePK)

            'Disable EnrollYear and Course when subjects are found to be enlisted 
            'Me.txtEnrollYear.Enabled = False REM Ben. allow editing 7.11.2013
            Me.txtSemester.Enabled = False
        Else
            
            'get the most recent course the student was enrolled to
            m_CoursePK = clsTool.getStudentRecentCoursePK(m_StudentPk)
            txtCourse.Text = clsTool.getCourseCompleteDesc(m_CoursePK)

            Me.txtEnrollYear.Enabled = True
            Me.txtSemester.Enabled = True
        End If
        totalUnits()
    End Sub
#End Region

#Region "Subjects adding/enrollment/dropping/removing"

    'add subject button
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSubject.Click
        addSubject()
    End Sub
    Private Sub addSubject()

        If isEnrollmentOpen() = False Then MsgBox("Enrollment has been closed!", MsgBoxStyle.Critical, "Error") : Exit Sub

        If Me.m_StudentPk = -1 Then MsgBox("Please select student.") : Exit Sub

        If m_CoursePK = -1 Then MsgBox("Please select course.") : Exit Sub

        SelectSubject(m_CoursePK)

        'Test if enrollheader exists , if not, then add new row in getEnrollHeader
        If Me.DsRegistrar.EnrollHeader.Rows.Count <= 0 Then getEnrollHeader()

        'save enrollheader if subjects > 0
        Me.DsRegistrar.EnrollHeader(0).yrlevel = Me.txtEnrollYear.SelectedValue

        Dim dtenroll As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        If Me.DsRegistrar.EnrollSubjects.Rows.Count > 0 Then
            dtenroll.Update(Me.DsRegistrar.EnrollHeader)
        End If

        'reload subjects
        getSubjectsEnrolled()
        'go to last record added
        If Me.DsRegistrar.EnrollSubjects.Rows.Count > 0 Then
            DataGridView1.Rows(DsRegistrar.EnrollSubjects.Rows.Count - 1).Selected = True
        End If

    End Sub

    Sub LoadCourseSubjectsAll()
        Dim sp As Boolean = clsTool.ClassSP(m_CoursePK)
        If sp Then
            Dim ds As New dsRegistrar
            Dim dt As New dsRegistrarTableAdapters.BlockSectionTuitionbyCourseTableAdapter
            dt.Fill(ds.BlockSectionTuitionbyCourse, m_CoursePK)
            Dim ctr As Integer
            For ctr = 0 To ds.BlockSectionTuitionbyCourse.Rows.Count - 1
                Me.DsRegistrar.EnrollSubjects.AddEnrollSubjectsRow(Me.txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue, Me.m_StudentPk, Me.txtDate.Value, "", ds.BlockSectionTuitionbyCourse(ctr).subjectid, -1, 1, m_CoursePK)
                Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)
            Next
        Else
            Dim ds As New dsRegistrar
            Dim dt As New dsRegistrarTableAdapters.BlockSectionTuitionTableAdapter
            dt.Fill(ds.BlockSectionTuition, m_CoursePK, Me.txtSemester.SelectedValue, Me.txtEnrollYear.SelectedValue, Me.txtDate.Value.Date)
            Dim ctr As Integer
            For ctr = 0 To ds.BlockSectionTuition.Rows.Count - 1
                Me.DsRegistrar.EnrollSubjects.AddEnrollSubjectsRow(Me.txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue, Me.m_StudentPk, Me.txtDate.Value, "", ds.BlockSectionTuitionbyCourse(ctr).subjectid, -1, 1, m_CoursePK)
                Me.DsRegistrar.EnrollSubjects.AddEnrollSubjectsRow(Me.txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue, Me.m_StudentPk, Me.txtDate.Value, "", ds.BlockSectionTuition(ctr).subjectid, -1, 0, m_CoursePK)
                Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)
            Next
        End If
    End Sub

    Sub SelectSubject(ByVal id As Integer)

        'commented below. no need to load subjects via course since most of the time, any subject can be chosen
        ''Dim frm As New frmEnrollSubject
        ''frm.m_Course = Me.txtCourse.SelectedValue
        ''frm.txtCourse.Text = clsTool.getCourseName(frm.m_Course)

        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()

        If frm.Selected Then

            Dim sp As Boolean = clsTool.ClassSP(m_CoursePK)

            Me.DsRegistrar.EnrollSubjects.AddEnrollSubjectsRow(Me.txtSchoolYear.SelectedValue, _
                Me.txtSemester.SelectedValue, Me.m_StudentPk, Me.txtDate.Value.Date, "", frm.m_SubjectID, _
                -1, IIf(sp, 1, 0), Me.m_CoursePK)

            Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)
        End If

    End Sub

    'Change Class/Enroll to Class
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnrollClass.Click
        changeClass()
    End Sub

    'Change Class Button
    'ben. Sep 25 2007 . Additional Request by Client. Allow Enrollment of Subject with Prereq but should have Password  
    Private Sub changeClass()

        'ben3.5.2008
        If isEnrollmentOpen() = False Then MsgBox("Enrollment has been closed. You can't change/enroll a class.", MsgBoxStyle.Critical, "Error") : Exit Sub

        If Me.DsRegistrar.EnrollSubjects.Rows.Count = 0 Then MsgBox("No subject selected!") : Exit Sub
        With Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''Jefferson Jamora 10/17/07''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim PreReqNum As Integer = clsTool2.getPreReqNum(.subjectpk)
            ''Get PreReqSubject

            REM 11.5.2011. Only initialize if subject has prereqs
            If PreReqNum > 0 Then

                Dim mPre As Integer = clsTool.getSubjectPrerequisite(.subjectpk)
                Dim mPre2 As Integer = clsTool2.getSubjectPrereq2(.subjectpk)
                Dim mPre3 As Integer = clsTool2.getSubjectPrereq3(.subjectpk)
                Dim mPre4 As Integer = clsTool2.getSubjectPrereq4(.subjectpk)
                Dim mPre5 As Integer = clsTool2.getSubjectPrereq5(.subjectpk)
                Dim mPre6 As Integer = clsTool2.getSubjectPrereq6(.subjectpk)
                Dim mPre7 As Integer = clsTool2.getSubjectPrereq7(.subjectpk)

                Dim grade As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre)
                Dim grade2 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre2)
                Dim grade3 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre3)
                Dim grade4 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre4)
                Dim grade5 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre5)
                Dim grade6 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre6)
                Dim grade7 As Double = clsTool.getStudentGrade(Me.m_StudentPk, mPre7)

                If PreReqNum = 1 And ((mPre <> -1 Or mPre <> 0) And grade < 75) Then
                    MsgBox("Subject has prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & " Please give SYS password.")
                End If

                If PreReqNum = 2 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           " Please give SYS password.")
                End If

                If PreReqNum = 3 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75) Or ((mPre3 <> -1 Or mPre3 <> 0) And grade3 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre3) & vbCrLf & _
                           " Please give SYS password.")
                End If

                If PreReqNum = 4 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75) Or ((mPre3 <> -1 Or mPre3 <> 0) And grade3 < 75) Or ((mPre4 <> -1 Or mPre4 <> 0) And grade4 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre3) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre4) & vbCrLf & _
                           " Please give SYS password.")
                End If

                If PreReqNum = 5 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75) Or ((mPre3 <> -1 Or mPre3 <> 0) And grade3 < 75) Or ((mPre4 <> -1 Or mPre4 <> 0) And grade4 < 75) Or ((mPre5 <> -1 Or mPre5 <> 0) And grade5 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre3) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre4) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre5) & vbCrLf & _
                           " Please give SYS password.")
                End If

                If PreReqNum = 6 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75) Or ((mPre3 <> -1 Or mPre3 <> 0) And grade3 < 75) Or ((mPre4 <> -1 Or mPre4 <> 0) And grade4 < 75) Or ((mPre5 <> -1 Or mPre5 <> 0) And grade5 < 75) Or ((mPre6 <> -1 Or mPre6 <> 0) And grade6 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre3) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre4) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre5) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre6) & vbCrLf & _
                           " Please give SYS password.")
                End If

                If PreReqNum = 7 And (((mPre <> -1 Or mPre <> 0) And grade2 < 75) Or ((mPre2 <> -1 Or mPre2 <> 0) And grade2 < 75) Or ((mPre3 <> -1 Or mPre3 <> 0) And grade3 < 75) Or ((mPre4 <> -1 Or mPre4 <> 0) And grade4 < 75) Or ((mPre5 <> -1 Or mPre5 <> 0) And grade5 < 75) Or ((mPre6 <> -1 Or mPre6 <> 0) And grade6 < 75) Or ((mPre7 <> -1 Or mPre7 <> 0) And grade7 < 75)) Then
                    MsgBox("Subject prerequisite:" & clsTool.GetSubjectDescription(mPre) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre2) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre3) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre4) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre5) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre6) & vbCrLf & _
                           "Subject prerequisite:" & clsTool.GetSubjectDescription(mPre7) & vbCrLf & _
                           " Please give SYS password.")
                End If

                Dim frmPassword As New frmAdminPassword
                frmPassword.ShowDialog()
                If frmPassword.isDirty = False Then Exit Sub

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'find if subject has been enrolled and passed        
            Dim lGrade As String = clsTool.getStudentGrade(Me.m_StudentPk, .subjectpk)

            REM for Non numeric grades (grades from previous schools?) , set to zero
            If Not IsNumeric(lGrade) Then lGrade = 0

            If lGrade >= 75 Then
                MsgBox("Student has previously enrolled to this subject!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If clsTool.ClassSP(.coursepk) And .status = 1 Then
                MsgBox("Special courses are assigned to classes only during grade entry!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If clsTool.ClassSP(.coursepk) Then
                .status = 1
                Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)
                getSubjectsEnrolled()
                Exit Sub
            End If

            Dim frm As New frmClassSelect
            frm.m_Sem = Me.txtSemester.SelectedValue
            frm.m_Year = Me.txtSchoolYear.SelectedValue
            frm.m_Subject = .subjectpk

            If frm.LoadClass() Then
                frm.ShowDialog()

                If frm.Selected Then

                    If frm.m_Closed Then MsgBox("You selected a class that is already closed!") : Exit Sub

                    Dim ctr As Integer

                    'Selected Class syofferpk
                    Dim curKey As Integer = frm.m_SelectedClass


                    'TEST FOR CONFLICT HERE
                    '
                    '
                    For ctr = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1

                        If Me.DsRegistrar.EnrollSubjects(ctr).status = 1 Then

                            If Not clsTool.checkSubjectConflict(curKey, Me.DsRegistrar.EnrollSubjects(ctr).syofferingpk) Then

                                MsgBox("Selected schedule conflicts with an enrolled schedule for " & clsTool.GetSubjectDescription(Me.DsRegistrar.EnrollSubjects(ctr).subjectpk))

                                Exit Sub

                            End If
                        End If
                    Next

                    'test for overload before update of data
                    If Not checkTotalUnitsEnrolledifAllowed(clsTool.GetSubjectUnits(.subjectpk)) Then Exit Sub

                    .syofferingpk = frm.m_SelectedClass
                    .status = 1

                    Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)

                    getSubjectsEnrolled()
                End If

            End If


        End With
    End Sub

    'Drop subject button
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDropClass.Click
        dropSubject()
    End Sub
    Private Sub dropSubject()

        'ben3.5.2008
        If isEnrollmentOpen() = False Then Exit Sub

        If Me.DsRegistrar.EnrollSubjects.Rows.Count = 0 Then MsgBox("Please add subjects") : Exit Sub
        If MsgBox("Are you sure to drop selected subject?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim course As Integer = Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).coursepk
            Dim subject As Integer = Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).subjectpk
            Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).status = 2
            Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)
            'Delete from ledger
            Dim ds As New dsFinance
            Dim dts As New dsFinanceTableAdapters.LedgerbyStudentCourseSubjectTableAdapter
            dts.Fill(ds.LedgerbyStudentCourseSubject, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, subject, "SCHG")
            If ds.LedgerbyStudentCourseSubject.Rows.Count > 0 Then
                ds.LedgerbyStudentCourseSubject(0).Delete()
                dts.Update(ds.LedgerbyStudentCourseSubject)
            End If

            'ben9.30.2007   . Delete entries in EnrollSubjectsCost         
            clsTool.DeleteSubjectCostbyPK(Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).enrollpk)

            'check if no more subjects enrolled
            Dim ctr As Integer
            Dim found As Boolean = False
            For ctr = 0 To Me.DsRegistrar.EnrollSubjects.Count - 1
                If Me.DsRegistrar.EnrollSubjects(ctr).status = 1 Then found = True
            Next
            'delete course charges if no more enrolled
            If Not found Then
                Dim dtc As New dsFinanceTableAdapters.LedgerbyStudentCourseTableAdapter
                dtc.Fill(ds.LedgerbyStudentCourse, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, "MISC")
                If ds.LedgerbyStudentCourse.Rows.Count > 0 Then
                    ds.LedgerbyStudentCourse(0).Delete()
                    dtc.Update(ds.LedgerbyStudentCourse)
                End If
            End If
            getSubjectsEnrolled()


        End If
    End Sub
    'Remove Subject
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSubject.Click
        removeSubject()
    End Sub

    Private Sub removeSubject()

        'ben3.5.2008
        If isEnrollmentOpen() = False Then Exit Sub

        If Me.DsRegistrar.EnrollSubjects.Rows.Count = 0 Then MsgBox("Nothing enrolled!") : Exit Sub
        If Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).status = 1 Then MsgBox("Drop the subject first!") : Exit Sub
        If MsgBox("Are you sure to remove selected subject?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            REM ben9.30.2007 . 
            Dim course As Integer = Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).coursepk
            Dim subject As Integer = Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).subjectpk

            Application.DoEvents()

            'ben9.30.2007
            clsTool.DeleteSubjectCostbyPK(Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).enrollpk)

            'delete EnrollSubjects Record
            Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).Delete()
            Me.EnrollSubjectsTableAdapter.Update(Me.DsRegistrar.EnrollSubjects)


            getSubjectsEnrolled()

            'delete ledger record
            Dim ds As New dsFinance
            Dim dts As New dsFinanceTableAdapters.LedgerbyStudentCourseSubjectTableAdapter
            dts.Fill(ds.LedgerbyStudentCourseSubject, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, subject, "SCHG")
            If ds.LedgerbyStudentCourseSubject.Rows.Count > 0 Then
                ds.LedgerbyStudentCourseSubject(0).Delete()
                dts.Update(ds.LedgerbyStudentCourseSubject)
            End If

            
        End If

    End Sub

    'Function to check if enrollment is closed , ask for password   . Ben 3.5.2008
    Function isEnrollmentOpen() As Boolean
        If clsTool.GetSetting("ENROLLCLOSED").ToUpper = "TRUE" Then
            MsgBox("Enrollment period is already closed. You need to supply Admin password.")
            Dim frmPassword As New frmAdminPassword
            frmPassword.ShowDialog()
            If frmPassword.isDirty Then
                Return True
            Else
                Return False
            End If

        Else  'enrollment is still open
            Return True
        End If
    End Function

    'Function to check total units . allowed is 28 for regular sem, 12 for summer . Ben 3.5.2008
    Function checkTotalUnitsEnrolledifAllowed(ByVal subjectunits As Integer) As Boolean
        If Not IsNumeric(Me.txtUnits.Text) Then Return True 'can be null or empty so that means nothing enrolled

        If Me.txtSemester.Text.ToUpper.Contains("SUM") Then   'SUMMER
            If Convert.ToDecimal(Me.txtUnits.Text) + subjectunits > 12 Then
                MsgBox("Student will be overloaded if you add this subject (allowed 12 units only)." & vbCrLf & "Please supply Admin password.")
                Dim frmPassword As New frmAdminPassword
                frmPassword.ShowDialog()
                If frmPassword.isDirty Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If

        Else 'REGULAR SEMESTER
            If Convert.ToDecimal(Me.txtUnits.Text) + subjectunits > 28 Then
                MsgBox("Student will be overloaded if you add this subject (allowed 28 units only)." & vbCrLf & "Please supply Admin password.")
                Dim frmPassword As New frmAdminPassword
                frmPassword.ShowDialog()
                If frmPassword.isDirty Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
    End Function

    'check subject fusions
    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.DsRegistrar.EnrollSubjects.Rows.Count = 0 Then MsgBox("Nothing enrolled!") : Exit Sub
        Dim SubjectPK As Integer = Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).subjectpk

        'get the offerings and fusions for the active semester
        Dim frm As New frmSubjectFusionList
        frm.m_SubjectPK = SubjectPK
        frm.LoadGrid()
        frm.ShowDialog()

    End Sub

#End Region

    
   
End Class

