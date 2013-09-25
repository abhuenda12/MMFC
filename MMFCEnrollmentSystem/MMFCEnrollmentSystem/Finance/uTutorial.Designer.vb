<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uTutorial
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uTutorial))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbSY = New System.Windows.Forms.ComboBox
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbSem = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinStudentsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxStudentsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClosedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SYOfferingSelect2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRegistrar = New MMFCEnrollmentSystem.dsRegistrar
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SYOfferingSelect2TableAdapter = New MMFCEnrollmentSystem.dsRegistrarTableAdapters.SYOfferingSelect2TableAdapter
        Me.GroupBox1.SuspendLayout()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SYOfferingSelect2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmbSY)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbSem)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(48, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(181, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Show Requested Tutorials Only?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(15, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(656, 39)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(416, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Apply Charges to Class"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(291, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Retrieve Offerings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbSY
        '
        Me.cmbSY.DataSource = Me.SchoolYearBindingSource
        Me.cmbSY.DisplayMember = "SchoolYear"
        Me.cmbSY.FormattingEnabled = True
        Me.cmbSY.Location = New System.Drawing.Point(177, 14)
        Me.cmbSY.Name = "cmbSY"
        Me.cmbSY.Size = New System.Drawing.Size(98, 21)
        Me.cmbSY.TabIndex = 3
        Me.cmbSY.ValueMember = "sypk"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Year"
        '
        'cmbSem
        '
        Me.cmbSem.DataSource = Me.SemesterBindingSource
        Me.cmbSem.DisplayMember = "SemesterName"
        Me.cmbSem.FormattingEnabled = True
        Me.cmbSem.Location = New System.Drawing.Point(48, 14)
        Me.cmbSem.Name = "cmbSem"
        Me.cmbSem.Size = New System.Drawing.Size(88, 21)
        Me.cmbSem.TabIndex = 1
        Me.cmbSem.ValueMember = "SemPK"
        '
        'SemesterBindingSource
        '
        Me.SemesterBindingSource.DataMember = "Semester"
        Me.SemesterBindingSource.DataSource = Me.DsSchool
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sem"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(2, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(784, 292)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.MinStudentsDataGridViewTextBoxColumn, Me.MaxStudentsDataGridViewTextBoxColumn, Me.Column4, Me.ClosedDataGridViewCheckBoxColumn, Me.Column5, Me.Column6})
        Me.DataGridView1.DataSource = Me.SYOfferingSelect2BindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 17)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(778, 272)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Class"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 180
        '
        'Column2
        '
        Me.Column2.HeaderText = "Time"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Days"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'MinStudentsDataGridViewTextBoxColumn
        '
        Me.MinStudentsDataGridViewTextBoxColumn.DataPropertyName = "MinStudents"
        Me.MinStudentsDataGridViewTextBoxColumn.HeaderText = "Min"
        Me.MinStudentsDataGridViewTextBoxColumn.Name = "MinStudentsDataGridViewTextBoxColumn"
        Me.MinStudentsDataGridViewTextBoxColumn.ReadOnly = True
        Me.MinStudentsDataGridViewTextBoxColumn.Width = 50
        '
        'MaxStudentsDataGridViewTextBoxColumn
        '
        Me.MaxStudentsDataGridViewTextBoxColumn.DataPropertyName = "MaxStudents"
        Me.MaxStudentsDataGridViewTextBoxColumn.HeaderText = "Max"
        Me.MaxStudentsDataGridViewTextBoxColumn.Name = "MaxStudentsDataGridViewTextBoxColumn"
        Me.MaxStudentsDataGridViewTextBoxColumn.ReadOnly = True
        Me.MaxStudentsDataGridViewTextBoxColumn.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Enrolled"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 50
        '
        'ClosedDataGridViewCheckBoxColumn
        '
        Me.ClosedDataGridViewCheckBoxColumn.DataPropertyName = "closed"
        Me.ClosedDataGridViewCheckBoxColumn.HeaderText = "Closed?"
        Me.ClosedDataGridViewCheckBoxColumn.Name = "ClosedDataGridViewCheckBoxColumn"
        Me.ClosedDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ClosedDataGridViewCheckBoxColumn.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "Type"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'SYOfferingSelect2BindingSource
        '
        Me.SYOfferingSelect2BindingSource.DataMember = "SYOfferingSelect2"
        Me.SYOfferingSelect2BindingSource.DataSource = Me.DsRegistrar
        '
        'DsRegistrar
        '
        Me.DsRegistrar.DataSetName = "dsRegistrar"
        Me.DsRegistrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GroupBox2)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(788, 436)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Requested Tutorial Subjects Final Assessment"
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SYOfferingSelect2TableAdapter
        '
        Me.SYOfferingSelect2TableAdapter.ClearBeforeFill = True
        '
        'uTutorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uTutorial"
        Me.Size = New System.Drawing.Size(788, 436)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SYOfferingSelect2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSem As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SYOfferingSelect2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRegistrar As MMFCEnrollmentSystem.dsRegistrar
    Friend WithEvents SYOfferingSelect2TableAdapter As MMFCEnrollmentSystem.dsRegistrarTableAdapters.SYOfferingSelect2TableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinStudentsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxStudentsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClosedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl

End Class
