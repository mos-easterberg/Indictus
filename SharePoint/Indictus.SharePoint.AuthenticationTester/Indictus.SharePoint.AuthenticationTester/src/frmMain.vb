
'Imports ClientObjectModelSample.ClientObjectModelSample
Imports Microsoft.SharePoint.Client
Imports System.Net
'Imports Indictus.SharePoint.Authentication
Imports System.Security
Imports Indictus.Common
Imports Indictus.SharePoint.Authentication

Public Class frmMain

	Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me._loginViaCookies("https://yndesdal.sharepoint.com/moslab")
        'Me._loginViaClientObjectModelSample("https://capgemini.sharepoint.com/sites/O365Playground")
        'Me._login2()
        'Me._loginViaAuthenticationClass("https://yndesdal.sharepoint.com/moslab")
        'Me._loginViaAuthenticationClass("https://capgemini.sharepoint.com/sites/O365Playground")
        Me._loginViaAuthenticationClass("https://retailpaymentas.sharepoint.com")
    End Sub

    'Private Sub login()

    '    Dim cookies As New CookieContainer()
    '    Dim context As Microsoft.SharePoint.Client.ClientContext = Nothing
    '    'Dim sUrl As String = "https://wartsila.sharepoint.com/sites/P_13033"
    '    Dim sUrl As String = "https://wartsila.sharepoint.com/"


    '    Try
    '        cookies = O365AuthenticationScraper.GetAuthCookies(sUrl, "magnus.osterberg@wartsila.onmicrosoft.com", "")

    '        If cookies.Count = 0 Then
    '            Debug.Print("Login failed!")
    '        Else
    '            Debug.Print("Login succeeded!")
    '        End If

    '        context = New ClientContext(sUrl)

    '        'context.
    '        context.Load(context.Web)
    '        context.ExecuteQuery()
    '        Debug.Print(context.Web.Title)

    '        'ClientObjectModelSample(Client = New ClientObjectModelSample(cookies))

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub _loginViaAuthenticationClass(ByVal sURL As String)

        Try
            Dim context As ClientContext = AuthManager.Authenticate(sURL)
            MsgBox(context.Url.ToString)
        Catch ex As Exception
            Toolbox.ErrorUtils.DisplayException(ex)
        End Try

    End Sub

    Private Sub _loginViaClientObjectModelSample(ByVal sURL As String)

        Dim cookies As New CookieContainer()
        Dim authCookies As CookieCollection = Nothing
        Dim client As ClientObjectModelSample.ClientObjectModelSample = Nothing
        Dim context As ClientContext = Nothing

        Try
            authCookies = ClientObjectModelSample.ClientObjectModelSample.GetAuthenticatedCookies(sURL, 500, 500)
            cookies.Add(authCookies)
            client = New ClientObjectModelSample.ClientObjectModelSample(cookies)
            context = client.getContext(sURL)
            Debug.WriteLine(context.Url)

            Dim items As ListItemCollection = client.GetSPListItems(sURL, "testlist_magnus")
            Debug.WriteLine(items.Count)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub _login2()

        Using cc As ClientContext = New ClientContext("https://yoursite.sharepoint.com/")
			Dim passWord As SecureString = New SecureString

			For Each c As Char In "".ToCharArray
				passWord.AppendChar(c)
			Next

			cc.Credentials = New SharePointOnlineCredentials("magnus.osterberg@wartsila.com", passWord)
			Dim web As Web = cc.Web
			cc.Load(web)
			cc.ExecuteQuery()
			Debug.WriteLine(web.Title)

		End Using

    End Sub

End Class
