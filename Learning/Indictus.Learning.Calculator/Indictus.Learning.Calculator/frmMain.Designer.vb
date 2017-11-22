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
        Me.txtOne = New System.Windows.Forms.TextBox()
        Me.txtSecond = New System.Windows.Forms.TextBox()
        Me.cboOps = New System.Windows.Forms.ComboBox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtOne
        '
        Me.txtOne.Location = New System.Drawing.Point(12, 12)
        Me.txtOne.Name = "txtOne"
        Me.txtOne.Size = New System.Drawing.Size(100, 20)
        Me.txtOne.TabIndex = 0
        '
        'txtSecond
        '
        Me.txtSecond.Location = New System.Drawing.Point(12, 38)
        Me.txtSecond.Name = "txtSecond"
        Me.txtSecond.Size = New System.Drawing.Size(100, 20)
        Me.txtSecond.TabIndex = 1
        '
        'cboOps
        '
        Me.cboOps.FormattingEnabled = True
        Me.cboOps.Location = New System.Drawing.Point(12, 64)
        Me.cboOps.Name = "cboOps"
        Me.cboOps.Size = New System.Drawing.Size(100, 21)
        Me.cboOps.TabIndex = 2
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(12, 103)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btnCalculate.TabIndex = 3
        Me.btnCalculate.Text = "Calculate!"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 272)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.cboOps)
        Me.Controls.Add(Me.txtSecond)
        Me.Controls.Add(Me.txtOne)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtOne As TextBox
    Friend WithEvents txtSecond As TextBox
    Friend WithEvents cboOps As ComboBox
    Friend WithEvents btnCalculate As Button
End Class
