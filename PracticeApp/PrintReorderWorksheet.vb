Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintReorderWorksheet
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder

    Private Sub PrintReorderWorksheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalItemClass = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRReorderViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRReorderViewer.Load
        If GlobalItemClass = "NO FILTER" Or GlobalItemClass = "" Then
            'Loads data into dataset for viewing
            If GlobalDivisionCode = "TWE" Then
                cmd = New SqlCommand("SELECT LastYearShippedTodate,ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND MaximumStock <> 0 AND MinimumStock <> 0 AND ItemClass NOT LIKE @ItemClass AND ItemClass NOT LIKE @ItemClass2 ORDER BY ItemID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "%SUPPLY%"
                cmd.Parameters.Add("@ItemClass2", SqlDbType.VarChar).Value = "%RENT%"
            Else
                cmd = New SqlCommand("SELECT LastYearShippedTodate,ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND ((MaximumStock <> 0 AND MinimumStock <> 0) OR OpenSOQuantity > QuantityOnHand) ORDER BY ItemID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = 0
                'cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = 0
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ADMInventoryTotal")
        Else
            'Loads data into dataset for viewing
            If GlobalDivisionCode = "TWE" Then
                cmd = New SqlCommand("SELECT LastYearShippedTodate,ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass AND MaximumStock <> 0 AND MinimumStock <> 0 ORDER BY ItemID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = GlobalItemClass
            Else
                cmd = New SqlCommand("SELECT LastYearShippedTodate,ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass AND ((MaximumStock <> 0 AND MinimumStock <> 0) OR OpenSOQuantity > QuantityOnHand) ORDER BY ItemID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = GlobalItemClass
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ADMInventoryTotal")
        End If

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        If GlobalDivisionCode = "TWE" Then
            MyReport = CRXReorderWorksheetTWE1
        Else
            MyReport = CRXReorderWorksheet1
        End If

        MyReport.SetDataSource(ds)
        CRReorderViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintReorderWorksheet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalItemClass = ""
    End Sub
End Class