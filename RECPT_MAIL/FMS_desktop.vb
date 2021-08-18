Imports System.Data
Imports System.Net
Imports System.Data.OracleClient
Imports System.Data.OleDb
Imports System.IO
Imports System.DateTime
Imports System.Globalization
Imports System.Xml

Public Class FMS_desktop
    Dim ADAP, adapg As New OleDb.OleDbDataAdapter
    Dim s As String
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.237.129 ;initial catalog=jan_FMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim cmd_sql As New OleDb.OleDbCommand
    Dim todays_file As String = Format(Date.Today, "yyyMMdd")

    Private Sub FMS_desktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PictureBox1.Image = Global.RECPT_MAIL.My.Resources.Resources.images


        'PictureBox1.Image = C : \Users\edp005\Desktop\Reports\logo.jpg

        'PictureBox1.Image = Global.RECPT_MAIL.My.Resources.jana_logo

        'Exit Sub
        'sync_data()
        Timer1.Enabled = True
        Timer1.Start()

        Try
            'sync_data()
            'display_result()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub display_result()



        Try

            'Dim file_name As String = "" & todays_file & ".csv"
            Dim fi As New FileInfo("L: \Flow-meter\out\" & todays_file & "_copy.csv")
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & fi.DirectoryName
            'Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & fi.DirectoryName
            Dim READING_DATE As Date
            Dim conn As New OleDbConnection(connectionString)
            conn.Open()

            'the SELECT statement is important here, 
            'and requires some formatting to pull dates and deal with headers with spaces.
            'Dim cmdSelect As New OleDbCommand("Select Foo, Bar, FORMAT(""SomeDate"",'YYYY/MM/DD') AS SomeDate, ""SOME MULTI WORD COL"", FROM " & fi.Name, conn)
            Dim cmdSelect As New OleDbCommand("SELECT  SLAVE_ID,	GROUP_ID,	FLOW_VALUE,	DIGITAL_INPUT ,	 FORMAT(Date,'DD-MM-YYYY') AS Reading_date,format(time,'hh:mm:ss')as reading_time FROM " & fi.Name & " ", conn)
            'Dim cmdSelect As New OleDbCommand("SELECT  	sum(FLOW_VALUE)FLOW_VALUE FROM " & fi.Name & " where flow_value=3.29 ", conn)
            Dim adapter1 As New OleDbDataAdapter
            adapter1.SelectCommand = cmdSelect

            'Dim ds As New DataSet
            adapter1.Fill(ds1, "DATA")
            Dim k, k1 As Object
            k = ds1.Tables("DATA").Compute("avg(FLOW_VALUE)", "FLOW_VALUE>=0")
            k = ds1.Tables("DATA").Compute("max(reading_time)", "SLAVE_ID='4-'")
            Me.Text = "Flow Staus As on " & ds1.Tables("DATA").Compute("max(Reading_date)", "SLAVE_ID='4-'") & " at " & k
            'DGV1.DataSource = ds.Tables(0).DefaultView
            conn.Close()
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create("Machine_master.xml", New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)

            ds.Tables(0).Columns.Add("flow_value")
            ds.Tables(0).Columns.Add("status")
            ds.Tables(0).Columns.Add("order_by")
            For i = 0 To ds.Tables(0).Rows.Count - 1
                k = ds1.Tables("DATA").Compute("max(reading_time)", "SLAVE_ID='" & ds.Tables(0).Rows(i).Item("FLOW_METER_ID") & "'")
                k1 = ds1.Tables("DATA").Compute("avg(FLOW_VALUE)", "SLAVE_ID='" & ds.Tables(0).Rows(i).Item("FLOW_METER_ID") & "' and reading_time='" & k & "'")
                ds.Tables(0).Rows(i).Item("flow_value") = Math.Round(k1, 2)
            Next

            'Code to calculte the status color

            For i = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(i)
                    Try

                        If .Item("flow_value") >= .Item("alert_flow") Then
                            If .Item("flow_value") >= .Item("recommended_flow") Then
                                .Item("status") = "red"
                                .Item("order_by") = 1
                            Else
                                .Item("status") = "Orange"
                                .Item("order_by") = 2
                            End If
                        Else
                            If .Item("flow_value") >= .Item("recommended_flow") Then
                                .Item("status") = "red"
                                .Item("order_by") = 1
                            Else
                                .Item("status") = "Green"
                                .Item("order_by") = 3
                            End If

                        End If
                    Catch ex As Exception

                    End Try
                End With
            Next
            Dim dvTable As DataView = ds.Tables(0).DefaultView
            If Rad_high_cons.Checked = True Then dvTable.Sort = "order_by ASC"


            'DGV1.DataSource = ds.Tables(0)
            'DGV1.Visible = False
            'If Rad_high_cons.Checked = True Then ds.Tables(0).DefaultView.Sort = "order_by asc"
            s = ""
            s& = " <table border=""1""  cellpadding =""20"" cellspacing =""0"" style =""border-color :white ;align-items :center;font-family :Verdana ,Arial   "">"
            s &= "  <tr style =""font-weight :bold ;color :white ;border-style :dotted"">"
            For i = 0 To dvTable.Count - 1
                With dvTable(i)
                    s &= "  <td style =""background-color :" & .Item("status") & "  ;width :10% "" >MC-" & .Item("flow_meter_id") & "</td> "
                End With
            Next
            'For i = 0 To dvTable.Count - 1
            '    With dvTable(i)
            '        s &= "  <td style =""background-color :" & .Item("status") & "  ;width :10% "" >MC-" & .Item("flow_meter_id") & "</td> "
            '    End With
            'Next
            s &= " </tr>"
            s &= "  <tr  cellpadding =""10""  style =""background-color :lightsteelblue;border-style :dotted ""><td  colspan=""6"" align=""center"" > <b>Flow in CFM</b></td></tr>"
            s &= " <tr style =""background-color :aliceblue;border-style :dotted "">"
            For i = 0 To dvTable.Count - 1
                With dvTable(i)
                    s &= " <td ><b>Running</b><br /><br />" & .Item("flow_value") & "</td> "
                End With
            Next
            'For i = 0 To dvTable.Count - 1
            '    With dvTable(i)
            '        s &= " <td ><b>Running</b><br /><br />" & .Item("flow_value") & "</td> "
            '    End With
            'Next
            s &= " </tr>"
            s &= "  <tr style =""background-color :lightsteelblue ;border-style :dotted"">"
            For i = 0 To dvTable.Count - 1
                With dvTable(i)
                    s &= " <td ><b>Idle</b><br /><br />" & Format(0, "0.00") & "</td> "
                End With
            Next
            'For i = 0 To dvTable.Count - 1
            '    With dvTable(i)
            '        s &= " <td ><b>Idle</b><br /><br />" & Format(0, "0.00") & "</td> "
            '    End With
            'Next
            's &= " <td ><b>Idle</b><br /><br />0</td><td><b>Idle</b><br /><br />0</td><td><b>Idle</b><br /><br />0</td>"
            s &= " </tr>"

            s &= "  </table>"

            WebBrowser1.DocumentText = s
            'Exit Sub

        Catch ex As Exception

        End Try
        Timer1.Start()
    End Sub


    Private Sub DGV1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV1.CellFormatting

        For Each dvr As DataGridViewRow In DGV1.Rows
            Try
                Dim sty As New DataGridViewCellStyle
                If Val(dvr.Cells("flow_value").Value) >= Val(dvr.Cells("alert_flow").Value) Then
                    If Val(dvr.Cells("flow_value").Value) >= Val(dvr.Cells("recommended_flow").Value) Then

                        sty.BackColor = Color.Red
                        dvr.Cells(0).Style = sty
                        dvr.Cells(1).Style = sty
                        dvr.Cells(2).Style = sty
                        dvr.Cells(3).Style = sty
                    Else
                        sty.BackColor = Color.Orange
                        dvr.Cells(0).Style = sty
                        dvr.Cells(1).Style = sty
                        dvr.Cells(2).Style = sty
                        dvr.Cells(3).Style = sty
                    End If
                Else

                    sty.BackColor = Color.Green
                    dvr.Cells(0).Style = sty
                    dvr.Cells(1).Style = sty
                    dvr.Cells(2).Style = sty
                    dvr.Cells(3).Style = sty
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub
    Private Sub btn_show_value_Click(sender As Object, e As EventArgs)
        display_result()
    End Sub
    Private Sub btn_sync_fms_master_Click(sender As Object, e As EventArgs)
        sync_data()

    End Sub

    Private Sub Rad_high_cons_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_high_cons.CheckedChanged
        If Rad_high_cons.Checked = True Then
            display_result()
        End If

    End Sub

    Private Sub Rad_dashboard_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_dashboard.CheckedChanged
        If Rad_dashboard.Checked = True Then
            display_result()
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Timer1.Tag = True Then
            Timer1.Tag = False

            Try
                My.Computer.FileSystem.DeleteFile("L:\Flow-meter\out\" & todays_file & "_copy.csv")
            Catch ex As Exception

            End Try
            My.Computer.FileSystem.CopyFile("L:\Flow-meter\out\" & todays_file & ".csv", "L:\Flow-meter\out\" & todays_file & "_copy.csv", True)
            Timer1.Stop()
            display_result()
        Else
            Timer1.Tag = True
        End If
    End Sub

    Private Sub link_sync_data_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_sync_data.LinkClicked
        sync_data()
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Dim fi As New FileInfo("L:\Flow-meter\out\20201109.csv")
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & fi.DirectoryName
        Dim READING_DATE As Date
        Dim conn As New OleDbConnection(connectionString)
        conn.Open()

        'the SELECT statement is important here, 
        'and requires some formatting to pull dates and deal with headers with spaces.
        'Dim cmdSelect As New OleDbCommand("SELECT Foo, Bar, FORMAT(""SomeDate"",'YYYY/MM/DD') AS SomeDate, ""SOME MULTI WORD COL"", FROM " & fi.Name, conn)
        Dim cmdSelect As New OleDbCommand("SELECT SLAVE_ID,	GROUP_ID,	FLOW_VALUE,	DIGITAL_INPUT ,	 FORMAT(Date,'DD-MM-YYYY') AS Reading_date,format(time,'hh:mm:ss')as reading_time FROM " & fi.Name, conn)
        Dim adapter1 As New OleDbDataAdapter
        adapter1.SelectCommand = cmdSelect

        Dim ds As New DataSet
        adapter1.Fill(ds, "DATA")
        'DataGridView1.DataSource = ds.Tables(0).DefaultView
        conn.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            READING_DATE = Convert.ToDateTime(ds.Tables(0).Rows(0).Item("reading_date"))
        End If

        sql = "delete from jan_flow_meter_lines_stg WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()

        For i = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(i)
                Try

                    sql = " insert into jan_flow_meter_lines_STG(flow_meter_id,air_flow,Running_ideal,reading_date,reading_time,GROUP_ID) values('" & .Item("SLAVE_ID") & "'," & .Item("FLOW_VALUE") & "," & .Item("DIGITAL_INPUT") & " "
                    sql &= "  ,'" & Convert.ToDateTime(.Item("reading_date")) & "' "
                    'sql &= ",'2020-10-17' "
                    sql &= ",'" & .Item("reading_time").ToString.Substring(0, 8) & "'"
                    sql &= " ,'" & .Item("GROUP_ID") & "')"

                    cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
                    If dms_con.State = ConnectionState.Closed Then dms_con.Open()
                    cmd_sql.ExecuteNonQuery()

                Catch ex As Exception

                End Try
            End With
        Next


        sql = "delete from jan_flow_meter_lines WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
        sql = " insert into jan_flow_meter_lines(flow_meter_id,air_flow,running_ideal,reading_date,reading_time_1,group_id)

select flow_meter_id,round(avg(air_flow),2)air_flow,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm'))ss,group_id
from jan_flow_meter_lines_STG a WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'
group by flow_meter_id,running_ideal,reading_date,concat(format(reading_time,'hh'),':',format(reading_time,'mm')),group_id"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()
        MessageBox.Show("Data uploading to cloud  Completed", "FMS Data uploading", MessageBoxButtons.OK)
    End Sub

    Private Sub sync_data()
        Try


            sql = "SELECT FLOW_METER_ID,MACHINE_NAME,MACHINE_MODEL,MACHINE_MAKE,(select recommended_flow from JAN_FMS_MASTER  where flow_meter_id=a.flow_meter_id)recommended_flow "
            sql &= " ,(select alert_flow from JAN_FMS_MASTER  where flow_meter_id=a.flow_meter_id)alert_flow"
            sql &= " FROM JAN_FMS_MILL_VS_MACHINE a  WHERE FLOW_METER_ID  Is Not NULL 
ORDER  BY FLOW_METER_ID,MACHINE_NAME,MACHINE_MODEL,MACHINE_MAKE"

            If dms_con.State = ConnectionState.Closed Then
                dms_con.Open()
            End If
            ADAP = New OleDb.OleDbDataAdapter(sql, dms_con)
            ADAP.Fill(ds, "DATA")

            If dms_con.State = ConnectionState.Open Then
                dms_con.Close()
            End If
            DGV1.DataSource = ds.Tables("data")

            ds.WriteXml("Machine_master.xml")
            MessageBox.Show("Data syncing Done", "AFMS Data syncing", MessageBoxButtons.OK)
        Catch ex As Exception

        End Try
    End Sub
End Class