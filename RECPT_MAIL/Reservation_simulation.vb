Public Class Reservation_simulation
    Private Sub btn_view_simulation_Click(sender As Object, e As EventArgs) Handles btn_view_simulation.Click
        sql = "  "
        sql = "DECLARE BEGIN Jan_Region_Flush_Simulation('" & Format(ofd_dt.Value, "dd-MMM-yyyy") & "','" & Format(Payment_date_from.Value, "dd-MMM-yyyy") & "'); END;"
        comand_new()


        sql = " SELECT SOLD_TO_ORG_ID,REGION,CUSTOMER_CATEGORY,(SELECT CUSTOMER_NAME FROM RA_CUSTOMERS WHERE CUSTOMER_ID=A.SOLD_TO_ORG_ID) CUSTOMER_NAME,ROUND(SUM(QUOTA_ALLOCATE_QTY*UNIT_SELLING_PRICE)/100000,2) SIMULATED_VALUE FROM jan_it.JAN_SALES_PLAN_TV_T_RSV_TEST A GROUP BY REGION,SOLD_TO_ORG_ID,CUSTOMER_CATEGORY "
        ds = SQL_SELECT("data", sql)
        dgv1.DataSource = ds.Tables("data")

    End Sub


End Class