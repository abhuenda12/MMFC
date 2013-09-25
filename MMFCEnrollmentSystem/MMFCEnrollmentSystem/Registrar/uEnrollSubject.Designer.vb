<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uEnrollSubject
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.EnrollpkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EnrollSubjectsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRegistrar = New MMFCEnrollmentSystem.dsRegistrar
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAddSubject = New System.Windows.Forms.ToolStripButton
        Me.btnRemoveSubject = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.btnEnrollClass = New System.Windows.Forms.ToolStripButton
        Me.btnDropClass = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.EnrollSubjectsTableAdapter = New MMFCEnrollmentSystem.dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnChooseCourse = New System.Windows.Forms.Button
        Me.txtCourse = New System.Windows.Forms.TextBox
        Me.txtStudentType = New System.Windows.Forms.TextBox
        Me.txtUnits = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtEnrollYear = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStudent = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSemester = New System.Windows.Forms.ComboBox
        Me.txtSchoolYear = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnrollSubjectsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EnrollpkDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column1})
        Me.DataGridView1.DataSource = Me.EnrollSubjectsBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1199, 337)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'EnrollpkDataGridViewTextBoxColumn
        '
        Me.EnrollpkDataGridViewTextBoxColumn.DataPropertyName = "enrollpk"
        Me.EnrollpkDataGridViewTextBoxColumn.HeaderText = "enrollpk"
        Me.EnrollpkDataGridViewTextBoxColumn.Name = "EnrollpkDataGridViewTextBoxColumn"
        Me.EnrollpkDataGridViewTextBoxColumn.ReadOnly = True
        Me.EnrollpkDataGridViewTextBoxColumn.Width = 5
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.HeaderText = "Subject"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "State"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Class"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 300
        '
        'Column5
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "n2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column5.HeaderText = "Units"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "n2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column6.HeaderText = "Lab Units"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Course"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'EnrollSubjectsBindingSource
        '
        Me.EnrollSubjectsBindingSource.DataMember = "EnrollSubjects"
        Me.EnrollSubjectsBindingSource.DataSource = Me.DsRegistrar
        '
        'DsRegistrar
        '
        Me.DsRegistrar.DataSetName = "dsRegistrar"
        Me.DsRegistrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddSubject, Me.btnRemoveSubject, Me.toolStripSeparator, Me.btnEnrollClass, Me.btnDropClass, Me.toolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1199, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddSubject
        '
        Me.btnAddSubject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSubject.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnAddSubject.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Add
        Me.btnAddSubject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddSubject.Name = "btnAddSubject"
        Me.btnAddSubject.Size = New System.Drawing.Size(95, 22)
        Me.btnAddSubject.Text = "&Add Subject"
        '
        'btnRemoveSubject
        '
        Me.btnRemoveSubject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSubject.ForeColor = System.Drawing.Color.Red
        Me.btnRemoveSubject.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Delete
        Me.btnRemoveSubject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemoveSubject.Name = "btnRemoveSubject"
        Me.btnRemoveSubject.Size = New System.Drawing.Size(120, 22)
        Me.btnRemoveSubject.Text = "&Remove Subject"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'btnEnrollClass
        '
        Me.btnEnrollClass.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnrollClass.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnEnrollClass.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Modify
        Me.btnEnrollClass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnrollClass.Name = "btnEnrollClass"
        Me.btnEnrollClass.Size = New System.Drawing.Size(105, 22)
        Me.btnEnrollClass.Text = "&Enroll to Class"
        '
        'btnDropClass
        '
        Me.btnDropClass.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDropClass.ForeColor = System.Drawing.Color.Red
        Me.btnDropClass.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Delete
        Me.btnDropClass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDropClass.Name = "btnDropClass"
        Me.btnDropClass.Size = New System.Drawing.Size(116, 22)
        Me.btnDropClass.Text = "&Drop from Class"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'EnrollSubjectsTableAdapter
        '
        Me.EnrollSubjectsTableAdapter.ClearBeforeFill = True
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Info
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(149, 22)
        Me.ToolStripButton1.Text = "Check Subject Fusions"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(371, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(353, 45)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Note: When enrolling a subject that is part of a Fused Offering, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "make sure it i" & _
            "s indeed part of that offering. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click on Check Subject Fusions for this."
        '
        'btnChooseCourse
        '
        Me.btnChooseCourse.Location = New System.Drawing.Point(420, 54)
        Me.btnChooseCourse.Name = "btnChooseCourse"
        Me.btnChooseCourse.Size = New System.Drawing.Size(22, 23)
        Me.btnChooseCourse.TabIndex = 60
        Me.btnChooseCourse.Text = ".."
        Me.btnChooseCourse.UseVisualStyleBackColor = True
        '
        'txtCourse
        '
        Me.txtCourse.Enabled = False
        Me.txtCourse.Location = New System.Drawing.Point(448, 53)
        Me.txtCourse.Multiline = True
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.ReadOnly = True
        Me.txtCourse.Size = New System.Drawing.Size(281, 50)
        Me.txtCourse.TabIndex = 75
        '
        'txtStudentType
        '
        Me.txtStudentType.Enabled = False
        Me.txtStudentType.Location = New System.Drawing.Point(173, 53)
        Me.txtStudentType.Name = "txtStudentType"
        Me.txtStudentType.ReadOnly = True
        Me.txtStudentType.Size = New System.Drawing.Size(188, 23)
        Me.txtStudentType.TabIndex = 74
        '
        'txtUnits
        '
        Me.txtUnits.BackColor = System.Drawing.Color.GreenYellow
        Me.txtUnits.Enabled = False
        Me.txtUnits.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnits.Location = New System.Drawing.Point(173, 178)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(82, 26)
        Me.txtUnits.TabIndex = 72
        Me.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(43, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 18)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Total Units Enrolled"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(369, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Course"
        '
        'txtEnrollYear
        '
        Me.txtEnrollYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtEnrollYear.FormattingEnabled = True
        Me.txtEnrollYear.Location = New System.Drawing.Point(173, 80)
        Me.txtEnrollYear.Name = "txtEnrollYear"
        Me.txtEnrollYear.Size = New System.Drawing.Size(188, 23)
        Me.txtEnrollYear.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Enroll as year"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(448, 109)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(281, 52)
        Me.txtRemarks.TabIndex = 61
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(371, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Remarks"
        '
        'txtDate
        '
        Me.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDate.Location = New System.Drawing.Point(448, 25)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(281, 23)
        Me.txtDate.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Date"
        '
        'txtStudent
        '
        Me.txtStudent.Enabled = False
        Me.txtStudent.Location = New System.Drawing.Point(173, 25)
        Me.txtStudent.Name = "txtStudent"
        Me.txtStudent.ReadOnly = True
        Me.txtStudent.Size = New System.Drawing.Size(188, 23)
        Me.txtStudent.TabIndex = 66
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(145, 23)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(22, 23)
        Me.Button5.TabIndex = 56
        Me.Button5.Text = ".."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Student"
        '
        'txtSemester
        '
        Me.txtSemester.DataSource = Me.SemesterBindingSource
        Me.txtSemester.DisplayMember = "SemesterName"
        Me.txtSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSemester.FormattingEnabled = True
        Me.txtSemester.Location = New System.Drawing.Point(173, 138)
        Me.txtSemester.Name = "txtSemester"
        Me.txtSemester.Size = New System.Drawing.Size(188, 23)
        Me.txtSemester.TabIndex = 58
        Me.txtSemester.ValueMember = "SemPK"
        '
        'txtSchoolYear
        '
        Me.txtSchoolYear.DataSource = Me.SchoolYearBindingSource
        Me.txtSchoolYear.DisplayMember = "SchoolYear"
        Me.txtSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSchoolYear.FormattingEnabled = True
        Me.txtSchoolYear.Location = New System.Drawing.Point(173, 109)
        Me.txtSchoolYear.Name = "txtSchoolYear"
        Me.txtSchoolYear.Size = New System.Drawing.Size(188, 23)
        Me.txtSchoolYear.TabIndex = 64
        Me.txtSchoolYear.ValueMember = "sypk"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Semester"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "School Year"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCourse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnChooseCourse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSchoolYear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtStudentType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSemester)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtUnits)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtStudent)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEnrollYear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtRemarks)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1199, 644)
        Me.SplitContainer1.SplitterDistance = 278
        Me.SplitContainer1.TabIndex = 77
        '
        'uEnrollSubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "uEnrollSubject"
        Me.Size = New System.Drawing.Size(1199, 644)
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnrollSubjectsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddSubject As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveSubject As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEnrollClass As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDropClass As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents EnrollSubjectsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRegistrar As MMFCEnrollmentSystem.dsRegistrar
    Friend WithEvents EnrollSubjectsTableAdapter As MMFCEnrollmentSystem.dsRegistrarTableAdapters.EnrollSubjectsTableAdapter
    Friend WithEvents EnrollpkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnChooseCourse As System.Windows.Forms.Button
    Friend WithEvents txtCourse As System.Windows.Forms.TextBox
    Friend WithEvents txtStudentType As System.Windows.Forms.TextBox
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEnrollYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStudent As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSemester As System.Windows.Forms.ComboBox
    Friend WithEvents txtSchoolYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
