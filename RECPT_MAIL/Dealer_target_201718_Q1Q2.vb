Imports System.IO
Public Class Dealer_target_201718_Q1Q2
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")

    Dim cmd_sql As New OleDb.OleDbCommand

    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim s As String

    Private Sub Dealer_target_201718_Q1Q2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select customer_name,customer_id from ra_customers where customer_class_code='DEALER' order by 1"

        ds = SQL_SELECT("CUST", sql)

        cmb_dealer.DataSource = ds.Tables("CUST")

        'For i = 0 To ds.Tables("CUST").Rows.Count - 1

        '    cmb_dealer.Items.Add = "customer_id"
        '    cmb_dealer.DisplayMember = "customer_name"
        'Next

        cmb_dealer.ValueMember = "customer_id"
        cmb_dealer.DisplayMember = "customer_name"
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        'sql = " SELECT        (SELECT        CUSTOMER_NAME FROM DMS_CUSTS_LOG_IN_TAB "
        'sql &= "         WHERE        (CUSTOMER_ID = a.bill_to_customer_id)) AS dealer_name, bill_to_customer_id, org, Product_group, Q1_qty AS Q1_201819_target, Fin_year,"
        'sql &= "       (SELECT        SUM(quantity_invoiced) AS Expr1"
        'sql &= "     FROM JAN_DEALER_SALE_2014_15_tab "
        'sql &= "           WHERE        (trx_date >= '1-apr-2018') AND (trx_date < '1-jul-2018') AND (bill_to_customer_id = a.bill_to_customer_id) AND (org = a.org) AND (product_group = a.Product_group)) AS sale_qty, ISNULL"
        'sql &= "          ((SELECT        SUM(ordered_quantity) AS Expr1"
        'sql &= "     FROM  jan_dealer_order_2015_16_v "
        'sql &= "                  WHERE        (product_group = a.Product_group) AND (org = a.org) AND (qtr_id IN (20181901)) AND (customer_id = a.bill_to_customer_id)), 0) AS order_Qty"
        'sql &= "     FROM            JAN_DEALER_TGT_2015_16_FINAL AS a"
        'sql &= "    WHERE        (Fin_year = 201819) " '(bill_to_customer_id = 1093) AND AND (org = 'I22')"
        'sql &= "     ORDER BY org, Product_group"




        'If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        'adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)

        'ds = New DataSet
        'adap_sql.Fill(ds, "res")

        'dgv_gate2.DataSource = ds.Tables("res")

        s = ""
        s &= "<html>"
        s &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

        s &= "<table width=80%><tr><td align=right>Date:" & Format(Date.Today, "dd-MMM-yyyy") & "</td></tr></table>"
        s &= "<h3>Gate1 Performance Status as on Date</h3>"
        If (cmb_dealer.SelectedValue) IsNot Nothing Then


            sql = "select (select customer_name from dms_custs_log_in_tab where customer_id=a.customer_id)""Dealer Name"",case when tod_q1>0 then tod_q1 else round(total_tod_target/CAST(4 AS float),2)   end  ""Q1 Target"""
            ',case when tod_q2>0 then tod_q2 else round(total_tod_target/CAST(4 AS float),2)   end ""Q2 Target"",round((case when tod_q1>0 then tod_q1 else total_tod_target/CAST(4 AS float)   end+case when tod_q2>0 then tod_q2 else total_tod_target/CAST(4 AS float)   end),2)""Total target upto Q2"" "

            sql &= ",  isnull((select  round(sum(quantity_invoiced*unit_selling_price)/ CAST(100000 AS float), 2)   from JAN_DEALER_SALE_2014_15_tab where BILL_TO_CUSTomer_id=a.customer_id and trx_DAte>='1-apr-2018' and trx_DAte<'1-jul-2018' ),0)""Achieved as on date"",0.1 as ""Gap in Total""  "

            sql &= " from JAN_DEALER_TOD_TARGET_BASE  a where customer_id=" & cmb_dealer.SelectedValue & " and fin_year=201819"
        Else
            sql = "select 'All Dealer' ""Dealer Name"",sum(case when tod_q1>0 then tod_q1 else total_tod_target/4  end ) ""Q1 Target"""
            ',sum(case when tod_q2>0 then tod_q2 else total_tod_target/4  end) ""Q2 Target"",sum((case when tod_q1>0 then tod_q1 else total_tod_target/CAST(4 AS float)  end+case when tod_q2>0 then tod_q2 else total_tod_target/CAST(4 AS float)  end))""Total target upto Q2"" "

            sql &= ",  isnull((select  round(sum(quantity_invoiced*unit_selling_price)/ CAST(100000 AS float), 2)   from JAN_DEALER_SALE_2014_15_tab where  trx_DAte>='1-apr-2018' and trx_DAte<'1-jul-2018' ),0)""Achieved as on date"",0.1 as ""Gap in Total""  "

            sql &= " from JAN_DEALER_TOD_TARGET_BASE  a where  fin_year=201819"

        End If


        'sql = "select * from JAN_DEALER_TOD_TARGET_BASE where fin_year=201718" 'customer_id=" & cmb_dealer.SelectedValue & " "

        'cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)
        'ds.Tables(adap_sql, "data")
        ds = New DataSet
        adap_sql.Fill(ds, "res")



        With ds.Tables("res").Rows(0)
            If .Item("Achieved as on date") >= .Item("Q1 Target") Then
                .Item("Gap in Total") = 0
            Else
                .Item("Gap in Total") = Math.Round(.Item("Q1 Target") - .Item("Achieved as on date"), 2)
            End If

        End With
        s &= mail_content2("Gate1")
        Dgv_gate1.DataSource = ds.Tables("res")

        If (cmb_dealer.SelectedValue) IsNot Nothing Then
            sql = " select org,product_group,q1_qty ""Q1 Target"""
            ',q2_qty ""Q2 Target"" ,(q1_qty+q2_qty) ""Total Target"" "

            sql &= " ,ISNULL((SELECT  SUM(ordered_quantity)  FROM  jan_dealer_order_2015_16_v WHERE (customer_id = a.bill_to_customer_id) AND (product_group = a.Product_group) AND (org = a.org) AND qtr_id in (20181901)), 0) ""Total Achieved"" "

            sql &= " , 0 ""Gap in Target as on Date""" '0 ""Total Achieved"",

            sql &= " from JAN_DEALER_TGT_2015_16_FINAL  a WHERE(Fin_year = 201819)  and bill_to_customer_id=" & cmb_dealer.SelectedValue & "  ORDER BY org, order_by"
        Else
            sql = " select org,product_group,sum(q1_qty )""Q1 Target"""
            ',sum(q2_qty )""Q2 Target"" ,sum(q1_qty+q2_qty) ""Total Target"" "

            sql &= " ,ISNULL((SELECT  SUM(ordered_quantity)  FROM  jan_dealer_order_2015_16_v WHERE  (product_group = a.Product_group) AND (org = a.org) AND qtr_id in ( 20181901)), 0) ""Achieved Qty"" "

            sql &= " , 0 ""Gap in Target as on Date""" '0 ""Total Achieved"",

            sql &= " from JAN_DEALER_TGT_2015_16_FINAL  a WHERE(Fin_year = 201819)  group by org,product_group,order_by  ORDER BY org, order_by"

        End If




        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        adap_sql = New OleDb.OleDbDataAdapter(sql, dms_con)

        ds = New DataSet
        adap_sql.Fill(ds, "res")

        For i = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(i)
                '.Item("Total Achieved") = .Item("Q1 Achieved") + .Item("Q2 Achieved")
                .Item("Gap in Target as on Date") = .Item("Q1 Target") - (.Item("Total Achieved"))
                If .Item("Gap in Target as on Date") < 0 Then .Item("Gap in Target as on Date") = 0
            End With
        Next


        dgv_gate2.DataSource = ds.Tables("res")
        s &= "<H3>Gate2  Performance Status as on Date</h3>"
        's &= "<br>"
        s &= mail_content2("Gate2")
        s &= "</html>"
        X = "d:\dealer_target_201718_Q3.html"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(s)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
        System.Diagnostics.Process.Start("d:\dealer_target_201718_Q3.html")

    End Sub
    Private Sub BTN_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_PRINT.Click

    End Sub
End Class