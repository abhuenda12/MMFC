Public Class frmSYOffering

#Region "Variables and Initialization"

    Public IsDirty As Boolean = False
    Public m_Subject As Integer
    Public m_Resource As Integer = 0
    Public mResourceMon As Integer = 0
    Public mResourceTue As Integer = 0
    Public mResourceWed As Integer = 0
    Public mResourceThu As Integer = 0
    Public mResourceFri As Integer = 0
    Public mResourceSat As Integer = 0
    Public mResourceSun As Integer = 0

    Public m_Teacher As Integer
    Public m_Sem As Integer
    Public IsEdit As Boolean = False
    Public m_PriKey As Integer
    Public m_strResource As String = ""
    Public m_dsSY As dsSchool.SYOfferingDataTable
    Public m_YearPK As Integer = 0

    Private m_ConflictMatrix As ConflictMatrix

    'Mapped/Fused Subjects
    Public m_fusedSubjectPK1, m_fusedSubjectPK2, m_fusedSubjectPK3, m_fusedSubjectPK4, m_fusedSubjectPK5, m_fusedSubjectPK6, m_fusedSubjectPK7, m_fusedSubjectPK8, m_fusedSubjectPK9, m_fusedSubjectPK10, m_fusedSubjectPK11, m_fusedSubjectPK12 As Integer

    'for usage on popout form frmBrokenHours
    Public monBrokenHoursFrom As Date = "2/5/2007 12:01 pm"
    Public monBrokenHoursTo As Date = "2/5/2007 12:00 pm"

    Public tueBrokenHoursFrom As Date = "2/6/2007 12:01 pm"
    Public tueBrokenHoursTo As Date = "2/6/2007 12:00 pm"

    Public wedBrokenHoursFrom As Date = "2/7/2007 12:01 pm"
    Public wedBrokenHoursTo As Date = "2/7/2007 12:00 pm"

    Public thuBrokenHoursFrom As Date = "2/8/2007 12:01 pm"
    Public thuBrokenHoursTo As Date = "2/8/2007 12:00 pm"

    Public friBrokenHoursFrom As Date = "2/9/2007 12:01 pm"
    Public friBrokenHoursTo As Date = "2/9/2007 12:00 pm"

    Public satBrokenHoursFrom As Date = "2/10/2007 12:01 pm"
    Public satBrokenHoursTo As Date = "2/10/2007 12:00 pm"

    Public sunBrokenHoursFrom As Date = "2/11/2007 12:01 pm"
    Public sunBrokenHoursTo As Date = "2/11/2007 12:00 pm"

    Sub Init()
        m_Subject = -1
        m_Resource = -1
        m_Teacher = -1
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""

        'Mon
        DateTimePicker1.Value = "2/5/2007 12:01 am"
        DateTimePicker2.Value = "2/5/2007 12:00 am"
        'Tue
        DateTimePicker3.Value = "2/6/2007 12:01 am"
        DateTimePicker4.Value = "2/6/2007 12:00 am"
        'Wed
        DateTimePicker5.Value = "2/7/2007 12:01 am"
        DateTimePicker6.Value = "2/7/2007 12:00 am"
        'Thu
        DateTimePicker7.Value = "2/8/2007 12:01 am"
        DateTimePicker8.Value = "2/8/2007 12:00 am"
        'Fri
        DateTimePicker9.Value = "2/9/2007 12:01 am"
        DateTimePicker10.Value = "2/9/2007 12:00 am"
        'Sat
        DateTimePicker11.Value = "2/10/2007 12:01 am"
        DateTimePicker12.Value = "2/10/2007 12:00 am"
        'Sun
        DateTimePicker13.Value = "2/11/2007 12:01 am"
        DateTimePicker14.Value = "2/11/2007 12:00 am"
        'ben10.3.2007
        Me.chkRequested.Checked = False

        
    End Sub

    Sub InitializeBrokenHours()
        monBrokenHoursFrom = "2/5/2007 12:01 pm"
        monBrokenHoursTo = "2/5/2007 12:00 pm"

        tueBrokenHoursFrom = "2/6/2007 12:01 pm"
        tueBrokenHoursTo = "2/6/2007 12:00 pm"

        wedBrokenHoursFrom = "2/7/2007 12:01 pm"
        wedBrokenHoursTo = "2/7/2007 12:00 pm"

        thuBrokenHoursFrom = "2/8/2007 12:01 pm"
        thuBrokenHoursTo = "2/8/2007 12:00 pm"

        friBrokenHoursFrom = "2/9/2007 12:01 pm"
        friBrokenHoursTo = "2/9/2007 12:00 pm"

        satBrokenHoursFrom = "2/10/2007 12:01 pm"
        satBrokenHoursTo = "2/10/2007 12:00 pm"

        sunBrokenHoursFrom = "2/11/2007 12:01 pm"
        sunBrokenHoursTo = "2/11/2007 12:00 pm"
    End Sub

    'Get Broken hours to set broken hours per day if any. only for EDIT.
    Public Sub FillBrokenHours()

        'Get Broken Hours for this SYOffering if any then replace initial values
        '10.21.2011
        Dim dsBroken As New dsRegistrar.SYOfferingExtraHoursByFKDataTable
        Dim dtBroken As New dsRegistrarTableAdapters.SYOfferingExtraHoursByFKTableAdapter

        dtBroken.Fill(dsBroken, m_PriKey)
        Dim i As Integer
        For i = 0 To dsBroken.Rows.Count - 1
            With dsBroken(i)

                If .dayType = "mon" Then
                    monBrokenHoursFrom = .timeStart
                    monBrokenHoursTo = .timeEnd

                ElseIf .dayType = "tue" Then
                    tueBrokenHoursFrom = .timeStart
                    tueBrokenHoursTo = .timeEnd

                ElseIf .dayType = "wed" Then
                    wedBrokenHoursFrom = .timeStart
                    wedBrokenHoursTo = .timeEnd

                ElseIf .dayType = "thu" Then
                    thuBrokenHoursFrom = .timeStart
                    thuBrokenHoursTo = .timeEnd

                ElseIf .dayType = "fri" Then
                    friBrokenHoursFrom = .timeStart
                    friBrokenHoursTo = .timeEnd

                ElseIf .dayType = "sat" Then
                    satBrokenHoursFrom = .timeStart
                    satBrokenHoursTo = .timeEnd

                ElseIf .dayType = "sun" Then
                    sunBrokenHoursFrom = .timeStart
                    sunBrokenHoursTo = .timeEnd

                End If

            End With
        Next
    End Sub
