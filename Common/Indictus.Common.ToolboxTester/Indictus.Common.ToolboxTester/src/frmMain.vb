
Imports Indictus.Common

Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me._initUI()
            If My.Settings.RunTestsOnAppLoad Then Me._runTests()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me._quit()
    End Sub

    Private Sub _quit()
        Application.ExitThread()
        Application.Exit()
    End Sub

    Private Sub _initUI()

        Try
            Me.txtInput1.Text = "magnus.osterberg@wartsila.com"
            Me.txtInput2.Text = "magnus.osterberg@wartsila.com,WDOC.InternalAdmiUser1@outlook.com,magnus_osterberg@hotmail.com"
            Me.txtInput3.Text = "smtp.wartsila.com"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnRunTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunTests.Click
        Me._runTests()
    End Sub

    Private Sub _runTests()

        Try
            'Me._testDateUtils()
            'Me._testEncodingUtils()
            'Me._testMailUtils("magnus.osterberg@wartsila.com", "magnus.osterberg@wartsila.com")
            'Me._testMailUtils(Me.txtInput1.Text, Me.txtInput2.Text, Me.txtInput3.Text)
            'Me._testNumberUtils()
            Me._testStringUtils2()

            If My.Settings.QuitAfterTesting Then
                Me._quit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub _testDateUtils()

        Try
            Dim dt As Date = Date.Now

            Me.txtMsg.AppendText(Toolbox.DateAndTimeUtils.ConvertDate(Toolbox.DateAndTimeUtils.DateStyle.SWEDISH, Toolbox.DateAndTimeUtils.DateFormat.LONG, dt) & vbNewLine)
            Me.txtMsg.AppendText(Toolbox.DateAndTimeUtils.ConvertDate(Toolbox.DateAndTimeUtils.DateStyle.FINNISH, Toolbox.DateAndTimeUtils.DateFormat.LONG, dt))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Private Sub _convertFolderContentToPDF(ByVal bOpenApp As Boolean, _
    '                                       ByVal sTestareaFolderPath As String)

    '    Dim sb As New StringBuilder
    '    Dim generator As Toolbox.PDFUtils.PDFGenerator
    '    Dim sPDFPath As String = ""
    '    Dim sFiles() As String

    '    Try
    '        sFiles = IO.Directory.GetFiles(sTestareaFolderPath)
    '        For Each sFilePath As String In sFiles
    '            sPDFPath = sFilePath & ".pdf"
    '            generator = Nothing

    '            Select Case Toolbox.FileUtils.GetFileExtension(sFilePath).ToUpper
    '                Case "XLSX" : generator = Toolbox.PDFUtils.PDFGenerator.Excel2007
    '                Case "PPTX" : generator = Toolbox.PDFUtils.PDFGenerator.PowerPoint2007
    '                Case "DOCX" : generator = Toolbox.PDFUtils.PDFGenerator.Word2007
    '                Case Else : generator = Nothing
    '            End Select

    '            'If Not IsNothing(generator) Then
    '            '    sb.Append(generator.ToString)
    '            '    sb.Append(Toolbox.PDFUtils.GeneratePDF(sFilePath, _
    '            '                                           sPDFPath, _
    '            '                                           generator, _
    '            '                                           bOpenApp, _
    '            '                                           Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)
    '            'End If

    '        Next
    '    Catch ex As Exception
    '        'Throw ex
    '        sb.Append(ex.Message)
    '    Finally
    '    End Try

    'End Sub

    Private Sub _testPDFUtils(ByVal bOpenApp As Boolean, _
                              ByVal sTestareaFolderPath As String)

        Dim sb As New StringBuilder

        Try
            'sb.Append("Word 2003: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "word2003-file-01.doc", _
            '                                       sTestareaFolderPath & "word2003-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.Word2003, _
            '                                       bOpenApp, _
            '                                       Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)

            'sb.Append("Word 2007: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "word2007-file-01.docx", _
            '                                       sTestareaFolderPath & "word2007-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.Word2007, _
            '                                       bOpenApp, _
            '                                       Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)

            'sb.Append("Excel 2003: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "excel2003-file-01.xls", _
            '                                       sTestareaFolderPath & "excel2003-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.Excel2003, _
            '                                       bOpenApp, _
            '                                       Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)

            'sb.Append("Excel 2007: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "excel2007-file-01.xlsx", _
            '                                       sTestareaFolderPath & "excel2007-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.Excel2007, _
            '                                       bOpenApp, _
            '                                       Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)

            'sb.Append("PowerPoint 2003: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "powerpoint2003-file-01.ppt", _
            '                                       sTestareaFolderPath & "powerpoint2003-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.PowerPoint2003, _
            '                                       True, _
            '                                       Toolbox.PDFUtils.PDFOptimizeFor.SCREEN).ToString & vbNewLine)

            'sb.Append("PowerPoint 2007: ")
            'sb.Append(Toolbox.PDFUtils.GeneratePDF(sTestareaFolderPath & "powerpoint2007-file-01.pptx", _
            '                                       sTestareaFolderPath & "powerpoint2007-file-01.pdf", _
            '                                       Toolbox.PDFUtils.PDFGenerator.PowerPoint2007, _
            '                                       True, _
            '                                       Toolbox.PDFUtils.PDFOptimizedFor.SCREEN).ToString & vbNewLine)

            Me.txtMsg.Text = sb.ToString

        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

    Private Sub _testFileUtils()

        Dim sb As New StringBuilder
        Dim sFilePath As String = ""
        'Dim d As Toolbox.DummyFile = Nothing

        Try
            sFilePath = "\\fivedms1\WatchFolder\PADocsFolder\temp\dummy.txt"

            'sb.AppendLine("unicode: " & Toolbox.FileUtils.WriteMessage("C:\testarea\Indictus.Common.Toolbox\FileUtils\unicode.txt", "Панель", System.Text.Encoding.Unicode))
            'sb.AppendLine("ascii: " & Toolbox.FileUtils.WriteMessage("C:\testarea\Indictus.Common.Toolbox\FileUtils\ascii.txt", "Панель", System.Text.Encoding.ASCII))
            'sFilePath = "C:\misc\testarea\Indictus.Common.Toolbox\FileUtils\dummy.txt"

            sb.AppendLine("Create: " & Toolbox.FileUtils.CreateFile(sFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 100, FileOptions.DeleteOnClose, 123, False).ToString)
            sb.AppendLine("Exists: " & Toolbox.FileUtils.FileExists(sFilePath))

            'd = New Toolbox.DummyFile(sFilePath)

            Me.txtMsg.Text = sb.ToString
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

    Private Sub _testMailUtils(ByVal sFrom As String, ByVal sTo As String, ByVal sServer As String)

        Dim b As Boolean = False
        Dim dtTime As Date = Now

        Try
            Me.txtMsg.AppendText(dtTime & ": sending mail from " & sFrom & " to " & sTo & "..." & vbNewLine)
            b = Toolbox.EmailUtils.SendMail(sFrom, sTo, "", "", "E-mail test msg from " & Environment.MachineName, "Time sent: " & dtTime, "", sServer, 0, False, 30, False, "")
            Me.txtMsg.AppendText("Mail send success: " & b.ToString)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub _testStringUtils1()

        Dim sb As New StringBuilder
        Dim b As Boolean = True

        Try
            If b Then b = StringUtilsTester.IsInDelimitedString(True, "a;bc;def", ";", "a", False)
            If b Then b = StringUtilsTester.IsInDelimitedString(True, "a;bc;def", ";", "bc", False)
            If b Then b = StringUtilsTester.IsInDelimitedString(True, "a;bc;def", ";", "def", False)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "", False)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "ab", False)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "A", True)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "bC", True)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "Bc", True)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ";", "BC", True)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", ":", "BC", True)
            If b Then b = StringUtilsTester.IsInDelimitedString(False, "a;bc;def", "", "BC", True)

            If b Then
                Me.txtMsg.Text = "All tests passed!"
            Else
                Me.txtMsg.Text = "Some test(s) failed!"
            End If

            If My.Settings.QuitAfterTesting Then Me._quit()

        Catch ex As Exception
            Me.txtMsg.Text = ex.Message.ToString
        Finally
        End Try

    End Sub

    Private Sub _testStringUtils2()

        Try
            Dim s1 As String() = New String() {"a", "b", "c"}
            Dim s2 As String() = New String() {"d", "e"}

            Dim o As New Object
            o = Toolbox.StringUtils.MergeStringArrays(s1, s2)
            MsgBox(o.ToString)
        Catch ex As Exception
            Me.txtMsg.Text = ex.Message.ToString
        End Try

    End Sub

    Private Sub _testEncodingUtils()

        Dim sb As New StringBuilder

        Try
            sb.Append(Toolbox.EncodingUtils.EncodeString("WÃ¤rtsilÃ¤ Finland Oy", System.Text.Encoding.UTF8, False))
        Catch ex As Exception
            Throw ex
        End Try

        Me.txtMsg.Text = sb.ToString

    End Sub

    Private Sub _testNumberUtils()

        Dim b As Boolean = True
        Dim sb As New StringBuilder
        Dim sep As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        Try
            'sb.AppendLine("Should be true:")
            'sb.AppendLine("IsBetween(-1, 0, 1): " + Toolbox.NumberUtils.IsBetween(-1, 0, 1).ToString)
            'sb.AppendLine("IsBetween(0, 0, 0): " + Toolbox.NumberUtils.IsBetween(0, 0, 0).ToString)
            'sb.AppendLine("IsBetween(0, 0, 1): " + Toolbox.NumberUtils.IsBetween(0, 0, 1).ToString)
            'sb.AppendLine("IsBetween(5, 6, 6): " + Toolbox.NumberUtils.IsBetween(5, 6, 6).ToString)
            'sb.AppendLine("IsBetween(5, 6, 7): " + Toolbox.NumberUtils.IsBetween(5, 6, 7).ToString)
            'sb.AppendLine("")
            'sb.AppendLine("Should be false:")
            'sb.AppendLine("IsBetween(0, 1, 0): " + Toolbox.NumberUtils.IsBetween(0, 1, 0).ToString)
            'sb.AppendLine("IsBetween(2, 1, 1): " + Toolbox.NumberUtils.IsBetween(2, 1, 1).ToString)
            'sb.AppendLine("IsBetween(1, 0, 2): " + Toolbox.NumberUtils.IsBetween(1, 0, 2).ToString)
            'sb.AppendLine("IsBetween(2, 1, 2): " + Toolbox.NumberUtils.IsBetween(2, 1, 2).ToString)

            'sb.AppendLine("Parsing double 3.14: " & Toolbox.ConversionUtils.ParseDouble("3.14", True))
            'sb.AppendLine("Parsing double 3,14: " & Toolbox.ConversionUtils.ParseDouble("3,14", ",", ".", True))
            'sb.AppendLine("Parsing double 3,14: " & Toolbox.ConversionUtils.ParseDouble("3,14", ",", sep, True))

            sb.AppendLine("Parsing decimal 3.14: " & Toolbox.ConversionUtils.ParseDecimal("3.14", True))
            sb.AppendLine("Parsing decimal 3,14: " & Toolbox.ConversionUtils.ParseDecimal("3,14", ",", ".", True))
            sb.AppendLine("Parsing decimal 3,14: " & Toolbox.ConversionUtils.ParseDecimal("3,14", ",", sep, True))
            sb.AppendLine("Parsing decimal 1.234,65: " & Toolbox.ConversionUtils.ParseDecimal("1.234,65", ",", sep, True))

            Me.txtMsg.Text = sb.ToString
        Catch ex As Exception
            Me.txtMsg.Text = ex.Message.ToString
        Finally
        End Try

    End Sub

    Private Sub _testMSSQLUtils()

        Dim sb As New StringBuilder
        Dim conn As SqlClient.SqlConnection = Nothing
        Dim settings As New Toolbox.MSSQLSettings
        Dim ds As DataSet = Nothing
        Dim sSQL As String = ""
        Dim b As Boolean = False

        Try
            settings.DataSource = "FIVPLM01.citec.local"
            settings.InitialCatalog = "ProArc"
            settings.UserID = "PA_admin"
            settings.Password = Toolbox.EncryptionUtils.SimpleEncrypt("Tbgwn1hgb4")

            'IsConnectionOpen
            '-----------------------
            conn = Toolbox.MSSQLUtils.GetConnection(settings)
            'conn = Toolbox.MSSQLUtils.GetConnection(
            '"Persist Security Info=False;Integrated Security=false;Initial Catalog=CIP;server=FIVPLM01.citec.local"
            sb.AppendLine("IsConnectionOpen (assumed True): " & Toolbox.MSSQLUtils.IsConnectionOpen(conn))


            'SetData
            '-----------------------
            sSQL = "update dbo.DOCUMENT set TITLE = 'MSSQLUtils-002' where DOC_ID = 'NN-0000023'"
            b = Toolbox.MSSQLUtils.SetData(conn, sSQL, 5)
            sb.AppendLine(sSQL & ": " & b)


            'GetData
            '-----------------------
            sSQL = "select TITLE from dbo.DOCUMENT where DOC_ID = 'NN-0000023'"
            ds = Toolbox.MSSQLUtils.GetData(conn, sSQL)
            sb.AppendLine(sSQL & ": " & ds.Tables(0).Rows(0).Item(0).ToString)


            'IsConnectionOpen
            '-----------------------
            conn.Close()
            sb.AppendLine("IsConnectionOpen (assumed False): " & Toolbox.MSSQLUtils.IsConnectionOpen(conn))

            Me.txtMsg.Text = sb.ToString

        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            conn = Nothing
            GC.Collect()
        End Try

    End Sub

    Private Sub _testEnvironmentUtils()

        Dim b As Boolean = True
        Dim sb As New StringBuilder
        Dim s As String = ""

        Try

            'sb.AppendLine(Toolbox.EnvironmentUtils.GetEnvironmentVariable("USERPROFILE"))
            'sb.AppendLine(Toolbox.EnvironmentUtils.GetEnvironmentVariables(""))

            sb.AppendLine(Toolbox.EnvironmentUtils.GetMachineInformation(", ").ToString)
            sb.AppendLine(Toolbox.EnvironmentUtils.GetUserInformation(", ").ToString)

            s = sb.ToString

        Catch ex As Exception
            s = ex.Message.ToString
        Finally
            Me.txtMsg.Text = s
        End Try

    End Sub

    Private Sub _testXMLUtils()

        Dim b As Boolean = True
        Dim sb As New StringBuilder
        Dim sFilePath As String = ""
        Dim s As String = ""

        Try
            sFilePath = "C:\misc\testarea\Indictus.Common.Toolbox\XMLUtils\books.xml"
            sb.AppendLine(Toolbox.XMLUtils.ParseXML(sFilePath, Toolbox.XMLUtils.XMLReadTypeEnum.CURSOR_BASED))
        Catch ex As Exception
            s = ex.Message.ToString
        Finally
            Me.txtMsg.Text = sb.ToString
        End Try

    End Sub

    Private Sub _testMathUtils()

        Dim sb As New StringBuilder

        Try
            'triangles
            sb.AppendLine("Area of triangle with base length 3 and height 5: " & Toolbox.MathUtils.GetTriangleArea(3, 5).ToString)
            sb.AppendLine("Area of parallelogram with base length 3 and height 5: " & Toolbox.MathUtils.GetParallelogramArea(3, 5).ToString)
            sb.AppendLine("Area of paralleltrapeze with lengths 3, 5 and height 3: " & Toolbox.MathUtils.GetParallelTrapezeArea(3, 5, 3).ToString)

            'circle
            sb.AppendLine("Area of circle with radius 4: " & Toolbox.MathUtils.GetCircleArea(4).ToString)
            sb.AppendLine("Circumference of circle with radius 4: " & Toolbox.MathUtils.GetCircleCircumference(4).ToString)
            sb.AppendLine("Area of circle sector with radius 4 and bow length 5: " & Toolbox.MathUtils.GetCircleSectorArea(4, 5).ToString)

            'cylinder, pyramid, cone, bowl
            sb.AppendLine("Volume of cylinder with radius 4 and height 5: " & Toolbox.MathUtils.GetCylinderVolume(4, 5).ToString)
            sb.AppendLine("Area of cylinder case with radius 4 and height 5: " & Toolbox.MathUtils.GetCylinderCaseArea(4, 5).ToString)
            sb.AppendLine("Volume of pyramid with base length 4 and height 5: " & Toolbox.MathUtils.GetPyramidVolume(4, 5).ToString)
            sb.AppendLine("Area of cone with radius 3 and side height 5: " & Toolbox.MathUtils.GetConeCaseArea(3, 5).ToString)
            sb.AppendLine("Volume of cone with radius 3, height 8: " & Toolbox.MathUtils.GetConeVolume(3, 8).ToString)
            sb.AppendLine("Area of bowl with radius 5: " & Toolbox.MathUtils.GetBowlArea(5).ToString)
            sb.AppendLine("Volume of bowl with radius 5: " & Toolbox.MathUtils.GetBowlVolume(5).ToString)

        Catch ex As Exception
            Me.txtMsg.Text = ex.Message
        Finally
            Me.txtMsg.Text = sb.ToString
        End Try

    End Sub

    Private Sub btnEmpty_Click(sender As System.Object, e As System.EventArgs) Handles btnEmpty.Click
        Me.txtMsg.Clear()
    End Sub

End Class
