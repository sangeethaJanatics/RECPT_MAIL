<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sales_KPI
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
        Me.rad_order_pending = New System.Windows.Forms.RadioButton()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_export_to_Excel = New System.Windows.Forms.Button()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.group_ofd = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ofd_dt_to = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofd_dt_from = New System.Windows.Forms.DateTimePicker()
        Me.rad_target_vs_actual = New System.Windows.Forms.RadioButton()
        Me.rad_delivery_rating = New System.Windows.Forms.RadioButton()
        Me.rad_sale_cyr = New System.Windows.Forms.RadioButton()
        Me.rad_order_receipt = New System.Windows.Forms.RadioButton()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.group_ofd.SuspendLayout()
        Me.SuspendLayout()
        '
        'rad_order_pending
        '
        Me.rad_order_pending.AutoSize = True
        Me.rad_order_pending.Checked = True
        Me.rad_order_pending.Location = New System.Drawing.Point(32, 19)
        Me.rad_order_pending.Name = "rad_order_pending"
        Me.rad_order_pending.Size = New System.Drawing.Size(93, 17)
        Me.rad_order_pending.TabIndex = 0
        Me.rad_order_pending.TabStop = True
        Me.rad_order_pending.Text = "Order Pending"
        Me.rad_order_pending.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(11, 99)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(873, 462)
        Me.dgv1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_export_to_Excel)
        Me.GroupBox1.Controls.Add(Me.btn_go)
        Me.GroupBox1.Controls.Add(Me.group_ofd)
        Me.GroupBox1.Controls.Add(Me.rad_target_vs_actual)
        Me.GroupBox1.Controls.Add(Me.rad_delivery_rating)
        Me.GroupBox1.Controls.Add(Me.rad_sale_cyr)
        Me.GroupBox1.Controls.Add(Me.rad_order_receipt)
        Me.GroupBox1.Controls.Add(Me.rad_order_pending)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(817, 90)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report For :"
        '
        'btn_export_to_Excel
        '
        Me.btn_export_to_Excel.Location = New System.Drawing.Point(411, 50)
        Me.btn_export_to_Excel.Name = "btn_export_to_Excel"
        Me.btn_export_to_Excel.Size = New System.Drawing.Size(106, 28)
        Me.btn_export_to_Excel.TabIndex = 4
        Me.btn_export_to_Excel.Text = "Export to Excel"
        Me.btn_export_to_Excel.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(467, 19)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(50, 28)
        Me.btn_go.TabIndex = 4
        Me.btn_go.Text = "View"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'group_ofd
        '
        Me.group_ofd.Controls.Add(Me.Label2)
        Me.group_ofd.Controls.Add(Me.ofd_dt_to)
        Me.group_ofd.Controls.Add(Me.Label1)
        Me.group_ofd.Controls.Add(Me.ofd_dt_from)
        Me.group_ofd.Location = New System.Drawing.Point(523, 19)
        Me.group_ofd.Name = "group_ofd"
        Me.group_ofd.Size = New System.Drawing.Size(270, 57)
        Me.group_ofd.TabIndex = 1
        Me.group_ofd.TabStop = False
        Me.group_ofd.Text = "Order FF DT:"
        Me.group_ofd.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Order ff Dt To:"
        '
        'ofd_dt_to
        '
        Me.ofd_dt_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ofd_dt_to.Location = New System.Drawing.Point(147, 34)
        Me.ofd_dt_to.Name = "ofd_dt_to"
        Me.ofd_dt_to.Size = New System.Drawing.Size(104, 20)
        Me.ofd_dt_to.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Order ff Dt From:"
        '
        'ofd_dt_from
        '
        Me.ofd_dt_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ofd_dt_from.Location = New System.Drawing.Point(147, 9)
        Me.ofd_dt_from.Name = "ofd_dt_from"
        Me.ofd_dt_from.Size = New System.Drawing.Size(104, 20)
        Me.ofd_dt_from.TabIndex = 6
        '
        'rad_target_vs_actual
        '
        Me.rad_target_vs_actual.AutoSize = True
        Me.rad_target_vs_actual.Location = New System.Drawing.Point(207, 49)
        Me.rad_target_vs_actual.Name = "rad_target_vs_actual"
        Me.rad_target_vs_actual.Size = New System.Drawing.Size(104, 17)
        Me.rad_target_vs_actual.TabIndex = 0
        Me.rad_target_vs_actual.Text = "Target Vs Actual"
        Me.rad_target_vs_actual.UseVisualStyleBackColor = True
        '
        'rad_delivery_rating
        '
        Me.rad_delivery_rating.AutoSize = True
        Me.rad_delivery_rating.Location = New System.Drawing.Point(32, 50)
        Me.rad_delivery_rating.Name = "rad_delivery_rating"
        Me.rad_delivery_rating.Size = New System.Drawing.Size(169, 17)
        Me.rad_delivery_rating.TabIndex = 0
        Me.rad_delivery_rating.Text = "Delivery rating OFd vs invoice "
        Me.rad_delivery_rating.UseVisualStyleBackColor = True
        '
        'rad_sale_cyr
        '
        Me.rad_sale_cyr.AutoSize = True
        Me.rad_sale_cyr.Location = New System.Drawing.Point(320, 19)
        Me.rad_sale_cyr.Name = "rad_sale_cyr"
        Me.rad_sale_cyr.Size = New System.Drawing.Size(113, 17)
        Me.rad_sale_cyr.TabIndex = 0
        Me.rad_sale_cyr.Text = "Sales Current Year"
        Me.rad_sale_cyr.UseVisualStyleBackColor = True
        '
        'rad_order_receipt
        '
        Me.rad_order_receipt.AutoSize = True
        Me.rad_order_receipt.Location = New System.Drawing.Point(148, 19)
        Me.rad_order_receipt.Name = "rad_order_receipt"
        Me.rad_order_receipt.Size = New System.Drawing.Size(153, 17)
        Me.rad_order_receipt.TabIndex = 0
        Me.rad_order_receipt.Text = "Order Receipt Current Year"
        Me.rad_order_receipt.UseVisualStyleBackColor = True
        '
        'sales_KPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(896, 573)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "sales_KPI"
        Me.Text = "Sales KPI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_ofd.ResumeLayout(False)
        Me.group_ofd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rad_order_pending As System.Windows.Forms.RadioButton
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_order_receipt As System.Windows.Forms.RadioButton
    Friend WithEvents rad_sale_cyr As System.Windows.Forms.RadioButton
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents rad_delivery_rating As System.Windows.Forms.RadioButton
    Friend WithEvents group_ofd As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ofd_dt_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofd_dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents rad_target_vs_actual As System.Windows.Forms.RadioButton
    Friend WithEvents btn_export_to_Excel As Button
End Class
