<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSP_MOQ_EDIT
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.txt_item_no = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_go = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddl_org = New System.Windows.Forms.ComboBox
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_add_new_item = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_moq = New System.Windows.Forms.TextBox
        Me.lbl_MOQ = New System.Windows.Forms.Label
        Me.txt_org_update = New System.Windows.Forms.TextBox
        Me.txt_add_new = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_update = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 65)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(772, 263)
        Me.dgv.TabIndex = 0
        '
        'txt_item_no
        '
        Me.txt_item_no.Location = New System.Drawing.Point(231, 25)
        Me.txt_item_no.Name = "txt_item_no"
        Me.txt_item_no.Size = New System.Drawing.Size(139, 20)
        Me.txt_item_no.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(181, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Item no :"
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(526, 24)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(42, 23)
        Me.btn_go.TabIndex = 3
        Me.btn_go.Text = "Go"
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(376, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Org :"
        '
        'ddl_org
        '
        Me.ddl_org.FormattingEnabled = True
        Me.ddl_org.Location = New System.Drawing.Point(412, 25)
        Me.ddl_org.Name = "ddl_org"
        Me.ddl_org.Size = New System.Drawing.Size(95, 21)
        Me.ddl_org.TabIndex = 4
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(572, 334)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(68, 23)
        Me.btn_edit.TabIndex = 3
        Me.btn_edit.Text = "Edit MOQ"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_add_new_item
        '
        Me.btn_add_new_item.Location = New System.Drawing.Point(644, 334)
        Me.btn_add_new_item.Name = "btn_add_new_item"
        Me.btn_add_new_item.Size = New System.Drawing.Size(140, 23)
        Me.btn_add_new_item.TabIndex = 3
        Me.btn_add_new_item.Text = "Add MOQ ( for new Item)"
        Me.btn_add_new_item.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_moq)
        Me.Panel1.Controls.Add(Me.lbl_MOQ)
        Me.Panel1.Controls.Add(Me.txt_org_update)
        Me.Panel1.Controls.Add(Me.txt_add_new)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btn_update)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 363)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 78)
        Me.Panel1.TabIndex = 5
        '
        'txt_moq
        '
        Me.txt_moq.Location = New System.Drawing.Point(458, 27)
        Me.txt_moq.Name = "txt_moq"
        Me.txt_moq.Size = New System.Drawing.Size(57, 20)
        Me.txt_moq.TabIndex = 1
        '
        'lbl_MOQ
        '
        Me.lbl_MOQ.AutoSize = True
        Me.lbl_MOQ.Location = New System.Drawing.Point(403, 31)
        Me.lbl_MOQ.Name = "lbl_MOQ"
        Me.lbl_MOQ.Size = New System.Drawing.Size(38, 13)
        Me.lbl_MOQ.TabIndex = 2
        Me.lbl_MOQ.Text = "MOQ :"
        '
        'txt_org_update
        '
        Me.txt_org_update.Location = New System.Drawing.Point(318, 27)
        Me.txt_org_update.Name = "txt_org_update"
        Me.txt_org_update.Size = New System.Drawing.Size(68, 20)
        Me.txt_org_update.TabIndex = 1
        '
        'txt_add_new
        '
        Me.txt_add_new.Location = New System.Drawing.Point(93, 27)
        Me.txt_add_new.Name = "txt_add_new"
        Me.txt_add_new.Size = New System.Drawing.Size(169, 20)
        Me.txt_add_new.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Item no :"
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(529, 24)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(99, 23)
        Me.btn_update.TabIndex = 3
        Me.btn_update.Text = "Update MOQ"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Org :"
        '
        'DSP_MOQ_EDIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(800, 451)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ddl_org)
        Me.Controls.Add(Me.btn_add_new_item)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_go)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_item_no)
        Me.Controls.Add(Me.dgv)
        Me.MaximizeBox = False
        Me.Name = "DSP_MOQ_EDIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit DSP MOQ"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txt_item_no As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddl_org As System.Windows.Forms.ComboBox
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_add_new_item As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_add_new As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_moq As System.Windows.Forms.TextBox
    Friend WithEvents lbl_MOQ As System.Windows.Forms.Label
    Friend WithEvents txt_org_update As System.Windows.Forms.TextBox
End Class
