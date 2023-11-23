Imports MySql.Data.MySqlClient

Public Class frmCashReceived

    Private Sub frmCashReceived_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            post_sales()

        End If

    End Sub





    Private Sub frmCashReceived_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True



    End Sub

    Private Sub txtChangeQty_TextChanged(sender As Object, e As EventArgs) Handles textCash.TextChanged

    End Sub

    Private Sub save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click

        post_sales()

    End Sub



    Sub saveTransaction()
        dbconn()
        ' generate the sale id

        sql = "INSERT INTO sales (userid,cust_id, amount) VALUES (" & uid & ", " & customerID & ", " & TotalAmount & ")"

        cmd = New MySqlCommand(sql, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()


        'get the generated saleid from sales table
        sql = "SELECT * FROM sales ORDER BY saleid DESC limit 1"
        cmd = New MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader()

        While dr.Read()
            saleId = dr("saleid")
        End While

        dr.Close()
        cmd.Dispose()


        'get the item values and save it to the sales details table
        Dim cItems As Integer

        For cItems = 0 To frmMainForm.ListView1.Items.Count - 1
            sql = "INSERT INTO sale_details (saleid, itemid, price, qty) VALUES (" & saleId & "," & frmMainForm.ListView1.Items(cItems).Text & "," & frmMainForm.ListView1.Items(cItems).SubItems(2).Text & "," & frmMainForm.ListView1.Items(cItems).SubItems(3).Text & ")"

            cmd = New MySqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Next


        For cItems = 0 To frmMainForm.ListView1.Items.Count - 1

            sql = "UPDATE items SET qty = qty - " & frmMainForm.ListView1.Items(cItems).SubItems(3).Text & " WHERE itemid = " & frmMainForm.ListView1.Items(cItems).Text
            cmd = New MySqlCommand(sql, cn)
            cmd.ExecuteNonQuery()

        Next


        cmd.Dispose()
        cn.Close()

        MsgBox("Transaction Posted!", MsgBoxStyle.Information, "Posted")

    End Sub

    Private Sub post_sales()
        If posted_status Then

            MsgBox("Transaction Already Posted")
            Me.Dispose()


        Else

            If Convert.ToDecimal(textCash.Text) < TotalAmount Then
                MsgBox("Error: Amount received is less than the total rendered!", vbInformation)
            Else
                frmMainForm.cash_received.Text = textCash.Text
                frmMainForm.overall_total.Text = Convert.ToDecimal(frmMainForm.cash_received.Text) - TotalAmount

                saveTransaction()
                frmMainForm.ChangePostedStatus()
                frmMainForm.UpdateSatus()

                Me.Dispose()
            End If
        End If
    End Sub
End Class
