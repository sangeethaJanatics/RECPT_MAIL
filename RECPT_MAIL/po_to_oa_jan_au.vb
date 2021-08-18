Imports System.Data.OracleClient

Public Class po_to_oa_jan_au
    Dim vendor_address As String
    Private Sub btn_show_lines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show_lines.Click
        If chk_1_yr_po.Checked = True Then

            If txt_need_by_from.Text = "" Or txt_need_by_to.Text = "" Then
                MessageBox.Show("Select Need by Date From and To  , then interface the OA", "OA Interface", MessageBoxButtons.OK)
                Exit Sub
            End If
        End If

        If txt_po_no1.Text <> "" Or txt_po_no2.Text <> "" Or txt_po_no3.Text <> "" Or txt_po_no4.Text <> "" Then

            sql = "select POH.SEGMENT1 PO_NO,POH.CREATION_DATE PO_DATE,JAN_ORGCODE(SHIP_TO_ORGANIZATION_ID)ORG "

            sql &= " ,JAN_ITEMNAME(POL.ITEM_ID)ITEM_NO"

            If chk_1_yr_po.Checked = True Then
                sql &= " ,POLL.QUANTITY"
            Else
                sql &= " ,POLl.QUANTITY"
            End If


            sql &= " ,ROUND(NVL((POL.UNIT_PRICE),0),2)*NVL(POH.RATE,1) PO_RATE,poll.need_by_date ,POH.VENDOR_SITE_ID,(select VENDOR_NAME from PO_VENDORS where VENDOR_ID=POH.VENDOR_ID)VENDOR_NAME,POH.VENDOR_ID,(select address_line1 from PO_VENDOR_SITES_ALL where  vendor_ID=poh.vendor_id and vendor_site_id=POH.VENDOR_SITE_ID)vendor_address"

            sql &= " ,(SELECT MAX(ORGANIZATION_ID) FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=POL.ITEM_ID "

            'If vendor_address.Contains("BODIPALAYAM") Then

            '    sql &= " AND ORGANIZATION_ID IN (444,464,484,504,505,524) "
            'Else
            sql &= " AND ORGANIZATION_ID=604 "
            'End If


            sql &= " AND DECODE(INVENTORY_ITEM_STATUS_CODE,'Active','1',0)+DECODE(CUSTOMER_ORDER_FLAG,'Y',1,0)+DECODE(CUSTOMER_ORDER_ENABLED_FLAG,'Y',1,0)+DECODE(SHIPPABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICEABLE_ITEM_FLAG,'Y',1,0)+DECODE(INVOICE_ENABLED_FLAG,'Y',1,0)+DECODE(RESERVABLE_TYPE,1,1,0)=7) order_ORG "

            sql &= "  FROM PO_HEADERS_ALL POH ,PO_LINES_ALL POL ,PO_LINE_LOCATIONS_ALL POLL WHERE POH.PO_HEADER_ID=POL.PO_HEADER_ID AND POL.PO_LINE_ID=POLL.PO_LINE_ID  and POH.SEGMENT1 in ("


            If txt_po_no1.Text <> "" Then sql &= " '" & Trim(txt_po_no1.Text) & "' "
            If txt_po_no2.Text <> "" Then sql &= " ,'" & Trim(txt_po_no2.Text) & "' "
            If txt_po_no3.Text <> "" Then sql &= " ,'" & Trim(txt_po_no3.Text) & "' "
            If txt_po_no4.Text <> "" Then sql &= " ,'" & Trim(txt_po_no4.Text) & "' "

            sql &= " ) "

            If chk_1_yr_po.Checked = True Then
                sql &= " and POLL.QUANTITY>0  and poll.need_by_date>='" & txt_need_by_from.Text & "' and poll.need_by_date<='" & txt_need_by_to.Text & "' and "
                sql &= " poll.po_release_id  IN (SELECT po_release_id  FROM PO_RELEASES_ALL WHERE PO_HEADER_ID IN (SELECT PO_HEADER_ID FROM PO_HEADERS_ALL WHERE SEGMENT1 IN ("

                If txt_po_no1.Text <> "" Then sql &= " '" & Trim(txt_po_no1.Text) & "' "
                If txt_po_no2.Text <> "" Then sql &= " ,'" & Trim(txt_po_no2.Text) & "' "
                If txt_po_no3.Text <> "" Then sql &= " ,'" & Trim(txt_po_no3.Text) & "' "
                If txt_po_no4.Text <> "" Then sql &= " ,'" & Trim(txt_po_no4.Text) & "' "
                sql &= " ))"
                'poll.po_release_id = " & cmb_po_release_no.SelectedValue & """
                If cmb_po_release_no.Text <> "" Then
                    sql &= " and release_num=" & cmb_po_release_no.Text & ""
                End If
                sql &= " ) "
            Else
                'sql &= " and POL.QUANTITY>0 "

            End If

            sql &= " and NVL(pol.closed_code,'-')<>'CLOSED'  and (POLl.QUANTITY-poll.quantity_received)>0" 'condition added on 29jan2021
            sql &= " order by po_no,item_no"

            adap = New OracleDataAdapter(sql, con)
            ds = New DataSet
            adap.Fill(ds, "result")


            dgv1.DataSource = ds.Tables("result")
            For i = 0 To dgv1.RowCount - 1
                With dgv1.Rows(i)
                    If IsDBNull(.Cells("order_ORG").Value) Then
                        .Cells("order_ORG").Style.BackColor = Color.Red
                    End If



                End With
            Next
        Else
            MessageBox.Show("Enter PO Number & View Details ...")

        End If
    End Sub
    Private Sub btn_move_to_stg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_to_stg.Click
        For i = 0 To dgv1.RowCount - 1
            With dgv1.Rows(i)
                If .Cells("order_ORG") Is DBNull.Value Then
                    MessageBox.Show("Enable order Enable Flag for the item " & .Cells("item_no").Value & " then create the order", "Po to OA Creation", MessageBoxButtons.OK)
                    Exit Sub
                End If

            End With
        Next


        For i = 0 To dgv1.RowCount - 1
            With dgv1.Rows(i)

                If i = 0 Then
                    sql = "insert into jan_so_header_stg "
                    sql &= " (LEGACY_SO_NUM,CUSTOMER_NAME ,CUSTOMER_NO,CUSTOMER_ID,BILL_TO ,SHIP_TO ,TRANSACTION_TYPE ,CUSTOMER_PO_NO,CUSTOMER_PO_DT,ORDER_DATE ,PRICE_LIST ,PAYMENT_TERMS ,PACKING_INSTRUCTION,VERIFY_FLAG,OE_DMS_ORDER_HEADER_ID,CUSTOMER_PO_REF,OE_DSP_ID,CUST_PO_DT,CUST_PO_DT_CHAR,SHIP_TO_CUSTOMER_ID,SHIP_TO_SITE_ID) values(jan_so_seq.nextval"

                    If .Cells("org").Value = "I61" Then

                        sql &= ",'JANATICS INDUSTRIAL AUTOMATION PRIVATE LIMITED',(select customer_number from ra_customers where customer_name='JANATICS INDUSTRIAL AUTOMATION PRIVATE LIMITED'),(select customer_id from ra_customers where customer_name='JANATICS INDUSTRIAL AUTOMATION PRIVATE LIMITED'),"
                        sql &= "'COIMBATORE','COIMBATORE'"
                    End If


                    sql &= ",'Regular-Janatics Automation' " ' Sales Order type created on 15jul2019

                    ',bill_to ,ship_to ,transaction_type
                    sql &= ",'" & .Cells("PO_NO").Value & "','" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "' ,sysdate,'JANA_STOCK_TRANSFER','120 Days',NULL,'N',JAN_TEST_SEQ.NEXTVAL,'" & .Cells("PO_NO").Value & "',0,'" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "',to_char(to_date('" & Format(.Cells("PO_DATE").Value, "dd-MMM-yyyy") & "'),'DD-MON-YYYY'),NULL,NULL"
                    sql &= " )"

                    comand()
                End If

                sql = " INSERT INTO JAN_SO_LINES_STG(LEGACY_SO_NUM ,LINE_NUM ,ITEM_CODE ,UOM,LINE_TYPE ,QTY ,PRICE_UNIT ,REQUEST_DATE ,SCHEDULED_SHIP_DATE ,VERIFY_FLAG,ORGANIZATION_ID,OE_DMS_ORDER_HEADER_ID,CUST_PO_REF)  VALUES(JAN_SO_SEQ.CURRVAL," & i + 1 & ",'" & .Cells("ITEM_NO").Value & "',(SELECT PRIMARY_UOM_CODE FROM MTL_SYSTEM_ITEMS WHERE INVENTORY_ITEM_ID=JAN_ITEMNO('" & .Cells("ITEM_NO").Value & "') AND ORGANIZATION_ID=" & .Cells("order_ORG").Value & "),'Automation Standard Ship Line'," & .Cells("QUANTITY").Value & "," & .Cells("PO_RATE").Value & ",SYSDATE,SYSDATE,'N'," & .Cells("order_ORG").Value & ",jan_test_seq.CURRval,'" & .Cells("PO_NO").Value & "')" ','" & Format(.Cells("need_by_date").Value, "dd-MMM-yyyy") & "'
                comand()

            End With
        Next
        MessageBox.Show("Order Lines moved to Staging", "Stock Transfer OA ", MessageBoxButtons.OK)
    End Sub
    Private Sub btn_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_interface.Click
        Dim order_id As Integer

        sql = "SELECT DISTINCT OE_DMS_ORDER_HEADER_ID FROM JAN_SO_HEADER_STG WHERE CUSTOMER_PO_NO IN ("

        If txt_po_no1.Text <> "" Then sql &= " '" & Trim(txt_po_no1.Text) & "' "
        If txt_po_no2.Text <> "" Then sql &= " ,'" & Trim(txt_po_no2.Text) & "' "
        If txt_po_no3.Text <> "" Then sql &= " ,'" & Trim(txt_po_no3.Text) & "' "
        If txt_po_no4.Text <> "" Then sql &= " ,'" & Trim(txt_po_no4.Text) & "' "

        sql &= " ) order by OE_DMS_ORDER_HEADER_ID desc"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        order_id = ds.Tables("data").Rows(0).Item("OE_DMS_ORDER_HEADER_ID")

        sql = "declare begin  JAN_SO_API_STOCK_TRANSFER(" & ds.Tables("data").Rows(0).Item("OE_DMS_ORDER_HEADER_ID") & "); end;"
        comand()

        sql = "SELECT decode(verify_flag,'Y','Lines Moved to Interface','Lines not Moved to Interface')status FROM JAN_SO_HEADER_STG WHERE OE_DMS_ORDER_HEADER_ID=" & order_id & ""
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        MessageBox.Show("Order Lines Status :" & ds.Tables("data").Rows(0).Item("status") & "", "PO to OA Creation", MessageBoxButtons.OK)
    End Sub

    Private Sub btn_view_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_order.Click
        sql = "select distinct (select ORDER_NUMBER from OE_ORDER_HEADERS_ALL where HEADER_ID=a.HEADER_ID ) ORDER_NUMBER from OE_ORDER_LINES_ALL a where header_id in (select header_id from OE_ORDER_HEADERS_ALL where TRUNC(ORDERED_DATE)=TRUNC(sysdate)  and flow_status_code<>'CANCELLED') and attribute6 IN ( "

        If txt_po_no1.Text <> "" Then sql &= " '" & Trim(txt_po_no1.Text) & "' "
        If txt_po_no2.Text <> "" Then sql &= " ,'" & Trim(txt_po_no2.Text) & "' "
        If txt_po_no3.Text <> "" Then sql &= " ,'" & Trim(txt_po_no3.Text) & "' "
        If txt_po_no4.Text <> "" Then sql &= " ,'" & Trim(txt_po_no4.Text) & "' "

        sql &= " ) "
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        If ds.Tables("data").Rows.Count > 0 Then
            MessageBox.Show("Order Created for this PO :" & ds.Tables("data").Rows(0).Item("ORDER_NUMBER") & "", "PO to OA Creation ", MessageBoxButtons.OK)

        Else
            MessageBox.Show("Order Not Created for this PO ", "PO to OA Creation ", MessageBoxButtons.OK)

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cal_need_by_1.Visible = True

    End Sub
    Private Sub cal_need_by_1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles cal_need_by_1.DateChanged
        txt_need_by_from.Text = Format(cal_need_by_1.SelectionStart, "dd-MMM-yyyy")
        cal_need_by_1.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cal_need_by_2.Visible = True
    End Sub

    Private Sub cal_need_by_2_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles cal_need_by_2.DateChanged
        txt_need_by_to.Text = Format(cal_need_by_2.SelectionStart, "dd-MMM-yyyy")
        cal_need_by_2.Visible = False
    End Sub
    Private Sub chk_1_yr_po_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_1_yr_po.CheckedChanged
        If chk_1_yr_po.Checked = True Then
            sql = " select release_num,po_release_id from po_releases_all where po_header_id=(select po_header_id from po_headers_all where segment1='" & txt_po_no1.Text & "') order by release_num"
            adap = New OracleDataAdapter(sql, con)
            ds = New DataSet
            adap.Fill(ds, "data")
            cmb_po_release_no.DataSource = ds.Tables("data")
            cmb_po_release_no.DisplayMember = "release_num"
            cmb_po_release_no.ValueMember = "po_release_id"
        Else
            cmb_po_release_no.DataSource = Nothing
            'cmb_po_release_no.DisplayMember = "release_num"
        End If

    End Sub

    Private Sub po_to_oa_jan_au_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class