#End Region

#Region "Conflict Checking"


    'Logic for Conflict Checking
    'Comparison is done with 2 SYOfferings. This forms SYoffering with that of the Whole Grid from Mother Form dsSY
    ' 1.  test for time overlap regular hours
    ' 2.  test for time overlap on Broken Hours 
    ' 3.  then if true for #1, test for teacher ID and Resource ID
    ' 4.6.213. Make this reusable
    Function CheckConflict(ByVal _dsSY As dsSchool.SYOfferingDataTable) As ConflictMatrix

        Dim Result As New ConflictMatrix
        Dim ctr As Integer
        Dim d1 As Date
        Dim d2 As Date

        'initialize
        Result.HasNoConflict = True
        Result.ListOfSyOfferings = New List(Of Integer)

        For ctr = 0 To _dsSY.Rows.Count - 1
            With _dsSY(ctr)

                'MONDAY

                d1 = DateTimePicker1.Value
                d2 = DateTimePicker2.Value

                'time checking on regular hours of the syofferpk in the grid
                'and with the broken hours
                If .monday And chkMon.Checked And _
                    ((d1 >= .monfrom And d1 <= .monto) _
                        Or (d2 >= .monfrom And d2 <= .monto) _
                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", False)) _
                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", False)) _
                    ) Then

                    'add to possible conflicting students who were enrolled on same time frame with other sections
                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then _
                                MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(.teacherid) _
                                         & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(.teacherid) _
                                   & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                     And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "mon") = mResourceMon Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'TUESDAY

                d1 = DateTimePicker3.Value

                d2 = DateTimePicker4.Value

                If .tuesday And chkTue.Checked And _
                 ((d1 >= .tuesfrom And d1 <= .tuesto) _
                     Or (d2 >= .tuesfrom And d2 <= .tuesto) _
                     Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", False)) _
                     Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", False)) _
                 ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                      And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "tue") = mResourceTue Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'WEDNESDAY

                d1 = DateTimePicker5.Value

                d2 = DateTimePicker6.Value

                If .wednesday And chkWed.Checked And _
                    ((d1 >= .wedfrom And d1 <= .wedto) _
                        Or (d2 >= .wedfrom And d2 <= .wedto) _
                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", False)) _
                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", False)) _
                    ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                     And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "wed") = mResourceWed Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'THURSDAY
                d1 = DateTimePicker7.Value
                d2 = DateTimePicker8.Value

                If .thursday And chkThu.Checked And _
                                    ((d1 >= .thufrom And d1 <= .thuto) _
                                        Or (d2 >= .thufrom And d2 <= .thuto) _
                                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", False)) _
                                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", False)) _
                                    ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                     And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "thu") = mResourceThu Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'FRIDAY
                d1 = DateTimePicker9.Value
                d2 = DateTimePicker10.Value

                If .friday And chkFri.Checked And _
                                    ((d1 >= .frifrom And d1 <= .frito) _
                                        Or (d2 >= .frifrom And d2 <= .frito) _
                                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", False)) _
                                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", False)) _
                                    ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                    And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "fri") = mResourceFri Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'SATURDAY
                d1 = DateTimePicker11.Value
                d2 = DateTimePicker12.Value

                If .saturday And chkSat.Checked And _
                                    ((d1 >= .satfrom And d1 <= .satto) _
                                        Or (d2 >= .satfrom And d2 <= .satto) _
                                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", False)) _
                                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", False)) _
                                    ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                    And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sat") = mResourceSat Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                'SUNDAY

                d1 = DateTimePicker13.Value
                d2 = DateTimePicker14.Value

                If .sunday And chkSun.Checked And _
                                   ((d1 >= .sunfrom And d1 <= .sunto) _
                                       Or (d2 >= .sunfrom And d2 <= .sunto) _
                                       Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", False)) _
                                       Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", False)) _
                                   ) Then

                    Result.ListOfSyOfferings.Add(.syofferingpk)

                    If .teacherid = Me.m_Teacher Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                    If .resource = Me.m_Resource _
                    And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sun") = mResourceSun Then

                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        Else
                            MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                        End If
                    End If

                End If

                '**************************************************************
                'Check Broken Hours here .. already includes Resource Conflict
                ' check against regular hours, also against broken hours
                '**************************************************************

                'MONDAY
                If Not monBrokenHoursFrom = "2/5/2007 12:01 pm" Or Not monBrokenHoursTo = "2/5/2007 12:00 pm" Then

                    d1 = monBrokenHoursFrom
                    d2 = monBrokenHoursTo

                    If .monday And chkMon.Checked And _
                            ((d1 >= .monfrom And d1 <= .monto) _
                           Or (d2 >= .monfrom And d2 <= .monto) _
                           Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", False)) _
                           Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "mon", False)) _
                         ) Then

                        Result.ListOfSyOfferings.Add(.syofferingpk)

                        If .teacherid = Me.m_Teacher Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then _
                                         MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(.teacherid) _
                                         & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(.teacherid) _
                                       & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                            And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "mon") = mResourceMon Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If

                End If

                'TUESDAY
                If Not tueBrokenHoursFrom = "2/6/2007 12:01 pm" Or Not tueBrokenHoursTo = "2/6/2007 12:00 pm" Then
                    d1 = tueBrokenHoursFrom
                    d2 = tueBrokenHoursTo
                    If .tuesday And chkTue.Checked And _
                       ((d1 >= .tuesfrom And d1 <= .tuesto) _
                           Or (d2 >= .tuesfrom And d2 <= .tuesto) _
                           Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", False)) _
                           Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "tue", False)) _
                       ) Then



                        Result.ListOfSyOfferings.Add(.syofferingpk)

                        If .teacherid = Me.m_Teacher Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                               And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "tue") = mResourceTue Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If

                End If

                'WedneSDAY
                If Not wedBrokenHoursFrom = "2/7/2007 12:01 pm" Or Not wedBrokenHoursTo = "2/7/2007 12:00 pm" Then
                    d1 = wedBrokenHoursFrom
                    d2 = wedBrokenHoursTo
                    If .wednesday And chkWed.Checked And _
                          ((d1 >= .wedfrom And d1 <= .wedto) _
                              Or (d2 >= .wedfrom And d2 <= .wedto) _
                              Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", False)) _
                              Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "wed", False)) _
                          ) Then




                        Result.ListOfSyOfferings.Add(.syofferingpk)

                        If .teacherid = Me.m_Teacher Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                              And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "wed") = mResourceWed Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If
                End If

                'THURSDAY
                If Not thuBrokenHoursFrom = "2/8/2007 12:01 pm" Or Not thuBrokenHoursTo = "2/8/2007 12:00 pm" Then
                    d1 = thuBrokenHoursFrom
                    d2 = thuBrokenHoursTo

                    If .thursday And chkThu.Checked And _
                                   ((d1 >= .thufrom And d1 <= .thuto) _
                                       Or (d2 >= .thufrom And d2 <= .thuto) _
                                       Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", False)) _
                                       Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "thu", False)) _
                                   ) Then



                        Result.ListOfSyOfferings.Add(.syofferingpk)

                        If .teacherid = Me.m_Teacher Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                              And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "thu") = mResourceThu Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If

                End If

                ''FRIDAY
                If Not friBrokenHoursFrom = "2/9/2007 12:01 pm" Or Not friBrokenHoursTo = "2/9/2007 12:00 pm" Then
                    d1 = friBrokenHoursFrom
                    d2 = friBrokenHoursTo

                    If .friday And chkFri.Checked And _
                                     ((d1 >= .frifrom And d1 <= .frito) _
                                         Or (d2 >= .frifrom And d2 <= .frito) _
                                         Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", False)) _
                                         Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "fri", False)) _
                                     ) Then



                        Result.ListOfSyOfferings.Add(.syofferingpk)

                        If .teacherid = Me.m_Teacher Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                             And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "fri") = mResourceFri Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If

                End If

                ''SATURDAY
                If Not satBrokenHoursFrom = "2/10/2007 12:01 pm" Or Not satBrokenHoursTo = "2/10/2007 12:00 pm" Then
                    d1 = satBrokenHoursFrom
                    d2 = satBrokenHoursTo
                    If .saturday And chkSat.Checked And _
                                    ((d1 >= .satfrom And d1 <= .satto) _
                                        Or (d2 >= .satfrom And d2 <= .satto) _
                                        Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", False)) _
                                        Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sat", False)) _
                                    ) Then




                        If .teacherid = Me.m_Teacher Or .resource = m_Resource _
                            Or clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sat") = mResourceSat Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                             And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sat") = mResourceSat Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If

                End If


                ''SUNDAY
                If Not sunBrokenHoursFrom = "2/11/2007 12:01 pm" Or Not sunBrokenHoursTo = "2/11/2007 12:00 pm" Then

                    d1 = sunBrokenHoursFrom
                    d2 = sunBrokenHoursTo
                    If .sunday And chkSun.Checked And _
                                  ((d1 >= .sunfrom And d1 <= .sunto) _
                                      Or (d2 >= .sunfrom And d2 <= .sunto) _
                                      Or (d1 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", True) And d1 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", False)) _
                                      Or (d2 >= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", True) And d2 <= clsTool.GetSYOfferBrokenHoursByDay(.syofferingpk, "sun", False)) _
                                  ) Then



                        If .teacherid = Me.m_Teacher Or .resource = m_Resource _
                            Or clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sun") = mResourceSun Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(.teacherid) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                        If .resource = m_Resource _
                             And clsTool.getSYOfferResourceIDbyDay(.syofferingpk, "sun") = mResourceSun Then

                            If IsEdit Then
                                If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            Else
                                MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Result.HasNoConflict = False
                            End If
                        End If

                    End If
                End If


            End With
        Next

        'for this Form usage 
        m_ConflictMatrix = Result

        Return Result

    End Function

    'NO NEED , integrated everything to CheckConflict Above
    Function CheckResource() As Boolean
        Dim ctr As Integer
        Dim d1 As Date
        Dim d2 As Date
        For ctr = 0 To Me.m_dsSY.Rows.Count - 1
            With m_dsSY(ctr)
                d1 = DateTimePicker1.Value
                d2 = DateTimePicker2.Value
                If .monday And chkMon.Checked And ((d1 >= .monfrom And d1 <= .monto) Or (d2 >= .monfrom And d2 <= .monto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker3.Value
                d2 = DateTimePicker4.Value
                If .tuesday And chkTue.Checked And ((d1 >= .tuesfrom And d1 <= .tuesto) Or (d2 >= .tuesfrom And d2 <= .tuesto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker5.Value
                d2 = DateTimePicker6.Value
                If .wednesday And chkWed.Checked And ((d1 >= .wedfrom And d1 <= .wedto) Or (d2 >= .wedfrom And d2 <= .wedto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker7.Value
                d2 = DateTimePicker8.Value
                If .thursday And chkThu.Checked And ((d1 >= .thufrom And d1 <= .thuto) Or (d2 >= .thufrom And d2 <= .thuto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker9.Value
                d2 = DateTimePicker10.Value
                If .friday And chkFri.Checked And chkAltFri.Checked And ((d1 >= .frifrom And d1 <= .frito) Or (d2 >= .frifrom And d2 <= .frito)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker11.Value
                d2 = DateTimePicker12.Value
                If .saturday And chkSat.Checked And ((d1 >= .satfrom And d1 <= .satto) Or (d2 >= .satfrom And d2 <= .satto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
                d1 = DateTimePicker13.Value
                d2 = DateTimePicker14.Value
                If .sunday And chkMon.Checked And ((d1 >= .sunfrom And d1 <= .sunto) Or (d2 >= .sunfrom And d2 <= .sunto)) Then
                    If .resource = Me.m_Resource Then
                        If IsEdit Then
                            If .syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        Else
                            MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(.resource) & "-" & clsTool.GetSubjectDescription(.subjectpk)) : Return False
                        End If
                    End If
                End If
            End With
        Next
        Return True
    End Function

    'NO NEED? syofferings are being compared so we get it there
    'When a detail is changed in the SYOffering, check for conflicts of existing enrolled students!
    Function CheckConflictWithExistingStudents() As Boolean
        If IsEdit Then
            'get the class of enrolled student
            Dim ds As dsRegistrar.ClassListDataTable = StoreSYOfferings.GetSYOfferingStudents(m_Sem, m_YearPK, m_PriKey)
            'loop each student in the outer loop
            Dim i, j As Integer
            If ds.Rows.Count <= 0 Then Return False

            For i = 0 To ds.Rows.Count - 1
                Dim studentCursor As Integer = ds(i).studentpk
                'then inner loop is to iterate the sections where Student is enrolled with
                Dim ds2 As dsRep.EnrollSubjectsbyStudentSemYrPkDataTable = StoreSYOfferings.GetStudentClassSked(m_Sem, m_YearPK, studentCursor)
                For Each Item As dsRep.EnrollSubjectsbyStudentSemYrPkRow In ds2
                    'check if current section is same with this forms section, continue if so
                    If Item.syofferingpk = m_PriKey Then Continue For
                    'now get the section details

                Next

            Next

        End If
        Return False
    End Function
  
#End Region

#Region "OLD CODE for Conflict Check"
    Function checkMondayTeacher() As Boolean


        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherMonTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherMon, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker1.Value)
        If dsmon.SYOfferingTeacherMon.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherMon(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherMon, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker2.Value)
        If dsmon.SYOfferingTeacherMon.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherMon(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkTuesdayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherTueTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherTue, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker3.Value)
        If dsmon.SYOfferingTeacherTue.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherTue(0).syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherTue, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker4.Value)
        If dsmon.SYOfferingTeacherTue.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherTue(0).syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Tuesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkWednesdayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherWedTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherWed, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker5.Value)
        If dsmon.SYOfferingTeacherWed.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherWed(0).syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherWed, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker6.Value)
        If dsmon.SYOfferingTeacherWed.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherWed(0).syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Wednesday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkThursdayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherThursTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherThurs, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker7.Value)
        If dsmon.SYOfferingTeacherThurs.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherThurs(0).syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherThurs, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker8.Value)
        If dsmon.SYOfferingTeacherThurs.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherThurs(0).syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Thursday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkFridayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherFriTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherFri, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker9.Value)
        If dsmon.SYOfferingTeacherFri.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherFri(0).syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherFri, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker10.Value)
        If dsmon.SYOfferingTeacherFri.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherFri(0).syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Friday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkSaturdayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherSatTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherSat, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker11.Value)
        If dsmon.SYOfferingTeacherSat.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherSat(0).syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherSat, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker12.Value)
        If dsmon.SYOfferingTeacherSat.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherSat(0).syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Saturday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkSundayTeacher() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingTeacherSunTableAdapter
        dtmon.Fill(dsmon.SYOfferingTeacherSun, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker13.Value)
        If dsmon.SYOfferingTeacherSun.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherSun(0).syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Sunday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingTeacherSun, clsTool.GetCurYearPK(), m_Sem, Me.m_Teacher, DateTimePicker14.Value)
        If dsmon.SYOfferingTeacherSun.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingTeacherSun(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getTeacherName(Me.m_Teacher)) : Return False
            End If
        End If
        Return True
    End Function

    Function checkMondayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceMonTableAdapter
        Dim r1 As Integer = clsTool.GetCurYearPK()
        Dim r2 As Integer = m_Sem

        dtmon.Fill(dsmon.SYOfferingResourceMon, clsTool.GetCurYearPK(), Me.m_Sem, Me.m_Resource, CDate(DateTimePicker1.Value))
        If dsmon.SYOfferingResourceMon.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceMon(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceMon, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker2.Value)
        If dsmon.SYOfferingResourceMon.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceMon(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkTuesdayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceTuesTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceTues, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker3.Value)
        If dsmon.SYOfferingResourceTues.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceTues(0).syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceTues, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker4.Value)
        If dsmon.SYOfferingResourceTues.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceTues(0).syofferingpk <> m_PriKey Then MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Tuesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkWednesdayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceWedTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceWed, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker5.Value)
        If dsmon.SYOfferingResourceWed.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceWed(0).syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceWed, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker6.Value)
        If dsmon.SYOfferingResourceWed.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceWed(0).syofferingpk <> m_PriKey Then MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Wednesday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkThursdayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceThursTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceThurs, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker7.Value)
        If dsmon.SYOfferingResourceThurs.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceThurs(0).syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceThurs, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker8.Value)
        If dsmon.SYOfferingResourceThurs.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceThurs(0).syofferingpk <> m_PriKey Then MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Thursday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkFridayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceFriTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceFri, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker9.Value)
        If dsmon.SYOfferingResourceFri.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceFri(0).syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceFri, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker10.Value)
        If dsmon.SYOfferingResourceFri.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceFri(0).syofferingpk <> m_PriKey Then MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Friday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkSaturdayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceSatTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceSat, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker11.Value)
        If dsmon.SYOfferingResourceSat.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceSat(0).syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceSat, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker12.Value)
        If dsmon.SYOfferingResourceSat.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceSat(0).syofferingpk <> m_PriKey Then MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Saturday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function
    Function checkSundayResource() As Boolean
        Dim dsmon As New dsSchool
        Dim dtmon As New dsSchoolTableAdapters.SYOfferingResourceSunTableAdapter
        dtmon.Fill(dsmon.SYOfferingResourceSun, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker13.Value)
        If dsmon.SYOfferingResourceSun.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceSun(0).syofferingpk <> m_PriKey Then MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Sunday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        dtmon.Fill(dsmon.SYOfferingResourceSun, clsTool.GetCurYearPK(), m_Sem, Me.m_Resource, DateTimePicker14.Value)
        If dsmon.SYOfferingResourceSun.Rows.Count > 0 Then
            If IsEdit Then
                If dsmon.SYOfferingResourceSun(0).syofferingpk <> m_PriKey Then MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            Else
                MsgBox("Monday schedule conflicts for " & clsTool.getResourceName(Me.m_Resource)) : Return False
            End If
        End If
        Return True
    End Function

