<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Order_cancelled_Data
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
        Me.btn_go = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.From_date = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.To_date = New System.Windows.Forms.DateTimePicker()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.rad_order_date = New System.Windows.Forms.RadioButton()
        Me.rad_cancellation_date = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker_OA_clean = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rad_cancelled_oa = New System.Windows.Forms.RadioButton()
        Me.rad_data_to_cancel_order = New System.Windows.Forms.RadioButton()
        Me.chk_dealer_order = New System.Windows.Forms.CheckBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(554, 63)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(42, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From Date :"
        '
        'From_date
        '
        Me.From_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.From_date.Location = New System.Drawing.Point(84, 22)
        Me.From_date.Name = "From_date"
        Me.From_date.Size = New System.Drawing.Size(92, 20)
        Me.From_date.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To Date :"
        '
        'To_date
        '
        Me.To_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.To_date.Location = New System.Drawing.Point(84, 48)
        Me.To_date.Name = "To_date"
        Me.To_date.Size = New System.Drawing.Size(92, 20)
        Me.To_date.TabIndex = 2
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
        Me.dgv1.GridColor = System.Drawing.Color.Gray
        Me.dgv1.Location = New System.Drawing.Point(5, 108)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(670, 306)
        Me.dgv1.TabIndex = 3
        '
        'rad_order_date
        '
        Me.rad_order_date.AutoSize = True
        Me.rad_order_date.Checked = True
        Me.rad_order_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_order_date.Location = New System.Drawing.Point(192, 29)
        Me.rad_order_date.Name = "rad_order_date"
        Me.rad_order_date.Size = New System.Drawing.Size(87, 17)
        Me.rad_order_date.TabIndex = 4
        Me.rad_order_date.TabStop = True
        Me.rad_order_date.Text = "Order Date"
        Me.rad_order_date.UseVisualStyleBackColor = True
        '
        'rad_cancellation_date
        '
        Me.rad_cancellation_date.AutoSize = True
        Me.rad_cancellation_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cancellation_date.Location = New System.Drawing.Point(192, 48)
        Me.rad_cancellation_date.Name = "rad_cancellation_date"
        Me.rad_cancellation_date.Size = New System.Drawing.Size(126, 17)
        Me.rad_cancellation_date.TabIndex = 4
        Me.rad_cancellation_date.Text = "Cancellation Date"
        Me.rad_cancellation_date.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "OFD Upto :"
        '
        'DateTimePicker_OA_clean
        '
        Me.DateTimePicker_OA_clean.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_OA_clean.Location = New System.Drawing.Point(76, 19)
        Me.DateTimePicker_OA_clean.Name = "DateTimePicker_OA_clean"
        Me.DateTimePicker_OA_clean.Size = New System.Drawing.Size(92, 20)
        Me.DateTimePicker_OA_clean.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rad_cancellation_date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rad_order_date)
        Me.GroupBox1.Controls.Add(Me.From_date)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.To_date)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 71)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cancelled OA Detail"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DateTimePicker_OA_clean)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(353, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(174, 70)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "For OA Cleaning"
        '
        'rad_cancelled_oa
        '
        Me.rad_cancelled_oa.AutoSize = True
        Me.rad_cancelled_oa.Checked = True
        Me.rad_cancelled_oa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cancelled_oa.Location = New System.Drawing.Point(529, 23)
        Me.rad_cancelled_oa.Name = "rad_cancelled_oa"
        Me.rad_cancelled_oa.Size = New System.Drawing.Size(156, 17)
        Me.rad_cancelled_oa.TabIndex = 7
        Me.rad_cancelled_oa.TabStop = True
        Me.rad_cancelled_oa.Text = "Order Canceled History"
        Me.rad_cancelled_oa.UseVisualStyleBackColor = True
        '
        'rad_data_to_cancel_order
        '
        Me.rad_data_to_cancel_order.AutoSize = True
        Me.rad_data_to_cancel_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_data_to_cancel_order.Location = New System.Drawing.Point(530, 43)
        Me.rad_data_to_cancel_order.Name = "rad_data_to_cancel_order"
        Me.rad_data_to_cancel_order.Size = New System.Drawing.Size(95, 17)
        Me.rad_data_to_cancel_order.TabIndex = 7
        Me.rad_data_to_cancel_order.Text = "OA Cleaning"
        Me.rad_data_to_cancel_order.UseVisualStyleBackColor = True
        '
        'chk_dealer_order
        '
        Me.chk_dealer_order.AutoSize = True
        Me.chk_dealer_order.Location = New System.Drawing.Point(383, 85)
        Me.chk_dealer_order.Name = "chk_dealer_order"
        Me.chk_dealer_order.Size = New System.Drawing.Size(106, 17)
        Me.chk_dealer_order.TabIndex = 9
        Me.chk_dealer_order.Text = "Dealer order only"
        Me.chk_dealer_order.UseVisualStyleBackColor = True
        '
        'Order_cancelled_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 421)
        Me.Controls.Add(Me.chk_dealer_order)
        Me.Controls.Add(Me.rad_data_to_cancel_order)
        Me.Controls.Add(Me.rad_cancelled_oa)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Order_cancelled_Data"
        Me.Text = "Sales Order cancelled Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents From_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents To_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rad_order_date As System.Windows.Forms.RadioButton
    Friend WithEvents rad_cancellation_date As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker_OA_clean As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rad_cancelled_oa As RadioButton
    Friend WithEvents rad_data_to_cancel_order As RadioButton
    Friend WithEvents chk_dealer_order As CheckBox
End Class
