Imports System.Data
Imports System.Net
Imports System.Data.OracleClient
Imports System.Data.OleDb
Imports System.IO
Imports System.DateTime
Imports System.Globalization




Public Class sql_server_update
    'Dim SQL As String

    Dim ordref As String

    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms_test;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    ''Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.237.129 ;initial catalog=jan_FMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.195.146 ;initial catalog=JAN_DMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim xl_con As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim adap As New OracleDataAdapter
    Dim DS, TDS As New DataSet

    Dim htm As String

    Dim DSP_ID As String
    Dim Z As New Integer
    Private Sub dsp_item_moq()
        sql = " select a.*,jan_itemname(item_id)item_no ,sysdate dt from JAN_DSP_ITEM_MOQ  a"
        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")

        For i = 0 To DS.Tables("RES").Rows.Count - 1
            With DS.Tables("RES").Rows(i)

                Try
                    sql = "INSERT INTO jan_dms_moq_details(org_id, item_no, inventory_item_id, moq, creation_date, valid) VALUES(" & .Item("org_id") & ",'" & .Item("item_no") & "'," & .Item("item_id") & "," & .Item("moq_qty") & ",GETDATE(),0)"
                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()
                Catch ex As Exception
                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload Less Payment')"
                    comand()
                End Try

            End With
        Next
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'export_from_excel()
        'Exit Sub

        'dsp_item_moq()
        'sale_2014_15_download()
        'Exit Sub
        target_upload_2015_16_q2()
        'target_upload_2015_16()
        'sql = "delete from  jan_dealer_less_payment" 'Less Payment
        ''sql = "UPDATE  Jan_DSP_Lines  SET VALID_UPTO='31-AUG-2014' WHERE (DSP_ID = 201409) "
        'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        'Z = cmd_sql.ExecuteNonQuery()

        'sql = " select bill_to_customer_id,sum(qtr1_less_payment)qtr1_less_payment,sum(qtr2_less_payment)qtr2_less_payment,sum(qtr3_less_payment)qtr3_less_payment,sum(qtr4_less_payment)qtr4_less_payment from jan_dealer_less_payment GROUP BY BILL_TO_CUSTOMER_ID "
        'adap = New OracleDataAdapter(sql, con)
        'DS = New DataSet
        'adap.Fill(DS, "RES")

        'For i = 0 To DS.Tables("RES").Rows.Count - 1
        '    With DS.Tables("RES").Rows(i)

        '        Try
        '            sql = "INSERT INTO jan_dealer_less_payment(bill_to_customer_id ,Qtr1_less_payment, Qtr2_less_payment, Qtr3_less_payment, Qtr4_less_payment) VALUES(" & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("Qtr1_less_payment") & "," & .Item("Qtr2_less_payment") & "," & .Item("Qtr3_less_payment") & "," & .Item("Qtr4_less_payment") & ")"
        '            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        '            cmd_sql.ExecuteNonQuery()
        '        Catch ex As Exception
        '            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload Less Payment')"
        '            comand()
        '        End Try

        '    End With
        'Next

        sql = "select upload_dealer_sale_from from jan_sales_bi_setup"
        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")
        Try

            sql = "delete from  JAN_DEALER_SALE_2014_15_tab  where trx_DAte>='" & Format(DS.Tables("RES").Rows(0).Item("upload_dealer_sale_from"), "dd-MMM-yyyy") & "'"

            'sql = "delete from  JAN_DEALER_SALE_2014_15_tab  where trx_DAte>='1-jul-2014' and bill_to_customer_id=2593588"

            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()

            sql = "SELECT * FROM JAN_DEALER_SALE_2014_15_v  where trx_DAte>='" & Format(DS.Tables("RES").Rows(0).Item("upload_dealer_sale_from"), "dd-MMM-yyyy") & "'"

            'sql = "SELECT * FROM JAN_DEALER_SALE_2014_15_v  where trx_DAte>='1-apr-2017' and bill_to_customer_id=2280588"

            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")

            For i = 0 To DS.Tables("RES").Rows.Count - 1
                With DS.Tables("RES").Rows(i)

                    Try
                        sql = "INSERT INTO JAN_DEALER_SALE_2014_15_tab(bill_to_customer_id, trx_number, trx_date, quantity_invoiced, sale_value_without_tax, org,  product_group, item_no,tod_item,disc,clp_price_list,unit_selling_price,unit_standard_price,order_type) VALUES(" & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("trx_number") & ",'" & Format(.Item("trx_date"), "dd-MMM-yyyy") & "'," & .Item("quantity_invoiced") & "," & .Item("sale_value_without_tax") & ",'" & .Item("org") & "','" & .Item("product_group") & "','" & .Item("ordered_item") & "'," & .Item("tod_item") & "," & .Item("disc") & "," & .Item("clp_price_list") & "," & .Item("unit_selling_price") & "," & .Item("unit_standard_price") & ",'" & .Item("ord_type") & "')"
                        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                        cmd_sql.ExecuteNonQuery()
                    Catch ex As Exception
                        sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,sales')"
                        comand()
                    End Try

                End With
            Next

            sql = "delete from  jan_dealer_order_2015_16 " 'Date-wise Order pending value
            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()

            'sql = "SELECT * FROM  JAN_DEALER_ORDER_PENDING_V where customer_id in (select customer_id from jan_dealer_target_status where q1_target_status='Achieved')"
            sql = "select * from JAN_DEALER_ORDER_201516_V "
            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")

            For i = 0 To DS.Tables("RES").Rows.Count - 1
                With DS.Tables("RES").Rows(i)

                    Try
                        'customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no

                        sql = "INSERT INTO jan_dealer_order_2015_16(order_number,customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no) VALUES(" & .Item("order_number") & "," & .Item("CUSTOMER_ID") & ",'" & .Item("org") & "','" & .Item("product_group") & "'," & .Item("ordered_quantity") & "," & .Item("unit_selling_price") & "," & .Item("qtr_id_new") & ",'" & .Item("ordered_item") & "')"
                        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                        cmd_sql.ExecuteNonQuery()
                    Catch ex As Exception
                        sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,JAN_DEALER_ORDER_PENDING')"
                        comand()
                    End Try

                End With
            Next

            'jan_dealer_order_pending_freezed_for_TOD JAN_DEALER_ORDER_PENDING
            sql = "delete from  JAN_DEALER_ORDER_PENDING " 'Date-wise Order pending value
            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()

            'sql = "SELECT * FROM  JAN_DEALER_ORDER_PENDING_V where customer_id in (select customer_id from jan_dealer_target_status where q1_target_status='Achieved')"
            sql = "SELECT * FROM  JAN_DEALER_ORDER_PENDING_V  "
            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")

            For i = 0 To DS.Tables("RES").Rows.Count - 1
                With DS.Tables("RES").Rows(i)

                    Try
                        sql = "INSERT INTO JAN_DEALER_ORDER_PENDING(customer_id,order_pend_qty,order_pend_value,order_date,org,product_group,item_no, unit_selling_price, q1_order_pend, q2_order_pend,                 q3_order_pend, q4_order_pend,qtr_id,dealer_ord_pend) VALUES(" & .Item("CUSTOMER_ID") & "," & .Item("order_pend_qty") & "," & .Item("order_pend_value") & ",'" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "','" & .Item("org") & "','" & .Item("product_group") & "','" & .Item("ordered_item") & "'," & .Item("unit_selling_price") & "," & .Item("dealer_q1_pend") & "," & .Item("dealer_q2_pend") & "," & .Item("dealer_q3_pend") & "," & .Item("dealer_q4_pend") & "," & .Item("qtr_id_new") & "," & .Item("dealer_ord_pend") & ")"


                        'sql = "INSERT INTO jan_dealer_order_pending_freezed_for_TOD(customer_id,order_pend_qty,order_pend_value,order_date,org,product_group,item_no) VALUES(" & .Item("CUSTOMER_ID") & "," & .Item("order_pend_qty") & "," & .Item("order_pend_value") & ",'" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "','" & .Item("org") & "','" & .Item("product_group") & "','" & .Item("ordered_item") & "')"

                        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                        cmd_sql.ExecuteNonQuery()
                    Catch ex As Exception
                        sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,JAN_DEALER_ORDER_PENDING')"
                        comand()
                    End Try

                End With
            Next

            'sql = "delete from  jan_dealer_quarter_order_pend" 'Qtr wise Order pending value
            'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            'cmd_sql.ExecuteNonQuery()

            'sql = "SELECT * FROM jan_dealer_quarter_order_pend"
            'adap = New OracleDataAdapter(sql, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            sql = "INSERT INTO jan_dealer_quarter_order_pend(customer_id,ord_pend_qtr1,ord_pend_qtr2,ord_pend_qtr3,ord_pend_qtr4) VALUES(" & .Item("CUSTOMER_ID") & "," & .Item("ord_pend_qtr1") & "," & .Item("ord_pend_qtr2") & "," & .Item("ord_pend_qtr3") & "," & .Item("ord_pend_qtr4") & ")"
            '            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception
            '            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload')"
            '            comand()
            '        End Try

            '    End With
            'Next

            sql = "delete from  JAN_DEALER_TGT_2014_15_FINAL_tmp" 'Target
            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()

            'sql = "SELECT a.*"
            'sql &= " , 0 order_pend "

            'sql &= ",nvl((SELECT GROUP_ORD  FROM jan_dealer_target_prod_group  WHERE GROUP_NAME=a.product_group AND ROWNUM=1  ),1000)ORDER_BY FROM JAN_DEALER_TGT_2014_15_FINAL a" 'JAN_DTGT_201415_NEW_27JUN14 a  

            sql = "select a.*"

            'sql &= " ,nvl((select decode(sign(q1_qty-achieved),-1,0,(q1_qty-achieved)) from jan_dealer_target_q1_not_achd where bill_to_customer_id=a.bill_to_customer_id and org=a.org and product_group=a.product_group),0)back_log_qty "

            sql &= ",0 back_log_qty "
            sql &= " ,nvl((select decode(count(*) ,0,0 ,1) from jan_dealer_target_status where  q1_target_status='Not Achieved' and customer_id=a.bill_to_customer_id and qtr_id=20141501),0)back_log ,nvl((SELECT GROUP_ORD  FROM jan_dealer_target_prod_group  WHERE GROUP_NAME=a.product_group AND ROWNUM=1  ),1000)ORDER_BY  , 0 order_pend  from JAN_DEALER_TGT_2014_15_FINAL a "
            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")

            For i = 0 To DS.Tables("RES").Rows.Count - 1
                With DS.Tables("RES").Rows(i)

                    Try
                        sql = "INSERT INTO JAN_DEALER_TGT_2014_15_FINAL_tmp(ORG,PRODUCT_GROUP,PROD_GROUP,SALE_QTY_2013_14 ,SALE_VALUE_2013_14 ,Q1_QTY,Q1_VALUE ,Q2_QTY,Q2_VALUE,Q3_QTY,Q3_VALUE,Q4_QTY,Q4_VALUE,TARGET_QTY,TARGET_VALUE,BILL_TO_CUSTOMER_ID,order_pend_qty,order_by,q1_backlog_qty,q1_backlog) VALUES('" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "','" & .Item("PROD_GROUP") & "'," & .Item("SALE_QTY_2013_14") & "," & .Item("SALE_VALUE_2013_14") & "," & .Item("Q1_QTY") & "," & .Item("Q1_VALUE") & "," & .Item("Q2_QTY") & "," & .Item("Q2_VALUE") & "," & .Item("Q3_QTY") & "," & .Item("Q3_VALUE") & " ," & .Item("Q4_QTY") & "," & .Item("Q4_VALUE") & " , " & .Item("TARGET_QTY") & "," & .Item("TARGET_VALUE") & "," & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("order_pend") & "," & .Item("order_by").ToString & "," & .Item("back_log_qty") & " ," & .Item("back_log") & ")"
                        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                        cmd_sql.ExecuteNonQuery()
                    Catch ex As Exception

                        sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,Target')"
                        comand()

                    End Try

                End With
            Next

            sql = "update JAN_DEALER_TGT_2014_15_FINAL_tmp  set q1_backlog_qty=isnull((select sum(q1_qty) from JAN_DEALER_TGT_2014_15_FINAL where bill_to_customer_id=JAN_DEALER_TGT_2014_15_FINAL_tmp .bill_to_customer_id and product_group=JAN_DEALER_TGT_2014_15_FINAL_tmp .product_group and org=JAN_DEALER_TGT_2014_15_FINAL_tmp .org ),0)-isnull((select sum(quantity_invoiced) from JAN_DEALER_SALE_2014_15_tab where bill_to_customer_id=JAN_DEALER_TGT_2014_15_FINAL_tmp .bill_to_customer_id and product_group=JAN_DEALER_TGT_2014_15_FINAL_tmp .product_group and org=JAN_DEALER_TGT_2014_15_FINAL_tmp .org and trx_date>='1-apr-2014'  and trx_date<'1-jul-2014'  and tod_item=0),0)-isnull((select sum(q1_order_pend) from jan_dealer_order_pending where customer_id=JAN_DEALER_TGT_2014_15_FINAL_tmp .bill_to_customer_id and product_group=JAN_DEALER_TGT_2014_15_FINAL_tmp .product_group and org=JAN_DEALER_TGT_2014_15_FINAL_tmp .org ),0) where  (q1_backlog = 1) "
            sql_server_cmd()

            sql = "update JAN_DEALER_TGT_2014_15_FINAL_tmp  set q1_backlog_qty=0 where q1_backlog_qty<0"
            sql_server_cmd()

            ' sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab set clp_price_list = 1 WHERE     (bill_to_customer_id = 1273580) AND (disc = 23.56) and trx_date<'1-jul-2014'"
            ' sql_server_cmd()

            ' sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab  set disc = 25 WHERE     (bill_to_customer_id = 1273580) AND (disc = 23.56)  and trx_date<'1-jul-2014'"
            'sql_server_cmd()


            ' sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab   set clp_price_list = 1 WHERE     (bill_to_customer_id = 1273580) AND (clp_price_list = 0) AND (disc = 25 )  and trx_date<'1-jul-2014'"
            'sql_server_cmd()

            ' sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab set clp_price_list = 1 WHERE     (bill_to_customer_id = 1273580) AND (clp_price_list = 0) AND (disc = 22)  and trx_date<'1-jul-2014'"
            'sql_server_cmd()

            ' sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab set clp_price_list = 1 WHERE     (bill_to_customer_id = 4527) AND (item_no = 'C5100')  and trx_date<'1-jul-2014'"
            'sql_server_cmd()

            'sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab set clp_price_list = 1 WHERE     (bill_to_customer_id = 1992) AND (item_no = 'C7069')  and trx_date<'1-jul-2014'"
            'sql_server_cmd()

            'sql = "UPDATE    JAN_DEALER_SALE_2014_15_tab set disc = 25 WHERE     (bill_to_customer_id = 1093) AND (disc IN (28, 30))  and trx_date<'1-jul-2014'"

            'sql_server_cmd()

            sql = "UPDATE    JAN_DEALER_ORDER_PENDING   set qtr_id = 20141502 WHERE     (customer_id = 315574) AND (qtr_id = 20141501) AND (product_group = 'A23/A24')"

            sql_server_cmd()

            sql = "update jan_data_upload_time set dealer_Target_last_upload_date='" & Format(Date.Now, "dd-MMM-yyyy") & "'"
            sql_server_cmd()

            sql = "update jan_sales_bi_setup set dealer_target_uploaded=sysdate"
            comand()

            Me.Close()
            Exit Sub

            'sql = "SELECT customer_id,nvl(TARGET_INCR_PER_2014_15,0)TARGET_INCR_PER_2014_15,nvl(QTR_VALUE_TO_ACHIEVE_2014_15,0)QTR_VALUE_TO_ACHIEVE_2014_15 FROM jan_dealer_target_base" 'Dealer Sale Increase percentage over previous year
            'adap = New OracleDataAdapter(sql, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            sql = "INSERT INTO jan_dealer_target_base(customer_id,TARGET_INCR_PER_2014_15,QTR_VALUE_TO_ACHIEVE_2014_15) VALUES(" & .Item("CUSTOMER_ID") & "," & .Item("TARGET_INCR_PER_2014_15") & "," & .Item("QTR_VALUE_TO_ACHIEVE_2014_15") & ")"
            '            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception
            '            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload')"
            '            comand()
            '        End Try

            '    End With
            'Next


            'SQL = "SELECT * FROM jan_dealer_sale_2013_14 " 'Sale value 2013-14
            'adap = New OracleDataAdapter(SQL, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            SQL = "INSERT INTO jan_dealer_sale_2013_14(BILL_TO_CUSTOMER_ID,SALE_VALUE) VALUES(" & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("SALE_VALUE") & ")"
            '            cmd_sql = New OleDb.OleDbCommand(SQL, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception

            '        End Try

            '    End With
            'Next

            ''-------UPLOAD DEALER PAYMENT -----

            'SQL = "delete from  JAN_DEALER_PAYMENT"
            'cmd_sql = New OleDb.OleDbCommand(SQL, dms_con)
            'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            'cmd_sql.ExecuteNonQuery()

            'SQL = "SELECT cust_id,payment_exp_date,nvl(PAYMENT_VALUE,0)PAYMENT_VALUE,NVL(AVAIL_VALUE,0)AVAIL_VALUE,NVL(picked_value,0)picked_value,rsv2,PAYMENT_STATUS,flag FROM JAN_DEALER_PAYMENT "
            'adap = New OracleDataAdapter(SQL, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")


            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            SQL = "INSERT INTO JAN_DEALER_PAYMENT(cust_id,payment_exp_date,PAYMENT_VALUE,AVAIL_VALUE,picked_value,rsv2,PAYMENT_STATUS,flag) VALUES(" & .Item("cust_id") & ",'" & Format(.Item("payment_exp_date"), "dd-MMM-yyyy") & "'," & .Item("PAYMENT_VALUE") & "," & .Item("AVAIL_VALUE") & "," & .Item("picked_value") & "," & .Item("rsv2") & ",'" & .Item("PAYMENT_STATUS") & "','" & .Item("flag") & "')"
            '            cmd_sql = New OleDb.OleDbCommand(SQL, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception

            '        End Try

            '    End With
            'Next
            ''-------------
            'DS = New DataSet
            ''SQL = "SELECT * FROM (SELECT JAN_ITEMNAME(ITEM_ID)ITEM_NO,A.* FROM JAN_DSP_LINES A WHERE DSP_ID=20130812 AND AVG_QTY=1 AND ORG_ID=107)B WHERE item_no like 'A%' and length(item_no)>=10 AND ITEM_ID NOT IN (SELECT ITEM_ID FROM JAN_DSP_ITEM_MOQ WHERE ORG_ID=107) AND  BILL_TO_CUST_ID =2197 "

            'SQL = "select * from (select nvl((select count(*) from jan_dsp_lines where dsp_id=20130812 and bill_to_cust_id=a.bill_to_cust_id and org_id=a.org_id and item_id=a.item_id),0)in_full_ord,a.* from jan_dsp_lines  a where dsp_id=201309 ) where  in_full_ord>0"
            'adap = New OracleDataAdapter(SQL, con)
            'adap.Fill(DS, "RES")
            'For i = 0 To DS.Tables("RES").Rows.Count - 1 '************ change DSP_ID = '201303'
            '    With DS.Tables("RES").Rows(i)
            '        'SQL = "insert into jan_dms_moq_details(org_id,item_no,inventory_item_id,moq,creation_date,valid) values(" & .Item("org_id") & ",'" & .Item("item_no") & "'," & .Item("item_id") & "," & .Item("moq_qty") & "," & .Item("dt") & ",0)"

            '        'cmd_sql = New OleDb.OleDbCommand(SQL, dms_con)
            '        'If dms_con.State = ConnectionState.Closed Then dms_con.Open()

            '        'cmd_sql.ExecuteNonQuery()

            '        'SQL = "UPDATE from  jan_dsp_lines  where   (DSP_ID = 201308) AND (BILL_TO_CUST_ID = " & .Item("BILL_TO_CUST_ID") & ") AND (ITEM_ID = " & .Item("ITEM_ID") & ") AND (ORG_ID = " & .Item("ORG_ID") & ") "
            '        'and oe_online_id_1=0"

            '        SQL = "delete from jan_dsp_lines  where   (DSP_LINE_ID = '" & .Item("DSP_LINE_ID") & "')               and oe_online_id_1=0"

            '        cmd_sql = New OleDb.OleDbCommand(SQL, dms_con)
            '        If dms_con.State = ConnectionState.Closed Then dms_con.Open()

            '        cmd_sql.ExecuteNonQuery()
            '    End With

            'Next
            'DS = New DataSet
            'SQL = "SELECT     * from jan_tmp"
            'adap_sql = New OleDb.OleDbDataAdapter(SQL, dms_con)
            'adap_sql.Fill(DS, "RES")
            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)
            '        SQL = "insert into  jan_tmp values(" & .Item("dsp_line_id") & ")"


            '        cmd = New OracleCommand(SQL, con)
            '        If con.State = ConnectionState.Closed Then con.Open()
            '        cmd.ExecuteNonQuery()
            '    End With

            'Next

            'Me.Close()
            'DS = New DataSet
            'SQL = "SELECT     dsp_id,dsp_line_id,dsp_quantity,bill_to_cust_id  FROM jan_dsp_lines WHERE      (review_status = 'A') "

            ''adap = New OleDb.OleDbDataAdapter(SQL, dms_con)
            ''adap.Fill(DS, "SQLTAB")


            'For i = 0 To DS.Tables("SQLTAB").Rows.Count - 1
            '    With DS.Tables("SQLTAB").Rows(i)
            '        'SQL = "INSERT INTO  JAN_DSP_DEC(BILL_TO_CUST_ID , DSP_ID ,ORG_ID,CATEGORY_NAME, DSP_QUANTITY ,DISC , INVENTORY_ITEM_ID , CLP ) "

            '        'SQL += " VALUES( " & .Item("BILL_TO_CUST_ID") & " ," & .Item("DSP_ID") & " ," & .Item("ORG_ID") & " ,'" & .Item("CATEGORY_NAME") & "'," & .Item("DSP_QUANTITY") & " ," & .Item("DISC") & " ," & .Item("INVENTORY_ITEM_ID") & "  ," & .Item("CLP") & "   )"
            '        SQL = "update jan_dsp_lines  set dsp_quantity=" & .Item("DSP_QUANTITY") & " where dsp_line_id=" & .Item("dsp_line_id") & " and DSP_ID = " & .Item("DSP_ID") & " and  review_status = 'A' and bill_to_cust_id=" & .Item("bill_to_cust_id") & " "
            '        cmd = New OracleCommand(SQL, con)
            '        If con.State = ConnectionState.Closed Then con.Open()
            '        cmd.ExecuteNonQuery()


            '    End With

            'Next
        Catch ex As Exception

            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,starting')"
            comand()
        End Try

    End Sub
    Private Sub target_upload_2015_16_q2()

        'sql = "select customer_id from ra_customers where customer_class_code='DEALER'  AND CUSTOMER_ID =1582" 'in ( 1198,1582)"
        'adap = New OracleDataAdapter(sql, con)
        'TDS.Tables.Clear()
        'adap.Fill(TDS, "cust")
        ''For j = 0 To TDS.Tables("cust").Rows.Count - 1
        'Dim cust_id As Integer = TDS.Tables("cust").Rows(j).Item("customer_id")


        'sql = "delete from JAN_DEALER_PRODUCT_201516_Q2 "
        'comand()

        'sql = "insert into JAN_DEALER_PRODUCT_201516_Q2 select ORG,BILL_TO_CUST_NAME,case when AMEND_QTY=0 then moq else (CEIL(Q2_QTY/MOQ) * MOQ) end Q2_QTY,case  when AMEND_QTY=0 and rev_per=0 then moq  when AMEND_QTY=0 and rev_per>0 then moq when  AMEND_QTY>0 and rev_per>0 and product_group not in ('Tube cutter','PU Tube','Blow gun') then  (CEIL((AMEND_QTY*((100-REV_PER)/100))/MOQ) * MOQ) when  AMEND_QTY>0 and rev_per>0 and product_group  in ('Tube cutter','PU Tube','Blow gun') then  (CEIL(AMEND_QTY/MOQ) * MOQ) WHEN  AMEND_QTY>0 AND REV_PER=0  THEN (CEIL(AMEND_QTY/MOQ) * MOQ) end AMEND_QTY,PRODUCT_GROUP ,0 ADDITIONAL_PROD_GROUP from (select ORG,BILL_TO_CUST_NAME,SUM(Q2_REVISED_QTY)Q2_QTY,SUM(AMENDED_QTY)AMEND_QTY,PRODUCT_GROUP,case  when ORG='I02' then 10   when ORG='I03' then 5  when ORG ='I04' then 10 when ORG='I05' and PRODUCT_GROUP='PU Tube' then 100 when ORG='I05' and PRODUCT_GROUP<>'PU Tube' then 25 end MOQ,(SELECT revised_per FROM JAN_DEALER_TGT_2015_16 where customer_id=a.bill_to_customer_id)rev_per from JAN_DEALER_TARGET_2015_16_TAB2 a where BILL_TO_CUSTOMER_ID=" & cust_id & " group by ORG, BILL_TO_CUST_NAME, PRODUCT_GROUP,bill_to_customer_id)b"
        'comand()

        'sql = "select * from (select a.*,NVL((select COUNT(*) from JAN_DEALER_PRODUCT_201516_Q2 where ORG=a.ORG and PRODUCT_GROUP=a.PRODUCT_GROUP),0)CNT from JAN_DEALER_PRODUCT_201516 a) where cnt=0"
        'adap = New OracleDataAdapter(sql, con)
        'DS.Tables.Clear()
        'adap.Fill(DS, "data")

        'For i = 0 To DS.Tables("data").Rows.Count - 1
        '    With DS.Tables("data").Rows(i)
        '        sql = "insert into  JAN_DEALER_PRODUCT_201516_Q2 (org,bill_to_cust_Name,recomended_qty ,revised_qty,product_group,ADDITIONAL_PROD_GROUP) values('" & .Item("org") & "',(select customer_name from ra_customers where customer_id=" & cust_id & ")," & .Item("moq") & "," & .Item("moq") & ",'" & .Item("product_group") & "',1)"
        '        comand()
        '    End With
        'Next

        'sql = "select a.*,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.product_group and rownum=1),400)prod_group_ord,(select customer_id from ra_customers where customer_name=a.bill_to_cust_name)bill_to_customer_id from JAN_DEALER_PRODUCT_201516_Q2  a where bill_to_cust_name=(select customer_NAme from ra_customers where customer_id=" & cust_id & ") "

        'sql = "SELECT B.*,nvl((select group_ord from jan_dealer_target_prod_group where group_name=B.PRODUCT_GROUP and rownum=1),60)prod_group_ord,(select customer_id from ra_customers where customer_name=B.bill_to_cust_name)bill_to_customer_id FROM (select ORG,BILL_TO_CUST_NAME,SUM(RECOMENDED_QTY)RECOMENDED_QTY,SUM(REVISED_QTY)REVISED_QTY,PRODUCT_GROUP_NEW PRODUCT_GROUP,ADDITIONAL_PROD_GROUP_NEW ADDITIONAL_PROD_GROUP  FROM (select  a.* ,case when PRODUCT_GROUP in ('A12/A13','A27/A28') then 'A12/A13/A27/A28' else PRODUCT_GROUP end PRODUCT_GROUP_NEW ,case when PRODUCT_GROUP in ('A12/A13','A27/A28') then 1 else ADDITIONAL_PROD_GROUP end ADDITIONAL_PROD_GROUP_NEW from JAN_DEALER_PRODUCT_201516_Q2 a) group by ORG, BILL_TO_CUST_NAME, PRODUCT_GROUP_NEW, ADDITIONAL_PROD_GROUP_NEW)B" 'WHERE PRODUCT_GROUP_NEW='A12/A13/A27/A28' 

        'sql = "SELECT B.*,NVL((SELECT GROUP_ORD FROM JAN_DEALER_TARGET_PROD_GROUP WHERE GROUP_NAME=B.PRODUCT_GROUP AND ROWNUM=1),60)PROD_GROUP_ORD,(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_NAME=B.BILL_TO_CUST_NAME)BILL_TO_CUSTOMER_ID FROM (SELECT ORG,DEALER_NAME BILL_TO_CUST_NAME,SUM(TARGET_QTY_Q2_1516)RECOMENDED_QTY,SUM(REVISED_TARGET_QTY_Q2)REVISED_QTY, PRODUCT_GROUP_NEW PRODUCT_GROUP,ADDITIONAL_PROD_GROUP_NEW ADDITIONAL_PROD_GROUP  FROM (SELECT  A.* ,CASE WHEN PRODUCT_GROUP IN ('A12/A13','A27/A28') THEN 'A12/A13/A27/A28' ELSE PRODUCT_GROUP END PRODUCT_GROUP_NEW ,CASE WHEN PRODUCT_GROUP IN ('A12/A13','A27/A28') THEN 1 ELSE revision_status END ADDITIONAL_PROD_GROUP_NEW FROM JAN_DEALER_TGT_2015_16_Q2 A where dealer_name='INDUSTRIAL EQUIPMENTS CORPORATION') GROUP BY ORG, DEALER_NAME, PRODUCT_GROUP_NEW, ADDITIONAL_PROD_GROUP_NEW)B"

        'sql = "select (select CUSTOMER_ID  from RA_CUSTOMERS where CUSTOMER_NAME =a.DEALER_NAME)BILL_TO_CUSTOMER_ID,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.PRODUCT_GROUP and rownum=1),60)prod_group_ord,a.* from jan_dealer_product_group a "
        sql = " SELECT B.*,ROWNUM SL_NO FROM (SELECT A.*,CASE WHEN ORG='I25' THEN (CEIL(FINAL_TARGET_QTY/25) * 25)  ELSE (CEIL(FINAL_TARGET_QTY/5) * 5)  END FINAL_TARGET_QTY_AFTER_ROUND ,(CASE WHEN ORG='I25' THEN (CEIL(FINAL_TARGET_QTY/25) * 25)  ELSE (CEIL(FINAL_TARGET_QTY/5) * 5)  END ) *4 FINAL_YEARLY_TARGET ,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.BILL_TO_CUSTOMER_ID)CUSTOMER_NAME   from jan_it.jan_dealer_product_201718 a  where bill_to_customer_id in (3435597,3481592,3475594) order by org,GROUP_ORD)b"
        sql = "select b.*,rownum sl_no from (select (select customer_name from ra_customers where customer_id=a.bill_to_customer_id)dealer_name,a.*,(4*final_target)FINAL_yearly_target from jan_dealer_target_Qty_201819 a where bill_to_customer_id=2280588 order by org,GROUP_ORD )b"
        sql = "select b.*,rownum sl_no,target_qty final_target from(select a.* ,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.PRODUCT_GROUP and rownum=1),60)group_ord from jan_exp_dealer_tgt a)b order by org,GROUP_ORD "

        sql = "select b.*,rownum sl_no from(select a.* ,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.PRODUCT_GROUP and rownum=1),60)group_ord_new from jan_exp_gate2_10jul2019 a where target_for_201920 is not null)b order by org,GROUP_ORD_new "

        sql = "select b.*,rownum sl_no from(select a.* ,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.PRODUCT_GROUP and rownum=1),60)group_ord_new from jan_africa_gate2 a where target_for_201920 is not null)b order by org,GROUP_ORD_new "

        sql = "select b.*,rownum sl_no from(select a.* ,nvl((select group_ord from jan_dealer_target_prod_group where group_name=a.PRODUCT_GROUP and rownum=1),60)group_ord_new from jan_dealer_gate2_revised a )b order by org,GROUP_ORD_new "

        sql = "select * from jan_dealer_category_crm1 union all select * from jan_dealer_category_crm2 "
        sql = "select * from jan_scheme_item_2020_21 "
        sql = "select * from jan_scheme_moq_june_2020 "
        sql = "select 484 org_id,k.*,jan_itemno(part_no)item_id from jan_otf_scheme_2020_21 k"
        sql = "select unique_id flow_meter_id,round(flow_average,2) air_flow,run_idle Running_ideal ,flow_date reading_date ,REPLACE(flow_time_new,'.',':') reading_time,substr(unique_id,6) unit_code from jan_fms_sample_data "

        sql = "SELECT customer_id,sum(cast(exchange_AMOUNT_DR as float)-cast(exchange_AMOUNT_cR as float)) opbal2 FROM jan_ar_ledger_ex  
