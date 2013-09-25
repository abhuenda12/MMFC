<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectFusionList
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SYOfferingByFusedSubjectPKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRegistrar = New MMFCEnrollmentSystem.dsRegistrar
        Me.SYOfferingByFusedSubjectPKTableAdapter = New MMFCEnrollmentSystem.dsRegistrarTableAdapters.SYOfferingByFusedSubjectPKTableAdapter
        Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SchoolYearDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SemesterNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainSubjectDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FusedSubjectDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TeacherDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SYOfferingByFusedSubjectPKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateCreatedDataGridViewTextBoxColumn, Me.SchoolYearDataGridViewTextBoxColumn, Me.SemesterNameDataGridViewTextBoxColumn, Me.MainSubjectDataGridViewTextBoxColumn, Me.FusedSubjectDataGridViewTextBoxColumn, Me.TeacherDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.SYOfferingByFusedSubjectPKBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1093, 571)
        Me.DataGridView1.TabIndex = 0
        '
        'SYOfferingByFusedSubjectPKBindingSource
        '
        Me.SYOfferingByFusedSubjectPKBindingSource.DataMember = "SYOfferingByFusedSubjectPK"
        Me.SYOfferingByFusedSubjectPKBindingSource.DataSource = Me.DsRegistrar
        '
        'DsRegistrar
        '
        Me.DsRegistrar.DataSetName = "dsRegistrar"
        Me.DsRegistrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SYOfferingByFusedSubjectPKTableAdapter
        '
        Me.SYOfferingByFusedSubjectPKTableAdapter.ClearBeforeFill = True
        '
        'DateCreatedDataGridViewTextBoxColumn
        '
        Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "dateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "dateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
        Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SchoolYearDataGridViewTextBoxColumn
        '
        Me.SchoolYearDataGridViewTextBoxColumn.DataPropertyName = "SchoolYear"
        Me.SchoolYearDataGridViewTextBoxColumn.HeaderText = "SchoolYear"
        Me.SchoolYearDataGridViewTextBoxColumn.Name = "SchoolYearDataGridViewTextBoxColumn"
        Me.SchoolYearDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SemesterNameDataGridViewTextBoxColumn
        '
        Me.SemesterNameDataGridViewTextBoxColumn.DataPropertyName = "SemesterName"
        Me.SemesterNameDataGridViewTextBoxColumn.HeaderText = "SemesterName"
        Me.SemesterNameDataGridViewTextBoxColumn.Name = "SemesterNameDataGridViewTextBoxColumn"
        Me.SemesterNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MainSubjectDataGridViewTextBoxColumn
        '
        Me.MainSubjectDataGridViewTextBoxColumn.DataPropertyName = "MainSubject"
        Me.MainSubjectDataGridViewTextBoxColumn.HeaderText = "MainSubject"
        Me.MainSubjectDataGridViewTextBoxColumn.Name = "MainSubjectDataGridViewTextBoxColumn"
        Me.MainSubjectDataGridViewTextBoxColumn.ReadOnly = True
        Me.MainSubjectDataGridViewTextBoxColumn.Width = 240
        '
        'FusedSubjectDataGridViewTextBoxColumn
        '
        Me.FusedSubjectDataGridViewTextBoxColumn.DataPropertyName = "FusedSubject"
        Me.FusedSubjectDataGridViewTextBoxColumn.HeaderText = "FusedSubject"
        Me.FusedSubjectDataGridViewTextBoxColumn.Name = "FusedSubjectDataGridViewTextBoxColumn"
        Me.FusedSubjectDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TeacherDataGridViewTextBoxColumn
        '
        Me.TeacherDataGridViewTextBoxColumn.DataPropertyName = "Teacher"
        Me.TeacherDataGridViewTextBoxColumn.HeaderText = "Teacher"
        Me.TeacherDataGridViewTextBoxColumn.Name = "TeacherDataGridViewTextBoxColumn"
        Me.TeacherDataGridViewTextBoxColumn.ReadOnly = True
        Me.TeacherDataGridViewTextBoxColumn.Width = 200
        '
        'frmSubjectFusionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 571)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmSubjectFusionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Subject fusion List"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SYOfferingByFusedSubjectPKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SYOfferingByFusedSubjectPKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRegistrar As MMFCEnrollmentSystem.dsRegistrar
    Friend WithEvents SYOfferingByFusedSubjectPKTableAdapter As MMFCEnrollmentSystem.dsRegistrarTableAdapters.SYOfferingByFusedSubjectPKTableAdapter
    Friend WithEvents DateCreatedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SchoolYearDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SemesterNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainSubjectDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FusedSubjectDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeacherDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
