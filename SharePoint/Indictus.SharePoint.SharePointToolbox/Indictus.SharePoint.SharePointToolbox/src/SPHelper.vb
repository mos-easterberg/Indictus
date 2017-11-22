
Imports Microsoft.SharePoint.Client
Imports Indictus.Common
Imports System.IO
Imports System.Text

Public Class SPHelper

    Public Shared Function ConnectToSPO(ByVal sURL As String, ByVal sSharePointUserName As String, ByVal sSharePointPassword As String) As ClientContext

        Dim spoConn As ClientContext = Nothing

        Try
            spoConn = New ClientContext(sURL)
            spoConn.Credentials = New SharePointOnlineCredentials(sSharePointUserName, Toolbox.EncodingUtils.TranslateToNETSecureString(sSharePointPassword))
        Catch ex As Exception
            Throw ex
        End Try

        Return spoConn

    End Function

    Public Shared Function IsConnected(ByVal spoConn As ClientContext, ByVal sListNameToTest As String) As Boolean

        Dim b As Boolean = False

        Try
            SPHelper.GetSPListItems(spoConn, sListNameToTest)
            b = True
        Catch ex As Exception
            'Throw ex
            Debug.WriteLine(ex.Message)
        End Try

        Return b

    End Function

    Public Shared Function IsFolder(ByVal item As ListItem)

        Dim b As Boolean = False

        Try
            b = (item.FileSystemObjectType = FileSystemObjectType.Folder)
        Catch ex As Exception
            Throw ex
        End Try

        Return b

    End Function

    Public Shared Function GetFolder(ByVal item As ListItem, ByVal spoConn As ClientContext) As Folder

        Try
            spoConn.Load(item.Folder)
            spoConn.Load(item.Folder.Files)
            spoConn.ExecuteQuery()

            Return item.Folder
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function DownloadFile(ByVal context As ClientContext, ByVal sFileURL As String, ByVal sSavePath As String) As Integer

        Dim sRelativeURL As String = ""
        Dim file As Microsoft.SharePoint.Client.File = Nothing
        Dim fileInfo As Microsoft.SharePoint.Client.FileInformation = Nothing
        Dim destFile As System.IO.FileStream = Nothing
        Dim buffer(8 * 1024) As Byte
        Dim iLen As Integer = 1
        Dim iFileSize As Integer = 0

        Try
            sRelativeURL = sFileURL.Substring(31)
            fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, sRelativeURL)
            destFile = System.IO.File.OpenWrite(sSavePath)
            While iLen > 0
                iLen = fileInfo.Stream.Read(buffer, 0, buffer.Length)
                destFile.Write(buffer, 0, iLen)
                iFileSize += iLen
            End While
            destFile.Close()

            Return iFileSize
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UploadSmallFile(ByVal spoConn As ClientContext, ByVal sLocalFilePath As String, ByVal sCloudFilePath As String,
                                      ByVal sListName As String) As Integer

        Try
            Dim currentWeb As Web = spoConn.Web
            Dim fileToUpload As FileCreationInformation = New FileCreationInformation

            fileToUpload.Content = System.IO.File.ReadAllBytes(sLocalFilePath)
            fileToUpload.Url = sCloudFilePath
            Dim list As List = currentWeb.Lists.GetByTitle(sListName)

            Dim uploadedFile As Microsoft.SharePoint.Client.File = list.RootFolder.Files.Add(fileToUpload)
            spoConn.Load(uploadedFile)
            spoConn.Load(uploadedFile.ListItemAllFields)
            spoConn.ExecuteQuery()

            Debug.WriteLine(uploadedFile.ListItemAllFields.Id)

            Return uploadedFile.ListItemAllFields.Id
        Catch ex As Exception
            Throw ex
        End Try

        Return -1

    End Function

    Public Shared Function GetSPListItems(ByVal context As ClientContext, ByVal sListName As String) As Microsoft.SharePoint.Client.ListItemCollection

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim items As ListItemCollection = list.GetItems(New CamlQuery)

            context.Load(items)
            context.ExecuteQuery()

            Return items
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function GetSPListItems(ByVal context As ClientContext, ByVal sListName As String, ByVal query As CamlQuery) As Microsoft.SharePoint.Client.ListItemCollection

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim items As ListItemCollection = list.GetItems(query)

            context.Load(items)
            context.ExecuteQuery()

            Return items
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function AddValuesToChoiceField(ByVal context As ClientContext, ByVal sList As String, ByVal sField As String, ByVal sValues As String()) As Boolean

        Try
            Dim field As Microsoft.SharePoint.Client.Field = Nothing
            Dim choiceField As Microsoft.SharePoint.Client.FieldChoice = Nothing

            field = SPHelper.GetSPField(context, sList, sField)
            choiceField = context.CastTo(Of FieldChoice)(field)
            'If sList.Equals("Communication") Then
            '    choiceField.EnforceUniqueValues = False
            '    choiceField.FillInChoice = True
            '    choiceField.Required = False
            '    choiceField.UpdateAndPushChanges(True)
            '    context.ExecuteQuery()
            'End If

            'field = SPHelper.GetSPField(context, sList, sField)
            'choiceField = context.CastTo(Of FieldChoice)(field)
            Dim sTemp As String() = choiceField.Choices
            choiceField.Choices = Toolbox.StringUtils.MergeStringArrays(sTemp, sValues)
            choiceField.UpdateAndPushChanges(True)
            context.ExecuteQuery()

            'If sList.Equals("Communication") Then
            '    choiceField.EnforceUniqueValues = True
            '    choiceField.FillInChoice = False
            '    choiceField.Required = True
            '    choiceField.UpdateAndPushChanges(True)
            '    context.ExecuteQuery()
            'End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try

        Return False

    End Function

    Public Shared Function GetSPField(ByVal context As ClientContext, ByVal sList As String, ByVal sField As String) As Microsoft.SharePoint.Client.Field

        Try
            Dim list As Microsoft.SharePoint.Client.List = SPHelper.GetSPList(context, sList)
            Dim fields As Microsoft.SharePoint.Client.FieldCollection = list.Fields
            context.Load(list.Fields)

            Dim field As Microsoft.SharePoint.Client.Field = fields.GetByTitle(sField)
            context.Load(field)
            context.ExecuteQuery()

            Return field
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetSPList(ByVal context As ClientContext, ByVal sListName As String) As Microsoft.SharePoint.Client.List

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)

            context.Load(list)
            context.ExecuteQuery()
            Return list
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function CountNrOfFilesPerFolder(ByVal conn As ClientContext, ByVal sDocLibName As String, ByVal arrFoldersToCount As ArrayList) As Dictionary(Of String, Integer)

        Dim dict As New Dictionary(Of String, Integer)
        Dim i As Integer = 1

        Try
            For Each item As ListItem In SPHelper.GetSPListItems(conn, sDocLibName)
                Try
                    If SPHelper.IsFolder(item) Then
                        Dim folder As Folder = SPHelper.GetFolder(item, conn)
                        Dim sFolderName As String = folder.Name
                        Debug.WriteLine(i & ": " & sFolderName)
                        If sFolderName.Length.Equals(6) Then
                            conn.Load(folder)
                            conn.Load(folder.Folders)
                            conn.ExecuteQuery()
                            For Each subFolder In folder.Folders
                                Try
                                    Dim s As String = Toolbox.StringUtils.Split(subFolder.Name, " ").Item(1).ToString
                                    If arrFoldersToCount.Contains(s.ToUpper) Then
                                        'Debug.WriteLine
                                        dict.Add(subFolder.Name, subFolder.ItemCount)
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                        End If
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try

                i += 1
                'If i = 4 Then Exit For
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return dict

    End Function

    Public Shared Function GetSPListItem(ByVal context As ClientContext, ByVal sListName As String, ByVal iID As Integer) As Microsoft.SharePoint.Client.ListItem

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim item As ListItem = list.GetItemById(iID)

            context.Load(item)
            context.ExecuteQuery()
            'Debug.WriteLine(item.Id)

            Return item
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function GetListItemAttachmentFiles(ByVal context As ClientContext, ByVal sListName As String, ByVal iID As Integer) As Microsoft.SharePoint.Client.AttachmentCollection

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim item As ListItem = list.GetItemById(iID)

            context.Load(item)
            context.Load(item.AttachmentFiles)
            context.ExecuteQuery()
            'Debug.WriteLine(item.AttachmentFiles.Count)

            If item.AttachmentFiles.AreItemsAvailable Then
                Return item.AttachmentFiles
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Sub UpdateSPListItem(ByVal context As ClientContext, ByVal sListName As String, ByVal iItemID As Integer,
                                       ByVal sFieldName As String, ByVal sFieldValue As String)

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim item As ListItem = list.GetItemById(iItemID)

            context.Load(item)
            context.ExecuteQuery()

            item.ParseAndSetFieldValue(sFieldName, sFieldValue)
            item.Update()

            context.Load(item)
            context.ExecuteQuery()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function UpdateSPListItem(ByVal context As ClientContext, ByVal item As ListItem, ByVal spDoc As SPDocument) As Boolean

        Try
            context.Load(item)
            context.ExecuteQuery()

            For Each kvp As KeyValuePair(Of String, Object) In spDoc.DocumentValues
                If TypeOf (kvp.Value) Is Microsoft.SharePoint.Client.FieldUrlValue Then
                    Dim sURL As String = DirectCast(kvp.Value, FieldUrlValue).Url
                    'Dim urlField As New Microsoft.SharePoint.Client.FieldUrlValue
                    'urlField.Url = kvp.Value.ToString
                    item.ParseAndSetFieldValue(kvp.Key, sURL)
                Else
                    item.ParseAndSetFieldValue(kvp.Key, kvp.Value.ToString)
                End If
            Next

            item.Update()
            context.Load(item)
            context.ExecuteQuery()
        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function

    Public Shared Function UpdateSPListItem(ByVal context As ClientContext, ByVal sListName As String, ByVal iItemID As Integer, ByVal spDoc As SPDocument) As Boolean

        Try
            Dim site As Web = context.Web
            Dim list As List = site.Lists.GetByTitle(sListName)
            Dim item As ListItem = list.GetItemById(iItemID)

            context.Load(item)
            context.ExecuteQuery()

            For Each kvp As KeyValuePair(Of String, Object) In spDoc.DocumentValues
                item.ParseAndSetFieldValue(kvp.Key, kvp.Value)
            Next

            item.Update()
            context.Load(item)
            context.ExecuteQuery()
        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function

    Public Shared Sub UpdateSPListItem(ByVal context As ClientContext, ByVal item As ListItem, ByVal sFieldName As String, ByVal sFieldValue As String)

        Try
            item.ParseAndSetFieldValue(sFieldName, sFieldValue)
            item.Update()
            context.Load(item)
            context.ExecuteQuery()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function AddListItem(ByVal context As ClientContext, ByVal sListName As String, ByVal dictItemFieldAndValue As Dictionary(Of String, String)) As Boolean

        Try
            Dim list As List = context.Web.Lists.GetByTitle(sListName)
            Dim itemCreateInfo As New ListItemCreationInformation
            Dim item As ListItem = list.AddItem(itemCreateInfo)

            For Each kvp As KeyValuePair(Of String, String) In dictItemFieldAndValue
                item(kvp.Key) = kvp.Value
            Next

            item.Update()
            context.ExecuteQuery()

            Return True
        Catch ex As Exception
            Throw ex
        End Try

        Return False

    End Function

    Public Shared Function ReadSPListItemValueAsString(ByVal item As ListItem, ByVal sFieldName As String, ByVal bThrowEx As Boolean) As String

        Try
            Return item.FieldValues(sFieldName).ToString
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ReadSPListItemValueAsFieldUrlValue(ByVal item As ListItem, ByVal sFieldName As String, ByVal bThrowEx As Boolean) As String

        Try
            Dim fuv As New Microsoft.SharePoint.Client.FieldUrlValue
            fuv = item.FieldValues(sFieldName)
            Return fuv.Url
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ReadSPListItemValueAsBoolean(ByVal item As ListItem, ByVal sFieldName As String, ByVal bThrowEx As Boolean) As Boolean

        Try
            If item.FieldValues(sFieldName).ToString.ToUpper.Equals("TRUE") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function ReadSPListItemValueAsInteger(ByVal item As ListItem, ByVal sFieldName As String, ByVal bThrowEx As Boolean) As Integer

        Try
            Return Toolbox.ConversionUtils.ParseInteger(item.FieldValues(sFieldName).ToString, False)
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

        Return Nothing

    End Function

    Public Shared Function GetSPDocDetails(ByVal spDoc As ListItem) As String

        Dim sb As New StringBuilder

        Try
            sb.Append("Title\ID: ")
            sb.Append(SPHelper.ReadSPListItemValueAsString(spDoc, "Title", False))
            sb.Append("\")
            sb.Append(SPHelper.ReadSPListItemValueAsInteger(spDoc, "ID", False))
        Catch ex As Exception
        End Try

        Return sb.ToString

    End Function

End Class
