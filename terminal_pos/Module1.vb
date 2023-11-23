Imports MySql.Data.MySqlClient
Module Module1
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public cn As New MySqlConnection

    Public sql As String
    Public itemId As Integer
    Public newline As ListViewItem
    Public fItem As String
    Public i As Integer
    Public ItemCount As Integer

    Public chngQty As Integer
    Public customerID As Integer = 1
    Public TotalAmount As Integer = 0
    Public total_amount_reveived As Integer = 0

    Public posted_status As Boolean = False

    Public saleId As Integer
    Public uid As Integer = 1

    Public Sub dbconn()
        cn.ConnectionString = "server=localhost;username=root;password=root;database=terminal_pos;port=3306;"
        cn.Open()
    End Sub




End Module
