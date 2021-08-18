<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Demand_set_MIS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv_main = New System.Windows.Forms.DataGridView
        Me.btn_go = New System.Windows.Forms.Button
        Me.cmb_org = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv_brk = New System.Windows.Forms.DataGridView
        Me.rad_pending = New System.Windows.Forms.RadioButton
        Me.rad_all_items = New System.Windows.Forms.RadioButton
        Me.cmb_item_type = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_item_no = New System.Windows.Forms.TextBox
        Me.rad_accessories = New System.Windows.Forms.RadioButton
        Me.rad_product = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_brk = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_close = New System.Windows.Forms.Button
        Me.btn_show_penidng = New System.Windows.Forms.Button
        Me.txt_week_no = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBL_WEEK_NO = New System.Windows.Forms.Label
        CType(Me.dgv_main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_main
        '
        Me.dgv_main.AllowUserToAddRows = False
        Me.dgv_main.AllowUserToDeleteRows = False
        Me.dgv_main.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_main.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_main.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_main.ColumnHeadersHeight = 50
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_main.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_main.EnableHeadersVisualStyles = False
        Me.dgv_main.Location = New System.Drawing.Point(12, 106)
        Me.dgv_main.Name = "dgv_main"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_main.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_main.RowHeadersVisible = False
        Me.dgv_main.Size = New System.Drawing.Size(409, 417)
        Me.dgv_main.TabIndex = 0
        '
        'btn_go
        '
        Me.btn_go.ForeColor = System.Drawing.Color.Maroon
        Me.btn_go.Location = New System.Drawing.Point(808, 16)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(52, 21)
        Me.btn_go.TabIndex = 1
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'cmb_org
        '
        Me.cmb_org.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_org.FormattingEnabled = True
        Me.cmb_org.Location = New System.Drawing.Point(42, 16)
        Me.cmb_org.Name = "cmb_org"
        Me.cmb_org.Size = New System.Drawing.Size(65, 21)
        Me.cmb_org.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Org :"
        '
        'dgv_brk
        '
        Me.dgv_brk.AllowUserToAddRows = False
        Me.dgv_brk.AllowUserToDeleteRows = False
        Me.dgv_brk.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_brk.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_brk.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_brk.ColumnHeadersHeight = 50
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_brk.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_brk.EnableHeadersVisualStyles = False
        Me.dgv_brk.Location = New System.Drawing.Point(481, 106)
        Me.dgv_brk.Name = "dgv_brk"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_brk.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_brk.RowHeadersVisible = False
        Me.dgv_brk.Size = New System.Drawing.Size(622, 417)
        Me.dgv_brk.TabIndex = 0
        '
        'rad_pending
        '
        Me.rad_pending.AutoSize = True
        Me.rad_pending.Checked = True
        Me.rad_pending.ForeColor = System.Drawing.Color.Maroon
        Me.rad_pending.Location = New System.Drawing.Point(6, 17)
        Me.rad_pending.Name = "rad_pending"
        Me.rad_pending.Size = New System.Drawing.Size(116, 17)
        Me.rad_pending.TabIndex = 4
        Me.rad_pending.TabStop = True
        Me.rad_pending.Text = "Pending Items Only"
        Me.rad_pending.UseVisualStyleBackColor = True
        '
        'rad_all_items
        '
        Me.rad_all_items.AutoSize = True
        Me.rad_all_items.ForeColor = System.Drawing.Color.Maroon
        Me.rad_all_items.Location = New System.Drawing.Point(127, 17)
        Me.rad_all_items.Name = "rad_all_items"
        Me.rad_all_items.Size = New System.Drawing.Size(64, 17)
        Me.rad_all_items.TabIndex = 4
        Me.rad_all_items.Text = "All Items"
        Me.rad_all_items.UseVisualStyleBackColor = True
        '
        'cmb_item_type
        '
        Me.cmb_item_type.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_item_type.FormattingEnabled = True
        Me.cmb_item_type.Items.AddRange(New Object() {"FG", "COMP"})
        Me.cmb_item_type.Location = New System.Drawing.Point(200, 16)
        Me.cmb_item_type.Name = "cmb_item_type"
        Me.cmb_item_type.Size = New System.Drawing.Size(121, 21)
        Me.cmb_item_type.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(134, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Item Type :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_item_no)
        Me.GroupBox1.Controls.Add(Me.rad_accessories)
        Me.GroupBox1.Controls.Add(Me.rad_product)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmb_item_type)
        Me.GroupBox1.Controls.Add(Me.btn_go)
        Me.GroupBox1.Controls.Add(Me.cmb_org)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1075, 48)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(397, 16)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(209, 20)
        Me.txt_item_no.TabIndex = 9
        '
        'rad_accessories
        '
        Me.rad_accessories.AutoSize = True
        Me.rad_accessories.ForeColor = System.Drawing.Color.SaddleBrown
        Me.rad_accessories.Location = New System.Drawing.Point(678, 18)
        Me.rad_accessories.Name = "rad_accessories"
        Me.rad_accessories.Size = New System.Drawing.Size(124, 17)
        Me.rad_accessories.TabIndex = 7
        Me.rad_accessories.Text = "Accessories , Spares"
        Me.rad_accessories.UseVisualStyleBackColor = True
        '
        'rad_product
        '
        Me.rad_product.AutoSize = True
        Me.rad_product.Checked = True
        Me.rad_product.ForeColor = System.Drawing.Color.SaddleBrown
        Me.rad_product.Location = New System.Drawing.Point(612, 18)
        Me.rad_product.Name = "rad_product"
        Me.rad_product.Size = New System.Drawing.Size(62, 17)
        Me.rad_product.TabIndex = 7
        Me.rad_product.TabStop = True
        Me.rad_product.Text = "Product"
        Me.rad_product.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rad_all_items)
        Me.GroupBox2.Controls.Add(Me.rad_pending)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox2.Location = New System.Drawing.Point(866, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 36)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Breakup For"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(341, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Item No :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 15.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(257, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(602, 46)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Demand Set MIS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_brk
        '
        Me.lbl_brk.AutoSize = True
        Me.lbl_brk.ForeColor = System.Drawing.Color.SeaGreen
        Me.lbl_brk.Location = New System.Drawing.Point(734, 91)
        Me.lbl_brk.Name = "lbl_brk"
        Me.lbl_brk.Size = New System.Drawing.Size(0, 13)
        Me.lbl_brk.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label5.Location = New System.Drawing.Point(14, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Click on the cell for breakup"
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.DarkViolet
        Me.lbl_status.Location = New System.Drawing.Point(799, 28)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(0, 13)
        Me.lbl_status.TabIndex = 9
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(1059, 91)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "DS MIS"
        Me.LinkLabel1.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Crimson
        Me.LinkLabel2.Location = New System.Drawing.Point(920, 90)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(128, 13)
        Me.LinkLabel2.TabIndex = 10
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "DS Pending Summary"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.btn_show_penidng)
        Me.Panel1.Controls.Add(Me.txt_week_no)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(640, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 49)
        Me.Panel1.TabIndex = 11
        Me.Panel1.Visible = False
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.Red
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.Location = New System.Drawing.Point(362, -1)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(30, 25)
        Me.btn_close.TabIndex = 3
        Me.btn_close.Text = "X"
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'btn_show_penidng
        '
        Me.btn_show_penidng.Location = New System.Drawing.Point(231, 16)
        Me.btn_show_penidng.Name = "btn_show_penidng"
        Me.btn_show_penidng.Size = New System.Drawing.Size(116, 23)
        Me.btn_show_penidng.TabIndex = 2
        Me.btn_show_penidng.Text = "Show Pending"
        Me.btn_show_penidng.UseVisualStyleBackColor = True
        '
        'txt_week_no
        '
        Me.txt_week_no.Location = New System.Drawing.Point(163, 16)
        Me.txt_week_no.Name = "txt_week_no"
        Me.txt_week_no.Size = New System.Drawing.Size(56, 20)
        Me.txt_week_no.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ds Pendiing upto Week :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( Give week no in 6 digit  )"
        '
        'LBL_WEEK_NO
        '
        Me.LBL_WEEK_NO.AutoSize = True
        Me.LBL_WEEK_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_WEEK_NO.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.LBL_WEEK_NO.Location = New System.Drawing.Point(833, 8)
        Me.LBL_WEEK_NO.Name = "LBL_WEEK_NO"
        Me.LBL_WEEK_NO.Size = New System.Drawing.Size(168, 13)
        Me.LBL_WEEK_NO.TabIndex = 9
        Me.LBL_WEEK_NO.Text = "Click on the cell for breakup"
        '
        'Demand_set_MIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1115, 530)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.LBL_WEEK_NO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_brk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_brk)
        Me.Controls.Add(Me.dgv_main)
        Me.Name = "Demand_set_MIS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demand Set MIS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv_main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_main As System.Windows.Forms.DataGridView
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents cmb_org As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_brk As System.Windows.Forms.DataGridView
    Friend WithEvents rad_pending As System.Windows.Forms.RadioButton
    Friend WithEvents rad_all_items As System.Windows.Forms.RadioButton
    Friend WithEvents cmb_item_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_brk As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
    Friend WithEvents rad_accessories As System.Windows.Forms.RadioButton
    Friend WithEvents rad_product As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_show_penidng As System.Windows.Forms.Button
    Friend WithEvents txt_week_no As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents LBL_WEEK_NO As System.Windows.Forms.Label
End Class
