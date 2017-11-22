
Imports System.Data.SqlClient
Imports System.Text

Public Class MSSQLUtils
    Inherits BaseUtils

    Public Enum SQLCommandType
        [STOREDPROCEDURE] = 0
        [TEXT] = 1
    End Enum

    Private Shared Function _getConnectionString(ByVal settings As MSSQLSettings) As String

        Dim sb As New StringBuilder

        '"Data Source=E4SEBUSINTL.citec.local;Initial Catalog=ProArc;User Id=PAadmin;Password=xxx;"
        Try
            sb.Append("Data Source=" & settings.DataSource & ";")
            sb.Append("Initial Catalog=" & settings.InitialCatalog & ";")
            sb.Append("User Id=" & settings.UserID & ";")
            sb.Append("Password=" & Toolbox.EncryptionUtils.SimpleDecrypt(settings.Password) & ";")
        Catch ex As Exception
            Throw ex
        End Try

        Return sb.ToString

    End Function

    Public Shared Sub CloseConnection(ByRef conn As SqlConnection)

        Try
            conn.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Try
                conn.Dispose()
                conn = Nothing
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Public Shared Function GetConnection(ByVal sTableOwner As String,
                                         ByVal sDataSource As String,
                                         ByVal sInitialCatalog As String,
                                         ByVal sUserID As String,
                                         ByVal sPassword As String) As SqlConnection

        Dim connection As SqlConnection = Nothing
        Dim settings As MSSQLSettings = Nothing

        Try
            settings = New MSSQLSettings()
            settings.TableOwner = sTableOwner
            settings.DataSource = sDataSource
            settings.InitialCatalog = sInitialCatalog
            settings.UserID = sUserID
            settings.Password = sPassword

            connection = New SqlConnection
            connection.ConnectionString = MSSQLUtils._getConnectionString(settings)
            connection.Open()
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return connection

    End Function

    Public Shared Function GetConnection(ByVal settings As MSSQLSettings) As SqlConnection

        Dim connection As SqlConnection = Nothing

        Try
            connection = New SqlConnection
            connection.ConnectionString = _getConnectionString(settings)
            connection.Open()
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return connection

    End Function

    Public Shared Function IsConnectionOpen(ByRef conn As SqlConnection) As Boolean

        Try
            Return (conn.State = ConnectionState.Open)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetData(ByRef conn As SqlConnection,
                                   ByVal sSQL As String) As DataSet

        Dim ds As New DataSet
        Dim ada As SqlDataAdapter = Nothing

        Try
            ada = New SqlDataAdapter(sSQL, conn)
            ada.Fill(ds)
        Catch ex As Exception
            Throw ex
        Finally
            ada.Dispose()
            ada = Nothing
        End Try

        Return ds

    End Function

    Public Shared Function SetData(ByRef conn As SqlConnection,
                                   ByVal sSQL As String) As Boolean

        Try
            Return MSSQLUtils.SetData(conn, sSQL, conn.ConnectionTimeout, SQLCommandType.TEXT)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function SetData(ByRef conn As SqlConnection,
                                   ByVal sSQL As String,
                                   ByVal iCommandTimeOut As Integer) As Boolean

        Try
            Return MSSQLUtils.SetData(conn, sSQL, iCommandTimeOut, SQLCommandType.TEXT)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function SetData(ByRef conn As SqlConnection,
                                   ByVal sSQL As String,
                                   ByVal iCommandTimeOut As Integer,
                                   ByVal cmdType As SQLCommandType) As Boolean

        Dim cmd As SqlCommand = Nothing
        Dim b As Boolean = False

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = sSQL
            If IsNothing(iCommandTimeOut) Then iCommandTimeOut = 60 Else cmd.CommandTimeout = iCommandTimeOut

            Select Case cmdType
                Case SQLCommandType.STOREDPROCEDURE : cmd.CommandType = CommandType.StoredProcedure
                Case SQLCommandType.TEXT : cmd.CommandType = CommandType.Text
            End Select

            cmd.ExecuteNonQuery()
            b = True

        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try

        Return b

    End Function

End Class
