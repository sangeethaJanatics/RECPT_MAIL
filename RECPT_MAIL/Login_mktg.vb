Public Class Login_mktg

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        sql = "select * from jan_bi_sales_user WHERE REPORT_NAME='PAYMENT' AND ENABLED='Y' AND UPPER(UserNAME)=UPPER('" & txt_username.Text & "')  AND UPPER(PassWorD)=UPPER('" & txt_pwd.Text & "') "
        ds = SQL_SELECT("res", sql)
        If ds.Tables("RES").Rows.Count > 0 Then

            Me.Size = New System.Drawing.Size(733, 520)
            Me.Panel1.Location = New System.Drawing.Point(1, 1)
            If ds.Tables("RES").Rows(0).Item("ip_address") = "Vivek" Then

                Link_Dealer_order_status.Visible = True
                Link_non_moving_item_stock.Visible = True
                Link_bin_addition.Visible = True
                link_sale_cyr_lyr.Visible = True
                LinkLabel1.Visible = True
                link_inter_region_flush.Visible = True
                link_weekwise_ord_pend.Visible = True
                link_ofd_date_change.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "Vijay" Then
                LinkLabel1.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "Shanthi" Then

                Link_ofd_orderpending.Visible = True
                Link_new_cust_billto_shipto.Visible = True
                Link_sale_detail.Visible = True
                Link_order_cancelation.Visible = True
                Link_non_tod_items.Visible = True
                Link_sales_KPI.Visible = True
                Link_new_price_addition.Visible = True
                Link_order_sale_OS.Visible = True
                link_us_sale.Visible = True
                LinkLabel_ORDER_RECEIPT.Visible = True
                Link_price_add.Visible = True
                LinkLabel2.Visible = True
                link_branch_price_rev.Visible = True
                link_view_price_list.Visible = True
                link_ofd_date_change.Visible = True
                Link_customer_detail.Visible = True
            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "Latha" Then
                Link_LPD.Visible = True
                link_mktg_mrm.Visible = True
                link_mktg_review_detail.Visible = True
                Link_TOD_Non_TOD_items.Visible = True
                Link_LPD.Visible = True
                Link_customer_detail.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "dr" Then
                Link_ofd_orderpending.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "admin" Then
                link_mktg_mrm.Visible = True
                link_mktg_review_detail.Visible = True
                Link_Dealer_order_status.Visible = True
                LPD.Visible = True
                'Viv
                Link_non_moving_item_stock.Visible = True
                Link_bin_addition.Visible = True
                Reservation_simulation.Visible = True
                LPD.Visible = False
                'Sales
                Link_ofd_orderpending.Visible = True
                Link_new_cust_billto_shipto.Visible = True
                Link_sale_detail.Visible = True
                Link_order_cancelation.Visible = True
                Link_non_tod_items.Visible = True
                Link_sales_KPI.Visible = True
                Link_new_price_addition.Visible = True
                Link_order_sale_OS.Visible = True
                link_us_sale.Visible = True
                LPD.Visible = True
                Reservation_simulation.Visible = True
                link_view_price_list.Visible = True
            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "Lakshmi" Then
                link_us_sale.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "corpplan" Then
                'Corp Plan
                link_dds_req.Visible = True

            ElseIf ds.Tables("RES").Rows(0).Item("ip_address") = "dealertarget" Then
                'Corp Plan
                link_Dealer_target.Visible = True
                Link_Dealer_order_status.Visible = True
                link_weekwise_ord_pend.Visible = True
            End If


        Else
            MessageBox.Show(" User Name or Password  is Invalid ...!")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Login_mktg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(586, 224)

        'Latha
        link_mktg_mrm.Visible = False
        link_mktg_review_detail.Visible = False
        Link_TOD_Non_TOD_items.Visible = False
        Link_LPD.Visible = False
        'Viv
        Link_non_moving_item_stock.Visible = False
        Link_bin_addition.Visible = False
        link_sale_cyr_lyr.Visible = False
        Link_Dealer_order_status.Visible = False
        Order_pending_available.Visible = False
        link_inter_region_flush.Visible = False
        'Sales
        Link_ofd_orderpending.Visible = False
        Link_new_cust_billto_shipto.Visible = False
        Link_sale_detail.Visible = False
        Link_order_cancelation.Visible = False
        Link_non_tod_items.Visible = False
        Link_sales_KPI.Visible = False
        Link_new_price_addition.Visible = False
        Link_order_sale_OS.Visible = False
        LinkLabel_ORDER_RECEIPT.Visible = False
        LinkLabel2.Visible = False
        link_branch_price_rev.Visible = False
        link_view_price_list.Visible = False
        'Export
        link_us_sale.Visible = False
        Reservation_simulation.Visible = False
        'Corp Plan
        link_dds_req.Visible = False
        Reservation_simulation.Visible = False
        'Dealer Target Change
        link_Dealer_target.Visible = False

    End Sub

    Private Sub link_mktg_review_detail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_mktg_review_detail.LinkClicked
        MKtg_review_detail.Show()
        Me.Hide()
    End Sub

    Private Sub link_mktg_mrm_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_mktg_mrm.LinkClicked
        Mktg_mrm.Show()
        Me.Hide()
    End Sub

    Private Sub Link_Dealer_order_status_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_Dealer_order_status.LinkClicked
        Dealer_order_status.Show()
    End Sub

    Private Sub Link_bin_addition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_bin_addition.LinkClicked
        Bin_addition.Show()
    End Sub

    Private Sub Link_non_moving_item_stock_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_non_moving_item_stock.LinkClicked
        Non_moving_item_stock.Show()
    End Sub

    Private Sub Link_ofd_orderpending_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_ofd_orderpending.LinkClicked
        order_pending.Show()
    End Sub

    Private Sub Link_new_cust_billto_shipto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_new_cust_billto_shipto.LinkClicked
        New_customer_addition_bill_To_Ship_TO.Show()
    End Sub

    Private Sub Link_order_cancelation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_order_cancelation.LinkClicked
        Order_cancelled_Data.Show()
    End Sub

    Private Sub Link_sale_detail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_sale_detail.LinkClicked
        Sale_Detail.Show()
    End Sub

    Private Sub Link_non_tod_items_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_non_tod_items.LinkClicked
        Non_TOD_items.Show()
    End Sub

    Private Sub link_us_sale_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_us_sale.LinkClicked
        US_Sale_with_inr_mplusl.Show()
    End Sub

    Private Sub Link_order_sale_OS_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_order_sale_OS.LinkClicked
        order_receipt.Show()
    End Sub

    Private Sub Link_new_price_addition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_new_price_addition.LinkClicked
        New_Price_addition.Show()
    End Sub

    Private Sub Link_sales_KPI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_sales_KPI.LinkClicked
        sales_KPI.Show()
    End Sub

    Private Sub link_sale_cyr_lyr_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_sale_cyr_lyr.LinkClicked
        Sale_Cyr_Lyr.Show()
    End Sub

    Private Sub link_dds_req_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_dds_req.LinkClicked
        DDS_req.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Order_pending_available.Show()
    End Sub

    Private Sub LinkLabel_ORDER_RECEIPT_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_ORDER_RECEIPT.LinkClicked
        order_receipt_for_the_items.Show()
    End Sub
    Private Sub Link_price_add_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_price_add.LinkClicked
        Price_Addition_Detail.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_TOD_Non_TOD_items.LinkClicked
        TOD_Non_TOD_items.Show()
    End Sub

    Private Sub link_inter_region_flush_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_inter_region_flush.LinkClicked
        Reservation_simulation.Show()
    End Sub

    Private Sub Link_LPD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_LPD.LinkClicked
        LPD.Show()
    End Sub

    Private Sub Login_mktg_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub link_Dealer_target_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_Dealer_target.LinkClicked
        Dealer_target_qty_edit.Show()

    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form2_addition.Show()

    End Sub

    Private Sub link_weekwise_ord_pend_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_weekwise_ord_pend.LinkClicked
        weekwise_order_sale.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub link_branch_price_rev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_branch_price_rev.LinkClicked
        Branch_Price_Rev_editing.Show()
    End Sub
    Private Sub link_view_price_list_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_view_price_list.LinkClicked
        Price_detail.Show()
    End Sub
    Private Sub link_ofd_date_change_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_ofd_date_change.LinkClicked
        'Dim iURL As String
        'iURL = ("http:\\192.168.0.22\BRANCH_FEEDBACK\BR_MAIN.ASPX?PARENT=" & puname & "&RIGHTS=" & Replace(ter, " ", "%20"))
        'iURL = ("START chrome http://192.168.0.22/ofd_date_change/default.aspx")
        'openbrowser(iURL)
        Shell("f:\OA\SAL\OFD_DATE_CHANGE.BAT", AppWinStyle.Hide)
    End Sub

    Public Sub openbrowser(ByVal urlname As String)
        Dim myProcess As New System.Diagnostics.Process()
        myProcess.StartInfo = New System.Diagnostics.ProcessStartInfo("iexplore")
        myProcess.StartInfo.Arguments = urlname
        myProcess.Start()
    End Sub

    Private Sub Link_customer_detail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_customer_detail.LinkClicked
        Customer_Detail.Show()
    End Sub
End Class
