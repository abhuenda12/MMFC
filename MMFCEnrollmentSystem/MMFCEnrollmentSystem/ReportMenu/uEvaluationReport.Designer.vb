<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uEvaluationReport
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grpCurriculum = New System.Windows.Forms.GroupBox
        Me.txtCourse = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpSemChooser = New System.Windows.Forms.GroupBox
        Me.txtSem = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkCurriculum = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtStudent = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.CheckBoxAllSemesters = New System.Windows.Forms.CheckBox
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpCurriculum.SuspendLayout()
        Me.grpSemChooser.SuspendLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(778, 413)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Evaluation Report"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 194)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(774, 217)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grpCurriculum)
        Me.GroupBox1.Controls.Add(Me.grpSemChooser)
        Me.GroupBox1.Controls.Add(Me.chkCurriculum)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtStudent)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(774, 172)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'grpCurriculum
        '
        Me.grpCurriculum.Controls.Add(Me.txtCourse)
        Me.grpCurriculum.Controls.Add(Me.Button3)
        Me.grpCurriculum.Controls.Add(Me.Label2)
        Me.grpCurriculum.Location = New System.Drawing.Point(281, 62)
        Me.grpCurriculum.Name = "grpCurriculum"
        Me.grpCurriculum.Size = New System.Drawing.Size(453, 47)
        Me.grpCurriculum.TabIndex = 15
        Me.grpCurriculum.TabStop = False
        '
        'txtCourse
        '
        Me.txtCourse.Location = New System.Drawing.Point(112, 20)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.ReadOnly = True
        Me.txtCourse.Size = New System.Drawing.Size(335, 21)
        Me.txtCourse.TabIndex = 12
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(73, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = ".."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Course"
        '
        'grpSemChooser
        '
        Me.grpSemChooser.Controls.Add(Me.CheckBoxAllSemesters)
        Me.grpSemChooser.Controls.Add(Me.txtSem)
        Me.grpSemChooser.Controls.Add(Me.Label3)
        Me.grpSemChooser.Controls.Add(Me.txtSY)
        Me.grpSemChooser.Controls.Add(Me.Label4)
        Me.grpSemChooser.Location = New System.Drawing.Point(23, 20)
        Me.grpSemChooser.Name = "grpSemChooser"
        Me.grpSemChooser.Size = New System.Drawing.Size(711, 42)
        Me.grpSemChooser.TabIndex = 14
        Me.grpSemChooser.TabStop = False
        Me.grpSemChooser.Visible = False
        '
        'txtSem
        '
        Me.txtSem.DataSource = Me.SemesterBindingSource
        Me.txtSem.DisplayMember = "SemesterName"
        Me.txtSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSem.FormattingEnabled = True
        Me.txtSem.Location = New System.Drawing.Point(222, 15)
        Me.txtSem.Name = "txtSem"
        Me.txtSem.Size = New System.Drawing.Size(121, 21)
        Me.txtSem.TabIndex = 4
        Me.txtSem.ValueMember = "SemPK"
        '
        'SemesterBindingSource
        '
        Me.SemesterBindingSource.DataMember = "Semester"
        Me.SemesterBindingSource.DataSource = Me.DsSchoolBindingSource
        '
        'DsSchoolBindingSource
        '
        Me.DsSchoolBindingSource.DataSource = Me.DsSchool
        Me.DsSchoolBindingSource.Position = 0
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Sy"
        '
        'txtSY
        '
        Me.txtSY.DataSource = Me.SchoolYearBindingSource
        Me.txtSY.DisplayMember = "SchoolYear"
        Me.txtSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSY.FormattingEnabled = True
        Me.txtSY.Location = New System.Drawing.Point(34, 15)
        Me.txtSY.Name = "txtSY"
        Me.txtSY.Size = New System.Drawing.Size(121, 21)
        Me.txtSY.TabIndex = 2
        Me.txtSY.ValueMember = "sypk"
        '
        'SchoolYearBindingSource
        '
        Me.SchoolYearBindingSource.DataMember = "SchoolYear"
        Me.SchoolYearBindingSource.DataSource = Me.DsSchool
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Semester"
        '
        'chkCurriculum
        '
        Me.chkCurriculum.AutoSize = True
        Me.chkCurriculum.Location = New System.Drawing.Point(67, 111)
        Me.chkCurriculum.Name = "chkCurriculum"
        Me.chkCurriculum.Size = New System.Drawing.Size(96, 17)
        Me.chkCurriculum.TabIndex = 13
        Me.chkCurriculum.Text = "By Curriculum?"
        Me.chkCurriculum.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(67, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = ".."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtStudent
        '
        Me.txtStudent.Location = New System.Drawing.Point(106, 76)
        Me.txtStudent.Name = "txtStudent"
        Me.txtStudent.ReadOnly = True
        Me.txtStudent.Size = New System.Drawing.Size(165, 21)
        Me.txtStudent.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(196, 107)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sudent"
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'CheckBoxAllSemesters
        '
        Me.CheckBoxAllSemesters.AutoSize = True
        Me.CheckBoxAllSemesters.Location = New System.Drawing.Point(349, 17)
        Me.CheckBoxAllSemesters.Name = "CheckBoxAllSemesters"
        Me.CheckBoxAllSemesters.Size = New System.Drawing.Size(95, 17)
        Me.CheckBoxAllSemesters.TabIndex = 14
        Me.CheckBoxAllSemesters.Text = "All Semesters?"
        Me.CheckBoxAllSemesters.UseVisualStyleBackColor = True
        '
        'uEvaluationReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uEvaluationReport"
        Me.Size = New System.Drawing.Size(778, 413)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpCurriculum.ResumeLayout(False)
        Me.grpCurriculum.PerformLayout()
        Me.grpSemChooser.ResumeLayout(False)
        Me.grpSemChooser.PerformLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCurriculum As System.Windows.Forms.CheckBox
    Friend WithEvents txtCourse As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStudent As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSemChooser As System.Windows.Forms.GroupBox
    Friend WithEvents txtSem As System.Windows.Forms.ComboBox
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchoolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents grpCurriculum As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxAllSemesters As System.Windows.Forms.CheckBox

End Class
