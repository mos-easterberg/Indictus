
Imports System.Text

Public Class AppSettings

	Public Sub New()
	End Sub

	Public Enum TimeUnitEnum
		SECONDS
		MINUTES
		HOURS
	End Enum

    Public Property ApplicationName As String
    Public Property LogFolderPath As String
    Public Property WorkFolderPath As String

    Public Property IDMFolderPath As String
    Public Property IDMStartFolderName As String
    Public Property IDMStartFolderID As Integer


    'Public Property InstanceID As String
    ''Public Property DocumentRegisterListName As String
    'Public Property DummyValueForEmptySPField As String
    ''Public Property IDMDocZoneID As Integer
    'Public Property IDMPassword As String
    'Public Property IDMRequestContentType As String
    'Public Property IDMServerWebServiceURL As String
    'Public Property IDMUserName As String
    'Public Property SitesToSync As System.Collections.Specialized.StringCollection
    'Public Property IDMDocTypesES As System.Collections.Specialized.StringCollection
    'Public Property IDMDocTypesNEPA As System.Collections.Specialized.StringCollection
    ''Public Property FoldersToScan_dict As Dictionary(Of Integer, IDMFolder)
    ''Public Property IDMScanFolders As String
    ''Public Property IDMScanIncludeSubfolders As Boolean
    'Public Property IDMSearchResultPageSize As Integer
    'Public Property IDMJustDumpSearchResult As Boolean
    'Public Property LogEmptyOnStartup As Boolean
    'Public Property SharePointPassword As String
    'Public Property SharePointUserName As String
    ''Public Property WDOCParentSiteURL As String
    'Public Property IDMSaveIntermediateXMLFiles As Boolean
    'Public Property StatusSyncIntervalTimeUnits As Integer
    'Public Property TimeUnit As TimeUnitEnum
    'Public Property SitesFolderPath As String
    'Public Property IDMMaxFileSizeInBytes As Integer
    'Public Property ToolErrorNotifRecps As String
    ''Public Property ConditionReportRecipients As String
    'Public Property AutoStartLinkerUponAppLaunch As Boolean
    ''Public Property IDMDocumentTypeCode As String
    'Public Property IDMDocumentRelevanceCode As String
    'Public Property IDMDocumentLifecycleCode As String
    'Public Property IDMPDFConversionType As String
    'Public Property IDMInformationClassification As String
    'Public Property IDMLanguage As String
    'Public Property IDMCreateFrontPage As Boolean
    'Public Property IDMFrontPageIDReference As String
    ''Public Property IDMWartsilaCompany As String
    'Public Property IDMTestWorkspaceID As Integer
    ''Public Property IDMWorkspaceID As Integer
    'Public Property IDMTestFolderIDs As String
    'Public Property IDMTimeOutSecs As Integer
    'Public Property SharePointTestAddress As String
    ''Public Property LogModeDetailed As Boolean
    'Public Property SupplierDocumentRegisterListName As String
    'Public Property RunInTestMode As Boolean
    'Public Property DCMStatusesToSync As String

End Class
