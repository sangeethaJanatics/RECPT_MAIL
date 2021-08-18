Imports System.Data.OracleClient
'Imports System.Data.OracleClient

Public Class Production_quantity

    'Dim CON As New OracleConnection("Data Source=prod;User Id=jan_it;Password=janapps;Integrated Security=no;")
    'Dim ds As New DataSet
    'Dim adap As New OracleDataAdapter


    'Change all the odbc.odbcconnection to OracleConnection

    'Change all the OracleCommand to Oraclecommand

    'Change all the OracleDataAdapter to Oracledataadapter
    Private Sub Production_quantity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        sql = "SELECT A.* ,(select description from mtl_system_items where  organization_id=a. organization_id and inventory_item_id=a.inventory_item_id)""Description"" from ( SELECT organization_id,inventory_item_id,jan_orgcode(organization_id)org,item_no ,transaction_date ""Transaction Date"", sum(transaction_quantity)""Production Qty"",level_5 ""Level 5"" FROM jan_prod_val_new WHERE trunc(transaction_date)>='" & Format(from_dt.Value, "dd-MMM-yyyy") & "' AND trunc(transaction_date)<'" & Format(DateAdd(DateInterval.Day, 1, To_date.Value), "dd-MMM-yyyy") & "'  GROUP BY organization_id, inventory_item_id, jan_orgcode(organization_id), item_no, transaction_date, level_5)a order by org,item_no"

        If Rad_Prodn_qty.Checked = True Then
            sql = "select JAN_ORGCODE(ORGANIZATION_ID)""Org"",jan_itemname(INVENTORY_ITEM_ID)""Item No"",B.PRODUCTION_QTY ""Production Qty"",JAN_ASSY_CAT(B.ORGANIZATION_ID, B.INVENTORY_ITEM_ID)""Prod Cat"" ,(SELECT LEVEL_5 FROM JAN_ITEM_CATEGORY WHERE  ORGANIZATION_ID=B.ORGANIZATION_ID AND  INVENTORY_ITEM_ID=B.INVENTORY_ITEM_ID)""Level 5""  FROM (select ORGANIZATION_ID,INVENTORY_ITEM_ID,SUM(wip_receipt)PRODUCTION_QTY from jan_rg1_receipt_issue where TRANSACTION_DATE>'30-jul-2021' and  TRUNC(TRANSACTION_DATE)>='" & Format(from_dt.Value, "dd-MMM-yyyy") & "' and  TRUNC(TRANSACTION_DATE)<'" & Format(DateAdd(DateInterval.Day, 1, To_date.Value), "dd-MMM-yyyy") & "' and wip_receipt>0   group by ORGANIZATION_ID, INVENTORY_ITEM_ID)B order by ""Org"",""Item No"""
        Else

            sql = " select JAN_ORGCODE(organization_id)""Org"",ROUND(SUM(wip_receipt*p_rate),2)""Production value"" from JAN_rg1_receipt_issue where TRANSACTION_DATE>'30-jul-2021' and  TRUNC(transaction_DATE)>='" & Format(from_dt.Value, "dd-MMM-yyyy") & "' and TRUNC(transaction_DATE)<'" & Format(DateAdd(DateInterval.Day, 1, To_date.Value), "dd-MMM-yyyy") & "' group by rollup(JAN_ORGCODE(organization_id)) order by 1 "
        End If


        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")
        If Rad_prodn_value.Checked = True Then
            With ds.Tables("data")
                .Rows(.Rows.Count - 1).Item(0) = "Total"
            End With

        End If

        With dgv1
            .DataSource = ds.Tables("data")
            If Rad_Prodn_qty.Checked = True Then
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Else
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            '.Columns(0).Visible = False
            '.Columns(1).Visible = False
            '.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.Columns(3).Width = 100
            '.Columns(7).Width = 350

        End With



    End Sub
End Class