Imports System.Data.OracleClient
Imports System.IO
Public Class mailer_new
    Dim average, stock, sl_no, num As Double
    Dim days, stock_days As Double
    'Dim dr, dr1 As Odbc.OdbcDataReader
    Dim description, tail, file_name,week1,week2,week3 As String
    Dim first_date, last_date, today_date, attendance_dt, booked_dt As Date
    Dim file_no, item_id, line, mailing_count, interval, dept_no, rec_cnt, l, m, form_per_cnt, week_no, new_customer_count, multiple_org_booked, ar_inv_diff_cnt As Integer
    Dim mailer As New System.Net.Mail.MailMessage
    Dim dept As New DataSet
    Dim align As String

    Private Sub mailer_new_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "insert into JAN_ORA_SCHEDULE_LOG_T( s_code,concurrent_name,start_time) values('C00011','Daily Mail  Internal',sysdate) "
        comand()



        If Not Directory.Exists("D:\MAILER") Then
            Directory.CreateDirectory("D:\MAILER")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\MAILER")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If


        Timer1.Enabled = True
        Timer1.Start()
        mailing_count = 0
        ds = New DataSet
        sql = "select trunc(sysdate-180)frm_date,TRUNC(SYSDATE)today,to_char(sysdate,'DY')day,TRUNC(SYSDATE-1)yesterday ,TRUNC(SYSDATE-2)pyesterday  from dual"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        first_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, ds.Tables("result").Rows(0).Item("frm_date")), Date.MinValue)
        last_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)
        today_date = ds.Tables("result").Rows(0).Item("today")
        If ds.Tables("result").Rows(0).Item("day") = "MON" Then
            attendance_dt = ds.Tables("result").Rows(0).Item("pyesterday")
        Else
            attendance_dt = ds.Tables("result").Rows(0).Item("yesterday")
        End If
    End Sub
    Private Sub planing_excep()
        ds = New DataSet
        sql = "SELECT JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_NO,DESCRIPTION,EXCEPTION_QTY,ITEM_TYPE,MAKE_BUY,NVL((select SUM(QUANTITY-RSV) from JAN_CONSOLIDATED_REQ_V2 where ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0) PLAN_PEND,NVL((select SUM(REQUIREMENT-CANCELLED_QTY-RECEIVED_QUANTITY) from JAN_SO_REQUIREMENT_MASTER_NEW where ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND TRUNC(SOR_DT)<=TRUNC(SYSDATE)),0) M2O_PEND from JAN_COMPONENT_EXCEPTION_TAB A where trunc(exception_date)=trunc(sysdate) AND EXCEPTION_QTY>0  order by org,item_no"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style></head>"

        S &= "<table width=80% class=tab align=center cellspacing=0 cellpadding=0 border=1>"
        S &= "<tr> <th align=center>Sl.No</th><th >Org</th><th >Item No</th><th >Description</th><th >Exception Qty</th><th>Item Type</th><th >Make/Buy</th></tr>"

        With ds.Tables("result")
            For k = 0 To .Rows.Count - 1
                S &= "<tr> <td align=center>" & k + 1 & "</td><td >" & .Rows(k).Item("org") & "</td><td  align=left>" & .Rows(k).Item("item_no") & "</td><td align=left>" & .Rows(k).Item("description") & "</td><td align=right>" & .Rows(k).Item("EXCEPTION_QTY") & "</td><td>" & .Rows(k).Item("ITEM_TYPE") & "</td><td >" & .Rows(k).Item("MAKE_BUY") & "</td></tr>"
            Next

        End With


        S &= "</table>"
        S &= "</html>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "Today's Exception.html"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

        'consolidated Pending
        ds = New DataSet
        sql = "SELECT TO_CHAR(exception_date,'MON')MONTH,JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_NO,DESCRIPTION,EXCEPTION_QTY,ITEM_TYPE,MAKE_BUY,NVL((select SUM(QUANTITY-RSV) from JAN_CONSOLIDATED_REQ_V2 where ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0) PLAN_PEND,NVL((select SUM(REQUIREMENT-CANCELLED_QTY-RECEIVED_QUANTITY) from JAN_SO_REQUIREMENT_MASTER_NEW where ORGANIZATION_ID=a.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID AND TRUNC(SOR_DT)<=TRUNC(SYSDATE)),0) M2O_PEND from JAN_COMPONENT_EXCEPTION_TAB A where TO_CHAR(exception_date,'MM')=TO_CHAR(sysdate,'MM') AND EXCEPTION_QTY>0  order by org,item_no"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style></head>"

        S &= "<table width=80% class=tab align=center cellspacing=0 cellpadding=0 border=1>"
        S &= "<tr> <th align=center>Sl.No</th><th >Org</th><th >Item No</th><th >Description</th><th >Exception Qty</th><th>Item Type</th><th >Make/Buy</th></tr>"

        With ds.Tables("result")
            For k = 0 To .Rows.Count - 1
                S &= "<tr> <td align=center>" & k + 1 & "</td><td >" & .Rows(k).Item("org") & "</td><td  align=left>" & .Rows(k).Item("item_no") & "</td><td align=left>" & .Rows(k).Item("description") & "</td><td align=right>" & .Rows(k).Item("EXCEPTION_QTY") & "</td><td>" & .Rows(k).Item("ITEM_TYPE") & "</td><td >" & .Rows(k).Item("MAKE_BUY") & "</td></tr>"
            Next

        End With


        S &= "</table>"
        S &= "</html>"
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "Consolidated Exception.html"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        FSTRM = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        SW = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

    End Sub
    Private Sub preventive_plan_exception()

        ds = New DataSet
        sql = "SELECT JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_NO,DESCRIPTION,ITEM_TYPE,MAKE_BUY,PREVENTIVE_PLAN_EXCEPTION ,FAST_SLOW_FLAG,STD_NSTD_FLAG  FROM JAN_COMPONENT_EXCEPTION   WHERE PREVENTIVE_PLAN_EXCEPTION>0  AND PLAN_QTY+PREVENTIVE_PLAN_QTY>0"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "res")

        mail_content("prev_plan_excep")
    End Sub
    Private Sub send_mail()
        Dim SmtpMail As New Net.Mail.SmtpClient
        tail = "@janatics.co.in"
        mailer = New System.Net.Mail.MailMessage
        Select Case ds5.Tables("result").Rows(i).Item("schedule_id")
            Case 1
                stock_out_alert()
                Dim Str() As String
                Str = Directory.GetFiles("D:\stock out alert")
                Dim cnt As Integer = Str.Length
                Dim attach_file As String
                For Each attach_file In Str
                    mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
                Next
            Case 1.1
                dealer_payment_receipt()
                mailer.Attachments.Add(New System.Net.Mail.Attachment("d:\MAILER\Dealer Payment Receipt.html"))

            Case 2
                job_store_pending()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 3
                Rtv_pending()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 7
                attendance_mail()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 8
                M2O_Vs_Weekly_Plan_Alert()
                Dim Str() As String
                Str = Directory.GetFiles("C:\M2o alert")
                Dim cnt As Integer = Str.Length
                Dim attach_file As String
                For Each attach_file In Str
                    mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
                Next
            Case 9
                Stock_Excess_Alert()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 10
                tobe_released()
                Dim Str() As String
                Str = Directory.GetFiles("C:\Tobe Released")
                Dim cnt As Integer = Str.Length
                Dim attach_file As String
                For Each attach_file In Str
                    mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
                Next
            Case 11
                DR_Pending_Products()
                Dim Str() As String
                Str = Directory.GetFiles("C:\DR Pending")
                Dim cnt As Integer = Str.Length
                Dim attach_file As String
                For Each attach_file In Str
                    mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
                Next

            Case 12
                booked_order()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 13
                booked_orders_without_sch_dt()
                If rec_cnt = 0 Then GoTo last
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 14
                component_rm_stock_alert()
                Dim Str() As String
                Str = Directory.GetFiles("C:\component stock out alert")
                Dim cnt As Integer = Str.Length
                Dim attach_file As String
                For Each attach_file In Str
                    mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
                Next
            Case 15
                long_running_query()
                mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 16
                po_form_personalization_changes()
                If form_per_cnt = 0 Then GoTo last
                'mailer.Body = S
                'mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
            Case 17
                planing_excep()
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Today's Exception.html"))
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Consolidated Exception.html"))

            Case 18
                Regression_plan_Exception()
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Org Exception.html"))
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Todays Org Exception.html"))
                'mailer.Attachments.Add(New System.Net.Mail.Attachment("Region Exception.html"))
                'mailer.Attachments.Add(New System.Net.Mail.Attachment("Todays Region Exception.html"))
            Case 19
                preventive_plan_exception()
                mailer.Attachments.Add(New System.Net.Mail.Attachment("prev_plan_excep.xls"))
            Case 20
                Excess_po_released()
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Excess_po_released.html"))
                mailer.Attachments.Add(New System.Net.Mail.Attachment("Excess_job_released.html"))
        End Select


        mailer.From = New System.Net.Mail.MailAddress(ds5.Tables("result").Rows(i).Item("from_address") & tail & "")
        to_address_bind()
        cc_address_bind()

        'mailer.To.Add("it-dev7@janatics.co.in")
        If ds5.Tables("result").Rows(i).Item("schedule_id") = 7 Then
            mailer.Subject = ds5.Tables("result").Rows(i).Item("mail_subject") & "  of  " & dept.Tables("dept_name").Rows(dept_no).Item("dept")

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 12 Then
            mailer.Subject = "Orders Booked on " & Format(booked_dt, "dd-MMM-yyyy") & " with formula<=1.30"
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 20 Then
            mailer.Subject = "Excess PO Released on :" & Format(Date.Today, "dd-MMM-yyyy") & " "
        Else
            mailer.Subject = ds5.Tables("result").Rows(i).Item("mail_subject")
        End If

        mailer.Priority = Net.Mail.MailPriority.Normal
        If ds5.Tables("result").Rows(i).Item("schedule_id") = 8 Then
            mail_body()
            mailer.Body = S & vbNewLine & "This is a computer generated email. Please do not Reply."
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 10 Then
            tobe_release_body()
            mailer.Body = S & vbNewLine & "This is a computer generated email. Please do not Reply."
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 15 Then
            long_operation_mail_body()
            mailer.Body = S & vbNewLine & "This is a computer generated email. Please do not Reply." & vbNewLine & " For Reference refer the Program F:\public\ORACLE Long Operation.bat"
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 16 Then
            mailer.Body = S & vbNewLine & "This is a computer generated email. Please do not Reply."
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 20 Then
            excess_po_released_body()
            mailer.Body = S
            'ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 21 Then
            '    order_payment()
            '    mailer.Attachments.Add(New System.Net.Mail.Attachment("Payment Data Consolidation.html"))
            '    mailer.Attachments.Add(New System.Net.Mail.Attachment("Order and Payment Breakup.html"))
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 32 Then
            edi_mail()
            mailer.Attachments.Add(New System.Net.Mail.Attachment("d:\MAILER\EDI.html"))
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 22 Then
            invoice_to_apply()
            mailer.Attachments.Add(New System.Net.Mail.Attachment("d:\MAILER\Dealer Payment Consolidation.html"))
            'mailer.Attachments.Add(New System.Net.Mail.Attachment("C:\Invoice Amount to Apply Consolidation.html"))
            'mailer.Attachments.Add(New System.Net.Mail.Attachment("C:\Invoice Amount to Apply breakup.html"))
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 33 Then
            Ar_invoice_diff()
            mailer.Body = S
            'mailer.Attachments.Add(New System.Net.Mail.Attachment("d:\MAILER\AR_Inv_Diff.html"))
            If ar_inv_diff_cnt = 0 Then GoTo last

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 23 Then

            dealer_payment_status()
            mailer.Attachments.Add(New System.Net.Mail.Attachment("D:\MAILER\Dealer Payment Status.html"))

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 24 Then
            component_shortage()
            mailer.Attachments.Add(New System.Net.Mail.Attachment("D:\Pending Orders Component Shortage.html"))
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 25 Then
            current_year_sale_qty()
            mailer.Body = S
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 26 Then
            New_customer_addition()
            mailer.Body = S
            If new_customer_count = 0 Then GoTo last

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 30 Then
            price_list_addition()
            mailer.Body = S
            If new_customer_count = 0 Then GoTo last

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 31 Then
            new_part_no_Addition()
            mailer.Body = S
            If new_customer_count = 0 Then GoTo last

        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 27 Then
            order_booked_in_multi_org()
            mailer.Body = S
            If multiple_org_booked = 0 Then GoTo last
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 1.2 Then
            yesterday_production_val()
            mailer.Body = S
        ElseIf ds5.Tables("result").Rows(i).Item("schedule_id") = 29 Then
            Order_detail()

            mailer.Attachments.Add(New System.Net.Mail.Attachment("D:\MAILER\Order Pending and Payment.html"))
            GoTo last


        Else
            If ds5.Tables("result").Rows(i).Item("schedule_id") = 12 Then
                mailer.Body = "The item cost shown is average cost rolled up after production.  The cost may be zero, if it is produced for the first time.. " & vbNewLine & " This is a computer generated email. Please do not Reply."
            Else
                mailer.Body = "This is a computer generated email. Please do not Reply."
            End If
        End If
        mailer.IsBodyHtml = True
        SmtpMail = New Net.Mail.SmtpClient
        'SmtpMail.Host = "192.168.0.57"
        SmtpMail.Host = "intmail.janaticsindia.com"

        SmtpMail.Send(mailer)


        sql = "insert into jan_mailer_table(report_name,run_date,schedule_id) values('" & ds5.Tables("result").Rows(i).Item("mail_subject") & "',sysdate," & ds5.Tables("result").Rows(i).Item("schedule_id") & ")"
        comand()
