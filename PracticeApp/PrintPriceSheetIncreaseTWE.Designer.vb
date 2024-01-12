<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPriceSheetIncreaseTWE
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
        Me.chkDistributer = New System.Windows.Forms.CheckBox
        Me.chkEndUser = New System.Windows.Forms.CheckBox
        Me.chkSWP = New System.Windows.Forms.CheckBox
        Me.cboFilter = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailPriceSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.chkRedDArce = New System.Windows.Forms.CheckBox
        Me.CRXPriceSheetIncreaseTWERedD1 = New MOS09Program.CRXPriceSheetIncreaseTWERedD
        Me.CRPriceSheetIncreaseViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPriceSheetIncreaseTWESwp1 = New MOS09Program.CRXPriceSheetIncreaseTWESwp
        Me.CRXPriceSheetIncreaseTWEDist1 = New MOS09Program.CRXPriceSheetIncreaseTWEDist
        Me.CRXPriceSheetIncreaseTWEEnd1 = New MOS09Program.CRXPriceSheetIncreaseTWEEnd
        Me.chkHanlon = New System.Windows.Forms.CheckBox
        Me.CRXPriceSheetIncreaseTWEHanlon1 = New MOS09Program.CRXPriceSheetIncreaseTWEHanlon
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkDistributer
        '
        Me.chkDistributer.AutoSize = True
        Me.chkDistributer.Location = New System.Drawing.Point(3, 171)
        Me.chkDistributer.Name = "chkDistributer"
        Me.chkDistributer.Size = New System.Drawing.Size(73, 17)
        Me.chkDistributer.TabIndex = 1
        Me.chkDistributer.Text = "Distributer"
        Me.chkDistributer.UseVisualStyleBackColor = True
        '
        'chkEndUser
        '
        Me.chkEndUser.AutoSize = True
        Me.chkEndUser.Location = New System.Drawing.Point(3, 212)
        Me.chkEndUser.Name = "chkEndUser"
        Me.chkEndUser.Size = New System.Drawing.Size(70, 17)
        Me.chkEndUser.TabIndex = 2
        Me.chkEndUser.Text = "End User"
        Me.chkEndUser.UseVisualStyleBackColor = True
        '
        'chkSWP
        '
        Me.chkSWP.AutoSize = True
        Me.chkSWP.Location = New System.Drawing.Point(3, 254)
        Me.chkSWP.Name = "chkSWP"
        Me.chkSWP.Size = New System.Drawing.Size(51, 17)
        Me.chkSWP.TabIndex = 3
        Me.chkSWP.Text = "SWP"
        Me.chkSWP.UseVisualStyleBackColor = True
        '
        'cboFilter
        '
        Me.cboFilter.Location = New System.Drawing.Point(26, 369)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(75, 23)
        Me.cboFilter.TabIndex = 5
        Me.cboFilter.Text = "Filter"
        Me.cboFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select Price Sheet"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 7
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailPriceSheetToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.EditToolStripMenuItem.Text = "Edit "
        '
        'EmailPriceSheetToolStripMenuItem
        '
        Me.EmailPriceSheetToolStripMenuItem.Name = "EmailPriceSheetToolStripMenuItem"
        Me.EmailPriceSheetToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EmailPriceSheetToolStripMenuItem.Text = "Email Price Sheet"
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
        'chkRedDArce
        '
        Me.chkRedDArce.AutoSize = True
        Me.chkRedDArce.Location = New System.Drawing.Point(3, 296)
        Me.chkRedDArce.Name = "chkRedDArce"
        Me.chkRedDArce.Size = New System.Drawing.Size(79, 17)
        Me.chkRedDArce.TabIndex = 4
        Me.chkRedDArce.Text = "Red-D-Arc "
        Me.chkRedDArce.UseVisualStyleBackColor = True
        '
        'CRPriceSheetIncreaseViewer1
        '
        Me.CRPriceSheetIncreaseViewer1.ActiveViewIndex = 0
        Me.CRPriceSheetIncreaseViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRPriceSheetIncreaseViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPriceSheetIncreaseViewer1.DisplayGroupTree = False
        Me.CRPriceSheetIncreaseViewer1.Location = New System.Drawing.Point(130, 27)
        Me.CRPriceSheetIncreaseViewer1.Name = "CRPriceSheetIncreaseViewer1"
        Me.CRPriceSheetIncreaseViewer1.ReportSource = Me.CRXPriceSheetIncreaseTWEHanlon1
        Me.CRPriceSheetIncreaseViewer1.ShowGroupTreeButton = False
        Me.CRPriceSheetIncreaseViewer1.ShowTextSearchButton = False
        Me.CRPriceSheetIncreaseViewer1.Size = New System.Drawing.Size(898, 584)
        Me.CRPriceSheetIncreaseViewer1.TabIndex = 0
        '
        'chkHanlon
        '
        Me.chkHanlon.AutoSize = True
        Me.chkHanlon.Location = New System.Drawing.Point(3, 336)
        Me.chkHanlon.Name = "chkHanlon"
        Me.chkHanlon.Size = New System.Drawing.Size(60, 17)
        Me.chkHanlon.TabIndex = 8
        Me.chkHanlon.Text = "Hanlon"
        Me.chkHanlon.UseVisualStyleBackColor = True
        '
        'PrintPriceSheetIncreaseTWE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 632)
        Me.Controls.Add(Me.chkHanlon)
        Me.Controls.Add(Me.chkRedDArce)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.chkSWP)
        Me.Controls.Add(Me.chkEndUser)
        Me.Controls.Add(Me.chkDistributer)
        Me.Controls.Add(Me.CRPriceSheetIncreaseViewer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintPriceSheetIncreaseTWE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Price Sheets"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRPriceSheetIncreaseViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkDistributer As System.Windows.Forms.CheckBox
    Friend WithEvents chkEndUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkSWP As System.Windows.Forms.CheckBox
    Friend WithEvents cboFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailPriceSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkRedDArce As System.Windows.Forms.CheckBox
    Friend WithEvents CRXPriceSheetIncreaseTWEEnd1 As MOS09Program.CRXPriceSheetIncreaseTWEEnd
    Friend WithEvents CRXPriceSheetIncreaseTWEDist1 As MOS09Program.CRXPriceSheetIncreaseTWEDist
    Friend WithEvents CRXPriceSheetIncreaseTWESwp1 As MOS09Program.CRXPriceSheetIncreaseTWESwp
    Friend WithEvents CRXPriceSheetIncreaseTWERedD1 As MOS09Program.CRXPriceSheetIncreaseTWERedD
    Friend WithEvents chkHanlon As System.Windows.Forms.CheckBox
    Friend WithEvents CRXPriceSheetIncreaseTWEHanlon1 As MOS09Program.CRXPriceSheetIncreaseTWEHanlon
End Class
