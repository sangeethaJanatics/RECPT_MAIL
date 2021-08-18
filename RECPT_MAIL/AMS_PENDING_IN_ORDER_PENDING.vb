Public Class AMS_PENDING_IN_ORDER_PENDING

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        dgv1_Dealer.Columns.Clear()
        If rad_customer.Checked = True Then

            sql = "SELECT  REGION,CUSTOMER_NAME,ORDERED_ITEM,SUM(RSV_BY_AMS)RSV_BY_AMS_QTY,SUM(RSV_BY_AMS*UNIT_SELLING_PRICE)RSV_BY_AMS_VAL,ORDER_FF_DT,TO_CHAR(ORDER_FF_DT,'IYYYIW')OFD_WK FROM JAN_ORDER_PEND_STATUS2_TAB WHERE RSV_BY_AMS>0 AND CUSTOMER_nAME IN (SELECT CUSTOMER_nAME FROM RA_CUSTOMERS WHERE CUSTOMER_CLASS_CODE<>'DEALER') "


            sql &= " and TO_CHAR(ORDER_FF_DT,'IYYYIW') "
            If chk_ofd.Checked = True Then sql &= "<=" Else sql &= "="
            sql &= " '" & cmb_ofd.Text & "'"
            If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "' "

            If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno(trim('" & txt_item_no.Text & "'))"

            sql &= " GROUP BY REGION,CUSTOMER_NAME,ORDERED_ITEM,ORDER_FF_DT,TO_CHAR(ORDER_FF_DT,'IYYYIW')"

            sql &= " order by REGION,OFD_WK,CUSTOMER_NAME,ORDER_FF_DT,ORDERED_ITEM "

        ElseIf rad_Dealer.Checked = True Then

            sql = "SELECT  REGION,CUSTOMER_NAME,ORDERED_ITEM,SUM(RSV_BY_AMS)RSV_BY_AMS_QTY,SUM(RSV_BY_AMS*UNIT_SELLING_PRICE)RSV_BY_AMS_VAL,ORDER_FF_DT,TO_CHAR(ORDER_FF_DT,'IYYYIW')OFD_WK FROM JAN_ORDER_PEND_STATUS2_TAB WHERE RSV_BY_AMS>0 AND CUSTOMER_nAME IN (SELECT CUSTOMER_nAME FROM RA_CUSTOMERS WHERE CUSTOMER_CLASS_CODE='DEALER') "

            sql &= " and TO_CHAR(ORDER_FF_DT,'IYYYIW') "
            If chk_ofd.Checked = True Then sql &= "<=" Else sql &= "="
            sql &= " '" & cmb_ofd.Text & "'"
            If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "' "
            If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno(trim('" & txt_item_no.Text & "'))"

            sql &= " GROUP BY REGION,CUSTOMER_NAME,ORDERED_ITEM,ORDER_FF_DT,TO_CHAR(ORDER_FF_DT,'IYYYIW')"

            sql &= " order by REGION,OFD_WK,CUSTOMER_NAME,ORDER_FF_DT,ORDERED_ITEM "


        ElseIf rad_consolidation.Checked = True Then

            sql = "SELECT  REGION,CUSTOMER_NAME,SUM(CASE WHEN ORGANIZATION_ID=524 THEN  RSV_BY_AMS ELSE 0 END )i21_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=524 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i21_RSV_BY_AMS_VAL,SUM(CASE WHEN ORGANIZATION_ID=464 THEN  RSV_BY_AMS ELSE 0 END )i22_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=464 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i22_RSV_BY_AMS_VAL,SUM(CASE WHEN ORGANIZATION_ID=444 THEN  RSV_BY_AMS ELSE 0 END )i23_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=444 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i23_RSV_BY_AMS_VAL,SUM(CASE WHEN ORGANIZATION_ID=504 THEN  RSV_BY_AMS ELSE 0 END )i24_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=504 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i24_RSV_BY_AMS_VAL,SUM(CASE WHEN ORGANIZATION_ID=484 THEN  RSV_BY_AMS ELSE 0 END )i25_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=484 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i25_RSV_BY_AMS_VAL,SUM(CASE WHEN ORGANIZATION_ID=505 THEN  RSV_BY_AMS ELSE 0 END )i26_RSV_BY_AMS_QTY,SUM(CASE WHEN ORGANIZATION_ID=505 THEN  (RSV_BY_AMS*UNIT_SELLING_PRICE) ELSE 0 END )i26_RSV_BY_AMS_VAL,SUM(cASE WHEN ORGANIZATION_ID not in (524,464,444,504,484,505) THEN RSV_BY_AMS end )other_org_AMS_qty ,SUM(cASE WHEN ORGANIZATION_ID not in (524,464,444,504,484,505) THEN (RSV_BY_AMS*UNIT_SELLING_PRICE) end )other_org_AMS_VAL FROM JAN_ORDER_PEND_STATUS2_TAB WHERE RSV_BY_AMS>0 AND CUSTOMER_nAME IN (SELECT CUSTOMER_nAME FROM RA_CUSTOMERS WHERE CUSTOMER_CLASS_CODE='DEALER') "
            sql &= " and TO_CHAR(ORDER_FF_DT,'IYYYIW') "
            If chk_ofd.Checked = True Then sql &= "<=" Else sql &= "="
            sql &= " '" & cmb_ofd.Text & "'"

            If cmb_region.Text <> "" Then sql &= " and region='" & cmb_region.Text & "' "

            If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno(trim('" & txt_item_no.Text & "'))"


            sql &= " GROUP BY REGION,CUSTOMER_NAME,ORDERED_ITEM "
            sql &= " order by REGION,CUSTOMER_NAME "
        End If

        ds = SQL_SELECT("data", sql)
        With dgv1_Dealer
            .DataSource = ds.Tables("data")
            .Columns(2).Frozen = True
            .Columns(0).HeaderText = "Region"
            .Columns(1).HeaderText = "Customer Name"
            If rad_consolidation.Checked <> True Then .Columns(2).HeaderText = "Item No"
            If rad_consolidation.Checked = True Then
                .Columns(2).HeaderText = "I21 AMS Qty"

                .Columns(3).HeaderText = "I21 AMS Value"
                .Columns(3).DefaultCellStyle.Format = "00.00"

                .Columns(4).HeaderText = "I22 AMS Qty"
                .Columns(5).HeaderText = "I22 AMS Value"
                .Columns(5).DefaultCellStyle.Format = "00.00"

                .Columns(6).HeaderText = "I23 AMS Qty"
                .Columns(7).HeaderText = "I23 AMS Value"
                .Columns(7).DefaultCellStyle.Format = "00.00"

                .Columns(8).HeaderText = "I24 AMS Qty"
                .Columns(9).HeaderText = "I24 AMS Value"
                .Columns(9).DefaultCellStyle.Format = "00.00"

                .Columns(10).HeaderText = "I25 AMS Qty"
                .Columns(11).HeaderText = "I25 AMS Value"
                .Columns(11).DefaultCellStyle.Format = "00.00"

                .Columns(12).HeaderText = "I26 AMS Qty"
                .Columns(13).HeaderText = "I26 AMS Value"
                .Columns(13).DefaultCellStyle.Format = "00.00"

                .Columns(14).HeaderText = "Others AMS Qty"
                .Columns(15).HeaderText = "Others AMS Value"
                .Columns(15).DefaultCellStyle.Format = "00.00"
                For i = 3 To 16
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Next


            Else
                .Columns(3).HeaderText = "Qty"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                .Columns(4).HeaderText = "Value"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(4).DefaultCellStyle.Format = "00.00"
                .Columns(5).HeaderText = "Ofd Dt"
                .Columns(6).HeaderText = "Ofd Wk"
            End If
        End With




    End Sub
    Private Sub AMS_PENDING_IN_ORDER_PENDING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select to_char(sysdate-21,'IYYYIW')wk from dual union select to_char(sysdate-14,'IYYYIW') wk from dual  union select to_char(sysdate-7,'IYYYIW') wk from dual union select to_char(sysdate,'IYYYIW') wk from dual"

        ds = SQL_SELECT("wk", sql)
        cmb_ofd.DataSource = ds.Tables("wk")
        cmb_ofd.ValueMember = "wk"
        cmb_ofd.DisplayMember = "wk"

        sql = "SELECT DISTINCT SEGMENT14 region FROM RA_TERRITORIES WHERE SEGMENT14 NOT IN ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O') order by 1"
        ds = SQL_SELECT("region", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.ValueMember = "region"
        cmb_region.DisplayMember = "region"

    End Sub
End Class