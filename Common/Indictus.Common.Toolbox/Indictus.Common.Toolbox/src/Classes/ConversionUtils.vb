
Imports System.Text
Imports System.Globalization

Public Class ConversionUtils
    Inherits BaseUtils

    Public Enum ConversionCoefficient
        KB
        MB
        GB
    End Enum

    Public Shared Function ConvertBytes(ByVal lBytes As Long, ByVal coff As ConversionCoefficient) As Double

        Dim iDivisor As Integer
        Dim d As Double = 0.0

        Try
            Select Case coff
                Case ConversionCoefficient.KB : iDivisor = 1024
                Case ConversionCoefficient.MB : iDivisor = 1024 * 1024
                Case ConversionCoefficient.GB : iDivisor = 1024 * 1024 * 1024
            End Select

            d = Math.Round((lBytes / iDivisor), 0)

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return d

    End Function

    Public Shared Function ParseBoolean(ByVal s As String, ByVal bThrowException As Boolean) As Boolean

        Try
            Select Case s.ToUpper
                Case "FALSE" : Return False
                Case "TRUE" : Return True
            End Select
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return Nothing

    End Function

    'Public Shared Function ParseBoolean(ByVal obj As Object, ByVal bThrowException As Boolean) As Boolean

    '    Dim b As Boolean = False

    '    Try
    '        Select Case GetType(Object)

    '        End Select
    '    Catch ex As Exception
    '        If bThrowException Then Throw ex
    '    End Try

    '    Return Nothing

    'End Function

    Public Shared Function ParseInteger(ByVal s As String, ByVal bThrowException As Boolean) As Integer

        Try
            Return Integer.Parse(s)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ParseString(ByVal obj As Object, ByVal bThrowException As Boolean) As String

        Dim s As String = ""

        Try
            s = New String(obj.ToString)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return s

    End Function

    Public Shared Function ParseDecimal(ByVal s As String, ByVal bThrowException As Boolean) As Decimal

        Try
            Return Decimal.Parse(s)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ParseDecimal(ByVal s As String,
                                       ByVal sCurrentDecimalSeparator As Char,
                                       ByVal sNewDecimalSeparator As Char,
                                       ByVal bThrowException As Boolean) As Decimal

        Dim dec As Decimal = Nothing

        Try
            If s.Contains(sCurrentDecimalSeparator) Then s = s.Replace(sCurrentDecimalSeparator, sNewDecimalSeparator)
            dec = Decimal.Parse(s)
        Catch ex As Exception
            dec = Nothing
            If bThrowException Then Throw ex
        End Try

        Return dec

    End Function

    Public Shared Function ParseDouble(ByVal s As String, ByVal bThrowException As Boolean) As Double

        Try
            Return Double.Parse(s)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ParseDouble(ByVal s As String,
                                       ByVal sCurrentDecimalSeparator As Char,
                                       ByVal sNewDecimalSeparator As Char,
                                       ByVal bThrowException As Boolean) As Double

        Dim d As Double = Nothing

        Try
            If s.Contains(sCurrentDecimalSeparator) Then s = s.Replace(sCurrentDecimalSeparator, sNewDecimalSeparator)
            d = Double.Parse(s)
        Catch ex As Exception
            d = Nothing
            If bThrowException Then Throw ex
        End Try

        Return d

    End Function

    Public Shared Function ParseDate(ByVal s As String, ByVal bThrowException As Boolean) As Date

        Try
            Return CDate(s)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ConvertDataSetToString(ByVal ds As DataSet,
                                                  ByVal iTableIndex As Integer,
                                                  ByVal iColumnIndex As Integer) As String

        Dim sRet As String = ""

        Try

            For Each row As DataRow In ds.Tables(iTableIndex).Rows
                sRet = sRet & row.Item(iColumnIndex).ToString & ","
            Next
            If sRet.EndsWith(",") Then
                sRet = sRet.Remove(sRet.Length - 1, 1)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            ds = Nothing
        End Try

        Return sRet

    End Function

    Public Shared Function ConvertDataRowToString(ByVal dr As DataRow) As String

        Dim sb As New StringBuilder
        Dim sRet As String = ""

        Try
            For Each si As String In dr.ItemArray
                sb.Append(si & ",")
            Next

            sRet = sb.ToString
            If sRet.EndsWith(",") Then sRet = sRet.Remove(sRet.Length - 1, 1)

        Catch ex As Exception
            Throw ex
        End Try

        Return sRet

    End Function

End Class
