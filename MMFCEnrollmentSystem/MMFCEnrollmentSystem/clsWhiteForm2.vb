Public Class clsWhiteForm2

    Public Shared Function loadWhiteForm(ByVal sempk As Integer, ByVal sypk As Integer, _
            ByVal studentpk As Integer) As crWhiteForm

        Dim frmw As New frmWait
        frmw.Show()
        Application.DoEvents()

        ''Dim rep As New crEnroll
        Dim rep As New crWhiteForm

        'start ledger filling
        Dim ds As New dsRegistrar
        Dim dsFin As New dsFinance

        Dim dest As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        dest.Fill(ds.EnrollHeader, sempk, sypk, studentpk)
        Dim yearlevel As Integer = -99
        Dim regno As Integer = 0
        yearlevel = ds.EnrollHeader(0).yrlevel

        'REGNO is from the cashier module. 10.27.2011
        ''''regno = ds.EnrollHeader(0).PK  'for parameter use
        regno = clsTool.getRegNoByStudentSemYear(sypk, sempk, studentpk)

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

        Dim hasotherskeds As Boolean = False

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
                ''''misctotal += nr.amount  
                'set misctotal below when iterating the miscellaneous charges

            ElseIf nr.linetype = "SCHG" Then
                'for parameter use                 
                'set tuition and rle and other subj charges below
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

                        'RLE UNits in Subjects Table will handle this
                        'use classtool
                        subjunits = clsTool.getRLEAndMainUnits(.subjectpk)


                        ' ''10.19.2011. Test for NEW NURSING CURRICULUM. Hard coded subject pk 
                        ' '' NCM 104 - 578 , 5 units charged tuition 4 to RLE
                        ' '' NCM 105 - 579 , 4 units charged to tuition 2 to RLE
                        ''If .subjectpk = 578 Then

                        ''    subjunits = 5

                        ''ElseIf .subjectpk = 579 Then

                        ''    subjunits = 4
                        ''Else
                        ''    subjunits /= 2
                        ''End If

                        ''subjunits /= 2
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

                'INNER LOOP, Subject costs
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
                Next 'End inner loop subject costs

                'Start the Broken Hours SubReport Here
                '
                '

                'now check for extra/different hours (also broken hours) 
                Dim thisSyofferPK = ds.EnrollSubjects(ndx).syofferingpk
                hasotherskeds = clsTool.CheckSYOfferHasDifferentTimeSkeds(thisSyofferPK)
                Dim thisSubjectName As String = clsTool.GetSubjectName(ds.EnrollSubjects(ndx).subjectpk)

                'add rows to template for each different sked for same subject
                If hasotherskeds Then
                    Dim daytimesked As String = clsTool.getSYOfferFullSked(thisSyofferPK)

                    ds.BrokenHoursTemplate.AddBrokenHoursTemplateRow(thisSubjectName, daytimesked)

                End If
                '
                '
                'END Broken Hours


            End If
        Next

        'START the Misc Charges here        
        '
        'ds is byreference
        '
        clsWhiteForm2.InsertMiscCharges(ds.WhiteFormMiscCharges, studentpk, sempk, sypk, ds.EnrollSubjects)
        '
        'at this point, insert is finished, ds should now have records



        'Add Tutor Fees to MISC temporarily
        If tutorfee > 0 Then

            ds.WhiteFormMiscCharges.AddWhiteFormMiscChargesRow("TUTORIAL CHARGE", FormatNumber(tutorfee, 2), "", 0)

            ''misctotalsemamort += tutorfee
        End If

        misctotalsemamort = ds.WhiteFormMiscCharges.Compute("SUM(AmountCol1)", String.Empty) + ds.WhiteFormMiscCharges.Compute("SUM(AmountCol2)", String.Empty)

        ''Now Summarize Totals

        Dim totalfee As Double = totaltuitionfee + rlecharges + misctotalsemamort + backaccount ''othercharges 
        ''Dim balance As Double = totalfee - payments
        'Ben 7.8.2008 . balance will now be computed as totalfee less DP
        Dim balance As Double = totalfee - downpayment
        Dim monthly As Double = balance / examCount


        'Report

        'Misc Charges
        rep.Subreports(0).SetDataSource(ds)
        'Broken Hours
        rep.Subreports(1).SetDataSource(ds)

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


        'conditional showing of information on final assessment
        If hasRequestSubjects Then
            ''''rep.SetParameterValue("SHOWFINALASSESSINFO", True)
            Dim reminder As String = "* FINAL ASSESSMENT FOR REQUESTED SUBJECTS ADDITIONAL CHARGES WILL BE GIVEN ON THE 1ST EXAM"
                        rep.SetParameterValue("RQSUBJECT_REMINDER", reminder)

        Else
            rep.SetParameterValue("RQSUBJECT_REMINDER", "")
        End If

        'Clearance Note
        Dim reminder2 As String = "* SECURE CLEARANCE NOTE AT AGH BEFORE PAYING YOUR TUITION FEE AT THE CASHIER."
        rep.SetParameterValue("CLEARANCE_REMINDER", reminder2)

        frmw.Hide()

        Return rep

    End Function

    Public Shared Sub InsertMiscCharges(ByRef ds As dsRegistrar.WhiteFormMiscChargesDataTable, ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer, ByVal dsEnroll As dsRegistrar.EnrollSubjectsDataTable)

        Dim i, sourcecount, targetcount, targetindex As Integer
        Dim dsFin As New dsFinance

        'fill misc table from semamort records
        Dim dtSemAmort As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        dtSemAmort.Fill(dsFin.SemAmortbyStudentYearSemPK, studentpk, sypk, sempk)

        If dsFin.SemAmortbyStudentYearSemPK.Rows.Count <= 0 Then Exit Sub

        sourcecount = dsFin.SemAmortbyStudentYearSemPK.Rows.Count

        Dim remndr As Integer
        If Math.DivRem(sourcecount, 2, remndr) > 0 Then
            targetcount = Math.Ceiling(sourcecount / 2)
        Else
            targetcount = sourcecount / 2
        End If

        'Put the misc charges in 2 columns
        REM get dsfin rowcount, divide by 2, the mod of that quotient is the number of rows we should add to dswhiteform
        REM when rowcount is reached, loop back to the first row in dswhiteform and set the column2 values

        targetindex = 0
        Dim j As Integer
        For i = 0 To dsFin.SemAmortbyStudentYearSemPK.Rows.Count - 1
            j = i + 1
            With dsFin.SemAmortbyStudentYearSemPK(i)

                'fill out first column
                If j <= targetcount Then

                    ds.AddWhiteFormMiscChargesRow(clsTool.getChargeSchedName(.ChargeSchedPK), FormatNumber(.Charge, 2), "", 0)
                Else
                    'else fill out 2nd col
                    ds(targetindex).MiscNameCol2 = clsTool.getChargeSchedName(.ChargeSchedPK)
                    ds(targetindex).AmountCol2 = FormatNumber(.Charge, 2)

                    targetindex += 1

                End If

            End With
        Next

        'OTHER FEES non MISC non TUITION
        'Insert to Miscellaneous details the other Non-RLE Non Tuition TrCodes
        Dim dsEnrollSubjectsCost As New dsRegistrar.EnrollSubjectsCostbyPKDataTable
        Dim dtSubjCost As New dsRegistrarTableAdapters.EnrollSubjectsCostbyPKTableAdapter

        Dim enrollpk As Integer = -1
        Dim ndx2 As Integer
        Dim tran As String = ""
        Dim subjcode As String = ""
        Dim tramount As Double = 0
        Dim tutorfee As Double = 0

        'OUTER LOOP
        '
        '
        'Get the enrolled subjects and all costings applied for that subject
        For i = 0 To dsEnroll.Rows.Count - 1

            If dsEnroll(i).status = 1 Then 'if enrolled

                enrollpk = dsEnroll(i).enrollpk

                'fill costing table
                dtSubjCost.Fill(dsEnrollSubjectsCost, enrollpk)

                'INNER LOOP
                '
                '
                'loop to check what transaction type it is. if not RLE and not Tuition, add to MISC 
                For ndx2 = 0 To dsEnrollSubjectsCost.Rows.Count - 1

                    With dsEnrollSubjectsCost(ndx2)

                        If .trpk = -1 Then Continue For 'regular requested subject cost
                        tran = clsTool.getTrTypeName(.trpk)
                        tramount = .amount

                        If Not clsTool.getTrTypeCode(.trpk).ToUpper = "RLE" _
                        And Not clsTool.getTrTypeCode(.trpk).ToUpper = "RLE REQUEST" _
                        And Not clsTool.getTrTypeCode(.trpk).ToUpper = "TUITION" _
                        And Not clsTool.getTrTypeCode(.trpk).ToUpper.Contains("INTERNSHIP") Then


                            ds.AddWhiteFormMiscChargesRow(tran, FormatNumber(tramount, 2), "", 0)

                        End If
                    End With
                Next
            End If
        Next


    End Sub

    'FOR Student Ledger. Subject Charges non tuition non rle are NOT INSERTED TO MISC
    Public Shared Sub InsertMiscChargesExcludeSubjectCharges(ByRef ds As dsRegistrar.WhiteFormMiscChargesDataTable, ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer, ByVal dsEnroll As dsRegistrar.EnrollSubjectsDataTable)

        Dim i, sourcecount, targetcount, targetindex As Integer
        Dim dsFin As New dsFinance

        'fill misc table from semamort records
        Dim dtSemAmort As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        dtSemAmort.Fill(dsFin.SemAmortbyStudentYearSemPK, studentpk, sypk, sempk)

        If dsFin.SemAmortbyStudentYearSemPK.Rows.Count <= 0 Then Exit Sub

        sourcecount = dsFin.SemAmortbyStudentYearSemPK.Rows.Count

        Dim remndr As Integer
        If Math.DivRem(sourcecount, 2, remndr) > 0 Then
            targetcount = Math.Ceiling(sourcecount / 2)
        Else
            targetcount = sourcecount / 2
        End If

        'Put the misc charges in 2 columns
        REM get dsfin rowcount, divide by 2, the mod of that quotient is the number of rows we should add to dswhiteform
        REM when rowcount is reached, loop back to the first row in dswhiteform and set the column2 values

        targetindex = 0
        Dim j As Integer
        For i = 0 To dsFin.SemAmortbyStudentYearSemPK.Rows.Count - 1
            j = i + 1
            With dsFin.SemAmortbyStudentYearSemPK(i)

                'fill out first column
                If j <= targetcount Then

                    ds.AddWhiteFormMiscChargesRow(clsTool.getChargeSchedName(.ChargeSchedPK), FormatNumber(.Charge, 2), "", 0)
                Else
                    'else fill out 2nd col
                    ds(targetindex).MiscNameCol2 = clsTool.getChargeSchedName(.ChargeSchedPK)
                    ds(targetindex).AmountCol2 = FormatNumber(.Charge, 2)

                    targetindex += 1

                End If

            End With
        Next

       

    End Sub
End Class
