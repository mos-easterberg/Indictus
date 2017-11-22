
Imports Microsoft.SharePoint.Client
Imports System.Net

Public Class AuthManager

	Public Shared Function Authenticate(ByVal sURL As String) As ClientContext

		Try
			Dim cookies As New CookieContainer()
			Dim authCookies As CookieCollection = Nothing
			Dim client As ClientObjectModelSample.ClientObjectModelSample = Nothing
			Dim context As ClientContext = Nothing

            'authCookies = ClientObjectModelSample.ClientObjectModelSample.GetAuthenticatedCookies("https://wartsila.sharepoint.com/", 500, 500)
            authCookies = ClientObjectModelSample.ClientObjectModelSample.GetAuthenticatedCookies(sURL, 500, 500)
			cookies.Add(authCookies)
			client = New ClientObjectModelSample.ClientObjectModelSample(cookies)
			context = client.getContext(sURL)
            'client.getc
            Debug.WriteLine(context.Url)
            'MsgBox(context.Url)

            Return context
		Catch ex As Exception
			Throw ex
            'MsgBox(ex.Message)
        End Try

		Return Nothing

	End Function

	Public Shared Function AuthenticateReturnClient(ByVal sURL As String) As ClientObjectModelSample.ClientObjectModelSample

		Try
			Dim cookies As New CookieContainer()
			Dim authCookies As CookieCollection = Nothing
			Dim client As ClientObjectModelSample.ClientObjectModelSample = Nothing
			'Dim context As ClientContext = Nothing

			authCookies = ClientObjectModelSample.ClientObjectModelSample.GetAuthenticatedCookies(sURL, 500, 500)
			cookies.Add(authCookies)
			client = New ClientObjectModelSample.ClientObjectModelSample(cookies)

			Return client
		Catch ex As Exception
			Throw ex
		End Try

		Return Nothing

	End Function

End Class
