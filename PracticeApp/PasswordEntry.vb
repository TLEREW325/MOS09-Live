Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PasswordEntry

    Public Sub New(Optional ByVal chooseUser As Boolean = False)
        InitializeComponent()

        If chooseUser Then
            lblUserName.Text = "Username"
            txtUserName.Show()
            lblCurrentUser.Hide()
        Else
            lblCurrentUser.Text = EmployeeLoginName
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("IF (SELECT COUNT(LoginPassword) FROM EmployeeData WHERE LoginName = @LoginName AND LoginPassword = @LoginPassword) > 0 SELECT 'VALID' ELSE SELECT 'INVALID'", con)
        If txtUserName.Visible Then
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = txtUserName.Text
        Else
            cmd.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = lblCurrentUser.Text
        End If

        cmd.Parameters.Add("@LoginPassword", SqlDbType.VarChar).Value = txtPassword.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar.ToString.Equals("INVALID") Then
            If txtUserName.Visible Then
                MessageBox.Show("Incorrect username/password.", "Enter correct username/password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Entered password is incorrect for the current user.", "Enter correct password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            txtPassword.SelectAll()
            txtPassword.Focus()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class