<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Non_TOD_items
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.view_non_tod_items = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.txt_item_no = New System.Windows.Forms.TextBox
        Me.btn_add_item = New System.Windows.Forms.Button
        Me.GROUP_BOX1 = New System.Windows.Forms.GroupBox
        Me.btn_enable_TOD = New System.Windows.Forms.Button
        Me.tod_end_date = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dealer_sale_from_dt = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dealer_sale_to_dt = New System.Windows.Forms.DateTimePicker
        Me.btn_view_dealer_sale = New System.Windows.Forms.Button
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GROUP_BOX1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item No :"
        '
        'view_non_tod_items
        '
        Me.view_non_tod_items.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.view_non_tod_items.Location = New System.Drawing.Point(317, 5)
        Me.view_non_tod_items.Name = "view_non_tod_items"
        Me.view_non_tod_items.Size = New System.Drawing.Size(120, 23)
        Me.view_non_tod_items.TabIndex = 1
        Me.view_non_tod_items.Text = "View Non TOD Items"
        Me.view_non_tod_items.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.GridColor = System.Drawing.Color.Gray
        Me.dgv.Location = New System.Drawing.Point(12, 64)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1003, 420)
        Me.dgv.TabIndex = 2
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(80, 8)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(231, 20)
        Me.txt_item_no.TabIndex = 3
        '
        'btn_add_item
        '
        Me.btn_add_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_add_item.Location = New System.Drawing.Point(443, 6)
        Me.btn_add_item.Name = "btn_add_item"
        Me.btn_add_item.Size = New System.Drawing.Size(111, 23)
        Me.btn_add_item.TabIndex = 1
        Me.btn_add_item.Text = "Add Non-TOD Items"
        Me.btn_add_item.UseVisualStyleBackColor = False
        '
        'GROUP_BOX1
        '
        Me.GROUP_BOX1.Controls.Add(Me.btn_enable_TOD)
        Me.GROUP_BOX1.Controls.Add(Me.tod_end_date)
        Me.GROUP_BOX1.Controls.Add(Me.Label2)
        Me.GROUP_BOX1.Location = New System.Drawing.Point(614, 5)
        Me.GROUP_BOX1.Name = "GROUP_BOX1"
        Me.GROUP_BOX1.Size = New System.Drawing.Size(311, 35)
        Me.GROUP_BOX1.TabIndex = 4
        Me.GROUP_BOX1.TabStop = False
        Me.GROUP_BOX1.Text = "TOD item Yes"
        '
        'btn_enable_TOD
        '
        Me.btn_enable_TOD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_enable_TOD.Location = New System.Drawing.Point(200, 9)
        Me.btn_enable_TOD.Name = "btn_enable_TOD"
        Me.btn_enable_TOD.Size = New System.Drawing.Size(111, 23)
        Me.btn_enable_TOD.TabIndex = 7
        Me.btn_enable_TOD.Text = "Make TOD Yes"
        Me.btn_enable_TOD.UseVisualStyleBackColor = False
        '
        'tod_end_date
        '
        Me.tod_end_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tod_end_date.Location = New System.Drawing.Point(99, 12)
        Me.tod_end_date.Name = "tod_end_date"
        Me.tod_end_date.Size = New System.Drawing.Size(96, 20)
        Me.tod_end_date.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Dealer Sale From  Date:"
        '
        'dealer_sale_from_dt
        '
        Me.dealer_sale_from_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dealer_sale_from_dt.Location = New System.Drawing.Point(150, 37)
        Me.dealer_sale_from_dt.Name = "dealer_sale_from_dt"
        Me.dealer_sale_from_dt.Size = New System.Drawing.Size(96, 20)
        Me.dealer_sale_from_dt.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Dealer Sale To Date:"
        '
        'dealer_sale_to_dt
        '
        Me.dealer_sale_to_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dealer_sale_to_dt.Location = New System.Drawing.Point(395, 37)
        Me.dealer_sale_to_dt.Name = "dealer_sale_to_dt"
        Me.dealer_sale_to_dt.Size = New System.Drawing.Size(96, 20)
        Me.dealer_sale_to_dt.TabIndex = 6
        '
        'btn_view_dealer_sale
        '
        Me.btn_view_dealer_sale.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_view_dealer_sale.Location = New System.Drawing.Point(497, 35)
        Me.btn_view_dealer_sale.Name = "btn_view_dealer_sale"
        Me.btn_view_dealer_sale.Size = New System.Drawing.Size(111, 23)
        Me.btn_view_dealer_sale.TabIndex = 1
        Me.btn_view_dealer_sale.Text = "View Dealer Sale"
        Me.btn_view_dealer_sale.UseVisualStyleBackColor = False
        '
        'Non_TOD_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(1027, 496)
        Me.Controls.Add(Me.GROUP_BOX1)
        Me.Controls.Add(Me.dealer_sale_to_dt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dealer_sale_from_dt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btn_view_dealer_sale)
        Me.Controls.Add(Me.btn_add_item)
        Me.Controls.Add(Me.view_non_tod_items)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Non_TOD_items"
        Me.Text = "Non_TOD_items"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GROUP_BOX1.ResumeLayout(False)
        Me.GROUP_BOX1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents view_non_tod_items As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_add_item As System.Windows.Forms.Button
    Friend WithEvents GROUP_BOX1 As System.Windows.Forms.GroupBox
    Friend WithEvents tod_end_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_enable_TOD As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dealer_sale_from_dt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dealer_sale_to_dt As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_view_dealer_sale As System.Windows.Forms.Button
End Class
