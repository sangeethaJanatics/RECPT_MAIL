Imports oralob.oralob

Imports System.Web
Imports System.Collections.Specialized
Imports System.IO
Imports System.IO.Compression


Imports System.Text
Imports System.Net
Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class API_testing
    Dim TOT_ASS_VAL, TOT_CGSTVAL, TOT_SGST_VAL, TOT_IGST_VAL, TOT_DISC, TOT_OthChrg, NET_TOTAL As Double
    Dim buyer_gstin, buyer_lglnm, buyer_trdnm, buyer_pos, buyer_addres1, buyer_addres2, buyer_loc, buyer_pin, buyer_stcd As String
    Dim exp_inv, exp_shipbno, exp_shipbdt, exp_port, exp_refclm, exp_forcur, exp_cntcode, EXP_CURRENCY, SUPPLY_TYPE, VEHICLE_NO As String

    Private Sub btn_ewaybill_Click(sender As Object, e As EventArgs) Handles btn_ewaybill.Click

        SUPPLY_TYPE = ""
        document_no = ""
        buyer_gstin = ""
        buyer_lglnm = ""
        buyer_trdnm = ""
        buyer_pos = ""
        buyer_addres1 = ""
        buyer_addres2 = ""
        buyer_loc = ""
        buyer_pin = ""
        buyer_stcd = ""
        exp_inv = ""
        exp_shipbno = ""
        exp_shipbdt = ""
        exp_port = ""
        exp_refclm = ""
        exp_forcur = ""
        exp_cntcode = ""
        EXP_CURRENCY = ""
        VEHICLE_NO = ""
        first_party_number = ""
        ds1 = New DataSet
        sql = "select customer_trx_id,trx_date  from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')"
        sql = "select * from jan_einvoice_base_details_v where trx_number=trim('" & Tex_inv_no.Text & "')"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds1, "cust_trx_id")

        ds2 = New DataSet
        sql = " select DISTINCT wnd.global_attribute20 vehicle_no from wsh_new_deliveries wnd,wsh_delivery_assignments wda,wsh_delivery_details wdd where    wdd.delivery_detail_id = wda.delivery_detail_id AND wnd.delivery_id = wda.delivery_id AND  wdd.source_line_id IN  (select INTERFACE_LINE_ATTRIBUTE6    from ra_customer_trx_lines_all  INVL where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("custOMER_trx_id") & "    AND LINE_TYPE='LINE')"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds2, "VEH_NO")

        VEHICLE_NO = ds2.Tables("VEH_NO").Rows(0).Item("vehicle_no").ToString

        For i = 0 To ds1.Tables("cust_trx_id").Rows.Count - 1
            With ds1.Tables("cust_trx_id").Rows(i)


                buyer_lglnm = .Item("bill_to_cust_name")
                buyer_trdnm = .Item("bill_to_cust_name")
                first_party_number = .Item("first_party_gst")
                If .Item("ORDER_TYPE").ToString.ToUpper.Contains("EXP") And .Item("invoice_currency_code") <> "INR" Then
                    buyer_pos = "96"
                    SUPPLY_TYPE = "EXPWOP"
                    buyer_gstin = "URP"
                    buyer_stcd = "96"
                    buyer_pin = "999999"
                    exp_inv = "Y"
                    exp_shipbno = .Item("trx_number")
                    exp_shipbdt = Format(.Item("trx_date"), "dd/MM/yyyy")
                    exp_port = ""
                    exp_refclm = ""
                    exp_forcur = .Item("invoice_currency_code")
                    exp_cntcode = ""
                Else
                    SUPPLY_TYPE = "B2B"
                    buyer_pos = .Item("buyer_state_code")
                    buyer_gstin = .Item("buyer_gstin")
                    buyer_pin = .Item("buyer_pin_code")
                    buyer_stcd = .Item("buyer_state_code")
                End If
                buyer_addres1 = .Item("buyer_ADDRESS1")
                buyer_addres2 = .Item("buyer_ADDRESS2")
                buyer_loc = .Item("ship_to_site").ToString.PadRight(3)

                document_no = .Item("trx_number")
                document_date = Format(.Item("trx_date"), "dd/MM/yyyy")

            End With
        Next

        sql = "delete from jan_inv1"
        comand()



        sql = "insert into jan_inv1(select  CUSTOMER_TRX_ID, CUSTOMER_TRX_LINE_ID,TRX_NUMBER ,TRX_DATE ,OE_LINE_ID ,MON ,TYEAR ,UOM ,My, CREATION_DATE, ORDER_NUMBER, OATYPE, ORDER_DATE, ORDERED_ITEM, INVENTORY_ITEM_ID, DESCRIPTION,QUANTITY_INVOICED ,EXTENDED_AMOUNT,UNIT_STANDARD_PRICE ,UNIT_SELLING_PRICE ,OLP,SHIPPING_INSTRUCTIONS ,ATTRIBUTE3,CONVERSION_RATE ,SHIP_TO_CUST_NAME ,SHIP_TO_CUST_ID ,BILL_TO_CUSTOMER_ID,CUSTOMER_CLASS_CODE,BILL_TO_CUST_NAME ,SHIP_TO_ADDRESS,SHIP_TO_SITE,BILL_TO_SITE,BILL_TO_ADDRESS,ORGANIZATION_ID ,DISC,case when trx_number='1870170826' then '4508126996  / 40' else C_ORDER_NO end C_ORDER_NO,C_ORDER_DATE ,ECC_NO,ST_NO,CST_NO, SECC_NO ,SST_NO ,SCST_NO ,REGION ,TARIFF_NO ,TOT_CHK_AMT ,INS_TEXT ,GL_DATE,SHORT_TEXT,  CUS_DRG_NO,SCHEDULE_SHIP_DATE,BATCH_SOURCE_ID,CUST_TRX_TYPE_ID,CAT_ID,ATTRIBUTE1 ,BRANCH_EMPLOYEE from jan_invoice_listing where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
        comand()

        sql = "delete from jan_inv4"
        comand()

        sql = "insert into jan_inv4(select * from jan_invoice_tax where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
        comand()


        ds = New DataSet
        sql = "select  ordered_item||','||description prd_desc,case when upper(oatype)  like 'SERVICE%' then 'Y' else 'N' end  isservc "

        sql &= ",case when upper(oatype)  Like 'SERVICE %' then (select sac_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id) else nvl((select hsn_code from JAN_GST_RA_CUST_TRX_LINES_V where TRX_LINE_ID=a.customer_trx_line_id),(select hsn_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id)) end hsn_code "

        sql &= " ,quantity_invoiced  qty,upper(uom)unit_code,unit_selling_price unit_price,(quantity_invoiced*unit_selling_price) totamt "

        sql &= " ,(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"

        'sql &= " , nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"
        sql &= " ,0 as assamt"
        sql &= " ,nvl((SELECT sum(tax_rate) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST','CGST','SGST') ),0)gstrt"
        sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST') ),0)igstamt "
        sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('CGST') ),0)cgstamt "
        sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('SGST') ),0)sgstamt "
        sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type  Like '%TCS%' ),0)othchrg "
        sql &= ",(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE  CUSTOMER_TRX_LINE_ID in a.customer_trx_line_id And tax_type NOT Like '%TCS%'),0)TOTITEMVAL,a.* from jan_inv1 a where trx_date>'1-dec-2020' and  customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & " order by customer_trx_line_id"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds, "item_details")

        For i = 0 To ds.Tables("item_details").Rows.Count - 1
            With ds.Tables("item_details").Rows(i)
                .Item("assamt") = .Item("pretaxval")
                .Item("totamt") = .Item("pretaxval")

                '.Item("totamt") = .Item("totamt") + .Item("pretaxval")
                '.Item("assamt") = .Item("totamt")
            End With
        Next


        TOT_ASS_VAL = 0
        TOT_CGSTVAL = 0
        TOT_SGST_VAL = 0
        TOT_IGST_VAL = 0
        TOT_DISC = 0
        TOT_OthChrg = 0

        S = ""
        S &= """ItemList"" : [" & vbNewLine
        For i = 0 To ds.Tables("item_details").Rows.Count - 1
            With ds.Tables("item_details").Rows(i)
                TOT_ASS_VAL += .Item("assamt")
                TOT_CGSTVAL += .Item("CgstAmt")
                TOT_SGST_VAL += .Item("SgstAmt")
                TOT_IGST_VAL += .Item("IgstAmt")
                'TOT_DISC += .Item("assamt")
                TOT_OthChrg += .Item("OthChrg")

                If i <> 0 Then S &= " ," & vbNewLine

                S &= "  { " & vbNewLine
                S &= " ""SlNo"": """ & i + 1 & """," & vbNewLine
                S &= """PrdDesc"":""" & .Item("prd_desc").ToString.Replace("""", "") & """," & vbNewLine
                S &= """IsServc"":""" & .Item("isservc") & """," & vbNewLine
                S &= """HsnCd"":""" & .Item("hsn_code") & """," & vbNewLine
                S &= """Qty"":" & .Item("qty") & "," & vbNewLine
                S &= """Unit"":""" & .Item("unit_code") & """," & vbNewLine
                S &= """UnitPrice"":" & .Item("unit_price") & "," & vbNewLine
                S &= """TotAmt"":" & .Item("totamt") & "," & vbNewLine

                S &= """PreTaxVal"":" & .Item("PreTaxVal") & "," & vbNewLine
                S &= """AssAmt"":" & .Item("assamt") & "," & vbNewLine
                S &= """GstRt"":" & .Item("gstrt") & "," & vbNewLine
                S &= """IgstAmt"":" & .Item("IgstAmt") & "," & vbNewLine
                S &= """CgstAmt"":" & .Item("CgstAmt") & "," & vbNewLine
                S &= """SgstAmt"":" & .Item("SgstAmt") & "," & vbNewLine
                'S &= """OthChrg"":" & .Item("OthChrg") & "," & vbNewLine
                S &= """TotItemVal"":" & .Item("TotItemVal") & "" & vbNewLine
                S &= " } " & vbNewLine

            End With

        Next
        S &= " ]," & vbNewLine
        NET_TOTAL = TOT_ASS_VAL + TOT_CGSTVAL + TOT_SGST_VAL + TOT_IGST_VAL + TOT_DISC + TOT_OthChrg
        S &= " ""ValDtls"": { "
        S &= " ""AssVal"": " & TOT_ASS_VAL & "," & vbNewLine
        S &= " ""CgstVal"" :  " & TOT_CGSTVAL & "," & vbNewLine
        S &= " ""SgstVal"":" & TOT_SGST_VAL & "," & vbNewLine
        S &= " ""IgstVal"" :   " & TOT_IGST_VAL & "," & vbNewLine
        S &= " ""Discount"": " & TOT_DISC & "," & vbNewLine
        S &= " ""OthChrg"": " & TOT_OthChrg & "," & vbNewLine
        S &= " ""RndOffAmt"": 0.3," & vbNewLine
        S &= " ""TotInvVal"": " & Math.Round(NET_TOTAL) & "," & vbNewLine
        S &= " ""TotInvValFc"": " & NET_TOTAL & "" & vbNewLine
        S &= "  },"
        Txt_json.Text = S
        api_ewaybill()
    End Sub
    Private Sub api_ewaybill()
        Dim OWNER_ID As String = ""
        If first_party_number = "33AAACJ5553C1Z0" Then
            OWNER_ID = "44be97e6-26fb-48d0-859d-621931ffc632"  ''sandbox id
            'OWNER_ID = "0e486255-257b-4f1b-a03b-c02af5ee86a3" 'Production 
            'ElseIf first_party_number = "24AAACJ5553C1ZZ" Then
            '    OWNER_ID = "8f7b2c96-b8e1-458a-851b-461fc75f3b05" 'Production

            'ElseIf first_party_number = "09AAACJ5553C1ZR" Then
            '    OWNER_ID = "9d8f561b-c6bc-494e-b5c2-f9b3fea2dbec" 'Production
        End If
        Dim req_method As String = ""
        ''sandbox variables
        Einvoice_api_endpoint = "https://einvoicing.internal.cleartax.co/v1/govt/api/Invoice"
        Eway_bill_api_endpoint = "https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print"
        authentication_token = "1.cad216c1-00b3-40e2-acbc-1d1245fbf704_c8dd9a1b2defe498ace54a80616e55c270477e787abf57e615dccfe544bb8e5f"
        req_method = "POST"
        ''End sandbox variables

        ''Production variables
        'Einvoice_api_endpoint = "https://api-einv.cleartax.in/v1/govt/api/Invoice"
        'Eway_bill_api_endpoint = "https://api-einv.cleartax.in/v2/eInvoice/ewaybill/print"
        'authentication_token = "1.cf77097f-e9b7-4a21-be72-eb7b165b460a_9580cff01e118eac51341a5e842b6c6829f56dd6c81bd6ee16f86628fa3bee58"
        'req_method = "POST"
        ''End Production variables


        ' Create a request using a URL that can receive a post.   
        'Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ")
        Dim request As WebRequest = WebRequest.Create("" & Einvoice_api_endpoint & "") 'sandbox
        'Dim request As WebRequest = WebRequest.Create("https://einv-gsp.cleartax.in/core/v1.03/Invoice") 'Production

        ' Set the Method property of the request to POST.  
        request.Method = "" & req_method & ""

        request.Headers.Add("x-cleartax-auth-token", "" & authentication_token & "")  'sandbox token

        'request.Headers.Add("x-cleartax-auth-token", "1.cf77097f-e9b7-4a21-be72-eb7b165b460a_9580cff01e118eac51341a5e842b6c6829f56dd6c81bd6ee16f86628fa3bee58") 'Production token
        'End Production token
        'request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
        'request.Headers.Add("gstin", "29AAFCD5862R000")
        'request.Headers.Add("owner_id", "" & OWNER_ID & "")
        'request.Headers.Add("gstin", "" & first_party_number & "")
        Dim postData As String = "{
  ""Version"": ""1.1"",
  ""TranDtls"": {
    ""TaxSch"": ""GST"",
    ""SupTyp"": """ & SUPPLY_TYPE & """,
    ""RegRev"": ""N"",
    ""EcmGstin"": null,
    ""IgstOnIntra"": ""N""
  },
  ""DocDtls"": {
    ""Typ"": ""INV"",
    ""No"": """ & document_no & """,
    ""Dt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """ 
  }, "

        '        24AAACJ5553C1ZZ Ahmadabad GUJ
        '"09AAACJ5553C1ZR  Noida , UP
        If first_party_number = "33AAACJ5553C1Z0" Then

            postData &= " ""SellerDtls"": {
    ""Gstin"": ""33AAACJ5553C1Z0"",
    ""LglNm"": ""JANATICS INDIA PRIVATE LIMITED"",
    ""TrdNm"": ""JANATICS INDIA PRIVATE LIMITED"",
    ""Addr1"": ""S.F.No. 252/1B1, BODIPALAYAM"",
    ""Addr2"": ""SEERAPALAYAM VILLAGE,MADHUKKARAI POST,"",
    ""Loc"": ""COIMBATORE"",
    ""Pin"": 641105,
    ""Stcd"": ""33"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "
        ElseIf first_party_number = "24AAACJ5553C1ZZ" Then
            postData &= " ""SellerDtls"": {
    ""Gstin"": ""24AAACJ5553C1ZZ"",
    ""LglNm"": ""JANATICS INDIA PVT. LTD - UNIT V"",
    ""TrdNm"": ""JANATICS INDIA PVT. LTD - UNIT V"",
    ""Addr1"": ""SHED NO.8, SHAYONA INDUSTRIAL ESTATE"",
    ""Addr2"": ""INSIDE PANCHRATNA ESTATE, VATVA GIDC,  PHASE-IV, RAMOL,TA.DASCROIT, AHMEDABAD"",
    ""Loc"": ""AHMEDABAD"",
    ""Pin"": 382445,
    ""Stcd"": ""24"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "

        ElseIf first_party_number = "09AAACJ5553C1ZR" Then
            postData &= " ""SellerDtls"": {
    ""Gstin"": ""09AAACJ5553C1ZR"",
    ""LglNm"": ""JANATICS INDIA PVT. LTD - UNIT VI"",
    ""TrdNm"": ""JANATICS INDIA PVT. LTD - UNIT VI"",
    ""Addr1"": ""A-38,SECTOR-65,"",
    ""Addr2"": ""GAUTAM BUDH NAGAR,"",
    ""Loc"": ""NOIDA"",
    ""Pin"": 201301,
    ""Stcd"": ""09"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "

        End If
        postData &= " ""BuyerDtls"": {
    ""Gstin"": """ & buyer_gstin & """,
    ""LglNm"": """ & buyer_lglnm & """,
    ""TrdNm"": """ & buyer_trdnm & """,
    ""Pos"": """ & buyer_pos & """,
    ""Addr1"": """ & buyer_addres1 & """,
    ""Addr2"": """ & buyer_addres2 & """,
    ""Loc"": """ & buyer_loc & """,
    ""Pin"": " & buyer_pin.ToString.Replace(" ", "") & ",
    ""Stcd"":""" & buyer_stcd & """  
  },"

        postData &= "  ""ShipDtls"": {
          ""Gstin"": """ & buyer_gstin & """,
          ""LglNm"": """ & buyer_lglnm & """,
          ""TrdNm"": """ & buyer_trdnm & """,
          ""Addr1"": """ & buyer_addres1 & """,
          ""Addr2"": """ & buyer_addres1 & """,
          ""Loc"": """ & buyer_loc & """,
          ""Pin"": " & buyer_pin.ToString.Replace(" ", "") & ",
          ""Stcd"": """ & buyer_stcd & """
        },"

        postData &= " " & S & ""

        If exp_inv = "Y" Then
            postData &= """ExpDtls"": {
    ""ShipBNo"": """ & exp_shipbno & """,
    ""ShipBDt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """,
        ""ForCur"": """ & exp_forcur & """
  }, "
        End If
        '    ""Port"": ""INABG1"",
        '""RefClm"": ""N"",
        ',
        '""CntCode"": ""AE""
        postData &= """EwbDtls"": {
       ""Distance"": 0,
    ""TransDocNo"": """ & document_no & """,
    ""TransDocDt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """,
    ""VehNo"": """ & VEHICLE_NO & """,
