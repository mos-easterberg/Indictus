
Imports System.Text

Public Class Email
    Inherits BaseEntity
    Implements IEntity

    Public Property FromAddress As String
    Public Property ReplyToAddress As String
    Public Property ToAddress As String
    Public Property CCAddress As String
    Public Property BCCAddress As String
    Public Property Subject As String
    Public Property Message As String
    Public Property AttachmentFilePath As String

    Public Overrides Function ToString() As String Implements IEntity.ToString

        Dim sb As New StringBuilder

        Try
        Catch ex As Exception
        End Try

        Return sb.ToString

    End Function

End Class

