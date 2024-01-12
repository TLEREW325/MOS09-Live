<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlueprintJournalEditEntry
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.txtDetails = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lstPictureFiles = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdSelectPictures = New System.Windows.Forms.Button
        Me.lstCurrentPictures = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.pnlImageCopy = New System.Windows.Forms.Panel
        Me.lblTotalCount = New System.Windows.Forms.Label
        Me.lblImageCount = New System.Windows.Forms.Label
        Me.lblCopyMessage = New System.Windows.Forms.Label
        Me.bgwkCopyImage = New System.ComponentModel.BackgroundWorker
        Me.tmrCopyMessageChange = New System.Windows.Forms.Timer(Me.components)
        Me.pnlImageCopy.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(67, 26)
        Me.txtTitle.MaxLength = 100
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(564, 20)
        Me.txtTitle.TabIndex = 1
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(37, 80)
        Me.txtDetails.MaxLength = 500
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(594, 70)
        Me.txtDetails.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Details"
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Location = New System.Drawing.Point(505, 239)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 5
        Me.cmdAdd.Text = "Update"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(582, 239)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lstPictureFiles
        '
        Me.lstPictureFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPictureFiles.BackColor = System.Drawing.SystemColors.Control
        Me.lstPictureFiles.Enabled = False
        Me.lstPictureFiles.FormattingEnabled = True
        Me.lstPictureFiles.Location = New System.Drawing.Point(37, 215)
        Me.lstPictureFiles.MultiColumn = True
        Me.lstPictureFiles.Name = "lstPictureFiles"
        Me.lstPictureFiles.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstPictureFiles.Size = New System.Drawing.Size(209, 69)
        Me.lstPictureFiles.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "New Pictures"
        '
        'cmdSelectPictures
        '
        Me.cmdSelectPictures.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectPictures.Location = New System.Drawing.Point(37, 156)
        Me.cmdSelectPictures.Name = "cmdSelectPictures"
        Me.cmdSelectPictures.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectPictures.TabIndex = 9
        Me.cmdSelectPictures.Text = "Select Pictures"
        Me.cmdSelectPictures.UseVisualStyleBackColor = True
        '
        'lstCurrentPictures
        '
        Me.lstCurrentPictures.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstCurrentPictures.FormattingEnabled = True
        Me.lstCurrentPictures.Location = New System.Drawing.Point(307, 215)
        Me.lstCurrentPictures.MultiColumn = True
        Me.lstCurrentPictures.Name = "lstCurrentPictures"
        Me.lstCurrentPictures.Size = New System.Drawing.Size(192, 69)
        Me.lstCurrentPictures.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(304, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Current Pictures"
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(428, 169)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 12
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'pnlImageCopy
        '
        Me.pnlImageCopy.Controls.Add(Me.lblTotalCount)
        Me.pnlImageCopy.Controls.Add(Me.lblImageCount)
        Me.pnlImageCopy.Controls.Add(Me.lblCopyMessage)
        Me.pnlImageCopy.Location = New System.Drawing.Point(151, 66)
        Me.pnlImageCopy.Name = "pnlImageCopy"
        Me.pnlImageCopy.Size = New System.Drawing.Size(348, 143)
        Me.pnlImageCopy.TabIndex = 13
        Me.pnlImageCopy.Visible = False
        '
        'lblTotalCount
        '
        Me.lblTotalCount.Location = New System.Drawing.Point(145, 104)
        Me.lblTotalCount.Name = "lblTotalCount"
        Me.lblTotalCount.Size = New System.Drawing.Size(97, 23)
        Me.lblTotalCount.TabIndex = 2
        Me.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImageCount
        '
        Me.lblImageCount.Location = New System.Drawing.Point(42, 104)
        Me.lblImageCount.Name = "lblImageCount"
        Me.lblImageCount.Size = New System.Drawing.Size(97, 23)
        Me.lblImageCount.TabIndex = 1
        Me.lblImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCopyMessage
        '
        Me.lblCopyMessage.AutoSize = True
        Me.lblCopyMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblCopyMessage.Location = New System.Drawing.Point(41, 58)
        Me.lblCopyMessage.Name = "lblCopyMessage"
        Me.lblCopyMessage.Size = New System.Drawing.Size(221, 20)
        Me.lblCopyMessage.TabIndex = 0
        Me.lblCopyMessage.Text = "Copying image please wait"
        '
        'tmrCopyMessageChange
        '
        Me.tmrCopyMessageChange.Interval = 1000
        '
        'BlueprintJournalEditEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 291)
        Me.Controls.Add(Me.pnlImageCopy)
        Me.Controls.Add(Me.cmdDeleteSelected)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstCurrentPictures)
        Me.Controls.Add(Me.cmdSelectPictures)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstPictureFiles)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BlueprintJournalEditEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Blueprint Journal Add Entry"
        Me.pnlImageCopy.ResumeLayout(False)
        Me.pnlImageCopy.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lstPictureFiles As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectPictures As System.Windows.Forms.Button
    Friend WithEvents lstCurrentPictures As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents pnlImageCopy As System.Windows.Forms.Panel
    Friend WithEvents lblTotalCount As System.Windows.Forms.Label
    Friend WithEvents lblImageCount As System.Windows.Forms.Label
    Friend WithEvents lblCopyMessage As System.Windows.Forms.Label
    Friend WithEvents bgwkCopyImage As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrCopyMessageChange As System.Windows.Forms.Timer
End Class
