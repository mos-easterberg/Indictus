
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
    Friend WithEvents cboAlghoritm As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optEncrypt As System.Windows.Forms.RadioButton
    Friend WithEvents optDecrypt As System.Windows.Forms.RadioButton
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents gpKey As GroupBox
    Friend WithEvents txtKey As TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboAlghoritm = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.optDecrypt = New System.Windows.Forms.RadioButton()
        Me.optEncrypt = New System.Windows.Forms.RadioButton()
        Me.gpKey = New System.Windows.Forms.GroupBox()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpKey.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(352, 192)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "&Exit"
        '
        'cboAlghoritm
        '
        Me.cboAlghoritm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlghoritm.Location = New System.Drawing.Point(8, 24)
        Me.cboAlghoritm.Name = "cboAlghoritm"
        Me.cboAlghoritm.Size = New System.Drawing.Size(144, 21)
        Me.cboAlghoritm.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboAlghoritm)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 56)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose encryption alghoritm"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(16, 72)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(384, 20)
        Me.txtData.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Controls.Add(Me.optDecrypt)
        Me.GroupBox2.Controls.Add(Me.optEncrypt)
        Me.GroupBox2.Controls.Add(Me.txtData)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 104)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Encrypt/decrypt"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(152, 40)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(56, 24)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "&Clear"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(88, 40)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(56, 24)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "&Start"
        '
        'optDecrypt
        '
        Me.optDecrypt.Location = New System.Drawing.Point(16, 48)
        Me.optDecrypt.Name = "optDecrypt"
        Me.optDecrypt.Size = New System.Drawing.Size(72, 16)
        Me.optDecrypt.TabIndex = 5
        Me.optDecrypt.Text = "Decrypt"
        '
        'optEncrypt
        '
        Me.optEncrypt.Location = New System.Drawing.Point(16, 24)
        Me.optEncrypt.Name = "optEncrypt"
        Me.optEncrypt.Size = New System.Drawing.Size(72, 16)
        Me.optEncrypt.TabIndex = 4
        Me.optEncrypt.Text = "Encrypt"
        '
        'gpKey
        '
        Me.gpKey.Controls.Add(Me.txtKey)
        Me.gpKey.Location = New System.Drawing.Point(173, 8)
        Me.gpKey.Name = "gpKey"
        Me.gpKey.Size = New System.Drawing.Size(243, 56)
        Me.gpKey.TabIndex = 3
        Me.gpKey.TabStop = False
        Me.gpKey.Text = "Key"
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(6, 25)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(229, 20)
        Me.txtKey.TabIndex = 0
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(424, 221)
        Me.Controls.Add(Me.gpKey)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "EncryptionAssistant"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpKey.ResumeLayout(False)
        Me.gpKey.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Text = "EncryptionAssistant " & My.Settings.VersionString
            Me._loadAlghoritms()
            Me.optEncrypt.Checked = True
            Me.btnStart.Enabled = False
            Me.txtData.Focus()
        Catch ex As Exception
            Me._catchException(ex)
        End Try

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me._exit()
    End Sub

    Private Sub _loadAlghoritms()
        Me.cboAlghoritm.Items.Add("SimpleEncrypt")
        Me.cboAlghoritm.Items.Add("KeyEncrypt")
        Me.cboAlghoritm.Text = Me.cboAlghoritm.Items.Item(1).ToString
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Try
            If Me.optEncrypt.Checked Then
                Me.txtData.Text = Me._encrypt(Me.cboAlghoritm.Text, Me.txtData.Text)
            Else
                Me.txtData.Text = Me._decrypt(Me.cboAlghoritm.Text, Me.txtData.Text)
            End If
        Catch ex As Exception
            Me._catchException(ex)
        End Try

    End Sub

    Private Function _encrypt(ByVal sAlghoritm As String,
                              ByVal sData As String) As String

        Dim s As String = ""

        Try
            Select Case sAlghoritm.ToUpper
                Case "SIMPLEENCRYPT" : s = Toolbox.EncryptionUtils.SimpleEncrypt(sData)
                Case "KEYENCRYPT" : s = Toolbox.EncryptionUtils.KeyEncrypt(sData, Me.txtKey.Text.Trim)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return s

    End Function

    Private Function _decrypt(ByVal sAlghoritm As String,
                              ByVal sData As String) As String

        Dim s As String = ""

        Try
            Select Case sAlghoritm.ToUpper
                Case "SIMPLEENCRYPT" : s = Toolbox.EncryptionUtils.SimpleDecrypt(sData)
                Case "KEYENCRYPT" : s = Toolbox.EncryptionUtils.KeyDecrypt(sData, Me.txtKey.Text.Trim)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return s

    End Function

    Private Sub txtData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtData.TextChanged
        Me.btnStart.Enabled = (Me.txtData.Text.Length > 0)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtData.Text = ""
    End Sub

    Private Sub _catchException(ByVal exception As Exception)

        Try
            MsgBox(exception.Message)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub _exit()

        Try
            Application.ExitThread()
            Application.Exit()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboAlghoritm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlghoritm.SelectedIndexChanged

        Try
            Me.txtKey.Clear()
            If cboAlghoritm.Text.ToUpper.Equals("KEYENCRYPT") Then
                Me.gpKey.Enabled = True
            Else
                Me.gpKey.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
