<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Out_Mails
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_view_pay = New System.Windows.Forms.Button
        Me.btn_pay = New System.Windows.Forms.Button
        Me.btn_order = New System.Windows.Forms.Button
        Me.btn_invoice = New System.Windows.Forms.Button
        Me.btn_view_oa = New System.Windows.Forms.Button
        Me.btn_view_des = New System.Windows.Forms.Button
        Me.cform_mail_send = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(165, 34)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(87, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mails For "
        '
        'btn_view_pay
        '
        Me.btn_view_pay.Location = New System.Drawing.Point(25, 90)
        Me.btn_view_pay.Name = "btn_view_pay"
        Me.btn_view_pay.Size = New System.Drawing.Size(164, 23)
        Me.btn_view_pay.TabIndex = 3
        Me.btn_view_pay.Text = "View Payment Details"
        Me.btn_view_pay.UseVisualStyleBackColor = True
        '
        'btn_pay
        '
        Me.btn_pay.Location = New System.Drawing.Point(218, 90)
        Me.btn_pay.Name = "btn_pay"
        Me.btn_pay.Size = New System.Drawing.Size(169, 23)
        Me.btn_pay.TabIndex = 4
        Me.btn_pay.Text = "Send Payment Receipt Mails"
        Me.btn_pay.UseVisualStyleBackColor = True
        '
        'btn_order
        '
        Me.btn_order.Location = New System.Drawing.Point(218, 130)
        Me.btn_order.Name = "btn_order"
        Me.btn_order.Size = New System.Drawing.Size(169, 23)
        Me.btn_order.TabIndex = 4
        Me.btn_order.Text = "Send Order Acceptance Mails"
        Me.btn_order.UseVisualStyleBackColor = True
        '
        'btn_invoice
        '
        Me.btn_invoice.Location = New System.Drawing.Point(218, 169)
        Me.btn_invoice.Name = "btn_invoice"
        Me.btn_invoice.Size = New System.Drawing.Size(169, 23)
        Me.btn_invoice.TabIndex = 4
        Me.btn_invoice.Text = "Send  Despatch  Details  Mails"
        Me.btn_invoice.UseVisualStyleBackColor = True
        '
        'btn_view_oa
        '
        Me.btn_view_oa.Location = New System.Drawing.Point(25, 130)
        Me.btn_view_oa.Name = "btn_view_oa"
        Me.btn_view_oa.Size = New System.Drawing.Size(164, 23)
        Me.btn_view_oa.TabIndex = 3
        Me.btn_view_oa.Text = "View Order Acceptance Details"
        Me.btn_view_oa.UseVisualStyleBackColor = True
        '
        'btn_view_des
        '
        Me.btn_view_des.Location = New System.Drawing.Point(25, 169)
        Me.btn_view_des.Name = "btn_view_des"
        Me.btn_view_des.Size = New System.Drawing.Size(164, 23)
        Me.btn_view_des.TabIndex = 3
        Me.btn_view_des.Text = "View Despatch  Details"
        Me.btn_view_des.UseVisualStyleBackColor = True
        '
        'cform_mail_send
        '
        Me.cform_mail_send.Location = New System.Drawing.Point(218, 207)
        Me.cform_mail_send.Name = "cform_mail_send"
        Me.cform_mail_send.Size = New System.Drawing.Size(169, 23)
        Me.cform_mail_send.TabIndex = 5
        Me.cform_mail_send.Text = "Send CForm Pending Mails ."
        Me.cform_mail_send.UseVisualStyleBackColor = True
        '
        'Out_Mails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 251)
        Me.Controls.Add(Me.cform_mail_send)
        Me.Controls.Add(Me.btn_invoice)
        Me.Controls.Add(Me.btn_order)
        Me.Controls.Add(Me.btn_pay)
        Me.Controls.Add(Me.btn_view_des)
        Me.Controls.Add(Me.btn_view_oa)
        Me.Controls.Add(Me.btn_view_pay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.MaximizeBox = False
        Me.Name = "Out_Mails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Mails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_view_pay As System.Windows.Forms.Button
    Friend WithEvents btn_pay As System.Windows.Forms.Button
    Friend WithEvents btn_order As System.Windows.Forms.Button
    Friend WithEvents btn_invoice As System.Windows.Forms.Button
    Friend WithEvents btn_view_oa As System.Windows.Forms.Button
    Friend WithEvents btn_view_des As System.Windows.Forms.Button
    Friend WithEvents cform_mail_send As System.Windows.Forms.Button
End Class
