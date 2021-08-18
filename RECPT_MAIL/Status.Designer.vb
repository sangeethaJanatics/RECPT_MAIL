<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Status
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
        Me.Rd1 = New System.Windows.Forms.RadioButton
        Me.Rd2 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.receipt = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmborder = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.inwdtf = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.inwdtto = New System.Windows.Forms.DateTimePicker
        Me.rd3 = New System.Windows.Forms.RadioButton
        Me.rd4 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdser = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmborg = New System.Windows.Forms.ComboBox
        Me.rd6 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rd5 = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txtrole = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Rd1
        '
        Me.Rd1.AutoSize = True
        Me.Rd1.Checked = True
        Me.Rd1.Location = New System.Drawing.Point(4, 16)
        Me.Rd1.Name = "Rd1"
        Me.Rd1.Size = New System.Drawing.Size(36, 17)
        Me.Rd1.TabIndex = 0
        Me.Rd1.TabStop = True
        Me.Rd1.Text = "All"
        Me.Rd1.UseVisualStyleBackColor = True
        '
        'Rd2
        '
        Me.Rd2.AutoSize = True
        Me.Rd2.Location = New System.Drawing.Point(40, 16)
        Me.Rd2.Name = "Rd2"
        Me.Rd2.Size = New System.Drawing.Size(111, 17)
        Me.Rd2.TabIndex = 0
        Me.Rd2.Text = "Matching Pending"
        Me.Rd2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.receipt)
        Me.GroupBox1.Controls.Add(Me.Rd1)
        Me.GroupBox1.Controls.Add(Me.Rd2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 39)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'receipt
        '
        Me.receipt.AutoSize = True
        Me.receipt.Location = New System.Drawing.Point(150, 16)
        Me.receipt.Name = "receipt"
        Me.receipt.Size = New System.Drawing.Size(104, 17)
        Me.receipt.TabIndex = 15
        Me.receipt.TabStop = True
        Me.receipt.Text = "Receipt Pending"
        Me.receipt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Order by"
        '
        'cmborder
        '
        Me.cmborder.FormattingEnabled = True
        Me.cmborder.Items.AddRange(New Object() {"Gate No", "Supplier"})
        Me.cmborder.Location = New System.Drawing.Point(127, 75)
        Me.cmborder.Name = "cmborder"
        Me.cmborder.Size = New System.Drawing.Size(100, 21)
        Me.cmborder.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(209, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(279, 130)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(82, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "From"
        '
        'inwdtf
        '
        Me.inwdtf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.inwdtf.Location = New System.Drawing.Point(127, 49)
        Me.inwdtf.Name = "inwdtf"
        Me.inwdtf.Size = New System.Drawing.Size(100, 20)
        Me.inwdtf.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(233, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "To"
        '
        'inwdtto
        '
        Me.inwdtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.inwdtto.Location = New System.Drawing.Point(279, 51)
        Me.inwdtto.Name = "inwdtto"
        Me.inwdtto.Size = New System.Drawing.Size(100, 20)
        Me.inwdtto.TabIndex = 6
        '
        'rd3
        '
        Me.rd3.AutoSize = True
        Me.rd3.Checked = True
        Me.rd3.Location = New System.Drawing.Point(5, 16)
        Me.rd3.Name = "rd3"
        Me.rd3.Size = New System.Drawing.Size(40, 17)
        Me.rd3.TabIndex = 1
        Me.rd3.TabStop = True
        Me.rd3.Text = "PO"
        Me.rd3.UseVisualStyleBackColor = True
        '
        'rd4
        '
        Me.rd4.AutoSize = True
        Me.rd4.Location = New System.Drawing.Point(43, 16)
        Me.rd4.Name = "rd4"
        Me.rd4.Size = New System.Drawing.Size(47, 17)
        Me.rd4.TabIndex = 1
        Me.rd4.TabStop = True
        Me.rd4.Text = "OSP"
        Me.rd4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdser)
        Me.GroupBox2.Controls.Add(Me.rd4)
        Me.GroupBox2.Controls.Add(Me.rd3)
        Me.GroupBox2.Location = New System.Drawing.Point(273, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 39)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'rdser
        '
        Me.rdser.AutoSize = True
        Me.rdser.Location = New System.Drawing.Point(87, 16)
        Me.rdser.Name = "rdser"
        Me.rdser.Size = New System.Drawing.Size(61, 17)
        Me.rdser.TabIndex = 2
        Me.rdser.TabStop = True
        Me.rdser.Text = "Service"
        Me.rdser.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Delivered", "Not Delivered"})
        Me.ComboBox1.Location = New System.Drawing.Point(279, 76)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(232, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Search"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 148)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ProgressBar1.TabIndex = 9
        Me.ProgressBar1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Org"
        '
        'cmborg
        '
        Me.cmborg.FormattingEnabled = True
        Me.cmborg.Location = New System.Drawing.Point(125, 102)
        Me.cmborg.Name = "cmborg"
        Me.cmborg.Size = New System.Drawing.Size(102, 21)
        Me.cmborg.TabIndex = 10
        '
        'rd6
        '
        Me.rd6.AutoSize = True
        Me.rd6.Location = New System.Drawing.Point(75, 16)
        Me.rd6.Name = "rd6"
        Me.rd6.Size = New System.Drawing.Size(64, 17)
        Me.rd6.TabIndex = 11
        Me.rd6.Text = "Detailed"
        Me.rd6.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rd5)
        Me.GroupBox3.Controls.Add(Me.rd6)
        Me.GroupBox3.Location = New System.Drawing.Point(439, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(141, 39)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'rd5
        '
        Me.rd5.AutoSize = True
        Me.rd5.Checked = True
        Me.rd5.Location = New System.Drawing.Point(7, 16)
        Me.rd5.Name = "rd5"
        Me.rd5.Size = New System.Drawing.Size(68, 17)
        Me.rd5.TabIndex = 11
        Me.rd5.TabStop = True
        Me.rd5.Text = "Summary"
        Me.rd5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(385, 76)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Visible = False
        '
        'txtrole
        '
        Me.txtrole.Location = New System.Drawing.Point(384, 50)
        Me.txtrole.Name = "txtrole"
        Me.txtrole.Size = New System.Drawing.Size(100, 20)
        Me.txtrole.TabIndex = 14
        Me.txtrole.Visible = False
        '
        'Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(582, 185)
        Me.Controls.Add(Me.txtrole)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmborg)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.inwdtto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.inwdtf)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmborder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Status"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gate Register-Status"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmborder As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents inwdtf As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents inwdtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents rd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rd4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmborg As System.Windows.Forms.ComboBox
    Friend WithEvents rd6 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rd5 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtrole As System.Windows.Forms.TextBox
    Friend WithEvents receipt As System.Windows.Forms.RadioButton
    Friend WithEvents rdser As System.Windows.Forms.RadioButton
End Class
