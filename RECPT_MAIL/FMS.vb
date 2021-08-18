Imports System.Globalization
Imports System.IO
Public Class FMS
    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.237.129 ;initial catalog=jan_FMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.23.222;port:3306;Database=janatics;uid=root;password=T006@123;option=3;")
    'Dim ada_mysql As New Odbc.OdbcDataAdapter
    'Dim cmd_mysql As New Odbc.OdbcCommand
    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim cmd_sql As New OleDb.OleDbCommand
    Dim customer_id, chek_count, nor As Integer
    Dim row_span, COL_SPAN_REMARKS As Integer
    Dim report_header As String = ""
    Dim back_ground_color As String = ""
    Dim user_edit As Integer
    Dim CHK As CheckBox = New CheckBox
    Dim FILE_NAME As String
    Dim open_dialogue As New OpenFileDialog
    Dim LOGO_TEXT, LOGO_NAME, LOGO_TYPE As String
    Dim selected_machines As String = "'"
    Dim ds_time_diff As DataSet
    Private Sub FMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SHIFT_DATA_FREEZING()
        ''minute_DATA_FREEZING()

        TabControl1.SelectedIndex = 0
        lbl_user_name.Text = "User :" & FMS_LOGIN_USER
        date_time_shift1_st_time.Format = DateTimePickerFormat.Custom
        date_time_shift1_st_time.CustomFormat = "hh:mm tt"

        date_time_shift1_end_time.Format = DateTimePickerFormat.Custom
        date_time_shift1_end_time.CustomFormat = "hh:mm tt"

        date_time_shift2_st_time.Format = DateTimePickerFormat.Custom
        date_time_shift2_st_time.CustomFormat = "hh:mm tt"

        date_time_shift2_end_time.Format = DateTimePickerFormat.Custom
        date_time_shift2_end_time.CustomFormat = "hh:mm tt"

        date_time_shift3_st_time.Format = DateTimePickerFormat.Custom
        date_time_shift3_st_time.CustomFormat = "hh:mm tt"

        date_time_shift3_end_time.Format = DateTimePickerFormat.Custom
        date_time_shift3_end_time.CustomFormat = "hh:mm tt"

        DateTime_report_from_time.Format = DateTimePickerFormat.Custom
        DateTime_report_to_time.CustomFormat = "hh:mm tt"

        date_time_shift3_end_time.Format = DateTimePickerFormat.Custom
        date_time_shift3_end_time.CustomFormat = "hh:mm tt"

        txt_no_of_shifts.Text = 1
        shift_detail_visibility()

        sql = "alter  table  JAN_FMS_MILL_VS_MACHINE add  column (recommended_flow_running float,recommended_flow_idle float,alert_flow_running float,alert_flow_idle float  )"
        sql = " delete from jan_fms_mill_vs_machine where machine_make=',Schlafhorst'"
        sql = "update jan_fms_mill_vs_machine set recommended_flow_running='3.5',recommended_flow_idle=0, alert_flow_running='3',alert_flow_idle=0  where flow_meter_id='2-'  "

        sql = "alter  table  jan_fms_shift_details rename  shifrt3_end_time to shifrt3_end_time"
        'sql = "ALTER TABLE jan_fms_shift_details   CHANGE COLUMN shifrt1_end_time shift1_end_time time"
        'z = Execute_Query_mysql(sql)

        DateTime_report_from_time.Format = DateTimePickerFormat.Custom
        DateTime_report_from_time.CustomFormat = "hh:mm tt"

        DateTime_report_to_time.Format = DateTimePickerFormat.Custom
        DateTime_report_to_time.CustomFormat = "hh:mm tt"

        txt_customer.Text = "PURANI TEXTILES PRIVATE LTD.,"
        txt_customer.Enabled = False
        lbl_cust_name_on_head.Text = txt_customer.Text

        'sql = "select *  from jan_fms_mill_vs_machine   where   end_date is null order by machine_name"
        '      sql = " SELECT 'All' machine_name ,0 flow_meter_id union
        'select machine_name,flow_meter_id  from jan_fms_mill_vs_machine  A   where   end_date is null  ORDER BY flow_meter_id"
        '      ds = SQL_SELECT_mysql("machine_detail", sql)
        '      cmb_report_machine_name.DataSource = ds.Tables("machine_detail")
        '      cmb_report_machine_name.DisplayMember = "machine_name"
        '      cmb_report_machine_name.ValueMember = "flow_meter_id"

        '      sql = " select distinct dept from jan_fms_mill_vs_machine   where   end_date is null " 'select 'All' dept union 
        '      ds = SQL_SELECT_mysql("dept", sql)
        '      cmb_report_dept.DataSource = ds.Tables("dept")
        '      cmb_report_dept.DisplayMember = "dept"



        refresh_dashboard()
        btn_view_machines_Click(sender, e)
        'display_report()
        SHOW_Shift_detail()
        panel_shift_edit.Visible = False
        Panel_add_user.Visible = False

    End Sub
    Private Sub UPDATE_MACHINE_LIST()
        sql = "Select  distinct dept from jan_fms_mill_vs_machine where end_date Is null"
        ds1 = SQL_SELECT_mysql("dept", sql)
        Dim offset As Integer = 10

        TreeView1.Nodes.Clear()
        TreeView1.CheckBoxes = True
        chek_count = 0
        For j = 0 To ds1.Tables("dept").Rows.Count - 1
            TreeView1.Nodes.Add(ds1.Tables("dept").Rows(j).Item("dept").ToString)

            sql = "Select * From jan_fms_mill_vs_machine Where end_date Is null and  dept='" & ds1.Tables("dept").Rows(j).Item("dept") & "'"
            ds = SQL_SELECT_mysql("res", sql)

            For i = 0 To ds.Tables("res").Rows.Count - 1
                With ds.Tables("res")
                    TreeView1.Nodes(j).Nodes.Add(.Rows(i).Item("machine_name").ToString)

                End With
            Next
        Next
    End Sub
    Private Sub SHOW_Shift_detail()
        dgv_shift.Rows.Clear()
        sql = "select no_of_shift ""No of Shift"",shift1_start_time ""Shift1 Start time"",shift1_end_time ""Shift1 End time"",shift2_start_time ""Shift2 Start time"",shift2_end_time ""Shift2 End time"",shift3_start_time ""Shift3 Start time"",shift3_end_time ""Shift3 End time"" from jan_fms_shift_details order by no_of_shift "
        sql = "select no_of_shift ,time_format(shift1_start_time,'%r')shift1_start_time ,time_format(shift1_end_time,'%r')shift1_end_time ,time_format(shift2_start_time,'%r')shift2_start_time ,time_format(shift2_end_time,'%r')shift2_end_time ,time_format(shift3_start_time,'%r')shift3_start_time ,time_format(shift3_end_time,'%r')shift3_end_time  from jan_fms_shift_details order by no_of_shift "

        ds = SQL_SELECT_mysql("shift_detail", sql)
        If ds.Tables("shift_detail").Rows.Count > 0 Then txt_no_of_shifts.Text = ds.Tables("shift_detail").Rows(0).Item("no_of_shift")
        dgv_shift.Rows.Add(ds.Tables("shift_detail").Rows.Count)


        For i = 0 To ds.Tables("shift_detail").Rows.Count - 1
            With ds.Tables("shift_detail").Rows(i)
                dgv_shift.Rows(i).Cells(0).Value = .Item("no_of_shift")
                dgv_shift.Rows(i).Cells(1).Value = .Item("shift1_start_time")
                dgv_shift.Rows(i).Cells(2).Value = .Item("shift1_end_time")
                dgv_shift.Rows(i).Cells(3).Value = .Item("shift2_start_time")
                dgv_shift.Rows(i).Cells(4).Value = .Item("shift2_end_time")
                dgv_shift.Rows(i).Cells(5).Value = .Item("shift3_start_time")

                dgv_shift.Rows(i).Cells(6).Value = .Item("shift3_end_time")

                dgv_shift.Rows(i).Cells(7).Value = "Edit"

            End With
        Next
        'dgv_shift.DataSource = ds.Tables("shift_detail")

        'Dim btn As New DataGridViewButtonColumn
        'btn.HeaderText = "Edit Data"
        'btn.Text = "Edit"
        'btn.Name = "btn"
        'btn.UseColumnTextForButtonValue = True
        'dgv_shift.Columns.Add(btn)

    End Sub
    Private Sub display_report()
        Try
            selected_machines = selected_machines.Replace(",", "','")

            WebBrowser_report.DocumentText = ""

            Dim report_head_metric As String = ""
            If rad_cfm.Checked = True Then report_head_metric = "CFM" Else report_head_metric = "LPM"
            If rad_lpm.Checked = True Then
                LBL_FLOW_METRIC_HOME_PAGE.Text = "Flow value in LPM"
            Else
                LBL_FLOW_METRIC_HOME_PAGE.Text = "Flow value in CFM"
            End If
            'If cmb_report_machine_name.SelectedValue = "" Then Exit Sub

            Dim value_to_take As String = ""


            If rad_lpm.Checked = True Then
                value_to_take = " (flow_value) "
                value_to_take = " (AVG_flow_value) "
            Else
                value_to_take = "  (flow_value/28.31)"
                value_to_take = "  (AVG_flow_value/28.31)"
            End If

            sql = "Select * From jan_fms_shift_details   "
            ds = SQL_SELECT_mysql("LOGO", sql)
            LOGO_TEXT = ds.Tables("LOGO").Rows(0).Item("COMPANY_LOGO_TEXT").ToString
            'LOGO_NAME = Application.StartupPath & "\company_logo\" & ds.Tables("LOGO").Rows(0).Item("COMPANY_LOGO_FILE_NAME").ToString
            LOGO_NAME = "d:\company_logo\" & ds.Tables("LOGO").Rows(0).Item("COMPANY_LOGO_FILE_NAME").ToString
            LOGO_TYPE = ds.Tables("LOGO").Rows(0).Item("COMPANY_LOGO_OR_TEXT").ToString


            If selected_machines = "" Or selected_machines = "'" Then
                MessageBox.Show("Select one Machine And run report", "Janatics AFMS", MessageBoxButtons.OK)
                Exit Sub
            End If

            If rad_minute.Checked = True Or rad_hour.Checked = True Then

                sql = "Select * from jan_fms_mill_vs_machine   where   end_date Is null And  machine_name In (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & " )"
                ds2 = SQL_SELECT_mysql("report", sql)
                If ds2.Tables("report").Rows.Count > 1 Then
                    MessageBox.Show("Select one Machine And run report", "Janatics AFMS", MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If
            If rad_minute.Checked = True Then
                row_span = 2
                COL_SPAN_REMARKS = 3
                report_header = "Air consumption - Minute Report"


                sql = " Select slave_id,group_id ,HOUR_NO,MINUTE_NO  ,TIME_FORMAT(CONCAT(HOUR_NO,':',MINUTE_NO), '%h:%i  %p')hou_minute ,cast(ifnull((Case When digital_input=0 Then " & value_to_take & " Else 0  End),0) As Decimal(6,2)) flow_value "

                sql &= "  ,cast(ifnull((Case When digital_input=1 Then " & value_to_take & "  Else 0  End ),0) As Decimal(6,2)) idle_value "

                sql &= "    FROM JAN_FLOW_minute_DATA a where FLOW_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  and slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") "
                sql &= " )  And CONCAT(HOUR_NO,':',MINUTE_NO)>='" & Format(DateTime_report_from_time.Value, "HH:mm") & "' and CONCAT(HOUR_NO,':',MINUTE_NO)<='" & Format(DateTime_report_to_time.Value, "HH:mm") & "' "
                sql &= "  order by  HOUR_NO, MINUTE_NO "
                Cursor.Current = Cursors.WaitCursor
                ds2 = SQL_SELECT_mysql("report", sql)
            ElseIf rad_hour.Checked = True Then
                row_span = 2
                COL_SPAN_REMARKS = 4
                report_header = "Air consumption - Hour Report "


                sql = "select * from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & " )"
                ds2 = SQL_SELECT_mysql("report", sql)
                If ds2.Tables("report").Rows.Count > 1 Then
                    MessageBox.Show("Select one Machine and run report", "Janatics AFMS", MessageBoxButtons.OK)
                    Exit Sub
                End If


                sql = "select FLOW_DATE date,slave_id,group_id ,HOUR_NO  ,cast(ifnull(AVG(case when digital_input=0 then  " & value_to_take & "  else 0  end ),0) as decimal(6,2)) flow_value 
  ,cast(ifnull(AVG(case when digital_input=1 then  " & value_to_take & "   else 0  end),0) as decimal(6,2)) idle_value  
    ,TIME_FORMAT(concat(HOUR_NO,':',minute_no), '%h:%p')hou_minute
 ,TIME_FORMAT(concat(FLOW_date, ' ',hour_no,' ', MINUTE_NO), '%p')mer
 FROM JAN_FLOW_minute_DATA a where   slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ")) 
 And    concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)>='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 08:00' And    concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)<date_add('" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 07:59',interval 1 day )  
 group by slave_id,group_id,TIME_FORMAT(concat(hour_no,':', MINUTE_NO), '%h:%p') ,TIME_FORMAT(concat(FLOW_date, ' ',hour_no,' ', MINUTE_NO), '%p'),HOUR_NO
 order by DATE,HOUR_NO,mer"

                Cursor.Current = Cursors.WaitCursor
                ds2 = SQL_SELECT_mysql("report", sql)
                '  Query to get average
                sql = "select null date,slave_id,group_id ,null HOUR_NO  ,cast(ifnull(AVG(case when digital_input=0 then  " & value_to_take & "  else 0  end ),0) as decimal(6,2)) flow_value 
  ,cast(ifnull(AVG(case when digital_input=1 then  " & value_to_take & "   else 0  end),0) as decimal(6,2)) idle_value  
    ,null hou_minute
 ,null mer
 FROM JAN_FLOW_minute_DATA a where   slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ")) 
 And    concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)>='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 08:00' And    concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)<date_add('" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 07:59',interval 1 day )  
 group by slave_id,group_id "

                Cursor.Current = Cursors.WaitCursor
                ds1 = SQL_SELECT_mysql("report", sql)
                'ds2 = ds1.Clone
                'ds2.Tables.Add(ds1.Tables("report"))
                'ds2.Merge(ds1.Tables("report"))

                With ds2.Tables("report")
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Item("flow_value") = ds1.Tables(0).Rows(0).Item("flow_value")
                    .Rows(.Rows.Count - 1).Item("idle_value") = ds1.Tables(0).Rows(0).Item("idle_value")
                End With
                ds2.AcceptChanges()


            ElseIf rad_shift.Checked = True Then
                row_span = 2
                report_header = "Air consumption - Shift Report"

                sql = "select  slave_id,(SELECT DEPT FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=A.SLAVE_ID )dept
,(SELECT machine_name FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=A.SLAVE_ID )machine_name "
                If chk_shift1.Checked = True Then
                    sql &= "  ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value "
                End If
                If Chk_shift2.Checked = True Then
                    sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
"
                End If
                If Chk_shift3.Checked = True Then
                    sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value
 "
                End If
                If Chk_all_shift.Checked = True Then


                    sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value "
                    sql &= " ,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_IDLE_value"
                End If

                sql &= " from JAN_FLOW_MINUTE_DATA   A where  "
                sql &= "  slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") )  AND "

                'sql &= " flow_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  "

                'sql &= " And   concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)>='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "  08:00'"
                'sql &= " And   concat(FLOW_date, ' ',hour_no,':', MINUTE_NO)<date_add('" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "  08:00',interval 1 day )"
                sql &= "     concat(flow_date, ' ', hOUR_NO, ':', MINUTE_NO)>='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 08:00'"
                sql &= "    and concat(flow_date, ' ', hOUR_NO, ':', MINUTE_NO)<date_add('" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & " 07:59',interval 1 day )"

                sql &= " GROUP BY slave_id ORDER BY FLOW_DATE,slave_id"
                If (Chk_all_shift.Checked = True) And (chk_shift1.Checked = True Or Chk_shift2.Checked = True Or Chk_shift3.Checked = True) Then
                    MessageBox.Show("Select Single Shift or All Shift then run the report ", " Janatics AFMS", MessageBoxButtons.OK)
                    Exit Sub
                ElseIf (Chk_all_shift.Checked = False And chk_shift1.Checked = False And Chk_shift2.Checked = False And Chk_shift3.Checked = False) Then
                    MessageBox.Show("Select Single Shift or All Shift then run the report ", " Janatics AFMS", MessageBoxButtons.OK)
                    Exit Sub
                End If

                Cursor.Current = Cursors.WaitCursor
                ds2 = SQL_SELECT_mysql("report", sql)
            ElseIf rad_day.Checked = True Then
                row_span = 2
                report_header = "Air consumption - Day Report"
                COL_SPAN_REMARKS = 10


                sql = "select  REPORT_DATE date ,slave_id,(SELECT DEPT FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=b.SLAVE_ID )dept
,(SELECT machine_name FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=b.SLAVE_ID )machine_name "

                sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value "
                sql &= " ,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_IDLE_value"


                sql &= " from (select a.*,CASE WHEN shift_no =3 THEN date_add(a.FLOW_DATE,interval -1 day ) WHEN shift_no =2  and hour_no='00' and minute_no between '00' and '29' THEN date_add(a.FLOW_DATE,interval -1 day )  ELSE FLOW_DATE END REPORT_DATE  FROM JAN_FLOW_MINUTE_DATA   A where  "
                sql &= "  slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") ))b  where  "

                'sql &= " flow_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  
                sql &= " date_format(REPORT_DATE,'%b-%Y')='" & Format(DateTime_report_dt.Value, "MMM-yyyy") & "' 
  GROUP BY REPORT_DATE  ,slave_id ORDER BY REPORT_DATE"

                Cursor.Current = Cursors.WaitCursor
                ds2 = SQL_SELECT_mysql("report", sql)

                ' Query For average 

                sql = "select  null date ,slave_id,(SELECT DEPT FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=b.SLAVE_ID )dept
