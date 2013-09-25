<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrTypesSelect
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.TRTypesbyNameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TRTypesbyNameTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.TRTypesbyNameTableAdapter
        Me.TRCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TRNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TRAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRTypesbyNameBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(561, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(451, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "&Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(370, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(75, 22)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(269, 23)
        Me.TextBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Filter"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TRCodeDataGridViewTextBoxColumn, Me.TRNameDataGridViewTextBoxColumn, Me.TRAmountDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TRTypesbyNameBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(561, 428)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.VirtualMode = True
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TRTypesbyNameBindingSource
        '
        Me.TRTypesbyNameBindingSource.DataMember = "TRTypesbyName"
        Me.TRTypesbyNameBindingSource.DataSource = Me.DsSchool
        '
        'TRTypesbyNameTableAdapter
        '
        Me.TRTypesbyNameTableAdapter.ClearBeforeFill = True
        '
        'TRCodeDataGridViewTextBoxColumn
        '
        Me.TRCodeDataGridViewTextBoxColumn.DataPropertyName = "TRCode"
        Me.TRCodeDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.TRCodeDataGridViewTextBoxColumn.Name = "TRCodeDataGridViewTextBoxColumn"
        Me.TRCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.TRCodeDataGridViewTextBoxColumn.Width = 140
        '
        'TRNameDataGridViewTextBoxColumn
        '
        Me.TRNameDataGridViewTextBoxColumn.DataPropertyName = "TRName"
        Me.TRNameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.TRNameDataGridViewTextBoxColumn.Name = "TRNameDataGridViewTextBoxColumn"
        Me.TRNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.TRNameDataGridViewTextBoxColumn.Width = 220
        '
        'TRAmountDataGridViewTextBoxColumn
        '
        Me.TRAmountDataGridViewTextBoxColumn.DataPropertyName = "TRAmount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.TRAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TRAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.TRAmountDataGridViewTextBoxColumn.Name = "TRAmountDataGridViewTextBoxColumn"
        Me.TRAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmTrTypesSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(561, 500)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTrTypesSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Transaction Type Charge"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRTypesbyNameBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TRCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRTypesbyNameBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents TRTypesbyNameTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.TRTypesbyNameTableAdapter
End Class
