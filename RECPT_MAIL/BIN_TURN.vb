Public Class BIN_TURN

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        'sql = "SELECT * FROM jan_customer_replenishment_v where customer_id=" & cmb_cust.SelectedValue & ""
        Cursor = Cursors.WaitCursor

        sql = "SELECT B.*,ROUND(AVG_QTY/(ROQ+ROL+fc_qty),2)""No of Turns"" FROM ("
        sql &= "SELECT CUSTOMER_NAME ""Customer Name"",ORG ""Org"",ITEM_NO ""Item NO"",DESCRIPTION ""Description"",nvl(ROQ,0) ""ROQ"",nvl(ROL,0) ""ROL"",nvl(FC_QTY,0)FC_QTY  "
        sql &= ",NVL((SELECT  SUM(QUANTITY_INVOICED) FROM JAN_SALES_ANY_1_COPY WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID and DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and MY='042016' and SHIP_TO_SITE=a.SITE),0)""Sale Qty Apr2016"""
        sql &= ",NVL((SELECT  SUM(QUANTITY_INVOICED) FROM JAN_SALES_ANY_1_COPY WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID and DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and MY='052016' and SHIP_TO_SITE=a.SITE),0)""Sale Qty May2016"""

        sql &= ",NVL((SELECT  SUM(QUANTITY_INVOICED) FROM JAN_SALES_ANY_1_COPY WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID and DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and MY='062016' and SHIP_TO_SITE=a.SITE),0)""Sale Qty Jun2016"""

        sql &= ",NVL((SELECT  SUM(QUANTITY_INVOICED) FROM JAN_SALES_ANY_1_COPY WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID and DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and MY='072016' and SHIP_TO_SITE=a.SITE),0)""Sale Qty Jul2016"""

        sql &= ",ROUND(NVL((SELECT  SUM(QUANTITY_INVOICED) FROM JAN_SALES_ANY_1_COPY WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID and DECODE(ORGANIZATION_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORGANIZATION_ID)=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and TRX_DATE>=(select F_DT_CYR from JAN_SALES_BI_SETUP) and TRX_DATE<TRUNC(sysdate,'MM')and SHIP_TO_SITE=a.SITE),0)/(MONTHS_BETWEEN(TRUNC(sysdate,'MM'),(select F_DT_CYR from JAN_SALES_BI_SETUP) )))AVG_QTY"
        sql &= " from jan_customer_replenishment_v A  where customer_id=" & cmb_cust.SelectedValue & ")B ORDER BY ""Org"",""Item NO"""
        ds = SQL_SELECT("data", sql)
        Cursor = Cursors.Default

        With dgv1
            .DataSource = ds.Tables("data")
            For i = 4 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Next
            .Columns(1).Width = "40"
        End With

    End Sub

    Private Sub BIN_TURN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sql="select customer_name from ra_customers where region='"& & "'"

        sql = "select distinct segment14 region from ra_territories where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA')"

        ds = SQL_SELECT("reg", sql)
        cmb_region.DataSource = ds.Tables("reg")
        cmb_region.DisplayMember = "region"

    End Sub
    Private Sub cmb_region_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_region.SelectedIndexChanged

        sql = "select A.*,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID)CUSTOMER_NAME from jan_bms_bill_to_v A  where TER_NAME='" & cmb_region.Text & "' ORDER BY CUSTOMER_NAME"

        ds = SQL_SELECT("CUST", sql)
        cmb_cust.DataSource = ds.Tables("CUST")
        cmb_cust.DisplayMember = "CUSTOMER_NAME"
        cmb_cust.ValueMember = "CUSTOMER_ID"

    End Sub
End Class