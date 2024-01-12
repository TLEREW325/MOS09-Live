<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationsAdd
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
        Me.cboNotificationType = New System.Windows.Forms.ComboBox
        Me.lblNotificationType = New System.Windows.Forms.Label
        Me.lblFrequency = New System.Windows.Forms.Label
        Me.cboFrequency = New System.Windows.Forms.ComboBox
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.dtpStartingDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndingDate = New System.Windows.Forms.Label
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboEmployee = New System.Windows.Forms.ComboBox
        Me.lblNotificationTime = New System.Windows.Forms.Label
        Me.txtDetails = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpTime = New System.Windows.Forms.DateTimePicker
        Me.lblReferenceNumber = New System.Windows.Forms.Label
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cboNotificationType
        '
        Me.cboNotificationType.FormattingEnabled = True
        Me.cboNotificationType.Items.AddRange(New Object() {"Billing", "Shipping", "Invoicing"})
        Me.cboNotificationType.Location = New System.Drawing.Point(127, 76)
        Me.cboNotificationType.Margin = New System.Windows.Forms.Padding(5)
        Me.cboNotificationType.Name = "cboNotificationType"
        Me.cboNotificationType.Size = New System.Drawing.Size(163, 21)
        Me.cboNotificationType.TabIndex = 0
        '
        'lblNotificationType
        '
        Me.lblNotificationType.Location = New System.Drawing.Point(19, 76)
        Me.lblNotificationType.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationType.Name = "lblNotificationType"
        Me.lblNotificationType.Size = New System.Drawing.Size(118, 21)
        Me.lblNotificationType.TabIndex = 15
        Me.lblNotificationType.Text = "Notification Type"
        Me.lblNotificationType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFrequency
        '
        Me.lblFrequency.Location = New System.Drawing.Point(21, 137)
        Me.lblFrequency.Margin = New System.Windows.Forms.Padding(5)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Size = New System.Drawing.Size(114, 21)
        Me.lblFrequency.TabIndex = 14
        Me.lblFrequency.Text = "Frequency"
        Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFrequency
        '
        Me.cboFrequency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFrequency.FormattingEnabled = True
        Me.cboFrequency.Items.AddRange(New Object() {"Every Other Month", "Every Other Week", "Weekly", "Monthly", "Only Once"})
        Me.cboFrequency.Location = New System.Drawing.Point(127, 137)
        Me.cboFrequency.Margin = New System.Windows.Forms.Padding(5)
        Me.cboFrequency.Name = "cboFrequency"
        Me.cboFrequency.Size = New System.Drawing.Size(163, 21)
        Me.cboFrequency.TabIndex = 2
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(21, 168)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(114, 19)
        Me.lblStartDate.TabIndex = 11
        Me.lblStartDate.Text = "Starting Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartingDate
        '
        Me.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartingDate.Location = New System.Drawing.Point(167, 168)
        Me.dtpStartingDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpStartingDate.Name = "dtpStartingDate"
        Me.dtpStartingDate.Size = New System.Drawing.Size(122, 20)
        Me.dtpStartingDate.TabIndex = 3
        '
        'lblEndingDate
        '
        Me.lblEndingDate.Location = New System.Drawing.Point(21, 197)
        Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(5)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(114, 20)
        Me.lblEndingDate.TabIndex = 17
        Me.lblEndingDate.Text = "Ending Date"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndingDate.Location = New System.Drawing.Point(167, 198)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(122, 20)
        Me.dtpEndingDate.TabIndex = 4
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(103, 436)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(208, 436)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(169, 14)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(121, 21)
        Me.cboDivisionID.TabIndex = 9
        '
        'lblDivisionID
        '
        Me.lblDivisionID.Location = New System.Drawing.Point(22, 15)
        Me.lblDivisionID.Margin = New System.Windows.Forms.Padding(5)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(118, 21)
        Me.lblDivisionID.TabIndex = 21
        Me.lblDivisionID.Text = "Division ID"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Employee"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmployee
        '
        Me.cboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployee.Enabled = False
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(127, 45)
        Me.cboEmployee.Margin = New System.Windows.Forms.Padding(5)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(163, 21)
        Me.cboEmployee.TabIndex = 10
        '
        'lblNotificationTime
        '
        Me.lblNotificationTime.Location = New System.Drawing.Point(21, 227)
        Me.lblNotificationTime.Margin = New System.Windows.Forms.Padding(5)
        Me.lblNotificationTime.Name = "lblNotificationTime"
        Me.lblNotificationTime.Size = New System.Drawing.Size(114, 20)
        Me.lblNotificationTime.TabIndex = 25
        Me.lblNotificationTime.Text = "Notification Time"
        Me.lblNotificationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(24, 286)
        Me.txtDetails.MaxLength = 500
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(266, 141)
        Me.txtDetails.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 258)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Details"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTime
        '
        Me.dtpTime.CustomFormat = "hh:mm tt"
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(167, 228)
        Me.dtpTime.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(122, 20)
        Me.dtpTime.TabIndex = 5
        '
        'lblReferenceNumber
        '
        Me.lblReferenceNumber.Location = New System.Drawing.Point(21, 107)
        Me.lblReferenceNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.lblReferenceNumber.Name = "lblReferenceNumber"
        Me.lblReferenceNumber.Size = New System.Drawing.Size(114, 21)
        Me.lblReferenceNumber.TabIndex = 29
        Me.lblReferenceNumber.Text = "Reference Number"
        Me.lblReferenceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Location = New System.Drawing.Point(127, 107)
        Me.txtReferenceNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.txtReferenceNumber.MaxLength = 20
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(162, 20)
        Me.txtReferenceNumber.TabIndex = 1
        '
        'NotificationsAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 495)
        Me.Controls.Add(Me.txtReferenceNumber)
        Me.Controls.Add(Me.lblReferenceNumber)
        Me.Controls.Add(Me.dtpTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.cboEmployee)
        Me.Controls.Add(Me.cboFrequency)
        Me.Controls.Add(Me.lblNotificationTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDivisionID)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lblEndingDate)
        Me.Controls.Add(Me.dtpEndingDate)
        Me.Controls.Add(Me.cboNotificationType)
        Me.Controls.Add(Me.lblNotificationType)
        Me.Controls.Add(Me.lblFrequency)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.dtpStartingDate)
        Me.Name = "NotificationsAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Notifications"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboNotificationType As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotificationType As System.Windows.Forms.Label
    Friend WithEvents lblFrequency As System.Windows.Forms.Label
    Friend WithEvents cboFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndingDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotificationTime As System.Windows.Forms.Label
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
End Class
