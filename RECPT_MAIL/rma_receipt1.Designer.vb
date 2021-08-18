<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rma_receipt1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btn_go = New System.Windows.Forms.Button
        Me.cmb_document_type = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "RMA No"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(111, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(174, 20)
        Me.TextBox1.TabIndex = 4
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(304, 40)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(32, 22)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "GO"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'cmb_document_type
        '
        Me.cmb_document_type.FormattingEnabled = True
        Me.cmb_document_type.Items.AddRange(New Object() {"Original Invoice and Duplicater", "Duplicater Invoice", "Extra copy Invoice", "Delivery Challan"})
        Me.cmb_document_type.Location = New System.Drawing.Point(111, 84)
        Me.cmb_document_type.Name = "cmb_document_type"
        Me.cmb_document_type.Size = New System.Drawing.Size(212, 21)
        Me.cmb_document_type.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Document Type ;"
        '
        'rma_receipt1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 168)
        Me.Controls.Add(Me.cmb_document_type)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "rma_receipt1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RMA RETURN"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents cmb_document_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
