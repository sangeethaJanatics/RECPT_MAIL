Imports System.IO
Imports System.Data.OracleClient
Public Class mailer1
    Dim average, stock, sl_no As Double
    Dim days, stock_days As Double
    'Dim dr, dr1 As Odbc.OdbcDataReader
    Dim description, tail As String
    Dim first_date, last_date As Date
    Dim file_no, item_id, line As Integer
    Private Sub mailer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "select trunc(sysdate-180) frm_date from dual"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        first_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, ds.Tables("result").Rows(0).Item("frm_date")), Date.MinValue)
        last_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)
        btn_send_mail_Click(sender, e)
        btn_cancel_Click(sender, e)
    End Sub
    Private Sub btn_send_mail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send_mail.Click
        stock_out_alert()
        tail = "@janatics.co.in"
        Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "it-dev7" & tail & "")
        mailer.To.Add("SAMIKANNU" & tail & "")
        mailer.To.Add("santhanam" & tail & "")
        mailer.To.Add("RAMESH-PRODN" & tail & "")
        mailer.To.Add("KALIRAJ" & tail & "")
        mailer.To.Add("kathirvel" & tail & "")
        mailer.To.Add("lalitha" & tail & "")
        mailer.CC.Add("edgcv" & tail & "")
        mailer.CC.Add("ganesh" & tail & "")
        mailer.CC.Add("ramesh-mktg" & tail & "")
        mailer.CC.Add("sathish" & tail & "")
        mailer.CC.Add("it-dev7" & tail & "")
        Dim Str() As String
        Str = Directory.GetFiles("D:\stock out alert")
        Dim cnt As Integer = Str.Length
        Dim attach_file As String
        For Each attach_file In Str
            mailer.Attachments.Add(New System.Net.Mail.Attachment(attach_file))
        Next
        mailer.Subject = "Stock-out Alert on " & Date.Today & ""
        mailer.Priority = Net.Mail.MailPriority.Normal
        mailer.IsBodyHtml = True
        Dim SmtpMail As New Net.Mail.SmtpClient
        SmtpMail.Host = "mail.janatics.co.in"
        SmtpMail.Send(mailer)
        sql = "insert into jan_mailer_table(report_name,run_date) values('stock_out_alert',to_date('" & Format(Date.Now, "dd-MMM-yyyy HH:mm:ss") & "','DD-MM-YYYY HH24:MI:SS'))"
        comand()
        'code for job Store Pending mail*****************************************************************
        job_store_pending()
        mailer = New System.Net.Mail.MailMessage("it-dev7" & tail & "", "jmd-gnb" & tail & "")
        mailer.CC.Add("SATHISH" & tail & "")
        mailer.CC.Add("CKV" & tail & "")
        mailer.CC.Add("LALITHA" & tail & "")
        mailer.CC.Add("NAGANATHAN" & tail & "")
        mailer.CC.Add("PUR-STAFF" & tail & "")
        mailer.CC.Add("SAMIKANNU" & tail & "")
        mailer.CC.Add("RADHA" & tail & "")
        mailer.CC.Add("RAMESH-PRODN" & tail & "")
        mailer.CC.Add("KALIRAJ" & tail & "")
        mailer.CC.Add("RAJU" & tail & "")
        mailer.CC.Add("JAYARAMAN" & tail & "")
        mailer.CC.Add("IED-STAFF" & tail & "")
        mailer.CC.Add("santhanam" & tail & "")
        mailer.CC.Add("subash" & tail & "")
        mailer.CC.Add("rndstaff1" & tail & "")
        mailer.CC.Add("it-dev7" & tail & "")
        mailer.Subject = "Job Store Pending"
        mailer.Body = "Dear Sirs," & vbNewLine & "              Please find attached herewith excel   document consists of list of jobs to be delivered to stores from  01.04.2009 to " & Format(DateAdd(DateInterval.Day, -1, CDate(Date.Today)), "dd.MM.yyyy") & "." & vbNewLine & vbNewLine & "    Regards," & vbNewLine & "   C.K.Venkatachalapathy"
        mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
        mailer.Priority = Net.Mail.MailPriority.Normal
        mailer.IsBodyHtml = True
        SmtpMail = New Net.Mail.SmtpClient
        SmtpMail.Host = "mail.janatics.co.in"
        SmtpMail.Send(mailer)
        sql = "insert into jan_mailer_table(report_name,run_date) values('Job Store Pending',to_date('" & Format(Date.Now, "dd-MMM-yyyy HH:mm:ss") & "','DD-MM-YYYY HH24:MI:SS'))"
        comand()
        'code for rtv mail***************************************************************************
        Rtv_pending()
        tail = "@janatics.co.in"
        mailer = New System.Net.Mail.MailMessage("it-dev7" & tail & "", "jmd-gnb" & tail & "")
        mailer.CC.Add("SATHISH" & tail & "")
        mailer.CC.Add("CKV" & tail & "")
        mailer.CC.Add("LALITHA" & tail & "")
        mailer.CC.Add("NAGANATHAN" & tail & "")
        mailer.CC.Add("PUR-STAFF" & tail & "")
        mailer.CC.Add("it-dev7" & tail & "")
        mailer.Subject = "RTV PENDING - REG"
        mailer.Body = "Dear Sirs," & vbNewLine & vbNewLine & "        Please find attached herewith excel   document consists of RTV pending from purchase  date from  01.04.2009 to " & Format(DateAdd(DateInterval.Day, -1, CDate(Date.Today)), "dd.MM.yyyy") & "." & vbNewLine & vbNewLine & "Regards," & vbNewLine & "C.K.Venkatachalapathy"
        mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
        mailer.Priority = Net.Mail.MailPriority.Normal
        mailer.IsBodyHtml = True
        SmtpMail = New Net.Mail.SmtpClient
        SmtpMail.Host = "mail.janatics.co.in"
        SmtpMail.Send(mailer)
        sql = "insert into jan_mailer_table(report_name,run_date) values('Purchase-Rtv Pending',to_date('" & Format(Date.Now, "dd-MMM-yyyy HH:mm:ss") & "','DD-MM-YYYY HH24:MI:SS'))"
        comand()
        'assembly_rejection() 'code for Assembly Rejection*******************************************
        'tail = "@janatics.co.in"
        '' mailer = New System.Net.Mail.MailMessage("it-dev7" & tail & "", "jmd-gnb" & tail & "")
        'mailer = New System.Net.Mail.MailMessage("it-dev7" & tail & "", "it-dev4" & tail & "")
        ''mailer.To.Add("ANURADHA" & tail & "")
        ''mailer.To.Add("ESNK" & tail & "")
        ''mailer.To.Add("KALIRAJ" & tail & "")
        ''mailer.To.Add("KATHIRVEL" & tail & "")
        ''mailer.To.Add("lalitha" & tail & "")
        ''mailer.To.Add("naganathan" & tail & "")
        ''mailer.To.Add("PALKANNAN" & tail & "")
        ''mailer.To.Add("qc-staff" & tail & "")
        ''mailer.To.Add("RAJU" & tail & "")
        ''mailer.To.Add("RAMESH-PRODN" & tail & "")
        ''mailer.To.Add("SAMIKANNU" & tail & "")
        ''mailer.To.Add("SANTHANAM" & tail & "")
        ''mailer.To.Add("SUBASH" & tail & "")
        ''mailer.CC.Add("ckv" & tail & "")
        ''mailer.CC.Add("edgcv" & tail & "")
        ''mailer.CC.Add("GANESH" & tail & "")
        ''mailer.CC.Add("JMD-GNB" & tail & "")
        ''mailer.CC.Add("RAMESH-MKTG" & tail & "")
        'mailer.Subject = "Assembly Rejection"
        'mailer.Attachments.Add(New System.Net.Mail.Attachment(X))
        'mailer.Priority = Net.Mail.MailPriority.Normal
        'mailer.IsBodyHtml = True
        'SmtpMail = New Net.Mail.SmtpClient
        'SmtpMail.Host = "mail.janatics.co.in"
        'SmtpMail.Send(mailer)
        'If Format(Date.Now, "dd") = "01" Then
        '    Assembly_Rejection_consolidated()
        'End If
        MessageBox.Show("Mail sending completed", "Mailer", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Private Sub Assembly_Rejection_consolidated()
    '    Dim firstdate As Date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)
    '    Dim dt As Date = DateAdd(DateInterval.Day, -1, firstdate)
    '    Dim firstdateofLastMonth = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, dt), Date.MinValue)
    '    Dim LastDayofLastMonth As Date = DateAdd(DateInterval.Second, -3, DateAdd(DateInterval.Month, DateDiff("m", Date.MinValue, firstdate) + 1, Date.MinValue))


    '    sql = "SELECT distinct aa.org,aa.item_no,aa.item_des,sum(aa.qty)qty,aa.item_type,sum(tot_qty)tot_qty,occ,transaction_uom FROM ("

    '    sql &= " SELECT jan_orgcode(organization_id)org,item_no,item_Des,organization_id,sum(cr_qty)qty,item_type,transaction_uom, "

    '    sql &= "(SELECT abs(SUM(PRIMARY_QUANTITY)) FROM MTL_MATERIAL_TRANSACTIONS WHERE TRANSACTION_SOURCE_ID=A.TRANSACTION_SOURCE_ID AND TRANSACTION_TYPE_ID=35 AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID AND ORGANIZATION_ID=A.ORGANIZATION_ID)tot_QTY, "

    '    sql &= " (select count(distinct transaction_source_id) from mtl_material_transactions WHERE    inventory_item_id = a.inventory_item_id  AND organization_id = a.organization_id  and transaction_type_id = 43  AND subinventory_code IN ('Scrap', 'Scrap_Wip', 'FRDS-RTV')  and trunc(creation_date)>='" & Format(firstdateofLastMonth, "dd-MMM-yyyy") & "' and trunc(creation_date)<='" & Format(LastDayofLastMonth, "dd-MMM-yyyy") & "')occ "

    '    sql &= " FROM jan_kardex a where transaction_type_id=43 and subinventory_code in ('Scrap','Scrap_Wip','FRDS-RTV') "

    '    If Format(Date.Now, "ddd").ToUpper = "MON" Then sql &= " and trunc(transaction_date)>=trunc(sysdate)-2" Else sql &= " and trunc(transaction_date)>=trunc(sysdate)-1"

    '    sql &= "  and trunc(transaction_date)<trunc(sysdate) and organization_id in(104,106,107,108,109)  group by organization_id,item_no,item_Des,item_type,transaction_uom,TRANSACTION_SOURCE_ID,INVENTORY_ITEM_ID) aa group by  aa.org,aa.item_no,aa.item_des,aa.item_type, aa.occ,transaction_uom "

    '    adap = New OracleDataAdapter(sql, con)
    '    ds = New DataSet
    '    adap.Fill(ds, "resultab")
    '    Dim dv As DataView
    '    dv = ds.Tables("resultab").DefaultView
    '    dv.Sort = "org,item_no asc"
    '    ds.Tables("resultab").AcceptChanges()
    '    'If ds.Tables("resultab").Rows.Count > 0 Then




    '    S = "<HTML><HEAD>"
    '    S &= "<h4 align=center font face=Verdana>Component Rejection On :"

    '    If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "

    '    S &= "   </h4>"

    '    S &= "<table border=1 cellpadding=4 cellspacing=0 ><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td><td width=50><B>Total  Occurence of the month </td></tr>"

    '    line = 0

    '    For k = 0 To ds.Tables("resultab").Rows.Count - 1
    '        With ds.Tables("resultab").Rows(k)
    '            line = line + 1
    '            S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("item_des") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("transaction_uom") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("tot_qty") & "</font> </TD> <TD align=right><font face=verdana size=1.5>" & .Item("qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("occ") & "</font> </TD></tr>"
    '        End With
    '    Next
    '    'Else
    '    's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

    '    'End If
    '    'end if 
    '    S &= "</table></html>"

    '    sql = " SELECT jan_orgcode(organization_id)org,item_no,description,qty,primary_uom_code,JOB_QTY FROM ( SELECT  sum(transaction_quantity)qty,"

    '    sql &= " (select segment1 from mtl_system_items where   inventory_item_id=a.primary_item_id and organization_id=a.organization_id)item_no,"

    '    sql &= " (select description from mtl_system_items where  inventory_item_id=a.primary_item_id and organization_id=a.organization_id)description,"

    '    sql &= "(select primary_uom_code from mtl_system_items where  inventory_item_id=a.primary_item_id and organization_id=105)primary_uom_code, "

    '    sql &= " (select item_type from mtl_system_items where   inventory_item_id=a.primary_item_id and organization_id=a.organization_id)item_type,"

    '    sql &= " (SELECT SUM(START_QUANTITY) FROM WIP_DISCRETE_JOBS WHERE   WIP_ENTITY_ID=A.WIP_ENTITY_ID AND   PRIMARY_ITEM_ID = a.PRIMARY_ITEM_ID  AND ORGANIZATION_ID=A.ORGANIZATION_ID) JOB_QTY,organization_id "

    '    sql &= " FROM wip_move_transactions a  where TO_INTRAOPERATION_STEP_TYPE=5  and trunc(last_update_date)>='" & Format(firstdate, "dd-MMM-yyyy") & "'   and trunc(last_update_date)<='" & Format(LastDayofCurrentMonth, "dd-MMM-yyyy") & "'"


    '    sql &= " and trunc(last_update_date)<trunc(sysdate) and organization_id in(104,106,107,108,109) group by organization_id,primary_item_id,wip_entity_id ) where item_type='FG'"

    '    adap = New OracleDataAdapter(sql, con)
    '    ds2 = New DataSet
    '    adap.Fill(ds2, "resultab")
    '    Dim dv1 As DataView
    '    dv1 = ds2.Tables("resultab").DefaultView
    '    dv1.Sort = "org,item_no asc"
    '    ds2.Tables("resultab").AcceptChanges()


    '    ' If ds2.Tables("resultab").Rows.Count > 0 Then



    '    S &= "<HTML><HEAD>"
    '    S &= "<h4 align=center font face=Verdana>Product Rejection On:"

    '    If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "
    '    S &= "</h4>"

    '    S &= "<table border=1 cellpadding=4 cellspacing=0  ><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td></tr>"

    '    line = 0

    '    For j = 0 To ds2.Tables("resultab").Rows.Count - 1
    '        With ds2.Tables("resultab").Rows(j)
    '            line = line + 1
    '            S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("description") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("primary_uom_code") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("job_qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("qty") & "</font> </TD> </tr>"
    '        End With
    '    Next
    '    'Else
    '    's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

    '    'End If
    '    'End If
    '    S &= "</table></html>"




    '    sql = " SELECT jan_orgcode(ORG)ORG,ITEM_NO,DESCRIPTION,UOM,SUM(JOB_qTY)JOB_qTY,SUM(QUANTITY)REJ_QUANTITY,TO_DEPT  FROM JAN_INHOUSE_REJECTIONS WHERE   FROM_DEPT_CODE<>'ASSY' and org in (104,106,107,108,109) and REASON_CODE NOT IN ('OSP-000','PUR000','ISP000','OSP-030','ISP027','PUR011','ISP028','OSP-032','PUR014') and trunc(TRANSACTION_DATE)>='" & Format(firstdate, "dd-MMM-yyyy") & "'   and trunc(TRANSACTION_DATE)<='" & Format(LastDayofCurrentMonth, "dd-MMM-yyyy") & "'"



    '    sql &= "  GROUP BY ORG,ITEM_NO,DESCRIPTION,UOM,TO_DEPT "

    '    adap = New OracleDataAdapter(sql, con)
    '    ds3 = New DataSet
    '    adap.Fill(ds3, "resultab")
    '    Dim dv2 As DataView
    '    dv2 = ds3.Tables("resultab").DefaultView
    '    dv2.Sort = "org,item_no asc"
    '    ds3.Tables("resultab").AcceptChanges()


    '    ' If ds2.Tables("resultab").Rows.Count > 0 Then



    '    S &= "<HTML><HEAD>"
    '    S &= "<h4 align=center font face=Verdana>Machine Shop Rejection From :"

    '    If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "
    '    S &= "</h4>"

    '    S &= "<table border=1 cellpadding=4 cellspacing=0><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>To.Dept</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td></tr>"

    '    line = 0

    '    For j = 0 To ds3.Tables("resultab").Rows.Count - 1
    '        With ds3.Tables("resultab").Rows(j)
    '            line = line + 1
    '            S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("description") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("uom") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("to_dept") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("job_qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("REJ_QUANTITY") & "</font> </TD> </tr>"
    '        End With
    '    Next
    '    'Else
    '    's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

    '    'End If
    '    'End If
    '    S &= "</table></html>"


    '    '   If ds2.Tables("resultab").Rows.Count > 0 Or ds.Tables("resultab").Rows.Count > 0 Then
    '    Dim objfso
    '    objfso = CreateObject("Scripting.FileSystemObject")
    '    X = "D:\ Rejection Consolidated List.HTML "
    '    If objfso.FileExists(X) Then
    '        objfso.DeleteFile(X)
    '    End If
    '    Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
    '    Dim SW As StreamWriter = New StreamWriter(FSTRM)
    '    SW.WriteLine(S)
    '    FSTRM.Flush()
    '    SW.Flush()
    '    SW.Close()
    '    FSTRM.Close()

    'End Sub
    Private Sub assembly_rejection()
        Dim firstdate As Date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)

        Dim LastDayofCurrentMonth As Date = DateAdd(DateInterval.Second, -3, DateAdd(DateInterval.Month, DateDiff("m", Date.MinValue, Today()) + 1, Date.MinValue))


        sql = "SELECT distinct aa.org,aa.item_no,aa.item_des,sum(aa.qty)qty,aa.item_type,sum(tot_qty)tot_qty,occ,transaction_uom FROM ("

        sql &= " SELECT jan_orgcode(organization_id)org,item_no,item_Des,organization_id,sum(cr_qty)qty,item_type,transaction_uom, "

        sql &= "(SELECT abs(SUM(PRIMARY_QUANTITY)) FROM MTL_MATERIAL_TRANSACTIONS WHERE TRANSACTION_SOURCE_ID=A.TRANSACTION_SOURCE_ID AND TRANSACTION_TYPE_ID=35 AND INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID AND ORGANIZATION_ID=A.ORGANIZATION_ID)tot_QTY, "

        sql &= " (select count(distinct transaction_source_id) from mtl_material_transactions WHERE    inventory_item_id = a.inventory_item_id  AND organization_id = a.organization_id  and transaction_type_id = 43  AND subinventory_code IN ('Scrap', 'Scrap_Wip', 'FRDS-RTV')  and trunc(creation_date)>='" & Format(firstdate, "dd-MMM-yyyy") & "' and trunc(creation_date)<='" & Format(LastDayofCurrentMonth, "dd-MMM-yyyy") & "')occ "

        sql &= " FROM jan_kardex a where transaction_type_id=43 and subinventory_code in ('Scrap','Scrap_Wip','FRDS-RTV') "

        If Format(Date.Now, "ddd").ToUpper = "MON" Then sql &= " and trunc(transaction_date)>=trunc(sysdate)-2" Else sql &= " and trunc(transaction_date)>=trunc(sysdate)-1"

        sql &= "  and trunc(transaction_date)<trunc(sysdate) and organization_id in(104,106,107,108,109)  group by organization_id,item_no,item_Des,item_type,transaction_uom,TRANSACTION_SOURCE_ID,INVENTORY_ITEM_ID) aa group by  aa.org,aa.item_no,aa.item_des,aa.item_type, aa.occ,transaction_uom "

        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "resultab")
        Dim dv As DataView
        dv = ds.Tables("resultab").DefaultView
        dv.Sort = "org,item_no asc"
        ds.Tables("resultab").AcceptChanges()
        'If ds.Tables("resultab").Rows.Count > 0 Then




        S = "<HTML><HEAD>"
        S &= "<h4 align=center font face=Verdana>Component Rejection On :"

        If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "

        S &= "   </h4>"

        S &= "<table border=1 cellpadding=4 cellspacing=0 ><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td><td width=50><B>Total  Occurence of the month </td></tr>"

        line = 0

        For k = 0 To ds.Tables("resultab").Rows.Count - 1
            With ds.Tables("resultab").Rows(k)
                line = line + 1
                S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("item_des") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("transaction_uom") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("tot_qty") & "</font> </TD> <TD align=right><font face=verdana size=1.5>" & .Item("qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("occ") & "</font> </TD></tr>"
            End With
        Next
        'Else
        's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

        'End If
        'end if 
        S &= "</table></html>"

        sql = " SELECT jan_orgcode(organization_id)org,item_no,description,qty,primary_uom_code,JOB_QTY FROM ( SELECT  sum(transaction_quantity)qty,"

        sql &= " (select segment1 from mtl_system_items where   inventory_item_id=a.primary_item_id and organization_id=a.organization_id)item_no,"

        sql &= " (select description from mtl_system_items where  inventory_item_id=a.primary_item_id and organization_id=a.organization_id)description,"

        sql &= "(select primary_uom_code from mtl_system_items where  inventory_item_id=a.primary_item_id and organization_id=105)primary_uom_code, "

        sql &= " (select item_type from mtl_system_items where   inventory_item_id=a.primary_item_id and organization_id=a.organization_id)item_type,"

        sql &= " (SELECT SUM(START_QUANTITY) FROM WIP_DISCRETE_JOBS WHERE   WIP_ENTITY_ID=A.WIP_ENTITY_ID AND   PRIMARY_ITEM_ID = a.PRIMARY_ITEM_ID  AND ORGANIZATION_ID=A.ORGANIZATION_ID) JOB_QTY,organization_id "

        sql &= " FROM wip_move_transactions a  where TO_INTRAOPERATION_STEP_TYPE=5 "

        If Format(Date.Now, "ddd").ToUpper = "MON" Then sql &= " and trunc(last_update_date)>=trunc(sysdate)-2  " Else sql &= " and trunc(last_update_date)>=trunc(sysdate)-1  "


        sql &= " and trunc(last_update_date)<trunc(sysdate) and organization_id in(104,106,107,108,109) group by organization_id,primary_item_id,wip_entity_id ) where item_type='FG'"

        adap = New OracleDataAdapter(sql, con)
        ds2 = New DataSet
        adap.Fill(ds2, "resultab")
        Dim dv1 As DataView
        dv1 = ds2.Tables("resultab").DefaultView
        dv1.Sort = "org,item_no asc"
        ds2.Tables("resultab").AcceptChanges()


        ' If ds2.Tables("resultab").Rows.Count > 0 Then



        S &= "<HTML><HEAD>"
        S &= "<h4 align=center font face=Verdana>Product Rejection On:"

        If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "
        S &= "</h4>"

        S &= "<table border=1 cellpadding=4 cellspacing=0  ><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td></tr>"

        line = 0

        For j = 0 To ds2.Tables("resultab").Rows.Count - 1
            With ds2.Tables("resultab").Rows(j)
                line = line + 1
                S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("description") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("primary_uom_code") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("job_qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("qty") & "</font> </TD> </tr>"
            End With
        Next
        'Else
        's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

        'End If
        'End If
        S &= "</table></html>"




        sql = " SELECT jan_orgcode(ORG)ORG,ITEM_NO,DESCRIPTION,UOM,SUM(JOB_qTY)JOB_qTY,SUM(QUANTITY)REJ_QUANTITY,TO_DEPT  FROM JAN_INHOUSE_REJECTIONS WHERE   FROM_DEPT_CODE<>'ASSY' and org in (104,106,107,108,109) and REASON_CODE NOT IN ('OSP-000','PUR000','ISP000','OSP-030','ISP027','PUR011','ISP028','OSP-032','PUR014')"


        If Format(Date.Now, "ddd").ToUpper = "MON" Then sql &= " and trunc(TRANSACTION_DATE)=trunc(sysdate)-2  " Else sql &= " and trunc(TRANSACTION_DATE)=trunc(sysdate)-1 "



        sql &= "  GROUP BY ORG,ITEM_NO,DESCRIPTION,UOM,TO_DEPT "

        adap = New OracleDataAdapter(sql, con)
        ds3 = New DataSet
        adap.Fill(ds3, "resultab")
        Dim dv2 As DataView
        dv2 = ds3.Tables("resultab").DefaultView
        dv2.Sort = "org,item_no asc"
        ds3.Tables("resultab").AcceptChanges()


        ' If ds2.Tables("resultab").Rows.Count > 0 Then



        S &= "<HTML><HEAD>"
        S &= "<h4 align=center font face=Verdana>Machine Shop Rejection On:"

        If Format(Date.Now, "ddd").ToUpper = "MON" Then S &= " " & Format(DateAdd(DateInterval.Day, -2, Date.Now), "dd-MMM-yyyy") & " " Else S &= " " & Format(DateAdd(DateInterval.Day, -1, Date.Now), "dd-MMM-yyyy") & " "
        S &= "</h4>"

        S &= "<table border=1 cellpadding=4 cellspacing=0  ><tr><TD><B>S.No</TD><TD><B>Org</TD><TD><B>Item.No</TD><td><B>Description</td><td><B>UOM</td><td><B>To.Dept</td><td><B>Tot.Qty</td><td><B>Rej.Qty</td></tr>"

        line = 0

        For j = 0 To ds3.Tables("resultab").Rows.Count - 1
            With ds3.Tables("resultab").Rows(j)
                line = line + 1
                S &= " <tr><TD> <font face=verdana size=1.5>" & line & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("org") & "</font> </TD><TD> <font face=verdana size=1.5>" & .Item("item_no") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("description") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("uom") & "</font> </TD><TD><font face=verdana size=1.5>" & .Item("to_dept") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("job_qty") & "</font> </TD><TD align=right><font face=verdana size=1.5>" & .Item("REJ_QUANTITY") & "</font> </TD> </tr>"
            End With
        Next
        'Else
        's &= " <tr><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD> <font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD><TD align=right><font face=verdana size=1.5>&nbsp;</font> </TD> </tr>"

        'End If
        'End If
        S &= "</table></html>"


        '   If ds2.Tables("resultab").Rows.Count > 0 Or ds.Tables("resultab").Rows.Count > 0 Then
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\ Rejection list.HTML "
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
    Private Sub Rtv_pending()
        ds = New DataSet
        sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,PONO,PODT,VENDOR_NAME,ITEM_NO,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_pur_listing a where  receipt_date >='01-apr-2009' and receipt_date <'" & Format(CDate(Date.Today), "dd-MMM-yyyy") & "' and quantity_received=qty_dlyd and qty_rejd<>0 and vendor_return<qty_rejd  and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID) ,DIVISION"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "receipt")
        sl_no = 0
        S = ""
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=16 align=center><b> PURCHASE - RTV PENDING FROM 01-apr-2009 TO " & Format(CDate(DateAdd(DateInterval.Day, -1, Date.Today)), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>DIVISION</td><td>RECEIPT-NO</td><td>RECEIPT_DT</td><td>PONO</td><td>PODT</td><td>VENDOR</td><td>PART NO</td><td>DESCRIPTION</td><td>INS_DT</td><td>DEL_DT</td><td>RECD</td><td>APPD</td><td>REJ</td><td>DELIVERED</td></tr>"
        sl_no = 0
        For i = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            With ds.Tables("RECEIPT").Rows(i)
                If i > 0 Then
                    If ds.Tables("receipt").Rows(i - 1).Item("org") <> ds.Tables("receipt").Rows(i).Item("org") Then
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        'S &= "<TR></tr>"
                        'S &= "<TR></tr>"
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
        X = "D:\Purchase - Rtv pending.xls"
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
    Private Sub job_store_pending()
        ds = New DataSet
        sql = "SELECT (SELECT organization_code FROM org_organization_definitions WHERE organization_id=a.organization_id) org,job_no,job_dt,item_no,rev,description,opn_seq,lot_move quantity,TRUNC(comp_dt)comp_dt,res_code,ITEM_TYPE,resourc,osp_isp inhouse_osp,assy_target,(SELECT category FROM jan_counting_category WHERE a.item_cost BETWEEN from_value AND to_value AND organization_id=a.organization_id)category,NVL((SELECT location FROM jan_store_location_view WHERE inventory_item_id=a.inventory_item_id AND organization_id=a.organization_id AND ROWNUM=1),'-')location   FROM jan_final_operations a WHERE  comp_dt>='01-apr-2009' and comp_dt<'" & Format(DateAdd(DateInterval.Day, -1, CDate(Date.Today)), "dd/MMM/yyyy") & "' order by organization_id  asc"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "receipt")
        sl_no = 0
        S = ""
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=17 align=center><b>JOB STORE PENDING FROM 01-apr-2010 TO " & Format(DateAdd(DateInterval.Day, -1, CDate(Date.Today)), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>JOB NO</td><td>JOB DATE</td><td>ITEM NO</td><td>REV</td><td>DESCRIPTION</td><td>OPEN SEQ</td><td>QUANTITY</td><td>COMP DT</td><td>RES CODE</td><td>ITEM TYPE</td><td>RESOURCE</td><td>INHOUSE_OSP</td><td>ASSY_TARGET</td><td>CATEGORY</td><td>LOCATION</td></tr>"
        For i = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            With ds.Tables("receipt")
                sl_no += 1
                If i = 0 Then
                    S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(i).Item("org") & "</td><td>" & .Rows(i).Item("job_no") & "</td><td align=left>" & .Rows(i).Item("job_dt") & "</td><td align=left>" & .Rows(i).Item("item_no") & "</td><td>" & .Rows(i).Item("rev") & "</td><td>" & .Rows(i).Item("description") & "</td><td>" & .Rows(i).Item("opn_seq") & "</td><td>" & .Rows(i).Item("quantity") & "</td><td>" & .Rows(i).Item("comp_dt") & "</td><td>" & .Rows(i).Item("res_code") & "</td><td>" & .Rows(i).Item("item_type") & "</td><td>" & .Rows(i).Item("resourc") & "</td><td>" & .Rows(i).Item("inhouse_osp") & "</td><td>" & .Rows(i).Item("assy_target") & "</td><td>" & .Rows(i).Item("category") & "</td><td>" & .Rows(i).Item("location") & "</td></tr>"
                Else
                    If .Rows(i).Item("org") <> .Rows(i - 1).Item("org") Then
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(i).Item("org") & "</td><td>" & .Rows(i).Item("job_no") & "</td><td align=left>" & .Rows(i).Item("job_dt") & "</td><td align=left>" & .Rows(i).Item("item_no") & "</td><td>" & .Rows(i).Item("rev") & "</td><td>" & .Rows(i).Item("description") & "</td><td>" & .Rows(i).Item("opn_seq") & "</td><td>" & .Rows(i).Item("quantity") & "</td><td>" & .Rows(i).Item("comp_dt") & "</td><td>" & .Rows(i).Item("res_code") & "</td><td>" & .Rows(i).Item("item_type") & "</td><td>" & .Rows(i).Item("resourc") & "</td><td>" & .Rows(i).Item("inhouse_osp") & "</td><td>" & .Rows(i).Item("assy_target") & "</td><td>" & .Rows(i).Item("category") & "</td><td>" & .Rows(i).Item("location") & "</td></tr>"
                    Else
                        S &= "<tr><td align=center>" & sl_no & "</td><td>" & .Rows(i).Item("org") & "</td><td>" & .Rows(i).Item("job_no") & "</td><td align=left>" & .Rows(i).Item("job_dt") & "</td><td align=left>" & .Rows(i).Item("item_no") & "</td><td>" & .Rows(i).Item("rev") & "</td><td>" & .Rows(i).Item("description") & "</td><td>" & .Rows(i).Item("opn_seq") & "</td><td>" & .Rows(i).Item("quantity") & "</td><td>" & .Rows(i).Item("comp_dt") & "</td><td>" & .Rows(i).Item("res_code") & "</td><td>" & .Rows(i).Item("item_type") & "</td><td>" & .Rows(i).Item("resourc") & "</td><td>" & .Rows(i).Item("inhouse_osp") & "</td><td>" & .Rows(i).Item("assy_target") & "</td><td>" & .Rows(i).Item("category") & "</td><td>" & .Rows(i).Item("location") & "</td></tr>"
                    End If
                End If
            End With
        Next
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\Job Store Pending.xls"
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
        ds = New DataSet
        sql = "SELECT * FROM (SELECT ORDERed_item,organization_id,ROUND(qty/COUNT)average FROM(SELECT AA.*,(SELECT SUM(quantity_invoiced) FROM JAN_IT.jan_sales_any_1_copy WHERE  ORDERED_ITEM=AA.ORDERED_ITEM AND organization_id=aa.organization_id AND TRX_DATE>=TRUNC (TRUNC (SYSDATE, 'MM') - 90,'MM') AND trx_date<'" & Format(last_date, "dd-MMM-yyyy") & "') LAST_3_MNTH_QTY,(SELECT DECODE(clp,0,sclp,clp) FROM jan_clp_pricelist WHERE item_no=aa.ordered_item  and rownum=1)clp FROM (SELECT   ordered_item, organization_id, SUM (qty) qty,COUNT (*) COUNT FROM (SELECT   ordered_item, my, organization_id, SUM (quantity_invoiced) qty  FROM (SELECT a.*,(SELECT item_type FROM mtl_system_items        WHERE organization_id =a.organization_id AND inventory_item_id =a.inventory_item_id) item_type FROM JAN_IT.jan_sales_any_1_copy a  where organization_id in ('104','106','107','108','109')) WHERE item_type = 'FG' AND trx_date >= '" & Format(first_date, "dd-MMM-yyyy") & "'  AND trx_date < '" & Format(last_date, "dd-MMM-yyyy") & "'  GROUP BY ordered_item, my, organization_id)   GROUP BY ordered_item, organization_id ) AA) WHERE LAST_3_MNTH_QTY IS NOT NULL and clp is not null) WHERE average>=50 ORDER BY organization_id,ordered_item"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")


        For i = 0 To ds.Tables("result").Rows.Count - 1
            If i = 0 Then
                S = ""
                S = "<html>"
                find_org()
                S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
                S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
                table_head()
            End If
            If i > 0 Then
                If ds.Tables("result").Rows(i - 1).Item("organization_id") <> ds.Tables("result").Rows(i).Item("organization_id") Then
                    S &= "</table>"
                    file_no += 1
                    Dim objfso
                    objfso = CreateObject("Scripting.FileSystemObject")
                    X = "D:\stock out alert\stock_out_alert" & file_no & ".html"
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
            With ds.Tables("result").Rows(i)
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
        sql = "select organization_code from org_organization_definitions where organization_id='" & ds.Tables("result").Rows(i).Item("organization_id") & "'"
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            S &= "<h5><font size=2 face=Verdana>Stock Out Alert for " & dr.Item("organization_code") & " </h5>"
        End If
    End Sub
    Private Sub table_head()
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana>FG Stock<br>(nos)</u></TD><TD align=center><u><font size=1 face=Verdana>Projected <br>Stock-out Days</TD></tr>"
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        con.Close()
        con = Nothing
        End
    End Sub
End Class