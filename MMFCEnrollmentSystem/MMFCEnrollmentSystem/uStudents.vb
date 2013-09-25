Public Class uStudents

#Region "New/Open/Delete"

    Public Sub NewDoc()
        Dim frm As New frmStudents
        frm.rdoMale.Checked = True
        frm.chk2ndCourser.Checked = False
        frm.ShowDialog()
        If frm.IsDirty Then
            With frm
                Me.DsReg2.Students.AddStudentsRow(.TextBox1.Text, .txtStudentName.Text, .txtAddress1.Text, _
                   .txtAddress2.Text, .txtAddress3.Text, .TextBox6.Text, .TextBox7.Text, .TextBox8.Text, .TextBox9.Text, _
                    .TextBox10.Text, .txtElem.Text, .TextBox13.Text, .txtHighSchool.Text, .TextBox15.Text, .txtCollege1.Text, _
                    .TextBox17.Text, .txtCollege2.Text, .TextBox19.Text, .cmbStudentType.Text, .RegDate.Value.Date, .gender, .TextBox11.Text, _
                    FormatDateTime(.GradDate.Value.Date, DateFormat.ShortDate), .txtCollegeGraduated.Text, .txtCourseGraduated.Text, .txtConcentration.Text, _
                    .txtCollege3.Text, .txtCollege3Date.Text, .txtCollege4.Text, .txtCollege4Date.Text, .chk2ndCourser.Checked)
            End With
            Me.StudentsTableAdapter.Update(Me.DsReg2.Students)
        End If
    End Sub
    Public Sub OpenDoc()

        Try
            If Me.DsReg2.Students.Rows.Count = 0 Then MsgBox("Nothing to open!") : Exit Sub
            Dim r As dsReg2.StudentsRow = Me.DsReg2.Students(Me.StudentsBindingSource.Position)
            Dim frm As New frmStudents
            frm.studentPK = r.StudentPK

            frm.TextBox1.Text = r.StudentID
            frm.txtStudentName.Text = r.StudentName
            frm.txtAddress1.Text = r.Address1
            frm.txtAddress2.Text = r.Address2
            frm.txtAddress3.Text = r.Address3
            frm.TextBox6.Text = r.Phone
            frm.TextBox7.Text = r.MotherName
            frm.TextBox8.Text = r.FatherName
            frm.TextBox9.Text = r.Guardian


            If r.IsbirthplaceNull Then r.birthplace = ""
            frm.TextBox11.Text = r.birthplace

            ''If r.IsgradDateNull Then r.gradDate = FormatDateTime(Now, DateFormat.ShortDate)
            ''frm.GradDate.Value = Convert.ToDateTime(r.gradDate)
            If r.IsgradDateNull Then r.gradDate = Now.ToString
            frm.GradDate.Value = Convert.ToDateTime(r.gradDate & " 00:00:00 AM")

            frm.TextBox10.Text = r.Birthdate
            frm.txtElem.Text = r.Edubackground1
            frm.TextBox13.Text = r.Edubackgrounddate1
            frm.txtHighSchool.Text = r.Edubackground2
            frm.TextBox15.Text = r.Edubackgrounddate2
            frm.txtCollege1.Text = r.Edubackground3
            frm.TextBox17.Text = r.Edubackgrounddate3
            frm.txtCollege2.Text = r.Edubackground4
            frm.TextBox19.Text = r.Edubackgrounddate4
            If r.IsStudentTypeNull Then r.StudentType = "OLD"
            frm.cmbStudentType.Text = r.StudentType
            If r.IsGenderNull Then r.Gender = "Male"
            If r.Gender = "Male" Then
                frm.rdoMale.Checked = True
            Else
                frm.rdoFemale.Checked = True
            End If
            If r.IsregDateNull Then r.regDate = Now()
            frm.RegDate.Value = r.regDate
            If r.IsgradCollegeNull Then r.gradCollege = ""
            If r.IsgradConcentrationNull Then r.gradConcentration = ""
            If r.IsgradCourseNull Then r.gradCourse = ""
            frm.txtCollegeGraduated.Text = r.gradCollege
            frm.txtConcentration.Text = r.gradConcentration
            frm.txtCourseGraduated.Text = r.gradCourse

            'ben1.25.2008
            If r.IsEdubackground5Null Then r.Edubackground5 = ""
            If r.IsEdubackground6Null Then r.Edubackground6 = ""
            If r.IsEdubackgrounddate5Null Then r.Edubackgrounddate5 = ""
            If r.IsEdubackgrounddate6Null Then r.Edubackgrounddate6 = ""
            frm.txtCollege3.Text = r.Edubackground5
            frm.txtCollege4.Text = r.Edubackground6
            frm.txtCollege3Date.Text = r.Edubackgrounddate5
            frm.txtCollege4Date.Text = r.Edubackgrounddate6
            If r.IsSecondCourserNull Then r.SecondCourser = False
            frm.chk2ndCourser.Checked = r.SecondCourser

            frm.ShowDialog()
            If frm.IsDirty Then
                r.StudentID = frm.TextBox1.Text
                r.StudentName = frm.txtStudentName.Text
                r.Address1 = frm.txtAddress1.Text
                r.Address2 = frm.txtAddress2.Text
                r.Address3 = frm.txtAddress3.Text
                r.Phone = frm.TextBox6.Text
                r.MotherName = frm.TextBox7.Text
                r.FatherName = frm.TextBox8.Text
                r.Guardian = frm.TextBox9.Text
                r.Birthdate = frm.TextBox10.Text
                r.Edubackground1 = frm.txtElem.Text
                r.Edubackgrounddate1 = frm.TextBox13.Text
                r.Edubackground2 = frm.txtHighSchool.Text
                r.Edubackgrounddate2 = frm.TextBox15.Text
                r.Edubackground3 = frm.txtCollege1.Text
                r.Edubackgrounddate3 = frm.TextBox17.Text
                r.Edubackground4 = frm.txtCollege2.Text
                r.Edubackgrounddate4 = frm.TextBox19.Text
                r.StudentType = frm.cmbStudentType.Text
                r.Gender = frm.gender
                r.regDate = frm.RegDate.Value.Date

                r.birthplace = frm.TextBox11.Text
                r.gradDate = FormatDateTime(frm.GradDate.Value.Date, DateFormat.ShortDate)

                r.gradCollege = frm.txtCollegeGraduated.Text
                r.gradConcentration = frm.txtConcentration.Text
                r.gradCourse = frm.txtCourseGraduated.Text

                r.Edubackground5 = frm.txtCollege3.Text
                r.Edubackground6 = frm.txtCollege4.Text
                r.Edubackgrounddate5 = frm.txtCollege3Date.Text
                r.Edubackgrounddate6 = frm.txtCollege4Date.Text
                r.SecondCourser = frm.chk2ndCourser.Checked

                Try
                    Me.StudentsTableAdapter.Update(Me.DsReg2.Students)
                Catch ex As Exception
                    MsgBox("Error Saving Details. " & vbCrLf & ex.Message)
                End Try

            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
       
    End Sub

    Public Sub DeleteDoc()
        If Me.DsReg2.Students.Rows.Count = 0 Then MsgBox("Nothing to delete!") : Exit Sub
        If MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DsReg2.Students(Me.StudentsBindingSource.Position).Delete()
            Me.StudentsTableAdapter.Update(Me.DsReg2.Students)
        End If
    End Sub

#End Region

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            
            Application.DoEvents()
            Me.StudentsTableAdapter.Fill(Me.DsReg2.Students, "%" & txtFilter.Text & "%")

        End If
    End Sub

    Sub GoFilter()
        Application.DoEvents()
        Me.StudentsTableAdapter.Fill(Me.DsReg2.Students, "%" & txtFilter.Text & "%")
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
        GoFilter()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ShowAll()
    End Sub

    Sub ShowAll()

        Application.DoEvents()
        Me.StudentsTableAdapter.Fill(Me.DsReg2.Students, "%")
    End Sub


    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If Me.DsReg2.Students(e.RowIndex).RowState = DataRowState.Deleted Then Exit Sub
        If Me.DsReg2.Students(e.RowIndex).RowState = DataRowState.Detached Then Exit Sub
        If e.ColumnIndex = 6 Then
            e.Value = clsTool.getStudentRecentCourse(Me.DsReg2.Students(e.RowIndex).StudentPK)
        End If
    End Sub
End Class
