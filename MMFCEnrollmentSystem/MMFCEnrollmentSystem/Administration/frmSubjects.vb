Public Class frmSubjects
    Public IsDirty As Boolean = False
    Public mPreReq = -1
    Public mPreReq2 = -1
    Public mPreReq3 = -1
    Public mPreReq4 = -1
    Public mPreReq5 = -1
    Public mPreReq6 = -1
    Public mPreReq7 = -1

    Public ReadOnly Property PreReqName() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq2Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq2)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq3Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq3)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq4Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq4)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq5Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq5)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq6Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq6)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    '' 10/17/07
    Public ReadOnly Property PreReq7Name() As String
        Get
            Dim ds As New dsSchool
            Dim dt As New dsSchoolTableAdapters.SubjectsByPriKeyTableAdapter
            dt.Fill(ds.SubjectsByPriKey, mPreReq7)
            If ds.SubjectsByPriKey.Rows.Count > 0 Then
                Return ds.SubjectsByPriKey(0).SubjectName
            Else
                Return ""
            End If
        End Get
    End Property

    REM Saving Button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then MsgBox("Subj Abbrev cannot be empty!") : Exit Sub
        If String.IsNullOrEmpty(TextBox2.Text) Then MsgBox("Subject Name cannot be empty!") : Exit Sub
        If String.IsNullOrEmpty(TextBox3.Text) Then MsgBox("Units cannot be blank!") : Exit Sub
        If Not IsNumeric(TextBox3.Text) Then MsgBox("Units should be numeric!") : Exit Sub
        If Not IsNumeric(Me.txtLabunits.Text) Then MsgBox("Lab Units should be numeric!") : Exit Sub


        '10.21.2011 . make RLEunits numeric
        If Not IsNumeric(TextBoxRLEUnits.Text) Then TextBoxRLEUnits.Text = 0


        '' 10/18/07
        If (Not IsNumeric(Val(Me.ComboBox1.Text))) Or Me.ComboBox1.Text = "" Then MsgBox("Input Credit Group Number should be numeric", MsgBoxStyle.Critical, "   Error!") : Exit Sub
        SaveIfGood()



    End Sub

    Public Sub loadSubjects()
        Me.SubjectsTableAdapter.Fill(Me.DsSchool.Subjects)
        Me.chkMajor.Checked = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq = frm.m_SubjectID
            Me.TextBox4.Text = frm.m_SubjectName
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox4.Text = ""
        Me.mPreReq = -1
    End Sub

    '' 10/17/07
    Public Sub SaveIfGood()
        If Me.TextBox4.Text = "" Then
            Me.TextBox12.Text = 0
        ElseIf Me.TextBox6.Text = "" Then
            Me.TextBox12.Text = 1
        ElseIf Me.TextBox7.Text = "" Then
            Me.TextBox12.Text = 2
        ElseIf Me.TextBox8.Text = "" Then
            Me.TextBox12.Text = 3
        ElseIf Me.TextBox9.Text = "" Then
            Me.TextBox12.Text = 4
        ElseIf Me.TextBox10.Text = "" Then
            Me.TextBox12.Text = 5
        ElseIf Me.TextBox11.Text = "" Then
            Me.TextBox12.Text = 6
        End If

        If Val(Me.TextBox12.Text) = 7 Then
            mPreReq = -1
            mPreReq2 = -1
            mPreReq3 = -1
            mPreReq4 = -1
            mPreReq5 = -1
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 1 Then
            '    If Me.TextBox4.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq2 = -1
            mPreReq3 = -1
            mPreReq4 = -1
            mPreReq5 = -1
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 2 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq3 = -1
            mPreReq4 = -1
            mPreReq5 = -1
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 3 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox7.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq4 = -1
            mPreReq5 = -1
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 4 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox7.Text = "" Or Me.TextBox8.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq5 = -1
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 5 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox7.Text = "" Or Me.TextBox8.Text = "" Or Me.TextBox9.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq6 = -1
            mPreReq7 = -1

        ElseIf Val(Me.TextBox12.Text) = 6 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox7.Text = "" Or Me.TextBox8.Text = "" Or Me.TextBox9.Text = "" Or Me.TextBox10.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
            '    End If
            mPreReq7 = -1

            'ElseIf Val(Me.TextBox12.Text) = 7 Then
            '    If Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox7.Text = "" Or Me.TextBox8.Text = "" Or Me.TextBox9.Text = "" Or Me.TextBox10.Text = "" Or Me.TextBox11.Text = "" Then
            '        MsgBox("Pre-Requisite must have an input.", MsgBoxStyle.Critical, "   Data incomplete.")
            '        Exit Sub
        End If


        'End If

        IsDirty = True
        Me.Hide()
    End Sub

    ''Added by  10/17/07: Number of PreReq required.
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        If (Me.TextBox12.Text = "") Or (IsNumeric(Me.TextBox12.Text) = False) Then MsgBox("Invalid Input", MsgBoxStyle.Critical) : Me.TextBox12.Text = 0 : Me.TextBox12.Focus() : Exit Sub
        If (Val(Me.TextBox12.Text) > 7) Then MsgBox("Invalid Input", MsgBoxStyle.Critical) : Me.TextBox12.Text = 0 : Me.TextBox12.Focus() : Exit Sub
        NumReq()
    End Sub

    ''Added by  10/17/07
    Public Sub NumReq()
        If Val(Me.TextBox12.Text) = 0 Then
            Me.GroupBox1.Visible = False
            Me.Height = 346
            Me.lblRem.Top = 181
            Me.TextBox5.Top = 178
            Me.Button1.Top = 288

        ElseIf Val(Me.TextBox12.Text) = 1 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 47
            Me.Height = 406
            Me.lblRem.Top = 238
            Me.TextBox5.Top = 235
            Me.Button1.Top = 345

            ''labels
            Me.Label7.Visible = False
            Me.Label8.Visible = False
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = False
            Me.TextBox7.Visible = False
            Me.TextBox8.Visible = False
            Me.TextBox9.Visible = False
            Me.TextBox10.Visible = False
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = False
            Me.Button5.Visible = False
            Me.Button6.Visible = False
            Me.Button7.Visible = False
            Me.Button8.Visible = False
            Me.Button9.Visible = False
            Me.Button10.Visible = False
            Me.Button11.Visible = False
            Me.Button12.Visible = False
            Me.Button13.Visible = False
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 2 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 73
            Me.Height = 432
            Me.lblRem.Top = 238 + (26)
            Me.TextBox5.Top = 235 + (26)
            Me.Button1.Top = 345 + (26)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = False
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = False
            Me.TextBox8.Visible = False
            Me.TextBox9.Visible = False
            Me.TextBox10.Visible = False
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = False
            Me.Button7.Visible = False
            Me.Button8.Visible = False
            Me.Button9.Visible = False
            Me.Button10.Visible = False
            Me.Button11.Visible = False
            Me.Button12.Visible = False
            Me.Button13.Visible = False
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 3 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 99
            Me.Height = 458
            Me.lblRem.Top = 238 + (26 * 2)
            Me.TextBox5.Top = 235 + (26 * 2)
            Me.Button1.Top = 345 + (26 * 2)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = True
            Me.TextBox8.Visible = False
            Me.TextBox9.Visible = False
            Me.TextBox10.Visible = False
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = True
            Me.Button7.Visible = True
            Me.Button8.Visible = False
            Me.Button9.Visible = False
            Me.Button10.Visible = False
            Me.Button11.Visible = False
            Me.Button12.Visible = False
            Me.Button13.Visible = False
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 4 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 125
            Me.Height = 484
            Me.lblRem.Top = 238 + (26 * 3)
            Me.TextBox5.Top = 235 + (26 * 3)
            Me.Button1.Top = 345 + (26 * 3)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = True
            Me.TextBox8.Visible = True
            Me.TextBox9.Visible = False
            Me.TextBox10.Visible = False
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = True
            Me.Button7.Visible = True
            Me.Button8.Visible = True
            Me.Button9.Visible = True
            Me.Button10.Visible = False
            Me.Button11.Visible = False
            Me.Button12.Visible = False
            Me.Button13.Visible = False
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 5 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 151
            Me.Height = 510
            Me.lblRem.Top = 238 + (26 * 4)
            Me.TextBox5.Top = 235 + (26 * 4)
            Me.Button1.Top = 345 + (26 * 4)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = False
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = True
            Me.TextBox8.Visible = True
            Me.TextBox9.Visible = True
            Me.TextBox10.Visible = False
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = True
            Me.Button7.Visible = True
            Me.Button8.Visible = True
            Me.Button9.Visible = True
            Me.Button10.Visible = True
            Me.Button11.Visible = True
            Me.Button12.Visible = False
            Me.Button13.Visible = False
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 6 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 177
            Me.Height = 536
            Me.lblRem.Top = 238 + (26 * 5)
            Me.TextBox5.Top = 235 + (26 * 5)
            Me.Button1.Top = 345 + (26 * 5)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = True
            Me.Label12.Visible = False
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = True
            Me.TextBox8.Visible = True
            Me.TextBox9.Visible = True
            Me.TextBox10.Visible = True
            Me.TextBox11.Visible = False
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = True
            Me.Button7.Visible = True
            Me.Button8.Visible = True
            Me.Button9.Visible = True
            Me.Button10.Visible = True
            Me.Button11.Visible = True
            Me.Button12.Visible = True
            Me.Button13.Visible = True
            Me.Button14.Visible = False
            Me.Button15.Visible = False

        ElseIf Val(Me.TextBox12.Text) = 7 Then
            Me.GroupBox1.Visible = True
            Me.GroupBox1.Height = 203
            Me.Height = 562
            Me.lblRem.Top = 238 + (26 * 6)
            Me.TextBox5.Top = 235 + (26 * 6)
            Me.Button1.Top = 345 + (26 * 6)

            ''labels
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = True
            Me.Label12.Visible = True
            ''textboxes
            Me.TextBox6.Visible = True
            Me.TextBox7.Visible = True
            Me.TextBox8.Visible = True
            Me.TextBox9.Visible = True
            Me.TextBox10.Visible = True
            Me.TextBox11.Visible = True
            ''buttons
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.Button6.Visible = True
            Me.Button7.Visible = True
            Me.Button8.Visible = True
            Me.Button9.Visible = True
            Me.Button10.Visible = True
            Me.Button11.Visible = True
            Me.Button12.Visible = True
            Me.Button13.Visible = True
            Me.Button14.Visible = True
            Me.Button15.Visible = True

        Else : Exit Sub

        End If
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.TextBox6.Text = ""
        mPreReq2 = -1
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.TextBox7.Text = ""
        mPreReq3 = -1
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.TextBox8.Text = ""
        mPreReq4 = -1
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.TextBox9.Text = ""
        mPreReq5 = -1
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.TextBox10.Text = ""
        mPreReq6 = -1
    End Sub

    '' 10/17/07: Clear PreReq
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.TextBox11.Text = ""
        mPreReq7 = -1
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq2 = frm.m_SubjectID
            Me.TextBox6.Text = frm.m_SubjectName
        End If
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq3 = frm.m_SubjectID
            Me.TextBox7.Text = frm.m_SubjectName
        End If
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq4 = frm.m_SubjectID
            Me.TextBox8.Text = frm.m_SubjectName
        End If
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq5 = frm.m_SubjectID
            Me.TextBox9.Text = frm.m_SubjectName
        End If
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq6 = frm.m_SubjectID
            Me.TextBox10.Text = frm.m_SubjectName
        End If
    End Sub

    '' 10/17/07: Insert Subject for PreReq
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim frm As New frmSubjectsSelect
        frm.ShowDialog()
        If frm.Selected Then
            Me.mPreReq7 = frm.m_SubjectID
            Me.TextBox11.Text = frm.m_SubjectName
        End If
    End Sub

End Class