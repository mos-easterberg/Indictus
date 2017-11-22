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
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnRunTests = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInput2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInput3 = New System.Windows.Forms.TextBox()
        Me.btnEmpty = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(2, 76)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(546, 223)
        Me.txtMsg.TabIndex = 3
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(473, 306)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Text = "&Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnRunTests
        '
        Me.btnRunTests.Location = New System.Drawing.Point(473, 47)
        Me.btnRunTests.Name = "btnRunTests"
        Me.btnRunTests.Size = New System.Drawing.Size(75, 23)
        Me.btnRunTests.TabIndex = 4
        Me.btnRunTests.Text = "&Run tests"
        Me.btnRunTests.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Input #1:"
        '
        'txtInput1
        '
        Me.txtInput1.Location = New System.Drawing.Point(57, 6)
        Me.txtInput1.Name = "txtInput1"
        Me.txtInput1.Size = New System.Drawing.Size(266, 20)
        Me.txtInput1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Input #2:"
        '
        'txtInput2
        '
        Me.txtInput2.Location = New System.Drawing.Point(57, 28)
        Me.txtInput2.Name = "txtInput2"
        Me.txtInput2.Size = New System.Drawing.Size(266, 20)
        Me.txtInput2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Input #3:"
        '
        'txtInput3
        '
        Me.txtInput3.Location = New System.Drawing.Point(57, 50)
        Me.txtInput3.Name = "txtInput3"
        Me.txtInput3.Size = New System.Drawing.Size(266, 20)
        Me.txtInput3.TabIndex = 2
        '
        'btnEmpty
        '
        Me.btnEmpty.Location = New System.Drawing.Point(392, 47)
        Me.btnEmpty.Name = "btnEmpty"
        Me.btnEmpty.Size = New System.Drawing.Size(75, 23)
        Me.btnEmpty.TabIndex = 6
        Me.btnEmpty.Text = "&Empty"
        Me.btnEmpty.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 332)
        Me.Controls.Add(Me.btnEmpty)
        Me.Controls.Add(Me.txtInput3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInput2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInput1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRunTests)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.txtMsg)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indictus.Common.ToolboxTester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnRunTests As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInput1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInput2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInput3 As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpty As System.Windows.Forms.Button

End Class
