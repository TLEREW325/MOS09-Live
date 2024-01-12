<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WIAScannerSelection
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.pnlPrinters = New System.Windows.Forms.Panel
        Me.cmdPrinter3 = New System.Windows.Forms.Button
        Me.cmdPrinter2 = New System.Windows.Forms.Button
        Me.cmdPrinter1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlPrinters.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(201, 219)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'pnlPrinters
        '
        Me.pnlPrinters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrinters.AutoScroll = True
        Me.pnlPrinters.Controls.Add(Me.cmdPrinter3)
        Me.pnlPrinters.Controls.Add(Me.cmdPrinter2)
        Me.pnlPrinters.Controls.Add(Me.cmdPrinter1)
        Me.pnlPrinters.Location = New System.Drawing.Point(13, 50)
        Me.pnlPrinters.Name = "pnlPrinters"
        Me.pnlPrinters.Size = New System.Drawing.Size(259, 163)
        Me.pnlPrinters.TabIndex = 1
        '
        'cmdPrinter3
        '
        Me.cmdPrinter3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrinter3.Location = New System.Drawing.Point(15, 115)
        Me.cmdPrinter3.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdPrinter3.Name = "cmdPrinter3"
        Me.cmdPrinter3.Size = New System.Drawing.Size(232, 40)
        Me.cmdPrinter3.TabIndex = 4
        Me.cmdPrinter3.Text = "Printer 3"
        Me.cmdPrinter3.UseVisualStyleBackColor = True
        Me.cmdPrinter3.Visible = False
        '
        'cmdPrinter2
        '
        Me.cmdPrinter2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrinter2.Location = New System.Drawing.Point(15, 65)
        Me.cmdPrinter2.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdPrinter2.Name = "cmdPrinter2"
        Me.cmdPrinter2.Size = New System.Drawing.Size(232, 40)
        Me.cmdPrinter2.TabIndex = 3
        Me.cmdPrinter2.Text = "Printer 2"
        Me.cmdPrinter2.UseVisualStyleBackColor = True
        '
        'cmdPrinter1
        '
        Me.cmdPrinter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrinter1.Location = New System.Drawing.Point(15, 15)
        Me.cmdPrinter1.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdPrinter1.Name = "cmdPrinter1"
        Me.cmdPrinter1.Size = New System.Drawing.Size(232, 40)
        Me.cmdPrinter1.TabIndex = 2
        Me.cmdPrinter1.Text = "Printer 1"
        Me.cmdPrinter1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 38)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select the scanner"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WIAScannerSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlPrinters)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = New System.Drawing.Size(300, 900)
        Me.Name = "WIAScannerSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WIA Scanner Selection"
        Me.TopMost = True
        Me.pnlPrinters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents pnlPrinters As System.Windows.Forms.Panel
    Friend WithEvents cmdPrinter2 As System.Windows.Forms.Button
    Friend WithEvents cmdPrinter1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrinter3 As System.Windows.Forms.Button
End Class
