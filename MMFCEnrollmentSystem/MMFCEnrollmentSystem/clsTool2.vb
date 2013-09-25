Public Class clsTool2
    ''takes in a grade, for those with decimal like  2.80 , 
    ''it will return back 2.8 , take out the trailing zeros in the decimal portion
    Public Shared Function formatGrade(ByVal inputGrade As String) As String
        If IsNumeric(inputGrade) Then
            If Math.Floor(CDbl(inputGrade)) = CDbl(inputGrade) Then
                'for those with no decimal
                Return CInt(inputGrade).ToString()
            Else
                'has a decimal, multiply by 10 and get floor then put this back to decimal
                Dim decimalValue As Double = CDbl(inputGrade) - Math.Floor(CDbl(inputGrade))
                decimalValue *= 10
                Dim outputGrade As String = Convert.ToString(Math.Floor(CDbl(inputGrade))) & "." & decimalValue.ToString()

                Return outputGrade
            End If
        End If
        Return inputGrade
    End Function

    Public Shared Function getElem(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        'If ds.StudentsbyPK(0).Edubackground1 Then ds.StudentsbyPK(0).NumOf = 0
        Return ds.StudentsbyPK(0).Edubackground1
    End Function

    Public Shared Function getHS(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        'If ds.StudentsbyPK(0).Edubackground1 Then ds.StudentsbyPK(0).NumOf = 0
        Return ds.StudentsbyPK(0).Edubackground2
    End Function

    Public Shared Function getElemYear(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        'If ds.StudentsbyPK(0).Edubackground1 Then ds.StudentsbyPK(0).NumOf = 0
        Return ds.StudentsbyPK(0).Edubackgrounddate1
    End Function

    Public Shared Function getHSYear(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        'If ds.StudentsbyPK(0).Edubackground1 Then ds.StudentsbyPK(0).NumOf = 0
        Return ds.StudentsbyPK(0).Edubackgrounddate2
    End Function
    'ben10.19.2007
    Public Shared Function getGradDate(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        If ds.StudentsbyPK(0).IsgradDateNull Then Return ""
        Return ds.StudentsbyPK(0).gradDate
    End Function
    'ben10.19.2007
    Public Shared Function getGradCollege(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        If ds.StudentsbyPK(0).IsgradCollegeNull Then Return ""
        Return ds.StudentsbyPK(0).gradCollege
    End Function
    'ben10.19.2007
    Public Shared Function getGradConcentration(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        If ds.StudentsbyPK(0).IsgradConcentrationNull Then Return ""
        Return ds.StudentsbyPK(0).gradConcentration
    End Function
    'ben10.19.2007
    Public Shared Function getGradCourse(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        If ds.StudentsbyPK(0).IsgradCourseNull Then Return ""
        Return ds.StudentsbyPK(0).gradCourse
    End Function
    'ben1.30.2008
    Public Shared Function checkIfStudent2ndcourser(ByVal studentpk As Integer) As Boolean
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, studentpk)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return False
        If ds.StudentsbyPK(0).IsSecondCourserNull Then Return False
        Return ds.StudentsbyPK(0).SecondCourser
    End Function


    Public Shared Function getBirthPlace(ByVal student As Integer) As String
        Dim ds As New dsReg2
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, student)
        If ds.StudentsbyPK.Rows.Count = 0 Then Return ""
        If ds.StudentsbyPK(0).IsbirthplaceNull Then ds.StudentsbyPK(0).birthplace = ""
        Return ds.StudentsbyPK(0).birthplace
    End Function
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Shared Function getPreReqNum(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return 0
        If ds.SubjectsByPreReq(0).IsNumOfPreReqNull Then ds.SubjectsByPreReq(0).NumOfPreReq = 0
        Return ds.SubjectsByPreReq(0).NumOfPreReq
    End Function

    Public Shared Function getSubjectPrereq2(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq2Null Then ds.SubjectsByPreReq(0).prereq2 = -1
        Return ds.SubjectsByPreReq(0).prereq2
    End Function

    Public Shared Function getSubjectPrereq3(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq3Null Then ds.SubjectsByPreReq(0).prereq3 = -1
        Return ds.SubjectsByPreReq(0).prereq3
    End Function

    Public Shared Function getSubjectPrereq4(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq4Null Then ds.SubjectsByPreReq(0).prereq4 = -1
        Return ds.SubjectsByPreReq(0).prereq4
    End Function

    Public Shared Function getSubjectPrereq5(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq5Null Then ds.SubjectsByPreReq(0).prereq5 = -1
        Return ds.SubjectsByPreReq(0).prereq5
    End Function

    Public Shared Function getSubjectPrereq6(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq6Null Then ds.SubjectsByPreReq(0).prereq6 = -1
        Return ds.SubjectsByPreReq(0).prereq6
    End Function

    Public Shared Function getSubjectPrereq7(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPreReqTableAdapter
        dt.Fill(ds.SubjectsByPreReq, subject)
        If ds.SubjectsByPreReq.Rows.Count = 0 Then Return -1
        If ds.SubjectsByPreReq(0).Isprereq7Null Then ds.SubjectsByPreReq(0).prereq7 = -1
        Return ds.SubjectsByPreReq(0).prereq7
    End Function
    'ben1.25.2008
    Public Shared Function getTeacherPKbyName(ByVal teachername As String) As Integer

        Dim ds As New dsSchool.TeachersbyCNameDataTable
        Dim dt As New dsSchoolTableAdapters.TeachersbyCNameTableAdapter
        dt.Fill(ds, "%" & teachername & "%")

        If ds.Rows.Count <= 0 Then MsgBox("No teachers found.") : Return -1
        If ds.Rows.Count = 1 Then Return ds(0).TeacherPriKey
        If ds.Rows.Count > 1 Then
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                If MsgBox("You want to choose " & ds(i).Name & "  ?", MsgBoxStyle.YesNo, _
                               "Multiple Records Match") = MsgBoxResult.Yes Then

                    Return ds(i).TeacherPriKey
                Else
                    Continue For
                End If
            Next
        End If
        Return -1
    End Function
    'ben1.25.2008 . To get ex colleges of student and choose from the list
    Public Shared Function getExCollegeName(ByVal studentpk As Integer) As String

        Dim ds As New dsReg2.StudentsbyPKDataTable
        Dim dt As New dsReg2TableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds, studentpk)

        If ds.Rows.Count <= 0 Then Return ""

        If ds(0).IsEdubackground5Null Then ds(0).Edubackground5 = ""
        If ds(0).IsEdubackground6Null Then ds(0).Edubackground6 = ""

        'Excollege1
        If ds(0).Edubackground3 > "" Then
            If MsgBox("You want to choose " & ds(0).Edubackground3 & "  ?", MsgBoxStyle.YesNo, _
                           "Multiple Records Match") = MsgBoxResult.Yes Then
                Return ds(0).Edubackground3
            End If
        End If
        'Excollege2
        If ds(0).Edubackground4 > "" Then
            If MsgBox("You want to choose " & ds(0).Edubackground4 & "  ?", MsgBoxStyle.YesNo, _
                           "Multiple Records Match") = MsgBoxResult.Yes Then
                Return ds(0).Edubackground4
            End If
        End If
        'Excollege3
        If ds(0).Edubackground5 > "" Then
            If MsgBox("You want to choose " & ds(0).Edubackground5 & "  ?", MsgBoxStyle.YesNo, _
                           "Multiple Records Match") = MsgBoxResult.Yes Then
                Return ds(0).Edubackground5
            End If
        End If
        'Excollege4
        If ds(0).Edubackground6 > "" Then
            If MsgBox("You want to choose " & ds(0).Edubackground6 & "  ?", MsgBoxStyle.YesNo, _
                           "Multiple Records Match") = MsgBoxResult.Yes Then
                Return ds(0).Edubackground6
            End If
        End If

        'More Previous Schools Table
        Dim ds2 As New dsReg2.PreviousSchoolsByStudentPKDataTable
        Dim dt2 As New dsReg2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
        dt2.Fill(ds2, studentpk)
        If ds2.Rows.Count <= 0 Then Return ""

        Dim i As Integer
        For i = 0 To ds2.Rows.Count - 1
            If MsgBox("You want to choose " & ds2(i).SchoolName & "  ?", MsgBoxStyle.YesNo, _
                           "Multiple Records Match") = MsgBoxResult.Yes Then
                Return ds2(i).SchoolName
            End If
        Next

        Return ""
    End Function

    '1.27.2008 . To test if a subjectPK has been enrolled by student
    Public Shared Function testIfSubjectEnrolled(ByVal subjectpk As Integer, ByVal studentpk As Integer, _
                                        ByVal sempk As Integer, ByVal sypk As Integer) As Boolean

        Dim ds As New dsRegistrar.EnrollSubjectsDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds, sypk, sempk, studentpk)
        If ds.Rows.Count <= 0 Then Return False
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).status = 1 Then
                If ds(i).subjectpk = subjectpk Then Return True
            End If
        Next
        Return False
    End Function

    '1.27.2008 . To test if a subjectCODE has been enrolled by student
    Public Shared Function testIfSubjectCodeEnrolled(ByVal subjectcode As String, ByVal studentpk As Integer, _
                                        ByVal sempk As Integer, ByVal sypk As Integer) As Boolean

        Dim ds As New dsRegistrar.EnrollSubjectsDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds, sypk, sempk, studentpk)
        If ds.Rows.Count <= 0 Then Return False
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).status = 1 Then
                If clsTool.GetSubjectCode(ds(i).subjectpk).ToUpper.Contains(subjectcode) Then Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function getSurname(ByVal studentname As String) As String
        'format of student name is SURNAME, FIRSTNAME  MI  
        'ends at index of comma 
        Dim surname As String = ""
        If Not studentname.Contains(",") Then Return studentname
        Dim indexofcomma As Integer = studentname.IndexOf(",")
        surname = studentname.Substring(0, indexofcomma)
        Return surname
    End Function

    Public Shared Function getFirstname(ByVal studentname As String) As String
        'format of student name is SURNAME, FIRSTNAME  MI  
        'starts at index of comma + 1 .. for now we include everything after the comma since theres no exact format of encoding middle name
        Dim firstname As String = ""
        If Not studentname.Contains(",") Then Return studentname
        Dim indexofcomma As Integer = studentname.IndexOf(",")
        Dim indexof2ndcomma As Integer = studentname.LastIndexOf(",")
        Dim lengthfirstname As Integer = 0
        If indexofcomma = indexof2ndcomma Then
            firstname = studentname.Substring(indexofcomma + 1)
        Else
            lengthfirstname = indexof2ndcomma - indexofcomma
            firstname = studentname.Substring(indexofcomma + 1, lengthfirstname)
        End If

        Return firstname
    End Function
    'Ben 5.19.2008
    Public Shared Function getMiddleName(ByVal studentname As String) As String
        'format of student name is SURNAME, FIRSTNAME ,MI          
        Dim middlename As String = ""
        If Not studentname.Contains(",") Then Return studentname
        Dim indexofcomma As Integer = studentname.IndexOf(",")
        Dim indexof2ndcomma As Integer = studentname.LastIndexOf(",")
        If indexofcomma = indexof2ndcomma Then
            middlename = ""
        Else
            middlename = studentname.Substring(indexof2ndcomma + 1)
        End If

        Return middlename
    End Function

    'For distinguishing between Receipts that are to deduct from Students Assessment and those that are not
    Public Shared Function isAssessmentDeductible(ByVal receiptremarks As String) As Boolean
        With receiptremarks.ToUpper
            If .Contains("TUITION") And .Contains("FEE") Then Return True
            If .Contains("SCRUBSUIT") Then Return True
            If .Contains("CHN") Then Return True
            If .Contains("PARAPHERNALIA") Then Return True
            If .Contains("ENROLLMENT") And .Contains("DMC") Then Return True
            If .Contains("ENROLLMENT") And .Contains("LIB") Then Return True
            If .Contains("ENROLLMENT") And .Contains("PUB") Then Return True
            If .Contains("ENROLLMENT") And .Contains("INTERNET") Then Return True
            If .Contains("ENROLLMENT") And .Contains("ID") Then Return True
            If .Contains("ENROLLMENT") And .Contains("INSU") Then Return True
            If .Contains("ENROLLMENT") And .Contains("PRISAA") Then Return True
        End With
        Return False
    End Function

    'ben3.5.2008 . Get BACKACCOUNTS of student . This is the OCHG charges in the ledger.
    Public Shared Function getStudentBackAccounts(ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer) As Double
        Dim ds As New dsRegistrar.WhiteFormDataTable
        Dim dt As New dsRegistrarTableAdapters.WhiteFormTableAdapter
        dt.Fill(ds, sypk, sempk, studentpk)
        If ds.Rows.Count <= 0 Then Return 0
        Dim i As Integer
        Dim backaccount As Double = 0
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                If .linetype.ToUpper = "OCHG" Then
                    backaccount += .amount
                End If
            End With
        Next
        Return backaccount
    End Function
    Public Shared Function getSYPKsortorder(ByVal sypk) As Integer
        Dim ds As New dsSchool.SchoolYearbyPKDataTable
        Dim dt As New dsSchoolTableAdapters.SchoolYearbyPKTableAdapter
        dt.Fill(ds, sypk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IssorterNull Then Return 0
        Return ds(0).sorter
    End Function

    Public Shared Function getSemPKsortorder(ByVal sempk) As Integer
        Dim ds As New dsSchool.SemesterbyPkDataTable
        Dim dt As New dsSchoolTableAdapters.SemesterbyPkTableAdapter
        dt.Fill(ds, sempk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IssorterNull Then Return 0
        Return ds(0).sorter
    End Function

    '10.28.2011. Pseudo System Reset. Ledger computation will only include those on or after 2nd sem 2011-2012
    '10.27.2011. will check for field IsBackAccountClearing, to include that amount in computation
    'Ben 3.28.2008 . Modified getStudentBackAccount. Will get total of balances from previous semesters. 
    Public Shared Function getStudentBackAccount(ByVal studentpk As Integer, ByVal sempk As Integer, _
                                                   ByVal sypk As Integer) As Single
        Dim backaccount As Single = 0
        Dim ds As New dsFinance.LedgerbyStudentDataTable
        Dim dt As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter
        dt.Fill(ds, studentpk)
        If ds.Rows.Count <= 0 Then Return 0

        Dim i, semsorter, sysorter As Integer
        For i = 0 To ds.Rows.Count - 1
            With ds(i)

                'CHECK INCLUSION . Only include backacounts on or after 2nd sem 2011-2012
                If Not clsTool.IsSYSemIncludedInLedgerComputations(.sempk, .sypk) Then Continue For

                'Check SortOrder of sypk and sempk.
                'back accounts are from previous semesters only.
                semsorter = clsTool2.getSemPKsortorder(.sempk)
                sysorter = clsTool2.getSYPKsortorder(.sypk)

                REM ONLY CHECK FOR SEM AND SY IF IsBackACcountClearing = false
                If .IsIsBackAccountClearingNull Then .IsBackAccountClearing = False

                If Not .IsBackAccountClearing Then
                    'Check School Year first of current record compare with fed sypk
                    If sysorter > clsTool2.getSYPKsortorder(sypk) Then Continue For

                    If sysorter = clsTool2.getSYPKsortorder(sypk) Then
                        'check if semester is equal or greater
                        If semsorter >= clsTool2.getSemPKsortorder(sempk) Then Continue For

                    End If
                End If

                REM Add checking for the coursepk if its the same as that in EnrollSubjectsCost
                ' avoid ledger records that were saved wrongly under another course . 7.2.2012
                If Not .linetype.ToUpper = "RCPT" Then 'RCPT records not under a coursepk
                    'get the first EnrollSubjects record on same sempk,sypk as that of ledger record
                    Dim strSQL As String = "SELECT TOP 1 coursepk FROM EnrollSubjects WHERE status = 1 AND yearpk = " & .sypk _
                                        & " AND sempk = " & .sempk & " AND studentpk =  " & .studentpk
                    Dim coursepk As String = clsTool.getDBValue(strSQL)
                    If Not IsNumeric(coursepk) Then coursepk = "0"

                    'skip record for non equal coursepk
                    If Not .coursepk = coursepk Then Continue For

                End If

                '' If sysorter < clstool2.getSYPKsortorder(sypk) Then WE DO NOTHING

                ' ========================================================
                ' At this point , records are from previous semesters only 
                '  .. except for IsBackAccountClearing
                ' ========================================================

                'SCHG OCHG RCPT TUTOR MISC
                Select Case .linetype.ToUpper
                    Case "SCHG"
                        backaccount += .amount
                    Case "OCHG"
                        backaccount += .amount
                    Case "TUTOR"
                        backaccount += .amount
                    Case "MISC"
                        backaccount += .amount

                    Case "RCPT"
                        'Add code to create a counterpart DEBIT item for RCPT lines that 
                        'are not assessmentdeductible
                        If Not clsTool2.isAssessmentDeductible(.remarks) Then
                            backaccount += .amount
                        End If

                        'Credit part                        
                        backaccount -= .amount
                End Select
            End With
        Next
        Return backaccount
    End Function

End Class
'==========================================================================
' PAYMENT TYPES
' ----------------
'ACCOMMODATION FEE
'ADDING/CHANGING
'ALUMNI FEE
'BACK ACCOUNTS
'BOARD EXAM PACKAGE
'BOARDING HOUSE
'CASES
'CERTIFICATION
'CERTIFIED TRUE COPY (CTC)
'CHN
'CLINICAL FEE
'CLINICAL ROTATION
'COMPLETION
'CONTRIBUTION
'COURSE AUDIT
'DIPLOMA
'DMC
'EXTENSION FEE
'FORM
'GRADUATION FEE
'HONORABLE DISMISSAL
'ID (NEW)
'INTERNET FEE
'LIBRARY FEE
'PARAPHERNALIA
'PHYSICAL EXAM
'PUBLICATION
'REMOVAL
'S/O
'SCRUBSUIT
'SPECIAL EXAM
'STATEMENT OF ACCOUNT
'TRANSCRIPT OF RECORDS
'TUITION FEE
'TUTORIAL FEE
'YEARBOOK
'OTHER FEES
'ENROLLMENT - DMC
'ENROLLMENT - LIB
'ENROLLMENT - PUB
'ENROLLMENT - INTERNET
'ENROLLMENT - ID
'ENROLLMENT - INSU
'ENROLLMENT - PRISAA
'ENROLLMENT - HANDBOOK
