<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class order_pending
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.rad_dealer = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.cmb_ofd_wk = New System.Windows.Forms.ComboBox()
        Me.rad_customer = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.chk_ofd_upto = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rad_summary = New System.Windows.Forms.RadioButton()
        Me.rad_detailed = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rad_production_pending = New System.Windows.Forms.RadioButton()
        Me.rad_order_pending = New System.Windows.Forms.RadioButton()
        Me.txt_item_no = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rad_inactive_oa = New System.Windows.Forms.RadioButton()
        Me.rad_active_oa = New System.Windows.Forms.RadioButton()
        Me.btn_export_to_excel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_order_no = New System.Windows.Forms.TextBox()
        Me.chk_orgwise_order_pending = New System.Windows.Forms.CheckBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.ForeColor = System.Drawing.Color.Crimson
        Me.btn_go.Location = New System.Drawing.Point(680, 13)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(58, 24)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Show"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'rad_dealer
        '
        Me.rad_dealer.AutoSize = True
        Me.rad_dealer.Checked = True
        Me.rad_dealer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dealer.ForeColor = System.Drawing.Color.Crimson
        Me.rad_dealer.Location = New System.Drawing.Point(541, 17)
        Me.rad_dealer.Name = "rad_dealer"
        Me.rad_dealer.Size = New System.Drawing.Size(62, 17)
        Me.rad_dealer.TabIndex = 1
        Me.rad_dealer.TabStop = True
        Me.rad_dealer.Text = "Dealer"
        Me.rad_dealer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(215, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Order FF week:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
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
        Me.dgv1.Location = New System.Drawing.Point(12, 75)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1057, 432)
        Me.dgv1.TabIndex = 3
        '
        'cmb_ofd_wk
        '
        Me.cmb_ofd_wk.ForeColor = System.Drawing.Color.Crimson
        Me.cmb_ofd_wk.FormattingEnabled = True
        Me.cmb_ofd_wk.Location = New System.Drawing.Point(312, 15)
        Me.cmb_ofd_wk.Name = "cmb_ofd_wk"
        Me.cmb_ofd_wk.Size = New System.Drawing.Size(139, 21)
        Me.cmb_ofd_wk.TabIndex = 4
        '
        'rad_customer
        '
        Me.rad_customer.AutoSize = True
        Me.rad_customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_customer.ForeColor = System.Drawing.Color.Crimson
        Me.rad_customer.Location = New System.Drawing.Point(603, 17)
        Me.rad_customer.Name = "rad_customer"
        Me.rad_customer.Size = New System.Drawing.Size(77, 17)
        Me.rad_customer.TabIndex = 1
        Me.rad_customer.Text = "Customer"
        Me.rad_customer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(10, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Region :"
        '
        'cmb_region
        '
        Me.cmb_region.ForeColor = System.Drawing.Color.Crimson
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(71, 15)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(139, 21)
        Me.cmb_region.TabIndex = 4
        '
        'chk_ofd_upto
        '
        Me.chk_ofd_upto.AutoSize = True
        Me.chk_ofd_upto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ofd_upto.ForeColor = System.Drawing.Color.Crimson
        Me.chk_ofd_upto.Location = New System.Drawing.Point(457, 17)
        Me.chk_ofd_upto.Name = "chk_ofd_upto"
        Me.chk_ofd_upto.Size = New System.Drawing.Size(82, 17)
        Me.chk_ofd_upto.TabIndex = 5
        Me.chk_ofd_upto.Text = "OFD Upto"
        Me.chk_ofd_upto.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rad_summary)
        Me.GroupBox1.Controls.Add(Me.rad_detailed)
        Me.GroupBox1.Location = New System.Drawing.Point(603, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 39)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Type"
        Me.GroupBox1.Visible = False
        '
        'rad_summary
        '
        Me.rad_summary.AutoSize = True
        Me.rad_summary.Checked = True
        Me.rad_summary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_summary.Location = New System.Drawing.Point(25, 16)
        Me.rad_summary.Name = "rad_summary"
        Me.rad_summary.Size = New System.Drawing.Size(75, 17)
        Me.rad_summary.TabIndex = 1
        Me.rad_summary.TabStop = True
        Me.rad_summary.Text = "Summary"
        Me.rad_summary.UseVisualStyleBackColor = True
        '
        'rad_detailed
        '
        Me.rad_detailed.AutoSize = True
        Me.rad_detailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_detailed.Location = New System.Drawing.Point(106, 16)
        Me.rad_detailed.Name = "rad_detailed"
        Me.rad_detailed.Size = New System.Drawing.Size(72, 17)
        Me.rad_detailed.TabIndex = 1
        Me.rad_detailed.Text = "Detailed"
        Me.rad_detailed.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rad_production_pending)
        Me.GroupBox2.Controls.Add(Me.rad_order_pending)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox2.Location = New System.Drawing.Point(785, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 36)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Report For"
        '
        'rad_production_pending
        '
        Me.rad_production_pending.AutoSize = True
        Me.rad_production_pending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_production_pending.Location = New System.Drawing.Point(141, 15)
        Me.rad_production_pending.Name = "rad_production_pending"
        Me.rad_production_pending.Size = New System.Drawing.Size(136, 17)
        Me.rad_production_pending.TabIndex = 1
        Me.rad_production_pending.Text = "Production Pending"
        Me.rad_production_pending.UseVisualStyleBackColor = True
        '
        'rad_order_pending
        '
        Me.rad_order_pending.AutoSize = True
        Me.rad_order_pending.Checked = True
        Me.rad_order_pending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_order_pending.Location = New System.Drawing.Point(25, 14)
        Me.rad_order_pending.Name = "rad_order_pending"
        Me.rad_order_pending.Size = New System.Drawing.Size(106, 17)
        Me.rad_order_pending.TabIndex = 1
        Me.rad_order_pending.TabStop = True
        Me.rad_order_pending.Text = "Order Pending"
        Me.rad_order_pending.UseVisualStyleBackColor = True
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(71, 43)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(139, 20)
        Me.txt_item_no.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(10, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Item No :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LightGreen
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(458, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "       "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Purple
        Me.Label5.Location = New System.Drawing.Point(494, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Available in AMS Pending"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rad_inactive_oa)
        Me.GroupBox3.Controls.Add(Me.rad_active_oa)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox3.Location = New System.Drawing.Point(857, 37)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(209, 36)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actice /InActive OA"
        Me.GroupBox3.Visible = False
        '
        'rad_inactive_oa
        '
        Me.rad_inactive_oa.AutoSize = True
        Me.rad_inactive_oa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_inactive_oa.Location = New System.Drawing.Point(111, 15)
        Me.rad_inactive_oa.Name = "rad_inactive_oa"
        Me.rad_inactive_oa.Size = New System.Drawing.Size(93, 17)
        Me.rad_inactive_oa.TabIndex = 1
        Me.rad_inactive_oa.Text = "InActive OA"
        Me.rad_inactive_oa.UseVisualStyleBackColor = True
        '
        'rad_active_oa
        '
        Me.rad_active_oa.AutoSize = True
        Me.rad_active_oa.Checked = True
        Me.rad_active_oa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_active_oa.Location = New System.Drawing.Point(25, 14)
        Me.rad_active_oa.Name = "rad_active_oa"
        Me.rad_active_oa.Size = New System.Drawing.Size(82, 17)
        Me.rad_active_oa.TabIndex = 1
        Me.rad_active_oa.TabStop = True
        Me.rad_active_oa.Text = "Active OA"
        Me.rad_active_oa.UseVisualStyleBackColor = True
        '
        'btn_export_to_excel
        '
        Me.btn_export_to_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export_to_excel.ForeColor = System.Drawing.Color.Crimson
        Me.btn_export_to_excel.Location = New System.Drawing.Point(680, 41)
        Me.btn_export_to_excel.Name = "btn_export_to_excel"
        Me.btn_export_to_excel.Size = New System.Drawing.Size(58, 24)
        Me.btn_export_to_excel.TabIndex = 0
        Me.btn_export_to_excel.Text = "Excel"
        Me.btn_export_to_excel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Crimson
        Me.Label6.Location = New System.Drawing.Point(241, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Order No :"
        '
        'txt_order_no
        '
        Me.txt_order_no.Location = New System.Drawing.Point(312, 43)
        Me.txt_order_no.Name = "txt_order_no"
        Me.txt_order_no.Size = New System.Drawing.Size(139, 20)
        Me.txt_order_no.TabIndex = 8
        '
        'chk_orgwise_order_pending
        '
        Me.chk_orgwise_order_pending.AutoSize = True
        Me.chk_orgwise_order_pending.Location = New System.Drawing.Point(750, 48)
        Me.chk_orgwise_order_pending.Name = "chk_orgwise_order_pending"
        Me.chk_orgwise_order_pending.Size = New System.Drawing.Size(138, 17)
        Me.chk_orgwise_order_pending.TabIndex = 11
        Me.chk_orgwise_order_pending.Text = "OrgWise Order Pending"
        Me.chk_orgwise_order_pending.UseVisualStyleBackColor = True
        '
        'order_pending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(1081, 512)
        Me.Controls.Add(Me.chk_orgwise_order_pending)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_order_no)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chk_ofd_upto)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmb_ofd_wk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rad_customer)
        Me.Controls.Add(Me.rad_dealer)
        Me.Controls.Add(Me.btn_export_to_excel)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "order_pending"
        Me.Text = "Order Pending"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents rad_dealer As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_ofd_wk As System.Windows.Forms.ComboBox
    Friend WithEvents rad_customer As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents chk_ofd_upto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_detailed As System.Windows.Forms.RadioButton
    Friend WithEvents rad_summary As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_production_pending As System.Windows.Forms.RadioButton
    Friend WithEvents rad_order_pending As System.Windows.Forms.RadioButton
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rad_inactive_oa As RadioButton
    Friend WithEvents rad_active_oa As RadioButton
    Friend WithEvents btn_export_to_excel As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_order_no As TextBox
    Friend WithEvents chk_orgwise_order_pending As CheckBox
End Class