#End Region

#Region "MAIN EVENTS"


    'Save button
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.m_Subject = -1 Then MsgBox("Please select subject") : Exit Sub
        If Me.m_Resource = -1 Then MsgBox("Resource cannot be empty!") : Exit Sub
        If Not chkMon.Checked And Not chkTue.Checked And Not chkWed.Checked And Not chkThu.Checked And Not chkFri.Checked And Not chkSat.Checked And Not chkSun.Checked Then MsgBox("Please select schedule") : Exit Sub
        If Not IsNumeric(TextBox5.Text) Then MsgBox("Mininum number of students should be numeric!") : TextBox5.Focus() : Exit Sub
        If Not IsNumeric(TextBox6.Text) Then MsgBox("Maximum number of students should be numeric!") : TextBox6.Focus() : Exit Sub
        Dim min As Integer = Convert.ToInt32(TextBox5.Text)
        Dim max As Integer = Convert.ToInt32(TextBox6.Text)
        If min < 1 Then MsgBox("Mininum number of students should be greater than zero!") : Exit Sub
        If max < 1 Then MsgBox("Maximum number of students should be greater than zero!") : Exit Sub
        If max < min Then MsgBox("Maximum cannot be less than minimum!") : TextBox6.Focus() : Exit Sub
        'ben10.2.2007 . Teacher not empty
        If Me.m_Teacher = -1 Then MsgBox("Please select teacher") : Exit Sub

        'Section below was commented out previously. Maybe because to allow multiple creation of SYOffering to simulate fused sections??
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()

        'test for NO CONFLICT on teacher and resource. False return means has conflict
        If Not Me.CheckConflict(m_dsSY).HasNoConflict Then ''Or Not Me.CheckResource Then
            'ask user if still proceed with saving even with conflicts. if Not OK or NOT PROCEED, exit sub
            If MsgBox("There were conflicts, changes will not be saved. Press Cancel if you want to view Conflicts with current Students.", MsgBoxStyle.OkCancel, "Conflict!") = MsgBoxResult.Cancel Then
                frm.Hide()

                REM TO DO. this is a nuisance. find another way to message this.
                ''If MsgBox("Would you like to view if there are conflicting student schedules?", MsgBoxStyle.OkCancel, "View Student Conflicts") = MsgBoxResult.Ok Then
                ShowConflictingStudents()
                ''End If

                Exit Sub
            Else
                frm.Hide()
            End If

        Else
            REM TO DO. this is a nuisance. find another way to message this.
            ''it is possible that current section has no conflicts with Teacher and Resource, but Enrolled Students have
            ''so test it here
            If m_ConflictMatrix.ListOfSyOfferings.Count > 0 Then
                If MsgBox("No conflicts with Teacher and Resource, but there are possible Student Schedule conflicts. View Conflicts?", MsgBoxStyle.OkCancel, "View Student Conflicts") = MsgBoxResult.Ok Then
                    ShowConflictingStudents()
                    frm.Hide()
                    Exit Sub
                End If
            End If

            IsDirty = True

            frm.Hide()

            Me.Hide()
        End If

        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Subject = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.TextBox1.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ''Dim frm As New frmSchoolResourcesSelect
        ''frm.ShowDialog()
        ''If frm.Selected Then
        ''    Me.m_Resource = frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position).ResourcePrikey
        ''    Me.TextBox2.Text = frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position).ResourceName
        ''End If

        OpenFormResourceSelect(0)
    End Sub

    Sub OpenFormResourceSelect(ByVal _day As Int16)
        Dim frm As New frmSchoolResourcesSelect
        frm.ShowDialog()
        ''If frm.Selected Then
        ''    Me.m_Resource = frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position).ResourcePrikey
        ''    Me.TextBox2.Text = frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position).ResourceName
        ''End If

        If frm.Selected Then
            With frm.DsSchool.SchoolResourcesbyCName(frm.SchoolResourcesbyCNameBindingSource.Position)


                Select Case _day
                    Case 1
                        mResourceMon = .ResourcePrikey
                        txtResourceMon.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 2
                        mResourceTue = .ResourcePrikey
                        txtResourceTue.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 3
                        mResourceWed = .ResourcePrikey
                        txtResourceWed.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 4
                        mResourceThu = .ResourcePrikey
                        txtResourceThu.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 5
                        mResourceFri = .ResourcePrikey
                        txtResourceFri.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 6
                        mResourceSat = .ResourcePrikey
                        txtResourceSat.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case 7
                        mResourceSun = .ResourcePrikey
                        txtResourceSun.Text = .ResourceName
                        m_Resource = .ResourcePrikey
                    Case Else
                        m_Resource = .ResourcePrikey
                End Select

                m_strResource = .ResourceName
            End With
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmTeachersSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_Teacher = frm.DsSchool.TeachersbyCName(frm.TeachersbyCNameBindingSource.Position).TeacherPriKey
            Me.TextBox3.Text = frm.DsSchool.TeachersbyCName(frm.TeachersbyCNameBindingSource.Position).Name
        End If
    End Sub
    'btnMon
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpenFormResourceSelect(1)
    End Sub

    'Tue
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        OpenFormResourceSelect(2)
    End Sub
    'Wed
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        OpenFormResourceSelect(3)
    End Sub
    'Thu
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        OpenFormResourceSelect(4)
    End Sub
    'Fri
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        OpenFormResourceSelect(5)
    End Sub
    'Sat
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        OpenFormResourceSelect(6)
    End Sub
    'Sun
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        OpenFormResourceSelect(7)
    End Sub

    'CLOSE BUTTON
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region

