Public Class Price_Addition_Detail
    Private Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click

        UseWaitCursor = True


        sql = "select user_name_mode ""Price Added Mode"" ,price_list_Name ""Price List Name "",user_name  ""Price Added By"",count(*)""No of Lines Added""  from (select (select decode(user_Name,'ANONYMOUS','Through Interface','Manual') from fnd_user where user_id=a.last_updated_by)user_name_mode "

        sql &= " ,(select user_Name from fnd_user where user_id=a.last_updated_by)user_name "
        sql &= " ,(select name from qp_list_headers_all where list_header_id=a.list_header_id)price_list_name,a.* from qp_list_lines a  where trunc(creation_date)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and  trunc(creation_date)<='" & Format(To_date.Value, "dd-MMM-yyyy") & "')  group by user_Name,price_list_Name ,user_name_mode order  by user_Name,price_list_Name "
        ds = SQL_SELECT("data", sql)

        dgv1.DataSource = ds.Tables("data")
        UseWaitCursor = False
    End Sub

    Private Sub dgv1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        sql = " select rownum ""Sl.No"",a.* from (SELECT (SELECT NAME FROM qp_list_headers where LIST_HEADER_ID=QPLL.LIST_HEADER_ID )""Price List Name "",jan_itemname(QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID))item_no,OPERAND PRICE,START_DATE_ACTIVE ""Statrt Date"",end_DATE_ACTIVE ""End Date "" FROM QP_LIST_LINES QPLL WHERE  trunc(creation_date)>='" & Format(From_date.Value, "dd-MMM-yyyy") & "' and  list_header_id=(SELECT list_header_id FROM qp_list_headers where name='" & dgv1.CurrentRow.Cells(1).Value & "')  "

        sql &= " and last_updated_by=(select user_id from fnd_user where user_Name='" & dgv1.CurrentRow.Cells(2).Value & "')"
        sql &= "  order  by item_no)a "
        ds = SQL_SELECT("data", sql)
        dgv_brk.DataSource = ds.Tables("data")

    End Sub
End Class