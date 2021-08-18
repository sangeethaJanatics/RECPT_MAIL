<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMS_new
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMS_new))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.date_time_shift3_end_time = New System.Windows.Forms.DateTimePicker()
        Me.date_time_shift3_st_time = New System.Windows.Forms.DateTimePicker()
        Me.date_time_shift2_end_time = New System.Windows.Forms.DateTimePicker()
        Me.date_time_shift2_st_time = New System.Windows.Forms.DateTimePicker()
        Me.date_time_shift1_end_time = New System.Windows.Forms.DateTimePicker()
        Me.date_time_shift1_st_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift3_end_time = New System.Windows.Forms.Label()
        Me.lbl_shift2_end_time = New System.Windows.Forms.Label()
        Me.lbl_shift3_start_time = New System.Windows.Forms.Label()
        Me.lbl_shift1_end_time = New System.Windows.Forms.Label()
        Me.lbl_shift2_start_time = New System.Windows.Forms.Label()
        Me.lbl_shift1_start_time = New System.Windows.Forms.Label()
        Me.txt_no_of_shifts = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_save_shift_detail = New System.Windows.Forms.Button()
        Me.txt_Alert_flow_idle = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Alert_flow_running = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_create_mysql_tables = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.rad_minute = New System.Windows.Forms.RadioButton()
        Me.txt_Alert_recom_flow_idle = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Alert_recom_flow_running = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_machine_model = New System.Windows.Forms.ComboBox()
        Me.txt_create_table_machine_name = New System.Windows.Forms.TextBox()
        Me.rad_hour = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_create_table_machine_make = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_table_creation_dept_name = New System.Windows.Forms.ComboBox()
        Me.txt_flow_meter_id = New System.Windows.Forms.TextBox()
        Me.dgv_report = New System.Windows.Forms.DataGridView()
        Me.rad_month = New System.Windows.Forms.RadioButton()
        Me.rad_shift = New System.Windows.Forms.RadioButton()
        Me.rad_day = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.WebBrowser_report = New System.Windows.Forms.WebBrowser()
        Me.txt_customer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.rad_cfm = New System.Windows.Forms.RadioButton()
        Me.rad_lpm = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.dgv_dashboard = New System.Windows.Forms.DataGridView()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Panel_view_machines = New System.Windows.Forms.Panel()
        Me.Panel1_edit_machine_details = New System.Windows.Forms.Panel()
        Me.btn_edit_machine_details = New System.Windows.Forms.Button()
        Me.txt_alert_running_edit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_recomm_running_edit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_machines_new = New System.Windows.Forms.DataGridView()
        Me.Panel1_add_new_machines = New System.Windows.Forms.Panel()
        Me.btn_search_customer = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_save_machine_details = New System.Windows.Forms.Button()
        Me.BTN_ADD_NEW_MACHINES = New System.Windows.Forms.Button()
        Me.btn_view_machines = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.dgv_alert = New System.Windows.Forms.DataGridView()
        Me.TabPage8.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgv_report, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel_view_machines.SuspendLayout()
        Me.Panel1_edit_machine_details.SuspendLayout()
        CType(Me.dgv_machines_new, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1_add_new_machines.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgv_alert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage8.Controls.Add(Me.date_time_shift3_end_time)
        Me.TabPage8.Controls.Add(Me.date_time_shift3_st_time)
        Me.TabPage8.Controls.Add(Me.date_time_shift2_end_time)
        Me.TabPage8.Controls.Add(Me.date_time_shift2_st_time)
        Me.TabPage8.Controls.Add(Me.date_time_shift1_end_time)
        Me.TabPage8.Controls.Add(Me.date_time_shift1_st_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift3_end_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift2_end_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift3_start_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift1_end_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift2_start_time)
        Me.TabPage8.Controls.Add(Me.lbl_shift1_start_time)
        Me.TabPage8.Controls.Add(Me.txt_no_of_shifts)
        Me.TabPage8.Controls.Add(Me.Label14)
        Me.TabPage8.Controls.Add(Me.btn_save_shift_detail)
        Me.TabPage8.Location = New System.Drawing.Point(4, 36)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1063, 424)
        Me.TabPage8.TabIndex = 3
        Me.TabPage8.Text = "SHIFT"
        '
        'date_time_shift3_end_time
        '
        Me.date_time_shift3_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift3_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift3_end_time.Location = New System.Drawing.Point(240, 252)
        Me.date_time_shift3_end_time.Name = "date_time_shift3_end_time"
        Me.date_time_shift3_end_time.ShowUpDown = True
        Me.date_time_shift3_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift3_end_time.TabIndex = 3
        '
        'date_time_shift3_st_time
        '
        Me.date_time_shift3_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift3_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift3_st_time.Location = New System.Drawing.Point(240, 223)
        Me.date_time_shift3_st_time.Name = "date_time_shift3_st_time"
        Me.date_time_shift3_st_time.ShowUpDown = True
        Me.date_time_shift3_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift3_st_time.TabIndex = 3
        '
        'date_time_shift2_end_time
        '
        Me.date_time_shift2_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift2_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift2_end_time.Location = New System.Drawing.Point(244, 190)
        Me.date_time_shift2_end_time.Name = "date_time_shift2_end_time"
        Me.date_time_shift2_end_time.ShowUpDown = True
        Me.date_time_shift2_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift2_end_time.TabIndex = 3
        '
        'date_time_shift2_st_time
        '
        Me.date_time_shift2_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift2_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift2_st_time.Location = New System.Drawing.Point(244, 161)
        Me.date_time_shift2_st_time.Name = "date_time_shift2_st_time"
        Me.date_time_shift2_st_time.ShowUpDown = True
        Me.date_time_shift2_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift2_st_time.TabIndex = 3
        '
        'date_time_shift1_end_time
        '
        Me.date_time_shift1_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift1_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift1_end_time.Location = New System.Drawing.Point(244, 117)
        Me.date_time_shift1_end_time.Name = "date_time_shift1_end_time"
        Me.date_time_shift1_end_time.ShowUpDown = True
        Me.date_time_shift1_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift1_end_time.TabIndex = 3
        '
        'date_time_shift1_st_time
        '
        Me.date_time_shift1_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift1_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift1_st_time.Location = New System.Drawing.Point(244, 88)
        Me.date_time_shift1_st_time.Name = "date_time_shift1_st_time"
        Me.date_time_shift1_st_time.ShowUpDown = True
        Me.date_time_shift1_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift1_st_time.TabIndex = 3
        '
        'lbl_shift3_end_time
        '
        Me.lbl_shift3_end_time.AutoSize = True
        Me.lbl_shift3_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift3_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift3_end_time.Location = New System.Drawing.Point(96, 252)
        Me.lbl_shift3_end_time.Name = "lbl_shift3_end_time"
        Me.lbl_shift3_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift3_end_time.TabIndex = 1
        Me.lbl_shift3_end_time.Text = "Shift3  End Time :"
        '
        'lbl_shift2_end_time
        '
        Me.lbl_shift2_end_time.AutoSize = True
        Me.lbl_shift2_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift2_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift2_end_time.Location = New System.Drawing.Point(96, 190)
        Me.lbl_shift2_end_time.Name = "lbl_shift2_end_time"
        Me.lbl_shift2_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift2_end_time.TabIndex = 1
        Me.lbl_shift2_end_time.Text = "Shift2  End Time :"
        '
        'lbl_shift3_start_time
        '
        Me.lbl_shift3_start_time.AutoSize = True
        Me.lbl_shift3_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift3_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift3_start_time.Location = New System.Drawing.Point(94, 223)
        Me.lbl_shift3_start_time.Name = "lbl_shift3_start_time"
        Me.lbl_shift3_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift3_start_time.TabIndex = 1
        Me.lbl_shift3_start_time.Text = "Shift3 Start Time :"
        '
        'lbl_shift1_end_time
        '
        Me.lbl_shift1_end_time.AutoSize = True
        Me.lbl_shift1_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift1_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift1_end_time.Location = New System.Drawing.Point(96, 117)
        Me.lbl_shift1_end_time.Name = "lbl_shift1_end_time"
        Me.lbl_shift1_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift1_end_time.TabIndex = 1
        Me.lbl_shift1_end_time.Text = "Shift1  End Time :"
        '
        'lbl_shift2_start_time
        '
        Me.lbl_shift2_start_time.AutoSize = True
        Me.lbl_shift2_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift2_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift2_start_time.Location = New System.Drawing.Point(94, 161)
        Me.lbl_shift2_start_time.Name = "lbl_shift2_start_time"
        Me.lbl_shift2_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift2_start_time.TabIndex = 1
        Me.lbl_shift2_start_time.Text = "Shift2 Start Time :"
        '
        'lbl_shift1_start_time
        '
        Me.lbl_shift1_start_time.AutoSize = True
        Me.lbl_shift1_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift1_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift1_start_time.Location = New System.Drawing.Point(94, 88)
        Me.lbl_shift1_start_time.Name = "lbl_shift1_start_time"
        Me.lbl_shift1_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift1_start_time.TabIndex = 1
        Me.lbl_shift1_start_time.Text = "Shift1 Start Time :"
        '
        'txt_no_of_shifts
        '
        Me.txt_no_of_shifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_of_shifts.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.txt_no_of_shifts.Location = New System.Drawing.Point(244, 48)
        Me.txt_no_of_shifts.Name = "txt_no_of_shifts"
        Me.txt_no_of_shifts.Size = New System.Drawing.Size(100, 23)
        Me.txt_no_of_shifts.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label14.Location = New System.Drawing.Point(133, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "No of shifts :"
        '
        'btn_save_shift_detail
        '
        Me.btn_save_shift_detail.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_save_shift_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save_shift_detail.ForeColor = System.Drawing.Color.MistyRose
        Me.btn_save_shift_detail.Location = New System.Drawing.Point(269, 285)
        Me.btn_save_shift_detail.Name = "btn_save_shift_detail"
        Me.btn_save_shift_detail.Size = New System.Drawing.Size(75, 29)
        Me.btn_save_shift_detail.TabIndex = 0
        Me.btn_save_shift_detail.Text = "Save"
        Me.btn_save_shift_detail.UseVisualStyleBackColor = False
        '
        'txt_Alert_flow_idle
        '
        Me.txt_Alert_flow_idle.Location = New System.Drawing.Point(243, 272)
        Me.txt_Alert_flow_idle.Name = "txt_Alert_flow_idle"
        Me.txt_Alert_flow_idle.Size = New System.Drawing.Size(135, 23)
        Me.txt_Alert_flow_idle.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label12.Location = New System.Drawing.Point(109, 272)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Alert Flow  Idle  :"
        '
        'txt_Alert_flow_running
        '
        Me.txt_Alert_flow_running.Location = New System.Drawing.Point(243, 244)
        Me.txt_Alert_flow_running.Name = "txt_Alert_flow_running"
        Me.txt_Alert_flow_running.Size = New System.Drawing.Size(135, 23)
        Me.txt_Alert_flow_running.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label11.Location = New System.Drawing.Point(85, 247)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(154, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Alert Flow Running :"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackgroundImage = Global.RECPT_MAIL.My.Resources.Resources.background_head1
        Me.PictureBox2.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(888, 34)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.RECPT_MAIL.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(892, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 27)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "settings.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Reports_icon1.png")
        Me.ImageList1.Images.SetKeyName(2, "dash_board_images.jpg")
        Me.ImageList1.Images.SetKeyName(3, "flow_meter_images1.jpg")
        Me.ImageList1.Images.SetKeyName(4, "flow_meter_images2.jpg")
        Me.ImageList1.Images.SetKeyName(5, "settings_images1.jpg")
        Me.ImageList1.Images.SetKeyName(6, "settings_images3.jpg")
        Me.ImageList1.Images.SetKeyName(7, "sync_images1.jpg")
        Me.ImageList1.Images.SetKeyName(8, "sync_images2.jpg")
        Me.ImageList1.Images.SetKeyName(9, "sync_images3.jpg")
        Me.ImageList1.Images.SetKeyName(10, "settings_images2.png")
        Me.ImageList1.Images.SetKeyName(11, "reports_image2.jpg")
        Me.ImageList1.Images.SetKeyName(12, "reports_images.jpg")
        '
        'btn_create_mysql_tables
        '
        Me.btn_create_mysql_tables.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_create_mysql_tables.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create_mysql_tables.Location = New System.Drawing.Point(8, 6)
        Me.btn_create_mysql_tables.Name = "btn_create_mysql_tables"
        Me.btn_create_mysql_tables.Size = New System.Drawing.Size(154, 53)
        Me.btn_create_mysql_tables.TabIndex = 3
        Me.btn_create_mysql_tables.Text = "Create MySQL Tables"
        Me.btn_create_mysql_tables.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btn_create_mysql_tables)
        Me.TabPage4.ImageIndex = 9
        Me.TabPage4.Location = New System.Drawing.Point(4, 71)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1082, 470)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'rad_minute
        '
        Me.rad_minute.AutoSize = True
        Me.rad_minute.Checked = True
        Me.rad_minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_minute.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_minute.Location = New System.Drawing.Point(66, 3)
        Me.rad_minute.Name = "rad_minute"
        Me.rad_minute.Size = New System.Drawing.Size(74, 21)
        Me.rad_minute.TabIndex = 0
        Me.rad_minute.TabStop = True
        Me.rad_minute.Text = "Minute"
        Me.rad_minute.UseVisualStyleBackColor = True
        '
        'txt_Alert_recom_flow_idle
        '
        Me.txt_Alert_recom_flow_idle.Location = New System.Drawing.Point(243, 216)
        Me.txt_Alert_recom_flow_idle.Name = "txt_Alert_recom_flow_idle"
        Me.txt_Alert_recom_flow_idle.Size = New System.Drawing.Size(135, 23)
        Me.txt_Alert_recom_flow_idle.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label13.Location = New System.Drawing.Point(42, 220)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(197, 17)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Recommedded Flow  Idle :"
        '
        'txt_Alert_recom_flow_running
        '
        Me.txt_Alert_recom_flow_running.Location = New System.Drawing.Point(243, 188)
        Me.txt_Alert_recom_flow_running.Name = "txt_Alert_recom_flow_running"
        Me.txt_Alert_recom_flow_running.Size = New System.Drawing.Size(137, 23)
        Me.txt_Alert_recom_flow_running.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label10.Location = New System.Drawing.Point(8, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(231, 17)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Recommedded Flow  Running :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label4.Location = New System.Drawing.Point(91, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Department Name :"
        '
        'cmb_machine_model
        '
        Me.cmb_machine_model.FormattingEnabled = True
        Me.cmb_machine_model.Location = New System.Drawing.Point(243, 102)
        Me.cmb_machine_model.Name = "cmb_machine_model"
        Me.cmb_machine_model.Size = New System.Drawing.Size(198, 24)
        Me.cmb_machine_model.TabIndex = 3
        '
        'txt_create_table_machine_name
        '
        Me.txt_create_table_machine_name.Location = New System.Drawing.Point(243, 45)
        Me.txt_create_table_machine_name.Name = "txt_create_table_machine_name"
        Me.txt_create_table_machine_name.Size = New System.Drawing.Size(199, 23)
        Me.txt_create_table_machine_name.TabIndex = 1
        '
        'rad_hour
        '
        Me.rad_hour.AutoSize = True
        Me.rad_hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_hour.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_hour.Location = New System.Drawing.Point(143, 3)
        Me.rad_hour.Name = "rad_hour"
        Me.rad_hour.Size = New System.Drawing.Size(61, 21)
        Me.rad_hour.TabIndex = 0
        Me.rad_hour.Text = "Hour"
        Me.rad_hour.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label6.Location = New System.Drawing.Point(115, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Machine Name :"
        '
        'cmb_create_table_machine_make
        '
        Me.cmb_create_table_machine_make.FormattingEnabled = True
        Me.cmb_create_table_machine_make.Location = New System.Drawing.Point(243, 131)
        Me.cmb_create_table_machine_make.Name = "cmb_create_table_machine_make"
        Me.cmb_create_table_machine_make.Size = New System.Drawing.Size(198, 24)
        Me.cmb_create_table_machine_make.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label1.Location = New System.Drawing.Point(107, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label8.Location = New System.Drawing.Point(128, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Flow Meter ID:"
        '
        'cmb_table_creation_dept_name
        '
        Me.cmb_table_creation_dept_name.FormattingEnabled = True
        Me.cmb_table_creation_dept_name.Location = New System.Drawing.Point(243, 73)
        Me.cmb_table_creation_dept_name.Name = "cmb_table_creation_dept_name"
        Me.cmb_table_creation_dept_name.Size = New System.Drawing.Size(198, 24)
        Me.cmb_table_creation_dept_name.TabIndex = 3
        '
        'txt_flow_meter_id
        '
        Me.txt_flow_meter_id.Location = New System.Drawing.Point(243, 160)
        Me.txt_flow_meter_id.Name = "txt_flow_meter_id"
        Me.txt_flow_meter_id.Size = New System.Drawing.Size(198, 23)
        Me.txt_flow_meter_id.TabIndex = 1
        '
        'dgv_report
        '
        Me.dgv_report.AllowUserToAddRows = False
        Me.dgv_report.AllowUserToDeleteRows = False
        Me.dgv_report.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_report.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_report.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_report.EnableHeadersVisualStyles = False
        Me.dgv_report.Location = New System.Drawing.Point(66, 274)
        Me.dgv_report.Name = "dgv_report"
        Me.dgv_report.ReadOnly = True
        Me.dgv_report.Size = New System.Drawing.Size(872, 104)
        Me.dgv_report.TabIndex = 1
        '
        'rad_month
        '
        Me.rad_month.AutoSize = True
        Me.rad_month.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_month.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_month.Location = New System.Drawing.Point(359, 3)
        Me.rad_month.Name = "rad_month"
        Me.rad_month.Size = New System.Drawing.Size(70, 21)
        Me.rad_month.TabIndex = 0
        Me.rad_month.Text = "Month"
        Me.rad_month.UseVisualStyleBackColor = True
        '
        'rad_shift
        '
        Me.rad_shift.AutoSize = True
        Me.rad_shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_shift.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_shift.Location = New System.Drawing.Point(219, 3)
        Me.rad_shift.Name = "rad_shift"
        Me.rad_shift.Size = New System.Drawing.Size(59, 21)
        Me.rad_shift.TabIndex = 0
        Me.rad_shift.Text = "Shift"
        Me.rad_shift.UseVisualStyleBackColor = True
        '
        'rad_day
        '
        Me.rad_day.AutoSize = True
        Me.rad_day.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_day.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_day.Location = New System.Drawing.Point(294, 3)
        Me.rad_day.Name = "rad_day"
        Me.rad_day.Size = New System.Drawing.Size(54, 21)
        Me.rad_day.TabIndex = 0
        Me.rad_day.Text = "Day"
        Me.rad_day.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.WebBrowser_report)
        Me.TabPage3.Controls.Add(Me.dgv_report)
        Me.TabPage3.Controls.Add(Me.rad_month)
        Me.TabPage3.Controls.Add(Me.rad_shift)
        Me.TabPage3.Controls.Add(Me.rad_day)
        Me.TabPage3.Controls.Add(Me.rad_hour)
        Me.TabPage3.Controls.Add(Me.rad_minute)
        Me.TabPage3.ImageIndex = 12
        Me.TabPage3.Location = New System.Drawing.Point(4, 71)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1082, 470)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'WebBrowser_report
        '
        Me.WebBrowser_report.Location = New System.Drawing.Point(66, 30)
        Me.WebBrowser_report.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser_report.Name = "WebBrowser_report"
        Me.WebBrowser_report.Size = New System.Drawing.Size(840, 228)
        Me.WebBrowser_report.TabIndex = 2
        '
        'txt_customer
        '
        Me.txt_customer.Location = New System.Drawing.Point(243, 17)
        Me.txt_customer.Name = "txt_customer"
        Me.txt_customer.Size = New System.Drawing.Size(447, 23)
        Me.txt_customer.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Location = New System.Drawing.Point(123, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Machine Make:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(4, 39)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(3, 10)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1048, 545)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.rad_cfm)
        Me.TabPage1.Controls.Add(Me.rad_lpm)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.WebBrowser1)
        Me.TabPage1.Controls.Add(Me.dgv_dashboard)
        Me.TabPage1.Controls.Add(Me.btn_refresh)
        Me.TabPage1.ForeColor = System.Drawing.Color.Black
        Me.TabPage1.ImageKey = "dash_board_images.jpg"
        Me.TabPage1.Location = New System.Drawing.Point(4, 71)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(10)
        Me.TabPage1.Size = New System.Drawing.Size(1040, 470)
        Me.TabPage1.TabIndex = 0
        '
        'rad_cfm
        '
        Me.rad_cfm.AutoSize = True
        Me.rad_cfm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cfm.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_cfm.Location = New System.Drawing.Point(823, 3)
        Me.rad_cfm.Name = "rad_cfm"
        Me.rad_cfm.Size = New System.Drawing.Size(57, 21)
        Me.rad_cfm.TabIndex = 5
        Me.rad_cfm.Text = "CFM"
        Me.rad_cfm.UseVisualStyleBackColor = True
        '
        'rad_lpm
        '
        Me.rad_lpm.AutoSize = True
        Me.rad_lpm.Checked = True
        Me.rad_lpm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_lpm.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_lpm.Location = New System.Drawing.Point(763, 3)
        Me.rad_lpm.Name = "rad_lpm"
        Me.rad_lpm.Size = New System.Drawing.Size(57, 21)
        Me.rad_lpm.TabIndex = 5
        Me.rad_lpm.TabStop = True
        Me.rad_lpm.Text = "LPM"
        Me.rad_lpm.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label7.Location = New System.Drawing.Point(28, 315)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Flow values"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(13, 29)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1019, 256)
        Me.WebBrowser1.TabIndex = 2
        '
        'dgv_dashboard
        '
        Me.dgv_dashboard.AllowUserToAddRows = False
        Me.dgv_dashboard.AllowUserToDeleteRows = False
        Me.dgv_dashboard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_dashboard.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_dashboard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_dashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dashboard.Location = New System.Drawing.Point(27, 336)
        Me.dgv_dashboard.Name = "dgv_dashboard"
        Me.dgv_dashboard.ReadOnly = True
        Me.dgv_dashboard.Size = New System.Drawing.Size(723, 72)
        Me.dgv_dashboard.TabIndex = 1
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Location = New System.Drawing.Point(712, 2)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(38, 23)
        Me.btn_refresh.TabIndex = 0
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        Me.btn_refresh.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.ImageIndex = 10
        Me.TabPage2.Location = New System.Drawing.Point(4, 71)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1040, 470)
        Me.TabPage2.TabIndex = 1
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage8)
        Me.TabControl2.Location = New System.Drawing.Point(8, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.Padding = New System.Drawing.Point(10, 10)
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1029, 464)
        Me.TabControl2.TabIndex = 4
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage5.Controls.Add(Me.Panel_view_machines)
        Me.TabPage5.Controls.Add(Me.Panel1_add_new_machines)
        Me.TabPage5.Controls.Add(Me.BTN_ADD_NEW_MACHINES)
        Me.TabPage5.Controls.Add(Me.btn_view_machines)
        Me.TabPage5.Location = New System.Drawing.Point(4, 39)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1021, 421)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "MACHINE"
        '
        'Panel_view_machines
        '
        Me.Panel_view_machines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_view_machines.Controls.Add(Me.Panel1_edit_machine_details)
        Me.Panel_view_machines.Controls.Add(Me.dgv_machines_new)
        Me.Panel_view_machines.Location = New System.Drawing.Point(3, 39)
        Me.Panel_view_machines.Name = "Panel_view_machines"
        Me.Panel_view_machines.Size = New System.Drawing.Size(1015, 339)
        Me.Panel_view_machines.TabIndex = 20
        '
        'Panel1_edit_machine_details
        '
        Me.Panel1_edit_machine_details.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1_edit_machine_details.Controls.Add(Me.btn_edit_machine_details)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_alert_running_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label9)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_recomm_running_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label3)
        Me.Panel1_edit_machine_details.Location = New System.Drawing.Point(15, 269)
        Me.Panel1_edit_machine_details.Name = "Panel1_edit_machine_details"
        Me.Panel1_edit_machine_details.Size = New System.Drawing.Size(790, 70)
        Me.Panel1_edit_machine_details.TabIndex = 22
        '
        'btn_edit_machine_details
        '
        Me.btn_edit_machine_details.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_edit_machine_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit_machine_details.ForeColor = System.Drawing.Color.White
        Me.btn_edit_machine_details.Location = New System.Drawing.Point(623, 3)
        Me.btn_edit_machine_details.Name = "btn_edit_machine_details"
        Me.btn_edit_machine_details.Size = New System.Drawing.Size(102, 31)
        Me.btn_edit_machine_details.TabIndex = 21
        Me.btn_edit_machine_details.Text = "Save"
        Me.btn_edit_machine_details.UseVisualStyleBackColor = False
        '
        'txt_alert_running_edit
        '
        Me.txt_alert_running_edit.Location = New System.Drawing.Point(493, 8)
        Me.txt_alert_running_edit.Name = "txt_alert_running_edit"
        Me.txt_alert_running_edit.Size = New System.Drawing.Size(125, 23)
        Me.txt_alert_running_edit.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(364, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Alert Flow Running:"
        '
        'txt_recomm_running_edit
        '
        Me.txt_recomm_running_edit.Location = New System.Drawing.Point(225, 8)
        Me.txt_recomm_running_edit.Name = "txt_recomm_running_edit"
        Me.txt_recomm_running_edit.Size = New System.Drawing.Size(125, 23)
        Me.txt_recomm_running_edit.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Recommended Flow Running:"
        '
        'dgv_machines_new
        '
        Me.dgv_machines_new.AllowUserToAddRows = False
        Me.dgv_machines_new.AllowUserToDeleteRows = False
        Me.dgv_machines_new.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_machines_new.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_machines_new.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_machines_new.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_machines_new.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_machines_new.EnableHeadersVisualStyles = False
        Me.dgv_machines_new.Location = New System.Drawing.Point(13, 13)
        Me.dgv_machines_new.Name = "dgv_machines_new"
        Me.dgv_machines_new.ReadOnly = True
        Me.dgv_machines_new.Size = New System.Drawing.Size(987, 249)
        Me.dgv_machines_new.TabIndex = 19
        '
        'Panel1_add_new_machines
        '
        Me.Panel1_add_new_machines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1_add_new_machines.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_Alert_flow_idle)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label12)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_Alert_flow_running)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label11)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_Alert_recom_flow_idle)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label13)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_Alert_recom_flow_running)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label10)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label4)
        Me.Panel1_add_new_machines.Controls.Add(Me.cmb_machine_model)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_create_table_machine_name)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label6)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_customer)
        Me.Panel1_add_new_machines.Controls.Add(Me.cmb_create_table_machine_make)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label1)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label8)
        Me.Panel1_add_new_machines.Controls.Add(Me.cmb_table_creation_dept_name)
        Me.Panel1_add_new_machines.Controls.Add(Me.txt_flow_meter_id)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label2)
        Me.Panel1_add_new_machines.Controls.Add(Me.btn_search_customer)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label5)
        Me.Panel1_add_new_machines.Controls.Add(Me.btn_save_machine_details)
        Me.Panel1_add_new_machines.Location = New System.Drawing.Point(6, 37)
        Me.Panel1_add_new_machines.Name = "Panel1_add_new_machines"
        Me.Panel1_add_new_machines.Size = New System.Drawing.Size(1005, 339)
        Me.Panel1_add_new_machines.TabIndex = 4
        Me.Panel1_add_new_machines.Visible = False
        '
        'btn_search_customer
        '
        Me.btn_search_customer.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_search_customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search_customer.ForeColor = System.Drawing.Color.White
        Me.btn_search_customer.Location = New System.Drawing.Point(696, 15)
        Me.btn_search_customer.Name = "btn_search_customer"
        Me.btn_search_customer.Size = New System.Drawing.Size(41, 27)
        Me.btn_search_customer.TabIndex = 2
        Me.btn_search_customer.Text = ". . ."
        Me.btn_search_customer.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label5.Location = New System.Drawing.Point(118, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Machine Model:"
        '
        'btn_save_machine_details
        '
        Me.btn_save_machine_details.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_save_machine_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save_machine_details.ForeColor = System.Drawing.Color.White
        Me.btn_save_machine_details.Location = New System.Drawing.Point(242, 311)
        Me.btn_save_machine_details.Name = "btn_save_machine_details"
        Me.btn_save_machine_details.Size = New System.Drawing.Size(174, 26)
        Me.btn_save_machine_details.TabIndex = 2
        Me.btn_save_machine_details.Text = "Save Machine Details"
        Me.btn_save_machine_details.UseVisualStyleBackColor = False
        '
        'BTN_ADD_NEW_MACHINES
        '
        Me.BTN_ADD_NEW_MACHINES.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BTN_ADD_NEW_MACHINES.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ADD_NEW_MACHINES.ForeColor = System.Drawing.Color.White
        Me.BTN_ADD_NEW_MACHINES.Location = New System.Drawing.Point(232, 1)
        Me.BTN_ADD_NEW_MACHINES.Name = "BTN_ADD_NEW_MACHINES"
        Me.BTN_ADD_NEW_MACHINES.Size = New System.Drawing.Size(102, 31)
        Me.BTN_ADD_NEW_MACHINES.TabIndex = 2
        Me.BTN_ADD_NEW_MACHINES.Text = "Add New "
        Me.BTN_ADD_NEW_MACHINES.UseVisualStyleBackColor = False
        '
        'btn_view_machines
        '
        Me.btn_view_machines.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_view_machines.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view_machines.ForeColor = System.Drawing.Color.White
        Me.btn_view_machines.Location = New System.Drawing.Point(340, 2)
        Me.btn_view_machines.Name = "btn_view_machines"
        Me.btn_view_machines.Size = New System.Drawing.Size(124, 31)
        Me.btn_view_machines.TabIndex = 2
        Me.btn_view_machines.Text = "View Machines"
        Me.btn_view_machines.UseVisualStyleBackColor = False
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 36)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1063, 424)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "USER"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.dgv_alert)
        Me.TabPage7.Location = New System.Drawing.Point(4, 36)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1063, 424)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "GENERAL"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'dgv_alert
        '
        Me.dgv_alert.BackgroundColor = System.Drawing.Color.White
        Me.dgv_alert.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_alert.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_alert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_alert.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_alert.EnableHeadersVisualStyles = False
        Me.dgv_alert.GridColor = System.Drawing.Color.Gray
        Me.dgv_alert.Location = New System.Drawing.Point(6, 242)
        Me.dgv_alert.Name = "dgv_alert"
        Me.dgv_alert.Size = New System.Drawing.Size(902, 140)
        Me.dgv_alert.TabIndex = 6
        '
        'FMS_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 489)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FMS_new"
        Me.Text = "FMS_new"
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgv_report, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgv_dashboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.Panel_view_machines.ResumeLayout(False)
        Me.Panel1_edit_machine_details.ResumeLayout(False)
        Me.Panel1_edit_machine_details.PerformLayout()
        CType(Me.dgv_machines_new, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1_add_new_machines.ResumeLayout(False)
        Me.Panel1_add_new_machines.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        CType(Me.dgv_alert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents date_time_shift3_end_time As DateTimePicker
    Friend WithEvents date_time_shift3_st_time As DateTimePicker
    Friend WithEvents date_time_shift2_end_time As DateTimePicker
    Friend WithEvents date_time_shift2_st_time As DateTimePicker
    Friend WithEvents date_time_shift1_end_time As DateTimePicker
    Friend WithEvents date_time_shift1_st_time As DateTimePicker
    Friend WithEvents lbl_shift3_end_time As Label
    Friend WithEvents lbl_shift2_end_time As Label
    Friend WithEvents lbl_shift3_start_time As Label
    Friend WithEvents lbl_shift1_end_time As Label
    Friend WithEvents lbl_shift2_start_time As Label
    Friend WithEvents lbl_shift1_start_time As Label
    Friend WithEvents txt_no_of_shifts As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btn_save_shift_detail As Button
    Friend WithEvents txt_Alert_flow_idle As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_Alert_flow_running As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btn_create_mysql_tables As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents rad_minute As RadioButton
    Friend WithEvents txt_Alert_recom_flow_idle As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_Alert_recom_flow_running As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_machine_model As ComboBox
    Friend WithEvents txt_create_table_machine_name As TextBox
    Friend WithEvents rad_hour As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents cmb_create_table_machine_make As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmb_table_creation_dept_name As ComboBox
    Friend WithEvents txt_flow_meter_id As TextBox
    Friend WithEvents dgv_report As DataGridView
    Friend WithEvents rad_month As RadioButton
    Friend WithEvents rad_shift As RadioButton
    Friend WithEvents rad_day As RadioButton
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents WebBrowser_report As WebBrowser
    Friend WithEvents txt_customer As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents rad_cfm As RadioButton
    Friend WithEvents rad_lpm As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents dgv_dashboard As DataGridView
    Friend WithEvents btn_refresh As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Panel_view_machines As Panel
    Friend WithEvents Panel1_edit_machine_details As Panel
    Friend WithEvents btn_edit_machine_details As Button
    Friend WithEvents txt_alert_running_edit As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_recomm_running_edit As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv_machines_new As DataGridView
    Friend WithEvents Panel1_add_new_machines As Panel
    Friend WithEvents btn_search_customer As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_save_machine_details As Button
    Friend WithEvents BTN_ADD_NEW_MACHINES As Button
    Friend WithEvents btn_view_machines As Button
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents dgv_alert As DataGridView
End Class
