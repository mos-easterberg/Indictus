
Imports Microsoft.SharePoint.Client
Imports Indictus.Common.Toolbox
Imports System.IO
Imports System.Text
Imports Indictus.SharePoint.SharePointToolbox
Imports System.Net.Http
Imports System.Web.Script.Serialization

Public Class frmOne
    Public m_spoConn As ClientContext = Nothing

    Private Sub frmOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me._test()
        Me._run()
    End Sub

    Private Sub _run()

        Try
            Dim sURL As String = "https://yndesdal.sharepoint.com/moslab"

            'Me.m_spoConn = SPHelper.ConnectToSPO("https://yndesdal.sharepoint.com/moslab", "magnus@365sky.no", "MosTemp991")
            'MsgBox(Me.m_spoConn.Url)
            'Me._uploadSmallFile()
            'Me._uploadBigFile()
            'Environment.Exit(0)

            Dim credentials As SharePointOnlineCredentials = Indictus.SharePoint.SharePointToolboxC.RESTMan.CreateCredentials("magnus@365sky.no", "NotTooSens991")
            Dim client As System.Net.Http.HttpClient = Indictus.SharePoint.SharePointToolboxC.RESTMan.GetClient(sURL, credentials)

            'Me._query(client, sURL)
            Me._queryList(client, sURL)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Async Sub _query(ByVal client As HttpClient, ByVal sURL As String)

        Try
            Dim sJson As String = Await Indictus.SharePoint.SharePointToolboxC.RESTMan.GetData(client, sURL, "{0}/_api/web?$select=Title")
            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer

            Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(sJson)

            For Each kvp As KeyValuePair(Of String, String) In dict
                Me.txtData.AppendText(kvp.Key & ": " & kvp.Value & vbNewLine)
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Async Sub _queryList(ByVal client As HttpClient, ByVal sURL As String)

        Try
            Dim sJson As String = Await Indictus.SharePoint.SharePointToolboxC.RESTMan.GetListItems(client, sURL, "FlowTest")
            Debug.WriteLine(sJson)
            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer

            'Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(sJson)
            'For Each kvp As KeyValuePair(Of String, String) In dict
            '    Me.txtData.AppendText(kvp.Key & ": " & kvp.Value & vbNewLine)
            'Next

            Dim deserializedResult = jss.Deserialize(Of List(Of FlowTest))(sJson)
            Debug.WriteLine("count: " & deserializedResult.Count)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _uploadSmallFile()

        Try
            Dim sLocalFilePath As String = "D:\testarea\docx\001-docx.docx"
            Dim sCloudFilePath As String = "https://yndesdal.sharepoint.com/moslab/testlib/001-docx.docx"
            Dim i As Integer = SPHelper.UploadSmallFile(Me.m_spoConn, sLocalFilePath, sCloudFilePath, "testlib")
            Debug.WriteLine(i)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _uploadBigFile()

        Try
            Dim fm As New Indictus.SharePoint.SharePointToolboxC.FileManager
            Dim dtStart As Date = Date.Now
            Dim i As Integer = fm.UploadFileViaContentStream(Me.m_spoConn, "testlib", "D:\testarea\big files\10mb.zip")
            Debug.WriteLine(i)
            Dim dtEnd As Date = Date.Now

            Dim s As String = DateAndTimeUtils.GetTimeDiff(dtStart, dtEnd, DateAndTimeUtils.TimeDiffStyle.HMS)
            MsgBox(s)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _test()

        Try
            Dim RegisteredUsers As New List(Of Person)()
            RegisteredUsers.Add(New Person With {.PersonID = 1, .Name = "Bryon Hetrick", .Registered = True})
            RegisteredUsers.Add(New Person With {.PersonID = 2, .Name = "Nicole Wilcox", .Registered = True})
            RegisteredUsers.Add(New Person With {.PersonID = 3, .Name = "Adrian Martinson", .Registered = False})
            RegisteredUsers.Add(New Person With {.PersonID = 4, .Name = "Nora Osborn", .Registered = False})
            RegisteredUsers.Add(New Person With {.PersonID = 5, .Name = "Magnus Österberg", .Registered = False})

            Dim serializer As New JavaScriptSerializer()
            Dim serializedResult = serializer.Serialize(RegisteredUsers)
            Debug.WriteLine(serializedResult)

            Dim deserializedResult = serializer.Deserialize(Of List(Of Person))(serializedResult)
            Debug.WriteLine(deserializedResult.Count)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class

Public Class Person
    Public Property PersonID As Integer
    Public Property Name As String
    Public Property Registered As Boolean
End Class

Public Class FlowTest
    Public Property Title As String
End Class