#Region "Checkbox events. Copy Time and Room by default if day is checked"

    REM just copy Time but not the date.. Mon is 2/5/2007, Tue 2/6/2007, so on so forth
    Private Sub chkMon_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMon.CheckedChanged
        If chkMon.Checked Then
            mResourceMon = m_Resource
            txtResourceMon.Text = m_strResource
        Else
            mResourceMon = 0
            txtResourceMon.Text = ""
        End If
    End Sub


    Private Sub chkTue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTue.CheckedChanged
        If chkTue.Checked Then
            mResourceTue = m_Resource
            txtResourceTue.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker3.Value = "2/6/2007 " & time1
                DateTimePicker4.Value = "2/6/2007 " & time2

            End If
        Else
            mResourceTue = 0
            txtResourceTue.Text = ""
        End If
    End Sub

    Private Sub chkWed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWed.CheckedChanged
        If chkWed.Checked Then
            mResourceWed = m_Resource
            txtResourceWed.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker5.Value = "2/7/2007 " & time1
                DateTimePicker6.Value = "2/7/2007 " & time2

                'else copy from tue
            ElseIf chkTue.Checked Then

                Dim time1 As String = DateTimePicker3.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker4.Value.ToShortTimeString

                DateTimePicker5.Value = "2/7/2007 " & time1
                DateTimePicker6.Value = "2/7/2007 " & time2

            End If
        Else
            mResourceWed = 0
            txtResourceWed.Text = ""
        End If
    End Sub

    Private Sub chkThu_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkThu.CheckedChanged
        If chkThu.Checked Then
            mResourceThu = m_Resource
            txtResourceThu.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker7.Value = "2/8/2007 " & time1
                DateTimePicker8.Value = "2/8/2007 " & time2
                'else copy from tue
            ElseIf chkTue.Checked Then
                Dim time1 As String = DateTimePicker3.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker4.Value.ToShortTimeString

                DateTimePicker7.Value = "2/8/2007 " & time1
                DateTimePicker8.Value = "2/8/2007 " & time2
                
            ElseIf chkWed.Checked Then
                Dim time1 As String = DateTimePicker5.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker6.Value.ToShortTimeString

                DateTimePicker7.Value = "2/8/2007 " & time1
                DateTimePicker8.Value = "2/8/2007 " & time2

               
            End If
        Else
            mResourceThu = 0
            txtResourceThu.Text = ""
        End If
    End Sub

    Private Sub chkFri_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFri.CheckedChanged
        If chkFri.Checked Then
            mResourceFri = m_Resource
            txtResourceFri.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker9.Value = "2/9/2007 " & time1
                DateTimePicker10.Value = "2/9/2007 " & time2

                'else copy from tue
            ElseIf chkTue.Checked Then
                Dim time1 As String = DateTimePicker3.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker4.Value.ToShortTimeString

                DateTimePicker9.Value = "2/9/2007 " & time1
                DateTimePicker10.Value = "2/9/2007 " & time2
            ElseIf chkWed.Checked Then
                Dim time1 As String = DateTimePicker5.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker6.Value.ToShortTimeString

                DateTimePicker9.Value = "2/9/2007 " & time1
                DateTimePicker10.Value = "2/9/2007 " & time2
            ElseIf chkThu.Checked Then
                Dim time1 As String = DateTimePicker7.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker8.Value.ToShortTimeString

                DateTimePicker9.Value = "2/9/2007 " & time1
                DateTimePicker10.Value = "2/9/2007 " & time2
               
            End If
        Else
            mResourceFri = 0
            txtResourceFri.Text = ""
        End If

    End Sub

    Private Sub chkSat_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSat.CheckedChanged
        If chkSat.Checked Then
            mResourceSat = m_Resource
            txtResourceSat.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker11.Value = "2/10/2007 " & time1
                DateTimePicker12.Value = "2/10/2007 " & time2
                'else copy from tue
            ElseIf chkTue.Checked Then
                Dim time1 As String = DateTimePicker3.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker4.Value.ToShortTimeString

                DateTimePicker11.Value = "2/10/2007 " & time1
                DateTimePicker12.Value = "2/10/2007 " & time2
            ElseIf chkWed.Checked Then
                Dim time1 As String = DateTimePicker5.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker6.Value.ToShortTimeString

                DateTimePicker11.Value = "2/10/2007 " & time1
                DateTimePicker12.Value = "2/10/2007 " & time2
            ElseIf chkThu.Checked Then
                Dim time1 As String = DateTimePicker7.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker8.Value.ToShortTimeString

                DateTimePicker11.Value = "2/10/2007 " & time1
                DateTimePicker12.Value = "2/10/2007 " & time2
            ElseIf chkFri.Checked Then
                Dim time1 As String = DateTimePicker9.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker10.Value.ToShortTimeString

                DateTimePicker11.Value = "2/10/2007 " & time1
                DateTimePicker12.Value = "2/10/2007 " & time2
            End If
        Else
            mResourceSat = 0
            txtResourceSat.Text = ""
        End If
    End Sub

    Private Sub chkSun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSun.CheckedChanged
        If chkSun.Checked Then
            mResourceSun = m_Resource
            txtResourceSun.Text = m_strResource
            'copy time from Mon
            If chkMon.Checked Then
                Dim time1 As String = DateTimePicker1.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker2.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

                'else copy from tue
            ElseIf chkTue.Checked Then
                Dim time1 As String = DateTimePicker3.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker4.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

            ElseIf chkWed.Checked Then
                Dim time1 As String = DateTimePicker5.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker6.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

            ElseIf chkThu.Checked Then
                Dim time1 As String = DateTimePicker7.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker8.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

            ElseIf chkFri.Checked Then
                Dim time1 As String = DateTimePicker9.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker10.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

            ElseIf chkSat.Checked Then
                Dim time1 As String = DateTimePicker11.Value.ToShortTimeString
                Dim time2 As String = DateTimePicker12.Value.ToShortTimeString

                DateTimePicker13.Value = "2/11/2007 " & time1
                DateTimePicker14.Value = "2/11/2007 " & time2

            End If
        Else
            mResourceSun = 0
            txtResourceSun.Text = ""
        End If
    End Sub


    Private Sub chkSpecialTutorial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpecialTutorial.CheckedChanged

        If chkSpecialTutorial.Checked Then
            'also check REQUESTED just to make sure
            chkRequested.Checked = True
        End If

    End Sub
