<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Production_day_wise
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
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.btn_go = New System.Windows.Forms.Button
        Me.rad_qty = New System.Windows.Forms.RadioButton
        Me.rad_prod_val = New System.Windows.Forms.RadioButton
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
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(5, 38)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(854, 368)
        Me.dgv1.TabIndex = 0
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(420, 9)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(41, 23)
        Me.btn_go.TabIndex = 1
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'rad_qty
        '
        Me.rad_qty.AutoSize = True
        Me.rad_qty.Checked = True
        Me.rad_qty.Location = New System.Drawing.Point(181, 12)
        Me.rad_qty.Name = "rad_qty"
        Me.rad_qty.Size = New System.Drawing.Size(118, 17)
        Me.rad_qty.TabIndex = 3
        Me.rad_qty.TabStop = True
        Me.rad_qty.Text = "Production Quantity"
        Me.rad_qty.UseVisualStyleBackColor = True
        '
        'rad_prod_val
        '
        Me.rad_prod_val.AutoSize = True
        Me.rad_prod_val.Location = New System.Drawing.Point(305, 12)
        Me.rad_prod_val.Name = "rad_prod_val"
        Me.rad_prod_val.Size = New System.Drawing.Size(106, 17)
        Me.rad_prod_val.TabIndex = 3
        Me.rad_prod_val.TabStop = True
        Me.rad_prod_val.Text = "Production Value"
        Me.rad_prod_val.UseVisualStyleBackColor = True
        '
        'Production_day_wise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 412)
        Me.Controls.Add(Me.rad_prod_val)
        Me.Controls.Add(Me.rad_qty)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "Production_day_wise"
        Me.Text = "Day wise Production"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents rad_qty As System.Windows.Forms.RadioButton
    Friend WithEvents rad_prod_val As System.Windows.Forms.RadioButton
End Class
