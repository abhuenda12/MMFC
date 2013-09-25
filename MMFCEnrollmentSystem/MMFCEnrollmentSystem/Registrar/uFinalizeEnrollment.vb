Public Class uFinalizeEnrollment


    '-------------------------------------------------------------------------------------------------------------
    ' NOTES: 
    ' 1. coursepk is set from enrollsubjects not in enrollheader
    ' 2. Subject Charges for those not reaching Minimum required or Tutorials.. has 3 main types of Tutorials
    '    i.  Regular Subject - no additional charges. Will just be classified as Tutorial
    '    ii. Requested Subject Non RLE
    '           - Subject Cost (min student * tuition fee * units ) will be 
    '                        shared by all class students. This will be done before 
    '                        1st Exam, use Finance>Tutorial Subjects Module to apply charges
    '           - Finance>Tutorial Subjects Module will only add ledger records! EnrollSubjectsCost records are still
    '               done via this module uFinalizeEnrollment
    '    iii. Requested Special Tutorial - still considered Tutorial, but no ADDED CHARGES on white form.
    '                       student pays teacher for the charge via cashier . not part of student ledger costs.

    ' 3. RLE Requested Subject not part of above mentioned types of Tutorials. RLE Requested Charges computed separately.    
    ' 4. White Form doesn't include Requested NON RLE Subjects costing
    '--------------------------------------------------------------------------------------------------------------
   
    '---------------------------------------------------
    'Requested Subject Non RLE Computation
    '1. Requested subjects cost is shared among enrollees
    '2. If NonRLE Requested is CLOSED, that's when charges
    '     are set. 
    '3. computation done via method initializeSubjectCharges()
    '---------------------------------------------------

    Public m_StudentPk As Integer = -1
    Public m_CoursePK As Integer = -1
    Private m_Error As String = ""


#Region "Initialization. Clean up"

    Public Sub InitializeForm()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)

        Me.txtSchoolYear.SelectedValue = clsTool.GetCurYearPK
        Me.txtSemester.SelectedValue = clsTool.GetCurSemPK
        Me.txtSchoolYear.Enabled = False
        Me.txtSemester.Enabled = True
        Me.txtDate.Value = Now.Date
        fillEnrollasYearCombo()

        Me.txtUnits.Text = "0"
        m_CoursePK = -1
        m_Error = ""
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

        txtMiscCharges.Text = "0"
        txtSubjCharges.Text = "0"
        txtGrandTotal.Text = "0"
    End Sub

#End Region

#Region "Choose Student Event , Loading Subjects"

    'Choose Student
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        LoadStudentData()
    End Sub

    'will check if student has previously been charged or initialized, if not, will run initialization automatically
    Sub LoadStudentData()

        Dim frmWait As New frmWait

        Try

            Dim frm As New frmStudentSelect

            frm.TextBox1.Select()

            frm.ShowDialog()


            If frm.Selected Then


                frmWait.Show()
                Application.DoEvents()

                resetData()

                Me.m_StudentPk = frm.m_StudentPK
                Me.txtStudent.Text = frm.m_StudentName
                Me.txtStudentType.Text = frm.m_StudentType

                If getEnrollHeader() Then

                    getSubjectsEnrolled()

                    'Try
                    setSubjectCharges()

                    setMiscCharges()

                    'Catch ex As Exception

                    'Finally
                    frmWait.Hide()
                    'End Try

                End If

                If Not String.IsNullOrEmpty(m_Error) Then
                    MsgBox("Some error occurred." & vbCrLf & m_Error)
                End If
            End If

        Catch ex As Exception


        Finally
            frmWait.Close()
        End Try


    End Sub

    'creates a new row for enrollheader when theres no existing record (id=sempk+yrpk+studentpk)
    Private Function getEnrollHeader() As Boolean
        Dim dt As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter

        dt.Fill(Me.DsRegistrar.EnrollHeader, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk)

        If Me.DsRegistrar.EnrollHeader.Rows.Count > 0 Then

            'set remarks
            Me.txtRemarks.Text = Me.DsRegistrar.EnrollHeader(0).remarks
            'set Enroll as year
            If Not Me.DsRegistrar.EnrollHeader(0).IsyrlevelNull Then
                Me.txtEnrollYear.SelectedValue = Me.DsRegistrar.EnrollHeader(0).yrlevel
            End If

            Return True
        Else

            MsgBox("Student hasn't enrolled any subjects yet.", MsgBoxStyle.Information)

            Return False
        End If
    End Function

    Sub getSubjectsEnrolled()

        Me.EnrollSubjectsTableAdapter.Fill(Me.DsRegistrar.EnrollSubjects, Me.txtSchoolYear.SelectedValue, _
                                          Me.txtSemester.SelectedValue, Me.m_StudentPk)

        If Me.DsRegistrar.EnrollSubjects.Rows.Count > 0 Then

            Me.m_CoursePK = Me.DsRegistrar.EnrollSubjects(0).coursepk
            Me.txtCourse.Text = clsTool.getCourseCompleteDesc(Me.m_CoursePK)

            'Disable EnrollYear and Course when subjects are found to be enlisted 
            REM Still enable EnrollYear to allow adjustments incase year level was forgotten in Enroll Subject Module
            ''Me.txtEnrollYear.Enabled = False
            Me.txtSemester.Enabled = False

            totalUnits()
        End If
    End Sub

    Private Sub totalUnits()
        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then Me.txtUnits.Text = "0.0" : Exit Sub
        Dim ctr As Integer
        Dim units As Double = 0
        For ctr = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1

            If Me.DsRegistrar.EnrollSubjects(ctr).RowState = DataRowState.Deleted Then Continue For
            If Me.DsRegistrar.EnrollSubjects(ctr).status = 1 Then
                units = units + clsTool.getUnits(Me.DsRegistrar.EnrollSubjects(ctr).subjectpk)
            End If
        Next
        Me.txtUnits.Text = units
    End Sub

#End Region

