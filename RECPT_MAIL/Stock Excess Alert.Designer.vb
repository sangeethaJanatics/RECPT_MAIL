<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Excess_Alert
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
        Me.btn_create = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_create
        '
        Me.btn_create.Location = New System.Drawing.Point(35, 40)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(55, 23)
        Me.btn_create.TabIndex = 0
        Me.btn_create.Text = "Create "
        Me.btn_create.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(134, 40)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(55, 23)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'Stock_Excess_Alert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 118)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_create)
        Me.Name = "Stock_Excess_Alert"
        Me.Text = "Stock Excess Alert"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_create As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
End Class
