<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class daily_mail
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
        Me.criteria_combo = New System.Windows.Forms.ComboBox
        Me.btn_go = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'criteria_combo
        '
        Me.criteria_combo.FormattingEnabled = True
        Me.criteria_combo.Location = New System.Drawing.Point(12, 46)
        Me.criteria_combo.Name = "criteria_combo"
        Me.criteria_combo.Size = New System.Drawing.Size(238, 21)
        Me.criteria_combo.TabIndex = 0
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(256, 45)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(34, 23)
        Me.btn_go.TabIndex = 1
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'daily_mail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 99)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.criteria_combo)
        Me.Name = "daily_mail"
        Me.Text = "Daily Mail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents criteria_combo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_go As System.Windows.Forms.Button
End Class
