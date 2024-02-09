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
Imports System.Drawing.Printing
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection

Public Class ViewStructuralCertsRemote

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd, cmd2, cmd3 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim tableName As String = "StructuralCertTable"

    Dim BeginDate, EndDate As Date

    Dim LotNumFilter, HeatNumFilter, PartFilter, DescriptionFilter, SalesIDFilter, VendorFilter, PDFStatusFilter, StatusFilter, DateFilter As String
    'Closes the form
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    'Clears the data out of the input places and then it reassigns the division into the combobox
    Public Sub cleardata()
        cboSalesID.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        txtLotNumber.Text = ""
        txtHeatNumber.Text = ""
        dtpDateEntry.Value = Now
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        cboVendor.Text = ""
        cboItemClass.Text = ""
        'dgvMainRack.DataSource = Nothing
        cboSalesID.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboVendor.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txtSearch.Text = ""
        txtLookPartNum.Text = ""
        txtLookPartDesc.Text = ""
        txtLookLotNum.Text = ""
        txtLookHeatNumber.Text = ""
        txtLookSalesID.Text = ""
        txtLookVendorView.Text = ""
        chkDateRange.Checked = False
        chkOpen.Checked = False
        chkPDFScanned.Checked = False
    End Sub


    'When loading the form, will place current division into the combobox and pull in the records associated with that division
    Private Sub ViewMaintenanceRacking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StructuralCertTable' table. You can move, or remove it, as needed.
        'Me.StructuralCertTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StructuralCertTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemList' table. You can move, or remove it, as needed.
        'Me.ItemListTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemList)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StructuralCertTable' table. You can move, or remove it, as needed.
        'Me.StructuralCertTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StructuralCertTable)


        GlobalDivisionCode = EmployeeCompanyCode


        LoadPartNumber()
        LoadPartDescription()
        LoadItemClass()
        LoadSalesID()
        LoadVendorID()
        LoadCustomerName()

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdScan.Visible = False

        Else
            cmdRemoteScan.Visible = False
            cmdScan.Visible = True
        End If

        Try

            cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "StructuralCertTable")
            dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
            con.Close()

            For Each rw As DataGridViewRow In dgvStructCert.Rows
                If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                    rw.DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    rw.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next

        Catch ex As System.Exception
        End Try
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerID.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerID.ValueMember = "CustomerID"
        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub ShowDataByFilter()
        If txtLookLotNum.Text <> "" Or txtSearch.Text <> "" Or txtLookHeatNumber.Text <> "" Or txtLookPartDesc.Text <> "" Or txtLookPartNum.Text <> "" Or txtLookSalesID.Text <> "" Or txtLookVendorView.Text <> "" Or chkDateRange.Checked = True Or chkOpen.Checked = True Or chkPDFScanned.Checked = True Then
            Dim searchFilter As String
            If txtSearch.Text <> "" Then
                searchFilter = "(LotNumber LIKE '%" + txtSearch.Text + "%' OR PartNumber LIKE '%" + txtSearch.Text + "%' " + " OR PartDescription LIKE '%" + txtSearch.Text + "%' OR ItemClass LIKE '%" + txtSearch.Text + "%')"
                If chkDateRange.Checked = True Then
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value

                    DateFilter = " AND Date BETWEEN @BeginDate AND @EndDate"
                Else
                    DateFilter = ""
                End If

                cmd = New SqlCommand("SELECT * FROM StructuralCertTable Where" + searchFilter + DateFilter, con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "StructuralCertTable")
                dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
                con.Close()

            Else
                If txtLookPartNum.Text <> "" Then
                    PartFilter = " PartNumber = '" + txtLookPartNum.Text + "'"
                Else
                    PartFilter = ""
                End If

                If txtLookPartDesc.Text <> "" Then
                    If txtLookPartNum.Text = "" Then
                        DescriptionFilter = " PartDescription = '" + txtLookPartDesc.Text + "'"
                    Else
                        DescriptionFilter = " AND PartDescription = '" + txtLookPartDesc.Text + "'"
                    End If
                Else
                    DescriptionFilter = ""
                End If

                If txtLookLotNum.Text <> "" Then
                    If txtLookPartNum.Text = "" And txtLookPartDesc.Text = "" Then
                        LotNumFilter = " LotNumber = '" + txtLookLotNum.Text + "'"
                    Else
                        LotNumFilter = " AND LotNumber = '" + txtLookLotNum.Text + "'"
                    End If
                Else
                    LotNumFilter = ""
                End If

                If txtLookHeatNumber.Text <> "" Then
                    If txtLookPartNum.Text = "" And txtLookPartDesc.Text = "" And txtLookLotNum.Text = "" Then
                        HeatNumFilter = " HeatNumber = '" + txtLookHeatNumber.Text + "'"
                    Else
                        HeatNumFilter = " AND HeatNumber = '" + txtLookHeatNumber.Text + "'"
                    End If
                Else
                    HeatNumFilter = ""
                End If

                If txtLookSalesID.Text <> "" Then
                    If txtLookPartNum.Text = "" And txtLookPartDesc.Text = "" And txtLookLotNum.Text = "" And txtLookHeatNumber.Text = "" Then
                        SalesIDFilter = " SalesID  = '" + txtLookSalesID.Text + "'"
                    Else
                        SalesIDFilter = " AND SalesID  = '" + txtLookSalesID.Text + "'"
                    End If
                Else
                    SalesIDFilter = ""
                End If

                If txtLookVendorView.Text <> "" Then
                    If txtLookPartNum.Text = "" And txtLookPartDesc.Text = "" And txtLookLotNum.Text = "" And txtLookHeatNumber.Text = "" And txtLookSalesID.Text = "" Then
                        VendorFilter = " Vendor = '" + txtLookVendorView.Text + "'"
                    Else
                        VendorFilter = " AND Vendor = '" + txtLookVendorView.Text + "'"
                    End If
                Else
                    VendorFilter = ""
                End If

                If chkOpen.Checked = True Then
                    If txtLookLotNum.Text = "" And txtSearch.Text = "" And txtLookHeatNumber.Text = "" And txtLookPartDesc.Text = "" And txtLookPartNum.Text = "" And txtLookSalesID.Text = "" And txtLookVendorView.Text = "" Then
                        StatusFilter = " Status = 'OPEN'"
                    Else
                        StatusFilter = " AND Status = 'OPEN'"
                    End If

                Else
                    StatusFilter = ""
                End If

                If chkPDFScanned.Checked = True Then
                    If txtLookLotNum.Text = "" And txtSearch.Text = "" And txtLookHeatNumber.Text = "" And txtLookPartDesc.Text = "" And txtLookPartNum.Text = "" And txtLookSalesID.Text = "" And txtLookVendorView.Text = "" And chkOpen.Checked = False Then
                        PDFStatusFilter = " PDFStatus = 'Not Uploaded'"
                    Else
                        PDFStatusFilter = " AND PDFStatus = 'Not Uploaded'"
                    End If
                Else
                    PDFStatusFilter = ""
                End If

                If chkDateRange.Checked = True Then
                    BeginDate = dtpBeginDate.Value
                    EndDate = dtpEndDate.Value
                    If txtLookLotNum.Text = "" And txtSearch.Text = "" And txtLookHeatNumber.Text = "" And txtLookPartDesc.Text = "" And txtLookPartNum.Text = "" And txtLookSalesID.Text = "" And txtLookVendorView.Text = "" And chkOpen.Checked = False And chkPDFScanned.Checked = False Then
                        DateFilter = " Date BETWEEN @BeginDate AND @EndDate"
                    Else
                        DateFilter = " AND Date BETWEEN @BeginDate AND @EndDate"
                    End If
                Else
                    DateFilter = ""
                End If

                cmd = New SqlCommand("SELECT * FROM StructuralCertTable Where" + PartFilter + LotNumFilter + HeatNumFilter + DescriptionFilter + SalesIDFilter + VendorFilter + StatusFilter + PDFStatusFilter + DateFilter, con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "StructuralCertTable")
                dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
                con.Close()

            End If


            Try
                For Each rw As DataGridViewRow In dgvStructCert.Rows
                    If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                        rw.DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        rw.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                Next
            Catch excep As System.Exception
            End Try
        End If


    End Sub

    'Loads data into the table based on specifics declared in the form
    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub
    'Makes sure all fields are filled in
    Function Validation() As Boolean
        If txtLotNumber.Text = "" Then
            MsgBox("Please Insert A Lot Number")
            txtLotNumber.Focus()
            Return False
        End If
        If cboPartNumber.Text = "" Then
            MsgBox("Please Insert A Part Number")
            cboPartNumber.Focus()
            Return False
        End If
        If cboPartDescription.Text = "" Then
            MsgBox("Please Insert A Part Description")
            cboPartDescription.Focus()
            Return False
        End If
        If cboSalesID.Text = "" Then
            MsgBox("Please Choose A Sales ID")
            cboSalesID.Focus()
            Return False
        End If
        Return True
    End Function
    'Adds or updates the records into the sql database and the table
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cboSalesID.Text = UCase(cboSalesID.Text)
        If Validation() Then
            Dim exists As Boolean = False
            Dim autho As String = ""
            Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("LotNumber")) Then
                        autho = ""
                    Else
                        autho = reader.Item("LotNumber")
                    End If
                End If
                reader.Close()
            End Using

            Dim chosenautho = txtLotNumber.Text
            Dim comString = autho
            Dim length As Integer = comString.Length

            Dim exists2 As Boolean = False
            Dim autho2 As String = ""

            Dim chosenautho2 = cboPartNumber.Text
            Dim comString2 = autho2
            Dim length2 As Integer = comString2.Length

            Dim PDFstat As String = "Not Uploaded"
            Dim pdfstatus As Boolean = False
            Dim structCertExists As String = "\\TFP-FS\TransferData\StructuralCerts\" + txtLookLotNum.Text + ".pdf"
            If File.Exists(structCertExists) Then
                PDFstat = "Uploaded"
                pdfstatus = True
            End If



            Dim status As String
            If pdfstatus = False Or txtLotNumber.Text = "" Or cboPartNumber.Text = "" Or cboPartDescription.Text = "" Or cboItemClass.Text = "" Or cboSalesID.Text = "" Then
                status = "Open"
            Else
                status = "Closed"
            End If

            If chosenautho = comString Then
                'update

                cmd = New SqlCommand("UPDATE StructuralCertTable SET LotNumber = @Lotnumber, HeatNumber = @HeatNumber, PartNumber = @PartNumber, PartDescription = @PartDescription, ItemClass = @ItemClass, SalesID = @SalesID, Vendor = @Vendor, Date = @Date, PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
                    .Add("@SalesID", SqlDbType.VarChar).Value = cboSalesID.Text
                    .Add("@Vendor", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Date", SqlDbType.VarChar).Value = dtpDateEntry.Value
                    .Add("@PDFStatus", SqlDbType.VarChar).Value = PDFstat
                    .Add("@Status", SqlDbType.VarChar).Value = status
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated Lot Number Information")

            Else
                If txtHeatNumber.Text = "" Then
                    txtHeatNumber.Text = " "
                End If
                'insert
                cmd = New SqlCommand("INSERT INTO StructuralCertTable (LotNumber, HeatNumber, PartNumber, PartDescription, ItemClass, SalesID, Vendor, Date, PDFStatus, Status)Values(@LotNumber, @HeatNumber, @PartNumber, @PartDescription, @ItemClass, @SalesID, @Vendor, @Date, @PDFStatus, @Status)", con)

                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
                    .Add("@SalesID", SqlDbType.VarChar).Value = cboSalesID.Text
                    .Add("@Vendor", SqlDbType.VarChar).Value = cboVendor.Text
                    .Add("@Date", SqlDbType.VarChar).Value = dtpDateEntry.Value
                    .Add("@PDFStatus", SqlDbType.VarChar).Value = PDFstat
                    .Add("@Status", SqlDbType.VarChar).Value = status

                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Saved Lot Number Information")
            End If
        End If
        cleardata()

        Try

            cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "StructuralCertTable")
            dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
            con.Close()

            For Each rw As DataGridViewRow In dgvStructCert.Rows
                If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                    rw.DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    rw.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next

        Catch ex As System.Exception
        End Try

    End Sub
    'Removes record from the table where the part number and bin number are the same
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        'Delete Data in the MaintenanceRackingTable
        If txtLotNumber.Text <> "" Then
            If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf")
            Try
                cmd = New SqlCommand("DELETE FROM StructuralCertTable WHERE LotNumber = @LotNumber", con)
                cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Record Deleted")
            Catch ex As System.Exception
                MsgBox("Record Does Not Exists")

            End Try


            Try

                cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "StructuralCertTable")
                dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
                con.Close()

                For Each rw As DataGridViewRow In dgvStructCert.Rows
                    If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                        rw.DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        rw.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                Next

            Catch ex As System.Exception
            End Try
            cleardata()
        Else
            MsgBox("Please Insert A Lot Number")
            txtLotNumber.Focus()
        End If
    End Sub
    'Calls the cleardata function to clear all of the inputed fields
    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cleardata()
        Try

            cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "StructuralCertTable")
            dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
            con.Close()

            For Each rw As DataGridViewRow In dgvStructCert.Rows
                If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                    rw.DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    rw.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next

        Catch ex As System.Exception
        End Try
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.ValueMember = "ItemID"
        cboPartNumber.DisplayMember = "ItemID"
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> 'DE-ACTIVATED' ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "Vendor")
        con.Close()

        cboVendor.DataSource = ds3.Tables("Vendor")
        cboVendor.ValueMember = "VendorCode"
        cboVendor.DisplayMember = "VendorCode"
        cboVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass", con)
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ItemClass")
        con.Close()

        cboItemClass.DataSource = ds6.Tables("ItemClass")
        cboItemClass.ValueMember = "ItemClassID"
        cboItemClass.DisplayMember = "ItemClassID"
        cboItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter8.Fill(ds8, "ItemList")
        con.Close()

        cboPartDescription.DataSource = ds8.Tables("ItemList")
        cboPartDescription.ValueMember = "ShortDescription"
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesID()
        cmd = New SqlCommand("SELECT DISTINCT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter9.Fill(ds9, "ItemList")
        con.Close()

        cboSalesID.DataSource = ds9.Tables("ItemList")
        cboSalesID.ValueMember = "SalesProdLineID"
        cboSalesID.DisplayMember = "SalesProdLineID"
        cboSalesId.SelectedIndex = -1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As System.Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartByDescription2()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As System.Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadItemClassByItemID()
        Dim PartClass As String = ""

        Dim PartClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim PartClassCommand As New SqlCommand(PartClassStatement, con)
        PartClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        PartClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartClass = CStr(PartClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            PartClass = ""
        End Try
        con.Close()

        cboItemClass.Text = PartClass
    End Sub

    Public Sub LoadSalesProdLineByItemID()
        Dim PartClass As String = ""

        Dim PartClassStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim PartClassCommand As New SqlCommand(PartClassStatement, con)
        PartClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        PartClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartClass = CStr(PartClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            PartClass = ""
        End Try
        con.Close()

        cboSalesID.Text = PartClass
    End Sub

    Public Sub LoadSalesProdLineIDByDescription2()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT SalesProdLineID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As System.Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboSalesID.Text = PartNumber1
    End Sub

    Public Sub LoadItemClassByDescription()
        Dim PartClass As String = ""

        Dim PartClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ShortDescription = @ShortDescription"
        Dim PartClassCommand As New SqlCommand(PartClassStatement, con)
        PartClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        PartClassCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartClass = CStr(PartClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            PartClass = ""
        End Try
        con.Close()

        cboItemClass.Text = PartClass
    End Sub
    'Loads the row clicked on's data into the fields for modification and deletion
    Private Sub dgvStructCert_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStructCert.CellClick
        If dgvStructCert.RowCount > 0 Then
            cleardata()
            Try
                Dim RowIndex As Integer = Me.dgvStructCert.CurrentCell.RowIndex
                Dim lotNum, heatNum, part, desc, vendor, dateC, itemClass, salesId, status, pdfStatus As String
                part = Me.dgvStructCert.Rows(RowIndex).Cells("PartNumberDataGridViewTextBoxColumn").Value.ToString()
                desc = Me.dgvStructCert.Rows(RowIndex).Cells("PartDescriptionDataGridViewTextBoxColumn").Value.ToString()
                lotNum = Me.dgvStructCert.Rows(RowIndex).Cells("LotNumberDataGridViewTextBoxColumn").Value.ToString()
                heatNum = Me.dgvStructCert.Rows(RowIndex).Cells("HeatNumberDataGridViewTextBoxColumn").Value.ToString()
                dateC = Me.dgvStructCert.Rows(RowIndex).Cells("DateDataGridViewTextBoxColumn").Value.ToString()
                itemClass = Me.dgvStructCert.Rows(RowIndex).Cells("ItemClassDataGridViewTextBoxColumn").Value.ToString()
                vendor = Me.dgvStructCert.Rows(RowIndex).Cells("VendorDataGridViewTextBoxColumn").Value.ToString()
                salesId = Me.dgvStructCert.Rows(RowIndex).Cells("SalesIDDataGridViewTextBoxColumn").Value.ToString()
                pdfStatus = Me.dgvStructCert.Rows(RowIndex).Cells("PDFStatusDataGridViewTextBoxColumn").Value.ToString()
                status = Me.dgvStructCert.Rows(RowIndex).Cells("StatusDataGridViewTextBoxColumn").Value.ToString()
                cboPartNumber.Text = part
                cboPartDescription.Text = desc
                dtpDateEntry.Value = Convert.ToDateTime(dateC)
                txtLotNumber.Text = lotNum
                txtLookLotNum.Text = lotNum
                txtHeatNumber.Text = heatNum
                cboVendor.Text = vendor
                cboSalesID.Text = salesId
                cboItemClass.Text = itemClass

            Catch ex As Exception

            End Try
        End If
    End Sub


    'Opens up the report that
    Private Sub cmdViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPDF.Click

        Dim structCertExists As String = "\\TFP-FS\TransferData\StructuralCerts\" + txtLookLotNum.Text + ".pdf"
        If File.Exists(structCertExists) Then
            System.Diagnostics.Process.Start(structCertExists)
        Else
            MsgBox("PDF Does Not Exist")
        End If
    End Sub

    Private Sub cmdViewAll_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        Try

            cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "StructuralCertTable")
            dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
            con.Close()
            For Each rw As DataGridViewRow In dgvStructCert.Rows
                If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                    rw.DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    rw.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next

        Catch ex As System.Exception
        End Try

    End Sub

    Private Sub dgvStructCert_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStructCert.CellDoubleClick
        Try
            Dim pdfname As String = " "

            If Me.dgvStructCert.RowCount <> 0 Then
                Dim RowIndex As Integer = Me.dgvStructCert.CurrentCell.RowIndex
                pdfname = Me.dgvStructCert.Rows(RowIndex).Cells("LotNumberDataGridViewTextBoxColumn").Value
                Dim structCertExists As String = "\\TFP-FS\TransferData\StructuralCerts\" + pdfname + ".pdf"
                If File.Exists(structCertExists) Then
                    System.Diagnostics.Process.Start(structCertExists)
                Else
                    MsgBox("PDF Does Not Exist")
                End If
            End If
        Catch except As System.Exception
            MsgBox("PDF Does Not Exist")
        End Try

    End Sub

    Private Sub dgvStructCert_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStructCert.CellValueChanged
        Dim weight As Decimal = 0

        If Me.dgvStructCert.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvStructCert.CurrentCell.RowIndex
            Dim lotNum, heatNum, part, desc, vendor, dateC, itemClass, salesId, status, PdfStatus As String

            Dim pdffile As String = Me.dgvStructCert.Rows(RowIndex).Cells("LotNumberDataGridViewTextBoxColumn").Value
            If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then
                PdfStatus = "Uploaded"
            Else
                PdfStatus = "Not Uploaded"
            End If
            Try
                lotNum = Me.dgvStructCert.Rows(RowIndex).Cells("LotNumberDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                lotNum = ""
            End Try

            Try
                heatNum = Me.dgvStructCert.Rows(RowIndex).Cells("HeatNumberDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                heatNum = ""
            End Try

            Try
                part = Me.dgvStructCert.Rows(RowIndex).Cells("PartNumberDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                part = ""
            End Try

            Try
                desc = Me.dgvStructCert.Rows(RowIndex).Cells("PartDescriptionDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                desc = ""
            End Try

            Try
                vendor = Me.dgvStructCert.Rows(RowIndex).Cells("VendorDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                vendor = ""
            End Try

            Try
                salesId = Me.dgvStructCert.Rows(RowIndex).Cells("SalesIDDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                salesId = ""
            End Try

            Try
                status = Me.dgvStructCert.Rows(RowIndex).Cells("StatusDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                status = ""
            End Try

            Try
                itemClass = Me.dgvStructCert.Rows(RowIndex).Cells("ItemClassDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                itemClass = ""
            End Try

            Try
                dateC = Me.dgvStructCert.Rows(RowIndex).Cells("DateDataGridViewTextBoxColumn").Value
            Catch ex As Exception
                dateC = ""
            End Try
            If lotNum = "" Or heatNum = "" Or part = "" Or desc = "" Or itemClass = "" Or salesId = "" Or vendor = "" Or dateC = "" Then
                status = "Open"
            Else
                status = "Closed"
            End If
            Try
                cmd = New SqlCommand("UPDATE StructuralCertTable SET LotNumber = @Lotnumber, HeatNumber = @HeatNumber, PartNumber = @PartNumber, PartDescription = @PartDescription, ItemClass = @ItemClass, SalesID = @SalesID, Vendor = @Vendor, Date = @Date, PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = lotNum
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = heatNum
                    .Add("@PartNumber", SqlDbType.VarChar).Value = part
                    .Add("@PartDescription", SqlDbType.VarChar).Value = desc
                    .Add("@ItemClass", SqlDbType.VarChar).Value = itemClass
                    .Add("@SalesID", SqlDbType.VarChar).Value = salesId
                    .Add("@Vendor", SqlDbType.VarChar).Value = vendor
                    .Add("@Date", SqlDbType.VarChar).Value = dateC
                    .Add("@PDFStatus", SqlDbType.VarChar).Value = PdfStatus
                    .Add("@Status", SqlDbType.VarChar).Value = status
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated Lot Number Information")


            Catch ex As System.Exception

            End Try


        End If

        cleardata()

        cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "StructuralCertTable")
        dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
        con.Close()

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadItemClassByItemID()
        LoadDescriptionByPart()
        LoadSalesProdLineByItemID()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription2()
        LoadItemClassByDescription()
        LoadSalesProdLineIDByDescription2()
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub


    Public Function canSave() As Boolean
        If String.IsNullOrEmpty(txtLotNumber.Text) Then
            MessageBox.Show("You must enter a Lot Number", "Enter a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLotNumber.Focus()
            Return False
        ElseIf txtLotNumber.Text = "" Then
            MessageBox.Show("You must enter a Lot Number", "Enter a Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLotNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub ScanStrucCert(Optional ByVal newPDF As Boolean = True)

        If canSave() Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

            If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0

            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For l As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(l).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(l)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If
            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Imgs As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Imgs.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True


                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While

                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                End If
            End If
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1


            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For h As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(h), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount
        End If

        Dim boolCheck As Boolean = True
        Dim FilesInFolder As Integer
        Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
        FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count

        'Variables Declared
        Dim comboboxSelection As String = txtLotNumber.Text

        Dim strDir As String = "\\TFP-FS\TransferData\StructuralCerts\"

        'Dim pdfDoc As New document()

        'Name of file
        Dim strFilename As String = txtLotNumber.Text + ".pdf"
        Dim pdfDoc As New document()
        Dim i As Integer = 1
        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
        'path to bmp
        Dim strCompletePath As String = strDir & strFilename
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
        pdfDoc.Open()
        'Grabs the bmp image seen on screen
        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
        'structures it to fit on pdf file
        img.ScalePercent(72.0F / img.DpiX * 100)
        img.SetAbsolutePosition(0, 0)
        'adds image to the document
        pdfDoc.Add(img)

        i += 1
        While i <= FilesInFolder
            pdfDoc.NewPage()
            strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            strCompletePath = strDir & strFilename
            'Grabs the bmp image seen on screen
            img = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)
            i += 1
        End While
        pdfDoc.Close()
        Dim status As String
        If txtLotNumber.Text = "" Or txtHeatNumber.Text = "" Or cboPartNumber.Text = "" Or cboPartDescription.Text = "" Or cboItemClass.Text = "" Or cboItemClass.Text = "" Then
            status = "Open"
        Else
            status = "Closed"
        End If
        If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then
            cmd = New SqlCommand("UPDATE StructuralCertTable SET PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
            With cmd.Parameters
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                .Add("@PDFStatus", SqlDbType.VarChar).Value = "Uploaded"
                .Add("@Status", SqlDbType.VarChar).Value = status
            End With
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Updated Lot Number Information")
            cleardata()
        End If

    End Sub

    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        Dim exists As Boolean = False
        Dim autho As Integer = 0
        Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("LotNumber")) Then
                    autho = 0
                Else
                    autho = reader.Item("LotNumber")
                End If
            End If
            reader.Close()
        End Using

        Dim chosenautho = txtLotNumber.Text
        Dim comString = autho.ToString
        If chosenautho = comString Then
            ScanStrucCert()
            Try

                cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "StructuralCertTable")
                dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
                con.Close()

                For Each rw As DataGridViewRow In dgvStructCert.Rows
                    If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                        rw.DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        rw.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                Next

            Catch ex As System.Exception
            End Try
        Else
            MsgBox("Lot Number Does Not Exist")
        End If
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim exists As Boolean = False
        Dim autho As Integer = 0
        Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("LotNumber")) Then
                    autho = 0
                Else
                    autho = reader.Item("LotNumber")
                End If
            End If
            reader.Close()
        End Using

        Dim chosenautho = txtLotNumber.Text
        Dim comString = autho.ToString
        If chosenautho = comString Then

            Dim ReceiptFilename As String = ""
            Dim ReceiptFilenameAndPath As String = ""
            Dim strReceiptNumber As String = ""

            'Verify that they have a Receipt selected
            If txtLotNumber.Text = "" Then
                MsgBox("You must select a valid lot number.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                strReceiptNumber = txtLotNumber.Text
            End If

            Dim UploadedReceiptNumber As String = txtLotNumber.Text

            ReceiptFilename = strReceiptNumber + ".pdf"
            ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

            If File.Exists(ReceiptFilenameAndPath) Then
                Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Cert?", "OVERWRITE EXISTING CERT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Delete existing Receipt before upload
                    File.Delete(ReceiptFilenameAndPath)

                    Dim My_Process As New Process()
                    'Dim My_Process_Info As New ProcessStartInfo

                    Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                    strReceiptNumber = CStr(txtLotNumber.Text)

                    ReceiptFilename = strReceiptNumber + ".pdf"
                    ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

                    'My_Process_Info.UseShellExecute = False
                    'My_Process_Info.RedirectStandardOutput = True
                    'My_Process_Info.RedirectStandardError = True
                    'My_Process_Info.CreateNoWindow = True

                    Try
                        My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                        'My_Process.WaitForExit()
                        My_Process.Close()
                    Catch ex As Exception
                        MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                    End Try
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            Else
                Dim My_Process As New Process()
                'Dim My_Process_Info As New ProcessStartInfo

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strReceiptNumber = CStr(txtLotNumber.Text)

                ReceiptFilename = strReceiptNumber + ".pdf"
                ReceiptFilenameAndPath = "\\TFP-FS\TransferData\StructuralCerts\" + ReceiptFilename

                'My_Process_Info.UseShellExecute = False
                'My_Process_Info.RedirectStandardOutput = True
                'My_Process_Info.RedirectStandardError = True
                'My_Process_Info.CreateNoWindow = True

                Try
                    My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                    'My_Process.WaitForExit()
                    My_Process.Close()
                Catch ex As Exception

                End Try

            End If
            Dim status As String
            If txtLotNumber.Text = "" Or txtHeatNumber.Text = "" Or cboPartNumber.Text = "" Or cboPartDescription.Text = "" Or cboItemClass.Text = "" Or cboItemClass.Text = "" Then
                status = "Open"
            Else
                status = "Closed"
            End If
            If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then
                cmd = New SqlCommand("UPDATE StructuralCertTable SET PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                    .Add("@PDFStatus", SqlDbType.VarChar).Value = "Uploaded"
                    .Add("@Status", SqlDbType.VarChar).Value = status
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated Lot Number Information")
                cleardata()
            End If
        Else
            MsgBox("Lot Number Does Not Exist")
        End If
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        Dim exists As Boolean = False
        Dim autho As String = ""
        Dim ItemDataStatement As String = "SELECT LotNumber FROM StructuralCertTable WHERE LotNumber = @LotNumber"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        ItemDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("LotNumber")) Then
                    autho = ""
                Else
                    autho = reader.Item("LotNumber")
                End If
            End If
            reader.Close()
        End Using

        Dim chosenautho = txtLotNumber.Text
        Dim comString = autho
        If chosenautho = comString Then
            If canSave() Then
                Try
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf")
                Catch ex As System.Exception
                End Try
                Try
                    Dim MoveLocation As String = "\\TFP-FS\TransferData\StructuralCerts\"
                    Dim destinationPath As String = ""

                    Dim fd As OpenFileDialog = New OpenFileDialog()
                    Dim strFileName As String = ""

                    fd.Title = "Open File Dialog"
                    fd.InitialDirectory = "C:\"
                    fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                    fd.FilterIndex = 2
                    fd.RestoreDirectory = True

                    If fd.ShowDialog() = DialogResult.OK Then
                        strFileName = fd.FileName
                    End If

                    If File.Exists(strFileName) Then
                        Dim filename As String = System.IO.Path.GetFileName(strFileName)
                        destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                        If File.Exists(destinationPath) Then
                            File.Delete(destinationPath)
                        End If
                        File.Move(strFileName, destinationPath)
                        Dim rename As String = txtLotNumber.Text + ".pdf"
                        My.Computer.FileSystem.RenameFile(destinationPath, rename)
                        MsgBox("File Moved")

                    Else
                        MsgBox("File Not Moved")
                    End If
                    Dim status As String
                    If txtLotNumber.Text = "" Or txtHeatNumber.Text = "" Or cboPartNumber.Text = "" Or cboPartDescription.Text = "" Or cboItemClass.Text = "" Or cboItemClass.Text = "" Then
                        status = "Open"
                    Else
                        status = "Closed"
                    End If
                    If File.Exists("\\TFP-FS\TransferData\StructuralCerts\" + txtLotNumber.Text + ".pdf") Then
                        cmd = New SqlCommand("UPDATE StructuralCertTable SET PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                            .Add("@PDFStatus", SqlDbType.VarChar).Value = "Uploaded"
                            .Add("@Status", SqlDbType.VarChar).Value = status
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        'MsgBox("Updated Lot Number Information")

                        cmd = New SqlCommand("SELECT * FROM StructuralCertTable", con)
                        If con.State = ConnectionState.Closed Then con.Open()
                        ds = New DataSet()
                        myAdapter.SelectCommand = cmd
                        myAdapter.Fill(ds, "StructuralCertTable")
                        dgvStructCert.DataSource = ds.Tables("StructuralCertTable")
                        con.Close()

                        For Each rw As DataGridViewRow In dgvStructCert.Rows
                            If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                                rw.DefaultCellStyle.BackColor = Color.LightCoral
                            Else
                                rw.DefaultCellStyle.BackColor = Color.LightGreen
                            End If
                        Next
                    Else
                        cmd = New SqlCommand("UPDATE StructuralCertTable SET PDFStatus = @PDFStatus, Status = @Status WHERE LotNumber = @LotNumber", con)
                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                            .Add("@PDFStatus", SqlDbType.VarChar).Value = "Not Uploaded"
                            .Add("@Status", SqlDbType.VarChar).Value = status
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                    End If
                    cleardata()
                Catch ex As System.Exception
                End Try
            
            End If
        Else
            MsgBox("Lot Number Does Not Exist")
        End If
    End Sub

    Private Sub dgvStructCert_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvStructCert.Sorted
        For Each rw As DataGridViewRow In dgvStructCert.Rows
            If rw.Cells("StatusDataGridViewTextBoxColumn").Value.ToString = "Open" Then
                rw.DefaultCellStyle.BackColor = Color.LightCoral
            Else
                rw.DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Private Sub AddUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUpdateToolStripMenuItem.Click
        MsgBox("This option will update an existing lot numbers information based on the lot number. If the lot number does not exist yet, it will create a new one")
        txtLotNumber.Focus()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        MsgBox("This option will clear both the search group and the insert/update group of textboxes/options for a fresh restart")
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        MsgBox("This option will remove the scanned pdf, if one exists, and remove the lot number from the database")
    End Sub

    Private Sub ScanCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanCertToolStripMenuItem.Click
        MsgBox("This option will scan the Structural Cert into the correct folder")
    End Sub

    Private Sub UploadCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadCertToolStripMenuItem.Click
        MsgBox("Upload the Structural Cert from a pdf saves on your local machine")
    End Sub

    Private Sub ViewVsViewAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewVsViewAllToolStripMenuItem.Click
        MsgBox("View will search through the database based on parameters supplied by you to look for specific entries while view all will pull in everything")
    End Sub

    Private Sub KeywordSearchingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeywordSearchingToolStripMenuItem.Click
        MsgBox("This will look for lot numbers, part numbers, part descriptions, and item classes containing the words entered in textbox")
        txtSearch.Focus()
    End Sub

    Private Sub txtLotNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNumber.TextChanged
        If txtLotNumber.Text = "" Then
            cleardata()
        Else

            Try

                Dim PartClass As String = ""

                Dim PartClassStatement As String = "SELECT PartNumber FROM RackingTransactionQuery WHERE DivisionID = @DivisionID AND LotNumber = @LotNumber"
                Dim PartClassCommand As New SqlCommand(PartClassStatement, con)
                PartClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                PartClassCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartClass = CStr(PartClassCommand.ExecuteScalar)
                    If PartClass <> "" Then
                        cboPartNumber.Text = PartClass
                    End If

                Catch ex As System.Exception

                End Try
                con.Close()

                Dim HeatNum As String = ""

                Dim HeatNumStatement As String = "SELECT HeatNumber FROM RackingTransactionQuery WHERE DivisionID = @DivisionID AND LotNumber = @LotNumber"
                Dim HeatNumCommand As New SqlCommand(HeatNumStatement, con)
                HeatNumCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                HeatNumCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    HeatNum = CStr(HeatNumCommand.ExecuteScalar)
                    If HeatNum <> "" Then
                        txtHeatNumber.Text = HeatNum
                    End If

                Catch ex As System.Exception

                End Try
                con.Close()

                Dim Partdescripton As String = ""

                Dim PartdescriptonStatement As String = "SELECT PartDescription FROM RackingTransactionQuery WHERE DivisionID = @DivisionID AND LotNumber = @LotNumber"
                Dim PartdescriptonCommand As New SqlCommand(PartdescriptonStatement, con)
                PartdescriptonCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                PartdescriptonCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    Partdescripton = CStr(PartdescriptonCommand.ExecuteScalar)
                    If Partdescripton <> "" Then
                        cboPartDescription.Text = Partdescripton
                    End If
                Catch ex As System.Exception

                End Try
                con.Close()



                Dim PartClass2 As String = ""

                Dim PartClassStatement2 As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                Dim PartClassCommand2 As New SqlCommand(PartClassStatement2, con)
                PartClassCommand2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                PartClassCommand2.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartClass2 = CStr(PartClassCommand2.ExecuteScalar)
                    If PartClass2 <> "" Then
                        cboItemClass.Text = PartClass2
                        cboVendor.Text = ""
                    End If

                Catch ex As System.Exception

                End Try
                con.Close()



            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EmailPDFOfStructCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPDFOfStructCertToolStripMenuItem.Click
        Dim structCertExists As String = "\\TFP-FS\TransferData\StructuralCerts\" + txtLookLotNum.Text + ".pdf"
        If File.Exists(structCertExists) Then

            Dim CertEmail As String = ""

            Dim CertStatement As String = "SELECT InvoiceCertEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CertCommand As New SqlCommand(CertStatement, con)
            CertCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CertCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CertEmail = CStr(CertCommand.ExecuteScalar)
            Catch ex As System.Exception
                CertEmail = ""
            End Try
            con.Close()


            TFPMailFilename = txtLotNumber.Text + ".pdf"
            TFPMailFilePath = "\\TFP-FS\TransferData\StructuralCerts\" & txtLotNumber.Text & ".pdf"
            TFPMailTransactionType = "Email Structural Certification"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = CertEmail

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using

            Me.Dispose()
            Me.Close()
        Else
            MsgBox("PDF Does Not Exist, Cannot Email")
        End If
    End Sub

    Private Sub EmailCoCOfCurrentLotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCoCOfCurrentLotToolStripMenuItem.Click
        If con.State = ConnectionState.Closed Then con.Open()

        Dim PartClass As String = ""

        Dim PartClassStatement As String = "SELECT PartNumber FROM RackingTransactionQuery WHERE DivisionID = @DivisionID AND LotNumber = @LotNumber"
        Dim PartClassCommand As New SqlCommand(PartClassStatement, con)
        PartClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        PartClassCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartClass = CStr(PartClassCommand.ExecuteScalar)


        Catch ex As System.Exception
            PartClass = ""
        End Try
        If PartClass <> "" Then
            Dim datefilter2, BeginDate2, EndDate2, CustomerFilter As String
            If chkDateRange.Checked = True Then
                BeginDate2 = dtpBeginDate.Text
                EndDate2 = dtpEndDate.Text
                datefilter2 = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
            Else
                datefilter2 = ""
            End If
            If cboCustomerID.Text <> "" Then
                CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
            Else
                CustomerFilter = ""
            End If

            con.Close()
            cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery2 WHERE DivisionID = @DivisionID" + CustomerFilter + datefilter2 + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds2, "ShipmentLineQuery2")

            con.Close()

            cmd = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            GlobalDivisionCode = EmployeeCompanyCode

            cmd3 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID AND (ItemClass = 'ANCHOR BOLTS' OR ItemClass = 'MACHINING' OR ItemClass = 'CARR BOLTS' OR ItemClass = 'CLEVIS' OR ItemClass = 'CPG NUTS' OR ItemClass = 'DES' OR ItemClass = 'EPOXY' OR ItemClass = 'EXP ANCHOR' OR ItemClass = 'EYE BOLTS' OR ItemClass = 'HEX BOLTS' OR ItemClass = 'HEX NUTS' OR ItemClass = 'JAM NUTS' OR ItemClass = 'LAG BOLTS' OR ItemClass = 'LOCK NUTS' OR ItemClass = 'METRIC' OR ItemClass = 'SES' OR ItemClass = 'THREADED ROD' OR ItemClass = 'TURNBUCKLES' OR ItemClass = 'U BOLTS' OR ItemClass = 'WASHERS') AND ItemID = @ItemID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            cmd3.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartClass

            GDS1 = New DataSet()

            GDS1 = ds2

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(GDS1, "CustomerList")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(GDS1, "ItemList")

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Dim NewPrintCustCertOfCompliance As New PrintCertOfComplianceRemote
                NewPrintCustCertOfCompliance.Show()
            Else
                Dim NewPrintCustCertOfCompliance As New PrintCertOfCompliance
                NewPrintCustCertOfCompliance.Show()
            End If
        Else
            MsgBox("Please select a valid lot number (Must be in database) and customer")
        End If
    End Sub

    Private Sub cboPartNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPartNumber.TextChanged
        If cboPartNumber.Text = "" Then
            cboPartDescription.SelectedIndex = -1
            cboItemClass.SelectedIndex = -1
            cboSalesID.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboPartDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPartDescription.TextChanged
        If cboPartDescription.Text = "" Then
            cboPartNumber.SelectedIndex = -1
            cboItemClass.SelectedIndex = -1
            cboSalesID.SelectedIndex = -1
        End If
    End Sub
End Class