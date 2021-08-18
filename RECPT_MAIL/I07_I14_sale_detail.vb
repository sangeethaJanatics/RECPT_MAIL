Public Class I07_I14_sale_detail
    Private Sub I07_I14_sale_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click

        sql = "select sys_context('USERENV','IP_ADDRESS')ip from dual"
        ds = SQL_SELECT("data", sql)
        If ds.Tables("data").Rows(0).Item("ip") = "192.168.23.60" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.17.13" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.17.13" Or ds.Tables("data").Rows(0).Item("ip") = "192.168.17.136" Then



            sql = "SELECT JAN_ORGCODE(ORGANIZATION_ID)""Org"",ORDERED_ITEM ""Item No"",JAN_ITEMDESC(ORDERED_ITEM)""Description"",ORDER_NUMBER ""Order No"",ORDERED_DATE""Order Date"",TRX_NUMBER ""Invoice No"",TRX_DATE ""Inv Date"",BILL_TO_CUST_NAME ""Customer Name"",REGION ""Region"",SUM(QUANTITY_INVOICED)Sale_Qty,SUM(QUANTITY_INVOICED*UNIT_SELLING_PRICE)Sale_Value,my ""Month/Year"" FROM JAN_SALES_ANY_1_COPY WHERE TRX_DATE>='" & Format(DateTimePicker_from.Value, "dd-MMM-yyyy") & "' AND  TRX_DATE<='" & Format(DateTimePicker_to.Value, "dd-MMM-yyyy") & "' "

            If txt_item.Text <> "" Then sql &= " and ORDERED_ITEM='" & txt_item.Text & "' "
            sql &= " And ORGANIZATION_ID IN (304,111) GROUP BY ORGANIZATION_ID,ORDERED_ITEM,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER ,TRX_DATE ,BILL_TO_CUST_NAME,REGION,my order by TRX_DATE ,TRX_NUMBER ,BILL_TO_CUST_NAME,REGION,ORGANIZATION_ID,ORDERED_ITEM"
            ds = SQL_SELECT("data", sql)

            With ds.Tables("data")
                .Rows.Add("Total")
                .Rows(.Rows.Count - 1).Item("Sale_Value") = .Compute("sum(Sale_Value)", "Sale_Value>=0")
                .Rows(.Rows.Count - 1).Item("Sale_Qty") = .Compute("sum(Sale_Qty)", "Sale_Qty>=0")
            End With
            With dgv1
                .DataSource = ds.Tables("data")
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            MessageBox.Show("Some Error Occured , Kindly Contact EDP", "I07 and I14 Sale ", MessageBoxButtons.OK)
        End If
    End Sub
End Class