

Imports System.Text

Public MustInherit Class BaseEntity

    Public Property Key As String
    Public Property Name As String
    Public Property Value As String
    Public Property ID As Integer
    Public Property Serial As Integer
    Public Property TimeStamp As DateTime
    Public Property Created As String
    Public Property CreatedBy As String
    Public Property Updated As String
    Public Property UpdatedBy As String
    Public Property [Active] As Boolean
    Public Property [Default] As Boolean

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String

        Dim sb As New StringBuilder

        Try
            sb.AppendLine("Key: " & Me.Key)
            sb.AppendLine("Name: " & Me.Name)
            sb.AppendLine("Value: " & Me.Value)
            sb.AppendLine("ID: " & Me.ID)
            sb.AppendLine("Serial: " & Me.Serial)
            sb.AppendLine("TimeStamp: " & Me.TimeStamp)
            sb.AppendLine("Created: " & Me.Created)
            sb.AppendLine("CreatedBy: " & Me.CreatedBy)
            sb.AppendLine("Updated: " & Me.Updated)
            sb.AppendLine("UpdatedBy: " & Me.UpdatedBy)
            sb.AppendLine("Active: " & Me.[Active])
            sb.AppendLine("Default: " & Me.[Default])
        Catch ex As Exception
        End Try

        Return sb.ToString

    End Function

End Class

