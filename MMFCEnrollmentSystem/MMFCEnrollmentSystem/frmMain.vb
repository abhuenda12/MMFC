
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain

#Region "Variables"
    REM Management userControls
    Dim uCurrentSchoolYear As uCurrentSchoolyear
    Dim uSchoolYear As uSchoolYear
    Dim uCourses As uCourses
    Dim uSubjects As uSubjects
    Dim uTeachers As uTeachers
    Dim uSchoolResources As uSchoolResources
    Dim uSYOffering As uSYOffering
    Dim uSummary As uSummary
    Dim uCurriculum As uCurriculum
    Dim uSemester As uSemester
    Dim uChargeSchedule As uChargeSchedule
    Dim uTRTypes As uTRTypes

    '*** Registrar Modules
    '***
    Dim uEnrollSubject As uEnrollSubject
    Dim uFinalizeEnrollment As uFinalizeEnrollment
    Dim uGradesSubjectTeacher As uGradesSubjectTeacher
    Dim uStudentGrades As uStudentGrades
    Dim uGradeTransferee As uGradeTransferee
    Dim uTeacherLoad As uTeacherLoad
    Dim uResourceLoad As uResourceLoad

    Dim UserName As String = ""
    Dim FullUserName As String = ""

    Dim uStudents As uStudents
    ''

    ''
    ''Dim uReport As uReport

    ''Dim uChargesbyCourse As uChargesbyCourse

    ' ''Ben 10.3.2007 . Replaced with uEnrollment (has a nevron grouper)
    '' ''Dim uEnroll As uEnroll
    ''Dim uEnrollment As uEnrollment
    ''
    ''Dim uPreferrences As uPreferrences
    ''
    ''Dim uMain As uMain
    ''Dim uSubjectLoad As uSubjectLoad

    '*** FINANCE MODULES
    '***
    Dim uReceipts As uReceipts
    Dim uAdjustments As uAdjustments
    Dim uReceiptReprint As uReceiptReprint
    Dim uReceiptCancel As uReceiptCancel
    Dim uStudentLedger As uStudentLedger
    Dim uTutorial As uTutorial
    Dim uStudentPermit As uStudentPermit


    ''Dim uUsers As uUsers
    Dim uReceiptsListing As uReceiptsListing
    Dim uSyOfferingRep As uSyOfferingRep
    Dim uClassList As uClassList
    Dim uEnrollmentList As uEnrollmentList

    Dim uWhiteForm As uWhiteForm
    Dim uReceivables As uReceivables

    Dim uStudentsReport As uStudentsReport

    Dim uCollegiateGrade As uCollegiateGrade
    Dim uPromotionalReport As uPromotionalReport
    Dim uGradesMailingList As uGradesMailingList
    Dim uStudentPermanentRecord As uStudentPermanentRecord
    Dim uStatistics As uStatistics
    Dim uStudentSchedule As uStudentSchedule
    Dim uClassCard As uClassCard
    
    Dim uEvaluationReport As uEvaluationReport
    Dim uCollections As uCollections
    Dim uCollectionsBreakdown As uCollectionsBreakdown
    
    Dim uTOR As uTOR
    Dim uStatementofAccount As uStatementofAccount
    
 

    ''Dim uMgt As Boolean = False
    ''Dim uReg As Boolean = False
    ''Dim uFin As Boolean = False
    ''Dim uRep As Boolean = False
    ''Dim uSys As Boolean = False

#End Region

