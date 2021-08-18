Imports System.Data.OracleClient
Public Class Plan

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        ds = New DataSet

        For i = 104 To 110


            sql = " SELECT JAN_ORGCODE(ORG_ID)ORG,ITEM_NO,APR_JUL_PLAN,APR_JUL_ORDER,"
            sql &= "DECODE(SIGN(AUG_ORDER_REGr_1),1,AUG_ORDER_REGr_1,0)AUG_ORD_REGR_QTY_JAN_JUN,"
            sql &= "DECODE(SIGN(AUG_ORDER_REGr_2),1,AUG_ORDER_REGr_2,0)AUG_ORD_REGR_QTY_JAN_JUL,"
            sql &= "DECODE(SIGN(AUG_sale_REGr_1),1,AUG_sale_REGr_1,0)AUG_SAL_REGR_QTY_JAN_JUN,"
            sql &= "DECODE(SIGN(AUG_sale_REGr_2),1,AUG_sale_REGr_2,0)AUG_SAL_REGR_QTY_JAN_JUl, "
            sql &= "DECODE(SIGN(sep_ORDER_REGr_1),1,sep_ORDER_REGr_1,0)sep_ORD_REGR_QTY_JAN_JUN,"
            sql &= "DECODE(SIGN(sep_ORDER_REGr_2),1,sep_ORDER_REGr_2,0)sep_ORD_REGR_QTY_JAN_JUL,"
            sql &= "DECODE(SIGN(sep_sale_REGr_1),1,sep_sale_REGr_1,0)sep_SAL_REGR_QTY_JAN_JUN,"
            sql &= "DECODE(SIGN(sep_sale_REGr_2),1,sep_sale_REGr_2,0)sep_SAL_REGR_QTY_JAN_JUl"
            sql &= ",AUG_PLAN,SEP_PLAN  FROM ( "
            sql &= "select a.* ,NVL((select sum(final_qty)  from jan_org_ds_all where mnyear in ('042012','052012','062012','072012') and org_id=a.org_id and item_id=a.item_id),0) apr_jul_plan, "
            sql &= "NVL((select sum(ordered_quantity) from jan_sales_any_tb2_1 where ordered_date>='1-apr-2012' and inventory_item_id= a.item_id and organization_id=a.org_id and sdtmy in ('042012','052012','062012','072012')),0)APR_JUL_order "
            sql &= ",nvl((select ROUND(TO_NUMBER(SUBSTR(ORDER_JAN_JUN,INSTR(ORDER_JAN_JUN,',')+1)) +(8*     TO_NUMBER(SUBSTR(ORDER_JAN_JUN,1,INSTR(ORDER_JAN_JUN,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  AUG_ORDER_REGr_1"
            sql &= ",nvl((select ROUND(TO_NUMBER(SUBSTR(ORDER_JAN_JUl,INSTR(ORDER_JAN_JUl,',')+1)) +(8*     TO_NUMBER(SUBSTR(ORDER_JAN_JUL,1,INSTR(ORDER_JAN_JUL,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  AUG_ORDER_REGr_2, "

            sql &= "nvl((select ROUND(TO_NUMBER(SUBSTR(SALE_JAN_TO_JUN,INSTR(SALE_JAN_TO_JUN,',')+1)) +(8*     TO_NUMBER(SUBSTR(SALE_JAN_TO_JUN,1,INSTR(SALE_JAN_TO_JUN,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  AUG_SALE_REGR_1  , "

            sql &= "nvl((select ROUND(TO_NUMBER(SUBSTR(SALE_JAN_TO_JUL,INSTR(SALE_JAN_TO_JUL,',')+1)) +(8*     TO_NUMBER(SUBSTR(SALE_JAN_TO_JUL,1,INSTR(SALE_JAN_TO_JUL,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  AUG_SALE_REGR_2"
            sql &= ",nvl((select ROUND(TO_NUMBER(SUBSTR(ORDER_JAN_JUN,INSTR(ORDER_JAN_JUN,',')+1)) +(9*     TO_NUMBER(SUBSTR(ORDER_JAN_JUN,1,INSTR(ORDER_JAN_JUN,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  SEP_ORDER_REGr_1"

            sql &= ",nvl((select ROUND(TO_NUMBER(SUBSTR(ORDER_JAN_JUl,INSTR(ORDER_JAN_JUl,',')+1)) +(9*     TO_NUMBER(SUBSTR(ORDER_JAN_JUL,1,INSTR(ORDER_JAN_JUL,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  SEP_ORDER_REGr_2, "

            sql &= "nvl((select ROUND(TO_NUMBER(SUBSTR(SALE_JAN_TO_JUN,INSTR(SALE_JAN_TO_JUN,',')+1)) +(9*     TO_NUMBER(SUBSTR(SALE_JAN_TO_JUN,1,INSTR(SALE_JAN_TO_JUN,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  SEP_SALE_REGR_1  , "

            sql &= "nvl((select ROUND(TO_NUMBER(SUBSTR(SALE_JAN_TO_JUL,INSTR(SALE_JAN_TO_JUL,',')+1)) +(9*     TO_NUMBER(SUBSTR(SALE_JAN_TO_JUL,1,INSTR(SALE_JAN_TO_JUL,',')-1)))) from JAN_OTHER_ACCESS_SLOPE_INTER where item_id=     a.item_id and orgANIZATION_id=a.org_id ),0)  SEP_SALE_REGR_2  , "

            sql &= "NVL((select sum(final_qty)  from jan_org_ds_all where mnyear in ('082012') and org_id=a.org_id and item_id=a.item_id),0)+NVL((select sum(aug_suppl_final_qty)  from jan_ACCESSORIES_aug_SUPPL where org_id=a.org_id and item_id=a.item_id),0) AUG_PLAN "

            sql &= ",NVL((select sum(final_qty)  from jan_org_ds_all where mnyear in ('092012') and org_id=a.org_id and item_id=a.item_id),0) sep_PLAN  "

            sql &= ",NVL((select sum(AA.primary_quantity)receipt_qty from  MTL_MATERIAL_TRANSACTIONS AA,            MTL_SECONDARY_INVENTORIES BB  WHERE AA.PRIMARY_QUANTITY > 0  AND AA.TRANSACTION_DATE>'02-APR-2012'  AND AA.TRANSACTION_TYPE_ID IN (3,4,18,44,38)  AND AA.SUBINVENTORY_CODE=BB.SECONDARY_INVENTORY_NAME  AND AA.ORGANIZATION_ID=BB.ORGANIZATION_ID   AND AA.SUBINVENTORY_CODE IN ('FG Store','BDA_Store','Service 1','Spares') AND BB.AVAILABILITY_TYPE=1  and AA.inventory_item_id=a.ITEM_ID and AA.organization_id=a.ORG_ID),0)prod_completed "
            sql &= " from ( select distinct item_id,org_id,item_no from jan_org_ds_all    where  org_id=" & i & " /*item_id=37754  item_no ='DS255SR61-A' */)a)"

            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds, "res")

        Next
        mail_content("Plan List")
        System.Diagnostics.Process.Start("Plan List.html")

    End Sub
End Class