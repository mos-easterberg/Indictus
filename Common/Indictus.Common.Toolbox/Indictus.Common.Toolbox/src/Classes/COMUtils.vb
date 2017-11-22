
Imports System.Windows.Forms

Public Class COMUtils
    Inherits BaseUtils

    Public Shared Function ReleaseObject(ByRef obj As Object) As Boolean

        Dim iRel As Integer = 0
        Dim b As Boolean = False

        Try
            Do
                iRel = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            Loop While iRel > 0
            b = True
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

        Return b

    End Function

End Class