#Region "Grid, Boxes, Totals > Display handling"

    Private Sub txtSemester_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSemester.Validating
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

    'Enrolled Subjects Grid
    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsRegistrar.EnrollSubjects(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub

        'Course Name
        If e.ColumnIndex = 8 Then
            e.Value = clsTool.getCourseName(Me.DsRegistrar.EnrollSubjects(e.RowIndex).coursepk)
        End If

        'Subject Name
        If e.ColumnIndex = 2 Then
            e.Value = clsTool.GetSubjectDescription(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If

        'Subject/Offering Type (R,RQ,T)
        If e.ColumnIndex = 3 Then
            e.Value = clsTool.getClassType(Me.DsRegistrar.EnrollSubjects(e.RowIndex).syofferingpk, Me.DsRegistrar.EnrollSubjects(e.RowIndex).sempk, Me.DsRegistrar.EnrollSubjects(e.RowIndex).yearpk)
        End If

        'Subject Status
        If e.ColumnIndex = 4 Then
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 0 Then e.Value = "NOT ENROLLED"
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 1 Then e.Value = "ENROLLED"
            If Me.DsRegistrar.EnrollSubjects(e.RowIndex).status = 2 Then e.Value = "DROPPED"
        End If

        'Sked/Class
        If e.ColumnIndex = 5 Then
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

        'Subject Units
        If e.ColumnIndex = 6 Then
            e.Value = clsTool.getUnits(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If

        'ben9.30.3007 . LAB Units
        If e.ColumnIndex = 7 Then
            e.Value = clsTool.getLabUnits(Me.DsRegistrar.EnrollSubjects(e.RowIndex).subjectpk)
        End If

    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then Exit Sub
        If Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position).RowState = DataRowState.Deleted Then Exit Sub
        displaySubjectCost()
    End Sub

    Private Sub displaySubjectCost()
        With Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position)
            Me.EnrollSubjectsCostbyPKTableAdapter.Fill(Me.DsRegistrar.EnrollSubjectsCostbyPK, .enrollpk)

            'now set the label of the group box
            Dim subjectname As String = clsTool.GetSubjectName(.subjectpk)
            GroupBox2.Text = "Charges for : " & subjectname
        End With


    End Sub

    'Subject Charges Grid
    Private Sub DataGridView2_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView2.CellValueNeeded
        If Me.DsRegistrar.EnrollSubjectsCostbyPK(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If e.ColumnIndex = 0 Then
            e.Value = clsTool.getTrTypeName(Me.DsRegistrar.EnrollSubjectsCostbyPK(e.RowIndex).trpk)
        End If

    End Sub

    'Misc  Charges Grid
    Private Sub DataGridView3_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView3.CellValueNeeded
        If Me.DsFinance.SemAmortbyStudentYearSemPK(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        Try
            If e.ColumnIndex = 1 Then
                e.Value = clsTool.getChargeCategory(Me.DsFinance.SemAmortbyStudentYearSemPK(e.RowIndex).ChargeSchedPK)
            End If
            If e.ColumnIndex = 2 Then
                e.Value = clsTool.getChargeSchedName(Me.DsFinance.SemAmortbyStudentYearSemPK(e.RowIndex).ChargeSchedPK)
            End If
            If e.ColumnIndex = 4 Then
                e.Value = clsTool.getChargeRemarks(Me.DsFinance.SemAmortbyStudentYearSemPK(e.RowIndex).ChargeSchedPK)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'to set amount and linenumber in grid2
    Private Sub detTotal()
        If Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count <= 0 Then Exit Sub
        Dim i As Integer
        For i = 0 To Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count - 1
            With Me.DsRegistrar.EnrollSubjectsCostbyPK(i)
                If .RowState = DataRowState.Deleted Then Continue For
                .amount = .quantity * .unitamount
                .linenumber = i + 1
            End With
        Next
    End Sub

    'set Summary Box
    Private Sub SetSummaryBoxCharges()
        Dim miscAmount As Double = 0

        If DsFinance.SemAmortbyStudentYearSemPK.Rows.Count > 0 Then
            miscAmount = DsFinance.SemAmortbyStudentYearSemPK.Compute("SUM(Charge)", String.Empty)
        End If

        txtMiscCharges.Text = FormatNumber(miscAmount, 2)

        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then
            Me.txtSubjCharges.Text = "0.00"
            Me.txtGrandTotal.Text = FormatNumber(Convert.ToDouble(Me.txtMiscCharges.Text), 2)
            Exit Sub
        Else
            Dim sumamount As Double = 0
            Dim i As Integer
            For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1
                If Me.DsRegistrar.EnrollSubjects(i).RowState = DataRowState.Deleted Then Continue For
                sumamount += clsTool.getSubjectCostTotal(Me.DsRegistrar.EnrollSubjects(i).enrollpk)
            Next
            Me.txtSubjCharges.Text = FormatNumber(sumamount, 2)
            Me.txtGrandTotal.Text = FormatNumber(sumamount + Convert.ToDouble(Me.txtMiscCharges.Text), 2)
        End If
    End Sub

#End Region

#Region "Charges Computation and Processing"

    Private Sub ButtonRecomputeCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecomputeCharges.Click

        Dim frmWait As New frmWait
        frmWait.Show()
        Application.DoEvents()

        Try
            setSubjectCharges(True)

            setMiscCharges()

        Catch ex As Exception

        Finally

            frmWait.Close()
        End Try
    End Sub

    'main method that loops all subjects then calls a sub method to compute charges
    Private Sub setSubjectCharges(Optional ByVal recompute As Boolean = False)

        If clsTool.isEnrollmentOpen() = False Then Exit Sub

        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then
            Exit Sub
        End If

        'Loop all subjects
        Dim i As Integer
        For i = 0 To DsRegistrar.EnrollSubjects.Rows.Count - 1

            With Me.DsRegistrar.EnrollSubjects(i)

                'dont set charges if not ENROLLED (1)
                If Not .status = 1 Then Continue For

                'fill grid2/dataset2 by enrollpk from grid1/dataset1
                Me.EnrollSubjectsCostbyPKTableAdapter.Fill(Me.DsRegistrar.EnrollSubjectsCostbyPK, .enrollpk)


                'For Recompute , Delete any existing subject costs
                If Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count > 0 And recompute Then

                    Dim strSQL As String = "DELETE FROM EnrollSubjectsCost WHERE (headerpk = " & .enrollpk & " ) "
                    Try
                        clsTool.runDBSQL(strSQL)
                        'rebind grid
                        Me.EnrollSubjectsCostbyPKTableAdapter.Fill(Me.DsRegistrar.EnrollSubjectsCostbyPK, .enrollpk)
                    Catch ex As Exception
                        MsgBox("An error occurred when subject costs were being computed. Previous costs were not deleted. Please double check." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try

                    'continue setting charges

                ElseIf Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count > 0 And Not recompute Then
                    'do nothing, continue Loop
                    Continue For
                ElseIf Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count <= 0 Then

                    'continue setting charges
                End If

                '============================================================================
                ' This to end won't run if just normal loading of student, recompute = false
                '============================================================================

                REM 11.16.2011
                ' Superceed checking of Closed Offering. We will put that parameter in the
                '   submethod which computes for each subject charge

                'Check if Requested subject  
                'added code in the sub method to distinguish Regular Requested subject from RLE Requested Subject 11.29.2007
                'Check if its already closed. Division of charges can be done only if closed.

                Dim subjectunits As Single = clsTool.getUnits(.subjectpk)
                Dim labunits As Single = clsTool.getLabUnits(.subjectpk)

                Dim thisRequested As Boolean = clsTool.testSYOfferIfRequested(.syofferingpk)
                Dim thisClosed As Boolean = clsTool.testSYOfferIfClosed(.syofferingpk)

                initializeSubjectCharges(subjectunits, labunits, .subjectpk, .enrollpk, .syofferingpk, thisRequested, thisClosed)

                'Call method to update Student Ledger for this subject's costing.. tuition etc.
                addLedger(.coursepk, .subjectpk, .enrollpk, "SCHG")

                ' ''Now check if this subject is REQUESTED, only CLOSED REQUESTED subjects should be initialized
                '' ''If clsTool.testSYOfferIfRequested(.syofferingpk) Then
                '' ''    ''If clsTool.testSYOfferIfClosed(.syofferingpk) Then
                '' ''    initializeSubjectCharges(subjectunits, labunits, .subjectpk, .enrollpk, .syofferingpk)
                '' ''    addLedger(.coursepk, .subjectpk, .enrollpk, "SCHG")
                '' ''    ''End If
                '' ''Else
                ' '' ''Not a requested subject
                '' ''initializeSubjectCharges(subjectunits, labunits, .subjectpk, .enrollpk, .syofferingpk)
                '' ''addLedger(.coursepk, .subjectpk, .enrollpk, "SCHG")
                '' ''End If

            End With

        Next

        'Refresh Display of Summary
        SetSummaryBoxCharges()

    End Sub

    'sub method that does the computation. 
    'Has 3 Parts
    ' 1. Subject Units setting
    ' 2. Main Subject Charges - Tuition, Comm Ext fee, RLE NCM Non Requested, Internship, Course Specific Charges
    ' 3. RLE and nonRLE Requested Subject
    Private Sub initializeSubjectCharges(ByVal subjectunits As Single, ByVal labunits As Single, _
            ByVal subjectpk As Integer, ByVal headerpk As Integer, ByVal syofferpk As Integer, _
            ByVal isRequested As Boolean, ByVal isClosed As Boolean)

        Dim ds As New dsSchool.TRTypesDataTable
        Dim dt As New dsSchoolTableAdapters.TRTypesTableAdapter

        Dim tuitionfee As Double = 0

        dt.Fill(ds)

        If ds.Rows.Count <= 0 Then MsgBox("No Transaction Type Records to choose from") : Exit Sub

        '========================
        ' SETTING of UNITS
        '========================

        'ben11.23 . For NSTP, RLE101,RLE102,NCM104,NCM105 , divide by half the units
        Dim subjectcode As String = clsTool.GetSubjectCode(subjectpk)
        ' ''If (subjectcode.ToUpper.Contains("NSTP")) Or _
        ' '' (subjectcode.ToUpper.Contains("RLE") And subjectcode.ToUpper.Contains("101")) Or _
        ' ''  (subjectcode.ToUpper.Contains("RLE") And subjectcode.ToUpper.Contains("102")) Or _
        ' ''  (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("101")) Or _
        ' ''  (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("102")) Or _
        ' ''  (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("104")) Or _
        ' ''  (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("105")) Then

        '11.4.2011. NSTP should still have units halved.
        If (subjectcode.ToUpper.Contains("NSTP")) Then

            'CREATED RLEunits field. tuition for NCM should be applied to the Tuition Units which is
            ' subjectunits = subjectunits as is

            ' ''10.19.2011. Test for NEW NURSING CURRICULUM. Hard coded subject pk 
            ' '' NCM 104 - 578 , 5 units charged tuition 4 to RLE
            ' '' NCM 105 - 579 , 4 units charged to tuition 2 to RLE
            ''If subjectpk = 578 Then

            ''    subjectunits = 5

            ''ElseIf subjectpk = 579 Then

            ''    subjectunits = 4
            ''Else
            ''    subjectunits /= 2
            ''End If

            subjectunits /= 2

        ElseIf (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("100")) Then
            'Ben 6.12.2008 . another modification as requested.
            subjectunits = 1
        End If

        '==============================
        ' SETTING of Subject Charges
        '==============================
        Dim thisStudentType As String = ""

        'Loop the TRTypes table to get all applicable charges for the subject
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1

            'check student type for TRN, make it TRANSFEREE
            If ds(i).TRStudentType = "TRN" Then
                thisStudentType = "TRANSFEREE"
            Else
                thisStudentType = ds(i).TRStudentType
            End If

            'Tuition = subjectunits * tuition fee per unit 
            'Other Fees = tramount * 1

            'validate NULLS
            If ds(i).IsTRCourseNull Then ds(i).TRCourse = -99
            If ds(i).IsTRSubjectNull Then ds(i).TRSubject = -99
            If ds(i).IsTRYearLevelNull Then ds(i).TRYearLevel = -99

            'TUITION FEE
            If ds(i).TRCourse = m_CoursePK And _
               (ds(i).TRSubject = subjectpk Or ds(i).TRSubject = -99) And _
               (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) And _
                ds(i).TRCode.ToUpper = "TUITION" Then

                'Superceeded by Jan 27 2008 Requests. NCM will have tuition fee. 
                '''''NCM Subjects have no tuition fee . They have a special subject cost (the RLE matrix)
                ''''If subjectcode.ToUpper.Contains("NCM") Then Continue For

                '1.25.2008 . New Directive. Only RLE 103 will be charged with tuition. The other RLEs are exempted.
                If subjectcode.ToUpper.Contains("RLE") And Not subjectcode.ToUpper.Contains("103") Then Continue For

                Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                     ds(i).TRPK, subjectunits, ds(i).TRAmount, 0, 0, True)

                tuitionfee = ds(i).TRAmount 'for usage in requested subject costing below 

                'COMM EXTENSION FEE course specific
                'Comm Extension fee is applied only once (course is specific)
            ElseIf ds(i).TRCourse = m_CoursePK And _
               (ds(i).TRSubject = subjectpk Or ds(i).TRSubject = -99) And _
               (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) And _
                (ds(i).TRCode.ToUpper.Contains("EXTENSION")) Then
                If testforCommExtRecords() = False Then
                    Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                         ds(i).TRPK, 1, ds(i).TRAmount, 0, 0, False)
                End If

                'COMM EXTENSION FEE and course is not specific
            ElseIf (ds(i).TRCourse = -99) And _
               (ds(i).TRSubject = subjectpk) And _
               (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) And _
                (ds(i).TRCode.ToUpper.Contains("EXTENSION")) Then

                If testforCommExtRecords() = False Then
                    Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                         ds(i).TRPK, 1, ds(i).TRAmount, 0, 0, False)
                End If

                'RLE NCM REQUESTED SUBJECT  11.29.2007
            ElseIf (ds(i).TRCourse = m_CoursePK Or ds(i).TRCourse = -99) And _
               (ds(i).TRSubject = subjectpk) And _
                (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) And _
                (ds(i).TRCode.ToUpper.Contains("RLE") And ds(i).TRCode.ToUpper.Contains("REQUEST")) Then

                'DO NOTHING HERE. We add the charges below in Requested Subject Costing

                'RLE NCM Not Requested 11.29.2007
            ElseIf (ds(i).TRCourse = m_CoursePK Or ds(i).TRCourse = -99) And _
               (ds(i).TRSubject = subjectpk) And _
                (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) And _
                (ds(i).TRCode.ToUpper.Contains("RLE") And Not ds(i).TRCode.ToUpper.Contains("REQUEST")) Then

                'Special RLE Amount * 1 only not * subject units
                If Not clsTool.testSYOfferIfRequested(syofferpk) Then
                    Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                             ds(i).TRPK, 1, ds(i).TRAmount, 0, 0, False)
                End If

                'OTHER CHARGES course specific . includes INTERNSHIP here. 
            ElseIf ds(i).TRCourse = m_CoursePK And _
               (ds(i).TRSubject = subjectpk Or ds(i).TRSubject = -99) And _
                (ds(i).TRYearLevel = Me.txtEnrollYear.SelectedValue Or ds(i).TRYearLevel = -99) Then

                Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                         ds(i).TRPK, 1, ds(i).TRAmount, 0, 0, False)

                'Student Type Charges PLUS Subject handled here. E.G. New Students plus PE Subject will have PE Uniform Charges
            ElseIf ds(i).TRSubject = subjectpk And thisStudentType = clsTool.getStudentType(m_StudentPk) And ds(i).TRStudentType <> "ALL" Then

                Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                        ds(i).TRPK, 1, ds(i).TRAmount, 0, 0, False)

            End If
        Next

        '*************************************
        'Requested Subject Additional Costing
        '*************************************

        '=================================================================================================================================
        '=== 10.16 Get additional costing if requested subject 
        '=== 11.29 Added code for RLE Requested Subject NCM100-105

        'Formula : student share = tuitionfee*units*minstudentsrequired/enrollees 
        'additional cost =  student share - tuition per unit of subject         

        Dim enrollcount As Integer = clsTool.getStudentCount(Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, syofferpk)
        Dim minrequired As Integer = clsTool.getSYOfferMinStudents(syofferpk)

        If isRequested Then

            'RLE requested subject . Modified 7.10.2008. Only RLE will be charged this way , not NCM

            If clsTool.GetSubjectCode(subjectpk).ToUpper.Contains("RLE") And isClosed Then

                Dim rlereqcharge As Double = clsTool.getTrChargeforRLERequest(subjectpk)
                Dim studentshare As Double = rlereqcharge * minrequired / enrollcount
                Dim additionalshare As Double = studentshare - (rlereqcharge)
                Dim trpk As Integer = clsTool.getTrPKRLERequest(subjectpk)

                If studentshare > 0 Then
                    '7.10.2008 . We do 2 entries to separate the RLErequestcharge from the additional charge
                    'RLE Request Charge
                    Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                                    trpk, 1, rlereqcharge, 0, 0, False)
                    'Additional Charge per Student 
                    If additionalshare > 0 Then
                        Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                                        trpk, 1, additionalshare, 0, 0, False)

                    End If

                End If

            Else

                '*******************************
                ' non RLE requested subject
                '*******************************
                'check for closed offering before dividing subject cost among class
                If isClosed Then

                    Dim studentshare As Double = tuitionfee * subjectunits * minrequired / enrollcount
                    Dim additionalcost As Double = studentshare - (tuitionfee * subjectunits)

                    'We set requested subject as trpk = -1 

                    If additionalcost > 0 Then
                        Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(headerpk, Me.txtEnrollYear.SelectedValue, _
                                        -1, 1, additionalcost, 0, 0, False)
                    End If

                End If
               

            End If

        End If
        '===================================================================================================================================

        'this multiplies the line unit amounts and the qty (tuition fee * subject units) 
        detTotal()

        Try
            Me.EnrollSubjectsCostbyPKTableAdapter.Update(Me.DsRegistrar.EnrollSubjectsCostbyPK)
        Catch ex As Exception

            m_Error = m_Error & vbCrLf & ex.Message
            MsgBox(m_Error, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'will check if Comm Extension fee has been applied in one of the enrolled subjects already
    Private Function testforCommExtRecords() As Boolean
        Dim ds As New dsRegistrar.EnrollSubjectsCostbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCostbyPKTableAdapter

        'loop the enrolled subjects
        Dim i As Integer
        Dim j As Integer
        For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1
            With Me.DsRegistrar.EnrollSubjects(i)
                If .status = 1 Then
                    'loop the charges of this enrolled subject look for TRCode = Comm Extension
                    dt.Fill(ds, .enrollpk)
                    For j = 0 To ds.Rows.Count - 1
                        Dim trcode As String = clsTool.getTrTypeCode(ds(j).trpk)
                        If trcode.ToUpper.Contains("EXTENSION") Then Return True
                    Next
                End If
            End With
        Next

        Return False
    End Function
   

#End Region

#Region "ADD/EDIT/DELETE Subject Charges Grid Button events"
    'Add Cost
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Dim frm As New frmEnrollSubjectCharge
        frm.ShowDialog()
        If frm.isDirty Then
            Dim enrollyr = Me.txtEnrollYear.SelectedValue
            With Me.DsRegistrar.EnrollSubjects(Me.EnrollSubjectsBindingSource.Position)

                Me.DsRegistrar.EnrollSubjectsCostbyPK.AddEnrollSubjectsCostbyPKRow(.enrollpk, enrollyr, frm.trtypepk, frm.txtQuantity.Text, frm.txtAmount.Text, 0, 0, False)

                detTotal()

                Me.EnrollSubjectsCostbyPKTableAdapter.Update(Me.DsRegistrar.EnrollSubjectsCostbyPK)

                updateLedger(.enrollpk, "SCHG")

                SetSummaryBoxCharges()
            End With
        End If
    End Sub
    'Edit Cost
    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Dim frm As New frmEnrollSubjectCharge
        With Me.DsRegistrar.EnrollSubjectsCostbyPK(Me.EnrollSubjectsCostbyPKBindingSource.Position)
            frm.trtypepk = .trpk
            frm.txtTransaction.Text = clsTool.getTrTypeName(.trpk)
            frm.txtQuantity.Text = FormatNumber(.quantity, 2)
            frm.txtAmount.Text = FormatNumber(.unitamount, 2)
            frm.txtTotal.Text = FormatNumber(.amount, 2)
        End With
        frm.ShowDialog()
        If frm.isDirty Then
            With Me.DsRegistrar.EnrollSubjectsCostbyPK(Me.EnrollSubjectsCostbyPKBindingSource.Position)
                .trpk = frm.trtypepk
                .quantity = frm.txtQuantity.Text
                .unitamount = frm.txtAmount.Text

                detTotal()

                Me.EnrollSubjectsCostbyPKTableAdapter.Update(Me.DsRegistrar.EnrollSubjectsCostbyPK)

                updateLedger(.headerpk, "SCHG")

                SetSummaryBoxCharges()
            End With
        End If
    End Sub
    'Delete Cost
    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        If Me.DsRegistrar.EnrollSubjectsCostbyPK.Rows.Count <= 0 Then MsgBox("No cost to delete") : Exit Sub
        If MsgBox("Are you sure to delete selected cost?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                With Me.DsRegistrar.EnrollSubjectsCostbyPK(Me.EnrollSubjectsCostbyPKBindingSource.Position)
                    Dim headerpk As Integer = .headerpk  'before the row gets deleted get the pk
                    .Delete()
                    detTotal()
                    Me.EnrollSubjectsCostbyPKTableAdapter.Update(Me.DsRegistrar.EnrollSubjectsCostbyPK)
                    updateLedger(headerpk, "SCHG")

                    SetSummaryBoxCharges()

                End With
            Catch ex As Exception
                MsgBox("Error deleting. Try again." & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "Ledger Codes"

    'Code to add or modify current Ledger record of student for the given Subject (course and Enrollheaderpk as other parameter)
    Private Sub addLedger(ByVal course As Integer, ByVal subject As Integer, ByVal enrollpk As Integer, ByVal linetype As String)

        'All cost of given subjectpk
        Dim subjtotalamt As Double = clsTool.getSubjectCostTotal(enrollpk)

        Dim ds As New dsFinance
        Dim dts As New dsFinanceTableAdapters.LedgerbyStudentCourseSubjectTableAdapter

        dts.Fill(ds.LedgerbyStudentCourseSubject, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, subject, linetype)

        If ds.LedgerbyStudentCourseSubject.Rows.Count = 0 Then

            ds.LedgerbyStudentCourseSubject.AddLedgerbyStudentCourseSubjectRow(Me.txtDate.Value.Date, enrollpk, _
               Me.txtSemester.SelectedValue, subject, course, linetype, subjtotalamt, 0, Me.m_StudentPk, Me.txtSchoolYear.SelectedValue, "")

        Else

            ds.LedgerbyStudentCourseSubject(0).amount = subjtotalamt
        End If

        dts.Update(ds.LedgerbyStudentCourseSubject)

    End Sub

    'ben10.3.2007
    ' gets the total subject cost then edits the ledger record with that amount
    Private Sub updateLedger(ByVal enrollpk As Integer, ByVal linetype As String)
        Dim ds As New dsFinance.LedgerbyRefLinetypeDataTable
        Dim dt As New dsFinanceTableAdapters.LedgerbyRefLinetypeTableAdapter
        dt.Fill(ds, enrollpk, linetype)
        If ds.Rows.Count <= 0 Then Exit Sub

        Dim subjtotalamt As Double = clsTool.getSubjectCostTotal(enrollpk)
        ds(0).amount = subjtotalamt
        dt.Update(ds)
    End Sub

    Sub RemoveLedger(ByVal course As Integer, ByVal subject As Integer)

        Dim ds As New dsFinance
        Dim dts As New dsFinanceTableAdapters.LedgerbyStudentCourseSubjectTableAdapter
        dts.Fill(ds.LedgerbyStudentCourseSubject, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, subject, "SCHG")
        If ds.LedgerbyStudentCourseSubject.Rows.Count > 0 Then
            ds.LedgerbyStudentCourseSubject(0).Delete()
            dts.Update(ds.LedgerbyStudentCourseSubject)
        End If
        'check if no more subjects enrolled
        Dim ctr As Integer
        Dim found As Boolean = False
        For ctr = 0 To Me.DsRegistrar.EnrollSubjects.Count - 1
            If Me.DsRegistrar.EnrollSubjects(ctr).status = 1 Then found = True
        Next
        'delete course charges if no more enrolled
        If Not found Then
            Dim dtc As New dsFinanceTableAdapters.LedgerbyStudentCourseTableAdapter
            dtc.Fill(ds.LedgerbyStudentCourse, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, course, "CCHG")
            If ds.LedgerbyStudentCourse.Rows.Count > 0 Then
                ds.LedgerbyStudentCourse(0).Delete()
                dtc.Update(ds.LedgerbyStudentCourse)
            End If
        End If
    End Sub
#End Region

#Region "Miscellaneous Charges"

    Private Sub LoadMiscGrid()
        Me.SemAmortbyStudentYearSemPKTableAdapter.Fill(Me.DsFinance.SemAmortbyStudentYearSemPK, m_StudentPk, txtSchoolYear.SelectedValue, txtSemester.SelectedValue)
    End Sub

    'MISC CHARGES in Tab2>Grid3
    Private Sub setMiscCharges()

        LoadMiscGrid()

        If Me.DsFinance.SemAmortbyStudentYearSemPK.Rows.Count <= 0 Then 'Else student has previous misc charges set for sypk,sempk
            'Initialize charges
            getChargeSchedule()
        End If

        'Start setting Ledger value for the MISC charges

        'The miscellaneous charges once set will be saved
        'should create the MISC charges in Ledger also

        Dim misctotal As Double = Me.DsFinance.SemAmortbyStudentYearSemPK.Compute("SUM(charge)", Nothing)

        Me.txtMiscCharges.Text = FormatNumber(misctotal, 2)

        'now get/set Ledger values for MISC type
        Dim ds As New dsFinance
        Dim dtc As New dsFinanceTableAdapters.LedgerbyStudentCourseTableAdapter

        dtc.Fill(ds.LedgerbyStudentCourse, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, m_CoursePK, "MISC")

        If ds.LedgerbyStudentCourse.Rows.Count = 0 Then

            ds.LedgerbyStudentCourse.AddLedgerbyStudentCourseRow(Me.txtDate.Value.Date, "", Me.txtSemester.SelectedValue, _
                                    -99, m_CoursePK, "MISC", misctotal, 0, Me.m_StudentPk, Me.txtSchoolYear.SelectedValue, "")

        Else
            'set the first record. there should be only 1 MISC record in LEdger
            ds.LedgerbyStudentCourse(0).amount = misctotal
        End If

        Try

            dtc.Update(ds.LedgerbyStudentCourse)

        Catch ex As Exception

            'add error here
            m_Error = m_Error & vbCrLf & ex.Message
        End Try

        'recalculate Summary of amounts
        SetSummaryBoxCharges()

    End Sub

    'Procedure to load all appropriate misc charges for the student
    Private Function getChargeSchedule() As Double

        Dim ds As New dsFinance.ChargeScheduleDataTable
        Dim dt As New dsFinanceTableAdapters.ChargeScheduleTableAdapter
        dt.Fill(ds)

        'get all charges first then loop through the table and get appropriate 
        'charges for the current student (based on student type)
        Dim type As String = Me.txtStudentType.Text
        Dim i As Integer
        Dim yrlevel As Integer = txtEnrollYear.SelectedValue
        Try

            'Start looping all CHARGE SCHEDULE data
            For i = 0 To ds.Rows.Count - 1

                'This with statement is just for the AddRowToTemplate or MiscChargeTab code. not for loop.
                With Me.DsFinance.SemAmortbyStudentYearSemPK

                    'set nullvalues
                    If ds(i).IscoursepkNull Then ds(i).coursepk = -99
                    If ds(i).IsyrlevelNull Then ds(i).yrlevel = -99
                    If ds(i).IsoldStudentNull Then ds(i).oldStudent = False
                    If ds(i).IsnewStudentNull Then ds(i).newStudent = False
                    If ds(i).IstransferStudentNull Then ds(i).transferStudent = False

                    'START LAB
                    '
                    '
                    'check for Lab units before applying lab fee
                    If ds(i).Category.ToUpper = "LABORATORY" Or ds(i).Category.ToUpper = "LAB" Then
                        'old code to test for lab units
                        If checkforLabunits() = False Then Continue For

                        REM 10.21.2011
                        'additional checking for the year level in curriculum of the said Lab Charges
                        'if student has enrolled subject with lab for different year levels in his curriculum
                        '   charge those separately

                        'loop enrolled subject here and get the year level in the curriculum
                        'test for same course first
                        If ds(i).coursepk = Me.m_CoursePK Then

                            'this test is to check if the misc charge for a certain year level
                            ' is met by the enrolled subject of the student (curriculum year level)
                            ' the year level used here is not the Student Yr Level but the Year level in the curriculum of the student
                            If hasEnrolledSubjectWithLabInYearLevel(ds(i).yrlevel) Then

                                'at this point, this misc charge is proven to be applicable to this student
                                'since the coursepk, subjectpk, yearlevel and misc_charge yearlevel has been tested

                                'add to Misc Charge Tab!
                                .AddSemAmortbyStudentYearSemPKRow(Me.m_CoursePK, ds(i).pk, ds(i).Amount, yrlevel, Me.m_StudentPk, type, txtSchoolYear.SelectedValue, txtSemester.SelectedValue)

                                'update db
                                Me.SemAmortbyStudentYearSemPKTableAdapter.Update(Me.DsFinance.SemAmortbyStudentYearSemPK)

                                'Then skip the procedures below to avoid dual entry
                                Continue For
                            End If

                        Else

                            'curent LAB Type Misc Charge is not applicable to student so skip to next index
                            Continue For

                        End If

                        'END LAB

                    Else

                        'THIS PORTION is Now for the NON LAB
                        Select Case type
                            Case "OLD"

                                If (ds(i).oldStudent And ds(i).yrlevel = -99 And ds(i).coursepk = -99) Or _
                                    (ds(i).oldStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = -99) Or _
                                    (ds(i).oldStudent And ds(i).yrlevel = -99 And ds(i).coursepk = Me.m_CoursePK) Or _
                                    (ds(i).oldStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = Me.m_CoursePK) Then

                                    .AddSemAmortbyStudentYearSemPKRow(Me.m_CoursePK, ds(i).pk, ds(i).Amount, yrlevel, Me.m_StudentPk, type, txtSchoolYear.SelectedValue, txtSemester.SelectedValue)

                                End If

                            Case "NEW"
                                If (ds(i).newStudent And ds(i).yrlevel = -99 And ds(i).coursepk = -99) Or _
                                    (ds(i).newStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = -99) Or _
                                    (ds(i).newStudent And ds(i).yrlevel = -99 And ds(i).coursepk = Me.m_CoursePK) Or _
                                    (ds(i).newStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = Me.m_CoursePK) Then

                                    .AddSemAmortbyStudentYearSemPKRow(Me.m_CoursePK, ds(i).pk, ds(i).Amount, yrlevel, Me.m_StudentPk, type, txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue)
                                End If

                            Case "TRANSFEREE"
                                If (ds(i).transferStudent And ds(i).yrlevel = -99 And ds(i).coursepk = -99) Or _
                                    (ds(i).transferStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = -99) Or _
                                    (ds(i).transferStudent And ds(i).yrlevel = -99 And ds(i).coursepk = Me.m_CoursePK) Or _
                                    (ds(i).transferStudent And ds(i).yrlevel = yrlevel And ds(i).coursepk = Me.m_CoursePK) Then

                                    .AddSemAmortbyStudentYearSemPKRow(Me.m_CoursePK, ds(i).pk, ds(i).Amount, yrlevel, Me.m_StudentPk, type, txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue)
                                End If
                        End Select

                        'update db
                        Me.SemAmortbyStudentYearSemPKTableAdapter.Update(Me.DsFinance.SemAmortbyStudentYearSemPK)

                    End If  'End of test if LAB


                End With


            Next 'END LOOP for the MISC CHARGES MASTER TABLE


        Catch ex As Exception

            'add error here    
            m_Error = m_Error & vbCrLf & ex.Message
        End Try

    End Function

    Private Function checkforLabunits() As Boolean
        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then Return False
        Dim i As Integer
        For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1
            With Me.DsRegistrar.EnrollSubjects(i)
                If clsTool.getLabUnits(.subjectpk) > 0 Then Return True
            End With
        Next
        Return False
    End Function

    'Check all enrolled subjects if it has lab, and if it is found in the same year level in the curriculum
    'add checking for fused subjects
    Private Function hasEnrolledSubjectWithLabInYearLevel(ByVal _miscChargeYearLevel As Integer) As Boolean
        Dim result As Boolean = False

        If Me.DsRegistrar.EnrollSubjects.Rows.Count <= 0 Then Return False
        Dim i, j As Integer
        'LOOP ENROLLED SUBJECTS
        For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1

            With Me.DsRegistrar.EnrollSubjects(i)

                Dim thisSubjectYearLevel As Integer = clsTool.getYearLevelInCurriculumByCourse(.subjectpk, m_CoursePK)

                If clsTool.getLabUnits(.subjectpk) > 0 Then

                    'now test if the misc charge year level is same with curriculum year level
                    If thisSubjectYearLevel = _miscChargeYearLevel Then
                        result = True
                        Exit For  'OUTER FOR LOOP
                    End If
                End If


                    'TEST for Fused
                    'Begin fused subject testing
                    '
                    'test fused subjects for this student's course/curriculum if has Lab Units

                Dim dsFused As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
                Dim dtFused As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter

                dtFused.Fill(dsFused, .syofferingpk)

                If dsFused.Rows.Count > 0 Then
                    'check for each fused subject if has lab unit
                    For j = 0 To dsFused.Rows.Count - 1

                        Dim fusedSubjectPK As Integer = dsFused(j).subjectPK

                        If clsTool.getLabUnits(fusedSubjectPK) > 0 Then

                            Dim fusedSubjectYearLevel As Integer = _
                                    clsTool.getYearLevelInCurriculumByCourse(fusedSubjectPK, m_CoursePK)

                            'fused subject has lab units so test if its inside curriculum and misc charge year level
                            If fusedSubjectYearLevel = _miscChargeYearLevel Then
                                result = True
                                Exit For 'INNER LOOP
                            End If

                        End If
                    Next

                End If
                '
                '
                'END fused subject


                'if at this point result is true, EXIT OUTER LOOP ALSO
                If result Then Exit For

            End With
        Next
        '
        '
        'END Loop Subjects

        Return result

    End Function


    'Delete Misc Charges button . delete both in ledger and in semamort
    Private Sub deleteMiscCharges()
        Dim ds As New dsFinance.SemAmortbyStudentYearSemPKDataTable
        Dim dsc As New dsFinance.LedgerbyStudentCourseDataTable
        Dim dt As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        Dim dtc As New dsFinanceTableAdapters.LedgerbyStudentCourseTableAdapter

        dt.Fill(ds, Me.m_StudentPk, Me.txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue)
        dtc.Fill(dsc, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, Me.m_CoursePK, "MISC")

        If ds.Rows.Count <= 0 And dsc.Rows.Count <= 0 Then MsgBox("No Misc. Charges to delete") : Exit Sub
        If MsgBox("Are you sure to delete ALL Misc Charges?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try

                'Delete all rows in SemAmort 
                Dim con As New System.Data.SqlClient.SqlConnection(My.Settings.mmfcdbConnectionString)
                Dim com As New System.Data.SqlClient.SqlCommand("DELETE FROM SemAmort WHERE studentpk = " & Me.m_StudentPk & " AND sypk = " & Me.txtSchoolYear.SelectedValue & " AND sempk = " & Me.txtSemester.SelectedValue, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()

                'Delete MISC record from Ledger
                dsc(0).Delete()
                dtc.Update(dsc)

                Me.txtMiscCharges.Text = "0.00"

                SetSummaryBoxCharges()

                'Refresh Misc Charges Grid 
                LoadMiscGrid()

            Catch ex As Exception

                MsgBox("Error deleting miscellaneous charges. Try again." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

            End Try
        End If

    End Sub
#End Region

#Region "Misc Grid Button Events"

    'add misc
    Private Sub NewToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton1.Click
        Dim frm As New frmMiscChargesDetails
        frm.loadData()
        frm.ShowDialog()
        If frm.isDirty Then
            With Me.DsFinance.SemAmortbyStudentYearSemPK
                .AddSemAmortbyStudentYearSemPKRow(m_CoursePK, frm.chargepk, frm.txtAmount.Text, txtEnrollYear.SelectedValue _
                    , m_StudentPk, Me.txtStudentType.Text, txtSchoolYear.SelectedValue, txtSemester.SelectedValue)

                checkDuplicate(frm.chargepk)
            End With

            'update db here
            Try
                SemAmortbyStudentYearSemPKTableAdapter.Update(DsFinance.SemAmortbyStudentYearSemPK)


            Catch ex As Exception
                MsgBox("Error adding miscellaneous charges. Try again." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

                clsTool.SaveErrorLog("Finalize Enrollment > New Misc Charge", ex.Message)
            End Try

            SetSummaryBoxCharges()
        End If
    End Sub
    'edit misc
    Private Sub OpenToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton1.Click
        If Me.DsFinance.SemAmortbyStudentYearSemPK.Rows.Count <= 0 Then Exit Sub

        Dim frm As New frmMiscChargesDetails
        frm.loadData()

        With Me.DsFinance.SemAmortbyStudentYearSemPK(Me.SemAmortbyStudentYearSemPKBindingSource.Position)
            frm.chargepk = .ChargeSchedPK
            frm.txtAmount.Text = FormatNumber(.Charge, 2)
            frm.txtChargeName.Text = clsTool.getChargeSchedName(.ChargeSchedPK)
            frm.txtCategory.Text = clsTool.getChargeCategory(.ChargeSchedPK)
            frm.txtRemarks.Text = clsTool.getChargeRemarks(.ChargeSchedPK)
        End With

        frm.ShowDialog()

        If frm.isDirty Then
            With Me.DsFinance.SemAmortbyStudentYearSemPK(Me.SemAmortbyStudentYearSemPKBindingSource.Position)
                .ChargeSchedPK = frm.chargepk
                .Charge = frm.txtAmount.Text

                checkDuplicate(.ChargeSchedPK)
            End With

            'update db here
            Try
                SemAmortbyStudentYearSemPKTableAdapter.Update(DsFinance.SemAmortbyStudentYearSemPK)

                SetSummaryBoxCharges()

            Catch ex As Exception
                MsgBox("Error editing miscellaneous charge. Try again." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

                clsTool.SaveErrorLog("Finalize Enrollment > Edit Misc Charge", ex.Message)
            End Try
        End If
    End Sub
    'delete misc
    Private Sub CutToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton1.Click

        If Me.DsFinance.SemAmortbyStudentYearSemPK.Rows.Count = 0 Then Exit Sub

        If MsgBox("Are you sure to remove selected Charge? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Me.DsFinance.SemAmortbyStudentYearSemPK(Me.SemAmortbyStudentYearSemPKBindingSource.Position).Delete()

            'update db here
            Try
                SemAmortbyStudentYearSemPKTableAdapter.Update(DsFinance.SemAmortbyStudentYearSemPK)

                SetSummaryBoxCharges()

            Catch ex As Exception
                MsgBox("Error deleting miscellaneous charge. Try again." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

                clsTool.SaveErrorLog("Finalize Enrollment > Delete Misc Charge", ex.Message)
            End Try

        End If

    End Sub
    'delete all misc
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        deleteMiscCharges()

        SetSummaryBoxCharges()
    End Sub

    'check for more than 1 entry of chargepk
    Private Sub checkDuplicate(ByVal thischargepk)
        If Me.DsFinance.SemAmortbyStudentYearSemPK.Rows.Count <= 0 Then Exit Sub
        Dim i As Integer
        Dim count As Integer = 0
        For i = 0 To Me.DsFinance.SemAmortbyStudentYearSemPK.Rows.Count - 1
            If Me.DsFinance.SemAmortbyStudentYearSemPK(i).ChargeSchedPK = thischargepk Then
                count += 1
            End If
        Next
        If count > 1 Then
            MsgBox("Warning. You have more than 1 entry for charge " & clsTool.getChargeSchedName(thischargepk), MsgBoxStyle.Exclamation)
        End If

    End Sub
#End Region

#Region "Finalization : White Form, Assessment, etc"

    'Student Assesment button
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssessment.Click
        If Me.m_StudentPk = -1 Then MsgBox("Please select student first") : Exit Sub

        Dim frm As New frmStudentLedger
        frm.LoadData(Me.m_StudentPk)
        frm.CrystalReportViewer1.Zoom(75)
        frm.Show()

    End Sub

    'Finalize White Form Button

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalize.Click

        'checks if a record for the student+sem+sy exists in EnrollHeader , adds one if none 
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter

        dt.Fill(ds.EnrollHeader, Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk)

        If ds.EnrollHeader.Rows.Count > 0 Then
            ds.EnrollHeader(0).remarks = Me.txtRemarks.Text
            ds.EnrollHeader(0).yrlevel = Me.txtEnrollYear.SelectedValue
        Else
            ds.EnrollHeader.AddEnrollHeaderRow(Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk, Me.txtRemarks.Text, Me.txtEnrollYear.SelectedValue)
        End If

        Try
            dt.Update(ds.EnrollHeader)

            FinalizeEnrollment()

        Catch ex As Exception

            MsgBox("An error occurred." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'sub to create the report
    'calls a class to produce the report crystalreport
    Private Sub FinalizeEnrollment()

        If Me.DsRegistrar.EnrollSubjects.Rows.Count = 0 Then MsgBox("Nothing to finalize") : Exit Sub

        'Check if at least 1 subject is enrolled
        Dim i As Integer
        Dim minimumenrolled As Boolean = False

        For i = 0 To Me.DsRegistrar.EnrollSubjects.Rows.Count - 1

            If Me.DsRegistrar.EnrollSubjects(i).RowState = DataRowState.Deleted Then
                Continue For
            End If
            
            If Me.DsRegistrar.EnrollSubjects(i).status = 1 Then
                minimumenrolled = True
                Exit For
            End If
                
        Next

        If minimumenrolled = False Then MsgBox("You should have at least 1 enrolled subject!", MsgBoxStyle.Exclamation) : Exit Sub

        'check ledger
        Dim dtx As New dsRegistrarTableAdapters.WhiteFormTableAdapter
        dtx.Fill(Me.DsRegistrar.WhiteForm, Me.txtSchoolYear.SelectedValue, Me.txtSemester.SelectedValue, Me.m_StudentPk)
        If Me.DsRegistrar.WhiteForm.Rows.Count <= 0 Then MsgBox("No Ledger Records Found! ", MsgBoxStyle.Exclamation) : Exit Sub

        'Report 
        Dim frm As New frmReportViewer
        ''frm.CrystalReportViewer1.ReportSource = clsWhiteForm.loadWhiteForm(Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk)
        frm.CrystalReportViewer1.ReportSource = clsWhiteForm2.loadWhiteForm(Me.txtSemester.SelectedValue, Me.txtSchoolYear.SelectedValue, Me.m_StudentPk)
        frm.Show()
        frm.CrystalReportViewer1.RefreshReport()
        frm.CrystalReportViewer1.Zoom(100)

        If MsgBox("Print?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frm.CrystalReportViewer1.PrintReport()
        End If

        If MsgBox("Retain print preview?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            frm.Hide()
        End If


    End Sub
    'Close Enrollment
    Private Sub btnCloseEnrollment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseEnrollment.Click

        If clsTool.GetSetting("ENROLLCLOSED").ToUpper = "TRUE" Then MsgBox("Enrollment has been closed already.") : Exit Sub

        If MsgBox("This will close the Enrollment Period. Proceed?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            clsTool.SetSetting("ENROLLCLOSED", "TRUE")

            MsgBox("ENROLLMENT CLOSED!")

        End If

    End Sub

#End Region



End Class
