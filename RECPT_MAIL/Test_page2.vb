Imports System.Data
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data.OracleClient


'Imports System.Web.Script.Serialization



Public Class Test_page2

    Dim ordref As String
    Dim dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=janatics.net;initial catalog=jan_dms;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    Public con As New OleDb.OleDbConnection("provider=sqloledb;workstation id=59.160.116.114;packet size=4096;user id=jandms;password=jandms#$sql08;data source=59.160.116.114;persist security info=False;initial catalog=jan_dms")
    Dim cmd_sql As New OleDb.OleDbCommand
    Dim adap_sql As New OleDb.OleDbDataAdapter
    Dim DS, TDS As New DataSet
    Dim htm As String
    Dim DSP_ID As String
    Dim Z As New Integer
    Dim sql_CMD As New OleDb.OleDbCommand

    Private Sub Test_page2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "select customer_id,customer_name from ra_customers a  where customer_class_code='DEALER'  order by 2"
        DS = SQL_SELECT("result", sql)
        dgv1.DataSource = DS.Tables("result")

        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .HeaderText = "Testing"
            .Name = "Testing"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        dgv1.Columns.Insert(0, column)
        Dim column1 As New DataGridViewCheckBoxColumn()
        With column1
            .HeaderText = "Testing2"
            .Name = "Testing2"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        dgv1.Columns.Insert(1, column1)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim message As String = String.Empty
        For Each row As DataGridViewRow In dgv1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Testing2").Value)
            If isSelected Then
                message &= Environment.NewLine
                message &= row.Cells("customer_Name").Value.ToString()
            End If
        Next
        MessageBox.Show("Selected Values" & message)
    End Sub






End Class