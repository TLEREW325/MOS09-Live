<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadSDS
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
        Me.lblName = New System.Windows.Forms.Label
        Me.cboName = New System.Windows.Forms.ComboBox
        Me.lblFileName = New System.Windows.Forms.Label
        Me.cmdSelectFile = New System.Windows.Forms.Button
        Me.lblFile = New System.Windows.Forms.Label
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(35, 44)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        '
        'cboName
        '
        Me.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboName.FormattingEnabled = True
        Me.cboName.Location = New System.Drawing.Point(108, 41)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(164, 21)
        Me.cboName.TabIndex = 1
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(35, 91)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(23, 13)
        Me.lblFileName.TabIndex = 2
        Me.lblFileName.Text = "File"
        '
        'cmdSelectFile
        '
        Me.cmdSelectFile.Location = New System.Drawing.Point(108, 127)
        Me.cmdSelectFile.Name = "cmdSelectFile"
        Me.cmdSelectFile.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectFile.TabIndex = 3
        Me.cmdSelectFile.Text = "Select File"
        Me.cmdSelectFile.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFile.Location = New System.Drawing.Point(108, 90)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(164, 23)
        Me.lblFile.TabIndex = 4
        '
        'cmdUpload
        '
        Me.cmdUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUpload.Location = New System.Drawing.Point(108, 173)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpload.TabIndex = 6
        Me.cmdUpload.Text = "Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(201, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'UploadSDS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 225)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdUpload)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.cmdSelectFile)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.cboName)
        Me.Controls.Add(Me.lblName)
        Me.Name = "UploadSDS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Safety Data Sheet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents cmdSelectFile As System.Windows.Forms.Button
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
