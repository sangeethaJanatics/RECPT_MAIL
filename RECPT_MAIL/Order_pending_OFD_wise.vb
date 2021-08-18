Public Class Order_pending_OFD_wise

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = "select region ""Region"",CUSTOMER_CATEGORY ""Cust Cat"",customer_NAme ""Customer Name"",org ""Org"",Ordered_item ""Item No"",order_pending_qty ""Pending qty"",order_pending_value ""Pending Value"",rsv_qty ""Rsv Qty"",rsv_val ""Rsv value"",rsv_status ""Rsv Status"",weekno ""Fulfillment Wk no"",ds_pending_from ""Ds week"",PAYMENT_STATUS ""Payment Status"",case when ds_pending_from is null then 'Not in DS' else ds_pending_from end ""DS Status"" from (SELECT A.* ,(select min(week_no) from jan_demand_Set_tmp_v where  pending_qty>0 and organization_id=a.organization_id and  inventory_item_id=a.inventory_item_id)ds_pending_from,NVL((SELECT FINAL_RRS FROM JAN_RRS_CATEGORY_MASTER WHERE ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID),'St')RRS_CAT,(SELECT CUSTOMER_CATEGORY FROM JAN_PICK_FORWARD_CONTROL WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID)CUSTOMER_CATEGORY,(SELECT PAYMENT_STATUS FROM JAN_DEALER_PAYMENT2 WHERE LINE_ID=A.LINE_ID)PAYMENT_STATUS,case when rsv_qty=order_pending_qty then 'Completed' when rsv_qty=0 then 'Pending' else 'Partial Rsv' end rsv_status FROM (select LINE_ID,region,CUSTOMER_ID,customer_name,jan_orgcode(organization_id)org,organization_id,inventory_item_id,ordered_item,sum((ordered_quantity-nvl(shipped_quantity,0)))order_pending_qty,sum((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price)order_pending_value,TO_CHAR(ORDER_FF_DT,'IYYYIW')weekno,sum(nvl(rsv_qty,0)+nvl(picked_qty,0))rsv_qty,sum((nvl(rsv_qty,0)+nvl(picked_qty,0))*unit_selling_price)rsv_val from jan_sales_any_tb2_1   where (ordered_quantity-nvl(shipped_quantity,0))>0 and customer_id "
        If rad_customer.Checked = True Then sql &= " not in "
        If rad_dealer.Checked = True Then sql &= "  in "

        sql &= " (select customer_id from ra_customers where customer_class_code='DEALER')and ORDER_FF_DT<='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' group by region,customer_name,organization_id,ordered_item,TO_CHAR(ORDER_FF_DT,'IYYYIW'),inventory_item_id,CUSTOMER_ID,LINE_ID)A)  order by customer_NAme,region"

        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")
    End Sub
End Class