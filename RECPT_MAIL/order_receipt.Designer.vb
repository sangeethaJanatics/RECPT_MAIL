<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class order_receipt
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.rad_order_recd = New System.Windows.Forms.RadioButton()
        Me.rad_order_penidng = New System.Windows.Forms.RadioButton()
        Me.rad_outstanding = New System.Windows.Forms.RadioButton()
        Me.rad_sales = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RAD_DEALER_ORDER = New System.Windows.Forms.RadioButton()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.dgv_break = New System.Windows.Forms.DataGridView()
        Me.chk_order_pending = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rad_order_receipt_detailed = New System.Windows.Forms.RadioButton()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_order_receipt = New System.Windows.Forms.Button()
        Me.chk_dealer_order = New System.Windows.Forms.CheckBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_break, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.DimGray
        Me.dgv.Location = New System.Drawing.Point(6, 59)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1169, 215)
        Me.dgv.TabIndex = 0
        '
        'rad_order_recd
        '
        Me.rad_order_recd.AutoSize = True
        Me.rad_order_recd.Checked = True
        Me.rad_order_recd.Location = New System.Drawing.Point(7, 18)
        Me.rad_order_recd.Name = "rad_order_recd"
        Me.rad_order_recd.Size = New System.Drawing.Size(104, 17)
        Me.rad_order_recd.TabIndex = 0
        Me.rad_order_recd.TabStop = True
        Me.rad_order_recd.Text = "Order Receipt"
        Me.rad_order_recd.UseVisualStyleBackColor = True
        '
        'rad_order_penidng
        '
        Me.rad_order_penidng.AutoSize = True
        Me.rad_order_penidng.Location = New System.Drawing.Point(111, 18)
        Me.rad_order_penidng.Name = "rad_order_penidng"
        Me.rad_order_penidng.Size = New System.Drawing.Size(106, 17)
        Me.rad_order_penidng.TabIndex = 0
        Me.rad_order_penidng.Text = "Order Pending"
        Me.rad_order_penidng.UseVisualStyleBackColor = True
        '
        'rad_outstanding
        '
        Me.rad_outstanding.AutoSize = True
        Me.rad_outstanding.Location = New System.Drawing.Point(219, 31)
        Me.rad_outstanding.Name = "rad_outstanding"
        Me.rad_outstanding.Size = New System.Drawing.Size(93, 17)
        Me.rad_outstanding.TabIndex = 0
        Me.rad_outstanding.Text = "Outstanding"
        Me.rad_outstanding.UseVisualStyleBackColor = True
        '
        'rad_sales
        '
        Me.rad_sales.AutoSize = True
        Me.rad_sales.Location = New System.Drawing.Point(219, 10)
        Me.rad_sales.Name = "rad_sales"
        Me.rad_sales.Size = New System.Drawing.Size(56, 17)
        Me.rad_sales.TabIndex = 0
        Me.rad_sales.Text = "Sales"
        Me.rad_sales.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RAD_DEALER_ORDER)
        Me.GroupBox1.Controls.Add(Me.rad_sales)
        Me.GroupBox1.Controls.Add(Me.rad_outstanding)
        Me.GroupBox1.Controls.Add(Me.rad_order_penidng)
        Me.GroupBox1.Controls.Add(Me.rad_order_recd)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details of "
        '
        'RAD_DEALER_ORDER
        '
        Me.RAD_DEALER_ORDER.AutoSize = True
        Me.RAD_DEALER_ORDER.Location = New System.Drawing.Point(328, 13)
        Me.RAD_DEALER_ORDER.Name = "RAD_DEALER_ORDER"
        Me.RAD_DEALER_ORDER.Size = New System.Drawing.Size(157, 17)
        Me.RAD_DEALER_ORDER.TabIndex = 1
        Me.RAD_DEALER_ORDER.Text = "Dealer Order currnet Yr"
        Me.RAD_DEALER_ORDER.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(527, 23)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(43, 23)
        Me.btn_go.TabIndex = 2
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'dgv_break
        '
        Me.dgv_break.AllowUserToAddRows = False
        Me.dgv_break.AllowUserToDeleteRows = False
        Me.dgv_break.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_break.BackgroundColor = System.Drawing.Color.White
        Me.dgv_break.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_break.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_break.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_break.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_break.EnableHeadersVisualStyles = False
        Me.dgv_break.GridColor = System.Drawing.Color.DimGray
        Me.dgv_break.Location = New System.Drawing.Point(5, 280)
        Me.dgv_break.Name = "dgv_break"
        Me.dgv_break.ReadOnly = True
        Me.dgv_break.Size = New System.Drawing.Size(1169, 232)
        Me.dgv_break.TabIndex = 0
        '
        'chk_order_pending
        '
        Me.chk_order_pending.AutoSize = True
        Me.chk_order_pending.Location = New System.Drawing.Point(576, 27)
        Me.chk_order_pending.Name = "chk_order_pending"
        Me.chk_order_pending.Size = New System.Drawing.Size(134, 17)
        Me.chk_order_pending.TabIndex = 3
        Me.chk_order_pending.Text = "Order Upto Last Month"
        Me.chk_order_pending.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox2.Controls.Add(Me.chk_dealer_order)
        Me.GroupBox2.Controls.Add(Me.rad_order_receipt_detailed)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btn_order_receipt)
        Me.GroupBox2.Location = New System.Drawing.Point(708, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(467, 56)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Order Receipt"
        '
        'rad_order_receipt_detailed
        '
        Me.rad_order_receipt_detailed.AutoSize = True
        Me.rad_order_receipt_detailed.Checked = True
        Me.rad_order_receipt_detailed.Location = New System.Drawing.Point(222, 15)
        Me.rad_order_receipt_detailed.Name = "rad_order_receipt_detailed"
        Me.rad_order_receipt_detailed.Size = New System.Drawing.Size(133, 17)
        Me.rad_order_receipt_detailed.TabIndex = 7
        Me.rad_order_receipt_detailed.TabStop = True
        Me.rad_order_receipt_detailed.Text = "Order Receipt Detailed"
        Me.rad_order_receipt_detailed.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(120, 32)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(92, 20)
        Me.DateTimePicker2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To Dt :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(120, 11)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(92, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "From Dt :"
        '
        'btn_order_receipt
        '
        Me.btn_order_receipt.Location = New System.Drawing.Point(396, 9)
        Me.btn_order_receipt.Name = "btn_order_receipt"
        Me.btn_order_receipt.Size = New System.Drawing.Size(65, 42)
        Me.btn_order_receipt.TabIndex = 2
        Me.btn_order_receipt.Text = "view order"
        Me.btn_order_receipt.UseVisualStyleBackColor = True
        '
        'chk_dealer_order
        '
        Me.chk_dealer_order.AutoSize = True
        Me.chk_dealer_order.Location = New System.Drawing.Point(265, 37)
        Me.chk_dealer_order.Name = "chk_dealer_order"
        Me.chk_dealer_order.Size = New System.Drawing.Size(106, 17)
        Me.chk_dealer_order.TabIndex = 8
        Me.chk_dealer_order.Text = "Dealer order only"
        Me.chk_dealer_order.UseVisualStyleBackColor = True
        '
        'order_receipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1186, 515)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chk_order_pending)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_break)
        Me.Controls.Add(Me.dgv)
        Me.Name = "order_receipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order Receipt  value  --Customer Category"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_break, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents rad_outstanding As System.Windows.Forms.RadioButton
    Friend WithEvents rad_order_penidng As System.Windows.Forms.RadioButton
    Friend WithEvents rad_order_recd As System.Windows.Forms.RadioButton
    Friend WithEvents rad_sales As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents dgv_break As System.Windows.Forms.DataGridView
    Friend WithEvents chk_order_pending As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_order_receipt As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents rad_order_receipt_detailed As RadioButton
    Friend WithEvents RAD_DEALER_ORDER As RadioButton
    Friend WithEvents chk_dealer_order As CheckBox
End Class