#End Region

#Region "Broken Hours"

    'frm.referenceFrom has no use??

    Private Sub btnExtraHoursMon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursMon.Click

        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Monday"

        'set the values
        frm.DateTimePicker1.Value = monBrokenHoursFrom
        frm.DateTimePicker2.Value = monBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker1.Value
        frm.referenceTo = DateTimePicker2.Value

        frm.ShowDialog()

        If frm.isDirty Then
            monBrokenHoursFrom = frm.DateTimePicker1.Value
            monBrokenHoursTo = frm.DateTimePicker2.Value

        End If

    End Sub

    Private Sub btnExtraHoursTue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursTue.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Tuesday"

        'set the values
        frm.DateTimePicker1.Value = tueBrokenHoursFrom
        frm.DateTimePicker2.Value = tueBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker3.Value
        frm.referenceTo = DateTimePicker4.Value

        frm.ShowDialog()

        If frm.isDirty Then
            tueBrokenHoursFrom = frm.DateTimePicker1.Value
            tueBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    Private Sub btnExtraHoursWed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursWed.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Wednesday"

        'set the values
        frm.DateTimePicker1.Value = wedBrokenHoursFrom
        frm.DateTimePicker2.Value = wedBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker5.Value
        frm.referenceTo = DateTimePicker6.Value

        frm.ShowDialog()

        If frm.isDirty Then
            wedBrokenHoursFrom = frm.DateTimePicker1.Value
            wedBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    Private Sub btnExtraHoursThu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursThu.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Thursday"

        'set the values
        frm.DateTimePicker1.Value = thuBrokenHoursFrom
        frm.DateTimePicker2.Value = thuBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker7.Value
        frm.referenceTo = DateTimePicker8.Value

        frm.ShowDialog()

        If frm.isDirty Then
            thuBrokenHoursFrom = frm.DateTimePicker1.Value
            thuBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    Private Sub btnExtraHoursFri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursFri.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Friday"

        'set the values
        frm.DateTimePicker1.Value = friBrokenHoursFrom
        frm.DateTimePicker2.Value = friBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker9.Value
        frm.referenceTo = DateTimePicker10.Value

        frm.ShowDialog()

        If frm.isDirty Then
            friBrokenHoursFrom = frm.DateTimePicker1.Value
            friBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    Private Sub btnExtraHoursSat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursSat.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Saturday"

        'set the values
        frm.DateTimePicker1.Value = satBrokenHoursFrom
        frm.DateTimePicker2.Value = satBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker11.Value
        frm.referenceTo = DateTimePicker12.Value

        frm.ShowDialog()

        If frm.isDirty Then
            satBrokenHoursFrom = frm.DateTimePicker1.Value
            satBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    Private Sub btnExtraHoursSun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtraHoursSun.Click
        Dim frm As New frmBrokenHours
        frm.TextBox1.Text = "Sunday"

        'set the values
        frm.DateTimePicker1.Value = sunBrokenHoursFrom
        frm.DateTimePicker2.Value = sunBrokenHoursTo

        'now pass the current First Entry
        frm.referenceFrom = DateTimePicker13.Value
        frm.referenceTo = DateTimePicker14.Value

        frm.ShowDialog()

        If frm.isDirty Then
            sunBrokenHoursFrom = frm.DateTimePicker1.Value
            sunBrokenHoursTo = frm.DateTimePicker2.Value

        End If
    End Sub

    'CLEAR ALL BROKEN HOURS.. set to default times so it wont be saved
    Private Sub btnClearBroken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearBroken.Click

        InitializeBrokenHours()
    End Sub

