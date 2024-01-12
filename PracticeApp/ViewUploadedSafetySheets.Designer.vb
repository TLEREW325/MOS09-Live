<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUploadedSafetySheets
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.rdoCarbonSteel = New System.Windows.Forms.RadioButton
        Me.rdoStainlessSteel = New System.Windows.Forms.RadioButton
        Me.rdoFerrules = New System.Windows.Forms.RadioButton
        Me.rdoNickel = New System.Windows.Forms.RadioButton
        Me.rdoWeldTiles = New System.Windows.Forms.RadioButton
        Me.cmdView = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(409, 335)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'rdoCarbonSteel
        '
        Me.rdoCarbonSteel.AutoSize = True
        Me.rdoCarbonSteel.Checked = True
        Me.rdoCarbonSteel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCarbonSteel.Location = New System.Drawing.Point(33, 57)
        Me.rdoCarbonSteel.Name = "rdoCarbonSteel"
        Me.rdoCarbonSteel.Size = New System.Drawing.Size(199, 20)
        Me.rdoCarbonSteel.TabIndex = 8
        Me.rdoCarbonSteel.TabStop = True
        Me.rdoCarbonSteel.Text = "Carbon Steel Weld Studs"
        Me.rdoCarbonSteel.UseVisualStyleBackColor = True
        '
        'rdoStainlessSteel
        '
        Me.rdoStainlessSteel.AutoSize = True
        Me.rdoStainlessSteel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoStainlessSteel.Location = New System.Drawing.Point(33, 122)
        Me.rdoStainlessSteel.Name = "rdoStainlessSteel"
        Me.rdoStainlessSteel.Size = New System.Drawing.Size(213, 20)
        Me.rdoStainlessSteel.TabIndex = 9
        Me.rdoStainlessSteel.TabStop = True
        Me.rdoStainlessSteel.Text = "Stainless Steel Weld Studs"
        Me.rdoStainlessSteel.UseVisualStyleBackColor = True
        '
        'rdoFerrules
        '
        Me.rdoFerrules.AutoSize = True
        Me.rdoFerrules.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFerrules.Location = New System.Drawing.Point(33, 252)
        Me.rdoFerrules.Name = "rdoFerrules"
        Me.rdoFerrules.Size = New System.Drawing.Size(83, 20)
        Me.rdoFerrules.TabIndex = 11
        Me.rdoFerrules.TabStop = True
        Me.rdoFerrules.Text = "Ferrules"
        Me.rdoFerrules.UseVisualStyleBackColor = True
        '
        'rdoNickel
        '
        Me.rdoNickel.AutoSize = True
        Me.rdoNickel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNickel.Location = New System.Drawing.Point(33, 187)
        Me.rdoNickel.Name = "rdoNickel"
        Me.rdoNickel.Size = New System.Drawing.Size(203, 20)
        Me.rdoNickel.TabIndex = 10
        Me.rdoNickel.TabStop = True
        Me.rdoNickel.Text = "Nickel-Plated Weld Studs"
        Me.rdoNickel.UseVisualStyleBackColor = True
        '
        'rdoWeldTiles
        '
        Me.rdoWeldTiles.AutoSize = True
        Me.rdoWeldTiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoWeldTiles.Location = New System.Drawing.Point(33, 317)
        Me.rdoWeldTiles.Name = "rdoWeldTiles"
        Me.rdoWeldTiles.Size = New System.Drawing.Size(122, 20)
        Me.rdoWeldTiles.TabIndex = 12
        Me.rdoWeldTiles.TabStop = True
        Me.rdoWeldTiles.Text = "Welding Tiles"
        Me.rdoWeldTiles.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdView.Location = New System.Drawing.Point(332, 335)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 13
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'ViewUploadedSafetySheets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 387)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.rdoWeldTiles)
        Me.Controls.Add(Me.rdoFerrules)
        Me.Controls.Add(Me.rdoNickel)
        Me.Controls.Add(Me.rdoStainlessSteel)
        Me.Controls.Add(Me.rdoCarbonSteel)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "ViewUploadedSafetySheets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Safety Data Shets"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents rdoCarbonSteel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoStainlessSteel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFerrules As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNickel As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWeldTiles As System.Windows.Forms.RadioButton
    Friend WithEvents cmdView As System.Windows.Forms.Button
End Class
