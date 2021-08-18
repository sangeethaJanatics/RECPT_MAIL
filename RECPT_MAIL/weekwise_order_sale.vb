Public Class weekwise_order_sale
    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click
        'jan_weekwise_order_pend_v week wise ofd order pending view
        If rad_dealer_order.Checked = True Or rad_dealer_org_order_receipt.Checked = True Or rad_dealer_order_ofd.Checked = True Or rad_dealer_org_order_ofd.Checked = True Then
            Dim order_receipt_for As String = ""

            If rad_dealer_order.Checked = True Or rad_dealer_org_order_receipt.Checked = True Then
                order_receipt_for = "ordered_date"
            Else
                order_receipt_for = "order_ff_dt "
            End If
            sql = " select  distinct to_char(" & order_receipt_for & ",'IYYYIW')wk from jan_sales_any_tb2_1  a where " & order_receipt_for & ">'1-jun-2020'  order by wk "
            ds = SQL_SELECT("wk", sql)

            sql = "select  "
            If rad_dealer_order.Checked = True Or rad_dealer_order_ofd.Checked = True Then sql &= " customer_name,region "

            If rad_dealer_org_order_receipt.Checked = True Or rad_dealer_org_order_ofd.Checked = True Then sql &= " jan_orgcode(organization_id)org  "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='042019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_apr2019 "

            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='052019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_may2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='062019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_jun2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='072019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_jul2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='082019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_aug2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='092019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_sep2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='102019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_oct2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='112019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_nov2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='122019' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_dec2019 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='012020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_jan2020 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='022020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_feb2020 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='032020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_mar2020 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='042020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_apr2020 "
            sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'MMYYYY')='052020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_may2020 "

            For i = 0 To ds.Tables("wk").Rows.Count - 1
                With ds.Tables("wk").Rows(i)
                    sql &= " ,round(sum (case when to_char(" & order_receipt_for & ",'IYYYIW')= '" & .Item("wk") & "' and " & order_receipt_for & ">'31-may-2020' then (ordered_quantity*unit_selling_price) else 0 end) /100000,2)order_" & .Item("wk") & " "
                End With
            Next


            sql &= "   from  jan_sales_any_tb2_1  a where trunc(" & order_receipt_for & ")>='1-apr-2019' and customer_id in (select customer_id from ra_customers where customer_class_code='DEALER'  )  group by "

            If rad_dealer_order.Checked = True Or rad_dealer_order_ofd.Checked = True Then sql &= " customer_name,region order by  customer_name,region "

            If rad_dealer_org_order_receipt.Checked = True Or rad_dealer_org_order_ofd.Checked = True Then sql &= " rollup(organization_id) order by organization_id"
        ElseIf Rad_ofd_order_pending.Checked = True Then
            sql = " select * from jan_OFD_order_pending_v "
        ElseIf Rad_FIFO_consolid.Checked = True Then
            sql = " select * from jan_rg1_manual_allo_con_v "
        ElseIf rad_active_oa_pending.Checked = True Then
            sql = " Select JAN_ORGCODE(organization_id)ORG,JAN_ITEMDESC(ORDERED_ITEM)DESCRIPTION,B.* ,JAN_SALES_RRS_CATEGORY(b.ORGANIZATION_ID,b.INVENTORY_ITEM_ID)rrs "
            sql &= ",NVL((SELECT ROUND(PVAL,2) FROM JAN_PRATE WHERE INVENTORY_ITEM_ID=B.INVENTORY_ITEM_ID),0)P_RATE "
            sql &= ",NVL((select sum(nettable_quantity) from mrp_onhand_quantities where COMPILE_DESIGNATOR ='MRP_SO_SS' and ORGANIZATION_ID=B.ORGANIZATION_ID and                                      
  INVENTORY_ITEM_ID=B.INVENTORY_ITEM_ID and sub_inventory_code in (select x.subinventory_code from jan_rg1_subinventories x)),0)FG_ONHAND                                          
