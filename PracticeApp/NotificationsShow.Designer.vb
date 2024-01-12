<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationsShow
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
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.lblNotificationTypeLabel = New System.Windows.Forms.Label
        Me.lblNotificationType = New System.Windows.Forms.Label
        Me.lblReferenceNumber = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblNotificationRecipient = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblNotificationTime = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblDetails = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdComplete = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdPrintPaymentCoupons = New System.Windows.Forms.Button
        Me.cmdCreateInvoice = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdPrevious.Location = New System.Drawing.Point(12, 361)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrevious.TabIndex = 1
        Me.cmdPrevious.Text = "Previous"
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdNext.Location = New System.Drawing.Point(89, 361)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(71, 40)
        Me.cmdNext.TabIndex = 2
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCount.Location = New System.Drawing.Point(12, 332)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(120, 23)
        Me.lblCount.TabIndex = 3
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdClose.Location = New System.Drawing.Point(539, 361)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(71, 40)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'lblNotificationTypeLabel
        '
        Me.lblNotificationTypeLabel.AutoSize = True
        Me.lblNotificationTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotificationTypeLabel.Location = New System.Drawing.Point(22, 13)
        Me.lblNotificationTypeLabel.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationTypeLabel.Name = "lblNotificationTypeLabel"
        Me.lblNotificationTypeLabel.Size = New System.Drawing.Size(104, 13)
        Me.lblNotificationTypeLabel.TabIndex = 5
        Me.lblNotificationTypeLabel.Text = "Notification Type"
        '
        'lblNotificationType
        '
        Me.lblNotificationType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotificationType.Location = New System.Drawing.Point(166, 13)
        Me.lblNotificationType.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationType.Name = "lblNotificationType"
        Me.lblNotificationType.Size = New System.Drawing.Size(357, 13)
        Me.lblNotificationType.TabIndex = 6
        '
        'lblReferenceNumber
        '
        Me.lblReferenceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferenceNumber.Location = New System.Drawing.Point(166, 36)
        Me.lblReferenceNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.lblReferenceNumber.Name = "lblReferenceNumber"
        Me.lblReferenceNumber.Size = New System.Drawing.Size(357, 13)
        Me.lblReferenceNumber.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Reference Number"
        '
        'lblNotificationRecipient
        '
        Me.lblNotificationRecipient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotificationRecipient.Location = New System.Drawing.Point(166, 59)
        Me.lblNotificationRecipient.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationRecipient.Name = "lblNotificationRecipient"
        Me.lblNotificationRecipient.Size = New System.Drawing.Size(357, 13)
        Me.lblNotificationRecipient.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Notification Recipient"
        '
        'lblNotificationTime
        '
        Me.lblNotificationTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotificationTime.Location = New System.Drawing.Point(166, 82)
        Me.lblNotificationTime.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationTime.Name = "lblNotificationTime"
        Me.lblNotificationTime.Size = New System.Drawing.Size(357, 13)
        Me.lblNotificationTime.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 82)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Notification Time"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(166, 105)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(357, 13)
        Me.lblStatus.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 105)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Notification Status"
        '
        'lblDetails
        '
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(25, 151)
        Me.lblDetails.Margin = New System.Windows.Forms.Padding(5)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(595, 176)
        Me.lblDetails.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 128)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Notification Details"
        '
        'cmdComplete
        '
        Me.cmdComplete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdComplete.Location = New System.Drawing.Point(462, 361)
        Me.cmdComplete.Name = "cmdComplete"
        Me.cmdComplete.Size = New System.Drawing.Size(71, 40)
        Me.cmdComplete.TabIndex = 17
        Me.cmdComplete.Text = "Complete"
        Me.cmdComplete.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdDelete.Location = New System.Drawing.Point(385, 361)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 18
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdEdit.Location = New System.Drawing.Point(308, 361)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(71, 40)
        Me.cmdEdit.TabIndex = 19
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdPrintPaymentCoupons
        '
        Me.cmdPrintPaymentCoupons.Location = New System.Drawing.Point(231, 361)
        Me.cmdPrintPaymentCoupons.Name = "cmdPrintPaymentCoupons"
        Me.cmdPrintPaymentCoupons.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPaymentCoupons.TabIndex = 20
        Me.cmdPrintPaymentCoupons.Text = "Print Coupons"
        Me.cmdPrintPaymentCoupons.UseVisualStyleBackColor = True
        Me.cmdPrintPaymentCoupons.Visible = False
        '
        'cmdCreateInvoice
        '
        Me.cmdCreateInvoice.Location = New System.Drawing.Point(231, 361)
        Me.cmdCreateInvoice.Name = "cmdCreateInvoice"
        Me.cmdCreateInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateInvoice.TabIndex = 21
        Me.cmdCreateInvoice.Text = "Create Invoice"
        Me.cmdCreateInvoice.UseVisualStyleBackColor = True
        Me.cmdCreateInvoice.Visible = False
        '
        'NotificationsShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 409)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCreateInvoice)
        Me.Controls.Add(Me.cmdPrintPaymentCoupons)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdComplete)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblNotificationTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNotificationRecipient)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblReferenceNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNotificationType)
        Me.Controls.Add(Me.lblNotificationTypeLabel)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "NotificationsShow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Show Notifications"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblNotificationTypeLabel As System.Windows.Forms.Label
    Friend WithEvents lblNotificationType As System.Windows.Forms.Label
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNotificationRecipient As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNotificationTime As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdComplete As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintPaymentCoupons As System.Windows.Forms.Button
    Friend WithEvents cmdCreateInvoice As System.Windows.Forms.Button
End Class
