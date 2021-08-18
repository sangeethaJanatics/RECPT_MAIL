Public Class Sale_Cyr_Lyr
    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click
        If rad_org_sale.Checked = True Then


            sql = "select jan_orgcode(ORGANIZATION_ID)org,a.*  from (
select  DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)organization_id
, sum(case when  my='042018' then quantity_invoiced*unit_selling_price else 0  end )sales_apr2018
, sum(case when my='042019' then quantity_invoiced*unit_selling_price else 0  end )sales_apr2019

, sum(case when my='052018' then quantity_invoiced*unit_selling_price else 0  end )sales_may2018
, sum(case when my='052019' then quantity_invoiced*unit_selling_price else 0  end )sales_may2019

, sum(case when my='062018' then quantity_invoiced*unit_selling_price else 0  end )sales_JUN2018
, sum(case when my='062019' then quantity_invoiced*unit_selling_price else 0  end )sales_JUN2019

, sum(case when my='072018' then quantity_invoiced*unit_selling_price else 0  end )sales_JUL2018
, sum(case when my='072019' then quantity_invoiced*unit_selling_price else 0  end )sales_JUL2019

, sum(case when my='082018' then quantity_invoiced*unit_selling_price else 0  end )sales_aug2018
, sum(case when my='082019' then quantity_invoiced*unit_selling_price else 0  end )sales_aug2019

, sum(case when my='092018' then quantity_invoiced*unit_selling_price else 0  end )sales_sep2018
, sum(case when my='092019' then quantity_invoiced*unit_selling_price else 0  end )sales_sep2019

, sum(case when my='102018' then quantity_invoiced*unit_selling_price else 0  end )sales_oct2018
, sum(case when my='102019' then quantity_invoiced*unit_selling_price else 0  end )sales_oct2019

, sum(case when my='112018' then quantity_invoiced*unit_selling_price else 0  end )sales_nov2018
, sum(case when my='112019' then quantity_invoiced*unit_selling_price else 0  end )sales_nov2019

, sum(case when my='122018' then quantity_invoiced*unit_selling_price else 0  end )sales_dec2018
, sum(case when my='122019' then quantity_invoiced*unit_selling_price else 0  end )sales_dec2019

, sum(case when my='012019' then quantity_invoiced*unit_selling_price else 0  end )sales_Jan2019
, sum(case when my='012020' then quantity_invoiced*unit_selling_price else 0  end )sales_Jan2020

, sum(case when my='022019' then quantity_invoiced*unit_selling_price else 0  end )sales_feb2019
, sum(case when my='022020' then quantity_invoiced*unit_selling_price else 0  end )sales_feb2020

, sum(case when my='032019' then quantity_invoiced*unit_selling_price else 0  end )sales_mar2019
, sum(case when my='032020' then quantity_invoiced*unit_selling_price else 0  end )sales_mar2020

from jan_sales_any_1_copy where trx_date>='1-apr-2018'  and trx_date<'1-apr-2020'  
group by  DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID))a "
        Else
            sql = "select b.*  , case when LEVEL_5='Product' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') when LEVEL_5='Tube'  and level_2='WHC' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP from (  "

            sql &= " select jan_orgcode(ORGANIZATION_ID)org,a.* 
 ,(select LEVEL_2 from jan_item_category where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id)LEVEL_2
 ,(select LEVEL_5 from jan_item_category where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id)LEVEL_5,JAN_SALES_RRS_CATEGORY(a.ORGANIZATION_ID,a.INVENTORY_ITEM_ID)rrs
 from (
select  DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)organization_id,ordered_item,inventory_item_id
, sum(case when my='042018' then quantity_invoiced*unit_selling_price else 0  end )sales_val_apr2018
, sum(case when my='042018' then quantity_invoiced else 0  end )sales_qty_apr2018
, sum(case when my='042019' then quantity_invoiced*unit_selling_price else 0  end )sales_val_apr2019
, sum(case when my='042019' then quantity_invoiced else 0  end )sales_qty_apr2019