,(SELECT machine_name FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=b.SLAVE_ID )machine_name "

                sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value "
                sql &= " ,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_IDLE_value"


                sql &= " from (select a.*,CASE WHEN shift_no =3 THEN date_add(a.FLOW_DATE,interval -1 day ) WHEN shift_no =2  and hour_no='00' and minute_no between '00' and '29' THEN date_add(a.FLOW_DATE,interval -1 day )  ELSE FLOW_DATE END REPORT_DATE  FROM JAN_FLOW_MINUTE_DATA   A where  "
                sql &= "  slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") ))b  where  "

                'sql &= " flow_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  
                sql &= " date_format(REPORT_DATE,'%b-%Y')='" & Format(DateTime_report_dt.Value, "MMM-yyyy") & "' 
  GROUP BY slave_id "
                Cursor.Current = Cursors.WaitCursor
                ds1 = SQL_SELECT_mysql("report", sql)


                With ds2.Tables("report")
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Item("shift1_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift1_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift2_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift2_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift3_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift3_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("total_RUNNING_value") = ds1.Tables(0).Rows(0).Item("total_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift1_idle_value") = ds1.Tables(0).Rows(0).Item("shift1_idle_value")
                    .Rows(.Rows.Count - 1).Item("shift2_idle_value") = ds1.Tables(0).Rows(0).Item("shift2_idle_value")
                    .Rows(.Rows.Count - 1).Item("shift3_idle_value") = ds1.Tables(0).Rows(0).Item("shift3_idle_value")
                    .Rows(.Rows.Count - 1).Item("total_idle_value") = ds1.Tables(0).Rows(0).Item("total_idle_value")
                End With
                ds2.AcceptChanges()

            ElseIf rad_month.Checked = True Then
                row_span = 2
                report_header = "Air consumption - Month Report"
                COL_SPAN_REMARKS = 11

                sql = "select  date_format(REPORT_DATE,'%b-%Y') DATE ,month(REPORT_DATE)month_no ,slave_id,(SELECT DEPT FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=B.SLAVE_ID )dept
,(SELECT machine_name FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=B.SLAVE_ID )machine_name "

                sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value "
                sql &= " ,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_IDLE_value"


                sql &= " from ( select a.*,CASE WHEN shift_no =3 THEN date_add(a.FLOW_DATE,interval -1 day ) WHEN shift_no =2  AND HOUR_NO='00' and minute_no between '00' and '29' THEN date_add(a.FLOW_DATE,interval -1 day )  ELSE FLOW_DATE END REPORT_DATE  FROM JAN_FLOW_MINUTE_DATA   A where  "
                sql &= "  slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") ))B  WHERE  "

                'sql &= " flow_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  
                'sql &= " date_format(FLOW_DATE,'%b-%Y')='" & Format(DateTime_report_dt.Value, "MMM-yyyy") & "' "
                sql &= " date_format(REPORT_DATE,'%Y')='" & Format(DateTime_report_dt.Value, "yyyy") & "'"
                sql &= "  GROUP BY slave_id ,date_format(REPORT_DATE,'%b-%Y')  ,month(REPORT_DATE) ORDER BY slave_id,REPORT_DATE"

                Cursor.Current = Cursors.WaitCursor
                ds2 = SQL_SELECT_mysql("report", sql)

                'Query for average
                sql = "select  null DATE ,null month_no ,slave_id,(SELECT DEPT FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=B.SLAVE_ID )dept
,(SELECT machine_name FROM jan_fms_mill_vs_machine WHERE END_DATE IS NULL AND FLOW_METER_ID=B.SLAVE_ID )machine_name "

                sql &= " ,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=1  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift1_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=2  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift2_IDLE_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN SHIFT_NO=3  AND DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) shift3_IDLE_value "
                sql &= " ,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=0 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_RUNNING_value
