
Imports System.Windows.Forms

Public Interface IFormCommon

    Sub _cancel()
    Sub _closeForm(ByVal bConfirm As Boolean)
    Sub _init()
    Sub _initUI()
    Sub _initTooltips()
    'Sub _updateSessionInstance()
    'Sub _setUIState(ByVal formState As Forms.frmFormBase.FormStateEnum, ByVal cursor As Cursor)

End Interface

