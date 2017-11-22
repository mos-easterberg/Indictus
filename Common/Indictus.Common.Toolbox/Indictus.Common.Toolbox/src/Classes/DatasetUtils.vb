
Imports System.Text

Public Class DatasetUtils
    Inherits BaseUtils

    Public Enum DataTypeEnum
        [BOOLEAN]
        [STRING]
        [INTEGER]
        [DATE]
    End Enum

    Public Shared Function GetDataRowStringValue(ByVal row As DataRow, ByVal sFieldName As String, ByVal bThrowException As Boolean) As String

        Dim s As String = ""

        Try
            s = row.Item(sFieldName).ToString.Trim
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return s

    End Function

    Public Shared Function GetDataRowIntegerValue(ByVal row As DataRow, ByVal sFieldName As String, ByVal bThrowException As Boolean) As Integer

        Dim i As Integer = 0

        Try
            i = Toolbox.ConversionUtils.ParseInteger(row.Item(sFieldName).ToString, bThrowException)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return i

    End Function

    Public Shared Function GetDataRowDateValue(ByVal row As DataRow, ByVal sFieldName As String, ByVal bThrowException As Boolean) As Date

        Dim dt As Date = Nothing

        Try
            dt = Toolbox.ConversionUtils.ParseDate(row.Item(sFieldName).ToString, bThrowException)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return dt

    End Function

    Public Shared Function GetDataRowBooleanValue(ByVal row As DataRow, ByVal sFieldName As String, ByVal bThrowException As Boolean) As Boolean

        Dim b As Boolean = False

        Try
            b = Toolbox.ConversionUtils.ParseBoolean(row.Item(sFieldName).ToString, bThrowException)
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return b

    End Function

End Class
