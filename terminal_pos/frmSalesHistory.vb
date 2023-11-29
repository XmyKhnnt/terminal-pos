Public Class frmSalesHistory

    Dim currentDate As DateTime = DateTime.Now
    Dim TodayDate As String = currentDate.ToString("yyyy-MM-dd")
    Private Sub frmSalesHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        ElseIf e.KeyCode = Keys.F1 Then
            LoadSales(TodayDate)
        ElseIf e.KeyCode = Keys.F2 Then
            LoadAllSales()
        End If
    End Sub


    Private Sub frmSalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        KeyPreview = True

        LoadSales(TodayDate)
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged

        Dim selectedDate As String = MonthCalendar1.SelectionStart.ToString("yyyy-MM-dd")
        LoadSales(selectedDate)

    End Sub

    Private Sub LoadSales(ByVal date_arg As String)

        dbconn()


        sql = "SELECT sale_details.itemid, sale_details.qty, sale_details.price, items.item_name, sales.date_at, sales.void,sale_details.sd_id, users.complete_name FROM sales INNER JOIN users ON sales.userid = users.uid INNER JOIN sale_details ON sales.saleid = sale_details.saleid INNER JOIN items ON sale_details.itemid = items.itemid WHERE DATE(date_at) = '" & date_arg & "'  ORDER BY date_at;"


        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        salesHistoryListView.Items.Clear()

        While dr.Read
            newline = salesHistoryListView.Items.Add(dr("sd_id"))
            newline.SubItems.Add(dr("itemid"))
            newline.SubItems.Add(dr("item_name"))
            newline.SubItems.Add(dr("qty"))
            newline.SubItems.Add(dr("price"))
            newline.SubItems.Add(dr("date_at"))
            newline.SubItems.Add(dr("complete_name"))
        End While

        cn.Close()
        cmd.Dispose()
    End Sub


    Private Sub salesHistoryListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles salesHistoryListView.SelectedIndexChanged

    End Sub


    Private Sub LoadAllSales()

        dbconn()


        sql = "SELECT sale_details.itemid, sale_details.qty, sale_details.price, items.item_name, sales.date_at, sales.void,sale_details.sd_id, users.complete_name FROM sales INNER JOIN users ON sales.userid = users.uid INNER JOIN sale_details ON sales.saleid = sale_details.saleid INNER JOIN items ON sale_details.itemid = items.itemid   ORDER BY date_at;"


        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        salesHistoryListView.Items.Clear()

        While dr.Read
            newline = salesHistoryListView.Items.Add(dr("sd_id"))
            newline.SubItems.Add(dr("itemid"))
            newline.SubItems.Add(dr("item_name"))
            newline.SubItems.Add(dr("qty"))
            newline.SubItems.Add(dr("price"))
            newline.SubItems.Add(dr("date_at"))
            newline.SubItems.Add(dr("complete_name"))
        End While

        cn.Close()
        cmd.Dispose()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label4.Click

    End Sub
End Class