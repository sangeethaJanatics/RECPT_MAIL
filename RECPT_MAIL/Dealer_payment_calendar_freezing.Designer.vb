<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dealer_payment_calendar_freezing
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_dealer = New System.Windows.Forms.ComboBox()
        Me.btn_go = New System.Windows.Forms.Button()
        Me.Dgv_gate1 = New System.Windows.Forms.DataGridView()
        Me.btn_run_payment_proc = New System.Windows.Forms.Button()
        CType(Me.Dgv_gate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Dealer Name :"
        '
        'cmb_dealer
        '
        Me.cmb_dealer.FormattingEnabled = True
        Me.cmb_dealer.Location = New System.Drawing.Point(130, 30)
        Me.cmb_dealer.Name = "cmb_dealer"
        Me.cmb_dealer.Size = New System.Drawing.Size(394, 21)
        Me.cmb_dealer.TabIndex = 7
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(530, 30)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(43, 23)
        Me.btn_go.TabIndex = 6
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        Me.btn_go.Visible = False
        '
        'Dgv_gate1
        '
        Me.Dgv_gate1.AllowUserToAddRows = False
        Me.Dgv_gate1.AllowUserToDeleteRows = False
        Me.Dgv_gate1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_gate1.BackgroundColor = System.Drawing.Color.White
        Me.Dgv_gate1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Dgv_gate1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_gate1.Location = New System.Drawing.Point(23, 70)
        Me.Dgv_gate1.Name = "Dgv_gate1"
        Me.Dgv_gate1.ReadOnly = True
        Me.Dgv_gate1.RowHeadersVisible = False
        Me.Dgv_gate1.Size = New System.Drawing.Size(755, 368)
        Me.Dgv_gate1.TabIndex = 9
        '
        'btn_run_payment_proc
        '
        Me.btn_run_payment_proc.Location = New System.Drawing.Point(579, 31)
        Me.btn_run_payment_proc.Name = "btn_run_payment_proc"
        Me.btn_run_payment_proc.Size = New System.Drawing.Size(151, 23)
        Me.btn_run_payment_proc.TabIndex = 6
        Me.btn_run_payment_proc.Text = "Run Payment Procedure"
        Me.btn_run_payment_proc.UseVisualStyleBackColor = True
        '
        'Dealer_payment_calendar_freezing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Dgv_gate1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_dealer)
        Me.Controls.Add(Me.btn_run_payment_proc)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Dealer_payment_calendar_freezing"
        Me.Text = "Dealer_payment_calendar_freezing"
        CType(Me.Dgv_gate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_dealer As ComboBox
    Friend WithEvents btn_go As Button
    Friend WithEvents Dgv_gate1 As DataGridView
    Friend WithEvents btn_run_payment_proc As Button
End Class
