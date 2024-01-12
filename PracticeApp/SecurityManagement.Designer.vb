<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecurityManagement
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxSecurityEntry = New System.Windows.Forms.GroupBox
        Me.cboEmployeeName = New System.Windows.Forms.ComboBox
        Me.cmdShowHideHierarchy = New System.Windows.Forms.Button
        Me.cboColumn = New System.Windows.Forms.ComboBox
        Me.lblColumn = New System.Windows.Forms.Label
        Me.cboSecurityID = New System.Windows.Forms.ComboBox
        Me.lblSecurityID = New System.Windows.Forms.Label
        Me.cboValue = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProperty = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cboControls = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboForm = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.cboSecurityFor = New System.Windows.Forms.ComboBox
        Me.lblEmployeeID = New System.Windows.Forms.Label
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxCopyEntries = New System.Windows.Forms.GroupBox
        Me.cboToSecurityID = New System.Windows.Forms.ComboBox
        Me.lblToSecurityID = New System.Windows.Forms.Label
        Me.cboFromSecurityID = New System.Windows.Forms.ComboBox
        Me.lblFromSecurityID = New System.Windows.Forms.Label
        Me.cboToDivisionID = New System.Windows.Forms.ComboBox
        Me.lblToDivisionID = New System.Windows.Forms.Label
        Me.cboFromDivisionID = New System.Windows.Forms.ComboBox
        Me.lblFromDivisionID = New System.Windows.Forms.Label
        Me.cboCopyForm = New System.Windows.Forms.ComboBox
        Me.lblCopyForm = New System.Windows.Forms.Label
        Me.cboToEmployeeID = New System.Windows.Forms.ComboBox
        Me.lblToEmployeeID = New System.Windows.Forms.Label
        Me.cboFromEmployeeID = New System.Windows.Forms.ComboBox
        Me.lblFromEmployeeID = New System.Windows.Forms.Label
        Me.cboCopySecurityFor = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdCopyClear = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.tabCtrlPermissions = New System.Windows.Forms.TabControl
        Me.tabSecurityPermissions = New System.Windows.Forms.TabPage
        Me.dgvSecurityPermissions = New System.Windows.Forms.DataGridView
        Me.tabDivisionPermissions = New System.Windows.Forms.TabPage
        Me.dgvDivisionPermissions = New System.Windows.Forms.DataGridView
        Me.tabEmployeePermissions = New System.Windows.Forms.TabPage
        Me.dgvEmployeePermissions = New System.Windows.Forms.DataGridView
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.trvCtrlHierarchy = New System.Windows.Forms.TreeView
        Me.gpxSecurityEntry.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gpxCopyEntries.SuspendLayout()
        Me.tabCtrlPermissions.SuspendLayout()
        Me.tabSecurityPermissions.SuspendLayout()
        CType(Me.dgvSecurityPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDivisionPermissions.SuspendLayout()
        CType(Me.dgvDivisionPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmployeePermissions.SuspendLayout()
        CType(Me.dgvEmployeePermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Security for:"
        '
        'gpxSecurityEntry
        '
        Me.gpxSecurityEntry.Controls.Add(Me.cboEmployeeName)
        Me.gpxSecurityEntry.Controls.Add(Me.cmdShowHideHierarchy)
        Me.gpxSecurityEntry.Controls.Add(Me.cboColumn)
        Me.gpxSecurityEntry.Controls.Add(Me.lblColumn)
        Me.gpxSecurityEntry.Controls.Add(Me.cboSecurityID)
        Me.gpxSecurityEntry.Controls.Add(Me.lblSecurityID)
        Me.gpxSecurityEntry.Controls.Add(Me.cboValue)
        Me.gpxSecurityEntry.Controls.Add(Me.Label5)
        Me.gpxSecurityEntry.Controls.Add(Me.cboProperty)
        Me.gpxSecurityEntry.Controls.Add(Me.Label4)
        Me.gpxSecurityEntry.Controls.Add(Me.cmdClear)
        Me.gpxSecurityEntry.Controls.Add(Me.cboEmployeeID)
        Me.gpxSecurityEntry.Controls.Add(Me.cmdAdd)
        Me.gpxSecurityEntry.Controls.Add(Me.cboControls)
        Me.gpxSecurityEntry.Controls.Add(Me.Label3)
        Me.gpxSecurityEntry.Controls.Add(Me.cboForm)
        Me.gpxSecurityEntry.Controls.Add(Me.Label2)
        Me.gpxSecurityEntry.Controls.Add(Me.cboDivisionID)
        Me.gpxSecurityEntry.Controls.Add(Me.cboSecurityFor)
        Me.gpxSecurityEntry.Controls.Add(Me.Label1)
        Me.gpxSecurityEntry.Controls.Add(Me.lblEmployeeID)
        Me.gpxSecurityEntry.Controls.Add(Me.lblDivisionID)
        Me.gpxSecurityEntry.Location = New System.Drawing.Point(12, 40)
        Me.gpxSecurityEntry.Name = "gpxSecurityEntry"
        Me.gpxSecurityEntry.Size = New System.Drawing.Size(254, 416)
        Me.gpxSecurityEntry.TabIndex = 0
        Me.gpxSecurityEntry.TabStop = False
        Me.gpxSecurityEntry.Text = "Security Entry"
        '
        'cboEmployeeName
        '
        Me.cboEmployeeName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeName.FormattingEnabled = True
        Me.cboEmployeeName.Location = New System.Drawing.Point(9, 87)
        Me.cboEmployeeName.Name = "cboEmployeeName"
        Me.cboEmployeeName.Size = New System.Drawing.Size(239, 21)
        Me.cboEmployeeName.TabIndex = 2
        Me.cboEmployeeName.Visible = False
        '
        'cmdShowHideHierarchy
        '
        Me.cmdShowHideHierarchy.Location = New System.Drawing.Point(155, 225)
        Me.cmdShowHideHierarchy.Name = "cmdShowHideHierarchy"
        Me.cmdShowHideHierarchy.Size = New System.Drawing.Size(93, 24)
        Me.cmdShowHideHierarchy.TabIndex = 19
        Me.cmdShowHideHierarchy.Text = "Show Hierarchy"
        Me.cmdShowHideHierarchy.UseVisualStyleBackColor = True
        '
        'cboColumn
        '
        Me.cboColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboColumn.FormattingEnabled = True
        Me.cboColumn.Location = New System.Drawing.Point(59, 198)
        Me.cboColumn.Name = "cboColumn"
        Me.cboColumn.Size = New System.Drawing.Size(189, 21)
        Me.cboColumn.TabIndex = 5
        Me.cboColumn.Visible = False
        '
        'lblColumn
        '
        Me.lblColumn.AutoSize = True
        Me.lblColumn.Location = New System.Drawing.Point(6, 201)
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(42, 13)
        Me.lblColumn.TabIndex = 18
        Me.lblColumn.Text = "Column"
        Me.lblColumn.Visible = False
        '
        'cboSecurityID
        '
        Me.cboSecurityID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSecurityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSecurityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSecurityID.FormattingEnabled = True
        Me.cboSecurityID.Location = New System.Drawing.Point(108, 60)
        Me.cboSecurityID.Name = "cboSecurityID"
        Me.cboSecurityID.Size = New System.Drawing.Size(140, 21)
        Me.cboSecurityID.TabIndex = 1
        Me.cboSecurityID.Visible = False
        '
        'lblSecurityID
        '
        Me.lblSecurityID.AutoSize = True
        Me.lblSecurityID.Location = New System.Drawing.Point(6, 63)
        Me.lblSecurityID.Name = "lblSecurityID"
        Me.lblSecurityID.Size = New System.Drawing.Size(59, 13)
        Me.lblSecurityID.TabIndex = 16
        Me.lblSecurityID.Text = "Security ID"
        Me.lblSecurityID.Visible = False
        '
        'cboValue
        '
        Me.cboValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValue.FormattingEnabled = True
        Me.cboValue.Items.AddRange(New Object() {"True", "False"})
        Me.cboValue.Location = New System.Drawing.Point(108, 305)
        Me.cboValue.Name = "cboValue"
        Me.cboValue.Size = New System.Drawing.Size(140, 21)
        Me.cboValue.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Value"
        '
        'cboProperty
        '
        Me.cboProperty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProperty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProperty.FormattingEnabled = True
        Me.cboProperty.Items.AddRange(New Object() {"Enabled", "ReadOnly", "Visible", "Text"})
        Me.cboProperty.Location = New System.Drawing.Point(108, 256)
        Me.cboProperty.Name = "cboProperty"
        Me.cboProperty.Size = New System.Drawing.Size(140, 21)
        Me.cboProperty.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Property"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(177, 344)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(108, 60)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(140, 21)
        Me.cboEmployeeID.TabIndex = 1
        Me.cboEmployeeID.Visible = False
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(100, 344)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cboControls
        '
        Me.cboControls.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboControls.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboControls.FormattingEnabled = True
        Me.cboControls.Location = New System.Drawing.Point(59, 171)
        Me.cboControls.Name = "cboControls"
        Me.cboControls.Size = New System.Drawing.Size(189, 21)
        Me.cboControls.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Controls"
        '
        'cboForm
        '
        Me.cboForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboForm.FormattingEnabled = True
        Me.cboForm.Location = New System.Drawing.Point(59, 127)
        Me.cboForm.Name = "cboForm"
        Me.cboForm.Size = New System.Drawing.Size(189, 21)
        Me.cboForm.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Form"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(108, 60)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(140, 21)
        Me.cboDivisionID.TabIndex = 1
        Me.cboDivisionID.Visible = False
        '
        'cboSecurityFor
        '
        Me.cboSecurityFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSecurityFor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSecurityFor.FormattingEnabled = True
        Me.cboSecurityFor.Items.AddRange(New Object() {"Division", "Employee", "Security Level"})
        Me.cboSecurityFor.Location = New System.Drawing.Point(78, 19)
        Me.cboSecurityFor.Name = "cboSecurityFor"
        Me.cboSecurityFor.Size = New System.Drawing.Size(170, 21)
        Me.cboSecurityFor.TabIndex = 0
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(6, 63)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(67, 13)
        Me.lblEmployeeID.TabIndex = 9
        Me.lblEmployeeID.Text = "Employee ID"
        Me.lblEmployeeID.Visible = False
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(6, 63)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(58, 13)
        Me.lblDivisionID.TabIndex = 2
        Me.lblDivisionID.Text = "Division ID"
        Me.lblDivisionID.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FielToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FielToolStripMenuItem
        '
        Me.FielToolStripMenuItem.Name = "FielToolStripMenuItem"
        Me.FielToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FielToolStripMenuItem.Text = "File"
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
        'gpxCopyEntries
        '
        Me.gpxCopyEntries.Controls.Add(Me.cboToSecurityID)
        Me.gpxCopyEntries.Controls.Add(Me.lblToSecurityID)
        Me.gpxCopyEntries.Controls.Add(Me.cboFromSecurityID)
        Me.gpxCopyEntries.Controls.Add(Me.lblFromSecurityID)
        Me.gpxCopyEntries.Controls.Add(Me.cboToDivisionID)
        Me.gpxCopyEntries.Controls.Add(Me.lblToDivisionID)
        Me.gpxCopyEntries.Controls.Add(Me.cboFromDivisionID)
        Me.gpxCopyEntries.Controls.Add(Me.lblFromDivisionID)
        Me.gpxCopyEntries.Controls.Add(Me.cboCopyForm)
        Me.gpxCopyEntries.Controls.Add(Me.lblCopyForm)
        Me.gpxCopyEntries.Controls.Add(Me.cboToEmployeeID)
        Me.gpxCopyEntries.Controls.Add(Me.lblToEmployeeID)
        Me.gpxCopyEntries.Controls.Add(Me.cboFromEmployeeID)
        Me.gpxCopyEntries.Controls.Add(Me.lblFromEmployeeID)
        Me.gpxCopyEntries.Controls.Add(Me.cboCopySecurityFor)
        Me.gpxCopyEntries.Controls.Add(Me.Label6)
        Me.gpxCopyEntries.Controls.Add(Me.cmdCopyClear)
        Me.gpxCopyEntries.Controls.Add(Me.cmdCopy)
        Me.gpxCopyEntries.Location = New System.Drawing.Point(12, 462)
        Me.gpxCopyEntries.Name = "gpxCopyEntries"
        Me.gpxCopyEntries.Size = New System.Drawing.Size(254, 237)
        Me.gpxCopyEntries.TabIndex = 1
        Me.gpxCopyEntries.TabStop = False
        Me.gpxCopyEntries.Text = "Copy Entries"
        '
        'cboToSecurityID
        '
        Me.cboToSecurityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToSecurityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToSecurityID.FormattingEnabled = True
        Me.cboToSecurityID.Location = New System.Drawing.Point(108, 99)
        Me.cboToSecurityID.Name = "cboToSecurityID"
        Me.cboToSecurityID.Size = New System.Drawing.Size(140, 21)
        Me.cboToSecurityID.TabIndex = 2
        Me.cboToSecurityID.Visible = False
        '
        'lblToSecurityID
        '
        Me.lblToSecurityID.AutoSize = True
        Me.lblToSecurityID.Location = New System.Drawing.Point(6, 102)
        Me.lblToSecurityID.Name = "lblToSecurityID"
        Me.lblToSecurityID.Size = New System.Drawing.Size(75, 13)
        Me.lblToSecurityID.TabIndex = 26
        Me.lblToSecurityID.Text = "To Security ID"
        Me.lblToSecurityID.Visible = False
        '
        'cboFromSecurityID
        '
        Me.cboFromSecurityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFromSecurityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFromSecurityID.FormattingEnabled = True
        Me.cboFromSecurityID.Location = New System.Drawing.Point(108, 72)
        Me.cboFromSecurityID.Name = "cboFromSecurityID"
        Me.cboFromSecurityID.Size = New System.Drawing.Size(140, 21)
        Me.cboFromSecurityID.TabIndex = 1
        Me.cboFromSecurityID.Visible = False
        '
        'lblFromSecurityID
        '
        Me.lblFromSecurityID.AutoSize = True
        Me.lblFromSecurityID.Location = New System.Drawing.Point(6, 75)
        Me.lblFromSecurityID.Name = "lblFromSecurityID"
        Me.lblFromSecurityID.Size = New System.Drawing.Size(85, 13)
        Me.lblFromSecurityID.TabIndex = 24
        Me.lblFromSecurityID.Text = "From Security ID"
        Me.lblFromSecurityID.Visible = False
        '
        'cboToDivisionID
        '
        Me.cboToDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToDivisionID.FormattingEnabled = True
        Me.cboToDivisionID.Location = New System.Drawing.Point(108, 99)
        Me.cboToDivisionID.Name = "cboToDivisionID"
        Me.cboToDivisionID.Size = New System.Drawing.Size(140, 21)
        Me.cboToDivisionID.TabIndex = 2
        Me.cboToDivisionID.Visible = False
        '
        'lblToDivisionID
        '
        Me.lblToDivisionID.AutoSize = True
        Me.lblToDivisionID.Location = New System.Drawing.Point(6, 102)
        Me.lblToDivisionID.Name = "lblToDivisionID"
        Me.lblToDivisionID.Size = New System.Drawing.Size(74, 13)
        Me.lblToDivisionID.TabIndex = 22
        Me.lblToDivisionID.Text = "To Division ID"
        Me.lblToDivisionID.Visible = False
        '
        'cboFromDivisionID
        '
        Me.cboFromDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFromDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFromDivisionID.FormattingEnabled = True
        Me.cboFromDivisionID.Location = New System.Drawing.Point(108, 72)
        Me.cboFromDivisionID.Name = "cboFromDivisionID"
        Me.cboFromDivisionID.Size = New System.Drawing.Size(140, 21)
        Me.cboFromDivisionID.TabIndex = 1
        Me.cboFromDivisionID.Visible = False
        '
        'lblFromDivisionID
        '
        Me.lblFromDivisionID.AutoSize = True
        Me.lblFromDivisionID.Location = New System.Drawing.Point(6, 75)
        Me.lblFromDivisionID.Name = "lblFromDivisionID"
        Me.lblFromDivisionID.Size = New System.Drawing.Size(84, 13)
        Me.lblFromDivisionID.TabIndex = 20
        Me.lblFromDivisionID.Text = "From Division ID"
        Me.lblFromDivisionID.Visible = False
        '
        'cboCopyForm
        '
        Me.cboCopyForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCopyForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCopyForm.FormattingEnabled = True
        Me.cboCopyForm.Location = New System.Drawing.Point(78, 140)
        Me.cboCopyForm.Name = "cboCopyForm"
        Me.cboCopyForm.Size = New System.Drawing.Size(170, 21)
        Me.cboCopyForm.TabIndex = 3
        '
        'lblCopyForm
        '
        Me.lblCopyForm.AutoSize = True
        Me.lblCopyForm.Location = New System.Drawing.Point(6, 143)
        Me.lblCopyForm.Name = "lblCopyForm"
        Me.lblCopyForm.Size = New System.Drawing.Size(30, 13)
        Me.lblCopyForm.TabIndex = 16
        Me.lblCopyForm.Text = "Form"
        '
        'cboToEmployeeID
        '
        Me.cboToEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToEmployeeID.FormattingEnabled = True
        Me.cboToEmployeeID.Location = New System.Drawing.Point(108, 99)
        Me.cboToEmployeeID.Name = "cboToEmployeeID"
        Me.cboToEmployeeID.Size = New System.Drawing.Size(140, 21)
        Me.cboToEmployeeID.TabIndex = 2
        Me.cboToEmployeeID.Visible = False
        '
        'lblToEmployeeID
        '
        Me.lblToEmployeeID.AutoSize = True
        Me.lblToEmployeeID.Location = New System.Drawing.Point(6, 102)
        Me.lblToEmployeeID.Name = "lblToEmployeeID"
        Me.lblToEmployeeID.Size = New System.Drawing.Size(83, 13)
        Me.lblToEmployeeID.TabIndex = 18
        Me.lblToEmployeeID.Text = "To Employee ID"
        Me.lblToEmployeeID.Visible = False
        '
        'cboFromEmployeeID
        '
        Me.cboFromEmployeeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFromEmployeeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFromEmployeeID.FormattingEnabled = True
        Me.cboFromEmployeeID.Location = New System.Drawing.Point(108, 72)
        Me.cboFromEmployeeID.Name = "cboFromEmployeeID"
        Me.cboFromEmployeeID.Size = New System.Drawing.Size(140, 21)
        Me.cboFromEmployeeID.TabIndex = 1
        Me.cboFromEmployeeID.Visible = False
        '
        'lblFromEmployeeID
        '
        Me.lblFromEmployeeID.AutoSize = True
        Me.lblFromEmployeeID.Location = New System.Drawing.Point(6, 75)
        Me.lblFromEmployeeID.Name = "lblFromEmployeeID"
        Me.lblFromEmployeeID.Size = New System.Drawing.Size(93, 13)
        Me.lblFromEmployeeID.TabIndex = 16
        Me.lblFromEmployeeID.Text = "From Employee ID"
        Me.lblFromEmployeeID.Visible = False
        '
        'cboCopySecurityFor
        '
        Me.cboCopySecurityFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCopySecurityFor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCopySecurityFor.FormattingEnabled = True
        Me.cboCopySecurityFor.Items.AddRange(New Object() {"Division", "Employee", "Security Level"})
        Me.cboCopySecurityFor.Location = New System.Drawing.Point(108, 31)
        Me.cboCopySecurityFor.Name = "cboCopySecurityFor"
        Me.cboCopySecurityFor.Size = New System.Drawing.Size(140, 21)
        Me.cboCopySecurityFor.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Security for:"
        '
        'cmdCopyClear
        '
        Me.cmdCopyClear.Location = New System.Drawing.Point(177, 180)
        Me.cmdCopyClear.Name = "cmdCopyClear"
        Me.cmdCopyClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdCopyClear.TabIndex = 5
        Me.cmdCopyClear.Text = "Clear"
        Me.cmdCopyClear.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(100, 180)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(71, 40)
        Me.cmdCopy.TabIndex = 4
        Me.cmdCopy.Text = "Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'tabCtrlPermissions
        '
        Me.tabCtrlPermissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrlPermissions.Controls.Add(Me.tabSecurityPermissions)
        Me.tabCtrlPermissions.Controls.Add(Me.tabDivisionPermissions)
        Me.tabCtrlPermissions.Controls.Add(Me.tabEmployeePermissions)
        Me.tabCtrlPermissions.Location = New System.Drawing.Point(272, 27)
        Me.tabCtrlPermissions.Name = "tabCtrlPermissions"
        Me.tabCtrlPermissions.SelectedIndex = 0
        Me.tabCtrlPermissions.Size = New System.Drawing.Size(770, 784)
        Me.tabCtrlPermissions.TabIndex = 2
        '
        'tabSecurityPermissions
        '
        Me.tabSecurityPermissions.BackColor = System.Drawing.SystemColors.Control
        Me.tabSecurityPermissions.Controls.Add(Me.dgvSecurityPermissions)
        Me.tabSecurityPermissions.Location = New System.Drawing.Point(4, 22)
        Me.tabSecurityPermissions.Name = "tabSecurityPermissions"
        Me.tabSecurityPermissions.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSecurityPermissions.Size = New System.Drawing.Size(762, 758)
        Me.tabSecurityPermissions.TabIndex = 0
        Me.tabSecurityPermissions.Text = "Security Permissions"
        '
        'dgvSecurityPermissions
        '
        Me.dgvSecurityPermissions.AllowUserToAddRows = False
        Me.dgvSecurityPermissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecurityPermissions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSecurityPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecurityPermissions.Location = New System.Drawing.Point(6, 6)
        Me.dgvSecurityPermissions.Name = "dgvSecurityPermissions"
        Me.dgvSecurityPermissions.Size = New System.Drawing.Size(753, 700)
        Me.dgvSecurityPermissions.TabIndex = 0
        '
        'tabDivisionPermissions
        '
        Me.tabDivisionPermissions.BackColor = System.Drawing.SystemColors.Control
        Me.tabDivisionPermissions.Controls.Add(Me.dgvDivisionPermissions)
        Me.tabDivisionPermissions.Location = New System.Drawing.Point(4, 22)
        Me.tabDivisionPermissions.Name = "tabDivisionPermissions"
        Me.tabDivisionPermissions.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDivisionPermissions.Size = New System.Drawing.Size(762, 758)
        Me.tabDivisionPermissions.TabIndex = 1
        Me.tabDivisionPermissions.Text = "Division Permissions"
        '
        'dgvDivisionPermissions
        '
        Me.dgvDivisionPermissions.AllowUserToAddRows = False
        Me.dgvDivisionPermissions.AllowUserToDeleteRows = False
        Me.dgvDivisionPermissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDivisionPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDivisionPermissions.Location = New System.Drawing.Point(5, 6)
        Me.dgvDivisionPermissions.Name = "dgvDivisionPermissions"
        Me.dgvDivisionPermissions.Size = New System.Drawing.Size(745, 588)
        Me.dgvDivisionPermissions.TabIndex = 29
        '
        'tabEmployeePermissions
        '
        Me.tabEmployeePermissions.BackColor = System.Drawing.SystemColors.Control
        Me.tabEmployeePermissions.Controls.Add(Me.dgvEmployeePermissions)
        Me.tabEmployeePermissions.Location = New System.Drawing.Point(4, 22)
        Me.tabEmployeePermissions.Name = "tabEmployeePermissions"
        Me.tabEmployeePermissions.Size = New System.Drawing.Size(762, 758)
        Me.tabEmployeePermissions.TabIndex = 2
        Me.tabEmployeePermissions.Text = "Employee Permissions"
        '
        'dgvEmployeePermissions
        '
        Me.dgvEmployeePermissions.AllowUserToAddRows = False
        Me.dgvEmployeePermissions.AllowUserToDeleteRows = False
        Me.dgvEmployeePermissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmployeePermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployeePermissions.Location = New System.Drawing.Point(5, 6)
        Me.dgvEmployeePermissions.Name = "dgvEmployeePermissions"
        Me.dgvEmployeePermissions.Size = New System.Drawing.Size(745, 588)
        Me.dgvEmployeePermissions.TabIndex = 29
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(883, 761)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 28
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(958, 761)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'trvCtrlHierarchy
        '
        Me.trvCtrlHierarchy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvCtrlHierarchy.Location = New System.Drawing.Point(260, 266)
        Me.trvCtrlHierarchy.Name = "trvCtrlHierarchy"
        Me.trvCtrlHierarchy.ShowNodeToolTips = True
        Me.trvCtrlHierarchy.Size = New System.Drawing.Size(300, 200)
        Me.trvCtrlHierarchy.TabIndex = 30
        Me.trvCtrlHierarchy.Visible = False
        '
        'SecurityManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.trvCtrlHierarchy)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tabCtrlPermissions)
        Me.Controls.Add(Me.gpxCopyEntries)
        Me.Controls.Add(Me.gpxSecurityEntry)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SecurityManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security Management"
        Me.gpxSecurityEntry.ResumeLayout(False)
        Me.gpxSecurityEntry.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxCopyEntries.ResumeLayout(False)
        Me.gpxCopyEntries.PerformLayout()
        Me.tabCtrlPermissions.ResumeLayout(False)
        Me.tabSecurityPermissions.ResumeLayout(False)
        CType(Me.dgvSecurityPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDivisionPermissions.ResumeLayout(False)
        CType(Me.dgvDivisionPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmployeePermissions.ResumeLayout(False)
        CType(Me.dgvEmployeePermissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxSecurityEntry As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents cboSecurityFor As System.Windows.Forms.ComboBox
    Friend WithEvents cboForm As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents lblEmployeeID As System.Windows.Forms.Label
    Friend WithEvents cboControls As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboValue As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProperty As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpxCopyEntries As System.Windows.Forms.GroupBox
    Friend WithEvents cboCopyForm As System.Windows.Forms.ComboBox
    Friend WithEvents lblCopyForm As System.Windows.Forms.Label
    Friend WithEvents cboToEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToEmployeeID As System.Windows.Forms.Label
    Friend WithEvents cboFromEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFromEmployeeID As System.Windows.Forms.Label
    Friend WithEvents cboCopySecurityFor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdCopyClear As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cboToDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToDivisionID As System.Windows.Forms.Label
    Friend WithEvents cboFromDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFromDivisionID As System.Windows.Forms.Label
    Friend WithEvents cboToSecurityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToSecurityID As System.Windows.Forms.Label
    Friend WithEvents cboFromSecurityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFromSecurityID As System.Windows.Forms.Label
    Friend WithEvents cboSecurityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecurityID As System.Windows.Forms.Label
    Friend WithEvents tabCtrlPermissions As System.Windows.Forms.TabControl
    Friend WithEvents tabSecurityPermissions As System.Windows.Forms.TabPage
    Friend WithEvents tabDivisionPermissions As System.Windows.Forms.TabPage
    Friend WithEvents tabEmployeePermissions As System.Windows.Forms.TabPage
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents dgvSecurityPermissions As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDivisionPermissions As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEmployeePermissions As System.Windows.Forms.DataGridView
    Friend WithEvents cboColumn As System.Windows.Forms.ComboBox
    Friend WithEvents lblColumn As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowHideHierarchy As System.Windows.Forms.Button
    Friend WithEvents trvCtrlHierarchy As System.Windows.Forms.TreeView
    Friend WithEvents cboEmployeeName As System.Windows.Forms.ComboBox
End Class
