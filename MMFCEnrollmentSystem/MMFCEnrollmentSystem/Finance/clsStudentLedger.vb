Public Class clsStudentLedger

    '---------------------------------------------------------------------------------------------------------------
    '  NOTE :
    '  1. dsFinance.LedgerandTrCodesbyStudentDataTable gives out a datatable which can be misleading with the joins.
    '     Ledger.ref  is usually the  EnrollSubjects.pk .. thus the statement 
    '       FROM Ledger AS a LEFT OUTER JOIN
    '                    EnrollSubjectsCost AS b ON a.ref = b.headerpk 
    '    BUT This works for types of SCHG . For TUTOR , the ledger.ref field is the SYOFFERINGPK 
    '     so careful with handling the output datatable 
    '---------------------------------------------------------------------------------------------------------------

    Public Shared Function loadStudentLedgerORtype(ByVal sempk As Integer, ByVal sypk As Integer, _
               ByVal studentpk As Integer, ByVal ds As dsFinance.LedgerandTrCodesbyStudentDataTable) As crStudentLedgerbyOR_Misc2Cols
        '=====================================================================================================
        'Variables
        Dim i As Integer
        Dim tuitiontotal As Decimal = 0
        ''Dim misctotal As Decimal = 0

        REM split misc into 2 . Feb 18, 2012
        Dim misctotal_reg As Decimal = 0
        Dim misctotal_special As Decimal = 0

        Dim otherfees As Decimal = 0  'for other SCHG nonTuition fees  
        Dim rlecharges As Decimal = 0
        Dim coursepk As Integer = clsTool.getStudentCoursePK(sempk, sypk, studentpk)  '6.30.2012
        REM change way of getting the tuition fee. since this is a ledger, 
        REM records have already been set in the enrollsubjects table . 6.30.2012
        ''Dim tuitionfee As Decimal = FormatNumber(clsTool.getCourseTuition(coursepk), 2) 'feb 7 2012
        Dim tuitionfee As Decimal = FormatNumber(clsTool.getTuitionbySemStudentSypk(studentpk, sempk, sypk, coursepk), 2)

        '10.28.2011. backaccounts will not include sems before 2nd sem 2011-2012. Pseudo New System Reset.
        'Ben 3.28.2008 Modified BackAccount source value
        Dim backaccounts As Decimal = clsTool2.getStudentBackAccount(studentpk, sempk, sypk)

        Dim adjustments As Decimal = 0
        Dim tutorial As Decimal = 0
        Dim requestedfee As Decimal = 0 'for requested subjects both NCM and nonNCM 
        Dim enrolledunits As Integer = clsTool.getStudentEnrolledUnits(studentpk, sempk, sypk)
        'will put string = "COURSE AUDIT" in other fees
        Dim hasNCM105 As Boolean = clsTool2.testIfSubjectCodeEnrolled("NCM 105", studentpk, sempk, sypk)

        Dim dsF As New dsFinance

        '=====================================================================================================
        For i = 0 To ds.Rows.Count - 1
            With ds(i)

                'filter out records with coursepk <> current student course pk from EnrollSubjects table. 6.30.2012
                If .IsCoursePKNull Then .CoursePK = 0
                If .linetype <> "RCPT" And .CoursePK <> coursepk Then Continue For

                Select Case .linetype
                    'Tuition Fee and Requested Subject Charges
                    'What differentiates an NCM-Requested Subject from a None-NCM Requested are 2 fields in the table (subjectcosttype and requesttype)
                    'Pharaphernalia, scrubsuit and comm extension displayed as misc
                    Case "SCHG"
                        'as of coding , we have 8 TRCODES plus the trpk = -1 which is the non-NCM requested subject
                        If .IsTranCodeNull Then .TranCode = ""
                        If .IsEnrollSubjectCostLineAmountNull Then .EnrollSubjectCostLineAmount = 0

                        If .TranCode.ToUpper = "TUITION" Or .TranCode.ToUpper = "TUITION FEE" Then

                            'check for 0 ledger amounts . 6.30.2012
                            If Not .LedgerAmount = 0 Then
                                tuitiontotal += .EnrollSubjectCostLineAmount
                            End If


                        ElseIf .TranCode.ToUpper = "RLE" Or .TranCode.ToUpper = "INTERNSHIP" Then

                            rlecharges += .EnrollSubjectCostLineAmount

                        ElseIf .TranCode.ToUpper = "RLE REQUEST" Then  'This is for the NCM-Type REQUESTED subjects

                            requestedfee += .EnrollSubjectCostLineAmount

                            'Trtype charge but display as misc
                            'insert the misc record below along with other misc charges from semamort table
                        ElseIf .TranCode.ToUpper = "CHN KIT" Or .TranCode.ToUpper = "PHARAPHERNALIA" _
                          Or .TranCode.ToUpper = "SCRUBSUIT" Or .TranCode.ToUpper = "COMM. EXTENSION" Then

                            REM 2.18.2012
                            'We will now differentiate 2 types of Misc amounts
                            'this misc is called specialmisc, the other is regularmisc

                            'check for 0 ledger amounts . 6.30.2012
                            If Not .LedgerAmount = 0 Then
                                misctotal_special += .EnrollSubjectCostLineAmount
                            End If


                            'for trpk = -1 , datatable will return OTHERS 
                        ElseIf .TranCode = "OTHERS" Then
                            'check if nonNCM-Type requested subject
                            If .IsRequestTypeNull Then .RequestType = ""

                            If .RequestType = "REQUEST" Then

                                requestedfee += .EnrollSubjectCostLineAmount
                            End If

                        Else
                            REM 10.29.2011
                            'all other charges we put into otherfees
                            'those that are subject related but are printed in WhiteForm as Miscellaneous
                            otherfees += .EnrollSubjectCostLineAmount

                        End If

                        'Miscellaneous Fees dbo.SemAmort
                    Case "MISC"
                        '2/18/2012 . 2 misc type
                        misctotal_reg += .LedgerAmount

                        'Adjustments  ... backaccounts will be derived differently
                    Case "OCHG"
                        'check that its not a backaccount reversal/addition record (IsBackAccountClearing)
                        If .IsIsBackAccountClearingNull Then .IsBackAccountClearing = False

                        If Not .IsBackAccountClearing Then
                            adjustments += .LedgerAmount

                        End If

                        'Receipts/Payments . 
                    Case "RCPT"

                        'Tutorial Subjects
                    Case "TUTOR"
                        otherfees += .LedgerAmount
                End Select
            End With
        Next

        Dim runningBalance As Decimal = 0


        'ADD DEBIT ITEMS
        'TUITION AMOUNT
        If tuitionfee = 0 Then tuitionfee = 1
        Dim tuitionunits As Integer = tuitiontotal / tuitionfee
        runningBalance += tuitiontotal
        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "Tuition Fee: " & tuitionunits & " x " & tuitionfee & "/unit", _
                               "", tuitiontotal, 0, runningBalance, "", 1)


        REM 2.18.2012. Split MISC into 2. regular and special. MISC BOX is regular. the others are special.
        REM Superceed this. Enter Misc as full amount item. details in subreport.
        'Ben 1.26.2008 . Should Itemize Misc Fees. 
        'Insert This as Misc Header only

        runningBalance += misctotal_reg

        ''dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "MISCELLANEOUS( total : " & FormatNumber(misctotal, 2) & "  )", _
        ''                       "", 0, 0, 0, "", 2)

        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "MISCELLANEOUS", _
                               "", misctotal_reg, 0, runningBalance, "", 2)

        REM COMMENTED OUT 10.29.2011
        ' MISC will be in a subreport
        '==============================================================================
        'ADD MISC DETAILS HERE from semamort table
        '' ''Dim dsMisc As New dsFinance.SemAmortbyStudentYearSemPKDataTable
        '' ''Dim dtMisc As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        '' ''dtMisc.Fill(dsMisc, studentpk, sypk, sempk)

        '' ''If dsMisc.Rows.Count > 0 Then

        '' ''    Dim miscName As String = ""
        '' ''    For i = 0 To dsMisc.Rows.Count - 1
        '' ''        With dsMisc(i)
        '' ''            miscName = "   " & clsTool.getChargeSchedName(.ChargeSchedPK)    'indent
        '' ''            runningBalance += .Charge

        '' ''            dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", miscName, _
        '' ''                "", .Charge, 0, runningBalance, "", 2)
        '' ''        End With
        '' ''    Next

        '' ''End If

        'insert trmisc from TR TYPES (Pharaphernalia,Commextension, Scrubsuit , chn kit)
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                If .IsTranCodeNull Then Continue For
                REM add checking for coursepk . 6.30.2012
                If .linetype = "SCHG" And .CoursePK = coursepk Then

                    If .TranCode.ToUpper = "CHN KIT" Or .TranCode.ToUpper = "PHARAPHERNALIA" _
                          Or .TranCode.ToUpper = "SCRUBSUIT" Or .TranCode.ToUpper = "COMM. EXTENSION" Then

                        'check for 0 ledger amounts . 6.30.2012
                        If Not .LedgerAmount = 0 Then
                            If .IsEnrollSubjectCostLineAmountNull Then .EnrollSubjectCostLineAmount = 0

                            runningBalance += .EnrollSubjectCostLineAmount

                            dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "   " & .TranCode, _
                                                    "", .EnrollSubjectCostLineAmount, 0, runningBalance, "", 2)
                        End If
                    End If
                End If
            End With
        Next

        '========================================================================================================
        'RLE CHARGES here
        If rlecharges > 0 Then
            runningBalance += rlecharges

            dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "RLE CHARGES", _
                                           "", rlecharges, 0, runningBalance, "", 4)
        End If
        '========================================================================================================

        '***************************
        'OTHER SUBJECT Charges HERE
        '***************************
        ' coming from TRTypes, non Tuition non RLE
        'TUTORIAL here 

        'header only here not affecting running balance
        ''''runningBalance += otherfees
        Dim othersubjectchargestitle As String = "OTHER SUBJECT CHARGES(" & FormatNumber(otherfees, 2) & ")"
        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", othersubjectchargestitle, _
                              "", 0, 0, 0, "", 4)

        'same loop above to itemize the details
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                If .IsTranCodeNull Then Continue For

                If .linetype = "SCHG" And .CoursePK = coursepk Then
                    If Not .TranCode.ToUpper = "CHN KIT" And Not .TranCode.ToUpper = "PHARAPHERNALIA" _
                          And Not .TranCode.ToUpper = "SCRUBSUIT" And Not .TranCode.ToUpper = "COMM. EXTENSION" _
                          And Not .TranCode.ToUpper = "TUITION" And Not .TranCode.ToUpper = "TUITION FEE" _
                          And Not .TranCode.ToUpper = "RLE" And Not .TranCode.ToUpper = "INTERNSHIP" _
                          And Not .TranCode.ToUpper = "RLE REQUEST" And Not .TranCode.ToUpper = "OTHERS" Then

                        runningBalance += .EnrollSubjectCostLineAmount

                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "     " & .TranCode.ToUpper, _
                              "", .EnrollSubjectCostLineAmount, 0, runningBalance, "", 4)

                    End If
                End If
            End With
        Next


        'NCM 105 Course Audit  1.27.2008
        If hasNCM105 Then
            dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "     COURSE AUDIT", _
                                           "", 0, 0, 0, "", 4)
        End If

        'BACK ACCOUNTS here
        runningBalance += backaccounts
        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "BACK ACCOUNTS", _
                               "", backaccounts, 0, runningBalance, "", 5)

        'REQUESTED FEE here
        runningBalance += requestedfee
        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "REQUESTED", _
                               "", requestedfee, 0, runningBalance, "", 6)

        'ADJUSTMENTS here
        If adjustments > 0 Then
            runningBalance += adjustments
            dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "ADJUSTMENTS", _
                                   "", adjustments, 0, runningBalance, "", 6)

        End If


        ' insert OR records HERE
        '=================================================================================
        Dim dsR As New dsFinance.LedgerbyStudentSemYearDataTable
        Dim dtR As New dsFinanceTableAdapters.LedgerbyStudentSemYearTableAdapter
        dtR.Fill(dsR, studentpk, sempk, sypk)

        For i = 0 To dsR.Rows.Count - 1
            With dsR(i)

                If .linetype.ToUpper = "RCPT" Then
                    'Distinguish if Assessment Deductible 
                    If Not clsTool2.isAssessmentDeductible(.remarks) Then Continue For

                    'use Ref as key in getting ORNo in ReceiptsHeader
                    'receipt amount should be from ledger not ReceiptsHEader since some records
                    'may not be AssessmentDeductible                        
                    If Not IsNumeric(.ref) Then .ref = -1
                    Dim ORNo As String = clsTool.getORNobyPK(.ref)
                    Dim payperiod As Integer = clsTool.getORpayperiodbyPK(.ref)
                    Dim ORDate As String = CStr(clsTool.getORDatebyPK(.ref))

                    'test if RCPT in Table , add ledger amount if its assessment deductible
                    'ds lists down OR# repeatedly per ledger record but printout 
                    'should be once
                    Dim isExisting As Boolean = False
                    If ORNo > "" Then
                        Dim j As Integer
                        For j = 0 To dsF.TemplateLedgerandOR.Rows.Count - 1
                            If dsF.TemplateLedgerandOR(j).ORno = ORNo Then
                                isExisting = True
                                'update the existing row's creditamt but dont insert a new row
                                dsF.TemplateLedgerandOR(j).creditAmt += .amount
                                Exit For 'exits inner for
                            End If
                        Next
                    End If
                    If isExisting Then Continue For 'exits outer for

                    If payperiod = 0 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "REGISTRATION", _
                           ORNo, 0, .amount, 0, "", 10)

                    ElseIf payperiod = 1 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "FIRST MONTHLY", _
                           ORNo, 0, .amount, 0, "", 11)
                    ElseIf payperiod = 2 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "SECOND MONTHLY", _
                           ORNo, 0, .amount, 0, "", 12)
                    ElseIf payperiod = 3 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "MID-TERM", _
                           ORNo, 0, .amount, 0, "", 13)
                    ElseIf payperiod = 4 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "SEMI-FINAL", _
                           ORNo, 0, .amount, 0, "", 14)
                    ElseIf payperiod = 5 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "FINAL", _
                           ORNo, 0, .amount, 0, "", 15)
                    End If


                End If
            End With
        Next
        '
        ' END O.R. Records
        '================================================================================================


        'get total assessment then edit balance column per OR posted
        ''Dim runningbalance As Decimal = tuitiontotal + misctotal + otherfees + backaccounts
        For i = 0 To dsF.TemplateLedgerandOR.Rows.Count - 1
            With dsF.TemplateLedgerandOR(i)
                If .creditAmt > 0 Then

                    .balance = runningBalance - .creditAmt
                    runningBalance = .balance
                End If
            End With
        Next


        ''Commented out remarks,. remarks will only be used when printing FULLY PAID!
        'Remarks row
        ''dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "REMARKS", _
        ''                           "", 0, 0, 0, "", 20)


        'START MISC CHARGES for SubReport
        '
        '10.28.2011. Include Misc Details in 2 columns, use WhiteForm Misc Charges SubReport

        '================================
        'START the Misc Charges here        
        '================================
        'ds is byreference
        '
        Dim dsReg As New dsRegistrar

        Dim dtEnrollSubj As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dtEnrollSubj.Fill(dsReg.EnrollSubjects, sypk, sempk, studentpk)

        If dsReg.EnrollSubjects.Rows.Count > 0 Then


            clsWhiteForm2.InsertMiscChargesExcludeSubjectCharges(dsReg.WhiteFormMiscCharges, studentpk, sempk, sypk, dsReg.EnrollSubjects)

        End If
        '
        'at this point, insert is finished, dsReg.WhiteFormMiscCharges should now have records

        'create and migrate dsRegWhiteFormMisc = dsfinWhiteformmisc 
        'report can only use 1 dataset which should be dsFinanance
        dsF.WhiteFormMiscCharges.Merge(dsReg.WhiteFormMiscCharges)
        '
        '
        'END Misc Charges Sub Report

        ''Dim rep2 As New crStudentLedgerbyOR
        Dim rep2 As New crStudentLedgerbyOR_Misc2Cols

        'Subreport Misc Charges
        rep2.Subreports(0).SetDataSource(dsF)

        rep2.SetDataSource(dsF)
        rep2.SetParameterValue("STUDENT", clsTool.getStudentName(studentpk))
        rep2.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep2.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep2.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep2.SetParameterValue("SEMSY", clsTool.getSEMName(sempk) & "  " & clsTool.getSYName(sypk))
        rep2.SetParameterValue("COURSE", clsTool.getStudentCourseCode(sempk, sypk, studentpk))
        rep2.SetParameterValue("YEARLEVEL", clsTool.getStudentYearLevel(studentpk, sempk, sypk))
        rep2.SetParameterValue("IDNO", clsTool.getStudentID(studentpk))
        rep2.SetParameterValue("TYPE", clsTool.getStudentType(studentpk))

        Return rep2
    End Function

    '10.28.2011. Only include ledger accounts 2nd sem 2011-2012. System Pseudo Reset.
    Public Shared Function loadStudentLedgerALLDetails(ByVal studentpk As Integer, _
                           ByVal ds As dsFinance.LedgerbyStudentDataTable) As crStudentLedger

        Dim ctr As Integer
        Dim bal As Double = 0
        Dim dsF As New dsFinance

        For ctr = 0 To ds.Rows.Count - 1
            With ds(ctr)

                If Not clsTool.IsSYSemIncludedInLedgerComputations(.sempk, .sypk) Then Continue For

                If .linetype = "SCHG" Then
                    bal = bal + .amount
                    dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, _
                      clsTool.GetSubjectDescription(.subjectpk), "SCHG", .amount, bal, "", _
                      clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                End If

                If .linetype = "MISC" Then
                    bal = bal + .amount : dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, _
                       clsTool.getCourseName(.coursepk), "MISC", .amount, bal, "", _
                       clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                End If

                '2.11.2008 . Add code to create a counterpart DEBIT item for 
                'RCPT lines that are not assessmentdeductible
                If .linetype = "RCPT" Then
                    If Not clsTool2.isAssessmentDeductible(.remarks) Then
                        bal += .amount
                        dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, .remarks, "PAYABLES", .amount, _
                                    bal, "", clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                    End If

                    'Credit part
                    bal = bal - .amount
                    dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, "PAY REF:" & .ref, _
                                       "RCPT", .amount, bal, .remarks, clsTool.getSYName(.sypk), _
                                        clsTool.getSEMName(.sempk), .ledgerpk)
                End If

                If .linetype = "OCHG" Then
                    bal = bal + .amount : dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, _
                                "", "OCHG", .amount, bal, .remarks, clsTool.getSYName(.sypk), _
                                clsTool.getSEMName(.sempk), .ledgerpk)
                End If

                'ben10.30.2007
                If .linetype = "TUTOR" Then
                    bal = bal + .amount : dsF.TemplateStudentLedger.AddTemplateStudentLedgerRow(.ledgerdate, _
                                   clsTool.GetSubjectDescription(.subjectpk), "TUTORIAL", .amount, _
                                   bal, .remarks, clsTool.getSYName(.sypk), clsTool.getSEMName(.sempk), .ledgerpk)
                End If

            End With
        Next

        Dim rep As New crStudentLedger
        rep.SetDataSource(dsF)
        rep.SetParameterValue("pStudentName", clsTool.getStudentName(studentpk))
        rep.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep.SetParameterValue("ADDR3", clsTool.GetSetting("ADDR3"))

        Return rep
    End Function

    'UPDATES on LEDGER only. Usually those after the first payment like exam payments.
    Public Shared Function loadStudentLedgerORtypeUpdatesOnly(ByVal sempk As Integer, ByVal sypk As Integer, _
            ByVal studentpk As Integer, ByVal ds As dsFinance.LedgerandTrCodesbyStudentDataTable, _
            ByVal DateReference As DateTime, ByVal OnlyIncludeUpdates As Boolean) As crStudentLedgerByORUpdatesOnly


        '=====================================================================================================
        'Variables
        Dim i As Integer
        Dim tuitiontotal As Decimal = 0
        Dim misctotal As Decimal = 0
        Dim otherfees As Decimal = 0  'for other SCHG nonTuition fees  ''check this again if still needed
        Dim rlecharges As Decimal = 0
        'Ben 3.28.2008 Modified BackAccount source value
        Dim backaccounts As Decimal = clsTool2.getStudentBackAccount(studentpk, sempk, sypk)
        Dim adjustments As Decimal = 0
        Dim tutorial As Decimal = 0
        Dim requestedfee As Decimal = 0 'for requested subjects both NCM and nonNCM 
        Dim enrolledunits As Integer = clsTool.getStudentEnrolledUnits(studentpk, sempk, sypk)
        'will put string = "COURSE AUDIT" in other fees
        Dim hasNCM105 As Boolean = clsTool2.testIfSubjectCodeEnrolled("NCM 105", studentpk, sempk, sypk)

        Dim dsF As New dsFinance

        '=====================================================================================================
        For i = 0 To ds.Rows.Count - 1
            With ds(i)

                ''Check for Dates . 10.27.2012. Only include records after the date reference
                If OnlyIncludeUpdates And .ledgerdate < DateReference Then Continue For

                Select Case .linetype
                    'Tuition Fee and Requested Subject Charges
                    'What differentiates an NCM-Requested Subject from a None-NCM Requested are 2 fields in the table (subjectcosttype and requesttype)
                    'Pharaphernalia, scrubsuit and comm extension displayed as misc
                    Case "SCHG"
                        'as of coding , we have 8 TRCODES plus the trpk = -1 which is the non-NCM requested subject
                        If .IsTranCodeNull Then .TranCode = ""
                        If .IsEnrollSubjectCostLineAmountNull Then .EnrollSubjectCostLineAmount = 0

                        If .TranCode.ToUpper = "TUITION" Then
                            tuitiontotal += .EnrollSubjectCostLineAmount

                        ElseIf .TranCode.ToUpper = "RLE" Or .TranCode.ToUpper = "INTERNSHIP" Then
                            rlecharges += .EnrollSubjectCostLineAmount

                        ElseIf .TranCode.ToUpper = "RLE REQUEST" Then  'This is for the NCM-Type REQUESTED subjects
                            requestedfee += .EnrollSubjectCostLineAmount

                            'Trtype charge but display as misc
                            'insert the misc record below along with other misc charges from semamort table
                        ElseIf .TranCode.ToUpper = "CHN KIT" Or .TranCode.ToUpper = "PHARAPHERNALIA" _
                          Or .TranCode.ToUpper = "SCRUBSUIT" Or .TranCode.ToUpper = "COMM. EXTENSION" Then
                            misctotal += .EnrollSubjectCostLineAmount

                            'for trpk = -1 , datatable will return OTHERS 
                        ElseIf .TranCode = "OTHERS" Then
                            'check if nonNCM-Type requested subject
                            If .IsRequestTypeNull Then .RequestType = ""
                            If .RequestType = "REQUEST" Then
                                requestedfee += .EnrollSubjectCostLineAmount
                            End If
                        End If

                        'Miscellaneous Fees dbo.SemAmort
                    Case "MISC"
                        misctotal += .LedgerAmount

                        'Adjustments  ... backaccounts will be derived differently
                    Case "OCHG"
                        adjustments += .LedgerAmount

                        'Receipts/Payments . 
                    Case "RCPT"

                        'Tutorial Subjects
                    Case "TUTOR"
                        otherfees += .LedgerAmount
                End Select
            End With
        Next

        Dim runningBalance As Decimal = 0


        ' insert OR records HERE
        '=================================================================================
        Dim dsR As New dsFinance.LedgerbyStudentSemYearDataTable
        Dim dtR As New dsFinanceTableAdapters.LedgerbyStudentSemYearTableAdapter
        dtR.Fill(dsR, studentpk, sempk, sypk)

        For i = 0 To dsR.Rows.Count - 1
            With dsR(i)

                ''Check for Dates . 10.27.2012. Only include records after the date reference
                If OnlyIncludeUpdates And .ledgerdate < DateReference Then Continue For

                If .linetype.ToUpper = "RCPT" Then
                    'Distinguish if Assessment Deductible 
                    If Not clsTool2.isAssessmentDeductible(.remarks) Then Continue For

                    'use Ref as key in getting ORNo in ReceiptsHeader
                    'receipt amount should be from ledger not ReceiptsHEader since some records
                    'may not be AssessmentDeductible                        
                    If Not IsNumeric(.ref) Then .ref = -1
                    Dim ORNo As String = clsTool.getORNobyPK(.ref)
                    Dim payperiod As Integer = clsTool.getORpayperiodbyPK(.ref)
                    Dim ORDate As String = CStr(clsTool.getORDatebyPK(.ref))

                    'test if RCPT in Table , add ledger amount if its assessment deductible
                    'ds lists down OR# repeatedly per ledger record but printout 
                    'should be once
                    Dim isExisting As Boolean = False
                    If ORNo > "" Then
                        Dim j As Integer
                        For j = 0 To dsF.TemplateLedgerandOR.Rows.Count - 1
                            If dsF.TemplateLedgerandOR(j).ORno = ORNo Then
                                isExisting = True
                                'update the existing row's creditamt but dont insert a new row
                                dsF.TemplateLedgerandOR(j).creditAmt += .amount
                                Exit For 'exits inner for
                            End If
                        Next
                    End If
                    If isExisting Then Continue For 'exits outer for

                    If payperiod = 0 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "REGISTRATION", _
                           ORNo, 0, .amount, 0, "", 10)

                    ElseIf payperiod = 1 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "FIRST MONTHLY", _
                           ORNo, 0, .amount, 0, "", 11)
                    ElseIf payperiod = 2 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "SECOND MONTHLY", _
                           ORNo, 0, .amount, 0, "", 12)
                    ElseIf payperiod = 3 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "MID-TERM", _
                           ORNo, 0, .amount, 0, "", 13)
                    ElseIf payperiod = 4 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "SEMI-FINAL", _
                           ORNo, 0, .amount, 0, "", 14)
                    ElseIf payperiod = 5 Then
                        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow(ORDate, "FINAL", _
                           ORNo, 0, .amount, 0, "", 15)
                    End If


                End If
            End With
        Next
        '
        ' END O.R. Records
        '================================================================================================


        Dim rep2 As New crStudentLedgerByORUpdatesOnly
        rep2.SetDataSource(dsF)
        rep2.SetParameterValue("STUDENT", clsTool.getStudentName(studentpk))
        rep2.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep2.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep2.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep2.SetParameterValue("SEMSY", clsTool.getSEMName(sempk) & "  " & clsTool.getSYName(sypk))
        rep2.SetParameterValue("COURSE", clsTool.getStudentCourseCode(sempk, sypk, studentpk))
        rep2.SetParameterValue("YEARLEVEL", clsTool.getStudentYearLevel(studentpk, sempk, sypk))
        rep2.SetParameterValue("IDNO", clsTool.getStudentID(studentpk))
        rep2.SetParameterValue("TYPE", clsTool.getStudentType(studentpk))

        Return rep2
    End Function


    Public Shared Function loadStudentLedgerFullyPaid(ByVal sempk As Integer, ByVal sypk As Integer, _
            ByVal studentpk As Integer, ByVal ds As dsFinance.LedgerandTrCodesbyStudentDataTable, _
            ByVal DateReference As DateTime, ByVal OnlyIncludeUpdates As Boolean) As crStudentLedgerByORUpdatesOnly

        Dim dsF As New dsFinance

        'Remarks row
        dsF.TemplateLedgerandOR.AddTemplateLedgerandORRow("", "REMARKS : FULLY PAID", _
                                   "", 0, 0, 0, "", 20)
      
        Dim rep2 As New crStudentLedgerByORUpdatesOnly
        rep2.SetDataSource(dsF)
        rep2.SetParameterValue("STUDENT", clsTool.getStudentName(studentpk))
        rep2.SetParameterValue("SNAME", clsTool.GetSetting("SNAME"))
        rep2.SetParameterValue("ADDR1", clsTool.GetSetting("ADDR1"))
        rep2.SetParameterValue("ADDR2", clsTool.GetSetting("ADDR2"))
        rep2.SetParameterValue("SEMSY", clsTool.getSEMName(sempk) & "  " & clsTool.getSYName(sypk))
        rep2.SetParameterValue("COURSE", clsTool.getStudentCourseCode(sempk, sypk, studentpk))
        rep2.SetParameterValue("YEARLEVEL", clsTool.getStudentYearLevel(studentpk, sempk, sypk))
        rep2.SetParameterValue("IDNO", clsTool.getStudentID(studentpk))
        rep2.SetParameterValue("TYPE", clsTool.getStudentType(studentpk))

        Return rep2
    End Function
End Class
