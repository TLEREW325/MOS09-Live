<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View1099Misc
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
        Me.txtRent1 = New System.Windows.Forms.TextBox
        Me.cboName1 = New System.Windows.Forms.ComboBox
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDiv1 = New System.Windows.Forms.ComboBox
        Me.txtGross1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblDivision1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chksecond = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtRent2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboName2 = New System.Windows.Forms.ComboBox
        Me.cboDiv2 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtGross2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRX1099Misc1 = New MOS09Program.CRX1099Misc
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRent1
        '
        Me.txtRent1.Location = New System.Drawing.Point(41, 134)
        Me.txtRent1.Name = "txtRent1"
        Me.txtRent1.Size = New System.Drawing.Size(198, 20)
        Me.txtRent1.TabIndex = 0
        '
        'cboName1
        '
        Me.cboName1.FormattingEnabled = True
        Me.cboName1.Location = New System.Drawing.Point(41, 85)
        Me.cboName1.Name = "cboName1"
        Me.cboName1.Size = New System.Drawing.Size(198, 21)
        Me.cboName1.TabIndex = 2
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDiv1
        '
        Me.cboDiv1.FormattingEnabled = True
        Me.cboDiv1.Location = New System.Drawing.Point(41, 33)
        Me.cboDiv1.Name = "cboDiv1"
        Me.cboDiv1.Size = New System.Drawing.Size(198, 21)
        Me.cboDiv1.TabIndex = 3
        '
        'txtGross1
        '
        Me.txtGross1.Location = New System.Drawing.Point(41, 185)
        Me.txtGross1.Name = "txtGross1"
        Me.txtGross1.Size = New System.Drawing.Size(198, 20)
        Me.txtGross1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Gross Proceeds Paid To An Attorney"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Rents"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Recipent's Name"
        '
        'lblDivision1
        '
        Me.lblDivision1.AutoSize = True
        Me.lblDivision1.Location = New System.Drawing.Point(38, 17)
        Me.lblDivision1.Name = "lblDivision1"
        Me.lblDivision1.Size = New System.Drawing.Size(44, 13)
        Me.lblDivision1.TabIndex = 9
        Me.lblDivision1.Text = "Division"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRent1)
        Me.GroupBox1.Controls.Add(Me.lblDivision1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboName1)
        Me.GroupBox1.Controls.Add(Me.cboDiv1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGross1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 228)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Top Entry"
        '
        'chksecond
        '
        Me.chksecond.AutoSize = True
        Me.chksecond.Location = New System.Drawing.Point(101, 256)
        Me.chksecond.Name = "chksecond"
        Me.chksecond.Size = New System.Drawing.Size(90, 17)
        Me.chksecond.TabIndex = 12
        Me.chksecond.Text = "Second Entry"
        Me.chksecond.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRent2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboName2)
        Me.GroupBox2.Controls.Add(Me.cboDiv2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtGross2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(14, 279)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 228)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bottom Entry"
        '
        'txtRent2
        '
        Me.txtRent2.Location = New System.Drawing.Point(41, 134)
        Me.txtRent2.Name = "txtRent2"
        Me.txtRent2.Size = New System.Drawing.Size(198, 20)
        Me.txtRent2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Division"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Recipent's Name"
        '
        'cboName2
        '
        Me.cboName2.FormattingEnabled = True
        Me.cboName2.Location = New System.Drawing.Point(41, 85)
        Me.cboName2.Name = "cboName2"
        Me.cboName2.Size = New System.Drawing.Size(198, 21)
        Me.cboName2.TabIndex = 2
        '
        'cboDiv2
        '
        Me.cboDiv2.FormattingEnabled = True
        Me.cboDiv2.Location = New System.Drawing.Point(41, 33)
        Me.cboDiv2.Name = "cboDiv2"
        Me.cboDiv2.Size = New System.Drawing.Size(198, 21)
        Me.cboDiv2.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Rents"
        '
        'txtGross2
        '
        Me.txtGross2.Location = New System.Drawing.Point(41, 185)
        Me.txtGross2.Name = "txtGross2"
        Me.txtGross2.Size = New System.Drawing.Size(198, 20)
        Me.txtGross2.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(180, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Gross Proceeds Paid To An Attorney"
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(14, 532)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(87, 36)
        Me.cmdView.TabIndex = 14
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(109, 532)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(87, 36)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(204, 532)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(87, 36)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(306, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.CRX1099Misc1
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(865, 619)
        Me.CrystalReportViewer1.TabIndex = 13
        '
        'View1099Misc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 623)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chksecond)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "View1099Misc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View1099Misc"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRent1 As System.Windows.Forms.TextBox
    Friend WithEvents cboName1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiv1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtGross1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDivision1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chksecond As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRent2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboName2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiv2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGross2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRX1099Misc1 As MOS09Program.CRX1099Misc
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
End Class
