
Imports Indictus.Common.Settings

Public Class ErrorUtils
    Inherits BaseUtils

    Public Shared Sub DisplayException(ByVal ex As Exception)

        Try
            ErrorUtils.DisplayException(ex, "")
        Catch exc As Exception
            Throw exc
        End Try

    End Sub

    Public Shared Sub DisplayException(ByVal ex As Exception,
                                       ByVal sErrMsg As String)

        Dim frm As frmExceptionDisplay

        Try
            frm = New frmExceptionDisplay
            frm.Init(ex, sErrMsg)
            frm.ShowDialog()
        Catch ex2 As Exception
            Throw ex2
        Finally
            frm = Nothing
        End Try

    End Sub

    Public Shared Function EmailMessage(ByVal sOriginID As String, ByVal sSubject As String, ByVal sMessage As String, ByVal sTo As String,
                                        ByVal sCc As String, ByVal mailSettings As EmailSettings, ByVal bThrowEx As Boolean) As Boolean

        Dim b As Boolean = False

        Try
            If Toolbox.StringUtils.IsNullOrWhiteSpace(sOriginID) Then sOriginID = "unknown"
            sSubject = sSubject & " [origin: " & sOriginID & "]"
            b = Toolbox.EmailUtils.SendMail(mailSettings.FromAddress, sTo, sCc, "",
                                            sSubject, sMessage, mailSettings.ReplyToAddress,
                                            mailSettings.ServerName, mailSettings.PortNumber, mailSettings.EnableSSL,
                                            mailSettings.SendTimeoutSeconds, False, "")
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return b

    End Function

End Class
