<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DDS_req
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_select_file = New System.Windows.Forms.Button()
        Me.txt_file_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_move_to_oracle = New System.Windows.Forms.Button()
        Me.btn_view_list = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_sheet_name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_org = New System.Windows.Forms.ComboBox()
        Me.chk_compact_valve = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 31)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(827, 306)
        Me.DataGridView1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btn_select_file
        '
        Me.btn_select_file.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btn_select_file.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_select_file.ForeColor = System.Drawing.Color.Brown
        Me.btn_select_file.Location = New System.Drawing.Point(655, 3)
        Me.btn_select_file.Name = "btn_select_file"
        Me.btn_select_file.Size = New System.Drawing.Size(75, 23)
        Me.btn_select_file.TabIndex = 1
        Me.btn_select_file.Text = "Select File"
        Me.btn_select_file.UseVisualStyleBackColor = False
        '
        'txt_file_name
        '
        Me.txt_file_name.Location = New System.Drawing.Point(139, 4)
        Me.txt_file_name.Name = "txt_file_name"
        Me.txt_file_name.Size = New System.Drawing.Size(255, 20)
        Me.txt_file_name.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(55, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File Name :"
        '
        'btn_move_to_oracle
        '
        Me.btn_move_to_oracle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_move_to_oracle.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btn_move_to_oracle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_move_to_oracle.ForeColor = System.Drawing.Color.Brown
        Me.btn_move_to_oracle.Location = New System.Drawing.Point(711, 343)
        Me.btn_move_to_oracle.Name = "btn_move_to_oracle"
        Me.btn_move_to_oracle.Size = New System.Drawing.Size(128, 23)
        Me.btn_move_to_oracle.TabIndex = 1
        Me.btn_move_to_oracle.Text = "Move to Oracle"
        Me.btn_move_to_oracle.UseVisualStyleBackColor = False
        '
        'btn_view_list
        '
        Me.btn_view_list.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_view_list.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btn_view_list.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_list.ForeColor = System.Drawing.Color.Brown
        Me.btn_view_list.Location = New System.Drawing.Point(569, 343)
        Me.btn_view_list.Name = "btn_view_list"
        Me.btn_view_list.Size = New System.Drawing.Size(127, 23)
        Me.btn_view_list.TabIndex = 1
        Me.btn_view_list.Text = "View XL list"
        Me.btn_view_list.UseVisualStyleBackColor = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(10, 403)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(470, 168)
        Me.DataGridView2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.OldLace
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button1.Location = New System.Drawing.Point(163, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(270, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "View Today's MKTG Req Addition"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txt_sheet_name
        '
        Me.txt_sheet_name.Location = New System.Drawing.Point(492, 4)
        Me.txt_sheet_name.Name = "txt_sheet_name"
        Me.txt_sheet_name.Size = New System.Drawing.Size(156, 20)
        Me.txt_sheet_name.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(405, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sheet Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Brown
        Me.Label3.Location = New System.Drawing.Point(12, 374)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Org :"
        '
        'cmb_org
        '
        Me.cmb_org.FormattingEnabled = True
        Me.cmb_org.Location = New System.Drawing.Point(53, 374)
        Me.cmb_org.Name = "cmb_org"
        Me.cmb_org.Size = New System.Drawing.Size(86, 21)
        Me.cmb_org.TabIndex = 4
        '
        'chk_compact_valve
        '
        Me.chk_compact_valve.AutoSize = True
        Me.chk_compact_valve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_compact_valve.ForeColor = System.Drawing.Color.Maroon
        Me.chk_compact_valve.Location = New System.Drawing.Point(745, 6)
        Me.chk_compact_valve.Name = "chk_compact_valve"
        Me.chk_compact_valve.Size = New System.Drawing.Size(199, 17)
        Me.chk_compact_valve.TabIndex = 5
        Me.chk_compact_valve.Text = "Compact Cylinder Requirement"
        Me.chk_compact_valve.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(520, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(319, 154)
        Me.Label4.TabIndex = 6
        '
        'DDS_req
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(851, 578)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chk_compact_valve)
        Me.Controls.Add(Me.cmb_org)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_sheet_name)
        Me.Controls.Add(Me.txt_file_name)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_view_list)
        Me.Controls.Add(Me.btn_move_to_oracle)
        Me.Controls.Add(Me.btn_select_file)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DDS_req"
        Me.Text = "DDS Requirement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_select_file As System.Windows.Forms.Button
    Friend WithEvents txt_file_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_move_to_oracle As System.Windows.Forms.Button
    Friend WithEvents btn_view_list As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_sheet_name As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_org As System.Windows.Forms.ComboBox
    Friend WithEvents chk_compact_valve As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As Label
End Class
