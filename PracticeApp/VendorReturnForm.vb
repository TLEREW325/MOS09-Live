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
Public Class VendorReturnForm
    Inherits System.Windows.Forms.Form

    Dim CloseReceiver, CheckVoucherStatus, ReturnStatus, ItemClassName, GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLPurchasesAccount As String
    Dim VendorClass, VerifyVendor, VendorName, LongDescription, ItemClass, VendorID, ReturnDate, ReturnComment, PartNumber, PartDescription As String
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, CountVoucherLines, LineReceiverNumber, LineReceiverLineNumber, GetPOLineCount, GetPONumber, NextGLNumber, LastGLNumber, PONumber, counter, LastLineNumber, NextLineNumber, LastTransactionNumber, NextTransactionNumber As Integer
    Dim MatchReturnTotal, MatchReceiverTotal, StandardCost, Cost, ExtendedAmount, ProductTotal, SalesTaxTotal, FreightTotal, OtherTotal, ReturnTotal, Quantity As Double
    Dim ConvertReturnDate As Date
    Dim GetPurchProdLineID As String = ""
    Dim GetSerialStatus As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim isLoaded As Boolean = False
    Dim lastReturn As String = ""

    'Form Routines

    Private Sub VendorReturnForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()

        If EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1001 Or EmployeeLoginName = "HSRYAN" Then
            REOpenVendorReturnToolStripMenuItem.Enabled = True
        Else
            REOpenVendorReturnToolStripMenuItem.Enabled = False
        End If

        'Load Defaults lists for specific company
        ClearVariables()
        ClearData()
        LoadReturnNumber()
        LoadVendor()
        LoadPONumber()
        LoadItemList()

        isLoaded = True

        If GlobalVendorReturnNumber = 0 Then
            ClearData()
            ShowData()
        Else
            cboReturnNumber.Text = GlobalVendorReturnNumber
            cboPurchaseOrderNumber.Text = GlobalPONumber
            cboDivisionID.Text = GlobalDivisionCode
            ShowData()
            CalculateReturnTotals()
        End If
    End Sub

    Private Sub VendorReturnForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    'Load Data into controls and datagrid

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "VendorReturnLine")
        dgvReturnLines.DataSource = ds.Tables("VendorReturnLine")
        cboDeleteLineNumber.DataSource = ds.Tables("VendorReturnLine")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvReturnLines.DataSource = Nothing
    End Sub

    Public Sub LoadNonInventoryItemList()
        'Loads only Part Number for the correct division
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND PurchProdLineID = @PurchProdLineID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "NON-INVENTORY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadItemList()
        'Loads only Part Number for the correct division
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        'Loads only Vendor for the correct division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorCode.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorCode.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        'Loads only PO Number for the correct division
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "PurchaseOrderHeaderTable")
        cboPurchaseOrderNumber.DataSource = ds3.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReturnNumber()
        'Loads only PO Number for the correct division
        cmd = New SqlCommand("SELECT ReturnNumber FROM VendorReturn WHERE DivisionID = @DivisionID ORDER BY ReturnNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "VendorReturn")
        cboReturnNumber.DataSource = ds4.Tables("VendorReturn")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialLines()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "AssemblySerialTempTable")
        dgvSerialLines.DataSource = ds8.Tables("AssemblySerialTempTable")
        con.Close()
    End Sub

    Public Sub ClearSerialLines()
        dgvSerialLines.DataSource = Nothing
    End Sub

    'Load Data subroutines

    Public Sub LoadPOData()
        Dim VendorIDStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
        Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
        VendorIDCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorID = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorID = ""
        End Try
        con.Close()

        cboVendorCode.Text = VendorID
    End Sub

    Public Sub LoadReturnData()
        Dim PONumberStatement As String = "SELECT * FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
        PONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = PONumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PONumber")) Then
                PONumber = Val(cboPurchaseOrderNumber.Text)
            Else
                PONumber = reader.Item("PONumber")
            End If
            If IsDBNull(reader.Item("ReturnDate")) Then
                ReturnDate = dtpReturnDate.Text
            Else
                ReturnDate = reader.Item("ReturnDate")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = cboVendorCode.Text
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("ReturnComment")) Then
                ReturnComment = ""
            Else
                ReturnComment = reader.Item("ReturnComment")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("SalesTaxTotal")) Then
                SalesTaxTotal = 0
            Else
                SalesTaxTotal = reader.Item("SalesTaxTotal")
            End If
            If IsDBNull(reader.Item("FreightTotal")) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.Item("FreightTotal")
            End If
            If IsDBNull(reader.Item("ReturnTotal")) Then
                ReturnTotal = 0
            Else
                ReturnTotal = reader.Item("ReturnTotal")
            End If
            If IsDBNull(reader.Item("ReturnStatus")) Then
                ReturnStatus = "OPEN"
            Else
                ReturnStatus = reader.Item("ReturnStatus")
            End If
        Else
            PONumber = Val(cboPurchaseOrderNumber.Text)
            ReturnDate = dtpReturnDate.Text
            VendorID = cboVendorCode.Text
            ReturnComment = ""
            ProductTotal = 0
            SalesTaxTotal = 0
            FreightTotal = 0
            ReturnTotal = 0
            ReturnStatus = "OPEN"
        End If
        reader.Close()
        con.Close()

        If cboDivisionID.Text.Equals("TOR") Or cboDivisionID.Text.Equals("TFF") Or cboDivisionID.Text = "ALB" Then
            Dim temp As String() = ReturnDate.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
            If Val(temp(0)) > 12 Then
                dtpReturnDate.Text = temp(1) + "/" + temp(0) + "/" + temp(2)
            Else
                dtpReturnDate.Text = ReturnDate
            End If
        Else
            dtpReturnDate.Text = ReturnDate
        End If

        cboPurchaseOrderNumber.Text = PONumber

        cboVendorCode.Text = VendorID
        txtComment.Text = ReturnComment
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtSalesTax.Text = SalesTaxTotal
        txtFreight.Text = FreightTotal
        txtReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
        txtReturnStatus.Text = ReturnStatus
    End Sub

    Public Sub LoadVendorData()
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadItemData()
        Dim GetItemDataStatement As String = "SELECT LongDescription, StandardCost, ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetItemDataCommand As New SqlCommand(GetItemDataStatement, con)
        GetItemDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetItemDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetItemDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("StandardCost")) Then
                StandardCost = 0
            Else
                StandardCost = reader.Item("StandardCost")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
        Else
            LongDescription = ""
            StandardCost = 0
            ItemClass = ""
        End If
        reader.Close()
        con.Close()

        txtLongDescription.Text = LongDescription
        txtUnitCost.Text = StandardCost
        cboItemClass.Text = ItemClass
    End Sub

    Public Sub LoadItemClassData()
        Dim ItemClassNameStatement As String = "SELECT * FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim ItemClassNameCommand As New SqlCommand(ItemClassNameStatement, con)
        ItemClassNameCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ItemClassNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ItemClassName")) Then
                ItemClassName = ""
            Else
                ItemClassName = reader.Item("ItemClassName")
            End If
            If IsDBNull(reader.Item("GLSalesAccount")) Then
                GLSalesAccount = ""
            Else
                GLSalesAccount = reader.Item("GLSalesAccount")
            End If
            If IsDBNull(reader.Item("GLReturnsAccount")) Then
                GLReturnsAccount = ""
            Else
                GLReturnsAccount = reader.Item("GLReturnsAccount")
            End If
            If IsDBNull(reader.Item("GLInventoryAccount")) Then
                GLInventoryAccount = ""
            Else
                GLInventoryAccount = reader.Item("GLInventoryAccount")
            End If
            If IsDBNull(reader.Item("GLCOGSAccount")) Then
                GLCOGSAccount = ""
            Else
                GLCOGSAccount = reader.Item("GLCOGSAccount")
            End If
            If IsDBNull(reader.Item("GLPurchasesAccount")) Then
                GLPurchasesAccount = ""
            Else
                GLPurchasesAccount = reader.Item("GLPurchasesAccount")
            End If
        Else
            ItemClassName = ""
            GLSalesAccount = ""
            GLReturnsAccount = ""
            GLInventoryAccount = ""
            GLCOGSAccount = ""
            GLPurchasesAccount = ""
        End If
        reader.Close()
        con.Close()

        txtItemClassDescription.Text = ItemClassName
        txtGLSales.Text = GLSalesAccount
        txtGLReturns.Text = GLReturnsAccount
        txtGLInventory.Text = GLInventoryAccount
        txtGLCOGS.Text = GLCOGSAccount
        txtGLPurchases.Text = GLPurchasesAccount
    End Sub

    Public Sub CalculateReturnTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxTotalStatement As String = "SELECT SalesTaxTotal, FreightTotal FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
        SalesTaxTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        SalesTaxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try

        Dim reader As SqlDataReader = SalesTaxTotalCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                SalesTaxTotal = 0
            Else
                SalesTaxTotal = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.GetValue(1)
            End If
        Else
            SalesTaxTotal = 0
        End If
        reader.Close()
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)

        ReturnTotal = ProductTotal + FreightTotal + SalesTaxTotal

        txtReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtSalesTax.Text = SalesTaxTotal
        txtFreight.Text = FreightTotal
    End Sub

    Public Sub ReCalculateReturnTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)
        FreightTotal = Val(txtFreight.Text)
        SalesTaxTotal = Val(txtSalesTax.Text)

        ReturnTotal = ProductTotal + FreightTotal + SalesTaxTotal
        txtReturnTotal.Text = FormatCurrency(ReturnTotal, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
    End Sub

    'Save or Insert Routines

    Private Sub updateOrInsertIntoVendorReturn(Optional ByVal status As String = "OPEN")
        cmd = New SqlCommand("Select * FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            updateVendorReturn(status)
        Else
            reader.Close()
            con.Close()
            insertIntoVendorReturn(status)
        End If
    End Sub

    Private Sub updateVendorReturn(Optional ByVal status As String = "OPEN")
        'Write to database one time (re-write header information and totals)
        cmd = New SqlCommand("UPDATE VendorReturn SET PONumber = @PONumber, ReturnDate = @ReturnDate, VendorID = @VendorID, ReturnComment = @ReturnComment, ProductTotal = @ProductTotal, SalesTaxTotal = @SalesTaxTotal, FreightTotal = @FreightTotal, OtherTotal = @OtherTotal, ReturnTotal = @ReturnTotal, ReturnStatus = @ReturnStatus, Locked = @Locked WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ReturnDate", SqlDbType.VarChar).Value = ConvertReturnDate
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text
            .Add("@ReturnComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@SalesTaxTotal", SqlDbType.VarChar).Value = SalesTaxTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
            .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = status
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateProductAndReturnTotals(ByVal fromFunction As String)
        Try
            cmd = New SqlCommand("UPDATE VendorReturn SET ProductTotal = @ProductTotal, ReturnTotal = @ReturnTotal WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            cmd.Parameters.Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase(fromFunction + "Error trying to update ProductTotal and ReturnTotal in VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
        End Try
    End Sub

    Private Sub updateExtendedAmount(ByVal fromFunction As String)
        Try
            'UPDATE Lines in case of changes
            cmd = New SqlCommand("UPDATE VendorReturnLine SET ExtendedAmount = Quantity * Cost WHERE ReturnNumber = @ReturnNumber", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase(fromFunction + "Error trying to update ExtendedAmount in VendorReturnLine", "Return #" + cboReturnNumber.Text, ex.ToString())
        End Try
    End Sub

    Private Sub updateVendorReturnStatus()
        'Close Return Header
        cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub updateVendorReturnLineStatus()
        'Close Vendor Return Line Table
        cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub insertIntoVendorReturn(Optional ByVal status As String = "OPEN")
        'Write to database one time (re-write header information and totals)
        cmd = New SqlCommand("INSERT INTO VendorReturn (ReturnNumber, PONumber, DivisionID, ReturnDate, VendorID, ReturnComment, ProductTotal, SalesTaxTotal, FreightTotal, OtherTotal, ReturnTotal, ReturnStatus, Locked, UserID) Values (@ReturnNumber, @PONumber, @DivisionID, @ReturnDate, @VendorID, @ReturnComment, @ProductTotal, @SalesTaxTotal, @FreightTotal, @OtherTotal, @ReturnTotal, @ReturnStatus, @Locked, @UserID)", con)

        With cmd.Parameters
            .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ReturnDate", SqlDbType.VarChar).Value = ConvertReturnDate
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text
            .Add("@ReturnComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@SalesTaxTotal", SqlDbType.VarChar).Value = SalesTaxTotal
            .Add("@FreightTotal", SqlDbType.VarChar).Value = FreightTotal
            .Add("@OtherTotal", SqlDbType.VarChar).Value = 0
            .Add("@ReturnTotal", SqlDbType.VarChar).Value = ReturnTotal
            .Add("@ReturnStatus", SqlDbType.VarChar).Value = status
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Datagrid routines

    Private Sub dgvReturnLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnLines.CellDoubleClick
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
            'Get Part Data and open Serial Popup
            Dim RowPartNumber As String = ""
            Dim RowQuantity As Double = 0
            Dim RowLineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvReturnLines.CurrentCell.RowIndex

            RowPartNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            RowQuantity = Me.dgvReturnLines.Rows(RowIndex).Cells("QuantityColumn").Value
            RowLineNumber = Me.dgvReturnLines.Rows(RowIndex).Cells("ReturnLineNumberColumn").Value
            '*************************************************************************************************************
            'Check to see if part is a serialized assembly
            Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
            GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
            Catch ex As Exception
                GetPurchProdLineID = ""
            End Try
            con.Close()
            '*************************************************************************************************************
            If GetPurchProdLineID = "ASSEMBLY" Then
                Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSerialStatus = "NO"
                End Try
                con.Close()
                '*********************************************************************************************************
                If GetSerialStatus = "YES" Then
                    'Open serial popup
                    GlobalAssemblyTransactionNumber = Val(cboReturnNumber.Text)
                    GlobalSerialAssemblyQuantity = RowQuantity
                    GlobalSerialFormLocation = "VENDORRETURN"
                    GlobalAssemblyPartNumber = RowPartNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalAssemblyBatchNumber = RowLineNumber

                    Using NewAssemblySerialPopup As New AssemblySerialPopup
                        Dim Result = NewAssemblySerialPopup.ShowDialog()
                    End Using

                    'Show Lines
                    ShowSerialLines()
                Else
                    'Do nothing - exit sub
                    Exit Sub
                End If
            Else
                'Do nothing - exit sub
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvReturnLines.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                LoadReturnData()
                LoadReturnStatus()
                ShowData()
                checkRows()
                Exit Sub
            End If
            LockBatch()

            Dim LineOrderQuantity, LineExtendedAmount, LineUnitCost As Double
            Dim LineNumber As Integer

            Dim currentRow As Integer = dgvReturnLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvReturnLines.CurrentCell.ColumnIndex
            ''UPDATE Line Table on changes in the datagrid
            If IsDBNull(dgvReturnLines.Rows(currentRow).Cells("CostColumn").Value) Then
                LineUnitCost = 0
            Else
                LineUnitCost = dgvReturnLines.Rows(currentRow).Cells("CostColumn").Value
            End If
            If IsDBNull(dgvReturnLines.Rows(currentRow).Cells("QuantityColumn").Value) Then
                LineOrderQuantity = 0
            Else
                LineOrderQuantity = dgvReturnLines.Rows(currentRow).Cells("QuantityColumn").Value
            End If

            LineNumber = dgvReturnLines.Rows(currentRow).Cells("ReturnLineNumberColumn").Value
            '***************************************************************************************************
            'If Cost is negative, exit sub with warning
            If LineUnitCost < 0 Then
                MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '***************************************************************************************************
            LineExtendedAmount = LineUnitCost * LineOrderQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

            Try
                'UPDATE Line Table based on line changes
                cmd = New SqlCommand("UPDATE VendorReturnLine SET Cost = @Cost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = LineNumber
                    .Add("@Cost", SqlDbType.VarChar).Value = LineUnitCost
                    .Add("@Quantity", SqlDbType.VarChar).Value = LineOrderQuantity
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                sendErrorToDataBase("VendorReturnForm - cell changed --Error trying to update line " + LineNumber.ToString() + "in the VendorReturnLine table", "Return #" + cboReturnNumber.Text, ex.ToString())
            End Try

            ReCalculateReturnTotals()

            Try
                updateProductAndReturnTotals("VenforReturnForm - cell changed --")
            Catch ex As Exception
                sendErrorToDataBase("VendorReturnForm - cell changed --Error trying to update ProductTotal and ReturnTotal in VendorReturn table", "Return #" + cboReturnNumber.Text, ex.ToString())
            End Try

            ShowData()

            'Resets the current cell back to where it was located
            dgvReturnLines.CurrentCell = dgvReturnLines.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    'Command Buttons

    Private Sub cmdItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using NewItemMaintenance As New ItemMaintenance
            Dim result = NewItemMaintenance.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim rslt As DialogResult = canExit()
        If rslt = DialogResult.Yes Then

            ConvertReturnDate = dtpReturnDate.Value

            ''checks the database to make sure the vendor is a valid vendor
            checkVendor()

            If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Else
                Try
                    'Save data in datagrid
                    Dim Updater As New SqlCommandBuilder(myAdapter)
                    Me.Validate()
                    Me.myAdapter.Update(Me.ds.Tables("VendorReturnLine"))
                    Me.ds.AcceptChanges()
                Catch ex As Exception
                    sendErrorToDataBase("Error trying to update datagrid", "no reference number", ex.ToString())
                End Try

                'Do not allow change of PO Number if Vendor Return has lines
                Dim GetPOLineCountStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                Dim GetPOLineCountCommand As New SqlCommand(GetPOLineCountStatement, con)
                GetPOLineCountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                GetPOLineCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPOLineCount = CInt(GetPOLineCountCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPOLineCount = 0
                End Try
                con.Close()

                If GetPOLineCount > 0 Then
                    'Verify that only one PO is used per Return
                    Dim GetPONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                    Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                    GetPONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPONumber = 0
                    End Try
                    con.Close()
                    Try
                        updateVendorReturn()
                    Catch ex As Exception
                        sendErrorToDataBase("VendorReturnForm - cmdExit_Click --Error trying to update VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
                        Exit Sub
                    End Try
                Else
                    Try
                        updateVendorReturn()
                    Catch ex As Exception
                        sendErrorToDataBase("VendorReturnForm - cmdExit_Click --Error trying to update VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
                        Exit Sub
                    End Try
                End If

                updateExtendedAmount("VenforReturnForm - cmdExit_Click --")

                'Extract data to UPDATE Totals
                Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                con.Close()

                'UPDATE Totals
                ReturnTotal = ProductTotal + SalesTaxTotal + FreightTotal

                updateProductAndReturnTotals("VenforReturnForm - cmdExit_Click --")

                unlockBatch()
                GlobalDivisionCode = ""
                GlobalVendorReturnNumber = 0
                GlobalPONumber = 0
                ClearVariables()
                ClearData()
                Me.Dispose()
                Me.Close()
            End If
        ElseIf rslt = DialogResult.Cancel Then
            Exit Sub
        End If

        unlockBatch()
        GlobalDivisionCode = ""
        GlobalVendorReturnNumber = 0
        GlobalPONumber = 0
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearLines()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        unlockBatch()
        ClearData()
        ClearVariables()
        ClearSerialLines()
        ShowData()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Exit Sub
        End If
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Vendor Return?", "DELETE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Verify that Return is not posted
            LoadReturnStatus()

            If ReturnStatus = "CLOSED" Or ReturnStatus = "POSTED" Then
                MsgBox("You cannot delete a Posted Reurn.", MsgBoxStyle.OkOnly)
            Else
                'Write to Audit Trail Table
                Dim AuditComment As String = ""
                Dim AuditReturnNumber As Integer = 0
                Dim strReturnNumber As String = ""

                AuditReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber = CStr(AuditReturnNumber)
                AuditComment = "Return #" + strReturnNumber + " for vendor " + cboVendorCode.Text + " was deleted on " + Today()

                Try
                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "VENDOR RETURN - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = ReturnTotal
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReturnNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber2 As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber2 = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Vendor Return Form --- Insert Into Audit Log"
                    ErrorReferenceNumber = "Return # " + strReturnNumber2
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**********************************************************************************************************
                Try
                    'Create command to delete Vendor Return
                    cmd = New SqlCommand("DELETE FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    sendErrorToDataBase("VendorReturnForm - cmdDelete_Click --Error trying to delete " + cboReturnNumber.Text + " from VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
                    Exit Sub
                End Try
                '***********************************************************************************
                'Delete from Serial Lines if applicable
                Try
                    'Create command to delete data from text boxes
                    cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber2 As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber2 = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Vendor Return Form --- Delete Serial Temp"
                    ErrorReferenceNumber = "Return # " + strReturnNumber2
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************
                MsgBox("Vendor Return has been deleted", MsgBoxStyle.OkOnly)

                GlobalDivisionCode = ""
                GlobalVendorReturnNumber = 0
                GlobalPONumber = 0
                cboReturnNumber.Text = ""
                LoadReturnNumber()
                ShowData()
                ClearVariables()
                ClearData()
            End If
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If canDeleteLine() Then
            LockBatch()
            Try
                'Create command to delete line from Vendor Return
                cmd = New SqlCommand("DELETE FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)
                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                cmd.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = Val(cboDeleteLineNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '******************************************************************************************
                'Delete from Serial Lines if applicable
                Try
                    'Create command to delete data from text boxes
                    cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
                    cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboDeleteLineNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber2 As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber2 = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Vendor Return Form --- Delete Serial Temp"
                    ErrorReferenceNumber = "Return # " + strReturnNumber2
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************
                'Refresh Datagrid
                ShowData()

                'Sum lines to recalculate total
                ReCalculateReturnTotals()

                ''if there are no lines in the datagrid this will clear the text in the deleteline cbo
                If dgvReturnLines.Rows.Count = 0 Then
                    cboDeleteLineNumber.Text = ""
                End If
                MessageBox.Show("Line has been deleted sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                sendErrorToDataBase("VendorReturnForm - cmdDeleteLine_Click --Error trying to delete " + cboReturnNumber.Text + " from VendorReturnLine", "Return #" + cboReturnNumber.Text, ex.ToString())
                MsgBox("You cannot delete this line.", MsgBoxStyle.OkOnly)
            End Try

            checkRows()
        End If
    End Sub

    Private Sub cmdGenerateReturnNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateReturnNumber.Click
        If Not String.IsNullOrEmpty(lastReturn) Then
            unlockBatch(lastReturn)
        End If

        'Clear form on next number
        ClearVariables()
        ClearData()
        ShowData()

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a valid division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim MAXStatement As String = "SELECT MAX(ReturnNumber) FROM VendorReturn"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 98000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboReturnNumber.Text = NextTransactionNumber

        ConvertReturnDate = dtpReturnDate.Value

        Try
            updateOrInsertIntoVendorReturn()
        Catch ex As Exception
            sendErrorToDataBase("VendorReturnForm - cmdGenerateReturnNumber_Click --Error trying to update or insert Return # " + cboReturnNumber.Text + " to the VendorReturn table", "Return #" + cboReturnNumber.Text, ex.ToString())
        End Try

        txtReturnStatus.Text = "OPEN"
        If cboPurchaseOrderNumber.Enabled = False Then
            cboPurchaseOrderNumber.Enabled = True
            cboVendorCode.Enabled = True
        End If
        isLoaded = False
        LoadReturnNumber()
        cboReturnNumber.Text = NextTransactionNumber
        isLoaded = True
        cboReturnNumber.Focus()
        lastReturn = cboReturnNumber.Text
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            'Validate Vendor
            Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
            VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
            VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyVendor = "DOES NOT EXIST"
            End Try
            con.Close()

            ConvertReturnDate = dtpReturnDate.Value

            If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Else
                'Do not allow change of PO Number if Vendor Return has lines
                Dim GetPOLineCountStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                Dim GetPOLineCountCommand As New SqlCommand(GetPOLineCountStatement, con)
                GetPOLineCountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                GetPOLineCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPOLineCount = CInt(GetPOLineCountCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPOLineCount = 0
                End Try
                con.Close()

                If GetPOLineCount > 0 Then
                    'Verify that only one PO is used per Return
                    Dim GetPONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                    Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                    GetPONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPONumber = 0
                    End Try
                    con.Close()
                End If
                '*********************************************************************************************
                Try
                    updateOrInsertIntoVendorReturn()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempReturnNumber As Integer = 0
                    Dim strReturnNumber As String
                    TempReturnNumber = Val(cboReturnNumber.Text)
                    strReturnNumber = CStr(TempReturnNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Vendor Return --- Save Button"
                    ErrorReferenceNumber = "Return # " + strReturnNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*********************************************************************************************
                'Save Line Data
                updateExtendedAmount("VenforReturnForm - cmdSave_Click --")
                '************************************************************************************************
                'Extract data to UPDATE Totals
                Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                con.Close()

                'UPDATE Totals
                ReturnTotal = ProductTotal + SalesTaxTotal + FreightTotal

                updateProductAndReturnTotals("VenforReturnForm - cmdSave_Click --")

                'Calculate totals and show updates
                CalculateReturnTotals()
                ShowData()
                '************************************************************************************************
                MsgBox("Vendor Return has been saved", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canAddLine() Then
            'Validate Vendor
            Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
            VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
            VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyVendor = "DOES NOT EXIST"
            End Try
            con.Close()

            If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Else
                'Recalulate Return Totals
                ReCalculateReturnTotals()
                '***************************************************************************************************
                ConvertReturnDate = dtpReturnDate.Value

                Try
                    updateOrInsertIntoVendorReturn()
                Catch ex As Exception
                    sendErrorToDataBase("VendorReturnForm - cmdEnter_Click --Error trying to update or insert Return # " + cboReturnNumber.Text + " to the VendorReturn table", "Return #" + cboReturnNumber.Text, ex.ToString())
                End Try
                '***************************************************************************************************
                'If Cost is negative, exit sub with warning
                If Val(txtUnitCost.Text) < 0 Then
                    MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***************************************************************************************************
                'Determine starting line number for Line Items
                Dim MAXLineStatement As String = "SELECT MAX(ReturnLineNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
                Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                MAXLineCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1

                Try
                    cmd = New SqlCommand("Insert Into VendorReturnLine(ReturnNumber, ReturnLineNumber, PartNumber, PartDescription, Quantity, Cost, LineComment, ExtendedAmount, DebitGLAccount, CreditGLAccount, LineStatus, DivisionID, ReceiverNumber, ReceiverLineNumber)Values(@ReturnNumber, @ReturnLineNumber, @PartNumber, @PartDescription, @Quantity, @Cost, @LineComment, @ExtendedAmount, @DebitGLAccount, @CreditGLAccount, @LineStatus, @DivisionID, @ReceiverNumber, @ReceiverLineNumber)", con)

                    With cmd.Parameters
                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
                        .Add("@Cost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                        .Add("@LineComment", SqlDbType.VarChar).Value = "PO # " & Val(cboPurchaseOrderNumber.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtGLPurchases.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtGLInventory.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ReceiverNumber", SqlDbType.VarChar).Value = 0
                        .Add("@ReceiverLineNumber", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    sendErrorToDataBase("VendorReturnForm - cmdEnter_Click --Error trying to insert line " + NextLineNumber.ToString() + " into VendorReturnLine table", "Return #" + cboReturnNumber.Text, ex.ToString())
                    MessageBox.Show("There was an error trying to add new line, contact system admin", "Error trying to add line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try

                updateExtendedAmount("VendorReturnForm - cmdEnter_Click --")
                '***************************************************************************************************
                'Extract data to UPDATE Totals
                Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                con.Close()

                'UPDATE Totals
                ReturnTotal = ProductTotal + SalesTaxTotal + FreightTotal
                '***************************************************************************************************
                updateProductAndReturnTotals("VendorReturnForm - cmdEnter_Click --")

                'Reset totals after entry
                CalculateReturnTotals()
                ShowData()
                ExtendedAmount = 0
                ClearLines()
                '***************************************************************************************************
                Try
                    'Set focus to current cell in the datagrid
                    Me.dgvReturnLines.Rows(dgvReturnLines.Rows.Count - 1).Selected = True
                    Me.dgvReturnLines.CurrentCell = Me.dgvReturnLines.Rows(Me.dgvReturnLines.Rows.Count - 1).Cells(1)
                Catch ex As Exception
                    'Skip
                End Try
            End If
        End If
    End Sub

    Private Sub cmdPostReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostReturn.Click
        LoadReturnStatus()

        If canPost() Then
            ConvertReturnDate = dtpReturnDate.Value
            '******************************************************************************************************
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                'Skip Date Validation
            Else
                ''Validate Date
                'Dim CurrentDate, TodaysDate As Date
                'Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

                'TodaysDate = Today()
                'CurrentDate = dtpReturnDate.Value

                'MonthOfYear = CurrentDate.Month
                'YearOfYear = CurrentDate.Year
                'TodaysMonthOfYear = TodaysDate.Month
                'TodaysYearOfYear = TodaysDate.Year

                'If TodaysYearOfYear - YearOfYear > 1 Then
                '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
                '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
                '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
                '    MsgBox("You cannot post a Return to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
                '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
                '    MsgBox("You cannot post a Return to a future period.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'Else
                '    'Date is okay --- Continue
                'End If
            End If
            '******************************************************************************************************
            'Validate Vendor
            Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
            VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
            VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyVendor = "DOES NOT EXIST"
            End Try
            con.Close()

            If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************************************
            'Load Totals
            ReCalculateReturnTotals()

            'Validate if Vendor return is not negative
            If ReturnTotal < 0 Then
                MsgBox("This Vendor Return is negative. Quantities should be entered as a positive.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************************************
            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
                'Verify serial numbers, if applicable
                '***********************************************************************************************************
                'Check for serial Numbers
                Dim CheckPartNumber As String = ""
                Dim CheckSerialNumbers As String = ""
                Dim CheckLineNumber As Integer = 0
                Dim CheckLineQuantity As Double = 0
                Dim CountSerialLines As Integer = 0

                For Each row2 As DataGridViewRow In dgvReturnLines.Rows
                    Try
                        CheckPartNumber = row2.Cells("PartNumberColumn").Value
                    Catch ex As Exception
                        CheckPartNumber = ""
                    End Try
                    Try
                        CheckLineNumber = row2.Cells("ReturnLineNumberColumn").Value
                    Catch ex As Exception
                        CheckLineNumber = 1
                    End Try
                    Try
                        CheckLineQuantity = row2.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        CheckLineQuantity = 0
                    End Try
                    '*************************************************************************
                    Dim SerializedAssemblyStatus As String = ""

                    'Check for Assembly
                    Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                    GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CheckPartNumber
                    GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPurchProdLineID = CStr(GetPPLCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPurchProdLineID = ""
                    End Try
                    con.Close()

                    'Check to see if part is a serialized assembly
                    If GetPurchProdLineID = "ASSEMBLY" Then
                        Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                        CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                        CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetSerialStatus = "NO"
                        End Try
                        con.Close()
                        '*******************************************************************************
                        If GetSerialStatus = "YES" Then
                            Dim CountSerialLinesStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialTempTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber"
                            Dim CountSerialLinesCommand As New SqlCommand(CountSerialLinesStatement, con)
                            CountSerialLinesCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            CountSerialLinesCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            CountSerialLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = CheckLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CountSerialLines = CInt(CountSerialLinesCommand.ExecuteScalar)
                            Catch ex As Exception
                                CountSerialLines = 0
                            End Try
                            con.Close()

                            If CountSerialLines = CheckLineQuantity Then
                                'Do nothing
                            Else
                                MsgBox("The number of serial numbers entered must match the line quantity.", MsgBoxStyle.OkOnly)
                                Exit Sub
                            End If
                        Else
                            'Do nothing
                        End If
                    Else
                        'Do nothing
                    End If

                    CheckPartNumber = ""
                    CheckSerialNumbers = ""
                    CheckLineNumber = 0
                    CheckLineQuantity = 0
                    CountSerialLines = 0
                    GetSerialStatus = ""
                    GetPurchProdLineID = ""
                Next
            End If
            '**************************************************************************************************
            Try
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Get Vendor Class if company is TFF
                    Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                    VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
                    VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        VendorClass = "CANADIAN"
                    End Try
                    con.Close()
                Else
                    'Proceed as normal - vendor class not needed
                End If
                '************************************************************************************************
                'Do not allow change of PO Number if Vendor Return has lines
                Dim GetPOLineCountStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                Dim GetPOLineCountCommand As New SqlCommand(GetPOLineCountStatement, con)
                GetPOLineCountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                GetPOLineCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPOLineCount = CInt(GetPOLineCountCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPOLineCount = 0
                End Try
                con.Close()

                If GetPOLineCount > 0 Then
                    'Verify that only one PO is used per Return
                    Dim GetPONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                    Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                    GetPONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPONumber = 0
                    End Try
                    con.Close()
                End If
                '********************************************************************************************************
                Try
                    updateOrInsertIntoVendorReturn("POSTED")
                Catch ex As Exception
                    sendErrorToDataBase("VendorReturnForm - cmdPostReturn_Click --Error trying to insert or update VendorReturn table as POSTED", "Return #" + cboReturnNumber.Text, ex.ToString())
                    Throw ex
                End Try
                '*********************************************************************************************************
                'Post Lines to relieve inventory
                Dim LineReturnQuantity As Double = 0
                Dim LineExtendedAmount As Double = 0
                Dim LineUnitCost As Double = 0
                Dim LinePartNumber, LinePartDescription As String
                Dim LineNumber As Integer

                For Each row As DataGridViewRow In dgvReturnLines.Rows
                    Try
                        LineUnitCost = row.Cells("CostColumn").Value
                    Catch ex As Exception
                        LineUnitCost = 0
                    End Try
                    Try
                        LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                    Catch ex As Exception
                        LineExtendedAmount = 0
                    End Try
                    Try
                        LinePartNumber = row.Cells("PartNumberColumn").Value
                    Catch ex As Exception
                        LinePartNumber = ""
                    End Try
                    Try
                        LinePartDescription = row.Cells("PartDescriptionColumn").Value
                    Catch ex As Exception
                        LinePartDescription = ""
                    End Try
                    Try
                        LineReturnQuantity = row.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        LineReturnQuantity = 0
                    End Try
                    Try
                        LineNumber = row.Cells("ReturnLineNumberColumn").Value
                    Catch ex As Exception
                        LineNumber = 1
                    End Try
                    '********************************************************************************************************************
                    'Get Item Class for part

                    'Verify that Return Line Item is an Inventory Item to write to the Inventory Transaction Table
                    Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                    ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
                    ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        ItemClass = "TW CA"
                    End Try
                    con.Close()

                    Dim InventoryItem, GetDebitAccount, GetCreditAccount As String

                    'Get GL Accounts from Item List
                    Dim GetDebitAccountStatement As String = "SELECT GLPurchasesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                    GetDebitAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                    Dim GetCreditAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                    GetCreditAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                    Dim InventoryItemStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim InventoryItemCommand As New SqlCommand(InventoryItemStatement, con)
                    InventoryItemCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetDebitAccount = "20999"
                    End Try
                    Try
                        GetCreditAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCreditAccount = "12100"
                    End Try
                    Try
                        InventoryItem = CStr(InventoryItemCommand.ExecuteScalar)
                    Catch ex As Exception
                        InventoryItem = "YES"
                    End Try
                    con.Close()
                    '********************************************************************************************************************
                    'If ItemClass is expense / supply then use the actual cost from the shipment line
                    If InventoryItem = "NO" Then
                        'Do not add Inventory Transaction to Transaction Table or create cost tier
                    Else
                        'Create a Cost Tier
                        'Extract the Upper and Lower Limit of the Inventory Costing Table
                        If LineReturnQuantity > 0 Then
                            LineReturnQuantity = LineReturnQuantity * -1
                        End If
                        '********************************************************************
                        'Extract the Upper and Lower Limit of the Inventory Costing Table
                        Dim NewUpperLimit, LowerLimit, UpperLimit As Double
                        Dim MaxTransactionNumber As Integer = 0
                        Dim MAXDate As String = ""

                        Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MAXDate = CStr(MAXDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            MAXDate = ""
                        End Try
                        con.Close()

                        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                        MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                        MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXDate

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            MaxTransactionNumber = 0
                        End Try
                        con.Close()
                        '**********************************************************************
                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                        Catch ex As Exception
                            UpperLimit = 0
                        End Try
                        con.Close()
                        '***********************************************************************
                        If LineReturnQuantity < 0 Then
                            LowerLimit = UpperLimit
                            NewUpperLimit = LowerLimit + LineReturnQuantity
                        Else
                            'Calculate the NEW Lower/Upper Limit for the next post
                            LowerLimit = UpperLimit + 1
                            NewUpperLimit = LowerLimit + LineReturnQuantity - 1
                        End If
                        '************************************************************************************************
                        'Get next Transaction Number
                        Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                        Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastCostingTransactionNumber = 63600000
                        End Try
                        con.Close()

                        NextCostingTransactionNumber = LastCostingTransactionNumber + 1
                        '************************************************************************************************
                        Try
                            'Write Values to Inventory Costing Table
                            cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                            With cmd.Parameters
                                .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@CostingDate", SqlDbType.VarChar).Value = ConvertReturnDate
                                .Add("@ItemCost", SqlDbType.VarChar).Value = LineUnitCost
                                .Add("@CostQuantity", SqlDbType.VarChar).Value = LineReturnQuantity
                                .Add("@Status", SqlDbType.VarChar).Value = "Vendor Return"
                                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@ReferenceLine", SqlDbType.VarChar).Value = LineNumber
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Vendor Return --- Update costing on POST"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        'Flip the GL Accounts if the extended amount is negative
                        If LineExtendedAmount < 0 Then
                            Dim TempDebitAccount, TempCreditAccount As String
                            TempDebitAccount = GetCreditAccount
                            TempCreditAccount = GetDebitAccount
                            GetCreditAccount = TempCreditAccount
                            GetDebitAccount = TempDebitAccount
                        Else
                            'Do nothing
                        End If
                        '*************************************************
                        'Check to make sure values are not negative
                        If LineReturnQuantity < 0 Then
                            LineReturnQuantity = LineReturnQuantity * -1
                        End If
                        If LineUnitCost < 0 Then
                            LineUnitCost = LineUnitCost * -1
                        End If
                        If LineExtendedAmount < 0 Then
                            LineExtendedAmount = LineExtendedAmount * -1
                        End If
                        '****************************************************************************************************************************************
                        'Write Values to Inventory Transaction Table
                        Dim LastInventoryTransactionNumber, NextInventoryTransactionNumber As Integer

                        'Find Next Transaction Number
                        Dim InventoryTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
                        Dim InventoryTransactionNumberCommand As New SqlCommand(InventoryTransactionNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastInventoryTransactionNumber = CInt(InventoryTransactionNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastInventoryTransactionNumber = 867500000
                        End Try
                        con.Close()

                        NextInventoryTransactionNumber = LastInventoryTransactionNumber + 1
                        '******************************************************************************************************************************************
                        Try
                            'Write Data to the Inventory Transaction Table
                            cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                            With cmd.Parameters
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = ConvertReturnDate
                                .Add("@TransactionType", SqlDbType.VarChar).Value = "VENDOR RETURN"
                                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = LineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                                .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                                .Add("@Quantity", SqlDbType.VarChar).Value = LineReturnQuantity
                                .Add("@ItemCost", SqlDbType.VarChar).Value = LineUnitCost
                                .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                                .Add("@ExtendedCost", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                                .Add("@GLAccount", SqlDbType.VarChar).Value = GetCreditAccount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempReturnNumber As Integer = 0
                            Dim strReturnNumber As String
                            TempReturnNumber = Val(cboReturnNumber.Text)
                            strReturnNumber = CStr(TempReturnNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Vendor Return --- Inventory Transaction creation on POST"
                            ErrorReferenceNumber = "Return # " + strReturnNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End If
                    '**********************************************************************************************************************************
                    'Post to the GL - both Inventory and Non-Inventory Transactions

                    'Convert GL Account to Canadian if Vendor Class is Canadian
                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                        GetCreditAccount = "C$" & GetCreditAccount
                        GetDebitAccount = "C$" & GetDebitAccount
                    Else
                        'Do nothing - proceed as usual
                    End If
                    '**********************************************************************************************************************************************
                    'Get next GL Posting Number
                    Dim MAXGLStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
                    Dim MAXGLCommand As New SqlCommand(MAXGLStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastGLNumber = CInt(MAXGLCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastGLNumber = 255520000
                    End Try
                    con.Close()

                    NextGLNumber = LastGLNumber + 1
                    '**********************************************************************************************************************************************
                    Try
                        'Command to write to GL (Inventory Account)
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetCreditAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Vendor Return"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ConvertReturnDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Vendor " & cboVendorCode.Text & "  -- PO Number " & Val(cboPurchaseOrderNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "PURCHASESJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Vendor Return --- GL Credit Transaction on POST"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**********************************************************************************************************************************************
                    'Get next GL Posting Number
                    Dim MAXGLStatement1 As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
                    Dim MAXGLCommand1 As New SqlCommand(MAXGLStatement1, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastGLNumber = CInt(MAXGLCommand1.ExecuteScalar)
                    Catch ex As Exception
                        LastGLNumber = 255520000
                    End Try
                    con.Close()

                    NextGLNumber = LastGLNumber + 1
                    '**********************************************************************************************************************************************
                    Try
                        'Command to write to GL (Purchase Clearing)
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GetDebitAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Vendor Return"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ConvertReturnDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Vendor " & cboVendorCode.Text & "  -- PO Number " & Val(cboPurchaseOrderNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "PURCHASESJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        '******************************************************************************************************************************************
                        'Log error on update failure
                        Dim TempReturnNumber As Integer = 0
                        Dim strReturnNumber As String
                        TempReturnNumber = Val(cboReturnNumber.Text)
                        strReturnNumber = CStr(TempReturnNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Vendor Return --- GL Debit Transaction on POST"
                        ErrorReferenceNumber = "Return # " + strReturnNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Next

                '************************************************************************************************************************************
                'Show Serial Lines
                ShowSerialLines()
                '=====================================================================
                'Update Serial Log from the temp table if applicable
                If dgvSerialLines.RowCount > 0 Then
                    Dim RowPartNumber As String = ""
                    Dim RowSerialNumber As String = ""
                    Dim RowBuildNumber As Integer = 0
                    Dim RowStatus As String = ""
                    Dim RowCustomerID As String = ""
                    Dim RowBatchNumber As Integer = 0
                    Dim RowTransactionNumber As Integer = 0
                    Dim RowTotalCost As Double = 0

                    For Each row As DataGridViewRow In dgvSerialLines.Rows
                        Try
                            RowPartNumber = row.Cells("AssemblyPartNumber2Column").Value
                        Catch ex As Exception
                            RowPartNumber = ""
                        End Try
                        Try
                            RowSerialNumber = row.Cells("SerialNumber2Column").Value
                        Catch ex As Exception
                            RowSerialNumber = ""
                        End Try
                        Try
                            RowBuildNumber = row.Cells("BuildNumber2Column").Value
                        Catch ex As Exception
                            RowBuildNumber = 0
                        End Try
                        Try
                            RowCustomerID = row.Cells("CustomerID2Column").Value
                        Catch ex As Exception
                            RowCustomerID = ""
                        End Try
                        Try
                            RowBatchNumber = row.Cells("BatchNumber2Column").Value
                        Catch ex As Exception
                            RowBatchNumber = 0
                        End Try
                        Try
                            RowTransactionNumber = row.Cells("TransactionNumber2Column").Value
                        Catch ex As Exception
                            RowTransactionNumber = 0
                        End Try
                        Try
                            RowTotalCost = row.Cells("TotalCost2Column").Value
                        Catch ex As Exception
                            RowTotalCost = 0
                        End Try
                        '****************************************************************************************
                        'Update Serial Log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET DivisionID = @DivisionID, Comment = @Comment, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = "Vendor Return"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Next
                End If
                '********************************************************************
                'Update Vendor Return with Print Date
                cmd = New SqlCommand("UPDATE VendorReturn SET PrintDate = @PrintDate WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '======================================================================
                'If Apply Against is checked - verify Return matches Receiver, and close both
                If chkApplyAgainst.Checked = True Then
                    For Each row As DataGridViewRow In dgvReturnLines.Rows
                        Try
                            LineReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                        Catch ex As Exception
                            LineReceiverNumber = 0
                        End Try
                        Try
                            LineReceiverLineNumber = row.Cells("ReceiverLineNumberColumn").Value
                        Catch ex As Exception
                            LineReceiverLineNumber = 0
                        End Try

                        'Check to see if any lines have been vouched for this receiver
                        If LineReceiverNumber = 0 Or LineReceiverLineNumber = 0 Then
                            CloseReceiver = "NO"
                            MsgBox("No Receiver linked to this return.", MsgBoxStyle.OkOnly)
                            Exit For
                        Else
                            Dim CheckVoucherStatusStatement As String = "SELECT SelectForInvoice FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLinekey = @ReceivingLineKey AND DivisionID = @DivisionID"
                            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                            CheckVoucherStatusCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                            CheckVoucherStatusCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLineNumber
                            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLine = @ReceiverLine"
                            Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                            CountVoucherLinesCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = LineReceiverNumber
                            CountVoucherLinesCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = LineReceiverLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                            Catch ex As Exception
                                CheckVoucherStatus = "OPEN"
                            End Try
                            Try
                                CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                            Catch ex As Exception
                                CountVoucherLines = 0
                            End Try
                            con.Close()

                            If CheckVoucherStatus = "CLOSED" Or CountVoucherLines >= 1 Then
                                CloseReceiver = "NO"
                                MsgBox("This Receiver has a voucher against it - you can't close out receiver. Posting will continue.", MsgBoxStyle.OkOnly)
                                Exit For
                            Else
                                CloseReceiver = "YES"
                            End If
                        End If
                    Next
                    '*****************************************************************************************************************************
                    If CloseReceiver = "YES" Then
                        'Match sure Receiver Totals match the Vendor Return Total
                        Dim MatchReturnTotalStatement As String = "SELECT ReturnTotal FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                        Dim MatchReturnTotalCommand As New SqlCommand(MatchReturnTotalStatement, con)
                        MatchReturnTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        MatchReturnTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim MatchReceiverTotalStatement As String = "SELECT POTotal FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                        Dim MatchReceiverTotalCommand As New SqlCommand(MatchReceiverTotalStatement, con)
                        MatchReceiverTotalCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        MatchReceiverTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MatchReturnTotal = CDbl(MatchReturnTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            MatchReturnTotal = 0
                        End Try
                        Try
                            MatchReceiverTotal = CDbl(MatchReceiverTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            MatchReceiverTotal = 0
                        End Try
                        con.Close()

                        MatchReturnTotal = Round(MatchReturnTotal, 2)
                        MatchReceiverTotal = Round(MatchReceiverTotal, 2)

                        If MatchReceiverTotal = MatchReturnTotal Then
                            'Everything matched - Vendor Return cancels Receiver - close all 4 tables
                            Try
                                updateVendorReturnStatus()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Vendor Return --- Update status on POST"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            Try
                                updateVendorReturnLineStatus()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Vendor Return --- Update Line Status on POST"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            Try
                                'Close Receiver Table
                                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Vendor Return --- Update Receiving Header Status on POST"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            Try
                                'Close Receiver Line Table
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Log error on update failure
                                Dim TempReturnNumber As Integer = 0
                                Dim strReturnNumber As String
                                TempReturnNumber = Val(cboReturnNumber.Text)
                                strReturnNumber = CStr(TempReturnNumber)

                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Vendor Return --- Update receiving line status on POST"
                                ErrorReferenceNumber = "Return # " + strReturnNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try

                            MsgBox("Vendor Return has been posted against Receiver. Both are now closed.", MsgBoxStyle.OkOnly)
                        Else
                            MsgBox("Receiver Total does not match Return Total. Posting will continue.", MsgBoxStyle.OkOnly)
                        End If
                    Else
                        'Do nothing
                    End If
                Else
                    'Skip routine
                End If

                unlockBatch()

                ClearVariables()
                ClearData()

                MsgBox("This Vendor Return has been posted", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("There is an error in the Posting. Verify info and try again.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cmdSelectLinesFromReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLinesFromReceiver.Click
        If canSelectLine() Then
            'Verify that only one PO is used per Return
            Dim GetPONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
            Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
            GetPONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim GetPOLineCountStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
            Dim GetPOLineCountCommand As New SqlCommand(GetPOLineCountStatement, con)
            GetPOLineCountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            GetPOLineCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPONumber = 0
            End Try
            Try
                GetPOLineCount = CInt(GetPOLineCountCommand.ExecuteScalar)
            Catch ex As Exception
                GetPOLineCount = 0
            End Try
            con.Close()

            If GetPONumber > 0 And GetPOLineCount > 0 And GetPONumber <> Val(cboPurchaseOrderNumber.Text) Then
                MsgBox("This Vendor Return already has lines from another PO.", MsgBoxStyle.OkOnly)
                cboPurchaseOrderNumber.Text = GetPONumber
            Else
                'Load Totals
                ReCalculateReturnTotals()

                'Validate Vendor
                Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
                VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                Catch ex As Exception
                    VerifyVendor = "DOES NOT EXIST"
                End Try
                con.Close()

                ConvertReturnDate = dtpReturnDate.Value

                If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                    MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
                Else
                    Try
                        updateOrInsertIntoVendorReturn()
                    Catch ex As Exception
                        sendErrorToDataBase("VendorReturnForm - cmdSelectLinesFromReceiver_Click --Error trying to update or insert Return # " + cboReturnNumber.Text + " to the VendorReturn table", "Return #" + cboReturnNumber.Text, ex.ToString())
                    End Try

                    'Open Select Line from Receiver Form
                    GlobalPONumber = Val(cboPurchaseOrderNumber.Text)
                    GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text

                    Dim NewSelectReceiverLinesForReturn As New SelectReceiverLinesForReturn
                    Me.Hide()
                    NewSelectReceiverLinesForReturn.setDivisionID(cboDivisionID.Text)
                    NewSelectReceiverLinesForReturn.setPONumber(cboPurchaseOrderNumber.Text)
                    NewSelectReceiverLinesForReturn.setReturnNumber(cboReturnNumber.Text)
                    NewSelectReceiverLinesForReturn.LoadReceiverLines()

                    If NewSelectReceiverLinesForReturn.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                        If cboPurchaseOrderNumber.Enabled Then
                            cboPurchaseOrderNumber.Enabled = False
                            cboVendorCode.Enabled = False
                        End If
                    End If
                    LoadReturnData()
                    ShowData()
                    ReCalculateReturnTotals()
                    Me.Show()
                    Me.BringToFront()

                End If
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        'Auto save before printing
        LoadReturnStatus()

        If ReturnStatus = "CLOSED" Or ReturnStatus = "POSTED" Then
            GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
            Using NewPrintVendorReturn As New PrintVendorReturn
                Dim result = NewPrintVendorReturn.ShowDialog()
            End Using
        Else
            'Validate Vendor
            Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
            VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
            VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyVendor = "DOES NOT EXIST"
            End Try
            con.Close()

            ConvertReturnDate = dtpReturnDate.Value

            If VerifyVendor = "" Or VerifyVendor = "DOES NOT EXIST" Then
                MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Else
                If Not isSomeoneEditing() Then
                    'Save data in datagrid
                    Dim Updater As New SqlCommandBuilder(myAdapter)
                    Me.Validate()
                    Me.myAdapter.Update(Me.ds.Tables("VendorReturnLine"))
                    Me.ds.AcceptChanges()

                    'Do not allow change of PO Number if Vendor Return has lines
                    Dim GetPOLineCountStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                    Dim GetPOLineCountCommand As New SqlCommand(GetPOLineCountStatement, con)
                    GetPOLineCountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    GetPOLineCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPOLineCount = CInt(GetPOLineCountCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetPOLineCount = 0
                    End Try
                    con.Close()

                    If GetPOLineCount > 0 Then
                        'Verify that only one PO is used per Return
                        Dim GetPONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                        Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                        GetPONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetPONumber = 0
                        End Try
                        con.Close()
                        Try
                            updateVendorReturn()

                        Catch ex As Exception
                            sendErrorToDataBase("VendorReturnForm - cmdPrint_Click --Error trying to update VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
                            Exit Sub
                        End Try

                    Else
                        Try
                            updateVendorReturn()

                        Catch ex As Exception
                            sendErrorToDataBase("VendorReturnForm - cmdPrint_Click --Error trying to update VendorReturn", "Return #" + cboReturnNumber.Text, ex.ToString())
                            Exit Sub
                        End Try
                    End If

                    updateExtendedAmount("VenforReturnForm - cmdPrint_Click --")

                    'Extract data to UPDATE Totals
                    Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
                    Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                    ProductTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    'UPDATE Totals
                    ReturnTotal = ProductTotal + SalesTaxTotal + FreightTotal
                    updateProductAndReturnTotals("VenforReturnForm - cmdPrint_Click --")
                End If

                GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintVendorReturn As New PrintVendorReturn
                    Dim result = NewPrintVendorReturn.ShowDialog()
                End Using
            End If
        End If
    End Sub

    'Combobox Routines

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastReturn) Then
                unlockBatch(lastReturn)
            End If

            'Load Defaults lists for specific company
            ClearVariables()
            ClearData()
            LoadReturnNumber()
            LoadVendor()
            LoadPONumber()
            LoadItemList()
            ShowData()
        End If
    End Sub

    Private Sub cboPurchaseOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPurchaseOrderNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPOData()
        End If
    End Sub

    Private Sub cboVendorCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorCode.SelectedIndexChanged
        If isLoaded Then
            LoadVendorData()
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadItemData()
        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        If isLoaded Then
            LoadItemClassData()
        End If
    End Sub

    Private Sub cboReturnNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnNumber.SelectedIndexChanged
        If isLoaded Then
            If Not String.IsNullOrEmpty(lastReturn) Then
                unlockBatch(lastReturn)
            End If
            Dim returnNumb As String = cboReturnNumber.Text
            isLoaded = False
            ClearVariables()
            ClearData()
            cboReturnNumber.Text = returnNumb
            isLoaded = True
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            ShowSerialLines()
            checkRows()
            lastReturn = cboReturnNumber.Text
        End If
    End Sub

    'Menu Strip Routines

    Private Sub ManuallyCloseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyCloseReturnToolStripMenuItem.Click
        If cboReturnNumber.Text = "" Or cboVendorCode.Text = "" Then
            MsgBox("You must have a valid Return Number / Vendor selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                LoadReturnData()
                LoadReturnStatus()
                ShowData()
                checkRows()
                Exit Sub
            End If
            LockBatch()
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to close this Vendor Return?", "CLOSE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                If txtReturnStatus.Text = "POSTED" Then
                    Try
                        updateVendorReturnStatus()
                    Catch ex As Exception
                        sendErrorToDataBase("VendorReturnFor - ManuallyCloseReturnToolStripMenuItem_Click --Error trying to update the status to CLOSED in the VendorReturn table", "Return #" + cboReturnNumber.Text, ex.ToString())
                    End Try
                    Try
                        updateVendorReturnLineStatus()
                    Catch ex As Exception
                        sendErrorToDataBase("VendorReturnFor - ManuallyCloseReturnToolStripMenuItem_Click --Error trying to update the line status to CLOSED in VendorReturnLine table", "Return #" + cboReturnNumber.Text, ex.ToString())
                    End Try
                    'Calculate totals and show updates
                    ShowData()
                    LoadReturnData()
                    unlockBatch()
                    MsgBox("Vendor Return has been closed", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("Return cannot be closed.", MsgBoxStyle.OkOnly)
                End If
            ElseIf button = DialogResult.No Then
                'Return will not be saved
                cmdSave.Focus()
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        unlockBatch()
        ClearData()
        ClearVariables()
        ClearSerialLines()
        ShowData()
    End Sub

    Private Sub UnLockReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockReturnToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this Return?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE VendorReturn SET Locked = '' WHERE ReturnNumber = @ReturnNumber", con)
                cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Return is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a Return Number to un-lock", "Enter a Return Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
        End If
    End Sub

    'Textbox Routines

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        SalesTaxTotal = Val(txtSalesTax.Text)
    End Sub

    Private Sub txtFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreight.TextChanged
        FreightTotal = Val(txtFreight.Text)
    End Sub

    Private Sub txtOrderQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderQuantity.TextChanged
        Quantity = Val(txtOrderQuantity.Text)
        ExtendedAmount = Quantity * Cost
        txtExtendedAmount.Text = ExtendedAmount
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        Cost = Val(txtUnitCost.Text)
        ExtendedAmount = Quantity * Cost
        txtExtendedAmount.Text = ExtendedAmount
    End Sub

    'Clear Routines

    Public Sub ClearVariables()
        ItemClassName = ""
        GLSalesAccount = ""
        GLReturnsAccount = ""
        GLInventoryAccount = ""
        GLCOGSAccount = ""
        GLPurchasesAccount = ""
        LongDescription = ""
        ItemClass = ""
        VendorID = ""
        VendorName = ""
        ReturnDate = ""
        ReturnComment = ""
        PartNumber = ""
        PartDescription = ""
        PONumber = 0
        counter = 0
        LastLineNumber = 0
        NextLineNumber = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        NextCostingTransactionNumber = 0
        LastCostingTransactionNumber = 0
        Quantity = 0
        StandardCost = 0
        Cost = 0
        ExtendedAmount = 0
        ProductTotal = 0
        SalesTaxTotal = 0
        FreightTotal = 0
        OtherTotal = 0
        ReturnTotal = 0
        NextGLNumber = 0
        LastGLNumber = 0
        ReturnStatus = ""
        GetPOLineCount = 0
        GetPONumber = 0
        CheckVoucherStatus = ""
        CountVoucherLines = 0
        CloseReceiver = ""
        MatchReturnTotal = 0
        MatchReceiverTotal = 0
        VendorClass = ""
        ConvertReturnDate = Today()
        lastReturn = ""

        cmdDelete.Enabled = True
        cmdEnter.Enabled = True
        cmdSave.Enabled = True
        cmdPostReturn.Enabled = True
        cmdSelectLinesFromReceiver.Enabled = True
        dgvReturnLines.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
        cmdDeleteLine.Enabled = True
    End Sub

    Public Sub ClearData()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboVendorCode.SelectedIndex = -1
        cboDeleteLineNumber.SelectedIndex = -1
        cboDeleteLineNumber.Text = ""
        cboItemClass.SelectedIndex = -1

        txtComment.Clear()
        txtExtendedAmount.Clear()
        txtLongDescription.Clear()
        txtOrderQuantity.Clear()
        txtUnitCost.Clear()
        txtProductTotal.Clear()
        txtReturnTotal.Clear()
        txtSalesTax.Clear()
        txtFreight.Clear()
        txtReturnTotal.Clear()
        txtVendorName.Clear()
        txtReturnStatus.Clear()
        txtGLCOGS.Clear()
        txtGLInventory.Clear()
        txtGLPurchases.Clear()
        txtGLReturns.Clear()
        txtGLSales.Clear()
        txtItemClassDescription.Clear()

        dtpReturnDate.Value = Today()

        cmdDelete.Enabled = True
        cmdEnter.Enabled = True
        cmdSave.Enabled = True
        cmdPostReturn.Enabled = True
        cmdSelectLinesFromReceiver.Enabled = True
        dgvReturnLines.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
        cmdDeleteLine.Enabled = True

        If cboPurchaseOrderNumber.Enabled = False Then
            cboPurchaseOrderNumber.Enabled = True
            cboVendorCode.Enabled = True
        End If

        cboReturnNumber.Focus()
    End Sub

    Public Sub ClearLines()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        txtOrderQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()
        txtGLCOGS.Clear()
        txtGLInventory.Clear()
        txtGLPurchases.Clear()
        txtGLReturns.Clear()
        txtGLSales.Clear()
        txtItemClassDescription.Clear()
        cboPartNumber.Focus()
    End Sub

    'Validation / Error Checking / Misc

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function canSelectLine() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must enter a return number", "Enter a return number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return False
        End If
        If String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            MessageBox.Show("You must enter a PO number", "Enter a PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.Focus()
            Return False
        End If
        If cboPurchaseOrderNumber.SelectedIndex = -1 Then
            MessageBox.Show("Enter a valid PO number", "Enter a PO number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.SelectAll()
            cboPurchaseOrderNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must select a vendor ID", "Select a vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub checkRows()
        If shouldLock() Then
            If cboPurchaseOrderNumber.Enabled = False Then
                cboPurchaseOrderNumber.Enabled = True
                cboVendorCode.Enabled = True
            End If
        Else
            If cboPurchaseOrderNumber.Enabled Then
                cboPurchaseOrderNumber.Enabled = False
                cboVendorCode.Enabled = False
            End If
        End If
    End Sub

    Private Function shouldLock() As Boolean
        If txtReturnStatus.Text <> "OPEN" Then
            Return False
        End If
        If cboPurchaseOrderNumber.Text <> "0" Then
            If dgvReturnLines.Rows.Count <> 0 Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You muste enter a return number", "Enter a return number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must select a vendor ID", "Select a vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.Focus()
            Return False
        End If
        If cboVendorCode.SelectedIndex = -1 Then
            MessageBox.Show("Enter a valid vendor ID", "Enter a valid vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.SelectAll()
            cboVendorCode.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return?", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must enter a return number", "Enter a return number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.SelectAll()
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must select a vendor ID", "Select vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.SelectAll()
            cboVendorCode.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MessageBox.Show("You must select a part to add", "Select a part to add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOrderQuantity.Text) Then
            MessageBox.Show("You must enter an order quanttiy", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOrderQuantity.SelectAll()
            txtOrderQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtOrderQuantity.Text) = False Then
            MessageBox.Show("Quantity must be a number", "enter a valid quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOrderQuantity.SelectAll()
            txtOrderQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtUnitCost.Text) = False Then
            MessageBox.Show("You must have a valid unit cost entered", "Enter a valid unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteLine() As Boolean
        If ReturnStatus = "POSTED" Then
            MessageBox.Show("You cant delete lines off a POSTED return", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must select a return before deleting lines", "Select a return", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return False
        End If
        If dgvReturnLines.Rows.Count = 0 Then
            MessageBox.Show("There are no lines to delete", "Can't delete line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteLineNumber.Text) Then
            MessageBox.Show("There is no line selected to delete", "Select a line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must have a return number entered", "Enter a retrun number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must have a vendor ID selected", "Select a vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.Focus()
            Return False
        End If
        If cboVendorCode.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid vendor ID", "Select a valid vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.SelectAll()
            cboVendorCode.Focus()
            Return False
        End If
        If ReturnStatus = "POSTED" Or ReturnStatus = "CLOSED" Then
            MsgBox("This Return has already been posted.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If dgvReturnLines.Rows.Count = 0 Then
            MessageBox.Show("You must enter lines to return", "Enter lines to return", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to POST this Vendor Return?", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function canExit() As DialogResult
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            Return Windows.Forms.DialogResult.No
        End If
        If txtReturnStatus.Text = "POSTED" Then
            Return Windows.Forms.DialogResult.No
        End If
        If txtReturnStatus.Text = "CLOSED" Then
            Return Windows.Forms.DialogResult.No
        End If
        If isSomeoneEditing() Then
            LoadReturnData()
            LoadReturnStatus()
            ShowData()
            checkRows()
            Return Windows.Forms.DialogResult.No
        End If
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return?", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return button
    End Function

    Private Sub checkVendor()
        'Validate Vendor
        Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
        VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyVendor = "DOES NOT EXIST"
        End Try
        con.Close()
    End Sub

    Public Sub LoadReturnStatus()
        Dim ReturnStatusStatement As String = "SELECT ReturnStatus FROM VendorReturn WHERE DivisionID = @DivisionID AND ReturnNumber = @ReturnNumber"
        Dim ReturnStatusCommand As New SqlCommand(ReturnStatusStatement, con)
        ReturnStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ReturnStatusCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReturnStatus = CStr(ReturnStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ReturnStatus = ""
        End Try
        con.Close()

        txtReturnStatus.Text = ReturnStatus

        If ReturnStatus = "CLOSED" Or ReturnStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdSave.Enabled = False
            cmdDeleteLine.Enabled = False
            cmdPostReturn.Enabled = False
            cmdSelectLinesFromReceiver.Enabled = False
            dgvReturnLines.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdSave.Enabled = True
            cmdPostReturn.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdSelectLinesFromReceiver.Enabled = True
            dgvReturnLines.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE VendorReturn SET Locked = @Locked WHERE ReturnNumber = @ReturnNumber", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = cboReturnNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE VendorReturn SET Locked = '' WHERE ReturnNumber = @ReturnNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        Else
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub chkInventoryItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInventoryItem.CheckedChanged
        If chkInventoryItem.Checked = True Then
            LoadItemList()
            cboPartNumber.SelectedIndex = -1
            cboPartDescription.SelectedIndex = -1
        Else
            LoadNonInventoryItemList()
            cboPartNumber.SelectedIndex = -1
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Private Sub REOpenVendorReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REOpenVendorReturnToolStripMenuItem.Click
        If cboReturnNumber.Text = "" Or Val(cboReturnNumber.Text) = 0 Then
            MsgBox("You must select a valid return number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtReturnStatus.Text = "OPEN" Or txtReturnStatus.Text = "POSTED" Or txtReturnStatus.Text = "" Then
            MsgBox("This return is not closed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Check to see if return should be open, posted, or not opened
        Dim CheckGLPosting As Integer = 0
        Dim CheckROIPosting As Integer = 0

        Dim CheckGLPostingStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLTransactionDescription = @GLTransactionDescription"
        Dim CheckGLPostingCommand As New SqlCommand(CheckGLPostingStatement, con)
        CheckGLPostingCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        CheckGLPostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckGLPostingCommand.Parameters.Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Vendor Return"

        Dim CheckROIPostingStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLineQuery WHERE ReceiverNumber = @ReceiverNumber AND DivisionID = @DivisionID"
        Dim CheckROIPostingCommand As New SqlCommand(CheckROIPostingStatement, con)
        CheckROIPostingCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        CheckROIPostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
  
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckGLPosting = CInt(CheckGLPostingCommand.ExecuteScalar)
        Catch ex As Exception
            CheckGLPosting = 0
        End Try
        Try
            CheckROIPosting = CInt(CheckROIPostingCommand.ExecuteScalar)
        Catch ex As Exception
            CheckROIPosting = 0
        End Try
        con.Close()

        If CheckROIPosting > 0 Then
            MsgBox("This Vendor Return already has a payable created.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If CheckROIPosting = 0 And CheckGLPosting = 0 Then
            'Open Vendor Return to OPEN Status
            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write to audit trail
            Dim AuditComment As String = ""
            Dim AuditReturnNumber As Integer = 0
            Dim strReturnNumber As String = ""

            AuditReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(AuditReturnNumber)
            AuditComment = "Return #" + strReturnNumber + " for vendor " + cboVendorCode.Text + " was re-opened on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "VENDOR RETURN - RE-OPEN"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = ReturnTotal
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReturnNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber2 As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber2 = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Vendor Return Form --- Insert Into Audit Log"
                ErrorReferenceNumber = "Return # " + strReturnNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            txtReturnStatus.Text = "OPEN"

            MsgBox("Return has been changed to OPEN.", MsgBoxStyle.OkOnly)
        ElseIf CheckROIPosting = 0 And CheckGLPosting > 0 Then
            'Open Vendor Return to POSTED Status
            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber", con)
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write to audit trail
            Dim AuditComment As String = ""
            Dim AuditReturnNumber As Integer = 0
            Dim strReturnNumber As String = ""

            AuditReturnNumber = Val(cboReturnNumber.Text)
            strReturnNumber = CStr(AuditReturnNumber)
            AuditComment = "Return #" + strReturnNumber + " for vendor " + cboVendorCode.Text + " was re-opened on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "VENDOR RETURN - RE-OPEN TO POSTED STATUS"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = ReturnTotal
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strReturnNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempReturnNumber As Integer = 0
                Dim strReturnNumber2 As String
                TempReturnNumber = Val(cboReturnNumber.Text)
                strReturnNumber2 = CStr(TempReturnNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Vendor Return Form --- Insert Into Audit Log"
                ErrorReferenceNumber = "Return # " + strReturnNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            txtReturnStatus.Text = "POSTED"
            MsgBox("Return has been changed to POSTED.", MsgBoxStyle.OkOnly)
        Else
            'Do nothing
        End If
    End Sub
End Class