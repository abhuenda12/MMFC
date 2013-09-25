<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uReceiptsListing
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
        Me.chkAllCashiers = New System.Windows.Forms.CheckBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbCashier = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DsSystem = New MMFCEnrollmentSystem.dsSystem
        Me.CashiersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CashiersTableAdapter = New MMFCEnrollmentSystem.dsSystemTableAdapters.CashiersTableAdapter
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DsSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashiersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(779, 414)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Receipts Listing"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 72)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(775, 340)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAllCashiers)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmbCashier)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkAllCashiers
        '
        Me.chkAllCashiers.AutoSize = True
        Me.chkAllCashiers.Location = New System.Drawing.Point(536, 20)
        Me.chkAllCashiers.Name = "chkAllCashiers"
        Me.chkAllCashiers.Size = New System.Drawing.Size(81, 17)
        Me.chkAllCashiers.TabIndex = 11
        Me.chkAllCashiers.Text = "All Cashiers"
        Me.chkAllCashiers.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(226, 15)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(111, 21)
        Me.DateTimePicker2.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "---      To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(54, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(111, 21)
        Me.DateTimePicker1.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(623, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbCashier
        '
        Me.cmbCashier.DataSource = Me.CashiersBindingSource
        Me.cmbCashier.DisplayMember = "cashier"
        Me.cmbCashier.FormattingEnabled = True
        Me.cmbCashier.Location = New System.Drawing.Point(409, 18)
        Me.cmbCashier.Name = "cmbCashier"
        Me.cmbCashier.Size = New System.Drawing.Size(121, 21)
        Me.cmbCashier.TabIndex = 3
        Me.cmbCashier.ValueMember = "cashier"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cashier"
        '
        'DsSystem
        '
        Me.DsSystem.DataSetName = "dsSystem"
        Me.DsSystem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CashiersBindingSource
        '
        Me.CashiersBindingSource.DataMember = "Cashiers"
        Me.CashiersBindingSource.DataSource = Me.DsSystem
        '
        'CashiersTableAdapter
        '
        Me.CashiersTableAdapter.ClearBeforeFill = True
        '
        'uReceiptsListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uReceiptsListing"
        Me.Size = New System.Drawing.Size(779, 414)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DsSystem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashiersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbCashier As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAllCashiers As System.Windows.Forms.CheckBox
    Friend WithEvents CashiersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSystem As MMFCEnrollmentSystem.dsSystem
    Friend WithEvents CashiersTableAdapter As MMFCEnrollmentSystem.dsSystemTableAdapters.CashiersTableAdapter

End Class
