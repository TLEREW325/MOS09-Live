<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerAnnouncements
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxDivisionSelection = New System.Windows.Forms.GroupBox
        Me.chkTFJ = New System.Windows.Forms.CheckBox
        Me.chkALB = New System.Windows.Forms.CheckBox
        Me.chkTST = New System.Windows.Forms.CheckBox
        Me.cmdUncheckAll = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.chkTWE = New System.Windows.Forms.CheckBox
        Me.chkTWD = New System.Windows.Forms.CheckBox
        Me.chkTOR = New System.Windows.Forms.CheckBox
        Me.chkTFP = New System.Windows.Forms.CheckBox
        Me.chkTFT = New System.Windows.Forms.CheckBox
        Me.chkTFF = New System.Windows.Forms.CheckBox
        Me.chkSLC = New System.Windows.Forms.CheckBox
        Me.chkHOU = New System.Windows.Forms.CheckBox
        Me.chkDEN = New System.Windows.Forms.CheckBox
        Me.chkCHT = New System.Windows.Forms.CheckBox
        Me.chkCGO = New System.Windows.Forms.CheckBox
        Me.chkCBS = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkATL = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdValidateEmail = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdRemoveFile = New System.Windows.Forms.Button
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFileNamePath = New System.Windows.Forms.TextBox
        Me.cmdSelectFile = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdSendEmail = New System.Windows.Forms.Button
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.txtTestEmailAddress = New System.Windows.Forms.TextBox
        Me.txtEmailBody = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSubjectLine = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.OpenAttachment = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdLoadDefaultSignature = New System.Windows.Forms.Button
        Me.cmdClearSignature = New System.Windows.Forms.Button
        Me.txtSignature = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxDivisionSelection.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'gpxDivisionSelection
        '
        Me.gpxDivisionSelection.Controls.Add(Me.chkTFJ)
        Me.gpxDivisionSelection.Controls.Add(Me.chkALB)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTST)
        Me.gpxDivisionSelection.Controls.Add(Me.cmdUncheckAll)
        Me.gpxDivisionSelection.Controls.Add(Me.cmdCheckAll)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTWE)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTWD)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTOR)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTFP)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTFT)
        Me.gpxDivisionSelection.Controls.Add(Me.chkTFF)
        Me.gpxDivisionSelection.Controls.Add(Me.chkSLC)
        Me.gpxDivisionSelection.Controls.Add(Me.chkHOU)
        Me.gpxDivisionSelection.Controls.Add(Me.chkDEN)
        Me.gpxDivisionSelection.Controls.Add(Me.chkCHT)
        Me.gpxDivisionSelection.Controls.Add(Me.chkCGO)
        Me.gpxDivisionSelection.Controls.Add(Me.chkCBS)
        Me.gpxDivisionSelection.Controls.Add(Me.Label7)
        Me.gpxDivisionSelection.Controls.Add(Me.chkATL)
        Me.gpxDivisionSelection.Location = New System.Drawing.Point(29, 41)
        Me.gpxDivisionSelection.Name = "gpxDivisionSelection"
        Me.gpxDivisionSelection.Size = New System.Drawing.Size(317, 393)
        Me.gpxDivisionSelection.TabIndex = 0
        Me.gpxDivisionSelection.TabStop = False
        Me.gpxDivisionSelection.Text = "Sending Options"
        '
        'chkTFJ
        '
        Me.chkTFJ.Location = New System.Drawing.Point(91, 95)
        Me.chkTFJ.Name = "chkTFJ"
        Me.chkTFJ.Size = New System.Drawing.Size(72, 17)
        Me.chkTFJ.TabIndex = 18
        Me.chkTFJ.Text = "TFJ"
        Me.chkTFJ.UseVisualStyleBackColor = True
        '
        'chkALB
        '
        Me.chkALB.Location = New System.Drawing.Point(21, 95)
        Me.chkALB.Name = "chkALB"
        Me.chkALB.Size = New System.Drawing.Size(51, 17)
        Me.chkALB.TabIndex = 17
        Me.chkALB.Text = "ALB"
        Me.chkALB.UseVisualStyleBackColor = True
        '
        'chkTST
        '
        Me.chkTST.Location = New System.Drawing.Point(91, 305)
        Me.chkTST.Name = "chkTST"
        Me.chkTST.Size = New System.Drawing.Size(73, 17)
        Me.chkTST.TabIndex = 16
        Me.chkTST.Text = "TST"
        Me.chkTST.UseVisualStyleBackColor = True
        '
        'cmdUncheckAll
        '
        Me.cmdUncheckAll.Location = New System.Drawing.Point(235, 336)
        Me.cmdUncheckAll.Name = "cmdUncheckAll"
        Me.cmdUncheckAll.Size = New System.Drawing.Size(65, 38)
        Me.cmdUncheckAll.TabIndex = 15
        Me.cmdUncheckAll.Text = "Uncheck All"
        Me.cmdUncheckAll.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Location = New System.Drawing.Point(163, 336)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(65, 38)
        Me.cmdCheckAll.TabIndex = 14
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'chkTWE
        '
        Me.chkTWE.Location = New System.Drawing.Point(91, 270)
        Me.chkTWE.Name = "chkTWE"
        Me.chkTWE.Size = New System.Drawing.Size(73, 17)
        Me.chkTWE.TabIndex = 13
        Me.chkTWE.Text = "TWE"
        Me.chkTWE.UseVisualStyleBackColor = True
        '
        'chkTWD
        '
        Me.chkTWD.Location = New System.Drawing.Point(91, 235)
        Me.chkTWD.Name = "chkTWD"
        Me.chkTWD.Size = New System.Drawing.Size(72, 17)
        Me.chkTWD.TabIndex = 12
        Me.chkTWD.Text = "TWD"
        Me.chkTWD.UseVisualStyleBackColor = True
        '
        'chkTOR
        '
        Me.chkTOR.Location = New System.Drawing.Point(91, 200)
        Me.chkTOR.Name = "chkTOR"
        Me.chkTOR.Size = New System.Drawing.Size(72, 17)
        Me.chkTOR.TabIndex = 11
        Me.chkTOR.Text = "TOR"
        Me.chkTOR.UseVisualStyleBackColor = True
        '
        'chkTFP
        '
        Me.chkTFP.Location = New System.Drawing.Point(91, 165)
        Me.chkTFP.Name = "chkTFP"
        Me.chkTFP.Size = New System.Drawing.Size(72, 17)
        Me.chkTFP.TabIndex = 10
        Me.chkTFP.Text = "TFP"
        Me.chkTFP.UseVisualStyleBackColor = True
        '
        'chkTFT
        '
        Me.chkTFT.Location = New System.Drawing.Point(91, 130)
        Me.chkTFT.Name = "chkTFT"
        Me.chkTFT.Size = New System.Drawing.Size(72, 17)
        Me.chkTFT.TabIndex = 9
        Me.chkTFT.Text = "TFT"
        Me.chkTFT.UseVisualStyleBackColor = True
        '
        'chkTFF
        '
        Me.chkTFF.Location = New System.Drawing.Point(91, 60)
        Me.chkTFF.Name = "chkTFF"
        Me.chkTFF.Size = New System.Drawing.Size(72, 17)
        Me.chkTFF.TabIndex = 8
        Me.chkTFF.Text = "TFF"
        Me.chkTFF.UseVisualStyleBackColor = True
        '
        'chkSLC
        '
        Me.chkSLC.Location = New System.Drawing.Point(21, 305)
        Me.chkSLC.Name = "chkSLC"
        Me.chkSLC.Size = New System.Drawing.Size(51, 17)
        Me.chkSLC.TabIndex = 7
        Me.chkSLC.Text = "SLC"
        Me.chkSLC.UseVisualStyleBackColor = True
        '
        'chkHOU
        '
        Me.chkHOU.Location = New System.Drawing.Point(21, 270)
        Me.chkHOU.Name = "chkHOU"
        Me.chkHOU.Size = New System.Drawing.Size(51, 17)
        Me.chkHOU.TabIndex = 6
        Me.chkHOU.Text = "HOU"
        Me.chkHOU.UseVisualStyleBackColor = True
        '
        'chkDEN
        '
        Me.chkDEN.Location = New System.Drawing.Point(21, 235)
        Me.chkDEN.Name = "chkDEN"
        Me.chkDEN.Size = New System.Drawing.Size(51, 17)
        Me.chkDEN.TabIndex = 5
        Me.chkDEN.Text = "DEN"
        Me.chkDEN.UseVisualStyleBackColor = True
        '
        'chkCHT
        '
        Me.chkCHT.Location = New System.Drawing.Point(21, 200)
        Me.chkCHT.Name = "chkCHT"
        Me.chkCHT.Size = New System.Drawing.Size(51, 17)
        Me.chkCHT.TabIndex = 4
        Me.chkCHT.Text = "CHT"
        Me.chkCHT.UseVisualStyleBackColor = True
        '
        'chkCGO
        '
        Me.chkCGO.Location = New System.Drawing.Point(21, 165)
        Me.chkCGO.Name = "chkCGO"
        Me.chkCGO.Size = New System.Drawing.Size(51, 17)
        Me.chkCGO.TabIndex = 3
        Me.chkCGO.Text = "CGO"
        Me.chkCGO.UseVisualStyleBackColor = True
        '
        'chkCBS
        '
        Me.chkCBS.Location = New System.Drawing.Point(21, 130)
        Me.chkCBS.Name = "chkCBS"
        Me.chkCBS.Size = New System.Drawing.Size(51, 17)
        Me.chkCBS.TabIndex = 2
        Me.chkCBS.Text = "CBS"
        Me.chkCBS.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Send to customers from divisions (select)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkATL
        '
        Me.chkATL.Location = New System.Drawing.Point(21, 60)
        Me.chkATL.Name = "chkATL"
        Me.chkATL.Size = New System.Drawing.Size(51, 17)
        Me.chkATL.TabIndex = 1
        Me.chkATL.Text = "ATL"
        Me.chkATL.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdValidateEmail)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmdRemoveFile)
        Me.GroupBox2.Controls.Add(Me.txtFilename)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtFileNamePath)
        Me.GroupBox2.Controls.Add(Me.cmdSelectFile)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmdSendEmail)
        Me.GroupBox2.Controls.Add(Me.cmdClearForm)
        Me.GroupBox2.Controls.Add(Me.txtTestEmailAddress)
        Me.GroupBox2.Controls.Add(Me.txtEmailBody)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtSubjectLine)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(446, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(667, 715)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Email Contents"
        '
        'cmdValidateEmail
        '
        Me.cmdValidateEmail.ForeColor = System.Drawing.Color.Red
        Me.cmdValidateEmail.Location = New System.Drawing.Point(130, 526)
        Me.cmdValidateEmail.Name = "cmdValidateEmail"
        Me.cmdValidateEmail.Size = New System.Drawing.Size(68, 28)
        Me.cmdValidateEmail.TabIndex = 256
        Me.cmdValidateEmail.Text = "Validate"
        Me.cmdValidateEmail.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(204, 523)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(455, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "If this field is populated, this will send a test email to the specified address " & _
            "only."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdRemoveFile
        '
        Me.cmdRemoveFile.ForeColor = System.Drawing.Color.Red
        Me.cmdRemoveFile.Location = New System.Drawing.Point(130, 637)
        Me.cmdRemoveFile.Name = "cmdRemoveFile"
        Me.cmdRemoveFile.Size = New System.Drawing.Size(68, 28)
        Me.cmdRemoveFile.TabIndex = 255
        Me.cmdRemoveFile.Text = "Remove"
        Me.cmdRemoveFile.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilename.Location = New System.Drawing.Point(214, 637)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.txtFilename.Size = New System.Drawing.Size(189, 20)
        Me.txtFilename.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(127, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(532, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Limit - 50 characters"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(251, 584)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(408, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "File to upload:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFileNamePath
        '
        Me.txtFileNamePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileNamePath.Location = New System.Drawing.Point(214, 607)
        Me.txtFileNamePath.Name = "txtFileNamePath"
        Me.txtFileNamePath.ReadOnly = True
        Me.txtFileNamePath.Size = New System.Drawing.Size(432, 20)
        Me.txtFileNamePath.TabIndex = 9
        '
        'cmdSelectFile
        '
        Me.cmdSelectFile.ForeColor = System.Drawing.Color.Red
        Me.cmdSelectFile.Location = New System.Drawing.Point(130, 603)
        Me.cmdSelectFile.Name = "cmdSelectFile"
        Me.cmdSelectFile.Size = New System.Drawing.Size(68, 28)
        Me.cmdSelectFile.TabIndex = 24
        Me.cmdSelectFile.Text = "Select"
        Me.cmdSelectFile.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 607)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Select File to Attach"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSendEmail
        '
        Me.cmdSendEmail.Location = New System.Drawing.Point(498, 662)
        Me.cmdSendEmail.Name = "cmdSendEmail"
        Me.cmdSendEmail.Size = New System.Drawing.Size(71, 40)
        Me.cmdSendEmail.TabIndex = 26
        Me.cmdSendEmail.Text = "Send Email"
        Me.cmdSendEmail.UseVisualStyleBackColor = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Location = New System.Drawing.Point(575, 662)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 27
        Me.cmdClearForm.Text = "Clear"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'txtTestEmailAddress
        '
        Me.txtTestEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTestEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTestEmailAddress.Location = New System.Drawing.Point(130, 494)
        Me.txtTestEmailAddress.Name = "txtTestEmailAddress"
        Me.txtTestEmailAddress.Size = New System.Drawing.Size(516, 26)
        Me.txtTestEmailAddress.TabIndex = 23
        '
        'txtEmailBody
        '
        Me.txtEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailBody.Location = New System.Drawing.Point(130, 82)
        Me.txtEmailBody.MaxLength = 1500
        Me.txtEmailBody.Multiline = True
        Me.txtEmailBody.Name = "txtEmailBody"
        Me.txtEmailBody.Size = New System.Drawing.Size(516, 387)
        Me.txtEmailBody.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Email Body"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSubjectLine
        '
        Me.txtSubjectLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubjectLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubjectLine.Location = New System.Drawing.Point(130, 36)
        Me.txtSubjectLine.MaxLength = 50
        Me.txtSubjectLine.Name = "txtSubjectLine"
        Me.txtSubjectLine.Size = New System.Drawing.Size(516, 26)
        Me.txtSubjectLine.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 497)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Test Email Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Email Subject Line"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1042, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 28
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'OpenAttachment
        '
        Me.OpenAttachment.Filter = """PDF's|*.pdf|AllFiles|*.*"""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdLoadDefaultSignature)
        Me.GroupBox3.Controls.Add(Me.cmdClearSignature)
        Me.GroupBox3.Controls.Add(Me.txtSignature)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 440)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(321, 370)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Add Signature"
        '
        'cmdLoadDefaultSignature
        '
        Me.cmdLoadDefaultSignature.Location = New System.Drawing.Point(146, 320)
        Me.cmdLoadDefaultSignature.Name = "cmdLoadDefaultSignature"
        Me.cmdLoadDefaultSignature.Size = New System.Drawing.Size(65, 38)
        Me.cmdLoadDefaultSignature.TabIndex = 18
        Me.cmdLoadDefaultSignature.Text = "Load Default"
        Me.cmdLoadDefaultSignature.UseVisualStyleBackColor = True
        '
        'cmdClearSignature
        '
        Me.cmdClearSignature.Location = New System.Drawing.Point(217, 320)
        Me.cmdClearSignature.Name = "cmdClearSignature"
        Me.cmdClearSignature.Size = New System.Drawing.Size(65, 38)
        Me.cmdClearSignature.TabIndex = 19
        Me.cmdClearSignature.Text = "Clear"
        Me.cmdClearSignature.UseVisualStyleBackColor = True
        '
        'txtSignature
        '
        Me.txtSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSignature.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignature.Location = New System.Drawing.Point(25, 31)
        Me.txtSignature.MaxLength = 500
        Me.txtSignature.Multiline = True
        Me.txtSignature.Name = "txtSignature"
        Me.txtSignature.Size = New System.Drawing.Size(279, 272)
        Me.txtSignature.TabIndex = 17
        '
        'CustomerAnnouncements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxDivisionSelection)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CustomerAnnouncements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Customer Announcememts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxDivisionSelection.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxDivisionSelection As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents txtEmailBody As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSubjectLine As System.Windows.Forms.TextBox
    Friend WithEvents cmdSendEmail As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTestEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenAttachment As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFileNamePath As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectFile As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents chkTWD As System.Windows.Forms.CheckBox
    Friend WithEvents chkTOR As System.Windows.Forms.CheckBox
    Friend WithEvents chkTFP As System.Windows.Forms.CheckBox
    Friend WithEvents chkTFT As System.Windows.Forms.CheckBox
    Friend WithEvents chkTFF As System.Windows.Forms.CheckBox
    Friend WithEvents chkSLC As System.Windows.Forms.CheckBox
    Friend WithEvents chkHOU As System.Windows.Forms.CheckBox
    Friend WithEvents chkDEN As System.Windows.Forms.CheckBox
    Friend WithEvents chkCHT As System.Windows.Forms.CheckBox
    Friend WithEvents chkCGO As System.Windows.Forms.CheckBox
    Friend WithEvents chkCBS As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkATL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents chkTWE As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSignature As System.Windows.Forms.TextBox
    Friend WithEvents cmdLoadDefaultSignature As System.Windows.Forms.Button
    Friend WithEvents cmdClearSignature As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveFile As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkTST As System.Windows.Forms.CheckBox
    Friend WithEvents cmdValidateEmail As System.Windows.Forms.Button
    Friend WithEvents chkTFJ As System.Windows.Forms.CheckBox
    Friend WithEvents chkALB As System.Windows.Forms.CheckBox
End Class
