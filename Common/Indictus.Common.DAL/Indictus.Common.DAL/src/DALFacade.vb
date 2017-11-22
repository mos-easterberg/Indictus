
Imports Indictus.Common.Settings

Public Class DALFacade

    Public Shared Function SelectFromDB(ByVal sSQL As String,
                                        ByVal db As DBSettings) As DataSet
        Try
            Select Case db.Vendor
                Case DBSettings.VendorEnum.MSSQL : Return MSSQLDAL.SelectFromDB(sSQL, db)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function InsertToDB(ByVal sSQL As String,
                                      ByVal db As DBSettings) As Boolean

        Try
            Select Case db.Vendor
                Case DBSettings.VendorEnum.MSSQL : Return MSSQLDAL.InsertToDB(sSQL, db)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function UpdateToDB(ByVal sSQL As String,
                                      ByVal db As DBSettings) As Boolean

        Try
            Select Case db.Vendor
                Case DBSettings.VendorEnum.MSSQL : Return MSSQLDAL.UpdateToDB(sSQL, db)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function DeleteFromDB(ByVal sSQL As String,
                                        ByVal db As DBSettings) As Boolean

        Try
            Select Case db.Vendor
                Case DBSettings.VendorEnum.MSSQL : Return MSSQLDAL.DeleteFromDB(sSQL, db)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function RunSQL(ByVal sSQL As String,
                                  ByVal db As DBSettings) As Boolean

        Try
            Select Case db.Vendor
                Case DBSettings.VendorEnum.MSSQL : Return MSSQLDAL.RunSQL(sSQL, db)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

End Class
