<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBlueprintPopup
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
        Me.components = New System.ComponentModel.Container
        Me.cboBlueprintNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.rdoHeadingPrint = New System.Windows.Forms.RadioButton
        Me.rdoMachiningPrint = New System.Windows.Forms.RadioButton
        Me.rdoToolingPrint = New System.Windows.Forms.RadioButton
        Me.rdoFinishedPrint = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdViewBlueprint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.rdoTWEPrint = New System.Windows.Forms.RadioButton
        Me.rdoFerrulePrint = New System.Windows.Forms.RadioButton
        Me.dgvExtensions = New System.Windows.Forms.DataGridView
        Me.FilenameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdViewSelected = New System.Windows.Forms.Button
        Me.rdoHeatTreatPrint = New System.Windows.Forms.RadioButton
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExtensions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboBlueprintNumber
        '
        Me.cboBlueprintNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprintNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprintNumber.DataSource = Me.FOXTableBindingSource
        Me.cboBlueprintNumber.DisplayMember = "BlueprintNumber"
        Me.cboBlueprintNumber.FormattingEnabled = True
        Me.cboBlueprintNumber.Location = New System.Drawing.Point(23, 59)
        Me.cboBlueprintNumber.Name = "cboBlueprintNumber"
        Me.cboBlueprintNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboBlueprintNumber.TabIndex = 0
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rdoHeadingPrint
        '
        Me.rdoHeadingPrint.AutoSize = True
        Me.rdoHeadingPrint.Checked = True
        Me.rdoHeadingPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoHeadingPrint.Location = New System.Drawing.Point(24, 107)
        Me.rdoHeadingPrint.Name = "rdoHeadingPrint"
        Me.rdoHeadingPrint.Size = New System.Drawing.Size(136, 24)
        Me.rdoHeadingPrint.TabIndex = 1
        Me.rdoHeadingPrint.TabStop = True
        Me.rdoHeadingPrint.Text = "Heading Print"
        Me.rdoHeadingPrint.UseVisualStyleBackColor = True
        '
        'rdoMachiningPrint
        '
        Me.rdoMachiningPrint.AutoSize = True
        Me.rdoMachiningPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoMachiningPrint.Location = New System.Drawing.Point(24, 156)
        Me.rdoMachiningPrint.Name = "rdoMachiningPrint"
        Me.rdoMachiningPrint.Size = New System.Drawing.Size(150, 24)
        Me.rdoMachiningPrint.TabIndex = 2
        Me.rdoMachiningPrint.Text = "Machining Print"
        Me.rdoMachiningPrint.UseVisualStyleBackColor = True
        '
        'rdoToolingPrint
        '
        Me.rdoToolingPrint.AutoSize = True
        Me.rdoToolingPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoToolingPrint.Location = New System.Drawing.Point(24, 205)
        Me.rdoToolingPrint.Name = "rdoToolingPrint"
        Me.rdoToolingPrint.Size = New System.Drawing.Size(127, 24)
        Me.rdoToolingPrint.TabIndex = 3
        Me.rdoToolingPrint.Text = "Tooling Print"
        Me.rdoToolingPrint.UseVisualStyleBackColor = True
        '
        'rdoFinishedPrint
        '
        Me.rdoFinishedPrint.AutoSize = True
        Me.rdoFinishedPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFinishedPrint.Location = New System.Drawing.Point(24, 254)
        Me.rdoFinishedPrint.Name = "rdoFinishedPrint"
        Me.rdoFinishedPrint.Size = New System.Drawing.Size(137, 24)
        Me.rdoFinishedPrint.TabIndex = 4
        Me.rdoFinishedPrint.Text = "Finished Print"
        Me.rdoFinishedPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Enter Blueprint #:"
        '
        'cmdViewBlueprint
        '
        Me.cmdViewBlueprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdViewBlueprint.Location = New System.Drawing.Point(344, 403)
        Me.cmdViewBlueprint.Name = "cmdViewBlueprint"
        Me.cmdViewBlueprint.Size = New System.Drawing.Size(90, 60)
        Me.cmdViewBlueprint.TabIndex = 7
        Me.cmdViewBlueprint.Text = "View"
        Me.cmdViewBlueprint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(440, 403)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(90, 60)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'rdoTWEPrint
        '
        Me.rdoTWEPrint.AutoSize = True
        Me.rdoTWEPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTWEPrint.Location = New System.Drawing.Point(24, 303)
        Me.rdoTWEPrint.Name = "rdoTWEPrint"
        Me.rdoTWEPrint.Size = New System.Drawing.Size(167, 24)
        Me.rdoTWEPrint.TabIndex = 5
        Me.rdoTWEPrint.Text = "TWE Accessories"
        Me.rdoTWEPrint.UseVisualStyleBackColor = True
        '
        'rdoFerrulePrint
        '
        Me.rdoFerrulePrint.AutoSize = True
        Me.rdoFerrulePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFerrulePrint.Location = New System.Drawing.Point(24, 352)
        Me.rdoFerrulePrint.Name = "rdoFerrulePrint"
        Me.rdoFerrulePrint.Size = New System.Drawing.Size(126, 24)
        Me.rdoFerrulePrint.TabIndex = 6
        Me.rdoFerrulePrint.Text = "Ferrule Print"
        Me.rdoFerrulePrint.UseVisualStyleBackColor = True
        '
        'dgvExtensions
        '
        Me.dgvExtensions.AllowUserToAddRows = False
        Me.dgvExtensions.AllowUserToDeleteRows = False
        Me.dgvExtensions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvExtensions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtensions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FilenameColumn})
        Me.dgvExtensions.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvExtensions.Location = New System.Drawing.Point(238, 59)
        Me.dgvExtensions.Name = "dgvExtensions"
        Me.dgvExtensions.ReadOnly = True
        Me.dgvExtensions.Size = New System.Drawing.Size(292, 268)
        Me.dgvExtensions.TabIndex = 9
        Me.dgvExtensions.Visible = False
        '
        'FilenameColumn
        '
        Me.FilenameColumn.HeaderText = "File Extension"
        Me.FilenameColumn.Name = "FilenameColumn"
        Me.FilenameColumn.ReadOnly = True
        Me.FilenameColumn.Width = 250
        '
        'cmdViewSelected
        '
        Me.cmdViewSelected.Location = New System.Drawing.Point(455, 334)
        Me.cmdViewSelected.Name = "cmdViewSelected"
        Me.cmdViewSelected.Size = New System.Drawing.Size(75, 23)
        Me.cmdViewSelected.TabIndex = 10
        Me.cmdViewSelected.Text = "Continue"
        Me.cmdViewSelected.UseVisualStyleBackColor = True
        Me.cmdViewSelected.Visible = False
        '
        'rdoHeatTreatPrint
        '
        Me.rdoHeatTreatPrint.AutoSize = True
        Me.rdoHeatTreatPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoHeatTreatPrint.Location = New System.Drawing.Point(24, 401)
        Me.rdoHeatTreatPrint.Name = "rdoHeatTreatPrint"
        Me.rdoHeatTreatPrint.Size = New System.Drawing.Size(155, 24)
        Me.rdoHeatTreatPrint.TabIndex = 11
        Me.rdoHeatTreatPrint.Text = "Heat Treat Print"
        Me.rdoHeatTreatPrint.UseVisualStyleBackColor = True
        '
        'ViewBlueprintPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 475)
        Me.Controls.Add(Me.rdoHeatTreatPrint)
        Me.Controls.Add(Me.cmdViewSelected)
        Me.Controls.Add(Me.dgvExtensions)
        Me.Controls.Add(Me.rdoFerrulePrint)
        Me.Controls.Add(Me.rdoTWEPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdViewBlueprint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdoFinishedPrint)
        Me.Controls.Add(Me.rdoToolingPrint)
        Me.Controls.Add(Me.rdoMachiningPrint)
        Me.Controls.Add(Me.rdoHeadingPrint)
        Me.Controls.Add(Me.cboBlueprintNumber)
        Me.Name = "ViewBlueprintPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Blueprints"
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExtensions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBlueprintNumber As System.Windows.Forms.ComboBox
    Friend WithEvents rdoHeadingPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMachiningPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rdoToolingPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFinishedPrint As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdViewBlueprint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents rdoTWEPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFerrulePrint As System.Windows.Forms.RadioButton
    Friend WithEvents dgvExtensions As System.Windows.Forms.DataGridView
    Friend WithEvents FilenameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdViewSelected As System.Windows.Forms.Button
    Friend WithEvents rdoHeatTreatPrint As System.Windows.Forms.RadioButton
End Class
