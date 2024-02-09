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
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalItemClass = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    'Sets up viewer to display data from the loaded dataset
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub CRReorderViewer_Load(sender As Object, e As EventArgs) Handles CRReorderViewer.Load
        If GlobalItemClass = "NO FILTER" Or GlobalItemClass = "" Then
            'Loads data into dataset for viewing
            If GlobalDivisionCode = "TWE" Then
                cmd = New SqlCommand("SELECT LastYearShippedTodate, ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND MaximumStock <> 0 AND MinimumStock <> 0 AND ItemClass NOT LIKE @ItemClass AND ItemClass NOT LIKE @ItemClass2 ORDER BY ItemID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "%SUPPLY%"
                cmd.Parameters.Add("@ItemClass2", SqlDbType.VarChar).Value = "%RENT%"
            Else
                cmd = New SqlCommand("SELECT LastYearShippedTodate, ItemID, ShortDescription, MaximumStock, MinimumStock, TotalQuantityShipped, OpenSoQuantity, OpenPOQuantity, QuantityOnHand, DivisionID, PreferredVendor From ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' AND ((MaximumStock <> 0 AND MinimumStock <> 0) OR OpenSOQuantity > QuantityOnHand) ORDER BY ItemID", con)
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


        If GlobalDivisionCode = "TWE" Then
            'MyReport = CRXReorderWorksheetTWE1
        Else
            MyReport = crxReorderWorksheet1
        End If

        MyReport.SetDataSource(ds)
        CRReorderViewer.ReportSource = MyReport
        con.Close()
    End Sub

End Class