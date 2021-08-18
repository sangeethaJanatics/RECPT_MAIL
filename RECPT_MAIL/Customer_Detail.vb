

Imports System.IO

Public Class Customer_Detail
    Private Sub Customer_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds = New DataSet

        sql = "select distinct SEGMENT14 from ra_territories where SEGMENT14 not in ('GOA','M.P.','PROJECTS 1','NOT LISTED') order by SEGMENT14"
        'adap = New OracleDataAdapter(sql, con)
        'adap.Fill(ds, "result")
        ds = SQL_SELECT("result", sql)
        reg_combo.Items.Add("ALL")
        For i = 0 To ds.Tables("result").Rows.Count - 1
            reg_combo.Items.Add(ds.Tables("result").Rows(i).Item("segment14"))
        Next
        reg_combo.Text = "ALL"
    End Sub

    Private Sub btn_show_Click(sender As Object, e As EventArgs) Handles btn_show.Click
        ds = New DataSet
        If Rad_oracle_customer.Checked = True Then


            sql = "SELECT rac.customer_name,TRUNC(rac.creation_date)creation_date,rac.customer_class_code,(SELECT STANDARD_TERMS_NAME FROM AR_CUSTOMER_PROFILES_V WHERE CUSTOMER_ID=rac.CUSTOMER_ID AND SITE_USE_ID IS NULL)pay_term,rac.attribute9 person_name_desg,rac.attribute10  customer_support_engineer ,rac.attribute11 ind_segment,rac.attribute12 customer_potential,NVL(A.ADDRESS1,'-') ADDRESS1,NVL(A.ADDRESS2,'-') ADDRESS2,NVL(A.ADDRESS3,'-') ADDRESS3,NVL(A.ADDRESS4,'-') ADDRESS4,NVL(A.CITY,'-') CITY,NVL(A.POSTAL_CODE,'-') POSTAL_CODE,NVL(A.STATE,'-') STATE,c.segment14 region,B.LOCATION,B.FREIGHT_TERM,a.attribute12 sales_tax"

        sql &= ",rowtocol('SELECT  COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Telephone'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='||rac.customer_id||')')phone"

        sql &= ",rowtocol('SELECT  COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Fax'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='||rac.customer_id||')')fax"

        sql &= ",rowtocol('SELECT  distinct email_address  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''E-mail'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='||rac.customer_id||')')e_mail"

        sql &= ",ROWTOCOL('SELECT CONT_FIRST_NAME || '' '' || CONT_LAST_NAME  FROM AR_CUSTOMER_CONTACT_FIND_V WHERE CUSTOMER_ID=''' || rac.CUSTOMER_ID || '''')contact_person, "

        sql &= "(SELECT sum(quantity_invoiced*unit_selling_price)  FROM jan_sales_any_1_copy WHERE BILL_TO_CUSTOMER_ID=rac.CUSTOMER_ID)sale_value"

        sql &= " FROM ra_addresses_all a,ra_site_uses_all b, ra_territories c, ra_customers rac WHERE trunc(rac.creation_date)>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and trunc(rac.creation_date)<='" & Format(DateTimePicker2.Value, "dd-MMM-yyyy") & "' AND a.address_id = b.address_id AND b.bill_to_site_use_id IS NOT NULL AND c.territory_id = b.territory_id AND rac.party_id = a.party_id "
        If reg_combo.Text <> "ALL" Then sql &= " and c.segment14='" & reg_combo.Text & "' "
            sql &= " ORDER BY TRUNC(rac.creation_date)"
        Else
            sql = " SELECT B.*
