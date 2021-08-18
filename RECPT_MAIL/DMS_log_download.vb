Imports System.Data.OracleClient
Public Class DMS_log_download
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim adap As New OracleDataAdapter
    Dim DS, TDS As New DataSet

    Private Sub btn_download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_download.Click
        sql = "select cus_id ,v_date ,sid,isnull(mair,0)mair ,isnull(desp,0)desp ,isnull(acstmt,0)acstmt ,isnull(pay_pend,0)pay_pend ,isnull(tod,0)tod ,isnull(prod_schemes,0)prod_schemes ,isnull(new_prod ,0)new_prod,isnull(mapped_cus,0)mapped_cus ,isnull(visit_report,0)visit_report,isnull(price_list,0)price_list, isnull(jan_cform,0)jan_cform ,isnull(jan_dms_tod,0)jan_dms_tod ,isnull(jan_tar_vs_sales,0)jan_tar_vs_sales ,isnull(dms_scheme_orders,0)dms_scheme_orders ,isnull(payment_details_entry,0)payment_details_entry ,isnull(Account_Reconciliation,0)Account_Reconciliation ,isnull(item_search,0)item_search ,isnull(despatch_request,0)despatch_request from dms_new_usr_log where v_date >= '1-jan-2014' AND v_date < '1-feb-2014' and login_as = 'Dealer'"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        DS = New DataSet
        adap_sql.Fill(DS, "log")
        For i = 0 To DS.Tables("log").Rows.Count - 1
            With DS.Tables("log").Rows(i)
                sql = "insert into jan_dms_new_usr_log(cus_id ,v_date ,sid,mair ,desp ,acstmt ,pay_pend ,tod ,prod_schemes ,new_prod ,mapped_cus ,visit_report,price_list, jan_cform ,jan_dms_tod ,jan_tar_vs_sales ,dms_scheme_orders ,payment_details_entry ,account_reconsiliation ,item_search ,despatch_request)"

                sql &= " values(" & .Item("cus_id") & ",'" & Format(.Item("v_date"), "dd-MMM-yyyy") & "','" & .Item("sid") & "'," & .Item("mair") & "," & .Item("desp") & "," & .Item("acstmt") & "," & .Item("pay_pend") & "," & .Item("tod") & "," & .Item("prod_schemes") & "," & .Item("new_prod") & "," & .Item("mapped_cus") & "," & .Item("visit_report") & "," & .Item("price_list") & "," & .Item("jan_cform") & "," & .Item("jan_dms_tod") & "," & .Item("jan_tar_vs_sales") & "," & .Item("dms_scheme_orders") & "," & .Item("payment_details_entry") & "," & .Item("Account_Reconciliation") & "," & .Item("item_search") & "," & .Item("despatch_request") & ")"
                ',sid,mair , , , , , , , ,,  , , , , , , ,)"
                'comand()
                cmd = New OracleCommand(sql, con)
                If con.State = ConnectionState.Closed Then con.Open()

                cmd.ExecuteNonQuery()

            End With

        Next


    End Sub
End Class