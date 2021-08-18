Public Class VRLogin
    Dim SQL, S, rating_level_for As String
    Dim DS, ds1 As New Data.DataSet
    Dim nor, i, j, z As Integer
    'Dim sql_select As New  
    Dim actual_target As Double
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.0.66;port:3306;Database=jan_vr;uid=root;password=;option=3;")

    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=127.0.0.1;port:8081;Database=vr;uid=root;password=;option=3;")
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=127.0.0.1;port:3306;Database=janatics;uid=root;password=;option=3;")
    Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.23.222;port:3306;Database=janatics;uid=root;password=T006@123;option=3;")
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 8.0Driver};Server=127.0.0.1;port:3306;Database=janatics;uid=root;password=;option=3;")
    Dim ada_mysql As New Odbc.OdbcDataAdapter
    Dim cmd_mysql As New Odbc.OdbcCommand
    Private Sub btn_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register.Click

        If txt_visitor_name.Text <> "" Then

            SQL = "insert into jan_exb_registration("
            SQL &= " name,category,creation_date,event_name"
            If txt_email_id.Text <> "" Then SQL &= " ,email"
            If txt_mobile_no.Text <> "" Then SQL &= " ,phone_no"
            If txt_organization_name.Text <> "" Then SQL &= " ,organization_name"

            SQL &= " ,cur_user) values('" & txt_visitor_name.Text.ToString.Replace("'", "''") & "' ,'" & ddl_category.Text & "',now(),'DIDAC India 2018, Delhi'"

            If txt_email_id.Text <> "" Then SQL &= " ,'" & txt_email_id.Text.ToString.Replace("'", "''") & "'"
            If txt_mobile_no.Text <> "" Then SQL &= " ," & txt_mobile_no.Text & ""

            If txt_organization_name.Text <> "" Then SQL &= " ,'" & txt_organization_name.Text.ToString.Replace("'", "''") & "'"
            SQL &= " ,0 )"
            z = Execute_Query_mysql(SQL)

            If z > 0 Then
                MessageBox.Show("Registration Detail  Saved !..", "Exb Registration", MessageBoxButtons.OK)


                txt_visitor_name.Text = ""
                txt_email_id.Text = ""
                txt_mobile_no.Text = ""
                txt_organization_name.Text = ""
                txt_qr_content.Text = ""
            Else
                MessageBox.Show("Registration Detail not Saved !..", "Exb Registration", MessageBoxButtons.OK)

            End If
        Else
            MessageBox.Show("Enter Name and Registration !..", "Exb Registration", MessageBoxButtons.OK)
            'Page.RegisterStartupScript("ERR", "<script language='javascript'>alert('  Enter Name and Registration !..');</script>")
        End If
    End Sub
    Private Function SQL_SELECT_mysql(ByVal dSTableName As String, ByVal SQL As String) As DataSet

        Try

            cmd_mysql = New Data.Odbc.OdbcCommand(SQL, my_sql_Con)
            If my_sql_Con.State = Data.ConnectionState.Closed Then
                my_sql_Con.Open()
            End If
            ada_mysql = New Data.Odbc.OdbcDataAdapter(cmd_mysql)
            DS = New Data.DataSet
            DS.Tables.Clear()
            ada_mysql.Fill(DS, dSTableName)

            If my_sql_Con.State = Data.ConnectionState.Open Then
                my_sql_Con.Close()
            End If

        Catch ex As Exception

        End Try

        Return DS
    End Function
    Private Function Execute_Query_mysql(ByVal SQL As String) As Integer
        Dim rows As Integer = 0
        Try

            cmd_mysql = New Odbc.OdbcCommand(SQL, my_sql_Con)
            If my_sql_Con.State = ConnectionState.Closed Then
                my_sql_Con.Open()
            End If
            'ADAP = New OleDb.OleDbDataAdapter(sql_CMD)
            'ADAP.Fill(DS, dSTableName)
            rows = cmd_mysql.ExecuteNonQuery()
            If my_sql_Con.State = ConnectionState.Open Then
                my_sql_Con.Close()
            End If

        Catch ex As Exception

        End Try

        Return rows
    End Function
    Private Sub txt_qr_content_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qr_content.TextChanged
        Try
            Dim SQL() As String = txt_qr_content.Text.Split("#")
            txt_visitor_name.Text = SQL(0).ToString()
            txt_mobile_no.Text = SQL(1).ToString
            txt_email_id.Text = SQL(2).ToString
            txt_organization_name.Text = SQL(3).ToString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub VRLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ddl_category.SelectedItem = "Student"
        txt_qr_content.Focus()
    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        dgv.Columns.Clear()
        'SQL = "select * from jan_exb_registration where creation_date>='" & Format(from_date.Value, "dd-MMM-yyyy") & "' and creation_date<='" & Format(To_date.Value, "dd-MMM-yyyy") & "'"
        SQL = "select * from jan_exb_registration where creation_date>='" & Format(from_date.Value, "yyyy-MM-dd") & "' and creation_date<='" & Format(To_date.Value, "yyyy-MM-dd") & "' order by id desc"
        SQL = "select * from janatics.flow_meter"
        DS = SQL_SELECT_mysql("data", SQL)
        dgv.DataSource = DS.Tables("data")
        'dgv.Columns("id").Visible = False
        'dgv.ColumnCount = 3
        'dgv.Columns(0).Name = "Product ID"
        'dgv.Columns(1).Name = "Product Name"
        'dgv.Columns(2).Name = "Product_Price"

        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'dgv.Rows.Add(row)
        'row = New String() {"2", "Product 2", "2000"}
        'dgv.Rows.Add(row)
        'row = New String() {"3", "Product 3", "3000"}
        'dgv.Rows.Add(row)
        'row = New String() {"4", "Product 4", "4000"}
        'dgv.Rows.Add(row)
        ''SQL = "select * from jan_bi_sales_user"
        ''DS = SQL_SELECT("data", SQL)
        ''dgv.DataSource = DS.Tables("data")
        Dim btn As New DataGridViewButtonColumn()
        dgv.Columns.Add(btn)
        btn.HeaderText = "Play VR"
        btn.Text = " Yes"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
    End Sub
    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.ColumnIndex = 9 Then
            'MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)

            SQL = "update jan_exb_registration set cur_user=0"
            Execute_Query_mysql(SQL)

            SQL = "update jan_exb_registration set cur_user=1 where email='" & dgv.Rows(e.RowIndex).Cells(2).Value & "'"
            Execute_Query_mysql(SQL)
            btn_go_Click(sender, e)

        End If
    End Sub
End Class