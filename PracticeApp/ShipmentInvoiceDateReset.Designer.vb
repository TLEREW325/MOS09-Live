<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentInvoiceDateReset
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdResetShipmentDate = New System.Windows.Forms.Button
        Me.dtpResetDate = New System.Windows.Forms.DateTimePicker
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtResetInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtResetShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(432, 231)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 584
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 231)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 583
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdResetShipmentDate
        '
        Me.cmdResetShipmentDate.Location = New System.Drawing.Point(259, 143)
        Me.cmdResetShipmentDate.Name = "cmdResetShipmentDate"
        Me.cmdResetShipmentDate.Size = New System.Drawing.Size(71, 30)
        Me.cmdResetShipmentDate.TabIndex = 591
        Me.cmdResetShipmentDate.Text = "Reset Date"
        Me.cmdResetShipmentDate.UseVisualStyleBackColor = True
        '
        'dtpResetDate
        '
        Me.dtpResetDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpResetDate.Location = New System.Drawing.Point(160, 103)
        Me.dtpResetDate.Name = "dtpResetDate"
        Me.dtpResetDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpResetDate.TabIndex = 590
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(17, 103)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(95, 23)
        Me.Label32.TabIndex = 589
        Me.Label32.Text = "Date"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(17, 72)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 23)
        Me.Label31.TabIndex = 588
        Me.Label31.Text = "Invoice Number"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResetInvoiceNumber
        '
        Me.txtResetInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResetInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResetInvoiceNumber.Location = New System.Drawing.Point(160, 72)
        Me.txtResetInvoiceNumber.Name = "txtResetInvoiceNumber"
        Me.txtResetInvoiceNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtResetInvoiceNumber.TabIndex = 587
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(17, 41)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(95, 23)
        Me.Label30.TabIndex = 586
        Me.Label30.Text = "Shipment Number"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResetShipmentNumber
        '
        Me.txtResetShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResetShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResetShipmentNumber.Location = New System.Drawing.Point(160, 41)
        Me.txtResetShipmentNumber.Name = "txtResetShipmentNumber"
        Me.txtResetShipmentNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtResetShipmentNumber.TabIndex = 585
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(17, 197)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(371, 64)
        Me.Label33.TabIndex = 592
        Me.Label33.Text = "This utility will reset the ship/invoice date and all associated entries. This in" & _
            "cludes inventory transactions and G/L postings. This utility will not work on cr" & _
            "edits from a return."
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(348, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 64)
        Me.Label1.TabIndex = 593
        Me.Label1.Text = "Type in Shipment # or Invoice # - this utility will autoload the Invoice # for a " & _
            "shipment or the shipment # for an invoice, if it exists."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(348, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 20)
        Me.Label2.TabIndex = 594
        Me.Label2.Text = "Bill Only Invoice - no shipment #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(348, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 40)
        Me.Label3.TabIndex = 595
        Me.Label3.Text = "A shipment may or may not have an invoice # (yet)."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentInvoiceDateReset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.cmdResetShipmentDate)
        Me.Controls.Add(Me.dtpResetDate)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtResetInvoiceNumber)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtResetShipmentNumber)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipmentInvoiceDateReset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment / Invoice Date Reset"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdResetShipmentDate As System.Windows.Forms.Button
    Friend WithEvents dtpResetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtResetInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtResetShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
