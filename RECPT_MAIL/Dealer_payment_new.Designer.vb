<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dealer_payment_new
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
        Me.btn_go = New System.Windows.Forms.Button()
        Me.rad_week = New System.Windows.Forms.RadioButton()
        Me.rad_unapplied = New System.Windows.Forms.RadioButton()
        Me.rad_os_breakup = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddl_cust = New System.Windows.Forms.ComboBox()
        Me.RAD_DELIVERY_RATING = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker_ofd_from = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker_ofd_to = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Rad_weekwise_order_pend = New System.Windows.Forms.RadioButton()
        Me.Rad_Despatch_vs_Payment = New System.Windows.Forms.RadioButton()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
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
        Me.dgv1.Location = New System.Drawing.Point(12, 98)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(776, 340)
        Me.dgv1.TabIndex = 0
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(697, 12)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 56)
        Me.btn_go.TabIndex = 1
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'rad_week
        '
        Me.rad_week.AutoSize = True
        Me.rad_week.Checked = True
        Me.rad_week.Location = New System.Drawing.Point(546, 6)
        Me.rad_week.Name = "rad_week"
        Me.rad_week.Size = New System.Drawing.Size(99, 17)
        Me.rad_week.TabIndex = 2
        Me.rad_week.TabStop = True
        Me.rad_week.Text = "Week Wise OS"
        Me.rad_week.UseVisualStyleBackColor = True
        '
        'rad_unapplied
        '
        Me.rad_unapplied.AutoSize = True
        Me.rad_unapplied.Location = New System.Drawing.Point(546, 45)
        Me.rad_unapplied.Name = "rad_unapplied"
        Me.rad_unapplied.Size = New System.Drawing.Size(112, 17)
        Me.rad_unapplied.TabIndex = 3
        Me.rad_unapplied.Text = "Unapplied Amount"
        Me.rad_unapplied.UseVisualStyleBackColor = True
        '
        'rad_os_breakup
        '
        Me.rad_os_breakup.AutoSize = True
        Me.rad_os_breakup.Location = New System.Drawing.Point(546, 27)
        Me.rad_os_breakup.Name = "rad_os_breakup"
        Me.rad_os_breakup.Size = New System.Drawing.Size(83, 17)
        Me.rad_os_breakup.TabIndex = 4
        Me.rad_os_breakup.Text = "OS Breakup"
        Me.rad_os_breakup.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Dealer Name :"
        '
        'ddl_cust
        '
        Me.ddl_cust.FormattingEnabled = True
        Me.ddl_cust.Location = New System.Drawing.Point(127, 6)
        Me.ddl_cust.Name = "ddl_cust"
        Me.ddl_cust.Size = New System.Drawing.Size(393, 21)
        Me.ddl_cust.TabIndex = 6
        '
        'RAD_DELIVERY_RATING
        '
        Me.RAD_DELIVERY_RATING.AutoSize = True
        Me.RAD_DELIVERY_RATING.Location = New System.Drawing.Point(421, 38)
        Me.RAD_DELIVERY_RATING.Name = "RAD_DELIVERY_RATING"
        Me.RAD_DELIVERY_RATING.Size = New System.Drawing.Size(97, 17)
        Me.RAD_DELIVERY_RATING.TabIndex = 7
        Me.RAD_DELIVERY_RATING.Text = "Delivery Rating"
        Me.RAD_DELIVERY_RATING.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "OFD From :"
        '
        'DateTimePicker_ofd_from
        '
        Me.DateTimePicker_ofd_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_ofd_from.Location = New System.Drawing.Point(112, 36)
        Me.DateTimePicker_ofd_from.Name = "DateTimePicker_ofd_from"
        Me.DateTimePicker_ofd_from.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker_ofd_from.TabIndex = 9
        '
        'DateTimePicker_ofd_to
        '
        Me.DateTimePicker_ofd_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_ofd_to.Location = New System.Drawing.Point(312, 36)
        Me.DateTimePicker_ofd_to.Name = "DateTimePicker_ofd_to"
        Me.DateTimePicker_ofd_to.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker_ofd_to.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "OFD To :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DeepPink
        Me.Label4.Location = New System.Drawing.Point(677, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "OS  Morninig Status"
        '
        'Rad_weekwise_order_pend
        '
        Me.Rad_weekwise_order_pend.AutoSize = True
        Me.Rad_weekwise_order_pend.Location = New System.Drawing.Point(545, 68)
        Me.Rad_weekwise_order_pend.Name = "Rad_weekwise_order_pend"
        Me.Rad_weekwise_order_pend.Size = New System.Drawing.Size(152, 17)
        Me.Rad_weekwise_order_pend.TabIndex = 3
        Me.Rad_weekwise_order_pend.Text = "Week-Wise Order Pending"
        Me.Rad_weekwise_order_pend.UseVisualStyleBackColor = True
        '
        'Rad_Despatch_vs_Payment
        '
        Me.Rad_Despatch_vs_Payment.AutoSize = True
        Me.Rad_Despatch_vs_Payment.Location = New System.Drawing.Point(336, 68)
        Me.Rad_Despatch_vs_Payment.Name = "Rad_Despatch_vs_Payment"
        Me.Rad_Despatch_vs_Payment.Size = New System.Drawing.Size(199, 17)
        Me.Rad_Despatch_vs_Payment.TabIndex = 3
        Me.Rad_Despatch_vs_Payment.Text = "Despatch Vs Payment Receipt value"
        Me.Rad_Despatch_vs_Payment.UseVisualStyleBackColor = True
        '
        'Dealer_payment_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker_ofd_to)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker_ofd_from)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RAD_DELIVERY_RATING)
        Me.Controls.Add(Me.ddl_cust)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rad_os_breakup)
        Me.Controls.Add(Me.Rad_Despatch_vs_Payment)
        Me.Controls.Add(Me.Rad_weekwise_order_pend)
        Me.Controls.Add(Me.rad_unapplied)
        Me.Controls.Add(Me.rad_week)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "Dealer_payment_new"
        Me.Text = "Dealer Payment OS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents btn_go As Button
    Friend WithEvents rad_week As RadioButton
    Friend WithEvents rad_unapplied As RadioButton
    Friend WithEvents rad_os_breakup As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ddl_cust As ComboBox
    Friend WithEvents RAD_DELIVERY_RATING As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker_ofd_from As DateTimePicker
    Friend WithEvents DateTimePicker_ofd_to As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Rad_weekwise_order_pend As RadioButton
    Friend WithEvents Rad_Despatch_vs_Payment As RadioButton
End Class
