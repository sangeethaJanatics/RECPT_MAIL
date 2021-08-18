Public Class Application_data

    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        dgv1.Columns.Clear()

        If rad_2002.Checked = True Then
            sql = "SELECT * FROM JAN_COST_CENTER_VIEW WHERE COST_CENTER_ID=2002 AND     ADATE>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  AND     ADATE<'" & Format(DateAdd(DateInterval.Day, 1, to_date.Value), "dd-MMM-yyyy") & "'"
        ElseIf rad_5400.Checked = True Then

            sql = "SELECT * FROM JAN_COST_CENTER_VIEW WHERE COST_CENTER_ID=5400 AND     ADATE>='" & Format(From_date.Value, "dd-MMM-yyyy") & "'  AND     ADATE<'" & Format(DateAdd(DateInterval.Day, 1, to_date.Value), "dd-MMM-yyyy") & "'"


            'sql = "SELECT * FROM JAN_COST_CENTER_VIEW WHERE COST_CENTER_ID=5400 AND     ADATE>='1-APR-2015'"
        End If


        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub
End Class