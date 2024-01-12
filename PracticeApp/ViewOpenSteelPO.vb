Imports System.Data.SqlClient

Public Class ViewOpenSteelPO
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet

    Public Sub New()
        InitializeComponent()

        usefulFunctions.LoadSecurity(Me)
    End Sub

    Private Sub ViewOpenSteelPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd = New SqlCommand("SELECT SteelPurchaseOrderHeaderKey, SteelPurchaseOrderDate, SteelVendorID, Carbon, SteelSize, Description, QuantityOpen, PurchasePricePerPound, ROUND((PurchasePricePerPound * QuantityOpen), 2) as RemaingCost FROM SteelPurchaseQuantityStatus WHERE LineStatus = 'OPEN' AND QuantityOpen > 0 AND Status <> 'CLOSED' ORDER BY SteelPurchaseOrderDate DESC", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelPurchaseQuantityStatus")
        con.Close()

        dgvOpenSteelPO.DataSource = ds.Tables("SteelPurchaseQuantityStatus")
        setupDGV()
    End Sub

    Private Sub setupDGV()
        dgvOpenSteelPO.Columns("SteelPurchaseOrderHeaderKey").HeaderText = "PO #"
        dgvOpenSteelPO.Columns("SteelPurchaseOrderDate").HeaderText = "PO Date"
        dgvOpenSteelPO.Columns("SteelVendorID").HeaderText = "Vendor ID"
        dgvOpenSteelPO.Columns("SteelSize").HeaderText = "Steel Size"
        dgvOpenSteelPO.Columns("QuantityOpen").HeaderText = "Open Qty"
        dgvOpenSteelPO.Columns("PurchasePricePerPound").HeaderText = "Price per Pound"
        dgvOpenSteelPO.Columns("RemaingCost").HeaderText = "Remaing Cost"
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub dgvOpenSteelPO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenSteelPO.CellDoubleClick
        cmdOpenSteelPO_Click(sender, e)
    End Sub

    Private Sub cmdOpenSteelPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenSteelPO.Click
        Dim newSteelPO As New SteelPurchaseOrder
        newSteelPO.Show()
        newSteelPO.setPO(dgvOpenSteelPO.Rows(dgvOpenSteelPO.CurrentCell.RowIndex).Cells("SteelPurchaseOrderHeaderKey").Value)
        Me.Hide()
        newSteelPO.Parent = Me.ParentForm()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using newPrintSteelPO As New PrintOpenSteelPOList(ds)
            newPrintSteelPO.ShowDialog()
        End Using
    End Sub
End Class
