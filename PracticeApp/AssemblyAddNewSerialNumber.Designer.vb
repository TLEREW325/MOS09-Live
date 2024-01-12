<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblyAddNewSerialNumber
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
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAddNew = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.rdoAvailable = New System.Windows.Forms.RadioButton
        Me.rdoOpen = New System.Windows.Forms.RadioButton
        Me.rdoClosed = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Location = New System.Drawing.Point(94, 108)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(260, 20)
        Me.txtSerialNumber.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Serial #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Part #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(206, 204)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddNew.TabIndex = 6
        Me.cmdAddNew.Text = "Add"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(283, 204)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'rdoAvailable
        '
        Me.rdoAvailable.AutoSize = True
        Me.rdoAvailable.Checked = True
        Me.rdoAvailable.Location = New System.Drawing.Point(19, 170)
        Me.rdoAvailable.Name = "rdoAvailable"
        Me.rdoAvailable.Size = New System.Drawing.Size(128, 17)
        Me.rdoAvailable.TabIndex = 3
        Me.rdoAvailable.TabStop = True
        Me.rdoAvailable.Text = "AVAILABLE (for build)"
        Me.rdoAvailable.UseVisualStyleBackColor = True
        '
        'rdoOpen
        '
        Me.rdoOpen.AutoSize = True
        Me.rdoOpen.Location = New System.Drawing.Point(19, 199)
        Me.rdoOpen.Name = "rdoOpen"
        Me.rdoOpen.Size = New System.Drawing.Size(98, 17)
        Me.rdoOpen.TabIndex = 4
        Me.rdoOpen.Text = "OPEN (for sale)"
        Me.rdoOpen.UseVisualStyleBackColor = True
        '
        'rdoClosed
        '
        Me.rdoClosed.AutoSize = True
        Me.rdoClosed.Location = New System.Drawing.Point(19, 228)
        Me.rdoClosed.Name = "rdoClosed"
        Me.rdoClosed.Size = New System.Drawing.Size(143, 17)
        Me.rdoClosed.TabIndex = 5
        Me.rdoClosed.Text = "CLOSED (for return, etc.)"
        Me.rdoClosed.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(19, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 23)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Status"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(94, 34)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(260, 21)
        Me.cboPartNumber.TabIndex = 0
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartDescription
        '
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 61)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(336, 21)
        Me.cboPartDescription.TabIndex = 1
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'AssemblyAddNewSerialNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 256)
        Me.Controls.Add(Me.cboPartDescription)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rdoClosed)
        Me.Controls.Add(Me.rdoOpen)
        Me.Controls.Add(Me.rdoAvailable)
        Me.Controls.Add(Me.cmdAddNew)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.Label4)
        Me.Name = "AssemblyAddNewSerialNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Serial Number"
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents rdoAvailable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOpen As System.Windows.Forms.RadioButton
    Friend WithEvents rdoClosed As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
End Class
