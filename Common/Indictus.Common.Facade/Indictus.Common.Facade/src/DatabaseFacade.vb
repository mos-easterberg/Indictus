
Imports Indictus.Common.DAL
Imports Indictus.Common.Entity
Imports Indictus.Common.Settings

Public Class DatabaseFacade
    Inherits BaseFacade
    Implements IFacade

    Public Function Fetch(ByVal sSQL As String, ByVal db As DBSettings) As DataSet Implements IFacade.Fetch

        Try
            Return DALFacade.SelectFromDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

    Public Function Add(ByVal sSQL As String, ByVal db As DBSettings) As Boolean Implements IFacade.Add

        Try
            Return DALFacade.InsertToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Function Update(ByVal sSQL As String, ByVal db As DBSettings) As Boolean Implements IFacade.Update

        Try
            Return DALFacade.UpdateToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Function Remove(ByVal sSQL As String, ByVal db As DBSettings) As Boolean Implements IFacade.Remove

        Try
            Return DALFacade.DeleteFromDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Function RunSQL(ByVal sSQL As String, ByVal db As DBSettings) As Boolean Implements IFacade.RunSQL

        Try
            Return DALFacade.RunSQL(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

End Class
