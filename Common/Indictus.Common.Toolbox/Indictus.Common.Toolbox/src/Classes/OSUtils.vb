
Imports System.Text

Public Class OSUtils
    Inherits BaseUtils

    Public Shared Function GetVersionFriendlyName(ByVal sOSVersion As String) As String

        Dim sVersionFriendlyName As String = ""

        Try

            'If StringUtils.Matches(sOSVersion, "6.1.7600", False, StringUtils.MatchMode.CONTAINS) Then
            'End If

            Select Case sOSVersion
                Case "1.04" : sVersionFriendlyName = "Windows 1.0"
                Case "2.11" : sVersionFriendlyName = "Windows 2.0"
                Case "3" : sVersionFriendlyName = "Windows 3.0"
                Case "3.10.528" : sVersionFriendlyName = "Windows NT 3.1"
                Case "3.11" : sVersionFriendlyName = "Windows for Workgroups 3.11"
                Case "3.5.807" : sVersionFriendlyName = "Windows NT Workstation 3.5"
                Case "3.51.1057" : sVersionFriendlyName = "Windows NT Workstation 3.51"
                Case "4.0.950" : sVersionFriendlyName = "Windows 95"
                Case "4.0.1381" : sVersionFriendlyName = "Windows NT Workstation 4.0"
                Case "4.1.1998" : sVersionFriendlyName = "Windows 98"
                Case "4.1.2222" : sVersionFriendlyName = "Windows 98 Second Edition"
                Case "4.90.3000" : sVersionFriendlyName = "Windows Me"
                Case "5.0.2195" : sVersionFriendlyName = "Windows 2000 Professional"
                Case "5.1.2600" : sVersionFriendlyName = "Windows XP"
                Case "5.2.3790" : sVersionFriendlyName = "Windows XP Professional x64 Edition"
                Case "6.0.6000" : sVersionFriendlyName = "Windows Vista"
                Case "6.1.7600.0" : sVersionFriendlyName = "Windows 7"

                Case Else : sVersionFriendlyName = "Unknown"
            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sVersionFriendlyName

    End Function

End Class

