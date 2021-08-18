Public Class Cog_current_year
    Dim CUST_TYPE As String
    Dim m_plus_l As String = ""
    Private Sub Cog_current_year_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Close()
        cog_login.Close()
    End Sub
    Private Sub Cog_current_year_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "select distinct fin_year from JAN_COG_BREAKUP_TAB order by fin_year"
        ds = SQL_SELECT("data", sql)
        cmb_fin_year.DataSource = ds.Tables("data")
        cmb_fin_year.DisplayMember = "fin_year"
        cmb_fin_year.ValueMember = "fin_year"

        cmb_MplusL.Text = "Current_MplusL"
        display_result()

    End Sub
    Private Sub display_result()

        'If rad_mplul_mar2016.Checked Then
        '    m_plus_l = "M_PLUS_L_ASON31MAR"
        'ElseIf rad_mplusl_31mar2018.Checked = True Then
        '    m_plus_l = "m_plus_l_ason31mar2018"
        'ElseIf rad_cur_mplusl.Checked = True Then
        '    m_plus_l = "curRENT_mplusl"
        'End If

        If cmb_MplusL.Text = "31mar2016" Then
            m_plus_l = "M_PLUS_L_ASON31MAR"

        ElseIf cmb_MplusL.Text = "31mar2018" Then
            m_plus_l = "m_plus_l_ason31mar2018"

        ElseIf cmb_MplusL.Text = "31mar2019" Then
            m_plus_l = "m_plus_l_ason31mar2019"

        ElseIf cmb_MplusL.Text = "31mar2020" Then
            m_plus_l = "m_plus_l_ason31mar2020"

        ElseIf cmb_MplusL.Text = "31mar2021" Then
            m_plus_l = "m_plus_l_ason31mar2021"

        ElseIf cmb_MplusL.Text = "Current_MplusL" Then
            m_plus_l = "curRENT_mplusl"
        End If



        sql = "SELECT MAKE_BUY,ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2)""Current Fin Yr Cog"" FROM (SELECT A.* ,(SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)MAKE_BUY FROM JAN_COG_BREAKUP_TAB A where fin_year='" & cmb_fin_year.Text & "') GROUP BY MAKE_BUY "
        ds = SQL_SELECT("data", sql)

        With dgv_make_buy
            .DataSource = ds.Tables("data")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        sql = "select 'Overall COG' ""COG"",round(sum(total_sale_val)/sum(TOTAL_SALE_QTY*" & m_plus_l & "),2)""Current Fin Yr Cog"" from JAN_COG_BREAKUP_tab where fin_year='" & cmb_fin_year.Text & "'"
        ds = SQL_SELECT("data", sql)

        With dgv_overall
            .DataSource = ds.Tables("data")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        sql = "select class_code ""Class Code"",round(sum(total_sale_val)/sum(TOTAL_SALE_QTY*" & m_plus_l & "),2)""Current Fin Yr Cog"" from JAN_COG_BREAKUP_tab where fin_year='" & cmb_fin_year.Text & "' group by CLASS_CODE"
        ds = SQL_SELECT("data", sql)

        With dgv1
            .DataSource = ds.Tables("data")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        'If dgv1.CurrentRow.Cells(0).Value = "DEALER" Then
        '    CUST_TYPE = "="
        '    Label1.Text = "Breakup For : Dealer"
        'Else
        '    CUST_TYPE = "<>"
        '    Label1.Text = "Breakup For :Customer"
        'End If
        'Label1.Visible = True
        'sql = "select PRODUCT_GROUP ""Product Group"",cog ""Cog"" ,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP where GROUP_NAME=a.PRODUCT_GROUP and rownum=1)GROUP_ORD FROM( select PRODUCT_GROUP , CASE WHEN SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR)=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR),2) ENd cog from JAN_COG_BREAKUP_TAB where CLASS_CODE" & CUST_TYPE & " 'DEALER' group by PRODUCT_GROUP, CLASS_CODE  )A ORDER BY GROUP_ORD"
        'ds = SQL_SELECT("data", sql)
        'With DGV_PRODUCT_GROUP
        '    .DataSource = ds.Tables("DATA")
        '    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .Columns(2).Visible = False
        'End With

        'sql = " select region ""Region"", CASE WHEN SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR)=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR),2) ENd  ""Cog"" from JAN_COG_BREAKUP_TAB where CLASS_CODE" & CUST_TYPE & " 'DEALER' group by region ORDER BY region"
        'ds = SQL_SELECT("data", sql)
        'With dgv_reg_breakup
        '    .DataSource = ds.Tables("data")
        '    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        'End With
    End Sub
    Private Sub dgv_reg_breakup_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_reg_breakup.CellClick
        DGV_CUST_BREAK.Columns.Clear()

        Label2.Visible = True
        Label2.Text = " Breakup For  Region"

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

        sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Overall Cog"",(select AVG_PAID_DAYS from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Avg Payment Days"",(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V where CUSTOMER_ID=A.CUSTOMER_ID and SITE_USE_ID is null)""Payment Term"" from JAN_COG_BREAKUP_TAB  a where 1=1 and fin_year='" & cmb_fin_year.Text & "'"

        If rad_overall.Checked = True Then
            sql &= "  and REGION='" & dgv_reg_breakup.CurrentRow.Cells(0).Value & "' "
        ElseIf rad_class_code.Checked = True Then
            If dgv1.CurrentRow.Cells(0).Value = "DEALER" Then
                CUST_TYPE = "="
                Label1.Text = "Breakup For : Dealer"
            Else
                CUST_TYPE = "<>"
                Label1.Text = "Breakup For :Customer"
            End If

            sql &= " and CLASS_CODE" & CUST_TYPE & " 'DEALER' and REGION='" & dgv_reg_breakup.CurrentRow.Cells(0).Value & "' "
        ElseIf rad_make_buy.Checked = True Then

            'If dgv_make_buy.CurrentRow.Cells(0).Value = "Make" Then


            'Else
            '    CUST_TYPE = "<>"
            '    Label1.Text = "Breakup For :Buy"
            'End If

            sql &= " and (SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)='" & dgv_make_buy.CurrentRow.Cells(0).Value & "' and REGION='" & dgv_reg_breakup.CurrentRow.Cells(0).Value & "' "

        End If


        'CLASS_CODE(" & CUST_TYPE & ") 'DEALER' and REGION='" & dgv_reg_breakup.CurrentRow.Cells(0).Value & "' 

        sql &= " group by CUSTOMER_NAME ,CUSTOMER_ID"
        ds = SQL_SELECT("data", sql)
        With DGV_CUST_BREAK
            .DataSource = ds.Tables("DATA")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

    End Sub
    Private Sub btn_view_breakup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_breakup.Click
        dgv_reg_breakup.Columns.Clear()
        DGV_PRODUCT_GROUP.Columns.Clear()
        DGV_CUST_BREAK.Columns.Clear()
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False

        If rad_overall.Checked = True Then

            sql = "select PRODUCT_GROUP ""Product Group"",cog ""Cog"" ,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP where GROUP_NAME=a.PRODUCT_GROUP and rownum=1)GROUP_ORD FROM( select PRODUCT_GROUP , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd cog from JAN_COG_BREAKUP_TAB  where fin_year='" & cmb_fin_year.Text & "' group by PRODUCT_GROUP )A ORDER BY GROUP_ORD"

        ElseIf rad_class_code.Checked = True Then
            If dgv1.CurrentRow.Cells(0).Value = "DEALER" Then
                CUST_TYPE = "="
                Label1.Text = "Breakup For : Dealer"
            Else
                CUST_TYPE = "<>"
                Label1.Text = "Breakup For :Customer"
            End If

            sql = "select PRODUCT_GROUP ""Product Group"",cog ""Cog"" ,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP where GROUP_NAME=a.PRODUCT_GROUP and rownum=1)GROUP_ORD FROM( select PRODUCT_GROUP , CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd cog from JAN_COG_BREAKUP_TAB where CLASS_CODE" & CUST_TYPE & " 'DEALER' and  fin_year='" & cmb_fin_year.Text & "' group by PRODUCT_GROUP, CLASS_CODE  )A ORDER BY GROUP_ORD"
        ElseIf rad_make_buy.Checked = True Then

            If dgv_make_buy.CurrentRow.Cells(0).Value = "Make" Then
                CUST_TYPE = "="
                Label1.Text = "Breakup For : Make"
            Else
                CUST_TYPE = "<>"
                Label1.Text = "Breakup For :Buy"
            End If

            sql = "SELECT  PRODUCT_GROUP ""Product Group"",CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) end ""Current Fin Yr Cog"" ,(select GROUP_ORD from JAN_DEALER_TARGET_PROD_GROUP where GROUP_NAME=b.PRODUCT_GROUP and rownum=1)GROUP_ORD FROM (SELECT A.* ,(SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)MAKE_BUY FROM JAN_COG_BREAKUP_TAB A where fin_year='" & cmb_fin_year.Text & "')b  where MAKE_BUY="
            If dgv_make_buy.CurrentRow.Cells(0).Value = "Make" Then sql &= " 'Make'" Else sql &= " 'Buy'"
            sql &= " GROUP BY PRODUCT_GROUP  ORDER BY GROUP_ORD"

        End If

        ds = SQL_SELECT("data", sql)
        With DGV_PRODUCT_GROUP
            .DataSource = ds.Tables("DATA")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            'If rad_make_buy.Checked = False Then

            'End If
            .Columns(2).Visible = False
        End With

        If rad_overall.Checked = True Then
            Label1.Text = "Breakup For :Overall COG"

            sql = "select region ""Region"", CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Cog"" from JAN_COG_BREAKUP_TAB where fin_year='" & cmb_fin_year.Text & "' group by region ORDER BY region"
        ElseIf rad_class_code.Checked = True Then

            sql = " select region ""Region"", CASE WHEN SUM(TOTAL_SALE_QTY*" & m_plus_l & ")=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2) ENd  ""Cog"" from JAN_COG_BREAKUP_TAB where CLASS_CODE" & CUST_TYPE & " 'DEALER' and  fin_year='" & cmb_fin_year.Text & "' group by region ORDER BY region"

        ElseIf rad_make_buy.Checked = True Then

            sql = "SELECT region ""Region"",ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*" & m_plus_l & "),2)""Current Fin Yr Cog"" FROM (SELECT A.* ,(SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)MAKE_BUY FROM JAN_COG_BREAKUP_TAB A where fin_year='" & cmb_fin_year.Text & "' )  where MAKE_BUY="
            If dgv_make_buy.CurrentRow.Cells(0).Value = "Make" Then sql &= " 'Make'" Else sql &= " 'Buy'"
            sql &= " GROUP BY region "

        End If


        ds = SQL_SELECT("data", sql)
        With dgv_reg_breakup
            .DataSource = ds.Tables("data")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        End With
    End Sub
    'Private Sub DGV_PRODUCT_GROUP_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_PRODUCT_GROUP.CellClick
    '    Label2.Visible = True
    '    Label2.Text = " Breakup For Product Group"

    '    sql = "select CUSTOMER_NAME ""Customer Name "",case when SUM(APR_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(APR_SALE_VAL)/ SUM(APR_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Apr Cog"",case when SUM(MAY_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(MAY_SALE_VAL)/ SUM(MAY_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""May Cog"",case when SUM(JUN_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(JUN_SALE_VAL)/ SUM(JUN_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Jun Cog"",case when SUM(JUl_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(JUl_SALE_VAL)/ SUM(JUl_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Jul Cog"""

    '    sql &= ",case when SUM(aug_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(aug_SALE_VAL)/ SUM(aug_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Aug Cog"""
    '    sql &= ",case when SUM(sep_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(sep_SALE_VAL)/ SUM(sep_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Sep Cog"""
    '    sql &= ",case when SUM(oct_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(oct_SALE_VAL)/ SUM(oct_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Oct Cog"""
    '    sql &= ",case when SUM(nov_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(nov_SALE_VAL)/ SUM(nov_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Nov Cog"""
    '    sql &= ",case when SUM(dec_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(dec_SALE_VAL)/ SUM(dec_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Dec Cog"""
    '    sql &= ",case when SUM(jan_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(jan_SALE_VAL)/ SUM(jan_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Jan Cog"""
    '    sql &= ",case when SUM(feb_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(feb_SALE_VAL)/ SUM(feb_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Feb Cog"""
    '    sql &= ",case when SUM(mar_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(mar_SALE_VAL)/ SUM(mar_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Mar Cog"""

    '    sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR)=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR),2) ENd  ""Overall Cog"",(select AVG_PAID_DAYS from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID)""Avg Payment Days"",(select STANDARD_TERMS_NAME from AR_CUSTOMER_PROFILES_V where CUSTOMER_ID=A.CUSTOMER_ID and SITE_USE_ID is null)""Payment Term"" from JAN_COG_BREAKUP_TAB  a where 1=1 "

    '    If rad_overall.Checked = True Then
    '        sql &= "  and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "
    '    ElseIf rad_class_code.Checked = True Then
    '        If dgv1.CurrentRow.Cells(0).Value = "DEALER" Then
    '            CUST_TYPE = "="
    '            Label1.Text = "Breakup For : Dealer"
    '        Else
    '            CUST_TYPE = "<>"
    '            Label1.Text = "Breakup For :Customer"
    '        End If

    '        sql &= " and CLASS_CODE" & CUST_TYPE & " 'DEALER' and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "
    '    ElseIf rad_make_buy.Checked = True Then

    '        sql &= " and (SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)='" & dgv_make_buy.CurrentRow.Cells(0).Value & "' and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "

    '    End If

    '    sql &= " group by CUSTOMER_NAME ,CUSTOMER_ID"
    '    ds = SQL_SELECT("data", sql)
    '    With DGV_CUST_BREAK
    '        .DataSource = ds.Tables("DATA")
    '        .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    End With

    'End Sub
    'Private Sub DGV_CUST_BREAK_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_CUST_BREAK.CellClick
    '    Label3.Visible = True
    '    Label3.Text = "Breakup Of " & DGV_CUST_BREAK.CurrentRow.Cells(0).Value

    '    sql = "select jan_orgcode(org_id)org,jan_itemname(inventory_item_id)item_No,case when SUM(APR_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(APR_SALE_VAL)/ SUM(APR_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Apr Cog"",case when SUM(MAY_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(MAY_SALE_VAL)/ SUM(MAY_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""May Cog"",case when SUM(JUN_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(JUN_SALE_VAL)/ SUM(JUN_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Jun Cog"""

    '    sql &= ",case when SUM(JUl_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(JUl_SALE_VAL)/ SUM(JUN_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Jul Cog"""
    '    sql &= ",case when SUM(aug_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(aug_SALE_VAL)/ SUM(aug_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Aug Cog"""
    '    sql &= ",case when SUM(sep_SALE_QTY*M_PLUS_L_ASON31MAR)=0 then 0 else ROUND(SUM(sep_SALE_VAL)/ SUM(sep_SALE_QTY*M_PLUS_L_ASON31MAR),2)end ""Sep Cog"""


    '    sql &= " , CASE WHEN SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR)=0 THEN 0 ELSE ROUND(SUM(TOTAL_SALE_VAL)/SUM(TOTAL_SALE_QTY*M_PLUS_L_ASON31MAR),2) ENd  ""Avg Cog"" from JAN_COG_BREAKUP_TAB  a where 1=1  and CUSTOMER_NAME='" & DGV_CUST_BREAK.CurrentRow.Cells(0).Value & "' "

    '    If rad_overall.Checked = True Then

    '        'sql &= "  and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "
    '    ElseIf rad_class_code.Checked = True Then
    '        If dgv1.CurrentRow.Cells(0).Value = "DEALER" Then
    '            CUST_TYPE = "="
    '            Label1.Text = "Breakup For : Dealer"
    '        Else
    '            CUST_TYPE = "<>"
    '            Label1.Text = "Breakup For :Customer"
    '        End If

    '        sql &= " and CLASS_CODE" & CUST_TYPE & " 'DEALER' and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "
    '    ElseIf rad_make_buy.Checked = True Then

    '        sql &= " and (SELECT DECODE(COUNT(*) ,0,'Make','Buy') FROM JAN_BUY_AND_SELL_PRODUCTS WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)='" & dgv_make_buy.CurrentRow.Cells(0).Value & "' and REGION='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "' "
    '    End If

    '    If Label2.Text = "Breakup For Product Group" Then
    '        sql &= " and product_group='" & DGV_PRODUCT_GROUP.CurrentRow.Cells(0).Value & "'"
    '    End If

    '    sql &= " group by  inventory_item_id,org_id order by org,item_no"
    '    ds = SQL_SELECT("data", sql)
    '    With dgv_item_breakup
    '        .DataSource = ds.Tables("DATA")
    '        '.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    End With
    'End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Cog_breakup.Show()
    End Sub
    Private Sub cmb_fin_year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_fin_year.SelectedIndexChanged, cmb_MplusL.SelectedIndexChanged
        If cmb_MplusL.Text <> "" Then
            display_result()
        End If

    End Sub

    Private Sub rad_mplul_mar2016_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Go.Click
        display_result()
    End Sub
End Class