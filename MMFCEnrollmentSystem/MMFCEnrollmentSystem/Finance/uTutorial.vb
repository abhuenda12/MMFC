Public Class uTutorial

    REM disabled applying of charges , 7.1.2012
    '  setting of charges for REQUESTED SUBJECTS will be done in uFinalizeEnrollment only!
    '  uFinalizeEnrollment checks if a RQ subject is closed then it will set the charges there
    '=============================================================================================
    ' Main Objective of this module : to manually divide the Subject Charges of an 
    '  offering that didn't reach the minimum students. 
    '
    ' gets Syoffering Classes with enrolled students less than minimum 
    ' 1. computes for the additional charges and adds to student ledger
    ' 2. Closes the SY Offering that has been APPLIED CHARGES TO ENROLLED STUDENTS
    '==============================================================================================

#Region "Main Grid Events and Methods"
    'Initialize Combo Boxes
    Public Sub loadData()
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.cmbSem.SelectedValue = clsTool.GetCurSemPK
        Me.cmbSY.SelectedValue = clsTool.GetCurYearPK
    End Sub

    'Load all SYOFfering
    Sub LoadOfferings()
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        Me.SYOfferingSelect2TableAdapter.Fill(Me.DsRegistrar.SYOfferingSelect2, Me.cmbSY.SelectedValue, Me.cmbSem.SelectedValue)
        goFilter(Me.CheckBox1.Checked) '7.1.2012
        frm.Hide()
    End Sub

    'REtrieve button
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoadOfferings()
    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded

        With Me.DsRegistrar.SYOfferingSelect2(e.RowIndex)
            Dim enrolled As Integer = clsTool.getStudentCount(Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue, .syofferingpk)
            'class
            If e.ColumnIndex = 0 Then
                ''e.Value = clsTool.GetSubjectCode(.subjectpk)
                e.Value = clsTool.GetSubjectDescription(.subjectpk)
            End If
            'time
            If e.ColumnIndex = 1 Then
                e.Value = clsTool.getSYOfferStart(.syofferingpk) & clsTool.getSYOfferEnd(.syofferingpk)
            End If
            'days
            If e.ColumnIndex = 2 Then
                e.Value = clsTool.getSYOfferDays(.syofferingpk)
            End If
            'enrolled
            If e.ColumnIndex = 5 Then
                e.Value = enrolled
            End If

            'Type
            Dim classtype As String = ""

            If e.ColumnIndex = 7 Then
                If .IsrequestedNull Then .requested = False

                'REQUESTED SUBJECTS
                If .IsIsSpecialTutorialNull Then .IsSpecialTutorial = False

                If .IsSpecialTutorial Then
                    classtype = "Special Tutorial"

                ElseIf .requested Then
                    If enrolled < .MinStudents Then
                        classtype = "Requested - Tutorial"
                    Else
                        classtype = "Requested"
                    End If

                Else
                    'REGULAR SUBJECTS
                    If enrolled < .MinStudents Then
                        classtype = "Regular - Tutorial"
                    Else
                        classtype = "Regular"
                    End If

                End If
                e.Value = classtype
            End If

            'Status 
            If e.ColumnIndex = 8 Then


                If .IsrequestedNull Then
                    .requested = False

                End If

                If .IsIsSpecialTutorialNull Then .IsSpecialTutorial = False

                If .requested And enrolled < .MinStudents And Not .IsSpecialTutorial Then

                    'Also test for closed subject
                    If clsTool.testIfSYofferhasTutorCharges(CStr(.syofferingpk), .subjectpk, Me.cmbSem.SelectedValue, Me.cmbSY.SelectedValue) Then

                        e.Value = "Adjusted"
                    ElseIf clsTool.testSYOfferIfClosed(.syofferingpk) Then

                        e.Value = "Closed/Adjusted"

                    Else

                        e.Value = "For Adjustment"

                    End If

                Else
                    e.Value = "N/A"
                End If

            End If
        End With
    End Sub

    'filtering
    Private Sub goFilter(ByVal filtered As Boolean)
        Dim rows As Integer = Me.DsRegistrar.SYOfferingSelect2.Rows.Count
        If rows <= 0 Then MsgBox("No subjects offered.") : Exit Sub

        Try

            'put binding source at last row
            Me.SYOfferingSelect2BindingSource.Position = rows - 1
            Dim hits As Integer = 0
            Dim i As Integer
            For i = 0 To rows - 1
                With Me.DataGridView1.Rows(i)

                    'check if last row and if theres no hit yet
                    ''If i = rows - 1 And hits <= 0 Then MsgBox("No records meeting your filter.") : Exit Sub
                    If i = rows - 1 And hits <= 0 Then Exit Sub

                    'keyword search in cell values
                    Dim keyword As String = "N/A"

                    'search on subject, teacher, resource
                    If Not CStr(.Cells(8).Value).ToUpper = keyword And filtered Then

                        hits += 1
                        If hits = 1 Then Me.SYOfferingSelect2BindingSource.Position = i 'transfer currency to first hit row

                    ElseIf CStr(.Cells(8).Value).ToUpper = keyword And filtered Then
                        .Visible = False
                    Else
                        .Visible = True
                    End If
                End With
            Next
        Catch ex As Exception

            MsgBox("There was an error in filtering tutorials." & vbCrLf & ex.Message)
        Finally

        End Try

    End Sub
