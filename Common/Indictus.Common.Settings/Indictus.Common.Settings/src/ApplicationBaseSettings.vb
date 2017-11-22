
Imports System.Text

Public MustInherit Class ApplicationBaseSettings

    Public Property AppLang As AppEnums.AppLangEnum
    Public Property ReleaseMode As AppEnums.ReleaseModeEnum

    Public Property ApplicationName As String
    Public Property ApplicationNameWithVersion As String
    Public Property ApplicationLanguage As String
    Public Property ConfirmExit As Boolean
    Public Property SaveSettingsOnExit As Boolean
    Public Property VersionString As String

End Class
