Public Class Dealer_payment_new
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_go.Click
        If rad_week.Checked = True Then
            sql = "select * from JAN_DEALER_PAYMENT_OS_V "
            If ddl_cust.SelectedValue <> "0" Then
                sql &= " where bill_to_cust_name=(select customer_name from ra_customers where customer_id=" & ddl_cust.SelectedValue & ")"
            End If
            sql &= " order by bill_to_cust_name"

        ElseIf Rad_Despatch_vs_Payment.Checked = True Then
            sql = "SELECT * FROM JAN_DEALER_DESPATCH_PAYMENT_V WHERE 1=1 "
            If ddl_cust.SelectedValue <> "0" Then
                sql &= " and bill_to_customer_id=" & ddl_cust.SelectedValue & " "
            End If
            sql &= " order by bill_to_cust_name,wk_no"
        ElseIf rad_os_breakup.Checked = True Then
            sql = "select /* case when trim(to_char(trx_date,'Day'))='Saturday' then  to_number(to_char(trx_date+2,'IW'))else to_number(to_char(trx_date,'IW')) end */ to_number(to_char(trx_date,'IW')) final_week_no,to_char(sysdate,'IW') current_week,to_char(trx_date,'Day')inv_day,to_char(trx_date,'IW')inv_week_no , nvl((select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id),'D4')dealer_category, a.* from jan_region_payment_pending_tab  a where bill_to_customer_id in (select customer_id from ra_customers where customer_class_code='DEALER')  and a.AMOUNT_DUE_REMAINING>0"
            If ddl_cust.SelectedValue <> "0" Then
                sql &= " and bill_to_customer_id=" & ddl_cust.SelectedValue & " "
            End If
            sql &= "  order by final_week_no,bill_to_cust_name"
        ElseIf rad_unapplied.Checked = True Then
            sql = "select * from jan_sales_any_pay_unapplied where customer_name  in (select customer_name from ra_customers where customer_class_code='DEALER' "
            If ddl_cust.SelectedValue <> "0" Then
                sql &= " and customer_name=(select customer_name from ra_customers where customer_id=" & ddl_cust.SelectedValue & ")"
            End If

            sql &= "   )  order by customer_name"
        ElseIf RAD_DELIVERY_RATING.Checked = True Then
            sql = " select jan_orgcode(organization_id)org,customer_name,region,product_group,case when nvl(order_type,0)=0 then 'Manual' else 'DSP' end order_type
, round(sum(CASE WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)<>0 and  TRX_DATE<=order_ff_dt+7  THEN ORDERED_QUANTITY
WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)=0 and  TRX_DATE<=ordered_date+7  THEN ORDERED_QUANTITY
ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPLETED_WITHIN_7_DAYS_per  

, round(sum(CASE WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)<>0 and  TRX_DATE>order_ff_dt+7   and  TRX_DATE<=order_ff_dt+14 THEN ORDERED_QUANTITY
WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)=0 and  TRX_DATE>ordered_date+7  and  TRX_DATE<=ordered_date+14  THEN ORDERED_QUANTITY
ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPl_WITHIN_8_14_DAYS_per

, round(sum(CASE WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)<>0 and  TRX_DATE>order_ff_dt+14   and  TRX_DATE<=order_ff_dt+21 THEN ORDERED_QUANTITY
WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)=0 and  TRX_DATE>ordered_date+14  and  TRX_DATE<=ordered_date+21  THEN ORDERED_QUANTITY
ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPl_WITHIN_15_21_DAYS_per

