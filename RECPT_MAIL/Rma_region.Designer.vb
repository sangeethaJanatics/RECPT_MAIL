<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rma_region
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_go = New System.Windows.Forms.Button
        Me.branch_name_combo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.org_cmb = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_cust = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_item = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Region :"
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(255, 120)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(77, 23)
        Me.btn_go.TabIndex = 5
        Me.btn_go.Text = "Print Report"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'branch_name_combo
        '
        Me.branch_name_combo.FormattingEnabled = True
        Me.branch_name_combo.Location = New System.Drawing.Point(107, 93)
        Me.branch_name_combo.Name = "branch_name_combo"
        Me.branch_name_combo.Size = New System.Drawing.Size(129, 21)
        Me.branch_name_combo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(107, 58)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(216, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(242, 58)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(249, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Org"
        '
        'org_cmb
        '
        Me.org_cmb.FormattingEnabled = True
        Me.org_cmb.Items.AddRange(New Object() {"I01", "I02", "I03", "I04", "I05", "I06", "I07"})
        Me.org_cmb.Location = New System.Drawing.Point(276, 93)
        Me.org_cmb.Name = "org_cmb"
        Me.org_cmb.Size = New System.Drawing.Size(54, 21)
        Me.org_cmb.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Customer Name :"
        '
        'cmb_cust
        '
        Me.cmb_cust.FormattingEnabled = True
        Me.cmb_cust.Location = New System.Drawing.Point(107, 21)
        Me.cmb_cust.Name = "cmb_cust"
        Me.cmb_cust.Size = New System.Drawing.Size(227, 21)
        Me.cmb_cust.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Item No :"
        '
        'txt_item
        '
        Me.txt_item.Location = New System.Drawing.Point(108, 120)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.Size = New System.Drawing.Size(128, 20)
        Me.txt_item.TabIndex = 9
        '
        'Rma_region
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 154)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmb_cust)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.org_cmb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.branch_name_combo)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Rma_region"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RMA Region Wise"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents branch_name_combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents org_cmb As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_cust As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
End Class
