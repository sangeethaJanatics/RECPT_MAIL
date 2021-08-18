<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class US_Sale_with_inr_mplusl
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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.rad_us_sale = New System.Windows.Forms.RadioButton()
        Me.rad_india_sale = New System.Windows.Forms.RadioButton()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_fin_year = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rad_itemwise = New System.Windows.Forms.RadioButton()
        Me.rad_Customer_wise = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rad_sale_value = New System.Windows.Forms.RadioButton()
        Me.rad_cog = New System.Windows.Forms.RadioButton()
        Me.rad_sale_qty = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_customer = New System.Windows.Forms.ComboBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgv1.Location = New System.Drawing.Point(12, 76)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1136, 256)
        Me.dgv1.TabIndex = 0
        '
        'rad_us_sale
        '
        Me.rad_us_sale.AutoSize = True
        Me.rad_us_sale.Checked = True
        Me.rad_us_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_us_sale.ForeColor = System.Drawing.Color.Crimson
        Me.rad_us_sale.Location = New System.Drawing.Point(184, 15)
        Me.rad_us_sale.Name = "rad_us_sale"
        Me.rad_us_sale.Size = New System.Drawing.Size(71, 17)
        Me.rad_us_sale.TabIndex = 1
        Me.rad_us_sale.TabStop = True
        Me.rad_us_sale.Text = "US Sale"
        Me.rad_us_sale.UseVisualStyleBackColor = True
        '
        'rad_india_sale
        '
        Me.rad_india_sale.AutoSize = True
        Me.rad_india_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_india_sale.ForeColor = System.Drawing.Color.Crimson
        Me.rad_india_sale.Location = New System.Drawing.Point(254, 15)
        Me.rad_india_sale.Name = "rad_india_sale"
        Me.rad_india_sale.Size = New System.Drawing.Size(132, 17)
        Me.rad_india_sale.TabIndex = 1
        Me.rad_india_sale.Text = "Sale From Janatics"
        Me.rad_india_sale.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.ForeColor = System.Drawing.Color.Crimson
        Me.btn_go.Location = New System.Drawing.Point(935, 13)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(99, 31)
        Me.btn_go.TabIndex = 2
        Me.btn_go.Text = "View Details"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fi Year :"
        '
        'cmb_fin_year
        '
        Me.cmb_fin_year.FormattingEnabled = True
        Me.cmb_fin_year.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021"})
        Me.cmb_fin_year.Location = New System.Drawing.Point(77, 13)
        Me.cmb_fin_year.Name = "cmb_fin_year"
        Me.cmb_fin_year.Size = New System.Drawing.Size(104, 21)
        Me.cmb_fin_year.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rad_itemwise)
        Me.GroupBox1.Controls.Add(Me.rad_Customer_wise)
        Me.GroupBox1.Location = New System.Drawing.Point(403, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 39)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sale Detail For :"
        '
        'rad_itemwise
        '
        Me.rad_itemwise.AutoSize = True
        Me.rad_itemwise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_itemwise.ForeColor = System.Drawing.Color.Crimson
        Me.rad_itemwise.Location = New System.Drawing.Point(145, 16)
        Me.rad_itemwise.Name = "rad_itemwise"
        Me.rad_itemwise.Size = New System.Drawing.Size(85, 17)
        Me.rad_itemwise.TabIndex = 6
        Me.rad_itemwise.Text = "Item Wise "
        Me.rad_itemwise.UseVisualStyleBackColor = True
        '
        'rad_Customer_wise
        '
        Me.rad_Customer_wise.AutoSize = True
        Me.rad_Customer_wise.Checked = True
        Me.rad_Customer_wise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_Customer_wise.ForeColor = System.Drawing.Color.Crimson
        Me.rad_Customer_wise.Location = New System.Drawing.Point(33, 16)
        Me.rad_Customer_wise.Name = "rad_Customer_wise"
        Me.rad_Customer_wise.Size = New System.Drawing.Size(109, 17)
        Me.rad_Customer_wise.TabIndex = 6
        Me.rad_Customer_wise.TabStop = True
        Me.rad_Customer_wise.Text = "Customer Wise"
        Me.rad_Customer_wise.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rad_sale_value)
        Me.GroupBox2.Controls.Add(Me.rad_cog)
        Me.GroupBox2.Controls.Add(Me.rad_sale_qty)
        Me.GroupBox2.Location = New System.Drawing.Point(648, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 39)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sale  Quantity /Value"
        '
        'rad_sale_value
        '
        Me.rad_sale_value.AutoSize = True
        Me.rad_sale_value.Checked = True
        Me.rad_sale_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_sale_value.ForeColor = System.Drawing.Color.Crimson
        Me.rad_sale_value.Location = New System.Drawing.Point(6, 19)
        Me.rad_sale_value.Name = "rad_sale_value"
        Me.rad_sale_value.Size = New System.Drawing.Size(86, 17)
        Me.rad_sale_value.TabIndex = 6
        Me.rad_sale_value.TabStop = True
        Me.rad_sale_value.Text = "Sale Value"
        Me.rad_sale_value.UseVisualStyleBackColor = True
        '
        'rad_cog
        '
        Me.rad_cog.AutoSize = True
        Me.rad_cog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cog.ForeColor = System.Drawing.Color.Crimson
        Me.rad_cog.Location = New System.Drawing.Point(177, 18)
        Me.rad_cog.Name = "rad_cog"
        Me.rad_cog.Size = New System.Drawing.Size(82, 17)
        Me.rad_cog.TabIndex = 6
        Me.rad_cog.Text = "Cog value"
        Me.rad_cog.UseVisualStyleBackColor = True
        '
        'rad_sale_qty
        '
        Me.rad_sale_qty.AutoSize = True
        Me.rad_sale_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_sale_qty.ForeColor = System.Drawing.Color.Crimson
        Me.rad_sale_qty.Location = New System.Drawing.Point(98, 19)
        Me.rad_sale_qty.Name = "rad_sale_qty"
        Me.rad_sale_qty.Size = New System.Drawing.Size(73, 17)
        Me.rad_sale_qty.TabIndex = 6
        Me.rad_sale_qty.Text = "Sale Qty"
        Me.rad_sale_qty.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Region :"
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(77, 49)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(165, 21)
        Me.cmb_region.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(297, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Customer Name :"
        '
        'cmb_customer
        '
        Me.cmb_customer.FormattingEnabled = True
        Me.cmb_customer.Location = New System.Drawing.Point(403, 49)
        Me.cmb_customer.Name = "cmb_customer"
        Me.cmb_customer.Size = New System.Drawing.Size(409, 21)
        Me.cmb_customer.TabIndex = 4
        '
        'US_Sale_with_inr_mplusl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(1160, 339)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmb_customer)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_fin_year)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.rad_india_sale)
        Me.Controls.Add(Me.rad_us_sale)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "US_Sale_with_inr_mplusl"
        Me.Text = "US Sale With  INR MplusL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rad_us_sale As System.Windows.Forms.RadioButton
    Friend WithEvents rad_india_sale As System.Windows.Forms.RadioButton
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_fin_year As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rad_itemwise As RadioButton
    Friend WithEvents rad_Customer_wise As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rad_sale_value As RadioButton
    Friend WithEvents rad_sale_qty As RadioButton
    Friend WithEvents rad_cog As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_region As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_customer As ComboBox
End Class
