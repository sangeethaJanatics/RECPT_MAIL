Imports System.IO
Imports System.Data.OracleClient
Public Class stock_out_alert
    Dim average, stock, sl_no As Double
    Dim days, stock_days As Double
    Dim dr, dr1 As Odbc.OdbcDataReader
    Dim description As String
    Dim first_date, last_date As Date
    Dim file_no, item_id As Integer
    Private Sub stock_out_alert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "SELECT DISTINCT bill_to_customer_id,bill_to_cust_name FROM jan_invoice_listing WHERE trx_date='14-may-2011'"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        For j = 0 To ds.Tables("result").Rows.Count - 1
            out_standing(ds.Tables("result").Rows(j).Item("bill_to_customer_id"))
        Next

    End Sub
    Private Sub out_standing(ByVal customer_id)
        ds1 = New DataSet
        sql = "SELECT trx_date,trx_number,due_date,SUM(AMOUNT_DUE_REMAINING)out_standing FROM jan_region_payment_pending WHERE BILL_TO_CUSTOMER_ID='" & customer_id & "'  AND NAME NOT IN('Captive Consumption','Commission-CM','Captive Consumption','Commission - CM','Exhibition Sales','Projects Credit Memo','Projects Credit Memo','Projects Invoice','Projects Invoice','Purchase Return','Samples / Free Inv-1','Samples / Free Inv-2','Service Invoice','Stock Transfer - 1','Stock Transfer - 2','TDS Credit Memo') AND amount_due_remaining <> 0 GROUP BY trx_number,trx_date,due_date ORDER BY trx_date"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds1, "result")

        If ds1.Tables("result").Rows.Count > 0 Then


            S = ""
            S = "<html>"
            S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
            S &= "<h4 align=left> Payment Outstanding</h4>"
            S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=50%>"
            S &= "<tr><th>S.No.</th><th>Invoice Date</th><th>Invoice No</th><th>Due Date</th><th>Pending Amount</th></tr>"

            For i = 0 To ds1.Tables("result").Rows.Count - 1
                With ds1.Tables("result").Rows(i)
                    S &= "<tr><td align=center>" & i + 1 & "</td><td>" & .Item("trx_date") & "</td><td>" & .Item("trx_number") & "</td><td>" & .Item("due_date") & "</td><td align=right>" & Format(.Item("out_standing"), "00.00") & "</td></tr>"
                End With
            Next
            S &= "</table></html>"
        End If

        S &= "<br>"
        S &= "<br>"
        S &= "<br>"
        S &= "<html>"

        If ds1.Tables("result").Rows.Count > 0 Then
            ds1 = New DataSet
            sql = "SELECT trx_number,trx_date,NVL(inv_value,0)+NVL(tax_value,0) pending_value FROM jan_cform WHERE cform_no IS NULL AND customer_id=" & customer_id & " ORDER BY trx_date,TO_NUMBER(trx_number)"
            adap = New OracleDataAdapter(sql, con)
            adap.Fill(ds1, "result")


            S &= "<html>"
            S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
            S &= "<h4 align=left> C Form Pending</h4>"
            S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=50%>"
            S &= "<tr><th>S.No.</th><th>Invoice Date</th><th>Invoice No</th><th>Pending Amount</th></tr>"
            For i = 0 To ds1.Tables("result").Rows.Count - 1
                With ds1.Tables("result").Rows(i)
                    S &= "<tr><td align=center>" & i + 1 & "</td><td>" & .Item("trx_date") & "</td><td>" & .Item("trx_number") & "</td><td align=right>" & Format(.Item("pending_value"), "00.00") & "</td></tr>"
                End With
            Next
            S &= "</table></html>"
        End If
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click

        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\stock_out_alert" & file_no & ".html"
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
    Private Sub table_head()
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana>FG Stock<br>(nos)</u></TD><TD align=center><u><font size=1 face=Verdana>Projected <br>Stock-out Days</TD></tr>"
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        End
    End Sub
End Class