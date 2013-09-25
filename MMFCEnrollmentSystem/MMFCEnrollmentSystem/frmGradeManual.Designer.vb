<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGradeManual
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.chkFromPrevSchool = New System.Windows.Forms.CheckBox
        Me.txtCompletionGrade = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtExtSubjCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnExCollege = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbCreditGroup = New System.Windows.Forms.ComboBox
        Me.txtUnits = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.txtCourse = New System.Windows.Forms.TextBox
        Me.btnSubject = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtExtSubj = New System.Windows.Forms.TextBox
        Me.txtExtSchool = New System.Windows.Forms.TextBox
        Me.txtGrade = New System.Windows.Forms.TextBox
        Me.txtSemester = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtExUnits = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBoxMapSubject = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkFromPrevSchool
        '
        Me.chkFromPrevSchool.AutoSize = True
        Me.chkFromPrevSchool.Enabled = False
        Me.chkFromPrevSchool.Location = New System.Drawing.Point(123, 321)
        Me.chkFromPrevSchool.Name = "chkFromPrevSchool"
        Me.chkFromPrevSchool.Size = New System.Drawing.Size(192, 19)
        Me.chkFromPrevSchool.TabIndex = 52
        Me.chkFromPrevSchool.Text = "Grade is from Previous School"
        Me.chkFromPrevSchool.UseVisualStyleBackColor = True
        '
        'txtCompletionGrade
        '
        Me.txtCompletionGrade.Location = New System.Drawing.Point(121, 303)
        Me.txtCompletionGrade.Name = "txtCompletionGrade"
        Me.txtCompletionGrade.Size = New System.Drawing.Size(80, 23)
        Me.txtCompletionGrade.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 306)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 15)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Completion Grade"
        '
        'txtExtSubjCode
        '
        Me.txtExtSubjCode.Location = New System.Drawing.Point(123, 131)
        Me.txtExtSubjCode.Multiline = True
        Me.txtExtSubjCode.Name = "txtExtSubjCode"
        Me.txtExtSubjCode.Size = New System.Drawing.Size(285, 55)
        Me.txtExtSubjCode.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 15)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Ex Subject Code *"
        '
        'btnExCollege
        '
        Me.btnExCollege.Location = New System.Drawing.Point(91, 96)
        Me.btnExCollege.Name = "btnExCollege"
        Me.btnExCollege.Size = New System.Drawing.Size(26, 25)
        Me.btnExCollege.TabIndex = 55
        Me.btnExCollege.Text = ".."
        Me.btnExCollege.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 279)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 15)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Credit Group"
        '
        'cmbCreditGroup
        '
        Me.cmbCreditGroup.FormattingEnabled = True
        Me.cmbCreditGroup.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbCreditGroup.Location = New System.Drawing.Point(121, 276)
        Me.cmbCreditGroup.Name = "cmbCreditGroup"
        Me.cmbCreditGroup.Size = New System.Drawing.Size(80, 23)
        Me.cmbCreditGroup.TabIndex = 10
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(121, 250)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(80, 23)
        Me.txtUnits.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 15)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Credited Units"
        '
        'txtSubject
        '
        Me.txtSubject.Enabled = False
        Me.txtSubject.Location = New System.Drawing.Point(121, 128)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(260, 23)
        Me.txtSubject.TabIndex = 60
        '
        'txtCourse
        '
        Me.txtCourse.Enabled = False
        Me.txtCourse.Location = New System.Drawing.Point(121, 204)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.Size = New System.Drawing.Size(260, 23)
        Me.txtCourse.TabIndex = 59
        '
        'btnSubject
        '
        Me.btnSubject.Location = New System.Drawing.Point(414, 140)
        Me.btnSubject.Name = "btnSubject"
        Me.btnSubject.Size = New System.Drawing.Size(59, 23)
        Me.btnSubject.TabIndex = 7
        Me.btnSubject.Text = "----->"
        Me.btnSubject.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(89, 203)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = ".."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(691, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 67
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtExtSubj
        '
        Me.txtExtSubj.Location = New System.Drawing.Point(123, 192)
        Me.txtExtSubj.Multiline = True
        Me.txtExtSubj.Name = "txtExtSubj"
        Me.txtExtSubj.Size = New System.Drawing.Size(285, 55)
        Me.txtExtSubj.TabIndex = 5
        '
        'txtExtSchool
        '
        Me.txtExtSchool.Location = New System.Drawing.Point(123, 98)
        Me.txtExtSchool.Name = "txtExtSchool"
        Me.txtExtSchool.ReadOnly = True
        Me.txtExtSchool.Size = New System.Drawing.Size(285, 23)
        Me.txtExtSchool.TabIndex = 3
        '
        'txtGrade
        '
        Me.txtGrade.Location = New System.Drawing.Point(123, 282)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.Size = New System.Drawing.Size(110, 23)
        Me.txtGrade.TabIndex = 7
        '
        'txtSemester
        '
        Me.txtSemester.DataSource = Me.SemesterBindingSource
        Me.txtSemester.DisplayMember = "SemesterName"
        Me.txtSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSemester.FormattingEnabled = True
        Me.txtSemester.Location = New System.Drawing.Point(124, 64)
        Me.txtSemester.Name = "txtSemester"
        Me.txtSemester.Size = New System.Drawing.Size(136, 23)
        Me.txtSemester.TabIndex = 2
        Me.txtSemester.ValueMember = "SemPK"
        '
        'SemesterBindingSource
        '
        Me.SemesterBindingSource.DataMember = "Semester"
        Me.SemesterBindingSource.DataSource = Me.DsSchool
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtSY
        '
        Me.txtSY.DataSource = Me.SchoolYearBindingSource
        Me.txtSY.DisplayMember = "SchoolYear"
        Me.txtSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSY.FormattingEnabled = True
        Me.txtSY.Location = New System.Drawing.Point(123, 36)
        Me.txtSY.Name = "txtSY"
        Me.txtSY.Size = New System.Drawing.Size(137, 23)
        Me.txtSY.TabIndex = 1
        Me.txtSY.ValueMember = "sypk"
        '
        'SchoolYearBindingSource
        '
        Me.SchoolYearBindingSource.DataMember = "SchoolYear"
        Me.SchoolYearBindingSource.DataSource = Me.DsSchool
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 15)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Ex Subject Name *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Ex School*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Grade*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "MMFC Subject"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Course"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Semester"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "School Year"
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.PowderBlue
        Me.GroupBox1.Controls.Add(Me.txtExUnits)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnExCollege)
        Me.GroupBox1.Controls.Add(Me.txtSY)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtExtSchool)
        Me.GroupBox1.Controls.Add(Me.txtSemester)
        Me.GroupBox1.Controls.Add(Me.chkFromPrevSchool)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtExtSubj)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtExtSubjCode)
        Me.GroupBox1.Controls.Add(Me.txtGrade)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 346)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Previous School Data"
        '
        'txtExUnits
        '
        Me.txtExUnits.Location = New System.Drawing.Point(123, 253)
        Me.txtExUnits.Name = "txtExUnits"
        Me.txtExUnits.Size = New System.Drawing.Size(110, 23)
        Me.txtExUnits.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 15)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Units*"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.PaleGreen
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.CheckBoxMapSubject)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCompletionGrade)
        Me.GroupBox2.Controls.Add(Me.txtSubject)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmbCreditGroup)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtUnits)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.txtCourse)
        Me.GroupBox2.Location = New System.Drawing.Point(466, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 345)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MMFC Mapping"
        '
        'CheckBoxMapSubject
        '
        Me.CheckBoxMapSubject.AutoSize = True
        Me.CheckBoxMapSubject.Location = New System.Drawing.Point(16, 85)
        Me.CheckBoxMapSubject.Name = "CheckBoxMapSubject"
        Me.CheckBoxMapSubject.Size = New System.Drawing.Size(100, 19)
        Me.CheckBoxMapSubject.TabIndex = 8
        Me.CheckBoxMapSubject.Text = "Map Subject?"
        Me.CheckBoxMapSubject.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LawnGreen
        Me.Label12.Location = New System.Drawing.Point(13, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(4)
        Me.Label12.Size = New System.Drawing.Size(305, 53)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "NOTE : If the subject is not credited and mapped into " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MMFC's own subjects, leav" & _
            "e this box blank and the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Map Subject unchecked"
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Location = New System.Drawing.Point(772, 376)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 71
        Me.ButtonClose.Text = "&Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(207, 279)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 15)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "choose 0 if no group assigned"
        '
        'frmGradeManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.ButtonClose
        Me.ClientSize = New System.Drawing.Size(867, 421)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.btnSubject)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGradeManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Map Previous School Grade into MMFC's Subjects"
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkFromPrevSchool As System.Windows.Forms.CheckBox
    Friend WithEvents txtCompletionGrade As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtExtSubjCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExCollege As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCreditGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtCourse As System.Windows.Forms.TextBox
    Friend WithEvents btnSubject As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtExtSubj As System.Windows.Forms.TextBox
    Friend WithEvents txtExtSchool As System.Windows.Forms.TextBox
    Friend WithEvents txtGrade As System.Windows.Forms.TextBox
    Friend WithEvents txtSemester As System.Windows.Forms.ComboBox
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxMapSubject As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents txtExUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
