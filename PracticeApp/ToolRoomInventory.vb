Imports System.Data.SqlClient

Public Class ToolRoomInventory
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim searched As Boolean = False
    Dim isLoaded As Boolean = False
    Dim cmsToolRoom As New ContextMenu()
    Dim WangLikeness As New Dictionary(Of String, String)
    Dim ToolLikeness As New Dictionary(Of String, String)

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        cmsToolRoom.MenuItems.Add("Print Label", AddressOf PrintLabelCMS)
        cmsToolRoom.MenuItems(0).Name = "PrintLabelCMS"
        cmsToolRoom.MenuItems.Add("Delete Tool", AddressOf DeleteTool)
        cmsToolRoom.MenuItems(1).Name = "DeleteTool"

        LoadBlueprint()
        LoadToolTypeID()
        LoadWangTypeID()
        LoadLikeness()
        isLoaded = True
    End Sub
    Private Sub LoadLikeness()
        cmd = New SqlCommand(" SELECT DISTINCT (ToolTypeID), WangTypeID FROM ToolInventory ORDER BY WangTypeID", con)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read
                If Not WangLikeness.ContainsKey(reader.Item(1)) Then
                    WangLikeness.Add(reader.Item(1), reader.Item(0))
                End If
                If Not ToolLikeness.ContainsKey(reader.Item(0)) Then
                    ToolLikeness.Add(reader.Item(0), reader.Item(1))
                End If
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub dgvToolRoomInventory_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvToolRoomInventory.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = dgvToolRoomInventory.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgvToolRoomInventory.SelectedCells(0).Selected = False
                dgvToolRoomInventory.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                dgvToolRoomInventory.CurrentCell = dgvToolRoomInventory.Rows(ht.RowIndex).Cells(ht.ColumnIndex)

                cmsToolRoom.Show(dgvToolRoomInventory, New System.Drawing.Point(e.X, e.Y))
            End If
        End If
        
    End Sub
    Private Sub PrintLabelCMS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        printLabel()
    End Sub
    Private Sub DeleteTool(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DeleteTool()
    End Sub

    Private Sub LoadBlueprint()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) FROM FOXTable ORDER BY BlueprintNumber ASC", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "FOXTable")
        con.Close()
        ds3 = ds.Copy()
        cboAddInventoryBlueprintNumber.DisplayMember = "BlueprintNumber"
        cboAddInventoryBlueprintNumber.DataSource = ds3.Tables("FOXTable")
        cboAddInventoryBlueprintNumber.SelectedIndex = -1

        cboBlueprintNumber.DisplayMember = "BlueprintNumber"
        cboBlueprintNumber.DataSource = ds.Tables("FOXTable")
        cboBlueprintNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadToolTypeID()
        cmd = New SqlCommand("SELECT ToolType FROM ToolTypeID", con)
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboAddInventoryToolType.Items.Add(reader.Item(0))
                cboToolType.Items.Add(reader.Item(0))
            End While
        End If
        reader.Close()
        con.Close()
        
    End Sub

    Private Sub LoadWangTypeID()
        cmd = New SqlCommand("SELECT DISTINCT(WangTypeID) FROM ToolInventory", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboAddInventoryWangType.Items.Add(reader.Item(0))
                cboWangType.Items.Add(reader.Item(0))
            End While
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Search()
    End Sub

    Public Sub Search()
        Dim isFirst As Boolean = True
        Dim blueprint As Boolean = False
        cmd = New SqlCommand("SELECT ToolID, ToolTypeID, ToolOD, ToolFirstLength, ToolFirstID, DivisionID, Section, SectionRow, SectionColumn, ToolSecondLength, ToolSecondID, ToolThirdLength, ToolThirdID, ToolFourthLength, ToolFourthID, ToolRemarks, DateCreated, BluePrint, Material, WangTypeID, DieSection FROM ToolInventory ", con)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        ''if blueprint is entered
        If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE BluePrint = @BluePrint"
                isFirst = False
            Else
                cmd.CommandText += " AND BluePrint = @BluePrint"
            End If
            cmd.Parameters.Add("@BluePrint", SqlDbType.VarChar).Value = cboBlueprintNumber.Text
            blueprint = True
        End If
        ''if tool type is entered
        If Not String.IsNullOrEmpty(cboToolType.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE ToolTypeID = @ToolTypeID"
                isFirst = False
            Else
                cmd.CommandText += " AND ToolTypeID = @ToolTypeID"
            End If
            cmd.Parameters.Add("@ToolTypeID", SqlDbType.VarChar).Value = cboToolType.Text
            If cboToolType.Text.Equals("BLUEPRINT TUB") Then
                blueprint = True
            End If
        End If
        ''if wang type is entered
        If Not String.IsNullOrEmpty(cboWangType.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE WangTypeID = @WangTypeID"
            Else
                cmd.CommandText += " AND WangTypeID = @WangTypeID"
            End If
            cmd.Parameters.Add("@WangTypeID", SqlDbType.VarChar).Value = cboWangType.Text
            If cboWangType.Text.Equals("BT") Then
                blueprint = True
            End If
        End If
        ''if section entered
        If Not String.IsNullOrEmpty(txtSearchSection.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE Section = @Section"
            Else
                cmd.CommandText += " AND Section = @Section"
            End If

            cmd.Parameters.Add("@Section", SqlDbType.VarChar).Value = txtSearchSection.Text.ToUpper()
        End If
        ''if section row is entered
        If Not String.IsNullOrEmpty(txtSearchSectionRow.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE SectionRow = @SectionRow"
            Else
                cmd.CommandText += " AND SectionRow = @SectionRow"
            End If
            cmd.Parameters.Add("@SectionRow", SqlDbType.VarChar).Value = txtSearchSectionRow.Text
        End If
        ''if section column is entered
        If Not String.IsNullOrEmpty(txtSearchSectionColumn.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE SectionColumn = @SectionColumn"
            Else
                cmd.CommandText += " AND SectionColumn = @SectionColumn"
            End If
            cmd.Parameters.Add("@SectionColumn", SqlDbType.VarChar).Value = txtSearchSectionColumn.Text
        End If
        ''if the first length was entered
        If Not String.IsNullOrEmpty(txtSearchFirstLength.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE ToolFirstLength = @ToolFirstLength"
            Else
                cmd.CommandText += " AND ToolFirstLength = @ToolFirstLength"
            End If
            cmd.Parameters.Add("@ToolFirstLength", SqlDbType.Int).Value = Val(txtSearchFirstLength.Text)
        End If

        If Not String.IsNullOrEmpty(txtSearchFirstInnerDiameter.Text) Then
            If isFirst Then
                isFirst = False
                cmd.CommandText += " WHERE (ToolFirstID BETWEEN @ToolFirstID AND @ToolFirstID1) ORDER BY ToolFirstID DESC"
            Else
                cmd.CommandText += " AND (ToolFirstID BETWEEN @ToolFirstID AND @ToolFirstID1) ORDER BY ToolFirstID DESC"
            End If
            cmd.Parameters.Add("@ToolFirstID", SqlDbType.Float).Value = Val(txtSearchFirstInnerDiameter.Text) - Val(txtSearchInnerDiameterTolerance.Text)
            cmd.Parameters.Add("@ToolFirstID1", SqlDbType.Float).Value = Val(txtSearchFirstInnerDiameter.Text)
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "ToolInventory")
        con.Close()
        If blueprint Then
            ds4.Tables("ToolInventory").Columns("BluePrint").SetOrdinal(2)
            ds4.Tables("ToolInventory").Columns("Section").SetOrdinal(3)
            ds4.Tables("ToolInventory").Columns("SectionRow").SetOrdinal(4)
            ds4.Tables("ToolInventory").Columns("SectionColumn").SetOrdinal(5)
        End If
        isLoaded = False
        dgvToolRoomInventory.DataSource = ds4.Tables("ToolInventory")
        setupDGV()
        cboRemoveToolType.DisplayMember = "ToolTypeID"
        cboRemoveToolType.DataSource = ds4.Tables("ToolInventory")
        If dgvToolRoomInventory.Rows.Count > 0 Then
            cboRemoveToolType.SelectedIndex = 0
        End If

        searched = True
        isLoaded = True
    End Sub

    Private Sub setupDGV()
        dgvToolRoomInventory.Columns("ToolID").Visible = False
        dgvToolRoomInventory.Columns("DivisionID").Visible = False

        dgvToolRoomInventory.Columns("ToolTypeID").HeaderText = "Tool Type ID"
        dgvToolRoomInventory.Columns("ToolTypeID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvToolRoomInventory.Columns("ToolTypeID").ReadOnly = True
        dgvToolRoomInventory.Columns("WangTypeID").HeaderText = "Wang Type ID"
        dgvToolRoomInventory.Columns("WangTypeID").ReadOnly = True
        dgvToolRoomInventory.Columns("Section").Width = 50
        dgvToolRoomInventory.Columns("SectionRow").HeaderText = "Section Row"
        dgvToolRoomInventory.Columns("SectionRow").Width = 50
        dgvToolRoomInventory.Columns("SectionColumn").HeaderText = "Section Column"
        dgvToolRoomInventory.Columns("SectionColumn").Width = 50
        dgvToolRoomInventory.Columns("ToolOD").HeaderText = "Tool Outer Diameter"
        dgvToolRoomInventory.Columns("ToolOD").Width = 65
        dgvToolRoomInventory.Columns("ToolFirstLength").HeaderText = "Tool First Length"
        dgvToolRoomInventory.Columns("ToolFirstLength").Width = 65
        dgvToolRoomInventory.Columns("ToolFirstID").HeaderText = "Tool First Inner Diameter"
        dgvToolRoomInventory.Columns("ToolFirstID").Width = 65
        dgvToolRoomInventory.Columns("ToolSecondLength").HeaderText = "Tool Second Length"
        dgvToolRoomInventory.Columns("ToolSecondLength").Width = 65
        dgvToolRoomInventory.Columns("ToolSecondID").HeaderText = "Tool Second Inner Diameter"
        dgvToolRoomInventory.Columns("ToolSecondID").Width = 65
        dgvToolRoomInventory.Columns("ToolThirdLength").HeaderText = "Tool Third Length"
        dgvToolRoomInventory.Columns("ToolThirdLength").Width = 65
        dgvToolRoomInventory.Columns("ToolThirdID").HeaderText = "Tool Third Inner Diameter"
        dgvToolRoomInventory.Columns("ToolThirdID").Width = 65
        dgvToolRoomInventory.Columns("ToolFourthLength").HeaderText = "Tool Fourth Length"
        dgvToolRoomInventory.Columns("ToolFourthLength").Width = 65
        dgvToolRoomInventory.Columns("ToolFourthID").HeaderText = "Tool Fourth Inner Diameter"
        dgvToolRoomInventory.Columns("ToolFourthID").Width = 65
        dgvToolRoomInventory.Columns("ToolRemarks").HeaderText = "Tool Remarks"
        dgvToolRoomInventory.Columns("DateCreated").HeaderText = "Date Created"
        dgvToolRoomInventory.Columns("DateCreated").ReadOnly = True
        dgvToolRoomInventory.Columns("DieSection").HeaderText = "Die Section"
    End Sub

    Private Sub cmdClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSearch.Click
        cboBlueprintNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBlueprintNumber.Text) Then
            cboBlueprintNumber.Text = ""
        End If
        cboToolType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboToolType.Text) Then
            cboToolType.Text = ""
        End If
        cboWangType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboWangType.Text) Then
            cboWangType.Text = ""
        End If
        txtSearchSection.Clear()
        txtSearchSectionRow.Clear()
        txtSearchSectionColumn.Clear()
        txtSearchFirstLength.Clear()
        txtSearchFirstInnerDiameter.Clear()
        txtSearchInnerDiameterTolerance.Text = "0.2"
        ds4 = New DataSet()
        dgvToolRoomInventory.DataSource = Nothing
        cboRemoveToolType.DataSource = Nothing
        cboRemoveToolType.Text = ""
        lblRemoveSectionData.Text = ""
        lblRemoveSectionRowData.Text = ""
        lblRemoveSectionColumnData.Text = ""
        lblRemoveBlueprintNumber.Text = ""
        lblRemoveMaterialType.Text = ""
        searched = False
        cboBlueprintNumber.Focus()
    End Sub

    Private Sub dgvToolRoomInventory_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvToolRoomInventory.CurrentCellChanged
        If Not dgvToolRoomInventory.CurrentCell Is Nothing Then
            lblRemoveSectionData.Text = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("Section").Value
            lblRemoveSectionRowData.Text = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("SectionRow").Value
            lblRemoveSectionColumnData.Text = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("SectionColumn").Value
            lblRemoveBlueprintNumber.Text = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("BluePrint").Value
            If IsDBNull(dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("Material").Value) Then
                lblRemoveMaterialType.Text = ""
            Else
                lblRemoveMaterialType.Text = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("Material").Value
            End If

        End If
    End Sub

    Private Sub cmdAddToInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToInventory.Click
        If canAddToInventory() Then
            cmd = New SqlCommand("DECLARE @ToolID as int = (SELECT isnull(MAX(ToolID) + 1, 1) FROM ToolInventory); INSERT INTO ToolInventory (ToolID, ToolTypeID, WangTypeID, DivisionID, Section, SectionRow, SectionColumn, BluePrint, Material, ToolOD, ToolFirstLength, ToolFirstID, ToolSecondLength, ToolSecondID, ToolThirdLength, ToolThirdID, ToolFourthLength, ToolFourthID, ToolRemarks, DateCreated, DieSection) VALUES(@ToolID, @ToolTypeID, @WangTypeID, 'TFP', @Section, @SectionRow, @SectionColumn, @BluePrint, @Material, @ToolOD, @ToolFirstLength, @ToolFirstID, @ToolSecondLength, @ToolSecondID, @ToolThirdLength, @ToolThirdID, @ToolFourthLength, @ToolFourthID, @ToolRemarks, @DateCreated, @DieSection); SELECT @ToolID", con)
            With cmd.Parameters
                .Add("@ToolTypeID", SqlDbType.VarChar).Value = cboAddInventoryToolType.Text
                .Add("@WangTypeID", SqlDbType.VarChar).Value = cboAddInventoryWangType.Text
                .Add("@Section", SqlDbType.VarChar).Value = txtAddInventorySection.Text
                .Add("@SectionRow", SqlDbType.VarChar).Value = txtAddInventorySectionRow.Text
                .Add("@SectionColumn", SqlDbType.VarChar).Value = txtAddInventorySectionColumn.Text
                .Add("@BluePrint", SqlDbType.VarChar).Value = cboAddInventoryBlueprintNumber.Text
                .Add("@Material", SqlDbType.VarChar).Value = txtAddInventoryMaterialType.Text
                .Add("@ToolOD", SqlDbType.VarChar).Value = txtAddInventoryOuterDiameter.Text
                .Add("@ToolFirstLength", SqlDbType.VarChar).Value = txtAddInventoryFirstLength.Text
                .Add("@ToolFirstID", SqlDbType.VarChar).Value = txtAddInventoryFirstID.Text
                .Add("@ToolSecondLength", SqlDbType.VarChar).Value = txtAddInventorySecondLength.Text
                .Add("@ToolSecondID", SqlDbType.VarChar).Value = txtAddInventorySecondID.Text
                .Add("@ToolThirdLength", SqlDbType.VarChar).Value = txtAddInventoryThirdLength.Text
                .Add("@ToolThirdID", SqlDbType.VarChar).Value = txtAddInventoryThirdID.Text
                .Add("@ToolFourthLength", SqlDbType.VarChar).Value = txtAddInventoryFourthLength.Text
                .Add("@ToolFourthID", SqlDbType.VarChar).Value = txtAddInventoryFourthID.Text
                .Add("@ToolRemarks", SqlDbType.VarChar).Value = txtAddInventoryRemarks.Text
                .Add("@DateCreated", SqlDbType.VarChar).Value = Today.Date.ToShortDateString()
                .Add("@DieSection", SqlDbType.VarChar).Value = txtAddInventoryDieSection.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If cboAddInventoryWangType.SelectedIndex = -1 And EmployeeSecurityCode <= 1007 Then
                LoadWangTypeID()
            End If
            If chkPrintLabel.Checked AndAlso obj IsNot Nothing Then
                printLabel(obj.ToString())
            End If
            If searched Then
                Search()
            End If
            ClearAddInventory()
        End If
    End Sub

    Private Function canAddToInventory() As Boolean
        If String.IsNullOrEmpty(cboAddInventoryToolType.Text) Then
            MessageBox.Show("You must select a Tool Type", "Select a Tool Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAddInventoryToolType.Focus()
            Return False
        End If
        If cboAddInventoryToolType.SelectedIndex = -1 Then
            If EmployeeSecurityCode > 1002 And EmployeeSecurityCode <> 1031 Then
                MessageBox.Show("You must select a Valid Tool Type", "Select a Valid Tool Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Else
                cmd = New SqlCommand("INSERT INTO ToolTypeID (ToolType) VALUES(@ToolType)", con)
                cmd.Parameters.Add("@ToolType", SqlDbType.VarChar).Value = cboAddInventoryToolType.Text.ToUpper()
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Dim tmp As String = cboAddInventoryToolType.Text
                LoadToolTypeID()
                cboAddInventoryToolType.Text = tmp
            End If
        End If
        If String.IsNullOrEmpty(cboAddInventoryWangType.Text) Then
            MessageBox.Show("You must select a Wang Type ID", "Select a Wang Type ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboAddInventoryWangType.SelectedIndex = -1 Then
            If EmployeeSecurityCode > 1002 And EmployeeSecurityCode <> 1031 Then
                MessageBox.Show("You must enter a valid Wang Type ID", "Enter a valid Wang Type ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        If String.IsNullOrEmpty(txtAddInventorySection.Text) Then
            MessageBox.Show("You must enter a Section", "Enter a Section", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddInventorySection.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddInventorySectionRow.Text) Then
            MessageBox.Show("You must enter a Row", "Enter a Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddInventorySectionRow.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddInventorySectionColumn.Text) Then
            MessageBox.Show("You must enter a Column", "Enter a Column", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddInventorySectionColumn.Focus()
            Return False
        End If
        If Not cboAddInventoryToolType.Text.Equals("BLUEPRINT TUB") Then
            If String.IsNullOrEmpty(txtAddInventoryOuterDiameter.Text) Then
                MessageBox.Show("You must enter an Outer Diameter", "Enter an Outer Diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryOuterDiameter.Focus()
                Return False
            End If
            If Not IsNumeric(txtAddInventoryOuterDiameter.Text) Then
                MessageBox.Show("You must enter a number for Outer Diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryOuterDiameter.SelectAll()
                txtAddInventoryOuterDiameter.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtAddInventoryFirstLength.Text) Then
                MessageBox.Show("You must enter a First Length", "Enter a First Length", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryFirstLength.Focus()
                Return False
            End If
            If Not IsNumeric(txtAddInventoryFirstLength.Text) Then
                MessageBox.Show("You must enter a number for First Length", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryFirstLength.SelectAll()
                txtAddInventoryFirstLength.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtAddInventoryFirstID.Text) Then
                MessageBox.Show("You must enter a First Diameter", "Enter a First Inner Diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryFirstID.Focus()
                Return False
            End If
            If Not IsNumeric(txtAddInventoryFirstID.Text) Then
                MessageBox.Show("You must enter a number for First Inner Diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddInventoryFirstID.SelectAll()
                txtAddInventoryFirstID.Focus()
                Return False
            End If
            If Not String.IsNullOrEmpty(txtAddInventorySecondLength.Text) Then
                If Not IsNumeric(txtAddInventorySecondLength.Text) Then
                    MessageBox.Show("You must enter a number for Second Length", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventorySecondLength.SelectAll()
                    txtAddInventorySecondLength.Focus()
                    Return False
                End If
            End If
            If Not String.IsNullOrEmpty(txtAddInventorySecondID.Text) Then
                If Not IsNumeric(txtAddInventorySecondID.Text) Then
                    MessageBox.Show("You must enter a number for Second Inner Diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventorySecondID.SelectAll()
                    txtAddInventorySecondID.Focus()
                    Return False
                End If
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryThirdLength.Text) Then
                If Not IsNumeric(txtAddInventoryThirdLength.Text) Then
                    MessageBox.Show("You must enter a number for Third Length", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventoryThirdLength.SelectAll()
                    txtAddInventoryThirdLength.Focus()
                    Return False
                End If
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryThirdID.Text) Then
                If Not IsNumeric(txtAddInventoryThirdID.Text) Then
                    MessageBox.Show("You must enter a number for Third Inner Diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventoryThirdID.SelectAll()
                    txtAddInventoryThirdID.Focus()
                    Return False
                End If
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryFourthLength.Text) Then
                If Not IsNumeric(txtAddInventoryFourthLength.Text) Then
                    MessageBox.Show("You must enter a number for Fourth Length", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventoryFourthLength.SelectAll()
                    txtAddInventoryFourthLength.Focus()
                    Return False
                End If
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryFourthID.Text) Then
                If Not IsNumeric(txtAddInventoryFourthID.Text) Then
                    MessageBox.Show("You must enter a number for Fourth Inner Diameter", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddInventoryFourthID.SelectAll()
                    txtAddInventoryFourthID.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub cmdClearAddInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddInventory.Click
        ClearAddInventory()
    End Sub

    Private Sub ClearAddInventory()
        cboAddInventoryToolType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboAddInventoryToolType.Text) Then
            cboAddInventoryToolType.Text = ""
        End If
        cboAddInventoryWangType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboAddInventoryWangType.Text) Then
            cboAddInventoryWangType.Text = ""
        End If
        txtAddInventorySection.Clear()
        txtAddInventorySectionRow.Clear()
        txtAddInventorySectionColumn.Clear()
        cboAddInventoryBlueprintNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboAddInventoryBlueprintNumber.Text) Then
            cboAddInventoryBlueprintNumber.Text = ""
        End If
        txtAddInventoryMaterialType.Clear()
        txtAddInventoryOuterDiameter.Clear()
        txtAddInventoryFirstLength.Clear()
        txtAddInventoryFirstID.Clear()
        txtAddInventorySecondLength.Clear()
        txtAddInventorySecondID.Clear()
        txtAddInventoryThirdLength.Clear()
        txtAddInventoryThirdID.Clear()
        txtAddInventoryFourthLength.Clear()
        txtAddInventoryFourthID.Clear()
        txtAddInventoryRemarks.Clear()
        txtAddInventoryDieSection.Clear()
        chkPrintLabel.Checked = False
        cboAddInventoryToolType.Focus()
    End Sub

    Private Sub cmdRemoveTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveTool.Click
        DeleteTool()
    End Sub

    Private Sub DeleteTool()
        If canRemoveTool() Then
            ''if more a row or multiple rows are selected this will will take care of that  
            If dgvToolRoomInventory.SelectedRows.Count > 0 Then
                cmd = New SqlCommand("DELETE ToolInventory WHERE ToolID = @ToolID", con)
                cmd.Parameters.Add("@ToolID", SqlDbType.Int)
                For i As Integer = 0 To dgvToolRoomInventory.SelectedRows.Count - 1
                    cmd.Parameters("@ToolID").Value = dgvToolRoomInventory.SelectedRows(i).Cells("ToolID").Value
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Next
                con.Close()
            Else
                ''if the user only selected a cell this will take care of that
                cmd = New SqlCommand("DELETE ToolInventory WHERE ToolID = @ToolID", con)
                cmd.Parameters.Add("@ToolID", SqlDbType.Int).Value = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("ToolID").Value

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            Dim currentRow As Integer = dgvToolRoomInventory.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvToolRoomInventory.CurrentCell.ColumnIndex
            ''reloads the DGV data
            Search()
            ''this takes care of the placement of the currently selected cell after reload of date  
            If dgvToolRoomInventory.Rows.Count > currentRow Then
                dgvToolRoomInventory.CurrentCell = dgvToolRoomInventory.Rows(currentRow).Cells(currentColumn)
            Else
                While currentRow >= dgvToolRoomInventory.Rows.Count
                    currentRow -= 1
                End While
                If currentRow >= 0 Then
                    dgvToolRoomInventory.CurrentCell = dgvToolRoomInventory.Rows(currentRow).Cells(currentColumn)
                End If
            End If
        End If
    End Sub

    Private Function canRemoveTool() As Boolean
        If String.IsNullOrEmpty(cboRemoveToolType.Text) Then
            MessageBox.Show("You must select a Tool Type", "Select a Tool Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRemoveToolType.Focus()
            Return False
        End If
        If cboRemoveToolType.Text.Equals("BLUEPRINT TUB") Then
            If MessageBox.Show("Are you sure you wish to delete this blueprint tub", "Delete blueprint tub", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                cboRemoveToolType.Focus()
                Return False
            End If

        End If
        If dgvToolRoomInventory.Rows.Count = 0 Then
            MessageBox.Show("There are no Tools to select", "Search for Tools", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmdSearch.Focus()
        End If
        If dgvToolRoomInventory.CurrentCell Is Nothing Then
            MessageBox.Show("You must select a Tool", "Select a Tool", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvToolRoomInventory.Focus()
            Return False
        End If
        If dgvToolRoomInventory.SelectedRows.Count > 10 Then
            If MessageBox.Show("Are you sure you wish to delete all " + dgvToolRoomInventory.SelectedRows.Count.ToString() + " selected rows?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub pnlAddTool_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlAddTool.Enter
        Me.AcceptButton = Nothing
    End Sub

    Private Sub gpxSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpxSearch.Enter
        Me.AcceptButton = cmdSearch
    End Sub


    Private Sub pnlAddTool_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlAddTool.Leave
        Me.AcceptButton = cmdSearch
    End Sub

    Private Sub dgvToolRoomInventory_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvToolRoomInventory.CellValueChanged
        If canChange() Then
            cmd = New SqlCommand("UPDATE ToolInventory SET " + dgvToolRoomInventory.Columns(dgvToolRoomInventory.CurrentCell.ColumnIndex).DataPropertyName + " = @Value WHERE ToolID = @ToolID", con)
            cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = dgvToolRoomInventory.CurrentCell.Value.ToString()
            cmd.Parameters.Add("@ToolID", SqlDbType.VarChar).Value = dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("ToolID").Value

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Dim currentRow As Integer = dgvToolRoomInventory.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvToolRoomInventory.CurrentCell.ColumnIndex
            Search()
            If dgvToolRoomInventory.Rows.Count > currentRow Then
                dgvToolRoomInventory.CurrentCell = dgvToolRoomInventory.Rows(currentRow).Cells(currentColumn)
            End If
        End If
    End Sub

    Private Function canChange() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If IsDBNull(dgvToolRoomInventory.CurrentCell.Value) Then
            Select Case dgvToolRoomInventory.Columns(dgvToolRoomInventory.CurrentCell.ColumnIndex).Name
                Case "ToolRemarks", "Section", "SectionRow", "BluePrint", "Material", "DieSection"
                    dgvToolRoomInventory.CurrentCell.Value = ""
                Case "ToolOD", "ToolFirstLength", "ToolFirstID", "ToolSecondLength", "ToolSecondID", "ToolThirdLength", "ToolThirdID", "ToolFourthLength", "ToolFourthID"
                    dgvToolRoomInventory.CurrentCell.Value = 0
            End Select
            Return False
        End If
        Select Case dgvToolRoomInventory.Columns(dgvToolRoomInventory.CurrentCell.ColumnIndex).Name
            Case "ToolRemarks"
                If dgvToolRoomInventory.CurrentCell.Value.ToString().Count() > 100 Then
                    If MessageBox.Show("Remark entered is greater than what can be stored. Proceeding will remove anything over 100 characters, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                        Return False
                    End If
                    dgvToolRoomInventory.CurrentCell.Value = dgvToolRoomInventory.CurrentCell.Value.ToString().Substring(0, 100)
                    Return False
                End If
            Case "BluePrint", "WangTypeID", "Section", "DieSection"
                If dgvToolRoomInventory.CurrentCell.Value.ToString().Count() > 10 Then
                    If MessageBox.Show(dgvToolRoomInventory.Columns(dgvToolRoomInventory.CurrentCell.ColumnIndex).HeaderText + " entered is greater than what can be stored. Proceeding will remove anything over 10 characters, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                        Return False
                    End If
                    dgvToolRoomInventory.CurrentCell.Value = dgvToolRoomInventory.CurrentCell.Value.ToString().Substring(0, 10)
                    Return False
                End If
            Case "ToolOD", "ToolFirstLength", "ToolFirstID", "ToolSecondLength", "ToolSecondID", "ToolThirdLength", "ToolThirdID", "ToolFourthLength", "ToolFourthID"
                If Not IsNumeric(dgvToolRoomInventory.CurrentCell.Value) Then
                    MessageBox.Show("Value entered must be a number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Sub dgvToolRoomInventory_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvToolRoomInventory.DataError
        If e.Exception.ToString.Contains("not in a correct format") Then
            MessageBox.Show("Input must be a number", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cboAddInventoryBlueprintNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddInventoryBlueprintNumber.Leave
        If cboAddInventoryBlueprintNumber.Text.Equals("0") Then
            chkPrintLabel.Checked = True
        End If
    End Sub

    Private Sub getSuggestedLocation()
        If Not String.IsNullOrEmpty(cboAddInventoryToolType.Text) AndAlso Not String.IsNullOrEmpty(txtAddInventoryOuterDiameter.Text) AndAlso Not String.IsNullOrEmpty(txtAddInventoryFirstID.Text) Then
            Dim isFirst As Boolean = True
            cmd = New SqlCommand("SELECT Section, SectionRow, SectionColumn FROM (SELECT Section, SectionRow, SectionColumn, SUM(ToolOD * (ToolFirstLength + ToolSecondLength + ToolThirdLength + ToolFourthLength) * ToolOD) as Volume FROM ToolInventory", con)
            If Not String.IsNullOrEmpty(cboAddInventoryToolType.Text) Then
                If isFirst Then
                    isFirst = False
                    cmd.CommandText += " WHERE ToolTypeID = @ToolTypeID"
                Else
                    cmd.CommandText += " AND ToolTypeID = @ToolTypeID"
                End If
                cmd.Parameters.Add("@ToolTypeID", SqlDbType.VarChar).Value = cboAddInventoryToolType.Text
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryOuterDiameter.Text) Then
                If isFirst Then
                    isFirst = False
                    cmd.CommandText += " WHERE ToolOD = @ToolOD"
                Else
                    cmd.CommandText += " AND ToolOD = @ToolOD"
                End If
                cmd.Parameters.Add("@ToolOD", SqlDbType.Float).Value = Val(txtAddInventoryOuterDiameter.Text)
            End If
            If Not String.IsNullOrEmpty(txtAddInventoryFirstID.Text) Then
                If isFirst Then
                    isFirst = False
                    cmd.CommandText += " WHERE ToolFirstID = @ToolFirstID"
                Else
                    cmd.CommandText += " AND ToolFirstID = @ToolFirstID"
                End If
                cmd.Parameters.Add("@ToolFirstID", SqlDbType.Float).Value = Val(txtAddInventoryFirstID.Text)
            End If
            ''Static number of 75% of the volume, based on LxWxH of the bin in the locations. L = 16", W = 8-1/2", H = 7-1/2"
            cmd.CommandText += " GROUP BY Section, SectionRow, SectionColumn) as tmp WHERE Volume <= 765"
            Dim tempds As New DataSet()
            Dim tempadap As New SqlDataAdapter
            tempadap.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            tempadap.Fill(tempds, "ToolInventory")
            con.Close()

            If tempds.Tables("ToolInventory").Rows.Count > 0 Then
                txtAddInventorySection.Text = tempds.Tables("ToolInventory").Rows(0).Item("Section")
                txtAddInventorySectionRow.Text = tempds.Tables("ToolInventory").Rows(0).Item("SectionRow")
                txtAddInventorySectionColumn.Text = tempds.Tables("ToolInventory").Rows(0).Item("SectionColumn")
            End If
        Else
            txtAddInventorySection.Clear()
            txtAddInventorySectionRow.Clear()
            txtAddInventorySectionColumn.Clear()
        End If

    End Sub

    Private Sub printLabel(Optional ByVal toolID As String = Nothing)
        If toolID Is Nothing Then
            If Not dgvToolRoomInventory.CurrentCell Is Nothing Then
                Dim bc As New BarcodeLabel
                bc.setupToolLabel(dgvToolRoomInventory.Rows(dgvToolRoomInventory.CurrentCell.RowIndex).Cells("ToolID").Value)

                bc.PrintBarcodeLine()
            Else
                MessageBox.Show("You must Select a Tool to print a label", "Select a Tool", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Dim bc As New BarcodeLabel
            bc.setupToolLabel(toolID)
            bc.PrintBarcodeLine()
        End If

    End Sub

    Private Sub cmdPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabel.Click
        printLabel()
    End Sub

    Private Sub txtAdd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddInventoryOuterDiameter.Leave, txtAddInventoryFirstID.Leave
        Dim txt As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
        txt.Text = Math.Round(Val(txt.Text), 3, MidpointRounding.AwayFromZero)
        getSuggestedLocation()
    End Sub

    Private Sub txtAddInventory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddInventoryOuterDiameter.Leave, txtAddInventoryFirstLength.Leave, txtAddInventorySecondLength.Leave, txtAddInventorySecondID.Leave, txtAddInventoryThirdLength.Leave, txtAddInventoryThirdID.Leave, txtAddInventoryFourthLength.Leave, txtAddInventoryFourthID.Leave
        Dim txt As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
        txt.Text = Math.Round(Val(txt.Text), 3, MidpointRounding.AwayFromZero)
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click
        Dim printInventory As New PrintToolRoomInventory(ds4)
        printInventory.ShowDialog()
    End Sub

    Private Sub ToolRoomInventory_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub cboAddInventoryToolType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddInventoryToolType.Leave
        getSuggestedLocation()
    End Sub

    Private Sub AddInventory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAddInventoryToolType.KeyDown, cboAddInventoryWangType.KeyDown, cboAddInventoryBlueprintNumber.KeyDown, txtAddInventoryOuterDiameter.KeyDown, txtAddInventoryFirstLength.KeyDown, txtAddInventoryFirstID.KeyDown, txtAddInventorySecondLength.KeyDown, txtAddInventorySecondID.KeyDown, txtAddInventoryThirdLength.KeyDown, txtAddInventoryThirdID.KeyDown, txtAddInventoryFourthLength.KeyDown, txtAddInventoryFourthID.KeyDown, txtAddInventoryDieSection.KeyDown, txtAddInventoryMaterialType.KeyDown, txtAddInventoryRemarks.KeyDown, txtAddInventorySection.KeyDown, txtAddInventorySectionRow.KeyDown, txtAddInventorySectionColumn.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cboAddInventoryWangType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddInventoryWangType.SelectedIndexChanged
        SelectLikeCode("WANG", cboAddInventoryWangType, cboAddInventoryToolType)
    End Sub

    Private Sub SelectLikeCode(ByVal inField As String, ByVal Changed As System.Windows.Forms.ComboBox, ByVal ToChange As System.Windows.Forms.ComboBox)
        If inField.Equals("WANG") Then
            If WangLikeness.ContainsKey(Changed.Text) AndAlso ToChange.Items.Contains(WangLikeness(Changed.Text)) Then
                ToChange.SelectedIndex = ToChange.Items.IndexOf(WangLikeness(Changed.Text))
            Else
                ToChange.SelectedIndex = -1
            End If
        Else
            If ToolLikeness.ContainsKey(Changed.Text) AndAlso ToChange.Items.Contains(ToolLikeness(Changed.Text)) Then
                ToChange.SelectedIndex = ToChange.Items.IndexOf(ToolLikeness(Changed.Text))
            Else
                ToChange.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub cboAddInventoryToolType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddInventoryToolType.SelectedIndexChanged
        SelectLikeCode("TOOL", cboAddInventoryToolType, cboAddInventoryWangType)
    End Sub

    Private Sub cboToolType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboToolType.SelectedIndexChanged
        SelectLikeCode("TOOL", cboToolType, cboWangType)
    End Sub

    Private Sub cboWangType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWangType.SelectedIndexChanged
        SelectLikeCode("WANG", cboWangType, cboToolType)
    End Sub

End Class