from (
select organization_id,inventory_item_id,ORDERED_ITEM,sum(TOT_order_pend_upto_11oct2020)TOT_ord_pend_upto_day_befo_yes,sum( YESTERDAY_TOT_order_pending)YESTERDAY_order_TOT_pending
,sum( YESTERDAY_TOT_order_RECD)YESTERDAY_TOT_order_RECD ,sum( YESTER_order_pending_DSP)YESTER_DSP_order_pending,sum( YESTER_order_pending_MANUAL)YESTER_MANUAL_order_pending
,sum( YESTER_order_pending_CUSTOMER)YESTER_CUSTOMER_order_pending,sum( YESTERDAY_order_RECD_DSP)YESTERDAY_DSP_order_RECD ,sum( YESTERDAY_order_RECD_MANUAL)YESTERDAY_MANUAL_order_RECD
,sum( YESTERDAY_order_RECD_CUSTOMER)YESTERDAY_CUSTOMER_order_RECD,sum( ORDER_PEND_UPTO_11OCT_DSP)DSP_PEND_UPTO_day_befo_yes,sum( ORDER_PEND_UPTO_11OCT_MANUAL)MANUAL_PEND_UPTO_day_befo_yes
,sum( ORDER_PEND_UPTO_11OCT_CUSTOMER)CUST_PEND_UPTO_day_befo_yes ,sum(DDS_Pending)DDS_Pending from (
select organization_id,inventory_item_id,ORDERED_ITEM, sum(case when ordered_date<'" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' then (ordered_quantity-nvl(shipped_quantity,0)) 
else 0 end )TOT_order_pend_upto_11oct2020 
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )YESTERDAY_TOT_order_pending 
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' then (ordered_quantity) else 0 end )YESTERDAY_TOT_order_RECD
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)<>0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )YESTER_order_pending_DSP 
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)=0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )YESTER_order_pending_MANUAL
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "'  AND CUSTOMER_CLASS_CODE<>'DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )YESTER_order_pending_CUSTOMER
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)<>0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity) else 0 end )YESTERDAY_order_RECD_DSP 
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)=0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity) else 0 end )YESTERDAY_order_RECD_MANUAL
,sum(case when trunc(ordered_date)>='" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "'  AND CUSTOMER_CLASS_CODE<>'DEALER'
then (ordered_quantity) else 0 end )YESTERDAY_order_RECD_CUSTOMER "

            sql &= ",sum(case when trunc(ordered_date)<'" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)<>0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )ORDER_PEND_UPTO_11OCT_DSP  "
            sql &= ",sum(case when trunc(ordered_date)<'" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "' AND NVL(ORDER_TYPE,0)=0 AND CUSTOMER_CLASS_CODE='DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )ORDER_PEND_UPTO_11OCT_MANUAL "
            sql &= ",sum(case when trunc(ordered_date)<'" & Format(yesterday_date.Value, "dd-MMM-yyyy") & "'  AND CUSTOMER_CLASS_CODE<>'DEALER'
then (ordered_quantity-nvl(shipped_quantity,0)) else 0 end )ORDER_PEND_UPTO_11OCT_CUSTOMER
,0 dds_pending "
            sql &= " from jan_sales_any_tb2_1  X where (ordered_quantity-nvl(shipped_quantity,0))>0
AND (CASE WHEN BOOKED_DATE<'9-MAY-2020' 
AND nvl((SELECT COUNT(*) FROM JAN_ORDER_ACTIVE_INACTIVE WHERE header_id||'.'||Line_number= x.header_id||'.'||x.Line_number),0)=0 THEN  0 
ELSE 1 END)=1
and order_ff_dt<'" & Format(yesterday_ord_ofd.Value, "dd-MMM-yyyy") & "'
group by organization_id,inventory_item_id,ORDERED_ITEM "
            sql &= " union "
            sql &=" SELECT organization_id,inventory_item_id,jan_itemname(inventory_item_id)item_no,0 TOT_order_pend_upto_11oct2020,0 YESTERDAY_TOT_order_pending,