, round(sum(CASE WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)<>0 and  TRX_DATE>order_ff_dt+21  THEN ORDERED_QUANTITY
WHEN TRX_DATE IS NOT NULL AND nvl(order_type,0)=0 and  TRX_DATE>ordered_date+21  THEN ORDERED_QUANTITY
ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPLETED_above_21_DAYS_per  

, round(sum(CASE WHEN TRX_DATE IS NOT NULL  THEN ORDERED_QUANTITY
ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 total_COMPLETED_per  
from (
select b.* ,
case when LEVEL_5='Product' then    NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') 
when LEVEL_5='Tube'  and level_2='WHC' then     NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') 
else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP from (
select a.*
,NVL((SELECT LEVEL_2 FROM JAN_ITEM_CATEGORY WHERE ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID),'Others')LEVEL_2  
,NVL((SELECT LEVEL_5 FROM JAN_ITEM_CATEGORY WHERE ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID),'Others')LEVEL_5

from (select organization_id,inventory_item_id,TRX_DATE,region,customer_name,nvl(order_type,0)order_type,ordered_date,order_ff_dt,sum(ORDERED_QUANTITY)ORDERED_QUANTITY
FROM jan_sales_any_tb2_1 where customer_id  in (select customer_id from ra_customers where customer_class_code='DEALER' "
            If ddl_cust.SelectedValue <> "0" Then sql &= " and customer_id=" & ddl_cust.SelectedValue & " "
            sql &= " )   and order_ff_dt>'" & Format(DateTimePicker_ofd_from.Value, "dd-MMM-yyyy") & "'   and order_ff_dt<'" & Format(DateTimePicker_ofd_to.Value, "dd-MMM-yyyy") & "'  

 AND ORDERED_QUANTITY>0  group by organization_id,inventory_item_id,TRX_DATE,region,customer_name,nvl(order_type,0),ordered_date,order_ff_dt)a)b)
 
 group by customer_name,region,organization_id,product_group,case when nvl(order_type,0)=0 then 'Manual' else 'DSP' end "

        ElseIf Rad_weekwise_order_pend.Checked = True Then
            sql = " select customer_name,jan_orgcode(ORGANIZATION_ID)org,week_no,PRODUCT_GROUP,sum((ORDERED_QUANTITY-nvl(shipped_quantity,0)))order_pending_qty, sum((ORDERED_QUANTITY-nvl(shipped_quantity,0))*unit_selling_price)order_pending_value from ( select b.* ,case when LEVEL_5='Product' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP  from ( select a.*,to_char(order_ff_dt,'IYYYIW')week_no ,(select level_2 from jan_item_category where ORGANIZATION_ID=a.ORGANIZATION_ID and inventory_item_id=a.inventory_item_id)level_2 ,(select level_5 from jan_item_category where ORGANIZATION_ID=a.ORGANIZATION_ID and inventory_item_id=a.inventory_item_id)level_5 from jan_sales_any_tb2_1 a  where ordered_date>(select min(ordered_date)-1 from jan_sales_plan_tv_t)   /* and ord_type<>'Service Invoice' */ and (ORDERED_QUANTITY-nvl(shipped_quantity,0))>0 and customer_id in  ( Select Customer_Id From Ra_Customers  Where Customer_Class_Code='DEALER' "

            sql = " select customer_name,to_char(order_ff_dt,'IYYYIW')week_no,sum((ORDERED_QUANTITY-nvl(shipped_quantity,0)))order_pending_qty, sum((ORDERED_QUANTITY-nvl(shipped_quantity,0))*unit_selling_price)order_pending_value  from jan_sales_any_tb2_1   where ordered_date>(select min(ordered_date)-1 from jan_sales_plan_tv_t)   /* and ord_type<>'Service Invoice' */ and (ORDERED_QUANTITY-nvl(shipped_quantity,0))>0 and customer_id in  ( Select Customer_Id From Ra_Customers  Where Customer_Class_Code='DEALER' "

            If ddl_cust.SelectedValue <> "0" Then sql &= " and customer_id=" & ddl_cust.SelectedValue & " "

            sql &= " ) Group By Organization_Id,to_char(order_ff_dt,'IYYYIW'),Customer_Name"
        End If

        ds = SQL_SELECT("data", sql)
        'ds.Tables("data")
        If Rad_weekwise_order_pend.Checked = True Then ds.Tables("data").DefaultView.Sort = "customer_name,week_no asc"
        'If Rad_weekwise_order_pend.Checked = True Then
        '    With ds.Tables("data")
        '        .Rows.Add("Total")
        '        .Rows(.Rows.Count - 1).Item("order_pending_value") = .Compute("sum(order_pending_value)", "order_pending_value>=0")
        '    End With
        'End If
        If Rad_Despatch_vs_Payment.Checked = True Then
            With ds.Tables("data")
                .Rows.Add()
                .Rows(.Rows.Count - 1).Item("invoiced_amout") = .Compute("sum(invoiced_amout)", "invoiced_amout>=0")
                .Rows(.Rows.Count - 1).Item("amount_due_remaining") = .Compute("sum(amount_due_remaining)", "amount_due_remaining>=0")
                .Rows(.Rows.Count - 1).Item("payment_recd") = .Compute("sum(payment_recd)", "payment_recd>=0")
                .Rows(.Rows.Count - 1).Item("bill_to_cust_name") = "Total"
            End With

        End If
        With dgv1
            .DataSource = ds.Tables("data")
            If Rad_weekwise_order_pend.Checked = True Then
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            If Rad_Despatch_vs_Payment.Checked = True Then
                .Columns("invoiced_amout").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("amount_due_remaining").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns("payment_recd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            End If

        End With



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub Dealer_payment_new_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = " select customer_name,customer_id from ra_customers where customer_class_code='DEALER' union select 'ALL' customer_name ,0 customer_id  from dual order by customer_name "
        ds = SQL_SELECT("data", sql)

        ddl_cust.DisplayMember = "customer_name"
        ddl_cust.ValueMember = "customer_id"
        ddl_cust.DataSource = ds.Tables("DATA")
    End Sub


End Class