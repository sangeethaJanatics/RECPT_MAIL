<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_transfer_OA
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
        Me.txt_po_no = New System.Windows.Forms.TextBox
        Me.btn_show_lines = New System.Windows.Forms.Button
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_interface = New System.Windows.Forms.Button
        Me.btn_view_order = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(119, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PO Number :"
        '
        'txt_po_no
        '
        Me.txt_po_no.Location = New System.Drawing.Point(208, 13)
        Me.txt_po_no.Name = "txt_po_no"
        Me.txt_po_no.Size = New System.Drawing.Size(175, 20)
        Me.txt_po_no.TabIndex = 1
        '
        'btn_show_lines
        '
        Me.btn_show_lines.Location = New System.Drawing.Point(400, 12)
        Me.btn_show_lines.Name = "btn_show_lines"
        Me.btn_show_lines.Size = New System.Drawing.Size(91, 23)
        Me.btn_show_lines.TabIndex = 2
        Me.btn_show_lines.Text = "View Items"
        Me.btn_show_lines.UseVisualStyleBackColor = True
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
        Me.dgv1.Location = New System.Drawing.Point(12, 41)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(953, 334)
        Me.dgv1.TabIndex = 3
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(474, 381)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(127, 23)
        Me.btn_save.TabIndex = 4
        Me.btn_save.Text = "Move Items to Staging"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_interface
        '
        Me.btn_interface.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_interface.Location = New System.Drawing.Point(607, 381)
        Me.btn_interface.Name = "btn_interface"
        Me.btn_interface.Size = New System.Drawing.Size(127, 23)
        Me.btn_interface.TabIndex = 4
        Me.btn_interface.Text = "Move Items to Interface"
        Me.btn_interface.UseVisualStyleBackColor = True
        '
        'btn_view_order
        '
        Me.btn_view_order.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_view_order.Location = New System.Drawing.Point(755, 381)
        Me.btn_view_order.Name = "btn_view_order"
        Me.btn_view_order.Size = New System.Drawing.Size(127, 23)
        Me.btn_view_order.TabIndex = 4
        Me.btn_view_order.Text = "Show Order Number"
        Me.btn_view_order.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DeepPink
        Me.Label2.Location = New System.Drawing.Point(512, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(433, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Highlighted Items are not Enabled to create Order , Inform to Design Dept ."
        Me.Label2.Visible = False
        '
        'Stock_transfer_OA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(977, 410)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_view_order)
        Me.Controls.Add(Me.btn_interface)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_show_lines)
        Me.Controls.Add(Me.txt_po_no)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Stock_transfer_OA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock_transfer_OA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_po_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_show_lines As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_interface As System.Windows.Forms.Button
    Friend WithEvents btn_view_order As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
