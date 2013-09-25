<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChargeSchedule
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
        Me.chkAllYearLevel = New System.Windows.Forms.CheckBox
        Me.chkAllCourses = New System.Windows.Forms.CheckBox
        Me.cmbYrLevel = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkTransferee = New System.Windows.Forms.CheckBox
        Me.chkNewStudent = New System.Windows.Forms.CheckBox
        Me.chkOldStudent = New System.Windows.Forms.CheckBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSortKey = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtCharge = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCourseName = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAllYearLevel
        '
        Me.chkAllYearLevel.AutoSize = True
        Me.chkAllYearLevel.Location = New System.Drawing.Point(127, 359)
        Me.chkAllYearLevel.Name = "chkAllYearLevel"
        Me.chkAllYearLevel.Size = New System.Drawing.Size(152, 19)
        Me.chkAllYearLevel.TabIndex = 36
        Me.chkAllYearLevel.Text = "Apply to All Year Levels"
        Me.chkAllYearLevel.UseVisualStyleBackColor = True
        '
        'chkAllCourses
        '
        Me.chkAllCourses.AutoSize = True
        Me.chkAllCourses.Location = New System.Drawing.Point(127, 301)
        Me.chkAllCourses.Name = "chkAllCourses"
        Me.chkAllCourses.Size = New System.Drawing.Size(136, 19)
        Me.chkAllCourses.TabIndex = 34
        Me.chkAllCourses.Text = "Apply to All Courses"
        Me.chkAllCourses.UseVisualStyleBackColor = True
        '
        'cmbYrLevel
        '
        Me.cmbYrLevel.DisplayMember = "CourseName"
        Me.cmbYrLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYrLevel.FormattingEnabled = True
        Me.cmbYrLevel.Location = New System.Drawing.Point(121, 332)
        Me.cmbYrLevel.Name = "cmbYrLevel"
        Me.cmbYrLevel.Size = New System.Drawing.Size(288, 23)
        Me.cmbYrLevel.TabIndex = 35
        Me.cmbYrLevel.ValueMember = "coursepk"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 335)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Yr Level"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Course"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkTransferee)
        Me.GroupBox1.Controls.Add(Me.chkNewStudent)
        Me.GroupBox1.Controls.Add(Me.chkOldStudent)
        Me.GroupBox1.Location = New System.Drawing.Point(121, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 91)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Apply Charge To ( you can check all )"
        '
        'chkTransferee
        '
        Me.chkTransferee.AutoSize = True
        Me.chkTransferee.Location = New System.Drawing.Point(6, 65)
        Me.chkTransferee.Name = "chkTransferee"
        Me.chkTransferee.Size = New System.Drawing.Size(128, 19)
        Me.chkTransferee.TabIndex = 13
        Me.chkTransferee.Text = "Transferee Student"
        Me.chkTransferee.UseVisualStyleBackColor = True
        '
        'chkNewStudent
        '
        Me.chkNewStudent.AutoSize = True
        Me.chkNewStudent.Location = New System.Drawing.Point(6, 42)
        Me.chkNewStudent.Name = "chkNewStudent"
        Me.chkNewStudent.Size = New System.Drawing.Size(93, 19)
        Me.chkNewStudent.TabIndex = 12
        Me.chkNewStudent.Text = "New Student"
        Me.chkNewStudent.UseVisualStyleBackColor = True
        '
        'chkOldStudent
        '
        Me.chkOldStudent.AutoSize = True
        Me.chkOldStudent.Location = New System.Drawing.Point(6, 19)
        Me.chkOldStudent.Name = "chkOldStudent"
        Me.chkOldStudent.Size = New System.Drawing.Size(90, 19)
        Me.chkOldStudent.TabIndex = 11
        Me.chkOldStudent.Text = "Old Student"
        Me.chkOldStudent.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(121, 104)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(288, 55)
        Me.txtRemarks.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Remarks"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(121, 78)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 23)
        Me.txtAmount.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Amount"
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(121, 26)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(288, 23)
        Me.txtCategory.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Category"
        '
        'txtSortKey
        '
        Me.txtSortKey.Location = New System.Drawing.Point(121, 387)
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.Size = New System.Drawing.Size(288, 23)
        Me.txtSortKey.TabIndex = 37
        Me.txtSortKey.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Sort Key"
        Me.Label2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(334, 431)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCharge
        '
        Me.txtCharge.Location = New System.Drawing.Point(121, 52)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.Size = New System.Drawing.Size(288, 23)
        Me.txtCharge.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Charge Name"
        '
        'txtCourseName
        '
        Me.txtCourseName.Location = New System.Drawing.Point(155, 274)
        Me.txtCourseName.Name = "txtCourseName"
        Me.txtCourseName.ReadOnly = True
        Me.txtCourseName.Size = New System.Drawing.Size(254, 23)
        Me.txtCourseName.TabIndex = 42
        Me.txtCourseName.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(120, 275)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 23)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmChargeSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(460, 470)
        Me.Controls.Add(Me.txtCourseName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkAllYearLevel)
        Me.Controls.Add(Me.chkAllCourses)
        Me.Controls.Add(Me.cmbYrLevel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSortKey)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCharge)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmChargeSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure Charge Schedule Item"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkAllYearLevel As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllCourses As System.Windows.Forms.CheckBox
    Friend WithEvents cmbYrLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTransferee As System.Windows.Forms.CheckBox
    Friend WithEvents chkNewStudent As System.Windows.Forms.CheckBox
    Friend WithEvents chkOldStudent As System.Windows.Forms.CheckBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSortKey As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCourseName As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
