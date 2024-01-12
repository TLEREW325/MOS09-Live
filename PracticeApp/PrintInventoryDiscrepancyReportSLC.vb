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
Public Class PrintInventoryDiscrepancyReportSLC
    Inherits System.Windows.Forms.Form

    Dim WeldStudFilter, CarrBoltFilter, CPGNutsFilter, EPOXYFilter, EXPACHORFilter, FERFilter, HEXBOLTSFilter, HEXNUTSFilter, JAMNUTSFilter, LAGBOLTSFilter, LOCKNUTSFilter, METRICFilter, SCREWSFilter, SOCKETSCREWFilter, TCBOLTSFilter, WASHERSFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Create Filters
        If chkWeldStud.Checked = True Then
            WeldStudFilter = " OR (ItemClass = 'TW CA' OR ItemClass = 'TW SC' or ItemClass = 'TW DS' or ItemClass = 'TW DB' OR ItemClass = 'TW SWR' or ItemClass = 'TW PS'or ItemClass = 'TW TT' or ItemClass = 'TW TP' OR ItemClass = 'TW TR' OR ItemClass = 'TW CD'OR ItemClass = 'TW CS' OR ItemClass = 'TW IT')"
        Else
            WeldStudFilter = ""
        End If
        If chkCarrBolt.Checked = True Then
            CarrBoltFilter = " OR ItemClass = 'CARR BOLTS'"
        Else
            CarrBoltFilter = ""
        End If
        If chkCpgNuts.Checked = True Then
            CPGNutsFilter = " OR ItemClass = 'CPG NUTS'"
        Else
            CPGNutsFilter = ""

        End If
        If chkEPOXY.Checked = True Then
            EPOXYFilter = " OR ItemClass = 'EPOXY'"
        Else
            EPOXYFilter = ""
        End If
        If chkEXPANCHOR.Checked = True Then
            EXPACHORFilter = " OR ItemClass = 'EXP ANCHOR'"
        Else
            EXPACHORFilter = ""
        End If

        If chkTWFER.Checked = True Then
            FERFilter = " OR ItemClass = 'FERRULE'"
        Else
            FERFilter = ""
        End If

        If chkHEXBOLTS.Checked = True Then
            HEXBOLTSFilter = " OR ItemClass = 'HEX BOLTS'"
        Else
            HEXBOLTSFilter = ""
        End If
        If chkHEXNUTS.Checked = True Then
            HEXNUTSFilter = " OR ItemClass = 'HEX NUTS'"
        Else
            HEXNUTSFilter = ""
        End If
        If chkJAMNUTS.Checked = True Then
            JAMNUTSFilter = " OR ItemClass = 'JAM NUTS'"
        Else
            JAMNUTSFilter = ""
        End If
        If chkLAGBOLTS.Checked = True Then
            LAGBOLTSFilter = " OR ItemClass = 'LAG BOLTS'"
        Else
            LAGBOLTSFilter = ""
        End If
        If chkLOCKNUTS.Checked = True Then
            LOCKNUTSFilter = " OR ItemClass = 'LOCK NUTS'"
        Else
            LOCKNUTSFilter = ""
        End If

        If chkSCREWS.Checked = True Then
            SCREWSFilter = " OR ItemClass = 'SCREWS'"
        Else
            SCREWSFilter = ""
        End If
        If chkMETRIC.Checked = True Then
            METRICFilter = " OR ItemClass = 'METRIC'"
        Else
            METRICFilter = ""
        End If

        If chkSOCKETSCREW.Checked = True Then
            SOCKETSCREWFilter = " OR ItemClass = 'SOCKET SCREW'"
        Else
            SOCKETSCREWFilter = ""
        End If
        If chkTCBOLTS.Checked = True Then
            TCBOLTSFilter = " OR ItemClass = 'TC BOLTS'"
        Else
            TCBOLTSFilter = ""
        End If
        If chkWASHER.Checked = True Then
            WASHERSFilter = " OR ItemClass = 'WASHERS'"
        Else
            WASHERSFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM RackingWithQOHSLC WHERE DivisionID = @DivisionID AND (ItemClass = 'TST'" + WeldStudFilter + CarrBoltFilter + CPGNutsFilter + EPOXYFilter + EXPACHORFilter + FERFilter + HEXBOLTSFilter + HEXNUTSFilter + JAMNUTSFilter + LAGBOLTSFilter + LOCKNUTSFilter + METRICFilter + SCREWSFilter + SOCKETSCREWFilter + TCBOLTSFilter + WASHERSFilter + ") ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode


        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingWithQOHSLC")


        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInv_RackDiscrepancySLC1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInv_RackDiscrepancySLC1
        MyReport.SetDataSource(ds)
        CRInventoryViewer.ReportSource = Nothing
        con.Close()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then
            chkWeldStud.Checked = True
            chkJAMNUTS.Checked = True

            chkEPOXY.Checked = True
            chkCpgNuts.Checked = True
            chkTWFER.Checked = True
            chkHEXNUTS.Checked = True
            chkCarrBolt.Checked = True
            chkHEXBOLTS.Checked = True
            chkLAGBOLTS.Checked = True
            chkEXPANCHOR.Checked = True
            chkLOCKNUTS.Checked = True
            chkMETRIC.Checked = True
            chkSCREWS.Checked = True
            chkSOCKETSCREW.Checked = True
            chkTCBOLTS.Checked = True
            chkWASHER.Checked = True
            chkUnselectAll.Checked = False
        End If
    End Sub

    Private Sub chkUnselectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnselectAll.CheckedChanged
        If chkUnselectAll.Checked = True Then
            chkWeldStud.Checked = False
            chkJAMNUTS.Checked = False


            chkEPOXY.Checked = False
            chkCpgNuts.Checked = False
            chkTWFER.Checked = False
            chkHEXNUTS.Checked = False
            chkCarrBolt.Checked = False
            chkHEXBOLTS.Checked = False
            chkLAGBOLTS.Checked = False
            chkEXPANCHOR.Checked = False
            chkLOCKNUTS.Checked = False
            chkMETRIC.Checked = False
            chkSCREWS.Checked = False
            chkSOCKETSCREW.Checked = False
            chkTCBOLTS.Checked = False
            chkWASHER.Checked = False
            chkSelectAll.Checked = False
        End If
    End Sub






    Private Sub CRInventoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInventoryViewer.Load

    End Sub
End Class