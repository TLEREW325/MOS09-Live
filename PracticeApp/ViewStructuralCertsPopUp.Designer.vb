<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewStructuralCertsPopUp
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
        Me.cmdUpload = New System.Windows.Forms.Button()
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtLotNumber = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(196, 106)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(101, 58)
        Me.cmdUpload.TabIndex = 0
        Me.cmdUpload.Text = "Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'cmdScan
        '
        Me.cmdScan.Location = New System.Drawing.Point(37, 106)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(101, 58)
        Me.cmdScan.TabIndex = 1
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(68, 42)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(359, 20)
        Me.lblSelection.TabIndex = 2
        Me.lblSelection.Text = "Please select an option for scanning or uploading."
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(355, 106)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(101, 58)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtLotNumber
        '
        Me.txtLotNumber.Location = New System.Drawing.Point(184, 65)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.ReadOnly = True
        Me.txtLotNumber.Size = New System.Drawing.Size(127, 20)
        Me.txtLotNumber.TabIndex = 4
        '
        'ViewStructuralCertsPopUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 223)
        Me.Controls.Add(Me.txtLotNumber)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblSelection)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.cmdUpload)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewStructuralCertsPopUp"
        Me.Text = "ViewStructuralCertsPopUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
End Class
