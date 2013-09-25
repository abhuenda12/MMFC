<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCurrentSchoolyear
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkEnrollmentClosed = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DateTimePickerExam5To = New System.Windows.Forms.DateTimePicker
        Me.dateSemiFinalTo = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerExam3To = New System.Windows.Forms.DateTimePicker
        Me.dateSemiMidtermTo = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerExam1To = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePickerExam5From = New System.Windows.Forms.DateTimePicker
        Me.dateSemiFinalFrom = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerExam3From = New System.Windows.Forms.DateTimePicker
        Me.dateSemiMidtermfrom = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerExam1From = New System.Windows.Forms.DateTimePicker
        Me.cmbSemester = New System.Windows.Forms.ComboBox
        Me.cmbSY = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(818, 566)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Active School Year && Semester"
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
        'SchoolYearBindingSource
        '
        Me.SchoolYearBindingSource.DataMember = "SchoolYear"
        Me.SchoolYearBindingSource.DataSource = Me.DsSchool
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 333)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(62, 300)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 13)
        Me.Label13.TabIndex = 108
        Me.Label13.Text = "Enrollment Closed?"
        '
        'chkEnrollmentClosed
        '
        Me.chkEnrollmentClosed.AutoSize = True
        Me.chkEnrollmentClosed.Location = New System.Drawing.Point(183, 300)
        Me.chkEnrollmentClosed.Name = "chkEnrollmentClosed"
        Me.chkEnrollmentClosed.Size = New System.Drawing.Size(15, 14)
        Me.chkEnrollmentClosed.TabIndex = 107
        Me.chkEnrollmentClosed.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(374, 264)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "TO"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(374, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "TO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(374, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 13)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "TO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(374, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "TO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(374, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "TO"
        '
        'DateTimePickerExam5To
        '
        Me.DateTimePickerExam5To.Location = New System.Drawing.Point(401, 256)
        Me.DateTimePickerExam5To.Name = "DateTimePickerExam5To"
        Me.DateTimePickerExam5To.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam5To.TabIndex = 101
        '
        'dateSemiFinalTo
        '
        Me.dateSemiFinalTo.Location = New System.Drawing.Point(401, 230)
        Me.dateSemiFinalTo.Name = "dateSemiFinalTo"
        Me.dateSemiFinalTo.Size = New System.Drawing.Size(200, 20)
        Me.dateSemiFinalTo.TabIndex = 100
        '
        'DateTimePickerExam3To
        '
        Me.DateTimePickerExam3To.Location = New System.Drawing.Point(401, 204)
        Me.DateTimePickerExam3To.Name = "DateTimePickerExam3To"
        Me.DateTimePickerExam3To.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam3To.TabIndex = 99
        '
        'dateSemiMidtermTo
        '
        Me.dateSemiMidtermTo.Location = New System.Drawing.Point(401, 178)
        Me.dateSemiMidtermTo.Name = "dateSemiMidtermTo"
        Me.dateSemiMidtermTo.Size = New System.Drawing.Size(200, 20)
        Me.dateSemiMidtermTo.TabIndex = 98
        '
        'DateTimePickerExam1To
        '
        Me.DateTimePickerExam1To.Location = New System.Drawing.Point(401, 152)
        Me.DateTimePickerExam1To.Name = "DateTimePickerExam1To"
        Me.DateTimePickerExam1To.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam1To.TabIndex = 97
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(62, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "FINAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(62, 238)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "SEMI-FINAL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(62, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "MIDTERM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(62, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "SEMI-MIDTERM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(62, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "PRELIM"
        '
        'DateTimePickerExam5From
        '
        Me.DateTimePickerExam5From.Location = New System.Drawing.Point(164, 256)
        Me.DateTimePickerExam5From.Name = "DateTimePickerExam5From"
        Me.DateTimePickerExam5From.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam5From.TabIndex = 91
        '
        'dateSemiFinalFrom
        '
        Me.dateSemiFinalFrom.Location = New System.Drawing.Point(164, 230)
        Me.dateSemiFinalFrom.Name = "dateSemiFinalFrom"
        Me.dateSemiFinalFrom.Size = New System.Drawing.Size(200, 20)
        Me.dateSemiFinalFrom.TabIndex = 90
        '
        'DateTimePickerExam3From
        '
        Me.DateTimePickerExam3From.Location = New System.Drawing.Point(164, 204)
        Me.DateTimePickerExam3From.Name = "DateTimePickerExam3From"
        Me.DateTimePickerExam3From.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam3From.TabIndex = 89
        '
        'dateSemiMidtermfrom
        '
        Me.dateSemiMidtermfrom.Location = New System.Drawing.Point(164, 178)
        Me.dateSemiMidtermfrom.Name = "dateSemiMidtermfrom"
        Me.dateSemiMidtermfrom.Size = New System.Drawing.Size(200, 20)
        Me.dateSemiMidtermfrom.TabIndex = 88
        '
        'DateTimePickerExam1From
        '
        Me.DateTimePickerExam1From.Location = New System.Drawing.Point(164, 152)
        Me.DateTimePickerExam1From.Name = "DateTimePickerExam1From"
        Me.DateTimePickerExam1From.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerExam1From.TabIndex = 87
        '
        'cmbSemester
        '
        Me.cmbSemester.DataSource = Me.SemesterBindingSource
        Me.cmbSemester.DisplayMember = "SemesterName"
        Me.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSemester.FormattingEnabled = True
        Me.cmbSemester.Location = New System.Drawing.Point(164, 103)
        Me.cmbSemester.Name = "cmbSemester"
        Me.cmbSemester.Size = New System.Drawing.Size(121, 21)
        Me.cmbSemester.TabIndex = 86
        Me.cmbSemester.ValueMember = "SemPK"
        '
        'cmbSY
        '
        Me.cmbSY.DataSource = Me.SchoolYearBindingSource
        Me.cmbSY.DisplayMember = "SchoolYear"
        Me.cmbSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSY.FormattingEnabled = True
        Me.cmbSY.Location = New System.Drawing.Point(164, 72)
        Me.cmbSY.Name = "cmbSY"
        Me.cmbSY.Size = New System.Drawing.Size(121, 21)
        Me.cmbSY.TabIndex = 85
        Me.cmbSY.ValueMember = "sypk"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(62, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Current Semester"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(62, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Current School Year"
        '
        'uCurrentSchoolyear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkEnrollmentClosed)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DateTimePickerExam5To)
        Me.Controls.Add(Me.dateSemiFinalTo)
        Me.Controls.Add(Me.DateTimePickerExam3To)
        Me.Controls.Add(Me.dateSemiMidtermTo)
        Me.Controls.Add(Me.DateTimePickerExam1To)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePickerExam5From)
        Me.Controls.Add(Me.dateSemiFinalFrom)
        Me.Controls.Add(Me.DateTimePickerExam3From)
        Me.Controls.Add(Me.dateSemiMidtermfrom)
        Me.Controls.Add(Me.DateTimePickerExam1From)
        Me.Controls.Add(Me.cmbSemester)
        Me.Controls.Add(Me.cmbSY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uCurrentSchoolyear"
        Me.Size = New System.Drawing.Size(818, 566)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkEnrollmentClosed As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerExam5To As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateSemiFinalTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerExam3To As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateSemiMidtermTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerExam1To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerExam5From As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateSemiFinalFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerExam3From As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateSemiMidtermfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerExam1From As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSemester As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
