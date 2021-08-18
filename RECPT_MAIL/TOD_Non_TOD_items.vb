Public Class TOD_Non_TOD_items
    Private Sub but_go_Click(sender As Object, e As EventArgs) Handles but_go.Click


        sql = "SELECT org,ordered_item,jan_itemdesc(ordered_item)description,count(*)cnt,product_group,level_2,level_5,decode(tod_item,1,'No','Yes')Tod_item_yes_no FROM JAN_DEALER_SALE_2014_15_v where trx_DAte>='" & Format(DateTime_From.Value, "dd-MMM-yyyy") & "'  and  trx_DAte<='" & Format(DateTime_to.Value, "dd-MMM-yyyy") & "' group by  org,ordered_item,product_group,tod_item,level_2,level_5 order  by org,ordered_item "
        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")


    End Sub
End Class