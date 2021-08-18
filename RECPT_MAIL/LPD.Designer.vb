<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LPD
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.payment_date_from = New System.Windows.Forms.DateTimePicker()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Payment_dt_to = New System.Windows.Forms.DateTimePicker()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_dealer = New System.Windows.Forms.ComboBox()
        Me.BTN_RMA = New System.Windows.Forms.Button()
        Me.btn_cheque_bounce = New System.Windows.Forms.Button()
        Me.but_scheme_non_scheme_sale = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From  Date:"
        '
        'payment_date_from
        '
        Me.payment_date_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.payment_date_from.Location = New System.Drawing.Point(158, 23)
        Me.payment_date_from.Name = "payment_date_from"
        Me.payment_date_from.Size = New System.Drawing.Size(113, 20)
        Me.payment_date_from.TabIndex = 1
        '
        'btn_view
        '
        Me.btn_view.BackColor = System.Drawing.Color.Honeydew
        Me.btn_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.ForeColor = System.Drawing.Color.OliveDrab
        Me.btn_view.Location = New System.Drawing.Point(546, 20)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(79, 23)
        Me.btn_view.TabIndex = 2
        Me.btn_view.Text = "View LPD"
        Me.btn_view.UseVisualStyleBackColor = False
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
        Me.dgv1.Location = New System.Drawing.Point(8, 82)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(780, 364)
        Me.dgv1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(287, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To Date  :"
        '
        'Payment_dt_to
        '
        Me.Payment_dt_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Payment_dt_to.Location = New System.Drawing.Point(415, 23)
        Me.Payment_dt_to.Name = "Payment_dt_to"
        Me.Payment_dt_to.Size = New System.Drawing.Size(113, 20)
        Me.Payment_dt_to.TabIndex = 1
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.SeaGreen
        Me.lbl_status.Location = New System.Drawing.Point(552, 4)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(125, 13)
        Me.lbl_status.TabIndex = 4
        Me.lbl_status.Text = "Payment Date From :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dealer Name :"
        '
        'cmb_dealer
        '
        Me.cmb_dealer.FormattingEnabled = True
        Me.cmb_dealer.Location = New System.Drawing.Point(124, 53)
        Me.cmb_dealer.Name = "cmb_dealer"
        Me.cmb_dealer.Size = New System.Drawing.Size(404, 21)
        Me.cmb_dealer.TabIndex = 5
        '
        'BTN_RMA
        '
        Me.BTN_RMA.BackColor = System.Drawing.Color.Honeydew
        Me.BTN_RMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_RMA.ForeColor = System.Drawing.Color.OliveDrab
        Me.BTN_RMA.Location = New System.Drawing.Point(546, 47)
        Me.BTN_RMA.Name = "BTN_RMA"
        Me.BTN_RMA.Size = New System.Drawing.Size(79, 23)
        Me.BTN_RMA.TabIndex = 2
        Me.BTN_RMA.Text = "View RMA"
        Me.BTN_RMA.UseVisualStyleBackColor = False
        '
        'btn_cheque_bounce
        '
        Me.btn_cheque_bounce.BackColor = System.Drawing.Color.Honeydew
        Me.btn_cheque_bounce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cheque_bounce.ForeColor = System.Drawing.Color.OliveDrab
        Me.btn_cheque_bounce.Location = New System.Drawing.Point(631, 20)
        Me.btn_cheque_bounce.Name = "btn_cheque_bounce"
        Me.btn_cheque_bounce.Size = New System.Drawing.Size(136, 23)
        Me.btn_cheque_bounce.TabIndex = 2
        Me.btn_cheque_bounce.Text = "View Cheque Bounce"
        Me.btn_cheque_bounce.UseVisualStyleBackColor = False
        '
        'but_scheme_non_scheme_sale
        '
        Me.but_scheme_non_scheme_sale.BackColor = System.Drawing.Color.Honeydew
        Me.but_scheme_non_scheme_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_scheme_non_scheme_sale.ForeColor = System.Drawing.Color.OliveDrab
        Me.but_scheme_non_scheme_sale.Location = New System.Drawing.Point(631, 47)
        Me.but_scheme_non_scheme_sale.Name = "but_scheme_non_scheme_sale"
        Me.but_scheme_non_scheme_sale.Size = New System.Drawing.Size(167, 23)
        Me.but_scheme_non_scheme_sale.TabIndex = 2
        Me.but_scheme_non_scheme_sale.Text = "Scheme Non-Scheme Sale"
        Me.but_scheme_non_scheme_sale.UseVisualStyleBackColor = False
        '
        'LPD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmb_dealer)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_cheque_bounce)
        Me.Controls.Add(Me.but_scheme_non_scheme_sale)
        Me.Controls.Add(Me.BTN_RMA)
        Me.Controls.Add(Me.btn_view)
        Me.Controls.Add(Me.Payment_dt_to)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.payment_date_from)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LPD"
        Me.Text = "LPD"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents payment_date_from As DateTimePicker
    Friend WithEvents btn_view As Button
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Payment_dt_to As DateTimePicker
    Friend WithEvents lbl_status As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_dealer As ComboBox
    Friend WithEvents BTN_RMA As Button
    Friend WithEvents btn_cheque_bounce As Button
    Friend WithEvents but_scheme_non_scheme_sale As Button
End Class
