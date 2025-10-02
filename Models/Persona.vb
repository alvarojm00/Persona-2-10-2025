Public Class Persona

    Private _nombre As String
    Private _apellido As String
    Private edad As Integer

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    Public Property Edad1 As Integer
        Get
            Return edad
        End Get
        Set(value As Integer)
            edad = value
        End Set
    End Property



    Public Sub New(nombre As String, apellido As String, edad1 As Integer)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad1 = edad1
    End Sub

    Public Sub New(v As Integer)
        ' Constructor por defecto
        Me.Nombre = "No hay nombre"

    End Sub

    Public Sub New(nombre As String, apellido As String)
        _nombre = nombre
        _apellido = apellido
    End Sub

    Public Sub New()
    End Sub
End Class
