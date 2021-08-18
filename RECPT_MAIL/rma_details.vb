Imports System.IO
Imports System.Data.OracleClient

Public Class rma_details

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        S = ""
        S = "<html>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        'TRN No,TRN Date,Customer Name,Invoice No,Invoice Date,RMA No,RMA Date
        S &= "<tr><TD align=center><font size=1 face=Verdana><b>TRN No</TD><TD align=center><font size=1 face=Verdana><b>TRN Date</TD><TD align=center><font size=1 face=Verdana><b>Customer Name</TD><TD align=center><font size=1 face=Verdana><b>Invoice No</TD><TD align=center><font size=1 face=Verdana><b>Invoice Date</TD><TD align=center><font size=1 face=Verdana><b>RMA No</TD><TD align=center><font size=1 face=Verdana><b>RMA Date</TD><TD align=center><font size=1 face=Verdana><b>MODVAT Claimed</TD><td><b>Reason for Return</td><TD align=center><font size=1 face=Verdana><b>Value</TD><td><b>Region</td></TD><td><b>Customer Class Code</td><td><b>org</td></tr>"
        ds = New DataSet
        sql = "SELECT a.trn_no,TRUNC(rma_dt)trn_date,(SELECT CUSTOMER_NAME FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""customer Name"",(SELECT inv_no FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""Invoice No"",(SELECT TO_DATE(INV_DT,'YYYY-MM-DD HH24:MI:SS') FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""Invoice Date"",a.rma_no ""RMA No"",(SELECT TRUNC(RMA_DATE) FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""RMA Date"",(SELECT MODVAT_FLAG FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""MODVAT Flag"",(SELECT SUM((QUANTITY_RECEIVED*UNIT_SELLING_PRICE)) FROM jan_rma_listing WHERE rma_number=a.rma_no )""Value"" ,(SELECT region FROM jan_rma_listing WHERE rma_number=a.rma_no and rownum=1 )region,(SELECT RETURN_REASON FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)reason,(SELECT CUSTOMER_CLASS_CODE FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)CUSTOMER_CLASS_CODE,rowtocol('SELECT distinct jan_orgcode(to_organization_id) FROM jan_rma_listing WHERE rma_number='||a.rma_no||'')org  FROM jan_rma_return a ORDER BY rma_dt"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S &= "<tr><td align=right>" & .Item("trn_no") & "</td><td align=left>" & .Item("trn_date") & "</td><td align=left>" & .Item("customer Name") & "</td><td align=left>" & .Item("Invoice No") & "</td><td align=left>" & .Item("Invoice Date") & "</td><td align=right>" & .Item("RMA No") & "</td><td align=left>" & .Item("RMA Date") & "</td><td align=left>" & .Item("MODVAT Flag") & "</td><td>" & .Item("reason") & "</td><td align=right>" & .Item("Value") & "</td><td>" & .Item("region") & "</td><td>" & .Item("CUSTOMER_CLASS_CODE") & "</td><td>" & .Item("org") & "</td> </tr>"
            End With
        Next
        S &= "</html>"
        S &= "</table>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\rma_return_list.html"

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

    Private Sub rma_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class