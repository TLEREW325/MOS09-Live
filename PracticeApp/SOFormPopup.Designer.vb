<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOFormPopup
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdShipmentForm = New System.Windows.Forms.Button
        Me.cmdSalesOrder = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdShipmentForm)
        Me.GroupBox1.Controls.Add(Me.cmdSalesOrder)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 273)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 66)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Do you wish to return to the Sales Order or go to the Shipment Completion Form?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdShipmentForm
        '
        Me.cmdShipmentForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShipmentForm.ForeColor = System.Drawing.Color.Blue
        Me.cmdShipmentForm.Location = New System.Drawing.Point(248, 146)
        Me.cmdShipmentForm.Name = "cmdShipmentForm"
        Me.cmdShipmentForm.Size = New System.Drawing.Size(75, 41)
        Me.cmdShipmentForm.TabIndex = 1
        Me.cmdShipmentForm.Text = "Shipment Form"
        Me.cmdShipmentForm.UseVisualStyleBackColor = True
        '
        'cmdSalesOrder
        '
        Me.cmdSalesOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalesOrder.ForeColor = System.Drawing.Color.Blue
        Me.cmdSalesOrder.Location = New System.Drawing.Point(167, 146)
        Me.cmdSalesOrder.Name = "cmdSalesOrder"
        Me.cmdSalesOrder.Size = New System.Drawing.Size(75, 41)
        Me.cmdSalesOrder.TabIndex = 0
        Me.cmdSalesOrder.Text = "Sales Order"
        Me.cmdSalesOrder.UseVisualStyleBackColor = True
        '
        'SOFormPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SOFormPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Sales Order"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdShipmentForm As System.Windows.Forms.Button
    Friend WithEvents cmdSalesOrder As System.Windows.Forms.Button
End Class
