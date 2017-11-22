
Imports Indictus.Common
Imports Indictus.SharePoint.SharePointToolbox
Imports Microsoft.SharePoint.Client
'Imports System.Text
Imports Indictus.SharePoint.Authentication
'Imports ClientObjectModelSample

Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._noName()
        'Me._massCreateItems()
    End Sub

    Private Sub _noName()

        Try
            'Dim client As ClientObjectModelSample.ClientObjectModelSample = AuthManager.AuthenticateReturnClient("https://euroskogruppen.sharepoint.com")
            'Dim conn As ClientContext = client.getContext("https://euroskogruppen.sharepoint.com/sites/KP")
            Dim conn As ClientContext = SPHelper.ConnectToSPO("https://euroskogruppen.sharepoint.com/sites/KP", "magnus@euroskogruppen.com", "MagCapEurSko_991")

            Dim arr As New ArrayList({"PERIODEFAKTURA", "KONTOUTDRAG", "BILAG"})
            Dim dict As Dictionary(Of String, Integer) = SPHelper.CountNrOfFilesPerFolder(conn, "Kontoutdrag og Periodefaktura", arr)

            Dim sb As New System.Text.StringBuilder
            For Each kvp As KeyValuePair(Of String, Integer) In dict
                sb.AppendLine(kvp.Key.ToString & ";" & kvp.Value.ToString)
            Next
            Me.txtOutput.AppendText(sb.ToString)

        Catch ex As Exception
            Toolbox.UIUtils.ShowMessageBox(ex.Message, "", Toolbox.UIUtils.MessageType.WARNING)
        End Try

    End Sub

    Private Sub _massCreateItems()

        Try
            Dim conn As ClientContext = SPHelper.ConnectToSPO("https://yndesdal.sharepoint.com/moslab", "magnus@365sky.no", "")

            For i As Integer = 5000 To 5001
                Dim dict As New Dictionary(Of String, String)
                dict.Add("OrderNumber", i)
                dict.Add("Title", i)
                dict.Add("Thousand", "5000")
                SPHelper.AddListItem(conn, "bautalist", dict)
                Debug.WriteLine(i)
            Next

            MsgBox("done!")
        Catch ex As Exception
            Toolbox.UIUtils.ShowMessageBox(ex.Message, "", Toolbox.UIUtils.MessageType.WARNING)
        End Try

    End Sub

End Class