<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestScan
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
        Me.cmdScan = New System.Windows.Forms.Button
        Me.pbxScannedImage = New System.Windows.Forms.PictureBox
        Me.cboCustomer = New System.Windows.Forms.ComboBox
        Me.cboFoxNumber = New System.Windows.Forms.ComboBox
        Me.txtBlueprintNumber = New System.Windows.Forms.TextBox
        Me.txtRevision = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdLoadImage = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.pbxScannedImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdScan
        '
        Me.cmdScan.Location = New System.Drawing.Point(31, 42)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(102, 58)
        Me.cmdScan.TabIndex = 0
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'pbxScannedImage
        '
        Me.pbxScannedImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxScannedImage.Location = New System.Drawing.Point(309, 42)
        Me.pbxScannedImage.Name = "pbxScannedImage"
        Me.pbxScannedImage.Size = New System.Drawing.Size(507, 703)
        Me.pbxScannedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxScannedImage.TabIndex = 1
        Me.pbxScannedImage.TabStop = False
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(31, 254)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(207, 21)
        Me.cboCustomer.TabIndex = 2
        '
        'cboFoxNumber
        '
        Me.cboFoxNumber.FormattingEnabled = True
        Me.cboFoxNumber.Location = New System.Drawing.Point(31, 329)
        Me.cboFoxNumber.Name = "cboFoxNumber"
        Me.cboFoxNumber.Size = New System.Drawing.Size(207, 21)
        Me.cboFoxNumber.TabIndex = 3
        '
        'txtBlueprintNumber
        '
        Me.txtBlueprintNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlueprintNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBlueprintNumber.Location = New System.Drawing.Point(31, 404)
        Me.txtBlueprintNumber.Name = "txtBlueprintNumber"
        Me.txtBlueprintNumber.Size = New System.Drawing.Size(209, 20)
        Me.txtBlueprintNumber.TabIndex = 4
        '
        'txtRevision
        '
        Me.txtRevision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRevision.Location = New System.Drawing.Point(31, 478)
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Size = New System.Drawing.Size(209, 20)
        Me.txtRevision.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(31, 228)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(31, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(207, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "FOX Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(31, 378)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Blueprint #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(31, 454)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(207, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Revision Level"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(116, 567)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(80, 50)
        Me.cmdNext.TabIndex = 10
        Me.cmdNext.Text = "NEXT"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Location = New System.Drawing.Point(30, 567)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(80, 50)
        Me.cmdPrevious.TabIndex = 11
        Me.cmdPrevious.Text = "PREVIOUS"
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'cmdLoadImage
        '
        Me.cmdLoadImage.Location = New System.Drawing.Point(31, 121)
        Me.cmdLoadImage.Name = "cmdLoadImage"
        Me.cmdLoadImage.Size = New System.Drawing.Size(102, 58)
        Me.cmdLoadImage.TabIndex = 12
        Me.cmdLoadImage.Text = "Load Image"
        Me.cmdLoadImage.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(30, 711)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 50)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'TestScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 773)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdLoadImage)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRevision)
        Me.Controls.Add(Me.txtBlueprintNumber)
        Me.Controls.Add(Me.cboFoxNumber)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.pbxScannedImage)
        Me.Controls.Add(Me.cmdScan)
        Me.Name = "TestScan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TestScan"
        CType(Me.pbxScannedImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents pbxScannedImage As System.Windows.Forms.PictureBox
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cboFoxNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtBlueprintNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdLoadImage As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
