Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class uTOR

    'Superceed. Modified TOR to put grading system as part of the details of the report. 12.3.2011
    'This is just a modified copy of StudentPermanentRecord
    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""
    ''Dim rep As New crTOR
    Dim rep As New crTranscriptOfRecords

    Private Sub GenRep()
        If Me.m_StudentPK = -1 Then MsgBox("Please select student first!") : Exit Sub
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        'Get all grades of Student
        Dim ds As New dsRep
        Dim dt As New dsRepTableAdapters.GradesbyStudentPKTableAdapter
        dt.Fill(ds.GradesbyStudentPK, Me.m_StudentPK)
        If ds.GradesbyStudentPK.Rows.Count <= 0 Then
            MsgBox("No grade records for that student!")
            frm.Hide()
            Exit Sub
        End If

        'Fill Template SPR in dsRep with grades of student
        Dim i As Integer
        Dim semsy As String = ""
        Dim schoolname As String = ""
        Dim gradingSystem As String = ""
        Dim rightGrade As Integer = 100
        Dim leftGrade As Single = 1.0
        Dim prevSem As Integer = 0
        Dim thisSem As Integer = 0

        For i = 0 To ds.GradesbyStudentPK.Rows.Count - 1
            Dim r As dsRep.GradesbyStudentPKRow = ds.GradesbyStudentPK(i)
            Dim subjectgroup As Integer = clsTool.GetSubjectCreditGroup(r.subjectpk)
            Dim credits As String = ""
            Dim subjcode As String = ""
            Dim subjdesc As String = ""
            Dim multipleEntry As Boolean = False
            Dim completionGrade As String = ""

            'check if subject already has a grade (other than failed) .. avoid multiple grade entries in SPR
            Dim j As Integer
            For j = 0 To ds.TOR.Rows.Count - 1
                With ds.TOR(j)
                    'For grades that are alpha or encoded via previous schools , no checking anymore for duplicate grades
                    If IsNumeric(.Grade) Then
                        If clsTool.GetSubjectCode(r.subjectpk) = .SubjectCode And CDbl(.Grade) < 5 Then
                            multipleEntry = True
                            Exit For
                        End If
                    End If
                End With
            Next

            If multipleEntry Then Continue For

            'Entries done through Subject-TeacherGrades Module
            If r.keythrough = "ENR" Then
                schoolname = clsTool.GetSetting("SNAME")
                subjcode = clsTool.GetSubjectCode(r.subjectpk)
                subjdesc = clsTool.GetSubjectName(r.subjectpk)
                If r.grade < 5 Then
                    credits = clsTool.GetSubjectUnits(r.subjectpk)
                ElseIf r.grade = 5 Then
                    credits = 0
                ElseIf r.grade = 9 Then
                    credits = 0
                Else
                    credits = 0
                End If

                'Manually encoded grades especially for grades from ex schools
                '1.25.2008 Sonny. if exSubjectDesc has value, prioritize it since SPR/TOR 
                'should list the subject name as it was called in previous school
            ElseIf r.keythrough = "MAN" Then

                schoolname = r.extSubjectID 'this is actually exSchoolName                

                If r.exSubjectDesc > "" Then
                    If r.IsexSubjectCodeNull Then r.exSubjectCode = ""
                    If r.IsexCompletionGradeNull Then r.exCompletionGrade = 0
                    subjcode = r.exSubjectCode
                    subjdesc = r.exSubjectDesc
                    credits = r.exSubjectUnits
                    subjectgroup = r.exCreditGroup
                    If r.exCompletionGrade = 0 Then completionGrade = "" Else completionGrade = r.exCompletionGrade
                Else
                    subjcode = clsTool.GetSubjectCode(r.subjectpk)
                    subjdesc = clsTool.GetSubjectName(r.subjectpk)
                    credits = clsTool.GetSubjectUnits(r.subjectpk)
                    completionGrade = ""
                End If
            End If

            'create a sorter for schoolname & semschoolyear
            'School year .. get first 4 digits of SYNAME then convert to integer
            'Then add the integer of sempk

            Dim sem As Integer = -1
            Dim semname As String = clsTool.getSEMName(r.sempk).ToUpper

            If semname.Contains("1") Or semname.Contains("FIRST") Then
                sem = 1
            ElseIf semname.Contains("2") Or semname.Contains("SECOND") Then
                sem = 2
            Else
                sem = 3
            End If

            Dim syname As String = clsTool.getSYName(r.sypk)
            Dim sorter As String = ""
            Dim syconverted As String = ""

            If syname.Length >= 4 Then 'error handling when length is less than 4
                syconverted = syname.Substring(0, 4)
            End If
            If syconverted > 0 Then
                sorter = syconverted & sem
            Else
                sorter = 1000 + sem ' 1000 is arbitrary just to make sure its before yr 2000
            End If

            'Ben 4.29.2008 . SUM should be presented as SUMMER not SUM Semester
            If sem = 1 Or sem = 2 Then
                semsy = sorter + semname + " Semester, " + syname
            Else 'Summer
                semsy = sorter + "SUMMER, " + syname
            End If

            ''semsy = sorter + semname + " Semester, " + syname
            schoolname = sorter + schoolname
            Dim grade As String = ""
            'Ben 7.31.2008
            ' We set grade either equal to r.grade (coded via ENR) or equal to r.exSubjectgrade (coded via MAN or if .grade = 0 to cover for previously encoded rows)
            Dim isPrevSchoolGrade As Boolean = False
            If r.IsisPrevSchoolGradeNull Then r.isPrevSchoolGrade = False
            If r.isPrevSchoolGrade Then
                grade = r.exSubjectGrade
            Else
                grade = r.grade
            End If


            Dim group1 As Int16 = 0
            Dim group2 As Int16 = 0
            Dim group3 As Int16 = 0
            Dim group4 As Int16 = 0
            Dim group5 As Int16 = 0
            Dim group6 As Int16 = 0
            Dim group7 As Int16 = 0
            Dim group8 As Int16 = 0
            Dim group9 As Int16 = 0
            Dim group10 As Int16 = 0

            Select Case subjectgroup
                Case 1
                    group1 = CInt(credits)
                Case 2
                    group2 = CInt(credits)
                Case 3
                    group3 = CInt(credits)
                Case 4
                    group4 = CInt(credits)
                Case 5
                    group5 = CInt(credits)
                Case 6
                    group6 = CInt(credits)
                Case 7
                    group7 = CInt(credits)
                Case 8
                    group8 = CInt(credits)
                Case 9
                    group9 = CInt(credits)
                Case 10
                    group10 = CInt(credits)
                Case Else
            End Select

            'commented out. use a new template.. 12.3.2011
            '' ''ds.StudentPermanentRecord.AddStudentPermanentRecordRow(Me.m_StudentPK, schoolname, semsy, subjcode, _
            '' ''  subjdesc, grade, completionGrade, credits, group1, group2, group3, group4, group5, group6, group7, group8, group9, group10)

            If rightGrade = 74 Then

                gradingSystem = "5.0  -  FAILED"
                rightGrade -= 1
                leftGrade += 0.1
            ElseIf rightGrade = 73 Then
                ''RESET COUNTER HERE
                gradingSystem = "9.0  -  DROPPED"
                rightGrade = 100
                leftGrade = 1.0
            Else
                gradingSystem = FormatNumber(leftGrade, 1) & "  -  " & rightGrade.ToString
                rightGrade -= 1
                leftGrade += 0.1
            End If

            ''Semester Group Header Handler
            thisSem = r.Sorter  'Semsorter 1,2,3

            If thisSem <> prevSem Then
                'just add header rows
                ds.TOR.AddTORRow(gradingSystem, Me.m_StudentPK, "", "", "BOLD", schoolname, "", "", "")

                'adjust grading system less 1
                rightGrade -= 1
                leftGrade += 0.1
                gradingSystem = FormatNumber(leftGrade, 1) & "  -  " & rightGrade.ToString

                ds.TOR.AddTORRow(gradingSystem, Me.m_StudentPK, "", "", "BOLD", semsy, "", "", "")

            Else
                ds.TOR.AddTORRow(gradingSystem, Me.m_StudentPK, schoolname, semsy, subjcode, _
             subjdesc, grade, completionGrade, credits)

            End If

            prevSem = thisSem

        Next

        rep.SetDataSource(ds)
        rep.SetParameterValue("STUDENT", Me.m_StudentName)
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))

        Dim salute As String = ""
        If clsTool.getStudentSex(Me.m_StudentPK) = "Male" Then
            salute = "Mr."
        Else
            salute = "Ms."
        End If

        rep.SetParameterValue("SALUTE", salute)
        rep.SetParameterValue("SEX", clsTool.getStudentSex(Me.m_StudentPK))
        rep.SetParameterValue("BDAY", clsTool.getStudentBday(Me.m_StudentPK))
        rep.SetParameterValue("ADDRESS", clsTool.getStudentAddress(Me.m_StudentPK))
        rep.SetParameterValue("BIRTHPLACE", clsTool2.getBirthPlace(Me.m_StudentPK))
        rep.SetParameterValue("COLLEGE", clsTool2.getGradCollege(Me.m_StudentPK))
        rep.SetParameterValue("REMARKS", Me.txtRemarksPurpose.Text.ToUpper)
        rep.SetParameterValue("ELEM", clsTool2.getElem(Me.m_StudentPK) + "    " + clsTool2.getElemYear(Me.m_StudentPK))
        rep.SetParameterValue("HISCHOOL", clsTool2.getHS(Me.m_StudentPK) + "    " + clsTool2.getHSYear(Me.m_StudentPK))
        rep.SetParameterValue("CONCENTRATION", clsTool2.getGradConcentration(Me.m_StudentPK))
        rep.SetParameterValue("DEGREE", clsTool2.getGradCourse(Me.m_StudentPK))
        rep.SetParameterValue("GRADDATE", Convert.ToDateTime(clsTool2.getGradDate(Me.m_StudentPK)))
        rep.SetParameterValue("REGISTRAR", clsTool.GetSetting("REGISTRAR"))
        rep.SetParameterValue("PRESIDENT", clsTool.GetSetting("PRESIDENT"))
        rep.SetParameterValue("SAO", Me.txtSAO.Text.ToUpper)
        rep.SetParameterValue("SHOWREMARKSGRADUATED", Me.chkShowGraduatedRemarks.Checked)
        rep.SetParameterValue("REMARKSGRADUATED", Me.txtRemarksGraduated.Text)

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()


        frm.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GenRep()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.m_StudentName = frm.m_StudentName
            TextBox1.Text = frm.m_StudentName
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub

    Private Sub uTOR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.chkShowGraduatedRemarks.Checked = True
        Me.txtRemarksGraduated.Text = "From the four year course Nursing leading to the degree of " _
               & " Bachelor of Science in Nursing (BSN) as of " & Now.Date.Date & ". As per special order no. " _
               & " 50-501200-70 s. 2006 dated May 8, 2006. "

        Me.txtSAO.Text = clsTool.GetSetting("SAO")

    End Sub
End Class