,CAST(IFNULL(AVG(CASE WHEN  DIGITAL_INPUT=1 THEN " & value_to_take & "  END),0)  AS DECIMAL(6,2)) TOTAL_IDLE_value"


                sql &= " from ( select a.*,CASE WHEN shift_no =3 THEN date_add(a.FLOW_DATE,interval -1 day ) WHEN shift_no =2  AND HOUR_NO='00' and minute_no between '00' and '29' THEN date_add(a.FLOW_DATE,interval -1 day )  ELSE FLOW_DATE END REPORT_DATE  FROM JAN_FLOW_MINUTE_DATA   A where  "
                sql &= "  slave_id IN (select flow_meter_id from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & ") ))B  WHERE  "

                'sql &= " flow_date='" & Format(DateTime_report_dt.Value, "yyyy-MM-dd") & "'  
                'sql &= " date_format(FLOW_DATE,'%b-%Y')='" & Format(DateTime_report_dt.Value, "MMM-yyyy") & "' "
                sql &= " date_format(REPORT_DATE,'%Y')='" & Format(DateTime_report_dt.Value, "yyyy") & "'"
                sql &= "  GROUP BY slave_id "

                Cursor.Current = Cursors.WaitCursor
                ds1 = SQL_SELECT_mysql("report", sql)

                With ds2.Tables("report")
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Item("shift1_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift1_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift2_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift2_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift3_RUNNING_value") = ds1.Tables(0).Rows(0).Item("shift3_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("total_RUNNING_value") = ds1.Tables(0).Rows(0).Item("total_RUNNING_value")
                    .Rows(.Rows.Count - 1).Item("shift1_idle_value") = ds1.Tables(0).Rows(0).Item("shift1_idle_value")
                    .Rows(.Rows.Count - 1).Item("shift2_idle_value") = ds1.Tables(0).Rows(0).Item("shift2_idle_value")
                    .Rows(.Rows.Count - 1).Item("shift3_idle_value") = ds1.Tables(0).Rows(0).Item("shift3_idle_value")
                    .Rows(.Rows.Count - 1).Item("total_idle_value") = ds1.Tables(0).Rows(0).Item("total_idle_value")
                End With
                ds2.AcceptChanges()

            End If


            If ds2.Tables("report").Rows.Count > 0 Then
                print_report_data()
            Else
                MessageBox.Show("Flow Data Not Found", " Janatics FMS ", MessageBoxButtons.OK)
            End If


        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
            MessageBox.Show("Flow Data Not Found", " Janatics FMS ", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub print_report_data()
        If ds2.Tables("report").Rows.Count > 0 Then
            With ds2.Tables("report")

                Try
                    If rad_minute.Checked = True Then 'ThenOr rad_hour.Checked = True 
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Item("flow_value") = Math.Round(.Compute("avg(flow_value)", "flow_value>=0"), 2)
                        .Rows(.Rows.Count - 1).Item("idle_value") = Math.Round(.Compute("avg(idle_value)", "idle_value>=0"), 2)
                    ElseIf rad_shift.Checked = True Then ' Or rad_month.Checked = True or rad_month.Checked = True Then
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Item("shift1_RUNNING_value") = Math.Round(.Compute("avg(shift1_RUNNING_value)", "shift1_RUNNING_value>=0"), 2)
                        .Rows(.Rows.Count - 1).Item("shift2_RUNNING_value") = Math.Round(.Compute("avg(shift2_RUNNING_value)", "shift2_RUNNING_value>=0"), 2)
                        .Rows(.Rows.Count - 1).Item("shift3_RUNNING_value") = Math.Round(.Compute("avg(shift3_RUNNING_value)", "shift3_RUNNING_value>=0"), 2)
                        .Rows(.Rows.Count - 1).Item("total_RUNNING_value") = Math.Round(.Compute("avg(total_RUNNING_value)", "total_RUNNING_value>=0"), 2)
                        .Rows(.Rows.Count - 1).Item("shift1_idle_value") = .Compute("sum(shift1_idle_value)", "shift1_idle_value>=0")
                        .Rows(.Rows.Count - 1).Item("shift2_idle_value") = .Compute("sum(shift2_idle_value)", "shift2_idle_value>=0")
                        .Rows(.Rows.Count - 1).Item("shift3_idle_value") = .Compute("sum(shift3_idle_value)", "shift3_idle_value>=0")
                        .Rows(.Rows.Count - 1).Item("total_idle_value") = .Compute("sum(total_idle_value)", "total_idle_value>=0")

                    End If
                Catch ex As Exception

                End Try
            End With
            Cursor.Current = Cursors.Default
            Dim I_CURR_VAL As Integer = 0
            S = ""
            'REPORT_START:
            S &= " <html>"
            S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
            S &= "<table width=100% align=center class=tab>" '<style>img {  width:150px;  height:75px;}</style>
            If rad_minute.Checked = True Or rad_hour.Checked = True Then

                sql = "select  TIME_FORMAT('" & Format(DateTime_report_from_time.Value, "HH:mm") & "','%r') from_time , TIME_FORMAT('" & Format(DateTime_report_to_time.Value, "HH:mm") & "','%r') to_time,(select case when '" & Format(DateTime_report_from_time.Value, "HH:mm") & "' between time_format(shift1_start_time,'%H:%i') and time_format(shift1_end_time,'%H:%i') then 1
 when '" & Format(DateTime_report_from_time.Value, "HH:mm") & "' between time_format(shift2_start_time,'%H:%i') and time_format(DATE_ADD(shift2_start_time, INTERVAL 2 HOUR),'%H:%i') then 2 "

                sql &= " Else 3 end FROM janatics.jan_fms_shift_details )shift_no ,(select MACHINE_NAME from jan_fms_mill_vs_machine where end_date is null AND machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & "))MACHINE_NAME "
                sql &= " , (select DEPT from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & "))DEPT "
                ds1 = SQL_SELECT_mysql("report_period", sql)
            End If



            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"

            If rad_minute.Checked = True Or rad_hour.Checked = True Then

                S &= "<tr style=""background-color:4287f5; color:white""><td width=20%  rowspan=" & row_span & "  ALIGN=CENTER>"
                If LOGO_TYPE = "Logo" Then
                    S &= " <img src=""" & LOGO_NAME & """></img> "
                    'S &= " <img src=""D:\projects\RECPT_MAIL\RECPT_MAIL\bin\Debug\company_logo\ FMS_LOGO1""></img> "
                Else
                    S &= "" & LOGO_TEXT & ""
                End If

                S &= " </td><td  width=40%  rowspan=" & row_span & " ALIGN=center>" & report_header & "</td><td width=15%>Date:</td><td  width=15%>" & Format(DateTime_report_dt.Value, "dd-MM-yyyy") & "</td></tr>"
                S &= "<tr style=""background-color:4287f5; color:white""><td width=15%>Page No:</td><td  width=15%>1 of 1</td></tr>"

                S &= "<tr><td >Dept :&nbsp;" & ds1.Tables("report_period").Rows(0).Item("DEPT") & "</td ><td >"

                If rad_minute.Checked = True Then S &= " From " & ds1.Tables("report_period").Rows(0).Item("from_time") & "- " & ds1.Tables("report_period").Rows(0).Item("to_time") & "" Else S &= " &nbsp;"

                S &= " </td >"
                If rad_minute.Checked = True Then S &= "<td >Shift No:" & ds1.Tables("report_period").Rows(0).Item("shift_no") & "</td >" Else S &= "<td >&nbsp;</td >"
                S &= " <td >Macine.No:&nbsp;" & ds1.Tables("report_period").Rows(0).Item("MACHINE_NAME") & "</td></tr>"

            Else
                S &= "<tr style=""background-color:4287f5; color:white""><td width=20%  rowspan=" & row_span & "  ALIGN=CENTER>"
                '" & LOGO_TEXT & "
                If LOGO_TYPE = "Logo" Then
                    S &= " <img src=""" & LOGO_NAME & """></img> "
                    'S &= " <img src=""D:\projects\RECPT_MAIL\RECPT_MAIL\bin\Debug\company_logo\ FMS_LOGO1""></img> "
                Else
                    S &= "" & LOGO_TEXT & ""
                End If
                S &= " </td><td  width=45%  rowspan=" & row_span & " ALIGN=center>" & report_header & "</td><td width=10%>Date:</td><td  width=15%>" & Format(DateTime_report_dt.Value, "dd-MM-yyyy") & "</td></tr>" 'txt_customer.text
                S &= "<tr style=""background-color:4287f5; color:white""><td width=15%>Page No:</td><td  width=15%>1 of 1</td></tr>"
            End If

            S &= "<tr><td colspan=4 align=right>" & LBL_FLOW_METRIC_HOME_PAGE.Text & "</td></tr>"
            'S &= "<tr><td colspan=4 align=center>&nbsp;</td></tr>"

            S &= "</table>"
            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"

            If rad_hour.Checked = True Or rad_minute.Checked = True Then
                If rad_minute.Checked = True Then
                    S &= " <tr style=""background-color:4287f5; color:white""><th width=30%>Time</th><th width=35%>Running</th><th width=35%>Idle</th></tr>"
                Else
                    S &= " <tr style=""background-color:4287f5; color:white""><th width=25%>Date</th><th width=25%>Time</th><th width=25%>Running</th><th width=25%>Idle</th></tr>"
                End If

                For i = 0 To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)
                        'If i <> 0 And (i Mod 15) = 0 And I_CURR_VAL <> i Then
                        '    I_CURR_VAL = i
                        '    S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
                        '    S &= " </table>"
                        '    S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"
                        '    S &= "<tr  style=""height=80px"" ><td WIDTH=50% VALIGN=TOP><b>Prepared by :</b></td><td  WIDTH=50% VALIGN=TOP><b>Approved by :</b></td></tr >"
                        '    S &= "<table>"
                        '    S &= "<br style= page-break-before:always;>"
                        '    GoTo REPORT_START
                        'End If
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """> "
                        S &= " <td align=center>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            If rad_hour.Checked = True Then S &= "</TD><TD>&nbsp;</td>"
                        Else
                            If rad_hour.Checked = True Then S &= "" & Format(.Item("date"), "dd-MM-yyyy") & "</td><td  align=center> "
                            S &= "  " & .Item("hou_minute") & " "
                        End If
                        S &= " </td><td align=center>" & .Item("flow_value") & "</td><td  align=center>" & .Item("idle_value") & "</td>"
                        S &= "  </tr>"
                    End With
                Next

                S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            ElseIf rad_day.Checked = True Or rad_month.Checked = True Then
                S &= " <tr style=""background-color:4287f5; color:white""><th rowspan=2>Dept</th><th rowspan=2>Machine</th> "

                If rad_day.Checked = True Then S &= " <th rowspan=2>Day</th>"
                If rad_month.Checked = True Then S &= " <th rowspan=2>Month</th>"
                S &= " <th colspan=2>Shift1</th><th colspan=2>Shift2</th><th colspan=2>Shift3</th><th colspan=2>Total</th></tr>"
                S &= " <tr><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th></tr>"
                For i = 0 To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """><td  ALIGN=CENTER>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            S &= " </td><td>&nbsp;"

                        Else
                            S &= "" & .Item("dept") & " "
                            S &= " </td><td  ALIGN=CENTER>"
                            S &= "  " & .Item("machine_name") & " "
                        End If

                        S &= " </td>"

                        S &= " <td align=center>"
                        'Try
                        If rad_day.Checked = True Then
                            If IsDBNull(.Item("date")) = True Then S &= "&nbsp;" Else S &= " " & Format(.Item("date"), "dd-MM-yyyy") & ""
                        Else
                            If IsDBNull(.Item("date")) = True Then S &= "&nbsp;" Else S &= " " & .Item("date") & ""
                        End If
                        'Catch ex As Exception
                        '    S &= " &nbsp;"
                        'End Try
                        S &= "</td>"

                        If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                        If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                        If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"


                        If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"

                        If IsDBNull(.Item("total_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("total_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_idle_value") & "</td>"

                        S &= "  </tr >"
                    End With
                Next
                If rad_month.Checked = True Then COL_SPAN_REMARKS = COL_SPAN_REMARKS + 4 Else COL_SPAN_REMARKS = COL_SPAN_REMARKS + 10

                S &= "<tr style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            ElseIf rad_shift.Checked = True Then
                COL_SPAN_REMARKS = 2
                S &= " <tr style=""background-color:4287f5; color:white""><th rowspan=2>Dept</th><th rowspan=2>Machine</th> "

                If Chk_all_shift.Checked = True Then
                    COL_SPAN_REMARKS = 10
                    S &= " <th colspan=2>Shift1</th><th colspan=2>Shift2</th><th colspan=2>Shift3</th><th colspan=2>Total</th></tr>"
                    S &= " <tr><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th>"
                End If

                If chk_shift1.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift1</th>"
                End If

                If Chk_shift2.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift2</th>"
                End If

                If Chk_shift3.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift3</th>"
                End If

                S &= "</TR><tr>"
                If chk_shift1.Checked = True Then S &= " <th>Running</th><th>Idle</th>"

                If Chk_shift2.Checked = True Then S &= " <th>Running</th><th>Idle</th>"

                If Chk_shift3.Checked = True Then S &= " <th>Running</th><th>Idle</th>"


                S &= " </tr>"
                For i = 0 To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """><td  ALIGN=CENTER>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            S &= " </td><td>&nbsp;"

                        Else
                            S &= "" & .Item("dept") & " "
                            S &= " </td><td ALIGN=CENTER>"
                            S &= "  " & .Item("machine_name") & " "
                        End If
                        S &= " </td>"
                        If Chk_all_shift.Checked = True Then


                            If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                            If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                            If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"


                            If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"

                            If IsDBNull(.Item("total_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("total_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_idle_value") & "</td>"
                        End If
                        If chk_shift1.Checked = True Then
                            If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                            If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                        End If
                        If Chk_shift2.Checked = True Then
                            If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td >" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"
                        End If
                        If Chk_shift3.Checked = True Then

                            If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"
                        End If
                        S &= "  </tr >"
                    End With
                Next
                S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            End If

            S &= " </table>"
            'S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"
            S &= "<tr  style=""height=80px"" ><td WIDTH=50% VALIGN=TOP><b>Prepared by :</b></td><td  WIDTH=50% VALIGN=TOP><b>Approved by :</b></td></tr >"
            S &= "<table>"
            S &= "<table>"
            S &= " </html>"
            WebBrowser_report.DocumentText = S
        End If
    End Sub
    Private Sub print_report_PREVIEW()
        If ds2.Tables("report").Rows.Count > 0 Then

            Cursor.Current = Cursors.Default
            Dim I_CURR_VAL As Integer = 0
            S = ""
REPORT_START:
            S &= " <html>"
            S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
            S &= "<table width=100% align=center class=tab>" '<style>img {  width:150px;  height:75px;}</style>
            If rad_minute.Checked = True Or rad_hour.Checked = True Then

                sql = "select  TIME_FORMAT('" & Format(DateTime_report_from_time.Value, "HH:mm") & "','%r') from_time , TIME_FORMAT('" & Format(DateTime_report_to_time.Value, "HH:mm") & "','%r') to_time,(select case when '" & Format(DateTime_report_from_time.Value, "HH:mm") & "' between time_format(shift1_start_time,'%H:%i') and time_format(shift1_end_time,'%H:%i') then 1
 when '" & Format(DateTime_report_from_time.Value, "HH:mm") & "' between time_format(shift2_start_time,'%H:%i') and time_format(DATE_ADD(shift2_start_time, INTERVAL 2 HOUR),'%H:%i') then 2 "

                sql &= " Else 3 end FROM janatics.jan_fms_shift_details )shift_no ,(select MACHINE_NAME from jan_fms_mill_vs_machine where end_date is null AND machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & "))MACHINE_NAME "
                sql &= " , (select DEPT from jan_fms_mill_vs_machine   where   end_date is null and  machine_name IN (" & selected_machines.ToString.Substring(0, selected_machines.Length - 2) & "))DEPT "
                ds1 = SQL_SELECT_mysql("report_period", sql)
            End If



            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"

            If rad_minute.Checked = True Or rad_hour.Checked = True Then

                S &= "<tr style=""background-color:4287f5; color:white""><td width=20%  rowspan=" & row_span & "  ALIGN=CENTER>"
                If LOGO_TYPE = "Logo" Then
                    S &= " <img src=""" & LOGO_NAME & """></img> "
                    'S &= " <img src=""D:\projects\RECPT_MAIL\RECPT_MAIL\bin\Debug\company_logo\ FMS_LOGO1""></img> "
                Else
                    S &= "" & LOGO_TEXT & ""
                End If

                S &= " </td><td  width=40%  rowspan=" & row_span & " ALIGN=center>" & report_header & "</td><td width=15%>Date:</td><td  width=15%>" & Format(DateTime_report_dt.Value, "dd-MM-yyyy") & "</td></tr>"
                S &= "<tr style=""background-color:4287f5; color:white""><td width=15%>Page No:</td><td  width=15%>1 of 1</td></tr>"

                S &= "<tr><td >Dept :&nbsp;" & ds1.Tables("report_period").Rows(0).Item("DEPT") & "</td ><td >"

                If rad_minute.Checked = True Then S &= " From " & ds1.Tables("report_period").Rows(0).Item("from_time") & "- " & ds1.Tables("report_period").Rows(0).Item("to_time") & "" Else S &= " &nbsp;"

                S &= " </td >"
                If rad_minute.Checked = True Then S &= "<td >Shift No:" & ds1.Tables("report_period").Rows(0).Item("shift_no") & "</td >" Else S &= "<td >&nbsp;</td >"
                S &= " <td >Macine.No:&nbsp;" & ds1.Tables("report_period").Rows(0).Item("MACHINE_NAME") & "</td></tr>"

            Else
                S &= "<tr style=""background-color:4287f5; color:white""><td width=20%  rowspan=" & row_span & "  ALIGN=CENTER>"
                '" & LOGO_TEXT & "
                If LOGO_TYPE = "Logo" Then
                    S &= " <img src=""" & LOGO_NAME & """></img> "
                    'S &= " <img src=""D:\projects\RECPT_MAIL\RECPT_MAIL\bin\Debug\company_logo\ FMS_LOGO1""></img> "
                Else
                    S &= "" & LOGO_TEXT & ""
                End If
                S &= " </td><td  width=45%  rowspan=" & row_span & " ALIGN=center>" & report_header & "</td><td width=10%>Date:</td><td  width=15%>" & Format(DateTime_report_dt.Value, "dd-MM-yyyy") & "</td></tr>" 'txt_customer.text
                S &= "<tr style=""background-color:4287f5; color:white""><td width=15%>Page No:</td><td  width=15%>1 of 1</td></tr>"
            End If

            S &= "<tr><td colspan=4 align=right>" & LBL_FLOW_METRIC_HOME_PAGE.Text & "</td></tr>"
            'S &= "<tr><td colspan=4 align=center>&nbsp;</td></tr>"

            S &= "</table>"
            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"

            If rad_hour.Checked = True Or rad_minute.Checked = True Then
                If rad_minute.Checked = True Then
                    S &= " <tr style=""background-color:4287f5; color:white""><th width=30%>Time</th><th width=35%>Running</th><th width=35%>Idle</th></tr>"
                Else
                    S &= " <tr style=""background-color:4287f5; color:white""><th width=25%>Date</th><th width=25%>Time</th><th width=25%>Running</th><th width=25%>Idle</th></tr>"
                End If

                For i = I_CURR_VAL To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)
                        If i <> 0 And (i Mod 15) = 0 And I_CURR_VAL <> i Then
                            I_CURR_VAL = i
                            S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
                            S &= " </table>"
                            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"
                            S &= "<tr  style=""height=80px"" ><td WIDTH=50% VALIGN=TOP><b>Prepared by :</b></td><td  WIDTH=50% VALIGN=TOP><b>Approved by :</b></td></tr >"
                            S &= "<table>"
                            S &= "<br style= page-break-before:always;>"
                            GoTo REPORT_START
                        End If
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """> "
                        S &= " <td align=center>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            If rad_hour.Checked = True Then S &= "</TD><TD>&nbsp;</td>"
                        Else
                            If rad_hour.Checked = True Then S &= "" & Format(.Item("date"), "dd-MM-yyyy") & "</td><td  align=center> "
                            S &= "  " & .Item("hou_minute") & " "
                        End If
                        S &= " </td><td align=center>" & .Item("flow_value") & "</td><td  align=center>" & .Item("idle_value") & "</td>"
                        S &= "  </tr>"
                    End With
                Next

                S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            ElseIf rad_day.Checked = True Or rad_month.Checked = True Then
                S &= " <tr style=""background-color:4287f5; color:white""><th rowspan=2>Dept</th><th rowspan=2>Machine</th> "

                If rad_day.Checked = True Then S &= " <th rowspan=2>Day</th>"
                If rad_month.Checked = True Then S &= " <th rowspan=2>Month</th>"
                S &= " <th colspan=2>Shift1</th><th colspan=2>Shift2</th><th colspan=2>Shift3</th><th colspan=2>Total</th></tr>"
                S &= " <tr><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th></tr>"
                For i = I_CURR_VAL To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)

                        If i <> 0 And (i Mod 15) = 0 And I_CURR_VAL <> i Then
                            I_CURR_VAL = i
                            S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
                            S &= " </table>"
                            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"
                            S &= "<tr  style=""height=80px"" ><td WIDTH=50% VALIGN=TOP><b>Prepared by :</b></td><td  WIDTH=50% VALIGN=TOP><b>Approved by :</b></td></tr >"
                            S &= "<table>"
                            S &= "<br style= page-break-before:always;>"
                            GoTo REPORT_START
                        End If
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """><td  ALIGN=CENTER>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            S &= " </td><td>&nbsp;"

                        Else
                            S &= "" & .Item("dept") & " "
                            S &= " </td><td  ALIGN=CENTER>"
                            S &= "  " & .Item("machine_name") & " "
                        End If

                        S &= " </td>"

                        S &= " <td align=center>"
                        'Try
                        If rad_day.Checked = True Then
                            If IsDBNull(.Item("date")) = True Then S &= "&nbsp;" Else S &= " " & Format(.Item("date"), "dd-MM-yyyy") & ""
                        Else
                            If IsDBNull(.Item("date")) = True Then S &= "&nbsp;" Else S &= " " & .Item("date") & ""
                        End If
                        'Catch ex As Exception
                        '    S &= " &nbsp;"
                        'End Try
                        S &= "</td>"

                        If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                        If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                        If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"


                        If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"

                        If IsDBNull(.Item("total_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_RUNNING_value") & "</td>"

                        If IsDBNull(.Item("total_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_idle_value") & "</td>"

                        S &= "  </tr >"
                    End With
                Next
                If rad_month.Checked = True Then COL_SPAN_REMARKS = COL_SPAN_REMARKS + 4 Else COL_SPAN_REMARKS = COL_SPAN_REMARKS + 10

                S &= "<tr style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            ElseIf rad_shift.Checked = True Then
                COL_SPAN_REMARKS = 2
                S &= " <tr style=""background-color:4287f5; color:white""><th rowspan=2>Dept</th><th rowspan=2>Machine</th> "

                If Chk_all_shift.Checked = True Then
                    COL_SPAN_REMARKS = 10
                    S &= " <th colspan=2>Shift1</th><th colspan=2>Shift2</th><th colspan=2>Shift3</th><th colspan=2>Total</th></tr>"
                    S &= " <tr><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th><th>Running</th><th>Idle</th>"
                End If

                If chk_shift1.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift1</th>"
                End If

                If Chk_shift2.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift2</th>"
                End If

                If Chk_shift3.Checked = True Then
                    COL_SPAN_REMARKS += 2
                    S &= "<th colspan=2>Shift3</th>"
                End If

                S &= "</TR><tr>"
                If chk_shift1.Checked = True Then S &= " <th>Running</th><th>Idle</th>"

                If Chk_shift2.Checked = True Then S &= " <th>Running</th><th>Idle</th>"

                If Chk_shift3.Checked = True Then S &= " <th>Running</th><th>Idle</th>"


                S &= " </tr>"
                For i = 0 To ds2.Tables("report").Rows.Count - 1
                    With ds2.Tables("report").Rows(i)
                        If (i Mod 2) = 0 Then back_ground_color = "e6f9ff" Else back_ground_color = "f0f0f5"
                        S &= "  <tr style =""color :blue ;border-style :dotted;background-color:" & back_ground_color & """><td  ALIGN=CENTER>"
                        If i = ds2.Tables("report").Rows.Count - 1 Then
                            S &= "Average :"
                            S &= " </td><td>&nbsp;"

                        Else
                            S &= "" & .Item("dept") & " "
                            S &= " </td><td ALIGN=CENTER>"
                            S &= "  " & .Item("machine_name") & " "
                        End If
                        S &= " </td>"
                        If Chk_all_shift.Checked = True Then


                            If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                            If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                            If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"


                            If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"

                            If IsDBNull(.Item("total_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("total_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("total_idle_value") & "</td>"
                        End If
                        If chk_shift1.Checked = True Then
                            If IsDBNull(.Item("shift1_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift1_RUNNING_value") & "</td> "
                            If IsDBNull(.Item("shift1_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= "<td  align=center>" & .Item("shift1_idle_value") & "</td>"
                        End If
                        If Chk_shift2.Checked = True Then
                            If IsDBNull(.Item("shift2_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift2_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift2_idle_value")) = True Then S &= "<td  align=center>0.00</td >" Else S &= " <td align=center>" & .Item("shift2_idle_value") & "</td>"
                        End If
                        If Chk_shift3.Checked = True Then

                            If IsDBNull(.Item("shift3_RUNNING_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_RUNNING_value") & "</td>"

                            If IsDBNull(.Item("shift3_idle_value")) = True Then S &= "<td  align=center>0.00</td>" Else S &= " <td align=center>" & .Item("shift3_idle_value") & "</td>"
                        End If
                        S &= "  </tr >"
                    End With
                Next
                S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            End If

            S &= " </table>"
            'S &= "<tr  style=""height=80px""><td colspan=" & COL_SPAN_REMARKS & " VALIGN=TOP><b>Remarks :</b></td></tr >"
            S &= " <table border=""1""  cellpadding =""4"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "" width=100%>"
            S &= "<tr  style=""height=80px"" ><td WIDTH=50% VALIGN=TOP><b>Prepared by :</b></td><td  WIDTH=50% VALIGN=TOP><b>Approved by :</b></td></tr >"
            S &= "<table>"
            S &= "<table>"
            S &= " </html>"
            WebBrowser_report.DocumentText = S
        End If
    End Sub


    Private Sub refresh_dashboard()

        sql = "select b.*,case when flow_value>recommended_flow_running   then 'Red' when flow_value>=alert_flow_running and flow_value<recommended_flow_running   then 'Orange' when flow_value<=recommended_flow_running   then 'Green' else 'skyblue'
end flow_status from (select a.* ,(select  "
        If rad_lpm.Checked = True Then sql &= "  cast(case when digital_input=0 then flow_value else 0  end as decimal(10,2)) " Else sql &= " cast(case when digital_input=0 then flow_value/28.31 else 0  end as decimal(10,2)) "


        sql &= " from flow_meter USE INDEX (idx_flow_meter_slave_id_date_time) where slave_id=a.flow_meter_id and date=date(sysdate()) 
and (slave_id,time,date )in (SELECT slave_id, max(time)max_time,max(date)max_date FROM janatics.FLOW_METER where date=date(sysdate()) group by slave_id)) flow_value "

        sql &= " ,(select  "
        If rad_lpm.Checked = True Then sql &= "  cast(case when digital_input=1 then flow_value else 0  end as decimal(10,2)) " Else sql &= " cast(case when digital_input=1 then flow_value/28.31 else 0  end as decimal(10,2)) "

        sql &= " from flow_meter USE INDEX (idx_flow_meter_slave_id_date_time) where slave_id=a.flow_meter_id and date=date(sysdate()) 
and (slave_id,time,date )in (SELECT slave_id, max(time)max_time,max(date)max_date FROM janatics.FLOW_METER USE INDEX (idx_flow_meter_slave_id_date_time) where date=date(sysdate()) group by slave_id)) idle_value "
        sql &= " from jan_fms_mill_vs_machine a where end_date is null)b  "

        'Code to freeze minute-wise folw
        '        sql = " select T.MINUTE_DATA_FREEZE_TIME ss1,NOW() ss ,TIMESTAMPDIFF(MINUTE,T.MINUTE_DATA_FREEZE_TIME,NOW()) min_di
        ',TIMESTAMPDIFF(day,T.MINUTE_DATA_FREEZE_TIME,NOW()) day_dif,t.* from jan_fms_shift_details T"
        '        ds_time_diff = SQL_SELECT_mysql("minute_data", sql)
        '        With ds_time_diff.Tables("minute_data").Rows(0)
        '            If .Item("min_di") > 0 Then minute_DATA_FREEZING()

        '        End With
        'End 


        sql = " SELECT  a.* ,0.00 AS  flow_value,0.00 AS idle_value, 'DEEPSKYBLUE' flow_status,0.00 AS yesterday_avg,0.00 AS today_avg from jan_fms_mill_vs_machine a where end_date is null order by flow_meter_id "

        'sql = " SELECT  a.* ,0.00 AS  flow_value,0.00 AS idle_value, 0.00 AS yesterday_avg,0.00 AS today_avg from jan_fms_mill_vs_machine a where end_date is null "
        ds2 = SQL_SELECT_mysql("data", sql)

        For i = 0 To ds2.Tables("data").Rows.Count - 1
            With ds2.Tables("data").Rows(i)

                sql = "select a.* "
                sql &= " ,(select max(date) from flow_meter where date<a.max_date and  slave_id=a.slave_id)previous_day "
                sql &= " from (SELECT digital_input,date,slave_id, max(time)max_time,
max(date)max_date FROM janatics.FLOW_METER USE INDEX (idx_flow_meter_slave_id_date_time) where date=date(sysdate()) and slave_id='" & .Item("FLOW_METER_id") & "' group by slave_id,date,digital_input)a "
                ds1 = SQL_SELECT_mysql("MAX_DATE", sql)
                Try

                    sql = "SELECT IFNULL((select   "
                    If rad_lpm.Checked = True Then sql &= "  cast(  flow_value  as decimal(10,2)) " Else sql &= " cast( flow_value/28.31 as decimal(10,2)) "

                    sql &= " From flow_meter USE INDEX (idx_flow_meter_slave_id_date_time) where slave_id='" & ds1.Tables("MAX_DATE").Rows(0).Item("slave_id") & "' and date='" & Format(ds1.Tables("MAX_DATE").Rows(0).Item("max_date"), "yyyy-MM-dd") & "' AND TIME='" & ds1.Tables("MAX_DATE").Rows(0).Item("MAX_TIME").ToString.Substring(0, ds1.Tables("MAX_DATE").Rows(0).Item("MAX_TIME").ToString.Length) & "' ),0) flow_val "


                    sql &= ", IFNULL((select   "
                    If rad_lpm.Checked = True Then sql &= "  cast(  AVG(avg_flow_value)  as decimal(10,2)) " Else sql &= " cast( AVG(avg_flow_value/28.31) as decimal(10,2)) "

                    sql &= " From JAN_FLOW_minute_DATA   where slave_id='" & ds1.Tables("MAX_DATE").Rows(0).Item("slave_id") & "' and  flow_date='" & Format(ds1.Tables("MAX_DATE").Rows(0).Item("previous_day"), "yyyy-MM-dd") & "'  ),0) yesterday_avg "

                    sql &= ", IFNULL((Select   "

                    If rad_lpm.Checked = True Then sql &= "  cast(  AVG(avg_flow_value)  As Decimal(10,2)) " Else sql &= " cast( AVG(avg_flow_value/28.31) As Decimal(10,2)) "

                    sql &= " From JAN_FLOW_minute_DATA where slave_id='" & ds1.Tables("MAX_DATE").Rows(0).Item("slave_id") & "'  and  flow_date='" & Format(ds1.Tables("MAX_DATE").Rows(0).Item("max_date"), "yyyy-MM-dd") & "' ),0) today_avg "

                    sql &= " FROM DUAL"
                    ds3 = SQL_SELECT_mysql("flow_val", sql)

                    If ds1.Tables("MAX_DATE").Rows(0).Item("digital_input") = 0 Then
                        ds2.Tables("data").Rows(i).Item("flow_value") = ds3.Tables("flow_val").Rows(0).Item("flow_val")
                        ds2.Tables("data").Rows(i).Item("yesterday_avg") = ds3.Tables("flow_val").Rows(0).Item("yesterday_avg")
                        ds2.Tables("data").Rows(i).Item("today_avg") = ds3.Tables("flow_val").Rows(0).Item("today_avg")

                    Else
                        ds2.Tables("data").Rows(i).Item("idle_value") = ds3.Tables("flow_val").Rows(0).Item("flow_val")
                        ds2.Tables("data").Rows(i).Item("yesterday_avg") = ds3.Tables("flow_val").Rows(0).Item("yesterday_avg")
                        ds2.Tables("data").Rows(i).Item("today_avg") = ds3.Tables("flow_val").Rows(0).Item("today_avg")
                    End If

                    If ds2.Tables("data").Rows(i).Item("flow_value") > ds2.Tables("data").Rows(i).Item("recommended_flow_running") Then
                        ds2.Tables("data").Rows(i).Item("flow_status") = "Red"

                    ElseIf ds2.Tables("data").Rows(i).Item("flow_value") >= ds2.Tables("data").Rows(i).Item("alert_flow_running") Then
                        ds2.Tables("data").Rows(i).Item("flow_status") = "Orange"

                    ElseIf ds2.Tables("data").Rows(i).Item("flow_value") <= ds2.Tables("data").Rows(i).Item("recommended_flow_running") Then
                        ds2.Tables("data").Rows(i).Item("flow_status") = "Green"
                    Else
                        ds2.Tables("data").Rows(i).Item("flow_status") = "skyblue"

                    End If
                    ds2.Tables("data").AcceptChanges()

                Catch ex As Exception

                End Try
            End With
        Next

        Dim dv As DataView = ds2.Tables("data").DefaultView

        If rad_dashboard_sorting_machine.Checked = True Then
            dv.Sort = "flow_meter_id ASC"
        Else
            dv.Sort = "flow_value DESC "
        End If
        Dim style As String = ""
        Dim no_of_rows As Double = 0
        no_of_rows = Math.Ceiling(ds2.Tables("data").Rows.Count / 6)

        If rad_lpm.Checked = True Then
            LBL_FLOW_METRIC_HOME_PAGE.Text = "Flow value in LPM"
        Else
            LBL_FLOW_METRIC_HOME_PAGE.Text = "Flow value in CFM"
        End If
        Dim col_start, col_end, NEW_ROW As Integer

        col_start = 0
        col_end = 0
        S = ""
        S &= "<html><head><style>td {
  border-top-style: none;  border-top-width: thin;border-top-color: SILVER;border-bottom-style: solid;  border-bottom-width: thin;border-bottom-color: SILVER;border-left-style: solid;  border-left-width: thin;border-left-color: SILVER;border-right-style: none;  border-right-width: thin;
border-right-color: SILVER;}</style></head>"

        If no_of_rows = 1 Then
            S &= " <table border=""0""  cellpadding =""5"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial ""  WIDTH=" & (ds2.Tables("data").Rows.Count + 1) * 12.4 & "% >"
        Else
            S &= " <table border=""0""  cellpadding =""5"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial ""  WIDTH=99% >"
        End If

        NEW_ROW = 1

        For nor = 0 To no_of_rows - 1
            NEW_ROW = 1
            If nor = 0 Then col_start = nor + col_end Else col_start = 1 + col_end
            'If nor = 0 Then col_end = 7 Else col_end = nor * 7
            'col_end = (nor + 1) * 6
            col_end = col_start + 6

            If col_end > ds2.Tables("DATA").Rows.Count - 1 Then col_end = ds2.Tables("DATA").Rows.Count - 1
            'If nor <> 0 Then S &= " <Tr><TD COMSPAN=15 style=""border-LEFT-style: none;  border-Top - Width: thin;"">&nbsp;</TD></Tr>"
            If nor <> 0 Then
                If col_start > col_end Then GoTo END_DASHBOARD_DATA
                S &= " <Tr><TD COMSPAN=15 style=""border-LEFT-style: none;border-TOP-style: none;"">&nbsp;</TD></Tr>"
            End If

            '1st row
            S &= "  <tr style =""font-weight :bold ;color :white ;border-style :dotted ;height:50px"" >"
            For i = col_start To col_end
                With dv(i)
                    If NEW_ROW = 1 Then S &= "  <td style =""background-color :cornflowerblue ;width :12.4% ;color:wheat;border-top-style: solid;  border-top - Width: thik""  >Machine No </td>"

                    If i = col_end Then style = """ border-right-style: solid;  border-right - Width: thik;""" Else style = """width :5% """
                    S &= "  <td style =""background-color :" & .Item("flow_status") & "  ; " & style & """ align=center "
                    S &= " COLSPAN =2 "
                    S &= " >" & .Item("machine_name") & "</td> "
                    NEW_ROW = 2
                End With
            Next

            S &= " </tr>"


            NEW_ROW = 1
            '2ND ROW
            S &= "  <tr  style =""background-color :lightsteelblue ;font-weight :bold ;border-style :dotted;height:50px"">"
            For i = col_start To col_end
                With dv(i)
                    If NEW_ROW = 1 Then S &= "  <td style =""width :12.4% ;background-color :cornflowerblue ;color:wheat;font-weight :bold""  >Parameter</td>"
                    If i = col_end Then style = """width :6.2%;border-right-style: solid;  border-right - Width: thik;""" Else style = """width :6.2%"""
                    S &= "  <td style =""width :6.2% "" align=center >Running</td> <td style =" & style & " align=center >Idle</td>"
                    NEW_ROW = 2
                End With
            Next
            '''3rd Row
            S &= " </tr>"

            NEW_ROW = 1
            S &= " <tr style =""background-color :aliceblue;border-style :dotted;height:50px "" >"
            For i = col_start To col_end
                With dv(i)
                    If NEW_ROW = 1 Then S &= "<td style =""width :12.4% ;background-color :cornflowerblue ;color:wheat;font-weight :bold""  >Flow Rate</td>"
                    If i = col_end Then style = """width :6.2%;border-right-style: solid;  border-right - Width: thik;""" Else style = """width :6.2%"""
                    S &= "<td align=center style =""width :6.2% "">" & .Item("flow_value") & "</td> <td align=center style =" & style & ">" & .Item("IDLE_value") & "</td>"
                    NEW_ROW = 2
                End With
            Next
            S &= " </tr>"
            NEW_ROW = 1
            '''4th Row
            S &= " <tr style =""background-color :lightsteelblue ;border-style :dotted ;height:50px"" >"
            For i = col_start To col_end
                With dv(i)
                    If NEW_ROW = 1 Then S &= "<td style =""width :12.4% ;background-color :cornflowerblue ;color:wheat;font-weight :bold""  >Previous day average</td>" 'Or shift"
                    If i = col_end Then style = """width :6.2%;border-right-style: solid;  border-right - Width: thik;""" Else style = """width :6.2%"""
                    S &= "<td align=center  style =""width :6.2% "">" & .Item("yesterday_avg") & "</td> <td align=center  style =" & style & ">" & .Item("IDLE_value") & "</td>"
                    NEW_ROW = 2
                End With
            Next
            S &= " </tr>"
            '''Row 5
            NEW_ROW = 1

            S &= " <tr style =""background-color :aliceblue;border-style :dotted;height:50px "" >"
            For i = col_start To col_end
                With dv(i)
                    If NEW_ROW = 1 Then S &= "<td style =""width :12.4% ;background-color :cornflowerblue ;color:wheat;font-weight :bold""  >Today average</td>" 'Or current shift 

                    If i = col_end Then style = """width :6.2%;border-right-style: solid;  border-right - Width: thik;""" Else style = """width :6.2%"""
                    S &= "<td align=center  style =""width :6.2% "">" & .Item("today_avg") & "</td> <td align=center  style =" & style & ">" & .Item("IDLE_value") & "</td>"
                    NEW_ROW = 2
                End With
            Next
            S &= " </tr>"


        Next
END_DASHBOARD_DATA:
        S &= " </table>"
        S &= "</html>"
        WebBrowser1.DocumentText = S


        'With dgv_dashboard
        '    .DataSource = dv
        '    .Columns("customer_id").Visible = False
        '    ', , , , , , , , , , ,, , , , FLOW_VALUE, IDLE_VALUE, FLOW_STATUS
        '    .Columns("customer_id").Visible = False

        '    .Columns("customer_id").Visible = False
        '    .Columns("dept").Visible = False
        '    .Columns("MANUFACTURING_YEAR").Visible = False
        '    '.Columns("machine_name").Visible = False
        '    .Columns("machine_make").Visible = False
        '    .Columns("machine_model").Visible = False
        '    .Columns("flow_meter_id").Visible = False
        '    .Columns("CREATION_DATE").Visible = False
        '    .Columns("LAST_UPDATE_DATE").Visible = False
        '    .Columns("recommended_flow_running").Visible = False
        '    .Columns("recommended_flow_idle").Visible = False
        '    .Columns("alert_flow_running").Visible = False
        '    .Columns("alert_flow_idle").Visible = False
        '    .Columns("END_DATE").Visible = False
        '    .Columns("VIEW_REPORT").Visible = False
        '    '.Cells("customer_id").Visible = False
        '    '.Cells("customer_id").Visible = False

        'End With
        'Next

        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        refresh_dashboard()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Timer1.Tag = True Then
            Timer1.Tag = False
            Timer1.Stop()
            Try
                refresh_dashboard()
            Catch ex As Exception

            End Try


        Else
            Timer1.Tag = True
        End If
    End Sub
    Private Sub dgv_dashboard_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_dashboard.CellFormatting
        For Each dvr As DataGridViewRow In dgv_dashboard.Rows
            Try
                Dim sty As New DataGridViewCellStyle
                sty.BackColor = Color.LightSeaGreen
                If Val(dvr.Cells("flow_value").Value) > 0 Then dvr.Cells(2).Style = sty

            Catch ex As Exception

            End Try
        Next
    End Sub
    Private Sub cmb_table_creation_dept_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_table_creation_dept_name.SelectedIndexChanged
        sql = " Select distinct machine_make from JAN_FMS_MILL_VS_MACHINE where customer_id=" & customer_id & " And machine_name='" & cmb_table_creation_dept_name.Text & "' "
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        ds1 = New DataSet
        adap_sql.Fill(ds1, "machine_make")
        If ds1.Tables("machine_make").Rows.Count > 0 Then
            cmb_create_table_machine_make.DataSource = ds1.Tables("machine_make")

            cmb_create_table_machine_make.DisplayMember = "machine_make"
        End If
    End Sub
    Private Sub cmb_create_table_machine_make_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_create_table_machine_make.SelectedIndexChanged


        sql = " select distinct machine_model from JAN_FMS_MILL_VS_MACHINE where customer_id=" & customer_id & " and machine_name='" & cmb_table_creation_dept_name.Text & "' and machine_make='" & cmb_create_table_machine_make.Text & "' "
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        ds1 = New DataSet
        adap_sql.Fill(ds1, "machine_model")
        If ds1.Tables("machine_model").Rows.Count > 0 Then
            cmb_machine_model.DataSource = ds1.Tables("machine_model")
            cmb_machine_model.DisplayMember = "machine_model"
        End If

    End Sub

    Private Sub btn_search_customer_Click(sender As Object, e As EventArgs) Handles btn_search_customer.Click
        ' Fill cutomer detail
        sql = " select * from JAN_FMS_CUSTOMER_MASTER where customer_name like 'PURANI TEXTILES PRIVATE LTD.,%'"
        sql = " select * from JAN_FMS_CUSTOMER_MASTER where customer_name like '" & Trim(txt_customer.Text) & "%'"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        ds = New DataSet
        adap_sql.Fill(ds, "data")
        If ds.Tables("data").Rows.Count > 0 Then
            txt_customer.Text = ds.Tables("data").Rows(0).Item("customer_name")
            customer_id = ds.Tables("data").Rows(0).Item("customer_id")
            'Fill Machine Detail
            sql = " select distinct machine_name from JAN_FMS_MILL_VS_MACHINE where customer_id=" & ds.Tables("data").Rows(0).Item("customer_id") & " "
            adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            ds1 = New DataSet
            adap_sql.Fill(ds1, "machine_detail")
            If ds1.Tables("machine_detail").Rows.Count > 0 Then
                cmb_table_creation_dept_name.DataSource = ds1.Tables("machine_detail")

                cmb_table_creation_dept_name.DisplayMember = "machine_name"
            End If
        End If
    End Sub
    Private Sub BTN_ADD_NEW_MACHINES_Click(sender As Object, e As EventArgs) Handles BTN_ADD_NEW_MACHINES.Click
        If fms_edit = 1 Then

            Panel1_add_new_machines.Visible = True
            Panel_view_machines.Visible = False
            'dgv_machines_new.Visible = False
            'dgv_machines_new.SendToBack()
            'Panel1_add_new_machines.BringToFront()
        Else
            MessageBox.Show("Add / Edit Option Not Enabled  ...!", "Janatics FMS", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub btn_create_mysql_tables_Click_1(sender As Object, e As EventArgs) Handles btn_create_mysql_tables.Click
        '        Dim z As Int32 = 0
        '        sql = "create table IF NOT EXISTS jan_fms_customer_master(customer_id int,customer_name varchar(100),creation_date date,last_update_date date)"
        '        z = Execute_Query_mysql(sql)

        '        sql = "INSERT INTO jan_fms_customer_master (CUSTOMER_ID,CUSTOMER_NAME,cREATION_DATE,LAST_UPDATE_DATE) 
        'VALUES(19798,'" & txt_customer.Text.ToString.Replace("'", "''") & "',sysdate(),sysdate())"
        '        z = Execute_Query_mysql(sql)

        '        sql = "create table IF NOT EXISTS JAN_FMS_MILL_VS_MACHINE(CUSTOMER_ID int,dept varchar(20),manufacturing_year varchar(10),MACHINE_NAME varchar(100),MACHINE_MAKE varchar(50),MACHINE_MODEL varchar(50),FLOW_METER_ID varchar(30),creation_date date,last_update_date date,recommended_flow_running float,recommended_flow_idle float,alert_flow_running float,alert_flow_idle float,end_date date )"
        '        z = Execute_Query_mysql(sql)

        '        sql = "create table IF NOT EXISTS JAN_FMS_MASTER(CUSTOMER_ID int,FLOW_METER_ID varchar(30),RECOMMENDED_FLOW  float,alert_flow float ,creation_date date,last_update_date date  )"
        '        z = Execute_Query_mysql(sql)

        '        sql = "create table IF NOT EXISTS jan_fms_user_master(customer_id int,user_name varchar(30),user_id varchar(30),p_key varchar(30),email varchar(30),phone_no varchar(30),user_role int,department varchar(30) ,creation_date date,lat_update_date date,end_date date)"
        '        z = Execute_Query_mysql(sql)

        '        sql = "create table IF NOT EXISTS jan_FMS_user_role( user_group int ,view_option int,Edit_option int,delete_option int,Shift_setting_option int,creation_date date,last_update_date date ,user_role varchar(30)  )"
        '        z = Execute_Query_mysql(sql)

        '        sql = "create table  IF NOT EXISTS  jan_fms_shift_details(customer_id int ,no_of_shift int,shift1_start_time time,shift1_end_time time,shift2_start_time time,shift2_end_time time,shift3_start_time time,shift3_end_time time,creation_date date,last_update_date date)"
        '        z = Execute_Query_mysql(sql)

        '        sql = "INSERT INTO jan_fms_shift_details VALUES(customer_id  ,no_of_shift ,shift1_start_time ,shift1_end_time ,creation_date ) values((select CUSTOMER_ID from jan_fms_customer_master ),1,'08:00 AM','04:30 PM',sysdaye())"
        '        z = Execute_Query_mysql(sql)

        '        MessageBox.Show("Required Tables Created ", " Janatics AFMS Table creation", MessageBoxButtons.OK)
    End Sub
    Private Sub btn_save_machine_details_Click(sender As Object, e As EventArgs) Handles btn_save_machine_details.Click
        sql = " SELECT * FROM JAN_FMS_MILL_VS_MACHINE WHERE  FLOW_METER_ID='" & Trim(txt_flow_meter_id.Text) & "' AND END_DATE IS NULL"
        ds = SQL_SELECT_mysql("data", sql)
        If ds.Tables("data").Rows.Count > 0 Then
            MessageBox.Show("Flow Meter already Mapped with a Machine ...!", "Janatics FMS", MessageBoxButtons.OK)
            Exit Sub
        End If

        sql = " SELECT * FROM JAN_FMS_MILL_VS_MACHINE WHERE dept='" & cmb_table_creation_dept_name.Text & "' AND MACHINE_NAME='" & txt_create_table_machine_name.Text & "' AND END_DATE IS NULL"
        ds = SQL_SELECT_mysql("data", sql)
        If ds.Tables("data").Rows.Count > 0 Then
            MessageBox.Show("Machine Name already Entered for this Department ...!", "Janatics FMS", MessageBoxButtons.OK)
            Exit Sub
        End If

        If txt_create_table_machine_name.Text = "" Or txt_flow_meter_id.Text = "" Then
            MessageBox.Show("Machine Name and Flowmeter id are Mandatory...!", "Janatics FMS", MessageBoxButtons.OK)
            Exit Sub
        Else

            sql = " insert into JAN_FMS_MILL_VS_MACHINE(CUSTOMER_ID ,dept  "

            'If txt_create_table_manufacturing_year.Text <> "" Then sql &= " ,manufacturing_year "

            If txt_create_table_machine_name.Text <> "" Then sql &= " ,MACHINE_NAME "

            sql &= " ,MACHINE_MAKE ,MACHINE_MODEL,FLOW_METER_ID ,creation_date ,last_update_date"
            If txt_Alert_recom_flow_running.Text <> "" Then sql &= " ,recommended_flow_running "
            If txt_Alert_recom_flow_idle.Text <> "" Then sql &= " ,recommended_flow_idle "
            If txt_Alert_flow_running.Text <> "" Then sql &= ",alert_flow_running "
            If txt_Alert_flow_idle.Text <> "" Then sql &= ", alert_flow_idle"
            sql &= " )"
            sql &= " values(" & customer_id & ",'" & cmb_table_creation_dept_name.Text & "'"

            'If txt_create_table_manufacturing_year.Text <> "" Then sql &= " ,'" & Trim(txt_create_table_manufacturing_year.Text) & "' "

            If txt_create_table_machine_name.Text <> "" Then sql &= " ,'" & Trim(txt_create_table_machine_name.Text) & "' "

            sql &= " ,'" & cmb_create_table_machine_make.Text & "','" & cmb_machine_model.Text & "','" & Trim(txt_flow_meter_id.Text) & "',sysdate(),sysdate() "

            If txt_Alert_recom_flow_running.Text <> "" Then sql &= " ," & CDbl(txt_Alert_recom_flow_running.Text) & " "
            If txt_Alert_recom_flow_idle.Text <> "" Then sql &= " ," & CDbl(txt_Alert_recom_flow_idle.Text) & " "
            If txt_Alert_flow_running.Text <> "" Then sql &= "," & CDbl(txt_Alert_flow_running.Text) & " "
            If txt_Alert_flow_idle.Text <> "" Then sql &= "," & CDbl(txt_Alert_flow_idle.Text) & " "

            sql &= " )"
            z = Execute_Query_mysql(sql)
            If z > 0 Then
                MessageBox.Show("Machine Detail Saved ...!", "Janatics FMS", MessageBoxButtons.OK)
                txt_create_table_machine_name.Text = ""
                txt_Alert_recom_flow_running.Text = ""
                txt_Alert_recom_flow_idle.Text = ""
                txt_Alert_flow_running.Text = ""
                txt_Alert_flow_idle.Text = ""
                txt_flow_meter_id.Text = ""
            Else
                MessageBox.Show("Machine Detail not Saved ...!", "Janatics FMS", MessageBoxButtons.OK)
            End If

        End If
    End Sub
    Private Sub btn_view_machines_Click(sender As Object, e As EventArgs) Handles btn_view_machines.Click
        display_machine_details()
    End Sub
    Private Sub display_machine_details()
        'dgv_machines_new.Columns.Clear()
        dgv_machines_new.Rows.Clear()
        sql = "select machine_name ""Machine Name"",dept ""Department"",machine_make ""Machine Make"",machine_model ""Machine Model"",flow_meter_id ""Flow Meter "" ,recommended_flow_running ""Recomd Flow Running"",recommended_flow_idle ""Recomd Flow Idle""  ,alert_flow_running ""Alert Flow Running"",alert_flow_idle ""Alert Flow Idle"" from jan_fms_mill_vs_machine where end_date is  null order by dept,machine_make,machine_model,flow_meter_id"
        sql = "select machine_name,dept ,machine_make ,machine_model ,flow_meter_id  ,recommended_flow_running,recommended_flow_idle   ,alert_flow_running ,alert_flow_idle  from jan_fms_mill_vs_machine where end_date is  null order by flow_meter_id,dept,machine_make,machine_model"
        ds = SQL_SELECT_mysql("data", sql)
        'dgv_machines_new.DataSource = ds.Tables("data")
        dgv_machines_new.Rows.Add(ds.Tables("data").Rows.Count)


        For i = 0 To ds.Tables("data").Rows.Count - 1
            With ds.Tables("data").Rows(i)
                dgv_machines_new.Rows(i).Cells(0).Value = .Item("DEPT")
                dgv_machines_new.Rows(i).Cells(1).Value = .Item("machine_make")
                dgv_machines_new.Rows(i).Cells(2).Value = .Item("machine_model")
                dgv_machines_new.Rows(i).Cells(3).Value = .Item("machine_name")
                dgv_machines_new.Rows(i).Cells(4).Value = .Item("flow_meter_id")
                dgv_machines_new.Rows(i).Cells(5).Value = .Item("recommended_flow_running")
                dgv_machines_new.Rows(i).Cells(5).Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgv_machines_new.Rows(i).Cells(6).Value = .Item("recommended_flow_idle")
                dgv_machines_new.Rows(i).Cells(6).Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgv_machines_new.Rows(i).Cells(7).Value = .Item("alert_flow_running")
                dgv_machines_new.Rows(i).Cells(7).Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgv_machines_new.Rows(i).Cells(8).Value = .Item("alert_flow_idle")
                dgv_machines_new.Rows(i).Cells(8).Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgv_machines_new.Rows(i).Cells(9).Value = "Edit"

            End With
        Next

        Panel1_add_new_machines.Visible = False
        Panel_view_machines.Visible = True
        Panel1_edit_machine_details.Visible = False
        Panel_view_machines.BringToFront()
        Panel1_add_new_machines.SendToBack()
    End Sub
    Private Sub dgv_machines_new_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_machines_new.CellClick
        If dgv_machines_new.Columns(e.ColumnIndex).HeaderText = "Edit Data" Then
            If fms_edit = 1 Then
                Try
                    txt_recomm_running_edit.Text = dgv_machines_new.CurrentRow.Cells(5).Value
                    txt_alert_running_edit.Text = dgv_machines_new.CurrentRow.Cells(7).Value
                    txt_recom_idle_edit.Text = dgv_machines_new.CurrentRow.Cells(6).Value
                    txt_alert_idle_edit.Text = dgv_machines_new.CurrentRow.Cells(8).Value
                    chk_disable_machine_detail.Checked = False
                    Panel1_edit_machine_details.Visible = True
                Catch ex As Exception

                End Try
            Else
                MessageBox.Show("Editing Option Not Enabled  ...!", "Janatics FMS", MessageBoxButtons.OK)
            End If
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_edit_machine_details.Click


        sql = "update jan_fms_mill_vs_machine set recommended_flow_running =" & CDbl(txt_recomm_running_edit.Text) & ",alert_flow_running =" & CDbl(txt_alert_running_edit.Text) & " ,recommended_flow_idle =" & CDbl(txt_recom_idle_edit.Text) & ",alert_flow_IDLE=" & CDbl(txt_alert_idle_edit.Text) & " "

        If chk_disable_machine_detail.Checked = True Then sql &= " ,end_date=sysdate() "
        sql &= " where  dept='" & dgv_machines_new.CurrentRow.Cells(0).Value & "' and machine_name='" & dgv_machines_new.CurrentRow.Cells(3).Value & "'   "

        z = Execute_Query_mysql(sql)
        If z > 0 Then
            MessageBox.Show("Machine Flow Details Updated ...!", "Janatics FMS", MessageBoxButtons.OK)
            display_machine_details()
            txt_alert_running_edit.Text = ""
            txt_recomm_running_edit.Text = ""
            Panel1_edit_machine_details.Visible = False
        Else
            MessageBox.Show("Machine Flow Details not  Updated ...!", "Janatics FMS", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btn_save_shift_detail_Click(sender As Object, e As EventArgs) Handles btn_save_shift_detail.Click


        sql = "update  jan_fms_shift_details set last_update_date=sysdate(),no_of_shift=" & CDbl(txt_no_of_shifts.Text) & "  "

        If CDbl(txt_no_of_shifts.Text) = 1 Then
            sql &= " ,shift1_start_time ='" & Format(date_time_shift1_st_time.Value, "HH:mm") & "',shift1_end_time ='" & Format(date_time_shift1_end_time.Value, "HH:mm") & "'"

            sql &= ", shift2_start_time= null ,shift2_end_time=null"

            sql &= " ,shift3_start_time=null ,shift3_end_time=null"
        End If

        If CDbl(txt_no_of_shifts.Text) = 2 Then
            sql &= " ,shift1_start_time ='" & Format(date_time_shift1_st_time.Value, "HH:mm") & "',shift1_end_time ='" & Format(date_time_shift1_end_time.Value, "HH:mm") & "'"
            sql &= ", shift2_start_time= '" & Format(date_time_shift2_st_time.Value, "HH:mm") & "' ,shift2_end_time='" & Format(date_time_shift2_end_time.Value, "HH:mm") & "'"
            sql &= " ,shift3_start_time=null ,shift3_end_time=null"
        End If

        If CDbl(txt_no_of_shifts.Text) = 3 Then
            sql &= " ,shift1_start_time ='" & Format(date_time_shift1_st_time.Value, "HH:mm") & "',shift1_end_time ='" & Format(date_time_shift1_end_time.Value, "HH:mm") & "'"
            sql &= ", shift2_start_time= '" & Format(date_time_shift2_st_time.Value, "HH:mm") & "' ,shift2_end_time='" & Format(date_time_shift2_end_time.Value, "HH:mm") & "'"

            sql &= " ,shift3_start_time='" & Format(date_time_shift3_st_time.Value, "HH:mm") & "' ,shift3_end_time='" & Format(date_time_shift3_end_time.Value, "HH:mm") & "'"
        End If

        z = Execute_Query_mysql(sql)
        If z > 0 Then
            MessageBox.Show("Shift Details Saved ...!", "Janatics FMS", MessageBoxButtons.OK)
            panel_shift_edit.Visible = False
            SHOW_Shift_detail()
        Else
            MessageBox.Show("Shift Details not Saved ...!", "Janatics FMS", MessageBoxButtons.OK)
        End If
        SHOW_Shift_detail()

    End Sub
    Private Sub txt_no_of_shifts_TextChanged(sender As Object, e As EventArgs) Handles txt_no_of_shifts.TextChanged
        If CDbl(txt_no_of_shifts.Text) = 3 Then
            lbl_shift2_start_time.Visible = True
            lbl_shift2_end_time.Visible = True

            lbl_shift3_start_time.Visible = True
            lbl_shift3_end_time.Visible = True

            date_time_shift2_st_time.Visible = True
            date_time_shift2_end_time.Visible = True
            date_time_shift3_st_time.Visible = True
            date_time_shift3_end_time.Visible = True

        ElseIf CDbl(txt_no_of_shifts.Text) = 2 Then
            lbl_shift2_start_time.Visible = True
            lbl_shift2_end_time.Visible = True
            date_time_shift2_st_time.Visible = True
            date_time_shift2_end_time.Visible = True

            lbl_shift3_start_time.Visible = False
            lbl_shift3_end_time.Visible = False
            date_time_shift3_st_time.Visible = False
            date_time_shift3_end_time.Visible = False

        ElseIf CDbl(txt_no_of_shifts.Text) = 1 Then

            lbl_shift1_start_time.Visible = True
            lbl_shift1_end_time.Visible = True
            date_time_shift1_st_time.Visible = True
            date_time_shift1_end_time.Visible = True

            lbl_shift2_start_time.Visible = False
            lbl_shift2_end_time.Visible = False

            lbl_shift3_start_time.Visible = False
            lbl_shift3_end_time.Visible = False

            date_time_shift2_st_time.Visible = False
            date_time_shift2_end_time.Visible = False
            date_time_shift3_st_time.Visible = False
            date_time_shift3_end_time.Visible = False
        End If
    End Sub
    Private Sub shift_detail_visibility()
        lbl_shift2_start_time.Visible = False
        lbl_shift2_end_time.Visible = False

        lbl_shift3_start_time.Visible = False
        lbl_shift3_end_time.Visible = False

        date_time_shift2_st_time.Visible = False
        date_time_shift2_end_time.Visible = False
        date_time_shift3_st_time.Visible = False
        date_time_shift3_end_time.Visible = False

    End Sub
    Private Sub rad_hour_CheckedChanged(sender As Object, e As EventArgs) Handles rad_hour.CheckedChanged
        If rad_hour.Checked = True Then
            'sql = " select distinct dept from jan_fms_mill_vs_machine   where   end_date is null "
            'ds = SQL_SELECT_mysql("dept", sql)
            'cmb_report_dept.DataSource = ds.Tables("dept")
            'cmb_report_dept.DisplayMember = "dept"
            'lbl_reports_shift.Visible = False
            'cmb_reports_shift.Visible = False
            chk_shift1.Visible = False
            Chk_shift2.Visible = False
            Chk_shift3.Visible = False
            Chk_all_shift.Visible = False

            lbl_report_from_time.Visible = True
            lbl_report_to_time.Visible = True
            DateTime_report_from_time.Visible = True
            DateTime_report_to_time.Visible = True
            lbl_date_report.Text = "Date :"
            'cmb_report_machine_name.Visible = True
            'Label_report_machine.Visible = True
            DateTime_report_dt.Format = DateTimePickerFormat.Custom
            DateTime_report_dt.CustomFormat = "dd-MM-yyyy"

            lbl_report_from_time.Visible = False
            DateTime_report_from_time.Visible = False
            lbl_report_to_time.Visible = False
            DateTime_report_to_time.Visible = False
        End If

    End Sub
    Private Sub rad_minute_CheckedChanged(sender As Object, e As EventArgs) Handles rad_minute.CheckedChanged
        If rad_minute.Checked = True Then
            'sql = " select distinct dept from jan_fms_mill_vs_machine   where   end_date is null "
            'ds = SQL_SELECT_mysql("dept", sql)
            'cmb_report_dept.DataSource = ds.Tables("dept")
            'cmb_report_dept.DisplayMember = "dept"

            'lbl_reports_shift.Visible = False
            'cmb_reports_shift.Visible = False
            chk_shift1.Visible = False
            Chk_shift2.Visible = False
            Chk_shift3.Visible = False
            Chk_all_shift.Visible = False

            lbl_report_from_time.Visible = True
            lbl_report_to_time.Visible = True
            DateTime_report_from_time.Visible = True
            DateTime_report_to_time.Visible = True
            'Label_report_machine.Visible = True
            'cmb_report_machine_name.Visible = True
            lbl_date_report.Text = "Date :"
            'display_report()

            DateTime_report_dt.Format = DateTimePickerFormat.Custom
            DateTime_report_dt.CustomFormat = "dd-MM-yyyy"
        End If

    End Sub

    Private Sub rad_shift_CheckedChanged(sender As Object, e As EventArgs) Handles rad_shift.CheckedChanged
        If rad_shift.Checked = True Then
            'sql = " select 'All' dept union select distinct dept from jan_fms_mill_vs_machine   where   end_date is null "
            'ds = SQL_SELECT_mysql("dept", sql)
            'cmb_report_dept.DataSource = ds.Tables("dept")
            'cmb_report_dept.DisplayMember = "dept"

            'lbl_reports_shift.Visible = True
            'cmb_reports_shift.Visible = True

            chk_shift1.Visible = True
            Chk_shift2.Visible = True
            Chk_shift3.Visible = True
            Chk_all_shift.Visible = True

            lbl_report_from_time.Visible = False
            lbl_report_to_time.Visible = False
            DateTime_report_from_time.Visible = False
            DateTime_report_to_time.Visible = False
            lbl_date_report.Text = "Date :"
            'Label_report_machine.Visible = False
            'cmb_report_machine_name.Visible = False
            'cmb_report_machine_name.Visible = True
            'Label_report_machine.Visible = True
            DateTime_report_dt.Format = DateTimePickerFormat.Custom
            DateTime_report_dt.CustomFormat = "dd-MM-yyyy"
        End If

    End Sub
    Private Sub rad_day_CheckedChanged(sender As Object, e As EventArgs) Handles rad_day.CheckedChanged
        If rad_day.Checked = True Then
            'sql = " select 'All' dept union select distinct dept from jan_fms_mill_vs_machine   where   end_date is null "
            'ds = SQL_SELECT_mysql("dept", sql)
            'cmb_report_dept.DataSource = ds.Tables("dept")
            'cmb_report_dept.DisplayMember = "dept"
            'lbl_reports_shift.Visible = True
            'cmb_reports_shift.Visible = True

            chk_shift1.Visible = False
            Chk_shift2.Visible = False
            Chk_shift3.Visible = False
            Chk_all_shift.Visible = False

            lbl_report_from_time.Visible = False
            lbl_report_to_time.Visible = False
            DateTime_report_from_time.Visible = False
            DateTime_report_to_time.Visible = False
            lbl_date_report.Text = "Month :"

            DateTime_report_dt.Format = DateTimePickerFormat.Custom
            DateTime_report_dt.CustomFormat = "MMM-yyyy"

            'display_report()
        End If

    End Sub
    Private Sub rad_month_CheckedChanged(sender As Object, e As EventArgs) Handles rad_month.CheckedChanged
        If rad_month.Checked = True Then
            'sql = " select 'All' dept union select distinct dept from jan_fms_mill_vs_machine   where   end_date is null "
            'ds = SQL_SELECT_mysql("dept", sql)
            'cmb_report_dept.DataSource = ds.Tables("dept")
            'cmb_report_dept.DisplayMember = "dept"
            lbl_report_from_time.Visible = False
            lbl_report_to_time.Visible = False
            DateTime_report_from_time.Visible = False
            DateTime_report_to_time.Visible = False
            'lbl_reports_shift.Visible = True
            'cmb_reports_shift.Visible = True

            chk_shift1.Visible = False
            Chk_shift2.Visible = False
            Chk_shift3.Visible = False
            Chk_all_shift.Visible = False

            lbl_date_report.Text = "Year :"

            DateTime_report_dt.Format = DateTimePickerFormat.Custom
            DateTime_report_dt.CustomFormat = "yyyy"
        End If
    End Sub
    Private Sub dgv_shift_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_shift.CellClick
        If dgv_shift.Columns(e.ColumnIndex).HeaderText = "Edit Data" Then
            If FMS_shift_setting = 1 Then
                panel_shift_edit.Visible = True


                Try
                    date_time_shift1_st_time.Format = DateTimePickerFormat.Custom
                    date_time_shift1_st_time.CustomFormat = "hh:mm tt"
                    Dim tim As Object = dgv_shift.CurrentRow.Cells(1).Value.ToString
                    date_time_shift1_st_time.Value = Convert.ToDateTime(tim)

                    date_time_shift1_end_time.Format = DateTimePickerFormat.Custom
                    date_time_shift1_end_time.CustomFormat = "hh:mm tt"
                    tim = dgv_shift.CurrentRow.Cells(2).Value.ToString
                    date_time_shift1_end_time.Value = Convert.ToDateTime(tim)

                    'Shift 2
                    date_time_shift2_st_time.Format = DateTimePickerFormat.Custom
                    date_time_shift2_st_time.CustomFormat = "hh:mm tt"
                    tim = dgv_shift.CurrentRow.Cells(3).Value.ToString
                    date_time_shift2_st_time.Value = Convert.ToDateTime(tim)

                    date_time_shift2_end_time.Format = DateTimePickerFormat.Custom
                    date_time_shift2_end_time.CustomFormat = "hh:mm tt"
                    tim = dgv_shift.CurrentRow.Cells(4).Value.ToString
                    date_time_shift2_end_time.Value = Convert.ToDateTime(tim)

                    'Shift 3
                    date_time_shift3_st_time.Format = DateTimePickerFormat.Custom
                    date_time_shift3_st_time.CustomFormat = "hh:mm tt"
                    tim = dgv_shift.CurrentRow.Cells(5).Value.ToString
                    date_time_shift3_st_time.Value = Convert.ToDateTime(tim)

                    date_time_shift3_end_time.Format = DateTimePickerFormat.Custom
                    date_time_shift3_end_time.CustomFormat = "hh:mm tt"
                    tim = dgv_shift.CurrentRow.Cells(6).Value.ToString
                    date_time_shift3_end_time.Value = Convert.ToDateTime(tim)
                Catch ex As Exception

                End Try
            Else
                MessageBox.Show("View Option only Enabled , Shift Editing not Enabled for your user  ...!", "Janatics FMS", MessageBoxButtons.OK)
            End If
        End If
    End Sub
    Private Sub rad_lpm_CheckedChanged(sender As Object, e As EventArgs)
        If rad_lpm.Checked = True Then
            refresh_dashboard()
        End If
    End Sub
    Private Sub rad_cfm_CheckedChanged(sender As Object, e As EventArgs)
        If rad_cfm.Checked = True Then
            refresh_dashboard()
        End If
    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        S = ""
        S &= "<html> "
        S &= " <head> "
        S &= "<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script> "
        S &= "<script type=""text/javascript""> "
        S &= " google.charts.load(""current"", {packages:[""corechart""]}); "
        S &= "google.charts.setOnLoadCallback(drawChart); "
        S &= "function drawChart() { "
        S &= " var data = google.visualization.arrayToDataTable([ "
        S &= " ['Age', 'Weight'], "
        S &= "[ 8,      12],"
        S &= " [ 4,      5.5], "
        S &= " [ 11,     14], "
        S &= "[ 4,      5], "
        S &= " [ 3,      3.5], "
        S &= " [ 6.5,    7] "
        S &= "]); "

        S &= "var options = { "
        S &= "title: 'Age vs. Weight comparison', "
        S &= " legend: 'none', "
        S &= "crosshair: { trigger: 'both', orientation: 'both' }, "
        S &= " trendlines: {"
        S &= " 0: { "
        S &= " type: 'polynomial', "
        S &= " degree: 3, "
        S &= "visibleInLegend: true, "
        S &= " } "
        S &= "  } "
        S &= " };"

        S &= " var chart = new google.visualization.ScatterChart(document.getElementById('polynomial2_div')); "
        S &= " chart.draw(data, options); "
        S &= " } "
        S &= " </script> "
        S &= "</head>"
        S &= "<body>"
        S &= "<div id='polynomial2_div' style='width: 900px; height: 600px;'></div> "
        S &= " </body>"
        'lbl_chart.Text = S
        'Exit Sub
        S = " "
        S &= "  <html>" & vbNewLine
        S &= " <head>" & vbNewLine
        S &= " <script type = ""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>" & vbNewLine
        S &= "  <script type = ""text/javascript"" >" & vbNewLine
        S &= "    google.charts.load('current', {'packages':['corechart']});" & vbNewLine
        S &= "   google.charts.setOnLoadCallback(drawChart);" & vbNewLine

        S &= "   Function drawChart() {" & vbNewLine
        S &= "  var Data = google.visualization.arrayToDataTable([" & vbNewLine
        S &= "    ['Year', 'Sales', 'Expenses']," & vbNewLine
        S &= "   ['2004',  1000,      400]," & vbNewLine
        S &= "   ['2005',  1170,      460]," & vbNewLine
        S &= "   ['2006',  660,       1120]," & vbNewLine
        S &= "   ['2007',  1030,      540]" & vbNewLine
        S &= "  ]);"

        S &= "   var options = {" & vbNewLine
        S &= "  Title: 'Company Performance'," & vbNewLine
        S &= "  curveType: 'function'," & vbNewLine
        S &= "  legend: { position: 'bottom' }" & vbNewLine
        S &= "   };" & vbNewLine

        S &= "   var chart = New google.visualization.LineChart(document.getElementById('curve_chart'));" & vbNewLine

        S &= "   chart.draw(Data, options);" & vbNewLine
        S &= "   }" & vbNewLine
        S &= "    </script>" & vbNewLine
        S &= " <meta http-equiv=""X-UA-Compatible"" content=""IE=9"" >"
        S &= "   </head>" & vbNewLine
        S &= "   <body>" & vbNewLine
        S &= "   <div id = ""curve_chart"" style=""width: 900px; height: 500px""></div>" & vbNewLine
        S &= "   </body>" & vbNewLine
        S &= "  </html>"

        'lbl_chart.Text = S
        WebBrowser_chart.DocumentText = S
        Exit Sub
        S = ""

        S &= "<html>  <head>    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>    <script type=""text/javascript"">      google.charts.load('current', {'packages':['corechart']});      google.charts.setOnLoadCallback(drawChart);"
        S &= "function drawChart() {        var data = google.visualization.arrayToDataTable( "
        S &= "[          ['Year', 'Sales', 'Expenses'],          ['2004',  1000,      400],          ['2005',  1170,      460],          ['2006',  660,       1120],          ['2007',  1030,      540]        ] "
        S &= " );  "
        S &= "var options = {          title: 'Company Performance',          curveType: 'function',          legend: { position: 'bottom' }        };"
        S &= "var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));"
        S &= "chart.draw(data, options);      }    </script>  </head>  <body>    <div id=""curve_chart"" style=""width: 900px; height: 500px""></div>  </body></html>"

        sql = "Select FLOW_METER_ID, DATEPART(HOUR, READING_TIME_1)REAd_TIME,round(avg(AIR_FLOW),2)avg_flow from jan_flow_meter_lines where FLOW_METER_ID='1Z0101' group by DATEPART(HOUR, READING_TIME_1),FLOW_METER_ID order by READ_TIME,FLOW_METER_ID"

        sql = "Select  DATEPART(MINUTE, READING_TIME_1)REAd_TIME,round(avg(case when FLOW_METER_ID='1Z0101' then  AIR_FLOW  end),2) fms_flow1,round(avg(case when FLOW_METER_ID='1Z0102' then  AIR_FLOW  end),2) fms_flow2,round(avg(case when FLOW_METER_ID='1Z0103' then  AIR_FLOW  end),2) fms_flow3 from jan_flow_meter_lines group by DATEPART(MINUTE, READING_TIME_1) order by READ_TIME"

        'ds = SQL_SELECT.sql_select_full("data", sql)

        S = ""
        S &= "<html>  <head>    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>    <script type=""text/javascript"">      google.charts.load('current', {'packages':['corechart']});      google.charts.setOnLoadCallback(drawChart);"
        S &= "function drawChart() {        var data = google.visualization.arrayToDataTable( "
        S &= "[          ['REAd_TIME', 'Flow Meter1', 'Flow Meter2'],  "
        For i = 0 To ds.Tables("data").Rows.Count - 1
            With ds.Tables("data").Rows(i)
                If i <> 0 Then S &= " , "
                S &= "         ['" & .Item("REAd_TIME") & "',  " & .Item("fms_flow1") & ",  " & .Item("fms_flow2") & "] "
            End With
        Next
        S &= " ] );  "
        S &= "var options = {          title: 'Air Flow',          curveType: 'function',          legend: { position: 'bottom' }        };"
        S &= "var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));"
        S &= "chart.draw(data, options);      }    </script>  </head>  <body>    <div id=""curve_chart"" style=""width: 1000px; height: 500px""></div>  </body></html>"

        'lbl_chart.Text = S

    End Sub ' Declare the PrintDocument object.
    Private WithEvents docToPrint As New Printing.PrintDocument
    Private Function GetCheckedNodes() As List(Of TreeNode)
        Dim result As New List(Of TreeNode)

        'Get the root nodes
        Dim nodes As New Stack(Of TreeNode)
        For Each tn As TreeNode In TreeView1.Nodes
            nodes.Push(tn)
        Next

        'Check each node and it's children
        While nodes.Count > 0
            Dim popNode As TreeNode = nodes.Pop
            If popNode.Checked Then
                result.Add(popNode)
            End If
            For Each tn As TreeNode In popNode.Nodes
                nodes.Push(tn)
            Next
        End While

        Return result
    End Function
    Private Sub btn_view_report_Click(sender As Object, e As EventArgs) Handles btn_view_report.Click
        selected_machines = "'"
        For Each tn As TreeNode In GetCheckedNodes()
            'MessageBox.Show(tn.Text)
            selected_machines += String.Concat(tn.Text, ",")
            'selected_machines += String.Concat(tn.Text, "',")
        Next
        selected_machines.Replace(",", "','")
        display_report()
        WebBrowser_report.Visible = True
        Panel_view_chart.Visible = False
    End Sub
    Private Sub btn_print_report_Click(sender As Object, e As EventArgs) Handles btn_print_report.Click
        print_report_PREVIEW()
        Dim a As New FMS_preview
        a.wb.DocumentText = S

        a.wb.ShowPrintPreviewDialog()
        a.Show()
    End Sub
    Private Sub document_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
       Handles docToPrint.PrintPage

        ' Insert code to render the page here.
        ' This code will be called when the control is drawn.

        ' The following code will render a simple
        ' message on the printed document.
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
        ("Arial", 35, System.Drawing.FontStyle.Regular)

        ' Draw the content.
        e.Graphics.DrawString(text, printFont,
        System.Drawing.Brushes.Black, 10, 10)
    End Sub
    Private Sub cmb_report_dept_SelectedIndexChanged(sender As Object, e As EventArgs)
        'sql = "select *  from jan_fms_mill_vs_machine   where   end_date is null"
        '      sql = "  SELECT 'All' machine_name ,0 flow_meter_id union
        'select machine_name,flow_meter_id  from jan_fms_mill_vs_machine  A   where   end_date is null  "
        '      If cmb_report_dept.Text <> "All" Then sql &= " and  dept='" & cmb_report_dept.Text & "'"
        '      sql &= " order by flow_meter_id"
        '      ds = SQL_SELECT_mysql("machine_detail", sql)
        '      cmb_report_machine_name.DataSource = ds.Tables("machine_detail")
        '      cmb_report_machine_name.DisplayMember = "machine_name"
        '      cmb_report_machine_name.ValueMember = "flow_meter_id"
    End Sub
    Private Sub DateTime_report_from_time_ValueChanged(sender As Object, e As EventArgs) Handles DateTime_report_from_time.ValueChanged
        DateTime_report_to_time.Value = DateTime_report_from_time.Value

    End Sub
    Private Sub DateTime_report_to_time_ValueChanged(sender As Object, e As EventArgs) Handles DateTime_report_to_time.ValueChanged
        If DateTime_report_to_time.Value < DateTime_report_from_time.Value Then
            MessageBox.Show("Select correct From & To time ", "Janatics FMS", MessageBoxButtons.OK)
            DateTime_report_to_time.Value = DateTime_report_from_time.Value
        End If
    End Sub
    Private Sub btn_create_user_role_Click(sender As Object, e As EventArgs) Handles btn_create_user_role.Click
        'sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=0"
        'ds = SQL_SELECT_mysql("user_role", sql)
        'If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
        '    sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1,1,1,1,1,SYSDATE(),SYSDATE(),0)"
        '    Execute_Query_mysql(sql)
        'End If

        'sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=1"
        'ds = SQL_SELECT_mysql("user_role", sql)
        'If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
        '    sql = " INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 1, 1, 0, SYSDATE(), SYSDATE(), 1)"
        '    Execute_Query_mysql(sql)
        'End If

        'sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=2"
        'ds = SQL_SELECT_mysql("user_role", sql)
        'If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
        '    sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 1, 0, 0, SYSDATE(), SYSDATE(), 2)"
        '    Execute_Query_mysql(sql)
        'End If

        'sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=3"
        'ds = SQL_SELECT_mysql("user_role", sql)
        'If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
        '    sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 0, 0, 0, SYSDATE(), SYSDATE(), 3)"
        '    Execute_Query_mysql(sql)
        'End If

        'MessageBox.Show("User Roles Created ", "Janatics FMS", MessageBoxButtons.OK)
    End Sub
    Private Sub CheckBox_Checked(ByVal sender As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = (TryCast(sender, CheckBox))

        'If chk.Checked Then

        '    sql = " SELECT * FROM jan_fms_mill_vs_machine WHERE DEPT='" & chk.Text & "' "
        '    ds = SQL_SELECT_mysql("DEPT_CHECK", sql)
        '    If ds.Tables("DEPT_CHECK").Rows.Count > 0 Then

        '        'sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null "
        '        'Execute_Query_mysql(sql)

        '        sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=1  where end_date is null AND DEPT='" & chk.Text & "'"
        '        Execute_Query_mysql(sql)

        '    Else
        '        'If rad_minute.Checked = True Or rad_hour.Checked = True Then
        '        '    sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null "
        '        '    Execute_Query_mysql(sql)
        '        'End If

        '        sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=1  where end_date is null AND MACHINE_NAME='" & chk.Text & "'"
        '        Execute_Query_mysql(sql)
        '    End If
        'Else


        '    sql = " SELECT * FROM jan_fms_mill_vs_machine WHERE DEPT='" & chk.Text & "' "
        '    ds = SQL_SELECT_mysql("DEPT_CHECK", sql)
        '    If ds.Tables("DEPT_CHECK").Rows.Count > 0 Then

        '        sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null AND DEPT='" & chk.Text & "'"
        '        Execute_Query_mysql(sql)

        '    Else
        '        'If rad_minute.Checked = True Or rad_hour.Checked = True Then
        '        'sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null "
        '        '    Execute_Query_mysql(sql)
        '        'End If

        '        sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null AND MACHINE_NAME='" & chk.Text & "'"
        '        Execute_Query_mysql(sql)
        '    End If

        'End If

    End Sub
    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 Then
            'sql = " Select  distinct dept from jan_fms_mill_vs_machine where end_date Is null"

            'sql = "Select * From jan_fms_mill_vs_machine Where end_date Is null And dept ='Autoconer' "


            sql = "select distinct dept  from jan_fms_mill_vs_machine   where   end_date is null "
            'If cmb_report_dept.Text <> "All" Then sql &= " and  dept='" & cmb_report_dept.Text & "'"
            sql &= " order by dept"
            ds = SQL_SELECT_mysql("dept", sql)
            cmb_dept_user_tab.DataSource = ds.Tables("dept")
            cmb_dept_user_tab.DisplayMember = "dept"
            cmb_dept_user_tab.ValueMember = "dept"

            sql = "SELECT user_role,case when user_role=0 then 'Admin' when user_role<>0 then concat('Level ',user_role) end user_level
   FROM JAN_FMS_USER_ROLE where  user_role>=0 order by user_role "

            ds = SQL_SELECT_mysql("user_level", sql)
            cmb_user_role_user_tab.DataSource = ds.Tables("user_level")
            cmb_user_role_user_tab.DisplayMember = "user_level"
            cmb_user_role_user_tab.ValueMember = "user_role"

            display_user_list()

            dgv_user_role.Rows.Clear()

            sql = "SELECT case when user_role=0 then 'Admin' when user_role<>0 then concat('Level ',user_role) end user_Role
,case when view_option=1 then 'Yes' else '' end view_option,case when edit_option=1 then 'Yes' else '' end Edit_option
,case when delete_option=1 then 'Yes' else '' end delete_option,case when shift_setting_option=1 then 'Yes' else '' end shift_setting
   FROM JAN_FMS_USER_ROLE  where  user_role>=0  order by user_role"
            ds = SQL_SELECT_mysql("user_role", sql)
            dgv_user_role.Rows.Add(ds.Tables("user_role").Rows.Count)
            For i = 0 To ds.Tables("user_role").Rows.Count - 1
                With ds.Tables("user_role").Rows(i)
                    dgv_user_role.Rows(i).Cells(0).Value = .Item("user_Role")
                    dgv_user_role.Rows(i).Cells(1).Value = .Item("view_option")
                    dgv_user_role.Rows(i).Cells(2).Value = .Item("Edit_option")
                    dgv_user_role.Rows(i).Cells(3).Value = .Item("delete_option")
                    dgv_user_role.Rows(i).Cells(4).Value = .Item("shift_setting")
                    'dgv_user_role.Rows(i).Cells(5).Value = "Edit"
                End With
            Next
        ElseIf TabControl2.SelectedIndex = 2 Then
            sql = " select * from jan_fms_shift_details"
            ds = SQL_SELECT_mysql("shift_det", sql)
            If ds.Tables("shift_det").Rows.Count > 0 Then
                With ds.Tables("shift_det").Rows(0)
                    If .Item("dashboard_view_by").ToString = "Machine" Then rad_dashboard_sorting_machine.Checked = True Else rad_dashboard_sorting_flow.Checked = True
                    If .Item("flow_unit").ToString = "LPM" Then rad_lpm.Checked = True Else rad_cfm.Checked = True
                    If .Item("company_logo_or_text").ToString = "Logo" Then
                        rad_logo_image.Checked = True
                        Panel_company_logo_image.Visible = True
                        Panel_company_logo.Visible = False
                        Txt_company_logo_image.Text = .Item("companY_logo_FILE_NAME")


                    Else
                        rad_logo_text.Checked = True
                        Panel_company_logo.Visible = True
                        txt_complany_logo_text.Text = .Item("companY_logo_text")

                    End If
                End With
            End If

        Else
                Panel_add_user.Visible = False
            clear_user_detail()
        End If
    End Sub
    Private Sub display_user_list()
        dgv_user.Rows.Clear()

        sql = "SELECT (SELECT case when user_role=0 then 'Admin' when user_role<>0 then concat('Level ',user_role) end user_level
   FROM JAN_FMS_USER_ROLE where user_role=a.user_role)user_rl,a.* FROM JAN_FMS_USER_MASTER a where  user_role>=0 AND END_DATE IS NULL order by user_role"
        ds = SQL_SELECT_mysql("user_list", sql)
        dgv_user.Rows.Add(ds.Tables("user_list").Rows.Count)
        For i = 0 To ds.Tables("user_list").Rows.Count - 1
            With ds.Tables("user_list").Rows(i)
                dgv_user.Rows(i).Cells(0).Value = .Item("user_name")
                dgv_user.Rows(i).Cells(1).Value = .Item("user_rl")
                dgv_user.Rows(i).Cells(2).Value = .Item("department")
                dgv_user.Rows(i).Cells(3).Value = .Item("user_id")
                dgv_user.Rows(i).Cells(4).Value = .Item("email")
                dgv_user.Rows(i).Cells(5).Value = .Item("phone_no")
                dgv_user.Rows(i).Cells(6).Value = "Edit"
            End With
        Next
        With dgv_user
            .Columns(1).Width = 60
            .Columns(4).Width = 190
        End With
    End Sub
    Private Sub btn_save_user_detail_Click(sender As Object, e As EventArgs) Handles btn_save_user_detail.Click

        If user_edit = 1 Then

            sql = "select * from JAN_FMS_USER_MASTER where  ucase(user_ID)='" & UCase(Trim(txt_user_id.Text)) & "' and end_date is null"
            ds = SQL_SELECT_mysql("user_list", sql)

            If ds.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("User Id Already Added ", "Janatics AFMS", MessageBoxButtons.OK)
                Exit Sub
            End If
            If Txt_user_name.Text = "" Or txt_email_id.Text = "" Or txt_user_id.Text = "" Or txt_pwd.Text = "" Then
                MessageBox.Show("Please enter all details and save ..", "Janatics AFMS", MessageBoxButtons.OK)
                Exit Sub
            Else
                sql = "insert into JAN_FMS_USER_MASTER (customer_id,user_name,user_id,p_key,email,phone_no,user_role,department,creation_date,lat_update_date) values((SELECT distinct customer_id FROM JAN_FMS_customer_MASTER),'" & Trim(Txt_user_name.Text).ToString.Replace("'", "''") & "','" & Trim(txt_user_id.Text).ToString.Replace("'", "''") & "','" & Trim(txt_pwd.Text).ToString.Replace("'", "''") & "','" & Trim(txt_email_id.Text).ToString.Replace("'", "''") & "','" & Trim(txt_phone_no.Text).ToString.Replace("'", "''") & "'," & cmb_user_role_user_tab.SelectedValue & ",'" & cmb_dept_user_tab.Text & "',sysdate(),sysdate())"
                z = Execute_Query_mysql(sql)

                If z > 0 Then
                    MessageBox.Show("User Detail saved ", "Janatics FMS", MessageBoxButtons.OK)
                    clear_user_detail()
                    Panel_add_user.Visible = False
                    display_user_list()
                End If
            End If


        ElseIf user_edit = 2 Then
            sql = "update JAN_FMS_USER_MASTER set user_name='" & Trim(Txt_user_name.Text).ToString.Replace("'", "''") & "' ,user_role=" & cmb_user_role_user_tab.SelectedValue & ",department='" & cmb_dept_user_tab.Text & "',user_id='" & Trim(txt_user_id.Text).ToString.Replace("'", "''") & "',email='" & Trim(txt_email_id.Text).ToString.Replace("'", "''") & "',phone_no='" & Trim(txt_phone_no.Text).ToString.Replace("'", "''") & "',lat_update_date=sysdate() "

            If FMS_USER_ID <> Trim(txt_user_id.Text).ToString.Replace("'", "''") Then
                If chk_user_end_date.Checked = True Then sql &= " ,end_date=sysdate() "
            Else
                MessageBox.Show("You can't delete your own user id ", "Janatics FMS", MessageBoxButtons.OK)
                Exit Sub
            End If

            sql &= " where user_name='" & Trim(Txt_user_name.Text).ToString.Replace("'", "''") & "' and end_date is null"
            z = Execute_Query_mysql(sql)
        End If


        If z > 0 Then
            MessageBox.Show("User Detail saved ", "Janatics FMS", MessageBoxButtons.OK)
            clear_user_detail()
            Panel_add_user.Visible = False
            display_user_list()
        End If

    End Sub
    Private Sub clear_user_detail()
        Txt_user_name.Text = ""
        txt_user_id.Text = ""
        txt_pwd.Text = ""
        txt_email_id.Text = ""
        txt_phone_no.Text = ""
    End Sub
    Private Sub btn_add_user_Click(sender As Object, e As EventArgs) Handles btn_add_user.Click
        If fms_edit = 1 Then
            Panel_add_user.Visible = True
            user_edit = 1
            clear_user_detail()
        Else
            MessageBox.Show("Editing Option Not Enabled for you User", "Janatics FMS", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btn_cancel_user_addition_Click(sender As Object, e As EventArgs) Handles btn_cancel_user_addition.Click
        Panel_add_user.Visible = False
    End Sub
    Private Sub dgv_user_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_user.CellContentClick

    End Sub

    Private Sub dgv_user_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_user.CellClick
        If dgv_user.Columns(e.ColumnIndex).HeaderText = "Edit Data" Then
            user_edit = 2
            clear_user_detail()

            If fms_edit = 1 Then

                Try
                    'txt_recomm_running_edit.Text = dgv_machines_new.CurrentRow.Cells(5).Value
                    'txt_alert_running_edit.Text = dgv_machines_new.CurrentRow.Cells(7).Value
                    'txt_recom_idle_edit.Text = dgv_machines_new.CurrentRow.Cells(6).Value
                    'txt_alert_idle_edit.Text = dgv_machines_new.CurrentRow.Cells(8).Value
                    'Txt_user_name.Text
                    Txt_user_name.Text = dgv_user.CurrentRow.Cells(0).Value
                    cmb_user_role_user_tab.Text = dgv_user.CurrentRow.Cells(1).Value
                    cmb_dept_user_tab.Text = dgv_user.CurrentRow.Cells(2).Value
                    txt_user_id.Text = dgv_user.CurrentRow.Cells(3).Value
                    txt_email_id.Text = dgv_user.CurrentRow.Cells(4).Value
                    txt_phone_no.Text = dgv_user.CurrentRow.Cells(5).Value
                    Panel_add_user.Visible = True
                Catch ex As Exception

                End Try
            Else
                MessageBox.Show("Editing Option Not Enabled for you User", "Janatics FMS", MessageBoxButtons.OK)
            End If
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then
            Timer1.Start()
        ElseIf TabControl1.SelectedIndex = 2 Then
            dms_con.Close()
            Timer1.Stop()
            UPDATE_MACHINE_LIST()
            'sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null "
            'Execute_Query_mysql(sql)

            'sql = "Select  distinct dept from jan_fms_mill_vs_machine where end_date Is null"
            'ds1 = SQL_SELECT_mysql("dept", sql)
            'Dim offset As Integer = 10

            'TreeView1.Nodes.Clear()
            'TreeView1.CheckBoxes = True
            'chek_count = 0
            'For j = 0 To ds1.Tables("dept").Rows.Count - 1
            '    TreeView1.Nodes.Add(ds1.Tables("dept").Rows(j).Item("dept").ToString)

            '    sql = "Select * From jan_fms_mill_vs_machine Where end_date Is null and  dept='" & ds1.Tables("dept").Rows(j).Item("dept") & "'"
            '    ds = SQL_SELECT_mysql("res", sql)

            '    For i = 0 To ds.Tables("res").Rows.Count - 1
            '        With ds.Tables("res")
            '            TreeView1.Nodes(j).Nodes.Add(.Rows(i).Item("machine_name").ToString)

            '        End With
            '    Next
            'Next
        Else
            Timer1.Stop()
            dms_con.Close()
        End If

    End Sub
    Private Sub Link_logout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_logout.LinkClicked
        Me.Hide()
        Timer1.Stop()
        FMS_Login.Show()

    End Sub
    Private Sub BTN_VIEW_ROLES_Click(sender As Object, e As EventArgs) Handles BTN_VIEW_ROLES.Click
        Panel_view_user_role.Visible = True
    End Sub
    Private Sub btn_user_role_visibility_Click(sender As Object, e As EventArgs) Handles btn_user_role_visibility.Click
        Panel_view_user_role.Visible = False
    End Sub
    Private Sub draw_chart()
        S = ""
        S &= "<!DOCTYPE HTML>" & vbNewLine
        S &= "<html>" & vbNewLine
        S &= "<head>  " & vbNewLine
        S &= "<script>" & vbNewLine
        S &= "window.onload = function () {" & vbNewLine

        S &= "var chart = new CanvasJS.Chart(""chartContainer"", { " & vbNewLine
        If rad_hour.Checked = True Then

            S &= "  title:{ " & vbNewLine
            S &= " text: ""Hour-Wise Chart"" " & vbNewLine
            S &= " }," & vbNewLine

            S &= " axisX:{ " & vbNewLine
            S &= "title: ""time""," & vbNewLine
            S &= " gridThickness: 2," & vbNewLine
            S &= " interval:2, " & vbNewLine
            S &= "  intervalType: ""hour"",   " & vbNewLine
            S &= " valueFormatString: ""hh TT"", " & vbNewLine
            S &= " labelAngle: -20" & vbNewLine
            S &= "}," & vbNewLine
            S &= " axisY:{" & vbNewLine
            S &= " title: ""Flow value""" & vbNewLine
            S &= " }," & vbNewLine
            S &= " data: [" & vbNewLine
            S &= " {    " & vbNewLine
            S &= " type: ""line""," & vbNewLine
            S &= " dataPoints: [//array " & vbNewLine
            For i = 0 To ds2.Tables("report").Rows.Count - 2
                With ds2.Tables("REPORT").Rows(i)

                    S &= "	{ x: new Date(Date.UTC (" & Format(.Item("date"), "yyyy") & "," & Format(.Item("date"), "MM") - 1 & ",1," & i + 3 & ",0) ), y: " & .Item("FLOW_value") & " }," & vbNewLine

                End With
            Next
            ''S &= " {x: new Date(Date.UTC (2012, 01, 1, 0,0) ), y: 26 }," & vbNewLine
            ''S &= "  {x: new Date( Date.UTC (2012, 01, 1,2,0) ), y: 38  }," & vbNewLine
            ''S &= "  {x: new Date( Date.UTC(2012, 01, 1,3,0) ), y: 43 }," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,4,0) ), y: 29}," & vbNewLine
            ''S &= "{x: new Date( Date.UTC(2012, 01, 1,5,0) ), y: 41}," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,6,0) ), y: 54}," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,7,0) ), y: 66}," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,8,0) ), y: 60}," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,9,0) ), y: 53}," & vbNewLine
            ''S &= " {x: new Date( Date.UTC(2012, 01, 1,10,0) ), y: 60}" & vbNewLine
            S &= " ]" & vbNewLine
            S &= " }" & vbNewLine
            S &= " ]" & vbNewLine
            S &= " });" & vbNewLine

            S &= "chart.render();" & vbNewLine
            S &= "}" & vbNewLine
            S &= "</script>" & vbNewLine
            'S &= "<script type=""text/javascript"" src=""https://canvasjs.com/assets/script/canvasjs.min.js""></script>" & vbNewLine
            S &= "<script src = ""D:/COMpany_logo/canvasjs.min.js"" ></script>" & vbNewLine
            S &= "</head> " & vbNewLine
            S &= "<body>" & vbNewLine
            S &= " <div id=""chartContainer"" style=""height: 300px; width: 100%;"">" & vbNewLine
            S &= " </div>" & vbNewLine
            S &= "</body>" & vbNewLine
            S &= "</html>"

        ElseIf rad_day.Checked = True Then


            S &= "animationEnabled:  true," & vbNewLine
            S &= "theme: ""light2""," & vbNewLine
            S &= "title:{" & vbNewLine
            S &= "text: ""Chart""" & vbNewLine
            S &= "}," & vbNewLine
            S &= "toolTip: { " & vbNewLine
            S &= "shared:  true" & vbNewLine
            S &= "}," & vbNewLine
            S &= "legend: { " & vbNewLine
            S &= "cursor: ""pointer"", " & vbNewLine
            S &= "verticalAlign: ""top"", " & vbNewLine
            S &= "horizontalAlign: ""center"", " & vbNewLine
            S &= "dockInsidePlotArea: true," & vbNewLine
            S &= "itemclick: toogleDataSeries" & vbNewLine
            S &= "}," & vbNewLine
            S &= " axisX: {
		valueFormatString: ""DD MMM YYYY""
	},"
            S &= "data: [   " & vbNewLine
            Dim distinctDT As DataTable = SelectDistinct(ds2.Tables("report"), "machine_name")
            For j = 0 To distinctDT.Rows.Count - 1
                If Not IsDBNull(distinctDT.Rows(j).Item("mACHINE_NAME")) Then
                    S &= "{  " & vbNewLine
                    S &= " type: ""line""," & vbNewLine
                    S &= "axisYType: ""secondary""," & vbNewLine
                    S &= "name: """ & distinctDT.Rows(j).Item("mACHINE_NAME") & """," & vbNewLine
                    S &= "showInLegend: true," & vbNewLine
                    S &= "markerSize: 0," & vbNewLine
                    S &= "dataPoints: [" & vbNewLine

                    For i = 0 To ds2.Tables("report").Rows.Count - 2
                        With ds2.Tables("REPORT").Rows(i)
                            If .Item("MACHINE_NAME") = distinctDT.Rows(j).Item("mACHINE_NAME") Then
                                S &= "	{ x: new Date(" & Format(.Item("date"), "yyyy") & "," & Format(.Item("date"), "MM") - 1 & "," & Format(.Item("date"), "dd") & "), y: " & .Item("total_RUNNING_value") & " }," & vbNewLine
                            End If

                        End With
                    Next

                    S &= "]" & vbNewLine
                    S &= "}," & vbNewLine
                End If
            Next

            S &= "]" & vbNewLine
            S &= "});" & vbNewLine
            S &= "chart.render();" & vbNewLine

            S &= " chart.render();
            endif
function toogleDataSeries(e){
	if (typeof(e.dataSeries.visible) === ""undefined"" || e.dataSeries.visible) {
		e.dataSeries.visible = false;
	} else{
		e.dataSeries.visible = true;
	}
	chart.render();
}" & vbNewLine
            S &= "}" & vbNewLine
            S &= "</script>" & vbNewLine
            S &= "</head>" & vbNewLine
            S &= "<body>" & vbNewLine
            S &= "<div id = ""chartContainer"" style=""height: 300px; width: 100%;""></div>" & vbNewLine
            S &= "<script src = ""D:/COMpany_logo/canvasjs.min.js"" ></script>" & vbNewLine
            'S &= "<script src=""https://canvasjs.com/assets/script/canvasjs.min.js""></script>" & vbNewLine
            S &= "  </body>" & vbNewLine
            S &= "</html>"

        End If
        Dim FSTRM As New FileStream("D:\fms.html", FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
        System.Diagnostics.Process.Start("D:\fms.html")
    End Sub
    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        Try
            Return (A.Equals(B))

        Catch ex As Exception

        End Try
        If A = DBNull.Value AndAlso B = DBNull.Value Then Return True
        If A = DBNull.Value OrElse B = DBNull.Value Then Return False
    End Function
    Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal FieldName As String) As DataTable
        Try


            Dim dt As DataTable = New DataTable(SourceTable.TableName)
            dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
            Dim LastValue As Object = Nothing

            For Each dr As DataRow In SourceTable.[Select]("", FieldName)

                If LastValue Is Nothing OrElse Not (ColumnEqual(LastValue, dr(FieldName))) Then
                    LastValue = dr(FieldName)
                    dt.Rows.Add(New Object() {LastValue})
                End If
            Next

            Return dt
        Catch ex As Exception

        End Try
    End Function

    Private Sub btn_chart_Click(sender As Object, e As EventArgs) Handles btn_chart.Click
        draw_chart()
        'WebBrowser_report.Visible = False
        'Panel_view_chart.Visible = True
    End Sub
    Private Sub btn_upload_user_logo_Click(sender As Object, e As EventArgs) Handles btn_upload_user_logo.Click

        sql = "update jan_fms_shift_details  set dashboard_view_by ="
        If rad_dashboard_sorting_machine.Checked = True Then sql &= "'Machine' " Else sql &= "'Flow Value' "
        sql &= " ,flow_unit= "
        If rad_cfm.Checked = True Then sql &= " 'CFM'" Else sql &= " 'LPM'"
        sql &= " ,COMPANY_LOGO_OR_TEXT = "

        If rad_logo_image.Checked = True Then
            If Txt_company_logo_image.Text = "" Then
                MessageBox.Show("Select Company Logo  then update ...", "Janatics AFMS", MessageBoxButtons.OK)
                Exit Sub
            End If
            sql &= "'Logo' ,COMPANY_LOGO_file_name ='" & Txt_company_logo_image.Text.Replace("'", "''") & "'"
            Execute_Query_mysql(sql)
            save_company_logo()
            MessageBox.Show("Company Logo updated", "Janatics AFMS", MessageBoxButtons.OK)

        ElseIf rad_logo_text.Checked = True Then

            If txt_complany_logo_text.Text = "" Then
                MessageBox.Show("Enter Company Logo text then update ...", "Janatics AFMS", MessageBoxButtons.OK)
                Exit Sub
            End If
            sql &= "'Text' ,COMPANY_LOGO_TEXT='" & txt_complany_logo_text.Text.Replace("'", "''") & "' "
            Execute_Query_mysql(sql)
            MessageBox.Show("Company Text updated", "Janatics AFMS", MessageBoxButtons.OK)
        End If

        txt_complany_logo_text.Text = ""
        Txt_company_logo_image.Text = ""



    End Sub
    Private Sub save_company_logo()


        '       String fileLocation = OpenFileDialog1.FileName;  
        'File.Copy(fileLocation, Path.Combine("C:\Users\admin\source\repos\Software of TE\Software of TE\Images\", Path.GetFileName(fileLocation)), True); 

        Dim strBasePath As String
        Dim strFilePath As String
        Dim strFileName As String

        strFileName = FILE_NAME
        'strBasePath = Application.StartupPath & "\company_logo"
        strBasePath = "d:\company_logo"
        ' >> Check if Folder Exists 
        If Directory.Exists(strBasePath) = False Then
            Call Directory.CreateDirectory(strBasePath)
        End If
        strBasePath = strBasePath & "\ " & Txt_company_logo_image.Text & ""
        ' >> Save Picture 
        'File.Copy(strFileName, "D:\")
        My.Computer.FileSystem.CopyFile(strFileName, strBasePath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        'File.Copy(strFileName, strBasePath & "\" & txt_complany_logo_text.Text & "")

        '        String source = openFileDialog1.FileName;
        'String dest = @"C:\Users\admin\source\repos\Software of TE\Software of TE\Images\" + Path.GetFileName(source);
        'File.Copy(source, dest;
        'X = "d:\MAILER\" & FILE_NAME & ".html"
        'X = "d:\" & file_name & ".xls"
        'Dim FSTRM As New FileStream(strBasePath, FileMode.Create, FileAccess.Write)
        'Dim SW As StreamWriter = New StreamWriter(FSTRM)

        'SW = New StreamWriter(FSTRM)
        'SW.Write(S)
        'FSTRM.Flush()
        'SW.Flush()
        'SW.Close()
        'FSTRM.Close()
        'File.Copy(strFileName, strBasePath & "\" & txt_complany_logo_text.Text & "")

        'Call PictureBox1.Image.Save(strBasePath & "\" & strFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub
    Private Sub FMS_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub
    Private Sub rad_logo_text_CheckedChanged(sender As Object, e As EventArgs) Handles rad_logo_text.CheckedChanged
        If rad_logo_text.Checked = True Then
            Panel_company_logo.Visible = True
            Panel_company_logo_image.Visible = False
        Else
            Panel_company_logo.Visible = False
        End If
    End Sub
    Private Sub rad_logo_image_CheckedChanged(sender As Object, e As EventArgs) Handles rad_logo_image.CheckedChanged
        If rad_logo_image.Checked = True Then
            Panel_company_logo.Visible = False
            Panel_company_logo_image.Visible = True
        Else
            Panel_company_logo.Visible = True
            Panel_company_logo_image.Visible = False
        End If
    End Sub

    Private Sub Txt_company_logo_image_Click(sender As Object, e As EventArgs) Handles Txt_company_logo_image.Click
        FILE_NAME = ""
        open_dialogue.ShowDialog()
        FILE_NAME = open_dialogue.FileName
        Txt_company_logo_image.Text = FILE_NAME.Substring(InStrRev(FILE_NAME, "\"))
    End Sub

    Private Sub Chk_all_shift_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_all_shift.CheckedChanged
        chk_shift1.Visible = True
        Chk_shift2.Visible = True
        Chk_shift3.Visible = True
        Chk_all_shift.Visible = True
    End Sub

    ' NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
    ' After a tree node's Checked property is changed, all its child nodes are updated to the same value.
    Private Sub node_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        ' The code only executes if the user caused the checked state to change.
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                ' Calls the CheckAllChildNodes method, passing in the current 
                ' Checked value of the TreeNode whose checked state changed. 
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
                If e.Node.Checked = True Then
                    sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=1  where end_date Is null And DEPT='" & e.Node.Text & "' "
                    Execute_Query_mysql(sql)
                Else
                    sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null and DEPT='" & e.Node.Text & "' "
                    Execute_Query_mysql(sql)
                End If
                'sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null and dept='" & e.Node & "' "
                'Execute_Query_mysql(sql)
            Else
                If e.Node.Checked = True Then
                    sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=1  where end_date is null AND DEPT ='" & e.Node.Parent.Text & "' and machine_name='" & e.Node.Text & "' "
                    Execute_Query_mysql(sql)
                Else
                    sql = " UPDATE jan_fms_mill_vs_machine SET VIEW_REPORT=0  where end_date is null AND DEPT ='" & e.Node.Parent.Text & "' and machine_name='" & e.Node.Text & "' "
                    Execute_Query_mysql(sql)
                End If

            End If
        End If
    End Sub
    Private Sub draw_morris_chart()

        Dim str_script As String

        Dim strCaption As String = "Effectiveness"
        'Dim strSubCaption As String = ddl_yr.SelectedItem.Text
        'Label8.Text = strCaption & "<br/>" & strSubCaption

        str_script = " <script>"


        str_script &= " $.getScript('Morris/JavaScript.js',function(){"
        str_script &= " $.getScript('Morris/JavaScript2.js',function(){"

        str_script &= " Morris.Line({"
        str_script &= " element:'line-example',"
        str_script &= "  data: ["

        Dim kk, no_of_rows As Integer
        no_of_rows = ds2.Tables("report").Rows.Count - 1
        For kk = 0 To ds2.Tables("report").Columns.Count - 2

            If Not IsDBNull(ds2.Tables("report").Rows(no_of_rows).Item(kk)) Then

                str_script &= "{Category:'" & ds2.Tables("report").Columns(kk).ColumnName.ToString().Trim() & "', nb:" & ds2.Tables("report").Rows(no_of_rows).Item(kk) & "},"

            End If
        Next

        str_script &= "  ],"


        str_script &= " xkey: ['Category'],"
        str_script &= " ykeys: ['nb'],"
        str_script &= " labels: ['rating'],"
        str_script &= " parseTime: false,"
        str_script &= " eventStrokeWidth: 0,"
        str_script &= " ymin: 1,ymax:100,"
        str_script &= "grid:true,"
        'str_script &= "axes:true,"
        'str_script &= "resize:true,"
        'str_script &= "lineColors:#f32ff7,"
        str_script &= " yLabelFormat: function(y) { return y = Math.round(y);}"
        'str_script &= ".flex1 {  flex: 1;  border: 1px solid red;}"

        str_script &= " });"


        str_script &= " });"
        str_script &= " });"
        str_script &= "  </script>"
        WebBrowser1.DocumentText = str_script

        'Label38.Text = str_script
        'Me.Controls.Add(New LiteralControl(str_script))


    End Sub
    Private Sub SHIFT_DATA_FREEZING()

        sql = "Select  DATE_ADD(MAX(FLOW_DATE), INTERVAL - 2 DAY) MAX_DATE_2,MAX(FLOW_DATE)DT from JAN_FLOW_SHIFT_DATA"
        ds = SQL_SELECT_mysql("FLOW_DATA", sql)

        sql = "DELETE From JAN_FLOW_SHIFT_DATA Where FLOW_DATE >='" & Format(ds.Tables("FLOW_DATA").Rows(0).Item("MAX_DATE_2"), "yyyy-MM-dd") & "' "
        z = Execute_Query_mysql(sql)

        sql = "SELECT SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,ROUND(AVG(FLOW_VALUE),3)AVG_VALUE,DIGITAL_INPUT FROM (
SELECT B.*,CASE WHEN shift_no =3 THEN date_add(b.date,interval -1 day ) WHEN shift_no =2  and time_format(time,'%H:%i') between '00:00' and '00:30' THEN date_add(b.date,interval -1 day )  ELSE DATE END SHIFT_DATE FROM (
SELECT A.*,(SELECT  case when a.time between shift1_start_time and shift1_end_time then 1
          when a.time between shift3_start_time and shift3_end_time then 3 else 2 end  FROM janatics.jan_fms_shift_details)shift_no
         
          FROM FLOW_METER A 
          WHERE concat(date, ' ', time)>='" & Format(ds.Tables("FLOW_DATA").Rows(0).Item("MAX_DATE_2"), "yyyy-MM-dd") & " 08:00:00') B )C GROUP BY SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,DIGITAL_INPUT"
        ds = SQL_SELECT_mysql("SHIFT", sql)

        'SLAVE_ID VARCHAR(5), GROUP_ID VARCHAR(5),AVG_FLOW_VALUE VARCHAR(10),DIGITAL_INPUT VARCHAR(5),FLOW_DATE DATE,SHIFT1_VALUE VARCHAR(10),SHIFT2_VALUE VARCHAR(10),SHIFT3_VALUE VARCHAR(10),SHIFT_NO
        For i = 0 To ds.Tables("SHIFT").Rows.Count - 1
            With ds.Tables("SHIFT").Rows(i)
                sql = " INSERT INTO JAN_FLOW_SHIFT_DATA(SLAVE_ID,GROUP_ID,AVG_FLOW_VALUE,DIGITAL_INPUT,FLOW_DATE,SHIFT_NO) VALUES('" & .Item("SLAVE_ID") & "','" & .Item("GROUP_ID") & "','" & .Item("AVG_VALUE") & "','" & .Item("DIGITAL_INPUT") & "','" & Format(.Item("SHIFT_DATE"), "yyyy-MM-dd") & "'," & .Item("SHIFT_NO") & ")"
                z = Execute_Query_mysql(sql)
            End With
        Next
    End Sub

    Private Sub minute_DATA_FREEZING()

        'sql = "Select  DATE_ADD(MAX(FLOW_DATE), INTERVAL - 2 DAY) MAX_DATE_2,MAX(FLOW_DATE)DT from JAN_FLOW_minute_DATA"
        'ds = SQL_SELECT_mysql("FLOW_DATA", sql)

        'sql = "DELETE From JAN_FLOW_minute_DATA Where FLOW_DATE >='" & Format(ds.Tables("FLOW_DATA").Rows(0).Item("MAX_DATE_2"), "yyyy-MM-dd") & "' "
        'z = Execute_Query_mysql(sql)
        Try


            sql = " select a.*,LPAD((select max(minute_no) from JAN_FLOW_minute_DATA where flow_date=a.flow_date and hour_no=a.hour_no)-2,2,'0') minute_no
 from ( select  max(FLOW_DATE)FLOW_DATE,max(hour_no) hour_no  from JAN_FLOW_minute_DATA   WHERE   FLOW_DATE=(select  max(FLOW_DATE)max_date from JAN_FLOW_minute_DATA))a "
            ds = SQL_SELECT_mysql("data", sql)

            With ds.Tables("data").Rows(0)

                sql = " delete from JAN_FLOW_minute_DATA where FLOW_date='" & Format(.Item("FLOW_DATE"), "yyyy-MM-dd") & "' and    hour_no='" & .Item("hour_no") & "' and minute_no>='" & .Item("minute_no") & "' "
                z = Execute_Query_mysql(sql)

                sql = "SELECT HR,minutes,SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,ROUND(AVG(FLOW_VALUE),3)AVG_VALUE,DIGITAL_INPUT FROM (
SELECT B.* , " 'CASE WHEN shift_no =3 THEN date_add(b.date,interval -1 day ) WHEN shift_no =2  and time_format(time,'%H:%i') between '00:00' and '00:30' THEN date_add(b.date,interval -1 day )  ELSE DATE END 
                sql &= " DATE SHIFT_DATE FROM (
SELECT A.*,(SELECT  case when a.time between shift1_start_time and shift1_end_time then 1
          when a.time between shift3_start_time and shift3_end_time then 3 else 2 end  FROM janatics.jan_fms_shift_details)shift_no,time_format(time,'%i')minutes,time_format(time,'%H')HR
         
          FROM FLOW_METER A where concat(date, ' ', time)>='2021-01-01 08:00:00' AND  concat(date, ' ', time)<'2021-01-05 08:00:00' "
                'concat(date, ' ', time)>='" & Format(.Item("FLOW_DATE"), "yyyy-MM-dd") & " " & .Item("hour_no") & ":" & .Item("minute_no") & ":00'" 'date>'2021-03-12 08:00:00' "
                'WHERE concat(date, ' ', time)>='" & Format(ds.Tables("FLOW_DATA").Rows(0).Item("MAX_DATE_2"), "yyyy-MM-dd") & " 08:00:00'"
                sql &= " ) B )C GROUP BY SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,DIGITAL_INPUT,minutes,HR"
                ds = SQL_SELECT_mysql("SHIFT", sql)
            End With
        Catch ex As Exception

        End Try
        sql = "SELECT HR,minutes,SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,ROUND(AVG(FLOW_VALUE),3)AVG_VALUE,DIGITAL_INPUT FROM (
        SELECT B.* "
        'sql &= ",CASE WHEN shift_no =3 THEN date_add(b.date,interval -1 day ) WHEN shift_no =2  and time_format(time,'%H:%i') between '00:00' and '00:30' THEN date_add(b.date,interval -1 day )  ELSE DATE END SHIFT_DATE "
        sql &= ", DATE SHIFT_DATE FROM (
        SELECT A.*,(SELECT  case when a.time between shift1_start_time and shift1_end_time then 1
                  when a.time between shift3_start_time and shift3_end_time then 3 else 2 end  FROM janatics.jan_fms_shift_details)shift_no,time_format(time,'%i')minutes,time_format(time,'%H')HR

                  FROM FLOW_METER A where concat(date, ' ', time)>='2021-01-01 08:00:00'  AND  concat(date, ' ', time)<'2021-01-02 08:00:00' "
        'WHERE concat(date, ' ', time)>='" & Format(ds.Tables("FLOW_DATA").Rows(0).Item("MAX_DATE_2"), "yyyy-MM-dd") & " 08:00:00'"
        sql &= " ) B )C GROUP BY SLAVE_ID,GROUP_ID, SHIFT_DATE,shift_no,DIGITAL_INPUT,minutes,HR"
        ds = SQL_SELECT_mysql("SHIFT", sql)

        For i = 0 To ds.Tables("SHIFT").Rows.Count - 1
            With ds.Tables("SHIFT").Rows(i)
                sql = " INSERT INTO JAN_FLOW_minute_DATA(SLAVE_ID,GROUP_ID,AVG_FLOW_VALUE,DIGITAL_INPUT,FLOW_DATE,SHIFT_NO,minute_no,HOUR_NO) VALUES('" & .Item("SLAVE_ID") & "','" & .Item("GROUP_ID") & "','" & .Item("AVG_VALUE") & "','" & .Item("DIGITAL_INPUT") & "','" & Format(.Item("SHIFT_DATE"), "yyyy-MM-dd") & "'," & .Item("SHIFT_NO") & ",'" & .Item("minutes") & "','" & .Item("HR") & "')"
                z = Execute_Query_mysql(sql)
            End With
        Next
        sql = " update jan_fms_shift_details set MINUTE_DATA_FREEZE_TIME=NOW() "
        z = Execute_Query_mysql(sql)

    End Sub

End Class

Friend Class List
End Class
