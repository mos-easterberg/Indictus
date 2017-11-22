
Imports Indictus.Common.Settings

Imports System.Text

Public Class AppSettings
    Inherits ApplicationBaseSettings
    Implements ISettings

    Public Overrides Function ToString() As String Implements ISettings.ToString

        Dim sb As New StringBuilder

        Try
            sb.AppendLine("ApplicationName: " & MyBase.ApplicationName)
            sb.AppendLine("ApplicationLanguage: " & MyBase.ApplicationLanguage)
            sb.AppendLine("ConfirmExit: " & MyBase.ConfirmExit)
            sb.AppendLine("SaveSettingsOnExit: " & MyBase.SaveSettingsOnExit)
        Catch ex As Exception
        Finally
        End Try

        Return sb.ToString

    End Function

End Class
