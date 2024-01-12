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
Public Class CertificationSpec
    Inherits System.Windows.Forms.Form

    Dim Description, BottomLineSpec, MaterialSpec, ManufacturingSpec As String
    Dim MinTensile, MinYield, MaxTensile, MaxYield, ROAPercent, ElongationPercent As Double
    Dim AuditComment As String = ""
    Dim AuditCertCode As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub LoadCertCode()
        ''Query will order the certifications properly from 0 to whatever number unless its not a number then those wil lbe at the end
        cmd = New SqlCommand("SELECT * FROM CertificationType ORDER BY (CASE WHEN ISNUMERIC( CertificationCode) <> 1 then 9999 else CAST(CertificationCode as int) END)", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CertificationType")
        cboCertCode.DataSource = ds.Tables("CertificationType")
        cboCertType.DataSource = ds.Tables("CertificationType")
        con.Close()
        cboCertCode.SelectedIndex = -1
        cboCertType.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboCertCode.SelectedIndex = -1
        cboCertType.SelectedIndex = -1

        txtBottomLineSpec.Clear()
        txtLongDescription.Clear()
        txtMaterialSpec.Clear()
        txtManufacturingSpec.Clear()
        txtElongation.Clear()
        txtMinTensile.Clear()
        txtMinYield.Clear()
        txtReduction.Clear()
        txtMaxTensile.Clear()
        txtMaxYield.Clear()

        cboCertCode.Focus()
    End Sub

    Public Sub ClearVariables()
        Description = ""
        BottomLineSpec = ""
        MaterialSpec = ""
        ManufacturingSpec = ""
        MinTensile = 0
        MinYield = 0
        ROAPercent = 0
        ElongationPercent = 0
        MaxTensile = 0
        MaxYield = 0
    End Sub

    Public Sub UpdateAuditTrail()
        'Write To Audit Trail
        AuditCertCode = ""

        Try
            'Create Entry
            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

            With cmd.Parameters
                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@AuditType", SqlDbType.VarChar).Value = "CERT FORM - Log changes on cert data"
                .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = AuditCertCode
                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            AuditComment = ""
            AuditCertCode = ""
        Catch ex As Exception
            'Skip
        End Try
    End Sub

    Public Sub ValidateChanges()
        Dim OldDescription, OldMaterialSpec, OldBottomLineSpec, OldManufacturingSpec As String
        Dim OldMinTensile, OldMinYield, OldMaxTensile, OldMaxYield, OldElongationPercent, OldROAPercent As Double

        Dim DescriptionStatement As String = "SELECT Description FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaterialSpecStatement As String = "SELECT MaterialSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaterialSpecCommand As New SqlCommand(MaterialSpecStatement, con)
        MaterialSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim BottomLineSpecStatement As String = "SELECT BottomLineSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim BottomLineSpecCommand As New SqlCommand(BottomLineSpecStatement, con)
        BottomLineSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ManufacturingSpecStatement As String = "SELECT ManufacturingSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ManufacturingSpecCommand As New SqlCommand(ManufacturingSpecStatement, con)
        ManufacturingSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MinTensileStatement As String = "SELECT MinTensile FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MinTensileCommand As New SqlCommand(MinTensileStatement, con)
        MinTensileCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MinYieldStatement As String = "SELECT MinYield FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MinYieldCommand As New SqlCommand(MinYieldStatement, con)
        MinYieldCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ElongationStatement As String = "SELECT ElongationPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ElongationCommand As New SqlCommand(ElongationStatement, con)
        ElongationCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ReductionStatement As String = "SELECT ROAPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ReductionCommand As New SqlCommand(ReductionStatement, con)
        ReductionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaxTensileStatement As String = "SELECT MaxTensile FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaxTensileCommand As New SqlCommand(MaxTensileStatement, con)
        MaxTensileCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaxYieldStatement As String = "SELECT MaxYield FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaxYieldCommand As New SqlCommand(MaxYieldStatement, con)
        MaxYieldCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OldDescription = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            OldDescription = ""
        End Try
        Try
            OldMaterialSpec = CStr(MaterialSpecCommand.ExecuteScalar)
        Catch ex As Exception
            OldMaterialSpec = ""
        End Try
        Try
            OldBottomLineSpec = CStr(BottomLineSpecCommand.ExecuteScalar)
        Catch ex As Exception
            OldBottomLineSpec = ""
        End Try
        Try
            OldManufacturingSpec = CStr(ManufacturingSpecCommand.ExecuteScalar)
        Catch ex As Exception
            OldManufacturingSpec = ""
        End Try
        Try
            OldMinTensile = CDbl(MinTensileCommand.ExecuteScalar)
        Catch ex As Exception
            OldMinTensile = 0
        End Try
        Try
            OldMinYield = CDbl(MinYieldCommand.ExecuteScalar)
        Catch ex As Exception
            OldMinYield = 0
        End Try
        Try
            OldElongationPercent = CDbl(ElongationCommand.ExecuteScalar)
        Catch ex As Exception
            OldElongationPercent = 0
        End Try
        Try
            OldROAPercent = CDbl(ReductionCommand.ExecuteScalar)
        Catch ex As Exception
            OldROAPercent = 0
        End Try
        Try
            OldMaxTensile = CDbl(MaxTensileCommand.ExecuteScalar)
        Catch ex As Exception
            OldMaxTensile = 0
        End Try
        Try
            OldMaxYield = CDbl(MaxYieldCommand.ExecuteScalar)
        Catch ex As Exception
            OldMaxYield = 0
        End Try
        con.Close()

        'Compare New Values to Old and mark changes in the Audit Trail Table
        If OldDescription = txtLongDescription.Text Then
            'Skip
        Else
            AuditComment = "Description changed to " + txtLongDescription.Text + " from " + OldDescription

            UpdateAuditTrail()
        End If
        If OldMaterialSpec = txtMaterialSpec.Text Then
            'Skip
        Else
            AuditComment = "Material Spec changed to " + txtMaterialSpec.Text + " from " + OldMaterialSpec

            UpdateAuditTrail()
        End If
        If OldBottomLineSpec = txtBottomLineSpec.Text Then
            'Skip
        Else
            AuditComment = "Bottom Line Spec changed to " + txtBottomLineSpec.Text + " from " + OldBottomLineSpec

            UpdateAuditTrail()
        End If
        If OldManufacturingSpec = txtManufacturingSpec.Text Then
            'Skip
        Else
            AuditComment = "Manufacturing Spec changed to " + txtManufacturingSpec.Text + " from " + OldManufacturingSpec

            UpdateAuditTrail()
        End If
        If OldMinTensile = txtMinTensile.Text Then
            'Skip
        Else
            AuditComment = "Min Tensile # changed to " + txtMinTensile.Text + " from " + CStr(OldMinTensile)

            UpdateAuditTrail()
        End If
        If OldMinYield = txtMinYield.Text Then
            'Skip
        Else
            AuditComment = "Min Yield changed to " + txtMinYield.Text + " from " + CStr(OldMinYield)

            UpdateAuditTrail()
        End If
        If OldElongationPercent = txtElongation.Text Then
            'Skip
        Else
            AuditComment = "Elongation Percent changed to " + txtElongation.Text + " from " + CStr(OldElongationPercent)

            UpdateAuditTrail()
        End If
        If OldROAPercent = txtReduction.Text Then
            'Skip
        Else
            AuditComment = "ROA Percent changed to " + txtReduction.Text + " from " + CStr(OldROAPercent)

            UpdateAuditTrail()
        End If

        'Clear variables
        OldDescription = ""
        OldBottomLineSpec = ""
        OldManufacturingSpec = ""
        OldMaterialSpec = ""
        OldElongationPercent = 0
        OldMinTensile = 0
        OldMinYield = 0
        OldROAPercent = 0
    End Sub

    Public Sub LoadCertificationData()
        Dim DescriptionStatement As String = "SELECT Description FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaterialSpecStatement As String = "SELECT MaterialSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaterialSpecCommand As New SqlCommand(MaterialSpecStatement, con)
        MaterialSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim BottomLineSpecStatement As String = "SELECT BottomLineSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim BottomLineSpecCommand As New SqlCommand(BottomLineSpecStatement, con)
        BottomLineSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ManufacturingSpecStatement As String = "SELECT ManufacturingSpec FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ManufacturingSpecCommand As New SqlCommand(ManufacturingSpecStatement, con)
        ManufacturingSpecCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MinTensileStatement As String = "SELECT MinTensile FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MinTensileCommand As New SqlCommand(MinTensileStatement, con)
        MinTensileCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MinYieldStatement As String = "SELECT MinYield FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MinYieldCommand As New SqlCommand(MinYieldStatement, con)
        MinYieldCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ElongationStatement As String = "SELECT ElongationPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ElongationCommand As New SqlCommand(ElongationStatement, con)
        ElongationCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim ReductionStatement As String = "SELECT ROAPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim ReductionCommand As New SqlCommand(ReductionStatement, con)
        ReductionCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaxTensileStatement As String = "SELECT MaxTensile FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaxTensileCommand As New SqlCommand(MaxTensileStatement, con)
        MaxTensileCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        Dim MaxYieldStatement As String = "SELECT MaxYield FROM CertificationType WHERE CertificationCode = @CertificationCode"
        Dim MaxYieldCommand As New SqlCommand(MaxYieldStatement, con)
        MaxYieldCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Description = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            Description = ""
        End Try
        Try
            MaterialSpec = CStr(MaterialSpecCommand.ExecuteScalar)
        Catch ex As Exception
            MaterialSpec = ""
        End Try
        Try
            BottomLineSpec = CStr(BottomLineSpecCommand.ExecuteScalar)
        Catch ex As Exception
            BottomLineSpec = ""
        End Try
        Try
            ManufacturingSpec = CStr(ManufacturingSpecCommand.ExecuteScalar)
        Catch ex As Exception
            ManufacturingSpec = ""
        End Try
        Try
            MinTensile = CDbl(MinTensileCommand.ExecuteScalar)
        Catch ex As Exception
            MinTensile = 0
        End Try
        Try
            MinYield = CDbl(MinYieldCommand.ExecuteScalar)
        Catch ex As Exception
            MinYield = 0
        End Try
        Try
            ElongationPercent = CDbl(ElongationCommand.ExecuteScalar)
        Catch ex As Exception
            ElongationPercent = 0
        End Try
        Try
            ROAPercent = CDbl(ReductionCommand.ExecuteScalar)
        Catch ex As Exception
            ROAPercent = 0
        End Try
        Try
            MaxTensile = CDbl(MaxTensileCommand.ExecuteScalar)
        Catch ex As Exception
            MaxTensile = 0
        End Try
        Try
            MaxYield = CDbl(MaxYieldCommand.ExecuteScalar)
        Catch ex As Exception
            MaxYield = 0
        End Try
        con.Close()

        txtBottomLineSpec.Text = BottomLineSpec
        txtMaterialSpec.Text = MaterialSpec
        txtLongDescription.Text = Description
        txtManufacturingSpec.Text = ManufacturingSpec

        txtElongation.Text = ElongationPercent
        txtReduction.Text = ROAPercent
        txtMinTensile.Text = MinTensile
        txtMinYield.Text = MinYield
        txtMaxTensile.Text = MaxTensile
        txtMaxYield.Text = MaxYield
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboCertCode.Text = "" Then
            MsgBox("You must have a valid Cert Code selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Try to insert new record
                cmd = New SqlCommand("Insert Into CertificationType(CertificationCode, CertificationType, Description, MaterialSpec, BottomLineSpec, ManufacturingSpec, MinYield, MinTensile, ElongationPercent, ROAPercent, MaxYield, MaxTensile) Values(@CertificationCode, @CertificationType, @Description, @MaterialSpec, @BottomLineSpec, @ManufacturingSpec, @MinYield, @MinTensile, @ElongationPercent, @ROAPercent, @MaxYield, @MaxTensile)", con)

                With cmd.Parameters
                    .Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text
                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertType.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtLongDescription.Text
                    .Add("@MaterialSpec", SqlDbType.VarChar).Value = txtMaterialSpec.Text
                    .Add("@BottomLineSpec", SqlDbType.VarChar).Value = txtBottomLineSpec.Text
                    .Add("@ManufacturingSpec", SqlDbType.VarChar).Value = txtManufacturingSpec.Text
                    .Add("@MinYield", SqlDbType.VarChar).Value = Val(txtMinYield.Text)
                    .Add("@MinTensile", SqlDbType.VarChar).Value = Val(txtMinTensile.Text)
                    .Add("@ElongationPercent", SqlDbType.VarChar).Value = Val(txtElongation.Text)
                    .Add("@ROAPercent", SqlDbType.VarChar).Value = Val(txtReduction.Text)
                    .Add("@MaxYield", SqlDbType.VarChar).Value = Val(txtMaxYield.Text)
                    .Add("@MaxTensile", SqlDbType.VarChar).Value = Val(txtMaxTensile.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log Changes
                ValidateChanges()

                'Update 
                cmd = New SqlCommand("UPDATE CertificationType SET CertificationType = @CertificationType, Description = @Description, MaterialSpec = @MaterialSpec, BottomLineSpec = @BottomLineSpec, ManufacturingSpec = @ManufacturingSpec, MinYield = @MinYield, MinTensile = @MinTensile, ElongationPercent = @ElongationPercent, ROAPercent = @ROAPercent, MaxYield = @MaxYield, MaxTensile = @MaxTensile WHERE CertificationCode = @CertificationCode", con)

                With cmd.Parameters
                    .Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text
                    .Add("@CertificationType", SqlDbType.VarChar).Value = cboCertType.Text
                    .Add("@Description", SqlDbType.VarChar).Value = txtLongDescription.Text
                    .Add("@MaterialSpec", SqlDbType.VarChar).Value = txtMaterialSpec.Text
                    .Add("@BottomLineSpec", SqlDbType.VarChar).Value = txtBottomLineSpec.Text
                    .Add("@ManufacturingSpec", SqlDbType.VarChar).Value = txtManufacturingSpec.Text
                    .Add("@MinYield", SqlDbType.VarChar).Value = Val(txtMinYield.Text)
                    .Add("@MinTensile", SqlDbType.VarChar).Value = Val(txtMinTensile.Text)
                    .Add("@ElongationPercent", SqlDbType.VarChar).Value = Val(txtElongation.Text)
                    .Add("@ROAPercent", SqlDbType.VarChar).Value = Val(txtReduction.Text)
                    .Add("@MaxYield", SqlDbType.VarChar).Value = Val(txtMaxYield.Text)
                    .Add("@MaxTensile", SqlDbType.VarChar).Value = Val(txtMaxTensile.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            MsgBox("Certification Data has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim button1 As DialogResult = MessageBox.Show("Are you sure you wish to delete this certification spec", "DELETE SPEC", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        If button1 = DialogResult.Yes Then
            'Update existing record
            cmd = New SqlCommand("DELETE FROM CertificationType WHERE CertificationCode = @CertificationCode", con)

            With cmd.Parameters
                .Add("@CertificationCode", SqlDbType.VarChar).Value = cboCertCode.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearVariables()
            ClearData()
        ElseIf button1 = DialogResult.No Then
            cboCertCode.Focus()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim newPrintCertificationSpecification As New PrintCertificationSpecifications()
        newPrintCertificationSpecification.ShowDialog()
    End Sub

    Private Sub cboCertCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCertCode.SelectedIndexChanged
        LoadCertificationData()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub CertificationSpec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'usefulFunctions.LoadSecurity(Me)

        LoadCertCode()
        ClearVariables()
        ClearData()
    End Sub
End Class