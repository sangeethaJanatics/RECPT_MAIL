Imports System.IO
Public Class Demand_set_MIS
    Dim ITEM_ID As Integer = 0
    Private Sub Demand_set_MIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'sql = "select distinct jan_orgcode(organization_id)org,(select demand_set_allocation_date from JAN_SALES_BI_SETUP )status_as_on from jan_demand_set_tmp"

        sql = "select a.*,jan_orgcode(ORGANIZATION_ID)org,(select DEMAND_SET_ALLOCATION_DATE from JAN_SALES_BI_SETUP )STATUS_AS_ON from (select distinct ORGANIZATION_ID from JAN_DEMAND_SET_TMP )a ORDER BY ORG"

        ds = SQL_SELECT("org", sql)
        cmb_org.DataSource = ds.Tables("org")
        cmb_org.DisplayMember = "org"
        cmb_org.ValueMember = "organization_id"
        'cmb_org.SelectedIndex = -1
        cmb_org.Text = "I21"
        cmb_item_type.SelectedIndex = -1
        lbl_status.Text = "Status as on :" & ds.Tables("org").Rows(0).Item("status_as_on")
        display_result()



        sql = "select distinct item_type from JAN_DEMAND_SET_base_table "
        ds = SQL_SELECT("item_type", sql)
        cmb_item_type.DataSource = ds.Tables("item_type")
        cmb_item_type.DisplayMember = "item_type"
        cmb_item_type.SelectedIndex = -1

        sql = "select to_char(sysdate,'IYYYIW')WK from dual "
        ds = SQL_SELECT("week", sql)
        LBL_WEEK_NO.Text = "Current Week NO :" & ds.Tables("week").Rows(0).Item("wk")

    End Sub
    Private Sub display_result()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dgv_main.Columns.Clear()


        If txt_item_no.Text <> "" Then

            sql = "SELECT JAN_ITEMNO('" & txt_item_no.Text & "')ITEM_ID FROM DUAL"
            ds = SQL_SELECT("DATA", sql)
            If ds.Tables("DATA").Rows.Count > 0 And Not IsDBNull(ds.Tables("DATA").Rows(0).Item("ITEM_ID")) Then
                ITEM_ID = ds.Tables("DATA").Rows(0).Item("ITEM_ID")
            Else
                MessageBox.Show("Please check Item No ...!", "DS Pending For the Item", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub

            End If


        End If
        If txt_item_no.Text = "" Then ITEM_ID = 0
        'WEEK_NO
        If cmb_org.Text = "I23" Then


            sql = "SELECT  REPORT_DS_ID,ROUND(SUM(REQUIREMENT-NVL(CANCELLED_QTY,0)),2)DS_QTY,ROUND(SUM(RECEIPT_QTY),2)COMPLETED,ROUND(SUM(REQUIREMENT-NVL(CANCELLED_QTY,0)-RECEIPT_QTY),2)PENDING,sum(ams_qty)ams_qty"
            sql &= "  from ( select a.* ,  NVL((select SUM(TRIGGER_QTY) from JAN_IT.JAN_JOB_NOT_RELEASED where ORGANIZATION_ID=a.ORGANIZATION_ID AND ITEM_ID=A.INVENTORY_ITEM_ID AND ASSY_RELEASED<=0 ),0) +NVL((select SUM(START_QUANTITY-NVL(QUANTITY_COMPLETED,0)) from WIP_DISCRETE_JOBS W where ORGANIZATION_ID=a.ORGANIZATION_ID and PRIMARY_ITEM_ID=a.INVENTORY_ITEM_ID and STATUS_TYPE=3),0)AMS_Qty"

            sql &= "  FROM jan_cylinder_ds_lines a   WHERE EXCESS_COMPLETION_FLAG<>'Y' "

            If ITEM_ID <> 0 Then sql &= " and inventory_item_id=" & ITEM_ID & ""

            If rad_product.Checked = True Then sql &= " and DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')='Product'" Else sql &= " and DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')<>'Product'"

            sql &= ") GROUP BY REPORT_DS_ID ORDER BY REPORT_DS_ID"
        Else

            sql = "SELECT WEEK_NO ""Week No"",SUM(DS_CUR_REQ)DS_QTY,SUM(COMPLETED_QTY+CANCELLED_QTY)""Completed"",SUM(DS_CUR_REQ-(COMPLETED_QTY+CANCELLED_QTY))""Pending"" from JAN_DEMAND_SET_TMP_v where 1=1  " ',SUM(RSV2_M2O_BIN)M2o_Bin_Pending JAN_DEMAND_SET_TMP_V_SCHEDULE


            'If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno('" & txt_item_no.Text & "')"
            If ITEM_ID <> 0 Then sql &= " and inventory_item_id=" & ITEM_ID & ""

            'If cmb_org.Text <> "" Then sql &= " and  ORGANIZATION_ID=JAN_ORGID('" & cmb_org.Text & "')"
            If cmb_org.Text <> "" Then sql &= " and  ORGANIZATION_ID=" & cmb_org.SelectedValue & ""

            If cmb_item_type.Text <> "" Then sql &= " and item_type='" & cmb_item_type.Text & "'"

            If rad_product.Checked = True Then sql &= " and prod_cat='Product'" Else sql &= " and prod_cat<>'Product'"

            sql &= " and organization_id<>444 "
            sql &= " GROUP BY WEEK_NO ORDER BY WEEK_NO"
        End If
        ds = SQL_SELECT("DATA", sql)

        With ds.Tables("DATA")
            .Rows.Add()
            .Rows(.Rows.Count - 1).Item("DS_Qty") = .Compute("sum(DS_Qty)", "DS_Qty > 0")
            .Rows(.Rows.Count - 1).Item("Completed") = .Compute("sum(Completed)", "Completed > 0")
            .Rows(.Rows.Count - 1).Item("Pending") = .Compute("sum(Pending)", "Pending> 0")
            If cmb_org.Text = "I23" Then .Rows(.Rows.Count - 1).Item("ams_qty") = .Compute("sum(ams_qty)", "ams_qty> 0")
        End With

        dgv_main.DataSource = ds.Tables("DATA")

        With dgv_main

            .Columns("ds_qty").HeaderText = "DS Qty"
            '.Columns("m2o_bin_Pending").HeaderText = "M2o + Bin Pending"
            .Columns(0).Width = "65"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(1).Width = "75"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(2).Width = "75"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(3).Width = "75"
            '.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
            .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
            If cmb_org.Text = "I23" Then .Columns("ams_qty").HeaderText = "AMS Qty"
        End With
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        display_result()
        dgv_brk.Columns.Clear()
    End Sub
    Private Sub dgv_main_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_main.CellClick

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dgv_brk.Columns.Clear()
        If txt_item_no.Text <> "" Then

            sql = "SELECT JAN_ITEMNO('" & txt_item_no.Text & "')ITEM_ID FROM DUAL"
            ds = SQL_SELECT("DATA", sql)
            If ds.Tables("DATA").Rows.Count > 0 And Not IsDBNull(ds.Tables("DATA").Rows(0).Item("ITEM_ID")) Then
                ITEM_ID = ds.Tables("DATA").Rows(0).Item("ITEM_ID")
            Else
                MessageBox.Show("Please check Item No ...!", "DS Pending For the Item", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub

            End If


        End If
        If cmb_org.Text = "I23" Then
            sql = "select rownum ""Sl.no"", b.* from ( select jan_orgcode(organization_id)org,jan_itemname(inventory_item_id)item_no,"

            sql &= " (SELECT SEGMENT1 FROM MTL_ITEM_CATEGORIES_V WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID  AND CATEGORY_SET_NAME='Team Name')""Div"" "
            sql &= " ,sum(REQUIREMENT-NVL(CANCELLED_QTY,0)) DS_Qty,sum(receipt_QTY)  ""Completed"",sum(REQUIREMENT-NVL(CANCELLED_QTY,0)-receipt_QTY)""Pending"" ,DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')  ""Prod Cat"" ,  NVL((select SUM(TRIGGER_QTY) from JAN_IT.JAN_JOB_NOT_RELEASED where ORGANIZATION_ID=a.ORGANIZATION_ID AND ITEM_ID=A.INVENTORY_ITEM_ID AND ASSY_RELEASED<=0 ),0) +NVL((select SUM(START_QUANTITY-NVL(QUANTITY_COMPLETED,0)) from WIP_DISCRETE_JOBS W where ORGANIZATION_ID=a.ORGANIZATION_ID and PRIMARY_ITEM_ID=a.INVENTORY_ITEM_ID and STATUS_TYPE=3),0)AMS_Qty "
            'sql &= " ,NVL((SELECT FINAL_RRS FROM JAN_RRS_CATEGORY_MASTER WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),'St') ""RRS Cat"" "
            sql &= ",JAN_SALES_RRS_CATEGORY (A.ORGANIZATION_ID,A.INVENTORY_ITEM_ID ) ""RRS Cat"""

            sql &= "  from jan_cylinder_ds_lines  A where  (REQUIREMENT-NVL(CANCELLED_QTY,0))>0 and report_ds_id=" & dgv_main.CurrentRow.Cells(0).Value & "   "

            If ITEM_ID <> 0 Then sql &= " and inventory_item_id=" & ITEM_ID & ""
            If rad_product.Checked = True Then sql &= " and DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')='Product'" Else sql &= " and DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')<>'Product'"

            'and DECODE(JAN_ASSY_CAT(a.ORGANIZATION_ID, a.INVENTORY_ITEM_ID),'PROD','Product','Accessories')='Product'  
            sql &= " group by organization_id,inventory_item_id  order by org,item_no )b"

        Else



            sql = " select rownum ""Sl.no"", b.* from ( select jan_orgcode(organization_id)org,jan_itemname(inventory_item_id)item_no,"

            sql &= " (SELECT SEGMENT1 FROM MTL_ITEM_CATEGORIES_V WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID  AND CATEGORY_SET_NAME='Team Name')""Div"" "
            sql &= " ,sum(DS_CUR_REQ) DS_Qty,sum(COMPLETED_QTY+CANCELLED_QTY) ""Completed"",sum(DS_CUR_REQ-(COMPLETED_QTY+CANCELLED_QTY))""Pending"" ,target_date ""Target Date"" ,prod_cat  ""Prod Cat"" ,sum(RSV2) AMS_Qty "

            'sql &= " ,NVL((SELECT FINAL_RRS FROM JAN_RRS_CATEGORY_MASTER WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),'St') ""RRS Cat"" "
            sql &= ",JAN_SALES_RRS_CATEGORY (A.ORGANIZATION_ID,A.INVENTORY_ITEM_ID ) ""RRS Cat"""

            sql &= " from JAN_DEMAND_SET_TMP_v  A where  DS_CUR_REQ>0 and week_no=" & dgv_main.CurrentRow.Cells(0).Value & " " ',SUM(RSV2_M2O_BIN)M2o_Bin_Pending

            'If txt_item_no.Text <> "" Then sql &= " and inventory_item_id=jan_itemno('" & txt_item_no.Text & "')"
            If ITEM_ID <> 0 Then sql &= " and inventory_item_id=" & ITEM_ID & ""


            'If cmb_org.Text <> "" Then sql &= " and ORGANIZATION_ID=JAN_ORGID('" & cmb_org.Text & "') "
            If cmb_org.Text <> "" Then sql &= " and  ORGANIZATION_ID=" & cmb_org.SelectedValue & ""

            If rad_pending.Checked = True Then sql &= " AND (DS_CUR_REQ-(COMPLETED_QTY+CANCELLED_QTY))>0 "

            If cmb_item_type.Text <> "" Then sql &= " and item_type='" & cmb_item_type.Text & "'"

            If rad_product.Checked = True Then sql &= " and prod_cat='Product'" Else sql &= " and prod_cat<>'Product'"
            sql &= " and  organization_id<>444 "
            sql &= " group by organization_id,inventory_item_id,target_date,prod_cat "

            sql &= " order by org,item_no )b"
        End If

        ds = SQL_SELECT("DATA", sql)

        With ds.Tables("DATA")
            .Rows.Add()
            .Rows(.Rows.Count - 1).Item("DS_Qty") = .Compute("sum(DS_Qty)", "DS_Qty > 0")
            .Rows(.Rows.Count - 1).Item("Completed") = .Compute("sum(Completed)", "Completed > 0")
            .Rows(.Rows.Count - 1).Item("Pending") = .Compute("sum(Pending)", "Pending> 0")
            .Rows(.Rows.Count - 1).Item("AMS_Qty") = .Compute("sum(AMS_Qty)", "AMS_Qty> 0")
            '.Rows(.Rows.Count - 1).Item("m2o_bin_pending") = .Compute("sum(m2o_bin_pending)", "m2o_bin_pending> 0")
        End With

        dgv_brk.DataSource = ds.Tables("data")

        With dgv_brk
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(3).Width = 45
            .Columns(4).Width = 45
            .Columns(5).Width = 45
            .Columns("DS_Qty").HeaderText = "DS Qty"
            '.Columns("m2o_bin_pending").HeaderText = "M2o + Bin Pending"

            .Columns("ams_Qty").Width = 50
            .Columns("ams_Qty").HeaderText = "AMS Qty"
            .Columns("ams_Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
            .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue

        End With
        Windows.Forms.Cursor.Current = Cursors.Default
        lbl_brk.Text = " Breakup for Week NO :: " & dgv_main.CurrentRow.Cells(0).Value
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        DS_MIS.Show()

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Panel1.Visible = True
    End Sub
    Private Sub btn_show_penidng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show_penidng.Click

        If txt_week_no.Text <> "" Then
            show_summary()
        Else
            MessageBox.Show("Enter Week no and view the summary ", "DS Summary Report ", MessageBoxButtons.OK)

        End If
    End Sub
    Private Sub show_summary()
        sql = "select c.*,(PREVIOUE_DS_PENDING+CUR_WK_PENDING)total,round((PREVIOUE_DS_PENDING+CUR_WK_PENDING)/per_day_qty)days_to_complete from (select b.* ,case when  PROD_CAT='Product' and ORG='I21' then 540 when  PROD_CAT='Product' and ORG='I22' then 1600 when  PROD_CAT='Product' and ORG='I23' then 1300 when  PROD_CAT='Product' and  PROD_CAT='Product' and ORG='I24' then 3500 when  PROD_CAT='Product' and ORG='I25' then 30000 else null end per_day_qty,case when  PROD_CAT='Product' then 0 else 1 end prod_ord   from (SELECT prod_cat,JAN_ORGCODE(ORGANIZATION_ID)ORG,SUM(CASE WHEN WEEK_NO<" & txt_week_no.Text & " THEN PENDING_QTY ELSE 0 END)PREVIOUE_DS_PENDING,SUM(CASE WHEN WEEK_NO=" & txt_week_no.Text & " THEN PENDING_QTY ELSE 0 END)CUR_WK_PENDING,sum(CASE WHEN WEEK_NO<=" & txt_week_no.Text & " THEN PENDING_QTY*prate ELSE 0 END)val  FROM JAN_DEMAND_SET_TMP_v  WHERE ORGANIZATION_ID in (524,464,484,504,505) GROUP BY JAN_ORGCODE(ORGANIZATION_ID),prod_cat )B)C order by prod_ord,org"
        ds = SQL_SELECT("DATA", sql)

        'Query for customer count
        sql = "select COUNT(distinct CUSTOMER_ID)CUST_COUNT  from JAN_SALES_ANY_TB2_1 where ORDERED_DATE<(select TRUNC(DS_DATE) from JAN_DEMAND_SET_HEADER  where DS_ID=(select min( DS_ID ) DS_ID from JAN_DEMAND_SET_BASE_TABLE where TO_CHAR(TARGET_DATE,'IYYYIW')=" & txt_week_no.Text & ")) and BOOKED_DATE< (select DS_DATE from JAN_DEMAND_SET_HEADER  where DS_ID=(select min( DS_ID ) DS_ID from JAN_DEMAND_SET_BASE_TABLE where TO_CHAR(TARGET_DATE,'IYYYIW')=" & txt_week_no.Text & ")) and SCHEDULE_SHIP_DATE<(select TRUNC(DS_DATE)+14 from JAN_DEMAND_SET_HEADER  where DS_ID=(select min( DS_ID ) DS_ID from JAN_DEMAND_SET_BASE_TABLE where TO_CHAR(TARGET_DATE,'IYYYIW')=" & txt_week_no.Text & ")) and (ORDERED_QUANTITY-(NVL(SHIPPED_QUANTITY,0)+nvl(picked_qty,0)+nvl(rsv_qty,0)))>0"



        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"

        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Org</th><th>Prod Cat</th><th>Previous DS pending qty</th><th>DS pending for week " & txt_week_no.Text & "</th><th>Total upto " & txt_week_no.Text & " th week</th><th>Per day qty</th><th>No Of of Days to complete</th></tr>"

        Dim pre_wk_pend, cur_wk_pend, total_pend As Integer
        Dim val As Double = 0
        pre_wk_pend = 0
        cur_wk_pend = 0
        total_pend = 0

        For k = 0 To ds.Tables("data").Rows.Count - 1
            With ds.Tables("data").Rows(k)

                pre_wk_pend += .Item("PREVIOUE_DS_PENDING")
                cur_wk_pend += .Item("CUR_WK_PENDING")
                total_pend += .Item("total")
                val += .Item("val")

                S &= "<tr><td >" & .Item("org") & "</td><td >" & .Item("prod_cat") & "</td><td align=center>"

                If Not IsDBNull(.Item("PREVIOUE_DS_PENDING")) Then S &= "" & .Item("PREVIOUE_DS_PENDING") & "" Else S &= "&nbsp;"

                S &= "</td><td  align=center>"

                If Not IsDBNull(.Item("CUR_WK_PENDING")) Then S &= "" & .Item("CUR_WK_PENDING") & "" Else S &= "&nbsp;"
                S &= "</td><td  align=center>"

                If Not IsDBNull(.Item("total")) Then S &= "" & .Item("total") & "" Else S &= "&nbsp;"

                S &= "</td><td  align=center>"

                If Not IsDBNull(.Item("per_day_qty")) Then S &= "" & .Item("per_day_qty") & "" Else S &= "&nbsp;"

                S &= "</td><td  align=center> "

                If Not IsDBNull(.Item("days_to_complete")) Then S &= "" & .Item("days_to_complete") & "" Else S &= "&nbsp;"

                S &= "</td>"
                'S &= "<td>" & .Item("per_day_qty") & "</td>"
                'S &= "<td>" & .Item("days_to_complete") & "</td>"

                'If Not IsDBNull(.Item("pay_term")) Then S &= " " & .Item("pay_term") & "" Else S &= "&nbsp;"
                S &= "</tr>"
            End With
        Next
        S &= "<tr><td colspan=2 align=right ><b>Total ::</td><td  align=center><b>" & pre_wk_pend & " </td><td  align=center><b>" & cur_wk_pend & " </td><td  align=center><b>" & total_pend & " </td><td> &nbsp;  </td><td>&nbsp; </td></tr>"

        sql = "select * from jan_bi_authorised_user where ip_address=( select SYS_CONTEXT('USERENV', 'IP_ADDRESS', 15) ipaddr from dual) and bi_enabled='Y'"
        ds = SQL_SELECT("ip", sql)
        If ds.Tables("ip").Rows.Count > 0 Then
            S &= "<tr><td colspan=2  align=right ><b>Total Value ::</td><td align=right>" & val & " </td><td>&nbsp; </td></tr>"
        End If

        S &= "</table></td></tr>"
        S &= "</html>"

        X = "D:\DS_summary.html"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

        System.Diagnostics.Process.Start("D:\DS_summary.html")

    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Panel1.Visible = False
    End Sub

    Private Sub Demand_set_MIS_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub
End Class