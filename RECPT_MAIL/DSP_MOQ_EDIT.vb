Imports System.Data.OracleClient
Public Class DSP_MOQ_EDIT
    Dim z As Integer
    Dim add_edit As String
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        sql = "select  jan_orgcode(" & ddl_org.SelectedValue & ") ""Org"",'" & txt_item_no.Text & "' ""Item No"",jan_itemdesc('" & txt_item_no.Text & "')""Description"" ,jan_dsp_moq(jan_itemno('" & txt_item_no.Text & "')," & ddl_org.SelectedValue & ",'Pareto')""MOQ Qty"" from dual"

        sql = "SELECT jan_orgcode(ORG_ID) ""Org"",JAN_ITEMNAME(ITEM_ID) ""Item No"",jan_itemdesc(JAN_ITEMNAME(ITEM_ID))""Description"" , MOQ_QTY ""MOQ Qty"" FROM JAN_DSP_ITEM_MOQ WHERE ITEM_ID=JAN_ITEMNO('" & txt_item_no.Text & "') AND ORG_ID=" & ddl_org.SelectedValue & ""
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")

        With dgv
            .DataSource = ds.Tables("data")
            .Columns(2).Width = 350
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With
    End Sub
    Private Sub DSP_MOQ_EDIT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        add_edit = ""
        sql = " select ORGANIZATION_id,ORGANIZATION_CODE from ORG_ORGANIZATION_DEFINITIONS where ORGANIZATION_CODE not in ('COM','I09','S51','S52')  order by ORGANIZATION_CODE "
        adap = New OracleDataAdapter(sql, con)
        ds = New DataSet
        adap.Fill(ds, "data")
        ddl_org.DisplayMember = "ORGANIZATION_CODE"
        ddl_org.ValueMember = "ORGANIZATION_id"
        ddl_org.DataSource = ds.Tables("data")
        Me.Size = New System.Drawing.Size(816, 398)


    End Sub
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Me.Size = New System.Drawing.Size(816, 491)
        btn_update.Text = "Update"
        txt_add_new.Text = dgv.CurrentRow.Cells(1).Value
        txt_org_update.Text = dgv.CurrentRow.Cells(0).Value
        add_edit = "EDIT"
    End Sub
    Private Sub btn_add_new_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_new_item.Click
        Me.Size = New System.Drawing.Size(816, 491)
        btn_update.Text = "Add"
        add_edit = "ADD"
        'sql = "insert into JAN_dsp_item_moq (item_id,org_id,moq_qty) values(JAN_ITEMNO('" & txt_add_new.Text & "'),JAN_ORGID('" & txt_org_update.Text & "')," & txt_moq.Text & ")"
        'comand()
        ''If z = 0 Then
        ''    MessageBox.Show("MOQ NOt Updated", "DSP MOQ updation", MessageBoxButtons.OK)
        ''Else
        'MessageBox.Show("MOQ Updated", "DSP MOQ Added", MessageBoxButtons.OK)
        ''End If
        'clear_text()
        update_moq()

    End Sub
    Private Sub update_moq()

        If add_edit = "ADD" Then

            sql = "insert into JAN_dsp_item_moq (item_id,org_id,moq_qty) values(JAN_ITEMNO('" & txt_add_new.Text & "'),JAN_ORGID('" & txt_org_update.Text & "')," & txt_moq.Text & ")"
            comand()
            If txt_add_new.Text <> "" Then
                MessageBox.Show("MOQ Updated", "DSP MOQ Added", MessageBoxButtons.OK)
                Me.Size = New System.Drawing.Size(816, 398)
            End If


        ElseIf add_edit = "EDIT" Then

            sql = "update JAN_dsp_item_moq set moq_qty=" & txt_moq.Text & " where  item_id =jan_itemno('" & txt_add_new.Text & "') and org_id=jan_orgid('" & txt_org_update.Text & "')"
            comand()

            MessageBox.Show("MOQ Updated", "DSP MOQ updation", MessageBoxButtons.OK)

        End If

        clear_text()
    End Sub
    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        'sql = "update JAN_dsp_item_moq set moq_qty=" & txt_moq.Text & " where  item_id =jan_itemno('" & txt_add_new.Text & "') and org_id=jan_orgid('" & txt_org_update.Text & "')"
        'comand()
        ''If z = 0 Then
        ''    MessageBox.Show("MOQ NOt Updated", "DSP MOQ updation", MessageBoxButtons.OK)
        ''Else
        'MessageBox.Show("MOQ Updated", "DSP MOQ updation", MessageBoxButtons.OK)
        ''End If
        'clear_text()
        update_moq()
        Me.Size = New System.Drawing.Size(816, 398)
    End Sub
    Private Sub clear_text()
        txt_moq.Text = ""
        txt_add_new.Text = ""
        txt_org_update.Text = ""
    End Sub
End Class