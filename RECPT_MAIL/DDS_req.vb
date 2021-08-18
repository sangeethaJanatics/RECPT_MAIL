'Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Core
Imports System.Data.OleDb
Imports System.IO
Public Class DDS_req
    'Private Const connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=C:\Test.xls;Extended Properties=""Excel 8.0;HDR=YES;"""
    'Dim connstring As String = "provider=Microsoft.Jet.OLEDB.4.0;" & "data source=D:\Test.xls;Extended Properties=Excel 8.0;"
    'Dim connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Test.xls;Extended Properties=""Excel 8.0;HDR=YES"";"
    'Dim connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    'System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" & "data source=E:\TestVB2.xls;Extended Properties=Excel 8.0;")
    Dim con As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    'Dim filePath As String = "D:\Test.xls"

    Private Sub DDS_req_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT COUNT(*)CNT  FROM jan_cylinder_ds_lines  a where demand_source='MKTG'   AND ( INVENTORY_ITEM_ID IS  NULL OR ORGANIZATION_ID IS NULL) AND TRUNC(CREATION_DATE)=TRUNC(SYSDATE)"
        ds = SQL_SELECT("data", sql)
        If ds.Tables("DATA").Rows(0).Item("CNT") > 0 Then Label4.Text = " ERROR  ..! Some items added without org_id or Item Id"

        sql = "select sys_context('USERENV','IP_ADDRESS')ip_addr from dual"
        ds = SQL_SELECT("data", sql)
        'If ds.Tables("data").Rows(0).Item("ip_addr") = "192.168.23.60" Or ds.Tables("data").Rows(0).Item("ip_addr") = "192.168.23.79" Or ds.Tables("data").Rows(0).Item("ip_addr") = "192.168.71.11" Then

        'Else
        '    MessageBox.Show("ORA-00051: You were waiting for a resource and you timed out.")
        '    End
        'End If

        sql = "select 'ALL'org,0 organization_id from dual union select distinct jan_orgcode(organization_id)org,organization_id from jan_cylinder_ds_lines where EXCESS_COMPLETION_FLAG<>'Y' and  demand_source ='MKTG' order by org " 'trunc(creation_date)=trunc(sysdate) and 

        ds = SQL_SELECT("data", sql)
        cmb_org.DataSource = ds.Tables("data")
        cmb_org.DisplayMember = "Org"
        cmb_org.ValueMember = "organization_id"



    End Sub
    Private Sub btn_select_file_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_file.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_file_name.Text = OpenFileDialog1.FileName

        End If
    End Sub

    Private Sub btn_move_to_oracle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_to_oracle.Click
        'Dim fd As OpenFileDialog = New OpenFileDialog()

        'Dim dt As Date = ""
        For i = 0 To DataGridView1.RowCount - 1
            With DataGridView1.Rows(i)
                'dt=

                sql = "insert into jan_dds_input (org ,item_no ,qty ,target_date ,ds_id,creatioN_date,compact_valve_requirement,team_name,marketing_ds_id,marketing_target_date) values('" & .Cells("org").Value & "','" & .Cells("item_no").Value & "'," & .Cells("TODAY_QTY").Value & ",'" & Format(CDate(.Cells("TARGET_DATE").Value), "dd-MMM-yyyy") & "'," & .Cells("DS_ID").Value & ",sysdate"
                If chk_compact_valve.Checked = True Then sql &= ",'Y'" Else sql &= ",'N'"

                If .Cells("org").Value = "I07" Then sql &= " ,'" & .Cells("team_name").Value & "'" Else sql &= " ,null"

                sql &= " ," & .Cells("marketing_ds_id").Value & ",'" & Format(CDate(.Cells("marketing_target_date").Value), "dd-MMM-yyyy") & "')"


                'sql = "insert into jan_sales_input_08jan2020 (org,item_no,sales_input,total_ds_qty_1) values('" & .Cells("org").Value & "','" & .Cells("item_no").Value & "'," & .Cells("sales_input").Value & "," & .Cells("total_ds_qty_1").Value & ""
                'sql &= " )"

                comand_new()

            End With
        Next



        sql = "DECLARE BEGIN jan_DDS_REQ_INSERT; END;"
        comand_new()

        sql = " delete from jan_dds_input"
        comand_new()

        MessageBox.Show("Data moved to oracle", "DDS Input", MessageBoxButtons.OK)
        btn_move_to_oracle.Enabled = False
        sql = "SELECT COUNT(*)CNT  FROM jan_cylinder_ds_lines  a where demand_source='MKTG'   AND ( INVENTORY_ITEM_ID IS  NULL OR ORGANIZATION_ID IS NULL) AND TRUNC(CREATION_DATE)=TRUNC(SYSDATE)"
        ds = SQL_SELECT("data", sql)
        If ds.Tables("DATA").Rows(0).Item("CNT") > 0 Then Label4.Text = " ERROR  ..! Some items added without org_id or Item Id"

    End Sub

    Private Sub btn_view_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view_list.Click
        If txt_sheet_name.Text <> "" Then

       

            Dim filePath As String = txt_file_name.Text

            Dim extension As String = Path.GetExtension(filePath)
            Dim conStr As String, sheetName As String

            conStr = String.Empty
            Select Case extension

                Case ".xls"
                    conStr = String.Format(con, filePath, "YES")
                    Exit Select
            End Select


            Using con As New OleDbConnection(conStr)
                Using cmd As New OleDbCommand()
                    cmd.Connection = con
                    con.Open()
                    Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    'sheetName = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
                    'sheetName = dtExcelSchema.Rows(0)( ("TABLE_NAME").ToString()

                    sheetName = txt_sheet_name.Text & "$"

                    con.Close()
                End Using
            End Using


            Using con As New OleDbConnection(conStr)
                Using cmd As New OleDbCommand()
                    Using oda As New OleDbDataAdapter()
                        Dim dt As New DataTable()
                        cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                        cmd.Connection = con
                        con.Open()
                        oda.SelectCommand = cmd
                        oda.Fill(dt)
                        con.Close()


                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("Enter Sheet Name", "DDS Req Addition", MessageBoxButtons.OK)

        End If

    End Sub

    Private Sub txt_file_name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_file_name.TextChanged, txt_sheet_name.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label2.Click, Label3.Click

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select jan_orgcode(organization_id)org,sum(requirement)todays_req,report_ds_id from jan_cylinder_ds_lines where trunc(creation_date)=trunc(sysdate) and EXCESS_COMPLETION_FLAG<>'Y' and  demand_source ='MKTG'   "

        If cmb_org.Text <> "" And cmb_org.Text <> "ALL" Then sql &= " and organization_id=" & cmb_org.SelectedValue & " "

        If chk_compact_valve.Checked = True Then sql &= " and compact_valve_requirement='Y'" Else sql &= "  and compact_valve_requirement= 'N'"
        sql &= " group by report_ds_id,organization_id order by organization_id,report_ds_id"

        ds = SQL_SELECT("data", sql)
        With DataGridView2
            .DataSource = ds.Tables("DATA")
            .Columns("report_ds_id").DefaultCellStyle.Format = "00.0"
        End With

    End Sub

    Private Sub DDS_req_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Me.Close()
        'Login_mktg.Close()
    End Sub


End Class