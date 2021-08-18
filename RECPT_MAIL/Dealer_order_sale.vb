Public Class Dealer_order_sale
    Dim sql As String
    Private Sub Dealer_order_sale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
       
    End Sub

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        display()
    End Sub
    Private Sub display()
        If rad_sale.Checked = True Then
            sql = "SELECT A.* ,NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE) FROM JAN_SALES_ANY_TB2_1 WHERE (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 AND  CUSTOMER_ID=A.BILL_TO_CUSTOMER_ID),0)CURRENT_ORDER_PENDING FROM ( select  bill_to_cust_name,BILL_TO_CUSTOMER_ID,SUM(case when MY='042017' then (QUANTITY_INVOICED*UNIT_SELLING_PRICE) else 0 end )SALE_APR2017       "
            sql &= "  , SUM(CASE WHEN MY='052017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_MAY2017   , SUM(CASE WHEN MY='062017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_JUN2017 "
            sql &= "  , SUM(CASE WHEN MY='072017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_JUl2017  "
            sql &= " , SUM(CASE WHEN MY='082017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_aug2017 "
            sql &= " , SUM(CASE WHEN MY='092017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_sep2017 "
            sql &= " , SUM(CASE WHEN MY='102017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_oct2017 "
            sql &= " , SUM(CASE WHEN MY='112017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_nov2017 "
            sql &= " , SUM(CASE WHEN MY='122017' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_dec2017 "
            sql &= " , SUM(CASE WHEN MY='012018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_jan2018 "
            sql &= " , SUM(CASE WHEN MY='022018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_feb2018 "
            sql &= " , SUM(CASE WHEN MY='032018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_mar2018 "

            sql &= " , SUM(CASE WHEN MY='042018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_apr2018 "
            sql &= " , SUM(CASE WHEN MY='052018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_may2018 "
            sql &= " , SUM(CASE WHEN MY='062018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_jun2018 "
            sql &= " , SUM(CASE WHEN MY='072018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_jul2018 "
            sql &= " , SUM(CASE WHEN MY='082018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_aug2018 "
            sql &= " , SUM(CASE WHEN MY='092018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_sep2018 "
            sql &= " , SUM(CASE WHEN MY='102018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_oct2018 "
            sql &= " , SUM(CASE WHEN MY='112018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_nov2018 "
            sql &= " , SUM(CASE WHEN MY='122018' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_dec2018 "

            sql &= " , SUM(CASE WHEN MY='012019' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_jan2019 "
            sql &= " , SUM(CASE WHEN MY='022019' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_feb2019 "
            sql &= " , SUM(CASE WHEN MY='032019' THEN (QUANTITY_INVOICED*UNIT_SELLING_PRICE) ELSE 0 END )SALE_mar2019 "


            sql &= "  FROM JAN_SALES_ANY_1_COPY WHERE TRX_DATE>='1-APR-2017'    AND CUSTOMER_CLASS_CODE='DEALER' GROUP BY BILL_TO_CUST_NAME, BILL_TO_CUSTOMER_ID)A	"
        Else
            sql = "select customer_name,region,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='042017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_apr2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='052017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_may2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='062017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_jun2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='072017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_jul2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='082017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_aug2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='092017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_sep2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='102017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_oct2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='112017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_nov2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='122017' then  (ordered_quantity*unit_selling_price) else 0 end )Order_dec2017,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='012018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_jan2018,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='022018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_feb2018,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='032018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_mar2018"

            sql &= " ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='042018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_apr2018"

            sql &= "  ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='052018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_may2018"

            sql &= "  ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='062018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_jun2018"

            sql &= "  ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='072018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_jul2018"

            sql &= "  ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='082018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_aug2018"

            sql &= "  ,sum(case when to_char(nvl(ordered_date,ordered_date),'MMYYYY')='092018' then  (ordered_quantity*unit_selling_price) else 0 end )Order_sep2018"

            sql &= "  from jan_sales_any_tb2_1 where nvl(ordered_date,ordered_date)>='1-apr-2017' and  customer_id in (select customer_id from ra_customers where customer_class_code='DEALER') group by customer_name,region"
        End If

        ds = SQL_SELECT("data", sql)
        With ds.Tables("data")
            .Rows.Add("Total")
            If rad_sale.Checked = True Then
                .Rows(.Rows.Count - 1).Item("SALE_APR2017") = .Compute("sum(SALE_APR2017)", "SALE_APR2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_may2017") = .Compute("sum(SALE_may2017)", "SALE_may2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_jun2017") = .Compute("sum(SALE_jun2017)", "SALE_jun2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_jul2017") = .Compute("sum(SALE_jul2017)", "SALE_jul2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_Aug2017") = .Compute("sum(SALE_Aug2017)", "SALE_Aug2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_sep2017") = .Compute("sum(SALE_sep2017)", "SALE_sep2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_oct2017") = .Compute("sum(SALE_oct2017)", "SALE_oct2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_nov2017") = .Compute("sum(SALE_nov2017)", "SALE_nov2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_dec2017") = .Compute("sum(SALE_dec2017)", "SALE_dec2017>=0")
                .Rows(.Rows.Count - 1).Item("SALE_jan2018") = .Compute("sum(SALE_jan2018)", "SALE_jan2018>=0")
                .Rows(.Rows.Count - 1).Item("SALE_feb2018") = .Compute("sum(SALE_feb2018)", "SALE_feb2018>=0")
                .Rows(.Rows.Count - 1).Item("SALE_mar2018") = .Compute("sum(SALE_mar2018)", "SALE_mar2018>=0")
                .Rows(.Rows.Count - 1).Item("CURRENT_ORDER_PENDING") = .Compute("sum(CURRENT_ORDER_PENDING)", "CURRENT_ORDER_PENDING>=0")


            Else
                .Rows(.Rows.Count - 1).Item("Order_apr2017") = .Compute("sum(Order_apr2017)", "Order_apr2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_may2017") = .Compute("sum(Order_may2017)", "Order_may2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_jun2017") = .Compute("sum(Order_jun2017)", "Order_jun2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_jul2017") = .Compute("sum(Order_jul2017)", "Order_jul2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_aug2017") = .Compute("sum(Order_aug2017)", "Order_aug2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_sep2017") = .Compute("sum(Order_sep2017)", "Order_sep2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_oct2017") = .Compute("sum(Order_oct2017)", "Order_oct2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_nov2017") = .Compute("sum(Order_nov2017)", "Order_nov2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_dec2017") = .Compute("sum(Order_dec2017)", "Order_dec2017>=0")
                .Rows(.Rows.Count - 1).Item("Order_jan2018") = .Compute("sum(Order_jan2018)", "Order_jan2018>=0")
                .Rows(.Rows.Count - 1).Item("Order_feb2018") = .Compute("sum(Order_feb2018)", "Order_feb2018>=0")
                .Rows(.Rows.Count - 1).Item("Order_mar2018") = .Compute("sum(Order_mar2018)", "Order_mar2018>=0")


            End If
        End With
        With dgv1
            .DataSource = ds.Tables("data")
            For i = 2 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Next
        End With

    End Sub
End Class