<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vendor_mail_preview
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
        Me.wb1 = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'wb1
        '
        Me.wb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb1.Location = New System.Drawing.Point(0, 0)
        Me.wb1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb1.Name = "wb1"
        Me.wb1.Size = New System.Drawing.Size(541, 412)
        Me.wb1.TabIndex = 0
        '
        'vendor_mail_preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 412)
        Me.Controls.Add(Me.wb1)
        Me.Name = "vendor_mail_preview"
        Me.Text = "Preview"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wb1 As System.Windows.Forms.WebBrowser
End Class
