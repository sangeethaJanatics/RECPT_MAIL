<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AMS_PENDING_IN_ORDER_PENDING
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_go = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv1_Dealer = New System.Windows.Forms.DataGridView
        Me.cmb_ofd = New System.Windows.Forms.ComboBox
        Me.chk_ofd = New System.Windows.Forms.CheckBox
        Me.rad_Dealer = New System.Windows.Forms.RadioButton
        Me.rad_customer = New System.Windows.Forms.RadioButton
        Me.rad_consolidation = New System.Windows.Forms.RadioButton
        Me.cmb_region = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_item_no = New System.Windows.Forms.TextBox
        CType(Me.dgv1_Dealer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(952, 12)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(37, 21)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(447, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OFD Week:"
        '
        'dgv1_Dealer
        '
        Me.dgv1_Dealer.AllowUserToAddRows = False
        Me.dgv1_Dealer.AllowUserToDeleteRows = False
        Me.dgv1_Dealer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1_Dealer.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1_Dealer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1_Dealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1_Dealer.EnableHeadersVisualStyles = False
        Me.dgv1_Dealer.Location = New System.Drawing.Point(12, 43)
        Me.dgv1_Dealer.Name = "dgv1_Dealer"
        Me.dgv1_Dealer.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1_Dealer.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv1_Dealer.RowHeadersVisible = False
        Me.dgv1_Dealer.Size = New System.Drawing.Size(997, 400)
        Me.dgv1_Dealer.TabIndex = 2
        '
        'cmb_ofd
        '
        Me.cmb_ofd.FormattingEnabled = True
        Me.cmb_ofd.Location = New System.Drawing.Point(517, 12)
        Me.cmb_ofd.Name = "cmb_ofd"
        Me.cmb_ofd.Size = New System.Drawing.Size(121, 21)
        Me.cmb_ofd.TabIndex = 3
        '
        'chk_ofd
        '
        Me.chk_ofd.AutoSize = True
        Me.chk_ofd.Location = New System.Drawing.Point(647, 14)
        Me.chk_ofd.Name = "chk_ofd"
        Me.chk_ofd.Size = New System.Drawing.Size(81, 17)
        Me.chk_ofd.TabIndex = 4
        Me.chk_ofd.Text = "Upto Week"
        Me.chk_ofd.UseVisualStyleBackColor = True
        '
        'rad_Dealer
        '
        Me.rad_Dealer.AutoSize = True
        Me.rad_Dealer.Checked = True
        Me.rad_Dealer.Location = New System.Drawing.Point(734, 14)
        Me.rad_Dealer.Name = "rad_Dealer"
        Me.rad_Dealer.Size = New System.Drawing.Size(56, 17)
        Me.rad_Dealer.TabIndex = 5
        Me.rad_Dealer.TabStop = True
        Me.rad_Dealer.Text = "Dealer"
        Me.rad_Dealer.UseVisualStyleBackColor = True
        '
        'rad_customer
        '
        Me.rad_customer.AutoSize = True
        Me.rad_customer.Location = New System.Drawing.Point(792, 14)
        Me.rad_customer.Name = "rad_customer"
        Me.rad_customer.Size = New System.Drawing.Size(69, 17)
        Me.rad_customer.TabIndex = 5
        Me.rad_customer.Text = "Customer"
        Me.rad_customer.UseVisualStyleBackColor = True
        '
        'rad_consolidation
        '
        Me.rad_consolidation.AutoSize = True
        Me.rad_consolidation.Location = New System.Drawing.Point(862, 14)
        Me.rad_consolidation.Name = "rad_consolidation"
        Me.rad_consolidation.Size = New System.Drawing.Size(88, 17)
        Me.rad_consolidation.TabIndex = 5
        Me.rad_consolidation.Text = "Consolidation"
        Me.rad_consolidation.UseVisualStyleBackColor = True
        '
        'cmb_region
        '
        Me.cmb_region.ForeColor = System.Drawing.Color.Crimson
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(78, 14)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(139, 21)
        Me.cmb_region.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(17, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Region :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(223, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Item No:"
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(284, 14)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(157, 20)
        Me.txt_item_no.TabIndex = 8
        '
        'AMS_PENDING_IN_ORDER_PENDING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(1012, 455)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rad_consolidation)
        Me.Controls.Add(Me.rad_customer)
        Me.Controls.Add(Me.rad_Dealer)
        Me.Controls.Add(Me.chk_ofd)
        Me.Controls.Add(Me.cmb_ofd)
        Me.Controls.Add(Me.dgv1_Dealer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "AMS_PENDING_IN_ORDER_PENDING"
        Me.Text = "In AMS Pending --  For the Pending Orders"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1_Dealer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv1_Dealer As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_ofd As System.Windows.Forms.ComboBox
    Friend WithEvents chk_ofd As System.Windows.Forms.CheckBox
    Friend WithEvents rad_Dealer As System.Windows.Forms.RadioButton
    Friend WithEvents rad_customer As System.Windows.Forms.RadioButton
    Friend WithEvents rad_consolidation As System.Windows.Forms.RadioButton
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
End Class
