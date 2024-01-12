<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelCreator
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveLabelAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxProperties = New System.Windows.Forms.GroupBox
        Me.pnlText = New System.Windows.Forms.Panel
        Me.cboFontStyle = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.chkEditable = New System.Windows.Forms.CheckBox
        Me.txtFontSize = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtText = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlBarcode = New System.Windows.Forms.Panel
        Me.chkUnderlayText = New System.Windows.Forms.CheckBox
        Me.txtBarcodeHeight = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtBarcodeValue = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.pnlImage = New System.Windows.Forms.Panel
        Me.cmdSelectPicture = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtImageHeight = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtImageWidth = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.pnlLine = New System.Windows.Forms.Panel
        Me.txtLineLength = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtLineWidth = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRotation = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtYPos = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtXPos = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFieldType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFieldName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdNewField = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.lblLabelFields = New System.Windows.Forms.Label
        Me.cboFields = New System.Windows.Forms.ComboBox
        Me.nbrCopies = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPrintLabel = New System.Windows.Forms.Button
        Me.picbxLabel = New System.Windows.Forms.PictureBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPrint = New System.Windows.Forms.GroupBox
        Me.lblHighlightedField = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxProperties.SuspendLayout()
        Me.pnlText.SuspendLayout()
        Me.pnlBarcode.SuspendLayout()
        Me.pnlImage.SuspendLayout()
        Me.pnlLine.SuspendLayout()
        CType(Me.nbrCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picbxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(977, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewLabelToolStripMenuItem, Me.LoadLabelToolStripMenuItem, Me.SaveLabelToolStripMenuItem, Me.SaveLabelAsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewLabelToolStripMenuItem
        '
        Me.NewLabelToolStripMenuItem.Name = "NewLabelToolStripMenuItem"
        Me.NewLabelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewLabelToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NewLabelToolStripMenuItem.Text = "New Label"
        '
        'LoadLabelToolStripMenuItem
        '
        Me.LoadLabelToolStripMenuItem.Name = "LoadLabelToolStripMenuItem"
        Me.LoadLabelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LoadLabelToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.LoadLabelToolStripMenuItem.Text = "Load Label"
        '
        'SaveLabelToolStripMenuItem
        '
        Me.SaveLabelToolStripMenuItem.Name = "SaveLabelToolStripMenuItem"
        Me.SaveLabelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveLabelToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SaveLabelToolStripMenuItem.Text = "Save Label"
        '
        'SaveLabelAsToolStripMenuItem
        '
        Me.SaveLabelAsToolStripMenuItem.Name = "SaveLabelAsToolStripMenuItem"
        Me.SaveLabelAsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SaveLabelAsToolStripMenuItem.Text = "Save Label As"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
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
        'gpxProperties
        '
        Me.gpxProperties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxProperties.Controls.Add(Me.pnlText)
        Me.gpxProperties.Controls.Add(Me.pnlBarcode)
        Me.gpxProperties.Controls.Add(Me.pnlImage)
        Me.gpxProperties.Controls.Add(Me.pnlLine)
        Me.gpxProperties.Controls.Add(Me.txtRotation)
        Me.gpxProperties.Controls.Add(Me.Label5)
        Me.gpxProperties.Controls.Add(Me.txtYPos)
        Me.gpxProperties.Controls.Add(Me.Label4)
        Me.gpxProperties.Controls.Add(Me.txtXPos)
        Me.gpxProperties.Controls.Add(Me.Label3)
        Me.gpxProperties.Controls.Add(Me.cboFieldType)
        Me.gpxProperties.Controls.Add(Me.Label2)
        Me.gpxProperties.Controls.Add(Me.txtFieldName)
        Me.gpxProperties.Controls.Add(Me.Label1)
        Me.gpxProperties.Controls.Add(Me.cmdNewField)
        Me.gpxProperties.Controls.Add(Me.cmdDelete)
        Me.gpxProperties.Controls.Add(Me.lblLabelFields)
        Me.gpxProperties.Controls.Add(Me.cboFields)
        Me.gpxProperties.Location = New System.Drawing.Point(632, 45)
        Me.gpxProperties.Name = "gpxProperties"
        Me.gpxProperties.Size = New System.Drawing.Size(333, 454)
        Me.gpxProperties.TabIndex = 2
        Me.gpxProperties.TabStop = False
        Me.gpxProperties.Text = "Properties"
        '
        'pnlText
        '
        Me.pnlText.Controls.Add(Me.cboFontStyle)
        Me.pnlText.Controls.Add(Me.Label16)
        Me.pnlText.Controls.Add(Me.chkEditable)
        Me.pnlText.Controls.Add(Me.txtFontSize)
        Me.pnlText.Controls.Add(Me.Label7)
        Me.pnlText.Controls.Add(Me.txtText)
        Me.pnlText.Controls.Add(Me.Label6)
        Me.pnlText.Location = New System.Drawing.Point(7, 266)
        Me.pnlText.Name = "pnlText"
        Me.pnlText.Size = New System.Drawing.Size(323, 134)
        Me.pnlText.TabIndex = 30
        Me.pnlText.Visible = False
        '
        'cboFontStyle
        '
        Me.cboFontStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFontStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFontStyle.FormattingEnabled = True
        Me.cboFontStyle.Items.AddRange(New Object() {"Bold", "Italic", "Normal"})
        Me.cboFontStyle.Location = New System.Drawing.Point(81, 102)
        Me.cboFontStyle.Name = "cboFontStyle"
        Me.cboFontStyle.Size = New System.Drawing.Size(136, 21)
        Me.cboFontStyle.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 106)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Font Style"
        '
        'chkEditable
        '
        Me.chkEditable.AutoSize = True
        Me.chkEditable.Location = New System.Drawing.Point(249, 102)
        Me.chkEditable.Name = "chkEditable"
        Me.chkEditable.Size = New System.Drawing.Size(66, 17)
        Me.chkEditable.TabIndex = 35
        Me.chkEditable.Text = "Can Edit"
        Me.chkEditable.UseVisualStyleBackColor = True
        '
        'txtFontSize
        '
        Me.txtFontSize.Location = New System.Drawing.Point(179, 12)
        Me.txtFontSize.MaxLength = 3
        Me.txtFontSize.Name = "txtFontSize"
        Me.txtFontSize.Size = New System.Drawing.Size(136, 20)
        Me.txtFontSize.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Font Size"
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(64, 47)
        Me.txtText.MaxLength = 500
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(251, 49)
        Me.txtText.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Text"
        '
        'pnlBarcode
        '
        Me.pnlBarcode.Controls.Add(Me.chkUnderlayText)
        Me.pnlBarcode.Controls.Add(Me.txtBarcodeHeight)
        Me.pnlBarcode.Controls.Add(Me.Label14)
        Me.pnlBarcode.Controls.Add(Me.txtBarcodeValue)
        Me.pnlBarcode.Controls.Add(Me.Label15)
        Me.pnlBarcode.Location = New System.Drawing.Point(6, 266)
        Me.pnlBarcode.Name = "pnlBarcode"
        Me.pnlBarcode.Size = New System.Drawing.Size(323, 134)
        Me.pnlBarcode.TabIndex = 35
        Me.pnlBarcode.Visible = False
        '
        'chkUnderlayText
        '
        Me.chkUnderlayText.AutoSize = True
        Me.chkUnderlayText.Location = New System.Drawing.Point(224, 96)
        Me.chkUnderlayText.Name = "chkUnderlayText"
        Me.chkUnderlayText.Size = New System.Drawing.Size(92, 17)
        Me.chkUnderlayText.TabIndex = 36
        Me.chkUnderlayText.Text = "Underlay Text"
        Me.chkUnderlayText.UseVisualStyleBackColor = True
        '
        'txtBarcodeHeight
        '
        Me.txtBarcodeHeight.Location = New System.Drawing.Point(180, 21)
        Me.txtBarcodeHeight.MaxLength = 3
        Me.txtBarcodeHeight.Name = "txtBarcodeHeight"
        Me.txtBarcodeHeight.Size = New System.Drawing.Size(136, 20)
        Me.txtBarcodeHeight.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Barcode Height"
        '
        'txtBarcodeValue
        '
        Me.txtBarcodeValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcodeValue.Location = New System.Drawing.Point(65, 60)
        Me.txtBarcodeValue.MaxLength = 50
        Me.txtBarcodeValue.Name = "txtBarcodeValue"
        Me.txtBarcodeValue.Size = New System.Drawing.Size(251, 20)
        Me.txtBarcodeValue.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Text"
        '
        'pnlImage
        '
        Me.pnlImage.Controls.Add(Me.cmdSelectPicture)
        Me.pnlImage.Controls.Add(Me.Label13)
        Me.pnlImage.Controls.Add(Me.txtImageHeight)
        Me.pnlImage.Controls.Add(Me.Label11)
        Me.pnlImage.Controls.Add(Me.txtImageWidth)
        Me.pnlImage.Controls.Add(Me.Label12)
        Me.pnlImage.Location = New System.Drawing.Point(7, 266)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(323, 134)
        Me.pnlImage.TabIndex = 36
        Me.pnlImage.Visible = False
        '
        'cmdSelectPicture
        '
        Me.cmdSelectPicture.Location = New System.Drawing.Point(244, 73)
        Me.cmdSelectPicture.Name = "cmdSelectPicture"
        Me.cmdSelectPicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectPicture.TabIndex = 38
        Me.cmdSelectPicture.Text = "Select File"
        Me.cmdSelectPicture.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Picture File"
        '
        'txtImageHeight
        '
        Me.txtImageHeight.Location = New System.Drawing.Point(179, 12)
        Me.txtImageHeight.MaxLength = 3
        Me.txtImageHeight.Name = "txtImageHeight"
        Me.txtImageHeight.Size = New System.Drawing.Size(136, 20)
        Me.txtImageHeight.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Height"
        '
        'txtImageWidth
        '
        Me.txtImageWidth.Location = New System.Drawing.Point(179, 47)
        Me.txtImageWidth.MaxLength = 500
        Me.txtImageWidth.Name = "txtImageWidth"
        Me.txtImageWidth.Size = New System.Drawing.Size(136, 20)
        Me.txtImageWidth.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Width"
        '
        'pnlLine
        '
        Me.pnlLine.Controls.Add(Me.txtLineLength)
        Me.pnlLine.Controls.Add(Me.Label8)
        Me.pnlLine.Controls.Add(Me.txtLineWidth)
        Me.pnlLine.Controls.Add(Me.Label9)
        Me.pnlLine.Location = New System.Drawing.Point(7, 266)
        Me.pnlLine.Name = "pnlLine"
        Me.pnlLine.Size = New System.Drawing.Size(323, 134)
        Me.pnlLine.TabIndex = 35
        Me.pnlLine.Visible = False
        '
        'txtLineLength
        '
        Me.txtLineLength.Location = New System.Drawing.Point(179, 12)
        Me.txtLineLength.MaxLength = 3
        Me.txtLineLength.Name = "txtLineLength"
        Me.txtLineLength.Size = New System.Drawing.Size(136, 20)
        Me.txtLineLength.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Length"
        '
        'txtLineWidth
        '
        Me.txtLineWidth.Location = New System.Drawing.Point(179, 47)
        Me.txtLineWidth.MaxLength = 500
        Me.txtLineWidth.Name = "txtLineWidth"
        Me.txtLineWidth.Size = New System.Drawing.Size(136, 20)
        Me.txtLineWidth.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Width"
        '
        'txtRotation
        '
        Me.txtRotation.Location = New System.Drawing.Point(186, 225)
        Me.txtRotation.MaxLength = 3
        Me.txtRotation.Name = "txtRotation"
        Me.txtRotation.Size = New System.Drawing.Size(136, 20)
        Me.txtRotation.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Rotation (in degrees)"
        '
        'txtYPos
        '
        Me.txtYPos.Location = New System.Drawing.Point(186, 190)
        Me.txtYPos.MaxLength = 3
        Me.txtYPos.Name = "txtYPos"
        Me.txtYPos.Size = New System.Drawing.Size(136, 20)
        Me.txtYPos.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Position from Top (0-400)"
        '
        'txtXPos
        '
        Me.txtXPos.Location = New System.Drawing.Point(186, 154)
        Me.txtXPos.MaxLength = 3
        Me.txtXPos.Name = "txtXPos"
        Me.txtXPos.Size = New System.Drawing.Size(136, 20)
        Me.txtXPos.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Position from Left (0-600)"
        '
        'cboFieldType
        '
        Me.cboFieldType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFieldType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFieldType.FormattingEnabled = True
        Me.cboFieldType.Items.AddRange(New Object() {"Barcode", "Line", "Picture", "Text"})
        Me.cboFieldType.Location = New System.Drawing.Point(186, 114)
        Me.cboFieldType.Name = "cboFieldType"
        Me.cboFieldType.Size = New System.Drawing.Size(136, 21)
        Me.cboFieldType.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Field Type"
        '
        'txtFieldName
        '
        Me.txtFieldName.Location = New System.Drawing.Point(125, 68)
        Me.txtFieldName.MaxLength = 50
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.Size = New System.Drawing.Size(197, 20)
        Me.txtFieldName.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Field Name"
        '
        'cmdNewField
        '
        Me.cmdNewField.ForeColor = System.Drawing.Color.Red
        Me.cmdNewField.Location = New System.Drawing.Point(57, 21)
        Me.cmdNewField.Name = "cmdNewField"
        Me.cmdNewField.Size = New System.Drawing.Size(31, 23)
        Me.cmdNewField.TabIndex = 19
        Me.cmdNewField.Text = ">>"
        Me.cmdNewField.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(256, 408)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete Field"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'lblLabelFields
        '
        Me.lblLabelFields.AutoSize = True
        Me.lblLabelFields.Location = New System.Drawing.Point(22, 26)
        Me.lblLabelFields.Name = "lblLabelFields"
        Me.lblLabelFields.Size = New System.Drawing.Size(29, 13)
        Me.lblLabelFields.TabIndex = 1
        Me.lblLabelFields.Text = "Field"
        '
        'cboFields
        '
        Me.cboFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFields.FormattingEnabled = True
        Me.cboFields.Location = New System.Drawing.Point(125, 19)
        Me.cboFields.Name = "cboFields"
        Me.cboFields.Size = New System.Drawing.Size(197, 21)
        Me.cboFields.TabIndex = 0
        '
        'nbrCopies
        '
        Me.nbrCopies.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nbrCopies.Location = New System.Drawing.Point(90, 31)
        Me.nbrCopies.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nbrCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrCopies.Name = "nbrCopies"
        Me.nbrCopies.Size = New System.Drawing.Size(109, 20)
        Me.nbrCopies.TabIndex = 37
        Me.nbrCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbrCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Label Copies"
        '
        'cmdPrintLabel
        '
        Me.cmdPrintLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintLabel.Location = New System.Drawing.Point(217, 19)
        Me.cmdPrintLabel.Name = "cmdPrintLabel"
        Me.cmdPrintLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintLabel.TabIndex = 18
        Me.cmdPrintLabel.Text = "Print Label"
        Me.cmdPrintLabel.UseVisualStyleBackColor = True
        '
        'picbxLabel
        '
        Me.picbxLabel.BackColor = System.Drawing.Color.White
        Me.picbxLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picbxLabel.Location = New System.Drawing.Point(12, 45)
        Me.picbxLabel.Name = "picbxLabel"
        Me.picbxLabel.Size = New System.Drawing.Size(600, 400)
        Me.picbxLabel.TabIndex = 19
        Me.picbxLabel.TabStop = False
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(734, 505)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 20
        Me.cmdSave.Text = "Save Label"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(657, 505)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoad.TabIndex = 21
        Me.cmdLoad.Text = "Load Label"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(811, 505)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 36
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(888, 505)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 37
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxPrint
        '
        Me.gpxPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.gpxPrint.Controls.Add(Me.cmdPrintLabel)
        Me.gpxPrint.Controls.Add(Me.nbrCopies)
        Me.gpxPrint.Controls.Add(Me.Label10)
        Me.gpxPrint.Location = New System.Drawing.Point(318, 470)
        Me.gpxPrint.Name = "gpxPrint"
        Me.gpxPrint.Size = New System.Drawing.Size(294, 75)
        Me.gpxPrint.TabIndex = 38
        Me.gpxPrint.TabStop = False
        Me.gpxPrint.Text = "Print"
        '
        'lblHighlightedField
        '
        Me.lblHighlightedField.AutoSize = True
        Me.lblHighlightedField.ForeColor = System.Drawing.Color.Blue
        Me.lblHighlightedField.Location = New System.Drawing.Point(42, 489)
        Me.lblHighlightedField.Name = "lblHighlightedField"
        Me.lblHighlightedField.Size = New System.Drawing.Size(188, 13)
        Me.lblHighlightedField.TabIndex = 39
        Me.lblHighlightedField.Text = "Red field is the currently selected field."
        '
        'LabelCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 557)
        Me.Controls.Add(Me.lblHighlightedField)
        Me.Controls.Add(Me.gpxPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.picbxLabel)
        Me.Controls.Add(Me.gpxProperties)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(879, 305)
        Me.Name = "LabelCreator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Label Creator"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxProperties.ResumeLayout(False)
        Me.gpxProperties.PerformLayout()
        Me.pnlText.ResumeLayout(False)
        Me.pnlText.PerformLayout()
        Me.pnlBarcode.ResumeLayout(False)
        Me.pnlBarcode.PerformLayout()
        Me.pnlImage.ResumeLayout(False)
        Me.pnlImage.PerformLayout()
        Me.pnlLine.ResumeLayout(False)
        Me.pnlLine.PerformLayout()
        CType(Me.nbrCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picbxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPrint.ResumeLayout(False)
        Me.gpxPrint.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents gpxProperties As System.Windows.Forms.GroupBox
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLabelFields As System.Windows.Forms.Label
    Friend WithEvents cboFields As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrintLabel As System.Windows.Forms.Button
    Friend WithEvents picbxLabel As System.Windows.Forms.PictureBox
    Friend WithEvents cmdNewField As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFieldName As System.Windows.Forms.TextBox
    Friend WithEvents cboFieldType As System.Windows.Forms.ComboBox
    Friend WithEvents txtYPos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtXPos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlText As System.Windows.Forms.Panel
    Friend WithEvents txtRotation As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFontSize As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlLine As System.Windows.Forms.Panel
    Friend WithEvents txtLineLength As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLineWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SaveLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents nbrCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents cmdSelectPicture As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtImageHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtImageWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SaveLabelAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxPrint As System.Windows.Forms.GroupBox
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlBarcode As System.Windows.Forms.Panel
    Friend WithEvents txtBarcodeHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkUnderlayText As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditable As System.Windows.Forms.CheckBox
    Friend WithEvents cboFontStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblHighlightedField As System.Windows.Forms.Label
    Friend WithEvents NewLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
