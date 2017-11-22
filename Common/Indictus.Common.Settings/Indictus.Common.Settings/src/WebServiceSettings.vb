
Imports System.Text

Public NotInheritable Class WebServiceSettings
    Implements ISettings

    Public Property Address As String

    Public Overrides Function ToString() As String Implements ISettings.ToString

        Dim sb As StringBuilder = Nothing

        Try
            sb = New StringBuilder
            sb.AppendLine("Address: " & Me.Address)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

End Class
