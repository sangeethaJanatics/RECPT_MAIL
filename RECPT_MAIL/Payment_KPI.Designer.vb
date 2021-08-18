<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment_KPI
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
        Me.rad_over_due = New System.Windows.Forms.RadioButton()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb_odue = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rad_payment_adhr_cust = New System.Windows.Forms.RadioButton()
        Me.rad_payment_adhr_region = New System.Windows.Forms.RadioButton()
        Me.rad_nil_os = New System.Windows.Forms.RadioButton()
        Me.rad_delivery_rating_customer = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_delivery_rating = New System.Windows.Forms.RadioButton()
        Me.rad_dealer_CSI = New System.Windows.Forms.RadioButton()
        Me.rad_customer_CSI = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_month = New System.Windows.Forms.ComboBox()
        Me.rad_cust_cat_OS = New System.Windows.Forms.RadioButton()
        Me.rad_OS_breakup = New System.Windows.Forms.RadioButton()
        Me.rad_odue_cust_category_wise = New System.Windows.Forms.RadioButton()
        Me.rad_odue_cust_cat_breakup = New System.Windows.Forms.RadioButton()
        Me.rad_payment_cal_status = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "KPI For :"
        '
        'rad_over_due
        '
        Me.rad_over_due.AutoSize = True
        Me.rad_over_due.Checked = True
        Me.rad_over_due.ForeColor = System.Drawing.Color.Crimson
        Me.rad_over_due.Location = New System.Drawing.Point(75, 23)
        Me.rad_over_due.Name = "rad_over_due"
        Me.rad_over_due.Size = New System.Drawing.Size(128, 17)
        Me.rad_over_due.TabIndex = 1
        Me.rad_over_due.TabStop = True
        Me.rad_over_due.Text = "Over Due Month-wise"
        Me.rad_over_due.UseVisualStyleBackColor = True
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
        Me.dgv1.Location = New System.Drawing.Point(12, 136)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1024, 372)
        Me.dgv1.TabIndex = 2
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.Khaki
        Me.btn_go.Location = New System.Drawing.Point(652, 26)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 41)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_odue)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(753, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(291, 72)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ODue breakup"
        Me.GroupBox1.Visible = False
        '
        'cmb_odue
        '
        Me.cmb_odue.FormattingEnabled = True
        Me.cmb_odue.Location = New System.Drawing.Point(105, 19)
        Me.cmb_odue.Name = "cmb_odue"
        Me.cmb_odue.Size = New System.Drawing.Size(174, 21)
        Me.cmb_odue.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Khaki
        Me.Button1.Location = New System.Drawing.Point(194, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "View"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Breakup  For :"
        '
        'rad_payment_adhr_cust
        '
        Me.rad_payment_adhr_cust.AutoSize = True
        Me.rad_payment_adhr_cust.ForeColor = System.Drawing.Color.Crimson
        Me.rad_payment_adhr_cust.Location = New System.Drawing.Point(72, 91)
        Me.rad_payment_adhr_cust.Name = "rad_payment_adhr_cust"
        Me.rad_payment_adhr_cust.Size = New System.Drawing.Size(168, 17)
        Me.rad_payment_adhr_cust.TabIndex = 1
        Me.rad_payment_adhr_cust.Text = "Payment Adherence Customer"
        Me.rad_payment_adhr_cust.UseVisualStyleBackColor = True
        '
        'rad_payment_adhr_region
        '
        Me.rad_payment_adhr_region.AutoSize = True
        Me.rad_payment_adhr_region.ForeColor = System.Drawing.Color.Crimson
        Me.rad_payment_adhr_region.Location = New System.Drawing.Point(278, 29)
        Me.rad_payment_adhr_region.Name = "rad_payment_adhr_region"
        Me.rad_payment_adhr_region.Size = New System.Drawing.Size(158, 17)
        Me.rad_payment_adhr_region.TabIndex = 1
        Me.rad_payment_adhr_region.Text = "Payment Adherence Region"
        Me.rad_payment_adhr_region.UseVisualStyleBackColor = True
        '
        'rad_nil_os
        '
        Me.rad_nil_os.AutoSize = True
        Me.rad_nil_os.ForeColor = System.Drawing.Color.Crimson
        Me.rad_nil_os.Location = New System.Drawing.Point(278, 50)
        Me.rad_nil_os.Name = "rad_nil_os"
        Me.rad_nil_os.Size = New System.Drawing.Size(136, 17)
        Me.rad_nil_os.TabIndex = 1
        Me.rad_nil_os.Text = "Nil OS Beyond 90 Days"
        Me.rad_nil_os.UseVisualStyleBackColor = True
        '
        'rad_delivery_rating_customer
        '
        Me.rad_delivery_rating_customer.AutoSize = True
        Me.rad_delivery_rating_customer.ForeColor = System.Drawing.Color.Crimson
        Me.rad_delivery_rating_customer.Location = New System.Drawing.Point(478, 32)
        Me.rad_delivery_rating_customer.Name = "rad_delivery_rating_customer"
        Me.rad_delivery_rating_customer.Size = New System.Drawing.Size(144, 17)
        Me.rad_delivery_rating_customer.TabIndex = 1
        Me.rad_delivery_rating_customer.Text = "Customer Delivery Rating"
        Me.rad_delivery_rating_customer.UseVisualStyleBackColor = True
        '
        'rad_dealer_delivery_rating
        '
        Me.rad_dealer_delivery_rating.AutoSize = True
        Me.rad_dealer_delivery_rating.ForeColor = System.Drawing.Color.Crimson
        Me.rad_dealer_delivery_rating.Location = New System.Drawing.Point(478, 53)
        Me.rad_dealer_delivery_rating.Name = "rad_dealer_delivery_rating"
        Me.rad_dealer_delivery_rating.Size = New System.Drawing.Size(131, 17)
        Me.rad_dealer_delivery_rating.TabIndex = 1
        Me.rad_dealer_delivery_rating.Text = "Dealer Delivery Rating"
        Me.rad_dealer_delivery_rating.UseVisualStyleBackColor = True
        '
        'rad_dealer_CSI
        '
        Me.rad_dealer_CSI.AutoSize = True
        Me.rad_dealer_CSI.ForeColor = System.Drawing.Color.Crimson
        Me.rad_dealer_CSI.Location = New System.Drawing.Point(478, 74)
        Me.rad_dealer_CSI.Name = "rad_dealer_CSI"
        Me.rad_dealer_CSI.Size = New System.Drawing.Size(76, 17)
        Me.rad_dealer_CSI.TabIndex = 1
        Me.rad_dealer_CSI.Text = "Dealer CSI"
        Me.rad_dealer_CSI.UseVisualStyleBackColor = True
        '
        'rad_customer_CSI
        '
        Me.rad_customer_CSI.AutoSize = True
        Me.rad_customer_CSI.ForeColor = System.Drawing.Color.Crimson
        Me.rad_customer_CSI.Location = New System.Drawing.Point(478, 95)
        Me.rad_customer_CSI.Name = "rad_customer_CSI"
        Me.rad_customer_CSI.Size = New System.Drawing.Size(92, 17)
        Me.rad_customer_CSI.TabIndex = 1
        Me.rad_customer_CSI.Text = "Customer  CSI"
        Me.rad_customer_CSI.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(817, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CSI For the Month :"
        '
        'cmb_month
        '
        Me.cmb_month.FormattingEnabled = True
        Me.cmb_month.Location = New System.Drawing.Point(933, 86)
        Me.cmb_month.Name = "cmb_month"
        Me.cmb_month.Size = New System.Drawing.Size(101, 21)
        Me.cmb_month.TabIndex = 1
        '
        'rad_cust_cat_OS
        '
        Me.rad_cust_cat_OS.AutoSize = True
        Me.rad_cust_cat_OS.ForeColor = System.Drawing.Color.Crimson
        Me.rad_cust_cat_OS.Location = New System.Drawing.Point(278, 71)
        Me.rad_cust_cat_OS.Name = "rad_cust_cat_OS"
        Me.rad_cust_cat_OS.Size = New System.Drawing.Size(152, 17)
        Me.rad_cust_cat_OS.TabIndex = 1
        Me.rad_cust_cat_OS.Text = "Customer categorywise OS"
        Me.rad_cust_cat_OS.UseVisualStyleBackColor = True
        '
        'rad_OS_breakup
        '
        Me.rad_OS_breakup.AutoSize = True
        Me.rad_OS_breakup.ForeColor = System.Drawing.Color.Crimson
        Me.rad_OS_breakup.Location = New System.Drawing.Point(278, 92)
        Me.rad_OS_breakup.Name = "rad_OS_breakup"
        Me.rad_OS_breakup.Size = New System.Drawing.Size(194, 17)
        Me.rad_OS_breakup.TabIndex = 1
        Me.rad_OS_breakup.Text = "Customer categorywise OS breakup"
        Me.rad_OS_breakup.UseVisualStyleBackColor = True
        '
        'rad_odue_cust_category_wise
        '
        Me.rad_odue_cust_category_wise.AutoSize = True
        Me.rad_odue_cust_category_wise.ForeColor = System.Drawing.Color.Crimson
        Me.rad_odue_cust_category_wise.Location = New System.Drawing.Point(72, 47)
        Me.rad_odue_cust_category_wise.Name = "rad_odue_cust_category_wise"
        Me.rad_odue_cust_category_wise.Size = New System.Drawing.Size(163, 17)
        Me.rad_odue_cust_category_wise.TabIndex = 1
        Me.rad_odue_cust_category_wise.Text = "Over Due Customer Category"
        Me.rad_odue_cust_category_wise.UseVisualStyleBackColor = True
        '
        'rad_odue_cust_cat_breakup
        '
        Me.rad_odue_cust_cat_breakup.AutoSize = True
        Me.rad_odue_cust_cat_breakup.ForeColor = System.Drawing.Color.Crimson
        Me.rad_odue_cust_cat_breakup.Location = New System.Drawing.Point(72, 71)
        Me.rad_odue_cust_cat_breakup.Name = "rad_odue_cust_cat_breakup"
        Me.rad_odue_cust_cat_breakup.Size = New System.Drawing.Size(206, 17)
        Me.rad_odue_cust_cat_breakup.TabIndex = 1
        Me.rad_odue_cust_cat_breakup.Text = "Over Due Customer Category Breakup"
        Me.rad_odue_cust_cat_breakup.UseVisualStyleBackColor = True
        '
        'rad_payment_cal_status
        '
        Me.rad_payment_cal_status.AutoSize = True
        Me.rad_payment_cal_status.ForeColor = System.Drawing.Color.Crimson
        Me.rad_payment_cal_status.Location = New System.Drawing.Point(595, 94)
        Me.rad_payment_cal_status.Name = "rad_payment_cal_status"
        Me.rad_payment_cal_status.Size = New System.Drawing.Size(178, 17)
        Me.rad_payment_cal_status.TabIndex = 1
        Me.rad_payment_cal_status.Text = "Dealer Payment Calendar Status"
        Me.rad_payment_cal_status.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(819, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Region :"
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(875, 111)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(161, 21)
        Me.cmb_region.TabIndex = 1
        '
        'Payment_KPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(1048, 514)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.cmb_month)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.rad_nil_os)
        Me.Controls.Add(Me.rad_payment_cal_status)
        Me.Controls.Add(Me.rad_customer_CSI)
        Me.Controls.Add(Me.rad_dealer_CSI)
        Me.Controls.Add(Me.rad_dealer_delivery_rating)
        Me.Controls.Add(Me.rad_OS_breakup)
        Me.Controls.Add(Me.rad_cust_cat_OS)
        Me.Controls.Add(Me.rad_delivery_rating_customer)
        Me.Controls.Add(Me.rad_payment_adhr_region)
        Me.Controls.Add(Me.rad_payment_adhr_cust)
        Me.Controls.Add(Me.rad_odue_cust_cat_breakup)
        Me.Controls.Add(Me.rad_odue_cust_category_wise)
        Me.Controls.Add(Me.rad_over_due)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Payment_KPI"
        Me.Text = "Payment KPI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_over_due As System.Windows.Forms.RadioButton
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_odue As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rad_payment_adhr_cust As System.Windows.Forms.RadioButton
    Friend WithEvents rad_payment_adhr_region As System.Windows.Forms.RadioButton
    Friend WithEvents rad_nil_os As System.Windows.Forms.RadioButton
    Friend WithEvents rad_delivery_rating_customer As System.Windows.Forms.RadioButton
    Friend WithEvents rad_dealer_delivery_rating As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rad_dealer_CSI As System.Windows.Forms.RadioButton
    Friend WithEvents rad_customer_CSI As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_month As System.Windows.Forms.ComboBox
    Friend WithEvents rad_cust_cat_OS As RadioButton
    Friend WithEvents rad_OS_breakup As RadioButton
    Friend WithEvents rad_odue_cust_category_wise As RadioButton
    Friend WithEvents rad_odue_cust_cat_breakup As RadioButton
    Friend WithEvents rad_payment_cal_status As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_region As ComboBox
End Class
