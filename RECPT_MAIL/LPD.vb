Public Class LPD
    Private Sub btn_view_Click(sender As Object, e As EventArgs) Handles btn_view.Click

        sql = " select customer_name ""Dealer Name"" ,as_on ""As ON"",payment_exp_date ""Payment Exp Dt"",to_be_collected_on ""Tobe Collected on"",payment_to_be_made ""Payment Tobe Made"",paid_in_time ""Paid In Time"" ,lpd from JAN_DEALER_LPD_201819_Q1 where  payment_exp_date>='" & Format(payment_date_from.Value, "dd-MMM-yyyy") & "' and payment_exp_date<'" & Format(Payment_dt_to.Value, "dd-MMM-yyyy") & "' "

        If cmb_dealer.Text <> "" Then sql &= " and  cust_id=" & cmb_dealer.SelectedValue & ""
        sql &= " order  by customer_name,payment_exp_date"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub

    Private Sub LPD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = " select LPD_from_dt, LPD_to_dt,lPD_run_dt from jan_sales_bi_setup"
        ds = SQL_SELECT("data", sql)
        lbl_status.Text = " Payment Status as on " & ds.Tables("data").Rows(0).Item("lPD_run_dt") & ""

        sql = "select customer_id,customer_name  from ra_customers where customer_class_code='DEALER' order by 2"
        ds = SQL_SELECT("data", sql)
        cmb_dealer.DataSource = ds.Tables("data")
        cmb_dealer.ValueMember = "customer_id"
        cmb_dealer.DisplayMember = "customer_name"

    End Sub

    Private Sub BTN_RMA_Click(sender As Object, e As EventArgs) Handles BTN_RMA.Click


        sql = "select customer_name,region ,jan_orgcode(to_organization_id)org,segment1 tem_no,item_description ,receipt_num,receipt_dt,quantity_received,(quantity_received*unit_selling_price)rm_value,return_reason,rma_number,rma_date from JAN_RMA_LISTING_DEALER_TAB where RECEIPT_Dt>='" & Format(payment_date_from.Value, "dd-MMM-yyyy") & "' and  RECEIPT_Dt<'" & Format(Payment_dt_to.Value, "dd-MMM-yyyy") & "'  and customer_name in (select customer_name from ra_customers   where  customer_class_code='DEALER' )  order by customer_name,org,segment1"
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

    Private Sub btn_cheque_bounce_Click(sender As Object, e As EventArgs) Handles btn_cheque_bounce.Click
        sql = "select * from JAN_AR_REVERSE where receipt_date>'" & Format(payment_date_from.Value, "dd-MMM-yyyy") & "' and receipt_date<='" & Format(Payment_dt_to.Value, "dd-MMM-yyyy") & "' and customer_id in (select customer_id from ra_customers   where  customer_class_code='DEALER' )  "

        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub
    Private Sub but_scheme_non_scheme_sale_Click(sender As Object, e As EventArgs) Handles but_scheme_non_scheme_sale.Click
        sql = "select bill_to_cust_Name ""Dealer Name"", region ,sum(quantity_invoiced*unit_selling_price)""Total Sale Value"",
sum(case when tod_no=0 then (quantity_invoiced*unit_selling_price) else 0 end )""Tod Item Sale value"" 
,sum(case when tod_no>0 then (quantity_invoiced*unit_selling_price) else 0 end )""Non Tod Item Sale value""  
,sum(case when scheme_order='Y' then (quantity_invoiced*unit_selling_price) else 0 end )""Scheme Sale Value"" 
,sum(case when scheme_order<>'Y' then (quantity_invoiced*unit_selling_price) else 0 end )""Non Scheme Sale Value""  
from (
select a.* 
,nvl((select count(*) from jan_tod_exempted_items where end_date is null and item_id=a.inventory_item_id),0) tod_no
,nvl((select dsp_mast.scheme_order from oe_dms_order_headers_all  oe_dsp ,jan_dsp_master dsp_mast  ,oe_order_lines_all oel
where  oel.attribute8= oe_dsp.oe_order_ref_no and oe_dsp.oe_dsp_id=dsp_mast.dsp_id and oel.line_id=a.line_id),'N')scheme_order

from jan_sales_any_1_copy a 
where bill_to_customer_id in (select customer_id from ra_customers where customer_class_code='DEALER' "
        If cmb_dealer.Text <> "" Then sql &= " and customer_id =  " & cmb_dealer.SelectedValue & ""


        sql &= " )  
and trx_date>='" & Format(payment_date_from.Value, "dd-MMM-yyyy") & "'  and trx_date<='" & Format(Payment_dt_to.Value, "dd-MMM-yyyy") & "')  group by bill_to_cust_Name, region order  by 1"

        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub
End Class