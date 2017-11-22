
Imports System.Text

Public Class DateAndTimeUtils
    Inherits BaseUtils

    Public Enum DateStyle
        SWEDISH
        ENGLISH
        FINNISH
    End Enum

    Public Enum DateFormat
        [SHORT] = 0
        [LONG] = 1
    End Enum

    Public Enum TimeDiffStyle
        D       'days
        S       'seconds
        M       'minutes
        H       'hours
        MS      'minutes:seconds
        HMS     'hours:minutes:seconds
        DHMS    'days:hours:minutes:seconds
    End Enum

    Public Shared Function FormatDateForMySQL(ByVal d As Date) As String

        Try
            Return d.Year.ToString & "-" & _
                    DateAndTimeUtils.FormatMonth(d.Month) & "-" & _
                    DateAndTimeUtils.FormatDay(d.Day)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function ConvertTime(ByVal dtDate As Date, ByVal sSeparatorChar As String, ByVal bThrowEx As Boolean) As String

        Try
            Dim sb As New StringBuilder
            sb.Append(FormatHour(dtDate.Hour) & sSeparatorChar)
            sb.Append(FormatHour(dtDate.Minute) & sSeparatorChar)
            sb.Append(FormatHour(dtDate.Second))
            Return sb.ToString
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return ""

    End Function

    Public Shared Function ConvertDate(ByVal style As DateStyle, _
                                       ByVal dtDate As Date) As String

        Try
            Return DateAndTimeUtils.ConvertDate(style, DateFormat.LONG, dtDate)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function ConvertDate(ByVal style As DateStyle, _
                                       ByVal format As DateFormat, _
                                       ByVal dtDate As Date) As String

        Dim sb As New StringBuilder
        Dim sDateSeparator As String = ""
        Dim sTimeSeparator As String = ""

        Try
            Select Case style
                Case DateStyle.SWEDISH
                    sDateSeparator = "-"
                    sTimeSeparator = ":"
                    sb.Append(dtDate.Year & sDateSeparator)
                    sb.Append(DateAndTimeUtils.FormatMonth(dtDate.Month) & sDateSeparator)
                    sb.Append(DateAndTimeUtils.FormatDay(dtDate.Day))
                    If format = DateFormat.LONG Then
                        sb.Append(" " & DateAndTimeUtils.FormatHour(dtDate.Hour) & sTimeSeparator)
                        sb.Append(DateAndTimeUtils.FormatMinute(dtDate.Minute) & sTimeSeparator)
                        sb.Append(DateAndTimeUtils.FormatSecond(dtDate.Second))
                    End If
                Case DateStyle.FINNISH
                    sDateSeparator = "."
                    sTimeSeparator = ":"
                    sb.Append(DateAndTimeUtils.FormatDay(dtDate.Day) & sDateSeparator)
                    sb.Append(DateAndTimeUtils.FormatMonth(dtDate.Month) & sDateSeparator)
                    sb.Append(dtDate.Year)
                    If format = DateFormat.LONG Then
                        sb.Append(" " & DateAndTimeUtils.FormatHour(dtDate.Hour) & sTimeSeparator)
                        sb.Append(DateAndTimeUtils.FormatMinute(dtDate.Minute) & sTimeSeparator)
                        sb.Append(DateAndTimeUtils.FormatSecond(dtDate.Second))
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return sb.ToString

    End Function

    Public Shared Function GetDate(ByVal sDate As String) As Date

        Try
            Return DateAndTimeUtils.GetDate(sDate, DateFormat.SHORT)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetDate(ByVal sDate As String, _
                                   ByVal format As DateFormat) As Date

        Try
            If IsDate(sDate.Trim) Then
                Select Case format
                    Case DateFormat.LONG
                        Return Date.Parse(sDate)
                    Case DateFormat.SHORT
                        Return Date.Parse(Date.Parse(sDate).ToShortDateString)
                End Select
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return Nothing

    End Function

    Public Shared Function GetDate(ByVal style As DateStyle) As String

        Dim sRet As String = ""

        Try
            Select Case style
                'Case DateStyle.ENGLISH
                Case DateStyle.SWEDISH : sRet = DateAndTimeUtils.ConvertDate(DateStyle.SWEDISH, Date.Now)
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sRet

    End Function

    Public Shared Function FormatMonth(ByVal iMonth As Integer) As String

        Try
            If iMonth < 10 Then
                Return "0" & iMonth
            Else
                Return iMonth.ToString
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function FormatDay(ByVal iDay As Integer) As String

        Try
            If iDay < 10 Then
                Return "0" & iDay
            Else
                Return iDay.ToString
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function FormatHour(ByVal iHour As Integer) As String

        Try
            If iHour < 10 Then
                Return "0" & iHour
            Else
                Return iHour.ToString
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function FormatMinute(ByVal iMinute As Integer) As String

        Try
            If iMinute < 10 Then
                Return "0" & iMinute
            Else
                Return iMinute.ToString
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function FormatSecond(ByVal iSecond As Integer) As String

        Try
            If iSecond < 10 Then
                Return "0" & iSecond
            Else
                Return iSecond.ToString
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function IsTimeMatch(ByVal sHour As String, _
                                       ByVal sMinute As String) As Boolean

        Try
            Return DateAndTimeUtils.IsTimeMatch(sHour, sMinute, 30)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    'Checks if the time set in sHour and sMinute is in the interval
    'set by the current time and iLimitMinutes
    'Debug.WriteLine(DateAndTimeUtils.IsTimeMatch("13", "00", 10))
    Public Shared Function IsTimeMatch(ByVal sHour As String, _
                                       ByVal sMinute As String, _
                                       ByVal iLimitMinutes As Integer) As Boolean

        Dim iHour As Integer
        Dim iMinute As Integer
        Dim upper As Time
        Dim lower As Time

        If iLimitMinutes < 0 Then iLimitMinutes = 0
        If iLimitMinutes > 1440 Then iLimitMinutes = 1440 '24h * 60min

        Try
            iHour = Integer.Parse(sHour)
            If iHour < 0 Or iHour > 23 Then Return False

            iMinute = Integer.Parse(sMinute)
            If iMinute < 0 Or iMinute > 59 Then Return False

            upper = DateAndTimeUtils.GetUpperTimeBound(iHour, iMinute, iLimitMinutes)
            'Debug.WriteLine("Upper = " & upper.ToString())

            lower = DateAndTimeUtils.GetLowerTimeBound(iHour, iMinute, iLimitMinutes)
            'Debug.WriteLine("Lower = " & lower.ToString())

            Return DateAndTimeUtils.IsInInterval(upper, lower)

        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    'Get the upper time bound, specified by iLimitMinutes
    Public Shared Function GetUpperTimeBound(ByVal iHour As Integer, _
                                           ByVal iMinute As Integer, _
                                           ByVal iLimitMinutes As Integer) As Time

        Dim iAdditionalHours As Integer
        Dim iAdditionalMinutes As Integer

        'the normal case
        If iLimitMinutes = 0 Then Return New Time(iHour, iMinute)

        iAdditionalHours = CInt(Math.Floor(iLimitMinutes / 60))
        iAdditionalMinutes = iLimitMinutes Mod 60

        If iLimitMinutes >= 60 Then
            If (iLimitMinutes Mod 60) < 0 Then
                iHour += iAdditionalHours + 1
            Else
                iHour += iAdditionalHours
            End If
        End If

        iMinute = iAdditionalMinutes

        Return New Time(iHour, iMinute)

    End Function

    'Get the lower time bound, specified by iLimitMinutes
    Public Shared Function GetLowerTimeBound(ByVal iHour As Integer, _
                                             ByVal iMinute As Integer, _
                                             ByVal iLimitMinutes As Integer) As Time

        Dim iAdditionalHours As Integer
        Dim iAdditionalMinutes As Integer

        'the normal case
        If iLimitMinutes = 0 Then Return New Time(iHour, iMinute)

        iAdditionalHours = CInt(Math.Floor(iLimitMinutes / 60))
        iAdditionalMinutes = iLimitMinutes Mod 60

        If iLimitMinutes > 60 Then
            If (iLimitMinutes Mod 60) > 0 Then
                iHour -= iAdditionalHours + 1
            Else
                iHour -= iAdditionalHours
            End If
        Else
            iHour -= 1
        End If

        iMinute = 60 - iAdditionalMinutes

        Return New Time(iHour, iMinute)

    End Function

    'Find out if current time is in the interval
    'of the bounds of lower and upper time
    Public Shared Function IsInInterval(ByVal upper As Time, _
                                        ByVal lower As Time) As Boolean


        Try
            If DateAndTimeUtils._isGreaterThanOrEqual(lower) AndAlso DateAndTimeUtils._isLessThanOrEqual(upper) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    'Is current time greater than the lower time bound?
    Private Shared Function _isGreaterThanOrEqual(ByVal lower As Time) As Boolean

        If Date.Now.Hour > lower.Hour Then
            Return True
        Else
            If Date.Now.Hour = lower.Hour Then
                If Date.Now.Minute >= lower.Minute Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If

    End Function

    'Is current time less than the upper time bound?
    Private Shared Function _isLessThanOrEqual(ByVal upper As Time) As Boolean

        If Date.Now.Hour < upper.Hour Then
            Return True
        Else
            If Date.Now.Hour = upper.Hour Then
                If Date.Now.Minute <= upper.Minute Then
                    Return True
                End If
            Else
                Return False
            End If
        End If

        Return Nothing

    End Function

    'Matches one or many days against today.
    Public Shared Function IsWeekDayMatch(ByVal sDay As String, _
                                          Optional ByVal sSeparatorChar As String = ";") As Boolean


        Dim sDays() As String
        Dim collDays As New Collection
        Dim collSystemDays As New Collection
        Dim sSystemDayOfWeek As String
        Dim i As Integer

        sDay = sDay.Trim
        sSystemDayOfWeek = Date.Now.DayOfWeek.ToString()

        If sDay.IndexOf(sSeparatorChar) > 0 Then
            sDays = sDay.Split(sSeparatorChar.ToCharArray)
            For i = 0 To sDays.Length - 1
                collDays.Add(sDays(i).ToString.ToUpper)
            Next
        Else
            collDays.Add(sDay.ToUpper)
        End If

        Select Case sSystemDayOfWeek.ToUpper
            Case "MONDAY"
                collSystemDays.Add("MONDAY")
                collSystemDays.Add("MÅNDAG")
                collSystemDays.Add("MAANANTAI")
            Case "TUESDAY"
                collSystemDays.Add("TUESDAY")
                collSystemDays.Add("TISDAG")
                collSystemDays.Add("TIISTAI")
            Case "WEDNESDAY"
                collSystemDays.Add("WEDNESDAY")
                collSystemDays.Add("ONSDAG")
                collSystemDays.Add("KESKIVIIKKO")
            Case "THURSDAY"
                collSystemDays.Add("THURSDAY")
                collSystemDays.Add("TORSDAG")
                collSystemDays.Add("TORSTAI")
            Case "FRIDAY"
                collSystemDays.Add("FRIDAY")
                collSystemDays.Add("FREDAG")
                collSystemDays.Add("PERJANTAI")
            Case "SATURDAY"
                collSystemDays.Add("SATURDAY")
                collSystemDays.Add("LÖRDAG")
                collSystemDays.Add("LAUANTAI")
            Case "SUNDAY"
                collSystemDays.Add("SUNDAY")
                collSystemDays.Add("SÖNDAG")
                collSystemDays.Add("SUNNUNTAI")
        End Select

        'Return StringUtils.IsInCollection(collDays, collSystemDays)
        Return StringUtils.IsInCollection(collSystemDays, collDays, True)

    End Function

    'Is the parameter date same as current date?
    Public Shared Function IsDateMatch(ByVal sYear As String, _
                                       ByVal sMonth As String, _
                                       ByVal sDay As String) As Boolean

        Dim iYear As Integer
        Dim iMonth As Integer
        Dim iDay As Integer

        Try
            iYear = Integer.Parse(sYear)
            iMonth = Integer.Parse(sMonth)
            iDay = Integer.Parse(sDay)

            If iYear = Date.Now.Year Then
                If iMonth = Date.Now.Month Then
                    If iDay = Date.Now.Day Then
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return False

    End Function

    Public Shared Function GetTimeDiff(ByVal dateStart As Date, _
                                       ByVal dateFinished As Date, _
                                       ByVal style As TimeDiffStyle, _
                                       Optional ByVal sDelimiter As String = ":") As String

        Dim sSeconds As String
        Dim sMinutes As String
        Dim sHours As String
        Dim sDays As String


        Try
            sSeconds = DateAndTimeUtils.FormatSecond(Date.op_Subtraction(dateFinished, dateStart).Seconds)
            sMinutes = DateAndTimeUtils.FormatMinute(Date.op_Subtraction(dateFinished, dateStart).Minutes)
            sHours = DateAndTimeUtils.FormatHour(Date.op_Subtraction(dateFinished, dateStart).Hours)
            sDays = Date.op_Subtraction(dateFinished, dateStart).Days

            Select Case style

                Case TimeDiffStyle.D
                    Return sDays

                Case TimeDiffStyle.S
                    Return sSeconds

                Case TimeDiffStyle.M
                    Return sMinutes

                Case TimeDiffStyle.MS
                    Return sMinutes & sDelimiter & sSeconds

                Case TimeDiffStyle.HMS
                    Return sHours & sDelimiter & sMinutes & sDelimiter & sSeconds

                Case TimeDiffStyle.H
                    Return sHours

                Case TimeDiffStyle.DHMS
                    Return sDays & sDelimiter & sHours & sDelimiter & sMinutes & sDelimiter & sSeconds

            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return String.Empty

    End Function

    Public Shared Function FormatTime(ByVal time As TimeSpan, _
                                      ByVal style As TimeDiffStyle, _
                                      Optional ByVal sDelimiter As String = ":") As String

        Dim sSeconds As String
        Dim sMinutes As String
        Dim sHours As String
        Dim sDays As String


        Try
            sSeconds = DateAndTimeUtils.FormatSecond(time.Seconds)
            sMinutes = DateAndTimeUtils.FormatMinute(time.Minutes)
            sHours = DateAndTimeUtils.FormatHour(time.Hours)
            sDays = DateAndTimeUtils.FormatDay(time.Days)

            Select Case style

                Case TimeDiffStyle.S
                    Return sSeconds

                Case TimeDiffStyle.M
                    Return sMinutes

                Case TimeDiffStyle.MS
                    Return sMinutes & sDelimiter & sSeconds

                Case TimeDiffStyle.HMS
                    Return sHours & sDelimiter & sMinutes & sDelimiter & sSeconds

                Case TimeDiffStyle.H
                    Return sHours

                Case TimeDiffStyle.DHMS
                    Return sDays & sDelimiter & sHours & sDelimiter & sMinutes & sDelimiter & sSeconds

            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return String.Empty

    End Function

    Public Shared Function GetDurationInMinutes(ByVal iDurationHour As Integer, _
                                                ByVal iDurationMinutes As Integer) As Integer

        Dim iTotalDurationinMinutes As Integer = 0

        Try
            iTotalDurationinMinutes = iDurationHour * 60
            iTotalDurationinMinutes += iDurationMinutes
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return iTotalDurationinMinutes

    End Function

    Public Shared Function GetMonthNameByNumber(ByVal iMonthNumber As Integer) As String

        Dim s As String = ""

        Try
            Select Case iMonthNumber
                Case 1 : s = "Jan"
                Case 2 : s = "Feb"
                Case 3 : s = "Mar"
                Case 4 : s = "Apr"
                Case 5 : s = "May"
                Case 6 : s = "Jun"
                Case 7 : s = "Jul"
                Case 8 : s = "Aug"
                Case 9 : s = "Sep"
                Case 10 : s = "Oct"
                Case 11 : s = "Nov"
                Case 12 : s = "Dec"
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return s

    End Function

End Class
