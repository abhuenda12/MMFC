Public Class frmStudents

#Region "Variables"
    Public studentPK As Integer = -1
    Public IsDirty As Boolean = False
    Public gender As String = ""
    Private frmPrevSchool As frmPrevSchoolsDet

#End Region

#Region "Button Events"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then MsgBox("ID Cannot be empty!") : Exit Sub
        If String.IsNullOrEmpty(txtStudentName.Text) Then MsgBox("Name cannot be empty!") : Exit Sub
        'If Not String.IsNullOrEmpty(TextBox10.Text) Then If Not IsDate(TextBox10.Text) Then MsgBox("Birthday should be of type date!") : Exit Sub
        If String.IsNullOrEmpty(Me.cmbStudentType.Text) Then MsgBox("Student Type cannot be empty!") : Exit Sub

        If Me.cmbStudentType.Text.ToUpper <> "OLD" And Me.cmbStudentType.Text.ToUpper <> "NEW" _
           And Me.cmbStudentType.Text.ToUpper <> "TRANSFEREE" And Me.cmbStudentType.Text.ToUpper <> "CROSS-ENROLLED" Then
            MsgBox("Invalid Student Type!")
            Exit Sub
        End If

        'Check address length
        If Me.txtAddress1.TextLength > 1000 Or Me.txtAddress2.TextLength > 1000 Or Me.txtAddress3.TextLength > 1000 Then
            MsgBox("You've exceeded the allowed characters of 1000 per Address field. Please edit. ")
            Exit Sub
        End If

        If Me.rdoMale.Checked Then gender = "Male" Else gender = "Female"


        'check for frmPrevSchool if existing then set the student pk if the pk is still -1
        If Not Me.frmPrevSchool Is Nothing Then
            saveMorePreviousSchools()
        End If

        Me.IsDirty = True
        Me.Hide()
    End Sub


#End Region

#Region "Validation School Years"
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''Jefferson Jamora 10/18/07: Validation for Year attended.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub TextBox13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.LostFocus
        If Len(Me.TextBox13.Text) < 9 Then
            MsgBox("Please follow sample format.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox15_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox15.LostFocus
        If Len(Me.TextBox15.Text) < 9 Then
            MsgBox("Please follow sample format.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox17_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox17.LostFocus
        If Me.TextBox17.Text = "" And Len(Me.TextBox17.Text) < 9 Then
            MsgBox("Please follow sample format.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox19_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox19.LostFocus
        If Me.TextBox19.Text = "" And Len(Me.TextBox19.Text) < 9 Then
            MsgBox("Please follow sample format.", MsgBoxStyle.Critical)
        End If
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#End Region
   
#Region "More Schools Button"
    'Ben 7.31.2008
    'Saving of Previous Colleges > 4 different Grid. saves on different Table ( dbo.PreviousSchools )
    Private Sub btnMorePrevSchools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMorePrevSchools.Click

        morePreviousSchools()
    End Sub

    Sub morePreviousSchools()

        'check if frm has been initialized 
        If Me.frmPrevSchool Is Nothing Then
            frmPrevSchool = New frmPrevSchoolsDet
            frmPrevSchool.studentPK = Me.studentPK
            frmPrevSchool.lblStudentName.Text = Me.txtStudentName.Text
            frmPrevSchool.loadData() 'load the grid of previous schools
        End If

        Me.frmPrevSchool.ShowDialog()

    End Sub

    Sub saveMorePreviousSchools()
        Dim ds As New dsReg2.PreviousSchoolsByStudentPKDataTable
        Dim dt As New dsReg2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
        Dim strSQL As String = ""

        'for ADD Mode we get the latest studentpk from table then set that as the student pk of New Records
        If Me.studentPK <= 0 Then
            strSQL = "SELECT ISNULL(MAX(StudentPK),0) FROM Students "
            Me.studentPK = CInt(clsTool.getDBValue(strSQL)) + 1
        End If

        'DO delete of all existing Previous Schools Entry of student (for edit mode to avoid duplicate entries)
        strSQL = "DELETE FROM PreviousSchools WHERE StudentPK = " & Me.studentPK
        clsTool.runDBSQL(strSQL)

        Try

            Dim i As Integer
            For i = 0 To frmPrevSchool.DsReg2.PreviousSchoolsByStudentPK.Rows.Count - 1
                With frmPrevSchool.DsReg2.PreviousSchoolsByStudentPK(i)
                    If .RowState = DataRowState.Deleted Or .RowState = DataRowState.Detached Then Continue For

                    ds.AddPreviousSchoolsByStudentPKRow(.SchoolName, .YearAttend, Me.studentPK)
                    dt.Update(ds)
                End With
            Next

            frmPrevSchool.Dispose()

        Catch ex As Exception
            MsgBox("An Error occurred in saving the previous schools. Please report this to Administrator. " & vbCrLf & ex.Message)
        End Try


    End Sub
#End Region


    
End Class