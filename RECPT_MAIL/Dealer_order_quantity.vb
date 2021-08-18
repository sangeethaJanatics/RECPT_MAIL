Public Class Dealer_order_quantity

    Private Sub Dealer_order_quantity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select distinct qtr_id,case when qtr_id=20151601 then 'Qtr1'  when qtr_id=20151602 then 'Qtr2' when qtr_id=20151603 then 'Qtr3' when qtr_id=20151604 then 'Qtr4' end qtr from jan_tod_master_table1 where order_from_date>='1-apr-2015'"

        ds = SQL_SELECT("qtr", sql)
        cmb_qtr.DataSource = ds.Tables("qtr")
        cmb_qtr.DisplayMember = "qtr"
        cmb_qtr.ValueMember = "qtr_id"

        sql = "select customer_id,customer_name from ra_customers where customer_class_code='DEALER'  order by customer_name"

        ds = SQL_SELECT("cust", sql)
        cmb_dealer.DataSource = ds.Tables("cust")
        cmb_dealer.DisplayMember = "customer_name"
        cmb_dealer.ValueMember = "customer_id"

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        sql = "select customer_name""Dealer Name"",qtr_id ""Qtr Id"",org ""Org"",product_group ""Product Group"",ORDERED_QUANTITY ""Order Qty"" from (SELECT A.* ,NVL((SELECT GROUP_ORD FROM JAN_DEALER_TARGET_PROD_GROUP WHERE GROUP_NAME=a.PRODUCT_GROUP AND ROWNUM=1),60)PROD_GROUP_ORD from (SELECT CUSTOMER_NAME,QTR_ID_NEW QTR_ID,ORG,PRODUCT_GROUP,SUM(ORDERED_QUANTITY)ORDERED_QUANTITY  FROM JAN_DEALER_ORDER_201516_V  where qtr_id_new='" & cmb_qtr.SelectedValue & "' and customer_id=" & cmb_dealer.SelectedValue & " GROUP BY CUSTOMER_NAME, QTR_ID_NEW, ORG, PRODUCT_GROUP )a) order by org,PROD_GROUP_ORD"

        ds = SQL_SELECT("data", sql)

        With dgv_head
            .DataSource = ds.Tables("data")
            .Columns(0).Width = 300
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With


    End Sub

    Private Sub dgv_head_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_head.CellClick
        sql = "select ORDER_NUMBER ""Order No"",trunc(ORDERED_DATE)""Order Date"",ORG ""Org"",ORDERED_ITEM ""Item No"",ORDERED_QUANTITY ,PRODUCT_GROUP ""Product Group""  FROM JAN_DEALER_ORDER_201516_V  where qtr_id_new='" & cmb_qtr.SelectedValue & "' and customer_id=" & cmb_dealer.SelectedValue & "  and  PRODUCT_GROUP ='" & dgv_head.CurrentRow.Cells(3).Value & "' order by order_number,ordered_item "

        ds = SQL_SELECT("data", sql)
        With ds.Tables("data")
            .Rows.Add()
            .Rows(.Rows.Count - 1).Item("ORDERED_QUANTITY") = .Compute("sum(ORDERED_QUANTITY)", "ORDERED_QUANTITY>0")
        End With

        With dgv_brk
            .DataSource = ds.Tables("data")
            .Columns(0).Width = 300
            .Columns("ORDERED_QUANTITY").HeaderText = "Order Qty"
          
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With
    End Sub
End Class