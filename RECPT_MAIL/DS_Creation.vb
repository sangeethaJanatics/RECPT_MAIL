Public Class DS_Creation
    Dim SQL, S, rating_level_for As String
    Dim DS, ds1 As New Data.DataSet
    Dim nor, i, j, z As Integer
    'Dim sql_select As New  
    Dim actual_target As Double
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=192.168.0.66;port:3306;Database=jan_vr;uid=root;password=;option=3;")

    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=127.0.0.1;port:8081;Database=vr;uid=root;password=;option=3;")
    'Dim my_sql_Con As New Odbc.OdbcConnection("Driver={MySQL ODBC 5.1 Driver};Server=127.0.0.1;port:8081;Database=vr;uid=root1;password=;option=3;")
    'Dim ada_mysql As New Odbc.OdbcDataAdapter
    'Dim cmd_mysql As New Odbc.OdbcCommand

    Private Sub btn_create_DS_Click(sender As Object, e As EventArgs) Handles btn_create_DS.Click
        SQL = "  select  to_char(sysdate,'monddIYYY')ss from dual"
        DS = SQL_SELECT("data", SQL)

        SQL = " "
        comand_new()
    End Sub
End Class