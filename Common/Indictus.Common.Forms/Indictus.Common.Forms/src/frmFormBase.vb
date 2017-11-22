
Public Class frmFormBase
    Inherits System.Windows.Forms.Form

    Public Enum FormStateEnum
        LOADING
        IDLE
        SAVING
        CLOSING
    End Enum


    Protected Property IsClosing() As Boolean
    Protected Property IsDirty() As Boolean
    Protected Property IsSaved() As Boolean

    Protected Property FormState As FormStateEnum

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.Icon = My.Resources.

    End Sub

End Class