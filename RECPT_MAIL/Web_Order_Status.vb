Imports System.Data.OracleClient
Public Class Web_Order_Status
    Dim ora_adap As New OracleDataAdapter
    Dim ora_con As New Odbc.OdbcConnection("Driver=Microsoft ODBC for oracle;uid=jan_it;pwd=janapps;server=PROD")
    Dim dms_adap As New OleDb.OleDbDataAdapter
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim ds As New DataSet
    Dim drw(), drw2() As DataRow

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        display_result()
    End Sub
    Private Sub Web_Order_Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt_from.Value = Date.Today.AddDays(-5)
        display_result()
    End Sub
    Private Sub display_result()
        'sql
        sql = "select oe_order_online_id,approved_date,oe_bill_to_name,"
        sql &= " (select count(*) from oe_dms_order_lines_all where oe_dms_order_header_id=a.oe_order_online_id)web_item_count,''oracle_item_count "

        sql &= " ,(select sum(oe_order_qty) from oe_dms_order_lines_all where oe_dms_order_header_id=a.oe_order_online_id)sql_ord_qty"

        sql &= ",''oracle_ord_qty,''download_status from oe_dms_order_headers_all a where status='Approved' and approved_date>='" & Format(dt_from.Value, "dd-MMM-yyyy") & "' and approved_date<='" & Format(dt_to.Value, "dd-MMM-yyyy") & "'  order by oe_order_online_id"
        dms_adap = New OleDb.OleDbDataAdapter(sql, dms_con)
        ds = New DataSet
        dms_adap.Fill(ds, "sql")


        'oracle
        sql = "select oe_order_online_id,oe_bill_to_name,"
        sql &= " (select count(*) from oe_dms_order_lines_all where oe_dms_order_header_id=a.oe_order_online_id)oracle_item_count"

        sql &= " ,(select sum(oe_order_qty) from oe_dms_order_lines_all where oe_dms_order_header_id=a.oe_order_online_id)oracle_ord_qty"

        sql &= ",''oracle_item_count,''download_status from oe_dms_order_headers_all a where status='Approved' and approved_date>='" & Format(dt_from.Value, "dd-MMM-yyyy") & "' and approved_date<='" & Format(dt_to.Value, "dd-MMM-yyyy") & "'   order by oe_order_online_id"
        'ora_adap = New OracleDataAdapter(sql, ora_con)

        ora_adap.Fill(ds, "oracle")

        For i = 0 To ds.Tables("sql").Rows.Count - 1
            With ds.Tables("sql").Rows(i)
                drw = ds.Tables("oracle").Select("oe_order_online_id='" & .Item("oe_order_online_id") & "'")
                If drw.GetLength(0) = 1 Then
                    .Item("oracle_item_count") = drw(0).Item("oracle_item_count")
                    .Item("oracle_ord_qty") = drw(0).Item("oracle_ord_qty")
                End If
            End With
        Next
        ds.Tables("sql").AcceptChanges()

        With dgv1
            .DataSource = ds.Tables("sql")

            'For i = 0 To .RowCount - 1
            '    If .Rows(i).Cells("oracle_item_count").Value.ToString <> .Rows(i).Cells("web_item_count").Value.ToString Then
            '        .Rows(i).Cells("download_status").Style.BackColor = Color.Red
            '    Else
            '        .Rows(i).Cells("download_status").Style.BackColor = Color.YellowGreen
            '    End If

            'Next
            .Columns("approved_date").HeaderText = "Approved Date"
            .Columns("oe_bill_to_name").HeaderText = "Customer Name"
            .Columns("oe_bill_to_name").Width = 270
            .Columns("oe_order_online_id").HeaderText = "Web Order Id"
            .Columns("web_item_count").HeaderText = "Web Item Count"
            .Columns("web_item_count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns("oracle_item_count").HeaderText = "Oracle Item Count"
            .Columns("oracle_item_count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("oracle_ord_qty").HeaderText = "Oracle Order Qty"
            .Columns("oracle_ord_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("sql_ord_qty").HeaderText = "sql  Order Qty"
            .Columns("sql_ord_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("download_status").HeaderText = "Download Status"
        End With
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting

        For i = 0 To dgv1.Rows.Count - 1
            If e.RowIndex > 0 Then
                'If dgv1.Rows(i).Cells("oracle_item_count").Value.ToString = dgv1.Rows(i).Cells("web_item_count").Value.ToString Then
                '    dgv1.Rows(i).Cells("download_status").Style.BackColor = Color.YellowGreen
                'Else
                '    dgv1.Rows(i).Cells("download_status").Style.BackColor = Color.Red
                'End If

                If dgv1.Rows(i).Cells("oracle_ord_qty").Value.ToString = dgv1.Rows(i).Cells("sql_ord_qty").Value.ToString Then
                    dgv1.Rows(i).Cells("download_status").Style.BackColor = Color.YellowGreen

                Else
                    dgv1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    dgv1.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            End If
        Next

    End Sub
End Class