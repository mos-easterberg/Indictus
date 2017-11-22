
Imports Indictus.Common

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnMatch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtString As System.Windows.Forms.TextBox
    Friend WithEvents txtRegExp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMatch As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnMatch = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblMatch = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRegExp = New System.Windows.Forms.TextBox()
        Me.txtString = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMatch
        '
        Me.btnMatch.Location = New System.Drawing.Point(72, 80)
        Me.btnMatch.Name = "btnMatch"
        Me.btnMatch.Size = New System.Drawing.Size(72, 24)
        Me.btnMatch.TabIndex = 3
        Me.btnMatch.Text = "&Match?"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(216, 136)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "&Exit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMatch)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtRegExp)
        Me.GroupBox1.Controls.Add(Me.txtString)
        Me.GroupBox1.Controls.Add(Me.btnMatch)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 112)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblMatch
        '
        Me.lblMatch.Location = New System.Drawing.Point(152, 88)
        Me.lblMatch.Name = "lblMatch"
        Me.lblMatch.Size = New System.Drawing.Size(72, 16)
        Me.lblMatch.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "RegExp:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "String:"
        '
        'txtRegExp
        '
        Me.txtRegExp.Location = New System.Drawing.Point(72, 48)
        Me.txtRegExp.Name = "txtRegExp"
        Me.txtRegExp.Size = New System.Drawing.Size(200, 20)
        Me.txtRegExp.TabIndex = 2
        '
        'txtString
        '
        Me.txtString.Location = New System.Drawing.Point(72, 24)
        Me.txtString.Name = "txtString"
        Me.txtString.Size = New System.Drawing.Size(200, 20)
        Me.txtString.TabIndex = 1
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnMatch
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(292, 165)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "RegexTester"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatch.Click

        Try
            If Toolbox.RegExUtils.IsMatch(Me.txtString.Text.Trim, Me.txtRegExp.Text.Trim) Then
                Me.lblMatch.Text = "Yes!"
            Else
                Me.lblMatch.Text = "No!"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtRegExp.Focus()
        End Try

    End Sub

    Private Sub txtString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtString.TextChanged
        Me.btnMatch.Enabled = Me.txtString.Text.Length > 0
    End Sub

    Private Sub txtRegExp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegExp.TextChanged
        Me.btnMatch.Enabled = Me.txtRegExp.Text.Length > 0
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnMatch.Enabled = False
    End Sub

End Class
