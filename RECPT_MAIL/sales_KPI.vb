Public Class sales_KPI

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Cursor.Current = Cursors.WaitCursor

        If rad_delivery_rating.Checked = True Then
            group_ofd.Visible = True
        Else
            group_ofd.Visible = False
        End If

        If rad_order_receipt.Checked = True Then

            sql = "select odtmy,CUSTOMER_CATEGORY,sum((ORDERED_QUANTITY*UNIT_SELLING_PRICE))order_rece_value from (select a.*, NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID) ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY from JAN_SALES_ANY_TB2_1 a  where ordered_date>='1-apr-2018') group by odtmy,CUSTOMER_CATEGORY "

        ElseIf rad_order_pending.Checked = True Then
            sql = "select odtmy,CUSTOMER_CATEGORY ""Cust Cat"",ROUND(SUM(ORD_CUR_MONTH)/100000,3)""Order Pending for the Month"",ROUND(SUM(future_schedule)/100000,3)""Future Pending Order"", ROUND(SUM(total_order_pend)/100000,3)""Total Order Pending""  from ( select a.*, NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL  where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID) ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY,  case when TRUNC(schedule_ship_DATE)<trunc(last_day(sysdate)+1) then ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) else 0 end ORD_CUR_MONTH, case when  TRUNC(schedule_ship_DATE)>=trunc(last_day(sysdate)+1) then ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) else 0 end future_schedule, ((ORDERED_QUANTITY-nvl(shipped_quantity,0))*UNIT_SELLING_PRICE) total_order_pend from JAN_SALES_ANY_TB2_1 a where  TRUNC(ORDERED_DATE)>=(select F_DT_CYR from JAN_SALES_BI_SETUP )) group by CUSTOMER_CATEGORY,odtmy"

        ElseIf rad_sale_cyr.Checked = True Then

            sql = "select my,CUSTOMER_CATEGORY ""Cust Cat"",ROUND(SUM(sale_for_the_year)/100000,3)""Sale For the Year"",ROUND(SUM(sale_for_the_month)/100000,3)""Sale For the Month"",  ROUND(SUM(sale_yesterday)/100000,3)""Last Day Sale"",  ROUND(SUM(sale_yesterday_1)/100000,3)""Sale Day Before Yesterday""  from ( select a.*, NVL((select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.BILL_TO_CUSTOMER_ID) ,case when class_code='DEALER' then 'D4' else 'C4' end)CUSTOMER_CATEGORY , case when  trx_DATE=(select max(trx_date) from ra_customer_trx_all where trx_date<trunc(sysdate)) then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_yesterday, case when  trx_DATE=(select max(trx_date) from ra_customer_trx_all where trx_date<trunc(sysdate))-1 then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_yesterday_1, case when trx_DATE>= TRUNC(sysdate,'MM')then (QUANTITY_invoiced*UNIT_SELLING_PRICE) else 0 end sale_for_the_month,  (QUANTITY_invoiced*UNIT_SELLING_PRICE)  sale_for_the_year from JAN_SALES_ANY_1_copy a where trx_DATE>=(select F_DT_CYR from JAN_SALES_BI_SETUP )  ) group by my,CUSTOMER_CATEGORY"

        ElseIf rad_delivery_rating.Checked = True Then

            sql = "select  customer_name,customer_class_code,region,days_diff,trx_date,order_ff_dt,ordered_item,order_number,ordered_date,to_char(order_ff_dt,'MMYYYY')mnyear,schedule_ship_date FROM (select  CASE WHEN trx_date IS NULL THEN null ELSE (trx_date-order_ff_dt) END days_diff, b.* from jan_sales_any_tb2_1 b where order_ff_dt>='" & Format(ofd_dt_from.Value, "dd-MMM-yyyy") & "' and order_ff_dt<'" & Format(ofd_dt_to.Value, "dd-MMM-yyyy") & "' AND ORDERED_QUANTITY>0)"

        ElseIf rad_target_vs_actual.Checked = True Then

            sql = "select mnyear""Month"",round(sales_cyr/100000,2)""Sales"",sales_target ""Target"" from jan_sales_any_tb3_all where   updation_date=(select max(updation_date) from jan_sales_any_tb3_all) order by mnyear2"


        End If
        ds = SQL_SELECT("data", sql)
        Cursor.Current = Cursors.Default
        dgv1.DataSource = ds.Tables("data")

    End Sub
    Private Sub rad_delivery_rating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_delivery_rating.CheckedChanged


        If rad_delivery_rating.Checked = True Then
            group_ofd.Visible = True
        Else
            group_ofd.Visible = False
        End If

    End Sub
    Private Sub btn_export_to_Excel_Click(sender As Object, e As EventArgs) Handles btn_export_to_Excel.Click
        Dim dt As DataTable
        ' Dim dr As DataRow
        Dim myString As String
        Dim bFirstRecord As Boolean = True
        Dim myWriter As New System.IO.StreamWriter("d:\Delivery_Rating.csv")
        myString = ""
        Try
            dt = ds.Tables("data")
            For i = 0 To ds.Tables("data").Columns.Count - 1
                If i > 0 Then
                    myString &= (",")
                End If
                myString &= ds.Tables("data").Columns(i).ColumnName
            Next
            myString &= (Environment.NewLine)

            For Each dr As DataRow In dt.Rows
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString &= (",")
                    End If
                    myString &= (field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString &= (Environment.NewLine)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Write the String to the Csv File
        myWriter.WriteLine(myString)
        'Clean up
        myWriter.Close()
        Process.Start("d:\Delivery_Rating.csv")
    End Sub
End Class