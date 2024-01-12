<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FOXSteelOrderForm
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
        Me.cmdProcess = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtFOXNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSteelRequired = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOrderQuantity = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSteelCarbon = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSteelDescription = New System.Windows.Forms.TextBox
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker
        Me.txtRMID = New System.Windows.Forms.TextBox
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.cboUnits = New System.Windows.Forms.ComboBox
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdProcess
        '
        Me.cmdProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcess.Location = New System.Drawing.Point(485, 271)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcess.TabIndex = 13
        Me.cmdProcess.Text = "Process"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(559, 271)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtFOXNumber
        '
        Me.txtFOXNumber.BackColor = System.Drawing.Color.White
        Me.txtFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXNumber.Location = New System.Drawing.Point(149, 22)
        Me.txtFOXNumber.Name = "txtFOXNumber"
        Me.txtFOXNumber.ReadOnly = True
        Me.txtFOXNumber.Size = New System.Drawing.Size(135, 20)
        Me.txtFOXNumber.TabIndex = 1
        Me.txtFOXNumber.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "FOX #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelRequired
        '
        Me.txtSteelRequired.BackColor = System.Drawing.Color.White
        Me.txtSteelRequired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelRequired.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelRequired.Location = New System.Drawing.Point(149, 59)
        Me.txtSteelRequired.Name = "txtSteelRequired"
        Me.txtSteelRequired.ReadOnly = True
        Me.txtSteelRequired.Size = New System.Drawing.Size(135, 20)
        Me.txtSteelRequired.TabIndex = 2
        Me.txtSteelRequired.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Steel Req. for FOX"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderQuantity
        '
        Me.txtOrderQuantity.BackColor = System.Drawing.Color.White
        Me.txtOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderQuantity.Location = New System.Drawing.Point(402, 240)
        Me.txtOrderQuantity.Name = "txtOrderQuantity"
        Me.txtOrderQuantity.Size = New System.Drawing.Size(114, 20)
        Me.txtOrderQuantity.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(305, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Order Quantity"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelCarbon
        '
        Me.txtSteelCarbon.BackColor = System.Drawing.Color.White
        Me.txtSteelCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelCarbon.Location = New System.Drawing.Point(78, 170)
        Me.txtSteelCarbon.Name = "txtSteelCarbon"
        Me.txtSteelCarbon.ReadOnly = True
        Me.txtSteelCarbon.Size = New System.Drawing.Size(206, 20)
        Me.txtSteelCarbon.TabIndex = 5
        Me.txtSteelCarbon.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Steel Alloy"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelSize
        '
        Me.txtSteelSize.BackColor = System.Drawing.Color.White
        Me.txtSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSize.Location = New System.Drawing.Point(78, 207)
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.ReadOnly = True
        Me.txtSteelSize.Size = New System.Drawing.Size(206, 20)
        Me.txtSteelSize.TabIndex = 6
        Me.txtSteelSize.TabStop = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Steel Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(379, 23)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(251, 21)
        Me.cboVendorID.TabIndex = 8
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
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(305, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Steel Vendor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelDescription
        '
        Me.txtSteelDescription.BackColor = System.Drawing.Color.White
        Me.txtSteelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDescription.Location = New System.Drawing.Point(12, 244)
        Me.txtSteelDescription.Multiline = True
        Me.txtSteelDescription.Name = "txtSteelDescription"
        Me.txtSteelDescription.ReadOnly = True
        Me.txtSteelDescription.Size = New System.Drawing.Size(272, 67)
        Me.txtSteelDescription.TabIndex = 7
        Me.txtSteelDescription.TabStop = False
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BackColor = System.Drawing.Color.White
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartDescription.Location = New System.Drawing.Point(78, 133)
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(206, 20)
        Me.txtPartDescription.TabIndex = 4
        Me.txtPartDescription.TabStop = False
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BackColor = System.Drawing.Color.White
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(78, 96)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(206, 20)
        Me.txtPartNumber.TabIndex = 3
        Me.txtPartNumber.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Description"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Part #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BackColor = System.Drawing.Color.White
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(308, 80)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(322, 113)
        Me.txtComment.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(305, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 20)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Comment/Special Instructions"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(305, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Est. Delivery Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(402, 208)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(114, 20)
        Me.dtpDeliveryDate.TabIndex = 10
        '
        'txtRMID
        '
        Me.txtRMID.BackColor = System.Drawing.Color.White
        Me.txtRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRMID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRMID.Location = New System.Drawing.Point(120, 271)
        Me.txtRMID.Name = "txtRMID"
        Me.txtRMID.ReadOnly = True
        Me.txtRMID.Size = New System.Drawing.Size(109, 20)
        Me.txtRMID.TabIndex = 95
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'cboUnits
        '
        Me.cboUnits.FormattingEnabled = True
        Me.cboUnits.Items.AddRange(New Object() {"Lbs.", "Inches", "Feet", "Bars"})
        Me.cboUnits.Location = New System.Drawing.Point(522, 239)
        Me.cboUnits.Name = "cboUnits"
        Me.cboUnits.Size = New System.Drawing.Size(108, 21)
        Me.cboUnits.TabIndex = 12
        '
        'FOXSteelOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 323)
        Me.Controls.Add(Me.cboUnits)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtPartDescription)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSteelDescription)
        Me.Controls.Add(Me.txtOrderQuantity)
        Me.Controls.Add(Me.txtSteelRequired)
        Me.Controls.Add(Me.txtSteelSize)
        Me.Controls.Add(Me.txtSteelCarbon)
        Me.Controls.Add(Me.cboVendorID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFOXNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtRMID)
        Me.Name = "FOXSteelOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation FOX Steel Order Form"
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtFOXNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSteelRequired As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSteelCarbon As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSteelDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRMID As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents cboUnits As System.Windows.Forms.ComboBox
End Class
