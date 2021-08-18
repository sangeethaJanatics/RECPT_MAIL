<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2_addition
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Rad_FORM2_DETAIL = New System.Windows.Forms.RadioButton()
        Me.Rad_sale_discount = New System.Windows.Forms.RadioButton()
        Me.Rad_order_receipt_rev_model = New System.Windows.Forms.RadioButton()
        Me.Rad_sale_revenue_model = New System.Windows.Forms.RadioButton()
        Me.Rad_payment_receipt_rev_model = New System.Windows.Forms.RadioButton()
        Me.Rad_prodn_rev_model = New System.Windows.Forms.RadioButton()
        Me.rad_order_pending_ans_sale = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rad_order_entered = New System.Windows.Forms.RadioButton()
        Me.Rad_order_booked = New System.Windows.Forms.RadioButton()
        Me.Rad_ORDER_PEND_ALL = New System.Windows.Forms.RadioButton()
        Me.Rad_order_recd_cust_wise = New System.Windows.Forms.RadioButton()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(846, 56)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(5, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(49, 8)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(107, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(16, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(49, 34)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(107, 20)
        Me.DateTimePicker2.TabIndex = 2
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
        Me.dgv1.GridColor = System.Drawing.Color.Gray
        Me.dgv1.Location = New System.Drawing.Point(12, 97)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1038, 408)
        Me.dgv1.TabIndex = 3
        '
        'Rad_FORM2_DETAIL
        '
        Me.Rad_FORM2_DETAIL.AutoSize = True
        Me.Rad_FORM2_DETAIL.Checked = True
        Me.Rad_FORM2_DETAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_FORM2_DETAIL.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_FORM2_DETAIL.Location = New System.Drawing.Point(169, 10)
        Me.Rad_FORM2_DETAIL.Name = "Rad_FORM2_DETAIL"
        Me.Rad_FORM2_DETAIL.Size = New System.Drawing.Size(127, 17)
        Me.Rad_FORM2_DETAIL.TabIndex = 4
        Me.Rad_FORM2_DETAIL.TabStop = True
        Me.Rad_FORM2_DETAIL.Text = "View Form2 Detail"
        Me.Rad_FORM2_DETAIL.UseVisualStyleBackColor = True
        '
        'Rad_sale_discount
        '
        Me.Rad_sale_discount.AutoSize = True
        Me.Rad_sale_discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_sale_discount.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_sale_discount.Location = New System.Drawing.Point(169, 36)
        Me.Rad_sale_discount.Name = "Rad_sale_discount"
        Me.Rad_sale_discount.Size = New System.Drawing.Size(192, 17)
        Me.Rad_sale_discount.TabIndex = 4
        Me.Rad_sale_discount.Text = "Actual Sales Vs Scheme Sale"
        Me.Rad_sale_discount.UseVisualStyleBackColor = True
        '
        'Rad_order_receipt_rev_model
        '
        Me.Rad_order_receipt_rev_model.AutoSize = True
        Me.Rad_order_receipt_rev_model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_order_receipt_rev_model.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_order_receipt_rev_model.Location = New System.Drawing.Point(385, 7)
        Me.Rad_order_receipt_rev_model.Name = "Rad_order_receipt_rev_model"
        Me.Rad_order_receipt_rev_model.Size = New System.Drawing.Size(201, 17)
        Me.Rad_order_receipt_rev_model.TabIndex = 4
        Me.Rad_order_receipt_rev_model.Text = "Order Receipt -Revenue Model"
        Me.Rad_order_receipt_rev_model.UseVisualStyleBackColor = True
        '
        'Rad_sale_revenue_model
        '
        Me.Rad_sale_revenue_model.AutoSize = True
        Me.Rad_sale_revenue_model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_sale_revenue_model.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_sale_revenue_model.Location = New System.Drawing.Point(385, 30)
        Me.Rad_sale_revenue_model.Name = "Rad_sale_revenue_model"
        Me.Rad_sale_revenue_model.Size = New System.Drawing.Size(151, 17)
        Me.Rad_sale_revenue_model.TabIndex = 4
        Me.Rad_sale_revenue_model.Text = "Sale  -Revenue Model"
        Me.Rad_sale_revenue_model.UseVisualStyleBackColor = True
        '
        'Rad_payment_receipt_rev_model
        '
        Me.Rad_payment_receipt_rev_model.AutoSize = True
        Me.Rad_payment_receipt_rev_model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_payment_receipt_rev_model.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_payment_receipt_rev_model.Location = New System.Drawing.Point(385, 51)
        Me.Rad_payment_receipt_rev_model.Name = "Rad_payment_receipt_rev_model"
        Me.Rad_payment_receipt_rev_model.Size = New System.Drawing.Size(222, 17)
        Me.Rad_payment_receipt_rev_model.TabIndex = 4
        Me.Rad_payment_receipt_rev_model.Text = "Payment Receipt  -Revenue Model"
        Me.Rad_payment_receipt_rev_model.UseVisualStyleBackColor = True
        '
        'Rad_prodn_rev_model
        '
        Me.Rad_prodn_rev_model.AutoSize = True
        Me.Rad_prodn_rev_model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_prodn_rev_model.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_prodn_rev_model.Location = New System.Drawing.Point(385, 74)
        Me.Rad_prodn_rev_model.Name = "Rad_prodn_rev_model"
        Me.Rad_prodn_rev_model.Size = New System.Drawing.Size(187, 17)
        Me.Rad_prodn_rev_model.TabIndex = 4
        Me.Rad_prodn_rev_model.Text = "Production - Revenue Model"
        Me.Rad_prodn_rev_model.UseVisualStyleBackColor = True
        '
        'rad_order_pending_ans_sale
        '
        Me.rad_order_pending_ans_sale.AutoSize = True
        Me.rad_order_pending_ans_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_order_pending_ans_sale.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rad_order_pending_ans_sale.Location = New System.Drawing.Point(169, 59)
        Me.rad_order_pending_ans_sale.Name = "rad_order_pending_ans_sale"
        Me.rad_order_pending_ans_sale.Size = New System.Drawing.Size(160, 17)
        Me.rad_order_pending_ans_sale.TabIndex = 4
        Me.rad_order_pending_ans_sale.Text = "Order Pending and Sale"
        Me.rad_order_pending_ans_sale.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rad_order_entered)
        Me.GroupBox1.Controls.Add(Me.Rad_order_booked)
        Me.GroupBox1.Controls.Add(Me.Rad_ORDER_PEND_ALL)
        Me.GroupBox1.Location = New System.Drawing.Point(846, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 43)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Order status"
        '
        'Rad_order_entered
        '
        Me.Rad_order_entered.AutoSize = True
        Me.Rad_order_entered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_order_entered.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_order_entered.Location = New System.Drawing.Point(138, 18)
        Me.Rad_order_entered.Name = "Rad_order_entered"
        Me.Rad_order_entered.Size = New System.Drawing.Size(69, 17)
        Me.Rad_order_entered.TabIndex = 4
        Me.Rad_order_entered.Text = "Entered"
        Me.Rad_order_entered.UseVisualStyleBackColor = True
        '
        'Rad_order_booked
        '
        Me.Rad_order_booked.AutoSize = True
        Me.Rad_order_booked.Checked = True
        Me.Rad_order_booked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_order_booked.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_order_booked.Location = New System.Drawing.Point(64, 18)
        Me.Rad_order_booked.Name = "Rad_order_booked"
        Me.Rad_order_booked.Size = New System.Drawing.Size(68, 17)
        Me.Rad_order_booked.TabIndex = 4
        Me.Rad_order_booked.TabStop = True
        Me.Rad_order_booked.Text = "Booked"
        Me.Rad_order_booked.UseVisualStyleBackColor = True
        '
        'Rad_ORDER_PEND_ALL
        '
        Me.Rad_ORDER_PEND_ALL.AutoSize = True
        Me.Rad_ORDER_PEND_ALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_ORDER_PEND_ALL.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_ORDER_PEND_ALL.Location = New System.Drawing.Point(19, 18)
        Me.Rad_ORDER_PEND_ALL.Name = "Rad_ORDER_PEND_ALL"
        Me.Rad_ORDER_PEND_ALL.Size = New System.Drawing.Size(39, 17)
        Me.Rad_ORDER_PEND_ALL.TabIndex = 4
        Me.Rad_ORDER_PEND_ALL.Text = "All"
        Me.Rad_ORDER_PEND_ALL.UseVisualStyleBackColor = True
        '
        'Rad_order_recd_cust_wise
        '
        Me.Rad_order_recd_cust_wise.AutoSize = True
        Me.Rad_order_recd_cust_wise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_order_recd_cust_wise.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Rad_order_recd_cust_wise.Location = New System.Drawing.Point(615, 5)
        Me.Rad_order_recd_cust_wise.Name = "Rad_order_recd_cust_wise"
        Me.Rad_order_recd_cust_wise.Size = New System.Drawing.Size(217, 17)
        Me.Rad_order_recd_cust_wise.TabIndex = 4
        Me.Rad_order_recd_cust_wise.Text = "Custwise Order Recd- Rev Model "
        Me.Rad_order_recd_cust_wise.UseVisualStyleBackColor = True
        '
        'Form2_addition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(1062, 517)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rad_order_pending_ans_sale)
        Me.Controls.Add(Me.Rad_order_recd_cust_wise)
        Me.Controls.Add(Me.Rad_prodn_rev_model)
        Me.Controls.Add(Me.Rad_payment_receipt_rev_model)
        Me.Controls.Add(Me.Rad_sale_revenue_model)
        Me.Controls.Add(Me.Rad_order_receipt_rev_model)
        Me.Controls.Add(Me.Rad_sale_discount)
        Me.Controls.Add(Me.Rad_FORM2_DETAIL)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Form2_addition"
        Me.Text = "Form2 Addition And Revnue Models"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_go As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Rad_FORM2_DETAIL As RadioButton
    Friend WithEvents Rad_sale_discount As RadioButton
    Friend WithEvents Rad_order_receipt_rev_model As RadioButton
    Friend WithEvents Rad_sale_revenue_model As RadioButton
    Friend WithEvents Rad_payment_receipt_rev_model As RadioButton
    Friend WithEvents Rad_prodn_rev_model As RadioButton
    Friend WithEvents rad_order_pending_ans_sale As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rad_order_entered As RadioButton
    Friend WithEvents Rad_order_booked As RadioButton
    Friend WithEvents Rad_ORDER_PEND_ALL As RadioButton
    Friend WithEvents Rad_order_recd_cust_wise As RadioButton
End Class
