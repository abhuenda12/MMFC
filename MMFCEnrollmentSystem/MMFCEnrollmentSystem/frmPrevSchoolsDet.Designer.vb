<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrevSchoolsDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrevSchoolsDet))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.lblStudentName = New System.Windows.Forms.ToolStripLabel
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DsReg2 = New MMFCEnrollmentSystem.dsReg2
        Me.PreviousSchoolsByStudentPKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PreviousSchoolsByStudentPKTableAdapter = New MMFCEnrollmentSystem.dsReg2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
        Me.SchoolNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearAttendDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreviousSchoolsByStudentPKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStudentName, Me.SaveToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(502, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblStudentName
        '
        Me.lblStudentName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(99, 22)
        Me.lblStudentName.Text = "Student Name"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SchoolNameDataGridViewTextBoxColumn, Me.YearAttendDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PreviousSchoolsByStudentPKBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(502, 409)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.VirtualMode = True
        '
        'DsReg2
        '
        Me.DsReg2.DataSetName = "dsReg2"
        Me.DsReg2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PreviousSchoolsByStudentPKBindingSource
        '
        Me.PreviousSchoolsByStudentPKBindingSource.DataMember = "PreviousSchoolsByStudentPK"
        Me.PreviousSchoolsByStudentPKBindingSource.DataSource = Me.DsReg2
        '
        'PreviousSchoolsByStudentPKTableAdapter
        '
        Me.PreviousSchoolsByStudentPKTableAdapter.ClearBeforeFill = True
        '
        'SchoolNameDataGridViewTextBoxColumn
        '
        Me.SchoolNameDataGridViewTextBoxColumn.DataPropertyName = "SchoolName"
        Me.SchoolNameDataGridViewTextBoxColumn.HeaderText = "School Name"
        Me.SchoolNameDataGridViewTextBoxColumn.Name = "SchoolNameDataGridViewTextBoxColumn"
        Me.SchoolNameDataGridViewTextBoxColumn.Width = 240
        '
        'YearAttendDataGridViewTextBoxColumn
        '
        Me.YearAttendDataGridViewTextBoxColumn.DataPropertyName = "YearAttend"
        Me.YearAttendDataGridViewTextBoxColumn.HeaderText = "Year Attend (format 1999-2000)"
        Me.YearAttendDataGridViewTextBoxColumn.Name = "YearAttendDataGridViewTextBoxColumn"
        Me.YearAttendDataGridViewTextBoxColumn.Width = 200
        '
        'frmPrevSchoolsDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(502, 434)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPrevSchoolsDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure additional previous schools"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreviousSchoolsByStudentPKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblStudentName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SchoolNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearAttendDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreviousSchoolsByStudentPKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsReg2 As MMFCEnrollmentSystem.dsReg2
    Friend WithEvents PreviousSchoolsByStudentPKTableAdapter As MMFCEnrollmentSystem.dsReg2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
End Class
