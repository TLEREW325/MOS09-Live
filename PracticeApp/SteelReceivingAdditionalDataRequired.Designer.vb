<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelReceivingAdditionalDataRequired
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
        Me.cmdNext = New System.Windows.Forms.Button
        Me.lblQuestion = New System.Windows.Forms.Label
        Me.txtCoilCount = New System.Windows.Forms.TextBox
        Me.txtCoilWeight = New System.Windows.Forms.TextBox
        Me.txtCoilID = New System.Windows.Forms.TextBox
        Me.txtCoilHeat = New System.Windows.Forms.TextBox
        Me.lblCoilID = New System.Windows.Forms.Label
        Me.lblCoilWeight = New System.Windows.Forms.Label
        Me.lblCoilHeat = New System.Windows.Forms.Label
        Me.lblCoilCount = New System.Windows.Forms.Label
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.cmdQuit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.Location = New System.Drawing.Point(99, 162)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(71, 40)
        Me.cmdNext.TabIndex = 3
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'lblQuestion
        '
        Me.lblQuestion.Location = New System.Drawing.Point(98, 69)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(192, 35)
        Me.lblQuestion.TabIndex = 18
        Me.lblQuestion.Text = "How many Coils for "
        '
        'txtCoilCount
        '
        Me.txtCoilCount.Location = New System.Drawing.Point(136, 118)
        Me.txtCoilCount.Name = "txtCoilCount"
        Me.txtCoilCount.Size = New System.Drawing.Size(100, 20)
        Me.txtCoilCount.TabIndex = 0
        '
        'txtCoilWeight
        '
        Me.txtCoilWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilWeight.Location = New System.Drawing.Point(136, 92)
        Me.txtCoilWeight.Name = "txtCoilWeight"
        Me.txtCoilWeight.Size = New System.Drawing.Size(100, 20)
        Me.txtCoilWeight.TabIndex = 1
        Me.txtCoilWeight.Visible = False
        '
        'txtCoilID
        '
        Me.txtCoilID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilID.Location = New System.Drawing.Point(136, 66)
        Me.txtCoilID.Name = "txtCoilID"
        Me.txtCoilID.Size = New System.Drawing.Size(100, 20)
        Me.txtCoilID.TabIndex = 0
        Me.txtCoilID.Visible = False
        '
        'txtCoilHeat
        '
        Me.txtCoilHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCoilHeat.Location = New System.Drawing.Point(136, 118)
        Me.txtCoilHeat.Name = "txtCoilHeat"
        Me.txtCoilHeat.Size = New System.Drawing.Size(100, 20)
        Me.txtCoilHeat.TabIndex = 2
        Me.txtCoilHeat.Visible = False
        '
        'lblCoilID
        '
        Me.lblCoilID.AutoSize = True
        Me.lblCoilID.Location = New System.Drawing.Point(69, 69)
        Me.lblCoilID.Name = "lblCoilID"
        Me.lblCoilID.Size = New System.Drawing.Size(38, 13)
        Me.lblCoilID.TabIndex = 23
        Me.lblCoilID.Text = "Coil ID"
        Me.lblCoilID.Visible = False
        '
        'lblCoilWeight
        '
        Me.lblCoilWeight.AutoSize = True
        Me.lblCoilWeight.Location = New System.Drawing.Point(69, 95)
        Me.lblCoilWeight.Name = "lblCoilWeight"
        Me.lblCoilWeight.Size = New System.Drawing.Size(61, 13)
        Me.lblCoilWeight.TabIndex = 24
        Me.lblCoilWeight.Text = "Coil Weight"
        Me.lblCoilWeight.Visible = False
        '
        'lblCoilHeat
        '
        Me.lblCoilHeat.AutoSize = True
        Me.lblCoilHeat.Location = New System.Drawing.Point(69, 121)
        Me.lblCoilHeat.Name = "lblCoilHeat"
        Me.lblCoilHeat.Size = New System.Drawing.Size(50, 13)
        Me.lblCoilHeat.TabIndex = 25
        Me.lblCoilHeat.Text = "Coil Heat"
        Me.lblCoilHeat.Visible = False
        '
        'lblCoilCount
        '
        Me.lblCoilCount.AutoSize = True
        Me.lblCoilCount.Location = New System.Drawing.Point(145, 141)
        Me.lblCoilCount.Name = "lblCoilCount"
        Me.lblCoilCount.Size = New System.Drawing.Size(24, 13)
        Me.lblCoilCount.TabIndex = 26
        Me.lblCoilCount.Text = "Coil"
        Me.lblCoilCount.Visible = False
        '
        'lblCarbon
        '
        Me.lblCarbon.AutoSize = True
        Me.lblCarbon.Location = New System.Drawing.Point(98, 22)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(47, 13)
        Me.lblCarbon.TabIndex = 27
        Me.lblCarbon.Text = "Carbon :"
        Me.lblCarbon.Visible = False
        '
        'lblSteelSize
        '
        Me.lblSteelSize.AutoSize = True
        Me.lblSteelSize.Location = New System.Drawing.Point(98, 39)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(60, 13)
        Me.lblSteelSize.TabIndex = 28
        Me.lblSteelSize.Text = "Steel Size :"
        Me.lblSteelSize.Visible = False
        '
        'cmdQuit
        '
        Me.cmdQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdQuit.Location = New System.Drawing.Point(176, 162)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(71, 40)
        Me.cmdQuit.TabIndex = 29
        Me.cmdQuit.Text = "Quit"
        Me.cmdQuit.UseVisualStyleBackColor = True
        '
        'SteelReceivingAdditionalDataRequired
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.lblSteelSize)
        Me.Controls.Add(Me.lblCarbon)
        Me.Controls.Add(Me.lblCoilCount)
        Me.Controls.Add(Me.lblCoilHeat)
        Me.Controls.Add(Me.lblCoilWeight)
        Me.Controls.Add(Me.lblCoilID)
        Me.Controls.Add(Me.txtCoilHeat)
        Me.Controls.Add(Me.txtCoilID)
        Me.Controls.Add(Me.txtCoilWeight)
        Me.Controls.Add(Me.txtCoilCount)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.cmdNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SteelReceivingAdditionalDataRequired"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Receiving Additional Data Required"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents txtCoilCount As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilID As System.Windows.Forms.TextBox
    Friend WithEvents txtCoilHeat As System.Windows.Forms.TextBox
    Friend WithEvents lblCoilID As System.Windows.Forms.Label
    Friend WithEvents lblCoilWeight As System.Windows.Forms.Label
    Friend WithEvents lblCoilHeat As System.Windows.Forms.Label
    Friend WithEvents lblCoilCount As System.Windows.Forms.Label
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
End Class
