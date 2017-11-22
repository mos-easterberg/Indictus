
Imports System.Windows.Forms

Public Class GridUtils
    Inherits BaseUtils

    Public Shared Function SaveToFile(ByVal sFilePath As String, ByVal sDelimiter As String, ByRef grid As DataGridView) As Boolean

        Dim b As Boolean = False

        Try
            Dim headers = (From header As DataGridViewColumn In grid.Columns.Cast(Of DataGridViewColumn)()
               Select header.HeaderText).ToArray
            Dim rows = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)() _
                       Where Not row.IsNewRow _
                       Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))


            Using sw As New IO.StreamWriter(sFilePath)
                sw.WriteLine(String.Join(sDelimiter, headers))
                For Each r In rows
                    sw.WriteLine(String.Join(sDelimiter, r))
                Next
            End Using

            b = True
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

End Class
