'Imports System.Data
'Imports System
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Web
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.IO
'Imports iTextSharp.text
'Imports iTextSharp.text.html.simpleparser
'Imports iTextSharp.text.pdf
Public Class US_invoice_automail
    Dim sql As String

    Dim ilsql As String
    Dim invlds As New DataSet
    Dim inv_tot As Double = 0
    Dim TOTQTY As Double = 0
    Dim ds As New DataSet
    'Dim gc As New frm_class
    Private Sub US_invoice_automail_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        '    Inherits System.Web.UI.Page


        '    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        sql = "select "
            sql &= "(select CUSTOMER_NAME from jan_eo_customer_master_BILL_TO where customer_id=A.BILL_TO_CUSTOMER_ID AND site_use_code='BILL_TO' AND SITE_USE_ID=A.BILL_TO_SITE_ID) BILLTO_NAME,"
            sql &= "(select ADDRESS from jan_eo_customer_master_BILL_TO where customer_id=A.BILL_TO_CUSTOMER_ID AND site_use_code='BILL_TO'  AND SITE_USE_ID=A.BILL_TO_SITE_ID) BILLTO_ADDR,"
            sql &= "(select CUSTOMER_NAME from jan_eo_customer_master_ship_to where customer_id=A.SHIP_TO_CUSTOMER_ID AND site_use_code='SHIP_TO'  AND SITE_USE_ID=A.SHIP_TO_SITE_ID) SHIPTO_NAME,"
            sql &= "(select ADDRESS from jan_eo_customer_master_SHIP_TO where customer_id=A.SHIP_TO_CUSTOMER_ID AND site_use_code='SHIP_TO'  AND SITE_USE_ID=A.SHIP_TO_SITE_ID) SHIPTO_ADDR,"
        sql &= "A.TRX_NUMBER,A.TRX_DATE,A.CUSTOMER_PO_NO,A.PAY_TERMS,A.SHIPPING_INSTRUCTIONS,A.TRACKING_NO,NVL(A.OTHER_CHARGES,0) OTHER_CHARGES,NVL(A.FREIGHT_CHARGES,0)FREIGHT_CHARGES,NVL(A.OTHER_CHARGE_DETAILS,0) OTHER_CHARGE_DETAILS,A.*  from jan_eo_customer_trx_all A where trx_number=" &  & " "


        ' Oracle Base
        sql = "SELECT  CUSTOMER_TRX_ID,BILL_TO_CUST_NAME BILLTO_NAME, BILL_TO_ADDRESS BILLTO_ADDR, SHIP_TO_CUST_NAME SHIPTO_NAME, SHIP_TO_ADDRESS SHIPTO_ADDR,"
            sql &= " A.TRX_NUMBER,A.TRX_DATE, C_ORDER_NO CUSTOMER_PO_NO,"

            'sql &= " A.PAY_TERMS,"
            sql &= "  pAYMENT_TERMS PAY_TERMS,"
            sql &= " nvl(A.SHIPPING_INSTRUCTIONS,'-') SHIPPING_INSTRUCTIONS,"
            'sql &= " --A.TRACKING_NO,NVL(A.OTHER_CHARGES,0) OTHER_CHARGES,NVL(A.FREIGHT_CHARGES,0)FREIGHT_CHARGES,NVL(A.OTHER_CHARGE_DETAILS,0) OTHER_CHARGE_DETAILS,"
            sql &= " '-' TRACKING_NO,0 OTHER_CHARGES,0 FREIGHT_CHARGES,0 OTHER_CHARGE_DETAILS,"
            sql &= " A.*  "
            sql &= " from apps.JAN_INVOICE_LISTING_OU A  "
            sql &= " where trx_number='" & txt_inv_no.Text & "' AND ROWNUM=1"
            ' Response.Write(sql)
            ' Exit Sub

            ds = gc.SQL_SELECT("inv_det", sql)
            sql = ""
            With ds.Tables("inv_det").Rows(0)


                fillheader()




                ilsql = "select rownum,package_ref,(SELECT INVOICE_ITEM_NO FROM JAN_EO_ITEM_MASTER WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID) item_no,ITEM_DESCRIPTION,INVOICE_QTY,PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((INVOICE_QTY * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT from jan_eo_customer_trx_lines_all A where customer_trx_id=" & .Item("customer_trx_id") & " order by row_ref"

                ilsql = "select rownum,NULL package_ref,ORDERED_ITEM item_no,DESCRIPTION ITEM_DESCRIPTION,QUANTITY_INVOICED INVOICE_QTY,UOM PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((QUANTITY_INVOICED * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT,C_ORDER_NO,c_order_date FROM apps.JAN_INVOICE_LISTING_OU A "
                ilsql &= " where trx_number='" & txt_inv_no.Text & "'"
                ilsql &= " ORDER BY CUSTOMER_TRX_LINE_ID"

                ilsql = "select rownum,NULL package_ref,NVL((select INVOICE_ITEM_NO from JAN_EO_ITEM_MASTER where INVENTORY_ITEM_ID=(select INVENTORY_ITEM_ID from RA_CUSTOMER_TRX_LINES_ALL where CUSTOMER_TRX_LINE_ID=a.CUSTOMER_TRX_LINE_ID) and rownum=1),(select SEGMENT1 from MTL_SYSTEM_ITEMS where INVENTORY_ITEM_ID=(select INVENTORY_ITEM_ID from RA_CUSTOMER_TRX_LINES_ALL where CUSTOMER_TRX_LINE_ID=a.CUSTOMER_TRX_LINE_ID) and rownum=1)) ITEM_NO,"
                ilsql &= " DESCRIPTION ITEM_DESCRIPTION,QUANTITY_INVOICED INVOICE_QTY,UOM PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((QUANTITY_INVOICED * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT,C_ORDER_NO,c_order_date,tariff_no FROM apps.JAN_INVOICE_LISTING_OU A "
                ilsql &= " where trx_number='" & txt_inv_no.Text & "'"
                ilsql &= " ORDER BY CUSTOMER_TRX_LINE_ID"
                'Response.Write(ilsql)
                'Exit Sub

                invlds = gc.SQL_SELECT("inv_lines", ilsql)

                Dim j As Int16
    Dim brdr As String = "style='BORDER-left: black 1px solid;BORDER-bottom: BLACK 1px solid;' "
    For j = 0 To invlds.Tables("inv_lines").Rows.Count - 1

    With invlds.Tables("inv_lines").Rows(j)
    If IsDBNull(.Item("item_no")) Then
                            sql &= "<tr valign=top height=30px><td class='txt8'  width='5%' style='BORDER-bottom: BLACK 1px solid;'>&nbsp;</td>"
                        Else
                            sql &= "<tr valign=bottom height=30px ><td class='txt8'  width='5%' style='BORDER-bottom: BLACK 1px solid;'>" & j + 1 & "</td>"
                        End If

                        sql &= "<td  width='10%' class='txt8' " & brdr & " nowrap>"
                        If Not IsDBNull(.Item("c_order_no")) Then
                            sql &= .Item("c_order_no")
                        End If
                        sql &= "&nbsp;</td>"
                        sql &= "<td  width='10%' class='txt8' " & brdr & " nowrap>"
                        If Not IsDBNull(.Item("c_order_date")) Then
    Try
                                sql &= Format(CDate(.Item("c_order_date")), "MM-dd-yyyy")
                            Catch ex As Exception
                                sql &= .Item("c_order_date")
                            End Try

    End If
                        sql &= "&nbsp;</td>"

                        If Session.Item("ou_org_id") = "405" Then
                            brdr = "style='BORDER-left: black 1px solid;BORDER-bottom: BLACK 1px solid;' "
                        Else
                            brdr = "style='BORDER-left: black 1px solid;BORDER-bottom: BLACK 1px solid;' "
                        End If

    If IsDBNull(.Item("item_no")) Then

                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'><br>" & .Item("ITEM_DESCRIPTION") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;' align='right'>&nbsp;</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;' align='right'>&nbsp;</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'  align='right'>&nbsp;</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'  align='right'>&nbsp;</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'  align='right' valign='middle'>" & Format(Math.Round(CDbl(.Item("LINE_TOTAL_AMOUNT")), 2), "0.00") & "</td>"
                            sql &= " </tr>"


                        Else

                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'>" & .Item("item_no") & "<br>" & .Item("ITEM_DESCRIPTION") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'>" & .Item("tariff_no") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;' align='right'>" & .Item("INVOICE_QTY") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;' align='right'>" & .Item("PRIMARY_UOM") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("UNIT_SELLING_PRICE")), 2), "0.00") & "</td>"
                            sql &= " <td  class='txt8'  style='BORDER-left: BLACK 1px solid;BORDER-bottom: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("LINE_TOTAL_AMOUNT")), 2), "0.00") & "</td>"
                            sql &= " </tr>"



                            TOTQTY += CDbl(.Item("INVOICE_QTY"))
                        End If


                        inv_tot += Math.Round(CDbl(.Item("LINE_TOTAL_AMOUNT")), 2)

                        If ((j + 1) Mod 18) = 0 And j > 0 Then

                            sql &= "</table><BR /> <center class=txt10>All the Units Invoiced / Packed are made in India.</center>"
                            sql &= "</td></tr>"
                            sql &= "</table>"
                            sql &= "<br style='page-break-after: always;-webkit-region-break-after: always;' />"
                            fillheader()

                        End If

    End With

    Next


    ' sql &= "<tr valign=top height='70%' ><td  width='20%' colspan=9 class='txt8'  align='right' style='BORDER-left: BLACK 0px solid;BORDER-bottom: BLACK 1px solid;'>&nbsp;</td></tr>"
    If CDbl(.Item("FREIGHT_CHARGES")) > 0 Then
    If Session.Item("ou_org_id") = "405" Then
                        sql &= "<tr valign=bottom height='20px'>"
                        sql &= " <td class='txt8'  width='5%'  colspan=5 align=right style='BORDER-top: BLACK 1px solid;BORDER-RIGHT: BLACK 1px solid;'>" & .Item("FREIGHT_CHARGE_details") & "&nbsp;&nbsp;</td>"
                        sql &= " <td  width='20%' class='txt8'  style='BORDER-top: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("FREIGHT_CHARGES")), 2), "0.00") & "</td>"
                        sql &= " </tr>"
                    ElseIf Session.Item("ou_org_id") = "545" Then
                        sql &= "<tr valign=bottom height='20px'>"
                        sql &= " <td class='txt8'  width='5%'  colspan=5 align=right >" & .Item("FREIGHT_CHARGE_details") & "&nbsp;&nbsp;</td>"
                        sql &= " <td  width='20%' class='txt8'   align='right'>" & Format(Math.Round(CDbl(.Item("FREIGHT_CHARGES")), 2), "0.00") & "</td>"
                        sql &= " </tr>"
                    End If

    End If


                inv_tot += Math.Round(CDbl(.Item("FREIGHT_CHARGES")), 2)
                If CDbl(.Item("Other_CHARGES")) > 0 Then
    If Session.Item("ou_org_id") = "405" Then
                        sql &= "<tr valign=bottom height='20px'>"
                        sql &= " <td class='txt8'  width='5%'  colspan=5 align=right style='BORDER-top: BLACK 1px solid;BORDER-RIGHT: BLACK 1px solid;'>" & .Item("OTHER_CHARGE_DETAILS") & "&nbsp;&nbsp;</td>"
                        sql &= " <td  width='20%' class='txt8'  style='BORDER-top: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("Other_CHARGES")), 2), "0.00") & "</td>"
                        sql &= " </tr>"
                    ElseIf Session.Item("ou_org_id") = "545" Then
                        sql &= "<tr valign=bottom height='20px'>"
                        sql &= " <td class='txt8'  width='5%'  colspan=5 align=right >" & .Item("OTHER_CHARGE_DETAILS") & "&nbsp;&nbsp;</td>"
                        sql &= " <td  width='20%' class='txt8'    align='right'>" & Format(Math.Round(CDbl(.Item("Other_CHARGES")), 2), "0.00") & "</td>"
                        sql &= " </tr>"
                    End If
    End If

                inv_tot += Math.Round(CDbl(.Item("Other_CHARGES")), 2)



                If Session.Item("ou_org_id") = "405" Then

                    sql &= "<tr valign=top height='10px'>"

                    sql &= "<td class='txt9W'  width='5%'  colspan=5 align=right BGCOLOR='#BBBBBB' style='BORDER-top: black 1px solid;BORDER-RIGHT: black 1px solid;'><b>Total</td>"

                    sql &= "<td   class='txt9W'  style='BORDER-top: black 1px solid;BORDER-RIGHT: black 1px solid;'  BGCOLOR='#BBBBBB' align='right'>" & TOTQTY & "</td>"

                    sql &= "<td   class='txt9W'  style='BORDER-top: black 1px solid;BORDER-RIGHT: black 1px solid;'  BGCOLOR='#BBBBBB' align='right'>&nbsp;</td>"

                    sql &= "<td   class='txt9W'  style='BORDER-top: black 1px solid;BORDER-RIGHT: black 1px solid;' BGCOLOR='#BBBBBB'  align='right'>&nbsp;</td>"

                    sql &= "<td  class='txt9W'  style='BORDER-top: black 1px solid;BORDER-RIGHT: black 1px solid;' BGCOLOR='#BBBBBB'  align='right'>" & Format(Math.Round(inv_tot, 2), "0.00") & "</td>"

                    sql &= "</tr>"

                    sql &= "</table>"
                    sql &= "</td>"
                    sql &= "</tr>"
                    sql &= "<tr valign=bottom><td align=left  colspan=3 class=txt9><br><br><br><br>Authorized Signatory"
                    sql &= "<br><br><br><center class=txt10>All the Units Invoiced / Packed are made in India. <BR /> We appreciate your business and thank you for it !</center>"
                    sql &= "</td></tr>"

                    sql &= "</table>"

                ElseIf Session.Item("ou_org_id") = "545" Then

                    sql &= "<tr valign=MIDDLE height='30px' >"

                    sql &= "<td class='txt9'  width='5%'  colspan=5 align=right style='BORDER-left: BLACK 0px solid;' ><b>Total</td>"

                    sql &= "<td   class='txt9' align='right' style='BORDER-left: BLACK 1px solid;'><B>" & TOTQTY & "</td>"

                    sql &= "<td   class='txt9' align='right' style='BORDER-left: BLACK 1px solid;'>&nbsp;</td>"

                    sql &= "<td   class='txt9' align='right' style='BORDER-left: BLACK 1px solid;'>&nbsp;</td>"

                    sql &= "<td  class='txt9'  align='right' style='BORDER-left: BLACK 1px solid;'><B>" & Session.Item("CURRENCY") & " " & Format(Math.Round(inv_tot, 2), "0.00") & "</td>"

                    sql &= "</tr>"



                    sql &= "</table>"
                    sql &= "</td>"
                    sql &= "</tr>"
                    sql &= "<tr valign=bottom>"
                    sql &= "<td align=left colspan=2 class=txt9>"
                    sql &= "<table width=100% class=txt9>"
                    sql &= "<td width=20%>"
                    sql &= "<b>JANATICS PNEUMATIK GmbH</b><br>Hertichstraße, 31/1<br>D-71229 Leonberg,<br>Germany"
                    sql &= "</td>"
                    sql &= "<td align=center width=50%>"
                    sql &= "USt-Id-Nr. DE311224267<BR>HRB 759984 Amtsgericht Stuttgart<br>Geschaftsfuhrer: Helmet Schmidtmann"

                    sql &= "</td>"
                    sql &= "<td >"
                    sql &= "BLZ/Bank code 60040071<br>Kontonr. 6251409<br>IBAN:DE74 6004 0071 0625 1409 00<BR>BIC: COBAFFXXX"
                    sql &= "</td>"

                    sql &= "</tr>"

                    sql &= "</table>"

                    sql &= "</td>"
                    sql &= "</tr>"



                    sql &= "</table>"

                End If



                sql &= "</body>"
                sql &= "</html>"

            End With
