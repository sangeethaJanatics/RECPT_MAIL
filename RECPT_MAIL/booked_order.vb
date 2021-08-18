Imports System.IO
Imports System.Data.OracleClient
Public Class booked_order
    Dim booked_dt As Date
    Private Sub booked_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Now.DayOfWeek = DayOfWeek.Monday Then
            booked_dt = DateAdd(DateInterval.Day, -2, Today)
        Else
            booked_dt = DateAdd(DateInterval.Day, -2, Today)
        End If
        ds = New DataSet
        sql = "SELECT * FROM (SELECT aa.*,round(DECODE (aa.item_cost,0, 0, aa.unit_selling_price / aa.item_cost),3) fmla FROM (SELECT a.order_number, ordered_date, booked_date,jan_orgcode (organization_id) org, ord_cat,customer_name, site, ordered_item, ordered_quantity, unit_selling_price,(ordered_quantity * unit_selling_price) order_value,(SELECT item_cost FROM jan_itemcost  WHERE org_id = a.organization_id AND item_id = a.inventory_item_id) item_cost FROM jan_it.jan_sales_any_2 a WHERE TRUNC (a.booked_date) = TRUNC (SYSDATE) - 2 AND customer_name NOT LIKE 'JANATICS%' AND ord_type NOT IN (SELECT NAME FROM jan_exemp_order_type)) aa) WHERE fmla <= 1.30 ORDER BY org, customer_name, ordered_item"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<table width=80% align=center class=tab border=1 cellspacing=0 cellpadding=0>"
        S &= "<tr><th>Sl.no</th><th>Order No</th><th>Order Date</th><th>Booked date</th><th>Org</th><th>Order Caregory</th><th>Customer Name</th><th>site</th><th>Ordered Item</th><th>Ordered Quantity</th><th>Unit Selling Price</th><th>Order Value</th><th>Item Cost</th><th>Formula</th></tr>"

        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S &= "<tr><td>" & i + 1 & "</td><td>" & .Item("order_number") & "</td><td>" & .Item("ordered_date") & "</td><td>" & .Item("booked_date") & "</td><td>" & .Item("org") & "</td><td>" & .Item("ord_cat") & "</td><td>" & .Item("customer_name") & "</td><td>" & .Item("site") & "</td><td>" & .Item("ordered_item") & "</td><td>" & .Item("ordered_quantity") & "</td><td>" & .Item("unit_selling_price") & "</td><td>" & .Item("order_value") & "</td><td>" & .Item("item_cost") & "</td><td>" & .Item("fmla") & "</td></tr>"
            End With
        Next
        S &= "</table>"
        S &= "<br>"
        S &= "<p> This is a computer generated email. Please do not reply."
        S &= "</html>"
        'mail_no, mail_date, mail_program, mail_from, mail_to, mail_cc, mail_bcc, mail_subject, mail_body, mail_sent
        sql = "INSERT INTO jan_mail_system(mail_no, mail_date, mail_program, mail_from, mail_to, mail_cc, mail_bcc, mail_subject, mail_body2, mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'Booked Orders','feedback@janatics.co.in','it-dev7@janatics.co.in',null,null,'Orders Booked on " & Format(booked_dt, "dd-MMM-yyyy") & " with formula<=1.30','" & S & "',0)"

        cmd = New OracleCommand(sql, con)
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()

        'Dim FSTRM As New FileStream("D:\Orders Booked on " & Format(booked_dt, "dd-MMM-yyyy") & " .html", FileMode.Create, FileAccess.Write)
        'Dim SW As StreamWriter = New StreamWriter(FSTRM)

        'SW = New StreamWriter(FSTRM)
        'SW.Write(S)
        'FSTRM.Flush()
        'SW.Flush()
        'SW.Close()
        'FSTRM.Close()
    End Sub
End Class