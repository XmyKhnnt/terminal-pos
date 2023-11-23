Public Class frmChangeQty

    Private Sub frmChangeQty_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            chngQty = txtChangeQty.Text
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Dispose()

        End If
    End Sub

    Private Sub frmChangeQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
    End Sub

    Private Sub txtChangeQty_TextChanged(sender As Object, e As EventArgs) Handles txtChangeQty.TextChanged

    End Sub
End Class