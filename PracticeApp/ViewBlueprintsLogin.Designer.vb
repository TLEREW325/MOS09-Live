<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBlueprintsLogin
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvFormLogin = New System.Windows.Forms.DataGridView
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.FormLoginTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FormLoginTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FormLoginTableTableAdapter
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.LoginNameInDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginNameOutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateTimeInDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateTimeOutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FormNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvFormLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormLoginTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(509, 231)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 30)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvFormLogin
        '
        Me.dgvFormLogin.AllowUserToAddRows = False
        Me.dgvFormLogin.AllowUserToDeleteRows = False
        Me.dgvFormLogin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFormLogin.AutoGenerateColumns = False
        Me.dgvFormLogin.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFormLogin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormLogin.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LoginNameInDataGridViewTextBoxColumn, Me.LoginNameOutDataGridViewTextBoxColumn, Me.DateTimeInDataGridViewTextBoxColumn, Me.DateTimeOutDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.FormNameDataGridViewTextBoxColumn})
        Me.dgvFormLogin.DataSource = Me.FormLoginTableBindingSource
        Me.dgvFormLogin.GridColor = System.Drawing.Color.Red
        Me.dgvFormLogin.Location = New System.Drawing.Point(12, 12)
        Me.dgvFormLogin.Name = "dgvFormLogin"
        Me.dgvFormLogin.ReadOnly = True
        Me.dgvFormLogin.Size = New System.Drawing.Size(568, 213)
        Me.dgvFormLogin.TabIndex = 1
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FormLoginTableBindingSource
        '
        Me.FormLoginTableBindingSource.DataMember = "FormLoginTable"
        Me.FormLoginTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'FormLoginTableTableAdapter
        '
        Me.FormLoginTableTableAdapter.ClearBeforeFill = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 231)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(71, 30)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'LoginNameInDataGridViewTextBoxColumn
        '
        Me.LoginNameInDataGridViewTextBoxColumn.DataPropertyName = "LoginNameIn"
        Me.LoginNameInDataGridViewTextBoxColumn.HeaderText = "Login Name"
        Me.LoginNameInDataGridViewTextBoxColumn.Name = "LoginNameInDataGridViewTextBoxColumn"
        Me.LoginNameInDataGridViewTextBoxColumn.ReadOnly = True
        Me.LoginNameInDataGridViewTextBoxColumn.Width = 110
        '
        'LoginNameOutDataGridViewTextBoxColumn
        '
        Me.LoginNameOutDataGridViewTextBoxColumn.DataPropertyName = "LoginNameOut"
        Me.LoginNameOutDataGridViewTextBoxColumn.HeaderText = "Logout Name"
        Me.LoginNameOutDataGridViewTextBoxColumn.Name = "LoginNameOutDataGridViewTextBoxColumn"
        Me.LoginNameOutDataGridViewTextBoxColumn.ReadOnly = True
        Me.LoginNameOutDataGridViewTextBoxColumn.Width = 110
        '
        'DateTimeInDataGridViewTextBoxColumn
        '
        Me.DateTimeInDataGridViewTextBoxColumn.DataPropertyName = "DateTimeIn"
        Me.DateTimeInDataGridViewTextBoxColumn.HeaderText = "Date/Time In"
        Me.DateTimeInDataGridViewTextBoxColumn.Name = "DateTimeInDataGridViewTextBoxColumn"
        Me.DateTimeInDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateTimeInDataGridViewTextBoxColumn.Width = 110
        '
        'DateTimeOutDataGridViewTextBoxColumn
        '
        Me.DateTimeOutDataGridViewTextBoxColumn.DataPropertyName = "DateTimeOut"
        Me.DateTimeOutDataGridViewTextBoxColumn.HeaderText = "Date/Time Out"
        Me.DateTimeOutDataGridViewTextBoxColumn.Name = "DateTimeOutDataGridViewTextBoxColumn"
        Me.DateTimeOutDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateTimeOutDataGridViewTextBoxColumn.Width = 110
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Width = 80
        '
        'FormNameDataGridViewTextBoxColumn
        '
        Me.FormNameDataGridViewTextBoxColumn.DataPropertyName = "FormName"
        Me.FormNameDataGridViewTextBoxColumn.HeaderText = "Form"
        Me.FormNameDataGridViewTextBoxColumn.Name = "FormNameDataGridViewTextBoxColumn"
        Me.FormNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.FormNameDataGridViewTextBoxColumn.Visible = False
        '
        'ViewBlueprintsLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.dgvFormLogin)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "ViewBlueprintsLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corp Blueprint Login"
        CType(Me.dgvFormLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormLoginTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvFormLogin As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FormLoginTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FormLoginTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FormLoginTableTableAdapter
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents LoginNameInDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginNameOutDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTimeInDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTimeOutDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
