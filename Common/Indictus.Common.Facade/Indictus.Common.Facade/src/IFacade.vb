
Imports Indictus.Common.Settings

Public Interface IFacade

    Function Add(ByVal sSQL As String, ByVal db As DBSettings) As Boolean
    Function Fetch(ByVal sSQL As String, ByVal db As DBSettings) As DataSet
    Function Update(ByVal sSQL As String, ByVal db As DBSettings) As Boolean
    Function Remove(ByVal sSQL As String, ByVal db As DBSettings) As Boolean
    Function RunSQL(ByVal sSQL As String, ByVal db As DBSettings) As Boolean

End Interface

