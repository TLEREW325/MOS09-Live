<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlueprintJournal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveJournalEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBlueprint = New System.Windows.Forms.ComboBox
        Me.lstJournalEntries = New System.Windows.Forms.ListBox
        Me.dgvPictureList = New System.Windows.Forms.DataGridView
        Me.Picture = New System.Windows.Forms.DataGridViewImageColumn
        Me.tabCtrlLogs = New System.Windows.Forms.TabControl
        Me.tabJournal = New System.Windows.Forms.TabPage
        Me.cmdFullScreenJournal = New System.Windows.Forms.Button
        Me.cmdPrintJournalImage = New System.Windows.Forms.Button
        Me.hscrlJournalPicture = New System.Windows.Forms.HScrollBar
        Me.vscrlJournalPicture = New System.Windows.Forms.VScrollBar
        Me.picbxJournalPicture = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdEditSelected = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdAddEntry = New System.Windows.Forms.Button
        Me.lblLastUpdated = New System.Windows.Forms.Label
        Me.lblDateEntered = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDetails = New System.Windows.Forms.Label
        Me.tabNonConformance = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdFullScreenNonConformancePicture = New System.Windows.Forms.Button
        Me.cmdPrintNonConformancePicture = New System.Windows.Forms.Button
        Me.hscrlNonConformancePicture = New System.Windows.Forms.HScrollBar
        Me.vscrlNonConformancePicture = New System.Windows.Forms.VScrollBar
        Me.picbxNonConformancePicture = New System.Windows.Forms.PictureBox
        Me.dgvNonConformancePictures = New System.Windows.Forms.DataGridView
        Me.Pictures = New System.Windows.Forms.DataGridViewImageColumn
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblNonConformanceComment = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblNonConformanceReworkInstructions = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblNonConformanceReason = New System.Windows.Forms.Label
        Me.lblNonConformancePartDescription = New System.Windows.Forms.Label
        Me.lblNonConformancePartNumber = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblNonConformanceFOXNumber = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblNonConformanceLotNumber = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblNonConformanceDate = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lstNonConformanceEntries = New System.Windows.Forms.ListBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvPictureList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCtrlLogs.SuspendLayout()
        Me.tabJournal.SuspendLayout()
        CType(Me.picbxJournalPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNonConformance.SuspendLayout()
        CType(Me.picbxNonConformancePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNonConformancePictures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveJournalEntryToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RemoveJournalEntryToolStripMenuItem
        '
        Me.RemoveJournalEntryToolStripMenuItem.Enabled = False
        Me.RemoveJournalEntryToolStripMenuItem.Name = "RemoveJournalEntryToolStripMenuItem"
        Me.RemoveJournalEntryToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoveJournalEntryToolStripMenuItem.Text = "Remove Journal Entry"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Blueprint"
        '
        'cboBlueprint
        '
        Me.cboBlueprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprint.FormattingEnabled = True
        Me.cboBlueprint.Location = New System.Drawing.Point(66, 39)
        Me.cboBlueprint.Name = "cboBlueprint"
        Me.cboBlueprint.Size = New System.Drawing.Size(121, 21)
        Me.cboBlueprint.TabIndex = 2
        '
        'lstJournalEntries
        '
        Me.lstJournalEntries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstJournalEntries.FormattingEnabled = True
        Me.lstJournalEntries.Location = New System.Drawing.Point(6, 32)
        Me.lstJournalEntries.Name = "lstJournalEntries"
        Me.lstJournalEntries.Size = New System.Drawing.Size(206, 524)
        Me.lstJournalEntries.TabIndex = 3
        '
        'dgvPictureList
        '
        Me.dgvPictureList.AllowUserToAddRows = False
        Me.dgvPictureList.AllowUserToDeleteRows = False
        Me.dgvPictureList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPictureList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPictureList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPictureList.ColumnHeadersVisible = False
        Me.dgvPictureList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Picture})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPictureList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPictureList.Location = New System.Drawing.Point(816, 32)
        Me.dgvPictureList.Name = "dgvPictureList"
        Me.dgvPictureList.ReadOnly = True
        Me.dgvPictureList.RowHeadersVisible = False
        Me.dgvPictureList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPictureList.Size = New System.Drawing.Size(179, 524)
        Me.dgvPictureList.TabIndex = 4
        '
        'Picture
        '
        Me.Picture.HeaderText = "Picture"
        Me.Picture.Name = "Picture"
        Me.Picture.ReadOnly = True
        '
        'tabCtrlLogs
        '
        Me.tabCtrlLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrlLogs.Controls.Add(Me.tabJournal)
        Me.tabCtrlLogs.Controls.Add(Me.tabNonConformance)
        Me.tabCtrlLogs.ItemSize = New System.Drawing.Size(46, 18)
        Me.tabCtrlLogs.Location = New System.Drawing.Point(13, 70)
        Me.tabCtrlLogs.Name = "tabCtrlLogs"
        Me.tabCtrlLogs.SelectedIndex = 0
        Me.tabCtrlLogs.Size = New System.Drawing.Size(1009, 633)
        Me.tabCtrlLogs.TabIndex = 6
        '
        'tabJournal
        '
        Me.tabJournal.BackColor = System.Drawing.SystemColors.Control
        Me.tabJournal.Controls.Add(Me.cmdFullScreenJournal)
        Me.tabJournal.Controls.Add(Me.cmdPrintJournalImage)
        Me.tabJournal.Controls.Add(Me.hscrlJournalPicture)
        Me.tabJournal.Controls.Add(Me.vscrlJournalPicture)
        Me.tabJournal.Controls.Add(Me.picbxJournalPicture)
        Me.tabJournal.Controls.Add(Me.Label9)
        Me.tabJournal.Controls.Add(Me.cmdEditSelected)
        Me.tabJournal.Controls.Add(Me.Label6)
        Me.tabJournal.Controls.Add(Me.cmdAddEntry)
        Me.tabJournal.Controls.Add(Me.lblLastUpdated)
        Me.tabJournal.Controls.Add(Me.lblDateEntered)
        Me.tabJournal.Controls.Add(Me.Label5)
        Me.tabJournal.Controls.Add(Me.Label4)
        Me.tabJournal.Controls.Add(Me.Label3)
        Me.tabJournal.Controls.Add(Me.Label2)
        Me.tabJournal.Controls.Add(Me.lblDetails)
        Me.tabJournal.Controls.Add(Me.lstJournalEntries)
        Me.tabJournal.Controls.Add(Me.dgvPictureList)
        Me.tabJournal.Location = New System.Drawing.Point(4, 22)
        Me.tabJournal.Name = "tabJournal"
        Me.tabJournal.Padding = New System.Windows.Forms.Padding(3)
        Me.tabJournal.Size = New System.Drawing.Size(1001, 607)
        Me.tabJournal.TabIndex = 0
        Me.tabJournal.Text = "Journal"
        '
        'cmdFullScreenJournal
        '
        Me.cmdFullScreenJournal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFullScreenJournal.Location = New System.Drawing.Point(924, 559)
        Me.cmdFullScreenJournal.Name = "cmdFullScreenJournal"
        Me.cmdFullScreenJournal.Size = New System.Drawing.Size(71, 40)
        Me.cmdFullScreenJournal.TabIndex = 20
        Me.cmdFullScreenJournal.Text = "Full Screen"
        Me.cmdFullScreenJournal.UseVisualStyleBackColor = True
        '
        'cmdPrintJournalImage
        '
        Me.cmdPrintJournalImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintJournalImage.Location = New System.Drawing.Point(816, 559)
        Me.cmdPrintJournalImage.Name = "cmdPrintJournalImage"
        Me.cmdPrintJournalImage.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintJournalImage.TabIndex = 19
        Me.cmdPrintJournalImage.Text = "Print Selected"
        Me.cmdPrintJournalImage.UseVisualStyleBackColor = True
        '
        'hscrlJournalPicture
        '
        Me.hscrlJournalPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hscrlJournalPicture.Location = New System.Drawing.Point(221, 582)
        Me.hscrlJournalPicture.Name = "hscrlJournalPicture"
        Me.hscrlJournalPicture.Size = New System.Drawing.Size(569, 17)
        Me.hscrlJournalPicture.TabIndex = 18
        '
        'vscrlJournalPicture
        '
        Me.vscrlJournalPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vscrlJournalPicture.Location = New System.Drawing.Point(793, 162)
        Me.vscrlJournalPicture.Name = "vscrlJournalPicture"
        Me.vscrlJournalPicture.Size = New System.Drawing.Size(17, 417)
        Me.vscrlJournalPicture.TabIndex = 17
        '
        'picbxJournalPicture
        '
        Me.picbxJournalPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picbxJournalPicture.Location = New System.Drawing.Point(221, 162)
        Me.picbxJournalPicture.Name = "picbxJournalPicture"
        Me.picbxJournalPicture.Size = New System.Drawing.Size(569, 417)
        Me.picbxJournalPicture.TabIndex = 6
        Me.picbxJournalPicture.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(218, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Selected Image"
        '
        'cmdEditSelected
        '
        Me.cmdEditSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEditSelected.Enabled = False
        Me.cmdEditSelected.Location = New System.Drawing.Point(141, 561)
        Me.cmdEditSelected.Name = "cmdEditSelected"
        Me.cmdEditSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdEditSelected.TabIndex = 10
        Me.cmdEditSelected.Text = "Edit Entry"
        Me.cmdEditSelected.UseVisualStyleBackColor = True
        Me.cmdEditSelected.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(813, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Picture List:"
        '
        'cmdAddEntry
        '
        Me.cmdAddEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddEntry.Location = New System.Drawing.Point(6, 561)
        Me.cmdAddEntry.Name = "cmdAddEntry"
        Me.cmdAddEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddEntry.TabIndex = 8
        Me.cmdAddEntry.Text = "Add Entry"
        Me.cmdAddEntry.UseVisualStyleBackColor = True
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLastUpdated.Location = New System.Drawing.Point(687, 16)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(112, 13)
        Me.lblLastUpdated.TabIndex = 14
        '
        'lblDateEntered
        '
        Me.lblDateEntered.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDateEntered.Location = New System.Drawing.Point(489, 16)
        Me.lblDateEntered.Name = "lblDateEntered"
        Me.lblDateEntered.Size = New System.Drawing.Size(112, 13)
        Me.lblDateEntered.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(607, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Last Updated:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(410, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Date Entered:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(215, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Entries"
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDetails.Location = New System.Drawing.Point(218, 32)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(592, 107)
        Me.lblDetails.TabIndex = 8
        '
        'tabNonConformance
        '
        Me.tabNonConformance.BackColor = System.Drawing.SystemColors.Control
        Me.tabNonConformance.Controls.Add(Me.Label16)
        Me.tabNonConformance.Controls.Add(Me.cmdFullScreenNonConformancePicture)
        Me.tabNonConformance.Controls.Add(Me.cmdPrintNonConformancePicture)
        Me.tabNonConformance.Controls.Add(Me.hscrlNonConformancePicture)
        Me.tabNonConformance.Controls.Add(Me.vscrlNonConformancePicture)
        Me.tabNonConformance.Controls.Add(Me.picbxNonConformancePicture)
        Me.tabNonConformance.Controls.Add(Me.dgvNonConformancePictures)
        Me.tabNonConformance.Controls.Add(Me.Label15)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceComment)
        Me.tabNonConformance.Controls.Add(Me.Label14)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceReworkInstructions)
        Me.tabNonConformance.Controls.Add(Me.Label13)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceReason)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformancePartDescription)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformancePartNumber)
        Me.tabNonConformance.Controls.Add(Me.Label12)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceFOXNumber)
        Me.tabNonConformance.Controls.Add(Me.Label11)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceLotNumber)
        Me.tabNonConformance.Controls.Add(Me.Label10)
        Me.tabNonConformance.Controls.Add(Me.lblNonConformanceDate)
        Me.tabNonConformance.Controls.Add(Me.Label8)
        Me.tabNonConformance.Controls.Add(Me.Label7)
        Me.tabNonConformance.Controls.Add(Me.lstNonConformanceEntries)
        Me.tabNonConformance.Location = New System.Drawing.Point(4, 22)
        Me.tabNonConformance.Name = "tabNonConformance"
        Me.tabNonConformance.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNonConformance.Size = New System.Drawing.Size(1001, 607)
        Me.tabNonConformance.TabIndex = 1
        Me.tabNonConformance.Text = "Non-Conformance Entries"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(813, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Picture List:"
        '
        'cmdFullScreenNonConformancePicture
        '
        Me.cmdFullScreenNonConformancePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFullScreenNonConformancePicture.Location = New System.Drawing.Point(924, 554)
        Me.cmdFullScreenNonConformancePicture.Name = "cmdFullScreenNonConformancePicture"
        Me.cmdFullScreenNonConformancePicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdFullScreenNonConformancePicture.TabIndex = 30
        Me.cmdFullScreenNonConformancePicture.Text = "Full Screen"
        Me.cmdFullScreenNonConformancePicture.UseVisualStyleBackColor = True
        '
        'cmdPrintNonConformancePicture
        '
        Me.cmdPrintNonConformancePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintNonConformancePicture.Location = New System.Drawing.Point(816, 554)
        Me.cmdPrintNonConformancePicture.Name = "cmdPrintNonConformancePicture"
        Me.cmdPrintNonConformancePicture.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintNonConformancePicture.TabIndex = 29
        Me.cmdPrintNonConformancePicture.Text = "Print Selected"
        Me.cmdPrintNonConformancePicture.UseVisualStyleBackColor = True
        '
        'hscrlNonConformancePicture
        '
        Me.hscrlNonConformancePicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hscrlNonConformancePicture.Location = New System.Drawing.Point(137, 571)
        Me.hscrlNonConformancePicture.Name = "hscrlNonConformancePicture"
        Me.hscrlNonConformancePicture.Size = New System.Drawing.Size(626, 17)
        Me.hscrlNonConformancePicture.TabIndex = 28
        '
        'vscrlNonConformancePicture
        '
        Me.vscrlNonConformancePicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vscrlNonConformancePicture.Location = New System.Drawing.Point(767, 334)
        Me.vscrlNonConformancePicture.Name = "vscrlNonConformancePicture"
        Me.vscrlNonConformancePicture.Size = New System.Drawing.Size(17, 234)
        Me.vscrlNonConformancePicture.TabIndex = 27
        '
        'picbxNonConformancePicture
        '
        Me.picbxNonConformancePicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picbxNonConformancePicture.Location = New System.Drawing.Point(134, 334)
        Me.picbxNonConformancePicture.Name = "picbxNonConformancePicture"
        Me.picbxNonConformancePicture.Size = New System.Drawing.Size(629, 234)
        Me.picbxNonConformancePicture.TabIndex = 6
        Me.picbxNonConformancePicture.TabStop = False
        '
        'dgvNonConformancePictures
        '
        Me.dgvNonConformancePictures.AllowUserToAddRows = False
        Me.dgvNonConformancePictures.AllowUserToDeleteRows = False
        Me.dgvNonConformancePictures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNonConformancePictures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvNonConformancePictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNonConformancePictures.ColumnHeadersVisible = False
        Me.dgvNonConformancePictures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pictures})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNonConformancePictures.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNonConformancePictures.Location = New System.Drawing.Point(816, 86)
        Me.dgvNonConformancePictures.Name = "dgvNonConformancePictures"
        Me.dgvNonConformancePictures.ReadOnly = True
        Me.dgvNonConformancePictures.RowHeadersVisible = False
        Me.dgvNonConformancePictures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvNonConformancePictures.Size = New System.Drawing.Size(179, 462)
        Me.dgvNonConformancePictures.TabIndex = 26
        '
        'Pictures
        '
        Me.Pictures.HeaderText = "Pictures"
        Me.Pictures.Name = "Pictures"
        Me.Pictures.ReadOnly = True
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(134, 253)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Comment"
        '
        'lblNonConformanceComment
        '
        Me.lblNonConformanceComment.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNonConformanceComment.Location = New System.Drawing.Point(134, 266)
        Me.lblNonConformanceComment.Name = "lblNonConformanceComment"
        Me.lblNonConformanceComment.Size = New System.Drawing.Size(650, 65)
        Me.lblNonConformanceComment.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(134, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Rework Instructions"
        '
        'lblNonConformanceReworkInstructions
        '
        Me.lblNonConformanceReworkInstructions.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceReworkInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNonConformanceReworkInstructions.Location = New System.Drawing.Point(134, 174)
        Me.lblNonConformanceReworkInstructions.Name = "lblNonConformanceReworkInstructions"
        Me.lblNonConformanceReworkInstructions.Size = New System.Drawing.Size(650, 65)
        Me.lblNonConformanceReworkInstructions.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(134, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Reason"
        '
        'lblNonConformanceReason
        '
        Me.lblNonConformanceReason.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNonConformanceReason.Location = New System.Drawing.Point(134, 86)
        Me.lblNonConformanceReason.Name = "lblNonConformanceReason"
        Me.lblNonConformanceReason.Size = New System.Drawing.Size(650, 65)
        Me.lblNonConformanceReason.TabIndex = 20
        '
        'lblNonConformancePartDescription
        '
        Me.lblNonConformancePartDescription.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformancePartDescription.Location = New System.Drawing.Point(657, 32)
        Me.lblNonConformancePartDescription.Name = "lblNonConformancePartDescription"
        Me.lblNonConformancePartDescription.Size = New System.Drawing.Size(338, 41)
        Me.lblNonConformancePartDescription.TabIndex = 19
        '
        'lblNonConformancePartNumber
        '
        Me.lblNonConformancePartNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformancePartNumber.Location = New System.Drawing.Point(734, 16)
        Me.lblNonConformancePartNumber.Name = "lblNonConformancePartNumber"
        Me.lblNonConformancePartNumber.Size = New System.Drawing.Size(231, 13)
        Me.lblNonConformancePartNumber.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(657, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Part Number:"
        '
        'lblNonConformanceFOXNumber
        '
        Me.lblNonConformanceFOXNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceFOXNumber.Location = New System.Drawing.Point(548, 16)
        Me.lblNonConformanceFOXNumber.Name = "lblNonConformanceFOXNumber"
        Me.lblNonConformanceFOXNumber.Size = New System.Drawing.Size(103, 13)
        Me.lblNonConformanceFOXNumber.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(471, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "FOX Number:"
        '
        'lblNonConformanceLotNumber
        '
        Me.lblNonConformanceLotNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceLotNumber.Location = New System.Drawing.Point(299, 32)
        Me.lblNonConformanceLotNumber.Name = "lblNonConformanceLotNumber"
        Me.lblNonConformanceLotNumber.Size = New System.Drawing.Size(166, 41)
        Me.lblNonConformanceLotNumber.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(296, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Lot Number:"
        '
        'lblNonConformanceDate
        '
        Me.lblNonConformanceDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNonConformanceDate.Location = New System.Drawing.Point(197, 16)
        Me.lblNonConformanceDate.Name = "lblNonConformanceDate"
        Me.lblNonConformanceDate.Size = New System.Drawing.Size(93, 13)
        Me.lblNonConformanceDate.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(131, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Entry Date:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Entries"
        '
        'lstNonConformanceEntries
        '
        Me.lstNonConformanceEntries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstNonConformanceEntries.FormattingEnabled = True
        Me.lstNonConformanceEntries.Location = New System.Drawing.Point(6, 32)
        Me.lstNonConformanceEntries.Name = "lstNonConformanceEntries"
        Me.lstNonConformanceEntries.Size = New System.Drawing.Size(99, 550)
        Me.lstNonConformanceEntries.TabIndex = 4
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(947, 709)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(200, 24)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'BlueprintJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 761)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tabCtrlLogs)
        Me.Controls.Add(Me.cboBlueprint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BlueprintJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Blueprint Journal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvPictureList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCtrlLogs.ResumeLayout(False)
        Me.tabJournal.ResumeLayout(False)
        Me.tabJournal.PerformLayout()
        CType(Me.picbxJournalPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNonConformance.ResumeLayout(False)
        Me.tabNonConformance.PerformLayout()
        CType(Me.picbxNonConformancePicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNonConformancePictures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBlueprint As System.Windows.Forms.ComboBox
    Friend WithEvents lstJournalEntries As System.Windows.Forms.ListBox
    Friend WithEvents dgvPictureList As System.Windows.Forms.DataGridView
    Friend WithEvents tabCtrlLogs As System.Windows.Forms.TabControl
    Friend WithEvents tabJournal As System.Windows.Forms.TabPage
    Friend WithEvents picbxJournalPicture As System.Windows.Forms.PictureBox
    Friend WithEvents tabNonConformance As System.Windows.Forms.TabPage
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents lblDateEntered As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstNonConformanceEntries As System.Windows.Forms.ListBox
    Friend WithEvents lblNonConformanceLotNumber As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformanceDate As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformancePartNumber As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformanceFOXNumber As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformanceComment As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformanceReworkInstructions As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblNonConformanceReason As System.Windows.Forms.Label
    Friend WithEvents lblNonConformancePartDescription As System.Windows.Forms.Label
    Friend WithEvents dgvNonConformancePictures As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAddEntry As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Picture As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdEditSelected As System.Windows.Forms.Button
    Friend WithEvents picbxNonConformancePicture As System.Windows.Forms.PictureBox
    Friend WithEvents vscrlJournalPicture As System.Windows.Forms.VScrollBar
    Friend WithEvents hscrlJournalPicture As System.Windows.Forms.HScrollBar
    Friend WithEvents cmdFullScreenJournal As System.Windows.Forms.Button
    Friend WithEvents cmdPrintJournalImage As System.Windows.Forms.Button
    Friend WithEvents hscrlNonConformancePicture As System.Windows.Forms.HScrollBar
    Friend WithEvents vscrlNonConformancePicture As System.Windows.Forms.VScrollBar
    Friend WithEvents cmdFullScreenNonConformancePicture As System.Windows.Forms.Button
    Friend WithEvents cmdPrintNonConformancePicture As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveJournalEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pictures As System.Windows.Forms.DataGridViewImageColumn
End Class