last:
    End Sub
    Private Sub edi_mail()

        sql = "declare begin jan_edi_proc; end;"
        comand()

        sql = "select jan_orgcode( DECODE(ORG_ID,106,464,107,444,108,504,109,484,110,505,104,524,ORG_ID))org,a.* from JAN_MFG_STATUS_COLOR_BASE_T a  order by org,item_no"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("EDI")

    End Sub
    Private Sub dealer_payment_receipt()

        sql = "select (select customer_name from ra_customers where customer_id=a.pay_from_customer)dealer_name,rowtocol('select distinct ter_name from jan_bms_bill_to_v where ter_name not in (''DELHI 2'',''DELHI 3'') and  customer_id='||a.pay_from_customer||'' )region,creation_date,receipt_date,amount from  ar_cash_receipts_all a  where  trunc(creation_date)>=trunc(sysdate)-3 and pay_from_customer in (select customer_id from ra_customers where customer_class_code='DEALER') order by 3,1,2"

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Dealer Payment Receipt")


    End Sub
    Private Sub yesterday_production_val()
        sql = "SELECT UPDATION_DATE,JAN_ORGCODE(ORG)ORG,NVL(ROUND(SUM(PRODUCTION),2),0)PRODUCTION_VALUE FROM JAN_DSALES_TB3 WHERE TRUNC(UPDATION_DATE)=(SELECT TRUNC(JAN_PREDATE_CNT(TRUNC(SYSDATE),1)) FROM DUAL) GROUP BY UPDATION_DATE, JAN_ORGCODE(ORG) union SELECT to_date(null),'Total'ORG,NVL(ROUND(SUM(PRODUCTION),2),0)PRODUCTION_VALUE FROM JAN_DSALES_TB3 WHERE TRUNC(UPDATION_DATE)=(SELECT TRUNC(JAN_PREDATE_CNT(TRUNC(SYSDATE),1)) FROM DUAL) GROUP BY TO_DATE(NULL), 'Total'"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        'multiple_org_booked = ds.Tables("RES").Rows.Count

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=60% align=center class=tab>"

        'S &= "<tr><td>Dear Sir,</td></tr>"
        'S &= "<tr><td><br> </td></tr>"

        S &= "<tr><td>Last Working Day's Production value  ,</td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Sl.No</th><th>Org</th><th>Production Date</th><th>Production value</th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center>"
                If k <> ds.Tables("res").Rows.Count - 1 Then S &= " " & k + 1 & "" Else S &= "&nbsp;"
                S &= "</td><td align=center>"

                If Not IsDBNull(.Item("org")) Then S &= "" & .Item("org") & "" Else S &= "&nbsp;"
                S &= "</td><td align=center>"
                If Not IsDBNull(.Item("UPDATION_DATE")) Then S &= "" & Format(.Item("UPDATION_DATE"), "dd-MMM-yyyy") & "" Else S &= "&nbsp;"
                S &= "</td><td align=right>"
                If Not IsDBNull(.Item("PRODUCTION_VALUE")) Then S &= "" & Format(.Item("PRODUCTION_VALUE"), "00.00") & "" Else S &= "&nbsp;"
                S &= "</td>"
                S &= "</tr>"
            End With
        Next

        S &= "</table></td></tr>"
        S &= "<tr><td><br> </td></tr>"
    End Sub
    Private Sub order_booked_in_multi_org()

        sql = "select distinct  JAN_ORGCODE(SHIP_FROM_ORG_ID)ORG,JAN_ITEMNAME(INVENTORY_ITEM_ID)ITEM_NO from JAN_SALES_PLAN_TV_T where INVENTORY_ITEM_ID in (SELECT INVENTORY_ITEM_ID FROM (select   INVENTORY_ITEM_ID,COUNT(*)CNT from (select SHIP_FROM_ORG_ID,INVENTORY_ITEM_ID,COUNT(*)CNT  from JAN_SALES_PLAN_TV_T where SHIP_FROM_ORG_ID in (444,464,484,504,505) group by SHIP_FROM_ORG_ID, INVENTORY_ITEM_ID )group by  INVENTORY_ITEM_ID) WHERE CNT>1) group by JAN_ORGCODE(SHIP_FROM_ORG_ID), JAN_ITEMNAME(INVENTORY_ITEM_ID) ORDER BY ITEM_NO"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        multiple_org_booked = ds.Tables("RES").Rows.Count

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=60% align=center class=tab>"

        'S &= "<tr><td>Dear Sir,</td></tr>"
        'S &= "<tr><td><br> </td></tr>"

        S &= "<tr><td>The following Items are booked in multiple Organization. </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Sl.No</th><th>Org</th><th>Item No</th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center>" & k + 1 & "</td><td align=center>"

                If Not IsDBNull(.Item("org")) Then S &= "" & .Item("org") & "" Else S &= "&nbsp;"
                S &= "</td><td align=center>"
                If Not IsDBNull(.Item("item_no")) Then S &= "" & .Item("item_no") & "" Else S &= "&nbsp;"
                S &= "</td>"
                S &= "</tr>"
            End With
        Next

        S &= "</table></td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>For your kind information Please .</td></tr>"
        S &= "<tr><td><br> </td></tr>"

    End Sub
    Private Sub New_customer_addition()
        Dim new_customer_date As Date

        sql = "select  TRUNC(JAN_preDATE_CNT(TRUNC(SYSDATE),1)) last_working_day from dual"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "dt")
        new_customer_date = ds.Tables("dt").Rows(0).Item("last_working_day")

        sql = "select RAC.CUSTOMER_NAME,C.SEGMENT14 REGION,RAC.ATTRIBUTE15 IND_SEGMENT,RAC.ATTRIBUTE12 VOP_EXPECTED,(SELECT NAME FROM QP_LIST_HEADERS_ALL WHERE LIST_HEADER_ID=B.PRICE_LIST_ID)PRICE_LIST,RAC.ATTRIBUTE14 DISCOUNT,TRUNC(rac.creation_date)creation_date,(SELECT STANDARD_TERMS_NAME  FROM AR_CUSTOMER_PROFILES_V WHERE CUSTOMER_ID=rac.CUSTOMER_ID  AND SITE_USE_ID IS NULL)pay_term FROM ra_addresses_all a,ra_site_uses_all b,ra_territories c,ra_customers rac WHERE  TRUNC(RAC.CREATION_DATE)='" & Format(new_customer_date, "dd-MMM-yyyy") & "' and a.address_id= b.address_id and b.site_use_code='BILL_TO' and B.PRIMARY_FLAG<>'N' and C.TERRITORY_ID= B.TERRITORY_ID and RAC.PARTY_ID= a.PARTY_ID"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        new_customer_count = ds.Tables("RES").Rows.Count

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"

        S &= "<tr><td>Dear Sir,</td></tr>"
        S &= "<tr><td><br> </td></tr>"

        S &= "<tr><td>The following New Customers are added on " & Format(new_customer_date, "dd-MMM-yyyy") & " through Form II. </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Sl.No</th><th>Customer Name</th><th>Creation Date</th><th>Region</th><th>Industrial Segment</th><th>VOP Expected</th><th>Price List</th><th>Discount</th><th>Payment Terms</th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center>" & k + 1 & "</td><td >" & .Item("CUSTOMER_NAME") & "</td><td>" & Format(.Item("creation_date"), "dd-MMM-yyyy") & "</td><td>"

                If Not IsDBNull(.Item("REGION")) Then S &= "" & .Item("REGION") & "" Else S &= "&nbsp;"
                S &= "</td><td>"
                If Not IsDBNull(.Item("IND_SEGMENT")) Then S &= "" & .Item("IND_SEGMENT") & "" Else S &= "&nbsp;"
                S &= "</td><td>"
                If Not IsDBNull(.Item("VOP_EXPECTED")) Then S &= "" & .Item("VOP_EXPECTED") & "" Else S &= "&nbsp;"
                S &= " </td><td>"
                If Not IsDBNull(.Item("PRICE_LIST")) Then S &= " " & .Item("PRICE_LIST") & "" Else S &= "&nbsp;"
                S &= "</td><td>"
                If Not IsDBNull(.Item("DISCOUNT")) Then S &= "" & .Item("DISCOUNT") & "" Else S &= "&nbsp;"
                S &= "</td><td>"
                If Not IsDBNull(.Item("pay_term")) Then S &= " " & .Item("pay_term") & "" Else S &= "&nbsp;"
                S &= "</td></tr>"
            End With
        Next

        S &= "</table></td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>For your kind information Please .</td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>Regards ,</td></tr>"
        S &= "<tr><td>Mktg team</td></tr></table>"
        S &= "<p>This is a computer generated email. Please do not Reply."

    End Sub
    Private Sub current_year_sale_qty()
        'sql = "Select Jan_Orgcode(Organization_Id)Org,Sum(Quantity_Invoiced)Sale_Qty From Jan_Sales_Any_1_Copy Where Trx_Date>=trunc(sysdate,'MM') Group By Organization_Id"
        sql = "select JAN_ORGCODE(ORGANIZATION_ID)ORG,to_char(trx_date,'yyyyMM')ym,SUM(QUANTITY_INVOICED)SALE_QTY,(decode(substr(my,1,2),'04','Apr','05','May','06','Jun','07','Jul','08','Aug','09','Sep','10','Oct','11','Nov','12','Dec','01','Jan','02','Feb','03','Mar'))||'-'||substr(my,3,4)mnth from JAN_SALES_ANY_1_COPY where TRX_DATE>=(select F_DT_CYR from JAN_SALES_BI_SETUP) Group By JAN_ORGCODE(ORGANIZATION_ID), TO_CHAR(TRX_DATE,'yyyyMM'), (DECODE(SUBSTR(MY,1,2),'04','Apr','05','May','06','Jun','07','Jul','08','Aug','09','Sep','10','Oct','11','Nov','12','Dec','01','Jan','02','Feb','03','Mar'))||'-'||SUBSTR(MY,3,4) order by ym,org"

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")

        S = "<h4 align=left><font face=verdana size=2>Current Year Sale Qty</font></h4>"
        S &= "<table border=1 cellspacing=0 cellpadding=5 width=25%><tr><th><font face=verdana size=2>Month</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Sale Qty</font></th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center><font face=verdana size=2>" & .Item("mnth") & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td align=right><font face=verdana size=2>" & .Item("Sale_Qty") & "</font></td></tr>"
            End With

        Next

        S &= "</table>"
        S &= "<br>"
        S &= "<p>This is a computer generated email. Please do not Reply."

    End Sub
    Private Sub component_shortage()

        sql = " delete from JAN_PRODUCT_SHORTAGE"
        comand()
        sql = " delete from JAN_PRODUCT_SHORTAGE_lines"
        comand()
        sql = " insert into JAN_PRODUCT_SHORTAGE SELECT  A.*,JAN_ORDER_PEND_SEQ.NEXTVAL ,SYSDATE,'N' FROM JAN_PRODUCT_ORDER_PEND_VIEW A WHERE PEND_QTY>0"
        comand()


        sql = " DECLARE BEGIN JAN_ORDER_PEND_COMP_PROC; END;"
        comand()

        sql = "select ORG ""Org"",	ITEM_NO ""Item No"",DESCRIPTION	""Description"",ITEM_TYPE ""Item Type"",	SHORTAGE_QTY	""Shortage Qty"",	MAKE_BUY ""Make Buy"",	ASSEMBLY_PLAN_QTY	""Assy Plan Qty"",PO_IN_RECEIVING	""PO in Receiving"",PO_TOBE_FOLLOWED ""PO Tobe Followed"",	JOB_TOBE_FOLLOWED ""Job tobe Followed"" "
        sql &= " from (select a.* , "
        sql &= " (SELECT DECODE(PLANNING_MAKE_BUY_CODE,1,'Make','Buy') FROM MTL_SYSTEM_ITEMS WHERE ORGANIZATION_ID=A.ORGANIZATION_ID AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID)MAKE_BUY "

        sql &= ",nvl((select sum(requirement-cancelled_qty-received_quantity) from jan_assembly_plan_master where ORGANIZATION_ID=a.ORGANIZATION_ID  AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0)assembly_plan_qty "

        sql &= ", nvl((select sum(order_quantity) from jan_po_in_receiving_tab where ORGANIZATION_ID=a.ORGANIZATION_ID  AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0)po_in_receiving, "
        sql &= "nvl((select sum(order_quantity) from jan_po_tobe_followed_tab where ORGANIZATION_ID=a.ORGANIZATION_ID  AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0)po_tobe_followed "

        sql &= ",nvl((select sum(order_quantity) from jan_jobcards_tobe_followed_tab where ORGANIZATION_ID=a.ORGANIZATION_ID  AND INVENTORY_ITEM_ID=A.INVENTORY_ITEM_ID),0)job_tobe_followed "
        sql &= "from ( "
        sql &= "SELECT JAN_ORGCODE(ORGANIZATION_ID)ORG,COMPONENT item_no, DESCRIPTION , ITEM_TYPE,SUM(SHORTAGE)SHORTAGE_QTY,INVENTORY_ITEM_ID,ORGANIZATION_ID FROM JAN_PRODUCT_SHORTAGE_LINES  where ref_no in (select ref_no from JAN_PRODUCT_SHORTAGE where  week_id<=to_char(sysdate,'YYYYIW')) GROUP BY JAN_ORGCODE(ORGANIZATION_ID), COMPONENT, DESCRIPTION, ITEM_TYPE, INVENTORY_ITEM_ID, ORGANIZATION_ID)a)"

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Pending Orders Component Shortage")

    End Sub
    Private Sub dealer_payment_status()

        sql = "select b_cust_name,CUSTOMER_CATEGORY,region,sum(po_upto_before_2week)po_upto_before_2week,sum(inv_upto_before_2week)inv_upto_before_2week,sum(po_upto_before_1week)po_upto_before_1week,sum(inv_upto_before_1week)inv_upto_before_1week,sum(po_last_week)po_last_week,sum(inv_last_week)inv_last_week,sum(po_upto_before_2week+po_upto_before_1week+po_last_week)po_total ,sum(inv_upto_before_2week+inv_upto_before_1week+inv_last_week)inv_total from (select a.*"

        sql &= " ,to_char(payment_exp_date,'IW')wk,case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')<=TO_CHAR(SYSDATE-21,'IYYYIW') and flag='PENDING ORDER' and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end po_upto_before_2week,"

        sql &= " case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')<=TO_CHAR(SYSDATE-21,'IYYYIW') and flag='OUTSTANDING'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end inv_upto_before_2week ,"

        sql &= " case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')=TO_CHAR(SYSDATE-14,'IYYYIW') and flag='PENDING ORDER'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end po_upto_before_1week"

        sql &= " ,case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')=TO_CHAR(SYSDATE-14,'IYYYIW') and flag='OUTSTANDING'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end inv_upto_before_1week"

        sql &= " ,case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')=TO_CHAR(SYSDATE-7,'IYYYIW') and flag='PENDING ORDER'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end po_last_week"

        sql &= " ,case when TO_CHAR(PAYMENT_EXP_DATE,'IYYYIW')=TO_CHAR(SYSDATE-7,'IYYYIW') and flag='OUTSTANDING'  and payment_exp_date<sysdate then (payment_value-rsv2) else 0 end inv_last_week,(payment_value-rsv2)pend_val ,(select CUSTOMER_CATEGORY from JAN_IT.JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.cust_ID)CUSTOMER_CATEGORY from jan_dealer_payment2 a )GROUP BY B_CUST_NAME,CUSTOMER_CATEGORY,region order by B_CUST_NAME"

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")
        With ds.Tables("result")
            .Rows.Add()
            .Rows(.Rows.Count - 1).Item("po_upto_before_2week") = .Compute("sum(po_upto_before_2week)", "po_upto_before_2week>=0")
            .Rows(.Rows.Count - 1).Item("inv_upto_before_2week") = .Compute("sum(inv_upto_before_2week)", "inv_upto_before_2week>=0")
            .Rows(.Rows.Count - 1).Item("po_upto_before_1week") = .Compute("sum(po_upto_before_1week)", "po_upto_before_1week>=0")

            .Rows(.Rows.Count - 1).Item("inv_upto_before_1week") = .Compute("sum(inv_upto_before_1week)", "inv_upto_before_1week>=0")
            .Rows(.Rows.Count - 1).Item("po_last_week") = .Compute("sum(po_last_week)", "po_last_week>=0")
            .Rows(.Rows.Count - 1).Item("inv_last_week") = .Compute("sum(inv_last_week)", "inv_last_week>=0")

            .Rows(.Rows.Count - 1).Item("po_total") = .Compute("sum(po_total)", "po_total>=0")
            .Rows(.Rows.Count - 1).Item("inv_total") = .Compute("sum(inv_total)", "inv_total>=0")

        End With

        S = "<h4 align=left><font face=verdana size=2>Dealer Payment Status as on :" & Format(Date.Today, "dd-MMM-yyyy") & "</font></h4>"
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab width=80%>"

        S &= "<tr bgcolor=lightyellow><th rowspan=2>Dealer Name </th><th rowspan=2>Dealer Category </th><th rowspan=2>Region </th><th colspan=2>Upto wk-" & week3 & "</th><th colspan=2>wk-" & week2 & "</th><th colspan=2>wk-" & week1 & "</th><th colspan=2>Total Payment</th></tr>"

        S &= "<tr  bgcolor=lightyellow><th>Pending <br>Order</th><th>Invoice</th><th>Pending <br>Order</th><th>Invoice</th><th>Pending <br>Order</th><th>Invoice</th><th>Pending <br>Order</th><th>Invoice</th></tr>"
        For k = 0 To ds.Tables("result").Rows.Count - 1

            With ds.Tables("result").Rows(k)
                S &= "<tr>"
                S &= "<td>" & .Item("b_cust_name") & "</td>"
                S &= "<td>" & .Item("CUSTOMER_CATEGORY") & "</td>"
                S &= "<td>" & .Item("region") & "</td>"
                S &= "<td align=right>" & Format(.Item("po_upto_before_2week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("inv_upto_before_2week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("po_upto_before_1week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("inv_upto_before_1week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("po_last_week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("inv_last_week"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("po_total"), "00.00") & "</td>"
                S &= "<td align=right>" & Format(.Item("inv_total"), "00.00") & "</td>"


                S &= "</tr>"

            End With
        Next

        S &= "</table></html>"
        'file_name = ""
        X = "D:\MAILER\Dealer Payment Status.html"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

    End Sub
    Private Sub excess_po_released_body()
        sql = "select org ""Org"",sum(TOT_EXCESS_VAL)""Excess Value Released"" from (  SELECT (select organization_code from org_organization_definitions where organization_id=a.organization_id)org,A.*,ROUND(((PO_RELEASED-PO_TBR)*ITEM_COST),2) TOT_EXCESS_VAL  FROM JAN_PO_JOB_TBR_MASTER_V A  )GROUP BY rollup(ORG)"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")


        S = "<h4 align=left><font face=verdana size=2>Excess PO Released on :" & Format(Date.Today, "dd-MMM-yyyy") & "</font></h4>"
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr>"
        For k = 0 To ds.Tables("result").Columns.Count - 1
            With ds.Tables("result").Columns(k)
                S &= "<th><font  color=firebrick>" & .ColumnName & "</font></th>"
            End With
        Next
        S &= "</tr>"


        For k = 0 To ds.Tables("result").Rows.Count - 1

            S &= "<tr>"
            For j = 0 To ds.Tables("result").Columns.Count - 1
                With ds.Tables("result").Rows(k)
                    If .Item(j).GetType.Name = "Decimal" Then align = "right" Else align = "left"
                    S &= "<td align=" & align & ">" & .Item(j) & "</td>"
                End With
            Next
            S &= "</tr>"

        Next
        S &= "</table ></html>"
        S &= "<br>"
        sql = "select org ""Org"",sum(TOT_EXCESS_VAL)""Excess Value Released"" from (  SELECT (select organization_code from org_organization_definitions where organization_id=a.organization_id)org,A.*,ROUND(((job_RELEASED-PO_TBR)*ITEM_COST),2) TOT_EXCESS_VAL  FROM JAN_JOB_TBR_MASTER_V A  )GROUP BY rollup(ORG)"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")


        S &= "<h4 align=left><font face=verdana size=2>Excess JOB Released on :" & Format(Date.Today, "dd-MMM-yyyy") & "</font></h4>"
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr>"
        For k = 0 To ds.Tables("result").Columns.Count - 1
            With ds.Tables("result").Columns(k)
                S &= "<th><font  color=firebrick>" & .ColumnName & "</font></th>"
            End With
        Next
        S &= "</tr>"


        For k = 0 To ds.Tables("result").Rows.Count - 1

            S &= "<tr>"
            For j = 0 To ds.Tables("result").Columns.Count - 1
                With ds.Tables("result").Rows(k)
                    If .Item(j).GetType.Name = "Decimal" Then align = "right" Else align = "left"
                    S &= "<td align=" & align & ">" & .Item(j) & "</td>"
                End With
            Next
            S &= "</tr>"

        Next
        S &= "</table ></html>"

        S &= "<p>This is a computer generated email. Please do not Reply."

    End Sub
    Private Sub order_payment()
        sql = "select * from ( select B_CUST_NAME ""Dealer Name"",PAYMENT_STATUS ""Payment Status"",trunc(payment_exp_date)""Payment Exp Date"",FLAG ""Payment For"", SUM(PAYMENT_VALUE)""Payment to be Received Value"", SUM(nvl(AVAIL_VALUE,0)+nvl(picked_value,0))""Available Value for order"",SUM(RSV2) ""Available Payment"",REGION ""Region"" from jan_dealer_payment  GROUP BY B_CUST_NAME, PAYMENT_STATUS, TRUNC(PAYMENT_EXP_DATE), FLAG, REGION ) sub1 order by 1,3 asc"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Payment Data Consolidation")

        sql = "select  B_CUST_NAME ""Dealer Name"",order_number ""Order No"",ordered_date ""Order Date"", PAYMENT_STATUS ""Payment Status"",trunc(payment_exp_date)""Payment Exp Date"",FLAG ""Payment For"",(PAYMENT_VALUE)""Payment to be Received Value"",(nvl(AVAIL_VALUE,0)+nvl(picked_value,0))""Available Value for order "",(RSV2) ""Available Payment"",REGION ""Region"",(SELECT fnd.DESCRIPTION FROM jan_bms_order_pending_new_v bms ,FND_FLEX_VALUES_VL fnd WHERE fnd.FLEX_VALUE_SET_ID=1010407 AND fnd.FLEX_VALUE=bms.ORD_CAT and bms.order_number=a.order_number and rownum=1)""Order Category"",(select ord_type from jan_bms_order_pending_new_v where order_number=a.order_number and rownum=1)""Order Type"",(select cusordno from jan_bms_order_pending_new_v where order_number=a.order_number and rownum=1)""Customer Order No"",(select cusorddt from jan_bms_order_pending_new_v where order_number=a.order_number and rownum=1)""Customer Order Dt"" from jan_dealer_payment a order by B_CUST_NAME,payment_cum"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Order and Payment Breakup")
    End Sub


    Private Sub invoice_to_apply()

        sql = " DECLARE BEGIN JAN_DEALER_ORDER_PAYMENT_PROC2(0); END;"
        comand()


        Try
            'sql = " INSERT INTO jan_dealer_payment2_BK(LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,AS_ON,header_id,line_number)  SELECT LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,STATUS_AS_ON,(select distinct header_id from oe_order_lines_all where line_id=a.line_id )header_id,(select distinct line_number from oe_order_lines_all where line_id=a.line_id )line_number FROM jan_dealer_payment2 a  where FLAG='OUTSTANDING' AND (nvl(PAYMENT_VALUE,0)-NVL(RSV2,0))>0 "
            ''sql = " INSERT INTO jan_dealer_payment2_BK SELECT A.* FROM jan_dealer_payment2 A"
            'comand()


            'sql = " INSERT INTO jan_dealer_payment2_BK(LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,AS_ON,header_id,line_number)  SELECT LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,STATUS_AS_ON,(select distinct header_id from oe_order_lines_all where line_id=a.line_id )header_id,(select distinct line_number from oe_order_lines_all where line_id=a.line_id )line_number FROM jan_dealer_payment2 a  where FLAG='OUTSTANDING' AND (nvl(PAYMENT_VALUE,0)-NVL(RSV2,0))=0  AND  TRX_DATE>TRUNC(SYSDATE)-30 "
            ''sql = " INSERT INTO jan_dealer_payment2_BK SELECT A.* FROM jan_dealer_payment2 A"
            'comand()


            'sql = " INSERT INTO jan_dealer_payment2_BK(LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,AS_ON,header_id,line_number)  SELECT LINE_ID ,CUST_ID,B_CUST_NAME,REGION,ORDER_NUMBER,ORDERED_DATE,TRX_NUMBER,TRX_DATE ,ORD_CAT,PAYMENT_VALUE ,AVAIL_VALUE,PICKED_VALUE ,PAYMENT_EXP_DATE,CUSORDNO,FLAG,AVAILABLE_AMOUNT ,PAYMENT_CUM,RSV2 ,PAYMENT_STATUS,STATUS_AS_ON,(select distinct header_id from oe_order_lines_all where line_id=a.line_id )header_id,(select distinct line_number from oe_order_lines_all where line_id=a.line_id )line_number FROM jan_dealer_payment2 a  where FLAG='PENDING ORDER' "
            ''sql = " INSERT INTO jan_dealer_payment2_BK SELECT A.* FROM jan_dealer_payment2 A"
            'comand()

        Catch ex As Exception

            sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Accts Mail -Dealer Payment')"
            comand()
        End Try

        sql = "SELECT LEDGER_BALANCE ""Ledger Balance"",sample_free_replace ""Sample Free Unapplied Inv"", CUSTOMER_NAME ""Dealer Name"", PENDING_ORDER_TODAY ""Total Pending Order"",TOBE_MADE_PEND_ORDER ""Tobe collected for Order"",TOBE_MADE_PEND_INVOICE ""Tobe collected for Inv"",(LEDGER_BALANCE+PENDING_ORDER_TODAY)""Ledger + Pending Order""  ,(TOBE_MADE_PEND_ORDER+TOBE_MADE_PEND_INVOICE)""Total Amt tobe Collected"" "
        'sql &= "  ,(LEDGER_BALANCE+PENDING_ORDER_TODAY)-(TOBE_MADE_PEND_ORDER+tobe_made_pend_invoice)""Diff between Ledger & Pay Cal""  "

        sql &= " , case  when (TOBE_MADE_PEND_ORDER+tobe_made_pend_invoice+PENDING_ORDER_TODAY)=0 then 0 when (TOBE_MADE_PEND_ORDER+tobe_made_pend_invoice)=0 and  LEDGER_BALANCE<0 and abs(LEDGER_BALANCE)>=PENDING_ORDER_TODAY then 0 else (LEDGER_BALANCE+PENDING_ORDER_TODAY)-(TOBE_MADE_PEND_ORDER+tobe_made_pend_invoice) end  ""Diff between Ledger & Pay Cal"""

        sql &= "  FROM (  SELECT A.* ,   (SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID)CUSTOMER_NAME   ,NVL((SELECT SUM(PAYMENT_VALUE) FROM JAN_DEALER_PAYMENT2_TAB WHERE CUST_ID=A.CUSTOMER_ID AND FLAG='PENDING ORDER'),0)PENDING_ORDER_TODAY,    NVL((SELECT SUM(RSV2) FROM JAN_DEALER_PAYMENT2_TAB WHERE CUST_ID=A.CUSTOMER_ID AND FLAG='PENDING ORDER'),0)AVAIL_FOR_PENDING_ORD     ,NVL((SELECT SUM(PAYMENT_VALUE-nvl(rsv2,0)) FROM JAN_DEALER_PAYMENT2_TAB WHERE CUST_ID=A.CUSTOMER_ID AND FLAG='PENDING ORDER'  ),0)TOBE_MADE_PEND_ORDER   ,nvl((SELECT sum(payment_value-nvl(rsv2,0)) FROM JAN_DEALER_PAYMENT2_TAB WHERE CUST_ID=a.customer_id AND FLAG='OUTSTANDING' ),0)tobe_made_pend_invoice "

        sql &= "  ,NVL((SELECT SUM(AMOUNT_DUE_REMAINING) FROM JAN_REGION_PAYMENT_PENDING WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID AND NAME IN (select NAME from ra_cust_trx_types_all where NAME IN ('Commission-CM','Commission - CM', 'Exhibition Sales','Projects Credit Memo','Projects Credit Memo','Projects Invoice', 'Projects Invoice','Purchase Return','Samples / Free Inv-1','Samples / Free Inv-2', 'Service Invoice','TDS Credit Memo','Samp / Free Inv-1 -N','Samp / Free Inv-2 -N','Samp / Free Inv-7 -N')) AND AMOUNT_DUE_REMAINING>0  AND BILL_TO_CUSTOMER_ID IN (SELECT CUSTOMER_ID FROM RA_CUSTOMERS WHERE   CUSTOMER_CLASS_CODE='DEALER') ),0)sample_free_replace "


        sql &= "    FROM (   select CUSTOMER_ID,"
        sql &= " SUM(NVL(AMOUNT_DR,0))"
        ' sql &= " sum(case when ar_date>='15-jul-2017' and inv_type  like 'Samp%' then 0 else NVL(AMOUNT_DR,0) end) "
        sql &= " -SUM(NVL(AMOUNT_CR,0)) ledger_balance from JAN_DEALER_LEDGER_17JUL_2017  where CUSTOMER_ID in (select customer_id from ra_customers   WHERE CUSTOMER_CLASS_CODE='DEALER'    ) and   ar_date is not null GROUP BY CUSTOMER_ID   )A)B order by 3"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Dealer Payment Consolidation")
        Try
            sql = " DROP table JAN_REGION_PAYMENT_PENDING_tab"
            comand()
        Catch ex As Exception

        End Try


        sql = " create table JAN_REGION_PAYMENT_PENDING_tab as select * from JAN_REGION_PAYMENT_PENDING"
        comand()

        sql = " CREATE INDEX JAN_REGION_PAYMENT_IDX1 ON JAN_REGION_PAYMENT_PENDING_TAB (BILL_TO_CUSTOMER_ID,NAME) LOGGING TABLESPACE  JAN_TS_TX_IND  PCTFREE 10 INITRANS   11 MAXTRANS   255 STORAGE  (INITIAL  128K   NEXT 128K   MINEXTENTS    1  MAXEXTENTS    2147483645     PCTINCREASE   0     BUFFER_POOL   DEFAULT )NOPARALLEL"
        comand()

        sql = "CREATE INDEX JAN_REGION_PENDING_TAB_IDX2 ON JAN_REGION_PAYMENT_PENDING_TAB (BILL_TO_CUSTOMER_ID,BILL_TO_CUST_NAME,REGION) LOGGING TABLESPACE  JAN_TS_TX_IND PCTFREE    10 INITRANS   11 MAXTRANS   255 STORAGE    (INITIAL   128K  NEXT 128K MINEXTENTS    1  MAXEXTENTS    2147483645  PCTINCREASE   0  BUFFER_POOL   DEFAULT  ) NOPARALLEL"
        comand()

        sql = "CREATE INDEX JAN_REGION_PENDING_TAB_IDX3 ON JAN_REGION_PAYMENT_PENDING_TAB (TRX_NUMBER) LOGGING TABLESPACE  JAN_TS_TX_IND PCTFREE    10 INITRANS   11 MAXTRANS   255 STORAGE    (INITIAL   128K  NEXT 128K MINEXTENTS    1  MAXEXTENTS    2147483645  PCTINCREASE   0  BUFFER_POOL   DEFAULT  ) NOPARALLEL"
        comand()

        'Try
        '    sql = "DROP TABLE JAN_DEALER_UNAPPLIED_CUM_TAB "
        '    comand()
        'Catch ex As Exception

        'End Try


        'sql = "CREATE TABLE JAN_DEALER_UNAPPLIED_CUM_TAB AS SELECT * FROM JAN_DEALER_UNAPPLIED_CUM_V"
        'comand()


        'sql = " SELECT B.*,(UN_APPLIED-AMOUNT_CAN_BE_APPLIED) ""Amount Still Avail For Apply"",JAN_CHECK_POSITIVE(TOTAL_OUT_STANDING-UN_APPLIED)""Remaining Outstanding""  FROM (select customer_id,customer_name,NVL(jan_cus_pp(a.customer_id),0)UN_APPLIED,(select NVL(SUM(AMOUNT_DUE_REMAINING),0) FROM JAN_REGION_PAYMENT_PENDING_TAB WHERE BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID AND  AMOUNT_DUE_REMAINING<>0)TOTAL_OUT_STANDING,NVL((select SUM(RSV2) from jan_dealer_payment where cust_id=A.CUSTOMER_ID and payment_status in ('To be Applied','To be Applied-Partially')),0)AMOUNT_CAN_BE_APPLIED from ra_customers a where customer_class_code='DEALER' )B ORDER BY CUSTOMER_NAME"
        'sql = " SELECT B.*,(UN_APPLIED-AMOUNT_CAN_BE_APPLIED) ""Amount Still Avail For Apply"",JAN_CHECK_POSITIVE(TOTAL_OUT_STANDING-UN_APPLIED)""Remaining Outstanding""  FROM (select customer_id,customer_name,nvl((SELECT SUM(UNAPP_AMOUNT) FROM JAN_DEALER_UNAPPLIED WHERE CUSTOMER_ID=A.CUSTOMER_ID),0)UN_APPLIED,(select NVL(SUM(AMOUNT_DUE_REMAINING),0) FROM JAN_REGION_PAYMENT_PENDING_TAB WHERE BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID AND  AMOUNT_DUE_REMAINING<>0)TOTAL_OUT_STANDING,NVL((select SUM(RSV2) from jan_dealer_payment2 where cust_id=A.CUSTOMER_ID and payment_status in ('To be Applied','To be Applied-Partially')),0)AMOUNT_CAN_BE_APPLIED from ra_customers a where customer_class_code='DEALER' )B ORDER BY CUSTOMER_NAME"

        'sql = "SELECT B.*,(UN_APPLIED-AMOUNT_CAN_BE_APPLIED) ""Amount Still Avail For Apply"",JAN_CHECK_POSITIVE(TOTAL_OUT_STANDING-UN_APPLIED)""Remaining Outstanding"" FROM   (SELECT customer_id,customer_name,NVL((SELECT SUM(UNAPP_AMOUNT) FROM JAN_DEALER_UNAPPLIED WHERE CUSTOMER_ID=A.CUSTOMER_ID),0)UN_APPLIED,"
        ''sql &= " NVL((SELECT SUM(payment_value) FROM jan_dealer_payment2 WHERE cust_id=A.CUSTOMER_ID AND flag='OUTSTANDING'),0)TOTAL_OUT_STANDING,"
        'sql &= " NVL((SELECT SUM(amount_due_remaining)  FROM jan_region_payment_pending_tab  WHERE biLL_to_customer_id=A.CUSTOMER_ID  AND amount_due_remaining<>0),0)TOTAL_OUT_STANDING,"


        'sql &= " NVL((SELECT SUM(RSV2) FROM jan_dealer_payment2  WHERE cust_id=A.CUSTOMER_ID AND payment_status IN ('To be Applied','To be Applied-Partially')),0)AMOUNT_CAN_BE_APPLIED FROM ra_customers a WHERE customer_class_code='DEALER' )B ORDER BY CUSTOMER_NAME"

        'adap = New OracleDataAdapter(sql, con)
        'ds = New DataSet
        'adap.Fill(ds, "RES")
        'mail_content("Invoice Amount to Apply Consolidation")

        'sql = "select BILL_TO_CUST_NAME ""Dealer Name"",	TRX_NUMBER ""Invoice No"",	TRX_daTE ""Invoice Date""	,AMOUNT_DUE_ORIGINAL ""Invoice Original Amount"", AMOUNT_DUE_REMAINING ""Invoice Remaining Due Amount""	,payment_date ""Payment Due Date"",AMOUNT_TO_APPLY ""Available Amount to Apply"", RSV2 ""Amount to Apply"",RECEIPTS  from ( SELECT B.*, CASE WHEN DUE_CUM<=AMOUNT_TO_APPLY THEN amount_due_remaining ELSE JAN_CHECK_POSITIVE(AMOUNT_TO_APPLY-nvl(lag(DUE_CUM) over (PARTITION BY bill_to_customer_id ORDER BY bill_to_customer_id, payment_date,TRX_NUMBER),0)) END RSV2  ,ROWTOCOL('select DISTINCT receipt_number from JAN_DEALER_UNAPPLIED where customer_id='||b.bill_to_customer_id)RECEIPTS FROM (SELECT bill_to_customer_id,BILL_TO_CUST_NAME,TRX_NUMBER,TRX_daTE,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,payment_date,AMOUNT_TO_APPLY ,SUM(AMOUNT_DUE_REMAINING) OVER (PARTITION BY bill_to_customer_id ORDER BY payment_date,TRX_NUMBER)DUE_CUM  FROM (select a.* ,(SELECT MAX(JAN_PAYMENT_FULFILLMENT_DATE(TO_NUMBER(INTERFACE_LINE_ATTRIBUTE6))) ORD_FF_DT FROM RA_CUSTOMER_TRX_LINES_ALL RL WHERE RL.LINE_TYPE='LINE' AND RL.CUSTOMER_TRX_ID=A.CUSTOMER_TRX_ID) payment_date,(select SUM(RSV2) from jan_dealer_payment where cust_id=A.bill_to_customer_id and payment_status in ('To be Applied','To be Applied-Partially'))AMOUNT_TO_APPLY  from jan_region_payment_pending_tab a where amount_due_remaining>0 and bill_to_customer_id in (select customer_id from ra_customers where customer_class_code='DEALER'  ) ) )B) where rsv2>0 ORDER BY BILL_TO_CUST_NAME,TRX_NUMBER "

        'sql = "SELECT B_CUST_name ""Dealer Name"",TRX_NUMBER ""Invoice No"",TRX_daTE ""Invoice DATE"",AMOUNT_DUE_ORIGINAL ""Invoice Original Amount"",AMOUNT_DUE_REMAINING ""Invoice Remaining Due Amount"", payment_date ""Payment Due DATE"",AMOUNT_TO_APPLY ""Available Amount to Apply"",AMOUNT_TO_APPLY ""Amount TO Apply"",RECEIPTS FROM  (SELECT B.*,ROWTOCOL('select DISTINCT receipt_number from JAN_DEALER_UNAPPLIED where customer_id='     ||b.cust_id)RECEIPTS "

        'sql &= ",NVL((SELECT amount_due_original FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_ORIGINAL"

        'sql &= ",NVL((SELECT amount_due_remaining FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_REMAINING "
        'sql &= " FROM (SELECT cust_id,B_CUST_NAME,TRX_NUMBER,TRX_daTE"

        'sql &= ",payment_exp_date payment_date,sum(AMOUNT_TO_APPLY) AMOUNT_TO_APPLY  FROM (select a.*,case when payment_status IN ('To be Applied','To be Applied-Partially') then rsv2 else 0 end AMOUNT_TO_APPLY  FROM jan_dealer_payment2 a WHERE  flag='OUTSTANDING'  ) group by CUST_ID, B_CUST_NAME, TRX_NUMBER, TRX_DATE, PAYMENT_EXP_DATE )B ) WHERE AMOUNT_TO_APPLY>0 ORDER BY B_CUST_name"

        'sql = "SELECT B_CUST_NAME ""Dealer Name"",TRX_NUMBER ""Invoice No"",TRX_DATE ""Invoice Date"",AMOUNT_DUE_ORIGINAL ""Invoice Original Amount"",AMOUNT_DUE_REMAINING ""Invoice Remaining Due Amount"", PAYMENT_DATE ""Payment Due DATE"",AMOUNT_TO_APPLY ""Available Amount to Apply"", AMOUNT_TO_APPLY ""Amount To Apply"",CASE WHEN NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) THEN NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) ELSE NVL(RECEIPTS1,RECEIPTS2) END ""Receipts"" FROM (SELECT M.*,ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE ' || M.CUM_APPLY || ' BETWEEN LAG_CUM_UNAPP AND CUM_UNAPP') RECEIPTS1, ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE CUM_UNAPP BETWEEN ' || LAG_CUM_APPLY || '  AND '||  LEAD_CUM_APPLY) RECEIPTS2 FROM (select CUST_ID,B_CUST_NAME ,TRX_NUMBER ,TRX_DATE  , PAYMENT_DATE  ,AMOUNT_TO_APPLY  ,CUM_APPLY,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,NVL(LEAD(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY PAYMENT_DATE, TRX_NUMBER),0) LEAD_CUM_APPLY,nvl(LAG(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY PAYMENT_DATE, TRX_NUMBER),0) LAG_CUM_APPLY from  (select B.*,SUM(AMOUNT_TO_APPLY) over (partition by CUST_ID order by PAYMENT_DATE,TRX_NUMBER) CUM_APPLY,NVL((SELECT amount_due_original FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_ORIGINAL,NVL((SELECT amount_due_remaining FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_REMAINING from (SELECT CUST_ID,B_CUST_NAME,TRX_NUMBER,TRX_DATE,PAYMENT_EXP_DATE PAYMENT_DATE,SUM(AMOUNT_TO_APPLY) AMOUNT_TO_APPLY from (SELECT A.*,CASE WHEN PAYMENT_STATUS IN ('To be Applied','To be Applied-Partially') THEN RSV2 ELSE 0 END AMOUNT_TO_APPLY  FROM JAN_DEALER_PAYMENT2 A WHERE  FLAG='OUTSTANDING'  ) group by CUST_ID, B_CUST_NAME, TRX_NUMBER, TRX_DATE, PAYMENT_EXP_DATE )B ) F WHERE AMOUNT_TO_APPLY>0) M)N   ORDER BY B_CUST_name"

        'sql = "SELECT B_CUST_NAME ""Dealer Name"",TRX_NUMBER ""Invoice No"",TRX_DATE ""Invoice Date"",AMOUNT_DUE_ORIGINAL ""Invoice Original Amount"",AMOUNT_DUE_REMAINING ""Invoice Remaining Due Amount"", AMOUNT_TO_APPLY ""Available Amount to Apply"", AMOUNT_TO_APPLY ""Amount To Apply"",CASE WHEN NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) THEN NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) ELSE NVL(RECEIPTS1,RECEIPTS2) END ""Receipts"" FROM (SELECT M.*,ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE ' || M.CUM_APPLY || ' BETWEEN LAG_CUM_UNAPP AND CUM_UNAPP') RECEIPTS1, ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE CUM_UNAPP BETWEEN ' || LAG_CUM_APPLY || '  AND '||  LEAD_CUM_APPLY) RECEIPTS2 FROM (select CUST_ID,B_CUST_NAME ,TRX_NUMBER ,TRX_DATE   ,AMOUNT_TO_APPLY  ,CUM_APPLY,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,NVL(LEAD(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY  TRX_NUMBER),0) LEAD_CUM_APPLY,nvl(LAG(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY  TRX_NUMBER),0) LAG_CUM_APPLY from  (select B.*,SUM(AMOUNT_TO_APPLY) over (partition by CUST_ID order by TRX_NUMBER) CUM_APPLY,NVL((SELECT amount_due_original FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_ORIGINAL,NVL((SELECT amount_due_remaining FROM jan_region_payment_pending_Tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_REMAINING from (SELECT CUST_ID,B_CUST_NAME,TRX_NUMBER,TRX_DATE,SUM(AMOUNT_TO_APPLY) AMOUNT_TO_APPLY from (SELECT A.*,CASE WHEN PAYMENT_STATUS IN ('To be Applied','To be Applied-Partially') THEN RSV2 ELSE 0 END AMOUNT_TO_APPLY  FROM JAN_DEALER_PAYMENT2 A WHERE  FLAG='OUTSTANDING'  ) group by CUST_ID, B_CUST_NAME, TRX_NUMBER, TRX_DATE )B ) F WHERE AMOUNT_TO_APPLY>0) M)N   ORDER BY B_CUST_name"

        'sql = " DECLARE BEGIN jan_DEALER_PAYMENT_APPLY_PROC ; END;"
        'comand()



        'sql = " select  B_CUST_NAME ""Dealer Name"",TRX_NUMBER ""Invoice No"",TRX_DATE ""Invoice Date"",AMOUNT_DUE_ORIGINAL ""Invoice Original Amount"",AMOUNT_DUE_REMAINING ""Invoice Remaining Due Amount"",AMOUNT_TO_APPLY ""Available Amount to Apply"", AMOUNT_TO_APPLY ""Amount To Apply"",REC_NO ""Receipts""   from JAN_4109_BR_TEMP ORDER BY B_CUST_name,TRX_NUMBER "


        'adap = New OracleDataAdapter(sql, con)
        'ds = New DataSet
        'adap.Fill(ds, "RES")
        'mail_content("Invoice Amount to Apply breakup")

        'Try
        '    sql = "drop table jan_dealer_payment_to_apply"
        '    comand()
        'Catch ex As Exception

        'End Try

        'sql = " create table jan_dealer_payment_to_apply as SELECT B_CUST_NAME Dealer_Name,TRX_NUMBER ,TRX_DATE ,AMOUNT_DUE_ORIGINAL Invoice_Original_Amount,AMOUNT_DUE_REMAINING Invoice_Remaining_Due_Amount, AMOUNT_TO_APPLY Available_Amount_to_Apply, AMOUNT_TO_APPLY ,CASE WHEN NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) THEN NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) ELSE NVL(RECEIPTS1,RECEIPTS2) END Receipts FROM (SELECT M.*,ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE ' || M.CUM_APPLY || ' BETWEEN LAG_CUM_UNAPP AND CUM_UNAPP') RECEIPTS1, ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE CUM_UNAPP BETWEEN ' || LAG_CUM_APPLY || '  AND '||  LEAD_CUM_APPLY) RECEIPTS2 FROM (select CUST_ID,B_CUST_NAME ,TRX_NUMBER ,TRX_DATE   ,AMOUNT_TO_APPLY  ,CUM_APPLY,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,NVL(LEAD(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY  TRX_NUMBER),0) LEAD_CUM_APPLY,nvl(LAG(CUM_APPLY) OVER (PARTITION BY B_CUST_NAME ORDER BY  TRX_NUMBER),0) LAG_CUM_APPLY from  (select B.*,SUM(AMOUNT_TO_APPLY) over (partition by CUST_ID order by TRX_NUMBER) CUM_APPLY,NVL((SELECT amount_due_original FROM jan_region_payment_pending_tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_ORIGINAL,NVL((SELECT amount_due_remaining FROM jan_region_payment_pending_Tab  WHERE trx_number=to_char(b.trx_number)),0)AMOUNT_DUE_REMAINING from (SELECT CUST_ID,B_CUST_NAME,TRX_NUMBER,TRX_DATE,SUM(AMOUNT_TO_APPLY) AMOUNT_TO_APPLY from (SELECT A.*,CASE WHEN PAYMENT_STATUS IN ('To be Applied','To be Applied-Partially') THEN RSV2 ELSE 0 END AMOUNT_TO_APPLY  FROM JAN_DEALER_PAYMENT2 A WHERE  FLAG='OUTSTANDING'  ) group by CUST_ID, B_CUST_NAME, TRX_NUMBER, TRX_DATE )B ) F WHERE AMOUNT_TO_APPLY>0) M)N   ORDER BY B_CUST_name"

        'sql = " create table jan_dealer_payment_to_apply as select B_CUST_NAME DEALER_NAME,TRX_NUMBER ,TRX_DATE ,AMOUNT_DUE_ORIGINAL INVOICE_ORIGINAL_AMOUNT,AMOUNT_DUE_REMAINING INVOICE_REMAINING_DUE_AMOUNT, AMOUNT_TO_APPLY AVAILABLE_AMOUNT_TO_APPLY,AMOUNT_TO_APPLY ,case when INSTR(SUBSTR(REC_NO,2),',')>=1 then SUBSTR(REC_NO,2) else SUBSTR(REC_NO,2,INSTR(SUBSTR(REC_NO,2),':',1)-1) end RECEIPTS from JAN_4109_BR_TEMP  ORDER BY B_CUST_name"
        'sql = " create table jan_dealer_payment_to_apply as select B_CUST_NAME DEALER_NAME,TRX_NUMBER ,TRX_DATE ,AMOUNT_DUE_ORIGINAL INVOICE_ORIGINAL_AMOUNT,AMOUNT_DUE_REMAINING INVOICE_REMAINING_DUE_AMOUNT, AMOUNT_TO_APPLY AVAILABLE_AMOUNT_TO_APPLY,BR_VALUE AMOUNT_TO_APPLY ,br_no RECEIPTS from JAN_4109_BR_TEMP_BR_WISE  ORDER BY B_CUST_name"

        'comand()

        'Try
        '    sql = "drop table jan_deal_payment_to_apply_tmp"
        '    comand()
        'Catch ex As Exception
        '    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Mailer - jan_deal_payment_to_apply_tmp drop')"
        '    comand()
        'End Try


        'Try
        '    sql = " create table jan_deal_payment_to_apply_tmp as SELECT B_CUST_NAME,TRX_NUMBER ,TRX_DATE ,AMOUNT_DUE_ORIGINAL ,AMOUNT_DUE_REMAINING , AMOUNT_TO_APPLY , RECEIPTS1, AMOUNT_TO_APPLY-to_number(RECEIPTS2_val)receipt1_amount ,case when NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) then NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) else  NVL(RECEIPTS1,RECEIPTS2) END  receipts,replace(REPLACE (CASE WHEN NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) THEN NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) ELSE  NVL(RECEIPTS1,RECEIPTS2) END,receipts1,''),',','') Receipt2 , case when NVL(N.RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) then TO_NUMBER(RECEIPTS2_VAL)  else 0 end RECEIPT2_AMOUNT from (select S.*,case when NVL(RECEIPTS1,RECEIPTS2)<>NVL(RECEIPTS2,RECEIPTS1) then NVL(RECEIPTS1,RECEIPTS2) ||','|| NVL(RECEIPTS2,RECEIPTS1) else  NVL(RECEIPTS1,RECEIPTS2) end RECEIPT from (select M.*, ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE ' || M.CUM_APPLY || ' BETWEEN LAG_CUM_UNAPP AND CUM_UNAPP') RECEIPTS1 , ROWTOCOL('SELECT RECEIPT_NUMBER FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE CUM_UNAPP BETWEEN ' || LAG_CUM_APPLY || '  AND '||  LEAD_CUM_APPLY) RECEIPTS2 , ROWTOCOL('SELECT CUM_UNAPP-to_number('|| lag_CUM_APPLY ||') FROM (SELECT RECEIPT_NUMBER,CUM_UNAPP,NVL(LAG(CUM_UNAPP) OVER (PARTITION BY A.CUSTOMER_ID ORDER BY CUM_UNAPP),0) LAG_CUM_UNAPP FROM JAN_DEALER_UNAPPLIED_CUM_TAB A WHERE CUSTOMER_ID=' || M.CUST_ID || ') WHERE CUM_UNAPP BETWEEN ' || LAG_CUM_APPLY || '  AND '||  LEAD_CUM_APPLY) RECEIPTS2_val from ( select CUST_ID,B_CUST_NAME ,TRX_NUMBER ,TRX_DATE   ,AMOUNT_TO_APPLY  ,CUM_APPLY,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING ,NVL(LEAD(CUM_APPLY) over (partition by B_CUST_NAME order by  TRX_NUMBER),0) LEAD_CUM_APPLY,NVL(LAG(CUM_APPLY) over (partition by B_CUST_NAME order by  TRX_NUMBER),0) LAG_CUM_APPLY from  ( select B.*,SUM(AMOUNT_TO_APPLY) over (partition by CUST_ID order by TRX_NUMBER) CUM_APPLY, NVL((select AMOUNT_DUE_ORIGINAL from JAN_REGION_PAYMENT_PENDING_TAB  where TRX_NUMBER=TO_CHAR(B.TRX_NUMBER)),0)AMOUNT_DUE_ORIGINAL, NVL((select AMOUNT_DUE_REMAINING from JAN_REGION_PAYMENT_PENDING_TAB  where TRX_NUMBER=TO_CHAR(B.TRX_NUMBER)),0)AMOUNT_DUE_REMAINING from ( select CUST_ID,B_CUST_NAME,TRX_NUMBER,TRX_DATE,SUM(AMOUNT_TO_APPLY) AMOUNT_TO_APPLY from ( select a.*,case when PAYMENT_STATUS in ('To be Applied','To be Applied-Partially') then RSV2 else 0 end AMOUNT_TO_APPLY  from JAN_DEALER_PAYMENT2 a  WHERE  FLAG='OUTSTANDING' ) group by CUST_ID, B_CUST_NAME, TRX_NUMBER, TRX_DATE  )B) F where AMOUNT_TO_APPLY>0) M)s )N where INSTR(RECEIPT,',')>0 and length(RECEIPT) - length(replace(RECEIPT, ',', ''))=1  AND INSTR(RECEIPTS1,',')=0 ORDER BY B_CUST_name"
        '    comand()

        'Catch ex As Exception
        '    sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Mailer - jan_deal_payment_to_apply_tmp creation')"
        '    comand()
        'End Try

        'sql = "declare begin for I in (select * from JAN_DEAL_PAYMENT_TO_APPLY_TMP) LOOP insert into JAN_DEAL_PAYMENT_TO_APPLY_TMP1 (select B_CUST_NaME,TRX_NUMBER,TRX_DATE,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,RECEIPT1_AMOUNT,RECEIPT1_AMOUNT,RECEIPTS1 from JAN_DEAL_PAYMENT_TO_APPLY_TMP where RECEIPTS=I.RECEIPTS and TRX_NUMBER=I.TRX_NUMBER); commit; insert into JAN_DEAL_PAYMENT_TO_APPLY_TMP1 (select B_CUST_NaME,TRX_NUMBER,TRX_DATE,AMOUNT_DUE_ORIGINAL,AMOUNT_DUE_REMAINING,RECEIPT2_AMOUNT,RECEIPT2_AMOUNT,RECEIPT2 from JAN_DEAL_PAYMENT_TO_APPLY_TMP where RECEIPTS=I.RECEIPTS and TRX_NUMBER=I.TRX_NUMBER); commit; delete from JAN_DEALER_PAYMENT_TO_APPLY where RECEIPTS=I.RECEIPTS and TRX_NUMBER=I.TRX_NUMBER and AVAILABLE_AMOUNT_TO_APPLY=I.AMOUNT_TO_APPLY;commit; end LOOP; end;"

        'comand()


        'sql = " insert into jan_deal_payment_to_apply_bk  select  a.*,sysdate from JAN_DEAL_PAYMENT_TO_APPLY_TMP a"
        'comand()

        'sql = " insert into jan_dealer_payment_to_apply select  * from JAN_DEAL_PAYMENT_TO_APPLY_TMP1 a"
        'comand()

        'sql = "  delete from JAN_DEAL_PAYMENT_TO_APPLY_TMP1 a"
        'comand()

        'sql = "alter table JAN_DEALER_PAYMENT_TO_APPLY add (line_no number,as_on date,RECEIPT_APPLIED VARCHAR2(1),line_number number)"
        'comand()

        'sql = "update JAN_DEALER_PAYMENT_TO_APPLY set as_on =sysdate,RECEIPT_APPLIED='N'"
        'comand()
        'sql = "DECLARE BEGIN JAN_DEALER_PAYMENT_LINE_UPDATE ; END;"
        'comand()


        'sql = "declare K number; m number; begin for I in (select distinct RECEIPTS from JAN_DEALER_PAYMENT_TO_APPLY) LOOP m:=0; for J in (select *  from JAN_DEALER_PAYMENT_TO_APPLY where RECEIPTS=I.RECEIPTS order by TRX_NUMBER) LOOP M:=M+1; k :=m; update JAN_DEALER_PAYMENT_TO_APPLY set line_no=k where RECEIPTS=i.RECEIPTS  and TRX_NUMBER=j.TRX_NUMBER and AMOUNT_TO_APPLY=j.AMOUNT_TO_APPLY and nvl(line_number,0)=nvl(j.line_number,0);commit;end LOOP;end loop;end;"
        'comand()

        'sql = "INSERT INTO jan_dealer_payment_to_apply_BK SELECT * FROM jan_dealer_payment_to_apply "
        'comand()

        'sql = "select count(*) cnt from jan_dealer_payment2_bk where as_on>trunc(sysdate)"
        'adap = New OracleDataAdapter(sql, con)
        'ds = New DataSet
        'adap.Fill(ds, "RES")

        'If ds.Tables("res").Rows(0).Item("cnt") = 0 Then

        '    sql = "insert into jan_mail_system(MAIL_NO, MAIL_DATE, MAIL_PROGRAM, MAIL_FROM, MAIL_TO, MAIL_SUBJECT,MAIL_BODY, MAIL_SENT)"

        '    sql &= " values ( jan_test_seq.nextval,sysdate,'Dealer Payment Backup','feedback@janatics.co.in','it-dev7@janatics.co.in,it-dev@janatics.co.in','Dealer Payment Backup not taken today','Dealer Payment Backup not taken today',0)"
        '    comand()
        'End If


    End Sub
    Private Sub Excess_po_released()
        sql = "insert into jan_po_excess_release select ORGANIZATION_ID,INVENTORY_ITEM_ID,PO_TBR,PO_RELEASED,ITEM_COST,PERCENTAGE ,sysdate cr_dt from JAN_PO_JOB_TBR_MASTER_V "
        comand()
        sql = "insert into jan_job_excess_release select ORGANIZATION_ID,INVENTORY_ITEM_ID,PO_TBR,job_RELEASED,ITEM_COST,PERCENTAGE ,sysdate cr_dt from JAN_JOB_TBR_MASTER_V "
        comand()

        sql = "select org ""Org"",item_no ""Item no"" ,description ""Description"",po_tbr ""PO to be Released"",po_released ""Actual PO Released"",percentage ""Percentage Excess"" ,tot_excess_val ""Excess Value Released""  from (SELECT (select organization_code from org_organization_definitions where organization_id=a.organization_id)org,A.*, ROUND(((PO_RELEASED-PO_TBR)*ITEM_COST),2) TOT_EXCESS_VAL  FROM JAN_PO_JOB_TBR_MASTER_V A  order by org,item_no)"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Excess_po_released")

        sql = "select org ""Org"",item_no ""Item no"" ,description ""Description"",po_tbr ""JOB to be Released"",job_released ""Actual JOB Released"",percentage ""Percentage Excess"" ,tot_excess_val ""Excess Value Released""  from (SELECT (select organization_code from org_organization_definitions where organization_id=a.organization_id)org,A.*, ROUND(((job_RELEASED-PO_TBR)*ITEM_COST),2) TOT_EXCESS_VAL  FROM JAN_JOB_TBR_MASTER_V A  order by org,item_no)"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_content("Excess_job_released")
    End Sub
    Private Sub Regression_plan_Exception()

        'sql = "drop table jan_regr_compare1"
        'comand()

        'sql = "alter table jan_regr_compare2 rename to jan_regr_compare1"
        'comand()

        sql = "drop table jan_regr_compare3"
        comand()

        sql = "alter table jan_regr_compare4 rename to jan_regr_compare3"
        comand()

        sql = " create table  jan_regr_compare4 as select item_no,jan_orgcode(org_id)org,APR_TO_feb_PLAN,apr_to_feb_order,march_PLAN,march_order,level_4 from (SELECT A.*,nvl((SELECT SUM(FINAL_QTY) FROM JAN_ORG_DS_ALL WHERE MNYEAR IN ('042012','052012','062012','072012','082012','092012','102012','112012','122012','012013','022013') AND ITEM_ID=A.ITEM_ID AND ORG_ID=A.ORG_ID),0)APR_TO_feb_PLAN ,nvl((select sum(ordered_quantity) from jan_sales_any_tb2_1 where ordered_date>='01-apr-2012' and inventory_item_id=a.item_id and  organization_id=a.org_id and sdtmy in ('042012','052012','062012','072012','082012','092012','102012','112012','122012','012013','022013')),0)apr_to_feb_order,nvl((SELECT decode(sign(SUM(FINAL_QTY)),-1,0,SUM(FINAL_QTY)) FROM JAN_ORG_DS_ALL WHERE MNYEAR='032013' AND ITEM_ID=A.ITEM_ID AND ORG_ID=A.ORG_ID),0)march_PLAN,nvl((select sum(ordered_quantity) from jan_sales_any_tb2_1 where ordered_date>='01-apr-2012'and inventory_item_id=a.item_id and  organization_id=a.org_id and sdtmy='032013'),0)march_order,(SELECT level_4    FROM jan_planning_item_category  where inventory_item_id=a.item_id    AND organization_id  =a.org_id) LEVEL_4 FROM (SELECT DISTINCT ITEM_ID,ITEM_NO,ORG_ID FROM JAN_ORG_DS_ALL where org_id<>111)A /* where item_id=1050 */) where march_order>(decode(sign(APR_TO_feb_PLAN-apr_to_feb_order),1,(APR_TO_feb_PLAN-apr_to_feb_order),0)+march_PLAN)"
        comand()

        sql = "select org,item_no,apr_to_feb_plan,apr_to_feb_order,decode(sign(march_plan),-1,0,march_plan)march_plan,march_order,decode(level_4,'Standard','Standard','Non-Standard')Item_cat , NVL((select SUM(TRANSACTION_QUANTITY) from mtl_onhand_quantities where inventory_item_id=jan_itemno(a.item_no) and organization_id=jan_orgid(org) AND SUBINVENTORY_CODE IN ('FG Store','Staging','Spares','Service 1','BDA_Store','Slowmove','Nonmoving')),0)current_stock from  jan_regr_compare4 a order by org,item_no"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")

        mail_content("Org Exception")


        sql = "select a.*, NVL((select SUM(TRANSACTION_QUANTITY) from mtl_onhand_quantities where inventory_item_id=jan_itemno(a.item_no) and organization_id=jan_orgid(org) AND SUBINVENTORY_CODE IN ('FG Store','Staging','Spares','Service 1','BDA_Store','Slowmove','Nonmoving')),0)current_stock from (select org,item_no,apr_to_feb_plan,apr_to_feb_order,march_plan,march_order,decode(level_4,'Standard','Standard','Non-Standard')Item_cat from (select * from jan_regr_compare4 minus select * from jan_regr_compare3))a"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")
        mail_content("Todays Org Exception")

    End Sub
    Private Sub po_form_personalization_changes()

        ds = New DataSet
        sql = "SELECT DISTINCT function_name FROM fnd_form_custom_rules "
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "name")
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style></head>"

        S &= "<table width=90% class=tab align=center cellspacing=0 cellpadding=0 border=1>"
        S &= "<tr> <th align=center>Sl.No</th><th >Description</th><th >sequence</th><th>Last Update Date</th><th >Updated By</th><th >Enabled</th><th >Function Name</th><th >Responsible <br> Person in IT</th></tr>"

        form_per_cnt = 0

        For l = 0 To ds.Tables("name").Rows.Count - 1

            With ds.Tables("name").Rows(l)

                sql = "SELECT MAX(last_update_date)tab,(SELECT MAX(last_update_date) FROM fnd_form_custom_rules WHERE function_name=a.function_name)oracle FROM jan_po_form_personalization a WHERE function_name='" & .Item("function_name") & "' GROUP BY function_name"
                adap = New OracleDataAdapter(sql, con)
                If ds.Tables.Contains("dt") Then ds.Tables.Remove("dt")
                adap.Fill(ds, "dt")
                If ds.Tables("dt").Rows.Count > 0 Then

                    If ds.Tables("dt").Rows(0).Item("oracle") > ds.Tables("dt").Rows(0).Item("tab") Then


                        sql = "SELECT a.*,(select user_name from fnd_user where user_id=a.LAST_UPDATED_BY)user_name ,(select responsible_person from  JAN_FND_FORM_CUSTOM_RULES where function_name=a.function_name and rownum=1)responsible FROM fnd_form_custom_rules a  WHERE function_name='" & .Item("function_name") & "' and last_update_date>'" & Format(DateAdd(DateInterval.Day, 1, ds.Tables("dt").Rows(0).Item("tab")), "dd-MMM-yyyy") & "'"
                        adap = New OracleDataAdapter(sql, con)
                        If ds.Tables.Contains("result") Then ds.Tables.Remove("result")
                        adap.Fill(ds, "result")



                        For k = 0 To ds.Tables("result").Rows.Count - 1
                            With ds.Tables("result").Rows(k)

                                form_per_cnt += 1
                                S &= "<tr><td align=center>" & form_per_cnt & "</td><td >" & .Item("description") & "</td><td >" & .Item("sequence") & "</td><td>" & .Item("last_update_date") & "</td><td>" & .Item("user_name") & "</td><td >" & .Item("enabled") & "</td><td >" & .Item("function_name") & "</td><td >" & .Item("responsible") & "</td></tr>"

                            End With

                        Next
                        sql = "delete from  jan_po_form_personalization where function_name='" & .Item("function_name") & "'"
                        comand()

                        sql = "insert into jan_po_form_personalization (select * from fnd_form_custom_rules where function_name='" & .Item("function_name") & "')"
                        comand()
                    End If
                End If

            End With

        Next


        S &= "</table>"
        S &= "</html>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Form Personal.html"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
    End Sub
    Private Sub long_running_query()
        ds = New DataSet
        Dim dt As Date
        If Format(Date.Today, "ddd") = "Mon" Then
            dt = DateAdd(DateInterval.Day, -2, Date.Today)
        Else
            dt = DateAdd(DateInterval.Day, -1, Date.Today)
        End If
        sql = "SELECT DISTINCT sql_text,program,terminal FROM jan_oracle_longops WHERE TRUNC(creation_dt)='" & Format(dt, "dd-MMM-yyyy") & "' AND program IS NOT NULL "

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:navy;font-family:verdana;font-size:7pt}</style></head>"
        'S &= "<H4>Long Running Programs on " & Format(dt, "dd-MMM-yyyy") & "</h4>"
        S &= "<table width=80% class=tab align=center cellspacing=0 cellpadding=0 border=1>"
        S &= "<tr> <th align=center>Sl.No</th><th >Program</th><th >terminal</th><th>Query</th></tr>"

        For k = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(k)
                S &= "<tr> <td align=center>" & k + 1 & "</td><td align=left>" & .Item("program") & "</td> <td>" & .Item("terminal") & "</td><td>" & .Item("sql_text") & "</td></tr>"
            End With

        Next


        S &= "</table>"
        S &= "</html>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Long Running Queries.html"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

    End Sub
    Private Sub long_operation_mail_body()
        ds = New DataSet
        Dim dt As Date
        If Format(Date.Today, "ddd") = "Mon" Then
            dt = DateAdd(DateInterval.Day, -2, Date.Today)
        Else
            dt = DateAdd(DateInterval.Day, -1, Date.Today)
        End If
        sql = "SELECT DISTINCT program,COUNT(*)cnt FROM jan_oracle_longops WHERE TRUNC(creation_dt)='" & Format(dt, "dd-MMM-yyyy") & "' AND program IS NOT NULL group by program"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:navy;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<H4>Long Running Programs on " & Format(dt, "dd-MMM-yyyy") & "</h4>"
        S &= "<table width=50% class=tab  cellspacing=0 cellpadding=0>"
        S &= "<tr> <th align=center>Sl.No</th><th align=left>Program</th><th align=left>No.of time come under<br> Long Operation</th></tr>"

        For k = 0 To ds.Tables("result").Rows.Count - 1
            S &= "<tr> <td align=center>" & k + 1 & "</td><td align=left>" & ds.Tables("result").Rows(k).Item("program") & "</td> <td align=center>" & ds.Tables("result").Rows(k).Item("cnt") & "</td></tr>"
        Next
        S &= "<tr height=10px> <td align=center></td><td align=left></td></tr>"

        S &= "<br><br>"
        S &= "</table>"
        S &= "</html>"


    End Sub
    Private Sub component_rm_stock_alert()
        If Not Directory.Exists("C:\component stock out alert") Then
            Directory.CreateDirectory("C:\component stock out alert")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("C:\component stock out alert")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        For k = 104 To 109
            If k <> 105 Then
                ds = New DataSet
                sql = "SELECT jan_orgcode(organization_id)""Org"",component_no ""Item No"",description ""Description"",item_type ""Item Type"",tot_quantity ""jpq"",on_hand ""ON Hand"",oh_percent ""Available %"",inprocess_qty ""Inprocess Qty"",MAKE_BUY ""Make/Buy"",po_in_receiving ""PO in Receiving"",po_pending ""PO Pending"",job_pending ""Job Pending"",store_pending ""Store Pending"" FROM jan_component_rm_stock_out_v  WHERE oh_percent<40 AND organization_id=" & k & " ORDER BY MAKE_BUY,component_no"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds, "result")

                S = "<html>"
                S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:navy;font-family:verdana;font-size:7pt}</style></head>"
                S &= "<table width=80% align=center class=tab border=1 cellspacing=0 cellpadding=0>"
                S &= "<tr bgcolor=""#CCEEFF""> <th>Sl.No</th>"

                For l = 0 To ds.Tables("result").Columns.Count - 1
                    With ds.Tables("result").Columns(l)
                        S &= "<th>" & .ColumnName & "</th>"
                    End With
                Next
                S &= "</tr>"

                Dim align As String
                For l = 0 To ds.Tables("result").Rows.Count - 1

                    S &= "<tr><td>" & l + 1 & "</td>"
                    For m = 0 To ds.Tables("result").Columns.Count - 1
                        With ds.Tables("result").Rows(l)
                            If .Item(m).GetType.Name = "Decimal" Then align = "right" Else align = "left"
                            S &= "<td align=" & align & ">" & .Item(m) & "</td>"
                        End With
                    Next
                    S &= "</tr>"

                Next

                S &= "</table></html>"


                Dim objfso
                objfso = CreateObject("Scripting.FileSystemObject")
                X = "C:\component stock out alert\component_" & ds.Tables("result").Rows(l - 1).Item("Org") & ".html"
                If objfso.FileExists(X) Then
                    objfso.DeleteFile(X)
                End If
                Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(S)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()

            End If

        Next



    End Sub
    Private Sub booked_orders_without_sch_dt()

        ds = New DataSet
        sql = "SELECT jan_orgcode(SHIP_FROM_ORG_ID) ORG_ID, ordered_item,description,SCHEDULE_SHIP_DATE SCHEDULE_DATE, SUM(PEND_QTY) PEND_QTY FROM JAN_BMS_ORDER_PENDING_NEW_V A WHERE PEND_QTY>0 AND FLOW_STATUS_CODE = 'AWAITING_SHIPPING' AND BOOKED_DATE IS NOT NULL AND SCHEDULE_SHIP_DATE IS NULL GROUP BY SHIP_FROM_ORG_ID, ordered_item,description, SCHEDULE_SHIP_DATE,ORDERED_ITEM"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        rec_cnt = ds.Tables("result").Rows.Count


        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table width=80% align=center class=tab border=1 cellspacing=0 cellpadding=0>"
        S &= "<tr><th>Org</th><th>Ordered Item</th><th>Description</th><th>Schedule Date</th><th>Pending Quantity</th></tr>"

        For k = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(k)
                S &= "<tr><td>" & .Item("org_id") & "</td><td>" & .Item("ordered_item") & "</td><td >" & .Item("description") & "</td><td >" & .Item("SCHEDULE_DATE") & "</td><td  align=right>" & .Item("pend_qty") & "</td></tr>"
            End With
        Next
        S &= "</table></html>"


        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Booked without schedule.xls"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()

    End Sub
    Private Sub spl_pending()

        If Not Directory.Exists("C:\spl Pending") Then
            Directory.CreateDirectory("C:\spl Pending")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("C:\spl Pending")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If
        For k = 104 To 109
            If k <> 105 Then

                ds1 = New DataSet
                sql = "SELECT a.dr_no,trunc(dr_date)dr_date,org_name,rowtocol('SELECT distinct order_number FROM jan_DR_PENDING_PRODUCTS WHERE  ORG_ID='||a.org_id ||' and dr_no='||a.dr_no||'')order_no,rowtocol('SELECT distinct order_date FROM jan_DR_PENDING_PRODUCTS WHERE  ORG_ID='||a.org_id ||' AND dr_no='||a.dr_no||'')order_date,rowtocol('SELECT item_no||''-''||prod_pend_qty FROM jan_DR_PENDING_PRODUCTS WHERE  ORG_ID='||a.org_id ||' AND dr_no='||a.dr_no||'')pend FROM (SELECT DISTINCT dr_no,dr_date ,org_id,org_name FROM JAN_DR_PENDING_PRODUCTS WHERE  ORG_ID=" & k & " AND DR_NO IS NOT  NULL )a "
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "result")

                S = "<table border=0><tr><td align=center><font face=verdana size=2><b>SPL PENDING</b></td></tr></table>"


                S &= "<table border=1 cellspacing=0 cellpadding=5 width=80%><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>DR No</font></th><th><font face=verdana size=2>DR Date</font></th><th><font face=verdana size=2>Order No</font></th><th><font face=verdana size=2>Order Dt</font></th><th><font face=verdana size=2>Pending</font></th></tr>"
                j = 0
                For j = 0 To ds1.Tables("result").Rows.Count - 1
                    With ds1.Tables("result").Rows(j)
                        S &= "<tr style='color=blue'><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org_name") & "</font></td><td><font face=verdana size=2>" & .Item("dr_no") & "</font></td><td><font face=verdana size=2>" & .Item("dr_date") & "</font></td><td ><font face=verdana size=2>" & .Item("order_no") & "</font></td><td ><font face=verdana size=2>" & .Item("order_date") & "</font></td><td ><font face=verdana size=2>" & .Item("pend").ToString.Replace(",", "<br>") & "</font></td></tr>"
                    End With

                Next
                S &= "</table>"
            End If


            Dim FSTRM As New FileStream("C:\Spl Pending\SPL Pending_" & ds1.Tables("result").Rows(0).Item("org_name") & ".html", FileMode.Create, FileAccess.Write)
            Dim SW As StreamWriter = New StreamWriter(FSTRM)

            SW = New StreamWriter(FSTRM)
            SW.Write(S)
            FSTRM.Flush()
            SW.Flush()
            SW.Close()
            FSTRM.Close()

        Next



    End Sub
    Private Sub DR_Pending_Products()
        If Not Directory.Exists("C:\DR Pending") Then
            Directory.CreateDirectory("C:\DR Pending")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("C:\DR Pending")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        sql = "SELECT ORGANIZATION_CODE org,ITEM_NO,DESCRIPTION,REQUIREMENTS DR_REQUIREMENT,ON_HAND,(REQUIREMENTS-ON_HAND) SHORTAGE,PO_IN_RECEIVING, WIP_QTY, PO_QTY  FROM JAN_DR_SHORTAGE_VIEW WHERE (REQUIREMENTS-ON_HAND)>0 AND ITEM_TYPE='FG' AND ORGANIZATION_ID=110 order by item_no"
        adap = New OracleDataAdapter(sql, con)
        ds1 = New DataSet
        adap.Fill(ds1, "RESULT")


        sql = "SELECT ORGANIZATION_CODE org,ITEM_NO,DESCRIPTION,REQUIREMENTS DR_REQUIREMENT,ON_HAND,(REQUIREMENTS-ON_HAND) SHORTAGE,PO_IN_RECEIVING, WIP_QTY, PO_QTY, ITEM_TYPE FROM JAN_DR_SHORTAGE_VIEW WHERE (REQUIREMENTS-ON_HAND)>0 AND ITEM_TYPE IN ('COMP','RM','SA') AND UPPER(DESCRIPTION) NOT LIKE '%STICKER%'  AND ORGANIZATION_ID=110  order by item_no"
        adap = New OracleDataAdapter(sql, con)
        ds2 = New DataSet
        adap.Fill(ds2, "RESULT")


        S = "<table border=0><tr><td><font face=verdana size=2><b>CONSOLIDATED DR PENDING</b></td></tr></table>"


        S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>DR Requirement</font></th><th><font face=verdana size=2>ON hand</font></th><th><font face=verdana size=2>Shortage</font></th><th><font face=verdana size=2>PO in Receiving</font></th><th><font face=verdana size=2>WIP Qty</font></th><th><font face=verdana size=2>PO qty</font></th></tr>"
        j = 0
        For j = 0 To ds1.Tables("result").Rows.Count - 1
            With ds1.Tables("result").Rows(j)
                S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & Math.Round(.Item("DR_REQUIREMENT"), 3) & "</font></td><td align=right><font face=verdana size=2>" & .Item("ON_HAND") & "</font></td><td align=right><font face=verdana size=2>" & .Item("shortage") & "</font></td><td align=right><font face=verdana size=2>" & .Item("PO_IN_RECEIVING") & "</font></td><td><font face=verdana size=2>" & .Item("WIP_QTY") & "</font></td><td align=right><font face=verdana size=2>" & .Item("PO_qty") & "</font></td></tr>"
            End With

        Next


        S &= "</table><br><br><table border=0><tr><td><font face=verdana size=2><b>CONSOLIDATED DR COMPONENT SHORTAGE</b></td></tr></table>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>DR Requirement</font></th><th><font face=verdana size=2>ON hand</font></th><th><font face=verdana size=2>Shortage</font></th><th><font face=verdana size=2>PO in Receiving</font></th><th><font face=verdana size=2>WIP Qty</font></th><th><font face=verdana size=2>PO qty</font></th><th><font face=verdana size=2>Item Type</font></th></tr>"
        j = 0
        For j = 0 To ds2.Tables("result").Rows.Count - 1
            With ds2.Tables("result").Rows(j)

                S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & Math.Round(.Item("DR_REQUIREMENT"), 3) & "</font></td><td align=right><font face=verdana size=2>" & .Item("ON_HAND") & "</font></td><td align=right><font face=verdana size=2>" & .Item("shortage") & "</font></td><td align=right><font face=verdana size=2>" & .Item("PO_IN_RECEIVING") & "</font></td><td><font face=verdana size=2>" & .Item("WIP_QTY") & "</font></td><td align=right><font face=verdana size=2>" & .Item("PO_qty") & "</font></td><td><font face=verdana size=2>" & .Item("item_type") & "</font></td></tr>"
            End With
        Next
        S &= "</TABLE>"
        If ds1.Tables("result").Rows.Count > 0 Then
            Dim FSTRM As New FileStream("C:\DR Pending\DR Pending_" & ds1.Tables("result").Rows(0).Item("org") & ".xls", FileMode.Create, FileAccess.Write)
            Dim SW As StreamWriter = New StreamWriter(FSTRM)

            SW = New StreamWriter(FSTRM)
            SW.Write(S)
            FSTRM.Flush()
            SW.Flush()
            SW.Close()
            FSTRM.Close()
        End If
    End Sub
    Private Sub tobe_release_body()
        sql = "SELECT organization_code org,NVL((SELECT COUNT(DISTINCT item_no) FROM jan_so_requirement_master_new WHERE PO_TORELE>0 AND MAKE_BUY='Buy' AND UPPER(DESCRIPTION) NOT LIKE '%STICKER%'AND UPPER(DESCRIPTION) NOT LIKE '%MAGIC%SEAL%COVER%'  AND S_ORG_ID IS NULL  and sor_dt<=trunc(sysdate) AND organization_id=a.organization_id),0)total_products FROM org_organization_definitions a WHERE organization_id IN (104,106,107,108,109)"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")

        sql = "SELECT organization_code org,NVL((SELECT COUNT(DISTINCT item_no) FROM jan_so_requirement_master_new WHERE job_torele > 0 AND item_type NOT IN ('FG', 'SA') AND make_buy = 'Make' AND UPPER (description) NOT LIKE '%STICKER%' AND UPPER (description) NOT LIKE '%MAGIC%SEAL%COVER%' AND s_org_id IS NULL AND sor_dt <= TRUNC (SYSDATE) AND organization_id=a.organization_id),0)total_products FROM org_organization_definitions a WHERE organization_id IN (104,106,107,108,109)"
        adap = New OracleDataAdapter(sql, con)
        ds1 = New DataSet
        adap.Fill(ds1, "result")
        S = "<h4 align=left><font face=verdana size=2>To Be Released Status</font></h4>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=400><tr><th><font face=verdana size=2>&nbsp;</font></th><th><font face=verdana size=2>I01</font></th><th><font face=verdana size=2>I02</font></th><th><font face=verdana size=2>I03</font></th><th><font face=verdana size=2>I04</font></th><th><font face=verdana size=2>I05</font></th></tr>"
        S &= "<tr><th align=left><font face=verdana size=2>PO</font></th>"
        For k = 0 To 4
            S &= "<td align=right><font face=verdana size=2>" & ds.Tables("result").Rows(k).Item("total_products") & "</font></td>"
        Next

        S &= "</tr><tr><th align=left><font face=verdana size=2>Job</font></th>"
        For k = 0 To 4
            S &= "<td align=right><font face=verdana size=2>" & ds1.Tables("result").Rows(k).Item("total_products") & "</font></td>"
        Next
        S &= "</tr>"
        S &= "</table>"
        S &= "<br>"
        S &= "<p>This is a computer generated email. Please do not Reply."
    End Sub
    Private Sub tobe_released()
        If Not Directory.Exists("C:\Tobe Released") Then
            Directory.CreateDirectory("C:\Tobe Released")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("C:\Tobe Released")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If
        For k = 104 To 109
            If k <> 105 Then
                sql = "SELECT AA.org,AA.ITEM_NO,AA.DESCRIPTION,AA.TBR_QTY, AA.UOM,ceil((SELECT TRUNC(SYSDATE)-MIN(SOR_DT) FROM jan_so_requirement_master_new WHERE  ORGANIZATION_ID=AA.ORGANIZATION_ID AND PO_TORELE>0 AND SOR_DT<=TRUNC(SYSDATE)  AND ITEM_NO=AA.ITEM_NO))DAYS ,NVL((SELECT ROUND (SUM (po_qty), 3) FROM jan_po_tobe_followed_tab WHERE organization_id=111 AND item_no=aa.item_no  ),0)I07_po,"

                sql += "(select DATE_UPTO from JAN_ITEM_NOT_REQUIRED where ORGANIZATION_ID=AA.ORGANIZATION_ID and ITEM_NO=AA.ITEM_NO and TRUNC(DATE_UPTO)>=TRUNC(sysdate))HOLD_UPTO,replace(ROWTOCOL('(SELECT DISTINCT REASON FROM JAN_PO_TBR_HEADER H WHERE (ITEM_NO,ORGANIZATION_ID) IN (SELECT ITEM_NO,ORGANIZATION_ID FROM JAN_ITEM_NOT_REQUIRED WHERE TRUNC(DATE_UPTO)>=TRUNC(sysdate)) AND TRUNC(HOLD_DATE)=(SELECT MAX(TRUNC(HOLD_DATE)) FROM JAN_PO_TBR_HEADER WHERE ITEM_NO=H.ITEM_NO AND ORGANIZATION_ID=H.ORGANIZATION_ID) AND ITEM_NO='''||AA.ITEM_NO||''' AND ORGANIZATION_ID='||AA.ORGANIZATION_ID||')'),',-,','')REASON FROM (SELECT jan_orgcode(ORGANIZATION_ID)org,ORGANIZATION_ID,ITEM_NO,DESCRIPTION, ROUND(SUM(PO_TORELE),3) TBR_QTY, UOM FROM JAN_SO_REQUIREMENT_MASTER_NEW  WHERE PO_TORELE>0 AND MAKE_BUY='Buy'AND UPPER(DESCRIPTION) NOT LIKE '%STICKER%' AND UPPER(DESCRIPTION) NOT LIKE '%MAGIC%SEAL%COVER%' AND ORGANIZATION_ID=" & k & " AND S_ORG_ID IS NULL  AND SOR_DT<=TRUNC(SYSDATE) GROUP BY ORGANIZATION_ID,ITEM_NO, UOM,DESCRIPTION) AA  ORDER BY item_no"



                adap = New OracleDataAdapter(sql, con)
                ds1 = New DataSet
                adap.Fill(ds1, "RESULT")

                sql = "SELECT jan_orgcode(AA.ORGANIZATION_ID)org,AA.ITEM_NO,(SELECT DESCRIPTION FROM MTL_SYSTEM_ITEMS WHERE ORGANIZATION_ID=AA.ORGANIZATION_ID AND SEGMENT1=AA.ITEM_NO) DESCRIPTION,AA.TBR_QTY, AA.UOM,ceil((SELECT TRUNC(SYSDATE)-MIN(SOR_DT) FROM jan_so_requirement_master_new WHERE  ORGANIZATION_ID=AA.ORGANIZATION_ID AND JOB_TORELE>0 AND SOR_DT<=TRUNC(SYSDATE)  AND ITEM_NO=AA.ITEM_NO))DAYS ,rowtocol('select distinct HOLD_DT||'':''||HOLD_REASON from JAN_OUTWARD_HOLD where ITEM_ID='||JAN_ITEMNO(AA.ITEM_NO)||' AND TRUNC(HOLD_DT)>='''||TRUNC(SYSDATE)||''' AND ORG_ID='||AA.ORGANIZATION_ID||'')HOLD_REASON FROM (SELECT ORGANIZATION_ID,ITEM_NO, round(SUM(JOB_TORELE),3) TBR_QTY, UOM FROM JAN_SO_REQUIREMENT_MASTER_NEW WHERE JOB_TORELE>0 AND ITEM_TYPE NOT IN ('FG','SA') AND MAKE_BUY='Make' AND UPPER(DESCRIPTION) NOT LIKE '%STICKER%' AND UPPER(DESCRIPTION) NOT LIKE '%MAGIC%SEAL%COVER%'AND ORGANIZATION_ID=" & k & " AND S_ORG_ID IS NULL  AND SOR_DT<=TRUNC(SYSDATE) GROUP BY ORGANIZATION_ID,ITEM_NO, UOM) AA ORDER BY item_no"
                adap = New OracleDataAdapter(sql, con)
                ds2 = New DataSet
                adap.Fill(ds2, "RESULT")


                S = "<table border=0><tr><td><font face=verdana size=2><b>PO To Be Released</b></td></tr></table>"
                S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>Tobe Release Qty</font></th><th><font face=verdana size=2>UOM</font></th><th><font face=verdana size=2>No.of Days Pending</font></th><th><font face=verdana size=2>I07 PO</font></th><th><font face=verdana size=2>Hold UpTo</font></th><th><font face=verdana size=2>Reason</font></th></tr>"
                j = 0
                For j = 0 To ds1.Tables("result").Rows.Count - 1
                    With ds1.Tables("result").Rows(j)
                        S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & Math.Round(.Item("tbr_qty"), 3) & "</font></td><td><font face=verdana size=2>" & .Item("uom") & "</font></td><td align=center><font face=verdana size=2>" & .Item("days") & "</font></td><td align=right><font face=verdana size=2>" & .Item("I07_po") & "</font></td>"

                        If IsDBNull(.Item("HOLD_UPTO")) Then
                            S &= "<td><font face=verdana size=2>&nbsp;</font></td>"
                        Else
                            S &= "<td><font face=verdana size=2>" & .Item("HOLD_UPTO") & "</font></td>"
                        End If

                        If IsDBNull(.Item("reason")) Then
                            S &= "<td><font face=verdana size=2>&nbsp;</font></td>"
                        Else
                            S &= "<td><font face=verdana size=2>" & .Item("reason") & "</font></td>"
                        End If


                    End With

                Next


                S &= "</table><br><br><table border=0><tr><td><font face=verdana size=2><b>Job To Be Released</b></td></tr></table>"
                S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>Tobe Release Qty</font></th><th><font face=verdana size=2>UOM</font></th><th><font face=verdana size=2>No.of Days Pending</font></th><th><font face=verdana size=2>Hold Reason</font></th></tr>"
                j = 0
                For j = 0 To ds2.Tables("result").Rows.Count - 1
                    With ds2.Tables("result").Rows(j)
                        S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & Math.Round(.Item("tbr_qty"), 3) & "</font></td><td><font face=verdana size=2>" & .Item("uom") & "</font></td><td align=center><font face=verdana size=2>" & .Item("days") & "</font></td>"

                        If IsDBNull(.Item("HOLD_REASON")) Then
                            S &= "<td >&nbsp;</td>"
                        Else

                            S &= "<td align=center><font face=verdana size=2>" & .Item("HOLD_REASON") & "</font></td>"
                        End If
                        S &= " </tr>"
                    End With
                Next
                S &= "</TABLE>"
                Dim rec_cnt As Integer = 0
                rec_cnt = ds1.Tables("result").Rows.Count + ds2.Tables("result").Rows.Count
                Dim file_name As String = ""
                If ds1.Tables("result").Rows.Count > 0 Then
                    file_name = ds1.Tables("result").Rows(0).Item("org")
                ElseIf ds2.Tables("result").Rows.Count > 0 Then
                    file_name = ds2.Tables("result").Rows(0).Item("org")
                End If
                If rec_cnt <> 0 Then
                    Dim FSTRM As New FileStream("C:\Tobe Released\Tobe Released_" & file_name & ".html", FileMode.Create, FileAccess.Write)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)

                    SW = New StreamWriter(FSTRM)
                    SW.Write(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()
                End If

            End If
        Next
    End Sub
    Private Sub Stock_Excess_Alert()
        Dim excess_qty, org_day As Integer
        excess_qty = 0
        org_day = 0
        file_no = 0
        days = 0
        average = 0
        stock = 0
        stock_days = 0
        sl_no = 0
        ds = New DataSet
        sql = "SELECT ORDERed_item,organization_id,jan_orgcode(organization_id)org,AVERAGE,NVL((select (fg_stores+staging+spares+service+bda_store-reserved_qty) from jan_rg1_prod where INVENTORY_ITEM_ID=BB.INVENTORY_ITEM_ID),0)un_alloted,(select description from mtl_system_items where INVENTORY_ITEM_ID=BB.INVENTORY_ITEM_ID and ORGANIZATION_ID=105)description FROM(SELECT AA.*,ROUND(qty/COUNT)average,(SELECT SUM(quantity_invoiced) FROM JAN_IT.jan_sales_any_1_copy WHERE  INVENTORY_ITEM_ID=AA.INVENTORY_ITEM_ID AND organization_id=aa.organization_id AND TRX_DATE>=TRUNC (TRUNC (SYSDATE, 'MM') - 90,'MM') AND trx_date<'" & Format(last_date, "dd-MMM-yyyy") & "') LAST_3_MNTH_QTY,(SELECT DECODE(clp,0,sclp,clp) FROM jan_clp_pricelist_TABLE WHERE INVENTORY_ITEM_ID=aa.INVENTORY_ITEM_ID)clp FROM (SELECT   ordered_item, organization_id, SUM (qty) qty,COUNT (*) COUNT ,INVENTORY_ITEM_ID FROM (SELECT   ordered_item, my, organization_id, SUM (quantity_invoiced) qty,INVENTORY_ITEM_ID  FROM (SELECT a.*,(SELECT item_type FROM mtl_system_items        WHERE organization_id =a.organization_id AND inventory_item_id =a.inventory_item_id) item_type FROM JAN_IT.jan_sales_any_1_copy a  where organization_id in (464,444,484,504,524) AND trx_date >= '" & Format(first_date, "dd-MMM-yyyy") & "'  AND trx_date < '" & Format(last_date, "dd-MMM-yyyy") & "' ) WHERE item_type = 'FG'   GROUP BY ordered_item, my, organization_id,INVENTORY_ITEM_ID )   GROUP BY ordered_item, organization_id,INVENTORY_ITEM_ID ) AA)BB WHERE LAST_3_MNTH_QTY IS NOT NULL and clp is not null AND  average>=50 ORDER BY organization_id,ordered_item"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = ""
        S = "<html>"
        S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
        S &= "<h6><font size=1 face=Verdana >Stock Excess Alert</h6>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Organization</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Excess<br>Stock Qty</TD><TD align=center><u><font size=1 face=Verdana>Avg Sale Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Sale Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana>FG Stock<br>(nos)</u></TD></tr>"
        For k = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(k)
                average = .Item("average")
                days = average / 26
                If .Item("un_alloted") > 0 Then
                    stock = .Item("un_alloted")
                    stock_days = stock / days
                Else
                    stock = 0
                    stock_days = 0
                End If
                Select Case .Item("org")
                    Case "I22"
                        org_day = 30
                    Case "I23"
                        org_day = 20
                    Case "I24"
                        org_day = 15
                    Case "I25"
                        org_day = 15
                End Select
                If stock_days > org_day Then
                    sl_no += 1


                    S &= "<tr><td>" & sl_no & "</td><td>" & .Item("org") & "</td><td>" & .Item("ordered_item") & "</td><td>" & .Item("description") & "</td><td align=right>" & Math.Round(stock - (org_day * days)) & "</td><td align=right>" & average & "</td><td align=right>" & FormatNumber(days, 2) & "</td><td align=right>" & stock & "</td></tr>"
                End If
            End With
        Next
        S &= "</TABLE>"
        S &= "</html>"
        Dim objfso1
        objfso1 = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\stock Excess Alert.html"
        If objfso1.FileExists(X) Then
            objfso1.DeleteFile(X)
        End If
        Dim FSTRM1 As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)

        SW1.WriteLine(S)
        FSTRM1.Flush()
        SW1.Flush()
        SW1.Close()
        FSTRM1.Close()
    End Sub
    Private Sub mail_body()
        sql = "select * from jan_product_alert_tab order by org"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "result")

        sql = "select * from jan_component_alert_tab order by org"
        adap = New OracleDataAdapter(sql, con)
        ds1 = New DataSet
        adap.Fill(ds1, "result")
        S = "<h4 align=left><font face=verdana size=2>This alert is based on</font></h4><h4 align=left><font face=verdana size=2>a) M2O pending upto current date and</font></h4><h4 align=left><font face=verdana size=2>b) Weekly Plan Pending scheduled upto current date+10 days</font></h4>"
        S &= "<table border=1 cellspacing=0 cellpadding=5 width=400><tr><th><font face=verdana size=2>&nbsp;</font></th><th><font face=verdana size=2>I01</font></th><th><font face=verdana size=2>I02</font></th><th><font face=verdana size=2>I03</font></th><th><font face=verdana size=2>I04</font></th><th><font face=verdana size=2>I05</font></th></tr>"
        S &= "<tr><th align=left><font face=verdana size=2>Products</font></th>"
        For k = 0 To 4
            S &= "<td align=right><font face=verdana size=2>" & ds.Tables("result").Rows(k).Item("total_products") & "</font></td>"
        Next

        S &= "</tr><tr><th align=left><font face=verdana size=2>Components</font></th>"
        For k = 0 To 4
            S &= "<td align=right><font face=verdana size=2>" & ds1.Tables("result").Rows(k).Item("total_component") & "</font></td>"
        Next
        S &= "</tr>"
        S &= "</table>"
        S &= "<br>"
        S &= "<p>This is a computer generated email. Please do not Reply."
    End Sub
    Private Sub M2O_Vs_Weekly_Plan_Alert()
        If Not Directory.Exists("D:\M2o alert") Then
            Directory.CreateDirectory("D:\M2o alert")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\M2o alert")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If

        For k = 104 To 109
            If k <> 105 Then
                sql = "SELECT JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_NO,DESCRIPTION,M2O_PENDING,WEEKLY_SCHEDULE,M2O_PENDING-WEEKLY_SCHEDULE alert_qty FROM jan_product_alert WHERE ORGANIZATION_ID=" & k & ""
                adap = New OracleDataAdapter(sql, con)
                ds1 = New DataSet
                adap.Fill(ds1, "RESULT")

                sql = "SELECT JAN_ORGCODE(ORGANIZATION_ID)ORG,ITEM_NO,DESCRIPTION,M2O_PENDING,WEEKLY_SCHEDULE ,M2O_PENDING-WEEKLY_SCHEDULE alert_qty FROM jan_component_alert WHERE ORGANIZATION_ID=" & k & ""
                adap = New OracleDataAdapter(sql, con)
                ds2 = New DataSet
                adap.Fill(ds2, "RESULT")

                S = "<table border=0><tr><td><font face=verdana size=2><b>M2O Vs Weekly Plan - Alert (Product)</b></td></tr></table>"
                S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>M2O Pending</font></th><th><font face=verdana size=2>Weekly Schedule</font></th><th><font face=verdana size=2>Alert Qty</font></th></tr>"
                j = 0
                For j = 0 To ds1.Tables("result").Rows.Count - 1
                    With ds1.Tables("result").Rows(j)
                        S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & .Item("M2o_Pending") & "</font></td><td align=right><font face=verdana size=2>" & .Item("Weekly_Schedule") & "</font></td><td align=right><font face=verdana size=2>" & .Item("alert_qty") & "</font></td></tr>"
                    End With
                Next
                S &= "</table><br><br><table border=0><tr><td><font face=verdana size=2><b>M2O Vs Weekly Plan - Alert (Components for the Above Products)</b></td></tr></table>"
                S &= "<table border=1 cellspacing=0 cellpadding=5 width=700><tr><th><font face=verdana size=2>Sno</font></th><th><font face=verdana size=2>Org</font></th><th><font face=verdana size=2>Item No</font></th><th><font face=verdana size=2>Description</font></th><th><font face=verdana size=2>M2O Pending</font></th><th><font face=verdana size=2>Weekly Schedule</font></th><th><font face=verdana size=2>Alert Qty</font></th></tr>"
                j = 0
                For j = 0 To ds2.Tables("result").Rows.Count - 1
                    With ds2.Tables("result").Rows(j)
                        S &= "<tr><td><font face=verdana size=2>" & j + 1 & "</font></td><td><font face=verdana size=2>" & .Item("org") & "</font></td><td><font face=verdana size=2>" & .Item("Item_No") & "</font></td><td><font face=verdana size=2>" & .Item("Description") & "</font></td><td align=right><font face=verdana size=2>" & .Item("M2o_Pending") & "</font></td><td align=right><font face=verdana size=2>" & .Item("Weekly_Schedule") & "</font></td><td align=right><font face=verdana size=2>" & .Item("alert_qty") & "</font></td></tr>"
                    End With
                Next
                S &= "</TABLE>"
                Dim FSTRM As New FileStream("D:\M2o alert\Alert_" & ds1.Tables("result").Rows(0).Item("org") & ".html", FileMode.Create, FileAccess.Write)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(S)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()

            End If
        Next
    End Sub
    Private Sub attendance_mail()

        S = ""
        S = "<html>"
        S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
        S &= "<h6 align=center><u><font size=1 face=Verdana color=blue><b>Attendance Status </u></font></h6>"
        S &= "<h5><font size=1 face=Verdana align=left color=red><b>Department  :" & dept.Tables("dept_name").Rows(dept_no).Item("dept") & " &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Date :" & Format(attendance_dt, "dd-MMM-yyyy") & "</font> </h5>"

        ds = New DataSet
        sql = "SELECT DISTINCT status_id,rowtocol('select status_name from jan_attn_status where status_id='||a.status_id||'')status_name FROM jan_attn_status a  ORDER BY status_id"
        adap = New OracleDataAdapter(sql, con)
        If ds.Tables.Contains("status") Then
            ds.Tables.Remove("status")
        End If
        adap.Fill(ds, "status")

        For d = 0 To ds.Tables("status").Rows.Count - 1
            S &= "<h6><font size=1 face=Verdana color=green><b><u>" & ds.Tables("status").Rows(d).Item("status_name") & ":- </u></font></h6>"
            attendance_header()

            sql = "select  CARD_IN_DATE,EMPLOYEE_NUMBER,LAST_NAME NAME,DEPT_NAME,actual_hrs worked_hrs,STATUS from jan_daily_attn_v a where dept_name='" & dept.Tables("dept_name").Rows(dept_no).Item("dept") & "' and status in ('" & ds.Tables("status").Rows(d).Item("status_name").ToString.Replace(",", "','") & "') and card_in_date='" & Format(attendance_dt, "dd-MMM-yyyy") & "' order by EMPLOYEE_NUMBER"
            adap = New OracleDataAdapter(sql, con)
            If ds.Tables.Contains("result") Then
                ds.Tables.Remove("result")
            End If
            adap.Fill(ds, "result")
            If ds.Tables("result").Rows.Count > 0 Then
                For k = 0 To ds.Tables("result").Rows.Count - 1
                    attendance_status()
                Next
                S &= "</table>"
            Else
                attendance_status_novalue()
            End If

        Next

        'Dim objfso
        'objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\attendance_Reg" & dept_no & ".html"
        'If objfso.FileExists(X) Then
        '    objfso.DeleteFile(X)
        'End If
        Dim FSTRM1 As FileStream = New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)
        SW1.WriteLine(S)
        FSTRM1.Flush()
        SW1.Flush()
        SW1.Close()
        FSTRM1.Close()
    End Sub
    Private Sub attendance_status_novalue()
        S &= "<tr><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD><TD align=center><font size=1 face=Verdana>&nbsp;</TD></tr>"
        S &= "</table>"
    End Sub
    Private Sub attendance_status()
        S &= "<tr><TD align=center><font size=1 face=Verdana color=darkblue>" & k + 1 & "</TD><TD align=left><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("CARD_IN_DATE") & "</TD><TD align=center><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("EMPLOYEE_NUMBER") & "</TD><TD align=left><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("NAME") & "</TD><TD align=left><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("DEPT_NAME") & "</TD><TD align=left><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("worked_hrs") & "</TD><TD align=left><font size=1 face=Verdana color=darkblue>"
        sql = "select iotime from jan_hrms_io_trans where iodate='" & Format(attendance_dt, "dd-MMM-yyyy") & "' and empcode='" & ds.Tables("result").Rows(k).Item("EMPLOYEE_NUMBER") & "' order by iotime"

        adap = New OracleDataAdapter(sql, con)
        If ds.Tables.Contains("time") Then
            ds.Tables.Remove("time")
        End If
        adap.Fill(ds, "time")
        Dim z As Integer
        For z = 0 To ds.Tables("time").Rows.Count - 1
            S &= "" & ds.Tables("time").Rows(z).Item("iotime") & ""
            If z Mod 2 = 0 Then S &= "(IN)" Else S &= "(OUT)"
            S &= "<br>"
        Next
        S &= "</TD><TD align=left><font size=1 face=Verdana color=darkblue>" & ds.Tables("result").Rows(k).Item("STATUS") & "</TD></font></tr>"
    End Sub
    Private Sub attendance_header()
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><font size=1 face=Verdana color=firebrick>Sl.No.</TD><TD align=center><font size=1 face=Verdana color=firebrick>Date</TD><TD align=center><font size=1 face=Verdana color=firebrick>Employee No</TD><TD align=center><font size=1 face=Verdana color=firebrick>Name</TD><TD align=center><font size=1 face=Verdana color=firebrick>Department</TD><TD align=center><font size=1 face=Verdana color=firebrick>Available Hrs</TD><TD align=center><font size=1 face=Verdana color=firebrick>I/O Time</TD><TD align=center><font size=1 face=Verdana color=firebrick>Status</TD></font></tr>"
    End Sub
    Private Sub Rtv_pending()
        ds = New DataSet
        sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,PONO,PODT,VENDOR_NAME,ITEM_NO,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_pur_listing a where  receipt_date >='01-jan-2011' and receipt_date < trunc(sysdate) and quantity_received=qty_dlyd and qty_rejd<>0 and vendor_return<qty_rejd  and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID) ,DIVISION"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "receipt")
        sl_no = 0
        S = ""
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=16 align=center><b> PURCHASE - RTV PENDING FROM 01-jan-2011 TO " & Format(CDate(DateAdd(DateInterval.Day, -1, Date.Today)), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>DIVISION</td><td>RECEIPT-NO</td><td>RECEIPT_DT</td><td>PONO</td><td>PODT</td><td>VENDOR</td><td>PART NO</td><td>DESCRIPTION</td><td>INS_DT</td><td>DEL_DT</td><td>RECD</td><td>APPD</td><td>REJ</td><td>DELIVERED</td></tr>"
        sl_no = 0
        For k = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            With ds.Tables("RECEIPT").Rows(k)
                If k > 0 Then
                    If ds.Tables("receipt").Rows(k - 1).Item("org") <> ds.Tables("receipt").Rows(k).Item("org") Then
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                    End If
                End If
                sl_no += 1
                S &= "<TR><TD align=center> " & sl_no & "</TD><TD align=left>" & .Item("ORG") & "</TD>"
                S &= "<TD align=left>" & .Item("DIVISION") & "</TD>"
                S &= "<TD align=left>" & .Item("RECEIPT_NUM") & "</TD>"
                S &= "<TD align=left>" & .Item("RECEIPT_DATE") & "</TD>"
                S &= "<TD align=left>" & .Item("PONO") & "</TD>"
                S &= "<TD align=left>" & .Item("PODT") & "</TD>"
                S &= "<TD align=left>" & .Item("VENDOR_NAME") & "</TD>"
                S &= "<TD align=left>" & .Item("ITEM_NO") & "</TD>"
                S &= "<TD align=left>" & .Item("ITEM_DESCRIPTION") & "</TD>"
                S &= "<TD align=left>" & .Item("INSP_DT") & "</TD>"
                S &= "<TD align=left>" & .Item("DELIVERED_DT") & "</TD>"
                S &= "<TD align=right>" & .Item("QUANTITY_RECEIVED") & "</TD>"
                S &= "<TD align=right>" & .Item("QTY_APPD") & "</TD>"
                S &= "<TD align=right>" & .Item("QTY_REJD") & "</TD>"
                S &= "<TD align=right>" & .Item("QTY_DLYD") & "</TD></TR>"
            End With
        Next
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Purchase - Rtv pending.xls"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
    End Sub
    Private Sub to_address_bind()
        ds1 = New DataSet
        If ds5.Tables("result").Rows(i).Item("schedule_id") = 7 Then
            'sql = "SELECT email1,nvl(email2,'-')email2,nvl(email3,'-')email3 from jan_attn_dept_email where dept_id='" & dept.Tables("dept_name").Rows(dept_no).Item("dept_id") & "'"
            'adap = New OracleDataAdapter(sql, con)
            'adap.Fill(ds1, "address")
            'For j = 0 To ds1.Tables("address").Columns.Count - 1
            '    If ds1.Tables("address").Rows(0).Item(j) <> "-" Then mailer.To.Add(ds1.Tables("address").Rows(0).Item(j))
            'Next
            ' mailer.To.Add("ramesh-mktg" & tail & "")

        Else
            sql = "SELECT to_address FROM jan_mailer_address WHERE schedule_id=" & ds5.Tables("result").Rows(i).Item("schedule_id") & "  and  to_address is not null"
            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds1, "address")
            For j = 0 To ds1.Tables("address").Rows.Count - 1
                mailer.To.Add(ds1.Tables("address").Rows(j).Item("to_address") & tail)
            Next

        End If
    End Sub
    Private Sub cc_address_bind()
        If ds5.Tables("result").Rows(i).Item("schedule_id") = 7 Then
            mailer.CC.Add("it-dev7" & tail & "")
        Else
            ds1 = New DataSet
            sql = "SELECT cc_address FROM jan_mailer_address WHERE schedule_id=" & ds5.Tables("result").Rows(i).Item("schedule_id") & "  and cc_address is not null"
            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds1, "address")

            For j = 0 To ds1.Tables("address").Rows.Count - 1
                mailer.CC.Add(ds1.Tables("address").Rows(j).Item("cc_address") & tail)
            Next
        End If
    End Sub
    Private Sub job_store_pending()
        ds = New DataSet
        sql = "SELECT (SELECT organization_code FROM org_organization_definitions WHERE organization_id=a.organization_id) org,job_no,job_dt,item_no,rev,description,opn_seq,lot_move quantity,TRUNC(comp_dt)comp_dt,res_code,ITEM_TYPE,resourc,osp_isp inhouse_osp,assy_target,(SELECT category FROM jan_counting_category WHERE a.item_cost BETWEEN from_value AND to_value AND organization_id=a.organization_id)category,NVL((SELECT location FROM jan_store_location_view WHERE inventory_item_id=a.inventory_item_id AND organization_id=a.organization_id AND ROWNUM=1),'-')location   FROM jan_final_operations a WHERE  comp_dt>='01-apr-2009' and comp_dt<'" & Format(DateAdd(DateInterval.Day, -1, today_date), "dd/MMM/yyyy") & "' order by organization_id  asc"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "receipt")
        sl_no = 0
        S = ""
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=17 align=center><b>JOB STORE PENDING FROM 01-apr-2010 TO " & Format(DateAdd(DateInterval.Day, -1, today_date), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>JOB NO</td><td>JOB DATE</td><td>ITEM NO</td><td>REV</td><td>DESCRIPTION</td><td>OPEN SEQ</td><td>QUANTITY</td><td>COMP DT</td><td>RES CODE</td><td>ITEM TYPE</td><td>RESOURCE</td><td>INHOUSE_OSP</td><td>ASSY_TARGET</td><td>CATEGORY</td><td>LOCATION</td></tr>"
        For k = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            With ds.Tables("receipt")
                sl_no += 1
                If k = 0 Then
                    S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(k).Item("org") & "</td><td>" & .Rows(k).Item("job_no") & "</td><td align=left>" & .Rows(k).Item("job_dt") & "</td><td align=left>" & .Rows(k).Item("item_no") & "</td><td>" & .Rows(k).Item("rev") & "</td><td>" & .Rows(k).Item("description") & "</td><td>" & .Rows(k).Item("opn_seq") & "</td><td>" & .Rows(k).Item("quantity") & "</td><td>" & .Rows(k).Item("comp_dt") & "</td><td>" & .Rows(k).Item("res_code") & "</td><td>" & .Rows(k).Item("item_type") & "</td><td>" & .Rows(k).Item("resourc") & "</td><td>" & .Rows(k).Item("inhouse_osp") & "</td><td>" & .Rows(k).Item("assy_target") & "</td><td>" & .Rows(k).Item("category") & "</td><td>" & .Rows(k).Item("location") & "</td></tr>"
                Else
                    If .Rows(k).Item("org") <> .Rows(k - 1).Item("org") Then
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(k).Item("org") & "</td><td>" & .Rows(k).Item("job_no") & "</td><td align=left>" & .Rows(k).Item("job_dt") & "</td><td align=left>" & .Rows(k).Item("item_no") & "</td><td>" & .Rows(k).Item("rev") & "</td><td>" & .Rows(k).Item("description") & "</td><td>" & .Rows(k).Item("opn_seq") & "</td><td>" & .Rows(k).Item("quantity") & "</td><td>" & .Rows(k).Item("comp_dt") & "</td><td>" & .Rows(k).Item("res_code") & "</td><td>" & .Rows(k).Item("item_type") & "</td><td>" & .Rows(k).Item("resourc") & "</td><td>" & .Rows(k).Item("inhouse_osp") & "</td><td>" & .Rows(k).Item("assy_target") & "</td><td>" & .Rows(k).Item("category") & "</td><td>" & .Rows(k).Item("location") & "</td></tr>"
                    Else
                        S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(k).Item("org") & "</td><td>" & .Rows(k).Item("job_no") & "</td><td align=left>" & .Rows(k).Item("job_dt") & "</td><td align=left>" & .Rows(k).Item("item_no") & "</td><td>" & .Rows(k).Item("rev") & "</td><td>" & .Rows(k).Item("description") & "</td><td>" & .Rows(k).Item("opn_seq") & "</td><td>" & .Rows(k).Item("quantity") & "</td><td>" & .Rows(k).Item("comp_dt") & "</td><td>" & .Rows(k).Item("res_code") & "</td><td>" & .Rows(k).Item("item_type") & "</td><td>" & .Rows(k).Item("resourc") & "</td><td>" & .Rows(k).Item("inhouse_osp") & "</td><td>" & .Rows(k).Item("assy_target") & "</td><td>" & .Rows(k).Item("category") & "</td><td>" & .Rows(k).Item("location") & "</td></tr>"
                    End If
                End If
            End With
        Next
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Job Store Pending.xls"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)
        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
    End Sub
    Private Sub stock_out_alert()
        If Not Directory.Exists("D:\stock out alert") Then
            Directory.CreateDirectory("D:\stock out alert")
        Else
            Dim Str() As String
            Str = Directory.GetFiles("D:\stock out alert")
            Dim DELFILE As String
            For Each DELFILE In Str
                File.Delete(DELFILE)
            Next
        End If
        file_no = 0
        days = 0
        average = 0
        stock = 0
        stock_days = 0
        sl_no = 0

        'sql = "drop table jan_clp_pricelist_table"
        'comand()
        'sql = "create table jan_clp_pricelist_table as select * from jan_clp_pricelist"
        'comand()
        Try

            sql = "truncate table jan_clp_pricelist_table"
            comand()

            sql = "insert into jan_clp_pricelist_table select INVENTORY_ITEM_ID,	ITEM_NO,	DESCRIPTION,	UOM,	CLP,	SCLP,	DISC,	SCLP_DISC,	LIST_HEADER_ID,	LEVEL_2,	L5,	CATEGORY_NAME,	LEVEL_5,	CATEGORY_ID,LAST_UPDATE_DATE,	MRP_PRICE,	TARIFF_NO,	ED_PER from jan_clp_pricelist"
            comand()

        Catch ex As Exception

        End Try

        ds = New DataSet
        sql = "SELECT ORDERed_item,organization_id,average FROM(SELECT AA.*,ROUND(qty/COUNT)average ,(SELECT SUM(quantity_invoiced) FROM JAN_IT.jan_sales_any_1_copy WHERE  INVENTORY_ITEM_ID=AA.INVENTORY_ITEM_ID AND organization_id=aa.organization_id AND TRX_DATE>=TRUNC (TRUNC (SYSDATE, 'MM') - 90,'MM') AND trx_date<'" & Format(last_date, "dd-MMM-yyyy") & "') LAST_3_MNTH_QTY,(SELECT DECODE(clp,0,sclp,clp) FROM jan_clp_pricelist_table WHERE INVENTORY_ITEM_ID=aa.INVENTORY_ITEM_ID  and rownum=1)clp FROM (SELECT   ordered_item,INVENTORY_ITEM_ID, organization_id, SUM (qty) qty,COUNT (*) COUNT FROM (SELECT   ordered_item, my, organization_id, SUM (quantity_invoiced) qty ,INVENTORY_ITEM_ID FROM (SELECT a.*,(SELECT item_type FROM mtl_system_items        WHERE organization_id =a.organization_id AND inventory_item_id =a.inventory_item_id) item_type FROM jan_sales_any_1_copy a  where organization_id in (104,106,107,108,109) AND trx_date >= '" & Format(first_date, "dd-MMM-yyyy") & "'  AND trx_date < '" & Format(last_date, "dd-MMM-yyyy") & "') WHERE item_type = 'FG'   GROUP BY ordered_item, my, organization_id,INVENTORY_ITEM_ID)   GROUP BY ordered_item, organization_id ,INVENTORY_ITEM_ID) AA) WHERE LAST_3_MNTH_QTY IS NOT NULL and clp is not null AND average>=50   ORDER BY organization_id,ordered_item"

        'sql = "SELECT ORDERed_item,organization_id,average FROM( SELECT AA.*,(SELECT SUM(quantity_invoiced) FROM jan_sales_any_1_copy WHERE  INVENTORY_ITEM_ID=AA.INVENTORY_ITEM_ID AND organization_id=aa.organization_id AND TRX_DATE>=TRUNC (TRUNC (SYSDATE, 'MM') - 90,'MM') AND trx_date<'" & Format(last_date, "dd-MMM-yyyy") & "') LAST_3_MNTH_QTY,ROUND(qty/COUNT)average,(SELECT DECODE(clp,0,sclp,clp) FROM jan_clp_pricelist WHERE INVENTORY_ITEM_ID=AA.INVENTORY_ITEM_ID  and rownum=1)clp FROM (SELECT   ordered_item,INVENTORY_ITEM_ID, organization_id, SUM (qty) qty,COUNT (*) COUNT FROM (SELECT   ordered_item,INVENTORY_ITEM_ID, my, organization_id, SUM (quantity_invoiced) qty  FROM (SELECT a.*,(SELECT item_type FROM mtl_system_items        WHERE organization_id =a.organization_id AND inventory_item_id =a.inventory_item_id) item_type FROM JAN_IT.jan_sales_any_1_copy a  where organization_id in (104,106,107,108,109) AND trx_date >= '" & Format(first_date, "dd-MMM-yyyy") & "'  AND trx_date < '" & Format(last_date, "dd-MMM-yyyy") & "') WHERE item_type = 'FG'   GROUP BY ordered_item, my, organization_id,INVENTORY_ITEM_ID)   GROUP BY ordered_item, organization_id,INVENTORY_ITEM_ID ) AA) WHERE LAST_3_MNTH_QTY IS NOT NULL and clp is not null AND average>=50 ORDER BY organization_id,ordered_item"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")


        For k = 0 To ds.Tables("result").Rows.Count - 1
            If k = 0 Then
                S = ""
                S = "<html>"
                find_org()
                S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
                S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
                table_head()
            End If
            If k > 0 Then
                If ds.Tables("result").Rows(k - 1).Item("organization_id") <> ds.Tables("result").Rows(k).Item("organization_id") Then
                    S &= "</table>"
                    file_no += 1
                    Dim objfso
                    objfso = CreateObject("Scripting.FileSystemObject")
                    X = "C:\stock out alert\stock_out_alert" & file_no & ".html"
                    If objfso.FileExists(X) Then
                        objfso.DeleteFile(X)
                    End If
                    Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                    Dim SW As StreamWriter = New StreamWriter(FSTRM)
                    SW.WriteLine(S)
                    FSTRM.Flush()
                    SW.Flush()
                    SW.Close()
                    FSTRM.Close()
                    S = ""
                    S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
                    find_org()
                    S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
                    table_head()
                    sl_no = 0
                End If
            End If
            With ds.Tables("result").Rows(k)
                average = .Item("average")
                days = average / 26
                ds1 = New DataSet
                If .Item("organization_id") = 104 Then
                    sql = "SELECT INVENTORY_ITEM_ID,DESCRIPTION,(fg_stores+staging+spares+service+bda_store)stock FROM jan_rg1_prod_u2 WHERE item='" & .Item("ordered_item") & "'"
                ElseIf .Item("organization_id") <> 104 Then
                    sql = "SELECT INVENTORY_ITEM_ID,DESCRIPTION,(fg_stores+staging+spares+service+bda_store)stock FROM jan_rg1_prod WHERE item='" & .Item("ordered_item") & "'"
                End If
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "stock")
                If ds1.Tables("stock").Rows.Count > 0 Then
                    stock = ds1.Tables("stock").Rows(0).Item("stock")
                    stock_days = stock / days
                Else
                    stock = 0
                    stock_days = 0
                End If
                If stock_days < 10 Then
                    sl_no += 1
                    If ds1.Tables("stock").Rows.Count > 0 Then
                        S &= "<tr><td>" & sl_no & "</td><td>" & .Item("ordered_item") & "</td><td>" & ds1.Tables("stock").Rows(0).Item("description") & "</td><td align=right>" & average & "</td><td align=right>" & FormatNumber(days, 2) & "</td><td align=right>" & stock & "</td><td align=right>" & FormatNumber(stock_days, 2) & "</td></tr>"
                        sql = "insert into jan_stock_out_alert(run_date,item_no,description,avg_qty_per_mnth,avg_qty_per_day,stock,proj_stock_days,organization_id,inventory_item_id) values(sysdate,'" & .Item("ordered_item") & "','" & ds1.Tables("stock").Rows(0).Item("description") & "','" & average & "','" & days & "','" & stock & "','" & stock_days & "','" & .Item("organization_id") & "','" & ds1.Tables("stock").Rows(0).Item("INVENTORY_ITEM_ID") & "')"
                        comand()
                    Else
                        sql = "select description,inventory_item_id from mtl_system_items where segment1='" & .Item("ordered_item") & "' and organization_id=105"
                        cmd = New OracleClient.OracleCommand(sql, con)
                        If con.State = ConnectionState.Closed Then con.Open()
                        dr1 = cmd.ExecuteReader
                        If dr1.HasRows = True Then
                            description = dr1.Item("description")
                            item_id = dr1.Item("inventory_item_id")
                        End If
                        S &= "<tr><td>" & sl_no & "</td><td>" & .Item("ordered_item") & "</td><td>" & description & "</td><td align=right>" & average & "</td><td align=right>" & FormatNumber(days, 2) & "</td><td align=right>" & stock & "</td><td align=right>" & FormatNumber(stock_days, 2) & "</td></tr>"
                        sql = "insert into jan_stock_out_alert(run_date,item_no,description,avg_qty_per_mnth,avg_qty_per_day,stock,proj_stock_days,organization_id,inventory_item_id) values(sysdate,'" & .Item("ordered_item") & "','" & description & "','" & average & "','" & days & "','" & stock & "','" & stock_days & "','" & .Item("organization_id") & "','" & item_id & "')"
                        comand()
                    End If
                End If
            End With
        Next
        S &= "</TABLE>"
        S &= "</html>"
        file_no += 1
        Dim objfso1
        objfso1 = CreateObject("Scripting.FileSystemObject")
        X = "D:\stock out alert\stock_out_alert" & file_no & ".html"
        If objfso1.FileExists(X) Then
            objfso1.DeleteFile(X)
        End If
        Dim FSTRM1 As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)
        SW1.WriteLine(S)
        FSTRM1.Flush()
        SW1.Flush()
        SW1.Close()
        FSTRM1.Close()
    End Sub
    Private Sub find_org()
        sql = "select organization_code from org_organization_definitions where organization_id='" & ds.Tables("result").Rows(k).Item("organization_id") & "'"
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        DR = cmd.ExecuteReader
        If DR.HasRows = True Then
            S &= "<h5><font size=2 face=Verdana>Stock Out Alert for " & DR.Item("organization_code") & " </h5>"
        End If
    End Sub
    Private Sub table_head()
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana>FG Stock<br>(nos)</u></TD><TD align=center><u><font size=1 face=Verdana>Projected <br>Stock-out Days</TD></tr>"
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Tag = True Then
            sql = "update JAN_ORA_SCHEDULE_LOG_T set end_time=sysdate where trunc(start_time)=trunc(sysdate) and s_code='C00011'  and end_time is null"
            comand()

            'sql = "update JAN_ORA_SCHEDULE_LOG_T set errmsg='" & ex.Message.Replace("'", " ") & "' ,end_time=sysdate  where trunc(start_time)=trunc(sysdate) and s_code='C00011'  and end_time is null"
            'comand()

            Timer1.Tag = False

        Else

            Timer1.Tag = True
            If mailing_count = 0 Then
                sql = "SELECT a.*,to_char(sysdate,'IW')week_no,to_char(sysdate-7,'IYYYIW')week1 ,to_char(sysdate-14,'IYYYIW')week2,to_char(sysdate-21,'IYYYIW')week3 FROM jan_mailer_schedule a where  mail_status='A'   ORDER BY schedule_id " 'And schedule_id = 12    And schedule_id = 22 

                'schedule_id not in(4,5,6,7,8,14,20)
                adap = New OracleDataAdapter(sql, con)
                ds5 = New DataSet
                adap.Fill(ds5, "result")
                mailing_count = 1


                For i = 0 To ds5.Tables("result").Rows.Count - 1
                    With ds5.Tables("result").Rows(i)
                        If .Item("schedule_id") = 7 Then
                            ' sql = "SELECT FLEX_VALUE_ID dept_id,FLEX_VALUE dept FROM APPS.FND_FLEX_VALUES WHERE FLEX_VALUE_SET_ID=1012507 AND ENABLED_FLAG='Y' and FLEX_VALUE_ID=142204"
                            sql = "SELECT DISTINCT DEPT_NAME DEPT,DEPT_ID FROM JAN_DAILY_ATTN_V WHERE DEPT_NAME IS NOT NULL  AND DEPT_ID=144188"

                            adap = New OracleDataAdapter(sql, con)
                            dept = New DataSet
                            adap.Fill(dept, "dept_name")
                            For dept_no = 0 To dept.Tables("dept_name").Rows.Count - 1
                                send_mail()
                            Next

                        Else
                            Try
                                week1 = .Item("week1")
                                week2 = .Item("week2")
                                week3 = .Item("week3")
                                week_no = .Item("week_no")
                                send_mail()

                            Catch ex As Exception
                                sql = "insert into jan_sales_bi_exception(run_date,error_desc,pro_head) values(sysdate,'" & ex.Message.Replace("'", " ") & "','Mailer')"
                                comand()
                                Me.Close()
                            End Try

                        End If

                    End With
                Next


            Else


                sql = "SELECT * FROM jan_mailer_schedule  where  schedule_id not in('4','5','6')   and schedule_interval is not null ORDER BY schedule_id"
                adap = New OracleDataAdapter(sql, con)
                ds5 = New DataSet
                adap.Fill(ds5, "result")
                If ds5.Tables("result").Rows.Count = 0 Then Me.Close()

                For i = 0 To ds5.Tables("result").Rows.Count - 1
                    With ds5.Tables("result").Rows(i)

                        sql = "select max(run_date)run_date,sysdate from jan_mailer_table where schedule_id=" & .Item("schedule_id") & ""
                        adap = New OracleDataAdapter(sql, con)
                        If ds5.Tables.Contains("schedule") = True Then
                            ds5.Tables.Remove("schedule")
                        End If
                        adap.Fill(ds5, "schedule")

                        If .Item("period") = "Minute" Then
                            interval = DateDiff(DateInterval.Minute, ds5.Tables("schedule").Rows(0).Item("run_date"), ds5.Tables("schedule").Rows(0).Item("sysdate"))
                        ElseIf .Item("period") = "Hour" Then
                            interval = DateDiff(DateInterval.Hour, ds5.Tables("schedule").Rows(0).Item("run_date"), ds5.Tables("schedule").Rows(0).Item("sysdate"))
                        End If

                        If interval >= .Item("schedule_interval") Then
                            send_mail()
                        End If

                    End With
                Next
            End If
        End If

    End Sub
    Private Sub Ar_invoice_diff()

        sql = " DECLARE BEGIN jan_ar_inv_diff_proc; END;"
        comand()

        sql = "select trx_number ""Inv No"",trx_date  ""Inv Date"",basic_val ,Tax_amt,Total_inv_val,CUR_AR_val AR_val,cur_diff, oa_type,customer_name from (Select * FROM (Select B.* ,(TOTAL_INV_VAL-CUR_AR_val)CUR_DIFF,jan_check_positive(TOTAL_INV_VAL-CUR_AR_val)CUR_DIFF_amt FROM (Select A.*,Case When TRX_NUMBER Like '190%' THEN (SELECT OATYPE FROM JAN_INVOICE_LISTING_sf  WHERE CUSTOMER_TRX_ID=A.CUSTOMER_TRX_ID AND ROWNUM=1) ELSE (SELECT OATYPE FROM JAN_INVOICE_LISTING  WHERE CUSTOMER_TRX_ID=A.CUSTOMER_TRX_ID and OATYPE is not null AND ROWNUM=1) END OA_TYPE ,CASE WHEN TRX_NUMBER LIKE '190%' THEN  (SELECT  BILL_TO_CUST_NAME FROM JAN_INVOICE_LISTING_sf WHERE CUSTOMER_TRX_ID=A.CUSTOMER_TRX_ID AND ROWNUM=1) ELSE (SELECT OATYPE FROM JAN_INVOICE_LISTING  WHERE CUSTOMER_TRX_ID=A.CUSTOMER_TRX_ID  and OATYPE is not null  AND ROWNUM=1)  END CUSTOMER_NAME,CASE WHEN TRX_NUMBER LIKE '190%' THEN nvl((select sum(amount_due_original) from jan_region_payment_pending_sf where customer_trx_id=a.customer_trx_id),0)else  nvl((select sum(amount_due_original) from jan_region_payment_pending where customer_trx_id=a.customer_trx_id),0) end CUR_AR_val from jan_invoice_ar_check  a where  trx_date>=  "
        sql &= " (select ar_inv_diff_from  from jan_sales_bi_setup) "

        sql &= " )B) WHERE (/*(tax_amt=0 And OA_TYPE Not Like 'Exp%' ) or */ (cur_diff>=10 or cur_diff<-10) and OA_TYPE is not null ) ) order by oa_type,customer_name"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")

        ar_inv_diff_cnt = ds.Tables("res").Rows.Count

        mail_content("AR_Inv_Diff")


    End Sub
    Private Sub booked_order()


        If Now.DayOfWeek = DayOfWeek.Monday Then
            booked_dt = DateAdd(DateInterval.Day, -2, Today)
        Else
            booked_dt = DateAdd(DateInterval.Day, -1, Today)
        End If
        ds = New DataSet
        sql = "SELECT * FROM (SELECT aa.*,round(DECODE (aa.item_cost,0, 0, aa.unit_selling_price / aa.item_cost),3) fmla FROM (SELECT a.order_number, ordered_date, booked_date,jan_orgcode (organization_id) org, ord_cat,customer_name, site, ordered_item, ordered_quantity, unit_selling_price,(ordered_quantity * unit_selling_price) order_value,(SELECT item_cost FROM jan_itemcost  WHERE org_id = a.organization_id AND item_id = a.inventory_item_id) item_cost FROM jan_it.jan_sales_any_2 a WHERE TRUNC (a.booked_date) = '" & Format(booked_dt, "dd-MMM-yyyy") & "' AND customer_name NOT LIKE 'JANATICS%' AND ord_type NOT IN (SELECT NAME FROM jan_exemp_order_type)) aa) WHERE fmla <= 1.30 ORDER BY org, customer_name, ordered_item"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table width=80% align=center class=tab border=1 cellspacing=0 cellpadding=0>"
        S &= "<tr><th>Order No</th><th>Order Date</th><th>Booked date</th><th>Org</th><th>Order Caregory</th><th>Customer Name</th><th>site</th><th>Ordered Item</th><th>Ordered Quantity</th><th>Unit Selling Price</th><th>Order Value</th><th>Item Cost</th><th>Formula</th></tr>"

        For k = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(k)
                S &= "<tr><td>" & .Item("order_number") & "</td><td>" & .Item("ordered_date") & "</td><td>" & .Item("booked_date") & "</td><td>" & .Item("org") & "</td><td>" & .Item("ord_cat") & "</td><td>" & .Item("customer_name") & "</td><td>" & .Item("site") & "</td><td>" & .Item("ordered_item") & "</td><td align=right>" & .Item("ordered_quantity") & "</td><td  align=right>" & Format(.Item("unit_selling_price"), "00.00") & "</td><td  align=right>" & Format(.Item("order_value"), "00.00") & "</td><td  align=right>" & Format(.Item("item_cost"), "00.00") & "</td><td  align=right>" & .Item("fmla") & "</td></tr>"
            End With
        Next
        S &= "</table>"
        S &= "</html>"

        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\MAILER\Booked Orders.HTML"
        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
    End Sub
    Private Sub Order_detail()
        'sql = " SELECT B.*,CASE WHEN ""Unapplied"">=""Outstanding"" THEN  ""Unapplied""-""Outstanding"" ELSE 0 END ""Credit"",case when ""Unapplied""<""Outstanding"" then  ""Outstanding""-""Unapplied"" else 0 end ""Debit"" from (SELECT  (SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID )""Customer Name"", (select CUSTOMER_CLASS_CODE from RA_CUSTOMERS where CUSTOMER_ID=a.CUSTOMER_ID )""Class Code"", NVL((SELECT COUNT(DISTINCT HEADER_ID)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')-6),0)""No of OA pending Before OFD"", NVL((SELECT COUNT(DISTINCT HEADER_ID)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 AND  ORDER_FF_DT>NEXT_DAY(sysdate-1,'Sat')-6),0)""No of OA pending After OFD"",  NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')-6),0)""Val of OA Pending Before OFD"", NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT>NEXT_DAY(SYSDATE-1,'Sat')-6),0)""Val of OA Pending After OFD"", NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  */ AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')-6),0)""Avail value for Before OFD"", NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT>NEXT_DAY(sysdate-1,'Sat')-6),0)""Avail value for After OFD"" ,nvl((select sum(rsv2) from jan_dealer_payment2 where cust_id=a.customer_id and flag='PENDING ORDER' and PAYMENT_EXP_DATE<NEXT_DAY(sysdate-1,'Sat')-6),0)""Payment Received  Before OFD"" , NVL((SELECT SUM(RSV2) FROM JAN_DEALER_PAYMENT2 WHERE CUST_ID=A.CUSTOMER_ID AND FLAG='PENDING ORDER' AND PAYMENT_EXP_DATE>NEXT_DAY(SYSDATE-1,'Sat')-6),0)""Payment Received  After OFD"", NVL(JAN_CUS_PP(A.CUSTOMER_ID),0)""Unapplied"" ,nvl(jan_cus_out_standing(A.CUSTOMER_ID),0) ""Outstanding"" from ( SELECT CUSTOMER_ID,COUNT(*)CNT,TER_NAME REGION FROM JAN_BMS_BILL_TO_V WHERE  TER_NAME='CBE 2'   GROUP BY CUSTOMER_ID, TER_NAME)A)B WHERE (""Unapplied""+""Outstanding""+""No of OA pending Before OFD""+""No of OA pending After OFD""+""Val of OA Pending Before OFD""+""Val of OA Pending After OFD""+""Avail value for Before OFD""+""Avail value for After OFD""+""Payment Received  Before OFD""+""Payment Received  After OFD"")>0 order by ""Class Code"",""Customer Name"""


        sql = " SELECT B.*,CASE WHEN ""Unapplied"">=""Outstanding"" THEN  ""Unapplied""-""Outstanding"" ELSE 0 END ""Credit"",case when ""Unapplied""<""Outstanding"" then  ""Outstanding""-""Unapplied"" else 0 end ""Debit"" from ( "

        sql &= " SELECT  (SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.CUSTOMER_ID )""Customer Name"", (select CUSTOMER_CLASS_CODE from RA_CUSTOMERS where CUSTOMER_ID=a.CUSTOMER_ID )""Class Code"",nvl((select CUSTOMER_CATEGORY from JAN_PICK_FORWARD_CONTROL where BILL_TO_CUSTOMER_ID=a.CUSTOMER_ID),'C4')""Customer Category"" "
        sql &= ",(SELECT STANDARD_TERMS_NAME FROM AR_CUSTOMER_PROFILES_V WHERE CUSTOMER_ID=A.CUSTOMER_ID AND SITE_USE_ID IS NULL)pay_term "

        sql &= ",nvl((select SUM(NVL(DEPOSITED_AMONT,0))  from JAN_BMS_OA_LINE_PAYMENT_DET_T po where  1=1 and pgs_status='Open' AND customer_id=a.customer_id),0)GUARANTEE_AMOUNT
 "
        sql &= ",nvl((select   NVL(SUM(PAYMENT_GUARANTEED_AMOUNT-NVL(OUT_STANDING_AMOUNT,0)),0) from JAN_BMS_OA_LINE_PAYMENT_DET_T po where  1=1 and pgs_status='Open' AND customer_id=a.customer_id),0)BALANCE_GUARANTEE_AMOUNT
 "
        sql &= ",(SELECT STANDARD_TERMS_NAME FROM AR_CUSTOMER_PROFILES_V WHERE CUSTOMER_ID=A.CUSTOMER_ID AND SITE_USE_ID IS NULL)""Payment Terms"" "

        sql &= " , NVL((SELECT COUNT(DISTINCT HEADER_ID)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')+1),0)No_of_OA_pending_upto_OFD, NVL((SELECT COUNT(DISTINCT HEADER_ID)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 AND  ORDER_FF_DT>NEXT_DAY(sysdate-1,'Sat')+1),0)No_of_OA_pending_After_OFD "

        sql &= " ,  NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')+1),0)Val_of_OA_Pending_upto_OFD, NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT>NEXT_DAY(SYSDATE-1,'Sat')+1),0)Val_of_OA_Pending_After_OFD "

        sql &= " , NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  */ AND  ORDER_FF_DT<NEXT_DAY(SYSDATE-1,'Sat')+1),0)Avail_value_for_upto_OFD, NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0 */ AND  ORDER_FF_DT>NEXT_DAY(sysdate-1,'Sat')+1),0)Avail_value_for_After_OFD  "

        sql &= " , NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  */ AND   to_char(ORDER_FF_DT,'IYYYIW')<=to_char(sysdate,'IYYYIW')-2 ),0)Avail_value_for_week_minus2"

        sql &= " , NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0)-RSV_QTY)*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND to_char(ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  */ AND   to_char(ORDER_FF_DT,'IYYYIW')<=to_char(sysdate,'IYYYIW')-2 ),0)Not_Avail_value_week_minus2"

        sql &= " ,  NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID  AND  to_char(ORDER_FF_DT,'IYYYIW')<=to_char(sysdate,'IYYYIW')-3),0)Val_of_OA_Pending_week_minus3 "


        sql &= " , NVL((SELECT SUM(RSV_QTY*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID /* AND (ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))>0  */ AND   to_char(ORDER_FF_DT,'IYYYIW')<=to_char(sysdate,'IYYYIW')-3 ),0)Avail_value_for_week_minus3"

        sql &= " ,  NVL((SELECT SUM((ORDERED_QUANTITY-NVL(SHIPPED_QUANTITY,0))*UNIT_SELLING_PRICE)  FROM  JAN_SALES_PLAN_TV_T WHERE SOLD_TO_ORG_ID=A.CUSTOMER_ID ),0)total_OA_Pending  "

        sql &= ",rowtocol('select to_char(dt_of_week,''IWIYYY'')||''-''||amount_due_remaining wk from JAN_dealer_payment_new_t  where bill_to_customer_id='||A.CUSTOMER_ID||'')week_num_Paypend"

        sql &= " , NVL((select decode(count(*),0,'No','Yes') from JAN_CUSTOMER_REPLENISHMENT_T where end_date is  null  and CUSTOMER_ID=A.CUSTOMER_ID  ),0)bin_Exists"

        sql &= " ,nvl((select sum(rsv2) from jan_dealer_payment2 where cust_id=a.customer_id  and flag='PENDING ORDER'  and PAYMENT_EXP_DATE<NEXT_DAY(sysdate-1,'Sat')+1),0)Payment_Recd_OA_upto_OFD , NVL((SELECT SUM(RSV2) FROM JAN_DEALER_PAYMENT2 WHERE CUST_ID=A.CUSTOMER_ID  AND FLAG='PENDING ORDER'   AND PAYMENT_EXP_DATE>NEXT_DAY(SYSDATE-1,'Sat')+1),0)Payment_Recd_OA_After_OFD "

        sql &= " ,nvl((select sum(rsv2) from jan_dealer_payment2 where cust_id=a.customer_id  and flag<>'PENDING ORDER' and PAYMENT_EXP_DATE<NEXT_DAY(sysdate-1,'Sat')+1),0)Payment_Recd_Inv_upto_OFD , NVL((SELECT SUM(RSV2) FROM JAN_DEALER_PAYMENT2 WHERE CUST_ID=A.CUSTOMER_ID  AND FLAG<>'PENDING ORDER'   AND PAYMENT_EXP_DATE>NEXT_DAY(SYSDATE-1,'Sat')+1),0)Payment_Recd_Inv_After_OFD "


        sql &= " ,nvl((select sum(payment_value-rsv2) from jan_dealer_payment2 where cust_id=a.customer_id /* and flag='PENDING ORDER' */  and PAYMENT_EXP_DATE<NEXT_DAY(sysdate-1,'Sat')+1),0)Payment_Pending_upto_OFD , NVL((SELECT SUM(payment_value-rsv2) FROM JAN_DEALER_PAYMENT2 WHERE CUST_ID=A.CUSTOMER_ID /* AND FLAG='PENDING ORDER' */ AND PAYMENT_EXP_DATE>NEXT_DAY(SYSDATE-1,'Sat')+1),0)Payment_Pending_After_OFD"

        sql &= " , nvl((SELECT ROUND(SUM(HO_QUOTA_WITHIN_SCHEDULE),2) from JAN_SALES_PLAN_CUSTOMER_WISE where  CUSTOMER_ID=a.CUSTOMER_ID),0)Quota_Available_within_Sch "

        sql &= " , nvl((SELECT ROUND(SUM(HO_QUOTA_LATER_SCHEDULE),2) from JAN_SALES_PLAN_CUSTOMER_WISE where  CUSTOMER_ID=a.CUSTOMER_ID),0)Quota_Available_latter_Sch "


        sql &= " , NVL(JAN_CUS_PP(A.CUSTOMER_ID),0)""Unapplied"" "

        sql &= " ,nvl((select NVL(SUM(AMOUNT_DUE_REMAINING),0) FROM jan_region_payment_pending_tab WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID AND  AMOUNT_DUE_REMAINING<>0 and region='CBE 2' ),0) ""Outstanding"" "

        sql &= " ,nvl((select NVL(SUM(AMOUNT_DUE_REMAINING),0) FROM jan_region_payment_pending_tab WHERE BILL_TO_CUSTOMER_ID=A.CUSTOMER_ID AND  AMOUNT_DUE_REMAINING<>0 and region='CBE 2'  AND DUE_DAYS>0 ),0) ""ODue"" "

        'sql &= " ,nvl(JAN_CUS_ODUE(a.CUSTOMER_ID),0)""ODue"" "

        sql &= " from ( SELECT CUSTOMER_ID,COUNT(*)CNT,TER_NAME REGION FROM JAN_BMS_BILL_TO_V WHERE  TER_NAME='CBE 2'   GROUP BY CUSTOMER_ID, TER_NAME)A  " 'And CUSTOMER_ID = 513578

        'sql &= " SELECT CUSTOMER_ID,ROUND(SUM(HO_QUOTA_WITHIN_SCHEDULE)/100000,2)FG_LIMIT_WITHIN_SCHEDULE,ROUND(SUM(HO_QUOTA_LATER_SCHEDULE)/100000,2)FG_LIMIT_LATER_SCHEDULE from JAN_SALES_PLAN_CUSTOMER_WISE GROUP BY CUSTOMER_ID"





        sql &= " )B WHERE (""ODue""+""Unapplied""+""Outstanding""+No_of_OA_pending_upto_OFD+No_of_OA_pending_After_OFD+Val_of_OA_Pending_upto_OFD+Val_of_OA_Pending_After_OFD+Avail_value_for_upto_OFD+Avail_value_for_After_OFD+Payment_Recd_OA_upto_OFD+Payment_Recd_OA_After_OFD+Payment_Recd_Inv_upto_OFD+Payment_Recd_Inv_After_OFD+Payment_Pending_upto_OFD+Payment_Pending_After_OFD+Val_of_OA_Pending_week_minus3+ Avail_value_for_week_minus3+total_OA_Pending)>5 order by ""Customer Category"",""Customer Name"""

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")

        With ds.Tables("RES")
            .Rows.Add("Total")
            .Rows(.Rows.Count - 1).Item("ODue") = .Compute("sum(ODue)", "ODue>=0")
            .Rows(.Rows.Count - 1).Item("Unapplied") = .Compute("sum(Unapplied)", "Unapplied>=0")
            .Rows(.Rows.Count - 1).Item("Outstanding") = .Compute("sum(Outstanding)", "Outstanding>=0")
            
            .Rows(.Rows.Count - 1).Item("Avail_value_for_After_OFD") = .Compute("sum(Avail_value_for_After_OFD)", "Avail_value_for_After_OFD>=0")
            '.Rows(.Rows.Count - 1).Item("Val_of_OA_Pending_upto_OFD") = .Compute("sum(Val_of_OA_Pending_upto_OFD)", "Val_of_OA_Pending_upto_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Val_of_OA_Pending_After_OFD") = .Compute("sum(Val_of_OA_Pending_After_OFD)", "Val_of_OA_Pending_After_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Val_of_OA_Pending_upto_OFD") = .Compute("sum(Val_of_OA_Pending_upto_OFD)", "Val_of_OA_Pending_upto_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Payment_Recd_OA_upto_OFD") = .Compute("sum(Payment_Recd_OA_upto_OFD)", "Payment_Recd_OA_upto_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Payment_Recd_OA_After_OFD") = .Compute("sum(Payment_Recd_OA_After_OFD)", "Payment_Recd_OA_After_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Payment_Recd_Inv_upto_OFD") = .Compute("sum(Payment_Recd_Inv_upto_OFD)", "Payment_Recd_Inv_upto_OFD>=0")

            .Rows(.Rows.Count - 1).Item("Payment_Recd_Inv_After_OFD") = .Compute("sum(Payment_Recd_Inv_After_OFD)", "Payment_Recd_Inv_After_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Payment_Pending_upto_OFD") = .Compute("sum(Payment_Pending_upto_OFD)", "Payment_Pending_upto_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Payment_Pending_After_OFD") = .Compute("sum(Payment_Pending_After_OFD)", "Payment_Pending_After_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Avail_value_for_week_minus2") = .Compute("sum(Avail_value_for_week_minus2)", "Avail_value_for_week_minus2>=0")
            .Rows(.Rows.Count - 1).Item("Not_Avail_value_week_minus2") = .Compute("sum(Not_Avail_value_week_minus2)", "Not_Avail_value_week_minus2>=0")

            .Rows(.Rows.Count - 1).Item("No_of_OA_pending_upto_OFD") = .Compute("sum(No_of_OA_pending_upto_OFD)", "No_of_OA_pending_upto_OFD>=0")

            .Rows(.Rows.Count - 1).Item("No_of_OA_pending_After_OFD") = .Compute("sum(No_of_OA_pending_After_OFD)", "No_of_OA_pending_After_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Avail_value_for_upto_OFD") = .Compute("sum(Avail_value_for_upto_OFD)", "Avail_value_for_upto_OFD>=0")
            .Rows(.Rows.Count - 1).Item("Quota_Available_latter_Sch") = .Compute("sum(Quota_Available_latter_Sch)", "Quota_Available_latter_Sch>=0")

            .Rows(.Rows.Count - 1).Item("Quota_Available_within_Sch") = .Compute("sum(Quota_Available_within_Sch)", "Quota_Available_within_Sch>=0")



            .Rows(.Rows.Count - 1).Item("Debit") = .Compute("sum(Debit)", "Debit>=0")
            .Rows(.Rows.Count - 1).Item("Credit") = .Compute("sum(Credit)", "Credit>=0")

            .Rows(.Rows.Count - 1).Item("Val_of_OA_Pending_week_minus3") = .Compute("sum(Val_of_OA_Pending_week_minus3)", "Val_of_OA_Pending_week_minus3>=0")

            .Rows(.Rows.Count - 1).Item("Avail_value_for_week_minus3") = .Compute("sum(Avail_value_for_week_minus3)", "Avail_value_for_week_minus3>=0")

            .Rows(.Rows.Count - 1).Item("total_OA_Pending") = .Compute("sum(total_OA_Pending)", "total_OA_Pending>=0")



        End With
        mail_content("Order Pending and Payment")

        sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_sent,program_mail_id) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Cust Mail','feedback@janatics.co.in','sivashanmugam@janatics.co.in,janatics_cbe2@janatics.co.in','it-dev7@janatics.co.in,sathish@janatics.co.in','CBE 2 Order Pending and Payment Status',1,'it-dev7@janatics.co.in')"


        If con.State = ConnectionState.Closed Then con.Open()
        cmd = New OracleCommand(sql, con)
        cmd.ExecuteNonQuery()

        Dim file_name As String
        file_name = "d:\MAILER\Order Pending and Payment.html"

        Dim mail_no As Integer

        sql = "select jan_test_seq.currval task_id from dual"
        cmd = New OracleClient.OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        'DR = cmd.ExecuteReader
        'If DR.HasRows = True Then mail_no = DR("task_id")

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "RES")
        mail_no = ds.Tables("RES").Rows(0).Item("task_id")

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

    End Sub
    Private Sub price_list_addition()

        'Dim new_customer_date As Date

        sql = "select  TRUNC(JAN_preDATE_CNT(TRUNC(SYSDATE),1)) last_working_day from dual"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")


        new_customer_count = 0
        sql = "select (select name from qp_list_headers where list_header_id=qpll.list_header_id)price_list_name,jan_itemname(QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID))item_no,jan_itemdesc(jan_itemname(QP_PRICE_LIST_PVT.GET_INVENTORY_ITEM_ID(QPLL.LIST_LINE_ID)))description, operand price,creation_date  from qp_list_lines qpll where trunc(creation_date)>= '" & Format(ds.Tables("res").Rows(0).Item("last_working_day"), "dd-MMM-yyyy") & "' order by price_list_name,item_no"

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")
        'new_customer_date = ds.Tables("dt").Rows(0).Item("last_working_day")

        new_customer_count = ds.Tables("RES").Rows.Count

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"

        S &= "<tr><td>Dear Sir,</td></tr>"
        S &= "<tr><td><br> </td></tr>"

        S &= "<tr><td>The following New Prices are added on Last working day. </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Sl.No</th><th>Price List Name</th><th>Creation Date</th><th>Item No</th><th>Description</th><th>Price</th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center>" & k + 1 & "</td><td >" & .Item("price_list_name") & "</td><td>" & Format(.Item("creation_date"), "dd-MMM-yyyy") & "</td><td >" & .Item("item_no") & "</td><td >" & .Item("description") & "</td><td align=right>" & .Item("price") & "</td>"

                S &= "</tr>"
            End With
        Next

        S &= "</table></td></tr>"
        
        S &= "</table>"
        S &= "<p>This is a computer generated email. Please do not Reply."

    End Sub
    Private Sub new_part_no_Addition()

        sql = "select  TRUNC(JAN_preDATE_CNT(TRUNC(SYSDATE),1)) last_working_day from dual"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")

        sql = "select jan_it.jan_orgcode(organization_id)org,segment1 item_no,description,item_type,creation_date from mtl_system_items where  trunc(creation_date)>='" & Format(ds.Tables("res").Rows(0).Item("last_working_day"), "dd-MMM-yyyy") & "' and organization_id in (select organization_id from org_organization_definitions where operating_unit=103 and organization_id<>105 )and item_type='FG' order by item_no,org"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "res")

        new_customer_count = ds.Tables("RES").Rows.Count

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:navy;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:white;font-family:verdana;font-size:8pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"

        S &= "<tr><td>Dear Sir,</td></tr>"
        S &= "<tr><td><br> </td></tr>"

        S &= "<tr><td>The following FG Items are added on Last working day. </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td><br> </td></tr>"
        S &= "<tr><td>"

        S &= "<table border=1 cellspacing=0 cellpadding=5 width=100% class=tab bordercolor=gray><tr  class=tab1 bgcolor=cornflowerblue><th>Sl.No</th><th>Org</th><th>Item No</th><th>Description</th><th>Creation Date</th></tr>"

        For k = 0 To ds.Tables("res").Rows.Count - 1
            With ds.Tables("res").Rows(k)
                S &= "<tr><td align=center>" & k + 1 & "</td><td >" & .Item("org") & "</td><td >" & .Item("item_no") & "</td><td >" & .Item("Description") & "</td><td>" & Format(.Item("creation_date"), "dd-MMM-yyyy") & "</td>"

                S &= "</tr>"
            End With
        Next

        S &= "</table></td></tr>"
       
        S &= "</table>"
        S &= "<p>This is a computer generated email. Please do not Reply."

    End Sub

    Private Sub btn_send_mail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send_mail.Click

    End Sub
End Class