writeinv:
    Me.Controls.Clear()
            Response.Write(sql)
            'Label1.Text = sql
            '  DownloadAsPDF()
        End Sub

    Private Sub fillheader()

        With ds.Tables("inv_det").Rows(0)

            If Session.Item("ou_org_id") = "405" Then


                sql &= "<html>"
                sql &= "<head><title>Invoice No :" & .Item("trx_number") & "</title> <link href='expcss.css' rel='stylesheet' type='text/css'/></head>"
                sql &= "<body><div style='position:absolute;width:100%;z-index:0' align='center'><table width=90% border=0 cellpadding=0 cellspacing=0><tr><td align=right><img src='Images/Jana_logo.png' /></td></tr></table></div><br><BR><BR>"

                sql &= "<table style='height:95%;width:90%' align=center border=0 cellspacing=3 cellpadding=0>"

                sql &= "<tr valign=top height='10px'>"
                sql &= "<td colspan=2 style='width:50%' align='center' valign='bottom' class='txthdrr'>INVOICE</td>"
                sql &= "</tr>"


                sql &= "<tr valign=top height='10px'>"

                If Session.Item("ou_org_id") = "405" Then

                    sql &= "<td style='width:50%' valign='top' align='left'  class='txt10' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;padding-top:10px;padding-left:10px;padding-bottom:10px;'><b>JANATICS USA INC</b><br>1275 Glenlivet Drive Suite 100,<br />Allentown, <br />PA 18106, USA,<br>Phone : 16107371695<br>E-mail : seshb@janaticsusa.com</td>"

                ElseIf Session.Item("ou_org_id") = "545" Then

                    sql &= "<td style='width:50%' valign='top' align='left'  class='txt10' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;padding-top:10px;padding-left:10px;padding-bottom:10px;'><b>JANATICS PNEUMATIK GmbH</b><br>Hertichstraße, 31/1<br>71229 Leonberg, Germany<br>Tel.: (49) 7152/9013440<br>Fax.: (49) 7152/9013442<br>E-mail : info@janaticspneumatik.de</td>"

                End If



                sql &= "<td style='width:50%;padding-top:0px;padding-bottom:0px;padding-left:0px;padding-right:0px' align='right' valign='bottom'>"

                sql &= "<table height='100%' width='100%' align=center border=0 cellspacing=0 cellpadding=2> "

                sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Invoice No&nbsp;&nbsp;</td><td class='txt9'  style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & .Item("trx_number") & "&nbsp;&nbsp;</td></tr>"

                If Session.Item("ou_org_id") = "405" Then

                    sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Invoice Date&nbsp;&nbsp;</td><td class='txt9' style='width:100%;BORDER-RIGHT: black 1px solid;  WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & Format(CDate(.Item("trx_date")), "MM") & "/" & Format(CDate(.Item("trx_date")), "dd") & "/" & Format(CDate(.Item("trx_date")), "yyyy") & "&nbsp;&nbsp;</td></tr>"

                ElseIf Session.Item("ou_org_id") = "545" Then

                    sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Invoice Datum&nbsp;&nbsp;</td><td class='txt9' style='width:100%;BORDER-RIGHT: black 1px solid;  WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & Format(CDate(.Item("trx_date")), "dd. MMM. yyyy") & "&nbsp;&nbsp;</td></tr>"

                End If


                '  sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>PO/Contract Ref &nbsp;&nbsp;</td><td class='txt9' style='width:100%;BORDER-RIGHT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & gc.ret_val("SELECT ROWTOCOL('SELECT DISTINCT C_ORDER_NO FROM apps.JAN_INVOICE_LISTING_OU A where C_ORDER_NO IS NOT NULL AND CUSTOMER_TRX_ID=" & .Item("CUSTOMER_TRX_ID") & "') FROM DUAL") & "&nbsp;&nbsp;</td></tr>"
                '  sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Fed EIN&nbsp;&nbsp;</td><td class='txt9'  style='width:100%;BORDER-RIGHT: black 1px solid;  WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>45 - 2680687&nbsp;&nbsp;</td></tr>"

                '  sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>PA Sales Tax No&nbsp;&nbsp;</td><td class='txt9'  style='width:100%;BORDER-RIGHT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>85489792&nbsp;&nbsp;</td></tr>"

                sql &= "</table>"

                sql &= "</td>"

                sql &= "</tr>"

                'Bill to Ship to


                sql &= "<tr valign=top  height='100px'>"

                sql &= "<td colspan=2 style='width:50%;padding-top:3px;padding-bottom:0px;padding-left:0px;padding-right:0px' align='right' valign='bottom'>"

                'Bill to

                sql &= "<table  style='width:100%' align=center border=0 cellspacing=0 cellpadding=0>"

                sql &= "<tr>"

                sql &= "<td style='padding-top:0px;padding-bottom:0px' width='50%'>"

                sql &= "<table  style='width:100%;HEIGHT:120px;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid' align=center border=0 cellspacing=0 cellpadding=2> "
                sql &= "<tr height='10px'><td class='txt9w' bgcolor='#BBBBBB'>Bill To</td></tr>"
                sql &= "<tr valign='top'><td class='txt9'><b>" & .Item("BILLTO_NAME") & "</b>&nbsp;&nbsp;<br>" & .Item("BILLTO_ADDR").ToString.Replace(",-,", ",").Replace(",,", ",").Replace(", ,", "#").Replace(",", "&nbsp;&nbsp;<BR>") & "</td></tr>"
                sql &= "</table>"

                sql &= "</td>"

                sql &= "<td style='padding-top:0px;padding-bottom:0px' width='5px'>&nbsp</td>"

                sql &= "<td style='padding-top:0px;padding-bottom:0px' width='50%'>"

                sql &= "<table  style='width:100%;HEIGHT:120px;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid' align=center border=0 cellspacing=0 cellpadding=2> "
                sql &= "<tr height='10px'><td class='txt9w' bgcolor='#BBBBBB'>Ship To</td></tr>"
                sql &= "<tr valign='top'><td class='txt9'><b>" & .Item("SHIPTO_NAME") & "</b>&nbsp;&nbsp;<br>" & .Item("SHIPTO_ADDR").ToString.Replace(",-,", ",").Replace(", ,", ",").Replace(",,", "#").Replace(",", "&nbsp;&nbsp;<BR>") & "</td></tr>"
                sql &= "</table>"

                sql &= "</td>"


                sql &= "</tr>"

                sql &= "</table>"

                sql &= "</td></tr>"


                sql &= "<tr valign=top height='10px'>" 'Row 3

                sql &= "<td colspan=2 style='padding-top:3px;padding-bottom:0px'>"

                sql &= "<table  style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid' align=center border=0 cellspacing=0 cellpadding=2> "
                sql &= "<tr><td class='txt8w' bgcolor='#BBBBBB' width='25%'>Terms</td><td  width='25%' class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>Mode of Payment</td><td  width='25%' class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>Ship Via</td><td  width='25%' class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>Tracking No</td></tr>"
                sql &= "<tr><td class='txt8' >" & UCase(.Item("PAY_TERMS")) & "&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>Cheque&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>" & UCase(.Item("shipping_instructions")) & "&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>" & .Item("tracking_no") & "&nbsp;&nbsp;</td></tr>"
                sql &= "</table>"

                sql &= "</td>"
                sql &= "</tr>"

                'Item List

                sql &= "<tr valign=top  height='70%'>" 'Row 4

                sql &= "<td colspan=2 style='padding-top:3px;padding-bottom:0px' valign=top>"

                sql &= "<table  style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid' align=center border=0 cellspacing=0 cellpadding=2> "
                sql &= "<tr valign=bottom height='10%'><td class='txt8w' bgcolor='#BBBBBB' width='5%'>S.No</td>"

                sql &= "<td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>PO/Contract No</td>"
                sql &= "<td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>PO/Contract Date</td>"

                sql &= "<td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>Item No<br>Description</td>"
                sql &= "<td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'>HS Code</td>"
                sql &= " <td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;' align='right'>Qty</td>"
                sql &= " <td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;' align='right'>UOM</td>"
                sql &= " <td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'  align='right'>Unit Price</td>"
                sql &= " <td class='txt8w' bgcolor='#BBBBBB' style='BORDER-left: black 1px solid;'  align='right'>Amount</td>"
                sql &= " </tr>"

            ElseIf Session.Item("ou_org_id") = "545" Then
                sql &= "<html>"
                sql &= "<head><title>Invoice No :" & .Item("trx_number") & "</title> <link href='expcss.css' rel='stylesheet' type='text/css'/></head>"
                sql &= "<body><br><br><table width=95% border=0 cellpadding=0 cellspacing=0><tr><td align=right><img src='Images/Janaticsgmbhlogo.png' width='200px' /></td></tr></table>"

                sql &= "<table style='height:90%;width:90%' align=center border=0 cellspacing=3 cellpadding=0>"
                sql &= "<tr valign=top height='40px'>"
                sql &= "<td colspan=2 style='width:50%' valign='top' class='txt10'><b>JANATICS PNEUMATIK GmbH . </b> Hertichstraße, 31/1 D-71229 Leonberg, Germany</td>"
                sql &= "</tr>"
                sql &= "<tr valign=top height='10px'>"

                sql &= "<td class='txt9'><b>Billed to :</b> <br>" & .Item("BILLTO_NAME") & "&nbsp;&nbsp;<br>" & .Item("BILLTO_ADDR").ToString.Replace(",-,", ",").Replace(",,", ",").Replace(", ,", "#").Replace(",", "&nbsp;&nbsp;<BR>").Replace("#", "<br>")
                sql &= "<br><b>Delivery at :</b><br> " & .Item("SHIPTO_NAME") & "&nbsp;&nbsp;<br>" & .Item("SHIPTO_ADDR").ToString.Replace(",-,", ",").Replace(", ,", ",").Replace(",,", "#").Replace(",", "&nbsp;&nbsp;<BR>")

                sql &= "</td>"

                sql &= "<td style='width:50%' valign='top' align='right'  class='txt10' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;padding-top:10px;padding-left:10px;padding-bottom:10px;'>Hertichstraße, 31/1<br>71229 Leonberg, Germany<br>Tel.: (49) 7152/9013440<br>Fax.: (49) 7152/9013442<br>E-mail : info@janaticspneumatik.de<BR><BR>Datum : " & Format(CDate(.Item("trx_date")), "dd. MMM. yyyy") & "</td>"

                sql &= "</tr>"

                sql &= "<tr valign=top height='30px'>"
                sql &= "<td colspan=2 style='width:50%' valign='middle' class='txt10'><b>Rechnung / Invoice No. " & .Item("trx_number") & "</b></td>"
                sql &= "</tr>"




                'sql &= "<tr valign=top height='10px'>" 'Row 3

                'sql &= "<td colspan=2 style='padding-top:3px;padding-bottom:0px'>"

                'sql &= "<table  style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid' align=center border=0 cellspacing=0 cellpadding=2> "
                'sql &= "<tr><td class='txt8' width='25%'>Terms</td><td  width='25%' class='txt8' style='BORDER-left: black 1px solid;'>Mode of Payment</td><td  width='25%' class='txt8' style='BORDER-left: black 1px solid;'>Ship Via</td><td  width='25%' class='txt8'  style='BORDER-left: black 1px solid;'>Tracking No</td></tr>"
                'sql &= "<tr><td class='txt8' >" & UCase(.Item("PAY_TERMS")) & "&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>Cheque&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>" & UCase(.Item("shipping_instructions")) & "&nbsp;&nbsp;</td><td class='txt8' style='BORDER-left: black 1px solid;'>" & .Item("tracking_no") & "&nbsp;&nbsp;</td></tr>"
                'sql &= "</table>"

                'sql &= "</td>"
                'sql &= "</tr>"

                'Item List

                sql &= "<tr valign=top  height='55%'>" 'Row 4

                sql &= "<td colspan=2 style='padding-top:3px;padding-bottom:0px' valign=top>"

                sql &= "<table    style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid' class='txt8' align=center border=0 cellspacing=0 cellpadding=2> "
                sql &= "<tr valign=top height='20px' ><td class='txt8'  width='5%' style='border-bottom: 1px solid black !important;'><b>Item</td>"

                sql &= "<td class='txt8' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;'><b>PO/Contract No</td>"
                sql &= "<td class='txt8' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;'><b>PO/Contract Date</td>"

                sql &= "<td class='txt8' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;'><b>Code<BR>Description </td>"
                sql &= "<td class='txt8' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;'><b>HS Code</td>"
                sql &= " <td class='txt8' align='right' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;' width='5%'><b>Quantity</td>"
                sql &= " <td class='txt8' align='right' style='border-bottom: 1px solid black ;BORDER-left: black 1px solid; !important;' width='5%'><b>UOM</td>"
                sql &= " <td class='txt8'  align='right' style='border-bottom: 1px solid black ;BORDER-left: black 1px solid; !important;'><b>Price " & Session.Item("Currency") & "</td>"
                sql &= " <td class='txt8'  align='right' style='border-bottom: 1px solid black;BORDER-left: black 1px solid; !important;'><b>Total " & Session.Item("Currency") & "</td>"
                sql &= " </tr>"

            End If
        End With

    '    End Sub
    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        If Session.Item("invoice_print") = "" Then

    '            Me.Controls.Clear()

    '            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>" & vbCrLf)

    '            System.Web.HttpContext.Current.Response.Write("parent.location.replace('default.htm');")

    '            System.Web.HttpContext.Current.Response.Write(vbCrLf & "</script>")

    '            Exit Sub

    '        End If
    '        txt_inv_no.Text = Session.Item("invoice_print")
    '        Button1_Click(sender, e)
    '        'Response.Write("<script>window.print();</script>")
    '        'Session.Item("invoice_print") = ""

    '    End Sub
    '    Public Sub DownloadAsPDF()

    '        Try
    '            Dim strHtml As String = String.Empty
    '            Dim pdfFileName As String = Request.PhysicalApplicationPath + "\\files\\" + "GenerateHTMLTOPDF.pdf"

    '            Dim sw As StringWriter = New StringWriter()
    '            Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
    '            Label1.RenderControl(hw)
    '            Dim sr As StringReader = New StringReader(sw.ToString())
    '            strHtml = sr.ReadToEnd()
    '            sr.Close()

    '            CreatePDFFromHTMLFile(strHtml, pdfFileName)

    '            Response.ContentType = "application/x-download"
    '            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=""{0}""", "GenerateHTMLTOPDF.pdf"))
    '            Response.WriteFile(pdfFileName)
    '            Response.Flush()
    '            Response.End()
    '        Catch ex As Exception
    '            Response.Write(ex.Message)
    '        End Try


    '    End Sub

    '    Public Sub CreatePDFFromHTMLFile(ByVal HtmlStream As String, ByVal FileName As String)
    '        Try
    '            Dim TargetFile As Object = FileName
    '            Dim ModifiedFileName As String = String.Empty
    '            Dim FinalFileName As String = String.Empty


    '            Dim builder As New GeneratePDF.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4)
    '            Dim first As GeneratePDF.HtmlPdfPage = builder.AddPage()
    '            first.AppendHtml(HtmlStream)
    '            Dim file__1 As Byte() = builder.RenderPdf()
    '            File.WriteAllBytes(TargetFile.ToString(), file__1)

    '            Dim reader As New iTextSharp.text.pdf.PdfReader(TargetFile.ToString())
    '            ModifiedFileName = TargetFile.ToString()
    '            ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1")

    '            iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, New FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, "", "", iTextSharp.text.pdf.PdfWriter.AllowPrinting)
    '            reader.Close()
    '            If File.Exists(TargetFile.ToString()) Then
    '                File.Delete(TargetFile.ToString())
    '            End If
    '            FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1)
    '            File.Copy(ModifiedFileName, FinalFileName)
    '            If File.Exists(ModifiedFileName) Then
    '                File.Delete(ModifiedFileName)

    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Protected Sub Button1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Load

    '    End Sub
End Class


