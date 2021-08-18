Public Class Branch_Price_Rev_editing
    Private Sub Branch_Price_Rev_editing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "select  'ALL' region from dual union SELECT distinct region FROM jan_customer_price_rev_master WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1 ) order by region"
        ds = SQL_SELECT("REGION", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.DisplayMember = "region"


    End Sub

    Private Sub btn_view_price_Click(sender As Object, e As EventArgs) Handles btn_view_price.Click
        sql = "SELECT bill_to customer_name,region,item_no,pricelist,current_clp,new_clp FROM jan_customer_price_rev_master WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1) "
        If cmb_region.Text <> "ALL" Then sql &= " AND REGION='" & cmb_region.Text & "' "
        If cmb_cust_name.Text <> "" Then sql &= " AND BILL_TO='" & cmb_cust_name.Text.ToString.Replace("'", "''") & "' "
        If txt_item_no.Text <> "" Then sql &= " AND ITEM_NO=trim('" & txt_item_no.Text & "')"
        sql &= " order by region,customer_name,item_no"
        ds = SQL_SELECT("items", sql)
        dgv1.DataSource = ds.Tables("items")

    End Sub

    Private Sub cmb_region_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_region.SelectedIndexChanged
        sql = "SELECT distinct bill_to customer_name FROM jan_customer_price_rev_master WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1)  and region='" & cmb_region.Text & "' order by customer_name"
        ds = SQL_SELECT("cust", sql)
        cmb_cust_name.DataSource = ds.Tables("cust")
        cmb_cust_name.DisplayMember = "customer_name"

    End Sub
    Private Sub btn_update_price_Click(sender As Object, e As EventArgs) Handles btn_update_price.Click
        If txt_new_clp.Text <> "" Then

            sql = " update  jan_customer_price_rev_master set new_clp=" & txt_new_clp.Text & " WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1)  " ' and region='" & cmb_region.Text & "' order by customer_name"

            If cmb_region.Text <> "ALL" Then sql &= " AND REGION='" & cmb_region.Text & "' "
            If cmb_cust_name.Text <> "" Then sql &= " AND BILL_TO='" & cmb_cust_name.Text.ToString.Replace("'", "''") & "' "
            sql &= " AND ITEM_NO=trim('" & txt_item_no.Text & "')"
            comand()
            txt_new_clp.Text = ""

            MessageBox.Show("New CLP updated", "Branch Price updation", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Please Enter New CLP ....!", "Branch Price updation", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btn_delete_item_Click(sender As Object, e As EventArgs) Handles btn_delete_item.Click
        If txt_item_no.Text <> "" Then

            sql = " delete from   jan_customer_price_rev_master WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1)  "

            If cmb_region.Text <> "ALL" Then sql &= " AND REGION='" & cmb_region.Text & "' "
            If cmb_cust_name.Text <> "" Then sql &= " AND BILL_TO='" & cmb_cust_name.Text.ToString.Replace("'", "''") & "' "
            If txt_item_no.Text <> "" Then sql &= " AND ITEM_NO=trim('" & txt_item_no.Text & "')"
            comand()
            MessageBox.Show("Item No deleted", "Branch Price updation", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Please Enter Item No to Detete ....!", "Branch Price updation", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub btn_delete_customer_Click(sender As Object, e As EventArgs) Handles btn_delete_customer.Click
        If cmb_cust_name.Text <> "" Then

            sql = " delete from   jan_customer_price_rev_master WHERE FMLA_ID=(SELECT max(FMLA_ID) FROM JAN_PRICE_REV_FMLA_HEADER WHERE LIVE_FLAG=1)  "

            If cmb_region.Text <> "ALL" Then sql &= " AND REGION='" & cmb_region.Text & "' "
            If cmb_cust_name.Text <> "" Then sql &= " AND BILL_TO='" & cmb_cust_name.Text.ToString.Replace("'", "''") & "' "
            comand()
            MessageBox.Show("Customer Detail deleted", "Branch Price updation", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Please select Customer Name to Detete ....!", "Branch Price updation", MessageBoxButtons.OK)
        End If
    End Sub
End Class