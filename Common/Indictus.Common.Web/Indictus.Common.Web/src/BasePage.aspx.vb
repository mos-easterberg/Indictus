
Public Class BasePage
    Inherits System.Web.UI.Page

    Public Function GetRequestParamValue(ByVal sParamName As String,
                                         ByVal params As System.Collections.Specialized.NameValueCollection) As String

        Dim s As String = ""

        Try
            s = params.GetValues(sParamName)(0).ToString
        Catch ex As Exception
            'Throw ex
        End Try

        Return s

    End Function

End Class