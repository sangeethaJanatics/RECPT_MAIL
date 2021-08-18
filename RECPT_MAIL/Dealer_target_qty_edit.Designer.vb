<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dealer_target_qty_edit
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.cmb_dealer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_qtrid = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMB_PROD_GROUP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMB_ORG = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_gate1_val = New System.Windows.Forms.TextBox()
        Me.btn_gate1_value_update = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_view_DSP_val = New System.Windows.Forms.Button()
        Me.btn_acct_stmt = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btn_ = New System.Windows.Forms.Button()
        Me.btn_exted_DSP_date = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_dsp_id = New System.Windows.Forms.ComboBox()
        Me.dgv_acct_stmt = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_acct_stmt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(391, 41)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(92, 23)
        Me.btn_update.TabIndex = 0
        Me.btn_update.Text = "Update Gate 2"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dealer Name :"
        '
        'txt_qty
        '
        Me.txt_qty.Location = New System.Drawing.Point(324, 42)
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.Size = New System.Drawing.Size(61, 20)
        Me.txt_qty.TabIndex = 2
        '
        'cmb_dealer
        '
        Me.cmb_dealer.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_dealer.FormattingEnabled = True
        Me.cmb_dealer.Location = New System.Drawing.Point(97, 31)
        Me.cmb_dealer.Name = "cmb_dealer"
        Me.cmb_dealer.Size = New System.Drawing.Size(359, 21)
        Me.cmb_dealer.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Qtr ID :"
        '
        'cmb_qtrid
        '
        Me.cmb_qtrid.FormattingEnabled = True
        Me.cmb_qtrid.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cmb_qtrid.Location = New System.Drawing.Point(85, 42)
        Me.cmb_qtrid.Name = "cmb_qtrid"
        Me.cmb_qtrid.Size = New System.Drawing.Size(48, 21)
        Me.cmb_qtrid.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Qty to Revise :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Product Group :"
        '
        'CMB_PROD_GROUP
        '
        Me.CMB_PROD_GROUP.FormattingEnabled = True
        Me.CMB_PROD_GROUP.Location = New System.Drawing.Point(106, 16)
        Me.CMB_PROD_GROUP.Name = "CMB_PROD_GROUP"
        Me.CMB_PROD_GROUP.Size = New System.Drawing.Size(359, 21)
        Me.CMB_PROD_GROUP.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Org :"
        '
        'CMB_ORG
        '
        Me.CMB_ORG.FormattingEnabled = True
        Me.CMB_ORG.Items.AddRange(New Object() {"I22", "I23", "I24", "I25"})
        Me.CMB_ORG.Location = New System.Drawing.Point(175, 42)
        Me.CMB_ORG.Name = "CMB_ORG"
        Me.CMB_ORG.Size = New System.Drawing.Size(48, 21)
        Me.CMB_ORG.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Controls.Add(Me.btn_update)
        Me.GroupBox1.Controls.Add(Me.CMB_PROD_GROUP)
        Me.GroupBox1.Controls.Add(Me.txt_qty)
        Me.GroupBox1.Controls.Add(Me.CMB_ORG)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_qtrid)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 74)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gate 2"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.SeaShell
        Me.GroupBox2.Controls.Add(Me.txt_gate1_val)
        Me.GroupBox2.Controls.Add(Me.btn_gate1_value_update)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ComboBox3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(517, 57)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gate 1"
        '
        'txt_gate1_val
        '
        Me.txt_gate1_val.Location = New System.Drawing.Point(111, 23)
        Me.txt_gate1_val.Name = "txt_gate1_val"
        Me.txt_gate1_val.Size = New System.Drawing.Size(71, 20)
        Me.txt_gate1_val.TabIndex = 4
        '
        'btn_gate1_value_update
        '
        Me.btn_gate1_value_update.Location = New System.Drawing.Point(379, 22)
        Me.btn_gate1_value_update.Name = "btn_gate1_value_update"
        Me.btn_gate1_value_update.Size = New System.Drawing.Size(124, 23)
        Me.btn_gate1_value_update.TabIndex = 0
        Me.btn_gate1_value_update.Text = "Update Gate 1 value"
        Me.btn_gate1_value_update.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Q4 Target value"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Enable Target Link"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"4"})
        Me.ComboBox3.Location = New System.Drawing.Point(301, 23)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(71, 21)
        Me.ComboBox3.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Controls.Add(Me.btn_view_DSP_val)
        Me.GroupBox3.Controls.Add(Me.btn_acct_stmt)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.btn_)
        Me.GroupBox3.Controls.Add(Me.btn_exted_DSP_date)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cmb_dsp_id)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(12, 212)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(741, 106)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DSP Date Extensing"
        '
        'btn_view_DSP_val
        '
        Me.btn_view_DSP_val.BackColor = System.Drawing.Color.Tan
        Me.btn_view_DSP_val.Location = New System.Drawing.Point(458, 83)
        Me.btn_view_DSP_val.Name = "btn_view_DSP_val"
        Me.btn_view_DSP_val.Size = New System.Drawing.Size(258, 23)
        Me.btn_view_DSP_val.TabIndex = 6
        Me.btn_view_DSP_val.Text = "DSP Set value in CRM VS Oracle"
        Me.btn_view_DSP_val.UseVisualStyleBackColor = False
        '
        'btn_acct_stmt
        '
        Me.btn_acct_stmt.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_acct_stmt.Location = New System.Drawing.Point(340, 58)
        Me.btn_acct_stmt.Name = "btn_acct_stmt"
        Me.btn_acct_stmt.Size = New System.Drawing.Size(258, 23)
        Me.btn_acct_stmt.TabIndex = 6
        Me.btn_acct_stmt.Text = "View Acct Statement Vs New Payment Cal"
        Me.btn_acct_stmt.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(414, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(101, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'btn_
        '
        Me.btn_.BackColor = System.Drawing.Color.Yellow
        Me.btn_.Location = New System.Drawing.Point(17, 59)
        Me.btn_.Name = "btn_"
        Me.btn_.Size = New System.Drawing.Size(172, 23)
        Me.btn_.TabIndex = 0
        Me.btn_.Text = "Update Scheme order Qty"
        Me.btn_.UseVisualStyleBackColor = False
        '
        'btn_exted_DSP_date
        '
        Me.btn_exted_DSP_date.Location = New System.Drawing.Point(212, 59)
        Me.btn_exted_DSP_date.Name = "btn_exted_DSP_date"
        Me.btn_exted_DSP_date.Size = New System.Drawing.Size(124, 23)
        Me.btn_exted_DSP_date.TabIndex = 0
        Me.btn_exted_DSP_date.Text = "Extend DSP  Date"
        Me.btn_exted_DSP_date.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "DSP ID :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(293, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Extend Date Upto :"
        '
        'cmb_dsp_id
        '
        Me.cmb_dsp_id.FormattingEnabled = True
        Me.cmb_dsp_id.Items.AddRange(New Object() {"4"})
        Me.cmb_dsp_id.Location = New System.Drawing.Point(57, 27)
        Me.cmb_dsp_id.Name = "cmb_dsp_id"
        Me.cmb_dsp_id.Size = New System.Drawing.Size(236, 21)
        Me.cmb_dsp_id.TabIndex = 3
        '
        'dgv_acct_stmt
        '
        Me.dgv_acct_stmt.AllowUserToAddRows = False
        Me.dgv_acct_stmt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_acct_stmt.BackgroundColor = System.Drawing.Color.White
        Me.dgv_acct_stmt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_acct_stmt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_acct_stmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_acct_stmt.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_acct_stmt.EnableHeadersVisualStyles = False
        Me.dgv_acct_stmt.Location = New System.Drawing.Point(6, 324)
        Me.dgv_acct_stmt.Name = "dgv_acct_stmt"
        Me.dgv_acct_stmt.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_acct_stmt.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_acct_stmt.Size = New System.Drawing.Size(753, 211)
        Me.dgv_acct_stmt.TabIndex = 5
        '
        'Dealer_target_qty_edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.ClientSize = New System.Drawing.Size(765, 539)
        Me.Controls.Add(Me.dgv_acct_stmt)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmb_dealer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Dealer_target_qty_edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dealer Target Quantity Change"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_acct_stmt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents cmb_dealer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_qtrid As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMB_PROD_GROUP As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMB_ORG As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_gate1_value_update As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents txt_gate1_val As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_exted_DSP_date As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmb_dsp_id As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents btn_ As Button
    Friend WithEvents btn_acct_stmt As Button
    Friend WithEvents dgv_acct_stmt As DataGridView
    Friend WithEvents btn_view_DSP_val As Button
End Class
