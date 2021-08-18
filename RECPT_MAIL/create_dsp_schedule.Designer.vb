<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class create_dsp_schedule
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
        Me.btn_go = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_order_id = New System.Windows.Forms.TextBox
        Me.btn_change = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(235, 52)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(102, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Create Schedule"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DSP Order ID :"
        '
        'txt_order_id
        '
        Me.txt_order_id.Location = New System.Drawing.Point(109, 54)
        Me.txt_order_id.Name = "txt_order_id"
        Me.txt_order_id.Size = New System.Drawing.Size(119, 20)
        Me.txt_order_id.TabIndex = 2
        '
        'btn_change
        '
        Me.btn_change.Location = New System.Drawing.Point(12, 138)
        Me.btn_change.Name = "btn_change"
        Me.btn_change.Size = New System.Drawing.Size(102, 23)
        Me.btn_change.TabIndex = 0
        Me.btn_change.Text = "Change PO NO"
        Me.btn_change.UseVisualStyleBackColor = True
        '
        'create_dsp_schedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 173)
        Me.Controls.Add(Me.txt_order_id)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_change)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "create_dsp_schedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create DSP Schedule"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_order_id As System.Windows.Forms.TextBox
    Friend WithEvents btn_change As System.Windows.Forms.Button
End Class
