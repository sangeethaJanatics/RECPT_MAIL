Imports System.IO
Imports System.Data.OracleClient
Public Class rma_receipt1
    Dim i, count, PAGE_NO, NO_OF_LINES As Integer
    Dim rma_dt As Date
    Dim trn_no As String
    Dim total As Double
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        total = 0
        ds = New DataSet
        sql = "SELECT RECEIPT_NUM,RECEIPT_DT,SEGMENT1 ITEM_NO,QUANTITY_RECEIVED,trunc(RMA_DATE)RMA_DATE,ITEM_DESCRIPTION,CUSTOMER_NAME,INV_NO,to_date(INV_DT,'YYYY-MM-DD HH24:MI:SS')INV_DT,(SELECT ORGANIZATION_CODE FROM ORG_ORGANIZATION_DEFINITIONS WHERE ORGANIZATION_ID=A.TO_ORGANIZATION_ID)ORG,RETURN_REASON,nvl(MODVAT_FLAG,'-')MODVAT_FLAG,SHIPMENT_LINE_ID, (SELECT  SUBSTR(bill_to_address,1,80) FROM JAN_BMS_ORDER_PENDING_NEW_V WHERE ORDER_NUMBER=A.RMA_NUMBER AND ROWNUM=1) reg,(QUANTITY_RECEIVED*UNIT_SELLING_PRICE)value,JANATICS_INV_NO||','||JANATICS_INV_DT jan_inv,(select docu_type from jan_rma_return where rma_no=a.RMA_NUMBER)docu_type FROM JAN_RMA_LISTING A  WHERE QUANTITY_RECEIVED>0 AND RMA_NUMBER='" & TextBox1.Text & "'"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "receipt")
        total = ds.Tables("receipt").Compute("sum(value)", "value<>0")
        If ds.Tables("receipt").Rows(0).Item("receipt_dt") >= "06-apr-2010" Then
            If ds.Tables("receipt").Rows.Count > 0 Then
                ds1 = New DataSet
                sql = "select * from jan_rma_return where rma_no='" & TextBox1.Text & "'"
                adap = New OracleDataAdapter(sql, con)
                adap.Fill(ds1, "result")
                If ds1.Tables("result").Rows.Count > 0 Then
                    trn_no = ds1.Tables("result").Rows(0).Item("trn_no")
                    rma_dt = ds1.Tables("result").Rows(0).Item("rma_dt")
                Else
                    If cmb_document_type.SelectedItem = "" Then
                        MessageBox.Show("Enter Document Type", "RMA Return", MessageBoxButtons.OK)
                        Exit Sub
                    End If


                    sql = "insert into jan_rma_return(trn_no,rma_no,rma_dt,docu_type) values(2020||jan_rma_return_seq.nextval,'" & TextBox1.Text & "',sysdate,'" & cmb_document_type.SelectedItem & "')"
                    cmd = New OracleCommand(sql, con)
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    ds1 = New DataSet
                    sql = "select * from jan_rma_return where rma_no='" & TextBox1.Text & "'"
                    adap = New OracleDataAdapter(sql, con)
                    adap.Fill(ds1, "result")
                    trn_no = ds1.Tables("result").Rows(0).Item("trn_no")
                    rma_dt = ds1.Tables("result").Rows(0).Item("rma_dt")
                End If
            End If
        End If
        Dim NAME As String
        NAME = String.Concat("M/s.", ds.Tables("receipt").Rows(0).Item("customer_name"), "<br>", ds.Tables("receipt").Rows(0).Item("reg"))

        count = 0
        S = ""
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        Dim recd_cnt, page_cnt As Double
        Dim pg_cnt, page_no As Integer
        recd_cnt = ds.Tables("receipt").Rows.Count
        page_cnt = recd_cnt / 10
        pg_cnt = Math.Ceiling(page_cnt)
        page_no = 1
        header(pg_cnt, page_no)
        S &= "<table width=100% cellpading=0 cellspacing=0 class=tab>"
        S &= "<tr><td colspan=2>&nbsp;</td></tr>"
        S &= "<tr><td colspan=2><b> Janatics Invoice No & Dt:" & ds.Tables("receipt").Rows(0).Item("jan_inv") & "</b></td></tr>"

        S &= "<tr><td colspan=2>&nbsp;</td></tr>"

        S &= "<tr><tD align=left>FROM:SERVICE DEPARTMENT</font></tD><tD align=left>TO:CENTRAL EXCISE</font></tD></tr>"
        S &= "<tr><tD align=left>Customer : " & NAME & " </tD><tD align=left>Invoice No : " & ds.Tables("receipt").Rows(0).Item("inv_no") & "</tD></tr>"

        S &= "<tr><tD align=left>&nbsp; </tD><tD align=left>&nbsp;</tD></tr>"

        If IsDBNull(ds.Tables("receipt").Rows(0).Item("inv_DT")) = True Then
            S &= "<tr><td align=left>Document Type :"
            If IsDBNull(ds.Tables("receipt").Rows(0).Item("docu_type")) Then S &= " <input type=text>" Else S &= "" & ds.Tables("receipt").Rows(0).Item("docu_type") & ""
            S &= " </td><td align=left>Invoice Date </td></tr>"
        Else
            S &= "<tr><td align=left>Document Type :"
            'S &= "<input type=text width=30px>"
            If IsDBNull(ds.Tables("receipt").Rows(0).Item("docu_type")) Then S &= " <input type=text>" Else S &= "" & ds.Tables("receipt").Rows(0).Item("docu_type") & ""
            S &= " </td><td align=left>Invoice Date " & Format(CDate(ds.Tables("receipt").Rows(0).Item("inv_DT")), "dd-MMM-yy") & "</td></tr>"
        End If

        S &= "<tr><td align=left>RMA No :" & TextBox1.Text & "</td> <td align=left>RMA Date : " & ds.Tables("receipt").Rows(0).Item("RMA_DATE") & "</t></tr>"

        S &= "<tr><td colspan=2 align=center><b>Material Receipt details</b></td></tr>"
        S &= "</table>"
        S &= "<table border=1 cellpading=0 cellspacing=0 width=100%>"
        table_head()
        page_no = 0
        For i = 0 To ds.Tables("receipt").Rows.Count - 1
            With ds.Tables("receipt").Rows(i)


                If (i Mod 18 = 0) And i <> 0 Then
                    S &= "</table>"
                    page_no += 1

                    If page_no = 1 Then
                        footer()
                    End If

                    S &= "<br style= page-break-before:always;>"
                    header(pg_cnt, page_no)

                    table_head()

                End If
                count += 1
                S &= "<tr><td align=center>" & count & "</td><td align=LEFT>" & .Item("item_no") & "</td><td align=LEFT>" & .Item("ITEM_DESCRIPTION") & "</td><td align=center>" & .Item("QUANTITY_RECEIVED") & "</td><td align=left>" & .Item("RECEIPT_NUM") & "/<br>" & Format(CDate(.Item("RECEIPT_DT")), "dd/MMM/yyyy") & "</td><td align=center>" & .Item("org") & "</td><td align=center>" & .Item("modvat_flag") & "</td><td align=right>" & .Item("value") & "</td></tr>"
            End With
        Next
        S &= "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td><font size=1 face=Verdana>Total</td><td align=right><font size=1 face=Verdana>" & total & "</td></tr>"
        S &= "</table>"
        S &= " <br><font size=2 face=Verdana>Reason For Return :" & ds.Tables("receipt").Rows(0).Item("return_reason") & ""
        S &= "<hr>"
        S &= "<font size=2 face=Verdana>Remarks:"
        S &= "<hr>"
        S &= "<H4><font size=2 face=Verdana> Items transferred to RG1 are in good condition.</H4>"
        'S &= "<br>"
        'S &= "<br>"
        'S &= "<br>"
        'S &= "<br>"

        S &= "<table border=1 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td height=50 >&nbsp;</td><td height=50 >&nbsp;</td><td height=50 >&nbsp;</td><td height=50 >&nbsp;</td><td height=50>&nbsp;</td></tr>"
        S &= "<tr><td align=center><font size=2 face=Verdana>Service Dept</td><td align=center ><font size=2 face=Verdana>Quality Assurance</td><td align=center ><font size=2 face=Verdana>Sales Dept</td><td align=center ><font size=2 face=Verdana>FG Store</td><td align=center><font size=2 face=Verdana>A/C Dept</td></tr>"
        S &= "</table>"
        'S &= "<br>"
        'S &= "<br>"
        'S &= "<br>"
        'S &= "<br>"
        If page_no = 0 Then
            footer()
        End If


        S &= "</html>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\RMA_RETURN.html"

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
        System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub header(ByVal pg_cnt As Integer, ByVal page_no As Integer)

        S &= "<table  border=1 cellpading=0 cellspacing=0 width=100%>"
        S &= "<tr><td width=160 height=50 rowspan=3><img src=""F:\OA\sal\rma\image004.JPG""></img></td><td valign=center align=center rowspan=3><font size=4 face=Verdana>TRANSACTION  RETURN   NOTE</td><td><font size=2 face=Verdana>Rec.No&nbsp;:TRN-" & trn_no & "</td></tr>"
        S &= "<tr><td><font size=2 face=Verdana>Page No.:" & page_no & " of " & pg_cnt & "</td></tr>"
        ' S &= "<tr><td><font size=2 face=Verdana>Date &nbsp; &nbsp;&nbsp;:" & Format(rma_dt, "dd-MM-yyyy") & "</td></tr>"
        S &= "<tr><td><font size=2 face=Verdana>Date &nbsp; &nbsp;&nbsp;:" & Format(ds.Tables("receipt").Rows(0).Item("RMA_DATE"), "dd-MM-yyyy") & "</td></tr>"
        S &= "</table>"
        'S &= "<br>"
        'S &= "<br>"
    End Sub
    Private Sub footer()
        S &= "</table>"
        'S &= "<br>"
        S &= "<br>"
        S &= "<table border=1 cellpading=0 cellspacing=0 width=100%>"
        S &= "<td  height=40 valign=top><font size=1 face=Verdana>Prepared</td><td  height=50 valign=top><font size=1 face=Verdana>Approved</td>"
        S &= "</table>"
        'S &= "<H4 align=left><font size=1 face=Verdana>Form No:F/OP13/15 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Issue:&nbsp;3.0&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Date:27-01-2017</H4>"
        S &= "<H4 align=left><font size=1 face=Verdana>Form No: F/CSD/11  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Issue:&nbsp;4.0&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Date:01.01.2019</H4>"
    End Sub
    Private Sub table_head()
        S &= "<br>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Item Desc</TD><TD align=center><u><font size=1 face=Verdana>Qty <br>Recd</TD><TD align=center><u><font size=1 face=Verdana>Receipt No./<br>Date</TD><TD align=center><u><font size=1 face=Verdana>Receipt Org</TD><TD align=center><u><font size=1 face=Verdana>Modvat <br> Claimed</u></TD><TD align=center><u><font size=1 face=Verdana>Return <br> Value</u></TD></tr>"
    End Sub
End Class