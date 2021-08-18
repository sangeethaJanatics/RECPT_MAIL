<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Branch_Price_Rev_editing
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_view_price = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_item_no = New System.Windows.Forms.TextBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_cust_name = New System.Windows.Forms.ComboBox()
        Me.btn_update_price = New System.Windows.Forms.Button()
        Me.txt_new_clp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_delete_item = New System.Windows.Forms.Button()
        Me.btn_delete_customer = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_view_price
        '
        Me.btn_view_price.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btn_view_price.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_price.Location = New System.Drawing.Point(516, 8)
        Me.btn_view_price.Name = "btn_view_price"
        Me.btn_view_price.Size = New System.Drawing.Size(82, 53)
        Me.btn_view_price.TabIndex = 0
        Me.btn_view_price.Text = "View Items"
        Me.btn_view_price.UseVisualStyleBackColor = False
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv1.GridColor = System.Drawing.Color.Gray
        Me.dgv1.Location = New System.Drawing.Point(12, 81)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(776, 290)
        Me.dgv1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(316, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Item no:"
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(367, 13)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(137, 20)
        Me.txt_item_no.TabIndex = 3
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(116, 13)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(194, 21)
        Me.cmb_region.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Region :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Customer Name:"
        '
        'cmb_cust_name
        '
        Me.cmb_cust_name.FormattingEnabled = True
        Me.cmb_cust_name.Location = New System.Drawing.Point(116, 44)
        Me.cmb_cust_name.Name = "cmb_cust_name"
        Me.cmb_cust_name.Size = New System.Drawing.Size(388, 21)
        Me.cmb_cust_name.TabIndex = 6
        '
        'btn_update_price
        '
        Me.btn_update_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_update_price.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btn_update_price.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update_price.Location = New System.Drawing.Point(311, 386)
        Me.btn_update_price.Name = "btn_update_price"
        Me.btn_update_price.Size = New System.Drawing.Size(130, 27)
        Me.btn_update_price.TabIndex = 8
        Me.btn_update_price.Text = "Update New CLP"
        Me.btn_update_price.UseVisualStyleBackColor = False
        '
        'txt_new_clp
        '
        Me.txt_new_clp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_new_clp.Location = New System.Drawing.Point(162, 389)
        Me.txt_new_clp.Name = "txt_new_clp"
        Me.txt_new_clp.Size = New System.Drawing.Size(137, 20)
        Me.txt_new_clp.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(90, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "New CLP:"
        '
        'btn_delete_item
        '
        Me.btn_delete_item.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_delete_item.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btn_delete_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete_item.Location = New System.Drawing.Point(447, 386)
        Me.btn_delete_item.Name = "btn_delete_item"
        Me.btn_delete_item.Size = New System.Drawing.Size(130, 27)
        Me.btn_delete_item.TabIndex = 11
        Me.btn_delete_item.Text = "Delete item"
        Me.btn_delete_item.UseVisualStyleBackColor = False
        '
        'btn_delete_customer
        '
        Me.btn_delete_customer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_delete_customer.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btn_delete_customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete_customer.Location = New System.Drawing.Point(592, 385)
        Me.btn_delete_customer.Name = "btn_delete_customer"
        Me.btn_delete_customer.Size = New System.Drawing.Size(130, 27)
        Me.btn_delete_customer.TabIndex = 12
        Me.btn_delete_customer.Text = "Delete Customer"
        Me.btn_delete_customer.UseVisualStyleBackColor = False
        '
        'Branch_Price_Rev_editing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_delete_customer)
        Me.Controls.Add(Me.btn_delete_item)
        Me.Controls.Add(Me.txt_new_clp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_update_price)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_cust_name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_view_price)
        Me.Name = "Branch_Price_Rev_editing"
        Me.Text = "Branch_Price_Rev_editing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_view_price As Button
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_item_no As TextBox
    Friend WithEvents cmb_region As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_cust_name As ComboBox
    Friend WithEvents btn_update_price As Button
    Friend WithEvents txt_new_clp As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_delete_item As Button
    Friend WithEvents btn_delete_customer As Button
End Class
