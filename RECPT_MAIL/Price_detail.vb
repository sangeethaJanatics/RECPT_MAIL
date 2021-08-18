Public Class Price_detail
    Dim sql As String

    Private Sub btn_view_price_Click(sender As Object, e As EventArgs) Handles btn_view_price.Click
        Cursor.Current = Cursors.WaitCursor
        If txt_part_no.Text = "" And cmb_price_list_name.Text = "" Then
            MessageBox.Show("Search price for a PriceList or for a item .. ", " Price Visibility", MessageBoxButtons.OK)
        Else


            sql = "select b.*,round(price_in_CLP02_CS_NEW_PROD*1.0475)dlp from ( SELECT price_list_Name,jan_itemname(inventory_item_id)item_no,jan_itemdesc(jan_itemname(inventory_item_id))description,price,START_DATE_ACTIVE,END_DATE_ACTIVE,JAN_SALES_RRS_CATEGORY2(inventory_item_id)rrs_cat "

            sql &= " ,(select PRICE_IN_CLP02_ccs_new_prod from jan_c_cs_clp02_ord_interface_v where inventory_item_id=a.inventory_item_id)price_in_CLP02_CS_NEW_PROD "
            sql &= " FROM (SELECT (SELECT NAME FROM qp_list_headers where LIST_HEADER_ID=QPLL.LIST_HEADER_ID )PRICE_LIST_NAME,LIST_HEADER_ID,OPERAND PRICE,QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID)inventory_item_id,START_DATE_ACTIVE ,QPLL.END_DATE_ACTIVE,qpll.list_line_id FROM QP_LIST_LINES QPLL WHERE  1=1  "
            If cmb_price_list_name.Text <> "" Then sql &= " And LIST_HEADER_ID =(select list_header_id from qp_list_headers where name='" & cmb_price_list_name.Text & "')  "
            If chk_date.Checked = True Then
                sql &= " AND trunc(START_DATE_ACTIVE)>='" & Format(from_dt.Value, "dd-MMM-yyyy") & "'"
                sql &= " AND trunc(START_DATE_ACTIVE)<='" & Format(to_dt.Value, "dd-MMM-yyyy") & "'"
            End If
            If txt_part_no.Text <> "" Then sql &= " And QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID)=jan_itemno('" & txt_part_no.Text & "') "
            sql &= " And TRUNC(SYSDATE) BETWEEN TRUNC(QPLL.START_DATE_ACTIVE) And TRUNC(NVL(QPLl.END_DATE_ACTIVE,SYSDATE)))a order by 1,2 )b"

            ds = SQL_SELECT("data", sql)
            If ds.Tables("data").Rows.Count = 0 Then
                MessageBox.Show("There is no actice Price  .. ", " Price Visibility", MessageBoxButtons.OK)
                Exit Sub
            End If
            With dgv1
                .DataSource = ds.Tables("data")
                .Columns(0).Width = 300
                .Columns(7).Width = 280
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Price_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "select Name, list_header_id from qp_list_headers where list_type_code='PRL' and end_date_active is null order by name"
        ds = SQL_SELECT("prl", sql)

        cmb_price_list_name.DisplayMember = "name"
        cmb_price_list_name.ValueMember = "list_header_id"
        cmb_price_list_name.DataSource = ds.Tables("prl")
    End Sub
End Class