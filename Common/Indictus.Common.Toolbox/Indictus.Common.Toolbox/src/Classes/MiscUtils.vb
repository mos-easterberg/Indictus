
Public Class MiscUtils
    Inherits BaseUtils

    Public Shared Function GetAlphabet(ByVal language As LanguageUtils.Language) As String()

        Dim alphabet() As String = Nothing

        Try
            Select Case language
                Case LanguageUtils.Language.ENGLISH
                    alphabet = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                Case LanguageUtils.Language.SWEDISH, LanguageUtils.Language.FINNISH
                    alphabet = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö"}
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return alphabet

    End Function

    Public Shared Function CalculatePriceExclVAT(ByVal dNetPrice As Double, _
                                                 ByVal iTaxPercentage As Integer, _
                                                 ByVal bPadCents As Boolean) As String

        Dim dPriceExclVAT As Double = 0.0
        Dim dTaxPercentage As Double = 0.0
        Dim arr As ArrayList = Nothing
        Dim s As String = ""

        Try
            dTaxPercentage = (iTaxPercentage / 100) + 1
            dPriceExclVAT = Math.Round(dNetPrice / dTaxPercentage, 2)
            arr = StringUtils.Split(dPriceExclVAT.ToString, ",")
            arr(1) = StringUtils.Pad(arr(1), "0", 2, StringUtils.PadDirection.RIGHT)
            s = arr.Item(0).ToString & "," & arr.Item(1).ToString
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return s

    End Function

    Public Shared Function GetEntityKey() As String

        Try
            Return Guid.NewGuid.ToString
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function GetApplicationTitle(ByVal sAppName As String, ByVal sAppVersion As String) As String

        Try
            Return sAppName & " v" & sAppVersion
        Catch ex As Exception
            Throw ex
        End Try

        Return ""

    End Function

    Public Shared Sub ShowNotYetImplementedMessage()

        Try
            Toolbox.UIUtils.ShowMessageBox("Not yet implemented!", "", UIUtils.MessageType.INFO)
        Catch ex As Exception
        End Try

    End Sub

End Class