#End Region

#Region "Adjustment of Tutorial Charges for SYOffering"

    'Show Form for Tutorial Cost sharing, with Confirm Button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Me.DataGridView1.Rows.Count <= 0 Then Exit Sub

        ''If Me.DataGridView1.CurrentRow.Cells(7).Value <> "Tutorial" Then MsgBox("That is not a tutorial subject.") : Exit Sub
        If Not Me.DataGridView1.CurrentRow.Cells(7).Value.ToString.Contains("Tutorial") _
            Or Not Me.DataGridView1.CurrentRow.Cells(7).Value.ToString.Contains("Requested") Then

            MsgBox("Only Requested Tutorials can be processed for division of charges.")
            Exit Sub
        End If


        If Me.DataGridView1.CurrentRow.Cells(8).Value.ToString.Contains("Adjusted") Then MsgBox("Tutorial Class Already Adjusted!") : Exit Sub

        If Me.DataGridView1.CurrentRow.Cells(5).Value = "0" Then MsgBox("No students to share charges!") : Exit Sub

        Dim syofferclass As String = ""

        Dim enrolledcount = Me.DataGridView1.CurrentRow.Cells(5).Value

        syofferclass = Me.DataGridView1.CurrentRow.Cells(0).Value

        REM Commented out. Will show a form listing Class students First before confirming adjustment 
        ' of charges

        ''If MsgBox("This will now adjust subject charges for all students enrolled in class: " & syofferclass & " . This cannot be undone. Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        ''    adjustCharges(enrolledcount)
        ''End If

        SetTutorialClassForm(enrolledcount)


    End Sub

    Private Sub adjustCharges(ByVal enrolled As Integer)

        Dim ds As New dsRegistrar.EnrollSubjectsbySyOPKDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsbySyOPKTableAdapter

        Dim additionalcharges As Double = 0
        Dim studentshare As Double = 0  'tuitionfee of first student enrolled * units * minstudentrequired / enrolledcount
        Dim tuitionfee As Double = 0
        Dim minrequired As Double = 0
        Dim subjectunits As Integer = 0

        With Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position)
            'get all students enrolled
            dt.Fill(ds, .syofferingpk)

            minrequired = clsTool.getSYOfferMinStudents(.syofferingpk)
            subjectunits = clsTool.GetSubjectUnits(.subjectpk)

            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                'check if enrolled
                If ds(i).status = 1 Then
                    'get tuition fee of first student enrolled
                    If i = 0 Then tuitionfee = clsTool.getCourseTuition(ds(0).coursepk)

                    studentshare = tuitionfee * subjectunits * minrequired / enrolled
                    additionalcharges = studentshare - (tuitionfee * subjectunits)

                    'add TUTOR charges in ledger for this student
                    Dim dsL As New dsFinance.LedgerDataTable
                    Dim dtL As New dsFinanceTableAdapters.LedgerTableAdapter

                    '10.27.2011. added backaccountclearing bit.
                    If additionalcharges > 0 Then
                        dsL.AddLedgerRow(Now(), CStr(.syofferingpk), .semesterpk, .subjectpk, ds(i).coursepk, _
                         "TUTOR", additionalcharges, 0, ds(i).studentpk, .sypk, "Tutorial Charges shared by " & enrolled, False)
                    End If

                    Try
                        dtL.Update(dsL)
                    Catch ex As Exception
                        MsgBox("System Busy. Try Again" & vbCrLf & ex.Message)
                    End Try

                End If
            Next

            'close SY offering
            clsTool.closeSYOffering(.syofferingpk)

            LoadOfferings()

        End With

    End Sub

    'Just a copy of above but without the DT.UPDATE statement
    Sub SetTutorialClassForm(ByVal enrolled As Integer)
        Dim ds As New dsRegistrar.EnrollSubjectsbySyOPKDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsbySyOPKTableAdapter

        Dim additionalcharges As Double = 0
        Dim studentshare As Double = 0  'tuitionfee of first student enrolled * units * minstudentrequired / enrolledcount
        Dim tuitionfee As Double = 0
        Dim minrequired As Double = 0
        Dim subjectunits As Integer = 0

        With Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position)

            'get all students enrolled
            dt.Fill(ds, .syofferingpk)

            minrequired = clsTool.getSYOfferMinStudents(.syofferingpk)
            subjectunits = clsTool.GetSubjectUnits(.subjectpk)

            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                'check if enrolled
                If ds(i).status = 1 Then
                    'get tuition fee of first student enrolled
                    If i = 0 Then tuitionfee = clsTool.getCourseTuition(ds(0).coursepk)

                    studentshare = tuitionfee * subjectunits * minrequired / enrolled
                    additionalcharges = studentshare - (tuitionfee * subjectunits)


                End If
            Next

        End With

        Dim frm As New frmTutorialClassList
        With Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position)

            'get all students enrolled
            dt.Fill(ds, .syofferingpk)

            minrequired = clsTool.getSYOfferMinStudents(.syofferingpk)
            subjectunits = clsTool.GetSubjectUnits(.subjectpk)

            'amount that is required to cover the subject
            Dim subjectminimumcost As Double = tuitionfee * subjectunits * minrequired
            'amount that has been paid by the enrolled students in their white form enlistment
            Dim enrolledpaidcost As Double = enrolled * tuitionfee * subjectunits
            'balance to be shared by each (without deducting the whiteform charges yet)
            Dim balanceforsharing As Double = subjectminimumcost - enrolledpaidcost

            frm.TextBoxSubjectUnits.Text = subjectunits
            frm.TextBoxTuitionFee.Text = FormatNumber(tuitionfee, 2)
            frm.TextBoxSubjectCost.Text = FormatNumber(subjectminimumcost, 2)
            frm.TextBoxEnrolledTotalCost.Text = FormatNumber(enrolledpaidcost, 2)
            frm.TextBoxBalanceToBeShared.Text = FormatNumber(balanceforsharing, 2)


            frm.syofferpk = .syofferingpk
            frm.sempk = .semesterpk
            frm.sypk = .sypk

            frm.LoadClassList(.syofferingpk)

            frm.Text = clsTool.GetSubjectDescription(.subjectpk)

            'now set the charges (w/out applying it, just for display)
            frm.TextBoxStudentShare.Text = FormatNumber(additionalcharges, 2)

            frm.ShowDialog()

            'Confirmed Charges
            If frm.isDirty Then

                'call sub
                adjustCharges(enrolled)
            End If

        End With


    End Sub

#End Region


End Class
