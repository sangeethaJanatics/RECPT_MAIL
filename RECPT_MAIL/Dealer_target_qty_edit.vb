
Imports System.Data.OracleClient
Public Class Dealer_target_qty_edit

    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.195.146;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim adap As New OracleDataAdapter
    Dim DS, TDS As New DataSet

    Dim htm As String

    Dim DSP_ID As String
    Dim Z As New Integer

    Private Sub Dealer_target_qty_edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_acct_stmt_Click(sender, e)

        sql = "select 'ALL' CUSTOMER_NAME,0  customer_id from dual union SELECT CUSTOMER_NAME,CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_CLASS_CODE='DEALER' ORDER BY 1"
        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")

        cmb_dealer.DataSource = DS.Tables("res")
        cmb_dealer.DisplayMember = "CUSTOMER_NAME"
        cmb_dealer.ValueMember = "customer_id"


        sql = "SELECT DISTINCT Product_group FROM            JAN_DEALER_TGT_2015_16_FINAL WHERE        (org IN ('I22', 'I23', 'I24', 'I25'))  and fin_year=201920 ORDER BY Product_group"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        DS = New DataSet
        adap_sql.Fill(DS, "RES")

        CMB_PROD_GROUP.DataSource = DS.Tables("res")
        CMB_PROD_GROUP.DisplayMember = "Product_group"
        CMB_PROD_GROUP.ValueMember = "Product_group"

        sql = " select * from jan_dsp_master where  valid_upto>GETDATE()-60 order by dsp_id "
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        DS = New DataSet
        adap_sql.Fill(DS, "res")

        cmb_dsp_id.DataSource = DS.Tables("res")
        cmb_dsp_id.DisplayMember = "Description"
        cmb_dsp_id.ValueMember = "dsp_id"


    End Sub

    Private Sub btn_gate1_value_update_Click(sender As Object, e As EventArgs) Handles btn_gate1_value_update.Click
        If txt_gate1_val.Text <> "" Then
            sql = "update JAN_DEALER_TOD_TARGET_BASE SET  "


            sql &= "  ENABLE_LINK_Q4 =1,tod_q4=" & txt_gate1_val.Text & " where  fin_year=201920  and customer_id =" & cmb_dealer.SelectedValue & ""
            'sql &= " =" & txt_gate1_val.Text & " WHERE BILL_TO_CUSTOMER_ID=" & cmb_dealer.SelectedValue & " AND PRODUCT_GROUP='" & CMB_PROD_GROUP.SelectedValue & "' AND ORG='" & CMB_ORG.SelectedItem & "'  and fin_year=201920 "

            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            Z = cmd_sql.ExecuteNonQuery()
            If Z > 0 Then
                MessageBox.Show("Dealer Target value Updated ...!", "Dealer Target value Editing", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("Enter the target value to Change ...!", "Dealer Target value Editing", MessageBoxButtons.OK)

        End If
    End Sub

    Private Sub btn_exted_DSP_date_Click(sender As Object, e As EventArgs) Handles btn_exted_DSP_date.Click
        sql = "select rowtocol('select oe_customer_id from oe_dms_order_headers_all where oe_dsp_id='||" & cmb_dsp_id.SelectedValue & "||'' )cust_id from dual"
        DS = SQL_SELECT("res", sql)

        sql = "update jan_dsp_lines SET  "


        sql &= "  valid_upto='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' where  dsp_id=" & cmb_dsp_id.SelectedValue & "  "
        If cmb_dealer.Text = "ALL" Then
            'sql &= " and bill_to_cust_id not in (" & DS.Tables("res").Rows(0).Item("cust_id") & ")"
        Else
            sql &= " and bill_to_cust_id =" & cmb_dealer.SelectedValue & ""
        End If



        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        Z = cmd_sql.ExecuteNonQuery()
        If Z > 0 Then
            MessageBox.Show("DSP Date Extended ...!", "DSP Date Extension ", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_.Click
        Dim cus_id As Integer = 0
        If cmb_dealer.Text <> "ALL" Then
            sql = "select customer_id from ra_customers where customer_name ='" & cmb_dealer.Text & "' "
            DS = SQL_SELECT("data", sql)

            If DS.Tables("data").Rows.Count > 0 Then

                cus_id = DS.Tables("data").Rows(0).Item("customer_id")

                sql = " SELECT * FROM (SELECT (SELECT DRAFT_QTY FROM JAN_DSP_LINES WHERE DSP_ID=A.OE_DSP_ID AND BILL_TO_CUST_ID=A.OE_CUSTOMER_ID AND ORG_ID=A.OE_ORG_ID AND ITEM_ID=A.oe_inventory_item_id)DRAFT_QTY ,A.* FROM OE_DMS_ORDER_LINES_ALL A  WHERE OE_DSP_ID=" & cmb_dsp_id.SelectedValue & " AND oe_customer_id=" & cus_id & ") B WHERE DRAFT_QTY<>SITE_1_QTY "


                adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
                ds1 = New DataSet
                adap_sql.Fill(ds1, "RES")
                For i = 0 To ds1.Tables("RES").Rows.Count - 1
                    With ds1.Tables("RES").Rows(i)
                        sql = "update  OE_DMS_ORDER_LINES_ALL set site_1_qty=" & .Item("draft_qty") & "  WHERE OE_DSP_ID=" & cmb_dsp_id.SelectedValue & " AND oe_customer_id=" & cus_id & " and  oe_dsp_line_id=" & .Item("oe_dsp_line_id") & ""
                    End With

                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    Z = cmd_sql.ExecuteNonQuery()
                Next

                sql = "update jan_dsp_lines set site_1_qty=draft_qty where dsp_id=" & cmb_dsp_id.SelectedValue & " and bill_to_cust_id=" & cus_id & " and draft_qty<>site_1_qty"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                Z = cmd_sql.ExecuteNonQuery()
                If Z > 0 Then
                    MessageBox.Show("Scheme  Quantity Updated ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("There is no mismatch in Scheme  Quantity ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)
                End If
            End If
        Else
            MessageBox.Show("Enter  Dealer Name to Edit the Quantity ...!", "Scheme Order Quantity Editing", MessageBoxButtons.OK)

        End If
    End Sub

    Private Sub btn_acct_stmt_Click(sender As Object, e As EventArgs) Handles btn_acct_stmt.Click
        sql = "select customer_name,region,isnull((select sum(amount_due_remaining) from jan_dealer_payment_new_v where bill_to_customer_id=a.customer_id),0)OS_in_new_pay_cal
,isnull((SELECT SUM(CAST(receipt_unapp_amount AS float))unapp from JAN_DEALER_UNAPPLIED_CUM_TAB  where customer_id=a.customer_id),0)unapplied
,isnull((select balance from jan_ar_ledger_op_bals  where customer_id=a.customer_id),0)+isnull((SELECT sum(dr-cr) opbal2 FROM jan_ar_ledger   WHERE CUSTOMER_ID =a.customer_id),0)bal_in_actstmt,cast (0 as float)as bal_as_per_new_payment_cal,cast (0 as float)as diff "

        sql &= " , isnull((select  sum(CAST(AMOUNT_DUE_REMAINING AS float)) from JAN_REGION_PAYMENT_PENDING where upper(name) like 'SAM%'  and bill_to_customer_id=a.customer_id),0)sample_inv_OS "
        sql &= " From DMS_CUSTS_LOG_IN_TAB  a where customer_class_code='DEALER' and region  not in ('HO','EXPORT') order by customer_name
"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        ds1 = New DataSet
        adap_sql.Fill(ds1, "RES")
        For i = 0 To ds1.Tables("RES").Rows.Count - 1
            With ds1.Tables("RES").Rows(i)
                .Item("bal_as_per_new_payment_cal") = .Item("unapplied") - .Item("OS_in_new_pay_cal")
                .Item("bal_in_actstmt") = Math.Round(.Item("bal_in_actstmt"), 2)
                .Item("diff") = Math.Round(.Item("bal_in_actstmt") - (- .Item("bal_as_per_new_payment_cal")), 2)
            End With
        Next

        With dgv_acct_stmt
            .DataSource = ds1.Tables("RES")
            For i = 0 To .Rows.Count - 1
                If Math.Abs(.Rows(i).Cells("diff").Value) > 2 Then
                    If Math.Abs(.Rows(i).Cells("diff").Value) = Math.Abs(.Rows(i).Cells("sample_inv_OS").Value) Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Green
                    Else
                        .Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If

                End If
            Next
        End With


    End Sub
    Private Sub btn_view_DSP_val_Click(sender As Object, e As EventArgs) Handles btn_view_DSP_val.Click

        sql = "SELECT (select description from jan_dsp_master where dsp_id=a.oe_dsp_id)dsp_for,OE_BILL_TO_NAME ""Dealer Name "",oe_dsp_id,approved_date,status ,isnull((select sum(case when oe_dsp_id=20191203 then oe_total_selling_price else oe_total_price end ) AS vall from oe_dms_order_lines_all 
where oe_dms_order_header_id = a.oe_order_online_id ),0) order_value_in_crm
, isnull((select count(*) from oe_dms_order_lines_all 
where oe_dms_order_header_id = a.oe_order_online_id ),0) no_of_items,0 as oracle_ord_value,0 no_of_item_in_oracle,oe_order_online_id FROM OE_DMS_ORDER_HEADERS_ALL  a WHERE OE_DSP_ID =' " & cmb_dsp_id.SelectedValue & "'  order  by oe_dsp_id,OE_BILL_TO_NAME"
        'AND  OE_BILL_TO_NAME LIKE 'TRUE%'

        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        ds1 = New DataSet
        adap_sql.Fill(ds1, "RES")
        For i = 0 To ds1.Tables("RES").Rows.Count - 1
            With ds1.Tables("RES").Rows(i)
                sql = "select round(nvl((select sum(oe_order_qty*(oe_unit_price-((oe_unit_price/100)*oe_discount))) from OE_DMS_ORDER_lineS_ALL  where oe_dms_order_header_id=" & .Item("oe_order_online_id") & " and oe_dsp_id=" & .Item("OE_DSP_ID") & "),0),2) ord_val
