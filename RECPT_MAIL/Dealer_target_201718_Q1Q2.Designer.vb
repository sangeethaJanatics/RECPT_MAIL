<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dealer_target_201718_Q1Q2
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
        Me.btn_go = New System.Windows.Forms.Button
        Me.cmb_dealer = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dgv_gate1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv_gate2 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.BTN_PRINT = New System.Windows.Forms.Button
        CType(Me.Dgv_gate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_gate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(622, 20)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'cmb_dealer
        '
        Me.cmb_dealer.FormattingEnabled = True
        Me.cmb_dealer.Location = New System.Drawing.Point(160, 20)
        Me.cmb_dealer.Name = "cmb_dealer"
        Me.cmb_dealer.Size = New System.Drawing.Size(456, 21)
        Me.cmb_dealer.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Dealer Name :"
        '
        'Dgv_gate1
        '
        Me.Dgv_gate1.AllowUserToAddRows = False
        Me.Dgv_gate1.AllowUserToDeleteRows = False
        Me.Dgv_gate1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_gate1.BackgroundColor = System.Drawing.Color.White
        Me.Dgv_gate1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Dgv_gate1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_gate1.Location = New System.Drawing.Point(12, 68)
        Me.Dgv_gate1.Name = "Dgv_gate1"
        Me.Dgv_gate1.ReadOnly = True
        Me.Dgv_gate1.RowHeadersVisible = False
        Me.Dgv_gate1.Size = New System.Drawing.Size(887, 91)
        Me.Dgv_gate1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(21, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Gate1"
        '
        'dgv_gate2
        '
        Me.dgv_gate2.AllowUserToAddRows = False
        Me.dgv_gate2.AllowUserToDeleteRows = False
        Me.dgv_gate2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_gate2.BackgroundColor = System.Drawing.Color.White
        Me.dgv_gate2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgv_gate2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gate2.Location = New System.Drawing.Point(12, 178)
        Me.dgv_gate2.Name = "dgv_gate2"
        Me.dgv_gate2.ReadOnly = True
        Me.dgv_gate2.RowHeadersVisible = False
        Me.dgv_gate2.Size = New System.Drawing.Size(887, 343)
        Me.dgv_gate2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Crimson
        Me.Label3.Location = New System.Drawing.Point(12, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gate2"
        '
        'BTN_PRINT
        '
        Me.BTN_PRINT.Location = New System.Drawing.Point(703, 20)
        Me.BTN_PRINT.Name = "BTN_PRINT"
        Me.BTN_PRINT.Size = New System.Drawing.Size(75, 23)
        Me.BTN_PRINT.TabIndex = 0
        Me.BTN_PRINT.Text = "Print"
        Me.BTN_PRINT.UseVisualStyleBackColor = True
        Me.BTN_PRINT.Visible = False
        '
        'Dealer_target_201718_Q1Q2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 528)
        Me.Controls.Add(Me.dgv_gate2)
        Me.Controls.Add(Me.Dgv_gate1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_dealer)
        Me.Controls.Add(Me.BTN_PRINT)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Dealer_target_201718_Q1Q2"
        Me.Text = "Dealer Target 2018- 2019"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dgv_gate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_gate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents cmb_dealer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dgv_gate1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv_gate2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BTN_PRINT As System.Windows.Forms.Button
End Class
