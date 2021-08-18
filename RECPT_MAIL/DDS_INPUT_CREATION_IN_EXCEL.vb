Imports System.IO
Public Class DDS_INPUT_CREATION_IN_EXCEL
    Private Sub DDS_INPUT_CREATION_IN_EXCEL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Dim Str() As String
            'Str = Directory.GetFiles("L:\Oracle_Report\Reports_2_CRP_MKTG")
            'Dim DELFILE As String
            'For Each DELFILE In Str
            '    File.Delete(DELFILE)
            'Next

            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102','DDS Export to Excel',sysdate) "
            comand()
            Dim DT As String = Format(Date.Now, "ddMMMyyyy")
            'Report1
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_LIST1','DDS Export to Excel',sysdate) "
            comand()
            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM JAN_DDS_PLAN_v1', 'XLS_EXPORT1','DDS_LIST1_" & DT & ".xlsx'); END;"
                comand_new()

            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST1'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST1'  and end_time is null"
            comand()

            'Report2
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_LIST2','DDS Export to Excel',sysdate) "
            comand()

            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM JAN_DDS_PLAN_v2', 'XLS_EXPORT1','DDS_LIST2_" & DT & ".xlsx'); END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST2'  and end_time is null"
                comand()
            End Try


            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST2'  and end_time is null"
            comand()
            'Report3
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_LIST3','DDS Export to Excel',sysdate) "
            comand()

            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM JAN_DDS_PLAN_I07', 'XLS_EXPORT1','DDS_LIST3_" & DT & ".xlsx'); END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST3'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST3'  and end_time is null"
            comand()
            'Report4
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_LIST_SF','DDS Export to Excel',sysdate) "
            comand()

            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM JAN_DDS_PLAN_SF', 'XLS_EXPORT1','DDS_LIST_SF_" & DT & ".xlsx'); END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST_SF'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_LIST_SF'  and end_time is null"
            comand()

            'Report5
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-FG_Stock','DDS Export to Excel',sysdate) "
            comand()

            Try
                'FG Stock Query
                sql = " DECLARE  LV_DAY VARCHAR2(10);
            BEGIN  select TO_CHAR(sysdate,'DY') into LV_DAY from DUAL; if LV_DAY='MON' then jan_corp_plan_stock_proc; JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM jan_corp_plan_stock_v', 'XLS_EXPORT1','STOCK_ASON_" & DT & ".xlsx'); end if; END;" 'jan_corp_plan_stock_v
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-FG_Stock'  and end_time is null"
                comand()
            End Try
            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-FG_Stock'  and end_time is null"
            comand()

            'Report6
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_VISIBILITY_MOBILE','DDS Export to Excel',sysdate) "
            comand()

            sql = "delete from jan_dds_visibility_to_branch_t"
            comand_new()

            Try
                sql = "insert into jan_dds_visibility_to_branch_t select * from jan_dds_visibility_to_branch_v"
                comand_new()
            Catch ex As Exception
                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.Message.Replace("'", " ") & "' where trunc(start_time)=trunc(sysdate) and s_code='DDS_VISIBILITY_MOBILE' "
                comand_new()
            End Try
            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_VISIBILITY_MOBILE'  and end_time is null"
            comand()

            'Report7
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-DDS_Visibility','DDS Export to Excel',sysdate) "
            comand()
            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM jan_dds_visibility_to_branch_t', 'XLS_EXPORT1','DDS_VISIBILITY_" & DT & ".xlsx'); END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_Visibility'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-DDS_Visibility'  and end_time is null"
            comand()




            'Report8
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-ZOHO_BI','DDS Export to Excel',sysdate) "
            comand()

            Try
                sql = "DECLARE BEGIN JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM JAN_ZOHO_BI_V1', 'XLS_EXPORT1','ZOHO_BI_1_data.xlsx'); END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-ZOHO_BI'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-ZOHO_BI'  and end_time is null"
            comand()

            'Report9
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00102-last_month_sale','DDS Export to Excel',sysdate) "
            comand()

            Try
                'Last month Sale detail for corp-plan
                sql = " DECLARE  LV_DAY VARCHAR2(10);
            BEGIN  select TO_CHAR(sysdate,'DD') into LV_DAY from DUAL; if LV_DAY='01' or LV_DAY='02' then JAN_ORACLE_TO_EXCEL_PROC('SELECT * FROM jan_sale_det_corp_plan_v', 'XLS_EXPORT1','Last_month_sale_ASON_" & DT & ".xlsx'); end if; END;"
                comand_new()
            Catch ex As Exception

                sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.ToString & "' where trunc(start_time)=trunc(sysdate) and s_code='C00102-last_month_sale'  and end_time is null"
                comand()
            End Try

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102-last_month_sale'  and end_time is null"
            comand()

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00102'  and end_time is null"
            comand()

        Catch ex As Exception

        End Try
        End
        Me.Close()
    End Sub
End Class