where ar_date<(select LAST_DATE from JAN_DMS_DATA_STATUS where UPLOAD_FOR='AR_LED_FRM_DT') group by customer_id "
        'sql = " select * from jan_dealer_scheme_moq_revised "
        sql = " select * from JAN_TEX_MILL_VS_MACHINE where upper(mill_name) = 'SOUTHERN COTSPINNERS COIMBATORE [P] LTD.,' AND END_DATE IS NULL "
        'sql = " select A.*,(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_NAME=A.DEALER_NAME_)CUSTOMER_ID from JAN_DEALER_TGT_2021_22 A "
        'sql = " select (select customer_id from ra_customers where customer_name=a.bill_to_cust_name)customer_id,a.* from jan_dealer_tgt_202021 a "
        adap = New OracleDataAdapter(sql, con)
        DS.Tables.Clear()
        adap.Fill(DS, "data")

        'sql = "select * from jan_flow_minute_data WHERE FLOW_DATE<'2021-02-01'"
        'sql = "select A.*,(select DISTINCT CUSTOMER_ID from JAN_FMS_CUSTOMER_MASTER)CUSTOMER_ID   from jan_flow_minute_data A  WHERE FLOW_DATE<'2021-02-01'"
        'sql = "select * from jan_fms_mill_vs_machine WHERE alert_flow_running IS NOT NULL"
        'DS = SQL_SELECT_mysql("data", sql)


        For i = 0 To DS.Tables("data").Rows.Count - 1
            With DS.Tables("data").Rows(i)

                'sql = " insert into JAN_DEALER_TOD_TARGET_BASE(customer_id,total_tod_target,tod_q1,tod_q2,tod_q3,tod_q4,Fin_year ) values(" & .Item("customer_id") & "," & .Item("YEARLY_TGT") & "," & .Item("qtr_target") & "," & .Item("qtr_target") & "," & .Item("qtr_target") & "," & .Item("qtr_target") & ",202122)"
                'sql = "update Jan_dealer_tier_detail set min_order_qty=" & .Item("tier_4") & " where  customer_id=0 and tier=4 and product_group='" & .Item("PRODUCT_group") & "' "
                'sql = " Update  jan_ar_ledger_op_balst set balance=" & .Item("opbal2") & " where customer_id=" & .Item("customer_id") & ""

                'sql = "insert into jan_ar_ledger_op_balst (customer_id,balance) values(" & .Item("customer_id") & "," & .Item("balance") & ")"
                'sql = "insert into jan_flow_meter_lines(flow_meter_id,air_flow,Running_ideal ,reading_date ,reading_time_1,unit_code) values('" & .Item("flow_meter_id") & "'," & .Item("air_flow") & "," & .Item("Running_ideal") & ",'" & Format(.Item("reading_date"), "dd-MMM-yyyy") & "','" & .Item("reading_time") & "'," & .Item("unit_code") & ")"

                'sql = " insert into jan_flow_meter_lines_STG(flow_meter_id,air_flow,Running_idea,reading_date,unit_code,reading_time,GROUP_ID) values()"
                'FMS UPLOAS
                'If i = 0 Then
                '    sql = "insert into JAN_FMS_CUSTOMER_MASTER(customer_id,customer_name,creation_date,last_update_date,CUSTOMER_AUTHENTICATION_STATUS) values(" & .Item("CUSTOMER_ID") & ",'" & .Item("mill_name") & "',SYSDATE(),SYSDATE(),'N')"
                '    'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                '    'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                '    'cmd_sql.ExecuteNonQuery()
                '    Execute_Query_mysql_rds(sql)
                'End If
                'sql = "insert into jan_FMS_MILL_VS_MACHINE(CUSTOMER_ID,MACHINE_MAKE,MACHINE_MODEL,MACHINE_NAME,NO_OF_MACHINES,CREATION_DATE,LAST_UPDATE_DATE "

                'If Not IsDBNull(.Item("end_DATE")) Then sql &= " ,end_date "

                'sql &= " ) values(" & .Item("CUSTOMER_ID") & ",'" & .Item("MACHINE_MAKE") & "','" & .Item("MODEL_NO") & "','" & .Item("MACHINE_NAME") & "'," & .Item("QTY") & ",SYSDATE(),SYSDATE() "
                'If Not IsDBNull(.Item("end_DATE")) Then sql &= " ,'" & Format(.Item("end_DATE"), "dd-MMM-yyyy") & "' "
                'sql &= " )"
                'Execute_Query_mysql_rds(sql)

                'sql = "insert into jan_flow_minute_data(CUSTOMER_ID,SLAVE_ID,GROUP_ID,AVG_FLOW_VALUE,DIGITAL_INPUT,FLOW_DATE,SHIFT_NO,HOUR_NO,MINUTE_NO) values(" & .Item("CUSTOMER_ID") & ",'" & .Item("SLAVE_ID") & "','" & .Item("GROUP_ID") & "','" & .Item("AVG_FLOW_VALUE") & "','" & .Item("DIGITAL_INPUT") & "','" & Format(.Item("FLOW_DATE"), "dd-MMM-yyyy") & "','" & .Item("SHIFT_NO") & "','" & .Item("HOUR_NO") & "','" & .Item("MINUTE_NO") & "')"

                'sql = "insert into jan_fms_mill_vs_machine_maped(CUSTOMER_ID,	dept,		MACHINE_NAME,	MACHINE_MAKE,	MACHINE_MODEL,	FLOW_METER_ID,	creation_date,	last_update_date,	recommended_flow_running,	recommended_flow_idle,	alert_flow_running,	alert_flow_idle "
                'If Not IsDBNull(.Item("END_DATE")) Then sql &= " ,END_DATE "
                'sql &= ") values(" & .Item("CUSTOMER_ID") & ",'" & .Item("dept") & "','" & .Item("MACHINE_NAME") & "','" & .Item("MACHINE_MAKE") & "','" & .Item("MACHINE_MODEL") & "','" & .Item("FLOW_METER_ID") & "','" & Format(.Item("creation_DATE"), "dd-MMM-yyyy") & "','" & Format(.Item("last_update_date"), "dd-MMM-yyyy") & "'," & .Item("recommended_flow_running") & "," & .Item("recommended_flow_idle") & "," & .Item("alert_flow_running") & "," & .Item("alert_flow_idle") & ""
                'If Not IsDBNull(.Item("END_DATE")) Then sql &= " ,'" & Format(.Item("END_DATE"), "dd-MMM-yyyy") & "'"
                'sql &= " )"
                'sql = "INSERT INTO jan_dsp_scheme_items (ITEM_ID,ORG_ID,DISC_PER,ACTIVE_FLAG)  VALUES(" & .Item("ITEM_ID") & ",'" & .Item("ORG_ID") & "',35,2)"

                'sql = "INSERT INTO Jan_dealer_tier_detail (customer_id,tier,product_group,min_order_qty)  VALUES(0," & .Item("tier_no") & ",'" & .Item("PRODUCT_SERIES") & "'," & .Item("tier_moq") & ")"

                'sql = "INSERT INTO JAN_DEALER_TGT_2015_16_FINAL(ORG,PRODUCT_GROUP,total_SALE_QTY ,total_SALE_VALUE,Q1_QTY,Q2_QTY,Q3_QTY,Q4_QTY,BILL_TO_CUSTOMER_ID,order_by,q1_value,q2_value,q3_value,q4_value,q1_qty_revised,q2_qty_revised,fin_year) VALUES('" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "',0,0," & .Item("target_for_q1") & "," & .Item("target_for_q2") & "," & .Item("target_for_q3") & " ," & .Item("target_for_q4") & "," & .Item("customer_id") & "," & .Item("GROUP_ORD_new").ToString & ",0,0,0,0,1,1,201920)"

                'If .Item("additional_prod_group") = 1 Then
                'sql = "INSERT INTO JAN_DEALER_TGT_2015_16_FINAL(ORG,PRODUCT_GROUP,total_SALE_QTY ,total_SALE_VALUE,Q1_QTY,Q2_QTY,Q3_QTY,Q4_QTY,BILL_TO_CUSTOMER_ID,order_by,q1_value,q2_value,q3_value,q4_value,q1_qty_revised,q2_qty_revised) VALUES('" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "',0,0,0," & .Item("revised_QTY") & "," & .Item("revised_QTY") & " ," & .Item("revised_QTY") & "," & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("prod_group_ord").ToString & ",0,0,0,0,1,1)"
                'Else
                'sql = "update JAN_DEALER_TGT_2015_16_FINAL set Q1_QTY=0,q2_qty=" & .Item("revised_q1_q2_qty") & "  where bill_to_customer_id=" & .Item("CUSTOMER_ID") & " and org='" & .Item("org") & "' and product_group='" & .Item("product_group") & "' and Fin_year=201920"
                'End If'
                'sql = "update dms_custs_log_in_tab set customer_category='" & .Item("category") & "'  where customer_id=" & .Item("ID") & " and  CUSTOMER_CLASS_CODE='DEALER'"


                'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                'cmd_sql.ExecuteNonQuery()
            End With

        Next


        sql = " select a.* ,(select customer_id from ra_customers where customer_name=a.dealer_name)customer_id from jan_dealer_gate1_q3_revised a "
        adap = New OracleDataAdapter(sql, con)
        DS.Tables.Clear()
        adap.Fill(DS, "data")

        For i = 0 To DS.Tables("data").Rows.Count - 1
            With DS.Tables("data").Rows(i)
                sql = "update JAN_DEALER_TOD_TARGET_BASE set tod_Q3=" & .Item("Revised_Q3_Tgt") & " ,q3_gate1=1 where customer_id=" & .Item("CUSTOMER_ID") & "   and Fin_year=201920"
                'End If


                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()
            End With
        Next


        sql = " select (select customer_id from ra_customers where customer_name=a.dealer_name)customer_id,a.* from jan_dealer_Tier_detail a "
        adap = New OracleDataAdapter(sql, con)
        DS.Tables.Clear()
        adap.Fill(DS, "data")

        For i = 0 To DS.Tables("data").Rows.Count - 1
            With DS.Tables("data").Rows(i)
                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'FRC'," & .Item("frc") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()

                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'FRCLM'," & .Item("FRCLM") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()

                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'DS2_QUATER_INCH'," & .Item("DS2_QUATER_INCH") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()

                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'DS2_HALF_INCH'," & .Item("DS2_HALF_INCH") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()


                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'DMN'," & .Item("DMN") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()


                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'A02_A03'," & .Item("A02_A03") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()

                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'A51_A52'," & .Item("A51_A52") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()


                sql = "insert into  Jan_dealer_tier_detail(customer_id,tier,product_group,min_order_qty)  values(" & .Item("customer_id") & " ," & .Item("tier").ToString.Substring(1, 1) & ",'BLUE_PU_TUBE'," & .Item("BLUE_PU_TUBE") & " )"
                cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                cmd_sql.ExecuteNonQuery()
            End With
        Next


    End Sub
    Private Sub export_from_excel()

        Dim fi As New FileInfo("D:\projects\FMS\Flow meter\out\20201030.csv")
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & fi.DirectoryName
        Dim READING_DATE As Date = "2020-10-30"
        Dim conn As New OleDbConnection(connectionString)
        conn.Open()

        'the SELECT statement is important here, 
        'and requires some formatting to pull dates and deal with headers with spaces.
        'Dim cmdSelect As New OleDbCommand("SELECT Foo, Bar, FORMAT(""SomeDate"",'YYYY/MM/DD') AS SomeDate, ""SOME MULTI WORD COL"", FROM " & fi.Name, conn)
        Dim cmdSelect As New OleDbCommand("SELECT * FROM " & fi.Name, conn)
        Dim adapter1 As New OleDbDataAdapter
        adapter1.SelectCommand = cmdSelect

        Dim ds As New DataSet
        adapter1.Fill(ds, "DATA")

        DataGridView1.DataSource = ds.Tables(0).DefaultView
        conn.Close()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(i)
                Try
                    sql = " insert into jan_flow_meter_lines_STG(flow_meter_id,air_flow,Running_ideal,reading_date,reading_time,GROUP_ID) values('" & .Item("SLAVE_ID") & "'," & .Item("FLOW_VALUE") & "," & .Item("DIGITAL_INPUT") & " "
                    sql &= "  ,'" & Convert.ToDateTime(.Item("date")) & "' "
                    'sql &= ",'2020-10-17' "
                    sql &= ",'" & .Item("time").ToString.Substring(0, 8) & "'"
                    sql &= " ,'" & .Item("GROUP_ID") & "')"

                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()

                Catch ex As Exception

                End Try
            End With
        Next

        sql = "delete from jan_flow_meter_lines WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
        sql = " insert into jan_flow_meter_lines(flow_meter_id,air_flow,running_ideal,reading_date,reading_time_1,group_id)

