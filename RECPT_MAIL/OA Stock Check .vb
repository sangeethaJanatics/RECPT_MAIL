Public Class OA_Stock_Check

    Private Sub OA_Stock_Check_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If txt_oa.Text = "" Then
            MessageBox.Show("Enter OA  No  then press Go", "Stock checking", MessageBoxButtons.OK)
            Exit Sub

        End If


        'select sum(TRANSACTION_QUANTITY) from mtl_onhand_quantities where SUBINVENTORY_CODE='Staging'

        sql = "select item_no ""Item No"",org,NEW_ORDERED_QUANTITY,AVAILABLE_ONHAND ,STAGING_QTY from (select jan_itemname(inventory_item_id)item_no,jan_orgcode(organization_id)org,D.*,JAN_IT.JAN_CHECK_POSITIVE(D.ON_HAND-D.PEND_ORD_QTY) AVAILABLE_ONHAND,NVL((select sum(TRANSACTION_QUANTITY) from mtl_onhand_quantities where organization_id=D.organization_id AND inventory_item_id=D.inventory_item_id AND SUBINVENTORY_CODE='Staging'  ),0)STAGING_QTY FROM (select a.INVENTORY_ITEM_ID,a.ON_HAND,a.ORGANIZATION_ID,NVL((SELECT SUM(PEND_QTY-PICKED_QTY) FROM  JAN_BMS_ORDER_PENDING_NEW_V WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID and SHIP_FROM_ORG_ID=a.ORGANIZATION_ID and FLOW_STATUS_CODE not in ('CLOSED','CANCELLED') and HEADER_ID <>(select header_id from oe_order_headers_all where order_number='" & txt_oa.Text & "')),0) PEND_ORD_QTY,(SELECT SUM(ORDERED_QUANTITY) FROM OE_ORDER_LINES_ALL OL WHERE OL.INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID and OL.SHIP_FROM_ORG_ID=A.ORGANIZATION_ID AND OL.HEADER_ID=(select header_id from oe_order_headers_all where order_number='" & txt_oa.Text & "')) NEW_ORDERED_QUANTITY from JAN_FG_ONHAND_QUANTITIES a WHERE ORGANIZATION_ID IN (SELECT PC.ORG_ID FROM JAN_IT.JAN_ORG_PROD_STATUS PC) AND (INVENTORY_ITEM_ID,ORGANIZATION_ID) IN (SELECT INVENTORY_ITEM_ID,SHIP_FROM_ORG_ID FROM OE_ORDER_LINES_ALL WHERE HEADER_ID=(SELECT HEADER_ID FROM OE_ORDER_HEADERS_ALL WHERE ORDER_NUMBER='" & txt_oa.Text & "')))D) order by org,item_no"


        ds = SQL_SELECT("org", sql)
        dgv1.DataSource = ds.Tables("org")

        For i = 0 To dgv1.RowCount - 1
            dgv1.Columns("AVAILABLE_ONHAND").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgv1.Columns("NEW_ORDERED_QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgv1.Columns("STAGING_QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            With dgv1.Rows(i)

                If .Cells("AVAILABLE_ONHAND").Value < .Cells("NEW_ORDERED_QUANTITY").Value Then
                    .DefaultCellStyle.BackColor = Color.Red
                End If
            End With
        Next

        dgv1.Columns("AVAILABLE_ONHAND").HeaderText = "AVAILABLE ONHAND AT HO"

        dgv1.Columns("NEW_ORDERED_QUANTITY").HeaderText = "NEW ORDERED QUANTITY "
        dgv1.Columns("STAGING_QTY").HeaderText = "STAGING QUANTITY "

    End Sub
End Class