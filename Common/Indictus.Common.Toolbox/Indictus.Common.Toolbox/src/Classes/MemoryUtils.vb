
Public Class MemoryUtils
    Inherits BaseUtils

    Public Enum ByteCoefficientEnum
        KB
        MB
    End Enum

    Public Shared Sub CollectGarbage(ByVal bThrowExOnError As Boolean)

        Try
            GC.Collect()
        Catch ex As Exception
            If bThrowExOnError Then Throw ex
        End Try

    End Sub

    Public Shared Function GetMemoryConsumption(ByVal bForceFullCollection As Boolean, ByVal byteCoefficient As ByteCoefficientEnum) As Integer

        Dim i As Integer = 0

        Try
            'i = System.Diagnostics.Process.PrivateMemorySize64
            'i = Process.GetCurrentProcess.PrivateMemorySize
            'i = Process.GetCurrentProcess.WorkingSet
            'i = Process.GetCurrentProcess.WorkingSet
            i = Process.GetCurrentProcess.PrivateMemorySize

            Select Case byteCoefficient
                Case ByteCoefficientEnum.KB
                    i = i / 1024
                Case ByteCoefficientEnum.MB
                    i = i / (1024 * 1024)
            End Select
        Catch ex As Exception
        End Try

        Return i

    End Function

End Class
