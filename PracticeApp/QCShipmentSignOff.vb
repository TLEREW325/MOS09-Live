Imports System.Data.SqlClient

Public Class QCShipmentSignOff
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim isLoaded As Boolean = False
    Dim pass As New PasswordEntry()

    Public Sub New()
        InitializeComponent()

        lblUser.Text = EmployeeLoginName
        LoadPickTickets()
        isLoaded = True
    End Sub

    Private Sub LoadPickTickets()
        Dim cmd As New SqlCommand("SELECT ShipmentHeaderTable.ShipmentNumber, ShipmentHeaderTable.SalesOrderKey, ShipmentHeaderTable.PickTicketNumber, ShipmentHeaderTable.CustomerID, CustomerList.CustomerName FROM ShipmentHeaderTable LEFT OUTER JOIN CustomerList ON ShipmentHeaderTable.CustomerID = CustomerList.CustomerID AND ShipmentHeaderTable.DivisionID = CustomerList.DivisionID WHERE ShipmentHeaderTable.DivisionID = 'TFP' AND ShipmentStatus = 'PENDING' AND (QCSignOffUser = '' OR QCSignOffUser is null);", con)

        Dim dt As New Data.DataTable("ShipmentHeaderTable")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboPickTicketNumber.DisplayMember = "PickTicketNumber"
        cboPickTicketNumber.DataSource = dt
        cboPickTicketNumber.SelectedIndex = -1
    End Sub

    Private Sub cboPickTicketNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPickTicketNumber.SelectedIndexChanged
        If isLoaded Then
            Dim dt As Data.DataTable = CType(cboPickTicketNumber.DataSource, Data.DataTable)
            lblCustomerID.Text = dt.Rows(cboPickTicketNumber.SelectedIndex).Item("CustomerID")
            lblCustomerName.Text = dt.Rows(cboPickTicketNumber.SelectedIndex).Item("CustomerName")
            lblShipmentNumber.Text = dt.Rows(cboPickTicketNumber.SelectedIndex).Item("ShipmentNumber").ToString
            lblSalesOrderNumber.Text = dt.Rows(cboPickTicketNumber.SelectedIndex).Item("SalesOrderKey").ToString
        End If
    End Sub


    Private Sub cmdSignOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSignOff.Click
        If CanSignOff() Then
            Dim cmd As New SqlCommand("UPDATE ShipmentHeaderTable SET QCSignOffUser = @QCSignOffUser, QCSignOffDate = CURRENT_TIMESTAMP WHERE ShipmentNumber = @ShipmentNumber", con)
            If pass.txtUserName.Visible Then
                cmd.Parameters.Add("@QCSignOffUser", SqlDbType.VarChar).Value = pass.txtUserName.Text.ToUpper
            Else
                cmd.Parameters.Add("@QCSignOffUser", SqlDbType.VarChar).Value = pass.lblCurrentUser.Text
            End If

            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.Int).Value = Val(lblShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            isLoaded = False
            LoadPickTickets()
            isLoaded = True
            ClearData()
        End If
    End Sub

    Private Function CanSignOff() As Boolean
        If String.IsNullOrEmpty(cboPickTicketNumber.Text) Then
            MessageBox.Show("You must enter a Pick ticket", "Enter a pick ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPickTicketNumber.Focus()
            Return False
        End If
        If cboPickTicketNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid pick ticket", "Enter a valid pcik ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPickTicketNumber.SelectAll()
            cboPickTicketNumber.Focus()
            Return False
        End If
        pass = New PasswordEntry()
        If pass.ShowDialog() <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub ClearData()
        Dim tempIsLoaded As Boolean = isLoaded
        isLoaded = False
        cboPickTicketNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboPickTicketNumber.Text) Then
            cboPickTicketNumber.Text = ""
        End If
        lblCustomerID.Text = ""
        lblCustomerName.Text = ""
        lblSalesOrderNumber.Text = ""
        lblShipmentNumber.Text = ""
        cboPickTicketNumber.Focus()
        isLoaded = tempIsLoaded
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class