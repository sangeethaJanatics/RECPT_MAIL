Public Class Dealer_payment_schedule

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = "declare begin JAN_DEALER_payment_PROC(" & cmb_dealer.SelectedValue & "); end;"
        comand()

        Try
            sql = "DROP TABLE JAN_DEALER_DESPATCH_SCHEDULE"
            comand()
        Catch ex As Exception

        End Try

        sql = " CREATE TABLE JAN_DEALER_DESPATCH_SCHEDULE AS sELECT C.*,SUM(WEEK_VALUE) OVER (PARTITION BY CUSTOMER_ID ORDER BY TARGET_DATE)CUMULATIVE FROM (SELECT B.*,NVL(jan_cus_pp(B.CUSTOMER_ID),0)UNAPPLIED FROM (SELECT CUSTOMER_ID,'DSP order'order_type,0 ORDER_NUMBER ,to_date('1-jan-2014')order_date,''order_placed_day,week_value,"
        sql &= "case when week_id=201405 then to_date('6-feb-2014')"
        sql &= "when week_id=201406 then to_date('13-feb-2014')"
        sql &= "when week_id=201407 then to_date('20-feb-2014')"
        sql &= "when week_id=201408 then to_date('27-feb-2014') end"
        sql &= " target_date FROM JAN_DEALER_FUND_PLAN_NEW1 WHERE CUSTOMER_ID=" & cmb_dealer.SelectedValue & ""
        sql &= " union all "
        sql &= " SELECT CUSTOMER_ID,'Manual order'ord,ORDER_NUMBER,ordered_date,day_name order_placed_day,sum((pending_qty*unit_selling_price)+(tax_per_quantity*pending_qty))order_pending_value,TARGET_DATE FROM (select to_char(ordered_DAte,'DAY') DAY_NAME,NEXT_DAY(ordered_DAte,to_char(ordered_DAte,'DAY'))NEXTD,CASE WHEN TRIM(to_char(ordered_DAte,'DAY')) IN ('MONDAY','TUESDAY') THEN  NEXT_DAY(NEXT_DAY(ordered_DAte,'SATURDAY'),'SATURDAY') ELSE NEXT_DAY(NEXT_DAY(ordered_DAte,to_char(ordered_DAte,'DAY')),'WEDNESDAY') END TARGET_DATE,a.*,(ordered_quantity-nvl(shipped_quantity,0))pending_qty,round(tax_amount/ordered_quantity,2)tax_per_quantity,        'Manual order'payment_type from jan_sales_any_tb2_1  a where  customer_id=" & cmb_dealer.SelectedValue & " and ordered_DAte>='10-jan-2014' and nvl(order_type,0)=0 and (ordered_quantity-nvl(shipped_quantity,0))>0 )group by CUSTOMER_ID, ORDER_NUMBER, ORDERED_DATE, TARGET_DATE)b)c"
        comand()

        sql = " select b.*,case when PAY_PEND=0 then 'Completed' else 'Pending' end pay_status from (SELECT A.*,(SELECT CUSTOMER_naME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID)CUST,CASE WHEN (UNAPPLIED-CUMULATIVE)>0 THEN 0 WHEN(UNAPPLIED-CUMULATIVE)<0 AND ABS(UNAPPLIED-CUMULATIVE)<WEEK_VALUE THEN  ABS(UNAPPLIED-CUMULATIVE) ELSE WEEK_VALUE END PAY_PEND FROM JAN_DEALER_DESPATCH_SCHEDULE A ORDER BY ORDER_NUMBER,TARGET_DATE)b"
        SQL_SELECT("DATA", sql)
        Dim ds1 As New DataSet
        ds1 = ds.Copy

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"

        S &= "<tr><td>To</td></tr>"


        S &= "<tr><td>  M/s. " & ds1.Tables("DATA").Rows(0).Item("CUST") & "</td></tr>"
        S &= "<tr><td>&nbsp;</td></tr>"

        S &= "<tr></tr><tr><td><table width=80% class=tab border=1 cellpadding=2 cellspacing=0> "
        S &= "<tr><TH>Order Type</TH><TH>order No</TH><TH>order Date</TH><TH>Payment to be made</TH><TH>Target Dt for Payment</TH><TH>Payment Status</TH></tr>"

        Dim pending_amt As Double = 0
        Dim scheduled_amt As Double = 0

        For i = 0 To ds1.Tables("DATA").Rows.Count - 1

            With ds1.Tables("data").Rows(i)
                If .Item("pay_status") <> "Completed" Then



                    If .Item("target_date") < Date.Today Then pending_amt += .Item("pay_pend") Else scheduled_amt += .Item("pay_pend")
                    S &= "<tr><Td>" & .Item("order_type") & "</Td><Td>" & .Item("order_number") & "</Td><Td>" & Format(.Item("order_date"), "dd-MMM-yyyy") & "</Td><Td align=right>" & Format(.Item("pay_pend"), "00.00") & "</Td><Td>" & Format(.Item("target_date"), "dd-MMM-yyyy") & "</Td>"

                    If .Item("target_date") < Date.Today Then S &= "<Td ><b><font color=""red"">" & .Item("pay_status") & "</font></b></Td>" Else S &= "<Td ><b><font color=""red"">Scheduled</font></b></Td>"


                    S &= "</tr>"
                End If

            End With

        Next

        S &= "</table></td></tr>"
        S &= "<tr><td>&nbsp;</td></tr>"
        S &= "<tr><td><b><u>Summary:<u></b></td></tr>"
        S &= "<tr><td>&nbsp;</td></tr>"
       
        S &= "<tr><td><table width=50% class=tab cellpadding=2 cellspacing=0>"

        S &= "<tr><td><b>Total Pending Amount to be paid </b></td><td><font color=""red""><b>:" & pending_amt & "</b></font></td></tr>"

        S &= "<tr><td><b>Total Amount Scheduled</b></td><td><font color=""green""><b>: " & scheduled_amt & "</b></font></td></tr>"

        S &= "</table></td></tr>"
        S &= "<tr><td>&nbsp;</td></tr>"
        S &= "<tr><td><u><b>Available</b></u></td></tr>"
        S &= "<tr><td>&nbsp;</td></tr>"
        S &= "<tr><td><table width=80% class=tab border=1 cellpadding=2 cellspacing=0>"
        S &= "<tr><th>Org</th><th>Pending Value</th><th>Available Value</th><th>Breakup</th></tr>"

        sql = "select jan_orgcode(organization_id)org,sum((pending_qty*unit_selling_price)+(tax_per_quantity*pending_qty))pending_value,sum((avail_qty*unit_selling_price)+(tax_per_quantity*avail_qty))available_value from (select a.*,(ordered_quantity-nvl(shipped_quantity,0))pending_qty,round(tax_amount/ordered_quantity,2)tax_per_quantity,nvl((select sum(primary_reservation_quantity) from mtl_reservations where demand_source_line_id=a.line_id),0)avail_qty from jan_sales_any_tb2_1  a where   customer_id=" & cmb_dealer.SelectedValue & " and (ordered_quantity-nvl(shipped_quantity,0))>0) group by ORGANIZATION_ID"
        SQL_SELECT("available", sql)
        With ds.Tables("available")
            .Rows.Add("Total")
            .Rows(.Rows.Count - 1).Item("pending_value") = .Compute("sum(pending_value)", "pending_value>=0")
            .Rows(.Rows.Count - 1).Item("available_value") = .Compute("sum(available_value)", "available_value>=0")

        End With

        For i = 0 To ds.Tables("available").Rows.Count - 1
            With ds.Tables("available").Rows(i)
                S &= "<tr><td>" & .Item("org") & "</td>"
                S &= "<td align=right>" & Format(.Item("pending_value"), "00.00") & "</td>"
                S &= "<td  align=right>" & Format(.Item("available_value"), "00.00") & "</td><td>View</td></tr>"
            End With
        Next

      
       
        S &= " </table></td></tr>"
        S &= "</table>"
        S &= "</html>"
        WebBrowser1.DocumentText = S



    End Sub
    Private Sub Dealer_payment_schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT CUSTOMER_ID,CUSTOMER_naME FROM RA_CUSTOMERS WHERE CUSTOMER_CLASS_CODE='DEALER' ORDER BY 2"
        SQL_SELECT("NAME", sql)
        cmb_dealer.DataSource = ds.Tables("NAME")
        cmb_dealer.DisplayMember = "CUSTOMER_naME"
        cmb_dealer.ValueMember = "CUSTOMER_ID"

    End Sub
End Class