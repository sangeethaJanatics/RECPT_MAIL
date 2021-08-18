Imports System.Data.OracleClient
Public Class mobile_data_upload
    Dim ordref As String

    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms_test;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim adap As New OracleDataAdapter
    Dim DS, TDS As New DataSet

    Dim htm As String

    Dim DSP_ID As String
    Dim Z As New Integer
    Private Sub mobile_data_upload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "SELECT * FROM jan_region_mis_v "

        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")

        sql = "delete from JAN_REG_MOBILE_MIS_TAB1"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()

        For i = 0 To DS.Tables("RES").Rows.Count - 1
            With DS.Tables("RES").Rows(i)

                Try


                    sql = "INSERT INTO JAN_REG_MOBILE_MIS_TAB1(REGION, SALES_CUR_MONTH, SALES_CYR, ORDER_RECD_CUR_MONTH, ORDER_RECD_CYR, PAYMENT_RECD_CUR_MONTH, PAYMENT_RECD_CYR,IN_DESPATCH_CUR_MONTH, IN_DESPATCH_CYR, SALES_PROJ_CUR_MONTH, SALES_PROJ_CYR, TARGET_CUR_MONTH, TARGET_CYR, PENDING_ORD_CUR_MONTH, PENDING_ORD_CYR) "

                    sql &= " VALUES('" & .Item("REGION") & "'," & .Item("SALES_CUR_MONTH") & "," & .Item("SALES_CYR") & "," & .Item("ORD_RECD_CUR_MONTH") & "," & .Item("ORD_RECD_CYR") & "," & .Item("PAYMENT_RECD_CUR_MONTH") & "," & .Item("PAYMENT_RECD_CYR") & "," & .Item("INDESPATCH_CUR_MONTH") & "," & .Item("INDESPATCH_CYR") & "," & .Item("PROJ_CUR_MONTH") & "," & .Item("PROJ_CYR") & "," & .Item("TARGET_CUR_MONTH") & "," & .Item("CYR_TARGET") & "," & .Item("ORD_pend_CUR_MONTH") & "," & .Item("ORD_pend_CYR") & ")"
                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()
                Catch ex As Exception
                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','JAN_REG_MOBILE_MIS_TAB1,Error')"
                    comand()
                End Try

            End With
        Next
    End Sub
End Class