""TransMode"": ""1"" ,
        ""VehType"": ""R""
  }
}
"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        ' Set the ContentType property of the WebRequest.  
        request.ContentType = "application/json"
        ' Set the ContentLength property of the WebRequest.  
        request.ContentLength = byteArray.Length

        ' Get the request stream.  
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.  
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.  
        dataStream.Close()

        ' Get the response.  
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.  
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

        ' Get the stream containing content returned by the server.  
        ' The using block ensures the stream is automatically closed.
        Using dataStream1 As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.  
            Dim reader As New StreamReader(dataStream1)

            ' Read the content.  
            'Dim responseFromServer As String = reader.ReadToEnd()
            TextBox1.Text = reader.ReadToEnd()

        End Using

        ' Clean up the response.  
        response.Close()
        Txt_json.Text = postData
        Dim json As String = TextBox1.Text
        Dim read = Newtonsoft.Json.Linq.JObject.Parse(json)

        Try


            If read.Item("Success") = "Y" Then

                response_file_name = "D:\E_INVOICING\" & document_no & ".TXT"
                Dim FSTRM As New FileStream(response_file_name, FileMode.Create, FileAccess.Write)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(TextBox1.Text)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()

                eway_bill_no = ""
                Try
                    eway_bill_no = read.Item("EwbNo").ToString
                Catch ex As Exception

                End Try

                'Label1.Text = read.Item("EwbNo").ToString
                'Label2.Text = read.Item("statistics")("likeCount").ToString + " " + " times"
                sql = "insert into jan_einvoice_header "
                sql &= "(CUSTOMER_TRX_ID,TRX_NUMBER,TRX_DATE ,CREATION_DATE ,E_INV_DETAIL ,E_INV_STATUS,E_INV_ACKNO ,E_INV_IRN,E_INV_SIGNEDQRCODE,E_INV_EWBNO ,E_INV_ACKDT,supply_type) " ' ,E_INV_SIGNEDINVOICE,E_INVOICE_RESPONSE,RESPONSE_FILE_NAME
                sql &= " values((select CUSTOMER_TRX_ID from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')),trim('" & Tex_inv_no.Text & "'),(select TRX_DATE from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')),sysdate,null "
                If read.Item("Success").ToString = "Y" Then sql &= ", 1 " Else sql &= ", 0 "
                sql &= " ,'" & read.Item("AckNo").ToString & "' "
                sql &= ",'" & read.Item("Irn").ToString & "'"
                'sql &= ",'" & read.Item("SignedInvoice").ToString & "'"
                sql &= ",'" & read.Item("SignedQRCode").ToString & "'"
                sql &= ",'" & eway_bill_no & "'"
                sql &= ",to_date('" & read.Item("AckDt").ToString & "','YYYY-MM-dd HH24:MI:SS') "
                'sql &= ",'" & read.Item("AckDt").ToString & "'"
                sql &= ",'" & SUPPLY_TYPE & "'"
                sql &= " )"
                comand()
                Dim cmd1 As New OracleClient.OracleCommand
                Dim blob() As Byte = System.IO.File.ReadAllBytes(response_file_name)

                sql = "UPDATE jan_einvoice_header SET e_invoice_response=:BlobParameter WHERE TRX_NUMBER=" & document_no & ""
                Dim blobParameter As OracleClient.OracleParameter = New OracleClient.OracleParameter()
                blobParameter.OracleType = OracleClient.OracleType.Blob
                blobParameter.ParameterName = "BlobParameter"
                blobParameter.Value = blob
                If orcon.State = ConnectionState.Closed Then orcon.Open()
                cmd1 = New OracleClient.OracleCommand(sql, orcon)
                cmd1.Parameters.Add(blobParameter)
                cmd1.ExecuteNonQuery()
                orcon.Close()
                'MessageBox.Show("E-INVOICE GENERATED")

                sql = "update jan_inv_print set  e_inv_status='S' where inv_no='" & Tex_inv_no.Text & "'"
                comand()
                postData = ""
                'E-Way bill Download
                request = WebRequest.Create("" & Eway_bill_api_endpoint & "")
                ' Set the Method property of the request to POST.  
                request.Method = "POST"
                request.Headers.Add("x-cleartax-auth-token", "" & authentication_token & "")
                request.Headers.Add("owner_id", "" & OWNER_ID & "")
                request.Headers.Add("gstin", "" & first_party_number & "")
                'request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
                ' Create POST data and convert it to a byte array.  
                postData = "{
  ""ewb_numbers"": [
    " & eway_bill_no & "
  ],
  ""print_type"": ""DETAILED""
}"

                'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                byteArray = Encoding.UTF8.GetBytes(postData)

                ' Set the ContentType property of the WebRequest.  
                request.ContentType = "application/json"
                ' Set the ContentLength property of the WebRequest.  
                request.ContentLength = byteArray.Length

                ' Get the request stream.  
                dataStream = request.GetRequestStream()
                ' Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length)
                ' Close the Stream object.  
                dataStream.Close()

                Dim response_file As String = ""
                ' Get the response.  
                response = request.GetResponse()


                If CType(response, HttpWebResponse).StatusCode = HttpStatusCode.OK Then
                    Dim lReader As IO.Stream = CType(response, HttpWebResponse).GetResponseStream()


                    X = "D:\EWayBills.zip"
                    Dim lWriter As New IO.FileStream(X, IO.FileMode.Create, FileAccess.Write)
                    Dim lLength As Long
                    Dim lBytes(256) As Byte

                    Do

                        lLength = lReader.Read(lBytes, 0, lBytes.Length)
                        lWriter.Write(lBytes, 0, lLength)

                    Loop While lLength > 0

                    lWriter.Close()
                    lReader.Close()

                End If
            Else
                sql = "INSERT INTO JAN_MAIL_SYSTEM (MAIL_NO,MAIL_DATE,MAIL_SUBJECT,MAIL_PROGRAM,MAIL_FROM,MAIL_TO,MAIL_BODY"

                sql &= ",mail_sent)VALUES(jan_TEST_SEQ.nextval ,sysdate,'Issue in E-Invoice Generation Process','E-Invoice Generation Process','it-dev7@janatics.co.in','it-dev7@janatics.co.in" ',sales09@janatics.co.in"
                sql &= " ,'" & document_no & "," & TextBox1.Text & "'"

                'Dim drmail As String = ret_val("SELECT ROWTOCOL('SELECT EMAIL FROM JAN_BMS_LOGIN WHERE UNAME LIKE (''DR%'') AND INSTR(DR_REGION,''' || F.REGION || ''')>0 AND EMAIL IS NOT NULL ') MAIL FROM JAN_PICK_FORWARD_HISTORY_TAB F WHERE FORWARD_NO=" & FWD_NO)


                sql &= " ,0) "

                comand()

            End If
        Catch ex As Exception
            sql = "INSERT INTO JAN_MAIL_SYSTEM (MAIL_NO,MAIL_DATE,MAIL_SUBJECT,MAIL_PROGRAM,MAIL_FROM,MAIL_TO,MAIL_BODY"

            sql &= ",mail_sent)VALUES(jan_TEST_SEQ.nextval ,sysdate,'Issue in E-Waybill Generation Process','E-Waybill Generation Process','it-dev7@janatics.co.in','it-dev7@janatics.co.in" ',sales09@janatics.co.in"
            sql &= " ,'" & document_no & "," & TextBox1.Text & "'"

            'Dim drmail As String = ret_val("SELECT ROWTOCOL('SELECT EMAIL FROM JAN_BMS_LOGIN WHERE UNAME LIKE (''DR%'') AND INSTR(DR_REGION,''' || F.REGION || ''')>0 AND EMAIL IS NOT NULL ') MAIL FROM JAN_PICK_FORWARD_HISTORY_TAB F WHERE FORWARD_NO=" & FWD_NO)


            sql &= " ,0) "

            comand()
        End Try
    End Sub

    Dim document_no, response_file_name, first_party_number, eway_bill_no, Einvoice_api_endpoint, Eway_bill_api_endpoint, authentication_token As String


    Dim document_date As Date
    Dim ds_inv As New DataSet
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Timer1.Tag = True Then
            Timer1.Tag = False
        Else
            Timer1.Tag = True
            generate_einvoice()

        End If

    End Sub



    Private Sub btn_open_attachment_Click(sender As Object, e As EventArgs) Handles btn_open_attachment.Click
        Dim ol As String
        ol = open_lob("trx_number", "" & Tex_inv_no.Text & "", "jan_einvoice_header", "e_invoice_response", "" & Tex_inv_no.Text & ".text", orcon)
        'ol = open_lob("TASK_ID", dgv1.Rows(dgv1.CurrentRow.Index).Cells("TASK_ID1").Value, "jan_TASK_MASTER", "ATTACHMENT", dgv1.Rows(dgv1.CurrentRow.Index).Cells("ATTACHMENT").Value, orcon)
        ol = Nothing
    End Sub




    '
    'The output from this example will vary depending on the value passed into Main 
    'but will be similar to the following:
    '
    'Content length is 1542
    'Content type is text/html; charset=utf-8
    'Response stream received.
    '...
    '
    '
    Private Sub Main()
        ' Create a request using a URL that can receive a post.
        Dim request As Net.WebRequest = Net.WebRequest.Create("https://reqres.in/api/login")
        ' Set the Method property of the request to POST.
        request.Method = "POST"

        ' Create POST data and convert it to a byte array.
        Dim postData As String = "{    ""email"": ""eve.holt@reqres.in"",    ""password"": ""cityslicka""}"
        Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)

        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length

        ' Get the request stream.
        Dim dataStream As System.IO.Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()

        ' Get the response.
        Dim response As Net.WebResponse = request.GetResponse()
        ' Display the status.
        'Console.WriteLine(CType(response, Net.HttpWebResponse).StatusDescription)
        TextBox1.Text = CType(response, Net.HttpWebResponse).StatusDescription

        ' Get the stream containing content returned by the server.
        ' The using block ensures the stream is automatically closed.
        Using CSharpImpl_Assign(dataStream, response.GetResponseStream())
            ' Open the stream using a StreamReader for easy access.
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            ' Display the content.
            'Console.WriteLine(responseFromServer)
            'TextBox2.Text = responseFromServer
        End Using


        '' Close the response.
        'response.Close()
    End Sub
    Private Sub SurroundingSub()
        ' Creates an HttpWebRequest with the specified URL.
        Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://reqres.in/api/users"), HttpWebRequest)
        ' Sends the HttpWebRequest and waits for the response.			
        Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
        ' Gets the stream associated with the response.
        Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
        Dim encode As Encoding = Encoding.GetEncoding("utf-8")
        ' Pipes the stream to a higher level stream reader with the required encoding format.
        Dim readStream As StreamReader = New StreamReader(receiveStream, encode)
        Console.WriteLine(vbCrLf & "Response stream received.")
        Dim read As Char() = New Char(255) {}
        ' Reads 256 characters at a time.
        Dim count As Integer = readStream.Read(read, 0, 256)
        Console.WriteLine("HTML..." & vbCrLf)

        While count > 0
            ' Dumps the 256 characters on a string and displays the string to the console.
            Dim str As String = New [String](read, 0, count)
            Console.Write(str)
            count = readStream.Read(read, 0, 256)
            TextBox1.Text = str
        End While

        Console.WriteLine("")
        ' Releases the resources of the response.
        myHttpWebResponse.Close()
        ' Releases the resources of the Stream.
        readStream.Close()
    End Sub
    Private Sub api_post_req2()
        Dim httpWebRequest = DirectCast(WebRequest.Create("https://reqres.in/api/register"), HttpWebRequest)
        httpWebRequest.ContentType = "application/json"
        httpWebRequest.Method = "POST"

        'Dim streamWriter As Stream = httpWebRequest.GetRequestStream()
        Using streamWriter As StreamWriter = New StreamWriter("httpWebRequest.GetRequestStream()")

            'Dim json As String = "{'api_key': ""api-123456123456123456123456"", 'username': ""user@domain.com"", 'description': ""Generated via API"" }"
            Dim json As String = "{
    ""email"": ""eve.holt@reqres.in"",
   ""password"": ""pistol""
}"

            streamWriter.Write(json)
            streamWriter.Close()

        End Using

        Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
        Using streamReader As StreamReader = New StreamReader("httpResponse.GetResponseStream()")
            Dim result = streamReader.ReadToEnd()
        End Using
    End Sub
    Private Sub api_post_req()
        Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://reqres.in/api/register"), HttpWebRequest)
        myHttpWebRequest.Method = "POST"


        'Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :")
        ' Create a new string object to POST data to the Url.
        Dim inputData As String = "{
    ""email"": ""eve.holt@reqres.in"",
    ""password"": ""pistol""
}"
        Dim postData As String = inputData
        Dim encoding As New ASCIIEncoding()
        Dim byte1 As Byte() = encoding.GetBytes(postData)
        ' Set the content type of the data being posted.
        myHttpWebRequest.ContentType = "application/json"
        ' Set the content length of the string being posted.
        myHttpWebRequest.ContentLength = byte1.Length
        Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
        Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
        newStream.Write(byte1, 0, byte1.Length)
        Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength)
        newStream.Close()
        Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
        Dim streamRead As New StreamReader(streamResponse)
        Dim readBuff(256) As [Char]

        Dim count As Integer = streamRead.Read(readBuff, 0, 256)
        Console.WriteLine(ControlChars.Cr + "The HTML contents of page the are  : " + ControlChars.Cr + ControlChars.Cr + " ")
        While count > 0
            Dim outputData As New [String](readBuff, 0, count)
            Console.Write(outputData)
            count = streamRead.Read(readBuff, 0, 256)
        End While
    End Sub
    Private Sub EWB_DOWNLOAD()
        Dim request As WebRequest = WebRequest.Create("https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print")
        ' Set the Method property of the request to POST.  
        request.Method = "POST"
        request.Headers.Add("x-cleartax-auth-token", "1.cad216c1-00b3-40e2-acbc-1d1245fbf704_c8dd9a1b2defe498ace54a80616e55c270477e787abf57e615dccfe544bb8e5f")
        request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
        request.Headers.Add("gstin", "29AAFCD5862R000")
        'request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
        ' Create POST data and convert it to a byte array.  
        Dim postData As String = "{
  ""ewb_numbers"": [
    131009079549
  ],
  ""print_type"": ""DETAILED""
}"

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        ' Set the ContentType property of the WebRequest.  
        request.ContentType = "application/json"
        ' Set the ContentLength property of the WebRequest.  
        request.ContentLength = byteArray.Length

        ' Get the request stream.  
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.  
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.  
        dataStream.Close()

        Dim response_file As String = ""
        ' Get the response.  
        Dim response As WebResponse = request.GetResponse()


        If CType(response, HttpWebResponse).StatusCode = HttpStatusCode.OK Then
            Dim lReader As IO.Stream = CType(response, HttpWebResponse).GetResponseStream()


            X = "D:\EWayBills.zip"
            Dim lWriter As New IO.FileStream(X, IO.FileMode.Create, FileAccess.Write)
            Dim lLength As Long
            Dim lBytes(256) As Byte

            Do

                lLength = lReader.Read(lBytes, 0, lBytes.Length)
                lWriter.Write(lBytes, 0, lLength)

            Loop While lLength > 0

            lWriter.Close()
            lReader.Close()

        End If
        response_file = response.Headers("Content-Disposition")

        Dim remoteUri1 As String = "https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print/"
        Dim fileName1 As String = "EWayBills_28-12-2020.zip"
        Dim myStringWebResource1 As String = Nothing
        ' Create a new WebClient instance.
        Dim myWebClient1 As New WebClient()
        ' Concatenate the domain with the Web resource filename. Because DownloadFile 
        'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
        myStringWebResource1 = remoteUri1 + fileName1
        Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName1, myStringWebResource1)
        ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
        myWebClient1.DownloadFile(myStringWebResource1, fileName1)


        response.Headers.Add("Content-Disposition:," & response_file & "")
        response.ContentType = "application/zip"

        'response.AppendHeader("content-disposition", "attachment; filename=" + fileName)
        'response.ContentType = "application/octet-stream";
        'response.WriteFile("D:\")
        'response.Flush()
        'response.End()

        ' Display the status.  
        'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        'X = "C:\EWayBills_30-12-2020.html"
        X = "D:\EWayBills.html"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()


        Dim dest As String = "C:\test.zip"
        Dim ws As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Dim str As Stream = ws.GetResponseStream()
        Dim a As Integer = ws.ContentLength

        Dim inBuf(a) As Byte

        Dim bytesToRead As Integer = CInt(inBuf.Length)

        Dim bytesRead As Integer = 0

        While bytesToRead > 0

            Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)

            If n = 0 Then

                Exit While

            End If

            bytesRead += n

            bytesToRead -= n

        End While
        Dim fstr As New FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write)

        fstr.Write(inBuf, 0, bytesRead)

        str.Close()

        fstr.Close()



        'postresponse = postReq.GetResponse()
        'If postresponse.StatusCode = Net.HttpStatusCode.OK Then
        '    Dim lReader As IO.Stream = postresponse.GetResponseStream()
        '    Dim lWriter As New IO.FileStream(lLocal, IO.FileMode.Create)

        '    Dim lLength As Long
        '    Dim lBytes(256) As Byte

        '    Do

        '        lLength = lReader.Read(lBytes, 0, lBytes.Length)
        '        lWriter.Write(lBytes, 0, lLength)

        '    Loop While lLength > 0

        '    lWriter.Close()
        '    lReader.Close()

        'Dim response As WebResponse = request.GetResponse()
        'Using s As Stream = WebRequest.GetResponse().GetResponseStream()
        Using s As Stream = request.GetResponse().GetResponseStream()

            Using sr As StreamReader = New StreamReader(s)
                'Save zip file on C: drive
            End Using
        End Using

        DownloadFile("https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print")
        Dim file_name As String = CType(response, WebResponse).Headers("Content-Disposition")


        Dim remoteUri As String = "https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print"
        Dim fileName As String = "EWayBills_15-12-2020.zip"
        Dim myStringWebResource As String = Nothing
        ' Create a new WebClient instance.
        Dim myWebClient As New WebClient()
        ' Concatenate the domain with the Web resource filename. Because DownloadFile 
        'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
        myStringWebResource = remoteUri + fileName
        Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName, myStringWebResource)
        ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
        myWebClient.DownloadFile(myStringWebResource, fileName)

        ' Get the stream containing content returned by the server.  
        ' The using block ensures the stream is automatically closed.
        Using dataStream1 As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.  
            Dim reader As New StreamReader(dataStream1)
            ' Read the content.  
            'Dim responseFromServer As String = reader.ReadToEnd()
            TextBox1.Text = reader.ReadToEnd()

            ' Display the content.  
            'Console.WriteLine(responseFromServer)
        End Using

        ' Clean up the response.  
        response.Close()
    End Sub
    Private Shared Function DownloadFile(ByVal url As String) As String
        Dim filename As String = ""
        Dim webRequest = Net.WebRequest.Create(url)
        webRequest.appendheader("Content-Disposition", "attachment; filename=""EWayBills_28-12-2020.zip")
        webRequest.ContentType = "application/zip"
        webRequest.Method = "GET"
        'webRequest.Headers.Add("X-API-TOKEN: XXXXXXXXX")
        webRequest.Headers.Add("x-cleartax-auth-token", "1.cad216c1-00b3-40e2-acbc-1d1245fbf704_c8dd9a1b2defe498ace54a80616e55c270477e787abf57e615dccfe544bb8e5f")
        webRequest.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
        webRequest.Headers.Add("gstin", "29AAFCD5862R000")

        Using s As Stream = webRequest.GetResponse().GetResponseStream()

            Using sr As StreamReader = New StreamReader(s)
                'Save zip file on C: drive
            End Using
        End Using

        Return filename
    End Function


    Private Sub FILE_DOWNLOAD()
        Dim remoteUri As String = "http://www.contoso.com/library/homepage/images/"
        Dim fileName As String = "ms-banner.gif"
        Dim myStringWebResource As String = Nothing
        ' Create a new WebClient instance.
        Dim myWebClient As New WebClient()
        ' Concatenate the domain with the Web resource filename. Because DownloadFile 
        'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
        myStringWebResource = remoteUri + fileName
        Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName, myStringWebResource)
        ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
        myWebClient.DownloadFile(myStringWebResource, fileName)
        Console.WriteLine("Successfully Downloaded file ""{0}"" from ""{1}""", fileName, myStringWebResource)
        Console.WriteLine((ControlChars.Cr + "Downloaded file saved in the following file system folder:" + ControlChars.Cr + ControlChars.Tab + Application.StartupPath))
    End Sub
    Private Sub generate_einvoice()
        Timer1.Stop()

        ds_inv = New DataSet
        'sql = "select BILL_TO_CUSTOMER_ID,BILL_TO_CUST_nAME,region,trx_date,trx_number,customer_trx_id,count(*)line_count from jan_invoice_listing  a where trx_date='28-dec-2020'  and trx_number='2020100587'  group by trx_date,trx_number,customer_trx_id,BILL_TO_CUST_nAME,BILL_TO_CUSTOMER_ID,region"
        sql = " select a.*,inv_no trx_number ,(select trx_date from ra_customer_trx_all where trx_number=a.inv_no)trx_date from jan_inv_print  a where trunc(cr_dt)=trunc(sysdate)-1 and inv_no='2060100757' and  e_inv_status='N' order  by inv_no"
        adap = New OracleClient.OracleDataAdapter(sql, con)
            adap.Fill(ds_inv, "inv_no")
        For k = 0 To ds_inv.Tables("inv_no").Rows.Count - 1
            Try
                If i Mod 10 = 0 Then
                    wait(1000)
                End If
                Tex_inv_no.Text = ds_inv.Tables("inv_no").Rows(k).Item("trx_number")

                sql = "update jan_inv_print set  e_inv_status='P' where inv_no='" & Tex_inv_no.Text & "'"
                comand()

                SUPPLY_TYPE = ""
                document_no = ""
                buyer_gstin = ""
                buyer_lglnm = ""
                buyer_trdnm = ""
                buyer_pos = ""
                buyer_addres1 = ""
                buyer_addres2 = ""
                buyer_loc = ""
                buyer_pin = ""
                buyer_stcd = ""
                exp_inv = ""
                exp_shipbno = ""
                exp_shipbdt = ""
                exp_port = ""
                exp_refclm = ""
                exp_forcur = ""
                exp_cntcode = ""
                EXP_CURRENCY = ""
                VEHICLE_NO = ""
                first_party_number = ""

                ds1 = New DataSet
                sql = "select customer_trx_id,trx_date  from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')"
                sql = "select * from jan_einvoice_base_details_v where trx_number=trim('" & Tex_inv_no.Text & "') and trx_date='" & Format(ds_inv.Tables("inv_no").Rows(k).Item("trx_date"), "dd-MMM-yyyy") & "'"
                adap = New OracleClient.OracleDataAdapter(sql, con)
                adap.Fill(ds1, "cust_trx_id")

                ds2 = New DataSet
                sql = " select DISTINCT wnd.global_attribute20 vehicle_no from wsh_new_deliveries wnd,wsh_delivery_assignments wda,wsh_delivery_details wdd where    wdd.delivery_detail_id = wda.delivery_detail_id AND wnd.delivery_id = wda.delivery_id AND  wdd.source_line_id IN  (select INTERFACE_LINE_ATTRIBUTE6    from ra_customer_trx_lines_all  INVL where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("custOMER_trx_id") & "    AND LINE_TYPE='LINE')"
                adap = New OracleClient.OracleDataAdapter(sql, con)
                adap.Fill(ds2, "VEH_NO")

                VEHICLE_NO = ds2.Tables("VEH_NO").Rows(0).Item("vehicle_no").ToString

                If VEHICLE_NO = "" Then
                    VEHICLE_NO = "ka123456"
                End If

                For i = 0 To ds1.Tables("cust_trx_id").Rows.Count - 1
                    With ds1.Tables("cust_trx_id").Rows(i)

                        buyer_lglnm = .Item("bill_to_cust_name")
                        buyer_trdnm = .Item("bill_to_cust_name")
                        first_party_number = .Item("first_party_gst").ToString.Substring(0, 15)
                        If .Item("ORDER_TYPE").ToString.ToUpper.Contains("EXP") And .Item("invoice_currency_code") <> "INR" Then
                            buyer_pos = "96"
                            SUPPLY_TYPE = "EXPWP"
                            buyer_gstin = "URP"
                            buyer_stcd = "96"
                            buyer_pin = "999999"
                            exp_inv = "Y"
                            exp_shipbno = .Item("trx_number")
                            exp_shipbdt = Format(.Item("trx_date"), "dd/MM/yyyy")
                            exp_port = ""
                            exp_refclm = ""
                            exp_forcur = .Item("invoice_currency_code")
                            exp_cntcode = ""
                        Else
                            SUPPLY_TYPE = "B2B"
                            buyer_pos = .Item("buyer_state_code")
                            buyer_gstin = .Item("buyer_gstin")
                            buyer_pin = .Item("buyer_pin_code")
                            buyer_stcd = .Item("buyer_state_code")
                        End If
                        buyer_addres1 = .Item("buyer_ADDRESS1")
                        buyer_addres2 = .Item("buyer_ADDRESS2")
                        buyer_loc = .Item("ship_to_site").ToString.PadRight(3)

                        document_no = .Item("trx_number")
                        document_date = Format(.Item("trx_date"), "dd/MM/yyyy")

                    End With
                Next

                sql = "delete from jan_inv1"
                comand()



                sql = "insert into jan_inv1(select  CUSTOMER_TRX_ID, CUSTOMER_TRX_LINE_ID,TRX_NUMBER ,TRX_DATE ,OE_LINE_ID ,MON ,TYEAR ,UOM ,My, CREATION_DATE, ORDER_NUMBER, OATYPE, ORDER_DATE, ORDERED_ITEM, INVENTORY_ITEM_ID, DESCRIPTION,QUANTITY_INVOICED ,EXTENDED_AMOUNT,UNIT_STANDARD_PRICE ,UNIT_SELLING_PRICE ,OLP,SHIPPING_INSTRUCTIONS ,ATTRIBUTE3,CONVERSION_RATE ,SHIP_TO_CUST_NAME ,SHIP_TO_CUST_ID ,BILL_TO_CUSTOMER_ID,CUSTOMER_CLASS_CODE,BILL_TO_CUST_NAME ,SHIP_TO_ADDRESS,SHIP_TO_SITE,BILL_TO_SITE,BILL_TO_ADDRESS,ORGANIZATION_ID ,DISC,case when trx_number='1870170826' then '4508126996  / 40' else C_ORDER_NO end C_ORDER_NO,C_ORDER_DATE ,ECC_NO,ST_NO,CST_NO, SECC_NO ,SST_NO ,SCST_NO ,REGION ,TARIFF_NO ,TOT_CHK_AMT ,INS_TEXT ,GL_DATE,SHORT_TEXT,  CUS_DRG_NO,SCHEDULE_SHIP_DATE,BATCH_SOURCE_ID,CUST_TRX_TYPE_ID,CAT_ID,ATTRIBUTE1 ,BRANCH_EMPLOYEE from jan_invoice_listing where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
                comand()

                sql = "delete from jan_inv4"
                comand()

                sql = "insert into jan_inv4(select * from jan_invoice_tax where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
                comand()


                ds = New DataSet
                sql = "select  ordered_item||','||description prd_desc,case when upper(oatype)  like 'SERVICE%' then 'Y' else 'N' end  isservc "

                sql &= ",case when upper(oatype)  Like 'SERVICE %' then (select sac_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id) else nvl((select hsn_code from JAN_GST_RA_CUST_TRX_LINES_V where TRX_LINE_ID=a.customer_trx_line_id),(select hsn_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id)) end hsn_code "

                sql &= " ,quantity_invoiced  qty,upper(uom)unit_code,unit_selling_price unit_price,(quantity_invoiced*unit_selling_price) totamt "

                sql &= " ,(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"

                'sql &= " , nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"
                sql &= " ,0 as assamt"
                sql &= " ,nvl((SELECT sum(tax_rate) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST','CGST','SGST') ),0)gstrt"
                sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST') ),0)igstamt "
                sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('CGST') ),0)cgstamt "
                sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('SGST') ),0)sgstamt "
                sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type  Like '%TCS%' ),0)othchrg "
                sql &= ",(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE  CUSTOMER_TRX_LINE_ID in a.customer_trx_line_id And tax_type NOT Like '%TCS%'),0)TOTITEMVAL,a.* from jan_inv1 a where trx_date>'1-dec-2020' and  customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & " order by customer_trx_line_id"
                adap = New OracleClient.OracleDataAdapter(sql, con)
                adap.Fill(ds, "item_details")

                For i = 0 To ds.Tables("item_details").Rows.Count - 1
                    With ds.Tables("item_details").Rows(i)
                        .Item("assamt") = .Item("pretaxval")
                        .Item("totamt") = .Item("pretaxval")
                    End With
                Next


                TOT_ASS_VAL = 0
                TOT_CGSTVAL = 0
                TOT_SGST_VAL = 0
                TOT_IGST_VAL = 0
                TOT_DISC = 0
                TOT_OthChrg = 0

                S = ""
                S &= """ItemList"" : [" & vbNewLine
                For i = 0 To ds.Tables("item_details").Rows.Count - 1
                    With ds.Tables("item_details").Rows(i)
                        TOT_ASS_VAL += .Item("assamt")
                        TOT_CGSTVAL += .Item("CgstAmt")
                        TOT_SGST_VAL += .Item("SgstAmt")
                        TOT_IGST_VAL += .Item("IgstAmt")
                        'TOT_DISC += .Item("assamt")
                        TOT_OthChrg += .Item("OthChrg")

                        If i <> 0 Then S &= " ," & vbNewLine

                        S &= "  { " & vbNewLine
                        S &= " ""SlNo"": """ & i + 1 & """," & vbNewLine
                        S &= """PrdDesc"":""" & .Item("prd_desc").ToString.Replace("""", "") & """," & vbNewLine
                        S &= """IsServc"":""" & .Item("isservc") & """," & vbNewLine
                        S &= """HsnCd"":""" & .Item("hsn_code") & """," & vbNewLine
                        S &= """Qty"":" & .Item("qty") & "," & vbNewLine
                        S &= """Unit"":""" & .Item("unit_code") & """," & vbNewLine
                        S &= """UnitPrice"":" & .Item("unit_price") & "," & vbNewLine
                        S &= """TotAmt"":" & .Item("totamt") & "," & vbNewLine

                        S &= """PreTaxVal"":" & .Item("PreTaxVal") & "," & vbNewLine
                        S &= """AssAmt"":" & .Item("assamt") & "," & vbNewLine
                        S &= """GstRt"":" & .Item("gstrt") & "," & vbNewLine
                        S &= """IgstAmt"":" & .Item("IgstAmt") & "," & vbNewLine
                        S &= """CgstAmt"":" & .Item("CgstAmt") & "," & vbNewLine
                        S &= """SgstAmt"":" & .Item("SgstAmt") & "," & vbNewLine
                        'S &= """OthChrg"":" & .Item("OthChrg") & "," & vbNewLine
                        S &= """TotItemVal"":" & .Item("TotItemVal") & "" & vbNewLine
                        S &= " } " & vbNewLine

                    End With

                Next
                S &= " ]," & vbNewLine
                NET_TOTAL = TOT_ASS_VAL + TOT_CGSTVAL + TOT_SGST_VAL + TOT_IGST_VAL + TOT_DISC + TOT_OthChrg
                S &= " ""ValDtls"": { "
                S &= " ""AssVal"": " & TOT_ASS_VAL & "," & vbNewLine
                S &= " ""CgstVal"" :  " & TOT_CGSTVAL & "," & vbNewLine
                S &= " ""SgstVal"":" & TOT_SGST_VAL & "," & vbNewLine
                S &= " ""IgstVal"" :   " & TOT_IGST_VAL & "," & vbNewLine
                S &= " ""Discount"": " & TOT_DISC & "," & vbNewLine
                S &= " ""OthChrg"": " & TOT_OthChrg & "," & vbNewLine
                S &= " ""RndOffAmt"": 0.3," & vbNewLine
                S &= " ""TotInvVal"": " & Math.Round(NET_TOTAL) & "," & vbNewLine
                S &= " ""TotInvValFc"": " & NET_TOTAL & "" & vbNewLine
                S &= "  },"
                Txt_json.Text = S
                api_test3()

            Catch ex As Exception

                sql = "update jan_inv_print set  e_inv_status='E' where inv_no='" & Tex_inv_no.Text & "'"
                comand()

                sql = "INSERT INTO JAN_MAIL_SYSTEM (MAIL_NO,MAIL_DATE,MAIL_SUBJECT,MAIL_PROGRAM,MAIL_FROM,MAIL_TO,MAIL_BODY"

                sql &= ",mail_sent)VALUES(jan_TEST_SEQ.nextval ,sysdate,'Issue in E-Invoice Generation Process for Inv No : " & document_no & "','E-Invoice Generation Process','it-dev7@janatics.co.in','it-dev7@janatics.co.in'" ',sales09@janatics.co.in"
                sql &= " ,'" & ex.ToString & "'"

                'Dim drmail As String = ret_val("SELECT ROWTOCOL('SELECT EMAIL FROM JAN_BMS_LOGIN WHERE UNAME LIKE (''DR%'') AND INSTR(DR_REGION,''' || F.REGION || ''')>0 AND EMAIL IS NOT NULL ') MAIL FROM JAN_PICK_FORWARD_HISTORY_TAB F WHERE FORWARD_NO=" & FWD_NO)


                sql &= " ,0) "

                comand()
            End Try
        Next

        Timer1.Start()
    End Sub
    Private Sub API_testing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Enabled = True
        'Timer1.Start()

        'Dim strPath As String = "d://EWayBills.zip"



        ' Dim  filename  As String = ""


        'filename = Path.GetFileName(strPath)

        'Dim startPath As String = ".\start"
        'Dim zipPath As String = ".\result.zip"
        'Dim extractPath As String = ".\extract"

        'ZipFile.CreateFromDirectory(startPath, zipPath)

        'ZipFile.ExtractToDirectory(zipPath, extractPath)

        'Dim zipPath As String = "c:\users\exampleuser\end.zip"
        'Dim extractPath As String = "c:\users\exampleuser\extract"
        'Dim newFile As String = "c:\users\exampleuser\NewFile.txt"

        'Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update)
        '    archive.CreateEntryFromFile(newFile, "NewEntry.txt", CompressionLevel.Fastest)
        '    archive.ExtractToDirectory(extractPath)
        'End Using

        'generate_einvoice()


        'FILE_DOWNLOAD()

        'EWB_DOWNLOAD()

        'api_test3()
        Exit Sub



        api_post_req2()


        ' Create a new 'HttpWebRequest' Object to the mentioned URL.
        Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
        ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
        Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
        Console.WriteLine(ControlChars.Cr + "The HttpHeaders are " + ControlChars.Cr + ControlChars.Cr + ControlChars.Tab + "Name" + ControlChars.Tab + ControlChars.Tab + "Value" + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)

        ' Print the HTML contents of the page to the console. 
        Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
        Dim streamRead As New StreamReader(streamResponse)
        Dim readBuff(256) As [Char]
        Dim count As Integer = streamRead.Read(readBuff, 0, 256)
        Console.WriteLine(ControlChars.Cr + "The HTML contents of page the are  : " + ControlChars.Cr + ControlChars.Cr + " ")
        While count > 0
            Dim outputData As New [String](readBuff, 0, count)
            Console.Write(outputData)
            count = streamRead.Read(readBuff, 0, 256)
        End While
        ' Close the Stream object.
        streamResponse.Close()
        streamRead.Close()
        ' Release the HttpWebResponse Resource.
        myHttpWebResponse.Close()
        'SurroundingSub()
        'Exit Sub
        'Main()
        Dim request As HttpWebRequest = WebRequest.Create("https://reqres.in/api/users")
        request.Method = "POST"
        'add headers
        'request.Headers.Add("Content-Type", "application/json")
        'add other headers
        '....
        'add body
        Dim stream As Stream = request.GetRequestStream()
        Dim jsonData As String = "{
    ""name"": ""morpheus"",
    ""job"": ""leader""
}"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(jsonData)
        stream.Write(buffer, 0, buffer.Length)
        'send request
        request.GetResponse()

    End Sub

    Private Function CSharpImpl_Assign(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SUPPLY_TYPE = ""
        document_no = ""
        buyer_gstin = ""
        buyer_lglnm = ""
        buyer_trdnm = ""
        buyer_pos = ""
        buyer_addres1 = ""
        buyer_addres2 = ""
        buyer_loc = ""
        buyer_pin = ""
        buyer_stcd = ""
        exp_inv = ""
        exp_shipbno = ""
        exp_shipbdt = ""
        exp_port = ""
        exp_refclm = ""
        exp_forcur = ""
        exp_cntcode = ""
        EXP_CURRENCY = ""
        VEHICLE_NO = ""
        first_party_number = ""
        ds1 = New DataSet
        sql = "select customer_trx_id,trx_date  from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')"
        sql = "select * from jan_einvoice_base_details_v where trx_number=trim('" & Tex_inv_no.Text & "')"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds1, "cust_trx_id")

        ds2 = New DataSet
        sql = " select DISTINCT wnd.global_attribute20 vehicle_no from wsh_new_deliveries wnd,wsh_delivery_assignments wda,wsh_delivery_details wdd where    wdd.delivery_detail_id = wda.delivery_detail_id AND wnd.delivery_id = wda.delivery_id AND  wdd.source_line_id IN  (select INTERFACE_LINE_ATTRIBUTE6    from ra_customer_trx_lines_all  INVL where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("custOMER_trx_id") & "    AND LINE_TYPE='LINE')"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds2, "VEH_NO")

        VEHICLE_NO = ds2.Tables("VEH_NO").Rows(0).Item("vehicle_no").ToString

        For i = 0 To ds1.Tables("cust_trx_id").Rows.Count - 1
            With ds1.Tables("cust_trx_id").Rows(i)


                buyer_lglnm = .Item("bill_to_cust_name")
                buyer_trdnm = .Item("bill_to_cust_name")
                first_party_number = .Item("first_party_gst")
                If .Item("ORDER_TYPE").ToString.ToUpper.Contains("EXP") And .Item("invoice_currency_code") <> "INR" Then
                    buyer_pos = "96"
                    SUPPLY_TYPE = "EXPWOP"
                    buyer_gstin = "URP"
                    buyer_stcd = "96"
                    buyer_pin = "999999"
                    exp_inv = "Y"
                    exp_shipbno = .Item("trx_number")
                    exp_shipbdt = Format(.Item("trx_date"), "dd/MM/yyyy")
                    exp_port = ""
                    exp_refclm = ""
                    exp_forcur = .Item("invoice_currency_code")
                    exp_cntcode = ""
                Else
                    SUPPLY_TYPE = "B2B"
                    buyer_pos = .Item("buyer_state_code")
                    buyer_gstin = .Item("buyer_gstin")
                    buyer_pin = .Item("buyer_pin_code")
                    buyer_stcd = .Item("buyer_state_code")
                End If
                buyer_addres1 = .Item("buyer_ADDRESS1")
                buyer_addres2 = .Item("buyer_ADDRESS2")
                buyer_loc = .Item("ship_to_site").ToString.PadRight(3)

                document_no = .Item("trx_number")
                document_date = Format(.Item("trx_date"), "dd/MM/yyyy")

            End With
        Next

        sql = "delete from jan_inv1"
        comand()



        sql = "insert into jan_inv1(select  CUSTOMER_TRX_ID, CUSTOMER_TRX_LINE_ID,TRX_NUMBER ,TRX_DATE ,OE_LINE_ID ,MON ,TYEAR ,UOM ,My, CREATION_DATE, ORDER_NUMBER, OATYPE, ORDER_DATE, ORDERED_ITEM, INVENTORY_ITEM_ID, DESCRIPTION,QUANTITY_INVOICED ,EXTENDED_AMOUNT,UNIT_STANDARD_PRICE ,UNIT_SELLING_PRICE ,OLP,SHIPPING_INSTRUCTIONS ,ATTRIBUTE3,CONVERSION_RATE ,SHIP_TO_CUST_NAME ,SHIP_TO_CUST_ID ,BILL_TO_CUSTOMER_ID,CUSTOMER_CLASS_CODE,BILL_TO_CUST_NAME ,SHIP_TO_ADDRESS,SHIP_TO_SITE,BILL_TO_SITE,BILL_TO_ADDRESS,ORGANIZATION_ID ,DISC,case when trx_number='1870170826' then '4508126996  / 40' else C_ORDER_NO end C_ORDER_NO,C_ORDER_DATE ,ECC_NO,ST_NO,CST_NO, SECC_NO ,SST_NO ,SCST_NO ,REGION ,TARIFF_NO ,TOT_CHK_AMT ,INS_TEXT ,GL_DATE,SHORT_TEXT,  CUS_DRG_NO,SCHEDULE_SHIP_DATE,BATCH_SOURCE_ID,CUST_TRX_TYPE_ID,CAT_ID,ATTRIBUTE1 ,BRANCH_EMPLOYEE from jan_invoice_listing where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
        comand()

        sql = "delete from jan_inv4"
        comand()

        sql = "insert into jan_inv4(select * from jan_invoice_tax where customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & ")"
        comand()


        ds = New DataSet
        sql = "select  ordered_item||','||description prd_desc,case when upper(oatype)  like 'SERVICE%' then 'Y' else 'N' end  isservc "

        sql &= ",case when upper(oatype)  Like 'SERVICE %' then (select sac_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id) else nvl((select hsn_code from JAN_GST_RA_CUST_TRX_LINES_V where TRX_LINE_ID=a.customer_trx_line_id),(select hsn_code from JAN_ITEM_HSN_MASTER_V where organization_id=a.organization_id and inventory_item_id=a.inventory_item_id)) end hsn_code "

        sql &= " ,quantity_invoiced  qty,upper(uom)unit_code,unit_selling_price unit_price,(quantity_invoiced*unit_selling_price) totamt "

        sql &= " ,(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"

        'sql &= " , nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And (upper(tax_type) like '%OTHER%' or upper(tax_type) like '%FREIGHT%' or upper(tax_type) like '%COSTUPDATION%')),0)pretaxval"
        sql &= " ,0 as assamt"
        sql &= " ,nvl((SELECT sum(tax_rate) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST','CGST','SGST') ),0)gstrt"
        sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('IGST') ),0)igstamt "
        sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('CGST') ),0)cgstamt "
        sql &= " ,nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type in ('SGST') ),0)sgstamt "
        sql &= ",nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE CUSTOMER_TRX_LINE_ID=a.customer_trx_line_id And tax_type  Like '%TCS%' ),0)othchrg "
        sql &= ",(quantity_invoiced*unit_selling_price)+nvl((SELECT sum(extended_amount) FROM jan_inv4 WHERE  CUSTOMER_TRX_LINE_ID in a.customer_trx_line_id And tax_type NOT Like '%TCS%'),0)TOTITEMVAL,a.* from jan_inv1 a where trx_date>'1-dec-2020' and  customer_trx_id=" & ds1.Tables("cust_trx_id").Rows(0).Item("customer_trx_id") & " order by customer_trx_line_id"
        adap = New OracleClient.OracleDataAdapter(sql, con)
        adap.Fill(ds, "item_details")

        For i = 0 To ds.Tables("item_details").Rows.Count - 1
            With ds.Tables("item_details").Rows(i)
                .Item("assamt") = .Item("pretaxval")
                .Item("totamt") = .Item("pretaxval")

                '.Item("totamt") = .Item("totamt") + .Item("pretaxval")
                '.Item("assamt") = .Item("totamt")
            End With
        Next


        TOT_ASS_VAL = 0
        TOT_CGSTVAL = 0
        TOT_SGST_VAL = 0
        TOT_IGST_VAL = 0
        TOT_DISC = 0
        TOT_OthChrg = 0

        S = ""
        S &= """ItemList"" : [" & vbNewLine
        For i = 0 To ds.Tables("item_details").Rows.Count - 1
            With ds.Tables("item_details").Rows(i)
                TOT_ASS_VAL += .Item("assamt")
                TOT_CGSTVAL += .Item("CgstAmt")
                TOT_SGST_VAL += .Item("SgstAmt")
                TOT_IGST_VAL += .Item("IgstAmt")
                'TOT_DISC += .Item("assamt")
                TOT_OthChrg += .Item("OthChrg")

                If i <> 0 Then S &= " ," & vbNewLine

                S &= "  { " & vbNewLine
                S &= " ""SlNo"": """ & i + 1 & """," & vbNewLine
                S &= """PrdDesc"":""" & .Item("prd_desc").ToString.Replace("""", "") & """," & vbNewLine
                S &= """IsServc"":""" & .Item("isservc") & """," & vbNewLine
                S &= """HsnCd"":""" & .Item("hsn_code") & """," & vbNewLine
                S &= """Qty"":" & .Item("qty") & "," & vbNewLine
                S &= """Unit"":""" & .Item("unit_code") & """," & vbNewLine
                S &= """UnitPrice"":" & .Item("unit_price") & "," & vbNewLine
                S &= """TotAmt"":" & .Item("totamt") & "," & vbNewLine

                S &= """PreTaxVal"":" & .Item("PreTaxVal") & "," & vbNewLine
                S &= """AssAmt"":" & .Item("assamt") & "," & vbNewLine
                S &= """GstRt"":" & .Item("gstrt") & "," & vbNewLine
                S &= """IgstAmt"":" & .Item("IgstAmt") & "," & vbNewLine
                S &= """CgstAmt"":" & .Item("CgstAmt") & "," & vbNewLine
                S &= """SgstAmt"":" & .Item("SgstAmt") & "," & vbNewLine
                'S &= """OthChrg"":" & .Item("OthChrg") & "," & vbNewLine
                S &= """TotItemVal"":" & .Item("TotItemVal") & "" & vbNewLine
                S &= " } " & vbNewLine

            End With

        Next
        S &= " ]," & vbNewLine
        NET_TOTAL = TOT_ASS_VAL + TOT_CGSTVAL + TOT_SGST_VAL + TOT_IGST_VAL + TOT_DISC + TOT_OthChrg
        S &= " ""ValDtls"": { "
        S &= " ""AssVal"": " & TOT_ASS_VAL & "," & vbNewLine
        S &= " ""CgstVal"" :  " & TOT_CGSTVAL & "," & vbNewLine
        S &= " ""SgstVal"":" & TOT_SGST_VAL & "," & vbNewLine
        S &= " ""IgstVal"" :   " & TOT_IGST_VAL & "," & vbNewLine
        S &= " ""Discount"": " & TOT_DISC & "," & vbNewLine
        S &= " ""OthChrg"": " & TOT_OthChrg & "," & vbNewLine
        S &= " ""RndOffAmt"": 0.3," & vbNewLine
        S &= " ""TotInvVal"": " & Math.Round(NET_TOTAL) & "," & vbNewLine
        S &= " ""TotInvValFc"": " & NET_TOTAL & "" & vbNewLine
        S &= "  },"
        Txt_json.Text = S
        api_test3()
    End Sub

    Private Sub api_test3()
        Dim OWNER_ID As String = ""
        If first_party_number = "33AAACJ5553C1Z0" Then
            'OWNER_ID = "44be97e6-26fb-48d0-859d-621931ffc632"  ''sandbox id
            OWNER_ID = "0e486255-257b-4f1b-a03b-c02af5ee86a3" 'Production 
        ElseIf first_party_number = "24AAACJ5553C1ZZ" Then
            OWNER_ID = "8f7b2c96-b8e1-458a-851b-461fc75f3b05" 'Production

        ElseIf first_party_number = "09AAACJ5553C1ZR" Then
            OWNER_ID = "9d8f561b-c6bc-494e-b5c2-f9b3fea2dbec" 'Production
        End If
        Dim req_method As String = ""
        ''sandbox variables
        Einvoice_api_endpoint = "https://einvoicing.internal.cleartax.co/v1/govt/api/Invoice"
        Eway_bill_api_endpoint = "https://einvoicing.internal.cleartax.co/v2/eInvoice/ewaybill/print"
        authentication_token = "1.cad216c1-00b3-40e2-acbc-1d1245fbf704_c8dd9a1b2defe498ace54a80616e55c270477e787abf57e615dccfe544bb8e5f"
        req_method = "POST"
        ''End sandbox variables

        ''Production variables
        'Einvoice_api_endpoint = "https://api-einv.cleartax.in/v1/govt/api/Invoice"
        'Eway_bill_api_endpoint = "https://api-einv.cleartax.in/v2/eInvoice/ewaybill/print"
        'authentication_token = "1.cf77097f-e9b7-4a21-be72-eb7b165b460a_9580cff01e118eac51341a5e842b6c6829f56dd6c81bd6ee16f86628fa3bee58"
        'req_method = "POST"
        ''End Production variables


        ' Create a request using a URL that can receive a post.   
        'Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ")
        Dim request As WebRequest = WebRequest.Create("" & Einvoice_api_endpoint & "") 'sandbox
        'Dim request As WebRequest = WebRequest.Create("https://einv-gsp.cleartax.in/core/v1.03/Invoice") 'Production

        ' Set the Method property of the request to POST.  
        request.Method = "" & req_method & ""

        request.Headers.Add("x-cleartax-auth-token", "" & authentication_token & "")  'sandbox token

        'request.Headers.Add("x-cleartax-auth-token", "1.cf77097f-e9b7-4a21-be72-eb7b165b460a_9580cff01e118eac51341a5e842b6c6829f56dd6c81bd6ee16f86628fa3bee58") 'Production token
        'End Production token
        'request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
        'request.Headers.Add("gstin", "29AAFCD5862R000")
        request.Headers.Add("owner_id", "" & OWNER_ID & "")
        request.Headers.Add("gstin", "" & first_party_number & "")
        Dim postData As String = "{
  ""Version"": ""1.1"",
  ""TranDtls"": {
    ""TaxSch"": ""GST"",
    ""SupTyp"": """ & SUPPLY_TYPE & """,
    ""RegRev"": ""N"",
    ""EcmGstin"": null,
    ""IgstOnIntra"": ""N""
  },
  ""DocDtls"": {
    ""Typ"": ""INV"",
    ""No"": """ & document_no & """,
    ""Dt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """ 
  }, "

        '        24AAACJ5553C1ZZ Ahmadabad GUJ
        '"09AAACJ5553C1ZR  Noida , UP
        If first_party_number = "33AAACJ5553C1Z0" Then

            postData &= " ""SellerDtls"": {
    ""Gstin"": ""33AAACJ5553C1Z0"",
    ""LglNm"": ""JANATICS INDIA PRIVATE LIMITED"",
    ""TrdNm"": ""JANATICS INDIA PRIVATE LIMITED"",
    ""Addr1"": ""S.F.No. 252/1B1, BODIPALAYAM"",
    ""Addr2"": ""SEERAPALAYAM VILLAGE,MADHUKKARAI POST,"",
    ""Loc"": ""COIMBATORE"",
    ""Pin"": 641105,
    ""Stcd"": ""33"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "
        ElseIf first_party_number = "24AAACJ5553C1ZZ" Then
            postData &= " ""SellerDtls"": {
    ""Gstin"": ""24AAACJ5553C1ZZ"",
    ""LglNm"": ""JANATICS INDIA PVT. LTD - UNIT V"",
    ""TrdNm"": ""JANATICS INDIA PVT. LTD - UNIT V"",
    ""Addr1"": ""SHED NO.8, SHAYONA INDUSTRIAL ESTATE"",
    ""Addr2"": ""INSIDE PANCHRATNA ESTATE, VATVA GIDC,  PHASE-IV, RAMOL,TA.DASCROIT, AHMEDABAD"",
    ""Loc"": ""AHMEDABAD"",
    ""Pin"": 382445,
    ""Stcd"": ""24"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "

        ElseIf first_party_number = "09AAACJ5553C1ZR" Then
            postData &= " ""SellerDtls"": {
    ""Gstin"": ""09AAACJ5553C1ZR"",
    ""LglNm"": ""JANATICS INDIA PVT. LTD - UNIT VI"",
    ""TrdNm"": ""JANATICS INDIA PVT. LTD - UNIT VI"",
    ""Addr1"": ""A-38,SECTOR-65,"",
    ""Addr2"": ""GAUTAM BUDH NAGAR,"",
    ""Loc"": ""NOIDA"",
    ""Pin"": 201301,
    ""Stcd"": ""09"",
    ""Ph"": ""914222672800"",
    ""Em"": ""janatics@ho.vsnl.net.in""
  }, "

        End If
        postData &= " ""BuyerDtls"": {
    ""Gstin"": """ & buyer_gstin & """,
    ""LglNm"": """ & buyer_lglnm & """,
    ""TrdNm"": """ & buyer_trdnm & """,
    ""Pos"": """ & buyer_pos & """,
    ""Addr1"": """ & buyer_addres1 & """,
    ""Addr2"": """ & buyer_addres2 & """,
    ""Loc"": """ & buyer_loc & """,
    ""Pin"": " & buyer_pin.ToString.Replace(" ", "") & ",
    ""Stcd"":""" & buyer_stcd & """  
  },"

        postData &= "  ""ShipDtls"": {
          ""Gstin"": """ & buyer_gstin & """,
          ""LglNm"": """ & buyer_lglnm & """,
          ""TrdNm"": """ & buyer_trdnm & """,
          ""Addr1"": """ & buyer_addres1 & """,
          ""Addr2"": """ & buyer_addres1 & """,
          ""Loc"": """ & buyer_loc & """,
          ""Pin"": " & buyer_pin.ToString.Replace(" ", "") & ",
          ""Stcd"": """ & buyer_stcd & """
        },"

        postData &= " " & S & ""

        If exp_inv = "Y" Then
            postData &= """ExpDtls"": {
    ""ShipBNo"": """ & exp_shipbno & """,
    ""ShipBDt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """,
        ""ForCur"": """ & exp_forcur & """
  }, "
        End If
        '    ""Port"": ""INABG1"",
        '""RefClm"": ""N"",
        ',
        '""CntCode"": ""AE""
        postData &= """EwbDtls"": {
       ""Distance"": 0,
    ""TransDocNo"": """ & document_no & """,
    ""TransDocDt"": """ & Format(document_date, "dd-MM-yyyy").Replace("-", "/") & """,
    ""VehNo"": """ & VEHICLE_NO & """,
""TransMode"": ""1"" ,
        ""VehType"": ""R""
  }
}
"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        ' Set the ContentType property of the WebRequest.  
        request.ContentType = "application/json"
        ' Set the ContentLength property of the WebRequest.  
        request.ContentLength = byteArray.Length

        ' Get the request stream.  
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.  
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.  
        dataStream.Close()

        ' Get the response.  
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.  
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

        ' Get the stream containing content returned by the server.  
        ' The using block ensures the stream is automatically closed.
        Using dataStream1 As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.  
            Dim reader As New StreamReader(dataStream1)

            ' Read the content.  
            'Dim responseFromServer As String = reader.ReadToEnd()
            TextBox1.Text = reader.ReadToEnd()

        End Using

        ' Clean up the response.  
        response.Close()
        Txt_json.Text = postData
        Dim json As String = TextBox1.Text
        Dim read = Newtonsoft.Json.Linq.JObject.Parse(json)

        Try


            If read.Item("Success") = "Y" Then

                response_file_name = "D:\E_INVOICING\" & document_no & ".TXT"
                Dim FSTRM As New FileStream(response_file_name, FileMode.Create, FileAccess.Write)
                Dim SW As StreamWriter = New StreamWriter(FSTRM)

                SW = New StreamWriter(FSTRM)
                SW.Write(TextBox1.Text)
                FSTRM.Flush()
                SW.Flush()
                SW.Close()
                FSTRM.Close()

                eway_bill_no = ""
                Try
                    eway_bill_no = read.Item("EwbNo").ToString
                Catch ex As Exception

                End Try

                'Label1.Text = read.Item("EwbNo").ToString
                'Label2.Text = read.Item("statistics")("likeCount").ToString + " " + " times"
                sql = "insert into jan_einvoice_header "
                sql &= "(CUSTOMER_TRX_ID,TRX_NUMBER,TRX_DATE ,CREATION_DATE ,E_INV_DETAIL ,E_INV_STATUS,E_INV_ACKNO ,E_INV_IRN,E_INV_SIGNEDQRCODE,E_INV_EWBNO ,E_INV_ACKDT,supply_type) " ' ,E_INV_SIGNEDINVOICE,E_INVOICE_RESPONSE,RESPONSE_FILE_NAME
                sql &= " values((select CUSTOMER_TRX_ID from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')),trim('" & Tex_inv_no.Text & "'),(select TRX_DATE from ra_customer_trx_all where trx_number=trim('" & Tex_inv_no.Text & "')),sysdate,null "
                If read.Item("Success").ToString = "Y" Then sql &= ", 1 " Else sql &= ", 0 "
                sql &= " ,'" & read.Item("AckNo").ToString & "' "
                sql &= ",'" & read.Item("Irn").ToString & "'"
                'sql &= ",'" & read.Item("SignedInvoice").ToString & "'"
                sql &= ",'" & read.Item("SignedQRCode").ToString & "'"
                sql &= ",'" & eway_bill_no & "'"
                sql &= ",to_date('" & read.Item("AckDt").ToString & "','YYYY-MM-dd HH24:MI:SS') "
                'sql &= ",'" & read.Item("AckDt").ToString & "'"
                sql &= ",'" & SUPPLY_TYPE & "'"
                sql &= " )"
                comand()
                Dim cmd1 As New OracleClient.OracleCommand
                Dim blob() As Byte = System.IO.File.ReadAllBytes(response_file_name)

                sql = "UPDATE jan_einvoice_header SET e_invoice_response=:BlobParameter WHERE TRX_NUMBER=" & document_no & ""
                Dim blobParameter As OracleClient.OracleParameter = New OracleClient.OracleParameter()
                blobParameter.OracleType = OracleClient.OracleType.Blob
                blobParameter.ParameterName = "BlobParameter"
                blobParameter.Value = blob
                If orcon.State = ConnectionState.Closed Then orcon.Open()
                cmd1 = New OracleClient.OracleCommand(sql, orcon)
                cmd1.Parameters.Add(blobParameter)
                cmd1.ExecuteNonQuery()
                orcon.Close()
                'MessageBox.Show("E-INVOICE GENERATED")

                sql = "update jan_inv_print set  e_inv_status='S' where inv_no='" & Tex_inv_no.Text & "'"
                comand()
                postData = ""
                'E-Way bill Download
                request = WebRequest.Create("" & Eway_bill_api_endpoint & "")
                ' Set the Method property of the request to POST.  
                request.Method = "POST"
                request.Headers.Add("x-cleartax-auth-token", "" & authentication_token & "")
                request.Headers.Add("owner_id", "" & OWNER_ID & "")
                request.Headers.Add("gstin", "" & first_party_number & "")
                'request.Headers.Add("owner_id", "b451ea65-359f-4e33-b65d-b1cdfc54a7bc")
                ' Create POST data and convert it to a byte array.  
                postData = "{
  ""ewb_numbers"": [
    " & eway_bill_no & "
  ],
  ""print_type"": ""DETAILED""
}"

                'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                byteArray = Encoding.UTF8.GetBytes(postData)

                ' Set the ContentType property of the WebRequest.  
                request.ContentType = "application/json"
                ' Set the ContentLength property of the WebRequest.  
                request.ContentLength = byteArray.Length

                ' Get the request stream.  
                dataStream = request.GetRequestStream()
                ' Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length)
                ' Close the Stream object.  
                dataStream.Close()

                Dim response_file As String = ""
                ' Get the response.  
                response = request.GetResponse()


                If CType(response, HttpWebResponse).StatusCode = HttpStatusCode.OK Then
                    Dim lReader As IO.Stream = CType(response, HttpWebResponse).GetResponseStream()


                    X = "D:\EWayBills.zip"
                    Dim lWriter As New IO.FileStream(X, IO.FileMode.Create, FileAccess.Write)
                    Dim lLength As Long
                    Dim lBytes(256) As Byte

                    Do

                        lLength = lReader.Read(lBytes, 0, lBytes.Length)
                        lWriter.Write(lBytes, 0, lLength)

                    Loop While lLength > 0

                    lWriter.Close()
                    lReader.Close()

                End If
            Else
                sql = "INSERT INTO JAN_MAIL_SYSTEM (MAIL_NO,MAIL_DATE,MAIL_SUBJECT,MAIL_PROGRAM,MAIL_FROM,MAIL_TO,MAIL_BODY"

                sql &= ",mail_sent)VALUES(jan_TEST_SEQ.nextval ,sysdate,'Issue in E-Invoice Generation Process','E-Invoice Generation Process','it-dev7@janatics.co.in','it-dev7@janatics.co.in" ',sales09@janatics.co.in"
                sql &= " ,'" & document_no & "," & TextBox1.Text & "'"

                'Dim drmail As String = ret_val("SELECT ROWTOCOL('SELECT EMAIL FROM JAN_BMS_LOGIN WHERE UNAME LIKE (''DR%'') AND INSTR(DR_REGION,''' || F.REGION || ''')>0 AND EMAIL IS NOT NULL ') MAIL FROM JAN_PICK_FORWARD_HISTORY_TAB F WHERE FORWARD_NO=" & FWD_NO)


                sql &= " ,0) "

                comand()

            End If
        Catch ex As Exception
            sql = "INSERT INTO JAN_MAIL_SYSTEM (MAIL_NO,MAIL_DATE,MAIL_SUBJECT,MAIL_PROGRAM,MAIL_FROM,MAIL_TO,MAIL_BODY"

            sql &= ",mail_sent)VALUES(jan_TEST_SEQ.nextval ,sysdate,'Issue in E-Waybill Generation Process','E-Waybill Generation Process','it-dev7@janatics.co.in','it-dev7@janatics.co.in" ',sales09@janatics.co.in"
            sql &= " ,'" & document_no & "," & TextBox1.Text & "'"

            'Dim drmail As String = ret_val("SELECT ROWTOCOL('SELECT EMAIL FROM JAN_BMS_LOGIN WHERE UNAME LIKE (''DR%'') AND INSTR(DR_REGION,''' || F.REGION || ''')>0 AND EMAIL IS NOT NULL ') MAIL FROM JAN_PICK_FORWARD_HISTORY_TAB F WHERE FORWARD_NO=" & FWD_NO)


            sql &= " ,0) "

            comand()
        End Try
    End Sub
End Class




