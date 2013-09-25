<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceiptsBreakdown
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.txtTotal = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.LedgerReceiptBreakdownBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFinance = New MMFCEnrollmentSystem.dsFinance
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.remarks2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LedgerReceiptBreakdownBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFinance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.txtTotal, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(562, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStripButton2.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Print
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(119, 22)
        Me.ToolStripButton2.Text = "GET TOTAL ( F5 )"
        '
        'txtTotal
        '
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = Global.MMFCEnrollmentSystem.My.Resources.Resources.Save
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripButton1.Text = "SAVE ( F3 )"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 375)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RemarksDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.remarks2})
        Me.DataGridView1.DataSource = Me.LedgerReceiptBreakdownBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(556, 353)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'LedgerReceiptBreakdownBindingSource
        '
        Me.LedgerReceiptBreakdownBindingSource.DataMember = "LedgerReceiptBreakdown"
        Me.LedgerReceiptBreakdownBindingSource.DataSource = Me.DsFinance
        '
        'DsFinance
        '
        Me.DsFinance.DataSetName = "dsFinance"
        Me.DsFinance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RemarksDataGridViewTextBoxColumn
        '
        Me.RemarksDataGridViewTextBoxColumn.DataPropertyName = "remarks"
        Me.RemarksDataGridViewTextBoxColumn.HeaderText = "Item/Remarks"
        Me.RemarksDataGridViewTextBoxColumn.Items.AddRange(New Object() {"ACCOMMODATION FEE", "ADDING/CHANGING", "ALUMNI FEE", "BACK ACCOUNTS", "BOARD EXAM PACKAGE", "BOARDING HOUSE", "CASES", "CERTIFICATION-GM", "CERTIFICATION-MOI", "CERTIFICATION-RLE", "CERTIFIED TRUE COPY (CTC)", "CHN", "CLINICAL FEE", "CLINICAL ROTATION", "COMPLETION", "CONTRIBUTION", "COURSE AUDIT", "COURSE DESCRIPTION", "DIPLOMA", "DMC", "EXTENSION FEE", "FORM", "GRADUATION FEE", "HONORABLE DISMISSAL", "ID (NEW)", "INTERNET FEE", "LIBRARY FEE", "P.E. UNIFORM", "PARAPHERNALIA", "PHYSICAL EXAM", "PUBLICATION", "REMOVAL", "S/O", "SCRUBSUIT", "SPECIAL EXAM", "STATEMENT OF ACCOUNT", "TRANSCRIPT OF RECORDS", "TUITION FEE", "TUTORIAL FEE", "YEARBOOK", "OTHER FEES", "ENROLLMENT - DMC", "ENROLLMENT - LIB", "ENROLLMENT - PUB", "ENROLLMENT - INTERNET", "ENROLLMENT - ID", "ENROLLMENT - INSU", "ENROLLMENT - PRISAA", "ENROLLMENT - HANDBOOK"})
        Me.RemarksDataGridViewTextBoxColumn.Name = "RemarksDataGridViewTextBoxColumn"
        Me.RemarksDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RemarksDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RemarksDataGridViewTextBoxColumn.Width = 200
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "amount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.AmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        '
        'remarks2
        '
        Me.remarks2.DataPropertyName = "remarks2"
        Me.remarks2.HeaderText = "Addtl Remarks"
        Me.remarks2.Name = "remarks2"
        Me.remarks2.Width = 200
        '
        'frmReceiptsBreakdown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(562, 400)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmReceiptsBreakdown"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Breakdown for Payment"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LedgerReceiptBreakdownBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFinance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtTotal As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LedgerReceiptBreakdownBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsFinance As MMFCEnrollmentSystem.dsFinance
    Friend WithEvents RemarksDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
