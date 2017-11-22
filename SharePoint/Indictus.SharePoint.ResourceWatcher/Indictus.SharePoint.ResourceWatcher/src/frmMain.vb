
Imports Indictus.Common
Imports Wartsila.SharePoint.SharePointToolbox
Imports Indictus.Common.Settings
Imports Indictus.Common.Logging

Public Class frmMain

    Dim g_LogSettings As New LogSettings

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._init()
    End Sub

    Private Sub _init()

        Try
            g_LogSettings.LogFileName = "ResourceWatcher.txt"
            g_LogSettings.LogFolderPath = Environment.CurrentDirectory & "\log"

            If Not Toolbox.FileUtils.FolderExists(g_LogSettings.LogFolderPath) Then
                Toolbox.FileUtils.CreateDirectory(g_LogSettings.LogFolderPath)
            End If

            Logger.Log("Starting...", g_LogSettings)
            Me._run()
        Catch ex As Exception
            Toolbox.ErrorUtils.DisplayException(ex)
        End Try

    End Sub

    Private Sub _run()


        Try
            Dim sResourceWatcherJobsFilePath As String = Environment.CurrentDirectory & "\settings\ResourceWatcherJobs.txt"
            Dim sJobs As String() = Toolbox.FileUtils.ReadFile(sResourceWatcherJobsFilePath, "ASCII")

            Dim arrTmp As New ArrayList
            Dim arrJobs As New ArrayList
            For Each sLine As String In sJobs
                arrTmp = Toolbox.StringUtils.Split(sLine, ";")
                Dim rwJob As New ResourceWatcherJob
                rwJob.URL = arrTmp.Item(0).ToString.Trim
                rwJob.ItemCountLimit = Toolbox.ConversionUtils.ParseInteger(arrTmp.Item(1).ToString.Trim)
                arrJobs.Add(rwJob)
            Next


            For Each rwJob As ResourceWatcherJob In arrJobs
                Dim spoConn As 
                SPHelper.ConnectToSPO(rwJob.URL, "magnus.osterberg@wartsila.com", "")

            Next

        Catch ex As Exception
            Logger.Log("Error in _run()", g_LogSettings)
        End Try

    End Sub

End Class