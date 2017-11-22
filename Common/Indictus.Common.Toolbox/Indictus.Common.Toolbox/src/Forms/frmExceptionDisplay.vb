
Imports System.Text


Public Class frmExceptionDisplay
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAdvanced As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAppErrMsg As System.Windows.Forms.TextBox
    Friend WithEvents txtUserErrMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHelpLink As System.Windows.Forms.TextBox
    Friend WithEvents txtInnerException As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtStackTrace As System.Windows.Forms.TextBox
    Friend WithEvents txtTargetSite As System.Windows.Forms.TextBox
    Friend WithEvents tooltip As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExceptionDisplay))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAdvanced = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserErrMsg = New System.Windows.Forms.TextBox()
        Me.txtAppErrMsg = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTargetSite = New System.Windows.Forms.TextBox()
        Me.txtStackTrace = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtInnerException = New System.Windows.Forms.TextBox()
        Me.txtHelpLink = New System.Windows.Forms.TextBox()
        Me.tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(280, 192)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 24)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        '
        'btnAdvanced
        '
        Me.btnAdvanced.Location = New System.Drawing.Point(184, 192)
        Me.btnAdvanced.Name = "btnAdvanced"
        Me.btnAdvanced.Size = New System.Drawing.Size(88, 24)
        Me.btnAdvanced.TabIndex = 1
        Me.btnAdvanced.Tag = "ADVANCED"
        Me.btnAdvanced.Text = "&Advanced >>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtUserErrMsg)
        Me.GroupBox1.Controls.Add(Me.txtAppErrMsg)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 176)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Simple"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 48)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Error message:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 48)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Application error:"
        '
        'txtUserErrMsg
        '
        Me.txtUserErrMsg.Location = New System.Drawing.Point(88, 16)
        Me.txtUserErrMsg.Multiline = True
        Me.txtUserErrMsg.Name = "txtUserErrMsg"
        Me.txtUserErrMsg.ReadOnly = True
        Me.txtUserErrMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUserErrMsg.Size = New System.Drawing.Size(232, 72)
        Me.txtUserErrMsg.TabIndex = 1
        '
        'txtAppErrMsg
        '
        Me.txtAppErrMsg.Location = New System.Drawing.Point(88, 96)
        Me.txtAppErrMsg.Multiline = True
        Me.txtAppErrMsg.Name = "txtAppErrMsg"
        Me.txtAppErrMsg.ReadOnly = True
        Me.txtAppErrMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAppErrMsg.Size = New System.Drawing.Size(232, 72)
        Me.txtAppErrMsg.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtTargetSite)
        Me.GroupBox2.Controls.Add(Me.txtStackTrace)
        Me.GroupBox2.Controls.Add(Me.txtSource)
        Me.GroupBox2.Controls.Add(Me.txtInnerException)
        Me.GroupBox2.Controls.Add(Me.txtHelpLink)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 256)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Advanced"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 24)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Internal error:"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Source:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Stack:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Target:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Help:"
        '
        'txtTargetSite
        '
        Me.txtTargetSite.Location = New System.Drawing.Point(88, 208)
        Me.txtTargetSite.Multiline = True
        Me.txtTargetSite.Name = "txtTargetSite"
        Me.txtTargetSite.ReadOnly = True
        Me.txtTargetSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTargetSite.Size = New System.Drawing.Size(232, 40)
        Me.txtTargetSite.TabIndex = 8
        '
        'txtStackTrace
        '
        Me.txtStackTrace.Location = New System.Drawing.Point(88, 160)
        Me.txtStackTrace.Multiline = True
        Me.txtStackTrace.Name = "txtStackTrace"
        Me.txtStackTrace.ReadOnly = True
        Me.txtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStackTrace.Size = New System.Drawing.Size(232, 40)
        Me.txtStackTrace.TabIndex = 7
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(88, 112)
        Me.txtSource.Multiline = True
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSource.Size = New System.Drawing.Size(232, 40)
        Me.txtSource.TabIndex = 6
        '
        'txtInnerException
        '
        Me.txtInnerException.Location = New System.Drawing.Point(88, 64)
        Me.txtInnerException.Multiline = True
        Me.txtInnerException.Name = "txtInnerException"
        Me.txtInnerException.ReadOnly = True
        Me.txtInnerException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInnerException.Size = New System.Drawing.Size(232, 40)
        Me.txtInnerException.TabIndex = 5
        '
        'txtHelpLink
        '
        Me.txtHelpLink.Location = New System.Drawing.Point(88, 16)
        Me.txtHelpLink.Multiline = True
        Me.txtHelpLink.Name = "txtHelpLink"
        Me.txtHelpLink.ReadOnly = True
        Me.txtHelpLink.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHelpLink.Size = New System.Drawing.Size(232, 40)
        Me.txtHelpLink.TabIndex = 4
        '
        'frmExceptionDisplay
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(346, 487)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAdvanced)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExceptionDisplay"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Error display"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Init(ByVal ex As Exception,
                    ByVal sErrMsg As String)

        Me.Text = "Error message"
        Me.Height = 248


        'sErrMsg
        '-------------------------------------------------
        If sErrMsg.Equals("") Then
            Me.txtUserErrMsg.Text = "This is an unknown error or there is no error message provided!"
            'Me.txtUserErrMsg.Text = "Felmeddelande ej tillgängligt!"
        Else
            Me.txtUserErrMsg.Text = sErrMsg
        End If


        'ex.Message
        '-------------------------------------------------
        Try
            Me.txtAppErrMsg.Text = ex.Message.Trim
        Catch ex2 As Exception
        End Try


        'ex.HelpLink
        '-------------------------------------------------
        Try
            Me.txtHelpLink.Text = ex.HelpLink.Trim
        Catch ex3 As Exception
        End Try


        'ex.InnerException
        '-------------------------------------------------
        Try
            Me.txtInnerException.Text = ex.InnerException.Message.Trim
        Catch ex4 As Exception
        End Try


        'ex.Source
        '-------------------------------------------------
        Try
            Me.txtSource.Text = ex.Source.Trim
        Catch ex5 As Exception
        End Try


        'ex.StackTrace
        '-------------------------------------------------
        Try
            Me.txtStackTrace.Text = ex.StackTrace.Trim
        Catch ex6 As Exception
        End Try


        'ex.TargetSite
        '-------------------------------------------------
        Try
            Me.txtTargetSite.Text = ex.TargetSite.ToString.Trim
        Catch ex7 As Exception
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdvanced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvanced.Click

        Try
            If Me.btnAdvanced.Tag.Equals("ADVANCED") Then
                Me.btnAdvanced.Text = "Simple >>"
                Me.btnAdvanced.Tag = "SIMPLE"
                'Me.tooltip.SetToolTip(Me.btnAdvanced, ToolTips.FRMFRMEXCEPTIONDISPLAY_BASIC)
                Me.Height = 512
            ElseIf Me.btnAdvanced.Tag.Equals("SIMPLE") Then
                Me.btnAdvanced.Text = "Advanced >>"
                Me.btnAdvanced.Tag = "ADVANCED"
                'Me.tooltip.SetToolTip(Me.btnAdvanced, ToolTips.FRMFRMEXCEPTIONDISPLAY_ADVANCED)
                Me.Height = 248
            End If
        Catch ex As Exception
        Finally
        End Try

    End Sub

End Class
