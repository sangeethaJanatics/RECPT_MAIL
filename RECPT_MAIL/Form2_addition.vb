Public Class Form2_addition
    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click
        If Rad_FORM2_DETAIL.Checked = True Then


            sql = "select customer_name,Contact_Person,contact_designation Designation
,bill_to_address bill_to,bill_to_city,bill_to_state,bill_to_pin_code,BILL_TO_PHONE_NO
,email_id,pan_no_bill_to,bill_to_gst,ship_to_address,ship_to_city
,ship_to_state,ship_to_pin_code,pan_no_ship_to,ship_to_gst
,case  customer_class_code when 0 then 'DEALER'   when 1 then 'OEM' 
 when 2 then 'REPLACEMENT'  when 3 then 'CSE visit'  when 4 then 'OTHERS' end Customer_Class
 ,
 case  customer_source when 0 then 'Customer Enquiry'   when 1 then 'Exhibition'  
   when 2 then 'Dealer Reference'   when 3 then 'CSE visit'   when 4 then 'Others'end 
 Source_of_Customer
 ,
 case when nvl(customer_handled_dealer,1)=0 then 'Yes' else 'No' end Customer_Pres_handled_Dealer
 ,INDUSTRIAL_SEGMENT,ind_sub_segment,activity_detail Details_of_activity,
 case  RECOMEND_DIRECT_SUPPLY when 0 then 'CUSTOMER INSISTENCE ON DIRECT SUPPLY'
     when 1 then 'EXCISE & OTHER TAX BENIFITS ( MODVAT ) ETC'
       when 2 then 'DEALER SUPPORT NOT ADEQUATE (OFFER , SUPPLY) ETC'
         when 3 then 'OTHER REASONS , PLEASE SPECIFY' end Reason_for_Direct_Supply
          ,
          case ANUAL_PURCHASE_VALUE when '0' then 'Less than 1 Lakh' 
          when '1' then '2 to 5 Lakhs' 
           when '2' then '5 to 10 Lakhs' when '3' then '10 to 15 Lakhs'  when '4' then 'More than 15 Lakhs'
          end Annual_value_of_pur,potential_of_pneumatic,total_potential,
          OUR_SHARE_IN_TOTAL_POTENTIAL,COMP_SHARE_IN_TOTAL_POTENTIAL,COMPETITOR_NAME1,COMPETITOR1_SHARE
          ,COMPETITOR_NAME2,COMPETITOR2_SHARE
          ,COMPETITOR_NAME3,COMPETITOR3_SHARE,business_expected_first_yr,business_fin_year Busin_Expect_this_Fin
          ,case  when nvl(BUYING_ALL_PRODUCTS,0)=1 then 'No' else 'Yes' end  Buying_all_Products
             ,case  when nvl(INWARD_SYSTEM_AVAILABLE,0)=1 then 'No' else 'Yes' end  INWARD_SYSTEM_AVAILABLE
           ,INWARD_AVAILABLE_DETAIL,customer_support_engineer,discount,PACKING_FORWARDING
              ,case  when nvl(GST_YES_NO,0)=1 then 'No' else 'Yes' end  GST_YES_NO
              , case  PAYMENT_TERMS when 0 then 'IMMEDIATE'
     when 1 then '7 Days'
       when 2 then '15 Days'
         when 3 then '30 Days'  when 4 then '45 Days'  when 5 then 'AGAINST DELIVERY'
         when 6 then 'DOD'  when 6 then 'DACC' end PAYMENT_TERMS
         ,case  FREIGHT   when 0 then 'TO PAY' when 1 then 'COLLECT IN THE INVOICE'
         when 2 then 'FEDEX'  end FREIGHT
             ,case  MODE_OF_TRANSPORT   when 0 then 'BLUE DART' when 1 then 'GATI'
         when 2 then 'FEDEX' when 3 then 'ABT Expres' 
         when 4 then 'Startrek'
           when 5 then 'Future'
           when 6 then 'Shree Maruti'
             when 7 then 'Others'
         end Janatics_Nominated_Transport,cust_nominated_transport,case nvl(CRM_REQUIRED,0) when 0 then 'None' when 1 then 'Yes' when 2 then 'No' end  CRM_REQUIRED
         ,crm_contact_person,CRM_CONTACT_DESIGNATION,CRM_CONTACT_EMAIL,CRM_CONTACT_MOBILE,creation_date form2_date
 from jan_form2_master where creation_date>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and  creation_date<'" & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & "'"
        ElseIf Rad_order_receipt_rev_model.Checked = True Then

            sql = " select order_number,ordered_date,cust_NAme,region, po_no, po_dt,flow_status_code,sum(order_value_without_tax)order_value_without_tax,ord_type,
