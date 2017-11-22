
Imports System.Math

Public Class MathUtils
    Inherits BaseUtils

    Public Shared Function GetTriangleArea(ByVal iBaseLength As Integer,
                                           ByVal iHeight As Integer) As Double
        Return iBaseLength * iHeight / 2
    End Function

    Public Shared Function GetParallelogramArea(ByVal iBaseLength As Integer,
                                                ByVal iHeight As Integer) As Double
        Return iBaseLength * iHeight
    End Function

    Public Shared Function GetParallelTrapezeArea(ByVal iBaseLength As Integer,
                                                   ByVal iRoofLength As Integer,
                                                   ByVal iHeight As Integer) As Double
        Return iHeight / 2 * (iBaseLength + iRoofLength)
    End Function

    Public Shared Function GetCircleArea(ByVal iRadius As Integer) As Double
        Return Math.PI * Math.Pow(iRadius, 2)
    End Function

    Public Shared Function GetCircleCircumference(ByVal iRadius As Integer) As Double
        Return 2 * iRadius * Math.PI
    End Function

    Public Shared Function GetCircleSectorArea(ByVal iRadius As Integer,
                                               ByVal iBowLength As Integer) As Double
        Return (iRadius * iBowLength) / 2
    End Function

    Public Shared Function GetCylinderVolume(ByVal iRadius As Integer,
                                             ByVal iHeight As Integer) As Double
        Return Math.PI * Math.Pow(iRadius, 2) * iHeight
    End Function

    Public Shared Function GetCylinderCaseArea(ByVal iRadius As Integer,
                                               ByVal iHeight As Integer) As Double
        Return 2 * Math.PI * iRadius * iHeight
    End Function

    Public Shared Function GetPyramidVolume(ByVal iBaseLength As Integer,
                                            ByVal iHeight As Integer) As Double
        Return (iBaseLength * iHeight) / 3
    End Function

    Public Shared Function GetConeCaseArea(ByVal iRadius As Integer,
                                           ByVal iSideHeight As Integer) As Double
        Return Math.PI * iRadius * iSideHeight
    End Function

    Public Shared Function GetConeVolume(ByVal iRadius As Integer,
                                         ByVal iHeight As Integer) As Double
        Return (Math.PI * Math.Pow(iRadius, 2) * iHeight) / 3
    End Function

    Public Shared Function GetBowlArea(ByVal iRadius As Integer) As Double
        Return 4 * Math.PI * Math.Pow(iRadius, 2)
    End Function

    Public Shared Function GetBowlVolume(ByVal iRadius As Integer) As Double
        Return (4 * Math.PI * Math.Pow(iRadius, 3)) / 3
    End Function

End Class
