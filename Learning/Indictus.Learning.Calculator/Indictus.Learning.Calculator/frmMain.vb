
Public Class frmMain

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        Try
            Dim m As New MathStuff
            Dim i As Integer = m.Calculate(Me.txtOne.Text, Me.txtSecond.Text, Me.cboOps.Text)
            MsgBox(i)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cboOps.Items.Add("+")
        Me.cboOps.Items.Add("-")
        Me.cboOps.Items.Add("*")
        Me.cboOps.Items.Add("/")
    End Sub
End Class