cust_type 
,  ord_cat from (
select order_number,ordered_date,cust_NAme,region,cusordno po_no,cusorddt po_dt,flow_status_code,(ordered_quantity*unit_selling_price)order_value_without_tax,ord_type,
case when demand_class_code='DEALER' then 'Dealer' else 'Customer' end cust_type 
,case  when (select count(*) from jan_pick_forward_control_2 where customer_id=a.cust_id and key_customer>0)>0 then 'Key Customer'
when b_cust_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') then 'Project'
when b_cust_NAme in ('GROZ ENGINEERING TOOLS PVT.LTD','MARSH BELLOFRAM','MARSH BELLOFRAM EUROPE LTD','PREVOST SAS') then 'Brand Mfg'
 when ( select count(*) from jan_rev_model_project_items where inventory_item_id=a.inventory_item_id )=0  and  ship_from_org_id<>664 
 and ordered_item like 'A91SL%' or ordered_item like 'A40%' or ordered_item like 'DR%' or ordered_item like 'GU%' or  ordered_item like 'PT%'
or ordered_item like 'A02%G%' or ordered_item like 'A03%G%' or ordered_item like 'DS4%' or ordered_item like 'M01163' or ordered_item like 'M01161' 
or ordered_item like 'A50%' or ordered_item like 'AG02%G%'  or ordered_item like  'F14623-N1' or ordered_item like  'F15633-G1' or ordered_item like  'F17643-G1' 
or ordered_item like  'F17653-G1' 
then 'New_Product' 
when demand_class_code='DEALER'   then web_order_ref_no
else 'Customer Order' end  ord_cat
from jan_bms_order_pending_new_v  a where ordered_date >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and trx_date<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' )

group by order_number,ordered_date,cust_NAme,region, po_no, po_dt,flow_status_code,ord_type,cust_type ,  ord_cat
order by order_number,ordered_date,cust_NAme,region"
        ElseIf Rad_sale_discount.Checked = True Then
            sql = "Select my,sum(quantity_invoiced*unit_selling_price)actual_sale,sum(quantity_invoiced*unit_selling_price_new)calculated_sale from (
Select  c.*
,case when trx_date<'1-apr-2020' then unit_selling_price 
when scheme_order='Y' and disc=35 then  round(unit_standard_price *.75,2) else unit_selling_price end unit_selling_price_new
from(
select b.*
,nvl((select DSP_MAST.SCHEME_ORDER from oe_dms_order_headers_all dms_h,jan_dsp_master dsp_mast
where  dms_h.oe_dsp_id = dsp_mast.dsp_id And dms_h.oe_order_ref_no = b.web_order_ref),'N')scheme_order
from(
select a.*
,nvl(( SELECT   SUM(operand)   FROM oe_price_adjustments_v adj  WHERE 
	adj.line_id = A.LINE_ID And adj.applied_flag = 'Y' AND adj.list_line_type_code <> 'FREIGHT_CHARGE'),0)disc
    ,(select web_order_ref_lno from jan_sales_any_tb2_1 where line_id=a.line_id)web_order_ref
From jan_sales_any_1_copy a  Where trx_date >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and trx_date<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' 
--And bill_to_customer_id = 1093
)b)c) group by my"
        ElseIf Rad_order_receipt_rev_model.Checked = True Then

            sql = "select customer_NAme,region,sum(case when project_customer='Project' then  order_qty else 0 end)  proj_order_qty
