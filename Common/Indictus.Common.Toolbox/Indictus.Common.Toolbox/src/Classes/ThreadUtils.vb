
Imports System.Threading

Public Class ThreadUtils
    Inherits BaseUtils

    Public Shared Sub SleepHours(ByVal iHours As Integer)

        Try
            Thread.Sleep(1000 * 60 * 60 * iHours)
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SleepMinutes(ByVal iMinutes As Integer)

        Try
            Thread.Sleep(1000 * 60 * iMinutes)
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SleepSeconds(ByVal iSeconds As Integer)

        Try
            Thread.Sleep(1000 * iSeconds)
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SleepMilliSeconds(ByVal iMilliSeconds As Integer)

        Try
            Thread.Sleep(iMilliSeconds)
        Catch ex As Exception
        End Try

    End Sub

End Class

