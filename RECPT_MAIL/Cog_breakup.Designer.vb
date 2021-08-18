<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cog_breakup
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.cmb_product_group = New System.Windows.Forms.ComboBox()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_class_code = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_make_buy = New System.Windows.Forms.ComboBox()
        Me.btn_item_brk = New System.Windows.Forms.Button()
        Me.dgv_brk = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_fin_year = New System.Windows.Forms.ComboBox()
        Me.rad_mplusl_31mar2018 = New System.Windows.Forms.RadioButton()
        Me.rad_mplul_mar2016 = New System.Windows.Forms.RadioButton()
        Me.RAD_CURRENT_MPLUSL = New System.Windows.Forms.RadioButton()
        Me.rad_mplusl_ason31mar2019 = New System.Windows.Forms.RadioButton()
        Me.rad_mplusl_mar2020 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ddl_MplusL = New System.Windows.Forms.ComboBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Group :"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv1.EnableHeadersVisualStyles = False
        Me.dgv1.Location = New System.Drawing.Point(5, 101)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(1104, 238)
        Me.dgv1.TabIndex = 1
        '
        'cmb_product_group
        '
        Me.cmb_product_group.FormattingEnabled = True
        Me.cmb_product_group.Location = New System.Drawing.Point(100, 15)
        Me.cmb_product_group.Name = "cmb_product_group"
        Me.cmb_product_group.Size = New System.Drawing.Size(299, 21)
        Me.cmb_product_group.TabIndex = 2
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.Gainsboro
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.Location = New System.Drawing.Point(939, 4)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(170, 23)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "view cust wise Breakup"
        Me.btn_go.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(401, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Region :"
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(457, 15)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(121, 21)
        Me.cmb_region.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(585, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Class Code :"
        '
        'cmb_class_code
        '
        Me.cmb_class_code.FormattingEnabled = True
        Me.cmb_class_code.Location = New System.Drawing.Point(663, 15)
        Me.cmb_class_code.Name = "cmb_class_code"
        Me.cmb_class_code.Size = New System.Drawing.Size(105, 21)
        Me.cmb_class_code.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(773, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Make Buy :"
        '
        'cmb_make_buy
        '
        Me.cmb_make_buy.FormattingEnabled = True
        Me.cmb_make_buy.Location = New System.Drawing.Point(846, 15)
        Me.cmb_make_buy.Name = "cmb_make_buy"
        Me.cmb_make_buy.Size = New System.Drawing.Size(88, 21)
        Me.cmb_make_buy.TabIndex = 2
        '
        'btn_item_brk
        '
        Me.btn_item_brk.BackColor = System.Drawing.Color.Gainsboro
        Me.btn_item_brk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_item_brk.Location = New System.Drawing.Point(939, 32)
        Me.btn_item_brk.Name = "btn_item_brk"
        Me.btn_item_brk.Size = New System.Drawing.Size(170, 23)
        Me.btn_item_brk.TabIndex = 3
        Me.btn_item_brk.Text = "View  Item - wise Breakup"
        Me.btn_item_brk.UseVisualStyleBackColor = False
        '
        'dgv_brk
        '
        Me.dgv_brk.AllowUserToAddRows = False
        Me.dgv_brk.AllowUserToDeleteRows = False
        Me.dgv_brk.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_brk.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_brk.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_brk.EnableHeadersVisualStyles = False
        Me.dgv_brk.Location = New System.Drawing.Point(5, 355)
        Me.dgv_brk.Name = "dgv_brk"
        Me.dgv_brk.Size = New System.Drawing.Size(1104, 152)
        Me.dgv_brk.TabIndex = 4
        Me.dgv_brk.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(795, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fin Yr :"
        '
        'cmb_fin_year
        '
        Me.cmb_fin_year.FormattingEnabled = True
        Me.cmb_fin_year.Location = New System.Drawing.Point(846, 35)
        Me.cmb_fin_year.Name = "cmb_fin_year"
        Me.cmb_fin_year.Size = New System.Drawing.Size(88, 21)
        Me.cmb_fin_year.TabIndex = 2
        '
        'rad_mplusl_31mar2018
        '
        Me.rad_mplusl_31mar2018.AutoSize = True
        Me.rad_mplusl_31mar2018.Location = New System.Drawing.Point(187, 42)
        Me.rad_mplusl_31mar2018.Name = "rad_mplusl_31mar2018"
        Me.rad_mplusl_31mar2018.Size = New System.Drawing.Size(162, 17)
        Me.rad_mplusl_31mar2018.TabIndex = 9
        Me.rad_mplusl_31mar2018.Text = "MplusL based on 31mar2018"
        Me.rad_mplusl_31mar2018.UseVisualStyleBackColor = True
        '
        'rad_mplul_mar2016
        '
        Me.rad_mplul_mar2016.AutoSize = True
        Me.rad_mplul_mar2016.Checked = True
        Me.rad_mplul_mar2016.Location = New System.Drawing.Point(22, 42)
        Me.rad_mplul_mar2016.Name = "rad_mplul_mar2016"
        Me.rad_mplul_mar2016.Size = New System.Drawing.Size(162, 17)
        Me.rad_mplul_mar2016.TabIndex = 8
        Me.rad_mplul_mar2016.TabStop = True
        Me.rad_mplul_mar2016.Text = "MplusL based on 31mar2016"
        Me.rad_mplul_mar2016.UseVisualStyleBackColor = True
        '
        'RAD_CURRENT_MPLUSL
        '
        Me.RAD_CURRENT_MPLUSL.AutoSize = True
        Me.RAD_CURRENT_MPLUSL.Location = New System.Drawing.Point(702, 39)
        Me.RAD_CURRENT_MPLUSL.Name = "RAD_CURRENT_MPLUSL"
        Me.RAD_CURRENT_MPLUSL.Size = New System.Drawing.Size(96, 17)
        Me.RAD_CURRENT_MPLUSL.TabIndex = 9
        Me.RAD_CURRENT_MPLUSL.Text = "Current MplusL"
        Me.RAD_CURRENT_MPLUSL.UseVisualStyleBackColor = True
        '
        'rad_mplusl_ason31mar2019
        '
        Me.rad_mplusl_ason31mar2019.AutoSize = True
        Me.rad_mplusl_ason31mar2019.Location = New System.Drawing.Point(349, 42)
        Me.rad_mplusl_ason31mar2019.Name = "rad_mplusl_ason31mar2019"
        Me.rad_mplusl_ason31mar2019.Size = New System.Drawing.Size(162, 17)
        Me.rad_mplusl_ason31mar2019.TabIndex = 10
        Me.rad_mplusl_ason31mar2019.Text = "MplusL based on 31mar2019"
        Me.rad_mplusl_ason31mar2019.UseVisualStyleBackColor = True
        '
        'rad_mplusl_mar2020
        '
        Me.rad_mplusl_mar2020.AutoSize = True
        Me.rad_mplusl_mar2020.Location = New System.Drawing.Point(517, 41)
        Me.rad_mplusl_mar2020.Name = "rad_mplusl_mar2020"
        Me.rad_mplusl_mar2020.Size = New System.Drawing.Size(162, 17)
        Me.rad_mplusl_mar2020.TabIndex = 10
        Me.rad_mplusl_mar2020.Text = "MplusL based on 31mar2020"
        Me.rad_mplusl_mar2020.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(542, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "M plus L ason :"
        '
        'ddl_MplusL
        '
        Me.ddl_MplusL.FormattingEnabled = True
        Me.ddl_MplusL.Items.AddRange(New Object() {"MplusL based on 31mar2016", "MplusL based on 31mar2018", "MplusL based on 31mar2019", "MplusL based on 31mar2020", "MplusL based on 31mar2021", "Current MplusL"})
        Me.ddl_MplusL.Location = New System.Drawing.Point(642, 70)
        Me.ddl_MplusL.Name = "ddl_MplusL"
        Me.ddl_MplusL.Size = New System.Drawing.Size(309, 21)
        Me.ddl_MplusL.TabIndex = 2
        '
        'Cog_breakup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(1121, 509)
        Me.Controls.Add(Me.rad_mplusl_mar2020)
        Me.Controls.Add(Me.rad_mplusl_ason31mar2019)
        Me.Controls.Add(Me.RAD_CURRENT_MPLUSL)
        Me.Controls.Add(Me.rad_mplusl_31mar2018)
        Me.Controls.Add(Me.rad_mplul_mar2016)
        Me.Controls.Add(Me.dgv_brk)
        Me.Controls.Add(Me.btn_item_brk)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.cmb_fin_year)
        Me.Controls.Add(Me.ddl_MplusL)
        Me.Controls.Add(Me.cmb_make_buy)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.cmb_class_code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmb_product_group)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Cog_breakup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cog_breakup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_product_group As System.Windows.Forms.ComboBox
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_class_code As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_make_buy As System.Windows.Forms.ComboBox
    Friend WithEvents btn_item_brk As System.Windows.Forms.Button
    Friend WithEvents dgv_brk As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_fin_year As System.Windows.Forms.ComboBox
    Friend WithEvents rad_mplusl_31mar2018 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_mplul_mar2016 As System.Windows.Forms.RadioButton
    Friend WithEvents RAD_CURRENT_MPLUSL As System.Windows.Forms.RadioButton
    Friend WithEvents rad_mplusl_ason31mar2019 As RadioButton
    Friend WithEvents rad_mplusl_mar2020 As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents ddl_MplusL As ComboBox
End Class
