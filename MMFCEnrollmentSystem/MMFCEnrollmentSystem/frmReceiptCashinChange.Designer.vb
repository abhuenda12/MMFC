<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceiptCashinChange
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxCashin = New System.Windows.Forms.TextBox
        Me.TextBoxAmountDue = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxChange = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonPay = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cash-In"
        '
        'TextBoxCashin
        '
        Me.TextBoxCashin.BackColor = System.Drawing.Color.White
        Me.TextBoxCashin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCashin.Location = New System.Drawing.Point(169, 36)
        Me.TextBoxCashin.Name = "TextBoxCashin"
        Me.TextBoxCashin.Size = New System.Drawing.Size(141, 29)
        Me.TextBoxCashin.TabIndex = 1
        Me.TextBoxCashin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxAmountDue
        '
        Me.TextBoxAmountDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAmountDue.Location = New System.Drawing.Point(169, 95)
        Me.TextBoxAmountDue.Name = "TextBoxAmountDue"
        Me.TextBoxAmountDue.ReadOnly = True
        Me.TextBoxAmountDue.Size = New System.Drawing.Size(141, 29)
        Me.TextBoxAmountDue.TabIndex = 3
        Me.TextBoxAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Amount Due"
        '
        'TextBoxChange
        '
        Me.TextBoxChange.BackColor = System.Drawing.Color.White
        Me.TextBoxChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxChange.Location = New System.Drawing.Point(169, 159)
        Me.TextBoxChange.Name = "TextBoxChange"
        Me.TextBoxChange.ReadOnly = True
        Me.TextBoxChange.Size = New System.Drawing.Size(141, 29)
        Me.TextBoxChange.TabIndex = 5
        Me.TextBoxChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Change"
        '
        'ButtonPay
        '
        Me.ButtonPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPay.Location = New System.Drawing.Point(199, 236)
        Me.ButtonPay.Name = "ButtonPay"
        Me.ButtonPay.Size = New System.Drawing.Size(111, 34)
        Me.ButtonPay.TabIndex = 6
        Me.ButtonPay.Text = "OK"
        Me.ButtonPay.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(26, 236)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(111, 34)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'frmReceiptCashinChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(350, 298)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonPay)
        Me.Controls.Add(Me.TextBoxChange)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxAmountDue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxCashin)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReceiptCashinChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCashin As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAmountDue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxChange As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonPay As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
