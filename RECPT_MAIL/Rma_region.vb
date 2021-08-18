Imports System.IO
Imports System.Data.OracleClient

Public Class Rma_region

    Private Sub Rma_region_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "select distinct SEGMENT14 from ra_territories where SEGMENT14 not in ('GOA','M.P.','PROJECTS 1','EXPORT','NOT LISTED')"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "region")
        For i = 0 To ds.Tables("region").Rows.Count - 1
            branch_name_combo.Items.Add(ds.Tables("region").Rows(i).Item("segment14"))
        Next

        ds = New DataSet
        sql = "select customer_id,customer_name from JAN_BMS_CUSTOMER_REGION_V  ORDER BY customer_name"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "name")
        cmb_cust.DataSource = ds.Tables("name")
        cmb_cust.DisplayMember = "customer_name"
        cmb_cust.ValueMember = "customer_id"

    End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        ds = New DataSet
        sql = "SELECT a.rma_number,a.receipt_num,a.receipt_dt,a.segment1 item_no,a.item_description,a.quantity_received,(a.quantity_received*a.unit_selling_price)value,a.customer_name,a.inv_no,TO_DATE(a.INV_DT,'YYYY-MM-DD HH24:MI:SS')INV_DT,MODVAT_FLAG,region,RETURN_REASON,jan_orgcode(to_organization_id)org ,transfered_to FROM jan_rma_listing a WHERE  QUANTITY_RECEIVED>0 AND  trunc(rma_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "'  and trunc(rma_date)<='" & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & "' "

        If branch_name_combo.Text <> "" Then sql &= "  and region='" & branch_name_combo.Text & "'"
        If txt_item.Text <> "" Then sql &= " and upper(segment1) like '" & txt_item.Text.ToUpper & "'"
        If org_cmb.Text <> "" Then sql &= " and org='" & org_cmb.Text & "'"
        If cmb_cust.Text <> "" Then sql &= " AND CUSTOMER_naME='" & cmb_cust.Text & "'"

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "result")
        With ds.Tables("result")
            .Rows.Add()
            .Rows(.Rows.Count - 1).Item("value") = .Compute("sum(value)", "value>=0")
            .Rows(.Rows.Count - 1).Item("item_description") = "TOTAL"
        End With



        S = ""
        S = "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<h5><font size=2 face=Verdana>RMA Return for :" & branch_name_combo.Text & " : " & cmb_cust.Text & "</h5>"

        S &= "<table border=1 cellspacing=0 cellpading=0 class=tab width=100%>"
        S &= "<tr><TD align=center><font size=1 face=Verdana>Sales Return OA No</TD><TD align=center><font size=1 face=Verdana>Our Receipt No</TD><TD align=center><font size=1 face=Verdana>Our Receipt Dt</TD><TD align=center><font size=1 face=Verdana>Item No</TD><TD align=center><font size=1 face=Verdana>Description</TD><TD align=center><font size=1 face=Verdana>Quantity Received</TD><TD align=center><font size=1 face=Verdana>Value</TD><TD align=center><font size=1 face=Verdana>Customer Name</TD><TD align=center><font size=1 face=Verdana>Inv No</TD><TD align=center><font size=1 face=Verdana>Inv Dt</TD><TD align=center><font size=1 face=Verdana>MOD vat</TD><TD align=center><font size=1 face=Verdana>Reason for Return</TD><TD align=center><font size=1 face=Verdana>Org</TD><td><font size=1 face=Verdana> Transfered To </td></tr>"
        For i = 0 To ds.Tables("result").Rows.Count - 1
            With ds.Tables("result").Rows(i)
                S &= "<tr><TD><font size=1 face=Verdana>" & .Item("rma_number") & "</TD><TD><font size=1 face=Verdana>" & .Item("receipt_num") & "</TD><TD align=center><font size=1 face=Verdana>" & .Item("receipt_dt") & "</TD><TD><font size=1 face=Verdana>" & .Item("item_no") & "</TD><TD><font size=1 face=Verdana>" & .Item("item_description") & "</TD><TD align=right><font size=1 face=Verdana>" & .Item("quantity_received") & "</TD><TD align=right><font size=1 face=Verdana>" & .Item("value") & "</TD><TD><font size=1 face=Verdana>" & .Item("customer_name") & "</TD><TD><font size=1 face=Verdana>" & .Item("inv_no") & "</TD><TD><font size=1 face=Verdana>" & .Item("inv_dt") & "</TD><TD align=center><font size=1 face=Verdana>" & .Item("modvat_flag") & "</TD><td><font size=1 face=Verdana>" & .Item("RETURN_REASON") & "</TD><td><font size=1 face=Verdana>" & .Item("org") & "</TD><td><font size=1 face=Verdana>" & .Item("transfered_to") & "</TD></tr>"
            End With
        Next
        S &= "</html>"
        Dim objfso
        objfso = CreateObject("Scripting.FileSystemObject")
        X = "D:\" & branch_name_combo.Text & "_rma_return.html"

        If objfso.FileExists(X) Then
            objfso.DeleteFile(X)
        End If
        Dim FSTRM As FileStream = New FileStream(X, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW.WriteLine(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
        System.Diagnostics.Process.Start(X)
    End Sub
    Private Sub branch_name_combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles branch_name_combo.SelectedIndexChanged

        ds = New DataSet
        sql = "select customer_id,customer_name from JAN_BMS_CUSTOMER_REGION_V where region='" & branch_name_combo.Text & "' ORDER BY customer_name"
        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "name")
        cmb_cust.DataSource = ds.Tables("name")
        cmb_cust.DisplayMember = "customer_name"
        cmb_cust.ValueMember = "customer_id"

    End Sub
End Class