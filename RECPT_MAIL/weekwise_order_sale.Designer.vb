<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class weekwise_order_sale
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
        Me.btn_go = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.rad_region_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_orgwise_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_product_groupwise_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_customer_wise_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_order = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_org_order_receipt = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_order_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_org_order_ofd = New System.Windows.Forms.RadioButton()
        Me.rad_region_ord = New System.Windows.Forms.RadioButton()
        Me.Rad_org_ord = New System.Windows.Forms.RadioButton()
        Me.rad_product_group_ord = New System.Windows.Forms.RadioButton()
        Me.Rad_cust_ord = New System.Windows.Forms.RadioButton()
        Me.Rad_ofd_order_pending = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OFD_date_from = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rad_delivery_rating = New System.Windows.Forms.RadioButton()
        Me.Rad_FIFO_consolid = New System.Windows.Forms.RadioButton()
        Me.Rad_FIFO_brk = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rad_active_oa_pending = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.yesterday_ord_ofd = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.yesterday_date = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.Chocolate
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.ForeColor = System.Drawing.Color.White
        Me.btn_go.Location = New System.Drawing.Point(651, 0)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(104, 50)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "View Detail"
        Me.btn_go.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
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
        Me.dgv1.Location = New System.Drawing.Point(9, 138)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1179, 352)
        Me.dgv1.TabIndex = 2
        '
        'rad_region_ofd
        '
        Me.rad_region_ofd.AutoSize = True
        Me.rad_region_ofd.Checked = True
        Me.rad_region_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_region_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_region_ofd.Location = New System.Drawing.Point(12, 10)
        Me.rad_region_ofd.Name = "rad_region_ofd"
        Me.rad_region_ofd.Size = New System.Drawing.Size(130, 17)
        Me.rad_region_ofd.TabIndex = 3
        Me.rad_region_ofd.TabStop = True
        Me.rad_region_ofd.Text = "Region-Wise  OFD"
        Me.rad_region_ofd.UseVisualStyleBackColor = True
        '
        'rad_orgwise_ofd
        '
        Me.rad_orgwise_ofd.AutoSize = True
        Me.rad_orgwise_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_orgwise_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_orgwise_ofd.Location = New System.Drawing.Point(181, 10)
        Me.rad_orgwise_ofd.Name = "rad_orgwise_ofd"
        Me.rad_orgwise_ofd.Size = New System.Drawing.Size(106, 17)
        Me.rad_orgwise_ofd.TabIndex = 3
        Me.rad_orgwise_ofd.Text = "Org Wise OFD"
        Me.rad_orgwise_ofd.UseVisualStyleBackColor = True
        '
        'rad_product_groupwise_ofd
        '
        Me.rad_product_groupwise_ofd.AutoSize = True
        Me.rad_product_groupwise_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_product_groupwise_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_product_groupwise_ofd.Location = New System.Drawing.Point(319, 10)
        Me.rad_product_groupwise_ofd.Name = "rad_product_groupwise_ofd"
        Me.rad_product_groupwise_ofd.Size = New System.Drawing.Size(168, 17)
        Me.rad_product_groupwise_ofd.TabIndex = 3
        Me.rad_product_groupwise_ofd.Text = "Product Group Wise OFD"
        Me.rad_product_groupwise_ofd.UseVisualStyleBackColor = True
        '
        'rad_customer_wise_ofd
        '
        Me.rad_customer_wise_ofd.AutoSize = True
        Me.rad_customer_wise_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_customer_wise_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_customer_wise_ofd.Location = New System.Drawing.Point(501, 10)
        Me.rad_customer_wise_ofd.Name = "rad_customer_wise_ofd"
        Me.rad_customer_wise_ofd.Size = New System.Drawing.Size(138, 17)
        Me.rad_customer_wise_ofd.TabIndex = 3
        Me.rad_customer_wise_ofd.Text = "Customer Wise OFD"
        Me.rad_customer_wise_ofd.UseVisualStyleBackColor = True
        '
        'rad_dealer_order
        '
        Me.rad_dealer_order.AutoSize = True
        Me.rad_dealer_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer_order.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_dealer_order.Location = New System.Drawing.Point(889, 10)
        Me.rad_dealer_order.Name = "rad_dealer_order"
        Me.rad_dealer_order.Size = New System.Drawing.Size(257, 17)
        Me.rad_dealer_order.TabIndex = 3
        Me.rad_dealer_order.Text = "Dealer -Wise  Order Receipt (order Date)"
        Me.rad_dealer_order.UseVisualStyleBackColor = True
        '
        'rad_dealer_org_order_receipt
        '
        Me.rad_dealer_org_order_receipt.AutoSize = True
        Me.rad_dealer_org_order_receipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer_org_order_receipt.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_dealer_org_order_receipt.Location = New System.Drawing.Point(889, 33)
        Me.rad_dealer_org_order_receipt.Name = "rad_dealer_org_order_receipt"
        Me.rad_dealer_org_order_receipt.Size = New System.Drawing.Size(240, 17)
        Me.rad_dealer_org_order_receipt.TabIndex = 3
        Me.rad_dealer_org_order_receipt.Text = "Org -Wise Order Receipt  (order Date)"
        Me.rad_dealer_org_order_receipt.UseVisualStyleBackColor = True
        '
        'rad_dealer_order_ofd
        '
        Me.rad_dealer_order_ofd.AutoSize = True
        Me.rad_dealer_order_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer_order_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_dealer_order_ofd.Location = New System.Drawing.Point(889, 62)
        Me.rad_dealer_order_ofd.Name = "rad_dealer_order_ofd"
        Me.rad_dealer_order_ofd.Size = New System.Drawing.Size(257, 17)
        Me.rad_dealer_order_ofd.TabIndex = 3
        Me.rad_dealer_order_ofd.Text = "Dealer -Wise Order Receipt (Order_ff_dt)"
        Me.rad_dealer_order_ofd.UseVisualStyleBackColor = True
        '
        'rad_dealer_org_order_ofd
        '
        Me.rad_dealer_org_order_ofd.AutoSize = True
        Me.rad_dealer_org_order_ofd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer_org_order_ofd.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_dealer_org_order_ofd.Location = New System.Drawing.Point(889, 85)
        Me.rad_dealer_org_order_ofd.Name = "rad_dealer_org_order_ofd"
        Me.rad_dealer_org_order_ofd.Size = New System.Drawing.Size(281, 17)
        Me.rad_dealer_org_order_ofd.TabIndex = 3
        Me.rad_dealer_org_order_ofd.Text = "Org -Wise Dealer Order Receipt (Order_ff_dt)"
        Me.rad_dealer_org_order_ofd.UseVisualStyleBackColor = True
        '
        'rad_region_ord
        '
        Me.rad_region_ord.AutoSize = True
        Me.rad_region_ord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_region_ord.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_region_ord.Location = New System.Drawing.Point(12, 33)
        Me.rad_region_ord.Name = "rad_region_ord"
        Me.rad_region_ord.Size = New System.Drawing.Size(134, 17)
        Me.rad_region_ord.TabIndex = 3
        Me.rad_region_ord.Text = "Region-Wise OrdDt"
        Me.rad_region_ord.UseVisualStyleBackColor = True
        '
        'Rad_org_ord
        '
        Me.Rad_org_ord.AutoSize = True
        Me.Rad_org_ord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_org_ord.ForeColor = System.Drawing.Color.OrangeRed
        Me.Rad_org_ord.Location = New System.Drawing.Point(181, 33)
        Me.Rad_org_ord.Name = "Rad_org_ord"
        Me.Rad_org_ord.Size = New System.Drawing.Size(114, 17)
        Me.Rad_org_ord.TabIndex = 3
        Me.Rad_org_ord.Text = "Org Wise OrdDt"
        Me.Rad_org_ord.UseVisualStyleBackColor = True
        '
        'rad_product_group_ord
        '
        Me.rad_product_group_ord.AutoSize = True
        Me.rad_product_group_ord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_product_group_ord.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_product_group_ord.Location = New System.Drawing.Point(319, 33)
        Me.rad_product_group_ord.Name = "rad_product_group_ord"
        Me.rad_product_group_ord.Size = New System.Drawing.Size(176, 17)
        Me.rad_product_group_ord.TabIndex = 3
        Me.rad_product_group_ord.Text = "Product Group Wise OrdDt"
        Me.rad_product_group_ord.UseVisualStyleBackColor = True
        '
        'Rad_cust_ord
        '
        Me.Rad_cust_ord.AutoSize = True
        Me.Rad_cust_ord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_cust_ord.ForeColor = System.Drawing.Color.OrangeRed
        Me.Rad_cust_ord.Location = New System.Drawing.Point(501, 33)
        Me.Rad_cust_ord.Name = "Rad_cust_ord"
        Me.Rad_cust_ord.Size = New System.Drawing.Size(144, 17)
        Me.Rad_cust_ord.TabIndex = 3
        Me.Rad_cust_ord.Text = "Customer Wise Orddt"
        Me.Rad_cust_ord.UseVisualStyleBackColor = True
        '
        'Rad_ofd_order_pending
        '
        Me.Rad_ofd_order_pending.AutoSize = True
        Me.Rad_ofd_order_pending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_ofd_order_pending.ForeColor = System.Drawing.Color.OrangeRed
        Me.Rad_ofd_order_pending.Location = New System.Drawing.Point(12, 56)
        Me.Rad_ofd_order_pending.Name = "Rad_ofd_order_pending"
        Me.Rad_ofd_order_pending.Size = New System.Drawing.Size(211, 17)
        Me.Rad_ofd_order_pending.TabIndex = 3
        Me.Rad_ofd_order_pending.Text = "Region-Wise OFD Order Pending"
        Me.Rad_ofd_order_pending.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "OFD Date From :"
        '
        'OFD_date_from
        '
        Me.OFD_date_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.OFD_date_from.Location = New System.Drawing.Point(118, 17)
        Me.OFD_date_from.Name = "OFD_date_from"
        Me.OFD_date_from.Size = New System.Drawing.Size(113, 20)
        Me.OFD_date_from.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OFD_date_from)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Rad_delivery_rating)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(477, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 39)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dealer Product Group  wise Delivery Rating"
        '
        'Rad_delivery_rating
        '
        Me.Rad_delivery_rating.AutoSize = True
        Me.Rad_delivery_rating.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_delivery_rating.ForeColor = System.Drawing.Color.OrangeRed
        Me.Rad_delivery_rating.Location = New System.Drawing.Point(235, 18)
        Me.Rad_delivery_rating.Name = "Rad_delivery_rating"
        Me.Rad_delivery_rating.Size = New System.Drawing.Size(112, 17)
        Me.Rad_delivery_rating.TabIndex = 3
        Me.Rad_delivery_rating.Text = "Delivery Rating"
        Me.Rad_delivery_rating.UseVisualStyleBackColor = True
        '
        'Rad_FIFO_consolid
        '
        Me.Rad_FIFO_consolid.AutoSize = True
        Me.Rad_FIFO_consolid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_FIFO_consolid.ForeColor = System.Drawing.Color.SteelBlue
        Me.Rad_FIFO_consolid.Location = New System.Drawing.Point(229, 56)
        Me.Rad_FIFO_consolid.Name = "Rad_FIFO_consolid"
        Me.Rad_FIFO_consolid.Size = New System.Drawing.Size(169, 17)
        Me.Rad_FIFO_consolid.TabIndex = 3
        Me.Rad_FIFO_consolid.Text = "Stock FIFO Consolidation"
        Me.Rad_FIFO_consolid.UseVisualStyleBackColor = True
        '
        'Rad_FIFO_brk
        '
        Me.Rad_FIFO_brk.AutoSize = True
        Me.Rad_FIFO_brk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_FIFO_brk.ForeColor = System.Drawing.Color.SteelBlue
        Me.Rad_FIFO_brk.Location = New System.Drawing.Point(229, 75)
        Me.Rad_FIFO_brk.Name = "Rad_FIFO_brk"
        Me.Rad_FIFO_brk.Size = New System.Drawing.Size(140, 17)
        Me.Rad_FIFO_brk.TabIndex = 3
        Me.Rad_FIFO_brk.Text = "Stock FIFO Breakup"
        Me.Rad_FIFO_brk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(13, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'rad_active_oa_pending
        '
        Me.rad_active_oa_pending.AutoSize = True
        Me.rad_active_oa_pending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_active_oa_pending.ForeColor = System.Drawing.Color.OrangeRed
        Me.rad_active_oa_pending.Location = New System.Drawing.Point(12, 105)
        Me.rad_active_oa_pending.Name = "rad_active_oa_pending"
        Me.rad_active_oa_pending.Size = New System.Drawing.Size(356, 17)
        Me.rad_active_oa_pending.TabIndex = 3
        Me.rad_active_oa_pending.Text = "Active OA Pending for Yesterterday and  Before Yesterday"
        Me.rad_active_oa_pending.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.yesterday_ord_ofd)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.yesterday_date)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(404, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(527, 39)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Yesterday order Receipt"
        Me.GroupBox2.Visible = False
        '
        'yesterday_ord_ofd
        '
        Me.yesterday_ord_ofd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.yesterday_ord_ofd.Location = New System.Drawing.Point(388, 16)
        Me.yesterday_ord_ofd.Name = "yesterday_ord_ofd"
        Me.yesterday_ord_ofd.Size = New System.Drawing.Size(113, 20)
        Me.yesterday_ord_ofd.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(316, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "OFD upto :"
        '
        'yesterday_date
        '
        Me.yesterday_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.yesterday_date.Location = New System.Drawing.Point(173, 16)
        Me.yesterday_date.Name = "yesterday_date"
        Me.yesterday_date.Size = New System.Drawing.Size(113, 20)
        Me.yesterday_date.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Last Order Receipt Date :"
        '
        'weekwise_order_sale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1195, 499)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rad_dealer_org_order_ofd)
        Me.Controls.Add(Me.rad_dealer_order_ofd)
        Me.Controls.Add(Me.rad_dealer_org_order_receipt)
        Me.Controls.Add(Me.rad_dealer_order)
        Me.Controls.Add(Me.Rad_cust_ord)
        Me.Controls.Add(Me.rad_customer_wise_ofd)
        Me.Controls.Add(Me.rad_product_group_ord)
        Me.Controls.Add(Me.rad_product_groupwise_ofd)
        Me.Controls.Add(Me.Rad_org_ord)
        Me.Controls.Add(Me.rad_orgwise_ofd)
        Me.Controls.Add(Me.Rad_FIFO_brk)
        Me.Controls.Add(Me.Rad_FIFO_consolid)
        Me.Controls.Add(Me.rad_active_oa_pending)
        Me.Controls.Add(Me.Rad_ofd_order_pending)
        Me.Controls.Add(Me.rad_region_ord)
        Me.Controls.Add(Me.rad_region_ofd)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "weekwise_order_sale"
        Me.Text = "Weekwise Order & Sale"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_go As Button
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents rad_region_ofd As RadioButton
    Friend WithEvents rad_orgwise_ofd As RadioButton
    Friend WithEvents rad_product_groupwise_ofd As RadioButton
    Friend WithEvents rad_customer_wise_ofd As RadioButton
    Friend WithEvents rad_dealer_order As RadioButton
    Friend WithEvents rad_dealer_org_order_receipt As RadioButton
    Friend WithEvents rad_dealer_order_ofd As RadioButton
    Friend WithEvents rad_dealer_org_order_ofd As RadioButton
    Friend WithEvents rad_region_ord As RadioButton
    Friend WithEvents Rad_org_ord As RadioButton
    Friend WithEvents rad_product_group_ord As RadioButton
    Friend WithEvents Rad_cust_ord As RadioButton
    Friend WithEvents Rad_ofd_order_pending As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents OFD_date_from As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rad_delivery_rating As RadioButton
    Friend WithEvents Rad_FIFO_consolid As RadioButton
    Friend WithEvents Rad_FIFO_brk As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents rad_active_oa_pending As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents yesterday_date As DateTimePicker
    Friend WithEvents Label3 As Label
    Private WithEvents yesterday_ord_ofd As DateTimePicker
    Private WithEvents Label4 As Label
End Class
