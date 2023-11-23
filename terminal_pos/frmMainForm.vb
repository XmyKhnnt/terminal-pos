Public Class frmMainForm

    Private Sub frmMainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            frmItems.ShowDialog()
        ElseIf e.KeyCode = Keys.F8 Then
            frmChangeQty.ShowDialog()

        ElseIf e.KeyCode = Keys.F10 Then
            frmCashReceived.ShowDialog()

        ElseIf e.KeyCode = Keys.F2 Then
            ResetTransactrionForm()
        End If

    End Sub


    Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Label1.Text = "[F2]-New Transaction | [F4]-Search Item | [F8]-Change Qty [F10]- Add Payment  "
        chngQty = 1


        UpdateSatus()


    End Sub

    Private Sub overall_total_Click(sender As Object, e As EventArgs) Handles overall_total.Click, Label4.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub status_field_Click(sender As Object, e As EventArgs) Handles status_field.Click

    End Sub

    Public Sub ChangePostedStatus()

        If posted_status Then
            posted_status = False
        Else
            posted_status = True
        End If

    End Sub

    Public Sub UpdateSatus()

        If posted_status = False Then
            status_field.Text = "Not Posted"
            status_field.ForeColor = Color.OrangeRed
        Else
            status_field.Text = "Posted"
            status_field.ForeColor = Color.DarkGreen
        End If

    End Sub

    Public Sub ResetGlobalValues()
        chngQty = 0
        TotalAmount = 0
        total_amount_reveived = 0
    End Sub

    Public Sub ResetLitView()

        ListView1.Items.Clear()

    End Sub

    Public Sub ResetTransactrionForm()
        ResetGlobalValues()
        ResetLitView()


        If posted_status = True Then
            ChangePostedStatus()
        End If

        UpdateSatus()
        EmptyLabelValue()

    End Sub

    Public Sub EmptyLabelValue()
        cash_received.Text = ""
        overall_total.Text = ""
        totol_rendered.Text = ""

    End Sub

End Class
