<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCourseSubjectSelect
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DsRegistrar = New MMFCEnrollmentSystem.dsRegistrar
        Me.BlockSectionTuitionbyCourseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BlockSectionTuitionbyCourseTableAdapter = New MMFCEnrollmentSystem.dsRegistrarTableAdapters.BlockSectionTuitionbyCourseTableAdapter
        Me.BlockSectionPKDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.eduyear = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlockSectionTuitionbyCourseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(339, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BlockSectionPKDataGridViewTextBoxColumn, Me.Column1, Me.eduyear})
        Me.DataGridView1.DataSource = Me.BlockSectionTuitionbyCourseBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 41)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(426, 384)
        Me.DataGridView1.TabIndex = 3
        Me.DataGridView1.VirtualMode = True
        '
        'DsRegistrar
        '
        Me.DsRegistrar.DataSetName = "dsRegistrar"
        Me.DsRegistrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BlockSectionTuitionbyCourseBindingSource
        '
        Me.BlockSectionTuitionbyCourseBindingSource.DataMember = "BlockSectionTuitionbyCourse"
        Me.BlockSectionTuitionbyCourseBindingSource.DataSource = Me.DsRegistrar
        '
        'BlockSectionTuitionbyCourseTableAdapter
        '
        Me.BlockSectionTuitionbyCourseTableAdapter.ClearBeforeFill = True
        '
        'BlockSectionPKDataGridViewTextBoxColumn
        '
        Me.BlockSectionPKDataGridViewTextBoxColumn.DataPropertyName = "BlockSectionPK"
        Me.BlockSectionPKDataGridViewTextBoxColumn.HeaderText = "BlockSectionPK"
        Me.BlockSectionPKDataGridViewTextBoxColumn.Name = "BlockSectionPKDataGridViewTextBoxColumn"
        Me.BlockSectionPKDataGridViewTextBoxColumn.ReadOnly = True
        Me.BlockSectionPKDataGridViewTextBoxColumn.Width = 5
        '
        'Column1
        '
        Me.Column1.HeaderText = "Subject"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 300
        '
        'eduyear
        '
        Me.eduyear.DataPropertyName = "eduyear"
        Me.eduyear.HeaderText = "Yr"
        Me.eduyear.Name = "eduyear"
        Me.eduyear.ReadOnly = True
        Me.eduyear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.eduyear.Width = 20
        '
        'frmCourseSubjectSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(426, 425)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCourseSubjectSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose Subject"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRegistrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlockSectionTuitionbyCourseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BlockSectionTuitionbyCourseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRegistrar As MMFCEnrollmentSystem.dsRegistrar
    Friend WithEvents BlockSectionTuitionbyCourseTableAdapter As MMFCEnrollmentSystem.dsRegistrarTableAdapters.BlockSectionTuitionbyCourseTableAdapter
    Friend WithEvents BlockSectionPKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents eduyear As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
