<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelAddNewCoilForm
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
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.txtCoilWeight = New System.Windows.Forms.TextBox
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.txtDespatchNumber = New System.Windows.Forms.TextBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtPurchaseOrderNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.dtpReceiveDate = New System.Windows.Forms.DateTimePicker
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cboCoilStatus = New System.Windows.Forms.ComboBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnterCoil = New System.Windows.Forms.Button
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Location = New System.Drawing.Point(146, 63)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtHeatNumber.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(28, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 20)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Heat Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilID.Location = New System.Drawing.Point(146, 27)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(232, 20)
        Me.txtCoilID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Coil ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Location = New System.Drawing.Point(146, 135)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtLotNumber.TabIndex = 3
        '
        'txtCoilWeight
        '
        Me.txtCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoilWeight.Location = New System.Drawing.Point(225, 99)
        Me.txtCoilWeight.Name = "txtCoilWeight"
        Me.txtCoilWeight.Size = New System.Drawing.Size(153, 20)
        Me.txtCoilWeight.TabIndex = 2
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(146, 317)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtSalesOrderNumber.TabIndex = 8
        '
        'txtDespatchNumber
        '
        Me.txtDespatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDespatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDespatchNumber.Location = New System.Drawing.Point(146, 281)
        Me.txtDespatchNumber.Name = "txtDespatchNumber"
        Me.txtDespatchNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtDespatchNumber.TabIndex = 7
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(100, 461)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(278, 57)
        Me.txtComment.TabIndex = 11
        '
        'txtPurchaseOrderNumber
        '
        Me.txtPurchaseOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseOrderNumber.Location = New System.Drawing.Point(146, 353)
        Me.txtPurchaseOrderNumber.Name = "txtPurchaseOrderNumber"
        Me.txtPurchaseOrderNumber.Size = New System.Drawing.Size(232, 20)
        Me.txtPurchaseOrderNumber.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Lot Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(28, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Coil Weight (lbs.)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(28, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Steel Size"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(28, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Carbon / Alloy"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(28, 353)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Purchase Order #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(28, 245)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Receipt Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(28, 317)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Sales Order #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(28, 281)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Despatch (BOL) #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(28, 535)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Coil Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(28, 389)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Description"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(28, 462)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Comment"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(146, 171)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(232, 21)
        Me.cboCarbon.TabIndex = 4
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(146, 208)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(232, 21)
        Me.cboSteelSize.TabIndex = 5
        '
        'dtpReceiveDate
        '
        Me.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiveDate.Location = New System.Drawing.Point(225, 245)
        Me.dtpReceiveDate.Name = "dtpReceiveDate"
        Me.dtpReceiveDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpReceiveDate.TabIndex = 6
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(100, 389)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(278, 57)
        Me.txtDescription.TabIndex = 10
        '
        'cboCoilStatus
        '
        Me.cboCoilStatus.FormattingEnabled = True
        Me.cboCoilStatus.Items.AddRange(New Object() {"OPEN", "RAW", "WIP", "CLOSED"})
        Me.cboCoilStatus.Location = New System.Drawing.Point(193, 534)
        Me.cboCoilStatus.Name = "cboCoilStatus"
        Me.cboCoilStatus.Size = New System.Drawing.Size(185, 21)
        Me.cboCoilStatus.TabIndex = 12
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(230, 571)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnterCoil
        '
        Me.cmdEnterCoil.Location = New System.Drawing.Point(153, 571)
        Me.cmdEnterCoil.Name = "cmdEnterCoil"
        Me.cmdEnterCoil.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterCoil.TabIndex = 13
        Me.cmdEnterCoil.Text = "Enter Coil"
        Me.cmdEnterCoil.UseVisualStyleBackColor = True
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(307, 571)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 75
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SteelAddNewCoilForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 623)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdEnterCoil)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cboCoilStatus)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.dtpReceiveDate)
        Me.Controls.Add(Me.cboSteelSize)
        Me.Controls.Add(Me.cboCarbon)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtPurchaseOrderNumber)
        Me.Controls.Add(Me.txtSalesOrderNumber)
        Me.Controls.Add(Me.txtDespatchNumber)
        Me.Controls.Add(Me.txtLotNumber)
        Me.Controls.Add(Me.txtCoilWeight)
        Me.Controls.Add(Me.txtHeatNumber)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCoilID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Name = "SteelAddNewCoilForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Add New Coil"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtDespatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents dtpReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboCoilStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnterCoil As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
