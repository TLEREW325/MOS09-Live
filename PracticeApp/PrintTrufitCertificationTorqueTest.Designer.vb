﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintTrufitCertificationTorqueTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CRVViewTorqueTest = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FielToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FielToolStripMenuItem
        '
        Me.FielToolStripMenuItem.Name = "FielToolStripMenuItem"
        Me.FielToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FielToolStripMenuItem.Text = "File"
        '
        'CRVViewTorqueTest
        '
        Me.CRVViewTorqueTest.ActiveViewIndex = -1
        Me.CRVViewTorqueTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVViewTorqueTest.DisplayGroupTree = False
        Me.CRVViewTorqueTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVViewTorqueTest.Location = New System.Drawing.Point(0, 24)
        Me.CRVViewTorqueTest.Name = "CRVViewTorqueTest"
        Me.CRVViewTorqueTest.SelectionFormula = ""
        Me.CRVViewTorqueTest.Size = New System.Drawing.Size(1034, 737)
        Me.CRVViewTorqueTest.TabIndex = 1
        Me.CRVViewTorqueTest.ViewTimeSelectionFormula = ""
        '
        'ViewTorqueCertification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 761)
        Me.Controls.Add(Me.CRVViewTorqueTest)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewTorqueCertification"
        Me.Text = "View Torque Certification"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRVViewTorqueTest As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