,sum(case when project_customer='Project' then  Value_before_Tax else 0 end ) proj_order_value

,sum(case when brand_mfg='BRAND-MFG' then  order_qty else 0 end ) brand_order_qty
,sum(case when brand_mfg='BRAND-MFG' then  Value_before_Tax else 0 end ) brand_order_value

,sum(case when project_customer is null and brand_mfg is null and  New_Product='Y' then  order_qty else 0 end ) new_prod_order_qty
,sum(case when project_customer is null and brand_mfg is null and New_Product='Y' then  Value_before_Tax else 0 end ) new_prod_order_value

,sum(case when project_customer is null and brand_mfg is null and  New_Product='N' then  order_qty else 0 end  )regular_order_qty
,sum(case when project_customer is null and brand_mfg is null and New_Product='N' then  Value_before_Tax else 0 end  )regular_order_value
 from (
select a.*,jan_itemdesc(ordered_item)description
,(select customer_class_code from ra_customers where customer_id=a.customer_id)customer_category "
            'sql &= " ,(select decode(count(*) ,0,null, 'Project')  from ra_customers where customer_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') and  customer_id=a.customer_id)project_customer "
            sql &= " ,case when  organization_id=664 then 'Project' 
when ( select count(*) from jan_rev_model_project_items where inventory_item_id=a.inventory_item_id )>0 then 'Project'
when (select count(*)   from ra_customers
where customer_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') 
and  customer_id=a.customer_id)>0 then 'Project' else null end   project_customer "

            sql &= " ,(select decode(count(*) ,0,null,  'BRAND-MFG') from ra_customers
where customer_NAme in ('GROZ ENGINEERING TOOLS PVT.LTD','MARSH BELLOFRAM','MARSH BELLOFRAM EUROPE LTD','PREVOST SAS') and  customer_id=a.customer_id)brand_mfg "

            sql &= " ,case when ( select count(*) from jan_rev_model_project_items where inventory_item_id=a.inventory_item_id )>0 then 'N' 
