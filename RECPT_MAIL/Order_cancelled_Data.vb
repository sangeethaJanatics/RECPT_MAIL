Public Class Order_cancelled_Data

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If rad_cancelled_oa.Checked = True Then

            sql = " select * from ("
            sql = "select (select customer_Name from ra_customers where customer_id=a.sold_to_org_id)customer_Name, rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and  customer_id='||a.sold_to_org_id||'' )region, (select order_number from oe_order_headers_all where header_id=a.header_id)oa_no, (select ordered_date from oe_order_headers_all where header_id=a.header_id)oa_dt,JAN_ORGCODE(SHIP_FROM_ORG_ID)ORG,JAN_ITEMNAME(INVENTORY_ITEM_ID)ITEM_NO,CANCELLED_QUANTITY ,CANCELLED_QUANTITY*UNIT_SELLING_PRICE CANCELLED_VALUE, (select booked_date from oe_order_headers_all where header_id=a.header_id)booked_dt,Cancelled_date,A.REASON_REMARLS  from jan_orders_cancelled_history  a where 1=1 "
            If rad_cancellation_date.Checked = True Then sql &= " and trunc(Cancelled_date)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and  trunc(Cancelled_date)<'" & Format(To_date.Value, "dd-MMM-yyyy") & "'"

            If rad_order_date.Checked = True Then sql &= " and (select trunc(ordered_date) from oe_order_headers_all where header_id=a.header_id)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and  (select trunc(ordered_date) from oe_order_headers_all where header_id=a.header_id)<'" & Format(To_date.Value, "dd-MMM-yyyy") & "'"
            If chk_dealer_order.Checked = True Then sql &= " and sold_to_org_id in (select customer_id from ra_customers where customer_class_code='DEALER')"

            sql &= "  order by oa_dt,oa_no,customer_Name,ORG,ITEM_NO"

            ElseIf rad_data_to_cancel_order.Checked = True Then
                sql = " select * from (SELECT (select customer_name from ra_customers where customer_id=a.sold_to_org_id)CUSTOMER_NAME,(select order_number from oe_order_headers_all where header_id=a.header_id)ORDER_NUMBER,ORDERED_DATE,REGION,SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)ORDER_PENDING_VALUE,   SUM(RSV_QTY*UNIT_SELLING_PRICE)AVL  ,min(ORDER_FF_DT)ORDER_FF_DT  from JAN_SALES_plan_tv_t a  where (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  group by sold_to_org_id, header_id, ORDERED_DATE, REGION) where trunc(ORDER_FF_DT)<='" & Format(DateTimePicker_OA_clean.Value, "dd-MMM-yyyy") & "'"

        End If

        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")

    End Sub
    Private Sub Order_cancelled_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT SYS_CONTEXT('USERENV', 'IP_ADDRESS')IP,SYS_CONTEXT('USERENV', 'HOST')HOST_NAME FROM DUAL"
        ds = SQL_SELECT("data", sql)

        'If ds.Tables("data").Rows(0).Item("ip") = "192.168.12.18" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.12.102" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.23.60" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.71.111" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.26.98" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.12.104" Or ds.Tables("data").Rows(0).Item("HOST_NAME") = "JANATICSINDIA\U1005HODMKTMSI" Or ds.Tables("data").Rows(0).Item("host_name") = "JANATICSINDIA\HD004MKTGTAMILM" Or ds.Tables("data").Rows(0).Item("host_name") = "JANATICSINDIA\U1002HODMKTSSI" Or ds.Tables("data").Rows(0).Item("host_name") = "U1002HODMKTSSI" Then

        'Else
        '    MsgBox("ORA-00051: You were waiting for a resource and you timed out. Host Name :" & ds.Tables("data").Rows(0).Item("host_name") & "", MsgBoxStyle.Information)
        '    btn_go.Enabled = False
        'End If
    End Sub
End Class