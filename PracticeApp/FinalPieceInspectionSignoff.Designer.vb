<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalPieceInspectionSignoff
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
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.txtQcInspector = New System.Windows.Forms.TextBox
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.lblPartNumberText = New System.Windows.Forms.Label
        Me.lblShortDescriptionText = New System.Windows.Forms.Label
        Me.lblFoxNumberText = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblShortDescription = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.lblFoxNumber = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(151, 29)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(223, 21)
        Me.cboLotNumber.TabIndex = 0
        '
        'txtQcInspector
        '
        Me.txtQcInspector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQcInspector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQcInspector.Location = New System.Drawing.Point(151, 60)
        Me.txtQcInspector.Margin = New System.Windows.Forms.Padding(5)
        Me.txtQcInspector.MaxLength = 50
        Me.txtQcInspector.Name = "txtQcInspector"
        Me.txtQcInspector.Size = New System.Drawing.Size(223, 20)
        Me.txtQcInspector.TabIndex = 1
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(151, 271)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'lblPartNumberText
        '
        Me.lblPartNumberText.AutoSize = True
        Me.lblPartNumberText.Location = New System.Drawing.Point(31, 132)
        Me.lblPartNumberText.Margin = New System.Windows.Forms.Padding(5)
        Me.lblPartNumberText.Name = "lblPartNumberText"
        Me.lblPartNumberText.Size = New System.Drawing.Size(66, 13)
        Me.lblPartNumberText.TabIndex = 3
        Me.lblPartNumberText.Text = "Part Number"
        '
        'lblShortDescriptionText
        '
        Me.lblShortDescriptionText.AutoSize = True
        Me.lblShortDescriptionText.Location = New System.Drawing.Point(31, 167)
        Me.lblShortDescriptionText.Margin = New System.Windows.Forms.Padding(5)
        Me.lblShortDescriptionText.Name = "lblShortDescriptionText"
        Me.lblShortDescriptionText.Size = New System.Drawing.Size(88, 13)
        Me.lblShortDescriptionText.TabIndex = 4
        Me.lblShortDescriptionText.Text = "Short Description"
        '
        'lblFoxNumberText
        '
        Me.lblFoxNumberText.AutoSize = True
        Me.lblFoxNumberText.Location = New System.Drawing.Point(31, 99)
        Me.lblFoxNumberText.Margin = New System.Windows.Forms.Padding(5)
        Me.lblFoxNumberText.Name = "lblFoxNumberText"
        Me.lblFoxNumberText.Size = New System.Drawing.Size(64, 13)
        Me.lblFoxNumberText.TabIndex = 5
        Me.lblFoxNumberText.Text = "Fox Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 67)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "QC Inspector"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Lot Number"
        '
        'lblShortDescription
        '
        Me.lblShortDescription.Location = New System.Drawing.Point(151, 167)
        Me.lblShortDescription.Margin = New System.Windows.Forms.Padding(5)
        Me.lblShortDescription.Name = "lblShortDescription"
        Me.lblShortDescription.Size = New System.Drawing.Size(223, 88)
        Me.lblShortDescription.TabIndex = 12
        '
        'lblPartNumber
        '
        Me.lblPartNumber.Location = New System.Drawing.Point(151, 132)
        Me.lblPartNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(223, 13)
        Me.lblPartNumber.TabIndex = 13
        '
        'lblFoxNumber
        '
        Me.lblFoxNumber.Location = New System.Drawing.Point(151, 99)
        Me.lblFoxNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.lblFoxNumber.Name = "lblFoxNumber"
        Me.lblFoxNumber.Size = New System.Drawing.Size(223, 13)
        Me.lblFoxNumber.TabIndex = 14
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(228, 271)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(305, 271)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'FinalPieceInspectionSignoff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 323)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.lblFoxNumber)
        Me.Controls.Add(Me.lblPartNumber)
        Me.Controls.Add(Me.lblShortDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFoxNumberText)
        Me.Controls.Add(Me.lblShortDescriptionText)
        Me.Controls.Add(Me.lblPartNumberText)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.txtQcInspector)
        Me.Controls.Add(Me.cboLotNumber)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FinalPieceInspectionSignoff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FinalPieceInspectionSignoff"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtQcInspector As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents lblPartNumberText As System.Windows.Forms.Label
    Friend WithEvents lblShortDescriptionText As System.Windows.Forms.Label
    Friend WithEvents lblFoxNumberText As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblShortDescription As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents lblFoxNumber As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
