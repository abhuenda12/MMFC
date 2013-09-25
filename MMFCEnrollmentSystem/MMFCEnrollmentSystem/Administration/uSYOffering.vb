Public Class uSYOffering
    

    Private dsBrokenHours As New dsRegistrar.SYOfferingExtraHoursDataTable
    Private dtBrokenHours As New dsRegistrarTableAdapters.SYOfferingExtraHoursTableAdapter

#Region "ADD/EDIT/DELETE"

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewDoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        OpenDoc()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        DeleteDoc()
    End Sub

    Public Sub NewDoc()
        Dim frm As New frmSYOffering
        frm.m_dsSY = Me.DsSchool.SYOffering
        frm.Init()
        frm.TextBox5.Text = "10"
        frm.TextBox6.Text = "50"
        frm.m_Sem = ComboBoxSem.SelectedValue
        frm.ShowDialog()

        If frm.IsDirty Then

            'Add the SYOFfering record
            Me.DsSchool.SYOffering.AddSYOfferingRow(clsTool.GetCurYearPK(), frm.m_Subject, frm.m_Resource, ComboBoxSem.SelectedValue, _
                frm.chkMon.Checked, frm.chkTue.Checked, frm.chkWed.Checked, frm.chkThu.Checked, frm.chkFri.Checked, frm.chkSat.Checked, _
                frm.chkSun.Checked, frm.DateTimePicker13.Value, frm.DateTimePicker14.Value, frm.DateTimePicker1.Value, _
                frm.DateTimePicker2.Value, frm.DateTimePicker3.Value, frm.DateTimePicker4.Value, frm.DateTimePicker5.Value, _
                frm.DateTimePicker6.Value, frm.DateTimePicker7.Value, frm.DateTimePicker8.Value, frm.DateTimePicker9.Value, _
                frm.DateTimePicker10.Value, frm.DateTimePicker11.Value, frm.DateTimePicker12.Value, frm.chkAltFri.Checked, _
                ComboBoxSem.SelectedValue, frm.m_Teacher, frm.txtRemarks.Text, Convert.ToInt32(frm.TextBox5.Text), _
                Convert.ToInt32(frm.TextBox6.Text), frm.txClosed.Checked, frm.chkRequested.Checked, frm.CheckBoxFusedOffering.Checked, frm.chkSpecialTutorial.Checked)

            'update db
            Me.SYOfferingTableAdapter.Update(Me.DsSchool.SYOffering)

            'Resource per day
            Dim strSQL As String = "SELECT isnull(MAX(syofferingpk),0) FROM SYOffering"
            Dim syofferfk As Int16 = clsTool.getDBValue(strSQL)

            Dim ds As New dsSchool2.SYOfferingResourcesDataTable
            Dim dt As New dsSchool2TableAdapters.SYOfferingResourcesTableAdapter

            ds.AddSYOfferingResourcesRow(syofferfk, clsTool.nullToZero(frm.mResourceMon), clsTool.nullToZero(frm.mResourceTue), clsTool.nullToZero(frm.mResourceWed), clsTool.nullToZero(frm.mResourceThu), clsTool.nullToZero(frm.mResourceFri), clsTool.nullToZero(frm.mResourceSat), clsTool.nullToZero(frm.mResourceSun))

            Try
                dt.Update(ds)
            Catch ex As Exception
                MsgBox("Error saving the resource details" & vbCrLf & ex.Message)
            End Try

            'Save Broken hours if any
            If frm.monBrokenHoursFrom <> "2/5/2007 12:01 pm" Or frm.monBrokenHoursTo <> "2/5/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "mon", frm.monBrokenHoursFrom, frm.monBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If

            If frm.tueBrokenHoursFrom <> "2/6/2007 12:01 pm" Or frm.tueBrokenHoursTo <> "2/6/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "tue", frm.tueBrokenHoursFrom, frm.tueBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If

            If frm.wedBrokenHoursFrom <> "2/7/2007 12:01 pm" Or frm.wedBrokenHoursTo <> "2/7/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "wed", frm.wedBrokenHoursFrom, frm.wedBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If
            If frm.thuBrokenHoursFrom <> "2/8/2007 12:01 pm" Or frm.thuBrokenHoursTo <> "2/8/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "thu", frm.thuBrokenHoursFrom, frm.thuBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If
            If frm.friBrokenHoursFrom <> "2/9/2007 12:01 pm" Or frm.friBrokenHoursTo <> "2/9/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "fri", frm.friBrokenHoursFrom, frm.friBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If
            If frm.satBrokenHoursFrom <> "2/10/2007 12:01 pm" Or frm.satBrokenHoursTo <> "2/10/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "sat", frm.satBrokenHoursFrom, frm.satBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If
            If frm.sunBrokenHoursFrom <> "2/11/2007 12:01 pm" Or frm.sunBrokenHoursTo <> "2/11/2007 12:00 pm" Then

                dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "sun", frm.sunBrokenHoursFrom, frm.sunBrokenHoursTo, False, Now)
                dtBrokenHours.Update(dsBrokenHours)
            End If

            'Now save if FUSED offering.. save to mapping table
            If frm.CheckBoxFusedOffering.Checked Then

                Dim dsFused As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
                Dim dtFused As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter

                'now add and update for each subject mapped
                If frm.m_fusedSubjectPK1 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK1)
                    dtFused.Update(dsFused)
                End If

                If frm.m_fusedSubjectPK2 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK2)
                    dtFused.Update(dsFused)
                End If

                If frm.m_fusedSubjectPK3 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK3)
                    dtFused.Update(dsFused)
                End If

                If frm.m_fusedSubjectPK4 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK4)
                    dtFused.Update(dsFused)

                End If

                If frm.m_fusedSubjectPK5 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK5)
                    dtFused.Update(dsFused)

                End If

                If frm.m_fusedSubjectPK6 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK6)
                    dtFused.Update(dsFused)

                End If

                If frm.m_fusedSubjectPK7 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK7)
                    dtFused.Update(dsFused)

                End If
                If frm.m_fusedSubjectPK8 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK8)
                    dtFused.Update(dsFused)

                End If
                If frm.m_fusedSubjectPK9 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK9)
                    dtFused.Update(dsFused)

                End If
                If frm.m_fusedSubjectPK10 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK10)
                    dtFused.Update(dsFused)

                End If
                If frm.m_fusedSubjectPK11 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK11)
                    dtFused.Update(dsFused)

                End If
                If frm.m_fusedSubjectPK12 > 0 Then
                    dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK12)
                    dtFused.Update(dsFused)

                End If

            End If


        End If
    End Sub
    Public Sub OpenDoc()
        If Me.DsSchool.SYOffering.Rows.Count = 0 Then MsgBox("nothing to open!") : Exit Sub

        Dim frm As New frmSYOffering

        frm.m_dsSY = Me.DsSchool.SYOffering
        frm.IsEdit = True
        frm.m_PriKey = Me.DsSchool.SYOffering(Me.SYOfferingBindingSource.Position).syofferingpk
        frm.m_Sem = ComboBoxSem.SelectedValue
        frm.m_YearPK = Me.DsSchool.SYOffering(Me.SYOfferingBindingSource.Position).sypk
        Dim r As dsSchool.SYOfferingRow = Me.DsSchool.SYOffering(Me.SYOfferingBindingSource.Position)
        frm.m_Subject = r.subjectpk
        frm.TextBox1.Text = clsTool.GetSubjectDescription(r.subjectpk)
        frm.m_Resource = r.resource
        frm.TextBox2.Text = clsTool.getResourceName(r.resource)
        frm.m_Teacher = r.teacherid
        frm.TextBox3.Text = clsTool.getTeacherName(r.teacherid)
        frm.chkMon.Checked = r.monday
        frm.chkTue.Checked = r.tuesday
        frm.chkWed.Checked = r.wednesday
        frm.chkThu.Checked = r.thursday
        frm.chkFri.Checked = r.friday
        frm.chkSat.Checked = r.saturday
        frm.chkSun.Checked = r.sunday
        frm.chkAltFri.Checked = r.alternatefriday
        frm.DateTimePicker1.Value = r.monfrom
        frm.DateTimePicker2.Value = r.monto
        frm.DateTimePicker3.Value = r.tuesfrom
        frm.DateTimePicker4.Value = r.tuesto
        frm.DateTimePicker5.Value = r.wedfrom
        frm.DateTimePicker6.Value = r.wedto
        frm.DateTimePicker7.Value = r.thufrom
        frm.DateTimePicker8.Value = r.thuto
        frm.DateTimePicker9.Value = r.frifrom
        frm.DateTimePicker10.Value = r.frito
        frm.DateTimePicker11.Value = r.satfrom
        frm.DateTimePicker12.Value = r.satto
        frm.DateTimePicker13.Value = r.sunfrom
        frm.DateTimePicker14.Value = r.sunto
        frm.TextBox5.Text = r.MinStudents.ToString
        frm.TextBox6.Text = r.MaxStudents.ToString
        If r.IsclosedNull Then frm.txClosed.Checked = False Else frm.txClosed.Checked = r.closed
        'ben10.3.2007
        If r.IsrequestedNull Then frm.chkRequested.Checked = False Else frm.chkRequested.Checked = r.requested

        'Special Tutorial Checkbox
        If r.IsisSpecialTutorialNull Then r.isSpecialTutorial = False
        frm.chkSpecialTutorial.Checked = r.isSpecialTutorial

        'set the Resources per day
        Dim ds As New dsSchool2.SYOfferingResourcesByFKDataTable
        Dim dt As New dsSchool2TableAdapters.SYOfferingResourcesByFKTableAdapter

        dt.Fill(ds, r.syofferingpk)

        If ds.Rows.Count > 0 Then

            frm.mResourceMon = ds(0).resourcemon
            frm.txtResourceMon.Text = clsTool.getResourceName(ds(0).resourcemon)
            frm.m_strResource = clsTool.getResourceName(ds(0).resourcemon)

            frm.mResourceTue = ds(0).resourcetue
            frm.txtResourceTue.Text = clsTool.getResourceName(ds(0).resourcetue)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcetue)

            frm.mResourceWed = ds(0).resourcewed
            frm.txtResourceWed.Text = clsTool.getResourceName(ds(0).resourcewed)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcewed)

            frm.mResourceThu = ds(0).resourcethu
            frm.txtResourceThu.Text = clsTool.getResourceName(ds(0).resourcethu)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcethu)

            frm.mResourceFri = ds(0).resourcefri
            frm.txtResourceFri.Text = clsTool.getResourceName(ds(0).resourcefri)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcefri)

            frm.mResourceSat = ds(0).resourcesat
            frm.txtResourceSat.Text = clsTool.getResourceName(ds(0).resourcesat)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcesat)

            frm.mResourceSun = ds(0).resourcesun
            frm.txtResourceSun.Text = clsTool.getResourceName(ds(0).resourcesun)
            If String.IsNullOrEmpty(frm.m_strResource) Then frm.m_strResource = clsTool.getResourceName(ds(0).resourcesun)
        End If

        'get broken hours
        frm.FillBrokenHours()


        'now set Fused Subject if any
        If r.IsisFusedNull Then r.isFused = False

        frm.CheckBoxFusedOffering.Checked = r.isFused
        frm.txtRemarks.Text = r.Remarks

        If r.isFused Then
            'now set the Mapped subjects
            Dim dsFused As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
            Dim dtFused As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter

            dtFused.Fill(dsFused, r.syofferingpk)
            Dim i As Integer
            'Only 12 Mapped subjects allowed in Form
            For i = 0 To dsFused.Rows.Count - 1
                If i = 0 Then frm.m_fusedSubjectPK1 = dsFused(0).subjectPK : frm.txtFused1.Text = clsTool.GetSubjectDescription(dsFused(0).subjectPK)
                If i = 1 Then frm.m_fusedSubjectPK2 = dsFused(1).subjectPK : frm.txtFused2.Text = clsTool.GetSubjectDescription(dsFused(1).subjectPK)
                If i = 2 Then frm.m_fusedSubjectPK3 = dsFused(2).subjectPK : frm.txtFused3.Text = clsTool.GetSubjectDescription(dsFused(2).subjectPK)
                If i = 3 Then frm.m_fusedSubjectPK4 = dsFused(3).subjectPK : frm.txtFused4.Text = clsTool.GetSubjectDescription(dsFused(3).subjectPK)
                If i = 4 Then frm.m_fusedSubjectPK5 = dsFused(4).subjectPK : frm.txtFused5.Text = clsTool.GetSubjectDescription(dsFused(4).subjectPK)
                If i = 5 Then frm.m_fusedSubjectPK6 = dsFused(5).subjectPK : frm.txtFused6.Text = clsTool.GetSubjectDescription(dsFused(5).subjectPK)
                If i = 6 Then frm.m_fusedSubjectPK7 = dsFused(6).subjectPK : frm.txtFused7.Text = clsTool.GetSubjectDescription(dsFused(6).subjectPK)
                If i = 7 Then frm.m_fusedSubjectPK8 = dsFused(7).subjectPK : frm.txtFused8.Text = clsTool.GetSubjectDescription(dsFused(7).subjectPK)
                If i = 8 Then frm.m_fusedSubjectPK9 = dsFused(8).subjectPK : frm.txtFused9.Text = clsTool.GetSubjectDescription(dsFused(8).subjectPK)
                If i = 9 Then frm.m_fusedSubjectPK10 = dsFused(9).subjectPK : frm.txtFused10.Text = clsTool.GetSubjectDescription(dsFused(9).subjectPK)
                If i = 10 Then frm.m_fusedSubjectPK11 = dsFused(10).subjectPK : frm.txtFused11.Text = clsTool.GetSubjectDescription(dsFused(10).subjectPK)
                If i = 11 Then frm.m_fusedSubjectPK12 = dsFused(11).subjectPK : frm.txtFused12.Text = clsTool.GetSubjectDescription(dsFused(11).subjectPK)
            Next

        End If


        frm.ShowDialog()
        If frm.IsDirty Then
            r.subjectpk = frm.m_Subject
            r.resource = frm.m_Resource
            r.teacherid = frm.m_Teacher
            r.monday = frm.chkMon.Checked
            r.tuesday = frm.chkTue.Checked
            r.wednesday = frm.chkWed.Checked
            r.thursday = frm.chkThu.Checked
            r.friday = frm.chkFri.Checked
            r.saturday = frm.chkSat.Checked
            r.sunday = frm.chkSun.Checked
            r.alternatefriday = frm.chkAltFri.Checked
            r.monfrom = frm.DateTimePicker1.Value
            r.monto = frm.DateTimePicker2.Value
            r.tuesfrom = frm.DateTimePicker3.Value
            r.tuesto = frm.DateTimePicker4.Value
            r.wedfrom = frm.DateTimePicker5.Value
            r.wedto = frm.DateTimePicker6.Value
            r.thufrom = frm.DateTimePicker7.Value
            r.thuto = frm.DateTimePicker8.Value
            r.frifrom = frm.DateTimePicker9.Value
            r.frito = frm.DateTimePicker10.Value
            r.satfrom = frm.DateTimePicker11.Value
            r.satto = frm.DateTimePicker12.Value
            r.sunfrom = frm.DateTimePicker13.Value
            r.sunto = frm.DateTimePicker14.Value
            r.Remarks = frm.txtRemarks.Text
            r.MinStudents = frm.TextBox5.Text
            r.MaxStudents = frm.TextBox6.Text
            r.closed = frm.txClosed.Checked
            'ben10.3.2007
            r.requested = frm.chkRequested.Checked

            r.isFused = frm.CheckBoxFusedOffering.Checked

            r.isSpecialTutorial = frm.chkSpecialTutorial.Checked

            Me.SYOfferingTableAdapter.Update(Me.DsSchool.SYOffering)

            'Update resources
            If ds.Rows.Count > 0 Then
                With ds(0)
                    .resourcemon = frm.mResourceMon
                    .resourcetue = frm.mResourceTue
                    .resourcewed = frm.mResourceWed
                    .resourcethu = frm.mResourceThu
                    .resourcefri = frm.mResourceFri
                    .resourcesat = frm.mResourceSat
                    .resourcesun = frm.mResourceSun
                End With

            End If

            r.Remarks = frm.txtRemarks.Text

            Try
                dt.Update(ds)
            Catch ex As Exception
                MsgBox("Error updating the resource details" & vbCrLf & ex.Message)
            End Try


            Try
                ''Now save Broken Hours
                Dim syofferfk As Integer = r.syofferingpk

                'delete previous entries first
                SQLStatement = "DELETE FROM SYOfferingExtraHours WHERE syOfferingFK = " & syofferfk
                clsTool.runDBSQL(SQLStatement)

                'Save Broken hours if any
                If frm.monBrokenHoursFrom <> "2/5/2007 12:01 pm" Or frm.monBrokenHoursTo <> "2/5/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "mon", frm.monBrokenHoursFrom, frm.monBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If

                If frm.tueBrokenHoursFrom <> "2/6/2007 12:01 pm" Or frm.tueBrokenHoursTo <> "2/6/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "tue", frm.tueBrokenHoursFrom, frm.tueBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If

                If frm.wedBrokenHoursFrom <> "2/7/2007 12:01 pm" Or frm.wedBrokenHoursTo <> "2/7/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "wed", frm.wedBrokenHoursFrom, frm.wedBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If
                If frm.thuBrokenHoursFrom <> "2/8/2007 12:01 pm" Or frm.thuBrokenHoursTo <> "2/8/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "thu", frm.thuBrokenHoursFrom, frm.thuBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If
                If frm.friBrokenHoursFrom <> "2/9/2007 12:01 pm" Or frm.friBrokenHoursTo <> "2/9/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "fri", frm.friBrokenHoursFrom, frm.friBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If
                If frm.satBrokenHoursFrom <> "2/10/2007 12:01 pm" Or frm.satBrokenHoursTo <> "2/10/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "sat", frm.satBrokenHoursFrom, frm.satBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If
                If frm.sunBrokenHoursFrom <> "2/11/2007 12:01 pm" Or frm.sunBrokenHoursTo <> "2/11/2007 12:00 pm" Then

                    dsBrokenHours.AddSYOfferingExtraHoursRow(syofferfk, "sun", frm.sunBrokenHoursFrom, frm.sunBrokenHoursTo, False, Now)
                    dtBrokenHours.Update(dsBrokenHours)
                End If

            Catch ex As Exception

                MsgBox("Error updating Broken Hours" & vbCrLf & ex.Message)
            End Try

            Try
                'Now save fusing


                Dim syofferfk As Integer = r.syofferingpk

                'delete previous entries first
                SQLStatement = "DELETE FROM SYOfferingFusedSubjects WHERE syOfferingFK = " & syofferfk
                clsTool.runDBSQL(SQLStatement)


                'Now save if FUSED offering.. save to mapping table
                If frm.CheckBoxFusedOffering.Checked Then

                    Dim dsFused As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
                    Dim dtFused As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter

                    'now add and update for each subject mapped
                    If frm.m_fusedSubjectPK1 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK1)
                        dtFused.Update(dsFused)
                    End If

                    If frm.m_fusedSubjectPK2 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK2)
                        dtFused.Update(dsFused)
                    End If

                    If frm.m_fusedSubjectPK3 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK3)
                        dtFused.Update(dsFused)
                    End If

                    If frm.m_fusedSubjectPK4 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK4)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK5 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK5)
                        dtFused.Update(dsFused)
                    End If

                    If frm.m_fusedSubjectPK6 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK6)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK7 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK7)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK8 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK8)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK9 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK9)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK10 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK10)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK11 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK11)
                        dtFused.Update(dsFused)

                    End If
                    If frm.m_fusedSubjectPK12 > 0 Then
                        dsFused.AddSYOfferingFusedSubjectsByFKRow(Now, syofferfk, frm.m_fusedSubjectPK12)
                        dtFused.Update(dsFused)

                    End If
                End If
            Catch ex As Exception
                MsgBox("Error updating fused subjects" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    'ben. 9.25.2007
    'added code as requested by user.
    Public Sub DeleteDoc()

        If Me.DsSchool.SYOffering.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub

        If MsgBox("Are you sure to remove selected offering? This cannot be undone.", MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then

            'Make a logical delete only. 11.20.2011
            Dim syofferpk As Integer = DsSchool.SYOffering(Me.SYOfferingBindingSource.Position).syofferingpk
            Dim strSQL As String = "UPDATE SYOffering SET IsDeleted = 1 WHERE syofferingpk = " & syofferpk

            Try
                clsTool.runDBSQL(strSQL)

                dLoad()
            Catch ex As Exception

                MsgBox("Error deleting the offering." & vbCrLf & ex.Message)
            End Try

        End If

    End Sub

#End Region

#Region "Events and Display "

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        'added this line to prevent error exception on delete of record
        If Me.DsSchool.SYOffering(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If Me.DsSchool.SYOffering(e.RowIndex).RowState = DataRowState.Detached Then Exit Sub
        If e.ColumnIndex = 0 Then
            e.Value = clsTool.GetSubjectDescription(Me.DsSchool.SYOffering(e.RowIndex).subjectpk)
        End If
        If e.ColumnIndex = 1 Then
            e.Value = clsTool.getTeacherName(Me.DsSchool.SYOffering(e.RowIndex).teacherid)
        End If
        If e.ColumnIndex = 2 Then
            e.Value = clsTool.getResourceName(Me.DsSchool.SYOffering(e.RowIndex).resource)
        End If
        If e.ColumnIndex = 3 Then
            Dim s As String = ""
            Dim r As dsSchool.SYOfferingRow = Me.DsSchool.SYOffering(e.RowIndex)
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
            Dim r As dsSchool.SYOfferingRow = Me.DsSchool.SYOffering(e.RowIndex)
            e.Value = r.MinStudents.ToString & "/" & r.MaxStudents.ToString
        End If
        If e.ColumnIndex = 6 Then
            Dim r As dsSchool.SYOfferingRow = Me.DsSchool.SYOffering(e.RowIndex)
            If r.IsclosedNull Then
                e.Value = "Open"
            Else
                If r.closed Then
                    e.Value = "Closed"
                Else
                    e.Value = "Open"
                End If
            End If
        End If
    End Sub

    'Loads the Grid
    Public Sub dLoad()
        Dim sem As Integer = -1
        If ComboBoxSem.SelectedValue Is Nothing Then
            Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
            sem = Me.DsSchool.Semester(0).SemPK
        Else
            sem = ComboBoxSem.SelectedValue
        End If


        Me.SYOfferingTableAdapter.Fill(Me.DsSchool.SYOffering, ComboBox1.SelectedValue, sem)

        REM dont limit loading to current school year. 9.22.2012
        ''Me.SYOfferingTableAdapter.Fill(Me.DsSchool.SYOffering, clsTool.GetCurYearPK(), sem)
        ''Me.ToolStripLabel1.Text = "School Year : " & clsTool.GetCurYear()

    End Sub

    Public Sub Init()
        ComboBoxSem.SelectedIndex = ComboBoxSem.FindString(clsTool.GetCurSem)
    End Sub

    'Load the grid
    Private Sub uSYOffering_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        ComboBoxSem.SelectedValue = clsTool.GetCurSemPK

        '9/22/2012. allow user to select school year to be able to load previous years
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        ComboBox1.SelectedValue = clsTool.GetCurYearPK

    End Sub

    'When Semester is changed
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSem.SelectedIndexChanged
        dLoad()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        dLoad()
    End Sub

    'Click Go Search. 10.21.2011
    Private Sub ToolStripButtonFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonFilter.Click
        goFilter()
    End Sub

    'ben11.23.2007. Press Enter
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            goFilter()
        End If
    End Sub

    'ben. hide rows not meeting the filter requirement
    Private Sub goFilter()
        Dim rows As Integer = Me.DsSchool.SYOffering.Rows.Count
        If rows <= 0 Then MsgBox("No subjects offered.") : Exit Sub

        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        Try
            dLoad()
            'put binding source at last row
            Me.SYOfferingBindingSource.Position = rows - 1
            Dim hits As Integer = 0
            Dim i As Integer
            For i = 0 To rows - 1
                With Me.DataGridView1.Rows(i)

                    'check if last row and if theres no hit yet
                    If i = rows - 1 And hits <= 0 Then MsgBox("No records meeting your filter.") : dLoad() : Exit Sub

                    'keyword search in cell values
                    Dim keyword As String = Me.txtFilter.Text.ToUpper

                    'search on subject, teacher, resource
                    If CStr(.Cells(0).Value).ToUpper.Contains(keyword) Or CStr(.Cells(1).Value).ToUpper.Contains(keyword) _
                       Or CStr(.Cells(2).Value).ToUpper.Contains(keyword) Then

                        hits += 1
                        If hits = 1 Then Me.SYOfferingBindingSource.Position = i 'transfer currency to first hit row

                    Else
                        .Visible = False
                    End If
                End With
            Next
        Catch ex As Exception

            MsgBox("There was an error in doing the search." & vbCrLf & ex.Message)
        Finally
            frm.Hide()
        End Try
       
    End Sub

#End Region
    
    
End Class
