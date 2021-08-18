Imports System.IO
Imports System.Data.OracleClient
Public Class Stock_Excess_Alert
    Dim average, stock, sl_no, num As Double
    Dim days, stock_days As Double
    Dim dr, dr1 As Odbc.OdbcDataReader
    Dim description, tail As String
    Dim first_date, last_date, today_date, attendance_dt As Date
    Dim file_no, item_id, line, mailing_count, interval, dept_no As Integer
    Private Sub btn_create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create.Click
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
        sql = "SELECT * FROM (SELECT ORDERed_item,organization_id,jan_orgcode(organization_id)org,ROUND(qty/COUNT)average,(select (fg_stores+staging+spares+service+bda_store-reserved_qty) from jan_rg1_prod where item=BB.ORDERED_ITEM)un_alloted,(select description from mtl_system_items where segment1=BB.ORDERED_ITEM and rownum=1)description FROM(SELECT AA.*,(SELECT SUM(quantity_invoiced) FROM JAN_IT.jan_sales_any_1_copy WHERE  ORDERED_ITEM=AA.ORDERED_ITEM AND organization_id=aa.organization_id AND TRX_DATE>=TRUNC (TRUNC (SYSDATE, 'MM') - 90,'MM') AND trx_date<'" & Format(last_date, "dd-MMM-yyyy") & "') LAST_3_MNTH_QTY,(SELECT DECODE(clp,0,sclp,clp) FROM jan_clp_pricelist WHERE item_no=aa.ordered_item)clp FROM (SELECT   ordered_item, organization_id, SUM (qty) qty,COUNT (*) COUNT FROM (SELECT   ordered_item, my, organization_id, SUM (quantity_invoiced) qty  FROM (SELECT a.*,(SELECT item_type FROM mtl_system_items        WHERE organization_id =a.organization_id AND inventory_item_id =a.inventory_item_id) item_type FROM JAN_IT.jan_sales_any_1_copy a  where organization_id in ('106','107','108','109')) WHERE item_type = 'FG' AND trx_date >= '" & Format(first_date, "dd-MMM-yyyy") & "'  AND trx_date < '" & Format(last_date, "dd-MMM-yyyy") & "'  GROUP BY ordered_item, my, organization_id)   GROUP BY ordered_item, organization_id ) AA)BB WHERE LAST_3_MNTH_QTY IS NOT NULL and clp is not null) WHERE average>=50 ORDER BY organization_id,ordered_item"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = ""
        S = "<html>"
        S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
        S &= "<h6><font size=1 face=Verdana >Stock Excess Alert</h6>"
        'S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Organization</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Excess<br>Stock Qty</TD></tr>"
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
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
                    Case "I02"
                        org_day = 30
                    Case "I03"
                        org_day = 20
                    Case "I04"
                        org_day = 15
                    Case "I05"
                        org_day = 15
                End Select
                If stock_days > org_day Then
                    sl_no += 1

                    S &= "<tr><td>" & sl_no & "</td><td>" & .Item("org") & "</td><td>" & .Item("ordered_item") & "</td><td>" & .Item("description") & "</td><td align=right>" & Math.Round(stock - (org_day * days)) & "</td></tr>"
                    '<td align=right>" & average & "</td><td align=right>" & FormatNumber(days, 2) & "</td><td align=right>" & stock & "</td>
                End If
            End With
        Next
        S &= "</TABLE>"
        S &= "</html>"
        Dim objfso1
        objfso1 = CreateObject("Scripting.FileSystemObject")
        X = "D:\stock Excess Alert.html"
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
        System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub table_head()
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Organization</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Excess<br>Stock Qty</TD></tr>"
        '<TD align=center><u><font size=1 face=Verdana>Avg Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana>FG Stock<br>(nos)</u></TD>
    End Sub
    Private Sub Stock_Excess_Alert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "select trunc(sysdate-180) frm_date from dual"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        first_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, ds.Tables("result").Rows(0).Item("frm_date")), Date.MinValue)
        last_date = DateAdd(DateInterval.Month, DateDiff(DateInterval.Month, Date.MinValue, Today()), Date.MinValue)
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
End Class