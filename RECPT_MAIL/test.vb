Imports System.Media
Imports System.IO

Imports InfoSoftGlobal
Imports InfoSoftGlobal.FusionCharts
Imports System.Xml

Imports System.Data.OracleClient
Public Class test

    Private Sub dgv_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        '   Avoids rows or columns out of data area
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        '   Checks if it's painting percent column
        If e.ColumnIndex = 1 OrElse e.ColumnIndex = 3 OrElse e.ColumnIndex = 5 Then



            '   Get data row
            Dim oRow As DataRow = DirectCast(dgv.Rows(e.RowIndex).DataBoundItem, DataRowView).Row

            '   Tells to DataGridView that we will take care of painting cell
            e.Handled = True

            '   Selects bar color based on percent value.
            Dim oColor As Drawing.Color = Color.Green
            'If oRow.percent < _ciTarget Then oColor = Color.Red

            '   Draws cell with bar
            Bar.PintaDegradado(oColor, e, oRow.Item("comp_color"))
            Bar.PintaDegradado(oColor, e, oRow.Item("rm_color"))
            Bar.PintaDegradado(oColor, e, oRow.Item("sa_color"))

            'If CheckBox1.Checked Then
            '    Bar.PintaDegradado(oColor, e, oRow.percent, _ciTarget, Color.Orange)
            'Else
            '    Bar.PintaDegradado(oColor, e, oRow.percent)

            'End If
            '--------------------------Original Code Follows---------------------------

            ' ''   Avoids rows or columns out of data area
            ''If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

            ' ''   Checks if it's painting percent column
            ''If e.ColumnIndex <> Columns.Percent Then Exit Sub

            ' ''   Get data row
            ''Dim oRow As DataSet1.DataRow = _
            ''    DirectCast(DataGridView1.Rows(e.RowIndex).DataBoundItem, DataRowView).Row

            ' ''   Tells to DataGridView that we will take care of painting cell
            ''e.Handled = True

            ' ''   Selects bar color based on percent value.
            ''Dim oColor As Drawing.Color = Color.Green
            ''If CheckBox1.Checked AndAlso oRow.percent < _ciTarget Then oColor = Color.Red

            ' ''   Draws cell with bar
            ''If CheckBox1.Checked Then
            ''    Bar.PintaDegradado(oColor, e, oRow.percent, _ciTarget, Color.Orange)
            ''Else
            ''    Bar.PintaDegradado(oColor, e, oRow.percent)
            ''End If
        End If

    End Sub
    Private Sub display_data()

        S = "<HTML><HEAD><BODY>"
        S &= "<STYLE type='text/css'>.tab1 {font-family:Arial;font-size:10pt;}</STYLE>"
        S &= "<STYLE type='text/css'>.tab2 {font-family:Arial;font-size:11pt;}</STYLE>"
        S &= "<STYLE type='text/css'>.tab {font-family:Arial;font-size:8pt;color:white;}</STYLE>"
        S &= "<STYLE type='text/css'>.tab3 {font-family:Arial;font-size:7pt;color:Navy;}</STYLE>"
        'If Session.Item("mis_for") = "m2o" Then


        'm2o Measurement round(AVG(COMPLETED_PERCENT))COMPLETED_PERCENT

        sql = "SELECT  PROD_CAT,WK,SUM(NO_OF_ORDERS)TOTAL_ORDER,SUM(COMPLETED_WITHIN_TARGET)COMPLETED_WITHIN_TARGET,round((SUM(COMPLETED_WITHIN_TARGET)/SUM(NO_OF_ORDERS)*100)) COMPLETED_PERCENT,SUM(SLIPPAGE)SLIPPAGE,SUM(ASSEMBLY)ASSEMBLY,SUM(MATERIALS)MATERIALS,SUM(PLANNING)PLANNING,round(AVG(ASSEMBLY_PER))ASSEMBLY_PER,round(AVG(MATERIAL_PER))MATERIALS_PER,round(AVG(PLANNING_PER))PLANNING_PER FROM  JAN_7DAYS_MIS_WEEK_TAB  WHERE "

        sql &= " PROD_CAT='Rn' "

        sql &= " and org='I03'"

        sql &= " GROUP BY PROD_CAT, WK ORDER BY WK"
        adap = New OracleDataAdapter(sql, con)
        ds.Tables.Clear()
        adap.Fill(ds, "data")


        S = " <TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2 CLASS=TAB  BORDER=1% > "
        S &= " <tr bgcolor=cornflowerblue class=tab>"

        S &= "<td  colspan=1 rowspan=2><font color=white>Year / Week</td><td  colspan=1 rowspan=2><font color=white>Total No. of Orders</td><td align=center colspan=2><font color=white>Completed Within Target</td>"

        S &= "</tr><tr bgcolor=cornflowerblue class=tab>"
        S &= "<td colspan=1><font color=white>No. of Orders</td><td  colspan=1><font color=white>%</td>"

        S &= "</tr>"

        For i = 0 To ds.Tables("data").Rows.Count - 1
            With ds.Tables("data").Rows(i)

                S &= "<tr><td>" & .Item("wk") & "</td><td align=right>" & .Item("TOTAL_ORDER") & "</td><td align=right>" & .Item("COMPLETED_WITHIN_TARGET") & "</td><td align=right>" & .Item("COMPLETED_PERCENT") & "</td>"

                S &= "</tr> "
            End With
        Next
        S &= "</table>"


        'lbl_runner.Text = S
        'Literal_rn.Text = Ru_Chart(j)

               
    End Sub
    Public Function Ru_Chart(ByVal chart_for As Integer)

        Dim strCaption As String = ""
        If chart_for = 0 Then strCaption = "Runner(completion Status)"
        If chart_for = 1 Then strCaption = "Repeater(completion Status)"
        If chart_for = 2 Then strCaption = "Stranger(completion Status)"
        Dim strSubCaption As String = ""
        Dim xAxis As String = "Week No"
        Dim yAxis As String = "Percentage"
        Dim strXML As String
        strXML = ""
        strXML = "<graph caption='" & strCaption & "' " & vbCr & vbLf & "            subcaption='" & strSubCaption & "'" & vbCr & vbLf & "            hovercapbg='ff5904' hovercapborder='ff5904' formatNumberScale='0' decimalPrecision='2' " & vbCr & vbLf & "            showvalues='0' numdivlines='3' numVdivlines='0' yaxisminvalue='100.00' yaxismaxvalue='100.00'  " & vbCr & vbLf & "            rotateNames='1'" & vbCr & vbLf & "            showAlternateHGridColor='1' AlternateHGridColor='FF00FF' divLineColor='ff5904'    divLineAlpha='20' alternateHGridAlpha='5' " & vbCr & vbLf & "            xAxisName='" & xAxis & "' yAxisName='" & yAxis & "' baseFontColor='5F9EA0' >  "

        Dim j As Integer
        strXML &= "<categories font='Arial' fontSize='11' fontColor='CD853F'>"
        For I = 0 To DS.Tables("data").Rows.Count - 1
            strXML &= " <category name='" & DS.Tables("data").Rows(I).Item("wk").ToString().Trim() & "' />"
        Next
        strXML &= " </categories>"

        strXML &= "<dataset  color='00FFFF' anchorBorderColor='FF0000' anchorBgColor='FF0000'>"
        For j = 0 To DS.Tables("data").Rows.Count - 1
            strXML &= " <set value='" & DS.Tables("data").Rows(j).Item("COMPLETED_PERCENT").ToString().Trim() & "'  link=&quot;JavaScript:myJS('" & DS.Tables("data").Rows(j).Item("COMPLETED_PERCENT").ToString() & ", " & DS.Tables("data").Rows(j).Item("COMPLETED_PERCENT").ToString() & "');&quot; />"
        Next
        strXML &= "</dataset>"
        strXML &= "</graph>"
        'Return FusionChSarts.RenderChartHTML("FusionCharts/FCF_MSLine.swf", "", strXML, "mygraph10", 1000, 300, False)

    End Function
    Private Sub qr_code()
        Dim text_to_write As String = "TATAINVOICE"
        S = "^XA" & vbNewLine
        S &= "^MMT" & vbNewLine
        S &= "^PW599" & vbNewLine
        S &= "^LL0305" & vbNewLine
        S &= "^LS0" & vbNewLine

        S &= "^^FT249,277^A0N,28,28^FH\^FD" & text_to_write & "^FS" & vbNewLine
        'S &= "^FT107,61^A0N,31,31^FH\^FD" & VENDOR_NAME & "^FS" & vbNewLine

        S &= "^FT242,230^BQN,2,6" & vbNewLine
        S &= "^FH\^FDLA," & text_to_write & "^FS" & vbNewLine
        S &= "^PQ1,0,1,Y^XZ" & vbNewLine

        Dim OBJFSO As Object
        OBJFSO = CreateObject("Scripting.FileSystemObject")

        X = "D:\INV_PRINT\stickerZPL.prn"
        Dim fstrm As FileStream = New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim sw As StreamWriter = New StreamWriter(fstrm)
        'Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        'Dim SW As StreamWriter = New StreamWriter(fstrm)
        sw.WriteLine(S)
        fstrm.Flush()
        sw.Flush()
        sw.Close()
        fstrm.Close()



        'Dim FSTRM1 As FileStream = New FileStream("C:\LOT\sticker.bat", FileMode.Create, FileAccess.ReadWrite)
        'Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)
        'SW1.WriteLine("COPY " & X & " \\localhost\TSC")
        'SW1.Close()
        'FSTRM1.Close()
        'Shell("C:\LOT\sticker.bat", AppWinStyle.Hide)


    End Sub

    Private Sub test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("http://api.hostip.info/?ip=68.180.206.184")
        qr_code()


        sql = "select sys_context( 'userenv', 'HOST' )hostname  from dual"

        ds = SQL_SELECT("res", sql)
        TextBox1.Text = ds.Tables("res").Rows(0).Item("hostname")
        'System.Media.SystemSounds.Hand.Play()
        'System.Media.SystemSounds.Beep.Play()
        'My.Computer.Audio.Play("c:\jps\WA.WAV", AudioPlayMode.BackgroundLoop)


        'display_data()
        '<td style="height: 17px">
        ' &nbsp;<asp:Literal ID="Literal_fg_ALL_org" runat="server" Mode="PassThrough"></asp:Literal></td>
        'Dim week_no, tot_value As Integer
        'week_no = 0
        'tot_value = 0
        'ds = New DataSet
        'sql = "select organization_id,round(sum(jan_dsp_order_qty*p_rate)/4 )val from (select a.*,nvl((select round(pval) from jan_prate where INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID),0)p_rate from JAN_ANUBHAV_JAN_DSP a where customer_despatch_bucket='Monthly') group by ORGANIZATION_ID"
        'adap = New OracleDataAdapter(sql, con)
        'adap.Fill(ds, "res")

        'For i = 0 To ds.Tables("RES").Rows.Count - 1
        '    With ds.Tables("res").Rows(i)
        '        tot_value = 0
        '        ds1 = New DataSet
        '        sql = "select distinct inventory_item_id,jan_dsp_order_qty ,jan_dsp_order_qty*nvl((select round(pval) from jan_prate where INVENTORY_ITEM_ID=a.INVENTORY_ITEM_ID),0)val from JAN_ANUBHAV_JAN_DSP  a where jan_dsp_order_qty>0 and organization_id=" & .Item("organization_id") & " and customer_despatch_bucket='Monthly'"
        '        adap = New OracleDataAdapter(sql, con)
        '        adap.Fill(ds1, "item")

        '        For j = 0 To ds1.Tables("item").Rows.Count - 1

        '            If j = 0 Then week_no = 1
        '            sql = "UPDATE JAN_ANUBHAV_JAN_DSP SET week" & week_no & "=" & ds1.Tables("item").Rows(j).Item("jan_dsp_order_qty") & " WHERE inventory_item_id=" & ds1.Tables("item").Rows(j).Item("inventory_item_id") & " and organization_id=" & .Item("organization_id") & " "
        '            comand()
        '            tot_value += ds1.Tables("item").Rows(j).Item("val")
        '            If (j) Mod 4 = 0 Then
        '                week_no = 1
        '            Else
        '                week_no += 1
        '            End If
        '            'If tot_value <= .Item("val") Then
        '            '    week_no = week_no
        '            'Else
        '            '    week_no += 1
        '            '    tot_value = 0
        '            'End If
        '        Next
        '    End With

        'Next
        'dgv.DataSource = ds.Tables("res")


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Process.Start("http://192.168.0.2/dealer_despatch_plan/br_main.ASPX?rights=BANGALORE")
        'Process.Start("http://192.168.0.2/XXXX/FRM.ASPX?rights=HO")
    End Sub
End Class