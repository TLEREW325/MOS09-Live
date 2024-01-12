Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Public Class ViewTrufitCertifications
    ''trying to keep cert file data together
    Private Class CertData
        Public ship As String = ""
        Public heat As String = ""
        Public part As String = ""
        Public CertNumber As String = ""
    End Class
    ''tryign to keep heat/part combo together
    Private Class PartHeats
        Public heats As List(Of String)
        Public part As String

        Public lineComment As String
    End Class
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1 As New SqlDataAdapter
    Dim ds, ds1 As DataSet

    Dim RootDirPath As String = "\\TFP-FS\TransferData\TrufitCerts"

    Dim isLoaded As Boolean = False

    Dim currentCert As String = ""
    Dim CurrentCertification As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Public Sub New()
        InitializeComponent()
        LoadCustomerData()
        LoadPartData()
        isLoaded = True
        Me.AcceptButton = cmdViewCert
    End Sub

    Private Sub LoadCustomerData()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = 'TFP'", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "CustomerList")
        con.Close()

        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerID.DataSource = ds.Tables("CustomerList")
        cboCustomerID.SelectedIndex = -1

        cboCustomerName.DisplayMember = "CustomerName"
        cboCustomerName.DataSource = ds.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub LoadPartData()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = 'TFP'", con)
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "ItemList")
        con.Close()

        cboPartNumber.DisplayMember = "ItemID"
        cboPartDescription.DisplayMember = "ShortDescription"
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Private Sub cmdFindCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCert.Click
        CRVTFPCert.ReportSource = Nothing
        Dim isfirst As Boolean = True

        Dim tfpCertNumber As String = ""
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
        Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter

        cmd = New SqlCommand("SELECT TrufitCertNumber, ShipDate, FOXTable.FOXNumber, CustomerID, PartNumber, LotNumber, HeatNumber, Quantity FROM FOXTable INNER JOIN (SELECT LotNumber, HeatNumber, FOXNumber, TrufitCertificationTable.TrufitCertNumber, Quantity, ShipDate FROM TrufitCertificationTable LEFT OUTER JOIN TrufitCertificationHeatLines ON TrufitCertificationTable.TrufitCertNumber = TrufitCertificationHeatLines.TrufitCertNumber) as TrufitCertificationTable ON FOXTable.FOXNumber = TrufitCertificationTable.FOXNumber", con)

        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            If isfirst Then
                isfirst = False
                cmd.CommandText += " WHERE CustomerID = @CustomerID"
            Else
                cmd.CommandText += " AND CustomerID = @CustomerID"
            End If
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            If isfirst Then
                isfirst = False
                cmd.CommandText += " WHERE PartNumber = @PartNumber"
            Else
                cmd.CommandText += " AND PartNumber = @PartNumber"
            End If
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If
        If Not String.IsNullOrEmpty(txtHeatNumber.Text) Then
            If isfirst Then
                isfirst = False
                cmd.CommandText += " WHERE HeatNumber Like @HeatNumber"
            Else
                cmd.CommandText += " AND HeatNumber Like @HeatNumber"
            End If
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = txtHeatNumber.Text + "%"
        End If
        If Not String.IsNullOrEmpty(txtLotNumber.Text) Then
            If isfirst Then
                isfirst = False
                cmd.CommandText += " WHERE LotNumber Like @LotNumber"
            Else
                cmd.CommandText += " AND LotNumber Like @LotNumber"
            End If
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text + "%"
        End If
        Dim tempds As New DataSet
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(tempds, "Results")
        con.Close()

        If tempds.Tables("Results").Rows.Count >= 1 Then
            Dim certCount As Integer = 0
            Dim currCert As String = ""

            For i As Integer = 0 To tempds.Tables("Results").Rows.Count - 1
                If Not tempds.Tables("Results").Rows(i).Item("TrufitCertNumber").ToString.Equals(currCert) Then
                    certCount += 1
                    currCert = tempds.Tables("Results").Rows(i).Item("TrufitCertNumber").ToString
                End If
            Next
            If certCount > 1 Then
                tfpCertNumber = LoadSelectFileName(tempds)
                If tfpCertNumber.Equals("NOT CHOSEN") Then
                    Exit Sub
                Else
                    currentCert = tfpCertNumber
                End If
            ElseIf certCount = 1 Then
                tfpCertNumber = currCert
                currentCert = tfpCertNumber
            End If
        ElseIf tempds.Tables("Results").Rows.Count = 0 Then
            MessageBox.Show("There were no TFP Certifications found for the entered data.", "No Certificaions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(tfpCertNumber)

        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = 'TFP'", con)

        cmd2 = New SqlCommand("SELECT CustomerList.CustomerID, CustomerList.CustomerName, CustomerList.BillToAddress1, CustomerList.BillToAddress2, CustomerList.BillToCity, CustomerList.BillToState, CustomerList.BillToZip FROM CustomerList INNER JOIN (SELECT DivisionID, CustomerID FROM TrufitCertificationTable INNER JOIN SalesOrderHeaderTable ON TrufitCertificationTable.SalesOrderNumber = SalesOrderHeaderTable.SalesOrderKey WHERE TrufitCertNumber = @TrufitCertNumber) as TFPCert on CustomerList.CustomerID = TFPCert.CustomerID AND CustomerList.DivisionID = TFPCert.DivisionID", con)
        cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(tfpCertNumber)

        cmd3 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd3.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(tfpCertNumber)

        cmd4 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE DivisionID = 'TFP' AND SalesOrderKey = (SELECT SalesOrderNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd4.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(tfpCertNumber)

        cmd5 = New SqlCommand("SELECT * FROM FOXTable WHERE DivisionID = 'TFP' AND FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)", con)
        cmd5.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(tfpCertNumber)

        cmd6 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)

        cmd7 = New SqlCommand("SELECT * FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd7.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(tfpCertNumber)

        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter1.SelectCommand = cmd1
        myAdapter2.SelectCommand = cmd2
        myAdapter3.SelectCommand = cmd3
        myAdapter4.SelectCommand = cmd4
        myAdapter5.SelectCommand = cmd5
        myAdapter6.SelectCommand = cmd6
        myAdapter7.SelectCommand = cmd7

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.Fill(ds, "TrufitCertificationTable")
        myAdapter1.Fill(ds, "DivisionTable")
        myAdapter2.Fill(ds, "CustomerList")
        myAdapter3.Fill(ds, "SalesOrderHeaderTable")
        myAdapter4.Fill(ds, "SalesOrderLineTable")
        myAdapter5.Fill(ds, "FOXTable")
        myAdapter6.Fill(ds, "RawMaterialsTable")
        myAdapter7.Fill(ds, "TrufitCertificationHeatLines")

        Dim cmd10 As New SqlCommand("SELECT CustomerPO FROM TrufitCertificationPickTicket INNER JOIN PickListHeaderTable ON TrufitCertificationPickTicket.PickTicket = PickListHeaderTable.PickListHeaderKey WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd10.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(tfpCertNumber)
        Dim myAdapter10 As New SqlDataAdapter(cmd10)
        myAdapter10.Fill(tempds, "TrufitCertificationPickTicket")

        If tempds.Tables("TrufitCertificationPickTicket").Rows.Count > 0 Then
            Dim lst As New List(Of String)
            For i As Integer = 0 To tempds.Tables("TrufitCertificationPickTicket").Rows.Count - 1
                If Not lst.Contains(tempds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString) Then
                    lst.Add(tempds.Tables("TrufitCertificationPickTicket").Rows(i).Item("CustomerPO").ToString)
                End If
            Next
            If lst.Count > 0 Then
                tempds.Tables("TrufitCertificationPickTicket").Rows(0).Item("CustomerPO") = String.Join(",", lst.ToArray())
            End If
        End If

        cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = (SELECT TOP 1 LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber)"

        Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
        ''changes the part nubmer to show revision level behind it, only for Branam
        If ds.Tables("FOXTable").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And ds.Tables("CustomerList").Rows.Count > 0 Then
            If ds.Tables("CustomerList").Rows(0).Item("CustomerID").ToString().Equals("BRANAMFASTEN") Then
                For i As Integer = 0 To ds.Tables("FOXTable").Rows.Count - 1
                    ds.Tables("FOXTable").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                Next
            End If
        End If
        con.Close()
        'Sets up viewer to display data from the loaded dataset
        CurrentCertification = New CRXTFCert()
        CurrentCertification.SetDataSource(ds)
        CRVTFPCert.ReportSource = CurrentCertification
    End Sub

    Private Function LoadSelectFileName(ByRef tempds As DataSet) As String
        Dim newSelectFileName As New selectTrufitCertFile
        newSelectFileName.dgvFileNames.Columns.Add("TrufitCertNumber", "TrufitCertNumber")
        newSelectFileName.dgvFileNames.Columns("TrufitCertNumber").Visible = False
        newSelectFileName.dgvFileNames.Columns.Add("ShipDate", "Ship Date")
        newSelectFileName.dgvFileNames.Columns("ShipDate").ValueType = tempds.Tables("Results").Columns("ShipDate").DataType
        newSelectFileName.dgvFileNames.Columns("ShipDate").DefaultCellStyle.Format = "MM/dd/yyyy"
        newSelectFileName.dgvFileNames.Columns("ShipDate").SortMode = DataGridViewColumnSortMode.NotSortable
        newSelectFileName.dgvFileNames.Columns.Add("CustomerID", "Customer ID")
        newSelectFileName.dgvFileNames.Columns("CustomerID").SortMode = DataGridViewColumnSortMode.NotSortable
        newSelectFileName.dgvFileNames.Columns.Add("HeatNumber", "Heat #")
        newSelectFileName.dgvFileNames.Columns("HeatNumber").SortMode = DataGridViewColumnSortMode.NotSortable
        newSelectFileName.dgvFileNames.Columns.Add("LotNumber", "Lot #")
        newSelectFileName.dgvFileNames.Columns("LotNumber").SortMode = DataGridViewColumnSortMode.NotSortable
        newSelectFileName.dgvFileNames.Columns.Add("PartNumber", "Part Number")
        newSelectFileName.dgvFileNames.Columns("PartNumber").SortMode = DataGridViewColumnSortMode.NotSortable
        newSelectFileName.dgvFileNames.Columns.Add("Quantity", "Quantity Shipped")
        newSelectFileName.dgvFileNames.Columns("Quantity").SortMode = DataGridViewColumnSortMode.NotSortable
        Dim currCert As String = ""
        Dim Heats As String = ""
        Dim Lots As String = ""
        For i As Integer = 0 To tempds.Tables("Results").Rows.Count - 1
            If Not tempds.Tables("Results").Rows(i).Item("TrufitCertNumber").ToString.Equals(currCert) Then
                Heats += " " + tempds.Tables("Results").Rows(i).Item("HeatNumber").ToString
                Lots += " " + tempds.Tables("Results").Rows(i).Item("LotNumber").ToString
                newSelectFileName.dgvFileNames.Rows.Add(tempds.Tables("Results").Rows(i).Item("TrufitCertNumber").ToString, tempds.Tables("Results").Rows(i).Item("ShipDate"), tempds.Tables("Results").Rows(i).Item("CustomerID").ToString, Heats, Lots, tempds.Tables("Results").Rows(i).Item("PartNumber").ToString, tempds.Tables("Results").Rows(i).Item("Quantity").ToString)
                Heats = ""
                Lots = ""
            Else
                Heats += " " + tempds.Tables("Results").Rows(i).Item("HeatNumber").ToString
                Lots += " " + tempds.Tables("Results").Rows(i).Item("LotNumber").ToString
            End If
        Next
        newSelectFileName.SizeForm()

        If newSelectFileName.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Return newSelectFileName.dgvFileNames.CurrentRow.Cells("TrufitCertNumber").Value.ToString
        End If
        Me.BringToFront()
        Return "NOT CHOSEN"
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomerID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        cboCustomerName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        cboPartNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        cboPartDescription.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        txtHeatNumber.Text = ""
        txtLotNumber.Text = ""
        currentCert = ""
        CRVTFPCert.ReportSource = Nothing
        cboCustomerID.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub cmdEmailCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailCert.Click
        If Not String.IsNullOrEmpty(currentCert) Then
            Dim OLApp As New Application
            'creating outlook mailitem
            Dim mail As MailItem
            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)
            'adding subject information to the mail message
            mail.Subject = "Trufit Certification"
            'adding body message information to the mail message
            mail.Body = "This is a Certification from TFP Corporation."
            'adding attachment
            cmd = New SqlCommand("if EXISTS(SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber) ELSE SELECT 'UNKNOWN';", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim customer As String = cmd.ExecuteScalar()
            con.Close()
            If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer) Then
                Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer)
            End If
            If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf") Then
                File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")
            End If
            CurrentCertification.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")

            mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")
            'display mail
            mail.Display()
        End If
    End Sub

    Private Sub cmdEmailAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailAll.Click
        If Not String.IsNullOrEmpty(currentCert) Then
            Dim OLApp As New Application
            Dim mail As MailItem
            mail = OLApp.CreateItem(OlItemType.olMailItem)
            mail.Subject = "Trufit Certification"
            mail.Body = "This is a Certification from TFP Corporation."
            cmd = New SqlCommand("if EXISTS(SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber) ELSE SELECT 'UNKNOWN';", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim customer As String = cmd.ExecuteScalar()
            con.Close()
            If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer) Then
                Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer)
            End If
            If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf") Then
                File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")
            End If
            CurrentCertification.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")

            mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + currentCert + ".pdf")
            Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As New SqlCommand
            Dim MyAdapter1, MyAdapter2, MyAdapter3, MyAdapter4, MyAdapter5, MyAdapter6, MyAdapter7 As New SqlDataAdapter
            Dim tempds As New DataSet

            If con.State = ConnectionState.Closed Then con.Open()
            tempds.Tables.Add(GetTrufitCertHeatTreatLines())
            tempds.Tables.Add(GetTrufitCertHeatLines())
            tempds.Tables.Add(GetFOXTable())


            cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber INNER JOIN TrufitCertificationHeatLines ON LotNumber.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber"

            Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()
            ''changes the part nubmer to show revision level behind it, only for Branam
            If tempds.Tables("FOXTable").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                For i As Integer = 0 To tempds.Tables("FOXTable").Rows.Count - 1
                    tempds.Tables("FOXTable").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                Next
            End If

            ''check to see if there are any heat treat records added and if so will print the cert for that
            If tempds.Tables("TrufitCertificationHeatTreatLines").Rows.Count > 0 Then
                Dim tempds2 As New DataSet()

                If con.State = ConnectionState.Closed Then con.Open()
                tempds2.Tables.Add(GetHeatTreatInspectionLog())
                tempds2.Tables.Add(GetHeatTreatRockwellTest())
                tempds2.Tables.Add(GetHeatTreatTemperatureDraw())
                tempds2.Tables.Add(GetRawMaterialsTable())
                tempds2.Tables.Add(GetItemList())
                tempds2.Tables.Add(GetCustomerList())

                ''changes the part nubmer to show revision level behind it, only for Branam
                For i As Integer = 0 To tempds2.Tables("HeatTreatInspectionLog").Rows.Count - 1
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = customer
                    If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                        tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                    End If
                Next

                For i As Integer = 0 To tempds2.Tables("HeatTreatInspectionLog").Rows.Count - 1
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = customer
                Next

                cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader INNER JOIN (SELECT DISTINCT(LotNumber) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as CertLots on CertLots.LotNumber = TrufitCertificationMechanicalTestHeader.LotNumber WHERE Status = 'CLOSED'", con)
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read()
                If reader.Item("RowCnt") > 0 Then
                    reader.Close()
                    Dim tempds3 As New DataSet()

                    cmd = New SqlCommand("SELECT TestNumber, TrufitCertificationMechanicalTestHeader.LotNumber, TrufitCertificationMechanicalTestHeader.HeatNumber, FOXTable.PartNumber, Description, TestedBy, ApprovedBy FROM TrufitCertificationMechanicalTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
                    cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                    Dim ds As New DataSet
                    Dim adap As New SqlDataAdapter(cmd)
                    cmd1 = New SqlCommand("SELECT TrufitCertificationMechanicalTestLine.TestNumber, ResultNumber, Area, ProofPound, LoadPSI, UltimatePound, TensilePSI, LoadMPA, TensileMPA, Results FROM TrufitCertificationMechanicalTestLine INNER JOIN TrufitCertificationMechanicalTestHeader ON TrufitCertificationMechanicalTestLine.TestNumber = TrufitCertificationMechanicalTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable on TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber inner join FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
                    cmd1.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                    Dim adap1 As New SqlDataAdapter(cmd1)
                    cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
                    cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

                    Dim CustomerName As String = ""
                    If con.State = ConnectionState.Closed Then con.Open()
                    adap.Fill(tempds3, "TrufitCertificationMechanicalTestHeader")
                    adap1.Fill(tempds3, "TrufitCertificationMechanicalTestLine")

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd2.ExecuteScalar()
                    con.Close()
                    If Not IsDBNull(obj) Then
                        If obj IsNot Nothing Then
                            CustomerName = obj
                        End If
                    End If
                    ''changes the part nubmer to show revision level behind it, only for Branam
                    For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                        If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                            tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                        End If
                    Next

                    ''prints heat treat certs
                    Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                    MyReport1.SetDataSource(tempds2)
                    If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\") Then
                        Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\")
                    End If
                    If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf") Then
                        File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                    End If
                    MyReport1.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                    mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                    ''prints mechanical testing
                    Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                    MyReport2.SetDataSource(tempds3)
                    CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                    If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\") Then
                        Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\")
                    End If
                    If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf") Then
                        File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                    End If
                    MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                    mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                Else
                    reader.Close()

                    ''prints heat treat certs
                    Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                    MyReport1.SetDataSource(tempds2)
                    If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\") Then
                        Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\")
                    End If
                    If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf") Then
                        File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                    End If
                    MyReport1.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                    mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "HeatTreat\HeatTreat" + currentCert + ".pdf")
                End If
            Else
                cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader INNER JOIN (SELECT DISTINCT(LotNumber) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as CertLots on CertLots.LotNumber = TrufitCertificationMechanicalTestHeader.LotNumber WHERE Status = 'CLOSED'", con)
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read()
                If reader.Item("RowCnt") > 0 Then
                    reader.Close()
                    Dim tempds3 As New DataSet()

                    Dim CustomerName As String = ""
                    If con.State = ConnectionState.Closed Then con.Open()
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestHeader())
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestLine())

                    cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
                    cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd2.ExecuteScalar()
                    con.Close()
                    If Not IsDBNull(obj) Then
                        If obj IsNot Nothing Then
                            CustomerName = obj
                        End If
                    End If

                    ''changes the part nubmer to show revision level behind it, only for Branam
                    For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                        If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                            tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                        End If
                    Next

                    ''prints the mechanical tests
                    Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                    MyReport2.SetDataSource(tempds3)
                    CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                    If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\") Then
                        Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\")
                    End If
                    If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf") Then
                        File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                    End If
                    MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                    mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "MechanicalTesting\MechanicalTesting" + currentCert + ".pdf")
                Else
                    reader.Close()
                End If
            End If

            cmd = New SqlCommand("SELECT COUNT(TrufitCertificationTorqueTestHeader.LotNumber) FROM TrufitCertificationTorqueTestHeader INNER JOIN (SELECT LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as TFPCert ON TFPCert.LotNumber = TrufitCertificationTorqueTestHeader.LotNumber", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() > 0 Then
                Dim ds As New DataSet

                Dim CustomerName As String = ""
                Dim TorqueRequirement As Double = 0
                If con.State = ConnectionState.Closed Then con.Open()
                ds.Tables.Add(GetTrufitCertificationTorqueTestHeader())
                ds.Tables.Add(GetTrufitCertificationTorqueTestLine())

                cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
                cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd2.ExecuteScalar()

                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        CustomerName = obj
                    End If
                End If

                cmd.CommandText = "SELECT TorqueRequirement FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber"
                obj = cmd.ExecuteScalar()
                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        TorqueRequirement = Val(obj)
                    End If
                End If
                con.Close()
                ''changes the part nubmer to show revision level behind it, only for Branam
                For p As Integer = 0 To ds.Tables("TrufitCertificationTorqueTestHeader").Rows.Count - 1
                    If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                        ds.Tables("TrufitCertificationTorqueTestHeader").Rows(p).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                    End If
                Next

                Dim i As Integer = 0

                While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count
                    Dim sample As Integer = 1
                    Dim currentTest As String = ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber")
                    While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count AndAlso currentTest.Equals(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber"))
                        ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") = TorqueRequirement
                        If ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") > ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") Then
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows.RemoveAt(i)
                        Else
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("SampleNumber") = sample
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") = Math.Ceiling(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque"))
                            i += 1
                            sample += 1
                        End If
                        'If i >= ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count Then
                        '    Exit While
                        'End If
                    End While
                End While
                Dim MyReport As New CRXTrufitCertificationTorqueTest
                CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

                MyReport.SetDataSource(ds)
                If Not Directory.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\") Then
                    Directory.CreateDirectory("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\")
                End If
                If File.Exists("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\TorqueTesting" + currentCert + ".pdf") Then
                    File.Delete("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\TorqueTesting" + currentCert + ".pdf")
                End If
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\TorqueTesting" + currentCert + ".pdf")
                mail.Attachments.Add("\\TFP-FS\TransferData\TrufitCerts\" + customer + "\" + "TorqueTesting\TorqueTesting" + currentCert + ".pdf")
            End If

            Dim rootDirPath As String = "\\TFP-SQL\TransferData\Mill Certifications"
            Dim FoundFiles As New Dictionary(Of String, IO.FileInfo)

            For i As Integer = 0 To tempds.Tables("TrufitCertificationHeatLines").Rows.Count - 1
                Dim dirInfo As New System.IO.DirectoryInfo(rootDirPath)
                Dim FIs As System.IO.FileInfo() = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", SearchOption.AllDirectories)
                If FIs.Count() >= 1 Then
                    For Each fi As IO.FileInfo In FIs
                        If Not FoundFiles.ContainsKey(fi.FullName) Then
                            FoundFiles.Add(fi.FullName, fi)
                        End If
                    Next

                Else
                    ''Checks size to see if it is a fraction, if it is will change to decimal, else changes to fraction
                    If tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Contains("/") Then
                        FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.ConvertToDecimal(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", SearchOption.AllDirectories)
                    Else
                        FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.GetFractional(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-") + ".pdf", SearchOption.AllDirectories)
                    End If

                    For Each fi As IO.FileInfo In FIs
                        If Not FoundFiles.ContainsKey(fi.FullName) Then
                            FoundFiles.Add(fi.FullName, fi)
                        End If
                    Next
                End If
            Next

            For Each File As IO.FileInfo In FoundFiles.Values
                mail.Attachments.Add(File.FullName)
            Next
            mail.Display()
        End If
    End Sub

    Private Function GetTrufitCertHeatTreatLines() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM TrufitCertificationHeatTreatLines  WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

        Dim dt As New Data.DataTable("TrufitCertificationHeatTreatLines")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertHeatLines() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationHeatLines.*, LotNumber.SteelSize FROM TrufitCertificationHeatLines INNER JOIN LotNumber ON TrufitCertificationHeatLines.LotNumber = LotNumber.LotNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("TrufitCertificationHeatLines")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetFOXTable() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT FOXTable.* FROM FOXTable INNER JOIN TrufitCertificationTable ON FOXTable.FOXNumber = TrufitCertificationTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.VarChar).Value = Val(currentCert)
        Dim dt As New Data.DataTable("FOXTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatInspectionLog() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatInspectionLog.HeatTreatRecordNumber, HeatTreatInspectionLog.HeatNumber, HeatTreatInspectionLog.LotNumber, HeatTreatInspectionLog.CreationDate, HeatTreatInspectionLog.RMID, FOXTable.CustomerID, FOXTable.DivisionID, FOXTable.PartNumber FROM HeatTreatInspectionLog INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("HeatTreatInspectionLog")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatRockwellTest() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatRockwellTest.HeatTreatRecordNumber, HeatTreatRockwellTest.SampleNumber, HeatTreatRockwellTest.TestType, HeatTreatRockwellTest.LineAverage, HeatTreatRockwellTest.CoreHardnessScale FROM HeatTreatRockwellTest INNER JOIN HeatTreatInspectionLog ON HeatTreatRockwellTest.HeatTreatRecordNumber = HeatTreatInspectionLog.HeatTreatRecordNumber INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("HeatTreatRockwellTest")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetHeatTreatTemperatureDraw() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT HeatTreatTemperatureDraw.HeatTreatRecordNumber, HeatTreatTemperatureDraw.TemperatureDrawNumber, HeatTreatTemperatureDraw.TemperingTemperature, HeatTreatTemperatureDraw.TemperingTime, HeatTreatTemperatureDraw.TemperingType FROM HeatTreatTemperatureDraw INNER JOIN HeatTreatInspectionLog ON HeatTreatTemperatureDraw.HeatTreatRecordNumber = HeatTreatInspectionLog.HeatTreatRecordNumber INNER JOIN TrufitCertificationHeatTreatLines ON HeatTreatInspectionLog.LotNumber = TrufitCertificationHeatTreatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatTreatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber WHERE TrufitCertificationHeatTreatLines.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("HeatTreatTemperatureDraw")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetRawMaterialsTable() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM RawMaterialsTable", con)
        Dim dt As New Data.DataTable("RawMaterialsTable")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetItemList() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT * FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON FOXTable.FOXNumber = TrufitCertificationTable.FOXNumber WHERE TrufitCertificationTable.TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("ItemList")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetCustomerList() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT CustomerList.* FROM CustomerList INNER JOIN FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID INNER JOIN TrufitCertificationTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertNumber = @TrufitCertNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("CustomerList")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationMechanicalTestHeader() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TestNumber, TrufitCertificationMechanicalTestHeader.LotNumber, TrufitCertificationMechanicalTestHeader.HeatNumber, FOXTable.PartNumber, Description, TestedBy, ApprovedBy FROM TrufitCertificationMechanicalTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("TrufitCertificationMechanicalTestHeader")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationMechanicalTestLine() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationMechanicalTestLine.TestNumber, ResultNumber, Area, ProofPound, LoadPSI, UltimatePound, TensilePSI, LoadMPA, TensileMPA, Results FROM TrufitCertificationMechanicalTestLine INNER JOIN TrufitCertificationMechanicalTestHeader ON TrufitCertificationMechanicalTestLine.TestNumber = TrufitCertificationMechanicalTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationMechanicalTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable on TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber inner join FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationMechanicalTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("TrufitCertificationMechanicalTestLine")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationTorqueTestHeader() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationTorqueTestHeader.TestNumber, TrufitCertificationTorqueTestHeader.LotNumber, TrufitCertificationTorqueTestHeader.HeatNumber, FOXTable.PartNumber, TrufitCertificationTorqueTestHeader.Description, TrufitCertificationTorqueTestHeader.TestedBy, TrufitCertificationTorqueTestHeader.ApprovedBy FROM TrufitCertificationTorqueTestHeader INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber INNER JOIN TrufitCertificationTable ON TrufitCertificationHeatLines.TrufitCertNumber = TrufitCertificationTable.TrufitCertNumber INNER JOIN FOXTable ON TrufitCertificationTable.FOXNumber = FOXTable.FOXNumber WHERE TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber AND TrufitCertificationTorqueTestHeader.Status = 'CLOSED'", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("TrufitCertificationTorqueTestHeader")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Function GetTrufitCertificationTorqueTestLine() As Data.DataTable
        Dim cmd As New SqlCommand("SELECT TrufitCertificationTorqueTestLine.TestNumber, SampleNumber, RequiredTorque, ActualTorque, Remarks FROM TrufitCertificationTorqueTestLine INNER JOIN TrufitCertificationTorqueTestHeader ON TrufitCertificationTorqueTestLine.TestNumber = TrufitCertificationTorqueTestHeader.TestNumber INNER JOIN TrufitCertificationHeatLines ON TrufitCertificationTorqueTestHeader.LotNumber = TrufitCertificationHeatLines.LotNumber WHERE TrufitCertificationTorqueTestHeader.Status = 'CLOSED' AND TrufitCertificationHeatLines.TrufitCertNumber = @TrufitCertNumber ORDER BY TrufitCertificationTorqueTestLine.TestNumber, SampleNumber", con)
        cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
        Dim dt As New Data.DataTable("TrufitCertificationTorqueTestLine")
        Dim adap As New SqlDataAdapter(cmd)
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        Return dt
    End Function

    Private Sub cmdPrintCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCert.Click
        If CurrentCertification IsNot Nothing Then
            CurrentCertification.PrintToPrinter(1, True, 0, 0)
        Else
            MessageBox.Show("You must view a Certification", "View a Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAll.Click
        If CurrentCertification IsNot Nothing Then
            CurrentCertification.PrintToPrinter(1, True, 0, 0)
            cmd = New SqlCommand("if EXISTS(SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) SELECT CustomerID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber) ELSE SELECT 'UNKNOWN';", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim customer As String = cmd.ExecuteScalar()
            con.Close()

            Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As New SqlCommand
            Dim MyAdapter1, MyAdapter2, MyAdapter3, MyAdapter4, MyAdapter5, MyAdapter6, MyAdapter7 As New SqlDataAdapter
            Dim tempds As New DataSet

            If con.State = ConnectionState.Closed Then con.Open()
            tempds.Tables.Add(GetTrufitCertHeatTreatLines())
            tempds.Tables.Add(GetTrufitCertHeatLines())
            tempds.Tables.Add(GetFOXTable())

            cmd.Parameters.Clear()
            cmd.CommandText = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = (SELECT TOP 1 LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber)"
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
            Dim BlueprintRevLevel As Object = cmd.ExecuteScalar()

            ''changes the part nubmer to show revision level behind it, only for Branam
            If tempds.Tables("FOXTable").Rows.Count > 0 And BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                For i As Integer = 0 To tempds.Tables("FOXTable").Rows.Count - 1
                    tempds.Tables("FOXTable").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                Next
            End If

            ''check to see if there are any heat treat records added and if so will print the cert for that
            If tempds.Tables("TrufitCertificationHeatTreatLines").Rows.Count > 0 Then
                Dim tempds2 As New DataSet()

                If con.State = ConnectionState.Closed Then con.Open()
                tempds2.Tables.Add(GetHeatTreatInspectionLog())
                tempds2.Tables.Add(GetHeatTreatRockwellTest())
                tempds2.Tables.Add(GetHeatTreatTemperatureDraw())
                tempds2.Tables.Add(GetRawMaterialsTable())
                tempds2.Tables.Add(GetItemList())
                tempds2.Tables.Add(GetCustomerList())

                ''changes the part nubmer to show revision level behind it, only for Branam
                For i As Integer = 0 To tempds2.Tables("HeatTreatInspectionLog").Rows.Count - 1
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = customer
                    If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                        tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                    End If
                Next

                For i As Integer = 0 To tempds2.Tables("HeatTreatInspectionLog").Rows.Count - 1
                    tempds2.Tables("HeatTreatInspectionLog").Rows(i).Item("CustomerID") = customer
                Next

                cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader INNER JOIN (SELECT DISTINCT(LotNumber) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as CertLots on CertLots.LotNumber = TrufitCertificationMechanicalTestHeader.LotNumber WHERE Status = 'CLOSED'", con)
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read()
                If reader.Item("RowCnt") > 0 Then
                    reader.Close()
                    Dim tempds3 As New DataSet()

                    cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                    cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

                    Dim CustomerName As String = ""
                    If con.State = ConnectionState.Closed Then con.Open()
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestHeader())
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestLine())

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd2.ExecuteScalar()
                    con.Close()
                    If Not IsDBNull(obj) Then
                        If obj IsNot Nothing Then
                            CustomerName = obj
                        End If
                    End If
                    ''changes the part nubmer to show revision level behind it, only for Branam
                    For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                        If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                            tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                        End If
                    Next
                    ''prints heat treat certs
                    Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                    MyReport1.SetDataSource(tempds2)

                    MyReport1.PrintToPrinter(1, True, 0, 0)
                    ''prints mechanical testing
                    Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                    MyReport2.SetDataSource(tempds3)
                    CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                    MyReport2.PrintToPrinter(1, True, 0, 0)
                Else
                    reader.Close()

                    ''prints heat treat certs
                    Dim MyReport1 = New MOS09Program.CRXHeatTreatCert
                    MyReport1.SetDataSource(tempds2)

                    MyReport1.PrintToPrinter(1, True, 0, 0)
                End If
            Else
                cmd = New SqlCommand("SELECT COUNT(TestNumber) as RowCnt FROM TrufitCertificationMechanicalTestHeader INNER JOIN (SELECT DISTINCT(LotNumber) FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as CertLots on CertLots.LotNumber = TrufitCertificationMechanicalTestHeader.LotNumber WHERE Status = 'CLOSED'", con)
                cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                reader.Read()
                If reader.Item("RowCnt") > 0 Then
                    reader.Close()
                    Dim tempds3 As New DataSet()

                    Dim CustomerName As String = ""
                    If con.State = ConnectionState.Closed Then con.Open()
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestHeader())
                    tempds3.Tables.Add(GetTrufitCertificationMechanicalTestLine())

                    cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                    cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim obj As Object = cmd2.ExecuteScalar()
                    con.Close()
                    If Not IsDBNull(obj) Then
                        If obj IsNot Nothing Then
                            CustomerName = obj
                        End If
                    End If
                    ''changes the part nubmer to show revision level behind it, only for Branam
                    For i As Integer = 0 To tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows.Count - 1
                        If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                            tempds3.Tables("TrufitCertificationMechanicalTestHeader").Rows(i).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                        End If
                    Next
                    ''prints the mechanical tests
                    Dim MyReport2 = New MOS09Program.CRXTrufitCertMechanicalTest
                    MyReport2.SetDataSource(tempds3)
                    CType(MyReport2.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName
                    MyReport2.PrintToPrinter(1, True, 0, 0)
                Else
                    reader.Close()
                End If
            End If

            cmd = New SqlCommand("SELECT COUNT(TrufitCertificationTorqueTestHeader.LotNumber) FROM TrufitCertificationTorqueTestHeader INNER JOIN (SELECT LotNumber FROM TrufitCertificationHeatLines WHERE TrufitCertNumber = @TrufitCertNumber) as TFPCert ON TFPCert.LotNumber = TrufitCertificationTorqueTestHeader.LotNumber", con)
            cmd.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar() > 0 Then
                Dim ds As New DataSet
                Dim CustomerName As String = ""
                Dim TorqueRequirement As Double = 0

                If con.State = ConnectionState.Closed Then con.Open()
                ds.Tables.Add(GetTrufitCertificationTorqueTestHeader())
                ds.Tables.Add(GetTrufitCertificationTorqueTestLine())

                cmd2 = New SqlCommand("SELECT CustomerName FROM CustomerList RIGHT OUTER JOIN (SELECT CustomerID, DivisionID FROM FOXTable WHERE FOXNumber = (SELECT FOXNumber FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber)) as FOXTable ON CustomerList.CustomerID = FOXTable.CustomerID AND CustomerList.DivisionID = FOXTable.DivisionID", con)
                cmd2.Parameters.Add("@TrufitCertNumber", SqlDbType.Int).Value = Val(currentCert)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd2.ExecuteScalar()

                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        CustomerName = obj
                    End If
                End If

                cmd.CommandText = "SELECT TorqueRequirement FROM TrufitCertificationTable WHERE TrufitCertNumber = @TrufitCertNumber"
                obj = cmd.ExecuteScalar()
                If Not IsDBNull(obj) Then
                    If obj IsNot Nothing Then
                        TorqueRequirement = Val(obj)
                    End If
                End If
                con.Close()
                ''changes the part nubmer to show revision level behind it, only for Branam
                For p As Integer = 0 To ds.Tables("TrufitCertificationTorqueTestHeader").Rows.Count - 1
                    If BlueprintRevLevel IsNot Nothing And customer.Equals("BRANAMFASTEN") Then
                        ds.Tables("TrufitCertificationTorqueTestHeader").Rows(p).Item("PartNumber") += " Rev. " + BlueprintRevLevel.ToString()
                    End If
                Next

                Dim i As Integer = 0

                While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count
                    Dim sample As Integer = 1
                    Dim currentTest As String = ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber")
                    While i < ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count AndAlso currentTest.Equals(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("TestNumber"))
                        ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") = TorqueRequirement
                        If ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("RequiredTorque") > ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") Then
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows.RemoveAt(i)
                        Else
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("SampleNumber") = sample
                            ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque") = Math.Ceiling(ds.Tables("TrufitCertificationTorqueTestLine").Rows(i).Item("ActualTorque"))
                            i += 1
                            sample += 1
                        End If
                        'If i >= ds.Tables("TrufitCertificationTorqueTestLine").Rows.Count Then
                        '    Exit While
                        'End If
                    End While
                End While
                Dim MyReport As New CRXTrufitCertificationTorqueTest
                CType(MyReport.ReportDefinition.Sections(0).ReportObjects("txtCustomerName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Customer: " + CustomerName

                MyReport.SetDataSource(ds)
                MyReport.PrintToPrinter(1, True, 0, 0)
            End If

            Dim rootDirPath As String = "\\TFP-SQL\TransferData\Mill Certifications"
            Dim FoundFiles As New Dictionary(Of String, IO.FileInfo)

            For i As Integer = 0 To tempds.Tables("TrufitCertificationHeatLines").Rows.Count - 1
                Dim dirInfo As New System.IO.DirectoryInfo(rootDirPath)
                Dim FIs As System.IO.FileInfo() = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", SearchOption.AllDirectories)
                If FIs.Count() >= 1 Then
                    For Each fi As IO.FileInfo In FIs
                        If Not FoundFiles.ContainsKey(fi.FullName) Then
                            FoundFiles.Add(fi.FullName, fi)
                        End If
                    Next

                Else
                    ''Checks size to see if it is a fraction, if it is will change to decimal, else changes to fraction
                    If tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString.Contains("/") Then
                        FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.ConvertToDecimal(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-").Replace(".", "-") + ".pdf", SearchOption.AllDirectories)
                    Else
                        FIs = dirInfo.GetFiles(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("HeatNumber").ToString.Replace("/", "-").Replace("\", "-") + "-" + usefulFunctions.GetFractional(tempds.Tables("TrufitCertificationHeatLines").Rows(i).Item("SteelSize").ToString).Replace("/", "-").Replace("\", "-") + ".pdf", SearchOption.AllDirectories)
                    End If

                    For Each fi As IO.FileInfo In FIs
                        If Not FoundFiles.ContainsKey(fi.FullName) Then
                            FoundFiles.Add(fi.FullName, fi)
                        End If
                    Next
                End If
            Next

            For Each File As IO.FileInfo In FoundFiles.Values
                Try
                    Dim MyProcess As New Process
                    MyProcess.StartInfo.CreateNoWindow = False
                    MyProcess.StartInfo.Verb = "print"
                    MyProcess.StartInfo.FileName = File.FullName
                    MyProcess.Start()
                    MyProcess.WaitForExit(10000)
                    MyProcess.CloseMainWindow()
                    MyProcess.Close()
                Catch ex As System.Exception

                End Try
            Next
        Else
            MessageBox.Show("You must view a Certification", "View a Cert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ViewTrufitCertifications_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim NewViewTrufitCerts As New ViewTrufitCerts
        NewViewTrufitCerts.Show()
    End Sub
End Class
