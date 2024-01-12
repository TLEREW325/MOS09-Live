<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCNonConformanceRackingAddToRacking
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.txtTotalPieces = New System.Windows.Forms.TextBox
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.txtPiecesPerBox = New System.Windows.Forms.TextBox
        Me.txtBoxQuantity = New System.Windows.Forms.TextBox
        Me.cboPNCNumber = New System.Windows.Forms.ComboBox
        Me.QCHoldAdjustmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPartDescription = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.cmdAddToRack = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtHoldReason = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBinNumber = New System.Windows.Forms.ComboBox
        Me.BinNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BinNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.QCHoldAdjustmentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCHoldAdjustmentTableAdapter
        Me.GroupBox1.SuspendLayout()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QCHoldAdjustmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalWeight)
        Me.GroupBox1.Controls.Add(Me.txtTotalPieces)
        Me.GroupBox1.Controls.Add(Me.cboLotNumber)
        Me.GroupBox1.Controls.Add(Me.lblFOXNumber)
        Me.GroupBox1.Controls.Add(Me.txtPiecesPerBox)
        Me.GroupBox1.Controls.Add(Me.txtBoxQuantity)
        Me.GroupBox1.Controls.Add(Me.cboPNCNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblPartDescription)
        Me.GroupBox1.Controls.Add(Me.lblPartNumber)
        Me.GroupBox1.Controls.Add(Me.cmdAddToRack)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtHoldReason)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboBinNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 520)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add To QC Rack"
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Location = New System.Drawing.Point(108, 290)
        Me.txtTotalWeight.MaxLength = 12
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(169, 20)
        Me.txtTotalWeight.TabIndex = 5
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPieces
        '
        Me.txtTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPieces.Location = New System.Drawing.Point(108, 261)
        Me.txtTotalPieces.MaxLength = 9
        Me.txtTotalPieces.Name = "txtTotalPieces"
        Me.txtTotalPieces.Size = New System.Drawing.Size(169, 20)
        Me.txtTotalPieces.TabIndex = 4
        Me.txtTotalPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(108, 165)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(169, 21)
        Me.cboLotNumber.TabIndex = 1
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFOXNumber.Location = New System.Drawing.Point(108, 123)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(169, 20)
        Me.lblFOXNumber.TabIndex = 63
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPiecesPerBox
        '
        Me.txtPiecesPerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesPerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPiecesPerBox.Location = New System.Drawing.Point(108, 203)
        Me.txtPiecesPerBox.MaxLength = 9
        Me.txtPiecesPerBox.Name = "txtPiecesPerBox"
        Me.txtPiecesPerBox.Size = New System.Drawing.Size(169, 20)
        Me.txtPiecesPerBox.TabIndex = 2
        Me.txtPiecesPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxQuantity
        '
        Me.txtBoxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxQuantity.Location = New System.Drawing.Point(108, 232)
        Me.txtBoxQuantity.MaxLength = 9
        Me.txtBoxQuantity.Name = "txtBoxQuantity"
        Me.txtBoxQuantity.Size = New System.Drawing.Size(169, 20)
        Me.txtBoxQuantity.TabIndex = 3
        Me.txtBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPNCNumber
        '
        Me.cboPNCNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPNCNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPNCNumber.DataSource = Me.QCHoldAdjustmentBindingSource
        Me.cboPNCNumber.DisplayMember = "QCTransactionNumber"
        Me.cboPNCNumber.FormattingEnabled = True
        Me.cboPNCNumber.Location = New System.Drawing.Point(108, 20)
        Me.cboPNCNumber.Name = "cboPNCNumber"
        Me.cboPNCNumber.Size = New System.Drawing.Size(169, 21)
        Me.cboPNCNumber.TabIndex = 0
        '
        'QCHoldAdjustmentBindingSource
        '
        Me.QCHoldAdjustmentBindingSource.DataMember = "QCHoldAdjustment"
        Me.QCHoldAdjustmentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "PNC #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Location = New System.Drawing.Point(20, 88)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Size = New System.Drawing.Size(257, 20)
        Me.lblPartDescription.TabIndex = 61
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.Location = New System.Drawing.Point(62, 58)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(215, 20)
        Me.lblPartNumber.TabIndex = 60
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAddToRack
        '
        Me.cmdAddToRack.Location = New System.Drawing.Point(129, 465)
        Me.cmdAddToRack.Name = "cmdAddToRack"
        Me.cmdAddToRack.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddToRack.TabIndex = 8
        Me.cmdAddToRack.Text = "Add To Rack"
        Me.cmdAddToRack.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(20, 324)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 20)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Hold Reason"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHoldReason
        '
        Me.txtHoldReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoldReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHoldReason.Location = New System.Drawing.Point(20, 346)
        Me.txtHoldReason.MaxLength = 500
        Me.txtHoldReason.Multiline = True
        Me.txtHoldReason.Name = "txtHoldReason"
        Me.txtHoldReason.Size = New System.Drawing.Size(257, 66)
        Me.txtHoldReason.TabIndex = 6
        Me.txtHoldReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 20)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Total Weight"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 261)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 20)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Total Pieces"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 20)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Pieces per Box"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 20)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "# of Boxes"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(206, 465)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 20)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "LOT #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 428)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Bin #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "FOX #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBinNumber
        '
        Me.cboBinNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboBinNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBinNumber.DataSource = Me.BinNumberBindingSource
        Me.cboBinNumber.DisplayMember = "BinNumber"
        Me.cboBinNumber.FormattingEnabled = True
        Me.cboBinNumber.Location = New System.Drawing.Point(131, 427)
        Me.cboBinNumber.Name = "cboBinNumber"
        Me.cboBinNumber.Size = New System.Drawing.Size(146, 21)
        Me.cboBinNumber.TabIndex = 7
        '
        'BinNumberBindingSource
        '
        Me.BinNumberBindingSource.DataMember = "BinNumber"
        Me.BinNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BinNumberTableAdapter
        '
        Me.BinNumberTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'QCHoldAdjustmentTableAdapter
        '
        Me.QCHoldAdjustmentTableAdapter.ClearBeforeFill = True
        '
        'QCNonConformanceRackingAddToRacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 537)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "QCNonConformanceRackingAddToRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add To  Non-Conformance Racking"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QCHoldAdjustmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddToRack As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHoldReason As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPiecesPerBox As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBinNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents lblPartDescription As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPNCNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPieces As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents BinNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents QCHoldAdjustmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QCHoldAdjustmentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCHoldAdjustmentTableAdapter
End Class
