Public Class ds_m2o

    Private Sub ds_m2o_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = " select SUM(case when ORGANIZATION_ID=524  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I21_PROD_items,"
        sql &= " SUM(case when ORGANIZATION_ID=524  and PROD_CAT='Product' then PENDING_QTY else 0 end )I21_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=464  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I22_PROD_items,"
        sql &= " SUM(case when ORGANIZATION_ID=464   and PROD_CAT='Product'  then PENDING_QTY else 0 end )I22_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=444  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I23_PROD_items,"
        sql &= " SUM(case when ORGANIZATION_ID=444   and PROD_CAT='Product'  then PENDING_QTY else 0 end )I23_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=504  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I24_PROD_items,"
        sql &= " SUM(case when ORGANIZATION_ID=504  and PROD_CAT='Product'  then PENDING_QTY else 0 end )I24_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=484  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I25_PROD_items,"
        sql &= " SUM(case when ORGANIZATION_ID=484  and PROD_CAT='Product'  then PENDING_QTY else 0 end )I25_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=505  and PROD_CAT='Product'  and PENDING_QTY>0 then 1 else 0 end )I26_PROD_items,"
        sql &= " sum(case when organization_id=505  and prod_cat='Product'  then PENDING_QTY else 0 end )I26_Prod_qty,"
        sql &= " WEEK_NO, "

        sql &= " SUM(case when ORGANIZATION_ID=524  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I21_NON_PROD_ITEMS,"
        sql &= " SUM(case when ORGANIZATION_ID=524  and PROD_CAT<>'Product' then PENDING_QTY else 0 end )I21_NON_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=464  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I22_NON_PROD_ITEMS,"
        sql &= " SUM(case when ORGANIZATION_ID=464   and PROD_CAT<>'Product'  then PENDING_QTY else 0 end )I22_NON_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=444  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I23_NON_PROD_ITEMS,"
        sql &= " SUM(case when ORGANIZATION_ID=444   and PROD_CAT<>'Product'  then PENDING_QTY else 0 end )I23_NON_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=504  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I24_NON_PROD_ITEMS,"
        sql &= " SUM(case when ORGANIZATION_ID=504  and PROD_CAT<>'Product'  then PENDING_QTY else 0 end )I24_NON_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=484  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I25_NON_PROD_ITEMS,"
        sql &= " SUM(case when ORGANIZATION_ID=484  and PROD_CAT<>'Product'  then PENDING_QTY else 0 end )I25_NON_PROD_QTY,"
        sql &= " SUM(case when ORGANIZATION_ID=505  and PROD_CAT<>'Product'  and PENDING_QTY>0 then 1 else 0 end )I26_NON_PROD_ITEMS,"
        sql &= " sum(case when organization_id=505  and prod_cat<>'Product'  then PENDING_QTY else 0 end )I26_non_Prod_qty"
        sql &= " from jan_demand_Set_tmp_v where INVENTORY_ITEM_ID=37754 and PENDING_QTY>0 group by WEEK_NO"
        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")
    End Sub
End Class