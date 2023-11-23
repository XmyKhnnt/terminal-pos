<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashReceived
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textCash = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.save_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textCash
        '
        Me.textCash.Location = New System.Drawing.Point(154, 86)
        Me.textCash.Name = "textCash"
        Me.textCash.Size = New System.Drawing.Size(144, 22)
        Me.textCash.TabIndex = 4
        Me.textCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter Cash:"
        '
        'save_btn
        '
        Me.save_btn.Location = New System.Drawing.Point(154, 143)
        Me.save_btn.Name = "save_btn"
        Me.save_btn.Size = New System.Drawing.Size(144, 34)
        Me.save_btn.TabIndex = 5
        Me.save_btn.Text = "Save"
        Me.save_btn.UseVisualStyleBackColor = True
        '
        'frmCashReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 224)
        Me.Controls.Add(Me.save_btn)
        Me.Controls.Add(Me.textCash)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCashReceived"
        Me.Text = "cashReceived"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textCash As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents save_btn As Button
End Class
