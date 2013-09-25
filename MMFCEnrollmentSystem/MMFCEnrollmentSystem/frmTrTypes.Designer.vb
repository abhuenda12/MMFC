<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrTypes
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
        Me.chkCourse = New System.Windows.Forms.CheckBox
        Me.txtTRCode = New System.Windows.Forms.ComboBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkSubject = New System.Windows.Forms.CheckBox
        Me.chkYrlevel = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbEnrollYear = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTrName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCourseName = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtSubjectName = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboBoxStudentType = New System.Windows.Forms.ComboBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkCourse
        '
        Me.chkCourse.AutoSize = True
        Me.chkCourse.Location = New System.Drawing.Point(100, 129)
        Me.chkCourse.Name = "chkCourse"
        Me.chkCourse.Size = New System.Drawing.Size(143, 19)
        Me.chkCourse.TabIndex = 4
        Me.chkCourse.Text = "is not course specific"
        Me.chkCourse.UseVisualStyleBackColor = True
        '
        'txtTRCode
        '
        Me.txtTRCode.FormattingEnabled = True
        Me.txtTRCode.Items.AddRange(New Object() {"CHN KIT", "COMM. EXTENSION", "INTERNSHIP", "PHARAPHERNALIA", "RLE", "RLE REQUEST", "SCRUBSUIT", "TUITION"})
        Me.txtTRCode.Location = New System.Drawing.Point(100, 18)
        Me.txtTRCode.Name = "txtTRCode"
        Me.txtTRCode.Size = New System.Drawing.Size(330, 23)
        Me.txtTRCode.TabIndex = 1
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(100, 354)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(330, 78)
        Me.txtRemarks.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 355)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Remarks"
        '
        'chkSubject
        '
        Me.chkSubject.AutoSize = True
        Me.chkSubject.Location = New System.Drawing.Point(100, 234)
        Me.chkSubject.Name = "chkSubject"
        Me.chkSubject.Size = New System.Drawing.Size(146, 19)
        Me.chkSubject.TabIndex = 8
        Me.chkSubject.Text = "is not subject specific"
        Me.chkSubject.UseVisualStyleBackColor = True
        '
        'chkYrlevel
        '
        Me.chkYrlevel.AutoSize = True
        Me.chkYrlevel.Location = New System.Drawing.Point(100, 178)
        Me.chkYrlevel.Name = "chkYrlevel"
        Me.chkYrlevel.Size = New System.Drawing.Size(159, 19)
        Me.chkYrlevel.TabIndex = 6
        Me.chkYrlevel.Text = "is not year level specific"
        Me.chkYrlevel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Subject"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Yr Level"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Course"
        '
        'cmbEnrollYear
        '
        Me.cmbEnrollYear.FormattingEnabled = True
        Me.cmbEnrollYear.Location = New System.Drawing.Point(100, 151)
        Me.cmbEnrollYear.Name = "cmbEnrollYear"
        Me.cmbEnrollYear.Size = New System.Drawing.Size(330, 23)
        Me.cmbEnrollYear.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(274, 459)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(100, 321)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 23)
        Me.txtAmount.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Amount"
        '
        'txtTrName
        '
        Me.txtTrName.Location = New System.Drawing.Point(100, 51)
        Me.txtTrName.Name = "txtTrName"
        Me.txtTrName.Size = New System.Drawing.Size(330, 23)
        Me.txtTrName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Desc"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Code"
        '
        'txtCourseName
        '
        Me.txtCourseName.Location = New System.Drawing.Point(130, 83)
        Me.txtCourseName.Multiline = True
        Me.txtCourseName.Name = "txtCourseName"
        Me.txtCourseName.ReadOnly = True
        Me.txtCourseName.Size = New System.Drawing.Size(300, 40)
        Me.txtCourseName.TabIndex = 44
        Me.txtCourseName.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(95, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtSubjectName
        '
        Me.txtSubjectName.Location = New System.Drawing.Point(130, 208)
        Me.txtSubjectName.Name = "txtSubjectName"
        Me.txtSubjectName.ReadOnly = True
        Me.txtSubjectName.Size = New System.Drawing.Size(300, 23)
        Me.txtSubjectName.TabIndex = 46
        Me.txtSubjectName.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(95, 209)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 30)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Student" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Type"
        '
        'ComboBoxStudentType
        '
        Me.ComboBoxStudentType.FormattingEnabled = True
        Me.ComboBoxStudentType.Items.AddRange(New Object() {"ALL", "NEW", "OLD", "TRN"})
        Me.ComboBoxStudentType.Location = New System.Drawing.Point(100, 273)
        Me.ComboBoxStudentType.Name = "ComboBoxStudentType"
        Me.ComboBoxStudentType.Size = New System.Drawing.Size(330, 23)
        Me.ComboBoxStudentType.TabIndex = 9
        '
        'Button4
        '
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.Location = New System.Drawing.Point(355, 459)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "&Close"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'frmTrTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.CancelButton = Me.Button4
        Me.ClientSize = New System.Drawing.Size(452, 494)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ComboBoxStudentType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSubjectName)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtCourseName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkCourse)
        Me.Controls.Add(Me.txtTRCode)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkSubject)
        Me.Controls.Add(Me.chkYrlevel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbEnrollYear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTrName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTrTypes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure Transaction Type Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCourse As System.Windows.Forms.CheckBox
    Friend WithEvents txtTRCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkSubject As System.Windows.Forms.CheckBox
    Friend WithEvents chkYrlevel As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbEnrollYear As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTrName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCourseName As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtSubjectName As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxStudentType As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
