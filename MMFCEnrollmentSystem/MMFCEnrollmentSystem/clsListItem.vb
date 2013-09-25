Public Class clsListItem
    Dim _ID As Integer
    Dim _Name As String
    Public Property ID()
        Get
            Return _ID
        End Get
        Set(ByVal value)
            _ID = value
        End Set
    End Property
    Public Property Name()
        Get
            Return _Name
        End Get
        Set(ByVal value)
            _Name = value
        End Set
    End Property
    Public Sub New()
        _ID = 0
        _Name = ""
    End Sub

    Public Overrides Function ToString() As String
        Return _Name
    End Function
End Class
