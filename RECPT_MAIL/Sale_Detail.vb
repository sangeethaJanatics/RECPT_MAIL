Public Class Sale_Detail

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        If rad_order_sale_form2.Checked = True Then
            sql = " select b.* 
,(select attribute15  from ra_customers   where customer_id=b.cust_id)main_segment
,(select attribute16  from ra_customers   where customer_id=b.cust_id)sub_segment
from (
select cust_id,cust_name,region,ord_type ,sum(order_value)order_value,sum(sale_value)sale_value from 
(select cust_id,cust_name,region,ord_type,sum(ordered_quantity*unit_selling_price)order_value,0 sale_value from jan_bms_order_pending_new_v where 
ordered_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and cust_id in (select customer_id from ra_customers where trunc(creation_date)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and trunc(creation_date)<'" & Format(DateAdd("d", 1, To_date.Value), "dd-MMM-yyyy") & "') "

            If cmb_customer.Text <> "" Then sql &= " and cust_id=" & cmb_customer.SelectedValue & ""

            sql &= " group by cust_id,cust_name,region,ord_type
union  all
SELECT bill_to_customer_id,BILL_TO_CUST_NAME,region,oatype
,0 order_receipt,sum(quantity_invoiced*unit_selling_price)sale_value FROM JAN_INVOICE_LISTING WHERE  trx_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' 
and   bill_to_customer_id in (select customer_id from ra_customers where trunc(creation_date)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and trunc(creation_date)<'" & Format(DateAdd("d", 1, To_date.Value), "dd-MMM-yyyy") & "')  "

            If cmb_customer.Text <> "" Then sql &= " and bill_to_customer_id=" & cmb_customer.SelectedValue & ""

            sql &= " group by  bill_to_customer_id,BILL_TO_CUST_NAME,oatype,region
) group by cust_id,cust_name,region,ord_type )b "

        ElseIf Rad_order_receipt.Checked = False Then

            'Query for customer detail 
            sql = "select (select distinct ter_name from jan_bms_bill_to_v where customer_id=rac.customer_id and address1=rac.bill_to_site  and rownum=1)region,
 (select distinct zone_nam from jan_bms_bill_to_v where customer_id=rac.customer_id  and address1=rac.bill_to_site and rownum=1)sub_region,
(select distinct address2||','||address3||','||city||','||state||','||postal_code from jan_bms_bill_to_v where customer_id=rac.customer_id  and address1=rac.bill_to_site and rownum=1 )address

