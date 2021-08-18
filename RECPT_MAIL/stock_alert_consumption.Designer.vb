<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_alert_consumption
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
        Me.btn_close = New System.Windows.Forms.Button
        Me.btn_go = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(128, 32)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(52, 23)
        Me.btn_close.TabIndex = 2
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(30, 32)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 23)
        Me.btn_go.TabIndex = 1
        Me.btn_go.Text = "Create Files"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'stock_alert_consumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 84)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "stock_alert_consumption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Alert Consumption"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_go As System.Windows.Forms.Button
End Class
