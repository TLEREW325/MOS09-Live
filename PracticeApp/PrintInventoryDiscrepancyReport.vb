Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintInventoryDiscrepancyReport
    Inherits System.Windows.Forms.Form

    Dim RAFilter, TrufitFilter, ITFilter, SHFilter, CDFilter, KOFilter, NTFilter, PSFilter, CAFilter, SCFilter, DSFilter, DBFilter, TTFilter, TPFilter, TRFilter, CSFilter, FERFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Create Filters
        If chkTWCA.Checked = True Then
            CAFilter = " OR ItemClass = 'TW CA'"
        Else
            CAFilter = ""
        End If
        If chkTWSC.Checked = True Then
            SCFilter = " OR ItemClass = 'TW SC'"
        Else
            SCFilter = ""
        End If
        If chkTWDS.Checked = True Then
            DSFilter = " OR ItemClass = 'TW DS'"
        Else
            DSFilter = ""
        End If
        If chkTWDB.Checked = True Then
            DBFilter = " OR ItemClass = 'TW DB' OR ItemClass = 'TW SWR'"
        Else
            DBFilter = ""
        End If
        If chkTWPS.Checked = True Then
            PSFilter = " OR ItemClass = 'TW PS'"
        Else
            PSFilter = ""
        End If
        If chkTWTT.Checked = True Then
            TTFilter = " OR ItemClass = 'TW TT'"
        Else
            TTFilter = ""
        End If
        If chkTWTP.Checked = True Then
            TPFilter = " OR ItemClass = 'TW TP'"
        Else
            TPFilter = ""
        End If
        If chkTWTR.Checked = True Then
            TRFilter = " OR ItemClass = 'TW TR'"
        Else
            TRFilter = ""
        End If
        If chkTWCS.Checked = True Then
            CSFilter = " OR ItemClass = 'TW CS'"
        Else
            CSFilter = ""
        End If
        If chkTWNT.Checked = True Then
            NTFilter = " OR ItemClass = 'TW NT'"
        Else
            NTFilter = ""
        End If
        If chkTWKO.Checked = True Then
            KOFilter = " OR ItemClass = 'TW KO'"
        Else
            KOFilter = ""
        End If
        If chkTWCD.Checked = True Then
            CDFilter = " OR ItemClass = 'TW CD'"
        Else
            CDFilter = ""
        End If
        If chkTWFER.Checked = True Then
            FERFilter = " OR ItemClass = 'FERRULE'"
        Else
            FERFilter = ""
        End If
        If chkTWIT.Checked = True Then
            ITFilter = " OR ItemClass = 'TW IT'"
        Else
            ITFilter = ""
        End If
        If chkTWSH.Checked = True Then
            SHFilter = " OR ItemClass = 'TW SH'"
        Else
            SHFilter = ""
        End If
        If chkTWRA.Checked = True Then
            RAFilter = " OR ItemClass = 'TW RA'"
        Else
            RAFilter = ""
        End If
        If chkTrufit.Checked = True Then
            TrufitFilter = " OR ItemClass = 'Trufit Parts'"
        Else
            TrufitFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM RackingWithQOH WHERE DivisionID = @DivisionID AND (ItemClass = ''" + CAFilter + SCFilter + DSFilter + DBFilter + PSFilter + FERFilter + TRFilter + CSFilter + TTFilter + TPFilter + TRFilter + CDFilter + KOFilter + TrufitFilter + ITFilter + SHFilter + RAFilter + TrufitFilter + NTFilter + ") ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        cmd1 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID AND Status <> 'INACTIVE'", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingWithQOH")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "FoxTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInv_RackDiscrepancy1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInv_RackDiscrepancy1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = Nothing
        con.Close()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then
            chkTWCA.Checked = True
            chkTWCS.Checked = True
            chkTWCS.Checked = True
            chkTWDB.Checked = True
            chkTWDS.Checked = True
            chkTWFER.Checked = True
            chkTWPS.Checked = True
            chkTWSC.Checked = True
            chkTWTP.Checked = True
            chkTWTR.Checked = True
            chkTWTT.Checked = True
            chkTWNT.Checked = True
            chkTWKO.Checked = True
            chkTWCD.Checked = True
            chkTWIT.Checked = True
            chkTWSH.Checked = True
            chkTrufit.Checked = True
            chkUnselectAll.Checked = False
        End If
    End Sub

    Private Sub chkUnselectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnselectAll.CheckedChanged
        If chkUnselectAll.Checked = True Then
            chkTWCA.Checked = False
            chkTWCS.Checked = False
            chkTWCS.Checked = False
            chkTWDB.Checked = False
            chkTWDS.Checked = False
            chkTWFER.Checked = False
            chkTWPS.Checked = False
            chkTWSC.Checked = False
            chkTWTP.Checked = False
            chkTWTR.Checked = False
            chkTWTT.Checked = False
            chkTWNT.Checked = False
            chkTWKO.Checked = False
            chkTWCD.Checked = False
            chkTWIT.Checked = False
            chkTWSH.Checked = False
            chkTrufit.Checked = False
            chkSelectAll.Checked = False
        End If
    End Sub

    Private Sub PrintInventoryDiscrepancyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    
End Class