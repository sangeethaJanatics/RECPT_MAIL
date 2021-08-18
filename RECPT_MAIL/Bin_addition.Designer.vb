<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bin_addition
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_sheet_name = New System.Windows.Forms.TextBox()
        Me.txt_file_name = New System.Windows.Forms.TextBox()
        Me.btn_view_list = New System.Windows.Forms.Button()
        Me.btn_move_to_oracle = New System.Windows.Forms.Button()
        Me.btn_select_file = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.rad_item_specific = New System.Windows.Forms.RadioButton()
        Me.rad_all_items = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_custname = New System.Windows.Forms.ComboBox()
        Me.btn_view_site = New System.Windows.Forms.Button()
        Me.dgv_site_details = New System.Windows.Forms.DataGridView()
        Me.btn_view_bin = New System.Windows.Forms.Button()
        Me.btn_end_all_bin = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_item_end_bin = New System.Windows.Forms.TextBox()
        Me.btn_end_item_bin = New System.Windows.Forms.Button()
        Me.rad_all_new_bin = New System.Windows.Forms.RadioButton()
        Me.btn_active_bin = New System.Windows.Forms.Button()
        Me.btn_view_active_bin_cust = New System.Windows.Forms.Button()
        Me.btn_bin_revision_detail = New System.Windows.Forms.Button()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_site_details, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(439, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sheet Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(89, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "File Name :"
        '
        'txt_sheet_name
        '
        Me.txt_sheet_name.Location = New System.Drawing.Point(526, 6)
        Me.txt_sheet_name.Name = "txt_sheet_name"
        Me.txt_sheet_name.Size = New System.Drawing.Size(156, 20)
        Me.txt_sheet_name.TabIndex = 8
        '
        'txt_file_name
        '
        Me.txt_file_name.Location = New System.Drawing.Point(173, 6)
        Me.txt_file_name.Name = "txt_file_name"
        Me.txt_file_name.Size = New System.Drawing.Size(255, 20)
        Me.txt_file_name.TabIndex = 9
        '
        'btn_view_list
        '
        Me.btn_view_list.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_view_list.BackColor = System.Drawing.Color.Azure
        Me.btn_view_list.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_list.ForeColor = System.Drawing.Color.SteelBlue
        Me.btn_view_list.Location = New System.Drawing.Point(734, 383)
        Me.btn_view_list.Name = "btn_view_list"
        Me.btn_view_list.Size = New System.Drawing.Size(127, 23)
        Me.btn_view_list.TabIndex = 5
        Me.btn_view_list.Text = "View XL list"
        Me.btn_view_list.UseVisualStyleBackColor = False
        '
        'btn_move_to_oracle
        '
        Me.btn_move_to_oracle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_move_to_oracle.BackColor = System.Drawing.Color.Azure
        Me.btn_move_to_oracle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_move_to_oracle.ForeColor = System.Drawing.Color.SteelBlue
        Me.btn_move_to_oracle.Location = New System.Drawing.Point(867, 383)
        Me.btn_move_to_oracle.Name = "btn_move_to_oracle"
        Me.btn_move_to_oracle.Size = New System.Drawing.Size(128, 23)
        Me.btn_move_to_oracle.TabIndex = 6
        Me.btn_move_to_oracle.Text = "Update Bin Qty"
        Me.btn_move_to_oracle.UseVisualStyleBackColor = False
        '
        'btn_select_file
        '
        Me.btn_select_file.BackColor = System.Drawing.Color.Azure
        Me.btn_select_file.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_select_file.ForeColor = System.Drawing.Color.SteelBlue
        Me.btn_select_file.Location = New System.Drawing.Point(689, 5)
        Me.btn_select_file.Name = "btn_select_file"
        Me.btn_select_file.Size = New System.Drawing.Size(75, 23)
        Me.btn_select_file.TabIndex = 7
        Me.btn_select_file.Text = "Select File"
        Me.btn_select_file.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(22, 98)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(973, 281)
        Me.DataGridView1.TabIndex = 4
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'rad_item_specific
        '
        Me.rad_item_specific.AutoSize = True
        Me.rad_item_specific.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_item_specific.ForeColor = System.Drawing.Color.SteelBlue
        Me.rad_item_specific.Location = New System.Drawing.Point(21, 56)
        Me.rad_item_specific.Name = "rad_item_specific"
        Me.rad_item_specific.Size = New System.Drawing.Size(149, 17)
        Me.rad_item_specific.TabIndex = 12
        Me.rad_item_specific.Text = "Revise this Items only"
        Me.rad_item_specific.UseVisualStyleBackColor = True
        '
        'rad_all_items
        '
        Me.rad_all_items.AutoSize = True
        Me.rad_all_items.Checked = True
        Me.rad_all_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_all_items.ForeColor = System.Drawing.Color.SteelBlue
        Me.rad_all_items.Location = New System.Drawing.Point(176, 56)
        Me.rad_all_items.Name = "rad_all_items"
        Me.rad_all_items.Size = New System.Drawing.Size(115, 17)
        Me.rad_all_items.TabIndex = 12
        Me.rad_all_items.TabStop = True
        Me.rad_all_items.Text = "Revise all Items"
        Me.rad_all_items.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 414)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Customer Name :"
        '
        'cmb_custname
        '
        Me.cmb_custname.FormattingEnabled = True
        Me.cmb_custname.Location = New System.Drawing.Point(113, 410)
        Me.cmb_custname.Name = "cmb_custname"
        Me.cmb_custname.Size = New System.Drawing.Size(337, 21)
        Me.cmb_custname.TabIndex = 14
        '
        'btn_view_site
        '
        Me.btn_view_site.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btn_view_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_site.Location = New System.Drawing.Point(453, 409)
        Me.btn_view_site.Name = "btn_view_site"
        Me.btn_view_site.Size = New System.Drawing.Size(122, 23)
        Me.btn_view_site.TabIndex = 15
        Me.btn_view_site.Text = "View Site Details"
        Me.btn_view_site.UseVisualStyleBackColor = False
        '
        'dgv_site_details
        '
        Me.dgv_site_details.AllowUserToAddRows = False
        Me.dgv_site_details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_site_details.BackgroundColor = System.Drawing.Color.White
        Me.dgv_site_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_site_details.Location = New System.Drawing.Point(12, 455)
        Me.dgv_site_details.Name = "dgv_site_details"
        Me.dgv_site_details.ReadOnly = True
        Me.dgv_site_details.Size = New System.Drawing.Size(1040, 54)
        Me.dgv_site_details.TabIndex = 16
        '
        'btn_view_bin
        '
        Me.btn_view_bin.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btn_view_bin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_bin.Location = New System.Drawing.Point(573, 409)
        Me.btn_view_bin.Name = "btn_view_bin"
        Me.btn_view_bin.Size = New System.Drawing.Size(122, 23)
        Me.btn_view_bin.TabIndex = 15
        Me.btn_view_bin.Text = "View Bin Details"
        Me.btn_view_bin.UseVisualStyleBackColor = False
        '
        'btn_end_all_bin
        '
        Me.btn_end_all_bin.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btn_end_all_bin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_end_all_bin.Location = New System.Drawing.Point(693, 409)
        Me.btn_end_all_bin.Name = "btn_end_all_bin"
        Me.btn_end_all_bin.Size = New System.Drawing.Size(111, 23)
        Me.btn_end_all_bin.TabIndex = 15
        Me.btn_end_all_bin.Text = "End All Item Bin"
        Me.btn_end_all_bin.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 436)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Item No:"
        '
        'txt_item_end_bin
        '
        Me.txt_item_end_bin.Location = New System.Drawing.Point(113, 432)
        Me.txt_item_end_bin.Name = "txt_item_end_bin"
        Me.txt_item_end_bin.Size = New System.Drawing.Size(224, 20)
        Me.txt_item_end_bin.TabIndex = 18
        '
        'btn_end_item_bin
        '
        Me.btn_end_item_bin.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btn_end_item_bin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_end_item_bin.Location = New System.Drawing.Point(345, 429)
        Me.btn_end_item_bin.Name = "btn_end_item_bin"
        Me.btn_end_item_bin.Size = New System.Drawing.Size(162, 27)
        Me.btn_end_item_bin.TabIndex = 15
        Me.btn_end_item_bin.Text = "End Customer Item Bin"
        Me.btn_end_item_bin.UseVisualStyleBackColor = False
        '
        'rad_all_new_bin
        '
        Me.rad_all_new_bin.AutoSize = True
        Me.rad_all_new_bin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_all_new_bin.ForeColor = System.Drawing.Color.SteelBlue
        Me.rad_all_new_bin.Location = New System.Drawing.Point(297, 56)
        Me.rad_all_new_bin.Name = "rad_all_new_bin"
        Me.rad_all_new_bin.Size = New System.Drawing.Size(139, 17)
        Me.rad_all_new_bin.TabIndex = 12
        Me.rad_all_new_bin.Text = "Add New item in Bin"
        Me.rad_all_new_bin.UseVisualStyleBackColor = True
        '
        'btn_active_bin
        '
        Me.btn_active_bin.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btn_active_bin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_active_bin.Location = New System.Drawing.Point(804, 409)
        Me.btn_active_bin.Name = "btn_active_bin"
        Me.btn_active_bin.Size = New System.Drawing.Size(129, 23)
        Me.btn_active_bin.TabIndex = 15
        Me.btn_active_bin.Text = "Mark  Active  Bin"
        Me.btn_active_bin.UseVisualStyleBackColor = False
        '
        'btn_view_active_bin_cust
        '
        Me.btn_view_active_bin_cust.BackColor = System.Drawing.Color.Azure
        Me.btn_view_active_bin_cust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_active_bin_cust.ForeColor = System.Drawing.Color.SteelBlue
        Me.btn_view_active_bin_cust.Location = New System.Drawing.Point(466, 53)
        Me.btn_view_active_bin_cust.Name = "btn_view_active_bin_cust"
        Me.btn_view_active_bin_cust.Size = New System.Drawing.Size(171, 23)
        Me.btn_view_active_bin_cust.TabIndex = 7
        Me.btn_view_active_bin_cust.Text = "View Active Bin Customer"
        Me.btn_view_active_bin_cust.UseVisualStyleBackColor = False
        '
        'btn_bin_revision_detail
        '
        Me.btn_bin_revision_detail.BackColor = System.Drawing.Color.Azure
        Me.btn_bin_revision_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bin_revision_detail.ForeColor = System.Drawing.Color.SteelBlue
        Me.btn_bin_revision_detail.Location = New System.Drawing.Point(193, 18)
        Me.btn_bin_revision_detail.Name = "btn_bin_revision_detail"
        Me.btn_bin_revision_detail.Size = New System.Drawing.Size(171, 23)
        Me.btn_bin_revision_detail.TabIndex = 7
        Me.btn_bin_revision_detail.Text = "Sale Detail for Bin Revision "
        Me.btn_bin_revision_detail.UseVisualStyleBackColor = False
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(66, 19)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(121, 21)
        Me.cmb_region.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(6, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Region :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_bin_revision_detail)
        Me.GroupBox1.Controls.Add(Me.cmb_region)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(659, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 58)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details to Revision Bin"
        '
        'Bin_addition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(1064, 511)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_item_end_bin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_site_details)
        Me.Controls.Add(Me.btn_end_item_bin)
        Me.Controls.Add(Me.btn_active_bin)
        Me.Controls.Add(Me.btn_end_all_bin)
        Me.Controls.Add(Me.btn_view_bin)
        Me.Controls.Add(Me.btn_view_site)
        Me.Controls.Add(Me.cmb_custname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rad_all_new_bin)
        Me.Controls.Add(Me.rad_all_items)
        Me.Controls.Add(Me.rad_item_specific)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_sheet_name)
        Me.Controls.Add(Me.txt_file_name)
        Me.Controls.Add(Me.btn_view_list)
        Me.Controls.Add(Me.btn_move_to_oracle)
        Me.Controls.Add(Me.btn_view_active_bin_cust)
        Me.Controls.Add(Me.btn_select_file)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Bin_addition"
        Me.Text = "Bin Addition"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_site_details, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_sheet_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_file_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_view_list As System.Windows.Forms.Button
    Friend WithEvents btn_move_to_oracle As System.Windows.Forms.Button
    Friend WithEvents btn_select_file As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents rad_item_specific As System.Windows.Forms.RadioButton
    Friend WithEvents rad_all_items As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_custname As System.Windows.Forms.ComboBox
    Friend WithEvents btn_view_site As System.Windows.Forms.Button
    Friend WithEvents dgv_site_details As System.Windows.Forms.DataGridView
    Friend WithEvents btn_view_bin As System.Windows.Forms.Button
    Friend WithEvents btn_end_all_bin As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_item_end_bin As System.Windows.Forms.TextBox
    Friend WithEvents btn_end_item_bin As System.Windows.Forms.Button
    Friend WithEvents rad_all_new_bin As RadioButton
    Friend WithEvents btn_active_bin As Button
    Friend WithEvents btn_view_active_bin_cust As Button
    Friend WithEvents btn_bin_revision_detail As Button
    Friend WithEvents cmb_region As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
