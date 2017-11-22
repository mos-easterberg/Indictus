
Imports Indictus.Common.Settings
Imports Indictus.Common
Imports Indictus.Common.Logging

Imports System.Data
Imports System.Text

Public Class AppHelper

    Public Enum HandleException
        LOG
        MSGBOX
        BOTH
    End Enum

    Public Shared Sub CatchException(ByVal ex As Exception,
                                     ByVal handleExceptionType As HandleException,
                                     ByVal logSettings As LogSettings)

        Try
            Select Case handleExceptionType

                Case HandleException.MSGBOX
                    Toolbox.ErrorUtils.DisplayException(ex, "Error!")

                Case HandleException.LOG
                    Logger.Log(ex.Message, logSettings)

                Case HandleException.BOTH
                    Toolbox.ErrorUtils.DisplayException(ex, "Error!")
                    Logger.Log(ex.Message, logSettings)
            End Select

        Catch exc As Exception
            Toolbox.UIUtils.ShowMessageBox(exc.Message, "Error!", Toolbox.UIUtils.MessageType.WARNING)
        Finally
        End Try

    End Sub

    Public Shared Sub ExitApplication()

        Try
            Application.ExitThread()
            Application.Exit()
        Catch ex As Exception
        Finally
        End Try

    End Sub

    Public Shared Function GetAppSettings() As AppSettings

        Dim aps As AppSettings

        Try
            aps = New AppSettings

            aps.ApplicationName = My.Settings.ApplicationName

            Select Case My.Settings.ApplicationLanguage.ToUpper
                Case "ENGLISH" : aps.AppLang = AppEnums.AppLangEnum.ENGLISH
                Case "SWEDISH" : aps.AppLang = AppEnums.AppLangEnum.SWEDISH
            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return aps

    End Function

    Public Shared Function GetLogSettings() As LogSettings

        Dim s As LogSettings = Nothing

        Try
            s = New LogSettings

            s.LogEmptyOnStartup = My.Settings.LogEmptyOnStartup
            s.LogFolderPath = My.Settings.LogFolderPath
            s.LogFileName = My.Settings.LogFileName
            s.LogThrowException = My.Settings.LogThrowException

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return s

    End Function

    Public Shared Function GetDBSettings() As DBSettings

        Dim dbs As DBSettings

        Try
            dbs = New DBSettings

            dbs.DataSource = My.Settings.DBDataSource
            dbs.InitialCatalog = My.Settings.DBInitialCatalog
            dbs.Password = My.Settings.DBPassword
            dbs.TableOwner = My.Settings.DBTableOwner
            dbs.UserID = My.Settings.DBUserId

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return dbs

    End Function

    Public Shared Function GetEmailSettings() As EmailSettings

        Dim es As EmailSettings

        Try
            es = New EmailSettings

            es.EmailEnableSSL = My.Settings.EmailEnableSSL
            es.EmailFromAddress = My.Settings.EmailFromAddress
            es.EmailSendTimeoutSeconds = My.Settings.EmailSendTimeoutSeconds
            es.EmailServerName = My.Settings.EmailServerName
            es.EmailServerPort = My.Settings.EmailServerPort

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return es

    End Function

    Public Shared Sub ShowNotYetImplementedMessage()
        Toolbox.UIUtils.ShowMessageBox(AppMessages.NOT_YET_IMPLEMENTED(AppEnums.AppLangEnum.ENGLISH), UserSession.AppSettings.ApplicationName, Toolbox.UIUtils.MessageType.INFO)
    End Sub

    Public Shared Sub LogOperationSuccessStatus(ByVal bSuccess As Boolean)

        Try
            If bSuccess Then
                Logger.Log(AppMessages.OPERATION_SUCCESS(AppEnums.AppLangEnum.ENGLISH), UserSession.LogSettings)
            Else
                Logger.Log(AppMessages.OPERATION_FAILURE(AppEnums.AppLangEnum.ENGLISH), UserSession.LogSettings)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub MsgBoxOperationSuccessStatus(ByVal bSuccess As Boolean)

        Dim sMsg As String = ""

        Try
            If bSuccess Then
                sMsg = AppMessages.OPERATION_SUCCESS(AppEnums.AppLangEnum.ENGLISH)
            Else
                sMsg = AppMessages.OPERATION_FAILURE(AppEnums.AppLangEnum.ENGLISH)
            End If

            Toolbox.UIUtils.ShowMessageBox(sMsg, "Info", Toolbox.UIUtils.MessageType.INFO)
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub CreateSessionInstance()

        Try

            'AppSettings
            '------------------------------------------------
            UserSession.AppSettings = New AppSettings
            UserSession.AppSettings.ApplicationName = My.Settings.ApplicationName
            Select Case My.Settings.ApplicationLanguage.ToUpper
                Case "ENGLISH"
                    UserSession.AppSettings.AppLang = AppEnums.AppLangEnum.ENGLISH
                    UserSession.AppSettings.ApplicationLanguage = "English"
                Case "SWEDISH"
                    UserSession.AppSettings.AppLang = AppEnums.AppLangEnum.SWEDISH
                    UserSession.AppSettings.ApplicationLanguage = "Swedish"
            End Select
            UserSession.AppSettings.ConfirmExit = My.Settings.ConfirmExit
            UserSession.AppSettings.SaveSettingsOnExit = My.Settings.SaveSettingsOnExit
            UserSession.AppSettings.VersionString = My.Settings.VersionString
            UserSession.AppSettings.ApplicationNameWithVersion = Toolbox.MiscUtils.GetApplicationTitle(UserSession.AppSettings.ApplicationName,
                                                                                                       UserSession.AppSettings.VersionString)

            'LogSettings
            '------------------------------------------------
            UserSession.LogSettings = New LogSettings
            UserSession.LogSettings.LogEmptyOnStartup = My.Settings.LogEmptyOnStartup
            UserSession.LogSettings.LogFolderPath = My.Settings.LogFolderPath
            UserSession.LogSettings.LogFileName = My.Settings.LogFileName
            UserSession.LogSettings.LogThrowException = My.Settings.LogThrowException


            'DBSettings
            '------------------------------------------------
            UserSession.DBSettings = New DBSettings
            UserSession.DBSettings.DataSource = My.Settings.DBDataSource
            UserSession.DBSettings.InitialCatalog = My.Settings.DBInitialCatalog
            UserSession.DBSettings.Password = My.Settings.DBPassword
            UserSession.DBSettings.TableOwner = My.Settings.DBTableOwner
            UserSession.DBSettings.UserID = My.Settings.DBUserId


            'EmailSettings
            '------------------------------------------------
            UserSession.EmailSettings = New EmailSettings
            UserSession.EmailSettings.EmailEnableSSL = My.Settings.EmailEnableSSL
            UserSession.EmailSettings.EmailFromAddress = My.Settings.EmailFromAddress
            UserSession.EmailSettings.EmailSendTimeoutSeconds = My.Settings.EmailSendTimeoutSeconds
            UserSession.EmailSettings.EmailServerName = My.Settings.EmailServerName
            UserSession.EmailSettings.EmailServerPort = My.Settings.EmailServerPort

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Sub UpdateSessionInstance()

        Try
            'UserSession.AppSettings.ApplicationLanguage = frmMain.cboUILanguage.Text.ToUpper
            'UserSession.AppSettings.ConfirmExit = frmMain.chkConfirmExit.Checked
            'UserSession.AppSettings.SaveSettingsOnExit = frmMain.chkSaveSettingsOnExit.Checked
            'UserSession.LogSettings.LogEmptyOnStartup = frmMain.chkEmptyLogOnStartup.Checked
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Sub UpdateMySettings()

        Try
            My.Settings.ApplicationLanguage = UserSession.AppSettings.ApplicationLanguage
            My.Settings.ConfirmExit = UserSession.AppSettings.ConfirmExit
            My.Settings.SaveSettingsOnExit = UserSession.AppSettings.SaveSettingsOnExit
            My.Settings.LogEmptyOnStartup = UserSession.LogSettings.LogEmptyOnStartup
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SaveMySettings()

        Try
            My.Settings.Save()
        Catch ex As Exception
        End Try

    End Sub

End Class
