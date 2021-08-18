Public Class Stock_breakup

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        If cmb_criteria.Text = "Consolidated Stock" Then
            sql = " select org,round(rm/100000,2)""RM"",round(comp/100000,2)""COMP"",round(comp_for_rm/100000,2)""wip for comp/rm"",round(wip_fg/100000,2)""wip for FG"",round(po_receiving/100000,2)""PO Receiving"",round(FG_RG1_STORE/100000,2)""FG Rg1 store"",round(fg_production_store/100000,2)""FG Production Store"",round((nvl(rm,0)+nvl(comp,0)+nvl(comp_for_rm,0)+nvl(wip_fg,0)+nvl(po_receiving,0)+nvl(FG_RG1_STORE,0)+nvl(fg_production_store,0))/100000,2)""Total"" from jan_inv_bi_stock where run_time=trunc(sysdate)  "

            sql &= " union select 'Total' org,round(sum(rm)/100000,2)rm,round(sum(comp)/100000,2)comp,round(sum(comp_for_rm)/100000,2)wip_rm_comp,round(sum(wip_fg)/100000,2)wip_FG,round(sum(po_receiving)/100000,2)po_receiving,round(sum(FG_RG1_STORE)/100000,2)FG_RG1_STORE,round(sum(fg_production_store)/100000,2)fg_production_store,round(sum((nvl(rm,0)+nvl(comp,0)+nvl(comp_for_rm,0)+nvl(wip_fg,0)+nvl(po_receiving,0)+nvl(FG_RG1_STORE,0)+nvl(fg_production_store,0)))/100000,2)total from jan_inv_bi_stock where run_time=trunc(sysdate) "

            sql &= " order by org "
        ElseIf cmb_criteria.Text = "Stock Breakup" Then
            sql = " "
        End If

        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")
    End Sub

    Private Sub Stock_breakup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class