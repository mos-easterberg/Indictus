
Imports System.Text
Imports System.Security

Public Class EncodingUtils
    Inherits BaseUtils

    Public Shared Function UniCodeToXML(ByVal sString As String) As String

        Dim sb As New StringBuilder

        Try
            For Each c As Char In sString.ToCharArray()
                If Not EncodingUtils.IsCharInRange(c, 65, 90) AndAlso Not EncodingUtils.IsCharInRange(c, 97, 122) Then
                    sb.Append("&#" & AscW(c) & ";")
                Else
                    sb.Append(c)
                End If
            Next

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function IsCharInRange(ByVal c As Char, _
                                         ByVal iLowerBoundary As Integer, _
                                         ByVal iUpperBoundary As Integer) As Boolean

        Dim b As Boolean = False
        Dim i As Integer = 0

        Try
            i = AscW(c)
            If i >= iLowerBoundary Then
                If i <= iUpperBoundary Then
                    b = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function TranslateStringToEncoding(ByVal sEncoding As String) As System.Text.Encoding

        Dim encoding As System.Text.Encoding = Nothing

        Try
            Select Case sEncoding
                Case "ASCII" : encoding = New System.Text.ASCIIEncoding
                Case "UNICODE" : encoding = New System.Text.UnicodeEncoding
                Case "UTF7" : encoding = New System.Text.UTF7Encoding
                Case "UTF8" : encoding = New System.Text.UTF8Encoding
                Case "UTF32" : encoding = New System.Text.UTF32Encoding

                Case Else : encoding = Nothing
            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return encoding

    End Function

    Public Shared Function TranslateToNETSecureString(ByVal sStringToSecure As String) As SecureString

        Dim secure As New SecureString

        Try
            For Each c As Char In sStringToSecure.ToCharArray
                secure.AppendChar(c)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return secure

    End Function

    Public Shared Function EncodeString(ByVal sStr As String, ByVal encoding As System.Text.Encoding, ByVal bThrowEx As Boolean) As String

        Try
            Dim encodedString() As Byte = encoding.GetBytes(sStr)
            Return encoding.GetString(encodedString)
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function EncodeUTF8String(ByVal sStr As String, ByVal bEmitBOM As Boolean, ByVal bThrowEx As Boolean) As String

        Try
            Dim utf8 As New System.Text.UTF8Encoding(bEmitBOM)
            Dim encodedString() As Byte = utf8.GetBytes(sStr)
            Return utf8.GetString(encodedString)
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

End Class
