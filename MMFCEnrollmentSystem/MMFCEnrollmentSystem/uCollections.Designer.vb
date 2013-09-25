<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCollections
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
        Me.chkHistory = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtSEM = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.DsSchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        Me.grpReportType = New System.Windows.Forms.GroupBox
        Me.rdoType3 = New System.Windows.Forms.RadioButton
        Me.rdoType2 = New System.Windows.Forms.RadioButton
        Me.rdoType1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdo5th = New System.Windows.Forms.RadioButton
        Me.rdo4th = New System.Windows.Forms.RadioButton
        Me.rdo3rd = New System.Windows.Forms.RadioButton
        Me.rdo2nd = New System.Windows.Forms.RadioButton
        Me.rdo1st = New System.Windows.Forms.RadioButton
        Me.rdoAll = New System.Windows.Forms.RadioButton
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpReportType.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(786, 411)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Collections Reports"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 175)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(782, 234)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grpReportType)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkHistory)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtSEM)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSY)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(782, 153)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkHistory
        '
        Me.chkHistory.AutoSize = True
        Me.chkHistory.Location = New System.Drawing.Point(470, 20)
        Me.chkHistory.Name = "chkHistory"
        Me.chkHistory.Size = New System.Drawing.Size(110, 17)
        Me.chkHistory.TabIndex = 7
        Me.chkHistory.Text = "Payment History?"
        Me.chkHistory.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(389, 16)
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
        Me.txtSEM.Location = New System.Drawing.Point(244, 18)
        Me.txtSEM.Name = "txtSEM"
        Me.txtSEM.Size = New System.Drawing.Size(121, 21)
        Me.txtSEM.TabIndex = 3
        Me.txtSEM.ValueMember = "SemPK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 21)
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
        Me.txtSY.Location = New System.Drawing.Point(42, 18)
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
        'DsSchoolBindingSource
        '
        Me.DsSchoolBindingSource.DataSource = Me.DsSchool
        Me.DsSchoolBindingSource.Position = 0
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
        'grpReportType
        '
        Me.grpReportType.BackColor = System.Drawing.Color.Transparent
        Me.grpReportType.Controls.Add(Me.rdoType3)
        Me.grpReportType.Controls.Add(Me.rdoType2)
        Me.grpReportType.Controls.Add(Me.rdoType1)
        Me.grpReportType.Location = New System.Drawing.Point(267, 45)
        Me.grpReportType.Name = "grpReportType"
        Me.grpReportType.Size = New System.Drawing.Size(222, 81)
        Me.grpReportType.TabIndex = 11
        Me.grpReportType.TabStop = False
        Me.grpReportType.Text = "Report Type"
        Me.grpReportType.Visible = False
        '
        'rdoType3
        '
        Me.rdoType3.AutoSize = True
        Me.rdoType3.Location = New System.Drawing.Point(5, 58)
        Me.rdoType3.Name = "rdoType3"
        Me.rdoType3.Size = New System.Drawing.Size(167, 17)
        Me.rdoType3.TabIndex = 2
        Me.rdoType3.TabStop = True
        Me.rdoType3.Text = "Summary Report of Collection"
        Me.rdoType3.UseVisualStyleBackColor = True
        '
        'rdoType2
        '
        Me.rdoType2.AutoSize = True
        Me.rdoType2.Location = New System.Drawing.Point(5, 37)
        Me.rdoType2.Name = "rdoType2"
        Me.rdoType2.Size = New System.Drawing.Size(182, 17)
        Me.rdoType2.TabIndex = 1
        Me.rdoType2.TabStop = True
        Me.rdoType2.Text = "Expected Collectibles per Course"
        Me.rdoType2.UseVisualStyleBackColor = True
        '
        'rdoType1
        '
        Me.rdoType1.AutoSize = True
        Me.rdoType1.Location = New System.Drawing.Point(5, 14)
        Me.rdoType1.Name = "rdoType1"
        Me.rdoType1.Size = New System.Drawing.Size(208, 17)
        Me.rdoType1.TabIndex = 0
        Me.rdoType1.TabStop = True
        Me.rdoType1.Text = "Summary of Collected and Uncollected"
        Me.rdoType1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rdo5th)
        Me.GroupBox2.Controls.Add(Me.rdo4th)
        Me.GroupBox2.Controls.Add(Me.rdo3rd)
        Me.GroupBox2.Controls.Add(Me.rdo2nd)
        Me.GroupBox2.Controls.Add(Me.rdo1st)
        Me.GroupBox2.Controls.Add(Me.rdoAll)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 38)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Exam Period"
        Me.GroupBox2.Visible = False
        '
        'rdo5th
        '
        Me.rdo5th.AutoSize = True
        Me.rdo5th.Location = New System.Drawing.Point(191, 13)
        Me.rdo5th.Name = "rdo5th"
        Me.rdo5th.Size = New System.Drawing.Size(41, 17)
        Me.rdo5th.TabIndex = 5
        Me.rdo5th.TabStop = True
        Me.rdo5th.Text = "5th"
        Me.rdo5th.UseVisualStyleBackColor = True
        '
        'rdo4th
        '
        Me.rdo4th.AutoSize = True
        Me.rdo4th.Location = New System.Drawing.Point(153, 13)
        Me.rdo4th.Name = "rdo4th"
        Me.rdo4th.Size = New System.Drawing.Size(41, 17)
        Me.rdo4th.TabIndex = 4
        Me.rdo4th.TabStop = True
        Me.rdo4th.Text = "4th"
        Me.rdo4th.UseVisualStyleBackColor = True
        '
        'rdo3rd
        '
        Me.rdo3rd.AutoSize = True
        Me.rdo3rd.Location = New System.Drawing.Point(115, 13)
        Me.rdo3rd.Name = "rdo3rd"
        Me.rdo3rd.Size = New System.Drawing.Size(41, 17)
        Me.rdo3rd.TabIndex = 3
        Me.rdo3rd.TabStop = True
        Me.rdo3rd.Text = "3rd"
        Me.rdo3rd.UseVisualStyleBackColor = True
        '
        'rdo2nd
        '
        Me.rdo2nd.AutoSize = True
        Me.rdo2nd.Location = New System.Drawing.Point(74, 13)
        Me.rdo2nd.Name = "rdo2nd"
        Me.rdo2nd.Size = New System.Drawing.Size(43, 17)
        Me.rdo2nd.TabIndex = 2
        Me.rdo2nd.TabStop = True
        Me.rdo2nd.Text = "2nd"
        Me.rdo2nd.UseVisualStyleBackColor = True
        '
        'rdo1st
        '
        Me.rdo1st.AutoSize = True
        Me.rdo1st.Location = New System.Drawing.Point(38, 13)
        Me.rdo1st.Name = "rdo1st"
        Me.rdo1st.Size = New System.Drawing.Size(40, 17)
        Me.rdo1st.TabIndex = 1
        Me.rdo1st.TabStop = True
        Me.rdo1st.Text = "1st"
        Me.rdo1st.UseVisualStyleBackColor = True
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(5, 14)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(36, 17)
        Me.rdoAll.TabIndex = 0
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "All"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'uCollections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uCollections"
        Me.Size = New System.Drawing.Size(786, 411)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpReportType.ResumeLayout(False)
        Me.grpReportType.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkHistory As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSEM As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents DsSchoolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents grpReportType As System.Windows.Forms.GroupBox
    Friend WithEvents rdoType3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoType2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoType1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo5th As System.Windows.Forms.RadioButton
    Friend WithEvents rdo4th As System.Windows.Forms.RadioButton
    Friend WithEvents rdo3rd As System.Windows.Forms.RadioButton
    Friend WithEvents rdo2nd As System.Windows.Forms.RadioButton
    Friend WithEvents rdo1st As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton

End Class
