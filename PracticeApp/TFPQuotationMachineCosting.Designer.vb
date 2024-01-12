<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TFPQuotationMachineCosting
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
        Me.DeleteSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvQuoteCosting = New System.Windows.Forms.DataGridView
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxAddMachineCost = New System.Windows.Forms.GroupBox
        Me.txtSetupCost = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQuoteCost = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMachineType = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvQuoteCosting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAddMachineCost.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectionToolStripMenuItem})
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteSelectionToolStripMenuItem
        '
        Me.DeleteSelectionToolStripMenuItem.Name = "DeleteSelectionToolStripMenuItem"
        Me.DeleteSelectionToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DeleteSelectionToolStripMenuItem.Text = "Delete Selection"
        Me.DeleteSelectionToolStripMenuItem.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
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
        'dgvQuoteCosting
        '
        Me.dgvQuoteCosting.AllowUserToAddRows = False
        Me.dgvQuoteCosting.AllowUserToDeleteRows = False
        Me.dgvQuoteCosting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQuoteCosting.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvQuoteCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuoteCosting.Location = New System.Drawing.Point(264, 27)
        Me.dgvQuoteCosting.Name = "dgvQuoteCosting"
        Me.dgvQuoteCosting.Size = New System.Drawing.Size(533, 329)
        Me.dgvQuoteCosting.TabIndex = 3
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(726, 367)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(350, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Changes in the Data Grid are automatically saved."
        '
        'gpxAddMachineCost
        '
        Me.gpxAddMachineCost.Controls.Add(Me.txtSetupCost)
        Me.gpxAddMachineCost.Controls.Add(Me.Label4)
        Me.gpxAddMachineCost.Controls.Add(Me.txtQuoteCost)
        Me.gpxAddMachineCost.Controls.Add(Me.Label3)
        Me.gpxAddMachineCost.Controls.Add(Me.txtMachineType)
        Me.gpxAddMachineCost.Controls.Add(Me.Label2)
        Me.gpxAddMachineCost.Controls.Add(Me.cmdClear)
        Me.gpxAddMachineCost.Controls.Add(Me.cmdAdd)
        Me.gpxAddMachineCost.Location = New System.Drawing.Point(12, 27)
        Me.gpxAddMachineCost.Name = "gpxAddMachineCost"
        Me.gpxAddMachineCost.Size = New System.Drawing.Size(246, 187)
        Me.gpxAddMachineCost.TabIndex = 7
        Me.gpxAddMachineCost.TabStop = False
        Me.gpxAddMachineCost.Text = "Add Machine Cost"
        '
        'txtSetupCost
        '
        Me.txtSetupCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSetupCost.Location = New System.Drawing.Point(98, 82)
        Me.txtSetupCost.Name = "txtSetupCost"
        Me.txtSetupCost.Size = New System.Drawing.Size(130, 20)
        Me.txtSetupCost.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Setup Cost"
        '
        'txtQuoteCost
        '
        Me.txtQuoteCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteCost.Location = New System.Drawing.Point(98, 56)
        Me.txtQuoteCost.Name = "txtQuoteCost"
        Me.txtQuoteCost.Size = New System.Drawing.Size(130, 20)
        Me.txtQuoteCost.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Quote Cost"
        '
        'txtMachineType
        '
        Me.txtMachineType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineType.Location = New System.Drawing.Point(98, 30)
        Me.txtMachineType.MaxLength = 50
        Me.txtMachineType.Name = "txtMachineType"
        Me.txtMachineType.Size = New System.Drawing.Size(130, 20)
        Me.txtMachineType.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Machine Type"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(157, 131)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 1
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(80, 131)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'TFPQuotationMachineCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 423)
        Me.Controls.Add(Me.gpxAddMachineCost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvQuoteCosting)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimumSize = New System.Drawing.Size(815, 448)
        Me.Name = "TFPQuotationMachineCosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Quotation Machine Costing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvQuoteCosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAddMachineCost.ResumeLayout(False)
        Me.gpxAddMachineCost.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvQuoteCosting As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxAddMachineCost As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtMachineType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuoteCost As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSetupCost As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DeleteSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
