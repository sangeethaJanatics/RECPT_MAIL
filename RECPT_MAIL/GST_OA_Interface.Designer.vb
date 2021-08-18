<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GST_OA_Interface
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
        Me.btn_reallocate = New System.Windows.Forms.Button
        Me.txt_Old_oa_no = New System.Windows.Forms.TextBox
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.DGV_OLD_RSV = New System.Windows.Forms.DataGridView
        Me.BTN_CHECK_OLD_RSV = New System.Windows.Forms.Button
        Me.btn_check_rsv_interface = New System.Windows.Forms.Button
        Me.dgv_rsv_interface = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_new_oa = New System.Windows.Forms.TextBox
        Me.Dgv_new_oa = New System.Windows.Forms.DataGridView
        Me.btn_new_oa_status = New System.Windows.Forms.Button
        CType(Me.DGV_OLD_RSV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_rsv_interface, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_new_oa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Old OA :"
        '
        'btn_reallocate
        '
        Me.btn_reallocate.Location = New System.Drawing.Point(795, 6)
        Me.btn_reallocate.Name = "btn_reallocate"
        Me.btn_reallocate.Size = New System.Drawing.Size(149, 27)
        Me.btn_reallocate.TabIndex = 1
        Me.btn_reallocate.Text = "Reallocate Rsv Qty"
        Me.btn_reallocate.UseVisualStyleBackColor = True
        '
        'txt_Old_oa_no
        '
        Me.txt_Old_oa_no.Location = New System.Drawing.Point(71, 13)
        Me.txt_Old_oa_no.Name = "txt_Old_oa_no"
        Me.txt_Old_oa_no.Size = New System.Drawing.Size(187, 20)
        Me.txt_Old_oa_no.TabIndex = 2
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(12, 631)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(142, 24)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "Cancel Old OA"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'DGV_OLD_RSV
        '
        Me.DGV_OLD_RSV.AllowUserToAddRows = False
        Me.DGV_OLD_RSV.AllowUserToDeleteRows = False
        Me.DGV_OLD_RSV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_OLD_RSV.BackgroundColor = System.Drawing.Color.White
        Me.DGV_OLD_RSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_OLD_RSV.Location = New System.Drawing.Point(12, 48)
        Me.DGV_OLD_RSV.Name = "DGV_OLD_RSV"
        Me.DGV_OLD_RSV.Size = New System.Drawing.Size(932, 183)
        Me.DGV_OLD_RSV.TabIndex = 3
        '
        'BTN_CHECK_OLD_RSV
        '
        Me.BTN_CHECK_OLD_RSV.Location = New System.Drawing.Point(548, 6)
        Me.BTN_CHECK_OLD_RSV.Name = "BTN_CHECK_OLD_RSV"
        Me.BTN_CHECK_OLD_RSV.Size = New System.Drawing.Size(153, 27)
        Me.BTN_CHECK_OLD_RSV.TabIndex = 1
        Me.BTN_CHECK_OLD_RSV.Text = "Check OA  Status"
        Me.BTN_CHECK_OLD_RSV.UseVisualStyleBackColor = True
        '
        'btn_check_rsv_interface
        '
        Me.btn_check_rsv_interface.Location = New System.Drawing.Point(12, 237)
        Me.btn_check_rsv_interface.Name = "btn_check_rsv_interface"
        Me.btn_check_rsv_interface.Size = New System.Drawing.Size(192, 25)
        Me.btn_check_rsv_interface.TabIndex = 1
        Me.btn_check_rsv_interface.Text = "Check Reservation Interface  Status"
        Me.btn_check_rsv_interface.UseVisualStyleBackColor = True
        '
        'dgv_rsv_interface
        '
        Me.dgv_rsv_interface.AllowUserToAddRows = False
        Me.dgv_rsv_interface.AllowUserToDeleteRows = False
        Me.dgv_rsv_interface.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_rsv_interface.BackgroundColor = System.Drawing.Color.White
        Me.dgv_rsv_interface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_rsv_interface.Location = New System.Drawing.Point(12, 265)
        Me.dgv_rsv_interface.Name = "dgv_rsv_interface"
        Me.dgv_rsv_interface.Size = New System.Drawing.Size(932, 138)
        Me.dgv_rsv_interface.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(280, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "New OA :"
        '
        'txt_new_oa
        '
        Me.txt_new_oa.Location = New System.Drawing.Point(343, 13)
        Me.txt_new_oa.Name = "txt_new_oa"
        Me.txt_new_oa.Size = New System.Drawing.Size(187, 20)
        Me.txt_new_oa.TabIndex = 2
        '
        'Dgv_new_oa
        '
        Me.Dgv_new_oa.AllowUserToAddRows = False
        Me.Dgv_new_oa.AllowUserToDeleteRows = False
        Me.Dgv_new_oa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_new_oa.BackgroundColor = System.Drawing.Color.White
        Me.Dgv_new_oa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_new_oa.Location = New System.Drawing.Point(12, 438)
        Me.Dgv_new_oa.Name = "Dgv_new_oa"
        Me.Dgv_new_oa.Size = New System.Drawing.Size(932, 187)
        Me.Dgv_new_oa.TabIndex = 3
        '
        'btn_new_oa_status
        '
        Me.btn_new_oa_status.Location = New System.Drawing.Point(12, 409)
        Me.btn_new_oa_status.Name = "btn_new_oa_status"
        Me.btn_new_oa_status.Size = New System.Drawing.Size(142, 24)
        Me.btn_new_oa_status.TabIndex = 1
        Me.btn_new_oa_status.Text = "Check New OA Rsv status"
        Me.btn_new_oa_status.UseVisualStyleBackColor = True
        Me.btn_new_oa_status.Visible = False
        '
        'GST_OA_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 665)
        Me.Controls.Add(Me.Dgv_new_oa)
        Me.Controls.Add(Me.dgv_rsv_interface)
        Me.Controls.Add(Me.DGV_OLD_RSV)
        Me.Controls.Add(Me.btn_new_oa_status)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_check_rsv_interface)
        Me.Controls.Add(Me.BTN_CHECK_OLD_RSV)
        Me.Controls.Add(Me.btn_reallocate)
        Me.Controls.Add(Me.txt_new_oa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Old_oa_no)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GST_OA_Interface"
        Me.Text = "GST OA Interface"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV_OLD_RSV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_rsv_interface, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_new_oa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_reallocate As System.Windows.Forms.Button
    Friend WithEvents txt_Old_oa_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents DGV_OLD_RSV As System.Windows.Forms.DataGridView
    Friend WithEvents BTN_CHECK_OLD_RSV As System.Windows.Forms.Button
    Friend WithEvents btn_check_rsv_interface As System.Windows.Forms.Button
    Friend WithEvents dgv_rsv_interface As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_new_oa As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_new_oa As System.Windows.Forms.DataGridView
    Friend WithEvents btn_new_oa_status As System.Windows.Forms.Button
End Class