, sum(case when my='052018' then quantity_invoiced*unit_selling_price else 0  end )sales_val_may2018
, sum(case when my='052018' then quantity_invoiced else 0  end )sales_qty_may2018
, sum(case when my='052019' then quantity_invoiced*unit_selling_price else 0  end )sales_val_may2019
, sum(case when my='052019'  then quantity_invoiced else 0  end )sales_qty_may2019


, sum(case when my='062018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_JUN2018
, sum(case when my='062018'  then quantity_invoiced else 0  end )sales_qty_JUN2018
, sum(case when my='062019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valJUN2019
, sum(case when my='062019'  then quantity_invoiced else 0  end )sales_qty_JUN2019

, sum(case when my='072018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_JUL2018
, sum(case when my='072018'  then quantity_invoiced else 0  end )sales_qty_JUL2018
, sum(case when my='072019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valJUL2019
, sum(case when my='072019'  then quantity_invoiced else 0  end )sales_qty_JUL2019

, sum(case when my='082018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_aug2018
, sum(case when my='082018'  then quantity_invoiced else 0  end )sales_qty_aug2018
, sum(case when my='082019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valaug2019
, sum(case when my='082019'  then quantity_invoiced else 0  end )sales_qty_aug2019

, sum(case when my='092018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_sep2018
, sum(case when my='092018'  then quantity_invoiced else 0  end )sales_qty_sep2018
, sum(case when my='092019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valsep2019
, sum(case when my='092019'  then quantity_invoiced else 0  end )sales_qty_sep2019

, sum(case when my='102018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_oct2018
, sum(case when my='102018'  then quantity_invoiced else 0  end )sales_qty_oct2018
, sum(case when my='102019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valoct2019
, sum(case when my='102019'  then quantity_invoiced else 0  end )sales_qty_oct2019

, sum(case when my='112018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_nov2018
, sum(case when my='112018'  then quantity_invoiced else 0  end )sales_qty_nov2018
, sum(case when my='112019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valnov2019
, sum(case when my='112019'  then quantity_invoiced else 0  end )sales_qty_nov2019

, sum(case when my='122018'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_dec2018
, sum(case when my='122018'  then quantity_invoiced else 0  end )sales_qty_dec2018
, sum(case when my='122019'  then quantity_invoiced*unit_selling_price else 0  end )sales_valdec2019
, sum(case when my='122019'  then quantity_invoiced else 0  end )sales_qty_dec2019

, sum(case when my='012019'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_Jan2019
, sum(case when my='012019'  then quantity_invoiced else 0  end )sales_qty_Jan2019
, sum(case when my='012020'  then quantity_invoiced*unit_selling_price else 0  end )sales_valJan2020
, sum(case when my='012020'  then quantity_invoiced else 0  end )sales_qty_Jan2020

, sum(case when my='022019'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_feb2019
, sum(case when my='022019'  then quantity_invoiced else 0  end )sales_qty_feb2019
, sum(case when my='022020'  then quantity_invoiced*unit_selling_price else 0  end )sales_valfeb2020
, sum(case when my='022020'  then quantity_invoiced else 0  end )sales_qty_feb2020

, sum(case when my='032019'  then quantity_invoiced*unit_selling_price else 0  end )sales_val_mar2019
, sum(case when my='032019'  then quantity_invoiced else 0  end )sales_qty_mar2019
, sum(case when my='032020'  then quantity_invoiced*unit_selling_price else 0  end )sales_valmar2020
, sum(case when my='032020'  then quantity_invoiced else 0  end )sales_qty_mar2020

from jan_sales_any_1_copy where trx_date>='1-apr-2018'  and trx_date<'1-apr-2020' 
group by  DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID),ordered_item,inventory_item_id)a)b "

        End If

        ds = SQL_SELECT("res", sql)
        dgv1.DataSource = ds.Tables("res")

    End Sub
End Class