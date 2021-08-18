Public Class DS_MIS

    Private Sub DS_MIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select 'All' org from dual union select distinct jan_orgcode(organization_id)org from jan_demand_set_tmp"
        ds = SQL_SELECT("org", sql)
        cmb_org.DataSource = ds.Tables("org")
        cmb_org.DisplayMember = "org"

        display_result()

    End Sub
    Private Sub display_result()

        'sql = "select ds_prepared_week ""DS Prepared Wk"",sum(completed_within_target+completed_above_target+pending_within_target+pending_above_target)""Total"",sum(completed_within_target)""Completed within Target"" ,sum(completed_above_target)""Completed Above Target"" ,sum(pending_within_target)""Pending within Target"" ,sum(pending_above_target)""Pending Above Target"",round((sum(completed_within_target)/sum(completed_within_target+completed_above_target+pending_within_target+completed_above_target))*100,2)""Success %"" from JAN_DEMAND_SET_MIS_TAB where 1=1 "

        sql = "SELECT ds_prepared_week""DS Prepared Wk"" "
        ',sum(completed_within_target+completed_above_target+pending_within_target+pending_above_target)
        sql &= ", count(*) ""Total"",sum(completed_within_target)""Completed within Target"" ,sum(completed_above_target)""Completed Above Target"" ,sum(pending_within_target)""Pending within Target"" ,sum(pending_above_target)""Pending Above Target"",round((sum(completed_within_target)/sum(completed_within_target+completed_above_target+pending_within_target+PENDING_ABOVE_TARGET))*100,2)""Success %"" "
        sql &= "  FROM ("
        sql &= "SELECT a.* ,CASE WHEN  PRODN_COMPLETED IS NOT NULL AND PRODN_COMPLETED<=ACTUAL_TARGET_DATE THEN 1 ELSE 0 END COMPLETED_WITHIN_TARGET"
        sql &= ",CASE WHEN   PRODN_COMPLETED IS NOT NULL AND PRODN_COMPLETED>ACTUAL_TARGET_DATE THEN 1 ELSE 0 END COMPLETED_ABOVE_TARGET"
        sql &= ",CASE WHEN  PRODN_COMPLETED IS  NULL AND PENDING_QTY>0  AND ACTUAL_TARGET_DATE>=TRUNC(SYSDATE) THEN 1 ELSE 0 END PENDING_WITHIN_TARGET"
        sql &= ",CASE WHEN  PRODN_COMPLETED IS  NULL  AND PENDING_QTY>0 AND ACTUAL_TARGET_DATE<TRUNC(SYSDATE)THEN 1 ELSE 0 END PENDING_ABOVE_TARGET  from jan_demand_set_completion_t a where 1=1 "


        If cmb_org.Text <> "All" Then sql &= " and organization_id=jan_orgid('" & cmb_org.Text & "')"

        If rad_product.Checked = True Then sql &= " and prod_cat='Product'" Else sql &= " and prod_cat<>'Product'"

        If cmb_item_type.Text <> "" Then sql &= " and item_type='" & cmb_item_type.Text & "'"

        sql &= " )"
        sql &= " group by ds_prepared_week order by ds_prepared_week"

        ds = SQL_SELECT("data", sql)

        With dgv1

            .DataSource = ds.Tables("data")
            .Columns(0).Width = 60
            .Columns(1).Width = 60
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        End With

        dgv2.Columns.Clear()

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        display_result()
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick

        sql = " SELECT ROWNUM ""Sl No"" ,b.* from (select jan_orgcode(organization_id)org,jan_itemname(inventory_item_id)item_no,ds_cur_req ""DS Qty"",completed_qty ""Completed Qty"",cancelled_qty ""Adjusted Qty"",pending_qty ""Pending Qty"",actual_target_date ""Target Dt"",to_char(actual_target_date,'YYYYIW') ""Target Wk"",prodn_completed ""Prodn Completed Dt"",to_char(prodn_completed,'YYYYIW') ""Prodn Completed Wk"" ,rrs_cat ""RRS Cat"" from (SELECT a.* ,CASE WHEN  PRODN_COMPLETED IS NOT NULL AND PRODN_COMPLETED<=ACTUAL_TARGET_DATE THEN 1 ELSE 0 END COMPLETED_WITHIN_TARGET,CASE WHEN   PRODN_COMPLETED IS NOT NULL AND PRODN_COMPLETED>ACTUAL_TARGET_DATE THEN 1 ELSE 0 END COMPLETED_ABOVE_TARGET,CASE WHEN PRODN_COMPLETED IS  NULL AND ACTUAL_TARGET_DATE>=TRUNC(SYSDATE) THEN 1 ELSE 0 END PENDING_WITHIN_TARGET,case when  PRODN_COMPLETED is  null and ACTUAL_TARGET_DATE<trunc(sysdate)then 1 else 0 end pending_above_target,(SELECT rrs_cat FROM JAN_DEMAND_SET_base_table where ORGANIZATION_ID=a.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and ds_id=a.ds_id)rrs_cat from jan_demand_set_completion_t a  where  ds_prepared_week=" & dgv1.CurrentRow.Cells("DS Prepared Wk").Value & ""


        If cmb_org.Text <> "All" Then sql &= " and organization_id=jan_orgid('" & cmb_org.Text & "')"

        If rad_product.Checked = True Then sql &= " and prod_cat='Product'" Else sql &= " and prod_cat<>'Product'"

        If cmb_item_type.Text <> "" Then sql &= " and item_type='" & cmb_item_type.Text & "'"

        sql &= "  ) where 1=1 "

        'If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Completed within Target" Then sql &= " and (case when (DS_CUR_REQ-CANCELLED_QTY)>0  and PRODN_COMPLETED is not null and PRODN_COMPLETED<=ACTUAL_TARGET_DATE then 1 else 0 end)=1"

        'If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Completed Above Target" Then sql &= " and (CASE WHEN (DS_CUR_REQ-CANCELLED_QTY)>0  and  PRODN_COMPLETED IS NOT NULL AND PRODN_COMPLETED>ACTUAL_TARGET_DATE THEN 1 ELSE 0 END)=1"

        'If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Pending within Target" Then sql &= " and (case when (DS_CUR_REQ-CANCELLED_QTY)>0  and  PRODN_COMPLETED is  null and ACTUAL_TARGET_DATE>=TRUNC(sysdate) then 1 else 0 end)=1"

        'If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Pending Above Target" Then sql &= " and (case when (DS_CUR_REQ-CANCELLED_QTY)>0  and  PRODN_COMPLETED is  null and ACTUAL_TARGET_DATE<trunc(sysdate)then 1 else 0 end )=1"

        If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Completed within Target" Then sql &= " and COMPLETED_WITHIN_TARGET>0"

        If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Completed Above Target" Then sql &= " and COMPLETED_ABOVE_TARGET>0"

        If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Pending within Target" Then sql &= " and PENDING_WITHIN_TARGET>0"

        If dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText = "Pending Above Target" Then sql &= " and pending_above_target>0"

        sql &= " order by org,item_no)b"

        ds = SQL_SELECT("data", sql)

        With dgv2
            .DataSource = ds.Tables("data")
            .Columns(0).Width = "40"
            .Columns(1).Width = "40"

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With



    End Sub
End Class