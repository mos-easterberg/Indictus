
Imports Indictus.Common.Forms
Imports Indictus.Common.Logging
Imports Indictus.Common.Resources
Imports Indictus.Common
Imports Indictus.Common.Settings

Imports System.Text

Public Class frmMain
    Inherits frmFormBase
    Implements IFormCommon

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Logger.Log(AppTexts.MAIN_WINDOW_CLOSING, UserSession.LogSettings)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me._init()
    End Sub

    Private Sub _init() Implements IFormCommon._init

        Dim bContinue As Boolean = False
        Dim sb As New StringBuilder
        Dim s As String = ""
        Dim sMsg As String = ""

        Try

            'set wait state
            '------------------------------------------------
            Me._setUIState(FormStateEnum.LOADING, Cursors.WaitCursor)

            'init
            '------------------------------------------------
            bContinue = True


            'create session instance
            '------------------------------------------------
            If bContinue Then
                Try
                    AppHelper.CreateSessionInstance()
                Catch ex As Exception
                    bContinue = False
                    sb.AppendLine("Failed to fetch configuration settings!")
                    sb.AppendLine(AppTexts.APPLICATION_WILL_CLOSE)
                    sb.AppendLine(vbNewLine)
                    sb.AppendLine("Error: " & ex.Message)
                    Toolbox.UIUtils.ShowMessageBox(sb.ToString, "Failed to fetch configuration settings!", Toolbox.UIUtils.MessageType.WARNING)
                    sb.Clear()
                End Try
            End If



            'prepare log directory
            '------------------------------------------------
            If bContinue Then
                Try
                    Logger.PrepareLogDirectory(UserSession.LogSettings.LogFolderPath)
                Catch ex As Exception
                    bContinue = False
                    sb.AppendLine("Failed to prepare log directory!")
                    sb.AppendLine(AppTexts.APPLICATION_WILL_CLOSE)
                    sb.AppendLine(vbNewLine)
                    sb.AppendLine("Error: " & ex.Message)
                    Toolbox.UIUtils.ShowMessageBox(sb.ToString, UserSession.AppSettings.ApplicationName, Toolbox.UIUtils.MessageType.WARNING)
                    sb.Clear()
                End Try
            End If


            'empty log on startup?
            '------------------------------------------------
            If bContinue Then
                Try
                    Logger.EmptyLogOnStartup(UserSession.LogSettings)
                Catch ex As Exception
                Finally
                End Try
            End If


            'first log
            '------------------------------------------------
            Logger.Log("===========================================================", UserSession.LogSettings)
            Logger.Log("Starting...", UserSession.LogSettings, LogEnums.LogModeEnum.DISC)


            'init UI
            '------------------------------------------------
            If bContinue Then
                Try
                    Me._initUI()
                Catch ex As Exception
                    bContinue = False
                    sb.AppendLine("Failed to init UI!")
                    sb.AppendLine(AppTexts.APPLICATION_WILL_CLOSE)
                    sb.AppendLine(vbNewLine)
                    sb.AppendLine("Error: " & ex.Message)
                    Logger.Log(sb.ToString, UserSession.LogSettings, LogEnums.LogModeEnum.DISC)
                    sb.Clear()
                End Try
            End If


            'start msg
            '------------------------------------------------
            If bContinue Then
                Try
                    Logger.Log(UserSession.AppSettings.ApplicationNameWithVersion & " has now started.", UserSession.LogSettings)
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            AppHelper.CatchException(ex, AppHelper.HandleException.BOTH, UserSession.LogSettings)
        Finally
            Me._setUIState(FormStateEnum.IDLE, Cursors.Default)
        End Try

    End Sub

    Private Sub _initUI() Implements IFormCommon._initUI

        Try
            Me.Text = My.Settings.ApplicationName
            Me._initTooltips()
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

    Private Sub _initTooltips() Implements IFormCommon._initTooltips

        Try

        Catch ex As Exception
        End Try

    End Sub

    Private Sub _cancel() Implements IFormCommon._cancel

    End Sub

    Private Sub _closeForm(ByVal bConfirm As Boolean) Implements IFormCommon._closeForm

        Dim bExit As Boolean = False

        Try
            If bConfirm Then
                If Toolbox.UIUtils.AskConfirmation(AppMessages.DO_YOU_WISH_TO_EXIT(UserSession.AppSettings.AppLang),
                                           AppMessages.DIALOG_CAPTION(UserSession.AppSettings.AppLang),
                                           Toolbox.UIUtils.ConfirmationType.YES_NO) = MsgBoxResult.Yes Then
                    bExit = True
                End If
            Else
                bExit = True
            End If

            If bExit Then AppHelper.ExitApplication()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _setUIState(ByVal formState As FormStateEnum, ByVal cursor As Cursor)

        Try
            Me.FormState = formState
        Catch ex As Exception
        End Try

        Try
            Toolbox.UIUtils.SetCursor(cursor, Me)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        Me._closeForm(UserSession.AppSettings.ConfirmExit)
    End Sub

End Class
