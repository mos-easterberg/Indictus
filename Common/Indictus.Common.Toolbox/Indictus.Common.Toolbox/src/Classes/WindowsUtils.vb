
Imports System.Text

Public Class WindowsUtils
    Inherits BaseUtils

    Public Shared Function RemoveDomainFromUsername(ByVal sUsername As String) As String

        Dim iPos As Integer = 0
        Dim iLength As Integer = 0

        Try
            iPos = sUsername.IndexOf("/")
            If iPos > 0 Then
                iLength = sUsername.Length - iPos - 1
                Return sUsername.Substring(iPos + 1, iLength)
            Else
                iPos = sUsername.IndexOf("\")
                If iPos > 0 Then
                    iLength = sUsername.Length - iPos - 1
                    Return sUsername.Substring(iPos + 1, iLength)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sUsername

    End Function

    Public Shared Function GetVersion(ByVal iVersionDiligency As Integer) As String

        Dim sb As New StringBuilder
        Dim sMajor As String
        Dim sMinor As String
        Dim sRevision As String
        Dim sBuild As String
        Dim sDelimiter As String

        Try
            sDelimiter = "."
            sMajor = Environment.Version.Major.ToString
            sMinor = Environment.Version.Minor.ToString
            sRevision = Environment.Version.Revision.ToString
            sBuild = Environment.Version.Build.ToString

            Select Case iVersionDiligency
                Case 1
                    sb.Append(sMajor)
                Case 2
                    sb.Append(sMajor)
                    sb.Append(sDelimiter)
                    sb.Append(sMinor)
                Case 3
                    sb.Append(sMajor)
                    sb.Append(sDelimiter)
                    sb.Append(sMinor)
                    sb.Append(sDelimiter)
                    sb.Append(sRevision)
                Case 4
                    sb.Append(sMajor)
                    sb.Append(sDelimiter)
                    sb.Append(sMinor)
                    sb.Append(sDelimiter)
                    sb.Append(sRevision)
                    sb.Append(sDelimiter)
                    sb.Append(sBuild)
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Sub ExecuteOpenFileCommand(ByVal sFilePath As String)

        Try
            System.Diagnostics.Process.Start(sFilePath)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

End Class
