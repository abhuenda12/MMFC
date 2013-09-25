Public Class clsWhiteForm

    '*************************
    ' Please use clsWhiteForm2
    '*************************
    Public Shared Function loadWhiteForm(ByVal sempk As Integer, ByVal sypk As Integer, _
            ByVal studentpk As Integer) As crEnroll

        Dim frmw As New frmWait
        frmw.Show()
        Application.DoEvents()

        Dim rep As New crEnroll

        'start ledger filling
        Dim ds As New dsRegistrar
        Dim dsFin As New dsFinance

        Dim dest As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        dest.Fill(ds.EnrollHeader, sempk, sypk, studentpk)
        Dim yearlevel As Integer = -99
        Dim regno As Integer = 0
        yearlevel = ds.EnrollHeader(0).yrlevel
        regno = ds.EnrollHeader(0).PK  'for parameter use

        'get Ledger for student 
        Dim dtx As New dsRegistrarTableAdapters.WhiteFormTableAdapter
        dtx.Fill(ds.WhiteForm, sypk, sempk, studentpk)

        '========================================================================================
        '        V A R I A B L E S
        '========================================================================================
        'for parameter use
        Dim subjcostTotal As Double = 0      'for review if still needed
        Dim misctotal As Double = 0          'for review if still needed
        Dim othercharges As Double = 0
        Dim payments As Double = 0
        'Ben added. 7.8.2008 . Downpayment will now be taken from receipts with payperiod = 0
        Dim downpayment As Double = clsTool.getStudentPaidAmountPerPeriod(studentpk, sypk, 0, sempk)
        Dim course As String = ""
        Dim totalunits As Decimal = 0       'for review if still needed
        Dim totalunitsfordisplay As Decimal = 0
        Dim subjunits As Integer = 0
        Dim coursetuitionfee As Double = 0
        Dim totaltuitionfee As Double = 0
        Dim misctotalsemamort As Double = 0 'this is from semamort table
        Dim tutorfee As Double = 0
        Dim rlecharges As Double = 0
        Dim hasRequestSubjects As Boolean = False
        'Ben 3.28.2008 
        Dim backaccount As Double = clsTool2.getStudentBackAccount(studentpk, sempk, sypk)
        'Ben 4.9.2008
        Dim examCount As Integer = IIf(clsTool.getSEMName(sempk).ToUpper.Contains("SUM"), 3, 5)

        '===============================================================================================

        'get LEDGER details using  Student,Sem,SY and use as Parameter Values
        Dim ctr As Integer
        For ctr = 0 To ds.WhiteForm.Rows.Count - 1
            Dim nr As dsRegistrar.WhiteFormRow = ds.WhiteForm(ctr)

            If nr.linetype = "RCPT" Then
                If clsTool2.isAssessmentDeductible(nr.remarks) Then payments += nr.amount
            ElseIf nr.linetype = "OCHG" Then
                othercharges += nr.amount 'wont be used for back account value anymore
            ElseIf nr.linetype = "MISC" Then
                ''''misctotal += nr.amount  'set misctotal below when iterating the miscellaneous charges

            ElseIf nr.linetype = "SCHG" Then
                'for parameter use 
                ''''subjcostTotal += nr.amount 'set tuition and rle and other subj charges below
            ElseIf nr.linetype = "TUTOR" Then
                tutorfee += nr.amount  'as of coding we add tutorfee to misc
            End If

        Next

        Dim ndx As Integer

        'Get subjects enrolled        
        Dim dtEnrollSubj As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dtEnrollSubj.Fill(ds.EnrollSubjects, sypk, sempk, studentpk)

        For ndx = 0 To ds.EnrollSubjects.Rows.Count - 1
            With ds.EnrollSubjects(ndx)
                If .status = 1 Then

                    'Nov 12 2008. NSTP Display should be original = 3 not half. costing is the one being halfed.
                    'units for nstp, ncm104/105 are divided by half in costing tuition fee . 
                    'all rle except rle103 will not be charged
                    Dim subjectcode As String = clsTool.GetSubjectCode(.subjectpk)
                    subjunits = clsTool.GetSubjectUnits(.subjectpk)

                    'Nov 13 2008. NCM 101 and 102 display half also.
                    ''If (subjectcode.ToUpper.Contains("NSTP")) Or _
                    If (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("104")) Or _
                    (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("105")) Or _
                    (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("101")) Or _
                    (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("102")) Then

                        subjunits /= 2
                        ''ElseIf (subjectcode.ToUpper.Contains("RLE") And Not subjectcode.ToUpper.Contains("103")) Then
                        ''    subjunits = 0
                    End If

                    totalunits += subjunits
                    totalunitsfordisplay += subjunits

                    ds.TemplateEnrollment.AddTemplateEnrollmentRow("0SUBJECTS", clsTool.GetSubjectCode(.subjectpk), clsTool.GetSubjectName(.subjectpk), _
                            clsTool.getClassResourceID(.syofferingpk), clsTool.getSYOfferStart(.syofferingpk), clsTool.getSYOfferEnd(.syofferingpk), _
                            clsTool.getSYOfferDays(.syofferingpk), subjunits, clsTool.getClassType(.syofferingpk, sempk, sypk))

                    If clsTool.getClassType(.syofferingpk) = "RQ" Then hasRequestSubjects = True
                End If
            End With
        Next
        course = clsTool.getCourseCode(ds.EnrollSubjects(0).coursepk)
        coursetuitionfee = clsTool.getCourseTuition(ds.EnrollSubjects(0).coursepk)
        ''''totaltuitionfee = totalunits * coursetuitionfee   ***we get totaltuitionfee in iterating EnrollSubjectCost below

        'Insert pseudo footer for total units
        ds.TemplateEnrollment.AddTemplateEnrollmentRow("1SUBJECTSFOOTER", "", "", _
                          "", "", "", "Total Units:", totalunitsfordisplay, "")

        'Insert pseudo Header for RLE details
        ds.TemplateEnrollment.AddTemplateEnrollmentRow("2SUBJCHARGES", "", "RLE", _
                          "AMOUNT", "", "", "", "", "")

        'Get listing of subject charges (tuition fee , RLE, etc)
        'use ds.EnrollSubjects to get the enrollpk of each enrolled subject. 
        'enrollpk is equal to headerpk of EnrollSubjectsCost table
        Dim enrollpk As Integer = -1
        Dim ndx2 As Integer
        Dim tran As String = ""
        Dim subjcode As String = ""
        Dim tramount As Double = 0
        Dim dtSubjCost As New dsRegistrarTableAdapters.EnrollSubjectsCostbyPKTableAdapter

        For ndx = 0 To ds.EnrollSubjects.Rows.Count - 1
            If ds.EnrollSubjects(ndx).status = 1 Then

                enrollpk = ds.EnrollSubjects(ndx).enrollpk
                dtSubjCost.Fill(ds.EnrollSubjectsCostbyPK, enrollpk)

                For ndx2 = 0 To ds.EnrollSubjectsCostbyPK.Rows.Count - 1
                    With ds.EnrollSubjectsCostbyPK(ndx2)
                        tran = clsTool.getTrTypeName(.trpk)
                        subjcode = clsTool.GetSubjectCode(ds.EnrollSubjects(ndx).subjectpk)
                        tramount = .amount

                        'set Tuition Fee
                        If clsTool.getTrTypeCode(.trpk).ToUpper = "TUITION" Then
                            totaltuitionfee += tramount

                            'ben1.26.2008. Only RLE will be added. 
                            'Other nonRLE & nonTuition charges will be in MISC
                        ElseIf clsTool.getTrTypeCode(.trpk).ToUpper = "RLE" Or _
                           clsTool.getTrTypeCode(.trpk).ToUpper = "RLE REQUEST" Or _
                           clsTool.getTrTypeCode(.trpk).ToUpper.Contains("INTERNSHIP") Then

                            ds.TemplateEnrollment.AddTemplateEnrollmentRow("3SUBJDETAILS", "", subjcode & " " & tran, _
                                              FormatNumber(tramount, 2), "", "", "", "", "")
                            rlecharges += tramount
                        End If

                    End With
                Next
            End If
        Next


        'Insert pseudo Header for Miscellaneous . We create a box if has Requested Subject
        If hasRequestSubjects Then
            ds.TemplateEnrollment.AddTemplateEnrollmentRow("5MISCHEADER", "", "MISCELLANEOUS CHARGES", _
                              "AMOUNT", "================", "================", "================", "================", "")
        Else
            ds.TemplateEnrollment.AddTemplateEnrollmentRow("5MISCHEADER", "", "MISCELLANEOUS CHARGES", _
                              "AMOUNT", "", "", "", "", "")
        End If

        'Get Miscellaneous details . Use description column to hold Transaction Type Name , then use Room column to hold TRTypeAmount .. convert to string
        'added extra columns for a Message Box on Requested Subjects
        Dim dtSemAmort As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        dtSemAmort.Fill(dsFin.SemAmortbyStudentYearSemPK, studentpk, sypk, sempk)

        For ndx = 0 To dsFin.SemAmortbyStudentYearSemPK.Rows.Count - 1
            With dsFin.SemAmortbyStudentYearSemPK(ndx)
                misctotalsemamort += .Charge
                If hasRequestSubjects Then
                    If ndx = 0 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "", "IMPORTANT:", "", "", "")
                    If ndx = 1 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "     Final", "assessment", "     will", "be", "")
                    If ndx = 2 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "     during", "MIDTERM", "     due", "to", "")
                    If ndx = 3 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "   requested", "subject", "", "", "")
                    If ndx = 4 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "================", "================", "================", "================", "")
                    If ndx > 4 Then ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                          FormatNumber(.Charge, 2), "", "", "", "", "")

                Else
                    ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", clsTool.getChargeSchedName(.ChargeSchedPK), _
                         FormatNumber(.Charge, 2), "", "", "", "", "")
                End If
            End With
        Next

        'ben1.26.2008. Insert to Miscellaneous details the other Non-RLE Non Tuition TrCodes
        For ndx = 0 To ds.EnrollSubjects.Rows.Count - 1
            If ds.EnrollSubjects(ndx).status = 1 Then

                enrollpk = ds.EnrollSubjects(ndx).enrollpk
                dtSubjCost.Fill(ds.EnrollSubjectsCostbyPK, enrollpk)

                For ndx2 = 0 To ds.EnrollSubjectsCostbyPK.Rows.Count - 1
                    With ds.EnrollSubjectsCostbyPK(ndx2)
                        If .trpk = -1 Then Continue For 'regular requested subject cost
                        tran = clsTool.getTrTypeName(.trpk)
                        tramount = .amount

                        If Not clsTool.getTrTypeCode(.trpk).ToUpper = "RLE" _
                             And Not clsTool.getTrTypeCode(.trpk).ToUpper = "RLE REQUEST" _
                             And Not clsTool.getTrTypeCode(.trpk).ToUpper = "TUITION" _
                             And Not clsTool.getTrTypeCode(.trpk).ToUpper.Contains("INTERNSHIP") Then

                            ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", tran, _
                                              FormatNumber(tramount, 2), "", "", "", "", "")

                            misctotalsemamort += tramount
                        End If
                    End With
                Next
            End If
        Next

        'Add Tutor Fees to MISC temporarily
        If tutorfee > 0 Then
            ds.TemplateEnrollment.AddTemplateEnrollmentRow("6MISC", "", "TUTORIAL CHARGE", _
                                                          FormatNumber(tutorfee, 2), "", "", "", "", "")
            misctotalsemamort += tutorfee
        End If

        Dim totalfee As Double = totaltuitionfee + rlecharges + misctotalsemamort + backaccount ''othercharges 
        ''Dim balance As Double = totalfee - payments
        'Ben 7.8.2008 . balance will now be computed as totalfee less DP
        Dim balance As Double = totalfee - downpayment
        Dim monthly As Double = balance / examCount

        'Report

        rep.SetDataSource(ds)
        rep.SetParameterValue("EDATE", Now().Date)
        rep.SetParameterValue("STUDENTNAME", clsTool.getStudentName(studentpk))
        rep.SetParameterValue("YEARLEVEL", clsTool.GetYearLevelFull(yearlevel))
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))
        rep.SetParameterValue("REGISTRAR", clsTool.GetSetting("REGISTRAR"))
        'ben10.10.2007
        rep.SetParameterValue("TITLE", "FORM 1-A")
        rep.SetParameterValue("REGNO", regno)
        rep.SetParameterValue("COURSE", course)
        rep.SetParameterValue("SEM", clsTool.getSEMName(sempk))
        rep.SetParameterValue("SY", clsTool.getSYName(sypk))

        rep.SetParameterValue("MISC", misctotalsemamort)
        rep.SetParameterValue("TUITION", totaltuitionfee)
        rep.SetParameterValue("TUITIONFEE", coursetuitionfee)
        rep.SetParameterValue("SCHG", rlecharges)
        rep.SetParameterValue("BACKACCOUNT", backaccount) 'used othercharges before modification
        rep.SetParameterValue("TOTALFEE", totalfee)
        'payments will get all RCPTS from ledger from all pay periods as of coding. not just DP payperiod.
        'Ben 7.8.2008. DP will now be taken from payments with payperiod = 0
        rep.SetParameterValue("DP", downpayment)
        rep.SetParameterValue("BAL", balance)
        rep.SetParameterValue("MONTHLY", monthly)

        rep.SetParameterValue("1STE", clsTool.getExamDate(sempk, sypk, 1))
        rep.SetParameterValue("2NDE", clsTool.getExamDate(sempk, sypk, 2))
        rep.SetParameterValue("3RDE", clsTool.getExamDate(sempk, sypk, 3))
        rep.SetParameterValue("4THE", clsTool.getExamDate(sempk, sypk, 4))
        rep.SetParameterValue("5THE", clsTool.getExamDate(sempk, sypk, 5))

        rep.SetParameterValue("TYPE", clsTool.getStudentType(studentpk))
        frmw.Hide()

        Return rep

    End Function

End Class
