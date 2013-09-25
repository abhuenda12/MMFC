<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjects
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
        Me.chkInactive = New System.Windows.Forms.CheckBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Button14 = New System.Windows.Forms.Button
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Button15 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button12 = New System.Windows.Forms.Button
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Button13 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button10 = New System.Windows.Forms.Button
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.chkMajor = New System.Windows.Forms.CheckBox
        Me.txtLabunits = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRem = New System.Windows.Forms.Label
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.SubjectsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubjectsTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsTableAdapter
        Me.TextBoxRLEUnits = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkInactive
        '
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Location = New System.Drawing.Point(124, 324)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(69, 19)
        Me.chkInactive.TabIndex = 57
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.ComboBox1.Location = New System.Drawing.Point(357, 105)
        Me.ComboBox1.MaxLength = 1
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(81, 23)
        Me.ComboBox1.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(235, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 23)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Credit Group Number :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(170, 157)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 12)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "(Please input numbers from 0 - 7 only)"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(121, 153)
        Me.TextBox12.MaxLength = 2
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(43, 23)
        Me.TextBox12.TabIndex = 46
        Me.TextBox12.Text = "0"
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(39, 157)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Pre Req"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Controls.Add(Me.TextBox11)
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.TextBox10)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(48, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 11)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 172)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "PreReq"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(77, 168)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(23, 23)
        Me.Button14.TabIndex = 25
        Me.Button14.Text = ".."
        Me.Button14.UseVisualStyleBackColor = True
        '
        'TextBox11
        '
        Me.TextBox11.Enabled = False
        Me.TextBox11.Location = New System.Drawing.Point(106, 170)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(152, 23)
        Me.TextBox11.TabIndex = 26
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(262, 170)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 23)
        Me.Button15.TabIndex = 27
        Me.Button15.Text = "Clear"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "PreReq"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(77, 142)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(23, 23)
        Me.Button12.TabIndex = 22
        Me.Button12.Text = ".."
        Me.Button12.UseVisualStyleBackColor = True
        '
        'TextBox10
        '
        Me.TextBox10.Enabled = False
        Me.TextBox10.Location = New System.Drawing.Point(106, 144)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(152, 23)
        Me.TextBox10.TabIndex = 23
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(262, 144)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 23)
        Me.Button13.TabIndex = 24
        Me.Button13.Text = "Clear"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "PreReq"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(77, 116)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(23, 23)
        Me.Button10.TabIndex = 19
        Me.Button10.Text = ".."
        Me.Button10.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(106, 118)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(152, 23)
        Me.TextBox9.TabIndex = 20
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(262, 118)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 21
        Me.Button11.Text = "Clear"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "PreReq"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(77, 90)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(23, 23)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = ".."
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(106, 92)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(152, 23)
        Me.TextBox8.TabIndex = 17
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(262, 92)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 18
        Me.Button9.Text = "Clear"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PreReq"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(77, 64)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(23, 23)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = ".."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Enabled = False
        Me.TextBox7.Location = New System.Drawing.Point(106, 66)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(152, 23)
        Me.TextBox7.TabIndex = 14
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(262, 66)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "Clear"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PreReq"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(77, 38)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = ".."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(106, 40)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(152, 23)
        Me.TextBox6.TabIndex = 11
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(262, 40)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Clear"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "PreReq"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(77, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = ".."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(106, 14)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(152, 23)
        Me.TextBox4.TabIndex = 8
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(262, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chkMajor
        '
        Me.chkMajor.AutoSize = True
        Me.chkMajor.Location = New System.Drawing.Point(121, 76)
        Me.chkMajor.Name = "chkMajor"
        Me.chkMajor.Size = New System.Drawing.Size(60, 19)
        Me.chkMajor.TabIndex = 35
        Me.chkMajor.Text = "Major"
        Me.chkMajor.UseVisualStyleBackColor = True
        '
        'txtLabunits
        '
        Me.txtLabunits.Location = New System.Drawing.Point(121, 127)
        Me.txtLabunits.Name = "txtLabunits"
        Me.txtLabunits.Size = New System.Drawing.Size(100, 23)
        Me.txtLabunits.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(39, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Lab units"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(121, 101)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 23)
        Me.TextBox3.TabIndex = 37
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(121, 55)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(317, 23)
        Me.TextBox2.TabIndex = 34
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(121, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(39, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Tuition Units"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(125, 224)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(313, 94)
        Me.TextBox5.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(39, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(39, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Abbrev"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRem
        '
        Me.lblRem.Location = New System.Drawing.Point(43, 227)
        Me.lblRem.Name = "lblRem"
        Me.lblRem.Size = New System.Drawing.Size(57, 13)
        Me.lblRem.TabIndex = 38
        Me.lblRem.Text = "Remarks"
        Me.lblRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SubjectsBindingSource
        '
        Me.SubjectsBindingSource.DataMember = "Subjects"
        Me.SubjectsBindingSource.DataSource = Me.DsSchool
        '
        'SubjectsTableAdapter
        '
        Me.SubjectsTableAdapter.ClearBeforeFill = True
        '
        'TextBoxRLEUnits
        '
        Me.TextBoxRLEUnits.Location = New System.Drawing.Point(357, 131)
        Me.TextBoxRLEUnits.Name = "TextBoxRLEUnits"
        Me.TextBoxRLEUnits.Size = New System.Drawing.Size(81, 23)
        Me.TextBoxRLEUnits.TabIndex = 42
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(278, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "RLE Units"
        '
        'frmSubjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(470, 411)
        Me.Controls.Add(Me.TextBoxRLEUnits)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkMajor)
        Me.Controls.Add(Me.txtLabunits)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRem)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSubjects"
        Me.Text = "Configure a Subject"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chkMajor As System.Windows.Forms.CheckBox
    Friend WithEvents txtLabunits As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRem As System.Windows.Forms.Label
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents SubjectsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectsTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsTableAdapter
    Friend WithEvents TextBoxRLEUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
