Public Class MKtg_review_detail

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        Cursor.Current = Cursors.WaitCursor
        If rad_os_more_than_15days.Checked = True Then
            sql = "select customer_name,customer_id,rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and  customer_id='||a.customer_id||'' )region,NVL((SELECT  SUM(AMOUNT_DUE_REMAINING) FROM JAN_REGION_PAYMENT_PENDING_tab  WHERE BILL_TO_CUSTOMER_ID=A.customer_id AND TRX_DATE<TRUNC(SYSDATE)-16 AND name not in (select name from jan_exemp_payment_inv) AND NAME<>'Credit Memo'),0)OS_INV_MORETHAN_15DAYS from  ra_customers a  where customer_class_code='DEALER' order by 1"
        ElseIf rad_monthwise_sales.Checked = True Then
            sql = " select * from jan_sales_monthwise_v "
        ElseIf rad_dealer_week_order_pend.Checked = True Then
            sql = " select customer_name,jan_orgcode(ORGANIZATION_ID)org,week_no,PRODUCT_GROUP,sum((ORDERED_QUANTITY-nvl(shipped_quantity,0)))order_pending_qty, sum((ORDERED_QUANTITY-nvl(shipped_quantity,0))*unit_selling_price)order_pending_value from ( select b.* ,case when LEVEL_5='Product' then NVL((select GROUP_NAME from JAN_DEALER_TARGET_PROD_GROUP where SERIES=B.LEVEL_2),'Others') else DECODE(LEVEL_5,'Tube','PU Tube',LEVEL_5) end PRODUCT_GROUP  from ( select a.*,to_char(order_ff_dt,'IYYYIW')week_no ,(select level_2 from jan_item_category where ORGANIZATION_ID=a.ORGANIZATION_ID and inventory_item_id=a.inventory_item_id)level_2 ,(select level_5 from jan_item_category where ORGANIZATION_ID=a.ORGANIZATION_ID and inventory_item_id=a.inventory_item_id)level_5 from jan_sales_any_tb2_1 a  where ordered_date>(select min(ordered_date)-1 from jan_sales_plan_tv_t)   /* and ord_type<>'Service Invoice' */ and (ORDERED_QUANTITY-nvl(shipped_quantity,0))>0 and customer_id in  ( Select Customer_Id From Ra_Customers  Where Customer_Class_Code='DEALER' ))B) Group By Organization_Id,Week_No,Product_Group,Customer_Name"

        ElseIf rad_dealer_sale_order_pend.Checked = True Then
            sql = "select * from jan_dealer_sale_order_pending"
        ElseIf rad_segment_wise_sale.Checked = True Then
            sql = "select * from  jan_sales_ind_segment_v"
        ElseIf rad_order_sale_with_product_group.Checked = True Then
            sql = " select * from JAN_MKTG_ORDER_SALE_v2"

        ElseIf rad_order_and_sale.Checked = True Then
            sql = "select * from  jan_mktg_order_sale"

        ElseIf rad_delhi1_qtrly_sale.Checked = True Then
            sql = "select * from  jan_delhi_zone_sale"

        ElseIf RAD_DELHI1_SALE.Checked = True Then
            sql = "select FIN_YEAR,round(sum(quantity_invoiced*unit_SELLING_PRICE)/100000,2)Total_Sale "
            sql &= " ,round(sum(case when zone='ZONE 1' THEN  quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)NCR "
            sql &= " ,round(sum(case when zone='ZONE 2' THEN  quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Sonepat "
            sql &= " ,round(sum(case when zone='ZONE 3' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Jaipur "
            sql &= " ,round(sum(case when zone='ZONE 4' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Ludhiana "
            sql &= " ,round(sum(case when zone='ZONE 5' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Rudhrapur "
            sql &= " ,round(sum(case when zone='ZONE 6' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Kanpur "
            sql &= " ,round(sum(case when zone='ZONE 7' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Neemrana "
            sql &= " ,round(sum(case when zone='ZONE 8' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Chandigarh "
            sql &= " ,round(sum(case when zone='ZONE 9' THEN quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Himachala_Pradesh "
            sql &= " ,round(sum(case when zone Is NULL THEN   quantity_invoiced*unit_SELLING_PRICE ELSE 0 END )/100000,2)Unmapped from (select (SELECT CURYEAR FROM JAN_IT.JAN_BI_AP_TB3 WHERE TRUNC(TRX_DATE) BETWEEN  START_DATE And END_DATE) FIN_YEAR, a.* from jan_sales_any_1_copy a where trx_date>='1-apr-2018' and region ='DELHI 1') GROUP BY FIN_YEAR"

        End If
        ds = SQL_SELECT("res", sql)
        If rad_order_and_sale.Checked = True Then
            'mail_content("order_and_sale")
            'System.Diagnostics.Process.Start("d:\order_and_sale.xls")
        ElseIf RAD_DELHI1_SALE.Checked = True Then
            With ds.Tables("res")
                .Rows.Add("Total")
                .Rows(.Rows.Count - 1).Item("NCR") = .Compute("sum(NCR)", "NCR>=0")
                .Rows(.Rows.Count - 1).Item("Sonepat") = .Compute("sum(Sonepat)", "Sonepat>=0")
                .Rows(.Rows.Count - 1).Item("Jaipur") = .Compute("sum(Jaipur)", "Jaipur>=0")
                .Rows(.Rows.Count - 1).Item("Ludhiana") = .Compute("sum(Ludhiana)", "Ludhiana>=0")
                .Rows(.Rows.Count - 1).Item("Rudhrapur") = .Compute("sum(Rudhrapur)", "Rudhrapur>=0")
                .Rows(.Rows.Count - 1).Item("Kanpur") = .Compute("sum(Kanpur)", "Kanpur>=0")
                .Rows(.Rows.Count - 1).Item("Neemrana") = .Compute("sum(Neemrana)", "Neemrana>=0")
                .Rows(.Rows.Count - 1).Item("Chandigarh") = .Compute("sum(Chandigarh)", "Chandigarh>=0")
                .Rows(.Rows.Count - 1).Item("Himachala_Pradesh") = .Compute("sum(Himachala_Pradesh)", "Himachala_Pradesh>=0")
                .Rows(.Rows.Count - 1).Item("Total_Sale") = .Compute("sum(Total_Sale)", "Total_Sale>=0")
                .Rows(.Rows.Count - 1).Item("Unmapped") = .Compute("sum(Unmapped)", "Unmapped>=0")


            End With



        End If


        dgv1.DataSource = ds.Tables("res")
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgv1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellClick
        If RAD_DELHI1_SALE.Checked = True Then
            Dim zone_name As String = ""
            Dim zone_no As String = ""

            zone_name = dgv1.Columns(dgv1.CurrentCell.ColumnIndex).HeaderText
            If zone_name = "NCR" Then
                zone_no = "='ZONE 1'"
            ElseIf zone_name = "SONEPAT" Then
                zone_no = "='ZONE 2'"
            ElseIf zone_name = "JAIPUR" Then
                zone_no = "='ZONE 3'"
            ElseIf zone_name = "LUDHIANA" Then
                zone_no = "='ZONE 4'"
            ElseIf zone_name = "RUDHRAPUR" Then
                zone_no = "='ZONE 5'"
            ElseIf zone_name = "KANPUR" Then
                zone_no = "='ZONE 6'"
            ElseIf zone_name = "NEEMRANA" Then
                zone_no = "='ZONE 7'"
            ElseIf zone_name = "CHANDIGARH" Then
                zone_no = "='ZONE 8'"
            ElseIf zone_name = "HIMACHALA_PRADESH" Then
                zone_no = "='ZONE 9'"
            ElseIf zone_name = "UNMAPPED" Then
                zone_no = "  is null "

            End If
            sql = " select bill_to_cust_name,sum(quantity_invoiced*unit_SELLING_PRICE)sale_value from jan_sales_any_1_copy a where trx_date>='1-apr-2018' and region ='DELHI 1'  and zone " & zone_no & " and (SELECT CURYEAR FROM JAN_IT.JAN_BI_AP_TB3 WHERE TRUNC(TRX_DATE) BETWEEN  START_DATE AND END_DATE)='" & dgv1.CurrentRow.Cells(0).Value & "' group by rollup(bill_to_cust_name) order by bill_to_cust_name"
            ds = SQL_SELECT("res", sql)
            If ds.Tables("res").Rows.Count - 1 > 0 Then
                ds.Tables("res").Rows(ds.Tables("res").Rows.Count - 1).Item("bill_to_cust_name") = "Total"
            End If
            dgv_brk.DataSource = ds.Tables("res")
        End If
    End Sub

    Private Sub MKtg_review_detail_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        End
    End Sub

    Private Sub btn_export_to_excel_Click(sender As Object, e As EventArgs) Handles btn_export_to_excel.Click
        Dim dt As DataTable
        ' Dim dr As DataRow
        Dim myString As String
        Dim bFirstRecord As Boolean = True
        Dim myWriter As New System.IO.StreamWriter("d:\ORDERPEND.csv")
        myString = ""
        Try
            dt = ds.Tables("res")
            For i = 0 To ds.Tables("res").Columns.Count - 1
                If i > 0 Then
                    myString &= (",")
                End If
                myString &= ds.Tables("res").Columns(i).ColumnName
            Next
            myString &= (Environment.NewLine)

            For Each dr As DataRow In dt.Rows
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString &= (",")
                    End If
                    myString &= (field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString &= (Environment.NewLine)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Write the String to the Csv File
        myWriter.WriteLine(myString)
        'Clean up
        myWriter.Close()
        Process.Start("d:\ORDERPEND.csv")
    End Sub
End Class