when organization_id=664 then 'N' when ordered_item like 'A91SL%' or ordered_item like 'A40%' or ordered_item like 'DR%' or ordered_item like 'GU%' or  ordered_item like 'PT%'
or ordered_item like 'A02%G%' or ordered_item like 'A03%G%' or ordered_item like 'DS4%' or ordered_item like 'M01163' or ordered_item like 'M01161' 
or ordered_item like 'A50%' or ordered_item like 'AG02%G%'  or ordered_item like  'F14623-N1' or ordered_item like  'F15633-G1' or ordered_item like  'F17643-G1' or ordered_item like  'F17653-G1' 
then 'Y' else 'N' end New_Product
from ("
            'sql &= " Select Case customer_NAme,region,order_number,customer_id,ordered_item,trunc(ordered_date)ord_dt,sum(ordered_quantity)order_qty,inventory_item_id,organization_id,to_char(order_ff_dt,'yyyyWW')ofd_wk,sum(ordered_quantity*unit_selling_price)Value_before_Tax from jan_sales_any_tb2_1 where trunc(ordered_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(ordered_date)<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' "

            '--and customer_id in (1482580,1826584,3288590,4124604,2410,2941590,2981590,2959590,1093)
            'sql &= " group by trunc(ordered_date), customer_NAme,region,order_number,customer_id,ordered_item,inventory_item_id,organization_id,to_char(order_ff_dt,'yyyyWW')"
            sql &= " select b_cust_name customer_NAme,region,order_number,sold_to_org_id customer_id,ordered_item,trunc(ordered_date)ord_dt,sum(ordered_quantity)order_qty,inventory_item_id
,ship_from_org_id organization_id,to_char(ord_ff_dt,'yyyyWW')ofd_wk,
sum(ordered_quantity*unit_selling_price)Value_before_Tax from jan_bms_order_pending_new_v where trunc(ordered_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(ordered_date)<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' "
            If Rad_order_entered.Checked = True Then
                sql &= " and flow_status_code='ENTERED' "
            ElseIf Rad_order_booked.Checked = True Then
                sql &= " and flow_status_code='AWAITING_SHIPPING' "
            End If
            sql &= " group by trunc(ordered_date), b_cust_name,region,order_number,sold_to_org_id,ordered_item,inventory_item_id,ship_from_org_id,to_char(ord_ff_dt,'yyyyWW')"
            sql &= " )a
)group by customer_NAme,region"
        ElseIf Rad_sale_revenue_model.Checked = True Then
            sql = "select bill_to_cust_name,region,sum(case when project_customer='Project' then  sale_qty else 0 end)  proj_sale_qty
,sum(case when project_customer='Project' then  sal_Value_before_Tax else 0 end ) proj_sale_value

,sum(case when brand_mfg='BRAND-MFG' then  sale_qty else 0 end ) brand_sale_qty
,sum(case when brand_mfg='BRAND-MFG' then  sal_Value_before_Tax else 0 end ) brand_sale_value

,sum(case when project_customer is null and brand_mfg is null and  New_Product='Y' then  sale_qty else 0 end ) new_prod_sale_qty
,sum(case when project_customer is null and brand_mfg is null and New_Product='Y' then  sal_Value_before_Tax else 0 end ) new_prod_sale_value

,sum(case when project_customer is null and brand_mfg is null and  New_Product='N' then  sale_qty else 0 end  )regular_sale_qty
,sum(case when project_customer is null and brand_mfg is null and New_Product='N' then  sal_Value_before_Tax else 0 end  )regular_sale_value
 from (
select a.*,jan_itemdesc(ordered_item)description
,(select customer_class_code from ra_customers where customer_id=a.customer_id)customer_category "

            'sql &= " ,(select decode(count(*) ,0,null, 'Project')  from ra_customers where customer_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') and  customer_id=a.customer_id)project_customer "
            sql &= " ,case when  organization_id=664 then 'Project' 
when ( select count(*) from jan_rev_model_project_items where inventory_item_id=a.inventory_item_id )>0 then 'Project'
when (select count(*)   from ra_customers
where customer_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') 
and  customer_id=a.customer_id)>0 then 'Project' else null end   project_customer "

            sql &= " ,(select decode(count(*) ,0,null,  'BRAND-MFG') from ra_customers
where customer_NAme in ('GROZ ENGINEERING TOOLS PVT.LTD','MARSH BELLOFRAM','MARSH BELLOFRAM EUROPE LTD','PREVOST SAS') and  customer_id=a.customer_id)brand_mfg "

            sql &= " ,case  when ( select count(*) from jan_rev_model_project_items where inventory_item_id=a.inventory_item_id )>0 then 'N' 
