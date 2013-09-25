<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uSubjects
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uSubjects))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SubjectCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubjectNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LabunitsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MajorDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SubjectsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.txtFilter = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.SubjectsTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsTableAdapter
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(836, 624)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Subjects List"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SubjectCodeDataGridViewTextBoxColumn, Me.SubjectNameDataGridViewTextBoxColumn, Me.UnitsDataGridViewTextBoxColumn, Me.LabunitsDataGridViewTextBoxColumn, Me.MajorDataGridViewCheckBoxColumn})
        Me.DataGridView1.DataSource = Me.SubjectsBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(836, 624)
        Me.DataGridView1.TabIndex = 0
        '
        'SubjectCodeDataGridViewTextBoxColumn
        '
        Me.SubjectCodeDataGridViewTextBoxColumn.DataPropertyName = "SubjectCode"
        Me.SubjectCodeDataGridViewTextBoxColumn.HeaderText = "Subject Code"
        Me.SubjectCodeDataGridViewTextBoxColumn.Name = "SubjectCodeDataGridViewTextBoxColumn"
        Me.SubjectCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SubjectNameDataGridViewTextBoxColumn
        '
        Me.SubjectNameDataGridViewTextBoxColumn.DataPropertyName = "SubjectName"
        Me.SubjectNameDataGridViewTextBoxColumn.HeaderText = "Subject Name"
        Me.SubjectNameDataGridViewTextBoxColumn.Name = "SubjectNameDataGridViewTextBoxColumn"
        Me.SubjectNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.SubjectNameDataGridViewTextBoxColumn.Width = 300
        '
        'UnitsDataGridViewTextBoxColumn
        '
        Me.UnitsDataGridViewTextBoxColumn.DataPropertyName = "units"
        Me.UnitsDataGridViewTextBoxColumn.HeaderText = "Units"
        Me.UnitsDataGridViewTextBoxColumn.Name = "UnitsDataGridViewTextBoxColumn"
        Me.UnitsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LabunitsDataGridViewTextBoxColumn
        '
        Me.LabunitsDataGridViewTextBoxColumn.DataPropertyName = "labunits"
        Me.LabunitsDataGridViewTextBoxColumn.HeaderText = "Lab Units"
        Me.LabunitsDataGridViewTextBoxColumn.Name = "LabunitsDataGridViewTextBoxColumn"
        Me.LabunitsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MajorDataGridViewCheckBoxColumn
        '
        Me.MajorDataGridViewCheckBoxColumn.DataPropertyName = "major"
        Me.MajorDataGridViewCheckBoxColumn.HeaderText = "Major"
        Me.MajorDataGridViewCheckBoxColumn.Name = "MajorDataGridViewCheckBoxColumn"
        Me.MajorDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'SubjectsBindingSource
        '
        Me.SubjectsBindingSource.DataMember = "Subjects"
        Me.SubjectsBindingSource.DataSource = Me.DsSchool
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.CutToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.txtFilter, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(836, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(49, 22)
        Me.NewToolStripButton.Text = "&Add"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(47, 22)
        Me.OpenToolStripButton.Text = "&Edit"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.CutToolStripButton.Text = "&Delete"
        Me.CutToolStripButton.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Info
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripButton2.Text = "Check Fusions"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'txtFilter
        '
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(162, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripButton1.Text = "Filter"
        '
        'SubjectsTableAdapter
        '
        Me.SubjectsTableAdapter.ClearBeforeFill = True
        '
        'uSubjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "uSubjects"
        Me.Size = New System.Drawing.Size(836, 624)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SubjectsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SubjectsTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsTableAdapter
    Friend WithEvents SubjectCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubjectNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabunitsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MajorDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl

End Class
