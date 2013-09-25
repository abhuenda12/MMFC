<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uReceivables
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rdo60days = New System.Windows.Forms.RadioButton
        Me.rdo30days = New System.Windows.Forms.RadioButton
        Me.rdoAlldays = New System.Windows.Forms.RadioButton
        Me.rdo15days = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoAllBalance = New System.Windows.Forms.RadioButton
        Me.rdoWithBalance = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkAllStudents = New System.Windows.Forms.CheckBox
        Me.txtStudentName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.GroupControl1.Size = New System.Drawing.Size(785, 414)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Receivables Report"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 130)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(781, 282)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 108)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdo60days)
        Me.GroupBox4.Controls.Add(Me.rdo30days)
        Me.GroupBox4.Controls.Add(Me.rdoAlldays)
        Me.GroupBox4.Controls.Add(Me.rdo15days)
        Me.GroupBox4.Location = New System.Drawing.Point(421, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(235, 79)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "By Account Age of Last Transaction  (Days)"
        '
        'rdo60days
        '
        Me.rdo60days.AutoSize = True
        Me.rdo60days.Location = New System.Drawing.Point(114, 23)
        Me.rdo60days.Name = "rdo60days"
        Me.rdo60days.Size = New System.Drawing.Size(37, 17)
        Me.rdo60days.TabIndex = 3
        Me.rdo60days.TabStop = True
        Me.rdo60days.Text = "60"
        Me.rdo60days.UseVisualStyleBackColor = True
        '
        'rdo30days
        '
        Me.rdo30days.AutoSize = True
        Me.rdo30days.Location = New System.Drawing.Point(59, 23)
        Me.rdo30days.Name = "rdo30days"
        Me.rdo30days.Size = New System.Drawing.Size(37, 17)
        Me.rdo30days.TabIndex = 2
        Me.rdo30days.TabStop = True
        Me.rdo30days.Text = "30"
        Me.rdo30days.UseVisualStyleBackColor = True
        '
        'rdoAlldays
        '
        Me.rdoAlldays.AutoSize = True
        Me.rdoAlldays.Location = New System.Drawing.Point(6, 49)
        Me.rdoAlldays.Name = "rdoAlldays"
        Me.rdoAlldays.Size = New System.Drawing.Size(36, 17)
        Me.rdoAlldays.TabIndex = 1
        Me.rdoAlldays.TabStop = True
        Me.rdoAlldays.Text = "All"
        Me.rdoAlldays.UseVisualStyleBackColor = True
        '
        'rdo15days
        '
        Me.rdo15days.AutoSize = True
        Me.rdo15days.Location = New System.Drawing.Point(6, 23)
        Me.rdo15days.Name = "rdo15days"
        Me.rdo15days.Size = New System.Drawing.Size(37, 17)
        Me.rdo15days.TabIndex = 0
        Me.rdo15days.TabStop = True
        Me.rdo15days.Text = "15"
        Me.rdo15days.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoAllBalance)
        Me.GroupBox3.Controls.Add(Me.rdoWithBalance)
        Me.GroupBox3.Location = New System.Drawing.Point(319, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(96, 79)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "By Balance"
        '
        'rdoAllBalance
        '
        Me.rdoAllBalance.AutoSize = True
        Me.rdoAllBalance.Location = New System.Drawing.Point(6, 49)
        Me.rdoAllBalance.Name = "rdoAllBalance"
        Me.rdoAllBalance.Size = New System.Drawing.Size(36, 17)
        Me.rdoAllBalance.TabIndex = 1
        Me.rdoAllBalance.TabStop = True
        Me.rdoAllBalance.Text = "All"
        Me.rdoAllBalance.UseVisualStyleBackColor = True
        '
        'rdoWithBalance
        '
        Me.rdoWithBalance.AutoSize = True
        Me.rdoWithBalance.Location = New System.Drawing.Point(6, 23)
        Me.rdoWithBalance.Name = "rdoWithBalance"
        Me.rdoWithBalance.Size = New System.Drawing.Size(87, 17)
        Me.rdoWithBalance.TabIndex = 0
        Me.rdoWithBalance.TabStop = True
        Me.rdoWithBalance.Text = "With Balance"
        Me.rdoWithBalance.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAllStudents)
        Me.GroupBox2.Controls.Add(Me.txtStudentName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 79)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Student"
        '
        'chkAllStudents
        '
        Me.chkAllStudents.AutoSize = True
        Me.chkAllStudents.Location = New System.Drawing.Point(49, 50)
        Me.chkAllStudents.Name = "chkAllStudents"
        Me.chkAllStudents.Size = New System.Drawing.Size(83, 17)
        Me.chkAllStudents.TabIndex = 8
        Me.chkAllStudents.Text = "All Students"
        Me.chkAllStudents.UseVisualStyleBackColor = True
        '
        'txtStudentName
        '
        Me.txtStudentName.Location = New System.Drawing.Point(88, 22)
        Me.txtStudentName.Name = "txtStudentName"
        Me.txtStudentName.ReadOnly = True
        Me.txtStudentName.Size = New System.Drawing.Size(195, 21)
        Me.txtStudentName.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Name"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(662, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Retrieve"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(49, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = ".."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'uReceivables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uReceivables"
        Me.Size = New System.Drawing.Size(785, 414)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStudentName As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllStudents As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAlldays As System.Windows.Forms.RadioButton
    Friend WithEvents rdo15days As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAllBalance As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWithBalance As System.Windows.Forms.RadioButton
    Friend WithEvents rdo60days As System.Windows.Forms.RadioButton
    Friend WithEvents rdo30days As System.Windows.Forms.RadioButton

End Class
