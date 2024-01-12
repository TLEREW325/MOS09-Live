<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationEdit
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
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.lblReferenceNumber = New System.Windows.Forms.Label
        Me.dtpTime = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDetails = New System.Windows.Forms.TextBox
        Me.cboEmployee = New System.Windows.Forms.ComboBox
        Me.lblNotificationTime = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cboNotificationType = New System.Windows.Forms.ComboBox
        Me.lblNotificationType = New System.Windows.Forms.Label
        Me.lblNotificationDate = New System.Windows.Forms.Label
        Me.dtpNotificationDate = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Location = New System.Drawing.Point(119, 106)
        Me.txtReferenceNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.txtReferenceNumber.MaxLength = 20
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(162, 20)
        Me.txtReferenceNumber.TabIndex = 31
        '
        'lblReferenceNumber
        '
        Me.lblReferenceNumber.Location = New System.Drawing.Point(13, 106)
        Me.lblReferenceNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.lblReferenceNumber.Name = "lblReferenceNumber"
        Me.lblReferenceNumber.Size = New System.Drawing.Size(114, 21)
        Me.lblReferenceNumber.TabIndex = 49
        Me.lblReferenceNumber.Text = "Reference Number"
        Me.lblReferenceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTime
        '
        Me.dtpTime.CustomFormat = "hh:mm tt"
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(160, 166)
        Me.dtpTime.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(122, 20)
        Me.dtpTime.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 196)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Details"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(17, 224)
        Me.txtDetails.MaxLength = 500
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(266, 141)
        Me.txtDetails.TabIndex = 36
        '
        'cboEmployee
        '
        Me.cboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployee.Enabled = False
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(119, 44)
        Me.cboEmployee.Margin = New System.Windows.Forms.Padding(5)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(163, 21)
        Me.cboEmployee.TabIndex = 40
        '
        'lblNotificationTime
        '
        Me.lblNotificationTime.Location = New System.Drawing.Point(14, 165)
        Me.lblNotificationTime.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationTime.Name = "lblNotificationTime"
        Me.lblNotificationTime.Size = New System.Drawing.Size(114, 20)
        Me.lblNotificationTime.TabIndex = 47
        Me.lblNotificationTime.Text = "Notification Time"
        Me.lblNotificationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Employee"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDivisionID
        '
        Me.lblDivisionID.Location = New System.Drawing.Point(14, 14)
        Me.lblDivisionID.Margin = New System.Windows.Forms.Padding(5)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(118, 21)
        Me.lblDivisionID.TabIndex = 45
        Me.lblDivisionID.Text = "Division ID"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(161, 13)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(121, 21)
        Me.cboDivisionID.TabIndex = 39
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(201, 374)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 38
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(96, 374)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdate.TabIndex = 37
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cboNotificationType
        '
        Me.cboNotificationType.FormattingEnabled = True
        Me.cboNotificationType.Items.AddRange(New Object() {"Billing", "Shipping"})
        Me.cboNotificationType.Location = New System.Drawing.Point(119, 75)
        Me.cboNotificationType.Margin = New System.Windows.Forms.Padding(5)
        Me.cboNotificationType.Name = "cboNotificationType"
        Me.cboNotificationType.Size = New System.Drawing.Size(163, 21)
        Me.cboNotificationType.TabIndex = 30
        '
        'lblNotificationType
        '
        Me.lblNotificationType.Location = New System.Drawing.Point(11, 75)
        Me.lblNotificationType.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationType.Name = "lblNotificationType"
        Me.lblNotificationType.Size = New System.Drawing.Size(118, 21)
        Me.lblNotificationType.TabIndex = 43
        Me.lblNotificationType.Text = "Notification Type"
        Me.lblNotificationType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotificationDate
        '
        Me.lblNotificationDate.Location = New System.Drawing.Point(13, 136)
        Me.lblNotificationDate.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationDate.Name = "lblNotificationDate"
        Me.lblNotificationDate.Size = New System.Drawing.Size(114, 19)
        Me.lblNotificationDate.TabIndex = 41
        Me.lblNotificationDate.Text = "Notification Date"
        Me.lblNotificationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpNotificationDate
        '
        Me.dtpNotificationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNotificationDate.Location = New System.Drawing.Point(159, 136)
        Me.dtpNotificationDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpNotificationDate.Name = "dtpNotificationDate"
        Me.dtpNotificationDate.Size = New System.Drawing.Size(122, 20)
        Me.dtpNotificationDate.TabIndex = 33
        '
        'NotificationEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 423)
        Me.Controls.Add(Me.txtReferenceNumber)
        Me.Controls.Add(Me.lblReferenceNumber)
        Me.Controls.Add(Me.dtpTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.cboEmployee)
        Me.Controls.Add(Me.lblNotificationTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDivisionID)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cboNotificationType)
        Me.Controls.Add(Me.lblNotificationType)
        Me.Controls.Add(Me.lblNotificationDate)
        Me.Controls.Add(Me.dtpNotificationDate)
        Me.Name = "NotificationEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditNotification"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents cboEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotificationTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cboNotificationType As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotificationType As System.Windows.Forms.Label
    Friend WithEvents lblNotificationDate As System.Windows.Forms.Label
    Friend WithEvents dtpNotificationDate As System.Windows.Forms.DateTimePicker
End Class
