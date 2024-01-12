<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPriceSheetIncrease
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
        Me.chkMildSteel = New System.Windows.Forms.CheckBox
        Me.chkStainlessSteel = New System.Windows.Forms.CheckBox
        Me.chkPSR = New System.Windows.Forms.CheckBox
        Me.cboFilter = New System.Windows.Forms.Button
        Me.CRPriceSheetIncreaseViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXPriceSheetIncreaseSWR1 = New MOS09Program.CRXPriceSheetIncreaseSWR
        Me.CRXPriceSheetIncreaseSS1 = New MOS09Program.CRXPriceSheetIncreaseSS
        Me.CRXPriceSheetIncreasePSR1 = New MOS09Program.CRXPriceSheetIncreasePSR
        Me.CRXPriceSheetIncrease1 = New MOS09Program.CRXPriceSheetIncrease
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailPriceSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.chkSWR = New System.Windows.Forms.CheckBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkMildSteel
        '
        Me.chkMildSteel.AutoSize = True
        Me.chkMildSteel.Location = New System.Drawing.Point(13, 173)
        Me.chkMildSteel.Name = "chkMildSteel"
        Me.chkMildSteel.Size = New System.Drawing.Size(72, 17)
        Me.chkMildSteel.TabIndex = 1
        Me.chkMildSteel.Text = "Mild Steel"
        Me.chkMildSteel.UseVisualStyleBackColor = True
        '
        'chkStainlessSteel
        '
        Me.chkStainlessSteel.AutoSize = True
        Me.chkStainlessSteel.Location = New System.Drawing.Point(13, 215)
        Me.chkStainlessSteel.Name = "chkStainlessSteel"
        Me.chkStainlessSteel.Size = New System.Drawing.Size(95, 17)
        Me.chkStainlessSteel.TabIndex = 2
        Me.chkStainlessSteel.Text = "Stainless Steel"
        Me.chkStainlessSteel.UseVisualStyleBackColor = True
        '
        'chkPSR
        '
        Me.chkPSR.AutoSize = True
        Me.chkPSR.Location = New System.Drawing.Point(13, 257)
        Me.chkPSR.Name = "chkPSR"
        Me.chkPSR.Size = New System.Drawing.Size(48, 17)
        Me.chkPSR.TabIndex = 3
        Me.chkPSR.Text = "PSR"
        Me.chkPSR.UseVisualStyleBackColor = True
        '
        'cboFilter
        '
        Me.cboFilter.Location = New System.Drawing.Point(13, 339)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(75, 23)
        Me.cboFilter.TabIndex = 4
        Me.cboFilter.Text = "Filter"
        Me.cboFilter.UseVisualStyleBackColor = True
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
        Me.CRPriceSheetIncreaseViewer1.ReportSource = Me.CRXPriceSheetIncreaseSWR1
        Me.CRPriceSheetIncreaseViewer1.ShowGroupTreeButton = False
        Me.CRPriceSheetIncreaseViewer1.ShowTextSearchButton = False
        Me.CRPriceSheetIncreaseViewer1.Size = New System.Drawing.Size(898, 584)
        Me.CRPriceSheetIncreaseViewer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 138)
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
        'chkSWR
        '
        Me.chkSWR.AutoSize = True
        Me.chkSWR.Location = New System.Drawing.Point(13, 299)
        Me.chkSWR.Name = "chkSWR"
        Me.chkSWR.Size = New System.Drawing.Size(52, 17)
        Me.chkSWR.TabIndex = 8
        Me.chkSWR.Text = "SWR"
        Me.chkSWR.UseVisualStyleBackColor = True
        '
        'PrintPriceSheetIncrease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 632)
        Me.Controls.Add(Me.chkSWR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.chkPSR)
        Me.Controls.Add(Me.chkStainlessSteel)
        Me.Controls.Add(Me.chkMildSteel)
        Me.Controls.Add(Me.CRPriceSheetIncreaseViewer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PrintPriceSheetIncrease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Price Sheets"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRPriceSheetIncreaseViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXPriceSheetIncrease1 As MOS09Program.CRXPriceSheetIncrease
    Friend WithEvents chkMildSteel As System.Windows.Forms.CheckBox
    Friend WithEvents chkStainlessSteel As System.Windows.Forms.CheckBox
    Friend WithEvents chkPSR As System.Windows.Forms.CheckBox
    Friend WithEvents cboFilter As System.Windows.Forms.Button
    Friend WithEvents CRXPriceSheetIncreaseSS1 As MOS09Program.CRXPriceSheetIncreaseSS
    Friend WithEvents CRXPriceSheetIncreasePSR1 As MOS09Program.CRXPriceSheetIncreasePSR
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailPriceSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRXPriceSheetIncreaseSWR1 As MOS09Program.CRXPriceSheetIncreaseSWR
    Friend WithEvents chkSWR As System.Windows.Forms.CheckBox
End Class
