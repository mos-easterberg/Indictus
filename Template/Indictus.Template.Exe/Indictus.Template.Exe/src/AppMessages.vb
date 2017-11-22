
Imports Indictus.Common.Settings

Public Class AppMessages

    Public Shared ReadOnly Property DO_YOU_WISH_TO_EXIT(ByVal language As AppEnums.AppLangEnum) As String
        Get
            Dim s As String = ""

            Select Case language
                Case AppEnums.AppLangEnum.ENGLISH : s = "Do you wish to exit?"
                Case AppEnums.AppLangEnum.SWEDISH : s = "Vill du avsluta?"
            End Select

            Return s
        End Get
    End Property

    Public Shared ReadOnly Property DIALOG_CAPTION(ByVal language As AppEnums.AppLangEnum) As String
        Get
            Dim s As String = ""

            Select Case language
                Case AppEnums.AppLangEnum.ENGLISH
                    s = "Exe template"
                Case AppEnums.AppLangEnum.SWEDISH
                    s = "Exe-mall"
            End Select

            Return s

        End Get
    End Property

    Public Shared ReadOnly Property NOT_YET_IMPLEMENTED(ByVal language As AppEnums.AppLangEnum) As String
        Get
            Select Case language
                Case AppEnums.AppLangEnum.ENGLISH : Return "Functionality not yet implemented!"
                Case AppEnums.AppLangEnum.SWEDISH : Return "Funktionaliteten ännu ej implementerad!"
            End Select
            Return ""
        End Get
    End Property

    Public Shared ReadOnly Property OPERATION_SUCCESS(ByVal language As AppEnums.AppLangEnum) As String
        Get
            Select Case language
                Case AppEnums.AppLangEnum.ENGLISH : Return "Operation succeeded."
                Case AppEnums.AppLangEnum.SWEDISH : Return "Operationen lyckades. "
            End Select
            Return ""
        End Get
    End Property

    Public Shared ReadOnly Property OPERATION_FAILURE(ByVal language As AppEnums.AppLangEnum) As String
        Get
            Select Case language
                Case AppEnums.AppLangEnum.ENGLISH : Return "Operation failed!"
                Case AppEnums.AppLangEnum.SWEDISH : Return "Operationen misslyckades!"
            End Select
            Return ""
        End Get
    End Property

End Class
