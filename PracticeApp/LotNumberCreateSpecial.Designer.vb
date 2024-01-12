<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotNumberCreateSpecial
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLotSuffix = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtFOXNumber = New System.Windows.Forms.TextBox
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.txtShortDescription = New System.Windows.Forms.TextBox
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.txtSteelCarbon = New System.Windows.Forms.TextBox
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.txtSteelVendor = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdCreateNew = New System.Windows.Forms.Button
        Me.txtLotComment = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(592, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 521)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(126, 52)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(153, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(76, 88)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(203, 21)
        Me.cboLotNumber.TabIndex = 4
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lot #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "FOX #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotSuffix
        '
        Me.txtLotSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotSuffix.Location = New System.Drawing.Point(20, 54)
        Me.txtLotSuffix.MaxLength = 4
        Me.txtLotSuffix.Name = "txtLotSuffix"
        Me.txtLotSuffix.Size = New System.Drawing.Size(103, 20)
        Me.txtLotSuffix.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(239, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Lot # Suffix (4 characters MAX)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 356)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Heat #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 511)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Steel Vendor"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 452)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Steel Size"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 398)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Steel Carbon/Alloy"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXNumber
        '
        Me.txtFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXNumber.Location = New System.Drawing.Point(126, 132)
        Me.txtFOXNumber.Name = "txtFOXNumber"
        Me.txtFOXNumber.ReadOnly = True
        Me.txtFOXNumber.Size = New System.Drawing.Size(153, 20)
        Me.txtFOXNumber.TabIndex = 15
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(59, 176)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(220, 20)
        Me.txtPartNumber.TabIndex = 16
        '
        'txtShortDescription
        '
        Me.txtShortDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShortDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShortDescription.Location = New System.Drawing.Point(12, 241)
        Me.txtShortDescription.Multiline = True
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.ReadOnly = True
        Me.txtShortDescription.Size = New System.Drawing.Size(264, 83)
        Me.txtShortDescription.TabIndex = 17
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Location = New System.Drawing.Point(126, 356)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.ReadOnly = True
        Me.txtHeatNumber.Size = New System.Drawing.Size(153, 20)
        Me.txtHeatNumber.TabIndex = 18
        '
        'txtSteelCarbon
        '
        Me.txtSteelCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelCarbon.Location = New System.Drawing.Point(15, 424)
        Me.txtSteelCarbon.Name = "txtSteelCarbon"
        Me.txtSteelCarbon.ReadOnly = True
        Me.txtSteelCarbon.Size = New System.Drawing.Size(264, 20)
        Me.txtSteelCarbon.TabIndex = 19
        '
        'txtSteelSize
        '
        Me.txtSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSize.Location = New System.Drawing.Point(15, 479)
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.ReadOnly = True
        Me.txtSteelSize.Size = New System.Drawing.Size(264, 20)
        Me.txtSteelSize.TabIndex = 20
        '
        'txtSteelVendor
        '
        Me.txtSteelVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelVendor.Location = New System.Drawing.Point(15, 534)
        Me.txtSteelVendor.Name = "txtSteelVendor"
        Me.txtSteelVendor.ReadOnly = True
        Me.txtSteelVendor.Size = New System.Drawing.Size(264, 20)
        Me.txtSteelVendor.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmdCreateNew)
        Me.GroupBox1.Controls.Add(Me.txtLotComment)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtLotSuffix)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(300, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 447)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create New Lot # "
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 372)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 60)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "This process will create a new Lot # with all of the old Lot #'s data and will up" & _
            "date the comment field."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCreateNew
        '
        Me.cmdCreateNew.Location = New System.Drawing.Point(188, 383)
        Me.cmdCreateNew.Name = "cmdCreateNew"
        Me.cmdCreateNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateNew.TabIndex = 11
        Me.cmdCreateNew.Text = "Create New"
        Me.cmdCreateNew.UseVisualStyleBackColor = True
        '
        'txtLotComment
        '
        Me.txtLotComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotComment.Location = New System.Drawing.Point(20, 117)
        Me.txtLotComment.MaxLength = 200
        Me.txtLotComment.Multiline = True
        Me.txtLotComment.Name = "txtLotComment"
        Me.txtLotComment.Size = New System.Drawing.Size(239, 243)
        Me.txtLotComment.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(239, 23)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Comments (200 Characters MAX)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(431, 521)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 23
        Me.cmdClear.Text = "ClearFields"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'LotNumberCreateSpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 573)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSteelVendor)
        Me.Controls.Add(Me.txtSteelSize)
        Me.Controls.Add(Me.txtSteelCarbon)
        Me.Controls.Add(Me.txtHeatNumber)
        Me.Controls.Add(Me.txtShortDescription)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.txtFOXNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboLotNumber)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "LotNumberCreateSpecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Create Special Lot Number"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLotSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFOXNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtShortDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelVendor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLotComment As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdCreateNew As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
End Class