#Region "Main Events"
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sqlcon As New SqlConnection
        sqlcon.ConnectionString = My.Settings.mmfcdbConnectionString

        Try
            Application.DoEvents()
            sqlcon.Open()
        Catch ex As Exception

            MsgBox("Connection to SQL Server failed!")
            Exit Sub
        End Try

        Dim frmSplash As New frmSplash
        frmSplash.Show()
        Application.DoEvents()
        System.Threading.Thread.Sleep(3000)
        frmSplash.Hide()

        Dim flogin As New frmLogin
        Dim uName As String = ""
        Dim Password As String
        ''flogin.Top = Me.Height - flogin.Height - 20
        ''flogin.Left = Me.Width - flogin.Width - 20
        While True
            flogin.ShowDialog()
            uName = flogin.UsernameTextBox.Text
            Password = flogin.PasswordTextBox.Text
            If clsTool.uLogin(uName, Password) Then
                UserName = uName
                FullUserName = clsTool.uLoginFullUserName(uName, Password)

                SQLStatement = "SELECT TOP 1 isnull(uid,-1) FROM AppUsers WHERE username = '" & uName & "' And  Password = '" & Password & "'"

                Dim resultid As String = clsTool.getDBValue(SQLStatement)

                If Not String.IsNullOrEmpty(resultid) Then
                    loggedUserID = resultid
                End If

                Exit While
            Else
                MsgBox("Invalid User Login!")
            End If
        End While

        uSummary = New uSummary
        uSummary.LoadSummary()
        SetContainer(uSummary)

        'now run auto Student Type setter 
        REM only run this on a button click since users change curYear and curSem 
        ''AutoSetStudentTypeToOld()

    End Sub

    Sub SetContainer(ByVal u As UserControl)
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(u)
        u.Dock = DockStyle.Fill
    End Sub

    'sub to auto set the Student Type . If student has enrolled previous sems, set him to OLD
    Public Sub AutoSetStudentTypeToOld()
        Dim strSQL As String = "UPDATE students SET studentType = 'OLD' WHERE " _
         & "studentType NOT IN ( 'OLD' , 'CROSS-ENROLLED')  " _
        & "AND studentPK  IN" _
        & "( " _
        & "select distinct studentpk from enrollheader where " _
         & " ( yearpk <> ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) )  " _
          & " OR ( yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) AND sempk <> (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem'  ) ) " _
        & ") " _
        & " AND studentPK IN " _
        & " (  " _
        & "	select distinct studentpk from enrollsubjects where " _
        & "  ( yearpk <> ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) ) " _
        & " OR ( yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) and sempk <> (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem' ) ) " _
        & "  and status = 1 " _
        & ") "


        clsTool.runDBSQL(strSQL)

    End Sub

#End Region

#Region "Menu Events - Management"

    'Active Semester
    Private Sub NavBarItem1_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        If uCurrentSchoolYear Is Nothing Then uCurrentSchoolYear = New uCurrentSchoolyear
        SetContainer(uCurrentSchoolYear)
    End Sub

    'School Year
    Private Sub NavBarItem8_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem8.LinkClicked
        If uSchoolYear Is Nothing Then uSchoolYear = New uSchoolYear
        SetContainer(uSchoolYear)
    End Sub

    'Courses
    Private Sub NavBarItem3_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        If uCourses Is Nothing Then uCourses = New uCourses
        SetContainer(uCourses)
    End Sub

    'Subjects
    Private Sub NavBarItem6_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem6.LinkClicked
        If uSubjects Is Nothing Then uSubjects = New uSubjects
        SetContainer(uSubjects)
    End Sub

    'Teachers
    Private Sub NavBarItem5_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        If uTeachers Is Nothing Then uTeachers = New uTeachers
        SetContainer(uTeachers)
    End Sub
    'School Resources
    Private Sub NavBarItem7_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem7.LinkClicked
        If uSchoolResources Is Nothing Then uSchoolResources = New uSchoolResources
        SetContainer(uSchoolResources)
    End Sub
    'School Year Offering
    Private Sub NavBarItem2_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        If uSYOffering Is Nothing Then uSYOffering = New uSYOffering
       
        SetContainer(uSYOffering)
        uSYOffering.dLoad()
    End Sub

    'Curriculum
    Private Sub NavBarItem4_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        If uCurriculum Is Nothing Then uCurriculum = New uCurriculum
        SetContainer(uCurriculum)
    End Sub

    'Semester
    Private Sub NavBarItem9_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem9.LinkClicked
        If uSemester Is Nothing Then uSemester = New uSemester
        SetContainer(uSemester)
    End Sub
    'Charge Schedule
    Private Sub NavBarItem10_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem10.LinkClicked

        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()
        If frmPassword.isDirty Then
            If uChargeSchedule Is Nothing Then uChargeSchedule = New uChargeSchedule
            SetContainer(uChargeSchedule)
            uChargeSchedule.LoadData()
        Else
            MsgBox("NOT ALLOWED TO EDIT CHARGE SCHEDULE.")
        End If

        If uChargeSchedule Is Nothing Then uChargeSchedule = New uChargeSchedule
        SetContainer(uChargeSchedule)
        uChargeSchedule.LoadData()
    End Sub

    'Transaction Types
    Private Sub NavBarItem11_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem11.LinkClicked
        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()
        If frmPassword.isDirty Then
            If uTRTypes Is Nothing Then uTRTypes = New uTRTypes
            SetContainer(uTRTypes)
        Else
            MsgBox("NOT ALLOWED TO EDIT SUBJECT CHARGES.")
        End If

        If uTRTypes Is Nothing Then uTRTypes = New uTRTypes
        SetContainer(uTRTypes)
    End Sub
#End Region

