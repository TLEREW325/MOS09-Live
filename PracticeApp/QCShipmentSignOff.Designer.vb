<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCShipmentSignOff
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
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdSignOff = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.lblLabelShipmentNumber = New System.Windows.Forms.Label
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.lblLabelUser = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSalesOrderNumber = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblShipmentNumber = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(124, 258)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 0
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSignOff
        '
        Me.cmdSignOff.Location = New System.Drawing.Point(47, 258)
        Me.cmdSignOff.Name = "cmdSignOff"
        Me.cmdSignOff.Size = New System.Drawing.Size(71, 40)
        Me.cmdSignOff.TabIndex = 1
        Me.cmdSignOff.Text = "Sign Off"
        Me.cmdSignOff.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(201, 258)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblLabelShipmentNumber
        '
        Me.lblLabelShipmentNumber.AutoSize = True
        Me.lblLabelShipmentNumber.Location = New System.Drawing.Point(13, 28)
        Me.lblLabelShipmentNumber.Name = "lblLabelShipmentNumber"
        Me.lblLabelShipmentNumber.Size = New System.Drawing.Size(101, 13)
        Me.lblLabelShipmentNumber.TabIndex = 3
        Me.lblLabelShipmentNumber.Text = "Pick Ticket Number"
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(124, 25)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(148, 21)
        Me.cboPickTicketNumber.TabIndex = 4
        '
        'lblLabelUser
        '
        Me.lblLabelUser.AutoSize = True
        Me.lblLabelUser.Location = New System.Drawing.Point(13, 208)
        Me.lblLabelUser.Name = "lblLabelUser"
        Me.lblLabelUser.Size = New System.Drawing.Size(29, 13)
        Me.lblLabelUser.TabIndex = 5
        Me.lblLabelUser.Text = "User"
        '
        'lblUser
        '
        Me.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUser.Location = New System.Drawing.Point(124, 203)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(148, 23)
        Me.lblUser.TabIndex = 6
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCustomerID
        '
        Me.lblCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerID.Location = New System.Drawing.Point(124, 110)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(148, 23)
        Me.lblCustomerID.TabIndex = 8
        Me.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Customer ID"
        '
        'lblSalesOrderNumber
        '
        Me.lblSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSalesOrderNumber.Location = New System.Drawing.Point(124, 52)
        Me.lblSalesOrderNumber.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSalesOrderNumber.Name = "lblSalesOrderNumber"
        Me.lblSalesOrderNumber.Size = New System.Drawing.Size(148, 23)
        Me.lblSalesOrderNumber.TabIndex = 10
        Me.lblSalesOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Sales Order Number"
        '
        'lblShipmentNumber
        '
        Me.lblShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShipmentNumber.Location = New System.Drawing.Point(124, 81)
        Me.lblShipmentNumber.Margin = New System.Windows.Forms.Padding(3)
        Me.lblShipmentNumber.Name = "lblShipmentNumber"
        Me.lblShipmentNumber.Size = New System.Drawing.Size(148, 23)
        Me.lblShipmentNumber.TabIndex = 12
        Me.lblShipmentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Shipment Number"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerName.Location = New System.Drawing.Point(16, 139)
        Me.lblCustomerName.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(256, 23)
        Me.lblCustomerName.TabIndex = 13
        Me.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QCShipmentSignOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 310)
        Me.Controls.Add(Me.lblCustomerName)
        Me.Controls.Add(Me.lblShipmentNumber)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblSalesOrderNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCustomerID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblLabelUser)
        Me.Controls.Add(Me.cboPickTicketNumber)
        Me.Controls.Add(Me.lblLabelShipmentNumber)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSignOff)
        Me.Controls.Add(Me.cmdClear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "QCShipmentSignOff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "QC Shipment Sign Off"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSignOff As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents lblLabelShipmentNumber As System.Windows.Forms.Label
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblLabelUser As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSalesOrderNumber As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblShipmentNumber As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
End Class
