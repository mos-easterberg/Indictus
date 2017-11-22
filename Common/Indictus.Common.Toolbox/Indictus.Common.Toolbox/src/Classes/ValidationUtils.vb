
Imports System.Text.RegularExpressions

Public Class ValidationUtils
    Inherits BaseUtils

    Public Shared Function IsValidEmail(ByVal sStr As String) As Boolean

        Dim sMask As String = ""

        Try
            sMask = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            Return Regex.IsMatch(sStr, sMask)
        Catch ex As Exception
            Throw ex
        Finally
        End Try


    End Function

    Public Shared Function GetValidatedEmailAddresses(ByVal sAddresses As String, _
                                                      ByVal sDelimiter As String, _
                                                      ByVal bReturnValidAddresses As Boolean) As ArrayList

        Dim arrValids As New ArrayList
        Dim arrInvalids As New ArrayList

        Try
            For Each s As String In Toolbox.StringUtils.Split(sAddresses, sDelimiter, False)
                If Toolbox.ValidationUtils.IsValidEmail(s) Then
                    arrValids.Add(s)
                Else
                    arrInvalids.Add(s)
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        If bReturnValidAddresses Then
            Return arrValids
        Else
            Return arrInvalids
        End If

    End Function

    Public Shared Function IsValidGUID(ByVal sStr As String) As Boolean

        Dim sMask As String = ""

        Try
            '854B476E-03BA-49F5-9A68-71200480E096
            '   8    - 4  - 4  - 4  - 12 (nr of chars per section)            
            sMask = "........-....-....-....-............"
            Return Regex.IsMatch(sStr, sMask)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function IsValidPostalCode(ByVal s As String) As Boolean

        Dim i As Integer = 0

        Try
            i = Toolbox.ConversionUtils.ParseInteger(s, False)
            If i >= 1 AndAlso i <= 99999 Then Return True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return False

    End Function

End Class
