Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PrintQCInspectionReport
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim Key As String = ""

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal inspectionKey As String)
        InitializeComponent()
        Key = inspectionKey
        Dim i As Integer = 0
        Dim notfound As Boolean = True
        ''loops through to find the toolstrip
        While i < crvQCInspectionReport.Controls.Count AndAlso notfound
            If TypeOf crvQCInspectionReport.Controls(i) Is System.Windows.Forms.ToolStrip Then
                Dim ctrl As System.Windows.Forms.ToolStrip = CType(crvQCInspectionReport.Controls(i), System.Windows.Forms.ToolStrip)
                Dim j As Integer = 0
                ''Loops through to find the print button
                While j < ctrl.Items.Count AndAlso notfound
                    If ctrl.Items(j).ToolTipText.Equals("Print Report") Then
                        AddHandler ctrl.Items(j).Click, AddressOf UpdateInspectionEntry
                        notfound = False
                    End If
                    j += 1
                End While
            End If
            i += 1
        End While

        Dim cmd As New SqlCommand("SELECT * FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = inspectionKey

        Dim cmd1 As New SqlCommand("SELECT * FROM QCInspectionHeaderTable WHERE InspectionKey = @InspectionKey", con)
        cmd1.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = inspectionKey

        Dim cmd2 As New SqlCommand("DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey AND HasPrinted = 0);", con)
        cmd2.CommandText += " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5)"
        cmd2.CommandText += " BEGIN SELECT * FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey AND HasPrinted = 0 ORDER BY InspectionLineKey; END"
        cmd2.CommandText += " ELSE BEGIN SELECT * FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey AND HasPrinted = -1 END"
        cmd2.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = inspectionKey

        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)
        Dim myAdapter1 As New SqlDataAdapter(cmd1)
        Dim myAdapter2 As New SqlDataAdapter(cmd2)

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.Fill(ds, "QCInspectionLineTable")
        myAdapter1.Fill(ds, "QCInspectionHeaderTable")
        myAdapter2.Fill(ds, "QCInspectionFirstPieceTable")
        con.Close()
        If ds.Tables("QCInspectionFirstPieceTable").Rows.Count = 0 Then
            cmd2.CommandText = "DECLARE @MAXDate datetime2 = (SELECT isnull(MAX(InspectionDateTime), DATEADD(day, -6, CURRENT_TIMESTAMP)) FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey);"
            cmd2.CommandText += " IF (DATEDIFF(d, @MAXDate, CURRENT_TIMESTAMP) <= 5)"
            cmd2.CommandText += " BEGIN SELECT QCInspectionFirstPieceTable.* FROM QCInspectionFirstPieceTable INNER JOIN QCInspectionLineTable ON QCInspectionFirstPieceTable.InspectionKey = QCInspectionLineTable.InspectionKey AND QCInspectionFirstPieceTable.InspectionLineKey = QCInspectionLineTable.InspectionLineNumber WHERE QCInspectionLineTable.InspectionKey = @InspectionKey  and InspectionDateTime = @MAXDate ORDER BY InspectionLineKey; END"
            cmd2.CommandText += " ELSE BEGIN SELECT * FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey AND HasPrinted = -1 END"
            myAdapter2 = New SqlDataAdapter(cmd2)
            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter2.Fill(ds, "QCInspectionFirstPieceTable")
            con.Close()
            ''Ask if the user wants to print the most recent test entry from QC
            If ds.Tables("QCInspectionFirstPieceTable").Rows.Count <> 0 AndAlso MessageBox.Show("Do you wish to print the most recent first piece inspection results on the inspection sheet?", "Print first piece", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                ds.Tables("QCInspectionFirstPieceTable").Rows.Clear()
            End If
        End If

        While ds.Tables("QCInspectionLineTable").Rows.Count Mod 12 <> 0
            ds.Tables("QCInspectionLineTable").Rows.Add(inspectionKey, ds.Tables("QCInspectionLineTable").Rows.Count + 1, "", "", "", "", "", "", "", "")
        End While

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport As New CRXQCInspectionReport()
        MyReport.SetDataSource(ds)
        crvQCInspectionReport.ReportSource = MyReport

    End Sub

    Private Sub UpdateInspectionEntry(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Updates the first piece entry to have been printed
        If Not String.IsNullOrEmpty(Key) Then
            Dim cmd As New SqlCommand("UPDATE QCInspectionFirstPieceTable SET HasPrinted = 1 WHERE InspectionKey = @InspectionKey AND HasPrinted = 0;", con)
            cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = Key

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub crvQCInspectionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crvQCInspectionReport.Load

    End Sub
End Class