Public Class Payment_KPI

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        dgv1.Columns.Clear()
        If rad_nil_os.Checked = True Then
            sql = "select * from Jan_Branch_Rating_Brkup where criteria=1 order by region"
        ElseIf rad_cust_cat_OS.Checked = True Then
            sql = " select customer_category,sum(current_os)current_os from (select a.* ,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id)customer_category from (SELECT REGION,bill_to_cust_name,bill_to_customer_id,SUM(CASE WHEN  AMOUNT_DUE_REMAINING>0  THEN AMOUNT_DUE_REMAINING ELSE 0  END)current_os FROM    JAN_REGION_PAYMENT_PENDING_tab  WHERE name not in (select name from jan_exemp_payment_inv)    and bill_to_cust_name  not like 'JANATICS%'and  AMOUNT_DUE_REMAINING>0 and region<>'NOT LISTED' GROUP BY REGION,bill_to_cust_name ,bill_to_customer_id)a ) group by customer_category  order by customer_category"
        ElseIf rad_OS_breakup.Checked = True Then

            sql = " select cust_category,bill_to_cust_name,region,sum(current_os)current_os from (select a.* ,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id)cust_category from (SELECT REGION,bill_to_cust_name,bill_to_customer_id,SUM(CASE WHEN  AMOUNT_DUE_REMAINING>0  THEN AMOUNT_DUE_REMAINING ELSE 0  END)current_os FROM    JAN_REGION_PAYMENT_PENDING_tab  WHERE name not in (select name from jan_exemp_payment_inv)    and bill_to_cust_name  not like 'JANATICS%' and  AMOUNT_DUE_REMAINING>0 and region<>'NOT LISTED' GROUP BY REGION,bill_to_cust_name ,bill_to_customer_id)a ) group by cust_category ,bill_to_cust_name,region  order  by cust_category ,bill_to_cust_name "
        ElseIf rad_odue_cust_category_wise.Checked = True Then

            sql = " select cust_category,sum(current_os)current_odue from (select a.* ,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id)cust_category from (SELECT REGION,bill_to_cust_name,bill_to_customer_id,SUM(CASE WHEN  AMOUNT_DUE_REMAINING>0  THEN AMOUNT_DUE_REMAINING ELSE 0  END)current_os FROM    JAN_REGION_PAYMENT_PENDING_tab  WHERE name not in (select name from jan_exemp_payment_inv)    and bill_to_cust_name  not like 'JANATICS%' and  AMOUNT_DUE_REMAINING>0 and region<>'NOT LISTED' and nvl(due_days,0)>0  GROUP BY REGION,bill_to_cust_name ,bill_to_customer_id)a ) group by cust_category  order  by cust_category  "
        ElseIf rad_odue_cust_cat_breakup.Checked = True Then

            sql = " select cust_category,bill_to_cust_name,region,sum(current_os)current_odue from (select a.* ,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id)cust_category from (SELECT REGION,bill_to_cust_name,bill_to_customer_id,SUM(CASE WHEN  AMOUNT_DUE_REMAINING>0  THEN AMOUNT_DUE_REMAINING ELSE 0  END)current_os FROM    JAN_REGION_PAYMENT_PENDING_tab  WHERE name not in (select name from jan_exemp_payment_inv)    and bill_to_cust_name  not like 'JANATICS%' and  AMOUNT_DUE_REMAINING>0 and region<>'NOT LISTED' and nvl(due_days,0)>0  GROUP BY REGION,bill_to_cust_name ,bill_to_customer_id)a ) group by cust_category ,bill_to_cust_name,region  order  by cust_category ,bill_to_cust_name "
        ElseIf rad_over_due.Checked = True Then
            sql = "select * from jan_overdue_slab where period_year is not null"
        ElseIf rad_payment_adhr_cust.Checked = True Then
            sql = "select * from jan_payment_adherence_customer"
        ElseIf rad_payment_adhr_region.Checked = True Then
            sql = "select * from jan_payment_adherence_region"
        ElseIf rad_delivery_rating_customer.Checked = True Then
            sql = "select c.*,nvl((select decode(count(*),0,'No','Yes') from jan_customer_replenishment_t where end_date is null and customer_id=c.CUSTOMER_ID),'No')bin_available from (SELECT    B.* ,(SELECT CUSTOMER_CLASS_CODE FROM RA_CUSTOMERS WHERE CUSTOMER_ID=B.CUSTOMER_ID  and status='A')CUSTOMER_CLASS_CODE,(SELECT CUSTOMER_CATEGORY FROM JAN_PICK_FORWARD_CONTROL WHERE BILL_TO_CUSTOMER_ID=B.CUSTOMER_ID  )CUSTOMER_CATEGORY FROM (select a.* ,nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>=(select f_dt_cyr from jan_sales_bi_setup) and bill_to_cust_name=a.customer_name and region=a.region),0)sale_from_cyr_apr,(SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE CUSTOMER_NAME=A.CUSTOMER_NAME  and status='A' )CUSTOMER_ID from jan_delivery_rating a)B)c"
        ElseIf rad_dealer_delivery_rating.Checked = True Then

            sql = "SELECT * FROM JAN_DELIVERY_RATING_CONSOLID ORDER BY CUSTOMER_CATEGORY"

        ElseIf rad_dealer_CSI.Checked = True Then
            sql = " select c.*,delivery_rate_40per+pre_post_sale_10per+quality_50per score_obtained ,round(((delivery_rate_40per+pre_post_sale_10per+quality_50per)/max_score)*100,2) final_score from (  select customer_name,CUSTOMER_CATEGORY,region,RU_VAL,RE_VAL,ST_val,round(((RU_VAL+RE_VAL+ST_val)/3),2)delivery_rate_average,  round(round(((RU_VAL+RE_VAL+ST_val)/3),2) *.4,2) delivery_rate_40per,case when ccr_cnt=0 then 50 else 0 end quality_50per ,ipms pre_post_sale_actual  ,ipms*.1 pre_post_sale_10per,90+case when ipms>0 then 10 else 0 end max_score from (  select  customer_name,customer_id,CUSTOMER_CATEGORY,"
            sql &= " rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and  customer_id='||b.customer_id||'' )region,nvl((select count(*)  from JAN_SERVICE_CCR_HEADER a,JAN_SERVICE_CCR_LINES B where(a.CCRNO = B.CCRNO) and  COMPLAINT_BY not in ('Reliability Center','Internal') and COMPLAINT_TYPE in ('Type Defect','Technical')  and a.DEL_FLAG=1 and to_char( CCRDT,'MMYYYY')='" & cmb_month.Text & "' and cuscode='DEALER' and a.cusid=b.customer_id),0)ccr_cnt"
            sql &= " ,nvl((select cmpl_per from jan_ipms_csi where  mon_no||MOn_yr='" & cmb_month.SelectedValue & "' and customer_id =b.customer_id and  source_for='DEALER'),0)ipms"
            sql &= " , nvl(case when ODTMY='" & cmb_month.Text & "' and STATUS='val' then  ROUND(SUM(RU_PER)/sum(case when RU_PER is not null then 1 else 0 end),2) else 0 end,0) RU_VAL,"
            sql &= " nvl(case when ODTMY='" & cmb_month.Text & "' and STATUS='val' then  ROUND(SUM(RE_PER)/sum(case when RE_PER is not null then 1 else 0 end),2) else 0 end ,0) RE_VAL,"
            sql &= " nvl(case when ODTMY='" & cmb_month.Text & "' and STATUS='val' then  ROUND(SUM(ST_PER)/sum(case when ST_PER is not null then 1 else 0 end),2) else 0 end,0)  ST_val   from (  select a.* ,NVL((select CUSTOMER_CATEGORY from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUST_NAME=a.CUSTOMER_NAME),'D4')CUSTOMER_CATEGORY  FROM JAN_DEALER_RATE   A WHERE  ODTMY IN ('" & cmb_month.Text & "') and STATUS='val'and customer_name  IN  (select customer_name from ra_customers   where  customer_class_code='DEALER' )) b group by CUSTOMER_CATEGORY,ODTMY,STATUS,customer_name,customer_id order by customer_name))c "
        ElseIf rad_customer_CSI.Checked = True Then

            sql = "SELECT D.* ,round(((delivery_rate_40per+pre_post_sale_10per+quality_50per)/max_score)*100,2) final_score ,case when pre_post_yes_no>0 then to_char(pre_post_sale_10per) else 'NA' end pre_post_sale_status FROM ( "

            sql &= " select c.*,nvl((select decode(count(*),0,'No','Yes') from jan_customer_replenishment_t where end_date is null and customer_id=c.CUSTOMER_ID),'No')bin_available,90+case when pre_post_yes_no>0 then 10 else 0 end max_score,round(delivery_rate *.4,2) delivery_rate_40per,case when ccr_cnt=0 then 50 else 0 end quality_50per,pre_post_sale_actual*.10 pre_post_sale_10per from ( "

            sql &= " SELECT    B.* ,nvl((select sum(quantity_invoiced*unit_selling_price) from jan_sales_any_1_copy where trx_date>='1-apr-2019' and bill_to_cust_name=b.customer_name and region=b.region),0)sale_from_apr2019 "

            sql &= ",(SELECT CUSTOMER_CLASS_CODE FROM RA_CUSTOMERS WHERE CUSTOMER_ID=B.CUSTOMER_ID  and status='A')CUSTOMER_CLASS_CODE,(SELECT CUSTOMER_CATEGORY FROM JAN_PICK_FORWARD_CONTROL WHERE BILL_TO_CUSTOMER_ID=B.CUSTOMER_ID  )CUSTOMER_CATEGORY "
            sql &= " ,nvl((select count(*)  from JAN_SERVICE_CCR_HEADER a,JAN_SERVICE_CCR_LINES B where(a.CCRNO = B.CCRNO) and  COMPLAINT_BY not in ('Reliability Center','Internal') and COMPLAINT_TYPE in ('Type Defect','Technical')  and a.DEL_FLAG=1 and to_char( CCRDT,'MMYYYY')='" & cmb_month.Text & "' and a.cusid=b.customer_id),0)ccr_cnt "

            sql &= " ,nvl((select avg(cmpl_per) from jan_ipms_csi where  mon_no||MOn_yr='" & cmb_month.SelectedValue & "' and customer_id =b.customer_id),0)pre_post_sale_actual "
            sql &= " ,nvl((select count(*) from jan_ipms_csi where  mon_no||MOn_yr='" & cmb_month.SelectedValue & "' and customer_id =b.customer_id),0)pre_post_yes_no "
            sql &= " FROM (select customer_name,region,round(avg(case when month_ref='" & cmb_month.Text & "' then success_per end ),2) delivery_rate,sum(case when month_ref='" & cmb_month.Text & "' then order_value end ) order_value,customer_id "
            sql &= " from jan_CSI_order_completion_2jul where month_ref='" & cmb_month.Text & "' "
            sql &= " and customer_id  not in (select customer_id from ra_customers   where customer_class_code='DEALER') "
            If cmb_region.Text <> "ALL" Then sql &= " and region ='" & cmb_region.Text & "'  "
            sql &= " group by customer_name,region,customer_id)B)c )D"

        ElseIf rad_payment_cal_status.Checked = True Then
            sql = "select to_char(trunc(next_day(sysdate - 1,'SATURDAY'))-21,'YYYYIW') upto,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))-14,'YYYYIW') week_minus2,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))-7,'YYYYIW') week_minus1,to_char(trunc(next_day(sysdate - 1,'SATURDAY')),'YYYYIW') cur_week,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))+7,'YYYYIW') cur_week_plus1 ,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))+14,'YYYYIW') cur_week_plus2 ,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))+21,'YYYYIW') cur_week_plus3,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))+28,'YYYYIW') cur_week_plus4,to_char(trunc(next_day(sysdate - 1,'SATURDAY'))+35,'YYYYIW') cur_week_plus5 from dual"
            ds1 = SQL_SELECT("data", sql)

            '            Select Case next_day(sysdate - 21,'SATURDAY')cur_wk_minus3,next_day(sysdate-14,'SATURDAY')cur_wk_minus2,next_day(sysdate-7,'SATURDAY')cur_wk_minus1,next_day(sysdate-1,'SATURDAY')cur_wk
            ', next_day(sysdate + 8,'SATURDAY')cur_wk_plus1,next_day(sysdate+16,'SATURDAY')cur_wk_plus2
            With ds1.Tables("data").Rows(0)


                sql = " select (select customer_name from ra_customers WHERE CUSTOMER_CLASS_CODE='DEALER' and customer_id=a.customer_id)dealer_NAme  "

                sql &= " ,(select customer_CATEGORY  from JAN_PICK_FORWARD_CONTROL WHERE  BILL_TO_customer_id=a.customer_id)dealer_CATEGORY ,a.* "

                sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date<=trunc(next_day(sysdate - 1,'SATURDAY'))-21  and cust_id=a.customer_id),0)""Payment Pending Upto " & .Item("upto") & """"

                sql &= ",nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate-1,'SATURDAY'))-14 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("week_minus2") & """"

                sql &= "  ,nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date) =trunc(next_day(sysdate-1,'SATURDAY'))-7 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("week_minus1") & """"

                sql &= " ,nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate-1,'SATURDAY')) and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week") & """"

                sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate -1,'SATURDAY')) + 7 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week_plus1") & """"

                sql &= " ,nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate-1,'SATURDAY')) +14 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week_plus2") & """"

                sql &= " ,nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate -1,'SATURDAY'))+21 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week_plus3") & """"

                sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate-1,'SATURDAY')) +28 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week_plus4") & """"

                sql &= " ,nvl((Select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where trunc(payment_exp_date)=trunc(next_day(sysdate-1,'SATURDAY')) +35 and cust_id=a.customer_id),0)""Payment Pending for wk " & .Item("cur_week_plus5") & """"

                sql &= " ,rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and customer_id='||a.customer_id||'' )region from ( "
                sql &= " select CUSTOMER_ID, sum(NVL(AMOUNT_DR,0)) -SUM(NVL(AMOUNT_CR,0)) ledger_balance from JAN_DEALER_LEDGER_17JUL_2017 where CUSTOMER_ID in (select customer_id from ra_customers WHERE CUSTOMER_CLASS_CODE='DEALER')and ar_date is not null GROUP BY CUSTOMER_ID)a "

            End With

            '            sql = " select (select customer_name from ra_customers WHERE CUSTOMER_CLASS_CODE='DEALER' and customer_id=a.customer_id)dealer_NAme  "

            '            sql &= " ,(select customer_CATEGORY  from JAN_PICK_FORWARD_CONTROL WHERE  BILL_TO_customer_id=a.customer_id)dealer_CATEGORY ,a.* "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date<'31-mar-2019'  and cust_id=a.customer_id),0)payment_pending_UPTO_30mar "

            '            sql &= ",nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'1-apr-2019' and
            'payment_exp_date<'7-apr-2019' and cust_id=a.customer_id),0)payment_pending_6apr  "

            '            sql &= "  ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'7-apr-2019' and 
            'payment_exp_date<'14-apr-2019' and cust_id=a.customer_id),0)payment_pending_13apr "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'14-apr-2019' and 
            'payment_exp_date<'21-apr-2019' and cust_id=a.customer_id),0)payment_pending_20apr "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'21-apr-2019' and 
            'payment_exp_date<'28-apr-2019' and cust_id=a.customer_id),0)payment_pending_27apr "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'28-apr-2019' and 
            'payment_exp_date<'5-may-2019' and cust_id=a.customer_id),0)payment_pending_4may "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'5-may-2019' and 
            'payment_exp_date<'12-may-2019' and cust_id=a.customer_id),0)payment_pending_11may "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'12-may-2019' and 
            'payment_exp_date<'19-may-2019' and cust_id=a.customer_id),0)payment_pending_19may "

            '            sql &= " ,nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'19-may-2019' and 
            'payment_exp_date<'26-may-2019' and cust_id=a.customer_id),0)payment_pending_25may "

            '            sql &= " , nvl((select sum(payment_value-nvl(rsv2,0)) from jan_dealer_payment2 where payment_exp_date>'26-may-2019' and 
            'payment_exp_date<'2-jun-2019' and cust_id=a.customer_id),0)payment_pending_2jun "

            '            sql &= " ,rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and customer_id='||a.customer_id||'' )region from ( "
            '            sql &= " select CUSTOMER_ID, sum(NVL(AMOUNT_DR,0)) -SUM(NVL(AMOUNT_CR,0)) ledger_balance from JAN_DEALER_LEDGER_17JUL_2017 where CUSTOMER_ID in (select customer_id from ra_customers WHERE CUSTOMER_CLASS_CODE='DEALER')and ar_date is not null GROUP BY CUSTOMER_ID)a "


        End If

        ds = SQL_SELECT("data", sql)

        If rad_cust_cat_OS.Checked = True Or rad_OS_breakup.Checked = True Then

            With ds.Tables("data")
                .Rows.Add("Total")
                .Rows(.Rows.Count - 1).Item("current_os") = .Compute("sum(current_os)", "current_os>=0")
            End With
        ElseIf rad_odue_cust_category_wise.Checked = True Or rad_odue_cust_cat_breakup.Checked = True Then
            With ds.Tables("data")
                .Rows.Add("Total")
                .Rows(.Rows.Count - 1).Item("current_odue") = .Compute("sum(current_odue)", "current_odue>=0")
            End With
        End If

        dgv1.DataSource = ds.Tables("data")

        If rad_cust_cat_OS.Checked = True Or rad_OS_breakup.Checked = True Then
            dgv1.Columns("current_os").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgv1.Columns("current_os").DefaultCellStyle.Format = "00.00"
        ElseIf rad_odue_cust_category_wise.Checked = True Or rad_odue_cust_cat_breakup.Checked = True Then
            dgv1.Columns("current_odue").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgv1.Columns("current_odue").DefaultCellStyle.Format = "00.00"
        End If

    End Sub
    Private Sub Payment_KPI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = " select distinct odue_period from jan_overdue_slab_brk"
        ds = SQL_SELECT("data", sql)
        cmb_odue.DataSource = ds.Tables("data")
        cmb_odue.DisplayMember = "odue_period"
        cmb_odue.ValueMember = "odue_period"



        sql = " select mnyear,mnyear2,case when to_number(substr(mnyear,1,2))<10 then substr(mnyear,2) else mnyear end mnth from jan_sales_any_tb3_all where trunc(updation_date)= (select min(updation_date) from jan_sales_any_tb3_all where trunc(updation_date)>(select f_dt_cyr from jan_sales_bi_setup)) order by mnyear2"
        ds = SQL_SELECT("data", sql)
        cmb_month.DataSource = ds.Tables("data")
        cmb_month.DisplayMember = "mnyear"
        cmb_month.ValueMember = "mnth"

        sql = " select 'ALL' region from dual union SELECT DISTINCT SEGMENT14 region FROM RA_TERRITORIES WHERE SEGMENT14 NOT IN ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O','DELHI 2','DELHI 3') order by region"
        ds = SQL_SELECT("data", sql)
        cmb_region.DataSource = ds.Tables("data")
        cmb_region.DisplayMember = "region"
        cmb_region.ValueMember = "region"


    End Sub
    Private Sub rad_over_due_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_over_due.CheckedChanged, rad_odue_cust_category_wise.CheckedChanged, rad_odue_cust_cat_breakup.CheckedChanged
        If rad_over_due.Checked = True Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select * from jan_overdue_slab_brk where odue_period='" & cmb_odue.Text & "'"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

End Class