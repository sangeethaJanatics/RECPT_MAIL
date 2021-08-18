Imports System.IO

Imports System.Data.OracleClient
Module Module1
    'Public con As New Odbc.OdbcConnection("Driver=Microsoft ODBC for oracle;uid=jan_it;pwd=janapps;server=PROD")
    Public sql, sql1, S, S1, X, Y, rma_user, rma_pwd As String
    Public ds, ds1, ds2, ds3, ds4, ds5 As New DataSet
    'Public cmd As New OracleCommand
    'Public adap As New OracleDataAdapter

    'Public adap As New OracleDataAdapter
    'Public cmd As New OracleCommand
    'Public con As New OracleConnection("Data Source=PROD;User Id=jan_it;Password=janapps;Integrated Security=no;")
    Public DR, dr1 As OracleClient.OracleDataReader

    Public adap As New OracleDataAdapter
    Public cmd As New OracleCommand
    Public con As New OracleConnection("Data Source=PROD;User Id=jan_it;Password=janapps;Integrated Security=no;")
    Public con_GO As New OracleConnection("Data Source=PROD;User Id=jan_GO;Password=gous205;Integrated Security=no;")
    Public orcon As New OracleClient.OracleConnection("uid=jan_it;pwd=janapps;server=prod")
    Public dms_con As New OleDb.OleDbConnection("provider=sqloledb;Data Source=13.235.237.129 ;initial catalog=jan_FMS;Persist Security Info=True;User ID=jandms;Password=jandms#$sql08")
    'Public my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.23.222;port:3306;Database=janatics;uid=root;password=T006@123;option=3;")
    'Public my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.14.30;port:3306;Database=janatics;uid=appl;password=appl@123;option=3;")

    Public my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.23.222;port:3306;Database=janatics;uid=root;password=T006@123;option=3;") 'charset=UTF8;
    'Public my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=localhost;port:3306;Database=janatics;uid=root;password=T006@123;option=3;") 'charset=UTF8;
    'connectionstring="Driver={MySQL ODBC 5.1 Driver};Server=myServerAddress;charset=UTF8;Database=myDataBase;User=myUsername;Password=myPassword;Option=3;"
    '               providername="System.Data.Odbc"
    Public my_sql_Con_rds As New Odbc.OdbcConnection("Driver={MySQL ODBC 8.0 ANSI Driver};Server=jan-flowmeter.clamf2ylrdm1.ap-south-1.rds.amazonaws.com:33066;port:33066;Database=janatics;uid=jan_db_admin;password=Qwreasfgt#123#%420;")


    Public ada_mysql As New Odbc.OdbcDataAdapter
    Public cmd_mysql As New Odbc.OdbcCommand
    Public FMS_shift_setting, fms_view, fms_delete, fms_edit, FMS_LOGIN_USER, FMS_USER_ID As String
    'Public con As New OracleConnection("Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.32)(PORT = 1526))(CONNECT_DATA =(SID = test)));User ID=jan_it;Password=janapps;")

    'Public orcon As New OracleConnection("Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.32)(PORT = 1526))(CONNECT_DATA =(SID = test)));User ID=jan_it;Password=janapps;")


    Public i, j, k, d, z, ii As Integer
    'Dim conn As New OleDb.OleDbConnection("provider=sqloledb;workstation id=13.235.195.146;packet size=4096;user id=jandms;password=jandms#$sql08;data source=13.235.195.146;persist security info=False;initial catalog=jan_dms")

    Dim conn As New OleDb.OleDbConnection("provider=sqloledb;workstation id=13.235.237.129;packet size=4096;user id=jandms;password=jandms#$sql08;data source=13.235.237.129;persist security info=False;initial catalog=jan_FMS")
    Public Function Execute_Query_mysql_rds(ByVal SQL As String) As Integer
        Dim rows As Integer = 0
        Try
            cmd_mysql = New Odbc.OdbcCommand(SQL, my_sql_Con_rds)
            If my_sql_Con_rds.State = ConnectionState.Closed Then
                my_sql_Con_rds.Open()
            End If
            rows = cmd_mysql.ExecuteNonQuery()
            If my_sql_Con_rds.State = ConnectionState.Open Then
                my_sql_Con_rds.Close()
            End If

        Catch ex As Exception
        End Try

        Return rows
    End Function
    Public Function SQL_SELECT_mysql(ByVal dSTableName As String, ByVal SQL As String) As DataSet
        Try
            cmd_mysql = New Data.Odbc.OdbcCommand(SQL, my_sql_Con)
            If my_sql_Con.State = Data.ConnectionState.Closed Then
                my_sql_Con.Open()
            End If
            ada_mysql = New Data.Odbc.OdbcDataAdapter(cmd_mysql)
            ds = New Data.DataSet
            ds.Tables.Clear()
            ada_mysql.Fill(ds, dSTableName)

            If my_sql_Con.State = Data.ConnectionState.Open Then
                my_sql_Con.Close()
            End If

        Catch ex As Exception

        End Try
        Return ds
    End Function
    Public Function Execute_Query_mysql(ByVal SQL As String) As Integer
        Dim rows As Integer = 0
        Try
            cmd_mysql = New Odbc.OdbcCommand(SQL, my_sql_Con)
            If my_sql_Con.State = ConnectionState.Closed Then
                my_sql_Con.Open()
            End If
            rows = cmd_mysql.ExecuteNonQuery()
            If my_sql_Con.State = ConnectionState.Open Then
                my_sql_Con.Close()
            End If

        Catch ex As Exception

        End Try

        Return rows
    End Function

    Public Sub comand()
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            z = cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Function ret_val(ByVal sql As String) As String

        Dim ds As New DataSet()
        Dim cmd As OracleClient.OracleCommand
        Dim adap As OracleClient.OracleDataAdapter
        cmd = New OracleClient.OracleCommand(sql, con)
        adap = New OracleClient.OracleDataAdapter(cmd)

        If ds.Tables.Contains("rv") = True Then
            ds.Tables.Remove("rv")
        End If

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        adap.Fill(ds, "rv")



        Try
            If Not IsDBNull(ds.Tables("rv").Rows(0).Item(0)) Then
                Return ds.Tables("rv").Rows(0).Item(0).ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop

        sw.Stop()
    End Sub
    Public Function return_ds(ByVal sql_qty As String, ByVal datatable_name As String) As DataSet
        Dim rds As New DataSet
        Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand
        cmd.CommandText = sql_qty
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim oadap As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)
        oadap.Fill(rds, datatable_name)
        'conn.Close()
        Return rds

    End Function
    Public Function ExecuteSQL(ByVal Query As String) As Int32

        Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand
        cmd.CommandText = Query
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Return cmd.ExecuteNonQuery()
        'conn.Close()

    End Function
    Public Sub comand_new()
        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        z = cmd.ExecuteNonQuery()
      
    End Sub
    'Private Sub EXECUTE_READER()
    '    cmd = New OracleCommand(sql, con)
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    dr = cmd.ExecuteReader
    'End Sub
    Public Sub mail_content(ByVal file_name As String)
        Dim align As String
        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr><th> <font  color=firebrick>Sl.No</font></th>"
        For k = 0 To ds.Tables("res").Columns.Count - 1
            With ds.Tables("res").Columns(k)
                If file_name = "Order Pending and Payment" Then
                    S &= "<th><font  color=firebrick>" & .ColumnName.Replace("_", " ") & "</font></th>"
                Else
                    S &= "<th><font  color=firebrick>" & .ColumnName & "</font></th>"
                End If


            End With
        Next
        S &= "</tr>"


        For k = 0 To ds.Tables("res").Rows.Count - 1

            S &= "<tr><td align=center>" & k + 1 & "</td>"
            For j = 0 To ds.Tables("res").Columns.Count - 1
                With ds.Tables("res").Rows(k)
                    If .Item(j).GetType.Name = "Decimal" Then align = "right" Else align = "left"
                    S &= "<td align=" & align & ">" & .Item(j) & "</td>"
                End With
            Next
            S &= "</tr>"

        Next
        S &= "</html>"
        X = "d:\MAILER\" & file_name & ".html"
        'X = "d:\" & file_name & ".xls"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
    End Sub
    Public Function mail_content2(ByVal file_name As String) As String
        Dim align As String
        S = ""
        'S &= "<html>"
        'S &= "<head><style type=text/css>.tab {color:darkblue;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"

        'S &= "<h3>" & file_name & "</h3>"
        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr><th> <font  color=firebrick>Sl.No</font></th>"
        For k = 0 To ds.Tables("res").Columns.Count - 1
            With ds.Tables("res").Columns(k)
                If .ColumnName = "Gap in Target as on Date" Then .ColumnName = "Gap in Target <br>as on Date"
                If .ColumnName <> "Q1 Achieved" Or .ColumnName <> "Q2 Achieved" Or .ColumnName <> "order_by" Then S &= "<th><font  color=firebrick>" & .ColumnName & "</font></th>"

            End With
        Next
        S &= "</tr>"


        For k = 0 To ds.Tables("res").Rows.Count - 1
            'If ds.Tables("res").Columns(k).ColumnName <> "Q1 Achieved" Or ds.Tables("res").Columns(k).ColumnName <> "Q2 Achieved" Then

            S &= "<tr><td align=center>" & k + 1 & "</td>"
            For j = 0 To ds.Tables("res").Columns.Count - 1
                If ds.Tables("res").Columns(j).ColumnName <> "order_by" Then




                    With ds.Tables("res").Rows(k)

                        If .Item(j).GetType.Name = "Decimal" Or .Item(j).GetType.Name = "Double" Or .Item(j).GetType.Name = "Int32" Or .Item(j).GetType.Name = "Float" Then align = "right" Else align = "left"
                        S &= "<td align=" & align & ">" & .Item(j) & "</td>"
                    End With
                End If
            Next
            S &= "</tr>"


        Next
        S &= "</table>"
        'S &= "</html>"
        'X = "C:\" & file_name & ".html"
        'Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        'Dim SW As StreamWriter = New StreamWriter(FSTRM)

        'SW = New StreamWriter(FSTRM)
        'SW.Write(S)
        'FSTRM.Flush()
        'SW.Flush()
        'SW.Close()
        'FSTRM.Close()
        Return S
    End Function

    Public Function SQL_SELECT_GO(ByVal dSTableName As String, ByVal SQL As String)

        Try

            cmd = New OracleCommand(SQL, con_GO)
            If con.State = Data.ConnectionState.Closed Then
                con.Open()
            End If
            adap = New OracleDataAdapter(cmd)
            ds = New Data.DataSet
            ds.Tables.Clear()
            adap.Fill(ds, dSTableName)

            If con.State = Data.ConnectionState.Open Then
                con.Close()
            End If

        Catch ex As Exception

        End Try

        Return ds

    End Function
    Public Function SQL_SELECT(ByVal dSTableName As String, ByVal SQL As String)

        Try

            cmd = New OracleCommand(SQL, con)
            If con.State = Data.ConnectionState.Closed Then
                con.Open()
            End If
            adap = New OracleDataAdapter(cmd)
            DS = New Data.DataSet
            DS.Tables.Clear()
            adap.Fill(ds, dSTableName)

            If con.State = Data.ConnectionState.Open Then
                con.Close()
            End If

        Catch ex As Exception

        End Try

        Return DS

    End Function
    Public Function retval(ByVal SQL As String) As String

        Try

            cmd = New OracleCommand(SQL, con)
            If con.State = Data.ConnectionState.Closed Then
                con.Open()
            End If
            adap = New OracleDataAdapter(cmd)
            ds = New Data.DataSet
            ds.Tables.Clear()
            adap.Fill(ds, "res")

            Try
                If ds.Tables("res").Rows.Count > 0 Then
                    Return ds.Tables("res").Rows(0).Item(0).ToString
                Else
                    Return "nil"
                End If

            Catch ex As Exception
                Return "nil"
            End Try

            If con.State = Data.ConnectionState.Open Then
                con.Close()
            End If

        Catch ex As Exception

        End Try

    End Function
End Module
