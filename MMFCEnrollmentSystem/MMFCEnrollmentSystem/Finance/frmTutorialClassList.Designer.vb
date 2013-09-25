<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTutorialClassList
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DsRep = New MMFCEnrollmentSystem.dsRep
        Me.ClassListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StudentNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CourseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxStudentShare = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBoxSubjectUnits = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxTuitionFee = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxSubjectCost = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxEnrolledTotalCost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxBalanceToBeShared = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(490, 337)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StudentNameDataGridViewTextBoxColumn, Me.CourseDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClassListBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(482, 314)
        Me.DataGridView1.TabIndex = 0
        '
        'DsRep
        '
        Me.DsRep.DataSetName = "dsRep"
        Me.DsRep.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClassListBindingSource
        '
        Me.ClassListBindingSource.DataMember = "ClassList"
        Me.ClassListBindingSource.DataSource = Me.DsRep
        '
        'StudentNameDataGridViewTextBoxColumn
        '
        Me.StudentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName"
        Me.StudentNameDataGridViewTextBoxColumn.HeaderText = "Student Name"
        Me.StudentNameDataGridViewTextBoxColumn.Name = "StudentNameDataGridViewTextBoxColumn"
        Me.StudentNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.StudentNameDataGridViewTextBoxColumn.Width = 240
        '
        'CourseDataGridViewTextBoxColumn
        '
        Me.CourseDataGridViewTextBoxColumn.DataPropertyName = "Course"
        Me.CourseDataGridViewTextBoxColumn.HeaderText = "Course"
        Me.CourseDataGridViewTextBoxColumn.Name = "CourseDataGridViewTextBoxColumn"
        Me.CourseDataGridViewTextBoxColumn.ReadOnly = True
        Me.CourseDataGridViewTextBoxColumn.Width = 160
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 454)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Each Student Share :"
        '
        'TextBoxStudentShare
        '
        Me.TextBoxStudentShare.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxStudentShare.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxStudentShare.Location = New System.Drawing.Point(166, 448)
        Me.TextBoxStudentShare.Name = "TextBoxStudentShare"
        Me.TextBoxStudentShare.ReadOnly = True
        Me.TextBoxStudentShare.Size = New System.Drawing.Size(104, 26)
        Me.TextBoxStudentShare.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 448)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Confirm Charges"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBoxSubjectUnits
        '
        Me.TextBoxSubjectUnits.BackColor = System.Drawing.Color.White
        Me.TextBoxSubjectUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubjectUnits.Location = New System.Drawing.Point(166, 344)
        Me.TextBoxSubjectUnits.Name = "TextBoxSubjectUnits"
        Me.TextBoxSubjectUnits.ReadOnly = True
        Me.TextBoxSubjectUnits.Size = New System.Drawing.Size(104, 26)
        Me.TextBoxSubjectUnits.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 350)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Subject Units"
        '
        'TextBoxTuitionFee
        '
        Me.TextBoxTuitionFee.BackColor = System.Drawing.Color.White
        Me.TextBoxTuitionFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTuitionFee.Location = New System.Drawing.Point(375, 344)
        Me.TextBoxTuitionFee.Name = "TextBoxTuitionFee"
        Me.TextBoxTuitionFee.ReadOnly = True
        Me.TextBoxTuitionFee.Size = New System.Drawing.Size(107, 26)
        Me.TextBoxTuitionFee.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 350)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tuition Fee"
        '
        'TextBoxSubjectCost
        '
        Me.TextBoxSubjectCost.BackColor = System.Drawing.Color.White
        Me.TextBoxSubjectCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubjectCost.Location = New System.Drawing.Point(166, 376)
        Me.TextBoxSubjectCost.Name = "TextBoxSubjectCost"
        Me.TextBoxSubjectCost.ReadOnly = True
        Me.TextBoxSubjectCost.Size = New System.Drawing.Size(104, 26)
        Me.TextBoxSubjectCost.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 379)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 26)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Minimum Student " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Subject Cost:"
        '
        'TextBoxEnrolledTotalCost
        '
        Me.TextBoxEnrolledTotalCost.BackColor = System.Drawing.Color.White
        Me.TextBoxEnrolledTotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxEnrolledTotalCost.Location = New System.Drawing.Point(375, 376)
        Me.TextBoxEnrolledTotalCost.Name = "TextBoxEnrolledTotalCost"
        Me.TextBoxEnrolledTotalCost.ReadOnly = True
        Me.TextBoxEnrolledTotalCost.Size = New System.Drawing.Size(107, 26)
        Me.TextBoxEnrolledTotalCost.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(277, 376)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 26)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Enrolled Student " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Paid Cost:"
        '
        'TextBoxBalanceToBeShared
        '
        Me.TextBoxBalanceToBeShared.BackColor = System.Drawing.Color.White
        Me.TextBoxBalanceToBeShared.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxBalanceToBeShared.Location = New System.Drawing.Point(166, 408)
        Me.TextBoxBalanceToBeShared.Name = "TextBoxBalanceToBeShared"
        Me.TextBoxBalanceToBeShared.ReadOnly = True
        Me.TextBoxBalanceToBeShared.Size = New System.Drawing.Size(104, 26)
        Me.TextBoxBalanceToBeShared.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 415)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Balance to be Shared"
        '
        'frmTutorialClassList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(490, 487)
        Me.Controls.Add(Me.TextBoxBalanceToBeShared)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxEnrolledTotalCost)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxSubjectCost)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxTuitionFee)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxSubjectUnits)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxStudentShare)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmTutorialClassList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Class List"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StudentNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CourseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRep As MMFCEnrollmentSystem.dsRep
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxStudentShare As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxSubjectUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTuitionFee As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubjectCost As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEnrolledTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBalanceToBeShared As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
