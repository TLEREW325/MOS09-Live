<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblyAddAvailableSerialNumbers
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdAddSerialNumbers = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFirstSerialNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumberOfLabels = New System.Windows.Forms.TextBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.txtText = New System.Windows.Forms.TextBox
        Me.cmdTestCode = New System.Windows.Forms.Button
        Me.txtTestCode = New System.Windows.Forms.TextBox
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(409, 221)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdAddSerialNumbers
        '
        Me.cmdAddSerialNumbers.Location = New System.Drawing.Point(252, 221)
        Me.cmdAddSerialNumbers.Name = "cmdAddSerialNumbers"
        Me.cmdAddSerialNumbers.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSerialNumbers.TabIndex = 4
        Me.cmdAddSerialNumbers.Text = "Add"
        Me.cmdAddSerialNumbers.UseVisualStyleBackColor = True
        Me.cmdAddSerialNumbers.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Enter First Serial #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFirstSerialNumber
        '
        Me.txtFirstSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstSerialNumber.Location = New System.Drawing.Point(198, 134)
        Me.txtFirstSerialNumber.Name = "txtFirstSerialNumber"
        Me.txtFirstSerialNumber.Size = New System.Drawing.Size(242, 20)
        Me.txtFirstSerialNumber.TabIndex = 2
        Me.txtFirstSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Enter # of Labels"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfLabels
        '
        Me.txtNumberOfLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfLabels.Location = New System.Drawing.Point(198, 170)
        Me.txtNumberOfLabels.Name = "txtNumberOfLabels"
        Me.txtNumberOfLabels.Size = New System.Drawing.Size(141, 20)
        Me.txtNumberOfLabels.TabIndex = 3
        Me.txtNumberOfLabels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(157, 43)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(283, 21)
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
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(74, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(74, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDescription
        '
        Me.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDescription.DataSource = Me.ItemListBindingSource
        Me.cboDescription.DisplayMember = "ShortDescription"
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(77, 76)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(363, 21)
        Me.cboDescription.TabIndex = 1
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'txtText
        '
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(12, 221)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(141, 20)
        Me.txtText.TabIndex = 44
        Me.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtText.Visible = False
        '
        'cmdTestCode
        '
        Me.cmdTestCode.Location = New System.Drawing.Point(329, 221)
        Me.cmdTestCode.Name = "cmdTestCode"
        Me.cmdTestCode.Size = New System.Drawing.Size(74, 40)
        Me.cmdTestCode.TabIndex = 45
        Me.cmdTestCode.Text = "Add"
        Me.cmdTestCode.UseVisualStyleBackColor = True
        '
        'txtTestCode
        '
        Me.txtTestCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTestCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTestCode.Location = New System.Drawing.Point(12, 243)
        Me.txtTestCode.Name = "txtTestCode"
        Me.txtTestCode.Size = New System.Drawing.Size(141, 20)
        Me.txtTestCode.TabIndex = 46
        Me.txtTestCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTestCode.Visible = False
        '
        'AssemblyAddAvailableSerialNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 274)
        Me.Controls.Add(Me.txtTestCode)
        Me.Controls.Add(Me.cmdTestCode)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.cboDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumberOfLabels)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFirstSerialNumber)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdAddSerialNumbers)
        Me.Name = "AssemblyAddAvailableSerialNumbers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Add Serial Numbers"
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdAddSerialNumbers As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfLabels As System.Windows.Forms.TextBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents cmdTestCode As System.Windows.Forms.Button
    Friend WithEvents txtTestCode As System.Windows.Forms.TextBox
End Class
