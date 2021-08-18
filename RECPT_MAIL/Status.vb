Imports System.IO
Imports System.Data.OracleClient
Public Class Status
    Dim r As String
    Dim WithEvents DoIt As New DoStuffClass
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            ProgressBar1.Visible = True
            DoIt.StartValue = 0

            If rd5.Checked = True Then
                sql = "SELECT GATE_ID,(SELECT GDATE FROM JAN_GATe_HEADER WHERE GATe_ID=A.GATe_ID)GDATE ,VALIDATE_DATE,receipt_date,INSP_STATUS,insp_date,DELIVERY_STATUS,delivered_Date,VOUCHER_NOS,PAY_VOUCHER_NOS,REJECTED_QTY,RETURN_VENDOR,SUPPLIER_NAME,(SELECT DECODE(POTYPE,'Services',potype,type) from jan_gate_lines  WHERE GATe_id=A.GATE_id and rownum=1)gtype,NO_OF_ITEMS,DC_QTY,org,(select dc_no from jan_gate_header where gate_id=a.gate_id) dc,(select validated from jan_gatE_header where gate_id=a.gate_id and validated=0) validated,(select dc_date from jan_gate_header where gate_id=a.gate_id)dcdate,RECEIPT_QTY,RECEIPT_NOS,DELY_QTY FROM "

                If rd3.Checked = True Then sql &= " jan_procure_to_pay_pur a "
                If rd4.Checked = True Then sql &= " jan_procure_to_pay_osp a "
                If rdser.Checked = True Then sql &= " jan_procure_to_pay a "

                sql &= "where dc_qty>0 "
               
                'If txtrole.Text = "UNIT2" Then sql &= " and A.UNIT='UNIT2'"
                'If txtrole.Text = "UNIT1" Or txtrole.Text = "INWARD" Or txtrole.Text = "USER" Then sql &= "  and A.UNIT='UNIT1'"
                'If txtrole.Text = "VIEW" Then sql = sql
            ElseIf rd6.Checked = True Then
                sql = "select a.gate_ID,B.ORG,(select dc_no from jan_gate_header where gate_id=a.gate_id) dc,(select dc_date from jan_gate_header where gate_id=a.gate_id)dcdate,a.gdate,a.supplier_name ,DECODE(POTYPE,'Services',potype,type)gtype,b.item,b.description,b.supdcqty,b.popend ,b.potype,b.pono,b.uom,b.job,b.oper,b.osp,b.podt,(select validated from jan_gatE_header where gate_id=a.gate_id and validated=0) validated   from "

                If rd3.Checked = True Then sql &= " jan_procure_to_pay_pur a "
                If rd4.Checked = True Then sql &= " jan_procure_to_pay_osp a "
                If rdser.Checked = True Then sql &= " jan_procure_to_pay a "


                sql &= " jan_gate_lines b where to_number(a.gate_id)=to_number(b.gate_id)  "

                'If txtrole.Text = "UNIT2" Then sql &= " and A.UNIT='UNIT2'"
                'If txtrole.Text = "UNIT1" Or txtrole.Text = "INWARD" Or txtrole.Text = "USER" Then sql &= "  and A.UNIT='UNIT1'"
                'If txtrole.Text = "VIEW" Then sql = sql
            End If
            sql &= " AND"

            If receipt.Checked = False Then sql &= " to_date(gdate)>='" & Format(inwdtf.Value, "dd-MMM-yyyy") & "' and to_date(gdate)<='" & Format(inwdtto.Value, "dd-MMM-yyyy") & "' "

            If receipt.Checked = True Then sql &= " VALIDATE_DATE>=TO_DATE('" & Format(inwdtf.Value, "dd/MM/yyyy") & " 00:00:00','DD/MM/YYYY HH24:MI:SS') and VALIDATE_DATE<=TO_DATE('" & Format(inwdtto.Value, "dd/MM/yyyy") & " 23:59:00','DD/MM/YYYY HH24:MI:SS')"

            If Rd1.Checked = True Then sql = sql
            If Rd2.Checked = True Then sql &= " and delivered_date is not null and voucher_nos is null"
            'If rd3.Checked = True Then sql &= " and (SELECT DECODE(POTYPE,'Services',potype,type) from jan_gate_lines  WHERE GATe_id=A.GATE_id and rownum=1)='PO'"
            ' If rd4.Checked = True Then sql &= " and (SELECT DECODE(POTYPE,'Services',potype,type) from jan_gate_lines  WHERE GATe_id=A.GATE_id and rownum=1)='OSP'"
            If rdser.Checked = True Then sql &= "and (SELECT DECODE(POTYPE,'Services',potype,type) from jan_gate_lines  WHERE GATe_id=A.GATE_id and rownum=1)='Services'"

            If ComboBox1.SelectedItem = "Delivered" Then sql &= " and RECEIPT_QTY=DELY_QTY"
            If ComboBox1.SelectedItem = "Not Delivered" Then sql &= " and insp_date is null"

            If cmborg.SelectedItem <> "" Then sql &= " and a.org='" & cmborg.SelectedItem & "'"

            If receipt.Checked = True Then
                sql &= " and a.receipt_nos is null and to_date(gdate)>='1-jan-2009'"
                r = sql
                sql = " sELECT * FROM (" & r & " ) where   validated=0 "
            End If

            If cmborder.SelectedItem = "Gate No" Then sql &= " order by to_number(gate_id)"
            If cmborder.SelectedItem = "Supplier" Then sql &= " order by supplier_name"

            adap = New OracleDataAdapter(sql, con)
            Dim dsp As New DataSet
            adap.Fill(dsp, "resultab")
            DoIt.StartValue = 0
            DoIt.CountLoop()
            Dim X As String
            X = "D:\GATEREG.HTML"
            Dim fstrm As New FileStream(X, FileMode.Create, FileAccess.Write)
            Dim sw As New StreamWriter(fstrm)
            Dim S, GDATE, VENDOR, GTYPE, NITEM, DCQTY, MRIRNO, MRIRDT, MRIRQTY, IDATE, VDATE, DDATE, VNO, PVNO, REJQTY, RVENDOR, DEL, JOB, OPER, OSP As String
            S = "<html><H3 ALIGN=CENTER><FONT SIZE=2 FONT FACE=VERDANA>GATE ENTRY STATUS REPORT-"
            If Rd1.Checked = True Then S &= "" & Rd1.Text & ""
            If Rd2.Checked = True Then S &= "" & Rd2.Text & ""
            If receipt.Checked = True Then S &= "" & receipt.Text & ""

            S &= "<BR>"
            S &= " Gate Date:" & Format(inwdtf.Value, "dd-MMM-yyyy") & " || To: " & Format(inwdtto.Value, "dd-MMM-yyyy") & " <br> Gate Type:"
            If rd3.Checked = True Then S &= "" & rd3.Text & ""
            If rd4.Checked = True Then S &= "" & rd4.Text & ""
            If rdser.Checked = True Then S &= "" & rdser.Text & ""

            S &= "</FONT></H3>"
            If rd5.Checked = True Then
                S &= "<table border=1 cellspacing=0 cellpading=0 align=CENTER width=800><TR><TH><FONT SIZE=1 FONT FACE=VERDANA>SNO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE.DATE</FONT><TH><FONT SIZE=1 FONT FACE=VERDANA>ORG</FONT></TH></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>SUPPLIER</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GTYPE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>NO ITEMS</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>VALIDATE DT</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>MRIR QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>INSP DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DEL QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DEL DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>VOUCHER NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>PAYMENT</FONT></TH><TH><FONT SIZE=1 FoNT FACE=VERDANA>REJ QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>RETURN VENDOR</FONT></TH></TR>"

                Dim i, j As Integer
                j = 0
                For i = 0 To dsp.Tables("RESULTAB").Rows.Count - 1
                    j = j + 1
                    With dsp.Tables("RESULTAB").Rows(i)
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
            ElseIf rd6.Checked = True Then
                S &= "<table border=1 cellspacing=0 cellpading=0 align=CENTER width=800><TR><TH><FONT SIZE=1 FONT FACE=VERDANA>SNO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE NO</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GATE.DT</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>ORG</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>SUPPLIER</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>GTYPE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.NO<br>DATE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>PO.TYPE</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>ITEM<br>DESCRIPTION</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>PO.NO<br>DT</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>POPEND</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>DC.QTY</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>UOM</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>JOB</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>OPERATION</FONT></TH><TH><FONT SIZE=1 FONT FACE=VERDANA>OSP.NO</FONT></TH></TR>"
                Dim i, j As Integer
                j = 0

                For i = 0 To dsp.Tables("RESULTAB").Rows.Count - 1
                    j = j + 1
                    With dsp.Tables("RESULTAB").Rows(i)
                        If .Item("JOB").ToString <> "" Then JOB = .Item("JOB").ToString Else JOB = "-"
                        If .Item("OPER").ToString <> "" Then OPER = .Item("OPER").ToString Else OPER = "-"
                        If .Item("OSP").ToString = "" Then OSP = "-" Else OSP = .Item("OSP").ToString

                        S &= "<TR><Td><FONT SIZE=1 FONT FACE=VERDANA>" & j & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("GATE_id") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("GDATE") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("ORG") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("SUPPLiER_NAME") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("GTYPE") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("dc") & "<br>" & .Item("dcdate") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("POTYPE") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("ITEM") & "<br>" & .Item("DESCRIPTION") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("PONO") & " <br>" & .Item("PODT") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("POPEND") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("SUPDCQTY") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & .Item("UOM") & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & JOB & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & OPER & "</FONT></Td><Td><FONT SIZE=1 FONT FACE=VERDANA>" & OSP & "</FONT></Td></TR>"
                    End With
                Next
            End If
            DoIt.StartValue = 0
            DoIt.CountLoop()
            S = S & "</table></html>"
            sw.WriteLine(S)
            fstrm.Flush()
            sw.Flush()
            sw.Close()
            fstrm.Close()
            System.Diagnostics.Process.Start(X)
            ProgressBar1.Visible = False
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        cmborder.SelectedItem = "Gate No"
        sql = "select organization_code  from org_organization_definitions where organization_code  not in('I08','I09')order by organization_code"
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "resultab")
        Dim i As Integer
        For i = 0 To ds.Tables("resultab").Rows.Count - 1
            cmborg.Items.Add(ds.Tables("resultab").Rows(i).Item("organization_code"))
        Next
    End Sub
End Class