<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMS_log_download
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
        Me.btn_download = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_download
        '
        Me.btn_download.Location = New System.Drawing.Point(25, 52)
        Me.btn_download.Name = "btn_download"
        Me.btn_download.Size = New System.Drawing.Size(91, 23)
        Me.btn_download.TabIndex = 0
        Me.btn_download.Text = "DownLoad Log"
        Me.btn_download.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(156, 52)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 0
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'DMS_log_download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 145)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_download)
        Me.Name = "DMS_log_download"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DMS Log Download"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_download As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
End Class
