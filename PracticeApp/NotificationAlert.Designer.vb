<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationAlert
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
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdSnooze = New System.Windows.Forms.Button
        Me.lblAlertMessage = New System.Windows.Forms.Label
        Me.cmdSnoozeOneDay = New System.Windows.Forms.Button
        Me.cmdPrintPaymentCoupons = New System.Windows.Forms.Button
        Me.cmdCreateInvoice = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(12, 121)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 0
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdSnooze
        '
        Me.cmdSnooze.Location = New System.Drawing.Point(320, 121)
        Me.cmdSnooze.Name = "cmdSnooze"
        Me.cmdSnooze.Size = New System.Drawing.Size(71, 40)
        Me.cmdSnooze.TabIndex = 1
        Me.cmdSnooze.Text = "Snooze (30 minutes)"
        Me.cmdSnooze.UseVisualStyleBackColor = True
        '
        'lblAlertMessage
        '
        Me.lblAlertMessage.Location = New System.Drawing.Point(12, 21)
        Me.lblAlertMessage.Name = "lblAlertMessage"
        Me.lblAlertMessage.Size = New System.Drawing.Size(379, 73)
        Me.lblAlertMessage.TabIndex = 2
        '
        'cmdSnoozeOneDay
        '
        Me.cmdSnoozeOneDay.Location = New System.Drawing.Point(243, 121)
        Me.cmdSnoozeOneDay.Name = "cmdSnoozeOneDay"
        Me.cmdSnoozeOneDay.Size = New System.Drawing.Size(71, 40)
        Me.cmdSnoozeOneDay.TabIndex = 3
        Me.cmdSnoozeOneDay.Text = "Snooze (1 Day)"
        Me.cmdSnoozeOneDay.UseVisualStyleBackColor = True
        '
        'cmdPrintPaymentCoupons
        '
        Me.cmdPrintPaymentCoupons.Location = New System.Drawing.Point(166, 121)
        Me.cmdPrintPaymentCoupons.Name = "cmdPrintPaymentCoupons"
        Me.cmdPrintPaymentCoupons.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPaymentCoupons.TabIndex = 4
        Me.cmdPrintPaymentCoupons.Text = "Print All Coupons"
        Me.cmdPrintPaymentCoupons.UseVisualStyleBackColor = True
        Me.cmdPrintPaymentCoupons.Visible = False
        '
        'cmdCreateInvoice
        '
        Me.cmdCreateInvoice.Location = New System.Drawing.Point(89, 121)
        Me.cmdCreateInvoice.Name = "cmdCreateInvoice"
        Me.cmdCreateInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateInvoice.TabIndex = 5
        Me.cmdCreateInvoice.Text = "Create All Invoices"
        Me.cmdCreateInvoice.UseVisualStyleBackColor = True
        Me.cmdCreateInvoice.Visible = False
        '
        'NotificationAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 166)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCreateInvoice)
        Me.Controls.Add(Me.cmdPrintPaymentCoupons)
        Me.Controls.Add(Me.cmdSnoozeOneDay)
        Me.Controls.Add(Me.lblAlertMessage)
        Me.Controls.Add(Me.cmdSnooze)
        Me.Controls.Add(Me.cmdView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "NotificationAlert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification Alert"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdSnooze As System.Windows.Forms.Button
    Friend WithEvents lblAlertMessage As System.Windows.Forms.Label
    Friend WithEvents cmdSnoozeOneDay As System.Windows.Forms.Button
    Friend WithEvents cmdPrintPaymentCoupons As System.Windows.Forms.Button
    Friend WithEvents cmdCreateInvoice As System.Windows.Forms.Button
End Class
