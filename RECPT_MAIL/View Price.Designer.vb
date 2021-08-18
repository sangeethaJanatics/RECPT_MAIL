<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_Price
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
        Me.txt_item_no = New System.Windows.Forms.TextBox
        Me.btn_view = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item No :"
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(195, 13)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(175, 20)
        Me.txt_item_no.TabIndex = 1
        '
        'btn_view
        '
        Me.btn_view.Location = New System.Drawing.Point(386, 12)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(95, 23)
        Me.btn_view.TabIndex = 2
        Me.btn_view.Text = "View Price"
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 82)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(636, 290)
        Me.DataGridView1.TabIndex = 3
        '
        'View_Price
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 384)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_view)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.Label1)
        Me.Name = "View_Price"
        Me.Text = "View_Price"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_view As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
