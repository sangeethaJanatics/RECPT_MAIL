Imports System.IO
Imports System.Data.OracleClient
Public Class rma

    Private Sub RMAReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RMAReturnReportToolStripMenuItem.Click
        rma_receipt1.Show()
    End Sub
    Private Sub RMAReturnDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RMAReturnDetailsToolStripMenuItem.Click
        Panel1.Visible = True
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        RMA_RECEIPT.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub RegionWiseRmaReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegionWiseRmaReturnToolStripMenuItem.Click
        Rma_region.Show()
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'Credit_note_entry.Show()
        Sales_Return_Login.Show()
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Panel1.Visible = False
        S = ""
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table width=80% align=center class=tab>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        'TRN No,TRN Date,Customer Name,Invoice No,Invoice Date,RMA No,RMA Date
        S &= "<tr><TD align=center><font size=1 face=Verdana><b>TRN No</TD><TD align=center><font size=1 face=Verdana><b>TRN Date</TD><TD align=center><font size=1 face=Verdana><b>Customer Name</TD><TD align=center><font size=1 face=Verdana><b>Invoice No</TD><TD align=center><font size=1 face=Verdana><b>Invoice Date</TD><TD align=center><font size=1 face=Verdana><b>RMA No</TD><TD align=center><font size=1 face=Verdana><b>RMA Date</TD><TD align=center><font size=1 face=Verdana><b>MODVAT Claimed</TD><td><b>Reason for Return</td><TD align=center><font size=1 face=Verdana><b>Value</TD><td><b>Region</td><td><b>Customer Class Code</td><th>Credit Note No</th><th>Credit Value </th></tr>"
        ds = New DataSet
        sql = "SELECT a.trn_no,credit_note_no,credit_value,TRUNC(rma_dt)trn_date,(SELECT CUSTOMER_NAME FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""customer Name"",(SELECT inv_no FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""Invoice No"",(SELECT TO_DATE(INV_DT,'YYYY-MM-DD HH24:MI:SS') FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""Invoice Date"",a.rma_no ""RMA No"",(SELECT TRUNC(RMA_DATE) FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""RMA Date"",(SELECT MODVAT_FLAG FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)""MODVAT Flag"",(SELECT SUM((QUANTITY_RECEIVED*UNIT_SELLING_PRICE)) FROM jan_rma_listing WHERE rma_number=a.rma_no )""Value"" ,(SELECT region FROM jan_rma_listing WHERE rma_number=a.rma_no and rownum=1 )region,(SELECT RETURN_REASON FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)reason,(SELECT customer_class_code FROM jan_rma_listing WHERE rma_number=a.rma_no AND ROWNUM=1)customer_class_code FROM jan_rma_return a "
        sql &= " where  rma_no in (select rma_number from jan_rma_listing where rma_date>'" & Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), "dd-MMM-yyyy") & "' and rma_date<'" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "') "
        sql &= "  ORDER BY rma_dt"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S &= "<tr><td align=right>" & .Item("trn_no") & "</td><td align=left>" & .Item("trn_date") & "</td><td align=left>" & .Item("customer Name") & "</td><td align=left>" & .Item("Invoice No") & "</td><td align=left>" & .Item("Invoice Date") & "</td><td align=right>" & .Item("RMA No") & "</td><td align=left>" & .Item("RMA Date") & "</td><td align=left>" & .Item("MODVAT Flag") & "</td><td>" & .Item("reason") & "</td>"

                S &= " <td align=right>" & .Item("Value") & "</td><td>" & .Item("region") & "</td><td>" & .Item("customer_class_code") & "</td><td>" & .Item("credit_note_no") & "</td><td align=right>" & .Item("credit_value") & "</td></tr>"
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

    Private Sub ServiceReturnRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceReturnRegisterToolStripMenuItem.Click
        Credit_note_entry.Show()
    End Sub
End Class