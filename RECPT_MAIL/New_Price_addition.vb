Public Class New_Price_addition

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = " SELECT ROWNUM ""Sl .No"",A.* FROM (SELECT TRUNC(CREATION_DATE)""Creation Date"",(SELECT NAME FROM QP_LIST_HEADERS_ALL WHERE LIST_HEADER_ID=QPLL.LIST_HEADER_ID)""Price List Name"",JAN_ITEMNAME(QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID))""Item No"",OPERAND ""Price"" FROM QP_LIST_LINES QPLL WHERE TRUNC(CREATION_DATE)='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' order by  ""Price List Name"",""Item No"")A"

        ds1 = SQL_SELECT("REG", sql)
        dgv.DataSource = ds.Tables("REG")
    End Sub
End Class