<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dealer_order_quantity
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_go = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_dealer = New System.Windows.Forms.ComboBox
        Me.dgv_head = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_qtr = New System.Windows.Forms.ComboBox
        Me.dgv_brk = New System.Windows.Forms.DataGridView
        CType(Me.dgv_head, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(676, 21)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(42, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(237, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dealer Name :"
        '
        'cmb_dealer
        '
        Me.cmb_dealer.FormattingEnabled = True
        Me.cmb_dealer.Location = New System.Drawing.Point(318, 22)
        Me.cmb_dealer.Name = "cmb_dealer"
        Me.cmb_dealer.Size = New System.Drawing.Size(352, 21)
        Me.cmb_dealer.TabIndex = 2
        '
        'dgv_head
        '
        Me.dgv_head.AllowUserToAddRows = False
        Me.dgv_head.AllowUserToDeleteRows = False
        Me.dgv_head.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_head.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_head.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_head.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_head.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_head.EnableHeadersVisualStyles = False
        Me.dgv_head.Location = New System.Drawing.Point(7, 54)
        Me.dgv_head.Name = "dgv_head"
        Me.dgv_head.ReadOnly = True
        Me.dgv_head.Size = New System.Drawing.Size(778, 182)
        Me.dgv_head.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Qtr Id :"
        '
        'cmb_qtr
        '
        Me.cmb_qtr.FormattingEnabled = True
        Me.cmb_qtr.Location = New System.Drawing.Point(110, 22)
        Me.cmb_qtr.Name = "cmb_qtr"
        Me.cmb_qtr.Size = New System.Drawing.Size(121, 21)
        Me.cmb_qtr.TabIndex = 2
        '
        'dgv_brk
        '
        Me.dgv_brk.AllowUserToAddRows = False
        Me.dgv_brk.AllowUserToDeleteRows = False
        Me.dgv_brk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_brk.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_brk.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_brk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_brk.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_brk.EnableHeadersVisualStyles = False
        Me.dgv_brk.Location = New System.Drawing.Point(7, 242)
        Me.dgv_brk.Name = "dgv_brk"
        Me.dgv_brk.ReadOnly = True
        Me.dgv_brk.Size = New System.Drawing.Size(778, 240)
        Me.dgv_brk.TabIndex = 3
        '
        'Dealer_order_quantity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 494)
        Me.Controls.Add(Me.dgv_brk)
        Me.Controls.Add(Me.dgv_head)
        Me.Controls.Add(Me.cmb_qtr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_dealer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Dealer_order_quantity"
        Me.Text = "Dealer Order Quantity"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv_head, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_brk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_dealer As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_head As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_qtr As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_brk As System.Windows.Forms.DataGridView
End Class
