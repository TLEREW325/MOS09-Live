Imports System.Data.SqlClient

Public Class QCNonConformanceAddLot
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim LotList As New AutoCompleteStringCollection()
    Dim PNCNumber As Integer = 0
    Public Sub New()
        InitializeComponent()

        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    LotList.Add(reader.Item("LotNumber"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
        txtlotNumber.AutoCompleteCustomSource = LotList
        Me.AcceptButton = cmdAdd
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        PNCNumber = 0
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
        txtlotNumber.Clear()
        txtlotNumber.Focus()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If canAddLot() Then
            cmd = New SqlCommand("DECLARE @FOXNumber as int = (CASE WHEN EXISTS(SELECT isnull(FOXNumber, 0) FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber) THEN (SELECT isnull(FOXNumber, 0) FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber) ELSE (SELECT 0) END); IF (@FOXNumber <> (CASE WHEN EXISTS(SELECT isnull(FOXNumber, 0) FROM LotNumber WHERE LotNumber = @LotNumber) THEN (SELECT isnull(FOXNumber, 0) FROM LotNumber WHERE LotNumber = @LotNumber) ELSE (SELECT 0) END) AND @FOXNumber <> 0) select 'NO MATCH' ELSE SELECT 'MATCH'", con)
            cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = PNCNumber
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtlotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            If cmd.ExecuteScalar().ToString.Equals("MATCH") Then
                cmd.CommandText = "IF NOT EXISTS(SELECT LotNumber FROM QCHoldAdjustmentLotNumber WHERE QCTransactionNumber = @QCTransactionNumber AND LotNumber = @LotNumber) INSERT INTO QCHoldAdjustmentLotNumber (QCTransactionNumber, LotNumber) VALUES (@QCTransactionNumber, @LotNumber);"
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteScalar()
            Else
                MessageBox.Show("Lot number entered does not have the same FOX as the QC Hold. Only lot numbers with the same FOX can be added.", "Unable to add Lot", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If con.State = ConnectionState.Open Then con.Close()
            PNCNumber = 0
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
        txtlotNumber.Clear()
        txtlotNumber.Focus()
    End Sub

    Private Function canAddLot() As Boolean
        If PNCNumber = 0 Then
            Return False
        End If
        If String.IsNullOrEmpty(txtlotNumber.Text) Then
            Return False
        End If
        If Val(txtlotNumber.Text) = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub txtlotNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlotNumber.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Public Sub SetPNC(ByVal pnc As Integer)
        PNCNumber = pnc
    End Sub
End Class