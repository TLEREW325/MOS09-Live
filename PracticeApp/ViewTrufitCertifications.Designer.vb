<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTrufitCertifications
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
        Me.cmdViewCert = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.mnuDefault = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.lblHeatNumber = New System.Windows.Forms.Label
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.lblLotNumber = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.cmdEmailCert = New System.Windows.Forms.Button
        Me.cmdEmailAll = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CRVTFPCert = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdPrintAll = New System.Windows.Forms.Button
        Me.cmdPrintCert = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.mnuDefault.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdViewCert
        '
        Me.cmdViewCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewCert.Location = New System.Drawing.Point(143, 276)
        Me.cmdViewCert.Name = "cmdViewCert"
        Me.cmdViewCert.Size = New System.Drawing.Size(70, 40)
        Me.cmdViewCert.TabIndex = 10
        Me.cmdViewCert.Text = "Load Cert"
        Me.cmdViewCert.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1060, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(70, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(219, 276)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(70, 40)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'mnuDefault
        '
        Me.mnuDefault.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.mnuDefault.Location = New System.Drawing.Point(0, 0)
        Me.mnuDefault.Name = "mnuDefault"
        Me.mnuDefault.Size = New System.Drawing.Size(1142, 24)
        Me.mnuDefault.TabIndex = 60
        Me.mnuDefault.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
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
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Location = New System.Drawing.Point(6, 55)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(82, 13)
        Me.lblCustomerName.TabIndex = 84
        Me.lblCustomerName.Text = "Customer Name"
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(9, 138)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(280, 21)
        Me.cboPartDescription.TabIndex = 78
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(48, 111)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(241, 21)
        Me.cboPartNumber.TabIndex = 77
        '
        'lblPartNumber
        '
        Me.lblPartNumber.AutoSize = True
        Me.lblPartNumber.Location = New System.Drawing.Point(6, 114)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(36, 13)
        Me.lblPartNumber.TabIndex = 82
        Me.lblPartNumber.Text = "Part #"
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(92, 25)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(197, 21)
        Me.cboCustomerID.TabIndex = 76
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoSize = True
        Me.lblCustomerID.Location = New System.Drawing.Point(6, 28)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(65, 13)
        Me.lblCustomerID.TabIndex = 81
        Me.lblCustomerID.Text = "Customer ID"
        '
        'lblHeatNumber
        '
        Me.lblHeatNumber.Location = New System.Drawing.Point(6, 180)
        Me.lblHeatNumber.Name = "lblHeatNumber"
        Me.lblHeatNumber.Size = New System.Drawing.Size(70, 20)
        Me.lblHeatNumber.TabIndex = 80
        Me.lblHeatNumber.Text = "Heat #"
        Me.lblHeatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.Location = New System.Drawing.Point(92, 180)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(197, 20)
        Me.txtHeatNumber.TabIndex = 79
        '
        'lblLotNumber
        '
        Me.lblLotNumber.Location = New System.Drawing.Point(6, 231)
        Me.lblLotNumber.Name = "lblLotNumber"
        Me.lblLotNumber.Size = New System.Drawing.Size(62, 20)
        Me.lblLotNumber.TabIndex = 87
        Me.lblLotNumber.Text = "Lot #"
        Me.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.Location = New System.Drawing.Point(92, 230)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(197, 20)
        Me.txtLotNumber.TabIndex = 86
        '
        'cmdEmailCert
        '
        Me.cmdEmailCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEmailCert.Location = New System.Drawing.Point(231, 510)
        Me.cmdEmailCert.Name = "cmdEmailCert"
        Me.cmdEmailCert.Size = New System.Drawing.Size(70, 40)
        Me.cmdEmailCert.TabIndex = 88
        Me.cmdEmailCert.Text = "Email Cert"
        Me.cmdEmailCert.UseVisualStyleBackColor = True
        '
        'cmdEmailAll
        '
        Me.cmdEmailAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEmailAll.Location = New System.Drawing.Point(155, 510)
        Me.cmdEmailAll.Name = "cmdEmailAll"
        Me.cmdEmailAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdEmailAll.TabIndex = 89
        Me.cmdEmailAll.Text = "Email All"
        Me.cmdEmailAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.lblCustomerID)
        Me.GroupBox1.Controls.Add(Me.lblHeatNumber)
        Me.GroupBox1.Controls.Add(Me.lblLotNumber)
        Me.GroupBox1.Controls.Add(Me.txtLotNumber)
        Me.GroupBox1.Controls.Add(Me.cmdViewCert)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.lblCustomerName)
        Me.GroupBox1.Controls.Add(Me.txtHeatNumber)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.lblPartNumber)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 347)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(9, 72)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(280, 21)
        Me.cboCustomerName.TabIndex = 88
        '
        'CRVTFPCert
        '
        Me.CRVTFPCert.ActiveViewIndex = -1
        Me.CRVTFPCert.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRVTFPCert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVTFPCert.DisplayGroupTree = False
        Me.CRVTFPCert.DisplayStatusBar = False
        Me.CRVTFPCert.DisplayToolbar = False
        Me.CRVTFPCert.Location = New System.Drawing.Point(320, 29)
        Me.CRVTFPCert.Name = "CRVTFPCert"
        Me.CRVTFPCert.SelectionFormula = ""
        Me.CRVTFPCert.Size = New System.Drawing.Size(810, 736)
        Me.CRVTFPCert.TabIndex = 91
        Me.CRVTFPCert.ViewTimeSelectionFormula = ""
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintAll.Location = New System.Drawing.Point(155, 556)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(70, 40)
        Me.cmdPrintAll.TabIndex = 92
        Me.cmdPrintAll.Text = "Print All"
        Me.cmdPrintAll.UseVisualStyleBackColor = True
        '
        'cmdPrintCert
        '
        Me.cmdPrintCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCert.Location = New System.Drawing.Point(231, 556)
        Me.cmdPrintCert.Name = "cmdPrintCert"
        Me.cmdPrintCert.Size = New System.Drawing.Size(70, 40)
        Me.cmdPrintCert.TabIndex = 93
        Me.cmdPrintCert.Text = "Print Cert"
        Me.cmdPrintCert.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(230, 712)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 94
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ViewTrufitCertifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdPrintCert)
        Me.Controls.Add(Me.cmdPrintAll)
        Me.Controls.Add(Me.CRVTFPCert)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdEmailAll)
        Me.Controls.Add(Me.cmdEmailCert)
        Me.Controls.Add(Me.mnuDefault)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "ViewTrufitCertifications"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Trufit Certifications"
        Me.mnuDefault.ResumeLayout(False)
        Me.mnuDefault.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdViewCert As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents mnuDefault As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents lblHeatNumber As System.Windows.Forms.Label
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLotNumber As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdEmailCert As System.Windows.Forms.Button
    Friend WithEvents cmdEmailAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CRVTFPCert As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdPrintAll As System.Windows.Forms.Button
    Friend WithEvents cmdPrintCert As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
