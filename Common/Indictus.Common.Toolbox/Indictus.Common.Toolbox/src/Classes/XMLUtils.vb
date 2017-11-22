
Imports System.Text
Imports System.Xml

Public Class XMLUtils
    Inherits BaseUtils

    Public Enum XMLReadTypeEnum
        [STATIC]
        TREE_MODEL
        CURSOR_BASED
        STREAMING
        QUERY
    End Enum

    Public Shared Function LoadXML(ByVal sFilePath As String) As XmlDocument

        Dim xmlDoc As XmlDocument = Nothing

        Try
            xmlDoc = New XmlDocument
            xmlDoc.Load(sFilePath)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return xmlDoc

    End Function

    Public Shared Function ParseXML(ByVal sFilePath As String,
                                    ByVal readType As XMLReadTypeEnum) As String

        Dim s As String = ""

        Try
            Select Case readType
                Case XMLReadTypeEnum.CURSOR_BASED : s = XMLUtils.ParseXMLByCursor(sFilePath)
                Case XMLReadTypeEnum.QUERY : s = XMLUtils.ParseXMLByQuery(sFilePath)
                Case XMLReadTypeEnum.STATIC
                Case XMLReadTypeEnum.STREAMING : s = XMLUtils.ParseXMLStreaming(sFilePath)
                Case XMLReadTypeEnum.TREE_MODEL : s = XMLUtils.ParseXMLByTreeModel(sFilePath)
            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return s

    End Function

    Public Shared Function ParseXMLByTreeModel(ByVal sFilePath As String) As String

        Dim sb As New StringBuilder
        Dim doc As XmlDocument = Nothing

        Try
            doc = XMLUtils.LoadXML(sFilePath)

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function ParseXMLByCursor(ByVal sFilePath As String) As String

        Dim sb As New StringBuilder
        Dim doc As XmlDocument = Nothing
        Dim nav As XPath.XPathNavigator = Nothing

        Try
            doc = XMLUtils.LoadXML(sFilePath)
            nav = doc.CreateNavigator


        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function ParseXMLStreaming(ByVal sFilePath As String) As String

        Dim sb As New StringBuilder
        Dim reader As XmlTextReader = Nothing

        Try
            reader = New XmlTextReader(sFilePath)
            reader.MoveToContent()

            While reader.Read

                'Exit While
            End While

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function ParseXMLByQuery(ByVal sFilePath As String) As String

        Dim sb As New StringBuilder
        Dim doc As XPath.XPathDocument = Nothing
        Dim nav As XPath.XPathNavigator = Nothing
        Dim iterator As XPath.XPathNodeIterator = Nothing

        Try
            doc = New XPath.XPathDocument(sFilePath)
            nav = doc.CreateNavigator
            iterator = nav.Select("")

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function ParseXMLStatic(ByVal sFilePath As String) As String

        Dim sb As New StringBuilder
        Dim doc As XmlDocument = Nothing

        Try
            doc = XMLUtils.LoadXML(sFilePath)


        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

End Class

