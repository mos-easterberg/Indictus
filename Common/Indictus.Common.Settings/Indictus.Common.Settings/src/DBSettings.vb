
Imports System.Text

Public NotInheritable Class DBSettings
    Implements ISettings

    Public Enum VendorEnum
        [MYSQL]
        [MSSQL]
        [POSTGRES]
    End Enum

    Public Property TableOwner As String
    Public Property DataSource As String
    Public Property InitialCatalog As String
    Public Property UserID As String
    Public Property Password As String
    Public Property ConnectionString As String
    Public Property ServerName As String
    Public Property ServerPortNr As Integer
    Public Property Vendor As VendorEnum
    Public Property TimeOutSeconds As Integer

    Public Overrides Function ToString() As String Implements ISettings.ToString
        Return ""
    End Function

End Class
