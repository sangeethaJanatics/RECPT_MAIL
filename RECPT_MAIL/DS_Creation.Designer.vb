<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DS_Creation
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
        Me.btn_create_DS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_create_DS
        '
        Me.btn_create_DS.Location = New System.Drawing.Point(102, 12)
        Me.btn_create_DS.Name = "btn_create_DS"
        Me.btn_create_DS.Size = New System.Drawing.Size(75, 23)
        Me.btn_create_DS.TabIndex = 0
        Me.btn_create_DS.Text = "Create DS"
        Me.btn_create_DS.UseVisualStyleBackColor = True
        '
        'DS_Creation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_create_DS)
        Me.Name = "DS_Creation"
        Me.Text = "DS_Creation"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_create_DS As Button
End Class
