Imports System.Data.SqlClient

Public Class HeaderSetupSheetSelectFOX
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal bp As String)
        InitializeComponent()

        cmd = New SqlCommand("SELECT FOXTable.FOXNumber, BlueprintRevision, ShortDescription, CustomerID FROM FOXTable LEFT OUTER JOIN ItemList ON FOXTable.ParTNumber = ItemList.ItemID AND FOXTable.DivisionID = ItemList.DivisionID WHERE BlueprintNumber = @BlueprintNumber AND FOXTable.Status <> 'INACTIVE'", con)
        cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = bp
        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "FOXTable")
        con.Close()

        dgvFOXes.DataSource = tempds.Tables("FOXTable")
        dgvFOXes.Columns("FOXNumber").HeaderText = "FOX #"
        dgvFOXes.Columns("FOXNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvFOXes.Columns("BlueprintRevision").HeaderText = "Blueprint Rev."
        dgvFOXes.Columns("BlueprintRevision").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvFOXes.Columns("ShortDescription").HeaderText = "Short Description"
        dgvFOXes.Columns("ShortDescription").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvFOXes.Columns("CustomerID").Visible = False
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class