#Region "Menu Events - Registrar"

    'Register Student
    Private Sub NavBarItem12_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem12.LinkClicked
        If uStudents Is Nothing Then uStudents = New uStudents
        SetContainer(uStudents)
    End Sub

    'Enroll Student Subjects
    Private Sub NavBarItem13_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem13.LinkClicked
        If uEnrollSubject Is Nothing Then
            uEnrollSubject = New uEnrollSubject
            uEnrollSubject.InitForm()
        End If
        SetContainer(uEnrollSubject)
    End Sub

    'Finalize Enrollment
    Private Sub NavBarItem49_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem49.LinkClicked
        If uFinalizeEnrollment Is Nothing Then
            uFinalizeEnrollment = New uFinalizeEnrollment
            uFinalizeEnrollment.InitializeForm()
        End If
        SetContainer(uFinalizeEnrollment)
    End Sub

    'Encode Student Grades by SY offering
    Private Sub NavBarItem14_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem14.LinkClicked
        Dim frmPassword As New frmAdminPassword
        frmPassword.ShowDialog()
        If frmPassword.isDirty Then
            If uGradesSubjectTeacher Is Nothing Then uGradesSubjectTeacher = New uGradesSubjectTeacher
            uGradesSubjectTeacher.Initialize()
            SetContainer(uGradesSubjectTeacher)
        Else
            MsgBox("NOT ALLOWED TO EDIT GRADES!")
        End If
    End Sub

    'Encode Transferee Grades
    Private Sub NavBarItem15_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem15.LinkClicked
        If uGradeTransferee Is Nothing Then uGradeTransferee = New uGradeTransferee
        uGradeTransferee.Initialize()
        SetContainer(uGradeTransferee)
    End Sub

    'Encode Student Grades manually
    Private Sub NavBarItem50_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem50.LinkClicked

        If uStudentGrades Is Nothing Then uStudentGrades = New uStudentGrades
        uStudentGrades.Initialize()
        SetContainer(uStudentGrades)
    End Sub

    'Teachers Load
    Private Sub NavBarItem17_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem17.LinkClicked
        If uTeacherLoad Is Nothing Then uTeacherLoad = New uTeacherLoad
        SetContainer(uTeacherLoad)

    End Sub

    'Resource Load
    Private Sub NavBarItem18_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem18.LinkClicked
        If uResourceLoad Is Nothing Then uResourceLoad = New uResourceLoad
        SetContainer(uResourceLoad)
    End Sub

#End Region

