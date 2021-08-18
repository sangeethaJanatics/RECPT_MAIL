<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Flow_meter_data_uploading
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
        Me.btn_upload_to_cloud = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_upload_to_cloud
        '
        Me.btn_upload_to_cloud.Location = New System.Drawing.Point(85, 49)
        Me.btn_upload_to_cloud.Name = "btn_upload_to_cloud"
        Me.btn_upload_to_cloud.Size = New System.Drawing.Size(75, 23)
        Me.btn_upload_to_cloud.TabIndex = 0
        Me.btn_upload_to_cloud.Text = "Upload Data"
        Me.btn_upload_to_cloud.UseVisualStyleBackColor = True
        '
        'Flow_meter_data_uploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_upload_to_cloud)
        Me.Name = "Flow_meter_data_uploading"
        Me.Text = "FMS Data Uploading to Cloud  ... !"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_upload_to_cloud As Button
End Class
