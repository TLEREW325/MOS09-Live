<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RackingLocations
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
        Me.components = New System.ComponentModel.Container
        Me.dgvRackingLocations = New System.Windows.Forms.DataGridView
        Me.RackingTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.RackingTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.pnlTablet = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdTwo = New System.Windows.Forms.Button
        Me.txtCellValue = New System.Windows.Forms.TextBox
        Me.cmdUpdateCell = New System.Windows.Forms.Button
        Me.cmdZero = New System.Windows.Forms.Button
        Me.cmdThree = New System.Windows.Forms.Button
        Me.cmdFour = New System.Windows.Forms.Button
        Me.cmdNine = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEight = New System.Windows.Forms.Button
        Me.cmdFive = New System.Windows.Forms.Button
        Me.cmdOne = New System.Windows.Forms.Button
        Me.cmdSix = New System.Windows.Forms.Button
        Me.cmdSeven = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        CType(Me.dgvRackingLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTablet.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRackingLocations
        '
        Me.dgvRackingLocations.AllowUserToAddRows = False
        Me.dgvRackingLocations.AllowUserToDeleteRows = False
        Me.dgvRackingLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRackingLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingLocations.Location = New System.Drawing.Point(13, 27)
        Me.dgvRackingLocations.Name = "dgvRackingLocations"
        Me.dgvRackingLocations.Size = New System.Drawing.Size(840, 684)
        Me.dgvRackingLocations.TabIndex = 0
        '
        'RackingTransactionTableBindingSource
        '
        Me.RackingTransactionTableBindingSource.DataMember = "RackingTransactionTable"
        Me.RackingTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RackingTransactionTableTableAdapter
        '
        Me.RackingTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(963, 504)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(150, 50)
        Me.cmdUpdate.TabIndex = 37
        Me.cmdUpdate.Text = "Update Table"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'pnlTablet
        '
        Me.pnlTablet.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pnlTablet.Controls.Add(Me.Label1)
        Me.pnlTablet.Controls.Add(Me.cmdTwo)
        Me.pnlTablet.Controls.Add(Me.txtCellValue)
        Me.pnlTablet.Controls.Add(Me.cmdUpdateCell)
        Me.pnlTablet.Controls.Add(Me.cmdZero)
        Me.pnlTablet.Controls.Add(Me.cmdThree)
        Me.pnlTablet.Controls.Add(Me.cmdFour)
        Me.pnlTablet.Controls.Add(Me.cmdNine)
        Me.pnlTablet.Controls.Add(Me.cmdClear)
        Me.pnlTablet.Controls.Add(Me.cmdEight)
        Me.pnlTablet.Controls.Add(Me.cmdFive)
        Me.pnlTablet.Controls.Add(Me.cmdOne)
        Me.pnlTablet.Controls.Add(Me.cmdSix)
        Me.pnlTablet.Controls.Add(Me.cmdSeven)
        Me.pnlTablet.Location = New System.Drawing.Point(877, 106)
        Me.pnlTablet.Name = "pnlTablet"
        Me.pnlTablet.Size = New System.Drawing.Size(316, 395)
        Me.pnlTablet.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Enter Cell Value"
        '
        'cmdTwo
        '
        Me.cmdTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTwo.Location = New System.Drawing.Point(161, 62)
        Me.cmdTwo.Name = "cmdTwo"
        Me.cmdTwo.Size = New System.Drawing.Size(142, 50)
        Me.cmdTwo.TabIndex = 31
        Me.cmdTwo.Text = "2"
        Me.cmdTwo.UseVisualStyleBackColor = True
        '
        'txtCellValue
        '
        Me.txtCellValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCellValue.Location = New System.Drawing.Point(71, 31)
        Me.txtCellValue.Name = "txtCellValue"
        Me.txtCellValue.Size = New System.Drawing.Size(165, 26)
        Me.txtCellValue.TabIndex = 42
        '
        'cmdUpdateCell
        '
        Me.cmdUpdateCell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateCell.Location = New System.Drawing.Point(161, 342)
        Me.cmdUpdateCell.Name = "cmdUpdateCell"
        Me.cmdUpdateCell.Size = New System.Drawing.Size(142, 50)
        Me.cmdUpdateCell.TabIndex = 43
        Me.cmdUpdateCell.Text = "Edit Cell"
        Me.cmdUpdateCell.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(161, 286)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(142, 50)
        Me.cmdZero.TabIndex = 35
        Me.cmdZero.Text = "0"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdThree
        '
        Me.cmdThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThree.Location = New System.Drawing.Point(5, 118)
        Me.cmdThree.Name = "cmdThree"
        Me.cmdThree.Size = New System.Drawing.Size(150, 50)
        Me.cmdThree.TabIndex = 32
        Me.cmdThree.Text = "3"
        Me.cmdThree.UseVisualStyleBackColor = True
        '
        'cmdFour
        '
        Me.cmdFour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFour.Location = New System.Drawing.Point(161, 118)
        Me.cmdFour.Name = "cmdFour"
        Me.cmdFour.Size = New System.Drawing.Size(142, 50)
        Me.cmdFour.TabIndex = 33
        Me.cmdFour.Text = "4"
        Me.cmdFour.UseVisualStyleBackColor = True
        '
        'cmdNine
        '
        Me.cmdNine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNine.Location = New System.Drawing.Point(5, 286)
        Me.cmdNine.Name = "cmdNine"
        Me.cmdNine.Size = New System.Drawing.Size(150, 50)
        Me.cmdNine.TabIndex = 41
        Me.cmdNine.Text = "9"
        Me.cmdNine.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(5, 342)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(150, 50)
        Me.cmdClear.TabIndex = 36
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEight
        '
        Me.cmdEight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEight.Location = New System.Drawing.Point(161, 230)
        Me.cmdEight.Name = "cmdEight"
        Me.cmdEight.Size = New System.Drawing.Size(142, 50)
        Me.cmdEight.TabIndex = 40
        Me.cmdEight.Text = "8"
        Me.cmdEight.UseVisualStyleBackColor = True
        '
        'cmdFive
        '
        Me.cmdFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFive.Location = New System.Drawing.Point(5, 174)
        Me.cmdFive.Name = "cmdFive"
        Me.cmdFive.Size = New System.Drawing.Size(150, 50)
        Me.cmdFive.TabIndex = 34
        Me.cmdFive.Text = "5"
        Me.cmdFive.UseVisualStyleBackColor = True
        '
        'cmdOne
        '
        Me.cmdOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOne.Location = New System.Drawing.Point(5, 63)
        Me.cmdOne.Name = "cmdOne"
        Me.cmdOne.Size = New System.Drawing.Size(150, 50)
        Me.cmdOne.TabIndex = 30
        Me.cmdOne.Text = "1"
        Me.cmdOne.UseVisualStyleBackColor = True
        '
        'cmdSix
        '
        Me.cmdSix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSix.Location = New System.Drawing.Point(161, 174)
        Me.cmdSix.Name = "cmdSix"
        Me.cmdSix.Size = New System.Drawing.Size(142, 50)
        Me.cmdSix.TabIndex = 38
        Me.cmdSix.Text = "6"
        Me.cmdSix.UseVisualStyleBackColor = True
        '
        'cmdSeven
        '
        Me.cmdSeven.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeven.Location = New System.Drawing.Point(5, 230)
        Me.cmdSeven.Name = "cmdSeven"
        Me.cmdSeven.Size = New System.Drawing.Size(150, 50)
        Me.cmdSeven.TabIndex = 39
        Me.cmdSeven.Text = "7"
        Me.cmdSeven.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1192, 24)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem1
        '
        Me.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        Me.PrintToolStripMenuItem1.Size = New System.Drawing.Size(96, 22)
        Me.PrintToolStripMenuItem1.Text = "Print"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseWindowToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CloseWindowToolStripMenuItem
        '
        Me.CloseWindowToolStripMenuItem.Name = "CloseWindowToolStripMenuItem"
        Me.CloseWindowToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.CloseWindowToolStripMenuItem.Text = "Close Window"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmdExit.Location = New System.Drawing.Point(1038, 661)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(150, 50)
        Me.cmdExit.TabIndex = 39
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 661)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(150, 50)
        Me.cmdPrint.TabIndex = 40
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'RackingLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 723)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.pnlTablet)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.dgvRackingLocations)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RackingLocations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  TFP Inventory Count"
        CType(Me.dgvRackingLocations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTablet.ResumeLayout(False)
        Me.pnlTablet.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRackingLocations As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RackingTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionTableTableAdapter
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents pnlTablet As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdTwo As System.Windows.Forms.Button
    Friend WithEvents txtCellValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdateCell As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdThree As System.Windows.Forms.Button
    Friend WithEvents cmdFour As System.Windows.Forms.Button
    Friend WithEvents cmdNine As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEight As System.Windows.Forms.Button
    Friend WithEvents cmdFive As System.Windows.Forms.Button
    Friend WithEvents cmdOne As System.Windows.Forms.Button
    Friend WithEvents cmdSix As System.Windows.Forms.Button
    Friend WithEvents cmdSeven As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents CloseWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
