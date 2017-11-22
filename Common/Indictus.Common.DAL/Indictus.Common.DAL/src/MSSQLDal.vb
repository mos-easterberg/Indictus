
Imports Indictus.Common.Settings
Imports System.Data.SqlClient

Friend Class MSSQLDAL
    Inherits BaseDAL

    Private Shared Function _getConnection(ByVal db As DBSettings) As SqlConnection

        Dim conn As SqlConnection = Nothing

        Try
            conn = New SqlConnection
            conn.ConnectionString = db.ConnectionString
            conn.Open()
        Catch ex As Exception
            Throw ex
        End Try

        Return conn

    End Function

    Private Shared Function _writeToDB(ByVal sSQL As String, ByVal db As DBSettings) As Boolean

        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim i As Integer = 0

        Try
            conn = _getConnection(db)
            cmd = conn.CreateCommand
            cmd.CommandText = sSQL
            cmd.CommandTimeout = db.TimeOutSeconds
            i = cmd.ExecuteNonQuery()
            If i = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try

        Return False

    End Function

    Private Shared Function _readFromDB(ByVal sSQL As String, ByVal db As DBSettings) As DataSet

        Dim conn As SqlConnection = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet = Nothing
        Dim cb As SqlCommandBuilder = Nothing

        Try
            ds = New DataSet
            conn = _getConnection(db)
            da = New SqlDataAdapter(sSQL, conn)
            cb = New SqlCommandBuilder(da)
            da.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(conn) Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return ds

    End Function

    Public Shared Function SelectFromDB(ByVal sSQL As String,
                                        ByVal db As DBSettings) As DataSet

        Try
            Return MSSQLDAL._readFromDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function InsertToDB(ByVal sSQL As String,
                                      ByVal db As DBSettings) As Boolean

        Try
            Return MSSQLDAL._writeToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function UpdateToDB(ByVal sSQL As String,
                                      ByVal db As DBSettings) As Boolean

        Try
            Return MSSQLDAL._writeToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function DeleteFromDB(ByVal sSQL As String,
                                        ByVal db As DBSettings) As Boolean

        Try
            Return MSSQLDAL._writeToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function RunSQL(ByVal sSQL As String,
                                  ByVal db As DBSettings) As Boolean

        Try
            Return MSSQLDAL._writeToDB(sSQL, db)
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

End Class
