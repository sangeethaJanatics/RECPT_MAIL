<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GST_OA_convert
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_old_oa = New System.Windows.Forms.TextBox
        Me.btn_interface_OA = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_customer = New System.Windows.Forms.ComboBox
        Me.btn_view_new_order = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTN_LINES_IN_INTERFACE = New System.Windows.Forms.Button
        Me.btn_migrate_rsv = New System.Windows.Forms.Button
        Me.btn_rsv_interface_lines = New System.Windows.Forms.Button
        Me.DGV_RSV_INTERFACE = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_RSV_INTERFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name :"
        '
        'txt_old_oa
        '
        Me.txt_old_oa.Enabled = False
        Me.txt_old_oa.Location = New System.Drawing.Point(495, 9)
        Me.txt_old_oa.Name = "txt_old_oa"
        Me.txt_old_oa.Size = New System.Drawing.Size(144, 20)
        Me.txt_old_oa.TabIndex = 1
        '
        'btn_interface_OA
        '
        Me.btn_interface_OA.Location = New System.Drawing.Point(656, 9)
        Me.btn_interface_OA.Name = "btn_interface_OA"
        Me.btn_interface_OA.Size = New System.Drawing.Size(82, 23)
        Me.btn_interface_OA.TabIndex = 2
        Me.btn_interface_OA.Text = "Migrate OA"
        Me.btn_interface_OA.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 64)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(937, 466)
        Me.DataGridView1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(412, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Order Number :"
        '
        'cmb_customer
        '
        Me.cmb_customer.FormattingEnabled = True
        Me.cmb_customer.Location = New System.Drawing.Point(94, 8)
        Me.cmb_customer.Name = "cmb_customer"
        Me.cmb_customer.Size = New System.Drawing.Size(311, 21)
        Me.cmb_customer.TabIndex = 4
        '
        'btn_view_new_order
        '
        Me.btn_view_new_order.Location = New System.Drawing.Point(744, 9)
        Me.btn_view_new_order.Name = "btn_view_new_order"
        Me.btn_view_new_order.Size = New System.Drawing.Size(176, 23)
        Me.btn_view_new_order.TabIndex = 2
        Me.btn_view_new_order.Text = "View New order and Tax Category"
        Me.btn_view_new_order.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 531)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Migrate  Logistics OA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTN_LINES_IN_INTERFACE
        '
        Me.BTN_LINES_IN_INTERFACE.Location = New System.Drawing.Point(12, 35)
        Me.BTN_LINES_IN_INTERFACE.Name = "BTN_LINES_IN_INTERFACE"
        Me.BTN_LINES_IN_INTERFACE.Size = New System.Drawing.Size(201, 23)
        Me.BTN_LINES_IN_INTERFACE.TabIndex = 2
        Me.BTN_LINES_IN_INTERFACE.Text = "Lines in Interface"
        Me.BTN_LINES_IN_INTERFACE.UseVisualStyleBackColor = True
        '
        'btn_migrate_rsv
        '
        Me.btn_migrate_rsv.Location = New System.Drawing.Point(155, 531)
        Me.btn_migrate_rsv.Name = "btn_migrate_rsv"
        Me.btn_migrate_rsv.Size = New System.Drawing.Size(137, 23)
        Me.btn_migrate_rsv.TabIndex = 2
        Me.btn_migrate_rsv.Text = "Migrate  Reservation"
        Me.btn_migrate_rsv.UseVisualStyleBackColor = True
        '
        'btn_rsv_interface_lines
        '
        Me.btn_rsv_interface_lines.Location = New System.Drawing.Point(298, 531)
        Me.btn_rsv_interface_lines.Name = "btn_rsv_interface_lines"
        Me.btn_rsv_interface_lines.Size = New System.Drawing.Size(137, 23)
        Me.btn_rsv_interface_lines.TabIndex = 2
        Me.btn_rsv_interface_lines.Text = "Lines  in  Reservation Interface"
        Me.btn_rsv_interface_lines.UseVisualStyleBackColor = True
        '
        'DGV_RSV_INTERFACE
        '
        Me.DGV_RSV_INTERFACE.AllowUserToAddRows = False
        Me.DGV_RSV_INTERFACE.AllowUserToDeleteRows = False
        Me.DGV_RSV_INTERFACE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_RSV_INTERFACE.BackgroundColor = System.Drawing.Color.White
        Me.DGV_RSV_INTERFACE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DGV_RSV_INTERFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_RSV_INTERFACE.Location = New System.Drawing.Point(12, 560)
        Me.DGV_RSV_INTERFACE.Name = "DGV_RSV_INTERFACE"
        Me.DGV_RSV_INTERFACE.Size = New System.Drawing.Size(937, 95)
        Me.DGV_RSV_INTERFACE.TabIndex = 3
        '
        'GST_OA_convert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 659)
        Me.Controls.Add(Me.cmb_customer)
        Me.Controls.Add(Me.DGV_RSV_INTERFACE)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_view_new_order)
        Me.Controls.Add(Me.btn_rsv_interface_lines)
        Me.Controls.Add(Me.btn_migrate_rsv)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTN_LINES_IN_INTERFACE)
        Me.Controls.Add(Me.btn_interface_OA)
        Me.Controls.Add(Me.txt_old_oa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GST_OA_convert"
        Me.Text = "GST OA conversion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_RSV_INTERFACE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_old_oa As System.Windows.Forms.TextBox
    Friend WithEvents btn_interface_OA As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_customer As System.Windows.Forms.ComboBox
    Friend WithEvents btn_view_new_order As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BTN_LINES_IN_INTERFACE As System.Windows.Forms.Button
    Friend WithEvents btn_migrate_rsv As System.Windows.Forms.Button
    Friend WithEvents btn_rsv_interface_lines As System.Windows.Forms.Button
    Friend WithEvents DGV_RSV_INTERFACE As System.Windows.Forms.DataGridView
End Class
