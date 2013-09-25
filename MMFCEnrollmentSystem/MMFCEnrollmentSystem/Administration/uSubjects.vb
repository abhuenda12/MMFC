Public Class uSubjects
    

    Public Sub NewDoc()
        Dim frm As New frmSubjects
        frm.TextBox1.Text = ""
        frm.TextBox2.Text = ""
        frm.TextBox3.Text = ""
        frm.TextBox5.Text = ""
        frm.TextBox4.Text = ""
        frm.txtLabunits.Text = "0"
        frm.mPreReq = -1
        frm.loadSubjects()
        frm.ShowDialog()
        If frm.IsDirty Then

            'took out ProperCase method, allow user to put CAPS anywhere. 9.14.2012
            Me.DsSchool.Subjects.AddSubjectsRow(frm.TextBox1.Text, frm.TextBox2.Text, frm.TextBox5.Text, Convert.ToInt32(frm.TextBox3.Text), _
                            frm.mPreReq, frm.txtLabunits.Text, frm.chkMajor.Checked, Convert.ToInt32(frm.TextBox12.Text), _
                            frm.mPreReq2, frm.mPreReq3, frm.mPreReq4, frm.mPreReq5, frm.mPreReq6, frm.mPreReq7, _
                            Val(frm.ComboBox1.Text), False, frm.TextBoxRLEUnits.Text)

            Me.SubjectsTableAdapter.Update(Me.DsSchool.Subjects)

            Me.SubjectsTableAdapter.Fill(Me.DsSchool.Subjects)
        End If
    End Sub
    Public Sub OpenDoc()
        If Me.DsSchool.Subjects.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
        Dim frm As New frmSubjects
        frm.loadSubjects()

        With Me.DsSchool.Subjects(Me.SubjectsBindingSource.Position)
            frm.TextBox1.Text = .SubjectCode
            frm.TextBox2.Text = .SubjectName
            frm.TextBox3.Text = .units
            frm.mPreReq = .prereq
            frm.TextBox4.Text = frm.PreReqName

            '''''''''''''''''''''''''''''''''''''''''''
            'Added by Jefferson Jamora 10/17/07
            '''''''''''''''''''''''''''''''''''''''''''
            If .Isprereq2Null Then .prereq2 = -1
            frm.mPreReq2 = .prereq2
            If .Isprereq3Null Then .prereq3 = -1
            frm.mPreReq3 = .prereq3
            If .Isprereq4Null Then .prereq4 = -1
            frm.mPreReq4 = .prereq4
            If .Isprereq5Null Then .prereq5 = -1
            frm.mPreReq5 = .prereq5
            If .Isprereq6Null Then .prereq6 = -1
            frm.mPreReq6 = .prereq6
            If .Isprereq7Null Then .prereq7 = -1
            frm.mPreReq7 = .prereq7
            If .IsNumOfPreReqNull Then .NumOfPreReq = 0
            frm.TextBox12.Text = .NumOfPreReq

            frm.TextBox6.Text = frm.PreReq2Name
            frm.TextBox7.Text = frm.PreReq3Name
            frm.TextBox8.Text = frm.PreReq4Name
            frm.TextBox9.Text = frm.PreReq5Name
            frm.TextBox10.Text = frm.PreReq6Name
            frm.TextBox11.Text = frm.PreReq7Name
            '''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''
            ''Jefferson Jamora 10/18/07
            If .IsCreditGroupNull Then .CreditGroup = 1
            frm.ComboBox1.Text = .CreditGroup
            '''''''''''''''''''''''''''''''''''''''''''

            frm.TextBox5.Text = .Remarks
            If .IslabunitsNull Then .labunits = 0
            frm.txtLabunits.Text = .labunits
            If .IsmajorNull Then .major = False
            frm.chkMajor.Checked = .major

            If .IsinactiveNull Then .inactive = False
            frm.chkInactive.Checked = .inactive

            'RLE Units. 10.21.2011
            If .IsRLEunitsNull Then .RLEunits = 0
            frm.TextBoxRLEUnits.Text = .RLEunits

        End With

        frm.Hide()

        frm.ShowDialog()

        If frm.IsDirty Then
            With Me.DsSchool.Subjects(Me.SubjectsBindingSource.Position)
                .SubjectCode = frm.TextBox1.Text


                .SubjectName = frm.TextBox2.Text

                .units = frm.TextBox3.Text
                .Remarks = frm.TextBox5.Text

                '''''''''''''''''''''''''''''''''''''''''''
                'Added by Jefferson Jamora 10/17/07
                '''''''''''''''''''''''''''''''''''''''''''
                .NumOfPreReq = frm.TextBox12.Text
                .prereq2 = frm.mPreReq2
                .prereq3 = frm.mPreReq3
                .prereq4 = frm.mPreReq4
                .prereq5 = frm.mPreReq5
                .prereq6 = frm.mPreReq6
                .prereq7 = frm.mPreReq7
                '''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''
                ''Jefferson Jamora 10/18/07
                .CreditGroup = Val(frm.ComboBox1.Text)
                '''''''''''''''''''''''''''''''''''''''''''

                .prereq = frm.mPreReq
                .labunits = frm.txtLabunits.Text
                .major = frm.chkMajor.Checked

                .inactive = frm.chkInactive.Checked

                .RLEunits = frm.TextBoxRLEUnits.Text

            End With

            Me.SubjectsTableAdapter.Update(Me.DsSchool.Subjects)
            Me.SubjectsTableAdapter.Fill(Me.DsSchool.Subjects)
        End If
    End Sub
    Public Sub DeleteDoc()
        If Me.DsSchool.Subjects.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try

                Me.DsSchool.Subjects(Me.SubjectsBindingSource.Position).inactive = True
                Me.SubjectsTableAdapter.Update(Me.DsSchool.Subjects)
                Me.SubjectsTableAdapter.Fill(Me.DsSchool.Subjects)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub uSubjects_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dLoad()
    End Sub
    Private Sub dLoad()
        Me.SubjectsTableAdapter.Fill(Me.DsSchool.Subjects)
    End Sub

    'ben11.23.2007
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            goFilter()
        End If
    End Sub

    'benhide rows not meeting the filter requirement
    Private Sub goFilter()
        Dim rows As Integer = Me.DsSchool.Subjects.Rows.Count
        If rows <= 0 Then MsgBox("No subjects offered.") : Exit Sub

        dLoad()
        'put binding source at last row
        Me.SubjectsBindingSource.Position = rows - 1
        Dim hits As Integer = 0
        Dim i As Integer
        For i = 0 To rows - 1
            With Me.DataGridView1.Rows(i)
                'check if last row and if theres no hit yet
                If i = rows - 1 And hits <= 0 Then MsgBox("No records meeting your filter.") : dLoad() : Exit Sub
                If CStr(.Cells(0).Value).ToUpper.Contains(Me.txtFilter.Text.ToUpper) _
                   Or CStr(.Cells(1).Value).ToUpper.Contains(Me.txtFilter.Text.ToUpper) Then
                    hits += 1
                    If hits = 1 Then Me.SubjectsBindingSource.Position = i 'transfer currency to first hit row
                Else
                    .Visible = False
                End If
            End With
        Next
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewDoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        OpenDoc()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        DeleteDoc()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        goFilter()
    End Sub

    'Check for Fusings
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.DsSchool.Subjects.Rows.Count = 0 Then MsgBox("Nothing to check!") : Exit Sub
        Dim SubjectPK As Integer = Me.DsSchool.Subjects(Me.SubjectsBindingSource.Position).SubjectPriKey

        'get the offerings and fusions for the active semester
        Dim frm As New frmSubjectFusionList
        frm.m_SubjectPK = SubjectPK
        frm.LoadGrid()
        frm.ShowDialog()

    End Sub
End Class
