Public Class create_dsp_schedule

    Private Sub create_dsp_schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If txt_order_id.Text <> "" Then

            sql = " DECLARE BEGIN JAN_UPDATE_WEB_ORDER_COLUMNS(" & txt_order_id.Text & "); END;"
            comand()

            sql = " DECLARE BEGIN JAN_DMS_WEB_ORDER_SCHEDULES2(" & txt_order_id.Text & "); END;"
            comand()

            MessageBox.Show("Schedule Created  ..!")
            txt_order_id.Text = ""
        Else
            MessageBox.Show("Give Order id then create schedule", "DSP Schedule Creation", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub btn_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_change.Click

        sql = "update OE_DMS_ORDER_HEADERS_ALL set OE_ORDER_REF_NO=OE_ORDER_REF_NO ||'/2',OE_PO_NO=OE_PO_NO||'/2' where OE_ORDER_ONLINE_ID=" & txt_order_id.Text & " and OE_ORDER_REF_NO not like '%/2'"
        comand()
    End Sub
End Class