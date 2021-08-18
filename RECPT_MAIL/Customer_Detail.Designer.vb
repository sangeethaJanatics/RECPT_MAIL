<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customer_Detail
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.reg_combo = New System.Windows.Forms.ComboBox()
        Me.btn_show = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Rad_oracle_customer = New System.Windows.Forms.RadioButton()
        Me.Rad_sale_as_base = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "File Location : customer details.html in D drive"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Region"
        '
        'reg_combo
        '
        Me.reg_combo.FormattingEnabled = True
        Me.reg_combo.Location = New System.Drawing.Point(109, 32)
        Me.reg_combo.Name = "reg_combo"
        Me.reg_combo.Size = New System.Drawing.Size(121, 21)
        Me.reg_combo.TabIndex = 12
        '
        'btn_show
        '
        Me.btn_show.Location = New System.Drawing.Point(109, 131)
        Me.btn_show.Name = "btn_show"
        Me.btn_show.Size = New System.Drawing.Size(215, 32)
        Me.btn_show.TabIndex = 11
        Me.btn_show.Text = "Show Customer Details"
        Me.btn_show.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(274, 65)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker2.TabIndex = 9
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(109, 67)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From"
        '
        'Rad_oracle_customer
        '
        Me.Rad_oracle_customer.AutoSize = True
        Me.Rad_oracle_customer.Checked = True
        Me.Rad_oracle_customer.Location = New System.Drawing.Point(99, 104)
        Me.Rad_oracle_customer.Name = "Rad_oracle_customer"
        Me.Rad_oracle_customer.Size = New System.Drawing.Size(152, 17)
        Me.Rad_oracle_customer.TabIndex = 15
        Me.Rad_oracle_customer.TabStop = True
        Me.Rad_oracle_customer.Text = "Based on Customer Master"
        Me.Rad_oracle_customer.UseVisualStyleBackColor = True
        '
        'Rad_sale_as_base
        '
        Me.Rad_sale_as_base.AutoSize = True
        Me.Rad_sale_as_base.Location = New System.Drawing.Point(276, 104)
        Me.Rad_sale_as_base.Name = "Rad_sale_as_base"
        Me.Rad_sale_as_base.Size = New System.Drawing.Size(99, 17)
        Me.Rad_sale_as_base.TabIndex = 15
        Me.Rad_sale_as_base.Text = "Based on Sales"
        Me.Rad_sale_as_base.UseVisualStyleBackColor = True
        '
        'Customer_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(534, 196)
        Me.Controls.Add(Me.Rad_sale_as_base)
        Me.Controls.Add(Me.Rad_oracle_customer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.reg_combo)
        Me.Controls.Add(Me.btn_show)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Customer_Detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Detail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents reg_combo As ComboBox
    Friend WithEvents btn_show As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Rad_oracle_customer As RadioButton
    Friend WithEvents Rad_sale_as_base As RadioButton
End Class
