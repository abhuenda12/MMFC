Public Class uGradesSubjectTeacher
    Dim m_SYOFF As Integer = -1
    Dim m_Rec As dsRegistrar.SYOfferingSelect2Row
    Dim m_Course As Integer = -1
    Dim Loaded As Boolean = False

    Public Sub Initialize()
        Me.SchoolYearTableAdapter.Fill(Me.DsSchool.SchoolYear)
        Me.SemesterTableAdapter.Fill(Me.DsSchool.Semester)
        Me.ComboBox1.SelectedValue = clsTool.GetCurYearPK
        Me.ComboBox2.SelectedValue = clsTool.GetCurSemPK
        ''Me.TextBox1.Text = ""
        Me.m_SYOFF = -1
        Me.DsRegistrar.TemplateGradeEntry.Clear()
    End Sub

    Sub LoadStudents()
        If Me.m_SYOFF = -1 Then Exit Sub

    End Sub
    Sub ClearGrid()

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Me.TextBox1.Text = ""
        Me.m_SYOFF = -1
        Me.DsRegistrar.TemplateGradeEntry.Clear()
    End Sub
    'Button choose subject then load student and grades
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmClassSelect2
        frm.m_SY = ComboBox1.SelectedValue
        frm.m_SEM = ComboBox2.SelectedValue
        frm.LoadGrid()
        frm.ShowDialog()

        If frm.Selected Then

            Dim frmWait As New frmWait
            frmWait.Show()
            Application.DoEvents()

            Try
                With frm.DsRegistrar.SYOfferingSelect2(frm.SYOfferingSelect2BindingSource.Position)


                    GroupControl1.Text = "Encode Grades For : " & clsTool.GetSubjectDescription(.subjectpk) _
                                        & " - " & clsTool.getTeacherName(.teacherid)

                    Me.m_Rec = frm.DsRegistrar.SYOfferingSelect2(frm.SYOfferingSelect2BindingSource.Position)
                    Me.DsRegistrar.TemplateGradeEntry.Clear()
                    Dim ds As New dsRegistrar
                    Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsbySyOPKTableAdapter
                    dt.Fill(ds.EnrollSubjectsbySyOPK, frm.DsRegistrar.SYOfferingSelect2(frm.SYOfferingSelect2BindingSource.Position).syofferingpk)
                    Dim ctr As Integer
                    For ctr = 0 To ds.EnrollSubjectsbySyOPK.Rows.Count - 1
                        Me.m_Course = ds.EnrollSubjectsbySyOPK(ctr).coursepk
                        Dim r As dsRegistrar.EnrollSubjectsbySyOPKRow = ds.EnrollSubjectsbySyOPK(ctr)

                        Dim syofferingPK As Integer = ds.EnrollSubjectsbySyOPK(ctr).syofferingpk
                        Dim teacher As Integer = getTeacher(syofferingPK)
                        Dim subjectpkFromSYOfferingRecord As Integer = .subjectpk

                        Dim g As Decimal = getGrades(r.subjectpk, teacher, ds.EnrollSubjectsbySyOPK(ctr).studentpk, ds.EnrollSubjectsbySyOPK(ctr).syofferingpk, subjectpkFromSYOfferingRecord)

                        If Not Me.isSpecial(ds.EnrollSubjectsbySyOPK(ctr).enrollpk) Then
                            Me.DsRegistrar.TemplateGradeEntry.AddTemplateGradeEntryRow(clsTool.getStudentName(r.studentpk), r.studentpk, g)
                        End If
                    Next

                    Loaded = True

                End With

            Catch ex As Exception

            Finally

                frmWait.Close()
            End Try
        End If
    End Sub

    REM Modified 4/27/2013
    'Get grades using the subjectpk in the EnrollSubjects table
    Function getGrades(ByVal subj As Integer, ByVal teacher As Integer, ByVal student As Integer, ByVal sypk As Integer, ByVal subjectpkFromSYOfferingRecord As Integer) As Double
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.StudentGradesTableAdapter
        dt.Fill(ds.StudentGrades, "ENR", subj, ComboBox1.SelectedValue, ComboBox2.SelectedValue, student)
        If ds.StudentGrades.Rows.Count > 0 Then
            Return ds.StudentGrades(0).grade
        Else
            REM if there are no grades, try to use the syofferingpk to get the subjectpk 
            REM there are cases where the Student Enrolled Subject is different with the other section students due to syoffering subject changes while there are already enrolled students
            REM e.g.  3/1/2013, i enrolled juan to syoffering poli sci (syplk = 22276) , subject of poli sci (= 235)
            REM then on 3/3/2013, admin changed the syoffering , using the subject name FusedPoliSci (sypk still 22276) but subjectpk changed to (272)
            REM this results to Juan having an enrolled subject (235) under syoffering (22276) but this syoffering RIGHT NOW has subject = 272

            dt.Fill(ds.StudentGrades, "ENR", subjectpkFromSYOfferingRecord, ComboBox1.SelectedValue, ComboBox2.SelectedValue, student)
            If ds.StudentGrades.Rows.Count > 0 Then
                Return ds.StudentGrades(0).grade
            End If

        End If
        'code reaches here, no grades saved
        Return 0
    End Function

    Function getTeacher(ByVal id As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SYOfferingbyPKTableAdapter
        dt.Fill(ds.SYOfferingbyPK, id)
        If ds.SYOfferingbyPK.Rows.Count > 0 Then Return ds.SYOfferingbyPK(0).teacherid
        Return -1
    End Function
 

    Function isSpecial(ByVal key As Integer) As Boolean
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.SpecialCourseGradesbyEPKTableAdapter
        dt.Fill(ds.SpecialCourseGradesbyEPK, key)
        If ds.SpecialCourseGradesbyEPK.Rows.Count = 0 Then Return False
        Return True
    End Function
    'Button Update
    'ben12.6 . Edit grade if previous grade existing. Add grade if none existing. 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        updateGrades()
       

    End Sub
    'ben12.6
    Private Sub updateGrades()
        If Not Loaded Then MsgBox("Nothing loaded") : Exit Sub
        Dim isError As Boolean = False
        Dim frm As New frmWait
        frm.Show()
        Application.DoEvents()
        Dim i As Integer
        For i = 0 To Me.DsRegistrar.TemplateGradeEntry.Rows.Count - 1
            With Me.DsRegistrar.TemplateGradeEntry(i)
                isError = clsTool.updateStudentGrade(.Studentpk, m_Rec.semesterpk, m_Rec.sypk, m_Rec.subjectpk, .Grade, _
                  m_Rec.teacherid, m_Course)
            End With
        Next

        If isError Then
            MsgBox("Error Saving! Try Again.")
        Else
            MsgBox("Grades Processed and Saved!")
        End If

        frm.Hide()
    End Sub

    
End Class
