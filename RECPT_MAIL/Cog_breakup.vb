Public Class Cog_breakup
    Dim m_plus_l As String = ""

    Private Sub Cog_breakup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = " select distinct product_group from JAN_COG_BREAKUP_TAB"
        ds = SQL_SELECT("data", sql)
        cmb_product_group.DataSource = ds.Tables("data")
        cmb_product_group.DisplayMember = "product_group"

        sql = " select distinct fin_year from JAN_COG_BREAKUP_TAB"
        ds = SQL_SELECT("data", sql)
        cmb_fin_year.DataSource = ds.Tables("data")
        cmb_fin_year.DisplayMember = "fin_year"

        sql = " select distinct segment14 from ra_territories  where segment14 not in ('GOA','H.O','M.P.','NOT LISTED','PROJECTS 1')"
        ds = SQL_SELECT("data", sql)
        cmb_region.DataSource = ds.Tables("data")
        cmb_region.DisplayMember = "segment14"

        cmb_class_code.Items.Add("CUSTOMER")
        cmb_class_code.Items.Add("DEALER")

        cmb_make_buy.Items.Add("Make")
        cmb_make_buy.Items.Add("Buy")

        'Make','Buy'


    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        dgv1.Columns.Clear()
        'If rad_mplul_mar2016.Checked = True Then

        'ElseIf rad_mplusl_31mar2018.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2018"
        'ElseIf rad_mplusl_ason31mar2019.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2019"
        'ElseIf rad_mplusl_mar2020.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2020"
        'ElseIf RAD_CURRENT_MPLUSL.Checked = True Then
        '    m_plus_l = "curRENT_mplusl"
        'End If

        If ddl_MplusL.Text = "MplusL based on 31mar2016" Then
            m_plus_l = "M_PLUS_L_ASON31MAR"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2018" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2018"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2019" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2019"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2020" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2020"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2021" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2021"
        Else
            m_plus_l = "curRENT_mplusl"
        End If



        sql = "select CUSTOMER_NAME ""Customer Name "",case when SUM(APR_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(APR_SALE_VAL)/ SUM(APR_SALE_QTY*" & m_plus_l & "),2)end ""Apr Cog"",case when SUM(MAY_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(MAY_SALE_VAL)/ SUM(MAY_SALE_QTY*" & m_plus_l & "),2)end ""May Cog"",case when SUM(JUN_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUN_SALE_VAL)/ SUM(JUN_SALE_QTY*" & m_plus_l & "),2)end ""Jun Cog"""

        sql &= " ,case when SUM(JUl_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUl_SALE_VAL)/ SUM(JUl_SALE_QTY*" & m_plus_l & "),2)end ""Jul Cog"""
        sql &= " ,case when SUM(aug_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(aug_SALE_VAL)/ SUM(aug_SALE_QTY*" & m_plus_l & "),2)end ""Aug Cog"""
        sql &= " ,case when SUM(sep_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(sep_SALE_VAL)/ SUM(sep_SALE_QTY*" & m_plus_l & "),2)end ""Sep Cog"""
        sql &= " ,case when SUM(oct_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(oct_SALE_VAL)/ SUM(oct_SALE_QTY*" & m_plus_l & "),2)end ""Oct Cog"""

        sql &= " ,case when SUM(nov_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(nov_SALE_VAL)/ SUM(nov_SALE_QTY*" & m_plus_l & "),2)end ""Nov Cog"""

        sql &= " ,case when SUM(dec_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(dec_SALE_VAL)/ SUM(dec_SALE_QTY*" & m_plus_l & "),2)end ""Dec Cog"""

        sql &= " ,case when SUM(jan_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(jan_SALE_VAL)/ SUM(jan_SALE_QTY*" & m_plus_l & "),2)end ""Jan Cog"""
        sql &= " ,case when SUM(feb_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(feb_SALE_VAL)/ SUM(feb_SALE_QTY*" & m_plus_l & "),2)end ""Feb Cog"""
        sql &= " ,case when SUM(mar_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(mar_SALE_VAL)/ SUM(mar_SALE_QTY*" & m_plus_l & "),2)end ""Mar Cog"""

        sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Overall Cog"",(select AVG_PAID_DAYS from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Avg Payment Days"",(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V where CUSTOMER_ID=A.CUSTOMER_ID and SITE_USE_ID is null)""Payment Term"" from JAN_COG_BREAKUP_TAB  a where 1=1   and fin_year='" & cmb_fin_year.Text & "'"

        If cmb_product_group.Text <> "" Then sql &= " and product_group='" & cmb_product_group.Text & "'"
        If cmb_class_code.Text <> "" Then sql &= " and class_code='" & cmb_class_code.Text & "'"
        If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "'"
        If cmb_make_buy.Text <> "" Then

            If cmb_make_buy.Text = "Make" Then
                sql &= " and inventory_item_id  not in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            Else
                sql &= " and inventory_item_id   in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            End If


        End If


        sql &= " group by CUSTOMER_ID ,CUSTOMER_NAME order by 1 "
        ds = SQL_SELECT("data", sql)


        With dgv1
            .DataSource = ds.Tables("data")
            .Columns(0).Width = 240
            For i = 1 To .ColumnCount - 3
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Columns(i).DefaultCellStyle.Format = "0.00"
                .Columns(i).Width = 50
            Next
        End With
    End Sub

    Private Sub btn_item_brk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_item_brk.Click
        dgv1.Columns.Clear()

        'If rad_mplul_mar2016.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR"
        'ElseIf rad_mplusl_31mar2018.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2018"
        'ElseIf rad_mplusl_ason31mar2019.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2019"
        'ElseIf rad_mplusl_mar2020.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2020"
        'ElseIf RAD_CURRENT_MPLUSL.Checked = True Then
        '    m_plus_l = "curRENT_mplusl"
        'End If
        If ddl_MplusL.Text = "MplusL based on 31mar2016" Then
            m_plus_l = "M_PLUS_L_ASON31MAR"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2018" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2018"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2019" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2019"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2020" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2020"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2021" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2021"
        Else
            m_plus_l = "curRENT_mplusl"
        End If

        sql = "select jan_itemname(inventory_item_id) ""Item No"",case when SUM(APR_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(APR_SALE_VAL)/ SUM(APR_SALE_QTY*" & m_plus_l & "),2)end ""Apr Cog"",case when SUM(MAY_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(MAY_SALE_VAL)/ SUM(MAY_SALE_QTY*" & m_plus_l & "),2)end ""May Cog"",case when SUM(JUN_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUN_SALE_VAL)/ SUM(JUN_SALE_QTY*" & m_plus_l & "),2)end ""Jun Cog"""

        sql &= " ,case when SUM(JUl_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUl_SALE_VAL)/ SUM(JUl_SALE_QTY*" & m_plus_l & "),2)end ""Jul Cog"""
        sql &= " ,case when SUM(aug_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(aug_SALE_VAL)/ SUM(aug_SALE_QTY*" & m_plus_l & "),2)end ""Aug Cog"""
        sql &= " ,case when SUM(sep_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(sep_SALE_VAL)/ SUM(sep_SALE_QTY*" & m_plus_l & "),2)end ""Sep Cog"""
        sql &= " ,case when SUM(oct_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(oct_SALE_VAL)/ SUM(oct_SALE_QTY*" & m_plus_l & "),2)end ""Oct Cog"""

        sql &= " ,case when SUM(nov_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(nov_SALE_VAL)/ SUM(nov_SALE_QTY*" & m_plus_l & "),2)end ""Nov Cog"""

        sql &= " ,case when SUM(dec_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(dec_SALE_VAL)/ SUM(dec_SALE_QTY*" & m_plus_l & "),2)end ""Dec Cog"""

        sql &= " ,case when SUM(jan_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(jan_SALE_VAL)/ SUM(jan_SALE_QTY*" & m_plus_l & "),2)end ""Jan Cog"""
        sql &= " ,case when SUM(feb_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(feb_SALE_VAL)/ SUM(feb_SALE_QTY*" & m_plus_l & "),2)end ""Feb Cog"""
        sql &= " ,case when SUM(mar_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(mar_SALE_VAL)/ SUM(mar_SALE_QTY*" & m_plus_l & "),2)end ""Mar Cog"""

        sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Overall Cog"""
        ',(select AVG_PAID_DAYS from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Avg Payment Days"",(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V where CUSTOMER_ID=A.CUSTOMER_ID and SITE_USE_ID is null)""Payment Term"" 

        sql &= " from JAN_COG_BREAKUP_TAB  a where 1=1  and fin_year='" & cmb_fin_year.Text & "'"

        If cmb_product_group.Text <> "" Then sql &= " and product_group='" & cmb_product_group.Text & "'"
        If cmb_class_code.Text <> "" Then sql &= " and class_code='" & cmb_class_code.Text & "'"
        If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "'"
        If cmb_make_buy.Text <> "" Then

            If cmb_make_buy.Text = "Make" Then
                sql &= " and inventory_item_id  not in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            Else
                sql &= " and inventory_item_id   in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            End If


        End If


        sql &= " group by inventory_item_id order by 1 "
        ds = SQL_SELECT("data", sql)


        With dgv1
            .DataSource = ds.Tables("data")
            .Columns(0).Width = 240
            For i = 1 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Columns(i).DefaultCellStyle.Format = "0.00"
                .Columns(i).Width = 50
            Next
        End With
    End Sub
    Private Sub dgv1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        'If rad_mplul_mar2016.Checked Then m_plus_l = "M_PLUS_L_ASON31MAR" Else m_plus_l = "M_PLUS_L_ASON31MAR2018"
        'If rad_mplul_mar2016.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR"
        'ElseIf rad_mplusl_31mar2018.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2018"

        'ElseIf rad_mplusl_ason31mar2019.Checked = True Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR2019"

        'ElseIf RAD_CURRENT_MPLUSL.Checked = True Then
        '    m_plus_l = "curRENT_mplusl"
        'End If

        If ddl_MplusL.Text = "MplusL based on 31mar2016" Then
            m_plus_l = "M_PLUS_L_ASON31MAR"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2018" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2018"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2019" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2019"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2020" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2020"
        ElseIf ddl_MplusL.Text = "MplusL based on 31mar2021" Then
            m_plus_l = "M_PLUS_L_ASON31MAR2021"
        Else
            m_plus_l = "curRENT_mplusl"
        End If


        dgv_brk.Visible = True
        sql = "select jan_itemname(inventory_item_id) ""Item No"",case when SUM(APR_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(APR_SALE_VAL)/ SUM(APR_SALE_QTY*" & m_plus_l & "),2)end ""Apr Cog"",case when SUM(MAY_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(MAY_SALE_VAL)/ SUM(MAY_SALE_QTY*" & m_plus_l & "),2)end ""May Cog"",case when SUM(JUN_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUN_SALE_VAL)/ SUM(JUN_SALE_QTY*" & m_plus_l & "),2)end ""Jun Cog"""

        sql &= " ,case when SUM(JUl_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(JUl_SALE_VAL)/ SUM(JUl_SALE_QTY*" & m_plus_l & "),2)end ""Jul Cog"""
        sql &= " ,case when SUM(aug_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(aug_SALE_VAL)/ SUM(aug_SALE_QTY*" & m_plus_l & "),2)end ""Aug Cog"""
        sql &= " ,case when SUM(sep_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(sep_SALE_VAL)/ SUM(sep_SALE_QTY*" & m_plus_l & "),2)end ""Sep Cog"""
        sql &= " ,case when SUM(oct_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(oct_SALE_VAL)/ SUM(oct_SALE_QTY*" & m_plus_l & "),2)end ""Oct Cog"""

        sql &= " ,case when SUM(nov_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(nov_SALE_VAL)/ SUM(nov_SALE_QTY*" & m_plus_l & "),2)end ""Nov Cog"""

        sql &= " ,case when SUM(dec_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(dec_SALE_VAL)/ SUM(dec_SALE_QTY*" & m_plus_l & "),2)end ""Dec Cog"""

        sql &= " ,case when SUM(jan_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(jan_SALE_VAL)/ SUM(jan_SALE_QTY*" & m_plus_l & "),2)end ""Jan Cog"""
        sql &= " ,case when SUM(feb_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(feb_SALE_VAL)/ SUM(feb_SALE_QTY*" & m_plus_l & "),2)end ""Feb Cog"""
        sql &= " ,case when SUM(mar_SALE_QTY*" & m_plus_l & ")=0 then 0 else ROUND(SUM(mar_SALE_VAL)/ SUM(mar_SALE_QTY*" & m_plus_l & "),2)end ""Mar Cog"""

        sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Overall Cog"""
        ',(select AVG_PAID_DAYS from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Avg Payment Days"",(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V where CUSTOMER_ID=A.CUSTOMER_ID and SITE_USE_ID is null)""Payment Term"" 

        sql &= " from JAN_COG_BREAKUP_TAB  a where 1=1  and fin_year='" & cmb_fin_year.Text & "'  "

        If cmb_product_group.Text <> "" Then sql &= " and product_group='" & cmb_product_group.Text & "'"
        If cmb_class_code.Text <> "" Then sql &= " and class_code='" & cmb_class_code.Text & "'"
        If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "'"
        If cmb_make_buy.Text <> "" Then

            If cmb_make_buy.Text = "Make" Then
                sql &= " and inventory_item_id  not in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            Else
                sql &= " and inventory_item_id   in (SELECT INVENTORY_ITEM_ID FROM JAN_BUY_AND_SELL_PRODUCTS)"
            End If


        End If
        sql &= " and customer_name='" & dgv1.CurrentRow.Cells(0).Value & "'"

        sql &= " group by inventory_item_id order by 1 "
        ds = SQL_SELECT("data", sql)


        With dgv_brk
            .DataSource = ds.Tables("data")
            .Columns(0).Width = 240
            For i = 1 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Columns(i).DefaultCellStyle.Format = "0.00"
                .Columns(i).Width = 50
            Next
        End With
    End Sub
End Class