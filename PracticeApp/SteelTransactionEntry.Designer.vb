<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelTransactionEntry
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
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker
        Me.txtRMID = New System.Windows.Forms.TextBox
        Me.cboTransactionMath = New System.Windows.Forms.ComboBox
        Me.txtReferenceLine = New System.Windows.Forms.TextBox
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.txtExtendedCost = New System.Windows.Forms.TextBox
        Me.txtSteelCost = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSteelTransactionKey = New System.Windows.Forms.TextBox
        Me.cmdGenerateTransactionNumber = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdAddSteelTransaction = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTransactionType = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(143, 329)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(172, 20)
        Me.txtQuantity.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(21, 329)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 20)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Quantity"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(123, 160)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(192, 21)
        Me.cboCarbon.TabIndex = 4
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionDate.Location = New System.Drawing.Point(143, 103)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpTransactionDate.TabIndex = 3
        '
        'txtRMID
        '
        Me.txtRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRMID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRMID.Location = New System.Drawing.Point(21, 239)
        Me.txtRMID.Multiline = True
        Me.txtRMID.Name = "txtRMID"
        Me.txtRMID.Size = New System.Drawing.Size(294, 64)
        Me.txtRMID.TabIndex = 6
        '
        'cboTransactionMath
        '
        Me.cboTransactionMath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionMath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionMath.DisplayMember = "GLJournalID"
        Me.cboTransactionMath.FormattingEnabled = True
        Me.cboTransactionMath.Items.AddRange(New Object() {"ADD", "SUBTRACT"})
        Me.cboTransactionMath.Location = New System.Drawing.Point(143, 547)
        Me.cboTransactionMath.Name = "cboTransactionMath"
        Me.cboTransactionMath.Size = New System.Drawing.Size(172, 21)
        Me.cboTransactionMath.TabIndex = 12
        '
        'txtReferenceLine
        '
        Me.txtReferenceLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceLine.Location = New System.Drawing.Point(170, 493)
        Me.txtReferenceLine.Name = "txtReferenceLine"
        Me.txtReferenceLine.Size = New System.Drawing.Size(145, 20)
        Me.txtReferenceLine.TabIndex = 11
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNumber.Location = New System.Drawing.Point(170, 458)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtReferenceNumber.TabIndex = 10
        '
        'txtExtendedCost
        '
        Me.txtExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedCost.Location = New System.Drawing.Point(143, 401)
        Me.txtExtendedCost.Name = "txtExtendedCost"
        Me.txtExtendedCost.Size = New System.Drawing.Size(172, 20)
        Me.txtExtendedCost.TabIndex = 9
        '
        'txtSteelCost
        '
        Me.txtSteelCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelCost.Location = New System.Drawing.Point(143, 365)
        Me.txtSteelCost.Name = "txtSteelCost"
        Me.txtSteelCost.Size = New System.Drawing.Size(172, 20)
        Me.txtSteelCost.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 548)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 20)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Transaction Math"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelTransactionKey
        '
        Me.txtSteelTransactionKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelTransactionKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelTransactionKey.Location = New System.Drawing.Point(143, 67)
        Me.txtSteelTransactionKey.Name = "txtSteelTransactionKey"
        Me.txtSteelTransactionKey.Size = New System.Drawing.Size(172, 20)
        Me.txtSteelTransactionKey.TabIndex = 2
        '
        'cmdGenerateTransactionNumber
        '
        Me.cmdGenerateTransactionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateTransactionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateTransactionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateTransactionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateTransactionNumber.Location = New System.Drawing.Point(111, 67)
        Me.cmdGenerateTransactionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateTransactionNumber.Name = "cmdGenerateTransactionNumber"
        Me.cmdGenerateTransactionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateTransactionNumber.TabIndex = 1
        Me.cmdGenerateTransactionNumber.Text = ">>"
        Me.cmdGenerateTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateTransactionNumber.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(170, 711)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAddSteelTransaction
        '
        Me.cmdAddSteelTransaction.Location = New System.Drawing.Point(93, 711)
        Me.cmdAddSteelTransaction.Name = "cmdAddSteelTransaction"
        Me.cmdAddSteelTransaction.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddSteelTransaction.TabIndex = 14
        Me.cmdAddSteelTransaction.Text = "Add"
        Me.cmdAddSteelTransaction.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(143, 32)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(172, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 20)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Steel Trans. #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 493)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 20)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Steel Reference Line #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 458)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 20)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Steel Reference #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 401)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 20)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Extended Cost"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 365)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Steel Cost (Lb.)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(21, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 20)
        Me.Label11.TabIndex = 101
        Me.Label11.Text = "Steel Trans. Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 20)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Carbon/Alloy"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(123, 196)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(192, 21)
        Me.cboSteelSize.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 20)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Steel Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionType
        '
        Me.txtTransactionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionType.Location = New System.Drawing.Point(21, 613)
        Me.txtTransactionType.Multiline = True
        Me.txtTransactionType.Name = "txtTransactionType"
        Me.txtTransactionType.Size = New System.Drawing.Size(294, 64)
        Me.txtTransactionType.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 590)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 20)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Transaction Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(244, 711)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 109
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SteelTransactionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 753)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtTransactionType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboSteelSize)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboCarbon)
        Me.Controls.Add(Me.dtpTransactionDate)
        Me.Controls.Add(Me.txtRMID)
        Me.Controls.Add(Me.cboTransactionMath)
        Me.Controls.Add(Me.txtReferenceLine)
        Me.Controls.Add(Me.txtReferenceNumber)
        Me.Controls.Add(Me.txtExtendedCost)
        Me.Controls.Add(Me.txtSteelCost)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSteelTransactionKey)
        Me.Controls.Add(Me.cmdGenerateTransactionNumber)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdAddSteelTransaction)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Name = "SteelTransactionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Steel Transaction"
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRMID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionMath As System.Windows.Forms.ComboBox
    Friend WithEvents txtReferenceLine As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelCost As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSteelTransactionKey As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateTransactionNumber As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAddSteelTransaction As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTransactionType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
