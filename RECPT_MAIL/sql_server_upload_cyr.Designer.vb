<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sql_server_upload_cyr
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
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_upload
        '
        Me.btn_upload.Location = New System.Drawing.Point(12, 59)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(75, 23)
        Me.btn_upload.TabIndex = 0
        Me.btn_upload.Text = "Upload Data"
        Me.btn_upload.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(116, 59)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 0
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'sql_server_upload_cyr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 186)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_upload)
        Me.Name = "sql_server_upload_cyr"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_upload As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
End Class