,nvl((select count(*) from OE_DMS_ORDER_lineS_ALL  where oe_dms_order_header_id=" & .Item("oe_order_online_id") & " and oe_dsp_id=" & .Item("OE_DSP_ID") & "),0)no_of_items
from dual"
                DS = SQL_SELECT("res", sql)


                .Item("oracle_ord_value") = DS.Tables("res").Rows(0).Item("ord_val")
                .Item("no_of_item_in_oracle") = DS.Tables("res").Rows(0).Item("no_of_items")
                '.Item("diff") = Math.Round(.Item("bal_in_actstmt") - (- .Item("bal_as_per_new_payment_cal")), 2)
            End With
        Next


        With dgv_acct_stmt
            .DataSource = ds1.Tables("RES")
            For i = 0 To .Rows.Count - 1
                'If Math.Abs(.Rows(i).Cells("diff").Value) > 2 Then
                If (Math.Abs(.Rows(i).Cells("order_value_in_crm").Value) - Math.Abs(.Rows(i).Cells("oracle_ord_value").Value)) > 2 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Red
                Else
                    '.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If

                'End If
            Next
        End With

        dgv_acct_stmt.DataSource = ds1.Tables("res")
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click

        If txt_qty.Text <> "" Then
            sql = "update JAN_DEALER_TGT_2015_16_FINAL SET  "

            If cmb_qtrid.SelectedItem = "1" Then
                sql &= " Q1_QTY"
            ElseIf cmb_qtrid.SelectedItem = "2" Then
                sql &= " Q2_QTY"
            ElseIf cmb_qtrid.SelectedItem = "3" Then
                sql &= " Q3_QTY"
            ElseIf cmb_qtrid.SelectedItem = "4" Then
                sql &= " Q4_QTY"
            End If
            sql &= " =" & txt_qty.Text & " WHERE BILL_TO_CUSTOMER_ID=" & cmb_dealer.SelectedValue & " And PRODUCT_GROUP='" & CMB_PROD_GROUP.SelectedValue & "' AND ORG='" & CMB_ORG.SelectedItem & "'  and fin_year=201920 "

            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            Z = cmd_sql.ExecuteNonQuery()
            If Z > 0 Then
                MessageBox.Show("Dealer Target Quantity Updated ...!", "Dealer Target Quantity Editing", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("Enter the target Quantity to Change ...!", "Dealer Target Quantity Editing", MessageBoxButtons.OK)

        End If

    End Sub
End Class