Imports System.IO
Imports System.Data.OracleClient
Public Class stock_alert_consumption
    Dim average, stock, sl_no As Double
    Dim days, stock_days As Double
    Dim dr, dr1 As Odbc.OdbcDataReader
    Dim description As String
    Dim first_date, last_date As Date
    Dim file_no, item_id As Integer
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        file_no = 0
        days = 0
        average = 0
        stock = 0
        stock_days = 0
        sl_no = 0
        ds = New DataSet
        sql = "SELECT * FROM (SELECT a.*,jan_orgcode(a.organization_id)code,(SELECT segment1 FROM mtl_system_items WHERE inventory_item_id=a.inventory_item_id AND organization_id=105)item_no FROM jan_stock_consumption_table a where proj_stock_days<10) ORDER BY organization_id,item_type"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)


                If i = 0 Then
                    S = ""
                    S = "<html>"
                    S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
                    S &= "<h5><font size=2 face=Verdana>Stock Alert Consumption for " & .Item("code") & " ," & .Item("Item_type") & " </h5>"
                    S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
                    table_head()
                End If
                If i > 0 Then
                    If (ds.Tables("result").Rows(i - 1).Item("organization_id") <> ds.Tables("result").Rows(i).Item("organization_id")) Or (ds.Tables("result").Rows(i - 1).Item("item_type") <> ds.Tables("result").Rows(i).Item("item_type")) Then
                        S &= "</table>"
                        file_no += 1
                        Dim objfso
                        objfso = CreateObject("Scripting.FileSystemObject")
                        X = "D:\stock_consumption" & file_no & ".html"
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
                        S = ""
                        S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
                        S &= "<h5><font size=2 face=Verdana>Stock Alert Consumption for " & .Item("code") & " ," & .Item("Item_type") & " </h5>"
                        S &= "<h6><font size=1 face=Verdana>Run Time " & Date.Now & "</h6>"
                        table_head()
                        sl_no = 0
                    End If
                End If
                sl_no += 1
                S &= "<tr><td>" & sl_no & "</td><td>" & .Item("item_no") & "</td><td>" & .Item("description") & "</td><td align=right>" & .Item("avg_qty_per_mnth") & "</td><td align=right>" & FormatNumber(.Item("avg_qty_per_day"), 2) & "</td><td align=right>" & .Item("cur_stock") & "</td><td align=right>" & FormatNumber(.Item("proj_stock_days"), 2) & "</td></tr>"
            End With
        Next
        S &= "</TABLE>"
        S &= "</html>"
        file_no += 1
        Dim objfso1
        objfso1 = CreateObject("Scripting.FileSystemObject")
        X = "D:\stock_consumption" & file_no & ".html"
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
        S &= "<tr><TD align=center><u><font size=1 face=Verdana>Sl.No.</TD><TD align=center><u><font size=1 face=Verdana>Item No</TD><TD align=center><u><font size=1 face=Verdana>Description</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty per <br>month(nos)</TD><TD align=center><u><font size=1 face=Verdana>Avg Qty <br>per Day(nos)</TD><TD align=center><u><font size=1 face=Verdana> Stock<br>(nos)</u></TD><TD align=center><u><font size=1 face=Verdana>Projected <br>Stock-out Days</TD></tr>"
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class