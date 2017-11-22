
Public Interface IFormSaveable

    Function _save() As Boolean
    Function _isRequiredFieldsFilled() As Boolean
    Function _instantiateFromUI() As Object
    'Sub _setSaveState(ByVal bIsSaveable As Boolean)
    'Sub _isDirty(ByVal b As Boolean)

End Interface

