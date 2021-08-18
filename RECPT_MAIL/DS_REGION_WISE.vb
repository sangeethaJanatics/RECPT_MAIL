Public Class DS_REGION_WISE

    Private Sub DS_REGION_WISE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select distinct segment14 region from ra_territories where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA') order by region"
        ds = SQL_SELECT("REGION", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.DisplayMember = "region"

        sql = "select organization_code,organization_id from org_organization_definitions where organization_id in (444,464,484,504,505,524) order by organization_code"
        ds = SQL_SELECT("org", sql)
        cmb_org.DataSource = ds.Tables("org")
        cmb_org.DisplayMember = "organization_code"
        cmb_org.ValueMember = "organization_id"
        btn_go_Click(sender, e)
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = "SELECT to_char(target_date,'IYYYIW.D')""Target Week"",jan_orgcode(organization_id)""Org"",jan_itemname(inventory_item_id)""Item No"",requirement ""Requirement"",receipt_qty ""Completed Qty"",(requirement-receipt_qty)""Pending Qty"" FROM jan_cylinder_ds_lines a  where  1=1 "

        If txt_item.Text <> "" Then sql &= " and inventory_item_id=jan_itemno('" & txt_item.Text & "')"
        If txt_week_no.Text <> "" Then sql &= " and to_char(target_date,'IYYYIW')='" & txt_week_no.Text & "'"


        sql &= "  order by ""Org"",""Item No"",ds_id,target_date,line_id"
        ds = SQL_SELECT("REGION", sql)

        With dgv1
            .DataSource = ds.Tables("region")
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With



    End Sub
End Class