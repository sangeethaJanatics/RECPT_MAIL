<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMS))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_home = New System.Windows.Forms.TabPage()
        Me.LBL_FLOW_METRIC_HOME_PAGE = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.dgv_dashboard = New System.Windows.Forms.DataGridView()
        Me.Tab_settings = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Panel_view_machines = New System.Windows.Forms.Panel()
        Me.Panel1_edit_machine_details = New System.Windows.Forms.Panel()
        Me.chk_disable_machine_detail = New System.Windows.Forms.CheckBox()
        Me.btn_edit_machine_details = New System.Windows.Forms.Button()
        Me.txt_alert_idle_edit = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_alert_running_edit = New System.Windows.Forms.TextBox()
        Me.txt_recom_idle_edit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_recomm_running_edit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_machines_new = New System.Windows.Forms.DataGridView()
        Me.dept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.machine_make = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.machine_model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.machine_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flow_meter_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recommended_flow_running = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recommended_flow_idle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alert_flow_running = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alert_flow_idle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit_Data = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1_add_new_machines = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_Alert_flow_idle = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Alert_flow_running = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Alert_recom_flow_idle = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Alert_recom_flow_running = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_machine_model = New System.Windows.Forms.ComboBox()
        Me.txt_create_table_machine_name = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_customer = New System.Windows.Forms.TextBox()
        Me.cmb_create_table_machine_make = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_table_creation_dept_name = New System.Windows.Forms.ComboBox()
        Me.txt_flow_meter_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_search_customer = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_save_machine_details = New System.Windows.Forms.Button()
        Me.BTN_ADD_NEW_MACHINES = New System.Windows.Forms.Button()
        Me.btn_view_machines = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Panel_view_user_role = New System.Windows.Forms.Panel()
        Me.dgv_user_role = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_user_role_visibility = New System.Windows.Forms.Button()
        Me.dgv_user = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel_add_user = New System.Windows.Forms.Panel()
        Me.chk_user_end_date = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_user_role_user_tab = New System.Windows.Forms.ComboBox()
        Me.btn_cancel_user_addition = New System.Windows.Forms.Button()
        Me.btn_save_user_detail = New System.Windows.Forms.Button()
        Me.cmb_dept_user_tab = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txt_pwd = New System.Windows.Forms.TextBox()
        Me.Txt_user_name = New System.Windows.Forms.TextBox()
        Me.txt_user_id = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txt_phone_no = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txt_email_id = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.btn_add_user = New System.Windows.Forms.Button()
        Me.BTN_VIEW_ROLES = New System.Windows.Forms.Button()
        Me.btn_create_user_role = New System.Windows.Forms.Button()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel_company_logo_image = New System.Windows.Forms.Panel()
        Me.Txt_company_logo_image = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Panel_company_logo = New System.Windows.Forms.Panel()
        Me.txt_complany_logo_text = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rad_logo_image = New System.Windows.Forms.RadioButton()
        Me.rad_logo_text = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rad_dashboard_sorting_flow = New System.Windows.Forms.RadioButton()
        Me.rad_dashboard_sorting_machine = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rad_cfm = New System.Windows.Forms.RadioButton()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.rad_lpm = New System.Windows.Forms.RadioButton()
        Me.btn_upload_user_logo = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.panel_shift_edit = New System.Windows.Forms.Panel()
        Me.btn_save_shift_detail = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.date_time_shift3_end_time = New System.Windows.Forms.DateTimePicker()
        Me.txt_no_of_shifts = New System.Windows.Forms.TextBox()
        Me.date_time_shift3_st_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift1_start_time = New System.Windows.Forms.Label()
        Me.date_time_shift2_end_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift2_start_time = New System.Windows.Forms.Label()
        Me.date_time_shift2_st_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift1_end_time = New System.Windows.Forms.Label()
        Me.date_time_shift1_end_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift3_start_time = New System.Windows.Forms.Label()
        Me.date_time_shift1_st_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_shift2_end_time = New System.Windows.Forms.Label()
        Me.lbl_shift3_end_time = New System.Windows.Forms.Label()
        Me.dgv_shift = New System.Windows.Forms.DataGridView()
        Me.no_of_shift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shift1_start_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shift1_end_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shift2_Start_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shift2_end_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shift3_Start_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shift3_end_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Tab_reports = New System.Windows.Forms.TabPage()
        Me.Panel_view_chart = New System.Windows.Forms.Panel()
        Me.Chk_all_shift = New System.Windows.Forms.CheckBox()
        Me.Chk_shift3 = New System.Windows.Forms.CheckBox()
        Me.Chk_shift2 = New System.Windows.Forms.CheckBox()
        Me.chk_shift1 = New System.Windows.Forms.CheckBox()
        Me.Panel_report_machine_list = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btn_print_report = New System.Windows.Forms.Button()
        Me.btn_chart = New System.Windows.Forms.Button()
        Me.btn_view_report = New System.Windows.Forms.Button()
        Me.DateTime_report_to_time = New System.Windows.Forms.DateTimePicker()
        Me.DateTime_report_from_time = New System.Windows.Forms.DateTimePicker()
        Me.lbl_report_to_time = New System.Windows.Forms.Label()
        Me.DateTime_report_dt = New System.Windows.Forms.DateTimePicker()
        Me.lbl_report_from_time = New System.Windows.Forms.Label()
        Me.lbl_date_report = New System.Windows.Forms.Label()
        Me.WebBrowser_report = New System.Windows.Forms.WebBrowser()
        Me.rad_month = New System.Windows.Forms.RadioButton()
        Me.rad_shift = New System.Windows.Forms.RadioButton()
        Me.rad_day = New System.Windows.Forms.RadioButton()
        Me.rad_hour = New System.Windows.Forms.RadioButton()
        Me.rad_minute = New System.Windows.Forms.RadioButton()
        Me.Tab_sync = New System.Windows.Forms.TabPage()
        Me.WebBrowser_chart = New System.Windows.Forms.WebBrowser()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_create_mysql_tables = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_cust_name_on_head = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Link_logout = New System.Windows.Forms.LinkLabel()
        Me.lbl_user_name = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.Tab_home.SuspendLayout()
        CType(Me.dgv_dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_settings.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel_view_machines.SuspendLayout()
        Me.Panel1_edit_machine_details.SuspendLayout()
        CType(Me.dgv_machines_new, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1_add_new_machines.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.Panel_view_user_role.SuspendLayout()
        CType(Me.dgv_user_role, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_add_user.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Panel_company_logo_image.SuspendLayout()
        Me.Panel_company_logo.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.panel_shift_edit.SuspendLayout()
        CType(Me.dgv_shift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_reports.SuspendLayout()
        Me.Panel_report_machine_list.SuspendLayout()
        Me.Tab_sync.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.Tab_home)
        Me.TabControl1.Controls.Add(Me.Tab_settings)
        Me.TabControl1.Controls.Add(Me.Tab_reports)
        Me.TabControl1.Controls.Add(Me.Tab_sync)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(0, 66)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(3, 10)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(1200, 727)
        Me.TabControl1.TabIndex = 0
        '
        'Tab_home
        '
        Me.Tab_home.BackColor = System.Drawing.Color.White
        Me.Tab_home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_home.Controls.Add(Me.LBL_FLOW_METRIC_HOME_PAGE)
        Me.Tab_home.Controls.Add(Me.Label29)
        Me.Tab_home.Controls.Add(Me.Label28)
        Me.Tab_home.Controls.Add(Me.Label27)
        Me.Tab_home.Controls.Add(Me.Label26)
        Me.Tab_home.Controls.Add(Me.Label25)
        Me.Tab_home.Controls.Add(Me.Label24)
        Me.Tab_home.Controls.Add(Me.Label23)
        Me.Tab_home.Controls.Add(Me.Label18)
        Me.Tab_home.Controls.Add(Me.Label7)
        Me.Tab_home.Controls.Add(Me.WebBrowser1)
        Me.Tab_home.Controls.Add(Me.dgv_dashboard)
        Me.Tab_home.ForeColor = System.Drawing.Color.Black
        Me.Tab_home.ImageKey = "dash_board_images.jpg"
        Me.Tab_home.Location = New System.Drawing.Point(4, 71)
        Me.Tab_home.Name = "Tab_home"
        Me.Tab_home.Padding = New System.Windows.Forms.Padding(10)
        Me.Tab_home.Size = New System.Drawing.Size(1192, 652)
        Me.Tab_home.TabIndex = 0
        Me.Tab_home.ToolTipText = "DashBoard"
        '
        'LBL_FLOW_METRIC_HOME_PAGE
        '
        Me.LBL_FLOW_METRIC_HOME_PAGE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_FLOW_METRIC_HOME_PAGE.AutoSize = True
        Me.LBL_FLOW_METRIC_HOME_PAGE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_FLOW_METRIC_HOME_PAGE.ForeColor = System.Drawing.Color.DarkRed
        Me.LBL_FLOW_METRIC_HOME_PAGE.Location = New System.Drawing.Point(1027, 6)
        Me.LBL_FLOW_METRIC_HOME_PAGE.Name = "LBL_FLOW_METRIC_HOME_PAGE"
        Me.LBL_FLOW_METRIC_HOME_PAGE.Size = New System.Drawing.Size(73, 20)
        Me.LBL_FLOW_METRIC_HOME_PAGE.TabIndex = 5
        Me.LBL_FLOW_METRIC_HOME_PAGE.Text = "Label39"
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label29.Location = New System.Drawing.Point(1051, 546)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(138, 17)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "Flow value not found"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Location = New System.Drawing.Point(1021, 547)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(27, 14)
        Me.Label28.TabIndex = 4
        Me.Label28.Text = "   "
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label27.Location = New System.Drawing.Point(723, 546)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(293, 17)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Actual flow is greater than recommended flow"
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label26.BackColor = System.Drawing.Color.Red
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Location = New System.Drawing.Point(697, 547)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 14)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "   "
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label25.Location = New System.Drawing.Point(334, 546)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(362, 17)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Actual flow is between recommended flow and Alert level"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label24.BackColor = System.Drawing.Color.Orange
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Location = New System.Drawing.Point(308, 549)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(22, 11)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "   "
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label23.Location = New System.Drawing.Point(35, 546)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(272, 17)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Actual flow is less than recommended flow"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.Color.ForestGreen
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Location = New System.Drawing.Point(9, 549)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 11)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "   "
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label7.Location = New System.Drawing.Point(13, 506)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Flow values"
        Me.Label7.Visible = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(5, 29)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1183, 478)
        Me.WebBrowser1.TabIndex = 2
        '
        'dgv_dashboard
        '
        Me.dgv_dashboard.AllowUserToAddRows = False
        Me.dgv_dashboard.AllowUserToDeleteRows = False
        Me.dgv_dashboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_dashboard.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_dashboard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_dashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dashboard.Location = New System.Drawing.Point(7, 526)
        Me.dgv_dashboard.Name = "dgv_dashboard"
        Me.dgv_dashboard.ReadOnly = True
        Me.dgv_dashboard.Size = New System.Drawing.Size(459, 11)
        Me.dgv_dashboard.TabIndex = 1
        Me.dgv_dashboard.Visible = False
        '
        'Tab_settings
        '
        Me.Tab_settings.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Tab_settings.Controls.Add(Me.TabControl2)
        Me.Tab_settings.ImageIndex = 10
        Me.Tab_settings.Location = New System.Drawing.Point(4, 71)
        Me.Tab_settings.Name = "Tab_settings"
        Me.Tab_settings.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_settings.Size = New System.Drawing.Size(1192, 652)
        Me.Tab_settings.TabIndex = 1
        Me.Tab_settings.ToolTipText = "Settings"
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
        Me.TabControl2.Size = New System.Drawing.Size(1095, 646)
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
        Me.TabPage5.Size = New System.Drawing.Size(1087, 603)
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
        Me.Panel_view_machines.Location = New System.Drawing.Point(6, 40)
        Me.Panel_view_machines.Name = "Panel_view_machines"
        Me.Panel_view_machines.Size = New System.Drawing.Size(1081, 482)
        Me.Panel_view_machines.TabIndex = 20
        '
        'Panel1_edit_machine_details
        '
        Me.Panel1_edit_machine_details.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1_edit_machine_details.Controls.Add(Me.chk_disable_machine_detail)
        Me.Panel1_edit_machine_details.Controls.Add(Me.btn_edit_machine_details)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_alert_idle_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label21)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_alert_running_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_recom_idle_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label9)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label20)
        Me.Panel1_edit_machine_details.Controls.Add(Me.txt_recomm_running_edit)
        Me.Panel1_edit_machine_details.Controls.Add(Me.Label3)
        Me.Panel1_edit_machine_details.Location = New System.Drawing.Point(15, 384)
        Me.Panel1_edit_machine_details.Name = "Panel1_edit_machine_details"
        Me.Panel1_edit_machine_details.Size = New System.Drawing.Size(1003, 65)
        Me.Panel1_edit_machine_details.TabIndex = 22
        '
        'chk_disable_machine_detail
        '
        Me.chk_disable_machine_detail.AutoSize = True
        Me.chk_disable_machine_detail.Location = New System.Drawing.Point(624, 10)
        Me.chk_disable_machine_detail.Name = "chk_disable_machine_detail"
        Me.chk_disable_machine_detail.Size = New System.Drawing.Size(197, 21)
        Me.chk_disable_machine_detail.TabIndex = 22
        Me.chk_disable_machine_detail.Text = "Disable this Machine Detail"
        Me.chk_disable_machine_detail.UseVisualStyleBackColor = True
        '
        'btn_edit_machine_details
        '
        Me.btn_edit_machine_details.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_edit_machine_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit_machine_details.ForeColor = System.Drawing.Color.White
        Me.btn_edit_machine_details.Location = New System.Drawing.Point(828, 5)
        Me.btn_edit_machine_details.Name = "btn_edit_machine_details"
        Me.btn_edit_machine_details.Size = New System.Drawing.Size(65, 31)
        Me.btn_edit_machine_details.TabIndex = 21
        Me.btn_edit_machine_details.Text = "Save"
        Me.btn_edit_machine_details.UseVisualStyleBackColor = False
        '
        'txt_alert_idle_edit
        '
        Me.txt_alert_idle_edit.Location = New System.Drawing.Point(493, 33)
        Me.txt_alert_idle_edit.Name = "txt_alert_idle_edit"
        Me.txt_alert_idle_edit.Size = New System.Drawing.Size(125, 23)
        Me.txt_alert_idle_edit.TabIndex = 20
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(364, 36)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 17)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Alert Flow Idle:"
        '
        'txt_alert_running_edit
        '
        Me.txt_alert_running_edit.Location = New System.Drawing.Point(493, 8)
        Me.txt_alert_running_edit.Name = "txt_alert_running_edit"
        Me.txt_alert_running_edit.Size = New System.Drawing.Size(125, 23)
        Me.txt_alert_running_edit.TabIndex = 20
        '
        'txt_recom_idle_edit
        '
        Me.txt_recom_idle_edit.Location = New System.Drawing.Point(225, 33)
        Me.txt_recom_idle_edit.Name = "txt_recom_idle_edit"
        Me.txt_recom_idle_edit.Size = New System.Drawing.Size(125, 23)
        Me.txt_recom_idle_edit.TabIndex = 20
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
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(23, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(165, 17)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Recommended Flow Idle:"
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
        Me.dgv_machines_new.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_machines_new.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_machines_new.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_machines_new.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dept, Me.machine_make, Me.machine_model, Me.machine_name, Me.flow_meter_id, Me.recommended_flow_running, Me.recommended_flow_idle, Me.alert_flow_running, Me.alert_flow_idle, Me.Edit_Data})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_machines_new.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_machines_new.EnableHeadersVisualStyles = False
        Me.dgv_machines_new.Location = New System.Drawing.Point(5, 13)
        Me.dgv_machines_new.Name = "dgv_machines_new"
        Me.dgv_machines_new.ReadOnly = True
        Me.dgv_machines_new.Size = New System.Drawing.Size(1068, 354)
        Me.dgv_machines_new.TabIndex = 19
        '
        'dept
        '
        Me.dept.HeaderText = "Department"
        Me.dept.Name = "dept"
        Me.dept.ReadOnly = True
        '
        'machine_make
        '
        Me.machine_make.HeaderText = "Machine Make"
        Me.machine_make.Name = "machine_make"
        Me.machine_make.ReadOnly = True
        '
        'machine_model
        '
        Me.machine_model.HeaderText = "Machine Model"
        Me.machine_model.Name = "machine_model"
        Me.machine_model.ReadOnly = True
        '
        'machine_name
        '
        Me.machine_name.HeaderText = "Machine No"
        Me.machine_name.Name = "machine_name"
        Me.machine_name.ReadOnly = True
        '
        'flow_meter_id
        '
        Me.flow_meter_id.HeaderText = "Flow Meter Id"
        Me.flow_meter_id.Name = "flow_meter_id"
        Me.flow_meter_id.ReadOnly = True
        '
        'recommended_flow_running
        '
        Me.recommended_flow_running.HeaderText = "Recomd Flow Running"
        Me.recommended_flow_running.Name = "recommended_flow_running"
        Me.recommended_flow_running.ReadOnly = True
        '
        'recommended_flow_idle
        '
        Me.recommended_flow_idle.HeaderText = "Recomd Flow Idle"
        Me.recommended_flow_idle.Name = "recommended_flow_idle"
        Me.recommended_flow_idle.ReadOnly = True
        '
        'alert_flow_running
        '
        Me.alert_flow_running.HeaderText = "Alert Flow Running"
        Me.alert_flow_running.Name = "alert_flow_running"
        Me.alert_flow_running.ReadOnly = True
        '
        'alert_flow_idle
        '
        Me.alert_flow_idle.HeaderText = "Alert Flow Idle"
        Me.alert_flow_idle.Name = "alert_flow_idle"
        Me.alert_flow_idle.ReadOnly = True
        '
        'Edit_Data
        '
        Me.Edit_Data.HeaderText = "Edit Data"
        Me.Edit_Data.Name = "Edit_Data"
        Me.Edit_Data.ReadOnly = True
        Me.Edit_Data.Text = "Edit"
        '
        'Panel1_add_new_machines
        '
        Me.Panel1_add_new_machines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1_add_new_machines.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1_add_new_machines.Controls.Add(Me.Label16)
        Me.Panel1_add_new_machines.Controls.Add(Me.Label15)
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
        Me.Panel1_add_new_machines.Size = New System.Drawing.Size(1071, 515)
        Me.Panel1_add_new_machines.TabIndex = 4
        Me.Panel1_add_new_machines.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Crimson
        Me.Label16.Location = New System.Drawing.Point(108, 166)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 25)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Crimson
        Me.Label15.Location = New System.Drawing.Point(118, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 25)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "*"
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
        Me.Label4.Location = New System.Drawing.Point(91, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Department Name :"
        '
        'cmb_machine_model
        '
        Me.cmb_machine_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_machine_model.FormattingEnabled = True
        Me.cmb_machine_model.Location = New System.Drawing.Point(242, 103)
        Me.cmb_machine_model.Name = "cmb_machine_model"
        Me.cmb_machine_model.Size = New System.Drawing.Size(198, 24)
        Me.cmb_machine_model.TabIndex = 3
        '
        'txt_create_table_machine_name
        '
        Me.txt_create_table_machine_name.Location = New System.Drawing.Point(243, 131)
        Me.txt_create_table_machine_name.Name = "txt_create_table_machine_name"
        Me.txt_create_table_machine_name.Size = New System.Drawing.Size(199, 23)
        Me.txt_create_table_machine_name.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label6.Location = New System.Drawing.Point(135, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Machine No:"
        '
        'txt_customer
        '
        Me.txt_customer.Location = New System.Drawing.Point(243, 17)
        Me.txt_customer.Name = "txt_customer"
        Me.txt_customer.Size = New System.Drawing.Size(447, 23)
        Me.txt_customer.TabIndex = 1
        '
        'cmb_create_table_machine_make
        '
        Me.cmb_create_table_machine_make.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_create_table_machine_make.FormattingEnabled = True
        Me.cmb_create_table_machine_make.Location = New System.Drawing.Point(242, 73)
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
        Me.cmb_table_creation_dept_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_table_creation_dept_name.FormattingEnabled = True
        Me.cmb_table_creation_dept_name.Location = New System.Drawing.Point(243, 46)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Location = New System.Drawing.Point(122, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Machine Make:"
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
        Me.Label5.Location = New System.Drawing.Point(117, 108)
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
        Me.TabPage6.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage6.Controls.Add(Me.Panel_view_user_role)
        Me.TabPage6.Controls.Add(Me.dgv_user)
        Me.TabPage6.Controls.Add(Me.Panel_add_user)
        Me.TabPage6.Controls.Add(Me.btn_add_user)
        Me.TabPage6.Controls.Add(Me.BTN_VIEW_ROLES)
        Me.TabPage6.Controls.Add(Me.btn_create_user_role)
        Me.TabPage6.Location = New System.Drawing.Point(4, 39)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1087, 603)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "USER"
        '
        'Panel_view_user_role
        '
        Me.Panel_view_user_role.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel_view_user_role.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_view_user_role.Controls.Add(Me.dgv_user_role)
        Me.Panel_view_user_role.Controls.Add(Me.btn_user_role_visibility)
        Me.Panel_view_user_role.Location = New System.Drawing.Point(221, 374)
        Me.Panel_view_user_role.Name = "Panel_view_user_role"
        Me.Panel_view_user_role.Size = New System.Drawing.Size(606, 151)
        Me.Panel_view_user_role.TabIndex = 22
        Me.Panel_view_user_role.Visible = False
        '
        'dgv_user_role
        '
        Me.dgv_user_role.AllowUserToAddRows = False
        Me.dgv_user_role.AllowUserToDeleteRows = False
        Me.dgv_user_role.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_user_role.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgv_user_role.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_user_role.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_user_role.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_user_role.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewButtonColumn3})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_user_role.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_user_role.EnableHeadersVisualStyles = False
        Me.dgv_user_role.Location = New System.Drawing.Point(19, 10)
        Me.dgv_user_role.Name = "dgv_user_role"
        Me.dgv_user_role.ReadOnly = True
        Me.dgv_user_role.RowHeadersVisible = False
        Me.dgv_user_role.Size = New System.Drawing.Size(537, 113)
        Me.dgv_user_role.TabIndex = 21
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "User Role"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "View"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Edit"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "Delete"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewButtonColumn3
        '
        Me.DataGridViewButtonColumn3.HeaderText = "Shift Setting"
        Me.DataGridViewButtonColumn3.Name = "DataGridViewButtonColumn3"
        Me.DataGridViewButtonColumn3.ReadOnly = True
        Me.DataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'btn_user_role_visibility
        '
        Me.btn_user_role_visibility.BackColor = System.Drawing.Color.Red
        Me.btn_user_role_visibility.ForeColor = System.Drawing.Color.White
        Me.btn_user_role_visibility.Location = New System.Drawing.Point(560, -2)
        Me.btn_user_role_visibility.Name = "btn_user_role_visibility"
        Me.btn_user_role_visibility.Size = New System.Drawing.Size(43, 28)
        Me.btn_user_role_visibility.TabIndex = 4
        Me.btn_user_role_visibility.Text = "X"
        Me.btn_user_role_visibility.UseVisualStyleBackColor = False
        '
        'dgv_user
        '
        Me.dgv_user.AllowUserToAddRows = False
        Me.dgv_user.AllowUserToDeleteRows = False
        Me.dgv_user.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_user.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_user.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_user.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_user.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.EMail, Me.Phone_No, Me.DataGridViewButtonColumn2})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_user.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_user.EnableHeadersVisualStyles = False
        Me.dgv_user.Location = New System.Drawing.Point(6, 65)
        Me.dgv_user.Name = "dgv_user"
        Me.dgv_user.ReadOnly = True
        Me.dgv_user.RowHeadersVisible = False
        Me.dgv_user.Size = New System.Drawing.Size(895, 181)
        Me.dgv_user.TabIndex = 21
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "User Name"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 120
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "User Role"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 120
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "User ID"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'EMail
        '
        Me.EMail.HeaderText = "E-Mail"
        Me.EMail.Name = "EMail"
        Me.EMail.ReadOnly = True
        Me.EMail.Width = 200
        '
        'Phone_No
        '
        Me.Phone_No.HeaderText = "Phone No"
        Me.Phone_No.Name = "Phone_No"
        Me.Phone_No.ReadOnly = True
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.HeaderText = "Edit Data"
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        '
        'Panel_add_user
        '
        Me.Panel_add_user.Controls.Add(Me.chk_user_end_date)
        Me.Panel_add_user.Controls.Add(Me.Label17)
        Me.Panel_add_user.Controls.Add(Me.cmb_user_role_user_tab)
        Me.Panel_add_user.Controls.Add(Me.btn_cancel_user_addition)
        Me.Panel_add_user.Controls.Add(Me.btn_save_user_detail)
        Me.Panel_add_user.Controls.Add(Me.cmb_dept_user_tab)
        Me.Panel_add_user.Controls.Add(Me.Label33)
        Me.Panel_add_user.Controls.Add(Me.txt_pwd)
        Me.Panel_add_user.Controls.Add(Me.Txt_user_name)
        Me.Panel_add_user.Controls.Add(Me.txt_user_id)
        Me.Panel_add_user.Controls.Add(Me.Label34)
        Me.Panel_add_user.Controls.Add(Me.txt_phone_no)
        Me.Panel_add_user.Controls.Add(Me.Label32)
        Me.Panel_add_user.Controls.Add(Me.Label36)
        Me.Panel_add_user.Controls.Add(Me.Label35)
        Me.Panel_add_user.Controls.Add(Me.txt_email_id)
        Me.Panel_add_user.Controls.Add(Me.Label37)
        Me.Panel_add_user.Location = New System.Drawing.Point(26, 265)
        Me.Panel_add_user.Name = "Panel_add_user"
        Me.Panel_add_user.Size = New System.Drawing.Size(999, 103)
        Me.Panel_add_user.TabIndex = 8
        '
        'chk_user_end_date
        '
        Me.chk_user_end_date.AutoSize = True
        Me.chk_user_end_date.ForeColor = System.Drawing.Color.Blue
        Me.chk_user_end_date.Location = New System.Drawing.Point(431, 73)
        Me.chk_user_end_date.Name = "chk_user_end_date"
        Me.chk_user_end_date.Size = New System.Drawing.Size(86, 21)
        Me.chk_user_end_date.TabIndex = 8
        Me.chk_user_end_date.Text = "End Date"
        Me.chk_user_end_date.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(17, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 17)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "User Name :"
        '
        'cmb_user_role_user_tab
        '
        Me.cmb_user_role_user_tab.FormattingEnabled = True
        Me.cmb_user_role_user_tab.Location = New System.Drawing.Point(108, 70)
        Me.cmb_user_role_user_tab.Name = "cmb_user_role_user_tab"
        Me.cmb_user_role_user_tab.Size = New System.Drawing.Size(219, 24)
        Me.cmb_user_role_user_tab.TabIndex = 7
        '
        'btn_cancel_user_addition
        '
        Me.btn_cancel_user_addition.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_cancel_user_addition.ForeColor = System.Drawing.Color.White
        Me.btn_cancel_user_addition.Location = New System.Drawing.Point(830, 70)
        Me.btn_cancel_user_addition.Name = "btn_cancel_user_addition"
        Me.btn_cancel_user_addition.Size = New System.Drawing.Size(59, 28)
        Me.btn_cancel_user_addition.TabIndex = 4
        Me.btn_cancel_user_addition.Text = "Cancel"
        Me.btn_cancel_user_addition.UseVisualStyleBackColor = False
        '
        'btn_save_user_detail
        '
        Me.btn_save_user_detail.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_save_user_detail.ForeColor = System.Drawing.Color.White
        Me.btn_save_user_detail.Location = New System.Drawing.Point(767, 70)
        Me.btn_save_user_detail.Name = "btn_save_user_detail"
        Me.btn_save_user_detail.Size = New System.Drawing.Size(57, 28)
        Me.btn_save_user_detail.TabIndex = 4
        Me.btn_save_user_detail.Text = "Save"
        Me.btn_save_user_detail.UseVisualStyleBackColor = False
        '
        'cmb_dept_user_tab
        '
        Me.cmb_dept_user_tab.FormattingEnabled = True
        Me.cmb_dept_user_tab.Location = New System.Drawing.Point(108, 37)
        Me.cmb_dept_user_tab.Name = "cmb_dept_user_tab"
        Me.cmb_dept_user_tab.Size = New System.Drawing.Size(219, 24)
        Me.cmb_dept_user_tab.TabIndex = 7
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(355, 11)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 17)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "E-Mail ID :"
        '
        'txt_pwd
        '
        Me.txt_pwd.Location = New System.Drawing.Point(767, 38)
        Me.txt_pwd.Name = "txt_pwd"
        Me.txt_pwd.Size = New System.Drawing.Size(219, 23)
        Me.txt_pwd.TabIndex = 6
        '
        'Txt_user_name
        '
        Me.Txt_user_name.Location = New System.Drawing.Point(108, 8)
        Me.Txt_user_name.Name = "Txt_user_name"
        Me.Txt_user_name.Size = New System.Drawing.Size(219, 23)
        Me.Txt_user_name.TabIndex = 6
        '
        'txt_user_id
        '
        Me.txt_user_id.Location = New System.Drawing.Point(767, 8)
        Me.txt_user_id.Name = "txt_user_id"
        Me.txt_user_id.Size = New System.Drawing.Size(219, 23)
        Me.txt_user_id.TabIndex = 6
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(348, 41)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 17)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "Phone No :"
        '
        'txt_phone_no
        '
        Me.txt_phone_no.Location = New System.Drawing.Point(431, 38)
        Me.txt_phone_no.Name = "txt_phone_no"
        Me.txt_phone_no.Size = New System.Drawing.Size(219, 23)
        Me.txt_phone_no.TabIndex = 6
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Blue
        Me.Label32.Location = New System.Drawing.Point(14, 41)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(90, 17)
        Me.Label32.TabIndex = 5
        Me.Label32.Text = "Department :"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(685, 41)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(77, 17)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "Password :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Blue
        Me.Label35.Location = New System.Drawing.Point(699, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(63, 17)
        Me.Label35.TabIndex = 5
        Me.Label35.Text = "User ID :"
        '
        'txt_email_id
        '
        Me.txt_email_id.Location = New System.Drawing.Point(431, 8)
        Me.txt_email_id.Name = "txt_email_id"
        Me.txt_email_id.Size = New System.Drawing.Size(219, 23)
        Me.txt_email_id.TabIndex = 6
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(29, 74)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(75, 17)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "User Role:"
        '
        'btn_add_user
        '
        Me.btn_add_user.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_add_user.ForeColor = System.Drawing.Color.White
        Me.btn_add_user.Location = New System.Drawing.Point(866, 17)
        Me.btn_add_user.Name = "btn_add_user"
        Me.btn_add_user.Size = New System.Drawing.Size(92, 28)
        Me.btn_add_user.TabIndex = 4
        Me.btn_add_user.Text = "Add User"
        Me.btn_add_user.UseVisualStyleBackColor = False
        '
        'BTN_VIEW_ROLES
        '
        Me.BTN_VIEW_ROLES.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BTN_VIEW_ROLES.ForeColor = System.Drawing.Color.White
        Me.BTN_VIEW_ROLES.Location = New System.Drawing.Point(964, 17)
        Me.BTN_VIEW_ROLES.Name = "BTN_VIEW_ROLES"
        Me.BTN_VIEW_ROLES.Size = New System.Drawing.Size(126, 28)
        Me.BTN_VIEW_ROLES.TabIndex = 4
        Me.BTN_VIEW_ROLES.Text = "View User Role"
        Me.BTN_VIEW_ROLES.UseVisualStyleBackColor = False
        '
        'btn_create_user_role
        '
        Me.btn_create_user_role.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_create_user_role.ForeColor = System.Drawing.Color.White
        Me.btn_create_user_role.Location = New System.Drawing.Point(957, 17)
        Me.btn_create_user_role.Name = "btn_create_user_role"
        Me.btn_create_user_role.Size = New System.Drawing.Size(126, 28)
        Me.btn_create_user_role.TabIndex = 4
        Me.btn_create_user_role.Text = "Create User Role"
        Me.btn_create_user_role.UseVisualStyleBackColor = False
        Me.btn_create_user_role.Visible = False
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Panel_company_logo_image)
        Me.TabPage7.Controls.Add(Me.Panel_company_logo)
        Me.TabPage7.Controls.Add(Me.Panel4)
        Me.TabPage7.Controls.Add(Me.Panel3)
        Me.TabPage7.Controls.Add(Me.Panel2)
        Me.TabPage7.Controls.Add(Me.btn_upload_user_logo)
        Me.TabPage7.Controls.Add(Me.Label31)
        Me.TabPage7.Controls.Add(Me.Label30)
        Me.TabPage7.Controls.Add(Me.Label19)
        Me.TabPage7.Location = New System.Drawing.Point(4, 39)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1087, 603)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "GENERAL"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Panel_company_logo_image
        '
        Me.Panel_company_logo_image.Controls.Add(Me.Txt_company_logo_image)
        Me.Panel_company_logo_image.Controls.Add(Me.Label38)
        Me.Panel_company_logo_image.Location = New System.Drawing.Point(121, 167)
        Me.Panel_company_logo_image.Name = "Panel_company_logo_image"
        Me.Panel_company_logo_image.Size = New System.Drawing.Size(421, 46)
        Me.Panel_company_logo_image.TabIndex = 10
        '
        'Txt_company_logo_image
        '
        Me.Txt_company_logo_image.Location = New System.Drawing.Point(152, 13)
        Me.Txt_company_logo_image.Name = "Txt_company_logo_image"
        Me.Txt_company_logo_image.Size = New System.Drawing.Size(264, 23)
        Me.Txt_company_logo_image.TabIndex = 12
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label38.Location = New System.Drawing.Point(5, 16)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 17)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "Company Logo"
        '
        'Panel_company_logo
        '
        Me.Panel_company_logo.Controls.Add(Me.txt_complany_logo_text)
        Me.Panel_company_logo.Controls.Add(Me.Label22)
        Me.Panel_company_logo.Location = New System.Drawing.Point(121, 115)
        Me.Panel_company_logo.Name = "Panel_company_logo"
        Me.Panel_company_logo.Size = New System.Drawing.Size(421, 46)
        Me.Panel_company_logo.TabIndex = 10
        '
        'txt_complany_logo_text
        '
        Me.txt_complany_logo_text.Location = New System.Drawing.Point(152, 13)
        Me.txt_complany_logo_text.Name = "txt_complany_logo_text"
        Me.txt_complany_logo_text.Size = New System.Drawing.Size(264, 23)
        Me.txt_complany_logo_text.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label22.Location = New System.Drawing.Point(5, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 17)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Company Logo Text"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rad_logo_image)
        Me.Panel4.Controls.Add(Me.rad_logo_text)
        Me.Panel4.Location = New System.Drawing.Point(279, 87)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(228, 25)
        Me.Panel4.TabIndex = 13
        '
        'rad_logo_image
        '
        Me.rad_logo_image.AutoSize = True
        Me.rad_logo_image.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_logo_image.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_logo_image.Location = New System.Drawing.Point(103, 2)
        Me.rad_logo_image.Name = "rad_logo_image"
        Me.rad_logo_image.Size = New System.Drawing.Size(69, 21)
        Me.rad_logo_image.TabIndex = 9
        Me.rad_logo_image.Text = "image"
        Me.rad_logo_image.UseVisualStyleBackColor = True
        '
        'rad_logo_text
        '
        Me.rad_logo_text.AutoSize = True
        Me.rad_logo_text.Checked = True
        Me.rad_logo_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_logo_text.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_logo_text.Location = New System.Drawing.Point(9, 1)
        Me.rad_logo_text.Name = "rad_logo_text"
        Me.rad_logo_text.Size = New System.Drawing.Size(57, 21)
        Me.rad_logo_text.TabIndex = 8
        Me.rad_logo_text.TabStop = True
        Me.rad_logo_text.Text = "Text"
        Me.rad_logo_text.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rad_dashboard_sorting_flow)
        Me.Panel3.Controls.Add(Me.rad_dashboard_sorting_machine)
        Me.Panel3.Location = New System.Drawing.Point(277, 47)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(230, 28)
        Me.Panel3.TabIndex = 13
        '
        'rad_dashboard_sorting_flow
        '
        Me.rad_dashboard_sorting_flow.AutoSize = True
        Me.rad_dashboard_sorting_flow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dashboard_sorting_flow.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_dashboard_sorting_flow.Location = New System.Drawing.Point(103, 3)
        Me.rad_dashboard_sorting_flow.Name = "rad_dashboard_sorting_flow"
        Me.rad_dashboard_sorting_flow.Size = New System.Drawing.Size(102, 21)
        Me.rad_dashboard_sorting_flow.TabIndex = 9
        Me.rad_dashboard_sorting_flow.Text = "Flow value"
        Me.rad_dashboard_sorting_flow.UseVisualStyleBackColor = True
        '
        'rad_dashboard_sorting_machine
        '
        Me.rad_dashboard_sorting_machine.AutoSize = True
        Me.rad_dashboard_sorting_machine.Checked = True
        Me.rad_dashboard_sorting_machine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_dashboard_sorting_machine.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_dashboard_sorting_machine.Location = New System.Drawing.Point(9, 3)
        Me.rad_dashboard_sorting_machine.Name = "rad_dashboard_sorting_machine"
        Me.rad_dashboard_sorting_machine.Size = New System.Drawing.Size(86, 21)
        Me.rad_dashboard_sorting_machine.TabIndex = 8
        Me.rad_dashboard_sorting_machine.TabStop = True
        Me.rad_dashboard_sorting_machine.Text = "Machine"
        Me.rad_dashboard_sorting_machine.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rad_cfm)
        Me.Panel2.Controls.Add(Me.btn_refresh)
        Me.Panel2.Controls.Add(Me.rad_lpm)
        Me.Panel2.Location = New System.Drawing.Point(279, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(228, 26)
        Me.Panel2.TabIndex = 13
        '
        'rad_cfm
        '
        Me.rad_cfm.AutoSize = True
        Me.rad_cfm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_cfm.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_cfm.Location = New System.Drawing.Point(103, 3)
        Me.rad_cfm.Name = "rad_cfm"
        Me.rad_cfm.Size = New System.Drawing.Size(57, 21)
        Me.rad_cfm.TabIndex = 9
        Me.rad_cfm.Text = "CFM"
        Me.rad_cfm.UseVisualStyleBackColor = True
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Location = New System.Drawing.Point(-113, 0)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(38, 23)
        Me.btn_refresh.TabIndex = 7
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        Me.btn_refresh.Visible = False
        '
        'rad_lpm
        '
        Me.rad_lpm.AutoSize = True
        Me.rad_lpm.Checked = True
        Me.rad_lpm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_lpm.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_lpm.Location = New System.Drawing.Point(9, 1)
        Me.rad_lpm.Name = "rad_lpm"
        Me.rad_lpm.Size = New System.Drawing.Size(57, 21)
        Me.rad_lpm.TabIndex = 8
        Me.rad_lpm.TabStop = True
        Me.rad_lpm.Text = "LPM"
        Me.rad_lpm.UseVisualStyleBackColor = True
        '
        'btn_upload_user_logo
        '
        Me.btn_upload_user_logo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_upload_user_logo.ForeColor = System.Drawing.Color.White
        Me.btn_upload_user_logo.Location = New System.Drawing.Point(465, 230)
        Me.btn_upload_user_logo.Name = "btn_upload_user_logo"
        Me.btn_upload_user_logo.Size = New System.Drawing.Size(72, 31)
        Me.btn_upload_user_logo.TabIndex = 11
        Me.btn_upload_user_logo.Text = "Save"
        Me.btn_upload_user_logo.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label31.Location = New System.Drawing.Point(127, 91)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(139, 17)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Company Logo Type"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label30.Location = New System.Drawing.Point(126, 53)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(145, 17)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Dashboard  view  By :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label19.Location = New System.Drawing.Point(198, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 17)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Flow Unit :"
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage8.Controls.Add(Me.panel_shift_edit)
        Me.TabPage8.Controls.Add(Me.dgv_shift)
        Me.TabPage8.Location = New System.Drawing.Point(4, 39)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1087, 603)
        Me.TabPage8.TabIndex = 3
        Me.TabPage8.Text = "SHIFT"
        '
        'panel_shift_edit
        '
        Me.panel_shift_edit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_shift_edit.Controls.Add(Me.btn_save_shift_detail)
        Me.panel_shift_edit.Controls.Add(Me.Label14)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift3_end_time)
        Me.panel_shift_edit.Controls.Add(Me.txt_no_of_shifts)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift3_st_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift1_start_time)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift2_end_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift2_start_time)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift2_st_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift1_end_time)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift1_end_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift3_start_time)
        Me.panel_shift_edit.Controls.Add(Me.date_time_shift1_st_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift2_end_time)
        Me.panel_shift_edit.Controls.Add(Me.lbl_shift3_end_time)
        Me.panel_shift_edit.Location = New System.Drawing.Point(14, 242)
        Me.panel_shift_edit.Name = "panel_shift_edit"
        Me.panel_shift_edit.Size = New System.Drawing.Size(1006, 471)
        Me.panel_shift_edit.TabIndex = 21
        '
        'btn_save_shift_detail
        '
        Me.btn_save_shift_detail.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_save_shift_detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save_shift_detail.ForeColor = System.Drawing.Color.MistyRose
        Me.btn_save_shift_detail.Location = New System.Drawing.Point(778, 68)
        Me.btn_save_shift_detail.Name = "btn_save_shift_detail"
        Me.btn_save_shift_detail.Size = New System.Drawing.Size(75, 29)
        Me.btn_save_shift_detail.TabIndex = 0
        Me.btn_save_shift_detail.Text = "update"
        Me.btn_save_shift_detail.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label14.Location = New System.Drawing.Point(51, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "No of shifts :"
        '
        'date_time_shift3_end_time
        '
        Me.date_time_shift3_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift3_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift3_end_time.Location = New System.Drawing.Point(660, 74)
        Me.date_time_shift3_end_time.Name = "date_time_shift3_end_time"
        Me.date_time_shift3_end_time.ShowUpDown = True
        Me.date_time_shift3_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift3_end_time.TabIndex = 3
        '
        'txt_no_of_shifts
        '
        Me.txt_no_of_shifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_of_shifts.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.txt_no_of_shifts.Location = New System.Drawing.Point(155, 6)
        Me.txt_no_of_shifts.Name = "txt_no_of_shifts"
        Me.txt_no_of_shifts.Size = New System.Drawing.Size(100, 23)
        Me.txt_no_of_shifts.TabIndex = 2
        '
        'date_time_shift3_st_time
        '
        Me.date_time_shift3_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift3_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift3_st_time.Location = New System.Drawing.Point(660, 45)
        Me.date_time_shift3_st_time.Name = "date_time_shift3_st_time"
        Me.date_time_shift3_st_time.ShowUpDown = True
        Me.date_time_shift3_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift3_st_time.TabIndex = 3
        '
        'lbl_shift1_start_time
        '
        Me.lbl_shift1_start_time.AutoSize = True
        Me.lbl_shift1_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift1_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift1_start_time.Location = New System.Drawing.Point(12, 35)
        Me.lbl_shift1_start_time.Name = "lbl_shift1_start_time"
        Me.lbl_shift1_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift1_start_time.TabIndex = 1
        Me.lbl_shift1_start_time.Text = "Shift1 Start Time :"
        '
        'date_time_shift2_end_time
        '
        Me.date_time_shift2_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift2_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift2_end_time.Location = New System.Drawing.Point(410, 69)
        Me.date_time_shift2_end_time.Name = "date_time_shift2_end_time"
        Me.date_time_shift2_end_time.ShowUpDown = True
        Me.date_time_shift2_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift2_end_time.TabIndex = 3
        '
        'lbl_shift2_start_time
        '
        Me.lbl_shift2_start_time.AutoSize = True
        Me.lbl_shift2_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift2_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift2_start_time.Location = New System.Drawing.Point(260, 40)
        Me.lbl_shift2_start_time.Name = "lbl_shift2_start_time"
        Me.lbl_shift2_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift2_start_time.TabIndex = 1
        Me.lbl_shift2_start_time.Text = "Shift2 Start Time :"
        '
        'date_time_shift2_st_time
        '
        Me.date_time_shift2_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift2_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift2_st_time.Location = New System.Drawing.Point(410, 40)
        Me.date_time_shift2_st_time.Name = "date_time_shift2_st_time"
        Me.date_time_shift2_st_time.ShowUpDown = True
        Me.date_time_shift2_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift2_st_time.TabIndex = 3
        '
        'lbl_shift1_end_time
        '
        Me.lbl_shift1_end_time.AutoSize = True
        Me.lbl_shift1_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift1_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift1_end_time.Location = New System.Drawing.Point(14, 64)
        Me.lbl_shift1_end_time.Name = "lbl_shift1_end_time"
        Me.lbl_shift1_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift1_end_time.TabIndex = 1
        Me.lbl_shift1_end_time.Text = "Shift1  End Time :"
        '
        'date_time_shift1_end_time
        '
        Me.date_time_shift1_end_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift1_end_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift1_end_time.Location = New System.Drawing.Point(156, 64)
        Me.date_time_shift1_end_time.Name = "date_time_shift1_end_time"
        Me.date_time_shift1_end_time.ShowUpDown = True
        Me.date_time_shift1_end_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift1_end_time.TabIndex = 3
        '
        'lbl_shift3_start_time
        '
        Me.lbl_shift3_start_time.AutoSize = True
        Me.lbl_shift3_start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift3_start_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift3_start_time.Location = New System.Drawing.Point(514, 45)
        Me.lbl_shift3_start_time.Name = "lbl_shift3_start_time"
        Me.lbl_shift3_start_time.Size = New System.Drawing.Size(140, 17)
        Me.lbl_shift3_start_time.TabIndex = 1
        Me.lbl_shift3_start_time.Text = "Shift3 Start Time :"
        '
        'date_time_shift1_st_time
        '
        Me.date_time_shift1_st_time.CustomFormat = "hh:mm:ss tt"
        Me.date_time_shift1_st_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_time_shift1_st_time.Location = New System.Drawing.Point(156, 35)
        Me.date_time_shift1_st_time.Name = "date_time_shift1_st_time"
        Me.date_time_shift1_st_time.ShowUpDown = True
        Me.date_time_shift1_st_time.Size = New System.Drawing.Size(100, 23)
        Me.date_time_shift1_st_time.TabIndex = 3
        '
        'lbl_shift2_end_time
        '
        Me.lbl_shift2_end_time.AutoSize = True
        Me.lbl_shift2_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift2_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift2_end_time.Location = New System.Drawing.Point(262, 69)
        Me.lbl_shift2_end_time.Name = "lbl_shift2_end_time"
        Me.lbl_shift2_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift2_end_time.TabIndex = 1
        Me.lbl_shift2_end_time.Text = "Shift2  End Time :"
        '
        'lbl_shift3_end_time
        '
        Me.lbl_shift3_end_time.AutoSize = True
        Me.lbl_shift3_end_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shift3_end_time.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_shift3_end_time.Location = New System.Drawing.Point(516, 74)
        Me.lbl_shift3_end_time.Name = "lbl_shift3_end_time"
        Me.lbl_shift3_end_time.Size = New System.Drawing.Size(138, 17)
        Me.lbl_shift3_end_time.TabIndex = 1
        Me.lbl_shift3_end_time.Text = "Shift3  End Time :"
        '
        'dgv_shift
        '
        Me.dgv_shift.AllowUserToAddRows = False
        Me.dgv_shift.AllowUserToDeleteRows = False
        Me.dgv_shift.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_shift.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_shift.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_shift.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_shift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_shift.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no_of_shift, Me.shift1_start_time, Me.Shift1_end_Time, Me.Shift2_Start_Time, Me.Shift2_end_Time, Me.Shift3_Start_Time, Me.Shift3_end_Time, Me.DataGridViewButtonColumn1})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_shift.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_shift.EnableHeadersVisualStyles = False
        Me.dgv_shift.Location = New System.Drawing.Point(14, 15)
        Me.dgv_shift.Name = "dgv_shift"
        Me.dgv_shift.ReadOnly = True
        Me.dgv_shift.Size = New System.Drawing.Size(1053, 181)
        Me.dgv_shift.TabIndex = 20
        '
        'no_of_shift
        '
        Me.no_of_shift.HeaderText = "No of Shift"
        Me.no_of_shift.Name = "no_of_shift"
        Me.no_of_shift.ReadOnly = True
        '
        'shift1_start_time
        '
        Me.shift1_start_time.HeaderText = "Shift1 Start Time"
        Me.shift1_start_time.Name = "shift1_start_time"
        Me.shift1_start_time.ReadOnly = True
        '
        'Shift1_end_Time
        '
        Me.Shift1_end_Time.HeaderText = "Shift1 End Time"
        Me.Shift1_end_Time.Name = "Shift1_end_Time"
        Me.Shift1_end_Time.ReadOnly = True
        '
        'Shift2_Start_Time
        '
        Me.Shift2_Start_Time.HeaderText = "Shift2 Start Time"
        Me.Shift2_Start_Time.Name = "Shift2_Start_Time"
        Me.Shift2_Start_Time.ReadOnly = True
        '
        'Shift2_end_Time
        '
        Me.Shift2_end_Time.HeaderText = "Shift2 End Time"
        Me.Shift2_end_Time.Name = "Shift2_end_Time"
        Me.Shift2_end_Time.ReadOnly = True
        '
        'Shift3_Start_Time
        '
        Me.Shift3_Start_Time.HeaderText = "Shift3 Start Time"
        Me.Shift3_Start_Time.Name = "Shift3_Start_Time"
        Me.Shift3_Start_Time.ReadOnly = True
        '
        'Shift3_end_Time
        '
        Me.Shift3_end_Time.HeaderText = "Shift3 End Time"
        Me.Shift3_end_Time.Name = "Shift3_end_Time"
        Me.Shift3_end_Time.ReadOnly = True
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = "Edit Data"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        '
        'Tab_reports
        '
        Me.Tab_reports.Controls.Add(Me.Panel_view_chart)
        Me.Tab_reports.Controls.Add(Me.Chk_all_shift)
        Me.Tab_reports.Controls.Add(Me.Chk_shift3)
        Me.Tab_reports.Controls.Add(Me.Chk_shift2)
        Me.Tab_reports.Controls.Add(Me.chk_shift1)
        Me.Tab_reports.Controls.Add(Me.Panel_report_machine_list)
        Me.Tab_reports.Controls.Add(Me.btn_print_report)
        Me.Tab_reports.Controls.Add(Me.btn_chart)
        Me.Tab_reports.Controls.Add(Me.btn_view_report)
        Me.Tab_reports.Controls.Add(Me.DateTime_report_to_time)
        Me.Tab_reports.Controls.Add(Me.DateTime_report_from_time)
        Me.Tab_reports.Controls.Add(Me.lbl_report_to_time)
        Me.Tab_reports.Controls.Add(Me.DateTime_report_dt)
        Me.Tab_reports.Controls.Add(Me.lbl_report_from_time)
        Me.Tab_reports.Controls.Add(Me.lbl_date_report)
        Me.Tab_reports.Controls.Add(Me.WebBrowser_report)
        Me.Tab_reports.Controls.Add(Me.rad_month)
        Me.Tab_reports.Controls.Add(Me.rad_shift)
        Me.Tab_reports.Controls.Add(Me.rad_day)
        Me.Tab_reports.Controls.Add(Me.rad_hour)
        Me.Tab_reports.Controls.Add(Me.rad_minute)
        Me.Tab_reports.ImageIndex = 12
        Me.Tab_reports.Location = New System.Drawing.Point(4, 71)
        Me.Tab_reports.Name = "Tab_reports"
        Me.Tab_reports.Size = New System.Drawing.Size(1192, 652)
        Me.Tab_reports.TabIndex = 2
        Me.Tab_reports.ToolTipText = "Reports"
        Me.Tab_reports.UseVisualStyleBackColor = True
        '
        'Panel_view_chart
        '
        Me.Panel_view_chart.Location = New System.Drawing.Point(216, 52)
        Me.Panel_view_chart.Name = "Panel_view_chart"
        Me.Panel_view_chart.Size = New System.Drawing.Size(929, 378)
        Me.Panel_view_chart.TabIndex = 9
        '
        'Chk_all_shift
        '
        Me.Chk_all_shift.AutoSize = True
        Me.Chk_all_shift.Location = New System.Drawing.Point(937, 12)
        Me.Chk_all_shift.Name = "Chk_all_shift"
        Me.Chk_all_shift.Size = New System.Drawing.Size(74, 21)
        Me.Chk_all_shift.TabIndex = 8
        Me.Chk_all_shift.Text = "All Shift"
        Me.Chk_all_shift.UseVisualStyleBackColor = True
        '
        'Chk_shift3
        '
        Me.Chk_shift3.AutoSize = True
        Me.Chk_shift3.Location = New System.Drawing.Point(862, 12)
        Me.Chk_shift3.Name = "Chk_shift3"
        Me.Chk_shift3.Size = New System.Drawing.Size(63, 21)
        Me.Chk_shift3.TabIndex = 8
        Me.Chk_shift3.Text = "Shift3"
        Me.Chk_shift3.UseVisualStyleBackColor = True
        '
        'Chk_shift2
        '
        Me.Chk_shift2.AutoSize = True
        Me.Chk_shift2.Location = New System.Drawing.Point(794, 12)
        Me.Chk_shift2.Name = "Chk_shift2"
        Me.Chk_shift2.Size = New System.Drawing.Size(63, 21)
        Me.Chk_shift2.TabIndex = 8
        Me.Chk_shift2.Text = "Shift2"
        Me.Chk_shift2.UseVisualStyleBackColor = True
        '
        'chk_shift1
        '
        Me.chk_shift1.AutoSize = True
        Me.chk_shift1.Location = New System.Drawing.Point(727, 12)
        Me.chk_shift1.Name = "chk_shift1"
        Me.chk_shift1.Size = New System.Drawing.Size(63, 21)
        Me.chk_shift1.TabIndex = 8
        Me.chk_shift1.Text = "Shift1"
        Me.chk_shift1.UseVisualStyleBackColor = True
        '
        'Panel_report_machine_list
        '
        Me.Panel_report_machine_list.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel_report_machine_list.AutoScroll = True
        Me.Panel_report_machine_list.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel_report_machine_list.Controls.Add(Me.TreeView1)
        Me.Panel_report_machine_list.Location = New System.Drawing.Point(8, 51)
        Me.Panel_report_machine_list.Name = "Panel_report_machine_list"
        Me.Panel_report_machine_list.Size = New System.Drawing.Size(200, 487)
        Me.Panel_report_machine_list.TabIndex = 7
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.White
        Me.TreeView1.Location = New System.Drawing.Point(0, 1)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(196, 501)
        Me.TreeView1.TabIndex = 0
        '
        'btn_print_report
        '
        Me.btn_print_report.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_print_report.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_print_report.ForeColor = System.Drawing.Color.White
        Me.btn_print_report.Location = New System.Drawing.Point(1116, 543)
        Me.btn_print_report.Name = "btn_print_report"
        Me.btn_print_report.Size = New System.Drawing.Size(53, 29)
        Me.btn_print_report.TabIndex = 6
        Me.btn_print_report.Text = "Print"
        Me.btn_print_report.UseVisualStyleBackColor = False
        '
        'btn_chart
        '
        Me.btn_chart.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_chart.ForeColor = System.Drawing.Color.White
        Me.btn_chart.Location = New System.Drawing.Point(1104, 7)
        Me.btn_chart.Name = "btn_chart"
        Me.btn_chart.Size = New System.Drawing.Size(92, 29)
        Me.btn_chart.TabIndex = 6
        Me.btn_chart.Text = "View Chart"
        Me.btn_chart.UseVisualStyleBackColor = False
        '
        'btn_view_report
        '
        Me.btn_view_report.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btn_view_report.ForeColor = System.Drawing.Color.White
        Me.btn_view_report.Location = New System.Drawing.Point(1011, 8)
        Me.btn_view_report.Name = "btn_view_report"
        Me.btn_view_report.Size = New System.Drawing.Size(92, 29)
        Me.btn_view_report.TabIndex = 6
        Me.btn_view_report.Text = "View Report"
        Me.btn_view_report.UseVisualStyleBackColor = False
        '
        'DateTime_report_to_time
        '
        Me.DateTime_report_to_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTime_report_to_time.Location = New System.Drawing.Point(640, 11)
        Me.DateTime_report_to_time.Name = "DateTime_report_to_time"
        Me.DateTime_report_to_time.ShowUpDown = True
        Me.DateTime_report_to_time.Size = New System.Drawing.Size(80, 23)
        Me.DateTime_report_to_time.TabIndex = 5
        '
        'DateTime_report_from_time
        '
        Me.DateTime_report_from_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTime_report_from_time.Location = New System.Drawing.Point(519, 11)
        Me.DateTime_report_from_time.Name = "DateTime_report_from_time"
        Me.DateTime_report_from_time.ShowUpDown = True
        Me.DateTime_report_from_time.Size = New System.Drawing.Size(78, 23)
        Me.DateTime_report_from_time.TabIndex = 5
        '
        'lbl_report_to_time
        '
        Me.lbl_report_to_time.AutoSize = True
        Me.lbl_report_to_time.ForeColor = System.Drawing.Color.SlateGray
        Me.lbl_report_to_time.Location = New System.Drawing.Point(607, 14)
        Me.lbl_report_to_time.Name = "lbl_report_to_time"
        Me.lbl_report_to_time.Size = New System.Drawing.Size(29, 17)
        Me.lbl_report_to_time.TabIndex = 3
        Me.lbl_report_to_time.Text = "To:"
        '
        'DateTime_report_dt
        '
        Me.DateTime_report_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTime_report_dt.Location = New System.Drawing.Point(353, 11)
        Me.DateTime_report_dt.Name = "DateTime_report_dt"
        Me.DateTime_report_dt.Size = New System.Drawing.Size(97, 23)
        Me.DateTime_report_dt.TabIndex = 5
        '
        'lbl_report_from_time
        '
        Me.lbl_report_from_time.AutoSize = True
        Me.lbl_report_from_time.ForeColor = System.Drawing.Color.SlateGray
        Me.lbl_report_from_time.Location = New System.Drawing.Point(474, 14)
        Me.lbl_report_from_time.Name = "lbl_report_from_time"
        Me.lbl_report_from_time.Size = New System.Drawing.Size(44, 17)
        Me.lbl_report_from_time.TabIndex = 3
        Me.lbl_report_from_time.Text = "From:"
        '
        'lbl_date_report
        '
        Me.lbl_date_report.AutoSize = True
        Me.lbl_date_report.ForeColor = System.Drawing.Color.SlateGray
        Me.lbl_date_report.Location = New System.Drawing.Point(310, 14)
        Me.lbl_date_report.Name = "lbl_date_report"
        Me.lbl_date_report.Size = New System.Drawing.Size(42, 17)
        Me.lbl_date_report.TabIndex = 3
        Me.lbl_date_report.Text = "Date:"
        '
        'WebBrowser_report
        '
        Me.WebBrowser_report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser_report.Location = New System.Drawing.Point(216, 43)
        Me.WebBrowser_report.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser_report.Name = "WebBrowser_report"
        Me.WebBrowser_report.Size = New System.Drawing.Size(967, 471)
        Me.WebBrowser_report.TabIndex = 2
        '
        'rad_month
        '
        Me.rad_month.AutoSize = True
        Me.rad_month.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_month.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_month.Location = New System.Drawing.Point(242, 12)
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
        Me.rad_shift.Location = New System.Drawing.Point(131, 12)
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
        Me.rad_day.Location = New System.Drawing.Point(190, 12)
        Me.rad_day.Name = "rad_day"
        Me.rad_day.Size = New System.Drawing.Size(54, 21)
        Me.rad_day.TabIndex = 0
        Me.rad_day.Text = "Day"
        Me.rad_day.UseVisualStyleBackColor = True
        '
        'rad_hour
        '
        Me.rad_hour.AutoSize = True
        Me.rad_hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_hour.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_hour.Location = New System.Drawing.Point(73, 12)
        Me.rad_hour.Name = "rad_hour"
        Me.rad_hour.Size = New System.Drawing.Size(61, 21)
        Me.rad_hour.TabIndex = 0
        Me.rad_hour.Text = "Hour"
        Me.rad_hour.UseVisualStyleBackColor = True
        '
        'rad_minute
        '
        Me.rad_minute.AutoSize = True
        Me.rad_minute.Checked = True
        Me.rad_minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rad_minute.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.rad_minute.Location = New System.Drawing.Point(2, 12)
        Me.rad_minute.Name = "rad_minute"
        Me.rad_minute.Size = New System.Drawing.Size(74, 21)
        Me.rad_minute.TabIndex = 0
        Me.rad_minute.TabStop = True
        Me.rad_minute.Text = "Minute"
        Me.rad_minute.UseVisualStyleBackColor = True
        '
        'Tab_sync
        '
        Me.Tab_sync.Controls.Add(Me.WebBrowser_chart)
        Me.Tab_sync.Controls.Add(Me.Button1)
        Me.Tab_sync.Controls.Add(Me.btn_create_mysql_tables)
        Me.Tab_sync.ImageIndex = 9
        Me.Tab_sync.Location = New System.Drawing.Point(4, 71)
        Me.Tab_sync.Name = "Tab_sync"
        Me.Tab_sync.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_sync.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tab_sync.Size = New System.Drawing.Size(1192, 652)
        Me.Tab_sync.TabIndex = 3
        Me.Tab_sync.ToolTipText = "Cloud Data Integration"
        Me.Tab_sync.UseVisualStyleBackColor = True
        '
        'WebBrowser_chart
        '
        Me.WebBrowser_chart.Location = New System.Drawing.Point(157, 124)
        Me.WebBrowser_chart.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser_chart.Name = "WebBrowser_chart"
        Me.WebBrowser_chart.Size = New System.Drawing.Size(815, 286)
        Me.WebBrowser_chart.TabIndex = 5
        Me.WebBrowser_chart.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(181, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 53)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "view Chart"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
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
        Me.btn_create_mysql_tables.Visible = False
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
        Me.ImageList1.Images.SetKeyName(13, "Picture1.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1040, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 39)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Machine Make"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Machine Model"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Machine Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Flow Meter"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Recomd Flow Running"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Recomd Flow Idle"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Alert Flow Running"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Alert Flow Idle"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "No of Shift"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Shift1 Start Time"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Shift1 End Time"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Shift2 Start Time"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Shift2 End Time"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Shift3 Start Time"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Shift3 End Time"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'lbl_cust_name_on_head
        '
        Me.lbl_cust_name_on_head.AutoSize = True
        Me.lbl_cust_name_on_head.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cust_name_on_head.ForeColor = System.Drawing.Color.Crimson
        Me.lbl_cust_name_on_head.Location = New System.Drawing.Point(5, 6)
        Me.lbl_cust_name_on_head.Name = "lbl_cust_name_on_head"
        Me.lbl_cust_name_on_head.Size = New System.Drawing.Size(136, 25)
        Me.lbl_cust_name_on_head.TabIndex = 3
        Me.lbl_cust_name_on_head.Text = "Department :"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Link_logout
        '
        Me.Link_logout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Link_logout.AutoSize = True
        Me.Link_logout.BackColor = System.Drawing.Color.Transparent
        Me.Link_logout.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_logout.ForeColor = System.Drawing.Color.FloralWhite
        Me.Link_logout.LinkColor = System.Drawing.Color.White
        Me.Link_logout.Location = New System.Drawing.Point(1137, 6)
        Me.Link_logout.Name = "Link_logout"
        Me.Link_logout.Size = New System.Drawing.Size(60, 18)
        Me.Link_logout.TabIndex = 22
        Me.Link_logout.TabStop = True
        Me.Link_logout.Text = "Logout"
        '
        'lbl_user_name
        '
        Me.lbl_user_name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_user_name.AutoSize = True
        Me.lbl_user_name.BackColor = System.Drawing.Color.Transparent
        Me.lbl_user_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_name.ForeColor = System.Drawing.Color.White
        Me.lbl_user_name.Location = New System.Drawing.Point(989, 7)
        Me.lbl_user_name.Name = "lbl_user_name"
        Me.lbl_user_name.Size = New System.Drawing.Size(98, 17)
        Me.lbl_user_name.TabIndex = 23
        Me.lbl_user_name.Text = "User Name :"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackgroundImage = Global.RECPT_MAIL.My.Resources.Resources.background_head1
        Me.Panel1.Controls.Add(Me.lbl_user_name)
        Me.Panel1.Controls.Add(Me.Link_logout)
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 28)
        Me.Panel1.TabIndex = 24
        '
        'FMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1202, 711)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbl_cust_name_on_head)
        Me.Name = "FMS"
        Me.Text = "FMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_home.ResumeLayout(False)
        Me.Tab_home.PerformLayout()
        CType(Me.dgv_dashboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_settings.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.Panel_view_machines.ResumeLayout(False)
        Me.Panel1_edit_machine_details.ResumeLayout(False)
        Me.Panel1_edit_machine_details.PerformLayout()
        CType(Me.dgv_machines_new, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1_add_new_machines.ResumeLayout(False)
        Me.Panel1_add_new_machines.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.Panel_view_user_role.ResumeLayout(False)
        CType(Me.dgv_user_role, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_add_user.ResumeLayout(False)
        Me.Panel_add_user.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.Panel_company_logo_image.ResumeLayout(False)
        Me.Panel_company_logo_image.PerformLayout()
        Me.Panel_company_logo.ResumeLayout(False)
        Me.Panel_company_logo.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.panel_shift_edit.ResumeLayout(False)
        Me.panel_shift_edit.PerformLayout()
        CType(Me.dgv_shift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_reports.ResumeLayout(False)
        Me.Tab_reports.PerformLayout()
        Me.Panel_report_machine_list.ResumeLayout(False)
        Me.Tab_sync.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Tab_home As TabPage
    Friend WithEvents Tab_settings As TabPage
    Friend WithEvents Tab_reports As TabPage
    Friend WithEvents dgv_dashboard As DataGridView
    Friend WithEvents Tab_sync As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents cmb_machine_model As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmb_create_table_machine_make As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_table_creation_dept_name As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_search_customer As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_save_machine_details As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_flow_meter_id As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_customer As TextBox
    Friend WithEvents txt_create_table_machine_name As TextBox
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents Panel1_add_new_machines As Panel
    Friend WithEvents btn_view_machines As Button
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents BTN_ADD_NEW_MACHINES As Button
    Friend WithEvents btn_create_mysql_tables As Button
    Friend WithEvents txt_Alert_flow_idle As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_Alert_flow_running As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_Alert_recom_flow_idle As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_Alert_recom_flow_running As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label7 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents dgv_machines_new As DataGridView
    Friend WithEvents Panel_view_machines As Panel
    Friend WithEvents txt_recomm_running_edit As TextBox
    Friend WithEvents Panel1_edit_machine_details As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents txt_alert_running_edit As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btn_edit_machine_details As Button
    Friend WithEvents lbl_shift3_end_time As Label
    Friend WithEvents lbl_shift2_end_time As Label
    Friend WithEvents lbl_shift3_start_time As Label
    Friend WithEvents lbl_shift1_end_time As Label
    Friend WithEvents lbl_shift2_start_time As Label
    Friend WithEvents lbl_shift1_start_time As Label
    Friend WithEvents txt_no_of_shifts As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btn_save_shift_detail As Button
    Friend WithEvents date_time_shift1_st_time As DateTimePicker
    Friend WithEvents date_time_shift3_end_time As DateTimePicker
    Friend WithEvents date_time_shift3_st_time As DateTimePicker
    Friend WithEvents date_time_shift2_end_time As DateTimePicker
    Friend WithEvents date_time_shift2_st_time As DateTimePicker
    Friend WithEvents date_time_shift1_end_time As DateTimePicker
    Friend WithEvents rad_month As RadioButton
    Friend WithEvents rad_shift As RadioButton
    Friend WithEvents rad_day As RadioButton
    Friend WithEvents rad_hour As RadioButton
    Friend WithEvents rad_minute As RadioButton
    Friend WithEvents WebBrowser_report As WebBrowser
    Friend WithEvents Timer1 As Timer
    Friend WithEvents dgv_shift As DataGridView
    Friend WithEvents chk_disable_machine_detail As CheckBox
    Friend WithEvents panel_shift_edit As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents WebBrowser_chart As WebBrowser
    Friend WithEvents DateTime_report_from_time As DateTimePicker
    Friend WithEvents DateTime_report_dt As DateTimePicker
    Friend WithEvents lbl_report_from_time As Label
    Friend WithEvents DateTime_report_to_time As DateTimePicker
    Friend WithEvents lbl_report_to_time As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents no_of_shift As DataGridViewTextBoxColumn
    Friend WithEvents shift1_start_time As DataGridViewTextBoxColumn
    Friend WithEvents Shift1_end_Time As DataGridViewTextBoxColumn
    Friend WithEvents Shift2_Start_Time As DataGridViewTextBoxColumn
    Friend WithEvents Shift2_end_Time As DataGridViewTextBoxColumn
    Friend WithEvents Shift3_Start_Time As DataGridViewTextBoxColumn
    Friend WithEvents Shift3_end_Time As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents btn_view_report As Button
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents dept As DataGridViewTextBoxColumn
    Friend WithEvents machine_make As DataGridViewTextBoxColumn
    Friend WithEvents machine_model As DataGridViewTextBoxColumn
    Friend WithEvents machine_name As DataGridViewTextBoxColumn
    Friend WithEvents flow_meter_id As DataGridViewTextBoxColumn
    Friend WithEvents recommended_flow_running As DataGridViewTextBoxColumn
    Friend WithEvents recommended_flow_idle As DataGridViewTextBoxColumn
    Friend WithEvents alert_flow_running As DataGridViewTextBoxColumn
    Friend WithEvents alert_flow_idle As DataGridViewTextBoxColumn
    Friend WithEvents Edit_Data As DataGridViewButtonColumn
    Friend WithEvents lbl_cust_name_on_head As Label
    Friend WithEvents btn_print_report As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents rad_cfm As RadioButton
    Friend WithEvents rad_lpm As RadioButton
    Friend WithEvents btn_refresh As Button
    Friend WithEvents btn_chart As Button
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents btn_upload_user_logo As Button
    Friend WithEvents txt_alert_idle_edit As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txt_recom_idle_edit As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents rad_dashboard_sorting_flow As RadioButton
    Friend WithEvents rad_dashboard_sorting_machine As RadioButton
    Friend WithEvents Label31 As Label
    Friend WithEvents rad_logo_image As RadioButton
    Friend WithEvents rad_logo_text As RadioButton
    Friend WithEvents btn_create_user_role As Button
    Friend WithEvents cmb_dept_user_tab As ComboBox
    Friend WithEvents txt_email_id As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Txt_user_name As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txt_pwd As TextBox
    Friend WithEvents txt_user_id As TextBox
    Friend WithEvents txt_phone_no As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents cmb_user_role_user_tab As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents btn_save_user_detail As Button
    Friend WithEvents Panel_add_user As Panel
    Friend WithEvents dgv_user As DataGridView
    Friend WithEvents btn_add_user As Button
    Friend WithEvents btn_cancel_user_addition As Button
    Friend WithEvents dgv_user_role As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents chk_user_end_date As CheckBox
    Friend WithEvents Link_logout As LinkLabel
    Friend WithEvents BTN_VIEW_ROLES As Button
    Friend WithEvents Panel_view_user_role As Panel
    Friend WithEvents btn_user_role_visibility As Button
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents EMail As DataGridViewTextBoxColumn
    Friend WithEvents Phone_No As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
    Friend WithEvents lbl_user_name As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel_report_machine_list As Panel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents chk_shift1 As CheckBox
    Friend WithEvents Chk_all_shift As CheckBox
    Friend WithEvents Chk_shift3 As CheckBox
    Friend WithEvents Chk_shift2 As CheckBox
    Friend WithEvents lbl_date_report As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_complany_logo_text As TextBox
    Friend WithEvents Panel_company_logo As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel_company_logo_image As Panel
    Friend WithEvents Txt_company_logo_image As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents LBL_FLOW_METRIC_HOME_PAGE As Label
    Friend WithEvents Panel_view_chart As Panel
End Class
