<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sale_Cyr_Lyr
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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rad_org_sale = New System.Windows.Forms.RadioButton()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.rad_item_sale = New System.Windows.Forms.RadioButton()
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
        Me.dgv1.GridColor = System.Drawing.Color.Silver
        Me.dgv1.Location = New System.Drawing.Point(12, 52)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(776, 393)
        Me.dgv1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Report For :"
        '
        'rad_org_sale
        '
        Me.rad_org_sale.AutoSize = True
        Me.rad_org_sale.Checked = True
        Me.rad_org_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_org_sale.Location = New System.Drawing.Point(229, 15)
        Me.rad_org_sale.Name = "rad_org_sale"
        Me.rad_org_sale.Size = New System.Drawing.Size(106, 17)
        Me.rad_org_sale.TabIndex = 2
        Me.rad_org_sale.TabStop = True
        Me.rad_org_sale.Text = "Org-Wise Sale"
        Me.rad_org_sale.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.BackColor = System.Drawing.Color.DimGray
        Me.btn_go.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_go.ForeColor = System.Drawing.Color.White
        Me.btn_go.Location = New System.Drawing.Point(486, 12)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 23)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "View"
        Me.btn_go.UseVisualStyleBackColor = False
        '
        'rad_item_sale
        '
        Me.rad_item_sale.AutoSize = True
        Me.rad_item_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_item_sale.Location = New System.Drawing.Point(341, 15)
        Me.rad_item_sale.Name = "rad_item_sale"
        Me.rad_item_sale.Size = New System.Drawing.Size(107, 17)
        Me.rad_item_sale.TabIndex = 2
        Me.rad_item_sale.Text = "Item-wise Sale"
        Me.rad_item_sale.UseVisualStyleBackColor = True
        '
        'Sale_Cyr_Lyr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.rad_item_sale)
        Me.Controls.Add(Me.rad_org_sale)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "Sale_Cyr_Lyr"
        Me.Text = "Sale Current Year Last year"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents rad_org_sale As RadioButton
    Friend WithEvents btn_go As Button
    Friend WithEvents rad_item_sale As RadioButton
End Class