0 YESTERDAY_TOT_order_RECD ,0 YESTER_order_pending_DSP,0 YESTER_order_pending_MANUAL,0 YESTER_order_pending_CUSTOMER,0 YESTERDAY_order_RECD_DSP
,0 YESTERDAY_order_RECD_MANUAL,0 YESTERDAY_order_RECD_CUSTOMER,0 ORDER_PEND_UPTO_11OCT_DSP,0 ORDER_PEND_UPTO_11OCT_MANUAL,0 ORDER_PEND_UPTO_11OCT_CUSTOMER,
sum(REQUIREMENT-cancelled_qty-receipt_qty)DDS_Pending FROM jan_cylinder_ds_lines  
where demand_source='MKTG' 
group by organization_id,inventory_item_id)group by organization_id,inventory_item_id,ORDERED_ITEM
)B"

        ElseIf Rad_FIFO_brk.Checked Then
            sql = " select * from jan_rg1_manual_allo_brk_v "
        ElseIf Rad_delivery_rating.Checked = True Then
            sql = " SELECT CUSTOMER_NAME,REGION,ORG,PRODUCT_GROUP "
 sql &= "   ,round(sum(CASE WHEN TRX_DATE IS NOT NULL AND TRX_DATE<=order_ff_dt+7 THEN ORDERED_QUANTITY ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPLETED_WITHIN_7_DAYS_per "
 sql &= "   ,round(sum(CASE WHEN TRX_DATE IS NOT NULL AND TRX_DATE>order_ff_dt+7 AND TRX_DATE<=order_ff_dt+10 THEN ORDERED_QUANTITY ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPLETED_WITHIN_10_DAYS_per "
 sql &= "   ,round(sum(CASE WHEN TRX_DATE IS NOT NULL AND TRX_DATE>order_ff_dt+10 AND TRX_DATE<=order_ff_dt+21 THEN ORDERED_QUANTITY ELSE 0 END )/sum(ORDERED_QUANTITY),2)*100 COMPLETED_WITHIN_21_DAYS_per "
            sql &= "   FROM ( "
            sql &= "   Select  JAN_ORGCODE(ORGANIZATION_ID)ORG,JAN_ITEMNAME(INVENTORY_ITEM_ID)ITEM_NO,B.*,
case when LEVEL_5='Product' then "
            sql &= "   NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') 
when LEVEL_5='Tube'  and level_2='WHC' then "
 sql &= "    NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP "
            sql &= "   FROM ( "
            sql &= "                Select  "
            sql &= "   C.*,NVL((SELECT LEVEL_2 FROM JAN_ITEM_CATEGORY WHERE ORGANIZATION_ID=C.ORGANIZATION_ID AND INVENTORY_ITEM_ID=C.INVENTORY_ITEM_ID),'Others')LEVEL_2 "
            sql &= "   ,NVL((SELECT LEVEL_5 FROM JAN_ITEM_CATEGORY WHERE ORGANIZATION_ID=C.ORGANIZATION_ID AND INVENTORY_ITEM_ID=C.INVENTORY_ITEM_ID),'Others')LEVEL_5 FROM ( "
            sql &= "  Select 
