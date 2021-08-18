Imports System.Data.OracleClient

Public Class order_receipt
    Dim report_for As String
    Private Sub order_receipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub display()
        For i = 1 To dgv.ColumnCount - 1
            With dgv
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(i).DefaultCellStyle.Format = "00.000"

            End With
        Next
        dgv.Rows(dgv.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        report_for = "OS"
        dgv_break.Columns.Clear()
        If rad_order_penidng.Checked = True Then
            sql = "select CUSTOMER_CATEGORY ""Cust Cat"",ROUND(SUM(ORD_CUR_MONTH)/100000,3)""Order Pending for the Month"",ROUND(SUM(future_schedule)/100000,3)""Future Pending Order"","
            sql &= " ROUND(SUM(total_order_pend)/100000,3)""Total Order Pending"" "
            sql &= " from ("
            sql &= " select a.*,"
            sql &= " NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)"
            sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY,"
            sql &= " case when TRUNC(schedule_ship_DATE)<trunc(last_day(sysdate)+1) then ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) else 0 end ORD_CUR_MONTH,"
            sql &= " case when  TRUNC(schedule_ship_DATE)>=trunc(last_day(sysdate)+1) then ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) else 0 end future_schedule,"
            sql &= " ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) total_order_pend"

            sql &= " from JAN_SALES_ANY_TB2_1 a where TRUNC(ORDERED_DATE)>=(select F_DT_lYR from JAN_SALES_BI_SETUP )) group by rollup(CUSTOMER_CATEGORY)"
        ElseIf rad_order_recd.Checked = True Then
            sql = "select CUSTOMER_CATEGORY ""Cust Cat"",ROUND(SUM(ORD_CUR_MONTH)/100000,3)""Order Cur Month"",ROUND(SUM(ORD_CUR_YEAR)/100000,3)""Order Cur Year"",ROUND(SUM(ORD_last_MONTH)/100000,3)""Order Last Month"","
            sql &= " ROUND(SUM(YESTERDAY_ORD)/100000,3)""Order Yesterday"" ,ROUND(SUM(YESTERDAY_ORD_MINUE1)/100000,3)""Order Yesterday minus-1"","
            sql &= " ROUND(SUM(YESTERDAY_ORD_MINUE2)/100000,3)""Order Yesterday minus-2"""
            sql &= " from ("
            sql &= " select a.*,"
            sql &= " NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)"
            sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY,"
            sql &= " case when TRUNC(ORDERED_DATE)>= trunc(trunc(sysdate,'MM')-1,'MM') and TRUNC(ORDERED_DATE)<TRUNC(sysdate,'MM') then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end ORD_last_MONTH,"
            sql &= " case when TRUNC(ORDERED_DATE)>=TRUNC(sysdate,'MM') then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end ORD_CUR_MONTH,"
            sql &= " case when TRUNC(ORDERED_DATE)>=(select F_DT_CYR from JAN_SALES_BI_SETUP ) "

            If chk_order_pending.Checked = True Then sql &= "  and ordered_date<trunc(sysdate,'MM') "

            sql &= " then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end ORD_CUR_YEAR,"
            sql &= " case when TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1) then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end YESTERDAY_ORD,"
            sql &= " case when TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1)-1 then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end YESTERDAY_ORD_MINUE1,"
            sql &= " case when TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1)-2 then (ORDERED_QUANTITY*UNIT_SELLING_PRICE) else 0 end YESTERDAY_ORD_minue2"
            sql &= " from JAN_SALES_ANY_TB2_1 a  ) group by rollup(CUSTOMER_CATEGORY)"
        ElseIf RAD_DEALER_ORDER.Checked = True Then
            sql = " select * from jan_dealer_order_cyr_v order by customer_namae"
        ElseIf rad_sales.Checked = True Then

            sql = "select CUSTOMER_CATEGORY ""Cust Cat"",ROUND(SUM(sale_for_the_year)/100000,3)""Sale For the Year"",ROUND(SUM(sale_for_the_month)/100000,3)""Sale For the Month"","
            sql &= " ROUND(SUM(sale_yesterday)/100000,3)""Last Day Sale"", "
            sql &= " ROUND(SUM(sale_yesterday_1)/100000,3)""Sale Day Before Yesterday"" ,"
            sql &= " ROUND(SUM(sale_last_month)/100000,3)""Sale Last  Month"" "
            sql &= " from ("
            sql &= " select a.*,"
            sql &= " NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.BILL_TO_CUSTOMER_ID)"
            sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY,"
            sql &= " case when trx_DATE=(select max(trx_date) from ra_customer_trx_all where trx_date<trunc(sysdate)) then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_yesterday,"
            sql &= " case when trx_DATE=(select max(trx_date) from ra_customer_trx_all where trx_date<trunc(sysdate))-1 then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_yesterday_1,"
            sql &= " case when trx_DATE>= TRUNC(sysdate,'MM')then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_for_the_month,"
            sql &= " case when trx_DATE>=trunc(trunc(sysdate,'MM')-1,'MM') and trx_date<trunc(sysdate,'MM') then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_last_month,"

            sql &= "  (QUANTITY_invoiced*UNIT_SELLING_PRICE)  sale_for_the_year"

            sql &= " from JAN_SALES_ANY_1_copy a where trx_DATE>=(select F_DT_CYR from JAN_SALES_BI_SETUP )  ) group by rollup(CUSTOMER_CATEGORY)"
        ElseIf rad_outstanding.Checked = True Then

            sql = " SELECT CUSTOMER_CATEGORY""Cust Category"",count(distinct PAY_IMMEDIATE_cust) ""No of cust Immediate"",ROUND(SUM(PAY_IMMEDIATE)/100000,2)""OS within Due Immediate"",ROUND(SUM(PAY_IMMEDIATE_ODUE)/100000,2)""OS ODue Immediate"""

            sql &= " ,count(distinct PAY_7_DAYS_cust) ""No of Cust 7 Days"",ROUND(SUM(PAY_7_DAYS)/100000,2)""OS within Due 7 Days"",ROUND(SUM(PAY_7_DAYS_ODUE)/100000,2)""OS ODue 7 Days"""

            sql &= " ,count(distinct PAY_15_DAYS_cust)  ""No of Cust 15 Days"",ROUND(SUM(PAY_15_DAYS)/100000,2)""OS within Due 15 Days"",ROUND(SUM(PAY_15_DAYS_ODUE)/100000,2)""OS ODue 15 Days"""

            sql &= " ,count(distinct PAY_30_DAYS_cust)  ""No of Cust 30 Days"",ROUND(SUM(PAY_30_DAYS)/100000,2)""OS within Due 30 Days"",ROUND(SUM(PAY_30_DAYS_ODUE)/100000,2)""OS ODue 30 Days"""
            sql &= ",count(distinct PAY_45_DAYS_cust)  ""No of Cust 45 Days"",ROUND(SUM(PAY_45_DAYS)/100000,2)""OS within Due 45 Days"",ROUND(SUM(PAY_45_DAYS_ODUE)/100000,2)""OS ODue 45 Days"""
            sql &= " ,count(distinct PAY_60_DAYS_cust)  ""No of Cust 60 Days"",ROUND(SUM(PAY_60_DAYS)/100000,2)""OS within Due 60 Days"",ROUND(SUM(PAY_60_DAYS_ODUE)/100000,2)""OS ODue 60 Days"" "

            sql &= " ,count(distinct PAY_90_DAYS_cust)  ""No of Cust 90 Days"",ROUND(SUM(PAY_90_DAYS)/100000,2)""OS within Due 90 Days"",ROUND(SUM(PAY_90_DAYS_ODUE)/100000,2)""OS ODue 90 Days"" "

            sql &= " ,count(distinct PAY_120_DAYS_cust)  ""No of Cust 120 Days"",ROUND(SUM(PAY_120_DAYS)/100000,2)""OS within Due 120 Days"",ROUND(SUM(PAY_120_DAYS_ODUE)/100000,2)""OS ODue 120 Days"" "

            sql &= " from (SELECT A.*, NVL((SELECT CUSTOMER_CATEGORY FROM JAN_IT.JAN_PICK_FORWARD_CONTROL WHERE BILL_TO_CUSTOMER_ID=A.BILL_TO_CUSTOMER_ID),CASE WHEN (SELECT CUSTOMER_CLASS_CODE FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.BILL_TO_CUSTOMER_ID)='DEALER' THEN 'D4' ELSE 'C4' END)CUSTOMER_CATEGORY,CASE WHEN PAY_TERM='IMMEDIATE'   THEN 0 ELSE 0 END PAY_IMMEDIATE,CASE WHEN PAY_TERM='7 Days'   AND  (TRUNC(SYSDATE)-(trx_date+7))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_7_DAYS,CASE WHEN PAY_TERM='15 Days'   AND (TRUNC(SYSDATE)-(trx_date+15))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_15_DAYS,CASE WHEN PAY_TERM LIKE '30%'   AND  (TRUNC(SYSDATE)-(trx_date+30))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_30_DAYS,CASE WHEN PAY_TERM='45 Days'   AND  (TRUNC(SYSDATE)-(trx_date+45))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_45_DAYS,CASE WHEN PAY_TERM='60 Days'   and  (TRUNC(SYSDATE)-(trx_date+60))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_60_DAYS,CASE WHEN PAY_TERM='90 Days'   and  (TRUNC(SYSDATE)-(trx_date+90))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_90_DAYS,CASE WHEN PAY_TERM='120 Days'   and  (TRUNC(SYSDATE)-(trx_date+120))<=0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_120_DAYs"

            sql &= "  ,CASE WHEN PAY_TERM='IMMEDIATE'   THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_IMMEDIATE_ODUE,CASE WHEN PAY_TERM='7 Days'   AND  (TRUNC(SYSDATE)-(trx_date+7))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_7_DAYS_ODUE,CASE WHEN PAY_TERM='15 Days'   AND  (TRUNC(SYSDATE)-(trx_date+15))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_15_DAYS_ODUE,CASE WHEN PAY_TERM LIKE '30%'   AND  (TRUNC(SYSDATE)-(trx_date+30))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_30_DAYS_ODUE,CASE WHEN PAY_TERM='45 Days'   AND  (TRUNC(SYSDATE)-(trx_date+45))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_45_DAYS_ODUE,CASE WHEN PAY_TERM='60 Days'   and  (TRUNC(SYSDATE)-(trx_date+60))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_60_DAYS_odue,CASE WHEN PAY_TERM='90 Days'   and  (TRUNC(SYSDATE)-(trx_date+90))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_90_DAYS_odue,CASE WHEN PAY_TERM='120 Days'   and  (TRUNC(SYSDATE)-(trx_date+120))>0 THEN AMOUNT_DUE_REMAINING ELSE 0 END PAY_120_DAYS_odue"

            sql &= " ,CASE WHEN PAY_TERM='IMMEDIATE'   THEN bilL_to_customer_id  END PAY_IMMEDIATE_cust,CASE WHEN PAY_TERM='7 Days'  THEN BILL_TO_CUSTOMER_ID END PAY_7_DAYS_cust,CASE WHEN PAY_TERM='15 Days'   THEN  BILL_TO_CUSTOMER_ID END PAY_15_DAYS_cust,CASE WHEN PAY_TERM LIKE '30%'  THEN  bilL_to_customer_id END PAY_30_DAYS_cust,CASE WHEN PAY_TERM='45 Days'  THEN  BILL_TO_CUSTOMER_ID END PAY_45_DAYS_cust,CASE WHEN PAY_TERM='60 Days'    THEN  bilL_to_customer_id END PAY_60_DAYS_cust ,CASE WHEN PAY_TERM='90 Days'    THEN  bilL_to_customer_id END PAY_90_DAYS_cust ,CASE WHEN PAY_TERM='120 Days'    THEN  bilL_to_customer_id END PAY_120_DAYS_cust from jan_region_payment_pending_tab a  where NAME NOT IN ('Captive Consumption','Commission-CM','Captive Consumption','Commission - CM','Exhibition Sales','Projects Credit Memo','Projects Credit Memo','Projects Invoice','Projects Invoice','Purchase Return','Samples / Free Inv-1','Samples / Free Inv-2','Service Invoice','Stock Transfer - 1','Stock Transfer - 2','TDS Credit Memo','Invoice') AND BILL_TO_CUST_NAME NOT LIKE 'JANATICS%' AND REGION<>'NOT LISTED' AND AMOUNT_DUE_REMAINING>0) GROUP BY  ROLLUP(CUSTOMER_CATEGORY)"

        End If
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")
        ds.Tables("data").Rows(ds.Tables("data").Rows.Count - 1).Item(0) = "Total"
        dgv.DataSource = ds.Tables("data")
        display()
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If report_for <> "OA" Then



            If rad_order_recd.Checked = True Then
                sql = "SELECT CUSTOMER_NAME,REGION,SUM((ORDERED_QUANTITY)*UNIT_SELLING_PRICE)VAL FROM JAN_SALES_ANY_TB2_1  a WHERE 1=1 "
                If dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Cur Year" Then
                    sql &= " and TRUNC(ORDERED_DATE)>=(select F_DT_CYR from JAN_SALES_BI_SETUP ) "

                    If chk_order_pending.Checked = True Then sql &= "  and ordered_date<trunc(sysdate,'MM') "

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Cur Month" Then

                    sql &= " and TRUNC(ORDERED_DATE)>=TRUNC(sysdate,'MM')"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Yesterday" Then

                    sql &= " and TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1) "
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Yesterday minus-1" Then

                    sql &= " and TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1)-1 "
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Yesterday minus-2" Then

                    sql &= " and TRUNC(ORDERED_DATE)=(select TRUNC(max(ORDERED_DATE)) from JAN_SALES_ANY_TB2_1)-2 "
                End If

                sql &= " and NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)"
                sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)='" & dgv.CurrentRow.Cells(0).Value & "'"
                sql &= " GROUP BY CUSTOMER_NAME,REGION order by CUSTOMER_NAME,region"

            ElseIf rad_order_penidng.Checked = True Then

                sql = " SELECT CUSTOMER_NAME,REGION,SUM((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE)VAL FROM JAN_SALES_ANY_TB2_1  a WHERE (ORDERED_QUANTITY-nvl(shipped_quantity,0))>0  "
                If dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Order Pending for the Month" Then
                    sql &= " and TRUNC(schedule_ship_DATE)<trunc(last_day(sysdate)+1)"
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Future Pending Order" Then

                    sql &= " and  TRUNC(schedule_ship_DATE)>=trunc(last_day(sysdate)+1)"
                End If

                sql &= " and NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)"
                sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)='" & dgv.CurrentRow.Cells(0).Value & "'"
                sql &= " GROUP BY CUSTOMER_NAME,REGION order by CUSTOMER_NAME,region"

            ElseIf rad_sales.Checked = True Then
                sql = " SELECT Bill_to_cust_name CUSTOMER_NAME,REGION,SUM(QUANTITY_invoiced*UNIT_SELLING_PRICE)VAL FROM JAN_SALES_ANY_1_copy  a WHERE  1=1"

                If dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Sale For the Year" Then
                    sql &= " and trx_date>=(select f_dt_cyr from jan_sales_bi_setup)"
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Sale For the Month" Then
                    sql &= " and trx_date>=trunc(sysdate,'MM')"
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "Last Day Sale" Then
                    sql &= " and  trx_DATE>=(select max(trx_date) from ra_customer_trx_all where trx_date<trunc(sysdate))"
                End If

                sql &= " and NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.BILL_TO_CUSTOMER_ID)"
                sql &= " ,case when class_code='DEALER' then 'D4' else 'C4' end)='" & dgv.CurrentRow.Cells(0).Value & "'"
                sql &= " GROUP BY Bill_to_cust_name,REGION order by Bill_to_cust_name,region"


            ElseIf rad_outstanding.Checked = True Then
                'PAY_TERM='IMMEDIATE' PAY_TERM='15 Days'
                sql = " SELECT Bill_to_cust_name CUSTOMER_NAME,REGION,SUM(AMOUNT_DUE_REMAINING)VAL FROM JAN_region_payment_pending_tab  a where NAME NOT IN ('Captive Consumption','Commission-CM','Captive Consumption','Commission - CM','Exhibition Sales','Projects Credit Memo','Projects Credit Memo','Projects Invoice','Projects Invoice','Purchase Return','Samples / Free Inv-1','Samples / Free Inv-2','Service Invoice','Stock Transfer - 1','Stock Transfer - 2','TDS Credit Memo','Invoice') AND BILL_TO_CUST_NAME NOT LIKE 'JANATICS%' AND REGION<>'NOT LISTED' AND AMOUNT_DUE_REMAINING>0"

                If dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due Immediate" Then
                    dgv_break.Columns.Clear()
                    Exit Sub

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue Immediate" Then
                    sql &= " and PAY_TERM='IMMEDIATE' "
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 7 Days" Then
                    sql &= " and PAY_TERM='7 Days' and (TRUNC(SYSDATE)-(trx_date+7))<=0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 7 Days" Then
                    sql &= " and PAY_TERM='7 Days' and (TRUNC(SYSDATE)-(trx_date+7))>0"
                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 15 Days" Then
                    sql &= " and PAY_TERM='15 Days' and (TRUNC(SYSDATE)-(trx_date+15))<=0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 15 Days" Then
                    sql &= " and PAY_TERM='15 Days' and (TRUNC(SYSDATE)-(trx_date+15))>0"


                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 30 Days" Then
                    sql &= " and PAY_TERM like '30%' and (TRUNC(SYSDATE)-(trx_date+30))<=0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 30 Days" Then
                    sql &= " and PAY_TERM like '30%' and (TRUNC(SYSDATE)-(trx_date+30))>0"


                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 45 Days" Then
                    sql &= " and PAY_TERM='45 Days' and (TRUNC(SYSDATE)-(trx_date+45))<=0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 45 Days" Then
                    sql &= " and PAY_TERM='45 Days' and (TRUNC(SYSDATE)-(trx_date+45))>0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 60 Days" Then
                    sql &= " and PAY_TERM='60 Days' and (TRUNC(SYSDATE)-(trx_date+60))<=0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 60 Days" Then
                    sql &= " and PAY_TERM='60 Days' and (TRUNC(SYSDATE)-(trx_date+60))>0"


                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 90 Days" Then
                    sql &= " and PAY_TERM='90 Days' and (TRUNC(SYSDATE)-(trx_date+90))<0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 90 Days" Then
                    sql &= " and PAY_TERM='90 Days' and (TRUNC(SYSDATE)-(trx_date+90))>0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS within Due 120 Days" Then
                    sql &= " and PAY_TERM='120 Days' and (TRUNC(SYSDATE)-(trx_date+120))<0"

                ElseIf dgv.Columns(dgv.CurrentCell.ColumnIndex).HeaderText = "OS ODue 120 Days" Then
                    sql &= " and PAY_TERM='120 Days' and (TRUNC(SYSDATE)-(trx_date+120))>0"
                Else
                    dgv_break.Columns.Clear()
                    Exit Sub
                End If

                sql &= " and NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.BILL_TO_CUSTOMER_ID)"
                sql &= " ,case when (select CUSTOMER_Class_code from ra_customers where CUSTOMER_ID=a.BILL_TO_CUSTOMER_ID)='DEALER' then 'D4' else 'C4' end)='" & dgv.CurrentRow.Cells(0).Value & "'"
                sql &= " GROUP BY Bill_to_cust_name,REGION order by Bill_to_cust_name,region"
            End If
            adap = New OracleDataAdapter(sql, con)
            ds = New DataSet
            adap.Fill(ds, "data")
            'ds.Tables("data").Rows(ds.Tables("data").Rows.Count - 1).Item(0) = "Total"
            With ds.Tables("data")
                .Rows.Add("Total")
                .Rows(.Rows.Count - 1).Item("val") = .Compute("sum(val)", "val>=0")

            End With
            dgv_break.DataSource = ds.Tables("data")
            display2()
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub display2()
        If rad_order_recd.Checked = True Or rad_order_penidng.Checked = True Or rad_sales.Checked = True Or rad_outstanding.Checked = True Then
            dgv_break.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgv_break.Columns(2).DefaultCellStyle.Format = "00.00"


        ElseIf rad_sales.Checked = True Then
        ElseIf rad_outstanding.Checked = True Then

        End If
    End Sub

    Private Sub btn_order_receipt_Click(sender As Object, e As EventArgs) Handles btn_order_receipt.Click
        report_for = "OA"
        sql = "select order_number ,ordered_date,jan_orgcode(ship_from_org_id)org,ordered_item,description,sum(ordered_quantity)order_qty,sum(ordered_quantity*unit_selling_price)order_val_without_tax,sum((ordered_quantity*unit_selling_price)+tax_amt)order_val_with_tax,schedule_ship_date,flow_status_code,cust_name,region,ord_type from jan_bms_order_pending_new_v where   trunc(ordered_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and  trunc(ordered_date)<='" & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & "' "

        If chk_dealer_order.Checked = True Then sql &= " and cust_id in (select customer_id from ra_customers where customer_class_code='DEALER')"
        sql &= " group by order_number ,ordered_date,ship_from_org_id,ordered_item,description,schedule_ship_date,flow_status_code,cust_name,region,ord_type order  by cust_name,org "
        ds = SQL_SELECT("res", sql)
        dgv.DataSource = ds.Tables("res")

    End Sub
End Class