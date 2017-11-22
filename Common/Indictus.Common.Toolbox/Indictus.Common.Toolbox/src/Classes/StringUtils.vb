
Imports System.Text

Public Class StringUtils
    Inherits BaseUtils

    Public Enum Modification
        [LOWER]
        [UPPER]
        [TRIM]
    End Enum

    Public Enum PadDirection
        [LEFT]
        [RIGHT]
        [BOTH]
    End Enum

    Public Enum MatchMode
        CONTAINS
    End Enum

    Public Enum WhiteSpace
        NEWLINE
        TAB
        SPACE
    End Enum

    Public Shared Function ConstructWhiteSpace(ByVal iNrOfMoves As Integer,
                                               ByVal type As WhiteSpace) As String

        Dim sb As New StringBuilder

        Try
            For i As Integer = 0 To iNrOfMoves - 1
                Select Case type
                    Case WhiteSpace.NEWLINE : sb.Append(vbNewLine)
                    Case WhiteSpace.SPACE : sb.Append(" ")
                    Case WhiteSpace.TAB : sb.Append(vbTab)
                End Select
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function Replace(ByVal sStr As String, _
                                   ByVal sOldChar As String, _
                                   ByVal sNewChar As String) As String

        Try
            Return sStr.Replace(sOldChar, sNewChar)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function IsInArray(ByVal sSub() As String, _
                                     ByVal sMain() As String) As Boolean

        Dim i, j As Integer
        Dim m, s As String

        Try
            For i = 0 To sMain.Length - 1
                m = sMain(i).Trim.ToUpper
                For j = 0 To sSub.Length - 1
                    s = sSub(j).Trim.ToUpper
                    If m.Equals(s) Then
                        Return True
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return False

    End Function

    Public Shared Function IsInCollection(ByVal collSub As Collection, _
                                          ByVal collMain As Collection, _
                                          ByVal bCaseSensitive As Boolean) As Boolean

        Dim b As Boolean = False

        Try
            For Each sSub As String In collSub
                For Each sMain As String In collMain
                    If bCaseSensitive Then
                        'm = M?
                        If sSub.Equals(sMain) Then
                            Return True
                        End If
                    Else
                        'M = M!
                        If sSub.ToUpper.Equals(sMain.ToUpper) Then
                            Return True
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return False

    End Function

    Public Shared Function IsInDelimitedString(ByVal sDelimitedString As String, _
                                               ByVal sDelimiter As String, _
                                               ByVal sStringToFind As String, _
                                               ByVal bCaseSensitive As Boolean) As Boolean

        Dim b As Boolean = False

        Try

            For Each s As String In StringUtils.Split(sDelimitedString, sDelimiter, False)
                If bCaseSensitive Then
                    If s.Equals(sStringToFind) Then
                        b = True
                        Exit For
                    End If
                Else
                    If s.ToUpper.Equals(sStringToFind.ToUpper) Then
                        b = True
                        Exit For
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function CountOccurance(ByVal sChar As String, _
                                          ByVal sString As String, _
                                          ByVal bCaseSensitive As Boolean) As Integer

        Dim i As Integer
        Dim count As Integer

        Try
            If Not bCaseSensitive Then
                sChar = sChar.ToUpper
                sString = sString.ToUpper
            End If

            For i = 0 To sString.Length - 1
                If sString.Substring(i, 1).Equals(sChar) Then
                    count += 1
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return count

    End Function

    Public Shared Function Split(ByVal sStr As String) As ArrayList

        Try
            Return StringUtils.Split(sStr, ";", False)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function Split(ByVal sStr As String, _
                                 ByVal sDelimiter As String) As ArrayList

        Try
            Return StringUtils.Split(sStr, sDelimiter, False)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function Split(ByVal sStr As String, _
                                 ByVal sDelimiter As String, _
                                 ByVal bAcceptEmptyLines As Boolean) As ArrayList

        Dim arr As New ArrayList

        Try
            For Each s As String In sStr.Split(sDelimiter.ToCharArray)
                s = s.Trim
                If s.Equals(String.Empty) Then
                    If bAcceptEmptyLines Then
                        arr.Add(s)
                    End If
                Else
                    arr.Add(s)
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return arr

    End Function

    Public Shared Function SplitByFirstOccurence(ByVal sStringToSplit As String, _
                                                 ByVal sDelimiter As String) As Collection

        Dim iIndexOfDelimiter As Integer = 0
        Dim coll As New Collection

        Try
            iIndexOfDelimiter = sStringToSplit.IndexOf(sDelimiter)
            coll.Add(sStringToSplit.Substring(0, iIndexOfDelimiter))
            coll.Add(sStringToSplit.Substring(iIndexOfDelimiter + 1, sStringToSplit.Length - iIndexOfDelimiter - 1))
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return coll

    End Function

    Public Shared Function GetMidSubString(ByVal iStartPos As Integer, _
                                           ByVal iEndPos As Integer, _
                                           ByVal sStr As String) As String

        Try
            Return sStr.Substring(iStartPos + 1, iEndPos - iStartPos - 1)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetMidSubString(ByVal sStartChar As String, _
                                           ByVal sEndChar As String, _
                                           ByVal sStr As String) As String

        Dim iStartPos As Integer = 0
        Dim iEndPos As Integer = 0
        Dim sTmp As String = ""

        'English [ENG] ==> ENG
        'Finnish [FI]  ==> FI

        Try
            iStartPos = sStr.IndexOf(sStartChar)
            iEndPos = sStr.IndexOf(sEndChar)
            If iEndPos <= iStartPos Then
                sTmp = ""
            End If
            sTmp = sStr.Substring(iStartPos + 1, iEndPos - iStartPos - 1)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sTmp

    End Function

    Public Shared Function ModifyArrayList(ByVal arr As ArrayList, _
                                           ByVal modif As Modification) As ArrayList

        Dim i As Integer = 0

        Try
            For i = 0 To arr.Count - 1
                Select Case modif
                    Case Modification.LOWER
                        arr.Item(i) = arr.Item(i).ToString.ToLower()
                    Case Modification.UPPER
                        arr.Item(i) = arr.Item(i).ToString.ToUpper()
                    Case Modification.TRIM
                        arr.Item(i) = arr.Item(i).ToString.Trim()
                End Select
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return arr

    End Function

    Public Shared Function Pad(ByVal sStr As String, _
                               ByVal sPadChar As String, _
                               ByVal iDesiredPaddedLength As Integer, _
                               ByVal direction As PadDirection) As String

        Dim sPadString As String = ""

        Try
            If sStr.Length = iDesiredPaddedLength Then Return sStr

            For i = sStr.Length To iDesiredPaddedLength - 1
                sPadString = sPadString & sPadChar
            Next

            Select Case direction
                Case PadDirection.LEFT : sStr = sPadString & sStr
                Case PadDirection.RIGHT : sStr = sStr & sPadString
                Case PadDirection.BOTH : sStr = sPadString & sStr & sPadString
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sStr

    End Function

    Public Shared Function MergeStringArrays(ByVal sArray1 As String(), ByVal sArray2 As String()) As String()

        Try
            Dim i As Integer = 0
            Dim iLength As Integer = sArray1.Length
            ReDim Preserve sArray1(iLength + sArray2.Length - 1)

            For Each s As String In sArray2
                sArray1.SetValue(s, iLength + i)
                i += 1
            Next

            Return sArray1
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ArrayListToString(ByVal list As ArrayList) As String

        Dim sRet As String = ""

        Try
            For Each s As String In list
                sRet = sRet & s & ", "
            Next
            sRet = sRet.Substring(0, sRet.Length - 2)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sRet

    End Function

    Public Shared Function Matches(ByVal sString As String,
                                   ByVal sMask As String,
                                   ByVal bCaseSensitive As Boolean,
                                   ByVal matchMode As MatchMode) As Boolean

        Dim b As Boolean = False

        Try

            Select Case matchMode

                'CONTAINS
                Case StringUtils.MatchMode.CONTAINS
                    If bCaseSensitive Then
                        b = sString.Contains(sMask)
                    Else
                        b = sString.ToUpper.Contains(sMask.ToUpper)
                    End If

            End Select

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function IsNullOrWhiteSpace(ByVal sStr As String) As Boolean
        Return String.IsNullOrWhiteSpace(sStr)
    End Function

    'Public Shared Function Join() As String

    '    Try
    '        String.Join(
    '    Catch ex As Exception

    '    End Try

    'End Function

End Class
