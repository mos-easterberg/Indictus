
Imports Indictus.Common.Settings

Public Class UserSession

    Private Shared _instance As UserSession

    Public Shared AppSettings As AppSettings = Nothing
    Public Shared LogSettings As LogSettings = Nothing
    Public Shared DBSettings As DBSettings = Nothing
    Public Shared EmailSettings As EmailSettings = Nothing

    Private Sub New()
    End Sub

    Public Shared Function GetInstance() As UserSession
        SyncLock GetType(UserSession)
            If _instance Is Nothing Then
                _instance = New UserSession
            End If
        End SyncLock
        Return _instance
    End Function

    Public Shared Sub Destroy()
        _instance = Nothing
    End Sub

End Class
