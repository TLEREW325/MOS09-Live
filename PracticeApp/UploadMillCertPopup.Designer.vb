<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadMillCertPopup
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
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSteelDiameter = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdSelectFile = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtUploadPath = New System.Windows.Forms.TextBox
        Me.ofdSelectFile = New System.Windows.Forms.OpenFileDialog
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.txtSourcePath = New System.Windows.Forms.TextBox
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Location = New System.Drawing.Point(24, 120)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(248, 20)
        Me.txtHeatNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Heat #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(24, 59)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(248, 21)
        Me.cboSteelVendor.TabIndex = 0
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Steel Vendor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelDiameter
        '
        Me.txtSteelDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDiameter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDiameter.Location = New System.Drawing.Point(24, 185)
        Me.txtSteelDiameter.Name = "txtSteelDiameter"
        Me.txtSteelDiameter.Size = New System.Drawing.Size(138, 20)
        Me.txtSteelDiameter.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Steel Diameter"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectFile
        '
        Me.cmdSelectFile.Location = New System.Drawing.Point(24, 234)
        Me.cmdSelectFile.Name = "cmdSelectFile"
        Me.cmdSelectFile.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectFile.TabIndex = 3
        Me.cmdSelectFile.Text = "Select File"
        Me.cmdSelectFile.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(124, 441)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(201, 441)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtUploadPath
        '
        Me.txtUploadPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUploadPath.Enabled = False
        Me.txtUploadPath.Location = New System.Drawing.Point(24, 263)
        Me.txtUploadPath.Multiline = True
        Me.txtUploadPath.Name = "txtUploadPath"
        Me.txtUploadPath.ReadOnly = True
        Me.txtUploadPath.Size = New System.Drawing.Size(248, 65)
        Me.txtUploadPath.TabIndex = 9
        '
        'ofdSelectFile
        '
        Me.ofdSelectFile.FileName = "Mill Cert Name"
        Me.ofdSelectFile.Filter = "PDF Files|*.pdf|All Files|*.*"
        Me.ofdSelectFile.InitialDirectory = "C:\Users\%%\Documents\Visual Studio 2008"
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'txtSourcePath
        '
        Me.txtSourcePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSourcePath.Enabled = False
        Me.txtSourcePath.Location = New System.Drawing.Point(24, 357)
        Me.txtSourcePath.Multiline = True
        Me.txtSourcePath.Name = "txtSourcePath"
        Me.txtSourcePath.ReadOnly = True
        Me.txtSourcePath.Size = New System.Drawing.Size(248, 65)
        Me.txtSourcePath.TabIndex = 10
        '
        'UploadMillCertPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 491)
        Me.Controls.Add(Me.txtSourcePath)
        Me.Controls.Add(Me.txtUploadPath)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSelectFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSteelDiameter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSteelVendor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHeatNumber)
        Me.Name = "UploadMillCertPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Upload Mill Cert"
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSteelDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectFile As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtUploadPath As System.Windows.Forms.TextBox
    Friend WithEvents ofdSelectFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents txtSourcePath As System.Windows.Forms.TextBox
End Class
