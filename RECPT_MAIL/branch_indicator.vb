Imports System.Data.OracleClient

Public Class branch_indicator
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
    Private Sub branch_indicator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00006','branch indicator uploading',sysdate) "
        comand()


        sql = " declare begin  JAN_Branch_indicator_PROC; end ;"
        comand()

        'BRANCH INDICATIOR
        sql = " delete FROM jan_sales_branch_indicator"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()


        sql = "SELECT * FROM jan_sales_branch_indicator"
        adap = New OracleDataAdapter(sql, con)
        DS.Tables.Clear()
        adap.Fill(DS, "data")

        For i = 0 To DS.Tables("data").Rows.Count - 1
            With DS.Tables("data").Rows(i)

                sql = "INSERT INTO jan_sales_branch_indicator(INDICATOR_FOR,	REGION,	LAST_SIX_MONTH_AVG_SALE,	CUR_MONTH_SALE,	SALES_INDICATOR,	AS_ON
) VALUES('" & .Item("INDICATOR_FOR") & "','" & .Item("REGION") & "','" & .Item("LAST_SIX_MONTH_AVG_SALE") & "'," & .Item("CUR_MONTH_SALE") & "," & .Item("SALES_INDICATOR") & " ,'" & Format(.Item("AS_ON"), "dd-MMM-yyyy") & "')"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()
            End With
        Next

        sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00006'"
        comand()


        Me.Close()
        Exit Sub
        'MessageBox.Show("Branch Indicator Upload completed ", "Branch Indicator Uploaded", MessageBoxButtons.OK)
    End Sub
End Class