<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sale_Detail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.From_date = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.To_date = New System.Windows.Forms.DateTimePicker()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.chk_monthwise = New System.Windows.Forms.CheckBox()
        Me.chk_item_wise = New System.Windows.Forms.CheckBox()
        Me.chk_customer_wise = New System.Windows.Forms.CheckBox()
        Me.CHK_REGION_WISE = New System.Windows.Forms.CheckBox()
        Me.chk_daywise = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rad_cust_cat_all = New System.Windows.Forms.RadioButton()
        Me.Rad_customer = New System.Windows.Forms.RadioButton()
        Me.rad_dealer = New System.Windows.Forms.RadioButton()
        Me.chk_category = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_yearwise = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_customer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_part_no = New System.Windows.Forms.TextBox()
        Me.rad_sale_qty = New System.Windows.Forms.RadioButton()
        Me.rad_sale_val = New System.Windows.Forms.RadioButton()
        Me.Rad_order_receipt = New System.Windows.Forms.RadioButton()
        Me.rad_order_sale_form2 = New System.Windows.Forms.RadioButton()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From Date :"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.EnableHeadersVisualStyles = False
        Me.dgv1.Location = New System.Drawing.Point(25, 159)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(890, 314)
        Me.dgv1.TabIndex = 1
        '
        'From_date
        '
        Me.From_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_date.Location = New System.Drawing.Point(99, 13)
        Me.From_date.Name = "From_date"
        Me.From_date.Size = New System.Drawing.Size(102, 20)
        Me.From_date.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(223, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To Date :"
        '
        'To_date
        '
        Me.To_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.To_date.Location = New System.Drawing.Point(289, 13)
        Me.To_date.Name = "To_date"
        Me.To_date.Size = New System.Drawing.Size(102, 20)
        Me.To_date.TabIndex = 2
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.Crimson
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.ForeColor = System.Drawing.Color.White
        Me.btn_go.Location = New System.Drawing.Point(406, 12)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(54, 23)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = False
        '
        'chk_monthwise
        '
        Me.chk_monthwise.AutoSize = True
        Me.chk_monthwise.Location = New System.Drawing.Point(149, 19)
        Me.chk_monthwise.Name = "chk_monthwise"
        Me.chk_monthwise.Size = New System.Drawing.Size(83, 17)
        Me.chk_monthwise.TabIndex = 4
        Me.chk_monthwise.Text = "Month Wise"
        Me.chk_monthwise.UseVisualStyleBackColor = True
        '
        'chk_item_wise
        '
        Me.chk_item_wise.AutoSize = True
        Me.chk_item_wise.Location = New System.Drawing.Point(201, 19)
        Me.chk_item_wise.Name = "chk_item_wise"
        Me.chk_item_wise.Size = New System.Drawing.Size(73, 17)
        Me.chk_item_wise.TabIndex = 4
        Me.chk_item_wise.Text = "Item Wise"
        Me.chk_item_wise.UseVisualStyleBackColor = True
        '
        'chk_customer_wise
        '
        Me.chk_customer_wise.AutoSize = True
        Me.chk_customer_wise.Location = New System.Drawing.Point(5, 19)
        Me.chk_customer_wise.Name = "chk_customer_wise"
        Me.chk_customer_wise.Size = New System.Drawing.Size(97, 17)
        Me.chk_customer_wise.TabIndex = 4
        Me.chk_customer_wise.Text = "Customer Wise"
        Me.chk_customer_wise.UseVisualStyleBackColor = True
        '
        'CHK_REGION_WISE
        '
        Me.CHK_REGION_WISE.AutoSize = True
        Me.CHK_REGION_WISE.Location = New System.Drawing.Point(108, 19)
        Me.CHK_REGION_WISE.Name = "CHK_REGION_WISE"
        Me.CHK_REGION_WISE.Size = New System.Drawing.Size(87, 17)
        Me.CHK_REGION_WISE.TabIndex = 4
        Me.CHK_REGION_WISE.Text = "Region Wise"
        Me.CHK_REGION_WISE.UseVisualStyleBackColor = True
        '
        'chk_daywise
        '
        Me.chk_daywise.AutoSize = True
        Me.chk_daywise.Location = New System.Drawing.Point(56, 19)
        Me.chk_daywise.Name = "chk_daywise"
        Me.chk_daywise.Size = New System.Drawing.Size(72, 17)
        Me.chk_daywise.TabIndex = 4
        Me.chk_daywise.Text = "Day Wise"
        Me.chk_daywise.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_item_wise)
        Me.GroupBox1.Controls.Add(Me.rad_cust_cat_all)
        Me.GroupBox1.Controls.Add(Me.Rad_customer)
        Me.GroupBox1.Controls.Add(Me.rad_dealer)
        Me.GroupBox1.Controls.Add(Me.CHK_REGION_WISE)
        Me.GroupBox1.Controls.Add(Me.chk_category)
        Me.GroupBox1.Controls.Add(Me.chk_customer_wise)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox1.Location = New System.Drawing.Point(25, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 80)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Any One Option (or with category wise option)"
        '
        'rad_cust_cat_all
        '
        Me.rad_cust_cat_all.AutoSize = True
        Me.rad_cust_cat_all.Checked = True
        Me.rad_cust_cat_all.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cust_cat_all.Location = New System.Drawing.Point(226, 61)
        Me.rad_cust_cat_all.Name = "rad_cust_cat_all"
        Me.rad_cust_cat_all.Size = New System.Drawing.Size(39, 17)
        Me.rad_cust_cat_all.TabIndex = 9
        Me.rad_cust_cat_all.TabStop = True
        Me.rad_cust_cat_all.Text = "All"
        Me.rad_cust_cat_all.UseVisualStyleBackColor = True
        '
        'Rad_customer
        '
        Me.Rad_customer.AutoSize = True
        Me.Rad_customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_customer.Location = New System.Drawing.Point(116, 60)
        Me.Rad_customer.Name = "Rad_customer"
        Me.Rad_customer.Size = New System.Drawing.Size(104, 17)
        Me.Rad_customer.TabIndex = 9
        Me.Rad_customer.Text = "Customer only"
        Me.Rad_customer.UseVisualStyleBackColor = True
        '
        'rad_dealer
        '
        Me.rad_dealer.AutoSize = True
        Me.rad_dealer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer.Location = New System.Drawing.Point(8, 60)
        Me.rad_dealer.Name = "rad_dealer"
        Me.rad_dealer.Size = New System.Drawing.Size(97, 17)
        Me.rad_dealer.TabIndex = 9
        Me.rad_dealer.Text = "Dealers Only"
        Me.rad_dealer.UseVisualStyleBackColor = True
        '
        'chk_category
        '
        Me.chk_category.AutoSize = True
        Me.chk_category.Location = New System.Drawing.Point(6, 42)
        Me.chk_category.Name = "chk_category"
        Me.chk_category.Size = New System.Drawing.Size(188, 17)
        Me.chk_category.TabIndex = 4
        Me.chk_category.Text = "Customer && Dealer(Category Wise)"
        Me.chk_category.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_yearwise)
        Me.GroupBox2.Controls.Add(Me.chk_monthwise)
        Me.GroupBox2.Controls.Add(Me.chk_daywise)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox2.Location = New System.Drawing.Point(364, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 44)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Any One Option"
        '
        'chk_yearwise
        '
        Me.chk_yearwise.AutoSize = True
        Me.chk_yearwise.Location = New System.Drawing.Point(238, 19)
        Me.chk_yearwise.Name = "chk_yearwise"
        Me.chk_yearwise.Size = New System.Drawing.Size(75, 17)
        Me.chk_yearwise.TabIndex = 4
        Me.chk_yearwise.Text = "Year Wise"
        Me.chk_yearwise.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(22, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer Name:"
        '
        'cmb_customer
        '
        Me.cmb_customer.FormattingEnabled = True
        Me.cmb_customer.Location = New System.Drawing.Point(125, 36)
        Me.cmb_customer.Name = "cmb_customer"
        Me.cmb_customer.Size = New System.Drawing.Size(335, 21)
        Me.cmb_customer.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Crimson
        Me.Label4.Location = New System.Drawing.Point(466, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Part No:"
        '
        'txt_part_no
        '
        Me.txt_part_no.Location = New System.Drawing.Point(526, 36)
        Me.txt_part_no.Name = "txt_part_no"
        Me.txt_part_no.Size = New System.Drawing.Size(135, 20)
        Me.txt_part_no.TabIndex = 8
        '
        'rad_sale_qty
        '
        Me.rad_sale_qty.AutoSize = True
        Me.rad_sale_qty.Checked = True
        Me.rad_sale_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_sale_qty.Location = New System.Drawing.Point(352, 113)
        Me.rad_sale_qty.Name = "rad_sale_qty"
        Me.rad_sale_qty.Size = New System.Drawing.Size(101, 17)
        Me.rad_sale_qty.TabIndex = 9
        Me.rad_sale_qty.TabStop = True
        Me.rad_sale_qty.Text = "Sale Quantity"
        Me.rad_sale_qty.UseVisualStyleBackColor = True
        '
        'rad_sale_val
        '
        Me.rad_sale_val.AutoSize = True
        Me.rad_sale_val.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_sale_val.Location = New System.Drawing.Point(456, 113)
        Me.rad_sale_val.Name = "rad_sale_val"
        Me.rad_sale_val.Size = New System.Drawing.Size(86, 17)
        Me.rad_sale_val.TabIndex = 9
        Me.rad_sale_val.Text = "Sale Value"
        Me.rad_sale_val.UseVisualStyleBackColor = True
        '
        'Rad_order_receipt
        '
        Me.Rad_order_receipt.AutoSize = True
        Me.Rad_order_receipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_order_receipt.Location = New System.Drawing.Point(552, 113)
        Me.Rad_order_receipt.Name = "Rad_order_receipt"
        Me.Rad_order_receipt.Size = New System.Drawing.Size(266, 17)
        Me.Rad_order_receipt.TabIndex = 9
        Me.Rad_order_receipt.Text = "Order  Receipt and Sale  -- with order type"
        Me.Rad_order_receipt.UseVisualStyleBackColor = True
        '
        'rad_order_sale_form2
        '
        Me.rad_order_sale_form2.AutoSize = True
        Me.rad_order_sale_form2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_order_sale_form2.Location = New System.Drawing.Point(552, 136)
        Me.rad_order_sale_form2.Name = "rad_order_sale_form2"
        Me.rad_order_sale_form2.Size = New System.Drawing.Size(257, 17)
        Me.rad_order_sale_form2.TabIndex = 9
        Me.rad_order_sale_form2.Text = "Order  Receipt and Sale  (Form II Added)"
        Me.rad_order_sale_form2.UseVisualStyleBackColor = True
        '
        'Sale_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(907, 461)
        Me.Controls.Add(Me.rad_order_sale_form2)
        Me.Controls.Add(Me.Rad_order_receipt)
        Me.Controls.Add(Me.rad_sale_val)
        Me.Controls.Add(Me.rad_sale_qty)
        Me.Controls.Add(Me.txt_part_no)
        Me.Controls.Add(Me.cmb_customer)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.To_date)
        Me.Controls.Add(Me.From_date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Sale_Detail"
        Me.Text = "Sale_Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents From_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents To_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents chk_monthwise As System.Windows.Forms.CheckBox
    Friend WithEvents chk_item_wise As System.Windows.Forms.CheckBox
    Friend WithEvents chk_customer_wise As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_REGION_WISE As System.Windows.Forms.CheckBox
    Friend WithEvents chk_daywise As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_category As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_customer As System.Windows.Forms.ComboBox
    Friend WithEvents chk_yearwise As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_part_no As TextBox
    Friend WithEvents rad_sale_qty As RadioButton
    Friend WithEvents rad_sale_val As RadioButton
    Friend WithEvents Rad_customer As RadioButton
    Friend WithEvents rad_dealer As RadioButton
    Friend WithEvents rad_cust_cat_all As RadioButton
    Friend WithEvents Rad_order_receipt As RadioButton
    Friend WithEvents rad_order_sale_form2 As RadioButton
End Class
