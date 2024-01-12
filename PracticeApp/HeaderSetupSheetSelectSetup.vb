Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class HeaderSetupSheetSelectSetup

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal bp As String, ByVal SetupKey As Integer)
        InitializeComponent()

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("SELECT SetupKey, FOXNumber, Description, BlueprintRevision, Operator, CustomerID, Comments FROM HeaderSetupHeaderTable WHERE BlueprintNumber = @BlueprintNumber and SetupKey <> @SetupKey", con)
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.Int).Value = Val(bp)
        cmd.Parameters.Add("@SetupKey", SqlDbType.Int).Value = SetupKey
        Dim ds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "HeaderSetupHeaderTable")
        con.Close()

        dgvSetup.DataSource = ds.Tables("HeaderSetupHeaderTable")
        dgvSetup.Columns("SetupKey").Visible = False
        dgvSetup.Columns("FOXNumber").HeaderText = ""
        dgvSetup.Columns("BlueprintRevision").HeaderText = "Rev."
        dgvSetup.Columns("CustomerID").HeaderText = "Customer"
        dgvSetup.Columns("CustomerID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvSetup.Columns("Comments").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub HeaderSetupSheetSelectSetup_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = System.Windows.Forms.DialogResult.None Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class