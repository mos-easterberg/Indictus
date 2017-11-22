
Public Class DCMProjectSyncDefinition

    Public Property Year As Integer
    Public Property Project As String
    Public Property IncludeInIDMSync As Boolean
    Public Property NotifyWhenSyncComplete As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal IncludeInIDMSync As Boolean)
        Me.IncludeInIDMSync = IncludeInIDMSync
    End Sub

End Class
