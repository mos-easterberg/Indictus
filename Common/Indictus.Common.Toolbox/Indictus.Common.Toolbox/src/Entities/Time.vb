
Public Class Time

    Private _iHour As Integer
    Private _iMinute As Integer

    Public Sub New()
    End Sub

    Public Sub New(ByVal iHour As Integer, _
                   ByVal iMinute As Integer)
        Me._iHour = Me._checkHour(iHour)
        Me._iMinute = Me._checkMinute(iMinute)
    End Sub

    Private Function _checkHour(ByVal iHour As Integer) As Integer
        If iHour < 0 Then iHour = 0
        If iHour > 23 Then iHour = 0
        Return iHour
    End Function

    Private Function _checkMinute(ByVal iMinute As Integer) As Integer
        If iMinute < 0 Then iMinute = 0
        If iMinute > 59 Then iMinute = 0
        Return iMinute
    End Function

    Public Property Hour() As Integer
        Get
            Return Me._iHour
        End Get
        Set(ByVal Value As Integer)
            Me._iHour = Me._checkHour(Value)
        End Set
    End Property

    Public Property Minute() As Integer
        Get
            Return Me._iMinute
        End Get
        Set(ByVal Value As Integer)
            Me._iMinute = Me._checkMinute(Value)
        End Set
    End Property

    Public Overrides Function ToString() As String

        Dim sRet As String

        If Me._iHour < 9 Then
            sRet = "0" & Me._iHour.ToString
        Else
            sRet = Me._iHour.ToString
        End If

        sRet = sRet & ":"

        If Me._iMinute < 9 Then
            sRet = sRet & "0" & Me._iMinute.ToString
        Else
            sRet = sRet & Me._iMinute.ToString
        End If

        Return sRet


    End Function

End Class
