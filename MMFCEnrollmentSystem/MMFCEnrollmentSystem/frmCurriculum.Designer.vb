<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurriculum
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
        Me.cmbSubject = New System.Windows.Forms.ComboBox
        Me.SubjectsorderedbyNameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSchool = New MMFCEnrollmentSystem.dsSchool
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbSemester = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbYrLevel = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbCourse = New System.Windows.Forms.ComboBox
        Me.CoursesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.CoursesTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.CoursesTableAdapter
        Me.SubjectsorderedbyNameTableAdapter = New MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsorderedbyNameTableAdapter
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtSubjectName = New System.Windows.Forms.TextBox
        CType(Me.SubjectsorderedbyNameBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoursesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbSubject
        '
        Me.cmbSubject.DataSource = Me.SubjectsorderedbyNameBindingSource
        Me.cmbSubject.DisplayMember = "SubjectName"
        Me.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubject.FormattingEnabled = True
        Me.cmbSubject.Location = New System.Drawing.Point(418, 90)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(41, 23)
        Me.cmbSubject.TabIndex = 4
        Me.cmbSubject.ValueMember = "SubjectPriKey"
        Me.cmbSubject.Visible = False
        '
        'SubjectsorderedbyNameBindingSource
        '
        Me.SubjectsorderedbyNameBindingSource.DataMember = "SubjectsorderedbyName"
        Me.SubjectsorderedbyNameBindingSource.DataSource = Me.DsSchool
        '
        'DsSchool
        '
        Me.DsSchool.DataSetName = "dsSchool"
        Me.DsSchool.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Subject"
        '
        'cmbSemester
        '
        Me.cmbSemester.DisplayMember = "CourseName"
        Me.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSemester.FormattingEnabled = True
        Me.cmbSemester.Items.AddRange(New Object() {"First", "Second", "Summer"})
        Me.cmbSemester.Location = New System.Drawing.Point(78, 89)
        Me.cmbSemester.Name = "cmbSemester"
        Me.cmbSemester.Size = New System.Drawing.Size(196, 23)
        Me.cmbSemester.TabIndex = 3
        Me.cmbSemester.ValueMember = "coursepk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Semester"
        '
        'cmbYrLevel
        '
        Me.cmbYrLevel.DisplayMember = "CourseName"
        Me.cmbYrLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYrLevel.FormattingEnabled = True
        Me.cmbYrLevel.Items.AddRange(New Object() {"1st", "2nd", "3rd", "4th", "5th", "6th"})
        Me.cmbYrLevel.Location = New System.Drawing.Point(78, 62)
        Me.cmbYrLevel.Name = "cmbYrLevel"
        Me.cmbYrLevel.Size = New System.Drawing.Size(196, 23)
        Me.cmbYrLevel.TabIndex = 2
        Me.cmbYrLevel.ValueMember = "coursepk"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Yr Level"
        '
        'cmbCourse
        '
        Me.cmbCourse.DataSource = Me.CoursesBindingSource
        Me.cmbCourse.DisplayMember = "CourseName"
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(78, 35)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(381, 23)
        Me.cmbCourse.TabIndex = 1
        Me.cmbCourse.ValueMember = "coursepk"
        '
        'CoursesBindingSource
        '
        Me.CoursesBindingSource.DataMember = "Courses"
        Me.CoursesBindingSource.DataSource = Me.DsSchool
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Course"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(78, 153)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(381, 82)
        Me.txtRemarks.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Remarks"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(384, 269)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CoursesTableAdapter
        '
        Me.CoursesTableAdapter.ClearBeforeFill = True
        '
        'SubjectsorderedbyNameTableAdapter
        '
        Me.SubjectsorderedbyNameTableAdapter.ClearBeforeFill = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(78, 122)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 23)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtSubjectName
        '
        Me.txtSubjectName.Location = New System.Drawing.Point(113, 121)
        Me.txtSubjectName.Name = "txtSubjectName"
        Me.txtSubjectName.ReadOnly = True
        Me.txtSubjectName.Size = New System.Drawing.Size(346, 23)
        Me.txtSubjectName.TabIndex = 39
        Me.txtSubjectName.TabStop = False
        '
        'frmCurriculum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(491, 330)
        Me.Controls.Add(Me.txtSubjectName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmbSubject)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSemester)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbYrLevel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCurriculum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure a Curriculum Subject"
        CType(Me.SubjectsorderedbyNameBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSchool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoursesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSemester As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbYrLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DsSchool As MMFCEnrollmentSystem.dsSchool
    Friend WithEvents CoursesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CoursesTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.CoursesTableAdapter
    Friend WithEvents SubjectsorderedbyNameBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectsorderedbyNameTableAdapter As MMFCEnrollmentSystem.dsSchoolTableAdapters.SubjectsorderedbyNameTableAdapter
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtSubjectName As System.Windows.Forms.TextBox
End Class
