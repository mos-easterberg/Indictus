
Public Class HTMLUtils
    Inherits BaseUtils

    Public Enum SimpleFormat
        [BOLD]
        [ITALIC]
        [UNDERLINE]
    End Enum

    Public Shared Function GetSimpleFormattedText(ByVal sText As String, _
                                                  ByVal format As SimpleFormat) As String

        Try
            Select Case format
                Case SimpleFormat.BOLD : Return "<b>" & sText & "</b>"
                Case SimpleFormat.ITALIC : Return "<i>" & sText & "</i>"
                Case SimpleFormat.UNDERLINE : Return "<u>" & sText & "</u>"
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return ""

    End Function

    Public Shared Function GetPictureText(ByVal sFilePath As String) As String

        '<IMG height=264 alt="" src="pics/login.gif" width=424 border=0>
        Try
            Return "<img src=""" & sFilePath & """ border=0>"
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetLinkText(ByVal sLinkText As String, _
                                       ByVal sLink As String) As String

        '<a href="./agents.htm#notes">Notes</A>
        Try
            Return "<a href=" & "" & sLink & "" & ">" & sLinkText & "</a>"
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

End Class
