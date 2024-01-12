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
Public Class ViewSteelPurchaseLines
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim dt, SteelDT As Data.DataTable
    Dim isloaded As Boolean = False

    Private Sub ViewSteelPurchaseLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        usefulFunctions.LoadSecurity(Me)
        LoadSteelPONumber()
        LoadSteel()
        LoadVendor()

        isloaded = True
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelPurchaseLines.DataSource = Nothing
    End Sub

    Private Sub LoadSteel()
        Dim cmd As New SqlCommand("SELECT RMID, Carbon, SteelSize FROM RawMaterialsTable;", con)
        SteelDT = New Data.DataTable("RawMaterialsTable")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(SteelDT)
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1

        cboSteelSize.DisplayMember = "SteelSize"
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        Dim cmd As New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = 'TWD' AND VendorClass = 'SteelVendor';", con)
        Dim dt As New Data.DataTable("Vendor")
        Dim myAdapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()

        cboSteelVendor.DisplayMember = "VendorCode"
        cboSteelVendor.DataSource = dt
        cboSteelVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelPONumber()
        Dim cmd As New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID;", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        Dim dt As New Data.DataTable("SteelPurchaseOrderHeader")
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()
        cboPONumber.DisplayMember = "SteelPurchaseOrderKey"
        cboPONumber.DataSource = dt
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        isloaded = False
        cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
        cboCarbon.SelectedIndex = -1
        cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
        cboSteelSize.SelectedIndex = -1
        cboSteelVendor.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cboSteelVendor.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            cboPONumber.Text = ""
        End If

        txtVendorName.Clear()

        chkDateRange.Checked = False

        dtpBegin.Value = Now
        dtpEnd.Value = Now

        lblTotalWeight.Text = ""
        lblTotalCost.Text = ""
        isloaded = True
    End Sub

    Public Sub LoadVendorName()
        Dim VendorName As String

        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID;"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboSteelVendor.Text
        If EmployeeCompanyCode.Equals("TST") Then
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = VendorNameCommand.ExecuteScalar
        Catch ex As System.SystemException
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Private Sub cboSteelVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelVendor.SelectedIndexChanged
        If isloaded Then
            LoadVendorName()
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim cmd As New SqlCommand("SELECT * FROM SteelPurchaseQuantityStatus WHERE DivisionID = @DivisionID", con)
        Dim cmd2 As New SqlCommand("SELECT SUM(PurchaseQuantity) as TotalQuantity, ROUND(SUM(ExtendedAmount), 2) as TotalAmount FROM SteelPurchaseQuantityStatus WHERE DivisionID = @DivisionID", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        ''checks to see if carbon was selected and will add command
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            If chkAllTypes.Checked Then
                cmd.CommandText += " AND Carbon like @Carbon"
                cmd2.CommandText += " AND Carbon like @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
                cmd2.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text + "%"
            Else
                cmd.CommandText += " AND Carbon = @Carbon"
                cmd2.CommandText += " AND Carbon = @Carbon"
                cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                cmd2.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            End If
        End If
        ''checks to see if steel size is selected and will add command
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cmd.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            cmd2.CommandText += " AND (SteelSize = @SteelSize OR SteelSize = @SteelSize2)"
            If cboSteelSize.Text.Contains("/") Then
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd2.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
                cmd2.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
            Else
                cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
                cmd2.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                cmd2.Parameters.Add("@SteelSize2", SqlDbType.VarChar).Value = GetFractional(cboSteelSize.Text)
            End If
        End If
        If chkDateRange.Checked Then
            cmd.CommandText += " AND SteelPurchaseOrderDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text
            cmd2.CommandText += " AND SteelPurchaseOrderDate BETWEEN @BeginDate AND @EndDate"
            cmd2.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBegin.Text
            cmd2.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEnd.Text
        End If
        ''checks to see if a vendor was selected and adds the command
        If Not String.IsNullOrEmpty(cboSteelVendor.Text) Then
            cmd.CommandText += " AND SteelVendorID = @SteelVendorID"
            cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = cboSteelVendor.Text
            cmd2.CommandText += " AND SteelVendorID = @SteelVendorID"
            cmd2.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = cboSteelVendor.Text
        End If
        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            cmd.CommandText += " AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
            cmd.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.Int).Value = Val(cboPONumber.Text)
            cmd2.CommandText += " AND SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
            cmd2.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.Int).Value = Val(cboPONumber.Text)
        End If

        cmd.CommandText += ";"
        cmd2.CommandText += ";"
        Dim TotalQuantity As Double = 0D
        Dim TotalAmount As Double = 0D

        dt = New Data.DataTable("SteelPurchaseQuantityStatus")
        Dim myAdapter As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        Dim reader As SqlDataReader = cmd2.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("TotalQuantity")) Then
                TotalQuantity = reader.Item("TotalQuantity")
            End If
            If Not IsDBNull(reader.Item("TotalAmount")) Then
                TotalAmount = reader.Item("TotalAmount")
            End If
        End If
        reader.Close()
        con.Close()
        dgvSteelPurchaseLines.DataSource = dt

        lblTotalWeight.Text = FormatNumber(TotalQuantity, 0)
        lblTotalCost.Text = FormatCurrency(TotalAmount, 2)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        Dim NewPrintSteelPurchaseLines As New PrintSteelPurchaseLines(dt)
        NewPrintSteelPurchaseLines.ShowDialog()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvSteelPurchaseLines_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelPurchaseLines.CellDoubleClick
        If dgvSteelPurchaseLines.Rows.Count > 0 Then
            Dim RowSteelPONumber As Integer = 0
          
            Dim RowIndex As Integer = Me.dgvSteelPurchaseLines.CurrentCell.RowIndex

            Try
                RowSteelPONumber = Me.dgvSteelPurchaseLines.Rows(RowIndex).Cells("SteelPurchaseOrderHeaderKeyColumn").Value
            Catch ex As Exception
                RowSteelPONumber = 0
            End Try

            GlobalSteelPONumber = RowSteelPONumber
            GlobalDivisionCode = "TWD"
   
            Using NewPrintSteelPO As New PrintSteelPurchaseOrder
                Dim Result = NewPrintSteelPO.ShowDialog
            End Using
        End If
    End Sub

    Private Sub cboSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboSteelSize.Text.Length = 0 Or cboSteelSize.SelectionLength = cboSteelSize.Text.Length) Then
            cboSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboSteelSize.SelectionStart = cboSteelSize.Text.Length
            cboSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub cboCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarbon.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                If cboSteelSize.Text.Contains("/") Then
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                Else
                    cboCarbon.DataSource = SteelDT.Select("SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'", "RMID ASC").CopyToDataTable()
                End If
                cboCarbon.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboCarbon.Text
                isloaded = False
                cboCarbon.DataSource = SteelDT.DefaultView.ToTable(True, "Carbon")
                cboCarbon.Text = tmp
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboSteelSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.Leave
        If Not String.IsNullOrEmpty(cboSteelSize.Text) AndAlso cboSteelSize.SelectedIndex = -1 Then
            If cboSteelSize.Text.Contains("/") Then
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.ConvertToDecimal(cboSteelSize.Text)
                End If
            Else
                If CType(cboSteelSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.GetFractional(cboSteelSize.Text) + "'").Length > 0 Then
                    cboSteelSize.Text = usefulFunctions.GetFractional(cboSteelSize.Text)
                End If
            End If
        End If
    End Sub

    Private Sub chkShowAllTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTypes.CheckedChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(cboCarbon.Text) Then
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                If chkAllTypes.Checked Then
                    cboSteelSize.DataSource = SteelDT.Select("Carbon like '" + cboCarbon.Text + "%'", "RMID ASC").CopyToDataTable().DefaultView.ToTable(True, "SteelSize")
                Else
                    cboSteelSize.DataSource = SteelDT.Select("Carbon = '" + cboCarbon.Text + "'", "RMID ASC").CopyToDataTable()
                End If
                cboSteelSize.Text = tmp
                isloaded = True
            Else
                Dim tmp As String = cboSteelSize.Text
                isloaded = False
                cboSteelSize.DataSource = SteelDT.DefaultView.ToTable(True, "SteelSize")
                cboSteelSize.Text = tmp
                isloaded = True
            End If
        End If
    End Sub
End Class