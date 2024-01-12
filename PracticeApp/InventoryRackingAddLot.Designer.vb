<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryRackingAddLot
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotalPieces = New System.Windows.Forms.Label
        Me.txtBoxes = New System.Windows.Forms.TextBox
        Me.txtPiecesPerBox = New System.Windows.Forms.TextBox
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lot Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Boxes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pieces Per Box"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total Pieces"
        '
        'lblTotalPieces
        '
        Me.lblTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPieces.Location = New System.Drawing.Point(148, 153)
        Me.lblTotalPieces.Name = "lblTotalPieces"
        Me.lblTotalPieces.Size = New System.Drawing.Size(121, 20)
        Me.lblTotalPieces.TabIndex = 4
        Me.lblTotalPieces.Text = "0"
        Me.lblTotalPieces.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBoxes
        '
        Me.txtBoxes.Location = New System.Drawing.Point(148, 74)
        Me.txtBoxes.Name = "txtBoxes"
        Me.txtBoxes.Size = New System.Drawing.Size(121, 20)
        Me.txtBoxes.TabIndex = 1
        Me.txtBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPiecesPerBox
        '
        Me.txtPiecesPerBox.Location = New System.Drawing.Point(148, 112)
        Me.txtPiecesPerBox.Name = "txtPiecesPerBox"
        Me.txtPiecesPerBox.Size = New System.Drawing.Size(121, 20)
        Me.txtPiecesPerBox.TabIndex = 2
        Me.txtPiecesPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(148, 34)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(121, 21)
        Me.cboLotNumber.TabIndex = 0
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(121, 208)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 3
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(198, 208)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'InventoryRackingAddLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cboLotNumber)
        Me.Controls.Add(Me.txtPiecesPerBox)
        Me.Controls.Add(Me.txtBoxes)
        Me.Controls.Add(Me.lblTotalPieces)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "InventoryRackingAddLot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Lot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPieces As System.Windows.Forms.Label
    Friend WithEvents txtBoxes As System.Windows.Forms.TextBox
    Friend WithEvents txtPiecesPerBox As System.Windows.Forms.TextBox
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
