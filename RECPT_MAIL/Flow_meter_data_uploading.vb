Imports System.Data
Imports System.Net
Imports System.Data.OracleClient
Imports System.Data.OleDb
Imports System.IO
Imports System.DateTime
Imports System.Globalization


Public Class Flow_meter_data_uploading
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.237.129 ;initial catalog=jan_FMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Dim cmd_sql As New OleDb.OleDbCommand
    Private Sub Flow_meter_data_uploading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_upload_to_cloud_Click(sender As Object, e As EventArgs) Handles btn_upload_to_cloud.Click
        Dim fi As New FileInfo("L:\Common\fw\out\20201031.csv")
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & fi.DirectoryName
        Dim READING_DATE As Date
        Dim conn As New OleDbConnection(connectionString)
        conn.Open()

        'the SELECT statement is important here, 
        'and requires some formatting to pull dates and deal with headers with spaces.
        'Dim cmdSelect As New OleDbCommand("SELECT Foo, Bar, FORMAT(""SomeDate"",'YYYY/MM/DD') AS SomeDate, ""SOME MULTI WORD COL"", FROM " & fi.Name, conn)
        Dim cmdSelect As New OleDbCommand("SELECT * FROM " & fi.Name, conn)
        Dim adapter1 As New OleDbDataAdapter
        adapter1.SelectCommand = cmdSelect

        Dim ds As New DataSet
        adapter1.Fill(ds, "DATA")
        'DataGridView1.DataSource = ds.Tables(0).DefaultView
        conn.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            READING_DATE = Convert.ToDateTime(ds.Tables(0).Rows(0).Item("date"))
        End If

        sql = "delete from jan_flow_meter_lines_stg WHERE reading_date='" & Format(READING_DATE, "yyyy-MM-dd") & "'"
        cmd_sql = New OleDb.OleDbCommand(sql, dms_con)
        If dms_con.State = ConnectionState.Closed Then dms_con.Open()
        cmd_sql.ExecuteNonQuery()

        For i = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(i)
                Try

                    sql = " insert into jan_flow_meter_lines_STG(flow_meter_id,air_flow,Running_ideal,reading_date,reading_time,GROUP_ID) values('" & .Item("SLAVE_ID") & "'," & .Item("FLOW_VALUE") & "," & .Item("DIGITAL_INPUT") & " "
                    sql &= "  ,'" & Convert.ToDateTime(.Item("date")) & "' "
                    'sql &= ",'2020-10-17' "
                    sql &= ",'" & .Item("time").ToString.Substring(0, 8) & "'"
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
End Class