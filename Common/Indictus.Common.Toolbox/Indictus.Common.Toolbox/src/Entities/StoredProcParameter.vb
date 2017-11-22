
Public Class StoredProcParameter
    Inherits DataBaseClasses

    Dim _name As String
    Dim _value As Object
    Dim _type As ValueTypes

    Public Sub New()
    End Sub

    Public Sub New(ByVal sName As String, _
                   ByVal oValue As Object, _
                   ByVal type As ValueTypes)

        If Not sName.StartsWith("@") Then sName = "@" & sName

        Me._name = sName
        Me._value = oValue
        Me._type = type

    End Sub

    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal Value As String)
            If Not Value.StartsWith("@") Then Value = "@" & Value
            Me._name = Value
        End Set
    End Property

    Public Property Value() As Object
        Get
            Return Me._value
        End Get
        Set(ByVal Value As Object)
            Me._value = Value
        End Set
    End Property

    Public Property Type() As ValueTypes
        Get
            Return Me._type
        End Get
        Set(ByVal Value As ValueTypes)
            Me._type = Value
        End Set
    End Property

    Public Overrides Function ToString() As String

        Return "Name:" & vbTab & Me._name.ToString & vbNewLine & _
               "Value: " & vbTab & Me._value.ToString & vbNewLine & _
               "Type: " & vbTab & Me._type.ToString

    End Function


End Class