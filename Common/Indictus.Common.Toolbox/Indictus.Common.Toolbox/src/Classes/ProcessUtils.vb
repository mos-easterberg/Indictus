
Imports System.Windows.Forms

Public Class ProcessUtils
    Inherits BaseUtils

    Public Shared Function StartProcess(ByVal sCommand As String) As Process

        Try
            Return Process.Start(sCommand)
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function TerminateProcess(ByRef proc As Process) As Boolean

        Dim bTerminated As Boolean = False

        Try
            proc.Kill()
            proc = Nothing
            GC.Collect()
            bTerminated = True
        Catch ex As Exception
            Throw ex
        End Try

        Return bTerminated

    End Function

    Public Shared Function TerminateProcessesByName(ByVal sProcessName As String,
                                                    ByVal bThrowException As Boolean) As Boolean

        Dim bTerminated As Boolean = False

        Try
            For Each proc As Process In Process.GetProcessesByName(sProcessName)
                proc.Kill()
                proc = Nothing
                GC.Collect()
                bTerminated = IsNothing(proc)
            Next
        Catch ex As Exception
            If bThrowException Then Throw ex
        End Try

        Return bTerminated

    End Function

    Public Shared Function GetProcessesByName(ByVal sProcessName As String) As Process()

        Try
            Return Process.GetProcessesByName(sProcessName)
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

End Class
