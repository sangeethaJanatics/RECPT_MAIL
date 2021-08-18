Public Class Region_target_vs_actuals
    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim s As String
    Private Sub Region_target_vs_actuals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "select distinct segment14 region from ra_territories where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA') order by region"
        ds = SQL_SELECT("REGION", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.DisplayMember = "region"



    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = "select org ""Org"",region ""Region"",product_group_name ""Product Group"" ,apr2017_target ""Apr Taregt"" ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='042017'),0)""Apr Sch Order"" ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='042017'),0)""Apr Sale""  ,may2017_target ""May Taregt"" ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='052017'),0)""May Sch Order""  ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='052017'),0)""May Sale""  ,jun2017_target ""Jun Taregt"" ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='062017'),0)""Jun Sch Order""  ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='062017'),0)""Jun Sale""  ,jul2017_target ""Jul Taregt"" ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='072017'),0)""Jul Sch Order""   ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='072017'),0)""Jul Sale""  ,aug2017_target ""Aug Taregt"" ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='082017'),0)""Aug Sch Order""  ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='082017'),0)""Aug Sale""  ,sep2017_target ""Sep Taregt""  ,nvl(( select sum(ordered_quantity) from JAN_REGION_ORD_PEND_201415_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and sdtmy='092017'),0)""Sep Sch Order""  ,nvl(( select sum(quantity_invoiced) from jan_region_sale_2014_15_tab where   ORGANIZATION_ID=a.ORGANIZATION_ID and  REGION=a.REGION and  PRODUCT_GROUP=a.PRODUCT_GROUP_NAME and my='092017'),0)""Sep Sale"" ,nvl((SELECT GROUP_ORD  FROM jan_dealer_target_prod_group  WHERE GROUP_NAME=a.product_group_name AND ROWNUM=1  ),1000)ORDER_BY from (SELECT org,organization_id,region,product_group_name,SUM(apr_target_qty)apr2017_target,SUM(may_target_qty)may2017_target,SUM(jun_target_qty)jun2017_target,SUM(jul_target_qty)jul2017_target,SUM(aug_target_qty)aug2017_target,SUM(sep_target_qty)sep2017_target FROM JAN_REGION_TARGET_2014_15_tab WHERE region='" & cmb_region.Text & "' GROUP BY org, organization_id, region, product_group_name)a order by org,ORDER_BY"

        ds = SQL_SELECT("data", sql)
        With dgv1
            .DataSource = ds.Tables("data")
            For i = 3 To .ColumnCount - 2
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Next
            .Columns("ORDER_BY").Visible = False
        End With


    End Sub
End Class