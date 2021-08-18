Imports System.Data.OracleClient
Imports System.IO
Imports System.Web.Mail
Public Class receipt_mail
    Dim WithEvents DoIt As New DoStuffClass
    Dim I, S_NO, h As Integer
    Dim r As String
    Dim X1, Y1 As String
    Private Sub UpdateProgressBar(ByVal MyCountInteger As Integer) Handles DoIt.OnProgress
        ToolStripProgressBar1.Value = MyCountInteger
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        criterua_combo.Items.Add("Not Delivered-Inspection Completed before 12:00 PM")
        criterua_combo.Items.Add("RTV Pending")
        criterua_combo.Items.Add("Job Store Pending")
        DateTimePicker1.Value = "01/04/2009"
        DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, Date.Today)
        For h = 0 To criterua_combo.Items.Count - 1
            criterua_combo.Text = criterua_combo.Items(h)
            btn_go_Click(sender, e)
        Next
        Me.Close()
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        r = ""
        dgv1.Columns.Clear()
        ToolStripProgressBar1.Visible = True
        ToolStripStatusLabel1.Visible = True
        DoIt.StartValue = 0
        DoIt.StartValue = 0
        DoIt.CountLoop()
        ds = New DataSet
        If criterua_combo.Text = "Not Delivered-Inspection Completed before 12:00 PM" Then
            If radbtn_osp.Checked = True Then
                sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,VENDOR_NAME,PONO,PODT,PARTNO,PARTNAME,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_osp_listing a where to_date(receipt_date2) >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and receipt_date2 <= TO_DATE('" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & " 12:00:00','DD/MM/YYYY HH:MI:SS')  and QUANTITY_RECEIVED=(QTY_APPD+QTY_REJD) AND QUANTITY_RECEIVED<>QTY_DLYD  and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID),DIVISION "
            ElseIf radbtn_po.Checked = True Then
                sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,PONO,PODT,VENDOR_NAME,ITEM_NO,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_pur_listing a where  to_date(receipt_date2) >='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and receipt_date2 <= TO_DATE('" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & " 12:00:00','DD/MM/YYYY HH:MI:SS') and QUANTITY_RECEIVED=(QTY_APPD+QTY_REJD) AND QUANTITY_RECEIVED<>QTY_DLYD   and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID) ,DIVISION"
            End If
        ElseIf criterua_combo.Text = "RTV Pending" Then
            If radbtn_osp.Checked = True Then
                sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,VENDOR_NAME,PONO,PODT,PARTNO,PARTNAME,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_osp_listing a where receipt_date >=TO_DATE('" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & " 00:00:00','DD/MM/YYYY HH24:MI:SS') and receipt_date <=TO_DATE('" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & " 23:59:00','DD/MM/YYYY HH24:MI:SS') and quantity_received=qty_dlyd and qty_rejd<>0   and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID),DIVISION "
            ElseIf radbtn_po.Checked = True Then
                sql = "select (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)org,DIVISION,RECEIPT_NUM,RECEIPT_DATE,PONO,PODT,VENDOR_NAME,ITEM_NO,ITEM_DESCRIPTION,INSP_DT,DELIVERED_DT,QUANTITY_RECEIVED,QTY_APPD,QTY_REJD,QTY_DLYD  from jan_pur_listing a where  receipt_date >=TO_DATE('" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & " 00:00:00','DD/MM/YYYY HH24:MI:SS') and receipt_date <=TO_DATE('" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & " 23:59:00','DD/MM/YYYY HH24:MI:SS') and quantity_received=qty_dlyd and qty_rejd<>0 and vendor_return<qty_rejd  and QUANTITY_RECEIVED>=0 order by (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID) ,DIVISION"
            End If
        ElseIf criterua_combo.Text = "Receipt Pending" Then
            sql = "SELECT GATE_ID,(SELECT GDATE FROM JAN_GATe_HEADER WHERE GATe_ID=A.GATe_ID)GDATE ,VALIDATE_DATE,receipt_date,INSP_STATUS,insp_date,DELIVERY_STATUS,delivered_Date,VOUCHER_NOS,PAY_VOUCHER_NOS,REJECTED_QTY,RETURN_VENDOR,SUPPLIER_NAME,(SELECT DECODE(POTYPE,'Services',potype,type) from jan_gate_lines  WHERE GATe_id=A.GATE_id and rownum=1)gtype,NO_OF_ITEMS,DC_QTY,org,(select dc_no from jan_gate_header where gate_id=a.gate_id) dc,(select validated from jan_gatE_header where gate_id=a.gate_id and validated=0) validated,(select dc_date from jan_gate_header where gate_id=a.gate_id)dcdate,RECEIPT_QTY,RECEIPT_NOS,DELY_QTY FROM "
            If radbtn_po.Checked = True Then sql &= " jan_procure_to_pay_pur a "
            If radbtn_osp.Checked = True Then sql &= " jan_procure_to_pay_osp a "
            sql &= "where dc_qty>0  and"
            sql &= " VALIDATE_DATE>=TO_DATE('" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & " 00:00:00','DD/MM/YYYY HH24:MI:SS') and VALIDATE_DATE<=TO_DATE('" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & " 23:59:00','DD/MM/YYYY HH24:MI:SS')"
            sql &= " and a.receipt_nos is null and to_date(gdate)>='1-jan-2009'"
            r = sql
            sql = " SELECT * FROM (" & r & " ) where   validated=0 "
        ElseIf criterua_combo.Text = "Job Store Pending" Then
            sql = "SELECT (SELECT organization_code FROM org_organization_definitions WHERE organization_id=a.organization_id) org,job_no,job_dt,item_no,rev,description,opn_seq,lot_move quantity,TRUNC(comp_dt)comp_dt,res_code,ITEM_TYPE,resourc,osp_isp inhouse_osp,assy_target,(SELECT category FROM jan_counting_category WHERE a.item_cost BETWEEN from_value AND to_value AND organization_id=a.organization_id)category,NVL((SELECT location FROM jan_store_location_view WHERE inventory_item_id=a.inventory_item_id AND organization_id=a.organization_id AND ROWNUM=1),'-')location   FROM jan_final_operations a WHERE  comp_dt>='" & Format(DateTimePicker1.Value, "dd/MMM/yyyy") & "' and comp_dt<'" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "dd/MMM/yyyy") & "' order by organization_id  asc"
        End If
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        DoIt.StartValue = 0
        DoIt.CountLoop()
        adap.Fill(ds, "receipt")
        dgv1.DataSource = ds.Tables("receipt")
        ToolStripProgressBar1.Visible = False
        ToolStripStatusLabel1.Visible = False
        S_NO = 0
        S = ""
        Dim objfso

        objfso = CreateObject("Scripting.FileSystemObject")
        If (criterua_combo.Text = "Not Delivered-Inspection Completed before 12:00 PM") And (radbtn_po.Checked = True) Then

            X1 = "D:\Purchase - Delivered Pending.xls"
            If objfso.FileExists(X1) Then
                objfso.DeleteFile(X1)
            End If
        ElseIf (criterua_combo.Text = "Not Delivered-Inspection Completed before 12:00 PM") And (radbtn_osp.Checked = True) Then
            Y1 = "D:\OSP - Delivered Pending.xls"
            If objfso.FileExists(Y1) Then
                objfso.DeleteFile(Y1)
            End If
        ElseIf (criterua_combo.Text = "Receipt Pending") And (radbtn_po.Checked = True) Then
            X1 = "D:\Purchase - Receipt Pending From " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " To " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & ".html"
            If objfso.FileExists(X1) Then
                objfso.DeleteFile(X1)
            End If
        ElseIf (criterua_combo.Text = "Receipt Pending") And (radbtn_osp.Checked = True) Then
            Y1 = "D:\OSP - Receipt Pending From " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " To " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & ".html"
            If objfso.FileExists(Y1) Then
                ' objfso.DeleteFile(Y1)
            End If
        ElseIf (criterua_combo.Text = "RTV Pending") And (radbtn_po.Checked = True) Then
            X1 = "D:\Purchase - Rtv pending.xls"
            If objfso.FileExists(X1) Then
                objfso.DeleteFile(X1)
            End If
        ElseIf criterua_combo.Text = "Job Store Pending" Then
            X1 = "D:\Job Store Pending.xls"
            If objfso.FileExists(X1) Then
                objfso.DeleteFile(X1)
            End If
        End If

        If radbtn_osp.Checked = True Then
            Dim FSTRM1 As FileStream = New FileStream(Y1, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)
            If criterua_combo.Text = "Receipt Pending" Then
                receipt_pending()
            Else
                head_OSP()
            End If
            SW1.WriteLine(S)
            FSTRM1.Flush()
            SW1.Flush()
            SW1.Close()
            FSTRM1.Close()
        ElseIf radbtn_po.Checked = True Then
            Dim FSTRM As FileStream = New FileStream(X1, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim SW As StreamWriter = New StreamWriter(FSTRM)
            If criterua_combo.Text = "Receipt Pending" Then
                receipt_pending()
            ElseIf criterua_combo.Text = "Job Store Pending" Then
                job_store_pending()
            Else
                head_po()
            End If
            SW.WriteLine(S)
            FSTRM.Flush()
            SW.Flush()
            SW.Close()
            FSTRM.Close()
        End If
        MessageBox.Show("File created", "Mail sending", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btn_sendMail_Click(sender, e)
        'System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub job_store_pending()
        S_NO = 0
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=17 align=center><b>JOB STORE PENDING FROM " & Format(CDate(DateTimePicker1.Value), "dd-MMM-yyyy") & " TO " & Format(CDate(DateTimePicker2.Value), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>JOB NO</td><td>JOB DATE</td><td>ITEM NO</td><td>REV</td><td>DESCRIPTION</td><td>OPEN SEQ</td><td>QUANTITY</td><td>COMP DT</td><td>RES CODE</td><td>ITEM TYPE</td><td>RESOURCE</td><td>INHOUSE_OSP</td><td>ASSY_TARGET</td><td>CATEGORY</td><td>LOCATION</td></tr>"
        For I = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            With ds.Tables("receipt")
                S_NO += 1
                If I = 0 Then
                    S &= "<tr><td align=center>" & S_NO & "</td><td>" & .Rows(I).Item("org") & "</td><td>" & .Rows(I).Item("job_no") & "</td><td align=left>" & .Rows(I).Item("job_dt") & "</td><td align=left>" & .Rows(I).Item("item_no") & "</td><td>" & .Rows(I).Item("rev") & "</td><td>" & .Rows(I).Item("description") & "</td><td>" & .Rows(I).Item("opn_seq") & "</td><td>" & .Rows(I).Item("quantity") & "</td><td>" & .Rows(I).Item("comp_dt") & "</td><td>" & .Rows(I).Item("res_code") & "</td><td>" & .Rows(I).Item("item_type") & "</td><td>" & .Rows(I).Item("resourc") & "</td><td>" & .Rows(I).Item("inhouse_osp") & "</td><td>" & .Rows(I).Item("assy_target") & "</td><td>" & .Rows(I).Item("category") & "</td><td>" & .Rows(I).Item("location") & "</td></tr>"
                Else
                    If .Rows(I).Item("org") <> .Rows(I - 1).Item("org") Then
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
                        S &= "<tr><td align=center>" & S_NO & "</td><td>" & .Rows(I).Item("org") & "</td><td>" & .Rows(I).Item("job_no") & "</td><td align=left>" & .Rows(I).Item("job_dt") & "</td><td align=left>" & .Rows(I).Item("item_no") & "</td><td>" & .Rows(I).Item("rev") & "</td><td>" & .Rows(I).Item("description") & "</td><td>" & .Rows(I).Item("opn_seq") & "</td><td>" & .Rows(I).Item("quantity") & "</td><td>" & .Rows(I).Item("comp_dt") & "</td><td>" & .Rows(I).Item("res_code") & "</td><td>" & .Rows(I).Item("item_type") & "</td><td>" & .Rows(I).Item("resourc") & "</td><td>" & .Rows(I).Item("inhouse_osp") & "</td><td>" & .Rows(I).Item("assy_target") & "</td><td>" & .Rows(I).Item("category") & "</td><td>" & .Rows(I).Item("location") & "</td></tr>"
                    Else
                        S &= "<tr><td align=center>" & S_NO & "</td><td>" & .Rows(I).Item("org") & "</td><td>" & .Rows(I).Item("job_no") & "</td><td align=left>" & .Rows(I).Item("job_dt") & "</td><td align=left>" & .Rows(I).Item("item_no") & "</td><td>" & .Rows(I).Item("rev") & "</td><td>" & .Rows(I).Item("description") & "</td><td>" & .Rows(I).Item("opn_seq") & "</td><td>" & .Rows(I).Item("quantity") & "</td><td>" & .Rows(I).Item("comp_dt") & "</td><td>" & .Rows(I).Item("res_code") & "</td><td>" & .Rows(I).Item("item_type") & "</td><td>" & .Rows(I).Item("resourc") & "</td><td>" & .Rows(I).Item("inhouse_osp") & "</td><td>" & .Rows(I).Item("assy_target") & "</td><td>" & .Rows(I).Item("category") & "</td><td>" & .Rows(I).Item("location") & "</td></tr>"
                    End If
                End If
            End With
        Next
    End Sub
    Private Sub receipt_pending()
        Dim GDATE, VENDOR, GTYPE, NITEM, DCQTY, MRIRNO, MRIRDT, MRIRQTY, IDATE, VDATE, DDATE, VNO, PVNO, REJQTY, RVENDOR, DEL As String 'JOB, OPER, OSP
        S &= "<html><H3 ALIGN=CENTER><FONT SIZE=2 FONT FACE=VERDANA>GATE ENTRY STATUS REPORT-"
        If radbtn_po.Checked = True Then S &= "" & radbtn_po.Text & ""
        If radbtn_osp.Checked = True Then S &= "" & radbtn_osp.Text & ""
        S &= "Receipt Pending"

        S &= "<BR>"
        S &= " Gate Date:" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & " || To: " & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & " <br> Gate Type:"
        If radbtn_po.Checked = True Then S &= "" & radbtn_po.Text & ""
        If radbtn_osp.Checked = True Then S &= "" & radbtn_osp.Text & ""
        S &= "</FONT></H3>"
        'If rd5.Checked = True Then
        S &= "<table border=1 cellspacing=0 cellpading=0 align=CENTER width=800><TR><TH><FONT SIZE=1 FONT FACE=VERDANA>SNO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE.DATE</FONT><TH><FONT SIZE=1 FONT FACE=VERDANA>ORG</FONT></TH></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>SUPPLIER</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GTYPE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>NO ITEMS</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>VALIDATE DT</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>INSP DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DEL QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DEL DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>VOUCHER NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>PAYMENT</FONT></TH><TH><FONT SIZE=1 FoNT FACE=VERDANA>REJ QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>RETURN VENDOR</FONT></TH></TR>"

        Dim j As Integer = 0
        For I = 0 To ds.Tables("receipt").Rows.Count - 1
            j = j + 1
            With ds.Tables("receipt").Rows(I)
                GDATE = .Item("GDATE").ToString
                If .Item("SUPPLIER_NAME").ToString <> "" Then VENDOR = .Item("SUPPLIER_NAME").ToString Else VENDOR = "-"
                If .Item("GTYPE").ToString <> "" Then GTYPE = .Item("GTYPE").ToString Else GTYPE = "-"
                If .Item("NO_OF_ITEMS").ToString <> "" Then NITEM = .Item("NO_OF_ITEMS").ToString Else NITEM = "-"
                If .Item("DC_QTY").ToString <> "" Then DCQTY = .Item("DC_QTY").ToString Else DCQTY = "-"
                If .Item("DELY_QTY").ToString <> "" Then DEL = .Item("DELY_QTY").ToString Else DEL = "-"
                If .Item("RECEIPT_NOS").ToString <> "" Then MRIRNO = .Item("RECEIPT_NOS").ToString Else MRIRNO = "-"
                If .Item("RECEIPT_DATE").ToString <> "" Then MRIRDT = .Item("RECEIPT_DATE").ToString Else MRIRDT = "-"
                If .Item("RECEIPT_QTY").ToString <> "" Then MRIRQTY = .Item("RECEIPT_QTY").ToString Else MRIRQTY = "-"
                If .Item("INSP_DATE").ToString <> "" Then IDATE = .Item("INSP_DATE").ToString Else IDATE = "-"
                If .Item("VALIDATE_DATE").ToString <> "" Then VDATE = .Item("VALIDATE_DATE").ToString Else VDATE = "-"
                If .Item("DELIVERED_DATE").ToString <> "" Then DDATE = .Item("DELIVERED_DATE").ToString Else DDATE = "-"
                If .Item("VOUCHER_NOS").ToString <> "" Then VNO = .Item("VOUCHER_NOS").ToString Else VNO = "-"
                If .Item("PAY_VOUCHER_NOS").ToString <> "" Then PVNO = .Item("PAY_VOUCHER_NOS").ToString Else PVNO = "-"
                If .Item("RETURN_VENDOR").ToString <> "" Then RVENDOR = .Item("RETURN_VENDOR").ToString Else RVENDOR = "-"
                If .Item("rejected_qty").ToString = "" Then REJQTY = "-" Else REJQTY = .Item("rejected_qty").ToString

                S &= "<TR><Td><FONT SIZE=1 FONT FACE=VERDANA>" & j & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("GATE_ID") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & GDATE & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("ORG") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & VENDOR & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & GTYPE & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("dc") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("dcdate") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & NITEM & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & DCQTY & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & VDATE & " </FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & MRIRNO & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & MRIRDT & " </FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & MRIRQTY & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & IDATE & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & DEL & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & DDATE & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & VNO & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & PVNO & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & REJQTY & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & RVENDOR & "</FONT></Td></TR>"
            End With
        Next
        'DoIt.StartValue = 0
        'DoIt.CountLoop()
        S = S & "</table></html>"
        'sw.WriteLine(S)
        'fstrm.Flush()
        'sw.Flush()
        'sw.Close()
        'fstrm.Close()
    End Sub
    Private Sub head_OSP()
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=17 align=center><b>OSP-DELIVERED PENDING  FROM " & Format(CDate(DateTimePicker1.Value), "dd-MMM-yyyy") & " TO " & Format(CDate(DateTimePicker2.Value), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>DIVISION</td><td>RECEIPT-NO</td><td>RECEIPT_DT</td><td>VENDOR</td><td>PONO</td><td>PODT</td><td>PART NO</td><td>PART NAME</td><td>DESCRIPTION</td><td>INS_DT</td><td>DEL_DT</td><td>RECD</td><td>APPD</td><td>REJ</td><td>DELIVERED</td></tr>"
        For I = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            If I < ds.Tables("receipt").Rows.Count - 1 Then
                If ds.Tables("RECEIPT").Rows(I).Item("ORG") = ds.Tables("RECEIPT").Rows(I + 1).Item("ORG") Then
                    If ds.Tables("RECEIPT").Rows(I).Item("org") = "I07" Then
                        If ds.Tables("RECEIPT").Rows(I).Item("DIVISION").ToString = ds.Tables("RECEIPT").Rows(I + 1).Item("DIVISION").ToString Then
                            function3()
                            GoTo last
                        Else
                            function4()
                            GoTo last
                        End If
                    End If
                    function3()
last:
                Else
                    function4()
                End If
            Else
                If ds.Tables("RECEIPT").Rows(I).Item("ORG") = ds.Tables("RECEIPT").Rows(I - 1).Item("ORG") Then
                    S_NO += 1
                Else
                    S_NO = 1
                End If
                S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNO") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNAME") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
            End If
        Next
        S &= "</table>"
    End Sub
    Private Sub function4()
        S_NO += 1
        S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S_NO = 0
    End Sub
    Private Sub function3()
        S_NO += 1
        S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PARTNAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
    End Sub
    Private Sub head_po()
        Dim title As String
        If criterua_combo.Text = "RTV Pending" Then
            title = "PURCHASE - RTV PENDING"
        Else
            title = "PURCHASE-DELIVERED PENDING"
        End If
        S &= "<table border=0 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td colspan=16 align=center><b> " & title & " FROM " & Format(CDate(DateTimePicker1.Value), "dd-MMM-yyyy") & " TO " & Format(CDate(DateTimePicker2.Value), "dd-MMM-yyyy") & " </td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td align=center>SNO</td><td>ORG</td><td>DIVISION</td><td>RECEIPT-NO</td><td>RECEIPT_DT</td><td>PONO</td><td>PODT</td><td>VENDOR</td><td>PART NO</td><td>DESCRIPTION</td><td>INS_DT</td><td>DEL_DT</td><td>RECD</td><td>APPD</td><td>REJ</td><td>DELIVERED</td></tr>"
        For I = 0 To ds.Tables("RECEIPT").Rows.Count - 1
            If I < ds.Tables("receipt").Rows.Count - 1 Then
                If ds.Tables("RECEIPT").Rows(I).Item("ORG") = ds.Tables("RECEIPT").Rows(I + 1).Item("ORG") Then
                    If ds.Tables("RECEIPT").Rows(I).Item("org") = "I07" Then
                        If ds.Tables("RECEIPT").Rows(I).Item("DIVISION").ToString = ds.Tables("RECEIPT").Rows(I + 1).Item("DIVISION").ToString Then
                            function1()
                            GoTo last
                        Else
                            function2()
                            GoTo last
                        End If
                    End If
                    function1()
last:
                Else
                    function2()
                End If
            Else
                If ds.Tables("RECEIPT").Rows(I).Item("ORG") = ds.Tables("RECEIPT").Rows(I - 1).Item("ORG") Then
                    S_NO += 1
                Else
                    S_NO = 1
                End If
                S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_NO") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
                S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
                S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
            End If
        Next
        S &= "</table>"
    End Sub
    Private Sub function1()
        S_NO += 1
        S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_NO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
    End Sub
    Private Sub function2()
        S_NO += 1
        S &= "<TR><TD align=center> " & S_NO & "</TD><TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ORG") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DIVISION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_NUM") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("RECEIPT_DATE") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PONO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("PODT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("VENDOR_NAME") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_NO") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("ITEM_DESCRIPTION") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("INSP_DT") & "</TD>"
        S &= "<TD align=left>" & ds.Tables("RECEIPT").Rows(I).Item("DELIVERED_DT") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QUANTITY_RECEIVED") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_APPD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_REJD") & "</TD>"
        S &= "<TD align=right>" & ds.Tables("RECEIPT").Rows(I).Item("QTY_DLYD") & "</TD></TR>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>"
        S_NO = 0
    End Sub
    Private Sub btn_sendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sendMail.Click
        '==============================================code to send mail
        Dim strArgs() As String = Command.Split(",")
        Dim blnSMTP As Boolean = False
        Dim tail As String = "@janatics.co.in"
        'Dim insMail As New MailMessage()
        'With insMail
        If criterua_combo.Text = "RTV Pending" Then
            'Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "GNB" & tail & "")
            Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "it-dev7" & tail & "")
            'mailer.CC.Add("it-dev7" & tail & "")
            'mailer.CC.Add("SATHISH" & tail & "")
            'mailer.CC.Add("CKV" & tail & "")
            'mailer.CC.Add("LALITHA" & tail & "")
            'mailer.CC.Add("NAGANATHAN" & tail & "")
            'mailer.CC.Add("PUR-STAFF" & tail & "")
            mailer.Subject = "RTV PENDING - REG"
            mailer.Body = "Dear Sirs," & vbNewLine & vbNewLine & "        Please find attached herewith excel   document consists of RTV pending from purchase  date " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " to " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & "." & vbNewLine & vbNewLine & "Regards," & vbNewLine & "C.K.Venkatachalapathy"
            mailer.Attachments.Add(New System.Net.Mail.Attachment(X1))
            mailer.Priority = Net.Mail.MailPriority.Normal
            mailer.IsBodyHtml = True
            Dim SmtpMail As New Net.Mail.SmtpClient
            SmtpMail.Host = "mail.janatics.co.in"
            SmtpMail.Send(mailer)
        ElseIf criterua_combo.Text = "Not Delivered-Inspection Completed before 12:00 PM" Then
            'Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "GNB" & tail & "")
            Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "it-dev7" & tail & "")
            'mailer.CC.Add("it-dev7" & tail & "")
            'mailer.CC.Add("SATHISH" & tail & "")
            'mailer.CC.Add("CKV" & tail & "")
            'mailer.CC.Add("LALITHA" & tail & "")
            'mailer.CC.Add("NAGANATHAN" & tail & "")
            'mailer.CC.Add("PUR-STAFF" & tail & "")
            'mailer.CC.Add("SAMIKANNU" & tail & "")
            'mailer.CC.Add("RADHA" & tail & "")
            'mailer.CC.Add("RAMESH-PRODN" & tail & "")
            'mailer.CC.Add("KALIRAJ" & tail & "")
            'mailer.CC.Add("RAJU" & tail & "")
            'mailer.CC.Add("JAYARAMAN" & tail & "")
            'mailer.CC.Add("IED-STAFF" & tail & "")
            'mailer.CC.Add("santhanam" & tail & "")
            'mailer.CC.Add("subash" & tail & "")
            'mailer.CC.Add("rndstaff1" & tail & "")
            mailer.Subject = "Pending Delivered to store"
            mailer.Body = "Dear Sirs," & vbNewLine & vbNewLine & "        Please find attached herewith excel   document consists of list of receipts to be delivered to stores from purchase and Osp date " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " to " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & "  : 12:00 pm." & vbNewLine & vbNewLine & "Regards," & vbNewLine & "C.K.Venkatachalapathy"
            mailer.Attachments.Add(New System.Net.Mail.Attachment(X1))
            'mailer.Attachments.Add(New System.Net.Mail.Attachment(Y1))
            mailer.Priority = Net.Mail.MailPriority.Normal
            mailer.IsBodyHtml = True
            Dim SmtpMail As New Net.Mail.SmtpClient
            SmtpMail.Host = "mail.janatics.co.in"
            SmtpMail.Send(mailer)
        ElseIf criterua_combo.Text = "Job Store Pending" Then
            'Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "GNB" & tail & "")
            Dim mailer As New System.Net.Mail.MailMessage("it-dev7" & tail & "", "it-dev7" & tail & "")
            'mailer.CC.Add("it-dev7" & tail & "")
            'mailer.CC.Add("SATHISH" & tail & "")
            'mailer.CC.Add("CKV" & tail & "")
            'mailer.CC.Add("LALITHA" & tail & "")
            'mailer.CC.Add("NAGANATHAN" & tail & "")
            'mailer.CC.Add("PUR-STAFF" & tail & "")
            'mailer.CC.Add("SAMIKANNU" & tail & "")
            'mailer.CC.Add("RADHA" & tail & "")
            'mailer.CC.Add("RAMESH-PRODN" & tail & "")
            'mailer.CC.Add("KALIRAJ" & tail & "")
            'mailer.CC.Add("RAJU" & tail & "")
            'mailer.CC.Add("JAYARAMAN" & tail & "")
            'mailer.CC.Add("IED-STAFF" & tail & "")
            'mailer.CC.Add("santhanam" & tail & "")
            'mailer.CC.Add("subash" & tail & "")
            'mailer.CC.Add("rndstaff1" & tail & "")
            mailer.Subject = "Job Store Pending"
            mailer.Body = "Dear Sirs," & vbNewLine & "              Please find attached herewith excel   document consists of list of jobs to be delivered to stores from  " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " to " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & " ." & vbNewLine & vbNewLine & "    Regards," & vbNewLine & "   C.K.Venkatachalapathy"
            mailer.Attachments.Add(New System.Net.Mail.Attachment(X1))
            mailer.Priority = Net.Mail.MailPriority.Normal
            mailer.IsBodyHtml = True
            Dim SmtpMail As New Net.Mail.SmtpClient
            SmtpMail.Host = "mail.janatics.co.in"
            SmtpMail.Send(mailer)
        ElseIf criterua_combo.Text = "Receipt Pending" Then
            '.From = "IT-DEV7" & tail & ""
            '.To = "BHARATHI" & tail & ""
            '.Cc = "SATHISH" & tail & ",IT-DEV7" & tail & ""
            '.Subject = "RECEIPT PENDING - REG"
            '.Body = "Dear Madam," & vbNewLine & vbNewLine & "        Please find attached herewith document consists of receipt pending list from purchase & OSP date " & Format(DateTimePicker1.Value, "dd.MM.yyyy") & " to " & Format(DateTimePicker2.Value, "dd.MM.yyyy") & " ." & vbNewLine & vbNewLine & "Regards," & vbNewLine & " Sathish Kumar"
            '.Attachments.Add(New MailAttachment(X1))
            '.Attachments.Add(New MailAttachment(Y1))
        End If
        ' End With
        MessageBox.Show("Completed", "Receipt Mail Sending", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    'Private Sub criterua_combo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles criterua_combo.SelectedValueChanged
    '    If criterua_combo.Text = "RTV Pending" Then
    '        radbtn_osp.Enabled = False
    '        radbtn_po.Enabled = True
    '    ElseIf criterua_combo.Text = "Not Delivered-Inspection Completed before 12:00 PM" Then
    '        radbtn_osp.Enabled = True
    '        radbtn_po.Enabled = True
    '    ElseIf criterua_combo.Text = "Job Store Pending" Then
    '        radbtn_osp.Enabled = False
    '        radbtn_po.Enabled = False
    '        radbtn_po.Checked = True
    '    End If
    'End Sub
End Class
