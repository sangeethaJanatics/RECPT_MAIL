<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MKtg_review_detail
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rad_dealer_sale_order_pend = New System.Windows.Forms.RadioButton()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.rad_dealer_week_order_pend = New System.Windows.Forms.RadioButton()
        Me.rad_os_more_than_15days = New System.Windows.Forms.RadioButton()
        Me.rad_order_and_sale = New System.Windows.Forms.RadioButton()
        Me.RAD_DELHI1_SALE = New System.Windows.Forms.RadioButton()
        Me.dgv_brk = New System.Windows.Forms.DataGridView()
        Me.rad_segment_wise_sale = New System.Windows.Forms.RadioButton()
        Me.rad_delhi1_qtrly_sale = New System.Windows.Forms.RadioButton()
        Me.rad_order_sale_with_product_group = New System.Windows.Forms.RadioButton()
        Me.rad_monthwise_sales = New System.Windows.Forms.RadioButton()
        Me.btn_export_to_excel = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report For :"
        '
        'rad_dealer_sale_order_pend
        '
        Me.rad_dealer_sale_order_pend.AutoSize = True
        Me.rad_dealer_sale_order_pend.Checked = True
        Me.rad_dealer_sale_order_pend.Location = New System.Drawing.Point(83, 19)
        Me.rad_dealer_sale_order_pend.Name = "rad_dealer_sale_order_pend"
        Me.rad_dealer_sale_order_pend.Size = New System.Drawing.Size(160, 17)
        Me.rad_dealer_sale_order_pend.TabIndex = 1
        Me.rad_dealer_sale_order_pend.TabStop = True
        Me.rad_dealer_sale_order_pend.Text = "Dealer Sale && Order Pending"
        Me.rad_dealer_sale_order_pend.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.Crimson
        Me.btn_go.Location = New System.Drawing.Point(801, 17)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 43)
        Me.btn_go.TabIndex = 2
        Me.btn_go.Text = "Go"
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv1.Location = New System.Drawing.Point(8, 65)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(868, 279)
        Me.dgv1.TabIndex = 3
        '
        'rad_dealer_week_order_pend
        '
        Me.rad_dealer_week_order_pend.AutoSize = True
        Me.rad_dealer_week_order_pend.Location = New System.Drawing.Point(6, 42)
        Me.rad_dealer_week_order_pend.Name = "rad_dealer_week_order_pend"
        Me.rad_dealer_week_order_pend.Size = New System.Drawing.Size(180, 17)
        Me.rad_dealer_week_order_pend.TabIndex = 1
        Me.rad_dealer_week_order_pend.Text = "Dealer week-wise Order Pending"
        Me.rad_dealer_week_order_pend.UseVisualStyleBackColor = True
        '
        'rad_os_more_than_15days
        '
        Me.rad_os_more_than_15days.AutoSize = True
        Me.rad_os_more_than_15days.Location = New System.Drawing.Point(264, 19)
        Me.rad_os_more_than_15days.Name = "rad_os_more_than_15days"
        Me.rad_os_more_than_15days.Size = New System.Drawing.Size(167, 17)
        Me.rad_os_more_than_15days.TabIndex = 1
        Me.rad_os_more_than_15days.Text = "Dealer OS More than 15 Days"
        Me.rad_os_more_than_15days.UseVisualStyleBackColor = True
        '
        'rad_order_and_sale
        '
        Me.rad_order_and_sale.AutoSize = True
        Me.rad_order_and_sale.Location = New System.Drawing.Point(187, 42)
        Me.rad_order_and_sale.Name = "rad_order_and_sale"
        Me.rad_order_and_sale.Size = New System.Drawing.Size(96, 17)
        Me.rad_order_and_sale.TabIndex = 1
        Me.rad_order_and_sale.Text = "Order and Sale"
        Me.rad_order_and_sale.UseVisualStyleBackColor = True
        '
        'RAD_DELHI1_SALE
        '
        Me.RAD_DELHI1_SALE.AutoSize = True
        Me.RAD_DELHI1_SALE.Location = New System.Drawing.Point(289, 42)
        Me.RAD_DELHI1_SALE.Name = "RAD_DELHI1_SALE"
        Me.RAD_DELHI1_SALE.Size = New System.Drawing.Size(132, 17)
        Me.RAD_DELHI1_SALE.TabIndex = 1
        Me.RAD_DELHI1_SALE.Text = "Delhi 1 Zone wise sale"
        Me.RAD_DELHI1_SALE.UseVisualStyleBackColor = True
        '
        'dgv_brk
        '
        Me.dgv_brk.AllowUserToAddRows = False
        Me.dgv_brk.AllowUserToDeleteRows = False
        Me.dgv_brk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_brk.BackgroundColor = System.Drawing.Color.White
        Me.dgv_brk.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_brk.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_brk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_brk.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_brk.Location = New System.Drawing.Point(8, 350)
        Me.dgv_brk.Name = "dgv_brk"
        Me.dgv_brk.ReadOnly = True
        Me.dgv_brk.Size = New System.Drawing.Size(868, 117)
        Me.dgv_brk.TabIndex = 3
        '
        'rad_segment_wise_sale
        '
        Me.rad_segment_wise_sale.AutoSize = True
        Me.rad_segment_wise_sale.Location = New System.Drawing.Point(437, 19)
        Me.rad_segment_wise_sale.Name = "rad_segment_wise_sale"
        Me.rad_segment_wise_sale.Size = New System.Drawing.Size(118, 17)
        Me.rad_segment_wise_sale.TabIndex = 1
        Me.rad_segment_wise_sale.Text = "Segment Wise Sale"
        Me.rad_segment_wise_sale.UseVisualStyleBackColor = True
        '
        'rad_delhi1_qtrly_sale
        '
        Me.rad_delhi1_qtrly_sale.AutoSize = True
        Me.rad_delhi1_qtrly_sale.Location = New System.Drawing.Point(423, 42)
        Me.rad_delhi1_qtrly_sale.Name = "rad_delhi1_qtrly_sale"
        Me.rad_delhi1_qtrly_sale.Size = New System.Drawing.Size(130, 17)
        Me.rad_delhi1_qtrly_sale.TabIndex = 1
        Me.rad_delhi1_qtrly_sale.Text = "Delhi 1  Qtr - wise sale"
        Me.rad_delhi1_qtrly_sale.UseVisualStyleBackColor = True
        '
        'rad_order_sale_with_product_group
        '
        Me.rad_order_sale_with_product_group.AutoSize = True
        Me.rad_order_sale_with_product_group.ForeColor = System.Drawing.Color.Navy
        Me.rad_order_sale_with_product_group.Location = New System.Drawing.Point(561, 19)
        Me.rad_order_sale_with_product_group.Name = "rad_order_sale_with_product_group"
        Me.rad_order_sale_with_product_group.Size = New System.Drawing.Size(190, 17)
        Me.rad_order_sale_with_product_group.TabIndex = 4
        Me.rad_order_sale_with_product_group.Text = "Order and Sale with Product Group"
        Me.rad_order_sale_with_product_group.UseVisualStyleBackColor = True
        '
        'rad_monthwise_sales
        '
        Me.rad_monthwise_sales.AutoSize = True
        Me.rad_monthwise_sales.Location = New System.Drawing.Point(559, 43)
        Me.rad_monthwise_sales.Name = "rad_monthwise_sales"
        Me.rad_monthwise_sales.Size = New System.Drawing.Size(101, 17)
        Me.rad_monthwise_sales.TabIndex = 5
        Me.rad_monthwise_sales.Text = "Month wise sale"
        Me.rad_monthwise_sales.UseVisualStyleBackColor = True
        '
        'btn_export_to_excel
        '
        Me.btn_export_to_excel.Location = New System.Drawing.Point(676, 39)
        Me.btn_export_to_excel.Name = "btn_export_to_excel"
        Me.btn_export_to_excel.Size = New System.Drawing.Size(97, 23)
        Me.btn_export_to_excel.TabIndex = 6
        Me.btn_export_to_excel.Text = "Export to Excel"
        Me.btn_export_to_excel.UseVisualStyleBackColor = True
        '
        'MKtg_review_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(888, 475)
        Me.Controls.Add(Me.btn_export_to_excel)
        Me.Controls.Add(Me.rad_monthwise_sales)
        Me.Controls.Add(Me.rad_order_sale_with_product_group)
        Me.Controls.Add(Me.dgv_brk)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.rad_segment_wise_sale)
        Me.Controls.Add(Me.rad_delhi1_qtrly_sale)
        Me.Controls.Add(Me.RAD_DELHI1_SALE)
        Me.Controls.Add(Me.rad_order_and_sale)
        Me.Controls.Add(Me.rad_os_more_than_15days)
        Me.Controls.Add(Me.rad_dealer_week_order_pend)
        Me.Controls.Add(Me.rad_dealer_sale_order_pend)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MKtg_review_detail"
        Me.Text = "MKTG Review Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_dealer_sale_order_pend As System.Windows.Forms.RadioButton
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rad_dealer_week_order_pend As System.Windows.Forms.RadioButton
    Friend WithEvents rad_os_more_than_15days As System.Windows.Forms.RadioButton
    Friend WithEvents rad_order_and_sale As System.Windows.Forms.RadioButton
    Friend WithEvents RAD_DELHI1_SALE As RadioButton
    Friend WithEvents dgv_brk As DataGridView
    Friend WithEvents rad_segment_wise_sale As RadioButton
    Friend WithEvents rad_delhi1_qtrly_sale As RadioButton
    Friend WithEvents rad_order_sale_with_product_group As RadioButton
    Friend WithEvents rad_monthwise_sales As RadioButton
    Friend WithEvents btn_export_to_excel As Button
End Class
