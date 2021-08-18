Public Class GST_OA_Interface

    Private Sub btn_reallocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reallocate.Click

        If txt_Old_oa_no.Text <> "" Then
            sql = " DECLARE BEGIN JAN_ORDER_RSV_MIGRATE('" & txt_Old_oa_no.Text & "') ; END;"
            comand()
            If z = 0 Then
                MessageBox.Show("GST OA Interface --Reservation Not Initiated ", "Reservation Sattus", MessageBoxButtons.OK)
            Else
                MessageBox.Show("GST OA Interface --Reservation Initiated ", "Reservation Sattus", MessageBoxButtons.OK)
            End If

        Else
            MessageBox.Show("Enter the old OA No then Migrate Rexervation", "OA   No '" & txt_Old_oa_no.Text & "' Cancelled", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub BTN_CHECK_OLD_RSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CHECK_OLD_RSV.Click

        If txt_Old_oa_no.Text <> "" Then
            sql = "select order_number,ordered_item,jan_orgcode(ship_from_org_id)org,ordered_quantity,pend_qty,rsv_qty,FLOW_STATUS_CODE  from jan_bms_order_pending_new_v where order_number='" & txt_Old_oa_no.Text & "' AND FLOW_STATUS_CODE IN ('CANCELLED','AWAITING_SHIPPING') "

            ds = SQL_SELECT("org", sql)
            DGV_OLD_RSV.DataSource = ds.Tables("org")

            sql = "select cust_name,order_number,ordered_item,jan_orgcode(ship_from_org_id)org,ordered_quantity,pend_qty,rsv_qty ,FLOW_STATUS_CODE from jan_bms_order_pending_new_v where order_number='" & txt_new_oa.Text & "'"

            ds = SQL_SELECT("org", sql)
            Dgv_new_oa.DataSource = ds.Tables("org")
        Else
            MessageBox.Show("Enter the old OA No then Check the Status", "OA   No '" & txt_Old_oa_no.Text & "' Cancelled", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub btn_check_rsv_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_check_rsv_interface.Click
        sql = "select cust_name,order_number,ordered_item,jan_orgcode(ship_from_org_id)org,ordered_quantity,pend_qty,rsv_qty from jan_bms_order_pending_new_v where order_number='" & txt_Old_oa_no.Text & "'"
        sql = "select * from MTL_RESERVATIONS_INTERFACE where DEMAND_SOURCE_LINE_ID in (select line_id from jan_bms_order_pending_new_v where order_number='" & txt_new_oa.Text & "')"

        ds = SQL_SELECT("org", sql)
        dgv_rsv_interface.DataSource = ds.Tables("org")
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If txt_Old_oa_no.Text <> "" Then
            sql = " DECLARE BEGIN JAN_ORDER_RSV_MIGRATE_cancel('" & txt_Old_oa_no.Text & "') ; END;"
            comand()
            If z = 0 Then
                MessageBox.Show("Old OA Not Cancelled ", "OA   No '" & txt_Old_oa_no.Text & "' Cancellation", MessageBoxButtons.OK)
            Else
                MessageBox.Show("GST OA Interface --Old OA Cancelled ", "OA   No '" & txt_Old_oa_no.Text & "' Cancelled", MessageBoxButtons.OK)
            End If

            'MessageBox.Show("GST OA Interface --Old OA Cancelled ", "OA   No '" & txt_Old_oa_no.Text & "' Cancelled", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Enter the old OA No then Cancel", "OA   No '" & txt_Old_oa_no.Text & "' Cancelled", MessageBoxButtons.OK)
        End If


    End Sub
    'Private Sub btn_new_oa_status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_oa_status.Click
    '    sql = "select cust_name,order_number,ordered_item,jan_orgcode(ship_from_org_id)org,ordered_quantity,pend_qty,rsv_qty from jan_bms_order_pending_new_v where order_number='" & txt_new_oa.Text & "'"

    '    ds = SQL_SELECT("org", sql)
    '    Dgv_new_oa.DataSource = ds.Tables("org")
    'End Sub

    Private Sub GST_OA_Interface_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        GST_OA_Rsv_Login.Close()
    End Sub
End Class