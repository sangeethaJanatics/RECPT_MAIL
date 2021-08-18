Imports System.IO
Imports System.Data.OracleClient

Public Class attn_status
    Dim newPoint As New System.Drawing.Point()
    Dim a As Integer
    Dim b As Integer
    Dim empno As New DataSet
    'Dim DR As Odbc.OdbcDataReader
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        dgv.Columns.Clear()
        ds = New DataSet
        sql = "SELECT card_in_date""Date"",employee_number""EmpNo"",last_name""Name"",dept_name""Dept"",status ""Status"",rowtocol('SELECT to_char(iotime,''dd-MM-yyyy HH:MI AM'') FROM jan_hrms_io_trans WHERE  iodate='''||a.card_in_date||''' AND empcode='''||a.employee_number||''' ORDER BY iotime')iotime FROM jan_daily_attn_v a WHERE trunc(card_in_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(card_in_date)<='" & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & "' "
        If status_combo.Text <> "" Then sql &= " and status='" & status_combo.Text & "'"
        If dept_combo.Text <> "" Then sql &= " and dept_name='" & dept_combo.Text & "'"
        If emp_no_combo.Text <> "" Then sql &= " and  employee_number='" & emp_no_combo.Text & "' "
        sql &= " order by card_in_date"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        dgv1.DataSource = ds.Tables("result")
        dgv1.Columns(0).Width = 100
        dgv1.Columns(1).Width = 55
        dgv1.Columns(2).Width = 150
        dgv1.Columns(3).Width = 150
        dgv1.Columns(4).Width = 230
        dgv1.Columns(5).Width = 300

    End Sub
    Private Sub EaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EaToolStripMenuItem.Click
        ds1 = New DataSet
        sql = "select iotime""In/Out Time"",''""State"" from jan_hrms_io_trans where  iodate='" & Format(dgv1.CurrentRow.Cells(0).Value, "dd-MMM-yyyy") & "' and empcode='" & dgv1.CurrentRow.Cells(1).Value & "' order by iotime"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds1, "result")
        dgv2.DataSource = ds1.Tables("result")
        dgv2.Columns(0).Width = 250
        For i = 0 To dgv2.RowCount - 1
            If i Mod 2 = 0 Then dgv2.Rows(i).Cells(1).Value = "IN"
            If i Mod 2 <> 0 Then dgv2.Rows(i).Cells(1).Value = "OUT"
        Next
        Panel1.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = False
    End Sub

    Private Sub attn_status_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        End
        con = Nothing
    End Sub

    Private Sub attn_status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.images1
        Panel1.Visible = False
        Panel2.Visible = False
        'empno = New DataSet
        'sql = "select distinct employee_number from jan_daily_attn_v "
        'If deptid_txt.Text <> 1 Then sql &= " where dept_id='" & deptid_txt.Text & "'  "
        'sql &= "order by employee_number"
        'adap = New OracleDataAdapter(sql, con)
        'adap.Fill(empno, "ids")
        'For i = 0 To empno.Tables("ids").Rows.Count - 1
        '    emp_no_combo.Items.Add(empno.Tables("ids").Rows(i).Item("employee_number"))
        'Next
        dept_combo.Items.Clear()
        ds = New DataSet
        sql = "select distinct dept_name dept  from jan_daily_attn_v"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "dept")
        For i = 0 To ds.Tables("dept").Rows.Count - 1
            dept_combo.Items.Add(ds.Tables("dept").Rows(i).Item("dept"))
        Next

        ds = New DataSet
        sql = "SELECT status FROM att_status order by id"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "dept")
        For i = 0 To ds.Tables("dept").Rows.Count - 1
            status_combo.Items.Add(ds.Tables("dept").Rows(i).Item("status"))
        Next
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        a = Control.MousePosition.X - Panel1.Location.X
        b = Control.MousePosition.Y - Panel1.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Panel1.Location = newPoint
        End If
    End Sub
    Private Sub emp_no_combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles emp_no_combo.SelectedIndexChanged
        Panel1.Visible = False
    End Sub
    Private Sub btn_pwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pwd.Click
        Panel2.Visible = True
    End Sub
    Private Sub btn_close2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close2.Click
        Panel2.Visible = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If new_pwd_txt.Text <> "" Then

            sql = "select * from jan_attendance_user   where dept_id='" & deptid_txt.Text & "'"
            cmd = New OracleClient.OracleCommand(sql, con)
            If con.State = ConnectionState.Closed Then con.Open()
            DR = cmd.ExecuteReader
            If DR.HasRows = True Then
                If DR.Item("PWD") = old_pwd_txt.Text Then
                    sql = "update jan_attendance_user set pwd='" & new_pwd_txt.Text & "' where dept_id='" & deptid_txt.Text & "'"
                    cmd = New OracleCommand(sql, con)
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Password Changed ")
                    old_pwd_txt.Text = ""
                    new_pwd_txt.Text = ""
                    Panel2.Visible = False

                Else
                    MessageBox.Show("Invalid Password")
                End If
            End If
        Else
            MessageBox.Show("Enter  New Password")
        End If
    End Sub

    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        a = Control.MousePosition.X - Panel2.Location.X
        b = Control.MousePosition.Y - Panel2.Location.Y
    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Panel2.Location = newPoint
        End If
    End Sub
    Private Sub dept_combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_combo.SelectedIndexChanged
        emp_no_combo.Items.Clear()
        empno = New DataSet
        sql = "select distinct employee_number from jan_daily_attn_v  where dept_name='" & dept_combo.Text & "'  "
        sql &= "order by employee_number"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(empno, "ids")
        For i = 0 To empno.Tables("ids").Rows.Count - 1
            emp_no_combo.Items.Add(empno.Tables("ids").Rows(i).Item("employee_number"))
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        S = ""
        S = "<html>"
        S &= "<head><style type='text/css'>.tab {color:black;font-family:Arial Narrow;font-size:8pt}</style></head>"
        S &= "<h6 align=center><u><font size=1 face=Verdana color=blue><b>Attendance Status </u></font></h6>"
        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><font size=1 face=Verdana color=firebrick>Sl.No.</TD><TD align=center><font size=1 face=Verdana color=firebrick>Date</TD><TD align=center><font size=1 face=Verdana color=firebrick>Employee No</TD><TD align=center><font size=1 face=Verdana color=firebrick>Name</TD><TD align=center><font size=1 face=Verdana color=firebrick>Department</TD><TD align=center><font size=1 face=Verdana color=firebrick>Status</TD><TD align=center><font size=1 face=Verdana color=firebrick>I/O Time</TD></tr>"
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S &= "<tr><TD align=center><font size=1 face=Verdana color=firebrick>" & i + 1 & "</TD><TD><font size=1 face=Verdana color=firebrick>" & .Item("date") & "</TD><TD align=center><font size=1 face=Verdana color=firebrick>" & .Item("empno") & "</TD><TD><font size=1 face=Verdana color=firebrick>" & .Item("name") & "</TD><TD align=center><font size=1 face=Verdana color=firebrick>" & .Item("dept") & "</TD><TD><font size=1 face=Verdana color=firebrick>" & .Item("status") & "</TD><TD><font size=1 face=Verdana color=firebrick>" & .Item("iotime") & "</TD></tr>"
            End With
        Next
        S &= "</html>"
        X = "D:\attendance_Reg.html"
        'If objfso.FileExists(X) Then
        '    objfso.DeleteFile(X)
        'End If
        Dim FSTRM1 As FileStream = New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW1 As StreamWriter = New StreamWriter(FSTRM1)
        SW1.WriteLine(S)
        FSTRM1.Flush()
        SW1.Flush()
        SW1.Close()
        FSTRM1.Close()
        System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub dgv1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        ds1 = New DataSet
        sql = "select iotime""In/Out Time"",''""State"" from jan_hrms_io_trans where  iodate='" & Format(dgv1.CurrentRow.Cells(0).Value, "dd-MMM-yyyy") & "' and empcode='" & dgv1.CurrentRow.Cells(1).Value & "' order by iotime"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds1, "result")
        dgv.DataSource = ds1.Tables("result")
        dgv.Columns(0).Width = 250
        For i = 0 To dgv.RowCount - 1
            If i Mod 2 = 0 Then dgv.Rows(i).Cells(1).Value = "IN"
            If i Mod 2 <> 0 Then dgv.Rows(i).Cells(1).Value = "OUT"
        Next

    End Sub
End Class