<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerNoteCreation
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
        Me.cmdCreateNewNote = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtNoteCustomer = New System.Windows.Forms.TextBox
        Me.txtNoteSubject = New System.Windows.Forms.TextBox
        Me.txtNoteBody = New System.Windows.Forms.TextBox
        Me.dtpNoteDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCreateNewNote
        '
        Me.cmdCreateNewNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateNewNote.Location = New System.Drawing.Point(12, 221)
        Me.cmdCreateNewNote.Name = "cmdCreateNewNote"
        Me.cmdCreateNewNote.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateNewNote.TabIndex = 24
        Me.cmdCreateNewNote.Text = "Create New"
        Me.cmdCreateNewNote.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(97, 221)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 25
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtNoteCustomer
        '
        Me.txtNoteCustomer.BackColor = System.Drawing.Color.White
        Me.txtNoteCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoteCustomer.Location = New System.Drawing.Point(12, 44)
        Me.txtNoteCustomer.Name = "txtNoteCustomer"
        Me.txtNoteCustomer.ReadOnly = True
        Me.txtNoteCustomer.Size = New System.Drawing.Size(156, 20)
        Me.txtNoteCustomer.TabIndex = 26
        '
        'txtNoteSubject
        '
        Me.txtNoteSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoteSubject.Location = New System.Drawing.Point(12, 174)
        Me.txtNoteSubject.Name = "txtNoteSubject"
        Me.txtNoteSubject.Size = New System.Drawing.Size(156, 20)
        Me.txtNoteSubject.TabIndex = 27
        '
        'txtNoteBody
        '
        Me.txtNoteBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoteBody.Location = New System.Drawing.Point(184, 23)
        Me.txtNoteBody.MaxLength = 500
        Me.txtNoteBody.Multiline = True
        Me.txtNoteBody.Name = "txtNoteBody"
        Me.txtNoteBody.Size = New System.Drawing.Size(378, 238)
        Me.txtNoteBody.TabIndex = 28
        Me.txtNoteBody.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpNoteDate
        '
        Me.dtpNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNoteDate.Location = New System.Drawing.Point(12, 109)
        Me.dtpNoteDate.Name = "dtpNoteDate"
        Me.dtpNoteDate.Size = New System.Drawing.Size(156, 20)
        Me.dtpNoteDate.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Note Subject"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Note Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Customer"
        '
        'CustomerNoteCreation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 273)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpNoteDate)
        Me.Controls.Add(Me.txtNoteBody)
        Me.Controls.Add(Me.txtNoteSubject)
        Me.Controls.Add(Me.txtNoteCustomer)
        Me.Controls.Add(Me.cmdCreateNewNote)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "CustomerNoteCreation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Create New Customer Note"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCreateNewNote As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtNoteCustomer As System.Windows.Forms.TextBox
    Friend WithEvents txtNoteSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtNoteBody As System.Windows.Forms.TextBox
    Friend WithEvents dtpNoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
