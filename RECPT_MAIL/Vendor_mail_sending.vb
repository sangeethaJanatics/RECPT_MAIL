Imports System.Data.OracleClient
Public Class Vendor_mail_sending


    Private Sub btn_preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_preview.Click
        vendor_mail_preview.ShowDialog()
        vendor_mail_preview.wb1.DocumentText = RichTextBox1.Text



    End Sub
    Private Sub show_vendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show_vendor.Click

        chk_list_vendor.Items.Clear()
        Dim mnth As String
        ds = New DataSet

        If yr_cmb.Text <> "" Then mnth = String.Concat(yr_cmb.Text.ToString.Substring(0, 3), "_sup_req_qty")


        sql = " select * from (select a.*,(select c.email_address from  PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c where b.vendor_id=a.vendor_id and b.vendor_site_id=c.vendor_site_id  and c.email_address is not null and rownum=1)e_mail from (select distinct vendor_name,vendor_id from jan_corp_plan_04_2012_all_tab  k where "

        If rad_po.Checked = True Then sql &= "   plan_for='PO'" Else sql &= "   plan_for='JOB'"
        If yr_cmb.Text <> "" Then sql &= " and  " & mnth & ">0 "

        If chk_import_vendors.Checked = False Then
            sql &= " AND NVL((SELECT DD.SEGMENT1 FROM MTL_ITEM_CATEGORIES AA, MTL_CATEGORY_SETS_VL BB, MTL_CATEGORIES_B_KFV DD   WHERE BB.CATEGORY_SET_ID = AA.CATEGORY_SET_ID AND k.INVentory_ITEM_ID=AA.INVENTORY_ITEM_ID AND k.ORGanization_ID=AA.ORGANIZATION_ID AND DD.CATEGORY_ID=AA.CATEGORY_ID AND AA.CATEGORY_SET_ID=1100000162),'-')<>'Import'"
        End If

        sql &= " )a ) where e_mail is not null  "

        adap = New OracleDataAdapter(sql, con)
        adap.Fill(ds, "vendors")
        Dim dt As New DataTable
        dt = ds.Tables("vendors")

        For i = 0 To ds.Tables("vendors").Rows.Count - 1
            With ds.Tables("vendors").Rows(i)
                chk_list_vendor.Items.Add("" & .Item("vendor_name") & "")
            End With
        Next


    End Sub
    Public Shared Function FromRtf(ByVal rtf As RichTextBox) As String
        Dim b, i, u As Boolean
        b = False : i = False : u = False
        Dim curchar As String
        Dim fontfamily As String = "Arial"
        Dim fontsize As Integer = 12
        Dim htmlstr As String = String.Format("<html>{0}<body>{0}<div style=""text-align: left;""><span style=""font-family: Arial; font-size: 12pt;"">", vbCrLf)
        Dim x As Integer = 0
        While x < rtf.Text.Length
            rtf.Select(x, 1)
            If rtf.SelectionFont.Bold AndAlso (Not b) Then
                htmlstr &= "<b>"
                b = True
                'rtf.AppendText("<b>")
                'x += 2
            ElseIf (Not rtf.SelectionFont.Bold) AndAlso b Then
                htmlstr &= "</b>"
                b = False
            End If
            If rtf.SelectionFont.Italic AndAlso (Not i) Then
                htmlstr &= "<i>"
                i = True
            ElseIf (Not rtf.SelectionFont.Italic) AndAlso i Then
                htmlstr &= "</i>"
                i = False
            End If
            If rtf.SelectionFont.Underline AndAlso (Not u) Then
                htmlstr &= "<u>"
                u = True
            ElseIf (Not rtf.SelectionFont.Underline) AndAlso u Then
                htmlstr &= "</u>"
                u = False
            End If
            If fontfamily <> rtf.SelectionFont.FontFamily.Name Then
                htmlstr &= String.Format("</span><span style=""font-family: {0}; font-size: {0}pt;"">", rtf.SelectionFont.FontFamily.Name, fontsize)
                fontfamily = rtf.SelectionFont.FontFamily.Name
            End If
            If fontsize <> rtf.SelectionFont.SizeInPoints Then
                htmlstr &= String.Format("</span><span style=""font-family: {0}; font-size: {0}pt;"">", fontfamily, rtf.SelectionFont.SizeInPoints)
                fontsize = rtf.SelectionFont.SizeInPoints
            End If

            curchar = rtf.SelectedText
            Select Case curchar
                Case vbCr, vbLf
                    curchar = "<br />"
                    x += 5
                Case "&" : curchar = "&amp;" : x += "&amp;".Length - 1
                Case "<" : curchar = "&lt;" : x += "&lt;".Length - 1
                Case ">" : curchar = "&gt;" : x += "&gt;".Length - 1
                Case " " : curchar = "&nbsp;" : x += "&nbsp;".Length - 1
                    'Case " " : curchar = " " : x += 1

            End Select
            rtf.SelectedText = curchar
            x += 1
            htmlstr &= curchar
        End While
        S = htmlstr
        Return htmlstr & String.Format("</span>{0}</body>{0}</html>", vbCrLf)
    End Function

    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click

        Dim original_text As String = RichTextBox1.Text
        Dim s1 As String = FromRtf(RichTextBox1)
        s1 = original_text

        's1 = RichTextBox1.Text
        S = s1
        RichTextBox1.Text = original_text

        If txt_mail_subject.Text = "" Then
            MessageBox.Show("Add Mail Subject and send Mails", "Vendor Mail Sending", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GoTo last
        End If

        If RichTextBox1.Text = "" Then
            MessageBox.Show("Add Forwarding Message and send Mails", "Vendor Mail Sending", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GoTo last
        End If

        Dim mail_body_col As Double = S.Length / 3994

        Dim mail_body_col_cnt As Integer = Math.Ceiling(mail_body_col)

        For i = 0 To chk_list_vendor.CheckedItems.Count - 1

            sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_cc,mail_subject,mail_body,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in',(select c.email_address from  po_vendors a ,PO_VENDOR_SITES_ALL b,PO_VENDOR_CONTACTS c where  b.vendor_id = a.vendor_id And b.vendor_site_id = c.vendor_site_id And c.email_address Is Not null And rownum = 1 and a.vendor_name='" & chk_list_vendor.CheckedItems(i).ToString.Replace("'", "''") & "'),'websupport@janatics.co.in','" & txt_mail_subject.Text & "','" & S.Replace("'", "''") & "',0)"

            'sql = "INSERT INTO jan_mail_system(mail_no,mail_date,MAIL_PROGRAM,mail_from ,mail_to,mail_subject,mail_body"

            'If mail_body_col_cnt > 1 Then
            '    For k = 2 To mail_body_col_cnt
            '        sql &= " ,mail_subject_" & k & ""
            '    Next
            'End If

            'sql &= " ,mail_sent) VALUES(jan_test_seq.NEXTVAL,SYSDATE,'OSP Vendor Mails','feedback@janatics.co.in','it-dev7@janatics.co.in','" & txt_mail_subject.Text & "',"

            'If mail_body_col_cnt > 1 Then
            '    sql &= "  '" & S.Substring(0, 3993) & "',"
            '    For k = 2 To mail_body_col_cnt
            '        If k = 2 And mail_body_col_cnt = 2 Then
            '            sql &= "  '" & S.Substring(3993) & "',"
            '        Else
            '            sql &= "  '" & S.Substring(3993, 3993) & "',"
            '        End If

            '        If k = 3 And mail_body_col_cnt = 3 Then sql &= "  '" & S.Substring(7986) & "',"
            '    Next
            'Else
            '    sql &= "  '" & S.ToString.Replace("'", "''") & "',"
            'End If


            'sql &= " 0)"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd = New OracleCommand(sql, con)
            cmd.ExecuteNonQuery()
        Next

        MessageBox.Show("Mail sent", "Vendor Mail Sending", MessageBoxButtons.OK, MessageBoxIcon.Information)
last:
    End Sub
    Private Sub Vendor_mail_sending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Clear()

        yr_cmb.Items.Add("APR-2012")
        yr_cmb.Items.Add("MAY-2012")
        yr_cmb.Items.Add("JUN-2012")
        yr_cmb.Text = "APR-2012"

    End Sub
    Private Sub chk_all_select_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_all_select.CheckedChanged

        If chk_all_select.Checked = True Then
            For i = 0 To chk_list_vendor.Items.Count - 1
                chk_list_vendor.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chk_list_vendor.Items.Count - 1
                chk_list_vendor.SetItemChecked(i, False)
            Next
        End If
    End Sub
End Class