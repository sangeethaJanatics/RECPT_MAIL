Imports System.Data
Imports System.net
Imports System.Data.SqlClient
Imports System.Data.OracleClient



Public Class sql_server_upload_cyr
    Dim ordref As String

    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms_test;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.195.146 ;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    'Dim dms_con As New SqlClient.SqlConnection("Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    '"Persist Security Info=False;Integrated Security=true;Initial Catalog=Northwind;server=(local)"

    'Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;workstation id=59.160.116.114;packet size=4096;user id=jandms;password=jandms#$sql08;data source=59.160.116.114;persist security info=False;initial catalog=jandms")

    'Dim con As New OleDb.OleDbConnection("provider=sqloledb;workstation id=59.160.116.114;packet size=4096;user id=scm;password=scm#$sql2007;data source=59.160.116.114;persist security info=False;initial catalog=SCM")

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    'Dim cmd_sql As New SqlClient.SqlCommand
    'Dim adap_sql As New SqlClient.SqlDataAdapter
    Dim adap As New OracleDataAdapter
    Dim DS, TDS As New DataSet

    Dim htm As String

    Dim DSP_ID, stage As String
    Dim Z As New Integer
    Private Sub sql_server_upload_cyr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            'sql = "alter TABLE JAN_DEALER_TGT_2015_16_FINAL add Fin_year int "
            'sql = "alter TABLE jan_payment_followup_status add TRX_NUMBER INT,TRX_DATE DATE,ACTUAL_AMOUNT float,due_Date date,NO_BOTTLENECK int,BOTTLENECK int,LAST_UPDATED_DATE date,PAYMENT_DATE date , GRI_NO varchar(50),DELIVERY_FLAG varchar(1),BOTTLENECK_REASON varchar(500),DELIVERY_REMARK varchar(500),ALL_DOCUMENT_RECEIVED varchar(1),SHORT_EXCESS_SUPPLY varchar(1) ,HO_COMMENT varchar(50),HO_REMARKS  varchar(50) "
            ''sql = "CREATE TABLE jan_payment_followup_status (CUSTOMER_ID INT)"
            'cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            'cmd_sql.ExecuteNonQuery()

            ''sql = "alter TABLE JAN_DEALER_TOD_TARGET_BASE add( tod_q1 int,tod_q2 int,tod_q3 int,tod_q4 int, non_tod_q1 int,non_tod_q2 int,non_tod_q3 int,non_tod_q4 int,q1_gate1 int,q2_gate1 int,q3_gate1 int,q4_gate1 int)"


            'sql = "select a.*,(select customer_id from ra_customers where customer_name=a.dealer_name)cust_id  from jan_dealer_tgt_101617 a"
            'sql = "select a.*,(q1+q2+q3+q4)target_1819,(select customer_id   from ra_customers where customer_name=a.dealer_name)customer_id from jan_dealer_target_201819 a"
            'sql = " select a.* ,(select customer_id from ra_customers where customer_name=a.dealer_name_)customer_id from jan_dealer_tgt_201920 a "

            'sql = "select a.* ,(select customer_id from ra_customers where customer_name=a.dealer_name_)customer_id from jan_dealer_tgt_201920 a where dealer_name_ in ('SATYAM & CO','SATYAM & CO.','SUNTEX SPARES','G.K.ENTERPRISES','J-VISION','SKY PNEUMATICS')"
            'adap = New OracleDataAdapter(sql, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("res").Rows(i)
            '        sql = "INSERT INTO JAN_DEALER_TOD_TARGET_BASE(customer_id, total_tod_target, ENABLE_LINK_Q1, ENABLE_LINK_Q2, ENABLE_LINK_Q3, ENABLE_LINK_Q4, Fin_year,tod_q1,tod_q2,tod_q3,tod_q4) VALUES(" & .Item("customer_id") & ", " & .Item("total") & ", 0,0,0,0,201920,0,0,0,0 )"

            '        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            '        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '        cmd_sql.ExecuteNonQuery()
            '    End With
            'Next
            ''*****************block to insert from live table to freezed table ***********************************
            'sql = "select * from   JAN_tod_DEALER_ORDER_upload_V WHERE  QTR_ID_NEW1=20192002"
            ''adap_sql = New SqlClient.SqlDataAdapter(sql, dms_con)
            'adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
            'DS = New DataSet
            'adap_sql.Fill(DS, "RES")

            ''sql = "SELECT * FROM jan_dealer_order_032015 where QTR_ID_NEW1=20181904 " ' AND CUSTOMER_ID=1357 "
            ''adap = New OracleDataAdapter(sql, con)
            ''DS = New DataSet
            ''adap.Fill(DS, "RES")

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            'customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no

            '            sql = "INSERT INTO jan_dealer_order_2015_16(order_number,customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no) VALUES(" & .Item("order_number") & "," & .Item("CUSTOMER_ID") & ",'" & .Item("org") & "','" & .Item("product_group") & "'," & .Item("ordered_quantity") & "," & .Item("unit_selling_price") & "," & .Item("qtr_id_new1") & ",'" & .Item("ordered_item") & "')"
            '            'cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            '            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception
            '            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,JAN_DEALER_ORDER_PENDING')"
            '            comand()
            '        End Try

            '    End With
            'Next

            'sql = "delete from  JAN_tod_DEALER_ORDER_upload_V  WHERE  QTR_ID_NEW1=20192002"
            ''cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            'cmd_sql.ExecuteNonQuery()
            ''End *****************block to insert from live table to freezed table ***********************************

            sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00005','dealer target uploading',sysdate) "
            comand()

            sql = "update jan_sales_bi_setup set upload_dealer_sale_from=TRUNC(SYSDATE)-10"
            comand()


            sql = "select upload_dealer_sale_from from jan_sales_bi_setup"
            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")

            stage = 1
            'Try

            sql = "delete from  JAN_DEALER_SALE_2014_15_tab  where trx_DAte>='" & Format(DS.Tables("RES").Rows(0).Item("upload_dealer_sale_from"), "dd-MMM-yyyy") & "' " ' and  bill_to_customer_id<>1093"

            'sql = "delete from  JAN_DEALER_SALE_2014_15_tab  where trx_DAte>='1-aug-2017'"

            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()

            stage = 2
            sql = "SELECT * FROM JAN_DEALER_SALE_2014_15_v  where trx_DAte>='" & Format(DS.Tables("RES").Rows(0).Item("upload_dealer_sale_from"), "dd-MMM-yyyy") & "'  " 'And bill_to_customer_id<>1093 "

            'sql = "Select * FROM JAN_DEALER_SALE_2014_15_v  where trx_DAte>='1-jan-2019' and bill_to_customer_id=1093 "

            'sql = "SELECT * FROM JAN_DEALER_SALE_2014_15_v  where trx_DAte>='1-aug-2017' "
            'sql = "select customer_id,customer_name from ra_customers where customer_class_code='DEALER' order by 2"
            'adap = New OracleDataAdapter(sql, con)
            'ds2 = New DataSet
            'adap.Fill(ds2, "RES")

            ''For k = 0 To ds2.Tables("res").Rows.Count - 1



            ''    sql = "SELECT * FROM JAN_DEALER_SALE_2014_15_v  where  trx_date>='1-JAN-2016'  and bill_to_customer_id=" & ds2.Tables("res").Rows(k).Item("customer_id") & ""

            adap = New OracleDataAdapter(sql, con)
            DS = New DataSet
            adap.Fill(DS, "RES")
            stage = 3
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
            stage = 4
            'Next
            'Order Blocked bacause of the slow uploading of data

            'sql = "select * from JAN_DEALER_ORDER_201516_V where qtr_id_new1 in (20161702,20161703,20161704) "
            ''sql = "select * from JAN_DEALER_ORDER_201516_V where  QTR_ID_NEW1=20161702 and CUSTOMER_ID=3031590 and ordered_item in  ('CS50474','CS50473')"
            ''sql = "select order_number,CUSTOMER_ID,org,product_group,ordered_quantity,unit_selling_price,qtr_id_new,ordered_item from JAN_DEALER_ORDER_201516_Q3_tod "
            'adap = New OracleDataAdapter(sql, con)
            'DS = New DataSet
            'adap.Fill(DS, "RES")

            'If DS.Tables("res").Rows.Count > 0 Then
            '    sql = "delete from  jan_dealer_order_2015_16 where qtr_id  in (20161702,20161703,20161704)" 'Date-wise Order pending value
            '    cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            '    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '    cmd_sql.ExecuteNonQuery()
            'End If

            'For i = 0 To DS.Tables("RES").Rows.Count - 1
            '    With DS.Tables("RES").Rows(i)

            '        Try
            '            'customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no

            '            sql = "INSERT INTO jan_dealer_order_2015_16(order_number,customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no) VALUES(" & .Item("order_number") & "," & .Item("CUSTOMER_ID") & ",'" & .Item("org") & "','" & .Item("product_group") & "'," & .Item("ordered_quantity") & "," & .Item("unit_selling_price") & "," & .Item("qtr_id_new1") & ",'" & .Item("ordered_item") & "')"
            '            cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            '            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '            cmd_sql.ExecuteNonQuery()
            '        Catch ex As Exception
            '            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,JAN_DEALER_ORDER_PENDING')"
            '            comand()
            '        End Try

            '    End With
            'Next
            ' End Order Blocked bacause of the slow uploading of data

            '    ''BALAJI ELETRICALS Non - TOD Item
            '    sql = "select * from JAN_DEALER_ORDER_201516_V_EXE"
            '    adap = New OracleDataAdapter(sql, con)
            '    DS = New DataSet
            '    adap.Fill(DS, "RES")


            '    For i = 0 To DS.Tables("RES").Rows.Count - 1
            '        With DS.Tables("RES").Rows(i)

            '            Try
            '                'customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no

            '                sql = "INSERT INTO jan_dealer_order_2015_16(order_number,customer_id, org, product_group, ordered_quantity, unit_selling_price, qtr_id, item_no) VALUES(" & .Item("order_number") & "," & .Item("CUSTOMER_ID") & ",'" & .Item("org") & "','" & .Item("product_group") & "'," & .Item("ordered_quantity") & "," & .Item("unit_selling_price") & "," & .Item("qtr_id_new1") & ",'" & .Item("ordered_item") & "')"
            '                cmd_sql = New SqlClient.SqlCommand(sql, dms_con)
            '                If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            '                cmd_sql.ExecuteNonQuery()
            '            Catch ex As Exception
            '                sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,JAN_DEALER_ORDER_PENDING NON TOD')"
            '                comand()
            '            End Try

            '        End With
            '    Next

            'Catch ex As Exception

            '    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.ToString & "','Dealer Target upload,Initial stage')"
            '    comand()
            'End Try



            stage = 5

            sql = "update jan_data_upload_time set dealer_Target_last_upload_date='" & Format(Date.Now, "dd-MMM-yyyy") & "'"
            cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
            If dms_con.State = ConnectionState.Closed Then dms_con.Open()
            cmd_sql.ExecuteNonQuery()
            stage = 6
            sql = "update jan_sales_bi_setup set dealer_target_uploaded=sysdate"
            comand()
            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00005'"
            comand()

            Me.Close()
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.ToString & stage & sql)
            sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.Message.Replace("'", " ") & "' where trunc(start_time)=trunc(sysdate) and s_code='C00005'"
            comand()
            Me.Close()

        End Try

    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

    End Sub

    Private Sub sql_server_cmd()
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class