<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plan
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
        Me.btn_view = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_view
        '
        Me.btn_view.BackColor = System.Drawing.Color.GhostWhite
        Me.btn_view.Location = New System.Drawing.Point(42, 59)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(119, 23)
        Me.btn_view.TabIndex = 0
        Me.btn_view.Text = "View Plan Status"
        Me.btn_view.UseVisualStyleBackColor = False
        '
        'Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(262, 156)
        Me.Controls.Add(Me.btn_view)
        Me.Name = "Plan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_view As System.Windows.Forms.Button
End Class
