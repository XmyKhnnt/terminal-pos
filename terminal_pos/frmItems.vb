Imports MySql.Data.MySqlClient
Public Class frmItems

    Private Sub frmItems_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()

        End If
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True

        dbconn()
        sql = "SELECT  * FROM items"

        cmd = New MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        ItemCount = 0

        While dr.Read
            newline = ListView1.Items.Add(dr("itemid"))
            newline.SubItems.Add(dr("sku"))
            newline.SubItems.Add(dr("item_name"))
            newline.SubItems.Add(dr("price"))
            newline.SubItems.Add(dr("qty"))

            ItemCount += 1
        End While

        Label2.Text = "Found: " & ItemCount

        cmd.Dispose()
        cn.Close()

        ListviewAlternateColor()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItem.TextChanged
        dbconn()

        ItemCount = 0
        sql = "SELECT * FROM items WHERE item_name LIKE '%" & txtSearchItem.Text & "%' ORDER BY item_name ASC"

        cmd = New MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView1.Items.Clear()

        While dr.Read
            newline = ListView1.Items.Add(dr("itemid"))
            newline.SubItems.Add(dr("sku"))
            newline.SubItems.Add(dr("item_name"))
            newline.SubItems.Add(dr("price"))
            newline.SubItems.Add(dr("qty"))

            ItemCount += 1
        End While

        Label2.Text = "Found: " & ItemCount

        cmd.Dispose()
        cn.Close()

        ListviewAlternateColor()

    End Sub

    Sub ListviewAlternateColor()
        For i As Integer = 0 To ListView1.Items.Count - 1 Step 1
            If i Mod 2 = 0 Then
                ListView1.Items(i).BackColor = Color.White
            Else
                ListView1.Items(i).BackColor = Color.Cornsilk  'light grey
            End If
        Next i
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then

            newline = frmMainForm.ListView1.Items.Add(ListView1.SelectedItems.Item(0).Text)
            newline.SubItems.Add(ListView1.SelectedItems(0).SubItems(2).Text)
            newline.SubItems.Add(ListView1.SelectedItems(0).SubItems(3).Text)
            newline.SubItems.Add(chngQty)

            Dim sTotal As Double
            Dim price As Double

            price = ListView1.SelectedItems(0).SubItems(3).Text
            sTotal = price * chngQty

            newline.SubItems.Add(FormatNumber((sTotal), 2))

            chngQty = 1

            TotalAmount += price
            frmMainForm.totol_rendered.Text = TotalAmount


            Me.Dispose()

            ListviewAlternateColor()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class