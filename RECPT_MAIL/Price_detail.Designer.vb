<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Price_detail
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
        Me.btn_view_price = New System.Windows.Forms.Button()
        Me.cmb_price_list_name = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_cust_name = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_part_no = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.from_dt = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.to_dt = New System.Windows.Forms.DateTimePicker()
        Me.chk_date = New System.Windows.Forms.CheckBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_view_price
        '
        Me.btn_view_price.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btn_view_price.Location = New System.Drawing.Point(818, 5)
        Me.btn_view_price.Name = "btn_view_price"
        Me.btn_view_price.Size = New System.Drawing.Size(112, 56)
        Me.btn_view_price.TabIndex = 0
        Me.btn_view_price.Text = "View Price"
        Me.btn_view_price.UseVisualStyleBackColor = False
        '
        'cmb_price_list_name
        '
        Me.cmb_price_list_name.FormattingEnabled = True
        Me.cmb_price_list_name.Location = New System.Drawing.Point(106, 5)
        Me.cmb_price_list_name.Name = "cmb_price_list_name"
        Me.cmb_price_list_name.Size = New System.Drawing.Size(325, 21)
        Me.cmb_price_list_name.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Price List Name :"
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.EnableHeadersVisualStyles = False
        Me.dgv1.Location = New System.Drawing.Point(13, 86)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(997, 352)
        Me.dgv1.TabIndex = 3
        '
        'cmb_region
        '
        Me.cmb_region.Enabled = False
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(493, 5)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(137, 21)
        Me.cmb_region.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(445, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Region :"
        '
        'cmb_cust_name
        '
        Me.cmb_cust_name.Enabled = False
        Me.cmb_cust_name.FormattingEnabled = True
        Me.cmb_cust_name.Location = New System.Drawing.Point(106, 40)
        Me.cmb_cust_name.Name = "cmb_cust_name"
        Me.cmb_cust_name.Size = New System.Drawing.Size(325, 21)
        Me.cmb_cust_name.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customer Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(445, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Part No :"
        '
        'txt_part_no
        '
        Me.txt_part_no.Location = New System.Drawing.Point(495, 40)
        Me.txt_part_no.Name = "txt_part_no"
        Me.txt_part_no.Size = New System.Drawing.Size(135, 20)
        Me.txt_part_no.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(648, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "From Date :"
        '
        'from_dt
        '
        Me.from_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.from_dt.Location = New System.Drawing.Point(706, 5)
        Me.from_dt.Name = "from_dt"
        Me.from_dt.Size = New System.Drawing.Size(104, 20)
        Me.from_dt.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(648, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "To Date :"
        '
        'to_dt
        '
        Me.to_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.to_dt.Location = New System.Drawing.Point(706, 40)
        Me.to_dt.Name = "to_dt"
        Me.to_dt.Size = New System.Drawing.Size(104, 20)
        Me.to_dt.TabIndex = 5
        '
        'chk_date
        '
        Me.chk_date.AutoSize = True
        Me.chk_date.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.chk_date.Location = New System.Drawing.Point(703, 65)
        Me.chk_date.Name = "chk_date"
        Me.chk_date.Size = New System.Drawing.Size(93, 17)
        Me.chk_date.TabIndex = 6
        Me.chk_date.Text = "Consider Date"
        Me.chk_date.UseVisualStyleBackColor = True
        '
        'Price_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(1020, 450)
        Me.Controls.Add(Me.chk_date)
        Me.Controls.Add(Me.to_dt)
        Me.Controls.Add(Me.from_dt)
        Me.Controls.Add(Me.txt_part_no)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_cust_name)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.cmb_price_list_name)
        Me.Controls.Add(Me.btn_view_price)
        Me.Name = "Price_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price_detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_view_price As Button
    Friend WithEvents cmb_price_list_name As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents cmb_region As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_cust_name As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_part_no As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents from_dt As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents to_dt As DateTimePicker
    Friend WithEvents chk_date As CheckBox
End Class
