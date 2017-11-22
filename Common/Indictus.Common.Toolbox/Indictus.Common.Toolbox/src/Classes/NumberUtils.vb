
Public Class NumberUtils
    Inherits BaseUtils

    Public Shared Function IsBetween(ByVal iLowerNr As Integer, ByVal iNr As Integer, ByVal iUpperNr As Integer) As Boolean

        Dim b As Boolean = False

        Try
            b = (iLowerNr <= iNr) AndAlso (iNr <= iUpperNr)
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

End Class
