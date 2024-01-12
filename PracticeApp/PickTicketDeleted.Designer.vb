<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickTicketDeleted
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
        Me.cboPickTicket = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPickTicket
        '
        Me.cboPickTicket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicket.DataSource = Me.PickListHeaderTableBindingSource
        Me.cboPickTicket.DisplayMember = "PickListHeaderKey"
        Me.cboPickTicket.FormattingEnabled = True
        Me.cboPickTicket.Location = New System.Drawing.Point(142, 115)
        Me.cboPickTicket.Name = "cboPickTicket"
        Me.cboPickTicket.Size = New System.Drawing.Size(201, 21)
        Me.cboPickTicket.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(487, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Pick Ticket from drop down list to be deleted."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(195, 182)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(272, 182)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'PickTicketDeleted
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPickTicket)
        Me.Name = "PickTicketDeleted"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Pick Ticket For Deletion"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboPickTicket As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
End Class
