<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ds_m2o
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
        Me.btn_go = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.rad_ds = New System.Windows.Forms.RadioButton
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.rad_m2o = New System.Windows.Forms.RadioButton
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(451, 5)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(39, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(284, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status of :"
        '
        'rad_ds
        '
        Me.rad_ds.AutoSize = True
        Me.rad_ds.Checked = True
        Me.rad_ds.Location = New System.Drawing.Point(353, 8)
        Me.rad_ds.Name = "rad_ds"
        Me.rad_ds.Size = New System.Drawing.Size(40, 17)
        Me.rad_ds.TabIndex = 2
        Me.rad_ds.TabStop = True
        Me.rad_ds.Text = "DS"
        Me.rad_ds.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(11, 34)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(1105, 464)
        Me.dgv1.TabIndex = 3
        '
        'rad_m2o
        '
        Me.rad_m2o.AutoSize = True
        Me.rad_m2o.Location = New System.Drawing.Point(399, 8)
        Me.rad_m2o.Name = "rad_m2o"
        Me.rad_m2o.Size = New System.Drawing.Size(46, 17)
        Me.rad_m2o.TabIndex = 2
        Me.rad_m2o.Text = "M2o"
        Me.rad_m2o.UseVisualStyleBackColor = True
        '
        'ds_m2o
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 510)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.rad_m2o)
        Me.Controls.Add(Me.rad_ds)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "ds_m2o"
        Me.Text = "ds_m2o"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_ds As System.Windows.Forms.RadioButton
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rad_m2o As System.Windows.Forms.RadioButton
End Class
