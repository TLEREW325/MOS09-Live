<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailPage
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
        Me.components = New System.ComponentModel.Container()
        Me.listToAddressBook = New System.Windows.Forms.ListBox()
        Me.TFPMailAddressBookBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet()
        Me.listBCCAddressBook = New System.Windows.Forms.ListBox()
        Me.txtEmailSubject = New System.Windows.Forms.TextBox()
        Me.txtEmailBcc = New System.Windows.Forms.TextBox()
        Me.txtEmailCc = New System.Windows.Forms.TextBox()
        Me.txtEmailTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdAddCc = New System.Windows.Forms.Button()
        Me.cmdAddBcc = New System.Windows.Forms.Button()
        Me.cmdAddTo = New System.Windows.Forms.Button()
        Me.cmdSendEmail = New System.Windows.Forms.Button()
        Me.listCCAddressBook = New System.Windows.Forms.ListBox()
        Me.txtEmailBody = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEmailAttachments = New System.Windows.Forms.Label()
        Me.lblEmailCopyTo = New System.Windows.Forms.Label()
        Me.lblEmailSentFrom = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.TFPMailAddressBookTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPMailAddressBookTableAdapter()
        Me.cmdAddAttachment = New System.Windows.Forms.Button()
        Me.ofdAddAttachments = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdAddReceiverDocs = New System.Windows.Forms.Button()
        Me.cmdAddShipmentDoc = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReceiverNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdClearAllFields = New System.Windows.Forms.Button()
        CType(Me.TFPMailAddressBookBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'listToAddressBook
        '
        Me.listToAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listToAddressBook.DataSource = Me.TFPMailAddressBookBindingSource
        Me.listToAddressBook.DisplayMember = "EmailAddress"
        Me.listToAddressBook.FormattingEnabled = True
        Me.listToAddressBook.Location = New System.Drawing.Point(200, 28)
        Me.listToAddressBook.Name = "listToAddressBook"
        Me.listToAddressBook.ScrollAlwaysVisible = True
        Me.listToAddressBook.Size = New System.Drawing.Size(201, 535)
        Me.listToAddressBook.TabIndex = 25
        Me.listToAddressBook.TabStop = False
        Me.listToAddressBook.Visible = False
        '
        'TFPMailAddressBookBindingSource
        '
        Me.TFPMailAddressBookBindingSource.DataMember = "TFPMailAddressBook"
        Me.TFPMailAddressBookBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'listBCCAddressBook
        '
        Me.listBCCAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBCCAddressBook.DataSource = Me.TFPMailAddressBookBindingSource
        Me.listBCCAddressBook.DisplayMember = "EmailAddress"
        Me.listBCCAddressBook.FormattingEnabled = True
        Me.listBCCAddressBook.Location = New System.Drawing.Point(200, 133)
        Me.listBCCAddressBook.Name = "listBCCAddressBook"
        Me.listBCCAddressBook.ScrollAlwaysVisible = True
        Me.listBCCAddressBook.Size = New System.Drawing.Size(201, 509)
        Me.listBCCAddressBook.TabIndex = 27
        Me.listBCCAddressBook.TabStop = False
        Me.listBCCAddressBook.Visible = False
        '
        'txtEmailSubject
        '
        Me.txtEmailSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailSubject.Location = New System.Drawing.Point(200, 162)
        Me.txtEmailSubject.MaxLength = 400
        Me.txtEmailSubject.Multiline = True
        Me.txtEmailSubject.Name = "txtEmailSubject"
        Me.txtEmailSubject.Size = New System.Drawing.Size(472, 23)
        Me.txtEmailSubject.TabIndex = 3
        '
        'txtEmailBcc
        '
        Me.txtEmailBcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailBcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailBcc.Location = New System.Drawing.Point(200, 133)
        Me.txtEmailBcc.MaxLength = 400
        Me.txtEmailBcc.Multiline = True
        Me.txtEmailBcc.Name = "txtEmailBcc"
        Me.txtEmailBcc.Size = New System.Drawing.Size(472, 23)
        Me.txtEmailBcc.TabIndex = 2
        '
        'txtEmailCc
        '
        Me.txtEmailCc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailCc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailCc.Location = New System.Drawing.Point(200, 104)
        Me.txtEmailCc.MaxLength = 400
        Me.txtEmailCc.Multiline = True
        Me.txtEmailCc.Name = "txtEmailCc"
        Me.txtEmailCc.Size = New System.Drawing.Size(472, 23)
        Me.txtEmailCc.TabIndex = 1
        '
        'txtEmailTo
        '
        Me.txtEmailTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailTo.Location = New System.Drawing.Point(200, 28)
        Me.txtEmailTo.MaxLength = 400
        Me.txtEmailTo.Multiline = True
        Me.txtEmailTo.Name = "txtEmailTo"
        Me.txtEmailTo.Size = New System.Drawing.Size(472, 70)
        Me.txtEmailTo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(101, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Subject:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddCc
        '
        Me.cmdAddCc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddCc.Location = New System.Drawing.Point(102, 104)
        Me.cmdAddCc.Name = "cmdAddCc"
        Me.cmdAddCc.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddCc.TabIndex = 25
        Me.cmdAddCc.TabStop = False
        Me.cmdAddCc.Text = "Cc..."
        Me.cmdAddCc.UseVisualStyleBackColor = False
        '
        'cmdAddBcc
        '
        Me.cmdAddBcc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddBcc.Location = New System.Drawing.Point(102, 133)
        Me.cmdAddBcc.Name = "cmdAddBcc"
        Me.cmdAddBcc.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddBcc.TabIndex = 25
        Me.cmdAddBcc.TabStop = False
        Me.cmdAddBcc.Text = "Bcc..."
        Me.cmdAddBcc.UseVisualStyleBackColor = False
        '
        'cmdAddTo
        '
        Me.cmdAddTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddTo.Location = New System.Drawing.Point(102, 28)
        Me.cmdAddTo.Name = "cmdAddTo"
        Me.cmdAddTo.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddTo.TabIndex = 25
        Me.cmdAddTo.TabStop = False
        Me.cmdAddTo.Text = "To..."
        Me.cmdAddTo.UseVisualStyleBackColor = False
        '
        'cmdSendEmail
        '
        Me.cmdSendEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdSendEmail.Location = New System.Drawing.Point(11, 28)
        Me.cmdSendEmail.Name = "cmdSendEmail"
        Me.cmdSendEmail.Size = New System.Drawing.Size(75, 52)
        Me.cmdSendEmail.TabIndex = 25
        Me.cmdSendEmail.TabStop = False
        Me.cmdSendEmail.Text = "Send"
        Me.cmdSendEmail.UseVisualStyleBackColor = False
        '
        'listCCAddressBook
        '
        Me.listCCAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listCCAddressBook.DataSource = Me.TFPMailAddressBookBindingSource
        Me.listCCAddressBook.DisplayMember = "EmailAddress"
        Me.listCCAddressBook.FormattingEnabled = True
        Me.listCCAddressBook.Location = New System.Drawing.Point(200, 103)
        Me.listCCAddressBook.Name = "listCCAddressBook"
        Me.listCCAddressBook.ScrollAlwaysVisible = True
        Me.listCCAddressBook.Size = New System.Drawing.Size(201, 535)
        Me.listCCAddressBook.TabIndex = 26
        Me.listCCAddressBook.TabStop = False
        Me.listCCAddressBook.Visible = False
        '
        'txtEmailBody
        '
        Me.txtEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailBody.Location = New System.Drawing.Point(6, 205)
        Me.txtEmailBody.Multiline = True
        Me.txtEmailBody.Name = "txtEmailBody"
        Me.txtEmailBody.Size = New System.Drawing.Size(668, 398)
        Me.txtEmailBody.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 615)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attachments:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 787)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Email From:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 759)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Email Copy To:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmailAttachments
        '
        Me.lblEmailAttachments.Location = New System.Drawing.Point(142, 615)
        Me.lblEmailAttachments.Name = "lblEmailAttachments"
        Me.lblEmailAttachments.Size = New System.Drawing.Size(538, 48)
        Me.lblEmailAttachments.TabIndex = 5
        '
        'lblEmailCopyTo
        '
        Me.lblEmailCopyTo.Location = New System.Drawing.Point(145, 759)
        Me.lblEmailCopyTo.Name = "lblEmailCopyTo"
        Me.lblEmailCopyTo.Size = New System.Drawing.Size(448, 23)
        Me.lblEmailCopyTo.TabIndex = 6
        Me.lblEmailCopyTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmailSentFrom
        '
        Me.lblEmailSentFrom.Location = New System.Drawing.Point(145, 787)
        Me.lblEmailSentFrom.Name = "lblEmailSentFrom"
        Me.lblEmailSentFrom.Size = New System.Drawing.Size(448, 23)
        Me.lblEmailSentFrom.TabIndex = 7
        Me.lblEmailSentFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdExit.Location = New System.Drawing.Point(605, 759)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 52)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'TFPMailAddressBookTableAdapter
        '
        Me.TFPMailAddressBookTableAdapter.ClearBeforeFill = True
        '
        'cmdAddAttachment
        '
        Me.cmdAddAttachment.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddAttachment.Location = New System.Drawing.Point(89, 615)
        Me.cmdAddAttachment.Name = "cmdAddAttachment"
        Me.cmdAddAttachment.Size = New System.Drawing.Size(47, 23)
        Me.cmdAddAttachment.TabIndex = 5
        Me.cmdAddAttachment.Text = "Add"
        Me.cmdAddAttachment.UseVisualStyleBackColor = False
        '
        'ofdAddAttachments
        '
        Me.ofdAddAttachments.Filter = "PDF Files|*.pdf|Text Files|*.txt|All Files|*.*"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdAddReceiverDocs)
        Me.GroupBox2.Controls.Add(Me.cmdAddShipmentDoc)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtReceiverNumber)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtShipmentNumber)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 666)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(512, 87)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add Scanned Document as Attachment"
        '
        'cmdAddReceiverDocs
        '
        Me.cmdAddReceiverDocs.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddReceiverDocs.Location = New System.Drawing.Point(444, 54)
        Me.cmdAddReceiverDocs.Name = "cmdAddReceiverDocs"
        Me.cmdAddReceiverDocs.Size = New System.Drawing.Size(47, 23)
        Me.cmdAddReceiverDocs.TabIndex = 9
        Me.cmdAddReceiverDocs.Text = "Add"
        Me.cmdAddReceiverDocs.UseVisualStyleBackColor = False
        '
        'cmdAddShipmentDoc
        '
        Me.cmdAddShipmentDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAddShipmentDoc.Location = New System.Drawing.Point(444, 25)
        Me.cmdAddShipmentDoc.Name = "cmdAddShipmentDoc"
        Me.cmdAddShipmentDoc.Size = New System.Drawing.Size(47, 23)
        Me.cmdAddShipmentDoc.TabIndex = 7
        Me.cmdAddShipmentDoc.Text = "Add"
        Me.cmdAddShipmentDoc.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(330, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "(Enter Receiver #)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReceiverNumber
        '
        Me.txtReceiverNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiverNumber.Location = New System.Drawing.Point(148, 55)
        Me.txtReceiverNumber.Name = "txtReceiverNumber"
        Me.txtReceiverNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtReceiverNumber.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Scanned Vendor Docs:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(330, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "(Enter Shipment #)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.Location = New System.Drawing.Point(148, 25)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtShipmentNumber.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Scanned Shipping Docs:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAllFields
        '
        Me.cmdClearAllFields.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdClearAllFields.Location = New System.Drawing.Point(605, 691)
        Me.cmdClearAllFields.Name = "cmdClearAllFields"
        Me.cmdClearAllFields.Size = New System.Drawing.Size(75, 52)
        Me.cmdClearAllFields.TabIndex = 10
        Me.cmdClearAllFields.Text = "Clear All Fields"
        Me.cmdClearAllFields.UseVisualStyleBackColor = False
        '
        'EmailPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(692, 823)
        Me.Controls.Add(Me.listCCAddressBook)
        Me.Controls.Add(Me.listBCCAddressBook)
        Me.Controls.Add(Me.cmdClearAllFields)
        Me.Controls.Add(Me.listToAddressBook)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdAddAttachment)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblEmailSentFrom)
        Me.Controls.Add(Me.lblEmailCopyTo)
        Me.Controls.Add(Me.lblEmailAttachments)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdAddCc)
        Me.Controls.Add(Me.cmdAddBcc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdAddTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdSendEmail)
        Me.Controls.Add(Me.txtEmailBody)
        Me.Controls.Add(Me.txtEmailSubject)
        Me.Controls.Add(Me.txtEmailBcc)
        Me.Controls.Add(Me.txtEmailCc)
        Me.Controls.Add(Me.txtEmailTo)
        Me.Name = "EmailPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Email"
        CType(Me.TFPMailAddressBookBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAddCc As System.Windows.Forms.Button
    Friend WithEvents cmdAddBcc As System.Windows.Forms.Button
    Friend WithEvents cmdAddTo As System.Windows.Forms.Button
    Friend WithEvents cmdSendEmail As System.Windows.Forms.Button
    Friend WithEvents txtEmailSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailBcc As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailCc As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmailBody As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEmailAttachments As System.Windows.Forms.Label
    Friend WithEvents lblEmailCopyTo As System.Windows.Forms.Label
    Friend WithEvents lblEmailSentFrom As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TFPMailAddressBookBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TFPMailAddressBookTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPMailAddressBookTableAdapter
    Friend WithEvents listToAddressBook As System.Windows.Forms.ListBox
    Friend WithEvents cmdAddAttachment As System.Windows.Forms.Button
    Friend WithEvents ofdAddAttachments As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReceiverNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdAddReceiverDocs As System.Windows.Forms.Button
    Friend WithEvents cmdAddShipmentDoc As System.Windows.Forms.Button
    Friend WithEvents cmdClearAllFields As System.Windows.Forms.Button
    Friend WithEvents listCCAddressBook As System.Windows.Forms.ListBox
    Friend WithEvents listBCCAddressBook As System.Windows.Forms.ListBox
End Class
