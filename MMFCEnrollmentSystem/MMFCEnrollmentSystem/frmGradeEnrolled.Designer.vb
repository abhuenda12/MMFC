<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGradeEnrolled
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
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSemester = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.txtCompletionGrade = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbCreditGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUnits = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtCourse = New System.Windows.Forms.TextBox
        Me.btnSelectSubject = New System.Windows.Forms.Button
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSY
        '
        Me.txtSY.DataSource = Me.SchoolYearBindingSource
        Me.txtSY.DisplayMember = "SchoolYear"
        Me.txtSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSY.FormattingEnabled = True
        Me.txtSY.Location = New System.Drawing.Point(168, 28)
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
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "School Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Semester"
        '
        'txtSemester
        '
        Me.txtSemester.DataSource = Me.SemesterBindingSource
        Me.txtSemester.DisplayMember = "SemesterName"
        Me.txtSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSemester.FormattingEnabled = True
        Me.txtSemester.Location = New System.Drawing.Point(169, 56)
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
        'DsSchoolBindingSource
        '
        Me.DsSchoolBindingSource.DataSource = Me.DsSchool
        Me.DsSchoolBindingSource.Position = 0
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'txtCompletionGrade
        '
        Me.txtCompletionGrade.Location = New System.Drawing.Point(169, 196)
        Me.txtCompletionGrade.Name = "txtCompletionGrade"
        Me.txtCompletionGrade.Size = New System.Drawing.Size(137, 23)
        Me.txtCompletionGrade.TabIndex = 7
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(168, 85)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReadOnly = True
        Me.txtSubject.Size = New System.Drawing.Size(329, 23)
        Me.txtSubject.TabIndex = 76
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 15)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "MMFC Subject"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 15)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Credit Group"
        '
        'cmbCreditGroup
        '
        Me.cmbCreditGroup.FormattingEnabled = True
        Me.cmbCreditGroup.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbCreditGroup.Location = New System.Drawing.Point(169, 169)
        Me.cmbCreditGroup.Name = "cmbCreditGroup"
        Me.cmbCreditGroup.Size = New System.Drawing.Size(137, 23)
        Me.cmbCreditGroup.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Course"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(169, 143)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(137, 23)
        Me.txtUnits.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 15)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Credited Units"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(137, 113)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = ".."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtCourse
        '
        Me.txtCourse.Location = New System.Drawing.Point(169, 114)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.ReadOnly = True
        Me.txtCourse.Size = New System.Drawing.Size(328, 23)
        Me.txtCourse.TabIndex = 75
        '
        'btnSelectSubject
        '
        Me.btnSelectSubject.Location = New System.Drawing.Point(137, 85)
        Me.btnSelectSubject.Name = "btnSelectSubject"
        Me.btnSelectSubject.Size = New System.Drawing.Size(26, 23)
        Me.btnSelectSubject.TabIndex = 3
        Me.btnSelectSubject.Text = ".."
        Me.btnSelectSubject.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Location = New System.Drawing.Point(422, 274)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 22
        Me.ButtonClose.Text = "&Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(341, 274)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmGradeEnrolled
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.ButtonClose
        Me.ClientSize = New System.Drawing.Size(518, 309)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSelectSubject)
        Me.Controls.Add(Me.txtCompletionGrade)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbCreditGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtCourse)
        Me.Controls.Add(Me.txtSY)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSemester)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGradeEnrolled"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encode Student's Grade"
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSemester As System.Windows.Forms.ComboBox
    Friend WithEvents DsSchoolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents txtCompletionGrade As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCreditGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtCourse As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectSubject As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
