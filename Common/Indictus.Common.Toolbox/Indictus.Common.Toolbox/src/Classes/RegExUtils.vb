
Imports System.Text.RegularExpressions

Public Class RegExUtils
    Inherits BaseUtils

    Public Shared Function IsMatch(ByVal sStr As String, _
                                   ByVal sRegEx As String) As Boolean

        Try
            Return Regex.IsMatch(sStr, sRegEx, RegexOptions.None)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

End Class
