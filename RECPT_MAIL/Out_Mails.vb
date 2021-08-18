Imports System.IO
Imports System.Data.OracleClient
Imports System.Threading
Public Class Out_Mails
    'Dim dr As Odbc.OdbcDataReader
    Dim head, previous_mail As String
    Dim orcon As New OracleClient.OracleConnection("uid=jan_it;pwd=janapps;server=PROD")
    'Dim ii As Integer

    'Private Sub Out_Mails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    'btn_send_Click(sender, e)
    '    'Me.Close()
    '    'End
    'End Sub
   
    Private Sub payment_receipt()

        If Not Directory.Exists("D:\payment receipt") Then
            Directory.CreateDirectory("D:\payment receipt")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\payment receipt")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        Dim inv_null_flag As String
        Dim receipt_dt As Date
        receipt_dt = DateTimePicker1.Value
       
        ds = New DataSet

        sql = "SELECT DISTINCT pay_from_customer customer_id,customer_name,REGION,customer_class_code FROM ("

        sql &= " SELECT a.*,(SELECT ter.segment14 FROM ra_site_uses_all sit,ra_territories ter WHERE sit.territory_id=ter.territory_id AND sit.site_use_id=a.customer_site_use_id)region ,"

        sql &= " (select customer_name from ra_customers where customer_id=a.pay_from_customer)customer_name,"

        sql &= " (SELECT customer_class_code FROM ra_customers WHERE customer_id=a.pay_from_customer)customer_class_code "

        sql &= " FROM AR_CASH_RECEIPTS_ALL A WHERE  trunc(creation_date)='" & Format(receipt_dt, "dd-MMM-yyyy") & "' AND pay_from_customer IS NOT NULL AND pay_from_customer NOT IN (SELECT customer_id FROM jan_customer_mail_exception WHERE mail_id=3)) "

        sql &= " where customer_class_code not in ('E1 SALES','OTHERS')  and region not in ('CBE 1','NOT LISTED')  "
        'and region not in ('CBE 1','NOT LISTED','EXPORT')"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                If .Item("customer_class_code") <> "DEALER" Then


                    inv_null_flag = "N"


                    sql = "SELECT CURRENCY_CODE,RECEIPT_NUMBER,A.CUSTOMER_RECEIPT_REFERENCE ch_no,A.POSTMARK_DATE CH_dt,A.COMMENTS BANK_NAME,A.AMOUNT ,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.PAY_FROM_CUSTOMER)CUST_NAME,A.PAY_FROM_CUSTOMER CUST_ID,(SELECT NAME  FROM ar_receipt_methods WHERE RECEIPT_METHOD_ID=A.RECEIPT_METHOD_ID)METHOD,rowtocol('SELECT DISTINCT c.trx_number||''  /  ''||c.trx_date||''  /  ''||d.bill_to_site  FROM ar_receivable_applications_all b,ra_customer_trx_all c,jan_invoice_listing d WHERE b.applied_customer_trx_id=c.customer_trx_id  and  c.customer_trx_id=d.customer_trx_id AND b.status=''APP'' AND b.cash_receipt_id='||a.cash_receipt_id||'')inv   FROM ar_cash_receipts_all A WHERE trunc(creation_date)='" & Format(receipt_dt, "dd-MMM-yyyy") & "' and pay_from_customer=" & .Item("customer_id") & ""
                    adap = New OracleDataAdapter(sql, con)
                    ds1 = New DataSet
                    adap.Fill(ds1, "pay")


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                    S &= "<table width=80% align=center class=tab>"

                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Dear Customer,</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>We thank you very much for your continued support.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We hereby acknowledge the payment received from you as given below:</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr></tr>"
                    S &= "<tr><td><table width=100% align=left class=tab  border=1 cellpadding=0 cellspacing=0>"
                    S &= "<tr><th>Sl.no</th><th>Payment Details **</th><th>Amount in " & ds1.Tables("pay").Rows(0).Item("CURRENCY_CODE") & "</th><th>Bank Details</th><th>Payment made against<br>our invoice nos</th></tr>"

                    For j = 0 To ds1.Tables("pay").Rows.Count - 1
                        S &= "<tr><td align=center>" & j + 1 & "</td>"

                        S &= "<td><table  class=tab><tr><td>Mode of payment  </td><td>:" & ds1.Tables("pay").Rows(j).Item("method") & "</td></tr><tr><td>Cheque No        </td><td>:" & ds1.Tables("pay").Rows(j).Item("ch_no") & "</td></tr><tr><td>Cheque Date     </td><td>:" & ds1.Tables("pay").Rows(j).Item("ch_dt") & "</td></tr></table></td>"

                        S &= "<td align=right>" & Format(ds1.Tables("pay").Rows(j).Item("amount"), "00.00") & "</td><td  align=center>" & ds1.Tables("pay").Rows(j).Item("bank_name") & "</td>"


                        If IsDBNull(ds1.Tables("pay").Rows(j).Item("inv")) Then

                            S &= "<td  align=left>Please send us the Invoice details immediately which will help us to account accordingly.</td></tr>"
                            inv_null_flag = "Y"
                        Else
                            S &= "<td  align=left>" & ds1.Tables("pay").Rows(j).Item("inv").ToString.Replace(",", "<br>") & "</td></tr>"
                        End If

                    Next

                    S &= "</table></td></tr>"

                    S &= "<tr></tr>"

                    If inv_null_flag = "Y" Then

                        S &= "<tr><td>Please be informed that your payment outstanding details and the accounts statements are available in our exclusive customer portal website <b><a href=""http://www.janaticscrm.net"">www.janaticscrm.net</a></b>. </td></tr>"
                        S &= "<tr></tr>"

                    End If

                    S &= "<tr></tr>"

                    S &= "<tr><td>Assuring you of our Best Services always .</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                    S &= "<tr></tr>"


                    S &= "<tr><td><b>Note:</b></td></tr>"
                    S &= "<tr><td> 1.** Payments are subject to realization.</td></tr>"
                    S &= "<tr><td> 2.If you have not received the User ID and Password for our Exclusive Customer Portal, Please contact us  or our Branch.</td></tr>"
                    S &= "<tr><td>3.This is computer generated email.Please do not reply to this mail-id.For any queries/assistance,please contact us or our branch.</td></tr>"
                    S &= " <tr></tr>"


                    S &= "<tr><td><hr></td></tr>"
                    S &= "<tr></tr>"


                    If .Item("region").ToString.Contains("EXP") = False Then


                            ds1 = New DataSet
                            sql = "SELECT FIN_YR,QTR_ID,SUM(INV_VALUE+TAX_VALUE)INV_VALUE FROM JAN_CFORM WHERE CFORM_NO IS NULL AND CUSTOMER_ID=" & .Item("customer_id") & " GROUP BY FIN_YR,QTR_ID "
                            adap = New OracleDataAdapter(sql, con)
                            adap.Fill(ds1, "PAY")
                            If ds1.Tables("pay").Rows.Count > 0 Then
                                S &= "<tr><td>We also would like to bring to your kind attention that the C-forms are pending at your end for the following periods:</td></tr>"
                                S &= "<tr></tr>"
                                S &= "<tr><td><table  class=tab  border=1 cellpading=0 cellspacing=0 width=60%><tr><th>Sl.no</th><th>Year</th><th>Quarter</th><th>Invoice Value in Rs</th></tr>"
                                For j = 0 To ds1.Tables("PAY").Rows.Count - 1
                                    With ds1.Tables("PAY").Rows(j)
                                        S &= "<tr><td ALIGN=CENTER>" & j + 1 & "</td><td>" & .Item("Fin_yr") & "</td><td ALIGN=CENTER>" & .Item("Qtr_id") & "</td><td ALIGN=RIGHT>" & .Item("INV_value") & "</td></tr>"
                                    End With
                                Next
                                S &= "</table></td></tr>"



                                S &= "<tr></tr>"
                                S &= "<tr><td>We request you to organize to send C-forms for the above given period immediately.</td></tr>"
                                S &= "<tr></tr>"

                                S &= "<tr><td>In case C-forms for the above period is already sent to us, kindly let us know the details for us to clarify.</td></tr><tr></tr>"

                                S &= "<tr></tr>"
                                S &= "</table>"
                            End If

                        End If

                        S &= "<table width=80% align=center class=tab1>"
                    S &= "<tr><td><b>Disclaimer</b></td></tr>"
                    S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                    S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                    S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"

                    S &= "</table>"
                    S &= "</html>"
                    sql1 = S
                    S = sql1.Replace("'", "''")

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try

                        End Try
                    Next

                    If .Item("region").ToString.Contains("EXP") Then
                        sql = "SELECT 'export@janatics.co.in,gopal.r@janatics.co.in'CONTACT2,null branch_mail FROM dual"
                    Else


                        sql = "SELECT DECODE(CONTACT1,NULL,CONTACT2,CONTACT1)CONTACT2,branch_mail FROM (SELECT "

                        sql += " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("customer_id") & "))  AND UPPER(contact_point_purpose) IN (''PAYMENT'',''PURCHASE'')' )contact1,"

                        sql += " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=" & .Item("customer_id") & "))') contact2,"

                        'sql += " (SELECT mail_id||','||'accts-ar@janatics.co.in' FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("region") & "')branch_mail"
                        sql += "  DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'))||','||'accts-ar@janatics.co.in' branch_mail "

                        sql += " FROM dual )"
                    End If
                    ds2 = New DataSet
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds2, "res")


                    '********************
                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO"
                    If Not IsDBNull(ds2.Tables("res").Rows(0).Item("contact2")) Then sql += ",mail_cc"


                    sql &= ", MAIL_SUBJECT, MAIL_SENT, "
                    For j = 0 To longlist.Count - 1
                        If (j = 0) Then sql &= " MAIL_BODY" Else sql &= " ,MAIL_subject_" & j + 1

                    Next
                    sql &= ") values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    If Not IsDBNull(ds2.Tables("res").Rows(0).Item("contact2")) Then

                        sql &= "'" & ds2.Tables("res").Rows(0).Item("contact2") & "','" & ds2.Tables("res").Rows(0).Item("branch_mail") & "'"
                    Else
                        sql &= "'" & ds2.Tables("res").Rows(0).Item("branch_mail") & "'"
                    End If

                    sql &= ",'Payment Receipt',0,"

                    For j = 0 To longlist.Count - 1
                        If (j = 0) Then sql &= "'" & longlist(j) & "'" Else sql &= ",'" & longlist(j) & "'"
                    Next

                    sql &= ")"


                    cmd = New OracleCommand(sql, con)
                    comand()
dont_insert:


                    Dim FSTRM As New FileStream("D:\payment receipt\payment_receipt" & i & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()
                End If
            End With

        Next


    End Sub
    Private Sub pay_cform()

        ds = New DataSet
        sql = " SELECT DISTINCT customer_id,customer_name,region FROM (SELECT a.*,(SELECT customer_class_code FROM ra_customers WHERE customer_id=a.customer_id )class_code FROM jan_cform a  ) WHERE cform_no IS NULL  AND customer_id NOT IN (SELECT customer_id FROM jan_customer_mail_exception WHERE mail_id=3)  AND region NOT IN ('CBE 1','NOT LISTED','EXPORT') AND class_code NOT IN ('E1 SALES','OTHERS') "
        'AND  trx_date<='30-jun-2012' "

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)

                'If .Item("customer_id") = 1707 Then
                'i = 109

                ds1 = New DataSet
                'sql = "SELECT FIN_YR,QTR_ID,SUM(INV_VALUE+TAX_VALUE)INV_VALUE FROM JAN_CFORM WHERE CFORM_NO IS NULL AND CUSTOMER_ID=" & .Item("customer_id") & " GROUP BY FIN_YR,QTR_ID"

                sql = "select fin_yr,qtr_id,sum(inv_value)inv_value,bill_to_site from (select a.trx_number,trx_date,remarks,qtr_id,fin_yr,region,(inv_value+tax_value)inv_value,(select bill_to_address from jan_invoice_listing where customer_trx_id=a.customer_trx_id and rownum=1)addr,(select bill_to_site from jan_invoice_listing where customer_trx_id=a.customer_trx_id and rownum=1)bill_to_site from jan_cform a where cform_no is null and CUSTOMER_ID=" & .Item("customer_id") & "  and  trx_date <( select FROM_DT from jan_cform_period where  sysdate between FROM_DT and TO_DATE ) )  group by fin_yr,qtr_id,bill_to_site order by bill_to_site,fin_yr,qtr_id"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "PAY")


                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>To</td></tr>"

                S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Dear Customer,</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>We thank you very much for your continued support.</td></tr>"
                S &= "<tr></tr>"



                S &= "<tr><td>We would like to bring to your kind attention that the C-forms are pending at your end for the following periods:</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td><table  class=tab  border=1 cellpading=0 cellspacing=0 width=60%><tr><th>Sl.no</th><th>Year</th><th>Quarter</th><th>Invoice Value in Rs</th><th>Bill to Unit</th></tr>"
                For j = 0 To ds1.Tables("PAY").Rows.Count - 1
                    With ds1.Tables("PAY").Rows(j)
                        S &= "<tr><td ALIGN=CENTER>" & j + 1 & "</td><td>" & .Item("Fin_yr") & "</td><td ALIGN=CENTER>" & .Item("Qtr_id") & "</td><td ALIGN=RIGHT>" & .Item("INV_value") & "</td><td >" & .Item("bill_to_site") & "</td></tr>"
                    End With
                Next
                S &= "</table></td></tr>"



                S &= "<tr></tr>"
                S &= "<tr><td>We request you to organize to send C-forms for the above given period immediately.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>In case C-forms for the above period is already sent to us, kindly let us know the details for us to clarify.</td></tr><tr></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>Assuring you of our Best Services always .</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Thanking you,</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>With Regards,</td></tr>"
                S &= "<tr><td>Marketing Department.</td></tr>"
                S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr></tr>"
                S &= "</table>"

                S &= "<table width=80% align=center class=tab1>"
                S &= "<tr><td><b>Disclaimer</b></td></tr>"
                S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"

                S &= "</table>"
                S &= "</html>"

                Dim longlist As New List(Of String)
                For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                    Try
                        longlist.Add(S.Substring(j * 3950, 3950))
                    Catch ex As Exception
                        Try
                            longlist.Add(S.Substring(j * 3950))
                        Catch ex1 As Exception

                        End Try

                    End Try
                Next


                sql = " SELECT DECODE(contact1,NULL,contact2,contact1)CONTACT_MAIL,branch_mail FROM ( SELECT "

                sql &= " (SELECT distinct email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("customer_id") & "))  AND UPPER(contact_point_purpose)='PAYMENT' and rownum=1)contact1,"

                sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("customer_id") & " || '))') contact2,"

                'sql &= " (SELECT mail_id FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "')branch_mail"
                sql &= "   DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "' )) branch_mail"

                sql &= " FROM dual) "
                ds1 = New DataSet
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "mail")

                '************NEW ADDITION **************
                With ds1.Tables(0).Rows(0)

                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                    If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "  mail_cc,"
                    sql &= " MAIL_SUBJECT, "
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "'" & .Item("CONTACT_MAIL") & "' ,'" & .Item("branch_mail") & "' ," Else sql &= "'" & .Item("branch_mail") & "' ,"
                    sql &= " 'CForm Reminder',"
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j).ToString.Replace("'", "''") & "'"
                        Else
                            sql &= ",'" & longlist(j).ToString.Replace("'", "''") & "'"
                        End If
                    Next
                    sql &= ",0)"
                End With
                comand()
                '********************************************

                'If ds1.Tables("mail").Rows.Count > 0 Then
                '    sql = ""
                '    With ds1.Tables("mail").Rows(0)

                '        If Not IsDBNull(.Item("contact1")) Then
                '            sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,MAIL_CC,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact1") & "','" & .Item("branch_mail") & "','CForm Reminder','" & S & "',0)"
                '        ElseIf Not IsDBNull(.Item("contact2")) Then
                '            sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,MAIL_CC,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact2") & "','" & .Item("branch_mail") & "','CForm Reminder','" & S & "',0)"
                '        Else
                '            sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,MAIL_CC,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("branch_mail") & "','feedback@janatics.co.in','CForm Reminder','" & S & "',0)"
                '        End If

                '    End With
                '    cmd = New OracleCommand(sql, con)
                '    If con.State = ConnectionState.Closed Then con.Open()
                '    If sql <> "" Then cmd.ExecuteNonQuery()


                'End If
            End With
        Next

    End Sub
    Private Sub despatch_detail()

        If Not Directory.Exists("D:\Despatch details") Then
            Directory.CreateDirectory("D:\Despatch details")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\Despatch details")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        Dim inv_dt As Date

        inv_dt = DateTimePicker1.Value
        'inv_dt = "30-dec-2014"

        sql = "DELETE FROM jan_despatch_mail_customer WHERE INV_DT<=TRUNC(SYSDATE)-5"
        comand()

        ds = New DataSet
        sql = "SELECT * FROM jan_despatch_mail_customer where inv_dt='" & Format(inv_dt, "dd-MMM-yyyy") & "'"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        If ds.Tables("result").Rows.Count = 0 Then

            sql = "INSERT INTO jan_despatch_mail_customer (SELECT DISTINCT bill_to_customer_id,0 mail_sent,trx_date FROM jan_invoice_listing a  WHERE trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "'   AND bill_to_customer_id NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION WHERE mail_id=2) AND REGION NOT IN ('CBE 1', 'NOT LISTED','EXPORT')  AND customer_class_code not in ('OTHERS','E1 SALES') and oatype not in ('Sample','Sample Unit II','Sample Unit VII','Free Replacement','Free Replacement Unit II','Free Replacement - VII')  )"
            comand()

            'janatics Unit-5 ,Unit-6
            sql = "INSERT INTO jan_despatch_mail_customer (SELECT DISTINCT bill_to_customer_id,0 mail_sent,trx_date FROM jan_invoice_listing a  WHERE trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "'   AND bill_to_customer_id  IN (2220588,2333588))"
            comand()

        End If

        ds = New DataSet
        sql = "SELECT DISTINCT BILL_TO_CUST_NAME,bill_to_customer_id,"

        sql &= " rowtocol('select distinct customer_trx_id from jan_invoice_listing where trx_date=''" & Format(inv_dt, "dd-MMM-yyyy") & "''  and bill_to_customer_id='||a.bill_to_customer_id||'')trx_id,"

        sql &= " (SELECT  SUM(b.quantity_invoiced*b.unit_selling_price) FROM jan_invoice_listing b WHERE b.bill_to_customer_id =a.bill_to_customer_id AND b.trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "')inv_value,"

        sql &= " rowtocol('select distinct c_order_no from jan_invoice_listing where trx_date=''" & Format(inv_dt, "dd-MMM-yyyy") & "''  and bill_to_customer_id='||a.bill_to_customer_id||'')corder_no, "

        sql &= " region FROM jan_invoice_listing a  "

        sql &= " WHERE trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "'   AND bill_to_customer_id  IN (SELECT CUSTOMER_ID FROM jan_despatch_mail_customer where mail_sent=0 and inv_dt='" & Format(inv_dt, "dd-MMM-yyyy") & "') ORDER BY BILL_TO_CUST_NAME "
        'SELECT CUSTOMER_ID FROM jan_despatch_mail_customer where mail_sent=0 and inv_dt='" & Format(inv_dt, "dd-MMM-yyyy") & "'
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S = ""

                S &= "<html>"

                S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>To</td></tr>"

                S &= "<tr><td>  M/s. " & .Item("BILL_TO_CUST_NAME") & "</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Dear Customer,</td></tr>"
                S &= "<tr></tr><tr></tr>"
                S &= "<tr></tr><tr></tr>"

                S &= "<tr><td>We are happy to provide you the despatch details as below:</td></tr>"
                S &= "<tr></tr>"


                S &= "<tr><td><table width=60% border=1 cellpading=0 cellspacing=0 class=tab>"
                S &= "<tr><td>Your P.O nos:</td><td>" & .Item("corder_no").ToString.Replace(",", "<br>") & "</td><tr>"
                ds1 = New DataSet 'code for order No
                sql = "SELECT DISTINCT order_number||'  /  '||TO_CHAR(order_date,'dd-MON-yyyy')ord_no FROM jan_invoice_listing WHERE trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "' AND  bill_to_customer_id='" & .Item("bill_to_customer_id") & "'"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "value")

                S &= "<tr><td>Our OA nos:</td><td>"

                For j = 0 To ds1.Tables("value").Rows.Count - 1
                    S &= "" & ds1.Tables("value").Rows(j).Item("ord_no") & "<br>"
                Next
                S &= "</td></tr>"
                ds1 = New DataSet 'code for Invoice No
                sql = "SELECT DISTINCT trx_number||'  /  '||TO_CHAR(trx_date,'dd-MON-yyyy')trx_no FROM jan_invoice_listing WHERE trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "' AND  bill_to_customer_id='" & .Item("bill_to_customer_id") & "'"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "value")

                S &= "<tr><td>Our Invoice nos:</td><td>"

                For j = 0 To ds1.Tables("value").Rows.Count - 1
                    S &= "" & ds1.Tables("value").Rows(j).Item("trx_no") & "<br>"
                Next
                S &= "</td></tr>"
                ds1 = New DataSet 'tax value
                sql = "select nvl(sum(extended_amount),0)amt from jan_invoice_tax where customer_trx_id in ('" & .Item("trx_id").ToString.Replace(",", "','") & "')"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "ex_amt")

                S &= "<td>Invoice Value in Rs</td><td>" & .Item("inv_value") + ds1.Tables("ex_amt").Rows(0).Item("amt") & "</td></tr>"

                '========code to get the docket_ref_no for a customer for a particular day's invoices=========   

                sql = "select distinct trx_number from jan_invoice_listing where trx_date='" & Format(inv_dt, "dd-MMM-yyyy") & "' and bill_to_customer_id='" & .Item("bill_to_customer_id") & "'"
                adap = New OracleDataAdapter(sql, con)
                ds1 = New DataSet
                adap.Fill(ds1, "trx")

                Dim c As String = ""
                For j = 0 To ds1.Tables("trx").Rows.Count - 1

                    sql = "SELECT doc_ref_no FROM jan_sales_docket_master WHERE customer_trx_id LIKE '%" & ds1.Tables("trx").Rows(j).Item("trx_number") & "%'"
                    adap = New OracleDataAdapter(sql, con)
                    ds2 = New DataSet
                    adap.Fill(ds2, "docno")
                    If j <> 0 And j <> ds1.Tables("trx").Rows.Count And ds2.Tables("docno").Rows.Count > 0 And c <> "" Then c &= " union "
                    If ds2.Tables("docno").Rows.Count > 0 Then
                        If j = ds1.Tables("trx").Rows.Count Then c &= " union "
                        c &= "  select " & ds2.Tables("docno").Rows(0).Item("doc_ref_no") & " no from dual "
                    End If
                Next
                '=========================================================================================
                'docket details

                If c <> "" Then 'if docket is not created then c will be c=""
                    Dim doc_no As String = ""
                    sql = "" & c & ""
                    adap = New OracleDataAdapter(sql, con)
                    ds3 = New DataSet
                    adap.Fill(ds3, "doc_no")
                    For k = 0 To ds3.Tables("doc_no").Rows.Count - 1
                        If k = ds3.Tables("doc_no").Rows.Count - 1 Then doc_no += String.Concat(ds3.Tables("doc_no").Rows(k).Item("no")) Else doc_no += String.Concat(ds3.Tables("doc_no").Rows(k).Item("no"), ",")
                        'doc_no += String.Concat(ds3.Tables("doc_no").Rows(k).Item("no"), ",")
                    Next

                    sql = "SELECT DISTINCT transporter,despatch_mode,freight_mode,delivery_type,CUSTOMER_DOCKET_NO FROM (SELECT a.*,rowtocol('select  distinct FORWARDER from jan_sales_docket_master where DOC_REF_NO in (''" & doc_no.Replace(",", "'',''") & "'')') transporter,rowtocol('select distinct despatch_mode from jan_sales_docket_master where DOC_REF_NO in (''" & doc_no.Replace(",", "'',''") & "'')') despatch_mode, rowtocol('SELECT distinct FREIGHT_MODE from jan_sales_docket_master where DOC_REF_NO in (''" & doc_no.Replace(",", "'',''") & "'')')FREIGHT_MODE,rowtocol('SELECT DISTINCT DECODE(door_delivery,''Y'',''Door delivery'',DOCUMENTS_TO) FROM jan_sales_docket_master WHERE DOC_REF_NO in (''" & doc_no.Replace(",", "'',''") & "'')')delivery_type,rowtocol('SELECT DISTINCT CUSTOMER_DOCKET_NO FROM jan_logistics_list_lines WHERE docket_no in (''" & doc_no.Replace(",", "'',''") & "'')')CUSTOMER_DOCKET_NO FROM (" & c & ")a )"
                    adap = New OracleDataAdapter(sql, con)
                    ds1 = New DataSet
                    adap.Fill(ds1, "value")

                    S &= "<tr><td>Transporter Name</td><td>" & ds1.Tables("value").Rows(0).Item("transporter") & "</td><tr>"
                    S &= "<tr><td>Mode of Despatch</td><td>" & ds1.Tables("value").Rows(0).Item("despatch_mode") & "</td><tr>"
                    S &= "<tr><td>Delivery type</td><td>" & ds1.Tables("value").Rows(0).Item("delivery_type") & "</td><tr>"
                    S &= "<tr><td>Freight terms</td><td>" & ds1.Tables("value").Rows(0).Item("FREIGHT_MODE") & "</td><tr>"

                    S &= "<tr><td>Docket no</td><td>" & ds1.Tables("value").Rows(0).Item("CUSTOMER_DOCKET_NO") & "</td><tr>"
                    ds2 = New DataSet 'get Docket No
                    sql = "SELECT  CUSTOMER_DOCKET_NO FROM jan_logistics_list_lines WHERE docket_no IN (" & c & ") and CUSTOMER_DOCKET_NO is not null"
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds2, "value")

                    If ds2.Tables("value").Rows.Count > 0 And ds2.Tables("value").Rows.Count = ds3.Tables("doc_no").Rows.Count Then

                        sql = "update jan_despatch_mail_customer set mail_sent=1 where customer_id=" & .Item("bill_to_customer_id") & " and inv_dt='" & Format(inv_dt, "dd-MMM-yyyy") & "'"

                    Else

                        If ds1.Tables("value").Rows(0).Item("transporter") = "YOUR PERSON" Or ds1.Tables("value").Rows(0).Item("transporter") = "TEMPO" Or ds1.Tables("value").Rows(0).Item("transporter") = "OUR PERSON" Or ds1.Tables("value").Rows(0).Item("transporter") = "LTS" Or ds1.Tables("value").Rows(0).Item("transporter") = "AUTO" Then
                            sql = "update jan_despatch_mail_customer set mail_sent=1 where customer_id=" & .Item("bill_to_customer_id") & " and inv_dt='" & Format(inv_dt, "dd-MMM-yyyy") & "'"
                        Else
                            GoTo last
                        End If

                    End If
                    comand()

                Else
                    GoTo last
                End If

                S &= " </table></td></tr>"

                S &= "<tr></tr><tr></tr>"
                S &= "<tr><td>Please note that the above details are available in our  Exclusive Customer Portal  website:<b><a href=""http://www.janaticscrm.net"">www.janaticscrm.net</a></td></tr>"
                S &= "<tr></tr><tr></tr>"
                'S &= "<tr><td>In case you have not received the user ID and Password yet please do contact us. Also please contact our branch for any clarifications / assistance.</td></tr>"
                S &= "<tr></tr><tr></tr>"
                S &= "<tr><td>Assuring you of our Best Services always.</td></tr>"
                S &= "<tr></tr><tr></tr>"
                S &= "<tr><td>Thanking you,</td></tr>"
                S &= "<tr></tr><tr></tr>"
                S &= "<tr><td>With Regards,</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>Marketing Department.</td></tr>"
                S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td><b>Note:</b></td></tr>"
                S &= "<tr><td>1.If you have not received the User ID and Password for our Exclusive Customer Portal, Please contact us  or our Branch.</td></tr>"
                S &= "<tr><td>2.This is computer generated email.Please do not reply to this mail-id.For any queries/assistance,please contact us or our branch.</td></tr>"

                S &= "<tr></tr>"

                '---------Blocked based on Ms.vanithamani mail
                ds1 = New DataSet 'out standing and over due
                sql = "SELECT (select decode(customer_class_code,'DEALER','DEALER','OTHERS') from ra_customers where customer_id=a.bill_to_customer_id)class_code,nvl(SUM (amount_due_remaining),0) amount_remaining,NVL(JAN_CUS_ODUE(a.bill_to_customer_id),0)odue FROM jan_region_payment_pending a WHERE bill_to_customer_id=" & .Item("bill_to_customer_id") & " GROUP BY bill_to_customer_id"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "value")

                If (ds1.Tables("value").Rows(0).Item("amount_remaining") + ds1.Tables("value").Rows(0).Item("odue")) > 0 Then
                    If ds1.Tables("value").Rows(0).Item("class_code") <> "DEALER" Then
                        If (.Item("bill_to_customer_id") <> 2220588) Or (.Item("bill_to_customer_id") <> 2333588) Then
                            S &= "<tr><td><hr></td></tr>"
                            S &= "<tr></tr><tr></tr>"
                            S &= "<tr><td>Please visit our Exclusive Customer Portal website for payment outstanding details. The summary of your payment outstanding is given below:</td></tr>"

                            S &= "<tr><td><table width=60% align=center class=tab><tr><td>1.Total payment outstanding including the above invoices </td><td align=left>:Rs." & ds1.Tables("value").Rows(0).Item("amount_remaining") & "</td></tr>"
                            S &= "<tr><td>2.Overdue Payment </td><td align=left>:Rs." & ds1.Tables("value").Rows(0).Item("odue") & "</td></tr></table>"

                            S &= "</td></tr><tr></tr>"
                            S &= "<tr></tr>"
                            S &= "</table>"
                        End If
                    End If
                End If
                '------------------
                S &= "<table width=80% align=center class=tab1>"
                S &= "<tr><td><b>Disclaimer</b></td></tr>" 'Disclaimer
                S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"

                S &= "</table>"
                S &= "</html>"

                Dim longlist As New List(Of String)
                For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950)) - 1
                    Try
                        longlist.Add(S.Substring(j * 3950, 3950))
                    Catch ex As Exception

                        longlist.Add(S.Substring(j * 3950))

                    End Try
                Next


                sql = " SELECT REGION_MAIL,DECODE(contact1,NULL,contact2,contact1)CONTACT_MAIL FROM(SELECT  DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "')) REGION_MAIL," 'code to take mail-id

                sql &= " (SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("bill_to_customer_id") & "))  AND UPPER(contact_point_purpose)='PURCHASE' AND ROWNUM=1)contact1,"

                sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("bill_to_customer_id") & " || '))') contact2"


                sql &= " FROM dual )"
                ds1 = New DataSet
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "mail")


                '************NEW ADDITION **************
                With ds1.Tables(0).Rows(0)

                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                    If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "  mail_cc,"
                    sql &= " MAIL_SUBJECT, "
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "'" & .Item("CONTACT_MAIL") & "' ,'" & .Item("REGION_MAIL") & "' ," Else sql &= "'" & .Item("CONTACT_MAIL") & "' ,"
                    sql &= " 'Despatch Details - Janatics',"
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j).ToString.Replace("'", "''") & "'"
                        Else
                            sql &= ",'" & longlist(j).ToString.Replace("'", "''") & "'"
                        End If
                    Next
                    sql &= ",0)"
                End With
                comand()
                'dont_insert:
                Dim FSTRM As New FileStream("D:\Despatch details\Despatch detail" & i & ".html", FileMode.Create, FileAccess.Write)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(S)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()