,
  rowtocol('SELECT  COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Telephone'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='
  ||rac.customer_id
  ||')')phone,
  rowtocol('SELECT  COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Fax'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='
  ||rac.customer_id
  ||')')fax,
  rowtocol('SELECT  distinct email_address  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''E-mail'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='
  ||rac.customer_id
  ||')')e_mail,
  ROWTOCOL('SELECT CONT_FIRST_NAME || '' '' || CONT_LAST_NAME  FROM AR_CUSTOMER_CONTACT_FIND_V WHERE CUSTOMER_ID='''
  || rac.CUSTOMER_ID
  || '''')contact_person,
rac.*

from (
select  bill_to_customer_id customer_id,bill_to_cust_name,bill_to_site,sum(quantity_invoiced*unit_selling_price)sale_value_from_apr2016
from jan_sales_any_1_copy where trx_date>='1-apr-2016' and region  like 'BANGALO%' -- and bill_to_customer_id =2343589
group by  bill_to_customer_id,bill_to_cust_name,bill_to_site)rac"
            sql = ""
            Dim value_for As String = ""
            If rad_sale_qty.Checked = True Then
                value_for = "quantity_invoiced"
            ElseIf rad_sale_val.Checked = True Then
                value_for = "quantity_invoiced*unit_selling_price"
            End If
            dgv1.Columns.Clear()
            If chk_monthwise.Checked = True Then
                sql = "select distinct my ,concat(substr(my,3,4),substr(my,1,2))my1 from jan_sales_any_1_copy where  trx_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  and  trx_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "' order  by my1 "
                ds = SQL_SELECT("month", sql)
            End If
            If chk_daywise.Checked = True Then
                sql = "select distinct trx_date,to_char(trx_date,'DDMONYYYY')ss from jan_sales_any_1_copy where  trx_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  and  trx_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "' order by 1 "
                ds = SQL_SELECT("month", sql)
            End If

            If chk_yearwise.Checked = True Then

                'sql = " select ASSESSMENT_YEAR,replace(ASSESSMENT_YEAR,'-','')ss,start_date,end_date from jan_bi_ap_tb3 where  start_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  and  end_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "' order by 1"
                sql = "select curYEAR,replace(curYEAR,'-','_')ss,start_date,end_date from jan_bi_ap_tb3 where   start_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  and  end_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "' union select curYEAR,replace(curYEAR,'-','_')ss,start_date,end_date from jan_bi_ap_tb3 where   to_date('" & Format(To_date.Value, "dd-MMM-yyyy") & "') between start_date  and  end_date   order by 1 "
                ds = SQL_SELECT("month", sql)
            End If

            sql = "select "
            If chk_customer_wise.Checked = True Then sql &= " bill_to_cust_name,region,(select attribute15 from ra_customers where customer_id=a.bill_to_customer_id)Industrial_main_segment,(select attribute16 from ra_customers where customer_id=a.bill_to_customer_id)Industrial_sub_segment,(select customer_category from jan_pick_forward_control where bill_to_customer_id=a.bill_to_customer_id)customer_category,(select customer_class_code from ra_customers where customer_id=a.bill_to_customer_id)customer_class_code ,(select decode(customer_type,1,'Project Customer', 2,'Key Customer',customer_type)cust_type from jan_project_key_customer where  customer_id=a.bill_to_customer_id)Project_key , "
            'bill_to_cust_name,region"
            If CHK_REGION_WISE.Checked = True Then sql &= " region,"

            If chk_item_wise.Checked = True Then sql &= " jan_orgcode(organization_id)org,ordered_item, " 'JAN_SALES_RRS_CATEGORY(a.organization_id,a.inventory_ITEM_ID) rrs,(select decode((ROQ+ROL) ,0,'No','Yes')from JAN_CUSTOMER_REPLENISHMENT_T where end_date is null and inventory_item_id=a.inventory_item_id and organization_id=a.organization_id and  customer_id=b.bill_to_customer_id)bin_exists ,"

            If chk_monthwise.Checked = True Then

                For i = 0 To ds.Tables("month").Rows.Count - 1
                    With ds.Tables("month").Rows(i)
                        sql &= "  sum(case when my='" & .Item("my") & "' then (" & value_for & ") else 0 end )sale_" & .Item("my") & " "

                        If i < ds.Tables("month").Rows.Count - 1 Then sql &= " , "
                    End With
                Next
            ElseIf chk_daywise.Checked = True Then

                For i = 0 To ds.Tables("month").Rows.Count - 1
                    With ds.Tables("month").Rows(i)


                        sql &= "  sum(case when trx_date='" & Format(.Item("trx_date"), "dd-MMM-yyyy") & "' then (" & value_for & ") else 0 end )sale_" & .Item("ss") & " "
                        If i < ds.Tables("month").Rows.Count - 1 Then sql &= " , "
                    End With
                Next
            ElseIf chk_yearwise.Checked = True Then

                For i = 0 To ds.Tables("month").Rows.Count - 1
                    With ds.Tables("month").Rows(i)
                        sql &= "  sum(case when trx_date>='" & Format(.Item("start_date"), "dd-MMM-yyyy") & "' and  trx_date<='" & Format(.Item("end_date"), "dd-MMM-yyyy") & "' then (" & value_for & ") else 0 end )sale_" & .Item("ss") & " "

                        If i < ds.Tables("month").Rows.Count - 1 Then sql &= " , "
                    End With
                Next

            ElseIf chk_category.Checked = True Then
                sql &= "  sum( case when  bill_to_customer_id in( select customer_id from ra_customers   where customer_class_code='DEALER') then (" & value_for & ")   else 0 end )sale_value_dealer ,sum( case when  bill_to_customer_id not in( select customer_id from ra_customers   where customer_class_code='DEALER') then (" & value_for & ")   else 0 end )sale_value_customer"
            Else
                sql &= "  sum( (" & value_for & ")  )sale_value"
            End If


            sql &= " ,max(trx_date)last_inv_date from jan_sales_any_1_copy  a where  trx_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  and  trx_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "'  "

            If cmb_customer.Text <> "" Then sql &= " and bill_to_customer_id=" & cmb_customer.SelectedValue & ""

            If txt_part_no.Text <> "" Then
                If txt_part_no.Text.Contains("%") Then

                    sql &= " and ordered_item like '" & txt_part_no.Text & "%'"
                Else
                    sql &= " and ordered_item='" & txt_part_no.Text & "'"


                End If
            End If
            If rad_dealer.Checked = True Then
                sql &= "  and  bill_to_customer_id  in ( select customer_id from ra_customers   where customer_class_code='DEALER' )"

            ElseIf Rad_customer.Checked = True Then
                sql &= " and  bill_to_customer_id not in ( select customer_id from ra_customers   where customer_class_code='DEALER' )"
            End If



            If chk_item_wise.Checked = True Then sql &= " group by organization_id,ordered_item order by org,ordered_item"
            If chk_customer_wise.Checked = True Then
                sql &= "  group by bill_to_cust_name,region,bill_to_customer_id order by bill_to_cust_name,region "
            End If
            If CHK_REGION_WISE.Checked = True Then sql &= "  group by region  order  by region "

        Else
            sql = "select cust_id,cust_name,region,ord_type ,sum(order_value)order_value,sum(sale_value)sale_value from (select cust_id,cust_name,region,ord_type,sum(ordered_quantity*unit_selling_price)order_value,0 sale_value from jan_bms_order_pending_new_v where ordered_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and ordered_date<'" & DateAdd("d", 1, Format(To_date.Value, "dd-MMM-yyyy")) & "' "

            If cmb_customer.Text <> "" Then sql &= " and cust_id=" & cmb_customer.SelectedValue & ""
            sql &= " group by cust_id,cust_name,region,ord_type "

            sql &= "union  all "

            sql &= " SELECT bill_to_customer_id,BILL_TO_CUST_NAME,region,oatype,0 order_receipt,sum(quantity_invoiced*unit_selling_price)sale_value FROM JAN_INVOICE_LISTING WHERE  trx_date>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and trx_date<'" & DateAdd("d", 1, Format(To_date.Value, "dd-MMM-yyyy")) & "' "

            If cmb_customer.Text <> "" Then sql &= " and bill_to_customer_id=" & cmb_customer.SelectedValue & ""
            sql &= " group by  bill_to_customer_id,BILL_TO_CUST_NAME,oatype,region) group by cust_id,cust_name,region,ord_type "
        End If
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub
    Private Sub Sale_Detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sql = "SELECT SYS_CONTEXT('USERENV', 'IP_ADDRESS')IP FROM DUAL"
        'ds = SQL_SELECT("data", sql)

        'If ds.Tables("data").Rows(0).Item("ip") = "192.168.12.18" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.12.102" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.23.60" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.71.111" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.26.98" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.12.104" Then

        sql = "select customer_id,customer_Name from ra_customers where status='A'  order by customer_Name"
            ds = SQL_SELECT("data", sql)
            cmb_customer.DataSource = ds.Tables("data")
            cmb_customer.DisplayMember = "customer_Name"
            cmb_customer.ValueMember = "customer_id"

        'Else
        '    MsgBox("ORA-00051: You were waiting for a resource and you timed out. ", MsgBoxStyle.Information)
        '    btn_go.Enabled = False
        'End If
    End Sub
End Class