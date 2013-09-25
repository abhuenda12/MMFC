<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uReceipts
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBoxRegNo = New System.Windows.Forms.TextBox
        Me.ButtonRegNo = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoPay5 = New System.Windows.Forms.RadioButton
        Me.rdoPay4 = New System.Windows.Forms.RadioButton
        Me.rdopay3 = New System.Windows.Forms.RadioButton
        Me.rdoPay2 = New System.Windows.Forms.RadioButton
        Me.rdopay1 = New System.Windows.Forms.RadioButton
        Me.rdoPaydp = New System.Windows.Forms.RadioButton
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.btnBreakdown = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReceivedFrom = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtReference = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtReceiptNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStudent = New System.Windows.Forms.TextBox
        Me.btnFinalize = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSem = New System.Windows.Forms.ComboBox
        Me.SemesterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSY = New System.Windows.Forms.ComboBox
        Me.SchoolYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.SchoolYearTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
        Me.SemesterTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupControl1.Size = New System.Drawing.Size(790, 589)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Receipts"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(2, 311)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(786, 276)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Student Ledger"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 17)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(780, 256)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBoxRegNo)
        Me.GroupBox1.Controls.Add(Me.ButtonRegNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtDate)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.btnBreakdown)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtReceivedFrom)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtReference)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtReceiptNumber)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtStudent)
        Me.GroupBox1.Controls.Add(Me.btnFinalize)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSem)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSY)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 289)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label9.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label9.Location = New System.Drawing.Point(264, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(252, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "you can override the registration number if needed"
        '
        'TextBoxRegNo
        '
        Me.TextBoxRegNo.Location = New System.Drawing.Point(166, 256)
        Me.TextBoxRegNo.Name = "TextBoxRegNo"
        Me.TextBoxRegNo.Size = New System.Drawing.Size(89, 21)
        Me.TextBoxRegNo.TabIndex = 26
        '
        'ButtonRegNo
        '
        Me.ButtonRegNo.Location = New System.Drawing.Point(94, 254)
        Me.ButtonRegNo.Name = "ButtonRegNo"
        Me.ButtonRegNo.Size = New System.Drawing.Size(66, 23)
        Me.ButtonRegNo.TabIndex = 25
        Me.ButtonRegNo.Text = "Create"
        Me.ButtonRegNo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Registration No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Date"
        '
        'txtDate
        '
        Me.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDate.Location = New System.Drawing.Point(482, 18)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(87, 21)
        Me.txtDate.TabIndex = 19
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtRemarks)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 180)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(563, 66)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(6, 14)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(551, 82)
        Me.txtRemarks.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoPay5)
        Me.GroupBox3.Controls.Add(Me.rdoPay4)
        Me.GroupBox3.Controls.Add(Me.rdopay3)
        Me.GroupBox3.Controls.Add(Me.rdoPay2)
        Me.GroupBox3.Controls.Add(Me.rdopay1)
        Me.GroupBox3.Controls.Add(Me.rdoPaydp)
        Me.GroupBox3.Location = New System.Drawing.Point(267, 129)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 45)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Payment Period"
        '
        'rdoPay5
        '
        Me.rdoPay5.AutoSize = True
        Me.rdoPay5.Location = New System.Drawing.Point(250, 20)
        Me.rdoPay5.Name = "rdoPay5"
        Me.rdoPay5.Size = New System.Drawing.Size(41, 17)
        Me.rdoPay5.TabIndex = 5
        Me.rdoPay5.TabStop = True
        Me.rdoPay5.Text = "5th"
        Me.rdoPay5.UseVisualStyleBackColor = True
        '
        'rdoPay4
        '
        Me.rdoPay4.AutoSize = True
        Me.rdoPay4.Location = New System.Drawing.Point(204, 20)
        Me.rdoPay4.Name = "rdoPay4"
        Me.rdoPay4.Size = New System.Drawing.Size(41, 17)
        Me.rdoPay4.TabIndex = 4
        Me.rdoPay4.TabStop = True
        Me.rdoPay4.Text = "4th"
        Me.rdoPay4.UseVisualStyleBackColor = True
        '
        'rdopay3
        '
        Me.rdopay3.AutoSize = True
        Me.rdopay3.Location = New System.Drawing.Point(160, 20)
        Me.rdopay3.Name = "rdopay3"
        Me.rdopay3.Size = New System.Drawing.Size(41, 17)
        Me.rdopay3.TabIndex = 3
        Me.rdopay3.TabStop = True
        Me.rdopay3.Text = "3rd"
        Me.rdopay3.UseVisualStyleBackColor = True
        '
        'rdoPay2
        '
        Me.rdoPay2.AutoSize = True
        Me.rdoPay2.Location = New System.Drawing.Point(111, 20)
        Me.rdoPay2.Name = "rdoPay2"
        Me.rdoPay2.Size = New System.Drawing.Size(43, 17)
        Me.rdoPay2.TabIndex = 2
        Me.rdoPay2.TabStop = True
        Me.rdoPay2.Text = "2nd"
        Me.rdoPay2.UseVisualStyleBackColor = True
        '
        'rdopay1
        '
        Me.rdopay1.AutoSize = True
        Me.rdopay1.Location = New System.Drawing.Point(65, 20)
        Me.rdopay1.Name = "rdopay1"
        Me.rdopay1.Size = New System.Drawing.Size(40, 17)
        Me.rdopay1.TabIndex = 1
        Me.rdopay1.TabStop = True
        Me.rdopay1.Text = "1st"
        Me.rdopay1.UseVisualStyleBackColor = True
        '
        'rdoPaydp
        '
        Me.rdoPaydp.AutoSize = True
        Me.rdoPaydp.Location = New System.Drawing.Point(21, 20)
        Me.rdoPaydp.Name = "rdoPaydp"
        Me.rdoPaydp.Size = New System.Drawing.Size(38, 17)
        Me.rdoPaydp.TabIndex = 0
        Me.rdoPaydp.TabStop = True
        Me.rdoPaydp.Text = "DP"
        Me.rdoPaydp.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(139, 136)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(122, 21)
        Me.txtAmount.TabIndex = 16
        '
        'btnBreakdown
        '
        Me.btnBreakdown.Location = New System.Drawing.Point(100, 134)
        Me.btnBreakdown.Name = "btnBreakdown"
        Me.btnBreakdown.Size = New System.Drawing.Size(33, 23)
        Me.btnBreakdown.TabIndex = 15
        Me.btnBreakdown.Text = "+"
        Me.btnBreakdown.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Amount"
        '
        'txtReceivedFrom
        '
        Me.txtReceivedFrom.Location = New System.Drawing.Point(101, 73)
        Me.txtReceivedFrom.Name = "txtReceivedFrom"
        Me.txtReceivedFrom.Size = New System.Drawing.Size(317, 21)
        Me.txtReceivedFrom.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Received From"
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(311, 46)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(107, 21)
        Me.txtReference.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(237, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Reference #"
        '
        'txtReceiptNumber
        '
        Me.txtReceiptNumber.Location = New System.Drawing.Point(100, 46)
        Me.txtReceiptNumber.Name = "txtReceiptNumber"
        Me.txtReceiptNumber.ReadOnly = True
        Me.txtReceiptNumber.Size = New System.Drawing.Size(121, 21)
        Me.txtReceiptNumber.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Receipt #"
        '
        'txtStudent
        '
        Me.txtStudent.Location = New System.Drawing.Point(140, 102)
        Me.txtStudent.Name = "txtStudent"
        Me.txtStudent.ReadOnly = True
        Me.txtStudent.Size = New System.Drawing.Size(278, 21)
        Me.txtStudent.TabIndex = 7
        '
        'btnFinalize
        '
        Me.btnFinalize.Location = New System.Drawing.Point(449, 45)
        Me.btnFinalize.Name = "btnFinalize"
        Me.btnFinalize.Size = New System.Drawing.Size(120, 44)
        Me.btnFinalize.TabIndex = 6
        Me.btnFinalize.Text = "Process Payment"
        Me.btnFinalize.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(101, 100)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = ".."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "For Student"
        '
        'txtSem
        '
        Me.txtSem.DataSource = Me.SemesterBindingSource
        Me.txtSem.DisplayMember = "SemesterName"
        Me.txtSem.FormattingEnabled = True
        Me.txtSem.Location = New System.Drawing.Point(311, 18)
        Me.txtSem.Name = "txtSem"
        Me.txtSem.Size = New System.Drawing.Size(107, 21)
        Me.txtSem.TabIndex = 3
        Me.txtSem.ValueMember = "SemPK"
        '
        'SemesterBindingSource
        '
        Me.SemesterBindingSource.DataMember = "Semester"
        Me.SemesterBindingSource.DataSource = Me.DsSchool
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Semester"
        '
        'txtSY
        '
        Me.txtSY.DataSource = Me.SchoolYearBindingSource
        Me.txtSY.DisplayMember = "SchoolYear"
        Me.txtSY.FormattingEnabled = True
        Me.txtSY.Location = New System.Drawing.Point(100, 18)
        Me.txtSY.Name = "txtSY"
        Me.txtSY.Size = New System.Drawing.Size(121, 21)
        Me.txtSY.TabIndex = 1
        Me.txtSY.ValueMember = "sypk"
        '
        'SchoolYearBindingSource
        '
        Me.SchoolYearBindingSource.DataMember = "SchoolYear"
        Me.SchoolYearBindingSource.DataSource = Me.DsSchool
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "School Year"
        '
        'SchoolYearTableAdapter
        '
        Me.SchoolYearTableAdapter.ClearBeforeFill = True
        '
        'SemesterTableAdapter
        '
        Me.SemesterTableAdapter.ClearBeforeFill = True
        '
        'uReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "uReceipts"
        Me.Size = New System.Drawing.Size(790, 589)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.SemesterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStudent As System.Windows.Forms.TextBox
    Friend WithEvents btnFinalize As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSem As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReceiptNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReceivedFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnBreakdown As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents rdoPay5 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPay4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdopay3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPay2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdopay1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPaydp As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SemesterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SchoolYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolYearTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SchoolYearTableAdapter
    Friend WithEvents SemesterTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SemesterTableAdapter
    Friend WithEvents TextBoxRegNo As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRegNo As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
