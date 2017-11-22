
Imports System.Text

Public Class EncryptionUtils
    Inherits BaseUtils

    Public Shared Function SimpleEncrypt(ByVal sStr As String) As String

        Try
            Return EncryptionUtils.SimpleEncrypt(sStr, True)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function SimpleEncrypt(ByVal sStr As String, _
                                         ByVal bReplaceWhiteSpaceWithUnderScore As Boolean) As String

        Dim i As Integer
        Dim s As String
        Dim rnd As Integer
        Dim sb As New StringBuilder

        Try
            rnd = (Date.Now.Millisecond Mod 8) + 1

            sb.Append(Chr(rnd + 100))
            For i = 0 To sStr.Length - 1
                s = Chr(Asc(sStr.Substring(i, 1)) + rnd)
                If bReplaceWhiteSpaceWithUnderScore Then s = s.Replace(" ", "_")
                sb.Append(s)
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function SimpleDecrypt(ByVal sStr As String) As String

        Try
            Return EncryptionUtils.SimpleDecrypt(sStr, True)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function SimpleDecrypt(ByVal sStr As String,
                                         ByVal bReplaceUnderScoreWithWhiteSpace As Boolean) As String

        Dim i As Integer
        Dim s As String
        Dim rnd As Integer
        Dim sb As New StringBuilder

        Try
            sStr = sStr.Trim
            If sStr.Length = 0 Then Return String.Empty
            rnd = Asc(sStr.Substring(0, 1)) - 100

            For i = 1 To sStr.Length - 1
                s = Chr(Asc(sStr.Substring(i, 1)) - rnd).ToString
                If bReplaceUnderScoreWithWhiteSpace Then s = s.Replace("_", " ")
                sb.Append(s)
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString.Trim

    End Function

    Public Shared Function KeyEncrypt(ByVal sStr As String, ByVal sKey As String) As String

        Dim sRandPart As String = "_f79y349yrf9efd7fye7y374fec74y8e74_"

        Try
            sStr = sStr.Trim
            sKey = sKey.Trim

            If sStr.ToUpper.Equals(sKey.ToUpper) Then Return String.Empty
            If StringUtils.IsNullOrWhiteSpace(sStr) Or StringUtils.IsNullOrWhiteSpace(sKey) Then Return String.Empty
            If sKey.Length < 10 Or sKey.Length > 256 Then Return String.Empty

            Return SimpleEncrypt(SimpleEncrypt(sStr & sRandPart & sKey), False)
        Catch ex As Exception
            Throw ex
        End Try

        Return String.Empty

    End Function

    Public Shared Function KeyDecrypt(ByVal sStr As String, ByVal sKey As String) As String

        Dim sRet As String = ""
        Dim sRandPart As String = "_f79y349yrf9efd7fye7y374fec74y8e74_"

        Try
            sStr = sStr.Trim
            sKey = sKey.Trim

            If StringUtils.IsNullOrWhiteSpace(sStr) Or StringUtils.IsNullOrWhiteSpace(sKey) Then Return String.Empty
            If sKey.Length < 10 Or sKey.Length > 256 Then Return String.Empty

            sRet = SimpleDecrypt(SimpleDecrypt(sStr), False)
            If sRet.Contains(sRandPart & sKey) Then
                Dim iPos As Integer = sRet.IndexOf(sRandPart) + sRandPart.Length
                Dim sKeyPart As String = sRet.Substring(iPos, sRet.Length - iPos)
                If sKeyPart.Equals(sKey) Then
                    Dim jPos As Integer = sRet.IndexOf(sRandPart)
                    sRet = sRet.Substring(0, jPos)
                Else
                    sRet = ""
                End If
            Else
                sRet = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return sRet

    End Function

End Class
