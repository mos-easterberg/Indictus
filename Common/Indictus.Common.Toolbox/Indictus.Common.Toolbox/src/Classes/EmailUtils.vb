
Imports System.Net.Mail

Public Class EmailUtils
    Inherits BaseUtils

    Public Shared Function SendMail(ByVal sFromAddress As String,
                                    ByVal sToAddress As String,
                                    ByVal sCCAddress As String,
                                    ByVal sBCCAddress As String,
                                    ByVal sSubject As String,
                                    ByVal sMessage As String,
                                    ByVal sReplyToAddress As String,
                                    ByVal sServerName As String,
                                    ByVal iServerPort As Integer,
                                    ByVal bEnableSSL As Boolean,
                                    ByVal iSendTimeoutSeconds As Integer,
                                    ByVal bIsBodyHtml As Boolean,
                                    ByVal sAttachmentFilePath As String) As Boolean

        Dim b As Boolean = False
        Dim mail As MailMessage = Nothing
        Dim smtp As SmtpClient = Nothing

        Try
            mail = New MailMessage(sFromAddress, sToAddress)
            smtp = New SmtpClient


            'mail
            '------------------------------------------------
            mail.Subject = sSubject
            mail.Body = sMessage
            mail.IsBodyHtml = bIsBodyHtml
            'mail.CC = sCCAddress


            'attachment
            '------------------------------------------------
            If Not String.IsNullOrWhiteSpace(sAttachmentFilePath) Then
                Dim attchmnt As Attachment = New Attachment(sAttachmentFilePath, Net.Mime.MediaTypeNames.Application.Octet)
                mail.Attachments.Add(attchmnt)
            End If


            'smtp
            '------------------------------------------------
            smtp.Host = sServerName
            If iServerPort > 0 Then smtp.Port = iServerPort
            smtp.EnableSsl = bEnableSSL
            smtp.Timeout = iSendTimeoutSeconds * 1000

            'send
            '------------------------------------------------
            smtp.Send(mail)

            b = True
        Catch ex As Exception
            Throw ex
        Finally
            mail = Nothing
            smtp.Dispose()
            smtp = Nothing
        End Try

        Return b

    End Function

End Class
