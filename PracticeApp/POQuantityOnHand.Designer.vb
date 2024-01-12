<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POQuantityOnHand
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.lblPartDescription = New System.Windows.Forms.Label
        Me.lblQOH = New System.Windows.Forms.Label
        Me.lblQuantityCommitted = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Quantity On Hand"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Quantity Committed"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BackColor = System.Drawing.Color.White
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNumber.Location = New System.Drawing.Point(81, 11)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(199, 20)
        Me.lblPartNumber.TabIndex = 4
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BackColor = System.Drawing.Color.White
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.ForeColor = System.Drawing.Color.Blue
        Me.lblPartDescription.Location = New System.Drawing.Point(12, 42)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Size = New System.Drawing.Size(268, 49)
        Me.lblPartDescription.TabIndex = 5
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQOH
        '
        Me.lblQOH.BackColor = System.Drawing.Color.White
        Me.lblQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblQOH.Location = New System.Drawing.Point(146, 105)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(134, 20)
        Me.lblQOH.TabIndex = 6
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuantityCommitted
        '
        Me.lblQuantityCommitted.BackColor = System.Drawing.Color.White
        Me.lblQuantityCommitted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuantityCommitted.ForeColor = System.Drawing.Color.Blue
        Me.lblQuantityCommitted.Location = New System.Drawing.Point(146, 138)
        Me.lblQuantityCommitted.Name = "lblQuantityCommitted"
        Me.lblQuantityCommitted.Size = New System.Drawing.Size(134, 20)
        Me.lblQuantityCommitted.TabIndex = 7
        Me.lblQuantityCommitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'POQuantityOnHand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 173)
        Me.Controls.Add(Me.lblQuantityCommitted)
        Me.Controls.Add(Me.lblQOH)
        Me.Controls.Add(Me.lblPartDescription)
        Me.Controls.Add(Me.lblPartNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "POQuantityOnHand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Part Number Details"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents lblPartDescription As System.Windows.Forms.Label
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents lblQuantityCommitted As System.Windows.Forms.Label
End Class
