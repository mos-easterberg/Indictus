
Imports System.IO
Imports System.Text

Public Class FileUtils
    Inherits BaseUtils

    Public Shared Function CopyFile(ByVal sSourcePath As String, _
                                   ByVal sDestinationPath As String, _
                                   ByVal bOverwrite As Boolean) As Boolean

        Dim b As Boolean = False

        Try
            IO.File.Copy(sSourcePath, sDestinationPath, bOverwrite)
            b = True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function RenameFile(ByVal sSourceFilename As String, _
                                      ByVal sDestinationFilename As String, _
                                      ByVal sDestinationBackupFilename As String) As Boolean

        Dim b As Boolean = False

        Try
            IO.File.Replace(sSourceFilename, sDestinationFilename, sDestinationBackupFilename, True)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function MoveFileViaCopyAndDelete(ByVal sSourcePath As String,
                                                    ByVal sDestinationPath As String,
                                                    ByVal bOverwrite As Boolean) As Boolean

        Dim b As Boolean = False

        Try

            'MoveFileViaCopyAndDelete: copy & delete
            'if copy to new destination succeeds, then delete original
            '------------------------------------------------
            If FileUtils.CopyFile(sSourcePath, sDestinationPath, bOverwrite) Then
                b = FileUtils.DeleteFile(sSourcePath)
            End If

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function MoveFile(ByVal sSourcePath As String, _
                                    ByVal sDestinationPath As String) As Boolean

        Dim b As Boolean = False

        Try
            IO.File.Move(sSourcePath, sDestinationPath)
            b = True
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

    Public Shared Function GetSaveFileDialogFilter(Optional ByVal sDelimiter As String = "|") As String

        Dim sb As New StringBuilder

        Try
            sb.Append("Excel (*.xls)|*.xls")
            sb.Append(sDelimiter)
            sb.Append("PDF (*.pdf)|*.pdf")
            sb.Append(sDelimiter)
            sb.Append("XML (*.xml)|*.xml")
            sb.Append(sDelimiter)
            sb.Append("CSV (*.csv)|*.csv")
            sb.Append(sDelimiter)
            sb.Append("HTML (*.html)|*.html")
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sb.ToString

    End Function

    Public Shared Function WriteFile(ByVal sFilePath As String, _
                                     ByVal sStr As String, _
                                     ByVal sEncoding As String) As Boolean

        Dim b As Boolean = False
        Dim encoding As System.Text.Encoding = Nothing

        Try
            Return FileUtils.WriteFile(sFilePath, sStr, Toolbox.EncodingUtils.TranslateStringToEncoding(sEncoding))
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

    Public Shared Function WriteFile(ByVal sFilePath As String, _
                                     ByVal sStr As String, _
                                     ByVal encoding As System.Text.Encoding) As Boolean

        Dim sw As StreamWriter = Nothing
        Dim b As Boolean = False

        Try
            sw = New StreamWriter(sFilePath, False, encoding)
            sw.Write(sStr)
            sw.Close()
            b = True
        Catch ex As Exception
            Throw ex
        Finally
            sw = Nothing
        End Try

        Return b

    End Function

    Public Shared Function WriteMessage(ByVal sFilePathAndName As String, _
                                        ByVal sMessage As String, _
                                        ByVal encoding As System.Text.Encoding,
                                        ByVal bWriteTimeStamp As Boolean) As Boolean

        Dim fileStream As FileStream = Nothing
        Dim writer As StreamWriter = Nothing
        Dim b As Boolean = False

        Try

            'init
            '-------------------------------------------------------------------------
            fileStream = New FileStream(sFilePathAndName, FileMode.OpenOrCreate, FileAccess.Write)
            writer = New StreamWriter(fileStream, encoding)


            'write timestamp?
            '-------------------------------------------------------------------------
            If bWriteTimeStamp Then
                sMessage = DateAndTimeUtils.GetDate(DateAndTimeUtils.DateStyle.SWEDISH) & vbTab & sMessage & vbTab
            End If


            'lock the stream while writing
            '-------------------------------------------------------------------------
            SyncLock writer
                writer.BaseStream.Seek(0, SeekOrigin.End)
                writer.WriteLine(sMessage)
                writer.Flush()
                writer.Close()
                b = True
            End SyncLock

        Catch ex As Exception
            Throw ex
        Finally
            writer = Nothing
            fileStream = Nothing
        End Try

        Return b

    End Function

    'Can also append to an existing file
    Public Shared Function WriteMessage(ByVal sFilePathAndName As String, _
                                        ByVal sMessage As String, _
                                        Optional ByVal bWriteTimeStamp As Boolean = True, _
                                        Optional ByVal iNrOfEmptyLinesAfterText As Integer = 0, _
                                        Optional ByVal bEmptyLinesOverText As Boolean = False, _
                                        Optional ByVal iNrOfTabs As Integer = 0) As Boolean

        Dim fileStream As FileStream = Nothing
        Dim writer As StreamWriter = Nothing
        Dim i As Integer = 0
        Dim sTabs As String = ""
        Dim b As Boolean = False

        Try

            'init
            '-------------------------------------------------------------------------
            fileStream = New FileStream(sFilePathAndName, FileMode.OpenOrCreate, FileAccess.Write)
            writer = New StreamWriter(fileStream)


            'write timestamp?
            '-------------------------------------------------------------------------
            If bWriteTimeStamp Then sMessage = DateAndTimeUtils.GetDate(DateAndTimeUtils.DateStyle.SWEDISH) & vbTab & sMessage


            'tabs
            '-------------------------------------------------------------------------
            For i = 0 To iNrOfTabs - 1
                sTabs = sTabs & vbTab
            Next
            sMessage = sTabs & sMessage


            'lock the stream for writing
            '-------------------------------------------------------------------------
            SyncLock writer

                'Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End)

                If bEmptyLinesOverText Then
                    'Write empty lines over the text
                    For i = 0 To iNrOfEmptyLinesAfterText - 1
                        writer.WriteLine("")
                    Next

                    'Write the message
                    writer.WriteLine(sMessage)
                Else
                    'Write the message
                    writer.WriteLine(sMessage)

                    'Write empty lines under the text
                    For i = 0 To iNrOfEmptyLinesAfterText - 1
                        writer.WriteLine("")
                    Next
                End If

                writer.Flush()
                writer.Close()
                b = True

            End SyncLock

        Catch ex As Exception
            Throw ex
        Finally
            writer = Nothing
            fileStream = Nothing
        End Try

        Return b

    End Function

    'Checks and corrects a file name (' \ / : * ? " < > |)
    Public Shared Function CorrectFileName(ByVal sFileName As String, _
                                           ByVal bReplaceWhiteSpace As Boolean, _
                                           ByVal sReplaceWith As String) As String

        Dim replacables As New ArrayList
        Dim i As Integer

        Try

            'replacables.Add(IO.Path.GetInvalidFileNameChars)

            ' \ / : * ? " < > |
            replacables.Add("\")
            replacables.Add("/")
            replacables.Add(":")
            replacables.Add("*")
            replacables.Add("?")
            'replacables.Add(")
            replacables.Add("<")
            replacables.Add(">")
            replacables.Add("|")

            For i = 0 To replacables.Count - 1
                sFileName = sFileName.Replace(replacables(i).ToString, sReplaceWith)
            Next

            If bReplaceWhiteSpace Then
                sFileName = sFileName.Replace(" ", "_")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            replacables = Nothing
        End Try

        Return sFileName

    End Function

    Public Shared Function SecureFilePath(ByVal sPath As String) As String

        Try
            If Not sPath.EndsWith("\") Then
                sPath = sPath & "\"
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sPath

    End Function

    Public Shared Function SecureURLPath(ByVal sPath As String) As String

        Try
            If Not sPath.EndsWith("/") Then
                sPath = sPath & "/"
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sPath

    End Function

    Public Shared Function GetFileNameWithoutExtension(ByVal sFileName As String) As String

        Dim sFileNameWithoutExtension As String = ""

        Try
            'IO.Path.GetFileNameWithoutExtension(sFileName)
            sFileNameWithoutExtension = sFileName.Substring(0, sFileName.LastIndexOf("."))
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sFileNameWithoutExtension

    End Function

    Public Shared Function DoesFolderContainAnyOfFileTypes(ByVal sFolderPath As String, _
                                                           ByVal sFileExtensions As String) As Boolean

        Dim b As Boolean = False

        Try
            For Each sFilePath As String In IO.Directory.GetFiles(sFolderPath)
                For Each sExtension As String In StringUtils.Split(sFileExtensions, ";", False)
                    If FileUtils.GetFileExtension(sFilePath).ToUpper.Equals(sExtension.ToUpper) Then
                        Return True
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function GetFileExtension(ByVal sFileName As String) As String

        Dim sFileExtension As String = ""
        Dim sSplittedPieces() As Object

        Try
            'IO.Path.GetExtension(sFileName)
            sSplittedPieces = Toolbox.StringUtils.Split(sFileName, ".", False).ToArray
            sFileExtension = sSplittedPieces(sSplittedPieces.Length - 1).ToString
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sFileExtension

    End Function

    Public Shared Function ChangeFileExtension(ByVal sFileName As String, _
                                               ByVal sNewExtension As String) As String

        Dim sNewFilename As String = ""

        Try
            'IO.Path.ChangeExtension(sFileName, sNewExtension)
            sNewFilename = StringUtils.Replace(sFileName, FileUtils.GetFileExtension(sFileName), sNewExtension)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return sNewFilename

    End Function

    Public Shared Function GetFileNameFromPath(ByVal sFilePath As String) As String

        Try
            Return IO.Path.GetFileName(sFilePath)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ConvertFileToBase64String(ByVal sFilePath As String) As String

        Try
            Return Convert.ToBase64String(System.IO.File.ReadAllBytes(sFilePath))
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ReadFile(ByVal sFilePath As String) As String()

        Try
            Return FileUtils.ReadFile(sFilePath, System.Text.Encoding.Unicode)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function ReadFile(ByVal sFilePath As String, ByVal sEncoding As String) As String()

        Dim encoding As System.Text.Encoding = Nothing

        Try
            Select Case sEncoding
                Case "ASCII" : encoding = New System.Text.ASCIIEncoding
                Case "UNICODE" : encoding = New System.Text.UnicodeEncoding
                Case "UTF32" : encoding = New System.Text.UTF32Encoding
                Case "UTF7" : encoding = New System.Text.UTF7Encoding
                Case "UTF8" : encoding = New System.Text.UTF8Encoding
            End Select

            Return IO.File.ReadAllLines(sFilePath, encoding)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return Nothing

    End Function

    Public Shared Function ReadFile(ByVal sFilePath As String, ByVal encoding As System.Text.Encoding) As String()


        Try
            Return IO.File.ReadAllLines(sFilePath, encoding)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return Nothing

    End Function

    Public Shared Function GetFileAttributes(ByVal sFilePath As String) As System.IO.FileAttributes

        Try
            Return IO.File.GetAttributes(sFilePath)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function GetFileSize(ByVal sFilePath As String) As Long

        Dim stream As FileStream = Nothing
        Dim lLength As Long = 0

        Try
            stream = IO.File.OpenRead(sFilePath)
            lLength = stream.Length
        Catch ex As Exception
            Throw ex
        Finally
            stream.Close()
            stream = Nothing
        End Try

        Return lLength

    End Function

    Public Shared Function CreateDirectory(ByVal sPath As String) As Boolean

        Dim b As Boolean = False

        Try
            IO.Directory.CreateDirectory(sPath)
            b = True
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

    Public Shared Function CreateFile(ByVal sFilePath As String) As Boolean

        Dim b As Boolean = False
        Dim fs As FileStream = Nothing

        Try
            fs = IO.File.Create(sFilePath)
            fs.Close()
            b = True
        Catch ex As Exception
            Throw ex
        Finally
            fs = Nothing
        End Try

        Return b

    End Function

    Public Shared Function CreateFile(ByVal sFilePath As String,
                                      ByVal fileMode As IO.FileMode,
                                      ByVal fileAccess As IO.FileAccess,
                                      ByVal fileShare As IO.FileShare,
                                      ByVal iBufferSize As Integer,
                                      ByVal fileOptions As IO.FileOptions,
                                      ByVal btValue As Byte,
                                      ByVal bCloseFileStream As Boolean) As Boolean

        Dim b As Boolean = False
        Dim fs As FileStream = Nothing

        Try
            fs = New FileStream(sFilePath, fileMode, fileAccess, fileShare, iBufferSize, fileOptions)
            fs.WriteByte(btValue)

            If bCloseFileStream Then
                fs.Close()
                fs = Nothing
            End If

            b = True

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function GetFolderPathFromFilePath(ByVal sFilePath As String) As String

        Dim s As String = ""

        Try
            'IO.Path.GetDirectoryName
            s = sFilePath.Substring(0, sFilePath.LastIndexOf("\"))
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return s

    End Function

    Public Shared Function FileExists(ByVal sPath As String) As Boolean

        Try
            Return IO.File.Exists(sPath)
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function FolderExists(ByVal sPath As String) As Boolean

        Try
            Return IO.Directory.Exists(sPath)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function SetFileAttributes(ByVal sFilePath As String,
                                             ByVal attrs As IO.FileAttributes) As Integer

        Try
            Return FileUtils.SetFileAttributes(sFilePath, attrs, 1, 1)
        Catch ex As Exception
            Return 0
            Throw ex
        Finally
        End Try

    End Function

    Public Shared Function SetFileAttributes(ByVal sFilePath As String,
                                             ByVal attrs As IO.FileAttributes,
                                             ByVal iNrOfRepeats As Integer,
                                             ByVal iWaitTime As Integer) As Integer

        Dim i As Integer = 0
        Dim b As Boolean = False

        Try

            For i = 1 To iNrOfRepeats

                'try
                '-----------------------
                Try
                    IO.File.SetAttributes(sFilePath, attrs)
                    b = True
                Catch ex As Exception
                    b = False
                Finally
                End Try

                'success?
                '-----------------------
                If b Then
                    Exit For
                Else
                    Toolbox.ThreadUtils.SleepSeconds(iWaitTime)
                End If

            Next

        Catch ex As Exception
            Return 0
            Throw ex
        Finally
        End Try

        Return i

    End Function

    Public Shared Function DeleteFile(ByVal sFilePath As String,
                                      ByVal iNrOfRepeats As Integer,
                                      ByVal iSleepSeconds As Integer) As Integer

        Dim i As Integer = 0
        Dim b As Boolean = False

        For i = 1 To iNrOfRepeats

            'try
            '-----------------------
            Try
                IO.File.Delete(sFilePath)
                b = True
            Catch ex As Exception
                b = False
            End Try

            'success?
            '-----------------------
            If b Then
                Exit For
            Else
                Toolbox.ThreadUtils.SleepSeconds(iSleepSeconds)
            End If
        Next

        If b Then
            Return i
        Else
            Return 0
        End If

    End Function

    Public Shared Function DeleteFile(ByVal sFilePath As String) As Integer

        Try
            Return FileUtils.DeleteFile(sFilePath, 1, 1)
        Catch ex As Exception
            Return 0
            Throw ex
        End Try

    End Function

    Public Shared Function DeleteFolder(ByVal sPath As String,
                                        ByVal bDeleteSubContent As Boolean) As Boolean

        Dim b As Boolean = False

        Try
            IO.Directory.Delete(sPath, bDeleteSubContent)
            b = True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function EmptyFile(ByVal sFilePath As String) As Boolean

        Dim b As Boolean = False

        Try
            IO.File.WriteAllText(sFilePath, "")
            b = True
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function EmptyFolder(ByVal sFolderPath As String, _
                                       ByVal bSetFileAttributesForDeletionAllowance As Boolean) As Boolean

        Dim b As Boolean = False
        Dim attrs As IO.FileAttributes

        Try
            attrs = FileAttributes.Normal

            For Each sFilePath As String In IO.Directory.GetFiles(sFolderPath)

                'set attrs
                '-----------------------
                If bSetFileAttributesForDeletionAllowance Then
                    Try
                        IO.File.SetAttributes(sFilePath, attrs)
                    Catch ex As Exception
                        Throw ex
                    Finally
                    End Try
                End If


                'delete
                '-----------------------
                Try
                    IO.File.Delete(sFilePath)
                Catch ex As Exception
                    Throw ex
                Finally
                End Try
            Next

            b = True

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function IsTempFile(ByVal sFileName As String) As Boolean

        Dim b As Boolean = False

        Try
            b = sFileName.StartsWith("~")
        Catch ex As Exception
            Throw ex
        Finally
        End Try

        Return b

    End Function

    Public Shared Function Combine(ByVal sFolderPath As String,
                                   ByVal sFileName As String) As String

        Dim s As String = ""

        Try
            s = IO.Path.Combine(sFolderPath, sFileName)
        Catch ex As Exception
            Throw ex
        End Try

        Return s

    End Function

End Class

