
Imports System.Text

Public NotInheritable Class LogSettings
    Implements ISettings

    Public Enum LogSizeEnum
        FULL
        BASIC
    End Enum

    Public Property LogFileName As String
    Public Property LogFolderPath As String
    Public Property LogThrowException As Boolean
    Public Property LogEmptyOnStartup As Boolean
    Public Property LogSize As LogSizeEnum

    Public Overrides Function ToString() As String Implements ISettings.ToString

        Dim sb As StringBuilder = Nothing

        Try
            sb = New StringBuilder

            sb.AppendLine("LogFileName: " & Me.LogFileName)
            sb.AppendLine("LogFolderPath: " & Me.LogFolderPath)
            sb.AppendLine("LogThrowException: " & Me.LogThrowException)
            sb.AppendLine("LogEmptyOnStartup: " & Me.LogEmptyOnStartup)
            sb.AppendLine("LogSize: " & Me.LogSize.ToString)
        Catch ex As Exception
            Throw ex
        End Try

        Return sb.ToString

    End Function

End Class
