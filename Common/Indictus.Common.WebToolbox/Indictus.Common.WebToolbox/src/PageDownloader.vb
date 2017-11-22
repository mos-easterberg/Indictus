
Imports Indictus.Common
Imports System.Net.Http

Public Class PageDownloader
    Public Property URL As String
    Public Property DownloadPath As String

    'Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    Try
    '        Dim pdl As New WebToolbox.PageDownloader
    '        pdl.URL = "http://eklima.met.no/metdata/MetDataService?invoke=getStationsProperties&stations=&username=" '"http://www.vg.no"
    '        pdl.DownloadPath = Environment.CurrentDirectory & "\download\eklima.xml"

    '        Dim t As Task = New Task(AddressOf pdl.DownloadPageAsync)
    '        t.Start()
    '        While Not t.IsCompleted
    '            Debug.WriteLine(t.Status.ToString)
    '        End While
    '        t.Dispose()

    '        Toolbox.ProcessUtils.StartProcess(pdl.DownloadPath)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub
    Public Async Sub DownloadPageAsync()

        Try
            If Toolbox.FileUtils.FileExists(Me.DownloadPath) Then Toolbox.FileUtils.DeleteFile(Me.DownloadPath)
            Toolbox.FileUtils.CreateFile(Me.DownloadPath)

            Using client As HttpClient = New HttpClient()
                Using response As HttpResponseMessage = Await client.GetAsync(URL)
                    Using content As HttpContent = response.Content
                        Dim result As String = Await content.ReadAsStringAsync()
                        If result IsNot Nothing Then
                            Toolbox.FileUtils.WriteMessage(Me.DownloadPath, result, Text.ASCIIEncoding.ASCII, False)
                            'Debug.WriteLine(result.ToString)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try

    End Sub

End Class
