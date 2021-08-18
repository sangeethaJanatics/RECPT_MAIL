Public Class US_Sale_with_inr_mplusl

    Private Sub US_Sale_with_inr_mplusl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "select * from jan_bi_ap_tb3  where start_date>'1-apr-2016' order   by start_date"
        sql = "SELECT DISTINCT SEGMENT14 region FROM RA_TERRITORIES WHERE SEGMENT14 like 'EXP%' order  by region"
        ds = SQL_SELECT("data", sql)


        cmb_region.DataSource = ds.Tables("data")
        cmb_region.DisplayMember = "region"


        'btn_go_Click(sender, e)




    End Sub

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        Dim value_for As String = ""
        Dim head_for As String = ""

        If rad_sale_value.Checked = True Then
            value_for = "unit_selling_price"
            head_for = "Sales"
        ElseIf rad_cog.Checked = True Then
            value_for = "cog_cost"
            head_for = "Cog"
        End If
        If rad_us_sale.Checked = True Then

            sql = " select b.* "
            If rad_itemwise.Checked = True Then sql &= " ,nvl((select item_cost from jan_itemcost where org_id =b.sale_org and item_id=b. inventory_item_id),0)inr_mplus_l"
            sql &= " from ("
            sql &= " select "

            If rad_itemwise.Checked = True Then sql &= " jan_orgcode(org_id)org,"
            sql &= " a.* "

            If rad_itemwise.Checked = True Then sql &= " ,nvl((select max(organization_id ) from jan_sales_any_1_copy where trx_date>'1-apr-2017' and inventory_item_id=a.inventory_item_id),464)sale_org"
            sql &= " from ("
            sql &= " select customer_name "

            If rad_itemwise.Checked = True Then sql &= "  ,org_id,inventory_item_id,item_no "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='01" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY jan"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='01" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL jan"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='02" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY feb"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='02" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL feb"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='03" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY mar"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='03" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL mar"""


            If rad_sale_qty.Checked = True Then sql &= ",sum( case when mnyear='04" & cmb_fin_year.Text & "' then qty else 0 end )""Sales qty apr"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='04" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val apr"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='05" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY may"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='05" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL MAY"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='06" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY jun"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='06" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL jun"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='07" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY jul"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='07" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL jul"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='08" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY aug"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='08" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL aug"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='09" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY sep"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='09" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL sep"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='10" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY oct"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='10" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL oct"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='11" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY Nov"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='11" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL Nov"""



            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='12" & cmb_fin_year.Text & "' then qty else 0 end )""Sale QTY Dec"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='12" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " VAL Dec"""

            sql &= " from JAN_US_COG_v  where  trx_date>'31-dec-" & CDbl(cmb_fin_year.Text) - 1 & "' "  'fin_year='" & cmb_fin_year.Text & "' " 'trx_date>='1-apr-2018' " ' --and inventory_item_id=11232144  
                If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "'"
                If cmb_customer.Text <> "" Then sql &= " and customer_name='" & cmb_customer.Text & "'"

                sql &= " group by  customer_name "
                If rad_itemwise.Checked = True Then sql &= " ,org_id,item_no,inventory_item_id "
                sql &= " )a)b  order by customer_name"
                If rad_itemwise.Checked = True Then sql &= ",item_no"


            ElseIf rad_india_sale.Checked = True Then
                sql = "select  a.* "
            If rad_itemwise.Checked = True Then sql &= " ,jan_orgcode(org_id)org,nvl((select item_cost from jan_itemcost where org_id =a.org_id And item_id=a. inventory_item_id),0)mplus_l   "
            sql &= " from ( select "
            If rad_itemwise.Checked = True Then sql &= "  org_id,inventory_item_id,item_no , "

            sql &= " customer_name "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='01" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty jan"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='01" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val jan"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='02" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty feb"" "
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='02" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val feb"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='03" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Mar"" "
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='03" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val mar"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='04" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty apr"" "
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='04" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val apr"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='05" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty May"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='05" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val may"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='06" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Jun"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='06" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Jun"""

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='07" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Jul"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='07" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Jul"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='08" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Aug"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='08" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Aug"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='09" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Sep"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='09" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Sep"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='10" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Oct"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='10" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Oct"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='11" & cmb_fin_year.Text & "' then qty else 0 end )""Sales  Qty Nov"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='11" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Nov"" "

            If rad_sale_qty.Checked = True Then sql &= " ,sum( case when mnyear='12" & cmb_fin_year.Text & "' then qty else 0 end )""Sales Qty Dec"""
            If rad_sale_value.Checked = True Or rad_cog.Checked = True Then sql &= " ,sum( case when mnyear='12" & cmb_fin_year.Text & "' then qty*" & value_for & " else 0 end )""" & head_for & " val Dec"" "




            sql &= "  from jan_sales_any_cog where    trx_date>'31-dec- " & CDbl(cmb_fin_year.Text) - 1 & "'  "

            If cmb_customer.Text <> "" Then sql &= " And customer_name='" & cmb_customer.Text & "'"
            If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "'"

            sql &= " /*And And inventory_item_id =8660 */ group by  customer_name "
            If rad_itemwise.Checked = True Then sql &= " ,org_id,item_no,inventory_item_id "


            sql &= " )a order by customer_name "
            If rad_itemwise.Checked = True Then sql &= " ,item_no"

        End If

        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")

        If rad_itemwise.Checked = True Then
            dgv1.Columns("org_id").Visible = False
            dgv1.Columns("inventory_item_id").Visible = False
            If rad_us_sale.Checked = True Then dgv1.Columns("sale_org").Visible = False
        End If

        If rad_itemwise.Checked = True Then
            For i = 5 To dgv1.Columns.Count - 1
                With dgv1
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End With
            Next
        Else
            For i = 1 To dgv1.Columns.Count - 1
                With dgv1
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End With
            Next
        End If


    End Sub
    Private Sub cmb_region_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_region.SelectedIndexChanged

        sql = "select customer_id,(select customer_name from ra_customers where customer_id=a.customer_id)customer_name from jan_bms_bill_to_v a  where ter_name='" & cmb_region.Text & "' order by customer_name "
        ds = SQL_SELECT("data", sql)
        cmb_customer.DataSource = ds.Tables("data")
        cmb_customer.DisplayMember = "customer_name"
        cmb_customer.ValueMember = "customer_id"


    End Sub
End Class