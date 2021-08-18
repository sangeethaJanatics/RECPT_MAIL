<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rma_details
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
        Me.btn_go = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(45, 38)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(133, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Show RMA Details"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'rma_details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(237, 95)
        Me.Controls.Add(Me.btn_go)
        Me.MaximizeBox = False
        Me.Name = "rma_details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RMA Details"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
End Class
