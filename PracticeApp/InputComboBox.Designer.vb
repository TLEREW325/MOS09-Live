<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputComboBox
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
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboInputValue = New System.Windows.Forms.ComboBox
        Me.lblInputType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdEnter
        '
        Me.cmdEnter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnter.Location = New System.Drawing.Point(73, 72)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnter.TabIndex = 1
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(150, 72)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboInputValue
        '
        Me.cboInputValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInputValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInputValue.FormattingEnabled = True
        Me.cboInputValue.Location = New System.Drawing.Point(12, 45)
        Me.cboInputValue.Name = "cboInputValue"
        Me.cboInputValue.Size = New System.Drawing.Size(209, 21)
        Me.cboInputValue.TabIndex = 0
        '
        'lblInputType
        '
        Me.lblInputType.AutoSize = True
        Me.lblInputType.Location = New System.Drawing.Point(12, 20)
        Me.lblInputType.Name = "lblInputType"
        Me.lblInputType.Size = New System.Drawing.Size(39, 13)
        Me.lblInputType.TabIndex = 3
        Me.lblInputType.Text = "Label1"
        '
        'InputComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 124)
        Me.Controls.Add(Me.lblInputType)
        Me.Controls.Add(Me.cboInputValue)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdEnter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputComboBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input ComboBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboInputValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblInputType As System.Windows.Forms.Label

End Class
