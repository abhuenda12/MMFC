
Public Class clsTool
    Public Shared Sub SaveUserRights(ByVal user As Integer, ByVal key As String, ByVal value As Integer)
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUserRightsTableAdapter
        dt.Fill(ds.AppUserRights, user, key)
        If ds.AppUserRights.Rows.Count = 0 Then
            ds.AppUserRights.AddAppUserRightsRow(user, key, value)
        Else
            ds.AppUserRights(0).RightsValue = value
        End If
        dt.Update(ds.AppUserRights)
    End Sub
    Public Shared Function UserRights(ByVal user As Integer, ByVal key As String) As Integer
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUserRightsTableAdapter
        dt.Fill(ds.AppUserRights, user, key)
        If ds.AppUserRights.Rows.Count = 0 Then Return 0
        Return ds.AppUserRights(0).RightsValue
    End Function
    Public Shared Function getClassTeacher(ByVal id As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count = 0 Then Return ""
        Return clsTool.getTeacherName(ds.SYOfferingbyPK(0).teacherid)
    End Function
    Public Shared Function getClassTeacherPK(ByVal id As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count = 0 Then Return -1
        Return ds.SYOfferingbyPK(0).teacherid
    End Function
    Public Shared Function getClassResource(ByVal id As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count = 0 Then Return ""
        Return clsTool.getResourceName(ds.SYOfferingbyPK(0).resource)
    End Function

    REM Modified / Added... Special Tutorial type will also have T as type 
    Public Shared Function getClassType(ByVal syofferpk As Integer, Optional ByVal sempk As Integer = -1, _
                                          Optional ByVal sypk As Integer = -1) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        Dim isRequested As Boolean = False
        Dim isSpecialTutorial As Boolean = False

        dt.Fill(ds.SYOfferingbyPK, syofferpk)

        'if no results just return R which is default
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return "R" 'Regular

        If ds.SYOfferingbyPK(0).IsrequestedNull Then ds.SYOfferingbyPK(0).requested = False

        ''If ds.SYOfferingbyPK(0).requested Then Return "RQ" 'Requested
        If ds.SYOfferingbyPK(0).requested Then isRequested = True

        'Test for Special Tutorial. No need for closed enrollment to determine this.
        If ds.SYOfferingbyPK(0).IsisSpecialTutorialNull Then ds.SYOfferingbyPK(0).isSpecialTutorial = False

        If ds.SYOfferingbyPK(0).isSpecialTutorial Then isSpecialTutorial = True

        'Combine RQ and T conditions
        If isSpecialTutorial Then
            Return "T"
        ElseIf isRequested And Not isSpecialTutorial Then
            Return "RQ"

        End If

        
        'Ben . 3.27.2008 . test for Tutorial .
        'syoffer is closed , enrolled count is less than minimum .
        Dim enrolledcount As Integer = getStudentCount(sempk, sypk, syofferpk)

        If ds.SYOfferingbyPK(0).IsclosedNull Then ds.SYOfferingbyPK(0).closed = False

        If enrolledcount < ds.SYOfferingbyPK(0).MinStudents And _
                                      ds.SYOfferingbyPK(0).closed Then
            Return "T"
        End If

        Return "R"

    End Function


    'ben10.11.2007 .. a.k.a getClassRoomID
    'will get the Room ID (not the Room pk) using the syoffer(resource)
    Public Shared Function getClassResourceID(ByVal syofferpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count = 0 Then Return ""
        Return clsTool.getResourceID(ds.SYOfferingbyPK(0).resource)
    End Function

    'ben10.9.2007  . copied from uSYOffering 
    Public Shared Function GetClassSchedule(ByVal syofferpk As Integer) As String
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""
        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)
        Dim s As String = ""
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

        Return s
    End Function

#Region "SY Offering Methods"


    'ben10.11.2007 . As requested by client. This will just get the class start time of 1st occurence . 
    'if the start time is different on the other days , this will be inconsistent
    Public Shared Function getSYOfferStart(ByVal syofferpk As Integer) As String
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""
        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)        
        If r.monday Then Return clsTool.getTime(CDate(r.monfrom))
        If r.tuesday Then Return clsTool.getTime(CDate(r.tuesfrom))
        If r.wednesday Then Return clsTool.getTime(CDate(r.wedfrom))
        If r.thursday Then Return clsTool.getTime(CDate(r.thufrom))
        If r.friday Then Return clsTool.getTime(CDate(r.frifrom))
        If r.saturday Then Return clsTool.getTime(CDate(r.satfrom))
        If r.sunday Then Return clsTool.getTime(CDate(r.sunfrom))
        Return ""
    End Function
    Public Shared Function getSYOfferEnd(ByVal syofferpk As Integer) As String
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""
        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)
        If r.monday Then Return clsTool.getTime(CDate(r.monto))
        If r.tuesday Then Return clsTool.getTime(CDate(r.tuesto))
        If r.wednesday Then Return clsTool.getTime(CDate(r.wedto))
        If r.thursday Then Return clsTool.getTime(CDate(r.thuto))
        If r.friday Then Return clsTool.getTime(CDate(r.frito))
        If r.saturday Then Return clsTool.getTime(CDate(r.satto))
        If r.sunday Then Return clsTool.getTime(CDate(r.sunto))
        Return ""
    End Function

    'test if an syoffering has different hours for at least 2 days
    'test the FROM time only , no need to test TO time
    Public Shared Function CheckSYOfferHasDifferentTimeSkeds(ByVal syofferpk As Integer) As Boolean
        Dim result As Boolean = False

        'fill syoffer table
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return result

        Dim montime, tuetime, wedtime, thutime, fritime, sattime, suntime As Date
        Dim montime2, tuetime2, wedtime2, thutime2, fritime2, sattime2, suntime2 As Date

        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)

        If r.monday Then
            montime = CDate(r.monfrom)
            montime2 = CDate(r.monto)
        End If


        If r.tuesday Then
            tuetime = CDate(r.tuesfrom)
            tuetime2 = CDate(r.tuesto)

            'compare with monday , time only not date
            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = tuetime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = tuetime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True

            End If
        End If

        If r.wednesday Then
            wedtime = r.wedfrom
            wedtime2 = r.wedto

            'compare with monday
            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = wedtime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = wedtime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with tuesday
            time1 = tuetime.ToShortTimeString
            time2 = wedtime.ToShortTimeString
            time3 = tuetime2.ToShortTimeString
            time4 = wedtime2.ToShortTimeString

            If r.tuesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

        End If

        If r.thursday Then
            thutime = r.thufrom
            thutime2 = r.thuto

            'compare with monday

            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = thutime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = thutime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

          
            'compare with tuesday
            time1 = tuetime.ToShortTimeString
            time2 = thutime.ToShortTimeString
            time3 = tuetime2.ToShortTimeString
            time4 = thutime2.ToShortTimeString

            If r.tuesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            
            'compare with wednesday
            time1 = wedtime.ToShortTimeString
            time2 = thutime.ToShortTimeString
            time3 = wedtime2.ToShortTimeString
            time4 = thutime2.ToShortTimeString

            If r.wednesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If
        End If

        If r.friday Then
            fritime = r.frifrom
            fritime2 = r.frito

            'compare with monday
            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = fritime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = fritime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with tuesday
            time1 = tuetime.ToShortTimeString
            time2 = fritime.ToShortTimeString
            time3 = tuetime2.ToShortTimeString
            time4 = fritime2.ToShortTimeString

            If r.tuesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with wednesday
            time1 = wedtime.ToShortTimeString
            time2 = fritime.ToShortTimeString
            time3 = wedtime2.ToShortTimeString
            time4 = fritime2.ToShortTimeString

            If r.wednesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with thursday
            time1 = thutime.ToShortTimeString
            time2 = fritime.ToShortTimeString
            time3 = thutime2.ToShortTimeString
            time4 = fritime2.ToShortTimeString

            If r.thursday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If
        End If
        

        If r.saturday Then
            sattime = r.satfrom
            sattime2 = r.satto

            'compare with monday
            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = sattime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = sattime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with tuesday
            time1 = tuetime.ToShortTimeString
            time2 = sattime.ToShortTimeString
            time3 = tuetime2.ToShortTimeString
            time4 = sattime2.ToShortTimeString

            If r.tuesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with wednesday
            time1 = wedtime.ToShortTimeString
            time2 = sattime.ToShortTimeString
            time3 = wedtime2.ToShortTimeString
            time4 = sattime2.ToShortTimeString

            If r.wednesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with thursday
            time1 = thutime.ToShortTimeString
            time2 = sattime.ToShortTimeString
            time3 = thutime2.ToShortTimeString
            time4 = sattime2.ToShortTimeString

            If r.thursday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with friday
            time1 = fritime.ToShortTimeString
            time2 = sattime.ToShortTimeString
            time3 = fritime2.ToShortTimeString
            time4 = sattime2.ToShortTimeString

            If r.friday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If
        End If

        If r.sunday Then
            suntime = r.sunfrom
            suntime2 = r.sunto

            'compare with monday
            Dim time1 As String = montime.ToShortTimeString
            Dim time2 As String = suntime.ToShortTimeString
            Dim time3 As String = montime2.ToShortTimeString
            Dim time4 As String = suntime2.ToShortTimeString

            If r.monday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with tuesday
            time1 = tuetime.ToShortTimeString
            time2 = suntime.ToShortTimeString
            time3 = tuetime2.ToShortTimeString
            time4 = suntime2.ToShortTimeString

            If r.tuesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If


            'compare with wednesday
            time1 = wedtime.ToShortTimeString
            time2 = suntime.ToShortTimeString
            time3 = wedtime2.ToShortTimeString
            time4 = suntime2.ToShortTimeString

            If r.wednesday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with thursday
            time1 = thutime.ToShortTimeString
            time2 = suntime.ToShortTimeString
            time3 = thutime2.ToShortTimeString
            time4 = suntime2.ToShortTimeString

            If r.thursday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with friday
            time1 = fritime.ToShortTimeString
            time2 = suntime.ToShortTimeString
            time3 = fritime2.ToShortTimeString
            time4 = suntime2.ToShortTimeString

            If r.friday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If

            'compare with saturday
            time1 = sattime.ToShortTimeString
            time2 = suntime.ToShortTimeString
            time3 = sattime2.ToShortTimeString
            time4 = suntime2.ToShortTimeString

            If r.saturday Then
                If time2 <> time1 Then Return True
                If time4 <> time3 Then Return True
            End If
        End If

        'Now check for broken hours
        Dim dsB As New dsRegistrar.SYOfferingExtraHoursByFKDataTable
        Dim dtB As New dsRegistrarTableAdapters.SYOfferingExtraHoursByFKTableAdapter
        dtB.Fill(dsB, syofferpk)
        If dsB.Rows.Count > 0 Then result = True

        Return result
    End Function

    'Show full sked of offering, return long string
    Public Shared Function getSYOfferFullSked(ByVal syofferpk As Integer) As String
        Dim result As String = ""

        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""

        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)

        If r.monday Then result &= ";Mon (" & clsTool.getTime(CDate(r.monfrom)) & "-" & clsTool.getTime(CDate(r.monto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "mon")
        If r.tuesday Then result &= ";Tue (" & clsTool.getTime(CDate(r.tuesfrom)) & "-" & clsTool.getTime(CDate(r.tuesto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "tue")
        If r.wednesday Then result &= ";Wed (" & clsTool.getTime(CDate(r.wedfrom)) & "-" & clsTool.getTime(CDate(r.wedto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "wed")
        If r.thursday Then result &= ";Thu (" & clsTool.getTime(CDate(r.thufrom)) & "-" & clsTool.getTime(CDate(r.thuto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "thu")
        If r.friday Then result &= ";Fri (" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "fri")
        If r.saturday Then result &= ";Sat (" & clsTool.getTime(CDate(r.satfrom)) & "-" & clsTool.getTime(CDate(r.satto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "sat")
        If r.sunday Then result &= ";Sun (" & clsTool.getTime(CDate(r.sunfrom)) & "-" & clsTool.getTime(CDate(r.sunto)) & " )" : result &= getSYOfferingBrokenHoursByDay(syofferpk, "sun")

        'remove leading ;
        result = result.Substring(1)

        Return result

    End Function

    Public Shared Function getSYOfferDays(ByVal syofferpk As Integer) As String
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""
        Dim r As dsRegistrar.SYOfferingbyPKRow = ds(0)
        Dim s As String = ""
        If r.monday Then s = s & "M"
        If r.tuesday Then s = s & "T"
        If r.wednesday Then s = s & "W"
        If r.thursday Then s = s & "Th"
        If r.friday Then s = s & "F"
        If r.saturday Then s = s & "Sa"
        If r.sunday Then s = s & "Su"
        Return s
    End Function
    Public Shared Function checkSkedforDay(ByVal syofferpk As Integer, ByVal day As String) As Boolean

        If syofferpk = -1 Then Return False
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count = 0 Then Return False
        Dim r As dsRegistrar.SYOfferingbyPKRow = ds.SYOfferingbyPK(0)

        Select Case day
            Case "Mon"
                If r.monday Then Return True Else Return False
            Case "Tue"
                If r.tuesday Then Return True Else Return False
            Case "Wed"
                If r.wednesday Then Return True Else Return False
            Case "Thu"
                If r.thursday Then Return True Else Return False
            Case "Fri"
                If r.friday Then Return True Else Return False
            Case "Sat"
                If r.saturday Then Return True Else Return False
            Case "Sun"
                If r.sunday Then Return True Else Return False
        End Select

        Return False
    End Function

    'get the broken hours sked of an syoffering
    Public Shared Function getSYOfferingBrokenHoursByDay(ByVal syofferpk As Integer, ByVal daytype As String) As String

        Dim result As String = ""

        Dim ds As New dsRegistrar.SYOfferingExtraHoursByFKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingExtraHoursByFKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return ""

        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).dayType = daytype Then
                result = "," & clsTool.getTime(CDate(ds(i).timeStart)) & "-" & clsTool.getTime(CDate(ds(i).timeEnd))
            End If
        Next

        Return result
    End Function

    'test for broken hours
    Public Shared Function CheckSYOfferHasBrokenHours(ByVal syofferpk As Integer, Optional ByVal day As String = "") As Boolean


        Dim ds As New dsRegistrar.SYOfferingExtraHoursByFKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingExtraHoursByFKTableAdapter
        dt.Fill(ds, syofferpk)

        If Not String.IsNullOrEmpty(day) Then

            REM check for exact day
            REM 4.18.2013. Loop the records not just the first one!
            If ds.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To ds.Rows.Count - 1
                    If ds(i).dayType = "mon" And day = "mon" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "tue" And day = "tue" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "wed" And day = "wed" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "thu" And day = "thu" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "fri" And day = "fri" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "sat" And day = "sat" And ds(i).inactive = False Then
                        Return True
                    ElseIf ds(i).dayType = "sun" And day = "sun" And ds(i).inactive = False Then
                        Return True
                    End If
                Next
                
            Else
                Return False
            End If
        Else
            If ds.Rows.Count <= 0 Then Return False Else Return True
        End If

        Return False


    End Function

    'Test for Fused Subjects type SYOffering . 8.26.2012
    Public Shared Function CheckSYOfferIsFusedSubjects(ByVal syofferpk As Integer) As Boolean
        Dim ds As New dsRegistrar.SYOfferingbyPKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds, syofferpk)
        If ds.Rows.Count <= 0 Then Return False
        If ds(0).IsisFusedNull Then ds(0).isFused = False
        Return ds(0).isFused

    End Function


    ''' <summary>
    ''' Gets the main/source subject for the caller syofferingpk and coursepk , for fused subjects
    ''' </summary>
    ''' <param name="syofferingpk"></param>    
    ''' <param name="coursepk"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFusedSubjectDescriptionByCoursePK(ByVal syofferingpk As Integer, ByVal coursepk As Integer, ByVal subjectpk As Integer) As String
        'first, get all mapped subjects from SYOfferingFusedSubjects
        Dim ds As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter
        dt.Fill(ds, syofferingpk)

        If ds.Rows.Count <= 0 Then Return GetSubjectDescription(subjectpk)

        'for those with only 1 result , return that row
        If ds.Rows.Count = 1 Then Return GetSubjectDescription(ds(0).subjectPK)

        'for those with multiple mapped subjects under 1 fused subject, 
        'get the subjectpk that exists  in the course/curriculm
        If ds.Rows.Count > 1 Then
            Dim dsreg As New dsReg2.CurriculumbyCoursebySubjectDataTable
            Dim dtreg As New dsReg2TableAdapters.CurriculumbyCoursebySubjectTableAdapter

            'loop the mapped subjects and match with curriculum
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                dtreg.Fill(dsreg, coursepk, ds(i).subjectPK)

                'if there are results, get the subject!
                If dsreg.Rows.Count > 0 Then
                    Return GetSubjectDescription(dsreg(0).Subjectpk)
                End If

            Next
           
            'for zero results just return default
            If dsreg.Rows.Count <= 0 Then

                Return GetSubjectDescription(subjectpk)
            Else
                'for 1 or greater, return first record ????

                ''''Return GetSubjectDescription(dsreg(0).Subjectpk)
            End If

        End If

        'for everything else by default just return the desc of subjectpk
        Return GetSubjectDescription(subjectpk)

    End Function

    ''' <summary>
    ''' Gets the Subject Code from the original curriculum
    ''' </summary>
    ''' <param name="syofferingpk"></param>
    ''' <param name="coursepk"></param>
    ''' <param name="subjectpk"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFusedSubjectCodeByCoursePK(ByVal syofferingpk As Integer, ByVal coursepk As Integer, ByVal subjectpk As Integer) As String
        'first, get all mapped subjects from SYOfferingFusedSubjects
        Dim ds As New dsRegistrar.SYOfferingFusedSubjectsByFKDataTable
        Dim dt As New dsRegistrarTableAdapters.SYOfferingFusedSubjectsByFKTableAdapter
        dt.Fill(ds, syofferingpk)

        If ds.Rows.Count <= 0 Then Return GetSubjectCode(subjectpk)

        'for those with only 1 result , return that row
        If ds.Rows.Count = 1 Then Return GetSubjectCode(ds(0).subjectPK)

        'for those with multiple mapped subjects under 1 fused subject, 
        'get the subjectpk that exists  in the course/curriculm
        If ds.Rows.Count > 1 Then
            Dim dsreg As New dsReg2.CurriculumbyCoursebySubjectDataTable
            Dim dtreg As New dsReg2TableAdapters.CurriculumbyCoursebySubjectTableAdapter

            'loop the mapped subjects and match with curriculum
            Dim i As Integer
            For i = 0 To ds.Rows.Count - 1
                dtreg.Fill(dsreg, coursepk, ds(i).subjectPK)

                'if there are results, get the subject!
                If dsreg.Rows.Count > 0 Then
                    Return GetSubjectCode(dsreg(0).Subjectpk)
                End If

            Next

            'for zero results just return default
            If dsreg.Rows.Count <= 0 Then

                Return GetSubjectCode(subjectpk)
            Else
                'for 1 or greater, return first record ????

                ''''Return GetSubjectDescription(dsreg(0).Subjectpk)
            End If

        End If

        'for everything else by default just return the desc of subjectpk
        Return GetSubjectCode(subjectpk)

    End Function
#End Region

    'ben9.30.2007
    Public Shared Function getSubjectCostTotal(ByVal enrollpk As Integer) As Double
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCostbyPKTableAdapter
        dt.Fill(ds.EnrollSubjectsCostbyPK, enrollpk)
        If ds.EnrollSubjectsCostbyPK.Rows.Count = 0 Then
            Return 0
        Else
            Dim sumamount As Double
            sumamount = ds.EnrollSubjectsCostbyPK.Compute("Sum(amount)", String.Empty)
            Return sumamount
        End If
    End Function
    'ben9.30.2007 .. for replacement of sqlcon string to delete all at once without looping
    Public Shared Sub DeleteSubjectCostbyPK(ByVal enrollpk As Integer)
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCostbyPKTableAdapter
        dt.Fill(ds.EnrollSubjectsCostbyPK, enrollpk)
        If ds.EnrollSubjectsCostbyPK.Rows.Count = 0 Then
            Exit Sub
        Else
            Dim i As Integer
            For i = 0 To ds.EnrollSubjectsCostbyPK.Rows.Count - 1
                Try
                    ds.EnrollSubjectsCostbyPK(i).Delete()
                Catch ex As Exception
                End Try
            Next
            dt.Update(ds.EnrollSubjectsCostbyPK)
        End If
    End Sub

    Public Shared Function getUnits(ByVal subject As Integer) As Double
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, subject)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then Return 0
        Return ds.SubjectsByPriKey(0).units
    End Function
    'ben9.30.2007
    Public Shared Function getLabUnits(ByVal subject As Integer) As Double
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, subject)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then Return 0
        If ds.SubjectsByPriKey(0).IslabunitsNull Then Return 0 Else Return ds.SubjectsByPriKey(0).labunits
    End Function

    '10.21.2011
    'RLE units for NCM subjects etc. differentiate from lab
    Public Shared Function getRLEUnits(ByVal subject As Integer) As Double
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, subject)
        If ds.SubjectsByPriKey.Rows.Count <= 0 Then Return 0
        Return ds.SubjectsByPriKey(0).RLEunits
    End Function

    'RLE plus Tuition Units. for white form purposes etc. since Units that should show should include RLE also
    Public Shared Function getRLEAndMainUnits(ByVal subject As Integer) As Double
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, subject)
        If ds.SubjectsByPriKey.Rows.Count <= 0 Then Return 0

        If ds.SubjectsByPriKey(0).IsRLEunitsNull Then ds.SubjectsByPriKey(0).RLEunits = 0

        Dim rle As Double = ds.SubjectsByPriKey(0).RLEunits

        Dim main As Double = ds.SubjectsByPriKey(0).units

        Return main + rle

    End Function


    '10.21.2011
    'Get all subject in curriculum by course, then return year level in the curriculum for said subject
    Public Shared Function getYearLevelInCurriculumByCourse(ByVal _subjectPK As Int16, ByVal _coursePK As Int16) As Integer

        Dim ds As New dsReg2.CurriculumbyCourseDataTable
        Dim dt As New dsReg2TableAdapters.CurriculumbyCourseTableAdapter

        dt.Fill(ds, _coursePK)
        Dim i As Integer
        If ds.Rows.Count <= 0 Then Return 0

        For i = 0 To ds.Rows.Count - 1

            If ds(i).Subjectpk = _subjectPK Then

                Return ds(i).YearLevelid
            End If
        Next

        'if subject not found in curriculum return 0
        Return 0

    End Function

    Public Shared Function IsSubjectInCourseCurriculum(ByVal subjectpk As Integer, ByVal coursepk As Integer) As Boolean
        Dim result As Boolean = False


        Dim ds As New dsReg2.SubjectCountInCurriculumbyCourseDataTable
        Dim dt As New dsReg2TableAdapters.SubjectCountInCurriculumbyCourseTableAdapter

        dt.Fill(ds, coursepk, subjectpk)

        If ds(0).ResultCount > 0 Then result = True

        Return result

    End Function

    Public Shared Function ClassSP(ByVal key As Integer) As Boolean
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.CoursesbyPkTableAdapter
        dt.Fill(ds.CoursesbyPk, key)
        If ds.CoursesbyPk.Rows.Count = 0 Then Return False
        Return ds.CoursesbyPk(0).special
    End Function

    Public Shared Function getTime(ByVal d As Date) As String
        Dim hour As String = "00" & d.Hour.ToString
        Dim min As String = "00" & d.Minute.ToString
        hour = hour.Substring(hour.Length - 2, 2)
        min = min.Substring(min.Length - 2, 2)
        Dim s As String = d.ToString("t")
        'Return hour & ":" & min
        Return s
    End Function
    Public Shared Function getSEMName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SemesterbyPkTableAdapter
        dt.Fill(ds.SemesterbyPk, id)
        If ds.SemesterbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SemesterbyPk(0).SemesterName
        End If
    End Function
    REM 10.28.2011
    Public Shared Function getSEMSorter(ByVal id As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SemesterbyPkTableAdapter
        dt.Fill(ds.SemesterbyPk, id)
        If ds.SemesterbyPk.Rows.Count = 0 Then
            Return 0
        Else
            Return ds.SemesterbyPk(0).sorter
        End If
    End Function

    Public Shared Function getSYName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SchoolYearbyPKTableAdapter
        dt.Fill(ds.SchoolYearbyPK, id)
        If ds.SchoolYearbyPK.Rows.Count = 0 Then Return ""
        Return ds.SchoolYearbyPK(0).SchoolYear
    End Function
    Public Shared Function GetCurYear() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurYear")
        If ds.PrefTable.Rows.Count > 0 Then
            Dim key As Integer = ds.PrefTable(0).PrefValue
            Dim dl As New dsSchoolTableAdapters.SchoolYearbyPKTableAdapter
            dl.Fill(ds.SchoolYearbyPK, key)
            If ds.SchoolYearbyPK.Rows.Count > 0 Then
                Return ds.SchoolYearbyPK(0).SchoolYear
            Else
                Return "NOFOUND"
            End If
        Else
            Return "NOFOUND"
        End If
    End Function
    Public Shared Function GetSetting(ByVal rset As String) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, rset)
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        Else
            Return ""
        End If
    End Function
    'ben10.2.2007 . System Generated OR number
    'DONT DELETE in case needed in the future
    ''Public Shared Function getNextOR() As Integer
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    Dim orno As Integer = 1
    ''    dt.Fill(ds.PrefTable, "OR")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        If Not IsNumeric(ds.PrefTable(0).PrefValue) Then ds.PrefTable(0).PrefValue = orno : dt.Update(ds.PrefTable) : Return orno
    ''        orno = Convert.ToInt16(ds.PrefTable(0).PrefValue) + 1
    ''        ds.PrefTable(0).PrefValue = orno
    ''        dt.Update(ds.PrefTable)
    ''        Return orno
    ''    Else            
    ''        Try
    ''            ds.PrefTable(0).PrefValue = orno
    ''            dt.Update(ds.PrefTable)
    ''            Return orno
    ''        Catch ex As Exception
    ''            MsgBox("There is no OR value set in Preference Table.")
    ''        End Try
    ''    End If
    ''End Function
    'ben10.2.2007
    Public Shared Function getReceiptHeaderPKbyRef(ByVal ref As String) As Integer
        Dim ds As New dsFinance.ReceiptsListingbyRefnoDataTable
        Dim dt As New dsFinanceTableAdapters.ReceiptsListingbyRefnoTableAdapter
        dt.Fill(ds, ref)
        If ds.Rows.Count <= 0 Then
            Return 0
        Else
            Return ds(0).PK
        End If
    End Function
    'Ben 3.28.2008
    Public Shared Function getORNobyPK(ByVal receipthdrPK As Integer) As String
        Dim ds As New dsFinance.ReceiptsHeaderbyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ReceiptsHeaderbyPKTableAdapter
        dt.Fill(ds, receipthdrPK)
        If ds.Rows.Count <= 0 Then
            Return ""
        Else
            Return ds(0).Reference
        End If
    End Function
    'Ben 3.28.2008
    Public Shared Function getORpayperiodbyPK(ByVal receipthdrPK As Integer) As Integer
        Dim ds As New dsFinance.ReceiptsHeaderbyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ReceiptsHeaderbyPKTableAdapter
        dt.Fill(ds, receipthdrPK)
        If ds.Rows.Count <= 0 Then
            Return 0
        Else
            If ds(0).IspayperiodNull Then ds(0).payperiod = 0
            Return ds(0).payperiod
        End If
    End Function

    'Ben 3.28.2008
    Public Shared Function getORDatebyPK(ByVal receipthdrPK As Integer) As Date
        Dim ds As New dsFinance.ReceiptsHeaderbyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ReceiptsHeaderbyPKTableAdapter
        dt.Fill(ds, receipthdrPK)
        If ds.Rows.Count <= 0 Then
            Return "1/1/1900"
        Else
            Return ds(0).TRDate
        End If
    End Function

    'get REgistration Number. Cashier and White Form modules.
    Public Shared Function getRegNoByStudentSemYear(ByVal yearpk As Integer, ByVal sempk As Integer, ByVal studentpk As Integer) As Integer
        Dim ds As New dsReg2.RegistrationNumbersByStudentSemYearPKDataTable
        Dim dt As New dsReg2TableAdapters.RegistrationNumbersByStudentSemYearPKTableAdapter
        dt.Fill(ds, sempk, yearpk, studentpk)
        If ds.Rows.Count = 0 Then Return -1
        Return ds(0).RegNumber
    End Function

    'ben10.9.2007
    Public Shared Function GetYearLevel(ByVal sypk As Integer, ByVal sempk As Integer, ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar.EnrollHeaderDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        dt.Fill(ds, sempk, sypk, studentpk)
        If ds.Rows.Count <= 0 Then Return ""
        If ds(0).IsyrlevelNull Then Return ""
        Return clsTool.GetYearLevelFull(ds(0).yrlevel)
    End Function
    'ben10.2.2007
    Public Shared Function GetYearLevelFull(ByVal yrlevel As Integer) As String
        Select Case yrlevel
            Case 1
                Return "1st Year"
            Case 2
                Return "2nd Year"
            Case 3
                Return "3rd Year"
            Case 4
                Return "4th Year"
            Case 5
                Return "5th Year"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Sub SetSetting(ByVal key As String, ByVal data As String)
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, key)
        If ds.PrefTable.Rows.Count > 0 Then
            ds.PrefTable(0).PrefValue = data
            dt.Update(ds.PrefTable)
        Else
            ds.PrefTable.AddPrefTableRow(key, data)
            dt.Update(ds.PrefTable)
        End If
    End Sub
    Public Shared Function GetCurYearPK() As Integer

        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurYear")
        If ds.PrefTable.Rows.Count > 0 Then
            Dim key As Integer = ds.PrefTable(0).PrefValue
            Return key
        Else
            Return -1
        End If
    End Function
    Public Shared Function GetCurSemPK() As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurSem")
        If ds.PrefTable.Rows.Count > 0 Then
            Dim key As Integer = ds.PrefTable(0).PrefValue
            Return key
        Else
            Return -1
        End If
    End Function
    Public Shared Function GetCurSem() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurSem")
        If ds.PrefTable.Rows.Count > 0 Then
            Dim key As String = ds.PrefTable(0).PrefValue
            Dim dt1 As New dsSchoolTableAdapters.SemesterbyPkTableAdapter
            dt1.Fill(ds.SemesterbyPk, Convert.ToInt32(key))
            If ds.SemesterbyPk.Rows.Count > 0 Then
                Return ds.SemesterbyPk(0).SemesterName
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
    Public Shared Sub SetCurSem(ByVal pk As Integer)
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurSem")
        If ds.PrefTable.Rows.Count > 0 Then
            ds.PrefTable(0).PrefValue = pk
            dt.Update(ds.PrefTable)
        End If
    End Sub
    Public Shared Sub SetCurYear(ByVal pk As Integer)
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "CurYear")
        If ds.PrefTable.Rows.Count > 0 Then
            ds.PrefTable(0).PrefValue = pk
            dt.Update(ds.PrefTable)
        End If
    End Sub
    'benALL exam functions & subs
    ''Public Shared Sub Set1STExam(ByVal examdate As String)
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    dt.Fill(ds.PrefTable, "1STEXAM")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        ds.PrefTable(0).PrefValue = examdate
    ''        dt.Update(ds.PrefTable)
    ''    End If
    ''End Sub
    ''Public Shared Sub Set2ndExam(ByVal examdate As String)
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    dt.Fill(ds.PrefTable, "2NDEXAM")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        ds.PrefTable(0).PrefValue = examdate
    ''        dt.Update(ds.PrefTable)
    ''    End If
    ''End Sub
    ''Public Shared Sub Set3rdExam(ByVal examdate As String)
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    dt.Fill(ds.PrefTable, "3RDEXAM")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        ds.PrefTable(0).PrefValue = examdate
    ''        dt.Update(ds.PrefTable)
    ''    End If
    ''End Sub
    ''Public Shared Sub Set4thExam(ByVal examdate As String)
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    dt.Fill(ds.PrefTable, "4THEXAM")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        ds.PrefTable(0).PrefValue = examdate
    ''        dt.Update(ds.PrefTable)
    ''    End If
    ''End Sub
    ''Public Shared Sub Set5thExam(ByVal examdate As String)
    ''    Dim ds As New dsSchool
    ''    Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
    ''    dt.Fill(ds.PrefTable, "5THEXAM")
    ''    If ds.PrefTable.Rows.Count > 0 Then
    ''        ds.PrefTable(0).PrefValue = examdate
    ''        dt.Update(ds.PrefTable)
    ''    End If
    ''End Sub
    Public Shared Function Get1STExam() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "1STEXAM")
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        End If
        Return ""
    End Function
    Public Shared Function Get2ndExam() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "2NDEXAM")
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        End If
        Return ""
    End Function
    Public Shared Function Get3rdExam() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "3RDEXAM")
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        End If
        Return ""
    End Function
    Public Shared Function Get4thExam() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "4THEXAM")
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        End If
        Return ""
    End Function
    Public Shared Function Get5thExam() As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.PrefTableTableAdapter
        dt.Fill(ds.PrefTable, "5THEXAM")
        If ds.PrefTable.Rows.Count > 0 Then
            Return ds.PrefTable(0).PrefValue
        End If
        Return ""
    End Function
    Public Shared Function getExamDate(ByVal sempk As Integer, ByVal sypk As Integer, ByVal examno As Integer) As String
        Dim ds As New dsSchool.ExamsBySemSYDataTable
        Dim dt As New dsSchoolTableAdapters.ExamsBySemSYTableAdapter
        dt.Fill(ds, sypk, sempk)
        Dim retDate As String = ""
        If ds.Rows.Count <= 0 Then Return retDate
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                Select Case examno
                    Case 1
                        retDate = CStr(.examfrom1.Date) & " - " & CStr(.examto1.Date)
                    Case 2
                        If clsTool.getSEMName(sempk).ToLower.Contains("sum") Then
                            retDate = ""
                        Else
                            retDate = CStr(.examfrom2.Date) & " - " & CStr(.examto2.Date)
                        End If

                    Case 3
                        retDate = CStr(.examfrom3.Date) & " - " & CStr(.examto3.Date)
                    Case 4
                        If clsTool.getSEMName(sempk).ToLower.Contains("sum") Then
                            retDate = ""
                        Else
                            retDate = CStr(.examfrom4.Date) & " - " & CStr(.examto4.Date)
                        End If

                    Case 5
                        retDate = CStr(.examfrom5.Date) & " - " & CStr(.examto5.Date)
                End Select
            End With
        Next
        Return retDate
    End Function
    Public Shared Function GetSubjectDescription(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, id)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SubjectsByPriKey(0).SubjectCode & " - " & ds.SubjectsByPriKey(0).SubjectName
        End If
    End Function
    'ben10.11.2007
    Public Shared Function GetSubjectCode(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, id)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SubjectsByPriKey(0).SubjectCode
        End If
    End Function
    'ben10.11.2007
    Public Shared Function GetSubjectName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, id)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SubjectsByPriKey(0).SubjectName
        End If
    End Function
    'ben10.18.2007
    Public Shared Function GetSubjectCreditGroup(ByVal subjectpk As Integer) As Integer
        Dim ds As New dsRep
        Dim dt As New dsRepTableAdapters.SubjectsTableAdapter
        dt.Fill(ds.Subjects, subjectpk)
        If ds.Subjects.Rows.Count = 0 Then
            Return -1
        Else
            If ds.Subjects(0).IscreditgroupNull Then ds.Subjects(0).creditgroup = -1
            Return ds.Subjects(0).creditgroup
        End If
    End Function

    Public Shared Function GetSubjectUnits(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, id)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then
            Return "0"
        Else
            Return ds.SubjectsByPriKey(0).units.ToString
        End If
    End Function
    Public Shared Function getTeacherName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.TeachersbyIDTableAdapter
        dt.Fill(ds.TeachersbyID, id)
        If ds.TeachersbyID.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.TeachersbyID(0).Name
        End If
    End Function
    Public Shared Function getResourceName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SchoolResourcesbyPkTableAdapter
        dt.Fill(ds.SchoolResourcesbyPk, id)
        If ds.SchoolResourcesbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SchoolResourcesbyPk(0).ResourceID & "-" & ds.SchoolResourcesbyPk(0).ResourceName
        End If
    End Function
    'ben10.11.2007
    Public Shared Function getResourceID(ByVal pk As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SchoolResourcesbyPkTableAdapter
        dt.Fill(ds.SchoolResourcesbyPk, pk)
        If ds.SchoolResourcesbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.SchoolResourcesbyPk(0).ResourceID
        End If
    End Function
    'benadded Requested Subject Cost line 10.16.2007
    Public Shared Function getTrTypeName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.TRTypesbyPKTableAdapter
        dt.Fill(ds.TRTypesbyPK, id)
        If id = -1 Then Return "Requested Subject Cost"
        If ds.TRTypesbyPK.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.TRTypesbyPK(0).TRName
        End If
    End Function
    Public Shared Function getTrTypeCode(ByVal trpk As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.TRTypesbyPKTableAdapter
        dt.Fill(ds.TRTypesbyPK, trpk)
        If trpk = -1 Then Return ""
        If ds.TRTypesbyPK.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.TRTypesbyPK(0).TRCode
        End If
    End Function
    'ben11.29.2007
    Public Shared Function getTrChargeforRLERequest(ByVal subjectpk As Integer) As Double
        Dim ds As New dsSchool.TRTypesbySubjectDataTable
        Dim dt As New dsSchoolTableAdapters.TRTypesbySubjectTableAdapter
        dt.Fill(ds, subjectpk)
        If ds.Rows.Count <= 0 Then Return 0
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).TRCode.ToUpper.Contains("RLE") And ds(i).TRCode.ToUpper.Contains("REQUEST") Then
                Return ds(i).TRAmount
            End If
        Next
        Return 0
    End Function
    'ben11.29.2007
    Public Shared Function getTrPKRLERequest(ByVal subjectpk As Integer) As Integer
        Dim ds As New dsSchool.TRTypesbySubjectDataTable
        Dim dt As New dsSchoolTableAdapters.TRTypesbySubjectTableAdapter
        dt.Fill(ds, subjectpk)
        If ds.Rows.Count <= 0 Then Return -1
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If ds(i).TRCode.ToUpper.Contains("RLE") And ds(i).TRCode.ToUpper.Contains("REQUEST") Then
                Return ds(i).TRPK
            End If
        Next
        Return -1
    End Function

    'ben10.30.2007
    Public Shared Function checkTRifTuition(ByVal trpk As Integer) As Boolean
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.TRTypesbyPKTableAdapter
        dt.Fill(ds.TRTypesbyPK, trpk)
        If ds.TRTypesbyPK.Rows.Count <= 0 Then
            Return False
        Else
            If ds.TRTypesbyPK(0).TRCode.ToUpper = "TUITION" Then Return True Else Return False
        End If
    End Function

    'ben10.30.2007
    Public Shared Function getCourseTuition(ByVal coursepk As Integer) As Double
        Dim ds As New dsSchool.TRTypesbyCodeandCourseDataTable
        Dim dt As New dsSchoolTableAdapters.TRTypesbyCodeandCourseTableAdapter
        dt.Fill(ds, "TUITION", coursepk)
        If ds.Rows.Count <= 0 Then Return 0
        Return ds(0).TRAmount
    End Function

    Public Shared Function getTuitionbySemStudentSypk(ByVal studentpk As Integer, ByVal sempk As Integer, _
                  ByVal sypk As Integer, ByVal coursepk As Integer) As Double

        Dim ds As New dsFinance.TuitionFeebySemSyStudentpkDataTable
        Dim dt As New dsFinanceTableAdapters.TuitionFeebySemSyStudentpkTableAdapter
        dt.Fill(ds, studentpk, sypk, sempk)
        If ds.Rows.Count > 0 Then
            If ds(0).IstuitionfeeNull Then ds(0).tuitionfee = 0
            If ds(0).tuitionfee > 0 Then Return ds(0).tuitionfee
        End If

        'this only runs if tuition fee above is still zero ( isTuition field in table )
        'we get the row where qty > 0

        Dim ds2 As New dsFinance.TuitionFeebySemSyStudentpkWorkaroundDataTable
        Dim dt2 As New dsFinanceTableAdapters.TuitionFeebySemSyStudentpkWorkaroundTableAdapter
        dt2.Fill(ds2, studentpk, sypk, sempk)
        If ds2.Rows.Count > 0 Then
            If ds2(0).IstuitionfeeNull Then ds2(0).tuitionfee = 0
            If ds2(0).tuitionfee > 0 Then Return ds2(0).tuitionfee
        End If

        'If still 0 , get Course Tuition
        Return clsTool.getCourseTuition(coursepk)

    End Function

    Public Shared Function getTrTypeAmount(ByVal id As Integer) As Double
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.TRTypesbyPKTableAdapter
        dt.Fill(ds.TRTypesbyPK, id)
        If ds.TRTypesbyPK.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.TRTypesbyPK(0).TRAmount
        End If
    End Function
    Public Shared Function getCourseName(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.CoursesbyPkTableAdapter
        dt.Fill(ds.CoursesbyPk, id)
        If ds.CoursesbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.CoursesbyPk(0).CourseName
        End If
    End Function
    Public Shared Function getCourseRemarks(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.CoursesbyPkTableAdapter
        dt.Fill(ds.CoursesbyPk, id)
        If ds.CoursesbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.CoursesbyPk(0).Remarks
        End If
    End Function
    Public Shared Function getCoursePKgivenCode(ByVal coursecode As String) As Integer
        Dim ds As New dsSchool.CoursesDataTable
        Dim dt As New dsSchoolTableAdapters.CoursesTableAdapter
        Dim i As Integer
        dt.Fill(ds)
        If ds.Rows.Count <= 0 Then
            Return -1
        Else
            For i = 0 To ds.Rows.Count - 1
                If ds(i).CourseID.ToUpper = coursecode.ToUpper Then Return ds(i).coursepk
            Next
        End If
        Return -1
    End Function

    Public Shared Function getCourseCompleteDesc(ByVal id As Integer) As String
        Dim resultString As String = ""
        resultString = getCourseCode(id) & " - " & clsTool.getCourseName(id) & " - " & clsTool.getCourseRemarks(id)

        Return resultString

    End Function
    'Ben 3.12.2008 .Loops and lets user choose course.
    Public Shared Function getCoursePKgivenName(ByVal coursename As String) As Integer
        Dim ds As New dsSchool.CoursesbyNameDataTable
        Dim dt As New dsSchoolTableAdapters.CoursesbyNameTableAdapter
        Dim i As Integer
        dt.Fill(ds, "%" & coursename & "%")
        If ds.Rows.Count <= 0 Then
            MsgBox("None found!")
            Return -1
        Else
            For i = 0 To ds.Rows.Count - 1
                If MsgBox("Choose " & ds(i).CourseName & "  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return ds(i).coursepk
                End If
            Next
        End If
        Return -1
    End Function
    'ben9.29.2007
    Public Shared Function getCourseCode(ByVal id As Integer) As String
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.CoursesbyPkTableAdapter
        dt.Fill(ds.CoursesbyPk, id)
        If ds.CoursesbyPk.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.CoursesbyPk(0).CourseID
        End If
    End Function
    'ben11.23 . Based on Ledger Table
    Public Shared Function getCourseStudentCount(ByVal coursepk As Integer, ByVal sempk As Integer, ByVal yrpk As Integer) As Integer
        Dim ds As New dsFinance.StudentsperCourseDataTable
        Dim dt As New dsFinanceTableAdapters.StudentsperCourseTableAdapter
        dt.Fill(ds, sempk, yrpk, coursepk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IsstudentcountNull Then Return 0
        Return ds(0).studentcount
    End Function
    'ben11.23 . Based on Ledger Table
    Public Shared Function getDPperCourse(ByVal coursepk As Integer, ByVal sempk As Integer, ByVal yrpk As Integer) As Double
        Dim ds As New dsFinance.DPperCourseDataTable
        Dim dt As New dsFinanceTableAdapters.DPperCourseTableAdapter
        dt.Fill(ds, coursepk, yrpk, sempk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IsamountNull Then Return 0
        Return ds(0).amount
    End Function
    'ben11.23 . Based on Receipts and Ledger(to get course) Table
    Public Shared Function getPaymentsperCourse(ByVal coursepk As Integer, ByVal sempk As Integer, ByVal yrpk As Integer, ByVal payperiod As Integer) As Double
        Dim ds As New dsFinance.PaymentperPeriodCourseDataTable
        Dim dt As New dsFinanceTableAdapters.PaymentperPeriodCourseTableAdapter
        dt.Fill(ds, coursepk, payperiod, yrpk, sempk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IsamountNull Then Return 0
        Return ds(0).amount
    End Function
    'ben11.24 . Based on Receipts and Ledger(to get course) Table
    'Note. as long as theres a receipt, that student get counted for that period
    Public Shared Function getPaidStudentsperPeriod(ByVal coursepk As Integer, ByVal sempk As Integer, ByVal yrpk As Integer, ByVal payperiod As Integer) As Integer
        Dim ds As New dsFinance.CountStudentsPaidperPeriodCourseDataTable
        Dim dt As New dsFinanceTableAdapters.CountStudentsPaidperPeriodCourseTableAdapter
        dt.Fill(ds, coursepk, payperiod, yrpk, sempk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IsstudentcountNull Then Return 0
        Return ds(0).studentcount
    End Function
    'ben11.26 . Test if RCPT amount total to 500 or more for given sem and year
    Public Shared Function checkifStudentPaidRegFee(ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer) As Boolean
        Dim ds As New dsFinance.LedgerbyStudentSemYearDataTable
        Dim dt As New dsFinanceTableAdapters.LedgerbyStudentSemYearTableAdapter
        dt.Fill(ds, studentpk, sempk, sypk)
        If ds.Rows.Count <= 0 Then Return False
        Dim i As Integer
        Dim totalpaid As Double = 0
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                If .linetype = "RCPT" Then totalpaid += .amount
            End With
        Next
        If totalpaid >= 500 Then Return True Else Return False
    End Function

    'ben9.28.2007
    Public Shared Function getChargeSchedName(ByVal chargeschedpk As Integer)
        Dim ds As New dsFinance.ChargeSchedulebyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ChargeSchedulebyPKTableAdapter
        dt.Fill(ds, chargeschedpk)
        If ds.Rows.Count <= 0 Then
            Return ""
        Else
            Return ds(0).Name
        End If
    End Function
    'ben9.28.2007
    Public Shared Function getChargeRemarks(ByVal chargeschedpk As Integer)
        Dim ds As New dsFinance.ChargeSchedulebyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ChargeSchedulebyPKTableAdapter
        dt.Fill(ds, chargeschedpk)
        If ds.Rows.Count <= 0 Then
            Return ""
        Else
            If ds(0).IsRemarksNull Then ds(0).Remarks = ""
            Return ds(0).Remarks
        End If
    End Function
    'ben9.28.2007
    Public Shared Function getChargeCategory(ByVal chargeschedpk As Integer)
        Dim ds As New dsFinance.ChargeSchedulebyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ChargeSchedulebyPKTableAdapter
        dt.Fill(ds, chargeschedpk)
        If ds.Rows.Count <= 0 Then
            Return ""
        Else
            If ds(0).IsCategoryNull Then ds(0).Category = ""
            Return ds(0).Category
        End If
    End Function
    'ben9.28.2007
    Public Shared Function getChargeAmount(ByVal chargeschedpk As Integer)
        Dim ds As New dsFinance.ChargeSchedulebyPKDataTable
        Dim dt As New dsFinanceTableAdapters.ChargeSchedulebyPKTableAdapter
        dt.Fill(ds, chargeschedpk)
        If ds.Rows.Count <= 0 Then
            Return 0
        Else
            If ds(0).IsAmountNull Then ds(0).Amount = 0
            Return ds(0).Amount
        End If
    End Function
    'ben9.28.2007
    Public Shared Function getSemAmortTotal(ByVal studentpk As Integer, ByVal sypk As Integer, ByVal sempk As Integer)
        Dim ds As New dsFinance.SemAmortbyStudentYearSemPKDataTable
        Dim dt As New dsFinanceTableAdapters.SemAmortbyStudentYearSemPKTableAdapter
        dt.Fill(ds, studentpk, sypk, sempk)
        If ds.Rows.Count <= 0 Then
            Return 0
        Else
            Return ds.Compute("Sum(charge)", String.Empty)
        End If
    End Function
    'ben12.6 modified adapter to include condition on active field
    Public Shared Function uLogin(ByVal username As String, ByVal password As String) As Boolean
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUsersLoginTableAdapter
        dt.Fill(ds.AppUsersLogin, username, password)
        If ds.AppUsersLogin.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
    'ben12.6 modified adapter to include condition on active field
    Public Shared Function uLoginFullUserName(ByVal username As String, ByVal password As String) As String
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUsersLoginTableAdapter
        dt.Fill(ds.AppUsersLogin, username, password)
        If ds.AppUsersLogin.Rows.Count = 0 Then
            Return ""
        End If
        Return ds.AppUsersLogin(0).fullname
    End Function

    Public Shared Function uUserPK(ByVal username As String) As Integer
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUsersbyUserNameTableAdapter
        dt.Fill(ds.AppUsersbyUserName, username)
        If ds.AppUsersbyUserName.Rows.Count = 0 Then Return -1
        Return ds.AppUsersbyUserName(0).uid
    End Function
    'ben9.25.2007
    Public Shared Function getUserPKbypassword(ByVal password As String) As Integer
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUsersbyPasswordTableAdapter
        dt.Fill(ds.AppUsersbyPassword, password)
        If ds.AppUsersbyPassword.Rows.Count = 0 Then Return -1
        Return ds.AppUsersbyPassword(0).uid
    End Function

    Public Shared Function uRights(ByVal username As String, ByVal key As String) As Boolean
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUserRightsTableAdapter
        Dim uid As Integer = uUserPK(username)
        If uid = -1 Then Return False
        dt.Fill(ds.AppUserRights, uid, key)
        If ds.AppUserRights.Rows.Count = 0 Then
            Return False
        End If
        If ds.AppUserRights(0).RightsValue = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    'ben9.25.2007
    Public Shared Function getRightsbyIDandKey(ByVal uid As Integer, ByVal key As String) As Boolean
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUserRightsTableAdapter
        dt.Fill(ds.AppUserRights, uid, key)
        If ds.AppUserRights.Rows.Count = 0 Then
            Return False
        End If
        If ds.AppUserRights(0).RightsValue = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function getStudentName(ByVal key As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, key)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return 0
        Else
            Return ds.StudentsbyPK(0).StudentName
        End If
    End Function
    'ben10.24
    Public Shared Function getStudentID(ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, studentpk)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.StudentsbyPK(0).StudentID
        End If
    End Function
    'ben10.9.2007
    Public Shared Function getStudentSex(ByVal key As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, key)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return ""
        Else
            If ds.StudentsbyPK(0).IsGenderNull Then Return ""
            Return ds.StudentsbyPK(0).Gender
        End If
    End Function
    'ben11.29.2007
    Public Shared Function getStudentType(ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, studentpk)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return "OLD"
        Else
            If ds.StudentsbyPK(0).IsStudentTypeNull Then ds.StudentsbyPK(0).StudentType = "OLD"
            Return ds.StudentsbyPK(0).StudentType
        End If
    End Function

    'ben10.16.2007
    Public Shared Function getStudentBday(ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, studentpk)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return Now()
        Else
            Return ds.StudentsbyPK(0).Birthdate
        End If
    End Function
    'ben10.18.2007
    Public Shared Function getStudentAddress(ByVal key As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentsbyPKTableAdapter
        dt.Fill(ds.StudentsbyPK, key)
        If ds.StudentsbyPK.Rows.Count = 0 Then
            Return ""
        Else
            Return ds.StudentsbyPK(0).Address1 + ", " + ds.StudentsbyPK(0).Address2
        End If
    End Function
    'ben1.4.2008
    Public Shared Function getStudentYearLevel(ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer) As String
        Dim ds As New dsRegistrar.EnrollHeaderDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollHeaderTableAdapter
        dt.Fill(ds, sempk, sypk, studentpk)
        If ds.Rows.Count <= 0 Then Return ""
        If ds(0).IsyrlevelNull Then Return ""
        Return GetYearLevelFull(ds(0).yrlevel)
    End Function

    'ben1.26.2008 . 
    '2.9.2008 . Added code to divide by 2 special subjects
    'All RLE except RLE103 will not be charged with tuition fee
    Public Shared Function getStudentEnrolledUnits(ByVal studentpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer) As Integer
        Dim ds As New dsRegistrar.EnrollSubjectsDataTable
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds, sypk, sempk, studentpk)
        If ds.Rows.Count <= 0 Then Return 0
        Dim i As Integer
        Dim totalunits As Integer = 0
        For i = 0 To ds.Rows.Count - 1
            With ds(i)
                If .status = 1 Then
                    Dim subjectcode As String = clsTool.GetSubjectCode(.subjectpk)
                    If (subjectcode.ToUpper.Contains("NSTP")) Or _
                      (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("104")) Or _
                      (subjectcode.ToUpper.Contains("NCM") And subjectcode.ToUpper.Contains("105")) Then

                        totalunits += clsTool.GetSubjectUnits(.subjectpk) / 2
                    ElseIf (subjectcode.ToUpper.Contains("RLE") And Not subjectcode.ToUpper.Contains("103")) Then
                        totalunits += 0
                    Else
                        totalunits += clsTool.GetSubjectUnits(.subjectpk)
                    End If
                End If
            End With
        Next
        Return totalunits
    End Function

    Public Shared Function getStudentRecentCourse(ByVal studentpk As Integer) As String
        Dim ds As New dsReg2.CourseEnrolledByStudentPKDataTable
        Dim dt As New dsReg2TableAdapters.CourseEnrolledByStudentPKTableAdapter

        dt.Fill(ds, studentpk)
        If ds.Rows.Count <= 0 Then Return ""

        Return clsTool.getCourseCompleteDesc(ds(0).coursepk)

    End Function

    Public Shared Function getStudentRecentCoursePK(ByVal studentpk As Integer) As Integer
        Dim ds As New dsReg2.CourseEnrolledByStudentPKDataTable
        Dim dt As New dsReg2TableAdapters.CourseEnrolledByStudentPKTableAdapter

        dt.Fill(ds, studentpk)
        If ds.Rows.Count <= 0 Then Return -1

        Return ds(0).coursepk

    End Function

    Public Shared Function isStudentWithPreviousSchool(ByVal studentpk As Integer) As Boolean

        Dim ds As New dsSchool2.PreviousSchoolsByStudentPKDataTable
        Dim dt As New dsSchool2TableAdapters.PreviousSchoolsByStudentPKTableAdapter

        dt.Fill(ds, studentpk)

        If ds.Rows.Count <= 0 Then Return False

        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If Not String.IsNullOrEmpty(ds(i).PrevShool) Then Return True

        Next

        Return False
    End Function

    Public Shared Function GetStudentLastPreviousSchool(ByVal studentpk As Integer) As String
        Dim ds As New dsSchool2.PreviousSchoolsByStudentPKDataTable
        Dim dt As New dsSchool2TableAdapters.PreviousSchoolsByStudentPKTableAdapter

        dt.Fill(ds, studentpk)

        If ds.Rows.Count <= 0 Then Return ""

        Dim i As Integer

        For i = 0 To ds.Rows.Count - 1
            If Not String.IsNullOrEmpty(ds(i).PrevShool) Then Return ds(i).PrevShool

        Next
        Return ""
    End Function

    Public Shared Function getSYOffering(ByVal id As Integer) As dsRegistrar.SYOfferingbyPKRow
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count > 0 Then Return ds.SYOfferingbyPK(0) Else Return Nothing
    End Function
    'ben10.3.2007
    Public Shared Function testSYOfferIfRequested(ByVal syofferpk As Integer) As Boolean
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return False
        If ds.SYOfferingbyPK(0).IsrequestedNull Then
            Return False
        Else
            Return ds.SYOfferingbyPK(0).requested
        End If
    End Function
    'ben10.3.2007
    Public Shared Function testSYOfferIfClosed(ByVal id As Integer) As Boolean
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return False
        If ds.SYOfferingbyPK(0).IsclosedNull Then
            Return False
        Else
            Return ds.SYOfferingbyPK(0).closed
        End If
    End Function
    'ben10.16.2007
    Public Shared Function getSYOfferMinStudents(ByVal syofferpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return 1
        Return ds.SYOfferingbyPK(0).MinStudents
    End Function
    'ben10.16.2007
    Public Shared Function getSYOfferMaxStudents(ByVal syofferpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return 1
        Return ds.SYOfferingbyPK(0).MaxStudents
    End Function
    'ben11.29.2007
    Public Shared Function getSYOfferTeacher(ByVal syofferpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return -1
        Return ds.SYOfferingbyPK(0).teacherid
    End Function
    'ben11.29.2007
    Public Shared Function getSYOfferSubjectID(ByVal syofferpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return -1
        Return ds.SYOfferingbyPK(0).subjectpk
    End Function
    'ben11.29.2007
    Public Shared Function getSYOfferResource(ByVal syofferpk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Return -1
        Return ds.SYOfferingbyPK(0).resource
    End Function

    '11.19.2011 . GET the resources per day of an offering. 
    Public Shared Function getSYOfferResourceIDbyDay(ByVal syofferpk As Integer, ByVal day As String) As Integer

        Dim ds As New dsSchool2.SYOfferingResourcesByFKDataTable
        Dim dt As New dsSchool2TableAdapters.SYOfferingResourcesByFKTableAdapter

        dt.Fill(ds, syofferpk)

        If ds.Rows.Count <= 0 Then Return -1

        Select Case day
            Case "mon"
                Return ds(0).resourcemon
            Case "tue"
                Return ds(0).resourcetue
            Case "wed"
                Return ds(0).resourcewed
            Case "thu"
                Return ds(0).resourcethu
            Case "fri"
                Return ds(0).resourcefri
            Case "sat"
                Return ds(0).resourcesat
            Case "sun"
                Return ds(0).resourcesun

        End Select

        Return -1

    End Function


    'Get the Broken Hour for a given day of an SYOffering
    Public Shared Function GetSYOfferBrokenHoursByDay(ByVal syofferpk As Integer, ByVal day As String, ByVal timeStart As Boolean) As Date

        Dim dsBroken As New dsRegistrar.SYOfferingExtraHoursByFKDataTable
        Dim dtBroken As New dsRegistrarTableAdapters.SYOfferingExtraHoursByFKTableAdapter

        dtBroken.Fill(dsBroken, syofferpk)
        Dim i As Integer
        For i = 0 To dsBroken.Rows.Count - 1
            With dsBroken(i)

                If .dayType = "mon" And day = "mon" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd

                ElseIf .dayType = "tue" And day = "tue" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd

                ElseIf .dayType = "wed" And day = "wed" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd



                ElseIf .dayType = "thu" And day = "thu" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd


                ElseIf .dayType = "fri" And day = "fri" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd



                ElseIf .dayType = "sat" And day = "sat" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd


                ElseIf .dayType = "sun" And day = "sun" Then

                    If timeStart Then Return .timeStart Else Return .timeEnd



                End If

            End With
        Next

        Return "1900-01-01 12:00:00 AM"

    End Function

    'ben10.30.2007
    Public Shared Sub closeSYOffering(ByVal syofferpk As Integer)
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, syofferpk)
        If ds.SYOfferingbyPK.Rows.Count <= 0 Then Exit Sub
        ds.SYOfferingbyPK(0).closed = True
        dt.Update(ds.SYOfferingbyPK)
    End Sub
    Public Shared Function getUserkey(ByVal username As String) As Integer
        Dim ds As New dsSystem
        Dim dt As New dsSystemTableAdapters.AppUsersbyNameTableAdapter
        dt.Fill(ds.AppUsersbyName, username)
        If ds.AppUsersbyName.Rows.Count = 0 Then Return -1
        Return ds.AppUsersbyName(0).uid
    End Function
    REM EnrollSubject datatable is a misnomer. should be enrollstudents.
    Public Shared Function getStudentCount(ByVal sem As Integer, ByVal sy As Integer, ByVal syofferpk As Integer) As Integer
        Dim rval As Integer = 0
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCountTableAdapter
        dt.Fill(ds.EnrollSubjectsCount, sy, sem, syofferpk)
        If ds.EnrollSubjectsCount.Rows.Count = 0 Then Return 0
        If ds.EnrollSubjectsCount(0).IsStudentCountNull Then Return 0
        rval = ds.EnrollSubjectsCount(0).StudentCount
        Return rval
    End Function
    'ben11.24.2007
    Public Shared Function getStudentCourseCode(ByVal sempk As Integer, ByVal sypk As Integer, ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds.EnrollSubjects, sypk, sempk, studentpk)
        If ds.EnrollSubjects.Rows.Count <= 0 Then Return ""
        Dim i As Integer
        For i = 0 To ds.EnrollSubjects.Rows.Count - 1
            With ds.EnrollSubjects(i)
                If .status = 1 Then
                    Return clsTool.getCourseCode(.coursepk)
                End If
            End With
        Next
        Return ""
    End Function
    'ben2.29.2008
    Public Shared Function getStudentCourseName(ByVal sempk As Integer, ByVal sypk As Integer, ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds.EnrollSubjects, sypk, sempk, studentpk)
        If ds.EnrollSubjects.Rows.Count <= 0 Then Return ""
        Dim i As Integer
        For i = 0 To ds.EnrollSubjects.Rows.Count - 1
            With ds.EnrollSubjects(i)
                If .status = 1 Then
                    Return clsTool.getCourseName(.coursepk)
                End If
            End With
        Next
        Return ""
    End Function
    'ben2.29.2008
    Public Shared Function getStudentCoursePK(ByVal sempk As Integer, ByVal sypk As Integer, ByVal studentpk As Integer) As String
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        dt.Fill(ds.EnrollSubjects, sypk, sempk, studentpk)
        If ds.EnrollSubjects.Rows.Count <= 0 Then Return -1
        Dim i As Integer
        For i = 0 To ds.EnrollSubjects.Rows.Count - 1
            With ds.EnrollSubjects(i)
                If .status = 1 Then
                    Return .coursepk
                End If
            End With
        Next
        Return -1
    End Function


    'ben10.30.2007
    'will get data from ledger table having subject,sem,sy,syofferpk equal to parameter and linetype=TUTOR . 
    'if at least 1 record is found, it is assumed that the subject/syofferpk has already been adjusted in ledger with Tutorial charges
    Public Shared Function testIfSYofferhasTutorCharges(ByVal syofferpk As String, ByVal subjectpk As Integer, ByVal sempk As Integer, ByVal sypk As Integer) As Boolean
        Dim ds As New dsFinance.LedgerbySubjectSemYrLinetypeDataTable
        Dim dt As New dsFinanceTableAdapters.LedgerbySubjectSemYrLinetypeTableAdapter
        dt.Fill(ds, subjectpk, sempk, sypk, "TUTOR")
        Dim i As Integer
        If ds.Rows.Count <= 0 Then
            Return False
        Else
            For i = 0 To ds.Rows.Count - 1 'test for syofferpk in ref field
                If ds(i).ref = syofferpk Then Return True
            Next
            Return False
        End If
    End Function


    Public Shared Function getStudentGrade(ByVal student As Integer, ByVal subject As Integer) As String
        Dim ds As New dsRegistrar.StudentGradesbyStudentSubjectDataTable
        Dim dt As New dsRegistrarTableAdapters.StudentGradesbyStudentSubjectTableAdapter
        dt.Fill(ds, student, subject)
        Dim ctr As Integer
        Dim grade As Double = 0
        For ctr = 0 To ds.Rows.Count - 1
            With ds(ctr)
                If .IsisPrevSchoolGradeNull Then .isPrevSchoolGrade = False
                If .isPrevSchoolGrade Then 'grade from previous school
                    Return .exSubjectGrade
                Else 'grade from MMFC
                    If .grade > 0 Then Return .grade
                End If
            End With
        Next

        'If no grades found, check from Mappings.. INFINITE LOOP!!!! this function calls this main function
        grade = getStudentGradeFromMappedSubject(student, subject)

        Return grade
    End Function

    ''' <summary>
    ''' Gets a grade from the mapped 'fusion' pseudo subject
    ''' looks for curriculum subject in mapped table then looks for the pseudo fused subject in syofferings 
    ''' then gets the grade of that pseudo subject
    ''' </summary>
    ''' <param name="student"></param>
    ''' <param name="subject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getStudentGradeFromMappedSubject(ByVal student As Integer, ByVal subject As Integer) As String
        'get the syofferingfk for the input curriculum subject
        Dim ds As New dsReg2.FusedSubjectsByRootSubjectDataTable
        Dim dt As New dsReg2TableAdapters.FusedSubjectsByRootSubjectTableAdapter
        dt.Fill(ds, subject)
        If ds.Rows.Count <= 0 Then Return "0"
        Dim ctr As Integer
        Dim grade As Double
        Dim strGrade As String
        For ctr = 0 To ds.Rows.Count - 1
            With ds(ctr)
                'use the syoffering.subject pk to get a grade of input student
                'if none found then next syoffering.subject
                Dim ds2 As New dsRegistrar.StudentGradesbyStudentSubjectDataTable
                Dim dt2 As New dsRegistrarTableAdapters.StudentGradesbyStudentSubjectTableAdapter
                dt2.Fill(ds2, student, .subjectpk)                
                If ds2.Rows.Count > 0 Then strGrade = ds2(0).grade.ToString() Else strGrade = ""
                ''strGrade = getStudentGrade(student, .subjectpk)
                If IsNumeric(strGrade) Then
                    grade = Convert.ToDouble(strGrade)
                    If grade > 0 Then Return grade
                End If
            End With
        Next
        'if none found then return 0
        Return "0"
    End Function

    '4/27/2013
    'Get the grade via syoffering pk, which has a subjectpk in the record fields, then get the grade
    Public Shared Function getStudentGradeBySyOfferingPK(ByVal student As Integer, ByVal syofferingpk As Integer) As String
        Dim subjectpk As Integer = getSYOfferSubjectID(syofferingpk)
        Return getStudentGrade(student, subjectpk)
    End Function

    'ben12.6
    Public Shared Function updateStudentGrade(ByVal studentpk As Integer, ByVal sempk As Integer, _
      ByVal yearpk As Integer, ByVal subjectpk As Integer, ByVal grade As Decimal, _
       ByVal teacherpk As Integer, ByVal coursepk As Integer) As Boolean
        Dim ds As New dsRegistrar.StudentGradesDataTable
        Dim dt As New dsRegistrarTableAdapters.StudentGradesTableAdapter
        dt.Fill(ds, "ENR", subjectpk, yearpk, sempk, studentpk)
        If ds.Rows.Count <= 0 Then
            'add new record
            ds.AddStudentGradesRow(Now(), grade, "ENR", subjectpk, yearpk, sempk, teacherpk, studentpk, "", "", _
              "0", coursepk, 0, -1, "", 0, False, 0)
        Else
            'update existing record/grade
            ds(0).grade = grade
        End If
        Try
            dt.Update(ds)
            Return False
        Catch ex As Exception
            Return True 'if error saving
        End Try
    End Function
    Public Shared Function getSubjectPrerequisite(ByVal subject As Integer) As Integer
        Dim ds As New dsSchool
        Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
        dt.Fill(ds.SubjectsByPriKey, subject)
        If ds.SubjectsByPriKey.Rows.Count = 0 Then Return -1
        Return ds.SubjectsByPriKey(0).prereq
    End Function

    'Compare 2 SYOFFERINGS and check for conflict in time sked
    'a False return means THERES CONFLICT
    ' add checking for conflict on broken hours
    Public Shared Function checkSubjectConflict(ByVal enr1 As Integer, ByVal enr2 As Integer) As Boolean

        Dim ds1 As New dsRegistrar
        Dim ds2 As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter

        dt.Fill(ds1.SYOfferingbyPK, enr1)
        If ds1.SYOfferingbyPK.Rows.Count = 0 Then Return False

        dt.Fill(ds2.SYOfferingbyPK, enr2)
        If ds2.SYOfferingbyPK.Rows.Count = 0 Then Return False

        Dim r1 As dsRegistrar.SYOfferingbyPKRow = ds1.SYOfferingbyPK(0)
        Dim r2 As dsRegistrar.SYOfferingbyPKRow = ds2.SYOfferingbyPK(0)


        Dim r1from, r1brokenFrom, r2brokenFrom As Date
        Dim r1to, r1brokenTo, r2brokenTo As Date


        '======================================================================================
        'Ben 4.22.2008 added to catch conflict when 1st class range covers all of 2nd class
        ' e.g. 1stclass = 7:30-10:00 am  ,  2ndclass = 8:30 - 9:00
        '======================================================================================

        If r1.monday And r2.monday Then
            ' (monfrom <= @d1) and (monto >= @d1)
            r1from = r1.monfrom
            r1to = r1.monto
            If r2.monfrom <= r1from And r2.monto >= r1from Then Return False
            If r2.monfrom <= r1to And r2.monto >= r1to Then Return False
            If r1from <= r2.monfrom And r1to >= r2.monfrom Then Return False
            If r1from <= r2.monto And r1to >= r2.monto Then Return False

            'test r1 against broken hour of r2 vice versa
            If CheckSYOfferHasBrokenHours(enr1, "mon") Or CheckSYOfferHasBrokenHours(enr2, "mon") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "mon", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "mon", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "mon", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "mon", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.monfrom >= r1brokenFrom And r2.monfrom <= r1brokenTo) _
                    Or (r2.monto >= r1brokenFrom And r2.monto <= r1brokenTo) _
                    ) Then

                    Return False
                End If

            End If

        End If
        If r1.tuesday And r2.tuesday Then
            r1from = r1.tuesfrom
            r1to = r1.tuesto
            If r2.tuesfrom <= r1from And r2.tuesto >= r1from Then Return False
            If r2.tuesfrom <= r1to And r2.tuesto >= r1to Then Return False
            If r1from <= r2.tuesfrom And r1to >= r2.tuesfrom Then Return False
            If r1from <= r2.tuesto And r1to >= r2.tuesto Then Return False

            'test r1 against broken hour of r2 vice versa
            'only continue test if both have broken hours
            If CheckSYOfferHasBrokenHours(enr1, "tue") Or CheckSYOfferHasBrokenHours(enr2, "tue") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "tue", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "tue", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "tue", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "tue", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.tuesfrom >= r1brokenFrom And r2.tuesfrom <= r1brokenTo) _
                    Or (r2.tuesto >= r1brokenFrom And r2.tuesto <= r1brokenTo) _
                    ) Then

                    Return False
                End If

            End If

        End If
        If r1.wednesday And r2.wednesday Then
            r1from = r1.wedfrom
            r1to = r1.wedto
            If r2.wedfrom <= r1from And r2.wedto >= r1from Then Return False
            If r2.wedfrom <= r1to And r2.wedto >= r1to Then Return False
            If r1from <= r2.wedfrom And r1to >= r2.wedfrom Then Return False
            If r1from <= r2.wedto And r1to >= r2.wedto Then Return False

            'test r1 against broken hour of r2 vice versa
            'only continue test if both have broken hours
            If CheckSYOfferHasBrokenHours(enr1, "wed") Or CheckSYOfferHasBrokenHours(enr2, "wed") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "wed", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "wed", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "wed", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "wed", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.wedfrom >= r1brokenFrom And r2.wedfrom <= r1brokenTo) _
                    Or (r2.wedto >= r1brokenFrom And r2.wedto <= r1brokenTo) _
                    ) Then

                    Return False
                End If

            End If
        End If

        If r1.thursday And r2.thursday Then
            r1from = r1.thufrom
            r1to = r1.thuto
            If r2.thufrom <= r1from And r2.thuto >= r1from Then Return False
            If r2.thufrom <= r1to And r2.thuto >= r1to Then Return False
            If r1from <= r2.thufrom And r1to >= r2.thufrom Then Return False
            If r1from <= r2.thuto And r1to >= r2.thuto Then Return False

            'test r1 against broken hour of r2 vice versa

            If CheckSYOfferHasBrokenHours(enr1, "thu") Or CheckSYOfferHasBrokenHours(enr2, "thu") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "thu", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "thu", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "thu", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "thu", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.thufrom >= r1brokenFrom And r2.thufrom <= r1brokenTo) _
                    Or (r2.thuto >= r1brokenFrom And r2.thuto <= r1brokenTo) _
                    ) Then

                    Return False
                End If
            End If

        End If

        If r1.friday And r2.friday Then
            r1from = r1.frifrom
            r1to = r1.frito
            If r2.frifrom <= r1from And r2.frito >= r1from Then Return False
            If r2.frifrom <= r1to And r2.frito >= r1to Then Return False
            If r1from <= r2.frifrom And r1to >= r2.frifrom Then Return False
            If r1from <= r2.frito And r1to >= r2.frito Then Return False

            'test r1 against broken hour of r2 vice versa
            'only continue test if both have broken hours
            If CheckSYOfferHasBrokenHours(enr1, "fri") Or CheckSYOfferHasBrokenHours(enr2, "fri") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "fri", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "fri", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "fri", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "fri", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.frifrom >= r1brokenFrom And r2.frifrom <= r1brokenTo) _
                    Or (r2.frito >= r1brokenFrom And r2.frito <= r1brokenTo) _
                    ) Then

                    Return False
                End If

            End If
        End If

        If r1.saturday And r2.saturday Then
            r1from = r1.satfrom
            r1to = r1.satto
            If r2.satfrom <= r1from And r2.satto >= r1from Then Return False
            If r2.satfrom <= r1to And r2.satto >= r1to Then Return False
            If r1from <= r2.satfrom And r1to >= r2.satfrom Then Return False
            If r1from <= r2.satto And r1to >= r2.satto Then Return False

            'test r1 against broken hour of r2 vice versa
            'only continue test if both have broken hours
            If CheckSYOfferHasBrokenHours(enr1, "sat") Or CheckSYOfferHasBrokenHours(enr2, "sat") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "sat", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "sat", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "sat", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "sat", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.satfrom >= r1brokenFrom And r2.satfrom <= r1brokenTo) _
                    Or (r2.satto >= r1brokenFrom And r2.satto <= r1brokenTo) _
                    ) Then

                    Return False
                End If
            End If

        End If
        If r1.sunday And r2.sunday Then
            r1from = r1.sunfrom
            r1to = r1.sunto
            If r2.sunfrom <= r1from And r2.sunto >= r1from Then Return False
            If r2.sunfrom <= r1to And r2.sunto >= r1to Then Return False
            If r1from <= r2.sunfrom And r1to >= r2.sunfrom Then Return False
            If r1from <= r2.sunto And r1to >= r2.sunto Then Return False


            'test r1 against broken hour of r2 vice versa
            'only continue test if both have broken hours
            If CheckSYOfferHasBrokenHours(enr1, "sun") And CheckSYOfferHasBrokenHours(enr2, "sun") Then

                r1brokenFrom = GetSYOfferBrokenHoursByDay(enr1, "sun", True)
                r1brokenTo = GetSYOfferBrokenHoursByDay(enr1, "sun", False)
                r2brokenFrom = GetSYOfferBrokenHoursByDay(enr2, "sun", True)
                r2brokenTo = GetSYOfferBrokenHoursByDay(enr2, "sun", False)

                'first 2 line, broken against broken
                'next 2 lines, r1 regular against r2 broken
                'next 2 lines, r2 regular against r1 broken
                If ((r1brokenFrom >= r2brokenFrom And r1brokenFrom <= r2brokenTo) _
                    Or (r1brokenTo >= r2brokenFrom And r1brokenTo <= r2brokenTo) _
                    Or (r1from >= r2brokenFrom And r1from <= r2brokenTo) _
                    Or (r1to >= r2brokenFrom And r1to <= r2brokenTo) _
                    Or (r2.sunfrom >= r1brokenFrom And r2.sunfrom <= r1brokenTo) _
                    Or (r2.sunto >= r1brokenFrom And r2.sunto <= r1brokenTo) _
                    ) Then

                    Return False
                End If
            End If
        End If

        Return True

    End Function

    'Ben 7.8.2008
    Public Shared Function getStudentPaidAmountPerPeriod(ByVal studentpk As Integer, ByVal sypk As Integer, _
                                            ByVal payperiod As Integer, ByVal sempk As Integer) As Double

        Dim ds As New dsFinance.PaymentAmountByPeriodSemSYStudentPKDataTable
        Dim dt As New dsFinanceTableAdapters.PaymentAmountByPeriodSemSYStudentPKTableAdapter
        dt.Fill(ds, sempk, sypk, payperiod, studentpk)
        If ds.Rows.Count <= 0 Then Return 0
        If ds(0).IsamountNull Then Return 0
        Return ds(0).amount

    End Function

    Public Shared Function getDBValue(ByVal strSQL As String) As String

        Dim sql As New SqlClient.SqlCommand
        sql.Connection = New SqlClient.SqlConnection(My.Settings.mmfcdbConnectionString)
        sql.Connection.Open()

        sql.CommandType = CommandType.Text
        sql.CommandText = strSQL

        Dim returnString As String = ""

        Try

            returnString = sql.ExecuteScalar()
            Return returnString

        Catch ex As Exception
            Return returnString

        End Try

    End Function

    Public Shared Sub runDBSQL(ByVal strSQL As String)

        Dim sql As New SqlClient.SqlCommand
        sql.Connection = New SqlClient.SqlConnection(My.Settings.mmfcdbConnectionString)
        sql.Connection.Open()
        sql.CommandType = CommandType.Text
        sql.CommandText = strSQL
        Try
            sql.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("An error occurred. pls report this to Administrator. " & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Shared Function findOR(ByVal orno As String) As Boolean

        Dim ds As New dsFinance.ReceiptsHeaderByORNoDataTable
        Dim dt As New dsFinanceTableAdapters.ReceiptsHeaderByORNoTableAdapter

        dt.Fill(ds, orno)
        If ds.Rows.Count <= 0 Then Return False
        Return True
    End Function

    Public Shared Function getNextORSeries() As String

        Dim strSQL As String = "SELECT ISNULL(Reference,'0') FROM ReceiptsHeader " _
              & " WHERE PK = (SELECT ISNULL(MAX(PK),1) FRom ReceiptsHeader)"

        Dim returnOR As String = clsTool.getDBValue(strSQL)

        If IsNumeric(returnOR) Then
            returnOR = CInt(returnOR) + 1
        End If

        Return returnOR

    End Function

    Public Shared Function SaveErrorLog(ByVal moduleName As String, ByVal errorMsg As String) As Boolean
        Dim strSQL As String = "INSERT INTO ZErrorLog (logtime,message,module,systemUser) " _
                        & " VALUES ( getdate(), '" & errorMsg & "','" & moduleName & "'," & loggedUserID & ")"

        Try
            clsTool.runDBSQL(strSQL)

            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function

    Public Shared Function nullToZero(ByVal input As String) As String
        If String.IsNullOrEmpty(input) Then Return "0"
        Return input
    End Function

    Public Shared Function isEnrollmentOpen() As Boolean
        If clsTool.GetSetting("ENROLLCLOSED").ToUpper = "TRUE" Then
            MsgBox("Enrollment period is already closed. You need to supply Admin password.")
            Dim frmPassword As New frmAdminPassword
            frmPassword.ShowDialog()
            If frmPassword.isDirty Then
                Return True
            Else
                Return False
            End If

        Else  'enrollment is still open
            Return True
        End If
    End Function

    REM 10.28.2011
    'TEst if the SY and SEM will be included in Ledger Accounts and Computations
    'as of new system,only records for 2nd sem 2011-2012 and afterwards will be included
    Public Shared Function IsSYSemIncludedInLedgerComputations(ByVal sempk As Integer, ByVal sypk As Integer) As Boolean

        'get the sorter for the semester
        Dim semsorter As Integer = getSEMSorter(sempk)

        'get the SY Full format example 2011-2012, 1998-1999, 2001-2002
        Dim syfull As String = getSYName(sypk)

        'get the first 4 digits
        Dim syfirstfour As Integer = 0
        If syfull.Length > 4 Then
            syfirstfour = CInt(syfull.Substring(0, 4))

        End If

        'now compare sy if equal or greater than 2011, if equal test for sem, if less return false, in greater return true
        If syfirstfour < 2011 Then
            Return False
        ElseIf syfirstfour > 2011 Then
            Return True

        ElseIf syfirstfour = 2011 Then
            'test for sem
            If semsorter >= 2 Then Return True Else Return False

        End If

        Return True

    End Function

    'sub to auto set the Student Type . If student has enrolled previous sems, set him to OLD
    Public Shared Sub AutoSetStudentTypeToOld(ByVal StudentPK As Integer)
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
        & ") " _
        & " AND studentPK = " & StudentPK


        runDBSQL(strSQL)

    End Sub
End Class
