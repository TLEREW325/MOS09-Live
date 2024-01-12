<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOPriceBracket
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPrice1 = New System.Windows.Forms.TextBox
        Me.lblOne = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lblTwo = New System.Windows.Forms.Label
        Me.txtPrice2 = New System.Windows.Forms.TextBox
        Me.lblThree = New System.Windows.Forms.Label
        Me.txtPrice3 = New System.Windows.Forms.TextBox
        Me.lblFour = New System.Windows.Forms.Label
        Me.txtPrice4 = New System.Windows.Forms.TextBox
        Me.lblFive = New System.Windows.Forms.Label
        Me.txtPrice5 = New System.Windows.Forms.TextBox
        Me.lblSix = New System.Windows.Forms.Label
        Me.txtPrice6 = New System.Windows.Forms.TextBox
        Me.lblSeven = New System.Windows.Forms.Label
        Me.txtPrice7 = New System.Windows.Forms.TextBox
        Me.lblEight = New System.Windows.Forms.Label
        Me.txtPrice8 = New System.Windows.Forms.TextBox
        Me.lblEleven = New System.Windows.Forms.Label
        Me.txtPrice11 = New System.Windows.Forms.TextBox
        Me.lblTen = New System.Windows.Forms.Label
        Me.txtPrice10 = New System.Windows.Forms.TextBox
        Me.lblNine = New System.Windows.Forms.Label
        Me.txtPrice9 = New System.Windows.Forms.TextBox
        Me.lblThirteen = New System.Windows.Forms.Label
        Me.txtPrice13 = New System.Windows.Forms.TextBox
        Me.lblTwelve = New System.Windows.Forms.Label
        Me.txtPrice12 = New System.Windows.Forms.TextBox
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(292, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(54, 42)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(226, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(12, 69)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(268, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Part #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice1
        '
        Me.txtPrice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice1.Location = New System.Drawing.Point(139, 106)
        Me.txtPrice1.Name = "txtPrice1"
        Me.txtPrice1.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice1.TabIndex = 4
        Me.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOne
        '
        Me.lblOne.Location = New System.Drawing.Point(12, 105)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(145, 23)
        Me.lblOne.TabIndex = 5
        Me.lblOne.Text = "100 to 199 pcs."
        Me.lblOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'lblTwo
        '
        Me.lblTwo.Location = New System.Drawing.Point(12, 131)
        Me.lblTwo.Name = "lblTwo"
        Me.lblTwo.Size = New System.Drawing.Size(145, 23)
        Me.lblTwo.TabIndex = 7
        Me.lblTwo.Text = "200 to 299 pcs."
        Me.lblTwo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice2
        '
        Me.txtPrice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice2.Location = New System.Drawing.Point(139, 132)
        Me.txtPrice2.Name = "txtPrice2"
        Me.txtPrice2.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice2.TabIndex = 6
        Me.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThree
        '
        Me.lblThree.Location = New System.Drawing.Point(12, 157)
        Me.lblThree.Name = "lblThree"
        Me.lblThree.Size = New System.Drawing.Size(145, 23)
        Me.lblThree.TabIndex = 9
        Me.lblThree.Text = "300 to 399 pcs."
        Me.lblThree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice3
        '
        Me.txtPrice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice3.Location = New System.Drawing.Point(139, 158)
        Me.txtPrice3.Name = "txtPrice3"
        Me.txtPrice3.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice3.TabIndex = 8
        Me.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFour
        '
        Me.lblFour.Location = New System.Drawing.Point(12, 184)
        Me.lblFour.Name = "lblFour"
        Me.lblFour.Size = New System.Drawing.Size(145, 23)
        Me.lblFour.TabIndex = 11
        Me.lblFour.Text = "400 to 499 pcs."
        Me.lblFour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice4
        '
        Me.txtPrice4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice4.Location = New System.Drawing.Point(139, 184)
        Me.txtPrice4.Name = "txtPrice4"
        Me.txtPrice4.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice4.TabIndex = 10
        Me.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFive
        '
        Me.lblFive.Location = New System.Drawing.Point(12, 209)
        Me.lblFive.Name = "lblFive"
        Me.lblFive.Size = New System.Drawing.Size(145, 23)
        Me.lblFive.TabIndex = 13
        Me.lblFive.Text = "500 to 749 pcs."
        Me.lblFive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice5
        '
        Me.txtPrice5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice5.Location = New System.Drawing.Point(139, 210)
        Me.txtPrice5.Name = "txtPrice5"
        Me.txtPrice5.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice5.TabIndex = 12
        Me.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSix
        '
        Me.lblSix.Location = New System.Drawing.Point(12, 235)
        Me.lblSix.Name = "lblSix"
        Me.lblSix.Size = New System.Drawing.Size(145, 23)
        Me.lblSix.TabIndex = 15
        Me.lblSix.Text = "750 to 999 pcs."
        Me.lblSix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice6
        '
        Me.txtPrice6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice6.Location = New System.Drawing.Point(139, 236)
        Me.txtPrice6.Name = "txtPrice6"
        Me.txtPrice6.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice6.TabIndex = 14
        Me.txtPrice6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSeven
        '
        Me.lblSeven.Location = New System.Drawing.Point(12, 261)
        Me.lblSeven.Name = "lblSeven"
        Me.lblSeven.Size = New System.Drawing.Size(145, 23)
        Me.lblSeven.TabIndex = 17
        Me.lblSeven.Text = "1,000 to 2,499 pcs."
        Me.lblSeven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice7
        '
        Me.txtPrice7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice7.Location = New System.Drawing.Point(139, 262)
        Me.txtPrice7.Name = "txtPrice7"
        Me.txtPrice7.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice7.TabIndex = 16
        Me.txtPrice7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEight
        '
        Me.lblEight.Location = New System.Drawing.Point(12, 287)
        Me.lblEight.Name = "lblEight"
        Me.lblEight.Size = New System.Drawing.Size(145, 23)
        Me.lblEight.TabIndex = 19
        Me.lblEight.Text = "2,500 to 4,999 pcs."
        Me.lblEight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice8
        '
        Me.txtPrice8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice8.Location = New System.Drawing.Point(139, 288)
        Me.txtPrice8.Name = "txtPrice8"
        Me.txtPrice8.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice8.TabIndex = 18
        Me.txtPrice8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEleven
        '
        Me.lblEleven.Location = New System.Drawing.Point(12, 365)
        Me.lblEleven.Name = "lblEleven"
        Me.lblEleven.Size = New System.Drawing.Size(145, 23)
        Me.lblEleven.TabIndex = 25
        Me.lblEleven.Text = "25,000 to 49,999 pcs."
        Me.lblEleven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice11
        '
        Me.txtPrice11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice11.Location = New System.Drawing.Point(139, 366)
        Me.txtPrice11.Name = "txtPrice11"
        Me.txtPrice11.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice11.TabIndex = 24
        Me.txtPrice11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTen
        '
        Me.lblTen.Location = New System.Drawing.Point(12, 339)
        Me.lblTen.Name = "lblTen"
        Me.lblTen.Size = New System.Drawing.Size(145, 23)
        Me.lblTen.TabIndex = 23
        Me.lblTen.Text = "10,000 to 24,999 pcs."
        Me.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice10
        '
        Me.txtPrice10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice10.Location = New System.Drawing.Point(139, 340)
        Me.txtPrice10.Name = "txtPrice10"
        Me.txtPrice10.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice10.TabIndex = 22
        Me.txtPrice10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNine
        '
        Me.lblNine.Location = New System.Drawing.Point(12, 313)
        Me.lblNine.Name = "lblNine"
        Me.lblNine.Size = New System.Drawing.Size(145, 23)
        Me.lblNine.TabIndex = 21
        Me.lblNine.Text = "5,000 to 9,999 pcs."
        Me.lblNine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice9
        '
        Me.txtPrice9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice9.Location = New System.Drawing.Point(139, 314)
        Me.txtPrice9.Name = "txtPrice9"
        Me.txtPrice9.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice9.TabIndex = 20
        Me.txtPrice9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThirteen
        '
        Me.lblThirteen.Location = New System.Drawing.Point(12, 417)
        Me.lblThirteen.Name = "lblThirteen"
        Me.lblThirteen.Size = New System.Drawing.Size(145, 23)
        Me.lblThirteen.TabIndex = 29
        Me.lblThirteen.Text = "100,000 and over"
        Me.lblThirteen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice13
        '
        Me.txtPrice13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice13.Location = New System.Drawing.Point(139, 418)
        Me.txtPrice13.Name = "txtPrice13"
        Me.txtPrice13.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice13.TabIndex = 28
        Me.txtPrice13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTwelve
        '
        Me.lblTwelve.Location = New System.Drawing.Point(12, 391)
        Me.lblTwelve.Name = "lblTwelve"
        Me.lblTwelve.Size = New System.Drawing.Size(145, 23)
        Me.lblTwelve.TabIndex = 27
        Me.lblTwelve.Text = "50,000 to 99,999 pcs."
        Me.lblTwelve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice12
        '
        Me.txtPrice12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice12.Location = New System.Drawing.Point(139, 392)
        Me.txtPrice12.Name = "txtPrice12"
        Me.txtPrice12.Size = New System.Drawing.Size(141, 20)
        Me.txtPrice12.TabIndex = 26
        Me.txtPrice12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SOPriceBracket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 448)
        Me.Controls.Add(Me.txtPrice13)
        Me.Controls.Add(Me.txtPrice12)
        Me.Controls.Add(Me.txtPrice11)
        Me.Controls.Add(Me.txtPrice10)
        Me.Controls.Add(Me.txtPrice9)
        Me.Controls.Add(Me.txtPrice8)
        Me.Controls.Add(Me.txtPrice7)
        Me.Controls.Add(Me.txtPrice6)
        Me.Controls.Add(Me.txtPrice5)
        Me.Controls.Add(Me.txtPrice4)
        Me.Controls.Add(Me.txtPrice3)
        Me.Controls.Add(Me.txtPrice2)
        Me.Controls.Add(Me.txtPrice1)
        Me.Controls.Add(Me.lblThirteen)
        Me.Controls.Add(Me.lblTwelve)
        Me.Controls.Add(Me.lblEleven)
        Me.Controls.Add(Me.lblTen)
        Me.Controls.Add(Me.lblNine)
        Me.Controls.Add(Me.lblEight)
        Me.Controls.Add(Me.lblSeven)
        Me.Controls.Add(Me.lblSix)
        Me.Controls.Add(Me.lblFive)
        Me.Controls.Add(Me.lblFour)
        Me.Controls.Add(Me.lblThree)
        Me.Controls.Add(Me.lblTwo)
        Me.Controls.Add(Me.lblOne)
        Me.Controls.Add(Me.cboPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPartDescription)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SOPriceBracket"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price Levels"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrice1 As System.Windows.Forms.TextBox
    Friend WithEvents lblOne As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents lblTwo As System.Windows.Forms.Label
    Friend WithEvents txtPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents lblThree As System.Windows.Forms.Label
    Friend WithEvents txtPrice3 As System.Windows.Forms.TextBox
    Friend WithEvents lblFour As System.Windows.Forms.Label
    Friend WithEvents txtPrice4 As System.Windows.Forms.TextBox
    Friend WithEvents lblFive As System.Windows.Forms.Label
    Friend WithEvents txtPrice5 As System.Windows.Forms.TextBox
    Friend WithEvents lblSix As System.Windows.Forms.Label
    Friend WithEvents txtPrice6 As System.Windows.Forms.TextBox
    Friend WithEvents lblSeven As System.Windows.Forms.Label
    Friend WithEvents txtPrice7 As System.Windows.Forms.TextBox
    Friend WithEvents lblEight As System.Windows.Forms.Label
    Friend WithEvents txtPrice8 As System.Windows.Forms.TextBox
    Friend WithEvents lblEleven As System.Windows.Forms.Label
    Friend WithEvents txtPrice11 As System.Windows.Forms.TextBox
    Friend WithEvents lblTen As System.Windows.Forms.Label
    Friend WithEvents txtPrice10 As System.Windows.Forms.TextBox
    Friend WithEvents lblNine As System.Windows.Forms.Label
    Friend WithEvents txtPrice9 As System.Windows.Forms.TextBox
    Friend WithEvents lblThirteen As System.Windows.Forms.Label
    Friend WithEvents txtPrice13 As System.Windows.Forms.TextBox
    Friend WithEvents lblTwelve As System.Windows.Forms.Label
    Friend WithEvents txtPrice12 As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
