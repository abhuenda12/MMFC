<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCollectionsBreakdown
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.grpSorter = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OrRef = New System.Windows.Forms.RadioButton
        Me.rdoStudentName = New System.Windows.Forms.RadioButton
        Me.chkIncludeCancelledOR = New System.Windows.Forms.CheckBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkAllSemesters = New System.Windows.Forms.CheckBox
        Me.cmbFilter = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkPortrait = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtSEM = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.grpSorter)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(782, 415)
        Me.GroupControl1.TabIndex = 3
        Me.GroupControl1.Text = "Collections Breakdown"
        '
        'grpSorter
        '
        Me.grpSorter.ActiveViewIndex = -1
        Me.grpSorter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpSorter.DisplayGroupTree = False
        Me.grpSorter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSorter.Location = New System.Drawing.Point(2, 146)
        Me.grpSorter.Name = "grpSorter"
        Me.grpSorter.SelectionFormula = ""
        Me.grpSorter.Size = New System.Drawing.Size(778, 267)
        Me.grpSorter.TabIndex = 2
        Me.grpSorter.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkIncludeCancelledOR)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkAllSemesters)
        Me.GroupBox1.Controls.Add(Me.cmbFilter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkPortrait)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtSEM)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSY)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(778, 124)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OrRef)
        Me.GroupBox2.Controls.Add(Me.rdoStudentName)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 45)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sort by:"
        '
        'OrRef
        '
        Me.OrRef.AutoSize = True
        Me.OrRef.Location = New System.Drawing.Point(178, 20)
        Me.OrRef.Name = "OrRef"
        Me.OrRef.Size = New System.Drawing.Size(80, 17)
        Me.OrRef.TabIndex = 1
        Me.OrRef.TabStop = True
        Me.OrRef.Text = "OR Number"
        Me.OrRef.UseVisualStyleBackColor = True
        '
        'rdoStudentName
        '
        Me.rdoStudentName.AutoSize = True
        Me.rdoStudentName.Location = New System.Drawing.Point(6, 20)
        Me.rdoStudentName.Name = "rdoStudentName"
        Me.rdoStudentName.Size = New System.Drawing.Size(93, 17)
        Me.rdoStudentName.TabIndex = 0
        Me.rdoStudentName.TabStop = True
        Me.rdoStudentName.Text = "Student Name"
        Me.rdoStudentName.UseVisualStyleBackColor = True
        '
        'chkIncludeCancelledOR
        '
        Me.chkIncludeCancelledOR.AutoSize = True
        Me.chkIncludeCancelledOR.Location = New System.Drawing.Point(392, 73)
        Me.chkIncludeCancelledOR.Name = "chkIncludeCancelledOR"
        Me.chkIncludeCancelledOR.Size = New System.Drawing.Size(174, 17)
        Me.chkIncludeCancelledOR.TabIndex = 15
        Me.chkIncludeCancelledOR.Text = "Include Cancelled ORs Report?"
        Me.chkIncludeCancelledOR.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(253, 45)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(121, 21)
        Me.DateTimePicker2.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "---      To"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(59, 45)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 21)
        Me.DateTimePicker1.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "From"
        '
        'chkAllSemesters
        '
        Me.chkAllSemesters.AutoSize = True
        Me.chkAllSemesters.Location = New System.Drawing.Point(516, 50)
        Me.chkAllSemesters.Name = "chkAllSemesters"
        Me.chkAllSemesters.Size = New System.Drawing.Size(178, 17)
        Me.chkAllSemesters.TabIndex = 10
        Me.chkAllSemesters.Text = "Cover All Years and Semesters?"
        Me.chkAllSemesters.UseVisualStyleBackColor = True
        '
        'cmbFilter
        '
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(484, 18)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(210, 21)
        Me.cmbFilter.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(389, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Break Down Item"
        '
        'chkPortrait
        '
        Me.chkPortrait.AutoSize = True
        Me.chkPortrait.Location = New System.Drawing.Point(392, 50)
        Me.chkPortrait.Name = "chkPortrait"
        Me.chkPortrait.Size = New System.Drawing.Size(104, 17)
        Me.chkPortrait.TabIndex = 7
        Me.chkPortrait.Text = "Portrait Format?"
        Me.chkPortrait.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(299, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSEM
        '
        Me.txtSEM.DataSource = Me.SemesterBindingSource
        Me.txtSEM.DisplayMember = "SemesterName"
        Me.txtSEM.FormattingEnabled = True
        Me.txtSEM.Location = New System.Drawing.Point(253, 18)
        Me.txtSEM.Name = "txtSEM"
        Me.txtSEM.Size = New System.Drawing.Size(121, 21)
        Me.txtSEM.TabIndex = 3
        Me.txtSEM.ValueMember = "SemPK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Semester"
        '
        'txtSY
        '
        Me.txtSY.DataSource = Me.SchoolYearBindingSource
        Me.txtSY.DisplayMember = "SchoolYear"
        Me.txtSY.FormattingEnabled = True
        Me.txtSY.Location = New System.Drawing.Point(59, 18)
        Me.txtSY.Name = "txtSY"
        Me.txtSY.Size = New System.Drawing.Size(121, 21)
        Me.txtSY.TabIndex = 1
        Me.txtSY.ValueMember = "sypk"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sy"
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
        'SemesterBindingSource
        '
        Me.SemesterBindingSource.DataMember = "Semester"
        Me.SemesterBindingSource.DataSource = Me.DsSchool
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'uCollectionsBreakdown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uCollectionsBreakdown"
        Me.Size = New System.Drawing.Size(782, 415)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grpSorter As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPortrait As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSEM As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeCancelledOR As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkAllSemesters As System.Windows.Forms.CheckBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OrRef As System.Windows.Forms.RadioButton
    Friend WithEvents rdoStudentName As System.Windows.Forms.RadioButton
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter

End Class
