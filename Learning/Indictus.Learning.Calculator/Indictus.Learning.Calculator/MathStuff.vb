
Public Class MathStuff

    Public Function Calculate(ByVal iFirst As Integer, ByVal iSecond As Integer, ByVal sOp As String)

        Dim iResult As Integer = 0

        Try
            Select Case sOp
                Case "+" : iResult = iFirst + iSecond
                Case "-" : iResult = iFirst - iSecond
                Case "/" : iResult = iFirst / iSecond
                Case "*" : iResult = iFirst * iSecond
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return iResult

    End Function

End Class
