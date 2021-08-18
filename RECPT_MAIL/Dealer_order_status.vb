Public Class Dealer_order_status

    Private Sub Dealer_order_status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sql = "select SYS_CONTEXT('USERENV','IP_ADDRESS')ip_address from dual"
        'ds = SQL_SELECT("data", sql)
        'If ds.Tables("data").Rows(0).Item("ip_address") = "192.168.12.25" Or ds.Tables("data").Rows(0).Item("ip_address") = "192.168.26.59" Or ds.Tables("data").Rows(0).Item("ip_address") = "192.168.23.60" Then
        display()
        'Else


        '    End
        '    Exit Sub
        'End If

        'sql = "SELECT DEALER_NAME ""Dealer Name"",TOTAL_TARGET ""Total Target"",case when NVL(DIFFERENT_TARGET_QTY,0)=0 then ROUND(TOTAL_TARGET/4,2) else Q4_TARGET end ""Q4 Target value"" ,(SELECT REGION FROM jan_it.JAN_BMS_CUSTOMER_REGION_V WHERE CUSTOMER_ID=A.CUSTOMER_ID)""Region"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)ORD_PEND FROM jan_it.JAN_SALES_ANY_TB2_1 WHERE CUSTOMER_ID=A.CUSTOMER_ID),0)""Current Order Pending"""

        'sql &= "  ,NVL((select SUM((QUANTITY_INVOICED)*UNIT_SELLING_PRICE) FROM jan_it.JAN_SALES_ANY_1_COPY  WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID AND TRX_DATE>='1-jan-2016' and TRX_DATE<'1-apr-2016'),0)""Q4 Sale value""  from JAN_IT.JAN_DEALER_TGT_2015_16 a "



    End Sub

    Private Sub btn_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show.Click
        display()
    End Sub
    Private Sub display()
        'sql = "SELECT customer_NAME ""Dealer Name"",(tod_q4+non_tod_q4) ""Overall Target Q4"", q4 ""Gate1 Target Q4"" ,(SELECT REGION FROM jan_it.JAN_BMS_CUSTOMER_REGION_V WHERE CUSTOMER_ID=A.CUSTOMER_ID)""Region"""
        'sql &= ",(select CUSTOMER_CATEGORY from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Customer Category"" "

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)ORD_PEND FROM jan_it.JAN_SALES_ANY_TB2_1 WHERE CUSTOMER_ID=A.CUSTOMER_ID),0)""Total Order Pending"""

        'sql &= "  ,NVL((select SUM((QUANTITY_INVOICED)*UNIT_SELLING_PRICE) FROM jan_it.JAN_SALES_ANY_1_COPY  WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID AND TRX_DATE>='1-jan-2017' and TRX_DATE<'1-apr-2017'),0)""Q4 Sale value (16-17)"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')-13),0)""OFD upto Current week-2"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')-6),0)""OFD upto Current week-1"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')+1),0)""OFD upto Current week"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')+8),0)""OFD upto Current week+1"""

        'sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')+15),0)""OFD upto Current week+2"""

        'sql &= "   from JAN_IT.JAN_DEALER_TARGET_1617_GATE1 a  where customer_id=1093   order by 1" 'where customer_id=1093 

        sql = " select rownum ""Sl No"",b.* from ( SELECT CUSTOMER_NAME ""Dealer Name"",(select REGION from JAN_BMS_CUSTOMER_REGION_V where CUSTOMER_ID=a.CUSTOMER_ID and rownum=1)""Region"""
        sql &= ",(select CUSTOMER_CATEGORY from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Customer Category"" "
        sql &= " ,nvl((select q1_tgt+q2_tgt+q3_tgt+q4_tgt from jan_dealer_taeget_201718  where fin_year=202021 and CUSTOMER_ID=A.CUSTOMER_ID),0) ""Total Target"" "

        sql &= ",nvl((select q1_tgt from jan_dealer_taeget_201718  where fin_year=202021 and CUSTOMER_ID=A.CUSTOMER_ID),0)  ""Q1 Tgt"""
        sql &= ",nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>='1-apr-2020' and trx_date<'1-jul-2020' and bill_to_customer_id=a.customer_id),0)""Q1 Sale"""
        sql &= " ,nvl((select q2_tgt from jan_dealer_taeget_201718  where fin_year=202021 and CUSTOMER_ID=A.CUSTOMER_ID),0)""Q2 Tgt"""
        sql &= ",nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>='1-jul-2020' and trx_date<'1-oct-2020' and bill_to_customer_id=a.customer_id),0)""Q2 Sale"""
        sql &= " ,nvl((select q3_tgt from jan_dealer_taeget_201718  where fin_year=202021 and CUSTOMER_ID=A.CUSTOMER_ID),0)""Q3 Tgt"""

        sql &= ",nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>='1-oct-2020' and trx_date<'1-jan-2021' and bill_to_customer_id=a.customer_id),0)""Q3 Sale"""

        sql &= " ,nvl((select q4_tgt from jan_dealer_taeget_201718  where fin_year=202021 and CUSTOMER_ID=A.CUSTOMER_ID),0) ""Q4 Tgt"""

        sql &= ",nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>='1-jan-2021' and trx_date<'1-apr-2021' and bill_to_customer_id=a.customer_id),0)""Q4 Sale"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)ORD_PEND FROM jan_it.JAN_SALES_ANY_TB2_1 WHERE CUSTOMER_ID=A.CUSTOMER_ID),0)""Total Order Pending"""


        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt<next_day(sysdate-1,'sat')-27 ),0)""OFD upto Current week-4"""


        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID and  order_ff_dt>next_day(sysdate-1,'sat')-27 and  order_ff_dt<next_day(sysdate-1,'sat')-20),0)""OFD  Current week-3"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt>next_day(sysdate-1,'sat')-20 and  order_ff_dt<next_day(sysdate-1,'sat')-13),0)""OFD  Current week-2"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt>next_day(sysdate-1,'sat')-13 and  order_ff_dt<next_day(sysdate-1,'sat')-6),0)""OFD  Current week-1"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  trunc(order_ff_dt)=trunc(next_day(sysdate-1,'sat'))),0)""OFD  Current week"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt>next_day(sysdate-1,'sat') and  order_ff_dt<next_day(sysdate-1,'sat')+8 ),0)""OFD  Current week+1"""

        sql &= "  ,NVL((select SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM jan_it.jan_sales_any_tb2_1  WHERE CUSTOMER_ID=A.CUSTOMER_ID  and  order_ff_dt>next_day(sysdate-1,'sat')+8   and  order_ff_dt<next_day(sysdate-1,'sat')+15),0)""OFD  Current week+2"""


        sql &= "  FROM ra_customers A  "
        sql &= " where  customer_class_code='DEALER' " '   and  customer_id=1093 "

        sql &= "  ORDER BY 1)b"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

    Private Sub Dealer_order_status_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
End Class