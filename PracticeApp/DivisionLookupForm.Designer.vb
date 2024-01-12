<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DivisionLookupForm
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
        Me.components = New System.ComponentModel.Container
        Me.txtPOLookup = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtARInvoiceLookup = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAPInvoiceLookup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdLookup = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVendorLookup = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerLookup = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLookupDivision = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtLookupNotes = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtARCheck = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPRONumber = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPOLookup
        '
        Me.txtPOLookup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOLookup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOLookup.Location = New System.Drawing.Point(113, 29)
        Me.txtPOLookup.Name = "txtPOLookup"
        Me.txtPOLookup.Size = New System.Drawing.Size(162, 20)
        Me.txtPOLookup.TabIndex = 0
        Me.txtPOLookup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "PO #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtARInvoiceLookup
        '
        Me.txtARInvoiceLookup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtARInvoiceLookup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARInvoiceLookup.Location = New System.Drawing.Point(113, 119)
        Me.txtARInvoiceLookup.Name = "txtARInvoiceLookup"
        Me.txtARInvoiceLookup.Size = New System.Drawing.Size(162, 20)
        Me.txtARInvoiceLookup.TabIndex = 3
        Me.txtARInvoiceLookup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "A/R Invoice #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPInvoiceLookup
        '
        Me.txtAPInvoiceLookup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPInvoiceLookup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPInvoiceLookup.Location = New System.Drawing.Point(113, 59)
        Me.txtAPInvoiceLookup.Name = "txtAPInvoiceLookup"
        Me.txtAPInvoiceLookup.Size = New System.Drawing.Size(162, 20)
        Me.txtAPInvoiceLookup.TabIndex = 1
        Me.txtAPInvoiceLookup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "A/P Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLookup
        '
        Me.cmdLookup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLookup.Location = New System.Drawing.Point(355, 271)
        Me.cmdLookup.Name = "cmdLookup"
        Me.cmdLookup.Size = New System.Drawing.Size(71, 40)
        Me.cmdLookup.TabIndex = 9
        Me.cmdLookup.Text = "Lookup"
        Me.cmdLookup.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(509, 271)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Vendor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorLookup
        '
        Me.cboVendorLookup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorLookup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorLookup.DataSource = Me.VendorBindingSource
        Me.cboVendorLookup.DisplayMember = "VendorCode"
        Me.cboVendorLookup.FormattingEnabled = True
        Me.cboVendorLookup.Location = New System.Drawing.Point(72, 251)
        Me.cboVendorLookup.Name = "cboVendorLookup"
        Me.cboVendorLookup.Size = New System.Drawing.Size(203, 21)
        Me.cboVendorLookup.TabIndex = 6
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerLookup
        '
        Me.cboCustomerLookup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerLookup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerLookup.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerLookup.DisplayMember = "CustomerID"
        Me.cboCustomerLookup.FormattingEnabled = True
        Me.cboCustomerLookup.Location = New System.Drawing.Point(72, 287)
        Me.cboCustomerLookup.Name = "cboCustomerLookup"
        Me.cboCustomerLookup.Size = New System.Drawing.Size(203, 21)
        Me.cboCustomerLookup.TabIndex = 7
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(311, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(228, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Lookup Division"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLookupDivision
        '
        Me.txtLookupDivision.BackColor = System.Drawing.Color.White
        Me.txtLookupDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLookupDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLookupDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLookupDivision.Location = New System.Drawing.Point(314, 52)
        Me.txtLookupDivision.Name = "txtLookupDivision"
        Me.txtLookupDivision.ReadOnly = True
        Me.txtLookupDivision.Size = New System.Drawing.Size(266, 20)
        Me.txtLookupDivision.TabIndex = 7
        Me.txtLookupDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(311, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(228, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Lookup Notes"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLookupNotes
        '
        Me.txtLookupNotes.BackColor = System.Drawing.Color.White
        Me.txtLookupNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLookupNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLookupNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLookupNotes.Location = New System.Drawing.Point(314, 112)
        Me.txtLookupNotes.Multiline = True
        Me.txtLookupNotes.Name = "txtLookupNotes"
        Me.txtLookupNotes.ReadOnly = True
        Me.txtLookupNotes.Size = New System.Drawing.Size(266, 140)
        Me.txtLookupNotes.TabIndex = 8
        Me.txtLookupNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(432, 271)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear All"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(113, 89)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(162, 20)
        Me.txtShipmentNumber.TabIndex = 2
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Shipment #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(113, 149)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(162, 20)
        Me.txtSalesOrderNumber.TabIndex = 4
        Me.txtSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Sales Order"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtARCheck
        '
        Me.txtARCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtARCheck.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtARCheck.Location = New System.Drawing.Point(113, 179)
        Me.txtARCheck.Name = "txtARCheck"
        Me.txtARCheck.Size = New System.Drawing.Size(162, 20)
        Me.txtARCheck.TabIndex = 5
        Me.txtARCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 179)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "A/R Check #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPRONumber
        '
        Me.txtPRONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONumber.Location = New System.Drawing.Point(113, 209)
        Me.txtPRONumber.Name = "txtPRONumber"
        Me.txtPRONumber.Size = New System.Drawing.Size(162, 20)
        Me.txtPRONumber.TabIndex = 37
        Me.txtPRONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 209)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "PRO #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionLookupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 323)
        Me.Controls.Add(Me.txtPRONumber)
        Me.Controls.Add(Me.txtARCheck)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSalesOrderNumber)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtShipmentNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtLookupNotes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtLookupDivision)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboCustomerLookup)
        Me.Controls.Add(Me.cboVendorLookup)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdLookup)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtAPInvoiceLookup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtARInvoiceLookup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPOLookup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Name = "DivisionLookupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Division Lookup Form"
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPOLookup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtARInvoiceLookup As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAPInvoiceLookup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdLookup As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendorLookup As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerLookup As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLookupDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLookupNotes As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtARCheck As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPRONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
