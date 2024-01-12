<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeaderFOXInspectionEntryViewer
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
        Me.dgvInspectionEntries = New System.Windows.Forms.DataGridView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.txtRedBox = New System.Windows.Forms.TextBox
        Me.lblRedIndication = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvInspectionEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInspectionEntries
        '
        Me.dgvInspectionEntries.AllowUserToAddRows = False
        Me.dgvInspectionEntries.AllowUserToDeleteRows = False
        Me.dgvInspectionEntries.AllowUserToResizeColumns = False
        Me.dgvInspectionEntries.AllowUserToResizeRows = False
        Me.dgvInspectionEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvInspectionEntries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspectionEntries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInspectionEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInspectionEntries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvInspectionEntries.Location = New System.Drawing.Point(0, 0)
        Me.dgvInspectionEntries.MultiSelect = False
        Me.dgvInspectionEntries.Name = "dgvInspectionEntries"
        Me.dgvInspectionEntries.ReadOnly = True
        Me.dgvInspectionEntries.RowHeadersVisible = False
        Me.dgvInspectionEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvInspectionEntries.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInspectionEntries.Size = New System.Drawing.Size(569, 270)
        Me.dgvInspectionEntries.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(461, 278)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(99, 60)
        Me.cmdClose.TabIndex = 37
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtRedBox
        '
        Me.txtRedBox.BackColor = System.Drawing.Color.LightCoral
        Me.txtRedBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRedBox.Location = New System.Drawing.Point(46, 278)
        Me.txtRedBox.Multiline = True
        Me.txtRedBox.Name = "txtRedBox"
        Me.txtRedBox.Size = New System.Drawing.Size(20, 20)
        Me.txtRedBox.TabIndex = 38
        '
        'lblRedIndication
        '
        Me.lblRedIndication.AutoSize = True
        Me.lblRedIndication.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRedIndication.Location = New System.Drawing.Point(72, 278)
        Me.lblRedIndication.Name = "lblRedIndication"
        Me.lblRedIndication.Size = New System.Drawing.Size(91, 18)
        Me.lblRedIndication.TabIndex = 39
        Me.lblRedIndication.Text = "- out of spec"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightGreen
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(46, 304)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(20, 20)
        Me.TextBox1.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 18)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "- in spec"
        '
        'HeaderFOXInspectionEntryViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(572, 350)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblRedIndication)
        Me.Controls.Add(Me.txtRedBox)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.dgvInspectionEntries)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HeaderFOXInspectionEntryViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HeaderFOXInspectionEntryViewer"
        Me.TopMost = True
        CType(Me.dgvInspectionEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvInspectionEntries As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtRedBox As System.Windows.Forms.TextBox
    Friend WithEvents lblRedIndication As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
