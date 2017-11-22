
Imports System.Linq
Imports System.Xml.Linq

Public Class LINQUtils
    Inherits BaseUtils

    Public Shared Function GetXMLData(ByVal sXMLFilePath As String,
                                      ByVal sXMLStructurePath As String,
                                      ByVal bAsParallel As Boolean) As Collection

        Dim coll As New Collection
        Dim element As XElement = Nothing
        Dim query As ParallelQuery(Of XElement) = Nothing
        'Dim root As XElement = <ElementName>content</ElementName>

        Try
            element = XElement.Load(sXMLFilePath)

            If bAsParallel Then
                'query = element.<folder>.<metadata>.AsParallel
                query = element.Elements(sXMLStructurePath).AsParallel

            Else
                query = element.Elements(sXMLStructurePath)
            End If

            For Each result In query
                coll.Add(result)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return coll

    End Function

    'Public Shared Function GetXMLData(ByVal sXMLFilePath As String,
    '                              ByVal sXMLStructurePath As String,
    '                              ByVal bAsParallel As Boolean) As XElement

    '    Dim element As XElement = Nothing
    '    Dim query As ParallelQuery(Of XElement) = Nothing

    '    Try
    '        element = XElement.Load(sXMLFilePath)

    '        If bAsParallel Then
    '            'query = element.<folder>.<metadata>.AsParallel
    '            query = element.Elements(sXMLStructurePath).AsParallel

    '        Else
    '            query = element.Elements(sXMLStructurePath)
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return query.

    'End Function

End Class

