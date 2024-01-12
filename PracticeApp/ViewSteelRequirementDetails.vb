Imports System.Data.SqlClient

Public Class ViewSteelRequirementDetails
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Public Sub New()
        InitializeComponent()
        LoadFormatting()
    End Sub
    ''initializes with starting value
    Public Sub New(ByVal rmd As String)
        InitializeComponent()

        cmd = New SqlCommand("SELECT SalesOrderHeaderTable.SalesOrderKey, SalesORderHeaderTable.SalesOrderDate, SalesOrderHeaderTable.CustomerID, SteelCommittedToFOXStage1TFP.FOXNumber,  CEILING(SteelCommittedToFOXStage1TFP.SteelCommittedToFOX) as SteelCommitted, isnull(CEILING(CASE WHEN ADMInventoryTotal.QuantityOnHand < 0 THEN 0 ELSE ADMInventoryTotal.QuantityOnHand END / 1000 * SteelCommittedToFOXStage1TFP.RawMaterialWeight), 0) as PoundsOnHand, FOXTable.PartNumber FROM SteelCommittedToFOXStage1TFP INNER JOIN SalesOrderHeaderTable ON SteelCommittedToFOXStage1TFP.SalesOrderKey = SalesOrderHeaderTable.SalesOrderKey LEFT OUTER JOIN FOXTable ON SteelCommittedToFoxStage1TFP.FOXNumber = FOXTable.FOXNumber LEFT OUTER JOIN ADMInventoryTotal ON SteelCommittedToFOXStage1TFP.ItemID = ADMInventoryTotal.ItemID WHERE SteelCommittedToFoxStage1TFP.RMID = @RMID" _
                             + " UNION ALL SELECT SteelCommittedToFOXStage1TWD.SalesOrderKey, SteelCommittedToFOXStage1TWD.SalesOrderDate, SalesOrderHeaderTable.CustomerID, SteelCommittedToFoxStage1TWD.FOXNumber, CEILING(SteelCommittedToFOX), CEILING(CASE WHEN PoundsOnHand < 0 then 0 ELSE PoundsOnHand END), FOXTable.PartNumber FROM SteelCommittedToFOXStage1TWD INNER JOIN SalesOrderHeaderTable ON SteelCommittedToFOXStage1TWD.SalesOrderKey = SalesOrderHeaderTable.SalesOrderKey LEFT OUTER JOIN FOXTable ON SteelCommittedToFoxStage1TWD.FOXNumber = FOXTable.FOXNumber WHERE SteelCommittedToFoxStage1TWD.RMID = @RMID AND SteelCommittedToFOX > 0 ORDER BY SalesOrderDate", con)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = rmd
        Dim cmd1 As New SqlCommand("SELECT CASE WHEN isnull(CEILING(SUM(WIPWeight)), 0) < 0 then 0 else isnull(CEILING(SUM(WIPWeight)), 0) END  as WIPWeight FROM (SELECT TimeslipLineItemTable.FOXNumber, FOXTable.RMID, TimeSlipLineItemTable.PartNumber, CEILING(SUM(CASE WHEN TimeSlipLineItemTable.InventoryPieces = TimeSlipLineItemTable.PiecesProduced THEN (-1 * TimeSlipLineItemTable.InventoryPieces) ELSE TimeSlipLineItemTable.PiecesProduced END) * MAX(FOXTable.RawMaterialWeight / 1000)) as WIPWeight, MAX(ADMInventoryTotal.OpenSOQuantity) as OpenSOQuantity, MAX(FOXTable.RawMaterialWeight / 1000) as PieceWeight FROM TimeSlipLineItemTable INNER JOIN ADMInventoryTotal ON TimeSlipLineItemTable.PartNumber = ADMInventoryTotal.ItemID and TimeSlipLineItemTable.DivisionID = ADMInventoryTotal.DivisionID INNER JOIN FOXTable ON TimeSlipLineItemTable.FOXNumber = FOXtable.FOXNumber WHERE (TimeSlipLineItemTable.FOXStep = 1 OR TimeSlipLineItemTable.InventoryPieces <> 0) AND FOXTable.Status <> 'INACTIVE' AND FOXTable.DivisionID = 'TFP' AND TimeSlipLineItemTable.PartNumber = @PartNumber GROUP BY TimeSlipLineItemTable.FOXNumber, FOXTable.RMID, TimeSlipLineItemTable.PartNumber) as tmp GROUP BY PartNumber", con)
        cmd1.Parameters.Add("@PartNumber", SqlDbType.VarChar)
        Dim myAdapter As New SqlDataAdapter(cmd)
        Dim dt As New Data.DataTable("SalesOrderQuantities")
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        'Dim QOHList As New Dictionary(Of String, Integer)
        'If dt.Rows.Count > 0 Then
        '    Dim i As Integer = 0
        '    While i < dt.Rows.Count
        '        Dim removed As Boolean = False
        '        If Not QOHList.ContainsKey(dt.Rows(i).Item("PartNumber")) Then
        '            QOHList.Add(dt.Rows(i).Item("PartNumber"), dt.Rows(i).Item("PoundsOnHand"))
        '            cmd1.Parameters("@PartNumber").Value = dt.Rows(i).Item("PartNumber")
        '            If con.State = ConnectionState.Closed Then con.Open()
        '            Dim obj As Object = cmd1.ExecuteScalar()
        '            If obj IsNot Nothing AndAlso obj > 0 Then
        '                QOHList(dt.Rows(i).Item("PartNumber")) += obj
        '            End If

        '        End If
        '        If QOHList(dt.Rows(i).Item("PartNumber")) > 0 Then
        '            dt.Rows(i).Item("SteelCommitted") -= QOHList(dt.Rows(i).Item("PartNumber"))
        '            If dt.Rows(i).Item("SteelCommitted") > 0 Then
        '                QOHList(dt.Rows(i).Item("PartNumber")) = 0
        '            Else
        '                QOHList(dt.Rows(i).Item("PartNumber")) = Math.Abs(dt.Rows(i).Item("SteelCommitted"))
        '                dt.Rows.RemoveAt(i)
        '                removed = True
        '            End If
        '        End If
        '        If Not removed Then
        '            i += 1
        '        End If
        '    End While
        'End If
        con.Close()

        dgvSteelReqDetails.DataSource = dt
        dgvSteelReqDetails.Columns("SalesOrderKey").HeaderText = "Order #"
        dgvSteelReqDetails.Columns("SalesOrderDate").HeaderText = "Order Date"
        dgvSteelReqDetails.Columns("FOXNumber").HeaderText = "FOX Number"
        dgvSteelReqDetails.Columns("FOXNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSteelReqDetails.Columns("SteelCommitted").HeaderText = "Committed Qty (lbs)"
        dgvSteelReqDetails.Columns("SteelCommitted").DefaultCellStyle.Format = "N0"
        dgvSteelReqDetails.Columns("SteelCommitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSteelReqDetails.Columns("PoundsOnHand").HeaderText = "QOH (lbs)"
        dgvSteelReqDetails.Columns("PoundsOnHand").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSteelReqDetails.Columns("PoundsOnHand").Visible = True
        dgvSteelReqDetails.Columns("PartNumber").HeaderText = "Part #"
        dgvSteelReqDetails.Columns("PartNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSteelReqDetails.Columns("PartNumber").Visible = True

        LoadFormatting()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Public Sub LoadFormatting()
        Dim PoundsOnHand, SteelCommitted As Double
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvSteelReqDetails.Rows
            Try
                PoundsOnHand = row.Cells("PoundsOnHand").Value
            Catch ex As System.Exception
                PoundsOnHand = 0
            End Try
            Try
                SteelCommitted = row.Cells("SteelCommitted").Value
            Catch ex As System.Exception
                SteelCommitted = 0
            End Try

            If PoundsOnHand > SteelCommitted Then
                Me.dgvSteelReqDetails.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvSteelReqDetails.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            Else
                Me.dgvSteelReqDetails.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSteelReqDetails.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub dgvSteelReqDetails_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSteelReqDetails.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub ViewSteelRequirementDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFormatting()
    End Sub
End Class
