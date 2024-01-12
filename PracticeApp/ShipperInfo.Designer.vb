<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipperInfo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShipperInfo))
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboShipperID = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxShipperInfo = New System.Windows.Forms.GroupBox
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShipMethodType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkAddToVendor = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.txtShipperName = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtZipCode = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvShipMethod = New System.Windows.Forms.DataGridView
        Me.ShipMethIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhoneColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZipCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethDescColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipperInfo.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(961, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(807, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 14
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(884, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(27, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 20)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Shipper Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 20)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Division ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Address 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Ship Via"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipperID
        '
        Me.cboShipperID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipperID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipperID.DataSource = Me.ShipMethodBindingSource
        Me.cboShipperID.DisplayMember = "ShipMethID"
        Me.cboShipperID.FormattingEnabled = True
        Me.cboShipperID.Location = New System.Drawing.Point(97, 46)
        Me.cboShipperID.MaxLength = 50
        Me.cboShipperID.Name = "cboShipperID"
        Me.cboShipperID.Size = New System.Drawing.Size(204, 21)
        Me.cboShipperID.TabIndex = 1
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxShipperInfo
        '
        Me.gpxShipperInfo.Controls.Add(Me.cboState)
        Me.gpxShipperInfo.Controls.Add(Me.cboShipMethodType)
        Me.gpxShipperInfo.Controls.Add(Me.Label3)
        Me.gpxShipperInfo.Controls.Add(Me.chkAddToVendor)
        Me.gpxShipperInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxShipperInfo.Controls.Add(Me.cmdClear)
        Me.gpxShipperInfo.Controls.Add(Me.cmdEnter)
        Me.gpxShipperInfo.Controls.Add(Me.cboShipperID)
        Me.gpxShipperInfo.Controls.Add(Me.Label10)
        Me.gpxShipperInfo.Controls.Add(Me.txtShipperName)
        Me.gpxShipperInfo.Controls.Add(Me.txtEmail)
        Me.gpxShipperInfo.Controls.Add(Me.txtFax)
        Me.gpxShipperInfo.Controls.Add(Me.txtPhone)
        Me.gpxShipperInfo.Controls.Add(Me.txtZipCode)
        Me.gpxShipperInfo.Controls.Add(Me.txtCity)
        Me.gpxShipperInfo.Controls.Add(Me.txtAddress2)
        Me.gpxShipperInfo.Controls.Add(Me.txtAddress1)
        Me.gpxShipperInfo.Controls.Add(Me.Label18)
        Me.gpxShipperInfo.Controls.Add(Me.Label17)
        Me.gpxShipperInfo.Controls.Add(Me.Label13)
        Me.gpxShipperInfo.Controls.Add(Me.Label14)
        Me.gpxShipperInfo.Controls.Add(Me.Label6)
        Me.gpxShipperInfo.Controls.Add(Me.Label7)
        Me.gpxShipperInfo.Controls.Add(Me.Label5)
        Me.gpxShipperInfo.Controls.Add(Me.Label11)
        Me.gpxShipperInfo.Controls.Add(Me.Label1)
        Me.gpxShipperInfo.Controls.Add(Me.Label9)
        Me.gpxShipperInfo.Location = New System.Drawing.Point(21, 39)
        Me.gpxShipperInfo.Name = "gpxShipperInfo"
        Me.gpxShipperInfo.Size = New System.Drawing.Size(320, 772)
        Me.gpxShipperInfo.TabIndex = 0
        Me.gpxShipperInfo.TabStop = False
        Me.gpxShipperInfo.Text = "Shipper Info"
        '
        'cboState
        '
        Me.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.DisplayMember = "StateCode"
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(156, 407)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(145, 21)
        Me.cboState.TabIndex = 6
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShipMethodType
        '
        Me.cboShipMethodType.FormattingEnabled = True
        Me.cboShipMethodType.Items.AddRange(New Object() {"SP", "LTL", "FULL", "CONTAINER", "OTHER"})
        Me.cboShipMethodType.Location = New System.Drawing.Point(113, 540)
        Me.cboShipMethodType.Name = "cboShipMethodType"
        Me.cboShipMethodType.Size = New System.Drawing.Size(188, 21)
        Me.cboShipMethodType.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 540)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 20)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Ship Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAddToVendor
        '
        Me.chkAddToVendor.AutoSize = True
        Me.chkAddToVendor.Location = New System.Drawing.Point(33, 690)
        Me.chkAddToVendor.Name = "chkAddToVendor"
        Me.chkAddToVendor.Size = New System.Drawing.Size(153, 17)
        Me.chkAddToVendor.TabIndex = 12
        Me.chkAddToVendor.Text = "Add to Division Vendor List"
        Me.chkAddToVendor.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(97, 19)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(204, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(233, 716)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnter
        '
        Me.cmdEnter.ForeColor = System.Drawing.Color.Black
        Me.cmdEnter.Location = New System.Drawing.Point(156, 716)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 13
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'txtShipperName
        '
        Me.txtShipperName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipperName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipperName.Location = New System.Drawing.Point(30, 97)
        Me.txtShipperName.Multiline = True
        Me.txtShipperName.Name = "txtShipperName"
        Me.txtShipperName.Size = New System.Drawing.Size(271, 60)
        Me.txtShipperName.TabIndex = 2
        Me.txtShipperName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(30, 603)
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(271, 68)
        Me.txtEmail.TabIndex = 11
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFax.Location = New System.Drawing.Point(113, 507)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(188, 20)
        Me.txtFax.TabIndex = 9
        Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhone.Location = New System.Drawing.Point(113, 474)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(188, 20)
        Me.txtPhone.TabIndex = 8
        Me.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtZipCode
        '
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZipCode.Location = New System.Drawing.Point(113, 441)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(188, 20)
        Me.txtZipCode.TabIndex = 7
        Me.txtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(74, 374)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(227, 20)
        Me.txtCity.TabIndex = 5
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(30, 284)
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(271, 67)
        Me.txtAddress2.TabIndex = 4
        Me.txtAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(30, 194)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(271, 67)
        Me.txtAddress1.TabIndex = 3
        Me.txtAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(30, 580)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 20)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Email Address"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(30, 408)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 20)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "State"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(30, 507)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Fax Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(30, 474)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 20)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Phone Number"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 441)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Zip Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(30, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "City"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Address 2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipMethod
        '
        Me.dgvShipMethod.AllowUserToAddRows = False
        Me.dgvShipMethod.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipMethod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipMethod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipMethod.AutoGenerateColumns = False
        Me.dgvShipMethod.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipMethod.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipMethod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipMethIDColumn, Me.PhoneColumn, Me.FaxColumn, Me.EmailColumn, Me.ShipMethodTypeColumn, Me.Address1Column, Me.Address2Column, Me.CityColumn, Me.StateColumn, Me.ZipCodeColumn, Me.ShipMethDescColumn, Me.DivisionIDColumn})
        Me.dgvShipMethod.DataSource = Me.ShipMethodBindingSource
        Me.dgvShipMethod.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipMethod.Location = New System.Drawing.Point(361, 39)
        Me.dgvShipMethod.Name = "dgvShipMethod"
        Me.dgvShipMethod.Size = New System.Drawing.Size(671, 707)
        Me.dgvShipMethod.TabIndex = 22
        Me.dgvShipMethod.TabStop = False
        '
        'ShipMethIDColumn
        '
        Me.ShipMethIDColumn.DataPropertyName = "ShipMethID"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShipMethIDColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ShipMethIDColumn.HeaderText = "Ship Via"
        Me.ShipMethIDColumn.Name = "ShipMethIDColumn"
        Me.ShipMethIDColumn.Width = 200
        '
        'PhoneColumn
        '
        Me.PhoneColumn.DataPropertyName = "Phone"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhoneColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PhoneColumn.HeaderText = "Phone"
        Me.PhoneColumn.Name = "PhoneColumn"
        Me.PhoneColumn.Width = 180
        '
        'FaxColumn
        '
        Me.FaxColumn.DataPropertyName = "Fax"
        Me.FaxColumn.HeaderText = "Fax"
        Me.FaxColumn.Name = "FaxColumn"
        '
        'EmailColumn
        '
        Me.EmailColumn.DataPropertyName = "Email"
        Me.EmailColumn.HeaderText = "Email"
        Me.EmailColumn.Name = "EmailColumn"
        '
        'ShipMethodTypeColumn
        '
        Me.ShipMethodTypeColumn.DataPropertyName = "ShipMethodType"
        Me.ShipMethodTypeColumn.HeaderText = "Type"
        Me.ShipMethodTypeColumn.Name = "ShipMethodTypeColumn"
        '
        'Address1Column
        '
        Me.Address1Column.DataPropertyName = "Address1"
        Me.Address1Column.HeaderText = "Address1"
        Me.Address1Column.Name = "Address1Column"
        '
        'Address2Column
        '
        Me.Address2Column.DataPropertyName = "Address2"
        Me.Address2Column.HeaderText = "Address2"
        Me.Address2Column.Name = "Address2Column"
        '
        'CityColumn
        '
        Me.CityColumn.DataPropertyName = "City"
        Me.CityColumn.HeaderText = "City"
        Me.CityColumn.Name = "CityColumn"
        '
        'StateColumn
        '
        Me.StateColumn.DataPropertyName = "State"
        Me.StateColumn.HeaderText = "State"
        Me.StateColumn.Name = "StateColumn"
        '
        'ZipCodeColumn
        '
        Me.ZipCodeColumn.DataPropertyName = "ZipCode"
        Me.ZipCodeColumn.HeaderText = "ZipCode"
        Me.ZipCodeColumn.Name = "ZipCodeColumn"
        '
        'ShipMethDescColumn
        '
        Me.ShipMethDescColumn.DataPropertyName = "ShipMethDesc"
        Me.ShipMethDescColumn.HeaderText = "Description"
        Me.ShipMethDescColumn.Name = "ShipMethDescColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(358, 751)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(366, 60)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipperInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvShipMethod)
        Me.Controls.Add(Me.gpxShipperInfo)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipperInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipper Information"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipperInfo.ResumeLayout(False)
        Me.gpxShipperInfo.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShipperID As System.Windows.Forms.ComboBox
    Friend WithEvents gpxShipperInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvShipMethod As System.Windows.Forms.DataGridView
    Friend WithEvents txtShipperName As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents chkAddToVendor As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboShipMethodType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShipMethIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZipCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethDescColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
