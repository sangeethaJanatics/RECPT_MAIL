Public Class CRM_package_upload
    Private Sub CRM_package_upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00024-33','Uploading  to CRM Portal',sysdate) "
            comand()

            System.Diagnostics.Process.Start("D:\DMS\CRM_Package_upload.bat")

            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00024-33'"
            comand()

        Catch ex As Exception
            sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.Message.Replace("'", " ") & "',END_TIME=SYSDATE where trunc(start_time)=trunc(sysdate) and s_code='C00024-33'"
            comand()

        End Try

        End
    End Sub
End Class