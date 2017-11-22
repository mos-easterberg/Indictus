
Public Class CollectionUtils
    Inherits BaseUtils

    Public Shared Function TranslateDelimitedStringToCollection(ByVal sString As String, ByVal sDelimiter As String) As Collection

        Dim coll As Collection = Nothing

        Try
            coll = New Collection
            For Each s As String In Toolbox.StringUtils.Split(sString, sDelimiter)
                coll.Add(s)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return coll

    End Function

    Public Shared Function TranslateDatasetToDictionary(ByVal ds As DataSet) As Dictionary(Of Integer, String)

        Dim d As New Dictionary(Of Integer, String)

        Try
            For Each r As System.Data.DataRow In ds.Tables(0).Rows
                d.Add(Integer.Parse(r.Item(0)), r.Item(1).ToString)
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return d

    End Function

    Public Shared Function TranslateDatasetToStringDictionary(ByVal ds As DataSet) As Dictionary(Of String, String)

        Dim d As New Dictionary(Of String, String)

        Try
            For Each r As System.Data.DataRow In ds.Tables(0).Rows
                d.Add(r.Item(0).ToString, r.Item(1).ToString)
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return d

    End Function

End Class
