
Imports Indictus.Common.Entity
Imports Indictus.Common.Settings

Public Class UserSettings

    Private Shared _instance As UserSettings

    Public Shared UserAppSettings As AppSettings
    Public Shared LogSettings As LogSettings
    Public Shared EmailSettings As EmailSettings

    Private Sub New()
    End Sub

    Public Shared Function GetInstance() As UserSettings
        SyncLock GetType(UserSettings)
            If _instance Is Nothing Then
                _instance = New UserSettings
            End If
        End SyncLock
        Return _instance
    End Function

End Class
