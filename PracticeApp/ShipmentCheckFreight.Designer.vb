<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentCheckFreight
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
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtProNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFreightCharges = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtShipVia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtShipDate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSearchByPO = New System.Windows.Forms.Button
        Me.txtShippingDivision = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(112, 27)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(234, 20)
        Me.txtCustomerPO.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Enter Cust. PO#"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProNumber
        '
        Me.txtProNumber.BackColor = System.Drawing.Color.White
        Me.txtProNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProNumber.Location = New System.Drawing.Point(124, 140)
        Me.txtProNumber.Name = "txtProNumber"
        Me.txtProNumber.ReadOnly = True
        Me.txtProNumber.Size = New System.Drawing.Size(222, 20)
        Me.txtProNumber.TabIndex = 43
        Me.txtProNumber.TabStop = False
        Me.txtProNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "PRO #/ Tracking #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightCharges
        '
        Me.txtFreightCharges.BackColor = System.Drawing.Color.White
        Me.txtFreightCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreightCharges.Location = New System.Drawing.Point(198, 200)
        Me.txtFreightCharges.Name = "txtFreightCharges"
        Me.txtFreightCharges.ReadOnly = True
        Me.txtFreightCharges.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightCharges.TabIndex = 45
        Me.txtFreightCharges.TabStop = False
        Me.txtFreightCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 20)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Freight Charges"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipVia
        '
        Me.txtShipVia.BackColor = System.Drawing.Color.White
        Me.txtShipVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipVia.Location = New System.Drawing.Point(124, 170)
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.ReadOnly = True
        Me.txtShipVia.Size = New System.Drawing.Size(222, 20)
        Me.txtShipVia.TabIndex = 47
        Me.txtShipVia.TabStop = False
        Me.txtShipVia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Ship Via"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipDate
        '
        Me.txtShipDate.BackColor = System.Drawing.Color.White
        Me.txtShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipDate.Location = New System.Drawing.Point(198, 230)
        Me.txtShipDate.Name = "txtShipDate"
        Me.txtShipDate.ReadOnly = True
        Me.txtShipDate.Size = New System.Drawing.Size(148, 20)
        Me.txtShipDate.TabIndex = 49
        Me.txtShipDate.TabStop = False
        Me.txtShipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Ship Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(275, 293)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSearchByPO
        '
        Me.cmdSearchByPO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSearchByPO.Location = New System.Drawing.Point(275, 62)
        Me.cmdSearchByPO.Name = "cmdSearchByPO"
        Me.cmdSearchByPO.Size = New System.Drawing.Size(71, 30)
        Me.cmdSearchByPO.TabIndex = 1
        Me.cmdSearchByPO.Text = "Search"
        Me.cmdSearchByPO.UseVisualStyleBackColor = True
        '
        'txtShippingDivision
        '
        Me.txtShippingDivision.BackColor = System.Drawing.Color.White
        Me.txtShippingDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingDivision.Location = New System.Drawing.Point(198, 260)
        Me.txtShippingDivision.Name = "txtShippingDivision"
        Me.txtShippingDivision.ReadOnly = True
        Me.txtShippingDivision.Size = New System.Drawing.Size(148, 20)
        Me.txtShippingDivision.TabIndex = 53
        Me.txtShippingDivision.TabStop = False
        Me.txtShippingDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Shipping Division"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomer
        '
        Me.txtCustomer.BackColor = System.Drawing.Color.White
        Me.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(124, 110)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(222, 20)
        Me.txtCustomer.TabIndex = 55
        Me.txtCustomer.TabStop = False
        Me.txtCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Customer"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage.Location = New System.Drawing.Point(12, 62)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(248, 30)
        Me.lblMessage.TabIndex = 57
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(198, 293)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 582
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(12, 293)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 31)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Freight charge is amount charged by division to customer."
        '
        'ShipmentCheckFreight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 333)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtShippingDivision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdSearchByPO)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtShipDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtShipVia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFreightCharges)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCustomerPO)
        Me.Controls.Add(Me.Label13)
        Me.Name = "ShipmentCheckFreight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Check Freight Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtProNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFreightCharges As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtShipDate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSearchByPO As System.Windows.Forms.Button
    Friend WithEvents txtShippingDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
