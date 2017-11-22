
Imports Indictus.Common
Imports Indictus.Common.Settings

Public Class Logger

    Public Sub New()
    End Sub

    Public Shared Sub EmptyLogOnStartup(ByVal logSettings As LogSettings)

        Dim b As Boolean = False

        Try
            If logSettings.LogEmptyOnStartup Then
                b = Toolbox.FileUtils.EmptyFile(Logger.GetDailyLogFilePath(logSettings))
            Else
                b = True
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function PrepareLogDirectory(ByVal sLogDirectoryPath As String) As Boolean

        Try
            Return Toolbox.FileUtils.CreateDirectory(sLogDirectoryPath)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function Log(ByVal sMsg As String, ByVal logSettings As LogSettings) As Boolean

        Dim b As Boolean = False

        Try
            b = Log(sMsg, logSettings, LogEnums.LogModeEnum.DISC, Nothing)
        Catch ex As Exception
            If logSettings.LogThrowException Then Throw ex
            b = False
        Finally
            logSettings = Nothing
        End Try

        Return b

    End Function

    Public Shared Function Log(ByVal ex As Exception, ByVal logSettings As LogSettings) As Boolean

        Dim b As Boolean = False

        Try
            Select Case logSettings.LogSize
                Case logSettings.LogSizeEnum.BASIC
                    b = Log(ex.Message, logSettings, LogEnums.LogModeEnum.DISC, Nothing)
                Case logSettings.LogSizeEnum.FULL
                    b = Log(Toolbox.ExceptionUtils.ExceptionToString(ex), logSettings, LogEnums.LogModeEnum.DISC, Nothing)
            End Select
        Catch ex2 As Exception
            If logSettings.LogThrowException Then Throw ex2
        End Try

        Return b

    End Function

    Public Shared Function Log(ByVal sMsg As String,
                               ByVal logSettings As LogSettings,
                               ByVal mode As LogEnums.LogModeEnum)

        Dim b As Boolean = False

        Try
            b = Log(sMsg, logSettings, mode, Nothing)
        Catch ex As Exception
            If logSettings.LogThrowException Then Throw ex
            b = False
        Finally
            logSettings = Nothing
        End Try

        Return b

    End Function

    Public Shared Function Log(ByVal sMsg As String,
                               ByVal logSettings As LogSettings,
                               ByVal mode As LogEnums.LogModeEnum,
                               ByVal emailSettings As EmailSettings) As Boolean

        Dim sFilePath As String = ""
        Dim sEmailSubject As String = ""
        Dim b As Boolean = False

        Try

            'init
            '-------------------------------------------------------------------------
            If String.IsNullOrEmpty(sMsg) Then
                Return False
                Exit Function
            Else
                sFilePath = Logger.GetDailyLogFilePath(logSettings)
                sEmailSubject = Microsoft.VisualBasic.Left(sMsg, 50)
            End If

            Select Case mode


                'DISC
                '-------------------------------------------------------------------------
                Case LogEnums.LogModeEnum.DISC
                    Try
                        b = Toolbox.FileUtils.WriteMessage(sFilePath, sMsg, True, 0, False, 0)
                    Catch ex As Exception
                        If logSettings.LogThrowException Then Throw ex
                    End Try


                    'EMAIL
                    '-------------------------------------------------------------------------
                Case LogEnums.LogModeEnum.EMAIL
                    Try
                        b = Toolbox.EmailUtils.SendMail(emailSettings.FromAddress, emailSettings.ReceiverAddress, "", "",
                                                        sEmailSubject, sMsg, emailSettings.FromAddress,
                                                        emailSettings.ServerName, emailSettings.PortNumber, emailSettings.EnableSSL,
                                                        emailSettings.SendTimeoutSeconds, False, "")
                    Catch ex As Exception
                        If logSettings.LogThrowException Then Throw ex
                    End Try


                    'DISC_AND_EMAIL
                    '-------------------------------------------------------------------------
                Case LogEnums.LogModeEnum.DISC_AND_EMAIL
                    Try
                        b = Toolbox.FileUtils.WriteMessage(sFilePath, sMsg, True, 0, False, 0)
                    Catch ex As Exception
                        If logSettings.LogThrowException Then Throw ex
                    End Try

                    Try
                        'sb.Append(Toolbox.EmailUtils.SendMail("magnus.osterberg@citec.com", "magnus.osterberg@citec.com", "", "",
                        '                                      "E-mail test msg from " & Environment.MachineName, "foo bar", "DocmgmntService@citec.com",
                        '                                      "smtp.citec.com", 0, False,
                        '                                      30, False, ""))

                        b = Toolbox.EmailUtils.SendMail(emailSettings.FromAddress, emailSettings.ReceiverAddress, "", "",
                                                    sEmailSubject, sMsg, emailSettings.FromAddress,
                                                    emailSettings.ServerName, emailSettings.PortNumber, emailSettings.EnableSSL,
                                                    emailSettings.SendTimeoutSeconds, False, "")
                    Catch ex As Exception
                        If logSettings.LogThrowException Then Throw ex
                    End Try

            End Select

        Catch ex As Exception
            If logSettings.LogThrowException Then Throw ex
            b = False
        Finally
            logSettings = Nothing
        End Try

        Return b

    End Function

    Public Shared Function GetDailyLogFileName(ByVal sFileName As String) As String

        Dim sDailyFileName As String = ""

        Try
            sDailyFileName = Toolbox.DateAndTimeUtils.ConvertDate(Toolbox.DateAndTimeUtils.DateStyle.SWEDISH,
                                                                Toolbox.DateAndTimeUtils.DateFormat.SHORT,
                                                                Date.Today) & "_" & sFileName
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sDailyFileName

    End Function

    Public Shared Function GetDailyLogFilePath(ByVal logSettings As LogSettings) As String

        Dim sDailyFilePath As String = ""

        Try
            sDailyFilePath = Toolbox.FileUtils.SecureFilePath(logSettings.LogFolderPath) & Logger.GetDailyLogFileName(logSettings.LogFileName)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sDailyFilePath

    End Function

    

End Class
