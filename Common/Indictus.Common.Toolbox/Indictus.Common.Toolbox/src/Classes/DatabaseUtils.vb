
Option Strict Off

Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Text

Public Class DatabaseUtils
    Inherits BaseUtils

    Public Enum DBVendor
        [MYSQL] = 0
        [MSSQL] = 1
        [POSTGRES] = 2
    End Enum

    Public Enum ConnectionType
        [StandardSecurity] = 0
        [TrustedConnection] = 1
        [ConnectViaIP] = 2
    End Enum

    Public Enum SQLCommandType
        [STORED_PROCEDURE] = 0
        [TEXT] = 1
    End Enum

    Public Enum DBItemType
        [TABLE] = 0
        [VIEW] = 1
        [STORED_PROCEDURE] = 2
        [TRIGGER] = 3
        [INDEX] = 4
    End Enum

    Public Shared Function IsConnOpen(ByRef conn As IDbConnection) As Boolean

        Try
            Return (conn.State = ConnectionState.Open)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function ConstructConnectionString(ByVal dbVendor As DatabaseUtils.DBVendor, _
                                                       ByVal sServer As String, _
                                                       ByVal iPort As Integer, _
                                                       ByVal sDatabase As String, _
                                                       ByVal sUsername As String, _
                                                       ByVal sPassword As String, _
                                                       ByVal iDBTimeOutSeconds As Integer) As String

        Dim sb As New StringBuilder
        Dim sDelimiter As String = ""

        Try
            Select Case dbVendor

                Case DatabaseUtils.DBVendor.MSSQL

                Case DatabaseUtils.DBVendor.MYSQL
                    'Server=127.0.0.1;Port=3306;Database=dev;Uid=root;Pwd=rootsql;
                    sDelimiter = ";"
                    sb.Append("Server=" & sServer & sDelimiter)
                    sb.Append("Port=" & iPort.ToString & sDelimiter)
                    sb.Append("Database=" & sDatabase & sDelimiter)
                    sb.Append("Uid=" & sUsername & sDelimiter)
                    sb.Append("Pwd=" & sPassword & sDelimiter)

                Case DatabaseUtils.DBVendor.POSTGRES

            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function GetSqlConnection(ByVal sConnectionString As String) As SqlConnection

        Dim conn As New SqlConnection

        Try
            conn.ConnectionString = sConnectionString
            conn.Open()

            If conn.State = ConnectionState.Open Then
                Return conn
            Else
                conn.Dispose()
                conn = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetConnection(ByVal sType As String, _
                                         ByVal sConnectionString As String) As IDbConnection

        Dim conn As IDbConnection = Nothing

        Try

            Select Case sType.ToUpper()
                Case "OLEDB" : conn = New OleDbConnection(sConnectionString)
                Case "ODBC" : conn = New OdbcConnection(sConnectionString)
            End Select

            conn.Open()
            If conn.State = ConnectionState.Open Then
                Return conn
            Else
                conn.Dispose()
                conn = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function CloseReader(ByRef reader As IDataReader) As Boolean

        Try
            If Not reader Is Nothing Then
                If reader.IsClosed Then
                    Return True
                Else
                    reader.Close()
                    If reader.IsClosed Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return False

    End Function

    Public Shared Function GetSPCommandText(ByVal sSpName As String) As String
        Return "EXEC " & sSpName.Trim
    End Function

    Public Shared Function SQLEscape(ByVal StringToEscape As String) As String

        Dim Result As String

        Try
            Result = Replace(Trim(StringToEscape & ""), "'", "''")
            Result = Replace(Result, "|", "")
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return Result

    End Function

    Public Shared Function GetSPCommandText(ByVal sSpName As String, _
                                            ByVal params As Collection) As String

        Dim sRet As String
        Dim sValue As String

        Dim sString As String
        Dim iInteger As Integer
        Dim dtDate As Date

        'cmd.CommandText = "EXEC up_TableMappingInsert @BOOKITTable='sdlfksdf'"
        sRet = "EXEC " & sSpName.Trim

        Try

            For Each p As StoredProcParameter In params
                Select Case p.Type

                    'STRING
                    Case StoredProcParameter.ValueTypes.STRING
                        Try
                            sString = p.Value.ToString
                            If sString.Equals("") Then
                                sRet = sRet & " " & p.Name & "=NULL, "
                            Else
                                sRet = sRet & " " & p.Name & "='" & DatabaseUtils.SQLEscape(sString) & "', "
                            End If
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try


                        'INTEGER
                    Case StoredProcParameter.ValueTypes.INTEGER
                        Try
                            iInteger = Integer.Parse(p.Value.ToString)
                            sRet = sRet & " " & p.Name & "=" & iInteger & ", "
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try


                        'DATE
                    Case StoredProcParameter.ValueTypes.DATE
                        Try
                            dtDate = p.Value
                            sRet = sRet & " " & p.Name & "='" & _
                                    DateAndTimeUtils.ConvertDate(DateAndTimeUtils.DateStyle.SWEDISH, _
                                                                dtDate) & "', "
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try


                        'DECIMAL
                    Case StoredProcParameter.ValueTypes.DECIMAL
                        Try
                            sValue = p.Value.ToString.Replace(",", ".")
                            If sValue.Equals("") Then
                                sRet = sRet & " " & p.Name & "=NULL, "
                            Else
                                sRet = sRet & " " & p.Name & "=" & sValue & ", "
                            End If
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try


                        'BOOLEAN
                    Case StoredProcParameter.ValueTypes.BOOLEAN
                        Try
                            If p.Value Then
                                sRet = sRet & " " & p.Name & "=1, "
                            Else
                                sRet = sRet & " " & p.Name & "=0, "
                            End If
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try

                        'CHAR
                    Case StoredProcParameter.ValueTypes.CHAR
                        Try
                            sString = p.Value.ToString
                            If sString.Equals("") Then
                                sRet = sRet & " " & p.Name & "=NULL, "
                            ElseIf sString.Length = 1 Then
                                sRet = sRet & " " & p.Name & "='" & DatabaseUtils.SQLEscape(sString) & "', "
                            Else
                                sRet = sRet & " " & p.Name & "=NULL, "
                            End If
                        Catch ex As Exception
                            sRet = sRet & " " & p.Name & "=NULL, "
                        End Try

                End Select

            Next

            sRet = sRet.Remove(sRet.Length - 2, 2)
            'Debug.WriteLine(sRet)

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sRet

    End Function

    Public Shared Function Disconnect(ByRef conn As IDbConnection) As Boolean

        Dim b As Boolean = False

        Try
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    conn.Dispose()
                    conn = Nothing
                    b = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function ConvertDBNull(ByVal item As Object) As Object

        Dim o As Object = Nothing

        Try
            Select Case item.GetType.ToString.ToUpper
                Case "STRING" : o = DatabaseUtils._convertDBNull(DirectCast(item, String))
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return o

    End Function

    Private Shared Function _convertDBNull(ByVal item As String) As String

        Try
            If item Is Nothing Then
                Return String.Empty
            Else
                Return item
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetData(ByVal sCommandText As String, _
                                   ByRef conn As SqlConnection) As DataSet

        Try
            Return DatabaseUtils.GetData(sCommandText, conn, False)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetData(ByVal sCommandText As String, _
                                   ByRef conn As SqlConnection, _
                                   ByVal bClose As Boolean) As DataSet

        Dim ds As New DataSet
        Dim ada As SqlDataAdapter = Nothing

        Try
            ada = New SqlDataAdapter(sCommandText, conn)
            ada.Fill(ds)
        Catch ex As Exception
            Throw ex
        Finally
            ada.Dispose()
            If bClose Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return ds

    End Function

    Public Shared Sub SetData(ByVal sCommandText As String, _
                              ByVal cmdType As SQLCommandType, _
                              ByVal iCommandTimeOut As Integer, _
                              ByRef conn As SqlConnection)

        Try
            DatabaseUtils.SetData(sCommandText, cmdType, iCommandTimeOut, conn, False)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

    Public Shared Sub SetData(ByVal sCommandText As String, _
                              ByVal cmdType As SQLCommandType, _
                              ByVal iCommandTimeOut As Integer, _
                              ByRef conn As SqlConnection, _
                              ByVal bClose As Boolean)

        Dim cmd As SqlCommand

        Try
            If sCommandText.Equals("") Then Exit Sub

            cmd = conn.CreateCommand
            cmd.CommandText = sCommandText
            cmd.CommandTimeout = iCommandTimeOut

            Select Case cmdType
                Case SQLCommandType.STORED_PROCEDURE
                    cmd.CommandType = CommandType.StoredProcedure
                Case SQLCommandType.TEXT
                    cmd.CommandType = CommandType.Text
            End Select
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If bClose Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Sub

    Public Shared Function DropDatabase(ByVal sDatabaseName As String, _
                                        ByRef conn As SqlConnection) As Boolean

        Dim sSQL As String
        Dim b As Boolean = False

        Try
            sSQL = "DROP DATABASE " & sDatabaseName
            Toolbox.DatabaseUtils.SetData(sSQL, _
                                          Toolbox.DatabaseUtils.SQLCommandType.TEXT, _
                                          conn.ConnectionTimeout, _
                                          conn)
            b = True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function CreateDatabase(ByVal sDatabaseName As String, _
                                          ByRef conn As SqlConnection) As Boolean

        Dim sSQL As String
        Dim b As Boolean = False

        Try
            sSQL = "CREATE DATABASE " & sDatabaseName
            Toolbox.DatabaseUtils.SetData(sSQL, _
                                          Toolbox.DatabaseUtils.SQLCommandType.TEXT, _
                                          conn.ConnectionTimeout, _
                                          conn)
            b = True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Sub CloseConnection(ByRef conn As SqlConnection)

        Try
            conn.Close()
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

End Class