,(SELECT STANDARD_TERMS_NAME FROM AR_CUSTOMER_PROFILES_V WHERE CUSTOMER_ID=B.CUSTOMER_ID AND SITE_USE_ID IS NULL)pay_term
,rowtocol('SELECT NVL(ADDRESS1,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')ADDRESS1 
,rowtocol('SELECT NVL(ADDRESS2,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')ADDRESS2
,rowtocol('SELECT NVL(ADDRESS3,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')ADDRESS3
,rowtocol('SELECT NVL(ADDRESS4,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')ADDRESS4
,rowtocol('SELECT NVL(POSTAL_CODE,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')POSTAL_CODE 
,rowtocol('SELECT NVL(STATE,''-'') FROM JAN_BMS_BILL_TO_V WHERE CUSTOMER_ID='||B.CUSTOMER_ID||'')STATE 
FROM ("

            sql &= " select A.bill_to_cust_name,RAC.CUSTOMER_ID,RAC.CREATION_DATE,RAC.CUSTOMER_CLASS_CODE,rac.attribute9 person_name_desg,rac.attribute10  customer_support_engineer 
,rac.attribute11 ind_segment,rac.attribute12 customer_potential,A.region
,rowtocol('SELECT  COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Telephone'' 
AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='||rac.customer_id||')')phone,rowtocol('SELECT  
COUNTRY_CODE||''-''||AREA_CODE||''-''||PHONE_NUMBER  FROM AR_PHONES_V WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''Fax'' AND STATUS=''A''
AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers WHERE customer_id='||rac.customer_id||')')fax,rowtocol('SELECT  distinct email_address  FROM AR_PHONES_V 
WHERE owner_table_name=''HZ_PARTIES''  AND PHONE_TYPE_MEANING=''E-mail'' AND STATUS=''A'' AND OWNER_TABLE_ID=(SELECT party_id FROM ra_customers 
WHERE customer_id='||rac.customer_id||')')e_mail,ROWTOCOL('SELECT CONT_FIRST_NAME || '' '' || CONT_LAST_NAME  FROM AR_CUSTOMER_CONTACT_FIND_V WHERE CUSTOMER_ID=''' || 
rac.CUSTOMER_ID || '''')contact_person "

            sql &= " ,sum(A.quantity_invoiced*A.unit_selling_price)sale_in_this_period
from jan_sales_any_1_copy  A ,RA_CUSTOMERS RAC where RAC.CUSTOMER_ID=A.BILL_TO_CUSTOMER_ID 
AND  A.trx_date>='" & Format(DateTimePicker1.Value, "dd-MMM-yyyy") & "' and  A.trx_date<'" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "dd-MMM-yyyy") & "'"
            If reg_combo.Text <> "ALL" Then sql &= " and a.region='" & reg_combo.Text & "' "
            sql &= " group  by A.bill_to_cust_name,A.region,RAC.CREATION_DATE,RAC.CUSTOMER_CLASS_CODE,rac.attribute9 ,rac.attribute10  
,rac.attribute11 ,rac.attribute12,rac.customer_id )B"
        End If
        'adap = New OracleDataAdapter(sql, con)
        'adap.Fill(ds, "result")
        ds = SQL_SELECT("result", sql)

        S = ""
        S &= "<html>"
        S &= "<head><style type=text/css>.tab {color:black;font-family:verdana;font-size:8pt}</style><style type=text/css>.tab1 {color:black;font-family:verdana;font-size:7pt}</style></head>"
        S &= "<h4>Customer Details</h4>"

        S &= "<table border=1 cellpading=0 cellspacing=0 class=tab>"

        S &= "<tr><th>Sl.No</th>"
        For i = 0 To ds.Tables("result").Columns.Count - 1
            With ds.Tables("result").Columns(i)
                S &= "<th>" & .ColumnName & "</th>"
            End With
        Next
        S &= "</tr>"


        For i = 0 To ds.Tables("result").Rows.Count - 1

            S &= "<tr><td>" & i + 1 & "</td>"
            For j = 0 To ds.Tables("result").Columns.Count - 1
                With ds.Tables("result").Rows(i)

                    S &= "<td>" & .Item(j) & "</td>"
                End With
            Next
            S &= "</tr>"

        Next

        X = "D:\Customer_details.html"
        Dim FSTRM As New FileStream(X, FileMode.Create, FileAccess.Write)
        Dim SW As StreamWriter = New StreamWriter(FSTRM)

        SW = New StreamWriter(FSTRM)
        SW.Write(S)
        FSTRM.Flush()
        SW.Flush()
        SW.Close()
        FSTRM.Close()
        System.Diagnostics.Process.Start(X)
    End Sub
End Class