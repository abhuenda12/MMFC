<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectExSchool
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DsSchool2 = New MMFCEnrollmentSystem.dsSchool2
        Me.PreviousSchoolsByStudentPKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PreviousSchoolsByStudentPKTableAdapter = New MMFCEnrollmentSystem.dsSchool2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
        Me.PrevShoolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreviousSchoolsByStudentPKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(201, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrevShoolDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PreviousSchoolsByStudentPKBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 70)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(367, 251)
        Me.DataGridView1.TabIndex = 1
        '
        'DsSchool2
        '
        Me.DsSchool2.DataSetName = "dsSchool2"
        Me.DsSchool2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PreviousSchoolsByStudentPKBindingSource
        '
        Me.PreviousSchoolsByStudentPKBindingSource.DataMember = "PreviousSchoolsByStudentPK"
        Me.PreviousSchoolsByStudentPKBindingSource.DataSource = Me.DsSchool2
        '
        'PreviousSchoolsByStudentPKTableAdapter
        '
        Me.PreviousSchoolsByStudentPKTableAdapter.ClearBeforeFill = True
        '
        'PrevShoolDataGridViewTextBoxColumn
        '
        Me.PrevShoolDataGridViewTextBoxColumn.DataPropertyName = "PrevShool"
        Me.PrevShoolDataGridViewTextBoxColumn.HeaderText = "Previous Shools"
        Me.PrevShoolDataGridViewTextBoxColumn.Name = "PrevShoolDataGridViewTextBoxColumn"
        Me.PrevShoolDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrevShoolDataGridViewTextBoxColumn.Width = 300
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(280, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmSelectExSchool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(367, 321)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectExSchool"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Previous School"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreviousSchoolsByStudentPKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PreviousSchoolsByStudentPKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool2 As MMFCEnrollmentSystem.dsSchool2
    Friend WithEvents PreviousSchoolsByStudentPKTableAdapter As MMFCEnrollmentSystem.dsSchool2TableAdapters.PreviousSchoolsByStudentPKTableAdapter
    Friend WithEvents PrevShoolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
