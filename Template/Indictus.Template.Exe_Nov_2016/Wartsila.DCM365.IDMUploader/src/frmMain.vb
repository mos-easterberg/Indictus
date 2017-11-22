
Imports Wartsila.IDM.IDMToolbox
'Imports Wartsila.IDM.IDMToolboxC
Imports Wartsila.SharePoint.SharePointToolbox
Imports Wartsila.SharePoint.SharePointToolboxC
Imports Wartsila.DCM365.Factory
Imports Wartsila.DCM365.Entity
Imports Indictus.Common
Imports Indictus.Common.Logging
Imports Indictus.Common.Settings
Imports System.Text
Imports System.Threading
Imports System.Xml
Imports System.Collections
Imports System.Collections.Specialized
Imports Microsoft.SharePoint.Client

Public Class frmMain

    Private Enum FormStatusEnum
        LOADING
        IDLE
    End Enum

    Private m_FORM_STATUS As FormStatusEnum

    Dim m_dcmDocs As ListItemCollection = Nothing
    Dim m_dcmDocsArray As ArrayList = Nothing
    Dim m_spoConn As ClientContext = Nothing
    Dim m_MDRListName As String = "Master Document Register - initial"
    Dim m_bIDMSaveIntermediateXMLFiles As Boolean = False
    Dim m_sIDMProjectName As String = ""
    Dim m_sModuleName As String = ""
    Dim m_arrModuleFolders As New ArrayList

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._init()
        'Me._run()
    End Sub

    Private Sub _init()

        Try
            Me._getSettings()
            Me._initFolders()
            Me._initUI()

            Logger.EmptyLogOnStartup(UserSettings.LogSettings)
            Logger.Log("===================================================", UserSettings.LogSettings)
            Logger.Log(UserSettings.UserAppSettings.ApplicationName & " is initializing...", UserSettings.LogSettings)
        Catch ex As Exception
            Toolbox.ErrorUtils.DisplayException(ex, "")
        End Try

    End Sub

    Private Sub _getSettings()

        Try
            UserSettings.UserAppSettings = New AppSettings

            'UserAppSettings
            '----------------------------------------------------------
            UserSettings.UserAppSettings.ApplicationName = My.Settings.ApplicationName
            'UserSettings.UserAppSettings.IDMStartFolderName = My.Settings.IDMStartFolderName


            'LogSettings
            '----------------------------------------------------------
            UserSettings.LogSettings = New LogSettings
            UserSettings.LogSettings.LogEmptyOnStartup = My.Settings.LogEmptyOnStartup
            UserSettings.LogSettings.LogThrowException = False
            UserSettings.LogSettings.LogFolderPath = Environment.CurrentDirectory & "\log"
            UserSettings.LogSettings.LogFileName = "IDMUploader-log.txt"


            'EmailSettings 
            '----------------------------------------------------------
            UserSettings.EmailSettings = New EmailSettings
            UserSettings.EmailSettings.EnableSSL = False
            UserSettings.EmailSettings.FromAddress = My.Settings.EmailAccount
            UserSettings.EmailSettings.PortNumber = 0
            UserSettings.EmailSettings.ReceiverAddress = My.Settings.EmailAccount
            UserSettings.EmailSettings.ReplyToAddress = My.Settings.EmailReplyToAddress
            UserSettings.EmailSettings.SendTimeoutSeconds = 60
            UserSettings.EmailSettings.ServerName = My.Settings.EmailServer

            'SitesToSync_sc
            '----------------------------------------------------------
            'UserSettings.UserAppSettings.SitesToSync = My.Settings.SitesToSync

            'IDMDocTypes
            '----------------------------------------------------------
            'UserSettings.UserAppSettings.IDMDocTypesES = My.Settings.IDMDocTypesES
            'UserSettings.UserAppSettings.IDMDocTypesNEPA = My.Settings.IDMDocTypesNEPA

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _initFolders()

        Try
            UserSettings.UserAppSettings.WorkFolderPath = Environment.CurrentDirectory & "\work\"
            If Not Toolbox.FileUtils.FolderExists(UserSettings.UserAppSettings.WorkFolderPath) Then
                Toolbox.FileUtils.CreateDirectory(UserSettings.UserAppSettings.WorkFolderPath)
            End If

            UserSettings.UserAppSettings.LogFolderPath = Environment.CurrentDirectory & "\log\"
            If Not Toolbox.FileUtils.FolderExists(UserSettings.UserAppSettings.LogFolderPath) Then
                Toolbox.FileUtils.CreateDirectory(UserSettings.UserAppSettings.LogFolderPath)
            End If

            UserSettings.UserAppSettings.IDMFolderPath = Environment.CurrentDirectory & "\idm\"
            If Not Toolbox.FileUtils.FolderExists(UserSettings.UserAppSettings.IDMFolderPath) Then
                Toolbox.FileUtils.CreateDirectory(UserSettings.UserAppSettings.IDMFolderPath)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _initUI()

        Try
            Me.m_FORM_STATUS = FormStatusEnum.LOADING

            Me.lblSettingsSavedStatus.Text = ""
            Me.Text = UserSettings.UserAppSettings.ApplicationName & " - up since " & Now.ToString

            'Me.txtIDMStartFolderName.Text = UserSettings.UserAppSettings.IDMStartFolderName

        Catch ex As Exception
            Throw ex
        Finally
            Me.m_FORM_STATUS = FormStatusEnum.IDLE
        End Try

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me._run()
    End Sub

    Private Sub _run()

        Try
            Dim bMosIsSmart As Boolean = True
            Dim folder As New IDMFolder

            Dim sPwd As String = Toolbox.EncryptionUtils.SimpleDecrypt("gSroodv<<4")

            Dim idmUser As New IDMUser("mos013", sPwd)
            Dim idmCmd As New IDMCommand("https://fiidm01.wnsd.com/kronodoc/ws", "Post", "application/x-www-form-urlencoded")

            While bMosIsSmart
                Try
                    Logger.Log("Connecting to SPO...", UserSettings.LogSettings)
                    Me.m_spoConn = SPHelper.ConnectToSPO("https://wartsila.sharepoint.com/sites/modules", "magnus.osterberg@wartsila.com", sPwd)

                    Logger.Log("Getting DCM docs...", UserSettings.LogSettings)

                    Logger.Log("Nr of DCM docs found: " & Me.m_dcmDocs.Count, UserSettings.LogSettings)



                Catch ex As Exception
                    Logger.Log("Error in first loop: " & ex.Message, UserSettings.LogSettings)
                End Try
            End While

        Catch ex As Exception
            Toolbox.ErrorUtils.DisplayException(ex)
        End Try

    End Sub

    Private Sub btnViewLog_Click(sender As Object, e As EventArgs) Handles btnViewLog.Click
        Me._viewDailyLogFile()
    End Sub

    Private Sub _viewDailyLogFile()

        Try
            Toolbox.ProcessUtils.StartProcess(Logger.GetDailyLogFilePath(UserSettings.LogSettings))
        Catch ex As Exception
            'CrashHelper.CatchException(ex, CrashHelper.HandleException.LOG_AND_MSGBOX, UserSettings.LogSettings)
            Toolbox.ErrorUtils.DisplayException(ex)
        End Try

    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Me._saveSettings()
    End Sub

    Private Sub _saveSettings()

        Try
            'UserSettings.UserAppSettings.IDMStartFolderName = Me.txtIDMStartFolderName.Text.Trim
            'My.Settings.IDMStartFolderName = UserSettings.UserAppSettings.IDMStartFolderName


            'save
            '----------------------------------------------------------
            My.Settings.Save()
            Me.lblSettingsSavedStatus.Text = "Settings saved!"

        Catch ex As Exception
            Toolbox.ErrorUtils.DisplayException(ex)
        End Try

    End Sub

    Private Sub _setSettingsDirty()

        Try
            If Me.m_FORM_STATUS = FormStatusEnum.IDLE Then Me.lblSettingsSavedStatus.Text = "Settings changed!"
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me._quit(False)
    End Sub

    Private Sub _quit(ByVal bAskConfirmation As Boolean)

        Dim bClose As Boolean = False

        Try
            If bAskConfirmation Then
                bClose = Toolbox.UIUtils.AskConfirmation("Quit application?", UserSettings.UserAppSettings.ApplicationName, Toolbox.UIUtils.ConfirmationType.YES_NO) = MsgBoxResult.Yes
            Else
                bClose = True
            End If

            If bClose Then
                Logger.Log("Quitting....", UserSettings.LogSettings)
                Me.Close()
                Environment.Exit(1)
            End If

        Catch ex As Exception
        End Try

    End Sub

End Class
