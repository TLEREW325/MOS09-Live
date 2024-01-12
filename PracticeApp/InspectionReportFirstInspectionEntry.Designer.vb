<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InspectionReportFirstInspectionEntry
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
        Me.dgvFirstInspectionEntry = New System.Windows.Forms.DataGridView
        Me.cmdFirstInspectionEntry = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSampleSize = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblInspectionReport = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.lblCurrentRevisionLevel = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBlueprintRevisionLevel = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dgvFirstInspectionEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFirstInspectionEntry
        '
        Me.dgvFirstInspectionEntry.AllowUserToAddRows = False
        Me.dgvFirstInspectionEntry.AllowUserToDeleteRows = False
        Me.dgvFirstInspectionEntry.AllowUserToResizeColumns = False
        Me.dgvFirstInspectionEntry.AllowUserToResizeRows = False
        Me.dgvFirstInspectionEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFirstInspectionEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFirstInspectionEntry.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFirstInspectionEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFirstInspectionEntry.Location = New System.Drawing.Point(12, 12)
        Me.dgvFirstInspectionEntry.Name = "dgvFirstInspectionEntry"
        Me.dgvFirstInspectionEntry.RowHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvFirstInspectionEntry.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFirstInspectionEntry.Size = New System.Drawing.Size(517, 349)
        Me.dgvFirstInspectionEntry.TabIndex = 0
        '
        'cmdFirstInspectionEntry
        '
        Me.cmdFirstInspectionEntry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFirstInspectionEntry.Location = New System.Drawing.Point(381, 414)
        Me.cmdFirstInspectionEntry.Name = "cmdFirstInspectionEntry"
        Me.cmdFirstInspectionEntry.Size = New System.Drawing.Size(71, 40)
        Me.cmdFirstInspectionEntry.TabIndex = 3
        Me.cmdFirstInspectionEntry.Text = "Submit Entries"
        Me.cmdFirstInspectionEntry.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(458, 414)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(378, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sample Size"
        '
        'txtSampleSize
        '
        Me.txtSampleSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtSampleSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSampleSize.Location = New System.Drawing.Point(381, 384)
        Me.txtSampleSize.Name = "txtSampleSize"
        Me.txtSampleSize.Size = New System.Drawing.Size(126, 20)
        Me.txtSampleSize.TabIndex = 2
        Me.txtSampleSize.Text = "2"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lot Number"
        '
        'lblInspectionReport
        '
        Me.lblInspectionReport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblInspectionReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInspectionReport.Location = New System.Drawing.Point(15, 384)
        Me.lblInspectionReport.Name = "lblInspectionReport"
        Me.lblInspectionReport.Size = New System.Drawing.Size(135, 20)
        Me.lblInspectionReport.TabIndex = 8
        Me.lblInspectionReport.Text = "Inspection Report"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 364)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Inspection Report"
        '
        'txtLotNumber
        '
        Me.txtLotNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.Location = New System.Drawing.Point(210, 384)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(134, 20)
        Me.txtLotNumber.TabIndex = 1
        '
        'lblCurrentRevisionLevel
        '
        Me.lblCurrentRevisionLevel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCurrentRevisionLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentRevisionLevel.Location = New System.Drawing.Point(15, 429)
        Me.lblCurrentRevisionLevel.Name = "lblCurrentRevisionLevel"
        Me.lblCurrentRevisionLevel.Size = New System.Drawing.Size(88, 19)
        Me.lblCurrentRevisionLevel.TabIndex = 9
        Me.lblCurrentRevisionLevel.Text = "Inspection Report"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label5.Location = New System.Drawing.Point(12, 410)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Current Revision Level"
        '
        'txtBlueprintRevisionLevel
        '
        Me.txtBlueprintRevisionLevel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtBlueprintRevisionLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlueprintRevisionLevel.Location = New System.Drawing.Point(210, 430)
        Me.txtBlueprintRevisionLevel.Name = "txtBlueprintRevisionLevel"
        Me.txtBlueprintRevisionLevel.Size = New System.Drawing.Size(134, 20)
        Me.txtBlueprintRevisionLevel.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(207, 410)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Blueprint Revision Level"
        '
        'InspectionReportFirstInspectionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtBlueprintRevisionLevel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCurrentRevisionLevel)
        Me.Controls.Add(Me.txtLotNumber)
        Me.Controls.Add(Me.lblInspectionReport)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSampleSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdFirstInspectionEntry)
        Me.Controls.Add(Me.dgvFirstInspectionEntry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "InspectionReportFirstInspectionEntry"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inspection Report First Inspection Entry"
        CType(Me.dgvFirstInspectionEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFirstInspectionEntry As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFirstInspectionEntry As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSampleSize As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblInspectionReport As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentRevisionLevel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBlueprintRevisionLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
