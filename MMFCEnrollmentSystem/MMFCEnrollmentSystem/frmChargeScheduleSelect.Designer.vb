<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChargeScheduleSelect
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ChargeSchedulebyNameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFinance = New MMFCEnrollmentSystem.dsFinance
        Me.ChargeSchedulebyNameTableAdapter = New MMFCEnrollmentSystem.dsFinanceTableAdapters.ChargeSchedulebyNameTableAdapter
        Me.CategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldStudentDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.NewStudentDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TransferStudentDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChargeSchedulebyNameBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFinance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 57)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(424, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "&Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(343, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filter"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(55, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(269, 23)
        Me.TextBox1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategoryDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.OldStudentDataGridViewCheckBoxColumn, Me.NewStudentDataGridViewCheckBoxColumn, Me.TransferStudentDataGridViewCheckBoxColumn, Me.RemarksDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ChargeSchedulebyNameBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(859, 373)
        Me.DataGridView1.TabIndex = 6
        '
        'ChargeSchedulebyNameBindingSource
        '
        Me.ChargeSchedulebyNameBindingSource.DataMember = "ChargeSchedulebyName"
        Me.ChargeSchedulebyNameBindingSource.DataSource = Me.DsFinance
        '
        'DsFinance
        '
        Me.DsFinance.DataSetName = "dsFinance"
        Me.DsFinance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ChargeSchedulebyNameTableAdapter
        '
        Me.ChargeSchedulebyNameTableAdapter.ClearBeforeFill = True
        '
        'CategoryDataGridViewTextBoxColumn
        '
        Me.CategoryDataGridViewTextBoxColumn.DataPropertyName = "Category"
        Me.CategoryDataGridViewTextBoxColumn.HeaderText = "Category"
        Me.CategoryDataGridViewTextBoxColumn.Name = "CategoryDataGridViewTextBoxColumn"
        Me.CategoryDataGridViewTextBoxColumn.ReadOnly = True
        Me.CategoryDataGridViewTextBoxColumn.Width = 140
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameDataGridViewTextBoxColumn.Width = 200
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.AmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OldStudentDataGridViewCheckBoxColumn
        '
        Me.OldStudentDataGridViewCheckBoxColumn.DataPropertyName = "oldStudent"
        Me.OldStudentDataGridViewCheckBoxColumn.HeaderText = "Old"
        Me.OldStudentDataGridViewCheckBoxColumn.Name = "OldStudentDataGridViewCheckBoxColumn"
        Me.OldStudentDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OldStudentDataGridViewCheckBoxColumn.Width = 80
        '
        'NewStudentDataGridViewCheckBoxColumn
        '
        Me.NewStudentDataGridViewCheckBoxColumn.DataPropertyName = "newStudent"
        Me.NewStudentDataGridViewCheckBoxColumn.HeaderText = "New"
        Me.NewStudentDataGridViewCheckBoxColumn.Name = "NewStudentDataGridViewCheckBoxColumn"
        Me.NewStudentDataGridViewCheckBoxColumn.ReadOnly = True
        Me.NewStudentDataGridViewCheckBoxColumn.Width = 80
        '
        'TransferStudentDataGridViewCheckBoxColumn
        '
        Me.TransferStudentDataGridViewCheckBoxColumn.DataPropertyName = "transferStudent"
        Me.TransferStudentDataGridViewCheckBoxColumn.HeaderText = "Transfer."
        Me.TransferStudentDataGridViewCheckBoxColumn.Name = "TransferStudentDataGridViewCheckBoxColumn"
        Me.TransferStudentDataGridViewCheckBoxColumn.ReadOnly = True
        Me.TransferStudentDataGridViewCheckBoxColumn.Width = 80
        '
        'RemarksDataGridViewTextBoxColumn
        '
        Me.RemarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.HeaderText = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.Name = "RemarksDataGridViewTextBoxColumn"
        Me.RemarksDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmChargeScheduleSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(859, 430)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmChargeScheduleSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select a Misc. Charge Item"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChargeSchedulebyNameBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFinance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ChargeSchedulebyNameBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsFinance As MMFCEnrollmentSystem.dsFinance
    Friend WithEvents ChargeSchedulebyNameTableAdapter As MMFCEnrollmentSystem.dsFinanceTableAdapters.ChargeSchedulebyNameTableAdapter
    Friend WithEvents CategoryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldStudentDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NewStudentDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TransferStudentDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
