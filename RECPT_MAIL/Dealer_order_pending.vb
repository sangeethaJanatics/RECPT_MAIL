Public Class Dealer_order_pending

    Private Sub Dealer_order_pending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select jan_orgcode(a.ship_from_org_id)org,jan_itemname(inventory_item_id)ordered_item,(select hsn from jan_hsn_tot where inventory_item_id=a.inventory_item_id and organization_id=a.ship_from_org_id)hsn_code,LINE_ID,CUST_ID,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUST_ID)b_CUST_NAME,  REGION,  (SELECT ORDER_NUMBER FROM OE_ORDER_HEADERS_ALL WHERE HEADER_ID=a.HEADER_ID) ORDER_NUMBER,  ORDERED_DATE,  NULL TRX_NUMBER,  TO_DATE(NULL) trx_date,  (SELECT DESCRIPTION FROM FND_FLEX_VALUES_VL  WHERE FLEX_VALUE_SET_ID=1010407 AND FLEX_VALUE=A.ORD_CAT)ORD_CAT,    (ROUND(PENDING_QTY*(UNIT_SELLING_PRICE+NVL(TAX_AMT,0)),2)) PAYMENT_VALUE_WITH_TAX,  (ROUND(PENDING_QTY*(UNIT_SELLING_PRICE),2)) PAYMENT_VALUE_WITHOUT_TAX   from JAN_BMS_ORDER_PEND_V a  where order_type not in (select name from jan_exemp_order_type)"

    End Sub
End Class