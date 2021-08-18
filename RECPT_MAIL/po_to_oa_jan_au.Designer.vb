<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class po_to_oa_jan_au
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
        Me.cmb_po_release_no = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cal_need_by_2 = New System.Windows.Forms.MonthCalendar()
        Me.cal_need_by_1 = New System.Windows.Forms.MonthCalendar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chk_1_yr_po = New System.Windows.Forms.CheckBox()
        Me.btn_view_order = New System.Windows.Forms.Button()
        Me.btn_interface = New System.Windows.Forms.Button()
        Me.btn_move_to_stg = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.btn_show_lines = New System.Windows.Forms.Button()
        Me.txt_po_no4 = New System.Windows.Forms.TextBox()
        Me.txt_po_no3 = New System.Windows.Forms.TextBox()
        Me.txt_need_by_to = New System.Windows.Forms.TextBox()
        Me.txt_need_by_from = New System.Windows.Forms.TextBox()
        Me.txt_po_no1 = New System.Windows.Forms.TextBox()
        Me.txt_po_no2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_po_release_no
        '
        Me.cmb_po_release_no.FormattingEnabled = True
        Me.cmb_po_release_no.Location = New System.Drawing.Point(880, 41)
        Me.cmb_po_release_no.Name = "cmb_po_release_no"
        Me.cmb_po_release_no.Size = New System.Drawing.Size(121, 21)
        Me.cmb_po_release_no.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(770, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "PO Release NO :"
        '
        'cal_need_by_2
        '
        Me.cal_need_by_2.Location = New System.Drawing.Point(316, 63)
        Me.cal_need_by_2.Name = "cal_need_by_2"
        Me.cal_need_by_2.TabIndex = 40
        Me.cal_need_by_2.Visible = False
        '
        'cal_need_by_1
        '
        Me.cal_need_by_1.Location = New System.Drawing.Point(58, 63)
        Me.cal_need_by_1.Name = "cal_need_by_1"
        Me.cal_need_by_1.TabIndex = 39
        Me.cal_need_by_1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Location = New System.Drawing.Point(523, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 17)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "V"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(265, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 17)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "V"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chk_1_yr_po
        '
        Me.chk_1_yr_po.AutoSize = True
        Me.chk_1_yr_po.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_1_yr_po.Location = New System.Drawing.Point(583, 44)
        Me.chk_1_yr_po.Name = "chk_1_yr_po"
        Me.chk_1_yr_po.Size = New System.Drawing.Size(172, 17)
        Me.chk_1_yr_po.TabIndex = 36
        Me.chk_1_yr_po.Text = "One Year PO(Blanket PO)"
        Me.chk_1_yr_po.UseVisualStyleBackColor = True
        '
        'btn_view_order
        '
        Me.btn_view_order.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_view_order.Location = New System.Drawing.Point(921, 492)
        Me.btn_view_order.Name = "btn_view_order"
        Me.btn_view_order.Size = New System.Drawing.Size(127, 23)
        Me.btn_view_order.TabIndex = 33
        Me.btn_view_order.Text = "Show Order Number"
        Me.btn_view_order.UseVisualStyleBackColor = True
        '
        'btn_interface
        '
        Me.btn_interface.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_interface.Location = New System.Drawing.Point(773, 492)
        Me.btn_interface.Name = "btn_interface"
        Me.btn_interface.Size = New System.Drawing.Size(127, 23)
        Me.btn_interface.TabIndex = 34
        Me.btn_interface.Text = "Move Items to Interface"
        Me.btn_interface.UseVisualStyleBackColor = True
        '
        'btn_move_to_stg
        '
        Me.btn_move_to_stg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_move_to_stg.Location = New System.Drawing.Point(640, 492)
        Me.btn_move_to_stg.Name = "btn_move_to_stg"
        Me.btn_move_to_stg.Size = New System.Drawing.Size(127, 23)
        Me.btn_move_to_stg.TabIndex = 35
        Me.btn_move_to_stg.Text = "Move Items to Staging"
        Me.btn_move_to_stg.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(15, 74)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(1039, 409)
        Me.dgv1.TabIndex = 32
        '
        'btn_show_lines
        '
        Me.btn_show_lines.Location = New System.Drawing.Point(899, 3)
        Me.btn_show_lines.Name = "btn_show_lines"
        Me.btn_show_lines.Size = New System.Drawing.Size(77, 23)
        Me.btn_show_lines.TabIndex = 31
        Me.btn_show_lines.Text = "View Items"
        Me.btn_show_lines.UseVisualStyleBackColor = True
        '
        'txt_po_no4
        '
        Me.txt_po_no4.Location = New System.Drawing.Point(735, 4)
        Me.txt_po_no4.Name = "txt_po_no4"
        Me.txt_po_no4.Size = New System.Drawing.Size(142, 20)
        Me.txt_po_no4.TabIndex = 30
        '
        'txt_po_no3
        '
        Me.txt_po_no3.Location = New System.Drawing.Point(520, 4)
        Me.txt_po_no3.Name = "txt_po_no3"
        Me.txt_po_no3.Size = New System.Drawing.Size(142, 20)
        Me.txt_po_no3.TabIndex = 29
        '
        'txt_need_by_to
        '
        Me.txt_need_by_to.Location = New System.Drawing.Point(403, 42)
        Me.txt_need_by_to.Name = "txt_need_by_to"
        Me.txt_need_by_to.Size = New System.Drawing.Size(142, 20)
        Me.txt_need_by_to.TabIndex = 28
        '
        'txt_need_by_from
        '
        Me.txt_need_by_from.Location = New System.Drawing.Point(144, 42)
        Me.txt_need_by_from.Name = "txt_need_by_from"
        Me.txt_need_by_from.Size = New System.Drawing.Size(142, 20)
        Me.txt_need_by_from.TabIndex = 27
        '
        'txt_po_no1
        '
        Me.txt_po_no1.Location = New System.Drawing.Point(83, 4)
        Me.txt_po_no1.Name = "txt_po_no1"
        Me.txt_po_no1.Size = New System.Drawing.Size(142, 20)
        Me.txt_po_no1.TabIndex = 26
        '
        'txt_po_no2
        '
        Me.txt_po_no2.Location = New System.Drawing.Point(305, 4)
        Me.txt_po_no2.Name = "txt_po_no2"
        Me.txt_po_no2.Size = New System.Drawing.Size(142, 20)
        Me.txt_po_no2.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(666, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "PO No .4:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Need by Date To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(451, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PO No .3:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Need by Date  From :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "PO No .2:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "PO No .1:"
        '
        'po_to_oa_jan_au
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 519)
        Me.Controls.Add(Me.cmb_po_release_no)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cal_need_by_2)
        Me.Controls.Add(Me.cal_need_by_1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chk_1_yr_po)
        Me.Controls.Add(Me.btn_view_order)
        Me.Controls.Add(Me.btn_interface)
        Me.Controls.Add(Me.btn_move_to_stg)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_show_lines)
        Me.Controls.Add(Me.txt_po_no4)
        Me.Controls.Add(Me.txt_po_no3)
        Me.Controls.Add(Me.txt_need_by_to)
        Me.Controls.Add(Me.txt_need_by_from)
        Me.Controls.Add(Me.txt_po_no1)
        Me.Controls.Add(Me.txt_po_no2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "po_to_oa_jan_au"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PO TO OA Migration -- Jan Automation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_po_release_no As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cal_need_by_2 As MonthCalendar
    Friend WithEvents cal_need_by_1 As MonthCalendar
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents chk_1_yr_po As CheckBox
    Friend WithEvents btn_view_order As Button
    Friend WithEvents btn_interface As Button
    Friend WithEvents btn_move_to_stg As Button
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents btn_show_lines As Button
    Friend WithEvents txt_po_no4 As TextBox
    Friend WithEvents txt_po_no3 As TextBox
    Friend WithEvents txt_need_by_to As TextBox
    Friend WithEvents txt_need_by_from As TextBox
    Friend WithEvents txt_po_no1 As TextBox
    Friend WithEvents txt_po_no2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
