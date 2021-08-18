Public Class FMS_Login

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If txt_uset_name.Text = "" Or txt_pwd.Text = "" Then
            MessageBox.Show("Please Enter User Name and Password  !...", "Janatics AFMS ", MessageBoxButtons.OK)
        Else

            Try


                'create base tables
                sql = " SELECT * FROM jan_fms_customer_master"
                ds = SQL_SELECT_mysql("table_cnt", sql)
                If ds.Tables(0).Rows.Count = 0 Then
                    create_base_table()
                End If
                'jan_FMS_user_role(user_group int , view_option int, Edit_option int, delete_option int, Shift_setting_option int, creation_date Date, last_update_date Date , user_role varchar(30)  )"
                sql = "Select  a.*,(Select shift_setting_option from jan_FMS_user_role where user_role=a.user_role)shift_setting_option,(Select view_option from jan_FMS_user_role where user_role=a.user_role)view_option,(Select edit_option from jan_FMS_user_role where user_role=a.user_role)edit_option ,(Select delete_option from jan_FMS_user_role where user_role=a.user_role)delete_option  FROM JAN_FMS_USER_MASTER a  where end_date Is  null  And user_id='" & Trim(txt_uset_name.Text) & "' and p_key='" & txt_pwd.Text & "'"
                ds = SQL_SELECT_mysql("user_login", sql)

                If ds.Tables(0).Rows.Count > 0 Then
                    FMS_shift_setting = ds.Tables("user_login").Rows(0).Item("shift_setting_option")
                    fms_view = ds.Tables("user_login").Rows(0).Item("view_option")
                    fms_delete = ds.Tables("user_login").Rows(0).Item("delete_option")
                    fms_edit = ds.Tables("user_login").Rows(0).Item("edit_option")
                    FMS_LOGIN_USER = ds.Tables("user_login").Rows(0).Item("USER_NAME")
                    FMS.lbl_user_name.Text = "User :" & FMS_LOGIN_USER
                    FMS_USER_ID = ds.Tables("user_login").Rows(0).Item("USER_ID")
                    txt_pwd.Text = ""
                    txt_uset_name.Text = ""
                    FMS.TabControl1.SelectedIndex = 0
                    FMS.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("User Name  or  Password is Invalid !...", "Janatics AFMS ", MessageBoxButtons.OK)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString & vbNewLine & vbNewLine & sql, "AFMS Login", MessageBoxButtons.OK)
            End Try
        End If
    End Sub
    Private Sub create_base_table()
        Dim z As Int32 = 0
        sql = "create table IF NOT EXISTS jan_fms_customer_master(customer_id int,customer_name varchar(100),creation_date date,last_update_date date)"
        z = Execute_Query_mysql(sql)

        '        sql = "INSERT INTO jan_fms_customer_master (CUSTOMER_ID,CUSTOMER_NAME,cREATION_DATE,LAST_UPDATE_DATE) 
        'VALUES(19798,'" & txt_customer.Text.ToString.Replace("'", "''") & "',sysdate(),sysdate())"
        '        z = Execute_Query_mysql(sql)

        sql = "create table IF NOT EXISTS JAN_FMS_MILL_VS_MACHINE(CUSTOMER_ID int,dept varchar(20),manufacturing_year varchar(10),MACHINE_NAME varchar(100),MACHINE_MAKE varchar(50),MACHINE_MODEL varchar(50),FLOW_METER_ID varchar(30),creation_date date,last_update_date date,recommended_flow_running float,recommended_flow_idle float,alert_flow_running float,alert_flow_idle float,end_date date,VIEW_REPORT INT )"
        z = Execute_Query_mysql(sql)

        sql = "create table IF NOT EXISTS JAN_FMS_MASTER(CUSTOMER_ID int,FLOW_METER_ID varchar(30),RECOMMENDED_FLOW  float,alert_flow float ,creation_date date,last_update_date date  )"
        z = Execute_Query_mysql(sql)

        sql = "create table IF NOT EXISTS jan_fms_user_master(customer_id int,user_name varchar(30),user_id varchar(30),p_key varchar(30),email varchar(30),phone_no varchar(30),user_role int,department varchar(30) ,creation_date date,lat_update_date date,end_date date)"
        z = Execute_Query_mysql(sql)

        sql = "select * from jan_fms_user_master where user_role=-1"
        ds = SQL_SELECT_mysql("super_user", sql)

        If ds.Tables("super_user").Rows.Count = 0 Then
            sql = "insert into JAN_FMS_USER_MASTER values(0,'ADMIN','ADMIN','Jana@2021','janatics_sw@janatics.co.in',0,-1,'All',sysdate(),sysdate(),null)"
            z = Execute_Query_mysql(sql)
        End If
        '------User Role Creation
        sql = "create table IF NOT EXISTS jan_FMS_user_role( user_group int ,view_option int,Edit_option int,delete_option int,Shift_setting_option int,creation_date date,last_update_date date ,user_role varchar(30)  )"
        z = Execute_Query_mysql(sql)

        sql = "select * from jan_FMS_user_role where user_role=-1"
        ds = SQL_SELECT_mysql("super_user", sql)

        If ds.Tables("super_user").Rows.Count = 0 Then
            sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1,1,1,1,1,SYSDATE(),SYSDATE(),-1)"
            z = Execute_Query_mysql(sql)
        End If

        sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=0"
        ds = SQL_SELECT_mysql("user_role", sql)
        If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
            sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1,1,1,1,1,SYSDATE(),SYSDATE(),0)"
            Execute_Query_mysql(sql)
        End If

        sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=1"
        ds = SQL_SELECT_mysql("user_role", sql)
        If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
            sql = " INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 1, 1, 0, SYSDATE(), SYSDATE(), 1)"
            Execute_Query_mysql(sql)
        End If

        sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=2"
        ds = SQL_SELECT_mysql("user_role", sql)
        If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
            sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 1, 0, 0, SYSDATE(), SYSDATE(), 2)"
            Execute_Query_mysql(sql)
        End If

        sql = "select count(*)cnt from JAN_FMS_USER_ROLE where user_role=3"
        ds = SQL_SELECT_mysql("user_role", sql)
        If ds.Tables("user_role").Rows(0).Item("cnt") = 0 Then
            sql = "INSERT INTO JAN_FMS_USER_ROLE VALUES(1, 1, 0, 0, 0, SYSDATE(), SYSDATE(), 3)"
            Execute_Query_mysql(sql)
        End If


        '------Shift Detail Creation
        sql = "create table  IF NOT EXISTS  jan_fms_shift_details(customer_id int ,no_of_shift int,shift1_start_time time,shift1_end_time time,shift2_start_time time,shift2_end_time time,shift3_start_time time,shift3_end_time time,creation_date date,last_update_date date,COMPANY_LOGO_TEXT VARCHAR(100),COMPANY_LOGO_OR_TEXT VARCHAR(10),COMPANY_LOGO_file_name  VARCHAR(40),MINUTE_DATA_FREEZE_TIME datetime,dashboard_view_by  varchar(20),flow_unit varchar(10))"
        z = Execute_Query_mysql(sql)

        sql = "INSERT INTO jan_fms_shift_details VALUES(customer_id  ,no_of_shift ,shift1_start_time ,shift1_end_time ,creation_date ) values((select CUSTOMER_ID from jan_fms_customer_master ),1,'08:00 AM','04:30 PM',sysdaye())"
        z = Execute_Query_mysql(sql)

        sql = "CREATE TABLE   IF NOT EXISTS  JAN_FLOW_SHIFT_DATA(SLAVE_ID VARCHAR(5),GROUP_ID VARCHAR(5),AVG_FLOW_VALUE VARCHAR(10),DIGITAL_INPUT VARCHAR(5),FLOW_DATE DATE,SHIFT1_VALUE VARCHAR(10),SHIFT2_VALUE VARCHAR(10),SHIFT3_VALUE VARCHAR(10),SHIFT_NO INT)"
        z = Execute_Query_mysql(sql)

        sql = "CREATE TABLE   IF NOT EXISTS  JAN_FLOW_minute_DATA(SLAVE_ID VARCHAR(5),GROUP_ID VARCHAR(5),AVG_FLOW_VALUE VARCHAR(10),DIGITAL_INPUT VARCHAR(5),FLOW_DATE DATE,SHIFT1_VALUE VARCHAR(10),SHIFT2_VALUE VARCHAR(10),SHIFT3_VALUE VARCHAR(10),minute_no INT,HOUR_NO VARCHAR(2))"
        z = Execute_Query_mysql(sql)

        'MessageBox.Show("Required Tables Created ", " Janatics AFMS Table creation", MessageBoxButtons.OK)
    End Sub
    Private Sub FMS_Login_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub

    Private Sub FMS_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class