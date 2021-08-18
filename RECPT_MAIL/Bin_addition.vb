Imports System.Data.OleDb
Imports System.IO
Public Class Bin_addition
    Dim con As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"
    Private Sub Bin_addition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "select customer_name,Customer_id from ra_customers where status<>'I' order by 1"
        ds = SQL_SELECT("CUST", sql)
        cmb_custname.DataSource = ds.Tables("CUST")
        cmb_custname.DisplayMember = "customer_name"
        cmb_custname.ValueMember = "Customer_id"

        sql = "select distinct segment14 region from ra_territories where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA') order by region"
        ds = SQL_SELECT("REGION", sql)
        cmb_region.DataSource = ds.Tables("region")
        cmb_region.DisplayMember = "region"

    End Sub
    Private Sub btn_select_file_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_file.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_file_name.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub btn_view_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_list.Click
        If txt_sheet_name.Text <> "" Then



            Dim filePath As String = txt_file_name.Text

            Dim extension As String = Path.GetExtension(filePath)
            Dim conStr As String, sheetName As String

            conStr = String.Empty
            Select Case extension

                Case ".xls"
                    conStr = String.Format(con, filePath, "YES")
                    Exit Select
            End Select


            Using con As New OleDbConnection(conStr)
                Using cmd As New OleDbCommand()
                    cmd.Connection = con
                    con.Open()
                    Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    'sheetName = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
                    'sheetName = dtExcelSchema.Rows(0)( ("TABLE_NAME").ToString()

                    sheetName = txt_sheet_name.Text & "$"

                    con.Close()
                End Using
            End Using


            Using con As New OleDbConnection(conStr)
                Using cmd As New OleDbCommand()
                    Using oda As New OleDbDataAdapter()
                        Dim dt As New DataTable()
                        cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                        cmd.Connection = con
                        con.Open()
                        oda.SelectCommand = cmd
                        oda.Fill(dt)
                        con.Close()


                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("Enter Sheet Name", "Bin Quantity updation", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btn_move_to_oracle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_to_oracle.Click
        sql = " DELETE FROM jan_bin_staging_table"
        comand_new()

        For i = 0 To DataGridView1.RowCount - 1
            With DataGridView1.Rows(i)
                'dt=

                sql = "insert into jan_bin_staging_table (BILL_TO_CUSTOMER_ID ,BILL_TO_CUST_NAME,SITE_ID ,SHIP_TO_SITE ,SHIP_TO_CUST_NAME,REGION,org,ORDERED_ITEM,FG_Bin_Qty,FC_Bin_Qty,rol,roq,BIN_TYPE,BIN_CATEGORY,HOLD_FLAG,ADD_ON,REMARKS) values('" & .Cells("BILL_TO_CUSTOMER_ID").Value & "','" & .Cells("BILL_TO_CUST_NAME").Value & "'," & .Cells("SITE_ID").Value & ",'" & .Cells("SHIP_TO_SITE").Value & "','" & .Cells("SHIP_TO_CUST_NAME").Value & "','" & .Cells("REGION").Value & "','" & .Cells("org").Value & "','" & .Cells("ORDERED_ITEM").Value & "'," & .Cells("FG_Bin_Qty").Value & "," & .Cells("FC_Bin_Qty").Value & "," & .Cells("rol").Value & "," & .Cells("ROQ").Value & ",'" & .Cells("BIN_TYPE").Value & "','" & .Cells("BIN_CATEGORY").Value & "'," & .Cells("HOLD_FLAG").Value & "," & .Cells("ADD_ON").Value & ",'" & .Cells("REMARKS").Value & "')" ','" & Format(CDate(.Cells("TARGET_DATE").Value), "dd-MMM-yyyy") & "'
                comand_new()

            End With
        Next

        If rad_all_new_bin.Checked = True Then

        Else

            sql = " UPDATE  JAN_CUSTOMER_REPLENISHMENT_T SET  END_DATE=TRUNC(SYSDATE)-1 WHERE  CUSTOMER_ID IN (SELECT distinct BILL_TO_CUSTOMER_ID FROM jan_bin_staging_table) AND END_DATE IS NULL "

            If rad_all_items.Checked = True Then
                sql &= " "
            ElseIf rad_item_specific.Checked = True Then
                sql &= "  and item_no in (select ordered_item from jan_bin_staging_table)"
            End If
            comand_new()

        End If

        sql = " insert into JAN_CUSTOMER_REPLENISHMENT_T (REP_ID,ORGANIZATION_ID,ORG,INVENTORY_ITEM_ID,ITEM_NO,DESCRIPTION,CUSTOMER_ID,CUSTOMER_NAME,BIN_TYPE,ROQ,ROL,START_DATE,END_DATE,REMARKS,FC_FG_FLAG,CREATED_BY,CREATED_DATE,LAST_UPDATE_BY,LAST_UPDATE_DATE,SHIP_TO_SITE_ID,REP_TYPE,BIN_METHOD,FC_QTY,BIN_CATEGORY,BIN_HOLD_FLAG,REGION,stock_remarks) "

        sql &= " (select JAN_REP_ID.NEXTVAL,JAN_ORGID(ORG)ORG,ORG,JAN_ITEMNO(TRIM(ORDERED_ITEM))INVENTORY_ITEM_ID, ORDERED_ITEM,JAN_ITEMDESC(ORDERED_ITEM) DESCRIPTION,BILL_TO_CUSTOMER_ID CUSTOMER_ID,BILL_TO_CUST_NAME CUSTOMER_NAME,BIN_TYPE,ROQ ,ROL ,sysdate START_DATE,''END_DATE,''REMARKS,''FC_FG_FLAG,'vivek'CREATED_BY,sysdate  CREATED_DATE,'automatic' LAST_UPDATE_BY,sysdate LAST_UPDATE_DATE,SITE_ID SHIP_TO_SITE_ID,'BIN'F,'BIN'F,FC_BIN_QTY,bin_category,hold_flag ,REGION,remarks from jan_bin_staging_table A )"

        comand_new()


        sql = "update JAN_CUSTOMER_REPLENISHMENT_T  set NO_OF_SCHEDULES=4,ADD_ON_QUANTITY=0,SKU_QTY=jan_near5(roq/4),BIN_FULFILLMENT_DAYS=7,rep_method='OARSV',ADD_ON_QTY=0 where  end_date is null and trunc(start_date)=trunc(sysdate)"


        comand_new()
        MessageBox.Show("Bin Item Added", "New Bin Item Addition", MessageBoxButtons.OK)



    End Sub
   
    Private Sub btn_view_site_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_site.Click
        sql = "select customer_id BILL_TO_CUSTOMER_ID,customer_name BILL_TO_CUST_NAME,site_use_id SITE_ID,address1 SHIP_TO_SITE,customer_name SHIP_TO_CUST_NAME,region ,address2,address3,address4,city,state from jan_bms_ship_to_v where customer_id=" & cmb_custname.SelectedValue & ""
        ds = SQL_SELECT("sites", sql)

        dgv_site_details.DataSource = ds.Tables("sites")
    End Sub
    Private Sub btn_view_bin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_bin.Click
        sql = "select * from jan_customer_replenishment_t where end_date is null and  customer_id=" & cmb_custname.SelectedValue & ""
        ds = SQL_SELECT("bin", sql)

        dgv_site_details.DataSource = ds.Tables("bin")
    End Sub
    Private Sub btn_end_all_bin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_end_all_bin.Click
        If Not IsNothing(cmb_custname.SelectedValue) Then
            sql = "update JAN_CUSTOMER_REPLENISHMENT_T  set  end_date=trunc(sysdate)-1 where  end_date is null and customer_id=" & cmb_custname.SelectedValue & ""
            comand_new()
            MessageBox.Show("Bin Item Ended for this customer", "New Bin Item Addition", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Select Customer Name and end Bin ", "New Bin Item Addition", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btn_end_item_bin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_end_item_bin.Click

        If Not IsNothing(cmb_custname.SelectedValue) And txt_item_end_bin.Text <> "" Then
            sql = "update JAN_CUSTOMER_REPLENISHMENT_T  set  end_date=trunc(sysdate)-1 where  end_date is null and customer_id=" & cmb_custname.SelectedValue & " and item_no='" & txt_item_end_bin.Text & "'"
            comand_new()
            MessageBox.Show("Bin Item Ended for this customer", "New Bin Item Addition", MessageBoxButtons.OK)
        Else


            MessageBox.Show("Select Customer Name  and Item No then end Bin ", "New Bin Item Addition", MessageBoxButtons.OK)

        End If

    End Sub

    Private Sub Bin_addition_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub btn_active_bin_Click(sender As Object, e As EventArgs) Handles btn_active_bin.Click
        If Not IsNothing(cmb_custname.SelectedValue) Then
            sql = "update JAN_CUSTOMER_REPLENISHMENT_T  set  active_bin=1 where  end_date is null and customer_id=" & cmb_custname.SelectedValue & ""
            comand_new()
            MessageBox.Show("Customer Bin marked as Active", "Active Bin Addition", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Select Customer Name and mark as Active ", "Active Bin Addition", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btn_view_active_bin_cust_Click(sender As Object, e As EventArgs) Handles btn_view_active_bin_cust.Click
        sql = " select distinct customer_name,region from  jan_it.JAN_CUSTOMER_REPLENISHMENT_T   where nvl(active_bin,0)=1  and  end_date is null order by customer_name,region"
        ds = SQL_SELECT("bin", sql)

        DataGridView1.DataSource = ds.Tables("bin")
    End Sub
    Private Sub btn_bin_revision_detail_Click(sender As Object, e As EventArgs) Handles btn_bin_revision_detail.Click

        sql = "select jan_orgcode(ORGANIZATION_ID)org,item_no,ORGANIZATION_ID,INVENTORY_ITEM_ID,CUSTOMER_ID,customer_name,region,count(*)No_of_active_lines  from  jan_customer_replenishment_t  where end_date is null group by ORGANIZATION_ID,INVENTORY_ITEM_ID,CUSTOMER_ID ,customer_name,region,item_no having count(*)>1 ORDER BY region,customer_name,org,item_no"
        ds = SQL_SELECT("bin", sql)
        If ds.Tables("bin").Rows.Count > 0 Then
            DataGridView1.DataSource = ds.Tables("bin")

            MessageBox.Show("Below items are added multiple times in Bin", "Bin Addition", MessageBoxButtons.OK)
            'Else
            sql = "select * from jan_Bin_revision_detail where region='" & cmb_region.Text & "'"
            ds = SQL_SELECT("bin", sql)

            DataGridView1.DataSource = ds.Tables("bin")
        End If

    End Sub
End Class