when organization_id=664 then 'N' when ordered_item like 'A91SL%' or ordered_item like 'A40%' or ordered_item like 'DR%' or ordered_item like 'GU%' or  ordered_item like 'PT%'
or ordered_item like 'A02%G%' or ordered_item like 'A03%G%' or ordered_item like 'DS4%' or ordered_item like 'M01163' or ordered_item like 'M01161' 
or ordered_item like 'A50%' or ordered_item like 'AG02%G%'  or ordered_item like  'F14623-N1' or ordered_item like  'F15633-G1' or ordered_item like  'F17643-G1' or ordered_item like  'F17653-G1' then 'Y' else 'N' end New_Product
from (
select bill_to_cust_NAme,region,trx_number inv_no,bill_to_customer_id customer_id,ordered_item,trx_date,sum(quantity_invoiced)sale_qty,inventory_item_id,organization_id,
sum(quantity_invoiced*unit_selling_price)sal_Value_before_Tax from jan_sales_any_1_copy where trunc(trx_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(trx_date)<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' "
            ' trx_date >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and trx_date<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' 
            '--and customer_id in (1482580,1826584,3288590,4124604,2410,2941590,2981590,2959590,1093)
            sql &= " group by bill_to_cust_NAme,region,trx_number ,bill_to_customer_id ,ordered_item,trx_date,inventory_item_id,organization_id)a )group by bill_to_cust_name,region"

        ElseIf Rad_payment_receipt_rev_model.Checked = True Then
            sql = "select customer_name,region,sum(Payment_received)total_Payment_received,
sum(case when nvl(project_customer,'-')<>'Y' and nvl(brand_mfg,'-')<>'Y' then Payment_received else 0 end )regular_customer_Payment,
sum(case when project_customer='Y' then Payment_received else 0 end )project_customer_Payment
,sum(case when brand_mfg='Y' then Payment_received else 0 end )brand_mfg_Payment from (
select k.*
,(select customer_class_code from ra_customers where customer_id=k.customer_id)customer_category
,(select decode(count(*) ,0,null, 'Y')  from ra_customers
where customer_NAme in ('AIR FLOW EQUIPMENTS INDIA PRIVATE LIMITED','MITECH BUS DOOR SYSTEMS PVT.LTD','DIGITECH CONTROLS & SYSTEMS','SIEMENS LIMITED') 
and  customer_id=k.customer_id)project_customer
,(select decode(count(*) ,0,null,  'Y') from ra_customers
where customer_NAme in ('GROZ ENGINEERING TOOLS PVT.LTD','MARSH BELLOFRAM','MARSH BELLOFRAM EUROPE LTD','PREVOST SAS') and  customer_id=k.customer_id)brand_mfg from (
SELECT (select customer_name from ra_customers where customer_id=a.pay_from_customer)customer_name,pay_from_customer customer_id
,trunc(a.creation_date)payment_date ,b.region region ,sum(a.amount*nvl(Exchange_rate,1))Payment_received FROM  ar_cash_receipts_all a,(SELECT  sit.site_use_id,ter.segment14 region  
FROM ra_site_uses_all sit,ra_territories ter WHERE  ter.territory_id = sit.territory_id)b where a.customer_site_use_id=b.site_use_id
and trunc(a.creation_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(a.creation_date)<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "'   and a.org_id<>204    and b.region<>'NOT LISTED'  group by   trunc(a.creation_date) ,b.region,a.pay_from_customer)k)
group by customer_name,region  order by customer_name,region"

        ElseIf Rad_prodn_rev_model.Checked = True Then
            sql = "select jan_orgcode(organization_id)org,ordered_item item_no,sum(production_qty)production_qty,sum(production_value)total_production_value "
            sql &= " ,sum(case when PROJECT_ORD='Project'  then production_value else 0 end )PROJECT_product_prodn "
            sql &= " ,sum(case when  PROJECT_ORD<>'Project' AND  New_Product<>'Y'  and brand_mfg<>'Y' then production_value else 0 end )reqular_product_prodn
,sum(case when  PROJECT_ORD<>'Project' AND New_Product='Y' then production_value else 0 end )new_product_prodn
,sum(case when  PROJECT_ORD<>'Project' AND brand_mfg='Y' then production_value else 0 end )brand_mfg_prodn
from (
select b.*  ,case when  organization_id=664 then 'Project' 
when ( select count(*) from jan_rev_model_project_items where inventory_item_id=B.inventory_item_id )>0 then 'Project'  ELSE 'N' END PROJECT_ORD
,case when ordered_item like 'A91SL%' or ordered_item like 'A40%' or ordered_item like 'DR%' or ordered_item like 'GU%' or  ordered_item like 'PT%'
or ordered_item like 'A02%G%' or ordered_item like 'A03%G%' or ordered_item like 'DS4%' or ordered_item like 'M01163' or ordered_item like 'M01161' 
or ordered_item like 'A50%' or ordered_item like 'AG02%G%'  or ordered_item like  'F14623-N1' or ordered_item like  'F15633-G1' 
or ordered_item like  'F17643-G1' or ordered_item like  'F17653-G1' 
then 'Y' else 'N' end New_Product
,(select  decode(count(*),0,'N','Y') from  jan_sales_any_1_copy 
where  organization_id=b.organization_id and inventory_item_id=b.inventory_item_id  
and region = 'EXP-BRAND MFG'
and trx_date>(select add_months(f_dt_cyr,-24) from jan_sales_bi_setup)   )brand_mfg
from (
select organization_id,inventory_item_id,jan_itemname(inventory_item_id)ordered_item,sum(wip_receipt)production_qty,sum(wip_receipt*p_rate)production_value 
from jan_rg1_receipt_issue  where trunc(transaction_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and  trunc(transaction_date)<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "'  and wip_receipt>0  group by organization_id,inventory_item_id)b)a 
group  by organization_id,ordered_item ORDER BY ORG,ordered_item"
        ElseIf rad_order_pending_ans_sale.Checked = True Then
            sql = "select jan_itemname(inventory_item_id)item_no,jan_itemdesc(jan_itemname(inventory_item_id))description,a.* ,
--(select price_in_clp02 from jan_dealer_price_15jun2021 where list_header_id in (21272995,16667914,21273995))price_in_c_cs_clp02_new_prod
(select price_in_clp02 from jan_dealer_price_15jun2021 where list_header_id in (21272995,16667914,21273995) and inventory_item_id=a.inventory_item_id)price_in_c_cs_clp02_new_prod
,(select round(price_in_clp02*1.0471) from jan_dealer_price_15jun2021 where list_header_id in (21272995,16667914,21273995) and inventory_item_id=a.inventory_item_id)dlp
,(select price_in_clp02 from jan_dealer_price_15jun2021 where 
 LIST_HEADER_ID in (10241918,16432901,16571925, 8913814,10241942)
and inventory_item_id=a.inventory_item_id  and 
case when a.bill_to_customer_id  in (4032602 ,1466) then 10241918
when a.bill_to_customer_id =647578 then 16432901
when a.bill_to_customer_id =2649588 then 16571925
when a.bill_to_customer_id =1437 then 8913814
when a.bill_to_customer_id =1687 then 10241942 end =LIST_HEADER_ID)price_in_dealer_list
from (
select inventory_item_id,bill_to_cust_name,bill_to_customer_id,sum(sale_qty_from_apr2019)sale_qty_from_apr2019,sum(sale_val_from_apr2019)sale_val_from_apr2019
,sum(order_pend_qty) order_pend_qty,sum(order_pend_val) order_pend_val from (
select inventory_item_id,bill_to_cust_name,bill_to_customer_id,sum(quantity_invoiced)sale_qty_from_apr2019,sum(quantity_invoiced*unit_selling_price)sale_val_from_apr2019
,0 order_pend_qty,0 order_pend_val
from jan_sales_any_1_copy where trx_date>'1-apr-2019' and bill_to_customer_id in (4032602,1466,2649588,647578,1687,1437)
--and inventory_item_id=3715049
group by inventory_item_id,bill_to_cust_name,bill_to_customer_id
union all
select inventory_item_id,customer_name,customer_id,0 sale_qty_from_apr2019,0 sale_val_from_apr2019,sum(ordered_quantity-nvl(shipped_quantity,0)) order_pend_qty
,sum((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price)order_pend_val
from jan_sales_any_tb2_1 where   (ordered_quantity-nvl(shipped_quantity,0))>0 and customer_id in (4032602,1466,2649588,647578,1687,1437) 
--and inventory_item_id=3715049
group by inventory_item_id,customer_name,customer_id) 
group by inventory_item_id,bill_to_cust_name,bill_to_customer_id)a"

        End If

        'trx_date >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and trx_date<'" & Format(DateAdd("d", 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "' 

        ds = SQL_SELECT("CUST", sql)
        dgv1.DataSource = ds.Tables("CUST")

    End Sub
    Private Sub Rad_order_receipt_rev_model_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_order_receipt_rev_model.CheckedChanged
        If Rad_order_receipt_rev_model.Checked = False Then
            GroupBox1.Visible = False
        Else
            GroupBox1.Visible = True
        End If
    End Sub
    Private Sub Form2_addition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
    End Sub
End Class