#Region "Menu Events - Reports"

    'Class Card
    Private Sub NavBarItem27_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem27.LinkClicked

        If uClassCard Is Nothing Then uClassCard = New uClassCard
        SetContainer(uClassCard)
        uClassCard.LoadData()

    End Sub

    'Class List
    Private Sub NavBarItem28_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem28.LinkClicked

        If uClassList Is Nothing Then uClassList = New uClassList
        SetContainer(uClassList)
        uClassList.LoadData()

    End Sub

    'Collections Report
    Private Sub NavBarItem29_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem29.LinkClicked

        If uCollections Is Nothing Then uCollections = New uCollections
        SetContainer(uCollections)
        uCollections.LoadData()

    End Sub

    'Collections Report (Breakdown)
    Private Sub NavBarItem30_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem30.LinkClicked

        If uCollectionsBreakdown Is Nothing Then uCollectionsBreakdown = New uCollectionsBreakdown
        SetContainer(uCollectionsBreakdown)
        uCollectionsBreakdown.LoadData()

    End Sub

    'Collegiate Grading Sheet
    Private Sub NavBarItem31_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem31.LinkClicked

        If uCollegiateGrade Is Nothing Then uCollegiateGrade = New uCollegiateGrade
        SetContainer(uCollegiateGrade)
        uCollegiateGrade.LoadData()

    End Sub

    'Enrollment List
    Private Sub NavBarItem32_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem32.LinkClicked

        If uEnrollmentList Is Nothing Then uEnrollmentList = New uEnrollmentList
        SetContainer(uEnrollmentList)
        uEnrollmentList.LoadData()

    End Sub

    'Enrollment Statistics
    Private Sub NavBarItem33_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem33.LinkClicked

        If uStatistics Is Nothing Then uStatistics = New uStatistics
        SetContainer(uStatistics)
        uStatistics.LoadData()

    End Sub

    'Evaluation Report
    Private Sub NavBarItem34_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem34.LinkClicked

        If uEvaluationReport Is Nothing Then uEvaluationReport = New uEvaluationReport
        SetContainer(uEvaluationReport)
        uEvaluationReport.LoadData()

    End Sub

    'Grades for Mailing
    Private Sub NavBarItem35_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem35.LinkClicked

        If uGradesMailingList Is Nothing Then uGradesMailingList = New uGradesMailingList
        SetContainer(uGradesMailingList)
        uGradesMailingList.LoadData()

    End Sub

    'Promotional Report
    Private Sub NavBarItem36_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem36.LinkClicked

        If uPromotionalReport Is Nothing Then uPromotionalReport = New uPromotionalReport
        SetContainer(uPromotionalReport)
        uPromotionalReport.LoadData()

    End Sub

    'Receipts Listing
    Private Sub NavBarItem37_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem37.LinkClicked

        If uReceiptsListing Is Nothing Then uReceiptsListing = New uReceiptsListing
        SetContainer(uReceiptsListing)

    End Sub

    'Receivables
    Private Sub NavBarItem38_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem38.LinkClicked

        If uReceivables Is Nothing Then uReceivables = New uReceivables
        SetContainer(uReceivables)
        uReceivables.LoadData()

    End Sub

    'Current School Year Offering
    Private Sub NavBarItem39_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem39.LinkClicked

        If uSyOfferingRep Is Nothing Then uSyOfferingRep = New uSyOfferingRep
        SetContainer(uSyOfferingRep)
        uSyOfferingRep.LoadData()

    End Sub

    'Statement of Account
    Private Sub NavBarItem40_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem40.LinkClicked

        If uStatementofAccount Is Nothing Then uStatementofAccount = New uStatementofAccount
        SetContainer(uStatementofAccount)

    End Sub

    'Student Permanent Record
    Private Sub NavBarItem41_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem41.LinkClicked

        If uStudentPermanentRecord Is Nothing Then uStudentPermanentRecord = New uStudentPermanentRecord
        SetContainer(uStudentPermanentRecord)

    End Sub

    'Student Reports
    Private Sub NavBarItem42_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem42.LinkClicked

        If uStudentsReport Is Nothing Then uStudentsReport = New uStudentsReport
        SetContainer(uStudentsReport)
        uStudentsReport.LoadData()

    End Sub

    'Student Schedule
    Private Sub NavBarItem43_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem43.LinkClicked

        If uStudentSchedule Is Nothing Then uStudentSchedule = New uStudentSchedule
        SetContainer(uStudentSchedule)
        uStudentSchedule.LoadData()

    End Sub

    'Transcript of Records
    Private Sub NavBarItem44_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem44.LinkClicked

        If uTOR Is Nothing Then uTOR = New uTOR
        SetContainer(uTOR)

    End Sub

    'White Form
    Private Sub NavBarItem45_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem45.LinkClicked

        If uWhiteForm Is Nothing Then uWhiteForm = New uWhiteForm
        SetContainer(uWhiteForm)
        uWhiteForm.LoadData()

    End Sub

#End Region

#Region "Menu Events - Finance"

    'Receipts / Payments
    Private Sub NavBarItem20_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem20.LinkClicked
        If uReceipts Is Nothing Then uReceipts = New uReceipts
        SetContainer(uReceipts)
        uReceipts.LoadData()
        uReceipts.NewDoc()
        uReceipts.tellername = FullUserName

    End Sub

    'Receipts Reprint
    Private Sub NavBarItem21_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem21.LinkClicked
        If uReceiptReprint Is Nothing Then
            uReceiptReprint = New uReceiptReprint
            uReceiptReprint.NewDoc()
            uReceiptReprint.tellername = FullUserName
        End If

        SetContainer(uReceiptReprint)
    End Sub

    'REceipt Cancellation
    Private Sub NavBarItem22_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem22.LinkClicked
        If uReceiptCancel Is Nothing Then
            uReceiptCancel = New uReceiptCancel
            uReceiptCancel.NewDoc()
            uReceiptCancel.tellername = FullUserName
        End If

        SetContainer(uReceiptCancel)
    End Sub
    'Adjustments / Student Ledger Adjustments / Writeoffs
    Private Sub NavBarItem23_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem23.LinkClicked
        If uAdjustments Is Nothing Then uAdjustments = New uAdjustments
        SetContainer(uAdjustments)
    End Sub
    'Student Ledger Report
    Private Sub NavBarItem24_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem24.LinkClicked
        If uStudentLedger Is Nothing Then uStudentLedger = New uStudentLedger
        SetContainer(uStudentLedger)
    End Sub

    'Student Permit Print out
    Private Sub NavBarItem25_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem25.LinkClicked
        If uStudentPermit Is Nothing Then uStudentPermit = New uStudentPermit
        SetContainer(uStudentPermit)
        uStudentPermit.loadData()
    End Sub
    'Tutorial Subjects 
    Private Sub NavBarItem26_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem26.LinkClicked
        If uTutorial Is Nothing Then uTutorial = New uTutorial
        SetContainer(uTutorial)
        uTutorial.loadData()
    End Sub

#End Region

   
End Class