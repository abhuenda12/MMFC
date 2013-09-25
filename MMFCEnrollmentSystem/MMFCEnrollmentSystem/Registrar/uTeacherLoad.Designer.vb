<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uTeacherLoad
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.TextBoxTeacherName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTeacherFilter = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SYOfferingbyTeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TeachersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.TeachersTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.TeachersTableAdapter
        Me.cmbSY = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SYOfferingbyTeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeachersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(804, 607)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Teacher Load"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 122)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(800, 483)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbSY)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.TextBoxTeacherName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTeacherFilter)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(68, 31)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 27)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = ".."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBoxTeacherName
        '
        Me.TextBoxTeacherName.Enabled = False
        Me.TextBoxTeacherName.Location = New System.Drawing.Point(103, 35)
        Me.TextBoxTeacherName.Name = "TextBoxTeacherName"
        Me.TextBoxTeacherName.ReadOnly = True
        Me.TextBoxTeacherName.Size = New System.Drawing.Size(319, 23)
        Me.TextBoxTeacherName.TabIndex = 16
        Me.TextBoxTeacherName.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Semester"
        '
        'txtTeacherFilter
        '
        Me.txtTeacherFilter.Location = New System.Drawing.Point(661, 60)
        Me.txtTeacherFilter.Name = "txtTeacherFilter"
        Me.txtTeacherFilter.Size = New System.Drawing.Size(114, 23)
        Me.txtTeacherFilter.TabIndex = 13
        Me.txtTeacherFilter.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.SemesterBindingSource
        Me.ComboBox2.DisplayMember = "SemesterName"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(301, 67)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 23)
        Me.ComboBox2.TabIndex = 12
        Me.ComboBox2.ValueMember = "SemPK"
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(455, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Teacher"
        '
        'SYOfferingbyTeacherBindingSource
        '
        Me.SYOfferingbyTeacherBindingSource.DataMember = "SYOfferingbyTeacher"
        Me.SYOfferingbyTeacherBindingSource.DataSource = Me.DsSchool
        '
        'TeachersBindingSource
        '
        Me.TeachersBindingSource.DataMember = "Teachers"
        Me.TeachersBindingSource.DataSource = Me.DsSchool
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'TeachersTableAdapter
        '
        Me.TeachersTableAdapter.ClearBeforeFill = True
        '
        'cmbSY
        '
        Me.cmbSY.DataSource = Me.SchoolYearBindingSource
        Me.cmbSY.DisplayMember = "SchoolYear"
        Me.cmbSY.FormattingEnabled = True
        Me.cmbSY.Location = New System.Drawing.Point(103, 67)
        Me.cmbSY.Name = "cmbSY"
        Me.cmbSY.Size = New System.Drawing.Size(121, 23)
        Me.cmbSY.TabIndex = 18
        Me.cmbSY.ValueMember = "sypk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Sy"
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
        'uTeacherLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.Controls.Add(Me.GroupControl1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "uTeacherLoad"
        Me.Size = New System.Drawing.Size(804, 607)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SYOfferingbyTeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeachersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTeacherFilter As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SYOfferingbyTeacherBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeachersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents TeachersTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.TeachersTableAdapter
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBoxTeacherName As System.Windows.Forms.TextBox
    Friend WithEvents cmbSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter

End Class
