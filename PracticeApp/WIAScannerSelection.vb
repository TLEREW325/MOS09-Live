Public Class WIAScannerSelection
    Public SelectedPrinterName As String = String.Empty
    Private PrinterList As String()
    ''' <summary>
    ''' Initializes a new instance of the scanner selection screen.
    ''' </summary>
    ''' <param name="Printers">List of printers that can be selected.</param>
    ''' <remarks>Printers will be send from the local system to MOS.</remarks>
    Public Sub New(ByVal Printers As String())
        InitializeComponent()
        PrinterList = Printers

        If PrinterList.Length > 2 Then
            If PrinterList.Length > 3 Then
                Dim YPos As Integer = 165
                ''Goes through all the printers ing hte list and adds a button for any printer that is present after 3 printers
                For i As Integer = 3 To PrinterList.Length - 1
                    Dim btn As New System.Windows.Forms.Button()
                    btn.Parent = pnlPrinters
                    btn.Size = New System.Drawing.Size(232, 40)
                    btn.Location = New System.Drawing.Point(15, YPos)
                    btn.Text = PrinterList(i)
                    btn.Name = "cmdPrinter" + i.ToString()
                    AddHandler btn.Click, AddressOf btn_Click
                    pnlPrinters.Controls.Add(btn)
                Next
                If YPos + 100 > 900 Then Me.Height = 900 Else Me.Height = YPos + 100
            End If
            cmdPrinter3.Text = PrinterList(2)
            cmdPrinter3.Show()
        End If
        cmdPrinter2.Text = PrinterList(1)
        cmdPrinter1.Text = PrinterList(0)
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrinter1.Click, cmdPrinter2.Click, cmdPrinter3.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        SelectedPrinterName = CType(sender, System.Windows.Forms.Button).Text
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        SelectedPrinterName = String.Empty
        Me.Close()
    End Sub
End Class