
Imports Indictus.Common

Public Class StringUtilsTester

    Public Shared Function IsInDelimitedString(ByVal bExpectedResult As Boolean, _
                                               ByVal sDelimitedString As String, _
                                               ByVal sDelimiter As String, _
                                               ByVal sStringToFind As String, _
                                               ByVal bCaseSensitive As Boolean) As Boolean

        Try
            Return (bExpectedResult = Toolbox.StringUtils.IsInDelimitedString(sDelimitedString, sDelimiter, sStringToFind, bCaseSensitive))
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

End Class