select flow_meter_id,round(avg(air_flow),2)air_flow,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm'))ss,group_id
from jan_flow_meter_lines_STG a WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'
group by flow_meter_id,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm')),group_id"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
        Exit Sub

        Dim filePath As String = "D:\projects\FMS\Flow meter\out\2020-10-30.xls"
        Dim extension As String = Path.GetExtension(filePath)
        Dim conStr As String, sheetName As String

        conStr = String.Empty
        Select Case extension

            Case ".xls"
                conStr = String.Format(xl_con, filePath, "YES")
                Exit Select
        End Select


        Using xl_con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                cmd.Connection = xl_con
                xl_con.Open()
                Dim dtExcelSchema As DataTable = xl_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                'sheetName = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
                'sheetName = dtExcelSchema.Rows(0)( ("TABLE_NAME").ToString()

                sheetName = "2020-10-30$"

                xl_con.Close()
            End Using
        End Using

        Dim dt As New DataTable()
        Using xl_con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                Using oda As New OleDbDataAdapter()

                    cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                    cmd.Connection = xl_con
                    xl_con.Open()
                    oda.SelectCommand = cmd
                    oda.Fill(dt)
                    xl_con.Close()


                    'DataGridView1.DataSource = dt
                End Using
            End Using
        End Using
        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                Try
                    'Dim dateTime As String = "24-11-2015"
                    'Dim dat As DateTime = Convert.ToDateTime(dateTime)
                    'Dim format As String = "dd-MM-yyyy"
                    'Dim str As String = dat.ToString(format)
                    ''dateTime = "20/05/2012"
                    ''dat = dateTime.ParseExact(DateString, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture)

                    'Dim strDate As String = .Item("date")



                    'Dim dateTime As String = .Item("reading_DATE")
                    'Dim dat As DateTime = Convert.ToDateTime(dateTime)
                    'Dim format As String = "dd/MM/yyyy"
                    'Dim str As String = dat.ToString(format)

                    'Dim d As String = .Item("DATE").ToString
                    'Dim dat = DateTime.ParseExact(d, "yyyy-MM-dd", Nothing)

                    'Const MyDateFormat As String = "ddMMyyyy"

                    ''Dim dte As Date = #2/1/2003#
                    '''convert the date to a string
                    'Dim strDate As String = .Item("date")
                    ''convert the string back to a date
                    'Dim dte2 As Date = Date.ParseExact(strDate, MyDateFormat, System.Globalization.CultureInfo.InvariantCulture)


                    sql = " insert into jan_flow_meter_lines_STG(flow_meter_id,air_flow,Running_ideal,reading_date,reading_time,GROUP_ID) values('" & .Item("SLAVE_ID") & "'," & .Item("FLOW_VALUE") & "," & .Item("DIGITAL_INPUT") & " "
                    sql &= "  ,'" & Convert.ToDateTime(.Item("date")) & "' "
                    'sql &= ",'2020-10-17' "
                    sql &= ",'" & .Item("time").ToString.Substring(0, 8) & "'"
                    sql &= " ,'" & .Item("GROUP_ID") & "')"

                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()

                Catch ex As Exception

                End Try
            End With
        Next

        sql = "delete from jan_flow_meter_lines WHERE reading_date='" & READING_DATE & "'"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
        sql = " insert into jan_flow_meter_lines(flow_meter_id,air_flow,running_ideal,reading_date,reading_time_1,group_id)

select flow_meter_id,round(avg(air_flow),2)air_flow,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm'))ss,group_id
from jan_flow_meter_lines_STG a WHERE reading_date='" & READING_DATE & "'
group by flow_meter_id,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm')),group_id"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()

    End Sub
    Private Sub sale_2014_15_download()


        sql = "select * FROM     JAN_DEALER_ORDER_PENDING where customer_id  in (1093)" '  and trx_date>='1-dec-2014'   and trx_date<'1-jan-2015'"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        DS = New DataSet
        adap_sql.Fill(DS, "RES")

        For i = 0 To DS.Tables("RES").Rows.Count - 1
            With DS.Tables("RES").Rows(i)
                Try

                    sql = "insert into JAN_DEALER_ORDER_PENDING(CUSTOMER_ID , ORDER_DATE , ORG , PRODUCT_GROUP , ITEM_NO , qtr_id , dealer_ord_pend )"

                    sql &= " values(" & .Item("CUSTOMER_ID") & ",'" & Format(.Item("ORDER_DATE"), "dd-MMM-yyyy") & "','" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "','" & .Item("ITEM_NO") & "'," & .Item("qtr_id") & "," & .Item("dealer_ord_pend") & ")"
                    cmd = New OracleCommand(sql, con)
                    If con.State = ConnectionState.Closed Then con.Open()

                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer sale download')"
                    comand()
                End Try

            End With
        Next

        sql = "select * FROM JAN_DEALER_SALE_2014_15_tab where bilL_to_customer_id in (1183,1665,1827)" '  and trx_date>='1-dec-2014'   and trx_date<'1-jan-2015'"
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        DS = New DataSet
        adap_sql.Fill(DS, "RES")

        For i = 0 To DS.Tables("RES").Rows.Count - 1
            With DS.Tables("RES").Rows(i)
                Try

                    sql = "insert into JAN_DEALER_SALE_2014_15_T(BILL_TO_CUSTOMER_ID ,TRX_NUMBER ,TRX_DATE , QUANTITY_INVOICED , SALE_VALUE_WITHOUT_TAX , ORG , PRODUCT_GROUP, ITEM_NO, TOD_ITEM , DISC , CLP_PRICE_LIST ,UNIT_SELLING_PRICE,UNIT_STANDARD_PRICE , ORDER_TYPE )"

                    sql &= " values(" & .Item("BILL_TO_CUSTOMER_ID") & ",'" & .Item("TRX_NUMBER") & "','" & Format(.Item("TRX_DATE"), "dd-MMM-yyyy") & "'," & .Item("QUANTITY_INVOICED") & "," & .Item("SALE_VALUE_WITHOUT_TAX") & ",'" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "','" & .Item("ITEM_NO") & "'," & .Item("TOD_ITEM") & "," & .Item("DISC") & "," & .Item("CLP_PRICE_LIST") & "," & .Item("UNIT_SELLING_PRICE") & "," & .Item("UNIT_STANDARD_PRICE") & ",'" & .Item("ORDER_TYPE") & "')"
                    cmd = New OracleCommand(sql, con)
                    If con.State = ConnectionState.Closed Then con.Open()

                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer sale download')"
                    comand()
                End Try

            End With
        Next

    End Sub
    Private Sub target_upload_2015_16()

        'sql = "select b.*,case when Q1_QTY<>amended_qty then 1 else 0 end qty_revised from (select a.*  ,nvl((SELECT GROUP_ORD  FROM jan_dealer_target_prod_group  WHERE GROUP_NAME=a.product_group AND ROWNUM=1  ),1000)ORDER_BY from (select ORG,BILL_TO_CUSTOMER_ID,PRODUCT_GROUP,SUM(Q1_REVISED_QTY)Q1_QTY,SUM(Q2_REVISED_QTY)Q2_QTY,SUM(Q3_REVISED_QTY)Q3_QTY,SUM(Q4_REVISED_QTY)Q4_QTY,round(SUM(total_SALE_VAL)/100000,2)total_sale_val,sum(total_sale_qty)total_sale_qty,round(sum(q1_revised_qty*p_rate)/100000,2)q1_value ,round(sum(q2_revised_qty*p_rate)/100000,2)q2_value,round(sum(q3_revised_qty*p_rate)/100000,2)q3_value,round(sum(q4_revised_qty*p_rate)/100000,2)q4_value ,sum(amended_qty)amended_qty from JAN_DEALER_TARGET_2015_16_TAB2    where bill_to_customer_id  in (1198) group by ORG, BILL_TO_CUSTOMER_ID, PRODUCT_GROUP)a)b"
        '3031590, 2156, 1928584, 2034, 1596, 75555, 2138584where bill_to_customer_id  in ( 1658)

        '8 % Reduction
        'sql = "select b.*,case when Q1_QTY<>amended_qty then 1 else 0 end qty_revised from (select a.*  ,nvl((SELECT GROUP_ORD  FROM jan_dealer_target_prod_group  WHERE GROUP_NAME=a.product_group AND ROWNUM=1  ),1000)ORDER_BY from (select ORG,BILL_TO_CUSTOMER_ID,PRODUCT_GROUP,SUM(Q1_REVISED_QTY)Q1_QTY,SUM(Q2_REVISED_QTY)Q2_QTY,SUM(Q3_REVISED_QTY)Q3_QTY,SUM(Q4_REVISED_QTY)Q4_QTY,round(SUM(total_SALE_VAL)/100000,2)total_sale_val,sum(total_sale_qty)total_sale_qty,round(sum(q1_revised_qty*p_rate)/100000,2)q1_value ,round(sum(q2_revised_qty*p_rate)/100000,2)q2_value,round(sum(q3_revised_qty*p_rate)/100000,2)q3_value,round(sum(q4_revised_qty*p_rate)/100000,2)q4_value ,Case When Product_Group In ('Blow gun','PU Tube','Tube cutter')  Then Sum(Q1_Revised_Qty) Else Round(Sum(Q1_Revised_Qty)*.92) End Amended_Qty from JAN_DEALER_TARGET_2015_16_TAB2  where bill_to_customer_id  in (1582) group by ORG, BILL_TO_CUSTOMER_ID, PRODUCT_GROUP)a)b" '384570,775580,2234588,1164,1666,1247,1842,379571,833580,2280588,1890,2000,819583

        'sql = "select a.*,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP where GROUP_NAME=a.PRODUCT_GROUP and rownum=1)GROUP_ORD from ( select CUSTOMER_ID,ORG,PRODUCT_GROUP,TOTAL_SALE_QTY SALE_15_16,PROPOSED_QTY TARGET_1617,QTRLY_QTY_FINAL TARGET_QTR from JAN_DEALER_TARGET_2016_17  union select customer_id,ORG,PRODUCT_GROUP,TOTAL_SALE_QTY,ROUND(TOTAL_TARGET)TOTAL_TARGET,QTRLY_AFTER_ROUNDING from JAN_DEALER_QTY_TARGET_201617 )a WHERE CUSTOMER_ID=1520  order by ORG,GROUP_ORD"
        'sql = "SELECT A.*,(SELECT GROUP_ORD FROM JAN_DEALER_TARGET_PROD_GROUP WHERE GROUP_NAME=A.PRODUCT_GROUP AND ROWNUM=1)GROUP_ORD FROM (SELECT 3102590 CUSTOMER_ID,ORG,PRODUCT_GROUP,0 SALE_15_16,QTY*4  TARGET_1617,QTY  TARGET_QTR FROM jan_dealer_tgt_1617_dealer )a   order by ORG,GROUP_ORD"
        sql = " select rownum sl_no,c.* from (select B.* ,case when Q3_INCR_PER is not null  and ORG<>'I25' then JAN_IT.JAN_NEAR5(Q3_QTY*(1+(Q3_INCR_PER/100))) when Q3_INCR_PER is not null  and ORG='I25' and PRODUCT_GROUP <>'PU Tube'  then JAN_IT.JAN_NEAR25(Q3_QTY*(1+(Q3_INCR_PER/100))) when q3_incr_per is not null  and org='I25' and product_group ='PU Tube'  then Q3_QTY+1000 else Q3_QTY  end revised_q3_target  from (select  customer_id ,(select CUSTOMER_NAME from RA_CUSTOMERS where CUSTOMER_ID=a.CUSTOMER_ID)CUST_NAME ,ORG,PRODUCT_GROUP,Q1_QTY Q1_TGT ,Q1_ACHIEVED , CASE WHEN  Q1_ACHIEVED>=Q1_QTY  THEN 'Yes' else 'No' end q1_achieved_status,Q2_QTY Q2_TgT ,Q2_ACHIEVED ,case when  Q2_ACHIEVED>=Q2_QTY  then 'Yes' else 'No' end Q2_ACHIEVED_STATUS,case when (Q1_ACHIEVED>=Q1_QTY) and (Q2_ACHIEVED>=Q2_QTY)  THEN '2' else null end  q3_incr_per ,Q3_QTY,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP WHERE GROUP_NAME=A.PRODUCT_GROUP AND ROWNUM=1)GROUP_ORD FROM JAN_IT.JAN_DEALER_QUANTITY_TGT_201617  A WHERE CUSTOMER_ID in (2104585) ORDER BY ORG,PRODUCT_GROUP)b order by GROUP_ORD)c"

        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")
        'in (1449,1942,1687,1561,2649588,775580,1417,1276,1817,315574,1379,842580,1992,513578,384570,1250,1449,1273580,2013,1194580,1964584,1242,2000,1357 ,2593588,1242,2593588,1194580,2000,1997584,819583,1357,1248,1890,2104585,1561,1329,2412,1744584,1813,1936,1573,2038,2711590,1164,2689592,1520,379571,4527,2234588,2643588,2280588) 1226,833580,1425,1842,1666,2197,1410, 1942,1247,2727590,1093,2240,1746,1868,1693,647578,4535
        For i = 0 To DS.Tables("res").Rows.Count - 1
            With DS.Tables("res").Rows(i)


                Try
                    'sql = "INSERT INTO JAN_DEALER_TGT_2015_16_FINAL(ORG,PRODUCT_GROUP,total_SALE_QTY ,total_SALE_VALUE,Q1_QTY,Q2_QTY,Q3_QTY,Q4_QTY,BILL_TO_CUSTOMER_ID,order_by,q1_value,q2_value,q3_value,q4_value,q1_qty_revised) VALUES('" & .Item("ORG") & "','" & .Item("PRODUCT_GROUP") & "',0,0," & .Item("TARGET_QTR") & "," & .Item("TARGET_QTR") & "," & .Item("TARGET_QTR") & " ," & .Item("TARGET_QTR") & "," & .Item("CUSTOMER_ID") & "," & .Item("GROUP_ORD").ToString & ",0,0,0,0,0)"
                    sql = "update JAN_DEALER_TGT_2015_16_FINAL set q3_qty=" & .Item("revised_q3_target") & " where bill_to_customer_id=" & .Item("CUSTOMER_ID") & " and org='" & .Item("org") & "' and product_group='" & .Item("product_group") & "'"

                    'sql = "update JAN_DEALER_TGT_2015_16_FINAL set q1_actual_qty=" & .Item("q1_qty") & " where BILL_TO_CUSTOMER_ID=" & .Item("BILL_TO_CUSTOMER_ID") & " and org='" & .Item("ORG") & "' and PRODUCT_GROUP='" & .Item("PRODUCT_GROUP") & "'"
                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()
                Catch ex As Exception

                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,Target')"
                    comand()

                End Try
            End With
        Next

        '2014-15 Total Sale
        sql = " select a.*,nvl((select target_2015_16 from jan_dealer_target_2015_16 where customer_id=a.bill_to_customer_id),0)target_val from jan_dealer_sale_2014_15 a "


        adap = New OracleDataAdapter(sql, con)
        DS = New DataSet
        adap.Fill(DS, "RES")

        For i = 0 To DS.Tables("res").Rows.Count - 1
            With DS.Tables("res").Rows(i)


                Try
                    sql = "INSERT INTO jan_dealer_sale_2014_15(BILL_TO_CUSTOMER_ID,sale_value,target_2015_16) VALUES(" & .Item("BILL_TO_CUSTOMER_ID") & "," & .Item("sale_value") & "," & .Item("target_val") & ")"
                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()
                Catch ex As Exception

                    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,Target')"
                    comand()

                End Try
            End With
        Next
        '2015-16 Target

    End Sub
    Private Sub sql_server_cmd()
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
    End Sub

    Private Sub sql_server_update_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

    End Sub

    Private Sub sql_server_update_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged

    End Sub
End Class