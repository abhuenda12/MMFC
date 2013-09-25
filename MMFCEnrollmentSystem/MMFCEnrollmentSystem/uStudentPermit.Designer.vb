<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uStudentPermit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSAO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkEmptyIssuedDate = New System.Windows.Forms.CheckBox
        Me.dateIssued = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dateValidity = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.datePaymentMonth = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtExam = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPermitNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GroupBox2)
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(792, 437)
        Me.GroupControl1.TabIndex = 6
        Me.GroupControl1.Text = "Student Permit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(2, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(788, 265)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 17)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(782, 245)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Controls.Add(Me.txtSAO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkEmptyIssuedDate)
        Me.GroupBox1.Controls.Add(Me.dateIssued)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dateValidity)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.datePaymentMonth)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtExam)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPermitNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(788, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtSAO
        '
        Me.txtSAO.Location = New System.Drawing.Point(537, 14)
        Me.txtSAO.Name = "txtSAO"
        Me.txtSAO.Size = New System.Drawing.Size(160, 21)
        Me.txtSAO.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(503, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "SAO"
        '
        'chkEmptyIssuedDate
        '
        Me.chkEmptyIssuedDate.AutoSize = True
        Me.chkEmptyIssuedDate.Location = New System.Drawing.Point(477, 70)
        Me.chkEmptyIssuedDate.Name = "chkEmptyIssuedDate"
        Me.chkEmptyIssuedDate.Size = New System.Drawing.Size(122, 17)
        Me.chkEmptyIssuedDate.TabIndex = 27
        Me.chkEmptyIssuedDate.Text = "Empty Issued Date?"
        Me.chkEmptyIssuedDate.UseVisualStyleBackColor = True
        '
        'dateIssued
        '
        Me.dateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateIssued.Location = New System.Drawing.Point(359, 68)
        Me.dateIssued.Name = "dateIssued"
        Me.dateIssued.Size = New System.Drawing.Size(112, 21)
        Me.dateIssued.TabIndex = 26
        Me.dateIssued.Value = New Date(2011, 7, 10, 12, 6, 12, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(295, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Issued"
        '
        'dateValidity
        '
        Me.dateValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateValidity.Location = New System.Drawing.Point(359, 41)
        Me.dateValidity.Name = "dateValidity"
        Me.dateValidity.Size = New System.Drawing.Size(112, 21)
        Me.dateValidity.TabIndex = 24
        Me.dateValidity.Value = New Date(2011, 7, 10, 12, 6, 12, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(295, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Valid up to"
        '
        'datePaymentMonth
        '
        Me.datePaymentMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datePaymentMonth.Location = New System.Drawing.Point(359, 14)
        Me.datePaymentMonth.Name = "datePaymentMonth"
        Me.datePaymentMonth.Size = New System.Drawing.Size(112, 21)
        Me.datePaymentMonth.TabIndex = 22
        Me.datePaymentMonth.Value = New Date(2011, 7, 10, 12, 6, 12, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(295, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Month"
        '
        'txtExam
        '
        Me.txtExam.Location = New System.Drawing.Point(106, 68)
        Me.txtExam.Name = "txtExam"
        Me.txtExam.Size = New System.Drawing.Size(160, 21)
        Me.txtExam.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "For Exam"
        '
        'txtPermitNo
        '
        Me.txtPermitNo.Location = New System.Drawing.Point(106, 41)
        Me.txtPermitNo.Name = "txtPermitNo"
        Me.txtPermitNo.Size = New System.Drawing.Size(160, 21)
        Me.txtPermitNo.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Permit Number"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(624, 66)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(67, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = ".."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(106, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(160, 21)
        Me.TextBox1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Student"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMessage.Location = New System.Drawing.Point(103, 110)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(305, 13)
        Me.lblMessage.TabIndex = 30
        Me.lblMessage.Text = "You can change the permit # if you want to reprint a lost one."
        Me.lblMessage.Visible = False
        '
        'uStudentPermit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uStudentPermit"
        Me.Size = New System.Drawing.Size(792, 437)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPermitNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtExam As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSAO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkEmptyIssuedDate As System.Windows.Forms.CheckBox
    Friend WithEvents dateIssued As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dateValidity As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents datePaymentMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label

End Class