#End Region

#Region "Subject Fusing"

    ''What is Fused Subject help button click
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        MsgBox("Fused Subjects are those that represent the same SUBJECT MATTER but are named or described differently in their respective curriculums.", MsgBoxStyle.Information)

    End Sub


    Private Sub btnMap1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap1.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK1 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused1.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap2.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK2 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused2.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub btnMap3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap3.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK3 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused3.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub btnMap4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap4.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK4 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused4.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub btnMap5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap5.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK5 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused5.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub btnMap6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap6.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK6 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused6.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub

    Private Sub btnMap7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap7.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK7 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused7.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap8.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK8 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused8.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap9.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK9 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused9.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap10.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK10 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused10.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap11.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK11 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused11.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
    Private Sub btnMap12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap12.Click
        Dim frm As New frmSubjectsSelect
        frm.TextBox1.Select()
        frm.ShowDialog()
        If frm.Selected Then
            Me.m_fusedSubjectPK12 = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectPriKey
            Me.txtFused12.Text = frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectCode & "-" & frm.DsSchool.SubjectsByCName(frm.SubjectsByCNameBindingSource.Position).SubjectName
        End If
    End Sub
#End Region

#Region "STUDENT CONFLICTS"

    Sub ShowConflictingStudents()

        'show the button to allow user to view again
        btnViewConflictStudents.Visible = True

        'Get list of this Form's SY's Enrolled Students
        Dim ds As dsRegistrar.ClassListDataTable = StoreSYOfferings.GetSYOfferingStudents(m_Sem, m_YearPK, m_PriKey)

        'iterate the ConflictMatrix for all unique syofferingPKs
        Dim arrUniqueSYPKS(Me.m_ConflictMatrix.ListOfSyOfferings.Count()) As Integer
        Dim uniqueCounter As Integer = 0
        For Each sypk As Integer In m_ConflictMatrix.ListOfSyOfferings
            If Array.IndexOf(arrUniqueSYPKS, sypk) = -1 Then
                arrUniqueSYPKS(uniqueCounter) = sypk
                uniqueCounter += 1
            End If
        Next

        'Get Students of the unique syofferingPKs 
        Dim ListOfConflictingStudents As New List(Of StudentSectionMatrix)
        For Each sypk As Integer In arrUniqueSYPKS
            If sypk > 0 And sypk <> m_PriKey Then

                Dim ds2 As dsRegistrar.ClassListDataTable = StoreSYOfferings.GetSYOfferingStudents(m_Sem, m_YearPK, sypk)
                'Now MATCH the two ClassList Datasets. those that exist in both list are ConflictingStudents
                For Each dsrow As dsRegistrar.ClassListRow In ds
                    Dim studentCursor As Integer = dsrow.studentpk
                    'check if studentCursor is in ds2
                    For Each dsrow2 As dsRegistrar.ClassListRow In ds2
                        If dsrow2.studentpk = studentCursor Then
                            Dim syofferCursor As Integer = dsrow2.syofferingpk
                            Dim syofferSubject As String = clsTool.GetSubjectDescription(clsTool.getSYOffering(syofferCursor).subjectpk)
                            Dim syofferSked As String = clsTool.getSYOfferFullSked(syofferCursor)
                            Dim aStudentSectionMatrix As New StudentSectionMatrix

                            aStudentSectionMatrix.StudentID = studentCursor
                            aStudentSectionMatrix.StudentName = clsTool.getStudentName(studentCursor)
                            aStudentSectionMatrix.SYOfferingID = dsrow2.syofferingpk
                            aStudentSectionMatrix.SYOfferingName = syofferSubject & " " & syofferSked
                            ListOfConflictingStudents.Add(aStudentSectionMatrix)
                        End If
                    Next
                Next
            End If
        Next

        'Now Show Form
        Dim frm As New frmConflictStudents

        Dim m_sked As String = clsTool.getSYOfferFullSked(m_PriKey)
        frm.Text = "Conflicting Schedules against " & Me.TextBox1.Text & " " & m_sked

        'initialize datatable
        Dim dt = New DataTable()
        Dim dcStudentName = New DataColumn("StudentName", GetType(String))
        Dim dcSYSection = New DataColumn("SectionName", GetType(String))

        dt.Columns.Add(dcStudentName)
        dt.Columns.Add(dcSYSection)
        'add values to rows
        For i = 0 To ListOfConflictingStudents.Count() - 1
            With ListOfConflictingStudents(i)
                dt.Rows.Add(.StudentName, .SYOfferingName)
            End With
        Next

        'set datagrid source
        frm.DataGridView1.DataSource = dt
        frm.Show()

    End Sub

    Private Sub btnViewConflictStudents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewConflictStudents.Click
        ShowConflictingStudents()
    End Sub

    
#End Region


End Class

#Region "MODELS"
Public Class ConflictMatrix

    Public ListOfSyOfferings As List(Of Integer)
    Public HasNoConflict As Boolean

End Class

Public Class StudentSectionMatrix
    Public StudentID As Integer
    Public StudentName As String
    Public SYOfferingID As Integer
    Public SYOfferingName As String
End Class

#End Region