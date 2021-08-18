Public Class Non_TOD_items

    Private Sub view_non_tod_items_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles view_non_tod_items.Click
        sql = " select rownum SL_NO, a.* from (select distinct item_no,description ,min(creation_date)start_date from jan_tod_exempted_items where end_date is null "
        If txt_item_no.Text <> "" Then sql &= " and item_no like trim('" & txt_item_no.Text & "%')"
        sql &= " group by ITEM_NO, DESCRIPTION order by 1)a "
        ds = SQL_SELECT("CUST", sql)
        dgv.DataSource = ds.Tables("CUST")

    End Sub
    Private Sub btn_add_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_item.Click
        If txt_item_no.Text = "" Then
            MessageBox.Show("Enter a item then Add ..!", "Non - TOD item Addition", MessageBoxButtons.OK)

        Else

            sql = " select rownum SL_NO, a.* from (select distinct item_no,description ,min(creation_date)start_date from jan_tod_exempted_items where end_date is null "
            If txt_item_no.Text <> "" Then sql &= " and item_no = trim('" & txt_item_no.Text & "')"
            sql &= " group by ITEM_NO, DESCRIPTION order by 1)a "
            ds = SQL_SELECT("CUST", sql)
            If ds.Tables("CUST").Rows.Count > 0 Then
                MessageBox.Show("Item Already declared as Non-TOD item ..!", "Non - TOD item Addition", MessageBoxButtons.OK)
            Else

                sql = "insert into  jan_tod_exempted_items (item_id,item_no,description,creation_date,remarks) values(jan_itemno('" & txt_item_no.Text & "'),'" & txt_item_no.Text & "',jaN_itemdesc('" & txt_item_no.Text & "'),sysdate,'Added by sales')"
                comand()
                MessageBox.Show("Item No Added ..!", "Non - TOD item Addition", MessageBoxButtons.OK)
            End If


        End If

    End Sub
    Private Sub btn_enable_TOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enable_TOD.Click

        If txt_item_no.Text <> "" Then
            sql = " update jan_tod_exempted_items  set end_date='" & Format(tod_end_date.Value, "dd-MMM-yyyy") & "'   where item_id=jan_itemno('" & txt_item_no.Text & "')  and end_date is null"
            comand()
            MessageBox.Show("TOD Enabled ..!", "Non - TOD item Addition", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Enter a item then Enable TOD ..!", "Non - TOD item Addition", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub btn_view_dealer_sale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_dealer_sale.Click

        sql = "SELECT org,ordered_item,jan_itemdesc(ordered_item)description,count(*)cnt,product_group,level_2,level_5,decode(tod_item,1,'No','Yes')Tod_item_yes_no FROM JAN_DEALER_SALE_2014_15_v where trx_DAte>='" & Format(dealer_sale_from_dt.Value, "dd-MMM-yyyy") & "'  and  trx_DAte<'" & Format(dealer_sale_to_dt.Value, "dd-MMM-yyyy") & "' AND  ORDERED_ITEM NOT IN (SELECT DISTINCT ORDERED_ITEM FROM JAN_DEALER_SALE_2014_15_v WHERE TRX_DATE>'1-OCT-2018' AND  TRX_DATE<'1-JAN-2019') group by  org,ordered_item,product_group,tod_item,level_2,level_5 order by org,ordered_item,product_group "
        ds = SQL_SELECT("CUST", sql)
        dgv.DataSource = ds.Tables("CUST")

    End Sub
End Class