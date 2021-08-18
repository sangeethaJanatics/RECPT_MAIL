<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Login_mktg
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txt_username As System.Windows.Forms.TextBox
    Friend WithEvents txt_pwd As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login_mktg))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.txt_pwd = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.link_mktg_review_detail = New System.Windows.Forms.LinkLabel()
        Me.link_mktg_mrm = New System.Windows.Forms.LinkLabel()
        Me.Link_Dealer_order_status = New System.Windows.Forms.LinkLabel()
        Me.Link_bin_addition = New System.Windows.Forms.LinkLabel()
        Me.Link_non_moving_item_stock = New System.Windows.Forms.LinkLabel()
        Me.Link_ofd_orderpending = New System.Windows.Forms.LinkLabel()
        Me.Link_new_cust_billto_shipto = New System.Windows.Forms.LinkLabel()
        Me.Link_order_cancelation = New System.Windows.Forms.LinkLabel()
        Me.Link_sale_detail = New System.Windows.Forms.LinkLabel()
        Me.Link_non_tod_items = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.link_ofd_date_change = New System.Windows.Forms.LinkLabel()
        Me.Link_customer_detail = New System.Windows.Forms.LinkLabel()
        Me.link_view_price_list = New System.Windows.Forms.LinkLabel()
        Me.link_branch_price_rev = New System.Windows.Forms.LinkLabel()
        Me.Link_LPD = New System.Windows.Forms.LinkLabel()
        Me.Link_TOD_Non_TOD_items = New System.Windows.Forms.LinkLabel()
        Me.link_weekwise_ord_pend = New System.Windows.Forms.LinkLabel()
        Me.link_inter_region_flush = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.link_sale_cyr_lyr = New System.Windows.Forms.LinkLabel()
        Me.link_Dealer_target = New System.Windows.Forms.LinkLabel()
        Me.link_dds_req = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Link_price_add = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_ORDER_RECEIPT = New System.Windows.Forms.LinkLabel()
        Me.Link_order_sale_OS = New System.Windows.Forms.LinkLabel()
        Me.Link_new_price_addition = New System.Windows.Forms.LinkLabel()
        Me.Link_sales_KPI = New System.Windows.Forms.LinkLabel()
        Me.link_us_sale = New System.Windows.Forms.LinkLabel()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(303, 193)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Location = New System.Drawing.Point(326, 10)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Location = New System.Drawing.Point(326, 67)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_username
        '
        Me.txt_username.Location = New System.Drawing.Point(328, 30)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(220, 20)
        Me.txt_username.TabIndex = 1
        '
        'txt_pwd
        '
        Me.txt_pwd.Location = New System.Drawing.Point(328, 87)
        Me.txt_pwd.Name = "txt_pwd"
        Me.txt_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pwd.Size = New System.Drawing.Size(220, 20)
        Me.txt_pwd.TabIndex = 3
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(351, 147)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&OK"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(454, 147)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancel"
        '
        'link_mktg_review_detail
        '
        Me.link_mktg_review_detail.AutoSize = True
        Me.link_mktg_review_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_mktg_review_detail.LinkColor = System.Drawing.Color.SaddleBrown
        Me.link_mktg_review_detail.Location = New System.Drawing.Point(5, 41)
        Me.link_mktg_review_detail.Name = "link_mktg_review_detail"
        Me.link_mktg_review_detail.Size = New System.Drawing.Size(131, 13)
        Me.link_mktg_review_detail.TabIndex = 6
        Me.link_mktg_review_detail.TabStop = True
        Me.link_mktg_review_detail.Text = "MKTG Review Details"
        '
        'link_mktg_mrm
        '
        Me.link_mktg_mrm.AutoSize = True
        Me.link_mktg_mrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_mktg_mrm.LinkColor = System.Drawing.Color.SaddleBrown
        Me.link_mktg_mrm.Location = New System.Drawing.Point(5, 68)
        Me.link_mktg_mrm.Name = "link_mktg_mrm"
        Me.link_mktg_mrm.Size = New System.Drawing.Size(75, 13)
        Me.link_mktg_mrm.TabIndex = 6
        Me.link_mktg_mrm.TabStop = True
        Me.link_mktg_mrm.Text = "MKTG MRM"
        '
        'Link_Dealer_order_status
        '
        Me.Link_Dealer_order_status.AutoSize = True
        Me.Link_Dealer_order_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_Dealer_order_status.LinkColor = System.Drawing.Color.MidnightBlue
        Me.Link_Dealer_order_status.Location = New System.Drawing.Point(145, 30)
        Me.Link_Dealer_order_status.Name = "Link_Dealer_order_status"
        Me.Link_Dealer_order_status.Size = New System.Drawing.Size(119, 13)
        Me.Link_Dealer_order_status.TabIndex = 6
        Me.Link_Dealer_order_status.TabStop = True
        Me.Link_Dealer_order_status.Text = "Dealer Order Status"
        '
        'Link_bin_addition
        '
        Me.Link_bin_addition.AutoSize = True
        Me.Link_bin_addition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_bin_addition.LinkColor = System.Drawing.Color.MidnightBlue
        Me.Link_bin_addition.Location = New System.Drawing.Point(145, 56)
        Me.Link_bin_addition.Name = "Link_bin_addition"
        Me.Link_bin_addition.Size = New System.Drawing.Size(75, 13)
        Me.Link_bin_addition.TabIndex = 6
        Me.Link_bin_addition.TabStop = True
        Me.Link_bin_addition.Text = "Bin Addition"
        '
        'Link_non_moving_item_stock
        '
        Me.Link_non_moving_item_stock.AutoSize = True
        Me.Link_non_moving_item_stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_non_moving_item_stock.LinkColor = System.Drawing.Color.MidnightBlue
        Me.Link_non_moving_item_stock.Location = New System.Drawing.Point(145, 82)
        Me.Link_non_moving_item_stock.Name = "Link_non_moving_item_stock"
        Me.Link_non_moving_item_stock.Size = New System.Drawing.Size(140, 13)
        Me.Link_non_moving_item_stock.TabIndex = 6
        Me.Link_non_moving_item_stock.TabStop = True
        Me.Link_non_moving_item_stock.Text = "Non Moving Item Stock"
        '
        'Link_ofd_orderpending
        '
        Me.Link_ofd_orderpending.AutoSize = True
        Me.Link_ofd_orderpending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_ofd_orderpending.LinkColor = System.Drawing.Color.Crimson
        Me.Link_ofd_orderpending.Location = New System.Drawing.Point(329, 5)
        Me.Link_ofd_orderpending.Name = "Link_ofd_orderpending"
        Me.Link_ofd_orderpending.Size = New System.Drawing.Size(117, 13)
        Me.Link_ofd_orderpending.TabIndex = 6
        Me.Link_ofd_orderpending.TabStop = True
        Me.Link_ofd_orderpending.Text = "OFD Order Pending"
        '
        'Link_new_cust_billto_shipto
        '
        Me.Link_new_cust_billto_shipto.AutoSize = True
        Me.Link_new_cust_billto_shipto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_new_cust_billto_shipto.LinkColor = System.Drawing.Color.Crimson
        Me.Link_new_cust_billto_shipto.Location = New System.Drawing.Point(329, 24)
        Me.Link_new_cust_billto_shipto.Name = "Link_new_cust_billto_shipto"
        Me.Link_new_cust_billto_shipto.Size = New System.Drawing.Size(178, 13)
        Me.Link_new_cust_billto_shipto.TabIndex = 6
        Me.Link_new_cust_billto_shipto.TabStop = True
        Me.Link_new_cust_billto_shipto.Text = "New Customer Bill TO Ship To"
        '
        'Link_order_cancelation
        '
        Me.Link_order_cancelation.AutoSize = True
        Me.Link_order_cancelation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_order_cancelation.LinkColor = System.Drawing.Color.Crimson
        Me.Link_order_cancelation.Location = New System.Drawing.Point(329, 42)
        Me.Link_order_cancelation.Name = "Link_order_cancelation"
        Me.Link_order_cancelation.Size = New System.Drawing.Size(124, 13)
        Me.Link_order_cancelation.TabIndex = 6
        Me.Link_order_cancelation.TabStop = True
        Me.Link_order_cancelation.Text = "Order Cancel Details"
        '
        'Link_sale_detail
        '
        Me.Link_sale_detail.AutoSize = True
        Me.Link_sale_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_sale_detail.LinkColor = System.Drawing.Color.Crimson
        Me.Link_sale_detail.Location = New System.Drawing.Point(329, 63)
        Me.Link_sale_detail.Name = "Link_sale_detail"
        Me.Link_sale_detail.Size = New System.Drawing.Size(75, 13)
        Me.Link_sale_detail.TabIndex = 6
        Me.Link_sale_detail.TabStop = True
        Me.Link_sale_detail.Text = "Sale Details"
        '
        'Link_non_tod_items
        '
        Me.Link_non_tod_items.AutoSize = True
        Me.Link_non_tod_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_non_tod_items.LinkColor = System.Drawing.Color.Crimson
        Me.Link_non_tod_items.Location = New System.Drawing.Point(329, 84)
        Me.Link_non_tod_items.Name = "Link_non_tod_items"
        Me.Link_non_tod_items.Size = New System.Drawing.Size(98, 13)
        Me.Link_non_tod_items.TabIndex = 6
        Me.Link_non_tod_items.TabStop = True
        Me.Link_non_tod_items.Text = "NON TOD Items"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.link_ofd_date_change)
        Me.Panel1.Controls.Add(Me.Link_customer_detail)
        Me.Panel1.Controls.Add(Me.link_view_price_list)
        Me.Panel1.Controls.Add(Me.link_branch_price_rev)
        Me.Panel1.Controls.Add(Me.Link_sale_detail)
        Me.Panel1.Controls.Add(Me.Link_LPD)
        Me.Panel1.Controls.Add(Me.Link_TOD_Non_TOD_items)
        Me.Panel1.Controls.Add(Me.link_mktg_mrm)
        Me.Panel1.Controls.Add(Me.link_mktg_review_detail)
        Me.Panel1.Controls.Add(Me.link_weekwise_ord_pend)
        Me.Panel1.Controls.Add(Me.link_inter_region_flush)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.link_sale_cyr_lyr)
        Me.Panel1.Controls.Add(Me.Link_non_moving_item_stock)
        Me.Panel1.Controls.Add(Me.Link_Dealer_order_status)
        Me.Panel1.Controls.Add(Me.Link_bin_addition)
        Me.Panel1.Controls.Add(Me.link_Dealer_target)
        Me.Panel1.Controls.Add(Me.link_dds_req)
        Me.Panel1.Controls.Add(Me.Link_ofd_orderpending)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.Link_price_add)
        Me.Panel1.Controls.Add(Me.LinkLabel_ORDER_RECEIPT)
        Me.Panel1.Controls.Add(Me.Link_order_sale_OS)
        Me.Panel1.Controls.Add(Me.Link_new_price_addition)
        Me.Panel1.Controls.Add(Me.Link_sales_KPI)
        Me.Panel1.Controls.Add(Me.link_us_sale)
        Me.Panel1.Controls.Add(Me.Link_non_tod_items)
        Me.Panel1.Controls.Add(Me.Link_new_cust_billto_shipto)
        Me.Panel1.Controls.Add(Me.Link_order_cancelation)
        Me.Panel1.Location = New System.Drawing.Point(1, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(712, 282)
        Me.Panel1.TabIndex = 7
        '
        'link_ofd_date_change
        '
        Me.link_ofd_date_change.AutoSize = True
        Me.link_ofd_date_change.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_ofd_date_change.LinkColor = System.Drawing.Color.MidnightBlue
        Me.link_ofd_date_change.Location = New System.Drawing.Point(145, 212)
        Me.link_ofd_date_change.Name = "link_ofd_date_change"
        Me.link_ofd_date_change.Size = New System.Drawing.Size(110, 13)
        Me.link_ofd_date_change.TabIndex = 8
        Me.link_ofd_date_change.TabStop = True
        Me.link_ofd_date_change.Text = "OFD Date Change"
        Me.link_ofd_date_change.Visible = False
        '
        'Link_customer_detail
        '
        Me.Link_customer_detail.AutoSize = True
        Me.Link_customer_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_customer_detail.LinkColor = System.Drawing.Color.Crimson
        Me.Link_customer_detail.Location = New System.Drawing.Point(413, 258)
        Me.Link_customer_detail.Name = "Link_customer_detail"
        Me.Link_customer_detail.Size = New System.Drawing.Size(133, 13)
        Me.Link_customer_detail.TabIndex = 7
        Me.Link_customer_detail.TabStop = True
        Me.Link_customer_detail.Text = "View Customer Details"
        Me.Link_customer_detail.Visible = False
        '
        'link_view_price_list
        '
        Me.link_view_price_list.AutoSize = True
        Me.link_view_price_list.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_view_price_list.LinkColor = System.Drawing.Color.Crimson
        Me.link_view_price_list.Location = New System.Drawing.Point(333, 258)
        Me.link_view_price_list.Name = "link_view_price_list"
        Me.link_view_price_list.Size = New System.Drawing.Size(66, 13)
        Me.link_view_price_list.TabIndex = 7
        Me.link_view_price_list.TabStop = True
        Me.link_view_price_list.Text = "View price"
        Me.link_view_price_list.Visible = False
        '
        'link_branch_price_rev
        '
        Me.link_branch_price_rev.AutoSize = True
        Me.link_branch_price_rev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_branch_price_rev.LinkColor = System.Drawing.Color.Crimson
        Me.link_branch_price_rev.Location = New System.Drawing.Point(333, 240)
        Me.link_branch_price_rev.Name = "link_branch_price_rev"
        Me.link_branch_price_rev.Size = New System.Drawing.Size(178, 13)
        Me.link_branch_price_rev.TabIndex = 7
        Me.link_branch_price_rev.TabStop = True
        Me.link_branch_price_rev.Text = "Branch Price Revision/Editing"
        Me.link_branch_price_rev.Visible = False
        '
        'Link_LPD
        '
        Me.Link_LPD.AutoSize = True
        Me.Link_LPD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_LPD.LinkColor = System.Drawing.Color.SaddleBrown
        Me.Link_LPD.Location = New System.Drawing.Point(4, 120)
        Me.Link_LPD.Name = "Link_LPD"
        Me.Link_LPD.Size = New System.Drawing.Size(62, 13)
        Me.Link_LPD.TabIndex = 6
        Me.Link_LPD.TabStop = True
        Me.Link_LPD.Text = "View LPD"
        '
        'Link_TOD_Non_TOD_items
        '
        Me.Link_TOD_Non_TOD_items.AutoSize = True
        Me.Link_TOD_Non_TOD_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_TOD_Non_TOD_items.LinkColor = System.Drawing.Color.SaddleBrown
        Me.Link_TOD_Non_TOD_items.Location = New System.Drawing.Point(5, 97)
        Me.Link_TOD_Non_TOD_items.Name = "Link_TOD_Non_TOD_items"
        Me.Link_TOD_Non_TOD_items.Size = New System.Drawing.Size(135, 13)
        Me.Link_TOD_Non_TOD_items.TabIndex = 6
        Me.Link_TOD_Non_TOD_items.TabStop = True
        Me.Link_TOD_Non_TOD_items.Text = "TOD && Non TOD Items"
        '
        'link_weekwise_ord_pend
        '
        Me.link_weekwise_ord_pend.AutoSize = True
        Me.link_weekwise_ord_pend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_weekwise_ord_pend.LinkColor = System.Drawing.Color.MidnightBlue
        Me.link_weekwise_ord_pend.Location = New System.Drawing.Point(143, 189)
        Me.link_weekwise_ord_pend.Name = "link_weekwise_ord_pend"
        Me.link_weekwise_ord_pend.Size = New System.Drawing.Size(154, 13)
        Me.link_weekwise_ord_pend.TabIndex = 6
        Me.link_weekwise_ord_pend.TabStop = True
        Me.link_weekwise_ord_pend.Text = "Weekwise Order and Sale"
        Me.link_weekwise_ord_pend.Visible = False
        '
        'link_inter_region_flush
        '
        Me.link_inter_region_flush.AutoSize = True
        Me.link_inter_region_flush.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_inter_region_flush.LinkColor = System.Drawing.Color.MidnightBlue
        Me.link_inter_region_flush.Location = New System.Drawing.Point(145, 166)
        Me.link_inter_region_flush.Name = "link_inter_region_flush"
        Me.link_inter_region_flush.Size = New System.Drawing.Size(111, 13)
        Me.link_inter_region_flush.TabIndex = 6
        Me.link_inter_region_flush.TabStop = True
        Me.link_inter_region_flush.Text = "Inter Region Flush"
        Me.link_inter_region_flush.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.MidnightBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(145, 134)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(152, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Order Pend and Available"
        Me.LinkLabel1.Visible = False
        '
        'link_sale_cyr_lyr
        '
        Me.link_sale_cyr_lyr.AutoSize = True
        Me.link_sale_cyr_lyr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_sale_cyr_lyr.LinkColor = System.Drawing.Color.MidnightBlue
        Me.link_sale_cyr_lyr.Location = New System.Drawing.Point(145, 108)
        Me.link_sale_cyr_lyr.Name = "link_sale_cyr_lyr"
        Me.link_sale_cyr_lyr.Size = New System.Drawing.Size(190, 13)
        Me.link_sale_cyr_lyr.TabIndex = 6
        Me.link_sale_cyr_lyr.TabStop = True
        Me.link_sale_cyr_lyr.Text = "Sale Current Year and Last Year"
        '
        'link_Dealer_target
        '
        Me.link_Dealer_target.AutoSize = True
        Me.link_Dealer_target.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_Dealer_target.LinkColor = System.Drawing.Color.Blue
        Me.link_Dealer_target.Location = New System.Drawing.Point(447, 97)
        Me.link_Dealer_target.Name = "link_Dealer_target"
        Me.link_Dealer_target.Size = New System.Drawing.Size(257, 13)
        Me.link_Dealer_target.TabIndex = 6
        Me.link_Dealer_target.TabStop = True
        Me.link_Dealer_target.Text = "Dealer Target Change /DSP Date Extension"
        '
        'link_dds_req
        '
        Me.link_dds_req.AutoSize = True
        Me.link_dds_req.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_dds_req.LinkColor = System.Drawing.Color.Blue
        Me.link_dds_req.Location = New System.Drawing.Point(520, 28)
        Me.link_dds_req.Name = "link_dds_req"
        Me.link_dds_req.Size = New System.Drawing.Size(158, 13)
        Me.link_dds_req.TabIndex = 6
        Me.link_dds_req.TabStop = True
        Me.link_dds_req.Text = "DDS Requirement Addition"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Crimson
        Me.LinkLabel2.Location = New System.Drawing.Point(333, 221)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(109, 13)
        Me.LinkLabel2.TabIndex = 6
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "View Form2 Detail"
        Me.LinkLabel2.Visible = False
        '
        'Link_price_add
        '
        Me.Link_price_add.AutoSize = True
        Me.Link_price_add.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_price_add.LinkColor = System.Drawing.Color.Crimson
        Me.Link_price_add.Location = New System.Drawing.Point(329, 201)
        Me.Link_price_add.Name = "Link_price_add"
        Me.Link_price_add.Size = New System.Drawing.Size(146, 13)
        Me.Link_price_add.TabIndex = 6
        Me.Link_price_add.TabStop = True
        Me.Link_price_add.Text = "View New Price Addition"
        Me.Link_price_add.Visible = False
        '
        'LinkLabel_ORDER_RECEIPT
        '
        Me.LinkLabel_ORDER_RECEIPT.AutoSize = True
        Me.LinkLabel_ORDER_RECEIPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_ORDER_RECEIPT.LinkColor = System.Drawing.Color.Crimson
        Me.LinkLabel_ORDER_RECEIPT.Location = New System.Drawing.Point(329, 182)
        Me.LinkLabel_ORDER_RECEIPT.Name = "LinkLabel_ORDER_RECEIPT"
        Me.LinkLabel_ORDER_RECEIPT.Size = New System.Drawing.Size(150, 13)
        Me.LinkLabel_ORDER_RECEIPT.TabIndex = 6
        Me.LinkLabel_ORDER_RECEIPT.TabStop = True
        Me.LinkLabel_ORDER_RECEIPT.Text = "Order Receipt Monthwise"
        '
        'Link_order_sale_OS
        '
        Me.Link_order_sale_OS.AutoSize = True
        Me.Link_order_sale_OS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_order_sale_OS.LinkColor = System.Drawing.Color.Crimson
        Me.Link_order_sale_OS.Location = New System.Drawing.Point(329, 161)
        Me.Link_order_sale_OS.Name = "Link_order_sale_OS"
        Me.Link_order_sale_OS.Size = New System.Drawing.Size(173, 13)
        Me.Link_order_sale_OS.TabIndex = 6
        Me.Link_order_sale_OS.TabStop = True
        Me.Link_order_sale_OS.Text = "Order , Sale And Outstanding"
        '
        'Link_new_price_addition
        '
        Me.Link_new_price_addition.AutoSize = True
        Me.Link_new_price_addition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_new_price_addition.LinkColor = System.Drawing.Color.Crimson
        Me.Link_new_price_addition.Location = New System.Drawing.Point(329, 143)
        Me.Link_new_price_addition.Name = "Link_new_price_addition"
        Me.Link_new_price_addition.Size = New System.Drawing.Size(115, 13)
        Me.Link_new_price_addition.TabIndex = 6
        Me.Link_new_price_addition.TabStop = True
        Me.Link_new_price_addition.Text = "New Price Addition"
        '
        'Link_sales_KPI
        '
        Me.Link_sales_KPI.AutoSize = True
        Me.Link_sales_KPI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_sales_KPI.LinkColor = System.Drawing.Color.Crimson
        Me.Link_sales_KPI.Location = New System.Drawing.Point(329, 124)
        Me.Link_sales_KPI.Name = "Link_sales_KPI"
        Me.Link_sales_KPI.Size = New System.Drawing.Size(62, 13)
        Me.Link_sales_KPI.TabIndex = 6
        Me.Link_sales_KPI.TabStop = True
        Me.Link_sales_KPI.Text = "Sales KPI"
        '
        'link_us_sale
        '
        Me.link_us_sale.AutoSize = True
        Me.link_us_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_us_sale.LinkColor = System.Drawing.Color.Crimson
        Me.link_us_sale.Location = New System.Drawing.Point(332, 103)
        Me.link_us_sale.Name = "link_us_sale"
        Me.link_us_sale.Size = New System.Drawing.Size(51, 13)
        Me.link_us_sale.TabIndex = 6
        Me.link_us_sale.TabStop = True
        Me.link_us_sale.Text = "US sale"
        '
        'Login_mktg
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(717, 481)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txt_pwd)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Login_mktg"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MKTG Reports"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents link_mktg_review_detail As LinkLabel
    Friend WithEvents link_mktg_mrm As LinkLabel
    Friend WithEvents Link_Dealer_order_status As LinkLabel
    Friend WithEvents Link_bin_addition As LinkLabel
    Friend WithEvents Link_non_moving_item_stock As LinkLabel
    Friend WithEvents Link_ofd_orderpending As LinkLabel
    Friend WithEvents Link_new_cust_billto_shipto As LinkLabel
    Friend WithEvents Link_order_cancelation As LinkLabel
    Friend WithEvents Link_sale_detail As LinkLabel
    Friend WithEvents Link_non_tod_items As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents link_us_sale As LinkLabel
    Friend WithEvents Link_new_price_addition As LinkLabel
    Friend WithEvents Link_sales_KPI As LinkLabel
    Friend WithEvents Link_order_sale_OS As LinkLabel
    Friend WithEvents link_sale_cyr_lyr As LinkLabel
    Friend WithEvents link_dds_req As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel_ORDER_RECEIPT As LinkLabel
    Friend WithEvents Link_price_add As LinkLabel
    Friend WithEvents Link_TOD_Non_TOD_items As LinkLabel
    Friend WithEvents link_inter_region_flush As LinkLabel
    Friend WithEvents Link_LPD As LinkLabel
    Friend WithEvents link_Dealer_target As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents link_weekwise_ord_pend As LinkLabel
    Friend WithEvents link_branch_price_rev As LinkLabel
    Friend WithEvents link_view_price_list As LinkLabel
    Friend WithEvents link_ofd_date_change As LinkLabel
    Friend WithEvents Link_customer_detail As LinkLabel
End Class
