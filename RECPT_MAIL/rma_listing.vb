Imports System.Data.OracleClient
Public Class rma_listing
    Dim cn_str As String
    Private Sub rma_listing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        sql = "select ORGANIZATION_CODE from org_organization_definitions where ORGANIZATION_ID<=111 and ORGANIZATION_ID<>105 "
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        adap.Fill(ds, "org")
        org_combo.DataSource = ds.Tables("org")
        org_combo.DisplayMember = "ORGANIZATION_CODE"
        org_combo.SelectedIndex = -1

        'sql = "select distinct SEGMENT14 region from ra_territories where SEGMENT14 not in ('GOA','M.P.','PROJECTS 1') "
        sql = "select distinct SEGMENT14 region from ra_territories   "
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        adap.Fill(ds, "reg")
        branch_combo.DataSource = ds.Tables("reg")
        branch_combo.DisplayMember = "region"
        branch_combo.SelectedIndex = -1

        sql = "select CUSTOMER_NAME from ra_customers"
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        adap.Fill(ds, "cust")
        cname_combo.DataSource = ds.Tables("cust")
        cname_combo.DisplayMember = "CUSTOMER_NAME"
        cname_combo.SelectedIndex = -1

        sql = "select distinct CUSTOMER_CLASS_CODE from ra_customers"
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        adap.Fill(ds, "cust_type")
        ctype_combo.DataSource = ds.Tables("cust_type")
        ctype_combo.DisplayMember = "CUSTOMER_CLASS_CODE"
        ctype_combo.SelectedIndex = -1

    End Sub
    'Private Sub cname_combo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cname_combo.SelectedValueChanged

    '    Dim site As New DataSet
    '    'site_name_combo.Items.Clear()
    '    site.Clear()
    '    sql = "select B.ADDRESS1,B.ADDRESS_ID from ra_customers A,ra_addresses_all B WHERE A.PARTY_ID=B.PARTY_ID AND A.CUSTOMER_NAME='" & cname_combo.Text & "'"
    '    cmd = New OracleCommand(sql, con)
    '    adap = New OracleDataAdapter(cmd)
    '    adap.Fill(site, "bill_to_site")
    '    site_combo.DataSource = site.Tables("bill_to_site")
    '    site_combo.DisplayMember = "address1"
    '    site_combo.ValueMember = "address_id"
    '    site_combo.SelectedIndex = -1
    'End Sub
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        cn_str = ""
        'dgv.Rows.Clear()
        ds1 = New DataSet
        sql = "select a.RMA_NUMBER,a.RMA_DATE,a.RECEIPT_NUM,a.RECEIPT_DT,a.SEGMENT1,a.ITEM_DESCRIPTION,a.QUANTITY_RECEIVED,a.UNIT_SELLING_PRICE,(a.QUANTITY_RECEIVED*a.UNIT_SELLING_PRICE) value,a.RETURN_REASON  from jan_rma_listing a ,ra_customers b where trunc(a.RMA_DATE)>='" & Format(CDate(DateTimePicker1.Value), "dd-MMM-yyyy") & "' and trunc(a.RMA_DATE)<='" & Format(CDate(DateTimePicker2.Value), "dd-MMM-yyyy") & "' and a.customer_name=b.customer_name "
        If org_combo.Text <> "" Then
            cn_str = " and (select organization_code from org_organization_definitions where organization_id=a.TO_ORGANIZATION_ID)='" & org_combo.Text & "'"
        End If

        If cname_combo.Text <> "" Then
            'If cn_str <> "" Then
            cn_str &= "and a.CUSTOMER_NAME='" & cname_combo.Text & "'"
            'End If
        End If
        If item_txt.Text <> "" Then
            cn_str &= "and a.SEGMENT1='" & item_txt.Text & "'"
        End If
        If ctype_combo.Text <> "" Then
            cn_str &= "and a.customer_name=b.customer_name and b.customer_class_code='" & ctype_combo.Text & "'"
        End If
        If branch_combo.Text <> "" Then
            'cn_str &= "and a.customer_name=c.customer_name and c.region='" & branch_combo.Text & "'"
            'cn_str &= "(select ter.segment14 from ra_customers ctb, RA_addresses_all ads, RA_SITE_USES_ALL sit,  ra_territories ter  WHERE ads.address_id=sit.address_id and  ctb.customer_id = ads.customer_id And ter.TERRITORY_ID = sit.TERRITORY_ID AND CTB.CUSTOMER_NAME=A.CUSTOMER_NAME AND ROWNUM=1)	"
        End If
        cn_str &= "ORDER BY a.RMA_NUMBER"
        sql = sql + cn_str
        cmd = New OracleCommand(sql, con)
        adap = New OracleDataAdapter(cmd)
        adap.Fill(ds1, "rma")
        dgv.DataSource = ds1.Tables("rma")

        dgv.Columns(0).HeaderText = "RMA NO"
        dgv.Columns(1).HeaderText = "RMA DATE"
        dgv.Columns(2).HeaderText = "RECEIPT NO"
        dgv.Columns(3).HeaderText = "RECEIPT DATE"
        dgv.Columns(4).HeaderText = "ITEM NO"
        dgv.Columns(5).HeaderText = "DESCRIPTION"
        dgv.Columns(6).HeaderText = "QTY"
        dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgv.Columns(6).Width = 40
        dgv.Columns(7).HeaderText = "RATE"
        dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgv.Columns(7).Width = 60
        dgv.Columns(8).HeaderText = "VALUE"
        dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgv.Columns(8).Width = 60
        dgv.Columns(9).HeaderText = "REASON"
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class