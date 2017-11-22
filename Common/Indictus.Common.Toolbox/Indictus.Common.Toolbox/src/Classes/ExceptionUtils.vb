
Imports System.Text

Public Class ExceptionUtils
    Inherits BaseUtils

    Public Shared Function ExceptionToString(ByVal exc As Exception) As String

        Dim sb As New StringBuilder

        Try
            Try
                sb.AppendLine("Message: " & exc.Message.ToString)
            Catch ex As Exception
            End Try
            Try
                sb.AppendLine("Source: " & exc.Source.ToString)
            Catch ex As Exception
            End Try
            Try
                sb.AppendLine("TargetSite: " & exc.TargetSite.ToString)
            Catch ex As Exception
            End Try
            Try
                sb.AppendLine("StackTrace: " & exc.StackTrace.ToString)
            Catch ex As Exception
            End Try
            Try
                sb.AppendLine("HelpLink: " & exc.HelpLink.ToString)
            Catch ex As Exception
            End Try
            Try
                sb.AppendLine("InnerException: " & exc.InnerException.ToString)
            Catch ex As Exception
            End Try
        Catch exx As Exception
        End Try

        Return sb.ToString

    End Function

End Class
