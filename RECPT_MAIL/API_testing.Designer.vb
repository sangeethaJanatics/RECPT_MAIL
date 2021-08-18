<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class API_testing
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
        Me.components = New System.ComponentModel.Container()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Txt_json = New System.Windows.Forms.TextBox()
        Me.Tex_inv_no = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_open_attachment = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_ewaybill = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(3, 183)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(976, 255)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(301, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generate E-invoice"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Txt_json
        '
        Me.Txt_json.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_json.Location = New System.Drawing.Point(3, 31)
        Me.Txt_json.Multiline = True
        Me.Txt_json.Name = "Txt_json"
        Me.Txt_json.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_json.Size = New System.Drawing.Size(976, 146)
        Me.Txt_json.TabIndex = 0
        '
        'Tex_inv_no
        '
        Me.Tex_inv_no.Location = New System.Drawing.Point(117, 4)
        Me.Tex_inv_no.Name = "Tex_inv_no"
        Me.Tex_inv_no.Size = New System.Drawing.Size(162, 20)
        Me.Tex_inv_no.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Invoice No :"
        '
        'btn_open_attachment
        '
        Me.btn_open_attachment.Location = New System.Drawing.Point(424, 2)
        Me.btn_open_attachment.Name = "btn_open_attachment"
        Me.btn_open_attachment.Size = New System.Drawing.Size(109, 23)
        Me.btn_open_attachment.TabIndex = 1
        Me.btn_open_attachment.Text = "Open Attachment"
        Me.btn_open_attachment.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'btn_ewaybill
        '
        Me.btn_ewaybill.Location = New System.Drawing.Point(539, 1)
        Me.btn_ewaybill.Name = "btn_ewaybill"
        Me.btn_ewaybill.Size = New System.Drawing.Size(117, 23)
        Me.btn_ewaybill.TabIndex = 1
        Me.btn_ewaybill.Text = "Generate E-Waybill"
        Me.btn_ewaybill.UseVisualStyleBackColor = True
        '
        'API_testing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tex_inv_no)
        Me.Controls.Add(Me.btn_open_attachment)
        Me.Controls.Add(Me.btn_ewaybill)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txt_json)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "API_testing"
        Me.Text = "API_testing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Txt_json As TextBox
    Friend WithEvents Tex_inv_no As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_open_attachment As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_ewaybill As Button
End Class
