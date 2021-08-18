<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vendor_mail_sending
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
        Me.btn_send = New System.Windows.Forms.Button
        Me.rad_po = New System.Windows.Forms.RadioButton
        Me.yr_cmb = New System.Windows.Forms.ComboBox
        Me.rad_osp = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.txt_mail_subject = New System.Windows.Forms.TextBox
        Me.btn_preview = New System.Windows.Forms.Button
        Me.chk_list_vendor = New System.Windows.Forms.CheckedListBox
        Me.show_vendor = New System.Windows.Forms.Button
        Me.chk_all_select = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chk_import_vendors = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(569, 13)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(59, 23)
        Me.btn_send.TabIndex = 0
        Me.btn_send.Text = "Send"
        Me.btn_send.UseVisualStyleBackColor = True
        '
        'rad_po
        '
        Me.rad_po.AutoSize = True
        Me.rad_po.Checked = True
        Me.rad_po.Location = New System.Drawing.Point(28, 16)
        Me.rad_po.Name = "rad_po"
        Me.rad_po.Size = New System.Drawing.Size(40, 17)
        Me.rad_po.TabIndex = 1
        Me.rad_po.TabStop = True
        Me.rad_po.Text = "PO"
        Me.rad_po.UseVisualStyleBackColor = True
        '
        'yr_cmb
        '
        Me.yr_cmb.FormattingEnabled = True
        Me.yr_cmb.Location = New System.Drawing.Point(210, 14)
        Me.yr_cmb.Name = "yr_cmb"
        Me.yr_cmb.Size = New System.Drawing.Size(101, 21)
        Me.yr_cmb.TabIndex = 2
        '
        'rad_osp
        '
        Me.rad_osp.AutoSize = True
        Me.rad_osp.Location = New System.Drawing.Point(72, 16)
        Me.rad_osp.Name = "rad_osp"
        Me.rad_osp.Size = New System.Drawing.Size(47, 17)
        Me.rad_osp.TabIndex = 1
        Me.rad_osp.Text = "OSP"
        Me.rad_osp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Month and Yr"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mail Subject"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox1.Location = New System.Drawing.Point(296, 100)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(596, 470)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'txt_mail_subject
        '
        Me.txt_mail_subject.Location = New System.Drawing.Point(82, 41)
        Me.txt_mail_subject.Multiline = True
        Me.txt_mail_subject.Name = "txt_mail_subject"
        Me.txt_mail_subject.Size = New System.Drawing.Size(807, 21)
        Me.txt_mail_subject.TabIndex = 6
        '
        'btn_preview
        '
        Me.btn_preview.Location = New System.Drawing.Point(634, 13)
        Me.btn_preview.Name = "btn_preview"
        Me.btn_preview.Size = New System.Drawing.Size(59, 23)
        Me.btn_preview.TabIndex = 7
        Me.btn_preview.Text = "Preview"
        Me.btn_preview.UseVisualStyleBackColor = True
        '
        'chk_list_vendor
        '
        Me.chk_list_vendor.ForeColor = System.Drawing.Color.Navy
        Me.chk_list_vendor.FormattingEnabled = True
        Me.chk_list_vendor.Location = New System.Drawing.Point(8, 100)
        Me.chk_list_vendor.Name = "chk_list_vendor"
        Me.chk_list_vendor.Size = New System.Drawing.Size(283, 469)
        Me.chk_list_vendor.TabIndex = 8
        '
        'show_vendor
        '
        Me.show_vendor.Location = New System.Drawing.Point(472, 13)
        Me.show_vendor.Name = "show_vendor"
        Me.show_vendor.Size = New System.Drawing.Size(93, 23)
        Me.show_vendor.TabIndex = 9
        Me.show_vendor.Text = "Show Vendors"
        Me.show_vendor.UseVisualStyleBackColor = True
        '
        'chk_all_select
        '
        Me.chk_all_select.BackColor = System.Drawing.Color.DarkGray
        Me.chk_all_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_all_select.ForeColor = System.Drawing.Color.White
        Me.chk_all_select.Location = New System.Drawing.Point(8, 77)
        Me.chk_all_select.Name = "chk_all_select"
        Me.chk_all_select.Size = New System.Drawing.Size(283, 24)
        Me.chk_all_select.TabIndex = 10
        Me.chk_all_select.Text = "Select  All Vendors"
        Me.chk_all_select.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(296, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(595, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Message to Send"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_import_vendors
        '
        Me.chk_import_vendors.AutoSize = True
        Me.chk_import_vendors.Location = New System.Drawing.Point(327, 16)
        Me.chk_import_vendors.Name = "chk_import_vendors"
        Me.chk_import_vendors.Size = New System.Drawing.Size(135, 17)
        Me.chk_import_vendors.TabIndex = 12
        Me.chk_import_vendors.Text = "Include Import Vendors"
        Me.chk_import_vendors.UseVisualStyleBackColor = True
        '
        'Vendor_mail_sending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(901, 586)
        Me.Controls.Add(Me.chk_import_vendors)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chk_all_select)
        Me.Controls.Add(Me.show_vendor)
        Me.Controls.Add(Me.chk_list_vendor)
        Me.Controls.Add(Me.btn_preview)
        Me.Controls.Add(Me.txt_mail_subject)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.yr_cmb)
        Me.Controls.Add(Me.rad_osp)
        Me.Controls.Add(Me.rad_po)
        Me.Controls.Add(Me.btn_send)
        Me.Name = "Vendor_mail_sending"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor Mail Sending"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_send As System.Windows.Forms.Button
    Friend WithEvents rad_po As System.Windows.Forms.RadioButton
    Friend WithEvents yr_cmb As System.Windows.Forms.ComboBox
    Friend WithEvents rad_osp As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_mail_subject As System.Windows.Forms.TextBox
    Friend WithEvents btn_preview As System.Windows.Forms.Button
    Friend WithEvents chk_list_vendor As System.Windows.Forms.CheckedListBox
    Friend WithEvents show_vendor As System.Windows.Forms.Button
    Friend WithEvents chk_all_select As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_import_vendors As System.Windows.Forms.CheckBox
End Class
