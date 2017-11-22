<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnViewLog = New System.Windows.Forms.Button()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.lblSettingsSavedStatus = New System.Windows.Forms.Label()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(244, 258)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "&Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 152)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IDM"
        '
        'btnViewLog
        '
        Me.btnViewLog.Location = New System.Drawing.Point(325, 258)
        Me.btnViewLog.Name = "btnViewLog"
        Me.btnViewLog.Size = New System.Drawing.Size(75, 23)
        Me.btnViewLog.TabIndex = 3
        Me.btnViewLog.Text = "&View log"
        Me.btnViewLog.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(148, 258)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(91, 23)
        Me.btnSaveSettings.TabIndex = 4
        Me.btnSaveSettings.Text = "&Save settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'lblSettingsSavedStatus
        '
        Me.lblSettingsSavedStatus.AutoSize = True
        Me.lblSettingsSavedStatus.Location = New System.Drawing.Point(9, 268)
        Me.lblSettingsSavedStatus.Name = "lblSettingsSavedStatus"
        Me.lblSettingsSavedStatus.Size = New System.Drawing.Size(116, 13)
        Me.lblSettingsSavedStatus.TabIndex = 5
        Me.lblSettingsSavedStatus.Text = "lblSettingsSavedStatus"
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(406, 258)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(125, 23)
        Me.btnQuit.TabIndex = 6
        Me.btnQuit.Text = "&Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 285)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lblSettingsSavedStatus)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.btnViewLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Wartsila.DCM365.IDMUploader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnViewLog As Button
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents lblSettingsSavedStatus As Label
    Friend WithEvents btnQuit As Button
End Class