ORGANIZATION_ID,INVENTORY_ITEM_ID,SUM(ORDERED_QUANTITY)ORDERED_QUANTITY,CUSTOMER_NAME,REGION,OFD_MONTH,order_ff_dt,TRX_DATE
FROM ( "
            sql &= "  Select  TO_CHAR(order_ff_dt,'MMIYYY')OFD_MONTH,A.* FROM jan_sales_any_tb2_1 A
where customer_id  in (select customer_id from ra_customers where customer_class_code='DEALER'
/* and customer_id=1093 */)"
            sql &= "   and order_ff_dt>'" & Format(OFD_date_from.Value, "dd-MMM-yyyy") & "' AND ORDERED_QUANTITY>0 "
            'sql &= "   AND INVENTORY_ITEM_ID=37754 "
            sql &= "   ) GROUP BY ORGANIZATION_ID,INVENTORY_ITEM_ID,TRX_DATE,CUSTOMER_NAME,REGION,OFD_MONTH,order_ff_dt,TRX_DATE)C)B)
group by CUSTOMER_NAME,REGION,ORG,PRODUCT_GROUP"
        Else
            Dim view_name As String = ""

            If rad_region_ord.Checked = True Or Rad_org_ord.Checked = True Or rad_product_group_ord.Checked = True Or Rad_cust_ord.Checked = True Then

                view_name = " jan_weekwise_order_sale_v2 "

            ElseIf rad_region_ofd.Checked = True Or rad_orgwise_ofd.Checked = True Or rad_product_groupwise_ofd.Checked = True Or rad_customer_wise_ofd.Checked = True Then
                view_name = " jan_weekwise_order_sale_v "
            End If

            sql = "select "
            If rad_region_ofd.Checked = True Or rad_region_ord.Checked = True Then sql &= " sub_region,region,  "
            If rad_customer_wise_ofd.Checked = True Or Rad_cust_ord.Checked = True Then sql &= " customer_name ,customer_class_code, "

            If rad_orgwise_ofd.Checked = True Or Rad_org_ord.Checked = True Then sql &= " jan_orgcode(organization_id)org,"
            If rad_product_groupwise_ofd.Checked = True Or rad_product_group_ord.Checked = True Then sql &= " jan_orgcode(organization_id)org,PRODUCT_GROUP,"

            sql &= "  sum(sale_2019_20)sale_2019_20 "
            sql &= " , sum(sale_2020_21)sale_2020_21 "


            sql &= " ,sum( sale_upto_wk_13)sale_upto_wk_13,sum( sale_wk_14)sale_wk_14,sum( sale_wk_15)sale_wk_15,sum( sale_wk_16)sale_wk_16,sum( sale_wk_17)sale_wk_17,sum( sale_wk_18)sale_wk_18,sum( sale_wk_19)sale_wk_19,sum( sale_wk_20)sale_wk_20,sum( sale_wk_21)sale_wk_21,sum( sale_wk_22)sale_wk_22,sum( sale_wk_23)sale_wk_23,sum( sale_wk_24)sale_wk_24,sum( sale_wk_25)sale_wk_25,sum( sale_wk_26)sale_wk_26,sum( sale_wk_27)sale_wk_27,sum( sale_wk_28)sale_wk_28,sum( sale_wk_29)sale_wk_29,sum( sale_wk_30)sale_wk_30,sum( sale_wk_31)sale_wk_31,sum( sale_wk_32)sale_wk_32,sum( sale_wk_33)sale_wk_33,sum( sale_wk_34)sale_wk_34"

            sql &= " ,sum( sale_wk_35)sale_wk_35,sum( sale_wk_36)sale_wk_36,sum( sale_wk_37)sale_wk_37,sum( sale_wk_38)sale_wk_38,sum( sale_wk_39)sale_wk_39,sum( sale_wk_40)sale_wk_40,sum( sale_wk_41)sale_wk_41,sum( sale_wk_42)sale_wk_42,sum( sale_wk_43)sale_wk_43,sum( sale_wk_44)sale_wk_44,sum( sale_wk_45)sale_wk_45,sum( sale_wk_46)sale_wk_46,sum( sale_wk_47)sale_wk_47,sum( sale_wk_48)sale_wk_48,sum( sale_wk_49)sale_wk_49,sum( sale_wk_50)sale_wk_50"

            sql &= ",sum( ord_upto_wk_13)ord_upto_wk_13,sum( ord_wk_14)ord_wk_14     "


            sql &= ", sum( ord_wk_15)ord_wk_15,sum( ord_wk_16)ord_wk_16,sum( ord_wk_17)ord_wk_17,sum( ord_wk_18)ord_wk_18 ,sum( ord_wk_19)ord_wk_19,sum( ord_wk_20)ord_wk_20,sum( ord_wk_21)ord_wk_21,sum( ord_wk_22)ord_wk_22,sum( ord_wk_23)ord_wk_23,sum( ord_wk_24)ord_wk_24
,sum( ord_wk_25)ord_wk_25,sum( ord_wk_26)ord_wk_26,sum( ord_wk_27)ord_wk_27,sum( ord_wk_28)ord_wk_28,sum( ord_wk_29)ord_wk_29,sum( ord_wk_30)ord_wk_30,sum( ord_wk_31)ord_wk_31,sum( ord_wk_32)ord_wk_32 "

            sql &= " ,sum( ord_wk_33)ord_wk_33 ,sum( ord_wk_34)ord_wk_34 ,sum( ord_wk_35)ord_wk_35 ,sum( ord_wk_36)ord_wk_36 ,sum( ord_wk_37)ord_wk_37 ,sum( ord_wk_38)ord_wk_38 ,sum( ord_wk_39)ord_wk_39 ,sum( ord_wk_40)ord_wk_40 ,sum( ord_wk_41)ord_wk_41 ,sum( ord_wk_42)ord_wk_42 ,sum( ord_wk_43)ord_wk_43 ,sum( ord_wk_44)ord_wk_44 ,sum( ord_wk_45)ord_wk_45 ,sum( ord_wk_46)ord_wk_46 ,sum( ord_wk_47)ord_wk_47 ,sum( ord_wk_48)ord_wk_48 ,sum( ord_wk_49)ord_wk_49 ,sum( ord_wk_50)ord_wk_50 "
            sql &= " from( "

            sql &= " select b.* "

            If rad_product_groupwise_ofd.Checked = True Or rad_product_group_ord.Checked = True Then sql &= " ,case when LEVEL_5='Product' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') when LEVEL_5='Tube'  and level_2='WHC' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP "

            sql &= " from ( select (select customer_name from ra_customers where customer_id=a.bill_to_customer_id)customer_name,(select customer_class_code from ra_customers where customer_id=a.bill_to_customer_id)customer_class_code "
            If rad_product_groupwise_ofd.Checked = True Or rad_product_group_ord.Checked = True Then sql &= " ,nvl((select level_2 from jan_item_category where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id),'Others')level_2,nvl((select level_5 from jan_item_category where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id),'Others')level_5 "

            sql &= " ,a.* from " & view_name & "  a  " 'where  bill_to_customer_id=1093 "

            sql &= " )b) "
            If rad_region_ofd.Checked = True Or rad_region_ord.Checked = True Then sql &= "  group by  sub_region,region  "
            If rad_customer_wise_ofd.Checked = True Or Rad_cust_ord.Checked = True Then sql &= " group by   customer_name ,customer_class_code "

            If rad_orgwise_ofd.Checked = True Or Rad_org_ord.Checked = True Then sql &= "  group by  organization_id "
            If rad_product_groupwise_ofd.Checked = True Or rad_product_group_ord.Checked = True Then sql &= " group by   PRODUCT_GROUP,organization_id"
            'sql &= " group by  region ,sub_region,organization_id,customer_name,customer_class_code"
            Cursor.Current = Cursors.WaitCursor
        End If
        ds = New DataSet
        ds = SQL_SELECT("res", sql)

            With dgv1
                .DataSource = ds.Tables("res")
                If rad_dealer_order.Checked = True Then
                    For i = 2 To .Columns.Count - 1
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    Next
                End If
            End With
            Cursor.Current = Cursors.Default
    End Sub

    Private Sub weekwise_order_sale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = " select sTOCK_MANUAL_ALLO_END_DATE from jan_sales_bi_setup "
        ds = SQL_SELECT("res", sql)
        Label2.Text = "FIFO allocation Status as on :" & ds.Tables("res").Rows(0).Item("sTOCK_MANUAL_ALLO_END_DATE")
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles yesterday_date.ValueChanged

    End Sub

    Private Sub rad_active_oa_pending_CheckedChanged(sender As Object, e As EventArgs) Handles rad_active_oa_pending.CheckedChanged
        If rad_active_oa_pending.Checked = True Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub


End Class