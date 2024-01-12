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
Imports Microsoft.Office.Interop.Outlook

Public Class PrintCorrectivePreventiceActionReport
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, SalespersonFilter, SalesTerritoryFilter, DateFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As System.Data.DataTable
    Dim teamDetails As String = ""

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim LastTransactionNumber, NextTransactionNumber, counter As Integer
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application


    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'Runs Validation Checks 
        If Validation() Then
            'Pulls in the Short Description based on the part number
            Dim datestatement As String = "SELECT ShortDescription FROM ItemList Where ItemID =@Value1"
            Dim partDesc As String

            Dim MAXCommand As New SqlCommand(datestatement, con)
            MAXCommand.Parameters.Add("@Value1", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            'Makes the check to see if the description exists and if it does not, then displays NOT AVAILABLE.
            Try
                partDesc = MAXCommand.ExecuteScalar
            Catch ex As System.Exception
                partDesc = "NOT AVAILABLE"
            End Try
            con.Close()

            MyReport = CRXCorrectiveActionForm1
            Dim parameter As String
            Dim CarNum1, CarNum2 As String

            'Splits the CAR number into correct format
            If cboCARNum.Text.Length = 4 Then
                Try
                    CarNum1 = cboCARNum.Text.Substring(0, 2)
                    CarNum2 = cboCARNum.Text.Substring(2, 2)
                Catch ex As System.Exception
                    CarNum1 = "N/A"
                    CarNum2 = "ERROR"
                End Try
            Else
                Try
                    CarNum1 = "0" & cboCARNum.Text.Substring(0, 1)
                    CarNum2 = cboCARNum.Text.Substring(1, 2)
                Catch ex As System.Exception
                    CarNum1 = "N/A"
                    CarNum2 = "ERROR"
                End Try
            End If
            ''Fills parameters with the variables saved locally
            parameter = CarNum1 + "-" + CarNum2
            CRXCorrectiveActionForm1.SetParameterValue("CARNum", parameter)
            parameter = cboCustomer.Text
            CRXCorrectiveActionForm1.SetParameterValue("Customer", parameter)
            parameter = cboPartNumber.Text
            CRXCorrectiveActionForm1.SetParameterValue("PartNumber", parameter)
            parameter = cboSupplier.Text
            CRXCorrectiveActionForm1.SetParameterValue("Supplier", parameter)

            'Attempts to insert the parts description into the crystal report
            Try
                parameter = partDesc
                CRXCorrectiveActionForm1.SetParameterValue("PartName", parameter)
            Catch ex As System.Exception
                parameter = "Error With Part Number"
                CRXCorrectiveActionForm1.SetParameterValue("PartName", parameter)
            End Try

            parameter = dtpDateOpened.Text
            CRXCorrectiveActionForm1.SetParameterValue("DateOpened", parameter)
            parameter = teamDetails
            CRXCorrectiveActionForm1.SetParameterValue("TeamDetails", parameter)
            parameter = dtpOccuranceDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("DateOfOccurrence", parameter)
            parameter = rchProblemDef.Text
            CRXCorrectiveActionForm1.SetParameterValue("ProblemDefinition", parameter)
            parameter = rchContainmentAction.Text
            CRXCorrectiveActionForm1.SetParameterValue("ContainmentActions", parameter)
            parameter = dtpContainImpDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("ContainmentActionDates", parameter)
            parameter = rchRoot.Text
            CRXCorrectiveActionForm1.SetParameterValue("RootCause", parameter)
            parameter = rchInterimCorrect.Text
            CRXCorrectiveActionForm1.SetParameterValue("ChosenInterimCorrectiveAction", parameter)
            parameter = dtpVerifyDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("ChosenInterimActionDate", parameter)
            parameter = rchPermCorrAction.Text
            CRXCorrectiveActionForm1.SetParameterValue("ChosenPermanentCorrectiveAction", parameter)
            parameter = dtpImpPermActionDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("ChosenPermanentDate", parameter)
            parameter = rchActionToPreventReccurr.Text
            CRXCorrectiveActionForm1.SetParameterValue("ActionToPreventRecurrence", parameter)
            parameter = dtpActionToPreventDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("ActionDate", parameter)
            parameter = cboReviewModifyCreate.Text
            CRXCorrectiveActionForm1.SetParameterValue("ReviewModifyCreate", parameter)
            parameter = cboProductChanged.Text
            CRXCorrectiveActionForm1.SetParameterValue("ProcessChange", parameter)
            parameter = dtpdateofAudit.Text
            CRXCorrectiveActionForm1.SetParameterValue("ProcessChangeYes", parameter)
            parameter = txtNameOfAuditor.Text
            CRXCorrectiveActionForm1.SetParameterValue("ProcessAuditor", parameter)
            parameter = rchVerification.Text
            CRXCorrectiveActionForm1.SetParameterValue("Verification", parameter)
            parameter = cboVerifiedBy.Text
            CRXCorrectiveActionForm1.SetParameterValue("VerifiedBy", parameter)
            parameter = dtpCloseDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("VerifyDate", parameter)
            parameter = dtpStatusCARDate.Text
            CRXCorrectiveActionForm1.SetParameterValue("CarStatus", parameter)
            parameter = cboOpenClosed.Text
            CRXCorrectiveActionForm1.SetParameterValue("CAROpenClose", parameter)
            parameter = txtReportedBy.Text
            CRXCorrectiveActionForm1.SetParameterValue("ReportedBy", parameter)
            parameter = txtNameOf.Text
            CRXCorrectiveActionForm1.SetParameterValue("NameAtBot", parameter)
            parameter = txtDept.Text
            CRXCorrectiveActionForm1.SetParameterValue("Department", parameter)
            parameter = txtChampion.Text
            CRXCorrectiveActionForm1.SetParameterValue("Champ", parameter)

            CRXCorrectiveActionForm1 = MyReport
            CRCustomerYTDViewer.ReportSource = CRXCorrectiveActionForm1
            con.Close()
        End If
    End Sub

    Private Sub CRCustomerYTDViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRCustomerYTDViewer.Load
        Dim datestatement As String = "SELECT ShortDescription FROM ItemList Where ItemID = @Value1"
        Dim partDesc As String = "N/A"

        'Dim MAXCommand As New SqlCommand(datestatement, con)
        'MAXCommand.Parameters.Add("@Value1", SqlDbType.VarChar).Value = cboPartNumber.Text

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        'partDesc = MAXCommand.ExecuteScalar
        'Catch ex As System.Exception
        'partDesc = " "
        'End Try
        'con.Close()

        MyReport = CRXCorrectiveActionForm1
        Dim parameter As String

        ''Fills parameters with the variables saved locally
        parameter = cboCARNum.Text
        CRXCorrectiveActionForm1.SetParameterValue("CARNum", parameter)
        parameter = cboCustomer.Text
        CRXCorrectiveActionForm1.SetParameterValue("Customer", parameter)
        parameter = cboPartNumber.Text
        CRXCorrectiveActionForm1.SetParameterValue("PartNumber", parameter)
        parameter = cboPartNumber.Text
        CRXCorrectiveActionForm1.SetParameterValue("Supplier", parameter)
        parameter = partDesc
        CRXCorrectiveActionForm1.SetParameterValue("PartName", parameter)
        parameter = " "
        CRXCorrectiveActionForm1.SetParameterValue("Supplier2", parameter)
        parameter = dtpDateOpened.Text
        CRXCorrectiveActionForm1.SetParameterValue("DateOpened", parameter)
        parameter = teamDetails
        CRXCorrectiveActionForm1.SetParameterValue("TeamDetails", parameter)
        parameter = lblDateofOccurrence.Text
        CRXCorrectiveActionForm1.SetParameterValue("DateOfOccurrence", parameter)
        parameter = rchProblemDef.Text
        CRXCorrectiveActionForm1.SetParameterValue("ProblemDefinition", parameter)
        parameter = rchContainmentAction.Text
        CRXCorrectiveActionForm1.SetParameterValue("ContainmentActions", parameter)
        parameter = dtpContainImpDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("ContainmentActionDates", parameter)
        parameter = rchRoot.Text
        CRXCorrectiveActionForm1.SetParameterValue("RootCause", parameter)
        parameter = rchInterimCorrect.Text
        CRXCorrectiveActionForm1.SetParameterValue("ChosenInterimCorrectiveAction", parameter)
        parameter = dtpVerifyDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("ChosenInterimActionDate", parameter)
        parameter = rchPermCorrAction.Text
        CRXCorrectiveActionForm1.SetParameterValue("ChosenPermanentCorrectiveAction", parameter)
        parameter = dtpImpPermActionDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("ChosenPermanentDate", parameter)
        parameter = rchActionToPreventReccurr.Text
        CRXCorrectiveActionForm1.SetParameterValue("ActionToPreventRecurrence", parameter)
        parameter = dtpActionToPreventDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("ActionDate", parameter)
        parameter = cboReviewModifyCreate.Text
        CRXCorrectiveActionForm1.SetParameterValue("ReviewModifyCreate", parameter)
        parameter = cboProductChanged.Text
        CRXCorrectiveActionForm1.SetParameterValue("ProcessChange", parameter)
        parameter = dtpdateofAudit.Text
        CRXCorrectiveActionForm1.SetParameterValue("ProcessChangeYes", parameter)
        parameter = txtNameOfAuditor.Text
        CRXCorrectiveActionForm1.SetParameterValue("ProcessAuditor", parameter)
        parameter = rchVerification.Text
        CRXCorrectiveActionForm1.SetParameterValue("Verification", parameter)
        parameter = cboVerifiedBy.Text
        CRXCorrectiveActionForm1.SetParameterValue("VerifiedBy", parameter)
        parameter = dtpCloseDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("VerifyDate", parameter)
        parameter = dtpStatusCARDate.Text
        CRXCorrectiveActionForm1.SetParameterValue("CarStatus", parameter)
        parameter = cboOpenClosed.Text
        CRXCorrectiveActionForm1.SetParameterValue("CAROpenClose", parameter)
        parameter = txtReportedBy.Text
        CRXCorrectiveActionForm1.SetParameterValue("ReportedBy", parameter)
        parameter = txtNameOf.Text
        CRXCorrectiveActionForm1.SetParameterValue("NameAtBot", parameter)
        parameter = txtDept.Text
        CRXCorrectiveActionForm1.SetParameterValue("Department", parameter)
        parameter = txtChampion.Text
        CRXCorrectiveActionForm1.SetParameterValue("Champ", parameter)

        CRXCorrectiveActionForm1 = MyReport
        CRCustomerYTDViewer.ReportSource = CRXCorrectiveActionForm1
        'con.Close()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        'Clears out the details
        teamDetails = ""
        globalCounter = True
        MsgBox("Cleared Team Details")
    End Sub
    Dim globalCounter As Boolean = True
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'If the first name added, then it just adds the combobox displayed value, else, it iterates and adds the 2nd + name to the end of the variable.

        teamDetails = teamDetails + "  " + cboChampion.Text
        cboChampion.SelectedIndex = -1
    End Sub

    Private Sub cboDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivision.SelectedIndexChanged

        'Populates the Comboboxes based on the division given.
        cmd4 = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds4, "CustomerList")
        cboSupplier.DataSource = ds4.Tables(0)
        con.Close()
        cboSupplier.SelectedIndex = -1

        cmd2 = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomer.DataSource = ds2.Tables(0)
        con.Close()
        cboCustomer.SelectedIndex = -1

        cmd3 = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables(0)
        con.Close()
        cboPartNumber.SelectedIndex = -1

        cmd4 = New SqlCommand("SELECT AuthorizationNumber FROM RMATable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds4, "RMATable")
        cboCARNum.DataSource = ds4.Tables(0)
        con.Close()
        cboCARNum.SelectedIndex = -1

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this CAR Form?", "SAVE CAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If Validation() Then
                'Looks to see if the CAR number already exists or not
                Dim exists As Boolean = False
                Dim autho As Integer = 0
                Dim ItemDataStatement As String = "SELECT CARNumber FROM CorrectiveActionTable WHERE CARNumber = @CARNumber"
                Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
                ItemDataCommand.Parameters.Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("CARNumber")) Then
                            autho = 0
                        Else
                            autho = reader.Item("CARNumber")
                        End If
                    End If
                    reader.Close()
                End Using
                Dim chosenautho = cboCARNum.Text
                If chosenautho = autho.ToString Then
                    'update
                    Try
                        cmd = New SqlCommand("UPDATE CorrectiveActionTable SET  Customer = @Customer, DivisionID = @DivisionID, Supplier = @Supplier, PartNumber = @PartNum, DateOpen = @DateOpen, TeamChampion = @TeamChampion, TeamDetails = @TeamDetails, DateOfOccurrence = @DateOfOccurrence, ProblemDefinition = @ProblemDefinition, ContainmentAction = @ContainmentAction, ContainmentImplementationbDate = @ContainmentImplementationDate, RootCause = @RootCause, InterimChosenAction = @InterimChosenAction, VerificationDate = @VerificationDate, PermanentCorrectiveAction = @PermanentCorrectiveAction, PermanentImplementationDate = @PermanentImplementationDate, ActionPreventOccurence = @ActionPreventOccurence, Review = @Review, ProcedureChange = @ProcedureChange, ProcedureDate = @ProcedureDate, AuditorName = @AuditorName, Verification = @Verification, VerifiedBy = @VerifiedBy, VerifiedDate = @VerifiedDate, CloseDate = @CloseDate, ReportedName = @ReportedName, Name = @Name, Department = @Department  WHERE CARNumber = @CARNumber", con)
                        With cmd.Parameters
                            .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                            .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                            .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                            .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                            .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                            .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                            .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                            .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                            .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                            .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                            .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                            .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                            .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                            .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                            .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                            .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                            .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                            .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                            .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                            .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                            .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                            .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                            .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                            .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                            .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Updated CAR")
                    Catch ex As System.Exception
                        MsgBox("Error Updating CAR, Please Try Again")
                        MessageBox.Show(String.Format("Error: {0}", ex.Message))
                    End Try
                Else
                    Try
                        'insert new entry
                        cmd = New SqlCommand("INSERT INTO CorrectiveActionTable (CARNumber, DivisionID, Customer, Supplier, PartNumber, DateOpen, TeamChampion, TeamDetails, DateOfOccurrence, ProblemDefinition, ContainmentAction, ContainmentImplementationbDate, RootCause, InterimChosenAction, VerificationDate, PermanentCorrectiveAction, PermanentImplementationDate, ActionPreventOccurence, PreventRecurrenceDate, Review, ProcedureChange, ProcedureDate, AuditorName, Verification, VerifiedBy, VerifiedDate, CloseDate, OpenClose, ReportedName, Name, Department)Values(@CARNumber, @Customer, @Supplier, @PartNum, @DateOpen, @TeamChampion, @DivisionID, @TeamDetails, @DateOfOccurrence, @ProblemDefinition, @ContainmentAction, @ContainmentImplementationDate, @RootCause, @InterimChosenAction, @VerificationDate, @PermanentCorrectiveAction, @PermanentImplementationDate, @ActionPreventOccurence, @PreventRecurrenceDate, @Review, @ProcedureChange, @ProcedureDate, @AuditorName, @Verification, @VerifiedBy, @VerifiedDate, @CloseDate, @OpenClose, @ReportedName, @Name, @Department)", con)

                        With cmd.Parameters
                            .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                            .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                            .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                            .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                            .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                            .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                            .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                            .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                            .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                            .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                            .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                            .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                            .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                            .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                            .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                            .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                            .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                            .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                            .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                            .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                            .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                            .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                            .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                            .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                            .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved New CAR")
                    Catch x As System.Exception
                        MsgBox("Error Inserting CAR, Please Try Again")
                        MessageBox.Show(String.Format("Error: {0}", x.Message))
                    End Try
                End If
            End If
            Me.Close()
        Else
            Me.Close()
        End If


    End Sub

    Function Validation() As Boolean
        'Validating all selections are made
        If cboCARNum.Text = "" Then
            MsgBox("Please Enter A CAR Number")
            cboCARNum.Focus()
            Return False
        End If
        If teamDetails = "" Then
            MsgBox("Please Add At Least One Champion")
            cboChampion.Focus()
            Return False
        End If
        If cboCustomer.Text = "" Then
            MsgBox("Please Enter/Select A Customer")
            cboCustomer.Focus()
            Return False
        End If
        If cboDivision.Text = "" Then
            MsgBox("Please Choose A Division")
            cboDivision.Focus()
            Return False
        End If
        If cboOpenClosed.Text = "" Then
            MsgBox("Please Select A Status")
            cboOpenClosed.Focus()
            Return False
        End If
        If cboPartNumber.Text = "" Then
            MsgBox("Please Enter/Select A Part Number")
            cboPartNumber.Focus()
            Return False
        End If
        If cboProductChanged.Text = "" Then
            MsgBox("Please Select Yes Or No")
            cboProductChanged.Focus()
            Return False
        End If
        If cboReviewModifyCreate.Text = "" Then
            MsgBox("Please Select Procedure/Form/Checklist/Work Instructions")
            cboReviewModifyCreate.Focus()
            Return False
        End If
        If cboSupplier.Text = "" Then
            MsgBox("Please Enter/Select A Supplier")
            cboSupplier.Focus()
            Return False
        End If
        If cboVerifiedBy.Text = "" Then
            MsgBox("Please Enter A Name")
            cboVerifiedBy.Focus()
            Return False
        End If
        If txtChampion.Text = "" Then
            MsgBox("Please Insert A Champion")
            txtChampion.Focus()
            Return False
        End If
        If txtDept.Text = "" Then
            MsgBox("Please Enter A Department")
            txtDept.Focus()
            Return False
        End If
        If txtNameOf.Text = "" Then
            MsgBox("Please Enter A Name")
            txtNameOf.Focus()
            Return False
        End If
        If txtReportedBy.Text = "" Then
            MsgBox("Please Enter Who Was The Reporting Individual")
            txtReportedBy.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub EmailAuthorizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAuthorizationToolStripMenuItem.Click
        'Get Login Type
        If Validation() Then
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

            DeleteDirectory("\\TFP-FS\TransferData\Test")
            If Not System.IO.Directory.Exists("\\TFP-FS\TransferData\Test") Then System.IO.Directory.CreateDirectory("\\TFP-FS\TransferData\Test")
            If GetLoginType = "REMOTE" Then
                'Create new Filename for Sales Confirmation
                FileDate = Today()
                monthofyear = FileDate.Month
                dayofyear = FileDate.DayOfYear
                yearofyear = FileDate.Year
                minuteofyear = FileDate.Minute
                strMonth = CStr(monthofyear)
                strDay = CStr(dayofyear)
                strYear = CStr(yearofyear)
                strMinute = CStr(minuteofyear)
                strCompany = GlobalDivisionCode

                ConfirmName = strMonth + strDay + strYear

                'Export Document to Folder
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

                TFPMailFilename = ConfirmName + ".pdf"
                TFPMailFilename2 = ""
                TFPMailFilename3 = ""
                TFPMailFilePath = "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf"
                TFPMailFilePath2 = ""
                TFPMailFilePath3 = ""
                TFPMailTransactionType = "Corrective Action Report"
                TFPMailTransactionNumber = 0
                TFPMailCustomer = CreditVariables.emailID

                Using NewEmailPage As New EmailPage
                    Dim Result = NewEmailPage.ShowDialog()
                End Using
            Else

                'Create new Filename for Statement
                FileDate = Now()
                monthofyear = FileDate.Month
                dayofyear = FileDate.DayOfYear
                yearofyear = FileDate.Year
                minuteofyear = FileDate.Minute
                strMonth = CStr(monthofyear)
                strDay = CStr(dayofyear)
                strYear = CStr(yearofyear)
                strMinute = CStr(minuteofyear)
                strCompany = GlobalDivisionCode

                ConfirmName = cboCustomer.Text + strMonth + strDay + strYear

                'Export Document to Folder
                MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

                'creating outlook mailitem
                Dim mail As MailItem

                'creating newblank mail message
                mail = OLApp.CreateItem(OlItemType.olMailItem)

                'adding subject information to the mail message
                mail.Subject = "Corrective Action Form"

                'Address Email To
                mail.To = ""

                'adding body message information to the mail message
                mail.Body = ""

                'adding attachment
                Try
                    mail.Attachments.Add("\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")
                Catch ex As System.Exception

                End Try

                'display mail
                mail.Display()

                Me.Close()
            End If
        End If
    End Sub
    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        End If
    End Sub
    Private Sub LoadCustomer()
        Using cmd As New SqlCommand
            cmd2 = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd2
            myAdapter5.Fill(ds5, "CustomerList")
            cboCustomer.DataSource = ds5.Tables(0)
            cboCustomer.ValueMember = "CustomerID"
            con.Close()
            cboCustomer.SelectedIndex = -1
        End Using
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Validation() Then

            Dim exists As Boolean = False
            Dim autho As Integer = 0
            Dim ItemDataStatement As String = "SELECT CARNumber FROM CorrectiveActionTable WHERE CARNumber = @CARNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("CARNumber")) Then
                        autho = 0
                    Else
                        autho = reader.Item("CARNumber")
                    End If
                End If
                reader.Close()
            End Using
            Dim chosenautho = cboCARNum.Text
            If chosenautho = autho.ToString Then
                'update
                Try
                    cmd = New SqlCommand("UPDATE CorrectiveActionTable SET  Customer = @Customer, DivisionID = @DivisionID, Supplier = @Supplier, PartNumber = @PartNum, DateOpen = @DateOpen, TeamChampion = @TeamChampion, TeamDetails = @TeamDetails, DateOfOccurrence = @DateOfOccurrence, ProblemDefinition = @ProblemDefinition, ContainmentAction = @ContainmentAction, ContainmentImplementationbDate = @ContainmentImplementationDate, RootCause = @RootCause, InterimChosenAction = @InterimChosenAction, VerificationDate = @VerificationDate, PermanentCorrectiveAction = @PermanentCorrectiveAction, PermanentImplementationDate = @PermanentImplementationDate, ActionPreventOccurence = @ActionPreventOccurence, Review = @Review, ProcedureChange = @ProcedureChange, ProcedureDate = @ProcedureDate, AuditorName = @AuditorName, Verification = @Verification, VerifiedBy = @VerifiedBy, VerifiedDate = @VerifiedDate, CloseDate = @CloseDate, ReportedName = @ReportedName, Name = @Name, Department = @Department  WHERE CARNumber = @CARNumber", con)
                    With cmd.Parameters
                        .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                        .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                        .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                        .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                        .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                        .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                        .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                        .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                        .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                        .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                        .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                        .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                        .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                        .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                        .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                        .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                        .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                        .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                        .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                        .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                        .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                        .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                        .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                        .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                        .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                        .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                        .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                        .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                        .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                    End With
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Updated CAR")
                Catch ex As System.Exception
                    MsgBox("Error Updating CAR, Please Try Again")
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
            Else
                Try
                    'insert new entry
                    cmd = New SqlCommand("INSERT INTO CorrectiveActionTable (CARNumber, DivisionID, Customer, Supplier, PartNumber, DateOpen, TeamChampion, TeamDetails, DateOfOccurrence, ProblemDefinition, ContainmentAction, ContainmentImplementationbDate, RootCause, InterimChosenAction, VerificationDate, PermanentCorrectiveAction, PermanentImplementationDate, ActionPreventOccurence, PreventRecurrenceDate, Review, ProcedureChange, ProcedureDate, AuditorName, Verification, VerifiedBy, VerifiedDate, CloseDate, OpenClose, ReportedName, Name, Department)Values(@CARNumber, @Customer, @Supplier, @PartNum, @DateOpen, @TeamChampion, @DivisionID, @TeamDetails, @DateOfOccurrence, @ProblemDefinition, @ContainmentAction, @ContainmentImplementationDate, @RootCause, @InterimChosenAction, @VerificationDate, @PermanentCorrectiveAction, @PermanentImplementationDate, @ActionPreventOccurence, @PreventRecurrenceDate, @Review, @ProcedureChange, @ProcedureDate, @AuditorName, @Verification, @VerifiedBy, @VerifiedDate, @CloseDate, @OpenClose, @ReportedName, @Name, @Department)", con)

                    With cmd.Parameters
                        .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                        .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                        .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                        .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                        .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                        .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                        .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                        .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                        .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                        .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                        .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                        .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                        .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                        .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                        .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                        .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                        .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                        .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                        .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                        .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                        .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                        .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                        .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                        .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                        .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                        .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                        .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                        .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                        .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Saved New CAR")
                Catch x As System.Exception
                    MsgBox("Error Inserting CAR, Please Try Again")
                    MessageBox.Show(String.Format("Error: {0}", x.Message))
                End Try
            End If
        End If

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this CAR Form?", "SAVE CAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If Validation() Then

                Dim exists As Boolean = False
                Dim autho As Integer = 0
                Dim ItemDataStatement As String = "SELECT CARNumber FROM CorrectiveActionTable WHERE CARNumber = @CARNumber"
                Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
                ItemDataCommand.Parameters.Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("CARNumber")) Then
                            autho = 0
                        Else
                            autho = reader.Item("CARNumber")
                        End If
                    End If
                    reader.Close()
                End Using
                Dim chosenautho = cboCARNum.Text
                If chosenautho = autho.ToString Then
                    'update
                    Try
                        cmd = New SqlCommand("UPDATE CorrectiveActionTable SET  Customer = @Customer, DivisionID = @DivisionID, Supplier = @Supplier, PartNumber = @PartNum, DateOpen = @DateOpen, TeamChampion = @TeamChampion, TeamDetails = @TeamDetails, DateOfOccurrence = @DateOfOccurrence, ProblemDefinition = @ProblemDefinition, ContainmentAction = @ContainmentAction, ContainmentImplementationbDate = @ContainmentImplementationDate, RootCause = @RootCause, InterimChosenAction = @InterimChosenAction, VerificationDate = @VerificationDate, PermanentCorrectiveAction = @PermanentCorrectiveAction, PermanentImplementationDate = @PermanentImplementationDate, ActionPreventOccurence = @ActionPreventOccurence, Review = @Review, ProcedureChange = @ProcedureChange, ProcedureDate = @ProcedureDate, AuditorName = @AuditorName, Verification = @Verification, VerifiedBy = @VerifiedBy, VerifiedDate = @VerifiedDate, CloseDate = @CloseDate, ReportedName = @ReportedName, Name = @Name, Department = @Department  WHERE CARNumber = @CARNumber", con)
                        With cmd.Parameters
                            .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                            .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                            .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                            .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                            .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                            .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                            .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                            .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                            .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                            .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                            .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                            .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                            .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                            .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                            .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                            .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                            .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                            .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                            .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                            .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                            .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                            .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                            .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                            .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                            .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                        End With
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Updated CAR")
                    Catch ex As System.Exception
                        MsgBox("Error Updating CAR, Please Try Again")
                        MessageBox.Show(String.Format("Error: {0}", ex.Message))
                    End Try
                Else
                    Try
                        'insert new entry
                        cmd = New SqlCommand("INSERT INTO CorrectiveActionTable (CARNumber, DivisionID, Customer, Supplier, PartNumber, DateOpen, TeamChampion, TeamDetails, DateOfOccurrence, ProblemDefinition, ContainmentAction, ContainmentImplementationbDate, RootCause, InterimChosenAction, VerificationDate, PermanentCorrectiveAction, PermanentImplementationDate, ActionPreventOccurence, PreventRecurrenceDate, Review, ProcedureChange, ProcedureDate, AuditorName, Verification, VerifiedBy, VerifiedDate, CloseDate, OpenClose, ReportedName, Name, Department)Values(@CARNumber, @Customer, @Supplier, @PartNum, @DateOpen, @TeamChampion, @DivisionID, @TeamDetails, @DateOfOccurrence, @ProblemDefinition, @ContainmentAction, @ContainmentImplementationDate, @RootCause, @InterimChosenAction, @VerificationDate, @PermanentCorrectiveAction, @PermanentImplementationDate, @ActionPreventOccurence, @PreventRecurrenceDate, @Review, @ProcedureChange, @ProcedureDate, @AuditorName, @Verification, @VerifiedBy, @VerifiedDate, @CloseDate, @OpenClose, @ReportedName, @Name, @Department)", con)

                        With cmd.Parameters
                            .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
                            .Add("@Customer", SqlDbType.VarChar).Value = cboCustomer.Text
                            .Add("@Supplier", SqlDbType.VarChar).Value = cboSupplier.Text
                            .Add("@PartNum", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@DateOpen", SqlDbType.VarChar).Value = dtpDateOpened.Text
                            .Add("@TeamChampion", SqlDbType.VarChar).Value = txtChampion.Text
                            .Add("@TeamDetails", SqlDbType.VarChar).Value = teamDetails
                            .Add("@DateOfOccurrence", SqlDbType.VarChar).Value = dtpOccuranceDate.Text
                            .Add("@ProblemDefinition", SqlDbType.VarChar).Value = rchProblemDef.Text
                            .Add("@ContainmentAction", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@ContainmentImplementationDate", SqlDbType.VarChar).Value = dtpContainImpDate.Text
                            .Add("@RootCause", SqlDbType.VarChar).Value = rchRoot.Text
                            .Add("@InterimChosenAction", SqlDbType.VarChar).Value = rchInterimCorrect.Text
                            .Add("@VerificationDate", SqlDbType.VarChar).Value = dtpVerifyDate.Text
                            .Add("@PermanentCorrectiveAction", SqlDbType.VarChar).Value = rchPermCorrAction.Text
                            .Add("@PermanentImplementationDate", SqlDbType.VarChar).Value = dtpImpPermActionDate.Text
                            .Add("@ActionPreventOccurence", SqlDbType.VarChar).Value = rchContainmentAction.Text
                            .Add("@PreventRecurrenceDate", SqlDbType.VarChar).Value = dtpActionToPreventDate.Text
                            .Add("@Review", SqlDbType.VarChar).Value = cboReviewModifyCreate.Text
                            .Add("@ProcedureChange", SqlDbType.VarChar).Value = cboProductChanged.Text
                            .Add("@ProcedureDate", SqlDbType.VarChar).Value = dtpdateofAudit.Text
                            .Add("@AuditorName", SqlDbType.VarChar).Value = txtNameOfAuditor.Text
                            .Add("@Verification", SqlDbType.VarChar).Value = rchVerification.Text
                            .Add("@VerifiedBy", SqlDbType.VarChar).Value = cboVerifiedBy.Text
                            .Add("@VerifiedDate", SqlDbType.VarChar).Value = dtpCloseDate.Text
                            .Add("@CloseDate", SqlDbType.VarChar).Value = dtpStatusCARDate.Text
                            .Add("@OpenClose", SqlDbType.VarChar).Value = cboOpenClosed.Text
                            .Add("@ReportedName", SqlDbType.VarChar).Value = txtReportedBy.Text
                            .Add("@Name", SqlDbType.VarChar).Value = txtNameOf.Text
                            .Add("@Department", SqlDbType.VarChar).Value = txtDept.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivision.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved New CAR")
                    Catch x As System.Exception
                        MsgBox("Error Inserting CAR, Please Try Again")
                        MessageBox.Show(String.Format("Error: {0}", x.Message))
                    End Try
                End If
            End If
            Me.Close()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub cboCARNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCARNum.SelectedIndexChanged
        'Fills in the data based on the CAR Number Given
        Dim ItemDataStatement5 As String = "SELECT * FROM CorrectiveActionTable WHERE CARNumber = @CARNum"
        Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
        ItemDataCommand5.Parameters.Add("@CARNum", SqlDbType.VarChar).Value = cboCARNum.Text
        Dim Customer, Supp, PartNum, DateOpen, TC, TD, DOO, PD, CA, CID, RC, ICA, VD, PCA, PID, APR, PRD, R, PC, ProcDate, AN, Verif, VB, VerifiedDate, CD, OC, RN, Name, Department, DID As String
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
            Try

                If reader5.HasRows Then
                    reader5.Read()
                    If IsDBNull(reader5.Item("Customer")) Then
                        Customer = " "
                    Else
                        Customer = reader5.Item("Customer")
                    End If
                    If IsDBNull(reader5.Item("Supplier")) Then
                        Supp = " "
                    Else
                        Supp = reader5.Item("Supplier")
                    End If
                    If IsDBNull(reader5.Item("PartNumber")) Then
                        PartNum = " "
                    Else
                        PartNum = reader5.Item("PartNumber")
                    End If
                    If IsDBNull(reader5.Item("DateOpen")) Then
                        DateOpen = " "
                    Else
                        DateOpen = reader5.Item("DateOpen")
                    End If
                    If IsDBNull(reader5.Item("TeamChampion")) Then
                        TC = " "
                    Else
                        TC = reader5.Item("TeamChampion")
                    End If
                    If IsDBNull(reader5.Item("TeamDetails")) Then
                        TD = " "
                    Else
                        TD = reader5.Item("TeamDetails")
                    End If
                    If IsDBNull(reader5.Item("DateOfOccurrence")) Then
                        DOO = " "
                    Else
                        DOO = reader5.Item("DateOfOccurrence")
                    End If
                    If IsDBNull(reader5.Item("ProblemDefinition")) Then
                        PD = " "
                    Else
                        PD = reader5.Item("ProblemDefinition")
                    End If
                    If IsDBNull(reader5.Item("ContainmentAction")) Then
                        CA = " "
                    Else
                        CA = reader5.Item("ContainmentAction")
                    End If
                    If IsDBNull(reader5.Item("ContainmentImplementationDate")) Then
                        CID = " "
                    Else
                        CID = reader5.Item("ContainmentImplementationDate")
                    End If
                    If IsDBNull(reader5.Item("RootCause")) Then
                        RC = " "
                    Else
                        RC = reader5.Item("RootCause")
                    End If
                    If IsDBNull(reader5.Item("InterimChosenAction")) Then
                        ICA = " "
                    Else
                        ICA = reader5.Item("InterimChosenAction")
                    End If
                    If IsDBNull(reader5.Item("VerificationDate")) Then
                        VD = " "
                    Else
                        VD = reader5.Item("VerificationDate")
                    End If
                    If IsDBNull(reader5.Item("PermanentCorrectiveAction")) Then
                        PCA = " "
                    Else
                        PCA = reader5.Item("PermanentCorrectiveAction")
                    End If
                    If IsDBNull(reader5.Item("PermanentImplementationDate")) Then
                        PID = " "
                    Else
                        PID = reader5.Item("PermanentImplementationDate")
                    End If
                    If IsDBNull(reader5.Item("ActionPreventOccurence")) Then
                        APR = " "
                    Else
                        APR = reader5.Item("ActionPreventOccurence")
                    End If
                    If IsDBNull(reader5.Item("PreventRecurrenceDate")) Then
                        PRD = " "
                    Else
                        PRD = reader5.Item("PreventRecurrenceDate")
                    End If
                    If IsDBNull(reader5.Item("Review")) Then
                        R = " "
                    Else
                        R = reader5.Item("Review")
                    End If
                    If IsDBNull(reader5.Item("ProcedureChange")) Then
                        PC = " "
                    Else
                        PC = reader5.Item("ProcedureChange")
                    End If
                    If IsDBNull(reader5.Item("ProcedureDate")) Then
                        ProcDate = " "
                    Else
                        ProcDate = reader5.Item("ProcedureDate")
                    End If
                    If IsDBNull(reader5.Item("AuditorName")) Then
                        AN = " "
                    Else
                        AN = reader5.Item("AuditorName")
                    End If
                    If IsDBNull(reader5.Item("Verification")) Then
                        Verif = " "
                    Else
                        Verif = reader5.Item("Verification")
                    End If
                    If IsDBNull(reader5.Item("VerifiedBy")) Then
                        VB = " "
                    Else
                        VB = reader5.Item("VerifiedBy")
                    End If
                    If IsDBNull(reader5.Item("VerifiedDate")) Then
                        VerifiedDate = " "
                    Else
                        VerifiedDate = reader5.Item("VerifiedDate")
                    End If
                    If IsDBNull(reader5.Item("CloseDate")) Then
                        CD = " "
                    Else
                        CD = reader5.Item("CloseDate")
                    End If
                    If IsDBNull(reader5.Item("OpenClose")) Then
                        OC = " "
                    Else
                        OC = reader5.Item("OpenClose")
                    End If
                    If IsDBNull(reader5.Item("ReportedName")) Then
                        RN = " "
                    Else
                        RN = reader5.Item("ReportedName")
                    End If
                    If IsDBNull(reader5.Item("Name")) Then
                        Name = " "
                    Else
                        Name = reader5.Item("Name")
                    End If
                    If IsDBNull(reader5.Item("Department")) Then
                        Department = " "
                    Else
                        Department = reader5.Item("Department")
                    End If
                    If IsDBNull(reader5.Item("DivisionID")) Then
                        DID = " "
                    Else
                        DID = reader5.Item("DivisionID")
                    End If
                Else
                    Customer = " "
                    Supp = " "
                    PartNum = " "
                    DateOpen = " "
                    TC = " "
                    TD = " "
                    DOO = " "
                    PD = " "
                    CA = " "
                    CID = " "
                    RC = " "
                    ICA = " "
                    VD = " "
                    PCA = " "
                    PID = " "
                    APR = " "
                    PRD = " "
                    R = " "
                    PC = " "
                    ProcDate = " "
                    AN = " "
                    Verif = " "
                    VB = " "
                    VerifiedDate = " "
                    CD = " "
                    OC = " "
                    RN = " "
                    Name = " "
                    Department = " "
                    DID = " "
                End If
                teamDetails = TD
                cboCustomer.Text = Customer
                cboOpenClosed.Text = OC
                cboPartNumber.Text = PartNum
                cboProductChanged.Text = PC
                cboReviewModifyCreate.Text = R
                cboSupplier.Text = Supp
                cboVerifiedBy.Text = VB
                txtChampion.Text = TC
                txtDept.Text = Department
                txtNameOf.Text = Name
                txtNameOfAuditor.Text = AN
                txtReportedBy.Text = RN
                rchActionToPreventReccurr.Text = APR
                rchContainmentAction.Text = CA
                rchInterimCorrect.Text = ICA
                rchPermCorrAction.Text = PCA
                rchProblemDef.Text = PD
                rchRoot.Text = RC
                rchVerification.Text = Verif
                dtpActionToPreventDate.Text = PRD
                dtpCloseDate.Text = VD
                dtpContainImpDate.Text = CID
                dtpdateofAudit.Text = ProcDate
                dtpDateOpened.Text = DateOpen
                dtpImpPermActionDate.Text = PID
                dtpOccuranceDate.Text = DOO
                dtpStatusCARDate.Text = CD
                dtpVerifyDate.Text = VerifiedDate

            Catch ex As System.Exception

            End Try
        End Using
    End Sub

    Private Sub cboCARNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCARNum.TextChanged
        'Will try to find the data accociated with the CAR number that is typed into the combobox
        Try
            Dim ItemDataStatement5 As String = "SELECT * FROM CorrectiveActionTable WHERE CARNumber = @CARNumber"
            Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
            ItemDataCommand5.Parameters.Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text
            Dim Customer, Supp, PartNum, DateOpen, TC, TD, DOO, PD, CA, CID, RC, ICA, VD, PCA, PID, APR, PRD, R, PC, ProcDate, AN, Verif, VB, VerifiedDate, CD, OC, RN, Name, Department, DID As String
            If con.State = ConnectionState.Closed Then con.Open()
            Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
                Try

                    If reader5.HasRows Then
                        reader5.Read()
                        If IsDBNull(reader5.Item("Customer")) Then
                            Customer = " "
                        Else
                            Customer = reader5.Item("Customer")
                        End If
                        If IsDBNull(reader5.Item("Supplier")) Then
                            Supp = " "
                        Else
                            Supp = reader5.Item("Supplier")
                        End If
                        If IsDBNull(reader5.Item("PartNumber")) Then
                            PartNum = " "
                        Else
                            PartNum = reader5.Item("PartNumber")
                        End If
                        If IsDBNull(reader5.Item("DateOpen")) Then
                            DateOpen = " "
                        Else
                            DateOpen = reader5.Item("DateOpen")
                        End If
                        If IsDBNull(reader5.Item("TeamChampion")) Then
                            TC = " "
                        Else
                            TC = reader5.Item("TeamChampion")
                        End If
                        If IsDBNull(reader5.Item("TeamDetails")) Then
                            TD = " "
                        Else
                            TD = reader5.Item("TeamDetails")
                        End If
                        If IsDBNull(reader5.Item("DateOfOccurrence")) Then
                            DOO = " "
                        Else
                            DOO = reader5.Item("DateOfOccurrence")
                        End If
                        If IsDBNull(reader5.Item("ProblemDefinition")) Then
                            PD = " "
                        Else
                            PD = reader5.Item("ProblemDefinition")
                        End If
                        If IsDBNull(reader5.Item("ContainmentAction")) Then
                            CA = " "
                        Else
                            CA = reader5.Item("ContainmentAction")
                        End If
                        If IsDBNull(reader5.Item("ContainmentImplementationbDate")) Then
                            CID = " "
                        Else
                            CID = reader5.Item("ContainmentImplementationbDate")
                        End If
                        If IsDBNull(reader5.Item("RootCause")) Then
                            RC = " "
                        Else
                            RC = reader5.Item("RootCause")
                        End If
                        If IsDBNull(reader5.Item("InterimChosenAction")) Then
                            ICA = " "
                        Else
                            ICA = reader5.Item("InterimChosenAction")
                        End If
                        If IsDBNull(reader5.Item("VerificationDate")) Then
                            VD = " "
                        Else
                            VD = reader5.Item("VerificationDate")
                        End If
                        If IsDBNull(reader5.Item("PermanentCorrectiveAction")) Then
                            PCA = " "
                        Else
                            PCA = reader5.Item("PermanentCorrectiveAction")
                        End If
                        If IsDBNull(reader5.Item("PermanentImplementationDate")) Then
                            PID = " "
                        Else
                            PID = reader5.Item("PermanentImplementationDate")
                        End If
                        If IsDBNull(reader5.Item("ActionPreventOccurence")) Then
                            APR = " "
                        Else
                            APR = reader5.Item("ActionPreventOccurence")
                        End If
                        If IsDBNull(reader5.Item("PreventRecurrenceDate")) Then
                            PRD = " "
                        Else
                            PRD = reader5.Item("PreventRecurrenceDate")
                        End If
                        If IsDBNull(reader5.Item("Review")) Then
                            R = " "
                        Else
                            R = reader5.Item("Review")
                        End If
                        If IsDBNull(reader5.Item("ProcedureChange")) Then
                            PC = " "
                        Else
                            PC = reader5.Item("ProcedureChange")
                        End If
                        If IsDBNull(reader5.Item("ProcedureDate")) Then
                            ProcDate = " "
                        Else
                            ProcDate = reader5.Item("ProcedureDate")
                        End If
                        If IsDBNull(reader5.Item("AuditorName")) Then
                            AN = " "
                        Else
                            AN = reader5.Item("AuditorName")
                        End If
                        If IsDBNull(reader5.Item("Verification")) Then
                            Verif = " "
                        Else
                            Verif = reader5.Item("Verification")
                        End If
                        If IsDBNull(reader5.Item("VerifiedBy")) Then
                            VB = " "
                        Else
                            VB = reader5.Item("VerifiedBy")
                        End If
                        If IsDBNull(reader5.Item("VerifiedDate")) Then
                            VerifiedDate = " "
                        Else
                            VerifiedDate = reader5.Item("VerifiedDate")
                        End If
                        If IsDBNull(reader5.Item("CloseDate")) Then
                            CD = " "
                        Else
                            CD = reader5.Item("CloseDate")
                        End If
                        If IsDBNull(reader5.Item("OpenClose")) Then
                            OC = " "
                        Else
                            OC = reader5.Item("OpenClose")
                        End If
                        If IsDBNull(reader5.Item("ReportedName")) Then
                            RN = " "
                        Else
                            RN = reader5.Item("ReportedName")
                        End If
                        If IsDBNull(reader5.Item("Name")) Then
                            Name = " "
                        Else
                            Name = reader5.Item("Name")
                        End If
                        If IsDBNull(reader5.Item("Department")) Then
                            Department = " "
                        Else
                            Department = reader5.Item("Department")
                        End If
                        If IsDBNull(reader5.Item("DivisionID")) Then
                            DID = " "
                        Else
                            DID = reader5.Item("DivisionID")
                        End If
                    Else
                        Customer = " "
                        Supp = " "
                        PartNum = " "
                        DateOpen = " "
                        TC = " "
                        TD = " "
                        DOO = " "
                        PD = " "
                        CA = " "
                        CID = " "
                        RC = " "
                        ICA = " "
                        VD = " "
                        PCA = " "
                        PID = " "
                        APR = " "
                        PRD = " "
                        R = " "
                        PC = " "
                        ProcDate = " "
                        AN = " "
                        Verif = " "
                        VB = " "
                        VerifiedDate = " "
                        CD = " "
                        OC = " "
                        RN = " "
                        Name = " "
                        Department = " "
                        DID = " "
                    End If
                    teamDetails = TD
                    cboCustomer.Text = Customer
                    cboDivision.Text = DID
                    cboOpenClosed.Text = OC
                    cboPartNumber.Text = PartNum
                    cboProductChanged.Text = PC
                    cboReviewModifyCreate.Text = R
                    cboSupplier.Text = Supp
                    cboVerifiedBy.Text = VB
                    txtChampion.Text = TC
                    txtDept.Text = Department
                    txtNameOf.Text = Name
                    txtNameOfAuditor.Text = AN
                    txtReportedBy.Text = RN
                    rchActionToPreventReccurr.Text = APR
                    rchContainmentAction.Text = CA
                    rchInterimCorrect.Text = ICA
                    rchPermCorrAction.Text = PCA
                    rchProblemDef.Text = PD
                    rchRoot.Text = RC
                    rchVerification.Text = Verif
                    dtpActionToPreventDate.Text = PRD
                    dtpCloseDate.Text = VD
                    dtpContainImpDate.Text = CID
                    dtpdateofAudit.Text = ProcDate
                    dtpDateOpened.Text = DateOpen
                    dtpImpPermActionDate.Text = PID
                    dtpOccuranceDate.Text = DOO
                    dtpStatusCARDate.Text = CD
                    dtpVerifyDate.Text = VerifiedDate

                Catch ex As System.Exception

                End Try
            End Using
        Catch ex As System.Exception

        End Try
        Dim exists As Boolean = False
        Dim autho As Integer = 0
        Dim ItemDataStatement As String = "SELECT CARNumber FROM CorrectiveActionTable WHERE CARNumber = @CARNumber"
        Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
        Try
            ItemDataCommand.Parameters.Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("CARNumber")) Then
                        autho = 0
                    Else
                        autho = reader.Item("CARNumber")
                    End If
                End If
                reader.Close()
            End Using
            Dim chosenautho = cboCARNum.Text
            If chosenautho = autho.ToString Then
                lblExists.Text = "CAR# Exists"
                lblExists.Enabled = True

            Else
                lblExists.Text = " "
                lblExists.Enabled = False
            End If
        Catch exe As System.Exception

        End Try
    End Sub

    Private Sub cboProductChanged_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProductChanged.SelectedIndexChanged
        If cboProductChanged.Text = "No" Or cboProductChanged.Text = "no" Then
            txtNameOfAuditor.Text = "N/A"
            txtNameOfAuditor.Enabled = False
        Else
            txtNameOfAuditor.Text = ""
            txtNameOfAuditor.Enabled = True
        End If
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Try
            'clears comboboxes
            cboCARNum.SelectedIndex = -1
            cboDivision.SelectedIndex = -1
            cboCustomer.SelectedIndex = -1
            cboPartNumber.SelectedIndex = -1
            cboSupplier.SelectedIndex = -1
            cboOpenClosed.SelectedIndex = -1
            cboChampion.SelectedIndex = -1
            cboProductChanged.SelectedIndex = -1
            cboReviewModifyCreate.SelectedIndex = -1
            cboVerifiedBy.SelectedIndex = -1
            cboDivision.Text = ""
            cboCARNum.Text = ""
            cboSupplier.Text = ""
            cboCustomer.Text = ""
            cboPartNumber.Text = ""

            'clears date time pickers
            dtpActionToPreventDate.Value = Now
            dtpCloseDate.Value = Now
            dtpContainImpDate.Value = Now
            dtpdateofAudit.Value = Now
            dtpDateOpened.Value = Now
            dtpImpPermActionDate.Value = Now
            dtpOccuranceDate.Value = Now
            dtpStatusCARDate.Value = Now
            dtpVerifyDate.Value = Now

            'clears textboxes
            txtChampion.Text = ""
            txtDept.Text = ""
            txtNameOf.Text = ""
            txtNameOfAuditor.Text = ""
            txtReportedBy.Text = ""
            rchActionToPreventReccurr.Text = ""
            rchContainmentAction.Text = ""
            rchInterimCorrect.Text = ""
            rchPermCorrAction.Text = ""
            rchProblemDef.Text = ""
            rchRoot.Text = ""
            rchVerification.Text = ""

        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If lblExists.Enabled = True Then
            Try
                'delete entry
                cmd = New SqlCommand("DELETE FROM CorrectiveActionTable WHERE CARNumber = @CARNumber", con)

                With cmd.Parameters
                    .Add("@CARNumber", SqlDbType.VarChar).Value = cboCARNum.Text

                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Deleted CAR")
            Catch x As System.Exception
                MsgBox("Error Deleting CAR, Please Try Again")
                MessageBox.Show(String.Format("Error: {0}", x.Message))
            End Try
        Else
            MsgBox("Record does not exist. Please select a valid CAR number")
            cboCARNum.Focus()
        End If
    End Sub
End Class