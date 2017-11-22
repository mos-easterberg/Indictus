
Imports System.Text

Public Class EnvironmentUtils
    Inherits BaseUtils

    Public Enum EnvVar
        USER_PROFILE
    End Enum

    Public Shared Function GetSpecialEnvironmentVariable(ByVal envVar As EnvVar) As String

        Dim sVariableValue As String = ""

        Try

            Select Case envVar

                'USER_PROFILE
                Case EnvironmentUtils.EnvVar.USER_PROFILE
                    sVariableValue = System.Environment.GetFolderPath(CType(System.Enum.Parse(GetType(Environment.SpecialFolder), "UserProfile"), Environment.SpecialFolder))

                Case Else : sVariableValue = ""
            End Select

        Catch ex As Exception
            Throw ex
        End Try

        Return sVariableValue

    End Function

    Public Shared Function GetAllEnvironmentVariables() As System.Collections.Hashtable

        Try
            Return Environment.GetEnvironmentVariables
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetMachineInformation(ByVal sDelimiter As String) As StringBuilder

        Dim sb As New StringBuilder

        Try
            sb.Append("MachineName: " & Environment.MachineName & sDelimiter)
            sb.Append("OS: " & OSUtils.GetVersionFriendlyName(Environment.OSVersion.Version.ToString) & sDelimiter)
            sb.Append(".NET-framework: " & Environment.Version.ToString & sDelimiter)
            sb.Append("Is64BitOperatingSystem: " & Environment.Is64BitOperatingSystem & sDelimiter)
            sb.Append("Is64BitProcess: " & Environment.Is64BitProcess)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb

    End Function

    Public Shared Function GetUserInformation(ByVal sDelimiter As String) As StringBuilder

        Dim sb As New StringBuilder

        Try
            sb.Append("UserName: " & Environment.UserName & sDelimiter)
            sb.Append("UserDomainName: " & Environment.UserDomainName & sDelimiter)
            sb.Append("UserProfile: " & EnvironmentUtils.GetSpecialEnvironmentVariable(EnvVar.USER_PROFILE))
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb

    End Function

End Class

