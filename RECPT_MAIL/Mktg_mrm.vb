Public Class Mktg_mrm

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        If cmb_criteria.Text = "HO Gate1" Then

            sql = "select b.*,case when sales_cyr>sales_target then 100 else  round((sales_cyr/sales_target)*100) end sales_per,case when order_cyr>sales_target then 100 else  round((order_cyr/sales_target)*100) end order_per from (select case  substr(a.mnyear,0,2) when '04' then 'Apr' when '05' then 'May'  when '06' then 'Jun' when '07' then 'Jul' when '08' then 'Aug' when '09' then 'Sep' when '10' then 'Oct'when '11' then 'Nov'when '12' then 'Dec'when '01' then 'Jan'when '02' then 'Feb'when '03' then 'Mar' end month_name,mnyear,sales_target,round(sales_cyr/100000)sales_cyr,round(ord_recd/100000)order_cyr from jan_sales_any_tb3_all  a  where  trunc(updation_date)=(select max(updation_date) from jan_sales_any_tb3_all)  and mnyear2<to_char(sysdate,'YYYYMM') order  by mnyear2 )b"
        ElseIf cmb_criteria.Text = "Current yr Org sale monthwise" Then
            sql = "select JAN_ORGCODE(ORGANIZATION_ID)ORG,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='04' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_APR
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='05' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_MAY
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='06' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_JUN
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='07' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_JUL
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='08' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_AUG
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='09' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_SEP
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='10' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_OCT
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='11' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_NOV
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='12' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_DEC
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='01' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_JAN
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='02' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_FEB
,sum(CASE WHEN TO_CHAR(TRX_DATE,'MM')='03' THEN quantity_invoiced*UNIT_SELLING_PRICE ELSE 0 END )sale_MAR
from jan_sales_any_1_copy where trx_date>=(SELECT F_DT_CYR FROM JAN_SALES_BI_SETUP) AND trx_date<(SELECT L_DT_CYR+1 FROM JAN_SALES_BI_SETUP) 
GROUP BY ORGANIZATION_ID ORDER  BY ORG"
        ElseIf cmb_criteria.Text = "Current yr  Order Receipt Org and  monthwise" Then
            sql = "select JAN_ORGCODE(ORGANIZATION_ID)ORG,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='04' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_APR
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='05' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_MAY
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='06' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_JUN
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='07' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_JUL
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='08' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_AUG
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='09' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_SEP
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='10' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_OCT
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='11' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_NOV
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='12' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_DEC
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='01' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_JAN
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='02' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_FEB
,sum(CASE WHEN TO_CHAR(ORDERED_date,'MM')='03' THEN ORDERED_quantity*UNIT_SELLING_PRICE ELSE 0 END )ORDER_MAR
from jan_sales_any_TB2_1 where ORDERED_date>=(SELECT F_DT_CYR FROM JAN_SALES_BI_SETUP) AND ORDERED_date<(SELECT L_DT_CYR+1 FROM JAN_SALES_BI_SETUP) 
GROUP BY ORGANIZATION_ID ORDER  BY ORG "
        ElseIf cmb_criteria.Text = "Zone-wise sales" Then

            sql = "select * from jan_zone_wise_sales_v"

        ElseIf cmb_criteria.Text = "Branch Gate1" Then
            sql = "select case  substr(a.mnyear,0,2) when '04' then 'Apr' when '05' then 'May'  when '06' then 'Jun' when '07' then 'Jul' when '08' then 'Aug' when '09' then 'Sep' when '10' then 'Oct'when '11' then 'Nov'when '12' then 'Dec'when '01' then 'Jan'when '02' then 'Feb'when '03' then 'Mar' end month_name,a.*,nvl((select  round(sales_cyr/100000,2) from jan_regsales_any_tb1 where mnyear=a.mnyear and region=a.region),0)sale_cyr,nvl((select  round(sales_lyrfp/100000) from jan_regsales_any_tb1 where  mnyear=concat(substr(a.mnyear,0,2), substr(a.mnyear,3)-1) and region=a.region),0)sale_last_year,nvl((select  round(ord_recd/100000) from jan_regsales_any_tb1 where mnyear=a.mnyear and region=a.region),0)order_cyr from jan_reg_target0809  a  where mnyear1<to_char(sysdate,'YYYYMM') order  by region,mnyear1 "

        ElseIf cmb_criteria.Text = "Org-wise sales" Then
            sql = "select JAN_ORGCODE(ORGANIZATION_ID)ORG,a.*, CASE WHEN sales_lyr=0 THEN 100 ELSE round(((sales_cyr-sales_lyr)/sales_lyr)*100) END incr_per from (select DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)organization_id,round(sum(case when trx_date<add_months(trunc(sysdate,'MM'),-12) then (quantity_invoiced*unit_selling_price) else 0 end )/100000,2)sales_lyr,round(sum(case when trx_date>(select f_dt_cyr from jan_sales_bi_setup) and trx_date<trunc(sysdate,'MM') then (quantity_invoiced*unit_selling_price) else 0 end )/100000,2)sales_cyr from jan_sales_any_1_copy where trx_date>(select f_dt_lyr from jan_sales_bi_setup) group by DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID))a ORDER BY 1"

        ElseIf cmb_criteria.Text = "Order Receipt Customer category wise" Then
            sql = "select customer_category ,round(sum(ordered_quantity*unit_selling_price)/100000,2) order_value ,0 per from (select a.* ,nvl((select customer_category from jan_pick_forward_control where bill_to_customer_id= a.customer_id),case when a.customer_CLASS_CODE='DEALER' THEN 'D4' ELSE 'C4' END )customer_category from jan_sales_any_tb2_1 a  where ordered_date>(select f_dt_cyr from jan_sales_bi_setup)   and ordered_date<trunc(sysdate,'MM') )group by ROLLUP(customer_category) ORDER by customer_category"

        ElseIf cmb_criteria.Text = "Sales Customer category wise" Then
            sql = "select customer_category ,round(sum(quantity_invoiced*unit_selling_price)/100000,2) sale_value,0 per from (select a.* ,nvl((select customer_category from jan_pick_forward_control where bill_to_customer_id= a.bill_to_customer_id),case when a.customer_CLASS_CODE='DEALER' THEN 'D4' ELSE 'C4' END)customer_category from jan_sales_any_1_copy a  where ordered_date>(select f_dt_cyr from jan_sales_bi_setup)   and trx_date<trunc(sysdate,'MM') )group by ROLLUP(customer_category) ORDER by customer_category"

        ElseIf cmb_criteria.Text = "Delivery Rating" Then
            sql = "SELECT * FROM JAN_DELIVERY_RATING_CONSOLID ORDER BY CUSTOMER_CATEGORY"
        ElseIf cmb_criteria.Text = "Sales KPI1" Then
            sql = "select * from jan_sales_iso_kpi01"
        ElseIf cmb_criteria.Text = "Sales KPI2" Then
            sql = "select * from jan_sales_iso_kpi02"

        End If

        ds = SQL_SELECT("CUST", sql)
        Dim total As Double = 0
        Dim column_name As String = ""

        If cmb_criteria.Text = "Order Receipt Customer category wise" Or cmb_criteria.Text = "Sales Customer category wise" Then
            If cmb_criteria.Text = "Order Receipt Customer category wise" Then column_name = "order_value"
            If cmb_criteria.Text = "Sales Customer category wise" Then column_name = "sale_value"
            With ds.Tables(0)

                For i = 0 To .Rows.Count - 1
                    total += Math.Round(.Rows(i).Item("" & column_name & ""))
                Next

                For i = 0 To .Rows.Count - 1
                    .Rows(i).Item("per") = Math.Round((.Rows(i).Item("" & column_name & "") / total) * 100, 2)
                Next

            End With
        End If
        dgv1.DataSource = ds.Tables("CUST")


    End Sub
    Private Sub Mktg_mrm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
End Class