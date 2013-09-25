Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class uStudentPermanentRecord

    'ben10.18.2007  Created this class

    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""
    Dim rep As New crStudentPermanentRecord


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

        REM initialize the currentSchoolName and previousSchoolName 
        REM this is the control to set the schoolnamesorter
        Dim currentSchoolName = ""
        Dim previousSchoolName = ""
        Dim schoolnamesorter As Integer = 0

        For i = 0 To ds.GradesbyStudentPK.Rows.Count - 1

            Dim r As dsRep.GradesbyStudentPKRow = ds.GradesbyStudentPK(i)
            Dim subjectgroup As Integer = clsTool.GetSubjectCreditGroup(r.subjectpk)
            Dim schoolname As String = ""
            Dim credits As String = ""
            Dim subjcode As String = ""
            Dim subjdesc As String = ""
            Dim multipleEntry As Boolean = False
            Dim completiongrade As String = ""

            'check if subject already has a grade (other than failed) .. avoid multiple grade entries in SPR
            Dim j As Integer
            For j = 0 To ds.StudentPermanentRecord.Rows.Count - 1
                With ds.StudentPermanentRecord(j)
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


                
            ElseIf r.keythrough = "MAN" Then
                'Manually encoded grades especially for grades from ex schools
                '1.25.2008 Sonny. if exSubjectDesc has value, prioritize it since SPR/TOR 
                'should list the subject name as it was called in previous school
                schoolname = r.extSubjectID 'this is actually exSchoolName                

                If r.exSubjectDesc > "" Then
                    If r.IsexSubjectCodeNull Then r.exSubjectCode = ""
                    If r.IsexCompletionGradeNull Then r.exCompletionGrade = 0
                    subjcode = r.exSubjectCode
                    subjdesc = r.exSubjectDesc
                    credits = r.exSubjectUnits
                    subjectgroup = r.exCreditGroup
                    If r.exCompletionGrade = 0 Then completiongrade = "" Else completiongrade = r.exCompletionGrade
                Else
                    subjcode = clsTool.GetSubjectCode(r.subjectpk)
                    subjdesc = clsTool.GetSubjectName(r.subjectpk)
                    credits = clsTool.GetSubjectUnits(r.subjectpk)
                    completiongrade = ""
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

            If syconverted > "" Then
                sorter = syconverted & sem
            Else
                sorter = 1000 + sem ' 1000 is arbitrary just to make sure its before yr 2000
            End If


            Dim semsy As String = ""
            'Ben 4.29.2008 . SUM should be presented as SUMMER not SUM Semester
            If sem = 1 Or sem = 2 Then
                semsy = sorter + semname + " Semester, " + syname
            Else 'Summer
                semsy = sorter + "SUMMER, " + syname
            End If

            REM 2.7.2012. Dont put the sem as sorter for the school name
            REM so that the group header in the report will not print for same school names per sem
            ''schoolname = sorter + schoolname

            If Not schoolname = previousSchoolName Then
                schoolnamesorter += 1
                previousSchoolName = schoolname
            End If

            schoolname = schoolnamesorter & schoolname

            Dim grade As String = ""
            'Ben 7.31.2008
            ' We set grade either equal to r.grade (coded via ENR) or equal to r.exSubjectgrade (coded via MAN or if .grade = 0 to cover for previously encoded rows)
            ' before coding this, the previous school grades were all numeric and encoded in field grade which is numeric
            ' as of this coding , we now save previous school grades into field ExSubjectGrade and set isPrevSchoolGrade to True
            ' so if isPrevSchoolGradeNull then that means it was saved previous to coding
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

            ds.StudentPermanentRecord.AddStudentPermanentRecordRow(Me.m_StudentPK, schoolname, semsy, subjcode, _
              subjdesc, grade, completiongrade, credits, group1, group2, group3, group4, group5, group6, group7, group8, group9, group10)

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
        rep.SetParameterValue("REMARKS", "FOR CHED ONLY")
        rep.SetParameterValue("ELEM", clsTool2.getElem(Me.m_StudentPK) + "    " + clsTool2.getElemYear(Me.m_StudentPK))
        rep.SetParameterValue("HISCHOOL", clsTool2.getHS(Me.m_StudentPK) + "    " + clsTool2.getHSYear(Me.m_StudentPK))
        rep.SetParameterValue("CONCENTRATION", clsTool2.getGradConcentration(Me.m_StudentPK))
        rep.SetParameterValue("DEGREE", clsTool2.getGradCourse(Me.m_StudentPK))
        Dim graddate As Date = "1/1/1900"
        If IsDate(clsTool2.getGradDate(Me.m_StudentPK)) Then graddate = CDate(clsTool2.getGradDate(Me.m_StudentPK))
        rep.SetParameterValue("GRADDATE", graddate)
        rep.SetParameterValue("REGISTRAR", clsTool.GetSetting("REGISTRAR"))

        Me.CrystalReportViewer1.ReportSource = rep
        Me.CrystalReportViewer1.RefreshReport()


        frm.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GenRep()
    End Sub

  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStudentSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_StudentPK = frm.m_StudentPK
            Me.M_StudentName = frm.m_StudentName
            TextBox1.Text = frm.m_StudentName
            GenRep()
        End If
    End Sub


    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        e.Handled = True
    End Sub
End Class
