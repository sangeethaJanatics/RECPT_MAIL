Public Class Non_moving_item_stock

    Private Sub Non_moving_item_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        sql = "select a.* , NVL((select SUM(TRANSACTION_QUANTITY) from  MTL_ONHAND_QUANTITIES  where INVENTORY_ITEM_ID=JAN_ITEMNO(a.ITEM_NO) and  ORGANIZATION_ID=JAN_ORGID(a.ORG) and SUBINVENTORY_CODE=a.SUBINVENTORY_CODE),0) ""Current Onhand"", NVL((select SUM(ordered_QUANTITY-nvl(shipped_quantity,0)) from  jan_sales_any_tb2_1  where ORGANIZATION_ID=JAN_ORGID(a.ORG) and INVENTORY_ITEM_ID=JAN_ITEMNO(a.ITEM_NO) ),0) ""Total Order Pending"" "

        sql &= " ,NVL((select SUM(ROQ+ROL) from  JAN_CUSTOMER_REPLENISHMENT_V  where INVENTORY_ITEM_ID=JAN_ITEMNO(a.ITEM_NO) AND  ORGANIZATION_ID=JAN_ORGID(a.ORG)),0) ""Bin Qty"""
        sql &= "  from JAN_FG_NON_MOVE_06JAN2016 a  order by org,item_no"
        ds = SQL_SELECT("CUST", sql)

        dgv.DataSource = ds.Tables("CUST")
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Private Sub Non_moving_item_stock_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
End Class