last:
            End With
        Next

    End Sub
    Private Sub order_acceptance()
        If Not Directory.Exists("D:\Order Acceptance") Then
            Directory.CreateDirectory("D:\Order Acceptance")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\Order Acceptance")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        Dim ord_dt As Date
        ord_dt = DateTimePicker1.Value

        sql = "delete from jan_cust_mail_ord_accept where ord_dt<=trunc(sysdate)-5 and mail_sent=1"
        comand()

        sql = "select * from jan_cust_mail_ord_accept where ord_dt='" & Format(ord_dt, "dd-MMM-yyyy") & "'"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")
        If ds.Tables("result").Rows.Count = 0 Then
            sql = "insert into jan_cust_mail_ord_accept (SELECT DISTINCT ordered_date,order_number, 0 mail_sent ,null FROM jan_bms_order_pending_new_v WHERE TRUNC(ordered_date)='" & Format(ord_dt, "dd-MMM-yyyy") & "'  AND CUST_ID NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION where  mail_id=1) "
            sql &= " And REGION Not in ('CBE 1','NOT LISTED','EXPORT')   "
            'sql &= " And REGION not like 'EXP%' "
            sql &= " and nvl(demand_class_code,'-') Not in ('E1 SALES') " 'OTHERS', removed for SR/2021000/14521
            'sql &= " And ord_type in ('Regular - Unit I','Regular - Unit II','Regular Unit-VII','Export - Unit I','Export - Unit VII'))"

            sql &= "  and ord_type not in (select name from Jan_Exemp_Order_Type))"
            'sql &= " And ord_type in ('Export - Unit I','Export - Unit VII'))"
            ','Export - Unit VII' 'Removed on 27jun2019
            ' not in ('Sample','Sample Unit II','Free Replacement','Free Replacement Unit II'))"
            cmd = New OracleCommand(sql, con)
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            'US customer order acceptance
            sql = "insert into jan_cust_mail_ord_accept (SELECT DISTINCT ordered_date,order_number, 0 mail_sent ,null FROM JAN_BMS_ORDER_PENDING_GLOBAL_V WHERE TRUNC(ordered_date)='" & Format(ord_dt, "dd-MMM-yyyy") & "'  AND CUST_ID NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION where  mail_id=1)) "
            cmd = New OracleCommand(sql, con)
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        End If

        sql = " delete from jan_cust_mail_ord_accept where mail_sent=0  and ord_dt<trunc(sysdate)-30 "
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()

        'sql = "SELECT DISTINCT cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE,(select customer_class_code from ra_customers where customer_id=a.cust_id)demand_class_code  FROM jan_bms_order_pending_new_v a WHERE order_number in (select ord_no  from jan_cust_mail_ord_accept where mail_sent=0 "
        'sql &= " And  ord_no  in ('20211704498')"
        'sql &= " )  ORDER BY cust_name"
        sql = " select * from ( SELECT  cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE,(select customer_class_code from ra_customers where customer_id=b.cust_id)demand_class_code ,count(*)cnt FROM jan_bms_order_pending_new_v b WHERE ordered_date>sysdate-60 and header_id in (select (select header_id from oe_order_headers_all where order_number=a.ord_no)header_id from jan_cust_mail_ord_accept a where  mail_sent=0) group by cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE) where region not like 'EXP%' "
        adap = New OracleDataAdapter(sql, con) 'and ordered_date='19-nov-2011' AND cust_id=23523
        ds = New DataSet
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)

                If .Item("FLOW_STATUS_CODE") = "ENTERED" Then
                    GoTo ord_last
                ElseIf .Item("FLOW_STATUS_CODE") = "CANCELLED" Then

                    sql = "update  jan_cust_mail_ord_accept set mail_sent=1,mail_sent_dt=trunc(sysdate) where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and ord_no in(select distinct order_number from jan_bms_order_pending_new_v where ORDERED_DATE='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and cust_id=" & .Item("cust_id") & " and flow_status_code<>'ENTERED') and mail_sent=0"
                    comand()

                Else
                    sql = "update  jan_cust_mail_ord_accept set mail_sent=1,mail_sent_dt=trunc(sysdate) where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and ord_no in(select distinct order_number from jan_bms_order_pending_new_v where ORDERED_DATE='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and cust_id=" & .Item("cust_id") & " and flow_status_code<>'ENTERED') and mail_sent=0"
                    comand()


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"
                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("CUST_NAME") & "</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Dear Customer,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We thank you very much for your valued order.</td></tr>"
                    S &= "<tr><td>We have registered your order  as below and  we are processing the order on priority.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><table width=80% class=tab border=1 cellspacing=0 cellpadding=0><tr><th>Your Order No</th><th>Date</th><th>Our Order Acceptance<br>(OA)</th><th>Date</th>"
                    If .Item("demand_class_code") = "DEALER" Then S &= "<th>Payment Due Date and Value</th> "

                    S &= " </tr>"


                    ds1 = New DataSet
                    sql = "SELECT  order_number,ordered_date,cust_name,CUSORDNO,CUSORDDT,cust_id "

                    If .Item("demand_class_code") = "DEALER" Then sql &= ",trunc(payment_ff_dt)payment_ff_dt "

                    sql &= " ,sum(ordered_quantity*(unit_selling_price+nvl(tax_amt,0))) val FROM jan_bms_order_pending_new_v WHERE TRUNC(ordered_date)='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "'  AND cust_id=" & .Item("cust_id") & "  and order_number in (select ord_no from jan_cust_mail_ord_accept where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and mail_sent=1 and mail_sent_dt=trunc(sysdate)) group by order_number,ordered_date,cust_name,CUSORDNO,CUSORDDT,cust_id "

                    If .Item("demand_class_code") = "DEALER" Then sql &= " ,trunc(payment_ff_dt) "

                    sql &= " ORDER BY cust_name"
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "ord")

                    If ds1.Tables("ord").Rows.Count > 0 Then
                        For j = 0 To ds1.Tables("ord").Rows.Count - 1
                            S &= "<tr><td>" & ds1.Tables("ord").Rows(j).Item("CUSORDNO") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("CUSORDDT") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("order_number") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("ordered_date") & "</td>"
                            If .Item("demand_class_code") = "DEALER" Then S &= "<td>" & ds1.Tables("ord").Rows(j).Item("payment_ff_dt") & " , Rs." & Format(ds1.Tables("ord").Rows(j).Item("val"), "00.00") & "</td> "

                            S &= " </tr>"
                        Next
                    Else
                        GoTo ord_last
                    End If


                    S &= "</table></td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We will update the status of the order in our Exclusive Customer Portal website  <b><a href=""http://www.janaticscrm.net""> www.janaticscrm.net </a></b>. Additionally we will send an email  with despatch details as soon as the materials are despatched. Kindly contact us Or our branch for any information.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Assuring you of our best services always.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><b>Note:</b></td></tr>"
                    S &= "<tr><td>1. If you have Not received the User ID And Password for our Exclusive Customer Portal, Please contact us  Or our Branch.</td></tr>"
                    S &= "<tr><td>2.This Is computer generated email.Please do Not reply to this mail-id.For any queries/assistance,please contact us Or our branch.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><hr></td></tr>"

                    S &= "<tr><td>PS:please visit our website www.janaticscrm.net for details.</td></tr><tr></tr><tr></tr>"
                    S &= "</table>"
                    S &= "<table width=80% align=center class=tab1>"
                    S &= "<tr><td><b>Disclaimer</b></td></tr>"
                    S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                    S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                    S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"
                    S &= "</table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950)) - 1
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception

                            longlist.Add(S.Substring(j * 3950))

                        End Try
                    Next


                    'ds2 = New DataSet
                    'sql = "SELECT * FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'"
                    'adap = New OracleDataAdapter(sql, con)
                    'adap.Fill(ds2, "ID")

                    'sql = "SELECT "

                    'sql &= " (SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("cust_id") & "))  AND UPPER(contact_point_purpose)='PURCHASE' and rownum=1)contact1,"

                    'sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("cust_id") & " || '))') contact2"


                    'sql &= " FROM dual "


                    'ds1 = New DataSet
                    'adap = New OracleDataAdapter(sql, con)
                    'adap.Fill(ds1, "mail")

                    '****************************************************

                    sql = " SELECT REGION_MAIL,DECODE(contact1,NULL,contact2,contact1)CONTACT_MAIL FROM(SELECT  DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "')) REGION_MAIL," 'code to take mail-id

                    sql &= " (SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("cust_id") & "))  AND UPPER(contact_point_purpose)='PURCHASE' AND ROWNUM=1)contact1,"

                    sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("cust_id") & " || '))') contact2"


                    sql &= " FROM dual )"
                    ds1 = New DataSet
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "mail")

                    'sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact1") & "','" & ds2.Tables("id").Rows(0).Item("mail_id") & ",sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"

                    '************NEW ADDITION **************

                    If previous_mail <> S Then


                        With ds1.Tables(0).Rows(0)

                            sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                            If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "  mail_cc,"
                            sql &= " MAIL_SUBJECT, "
                            For j = 0 To longlist.Count - 1
                                If j = 0 Then
                                    sql &= " MAIL_BODY"
                                Else
                                    sql &= " ,MAIL_subject_" & j + 1
                                End If
                            Next
                            sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                            If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "'" & .Item("CONTACT_MAIL") & "' ,'" & .Item("REGION_MAIL") & ",sales@janatics.co.in" Else sql &= "'" & .Item("REGION_MAIL") & ",sales@janatics.co.in"

                            If ds.Tables("result").Rows(i).Item("REGION").ToString.Contains("EXP") Then sql &= ",export@janatics.co.in,gopal.r@janatics.co.in"

                            sql &= "' ,"
                            sql &= " 'Order Acceptance',"
                            For j = 0 To longlist.Count - 1
                                If j = 0 Then
                                    sql &= "'" & longlist(j).ToString.Replace("'", "''") & "'"
                                Else
                                    sql &= ",'" & longlist(j).ToString.Replace("'", "''") & "'"
                                End If
                            Next
                            sql &= ",0)"
                            comand()
                        End With
                        previous_mail = S
                    End If
                    '***************************************************************************************

                    'Dim previous_mail As String

                    'If ds1.Tables("mail").Rows.Count > 0 Then

                    '    If previous_mail <> S Then
                    '        With ds1.Tables("mail").Rows(0)
                    '            sql = ""
                    '            If Not IsDBNull(.Item("contact1")) Then
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact1") & "','" & ds2.Tables("id").Rows(0).Item("mail_id") & ",sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"
                    '            ElseIf Not IsDBNull(.Item("contact2")) Then
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact2") & "','" & ds2.Tables("id").Rows(0).Item("mail_id") & ",sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"

                    '            Else
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & ds2.Tables("id").Rows(0).Item("mail_id") & "','feedback@janatics.co.in,sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"
                    '            End If
                    '            cmd = New OracleCommand(sql, con)
                    '            If con.State = ConnectionState.Closed Then con.Open()
                    '            If sql <> "" Then cmd.ExecuteNonQuery()
                    '        End With
                    '    End If
                    '    previous_mail = S
                    'End If



                    Dim FSTRM As New FileStream("D:\Order Acceptance\order acceptance" & i & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()

                End If
ord_last:
            End With
        Next
        'MessageBox.Show("Mail Sent", "Order Acceptance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub order_acceptance_us()
        'If Not Directory.Exists("D:\Order Acceptance") Then
        '    Directory.CreateDirectory("D:\Order Acceptance")
        'Else
        '    Dim Str() As String
        '    Str = Directory.GetFiles("D:\Order Acceptance")
        '    Dim DELFILE As String
        '    For Each DELFILE In Str
        '        File.Delete(DELFILE)
        '    Next
        'End If

        'Dim ord_dt As Date
        'ord_dt = DateTimePicker1.Value
        ''ord_dt = "20-jun-2020"

        'sql = "delete from jan_cust_mail_ord_accept where ord_dt<=trunc(sysdate)-5 and mail_sent=1"
        'comand()

        'sql = "select * from jan_cust_mail_ord_accept where ord_dt='" & Format(ord_dt, "dd-MMM-yyyy") & "'"
        'adap = New OracleDataAdapter(sql, con)
        'ds = New DataSet
        'adap.Fill(ds, "result")
        'If ds.Tables("result").Rows.Count = 0 Then
        '    sql = "insert into jan_cust_mail_ord_accept (SELECT DISTINCT ordered_date,order_number, 0 mail_sent ,null FROM JAN_BMS_ORDER_PENDING_GLOBAL_V WHERE TRUNC(ordered_date)='" & Format(ord_dt, "dd-MMM-yyyy") & "'  AND CUST_ID NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION where  mail_id=1)) "
        '    'sql &= " And ord_type in ('Regular - Unit I','Regular - Unit II','Regular Unit-VII','Export - Unit I','Export - Unit VII'))"
        '    'sql &= " And ord_type in ('Export - Unit I','Export - Unit VII'))"
        '    ','Export - Unit VII' 'Removed on 27jun2019
        '    ' not in ('Sample','Sample Unit II','Free Replacement','Free Replacement Unit II'))"
        '    cmd = New OracleCommand(sql, con)
        '    If con.State = ConnectionState.Closed Then con.Open()
        '    cmd.ExecuteNonQuery()
        'End If

        'sql = " delete from jan_cust_mail_ord_accept where mail_sent=0  and ord_dt<trunc(sysdate)-30 "
        'cmd = New OracleCommand(sql, con)
        'If con.State = ConnectionState.Closed Then con.Open()
        'cmd.ExecuteNonQuery()

        sql = "SELECT DISTINCT cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE,demand_class_code  FROM JAN_BMS_ORDER_PENDING_GLOBAL_V WHERE order_number in (select ord_no  from jan_cust_mail_ord_accept where mail_sent=0 "
        'sql &= " And  ord_no  in ('2019400036','2019400034','2019400033','2019400035')"
        sql &= " )  ORDER BY cust_name"

        sql = " select * from ( SELECT  cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE,(select customer_class_code from ra_customers where customer_id=b.cust_id)demand_class_code ,count(*)cnt FROM jan_bms_order_pending_new_v b WHERE ordered_date>sysdate-60 and header_id in (select (select header_id from oe_order_headers_all where order_number=a.ord_no)header_id from jan_cust_mail_ord_accept a where  mail_sent=0) group by cust_name,cust_id,region,ORDERED_DATE,FLOW_STATUS_CODE) where region  like 'EXP%' "
        adap = New OracleDataAdapter(sql, con) 'and ordered_date='19-nov-2011' AND cust_id=23523
        ds = New DataSet
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)

                If .Item("FLOW_STATUS_CODE") = "ENTERED" Then
                    GoTo ord_last
                ElseIf .Item("FLOW_STATUS_CODE") = "CANCELLED" Then

                    sql = "update  jan_cust_mail_ord_accept set mail_sent=1,mail_sent_dt=trunc(sysdate) where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and ord_no in(select distinct order_number from JAN_BMS_ORDER_PENDING_GLOBAL_V where ORDERED_DATE='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and cust_id=" & .Item("cust_id") & " and flow_status_code<>'ENTERED') and mail_sent=0"
                    comand()

                Else
                    sql = "update  jan_cust_mail_ord_accept set mail_sent=1,mail_sent_dt=trunc(sysdate) where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and ord_no in(select distinct order_number from JAN_BMS_ORDER_PENDING_GLOBAL_V where ORDERED_DATE='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and cust_id=" & .Item("cust_id") & " and flow_status_code<>'ENTERED') and mail_sent=0"

                    sql = "update  jan_cust_mail_ord_accept set mail_sent=1,mail_sent_dt=trunc(sysdate) where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and ord_no in(select distinct order_number from JAN_BMS_ORDER_PENDING_new_V where ORDERED_DATE='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and cust_id=" & .Item("cust_id") & " and flow_status_code<>'ENTERED') and mail_sent=0"
                    comand()


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"
                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("CUST_NAME") & "</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Dear Customer,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We thank you very much for your valued order.</td></tr>"
                    S &= "<tr><td>We have registered your order  as below and  we are processing the order on priority.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><table width=80% class=tab border=1 cellspacing=0 cellpadding=0><tr><th>Your Order No</th><th>Date</th><th>Our Order Acceptance<br>(OA)</th><th>Date</th>"
                    If .Item("demand_class_code") = "DEALER" Then S &= "<th>Payment Due Date and Value</th> "

                    S &= " </tr>"


                    ds1 = New DataSet
                    sql = "SELECT  order_number,ordered_date,cust_name,CUSORDNO,CUSORDDT,cust_id,trunc(payment_ff_dt)payment_ff_dt,sum(ordered_quantity*(unit_selling_price+nvl(tax_amt,0))) val FROM JAN_BMS_ORDER_PENDING_new_V WHERE TRUNC(ordered_date)='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "'  AND cust_id=" & .Item("cust_id") & "  and order_number in (select ord_no from jan_cust_mail_ord_accept where ord_dt='" & Format(.Item("ordered_date"), "dd-MMM-yyyy") & "' and mail_sent=1 and mail_sent_dt=trunc(sysdate)) group by order_number,ordered_date,cust_name,CUSORDNO,CUSORDDT,cust_id,trunc(payment_ff_dt)  ORDER BY cust_name"
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "ord")

                    If ds1.Tables("ord").Rows.Count > 0 Then
                        For j = 0 To ds1.Tables("ord").Rows.Count - 1
                            S &= "<tr><td>" & ds1.Tables("ord").Rows(j).Item("CUSORDNO") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("CUSORDDT") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("order_number") & "</td><td>" & ds1.Tables("ord").Rows(j).Item("ordered_date") & "</td>"
                            If .Item("demand_class_code") = "DEALER" Then S &= "<td>" & ds1.Tables("ord").Rows(j).Item("payment_ff_dt") & " , Rs." & Format(ds1.Tables("ord").Rows(j).Item("val"), "00.00") & "</td> "

                            S &= " </tr>"
                        Next
                    Else
                        GoTo ord_last
                    End If


                    S &= "</table></td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We will update the status of the order in our Exclusive Customer Portal website  <b><a href=""http://www.janaticscrm.net""> www.janaticscrm.net </a></b>. Additionally we will send an email  with despatch details as soon as the materials are despatched. Kindly contact us or our branch for any information.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Assuring you of our best services always.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><b>Note:</b></td></tr>"
                    S &= "<tr><td>1. If you have not received the User ID and Password for our Exclusive Customer Portal, Please contact us  or our Branch.</td></tr>"
                    S &= "<tr><td>2.This is computer generated email.Please do not reply to this mail-id.For any queries/assistance,please contact us or our branch.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><hr></td></tr>"

                    S &= "<tr><td>PS:please visit our website www.janaticscrm.net for details.</td></tr><tr></tr><tr></tr>"
                    S &= "</table>"
                    S &= "<table width=80% align=center class=tab1>"
                    S &= "<tr><td><b>Disclaimer</b></td></tr>"
                    S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                    S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                    S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"
                    S &= "</table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950)) - 1
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception

                            longlist.Add(S.Substring(j * 3950))

                        End Try
                    Next

                    sql = " SELECT REGION_MAIL,DECODE(contact1,NULL,contact2,contact1)CONTACT_MAIL FROM(SELECT  DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT bdm_MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "')) REGION_MAIL," 'code to take mail-id

                    'sql &= " (SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("cust_id") & "))  AND UPPER(contact_point_purpose)='PURCHASE' AND ROWNUM=1)contact1,"

                    'sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("cust_id") & " || '))') contact2"
                    sql &= " null contact1,null contact2 "


                    sql &= " FROM dual )"
                    ds1 = New DataSet
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "mail")

                    '************NEW ADDITION **************

                    If previous_mail <> S Then


                        With ds1.Tables(0).Rows(0)

                            sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                            If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "  mail_cc,"
                            sql &= " MAIL_SUBJECT, "
                            For j = 0 To longlist.Count - 1
                                If j = 0 Then
                                    sql &= " MAIL_BODY"
                                Else
                                    sql &= " ,MAIL_subject_" & j + 1
                                End If
                            Next
                            sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                            If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "'" & .Item("CONTACT_MAIL") & "' ,'" & .Item("REGION_MAIL") & ",sales@janatics.co.in" Else sql &= "'" & .Item("REGION_MAIL") & ",it-dev7@janatics.co.in,tamilselvi@janatics.co.in"
                            'sql &= "'" & .Item("REGION_MAIL") & ",it-dev7@janatics.co.in"

                            'If ds.Tables("result").Rows(i).Item("REGION").ToString.Contains("EXP") Then sql &= ",export@janatics.co.in

                            sql &= " ' ,"
                            sql &= " 'Order Acceptance',"
                            For j = 0 To longlist.Count - 1
                                If j = 0 Then
                                    sql &= "'" & longlist(j).ToString.Replace("'", "''") & "'"
                                Else
                                    sql &= ",'" & longlist(j).ToString.Replace("'", "''") & "'"
                                End If
                            Next
                            sql &= ",0)"
                            comand()
                        End With
                        previous_mail = S
                    End If
                    '***************************************************************************************

                    'Dim previous_mail As String

                    'If ds1.Tables("mail").Rows.Count > 0 Then

                    '    If previous_mail <> S Then
                    '        With ds1.Tables("mail").Rows(0)
                    '            sql = ""
                    '            If Not IsDBNull(.Item("contact1")) Then
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact1") & "','" & ds2.Tables("id").Rows(0).Item("mail_id") & ",sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"
                    '            ElseIf Not IsDBNull(.Item("contact2")) Then
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & .Item("contact2") & "','" & ds2.Tables("id").Rows(0).Item("mail_id") & ",sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"

                    '            Else
                    '                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Customer Mails','feedback@janatics.co.in','" & ds2.Tables("id").Rows(0).Item("mail_id") & "','feedback@janatics.co.in,sales@janatics.co.in','Order Acceptance','" & S.ToString.Replace("'", "''") & "',0)"
                    '            End If
                    '            cmd = New OracleCommand(sql, con)
                    '            If con.State = ConnectionState.Closed Then con.Open()
                    '            If sql <> "" Then cmd.ExecuteNonQuery()
                    '        End With
                    '    End If
                    '    previous_mail = S
                    'End If



                    Dim FSTRM As New FileStream("D:\Order Acceptance\order acceptance" & i & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()

                End If
ord_last:
            End With
        Next
        'MessageBox.Show("Mail Sent", "Order Acceptance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub comand()
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub btn_pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pay.Click
        payment_receipt()
    End Sub
    Private Sub btn_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_order.Click
        order_acceptance()
    End Sub
    Private Sub btn_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_invoice.Click
        despatch_detail()
    End Sub
    Private Sub btn_view_pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_pay.Click

        ds = New DataSet
        sql = "SELECT * FROM ( SELECT  DISTINCT pay_from_customer customer_id,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.pay_from_customer)CUSTOMER_NAME,rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || a.pay_from_customer || '))')all_MAIL_ID,(SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=a.pay_from_customer))  AND UPPER(contact_point_purpose)='PAYMENT')payment_mail_id ,(SELECT CUSTOMER_class_code FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.pay_from_customer)CUSTOMER_class_code,(SELECT ter.segment14 FROM ra_site_uses_all sit,ra_territories ter WHERE sit.territory_id=ter.territory_id AND sit.site_use_id=a.customer_site_use_id)region  FROM ar_cash_receipts_all A WHERE trunc(creation_date)='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' AND pay_from_customer IS NOT NULL AND pay_from_customer NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION )) WHERE region NOT IN ('CBE 1','NOT LISTED','EXPORT') AND CUSTOMER_class_code NOT IN ('OTHERS','E1 SALES')"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        head = "Payment Receipt"
        mail_details()

    End Sub
    Private Sub mail_details()
        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<h4>" & head & "</h4>"

        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr><th>Sl.No</th>"
        For i = 0 To ds.Tables("result").Columns.Count - 1
            With ds.Tables("result").Columns(i)
                S &= "<th>" & .ColumnName & "</th>"
            End With
        Next
        S &= "</tr>"


        For i = 0 To ds.Tables("result").Rows.Count - 1

            S &= "<tr><td>" & i + 1 & "</td>"
            For j = 0 To ds.Tables("result").Columns.Count - 1
                With ds.Tables("result").Rows(i)
                    S &= "<td>" & .Item(j) & "</td>"
                End With
            Next
            S &= "</tr>"

        Next

        X = "mail_details.xls"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
        System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub btn_view_oa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_oa.Click
        ds = New DataSet
        sql = "SELECT DISTINCT cust_name,cust_id ,region,(SELECT customer_class_code FROM ra_customers WHERE customer_id=a.cust_id)customer_class_code,rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || a.cust_id || '))')all_MAIL_ID,(SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=a.cust_id))  AND UPPER(contact_point_purpose)='PURCHASE')purchase_mail_id FROM jan_bms_order_pending_new_v A  WHERE TRUNC(ordered_date)='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' AND demand_class_code NOT IN ('OTHERS','E1 SALES')  and ord_type not in ('Sample','Sample Unit II','Free Replacement','Free Replacement Unit II') AND cust_id NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION ) AND region NOT IN ('CBE 1','NOT LISTED','EXPORT')  ORDER BY cust_name"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        head = "Order Acceptance"
        mail_details()
    End Sub
    Private Sub btn_view_des_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_des.Click
        ds = New DataSet
        sql = "SELECT DISTINCT BILL_TO_CUST_NAME,bill_to_customer_id,region,customer_class_code,rowtocol('SELECT  distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || a.bill_to_customer_id || '))')all_MAIL_ID,(SELECT email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=a.bill_to_customer_id))  AND UPPER(contact_point_purpose)='PURCHASE')purchase_mail_id  FROM jan_invoice_listing a WHERE trx_date='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  AND bill_to_customer_id NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION ) AND REGION NOT IN ('CBE 1','NOT LISTED','EXPORT')  and oatype not in ('Sample','Sample Unit II','Free Replacement','Free Replacement Unit II') AND customer_class_code NOT IN ('OTHERS','E1 SALES') ORDER BY BILL_TO_CUST_NAME"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        head = "Despatch Details"
        mail_details()
    End Sub
    Private Sub payment_reminder()

        ds = New DataSet
        'sql = "select a.*,NVL(jan_cus_pp(a.CUSTOMER_ID),0)unapplied ,nvl(JAN_CUS_ODUE(a.CUSTOMER_ID),0)over_due,nvl(jan_cus_out_standing(A.CUSTOMER_ID),0) out_standing from JAN_BMS_CUSTOMER_REGION_V a where customer_class_code not in ('DEALER','OTHERS')"
        sql = "select a.*,NVL(jan_cus_pp(a.CUSTOMER_ID),0)unapplied ,nvl(JAN_CUS_ODUE(a.CUSTOMER_ID),0)over_due,nvl(jan_cus_out_standing(A.CUSTOMER_ID),0) out_standing from JAN_BMS_CUSTOMER_REGION_V a where  REGION NOT IN ('CBE 1', 'NOT LISTED','EXPORT')  AND customer_class_code not in ('OTHERS','E1 SALES','DEALER')AND CUSTOMER_ID NOT IN (SELECT CUSTOMER_ID FROM JAN_CUSTOMER_MAIL_EXCEPTION where  mail_id=5)  order by customer_id"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "cust")

        For i = 0 To ds.Tables("cust").Rows.Count - 1
            With ds.Tables("cust").Rows(i)

                If .Item("out_standing") > 1000 Then


                    S = ""
                    S += "<HTML>"

                    S += "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S += "<table width=100% align=center class=tab>"
                    S += "<tr><td>To</td></tr>"

                    S += "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                    S += "<tr></tr>"

                    S += "<tr><td>Dear Customer,</td></tr>"
                    S += "<tr></tr>"
                    S += "<tr></tr>"
                    S += "<tr><td>We thank you very much for your continued support.</td></tr>"
                    S += "<tr><td>We would like to bring to your kind attention that the following invoices are pending for payment.</td></tr>"
                    S += "<tr></tr>"
                    S += "<tr></tr>"
                    S += "<tr><td><table width=80% class=tab border=1 cellspacing=0 cellpadding=0><tr><th>Sno</th><th> P.O no / Date</th><th>Invoice no / Date</th><TH>Due Date</TH><TH>Amount pending</TH><TH>Bill to Unit</TH></tr>"

                    '1. The outstanding value is more than Rs. 1000
                    '2. The unapplied amount is more or equal than the overdue
                    '3. The dealer list to be removed, since we are already sending the same on every day.
                    sql = "SELECT * FROM (SELECT trx_number||' / '||to_char(trx_date,'dd-MON-yyyy')trx_date ,customer_trx_id,(select bill_to_site from jan_invoice_listing where customer_trx_id=a.customer_trx_id and rownum=1)bill_to_site,rowtocol('select distinct c_order_no from jan_invoice_listing where  customer_trx_id='||a.customer_trx_id||'')C_ORDER,to_char(due_date,'dd-MON-yyyy')due_date,(SELECT DISTINCT OATYPE FROM JAN_INVOICE_LISTING WHERE customer_trx_id=A.customer_trx_id)OA_TYPE,NVL(SUM(AMOUNT_DUE_REMAINING),0) over_due FROM jan_region_payment_pending A WHERE BILL_TO_CUSTOMER_ID=" & .Item("customer_id") & " AND  AMOUNT_DUE_REMAINING<>0 AND DUE_DAYS>0 group by  customer_trx_id,trx_number,trx_date,due_date order by trx_date ) WHERE over_due>10 AND  OA_TYPE NOT IN ('Sample','Sample Unit II','Free Replacement','Free Replacement Unit II')"
                    adap = New OracleDataAdapter(sql, con)
                    ds1 = New DataSet()
                    adap.Fill(ds1, "res")

                    If ds1.Tables("res").Rows.Count > 0 Then


                        For j = 0 To ds1.Tables("res").Rows.Count - 1

                            S += "<tr><td>" & j + 1 & "</td>"
                            If IsDBNull(ds1.Tables("res").Rows(j).Item("C_ORDER")) Then

                                S += "<td >&nbsp;</td>"

                            Else
                                S += " <td>" & ds1.Tables("res").Rows(j).Item("C_ORDER") & "</td>"
                            End If

                            S += "<td>" & ds1.Tables("res").Rows(j).Item("trx_date") & "</td><td>" & ds1.Tables("res").Rows(j).Item("due_date") & "</td><td align=right ><FONT color=red><B>" & ds1.Tables("res").Rows(j).Item("over_due") & "</B></FONT></td>"

                            If IsDBNull(ds1.Tables("res").Rows(j).Item("bill_to_site")) Then
                                S += "<td >&nbsp;</td>"
                            Else

                                S += "<td >" & ds1.Tables("res").Rows(j).Item("bill_to_site") & "</td>"
                            End If
                            S += "</tr>"


                        Next
                        S += "</table></td></tr>"
                        S += "<tr><td><br></td></tr>"

                        If .Item("unapplied") >= 1000 Then
                            S += "<tr><td><B><FONT color=blue> * Un Applied Amount is :</FONT><FONT color=red> " & .Item("unapplied") & "</FONT></B></td></tr>"
                            S += "<tr><td>Please send us the Invoice details immediately which will help us to account accordingly.</td></tr>"
                            S += "<tr><td><br></td></tr>"
                        End If


                        S += "<tr><td>We kindly request you to organize to send the above payments immediately.</td></tr>"
                        S += "<tr><td>In case if you have already paid the payment for the above invoices,kindly let us know the details for us to verify at our end.</td></tr>"

                        S += "<tr><td><br></td></tr>"
                        S += "<tr><td>Assuring you of our Best Services always.</td></tr>"
                        S += "<tr><td><br></td></tr>"
                        S += "<tr><td>Thanking you,</td></tr>"
                        S += "<tr><td>With Regards,</td></tr>"
                        S += "<tr><td>Marketing Department.</td></tr>"

                        S += "<tr><td><b>Janatics India Private Limited.</b></td></tr>"

                        S += "<tr><td><hr></td></tr>"

                        S += "</table>"
                        S += "<table width=100% align=center class=tab1>"
                        S += "<tr><td><b>Disclaimer</b></td></tr>"
                        S += "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                        S += "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                        S += "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"
                        S += "</table>"
                        S += "</html>"

                        sql1 = S
                        S = sql1.Replace("'", "''")

                        Dim longlist As New List(Of String)
                        For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                            Try
                                longlist.Add(S.Substring(j * 3950, 3950))
                            Catch ex As Exception
                                Try
                                    longlist.Add(S.Substring(j * 3950))
                                Catch ex1 As Exception

                                End Try

                            End Try
                        Next

                        sql = "SELECT DECODE(CONTACT1,NULL,CONTACT2,CONTACT1)CONTACT2,branch_mail FROM (SELECT "

                        sql += " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("customer_id") & "))  AND UPPER(contact_point_purpose) IN (''PAYMENT'',''PURCHASE'')' )contact1,"

                        sql += " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=" & .Item("customer_id") & "))') contact2,"

                        sql += " (SELECT mail_id||','||'vanitha@janatics.co.in' FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("region") & "')branch_mail"

                        sql += " FROM dual )"
                        adap = New OracleDataAdapter(sql, con)
                        ds2 = New DataSet()
                        adap.Fill(ds2, "res")



                        sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO"
                        If Not IsDBNull(ds2.Tables("res").Rows(0).Item("contact2")) Then sql += ",mail_cc"


                        sql &= ", MAIL_SUBJECT, MAIL_SENT, "
                        For j = 0 To longlist.Count - 1
                            If (j = 0) Then sql &= " MAIL_BODY" Else sql &= " ,MAIL_subject_" & j + 1

                        Next
                        sql &= ") values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                        If Not IsDBNull(ds2.Tables("res").Rows(0).Item("contact2")) Then

                            sql &= "'" & ds2.Tables("res").Rows(0).Item("contact2") & "','" & ds2.Tables("res").Rows(0).Item("branch_mail") & "'"
                        Else
                            sql &= "'" & ds2.Tables("res").Rows(0).Item("branch_mail") & "'"
                        End If

                        sql &= ",'Payment Reminder',0,"

                        For j = 0 To longlist.Count - 1
                            If (j = 0) Then sql &= "'" & longlist(j) & "'" Else sql &= ",'" & longlist(j) & "'"
                        Next

                        sql &= ")"


                        cmd = New OracleCommand(sql, con)
                        comand()

                    End If
                    'End If
                End If ' os more than 1000

            End With
        Next

    End Sub
    Private Sub cform_receipt()

        Dim LAST_UPDATE_DATE As Date
        LAST_UPDATE_DATE = DateTimePicker1.Value
        ds2 = New DataSet

        sql = "SELECT * FROM (select distinct customer_id,(SELECT CUSTOMER_CLASS_CODE FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID)CLASS_CODE,customer_name,region from jan_cform A where trunc(last_update_date)='" & Format(LAST_UPDATE_DATE, "dd-MMM-yyyy") & "' and cform_no is not null  AND cform_no NOT LIKE '%XXXX%' AND customer_id NOT IN (SELECT customer_id FROM jan_customer_mail_exception WHERE mail_id=3)  AND region NOT IN ('CBE 1','NOT LISTED','EXPORT')) WHERE class_code NOT IN ('E1 SALES','OTHERS','DEALER')"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds2, "result")

        For i = 0 To ds2.Tables("result").Rows.Count - 1


            With ds2.Tables("result").Rows(i)
                ds1 = New DataSet

                Try
                    sql = "select a.* ,rowtocol('select '' ''||trx_number from jan_cform where TRUNC(last_update_date)='''||a.last_update_date||''' AND customer_id='||a.customer_id||' and cform_no='''||a.cform_no||'''') inv_number,(select sum(inv_value+tax_value) from jan_cform where TRUNC(last_update_date)=a.last_update_date AND customer_id=a.customer_id and cform_no=a.cform_no)inv_val from (SELECT customer_id,cform_no,cform_date,trunc(last_update_date)last_update_date,count(*),case when remarks is not null then trx_number||'-'|| remarks else remarks end remarks FROM JAN_CFORM where trunc(last_update_date)='" & Format(LAST_UPDATE_DATE, "dd-MMM-yyyy") & "' and customer_id=" & .Item("customer_id") & " group by CUSTOMER_ID, CFORM_NO,cform_date, case when REMARKS is not null then TRX_NUMBER||'-'|| REMARKS else REMARKS end ,trunc(last_update_date)order by cform_no)A"
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "cform")

                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                    S &= "<table width=80% align=center class=tab>"

                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Dear Customer,</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>We thank you very much for your continued support.</td></tr>"
                    S &= "<tr></tr>"



                    S &= "<tr><td>We hereby acknowledge the C- Form received from you as given below:</td></tr>"
                    S &= "<tr></tr>"
                    Dim inv_no As String

                    S &= "<tr><td><table  class=tab  border=1 cellpading=0 cellspacing=0 width=100%><tr><th>Sl.no</th><th>C- Form Details </th><th>Remarks</th><th WIDTH=250px>Invoice No</th><th>Invoice value</th></tr>"
                    For j = 0 To ds1.Tables("cform").Rows.Count - 1
                        With ds1.Tables("cform").Rows(j)
                            S &= "<tr><td ALIGN=CENTER valign=top>" & j + 1 & "</td><td nowrap valign=top>CForm No:" & .Item("cform_no") & ""
                            If Not IsDBNull(.Item("cform_date")) Then S &= " <br>CForm Dt:" & .Item("cform_date") & ""
                            If Not IsDBNull(.Item("remarks")) Then S &= " </td><td valign=top>" & .Item("remarks") & "</td>" Else S &= " </td><td >&nbsp;</td>"

                            inv_no = .Item("inv_number")

                            S &= " <td >" & inv_no & "</td><td valign=top>" & .Item("inv_val") & "</td>"
                            S &= " </tr>"
                        End With
                    Next
                    S &= "</table></td></tr>"



                    S &= "<tr></tr>"
                    S &= "<tr><td>Please be informed that your C- form pending/payment outstanding details and the accounts statements are available in our exclusive customer portal website : <b><a href=""http://www.janaticscrm.net"">www.janaticscrm.net</a></td></tr>"
                    S &= "<tr></tr>"


                    S &= "<tr><td>Assuring you of our Best Services always .</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr></tr>"

                    S &= "<tr><td><b>Note:</b></td></tr>"
                    S &= "<tr><td>1.If you have not received the User ID and Password for our Exclusive Customer Portal, Please contact us  or our Branch.</td></tr>"
                    S &= "<tr><td>2.This is computer generated email.Please do not reply to this mail-id.For any queries/assistance,please contact us or our branch.</td></tr>"

                    S &= "</table>"
                    S &= "<table width=80% align=center class=tab1>"
                    S &= "<tr><td><b>Disclaimer</b></td></tr>"
                    S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                    S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                    S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"

                    S &= "</table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try

                        End Try
                    Next


                    sql = " SELECT DECODE(contact1,NULL,contact2,contact1)CONTACT_MAIL,branch_mail FROM ( SELECT "

                    sql &= " (SELECT distinct email_address FROM AR_PHONES_V WHERE owner_table_name='HZ_PARTIES' AND STATUS='A' AND (OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id=" & .Item("customer_id") & "))  AND UPPER(contact_point_purpose)='PAYMENT' and rownum=1)contact1,"

                    sql &= " rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID=(select party_id from ra_customers where customer_id=' || " & .Item("customer_id") & " || '))') contact2,"
                    'sql += " (SELECT mail_id||','||'vanitha@janatics.co.in'||','||'accts-ar@janatics.co.in' FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("region") & "')branch_mail"

                    sql += "  DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'))||','||'vanitha@janatics.co.in'||','||'accts-ar@janatics.co.in'  branch_mail"


                    sql &= " FROM dual) "
                    ds1 = New DataSet
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "mail")

                    With ds1.Tables(0).Rows(0)

                        sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                        If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "  mail_cc,"
                        sql &= " MAIL_SUBJECT, "
                        For j = 0 To longlist.Count - 1
                            If j = 0 Then
                                sql &= " MAIL_BODY"
                            Else
                                sql &= " ,MAIL_subject_" & j + 1
                            End If
                        Next
                        sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                        If Not IsDBNull(.Item("CONTACT_MAIL")) Then sql &= "'" & .Item("CONTACT_MAIL") & "' ,'" & .Item("branch_mail") & ",sales08@janatics.co.in' ," Else sql &= "'" & .Item("branch_mail") & ",sales08@janatics.co.in' ,"
                        sql &= " 'CForm Receipt',"
                        For j = 0 To longlist.Count - 1
                            If j = 0 Then
                                sql &= "'" & longlist(j) & "'"
                            Else
                                sql &= ",'" & longlist(j) & "'"
                            End If
                        Next
                        sql &= ",0)"
                    End With
                    comand()
                Catch ex As Exception

                End Try
            End With
        Next

    End Sub
    Private Sub Dealer_mail()

        ds = New DataSet
        sql = "select distinct customer_id,customer_name from jan_sales_any_tb2_1 where  customer_class_code='DEALER' and (ordered_quantity-nvl(shipped_quantity,0))>0 and schedule_ship_date<'1-feb-2014'  and customer_id=1510"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "dealer_name")
        For i = 0 To ds.Tables("dealer_name").Rows.Count - 1
            With ds.Tables("dealer_name").Rows(i)

                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>To</td></tr>"

                S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Dear Sir,</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Please find below the Fund plan based on your pending orders .</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>Kindly refer the same and organise to make your payments accordingly.</td></tr>"
                S &= "<tr></tr>"

                ds1 = New DataSet
                'sql = "select b.*,(order_pend_upto_jan+jan_dsp_order)total ,case when (order_pend_upto_jan+jan_dsp_order)<=100000 then (order_pend_upto_jan+jan_dsp_order) when (order_pend_upto_jan+jan_dsp_order)>100000 and  (order_pend_upto_jan+jan_dsp_order)<=200000 then JAN_NEAR50000(round((order_pend_upto_jan+jan_dsp_order)/2)) else JAN_NEAR50000(round((order_pend_upto_jan+jan_dsp_order)/3))  end wk1,case when (order_pend_upto_jan+jan_dsp_order)<=100000 then 0 when (order_pend_upto_jan+jan_dsp_order)>100000 and  (order_pend_upto_jan+jan_dsp_order)<=200000 then(order_pend_upto_jan+jan_dsp_order)-JAN_NEAR50000(round((order_pend_upto_jan+jan_dsp_order)/2)) else JAN_NEAR50000(round((order_pend_upto_jan+jan_dsp_order)/3))  end wk2,case when (order_pend_upto_jan+jan_dsp_order)<=100000 then 0 when (order_pend_upto_jan+jan_dsp_order)>100000 and  (order_pend_upto_jan+jan_dsp_order)<=200000 then 0 else ((order_pend_upto_jan+jan_dsp_order))-JAN_NEAR50000((order_pend_upto_jan+jan_dsp_order)/3)*2  end wk3 from ("

                'sql &= "select CUSTOMER_ID,CUSTOMER_name,jan_cus_out_standing(A.CUSTOMER_ID)oss ,"
                'sql &= " nvl((select  sum(((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price)+tax_amount) from jan_sales_any_tb2_1  where customer_id=a.customer_id and nvl(order_type,0)<>201401 and schedule_ship_date<'1-feb-2014'  and (ordered_quantity-nvl(shipped_quantity,0))>0 and ord_type not like 'E1%' ),0)order_pend_upto_jan , "

                'sql &= "nvl((select  sum(((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price)+tax_amount) from jan_sales_any_tb2_1  where customer_id=a.customer_id and order_type=201401 and schedule_ship_date<'1-feb-2014'  and (ordered_quantity-nvl(shipped_quantity,0))>0 ),0)jan_dsp_order from ra_customers a where customer_class_code='DEALER' and customer_id=" & .Item("customer_id") & ")B"

                sql = "SELECT b.*, (order_pend_upto_jan+jan_dsp_order)total ,CASE WHEN (order_pend_upto_jan+jan_dsp_order)<=100000 THEN (order_pend_upto_jan+jan_dsp_order) ELSE JAN_NEAR50000(ROUND((order_pend_upto_jan+jan_dsp_order)/2)) END+decode(sign(oss),-1,0,oss) wk4, "

                sql &= " CASE WHEN (order_pend_upto_jan+jan_dsp_order)<=100000  THEN 0 ELSE (order_pend_upto_jan                     +jan_dsp_order)-JAN_NEAR50000(ROUND((order_pend_upto_jan+jan_dsp_order)/2)) END wk5 FROM  ("

                sql &= " SELECT CUSTOMER_ID,CUSTOMER_name ,jan_cus_out_standing(A.CUSTOMER_ID)oss , NVL((SELECT SUM(((ordered_quantity-NVL(shipped_quantity,0))*unit_selling_price)+tax_amount) FROM jan_sales_any_tb2_1 WHERE customer_id =a.customer_id AND NVL(order_type,0)<>201401 AND schedule_ship_date<'1-feb-2014' AND (ordered_quantity-NVL(shipped_quantity,0))>0 AND ord_type NOT LIKE 'E1%' and ordered_DAte<'10-jan-2014'),0)order_pend_upto_jan ,NVL((SELECT SUM(((ordered_quantity-NVL(shipped_quantity,0))*unit_selling_price)+tax_amount) FROM jan_sales_any_tb2_1 WHERE customer_id=a.customer_id  AND order_type=201401 AND schedule_ship_date<'1-feb-2014'  AND (ordered_quantity-NVL(shipped_quantity,0))>0 ),0)jan_dsp_order  FROM ra_customers a  WHERE   customer_id =" & .Item("customer_id") & " )B"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "val")


                S &= "<tr></tr>"
                S &= "<tr><td><table  class=tab>"

                S &= "<tr><td>DSP Jan 2014 Order Pending value</td><td>Rs:" & Format(ds1.Tables("val").Rows(0).Item("jan_dsp_order"), "00.00") & "</td></tr>"
                S &= "<tr><td>Other Order Pending value upto 10-Jan-2014</td><td>Rs:" & Format(ds1.Tables("val").Rows(0).Item("order_pend_upto_jan"), "00.00") & "</td><td></td></tr>"

                Dim tot, sub_tot As Double

                tot = ds1.Tables("val").Rows(0).Item("order_pend_upto_jan") + ds1.Tables("val").Rows(0).Item("jan_dsp_order")
                S &= "<tr><td><b>Total</b></td><td><b>Rs:" & Format(ds1.Tables("val").Rows(0).Item("TOTAL"), "00.00") & "</b><td></td></td></tr>"

                S &= "<tr><td>&nbsp;</td></tr>"
                S &= "<tr><td>* Value is inclusive of ED & other applicable taxes.</td></tr>"
                S &= "<tr><td><b> <u>Fund Plan</u></b></td></tr>"

                S &= "<tr><td>Total order pending value  Rs:" & Format(ds1.Tables("val").Rows(0).Item("TOTAL"), "00.00") & " , per week  Rs:" & Math.Round(tot / 2, 2) & " </td></tr>"
                S &= "</table></td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"
                sub_tot = Math.Round(tot / 2, 2)
                S &= "<tr><td><table width=80% align=center class=tab border=1 cellpading=0 cellspacing=0>"

                S &= "<tr><th>Wk No:4<br>20/01/14-25/01/14</th><th>Wk No:5<br>27/01/14-31/01/14</th></tr>"

                S &= "<tr><td align=right>" & Format(ds1.Tables("val").Rows(0).Item("WK4"), "00.00") & "</td><td  align=right>"

                If ds1.Tables("val").Rows(0).Item("WK5") > 0 Then S &= "" & Format(ds1.Tables("val").Rows(0).Item("WK5"), "00.00") & "" Else S &= "&nbsp;"

                S &= "</td>"
                S &= "</td></tr>"

                S &= "</table></td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"
                S &= "<tr><td>The Current outstanding , if any,is included in week no:4.</td></tr>"

                S &= "<tr><td>&nbsp;</td></tr>"

                S &= "<tr><td>Please ensure to make the payment as per the above Fund Plan on or before every <b>Thursday</b> of the week.</td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"

                S &= "<tr><td>Kindly contact us for clarifications, if any.</td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"
                S &= "<tr><td>Regards</td></tr>"
                S &= "<tr><td>R.Senthilkumar.</td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"
                S &= "<tr><td>CCto : BDM/Mktg office.</td></tr>"
                S &= "<tr><td>&nbsp;</td></tr>"
                S &= "</table>"
                S &= "<table width=80% align=center class=tab1>"
                S &= "<tr><td>Note:-</td></tr>"
                S &= "<tr><td>* In case if the payment as per the Fund plan is not made on or before every <b>Thursday</b>, then the TOD will get affected for the Fund Plan value (or) the actual despatch value whichever is higher.</td></tr>"
                S &= "<tr><td>* In case if the payment as per the Fund plan is  not made on or before every <b>Thursday</b>, further despatch will be on hold till the payment is made.</td></tr>"
                S &= "</table>"
                S &= "</html>"
                'ds1 = New DataSet

                'sql = "SELECT jan_orgcode(organization_id)org,  (SELECT description  FROM mtl_system_items  WHERE inventory_item_id=b.inventory_item_id  AND organization_id    =b.organization_id)description, b.*,NVL((SELECT customer_despatch_bucket FROM jan_customer_bucket WHERE inventory_item_id=b.inventory_item_id AND organization_id =b.organization_id AND customer_id=b.customer_id),'Monthly')ds from (select  customer_id,    ordered_item,    inventory_item_id,    organization_id, sum(total_ord_pend)total_ord_pend,sum(jan_dsp_ord_pend)jan_dsp_ord_pend,sum(other_ord_pend)other_ord_pend from (select a.*,(ordered_quantity -NVL(shipped_quantity,0)) total_ord_pend,case when nvl(order_type,0)=201401 then (ordered_quantity -NVL(shipped_quantity,0)) else 0 end jan_dsp_ord_pend,case when nvl(order_type,0)<>201401 then (ordered_quantity -NVL(shipped_quantity,0)) else 0 end other_ord_pend FROM jan_sales_any_tb2_1 a WHERE customer_id =" & .Item("customer_id") & "  AND schedule_ship_date<'1-feb-2014' ) where total_ord_pend>0 group by customer_id,ordered_item,inventory_item_id,organization_id)b"

                'adap = New OracleDataAdapter(sql, con)
                'adap.Fill(ds1, "items")

                'S1 = ""
                'S1 &= "<html>"
                'S1 &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                'S1 &= "<table width=80% align=center class=tab border=1 cellpading=0 cellspacing=0>"

                'S1 &= "<tr><th>Sl.No</th><th>Org</th><th>Item No</th><th>Description</th><th>Jan DSP Order Pending Qty</th><th>Other Order Pending Qty</th><th>Total Order Pending Qty</th><th>Schedule Despatch <br>Frequency</th></tr>"

                'For j = 0 To ds1.Tables("items").Rows.Count - 1

                '    S1 &= "<tr><td>" & j + 1 & "</td>"
                '    S1 &= "<td>" & ds1.Tables("items").Rows(j).Item("org") & "</td>"
                '    S1 &= "<td>" & ds1.Tables("items").Rows(j).Item("ordered_item") & "</td>"
                '    S1 &= "<td>" & ds1.Tables("items").Rows(j).Item("description") & "</td>"
                '    S1 &= "<td align=center>" & ds1.Tables("items").Rows(j).Item("jan_dsp_ord_pend") & "</td>"
                '    S1 &= "<td align=center>" & ds1.Tables("items").Rows(j).Item("other_ord_pend") & "</td>"
                '    S1 &= "<td align=center>" & ds1.Tables("items").Rows(j).Item("total_ord_pend") & "</td>"

                '    If ds1.Tables("items").Rows(j).Item("ds") = "Quarterly" Then
                '        S1 &= "<td>Monthly</td>"
                '    Else
                '        S1 &= "<td>" & ds1.Tables("items").Rows(j).Item("ds") & "</td>"
                '    End If

                '    S1 &= "</tr>"
                'Next
                'S1 &= "</table>"

                'S1 &= "<table width=80% align=center class=tab> "
                'S1 &= "<tr ></tr>"
                'S1 &= "<tr><td colspan=2><b>Brief of Schedule Despatch Frequency</b><td></tr>"
                'S1 &= "<tr ><td colspan=2>&nbsp;</td></tr>"

                'S1 &= "<tr rowspan=3><td>Weekly Items</td><td>-Pending Qty will be distributed equally for four (subject to MOQ)weeks.</td></tr>"
                'S1 &= "<tr><td></td><td>-Despatch will be on weekly basis and the qty will be weekly qty in full.</td></tr>"
                'S1 &= "<tr ><td colspan=2>&nbsp;</td></tr>"

                'S1 &= "<tr rowspan=2><td>Fortnight Items</td><td>-Pending Qty will be distributed equally for two weeks (alternative weeks).</td></tr>"

                'S1 &= "<tr><td></td><td>-Despatch will be  made in that particular alternative week and the qty will be in full.</td></tr>"

                'S1 &= "<tr ><td colspan=2>&nbsp;</td></tr>"

                'S1 &= "<tr><td>Monthly Items</td><td>-Pending Qty will be dispatched in full qty in anyone of the four weeks.</td></tr>"

                'S1 &= "</table>"




                'S1 &= "</html>"
                Dim FSTRM As New FileStream("D:\Dealer_mail\" & .Item("customer_name") & ".html", FileMode.Create, FileAccess.Write)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(S)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()
                'sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent,program_mail_id) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Dealer Mails','feedback@janatics.co.in','sales07@janatics.co.in,senthil-bdm@janatics.co.in,it-dev7@janatics.co.in','Schedule Despatch Frequency','" & S.Replace("'", "''") & "',0,'it-dev7@janatics.co.in')"
                'comand()

                'Dim file_name As String
                'file_name = "D:\Dealer_mail\" & .Item("customer_name") & ".html"

                'Dim mail_no As Integer

                'sql = "select jan_test_seq.currval task_id from dual"
                'cmd = New OracleCommand(sql, con)
                'If con.State = ConnectionState.Closed Then con.Open()
                'dr = cmd.ExecuteReader
                'If dr.HasRows = True Then mail_no = dr.Item("task_id")

                'Dim cmd1 As New OracleClient.OracleCommand
                'Dim blob() As Byte = System.IO.File.ReadAllBytes(file_name)
                'sql = "UPDATE jan_mail_system SET mail_ATTACH=:BlobParameter,mail_attach_file_name='" & System.IO.Path.GetFileName(file_name) & "' WHERE mail_no=" & mail_no & ""
                'Dim blobParameter As OracleClient.OracleParameter = New OracleClient.OracleParameter()
                'blobParameter.OracleType = OracleClient.OracleType.Blob
                'blobParameter.ParameterName = "BlobParameter"
                'blobParameter.Value = blob
                'If orcon.State = ConnectionState.Closed Then orcon.Open()
                'cmd1 = New OracleClient.OracleCommand(sql, orcon)
                'cmd1.Parameters.Add(blobParameter)
                'cmd1.ExecuteNonQuery()
                'orcon.Close()


            End With
        Next

    End Sub
    Private Sub LESS_PAYMENT_DELAY()

        Dim MAIL_dt As Date
        'MAIL_dt = ds.Tables("dt").Rows(0).Item("sys_dt")

        sql = "select  customer_name,customer_id,party_id ,sysdate dt,to_char(NEXT_DAY(TRUNC(SYSDATE),'SATURDAY')-6 ,'IW') wk_no ,to_char(NEXT_DAY(TRUNC(SYSDATE)-6,'SATURDAY'),'Mon-DD') pay_dt"

        sql &= ",rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID='||a.party_id||')') mail_id,(select mail_id from jan_mail_address where region in( select region from JAN_BMS_CUSTOMER_REGION_V where customer_id=a.customer_id))reg_mail_id "

        sql &= ",nvl((select  sum(payment_value-rsv2)val from jan_dealer_payment2  where cust_id=a.customer_id and payment_exp_date=NEXT_DAY(TRUNC(SYSDATE),'SATURDAY')-7),0)less_payment "

        sql &= ",nvl((select  sum(payment_value)val from jan_dealer_payment2  where cust_id=a.customer_id and payment_exp_date=NEXT_DAY(TRUNC(SYSDATE),'SATURDAY')-7),0)total_payment "

        sql &= ",nvl((select  sum(rsv2)val from jan_dealer_payment2  where cust_id=a.customer_id and payment_exp_date=NEXT_DAY(TRUNC(SYSDATE),'SATURDAY')-7),0)payment_made "

        sql &= ",(select  sysdate-1 from dual )as_on "

        sql &= " from ra_customers a where customer_class_code='DEALER'  "
        SQL_SELECT("cust", sql)
        ds2 = New DataSet

        ds2 = ds.Copy

        For i = 0 To ds2.Tables("cust").Rows.Count - 1
            With ds2.Tables("cust").Rows(i)

                'sql = "select  cust_id,b_cust_name,sum(payment_value-rsv2)val from jan_dealer_payment2  where cust_id=1387 and payment_exp_date<NEXT_DAY(TRUNC(SYSDATE),'SATURDAY')-6 group by cust_id, b_cust_name"

                'SQL_SELECT("less_payment", sql)

                If .Item("less_payment") >= 500 Then


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"
                    S &= "<tr><td align=right>" & Format(.Item("Dt"), "dd-MMM-yyyy") & "</td></tr>"
                    S &= "<tr><td>  To- M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td>Dear Sir,</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td><b>Sub : Less payment delay for Wk No:" & .Item("wk_no") & "-reg.(Payment scheduled on " & .Item("pay_dt") & ")</td></tr>"


                    S &= "<tr><td><br></td></tr>"
                    'S &= "<tr><td>We would like to inform you that your payment of Rs." & Format(.Item("less_payment"), "00.00") & " (as per the payment calendar ) is not received by us as on date. Please find below the detail.</td></tr>"

                    S &= "<tr><td>This refers to the payment calendar scheduled for Wk No:" & .Item("wk_no") & " .</td></tr><tr><td>We would like to inform you that Rs." & Format(.Item("less_payment"), "00.00") & " is not received from you( as on date) for the mentioned payment calendar schedule. Please find below the details:</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td><b>Status as on " & Format(.Item("as_on"), "dd-MMM-yyyy") & "</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>"
                    S &= " <table class=tab >"

                    S &= "<tr><td width=30%>Actual payment scheduled (DSP+Manual order) </td><td width=5% align=right >Rs.</td><td align=right  width=10%>" & Format(.Item("total_payment"), "00.00") & "</td><td  width=55%></td></tr>"
                    S &= "<tr><td>Payment Received for Wk No:" & .Item("wk_no") & "</td><td width=5% align=right>Rs.</td><td align=right>" & Format(.Item("payment_made"), "00.00") & "</td><td ></td></tr>"
                    S &= "<tr><td>&nbsp;</td><td width=5%>&nbsp;</td><td ><hr></td><td ></td></tr>"

                    S &= "<tr><td>Payment not Received </td><td width=5% align=right>Rs.</td><td align=right>" & Format(.Item("less_payment"), "00.00") & "</td><td ></td></tr>"
                    S &= "<tr><td>&nbsp;</td><td width=5%>&nbsp;</td><td ><hr></td><td ></td></tr>"
                    S &= "</tr><tr></table></td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>Hence this payment not received value will be treated as <b>""Payment delay""</b> and will not be considered for TOD.</td></tr>"


                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>In case if it is already paid , please send us the details.</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>We will verify and update you.</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    'S &= "<tr><td>In case if it is already paid , please send us the details.</td></tr>"


                    S &= "<tr><td>Regards</td></tr>"
                    S &= "<tr><td>R.Senthilkumar</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>ccto : BDM \ MKTG office.</td></tr>"
                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td><b><u>Note:</td></tr>"
                    S &= "<tr><td><b>We request you to make the payment in time as per the calendar to avoid further such payment delay.</td></tr>"


                    S &= "</table><br>"
                    S &= "<table width=80% align=center class=tab1><tr><td><b>Disclaimer</b></td></tr><tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr><tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr><tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr></table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try


                        End Try
                    Next



                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                    If Not IsDBNull(.Item("mail_id")) Then sql &= "  mail_cc,"
                    sql &= " MAIL_SUBJECT, "
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    If Not IsDBNull(.Item("mail_id")) Then sql &= "'" & .Item("mail_id") & "' ,'" & .Item("reg_mail_id") & ",latha@janatics.co.in' ," Else sql &= "'" & .Item("reg_mail_id") & ",latha@janatics.co.in' ,"
                    'sql &= "'senthil-bdm@janatics.co.in' ,'it-dev7@janatics.co.in,latha@janatics.co.in' ,"

                    sql &= " 'Less Payment Delay',"
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j) & "'"
                        Else
                            sql &= ",'" & longlist(j) & "'"
                        End If
                    Next
                    sql &= ",0)"

                    comand()

                End If

            End With
        Next

    End Sub
    Private Sub payment_advice_for_unapplied()



        'sql = "select distinct segment14 region from ra_territories where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA','MUMBAI-1','EXPORT')"
        sql = "select a.*,(select MAIL_ID from JAN_MAIL_ADDRESS where REGION=a.REGION)REG_MAIL_ID,(select BDM_MAIL_ID from JAN_MAIL_ADDRESS where REGION=a.REGION)BDM_MAIL_ID from (select distinct segment14 region from ra_territories   where segment14 not in ('M.P.','NOT LISTED','PROJECTS 1','GOA','MUMBAI-1','H.O'))a"

        SQL_SELECT("region", sql)
        ds2 = New DataSet

        ds2 = ds.Copy

        For i = 0 To ds2.Tables("region").Rows.Count - 1
            With ds2.Tables("region").Rows(i)

                sql = "select * from (select CUSTOMER_NAME,NVL(JAN_CUS_PP(a.CUSTOMER_ID),0)UNAPPLIED,(select TER.SEGMENT14 from  RA_ADDRESSES_ALL ADS, RA_SITE_USES_ALL SIT,  RA_TERRITORIES TER where  ADS.ADDRESS_ID=SIT.ADDRESS_ID and a.CUSTOMER_ID=ADS.CUSTOMER_ID and TER.TERRITORY_ID=SIT.TERRITORY_ID and rownum=1)REGION  from RA_CUSTOMERS a where customer_name  not like 'JANATIC%' and customer_class_code<>'DEALER') WHERE unapplied>500 and  region='" & .Item("region") & "' order by CUSTOMER_NAME"
                SQL_SELECT("cust", sql)
                Dim ds_cust As New DataSet
                ds_cust = ds.Copy
                If ds_cust.Tables("cust").Rows.Count > 0 Then



                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"
                    'S &= "<tr><td align=right>" & Format(.Item("Dt"), "dd-MMM-yyyy") & "</td></tr>"
                    S &= "<tr><td>  Dear Friends,</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td>We give below the details of unapplied payments available.</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td>Kindly check with the customer and send their payment advice/invoice details so that the same can be adjusted against outstanding.</td></tr>"


                    S &= "<tr><td><br></td></tr>"


                    S &= "<tr><td>Please register the invoice details in Payment in CRM option available in BMS .</td></tr>"

                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td ><table class=tab border=1 cellpadding=4 cellspacing=0>"
                    S &= "<tr><th >Sl.No.</th><th >Customer Name</th><th >Unapplied Payment</th></tr>"

                    Dim c_cnt As Integer = 0
                    For c_cnt = 0 To ds_cust.Tables("cust").Rows.Count - 1
                        With ds_cust.Tables("cust").Rows(c_cnt)
                            S &= "<tr>"
                            S &= "<td align=center>" & c_cnt + 1 & "</td>"
                            S &= "<td>" & .Item("CUSTOMER_NAME") & "</td><td align=right>" & Format(.Item("UNAPPLIED"), "00.00") & "</td>"
                            S &= "</tr>"
                        End With
                    Next
                    S &= " </tr></table></td></tr>"


                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td>To Know more details please visit BMS Payment Followp screen -  Unapplied .</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td>Head Office.</td></tr>"
                    S &= "<tr><td><br></td></tr>"

                    S &= "<tr><td><b><u>Note:</td></tr>"
                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>This is computer generated email. Please do not reply to this mail-id. For any queries /assistance , please contact us .</td></tr>"


                    S &= "</table><br>"
                    'S &= "<table width=80% align=center class=tab1><tr><td><b>Disclaimer</b></td></tr><tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr><tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr><tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr></table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try


                        End Try
                    Next



                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,mail_cc,"

                    'If Not IsDBNull(.Item("mail_id")) Then sql &= "  "
                    sql &= " MAIL_SUBJECT, "
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    ''If Not IsDBNull(.Item("mail_id")) Then sql &= "'" & .Item("mail_id") & "' ,'" & .Item("reg_mail_id") & ",latha@janatics.co.in' ," Else 
                    sql &= "'" & .Item("reg_mail_id") & ""
                    If Not IsDBNull(.Item("BDM_MAIL_ID")) Then sql &= "," & .Item("BDM_MAIL_ID") & ""

                    sql &= "' ,"

                    sql &= "'vanitha@janatics.co.in,accts-ar@janatics.co.in,IT-DEV7@janatics.co.in',"

                    sql &= " 'Payment Advice/Invoice Details',"
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j) & "'"
                        Else
                            sql &= ",'" & longlist(j) & "'"
                        End If
                    Next
                    sql &= ",0)"

                    comand()
                End If

            End With
        Next

    End Sub
    Private Sub UNIDENTIFIED_LIST_CHEQUE_RETURN()

        sql = "select pay_from_customer,RECEIPT_NUMBER,RECEIPT_DATE,AMOUNT,COMMENTS,CUSTOMER_RECEIPT_REFERENCE,REMITTANCE_BANK_ACCOUNT_ID,NVL((select BANK_NAME from AP_BANK_BRANCHES where BANK_BRANCH_ID=a.REMITTANCE_BANK_ACCOUNT_ID ),'Indus Ind Bank')REMITTANCE_BANK,ROWTOCOL('select DISTINCT MAIL_ID from jan_mail_Address where region not in (''M.P.'',''NOT LISTED'',''PROJECTS 1'',''GOA'',''MUMBAI-1'',''HO'')')MAIL_ID from ar_cash_receipts_all a where STATUS like 'UNID'   and receipt_date>=(SELECT UNIDENTIFIED_LIST_MAIL_FROM  FROM JAN_SALES_BI_SETUP)  and AMOUNT>0  order by RECEIPT_DATE,RECEIPT_NUMBER" 'and receipt_date>=NEXT_DAY(TRUNC(sysdate-1) ,'MON')-7

        SQL_SELECT("unidentified", sql)
        ds2 = New DataSet

        ds2 = ds.Copy


        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

        S &= "<table width=80% align=center class=tab>"
        S &= "<tr><td>  Dear Friends,</td></tr>"
        S &= "<tr><td><br></td></tr>"

        S &= "<tr><td>We give below the details of unidentified payments.</td></tr>"
        S &= "<tr><td><br></td></tr>"

        S &= "<tr><td>Kindly check with the customer and send the details of customer name, payment advice and invoice details so that the same can be adjusted in the respective customer account.</td></tr>"


        S &= "<tr><td><br></td></tr>"
        S &= "<tr><td><U><B>UNIDENTIFIED LIST</td></tr>"
        S &= "<tr><td><br></td></tr>"
        S &= "<tr><td ><table class=tab border=1 cellpadding=4 cellspacing=0>"
        S &= "<tr><th >Sl.No.</th><th >Receipt No</th><th>Receipt Date</th><th >Net Receipt Amount</th><th >Reference</th><th >Remittence Bank</th><th >Comments</th></tr>"

        Dim c_cnt As Integer = 0

        For c_cnt = 0 To ds2.Tables("unidentified").Rows.Count - 1
            With ds2.Tables("unidentified").Rows(c_cnt)

                S &= "<tr>"
                S &= "<td align=center>" & c_cnt + 1 & "</td>"
                S &= "<td>" & .Item("RECEIPT_NUMBER") & "</td><td align=right>" & Format(.Item("receipt_date"), "dd-MMM-yyyy") & "</td><td align=right>" & Format(.Item("amount"), "00.00") & "</td><td>" & .Item("CUSTOMER_RECEIPT_REFERENCE") & "</td><td>" & .Item("REMITTANCE_BANK") & "</td><td>" & .Item("comments") & "</td>"
                S &= "</tr>"
            End With
        Next
        S &= " </tr></table></td></tr>"


        S &= "<tr><td><br></td></tr>"



        'S &= "<tr><td>We request you to check with the customer immediately and send the details within 7 days so that the same can be accounted in the respective customer account without any delay.</td></tr>"


        'S &= "<tr><td>To Know more details please visit BMS Payment Followp screen -  Unapplied .</td></tr>"
        'S &= "<tr><td><br></td></tr>"

        S &= "<tr><td>With Regards,</td></tr>"
        S &= "<tr><td>Marketing Department.</td></tr>"
        S &= "<tr><td>Head Office.</td></tr>"
        S &= "<tr><td><br></td></tr>"

        S &= "<tr><td><b><u>Note:</td></tr>"
        S &= "<tr><td><br></td></tr>"
        S &= "<tr><td>This is computer generated email. Please do not reply to this mail-id. For any queries /assistance , please contact us .</td></tr>"
        S &= "</table><br>"

        S &= "</html>"

        Dim longlist As New List(Of String)
        For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
            Try
                longlist.Add(S.Substring(j * 3950, 3950))
            Catch ex As Exception
                Try
                    longlist.Add(S.Substring(j * 3950))
                Catch ex1 As Exception

                End Try


            End Try
        Next



        sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,mail_cc,"

        sql &= " MAIL_SUBJECT, "
        For j = 0 To longlist.Count - 1
            If j = 0 Then
                sql &= " MAIL_BODY"
            Else
                sql &= " ,MAIL_subject_" & j + 1
            End If
        Next
        sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

        sql &= "'" & ds2.Tables("unidentified").Rows(0).Item("mail_id") & "',"
        'If Not IsDBNull(.Item("BDM_MAIL_ID")) Then sql &= "," & .Item("BDM_MAIL_ID") & ""

        'sql &= " ' ,"
        'sql &= "'IT-DEV7@janatics.co.in',"

        sql &= "'vanitha@janatics.co.in,accts-ar@janatics.co.in,IT-DEV7@janatics.co.in',"

        sql &= " 'Unidentified Payment List',"
        For j = 0 To longlist.Count - 1
            If j = 0 Then
                sql &= "'" & longlist(j) & "'"
            Else
                sql &= ",'" & longlist(j) & "'"
            End If
        Next
        sql &= ",0)"

        comand()
        '    End With
        'Next

    End Sub
    Private Sub fillheader()

        With ds.Tables("inv_det").Rows(0)




            sql &= "<html>"
                sql &= "<head><title>Invoice No :" & .Item("trx_number") & "</title> <link href='expcss.css' rel='stylesheet' type='text/css'/></head>"
                sql &= "<body><div style='position:absolute;width:100%;z-index:0' align='center'><table width=90% border=0 cellpadding=0 cellspacing=0><tr><td align=right><img src='Images/Jana_logo.png' /></td></tr></table></div><br><BR><BR>"

                sql &= "<table style='height:95%;width:90%' align=center border=0 cellspacing=3 cellpadding=0>"

                sql &= "<tr valign=top height='10px'>"
                sql &= "<td colspan=2 style='width:50%' align='center' valign='bottom' class='txthdrr'>INVOICE</td>"
                sql &= "</tr>"


                sql &= "<tr valign=top height='10px'>"



                sql &= "<td valign='top' align='left'  class='txt10' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;padding-top:10px;padding-left:10px;padding-bottom:10px;'><b>JANATICS USA INC</b><br>1275 Glenlivet Drive Suite 100,<br />Allentown, <br />PA 18106, USA,<br>Phone : 16107371695<br>E-mail : seshb@janaticsusa.com</td>"





                sql &= "<td style='width:50%;padding-top:0px;padding-bottom:0px;padding-left:0px;padding-right:0px' align='right' valign='bottom'>"

                sql &= "<table height='100%' width='100%' align=center border=0 cellspacing=0 cellpadding=2> "

                sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Invoice No&nbsp;&nbsp;</td><td class='txt9'  style='width:100%;BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & .Item("trx_number") & "&nbsp;&nbsp;</td></tr>"



                sql &= "<tr><td class='txt9' style='width:50%;BORDER-RIGHT: black 1px solid;  BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid'>Invoice Date&nbsp;&nbsp;</td><td class='txt9' style='width:100%;BORDER-RIGHT: black 1px solid;  WIDTH: 100%; BORDER-BOTTOM: black 1px solid'>" & Format(CDate(.Item("trx_date")), "MM") & "/" & Format(CDate(.Item("trx_date")), "dd") & "/" & Format(CDate(.Item("trx_date")), "yyyy") & "&nbsp;&nbsp;</td></tr>"



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


        End With

    End Sub
    Private Sub us_invoice()
        Dim ilsql As String
        Dim invlds As New DataSet
        Dim inv_tot As Double = 0
        Dim TOTQTY As Double = 0
        Dim ds As New DataSet
        Dim inv_no As String = "2020600141"

        sql = "select "
        sql &= "(select CUSTOMER_NAME from jan_eo_customer_master_BILL_TO where customer_id=A.BILL_TO_CUSTOMER_ID AND site_use_code='BILL_TO' AND SITE_USE_ID=A.BILL_TO_SITE_ID) BILLTO_NAME,"
        sql &= "(select ADDRESS from jan_eo_customer_master_BILL_TO where customer_id=A.BILL_TO_CUSTOMER_ID AND site_use_code='BILL_TO'  AND SITE_USE_ID=A.BILL_TO_SITE_ID) BILLTO_ADDR,"
        sql &= "(select CUSTOMER_NAME from jan_eo_customer_master_ship_to where customer_id=A.SHIP_TO_CUSTOMER_ID AND site_use_code='SHIP_TO'  AND SITE_USE_ID=A.SHIP_TO_SITE_ID) SHIPTO_NAME,"
        sql &= "(select ADDRESS from jan_eo_customer_master_SHIP_TO where customer_id=A.SHIP_TO_CUSTOMER_ID AND site_use_code='SHIP_TO'  AND SITE_USE_ID=A.SHIP_TO_SITE_ID) SHIPTO_ADDR,"
        sql &= "A.TRX_NUMBER,A.TRX_DATE,A.CUSTOMER_PO_NO,A.PAY_TERMS,A.SHIPPING_INSTRUCTIONS,A.TRACKING_NO,NVL(A.OTHER_CHARGES,0) OTHER_CHARGES,NVL(A.FREIGHT_CHARGES,0)FREIGHT_CHARGES,NVL(A.OTHER_CHARGE_DETAILS,0) OTHER_CHARGE_DETAILS,A.*  from jan_eo_customer_trx_all A where trx_number=" & inv_no


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
        sql &= " where trx_number='" & inv_no & "' AND ROWNUM=1"
        ' Response.Write(sql)
        ' Exit Sub

        ds = SQL_SELECT("inv_det", sql)
        sql = ""
        With ds.Tables("inv_det").Rows(0)


            fillheader()




            ilsql = "select rownum,package_ref,(SELECT INVOICE_ITEM_NO FROM JAN_EO_ITEM_MASTER WHERE INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID) item_no,ITEM_DESCRIPTION,INVOICE_QTY,PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((INVOICE_QTY * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT from jan_eo_customer_trx_lines_all A where customer_trx_id=" & .Item("customer_trx_id") & " order by row_ref"

            ilsql = "select rownum,NULL package_ref,ORDERED_ITEM item_no,DESCRIPTION ITEM_DESCRIPTION,QUANTITY_INVOICED INVOICE_QTY,UOM PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((QUANTITY_INVOICED * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT,C_ORDER_NO,c_order_date FROM apps.JAN_INVOICE_LISTING_OU A "
            ilsql &= " where trx_number='" & inv_no & "'"
            ilsql &= " ORDER BY CUSTOMER_TRX_LINE_ID"

            ilsql = "select rownum,NULL package_ref,NVL((select INVOICE_ITEM_NO from JAN_EO_ITEM_MASTER where INVENTORY_ITEM_ID=(select INVENTORY_ITEM_ID from RA_CUSTOMER_TRX_LINES_ALL where CUSTOMER_TRX_LINE_ID=a.CUSTOMER_TRX_LINE_ID) and rownum=1),(select SEGMENT1 from MTL_SYSTEM_ITEMS where INVENTORY_ITEM_ID=(select INVENTORY_ITEM_ID from RA_CUSTOMER_TRX_LINES_ALL where CUSTOMER_TRX_LINE_ID=a.CUSTOMER_TRX_LINE_ID) and rownum=1)) ITEM_NO,"
            ilsql &= " DESCRIPTION ITEM_DESCRIPTION,QUANTITY_INVOICED INVOICE_QTY,UOM PRIMARY_UOM,  UNIT_SELLING_PRICE,  ROUND((QUANTITY_INVOICED * UNIT_SELLING_PRICE),2)  LINE_TOTAL_AMOUNT,C_ORDER_NO,c_order_date,tariff_no FROM apps.JAN_INVOICE_LISTING_OU A "
            ilsql &= " where trx_number='" & inv_no & "'"
            ilsql &= " ORDER BY CUSTOMER_TRX_LINE_ID"
            'Response.Write(ilsql)
            'Exit Sub

            invlds = SQL_SELECT("inv_lines", ilsql)
            'sql = " "
            'sql &= "<head><style type=text/css>.txt8{	font-family: Verdana;	color: black;	font-size: 8pt;	text-decoration:none;}</style><style type=text/css>.txt7{	font-family: Verdana;	color: black;	font-size: 8pt;}</style><style type=text/css>.txt8w{	font-family: Verdana;	color: white;	font-size: 8pt;}</style><style type=text/css>.txt8right{	font-family: Verdana;	color: black;	font-size: 8pt;	text-align:right;	}</style><style type=text/css>.txt9{	font-family: Verdana;	color:black;	font-size: 8pt;	text-decoration:none;}</style><style type=text/css>.txt9w{	font-family: Verdana;	color: white;	font-size: 9pt;	text-ecoration:none;}</style><style type=text/css>.txt10{	font-family: Verdana;	color: black;	font-size: 10pt;}.txt10w{	font-family: Verdana;	color: white;	font-size: 10pt;}</style><style type=text/css>.txthdr{	font-family: Verdana;	color: black;	font-size: 15pt;	text-align:center;	letter-spacing:2px;}</style><style type=text/css>.txthdrr{	font-family: Verdana;	color: black;	font-weight:bold;	font-size: 20pt;/*	letter-spacing:2px;*/}</style><style type=text/css>.txt8r{	font-family: Verdana;	color: black;	font-size: 8pt;	text-align:right;}</style><style type=text/css>.txt9r{	font-family: Verdana;	color: black;	font-size: 9pt;	text-align:right;}</style><style type=text/css>.txt9gr{	font-family: Verdana;	color: black;	font-size: 9pt;	text-align: right;	border-bottom: gainsboro 1px solid;	border-left: gainsboro 1px solid;	background-color: Yellow;	border-top: gainsboro 1px solid;	border-right: gainsboro 1px solid;	padding-bottom: 2px;	padding-left: 2px;	padding-top: 2px;	padding-right: 2px;}</style><style type=text/css>.txt8gr{	font-family: Verdana;	color: black;	font-size: 8pt;	text-align: right;	border-bottom: gainsboro 1px solid;	border-left: gainsboro 1px solid;	background-color: Yellow;	border-top: gainsboro 1px solid;	border-right: gainsboro 1px solid;}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

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


                    brdr = "style='BORDER-left: black 1px solid;BORDER-bottom: BLACK 1px solid;' "


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

                sql &= "<tr valign=bottom height='20px'>"
                sql &= " <td class='txt8'  width='5%'  colspan=5 align=right style='BORDER-top: BLACK 1px solid;BORDER-RIGHT: BLACK 1px solid;'>" & .Item("FREIGHT_CHARGE_details") & "&nbsp;&nbsp;</td>"
                    sql &= " <td  width='20%' class='txt8'  style='BORDER-top: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("FREIGHT_CHARGES")), 2), "0.00") & "</td>"
                    sql &= " </tr>"

            End If


            inv_tot += Math.Round(CDbl(.Item("FREIGHT_CHARGES")), 2)
            If CDbl(.Item("Other_CHARGES")) > 0 Then

                sql &= "<tr valign=bottom height='20px'>"
                    sql &= " <td class='txt8'  width='5%'  colspan=5 align=right style='BORDER-top: BLACK 1px solid;BORDER-RIGHT: BLACK 1px solid;'>" & .Item("OTHER_CHARGE_DETAILS") & "&nbsp;&nbsp;</td>"
                    sql &= " <td  width='20%' class='txt8'  style='BORDER-top: BLACK 1px solid;'  align='right'>" & Format(Math.Round(CDbl(.Item("Other_CHARGES")), 2), "0.00") & "</td>"
                    sql &= " </tr>"

                End If

            inv_tot += Math.Round(CDbl(.Item("Other_CHARGES")), 2)




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


            sql &= "</body>"
            sql &= "</html>"
            Dim FSTRM As New FileStream("C:\Despatch_details\" & inv_no & ".html", FileMode.Create, FileAccess.Write)
            Dim SW As StreamWriter = New StreamWriter(FSTRM)

            SW = New StreamWriter(FSTRM)
            SW.Write(sql)
            FSTRM.Flush()
            SW.Flush()
            SW.Close()
            FSTRM.Close()

            Dim batch_file_content As String = "" '= "@ECHO OFF" & vbNewLine

            batch_file_content &= "C:\Despatch_details\wkhtmltopdf C:\Despatch_details\" & inv_no & ".html  C:\Despatch_details\" & inv_no & ".pdf --margin-left 0mm --margin-right 0mm --margin-top 0mm --disable-smart-shrinking --page-size A4"
            'batch_file_content &= "c:\U1_TRIPLICATE_PDF\wkhtmltopdf c:\U1_TRIPLICATE_PDF\" & dgv_inv.Rows(0).Cells(0).Value & ".html  c:\U1_TRIPLICATE_PDF\" & dgv_inv.Rows(0).Cells(0).Value & ".pdf --margin-left 0mm --margin-right 0mm --margin-top 0mm --disable-smart-shrinking --page-size A4"

            X = "C:\Despatch_details\" & inv_no & ".bat"
            'X = "c:\U1_TRIPLICATE_PDF\" & dgv_inv.Rows(0).Cells(0).Value & ".bat"

            Dim FSTRM1 As New FileStream(X, FileMode.Create, FileAccess.Write)
            Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)

            SW1 = New StreamWriter(FSTRM1)
            SW1.Write(batch_file_content)
            FSTRM1.Flush()
            SW1.Flush()
            SW1.Close()
            FSTRM1.Close()
            Shell("C:\Despatch_details\" & inv_no & ".bat")
            Thread.Sleep(2000)
            System.Diagnostics.Process.Start("C:\Despatch_details\" & inv_no & ".pdf")


        End With
writeinv:

    End Sub
    Private Sub Out_Mails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'us_invoice()

        'LESS_PAYMENT_DELAY()
        'dealer_payment_new()
        'Dealer_mail() 'Fund Plan
        'dealer_payment_status()
        'vendor_mail()
        'BRANCH_PLAN_VS_ORDER()
        'Me.Close()
        'Exit Sub


        sql = "DELETE FROM jan_mail_system WHERE mail_program='Customer Mails' AND TRUNC(mail_date)<TRUNC(SYSDATE)-90"
        comand()


        sql = "select TRUNC(JAN_preDATE_CNT(TRUNC(SYSDATE),1))dt,TO_CHAR(SYSDATE,'DD')dy1,trunc(sysdate)sys_dt,case when to_char(sysdate,'dd')=10 then 1  when to_char(sysdate,'dd')=20 then 1 when trunc(last_day(sysdate))=trunc(sysdate) then 1 else 0 end dy ,to_char(sysdate,'DY')day from dual "
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "dt")
        DateTimePicker1.Value = ds.Tables("dt").Rows(0).Item("dt")

        Dim day_check_for_clp_price_rev_mail As String = ""
        day_check_for_clp_price_rev_mail = ds.Tables("dt").Rows(0).Item("day")

        ''Payment Reminder Mails*********************************
        'If Trim(ds.Tables("dt").Rows(0).Item("dy")) = 1 Then
        'payment_reminder() 'send at 6PM on 10,20,30 th of every month
        'End If
        ''Dealer_overdue() 'send at 6 PM
        '' ''****************************************


        'Try  ''Mail blocked on 6jun2019 requested by Vanithamani
        '    If (Trim(ds.Tables("dt").Rows(0).Item("dy1")) = "05") Or (Trim(ds.Tables("dt").Rows(0).Item("dy1")) = "20") Then
        '        pay_cform()
        '    End If
        '    'If day_check_for_clp_price_rev_mail = "MON" Then 'mail stop sending based on 27-jan-2015 based on tamilselvi mail
        '    '    clp_revision_pending()
        '    'End If
        'Catch ex As Exception
        '    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Customer Auto Mail- CForm Reminder')"
        '    comand()
        'End Try

        Try 'order acceptance
            order_acceptance()
            order_acceptance_us()
        Catch ex As Exception
            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Customer Auto Mail- OA acceptance')"
            comand()
        End Try

        Try 'despatch detail
            despatch_detail() 'send twice in a day
        Catch ex As Exception
            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Customer Auto Mail- Despatch Detail')"
            comand()
        End Try

        Try 'Payment Receipt
            payment_receipt()
            payment_receipt_blocked_cust()
        Catch ex As Exception
            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Customer Auto Mail- Payment Receipt')"
            comand()
        End Try

        'Try 'Cform Receipt
        '    cform_receipt()
        'Catch ex As Exception
        '    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Customer Auto Mail- CForm Receipt')"
        '    comand()
        'End Try

        sql = "delete from jan_mail_system where trunc(mail_date)=trunc(sysdate) and mail_program='Customer Mails' and mail_to is null"
        comand()

        Try

            If day_check_for_clp_price_rev_mail = "MON" Then 'mail stop sending based on 27-jan-2015 based on tamilselvi mail
                payment_advice_for_unapplied()
                UNIDENTIFIED_LIST_CHEQUE_RETURN()

            End If
        Catch ex As Exception
            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Payment Advice/Invoice Details')"
            comand()
        End Try

        Me.Close()
    End Sub
    Private Sub BRANCH_PLAN_VS_ORDER()

        sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00007','branch plan vs actual',sysdate) "
        comand()



        sql = "select distinct SEGMENT14 REGION,sysdate todays_date from ra_territories where  SEGMENT14   not in ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O','MUMBAI-1','APPLICATION-1','DELHI 2','DELHI 3','CHENNAI-4') and SEGMENT14 not like 'EXP%' ORDER BY 1"
        'SEGMENT14='GUJARAT'"
        ' not in ('GOA','M.P.','PROJECTS 1','NOT LISTED','H.O','MUMBAI-1') ORDER BY 1"
        ds1 = SQL_SELECT("REG", sql)

        Dim ds2_wk As New DataSet
        sql = "select  DISTINCT TO_CHAR(ORDER_FF_DT,'IWIYYY')wk from JAN_SALES_ANY_TB2_1 where  truNC(ORDER_FF_DT)>=TRUNC(SYSDATE,'MONTH')  AND  TRUNC(ORDER_FF_DT)<LAST_DAY(TRUNC(SYSDATE,'MONTH'))+1  and ORDERED_QUANTITY>0 order by 1"
        ds2_wk = SQL_SELECT("WEEK", sql)


        For I As Integer = 0 To ds1.Tables("REG").Rows.Count - 1

            sql = "select region ""Region"",jan_orgcode(ORGANIZATION_ID)""Org"",item_no ""Item No"",description ""Description"",rrs ""RRS"",(bin_qty+fg_qty) ""Plan Qty"""

            For ii = 1 To ds2_wk.Tables("week").Rows.Count
                sql &= " ,wk" & ii & ""

            Next
            sql &= " ,ordered_quantity ""Cur Month Order receipt Qty"",YESTERDAY_BOOKED_ORD_QTY ""Yesterday's order booked qty"",CASE  WHEN (bin_qty+fg_qty) =0 THEN  'Not in Plan' WHEN (bin_qty+fg_qty)>=ORDERED_QUANTITY THEN 'Covered in Plan' WHEN (bin_qty+fg_qty)<=ORDERED_QUANTITY THEN 'Excess to Plan' ELSE 'Not in Plan' END ""Plan Status""  from (select '" & ds1.Tables("REG").Rows(I).Item("REGION") & "' region ,organization_id,inventory_item_id,segment1 item_no,description ,NVL((SELECT FINAL_RRS FROM JAN_RRS_CATEGORY_MASTER WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID  ),'St') RRS,NVL((select SUM(ROQ+ROL) from  JAN_CUSTOMER_REPLENISHMENT_V  where   ORGANIZATION_ID=A.ORGANIZATION_ID and  INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and region='" & ds1.Tables("REG").Rows(I).Item("REGION") & "'),0) bin_qty ,NVL((select SUM(qty_to_reserve) from  JAN_FG_QUOTA_VIEW_2014_15_T  where   ORGANIZATION_ID=A.ORGANIZATION_ID and  INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and region='" & ds1.Tables("REG").Rows(I).Item("REGION") & "'),0) fg_qty,NVL((select SUM(ordered_quantity) from JAN_SALES_ANY_TB2_1 where  truNC(ORDER_FF_DT)>=TRUNC(SYSDATE,'MONTH')  AND  TRUNC(ORDER_FF_DT)<LAST_DAY(TRUNC(SYSDATE,'MONTH'))+1  and ORDERED_QUANTITY>0   and    ORGANIZATION_ID=A.ORGANIZATION_ID and  INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and region='" & ds1.Tables("REG").Rows(I).Item("REGION") & "'),0) ordered_quantity"

            For ii = 0 To ds2_wk.Tables("week").Rows.Count - 1

                sql &= " ,NVL((select SUM(ordered_quantity) from JAN_SALES_ANY_TB2_1 where  truNC(ORDER_FF_DT)>=TRUNC(SYSDATE,'MONTH')  AND  TRUNC(ORDER_FF_DT)<LAST_DAY(TRUNC(SYSDATE,'MONTH'))+1  and ORDERED_QUANTITY>0   and    ORGANIZATION_ID=A.ORGANIZATION_ID and  INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and region='" & ds1.Tables("REG").Rows(I).Item("REGION") & "' and  TO_CHAR(ORDER_FF_DT,'IWIYYY')='" & ds2_wk.Tables("week").Rows(ii).Item("wk") & "'),0) wk" & ii + 1 & ""
            Next
            sql &= " ,NVL((select SUM( ordered_quantity )   from JAN_SALES_ANY_TB2_1 where TRUNC(BOOKED_DATE)=TRUNC(JAN_preDATE_CNT(TRUNC(SYSDATE),1))  and   ORGANIZATION_ID=A.ORGANIZATION_ID and INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID and region='" & ds1.Tables("REG").Rows(I).Item("REGION") & "'),0) YESTERDAY_BOOKED_ORD_QTY from mtl_system_items a where organization_id in (select organization_id from org_organization_definitions where operating_unit=103 and organization_id not in (324,364,444,111,104,106,107,108,109,110)))b where (bin_qty+fg_qty+ordered_quantity+YESTERDAY_BOOKED_ORD_QTY)>0 AND  RRS<>'Rn' ORDER BY ""Org"",""Item No"""
            ds = SQL_SELECT("res", sql)
            mail_content("branch_plan_vs_order_" & ds.Tables("res").Rows(0).Item("Region") & "")

            S = ""
            S &= "<html>"
            S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
            S &= "<table width=80% align=center class=tab>"

            S &= "<tr></tr>"
            S &= "<tr><td>Dear All,</td></tr>"

            S &= "<tr><td> Please find attached Plan vs Order receipt as on " & Format(ds1.Tables("reg").Rows(I).Item("todays_date"), "dd-MMM-yyyy") & " </td></tr>"
            S &= "<tr><td><br></td></tr>"

            S &= "<tr><td>Kindly refer the same .</td></tr>"
            S &= "<tr><td><br></td></tr>"

            S &= "<tr><td>Regards,</td></tr>"
            S &= "<tr><td>Marketing Department."
            S &= "</table >"
            S &= "</html>"
            sql = " SELECT * FROM JAN_MAIL_ADDRESS WHERE REGION='" & ds.Tables("res").Rows(0).Item("Region") & "'"
            ds2 = SQL_SELECT("mail_add", sql)
            sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,mail_cc,MAIL_SUBJECT,MAIL_BODY"


            sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Cust Mails','feedback@janatics.co.in','" & ds2.Tables("mail_add").Rows(0).Item("MAIL_ID") & ",sales10@janatics.co.in' ,'it-dev7@janatics.co.in','Plan vs Order Receipt',"
            sql &= "'" & S & "',1)"
            comand()

            Dim file_name As String
            file_name = "D:\MAILER\branch_plan_vs_order_" & ds1.Tables("REG").Rows(I).Item("Region") & ".html"
            'file_name = "D:\branch_plan_vs_order_KOLKATA.html"

            Dim mail_no As Integer

            sql = "select jan_test_seq.currval task_id from dual"
            cmd = New OracleClient.OracleCommand(sql, con)
            If con.State = ConnectionState.Closed Then con.Open()
            DR = cmd.ExecuteReader
            While (DR.Read())
                mail_no = DR.Item("task_id")
            End While
            'If DR.HasRows = True Then mail_no = DR.Item("task_id")

            Dim cmd1 As New OracleClient.OracleCommand
            Dim blob() As Byte = System.IO.File.ReadAllBytes(file_name)

            sql = "UPDATE jan_mail_system SET mail_ATTACH=:BlobParameter,mail_attach_file_name='" & System.IO.Path.GetFileName(file_name) & "' WHERE mail_no=" & mail_no & ""
            Dim blobParameter As OracleClient.OracleParameter = New OracleClient.OracleParameter()
            blobParameter.OracleType = OracleClient.OracleType.Blob
            blobParameter.ParameterName = "BlobParameter"
            blobParameter.Value = blob
            If orcon.State = ConnectionState.Closed Then orcon.Open()
            cmd1 = New OracleClient.OracleCommand(sql, orcon)
            cmd1.Parameters.Add(blobParameter)
            cmd1.ExecuteNonQuery()
            orcon.Close()

            sql = "update jan_mail_system set mail_sent=0 where mail_no=" & mail_no & ""
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = New OracleCommand(sql, con)
            cmd.ExecuteNonQuery()

        Next
        sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00007'"
        comand()


    End Sub
    Private Sub dealer_payment_new()


        sql = "select * from ra_customers where customer_class_code='DEALER' and customer_id=1093"
        ds2 = New DataSet
        ds2 = SQL_SELECT("dealer_name", sql)


        For i = 0 To ds2.Tables(0).Rows.Count - 1
            With ds2.Tables(0).Rows(i)


                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr></tr>"
                S &= "<tr><td>To</td></tr>"

                S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                S &= "<tr><td><br></td></tr>"

                S &= "<tr><td>We thank you very much for your continued support.</td></tr>"
                S &= "<tr><td><br></td></tr>"

                S &= "<tr><td>We would like to bring to your kind attention that the following invoices are pending for payment for the week _____.</td></tr>"
                S &= "<tr><td><br></td></tr>"

                S &= "<tr><td><table table width=80%  class=tab border=1 cellpadding=4 cellspacing=0><tr>"
                S &= "<th width=25% colspan=2 align=center>Upto Last week</th>"
                S &= "<th width=25%  colspan=2 align=center>Current week</th>"
                S &= "<th width=25%  colspan=2 align=center>Next week</th>"
                S &= "<th width=25%  colspan=2 align=center>Total</th>"
                S &= "</tr>"


                S &= "<tr ><th>Pending Order</th><th>Invoice</th><th>Pending Order</th><th>Invoice</th><th>Pending Order</th><th>Invoice</th><th>Pending Order</th><th>Invoice</th></tr>"

                sql = "select b_cust_name,sum(po_upto_last_week)po_upto_last_week,sum(inv_upto_last_week)inv_upto_last_week,sum(po_cur_week)po_cur_week,sum(inv_cur_week)inv_cur_week,sum(po_next_week)po_next_week,sum(inv_next_week)inv_next_week,sum(po_upto_last_week+po_cur_week+po_next_week)total_po,sum(inv_upto_last_week+inv_cur_week+inv_next_week)total_inv from (select a.*,case when to_char(payment_exp_date,'IW')<=to_char(sysdate,'IW')-1 and flag='PENDING ORDER' and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end po_upto_last_week,case when to_char(payment_exp_date,'IW')<=to_char(sysdate,'IW')-1 and flag='OUTSTANDING'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end inv_upto_last_week,case when to_char(payment_exp_date,'IW')=to_char(sysdate,'IW') and flag='PENDING ORDER'  and payment_exp_date<sysdate+30 then (payment_value-rsv2) else 0 end po_cur_week,case when to_char(payment_exp_date,'IW')=to_char(sysdate,'IW') and flag='OUTSTANDING'  and payment_exp_date<sysdate+30 then (payment_value-rsv2) else 0 end inv_cur_week,case when to_char(payment_exp_date,'IW')=to_char(sysdate,'IW')+1 and flag='PENDING ORDER'  and payment_exp_date<sysdate+30 then (payment_value-rsv2) else 0 end po_next_week,case when to_char(payment_exp_date,'IW')=to_number(to_char(sysdate,'IW'))+1 and flag='OUTSTANDING'  and payment_exp_date<sysdate+30 then (payment_value-rsv2) else 0 end inv_next_week from jan_dealer_payment2 a where cust_id=" & .Item("customer_id") & ") where (po_upto_last_week+inv_upto_last_week+po_cur_week+inv_cur_week+po_next_week+inv_next_week)>0 group by b_cust_name"
                ds3 = New DataSet
                ds3 = SQL_SELECT("data", sql)

                With ds3.Tables("data").Rows(0)

                    S &= "<tr ><td align=right>" & Format(.Item("po_upto_last_week"), "0.00") & "</td>"

                    S &= "<td  align=right>" & Format(.Item("inv_upto_last_week"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("po_cur_week"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("inv_cur_week"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("po_next_week"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("inv_next_week"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("total_po"), "0.00") & "</td>"
                    S &= "<td  align=right>" & Format(.Item("total_inv"), "0.00") & "</td></tr>"

                End With
                S &= "</table>"
                S &= "<tr><br></tr>"
                S &= "<tr><td>We kindly request you to organize to send the above payments immediately.</td></tr>"

                S &= "<tr><td><br></td></tr>"
                S &= "<tr><td>Further we would like to inform you that the following payments are pending  for the week no_______. Kindly arrange to pay the before ________(Week date)</td></tr>"

                S &= "<tr><td><br></td></tr>"
                S &= "<tr><td>Further we would like to inform you that the following payments are pending  for the week no_______. Kindly arrange to pay the before ________(Week date)</td></tr>"


                S &= "<tr><td><br></td></tr>"
                S &= "<tr><td>Assuring you of our Best Services always.</td></tr>"

                S &= "<tr><td><br></td></tr>"
                S &= "<tr><td>Thanking you,</td></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td>Marketing Department.</td></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                S &= "</table>"

                S &= "</html>"
            End With
        Next
    End Sub
    Private Sub dealer_payment_status()
        ds2 = New DataSet 'Fund Plan prepared Dealers --jan_dealer_feb_fund_plan
        sql = "select distinct oe_customer_id from oe_dms_order_headers_all where dsp_id=201402 and oe_customer_id =1250"

        'sql = "select distinct customer_id oe_customer_id from jan_sales_any_tb2_1 where nvl(order_type,0)=201402 AND TRUNC(BOOKED_DATE)='6-FEB-2014'"

        sql = "select distinct customer_id oe_customer_id from jan_sales_any_tb2_1 where nvl(order_type,0)=201402 AND CUSTOMER_ID NOT IN (SELECT CUSTOMER_ID FROM jan_dealer_feb_fund_plan)"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds2, "feb_dsp")
        For k = 0 To ds2.Tables("feb_dsp").Rows.Count - 1
            ds = New DataSet
            sql = "select customer_id,customer_name,"
            'nvl(jan_cus_out_standing(A.CUSTOMER_ID),0)out_standing,
            sql &= "(select NVL(SUM(AMOUNT_DUE_REMAINING),0)  FROM jan_region_payment_pending WHERE BILL_TO_CUSTOMER_ID=a.customer_id AND AMOUNT_DUE_REMAINING<>0 and trx_DAte<TRUNC(SYSDATE))out_standing,"
            sql &= " NVL(jan_cus_pp(a.customer_id),0)unapplied,"

            'sql &= "nvl((select sum((sch_qty*unit_selling_price)+(sch_qty*tax_per_unit))ord_val  FROM JAN_CUSTOMER_BUCKET_OA_VS_DR where oa_for<>'JANDSP' and customer_id=" & ds2.Tables("feb_dsp").Rows(k).Item("oe_customer_id") & "),0)ord_pend ,"
            sql &= "nvl((select sum(((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price) +((tax_amount/ordered_quantity)*(ordered_quantity-nvl(shipped_quantity,0))))order_pending_with_tax from jan_sales_Any_tb2_1 K where customer_id=a.customer_id and (ordered_quantity-nvl(shipped_quantity,0))>0 and nvl(order_type,0)<>201402 AND (SELECT cusordno      ||'-'      ||cusorddt    FROM jan_bms_order_pending_new_v    WHERE line_id=K.line_id    )  NOT LIKE 'CCR%' AND SCHEDULE_SHIP_daTE<'1-MAR-2014'),0) ord_pend ,"

            sql &= " nvl((select sum(((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price) +((tax_amount/ordered_quantity)*(ordered_quantity-nvl(shipped_quantity,0))))order_pending_with_tax from jan_sales_Any_tb2_1 where customer_id=a.customer_id and (ordered_quantity-nvl(shipped_quantity,0))>0 and nvl(order_type,0)=201402),0)feb_dsp_val "

            sql &= "from ra_customers a where customer_class_code='DEALER' and customer_id=" & ds2.Tables("feb_dsp").Rows(k).Item("oe_customer_id") & " order by 2"
            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds, "dealer")
            ds1 = New DataSet
            ds1 = ds.Copy
            For i = 0 To ds1.Tables("dealer").Rows.Count - 1

                With ds1.Tables("dealer").Rows(i)
                    Dim total, unapplied As Double
                    total = .Item("out_standing") + .Item("ord_pend") + .Item("feb_dsp_val")
                    unapplied = .Item("unapplied")
                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
                    S &= "<table width=80% align=center class=tab>"
                    S &= "<tr><td><b><u>Fund Plan</b></u></td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><table table width=80% align=center class=tab><tr>"
                    S &= "<th width=30 align=left>Details</th>"
                    S &= "<th width=30>Amount to be Paid Rs.</th>"
                    S &= "<th width=40>Due Date (to be Credited to us)</th></tr>"
                    S &= "<tr><td><b>I.Outstanding</td><b><td>" & Format(.Item("out_standing"), "00.00") & "</td><td>08-feb-2014</td></tr>"
                    S &= "<tr><td colspan=3><hr></td></tr>"

                    S &= "<tr><td colspan=3><b><u>II.Jan Pending orders<b><u></td></tr>"


                    'sql = "select case when order_date<='28-jan-2014' then 'Jan Pending Orders Upto 28-jan-2014' else 'Order Pending between 29-jan-2014 to 31-jan-2014' end order_date,case when order_date<='28-jan-2014' then '8-feb-2014' else '15-feb-2014' end due_date ,sum((sch_qty*unit_selling_price)+(sch_qty*tax_per_unit))ord_val from (SELECT LEAST(trunc(sysdate,'MM')+week_no*7,ADD_MONTHS(trunc(sysdate,'MM'),1)-1)sch_dt,(select trunc(ordered_DAte) from jan_Sales_Any_tb2_1 where line_id=a.oa_line_id )order_date,a.* FROM JAN_CUSTOMER_BUCKET_OA_VS_DR a  where oa_for<>'JANDSP' and customer_id=" & .Item("customer_id") & " order by oa_for) where order_DAte<'1-feb-2014' Group By  case when order_date<='28-jan-2014' then 'Jan Pending Orders Upto 28-jan-2014' else 'Order Pending between 29-jan-2014 to 31-jan-2014' end ,case when order_date<='28-jan-2014' then '8-feb-2014' else '15-feb-2014' end"
                    sql = "select case when order_date<='28-jan-2014' then 'Jan Pending Orders Upto 28-jan-2014' else 'Order Pending between 29-jan-2014 to 31-jan-2014' end order_date,case when order_date<='28-jan-2014' then '8-feb-2014' else '15-feb-2014' end due_date ,sum(order_pending_with_tax)ord_val from (select customer_id,customer_name,trunc(ordered_DAte)order_DAte,sum(((ordered_quantity-nvl(shipped_quantity,0))*unit_selling_price) +((tax_amount/ordered_quantity)*(ordered_quantity-nvl(shipped_quantity,0))))order_pending_with_tax from jan_sales_Any_tb2_1 a where customer_id=" & .Item("customer_id") & " and (ordered_quantity-nvl(shipped_quantity,0))>0 and  ordered_date<'1-feb-2014' and nvl(order_type,0)<>201402 AND SCHEDULE_SHIP_DATE<'01-MAR-2014' group by customer_id, customer_name, trunc(ordered_DAte))  group by case when order_date<='28-jan-2014' then 'Jan Pending Orders Upto 28-jan-2014' else 'Order Pending between 29-jan-2014 to 31-jan-2014' end, case when order_date<='28-jan-2014' then '8-feb-2014' else '15-feb-2014' end "

                    SQL_SELECT("val", sql)

                    Dim row_count As Integer = ds.Tables("val").Rows.Count
                    For j = 0 To ds.Tables("val").Rows.Count - 1
                        With ds.Tables("val").Rows(j)

                            S &= "<tr><td>" & j + 1 & "." & .Item("order_date") & "</td><td>" & Format(.Item("ord_val"), "00.00") & "</td><td>" & .Item("due_date") & "</td></tr>"
                        End With
                    Next

                    S &= "<tr><td colspan=3><hr></td></tr>"

                    S &= "<tr><td colspan=3><b><u>III.Feb DSP orders<b><u></td></tr>"
                    If .Item("feb_dsp_val") > 0 Then

                        If .Item("feb_dsp_val") < 100000 Then
                            S &= "<tr><td>Schedule 1</td><td>" & Format(.Item("feb_dsp_val"), "00.00") & "</td><td>13-feb-2014</td></tr>"
                        ElseIf .Item("feb_dsp_val") > 100000 And .Item("feb_dsp_val") < 150000 Then
                            S &= "<tr><td>Schedule 1</td><td>" & Format(.Item("feb_dsp_val") / 2, "00.00") & "</td><td>13-feb-2014</td></tr>"
                            S &= "<tr><td>Schedule 2</td><td>" & Format(.Item("feb_dsp_val") / 2, "00.00") & "</td><td>20-feb-2014</td></tr>"

                        ElseIf .Item("feb_dsp_val") >= 150000 Then
                            S &= "<tr><td>Schedule 1</td><td>" & Format(.Item("feb_dsp_val") / 3, "00.00") & "</td><td>13-feb-2014</td></tr>"
                            S &= "<tr><td>Schedule 2</td><td>" & Format(.Item("feb_dsp_val") / 3, "00.00") & "</td><td>20-feb-2014</td></tr>"
                            S &= "<tr><td>Schedule 3</td><td>" & Format(.Item("feb_dsp_val") / 3, "00.00") & "</td><td>27-feb-2014</td></tr>"
                            'Else

                            '    For j = 1 To 4
                            '        S &= "<tr><td>Schedule " & j & "</td><td>" & Format(.Item("feb_dsp_val") / 4, "00.00") & "</td><td>"
                            '        If j = 1 Then
                            '            S &= "6-feb-2014"
                            '        ElseIf j = 2 Then
                            '            S &= "13-feb-2014"
                            '        ElseIf j = 3 Then
                            '            S &= "20-feb-2014"
                            '        ElseIf j = 4 Then
                            '            S &= "27-feb-2014"
                            '        End If
                            '        S &= "</td></tr>"
                            '    Next
                        End If

                    End If
                    S &= "<tr><td colspan=3><hr></td></tr>"

                    S &= "<tr><td colspan=3><b><u>IV.Feb Manual orders</b></u></td></tr>"

                    'sql = "select  order_date,order_number ,case when order_date<='28-jan-2014' then '8-feb-2014' else '15-feb-2014' end due_date ,sum((sch_qty*unit_selling_price)+(sch_qty*tax_per_unit))ord_val from (SELECT LEAST(trunc(sysdate,'MM')+week_no*7,ADD_MONTHS(trunc(sysdate,'MM'),1)-1)sch_dt,(select trunc(ordered_DAte) from jan_Sales_Any_tb2_1 where line_id=a.oa_line_id )order_date,(select cusordno||'-'||cusorddt from jan_bms_order_pending_new_v where line_id=a.oa_line_id )order_number,a.* FROM JAN_CUSTOMER_BUCKET_OA_VS_DR a  where oa_for<>'JANDSP' and customer_id=" & .Item("customer_id") & " order by oa_for) where order_DAte>='1-feb-2014' Group By Order_Date, Case When Order_Date<='28-jan-2014' Then '8-feb-2014' Else '15-feb-2014' End,order_number"
                    sql = "select order_number,sum(order_pending_with_tax)ord_val,'15-feb-2014' due_date from (  SELECT customer_id,    customer_name,    (SELECT cusordno      ||'-'      ||cusorddt    FROM jan_bms_order_pending_new_v    WHERE line_id=a.line_id    )order_number,    TRUNC(ordered_DAte)order_DAte,    SUM(((ordered_quantity-NVL(shipped_quantity,0))*unit_selling_price) +((tax_amount/ordered_quantity)*(ordered_quantity-NVL(shipped_quantity,0))))order_pending_with_tax  FROM jan_sales_Any_tb2_1 a  WHERE customer_id                             =" & .Item("customer_id") & "  AND (ordered_quantity-NVL(shipped_quantity,0))>0  AND ordered_date                              >='1-feb-2014'  AND NVL(order_type,0)                        <>201402  AND SCHEDULE_SHIP_DATE                        <'01-MAR-2014'  GROUP BY customer_id, customer_name, TRUNC(ordered_DAte),line_id)WHERE order_number NOT LIKE 'CCR%' group by order_number"

                    SQL_SELECT("val", sql)

                    For j = 0 To ds.Tables("val").Rows.Count - 1
                        With ds.Tables("val").Rows(j)

                            S &= "<tr><td>" & j + 1 & ".  " & .Item("order_number") & "</td><td>" & Format(.Item("ord_val"), "00.00") & "</td><td>" & .Item("due_date") & "</td></tr>"
                        End With
                    Next
                    S &= "<tr><td colspan=3><hr></td></tr>"

                    S &= "</table></td></tr>"


                    S &= "<tr><td>&nbsp;</td></tr>"

                    S &= "<tr><td><b>Total Amount to be Paid :Rs." & Format(total, "00.00") & " </b></td></tr>"
                    S &= "<tr><td>&nbsp;</td></tr>"

                    If unapplied >= 1000 Then S &= "<tr><td><b>UnApplied Amount  :Rs." & Format(unapplied, "00.00") & " </b></td></tr>"

                    S &= "</table>"
                    S &= "</html>"


                    Dim FSTRM As New FileStream("D:\Dealer_fund_plan\" & .Item("customer_NAme") & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()

                End With
            Next

        Next

    End Sub
    Private Sub clp_revision_pending()

        sql = "select a.*,nvl((select count(*) FROM JAN_PRICE_REV_HEADER WHERE APP_BDM_DT IS NULL AND FMLA_ID=4 AND DEL_FLAG IS NULL AND region=a.region),0)un_app_cnt from jan_mail_address a where  bdm_name is not null order by region"
        SQL_SELECT("bdm", sql)
        ds2 = New DataSet
        ds2 = ds.Copy

        For i = 0 To ds2.Tables("bdm").Rows.Count - 1
            With ds2.Tables("bdm").Rows(i)
                If .Item("un_app_cnt") <> 0 Then
                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"

                    S &= "<tr><td>  To- Mr." & .Item("bdm_name") & "</td></tr>"
                    S &= "<tr><td  height=30>Dear Sir,</td></tr>"
                    S &= "<tr><td>This refers to New Price implementation.</td></tr>"
                    S &= "<tr><td> New price approval to be received for the following customers.</td></tr>"

                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><table width=60% class=tab border=1 cellspacing=0 cellpadding=0><tr><th>Sl.no</th><th>Customer Name</th></tr>"

                    sql = "SELECT A.PRICELIST_ID,A.NAME PRICELIST_NAME,(SELECT CUSTOMER_NAME  FROM JAN_BMS_SHIP_TO_V WHERE PRICE_LIST_ID=A.PRICELIST_ID AND REGION=A.REGION AND ROWNUM=1)CUSTOMER,A.REGION FROM JAN_PRICE_REV_HEADER A WHERE A.APP_BDM_DT IS NULL AND A.FMLA_ID=4 AND A.DEL_FLAG IS NULL and region='" & .Item("region") & "' order by CUSTOMER"
                    SQL_SELECT("region", sql)

                    For j = 0 To ds.Tables("region").Rows.Count - 1
                        With ds.Tables("region").Rows(j)
                            If Not IsDBNull(.Item("customer")) Then
                                S &= "<tr><td align=center>" & j + 1 & "</td><td>" & .Item("customer").ToString.Replace("'", "''") & "</td></tr>"
                            End If
                        End With
                    Next


                    S &= "</table></td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td  height=30>Please refer BMS icon ""CLP Price Revision"" for more details.</td></tr>"

                    S &= "<tr><td  height=30>Kindly do the needful to get the price approval on priority.</td></tr>"

                    S &= "<tr><td  height=30>With Regards</td></tr>"


                    S &= "<tr ><td  height=30>Marketing Department.</td></tr>"
                    S &= "<tr><td  height=30>Janatics India Private Limited.</td></tr></table>"

                    S &= "<table width=80% align=center class=tab1><tr><td><b>Disclaimer</b></td></tr><tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr><tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr><tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr></table>"
                    S &= "</html>"



                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try


                        End Try
                    Next



                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,mail_cc,MAIL_SUBJECT,"


                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in','" & .Item("mail_id") & "','sales08@janatics.co.in,senthil-bdm@janatics.co.in' ,'CLP Price Revision Reminder',"
                    'sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in','senthil-bdm@janatics.co.in','sales08@janatics.co.in,it-dev7@janatics.co.in' ,'CLP Price Revision Reminder',"

                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j) & "'"
                        Else
                            sql &= ",'" & longlist(j) & "'"
                        End If
                    Next
                    sql &= ",0)"

                    comand()
                End If
            End With
        Next



    End Sub
    Private Sub Dealer_overdue()

        Dim MAIL_dt As Date
        MAIL_dt = ds.Tables("dt").Rows(0).Item("sys_dt")

        sql = "select  customer_name,customer_id,party_id "

        sql &= ",rowtocol('SELECT distinct email_address FROM AR_PHONES_V WHERE PHONE_TYPE_MEANING like ''E-mail'' and owner_table_name=''HZ_PARTIES'' AND STATUS=''A'' and (OWNER_TABLE_ID='||a.party_id||')') mail_id,(select mail_id from jan_mail_address where region in( select region from JAN_BMS_CUSTOMER_REGION_V where customer_id=a.customer_id))reg_mail_id"
        sql &= " from ra_customers a where customer_class_code='DEALER' and customer_id not in (SELECT customer_id FROM JAN_CUSTOMER_MAIL_EXCEPTION  where mail_sub='Payment Reminder')"
        SQL_SELECT("cust", sql)
        ds2 = New DataSet

        ds2 = ds.Copy

        For i = 0 To ds2.Tables("cust").Rows.Count - 1
            With ds2.Tables("cust").Rows(i)
                sql = "select a.*,NVL(jan_cus_pp(a.customer_id),0)up_applied ,nvl(JAN_CUS_ODUE(a.customer_id),0)over_due,nvl(JAN_CUS_ODUE(a.customer_id),0)-NVL(jan_cus_pp(a.customer_id),0) over_due_after,nvl(jan_cus_out_standing(A.CUSTOMER_ID),0)out_standing,nvl(jan_cus_out_standing(A.CUSTOMER_ID),0)-NVL(jan_cus_pp(a.customer_id),0)out_standing_after from (select customer_id,customer_name,party_id from ra_customers where customer_class_code='DEALER' and customer_id=" & .Item("customer_id") & ")a"
                SQL_SELECT("odue", sql)
                If ds.Tables("odue").Rows(0).Item("over_due_after") > 1000 Then


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

                    S &= "<table width=80% align=center class=tab>"

                    S &= "<tr><td>  To- M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Dear Sir,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We would like to inform you that the following payments are due from you.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td><font color=blue><b>1. Total Outstanding as on   " & Format(MAIL_dt, "dd-MMM-yyyy") & "  &nbsp;&nbsp;&nbsp;  Rs." & ds.Tables("odue").Rows(0).Item("out_standing_after") & ". </b></font></td></tr>"
                    S &= "<tr><td></td></tr>"
                    S &= "<tr><td><font color=red><b>2. Over due as on      &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        " & Format(MAIL_dt, "dd-MMM-yyyy") & "   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Rs." & ds.Tables("odue").Rows(0).Item("over_due_after") & ".</b></font></td></tr>"
                    S &= "<tr><td><br></td></tr>"
                    S &= "<tr><td>Kindly arrange to transfer the above Entire payments by RTGS mode immediately.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td rospan=2>Please note that in future do not wait for any reminder and transfer funds in time to avoid operational hindrance in Despatch.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td  rospan=2>We are sure that you would understand and extend your  co-operation in this regard.</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>In case if you have already paid the payment for the above invoices, kindly let us know the details.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Assuring you of our Best Services always.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td>Janatics India Private Limited.</td></tr></table>"

                    S &= "<table width=80% align=center class=tab1><tr><td><b>Disclaimer</b></td></tr><tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr><tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr><tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr></table>"
                    S &= "</html>"

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try


                        End Try
                    Next



                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO,"

                    If Not IsDBNull(.Item("mail_id")) Then sql &= "  mail_cc,"
                    sql &= " MAIL_SUBJECT, "
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= " MAIL_BODY"
                        Else
                            sql &= " ,MAIL_subject_" & j + 1
                        End If
                    Next
                    sql &= ",mail_sent) values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in',"

                    If Not IsDBNull(.Item("mail_id")) Then sql &= "'" & .Item("mail_id") & "' ,'" & .Item("reg_mail_id") & ",vanitha@janatics.co.in' ," Else sql &= "'" & .Item("reg_mail_id") & ",vanitha@janatics.co.in,accts-ar@janatics.co.in' ,"
                    'sql &= "'vanitha@janatics.co.in' ,'vanitha@janatics.co.in' ,"

                    sql &= " 'Payment Reminder',"
                    For j = 0 To longlist.Count - 1
                        If j = 0 Then
                            sql &= "'" & longlist(j) & "'"
                        Else
                            sql &= ",'" & longlist(j) & "'"
                        End If
                    Next
                    sql &= ",0)"

                    comand()

                End If

            End With
        Next
    End Sub
    Private Sub vendor_mail()



        S = "Dear Vendor,<br/><br/>In projection with the increasing production and the expectation being double for the next financial year, we would like to understand the capacity available at your end for each part supplied by you.<br/><br/>We Kindly request you to please fill the attached format and resend it on or before 13th Dec 2014 (Saturday)<br/><br/>We request every vendor to fill the data as required for each and every part. <br/><br/>Incase of any query in filling the format, feel free to contact us.<br/><br/>Looking forward for your response well before the dead line. <br/><br/>Regards,<br/><br/>B.Ruckmanipriya<br/>Corporate Plan Team <br/><br/>"

        'S = "Date: 23/07/2014<br/><br/>Dear Vendor,<br/><br/>We would like to inform you that as projected we are expected to grow at 30% over the last year.We have observed again that the constraints for further growth is non-delivery of items on time by few vendors.  We request all vendors to understand and take steps in order to adhere to our ""need-by-dates"" without fail.<br/><br/><br/>Meanwhile, we are happy to inform you that a new member has joined in our Supply Chain Management.Mr. Dhiraj Munot, Dy. Manager, SCM, has joined us with rich experience in automobile & MNCs.  His priorities will be in Corporate plan, Bucket Implementation and Governance, Vendor Relationship etc.  He will work predominantly at the back-end while our team Mr. Ramesh kumar and  buyer will focus on front-end (i.e.) the transactional issues and all core technical issues, related to the components.  The purchase orders and related work will be as usual continued by Mrs. Lalitha and Team.<br/><br/>During your next meeting at our office, please make it a point to meet Mr. Dhiraj Munot along with Mr. Ramesh Kumar.<br/><br/>We are very sure that with all our initiatives we can together adhere our desired target.<br/><br/><br/>Regards<br/><br/>R.Ramesh,<br/>Executive Director<br/>"



        ds = New DataSet
        'sql = "SELECT * FROM (SELECT DISTINCT VENDOR_ID,(SELECT c.email_address FROM PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c WHERE b.vendor_id =a.vendor_id  AND b.vendor_site_id =c.vendor_site_id  AND c.email_address IS NOT NULL  AND rownum =1)e_mail FROM jan_scm_cfd_new A WHERE vendor_id  NOT in (select vendor_id from JAN_RM_VENDORS) and payment_currency_code='INR') WHERE e_mail IS NOT NULL"

        '--------po vendors--------------
        sql = "SELECT * FROM  (SELECT DISTINCT vendor_id ,    (SELECT payment_currency_code FROM po_vendors WHERE vendor_id=a.vendor_id    ) payment_currency_code ,    (SELECT c.email_address    FROM PO_VENDOR_SITES_ALL b,      PO_VENDOR_CONTACTS c    WHERE b.vendor_id    =a.vendor_id    AND b.vendor_site_id =c.vendor_site_id    AND c.email_address IS NOT NULL    AND rownum           =1    )e_mail  FROM jan_pur_listing_backup a  WHERE receipt_DAte >'1-apr-2013' and to_organization_id in (104,106,107,108,109)  AND vendor_id NOT IN    (SELECT VENDOR_ID FROM JAN_RM_VENDORS   )and ITEM_no not in (select item_no from jan_misc_items)  )WHERE PAYMENT_CURRENCY_CODE='INR' AND e_mail                IS NOT NULL"

        sql &= " union "
        sql &= " SELECT * FROM  (SELECT DISTINCT vendor_id ,    (SELECT payment_currency_code FROM po_vendors WHERE vendor_id=a.vendor_id    ) payment_currency_code ,    (SELECT c.email_address    FROM PO_VENDOR_SITES_ALL b,      PO_VENDOR_CONTACTS c    WHERE b.vendor_id    =a.vendor_id    AND b.vendor_site_id =c.vendor_site_id    AND c.email_address IS NOT NULL    AND rownum           =1    )e_mail  FROM jan_osp_listing_backup a  WHERE receipt_DAte >'1-apr-2013' and to_organization_id in (104,106,107,108,109)  AND vendor_id NOT IN    (SELECT VENDOR_ID FROM JAN_RM_VENDORS    ) )WHERE PAYMENT_CURRENCY_CODE='INR' AND e_mail                IS NOT NULL"

        'sql = "SELECT * FROM (SELECT DISTINCT VENDOR_ID,(SELECT c.email_address FROM PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c WHERE b.vendor_id =a.vendor_id  AND b.vendor_site_id =c.vendor_site_id  AND c.email_address IS NOT NULL  AND rownum =1)e_mail FROM po_vendors A WHERE vendor_id   in (select distinct vendor_id from jan_scm_bucket_system_vendorS where vendor_id>0)) WHERE e_mail IS NOT NULL"

        'AND vendor_id not in (select vendor_id from jan_scm_bucket_system_vendorS)
        'sql = "SELECT * FROM (SELECT DISTINCT VENDOR_ID,(SELECT c.email_address FROM PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c WHERE b.vendor_id =a.vendor_id  AND b.vendor_site_id =c.vendor_site_id  AND c.email_address IS NOT NULL  AND rownum =1)e_mail FROM jan_scm_bucket_system_vendorS A ) WHERE e_mail IS NOT NULL"

        'sql = "select * from (SELECT A.*,(SELECT DISTINCT  EMAIL_ADDRESS  FROM PO_VENDOR_CONTACTS C WHERE C.VENDOR_SITE_ID IN (select vendor_site_id from po_vendor_sites_all VS where VS.vendor_id=A.VENDOR_ID)  AND EMAIL_ADDRESS IS NOT NULL AND ROWNUM=1)vendor_mailid  FROM JAN_TEMP_4109 A WHERE VENDOR_ID NOT IN (SELECT VENDOR_ID FROM JAN_TEMP_41092)) where vendor_mailid is not null and vendor_mailid in (select mail_to from jan_mail_system where trunc(mail_DAte)='22-mar-2014' and mail_program='Vendor Mails')"

        '****************get vendor name in current plan*********************
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        Dim MAIL_SUBJECT As String = "Vendor Capacity and Capability Assessment"

        For i = 0 To ds.Tables("result").Rows.Count - 1


            With ds.Tables("result").Rows(i)

                ' sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_sent,program_mail_id,mail_body) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Vendor Mails','feedback@janatics.co.in','it-dev7@janatics.co.in,corp-plan@janatics.co.in','" & MAIL_SUBJECT.Replace("'", "''") & "',1,'it-dev7@janatics.co.in','" & S.Replace("'", "''") & " ')"

                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_sent,program_mail_id,mail_body) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Vendor Mails','feedback@janatics.co.in','" & .Item("E_MAIL") & "','" & MAIL_SUBJECT.Replace("'", "''") & "',1,'it-dev7@janatics.co.in','" & S.Replace("'", "''") & " ')"


                If con.State = ConnectionState.Closed Then con.Open()
                cmd = New OracleCommand(sql, con)
                cmd.ExecuteNonQuery()

                Dim file_name As String
                file_name = "D:\Capacity Study Format.xls"

                Dim mail_no As Integer

                sql = "select jan_test_seq.currval task_id from dual"
                cmd = New OracleClient.OracleCommand(sql, con)
                If con.State = ConnectionState.Closed Then con.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then mail_no = dr.Item("task_id")

                Dim cmd1 As New OracleClient.OracleCommand
                Dim blob() As Byte = System.IO.File.ReadAllBytes(file_name)

                sql = "UPDATE jan_mail_system SET mail_ATTACH=:BlobParameter,mail_attach_file_name='" & System.IO.Path.GetFileName(file_name) & "' WHERE mail_no=" & mail_no & ""
                Dim blobParameter As OracleClient.OracleParameter = New OracleClient.OracleParameter()
                blobParameter.OracleType = OracleClient.OracleType.Blob
                blobParameter.ParameterName = "BlobParameter"
                blobParameter.Value = blob
                If orcon.State = ConnectionState.Closed Then orcon.Open()
                cmd1 = New OracleClient.OracleCommand(sql, orcon)
                cmd1.Parameters.Add(blobParameter)
                cmd1.ExecuteNonQuery()
                orcon.Close()

                sql = "update jan_mail_system set mail_sent=0 where mail_no=" & mail_no & ""
                If con.State = ConnectionState.Closed Then con.Open()
                cmd = New OracleCommand(sql, con)
                cmd.ExecuteNonQuery()


            End With
        Next

    End Sub
    Private Sub po_vendor_mail()

        ds = New DataSet
        sql = "select * from (select a.*,(select c.email_address from  PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c where b.vendor_id=a.vendor_id and b.vendor_site_id=c.vendor_site_id  and c.email_address is not null and rownum=1)e_mail from (select distinct vendor_name,vendor_id from jan_corp_plan_04_2012_all_tab )a ) where e_mail is not null"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1

            With ds.Tables("result").Rows(i)
                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>Dear Vendor,</td></tr>"

                S &= "<tr></tr>"

                S &= "<tr><td>Based on the market feedback we have added some additional requirment for April,May,June quarter. This requirement is limited to some items only.</td></tr>"

                S &= "<tr></tr>"

                S &= "<tr><td>As April month is almost over, you may have to treat this as an additional ""May,June requirement"".</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>Kindly note that this will appear as extra line in the SCM portal when you click the ""April,May,June requirment"" menu.</td></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td>Kindly followup with materials department and get clarified should you have any difficulty in understanding the same and collect the necessary PO for the same.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>In future we will be adding such requirement based on market feedback (atleast once in 15days).</td></tr>"
                S &= "<tr></tr>"



                S &= "<tr><td>regards</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>E.S.N.Karthikeyan,</td></tr>"
                S &= "<tr><td>GM - Operations.</td></tr>"

                S &= "</table>"
                S &= "</html>"


                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Vendor Mails','feedback@janatics.co.in','" & .Item("e_mail") & "','Supplementary Requirement in SCM Portal','" & S & "',0)"

                'sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in','it-dev7@janatics.co.in','Important message from Janatics','" & S & "',0)"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd = New OracleCommand(sql, con)
                cmd.ExecuteNonQuery()


            End With
        Next

    End Sub
    Private Sub osp_vendor_mails()

        ds = New DataSet
        sql = "select * from (select a.*,(select c.email_address from  PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c where b.vendor_id=a.vendor_id and b.vendor_site_id=c.vendor_site_id  and c.email_address is not null and rownum=1)e_mail  from jan_sales a ) where e_mail is not null"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1

            With ds.Tables("result").Rows(i)

                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>Dear Esteemed Supplier,</td></tr>"

                S &= "<tr></tr>"

                S &= "<tr><td>&nbsp;&nbsp;As already published in SCM portal, we have started inviting our suppliers and have been discussing with them in person since 6th April’ 2012. Due to lack of time, we have not been able to cover all our suppliers so far and also for another 3 weeks.</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>&nbsp;&nbsp;So, we request you all to kindly look into our purchase orders placed on you, including the old purchase orders. Kindly compare our requirement schedules published in your portal individually for April, May and June with the pending purchase orders. If the requirement is shown in our portal, please deliver them to us as per the schedule as quickly as possible for each month.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>&nbsp;&nbsp;Whenever you feel that the schedules would spill over to next consecutive month, please send us your alternate possible deliverable dates for each item.</td></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td>&nbsp;&nbsp;For any clarifications, please contact our respective buyers namely M/s Mr.K.Manikandadas, Mr. V.K.Sureshkumar and Mr. Nandakumar after sending your queries to them through mail.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td>&nbsp;&nbsp;We would invite you in next month conveniently either in person or through Skype.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td>Thanking you,</td></tr>"
                S &= "<tr><td>Your’s Faithfully,</td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td>E.S.N.Karthikeyan,</td></tr>"
                S &= "<tr><td>GM - Operations.</td></tr>"

                S &= "</table>"
                S &= "</html>"
                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in','" & .Item("e_mail") & "','Apr,May,June Requirement Plan - Regarding','" & S & "',0)"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd = New OracleCommand(sql, con)
                cmd.ExecuteNonQuery()


            End With
        Next

    End Sub

    Private Sub osp_vendor_mail_2()
        ds = New DataSet
        sql = "select * from (select a.*,(select c.email_address from  PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c where b.vendor_id=a.vendor_id and b.vendor_site_id=c.vendor_site_id  and c.email_address is not null and rownum=1)e_mail from (select distinct vendor_name,vendor_id from jan_corp_plan_04_2012_all_tab where plan_for='JOB')a ) where e_mail is not null"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1

            With ds.Tables("result").Rows(i)

                S = ""
                S &= "<html>"
                S &= "<head><style type=text/css>.tab {color:black;font-family:Arial;font-size:9pt}</style><style type=text/css>.tab1 {color:black;font-family:Arial;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab>"

                S &= "<tr><td>Dear Vendor:</td></tr>"

                S &= "<tr></tr>"

                S &= "<tr><td colspan=2><u><b>Sub 1: Auto e-mailer for OSP Vendor(JOB order vendor)</u></b></td></tr>"
                S &= "<tr></tr>"
                S &= "<tr><td  colspan=2><ul><li>As a JOB vendor of our company please note that you are playing major role in ensuring that there is smooth material flow to our organisation.<br /><br /><b><li>We have noticed that in many case the material supplied by us is waiting in queue at your place and there is huge delay in getting the job done in time. This becomes problematic as subsequent processes are also held up.</b><br /><br /> "

                S &= "<b><li>VERY SOON WE WILL SEND AN AUTO EMAIL GIVING YOU THE STATUS OF MATERIAL AND JOB PENDING AT YOUR END. This can be viewed in SCM portal also when introduced.</b> <br /><br />"

                S &= "<li>Please note that <b>APART FROM OUR TODAYS REQUIREMENT</b>, the job order made for our April requirement is to be treated of TOP priority, followed by the May requirement. We will try to give you schedule soon in portal till June2012 for already PO made . <br /><br />"

                S &= "<li>Try to complete the job within a week to 10days time from the date of job order. <br /><br />"

                S &= "<li>We also request you to treat such job which is more than 10days as very urgent and attend to it on priority by allocating the necessary resources and supply quickly without any follow up. <br /><br />"

                S &= "<li>Please note that we will introduce lock system in material despatch area for an item which will prevent further releases to the vendor who has not cleared any order for that item for more than 15days. </ul>"


                S &= "</td></tr>"


                S &= "<tr><td  colspan=2>Please note that all your measurement will be made from date of job order and ratings will be affected for delayed despatches.<b> For unacceptable delays we reserve the right to cancel the order and divert the material to alternate vendors.</b> </td></tr>"

                S &= "<tr></tr>"
                S &= "<tr><td  colspan=2><b><u>Sub 2:April, May and June requirement(job order vendors) </u></b></td></tr>"

                S &= "<tr></tr>"
                S &= "<tr></tr>"


                S &= "<tr><td  colspan=2> Please note that these indications which we have published are tentative. They are published based on past data. These are not guaranteed orders but indications only.<b>We would have placed job orders to alternate vendors </b>according to past performance and other available data with us. Please check up with our materials department for details.</td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td  colspan=2><b><u>Sub 3:Capacity </u></b></td></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td  colspan=2>As we do not have any data related to capacity of individual vendors we will be happy to capture the data soon. We will send soon a format wherein you can fill up and send. This will help us to send you RFQ’s(request for quote) for any new items. </td></tr>"

                S &= "<tr></tr>"

                S &= "<tr><td  colspan=2>Regards </td></tr>"

                S &= "<tr><td>E S N Karthikeyan </td><td> R.Ramesh  </td></tr>"

                S &= "<tr></tr>"
                S &= "<tr></tr>"

                S &= "<tr><td  colspan=2><b>This is a computer generated email. Please do not Reply.</b> </td></tr>"
                S &= "</table>"
                S &= "</html>"
                sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in','" & .Item("e_mail") & "','Important message from Janatics','" & S & "',0)"

                'sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in','it-dev7@janatics.co.in','Important message from Janatics','" & S & "',0)"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd = New OracleCommand(sql, con)
                cmd.ExecuteNonQuery()


            End With
        Next

    End Sub
    Private Sub payment_receipt_blocked_cust()

        Dim inv_null_flag As String
        Dim receipt_dt As Date
        receipt_dt = DateTimePicker1.Value


        ds = New DataSet

        sql = "SELECT DISTINCT pay_from_customer customer_id,customer_name,REGION,customer_class_code FROM ("

        sql &= " SELECT a.*,(SELECT ter.segment14 FROM ra_site_uses_all sit,ra_territories ter WHERE sit.territory_id=ter.territory_id AND sit.site_use_id=a.customer_site_use_id)region ,"

        sql &= " (select customer_name from ra_customers where customer_id=a.pay_from_customer)customer_name,"

        sql &= " (SELECT customer_class_code FROM ra_customers WHERE customer_id=a.pay_from_customer)customer_class_code "

        sql &= " FROM AR_CASH_RECEIPTS_ALL A WHERE  trunc(creation_date)='" & Format(receipt_dt, "dd-MMM-yyyy") & "' AND pay_from_customer IS NOT NULL AND pay_from_customer IN (SELECT customer_id FROM jan_customer_mail_exception WHERE mail_id=3)) "



        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                If .Item("customer_class_code") <> "DEALER" Then


                    inv_null_flag = "N"

                    sql = "SELECT RECEIPT_NUMBER,A.CUSTOMER_RECEIPT_REFERENCE ch_no,A.POSTMARK_DATE CH_dt,A.COMMENTS BANK_NAME,A.AMOUNT ,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.PAY_FROM_CUSTOMER)CUST_NAME,A.PAY_FROM_CUSTOMER CUST_ID,(SELECT NAME  FROM ar_receipt_methods WHERE RECEIPT_METHOD_ID=A.RECEIPT_METHOD_ID)METHOD,rowtocol('SELECT c.trx_number||''  /  ''||c.trx_date||''  /  ''||d.bill_to_site  FROM ar_receivable_applications_all b,ra_customer_trx_all c,jan_invoice_listing d WHERE b.applied_customer_trx_id=c.customer_trx_id  and  c.customer_trx_id=d.customer_trx_id AND b.status=''APP'' AND b.cash_receipt_id='||a.cash_receipt_id||'')inv   FROM ar_cash_receipts_all A WHERE trunc(creation_date)='" & Format(receipt_dt, "dd-MMM-yyyy") & "' and pay_from_customer=" & .Item("customer_id") & ""
                    adap = New OracleDataAdapter(sql, con)
                    ds1 = New DataSet
                    adap.Fill(ds1, "pay")


                    S = ""
                    S &= "<html>"
                    S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
                    S &= "<table width=80% align=center class=tab>"
                    S &= "<tr><td>To</td></tr>"

                    S &= "<tr><td>  M/s. " & .Item("customer_name") & "</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>Dear Customer,</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr><td>We thank you very much for your continued support.</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>We hereby acknowledge the payment received from you as given below:</td></tr>"
                    S &= "<tr></tr>"

                    S &= "<tr></tr>"
                    S &= "<tr><td><table width=80% align=left class=tab  border=1 cellpadding=0 cellspacing=0>"
                    S &= "<tr><th>Sl.no</th><th>Payment Details **</th><th>Amount in Rs</th><th>Bank Details</th><th>Payment made against<br>our invoice nos</th></tr>"

                    For j = 0 To ds1.Tables("pay").Rows.Count - 1
                        S &= "<tr><td align=center>" & j + 1 & "</td>"

                        S &= "<td><table  class=tab><tr><td>Mode of payment  </td><td>:" & ds1.Tables("pay").Rows(j).Item("method") & "</td></tr><tr><td>Cheque No        </td><td>:" & ds1.Tables("pay").Rows(j).Item("ch_no") & "</td></tr><tr><td>Cheque Date     </td><td>:" & ds1.Tables("pay").Rows(j).Item("ch_dt") & "</td></tr></table></td>"

                        S &= "<td align=right>" & Format(ds1.Tables("pay").Rows(j).Item("amount"), "00.00") & "</td><td  align=center>" & ds1.Tables("pay").Rows(j).Item("bank_name") & "</td>"


                        If IsDBNull(ds1.Tables("pay").Rows(j).Item("inv")) Then

                            S &= "<td  align=left>Please send us the Invoice details immediately which will help us to account accordingly.</td></tr>"
                            inv_null_flag = "Y"
                        Else
                            S &= "<td  align=left>" & ds1.Tables("pay").Rows(j).Item("inv").ToString.Replace(",", "<br>") & "</td></tr>"
                        End If

                    Next

                    S &= "</table></td></tr>"

                    S &= "<tr></tr>"

                    If inv_null_flag = "Y" Then

                        S &= "<tr><td>Please be informed that your payment outstanding details and the accounts statements are available in our exclusive customer portal website <b><a href=""http://www.janaticscrm.net"">www.janaticscrm.net</a></b>. </td></tr>"
                        S &= "<tr></tr>"

                    End If

                    S &= "<tr></tr>"

                    S &= "<tr><td>Assuring you of our Best Services always .</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>Thanking you,</td></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr></tr>"
                    S &= "<tr><td>With Regards,</td></tr>"
                    S &= "<tr><td>Marketing Department.</td></tr>"
                    S &= "<tr><td><b>Janatics India Private Limited.</td></tr>"
                    S &= "<tr></tr>"


                    S &= "<tr><td><b>Note:</b></td></tr>"
                    S &= "<tr><td> 1.** Payments are subject to realization.</td></tr>"
                    S &= "<tr><td> 2.If you have not received the User ID and Password for our Exclusive Customer Portal, Please contact us  or our Branch.</td></tr>"
                    S &= "<tr><td>3.This is computer generated email.Please do not reply to this mail-id.For any queries/assistance,please contact us or our branch.</td></tr>"
                    S &= " <tr></tr>"


                    S &= "<tr><td><hr></td></tr>"
                    S &= "<tr></tr>"

                    ds1 = New DataSet
                    sql = "SELECT FIN_YR,QTR_ID,SUM(INV_VALUE+TAX_VALUE)INV_VALUE FROM JAN_CFORM WHERE CFORM_NO IS NULL AND CUSTOMER_ID=" & .Item("customer_id") & " GROUP BY FIN_YR,QTR_ID "
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "PAY")
                    If ds1.Tables("pay").Rows.Count > 0 Then
                        S &= "<tr><td>We also would like to bring to your kind attention that the C-forms are pending at your end for the following periods:</td></tr>"
                        S &= "<tr></tr>"
                        S &= "<tr><td><table  class=tab  border=1 cellpading=0 cellspacing=0 width=60%><tr><th>Sl.no</th><th>Year</th><th>Quarter</th><th>Invoice Value in Rs</th></tr>"
                        For j = 0 To ds1.Tables("PAY").Rows.Count - 1
                            With ds1.Tables("PAY").Rows(j)
                                S &= "<tr><td ALIGN=CENTER>" & j + 1 & "</td><td>" & .Item("Fin_yr") & "</td><td ALIGN=CENTER>" & .Item("Qtr_id") & "</td><td ALIGN=RIGHT>" & .Item("INV_value") & "</td></tr>"
                            End With
                        Next
                        S &= "</table></td></tr>"



                        S &= "<tr></tr>"
                        S &= "<tr><td>We request you to organize to send C-forms for the above given period immediately.</td></tr>"
                        S &= "<tr></tr>"

                        S &= "<tr><td>In case C-forms for the above period is already sent to us, kindly let us know the details for us to clarify.</td></tr><tr></tr>"

                        S &= "<tr></tr>"
                        S &= "</table>"
                    End If



                    S &= "<table width=80% align=center class=tab1>"
                    S &= "<tr><td><b>Disclaimer</b></td></tr>"
                    S &= "<tr><td>1.This is computer generated e-mail and hence authorised signature is not required.   </td></tr>"
                    S &= "<tr><td>2.The data furnished is purely for information purpose only.The accuracy, reliability or the completion of furnished data is subject to validation. Also there can be errors in data, due to software bug.</td></tr>"

                    S &= "<tr><td>3.Hence the status has to be verified with Janatics India Private Limited received in writing and signed by authorised persons.</td></tr>"

                    S &= "</table>"
                    S &= "</html>"




                    ds2 = New DataSet
                    'sql = "SELECT * FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'"
                    sql = "SELECT DECODE('" & .Item("REGION") & "','DELHI 3',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),'DELHI 2',rowtocol('select MAIL_ID from JAN_MAIL_ADDRESS  WHERE REGION in (''DELHI 1'',''DELHI 2'',''DELHI 3'')'),(SELECT MAIL_ID FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'))mail_id  FROM JAN_MAIL_ADDRESS  WHERE REGION='" & .Item("REGION") & "'"

                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds2, "res")

                    Dim longlist As New List(Of String)
                    For j = 0 To Math.Floor(Convert.ToInt32(S.Length / 3950))
                        Try
                            longlist.Add(S.Substring(j * 3950, 3950))
                        Catch ex As Exception
                            Try
                                longlist.Add(S.Substring(j * 3950))
                            Catch ex1 As Exception

                            End Try

                        End Try
                    Next


                    '********************
                    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_cc"
                    If ds2.Tables("res").Rows.Count > 0 Then sql += ",mail_to"


                    sql &= ", MAIL_SUBJECT, MAIL_SENT, "
                    For j = 0 To longlist.Count - 1
                        If (j = 0) Then sql &= " MAIL_BODY" Else sql &= " ,MAIL_subject_" & j + 1

                    Next
                    sql &= ") values ( jan_test_seq.nextval,sysdate,'Customer Mails','feedback@janatics.co.in','feedback@janatics.co.in'"


                    If ds2.Tables("res").Rows.Count > 0 Then sql &= ",'" & ds2.Tables("res").Rows(0).Item("mail_id") & "'"


                    sql &= ",'Payment Receipt',0,"

                    For j = 0 To longlist.Count - 1
                        If (j = 0) Then sql &= "'" & longlist(j).Replace("'", "''") & "'" Else sql &= ",'" & longlist(j).Replace("'", "''") & "'"
                    Next

                    sql &= ")"


                    cmd = New OracleCommand(sql, con)
                    comand()

dont_insert:


                    Dim FSTRM As New FileStream("D:\payment receipt\payment_receipt" & i & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()
                End If
            End With

        Next
    End Sub
    Private Sub cform_mail_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cform_mail_send.Click
        pay_cform()
    End Sub
End Class