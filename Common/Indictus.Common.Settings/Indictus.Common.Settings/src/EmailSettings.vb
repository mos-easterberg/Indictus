
Imports System.Text

Public NotInheritable Class EmailSettings
    Implements ISettings

    Public Property ReceiverAddress As String
    Public Property ServerName As String
    Public Property PortNumber As Integer
    Public Property EnableSSL As Boolean
    Public Property FromAddress As String
    Public Property SendTimeoutSeconds As Integer
    Public Property ReplyToAddress As String

    Public Overrides Function ToString() As String Implements ISettings.ToString

        Dim sb As New StringBuilder

        Try
            sb.AppendLine("EnableSSL: " & Me.EnableSSL)
            sb.AppendLine("FromAddress: " & Me.FromAddress)
            sb.AppendLine("ReceiverAddress: " & Me.ReceiverAddress)
            sb.AppendLine("SendTimeoutSeconds: " & Me.SendTimeoutSeconds)
            sb.AppendLine("ServerName: " & Me.ServerName)
            sb.AppendLine("PortNumber: " & Me.PortNumber)
            sb.AppendLine("ReplyToAddress: " & Me.ReplyToAddress)
        Catch ex As Exception
            Throw ex
        End Try

        Return sb.ToString

    End Function

End Class
