
Option Strict Off

Imports System.Windows.Forms

Public Class UIUtils
    Inherits BaseUtils

    Public Enum FormState
        LOADING
        IDLE
    End Enum

    Public Enum MessageType
        [INFO]
        [WARNING]
    End Enum

    Public Enum ConfirmationType
        [YES_NO]
        [YES_NO_CANCEL]
    End Enum

    Public Enum QuestionType
        [QUESTION]
    End Enum

    Public Shared Sub SetFormState(ByVal state As FormState, ByRef frm As Form)

        Try
            Select Case state
                Case FormState.IDLE
                    UIUtils.SetCursor(Cursors.Default, frm)
                Case FormState.LOADING
                    UIUtils.SetCursor(Cursors.WaitCursor, frm)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Sub SetCursor(ByVal cursor As Cursor, ByRef frm As Form)

        Try
            frm.Cursor = cursor
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Sub ShowMessageBox(ByVal sMessage As String,
                                     ByVal sTitle As String,
                                     ByVal type As MessageType)

        Try
            Select Case type
                Case MessageType.INFO
                    MsgBox(sMessage, vbOKOnly + vbInformation, sTitle)
                Case MessageType.WARNING
                    MsgBox(sMessage, vbOKOnly + vbExclamation, sTitle)
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try

    End Sub

    Public Shared Function AskConfirmation(ByVal sMessage As String, _
                                           ByVal sTitle As String, _
                                           ByVal type As ConfirmationType) As MsgBoxResult

        Dim answer As MsgBoxResult = Nothing
        Dim answerOption As MsgBoxStyle = Nothing

        Try
            Select Case type
                Case ConfirmationType.YES_NO
                    answerOption = vbYesNo
                Case ConfirmationType.YES_NO_CANCEL
                    answerOption = vbYesNoCancel
            End Select

            answer = MsgBox(sMessage, answerOption + vbQuestion, sTitle)

        Catch ex As Exception
            Throw ex
        End Try

        Return answer

    End Function

    Public Shared Function ShowQuestionBox(ByVal sMessage As String, _
                                           ByVal sTitle As String, _
                                           ByVal sDefaultResponse As String, _
                                           ByVal type As QuestionType) As String

        Dim s As String = ""

        Try
            Select Case type
                Case QuestionType.QUESTION
                    s = InputBox(sMessage, sTitle, sDefaultResponse)
            End Select
        Catch ex As Exception
            Throw ex
        End Try

        Return s

    End Function

    Public Shared Sub LoadDataSetToUI(ByVal ctrl As System.Windows.Forms.Control,
                                      ByVal ds As DataSet,
                                      ByVal bSetFirstValue As Boolean,
                                      ByVal bEmptyControlBeforeLoad As Boolean,
                                      ByVal bAddEmptyRowAtTop As Boolean)

        Dim bValesExist As Boolean = False

        Try
            Select Case ctrl.GetType

                'ComboBox
                '------------------------------------------------
                Case GetType(System.Windows.Forms.ComboBox)
                    If bEmptyControlBeforeLoad Then DirectCast(ctrl, System.Windows.Forms.ComboBox).Items.Clear()
                    If bAddEmptyRowAtTop Then DirectCast(ctrl, System.Windows.Forms.ComboBox).Items.Add("")
                    For Each row As DataRow In ds.Tables(0).Rows
                        DirectCast(ctrl, System.Windows.Forms.ComboBox).Items.Add(row.Item(0).ToString)
                        bValesExist = True
                    Next
                    If bSetFirstValue AndAlso bValesExist Then
                        DirectCast(ctrl, System.Windows.Forms.ComboBox).Text = DirectCast(ctrl, System.Windows.Forms.ComboBox).Items(0).ToString
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        Finally
            ds = Nothing
        End Try

    End Sub

    Public Shared Sub WriteToUI(ByVal sMsg As String, ByVal bThrowEx As Boolean, ByRef ctrl As Object)

        Try
            ctrl.Text = sMsg
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

    End Sub

    Public Shared Sub CheckAllTreeNodesRecursively(ByRef node As TreeNode, ByVal bCheck As Boolean)

        Try
            node.Checked = bCheck

            If node.Nodes.Count > 0 Then
                For Each nd As TreeNode In node.Nodes
                    nd.ForeColor = Drawing.Color.Black
                    UIUtils.CheckAllTreeNodesRecursively(nd, bCheck)
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SetTooltip(ByRef ctrl As Control, ByVal sText As String, ByVal bThrowEx As Boolean)

        Dim tt As ToolTip = Nothing

        Try
            tt = New ToolTip
            tt.SetToolTip(ctrl, sText)
        Catch ex As Exception
            If bThrowEx Then Throw ex
        End Try

    End Sub

End Class
