<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewFerruleToolingBlueprints
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
        Me.rdoDefaultFolder = New System.Windows.Forms.RadioButton
        Me.rdoRStylePress = New System.Windows.Forms.RadioButton
        Me.rdoFStylePress = New System.Windows.Forms.RadioButton
        Me.rdoExtrusionTooling = New System.Windows.Forms.RadioButton
        Me.rdoTStylePress = New System.Windows.Forms.RadioButton
        Me.cmdViewFiles = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoEricoR = New System.Windows.Forms.RadioButton
        Me.dgvToolingFileViewer = New System.Windows.Forms.DataGridView
        Me.BPFilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdViewBlueprint = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvToolingFileViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoDefaultFolder
        '
        Me.rdoDefaultFolder.AutoSize = True
        Me.rdoDefaultFolder.Checked = True
        Me.rdoDefaultFolder.Location = New System.Drawing.Point(17, 26)
        Me.rdoDefaultFolder.Name = "rdoDefaultFolder"
        Me.rdoDefaultFolder.Size = New System.Drawing.Size(104, 17)
        Me.rdoDefaultFolder.TabIndex = 0
        Me.rdoDefaultFolder.TabStop = True
        Me.rdoDefaultFolder.Text = "Default Directory"
        Me.rdoDefaultFolder.UseVisualStyleBackColor = True
        '
        'rdoRStylePress
        '
        Me.rdoRStylePress.AutoSize = True
        Me.rdoRStylePress.Location = New System.Drawing.Point(156, 63)
        Me.rdoRStylePress.Name = "rdoRStylePress"
        Me.rdoRStylePress.Size = New System.Drawing.Size(88, 17)
        Me.rdoRStylePress.TabIndex = 1
        Me.rdoRStylePress.Text = "R Style Press"
        Me.rdoRStylePress.UseVisualStyleBackColor = True
        '
        'rdoFStylePress
        '
        Me.rdoFStylePress.AutoSize = True
        Me.rdoFStylePress.Location = New System.Drawing.Point(156, 26)
        Me.rdoFStylePress.Name = "rdoFStylePress"
        Me.rdoFStylePress.Size = New System.Drawing.Size(86, 17)
        Me.rdoFStylePress.TabIndex = 2
        Me.rdoFStylePress.Text = "F Style Press"
        Me.rdoFStylePress.UseVisualStyleBackColor = True
        '
        'rdoExtrusionTooling
        '
        Me.rdoExtrusionTooling.AutoSize = True
        Me.rdoExtrusionTooling.Location = New System.Drawing.Point(17, 63)
        Me.rdoExtrusionTooling.Name = "rdoExtrusionTooling"
        Me.rdoExtrusionTooling.Size = New System.Drawing.Size(97, 17)
        Me.rdoExtrusionTooling.TabIndex = 3
        Me.rdoExtrusionTooling.Text = "Extrusion Prints"
        Me.rdoExtrusionTooling.UseVisualStyleBackColor = True
        '
        'rdoTStylePress
        '
        Me.rdoTStylePress.AutoSize = True
        Me.rdoTStylePress.Location = New System.Drawing.Point(277, 26)
        Me.rdoTStylePress.Name = "rdoTStylePress"
        Me.rdoTStylePress.Size = New System.Drawing.Size(87, 17)
        Me.rdoTStylePress.TabIndex = 4
        Me.rdoTStylePress.Text = "T Style Press"
        Me.rdoTStylePress.UseVisualStyleBackColor = True
        '
        'cmdViewFiles
        '
        Me.cmdViewFiles.Location = New System.Drawing.Point(409, 40)
        Me.cmdViewFiles.Name = "cmdViewFiles"
        Me.cmdViewFiles.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewFiles.TabIndex = 5
        Me.cmdViewFiles.Text = "View Files"
        Me.cmdViewFiles.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(409, 621)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoEricoR)
        Me.GroupBox1.Controls.Add(Me.rdoExtrusionTooling)
        Me.GroupBox1.Controls.Add(Me.rdoDefaultFolder)
        Me.GroupBox1.Controls.Add(Me.rdoRStylePress)
        Me.GroupBox1.Controls.Add(Me.rdoTStylePress)
        Me.GroupBox1.Controls.Add(Me.rdoFStylePress)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 100)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'rdoEricoR
        '
        Me.rdoEricoR.AutoSize = True
        Me.rdoEricoR.Location = New System.Drawing.Point(277, 63)
        Me.rdoEricoR.Name = "rdoEricoR"
        Me.rdoEricoR.Size = New System.Drawing.Size(60, 17)
        Me.rdoEricoR.TabIndex = 5
        Me.rdoEricoR.Text = "Erico R"
        Me.rdoEricoR.UseVisualStyleBackColor = True
        '
        'dgvToolingFileViewer
        '
        Me.dgvToolingFileViewer.AllowUserToAddRows = False
        Me.dgvToolingFileViewer.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvToolingFileViewer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvToolingFileViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvToolingFileViewer.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvToolingFileViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToolingFileViewer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BPFilenameColumn})
        Me.dgvToolingFileViewer.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvToolingFileViewer.Location = New System.Drawing.Point(12, 114)
        Me.dgvToolingFileViewer.Name = "dgvToolingFileViewer"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvToolingFileViewer.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvToolingFileViewer.Size = New System.Drawing.Size(468, 488)
        Me.dgvToolingFileViewer.TabIndex = 8
        '
        'BPFilenameColumn
        '
        Me.BPFilenameColumn.HeaderText = "Blueprint File Name"
        Me.BPFilenameColumn.Name = "BPFilenameColumn"
        Me.BPFilenameColumn.Width = 400
        '
        'cmdViewBlueprint
        '
        Me.cmdViewBlueprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewBlueprint.Location = New System.Drawing.Point(12, 621)
        Me.cmdViewBlueprint.Name = "cmdViewBlueprint"
        Me.cmdViewBlueprint.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewBlueprint.TabIndex = 9
        Me.cmdViewBlueprint.Text = "View B/P"
        Me.cmdViewBlueprint.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(332, 621)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'ViewFerruleToolingBlueprints
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 673)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdViewBlueprint)
        Me.Controls.Add(Me.dgvToolingFileViewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdViewFiles)
        Me.Name = "ViewFerruleToolingBlueprints"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Ferrule Tooling Prints"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvToolingFileViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdoDefaultFolder As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRStylePress As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFStylePress As System.Windows.Forms.RadioButton
    Friend WithEvents rdoExtrusionTooling As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTStylePress As System.Windows.Forms.RadioButton
    Friend WithEvents cmdViewFiles As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvToolingFileViewer As System.Windows.Forms.DataGridView
    Friend WithEvents cmdViewBlueprint As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents BPFilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdoEricoR As System.Windows.Forms.RadioButton
End Class
